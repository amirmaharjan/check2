using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoSingleton<DataHandler>
{
    private void Start()
    {
        if(!PlayerPrefs.HasKey("TotalScore")) PlayerPrefs.SetInt("TotalScore", 0);
    }

    public void SaveData(int totalScore) {
        PlayerPrefs.SetInt("TotalScore", totalScore);
        PlayerPrefs.Save();
    }

    public int LoadData() {
        return PlayerPrefs.GetInt("TotalScore", 0);
    }
}
