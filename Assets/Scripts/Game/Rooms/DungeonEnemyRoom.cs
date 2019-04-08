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
            StartCoroutine(CallChangeDoors(true));
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            ChangeActivation(Enemies, true);
            StartCoroutine(CallChangeDoors(false));
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

    IEnumerator CallChangeDoors(bool isOpen)
    {
        yield return new WaitForSeconds(1f);
        ChangeDoors(isOpen);
    }

    public void ChangeDoors(bool isOpen)
    {
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
