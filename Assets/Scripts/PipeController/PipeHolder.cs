using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHolder : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BirdController.instance != null)
        {
            if (BirdController.instance.isAlive == false)
            {
                Destroy(GetComponent<PipeHolder>());
            }
        }
        _PipeMovement();
    }

    void _PipeMovement()
    {
        Vector3 temp=transform.position;
        temp.x-=speed*Time.deltaTime;
        transform.position=temp;
        Debug.Log(temp.x+"\n");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
