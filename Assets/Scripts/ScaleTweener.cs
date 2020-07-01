using UnityEngine;

public class ScaleTweener :  AbstractTweener
{
    internal override void SetVisible(bool visible)
    {
        var tween = LeanTween.scale(gameObject, visible ? Vector3.one : Vector3.zero, TWEEN_TIME);
        if (visible)
        {
            tween.setEase(LeanTweenType.easeInOutBack);
        }
    }

}
