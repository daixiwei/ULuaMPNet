using System;
using com.gt.assets;
using LuaInterface;

public class IAssetBundleWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Load", Load),
		new LuaMethod("MainAsset", MainAsset),
		new LuaMethod("Unload", Unload),
		new LuaMethod("New", _CreateIAssetBundle),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("Parameter", get_Parameter, set_Parameter),
		new LuaField("Name", get_Name, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateIAssetBundle(IntPtr L)
	{
		LuaDLL.luaL_error(L, "IAssetBundle class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(IAssetBundle));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "com.gt.assets.IAssetBundle", typeof(IAssetBundle), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Parameter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		IAssetBundle obj = (IAssetBundle)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Parameter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Parameter on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.Parameter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		IAssetBundle obj = (IAssetBundle)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Name");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Name on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.Name);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Parameter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		IAssetBundle obj = (IAssetBundle)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Parameter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Parameter on a nil value");
			}
		}

		obj.Parameter = LuaScriptMgr.GetNetObject<com.gt.assets.AssetParameter>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Load(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		IAssetBundle obj = LuaScriptMgr.GetNetObject<IAssetBundle>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		object o = obj.Load(arg0);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MainAsset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		IAssetBundle obj = LuaScriptMgr.GetNetObject<IAssetBundle>(L, 1);
		object o = obj.MainAsset();
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Unload(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(com.gt.assets.IAssetBundle), typeof(bool)))
		{
			IAssetBundle obj = LuaScriptMgr.GetNetObject<IAssetBundle>(L, 1);
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			obj.Unload(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(com.gt.assets.IAssetBundle), typeof(string)))
		{
			IAssetBundle obj = LuaScriptMgr.GetNetObject<IAssetBundle>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			obj.Unload(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: IAssetBundle.Unload");
		}

		return 0;
	}
}

