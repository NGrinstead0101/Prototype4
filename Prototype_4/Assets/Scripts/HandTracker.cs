using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracker : MonoBehaviour
{
    public List<GameObject> cardsInHand;
    [SerializeField] Vector2 leftHandBound;
    Vector2 secondRowLeftBound;
    [SerializeField] float spacing;

    [SerializeField] CardConstruction cardConstruction;

    private void Awake()
    {
        secondRowLeftBound = new Vector2(leftHandBound.x, leftHandBound.y - 0.92f);

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

            cardsInHand[0].GetComponent<SpriteRenderer>().sortingOrder = 3;
            foreach (Transform child in cardsInHand[0].transform)
            {
                child.GetComponent<SpriteRenderer>().sortingOrder = 4;

                if (child.childCount != 0)
                {
                    child.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 5;
                }
            }

            int previousLayer = 6;

            for (int i = 1; i < cardsInHand.Count; ++i)
            {
                float newXPos = previousCard.transform.position.x + spacing;
                if (newXPos >= 8)
                {
                    cardsInHand[i].transform.position = secondRowLeftBound;
                }
                else
                {
                    cardsInHand[i].transform.position = new Vector2(newXPos, previousCard.transform.position.y);
                }
                previousCard = cardsInHand[i];

                cardsInHand[i].GetComponent<SpriteRenderer>().sortingOrder = previousLayer;
                previousLayer++;

                foreach (Transform child in cardsInHand[i].transform)
                {
                    child.GetComponent<SpriteRenderer>().sortingOrder = previousLayer;

                    if (child.childCount != 0)
                    {
                        child.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = previousLayer + 1;
                    }
                }

                previousLayer += 2;
            }
        }
    }

    public void RemoveCard(GameObject card)
    {
        if (cardsInHand.Contains(card))
        {
            cardsInHand.Remove(card);
        }
    }

    public void BuyCard(int suit, int type)
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
