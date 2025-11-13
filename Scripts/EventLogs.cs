using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLogs : MonoBehaviour
{
    public static EventLogs instance;
    public string message;


    private void Awake()
    {
        instance = this;
    }

    public void AddEventLog()
    {
        EventLogManager.Instance.AddLog("<color=#00FF00>Moving to</color> " + "[" + message + "]");
    }

    public void AddAnotherEventLog(string type)
    {
        EventLogManager.Instance.AddLog(type);
    }

    public void AddReturnEventLog()
    {
        EventLogManager.Instance.AddLog("<color=#00FF00>Returning to</color> " + "[" + message + "]");
    }

    public void IncreaseSatisfaction(int amount)
    {
        EventLogManager.Instance.AddLog("<color=#00FF00>You Won the Game! Satisfaction increased</color>" + "[+" + amount + "]");
        EventLogManager.Instance.AddLog("Facility Unlocked");
    }
    public void DecreaseSatisfaction(int amount)
    {
        EventLogManager.Instance.AddLog("<color=#00FF00>You Lost the Game! Satisfaction decreased</color>" + "[-" + amount + "]");
        EventLogManager.Instance.AddLog("Facility Unlocked");
    }

}
