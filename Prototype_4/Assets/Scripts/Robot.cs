using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Robot : MonoBehaviour
{
    int corp;
    GameObject part;
    Sprite robotSprite;
    bool hasSecurity;
    string dialogue;

    public Robot(int corp, GameObject part, Sprite sprite, bool hasSecurity, string dialogue)
    {
        this.Corp = corp;
        this.Part = part;
        RobotSprite = sprite;
        this.HasSecurity = hasSecurity;
        this.Dialogue = dialogue;
    }
   
    public int Corp { get => corp; set => corp = value; }
    public bool HasSecurity { get => hasSecurity; set => hasSecurity = value; }
    public string Dialogue { get => dialogue; set => dialogue = value; }
    public Sprite RobotSprite { get => robotSprite; set => robotSprite = value; }
    public GameObject Part { get => part; set => part = value; }
}
