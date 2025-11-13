using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FastTravelManager : MonoBehaviour
{
    public static FastTravelManager Instance;

    [Header("Floors Setting")]
    public Button[] Floors;
    [SerializeField] GameObject ChooseFloor;
    public bool shouldactivateobject = false;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        foreach (Button floorButton in Floors)
        {
            if (floorButton.name == currentScene)
            {
                floorButton.interactable = false; // disable button
            }
            else
            {
                floorButton.interactable = true; // keep others usable
            }
        }
    }

    public void Travelto(string sceneName, int AreaNum)
    {
        shouldactivateobject = true;
        SceneManager.LoadScene(sceneName);
        StartCoroutine(ActiveinOtherScene(AreaNum));
    }

    public void ActivateChooseFloor()
    {
        ChooseFloor.SetActive(true);
    }
    public void DeactivateChooseFloor()
    {
        ChooseFloor.SetActive(false);
    }

    IEnumerator ActiveinOtherScene(int index) {
        yield return new WaitForSeconds(1f);
        TravelManager.instance.ActivateOnlyOneArea(index);
    }
}
    