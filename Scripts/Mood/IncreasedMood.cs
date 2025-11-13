using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasedMood : MonoBehaviour
{

    private Animator animator;


    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.Play("Increases");
        StartCoroutine(Remove());
    }

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }
}
