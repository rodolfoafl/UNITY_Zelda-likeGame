using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

public class InventoryPersistence : MonoBehaviour
{
    public static InventoryPersistence _inventoryPersistence;

    [SerializeField] PlayerInventory _playerInventory;

    void OnEnable()
    {
        LoadScriptables();
    }

    void OnDisable()
    {
        SaveScriptables();
    }

    public void SaveScriptables()
    {
        ResetScriptables();

        for (int i = 0; i < _playerInventory.Inventory.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.inv", i));
            BinaryFormatter formatter = new BinaryFormatter();
            var json = JsonUtility.ToJson(_playerInventory.Inventory[i]);
            formatter.Serialize(file, json);
            file.Close();
        }
    }

    public void LoadScriptables()
    {
        ResetScriptables();

        int i = 0;
        while (File.Exists(Application.persistentDataPath + string.Format("/{0}.inv", i)))
        {
            var temporaryInventory = ScriptableObject.CreateInstance<InventoryItem>();

            FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.inv", i), FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            JsonUtility.FromJsonOverwrite((string)formatter.Deserialize(file), temporaryInventory);
            file.Close();
            _playerInventory.Inventory.Add(temporaryInventory);
            i++;
        }
    }

    public void ResetScriptables()
    {
        int i = 0;
        while (File.Exists(Application.persistentDataPath + string.Format("/{0}.inv", i)))
        {
            File.Delete(Application.persistentDataPath + string.Format("/{0}.inv", i));
            i++;
        }
    }
}
