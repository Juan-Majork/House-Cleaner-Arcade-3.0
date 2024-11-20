using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class activePanelTutorial : MonoBehaviour
{
    [SerializeField] public GameObject panel;
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "nivel2")
        {
            Time.timeScale = 0.0f;
            panel.SetActive(true);
        }
        if (SceneManager.GetActiveScene().name == "nivel4")
        {
            Time.timeScale = 0.0f;
            panel.SetActive(true);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
