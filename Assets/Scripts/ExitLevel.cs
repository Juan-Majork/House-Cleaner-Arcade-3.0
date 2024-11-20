using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    private AudioSource audioSource;
    private bool hecho = false;
    Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (hecho)
        {
            animator.SetBool("opening", true);
            animator.SetBool("open", true);
        }

        if (Input.GetKeyDown("u"))
        {
            hecho = true;
        }
    }
    public void openDoor(bool act)
    {
        hecho = act;
        audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador") && hecho == true)
        {
            CargarNivel();
        }
    }

    public void CargarNivel()
    {
        if (SceneManager.GetActiveScene().name == "nivel1")
        {
            SceneManager.LoadScene("Win");
            economyManager.Instance.calculoDinero();
            economyManager.Instance.getMoney();
            perfectManager.Instance.countStars();
            
        }

        if (SceneManager.GetActiveScene().name == "nivel2")
        {
            SceneManager.LoadScene("win2");
            economyManager.Instance.calculoDinero();
            economyManager.Instance.getMoney();
            perfectManager.Instance.countStars();
        }

        if (SceneManager.GetActiveScene().name == "nivel3")
        {
            SceneManager.LoadScene("win3");
            economyManager.Instance.calculoDinero();
            economyManager.Instance.getMoney();
            perfectManager.Instance.countStars();
        }

        if (SceneManager.GetActiveScene().name == "nivel4")
        {
            SceneManager.LoadScene("win4");
            economyManager.Instance.calculoDinero();
            economyManager.Instance.getMoney();
            perfectManager.Instance.countStars();
        }

        if (SceneManager.GetActiveScene().name == "nivel5")
        {
            SceneManager.LoadScene("win5");
            economyManager.Instance.calculoDinero();
            economyManager.Instance.getMoney();
            perfectManager.Instance.countStars();
        }

    }
}
