﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log
{
    public static void D(string msg)
    {
        Debug.Log(msg);
    }

    public static void E(string msg)
    {
        Debug.LogError(msg);
    }

 
}
