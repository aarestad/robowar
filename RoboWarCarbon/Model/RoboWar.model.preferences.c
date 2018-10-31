/*
 *  RoboWar.model.preferences.c
 *  RoboWar
 *
 *  Created by Sam Rushing on Sun Jul 25 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 */

#include "RoboTypes.h"
#include "RoboWar.model.preferences.h"
#include "RoboWar.interface.errors.h"

// the default preferences.
prefStruct gPrefs = { kRoboWarPreferencesCurrentVersion, kRoboWarDrawArenaAndStats, true,
		kRoboWarDisplayNormal, 9, false, true, true, {0xFFFF, 0x0000, 0x0000},
		{0x0000, 0x0000, 0xFFFF}, {0x0000, 0x0000, 0x0000}, true, true, false, false, 1 };

#define keyPreferencesVersion (CFSTR("RWPreferencesVersion"))
#define keyDisplayCode (CFSTR("RWDisplayCode"))
#define keyShouldPlaySound (CFSTR("RWShouldPlaySound"))
#define keyBattleSpeed (CFSTR("RWBattleSpeed"))
#define keyMaxPoints (CFSTR("RWMaxPoints"))
#define keyShouldCreateTournyLog (CFSTR("RWShouldCreateTournyLog"))
#define keyShouldShowBugyRobotDialog (CFSTR("RWShouldShowBugyRobotDialog"))
#define keyShouldUseSyntaxColoring (CFSTR("RWShouldUseSyntaxColoring"))
#define keyCommentColor (CFSTR("RWCommentColor"))
#define keyLabelColor (CFSTR("RWLabelColor"))
#define keyMainTextColor (CFSTR("RWMainTextColor"))
#define keyShouldShowMoveAndShootAlert (CFSTR("RWShouldShowMoveAndShootAlert"))
#define keyShouldEnforceNoMoveAndShootRule (CFSTR("RWShouldEnforceNoMoveAndShootRule"))
#define keyShouldEnforceNoLasersRule (CFSTR("RWShouldEnforceNoLasersRule"))
#define keyShouldEnforceNoDronesRule (CFSTR("RWShouldEnforceNoDronesRule"))
#define keySoundRecordingRate (CFSTR("RWSoundRecordingRate"))

#define keyRedComponent (CFSTR("red"))
#define keyGreenComponent (CFSTR("green"))
#define keyBlueComponent (CFSTR("blue"))


