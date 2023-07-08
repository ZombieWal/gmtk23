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

    public Transform hitStartPosition; // точка начала удара

    private Rigidbody2D rb; // компонент Rigidbody2D
    public Vector3 lookDirection; // направление взгляда персонажа
    private Vector2 input; // ввод от клавиатуры или контроллера

    private float deshTimeCD; // таймер на кулдаун дэша
    private bool inDesh = false; // проверка на нахождение в дэше

    public bool start_ = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // получаем компонент Rigidbody2D
    }

    void Update()
    {
        // получаем позицию курсора мышки в мировых координатах
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // поворачиваем удар в направлении курсора мышки
        lookDirection = mousePosition - transform.position;

        // получаем ввод от клавиатуры или контроллера
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (start_)
        {
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

            if (Input.GetMouseButtonDown(0))
            {
                GetComponentInChildren<MeleeAttack>().OnAttack();
            }
        }
    }

    void FixedUpdate()
    {
        // поворачиваем удар в направлении курсора мышки
        hitStartPosition.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);

        if (start_)
        {
            // движение игрока
            if (!inDesh)
            {
                if (false)//Vector3.Dot(lookDirection, input.normalized) > 0.9f) // старые штуки
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