using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform target;
    public Vector3 target_offset;
    public bool EndCamPosition;
    public GameObject CameraDestination;

    void Start()
    {
        target_offset = transform.position - target.position;
    }
    private void LateUpdate()
    {
        if (!EndCamPosition)
            transform.position = Vector3.Lerp(transform.position, target.position + target_offset, .125f);
        else
            transform.position = Vector3.Lerp(transform.position, CameraDestination.transform.position, .015f);
    }
}
