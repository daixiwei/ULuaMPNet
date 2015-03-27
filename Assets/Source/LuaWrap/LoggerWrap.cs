using System;
using com.gt.units;
using LuaInterface;

public class LoggerWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Debug", Debug),
		new LuaMethod("Error", Error),
		new LuaMethod("Info", Info),
		new LuaMethod("Warn", Warn),
		new LuaMethod("New", _CreateLogger),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("LoggingLevel", get_LoggingLevel, set_LoggingLevel),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLogger(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);


		if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type)))
		{
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
			Logger obj = new Logger(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(string)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			Logger obj = new Logger(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Logger.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Logger));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "com.gt.units.Logger", typeof(Logger), regs, fields, typeof(System.Object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LoggingLevel(IntPtr L)
	{
		LuaScriptMgr.Push(L, Logger.LoggingLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_LoggingLevel(IntPtr L)
	{
		Logger.LoggingLevel = LuaScriptMgr.GetNetObject<com.gt.units.LogLevel>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Debug(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		Logger obj = LuaScriptMgr.GetNetObject<Logger>(L, 1);
		string[] objs0 = LuaScriptMgr.GetParamsString(L, 2, count - 1);
		obj.Debug(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Error(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		Logger obj = LuaScriptMgr.GetNetObject<Logger>(L, 1);
		string[] objs0 = LuaScriptMgr.GetParamsString(L, 2, count - 1);
		obj.Error(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Info(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		Logger obj = LuaScriptMgr.GetNetObject<Logger>(L, 1);
		string[] objs0 = LuaScriptMgr.GetParamsString(L, 2, count - 1);
		obj.Info(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Warn(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		Logger obj = LuaScriptMgr.GetNetObject<Logger>(L, 1);
		string[] objs0 = LuaScriptMgr.GetParamsString(L, 2, count - 1);
		obj.Warn(objs0);
		return 0;
	}
}

