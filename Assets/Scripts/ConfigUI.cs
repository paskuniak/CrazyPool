using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConfigUI : MonoBehaviour
{

    private const string StringFormat = "0.00";

    [SerializeField]
    private TextMeshProUGUI gameTimeField = null;

    [SerializeField]
    private TextMeshProUGUI startSpeedField = null;

    [SerializeField]
    private TextMeshProUGUI endSpeedField = null;

    [SerializeField]
    private TextMeshProUGUI collisionForceField = null;

    [SerializeField]
    private TextMeshProUGUI secondaryCollisionForceField = null;

    [SerializeField]
    private TextMeshProUGUI sensitivityField = null;

    [SerializeField]
    private TextMeshProUGUI spawnRateField = null;

    [SerializeField]
    private TextMeshProUGUI uniqueRatioField = null;

    [SerializeField]
    private TextMeshProUGUI badRatioField = null;

    private void InitValues()
    {
        gameTimeField.text = Config.GameTime.ToString();
        startSpeedField.text = Config.StartSpeed.ToString();
        endSpeedField.text = Config.EndSpeed.ToString();
        collisionForceField.text = Config.CollisionForce.ToString();
        secondaryCollisionForceField.text = Config.SecondaryCollisionForce.ToString();
        sensitivityField.text = Config.ControlSensitivity.ToString();
        spawnRateField.text = Config.SpawnRate.ToString(StringFormat);
        uniqueRatioField.text = Config.UniqueSpawnRatio.ToString(StringFormat);
        badRatioField.text = Config.BadSpawnRatio.ToString(StringFormat);
    }

    public void SetVisible(bool visible)
    {
        gameObject.SetActive(visible);
        InitValues();
    }

    public void ChangeGameTime(int delta)
    {
        gameTimeField.text = (Config.GameTime + delta).ToString();
        Config.SetInt(Config.GAME_TIME_KEY, Config.GameTime + delta);
    }

    public void ChangeStartSpeed(int delta)
    {
        startSpeedField.text = (Config.StartSpeed + delta).ToString();
        Config.SetFloat(Config.START_SPEED_KEY, Config.StartSpeed + delta);
    }

    public void ChangeEndSpeed(int delta)
    {
        endSpeedField.text = (Config.EndSpeed + delta).ToString();
        Config.SetFloat(Config.END_SPEED_KEY, Config.EndSpeed + delta);
    }

    public void ChangeCollisionForce(int delta)
    {
        collisionForceField.text = (Config.CollisionForce + delta).ToString();
        Config.SetFloat(Config.COLLLISION_FORCE_KEY, Config.CollisionForce + delta);
    }

    public void ChangeSecondatyCollisionForce(int delta)
    {
        secondaryCollisionForceField.text = (Config.SecondaryCollisionForce + delta).ToString();
        Config.SetFloat(Config.SECONDATY_COLLISION_FORCE_KEY, Config.SecondaryCollisionForce + delta);
    }

    public void ChangeSensitivity(int delta)
    {
        sensitivityField.text = (Config.ControlSensitivity + delta).ToString();
        Config.SetInt(Config.SENSITIVITY_KEY, Config.ControlSensitivity + delta);
    }

    public void ChangeSpawnRate(float delta)
    {
        spawnRateField.text = (Config.SpawnRate + delta).ToString(StringFormat);
        Config.SetFloat(Config.SPAWN_RATE_KEY, Config.SpawnRate + delta);
    }

    public void ChangeUniqueRatio(float delta)
    {
        uniqueRatioField.text = (Config.UniqueSpawnRatio + delta).ToString(StringFormat);
        Config.SetFloat(Config.UNIQUE_SPAWN_RATIO_KEY, Config.UniqueSpawnRatio + delta);
    }

    public void ChangeBadRatio(float delta)
    {
        badRatioField.text = (Config.BadSpawnRatio + delta).ToString(StringFormat);
        Config.SetFloat(Config.BAD_SPAWN_RATIO_KEY, Config.BadSpawnRatio + delta);
    }

    public void ResetValues()
    {
        Config.ResetValues();
        InitValues();
    }

}
