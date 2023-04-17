using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    
    //card slots
    public int sleeves;
    //corp and part of sleeve's card
    int returnedCorp;
    int returnedType;
    //corp to assign to sleeve
    public int sleeveCorp;
    public GameObject sleeve;
    public List<GameObject> sleeveList = new List<GameObject>();
    public Vector2[] vectorList;

    //constructor
    public void setPart(Sprite s, int sl, int robotCorp)
    {
        Debug.Log("Sleeve count: " + sl);
        
        sleeves = sl;
        GetComponent<SpriteRenderer>().sprite = s;
        Debug.Log("CORP OF ROBOT:" + robotCorp);
        sleeveCorp = robotCorp;
        Debug.Log("NEW SLEEVE CORP: " + sleeveCorp);
    }

    public void UpdateSuit(int suit)
    {
        Debug.Log("Value passed to UpdateSuit: " + suit);

        sleeveCorp = suit;

        foreach (GameObject sleeve in sleeveList)
        {
            sleeve.GetComponent<Sleeve>().sleeveCorp = suit;
        }
    }

    private void Start()
    {
        //set vector array
        vectorList = new Vector2[4];
        vectorList[0] = new Vector2(transform.position.x - 1.5f, transform.position.y + 2);
        vectorList[1] = new Vector2(transform.position.x + 1.5f, transform.position.y + 2);
        vectorList[2] = new Vector2(transform.position.x - 2.5f, transform.position.y - 0.5f);
        vectorList[3] = new Vector2(transform.position.x + 2.5f, transform.position.y - 0.5f);
        Debug.Log("spawning sleeves");
        spawnSleeve(sleeves);
    }

    //check card corps
    public int checkCorp()
    {
        int matches = 0;
        for (int i = sleeveList.Count - 1; i >= 0; i--)
        {
            if (sleeveList[i].GetComponent<Sleeve>().checkCorp() == true)
            {
                matches++;
            }
        }
        return matches;
    }
    //check card types
    public int checkType()
    {
        int matches = 0;
        for (int i = sleeveList.Count - 1; i >= 0; i--)
        {
            if (sleeveList[i].GetComponent<Sleeve>().checkType() == true)
            {
                matches++;
            }
        }
        return matches;
    }
    //check sleeves
    public int returnSleeves()
    {
        return sleeveList.Count;
    }

    //spawn sleeves
    public void spawnSleeve(int spawn)
    {
       
        for (int i = 1; i <= spawn; i++)
        {
            //break so it only spawns a max of 4
            if (i > 4)
            {
                break;
            }
            //spawn
            sleeveList.Add(Instantiate(sleeve, vectorList[i - 1], Quaternion.identity));
            //assign corp
            sleeveList[i - 1].GetComponent<Sleeve>().SleeveCorp = sleeveCorp;
            //Debug.Log("SLEEVE'S CORP: " + sleeveCorp);
            
        }
    }

    

    public void OnDestroy()
    {
        if (this != null)
        {
            //when destroyed, remove all sleeves
            for (int i = sleeveList.Count - 1; i >= 0; i--)
            {
                if (sleeveList[i] != null)
                {
                    sleeveList[i].GetComponent<Sleeve>().ClearCards();
                }
            }
            Debug.Log("Count: " + sleeveList.Count);
        }
    }
}
