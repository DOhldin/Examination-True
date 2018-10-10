using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipper : MonoBehaviour
{
    public Color colour;
    public SpriteRenderer rend;
    public float movespeed;
    public int rotate;
    public float counter;
    public int timer;
    public float Färg1;
    public float Färg2;
    public float Färg3;
    // Use this for initialization
    void Start()
    {
        //Random snabbhet och rotation
        movespeed += Random.Range(0, 5);
        rotate += Random.Range(10, 30);
        transform.position = new Vector3(Random.Range(-18, 18), Random.Range(-10, 10));
    }

    // Update is called once per frame
    void Update()
    {   
        //Counter ökar med tid och ökar timer med ett ifall counter >= timer + 1 och printar värdet.  
        counter += Time.deltaTime;
        if (counter >= timer + 1)
        {
            timer += 1;
            print("timer" + ' ' + timer);
        }

        transform.Translate(movespeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            rend.color = new Color(0, 1, 0);
            transform.Rotate(0, 0, rotate * Time.deltaTime * 10);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rend.color = new Color(0, 0, 1);
            transform.Rotate(0, 0, -rotate * Time.deltaTime * 20);
        }
        if (Input.GetKeyDown(KeyCode.S))
         {
            movespeed = movespeed / 2;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            movespeed = movespeed * 2;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Färg1 = Random.Range(0f, 1f);
            Färg2 = Random.Range(0f, 1f);
            Färg3 = Random.Range(0f, 1f);
            rend.color = new Color(Färg1, Färg2, Färg3);
        }
        if (transform.position.x < -19)
        {
            transform.position = new Vector3 (19, transform.position.y);
        }
        if (transform.position.x > 19)
        {
            transform.position = new Vector3(-19, transform.position.y);
        }
        if (transform.position.y < -11)
        {
            transform.position = new Vector3(transform.position.x, 11);
        }
        if (transform.position.y > 11)
        {
            transform.position = new Vector3(transform.position.x, -11);
        }



    }
}
