using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("OnTriggerEnter2D");
        if (other.CompareTag("Breakable"))
        {
            if (other.GetComponent<Pot>() != null)
            {
                other.GetComponent<Pot>().Break();
            }
            else
            {
                Debug.Log("Hitting an unbreakable object!");
            }
        }
    }
}
