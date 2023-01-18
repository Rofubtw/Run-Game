using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Rauf;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Sprite _lockedButton;
    public int Level;
    MemoryManagement _memoryManagement = new MemoryManagement();
    [SerializeField] AudioSource _buttonAudio;
    void Start()
    {
        _buttonAudio.volume = _memoryManagement.ReadFloatData("MenuFx");

        int CurrentLevel = _memoryManagement.ReadIntData("LastLevel") - 4;
        int Index = 1;
        for (int i = 0; i < _buttons.Length; i++)
        {
            if (Index <= CurrentLevel)
            {
                _buttons[i].GetComponentInChildren<TMP_Text>().text = Index.ToString();
                int SceneIndex = Index + 4;
                _buttons[i].onClick.AddListener(delegate { SceneLoad(SceneIndex); });
            }
            else
            {
                _buttons[i].GetComponent<Image>().sprite = _lockedButton;
                _buttons[i].enabled= false;               
            }
            Index++;
        }
    }
    public void SceneLoad(int Index)
    {
        PlayBackAudio();
        Debug.Log(Index);
        SceneManager.LoadScene(Index);
    }
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
