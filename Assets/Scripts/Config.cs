using UnityEngine;

public static class Config
{

    public const float Y_SPAWN_POSITION = 0.75f;
    public const float TABLE_WIDTH = 12f;
    public const float TILE_DISTANCE = 30;
    public const int TABLE_TILES = 6;

    public const int DEFAULT_GAME_TIME = 60;
    public const int DEFAULT_SENSITIVITY = 12;
    public const float DEFAULT_START_SPEED = 25f;
    public const float DEFAULT_END_SPEED = 40f;
    public const float DEFAULT_COLLLISION_FORCE = 100f;
    public const float DEFAULT_SECONDARY_COLLISION_FORCE = 30f;
    public const float DEFAULT_SPAWN_RATE = 0.5f;
    public const float DEFAULT_BAD_SPAWN_RATIO = 0.3f;
    public const float DEFAULT_UNIQUE_SPAWN_RATIO = 0.25f;

    public const string GAME_TIME_KEY = "GameTime";
    public const string SENSITIVITY_KEY = "ControlSensitivity";
    public const string START_SPEED_KEY = "StartSpeed";
    public const string END_SPEED_KEY = "EndSpeed";
    public const string COLLLISION_FORCE_KEY = "CollisionForce";
    public const string SECONDATY_COLLISION_FORCE_KEY = "SecondaryCollisionForce";
    public const string SPAWN_RATE_KEY = "spawnRate";
    public const string BAD_SPAWN_RATIO_KEY = "badSpawnRatio";
    public const string UNIQUE_SPAWN_RATIO_KEY = "uniqueSpawnRatio";

    private static int gameTime;
    private static int controlSensitivity;
    private static float startSpeed;
    private static float endSpeed;
    private static float collisionForce;
    private static float secondaryCollisionForce;
    private static float spawnRate;
    private static float badSpawnRatio;
    private static float uniqueSpawnRatio;

    private static bool isInit;

    public static int ControlSensitivity {
        get {
            Init();
            return controlSensitivity;
        }
    }

    public static int GameTime {
        get {
            Init();
            return gameTime;
        }
    }

    public static float CollisionForce {
        get {
            Init();
            return collisionForce;
        }
    }

    public static float StartSpeed {
        get {
            Init();
            return startSpeed;
        }
    }

    public static float EndSpeed {
        get {
            Init();
            return endSpeed;
        }
    }

    public static float SecondaryCollisionForce {
        get {
            Init();
            return secondaryCollisionForce;
        }
    }

    public static float SpawnRate {
        get {
            Init();
            return spawnRate;
        }
    }
    
    public static float BadSpawnRatio {
        get {
            Init();
            return badSpawnRatio;
        }
    }

    public static float UniqueSpawnRatio {
        get {
            Init();
            return uniqueSpawnRatio;
        }
    }

    private static void Init(bool force = false)
    {
        if (isInit && !force) return;

        gameTime = InitInt(GAME_TIME_KEY, DEFAULT_GAME_TIME); 
        controlSensitivity = InitInt(SENSITIVITY_KEY, DEFAULT_SENSITIVITY);

        startSpeed = InitFloat(START_SPEED_KEY, DEFAULT_START_SPEED);
        endSpeed = InitFloat(END_SPEED_KEY, DEFAULT_END_SPEED);
        collisionForce = InitFloat(COLLLISION_FORCE_KEY, DEFAULT_COLLLISION_FORCE);
        secondaryCollisionForce = InitFloat(SECONDATY_COLLISION_FORCE_KEY, DEFAULT_SECONDARY_COLLISION_FORCE);

        spawnRate = InitFloat(SPAWN_RATE_KEY, DEFAULT_SPAWN_RATE);
        badSpawnRatio = InitFloat(BAD_SPAWN_RATIO_KEY, DEFAULT_BAD_SPAWN_RATIO);
        uniqueSpawnRatio = InitFloat(UNIQUE_SPAWN_RATIO_KEY, DEFAULT_UNIQUE_SPAWN_RATIO);

        isInit = true;
    }

    private static float InitFloat(string key, float defaultValue) 
    {
        if (!PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.SetFloat(key, defaultValue);
        }
        return PlayerPrefs.GetFloat(key);
    }

    private static int InitInt(string key, int defaultValue)
    {
        if (!PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.SetInt(key, defaultValue);
        }
        return PlayerPrefs.GetInt(key);
    }

    internal static void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        Init(true);
    }

    internal static void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        Init(true);
    }

    internal static void ResetValues()
    {
        PlayerPrefs.SetInt(GAME_TIME_KEY, DEFAULT_GAME_TIME);
        PlayerPrefs.SetInt(SENSITIVITY_KEY, DEFAULT_SENSITIVITY);

        PlayerPrefs.SetFloat(START_SPEED_KEY, DEFAULT_START_SPEED);
        PlayerPrefs.SetFloat(END_SPEED_KEY, DEFAULT_END_SPEED);
        PlayerPrefs.SetFloat(COLLLISION_FORCE_KEY, DEFAULT_COLLLISION_FORCE);
        PlayerPrefs.SetFloat(SECONDATY_COLLISION_FORCE_KEY, DEFAULT_SECONDARY_COLLISION_FORCE);

        PlayerPrefs.SetFloat(SPAWN_RATE_KEY, DEFAULT_SPAWN_RATE);
        PlayerPrefs.SetFloat(BAD_SPAWN_RATIO_KEY, DEFAULT_BAD_SPAWN_RATIO);
        PlayerPrefs.SetFloat(UNIQUE_SPAWN_RATIO_KEY, DEFAULT_UNIQUE_SPAWN_RATIO);

        Init(true);
    }

}
