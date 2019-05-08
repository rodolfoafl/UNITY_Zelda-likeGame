using System.Collections;
using System.Collections.Generic;
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
}
