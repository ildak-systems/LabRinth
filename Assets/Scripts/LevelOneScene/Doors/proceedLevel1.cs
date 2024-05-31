using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proceedLevel1 : MonoBehaviour
{
    public GameObject Player;
    private bool isTouching = false;

    public GameObject doorEnterTextBox;
    private bool textBoxOnScreen = false;

    public Vector3 textBoxOffset = new Vector3(0.4f, 0.27f, -0.1f);
    void Start()
    {
        doorEnterTextBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (textBoxOnScreen)
        {
            doorEnterTextBox.transform.position = Player.transform.position + textBoxOffset;
            // make it appear it for 3 seconds, then deactivate
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("E is pressed");
            if (isTouching)
            {
                doorEnterTextBox.transform.position = Player.transform.position + textBoxOffset;
                doorEnterTextBox.SetActive(true);
                textBoxOnScreen = true;
                StartCoroutine(DeactivateAfterDelay(3f));
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

    IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        doorEnterTextBox.SetActive(false);

        textBoxOnScreen = false;
    }
}
