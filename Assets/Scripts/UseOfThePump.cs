using UnityEngine;

public class UseOfThePump : MonoBehaviour
{
    private float explosionRadius = 12;
    private bool exploded;

    private void Awake()
    {
        exploded = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && exploded)
        {
            Explode();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Skill"))
        {
            exploded = true;

        }
    }


    private void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius); //Crea un array con todos los colliders en el radio de explosion

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Zombie"))
            {
                Destroy(hit.gameObject);
            }
        }

        exploded = false;
    }
}
