using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(shoot))]
public class turret : MonoBehaviour
{
    public float projectileFireRate;
    float timeSinceLastFire;
    shoot shootScript;
    
    Animator anim;
    SpriteRenderer sr;
    public float range;
    public Transform Target;
    bool Detected = false;
    public GameObject player;
    private bool flip;

    void Start()
    {
        

        shootScript = GetComponent<shoot>();
        shootScript.onProjectileSpawned.AddListener(UpdateTimeSinceLastFire);
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;

        if(player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);   
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
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
