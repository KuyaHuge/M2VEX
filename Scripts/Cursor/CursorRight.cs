using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorRight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

{
    public Texture2D newCursor;     // Assign your cursor texture in the Inspector
    public Vector2 hotspot = Vector2.zero; // The point in the texture that's "clicked"

    private Texture2D defaultCursor;
    private Vector2 defaultHotspot;

    void Start()
    {
        // Store the default cursor (null means the system default)
        defaultCursor = null;
        defaultHotspot = Vector2.zero;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ChangeCursor();
      
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ResetCursor();
    }



    public void ChangeCursor()
    {
        Cursor.SetCursor(newCursor, hotspot, CursorMode.Auto);
    }

    public void ResetCursor()
    {
        Cursor.SetCursor(defaultCursor, defaultHotspot, CursorMode.Auto);
    }
}
