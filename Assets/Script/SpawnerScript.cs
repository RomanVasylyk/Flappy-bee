using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject vzor; 
    public GameObject coinPrefab; 
    public int interval = 3;
    private float myTimer = 0f;

    void Start()
    {
        spawn();
    }

    void Update()
    {
        myTimer += Time.deltaTime;
        if (myTimer > interval)
        {
            spawn();
            myTimer = 0f;
        }
    }

    private void spawn()
    {
        float ypos = Random.Range(2, 7);
        
        if (Random.value < 0.3f) 
        {
            float coinYpos = Random.Range(2, 7);
            GameObject coin = Instantiate(coinPrefab);
            coin.transform.position = new Vector2(5, coinYpos);
        }
        else
        {
            GameObject prek = Instantiate(vzor);
            prek.transform.position = new Vector2(5, ypos);
        }
    }
}
