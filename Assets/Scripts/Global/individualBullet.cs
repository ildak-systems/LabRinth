using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class individualBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hit player, game over");
            SceneManager.LoadSceneAsync("gameOverScene");
            return;
        }
    }
}
