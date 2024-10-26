using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // O objeto que a câmera deve seguir
    public Transform target;

    // Offset da câmera em relação ao objeto
    public Vector3 offset;

    // Velocidade de suavização da câmera
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target não foi atribuído à câmera.");
            return;
        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}