using UnityEngine;

public class UITempDisplay : MonoBehaviour
{
    private const float TweenTime = 0.5f;
    private const float HiddenYPos = 1000;

    private Vector2 centerScreen;

    private void Awake()
    {
        transform.localScale = Vector3.zero;
        centerScreen.x = Screen.width / 2;
        centerScreen.y = Screen.height / 2;
    }

    private void MoveUp()
    {
        LeanTween.moveLocalY(gameObject, HiddenYPos, TweenTime).setEase(LeanTweenType.easeOutExpo).setOnComplete(PrepareForNextTime);
    }

    private void PrepareForNextTime()
    {
        transform.localScale = Vector3.zero;
        transform.position = centerScreen;
    }

    internal void Show(float displayTime)
    {
        LeanTween.scale(gameObject, Vector3.one, TweenTime).setEase(LeanTweenType.easeOutBack);
        Invoke("MoveUp", displayTime);
    }

}
