using UnityEngine;

public class ZombieFlee : MonoBehaviour
{
    [SerializeField] private float detectionRange = 10f; 
    [SerializeField] private float fleeSpeed = 5f; 
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private int scoreValue = 25;

    private Transform player;
    private Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
            if (scoreManager != null)
            {
                if (ScoreManager.isDoubleScoreActive)
                {
                    scoreManager.AddScore(scoreValue * 2);
                }
                else
                {
                    scoreManager.AddScore(scoreValue);
                }

            }

            Destroy(gameObject);
        }


    }

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            FleeFromPlayer();
        }
    }

    void FleeFromPlayer()
    {
        Vector3 fleeDirection = (transform.position - player.position).normalized;

        fleeDirection.y = 0;

        transform.position += fleeDirection * fleeSpeed * Time.deltaTime;

        if (fleeDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(fleeDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
