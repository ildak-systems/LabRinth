using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class proceedLevel2 : MonoBehaviour
{
    private bool levelClearedSignal = false;
    private bool isTouching = false;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    // Start is called before the first frame update
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
            if (levelOneController.levelCleared)
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
                SceneManager.LoadScene("levelOneScene");
                levelOneController.levelCleared = false;
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
