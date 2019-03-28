using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class AbstractPuzzleBase : MonoBehaviour
{
    public bool IsPuzzleSolved;
    public abstract void OpenPuzzle();
}
