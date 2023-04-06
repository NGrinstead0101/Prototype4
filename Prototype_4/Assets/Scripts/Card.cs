using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //corperation type
    public int corp;
    //part type
    public int type;
    //mouse position
    Vector2 mousePos;

    //"constructor"
    public void CreateCard(int c, int p, Sprite s, Sprite part)
    {
        Corp = c;
        Type = p;
        GetComponent<SpriteRenderer>().sprite = s;
        // May need more sprite variables + references to child objects
    }
    //getter and setter for corp
    public int Type { get => type; set => type = value; }
    //getter and setter for part
    public int Corp { get => corp; set => corp = value; }


    //drag for movement
    private void OnMouseDrag()
    {
        //update position
        transform.position = mousePos;
        
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
