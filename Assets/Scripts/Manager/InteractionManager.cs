using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public GameObject moveUI;
    public bool IsPlayerInside {  get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            moveUI.SetActive(true);
            IsPlayerInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            moveUI.SetActive(false);
            IsPlayerInside = false;
        }
    }
}
