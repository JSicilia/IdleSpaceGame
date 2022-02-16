using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    public float speed = 7f;
    public float rotation;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rotation = Random.Range(0.5f, 3f);
        //Debug.Log(screenBounds.y);
        //Debug.Log(transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotation*0.1f);
        if(transform.position.y < -screenBounds.y -1)
        {
            Destroy(this.gameObject);
        }
    }
}
