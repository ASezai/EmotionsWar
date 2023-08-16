using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerForPC : MonoBehaviour
{
    private Rigidbody2D rb;

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
    [SerializeField]
    private Canvas joystickUI;

    private float nextFireTime;

    public Camera Cam;

    Vector2 movement;
    Vector2 mousePos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joystickUI.gameObject.SetActive(false);
        GameManager.ActiveController = 1;
        Debug.Log(GameManager.ActiveController);
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = Cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + FireRate;
        }
    }
    private void FixedUpdate()
    {
        //Karakter hareketi
        rb.MovePosition(rb.position + movement * MovementSpeed * Time.deltaTime);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -30f, 30f),
            Mathf.Clamp(transform.position.y, -30f, 30f),
            transform.position.z
        );
        //Mouse yönüne göre ateþ yönü hareketi
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    private void Fire()
    {
        GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, gameObject.transform.rotation);
        Bullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * ProjectileSpeed;
    }
}
