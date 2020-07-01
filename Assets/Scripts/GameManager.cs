using UnityEngine;

public enum GameState
{
    Menu,
    Game
}

[RequireComponent(typeof(UIManager))]
[RequireComponent(typeof(BallPool))]
[RequireComponent(typeof(GameTimer))]
public class GameManager : MonoBehaviour
{

    private const float BombRollSpeed = 30;

    [SerializeField] 
    private GameState gameState;
    
    [SerializeField] 
    private PlayerController player = null;
    
    [SerializeField] 
    private CameraController cameraController = null;

    [SerializeField]
    private TileController[] tableTiles = null;

    private static GameManager instance;
    private UIManager uiManager;
    private BallPool pool;
    private GameTimer timer;

    private Vector3 spawnPosition;

    public static GameManager Instance => instance;

    public GameState GameState => gameState;

    private void Awake()
    {
        InitSingleton();
        gameState = GameState.Menu;
        uiManager = GetComponent<UIManager>();
        pool = GetComponent<BallPool>();
        timer = GetComponent<GameTimer>();
        timer.Init(uiManager, TimeUp);
        MusicPlayer.SetFilterActive(true);
    }

    private void Start()
    {
        cameraController.SetPlayer(player.gameObject);
        for (int i = 0; i < tableTiles.Length; i++)
        {
            tableTiles[i].SetPlayer(player.transform);
        }
    }

    private void InitSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void TimeUp()
    {
        SFXPlayer.PlayClip(SFX.TimeUp);
        EndGame();
    }

    private void SpawnObjects()
    {
        if (gameState == GameState.Game)
        {
            SpawnObject();
            Invoke("SpawnObjects", Config.SpawnRate + (Random.value/2 * ((float)timer.TimeRemaining / Config.GameTime)));
        }
    }

    private void SpawnObject()
    {
        InitSpawnPosition();
        if (Random.value < Config.UniqueSpawnRatio)
        {
            SpawnUnique();
        }
        else
        {
            SpawnBall();
        }
    }

    private void InitSpawnPosition()
    {
        spawnPosition.x = (Random.value - 0.5f) * Config.TABLE_WIDTH;
        spawnPosition.y = Config.Y_SPAWN_POSITION;
        spawnPosition.z = player.transform.position.z + 120;
    }

    private void SpawnBall()
    {
        var ball = pool.GetBall(Random.value > Config.BadSpawnRatio).GetComponent<Rigidbody>();
        if (ball != null)
        {
            ball.velocity = Vector3.zero;
            ball.angularVelocity = Vector3.zero;
            ball.transform.position = spawnPosition;
            ball.transform.rotation = Quaternion.identity;
        }
    }

    private void SpawnUnique()
    {
        var unique = pool.GetUnique();
        if (unique != null)
        {
            spawnPosition.x /= 2;
            unique.transform.rotation = Quaternion.identity;
            var obstacle = unique.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                unique.transform.Rotate(0, Random.value * 360, 0);
                obstacle.Rigidbody.velocity = Vector3.zero;
                obstacle.Rigidbody.angularVelocity = Vector3.zero;
                obstacle.SetPlayer(player.transform);
            }
            else if (unique.GetComponent<BombController>() != null)
            {
                unique.GetComponent<Rigidbody>().velocity = Vector3.back * BombRollSpeed;
            }
            unique.transform.position = spawnPosition;
        }
    }

    internal void StartGame()
    {
        gameState = GameState.Game;
        uiManager.SetState(gameState);
        player.ResetSpeed();
        timer.StartTimer();
        SpawnObjects();
        SFXPlayer.PlayClip(SFX.Go);
        MusicPlayer.SetFilterActive(false);
    }

    internal void EndGame(bool explosion = false)
    {
        if (explosion)
        {
            cameraController.Shake(Intensity.Extreme);
        }
        gameState = GameState.Menu;
        player.ResetSpeed();
        uiManager.EndGame();
        timer.CancelTimer();
        MusicPlayer.SetFilterActive(true);
    }

    internal void ReturnBall(GameObject ball)
    {
        pool.ReturnBall(ball, ball.GetComponent<BallController>().Type == BallType.Good);
    }

    internal void ReturnUnique(GameObject unique)
    {
        pool.ReturnUnique(unique);
    }

    internal void BallPocketed(BallController ball)
    {
        if (gameState != GameState.Game) return;
        switch (ball.Type)
        {
            case BallType.Good:;
                uiManager.AddScore(ball.Points);
                SFXPlayer.PlayClip(SFX.GoodBallInHole);
                ReturnBall(ball.gameObject);
                break;
            case BallType.Bad:
                cameraController.Shake(Intensity.Subtle);
                uiManager.AddScore(-ball.Points);
                SFXPlayer.PlayClip(SFX.BadBallInHole);
                ReturnBall(ball.gameObject);
                break;
            case BallType.Eight:
                cameraController.Shake(Intensity.Normal);
                SFXPlayer.PlayClip(SFX.EightBallInHole);
                ReturnBall(ball.gameObject);
                EndGame();
                break;
            case BallType.Bomb:
                ReturnUnique(ball.gameObject);
                break;
            case BallType.Surprize:
                uiManager.NotifyAddTime();
                timer.AddTime();
                ReturnUnique(ball.gameObject);
                break;
        }
        
    }
}
