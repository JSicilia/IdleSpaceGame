using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera worldCam;
    public GameObject player;
    private float CameraHeight;

    // Start is called before the first frame update
    void Start()
    {
        float screenRation = (float)Screen.width / (float)Screen.height;
        CameraHeight = worldCam.orthographicSize * 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("player = " + player.transform.position.y);
        //Debug.Log("cam = " + worldCam.transform.position.y);

        if (player.transform.position.y > (worldCam.transform.position.y + CameraHeight/2))
            {

            Debug.Log("Camera Up");
            worldCam.transform.position = new Vector3(worldCam.transform.position.x, worldCam.transform.position.y + CameraHeight, worldCam.transform.position.z);
        }

        if (player.transform.position.y < (worldCam.transform.position.y - CameraHeight/2))
        {
            Debug.Log("Camera down");
            worldCam.transform.position = new Vector3(worldCam.transform.position.x, worldCam.transform.position.y - CameraHeight, worldCam.transform.position.z);
            //worldCam.transform.position = new Vector3(worldCam.transform.position.x, worldCam.transform.position.y - CameraHeight, worldCam.transform.position.z);
        }
    }

    bool CameraCheck()
    {
        return true;
    }
}
