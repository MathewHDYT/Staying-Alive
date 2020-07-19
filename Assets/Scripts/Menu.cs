using UnityEngine;

public class Menu : MonoBehaviour
{
    GameManager gm;

    void Start()
    {
        gm = GameManager.instance;
    }

    public void Play()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        gm.NextLevel();
    }

    public void Quit()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        Application.Quit();
    }

    public void LoadMenu()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        gm.Menu();
    }

    public void RestartLevel()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        gm.Restart();
    }
}
