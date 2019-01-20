using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Dictionary<Level, LevelInfo> levelMap;

    static Level currentLevel;

    void Awake()
    {
        levelMap = new Dictionary<Level, LevelInfo>
        {
            { Level.Level1, new LevelInfo(10, 15, 30, .75f) },
            { Level.Level2, new LevelInfo(8, 12, 25, 1.25f) },
            { Level.Level3, new LevelInfo(5, 10, 15, 1.5f) }
        };
    }

    void Start()
    {
        StartCoroutine(LevelUpdater());
    }

    IEnumerator LevelUpdater()
    {
        GameManager.Instance.UpdateLevelInfo(levelMap[Level.Level1]);
        yield return new WaitForSeconds(Constants.LEVEL1_EXIT_TIME);
        GameManager.Instance.UpdateLevelInfo(levelMap[Level.Level2]);
        yield return new WaitForSeconds(Constants.LEVEL2_EXIT_TIME);
        GameManager.Instance.UpdateLevelInfo(levelMap[Level.Level3]);
    }
}

public enum Level
{
    Level1, Level2, Level3
}

public struct LevelInfo
{
    public int ufoSpawnTime;
    public int suiciderSpawnTime;
    public int motherShipSpawnTime;
    public float fireRate;

    public LevelInfo(int ufoSpawnTime, int suiciderSpawnTime, int motherShipSpawnTime, float fireRate)
    {
        this.ufoSpawnTime = ufoSpawnTime;
        this.suiciderSpawnTime = suiciderSpawnTime;
        this.motherShipSpawnTime = motherShipSpawnTime;
        this.fireRate = fireRate;
    }
}
