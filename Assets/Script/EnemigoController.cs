using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{

    Rigidbody2D rb2d;
    public float limiteCaminataIzq;
    public float limiteCaminataDer;
    public float velocidad;
    public int direccion = 1;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        limiteCaminataIzq = transform.position.x - GetComponent<CircleCollider2D>().radius;
        limiteCaminataDer = transform.position.x + GetComponent<CircleCollider2D>().radius;
        Destroy(GetComponent<CircleCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(velocidad * direccion, rb2d.velocity.y);
        if (transform.position.x < limiteCaminataIzq)
        {
            direccion = 1;
        }
        if (transform.position.x > limiteCaminataDer)
        {
            direccion = -1;
        }
        transform.localScale = new Vector3(-0.2975816f * direccion, 0.2975816f, 1f);
    }
}
