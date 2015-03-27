﻿namespace com.gt.entities
{
    using com.gt.units;
    using LuaInterface;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public class MPObject : IMPObject
    {
        private Dictionary<string, MPDataWrapper> dataHolder = new Dictionary<string, MPDataWrapper>();
       
        public bool ContainsKey(string key)
        {
            return dataHolder.ContainsKey(key);
        }

        private ICollection GetArray(string key)
        {
            return GetValue<ICollection>(key);
        }

        public bool GetBool(string key)
        {
            return GetValue<bool>(key);
        }

        public byte GetByte(string key)
        {
            return GetValue<byte>(key);
        }

        public ByteArray GetByteArray(string key)
        {
            return GetValue<ByteArray>(key);
        }

        public MPDataWrapper GetData(string key)
        {
            return dataHolder[key];
        }

        public double GetDouble(string key)
        {
            return GetValue<double>(key);
        }

        public float GetFloat(string key)
        {
            return GetValue<float>(key);
        }

        public int GetInt(string key)
        {
            return GetValue<int>(key);
        }

        public string[] GetKeys()
        {
            string[] array = new string[dataHolder.Keys.Count];
            dataHolder.Keys.CopyTo(array, 0);
            return array;
        }

        public long GetLong(string key)
        {
            return GetValue<long>(key);
        }


        public IMPArray GetMPArray(string key)
        {
            return GetValue<IMPArray>(key);
        }

        public IMPObject GetMPObject(string key)
        {
            return GetValue<IMPObject>(key);
        }

        public short GetShort(string key)
        {
            return GetValue<short>(key);
        }

        public string GetUtfString(string key)
        {
            return GetValue<string>(key);
        }

        public object GetClass(string key)
        {
            return GetValue<object>(key);
        }

        public T GetValue<T>(string key)
        {
            if (!dataHolder.ContainsKey(key))
            {
                return default(T);
            }
            return (T) dataHolder[key].Data;
        }

        public bool IsNull(string key)
        {
            return (!ContainsKey(key) || (GetData(key).Data == null));
        }

        public static MPObject NewFromBinaryData(ByteArray ba)
        {
            return MPDataSerializer.Instance.Binary2Object(ba) as MPObject;
        }

        public static MPObject NewFromObject(object o)
        {
            throw new NotImplementedException();
        }

        public static MPObject NewInstance()
        {
            return new MPObject();
        }

        public void Put(string key, MPDataWrapper val)
        {
            dataHolder[key] = val;
        }

        public void PutBool(string key, bool val)
        {
            dataHolder[key] = new MPDataWrapper(MPDataType.BOOL, val);
        }


        public void PutByte(string key, byte val)
        {
            dataHolder[key] = new MPDataWrapper(MPDataType.BYTE, val);
        }

        public void PutByteArray(string key, ByteArray val)
        {
            dataHolder[key] = new MPDataWrapper(MPDataType.BYTE_ARRAY, val);
        }


        public void PutDouble(string key, double val)
        {
            dataHolder[key] = new MPDataWrapper(MPDataType.DOUBLE, val);
        }

        public void PutFloat(string key, float val)
        {
            dataHolder[key] = new MPDataWrapper(MPDataType.FLOAT, val);
        }

        public void PutInt(string key, int val)
        {
            dataHolder[key] = new MPDataWrapper(MPDataType.INT, val);
        }

        public void PutLong(string key, long val)
        {
            dataHolder[key] = new MPDataWrapper(MPDataType.LONG, val);
        }

        public void PutNull(string key)
        {
            dataHolder[key] = new MPDataWrapper(MPDataType.NULL, null);
        }

        public void PutMPArray(string key, IMPArray val)
        {
            dataHolder[key] = new MPDataWrapper(MPDataType.MP_ARRAY, val);
        }

        public void PutMPObject(string key, IMPObject val)
        {
            dataHolder[key] = new MPDataWrapper(MPDataType.MP_OBJECT, val);
        }

        public void PutShort(string key, short val)
        {
            dataHolder[key] = new MPDataWrapper(MPDataType.SHORT, val);
        }

        public void PutUtfString(string key, string val)
        {
            dataHolder[key] = new MPDataWrapper(MPDataType.UTF_STRING, val);
        }

        public void PutClass(string key, Object val)
        {
            dataHolder[key] = new MPDataWrapper(MPDataType.CLASS, val);
        }

        public void RemoveElement(string key)
        {
            dataHolder.Remove(key);
        }

        public int Size()
        {
            return dataHolder.Count;
        }

        public ByteArray ToBinary()
        {
            return MPDataSerializer.Instance.Object2Binary(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public LuaTable ToLuaTable()
        {
            object[] tem = LuaScriptMgr.Instance.CallLuaFunction("Map.New");
            LuaTable table = tem[0] as LuaTable;
            string[] keys = GetKeys();
            foreach (string key in keys)
            {
                MPDataWrapper wrapp = GetData(key);
                switch (((MPDataType)wrapp.Type))
                {
                    case MPDataType.NULL:
                        break;
                    case MPDataType.BOOL:
                    case MPDataType.BYTE:
                    case MPDataType.SHORT:
                    case MPDataType.INT:
                    case MPDataType.LONG:
                    case MPDataType.FLOAT:
                    case MPDataType.DOUBLE:
                    case MPDataType.UTF_STRING:
                        table[key] = wrapp.Data;
                        break;
                    case MPDataType.MP_OBJECT:
                        table[key] = ((IMPObject)wrapp.Data).ToLuaTable();
                        break;
                }
            }
            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get
            {
                if (!dataHolder.ContainsKey(key))
                {
                    return null;
                }
                return dataHolder[key].Data; 
            }
            set
            {
                if (value == null)
                {
                    dataHolder[key] = new MPDataWrapper(MPDataType.NULL, value);
                }
                else if (value is bool)
                {
                    dataHolder[key] = new MPDataWrapper(MPDataType.BOOL, value);
                }
                else if (value is int)
                {
                    dataHolder[key] = new MPDataWrapper(MPDataType.INT, value);
                }
                else if (value is byte)
                {
                    dataHolder[key] = new MPDataWrapper(MPDataType.BYTE, value);
                }
                else if (value is short)
                {
                    dataHolder[key] = new MPDataWrapper(MPDataType.SHORT, value);
                }
                else if (value is string)
                {
                    dataHolder[key] = new MPDataWrapper(MPDataType.UTF_STRING, value);
                }
                else if (value is long)
                {
                    dataHolder[key] = new MPDataWrapper(MPDataType.LONG, value);
                }
                else if (value is float)
                {
                    dataHolder[key] = new MPDataWrapper(MPDataType.FLOAT, value);
                }
                else if (value is double)
                {
                    dataHolder[key] = new MPDataWrapper(MPDataType.DOUBLE, value);
                }
                else if (value is IMPObject)
                {
                    dataHolder[key] = new MPDataWrapper(MPDataType.MP_OBJECT, value);
                }
                else if (value is IMPArray)
                {
                    dataHolder[key] = new MPDataWrapper(MPDataType.MP_ARRAY, value);
                }
                else if (value is MPSerializable)
                {
                    dataHolder[key] = new MPDataWrapper(MPDataType.CLASS, value);
                }
                else
                {
                    throw new ArgumentException("Unknown data type : " + value.GetType());
                }
            }
        }


        
    }
}

