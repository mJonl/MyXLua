using UnityEngine;
using System.Collections.Generic;

public delegate void EventCallback(object param);

/// <summary>
/// 保存在列表中的事件数据结构
/// </summary>
class EventHandler
{
    public int Priority { get; set; }
    public EventCallback Callback { get; set; }
    public object Observer { set; get; }
}

/// <summary>
/// 事件排序类
/// </summary>
class EventHandlerCompairer : IComparer<EventHandler>
{
    public int Compare(EventHandler x, EventHandler y) {
        int result;
        try {
            if (x.Priority > y.Priority) {
                result = 0;
            } else {
                result = 1;
            }
            return result;
        } catch (System.Exception ex) {
            throw ex;
        }
    }
}

/// <summary>
/// 事件管理器
/// </summary>
public class EventMgr
{
    private static EventMgr instance = new EventMgr();
    private Dictionary<string, List<EventHandler>> dicHandler;
    private EventHandlerCompairer compairer;

    private EventMgr()
    {
        dicHandler = new Dictionary<string, List<EventHandler>>();
        compairer = new EventHandlerCompairer();
    }


    /// 注册事件监听
    /// <param name="type">消息名</param>
    /// <param name="observer">观察者</param>
    /// <param name="callback">回调函数</param>
    /// <param name="priority">权重</param>
    public static void AddEventListener(string type, object observer, EventCallback callback, int priority = 1)
    {
        if (!instance.dicHandler.ContainsKey(type))
        {
            instance.dicHandler.Add(type, new List<EventHandler>());
        }
        EventHandler handler = new EventHandler
        {
            Priority = priority,
            Callback = callback,
            Observer = observer
        };
        instance.dicHandler[type].Add(handler);
        instance.dicHandler[type].Sort(instance.compairer);
    }

    /// <summary>
    /// 派发事件
    /// </summary>
    /// <param name="type">事件类型</param>
    /// <param name="data">事件传达的数据</param>
    public static void DispachEvent(string type, object data = null)
    {
        if (!instance.dicHandler.ContainsKey(type))
        {
            //Debug.LogWarning("Did not add any callback of " + type + " in EventMgr!");
            return;
        }

        List<EventHandler> list = instance.dicHandler[type];
        for (int i = 0; i < list.Count; i++)
        {
            list[i].Callback(data);
        }
    }

    /// <summary>
    /// 移除某个类的某个监听
    /// </summary>
    /// <param name="type">消息名</param>
    /// <param name="observer">观察者</param>
    public static void RemoveEventByNameObserver(string type, object observer)
    {
        if (instance.dicHandler.ContainsKey(type))
        {
            EventHandler handler = instance.dicHandler[type].Find(c => c.Observer == observer);
            instance.dicHandler[type].Remove(handler);
        }
    }

    /// <summary>
    /// 移除对某消息的所有监听
    /// </summary>
    /// <param name="type">消息名</param>
    /// <param name="observer">观察者</param>
    public static void RemoveEventByName(string type, object observer)
    {
        if (instance.dicHandler.ContainsKey(type))
        {
            instance.dicHandler.Remove(type);
        }
    }

    /// <summary>
    /// 移除某个类的所有监听
    /// </summary>
    /// <param name="type">消息名</param>
    /// <param name="observer">观察者</param>
    public static void RemoveEventByObserver(object observer)
    {
        foreach(KeyValuePair<string, List<EventHandler>> eventData in instance.dicHandler)
        {
            RemoveEventByNameObserver(eventData.Key, observer);
        }
    }
}