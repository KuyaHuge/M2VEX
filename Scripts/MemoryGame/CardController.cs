using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Card cardPrefab;
    [SerializeField] Transform gridTransfrom;
    [SerializeField] Sprite[] sprites;
    [SerializeField] TextMeshProUGUI timerText;

    private List<Sprite> spritePairs;


    PadlockStatus padlockstatus;
    Card firstSelected;
    Card secondSelected;

    int matchCounts;

    [Header("Timer Setting")]
    public float timelimit = 60f;
    private float remainingTime;
    private bool gameover;

    private void Start()
    {
        PrepareSprites();
        CreateCards();
        padlockstatus = GameObject.FindGameObjectWithTag("PadlockHolder").GetComponentInParent<PadlockStatus>();

        remainingTime = timelimit;
        UpdateTimerUI(); // set initial text
        StartCoroutine(CountdownTimer());
    }

    private void PrepareSprites()
    {
        spritePairs = new List<Sprite>();   
        for (int i = 0; i < sprites.Length; i++)
        {
            spritePairs.Add(sprites[i]);
            spritePairs.Add(sprites[i]);
        }
        ShuffleSprites(spritePairs);
    }


    void CreateCards()
    {
        for (int i = 0; i < spritePairs.Count; i++)
        {
            Card card = Instantiate(cardPrefab, gridTransfrom);
            card.SetIconSprite(spritePairs[i]);
            card.controller = this;
        }
    }

    public void SetSelected(Card card)
    {
        if (card.isSelected == false)
        {
            card.Show();

            if (firstSelected == null)
            {
                firstSelected = card;
                return;
            }
            if (secondSelected == null)
            {
                secondSelected = card;
                StartCoroutine(CheckMatching(firstSelected, secondSelected));
                firstSelected = null;
                secondSelected = null;
            }
        }
    }

    IEnumerator CheckMatching(Card a, Card b)
    {
        yield return new WaitForSeconds(0.5f);

        if (a.iconSprite == b.iconSprite)
        {
            matchCounts++;
            if (matchCounts >= spritePairs.Count / 2)
            {
                //level Completed
                PrimeTween.Sequence.Create()
                    .Chain(PrimeTween.Tween.Scale(gridTransfrom, Vector3.one * 1.2f, 0.2f, ease: PrimeTween.Ease.OutBack))
                    .Chain(PrimeTween.Tween.Scale(gridTransfrom, Vector3.one, 0.1f));
                StartCoroutine(FinishGame(true));
            }
        }

        else
        {
            a.Hide();
            b.Hide();
        }
    }

    IEnumerator FinishGame(bool won)
    {
        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
        if (won == true)
        {
            GlobalManager.instance.Padlock(padlockstatus.name, false);
            SatisfactoryBar.instance.AddSatisfaction(25);
            EventLogs.instance.IncreaseSatisfaction(25);
            GameManager.Instance.CheckGames();
        }
        else
        {
           
            Debug.Log("You Lost! Time’s up.");
            GlobalManager.instance.Padlock(padlockstatus.name, false);
            SatisfactoryBar.instance.TakeSatisfaction(25);
            EventLogs.instance.DecreaseSatisfaction(25);
            GameManager.Instance.CheckGames();
        }
    }

    void ShuffleSprites(List<Sprite> spriteList)
    {
        for (int i = spriteList.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            Sprite temp = spriteList[i];
            spriteList[i] = spriteList[randomIndex];
            spriteList[randomIndex] = temp;
        }
    }
    IEnumerator CountdownTimer()
    {
        while (remainingTime > 0 && !gameover)
        {
            yield return new WaitForSeconds(1f);
            remainingTime--;

            UpdateTimerUI();
        }

        if (!gameover) // ran out of time
        {
            gameover = true;
            StartCoroutine(FinishGame(false));
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
