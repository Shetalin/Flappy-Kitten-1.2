using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class SPawnerScript : MonoBehaviour
{
    public GameObject scratchingPost;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;
    public bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && gameStarted == false)
        {
            gameStarted = true;
            spawnSP();
            Debug.Log("Game started");
        }

        if (timer < spawnRate && gameStarted == true) 
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnSP();
            timer = 0;
        }
        
    }

    void spawnSP ()
    {
        if (gameStarted)
        {
            float lowestPoint = transform.position.y - heightOffset;
            float highestPoint = transform.position.y + heightOffset;

            Instantiate(scratchingPost, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
            
        }
        
    }
}
