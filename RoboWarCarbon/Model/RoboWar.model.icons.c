/*
 *  RoboWar.model.icons.c
 *  RoboWar
 *
 *  Created by Sam Rushing on Wed Jun 30 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 *  I've moved away from the original GraphicWorlds approach in an
 *  attempt to make the whole procedure more modular and easy to understand.
 *  I'm not sure how the change affects performance, but it makes more
 *	sense when you go back and read the code.
 */

#include "CarbonWrapper.h"
#include "RoboTypes.h"

// ----- from RoboWar.errors.c -----
extern OSErr displayErr(char *errCode, char *errName, char *proc);
extern OSErr checkMemErr(char *proc);
extern OSErr checkResErr(char *proc);


void DisposeGenericIcon( GenericIcon * icon )
{
	if (icon->type == kGenericIconTypeColor && icon->data != NULL)
		DisposeCIcon( (CIconHandle)icon->data );
	else if (icon->type == kGenericIconTypeMono && icon->data != NULL) {
		ReleaseResource( (Handle)icon->data );
	}
	if (icon->mask) DisposeRgn(icon->mask);

	icon->type = kGenericIconTypeNULL;
	icon->data = NULL;
	icon->mask = NULL;
}

void GetGenericIcon( SInt16 iconID, GenericIcon * icon )
{
	BitMap map = {
		NULL,
		4,
		{0, 0, 32, 32}
	};
		
	DisposeGenericIcon( icon );
	
	map.baseAddr = NewPtr( 128 ); // create a new bitmap data field for the Mask
	map.bounds.top = map.bounds.left = 0; // our icons are always 32x32
	map.bounds.bottom = map.bounds.right = 32;
	
	if ( (icon->data = GetCIcon( iconID )) != NULL ) {
		int i, j;
		unsigned char t[128], flag, whiteIndex = 0;
		
		icon->type = kGenericIconTypeColor; // yes, it's a color icon.
		flag = 0xFF;
		
		for (i=0; i<128; i++) {
			flag &= (t[i]= ((unsigned char *)(*((CIconHandle)icon->data))->iconMaskData)[i]);
		}
		
		if (flag == 0xFF) {
			CTabPtr ct = *((*((CIconHandle)icon->data))->iconPMap.pmTable);
			
			// find out what index is white
			for (i=0; i<ct->ctSize; i++) {
				RGBColor * rgb = &(ct->ctTable[i].rgb);
				if (rgb->red == 0xFFFF
				 && rgb->green == 0xFFFF
				 && rgb->blue == 0xFFFF) {
					whiteIndex = i;
					break;
				}
			}
			
			// create a b&w image
			for (i=0; i<128; i++) {
				for (j=0; j<8; j++) {
					unsigned char b = (*(*((CIconHandle)icon->data))->iconData)[i*8+j];
					t[i] = (t[i] << 1) + (b!=whiteIndex);
				}
			}
		}
			
		CalcMask( t, map.baseAddr, 4, 4, 32, 2 );
	} else if ( (icon->data = GetIcon( iconID )) != NULL ) {
		DetachResource( (Handle)icon->data ); // resource clean-up. so we can close the resource file.
		
		icon->type = kGenericIconTypeMono; // yes it's a monochrome image
		
		CalcMask( *(Handle)(icon->data), map.baseAddr, 4, 4, 32, 2 );
	} else {
		DisposePtr( map.baseAddr ); // memory clean up
		return;
	}
	
	icon->mask = NewRgn(); // create a new mask region
	
	BitMapToRegion( icon->mask, &map ); // convert the bitmap to a region
	DisposePtr( map.baseAddr ); // memory clean up
}

