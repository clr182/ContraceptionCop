using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] wave;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    public Vector3[] spawnPoints;

    private float searchCountDown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if (!EnemyisAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if(waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(wave[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > wave.Length - 1)
        {
            nextWave = 0;
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyisAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {

        Vector3 left = new Vector2(Random.Range(-11f, 7f), Random.Range(-11f, -7f));
        Vector3 right = new Vector2(Random.Range(11f, -7f), Random.Range(11f, 7f));
        Vector3 top = new Vector2(Random.Range(-11f, 7f), Random.Range(11f, 7f));
        Vector3 bottom = new Vector2(Random.Range(-11f, -7f), Random.Range(11f, -7f));
        
        spawnPoints[0] = left;
        spawnPoints[1] = right;
        spawnPoints[2] = top;
        spawnPoints[3] = bottom;

        Vector2 _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp, transform.rotation);

        
    }

}
