using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlay : MonoBehaviour
{
    private AudioSource sound;
    [SerializeField] public AudioClip buttonSound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    public void ClickAudioOn()
    {
        sound.PlayOneShot(buttonSound);
    }
}
