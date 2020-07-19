using UnityEngine;

public class Iglu : MonoBehaviour
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
        {
            FindObjectOfType<AudioManager>().Play("GameWon");
            gm.NextLevel();
        }
    }
}
