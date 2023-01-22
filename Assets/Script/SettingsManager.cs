using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Rauf;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] AudioSource _buttonAudio;
    [SerializeField] Slider _menuSoundSlider;
    [SerializeField] Slider _menuFxSlider;
    [SerializeField] Slider _gameSoundSlider;
    [SerializeField] Slider _gameFxSlider;

    MemoryManagement _memoryManagement = new MemoryManagement();
    private void Start()
    {
        _buttonAudio.volume = _memoryManagement.ReadFloatData("MenuFx");

        _menuSoundSlider.value = _memoryManagement.ReadFloatData("MenuSound");
        _menuFxSlider.value = _memoryManagement.ReadFloatData("MenuFx");
        _gameSoundSlider.value = _memoryManagement.ReadFloatData("GameSound");
        _gameFxSlider.value = _memoryManagement.ReadFloatData("GameFx");
    }
    public void ChangeSound(string WhichSound) => _memoryManagement.SaveFloatData(WhichSound, _menuSoundSlider.value);
    public void GoBack()
    {
        PlayBackAudio();
        SceneManager.LoadScene(0);
    }
    public void PlayBackAudio()
    {
        _buttonAudio.Play();
    }
}
