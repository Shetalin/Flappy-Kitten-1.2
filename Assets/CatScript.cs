using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CatScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public float upperDeadZone = 15;
    public float lowerDeadZone = -15;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public Animator animator;
    public AudioSource activeMusic;
    public AudioSource inactiveMusic;
    private bool spacePressed = false;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        myRigidbody.gravityScale = 0;
        inactiveMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            myRigidbody.gravityScale = 5.11f;
            animator.SetTrigger("FlapTrigger");
            

            if (spacePressed == false)
            {
                inactiveMusic.Pause();
                activeMusic.Play();
                spacePressed = true;
            }

        }

        if (transform.position.y > upperDeadZone || transform.position.y < lowerDeadZone)
        {
            logic.gameOver();
            birdIsAlive = false;
            if (transform.position.y < lowerDeadZone-10)
            {
                myRigidbody.gravityScale = 0;
                myRigidbody.velocity = Vector2.zero;
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
        Debug.Log("Collision game over");
    }

}
