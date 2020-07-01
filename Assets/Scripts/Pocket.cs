using UnityEngine;

public class Pocket : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem glow = null;
    [SerializeField]
    private ParticleSystem redGlow = null;

    public void Glow()
    {
        glow.gameObject.SetActive(true);
        glow.Play();
    }
    public void RedGlow()
    {
        redGlow.gameObject.SetActive(true);
        redGlow.Play();
    }
}
