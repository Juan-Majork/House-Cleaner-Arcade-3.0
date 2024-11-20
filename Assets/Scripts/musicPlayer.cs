using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip storeMusic;
    private AudioSource audioSource;

    public static musicPlayer instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
        audioSource = GetComponent<AudioSource>();

        audioSource.loop = true;
        audioSource.clip = gameMusic;
        audioSource.Play();
    }

    public void putMusic()
    {
        audioSource.clip = gameMusic;
        audioSource.Play();
    }

    public void putStore()
    {
        audioSource.clip = storeMusic;
        audioSource.Play();
    }
}
