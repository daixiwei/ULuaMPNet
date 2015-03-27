using System;
using com.gt;
using System.Collections;
using LuaInterface;

public class IGameManagerWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("PostRunnable", PostRunnable),
		new LuaMethod("Print", Print),
		new LuaMethod("StartGTCoroutine", StartGTCoroutine),
		new LuaMethod("StopGTCoroutine", StopGTCoroutine),
		new LuaMethod("StopAllGTCoroutine", StopAllGTCoroutine),
		new LuaMethod("New", _CreateIGameManager),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("Log", get_Log, null),
		new LuaField("DeltaTime", get_DeltaTime, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateIGameManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "IGameManager class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(IGameManager));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "com.gt.IGameManager", typeof(IGameManager), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Log(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		IGameManager obj = (IGameManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Log");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Log on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.Log);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DeltaTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		IGameManager obj = (IGameManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name DeltaTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index DeltaTime on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.DeltaTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PostRunnable(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		IGameManager obj = LuaScriptMgr.GetNetObject<IGameManager>(L, 1);
		com.gt.Runnable arg0 = LuaScriptMgr.GetNetObject<com.gt.Runnable>(L, 2);
		obj.PostRunnable(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Print(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		IGameManager obj = LuaScriptMgr.GetNetObject<IGameManager>(L, 1);
		com.gt.units.LogLevel arg0 = LuaScriptMgr.GetNetObject<com.gt.units.LogLevel>(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		string arg2 = LuaScriptMgr.GetLuaString(L, 4);
		obj.Print(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StartGTCoroutine(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		if (count == 2)
		{
			IGameManager obj = LuaScriptMgr.GetNetObject<IGameManager>(L, 1);
			IEnumerator arg0 = LuaScriptMgr.GetNetObject<IEnumerator>(L, 2);
			obj.StartGTCoroutine(arg0);
			return 0;
		}
		else if (count == 3)
		{
			IGameManager obj = LuaScriptMgr.GetNetObject<IGameManager>(L, 1);
			IEnumerator arg0 = LuaScriptMgr.GetNetObject<IEnumerator>(L, 2);
			com.gt.Runnable arg1 = LuaScriptMgr.GetNetObject<com.gt.Runnable>(L, 3);
			obj.StartGTCoroutine(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: IGameManager.StartGTCoroutine");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopGTCoroutine(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		IGameManager obj = LuaScriptMgr.GetNetObject<IGameManager>(L, 1);
		IEnumerator arg0 = LuaScriptMgr.GetNetObject<IEnumerator>(L, 2);
		obj.StopGTCoroutine(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopAllGTCoroutine(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		IGameManager obj = LuaScriptMgr.GetNetObject<IGameManager>(L, 1);
		obj.StopAllGTCoroutine();
		return 0;
	}
}

