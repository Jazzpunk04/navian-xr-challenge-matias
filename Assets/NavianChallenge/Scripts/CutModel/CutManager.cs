using UnityEngine;
using UnityEngine.UIElements;

public class CutManager : MonoBehaviour
{
    public GameObject cutX;
    public GameObject cutY;
    public GameObject cutZ;
    public UIDocument cutUIDocument;

    private Slider sliderX;
    private Slider sliderY;
    private Slider sliderZ;

    void Start()
    {
        if (cutUIDocument == null)
        {
            Debug.LogError("CutManager: cutUIDocument is not assigned.");
            return;
        }

        var root = cutUIDocument.rootVisualElement;
        sliderX = root.Q<Slider>("SliderX");
        sliderY = root.Q<Slider>("SliderY");
        sliderZ = root.Q<Slider>("SliderZ");

        Debug.Assert(sliderX != null, "SliderX not found in Cut UI document.");
        Debug.Assert(sliderY != null, "SliderY not found in Cut UI document.");
        Debug.Assert(sliderZ != null, "SliderZ not found in Cut UI document.");

        if (sliderX != null)
        {
            sliderX.highValue = 110;
            sliderX.RegisterValueChangedCallback(evt => UpdateCutValue(cutX, evt.newValue));
        }

        if (sliderY != null)
        {
            sliderY.highValue = 110;
            sliderY.RegisterValueChangedCallback(evt => UpdateCutValue(cutY, evt.newValue));
        }

        if (sliderZ != null)
        {
            sliderZ.highValue = 110;
            sliderZ.RegisterValueChangedCallback(evt => UpdateCutValue(cutZ, evt.newValue));
        }

        // Apply initial values from sliders if available
        if (sliderX != null) UpdateCutValue(cutX, sliderX.value);
        if (sliderY != null) UpdateCutValue(cutY, sliderY.value);
        if (sliderZ != null) UpdateCutValue(cutZ, sliderZ.value);
    }

    private void UpdateCutValue(GameObject cutObject, float value)
    {
        if (cutObject == null)
        {
            return;
        }

        var objectCut = cutObject.GetComponent<ObjectCutter>();
        if (objectCut == null)
        {
            Debug.LogWarning($"CutManager: GameObject '{cutObject.name}' is missing ObjectCut component.");
            return;
        }
        switch (objectCut.GetAxis())
        {
            case 0: // X-axis
                cutObject.transform.position = new Vector3(value, cutObject.transform.position.y, cutObject.transform.position.z);
                break;
            case 1: // Y-axis
                cutObject.transform.position = new Vector3(cutObject.transform.position.x, value, cutObject.transform.position.z);
                break;
            case 2: // Z-axis
                cutObject.transform.position = new Vector3(cutObject.transform.position.x, cutObject.transform.position.y, value);
                break;
            default:
                Debug.LogWarning($"CutManager: GameObject '{cutObject.name}' has an invalid axis value.");
                break;
        }
    }
}
