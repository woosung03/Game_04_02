using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveCamera : MonoBehaviour
{
    public Transform Ballxy; // Ball Position x y
    public float CameraSpeed; //Camera speed decide box
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        transform.position = Vector3.Lerp(transform.position, Ballxy.position, Time.deltaTime * CameraSpeed); //Camera move and smooth 
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f); //Camera Position Z Fix -10f
    }
}
