using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(shoot))]
    public class eagletroop : enemyBaseClass
{
    private Transform player;
    private float range;
    public float howClose;
    public float projectileFireRate;
    float timeSinceLastFire;
    shoot shootScript;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        shootScript = GetComponent<shoot>();
        shootScript.onProjectileSpawned.AddListener(UpdateTimeSinceLastFire);
        player = GameObject.FindGameObjectWithTag("player").transform;
    }


    private void Update()
    {
        AnimatorClipInfo[] curClips = anim.GetCurrentAnimatorClipInfo(0);

        if (curClips[0].clip.name !="shooting");
        {
            if (Time.time >= timeSinceLastFire + projectileFireRate)
            {
                anim.SetTrigger("shooting");
            }
        }
        range = Vector3.Distance(player.position, transform.position);
        
        if (range <= howClose)
        {
            transform.LookAt(player);
            
        }
        if (range <= 5f)
        {
            anim.SetTrigger("shooting");
        }    
    }
    private void OnDisable()
    {
        shootScript.onProjectileSpawned.RemoveListener(UpdateTimeSinceLastFire);
    }
    // Update is called once per frame
    void UpdateTimeSinceLastFire()
    {
        timeSinceLastFire = Time.time;
    }
}
