using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoveManager : MonoBehaviour
{
    private BaseController controller;
    private InteractionManager interactionManager;

    [SerializeField] private string sceneToLoad;

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        controller = playerObj.GetComponent<BaseController>();
        interactionManager = GetComponent<InteractionManager>();
    }
    private void Update()
    {
        if (interactionManager.IsPlayerInside && controller != null && controller.IsInteracting == true)
            SceneManager.LoadScene(sceneToLoad);
    }
}
