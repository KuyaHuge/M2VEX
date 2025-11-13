using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F1C001 : MonoBehaviour
{
    [Header("References")]
    public TravelManager TravelManager;
    public EventLogs eventlogs;
    public GameObject[] Buttons;

    [Header("Settings")]
    public int TravelNumber;
    public string message;

    private void OnEnable()
    {
       StartCoroutine(ActivateEventLog());
      TravelManager.ActivateOnlyOneArea(TravelNumber);
      TravelManager.ActivateIdleArea(TravelNumber);


        foreach (GameObject button in Buttons) {

            if (button != null)
            {
                button.SetActive(true);
            }

        }
    }

    IEnumerator ActivateEventLog()
    {
        yield return new WaitForSeconds(0.25f);
        eventlogs.AddAnotherEventLog("<color=#00FF00>Arrived at</color> " + "[" + message + "]"); 
    }
}
