/* Speech.c */

/* Written 1/1/94 by David Harris

	This file has code that uses the speech manager.
*/

/* #includes */

#include <Carbon/Carbon.h>
#include "robotypes.h"

/* Globals */
								
VoiceSpec		myVoice;
SpeechChannel	mySpeechChannel;
Handle			mySpeechHandle;

#define		DEFAULT_TEXT		"Welcome to Robo War"
#define		DEFAULT_TEXT_LEN	 19

/* External Variables */

extern macFeatures features;

/* Prototypes */

void initSpeech(void);
void startSpeaking(Handle theText);
void endSpeaking(void);

/* Functions */

void initSpeech(void)
{
	//OSErr myErr;
	
	/* myErr = GetIndVoice(1, &myVoice); */
}

void startSpeaking(Handle theText)
{
	//OSErr myErr;
	
	mySpeechHandle = theText;
	HLock(mySpeechHandle);
/*	
	SpeechManager is required and may not be available on all PowerMacs,
	so I took this out.  SpeechLib also required on the PowerPC project file.
	
	myErr = NewSpeechChannel	 (&myVoice, &mySpeechChannel);
	myErr = SpeakText 			 (mySpeechChannel, *mySpeechHandle, 
									GetHandleSize(mySpeechHandle));
*/
}

void endSpeaking()
{
	//OSErr myErr;
	
	/* myErr = DisposeSpeechChannel (mySpeechChannel); */
	HUnlock(mySpeechHandle);
}

/*void speak(void)
{
	if (features.hasSpeech) {
		short			voiceCount;
		short			counter;
		SpeechChannel	theChannel;
		VoiceSpec		theVoice;
		char			defaultText[]		 = DEFAULT_TEXT;
		char			*theTextToBeSpoken;
		long			textlen;
		long			delayLen;
		OSErr			myErr;
		StringHandle	theHand;
		
		theHand	= GetString(128);
		
		if (theHand == nil)
		{
			theTextToBeSpoken	= defaultText;
			textlen				= DEFAULT_TEXT_LEN;
		}
		else
		{
			HLockHi				((Handle) theHand);
			theTextToBeSpoken	= (char *) (*theHand) + 1;
			textlen				= (long) **theHand;
		}
		
		myErr = GetIndVoice(1, &theVoice);
		myErr = NewSpeechChannel	 (&theVoice, &theChannel);
		myErr = SpeakText 			 (theChannel, (Ptr) theTextToBeSpoken, textlen);
/*		
		myErr = CountVoices	(&voiceCount);
	
		for (counter = 1; counter <= voiceCount; counter++)
		{
			myErr = GetIndVoice 		 (counter, &theVoice);
			myErr = NewSpeechChannel	 (&theVoice, &theChannel);
			myErr = SpeakText 			 (theChannel, (Ptr) theTextToBeSpoken, textlen);
			
			while	(SpeechBusy())
				Delay(60, &delayLen);
			
			myErr = DisposeSpeechChannel (theChannel);
		} 
		
	} 
}*/