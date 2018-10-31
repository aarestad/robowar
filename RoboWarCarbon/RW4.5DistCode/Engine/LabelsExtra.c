//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//- ¥ Label Functions ¥ LabelMenu.c
//-------------------------------------------------------------------------------------
//- 
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

#include <Carbon/Carbon.h>
#include "robotypes.h"
#include "strings.h"
//#include "myWASTE.h"

// --- Main probably
//extern MenuHandle		labelMenu;

// --- Assembly Line
//extern library			lib[libSize];		/* Library of labels */
//extern short			libPtr;				/* Number of items in the lib array */
extern	WEReference		myWText;

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// ---
void AddLabelsToMenu( library theLabels[], short labelsQty, MenuHandle menu, short intoMenuAtPos );
void DelAllMenuItems(MenuHandle menu);


//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// ¥ 
// ---
void DelAllMenuItems(MenuHandle menu)
{
	short j;

	for( j = CountMenuItems(menu); j >= 0; j-- )
	{
		DeleteMenuItem( menu, j );
	}
}


//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// ¥ 
// ---
void AddLabelsToMenu( library theLabels[], short labelsQty, MenuHandle menu, 
	short intoMenuAtPos )
{
	short i, nameLen;
	Str255	pName;
	Handle text;

	text = WEGetText( myWText );
	
	for( i = 0; i < labelsQty; i ++ )
	{
		nameLen = 0;
		//theLabels[i].textPos =;
		while( (pName[nameLen + 1] = (*text)[ theLabels[i].textPos + nameLen ]) != ':')
		nameLen++;
		
		pName[0] = nameLen;
		
		InsertMenuItem( menu, pName, intoMenuAtPos );
	}
}







// --- End Code ---