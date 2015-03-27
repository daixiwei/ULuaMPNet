using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public enum LuaType { 
    uLua = 0,
    nLua = 1,
}

public class Const {   
    public static bool DebugMode = true;                       //调试模式-用于内部测试
    public static int TimerInterval = 1;
    public static int GameFrameRate = 30;                       //游戏帧频

    public static TextAsset[] luaScripts;                       //Lua公共脚本

    public static string UserId = string.Empty;                 //用户ID
    public static string AppName = "simpleframework";           //应用程序名称
    public static string AppPrefix = AppName + "_";             //应用程序前缀

    public static string WebUrl = string.Empty;
    public static int SocketPort = 0;                           //Socket服务器端口
    public static string SocketAddress = string.Empty;          //Socket服务器地址
}
