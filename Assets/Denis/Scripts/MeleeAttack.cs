using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public GameObject hitEffect; // ������ �����
    public Transform hitStartPosition; // ����� ������ �����
    public float hitImpulsePlayer = 10f; // ���� ������ ������ ��� �����
    public float comboTime = 1f; // ����� �� ������ ����� ����

    private PlayerMovement playerMovement; // ��������� playerMovement
    private Rigidbody2D rb; // ��������� Rigidbody2D


    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
    }

    public void OnAttack()
    {
        // ������� ������ �����
        if (hitEffect != null)
        {
            Instantiate(hitEffect, hitStartPosition.position, hitStartPosition.rotation, hitStartPosition.transform);
        }
        //rb.AddForce(playerMovement.lookDirection.normalized * hitImpulsePlayer, ForceMode2D.Impulse);  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    }
}