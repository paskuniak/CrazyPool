using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Vector3 offsetFromPlayer = Vector3.zero;

    [SerializeField]
    private StressReceiver cameraShake = null;

    private Vector3 position;
    private GameObject player;

    private void LateUpdate()
    {
        position = transform.position;
        position.z = player.transform.position.z + offsetFromPlayer.z;
        transform.position = position;
    }

    internal void SetPlayer(GameObject playerObject)
    {
        player = playerObject;
    }

    internal void Shake(Intensity intensity)
    {
        cameraShake.Shake(intensity);
    }
}
