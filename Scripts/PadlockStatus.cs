using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadlockStatus : MonoBehaviour
{
    public static List<PadlockStatus> allPadlocks = new List<PadlockStatus>();
    public static PadlockStatus instance;

    public GameObject padlock;
    public GameObject EnterButton;
    public Transform spawnParent;

    public new string name;
    public bool locked;

    private void OnEnable()
    {
        allPadlocks.Add(this);
        if (GlobalManager.instance != null)
        {
            GlobalManager.instance.Padlock(name, locked);
            locked = GlobalManager.instance.GetPadlockState(name, locked);
        }
    }

    private void OnDisable()
    {
        allPadlocks.Remove(this);
    }

    private void Update()
    {
        if (locked == false)
        {
            if (EnterButton != null)
                EnterButton.SetActive(true);
        }
        else
        {
            if (EnterButton != null)
                EnterButton.SetActive(false);
        }
    }

    public void AddPadlock()
    {
        foreach (Transform child in spawnParent)
        {
            if (child.CompareTag("Padlock"))
            {
                Debug.Log("Padlock already exists. Not instantiating.");
                locked = true;
                return;
            }
        }

        GameObject newPadlock = Instantiate(padlock, spawnParent);

        if (!newPadlock.CompareTag("Padlock"))
        {
            newPadlock.tag = "Padlock";
        }

        locked = true;

        if (GlobalManager.instance != null)
        {
            GlobalManager.instance.Padlock(name, true);
        }
    }

    public void RemovePadlock()
    {
        foreach (Transform child in spawnParent)
        {
            if (child.CompareTag("Padlock"))
            {
                Destroy(child.gameObject);
                locked = false;

                if (EnterButton != null)
                {
                    EnterButton.SetActive(true);
                }

                if (GlobalManager.instance != null)
                {
                    GlobalManager.instance.Padlock(name, false);
                }

                return;
            }
        }
        Debug.Log("No padlock found to remove.");
    }

    public void DestroyPadlock()
    {
        foreach (Transform child in spawnParent)
        {
            if (child.CompareTag("Padlock"))
            {
                Destroy(child.gameObject);
                return;
            }
        }
        Debug.Log("No padlock found to destroy");
    }

    public void SetLocked(bool state)
    {
        locked = state;
        if (GlobalManager.instance != null)
        {
            GlobalManager.instance.Padlock(name, state);
        }
    }

}
