using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttacking : MonoBehaviour
{
    public bool start_ = false;

    public GameObject hitEffect;
    public Transform hitStartPosition;

    public float attackDelay = 1.0f;
    public float attackRange = 1.0f;

    private Transform target;

    private bool isAttacking = false;
    private Vector3 lookDirection;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (start_)
        {
            // поворачиваем удар в направлении курсора мышки
            if (target != null)
            {
                lookDirection = target.position - transform.position;

                // поворачиваем удар в направлении игрока
                hitStartPosition.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);

                if (!isAttacking)
                {
                    // Если игрок в пределах радиуса атаки и AI не атакует, начать атаку
                    if (Vector2.Distance(transform.position, target.position) <= attackRange)
                    {
                        StartCoroutine(Attack());
                    }
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitStartPosition.position, attackRange);
    }

        IEnumerator Attack()
    {
        isAttacking = true;

        if (hitEffect != null)
        {
            Instantiate(hitEffect, hitStartPosition.position, hitStartPosition.rotation, hitStartPosition.transform);
        }

        // Ждем перед следующей атакой
        yield return new WaitForSeconds(attackDelay);

        isAttacking = false;
    }

}
