using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.enemyList.Add(this.gameObject);
    }

    private void OnDestroy()
    {
        GameManager.instance.enemyList.Remove(this.gameObject);
    }


    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        Debug.Log("Collided with something");
        Debug.Log(otherObject.gameObject.name);
        if (otherObject.gameObject == GameManager.instance.player)
        {
            Debug.Log("Collided with the player game object");
            //this is when the player is hit the asteroid
        }
    }
   /* private void OnCollisionExit2D(Collision2D otherObject)
    {
        Debug.Log("Stopped Collideing with something");
    }
    private void OnCollisionStay2D(Collision2D otherObject)
    {
        Debug.Log("Am Collidding with something");
    }*/
}
