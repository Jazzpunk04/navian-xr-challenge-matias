using UnityEngine;
using UnityEngine.UIElements;

public class PopUpManager : MonoBehaviour
{
    public UIDocument uiDocument;
    public GameObject uiHolder;
    private Label title;
    private Label description;
    private bool isPopUpVisible = false;

    void Start()
    {
        if (uiDocument == null)
        {
            uiDocument = FindObjectOfType<UIDocument>();
        }

        Debug.Assert(uiDocument != null || uiHolder != null, "Either UIDocument or uiHolder must be assigned in the PopUpManager.");

        if (uiDocument != null)
        {
            title = uiDocument.rootVisualElement.Q<Label>("Title");
            description = uiDocument.rootVisualElement.Q<Label>("Description");
        }

        Debug.Assert(title != null, "Title label is not assigned in the PopUpManager. Please ensure a Label named 'Title' exists in the UIDocument.");
        Debug.Assert(description != null, "Description label is not assigned in the PopUpManager. Please ensure a Label named 'Description' exists in the UIDocument.");

        HidePopUp();
    }

    void Update()
    {
        if (isPopUpVisible && Input.GetMouseButtonDown(0))
        {
            HidePopUp();
        }
    }

    public void SetPopUpText(string titleText, string descriptionText)
    {
        if (uiHolder != null)
        {
            uiHolder.SetActive(true);

        }
        else if (uiDocument != null)
        {
            uiDocument.gameObject.SetActive(true);
        }

        if (title != null)
        {
            title.text = titleText;
        }

        if (description != null)
        {
            description.text = descriptionText;
        }

        isPopUpVisible = true;
        Debug.Log($"PopUpManager.SetPopUpText title='{titleText}' description='{descriptionText}' active={uiHolder?.activeSelf ?? uiDocument?.gameObject.activeSelf}");
    }

    public void HidePopUp()
    {
        isPopUpVisible = false;
        if (uiHolder != null)
        {
            uiHolder.SetActive(false);
        }
        else if (uiDocument != null)
        {
            uiDocument.gameObject.SetActive(false);
        }
    }

    public bool IsPopUpVisible()
    {
        return isPopUpVisible;
    }
}
