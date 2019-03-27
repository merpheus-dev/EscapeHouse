using System;
using UnityEngine;

[Serializable]
public class Item : ScriptableObject
{
    public int Id=-1;
    public string Name;
    public Sprite Icon;
    public GameObject InspectionObject;
}
