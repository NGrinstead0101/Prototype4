using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeve : MonoBehaviour
{

    //check if sleeve has a card on it
    bool filled;
    
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
        int cardCorp = collision.GetComponent<Card>().CorpType;
        int cardPart = collision.GetComponent<Card>().PartType;
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