void PutGenericIcon( SInt16 iconID, GenericIcon * icon )
{
	// This function saves icons to the robot res file. It will build a 'cicn'
	// from scratch to save color icon resources. I've hardcoded the template
	// 'cicn' resource into the following code to prevent having to load it
	// from a resource. I always found the "Blank Icon" annoying... -- Rushing

	Handle res = NULL;
	Str255 blankName = "\p";
	
	// define color component arrays so that we can construct 'cicn' resources
	// using loops... doing it without loops would be a heck of a lot of code!
	static unsigned short gradient1[6] = {
		0xFFFF, 0xCCCC, 0x9999, 0x6666, 0x3333, 0x0000
	};
	static unsigned short gradient2[10] = {
		0xEEEE, 0xDDDD, 0xBBBB, 0xAAAA, 0x8888, 0x7777, 0x5555, 0x4444, 0x2222, 0x1111
	};
		
/*
	unsigned long dateTime;
	GetDateTime( &dateTime );

	// remove the old DATE resource for Icons.
	if ((res = GetResource('DATE',iconDateID)) != NULL) {
		RemoveResource(res);
		checkResErr("RoboWar.model.icons:PutGenericIcon:1");
		DisposeHandle(res);
	}
			
	res = NewHandle(4L);
	(*((long**)res))[0] = dateTime;
	AddResource(res,'DATE',iconDateID,"\pIcons");
	checkResErr("RoboWar.model.icons:PutGenericIcon:2");
*/
	// delete the old icon
	if ((res = GetResource('ICON',iconID)) != NULL) {
		RemoveResource(res);
		checkResErr("RoboWar.model.icons:PutGenericIcon:3");
		DisposeHandle(res);
	}
	
	// delete the old cicn
	if ((res = GetResource( 'cicn', iconID )) != NULL) {
		RemoveResource( res );
		checkResErr( "RoboWar.model.icons:PutGenericIcon:4" );
		DisposeHandle( res );
	}
	
	if (icon->type == kGenericIconTypeMono && icon->data != NULL) {
		res = (Handle)icon->data;
		HandToHand( &res ); // make a copy of the icon data for saving
		if (checkResErr( "RoboWar.model.icons:PutGenericIcon:5" ) == noErr)
			AddResource( res, 'ICON', iconID, blankName );
		
		// there... wasn't that simple? now... just look how much more complex
		// it is to save in color:
		
	} else if (icon->type == kGenericIconTypeColor && icon->data != NULL) {
		unsigned short i, j, k, x, y;
		
		res = NewHandleClear( 3290 ); // create a new empty 'cicn'
		if (res == NULL) {
			checkMemErr( "RoboWar.model.icons:PutGenericIcon:6" );
			goto abortPutIcon;
		}
		
		// -- 7-1-04 -- removed dependance on a template 'cicn' resource.
		
		// fill in the basic cicn data-- i'm not sure what all this means...
		((unsigned short*)*res)[2] = 0x8020; // CIcon.iconPMap.rowBytes = 32?
		((unsigned short*)*res)[5] = 0x0020; // CIcon.iconPMap.bounds.bottom
		((unsigned short*)*res)[6] = 0x0020; // CIcon.iconPMap.bounds.right
		((unsigned short*)*res)[11] = 0x0048; // high word of CIcon.iconPMap.hRes
		((unsigned short*)*res)[13] = 0x0048; // high word of CIcon.iconPMap.vRes
		((unsigned short*)*res)[16] = 0x0008; // CIcon.iconPMap.pixelSize
		((unsigned short*)*res)[17] = 0x0001; // CIcon.iconPMap.cmpCount
		((unsigned short*)*res)[18] = 0x0008; // CIcon.iconPMap.cmpSize
		((unsigned short*)*res)[22] = 0x04D2; // CIcon.iconPMap.pmTable?
		((unsigned short*)*res)[27] = 0x0004; // CIcon.iconPMap.bounds.right
		((unsigned short*)*res)[30] = 0x0020; // CIcon.iconMask.bounds.bottom
		((unsigned short*)*res)[31] = 0x0020; // CIcon.iconMask.bounds.right
		((unsigned short*)*res)[37] = 0x0020; // CIcon.iconBMap.bounds.bottom
		((unsigned short*)*res)[38] = 0x0020; // CIcon.iconBMap.bounds.right
		
		// fill in a 100% black mask. -- we'll rebuild it when we load the icon anyway.
		// This is what the old version (4.5.2) did.
		for (i=41; i<105; i++)
			((unsigned short*)*res)[i] = 0xFFFF;
		
		// fill in the color table data
		((unsigned short*)*res)[106] = 0xAFBD; // the low word of the ColorTable's ctSeed value
		((unsigned short*)*res)[107] = 0x8000; // the ColorTable's ctFlags value
		((unsigned short*)*res)[108] = 0x00FF; // the ColorTable's ctSize value
		for (i=0; i<6; i++) // web safe colors, sans black (index 0 - 214)
			for (j=0; j<6; j++)
				for (k=0; k<6; k++) {
					y = (36*i+6*j+k);
					x = 109+y*4;
					((unsigned short*)*res)[x] = y; // ColorSpec.value
					((unsigned short*)*res)[x+1] = gradient1[i]; // ColorSpec.rgb.red
					((unsigned short*)*res)[x+2] = gradient1[j]; // ColorSpec.rgb.green
					((unsigned short*)*res)[x+3] = gradient1[k]; // ColorSpec.rgb.blue
				}
		for (i=0; i<3; i++) // primary color gradients (index 215 - 244)
			for (j=0; j<10; j++) {
				y = (10*i+j)+215;
				x = 109+y*4;
				((unsigned short*)*res)[x] = y;
				((unsigned short*)*res)[x+i+1] = gradient2[j];
			}
		for (i=0; i<10; i++) { // grayscale gradient (*10) (index 245 - 254)
			x = 1089+i*4;
			((unsigned short*)*res)[x] = 245+i;
			((unsigned short*)*res)[x+1] = gradient2[i];
			((unsigned short*)*res)[x+2] = gradient2[i];
			((unsigned short*)*res)[x+3] = gradient2[i];
		}
		((unsigned short*)*res)[1129] = 0x00FF; // black (index 255)
		((unsigned short*)*res)[1130] = 0x0000;
		((unsigned short*)*res)[1131] = 0x0000;
		((unsigned short*)*res)[1132] = 0x0000;
		
		// copy the pixels into the new resource
		for (i=0; i<1024; i++) { 
				(*res)[i+2266] = (*(*((CIconHandle)icon->data))->iconData)[i];
		}
		
		AddResource( res, 'cicn', iconID, blankName );
		require_noerr( checkResErr( "RoboWar.model.icons:PutGenericIcon:7" ), abortPutIcon );
		
		// and if you think this was complex, you should have seen the mess that creating
		// a color icon from a QuickDraw Graphics World pointer was.
		
		return;
		
abortPutIcon:
		// if this gets called after a successful AddResource(), then it corrupts the
		// resource data. I THINK that after the handle is added, closing the Res file will
		// take care of cleaning up the memory.
		if (res) DisposeHandle( res ); // clean up memory
	}
}

