using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorRight : MonoBehaviour
{
    public Animator anim;
    private void Update()
    {
        anim.Play("IndicatorRight");
    }
}
