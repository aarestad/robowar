//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-//- � Syntax Colouring Functions � SyntaxColouring.c//-------------------------------------------------------------------------------------//- //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-#include <Carbon/Carbon.h>#include "robotypes.h"//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-// --- For WASTE//#include "myWASTE.h"//#include "TextUtilFunc.h"//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-extern void 			reportMessage(char *message1,char *message2);extern void 			myReportNum( char* msg, long num );//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-extern prefStruct	gPrefs;//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-void 	SyntaxColorRange(long start, long end, WEReference wasteText);Boolean DoCharIsLabel( long* pos, Handle text, long end );Boolean DoCharIsComment( long* pos, Handle text, long end );void 	DoSyntaxColor( RGBColor color, long start, long end, WEReference wasteText );void	SyntaxColorSelection(WEReference wasteText);//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-// � SyntaxColorSelection// --- Syntax colour the selection, used for when changes are made//---n 15/4/98void SyntaxColorSelection(WEReference wasteText){	#pragma unused ( wasteText )	// used for dynamic syntax colouring	/*Handle		text;	long start, end;		// we need the text handle allot for my text util calls;	text = WEGetText( wasteText );		WEGetSelection( &start, &end, wasteText );	start--;	SyntaxColorRange( start, end, wasteText );	//reportMessage( "start = ", &(*text)[start] );	//reportMessage( "end = ", &(*text)[end] );*/}//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-// � SyntaxColorRange// ---  Syntax colour the range, used for all syntax colouring//---n 15/4/98void SyntaxColorRange(long start, long end, WEReference wasteText){	Handle		text;	long		pos, lastSyntaxEnd;	WERunInfo 	runInfo;	//unsigned char	label[20];	//short		tmp;	long 		selStart,selEnd;		if( gPrefs.syntaxColoringQ == false )		return;		if( end >= WEGetTextLength( wasteText ) )		end = WEGetTextLength( wasteText ) - 1;		WEGetSelection( &selStart, &selEnd, wasteText );	WESetSelection( selStart, selStart, wasteText );		// we need the text handle allot for my text util calls;	text = WEGetText( wasteText );		WEGetRunInfo(start, &runInfo, wasteText);	//pos = runInfo.runStart;	//- are we in a comment		if( (*text)[ runInfo.runStart ] == '#' )	{		pos = FindLineEnd( start, text, end );		if( pos > end )			return;		else			end = runInfo.runEnd;	}	else if( (*text)[ runInfo.runStart ] == '{' )	{		pos = FindNextChar( start, '}', text,  runInfo.runEnd );		if( pos > end )			return;		else			end = runInfo.runEnd;	}	else if( (*text)[ runInfo.runEnd ] == ':' )	{		start = runInfo.runStart;	}	//- if so, find comment end.	//if( DoCharIsComment( &pos, text, end ) && runInfo.runStart < start )	//	start = pos + 1;				//- goto first word		//- for ( pos < end )		//- if word is special token			//- Handle special token		//- if( word is token )			//- colour word			//- goto end of word		//- goto next word	//-		//MyDelLabels();		lastSyntaxEnd = start;	for( pos = start; pos < end; pos ++ )	{		// Hanlde Comments		start = pos;		if( DoCharIsComment( &pos, text, WEGetTextLength(wasteText) - 1 ) )		{			DoSyntaxColor( gPrefs.mainTextColor, lastSyntaxEnd, start, wasteText );						DoSyntaxColor( gPrefs.commentColor, start, pos+1, wasteText );			lastSyntaxEnd = pos+1;		}		else if( DoCharIsLabel( &start, text, end ) )		{			DoSyntaxColor( gPrefs.mainTextColor, lastSyntaxEnd, start, wasteText );			//--- note labels are found backwords from the ':'						//label[0] = pos - start;			//for ( tmp = 0 ; tmp < label[0]; tmp ++ )			//	label[tmp + 1] = (*text)[ start + tmp ];						//labelsList = NewLabelAfter( labelsList, label, start );						DoSyntaxColor( gPrefs.labelColor, start, pos, wasteText );			lastSyntaxEnd = pos+1;		}	}	if( lastSyntaxEnd < end )		DoSyntaxColor( gPrefs.mainTextColor, lastSyntaxEnd, end - 1, wasteText );		//CreateLabelsMenu();	//labelsList = FindListStart( labelsList );		WESetSelection( selStart, selEnd, wasteText );}//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-// � DoCharIsLabel// --- handle LabelsBoolean DoCharIsLabel( long* pos, Handle text, long end ){	#pragma unused (end )	if( (*text)[*pos] == ':' )	{		*pos = FindWordStart( *pos - 1, text );		return true;	}	else		return false;}//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-// � DoCharIsComment// --- handle comments// aka - Find CommentEnd:	// we know run end, so we searchfrom start to runEnd 	// for comment end, if found outside run end, move run 	// end to new end pos;Boolean DoCharIsComment( long* pos, Handle text, long end ){	if( (*text)[*pos] == '#' ) // comment is ignore line char	{		*pos = FindLineEnd( *pos, text, end );		//*pos ++;		return true;	}	else if( (*text)[*pos] == '{' ) // comment is ignore until end of comment	{		*pos = FindNextChar( *pos, '}', text, end );		//*pos ++;		return true;	}	else		return false;}//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-// � DoSyntaxColor// ---void DoSyntaxColor( RGBColor colour, long start, long end, WEReference wasteText ){	TextStyle	ts ;	//long		oldStart,oldEnd;	ts.tsColor = colour;		WESetStyleRange( weDoColor, start, end, &ts, wasteText );}