using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class projectile : MonoBehaviour
{
    public float lifetime;

    [HideInInspector]
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0)
            lifetime = 2.0f;

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifetime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    /* for damage when we get to it 
     private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.tag == "Enemy")
         {
             collision.gameObject.SendMessage("ApplyDamage", 10):
            Destroy(gameObject);
         }
     }*/

}
