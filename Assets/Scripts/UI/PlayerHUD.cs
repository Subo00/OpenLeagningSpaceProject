using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    private Camera maincamera;

    public static PlayerHUD Instance;

    protected Canvas canvas;
    protected GameObject interactionPrompt;
    protected GameObject timeText;
    protected Transform lastInteractPoint = null;

    protected virtual void Awake()
    {
        canvas = GetComponent<Canvas>();
        interactionPrompt = transform.GetChild(0)?.gameObject;
        timeText = transform.GetChild(1)?.gameObject;

        if (!timeText || !interactionPrompt)
        {
            Debug.LogError("GameObjects on UIManager are missing");
            return;
        }

        if(Instance != null) { Destroy(gameObject); }
        else { Instance = this; }   

        HideInteraction();
    }

    private void Start()
    {
        maincamera = Camera.main;
    }

    public void ShowInteractionOnObject(Vector3 position)
    {
        // Convert the world point to screen point
        Vector3 screenPoint = maincamera.WorldToScreenPoint(position);

        // Check if the point is in front of the camera
        if (screenPoint.z > 0)
        {
            // Convert screen point to canvas space
            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPoint, canvas.worldCamera, out canvasPos);

            // Set the position of the interact button
            interactionPrompt.GetComponent<RectTransform>().anchoredPosition = canvasPos;

            //interactionPrompt.GetComponent<Image>().color = isWhite? Color.white : Color.grey;

            // Optionally, make the interact button active
            interactionPrompt.SetActive(true);
        }
    }

    public void ShowTimeOnObject(Transform interactPoint, float time)
    {
        Vector3 screenPoint = maincamera.WorldToScreenPoint(interactPoint.position);
        if (screenPoint.z > 0)
        {
            // Convert screen point to canvas space
            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPoint, canvas.worldCamera, out canvasPos);

            // Set the position of the interact button
            timeText.GetComponent<RectTransform>().anchoredPosition = canvasPos;
            timeText.GetComponent<TextMeshProUGUI>().text = Mathf.Round(time).ToString();

            if (time < 0.1f)
            {
                timeText.SetActive(false);
            }
            else
            {
                timeText.SetActive(true);
            }
        }
    }


    public void SetInteractPoint(Transform interactPoint = null)
    {
        lastInteractPoint = interactPoint;
    }

    public void HideInteraction()
    {
        interactionPrompt.SetActive(false);
        timeText.SetActive(false);
    }

}