using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ItemCollector : MonoBehaviour
{
    private int puntos = 0;

    private TextMeshProUGUI puntosText;

    private void Start()
    {
        puntosText = GameObject.Find("Puntos_text").GetComponent<TextMeshProUGUI>();
        puntosText.text = "Puntos: "+puntos; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melocoton"))
        { 
            Destroy(collision.gameObject);
            puntos+=50;
            puntosText.text = "Puntos: " + puntos;
 
        }
    }
}