// load the preferences from the Carbon preferences file.
void readPrefs(void)
{
	Boolean isValid;
	CFIndex value;
	
	value = CFPreferencesGetAppIntegerValue( keyPreferencesVersion,
					kCFPreferencesCurrentApplication, &isValid );
	// check the returned value's type ID to make sure it is a number.
	if (isValid) {
		
		int i;
		CFStringRef colorsKeys[3] = { keyCommentColor, keyLabelColor, keyMainTextColor };
		RGBColor * colors[3] = { &gPrefs.commentColor, &gPrefs.labelColor, &gPrefs.mainTextColor };
		CFPropertyListRef theRef;
		
		// forward compatibility is not supported.
		// reading a preferences file from a later version results in a return to defaults.
		if (value > kRoboWarPreferencesCurrentVersion) {
			// if the version key that was read is too high, we'll use the defaults and tell the user.
			displayErr( "Your RoboWar preferences were too new.",
						"They have been reset to the defaults for this version.", NULL);
			return;
		}
		
		// --- now move on to the remaining preferences entries
		
		value = CFPreferencesGetAppIntegerValue( keyDisplayCode,
						kCFPreferencesCurrentApplication, &isValid );
		if (isValid) gPrefs.displayCode = value;
		
		value = CFPreferencesGetAppBooleanValue( keyShouldPlaySound,
						kCFPreferencesCurrentApplication, &isValid );
		if (isValid) gPrefs.soundFlag = value;
		
		value = CFPreferencesGetAppIntegerValue( keyBattleSpeed,
						kCFPreferencesCurrentApplication, &isValid );
		if (isValid) gPrefs.battleSpeed = value;
		
		value = CFPreferencesGetAppIntegerValue( keyMaxPoints,
						kCFPreferencesCurrentApplication, &isValid );
		if (isValid) gPrefs.maxPoints = value;
		
		value = CFPreferencesGetAppBooleanValue( keyShouldCreateTournyLog,
						kCFPreferencesCurrentApplication, &isValid );
		if (isValid) gPrefs.createTournyLogQ = value;
		
		value = CFPreferencesGetAppBooleanValue( keyShouldShowBugyRobotDialog,
						kCFPreferencesCurrentApplication, &isValid );
		if (isValid) gPrefs.showBugyRobotDialogQ = value;
		
		value = CFPreferencesGetAppBooleanValue( keyShouldUseSyntaxColoring,
						kCFPreferencesCurrentApplication, &isValid );
		if (isValid) gPrefs.syntaxColoringQ = value;
		
		value = CFPreferencesGetAppBooleanValue( keyShouldShowMoveAndShootAlert,
						kCFPreferencesCurrentApplication, &isValid );
		if (isValid) gPrefs.showMoveAndShootAlert = value;
		
		value = CFPreferencesGetAppBooleanValue( keyShouldEnforceNoMoveAndShootRule,
						kCFPreferencesCurrentApplication, &isValid );
		if (isValid) gPrefs.rules_noMoveShoot = value;
		
		value = CFPreferencesGetAppBooleanValue( keyShouldEnforceNoLasersRule,
						kCFPreferencesCurrentApplication, &isValid );
		if (isValid) gPrefs.rules_noLazers = value;
		
		value = CFPreferencesGetAppBooleanValue( keyShouldEnforceNoDronesRule,
						kCFPreferencesCurrentApplication, &isValid );
		if (isValid) gPrefs.rules_noDrones = value;
		
		value = CFPreferencesGetAppIntegerValue( keySoundRecordingRate,
						kCFPreferencesCurrentApplication, &isValid );
		if (isValid) gPrefs.sndQuality = value;
		
		for (i=0; i<3; i++) {
			theRef = CFPreferencesCopyAppValue( colorsKeys[i], kCFPreferencesCurrentApplication );
			if (theRef) {
				if (CFGetTypeID(theRef) == CFDictionaryGetTypeID()) {
					CFTypeRef theValue;
					int theComponent;
					if (CFDictionaryGetValueIfPresent((CFDictionaryRef)theRef, keyRedComponent, &theValue)
					 && CFGetTypeID(theValue) == CFNumberGetTypeID()
					 && CFNumberGetValue((CFNumberRef)theValue, kCFNumberSInt32Type, &theComponent))
						colors[i]->red = (theComponent & 0xFFFF);
					if (CFDictionaryGetValueIfPresent((CFDictionaryRef)theRef, keyGreenComponent, &theValue)
					 && CFGetTypeID(theValue) == CFNumberGetTypeID()
					 && CFNumberGetValue((CFNumberRef)theValue, kCFNumberSInt32Type, &theComponent))
						colors[i]->green = (theComponent & 0xFFFF);
					if (CFDictionaryGetValueIfPresent((CFDictionaryRef)theRef, keyBlueComponent, &theValue)
					 && CFGetTypeID(theValue) == CFNumberGetTypeID()
					 && CFNumberGetValue((CFNumberRef)theValue, kCFNumberSInt32Type, &theComponent))
						colors[i]->blue = (theComponent & 0xFFFF);
				}
				CFRelease( theRef );
			}
		}
	}
	
	// if no version key was read, then we'll use the defaults.
}

