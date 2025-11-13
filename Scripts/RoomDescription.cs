using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomDescription : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    public string message;
    public float typingSpeed = 0.01f;

    private Coroutine typingCoroutine;
    private Animator animator;
    private Image image;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.Play("OpenDescript");
        ShowName(message);
    }
    private void OnDisable()
    {
       
        animator.Play("CloseDescript");    
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
        text.text = "";

        foreach (char letter in message)
        {
            text.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }



}
