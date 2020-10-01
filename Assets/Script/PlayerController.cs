using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb2d;
    public float fuerzaSalto;
    public bool enPiso;
    public Transform refPie;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Comprueba si esta en el piso para saltar
        enPiso = Physics2D.OverlapCircle(refPie.position,1f,1<<8);
        //Boolean para animator
        anim.SetBool("enPiso", enPiso);
        // Saltar
        if (Input.GetKeyDown(KeyCode.J) && enPiso)
        {
            rb2d.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
        }

        

    }
}
