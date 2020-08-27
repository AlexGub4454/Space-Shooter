using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWave=0;
    [SerializeField] bool IsLooping;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (IsLooping);
        }
    public IEnumerator SpawnAllWaves()
    {for (int i = startingWave; i < waveConfigs.Count; i++) {

            yield return StartCoroutine(SpawnAllEnemiesInWave(waveConfigs[i]));
                
                }
}
    public IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
           var newEnemy= Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWayPoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetEnemyParthing(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBeetwenSpawns());
        }
    }
    // Update is called once per frame
    
}
