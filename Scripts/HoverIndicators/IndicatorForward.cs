using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorForward : MonoBehaviour
{
    public Animator anim;
    private void Update()
    {
        anim.Play("IndicatorForward");
    }
}
