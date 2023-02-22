using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(shoot))]
    public class eagletroop : enemyBaseClass
{
    private Transform player;
    private float range;
    public float minDist;
    public float projectileFireRate;
    float timeSinceLastFire;
    shoot shootScript;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

       // shootScript = GetComponent<shoot>();
       // shootScript.onProjectileSpawned.AddListener(UpdateTimeSinceLastFire);
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }
    }

    private void Update()
    {

        /*AnimatorClipInfo[] curClips = anim.GetCurrentAnimatorClipInfo(0);

        if (curClips[0].clip.name != "shooting")
        {
            if (Time.time >= timeSinceLastFire + projectileFireRate)
            {
                anim.SetTrigger("fire");
            }
        }*/


        transform.LookAt(player);



        /*  if (range <= 5f)
          {
              anim.SetTrigger("fire");
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
      }*/
    }
}
