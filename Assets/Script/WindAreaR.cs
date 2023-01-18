using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAreaR : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (!other.TryGetComponent(out NpcController alt_Karakter)) return;
        alt_Karakter.Rigidbody.AddForce(new Vector3(5, 0, 0), ForceMode.Impulse);
    }
}
