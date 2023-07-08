using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destr : MonoBehaviour
{
    public float destr_time = 0.08f;
    void Start()
    {
        Invoke("BulletRip", destr_time);
    }

    void BulletRip()
    {
        Destroy(gameObject);
    }
}
