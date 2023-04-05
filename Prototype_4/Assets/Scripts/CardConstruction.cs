using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardConstruction : MonoBehaviour
{
    Sprite[] corpSprites;
    Sprite[] typeSprites;

    [SerializeField] GameObject baseCardPrefab;
    Card currentCard;

    // could maybe have script that remembers what cards you have
    //[SerializeField] CardTracker cardTracker;

    public void GenerateBaseCards()
    {
        GameObject temp;

        for (int i = 0; i < 5; ++i)
        {
            for (int j = 0; j < 5; ++i)
            {
                temp = Instantiate(baseCardPrefab);
                currentCard = temp.GetComponent<Card>();
                currentCard.CreateCard(i, j, corpSprites[i], typeSprites[j]);
            }
        }
    }

    public void CreateCardWithSuit(int chosenSuit)
    {
        GameObject temp = Instantiate(baseCardPrefab);
        // pass card tracker the new card
        
        currentCard = temp.GetComponent<Card>();
        int randType = Random.Range(0, 4);
        currentCard.CreateCard(chosenSuit, randType, corpSprites[chosenSuit], typeSprites[randType]);
    }

    public void CreateCardWithPart(int chosenSuit, int chosenType)
    {
        GameObject temp = Instantiate(baseCardPrefab);
        // pass card tracker the new card

        currentCard = temp.GetComponent<Card>();
        currentCard.CreateCard(chosenSuit, chosenType, corpSprites[chosenSuit], typeSprites[chosenType]);
    }
}
