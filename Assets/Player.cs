using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform ballTf;
    public Transform playerCameraTf;
    public GameObject ball;
    public GameObject playerCamera;

    public float ballDistance = 20f;
    public float ballThrowingForce = 5f;

    private bool holdingBall = true;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        ball.GetComponent<Rigidbody>().useGravity = false;
    }   

    // Update is called once per frame
    void Update()
    {
        if (holdingBall)
        {
            float dist = Vector3.Distance(ball.GetComponent<Transform>().position, playerCamera.transform.position);
            ball.transform.parent = playerCamera.transform;
            
            if (Input.GetMouseButtonDown(0))
            {
                holdingBall = false;
                ball.GetComponent<Rigidbody>().useGravity = true;
                ball.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * ballThrowingForce);
            }
        }
    }
}

