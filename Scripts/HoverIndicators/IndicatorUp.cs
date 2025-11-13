using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorUp : MonoBehaviour
{
    public Animator anim;
    private void Update()
    {
        anim.Play("IndicatorUp");
    }
}
