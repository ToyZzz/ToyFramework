using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log
{
	public static void D(DebugType type, string msg)
	{
		D(String.Format("<color=#00ffff>[{0}]</color>{1}", type.ToString(), msg));
	}

	public static void D(string msg)
    {
        Debug.Log(msg);
    }

    public static void E(string msg)
    {
        Debug.LogError(msg);
    }

 
}
