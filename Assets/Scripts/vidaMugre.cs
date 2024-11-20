using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class vidaMugre : MonoBehaviour
{
    private int vida = 1;
    
    public void tomarDanio(int danio)
    {
        vida -= danio;
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
