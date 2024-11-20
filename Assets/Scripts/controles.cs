using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controles : MonoBehaviour
{
    [SerializeField] public Transform spawnUp;
    [SerializeField] public Transform spawnDown;
    [SerializeField] public Transform spawnLeft;
    [SerializeField] public Transform spawnRight;
    [SerializeField] public GameObject escoba;
    [SerializeField] public bool escAct = false;
    [SerializeField] private bool check = false;
    [SerializeField] public Vector2 velocidad;

    private AudioSource audioSource;

    private Rigidbody2D rb;

    [SerializeField] private List<GameObject> cantidad = new List<GameObject>();
    private float cantidadInicial;
    [SerializeField] private TextMeshProUGUI cantidadTexto;
    private float percent;
    private ExitLevel doorCheck;
    [SerializeField] private int perfection;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        velocidad.x = 10;
        velocidad.y = 10;

        cantidadInicial = cantidad.Count; //Keeps the first number of the amount of Dirt in the level.
        updateDirt(null); //Starts the DirtPercent without removing anything.
        doorCheck = GameObject.FindGameObjectWithTag("Puerta").GetComponent<ExitLevel>();

    }

    // Update is called once per frame
    void Update()
    {
        animations(); //Movement animations.

        movement(); //Movement of the playe, through Addforce(Impulse).

        broom(); //Instantiates the broom in the direction the player is moving (Speed preference).

    }

    private void animations() 
    {
        if (rb.velocity.y > 0)
            animator.SetBool("IsUp",true);
        else
            animator.SetBool("IsUp", false);

        if (rb.velocity.y < 0)
            animator.SetBool("IsDown", true);
        else
            animator.SetBool("IsDown", false);

        if (rb.velocity.x > 0)
            animator.SetBool("IsRight", true);
        else
            animator.SetBool("IsRight", false);

        if (rb.velocity.x < 0)
            animator.SetBool("IsLeft", true);
        else
            animator.SetBool("IsLeft", false);
    }

    private void movement()
    {
        if (Input.GetKeyDown("w"))
        {
            rb.AddForce(Vector3.up * velocidad.y, ForceMode2D.Impulse);
            audioSource.Play();
        }

        if (Input.GetKeyDown("s"))
        {
            rb.AddForce(Vector3.down * velocidad.y, ForceMode2D.Impulse);
            audioSource.Play();
        }

        if (Input.GetKeyDown("d"))
        {
            rb.AddForce(Vector3.right * velocidad.x, ForceMode2D.Impulse);
            audioSource.Play();
        }

        if (Input.GetKeyDown("a"))
        {
            rb.AddForce(Vector3.left * velocidad.x, ForceMode2D.Impulse);
            audioSource.Play();
        }

        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            audioSource.Stop();
        }

    }

    private void broom() //if "p" is pressed, some axe of the velocity is different from 0 and the broom isn't active, the Broom instantiates
    {
        

        if (Input.GetKeyDown("p") && rb.velocity.y > 0 && escAct == false)
        {
            Instantiate(escoba, spawnUp);
            escAct = true;
            checkEscoba(check);
        }
        if (Input.GetKeyDown("p") && rb.velocity.y < 0 && escAct == false)
        {
            Instantiate(escoba, spawnDown);
            escAct = true;
            checkEscoba(check);
        }
        if (Input.GetKeyDown("p") && rb.velocity.x > 0 && escAct == false)
        {
            Instantiate(escoba, spawnRight);
            escAct = true;
            checkEscoba(check);
        }
        if (Input.GetKeyDown("p") && rb.velocity.x < 0 && escAct == false)
        {
            Instantiate(escoba, spawnLeft);
            escAct = true;
            checkEscoba(check);
        }

    }

    public void updateDirt(GameObject deleted) //When the dirt is cleaned, it removes them from the list of dirt to clean. When theres no more dirt, text is "0%".
    {
        cantidad.Remove(deleted);

        if (cantidad.Count == 0)
        {
            cantidadTexto.text = "Dirt: 0%";
            doorCheck.openDoor(true); //Sends a true bool, so the door opens.

            perfectManager.perfect += perfection;
        }

        percent = cantidad.Count/cantidadInicial*100;

        cantidadTexto.text = "Dirt: " + percent.ToString("F2") + "%";
    }


    public void checkEscoba(bool check) //Checks if the broom was activated and deactivates it.
    {
        if (check == true)
        {
            escAct = false;
            check = false;
        }
    }
}
