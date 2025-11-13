using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LocationName : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public Animator Anim;
    public string message;
    public float typingSpeed = 0.01f; // Speed of typing effect (lower = faster)

    private Coroutine typingCoroutine;

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        if (Anim != null)
        {
            Anim.Play("LocationName");
        }
        ShowName(message);
    }

    public void ShowName(string name)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(TypeText(name));
    }

    private IEnumerator TypeText(string type)
    {
        if (textcomponent != null)
        {
            textcomponent.text = "";

            foreach (char letter in message)
            {
                textcomponent.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
    }

    public void Exitanimation()
    {
        // Safety check: only proceed if GameObject is active and Animator exists
        if (!gameObject.activeInHierarchy)
        {
            Debug.LogWarning($"Cannot start Exitanimation on inactive GameObject: {gameObject.name}");
            return;
        }

        if (Anim == null)
        {
            Debug.LogWarning($"Animator not found on {gameObject.name}");
            return;
        }

        Anim.Play("LocationNameExit");
        StartCoroutine(AfterExitAnimation());
    }

    IEnumerator AfterExitAnimation()
    {
        yield return new WaitForSeconds(2f);

        // Additional safety check before deactivating
        if (gameObject != null && gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }
}