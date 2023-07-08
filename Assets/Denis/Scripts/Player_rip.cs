using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_rip : MonoBehaviour
{
    public bool rip = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<EnemyMove>())
        {
            if (rip == false)
            {
                Debug.Log("PlayerRIP");
                rip = true;
            }
        }
    }
}
