/*
 *  CarbonWrapper.h
 *  RW4.5.2
 *
 *  Created by Sam Rushing on 5/20/05.
 *  Copyright 2005 __MyCompanyName__. All rights reserved.
 *
 */

/*
 *  This file wraps the Carbon framework includes so that we don't have
 *  to edit every last file when we transition to MPW for the final build.
 */

#ifndef __ROBOWAR_CARBONWRAPPER__
#define __ROBOWAR_CARBONWRAPPER__

// check if we're using gcc (in Xcode or Project Builder) to compile
#if defined(__APPLE_CC__)

	#include <Carbon/Carbon.h>

// check if we're using MrC (in MPW) to compile
#elif defined(__MRC__)

	#include <Carbon.h>

#else

	#error Unrecognized IDE: cannot determine which Carbon headers to use.
 
#endif

#endif