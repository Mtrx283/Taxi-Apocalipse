using UnityEngine;
using UnityEngine.InputSystem;

public class MovementCar : MonoBehaviour
{
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float deceleration = 5f;
    [SerializeField] private float reverseAcceleration = 6f; 
    [SerializeField] private float maxSpeed = 20f; 
    [SerializeField] private float maxReverseSpeed = 8f; 
    [SerializeField] private float turnSpeed = 50f;  

    private Rigidbody rb;
    private WheelCollider[] wheels;
    private Vector2 input;

    private float currentSpeed = 0f;
    private float speedMultiplier = 1f; 
    public bool isDashing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        wheels = GetComponentsInChildren<WheelCollider>();
        rb.sleepThreshold = 0;
    }

    void Update()
    {
       
        float targetSpeed = input.y * acceleration * 10 * speedMultiplier;
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, Time.deltaTime * 1000);

        foreach (var wheel in wheels)
            wheel.rotationSpeed = currentSpeed * 100;

        Quaternion rotateDelta = Quaternion.Euler(0, input.x * turnSpeed * Time.deltaTime, 0);
        rb.MoveRotation(rb.rotation * rotateDelta);
    }

    public void setMoveSpeed(float newSpeedAdjustment)
    {
        rb.AddForce(transform.forward * newSpeedAdjustment * 100, ForceMode.Impulse);
    }

    private void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDashing && collision.gameObject.CompareTag("Break"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Objeto destruido con dash!");
        }

        if (collision.gameObject.CompareTag("Zombie"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Zombie destruido!");
        }
    }

   
    public void ApplySpeedMultiplier(bool state, float multiplier)
    {
        if (state)
        {
            speedMultiplier = multiplier;
        }
        else
        {
            speedMultiplier = 1f;
        }
        
        Debug.Log("Speed multiplier set to: " + speedMultiplier); 
    }

    public void ClampVelocity(float speed)
    {
        rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, speed);
    }
}