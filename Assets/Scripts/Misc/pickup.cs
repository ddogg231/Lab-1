using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class pickup : MonoBehaviour
{
    public enum Pickuptype
    {
        powerup = 0,
        life = 1,
        score = 2,
    }

    public Pickuptype currentPickup;

    public object PickupType { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController temp = collision.gameObject.GetComponent<PlayerController>();
            switch (currentPickup)
            {
                case Pickuptype.powerup:
                    temp.StartJumpForceChange();
                    break;

                case Pickuptype.life:
                    temp.lives++;
              
                    break;

                case Pickuptype.score:
                    temp.StartSpeedChange();
                    break;


            }
            Destroy(gameObject);
        }
    }
}
