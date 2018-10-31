#include "CarbonWrapper.h"
#include "RoboTypes.h"
#include "RoboWar.model.preferences.h"

extern OSStatus installArenaWindowEventHandler();
extern OSStatus installArenaViewEventHandler();
extern OSStatus installCampViewEventHandler();
extern OSStatus installChrononViewEventHandler();
extern OSStatus installRoboWarApplicationEventHandlers();
extern OSStatus installBattleEventHandler();

WindowRef 		gArenaWindow;
ControlRef		gBattleButton;
ControlRef		gArenaView;
ControlRef		gChrononView;
ControlRef		gCampView;
MenuRef			gFileMenu;
MenuRef			gEditMenu;
MenuRef			gViewMenu;
MenuRef			gArenaMenu;

CIconHandle		bulletGW;			//Bullet GWorlds...
CIconHandle		hellBoreGW;
CIconHandle		mineGW;
CIconHandle		newMineGW;
CIconHandle		droneGW[8];

GenericIcon		botGW[maxBots][2];  // Default robot image GWorlds
GenericSound	defSnds[10];  // Default robot sounds

RgnHandle		explosionMasks[8];	// Section of exploding robot to display

// ----- Globals -----
double				sine[360];			/* Sine functions for each degree */
short				rosterChanged;		/* Invalidate old history */
short				controlChange;	 	/* 1 = Show mode's controls */
short				mode;				/* Program's current mode */
short				numBots;			/* Number of bots to battle */
short				botSelected;		/* Which bot is selected, maxBots = None */
short				quitFlag;			/* 1 = Quit Program */
short				isBattle;			/* 1 = Battle in progress */
short				isTournament;		/* 1 = Tournament in progress */
short				oldSoundFlag;		/* Keep old flag while game is in background */
short				modifyFlag;			/* Has a change been made in one of the editors */
short				useDebugger;		/* Use the debugger? (MaxBot = no debugger) */
short				pausedFlag;			/* 1 = paused in debugger */
short				stepFlag;			/* 1 = step forward in debugger */
short				chrononFlag;		/* Do one chronon in the debugger */
short				aggressiveFlag;		/* Aggressive scoring on tournaments */
short				officialFlag;		/* Official rules on tournaments */
short				lowBitMapMemoryFlag;/* Is memory too low for full colors */
unsigned short 		lastRandSeed;		/* Retain random seed to repeat battles */
Str255				findStr;			/* String of text to find */
Str255				replaceStr;			/* String with replacement text */
robot				rob[maxBots];		/* The robots */
shot				*shots;				/* Head of list of shots */
Ptr					safeMem;

extern void loadDefaultIcons(void);
extern void loadDefaultSounds(void);

void disableCampSpaceSpecificControls()
{
	if (numBots >= maxBots) {
		// disable menu items that require there be space in the camp
		DisableMenuItem( gFileMenu, kFileOpenMenuItemIndex );
		DisableMenuItem( gFileMenu, kFileDuplicateMenuItemIndex );
	}
}

void enableCampSpaceSpecificControls()
{
	if (numBots < maxBots) {
		// enable menu items that require there be space in the camp
		EnableMenuItem( gFileMenu, kFileOpenMenuItemIndex );
		if (botSelected < numBots)
			EnableMenuItem( gFileMenu, kFileDuplicateMenuItemIndex );
	}
}

void disableSelectionSpecificControls()
{
	if (botSelected == maxBots) {
		// disable menu items that require there be an open robot
		DisableMenuItem( gFileMenu, kFileDuplicateMenuItemIndex );
		DisableMenuItem( gFileMenu, kFileCloseMenuItemIndex );
		DisableMenuItem( gFileMenu, kFileSaveAsMenuItemIndex );
		DisableMenuItem( gViewMenu, kViewDraftingBoardMenuItemIndex );
		DisableMenuItem( gViewMenu, kViewHardwareStoreMenuItemIndex );
		DisableMenuItem( gViewMenu, kViewIconFactoryMenuItemIndex );
		DisableMenuItem( gViewMenu, kViewRecordingStudioMenuItemIndex );
		DisableMenuItem( gViewMenu, kViewCompileMenuItemIndex );
		DisableMenuItem( gViewMenu, kViewSetPasswordMenuItemIndex );
		DisableMenuItem( gArenaMenu, kArenaTeamMenuItemIndex );
		DisableMenuItem( gArenaMenu, kArenaUseDebuggerMenuItemIndex );
	}
}

void enableSelectionSpecificControls()
{
	if (botSelected < numBots) {
		// disable menu items that require there be an open robot
		if (numBots < maxBots)
			EnableMenuItem( gFileMenu, kFileDuplicateMenuItemIndex );
		EnableMenuItem( gFileMenu, kFileCloseMenuItemIndex );
		EnableMenuItem( gFileMenu, kFileSaveAsMenuItemIndex );
		EnableMenuItem( gViewMenu, kViewDraftingBoardMenuItemIndex );
		EnableMenuItem( gViewMenu, kViewHardwareStoreMenuItemIndex );
		EnableMenuItem( gViewMenu, kViewIconFactoryMenuItemIndex );
		EnableMenuItem( gViewMenu, kViewRecordingStudioMenuItemIndex );
		EnableMenuItem( gViewMenu, kViewCompileMenuItemIndex );
		EnableMenuItem( gViewMenu, kViewSetPasswordMenuItemIndex );
		EnableMenuItem( gArenaMenu, kArenaTeamMenuItemIndex );
		EnableMenuItem( gArenaMenu, kArenaUseDebuggerMenuItemIndex );
	}
}

