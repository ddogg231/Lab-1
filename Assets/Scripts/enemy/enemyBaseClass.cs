using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBaseClass : MonoBehaviour
{
    protected SpriteRenderer sr;
    protected Animator anim;
    public int maxHeath;
    protected int _heath;


    public int heath   
    {
        get => heath;
        set
        {
            _heath = value;

            if (_heath > maxHeath)
                _heath = maxHeath;

            if (_heath <= 0)
                Death();
        }
    }

    public virtual void Death()
    {
        anim.SetTrigger("death");
    }
    // Start is called before the first frame update
    public virtual void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        if (maxHeath <= 0)
            maxHeath = 5;
        heath = maxHeath;
    }



    public virtual void TakeDamage(int damage)
    {
        heath -= damage;
    }

    public void death()
        {
        anim.SetTrigger("death");
        }
    public void Destroyself()
    {
        Destroy(gameObject.transform.parent.gameObject.transform.parent);
    }
}
