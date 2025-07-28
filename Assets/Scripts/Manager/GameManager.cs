using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController player {  get; private set; }
    private ResourceController _playerResourceController;

    [SerializeField] private int currentWaveIndex = 0;

    private EnemyManager enemyManager;

    private DungeonUIManager dungeonUIManager;
    public static bool isFirstLoading = true;

    private void Awake()
    {
        Instance = this;
        player = FindObjectOfType<PlayerController>();
        player.Init(this);

        dungeonUIManager = FindObjectOfType<DungeonUIManager>();

        _playerResourceController = player.GetComponent<ResourceController>();
        _playerResourceController.RemoveHealthChangeEvent(dungeonUIManager.ChangePlayerHP);
        _playerResourceController.AddHealthChangeEvent(dungeonUIManager.ChangePlayerHP);

        enemyManager = GetComponentInChildren<EnemyManager>();
        enemyManager.Init(this);
    }
    private void Start()
    {
        if(!isFirstLoading)
        {
            StartGame();
        }
        else
        {
            isFirstLoading = false;
        }
    }

    public void StartGame()
    {
        dungeonUIManager.SetPlayGame();
        StartNextWave();
    }

    public void StartNextWave()
    {
        currentWaveIndex += 1;
        dungeonUIManager.ChangeWave(currentWaveIndex);
        enemyManager.StartWave(1 + currentWaveIndex / 5);
    }

    public void EndOfWave()
    {
        StartNextWave();
    }    

    public void GameOver()
    {
        enemyManager.StopWave();
        dungeonUIManager.SetGameOver();
    }
}
