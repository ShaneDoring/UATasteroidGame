﻿using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Vector3 directionToMove;
    private Vector3 targetPosition;
    public float moveSpeed;

    private void Start()
    {
        //at start designates enemies into the enemy list and makes the asteroid fly towards the player at the direction of the player when it spawns
        GameManager.instance.enemyList.Add(this.gameObject);
        directionToMove = GameManager.instance.player.transform.position - transform.position;
        directionToMove.Normalize();
        targetPosition = GameManager.instance.player.transform.position;
    }
    private void Update()
    {
         transform.position += directionToMove* moveSpeed * Time.deltaTime;
        // transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
       // transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);
    }

    //removes the enemy from the enemy list when destoyed
    private void OnDestroy()
    {
        GameManager.instance.enemyList.Remove(this.gameObject);
    }

    //when the object collides with the bullet it will be destoyed 
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        Debug.Log("Collided with something");
        Debug.Log(otherObject.gameObject.name);
        if (otherObject.gameObject == GameManager.instance.player)
        {
            Debug.Log("Collided with the player game object");
            //this is when the player is hit the asteroid
        }
        else
        {
            Die();
        }
      
       
    }
    


    void Die()
    {
        Destroy(this.gameObject);
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
