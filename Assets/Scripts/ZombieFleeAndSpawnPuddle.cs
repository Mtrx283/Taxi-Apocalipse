using UnityEngine;

public class ZombieFleeAndSpawnPuddle : MonoBehaviour
{
   [Header("Flee Settings")]
    [SerializeField] private float detectionRange = 10f; 
    [SerializeField] private float fleeSpeed = 5f; 
    [SerializeField] private float rotationSpeed = 5f;
    
    [Header("Score Settings")]
    [SerializeField] private int scoreValue = 25;
    
    [Header("Puddle Settings")]
    [SerializeField] private GameObject puddlePrefab; 
    [SerializeField] private Vector3 puddleSpawnOffset = new Vector3(0, 0.1f, 0); 

    private Transform player;
    private Rigidbody rb;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Add score
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

            
            SpawnPuddle();

            
            Destroy(gameObject);
        }
    }

    void SpawnPuddle()
    {
        if (puddlePrefab != null)
        {
            Vector3 spawnPosition = transform.position + puddleSpawnOffset;
            Instantiate(puddlePrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Puddle spawned at: " + spawnPosition);
        }
        else
        {
            Debug.LogWarning("Puddle prefab not assigned on " + gameObject.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
