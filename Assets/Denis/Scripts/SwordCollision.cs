using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class SwordCollision : MonoBehaviour
{
    public GameObject boom;
    public float damage = 50f;

    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<EnemyMove>())
        {
            Instantiate(boom, collision.transform.position, collision.transform.rotation);
            collision.GetComponentInParent<Health>().Damage(damage);
        }
    }
}
