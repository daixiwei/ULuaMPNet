using System;
using com.gt;
using LuaInterface;

public class IAssetManagerWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("LoadAsset", LoadAsset),
		new LuaMethod("GetAsset", GetAsset),
		new LuaMethod("PutAssetLoader", PutAssetLoader),
		new LuaMethod("BeginLoadEntity", BeginLoadEntity),
		new LuaMethod("EndLoadEntity", EndLoadEntity),
		new LuaMethod("UnLoadAsset", UnLoadAsset),
		new LuaMethod("ClearTempAsset", ClearTempAsset),
		new LuaMethod("New", _CreateIAssetManager),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("Progress", get_Progress, null),
		new LuaField("IsComplete", get_IsComplete, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateIAssetManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "IAssetManager class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(IAssetManager));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "com.gt.IAssetManager", typeof(IAssetManager), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Progress(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		IAssetManager obj = (IAssetManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Progress");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Progress on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.Progress);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsComplete(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		IAssetManager obj = (IAssetManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name IsComplete");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index IsComplete on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.IsComplete);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAsset(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(com.gt.IAssetManager), typeof(com.gt.assets.AssetParameter)))
		{
			IAssetManager obj = LuaScriptMgr.GetNetObject<IAssetManager>(L, 1);
			com.gt.assets.AssetParameter arg0 = LuaScriptMgr.GetNetObject<com.gt.assets.AssetParameter>(L, 2);
			obj.LoadAsset(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(com.gt.IAssetManager), typeof(string)))
		{
			IAssetManager obj = LuaScriptMgr.GetNetObject<IAssetManager>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			obj.LoadAsset(arg0);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(com.gt.IAssetManager), typeof(com.gt.assets.AssetParameter), typeof(string)))
		{
			IAssetManager obj = LuaScriptMgr.GetNetObject<IAssetManager>(L, 1);
			com.gt.assets.AssetParameter arg0 = LuaScriptMgr.GetNetObject<com.gt.assets.AssetParameter>(L, 2);
			string arg1 = LuaScriptMgr.GetString(L, 3);
			obj.LoadAsset(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(com.gt.IAssetManager), typeof(string), typeof(string)))
		{
			IAssetManager obj = LuaScriptMgr.GetNetObject<IAssetManager>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			string arg1 = LuaScriptMgr.GetString(L, 3);
			obj.LoadAsset(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: IAssetManager.LoadAsset");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAsset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		IAssetManager obj = LuaScriptMgr.GetNetObject<IAssetManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		com.gt.assets.IAssetBundle o = obj.GetAsset(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PutAssetLoader(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		IAssetManager obj = LuaScriptMgr.GetNetObject<IAssetManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		com.gt.IAssetLoader arg1 = LuaScriptMgr.GetNetObject<com.gt.IAssetLoader>(L, 3);
		obj.PutAssetLoader(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BeginLoadEntity(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		IAssetManager obj = LuaScriptMgr.GetNetObject<IAssetManager>(L, 1);
		obj.BeginLoadEntity();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EndLoadEntity(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		IAssetManager obj = LuaScriptMgr.GetNetObject<IAssetManager>(L, 1);
		obj.EndLoadEntity();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnLoadAsset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		IAssetManager obj = LuaScriptMgr.GetNetObject<IAssetManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.UnLoadAsset(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearTempAsset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		IAssetManager obj = LuaScriptMgr.GetNetObject<IAssetManager>(L, 1);
		obj.ClearTempAsset();
		return 0;
	}
}

