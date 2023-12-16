using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D player;
    private Animator anim;
    private Transform respawnPoint;//donde aparecer� el personaje si muere y le quedan vidas

    private TextMeshProUGUI vidasText;

    public static int vidas;

    private void Start()
    {
        player=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        respawnPoint = GameObject.FindWithTag("Respawn").transform;

        if (PlayerPrefs.HasKey("Vidas"))
        {
            leerVidas();
        }
        else {
            vidas = 3;        
        }

        vidasText = GameObject.Find("Vida_text").GetComponent<TextMeshProUGUI>();
        vidasText.text = "Vidas: " + vidas;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trampa") || collision.gameObject.CompareTag("Vacio"))
        {
            Die();
        }
    }


    private void leerVidas() 
    {
        vidas = PlayerPrefs.GetInt("Vidas");
    }
    private void guardarVidas()
    {
        PlayerPrefs.SetInt("Vidas", vidas);
    }


    private void Die()
    {
        player.bodyType = RigidbodyType2D.Static;//convierte a estatico para que no se pueda mover mientras est� muriendo
        vidas--;
        guardarVidas();
        leerVidas();
        vidasText.text = "Vidas: " + vidas;
        anim.SetTrigger("Muerte");
    }

    private void RestartLever() {//A este metodo se le llama desde la animaci�n de muerte
        if (vidas < 1)//Si tiene 0 vidas se recarga la escena. ESTO HABR� QUE CAMBIARLO A VENTANA DE GAME OVER Y PEDIR DATOS
        {
            vidas = 3;
            guardarVidas();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            player.bodyType = RigidbodyType2D.Dynamic;//al morir lo ponemos estatico, por lo que aqu� debemos volver a ponerlo dinamico
            player.transform.position = respawnPoint.position;
            anim.SetTrigger("Respawn");
        }
        
    }
}
