using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform tf;
    public float turnSpeed = 1f;
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.player = this.gameObject;
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
         tf.Rotate(0, 0, turnSpeed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tf.Rotate(0, 0, -turnSpeed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tf.Translate(Vector3.down * moveSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        //NOT the efficient WAY of creating bullets
        //GameObject bullet = new GameObject();
        //SpriteRenderer bulletSpriteRenderer = bullet.AddComponent<SpriteRenderer>() as SpriteRenderer;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Bullet>().bulletSpeed = bulletSpeed;
        Destroy(bullet, 3);
    }
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        //if the player runs into something they should die
        Die();
    }
    void Die()
    {
        Destroy(this.gameObject);
    }
    private void OnDestroy()
    {
        GameManager.instance.player = null;
    }
}

