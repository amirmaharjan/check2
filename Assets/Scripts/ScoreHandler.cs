using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField]
    private int matches, turns, totalPairsForRound;

    [SerializeField]
    private TMP_Text matchesTxt, turnsTxt;

    public static ScoreHandler instance;

    private void OnEnable()
    {
        ResetAllCounters();
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void MatchCounter()
    {
        matches++;
        matchesTxt.text = matches.ToString();

        if (matches == totalPairsForRound)
        {
            StartCoroutine(DelayGameOverPanel());
        }
    }

    private IEnumerator DelayGameOverPanel() {
        yield return new WaitForSeconds(0.2f);
        PanelHandler.instance.OpenGamneOverPanel();
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
