using UnityEngine;
using System.Collections;

public enum PROTOCOL_CS : byte
{
    CS_LIVE,
  	SC_LIVE_ECHO,
	
	// npc
	SC_NPC_APPEAR,
	SC_NPC_DISAPPEAR,
	SC_NPC_MOVE,
	SC_NPC_SKILL,
	
	//drop item
	CS_PICKUP_ITEM,
	SC_PICKUP_ITEM_RESULT,
	SC_DROPITEM_APPEAR,
	SC_DROPITEM_DISAPPEAR,
	
	// item
	CS_ITEM_USE,
	SC_ITEM_RESULT,
	
	// char
	CS_CHEAT_HP,
}








