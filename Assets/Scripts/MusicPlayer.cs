using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static AudioLowPassFilter filter;

    private void Awake()
    {
        filter = GetComponent<AudioLowPassFilter>();
    }

    internal static void SetFilterActive(bool active)
    {
        filter.enabled = active;
    }

}
