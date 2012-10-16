using System;
using System.Reflection;
using UnityEngine;


public enum PROTOCOL_CS : byte
{
    CS_LIVE,
  	SC_LIVE_ECHO,
	
	// npc
	SC_MONSTER_APPEAR,
	SC_MONSTER_DISAPPEAR,
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



public class cSC_MONSTER_APPEAR_DATA : PacketHeader
{
	public static int size = 48 + 4;

    public Int32 nIdx;
    public Int32 nTableIdx;	

    public Vector3 sCurPosition;
	public Vector3 sCurSize;
	public float fCurRotate;   
	public float fMoveSpeed;
}


public class cSC_MONSTER_APPEAR : PacketHeader
{
	public Int32 nCnt;
    public cSC_MONSTER_APPEAR_DATA[] datas = null;
}


public class cSC_USER_APPEAR_DATA : PacketHeader
{
	public static int size = 48 + 4;

    public Int32 nIdx;
    public Int32 nTableIdx;	

    public Vector3 sCurPosition;
	public Vector3 sCurSize;
	public float fCurRotate;   
	public float fMoveSpeed;
}


public class cSC_USER_APPEAR : PacketHeader
{
	public Int32 nCnt;
    public cSC_USER_APPEAR_DATA[] datas = null;
}

