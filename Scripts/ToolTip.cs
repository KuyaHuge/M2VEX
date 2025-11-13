using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static ToolTip Instance;

    public string message;
    public bool rightSide;

    private void Awake()
    {
        Instance = this;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (rightSide == true)
        {
            TooltipManager._instance.rectTransform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            TooltipManager._instance.textcomponent.rectTransform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            TooltipManager._instance.rectTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            TooltipManager._instance.textcomponent.rectTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }

        TooltipManager._instance.SetandShowToolTip(message);

        Debug.Log(rightSide);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager._instance.HideToolTip();
    }
}
