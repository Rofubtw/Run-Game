using Rauf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    [SerializeField] AudioSource _buttonAudio;
    MemoryManagement _memoryManagement = new MemoryManagement();
    public void GoBack()
    {
        _buttonAudio.volume = _memoryManagement.ReadFloatData("MenuFx");
        SceneManager.LoadScene(0);
        PlayBackAudio();
    }
    public void PlayBackAudio()
    {
        _buttonAudio.Play();
    }
}
