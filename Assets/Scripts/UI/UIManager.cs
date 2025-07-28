using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.XR;

public enum UIState
{
    StackHome,
    StackGame,
    StackScore,
    DungeonHome,
    DungeonGame,
    DungeonGameOver
}

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    UIState currentState = UIState.StackHome;

    StackHomeUI stackHomeUI = null;
    StackGameUI stackGameUI = null;
    StackScoreUI stackScoreUI = null;

    TheStack theStack = null;
    private void Awake()
    {
        instance = this;
        theStack = FindObjectOfType<TheStack>();

        stackHomeUI = GetComponentInChildren<StackHomeUI>(true);
        stackHomeUI?.Init(this);
        stackGameUI = GetComponentInChildren<StackGameUI>(true);
        stackGameUI?.Init(this);
        stackScoreUI = GetComponentInChildren<StackScoreUI>(true);
        stackScoreUI?.Init(this);

        ChangeState(UIState.StackHome);
    }
    public void ChangeState(UIState state)
    {
        currentState = state;
        stackHomeUI?.SetActive(currentState);
        stackGameUI?.SetActive(currentState);
        stackScoreUI?.SetActive(currentState);
    }
    public void OnClickStart()
    {
        theStack.Restart();
        ChangeState(UIState.StackGame);
    }
    public void OnclickExit()
    {
#if UNITY_EDITOR
        SceneManager.LoadScene("TownScene");
#else
        Application.Quit();
#endif
    }

    public void UpdateScore()
    {
        stackGameUI.SetUI(theStack.Score, theStack.Combo, theStack.MaxCombo);
    }

    public void SetScoreUI()
    {
        stackScoreUI.SetUI(theStack.Score, theStack.MaxCombo, theStack.BestScore, theStack.BestCombo);

        ChangeState(UIState.StackScore);
    }
}
