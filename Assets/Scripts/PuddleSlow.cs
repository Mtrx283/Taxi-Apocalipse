using UnityEngine;

public class PuddleSlow : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name + " (Tag: " + other.tag + ")");
        
        // Check the colliding object AND its parents for the Player tag
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
        
        // Check the colliding object AND its parents
        MovementCar car = other.GetComponentInParent<MovementCar>();
        
        if (car != null)
        {
            car.ApplySpeedMultiplier(false, speedMultiplier);
            Debug.Log("Slow removed from: " + car.gameObject.name);
        }
    }
}