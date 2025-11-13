using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorReturn : MonoBehaviour
{
    public Animator anim;
    private void Update()
    {
        anim.Play("IndicatorReturn");
    }
}
