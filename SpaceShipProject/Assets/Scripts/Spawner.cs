using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnPrefab;
    public GameObject ParentHolder;
    public float respawnTime = 1.0f;
    private float RandomScale;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(entityWave());
    }

    private void spawnEntity()
    {
        GameObject a = Instantiate(spawnPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.x * 2);
        a.transform.SetParent(ParentHolder.transform);
        RandomScale = Random.Range(0.2f, 0.7f);
        a.transform.localScale = new Vector3(RandomScale, RandomScale, RandomScale);
    }

    IEnumerator entityWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEntity();
        }
        
    }
}
