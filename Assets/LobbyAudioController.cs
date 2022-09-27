using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LobbyAudioController : MonoBehaviour
{
    AudioSource lobbyAudio;
    public GameObject volumeSlider;

 
    void Start()
    {
        lobbyAudio = gameObject.GetComponent<AudioSource>();
        lobbyAudio.volume = PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame
    void Update()
    {
        if (volumeSlider != null)
        {
            lobbyAudio.volume = volumeSlider.GetComponent<Slider>().value;
            PlayerPrefs.SetFloat("volume", lobbyAudio.volume);
        }
    
    }

}
