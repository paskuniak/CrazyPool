using UnityEngine;

public abstract class AbstractTweener : MonoBehaviour
{
    protected const float TWEEN_TIME = 0.35f;
    internal abstract void SetVisible(bool visible);
}