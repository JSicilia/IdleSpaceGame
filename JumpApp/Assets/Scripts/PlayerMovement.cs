using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    private float jumpHeight = 9f;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2d;
    public PhysicsMaterial2D bounceMaterial, normalMaterial;
    public bool canJump = true;
    public float jumpValue = 0.0f;
    private float directionValue;
    public Animator animator;

    public Transform groundCheck;
    public float groundCheckRadius;
    private bool touchingGround;
    private bool isFalling;

    private bool justJumped;

    private float startOfFall;

    private float jumpTimeCount;
    public float jumpTime;

    public Text startF;
    public Text FinalF;
    public Text timer;
    public Text JHeight;
    private float currentTime;
    public TimeSpan time;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        currentTime = 0;
    }

    private void FixedUpdate()
    {
        if (justJumped)
        {
            justJumped = false;
            isFalling = true;
            rb.velocity = new Vector2(directionValue, jumpValue);
            animator.SetBool("jumping", false);
            Invoke("ResetJump", 0.2f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        touchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, platformLayerMask);

        if (!isFalling && touchingGround) startOfFall = rb.transform.position.y;


        if (isFalling && touchingGround && Mathf.Abs(startOfFall - rb.transform.position.y) > 5)
        {
            startOfFall = rb.transform.position.y;
            
            Debug.Log("player fell");
            animator.SetTrigger("fall");
        }

        if (!touchingGround)
        {
            rb.sharedMaterial = bounceMaterial;
        } else
        {
            rb.sharedMaterial = normalMaterial;
        }

        TouchInput();

        //Can't go above max jumpHeight
        

        //Jump value being incremented

        /*if (Input.GetMouseButton(0) && touchingGround && canJump)
        {
            jumpValue += 0.05f;
        }

        if (Input.GetMouseButtonUp(0) && touchingGround && canJump)
        {
            canJump = true;
   
            rb.velocity = new Vector2(-2f, jumpValue);
            jumpValue = 0.0f;

        }

        if (Input.GetMouseButton(1) && touchingGround && canJump)
        {
            jumpValue += 0.05f;
        }

        if (Input.GetMouseButtonUp(1) && touchingGround && canJump)
        {
            canJump = true;
            if(jumpValue < 2f)
            {
                jumpValue = 2f;
            }
            rb.velocity = new Vector2(2f, jumpValue);
            jumpValue = 0.0f;

        }*/
        canJump = true;
    }

    void ResetJump()
    {
        canJump = false;
        jumpValue = 0.0f;
    }

    void TouchInput()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase >= TouchPhase.Began && touchingGround && canJump)
            {
                animator.SetBool("jumping", true);
                isFalling = false;
                if (touch.position.x < Screen.width / 2)
                    {
                    jumpValue += Time.deltaTime * 10f;
                    directionValue = -2.5f;
                }

                if (touch.position.x > Screen.width / 2)
                {
                    jumpValue += Time.deltaTime * 10f;
                    directionValue = 2.5f;
                }
                currentTime = currentTime + Time.deltaTime;
                time = TimeSpan.FromSeconds(currentTime);
                timer.text = time.Seconds.ToString() + ":" + time.Milliseconds.ToString();
                JHeight.text = jumpValue.ToString();
                
            }

            if (jumpValue >= jumpHeight)
            {
                jumpValue = jumpHeight;
            }



            if (touch.phase == TouchPhase.Ended && touchingGround && canJump)
            {
                if (jumpValue < 2f)
                {
                    jumpValue = 2f;
                }
                
                justJumped = true;
                currentTime = 0;
            }
        }
    }
}
