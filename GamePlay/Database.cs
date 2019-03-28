using UnityEngine;
public class Database
{
    private const string InventoryPlayerPrefsKey = "inventory";
    private const string inventoryPath = "Assets/Resources/";
    private const string resourcesInventoryPath = "Inventory/";
    private const string databaseAssetFileName = "ItemDatabase.asset";
    private const string databaseAssetFile = "ItemDatabase";
    private static ItemDatabase itemDB;
    public static Inventory CurrentInventory
    {
        get
        {
            if (Inventory.HasInstance)
                return Inventory.GetInstance();
            return ParseInventory(PlayerPrefs.GetString(InventoryPlayerPrefsKey, string.Empty));
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
            itemDB = Resources.Load<ItemDatabase>(resourcesInventoryPath + databaseAssetFile);
            if (itemDB == null)
                throw new ItemDatabaseNotExistsException(string.Format("ItemDatabase object cannot be found!"));
        }
        return itemDB;
    }

    private static Inventory ParseInventory(string inventoryHash)
    {
        var inventoryInstance = Inventory.GetInstance();

        if (!string.IsNullOrEmpty(inventoryHash))
        {
            string[] splittedString = inventoryHash.Split('|');
            var dbInstance = GetDatabaseInstance();
            for (int i = 0; i < splittedString.Length; i++)
            {
                inventoryInstance.AddItem(dbInstance.ParseItemFromIdString(splittedString[i]));
            }
        }
        return inventoryInstance;
    }
}