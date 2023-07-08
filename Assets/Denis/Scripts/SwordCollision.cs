using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class SwordCollision : MonoBehaviour
{
    public GameObject boom;
    public GameObject deadBody;

    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<EnemyMove>())
        {
            Debug.Log("EnemyRIP");
            Instantiate(boom, collision.transform.position, collision.transform.rotation);
            Instantiate(deadBody, collision.transform.position, collision.transform.rotation);
            Destroy(collision.GetComponentInParent<EnemyMove>().gameObject);
        }
    }
}
