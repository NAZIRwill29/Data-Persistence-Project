using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public Text BestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        SetBestScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //function back to menu
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    //function change bestscore text
    void SetBestScore()
    {
        //change best score text
        if (MainManager.Instance != null)
        {
            BestScoreText.text = "Best Score : " + MainManager.Instance.bestName + " : " + MainManager.Instance.bestScore;
        }
    }

    //function start game
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    //function quit game
    public void Exit()
    {
        MainManager.Instance.SaveBestScoreAndName();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
