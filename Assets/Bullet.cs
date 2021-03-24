using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    int direction = 1;

    // Start is called before the first frame update

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, 10 * direction); 
    }

    public void ChangeDirection()
    {
        direction *= -1;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (direction == 1)
        {
            if (col.gameObject.tag == "New tag (1)")
            {
                col.gameObject.GetComponent<FastShip>().Damage();
                Destroy(gameObject);
            }
        }
        else
        {
            if (col.gameObject.tag == "New tag")
            {
                col.gameObject.GetComponent<PlayerMovement>().Damage();
                Destroy(gameObject);
            }
        }
    }

    public void ChangeColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }
}
