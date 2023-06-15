using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoolSpawner : MonoBehaviour
{
    private static FoolSpawner instance;
    public static FoolSpawner Instance => instance;

    [SerializeField]
    private GameObject deathScreen;    
    
    [SerializeField]
    List<SpawnData> spawnData;

    List<Fool> fools = new List<Fool>();
    bool spawning = false;

    private void Awake() {
        instance = this;
    }

    public void StopSpawn() {
        if (spawning) {
            spawning = false;
            deathScreen.SetActive(true);
            StopAllCoroutines();
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    void Start()
    {
        //SpawnFool();
        //InvokeRepeating("SpawnFool", 0, 3f);
        spawning = true;
        StartCoroutine(SpawnFool());
    }

    IEnumerator SpawnFool() {
        while (true) {
            var rnd = UnityEngine.Random.Range(0, 100);

            float sum = 0;
            for (int i = 0; i < spawnData.Count; i++) {
                if (rnd <= spawnData[i].probability + sum) {
                    SpawnActualFool(spawnData[i].foolPrefab);
                    break;
                }
                sum += spawnData[i].probability;
            }
            yield return new WaitForSeconds(3);
        }
    }

    private void SpawnActualFool(GameObject foolPrefab) {
        var fool = Instantiate(foolPrefab, Vector3.zero, Quaternion.identity);
        fools.Add(fool.GetComponent<Fool>());
    }
}

[Serializable]
class SpawnData
{
    public GameObject foolPrefab;
    public float probability;
}
