using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//PARA QUE EL PERSONAJE SE MUEVA CON LA PLATAFORMA
public class StickyPlatform : MonoBehaviour
{
    //Si el jugador entra en contacto con la plataforma, se pone como "hijo" de ella y entonces hace lo mismo que la plataforma
   //utilizamos el ontrigger del segundo boxcollider(que es un poco más pequeño) para que no arrastre
   //al jugador con solo rozar la plataforma

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Jugador")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Jugador")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
