using System.Collections;
using UnityEngine;

public class CombinationHandler : MonoBehaviour
{
    [SerializeField]
    private bool firstClick, secondClick;

    [SerializeField]
    private int firstClickValue, secondClickValue;

    [SerializeField]
    private GameObject firstClickGO, secondClickGO;

    public delegate void FlipBackAction();
    public static event FlipBackAction onFlipBack;

    public static CombinationHandler instance;

    private void OnEnable()
    {
        ResetCurrentData();
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void OnClick(int value, GameObject go) {
        ScoreHandler.instance.TurnCounter();
        if (!firstClick && !secondClick) {
            firstClick = true;
            firstClickValue = value;
            firstClickGO = go;
            return;
        }

        if (firstClick && !secondClick) {
            secondClick = true;
            secondClickValue = value;
            secondClickGO = go;

            CheckCombination();
        }
    }

    private void CheckCombination() {
        if (firstClickValue == secondClickValue)
        {
            StartCoroutine(DelayDisableGameObjects());
            ScoreHandler.instance.MatchCounter();
        }
        else {
            onFlipBack();
            Invoke(nameof(ResetCurrentData), 0.2f);
        }
    }

    IEnumerator DelayDisableGameObjects() {
        yield return new WaitForSeconds(0.2f);
        firstClickGO.SetActive(false);
        secondClickGO.SetActive(false);

        ResetCurrentData();
    }

    private void ResetCurrentData() {
        firstClick = false;
        secondClick = false;
        firstClickGO = null;
        secondClickGO = null;
        firstClickValue = -1;
        secondClickValue = -1;
    }
}
