/*
 *  RoboWar.model.sound.c
 *  RoboWar
 *
 *  Created by Sam Rushing on 7/9/05.
 *  Copyright 2005 __MyCompanyName__. All rights reserved.
 *
 */

#include "CarbonWrapper.h"
#include "RoboTypes.h"
#include "RoboWar.model.preferences.h"

// ----- from RoboWar.errors.c -----
extern OSErr displayErr(char *errCode, char *errName, char *proc);
extern OSErr checkMemErr(char *proc);
extern OSErr checkResErr(char *proc);


void DisposeGenericSound( GenericSound * sound )
{
	if (sound->type == kGenericSoundTypeMovie && sound->data != NULL)
		DisposeMovie( (Movie)sound->data );
	else if (sound->type == kGenericSoundTypeResource && sound->data != NULL) {
		ReleaseResource( (Handle)sound->data );
	}

	sound->type = kGenericSoundTypeNULL;
	sound->data = NULL;
}

void GetGenericSoundFromResource( SInt16 sndID, GenericSound * sound )
{
	Handle h = GetResource('snd ', sndID);
	
	sound->type = (h?kGenericSoundTypeResource:kGenericSoundTypeNULL);
	sound->data = h;
	
	if (h) DetachResource(h);
}

void GetGenericSoundFromData( CFDataRef data, GenericSound * sound )
{
	Handle					myHandle = NULL, dataRef = NULL;
	Movie					movie = NULL;
    MovieImportComponent    miComponent;
    Track                   targetTrack = nil;
    TimeValue               addedDuration = 0;
    long                    outFlags = 0;
    OSErr                   err;
    ComponentResult         result;
	Size					waveDataSize = (Size)CFDataGetLength(data);
	
	myHandle = NewHandleClear( waveDataSize );
	if( !myHandle ) goto bail;	
	BlockMove(CFDataGetBytePtr(data), *myHandle, waveDataSize);
	err = PtrToHand(&myHandle, &dataRef, sizeof(Handle));
	if( err != noErr || !dataRef ) goto bail;
	
	miComponent = OpenDefaultComponent(MovieImportType, kQTFileTypeWave);
	if( !miComponent ) goto bail;	
	movie = NewMovie(0);
	if( !movie ) goto bail;	

	result = MovieImportDataRef(miComponent,
								dataRef,
								HandleDataHandlerSubType,
								movie,
								nil,
								&targetTrack,
								nil,
								&addedDuration,
								movieImportCreateTrack,
								&outFlags);
	if (result != noErr) goto bail;
	
	SetMovieVolume(movie, kFullVolume);
	
	sound->type = kGenericSoundTypeMovie;
	sound->data = movie;
	CloseComponent( miComponent );
	return;
	
bail:
	sound->type = kGenericSoundTypeNULL;
	sound->data = NULL;
	if (miComponent) CloseComponent( miComponent );
	if (movie) DisposeMovie( movie );
	else {
		if (dataRef) DisposeHandle( dataRef );	
		if (myHandle) DisposeHandle( myHandle );
	}
}

void GetGenericSoundFromFile( CFURLRef url, GenericSound * sound, SInt32 *errorCode )
{
	CFDataRef d = NULL;
	
	if (!url) printf("null url!\n");
	CFURLCreateDataAndPropertiesFromResource( NULL, url, &d, NULL, NULL, errorCode );
	if (!d) printf("null data!\n");
	GetGenericSoundFromData( d, sound );
	CFRelease( d );
}

void PlayGenericSound( GenericSound * sound )
{
	static SndChannelPtr chan = NULL;
	
	if (gPrefs.soundFlag && sound && sound->data)
		switch (sound->type) {
			case kGenericSoundTypeResource:
				if (!chan) {
					SndNewChannel( &chan, 0, 0, NULL );
				}
				SndPlay( chan, (SndListHandle)sound->data, TRUE );
				break;
			case kGenericSoundTypeMovie:
				GoToBeginningOfMovie( (Movie)sound->data );
				StartMovie( (Movie)sound->data );
				break;
		}
}