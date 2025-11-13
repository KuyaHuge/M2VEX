using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChooseFloorClicked : MonoBehaviour, IPointerClickHandler
{

    public static ChooseFloorClicked instance;
    [SerializeField] Transform spawnparent;
    public GameObject WarningMessage;

    public bool quiz = true;

    private void Awake()
    {
        instance = this;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.Instance.GameCount == 10 && quiz == false)
        {
            FastTravelManager.Instance.ActivateChooseFloor();
        }
        else if (GameManager.Instance.GameCount == 10)
        {
            GameManager.Instance.finalquiz.SetActive(true);
            quiz = false;
        }
        else
        {
            Instantiate(WarningMessage, spawnparent);
        }

    }
    
}
