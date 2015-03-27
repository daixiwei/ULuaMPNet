using System;
using com.gt;
using LuaInterface;

public class GTLibWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateGTLib),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("GameManager", get_GameManager, set_GameManager),
		new LuaField("NetManager", get_NetManager, set_NetManager),
		new LuaField("AssetManager", get_AssetManager, set_AssetManager),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGTLib(IntPtr L)
	{
		LuaDLL.luaL_error(L, "GTLib class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(GTLib));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "com.gt.GTLib", typeof(GTLib), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GameManager(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, GTLib.GameManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NetManager(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, GTLib.NetManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AssetManager(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, GTLib.AssetManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_GameManager(IntPtr L)
	{
		GTLib.GameManager = LuaScriptMgr.GetNetObject<com.gt.IGameManager>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_NetManager(IntPtr L)
	{
		GTLib.NetManager = LuaScriptMgr.GetNetObject<com.gt.INetManager>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AssetManager(IntPtr L)
	{
		GTLib.AssetManager = LuaScriptMgr.GetNetObject<com.gt.IAssetManager>(L, 3);
		return 0;
	}
}

