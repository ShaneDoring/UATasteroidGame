﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.up * bulletSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
      
        {
            Die();
        }


    }


    void Die()
    {
        Destroy(this.gameObject);
    }
}
