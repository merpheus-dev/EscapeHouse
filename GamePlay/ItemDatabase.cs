using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ItemDatabase : ScriptableObject
{
    public List<Item> Items = new List<Item>();

    public Item ParseItemFromIdString(string idString)
    {
        int targetId = int.Parse(idString);
        CheckItemExistanceWithId(targetId);
        return Items.Find(x => x.Id == targetId);
    }

    private void CheckItemExistanceWithId(int targetId)
    {
        if (!Items.Exists(x => x.Id == targetId))
            throw new ItemNotExistsException();
    }
}
