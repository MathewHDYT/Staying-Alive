using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    GameManager gm;

    [SerializeField] private ColdDecrease decrease;

    private void Start()
    {
        gm = GameManager.instance;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            decrease.fireplace = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            decrease.fireplace = false;
        }
    }

}
