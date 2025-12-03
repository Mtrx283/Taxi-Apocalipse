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
        
        MovementCar car = other.GetComponentInParent<MovementCar>();
        
        if (car != null)
        {
            car.ClampVelocity(3);
            
        }
    }

}