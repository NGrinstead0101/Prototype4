using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeve : MonoBehaviour
{

    [SerializeField] List<Sprite> typeSpriteList;
    [SerializeField] SpriteRenderer typeSprite;

    //check if sleeve has a card on it
    public bool filled;
    //check card's corp and part
    public int cardCorp = -1;
    public int cardType = -1;
    public int sleeveCorp;
    public int sleeveType;

    public GameObject currentCard;

    //geter and setter for card's corp and part
    public int CardCorp { get => cardCorp; set => cardCorp = value; }
    public int CardType { get => cardType; set => cardType = value; }
    public int SleeveCorp { get => sleeveCorp; set => sleeveCorp = value; }
    public int SleeveType { get => sleeveType; set => sleeveType = value; }

    // Start is called before the first frame update
    void Start()
    {
        //initialize variables
        filled = false;
        sleeveType = Random.Range(0, 4);
        typeSprite.sprite = typeSpriteList[sleeveType];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if collision is card
        if (collision.tag.Contains("Card") && filled == false)
        {
            Invoke("SetFilled", 0.1f);
            currentCard = collision.gameObject;
            Debug.Log("Filled: " + filled);
            cardCorp = collision.GetComponent<Card>().Corp;
            cardType = collision.GetComponent<Card>().Type;
            Debug.Log("Card's corp is: " + cardCorp);
            Debug.Log("Card's type is: " + cardType);
            Debug.Log("Sleeve's corp is: " + sleeveCorp);
            Debug.Log("Sleeve's type is: " + sleeveType);
            if (checkCorp()) Debug.Log("Corp match");
            if (checkType()) Debug.Log("Type match");
                 
        }
            
       
    }

    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if collision is card
        if (collision.tag.Contains("Card"))
        {
            collision.transform.position = transform.position;
            
        }
    }
    */



    public bool checkCorp()
    {
        if (filled && (sleeveCorp == cardCorp || cardCorp == 3))
        {
            return true;
        }
        else return false;
    }

    public bool checkType()
    {
        if (filled && sleeveType == cardType)
        {
            return true;
        }
        else return false;
    }

    public void SetFilled()
    {
        filled = true;

    }
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if collision is card.
        if (collision.tag.Contains("Card") && collision.gameObject == currentCard.gameObject)
        {
            //filled is false
            filled = false;
            cardCorp = -1;
            cardType = -1;
            if (currentCard != null)
            { 
                currentCard = null; 
            }
            Debug.Log("Filled: " + filled);
        }
    }

    public void ClearCards()
    {
        Debug.Log("ClearCardsCalled");
        if (currentCard != null)
        {
            Destroy(currentCard.gameObject);
        }
        Destroy(gameObject);
    }
}
