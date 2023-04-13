using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeve : MonoBehaviour
{

    [SerializeField] List<Sprite> typeSpriteList;
    [SerializeField] SpriteRenderer typeSprite;

    //check if sleeve has a card on it
    bool filled;
    //check card's corp and part
    public int cardCorp;
    public int cardType;
    public int sleeveCorp;
    public int sleeveType;

    GameObject currentCard;

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
        if (collision.tag.Contains("Card"))
        {
            //filled is true
            filled = true;
            currentCard = collision.gameObject;
            Debug.Log("Filled: " + filled);
            cardCorp = collision.GetComponent<Card>().Corp;
            cardType = collision.GetComponent<Card>().Type;
            Debug.Log("Card's corp is: " + cardCorp);
            Debug.Log("Card's type is: " + cardType);
            if (checkCorp()) Debug.Log("Corp match");
            if (checkType()) Debug.Log("Type match");
        }
       
    }

    public bool checkCorp()
    {
        if (sleeveCorp == cardCorp)
        {
            return true;
        }
        else return false;
    }

    public bool checkType()
    {
        if (sleeveType == cardType)
        {
            return true;
        }
        else return false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if collision is card
        if (collision.tag.Contains("Card"))
        {
            //filled is false
            filled = false;
            currentCard = null;
            Debug.Log("Filled: " + filled);
        }
    }

    public void ClearCards()
    {
        Destroy(currentCard);
        Destroy(gameObject);
    }
}
