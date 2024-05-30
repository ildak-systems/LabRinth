using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class levelTwoController : MonoBehaviour
{
    private bool gotKey1 = false;
    private bool gotKey2 = false;
    private bool gotKey3 = false;
    public static bool levelCleared = false;

    public GameObject playerPrefab;
    public GameObject player;

    public Camera MainCamera;
    public UnityEngine.Vector3 cameraOffset = new UnityEngine.Vector3 (1, 1, -10);
    public UnityEngine.Vector2 UIOffset = new UnityEngine.Vector2(0,0);
    public Canvas canvas;
    private RectTransform canvasRect;

    public GameObject trophyUIPrefab;
    private GameObject trophyUI1;
    private SpriteRenderer spriteRendererTU1;
    private GameObject trophyUI2;
    private SpriteRenderer spriteRendererTU2;
    private GameObject trophyUI3;
    private SpriteRenderer spriteRendererTU3;
    public GameObject keyPrefab;
    private GameObject key1;
    private GameObject key2;
    private GameObject key3;


    void Awake()
    {
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("levelOneScene"));
        //SceneManager.UnloadSceneAsync("TutorialScene");

        canvasRect = canvas.GetComponent<RectTransform>();
        Debug.Log(canvasRect.rect.width);
        Debug.Log(canvasRect.rect.height);
        // Camera
        MainCamera = Camera.main;

        //player = Instantiate(playerPrefab, new Vector3(-7.486219f, -5.760704f, -0.2f), Quaternion.identity);

        key1 = Instantiate(keyPrefab, new UnityEngine.Vector3(-4.67901f, -6.870049f, -0.423f), UnityEngine.Quaternion.identity);
        key2 = Instantiate(keyPrefab, new UnityEngine.Vector3(8.373f ,-3.636769f ,-0.423f), UnityEngine.Quaternion.identity);
        key3 = Instantiate(keyPrefab, new UnityEngine.Vector3(7.900255f ,-3.636769f, -0.423f), UnityEngine.Quaternion.identity);

        // UI for keys
        trophyUI1 = Instantiate(trophyUIPrefab, new UnityEngine.Vector3((canvasRect.rect.width / 2) - 25, (canvasRect.rect.height / 2) - 25, 0), UnityEngine.Quaternion.identity);
        trophyUI1.transform.SetParent(canvas.transform, false);
        trophyUI2 = Instantiate(trophyUIPrefab, new UnityEngine.Vector3((canvasRect.rect.width / 2) - 50, (canvasRect.rect.height / 2) - 25, 0), UnityEngine.Quaternion.identity);
        trophyUI2.transform.SetParent(canvas.transform, false);
        trophyUI3 = Instantiate(trophyUIPrefab, new UnityEngine.Vector3((canvasRect.rect.width / 2) - 75, (canvasRect.rect.height / 2) - 25, 0), UnityEngine.Quaternion.identity);
        trophyUI3.transform.SetParent(canvas.transform, false);

        spriteRendererTU1 = trophyUI1.GetComponent<SpriteRenderer>();
        spriteRendererTU2 = trophyUI2.GetComponent<SpriteRenderer>();
        spriteRendererTU3 = trophyUI3.GetComponent<SpriteRenderer>();
    }
    void LateUpdate()
    {
        // Follow player
        MainCamera.transform.position = player.transform.position + cameraOffset;

        // re-set UI location by camera position
    }
    // Update is called once per frame
    void Update()
    {
        if (!key1.activeSelf && !gotKey1)
        {
            gotKey1 = true;
            Debug.Log("got key1");
            spriteRendererTU1.color = Color.white;
        }
    }
}
