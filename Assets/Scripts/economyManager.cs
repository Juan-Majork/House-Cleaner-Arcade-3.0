using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class economyManager : MonoBehaviour
{
    public static economyManager Instance;
    public static int playerMoney = 0;
    public static int LevelMoney = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void calculoDinero()
    {
        if (perfectManager.perfect >= 25)
        {
            LevelMoney = 20;
        }

        if(perfectManager.perfect >= 50)
        {
            LevelMoney = 50;
        }
        
        if (perfectManager.perfect >= 100) //Si hace el perfect
        {
            LevelMoney = 80; //Se le da esta plata
        }
        
        perfectManager.perfectCounter += perfectManager.perfect; //Suma en un acumulador la score total de perfect.
    }
    public void getMoney()
    {
        playerMoney += LevelMoney;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
