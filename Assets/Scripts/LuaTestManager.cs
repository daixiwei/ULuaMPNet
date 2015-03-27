using UnityEngine;
using System.Collections;
using com.platform.unity;
using LuaInterface;
using com.gt.entities;
using com.gt.mpnet;
using com.gt.mpnet.core;
using com.gt.events;
using com.gt;
using com.gt.mpnet.requests;
using System.Collections.Generic;



public class LuaTestManager : UnityGameManager
{



    protected override void Init()
    {
        LuaHelper.UIRoot = (GameObject.Find("UI Root") as GameObject).transform;
        LuaHelper.NewLoadPanel();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        LuaScriptMgr umgr = new LuaScriptMgr();
        umgr.Start();
        umgr.DoFile("game");
        
        //StartCoroutine(InitAss());
        umgr.CallLuaFunction("GameManager.OnInit");

    }

    //public IEnumerator InitAss()
    //{
    //    GTLib.AssetManager.LoadAsset("Prefabs/Message/MessagePanel");
    //    GTLib.AssetManager.LoadAsset("Prefabs/Prompt/PromptItem");
    //    GTLib.AssetManager.LoadAsset("Prefabs/Prompt/PromptPanel");

    //    GTLib.AssetManager.BeginLoadEntity();
    //    while (!GTLib.AssetManager.IsComplete)
    //    {
    //        yield return null;
    //    }
    //    LuaScriptMgr.Instance.CallLuaFunction("GameManager.InitAssets");
    //}

    void LateUpdate()
    {
        LuaScriptMgr.Instance.LateUpate();
    }

    void Update()
    {
        LuaScriptMgr.Instance.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        //LuaScriptMgr.Instance.FixedUpdate();
    }

    protected override void OnApplicationQuit()
    {
        base.OnApplicationQuit();
        LuaScriptMgr.Instance.Destroy();
    }
}


/// <summary>
/// 
/// </summary>
public class LuaMessageTransmitter : MessageTransmitter
{
    private string luaclass;

    public LuaMessageTransmitter(int id, string luaclass)
        : base(id)
    {

        this.luaclass = luaclass;
        //LuaTestManager.uluaMgr.DoFile(luaclass);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="method"></param>
    /// <param name="args"></param>
    public void Call(string method, params object[] args)
    {
        LuaScriptMgr.Instance.CallLuaFunction(luaclass + "." + method, args);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ip"></param>
    /// <param name="port"></param>
    public void Connect(string ip, int port)
    {
        MPNetClient mpnet = new MPNetClient(m_PrefabConnecterId);
        GTLib.NetManager.AddMPNetClient(mpnet);

        mpnet.Connect(ip, port);
        mpnet.AddEventListener(MPEvent.CONNECTION, delegate(BaseEvent evt)
        {
            IMPObject par = evt.Params;
            if ((bool)par["success"])
            {
                IMPObject mpo = MPObject.NewInstance();
                mpo["test1"] = 22;
                mpo["test2"] = 22;
                mpo["test3"] = 33;
                LuaTable table = mpo.ToLuaTable();
                GTLib.NetManager.DispatchLuaEvent("conn1", table);
            }
            else
            {
                GTLib.NetManager.KillConnection(m_PrefabConnecterId);
                GTLib.NetManager.DispatchLuaEvent("lost1", null);
            }
        });
        mpnet.AddEventListener(MPEvent.CONNECTION_LOST, delegate(BaseEvent evt)
        {
            GTLib.NetManager.KillConnection(m_PrefabConnecterId);
            GTLib.NetManager.DispatchLuaEvent("lost1", null);
        });




    }

    public void Login(string username, string passwd)
    {
        Send(new LoginRequest(username, passwd));
        mpnet.AddEventListener(MPEvent.LOGIN, delegate(BaseEvent evt)
        {
            //mpnet.InitUDP(mpnet.CurrentIp, mpnet.CurrentPort);
            GTLib.NetManager.DispatchLuaEvent("login1", null);
        });
        mpnet.AddEventListener(MPEvent.LOGIN_ERROR, delegate(BaseEvent evt)
        {
            GTLib.NetManager.DispatchLuaEvent("le1", null);
        });
    }

    //public void SendMessage(string cmd)
    //{
    //    SendExtensionRequest(cmd);
    //}

    //public void SendMessage(string cmd, MPObject table)
    //{
    //    SendExtensionRequest(cmd, table);
    //}

    //public void SendMessage(string cmd, MPObject table, bool isUdp)
    //{
    //    SendExtensionRequest(cmd, table,isUdp);
    //}
    //public void SendMessage(string cmd,LuaTable table)
    //{
    //    SendMessage(cmd, table, false);
    //}

    //public void SendMessage(string cmd, LuaTable table, bool isUdp)
    //{
    //    IMPObject mpo = MPObject.NewInstance();
    //    foreach (string key in table.Keys)
    //    {
    //        LuaTable wrapp = table[key] as LuaTable;
    //        MPDataType type = (MPDataType)((int)wrapp[0]);
    //        switch (type)
    //        {
    //            case MPDataType.BOOL:
    //                mpo.PutBool(key, (bool)wrapp[1]);
    //                break;
    //            case MPDataType.BYTE:
    //                mpo.PutByte(key, (byte)wrapp[1]);
    //                break;
    //            case MPDataType.SHORT:
    //                mpo.PutShort(key, (short)wrapp[1]);
    //                break;
    //            case MPDataType.INT:
    //                mpo.PutInt(key, (int)wrapp[1]);
    //                break;
    //            case MPDataType.LONG:
    //                mpo.PutLong(key, (long)wrapp[1]);
    //                break;
    //            case MPDataType.FLOAT:
    //                mpo.PutFloat(key, (float)wrapp[1]);
    //                break;
    //            case MPDataType.DOUBLE:
    //                mpo.PutDouble(key, (double)wrapp[1]);
    //                break;
    //            case MPDataType.UTF_STRING:
    //                mpo.PutUtfString(key, (string)wrapp[1]);
    //                break;
    //        }
    //    }
    //    SendExtensionRequest(cmd, mpo,isUdp);
    //}
}

