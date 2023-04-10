using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracker : MonoBehaviour
{
    public List<GameObject> cardsInHand;
    [SerializeField] List<Vector2> cardPositions;

    [SerializeField] CardConstruction cardConstruction;

    private void Awake()
    {
        cardsInHand = cardConstruction.GenerateBaseCards();
        for (int i = 0; i < cardsInHand.Count && i < cardPositions.Count; ++i)
        {
            cardsInHand[i].transform.position = cardPositions[i];
        }
    }


}
