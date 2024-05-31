using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("gameOverScene"));
        //SceneManager.UnloadSceneAsync("TutorialScene"); // or any current scene
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            SceneManager.LoadScene("tutorialScene");
            return;
        }
    }
}
