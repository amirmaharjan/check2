using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreHandler : MonoSingleton<ScoreHandler>
{
    [SerializeField]
    private int matches, turns, totalPairsForRound, totalScore;

    [SerializeField]
    private TMP_Text matchesTxt, turnsTxt, totalScoreTxt;


    private void OnEnable()
    {
        ResetAllCounters();
    }

    private void Start()
    {
        totalScore = DataHandler.Instance.LoadData();
        totalScoreTxt.text = totalScore.ToString();
    }

    public void MatchCounter()
    {
        matches++;
        matchesTxt.text = matches.ToString();

        totalScore++;
        totalScoreTxt.text = totalScore.ToString();

        if (matches == totalPairsForRound)
        {
            DataHandler.Instance.SaveData(totalScore);
            StartCoroutine(DelayGameOverPanel());
        }
    }

    private IEnumerator DelayGameOverPanel() {
        yield return new WaitForSeconds(0.2f);
        PanelHandler.Instance.OpenGamneOverPanel();
        ResetAllCounters();
    }

    public void TurnCounter()
    {
        turns++;
        turnsTxt.text = turns.ToString();
    }

    private void ResetAllCounters()
    {
        matches = 0;
        turns = 0;
        matchesTxt.text = matches.ToString();
        turnsTxt.text = turns.ToString();
    }

    public void SetTotalScoreForRound(int value) => totalPairsForRound = value;
}
