using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor.Timeline;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager uiManager;
    protected DungeonUIManager dungeonUIManager;

    public virtual void Init(UIManager uIManager)
    {
        this.uiManager = uIManager;
    }

    public virtual void Init(DungeonUIManager dungeonUIManager)
    {
        this.dungeonUIManager = dungeonUIManager;
    }

    protected abstract UIState GetUIState();
    public void SetActive(UIState state)
    {
        gameObject.SetActive(GetUIState() == state);
    }
     
}
