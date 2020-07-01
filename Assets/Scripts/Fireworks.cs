using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem[] fx = null;

    internal void Play()
    {
        for (int i = 0; i < fx.Length; i++)
        {
            fx[i].gameObject.SetActive(true);
            fx[i].Play();
        }
    }


}
