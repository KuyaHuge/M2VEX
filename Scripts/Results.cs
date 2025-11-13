using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Results : MonoBehaviour
{
    public static Results instance;
   
    public TextMeshProUGUI FinalMood;
    public TextMeshProUGUI moodmessage;
    public TextMeshProUGUI finalquizresult;
    public TextMeshProUGUI resultmessage;

    public string finalmood;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        FinalMood.text = finalmood;
        finalquizresult.text = ("" + FinalQuiz.Instance.score + " / " + FinalQuiz.Instance.overall);
        moodmessages();
        finalmessage();
    }

    public void finalmessage()
    {

        if (FinalQuiz.Instance.score > 3)
        {
            resultmessage.text = ("The student is very attentive and shows interest in the school");
        }
        else if (FinalQuiz.Instance.score == 3)
        {
            resultmessage.text = ("The student is an average joe");
        }
        else if (FinalQuiz.Instance.score < 3)
        {
            resultmessage.text = ("The student is not interested in any way");
        }
    }
    public void moodmessages()
    {
        switch (FinalMood.text)
        {
            case "Satisfied":
                moodmessage.text = ("The student seems to be satisfied with the tour. Therefore, the student has decided to enroll in the next school year.");
                break;
            case "Dissatisfied":
                moodmessage.text = ("The student seems to be dissatisfied with the tour. Therefore, the student has decided to take their chances on another school");
                break;
            case "Neutral":
                moodmessage.text = ("Meh.");
                break;
        }
    }


}
