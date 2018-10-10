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
        //Random snabbhet, rotation och start-position
        movespeed += Random.Range(0, 5);
        rotate += Random.Range(10, 30);
        transform.position = new Vector3(Random.Range(-18, 18), Random.Range(-10, 10));
    }

    // Update is called once per frame
    void Update()
    {   
        //En float ökar med tiden och ökar en int med ett ifall counter >= timer + 1 och printar värdet.  
        counter += Time.deltaTime;
        if (counter >= timer + 1)
        {
            timer += 1;
            print("timer" + ' ' + timer);
        }
        //att den alltid åker framåt utan att den stoppas av fps
        transform.Translate(movespeed * Time.deltaTime, 0, 0);
        //vänster/höger/broms
        if (Input.GetKey(KeyCode.A))
        {
            //byter färg och roterar vänster oberoende av fps
            rend.color = new Color(0, 1, 0);
            transform.Rotate(0, 0, rotate * Time.deltaTime * 10);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //byter färg och roterar höger(dubbelt så snabbt) oberoende av fps
            rend.color = new Color(0, 0, 1);
            transform.Rotate(0, 0, -rotate * Time.deltaTime * 20);
        }
        //vid nedtryckning halveras snabbheten(broms), vid släpp dubblas den(tillbaka till vanligt) 
        if (Input.GetKeyDown(KeyCode.S))
         {
            movespeed = movespeed / 2;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            movespeed = movespeed * 2;
        }
        //random färg(gjorde bara GetKey istället för GetKeyDown för att det var roligare(annars hade den bara bytt en gång vid nedtryckning))
        if (Input.GetKey(KeyCode.Space))
        {
            // tre floats får ett random värde mellan 0 och 1
            Färg1 = Random.Range(0f, 1f);
            Färg2 = Random.Range(0f, 1f);
            Färg3 = Random.Range(0f, 1f);
            //dem tre floatsen blir ingredienserna till den nya färgen
            rend.color = new Color(Färg1, Färg2, Färg3);
        }
        //warping
        //checkar ifall om objektet har en x-position utanför 19 och -19 och om y är utanför 11 och -11
        //ifall om objekten är utanför så flyttas den till motsata x/y-kant och behåller sin y/x position
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
