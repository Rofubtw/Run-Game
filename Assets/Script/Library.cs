using System.Collections.Generic;
using UnityEngine;

namespace Rauf
{
    public class MathematicalOperations
    {
        MemoryManagement _memoryManagement = new MemoryManagement();
        public void MultiplicationNumbers(int incomingNumber, List<GameObject> Characters, Transform _position, List<GameObject> ConsistEffects)
        {
            int LoopQuantity = (GameManager.MomentaryCharacterNumber * incomingNumber) - GameManager.MomentaryCharacterNumber;
            #region Explanation   
            //                                5              *               2             -          5              = 5  tane karakter üretilecek
            //                                10             *               4             -          10             = 30 defa loop çalýþacak
            //                                3              *               3             -          3              = 6             
            #endregion
            int i = 0;
            foreach (var item in Characters)
            {
                if (i < LoopQuantity)
                {
                    if (!item.activeInHierarchy)
                    {
                        foreach (var item2 in ConsistEffects)
                        {
                            if (!item2.activeInHierarchy)
                            {
                                item2.SetActive(true);
                                item2.transform.position = _position.position;
                                item2.GetComponent<AudioSource>().volume = _memoryManagement.ReadFloatData("GameFx");
                                item2.GetComponent<ParticleSystem>().Play();
                                item2.GetComponent<AudioSource>().Play();
                                break;
                            }
                        }
                        item.transform.position = _position.position;
                        item.SetActive(true);
                        i++;
                    }
                }
                else
                {
                    i = 0;
                    break;
                }
            }
            GameManager.MomentaryCharacterNumber *= incomingNumber;
            //Debug.Log(incomingNumber + " ile çarpýldý " + GameManager.MomentaryCharacterNumber);
        }
        public void CollectionNumbers(int incomingNumber, List<GameObject> Characters, Transform _position, List<GameObject> ConsistEffects)
        {

            int i = 0;
            foreach (var item in Characters)
            {
                if (i < incomingNumber)
                {
                    if (!item.activeInHierarchy)
                    {
                        foreach (var item2 in ConsistEffects)
                        {
                            if (!item2.activeInHierarchy)
                            {
                                item2.SetActive(true);
                                item2.transform.position = _position.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                item2.GetComponent<AudioSource>().volume = _memoryManagement.ReadFloatData("GameFx");
                                item2.GetComponent<AudioSource>().Play();

                            }
                        }
                        item.transform.position = _position.position;
                        item.SetActive(true);
                        i++;
                    }
                }
                else
                {
                    i = 0;
                    break;
                }
            }
            GameManager.MomentaryCharacterNumber += incomingNumber;
            //Debug.Log(incomingNumber + " ile toplandý " + GameManager.MomentaryCharacterNumber);
        }
        public void SubtractionNumbers(int incomingNumber, List<GameObject> Characters, List<GameObject> ExtinctionEffects)
        {
            if (GameManager.MomentaryCharacterNumber <= incomingNumber)
            {
                foreach (var item in Characters)
                {
                    foreach (var item2 in ExtinctionEffects)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 NewPosition = new Vector3(item.transform.position.x, .23f, item.transform.position.z);
                            item2.SetActive(true);
                            item2.transform.position = NewPosition;
                            item2.GetComponent<ParticleSystem>().Play();
                            item2.GetComponent<AudioSource>().volume = _memoryManagement.ReadFloatData("GameFx");
                            item2.GetComponent<AudioSource>().Play();
                            break;
                        }
                    }
                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                    
                }
                GameManager.MomentaryCharacterNumber = 1;
                //Debug.Log(incomingNumber + " tane eksildi" + GameManager.MomentaryCharacterNumber);
            }
            else
            {
                int j = 0;

                foreach (var item in Characters)
                {
                    if (j != incomingNumber)
                    {
                        if (item.activeInHierarchy)
                        {
                            foreach (var item2 in ExtinctionEffects)
                            {
                                if (!item2.activeInHierarchy)
                                {
                                    Vector3 NewPosition = new Vector3(item.transform.position.x, .23f, item.transform.position.z);
                                    item2.SetActive(true);
                                    item2.transform.position = NewPosition;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    item2.GetComponent<AudioSource>().volume = _memoryManagement.ReadFloatData("GameFx");
                                    item2.GetComponent<AudioSource>().Play();
                                    break;
                                }
                                item.transform.position = Vector3.zero;
                                item.SetActive(false);
                                j++;
                            }
                        }
                        else
                        {
                            j = 0;
                            break;
                        }
                    }                  
                }
                GameManager.MomentaryCharacterNumber -= incomingNumber;
                //Debug.Log(incomingNumber + " tane eksildiiiiii" + GameManager.MomentaryCharacterNumber);
            }
        }
        public void DivisionNumbers(int incomingNumber, List<GameObject> Characters, List<GameObject> ExtinctionEffects)
        {
            if (GameManager.MomentaryCharacterNumber <= incomingNumber)
            {
                foreach (var item in Characters)
                {
                    foreach (var item2 in ExtinctionEffects)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 NewPosition = new Vector3(item.transform.position.x, .23f, item.transform.position.z);
                            item2.SetActive(true);
                            item2.transform.position = NewPosition;
                            item2.GetComponent<ParticleSystem>().Play();
                            item2.GetComponent<AudioSource>().volume = _memoryManagement.ReadFloatData("GameFx");
                            item2.GetComponent<AudioSource>().Play();
                            break;
                        }
                    }
                    item.transform.position = Vector3.zero;
                    item.SetActive(false);

                }
                GameManager.MomentaryCharacterNumber = 1;
            }
            else
            {
                int divided = GameManager.MomentaryCharacterNumber / incomingNumber;
                int j = 0;

                foreach (var item in Characters)
                {
                    if (j < divided)
                    {
                        if (item.activeInHierarchy)
                        {
                            foreach (var item2 in ExtinctionEffects)
                            {
                                if (!item2.activeInHierarchy)
                                {
                                    Vector3 NewPosition = new Vector3(item.transform.position.x, .23f, item.transform.position.z);
                                    item2.SetActive(true);
                                    item2.transform.position = NewPosition;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    item2.GetComponent<AudioSource>().volume = _memoryManagement.ReadFloatData("GameFx");
                                    item2.GetComponent<AudioSource>().Play();
                                    break;
                                }
                            }
                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            j++;
                        }
                    }
                    else
                    {
                        j = 0;

                        break;
                    }
                }
                if (GameManager.MomentaryCharacterNumber % incomingNumber == 0)
                {
                    GameManager.MomentaryCharacterNumber /= incomingNumber;
                }
                else if (GameManager.MomentaryCharacterNumber % incomingNumber == 1)
                {
                    GameManager.MomentaryCharacterNumber /= incomingNumber;
                    GameManager.MomentaryCharacterNumber++;
                }
                else if (GameManager.MomentaryCharacterNumber % incomingNumber == 2)
                {
                    GameManager.MomentaryCharacterNumber /= incomingNumber;
                    GameManager.MomentaryCharacterNumber += 2;
                }
            }
            //Debug.Log(incomingNumber + " ye bölündü" + GameManager.MomentaryCharacterNumber);
        }
    }
    public class MemoryManagement
    {
        public void SaveStringData(string key,string value)
        {
            PlayerPrefs.SetString(key,value);
            PlayerPrefs.Save();
        }
        public void SaveIntData(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save();
        }
        public void SaveFloatData(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
            PlayerPrefs.Save();
        }

        public string ReadStringData(string key)
        {
            return PlayerPrefs.GetString(key);
        }
        public int ReadIntData(string key)
        {
            return PlayerPrefs.GetInt(key);
        }
        public float ReadFloatData(string key)
        {
            return PlayerPrefs.GetFloat(key);
        }

        public void CheckandDescribe()
        {
            if (!PlayerPrefs.HasKey("LastLevel"))
            {
                PlayerPrefs.SetInt("LastLevel", 5);
                PlayerPrefs.SetInt("Puan", 1000);
                PlayerPrefs.SetFloat("MenuSound", 1);
                PlayerPrefs.SetFloat("MenuFx", 1);
                PlayerPrefs.SetFloat("GameSound", 1);
                PlayerPrefs.SetFloat("GameFx", 1);
            }
        }
    }
}
