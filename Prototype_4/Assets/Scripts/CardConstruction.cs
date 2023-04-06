using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardConstruction : MonoBehaviour
{
    Sprite[] corpSprites;
    Sprite[] partSprites;

    [SerializeField] GameObject baseCardPrefab;
    Card currentCard;

    // could maybe have script that remembers what cards you have
    //[SerializeField] CardTracker cardTracker;

    // rows are cards columns are corp, part, and bonus
    int[][] baseCardSet;

    public void GenerateBaseCards()
    {
        // instantiates card for each row in baseCardSet
        GameObject temp;

        for (int i = 0; i < baseCardSet.Length; ++i)
        {
            temp = Instantiate(baseCardPrefab);
            // pass card tracker the new card

            currentCard = temp.GetComponent<Card>();
            int corp = baseCardSet[i][0];
            int part = baseCardSet[i][1];
            currentCard.CreateCard(corp, part, corpSprites[corp], partSprites[part]);
        }
    }

    public void CreateCardWithSuit(int chosenSuit)
    {
        GameObject temp = Instantiate(baseCardPrefab);
        // pass card tracker the new card
        
        currentCard = temp.GetComponent<Card>();
        int randPart = Random.Range(0, 4);
        currentCard.CreateCard(chosenSuit, randPart, corpSprites[chosenSuit], partSprites[randPart]);
    }

    public void CreateCardWithPart(int chosenSuit, int chosenPart)
    {
        GameObject temp = Instantiate(baseCardPrefab);
        // pass card tracker the new card

        currentCard = temp.GetComponent<Card>();
        currentCard.CreateCard(chosenSuit, chosenPart, corpSprites[chosenSuit], partSprites[chosenPart]);
    }
}
