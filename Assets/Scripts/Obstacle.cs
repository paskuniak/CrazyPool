using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private const float DownToHell = -500f;
    private const float PlayerDistanceToReturn = 30;

    private Transform playerTransform;
    private Rigidbody rigidBody;

    public Rigidbody Rigidbody => rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if ((playerTransform != null && (playerTransform.position.z - PlayerDistanceToReturn > transform.position.z)) || 
            transform.position.y < DownToHell)
        {
            GameManager.Instance.ReturnUnique(gameObject);
        }
    }

    internal void SetPlayer(Transform player)
    {
        playerTransform = player;
    }


}
