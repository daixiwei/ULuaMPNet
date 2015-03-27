using UnityEngine;
using System.Collections;
using LuaInterface;

public class BaseLua : MonoBehaviour
{

    public LuaTable LuaView;
    private Transform trans = null;
    private Hashtable buttons = new Hashtable();
    void Awake()
    {
        trans = gameObject.transform;
    }

	// Use this for initialization
	void Start () {
        
       // LuaView.RawGetFunc("Start").Call();
	}

    void Destroy()
    {
        LuaView.RawGetFunc("Destroy").Call();
    }

    protected void OnClickEvent(GameObject go)
    {
        LuaView.RawGetFunc("OnClick").Call();
    }

    /// <summary>
    /// 添加单击事件
    /// </summary>
    public void AddClick(string button)
    {
        Transform to = trans.Find(button);
        if (to == null) return;
        GameObject go = to.gameObject;
        buttons.Add(button, go);
        UIEventListener.Get(go).onClick += OnClickEvent;
    }

    /// <summary>
    /// 移除单击事件
    /// </summary>
    public void RemoveClick(string button)
    {
        object o = buttons[button];
        if (o == null) return;
        GameObject go = o as GameObject;
        UIEventListener.Get(go).onClick -= OnClickEvent;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
