using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuiScript : MonoBehaviour
{
    public GameObject SetUpGameCanvas(Camera mainCamera, Sprite backSprite, Sprite floorSprite)
    {
        GameObject canvas = new GameObject("GameCanvas");
        canvas.AddComponent<Canvas>();
        canvas.AddComponent<CanvasScaler>();
        canvas.AddComponent<GraphicRaycaster>();
        canvas.AddComponent<Image>();
        canvas.GetComponent<Image>().sprite = backSprite;
        canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
        canvas.GetComponent<Canvas>().worldCamera = mainCamera;
        canvas.GetComponent<Canvas>().sortingOrder = 0;
        canvas.GetComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvas.GetComponent<GraphicRaycaster>().blockingObjects = GraphicRaycaster.BlockingObjects.None;

        GameObject floor = new GameObject("Floor");
        floor.transform.SetParent(canvas.transform);
        floor.AddComponent<Image>();
        floor.GetComponent<Image>().sprite = floorSprite;
        floor.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        floor.GetComponent<RectTransform>().anchorMin = new Vector2(0.0f, 0.0f);
        floor.GetComponent<RectTransform>().anchorMax = new Vector2(1.0f, 0.0f);
        floor.GetComponent<RectTransform>().offsetMin = new Vector2(0.0f, 0.0f);
        floor.GetComponent<RectTransform>().offsetMax = new Vector2(0.0f, 140.0f);
        floor.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        floor.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);

        return canvas;
    }

    public GameObject SetUpMenuCanvas(GameObject parent, Sprite startSprite, Sprite exitSprite, GameManagerRG gM)
    {
        GameObject menuPanel = new GameObject("MenuPanel");
        menuPanel.transform.SetParent(parent.transform);
        menuPanel.AddComponent<RectTransform>();
        menuPanel.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        menuPanel.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        menuPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
        menuPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(300.0f, 300.0f);
        menuPanel.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        menuPanel.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        menuPanel.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);

        GameObject startButton = new GameObject("StartButton");
        startButton.transform.SetParent(menuPanel.transform);
        startButton.AddComponent<Button>();
        startButton.AddComponent<Image>();
        startButton.GetComponent<Image>().sprite = startSprite;
        startButton.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        startButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(75.0f, 0.0f);
        startButton.GetComponent<RectTransform>().sizeDelta = new Vector2(150.0f, 150.0f);
        startButton.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        startButton.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        startButton.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        startButton.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        startButton.GetComponent<Button>().onClick.AddListener(delegate
        {
            gM.StartGame();   
        });

        GameObject exitButton = new GameObject("ExitButton");
        exitButton.transform.SetParent(menuPanel.transform);
        exitButton.AddComponent<Button>();
        exitButton.AddComponent<Image>();
        exitButton.GetComponent<Image>().sprite = exitSprite;
        exitButton.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        exitButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-75.0f, 0.0f);
        exitButton.GetComponent<RectTransform>().sizeDelta = new Vector2(150.0f, 150.0f);
        exitButton.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        exitButton.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        exitButton.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        exitButton.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        exitButton.GetComponent<Button>().onClick.AddListener(delegate { Application.Quit(); });

        return menuPanel;
    }

    public GameObject SetUpEndPanel(GameObject parent, Sprite checkSprite)
    {
        GameObject exitPanel = new GameObject("ExitPanel");
        exitPanel.transform.SetParent(parent.transform);
        exitPanel.AddComponent<RectTransform>();
        exitPanel.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        exitPanel.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        exitPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
        exitPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(300.0f, 300.0f);
        exitPanel.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        exitPanel.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        exitPanel.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);

        GameObject startButton = new GameObject("CheckButton");
        startButton.transform.SetParent(exitPanel.transform);
        startButton.AddComponent<Button>();
        startButton.AddComponent<Image>();
        startButton.GetComponent<Image>().sprite = checkSprite;
        startButton.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        startButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
        startButton.GetComponent<RectTransform>().sizeDelta = new Vector2(150.0f, 150.0f);
        startButton.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        startButton.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        startButton.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        startButton.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        startButton.GetComponent<Button>().onClick.AddListener(delegate
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });

        return exitPanel;
    }

    public void SetUpButtons(Sprite buttonSprite, GameObject gameCanvas, GameObject player,
        LayerMask red, LayerMask green, LayerMask blue)
    {
        GameObject button = new GameObject("RedButton");
        button.transform.SetParent(gameCanvas.transform);
        button.AddComponent<Image>();
        button.AddComponent<Button>();
        button.GetComponent<Image>().sprite = buttonSprite;
        button.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        button.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.0f);
        button.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.0f);
        button.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        button.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        button.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        button.GetComponent<RectTransform>().anchoredPosition = new Vector3(-105.0f, 50.0f, 0.0f);
        button.GetComponent<RectTransform>().sizeDelta = new Vector2(100.0f, 100.0f);
        button.GetComponent<Button>().onClick.AddListener(delegate
        {
            player.GetComponent<PlayerScript>().ChangeColor(red, new Color32(255, 0, 0 , 255));
        });

        button = new GameObject("GreenButton");
        button.transform.SetParent(gameCanvas.transform);
        button.AddComponent<Image>();
        button.AddComponent<Button>();
        button.GetComponent<Image>().sprite = buttonSprite;
        button.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
        button.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.0f);
        button.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.0f);
        button.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        button.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        button.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        button.GetComponent<RectTransform>().anchoredPosition = new Vector3(0.0f, 50.0f, 0.0f);
        button.GetComponent<RectTransform>().sizeDelta = new Vector2(100.0f, 100.0f);
        button.GetComponent<Button>().onClick.AddListener(delegate
        {
            player.GetComponent<PlayerScript>().ChangeColor(green, new Color32(0, 255, 0, 255));
        });

        button = new GameObject("BlueButton");
        button.transform.SetParent(gameCanvas.transform);
        button.AddComponent<Image>();
        button.AddComponent<Button>();
        button.GetComponent<Image>().sprite = buttonSprite;
        button.GetComponent<Image>().color = new Color32(0, 0, 255, 255);
        button.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.0f);
        button.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.0f);
        button.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        button.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        button.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        button.GetComponent<RectTransform>().anchoredPosition = new Vector3(105.0f, 50.0f, 0.0f);
        button.GetComponent<RectTransform>().sizeDelta = new Vector2(100.0f, 100.0f);
        button.GetComponent<Button>().onClick.AddListener(delegate
        {
            player.GetComponent<PlayerScript>().ChangeColor(blue, new Color32(0, 0, 255, 255));
        });
    }
}
