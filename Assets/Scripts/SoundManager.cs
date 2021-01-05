using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip shootSound, boom1Sound, boom2Sound;
    private static AudioSource audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        shootSound = Resources.Load<AudioClip>("shoot");
        boom1Sound = Resources.Load<AudioClip>("boom1");
        boom2Sound = Resources.Load<AudioClip>("boom2");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string sound)
    {
        switch (sound)
        {
            case "shoot":
                audioSource.PlayOneShot(shootSound);
                break;
            case "boom1":
                audioSource.PlayOneShot(boom1Sound);
                break;
            case "boom2":
                audioSource.PlayOneShot(boom2Sound);
                break;
        }
    }
}
