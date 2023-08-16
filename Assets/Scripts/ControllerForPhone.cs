using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerForPhone : MonoBehaviour
{
    private Rigidbody2D rb;

    public FixedJoystick MoveJoystick;
    public FixedJoystick WeaponJoystick;

    [Range(0.2f, 0.5f)]
    public static float FireRate = 0.5f;
    [Range(30f, 81f)]
    public static float ProjectileSpeed = 30f;
    [Range(8f, 20f)]
    public static float MovementSpeed = 8f;

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform firePoint;

    private float nextFireTime;

    Vector2 Move;
    Vector2 Weapon;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameManager.ActiveController = 0;
        Debug.Log(GameManager.ActiveController);
    }

    void Update()
    {
        Move.x = MoveJoystick.Horizontal;
        Move.y = MoveJoystick.Vertical;
        Weapon.x = WeaponJoystick.Horizontal;
        Weapon.y = WeaponJoystick.Vertical;

        Vector3 direction = new Vector3(Weapon.x, 0f, Weapon.y).normalized;

        if (direction.magnitude < 0.1f)
        {
            direction = Vector3.zero;
        }

        float hAxis = Weapon.x;
        float vAxis = Weapon.y;
        float zAxis = (Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg) + -90f;
        transform.eulerAngles = new Vector3(0f, 0f, -zAxis);

        if (Time.time >= nextFireTime && direction != Vector3.zero)
        {
            Fire();
            nextFireTime = Time.time + FireRate;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Move * MovementSpeed * Time.deltaTime);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -30f, 30f),
            Mathf.Clamp(transform.position.y, -30f, 30f),
            transform.position.z
        );
    }

    private void Fire()
    {
        GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, gameObject.transform.rotation);
        Bullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * ProjectileSpeed;
    }
}
