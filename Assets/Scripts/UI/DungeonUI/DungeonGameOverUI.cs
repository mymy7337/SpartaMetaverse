using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DungeonGameOverUI : BaseUI
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    public override void Init(DungeonUIManager dungeonUIManager)
    {
        base.Init(dungeonUIManager);
        restartButton.onClick.AddListener(OnClickRestartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnClickExitButton()
    {
        SceneManager.LoadScene("TownScene");
    }
    protected override UIState GetUIState()
    {
        return UIState.DungeonGameOver;
    }
}
