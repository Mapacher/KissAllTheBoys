using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirGameOver : MonoBehaviour
{
    public void salir() {
        Application.Quit();
    }

    public void volverAJugar() {
        SceneManager.LoadScene(0);
    }
}
