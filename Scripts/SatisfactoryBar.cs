using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SatisfactoryBar : MonoBehaviour
{
    [Header("Bar Manager")]
    public static SatisfactoryBar instance;
    public Image satisfactorybar;
    public float satisfactoryAmount;
    public float satisfactoryMaximumAmount;
    [SerializeField] TextMeshProUGUI barStatus;

    [Header("Mood Manager")]
    public Sprite[] moods;
    [SerializeField] Image moodSprite;
    [SerializeField] public TextMeshProUGUI moodtext;
    public GameObject increases;
    public GameObject decreases;
    public Transform spawnparent;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        satisfactorybar.fillAmount = satisfactoryAmount / 100f;
    }

    private void Update()
    {

        barStatus.text = ("" + satisfactoryAmount + " / " + satisfactoryMaximumAmount);

        if (satisfactoryAmount > 50)
        {
            moodSprite.sprite = moods[0];
            moodtext.text = ("Satisfied");
            SetFinalMoodSafely(moodtext.text);
        }
        else if (satisfactoryAmount < 50) {
            moodSprite.sprite = moods[2];
            moodtext.text = ("Dissatisfied");
            SetFinalMoodSafely(moodtext.text);
        }
        else if (satisfactoryAmount == 50)
        {
            moodSprite.sprite = moods[1];
            moodtext.text = ("Neutral");
            SetFinalMoodSafely(moodtext.text);
        }

    }

    private void SetFinalMoodSafely(string mood)
    {
        if (Results.instance != null)   
        {
            Results.instance.finalmood = mood;
        }
    }

    public void TakeSatisfaction(float damage)
    {
        satisfactoryAmount -= damage;
        satisfactorybar.fillAmount = satisfactoryAmount / 100f;

        Instantiate(decreases, spawnparent);
    }


    public void AddSatisfaction(float satisfactoryamount)
    {
        satisfactoryAmount += satisfactoryamount;
        satisfactoryAmount = Mathf.Clamp(satisfactoryAmount, 0, 100);

        satisfactorybar.fillAmount = satisfactoryAmount / 100f;

        Instantiate(increases, spawnparent);
    }
}
