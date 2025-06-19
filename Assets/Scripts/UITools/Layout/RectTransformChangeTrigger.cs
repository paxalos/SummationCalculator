using System;
using UnityEngine;
using UnityEngine.EventSystems;

[ExecuteInEditMode, DisallowMultipleComponent, RequireComponent(typeof(RectTransform))]
public class RectTransformChangeTrigger : UIBehaviour
{
    public event Action RectTransformChanged;

    public float Height
    {
        get
        {
            var rectTransform = (RectTransform)transform;
            return rectTransform.sizeDelta.y;
        }
    }

    protected override void OnRectTransformDimensionsChange()
    {
        OnRectTransformChanged();
    }

    private void OnRectTransformChanged()
    {
        var handler = RectTransformChanged;
        handler?.Invoke();
    }
}
