using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusSliced : MonoBehaviour
{
    public float startForce = 10f;
    public float rotationSpeed = 10f;

    private Rigidbody2D rb;
    private float randomRotation;

    // Start is called before the first frame update
    void Start()
    {
        // ���������� ��������� ������
        Vector3 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        // ����������� ������, ����� ��� ����� ���� 1
        randomDirection.Normalize();

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(randomDirection * startForce, ForceMode2D.Impulse);

        // ���������� ��������� ����� ��� ����������� ����������� ��������
        randomRotation = Random.Range(-1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        // ������� ������ � �������������� AddTorque
        rb.AddTorque(randomRotation * rotationSpeed);
    }
}
