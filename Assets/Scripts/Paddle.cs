using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float maxPaddleSpeed = 1f;

    public float paddleForce = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BoxCollider c = GetComponent<BoxCollider>();
        float max = c.bounds.max.z;
        float min = c.bounds.min.z;
        Debug.Log($"max: {max}, min: {min}");
    }

    //void FixedUpdate()
    //{
    //    
    //}

    // Update is called once per frame
    void Update()
    {
        //float movementAxis = Input.GetAxis("LeftPaddle");
        //Vector3 force = new Vector3(0f, 0f, 1f) * movementAxis * paddleForce;
        //Transform paddleTransform = GetComponent<Transform>();
        //paddleTransform.position += new Vector3(0f, 0f, movementAxis * maxPaddleSpeed * Time.deltaTime);

        //Vector3 newPosition = paddleTransform.position + new Vector3(0f, 0f, movementAxis * maxPaddleSpeed * Time.deltaTime);
        //newPosition.z = Math.Clamp(newPosition.z, -4.2f, 2.2f);
        //paddleTransform.position = newPosition;
        //Rigidbody rbody = GetComponent<Rigidbody>();
        //rbody.AddForce(force, ForceMode.Force);
    }
}
