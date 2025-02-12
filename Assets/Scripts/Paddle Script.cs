using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleScript : MonoBehaviour
{
    public float maxPaddleSpeed = 1f;

    public float paddleForce = 1f;

    public float speed = 0;
    
    public AudioClip paddleSound;
    
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    private Vector2 _moveDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //BoxCollider c = GetComponent<BoxCollider>();
        //float max = c.bounds.max.z;
        //float min = c.bounds.min.z;
        //Debug.Log($"max: {max}, min: {min}");
    }

    void OnMove(InputValue value)
    {
        Vector2 movementVector = value.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    // Update is called once per frame
    void Update()
    {
        //float movementAxis = Input.GetAxis("LeftPaddle");
        //Transform paddleTransform = GetComponent<Transform>();
        
        //Vector3 newPosition = paddleTransform.position + new Vector3(0f, 0f, movementAxis * maxPaddleSpeed *Time.deltaTime);
        //newPosition.z = Math.Clamp(newPosition.z, -2.2f, 2.2f);
        
        //paddleTransform.position = newPosition;
    }

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Wall") && !other.gameObject.CompareTag("No Sound"))
        {
            AudioSource audioSrc = GetComponent<AudioSource>();
            audioSrc.clip = paddleSound;
            float shift = other.gameObject.GetComponent<Rigidbody>().linearVelocity.magnitude;
            //Debug.Log(shift);
            shift = shift * 0.01f;
            audioSrc.pitch = 1 + shift;
            audioSrc.Play();
        }
    }
}
