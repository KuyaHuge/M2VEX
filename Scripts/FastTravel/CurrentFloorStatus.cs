using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CurrentFloorStatus : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{


    [SerializeField] int AreaNumber;
    [SerializeField] string SceneName;
    public FastTravelManager FastTravelManager;
    private ToolTip tooltip;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
       
        tooltip = GetComponent<ToolTip>();
        button = GetComponent<Button>();
    }

   public void OnPointerEnter(PointerEventData eventData)
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (button.interactable == false && currentScene == button.name)
        {
            tooltip.message = ("You're in the current floor");
        }
        else if (button.interactable == false) {
            tooltip.message = ("Coming Soon");
        }
        else if (button.interactable == true)
        {
            tooltip.message = ("Travel to this floor?");
        }
    }

    public void OnPointerClick(PointerEventData eventData) {

        FastTravelManager.Travelto(SceneName, AreaNumber);
    }

    
}

