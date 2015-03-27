using System;
using com.gt;
using LuaInterface;

public class INetManagerWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetTransmitter", GetTransmitter),
		new LuaMethod("AddEventListener", AddEventListener),
		new LuaMethod("RemoveEventListener", RemoveEventListener),
		new LuaMethod("RemoveAllEventListeners", RemoveAllEventListeners),
		new LuaMethod("AddLuaEventListener", AddLuaEventListener),
		new LuaMethod("RemoveLuaEventListener", RemoveLuaEventListener),
		new LuaMethod("RemoveAllLuaEventListeners", RemoveAllLuaEventListeners),
		new LuaMethod("AddMPNetClient", AddMPNetClient),
		new LuaMethod("AddTransmitter", AddTransmitter),
		new LuaMethod("AddMessageHandler", AddMessageHandler),
		new LuaMethod("AddLuaMessageHandler", AddLuaMessageHandler),
		new LuaMethod("RemoveLuaMessageHandler", RemoveLuaMessageHandler),
		new LuaMethod("DispatchEvent", DispatchEvent),
		new LuaMethod("DispatchLuaEvent", DispatchLuaEvent),
		new LuaMethod("KillConnection", KillConnection),
		new LuaMethod("KillAllConnection", KillAllConnection),
		new LuaMethod("New", _CreateINetManager),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("CacheQueueProcess", get_CacheQueueProcess, set_CacheQueueProcess),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateINetManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "INetManager class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(INetManager));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "com.gt.INetManager", typeof(INetManager), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CacheQueueProcess(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		INetManager obj = (INetManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name CacheQueueProcess");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index CacheQueueProcess on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.CacheQueueProcess);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CacheQueueProcess(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		INetManager obj = (INetManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name CacheQueueProcess");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index CacheQueueProcess on a nil value");
			}
		}

		obj.CacheQueueProcess = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTransmitter(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		INetManager obj = LuaScriptMgr.GetNetObject<INetManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		com.gt.mpnet.MessageTransmitter o = obj.GetTransmitter(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddEventListener(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		INetManager obj = LuaScriptMgr.GetNetObject<INetManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		com.gt.events.EventListenerDelegate arg1 = LuaScriptMgr.GetNetObject<com.gt.events.EventListenerDelegate>(L, 3);
		obj.AddEventListener(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveEventListener(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		INetManager obj = LuaScriptMgr.GetNetObject<INetManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		com.gt.events.EventListenerDelegate arg1 = LuaScriptMgr.GetNetObject<com.gt.events.EventListenerDelegate>(L, 3);
		obj.RemoveEventListener(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveAllEventListeners(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		INetManager obj = LuaScriptMgr.GetNetObject<INetManager>(L, 1);
		obj.RemoveAllEventListeners();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddLuaEventListener(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		INetManager obj = LuaScriptMgr.GetNetObject<INetManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		obj.AddLuaEventListener(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveLuaEventListener(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		INetManager obj = LuaScriptMgr.GetNetObject<INetManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		obj.RemoveLuaEventListener(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveAllLuaEventListeners(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		INetManager obj = LuaScriptMgr.GetNetObject<INetManager>(L, 1);
		obj.RemoveAllLuaEventListeners();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddMPNetClient(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		INetManager obj = LuaScriptMgr.GetNetObject<INetManager>(L, 1);
		com.gt.mpnet.MPNetClient arg0 = LuaScriptMgr.GetNetObject<com.gt.mpnet.MPNetClient>(L, 2);
		obj.AddMPNetClient(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddTransmitter(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		INetManager obj = LuaScriptMgr.GetNetObject<INetManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		com.gt.mpnet.MessageTransmitter arg1 = LuaScriptMgr.GetNetObject<com.gt.mpnet.MessageTransmitter>(L, 3);
		obj.AddTransmitter(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddMessageHandler(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		INetManager obj = LuaScriptMgr.GetNetObject<INetManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		com.gt.mpnet.MessageHandler arg1 = LuaScriptMgr.GetNetObject<com.gt.mpnet.MessageHandler>(L, 3);
		obj.AddMessageHandler(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddLuaMessageHandler(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		INetManager obj = LuaScriptMgr.GetNetObject<INetManager>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		LuaFunction arg2 = LuaScriptMgr.GetLuaFunction(L, 4);
		obj.AddLuaMessageHandler(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveLuaMessageHandler(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		INetManager obj = LuaScriptMgr.GetNetObject<INetManager>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		LuaFunction arg2 = LuaScriptMgr.GetLuaFunction(L, 4);
		obj.RemoveLuaMessageHandler(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DispatchEvent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		INetManager obj = LuaScriptMgr.GetNetObject<INetManager>(L, 1);
		com.gt.events.BaseEvent arg0 = LuaScriptMgr.GetNetObject<com.gt.events.BaseEvent>(L, 2);
		obj.DispatchEvent(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DispatchLuaEvent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		INetManager obj = LuaScriptMgr.GetNetObject<INetManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		LuaTable arg1 = LuaScriptMgr.GetLuaTable(L, 3);
		obj.DispatchLuaEvent(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int KillConnection(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		INetManager obj = LuaScriptMgr.GetNetObject<INetManager>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.KillConnection(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int KillAllConnection(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		INetManager obj = LuaScriptMgr.GetNetObject<INetManager>(L, 1);
		obj.KillAllConnection();
		return 0;
	}
}

