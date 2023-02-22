using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(shoot))]
    public class eagletroop : enemyBaseClass
{
    public float projectileFireRate;
    float timeSinceLastFire;
    shoot shootScript;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        shootScript = GetComponent<shoot>();
        shootScript.onProjectileSpawned.AddListener(UpdateTimeSinceLastFire);
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
