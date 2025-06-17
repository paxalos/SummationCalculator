using UnityEngine;
using UnityEngine.EventSystems;

[ExecuteInEditMode]
public class RectTransformHeightFitter : UIBehaviour
{
    [SerializeField] private RectTransform rectTransformToFit;
    [SerializeField, Min(0f)] private float maxHeight;

    private RectTransform rectTransform;

    protected override void Awake()
    {
        rectTransform = transform as RectTransform;
    }

    protected override void OnRectTransformDimensionsChange()
    {
        float fitHeight = Mathf.Min(rectTransform.sizeDelta.y,
                                    maxHeight);
        rectTransformToFit.sizeDelta = new Vector2(rectTransformToFit.sizeDelta.x,
                                                   fitHeight);
    }
}
