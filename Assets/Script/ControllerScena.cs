using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScena : MonoBehaviour
{
    public void CambiarEscena(string nombre)
    {
        print("Cambiar escena a " + nombre);
        SceneManager.LoadScene(nombre);
    }

    public void ProximoNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        print("saliendo");
        Application.Quit();
    }
}
