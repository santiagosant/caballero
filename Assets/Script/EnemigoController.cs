using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{

    Rigidbody2D rb2d;
    float limiteCaminataIzq;
    float limiteCaminataDer;
    public float velocidad;
    float direccion = 1f;
    public enum tipoComportamientoEnemigo { pasivo, persecucion, ataque };
    public tipoComportamientoEnemigo comportamiento = tipoComportamientoEnemigo.pasivo;

    public float entradaZonaPersecucion = 60f;
    public float salidaZonaPersecucion = 600f;
    public float distanciaAtaque = 5f;

    public float distanciaConPlayer;
    public Transform player;
    public int vida;
    bool sangrar;

    SpriteRenderer sprite;
    public ParticleSystem particulasDeDaño;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        limiteCaminataIzq = transform.position.x - GetComponent<CircleCollider2D>().radius;
        limiteCaminataDer = transform.position.x + GetComponent<CircleCollider2D>().radius;
        Destroy(GetComponent<CircleCollider2D>());
        transform.GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        particulasDeDaño = GetComponent<ParticleSystem>();
        //porque hice el sprite mirando a la izquierda
        sprite.flipX = true;
        vida = 3;
    }

    // Update is called once per frame
    void Update()
    {
       
        //distanciaConPlayer = Mathf.Abs(player.position.x - transform.position.x);




        /*   switch (comportamiento)
           {
               case tipoComportamientoEnemigo.pasivo:
                   //Deplazarce caminando
                   rb2d.velocity = new Vector2(velocidad * direccion, rb2d.velocity.y);
                   //Gira el sprite para c
                   if (transform.position.x < limiteCaminataIzq)
                   {
                       sprite.flipX = true;
                       direccion = 1;
                   }
                   if (transform.position.x > limiteCaminataDer)
                   {
                       sprite.flipX = false;
                       direccion = -1;
                   }
                   anim.speed = 1f; 
                   //Empieza a perseguir
                   if (distanciaConPlayer > entradaZonaPersecucion) comportamiento = tipoComportamientoEnemigo.persecucion;
                   break;

               case tipoComportamientoEnemigo.persecucion:
                   //Deplazarce caminando
                   rb2d.velocity = new Vector2(velocidad * 1.1f , rb2d.velocity.y);
                   //Gira el sprite para c
                   if (player.position.x > transform.position.x)
                   {
                       sprite.flipX = true;
                       direccion = 1;
                   }
                   if (player.position.x < transform.position.x)
                   {
                       sprite.flipX = false;
                       direccion = -1;
                   }
                   //Velocidad de animacion
                   anim.speed = 1.1f;
                   //volver a pasivo NO VUELVE A PASIVO (tampoco es que altere al gameplay planeado que no lo haga)
                   if (distanciaConPlayer > salidaZonaPersecucion) comportamiento = tipoComportamientoEnemigo.pasivo;
                   break;

               case tipoComportamientoEnemigo.ataque:

                   break;
           }
           */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        vida -= 1;
        if (vida == 0)
        {
            gameObject.SetActive(false);
        }
    }



}
