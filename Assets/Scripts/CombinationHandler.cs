using System.Collections;
using UnityEngine;

public class CombinationHandler : MonoSingleton<CombinationHandler>
{
    [SerializeField]
    private bool firstClick, secondClick;

    [SerializeField]
    private int firstClickValue, secondClickValue;

    [SerializeField]
    private GameObject firstClickGO, secondClickGO;

    public delegate void FlipBackAction();
    public static event FlipBackAction onFlipBack;

    private void OnEnable()
    {
        ResetCurrentData();
    }


    public void OnClick(int value, GameObject go) {
        ScoreHandler.Instance.TurnCounter();
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
            AudioHandler.Instance.PlayAudio(1);
            StartCoroutine(DelayDisableGameObjects());
            ScoreHandler.Instance.MatchCounter();
        }
        else {
            AudioHandler.Instance.PlayAudio(2);
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
