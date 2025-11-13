using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prohibition : MonoBehaviour
{
   private Animator animator;


    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.Play("OpenAttention");
    }

}
