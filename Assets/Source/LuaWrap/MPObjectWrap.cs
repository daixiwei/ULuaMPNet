using System;
using com.gt.entities;
using LuaInterface;

public class MPObjectWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("ContainsKey", ContainsKey),
		new LuaMethod("GetBool", GetBool),
		new LuaMethod("GetByte", GetByte),
		new LuaMethod("GetByteArray", GetByteArray),
		new LuaMethod("GetData", GetData),
		new LuaMethod("GetDouble", GetDouble),
		new LuaMethod("GetFloat", GetFloat),
		new LuaMethod("GetInt", GetInt),
		new LuaMethod("GetKeys", GetKeys),
		new LuaMethod("GetLong", GetLong),
		new LuaMethod("GetMPArray", GetMPArray),
		new LuaMethod("GetMPObject", GetMPObject),
		new LuaMethod("GetShort", GetShort),
		new LuaMethod("GetUtfString", GetUtfString),
		new LuaMethod("GetClass", GetClass),
		new LuaMethod("IsNull", IsNull),
		new LuaMethod("NewFromBinaryData", NewFromBinaryData),
		new LuaMethod("NewFromObject", NewFromObject),
		new LuaMethod("NewInstance", NewInstance),
		new LuaMethod("Put", Put),
		new LuaMethod("PutBool", PutBool),
		new LuaMethod("PutByte", PutByte),
		new LuaMethod("PutByteArray", PutByteArray),
		new LuaMethod("PutDouble", PutDouble),
		new LuaMethod("PutFloat", PutFloat),
		new LuaMethod("PutInt", PutInt),
		new LuaMethod("PutLong", PutLong),
		new LuaMethod("PutNull", PutNull),
		new LuaMethod("PutMPArray", PutMPArray),
		new LuaMethod("PutMPObject", PutMPObject),
		new LuaMethod("PutShort", PutShort),
		new LuaMethod("PutUtfString", PutUtfString),
		new LuaMethod("PutClass", PutClass),
		new LuaMethod("RemoveElement", RemoveElement),
		new LuaMethod("Size", Size),
		new LuaMethod("ToBinary", ToBinary),
		new LuaMethod("ToLuaTable", ToLuaTable),
		new LuaMethod("get_Item", get_Item),
		new LuaMethod("set_Item", set_Item),
		new LuaMethod("New", _CreateMPObject),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMPObject(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			MPObject obj = new MPObject();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MPObject.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(MPObject));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "com.gt.entities.MPObject", typeof(MPObject), regs, fields, typeof(System.Object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ContainsKey(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = obj.ContainsKey(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBool(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = obj.GetBool(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetByte(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		byte o = obj.GetByte(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetByteArray(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		com.gt.units.ByteArray o = obj.GetByteArray(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		com.gt.entities.MPDataWrapper o = obj.GetData(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDouble(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		double o = obj.GetDouble(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFloat(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		float o = obj.GetFloat(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInt(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int o = obj.GetInt(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeys(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string[] o = obj.GetKeys();
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLong(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		long o = obj.GetLong(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMPArray(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		com.gt.entities.IMPArray o = obj.GetMPArray(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMPObject(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		com.gt.entities.IMPObject o = obj.GetMPObject(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetShort(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		short o = obj.GetShort(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetUtfString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		string o = obj.GetUtfString(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClass(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		object o = obj.GetClass(arg0);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsNull(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = obj.IsNull(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int NewFromBinaryData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		com.gt.units.ByteArray arg0 = LuaScriptMgr.GetNetObject<com.gt.units.ByteArray>(L, 1);
		com.gt.entities.MPObject o = MPObject.NewFromBinaryData(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int NewFromObject(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 1);
		com.gt.entities.MPObject o = MPObject.NewFromObject(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int NewInstance(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		com.gt.entities.MPObject o = MPObject.NewInstance();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Put(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		com.gt.entities.MPDataWrapper arg1 = LuaScriptMgr.GetNetObject<com.gt.entities.MPDataWrapper>(L, 3);
		obj.Put(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PutBool(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
		obj.PutBool(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PutByte(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		byte arg1 = (byte)LuaScriptMgr.GetNumber(L, 3);
		obj.PutByte(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PutByteArray(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		com.gt.units.ByteArray arg1 = LuaScriptMgr.GetNetObject<com.gt.units.ByteArray>(L, 3);
		obj.PutByteArray(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PutDouble(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		double arg1 = (double)LuaScriptMgr.GetNumber(L, 3);
		obj.PutDouble(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PutFloat(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		obj.PutFloat(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PutInt(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.PutInt(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PutLong(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		long arg1 = (long)LuaScriptMgr.GetNumber(L, 3);
		obj.PutLong(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PutNull(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.PutNull(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PutMPArray(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		com.gt.entities.IMPArray arg1 = LuaScriptMgr.GetNetObject<com.gt.entities.IMPArray>(L, 3);
		obj.PutMPArray(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PutMPObject(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		com.gt.entities.IMPObject arg1 = LuaScriptMgr.GetNetObject<com.gt.entities.IMPObject>(L, 3);
		obj.PutMPObject(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PutShort(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		short arg1 = (short)LuaScriptMgr.GetNumber(L, 3);
		obj.PutShort(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PutUtfString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		obj.PutUtfString(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PutClass(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		object arg1 = LuaScriptMgr.GetVarObject(L, 3);
		obj.PutClass(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveElement(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.RemoveElement(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Size(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		int o = obj.Size();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToBinary(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		com.gt.units.ByteArray o = obj.ToBinary();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToLuaTable(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		LuaInterface.LuaTable o = obj.ToLuaTable();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Item(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		object o = obj[arg0];
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Item(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MPObject obj = LuaScriptMgr.GetNetObject<MPObject>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		object arg1 = LuaScriptMgr.GetVarObject(L, 3);
		obj[arg0] = arg1;
		return 0;
	}
}

