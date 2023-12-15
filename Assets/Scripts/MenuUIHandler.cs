using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    private TMP_InputField playersNameInputField;

    private void Start()
    {
        playersNameInputField = GetComponentInChildren<TMP_InputField>();
    }

    public void StartNewGame()
    {
        SaveDataManager.Instance.currentScorePlayersName = playersNameInputField.text;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        SaveDataManager.Instance.SaveGameData();
#if UNITY_EDITOR

        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }
}
