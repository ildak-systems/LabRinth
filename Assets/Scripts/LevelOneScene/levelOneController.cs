using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class levelOneController : MonoBehaviour
{
    // LevelOneController but script is used in tutorial level

    // General Level variables
    private bool gotKey1 = false;
    private bool gotKey2 = false;

    private bool gotKey3 = false;


    private bool levelCleared = false;

    // Level specific game object prefabs
    public GameObject easyEnemyPrefab;
    public GameObject trophyUIPrefab;
    private GameObject trophyUI1;
    private GameObject trophyUI2;
    private GameObject trophyUI3;
    public GameObject keyPrefab;
    private GameObject key1;
    private GameObject key2;
    private GameObject key3;
    public GameObject playerPrefab;
    private GameObject player;

    public GameObject MainCamera;
    public UnityEngine.Vector3 cameraOffset = new UnityEngine.Vector3 (1, 1, -10);

    void Start()
    {
        // Player
        player = Instantiate(playerPrefab, new UnityEngine.Vector3(-3.929f, -3.578f, -0.2f), UnityEngine.Quaternion.identity);

        // Enemies
        GameObject easyEnemy = Instantiate(easyEnemyPrefab, new UnityEngine.Vector3(5.54f, -3.57f, -0.2f), UnityEngine.Quaternion.identity);

        // keys
        key1 = Instantiate(keyPrefab, new UnityEngine.Vector3(3.291049f, -2.781418f, -0.423f), UnityEngine.Quaternion.identity);
        key2 = Instantiate(keyPrefab, new UnityEngine.Vector3(8.373f ,-3.636769f ,-0.423f), UnityEngine.Quaternion.identity);
        key3 = Instantiate(keyPrefab, new UnityEngine.Vector3(7.900255f ,-3.636769f, -0.423f), UnityEngine.Quaternion.identity);

        // UI for keys
        trophyUI1 = Instantiate(trophyUIPrefab, new UnityEngine.Vector3(0,0,0), UnityEngine.Quaternion.identity);
        trophyUI2 = Instantiate(trophyUIPrefab, new UnityEngine.Vector3(0,0,0), UnityEngine.Quaternion.identity);
        trophyUI3 = Instantiate(trophyUIPrefab, new UnityEngine.Vector3(0,0,0), UnityEngine.Quaternion.identity);
    }

    void LateUpdate()
    {
        MainCamera.transform.position = player.transform.position + cameraOffset;
    }

    void Update()
    {
        // Check for active status for each key indvidually - active status changes individually thorugh prefab instantiation
        // There is probably a better way to program the key / player mechanics - but keep this for now
        if (!key1.activeSelf && !gotKey1)
        {
            gotKey1 = true;
            Debug.Log("got key1");
        }

        if (!key2.activeSelf && !gotKey2)
        {
            gotKey2 = true;
            Debug.Log("got key2");
        }

        if (!key3.activeSelf && !gotKey3)
        {
            gotKey3 = true;
            Debug.Log("got key3");
        }

        if (gotKey1 && gotKey2 && gotKey3)
        {
            levelCleared = true;
        }
    }
    
}
