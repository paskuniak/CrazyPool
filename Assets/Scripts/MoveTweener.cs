using UnityEngine;

public enum MoveAxis
{
    X, Y
}

public class MoveTweener : AbstractTweener
{
    [SerializeField]
    private MoveAxis axis = MoveAxis.Y;

    [SerializeField]
    private float hiddenPos = 0;

    [SerializeField]
    private float visiblePos = 0;

    internal override void SetVisible(bool visible)
    {
        LTDescr tween;
        if (axis == MoveAxis.Y)
        {
            tween = LeanTween.moveY(gameObject, visible ? visiblePos : hiddenPos, TWEEN_TIME);
        }
        else
        {
            tween = LeanTween.moveX(gameObject, visible ? visiblePos : hiddenPos, TWEEN_TIME);
        }
        tween.setEase(LeanTweenType.easeInOutBack);
    }

}
