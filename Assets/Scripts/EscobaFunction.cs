
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscobaFunction : MonoBehaviour
{
    [SerializeField] public int danio;
    [SerializeField] private float tiempoActual;
    [SerializeField] private float tiempoDeVida;

    
    private GameObject puerta;
    private GameObject player;

    public int tareaHecha = 1;

    private controles updateDirt;

    // Start is called before the first frame update
    void Start()
    {
        updateDirt = GameObject.FindGameObjectWithTag("Jugador").GetComponent<controles>();
        puerta = GameObject.FindGameObjectWithTag("Puerta");
        player = GameObject.FindGameObjectWithTag("Jugador");
    }

    // Update is called once per frame
    void Update()
    {
        tiempoActual += Time.deltaTime;

        if(tiempoActual > tiempoDeVida)
        {
            Destroy(gameObject);
            player.GetComponent<controles>().checkEscoba(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mugre"))
        {
            collision.GetComponent<vidaMugre>().tomarDanio(danio);
            updateDirt.updateDirt(collision.gameObject);
        }

    }
}
