using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPlayer : MonoBehaviour
{
    public float velocidad = 8f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private Vector2 movimiento;

    public void OnMove(InputValue value)
    {
        movimiento = value.Get<Vector2>();
    }

    void Update()
    {
        Vector3 direccion = new Vector3(
            movimiento.x,
            movimiento.y,
            0f
        );

        transform.Translate(
            direccion * velocidad * Time.deltaTime
        );
    }

    /*void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * velocidad * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
        }
    }*/

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ZoneDamage")
        {
            Debug.Log("Jugador Quemado.");
        }

        if (collision.gameObject.name == "FinishLine")
        {
            Debug.Log("Felicidades.");
        }

        if (collision.gameObject.name == "Boost")
        {
            rb.AddForce(
                Vector2.up * velocidad,
                ForceMode2D.Impulse
            );
        }
    }
}