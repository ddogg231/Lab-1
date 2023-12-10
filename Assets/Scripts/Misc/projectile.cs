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
        if (collision.gameObject.CompareTag("EnemyShots") && collision.gameObject.CompareTag("Player"))
            GameManager.Instance.lives--;

        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("wall"))
            Destroy(gameObject);

        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.lives--;
        }

        if (collision.gameObject.CompareTag("Enemy"))
            
        Debug.Log("enemy hit");
        
        Destroy(gameObject);
    }


}
