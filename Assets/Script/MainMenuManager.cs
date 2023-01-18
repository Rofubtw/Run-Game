using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rauf;

public class MainMenuManager : MonoBehaviour
{
    MemoryManagement _memoryManagement = new MemoryManagement();
    [SerializeField] GameObject _exitPanel;
    [SerializeField] AudioSource _buttonAudio;
    void Start()
    {
        _memoryManagement.CheckandDescribe();
        _buttonAudio.volume = _memoryManagement.ReadFloatData("MenuFx");
    }
    public void LoadScene(int Index)
    {
        PlayBackAudio();
        SceneManager.LoadScene(Index);
    }
    public void Play() 
    {
        PlayBackAudio();
        SceneManager.LoadScene(_memoryManagement.ReadIntData("LastLevel"));
    }
    public void ExitButtonConclusion(string situation)
    {
        if (situation=="Yes")
            Application.Quit();
        else if(situation == "Exit")
            _exitPanel.SetActive(true);
        else
            _exitPanel.SetActive(false);
        PlayBackAudio();
    }
    public void PlayBackAudio()
    {
        _buttonAudio.Play();
    }
}
