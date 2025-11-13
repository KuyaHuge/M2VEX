using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGI : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    [Header("F1C-001 Preloading Images")]
    public Sprite[] F1C001;

    [Header("F1C-002 Preloading Images")]
    public Sprite[] F1C002;

    [Header("F1RW-001 Preloading Images")]
    public Sprite[] F1RW001;

    [Header("F1RWD-001 Preloading Images")]
    public Sprite[] F1RWD001;

    [Header("F1RWD-002 Preloading Images")]
    public Sprite[] F1RWD002;

    [Header("F1RW-002 Preloading Images")]
    public Sprite[] F1RW002;

    [Header("F1RWD-003 Preloading Images")]
    public Sprite[] F1RWD003;

    [Header("F1RWD-004 Preloading Images")]
    public Sprite[] F1RWD004;

    [Header("F1RW-003 Preloading Images")]
    public Sprite[] F1RW003;

    [Header("F1RWD-005 Preloading Images")]
    public Sprite[] F1RWD005;

    [Header("F1LW-001 Preloading Images")]
    public Sprite[] F1LW001;

    [Header("F1LWD-001 Preloading Images")]
    public Sprite[] F1LWD001;

    [Header("F1LW-002 Preloading Images")]
    public Sprite[] F1LW002;

    [Header("F1LWD-002 Preloading Images")]
    public Sprite[] F1LWD002;

    [Header("F1LWD-003 Preloading Images")]
    public Sprite[] F1LWD003;

    [Header("F1LW-003 Preloading Images")]
    public Sprite[] F1LW003;

    [Header("F1LWD-004 Preloading Images")]
    public Sprite[] F1LWD004;

    [Header("F1LWD-005 Preloading Images")]
    public Sprite[] F1LWD005;







    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void CurrentImage(string name, int index)
    {
        switch (name) {
            case "F1CONE":
                spriteRenderer.sprite = F1C001[index];
                break;
            case "F1CTWO":
                spriteRenderer.sprite = F1C002[index];
                break;
            case "F1RWONE":
                spriteRenderer.sprite = F1RW001[index];
                break;
            case "F1RWDONE":
                spriteRenderer.sprite = F1RWD001[index];
                break;
            case "F1RWDTWO":
                spriteRenderer.sprite = F1RWD002[index];
                break;
            case "F1RWTWO":
                spriteRenderer.sprite = F1RW002[index];
                break;
            case "F1RWDTHREE":
                spriteRenderer.sprite= F1RWD003[index];
                break;
            case "F1RWDFOUR":
                spriteRenderer.sprite = F1RWD004[index];
                break;
            case "F1RWTHREE":
                spriteRenderer.sprite = F1RW003[index];
                break;
            case "F1RWDFIVE":
                spriteRenderer.sprite = F1RWD005[index];
                break;
            case "F1LWONE":
                spriteRenderer.sprite = F1LW001[index];
                break;
            case "F1LWDONE":
                spriteRenderer.sprite = F1LWD001[index];
                break;
            case "F1LWTWO":
                spriteRenderer.sprite = F1LW002[index];
                break;
            case "F1LWDTWO":
                spriteRenderer.sprite = F1LWD002[index];
                break;
            case "F1LWDTHREE":
                spriteRenderer.sprite = F1LWD003[index];
                break;
            case "F1LWTHREE":
                spriteRenderer.sprite = F1LW003[index];
                break;
            case "F1LWDFOUR":
                spriteRenderer.sprite = F1LWD004[index];
                break;
            case "F1LWDFIVE":
                spriteRenderer.sprite = F1LWD005[index];
                break;
        }
    }
}
