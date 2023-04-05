using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeve : MonoBehaviour
{

    //check if sleeve has a card on it
    bool filled;
    //check card's corp and part
    int cardCorp;
    int cardPart;

    //geter and setter for card's corp and part
    public int CardCorp { get => cardCorp; set => cardCorp = value; }
    public int CardPart { get => cardPart; set => cardPart = value; }

    // Start is called before the first frame update
    void Start()
    {
        //initialize variables
        filled = false;
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
        }
        cardCorp = collision.GetComponent<Card>().CorpType;
        cardPart = collision.GetComponent<Card>().PartType;
        Debug.Log("Card's corp is: " + cardCorp);
        Debug.Log("Card's part is: " + cardPart);
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
