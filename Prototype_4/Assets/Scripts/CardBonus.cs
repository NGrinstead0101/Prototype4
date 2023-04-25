using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBonus
{
    public int bonusTargetType = -1;
    public bool isMultiplier;

    public CardBonus(int type, bool isMultiplier)
    {
        bonusTargetType = type;
        this.isMultiplier = isMultiplier;
    }
}
