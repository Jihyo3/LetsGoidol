using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip[] bgMusic;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
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
        PlayBackgroundMusic(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayBackgroundMusic(int index)
    {
        if (index >= 0 && index < bgMusic.Length)
        {
            audioSource.clip = bgMusic[index];
            audioSource.Play();
        }
    }
}
