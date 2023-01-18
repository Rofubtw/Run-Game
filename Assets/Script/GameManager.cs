using System.Collections.Generic;
using UnityEngine;
using Rauf;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int MomentaryCharacterNumber = 1;

    [Header("-----OBJECT POOLS")]
    public List<GameObject> Characters;
    public List<GameObject> ConsistEffects;
    public List<GameObject> ExtinctionEffects;
    public List<GameObject> Stains;
    
    [Header("-----GENERAL DATAS")]
    [SerializeField] AudioSource[] Sounds;
    [SerializeField] GameObject[] _operationPanels;
    [SerializeField] Slider[] _settingsSliders;
    private Scene _scene;

    [Header("-----LEVEL DATAS")]
    public List<GameObject> Enemys;
    public int MomentaryEnemyNumber;
    public PlayerController Player;
    public bool isgameover;

    MathematicalOperations _mathematicalOperations = new MathematicalOperations();
    MemoryManagement _memoryManagement = new MemoryManagement();
    
    private void Awake()
    {
        Sounds[0].volume = _memoryManagement.ReadFloatData("GameSound");
        _settingsSliders[0].value = _memoryManagement.ReadFloatData("GameSound");
        _settingsSliders[1].value = _memoryManagement.ReadFloatData("GameFx");
        Sounds[1].volume = _memoryManagement.ReadFloatData("MenuFx");
        Destroy(GameObject.FindWithTag("MenuAudio"));
        MomentaryCharacterNumber = 1;
    }
    void Start()
    {
        _scene= SceneManager.GetActiveScene();
        Debug.Log(MomentaryCharacterNumber);
        CreateEnemys();
        //Debug.Log(_memoryManagement.ReadIntData("Point"));
    }
    private void Update()
    {
        Debug.Log(MomentaryCharacterNumber);
    }
    public void CreateEnemys()
    {
        for (int i = 0; i < MomentaryEnemyNumber; i++)
        {
            Enemys[i].SetActive(true);
        }
    }
    public void WarSituation()
    {
        if (!Player.IsItEnd) return;
        if (MomentaryCharacterNumber == 1 || MomentaryEnemyNumber == 0)
        {
            isgameover = true;
            foreach (var item in Enemys)
            {
                if(item.activeInHierarchy)
                    item.GetComponent<Animator>().SetBool("Attack", false);
            }
            foreach (var item in Characters)
            {
                if (item.activeInHierarchy)
                    item.GetComponent<Animator>().SetBool("Attack", false);
            }
            Player.GetComponent<Animator>().SetBool("Attack", false);
            if (MomentaryCharacterNumber < MomentaryEnemyNumber || MomentaryCharacterNumber == MomentaryEnemyNumber)
            {
                
                //Debug.Log("Lose");
                _operationPanels[3].SetActive(true);
            }
            else
            {
                if (MomentaryCharacterNumber > 5)
                { 
                    if (_scene.buildIndex == _memoryManagement.ReadIntData("LastLevel"))
                    {
                        _memoryManagement.SaveIntData("Point", _memoryManagement.ReadIntData("Point") + 600);
                        _memoryManagement.SaveIntData("LastLevel", _memoryManagement.ReadIntData("LastLevel") + 1);
                    }        
                } 
                else
                { 
                    if (_scene.buildIndex == _memoryManagement.ReadIntData("LastLevel"))
                    {
                        _memoryManagement.SaveIntData("Point", _memoryManagement.ReadIntData("Point") + 200);
                        _memoryManagement.SaveIntData("LastLevel", _memoryManagement.ReadIntData("LastLevel") + 1);
                    }       
                }
                //Debug.Log("Win");
                _operationPanels[2].SetActive(true);
            }
        }
    }
    public void CharacterNumberChange(string operationType, int incomingNumber, Transform _position)
    {
        switch (operationType)
        {
            case "Multiplication":
                _mathematicalOperations.MultiplicationNumbers(incomingNumber, Characters, _position,ConsistEffects);
                break;

            case "Collection":
                _mathematicalOperations.CollectionNumbers(incomingNumber, Characters, _position,ConsistEffects);
                break;

            case "Subtraction":
                _mathematicalOperations.SubtractionNumbers(incomingNumber, Characters, ExtinctionEffects);
                break;

            case "Division":
                _mathematicalOperations.DivisionNumbers(incomingNumber, Characters, ExtinctionEffects);
                break;
        }
    }
    public void CreateExtinctionEffect(Vector3 newposition, bool Hammer = false, bool reducewhat=false) 
    {
        foreach (var item in ExtinctionEffects)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = newposition;
                item.GetComponent<AudioSource>().volume = _memoryManagement.ReadFloatData("GameFx");
                item.GetComponent<ParticleSystem>().Play();
                item.GetComponent<AudioSource>().Play();
                if (!reducewhat)
                    MomentaryCharacterNumber--;
                else
                    MomentaryEnemyNumber--;
                break;
            }
        }
        if (Hammer)
        {
            Vector3 NewPosition = new Vector3(newposition.x, .005f, newposition.z);
            foreach (var item in Stains)
            {
                if (!item.activeInHierarchy)
                {
                    item.SetActive(true);
                    item.transform.position = NewPosition;
                    break;
                }
            }
        }
        if (!isgameover)
        {
            WarSituation();
        }
    }
    public void TriggerEnemy()
    {
        foreach (var item in Enemys)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<EnemyCharacter>().TriggerAnimation();
            }           
        }
    }
    public void RunExitButtons(string whichbutton)
    {
        Sounds[1].Play();
        if (whichbutton == "Exit")
        {
            _operationPanels[1].SetActive(true);
            Time.timeScale = 0;
        }
        if (whichbutton == "Continue")
        {
            _operationPanels[1].SetActive(false);
            Time.timeScale = 1;
        }
        if (whichbutton == "Replay")
        {
            SceneManager.LoadScene(_scene.buildIndex);
            Time.timeScale = 1;
        }
        if (whichbutton == "MainMenu")
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
    public void RunSettingsButtons(string whichbutton)
    {
        Sounds[1].Play();
        if (whichbutton == "Settings")
        {
            _operationPanels[0].SetActive(true);
            Time.timeScale = 0;
        }
        if(whichbutton == "Exit")
        {
            _operationPanels[0].SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void ChangeAudio(string whichslider)
    {
        if(whichslider == "GameSound")
        {
            _memoryManagement.SaveFloatData("GameSound", _settingsSliders[0].value);
            Sounds[0].volume = _settingsSliders[0].value;
        }
        if (whichslider == "GameFx")
        {
            _memoryManagement.SaveFloatData("GameFx", _settingsSliders[1].value);
            Sounds[1].volume = _settingsSliders[0].value;
        }       
    }
    public void RunNextLevelButton()
    {
        Sounds[1].Play();
        SceneManager.LoadScene(_scene.buildIndex + 1);
    }
}
