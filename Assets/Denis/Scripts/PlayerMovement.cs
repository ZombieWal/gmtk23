using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // �������� ������������
    public float acceleration = 10f; // ���������
    public float deceleration = 5f; // ����������
    public float maxSpeed = 10f; // ������������ ��������
    public float turnSpeed = 3f; // �������� ��������

    public float DeshImpulse; // ��������� ����
    public float timeInDesh; // ����� � ��������� ����
    public float deshCD; // ����� �������� ����

    public Transform hitStartPosition; // ����� ������ �����

    private Rigidbody2D rb; // ��������� Rigidbody2D
    public Vector3 lookDirection; // ����������� ������� ���������
    private Vector2 input; // ���� �� ���������� ��� �����������

    private float deshTimeCD; // ������ �� ������� ����
    private bool inDesh = false; // �������� �� ���������� � ����

    public bool start_ = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // �������� ��������� Rigidbody2D
    }

    void Update()
    {
        // �������� ������� ������� ����� � ������� �����������
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // ������������ ���� � ����������� ������� �����
        lookDirection = mousePosition - transform.position;

        // �������� ���� �� ���������� ��� �����������
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (start_)
        {
            // ������� ����
            if (deshTimeCD <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    deshTimeCD = deshCD;
                    rb.AddForce(input.normalized * DeshImpulse, ForceMode2D.Impulse);
                    inDesh = true;
                    Invoke("StopDesh", timeInDesh);
                }
            }
            else
            {
                deshTimeCD -= Time.deltaTime;
            }

            if (Input.GetMouseButtonDown(0))
            {
                GetComponentInChildren<MeleeAttack>().OnAttack();
            }
        }
    }

    void FixedUpdate()
    {
        // ������������ ���� � ����������� ������� �����
        hitStartPosition.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);

        if (start_)
        {
            // �������� ������
            if (!inDesh)
            {
                if (false)//Vector3.Dot(lookDirection, input.normalized) > 0.9f) // ������ �����
                {
                    rb.AddForce(input.normalized * acceleration, ForceMode2D.Force);

                    if (rb.velocity.magnitude > maxSpeed)
                    {
                        rb.velocity = rb.velocity.normalized * maxSpeed;
                    }
                }
                else
                {
                    rb.velocity = Vector2.Lerp(rb.velocity, input.normalized * speed, deceleration * Time.fixedDeltaTime);
                }
            }
        
            // ��������� ������������ � ��������� �� ���� "Walls"
            int layerMask = 1 << LayerMask.NameToLayer("Walls");
            if (Physics2D.Raycast(transform.position, input, 0.5f, layerMask))
            {
                // ���� ����������� �� ������, �� ���������
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void StopDesh()
    {
        inDesh = false;
    }
}