using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void PrimaryUse();

    public void SecondaryUse();
    public void Focus();
    public void Unfocus();
}
