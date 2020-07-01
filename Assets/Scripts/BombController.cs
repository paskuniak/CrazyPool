using UnityEngine;

public class BombController : BallController
{

    [SerializeField]
    private GameObject[] objectsToDisable = null;

    [SerializeField]
    private GameObject[] objectsToEnable = null;

    private Rigidbody playerRB;

    private void RestoreAfterExplosion()
    {
        playerRB.constraints = RigidbodyConstraints.FreezePositionY;
        playerRB.position = new Vector3(playerRB.position.x, Config.Y_SPAWN_POSITION, playerRB.position.z);
        for (int i = 0; i < objectsToDisable.Length; i++)
        {
            objectsToDisable[i].SetActive(true);
        }
        for (int i = 0; i < objectsToEnable.Length; i++)
        {
            objectsToEnable[i].SetActive(false);
        }
    }

    protected override void CheckPlayerCollision(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            SFXPlayer.PlayClip(SFX.Bomb);
            playerRB = collision.rigidbody;
            playerRB.constraints = RigidbodyConstraints.None;
            playerRB.AddForce(Vector3.up * 300, ForceMode.Impulse);
            Invoke("RestoreAfterExplosion", 2);
            GameManager.Instance.EndGame(true);

            for (int i = 0; i < objectsToDisable.Length; i++)
            {
                objectsToDisable[i].SetActive(false);
            }
            for (int i = 0; i < objectsToEnable.Length; i++)
            {
                objectsToEnable[i].SetActive(true);
            }
        }
    }

}
