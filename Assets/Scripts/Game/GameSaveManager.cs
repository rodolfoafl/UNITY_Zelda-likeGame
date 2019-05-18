using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveManager : MonoBehaviour {

    public static GameSaveManager _gameSaveManager;

    [SerializeField] List<ScriptableObject> _objects = new List<ScriptableObject>();

    void Awake()
    {
        if(_gameSaveManager == null)
        {
            _gameSaveManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }  

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
        for (int i = 0; i < _objects.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.dat", i));
            BinaryFormatter formatter = new BinaryFormatter();
            var json = JsonUtility.ToJson(_objects[i]);
            formatter.Serialize(file, json);
            file.Close();
        }
    }

    public void LoadScriptables()
    {
        for (int i = 0; i < _objects.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath + string.Format("/{0}.dat", i)))
            {
                FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.dat", i), FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)formatter.Deserialize(file), _objects[i]);
                file.Close();
            }
        }
    }

    public void ResetScriptables()
    {
        for (int i = 0; i < _objects.Count; i++)
        {
            if(File.Exists(Application.persistentDataPath + string.Format("/{0}.dat", i)))
            {
                File.Delete(Application.persistentDataPath + string.Format("/{0}.dat", i));
            }
        }
    }
}
