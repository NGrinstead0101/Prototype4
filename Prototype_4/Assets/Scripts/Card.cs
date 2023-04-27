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
    //target type for bonus
    public int typeBonus;
    //mouse position
    Vector2 mousePos;
    public bool canMove = true;
    //card bonus
    public CardBonus cardBonus;

    [SerializeField] SpriteRenderer typeSR;
    [SerializeField] SpriteRenderer corpSR;
    [SerializeField] SpriteRenderer bonusTypeSR;
    [SerializeField] SpriteRenderer bonusValueSR;

    [SerializeField] List<Sprite> backgroundSpriteList;
    [SerializeField] List<Sprite> typeSpriteList;
    [SerializeField] List<Sprite> bonusValueSpriteList;
 
    //[SerializeField] float handExitThreshold;
    //bool isZoomed = false;
    //bool isInHand = true;
    //bool canUnzoom = false;
    

    //"constructor"
    public void CreateCard(int c, int p, CardBonus cardBonus, Sprite s, Sprite type)
    {
        Corp = c;
        Type = p;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        typeSR.sprite = type;
        handTracker = GameObject.FindGameObjectWithTag("HandTracker").GetComponent<HandTracker>();
        this.cardBonus = cardBonus;
        // update child object sprites to reflect bonuses

        corpSR.sprite = s;
        sr.sprite = backgroundSpriteList[corp];
        if (cardBonus != null)
        {
            bonusTypeSR.sprite = typeSpriteList[cardBonus.bonusTargetType];
            
            if (cardBonus.isMultiplier)
            {
                bonusValueSR.sprite = bonusValueSpriteList[0];
            }
            else
            {
                bonusValueSR.sprite = bonusValueSpriteList[1];
            }
        }
        

        //GetComponent<SpriteRenderer>().sprite = s;
        // May need more sprite variables + references to child objects
    }
    //getter and setter for corp
    public int Type { get => type; set => type = value; }
    //getter and setter for part
    public int Corp { get => corp; set => corp = value; }

    
    private void OnMouseEnter()
    {
        canMove = true;
    }


    //drag for movement
    private void OnMouseDrag()
    {
        
        if (canMove == true)
        {
            //update position
            transform.position = mousePos;

            //if (transform.position.y >= handExitThreshold)
            //{
            //    isInHand = false;
            //}
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

    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if coliding with sleeve and filled is false
        if (collision.tag.Contains("Sleeve") && !collision.GetComponent<Sleeve>().filled)
        {
            canMove = false;
           //card position becomes sleeve position
           transform.position = collision.transform.position;
        }
    }
    */
    public void setPos(GameObject go)
    {
        canMove = false;
        transform.position = go.transform.position;
        Invoke("setMove", 0.5f);

    }

    public void setMove()
    {
        canMove = true;
    }
    

    private void OnDestroy()
    {
        handTracker.RemoveCard(gameObject);
    }

}
