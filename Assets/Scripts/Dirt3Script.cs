using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt3Script : MonoBehaviour
{
    [SerializeField] private float Health;

    [SerializeField] private float DamagePerSecond;
    [SerializeField] private float SizeReductionPerSecond;

    private bool isInWater = false;

    [SerializeField] private float damageTimer;
    [SerializeField] private float damageInterval;

    [SerializeField] private int givePerfection;

    public GameObject crater;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInWater && Health > 0)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {

                Health -= DamagePerSecond;
                damageTimer = 0f;


                Vector3 newScale = transform.localScale - new Vector3(SizeReductionPerSecond, SizeReductionPerSecond, 0);

                if (newScale.x > 0 && newScale.y > 0)
                {
                    transform.localScale = newScale;
                }

                if (Health <= 0)
                {
                    perfectManager.perfect += givePerfection;
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("water3"))
        {
            isInWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("water3"))
        {
            isInWater = false;
            damageTimer = 0f;

        }
    }
}
