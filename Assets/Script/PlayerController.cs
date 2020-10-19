using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb2d;
    public Transform refPie;
    public float fuerzaSalto;
    public float velX;
    public bool enPiso;
    SpriteRenderer sprite;
    bool ataque;
    BoxCollider2D ataqueCollider;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        ataqueCollider = GetComponentInChildren<BoxCollider2D>();
        ataqueCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Comprueba si esta en el piso para saltar
        enPiso = Physics2D.OverlapCircle(refPie.position,1f,1<<8);
        //Boolean para animator
        anim.SetBool("enPiso", enPiso);
        // Saltar
        if (Input.GetKeyDown(KeyCode.W) && enPiso)
        {
            //Si el KeyDownW es false siempre que se despegue del piso va a hacer al animacion de caida
            anim.SetBool("KeyDownW", true);
            rb2d.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
        }
        //Animacion de ataque
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("Ataque");
            ataqueCollider.enabled = true;
        }
        //Animacion de bloqueo
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("Bloquear");
        }

    }


    private void FixedUpdate()
    {
        //Si esta en el piso KeyDownW es False
        //si es falso piso  
        if (!enPiso)
        {
            anim.SetBool("KeyDownW", false);
        }

        //Para movimiento horizontal
        float movX;
        movX = Input.GetAxis("Horizontal");
        anim.SetFloat("AbsMovX",Mathf.Abs(movX));
        rb2d.velocity = new Vector2(velX * movX, rb2d.velocity.y);

        if (movX < 0) sprite.flipX = true;
        if (movX > 0) sprite.flipX = false;

    }
}
