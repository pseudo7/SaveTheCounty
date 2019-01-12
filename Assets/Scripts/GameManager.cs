using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject ufo;
    public GameObject suicider;
    public GameObject motherShip;

    public int ufoSpawnTime;
    public int suiciderSpawnTime;
    public int motherShipSpawnTime;

    float countdown;

    readonly WaitForEndOfFrame WAIT_FOR_ENDFRAME = new WaitForEndOfFrame();

    private void Awake()
    {
        if (!Instance)
            Instance = this;
    }

    void Start()
    {
        StartCoroutine(LevelInfoCheck());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    IEnumerator LevelInfoCheck()
    {
        while (gameObject.activeInHierarchy)
        {
            if (countdown % motherShipSpawnTime == 0)
                SpawnMotherShip();
            else if (countdown % suiciderSpawnTime == 0)
                SpawnSuicider();
            else if (countdown % ufoSpawnTime == 0)
                SpawnUFO();
            else countdown += Time.deltaTime;
            yield return WAIT_FOR_ENDFRAME;
        }
    }

    public void UpdateLevelInfo(LevelInfo levelInfo)
    {
        ufoSpawnTime = levelInfo.ufoSpawnTime;
        suiciderSpawnTime = levelInfo.suiciderSpawnTime;
        motherShipSpawnTime = levelInfo.motherShipSpawnTime;
    }

    void SpawnUFO() { }

    void SpawnSuicider() { }

    void SpawnMotherShip() { }
}
