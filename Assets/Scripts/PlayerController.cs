using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float zSpeed = 0;

    private Rigidbody rb;
    private Vector3 speed;
    private float targetXPosition;
    private Vector3 targetPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (GameManager.Instance.GameState == GameState.Game)
        {
            zSpeed += Time.deltaTime * ((Config.EndSpeed - Config.StartSpeed) / Config.GameTime);
        }
    }

    private void FixedUpdate()
    {
        targetPosition = new Vector3(targetXPosition, rb.position.y, rb.position.z);
        rb.MovePosition(Vector3.Lerp(rb.position, targetPosition, Time.deltaTime * Config.ControlSensitivity));
        speed = rb.velocity;
        speed.z = zSpeed;
        speed.x = 0;
        rb.velocity = speed;
    }

    internal void SetXPositionTarget(float value)
    {
        targetXPosition = (value - 0.5f) * Config.TABLE_WIDTH;
    }

    internal void ResetSpeed()
    {
        zSpeed = Config.StartSpeed;
    }

}
