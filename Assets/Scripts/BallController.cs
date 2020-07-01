using System;
using UnityEngine;

public enum BallType
{
    Good,
    Bad,
    Eight,
    Surprize,
    Bomb
}

public class BallController : MonoBehaviour
{

    [SerializeField]
    private BallType type;

    [SerializeField]
    private int points;

    public BallType Type => type;
    public int Points => points;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.y < -10)
        {
            if (type == BallType.Surprize || type == BallType.Bomb)
            {
                GameManager.Instance.ReturnUnique(gameObject);
            }
            else {
                GameManager.Instance.ReturnBall(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        CheclBallCollision(collision);
        CheckPlayerCollision(collision);
    }

    private void CheclBallCollision(Collision collision)
    {
        if (collision.collider.tag == "BadBall" || collision.collider.tag == "GoodBall" ||
            collision.collider.tag == "EightBall")
        {
            SFXPlayer.PlayClip(SFX.OtherBallHitBall);
            rb.AddForce((rb.position - collision.rigidbody.position) * Config.SecondaryCollisionForce, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pocket")
        {
            GameManager.Instance.BallPocketed(this);
            if (type == BallType.Good || type == BallType.Surprize)
            {
                other.GetComponent<Pocket>().Glow();
            }
            else if (type == BallType.Eight || type == BallType.Bad)
            {
                other.GetComponent<Pocket>().RedGlow();
            }
        }
    }

    protected virtual void CheckPlayerCollision(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            rb.AddForce((rb.position - collision.rigidbody.position) * Config.CollisionForce, ForceMode.Impulse);
            SFXPlayer.PlayClip(SFX.PlayerBallHitBall);
        }
    }

    internal void Init(BallType type, int points)
    {
        this.type = type;
        this.points = points;
    }
}
