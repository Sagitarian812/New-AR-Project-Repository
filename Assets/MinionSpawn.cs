using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
public class MinionSpawn : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public TextMeshProUGUI timer;

    public float timeBetweenWaves = 10f;
    private float countdown = 2f;
    private int waveNumber = 0;

    private void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        timer.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Wave Incoming!");
        waveNumber++;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
       // enemyPrefab.transform.parent = spawnPoint.transform;
    }

}
