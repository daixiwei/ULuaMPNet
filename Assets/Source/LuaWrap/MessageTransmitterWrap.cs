using System;
using com.gt.mpnet;
using LuaInterface;

public class MessageTransmitterWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("SendExtensionRequest", SendExtensionRequest),
		new LuaMethod("New", _CreateMessageTransmitter),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("PrefabConnecterId", get_PrefabConnecterId, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMessageTransmitter(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			MessageTransmitter obj = new MessageTransmitter(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MessageTransmitter.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(MessageTransmitter));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "com.gt.mpnet.MessageTransmitter", typeof(MessageTransmitter), regs, fields, typeof(System.Object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_PrefabConnecterId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MessageTransmitter obj = (MessageTransmitter)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name PrefabConnecterId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index PrefabConnecterId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.PrefabConnecterId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendExtensionRequest(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		if (count == 2)
		{
			MessageTransmitter obj = LuaScriptMgr.GetNetObject<MessageTransmitter>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.SendExtensionRequest(arg0);
			return 0;
		}
		else if (count == 3)
		{
			MessageTransmitter obj = LuaScriptMgr.GetNetObject<MessageTransmitter>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			com.gt.entities.IMPObject arg1 = LuaScriptMgr.GetNetObject<com.gt.entities.IMPObject>(L, 3);
			obj.SendExtensionRequest(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			MessageTransmitter obj = LuaScriptMgr.GetNetObject<MessageTransmitter>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			com.gt.entities.IMPObject arg1 = LuaScriptMgr.GetNetObject<com.gt.entities.IMPObject>(L, 3);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 4);
			obj.SendExtensionRequest(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MessageTransmitter.SendExtensionRequest");
		}

		return 0;
	}
}

