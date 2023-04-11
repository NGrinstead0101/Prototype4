using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracker : MonoBehaviour
{
    public List<GameObject> cardsInHand;
    [SerializeField] Vector2 leftHandBound;
    [SerializeField] float spacing;

    [SerializeField] CardConstruction cardConstruction;

    private void Awake()
    {
        cardsInHand = cardConstruction.GenerateBaseCards();

        PositionCards();
    }

    private void PositionCards()
    {
        if (cardsInHand.Count != 0)
        {
            GameObject previousCard;
            previousCard = cardsInHand[0];
            cardsInHand[0].transform.position = leftHandBound;

            for (int i = 1; i < cardsInHand.Count; ++i)
            {
                cardsInHand[i].transform.position = new Vector2(previousCard.transform.position.x + spacing, previousCard.transform.position.y);
                previousCard = cardsInHand[i];
            }
        }
    }

    public void BuyCard(int suit, int type = -1)
    {
        GameObject newCard;

        if (type == -1)
        {
            newCard = cardConstruction.CreateCardWithSuit(suit);
        }
        else
        {
            newCard = cardConstruction.CreateCardWithPart(suit, type);
        }

        cardsInHand.Add(newCard);
        PositionCards();
    }
}
