using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //variable for camera
    //[SerializeField] private GameObject cameraContainer;

    //variable for the player object
    [SerializeField] private GameObject player;

    //offset to maintain from player
    [SerializeField] float offSet;

    //variable for camera height
    [SerializeField] float camHeight;

    //float for the camera follow speed
    [SerializeField] float followSpeed;

    //float for the camera rotation speed
    [SerializeField] float rotateSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);

        if(Vector3.Distance(transform.position, player.transform.position) > offSet)
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + camHeight, player.transform.position.z), followSpeed * Time.deltaTime); 
        }
        if(transform.position.y < player.transform.position.y && !Input.GetKey("w"))
        {
            transform.position += new Vector3(0, 2, 0) * Time.deltaTime;
        }
        if (Input.GetKey("e"))
        {
            transform.RotateAround(player.transform.position, Vector3.up, -rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey("q"))
        {
            transform.RotateAround(player.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }
        

        //transform.position = Vector3.Slerp(transform.position, player.transform.forward + offSet, followSpeed * Time.deltaTime) ;
    }
}
