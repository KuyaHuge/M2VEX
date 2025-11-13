using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGIsecond : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    [Header("F1C-001 Preloading Images")]
    public Sprite[] F2C001;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void CurrentImage(string name, int index)
    {
        switch (name) {
            case "F2CONE":
                spriteRenderer.sprite = F2C001[index];
                break;
        }
    }
}
