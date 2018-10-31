/*
 *  RoboWar.interface.errors.h
 *  RoboWar
 *
 *  Created by Sam Rushing on Sun Jul 25 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 */

#ifndef __ROBOWAR_INTERFACE_ERRORS__
#define __ROBOWAR_INTERFACE_ERRORS__ (1)

#include "CarbonWrapper.h"

extern void displayErr(char *errCode, char *errName, char *proc);
extern OSErr checkMemErr(char *proc);
extern OSErr checkResErr(char *proc);
extern OSErr checkSndErr(OSErr err,char *proc);
extern OSErr checkAppleEventErr(OSErr err, char *proc);
extern OSStatus checkNavErr(OSStatus err, char *proc);
extern OSErr checkFileErr(OSErr err,char *proc);

#endif /* __ROBOWAR_INTERFACE_ERRORS__ */