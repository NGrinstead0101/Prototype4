using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    //Sprite for part
    Sprite sprite;
    //card slots
    int slots;

    //constructor
    public Part(Sprite s, int sl)
    {
        sprite = s;
        slots = sl;
    }

    //check card slots
    public void check()
    { 
        
    }
   
}
