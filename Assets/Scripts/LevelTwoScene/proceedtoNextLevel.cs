using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class proceedtoNextLevel : MonoBehaviour
{
    private bool levelClearedSignal = false;
    private bool isTouching = false;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // play sound and black out the sprite
        if (!levelClearedSignal)
        {
            if (levelTwoController.levelCleared)
            {
                levelClearedSignal = true;
                spriteRenderer.color = Color.black;
                audioSource.Play();
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (levelClearedSignal && isTouching)
            {
                SceneManager.LoadScene("winScene");
                 // or any other current scene
                // play stair noises? 
                return;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTouching = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTouching = false;
        }
            
    }
}
