using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class turret : enemyBaseClass
{
    public float projectileFireRate;
    float timeSinceLastFire;
    enemyshoot shootScript;
    public float minDistance;
    
    public AudioClip firesound;

    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        shootScript = GetComponent<enemyshoot>();
        shootScript.onProjectileSpawned.AddListener(UpdateTimeSinceLastFire);
        asm = GetComponent<audiomanager>();

    }

    // Update is called once per frame
    void Update()
    {
        float range = GameManager.Instance.playerInstance.transform.position.x - gameObject.transform.position.x;
        //Debug.Log(range);
        //Debug.Log("test");

        AnimatorClipInfo[] curClips = anim.GetCurrentAnimatorClipInfo(0);
        if (range < minDistance && range > -minDistance)
        {
           
             if (Time.time >= timeSinceLastFire + projectileFireRate)
                   {
                     anim.SetTrigger("fire");
                        
                   }
            if (GameManager.Instance.playerInstance.transform.position.x > transform.position.x)
            {    
                sr.flipX = true;
            }
            else
             sr.flipX = false;    
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
