using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tienda : MonoBehaviour
{ 
    //silbato|Red Scream
    public GameObject silAct;
    public GameObject silInact;
    

    //poción|Solving Potion
    public GameObject potAct;
    public GameObject potInact; 
    

    public TextMeshProUGUI actualMon;
    public GameObject price;
    public TextMeshProUGUI priceText;
    public GameObject textPan;
    public TextMeshProUGUI descText; 


    // Start is called before the first frame update
    void Start()
    {
        checker();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "store") 
        {
            actualMon.text = economyManager.playerMoney.ToString();
        }
    }

    public void OnHighlightSil()
    {
        textPan.SetActive(true);
        price.SetActive(true);
        priceText.text = "50";
        descText.text = "The Red Scream: Use this and all the dogs will be gone by the time they hear it. Be aware! The sound destroys the device (And sometimes the user)";
    }

    public void OffHighlightSil()
    {
        textPan.SetActive(false);
        price.SetActive(false);
        priceText.text = string.Empty;
        descText.text = string.Empty;
    }

    public void OnHighlightPot()
    {
        textPan.SetActive(true);
        price.SetActive(true);
        priceText.text = "100";
        descText.text = "The Solving Potion: I'm not sure what this does, but it must have something to do with fixing something... At least I think so.";
    }

    public void OffHighlightPot()
    {
        textPan.SetActive(false);
        price.SetActive(false);
        priceText.text = string.Empty;
        descText.text = string.Empty;
    }

    public void silBuyed()
    {
        if (itemManager.Instance.sBuy == false && economyManager.playerMoney >= 50)
        {
            itemManager.Instance.sBuy = true;
            economyManager.playerMoney-=50;
            silAct.gameObject.SetActive(false);
            silInact.gameObject.SetActive(true);
            textPan.SetActive(false);
            price.SetActive(false);
            priceText.text = string.Empty;
            descText.text = string.Empty;
        }
    }

    public void potBuyed()
    {
        if (itemManager.Instance.pBuy == false && economyManager.playerMoney >= 100)
        {
            itemManager.Instance.pBuy = true;
            economyManager.playerMoney -= 100;
            potAct.gameObject.SetActive(false);
            potInact.gameObject.SetActive(true);
            textPan.SetActive(false);
            price.SetActive(false);
            priceText.text = string.Empty;
            descText.text = string.Empty;
        }
    }

    public void checker()
    {
        if (itemManager.Instance.sBuy == false)
        {
            silAct.SetActive(true);
            silInact.SetActive(false);
        }
        if (itemManager.Instance.pBuy == false)
        {
            potAct.SetActive(true);
            potInact.SetActive(false);
        }
        if (itemManager.Instance.sBuy == true)
        {
            silInact.SetActive(true);
            silAct.SetActive(false);
        }
        if (itemManager.Instance.pBuy == true)
        {
            potInact.SetActive(true);
            potAct.SetActive(false);
        }

    }

}
