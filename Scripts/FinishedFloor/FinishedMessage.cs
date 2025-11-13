using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedMessage : MonoBehaviour
{
    private Animator animator;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.Play("ShowMessage");
        StartCoroutine(Closemessage());
    }

    IEnumerator Closemessage()
    {
        yield return new WaitForSeconds(7f);
        animator.Play("CloseMessage");
        StartCoroutine(Destroymessage());
    }

    IEnumerator Destroymessage()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }



}
