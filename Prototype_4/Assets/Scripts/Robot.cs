using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Robot : MonoBehaviour
{
    int corp;
    //Part part;
    Sprite robotSprite;
    bool hasSecurity;
    string dialogue;

    public Robot(int corp, /*Part part,*/ Sprite sprite, bool hasSecurity, string dialogue)
    {
        this.Corp = corp;
        //this.part = part;
        robotSprite = sprite;
        // set sprite here
        this.HasSecurity = hasSecurity;
        this.Dialogue = dialogue;
    }
   
    public int Corp { get => corp; set => corp = value; }
    public bool HasSecurity { get => hasSecurity; set => hasSecurity = value; }
    public string Dialogue { get => dialogue; set => dialogue = value; }
}
