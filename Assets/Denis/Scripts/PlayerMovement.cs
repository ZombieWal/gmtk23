using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // скорость передвижения
    public float acceleration = 10f; // ускорение
    public float deceleration = 5f; // замедление
    public float maxSpeed = 10f; // максимальная скорость
    public float turnSpeed = 3f; // скорость поворота

    public float DeshImpulse; // дальность дэша
    public float timeInDesh; // время в состоянии дэша
    public float deshCD; // время кулдауна дэша

    private Rigidbody2D rb; // компонент Rigidbody2D
    public Vector3 lookDirection; // направление взгляда персонажа
    private Vector2 input; // ввод от клавиатуры или контроллера

    private float deshTimeCD; // таймер на кулдаун дэша
    private bool inDesh = false; // проверка на нахождение в дэше

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // получаем компонент Rigidbody2D
    }

    void Update()
    {
        // получаем позицию курсора мышки в мировых координатах
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // поворачиваем персонажа в направлении курсора мышки
        lookDirection = Vector3.Slerp(lookDirection, mousePosition - transform.position, Time.deltaTime * turnSpeed);

        // получаем ввод от клавиатуры или контроллера
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // кулдаун дэша
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
    }

    void FixedUpdate()
    {
        // движение игрока
        if (!inDesh)
        {
            if (false)//Vector3.Dot(lookDirection, input.normalized) > 0.9f)
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

        // проверяем столкновение с объектами на слое "Walls"
        int layerMask = 1 << LayerMask.NameToLayer("Walls");
        if (Physics2D.Raycast(transform.position, input, 0.5f, layerMask))
        {
            // если столкнулись со стеной, не двигаемся
            rb.velocity = Vector2.zero;
        }
    }

    void StopDesh()
    {
        inDesh = false;
    }
}