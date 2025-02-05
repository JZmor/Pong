using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed = 5f;
    public float leftScore;
    public float rightScore;

    private Vector3 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(ballSpeed, 0f, 0f);
        leftScore = 0;
        rightScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = movement;
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log($"made contact with {other.gameObject.name}");
        if (other.gameObject.CompareTag("Wall"))
        {
            Rigidbody rbody = GetComponent<Rigidbody>();
            float speed = other.relativeVelocity.magnitude;
            Vector3 newVelocity = other.relativeVelocity.normalized * speed;
            newVelocity = new Vector3(-newVelocity.x, newVelocity.y, newVelocity.z);
            rbody.linearVelocity = newVelocity;
            movement = newVelocity;
        } 
        else
        {
            Rigidbody rbody = GetComponent<Rigidbody>();
            float speed = other.relativeVelocity.magnitude;
            float newSpeed = speed * 1.1f;
        
            Vector3 direction;
            if (other.relativeVelocity.normalized.x > 0)
            {
                direction = new Vector3(1, 0, 0);
            }
            else
            {
                direction = new Vector3(-1, 0, 0);
            }

            //Quaternion posRotation = Quaternion.Euler(0f, 45f, 0f);
            //Quaternion negRotation = Quaternion.Euler(0f, -45f, 0f);
            //Vector3 posVector = posRotation * up;
            //Vector3 negVector = negRotation * up;
            Vector3 newDirection;
            //other.GetContact(0).point.z;
            if (other.GetContact(0).point.z > other.collider.bounds.center.z)
            {
                float difference = other.GetContact(0).point.z - other.collider.bounds.center.z;
                //float percent = difference / other.collider.bounds.max.z;
                float percent = difference / 2f;
                float thePain = -45f * direction.x * percent;
                Quaternion rotation = Quaternion.Euler(0f, thePain, 0f);
                newDirection = rotation * direction;
                //Debug.Log($"thePain: {thePain} percent: {percent} difference: {difference} max: {other.collider.bounds.max.z}");
            }
            else if (other.GetContact(0).point.z < other.collider.bounds.center.z)
            {
                float difference = other.GetContact(0).point.z - other.collider.bounds.center.z;
                float percent = difference / 2f;
                float thePain = -45f * direction.x * percent;
                Quaternion rotation = Quaternion.Euler(0f, thePain, 0f);
                newDirection = rotation * direction;
            }
            else
            {
                newDirection = direction;
            }

            Debug.DrawRay(transform.position, newDirection * 2f, Color.red);
            //Debug.DrawRay(transform.position, negVector * 2f, Color.blue);
            
            Vector3 newVelocity = newDirection * newSpeed;
            rbody.linearVelocity = newVelocity;
            movement = newVelocity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Right Score"))
        {
            rightScore = rightScore + 1;
            Debug.Log($"Right player scored! {leftScore}-{rightScore}");
            if (leftScore >= 11)
            {
                Debug.Log("Game Over, Left Paddle Wins");
                leftScore = 0;
                rightScore = 0;
            } else if (rightScore >= 11)
            {
                Debug.Log("Game Over, Right Paddle Wins");
                leftScore = 0;
                rightScore = 0;
            }
            Rigidbody rbody = GetComponent<Rigidbody>();
            rbody.linearVelocity = new Vector3(0f, 0f, 0f);
            rbody.position = new Vector3(0f, 0f, 0f);
            rbody.linearVelocity = new Vector3(-ballSpeed, 0f, 0f);
            movement = rbody.linearVelocity;
        } else if (other.gameObject.CompareTag("Left Score"))
        {
            leftScore = leftScore + 1;
            Debug.Log($"Left player scored! {leftScore}-{rightScore}");
            if (leftScore >= 11)
            {
                Debug.Log("Game Over, Left Paddle Wins");
                leftScore = 0;
                rightScore = 0;
            } else if (rightScore >= 11)
            {
                Debug.Log("Game Over, Right Paddle Wins");
                leftScore = 0;
                rightScore = 0;
            }
            Rigidbody rbody = GetComponent<Rigidbody>();
            rbody.linearVelocity = new Vector3(0f, 0f, 0f);
            rbody.position = new Vector3(0f, 0f, 0f);
            rbody.linearVelocity = new Vector3(ballSpeed, 0f, 0f);
            movement = rbody.linearVelocity;
        }
    }
}
