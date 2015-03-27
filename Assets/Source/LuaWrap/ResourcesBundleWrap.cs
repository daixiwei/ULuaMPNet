using System;
using com.platform.unity.assets;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class ResourcesBundleWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Unload", Unload),
		new LuaMethod("Load", Load),
		new LuaMethod("MainAsset", MainAsset),
		new LuaMethod("New", _CreateResourcesBundle),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("Parameter", get_Parameter, set_Parameter),
		new LuaField("Name", get_Name, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateResourcesBundle(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			com.platform.unity.assets.UnityAssetManager arg0 = LuaScriptMgr.GetNetObject<com.platform.unity.assets.UnityAssetManager>(L, 1);
			com.gt.assets.AssetParameter arg1 = LuaScriptMgr.GetNetObject<com.gt.assets.AssetParameter>(L, 2);
			Object arg2 = LuaScriptMgr.GetNetObject<Object>(L, 3);
			ResourcesBundle obj = new ResourcesBundle(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ResourcesBundle.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ResourcesBundle));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "com.platform.unity.assets.ResourcesBundle", typeof(ResourcesBundle), regs, fields, typeof(System.Object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Parameter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ResourcesBundle obj = (ResourcesBundle)o;

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
		ResourcesBundle obj = (ResourcesBundle)o;

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
		ResourcesBundle obj = (ResourcesBundle)o;

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
	static int Unload(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(com.platform.unity.assets.ResourcesBundle), typeof(string)))
		{
			ResourcesBundle obj = LuaScriptMgr.GetNetObject<ResourcesBundle>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			obj.Unload(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(com.platform.unity.assets.ResourcesBundle), typeof(bool)))
		{
			ResourcesBundle obj = LuaScriptMgr.GetNetObject<ResourcesBundle>(L, 1);
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			obj.Unload(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ResourcesBundle.Unload");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Load(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ResourcesBundle obj = LuaScriptMgr.GetNetObject<ResourcesBundle>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		object o = obj.Load(arg0);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MainAsset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ResourcesBundle obj = LuaScriptMgr.GetNetObject<ResourcesBundle>(L, 1);
		object o = obj.MainAsset();
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}
}

