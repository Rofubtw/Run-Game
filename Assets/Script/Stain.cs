using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stain : MonoBehaviour
{
    const float _delayTime = 5f;
    WaitForSeconds wait = new WaitForSeconds(_delayTime);
    IEnumerator Start()
    {
        yield return wait;
        gameObject.SetActive(false);
    }
}
