using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager instance;

    private Dictionary<string, bool> padlockStates = new Dictionary<string, bool>();



    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Padlock(string name, bool locked)
    {
        // Update the state in the dictionary
        padlockStates[name] = locked;

        // Apply the state to all matching padlock instances
        foreach (var padlockStatus in PadlockStatus.allPadlocks)
        {
            if (padlockStatus.name == name)
            {
                // Set the locked state directly without triggering the Add/Remove methods
                padlockStatus.locked = locked;

                // Handle the visual state change directly
                if (locked)
                {
                    // Add padlock visually if not already present
                    bool hasExistingPadlock = false;
                    foreach (Transform child in padlockStatus.spawnParent)
                    {
                        if (child.CompareTag("Padlock"))
                        {
                            hasExistingPadlock = true;
                            break;
                        }
                    }

                    if (!hasExistingPadlock)
                    {
                        GameObject newPadlock = Instantiate(padlockStatus.padlock, padlockStatus.spawnParent);
                        if (!newPadlock.CompareTag("Padlock"))
                        {
                            newPadlock.tag = "Padlock";
                        }
                    }
                }
                else
                {
                    // Remove padlock visually
                    foreach (Transform child in padlockStatus.spawnParent)
                    {
                        if (child.CompareTag("Padlock"))
                        {
                            Destroy(child.gameObject);
                            break;
                        }
                    }

                    if (padlockStatus.EnterButton != null)
                    {
                        padlockStatus.EnterButton.SetActive(true);
                    }
                }
            }
        }
    }

    public bool GetPadlockState(string name, bool defaultValue)
    {
        if (padlockStates.TryGetValue(name, out bool state))
        {
            return state;
        }
        return defaultValue;
    }
}
