//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//- ¥ Label Functions ¥ LabelMenu.c
//-------------------------------------------------------------------------------------
//- 
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

#include <Carbon/Carbon.h>
#include "robotypes.h"


LabelList	labelsList;

//extern ControlHandle	labelMenu;
extern MenuHandle		labelMenu;


LabelItem* NewLabelAfter( LabelItem* prevLabel, unsigned char* name, long pos );
LabelItem* NewLabelBefore( LabelItem* nextLabel, unsigned char* name, long pos );
LabelItem* CreateLabel( unsigned char* name, long pos );
void MoveLabelBefore( LabelItem* toBeMoved, LabelItem* beforeThisLabel );
void MoveLabelAfter( LabelItem* toBeMoved, LabelItem* afterThisLabel );
void DisposeLabelList( LabelItem* listStart );
void DelAllMenuItems(MenuHandle menu);
void AddLabelListToMenu(MenuHandle menu, LabelItem* listStart, short insertAtPos);
void CreateLabelsMenu(void);
void MyDelLabels(void);
LabelItem* FindListStart( LabelItem* labelsList );
LabelItem* FindLabelByID( short id, LabelItem* labelsList );

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// ¥ 
// ---
LabelItem* NewLabelAfter( LabelItem* prevLabel, unsigned char* name, long pos )
{
	short i;
	LabelItem*	newLabel;

	newLabel = CreateLabel( name, pos );

	MoveLabelAfter( newLabel, prevLabel );
}

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// ¥ 
// ---
LabelItem* NewLabelBefore( LabelItem* nextLabel, unsigned char* name, long pos )
{
	short i;
	LabelItem*	newLabel;

	newLabel = CreateLabel( name, pos );
	
	MoveLabelBefore( newLabel, nextLabel );
}

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// ¥ 
// ---
LabelItem* CreateLabel( unsigned char* name, long pos )
{
	short i;
	LabelItem*	newLabel;
	
	newLabel = (LabelItem*)NewPtr( sizeof( LabelItem ) );
	
	for( i = name[0]; i >= 0; i-- )
	{
		newLabel->name[i] = name[i];
	}
	
	newLabel->pos = pos;
	
	return newLabel;
}

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// ¥ 
// ---
void MoveLabelBefore( LabelItem* toBeMoved, LabelItem* beforeThisLabel )
{
	(LabelItem*)toBeMoved->next = beforeThisLabel;
	if( beforeThisLabel != nil )
	{
		toBeMoved->prev = beforeThisLabel->prev;
		
		if( beforeThisLabel->prev != nil )
			(LabelItem*)((LabelItem*)beforeThisLabel->prev)->next = toBeMoved;
			
		(LabelItem*)beforeThisLabel->prev = toBeMoved;

	}
	else
		toBeMoved->prev = nil;
}

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// ¥ 
// ---
void MoveLabelAfter( LabelItem* toBeMoved, LabelItem* afterThisLabel )
{
	(LabelItem*)toBeMoved->prev = afterThisLabel;
	if( afterThisLabel != nil )
	{
		toBeMoved->next = afterThisLabel->next;
		
		if( afterThisLabel->next != nil )
			(LabelItem*)((LabelItem*)afterThisLabel->next)->prev = toBeMoved;
			
		(LabelItem*)afterThisLabel->next = toBeMoved;
	}
	else
		toBeMoved->next = nil;
}


//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// ¥ 
// ---
void DisposeLabelList( LabelItem* listStart )
{
	LabelItem *curPos, *tmp, *tmp2;
	
	if( listStart != nil)
	{
		tmp2 = (LabelItem*)listStart->prev;
		curPos = listStart;
		while( curPos != nil )
		{
			tmp = (LabelItem*)curPos->next;
			DisposePtr( (Ptr)curPos );
			curPos = tmp;
		}
		curPos = tmp2;
		while( curPos != nil )
		{
			tmp = (LabelItem*)curPos->prev;
			DisposePtr( (Ptr)curPos );
			curPos = tmp;
		}
	}
}

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// ¥ 
// ---
void AddLabelListToMenu(MenuHandle menu, LabelItem* listStart, short insertAtPos)
{
	short itemPos;
	LabelItem *curPos, *tmp;
	
	if(listStart)
	{
	
		itemPos = insertAtPos;
		
		curPos = listStart;
		while( curPos != nil )
		{
			InsertMenuItem( menu, curPos->name, itemPos );
			curPos = (LabelItem*)curPos->next;
			itemPos ++;
		}
	
		curPos = (LabelItem*)listStart->prev;
		while( curPos != nil )
		{
			InsertMenuItem( menu, curPos->name, insertAtPos );
			curPos = (LabelItem*)curPos->prev;
		}
	}
}


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
void CreateLabelsMenu()
{
	AddLabelListToMenu(labelMenu, labelsList, 0);
}


//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// ¥ 
// ---
void MyDelLabels()
{
	DelAllMenuItems(labelMenu);
	DisposeLabelList(labelsList);
	labelsList = nil;
}

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// ¥ 
// ---
LabelItem* FindListStart( LabelItem* labelsList )
{
	LabelItem* curPos;
	
	curPos = labelsList;
	
	if( curPos != nil )
	{
		while( curPos->prev != nil )
		{
			curPos = (LabelItem*)curPos->prev;
		}
	}
	
	return curPos;
}


//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// ¥ 
// ---
LabelItem* FindLabelByID( short id, LabelItem* labelsList )
{
	short i;
	LabelItem* curItem;
	
	curItem = labelsList;
	
	for( i = 0; i < id && curItem != nil; i ++ )
	{
		curItem = (LabelItem*)curItem->next;
	}
	
	return curItem;
}