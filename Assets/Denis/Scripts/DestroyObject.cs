using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float destroyTime;

    void Start()
    {
        Invoke("Destroy_", destroyTime);
    }

    public void Destroy_()
    {
        Destroy(gameObject);
    }
}
