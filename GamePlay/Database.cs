using UnityEngine;
public class Database
{
    private const string InventoryPlayerPrefsKey = "inventory";
    private const string inventoryPath = "Assets/Resources/";
    private const string resourcesInventoryPath = "Inventory/";
    private const string databaseAssetFileName = "ItemDatabase.asset";
    private static ItemDatabase itemDB;
    public static Inventory CurrentInventory
    {
        get
        {
            if (PlayerPrefs.HasKey(InventoryPlayerPrefsKey))
            {
                return ParseInventory(PlayerPrefs.GetString(InventoryPlayerPrefsKey));
            }
            else
            {
                return Inventory.GetInstance();
            }

        }
    }

    public static string GetDatabasePath()
    {
        return inventoryPath + resourcesInventoryPath + databaseAssetFileName;
    }

    public static ItemDatabase GetDatabaseInstance()
    {
        if (itemDB == null)
        {
            itemDB = Resources.Load<ItemDatabase>(resourcesInventoryPath + databaseAssetFileName);
            if (itemDB == null)
                throw new ItemDatabaseNotExistsException();
        }
        return itemDB;
    }

    private static Inventory ParseInventory(string inventoryHash)
    {
        string[] splittedString = inventoryHash.Split('|');

        var inventoryInstance = Inventory.GetInstance();

        var dbInstance = GetDatabaseInstance();
        for (int i = 0; i < splittedString.Length; i++)
        {
            inventoryInstance.AddItem(dbInstance.ParseItemFromIdString(splittedString[i]));
        }
        return inventoryInstance;
    }
}