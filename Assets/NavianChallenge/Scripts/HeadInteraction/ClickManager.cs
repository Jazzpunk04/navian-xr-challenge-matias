//using System.Diagnostics;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private Camera mainCamera;
    private const float RAYCAST_MAX_DISTANCE = 1000f;
    private PopUpManager popUpManager;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Start()
    {
        popUpManager = GetComponent<PopUpManager>();
        UnityEngine.Debug.Assert(popUpManager != null, "PopUpManager not found in the scene. Please ensure there is a PopUpManager in the scene.");
    }

    void Update()
    {
        // 0 detects Left Click
        if (!popUpManager.IsPopUpVisible())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit[] hits = Physics.RaycastAll(ray, RAYCAST_MAX_DISTANCE);

                // Iterate through all hits to find one that's not cut away
                foreach (RaycastHit hit in hits)
                {
                    if (IsPointRendered(hit))
                    {
                        // This is the GameObject you clicked on a visible part
                        GameObject clickedObject = hit.transform.gameObject;
                        Debug.Log("Clicked on: " + clickedObject.name);
                        popUpManager.SetPopUpText(clickedObject.name, "This is a description for " + clickedObject.name);
                        break; // Stop at the first valid hit
                    }
                }
            }
        }

    }

    /// <summary>
    /// Checks if a raycast hit point is rendered by the shader (not clipped/cut away)
    /// </summary>
    private bool IsPointRendered(RaycastHit hit)
    {
        Renderer renderer = hit.collider.GetComponent<Renderer>();
        if (renderer == null)
            return true; // No renderer, assume it's rendered

        // Check all materials for the CutShader
        foreach (Material material in renderer.materials)
        {
            if (material.shader.name == "Custom/CutShader")
            {
                Vector3 worldPos = hit.point;

                // Get the cut plane positions from the material
                float cutX = material.GetFloat("_CutX");
                float cutY = material.GetFloat("_CutY");
                float cutZ = material.GetFloat("_CutZ");

                // Replicate the shader's clip logic:
                // clip(cutX - worldPos.x) discards if cutX <= worldPos.x
                // clip(cutY - worldPos.y) discards if cutY <= worldPos.y
                // clip(cutZ - worldPos.z) discards if cutZ <= worldPos.z
                if (cutX <= worldPos.x || cutY <= worldPos.y || cutZ <= worldPos.z)
                {
                    return false; // This point is cut away
                }
            }
        }

        return true; // Point is rendered
    }
}

