using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeve : MonoBehaviour
{

    //check if sleeve has a card on it
    bool filled;
    //check card's corp and part
    public int cardCorp;
    public int cardType;
    public int sleeveCorp;
    public int sleeveType;

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
        sleeveType = Random.Range(0, 2);
        
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
            Debug.Log("Filled: " + filled);
            cardCorp = collision.GetComponent<Card>().Corp;
            cardType = collision.GetComponent<Card>().Type;
            Debug.Log("Card's corp is: " + cardCorp);
            Debug.Log("Card's type is: " + cardType);
        }
       
    }

    public bool checkSleeve()
    {
        //variables to check if corp and types match
        bool corpMatch = false;
        bool typeMatch = false;
        //check if card's corp is same as sleeve
        if (cardCorp == sleeveCorp || cardCorp == 3)
        {
            Debug.Log("Corp match. Card's corp is " + cardCorp + " Sleeve's corp is " + sleeveCorp);
            corpMatch = true;
        }
        else Debug.Log("Corp different. Card's corp is " + cardCorp + " Sleeve's corp is " + sleeveCorp);
        //check if card's type is same as sleeve
        if (cardType == sleeveType || cardCorp == 3)
        {
            Debug.Log("Type match. Card's type is " + cardType + " Sleeve's type is " + sleeveType);
            typeMatch = true;
        }
        else Debug.Log("Type different.  Card's type is " + cardType + " Sleeve's type is " + sleeveType);
        //return true if corps match and types match
        return (corpMatch && typeMatch);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if collision is card
        if (collision.tag.Contains("Card"))
        {
            //filled is false
            filled = false;
            Debug.Log("Filled: " + filled);
        }
    }
}