// write the preferences to the Carbon preferences file.
void writePrefs(void)
{
	CFPropertyListRef theRef;
	CFNumberRef colorNums[3];
	CFStringRef colorComps[3] = { keyRedComponent, keyGreenComponent, keyBlueComponent };
	int i;
	CFStringRef colorsKeys[3] = { keyCommentColor, keyLabelColor, keyMainTextColor };
	RGBColor * colors[3] = { &gPrefs.commentColor, &gPrefs.labelColor, &gPrefs.mainTextColor };
	
	theRef = CFNumberCreate( kCFAllocatorDefault, kCFNumberSInt16Type, &gPrefs.version );
	CFPreferencesSetAppValue( keyPreferencesVersion, theRef, kCFPreferencesCurrentApplication );
	CFRelease( theRef );
	
	theRef = CFNumberCreate( kCFAllocatorDefault, kCFNumberSInt16Type, &gPrefs.displayCode );
	CFPreferencesSetAppValue( keyDisplayCode, theRef, kCFPreferencesCurrentApplication );
	CFRelease( theRef );
	
	theRef = ( gPrefs.soundFlag ? kCFBooleanTrue : kCFBooleanFalse );
	CFPreferencesSetAppValue( keyShouldPlaySound, theRef, kCFPreferencesCurrentApplication );
	
	theRef = CFNumberCreate( kCFAllocatorDefault, kCFNumberSInt16Type, &gPrefs.battleSpeed );
	CFPreferencesSetAppValue( keyBattleSpeed, theRef, kCFPreferencesCurrentApplication );
	CFRelease( theRef );
	
	theRef = CFNumberCreate( kCFAllocatorDefault, kCFNumberSInt16Type, &gPrefs.maxPoints );
	CFPreferencesSetAppValue( keyMaxPoints, theRef, kCFPreferencesCurrentApplication );
	CFRelease( theRef );
	
	theRef = ( gPrefs.createTournyLogQ ? kCFBooleanTrue : kCFBooleanFalse );
	CFPreferencesSetAppValue( keyShouldCreateTournyLog, theRef, kCFPreferencesCurrentApplication );
	
	theRef = ( gPrefs.showBugyRobotDialogQ ? kCFBooleanTrue : kCFBooleanFalse );
	CFPreferencesSetAppValue( keyShouldShowBugyRobotDialog, theRef, kCFPreferencesCurrentApplication );
	
	theRef = ( gPrefs.syntaxColoringQ ? kCFBooleanTrue : kCFBooleanFalse );
	CFPreferencesSetAppValue( keyShouldUseSyntaxColoring, theRef, kCFPreferencesCurrentApplication );
	
	theRef = ( gPrefs.showMoveAndShootAlert ? kCFBooleanTrue : kCFBooleanFalse );
	CFPreferencesSetAppValue( keyShouldShowMoveAndShootAlert, theRef, kCFPreferencesCurrentApplication );
	
	theRef = ( gPrefs.rules_noMoveShoot ? kCFBooleanTrue : kCFBooleanFalse );
	CFPreferencesSetAppValue( keyShouldEnforceNoMoveAndShootRule, theRef, kCFPreferencesCurrentApplication );
	
	theRef = ( gPrefs.rules_noLazers ? kCFBooleanTrue : kCFBooleanFalse );
	CFPreferencesSetAppValue( keyShouldEnforceNoLasersRule, theRef, kCFPreferencesCurrentApplication );
	
	theRef = ( gPrefs.rules_noDrones ? kCFBooleanTrue : kCFBooleanFalse );
	CFPreferencesSetAppValue( keyShouldEnforceNoDronesRule, theRef, kCFPreferencesCurrentApplication );
	
	theRef = CFNumberCreate( kCFAllocatorDefault, kCFNumberSInt16Type, &gPrefs.sndQuality );
	CFPreferencesSetAppValue( keySoundRecordingRate, theRef, kCFPreferencesCurrentApplication );
	CFRelease( theRef );
	
	for (i=0; i<3; i++) {
		int t;
		t = colors[i]->red;
		colorNums[0] = CFNumberCreate( kCFAllocatorDefault, kCFNumberSInt32Type, &t );
		t = colors[i]->green;
		colorNums[1] = CFNumberCreate( kCFAllocatorDefault, kCFNumberSInt32Type, &t );
		t = colors[i]->blue;
		colorNums[2] = CFNumberCreate( kCFAllocatorDefault, kCFNumberSInt32Type, &t );
		theRef = CFDictionaryCreate( kCFAllocatorDefault, (const void **)&colorComps, (const void **)&colorNums, 3,
						&kCFCopyStringDictionaryKeyCallBacks, &kCFTypeDictionaryValueCallBacks );
		CFPreferencesSetAppValue( colorsKeys[i], theRef, kCFPreferencesCurrentApplication );
		CFRelease( theRef );
		CFRelease( colorNums[0] );
		CFRelease( colorNums[1] );
		CFRelease( colorNums[2] );
	}
	
	// Write out the preference data.
	CFPreferencesAppSynchronize(kCFPreferencesCurrentApplication);
}
