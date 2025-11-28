
using UnityEngine;

public class InteractionWithItems : MonoBehaviour
{
    private Chronometer chronometer;

    void Awake()
    {
        chronometer = GameObject.Find("Canvas").GetComponent<Chronometer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ExtraTime"))
        {
            chronometer.time += 30;
        }
    }
}
