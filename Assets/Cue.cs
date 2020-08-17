using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cue : MonoBehaviour
{

    public Transform player;
    private Action OnHitAction;

    public void Shoot(Action onHit)
    {
        OnHitAction = onHit;
        transform.position = player.position;
        transform.Translate(0, 0, -35, Space.World);
        LeanTween.moveZ(gameObject, player.position.z - 22, 0.05f).setOnComplete(MoveBack);
    }

    private void MoveBack()
    {
        OnHitAction();
        LeanTween.moveZ(gameObject, player.position.z - 35, 0.05f);
    }
}
