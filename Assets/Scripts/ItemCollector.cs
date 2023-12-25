using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ItemCollector : MonoBehaviour
{
    private Rigidbody2D player;
    private Animator anim;
    public static int puntos;

    private TextMeshProUGUI puntosText;

    [SerializeField] private AudioSource collectionSoundEffect;
    [SerializeField] private AudioSource collectionKissEffect;

    private void Start()
    {

        /*if (PlayerPrefs.HasKey("Puntos"))
        {*/
            leerPuntos();
        /*}
        else
        {
            puntos = 0;
        }*/

        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        puntosText = GameObject.Find("Puntos_text").GetComponent<TextMeshProUGUI>();
        puntosText.text = "Puntos: " + puntos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melocoton"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            leerPuntos();
            puntos+=50;
            guardarPuntos();
            puntosText.text = "Puntos: " + puntos;
        }
        
        if (collision.gameObject.CompareTag("boy"))
        {
            Debug.Log("chico");
            collectionKissEffect.Play();
            Destroy(collision.gameObject, 1f);
            leerPuntos();
            puntos += 100;
            guardarPuntos();
            puntosText.text = "Puntos: " + puntos;
            player.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("KissCollect");
        }
    }

    private void EndKiss() {
        player.bodyType = RigidbodyType2D.Dynamic;
        anim.SetTrigger("EndKissCollect");
    }


    private void leerPuntos() {
        puntos = PlayerPrefs.GetInt("Puntos");
    }

    private void guardarPuntos() {
        PlayerPrefs.SetInt("Puntos", puntos);
    }

}
