using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
   public bool dead = false;

    // Update is called once per frame
    void Update()
    {

    }

     private void OnCollisionEnter2D(Collision2D CoInfo)
    {
        if (CoInfo.gameObject.CompareTag("Dead"))
            dead = true;
    }
}
