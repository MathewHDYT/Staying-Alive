using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    #region Singelton
    public static GameManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Instance of Inventory found");
            return;
        }
        instance = this;
    }
    #endregion

    public Animator transition;
    public float transitiontime = 1f;
    public bool died = false;
    private static int currentIndex = 0;

    public void NextLevel()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void Died()
    {
        if (!died)
        {
            FindObjectOfType<AudioManager>().Play("Hit");
            died = true;
        }
        StartCoroutine(LoadLevel(7));
    }

    public void Menu()
    {
        currentIndex = 0;
        StartCoroutine(LoadLevel(0));
    }

    public void Restart()
    {
        StartCoroutine(LoadLevel(currentIndex));
    }

    IEnumerator LoadLevel(int levelindex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitiontime);

        SceneManager.LoadScene(levelindex);
    }
}
