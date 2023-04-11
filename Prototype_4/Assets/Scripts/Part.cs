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
    public GameObject sleeve;
    public List<GameObject> sleeveList = new List<GameObject>();
    public Vector2[] vectorList;

    //constructor
    public void setPart(Sprite s, int sl)
    {
        Debug.Log("Sleeve count: " + sl);
        
        sleeves = sl;
        GetComponent<SpriteRenderer>().sprite = s;
    }

    private void Start()
    {
        //set vector array
        vectorList = new Vector2[4];
        vectorList[0] = new Vector2(transform.position.x, transform.position.y + 3);
        vectorList[1] = new Vector2(transform.position.x + 3, transform.position.y);
        vectorList[2] = new Vector2(transform.position.x, transform.position.y - 3);
        vectorList[3] = new Vector2(transform.position.x - 3, transform.position.y);
        spawnSleeve(sleeves);
    }

    //check card slots
    public void check()
    { 
        
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
            
        }
    }
    

    public void OnDestroy()
    {
        //when destroyed, remove all sleeves
        for (int i = sleeveList.Count - 1; i >= 0; i--)
        {
            GameObject.Destroy(sleeveList[i]);
        }
    }
}
