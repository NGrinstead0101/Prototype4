using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    public abstract void ShowInfo();

    public abstract void ChangeState();
}
