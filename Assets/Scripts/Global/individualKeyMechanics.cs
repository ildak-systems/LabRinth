using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class individualKeyMechanics : MonoBehaviour
{
    // Individual Key mechanics:
    // 1. Disappear once collision detected with player on Trigger
    // 2. Make a noise?
    void Awake()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }


}
