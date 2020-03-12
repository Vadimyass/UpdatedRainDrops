using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPerspective : MonoBehaviour
{
    [SerializeField] private Transform GeneralRainDrop = null;
    private Vector3 positionOfCamera;
    public float smoothSpeed = 0.0001f;
    void Update()
    {
        positionOfCamera = new Vector3(transform.position.x, GeneralRainDrop.transform.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, positionOfCamera, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
