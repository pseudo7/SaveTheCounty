using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject ufo;
    public GameObject suicider;
    public GameObject motherShip;
    public GameObject blast;

    public float spawnWidthRadius = 10;
    public Vector2 spawnHeightBounds = new Vector2(3, 5);

    public int ufoSpawnTime;
    public int suiciderSpawnTime;
    public int motherShipSpawnTime;

    float countdownUfo, countDownSuicider, countdownMotherShip;
    byte spawnTurn = 0;

    readonly WaitForEndOfFrame WAIT_FOR_ENDFRAME = new WaitForEndOfFrame();

    private void Awake()
    {
        if (!Instance)
            Instance = this;
    }

    void Start()
    {
        SpawnUFO();
        StartCoroutine(SpawnUFOCoroutine());
        StartCoroutine(SpawnSuiciderCoroutine());
        StartCoroutine(SpawnMotherShipCoroutine());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    IEnumerator SpawnUFOCoroutine()
    {
        while (gameObject.activeInHierarchy)
        {
            if (countdownUfo > ufoSpawnTime)
                SpawnUFO();
            else countdownUfo += Time.deltaTime;
            yield return WAIT_FOR_ENDFRAME;
        }
    }

    IEnumerator SpawnSuiciderCoroutine()
    {
        while (gameObject.activeInHierarchy)
        {
            if (countDownSuicider > suiciderSpawnTime)
                SpawnSuicider();
            else countDownSuicider += Time.deltaTime;
            yield return WAIT_FOR_ENDFRAME;
        }
    }

    IEnumerator SpawnMotherShipCoroutine()
    {
        while (gameObject.activeInHierarchy)
        {
            if (countdownMotherShip > motherShipSpawnTime)
                SpawnMotherShip();
            else countdownMotherShip += Time.deltaTime;
            yield return WAIT_FOR_ENDFRAME;
        }
    }

    public void SpawnBlast(Vector3 impactPoint)
    {
        Instantiate(blast, impactPoint, blast.transform.rotation);
    }

    public void UpdateLevelInfo(LevelInfo levelInfo)
    {
        ufoSpawnTime = levelInfo.ufoSpawnTime;
        suiciderSpawnTime = levelInfo.suiciderSpawnTime;
        motherShipSpawnTime = levelInfo.motherShipSpawnTime;
    }

    void SpawnUFO()
    {
        if (spawnTurn % 3 == 0)
            spawnTurn++;
        else return;

        countdownUfo = countDownSuicider = countdownMotherShip = 0;
        var spawnPosition = new Vector3(Random.Range(-spawnWidthRadius, spawnWidthRadius), Random.Range(spawnHeightBounds[0], spawnHeightBounds[1]));
        var spawnRotation = Quaternion.identity;
        Instantiate(ufo, spawnPosition, spawnRotation);
    }

    void SpawnSuicider()
    {
        if (spawnTurn % 3 == 1)
            spawnTurn++;
        else return;

        countdownUfo = countDownSuicider = countdownMotherShip = 0;
        var spawnPosition = new Vector3(Random.Range(-spawnWidthRadius, spawnWidthRadius), Random.Range(spawnHeightBounds[0], spawnHeightBounds[1]));
        var spawnRotation = Quaternion.Euler(-90, 0, 0);
        Instantiate(suicider, spawnPosition, spawnRotation);
    }

    void SpawnMotherShip()
    {
        if (spawnTurn % 3 == 2)
            spawnTurn++;
        else return;

        countdownUfo = countDownSuicider = countdownMotherShip = 0;
        var spawnPosition = new Vector3(Random.Range(-spawnWidthRadius, spawnWidthRadius), Random.Range(spawnHeightBounds[0], spawnHeightBounds[1]));
        var spawnRotation = Quaternion.identity;
        Instantiate(motherShip, spawnPosition, spawnRotation);
    }
}
