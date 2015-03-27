using com.gt.entities;
using com.gt.events;
using com.gt.units;
using System;
using System.Collections.Generic;


namespace com.gt.mpnet
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="parameters"></param>
    public delegate void ExtensionMessageDelegate(IMPObject parameters);

    /// <summary>
    /// 
    /// </summary>
    public class MessageHandler
    {
        //protected MPNetClient mpnet;
        /// <summary>
        /// 
        /// </summary>
        protected Logger Log;
        /// <summary>
        /// 
        /// </summary>
        protected int m_PrefabConnecterId;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netmp"></param>
        protected MessageHandler(int prefabConnecterId)
        {
            Log = new Logger(GetType());
            this.m_PrefabConnecterId = prefabConnecterId;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="evt"></param>
        protected void DispatchEvent(BaseEvent evt)
        {
            //if (mpnet == null)
            //{
            //    throw new ArgumentNullException("MPNetClient is null!");
            //}
            GTLib.NetManager.DispatchEvent(evt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="messageHandler"></param>
        protected void RegisterMessageHandler(string cmd, ExtensionMessageDelegate messageHandler)
        {
            ((MPNetManager)GTLib.NetManager).AddMessageHandler(m_PrefabConnecterId, cmd, messageHandler);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="messageHandler"></param>
        protected void UnRegisterMessageHandler(string cmd, ExtensionMessageDelegate messageHandler)
        {
            ((MPNetManager)GTLib.NetManager).RemoveMessageHandler(m_PrefabConnecterId, cmd, messageHandler);
        }

        /// <summary>
        /// 
        /// </summary>
        public int PrefabConnecterId
        {
            get
            {
                return m_PrefabConnecterId;
            }
        }
    }
}
