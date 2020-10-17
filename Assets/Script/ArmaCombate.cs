using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaCombate : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
