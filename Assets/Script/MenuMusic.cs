using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    private static GameObject _instance;
    [SerializeField] private AudioSource _audio;
    void Start()
    {
        _audio.volume = PlayerPrefs.GetFloat("MenuSound");
        DontDestroyOnLoad(gameObject);
        
        if(_instance == null)
            _instance= gameObject;
        else
            Destroy(gameObject); 
    }
    private void Update()
    {
        _audio.volume = PlayerPrefs.GetFloat("MenuSound");
    }
}
