using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChooseGame : MonoBehaviour, IPointerClickHandler
{
    GameManager gamemanager;

    private void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        gamemanager.ActiveChooseGame();
    }

}
