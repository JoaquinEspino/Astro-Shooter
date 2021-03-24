using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastShip : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public GameObject bullet, explosion, heart;

    public float xSpeed;
    public float ySpeed;
    public float speed;
    public bool canShoot;
    public float fireRate;
    public float health;
    public Color bulletColor;
    public int score;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Destroy(gameObject, 15);
        if (canShoot)
        {
            InvokeRepeating("Shoot", fireRate, fireRate);
        }

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(xSpeed, ySpeed * -1);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "New tag")
        {
            col.gameObject.GetComponent<PlayerMovement>().Damage();
            Die();
        }
    }

    void Die()
    {
        if ((int)Random.Range(0, 3) == 0)
        {
            Instantiate(heart, transform.position, Quaternion.identity);
        }
        Instantiate(explosion, transform.position, Quaternion.identity);
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
        Destroy(gameObject);
    }

    public void Damage ()
    {
        health--;
        if (health == 0)
        {
            Die();
        }
    }

    void Shoot()
    {
        GameObject temp = (GameObject) Instantiate(bullet, transform.position, Quaternion.identity);
        temp.GetComponent<Bullet>().ChangeDirection();
        temp.GetComponent<Bullet>().ChangeColor(bulletColor);
    }
}
