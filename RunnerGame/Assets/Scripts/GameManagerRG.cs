using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerRG : MonoBehaviour
{
    public LayerMask red;
    public LayerMask green;
    public LayerMask blue;
    public Camera mainCamera;
    public Sprite backSprite;
    public Sprite tileSprite;
    public Sprite buttonSprite;
    public Sprite startSprite;
    public Sprite exitSprite;
    public Sprite checkSprite;
    public RuntimeAnimatorController playerAnimatorController;
    public RuntimeAnimatorController enemyAnimatorController;

    private GuiScript gui;
    private GameObject gameCanvas;
    private GameObject menuPanel;
    private CreateScript create;
    private GameObject player;

    private float speed;
	// Use this for initialization
	void Start ()
    {
        speed = 8.0f;
        create = gameObject.AddComponent<CreateScript>();
        gui = gameObject.AddComponent<GuiScript>();
        player = create.CreatePlayer(new Vector3(-5.0f, 0.0f, 0.0f), new Vector3(1.0f, 1.0f, 1.0f),
            5, new Vector2(3.0f, 5.0f), 0.0f, playerAnimatorController, transform);
        gameCanvas = gui.SetUpGameCanvas(mainCamera, backSprite, tileSprite);
        menuPanel = gui.SetUpMenuCanvas(gameCanvas, startSprite, exitSprite, this);
        //StartGame();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void End()
    {
        StopAllCoroutines();
        player.GetComponent<BoxCollider2D>().enabled = false;
        player.GetComponent<Animator>().SetInteger("StateIndex", 2);
        Button[] buttons = gameCanvas.GetComponentsInChildren<Button>();
        foreach (Button but in buttons)
        {
            but.enabled = false;
        }
        gui.SetUpEndPanel(gameCanvas, checkSprite);
    }

    public void StartGame()
    {
        gui.SetUpButtons(buttonSprite, gameCanvas, player, red, green, blue);
        player.GetComponent<Animator>().SetInteger("StateIndex", 1);
        StartCoroutine(SpawnEnemies());
        Destroy(menuPanel);
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float time = Random.Range(1.0f, 2.0f);
            int enemyType = Random.Range(1, 3);
            int i = Random.Range(0, 3);
            Color32 col = new Color32(0, 0, 0, 255);
            LayerMask layer = red;
            switch (i)
            {
                case 0:
                    col = new Color32(255, 0, 0, 255);
                    layer = red;
                    break;
                case 1:
                    col = new Color32(0, 255, 0, 255);
                    layer = green;
                    break;
                case 2:
                    col = new Color32(0, 0, 255, 255);
                    layer = blue;
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(time);
            create.CreateEnemy(layer, enemyType, col, speed, new Vector3(15.0f, 0.0f, 0.0f),
                new Vector2(3f, 5f), 3, new Vector3(-1.0f, 1.0f, 1.0f), enemyAnimatorController);
        }
    }
}
