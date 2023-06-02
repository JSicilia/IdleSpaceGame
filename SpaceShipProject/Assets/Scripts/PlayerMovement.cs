using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour { 

    private Rigidbody2D rb;
    private float movementSpeed, ShipPos, objectWidth;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        screenBounds = Camera.main.ScreenToWorldPoint(transform.position);
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        rb = GetComponent<Rigidbody2D>();
        movementSpeed = 5f;
        Debug.Log(rb.name);
    }

    // Update is called once per frame
    void Update()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;
        Debug.Log("ship position: " + rb.position.x + " camera info: " + widthOrtho);
        //ShipPos = rb.position.x;
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        TouchInput();

        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (touch.position.x < Screen.width / 2 && ShipPos > -widthOrtho)
                        rb.velocity = new Vector2(-movementSpeed, 0f);

                    if (touch.position.x > Screen.width / 2 && ShipPos < widthOrtho)
                        rb.velocity = new Vector2(movementSpeed, 0f);

                    break;

                case TouchPhase.Ended:
                    rb.velocity = new Vector2(0f, 0f);
                    break;
            }
        }*/
        
        /*if (Input.GetMouseButton(0))
        {
            rb.velocity = new Vector2(-movementSpeed, 0f);
            ShipPos = rb.position.x;
            Debug.Log("click");
        }
        if (Input.GetMouseButton(1))
        {
            rb.velocity = new Vector2(movementSpeed, 0f);
                ShipPos = rb.position.x;    
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            rb.velocity = new Vector2(0f, 0f);
            ShipPos = rb.position.x;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            rb.velocity = new Vector2(0f, 0f);
            ShipPos = rb.position.x;
        }
        /*if (ShipPos > widthOrtho || ShipPos < -widthOrtho)
        {
                rb.velocity = new Vector2(0f, 0f);
                //rb.transform.Translate()
                ShipPos = rb.position.x;
        }*/
    }

   void LateUpdate()
    {
        Vector3 viewPos = rb.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x * -1 - objectWidth);
        rb.position = viewPos;
    }

    void TouchInput()
    {
        if (EventSystem.current.IsPointerOverGameObject() ||
            EventSystem.current.currentSelectedGameObject != null)
        {
            return;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (touch.position.x < Screen.width / 2)
                        rb.velocity = new Vector2(-movementSpeed, 0f);

                    if (touch.position.x > Screen.width / 2)
                        rb.velocity = new Vector2(movementSpeed, 0f);

                    break;

                case TouchPhase.Ended:
                    rb.velocity = new Vector2(0f, 0f);
                    break;
            }
        }
    }
}
