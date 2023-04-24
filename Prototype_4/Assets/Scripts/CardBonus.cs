using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBonus
{
    int bonusTargetType = -1;
    bool isMultiplier;

    public CardBonus(int type, bool isMultiplier)
    {
        bonusTargetType = type;
        this.isMultiplier = isMultiplier;
    }
}
