using System;
using System.Reflection;
using UnityEngine;

public enum PROTOCOL_GAME : byte
{
	CG_CHAR_CREATE,
    GC_CHAR_CREATE_RESULT,   
}


public class cGC_CHAR_CREATE_RESULT : PacketHeader
{
	public static int size = cSC_USER_APPEAR_DATA.size;

   	public cSC_USER_APPEAR_DATA data;
}