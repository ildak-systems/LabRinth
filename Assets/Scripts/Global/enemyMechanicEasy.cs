using System.Collections;
using UnityEngine;

public class enemyMechanicEasy : MonoBehaviour
{
    bool playerKillable = false;
    float flipIntervalSec = 5.0f;
    public float bulletSpeed = 5f;
    public GameObject player;
    BoxCollider2D boxCollider2D;
    GameObject bullet;
    private bool bulletShot = false;

    public GameObject bulletPrefab;
    public LayerMask barrierLayer;  // Layer mask for barriers
    public float detectionRange = 10f;  // Maximum range for detection

    void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        StartCoroutine(flipEnemyAction(flipIntervalSec));
    }

    void Update()
    {
        if (bulletShot)
        {
            if (transform.localScale.x > 0)
            {
                bullet.transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
            }
            else
            {
                bullet.transform.Translate(Vector2.left * bulletSpeed * Time.deltaTime);
            }
        }        
    }

    IEnumerator flipEnemyAction(float seconds)
    {
        while (true)
        {
            yield return new WaitForSeconds(seconds);
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Game Over");

            // Freeze player control
            Destroy(player.GetComponent<PlayerControl>());
            Destroy(player.GetComponent<Rigidbody2D>());

            // Play game over animation
            bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            bulletShot = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "barrier")
        {
            Debug.Log("touching barrier");
        }
    }

    bool DetectPlayer()
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        // Check if the player is within detection range
        if (distanceToPlayer <= detectionRange)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, detectionRange, ~barrierLayer);
            Debug.DrawRay(transform.position, directionToPlayer, Color.red);  // Visualize the ray in the scene view

            if (hit.collider != null && hit.collider.gameObject == player)
            {
                Debug.Log("Player detected!");
                return true;
                // Insert logic for when the player is detected
                //OnPlayerDetected();
            }
            else
            {
                Debug.Log("Barrier in the way, player not detected.");
                return false;
                // Insert logic for when the barrier is in the way
            }
        }
        return true;
    }
}
