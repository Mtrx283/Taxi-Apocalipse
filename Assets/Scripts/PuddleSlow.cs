using UnityEngine;

public class PuddleSlow : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 0.01f;
    [SerializeField] private float puddleLifetime = 30f; 

    private void Start()
    {
        
        Destroy(gameObject, puddleLifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name + " (Tag: " + other.tag + ")");
        
        
        MovementCar car = other.GetComponentInParent<MovementCar>();
        
        if (car != null)
        {
            car.ApplySpeedMultiplier(true, speedMultiplier);
            Debug.Log("Slow applied to: " + car.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exited by: " + other.gameObject.name);
        
        
        MovementCar car = other.GetComponentInParent<MovementCar>();
        
        if (car != null)
        {
            car.ApplySpeedMultiplier(false, speedMultiplier);
            Debug.Log("Slow removed from: " + car.gameObject.name);
        }
    }
}