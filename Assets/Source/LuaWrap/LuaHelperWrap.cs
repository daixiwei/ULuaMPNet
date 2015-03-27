using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class LuaHelperWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetType", GetType),
		new LuaMethod("GetComponentInChildren", GetComponentInChildren),
		new LuaMethod("GetComponent", GetComponent),
		new LuaMethod("GetComponentsInChildren", GetComponentsInChildren),
		new LuaMethod("NewPanel", NewPanel),
		new LuaMethod("NewLoadPanel", NewLoadPanel),
		new LuaMethod("CloseLoadPanel", CloseLoadPanel),
		new LuaMethod("GetAllChild", GetAllChild),
		new LuaMethod("Action", Action),
		new LuaMethod("VoidDelegate", VoidDelegate),
		new LuaMethod("New", _CreateLuaHelper),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("UIRoot", get_UIRoot, set_UIRoot),
		new LuaField("LoadPanelSlider", get_LoadPanelSlider, set_LoadPanelSlider),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLuaHelper(IntPtr L)
	{
		LuaDLL.luaL_error(L, "LuaHelper class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(LuaHelper));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "LuaHelper", typeof(LuaHelper), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UIRoot(IntPtr L)
	{
		LuaScriptMgr.Push(L, LuaHelper.UIRoot);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LoadPanelSlider(IntPtr L)
	{
		LuaScriptMgr.Push(L, LuaHelper.LoadPanelSlider);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_UIRoot(IntPtr L)
	{
		LuaHelper.UIRoot = LuaScriptMgr.GetNetObject<Transform>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_LoadPanelSlider(IntPtr L)
	{
		LuaHelper.LoadPanelSlider = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Type o = LuaHelper.GetType(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentInChildren(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Component o = LuaHelper.GetComponentInChildren(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Component o = LuaHelper.GetComponent(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentsInChildren(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Component[] o = LuaHelper.GetComponentsInChildren(arg0,arg1);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int NewPanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Transform arg0 = LuaScriptMgr.GetNetObject<Transform>(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		GameObject o = LuaHelper.NewPanel(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int NewLoadPanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		GameObject o = LuaHelper.NewLoadPanel();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CloseLoadPanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		LuaHelper.CloseLoadPanel();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAllChild(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 1);
		Transform[] o = LuaHelper.GetAllChild(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Action(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 1);
		Action o = LuaHelper.Action(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int VoidDelegate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 1);
		UIEventListener.VoidDelegate o = LuaHelper.VoidDelegate(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

