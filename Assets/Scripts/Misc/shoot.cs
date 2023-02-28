using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class shoot : MonoBehaviour
{
    SpriteRenderer sr;

    public UnityEvent onProjectileSpawned;
    public float projectilespeed;
    public Transform spawnPointRight;
    public Transform spawnPointLeft;

    public projectile projectilePrefab;

    public object OnProjectileSpawned { get; internal set; }

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (projectilespeed <= 0)
            projectilespeed = 15.0f;

        if (!spawnPointLeft || !spawnPointRight || !projectilePrefab)
            Debug.Log("Pease set up default values on" + gameObject.name);
    }

   
    public void fire()
    {
        
       
        if (!sr.flipX)
        {
            projectile curprojectile = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
            curprojectile.speed = projectilespeed;
        }
        else
        {
            projectile curprojectile = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            curprojectile.speed = -projectilespeed;
        }
        onProjectileSpawned?.Invoke();
    }
}
