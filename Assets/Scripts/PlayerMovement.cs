using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator enuit;
    public Animator cam;
    public GameObject snowcloud;
    public float runspeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;

        enuit.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            if (!enuit.GetBool("isJumping"))
            {
                FindObjectOfType<AudioManager>().Play("Jump");
                jump = true;
                enuit.SetBool("isJumping", true);
            }
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        enuit.SetBool("isJumping", false);
        cam.SetTrigger("Shake");
        FindObjectOfType<AudioManager>().Play("Land");
        GameObject cloud = Instantiate(snowcloud, transform);
        Destroy(cloud, .5f);
    }

    public void OnCrouching(bool isCrouching)
    {
        enuit.SetBool("isCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
