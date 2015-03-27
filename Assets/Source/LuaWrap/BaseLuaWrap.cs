using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class BaseLuaWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("AddClick", AddClick),
		new LuaMethod("RemoveClick", RemoveClick),
		new LuaMethod("New", _CreateBaseLua),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__eq", Lua_Eq),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("LuaView", get_LuaView, set_LuaView),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateBaseLua(IntPtr L)
	{
		LuaDLL.luaL_error(L, "BaseLua class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(BaseLua));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "BaseLua", typeof(BaseLua), regs, fields, typeof(UnityEngine.MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaView(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		BaseLua obj = (BaseLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name LuaView");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index LuaView on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.LuaView);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_LuaView(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		BaseLua obj = (BaseLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name LuaView");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index LuaView on a nil value");
			}
		}

		obj.LuaView = LuaScriptMgr.GetLuaTable(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		BaseLua obj = LuaScriptMgr.GetNetObject<BaseLua>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.AddClick(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		BaseLua obj = LuaScriptMgr.GetNetObject<BaseLua>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.RemoveClick(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetVarObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetVarObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

