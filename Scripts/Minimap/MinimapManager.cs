using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class AreaMapPosition
{
    public GameObject areaGameObject;
    public Vector2 mapPosition;
    public string areaName;
}

public class MinimapManager : MonoBehaviour
{
    [Header("Minimap UI")]
    public GameObject minimapPanel;
    public Image minimapImage;
    public Image playerMarker;
    public KeyCode toggleKey = KeyCode.M;

    [Header("Map Configuration")]
    public Texture2D mapTexture;

    [Header("Area Positions")]
    public List<AreaMapPosition> areaPositions = new List<AreaMapPosition>();

    private bool isMinimapVisible = false;
    private RectTransform mapRect;
    private RectTransform markerRect;
    private string currentActiveArea = "";

    void Start()
    {
        SetupMinimap();
        SetupDefaultAreaPositions();
        minimapPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleMinimap();
        }

        if (isMinimapVisible)
        {
            CheckActiveArea();
        }
    }

    void SetupMinimap()
    {
        if (minimapImage != null && mapTexture != null)
        {
            minimapImage.sprite = Sprite.Create(mapTexture,
                new Rect(0, 0, mapTexture.width, mapTexture.height),
                new Vector2(0.5f, 0.5f));
        }

        if (minimapImage != null)
            mapRect = minimapImage.GetComponent<RectTransform>();

        if (playerMarker != null)
        {
            markerRect = playerMarker.GetComponent<RectTransform>();
            playerMarker.color = Color.red;
        }
    }

    void SetupDefaultAreaPositions()
    {
        // Find area GameObjects in the scene and set up default positions
        string[] areaNames = {
            "F1C-001", "F1C-002",
            "F1RW-001", "F1RW-002", "F1RW-003",
            "F1LW-001", "F1LW-002", "F1LW-003",
            "F1RWD-001", "F1RWD-002", "F1RWD-003", "F1RWD-004", "F1RWD-005",
            "F1LWD-001", "F1LWD-002", "F1LWD-003", "F1LWD-004", "F1LWD-005",
            "Hydraulics", "MachineShop", "ResearchCenter",
            "MechanicalEngineering", "WeldingLaboratory", "MachineShopII", "HydraulicsII"
        };

        Vector2[] defaultPositions = {
            new Vector2(0.5f, 0.8f),   // F1C-001 (Center top)
            new Vector2(0.5f, 0.6f),   // F1C-002 (Center)
            new Vector2(0.7f, 0.7f),   // F1RW-001 (Right side)
            new Vector2(0.8f, 0.5f),   // F1RW-002
            new Vector2(0.9f, 0.3f),   // F1RW-003
            new Vector2(0.3f, 0.7f),   // F1LW-001 (Left side)
            new Vector2(0.2f, 0.5f),   // F1LW-002
            new Vector2(0.1f, 0.3f),   // F1LW-003
            new Vector2(0.75f, 0.65f), // F1RWD-001 (Right doors)
            new Vector2(0.85f, 0.55f), // F1RWD-002
            new Vector2(0.95f, 0.45f), // F1RWD-003
            new Vector2(0.85f, 0.35f), // F1RWD-004
            new Vector2(0.95f, 0.25f), // F1RWD-005
            new Vector2(0.25f, 0.65f), // F1LWD-001 (Left doors)
            new Vector2(0.15f, 0.55f), // F1LWD-002
            new Vector2(0.05f, 0.45f), // F1LWD-003
            new Vector2(0.15f, 0.35f), // F1LWD-004
            new Vector2(0.05f, 0.25f), // F1LWD-005
            new Vector2(0.75f, 0.6f),  // Hydraulics
            new Vector2(0.85f, 0.4f),  // MachineShop
            new Vector2(0.9f, 0.2f),   // ResearchCenter
            new Vector2(0.25f, 0.6f),  // MechanicalEngineering
            new Vector2(0.15f, 0.4f),  // WeldingLaboratory
            new Vector2(0.8f, 0.3f),   // MachineShopII
            new Vector2(0.7f, 0.5f)    // HydraulicsII
        };

        // Auto-populate area positions by finding GameObjects
        for (int i = 0; i < areaNames.Length && i < defaultPositions.Length; i++)
        {
            GameObject areaGO = GameObject.Find(areaNames[i]);
            if (areaGO != null)
            {
                AreaMapPosition newArea = new AreaMapPosition
                {
                    areaGameObject = areaGO,
                    mapPosition = defaultPositions[i],
                    areaName = areaNames[i]
                };
                areaPositions.Add(newArea);
            }
        }
    }

    void CheckActiveArea()
    {
        foreach (AreaMapPosition area in areaPositions)
        {
            if (area.areaGameObject != null && area.areaGameObject.activeInHierarchy)
            {
                if (currentActiveArea != area.areaName)
                {
                    currentActiveArea = area.areaName;
                    UpdatePlayerMarkerPosition(area.mapPosition);
                    Debug.Log($"Player moved to: {area.areaName}");
                }
                return; // Found active area, exit loop
            }
        }
    }

    void UpdatePlayerMarkerPosition(Vector2 normalizedPosition)
    {
        if (mapRect == null || markerRect == null) return;

        // Convert normalized position (0-1) to map coordinates
        Vector2 mapPosition = new Vector2(
            (normalizedPosition.x - 0.5f) * mapRect.rect.width,
            (normalizedPosition.y - 0.5f) * mapRect.rect.height
        );

        markerRect.anchoredPosition = mapPosition;
    }

    public void ToggleMinimap()
    {
        isMinimapVisible = !isMinimapVisible;
        minimapPanel.SetActive(isMinimapVisible);

        if (isMinimapVisible)
        {
            CheckActiveArea(); // Update position when opening
        }
    }

    public void ShowMinimap()
    {
        isMinimapVisible = true;
        minimapPanel.SetActive(true);
        CheckActiveArea();
    }

    public void HideMinimap()
    {
        isMinimapVisible = false;
        minimapPanel.SetActive(false);
    }

    // Method to manually set an area as active (useful for debugging)
    public void SetActiveArea(string areaName)
    {
        foreach (AreaMapPosition area in areaPositions)
        {
            if (area.areaName == areaName)
            {
                currentActiveArea = areaName;
                UpdatePlayerMarkerPosition(area.mapPosition);
                break;
            }
        }
    }

    // Method to add new area positions at runtime
    public void AddAreaPosition(GameObject areaGameObject, Vector2 mapPosition, string areaName)
    {
        AreaMapPosition newArea = new AreaMapPosition
        {
            areaGameObject = areaGameObject,
            mapPosition = mapPosition,
            areaName = areaName
        };
        areaPositions.Add(newArea);
    }
}
