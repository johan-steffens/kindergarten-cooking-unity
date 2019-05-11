using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject levelSelectPanel;

    public void OnPlayButtonClicked()
    {
        mainPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }

    public void OnLevelSelectBackClicked()
    {
        levelSelectPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void OnPlayLevel(int level)
    {
        switch(level)
        {
            case 1:
                SceneManager.LoadScene("Level One");
                break;
        }
    }

    public void OnExitButtonClicked()
    {
        #if UNITY_EDITOR
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        #endif
        Application.Quit();
    }

}
