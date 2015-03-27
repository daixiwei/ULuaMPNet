using System;
using LuaInterface;

public class LuaMessageTransmitterWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Call", Call),
		new LuaMethod("Connect", Connect),
		new LuaMethod("Login", Login),
		new LuaMethod("New", _CreateLuaMessageTransmitter),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLuaMessageTransmitter(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			LuaMessageTransmitter obj = new LuaMessageTransmitter(arg0,arg1);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: LuaMessageTransmitter.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(LuaMessageTransmitter));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "LuaMessageTransmitter", typeof(LuaMessageTransmitter), regs, fields, typeof(com.gt.mpnet.MessageTransmitter));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Call(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		LuaMessageTransmitter obj = LuaScriptMgr.GetNetObject<LuaMessageTransmitter>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		object[] objs1 = LuaScriptMgr.GetParamsObject(L, 3, count - 2);
		obj.Call(arg0,objs1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Connect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		LuaMessageTransmitter obj = LuaScriptMgr.GetNetObject<LuaMessageTransmitter>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.Connect(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Login(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		LuaMessageTransmitter obj = LuaScriptMgr.GetNetObject<LuaMessageTransmitter>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		obj.Login(arg0,arg1);
		return 0;
	}
}

