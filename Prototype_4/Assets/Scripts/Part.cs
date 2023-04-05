using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    //Sprite for part
    Sprite sprite;
    //card slots
    public int sleeves;
    //corp and part of sleve's card
    int returnedCorp;
    int returnedPart;
    GameObject[] sleeveList;

    //constructor
    public Part(Sprite s, int sl)
    {
        sprite = s;
        sleeves = sl;
    }

    //check card slots
    public void check()
    { 
        
    }
   
}
