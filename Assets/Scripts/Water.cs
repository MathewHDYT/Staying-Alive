using UnityEngine;

public class Water : MonoBehaviour
{
    GameManager gm;

    void Start()
    {
        gm = GameManager.instance;
    }

    //Calling Function in GameManager
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            gm.Died();
    }

}
