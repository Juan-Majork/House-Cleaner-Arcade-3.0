using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class winScreen : MonoBehaviour
{

    private Animator animator;

    [SerializeField] private GameObject numberPrefab;
    [SerializeField] private TextMeshProUGUI numberText;

    [SerializeField] private GameObject star1;
    [SerializeField] private GameObject star2;
    [SerializeField] private GameObject star3;

    [SerializeField] private GameObject starCount;
    [SerializeField] private TextMeshProUGUI starText;
    [SerializeField] private GameObject perfectCount;
    [SerializeField] private TextMeshProUGUI perfectText;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if(SceneManager.GetActiveScene().name == "win5")
        { 
            animator.SetBool("finale", true);
            starText = starCount.GetComponent<TextMeshProUGUI>();
            starText.text = perfectManager.starCounter.ToString() + " X ";
            perfectText = perfectCount.GetComponent<TextMeshProUGUI>();
            perfectText.text = "Final Score: " + perfectManager.perfectCounter.ToString();
        }
        else
        {
            animator.SetBool("winAnimDefFinale", true);
            numberText = numberPrefab.GetComponent<TextMeshProUGUI>();
            numberText.text = economyManager.LevelMoney.ToString();

            if (perfectManager.perfect >= 25)
            {
                star1.SetActive(true);
            }

            if (perfectManager.perfect >= 50)
            {
                star1.SetActive(true);
                star2.SetActive(true);
            }
            
            if (perfectManager.perfect >= 100)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
            }
        }
        
    }



}
