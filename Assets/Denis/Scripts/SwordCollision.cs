using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class SwordCollision : MonoBehaviour
{
    public bool player = false;
    public GameObject boom;
    public float damage = 50f;

    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player)
        {
            if (collision.GetComponentInParent<EnemyMove>())
            {
                Instantiate(boom, collision.transform.position, collision.transform.rotation);
                collision.GetComponentInParent<Health>().Damage(damage);
            }
        }
        else
        {
            if (collision.GetComponentInParent<PlayerMovement>())
            {
                //Instantiate(boom, collision.transform.position, collision.transform.rotation);
                collision.GetComponentInParent<Health>().Damage(damage);
            }
        }
    }
}
