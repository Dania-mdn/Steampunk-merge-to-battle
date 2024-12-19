using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Quaternion initialRotation;

    void Start()
    {
        // —охран€ем изначальную ориентацию объекта
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // ќбновл€ем мировую ориентацию объекта, игнориру€ поворот родител€
        transform.rotation = initialRotation;
    }
}
