using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdDecrease : MonoBehaviour
{
    public float heatloss = 0.05f;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Color blue;
    [SerializeField] private Color darkblue;
    [SerializeField] private Color darkerblue;
    private float heat = 1f;
    public bool locked = false;
    public bool fireplace = false;

    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

    private void Update()
    {
        if (!locked && heat > 0)
        {
            if (heat >= 0.5f && heat < 0.9f)
            {
                healthBar.SetColor(blue);
            }
            else if (heat >= 0.3f && heat < 0.5f)
            {
                healthBar.SetColor(darkblue);
            }
            else if (heat < 0.3f)
            {

                healthBar.SetColor(darkerblue);
            }
            locked = true;
            StartCoroutine(LoseBodyTemp());
        }
        if (heat < 0)
        {
            gm.Died();
        }
    }

    IEnumerator LoseBodyTemp()
    {
        if (fireplace)
        {
            yield return new WaitForSeconds(2);
            locked = false;
        }
        else
        {
            yield return new WaitForSeconds(2);
            heat -= heatloss;
            healthBar.SetSize(heat);
            locked = false;
        }
    }
}
