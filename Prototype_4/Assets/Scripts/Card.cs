using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //corperation type
    public int corpType;
    //part type
    public int partType;
    //mouse position
    Vector2 mousePos;

    //overload constructor
    public Card(int c, int p, Sprite s)
    {
        CorpType = c;
        PartType = p;
        GetComponent<SpriteRenderer>().sprite = s;
    }
    //getter and setter for corp
    public int PartType { get => partType; set => partType = value; }
    //getter and setter for part
    public int CorpType { get => corpType; set => corpType = value; }


    //drag for movement
    private void OnMouseDrag()
    {
        //update position
        transform.position = mousePos;
        //update drag
       
    }

    //update for various functions
    private void Update()
    {
        //update mouse position
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if mousse is down and coliding with sleeve
        if (Input.GetMouseButton(0) == false && collision.tag.Contains("Sleeve"))
        {
            //card position becomes sleeve position
            transform.position = collision.transform.position;
        }
    }

}
