using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Obstacke_ball : MonoBehaviour
{
    public GameObject prefabBalls; //Ball Object push
    Transform ObBalls;
    void Start()
    {
        ObBalls = GetComponent<Transform>( );

        StartCoroutine(ObstackeBalls( ));
    }


   


    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ObstackeBalls()
    {
        while (true)
        {
            Instantiate(prefabBalls, ObBalls.position, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }
    }
}
