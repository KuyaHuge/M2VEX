using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventLogManager : MonoBehaviour
{
    public static EventLogManager Instance;


    [Header("UI References")]
    public Transform logContent;
    public GameObject logEntryPrefab;

    [Header("Settings")]
    public int maxMessages = 10;

    private void Awake()
    {
        Instance = this;
    }

    public void AddLog(string message)
    {
        GameObject entry = Instantiate(logEntryPrefab, logContent);
        TMP_Text entryText = entry.GetComponent<TMP_Text>();
        entryText.text = message;

        if (logContent.childCount > maxMessages)
        {
            Destroy(logContent.GetChild(0).gameObject);
        }
    }
}
