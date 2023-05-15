using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 700f;
    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDoubleJump = false;
    private bool isSlide = false;
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private BoxCollider2D[] colliders;

    public Button btnJump;
    public Button btnSlide;

    // Start is called before the first frame update
    void Start()
    {
        this.playerRigidbody = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
        this.colliders = this.GetComponents<BoxCollider2D>();
        this.btnJump.onClick.AddListener(() =>
        {
            if (this.jumpCount < 2)
            {
                this.jumpCount++;
                playerRigidbody.velocity = Vector2.zero;
                this.playerRigidbody.AddForce(new Vector2(0, this.jumpForce));
                if (this.jumpCount > 1)
                {
                    this.isDoubleJump = true;
                }
            }
            else if (this.playerRigidbody.velocity.y > 0)
            {
                this.playerRigidbody.velocity = this.playerRigidbody.velocity * 0.5f;
            }
        });
        this.btnSlide.onClick.AddListener(() =>
        {

        });
    }

    // Update is called once per frame
    void Update()
    {
        this.animator.SetBool("DoubleJump", this.isDoubleJump);
        this.animator.SetBool("Grounded", this.isGrounded);
        this.animator.SetBool("Slide", this.isSlide);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            this.isGrounded = true;
            this.isDoubleJump = false;
            this.jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (this.transform.position.y > 0.1f)
        {
            isGrounded = false;
        }
    }

    public void SlideButtonDown()
    {
        colliders[0].enabled = false;
        colliders[1].enabled = true;
        isSlide = true;
    }
    public void SlideButtonUp()
    {
        colliders[0].enabled = true;
        colliders[1].enabled = false;
        isSlide = false;
    }
}