using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class DungeonUIManager : MonoBehaviour
{
    DungeonHomeUI dungeonHomeUI;
    DungeonGameUI dungeonGameUI;
    DungeonGameOverUI dungeonGameOverUI;
    private UIState currentState;

    private void Awake()
    {
        dungeonHomeUI = GetComponentInChildren<DungeonHomeUI>(true);
        dungeonHomeUI.Init(this);
        dungeonGameUI = GetComponentInChildren<DungeonGameUI>(true);
        dungeonGameUI.Init(this);
        dungeonGameOverUI = GetComponentInChildren<DungeonGameOverUI>(true);
        dungeonGameOverUI.Init(this);

        ChangeDungeonState(UIState.DungeonHome);
    }
    public void SetPlayGame()
    {
        ChangeDungeonState(UIState.DungeonGame);
    }
    public void SetGameOver()
    {
        ChangeDungeonState(UIState.DungeonGameOver);
    }

    public void ChangeWave(int waveIndex)
    {
        dungeonGameUI.UpdateWaveText(waveIndex);
    }

    public void ChangePlayerHP(float currentHP, float maxHp)
    {
        dungeonGameUI.UpdateHPSlider(currentHP / maxHp);
    }

    public void ChangeDungeonState(UIState state)
    {
        currentState = state;
        dungeonHomeUI.SetActive(currentState);
        dungeonGameUI.SetActive(currentState);
        if (currentState == UIState.DungeonGameOver)
            Debug.Log("게임오버");
        dungeonGameOverUI.SetActive(currentState);
    }
}
