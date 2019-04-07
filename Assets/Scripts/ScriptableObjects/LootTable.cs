using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Loot
{
    [SerializeField] PowerUp _thisLoot;
    [SerializeField] int _lootChance;

    #region Properties
    public int LootChance
    {
        get
        {
            return _lootChance;
        }

        set
        {
            _lootChance = value;
        }
    }

    public PowerUp ThisLoot
    {
        get
        {
            return _thisLoot;
        }

        set
        {
            _thisLoot = value;
        }
    }
    #endregion
}

[CreateAssetMenu]
public class LootTable : ScriptableObject {

    [SerializeField] Loot[] _loots;

    public PowerUp LootPowerUp()
    {
        int cummulativeProbability = 0;
        int currentProbability = Random.Range(0, 100);
        for (int i = 0; i < _loots.Length; i++)
        {
            cummulativeProbability += _loots[i].LootChance;
            if(currentProbability <= cummulativeProbability)
            {
                return _loots[i].ThisLoot;
            }
        }
        return null;
    }
}
