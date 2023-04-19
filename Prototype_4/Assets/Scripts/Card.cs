using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private HandTracker handTracker;
    //corperation type
    public int corp;
    //part type
    public int type;
    //mouse position
    Vector2 mousePos;

    [SerializeField] SpriteRenderer typeSR;

    [SerializeField] float handExitThreshold;
    bool isZoomed = false;
    bool isInHand = true;
    bool canUnzoom = false;

    //"constructor"
    public void CreateCard(int c, int p, Sprite s, Sprite type)
    {
        Corp = c;
        Type = p;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        typeSR.sprite = type;
        handTracker = GameObject.FindGameObjectWithTag("HandTracker").GetComponent<HandTracker>();

        // temp code to set colors for suits
        switch (corp)
        {
            case 0:
                sr.color = Color.green;
                break;

            case 1:
                sr.color = Color.blue;
                break;

            case 2:
                sr.color = Color.red;
                break;
        }
        

        //GetComponent<SpriteRenderer>().sprite = s;
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

        if (transform.position.y >= handExitThreshold)
        {
            isInHand = false;
        }
    }

    //private void OnMouseOver()
    //{
    //    if (!isZoomed && isInHand)
    //    {
    //        isZoomed = true;
    //        canUnzoom = false;
    //        Invoke("ZoomDelay", 0.1f);

    //        //transform.Translate(Vector2.up);
    //        transform.localScale *= 1.5f;
    //    }
    //}

    //private void OnMouseExit()
    //{
    //    if (canUnzoom && isZoomed && isInHand)
    //    {
    //        isZoomed = false;

    //        //transform.Translate(Vector2.down);
    //        transform.localScale /= 1.5f;
    //    }
    //}

    //private void ZoomDelay()
    //{
    //    canUnzoom = true;
    //}

    //update for various functions
    private void Update()
    {
        //update mouse position
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if coliding with sleeve and filled is false
        if (collision.tag.Contains("Sleeve")&& collision.gameObject.GetComponent<Sleeve>().filled == false)
        { 
           //card position becomes sleeve position
           transform.position = collision.transform.position;
        }
    }
    

    private void OnDestroy()
    {
        handTracker.RemoveCard(gameObject);
    }

}
