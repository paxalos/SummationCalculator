using UnityEngine;

[DisallowMultipleComponent, ExecuteInEditMode]
public class RectTransformHeightFitter : MonoBehaviour
{
    [SerializeField] private RectTransformChangeTrigger fitTransform;
    [SerializeField] private bool hasLimitations;
    [SerializeField, ShowIf(nameof(hasLimitations), true)] private Vector2 limitations;

    private void Start()
    {
        FitHeight();
    }

    private void OnEnable()
    {
        fitTransform.RectTransformChanged += FitTransform_RectTransformChanged;
    }

    private void OnDisable()
    {
        fitTransform.RectTransformChanged -= FitTransform_RectTransformChanged;
    }

    private void FitTransform_RectTransformChanged()
    {
        FitHeight();
    }

    private void FitHeight()
    {
        float height = fitTransform.Height;
        var rectTransform = (RectTransform)transform;
        float fittedHeight = hasLimitations ? Mathf.Clamp(height,
                                                          limitations.x,
                                                          limitations.y)
                                            : height;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 
                                              fittedHeight);
    }
}
