using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -30;
    public SPawnerScript spawnerScript;

    // Start is called before the first frame update
    void Start()
    {
        spawnerScript = FindObjectOfType<SPawnerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnerScript.gameStarted == true)
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
