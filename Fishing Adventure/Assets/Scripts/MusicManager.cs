using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    // Store game music
    public PlayerInventory inventory;
    [SerializeField] AudioSource music;
    public Slider musicSlider;
    public float musicSliderValue;

    // Store game sounds
    [SerializeField] Toggle sound;
    [SerializeField] AudioSource reelingSound;
    [SerializeField] AudioSource caughtFishSound;
    [SerializeField] AudioSource boatSound;
    [SerializeField] AudioSource CashRegisterSound;
    [SerializeField] AudioSource CastLineSound;
    public bool playSound;
    
    
    public AudioMixer Mixer;

    
    void Start()
    {
        music = GetComponent<AudioSource>(); 
       // reelingSound = GetComponent<AudioSource>();
        music.Play();

        musicSlider.value = inventory.musicVolume; // get slider volume level
        music.volume = musicSliderValue;

        if (inventory.gameSound == false) // if game previously had muted sound
        {
            sound.isOn = false; // mute sound
            MuteSound();
        }
    }

    void Update()
    {
        musicSliderValue = musicSlider.value;
        music.volume = musicSliderValue;

        inventory.musicVolume = music.volume; // store music volume level
    }

    public void MuteSound()
    {

        if (sound.isOn == false) // if sound box is not checked
        {
            Debug.Log("Sound is Off!!");
            reelingSound.volume = 0f;
            caughtFishSound.volume = 0f;
            boatSound.volume = 0f;
            CashRegisterSound.volume = 0f;
            CastLineSound.volume = 0f;

            inventory.gameSound = false; // store game sound as false
            sound.isOn = inventory.gameSound;
        }

        else // sound box is checked
        {
            reelingSound.volume = 0.25f;
            caughtFishSound.volume = 0.5f;
            boatSound.volume = 0.08f;
            CashRegisterSound.volume = 0.3f;
            CastLineSound.volume = 0.3f;
            inventory.gameSound = true; // store game sound as true

        }

    }


}

