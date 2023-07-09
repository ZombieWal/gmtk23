using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
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
        // ������������ ���� � ����������� ������� �����
        lookDirection = target.position - transform.position;
        // ������������ ���� � ����������� ������
        hitStartPosition.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);

        if (!isAttacking)
        {
            // ���� ����� � �������� ������� ����� � AI �� �������, ������ �����
            if (Vector2.Distance(transform.position, target.position) <= attackRange)
            {
                StartCoroutine(Attack());
            }
        }

    }

    IEnumerator Attack()
    {
        isAttacking = true;

        if (hitEffect != null)
        {
            Instantiate(hitEffect, hitStartPosition.position, hitStartPosition.rotation, hitStartPosition.transform);
        }

        // ���� ����� ��������� ������
        yield return new WaitForSeconds(attackDelay);

        isAttacking = false;
    }

}