void initProgram(void)
{
	int i;
	
	// --- initialize text handler --- add this!
	
	numBots = 0;
	quitFlag = 0;
	shots = NULL;
	botSelected = maxBots;
	useDebugger = maxBots;
	controlChange = 0;
	rosterChanged = 1;
	findStr[0] = 0;
	replaceStr[0] = 0;
	mode = arena;
	aggressiveFlag = TRUE;
	officialFlag = TRUE;
	lowBitMapMemoryFlag = FALSE;
	lastRandSeed = (unsigned short)TickCount();
	
	// --- initialize the arena --- add this
	loadDefaultIcons();
	loadDefaultSounds();
	//setArenaFunctions();
	//loadRobots();
	//initArena();

	// doTitleDialog();
	
	for (i=0; i<360; i++) {
		sine[i] = sin((double)(90-i)*0.01745329252); // ¹/180
	}
}

OSStatus initGlobals()
{
    OSStatus		err = noErr;
	ControlID		cid;
	
	cid.signature = kRoboWarSignature;
	cid.id = kArenaUserPaneID;
	err = GetControlByID(gArenaWindow, &cid, &gArenaView);
	require_noerr( err, InitGlobalsError );
	
	cid.id = kCampUserPaneID;
	err = GetControlByID(gArenaWindow, &cid, &gCampView);
	require_noerr( err, InitGlobalsError );
	
	cid.id = kChrononUserPaneID;
	err = GetControlByID(gArenaWindow, &cid, &gChrononView);
	require_noerr( err, InitGlobalsError );
	
	cid.id = kBattleButtonID;
	err = GetControlByID(gArenaWindow, &cid, &gBattleButton);
	require_noerr( err, InitGlobalsError );
	
	gFileMenu = GetMenuHandle( kFileMenuID );
	gEditMenu = GetMenuHandle( kEditMenuID );
	gViewMenu = GetMenuHandle( kViewMenuID );
	gArenaMenu = GetMenuHandle( kArenaMenuID );

	disableSelectionSpecificControls();
	
	// the battle button should initially be disabled
	DeactivateControl( gBattleButton );

InitGlobalsError:
	return err;
}

OSStatus installEventHandlers()
{
	OSStatus		err = noErr;
	
	err = installRoboWarApplicationEventHandlers();
	require_noerr( err, InstallEventHandlersError );
	
	err = installArenaWindowEventHandler();
	require_noerr( err, InstallEventHandlersError );

	err = installArenaViewEventHandler();
	require_noerr( err, InstallEventHandlersError );

	err = installCampViewEventHandler();
	require_noerr( err, InstallEventHandlersError );

	err = installChrononViewEventHandler();
	require_noerr( err, InstallEventHandlersError );

	err = installBattleEventHandler();
	require_noerr( err, InstallEventHandlersError );

InstallEventHandlersError:
	if (err)
		CFShow(CFSTR("Got Error!"));
	return err;
}

int main(int argc, char* argv[])
{
    IBNibRef 		nibRef;
	MenuRef			menu;
    
    OSStatus		err;
    
    // Create a Nib reference passing the name of the nib file (without the .nib extension)
    // CreateNibReference only searches into the application bundle.
    err = CreateNibReference(CFSTR("main"), &nibRef);
    require_noerr( err, ErrorConditionBreak );
    
    // Once the nib reference is created, set the menu bar. "MainMenu" is the name of the menu bar
    // object. This name is set in InterfaceBuilder when the nib is created.
    err = SetMenuBarFromNib(nibRef, CFSTR("MenuBar"));
    require_noerr( err, ErrorConditionBreak );
    
    // Then create a window. "MainWindow" is the name of the window object. This name is set in 
    // InterfaceBuilder when the nib is created.
    err = CreateWindowFromNib(nibRef, CFSTR("MainWindow"), &gArenaWindow);
    require_noerr( err, ErrorConditionBreak );

    // We don't need the nib reference anymore.
    DisposeNibReference(nibRef);
	
	// init quicktime
	EnterMovies();
	
	readPrefs();
	initProgram();
	err = initGlobals();
    require_noerr( err, ErrorConditionBreak );

	// check the currently selected menu items
	err = GetMenuItemHierarchicalMenu( gArenaMenu, kArenaDisplayMenuItemIndex, &menu );
    require_noerr( err, ErrorConditionBreak );
	if (menu) CheckMenuItem ( menu, gPrefs.displayCode, true );
	
	err = GetMenuItemHierarchicalMenu( gArenaMenu, kArenaSpeedMenuItemIndex, &menu );
	require_noerr( err, ErrorConditionBreak );
	if (menu) CheckMenuItem ( menu, gPrefs.battleSpeed+1, true );
	
	// install the command handler for the arena window.
	err = installEventHandlers();
    require_noerr( err, ErrorConditionBreak );
	
    // The window was created hidden so show it.
    ShowWindow( gArenaWindow );
	
    // Call the event loop
    RunApplicationEventLoop();
	
	// preferences are written from the event loop with the kEventAppQuit event.
	
ErrorConditionBreak:
	return err;
}

