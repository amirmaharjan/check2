using UnityEngine;
using TMPro;

public class PanelHandler : MonoSingleton<PanelHandler>
{
    [SerializeField]
    private GameObject menuPanel, gamePanel, gameOverPanel;

    [SerializeField]
    private TMP_Dropdown difficultyDropDown;

    [SerializeField]
    private int difficultyIndex, rowValue, columnValue;

    public void OnClickStartGame() {
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
        StartGame(difficultyDropDown.value);
    }

    public void StartGame(int value) {
        difficultyIndex = value;

        switch (difficultyIndex)
        {
            case 0:
                rowValue = 3;
                columnValue = 4;
                break;
            case 1:
                rowValue = 4;
                columnValue = 4;
                break;
            case 2:
                rowValue = 5;
                columnValue = 6;
                break;
        }

        GridHandler.Instance.CreateGrid(rowValue, columnValue);
    }

    public void OpenGamneOverPanel() {
        AudioHandler.Instance.PlayAudio(3);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void NextRound() {
        if (difficultyIndex == difficultyDropDown.options.Count-1) {
            menuPanel.SetActive(true);
            gamePanel.SetActive(false);
            gameOverPanel.SetActive(false);

            difficultyIndex = 0;
            rowValue = 0;
            columnValue = 0;
            return;
        }

        gamePanel.SetActive(true);
        gameOverPanel.SetActive(false);
        StartGame(difficultyIndex+1);
    }
}
