using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class TooltipManager : MonoBehaviour
{

    public static TooltipManager _instance;
    Animator anim;

    public RectTransform rectTransform;
    public TextMeshProUGUI textcomponent;
    public float typingSpeed = 0.02f; // Speed of typing effect (lower = faster)

    private Coroutine typingCoroutine;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rectTransform = GetComponent<RectTransform>();
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void SetandShowToolTip(string message)
    {

        gameObject.SetActive(true);

        anim.Play("ToolTip");
        // If a typing effect is already running, stop it
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        // Start a new typing effect
        typingCoroutine = StartCoroutine(TypeText(message));
    }

    private IEnumerator TypeText(string message)
    {
        textcomponent.text = "";

        foreach (char letter in message)
        {
            textcomponent.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void HideToolTip()
    {
        anim.Play("ToolTipExit");

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        gameObject.SetActive(false);
        textcomponent.text = string.Empty;
    }
}
