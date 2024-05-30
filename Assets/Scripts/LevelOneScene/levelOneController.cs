using System.Collections;
using UnityEngine;

public class levelOneController : MonoBehaviour
{
    // LevelOneController but script is used in tutorial level

    // General Level variables
    private bool gotKey1 = false;
    private bool gotKey2 = false;
    private bool gotKey3 = false;
    public static bool levelCleared = false;

    // Level specific game object prefabs
    public GameObject easyEnemyPrefab;
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
    public GameObject playerPrefab;
    public static GameObject player;

    public Camera MainCamera;
    public UnityEngine.Vector3 cameraOffset = new UnityEngine.Vector3 (1, 1, -10);
    public UnityEngine.Vector2 UIOffset = new UnityEngine.Vector2(0,0);
    public Canvas canvas;
    private RectTransform canvasRect;
    

    void Start()
    {
        // Canvas
        canvasRect = canvas.GetComponent<RectTransform>();

        Debug.Log(canvasRect.rect.width);
        Debug.Log(canvasRect.rect.height);
        // Camera
        MainCamera = Camera.main;

        // Player
        player = Instantiate(playerPrefab, new UnityEngine.Vector3(-3.929f, -3.578f, -0.2f), UnityEngine.Quaternion.identity);

        // Enemies
        GameObject easyEnemy = Instantiate(easyEnemyPrefab, new UnityEngine.Vector3(5.54f, -3.57f, -0.2f), UnityEngine.Quaternion.identity);

        // keys
        key1 = Instantiate(keyPrefab, new UnityEngine.Vector3(3.291049f, -2.781418f, -0.423f), UnityEngine.Quaternion.identity);
        key2 = Instantiate(keyPrefab, new UnityEngine.Vector3(8.373f ,-3.636769f ,-0.423f), UnityEngine.Quaternion.identity);
        key3 = Instantiate(keyPrefab, new UnityEngine.Vector3(7.900255f ,-3.636769f, -0.423f), UnityEngine.Quaternion.identity);

        // UI for keys
        trophyUI1 = Instantiate(trophyUIPrefab, new UnityEngine.Vector3((canvasRect.rect.width / 2) - 25, (canvasRect.rect.height / 2) - 50, 0), UnityEngine.Quaternion.identity);
        trophyUI1.transform.SetParent(canvas.transform, false);
        trophyUI2 = Instantiate(trophyUIPrefab, new UnityEngine.Vector3((canvasRect.rect.width / 2) - 50, (canvasRect.rect.height / 2) - 50, 0), UnityEngine.Quaternion.identity);
        trophyUI2.transform.SetParent(canvas.transform, false);
        trophyUI3 = Instantiate(trophyUIPrefab, new UnityEngine.Vector3((canvasRect.rect.width / 2) - 75, (canvasRect.rect.height / 2) - 50, 0), UnityEngine.Quaternion.identity);
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

    void Update()
    {
        // Check for active status for each key indvidually - active status changes individually thorugh prefab instantiation
        // There is probably a better way to program the key / player mechanics - but keep this for now
        if (!key1.activeSelf && !gotKey1)
        {
            gotKey1 = true;
            Debug.Log("got key1");
            spriteRendererTU1.color = Color.white;
        }

        if (!key2.activeSelf && !gotKey2)
        {
            gotKey2 = true;
            Debug.Log("got key2");
            spriteRendererTU2.color = Color.white;
        }

        if (!key3.activeSelf && !gotKey3)
        {
            gotKey3 = true;
            Debug.Log("got key3");
            spriteRendererTU3.color = Color.white;
        }

        if (gotKey1 && gotKey2 && gotKey3)
        {
            levelCleared = true;
        }
    }
    
}
