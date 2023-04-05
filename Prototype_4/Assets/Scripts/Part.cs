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
    public GameObject sleeve;
    public GameObject[] sleeveList;

    //constructor
    public Part(Sprite s, int sl)
    {
        sprite = s;
        sleeves = sl;
    }

    private void Start()
    {
        spawnSleeve(sleeves);
    }

    //check card slots
    public void check()
    { 
        
    }

    //spawn sleeves
    public void spawnSleeve(int spawn)
    {
        //spawn vector
        Vector2 spawnPos;
        for (int i = 1; i <= spawn; i++)
        {
            //break so it only spawns a max of 4
            if (i > 4)
            {
                break;
            }
            //set spawn
            if (i == 1)
            {
                spawnPos = new Vector2(transform.position.x, transform.position.y + 3);
            }
            else if (i == 2)
            {
                spawnPos = new Vector2(transform.position.x + 3, transform.position.y);
            }
            else if (i == 3)
            {
                spawnPos = new Vector2(transform.position.x, transform.position.y - 3);
            }
            else
            {
                spawnPos = new Vector2(transform.position.x - 3, transform.position.y);
            }
            //spawn sleeve object
            Instantiate(sleeve, spawnPos, Quaternion.identity);
        }
    }
}
