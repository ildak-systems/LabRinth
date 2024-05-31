using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    bool gameStart = false;
    public GameObject fadeOut;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        fadeOut.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyUp(KeyCode.E))
        {
            gameStart = true;
        }
        // click
        if (gameStart)
        {
            // fade out
            fadeOut.SetActive(true);
            // slowly lower volume
            audioSource.volume -= 0.3f * Time.deltaTime;

            if (audioSource.volume == 0)
            {
                // Init branch
                SceneManager.LoadScene("transitionScene");
                return;
            }
            
        }
    }
}
