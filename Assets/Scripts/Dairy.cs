using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dairy : MonoBehaviour {
    public GameObject dairy;
    private int checkTrigger;
    private bool interact;

    void Start()
    {
        interact = false;
        checkTrigger = 0;
        DairyDefault();
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        ++checkTrigger;
        if (player.CompareTag("Player") && isNonTrigger() == false)
        {
            interact = true;
        }
    }

    void OnTriggerExit2D()
    {
        --checkTrigger;
        DairyDefault();
        interact = false;
    }

    bool isNonTrigger()
    {
        if (checkTrigger == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool getInteract()
    {
        return interact;
    }

    void DairyDefault()
    {
        dairy.SetActive(false);
    }
}
