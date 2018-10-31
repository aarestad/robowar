/************************************************************Created: Friday, June 26, 1993 at 12:27 PM Speech.h C Interface to the Macintosh Libraries  Copyright Apple Computer, Inc. 1993  All rights reserved************************************************************/#ifndef _SPEECH_#define _SPEECH_#ifndef __TYPES__#include <Types.h>#endif#ifndef __MEMORY__#include <Memory.h>#endif#ifndef __FILES__#include <Files.h>#endif/*Speech Manager errors*/enum { noSynthFound = -240, synthOpenFailed = -241, synthNotReady = -242, bufTooSmall = -243, voiceNotFound = -244, incompatibleVoice = -245, badDictFormat = -246, badInputText = -247};#define gestaltSpeechAttr 			'ttsc'	/* Gestalt Manager selector for Speech Attributes */enum {    gestaltSpeechMgrPresent = 0				/* Gestalt bit which indicates that Speech Manager exists */};#define kTextToSpeechSynthType		 'ttsc'	/* Text-to-Speech Synthesizer component type 	*/#define kTextToSpeechVoiceType		 'ttvd'	/* Text-to-Speech Voice resource type 			*/#define kTextToSpeechVoiceFileType	 'ttvf'	/* Text-to-Speech Voice file type 				*/#define kTextToSpeechVoiceBundleType 'ttvb'	/* Text-to-Speech Voice Bundle file type		*/enum {										/* constants for SpeakBuffer and TextDone callback controlFlags bits */	kNoEndingProsody 	= 1,	kNoSpeechInterrupt 	= 2,	kPreflightThenPause	= 4};enum {										/* constants for StopSpeechAt and PauseSpeechAt */	kImmediate		= 0,	kEndOfWord		= 1,	kEndOfSentence	= 2};#define soStatus				'stat'		/* GetSpeechInfo & SetSpeechInfo selectors */#define soErrors				'erro'#define soInputMode				'inpt'#define soCharacterMode			'char'#define soNumberMode			'nmbr'#define soRate					'rate'#define soPitchBase				'pbas'#define soPitchMod				'pmod'#define soVolume				'volm'#define soSynthType				'vers'#define soRecentSync			'sync'#define soPhonemeSymbols		'phsy'#define soCurrentVoice			'cvox'#define soCommandDelimiter		'dlim'#define soReset					'rset'#define soCurrentA5				'myA5'#define soRefCon				'refc'#define soTextDoneCallBack		'tdcb'#define soSpeechDoneCallBack	'sdcb'#define soSyncCallBack			'sycb'#define soErrorCallBack			'ercb'#define soPhonemeCallBack		'phcb'#define soWordCallBack			'wdcb'#define soSynthExtension		'xtnd'/* Speaking Mode Constants */#define modeText		'TEXT'		/* input mode constants 				*/#define modeTX			'TX'#define modePhonemes	'PHON'#define modePH			'PH'#define modeNormal		'NORM'		/* character mode and number mode constants */#define modeLiteral		'LTRL'enum {								/* GetVoiceInfo selectors 				*/	soVoiceDescription	= 'info',	/* gets basic voice info 				*/	soVoiceFile			= 'fref'	/* gets voice file ref info 			*/};typedef struct SpeechChannelRecord {	long data[1];} SpeechChannelRecord;typedef SpeechChannelRecord *SpeechChannel;typedef struct VoiceSpec {	OSType	creator;				/* creator id of required synthesizer 	*/	OSType	id;						/* voice id on the specified synth 		*/} VoiceSpec;enum {kNeuter = 0, kMale, kFemale};	/* returned in gender field below 		*/typedef struct VoiceDescription {	long		length;				/* size of structure - set by application 	*/	VoiceSpec 	voice;				/* voice creator and id info 				*/	long		version;			/* version code for voice 					*/	Str63		name;				/* name of voice 							*/	Str255		comment;			/* additional text info about voice 		*/	short		gender;				/* neuter, male, or female					*/	short		age;				/* approximate age in years 				*/	short		script;				/* script code of text voice can process 	*/	short		language;			/* language code of voice output speech 	*/	short 		region;				/* region code of voice output speech 		*/	long		reserved[4];		/* always zero - reserved for future use	*/} VoiceDescription;typedef struct VoiceFileInfo {	FSSpec		fileSpec;			/* volume, dir, & name information for voice file */	short		resID;				/* resource id of voice in the file */} VoiceFileInfo;typedef struct SpeechStatusInfo {	Boolean	outputBusy; 			/* TRUE if audio is playing 		*/	Boolean	outputPaused;			/* TRUE if channel is paused 		*/	long	inputBytesLeft; 		/* bytes left to process 			*/	short	phonemeCode;			/* opcode for cur phoneme 			*/} SpeechStatusInfo;typedef struct SpeechErrorInfo {	short	count;					/* # of errs since last check 		*/	OSErr	oldest;					/* oldest unread error 				*/	long	oldPos;					/* char position of oldest err 		*/	OSErr	newest;					/* most recent error 				*/	long	newPos;					/* char position of newest err 		*/} SpeechErrorInfo;typedef struct SpeechVersionInfo {	OSType		synthType;			/* always �ttsc� 					*/	OSType		synthSubType;		/* synth flavor 					*/	OSType		synthManufacturer;	/* synth creator ID 				*/	long		synthFlags;			/* synth feature flags 				*/	NumVersion	synthVersion; 		/* synth version number 			*/} SpeechVersionInfo;typedef struct PhonemeInfo {	short	opcode;					/* opcode for the phoneme 			*/	Str15	phStr;					/* corresponding char string 		*/	Str31	exampleStr;				/* word that shows use of phoneme 	*/	short	hiliteStart;			/* segment of example word that	 	*/	short	hiliteEnd;				/* should be hilighted (ala TextEdit) */} PhonemeInfo;typedef struct PhonemeDescriptor {	short		phonemeCount; 		/* # of elements 		*/	PhonemeInfo	thePhonemes[1]; 	/* element list 		*/} PhonemeDescriptor;typedef struct SpeechXtndData {	OSType	synthCreator;			/* synth creator id 	*/	Byte	synthData[2];			/* data TBD by synth 	*/} SpeechXtndData;typedef struct DelimiterInfo {	Byte	startDelimiter[2];		/* defaults to �[[� 	*/	Byte	endDelimiter[2];		/* defaults to �]]� 	*/} DelimiterInfo;typedef pascal void (*SpeechTextDoneCBPtr) 	(SpeechChannel, long, Ptr *, long *, long *);	/* Text-done callback routine typedef 	*/typedef pascal void (*SpeechDoneCBPtr) 		(SpeechChannel, long );							/* Speech-done callback routine typedef */typedef pascal void (*SpeechSyncCBPtr) 		(SpeechChannel, long, OSType);					/* Sync callback routine typedef 		*/typedef pascal void (*SpeechErrorCBPtr) 	(SpeechChannel, long, OSErr, long);				/* Error callback routine typedef 		*/typedef pascal void (*SpeechPhonemeCBPtr) 	(SpeechChannel, long, short);					/* Phoneme callback routine typedef 	*/typedef pascal void (*SpeechWordCBPtr) 		(SpeechChannel, long, long, short);				/* Word callback routine typedef 		*/#ifdef __cplusplusextern "C" {#endifpascal NumVersion SpeechManagerVersion (void)    = {0x203C,0x0000,0x000C,0xA800};pascal OSErr MakeVoiceSpec (OSType creator, OSType id, VoiceSpec *voice)    = {0x203C,0x0604,0x000C,0xA800};pascal OSErr CountVoices (short *numVoices)    = {0x203C,0x0108,0x000C,0xA800};pascal OSErr GetIndVoice (short index, VoiceSpec *voice)    = {0x203C,0x030C,0x000C,0xA800};pascal OSErr GetVoiceDescription (VoiceSpec *voice, VoiceDescription *info, long infoLength)    = {0x203C,0x0610,0x000C,0xA800};pascal OSErr GetVoiceInfo (VoiceSpec *voice, OSType selector, void *voiceInfo)    = {0x203C,0x0614,0x000C,0xA800};pascal OSErr NewSpeechChannel (VoiceSpec *voice, SpeechChannel *chan)    = {0x203C,0x0418,0x000C,0xA800};pascal OSErr DisposeSpeechChannel (SpeechChannel chan)    = {0x203C,0x021C,0x000C,0xA800};pascal OSErr SpeakString (StringPtr s)    = {0x203C,0x0220,0x000C,0xA800};pascal OSErr SpeakText (SpeechChannel chan, Ptr textBuf, long textBytes)    = {0x203C,0x0624,0x000C,0xA800};pascal OSErr SpeakBuffer (SpeechChannel chan, Ptr textBuf, long textBytes, long controlFlags)    = {0x203C,0x0828,0x000C,0xA800};pascal OSErr StopSpeech (SpeechChannel chan)    = {0x203C,0x022C,0x000C,0xA800};pascal OSErr StopSpeechAt (SpeechChannel chan, long whereToStop)    = {0x203C,0x0430,0x000C,0xA800};pascal OSErr PauseSpeechAt (SpeechChannel chan, long whereToPause)    = {0x203C,0x0434,0x000C,0xA800};pascal OSErr ContinueSpeech (SpeechChannel chan)    = {0x203C,0x0238,0x000C,0xA800};pascal short SpeechBusy (void)    = {0x203C,0x003C,0x000C,0xA800};pascal short SpeechBusySystemWide (void)    = {0x203C,0x0040,0x000C,0xA800};pascal OSErr SetSpeechRate (SpeechChannel chan, Fixed rate)    = {0x203C,0x0444,0x000C,0xA800};pascal OSErr GetSpeechRate (SpeechChannel chan, Fixed *rate)    = {0x203C,0x0448,0x000C,0xA800};pascal OSErr SetSpeechPitch (SpeechChannel chan, Fixed pitch)    = {0x203C,0x044C,0x000C,0xA800};pascal OSErr GetSpeechPitch (SpeechChannel chan, Fixed *pitch)    = {0x203C,0x0450,0x000C,0xA800};pascal OSErr SetSpeechInfo (SpeechChannel chan, OSType selector, void *speechInfo)    = {0x203C,0x0654,0x000C,0xA800};pascal OSErr GetSpeechInfo (SpeechChannel chan, OSType selector, void *speechInfo)    = {0x203C,0x0658,0x000C,0xA800};pascal OSErr TextToPhonemes (SpeechChannel chan, Ptr textBuf, long textBytes, Handle phonemeBuf, long *phonemeBytes)    = {0x203C,0x0A5C,0x000C,0xA800};pascal OSErr UseDictionary (SpeechChannel chan, Handle dictionary)    = {0x203C,0x0460,0x000C,0xA800};#ifdef __cplusplus}#endif#endif