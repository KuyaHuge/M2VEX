using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPadlock : MonoBehaviour
{
    [Header("Debug")]
    public bool debugMode = false;

    public void FindPadlock()
    {
        if (debugMode)
            Debug.Log("FindPadlock called - searching for padlocks to destroy");

        DestroyAllPadlocks();
    }

    public void DestroyAllPadlocks()
    {
        // Find all GameObjects with "Padlock" tag
        GameObject[] padlocks = GameObject.FindGameObjectsWithTag("Padlock");

        if (debugMode)
            Debug.Log($"Found {padlocks.Length} padlock(s) to destroy");

        foreach (GameObject padlock in padlocks)
        {
            if (debugMode)
                Debug.Log($"Destroying padlock: {padlock.name}");

            Destroy(padlock);
        }

        // Also update all PadlockStatus components to reflect the removal
        UpdatePadlockStatuses();
    }

    private void UpdatePadlockStatuses()
    {
        // Update all active PadlockStatus components
        PadlockStatus[] allPadlockStatuses = FindObjectsOfType<PadlockStatus>();

        foreach (PadlockStatus padlockStatus in allPadlockStatuses)
        {
            // Check if this padlock status still has padlock children
            bool hasPadlock = false;
            foreach (Transform child in padlockStatus.spawnParent)
            {
                if (child.CompareTag("Padlock"))
                {
                    hasPadlock = true;
                    break;
                }
            }

            // If no padlock found, update the status
            if (!hasPadlock)
            {
                padlockStatus.locked = false;
                if (padlockStatus.EnterButton != null)
                {
                    padlockStatus.EnterButton.SetActive(true);
                }

                if (debugMode)
                    Debug.Log($"Updated PadlockStatus for: {padlockStatus.name}");
            }
        }
    }

    // Alternative method for specific padlock removal by name
    public void DestroyPadlockByName(string padlockName)
    {
        if (debugMode)
            Debug.Log($"Searching for padlock with name: {padlockName}");

        foreach (PadlockStatus padlockStatus in PadlockStatus.allPadlocks)
        {
            if (padlockStatus.name == padlockName)
            {
                // Use the correct method name from PadlockStatus
                padlockStatus.DestroyPadlock();
                padlockStatus.locked = false;

                if (padlockStatus.EnterButton != null)
                {
                    padlockStatus.EnterButton.SetActive(true);
                }

                if (debugMode)
                    Debug.Log($"Destroyed padlock for: {padlockName}");

                break;
            }
        }
    }

    // Method to clean up padlocks when exiting facilities
    public void CleanupOnReturn()
    {
        if (debugMode)
            Debug.Log("Cleaning up padlocks on return");

        // Destroy any remaining padlock GameObjects
        DestroyAllPadlocks();

        // Reset any PadlockStatus that should be unlocked
        ResetUnlockedFacilities();
    }

    private void ResetUnlockedFacilities()
    {
        // This method can be customized based on your game logic
        // For now, it ensures that non-locked facilities don't have padlocks

        foreach (PadlockStatus padlockStatus in PadlockStatus.allPadlocks)
        {
            // Check global manager state
            bool shouldBeLocked = GlobalManager.instance.GetPadlockState(padlockStatus.name, padlockStatus.locked);

            if (!shouldBeLocked && padlockStatus.locked)
            {
                padlockStatus.DestroyPadlock();
                padlockStatus.locked = false;

                if (padlockStatus.EnterButton != null)
                {
                    padlockStatus.EnterButton.SetActive(true);
                }

                if (debugMode)
                    Debug.Log($"Reset unlocked facility: {padlockStatus.name}");
            }
        }
    }
}
