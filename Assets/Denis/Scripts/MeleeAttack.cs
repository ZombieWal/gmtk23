using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public GameObject hitEffect; // эффект удара
    public Transform hitStartPosition; // точка начала удара
    public float hitImpulsePlayer = 10f; // сила прыжка игрока при ударе
    public float comboTime = 1f; // время до потери комбо атак

    private PlayerMovement playerMovement; // компонент playerMovement
    private Rigidbody2D rb; // компонент Rigidbody2D


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
        // создаем эффект удара
        if (hitEffect != null)
        {
            Instantiate(hitEffect, hitStartPosition.position, hitStartPosition.rotation, hitStartPosition.transform);
        }
        //rb.AddForce(playerMovement.lookDirection.normalized * hitImpulsePlayer, ForceMode2D.Impulse);  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    }
}