void PlotGenericIcon(const Rect * theRect, GenericIcon * icon, RgnHandle mask)
{
	// allocate memory to hold our temporary drawing regions
	RgnHandle oldClip = NewRgn();
	RgnHandle newClip = NewRgn();
	
	GetClip( oldClip ); // save the previous clipping region
	
	// intersect the icon's mask with the current clipping region.
	// technically, we should scale the mask to theRect first, but
	// since We don't expect to need to do it, and we want to save
	// as much processor time as possible, leave that step out.
	OffsetRgn( icon->mask, theRect->left, theRect->top );
	SectRgn ( oldClip, icon->mask, newClip );
	OffsetRgn( icon->mask, 0-theRect->left, 0-theRect->top );
	
	// if an additional mask is supplies, intersect with it as well.
	if (mask) SectRgn ( newClip, mask, newClip );
	
	// set the clipping region to mask off transparent parts of the icon
	SetClip( newClip );
	
	if (icon->type == kGenericIconTypeColor)
		PlotCIcon( theRect, (CIconHandle)icon->data );
	else if (icon->type == kGenericIconTypeMono) {
		PlotIconHandle( theRect, kAlignNone, kTransformNone, (Handle)icon->data );
	}
	
	SetClip( oldClip ); // restore the previous clipping region
	
	// clean up the memory that we used
	DisposeRgn( newClip );
	DisposeRgn( oldClip );
}
