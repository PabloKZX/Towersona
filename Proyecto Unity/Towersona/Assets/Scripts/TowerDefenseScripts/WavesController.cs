﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesController : MonoBehaviour
{
    public static int EnemiesAlives = 0;

    public int wavesToWin = 10;
    public float timeBetweenWaves;
    public float waveSpawnRate = 1;

    [SerializeField]
    private GameObject enemyPrefab;

    private float countdown = 2f; 
    private Transform spawnPoint;   

    private void Update()
    {        
        if(EnemiesAlives > 0)
        {
            return;
        }

        if(PlayerStats.Rounds == wavesToWin)
        {
            TowerDefenseManager.Instance.WinGame();
        }

        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
    }

    private IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;      

        //TODO: algoritmo de creación de enemigos
        EnemiesAlives = PlayerStats.Rounds;

        for(int i = 0; i < PlayerStats.Rounds; i++)
        {
            SpawnEnemy(enemyPrefab);
            yield return new WaitForSeconds(1f / waveSpawnRate);
        }       
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10f, 10f, 200f, 50f), "Next round in: " + countdown.ToString());
        GUI.Label(new Rect(10f, 30f, 200f, 50f), "Player Lives: " + PlayerStats.Lives.ToString());
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

    public void SetSpawnPoint(Transform transform)
    {
        spawnPoint = transform;
    }

}