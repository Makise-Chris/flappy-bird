using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public static BirdController instance;
    public float bounceForce;
    private Rigidbody2D myBody;
    private Animator anim;
    public bool isAlive;
    private bool didflap;
    private GameObject spawner;
    public int score = 0;

    // Start is called before the first frame update
    void Awake()
    {
        isAlive = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _makeInstance();
        spawner = GameObject.Find("SpawnerPipe");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _BirdMovement();
    }

    void _makeInstance()
    {
        if(instance == null) instance = this;
    }

    void _BirdMovement()
    {
        if (isAlive)
        {
            if (didflap)
            {
                didflap = false;
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);

            }
        }

        if (myBody.velocity.y > 0)
        {
            float angle = 0;
            angle = Mathf.Lerp(0, 60, myBody.velocity.y/10);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else if(myBody.velocity.y < 0)
        {
            float angle = 0;
            angle = Mathf.Lerp(0, -60, -myBody.velocity.y / 10);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void _flap()
    {
        didflap = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "pipeHolder")
        {
            score++;
            if (ScoreController.instance != null)
            {
                ScoreController.instance._setScore(score);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "pipe" || collision.gameObject.tag == "ground")
        {
            Destroy(spawner);
            isAlive = false;
            anim.SetTrigger("Died");
            if (ScoreController.instance != null)
            {
                ScoreController.instance._showPanel();
            }
        }
    }
}
