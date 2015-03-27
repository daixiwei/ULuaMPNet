/*************************************************
author：ricky pu
data：2014.4.12
email:32145628@qq.com
**********************************************/
using UnityEngine;
using System.Collections.Generic;
using System.Reflection;
using LuaInterface;
using System;
using com.gt.events;
using com.gt;
using com.gt.assets;

public static class LuaHelper {
    /// <summary>
    /// 
    /// </summary>
    public static Transform UIRoot;
    /// <summary>
    /// 
    /// </summary>
    private static GameObject LoadPanel;
    private static UISlider loadPanelSlider;
    public static float LoadPanelSlider
    {
        get
        {
            return loadPanelSlider.value;
        }
        set
        {
            loadPanelSlider.value = value;
        }
    }
    /// <summary>
    /// getType
    /// </summary>
    /// <param name="classname"></param>
    /// <returns></returns>
    public static System.Type GetType(string classname) {
        Assembly assb = Assembly.GetExecutingAssembly();  //.GetExecutingAssembly();
        System.Type t = null;
        t = assb.GetType(classname); ;
        if (t == null) {
            t = assb.GetType(classname);
        }
        return t;
    }

    /// <summary>
    /// GetComponentInChildren
    /// </summary>
    public static Component GetComponentInChildren(GameObject obj, string classname) {
        System.Type t = GetType(classname);
        Component comp = null;
        if (t != null && obj != null) comp = obj.GetComponentInChildren(t);
        return comp;
    }

    /// <summary>
    /// GetComponent
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="classname"></param>
    /// <returns></returns>
    public static Component GetComponent(GameObject obj, string classname) {
        if (obj == null) return null; 
        return obj.GetComponent(classname);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="classname"></param>
    /// <returns></returns>
    public static Component[] GetComponentsInChildren(GameObject obj, string classname) {
        System.Type t = GetType(classname);
        if (t != null && obj != null) return obj.transform.GetComponentsInChildren(t);
        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="bundleName"></param>
    /// <param name="asset"></param>
    /// <returns></returns>
    public static GameObject NewPanel(Transform parent,string bundleName)
    {
        IAssetBundle bundle = GTLib.AssetManager.GetAsset("Prefabs/" + bundleName);
        GameObject prefabs = bundle.MainAsset<GameObject>();
        if (prefabs != null)
        {
            GameObject go = GameObject.Instantiate(prefabs) as GameObject;
            go.transform.parent = parent;
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.zero;
            AnimationCurve animationCurve = new AnimationCurve(new Keyframe(0f, 0f, 0f, 1.7f), new Keyframe(0.6f, 1.5f, 1.7f, 0f), new Keyframe(1f, 1f, 0f, 0f));
            TweenScale ts =TweenScale.Begin(go, 0.3f, Vector3.one);
            ts.animationCurve = animationCurve;
            return go;
        }
        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static GameObject NewLoadPanel()
    {
        if (LoadPanel != null) return LoadPanel;
        LoadPanel = GameObject.Instantiate(Resources.Load("LoadPanel")) as GameObject;
        LoadPanel.transform.parent = UIRoot;
        LoadPanel.transform.localPosition = Vector3.zero;
        LoadPanel.transform.localScale = Vector3.one;
        loadPanelSlider = LoadPanel.transform.Find("Slider").GetComponent<UISlider>();
        loadPanelSlider.value = 0;
        return LoadPanel;
    }

    /// <summary>
    /// 
    /// </summary>
    public static void CloseLoadPanel()
    {
        if (LoadPanel != null)
        {
            GameObject.Destroy(LoadPanel);
            LoadPanel = null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static Transform[] GetAllChild(GameObject obj) {
        Transform[] child = null;
        int count = obj.transform.childCount;
        child = new Transform[count];
        for (int i = 0; i < count; i++) {
            child[i] = obj.transform.GetChild(i);
        }
        return child;
    }


    public static Action Action(LuaFunction func) {
        Action action = () => {
            func.Call();
        };
        return action;
    }

    public static UIEventListener.VoidDelegate VoidDelegate(LuaFunction func) {
        UIEventListener.VoidDelegate action = (go) => {
            func.Call(go);
        };
        return action;
    }


}