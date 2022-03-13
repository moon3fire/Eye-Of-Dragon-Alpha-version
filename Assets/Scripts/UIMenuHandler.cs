using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIMenuHandler : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button quitButton;
    void Awake()
    {
        startButton.onClick.AddListener(LoadStartScene);
        quitButton.onClick.AddListener(QuitGame);
    }
    void LoadStartScene()
    {
        SceneManager.LoadScene(1);
    }

    void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
