using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    [SerializeField]private AudioSource finishSound;
    private Rigidbody2D player;
    private Animator anim;

    private void Start()
    {
        finishSound= GetComponent<AudioSource>();
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "meta") {
            finishSound.Play();
            //Invoke("completeLever", 2f);
            player.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("Kiss");
        }
    }

    private void completeLevel() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
