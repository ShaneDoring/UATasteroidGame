using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    private Vector3 targetPosition;
    public float rotationSpeed;
    public float moveSpeed;
    private Vector3 directionToMove;
    // Start is called before the first frame update
    // on start enemy ship will be added to the enemy list to be spawned in at random spawn point and will heat seek the player
    void Start()
    {
        GameManager.instance.enemyList.Add(this.gameObject);
        directionToMove = GameManager.instance.player.transform.position - transform.position;
        directionToMove.Normalize();
        targetPosition = GameManager.instance.player.transform.position;
    }

    // Update is called once per frame
    //on update the enemy ship will redirect itself toward the player
    void Update()
    {
        targetPosition = GameManager.instance.player.transform.position;
        Vector3 directionToLook = targetPosition - transform.position;
        transform.up = directionToLook;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        //Error to fix
        //transform.rotation= Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.right, transform.forward), rotationSpeed * Time.deltaTime);
    }

    //removes the enemy ship from the list when it is destroyed
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
        else
        {
            Die();
        }


    }


    void Die()
    {
        Destroy(this.gameObject);
    }
}
