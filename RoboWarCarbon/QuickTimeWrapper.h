/*
 *  QuickTimeWrapper.h
 *  RW4.5.2
 *
 *  Created by Sam Rushing on 5/23/05.
 *  Copyright 2005 __MyCompanyName__. All rights reserved.
 *
 */

/*
 *  This file wraps the QuickTime framework includes so that we don't have
 *  to edit every last file when we transition to MPW for the final build.
 */

#ifndef __ROBOWAR_QUICKTIMEWRAPPER__
#define __ROBOWAR_QUICKTIMEWRAPPER__

// check if we're using gcc (in Xcode or Project Builder) to compile
#if defined(__APPLE_CC__)

	#include <QuickTime/QuickTime.h>

// check if we're using MrC (in MPW) to compile
#elif defined(__MRC__)

	#include <QuickTime.h>

#else

	#error Unrecognized IDE: cannot determine which Carbon headers to use.
 
#endif

#endif