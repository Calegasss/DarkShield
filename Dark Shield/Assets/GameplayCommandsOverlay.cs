using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayCommandsOverlay : MonoBehaviour
{
    private static GameplayCommandsOverlay instance;
    private static bool commandsShownThisSession;

    private Canvas overlayCanvas;
    private GameObject panel;
    private bool overlayVisible;
    private float previousTimeScale = 1f;
    private float canCloseAfterRealtime;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void Initialize()
    {
        if (instance != null)
        {
            return;
        }

        GameObject bootstrap = new GameObject("GameplayCommandsOverlay");
        DontDestroyOnLoad(bootstrap);
        instance = bootstrap.AddComponent<GameplayCommandsOverlay>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        TryShowForScene(SceneManager.GetActiveScene());
    }

    private void Update()
    {
        if (!overlayVisible)
        {
            return;
        }

        if (Time.realtimeSinceStartup < canCloseAfterRealtime)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return) ||
            Input.GetKeyDown(KeyCode.KeypadEnter) ||
            Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.Escape) ||
            Input.GetMouseButtonDown(0))
        {
            HideOverlay();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        TryShowForScene(scene);
    }

    private void TryShowForScene(Scene scene)
    {
        if (commandsShownThisSession)
        {
            return;
        }

        if (scene.name == "Menu")
        {
            return;
        }

        ShowOverlay();
        commandsShownThisSession = true;
    }

    private void ShowOverlay()
    {
        EnsureOverlay();

        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        canCloseAfterRealtime = Time.realtimeSinceStartup + 0.2f;

        panel.SetActive(true);
        overlayVisible = true;
    }

    private void HideOverlay()
    {
        overlayVisible = false;
        Time.timeScale = previousTimeScale;

        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    private void EnsureOverlay()
    {
        if (overlayCanvas != null)
        {
            return;
        }

        Font font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");

        GameObject canvasObject = new GameObject("CommandsOverlayCanvas");
        canvasObject.transform.SetParent(transform, false);

        overlayCanvas = canvasObject.AddComponent<Canvas>();
        overlayCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        overlayCanvas.sortingOrder = 5000;

        CanvasScaler scaler = canvasObject.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1920f, 1080f);
        scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        scaler.matchWidthOrHeight = 0.5f;

        canvasObject.AddComponent<GraphicRaycaster>();

        GameObject blocker = CreateUIObject("Blocker", canvasObject.transform);
        Image blockerImage = blocker.AddComponent<Image>();
        blockerImage.color = new Color(0.03f, 0.02f, 0.05f, 0.82f);
        StretchRect(blocker.GetComponent<RectTransform>());

        panel = CreateUIObject("Panel", blocker.transform);
        Image panelImage = panel.AddComponent<Image>();
        panelImage.color = new Color(0.10f, 0.09f, 0.12f, 0.96f);

        Outline panelOutline = panel.AddComponent<Outline>();
        panelOutline.effectColor = new Color(0.75f, 0.64f, 0.38f, 0.9f);
        panelOutline.effectDistance = new Vector2(3f, -3f);

        RectTransform panelRect = panel.GetComponent<RectTransform>();
        panelRect.anchorMin = new Vector2(0.5f, 0.5f);
        panelRect.anchorMax = new Vector2(0.5f, 0.5f);
        panelRect.pivot = new Vector2(0.5f, 0.5f);
        panelRect.sizeDelta = new Vector2(980f, 640f);
        panelRect.anchoredPosition = Vector2.zero;

        GameObject topBar = CreateUIObject("TopBar", panel.transform);
        Image topBarImage = topBar.AddComponent<Image>();
        topBarImage.color = new Color(0.25f, 0.11f, 0.11f, 1f);
        RectTransform topBarRect = topBar.GetComponent<RectTransform>();
        topBarRect.anchorMin = new Vector2(0f, 1f);
        topBarRect.anchorMax = new Vector2(1f, 1f);
        topBarRect.pivot = new Vector2(0.5f, 1f);
        topBarRect.sizeDelta = new Vector2(0f, 96f);
        topBarRect.anchoredPosition = Vector2.zero;

        CreateText(
            "Title",
            topBar.transform,
            font,
            "COMANDOS",
            42,
            FontStyle.Bold,
            TextAnchor.MiddleCenter,
            new Color(0.94f, 0.86f, 0.68f, 1f),
            new Vector2(0f, 0f),
            new Vector2(1f, 1f),
            new Vector2(0f, 0f));

        CreateText(
            "Subtitle",
            panel.transform,
            font,
            "Domine o Dark Shield antes de entrar na batalha.",
            24,
            FontStyle.Italic,
            TextAnchor.UpperCenter,
            new Color(0.78f, 0.76f, 0.72f, 1f),
            new Vector2(70f, -130f),
            new Vector2(840f, 40f),
            new Vector2(0.5f, 1f));

        CreateText(
            "CommandsLeft",
            panel.transform,
            font,
            "Mover\nPular\nRolar\nAtacar",
            30,
            FontStyle.Bold,
            TextAnchor.UpperLeft,
            new Color(0.94f, 0.86f, 0.68f, 1f),
            new Vector2(110f, -210f),
            new Vector2(260f, 230f),
            new Vector2(0f, 1f));

        CreateText(
            "CommandsRight",
            panel.transform,
            font,
            "A / D ou Setas\nEspaco\nR\nF",
            30,
            FontStyle.Normal,
            TextAnchor.UpperLeft,
            new Color(0.92f, 0.92f, 0.92f, 1f),
            new Vector2(420f, -210f),
            new Vector2(320f, 230f),
            new Vector2(0f, 1f));

        CreateText(
            "InteractionsTitle",
            panel.transform,
            font,
            "INTERACOES",
            26,
            FontStyle.Bold,
            TextAnchor.UpperLeft,
            new Color(0.82f, 0.38f, 0.38f, 1f),
            new Vector2(110f, -420f),
            new Vector2(320f, 40f),
            new Vector2(0f, 1f));

        CreateText(
            "InteractionsBody",
            panel.transform,
            font,
            "E  para usar fogueira e jarros\nW  para entrar em portas",
            24,
            FontStyle.Normal,
            TextAnchor.UpperLeft,
            new Color(0.88f, 0.88f, 0.88f, 1f),
            new Vector2(110f, -470f),
            new Vector2(520f, 110f),
            new Vector2(0f, 1f));

        CreateText(
            "Tip",
            panel.transform,
            font,
            "Dica: no codigo atual nao existe comando de agachar.",
            22,
            FontStyle.Italic,
            TextAnchor.UpperLeft,
            new Color(0.78f, 0.76f, 0.72f, 1f),
            new Vector2(110f, -560f),
            new Vector2(700f, 36f),
            new Vector2(0f, 1f));

        CreateText(
            "Footer",
            panel.transform,
            font,
            "Pressione Enter, Espaco, Esc ou clique para continuar",
            22,
            FontStyle.Bold,
            TextAnchor.LowerCenter,
            new Color(0.94f, 0.86f, 0.68f, 1f),
            new Vector2(0f, 40f),
            new Vector2(760f, 40f),
            new Vector2(0.5f, 0f));

        panel.SetActive(false);
    }

    private static GameObject CreateUIObject(string objectName, Transform parent)
    {
        GameObject uiObject = new GameObject(objectName, typeof(RectTransform));
        uiObject.transform.SetParent(parent, false);
        return uiObject;
    }

    private static void StretchRect(RectTransform rectTransform)
    {
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
    }

    private static void CreateText(
        string objectName,
        Transform parent,
        Font font,
        string content,
        int fontSize,
        FontStyle fontStyle,
        TextAnchor alignment,
        Color color,
        Vector2 anchoredPosition,
        Vector2 sizeDelta,
        Vector2 pivot)
    {
        GameObject textObject = CreateUIObject(objectName, parent);
        Text text = textObject.AddComponent<Text>();
        text.font = font;
        text.text = content;
        text.fontSize = fontSize;
        text.fontStyle = fontStyle;
        text.alignment = alignment;
        text.color = color;
        text.horizontalOverflow = HorizontalWrapMode.Wrap;
        text.verticalOverflow = VerticalWrapMode.Overflow;

        Outline outline = textObject.AddComponent<Outline>();
        outline.effectColor = new Color(0f, 0f, 0f, 0.45f);
        outline.effectDistance = new Vector2(1.5f, -1.5f);

        RectTransform rectTransform = textObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = pivot;
        rectTransform.anchorMax = pivot;
        rectTransform.pivot = pivot;
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = sizeDelta;
    }
}
