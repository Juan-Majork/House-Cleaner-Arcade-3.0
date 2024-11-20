using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class perfectManager : MonoBehaviour
{
    public static perfectManager Instance;
    public static int perfect = 0;
    public static int perfectCounter = 0;
    public static int starCounter = 0;

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

    public void countStars()
    {
        if(perfect >= 25)
        {
            starCounter++;
        }
        if(perfect >= 50)
        {
            starCounter++;
        }
        if(perfect >= 100)
        {
            starCounter++;
        }
    }

}
