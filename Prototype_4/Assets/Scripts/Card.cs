using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //corperation type
    private int corpType;
    //part type
    private int partType;
    //mouse position
    Vector2 mousePos;
    //getter and setter for corp
    public int PartType { get => partType; set => partType = value; }
    //getter and setter for part
    public int CorpType { get => corpType; set => corpType = value; }

    //overload constructor
    public Card(int c, int p, Sprite s)
    {
        CorpType = c;
        PartType = p;
        GetComponent<SpriteRenderer>().sprite = s;
    }

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

}
