using UnityEngine;

public class TileController : MonoBehaviour
{

    private Transform player;

    private void Update()
    {
        if (player.position.z > (transform.position.z + Config.TILE_DISTANCE))
        {
            transform.Translate(0, 0, Config.TILE_DISTANCE * Config.TABLE_TILES);
        }
    }

    internal void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }
}
