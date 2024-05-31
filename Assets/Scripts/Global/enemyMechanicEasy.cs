using System;
using System.Collections;
using UnityEngine;

public class enemyMechanicEasy : MonoBehaviour
{
    // RayCasting / collider check
    RaycastHit2D[] allHits = new RaycastHit2D[5]; // record collision up to 5
    BoxCollider2D collider2D;
    bool isSpriteRight = true;


    float flipIntervalSec = 5.0f;
    public float bulletSpeed = 5f;
    public GameObject player;
  
    GameObject bullet;
    private bool bulletShot = false;

    public GameObject bulletPrefab;


    void Awake()
    {
        collider2D = GetComponent<BoxCollider2D>();
        collider2D.enabled = false;
        StartCoroutine(flipEnemyAction(flipIntervalSec));
    }

    void Update()
    {
        if(isEnemyInFrame())
        {
            collider2D.enabled = true;
            checkCollider();
        }
        else
        {
            collider2D.enabled = false;
        }

        
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

    bool isEnemyInFrame()
    {
         var planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        var point = this.transform.position;
        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
                return false;
        }
        return true;
    }

    void checkCollider()
    {
        int numHits;
        if (isSpriteRight)
        {
            numHits = collider2D.Raycast(Vector2.right, allHits);
        }
        else
        {
            numHits = collider2D.Raycast(Vector2.left, allHits);
        }

        if (allHits.Length > 0)
        {
            for (int i = 0; i < numHits; i++)
            {
                //Debug.Log(i + ": " + allHits[i].collider.gameObject.name + " | distance: " + allHits[i].distance);
                if (allHits[0].collider.gameObject.name == "Player")
                {
                    Debug.Log("game Over");

                    // Freeze player control
                    //DestroyImmediate(player.GetComponent<PlayerControl>(), true);
                    //DestroyImmediate(player.GetComponent<Rigidbody2D>(), true);

                    // Play game over animation
                    bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    bulletShot = true;
                }
            }
        }

        Array.Clear(allHits, 0, allHits.Length);

    }

    IEnumerator flipEnemyAction(float seconds)
    {
        while (true)
        {
            yield return new WaitForSeconds(seconds);
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            isSpriteRight = !isSpriteRight;
            transform.localScale = scale;
        }
    }
    }

