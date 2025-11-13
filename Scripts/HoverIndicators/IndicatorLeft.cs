using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorLeft : MonoBehaviour
{
    public Animator anim;
    private void Update()
    {
        anim.Play("IndicatorLeft");
    }
}
