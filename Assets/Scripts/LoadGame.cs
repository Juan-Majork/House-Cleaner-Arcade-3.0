using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{

    private void Start()
    {
    }

    public void CargarJuego()
    {
        soundPlayer.Instance.playButtonSound();
        SceneManager.LoadScene("nivel1");
    }
    public void volverMenu()
    {
        soundPlayer.Instance.playButtonSound();
        SceneManager.LoadScene("Menu");
        perfectManager.perfect = 0;
        economyManager.LevelMoney = 0;
        economyManager.playerMoney = 0;
        itemManager.visits = 0;
        itemManager.Instance.sBuy = false;
        itemManager.Instance.pBuy = false;
        perfectManager.starCounter = 0;
        perfectManager.perfectCounter = 0;

    }
    public void salir()
    {
        Application.Quit();
    }

    public void CargarNivel()
    {
        soundPlayer.Instance.playButtonSound();

        if (SceneManager.GetActiveScene().name == "win")
        {
            SceneManager.LoadScene("nivel2");

            perfectManager.perfect = 0;
            economyManager.LevelMoney = 0;
        }
        if (SceneManager.GetActiveScene().name == "win2")
        {
            musicPlayer.instance.putStore();
            SceneManager.LoadScene("store");

            itemManager.visits++;
            perfectManager.perfect = 0;
            economyManager.LevelMoney = 0;

        }
        if (SceneManager.GetActiveScene().name == "store" && itemManager.visits == 1)
        {
            musicPlayer.instance.putMusic();
            SceneManager.LoadScene("nivel3");

            perfectManager.perfect = 0;
            economyManager.LevelMoney = 0;

        }
        if (SceneManager.GetActiveScene().name == "win3")
        {
            musicPlayer.instance.putStore();
            SceneManager.LoadScene("store");

            itemManager.visits++;
            perfectManager.perfect = 0;
            economyManager.LevelMoney = 0;

        }
        if (SceneManager.GetActiveScene().name == "store" && itemManager.visits == 2)
        {
            musicPlayer.instance.putMusic();
            SceneManager.LoadScene("nivel4");

            perfectManager.perfect = 0;
            economyManager.LevelMoney = 0;

        }
        if (SceneManager.GetActiveScene().name == "win4")
        {
            SceneManager.LoadScene("nivel5");

            perfectManager.perfect = 0;
            economyManager.LevelMoney = 0;
        }

    }
}
