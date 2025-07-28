using System.Collections;
using System.Collections.Generic;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DungeonHomeUI : BaseUI
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    public override void Init(DungeonUIManager dungeonUIManager)
    {
        base.Init(dungeonUIManager);
        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickStartButton()
    {
        GameManager.Instance.StartGame();
    }
    public void OnClickExitButton()
    {
        SceneManager.LoadScene("TownScene");
    }
    protected override UIState GetUIState()
    {
        return UIState.DungeonHome;
    }
}
