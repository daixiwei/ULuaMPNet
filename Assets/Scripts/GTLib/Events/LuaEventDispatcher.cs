using System.Collections;
using LuaInterface;
using System;
using System.Collections.Generic;

namespace com.gt.events
{

    

    /// <summary>
    /// 
    /// </summary>
    public struct LuaEvent
    {
        public string eventType;
        public LuaTable arguments;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="arguments"></param>
        public LuaEvent(string eventType, LuaTable arguments)
        {
            this.eventType = eventType;
            this.arguments = arguments;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class LuaEventDispatcher
    {

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, List<LuaFunction>> listeners = new Dictionary<string, List<LuaFunction>>();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public LuaEventDispatcher()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="listener"></param>
        public void AddEventListener(string eventType, LuaFunction listener)
        {
            if (!listeners.ContainsKey(eventType))
            {
                listeners.Add(eventType, new List<LuaFunction>());
            }
            List<LuaFunction> list = listeners[eventType];
            list.Add(listener);
            //LuaEventListenerDelegate a = listeners[eventType] as LuaEventListenerDelegate;
            //a = (LuaEventListenerDelegate)Delegate.Combine(a, listener);
            listeners[eventType] = list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evt"></param>
        public void DispatchEvent(string eventType, LuaTable evt)
        {
            if (listeners.ContainsKey(eventType))
            {
                List<LuaFunction> list = listeners[eventType];
                foreach (LuaFunction fun in list)
                {
                    fun.Call(evt);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemoveAll()
        {
            listeners.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="listener"></param>
        public void RemoveEventListener(string eventType, LuaFunction listener)
        {
            if (listeners.ContainsKey(eventType))
            {
                List<LuaFunction> list = listeners[eventType];
                list.Remove(listener);
                if (list.Count <= 0)
                {
                    listeners.Remove(eventType);
                }
            }
            //LuaEventListenerDelegate source = listeners[eventType] as LuaEventListenerDelegate;
            //if (source != null)
            //{
            //    source = (LuaEventListenerDelegate)Delegate.Remove(source, listener);
            //}
            //listeners[eventType] = source;
        }
    }
}