using System.Collections;
using UnityEngine;

public class enemyMechanicEasy : MonoBehaviour
{
    float flipIntervalSec = 5.0f;
    public float bulletSpeed = 5f;
    BoxCollider2D boxCollider2D;
    GameObject bullet;
    private bool bulletShot = false;
    // Black enemy (Easy) : Flip every 5 seconds
    // Green enemy (Medium) : Flip every 3 seconds, ability to move around a little bit but not random
    // Red enemy (Hard) : Flip every 3 seconds, random movements
    // Boss (Very Hard) : Random chance of seeing player through walls

    public GameObject bulletPrefab;
    
    void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        StartCoroutine(flipEnemyAction(flipIntervalSec));
    }

    // Update is called once per frame
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
        while(true)
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
            Destroy(levelOneController.player.GetComponent<PlayerControl>());
            Destroy(levelOneController.player.GetComponent<Rigidbody2D>());

            // Play game over animation
            bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            bulletShot = true;
        }
    }
}
