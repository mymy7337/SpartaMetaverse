using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoveManager : MonoBehaviour
{
    private BaseController controller;
    private InteractionManager interactionManager;

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        controller = playerObj.GetComponent<BaseController>();
        interactionManager = GetComponent<InteractionManager>();
    }
    private void Update()
    {
        if (controller != null && controller.IsInteracting == true)
            SceneManager.LoadScene("StackScene");
    }
    public void ToStackScene()
    {
            SceneManager.LoadScene("StackScene");
    }
}
