using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemyRoom : DungeonRoom {
    [SerializeField] Door[] _doors;
    [SerializeField] Signal _enemyUpdate;

    public void CheckEnemies()
    {
        if (Enemies.Length > 0)
        {
            for (int i = 0; i < Enemies.Length; i++)
            {
                if (Enemies[i].gameObject.activeInHierarchy)
                {
                    return;
                }
            }
            ChangeDoors(true);
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            ChangeActivation(Enemies, true);
            ChangeDoors(false);
            VirtualCamera.SetActive(true);
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            ChangeActivation(Enemies, false);
            VirtualCamera.SetActive(false);
        }
    }

    public void ChangeDoors(bool isOpen)
    {
        Debug.Log("ChangeDoors");
        if (_doors.Length > 0)
        {
            for (int i = 0; i < _doors.Length; i++)
            {
                if (isOpen)
                {
                    _doors[i].Open();
                }
                else
                {
                    _doors[i].Close();
                }
            }
        }
    }
}
