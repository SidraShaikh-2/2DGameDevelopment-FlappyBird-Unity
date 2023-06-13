using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
 public Rigidbody2D myRigidbody;
    public float flapStrength = 7;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource flapSound;
 
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
 
    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive == true)
        // {
        //     flapSound.Play();
        //     myRigidbody.velocity = Vector2.up * flapStrength;

        // }

        if (Input.touchCount > 0 && birdIsAlive)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                flapSound.Play();
                myRigidbody.velocity = Vector2.up * flapStrength;
            }
        }
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
