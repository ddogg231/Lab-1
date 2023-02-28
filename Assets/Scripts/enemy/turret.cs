using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class turret : MonoBehaviour
{
    public float projectileFireRate;
    float timeSinceLastFire;
    enemyshoot shootScript;
    
    Animator anim;
    SpriteRenderer sr;
    public float range;
    public float minDistance;
    public Transform Target;
    
    public GameObject player;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        shootScript = GetComponent<enemyshoot>();
        shootScript.onProjectileSpawned.AddListener(UpdateTimeSinceLastFire);
        

    }

    // Update is called once per frame
    void Update()
    {
        float range = GameObject.FindGameObjectWithTag("Player").transform.position.x - gameObject.transform.position.x;
        Debug.Log(range);
        Debug.Log("test");

        if (range < minDistance && range > -minDistance)
        {
           if (GameObject.FindGameObjectWithTag("Player").transform.position.x > transform.position.x)
            {
                sr.flipX = true;
            }
            else
                sr.flipX = false;

        }
        AnimatorClipInfo[] curClips = anim.GetCurrentAnimatorClipInfo(0);

        if (curClips[0].clip.name != "shooting")
            {

            if (Time.time >= timeSinceLastFire + projectileFireRate)
            {
                anim.SetTrigger("fire");
            }
        }
     }

      
    private void OnDisable()
    {
        shootScript.onProjectileSpawned.RemoveListener(UpdateTimeSinceLastFire);
    }



    void UpdateTimeSinceLastFire()
    {
        timeSinceLastFire = Time.time;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
