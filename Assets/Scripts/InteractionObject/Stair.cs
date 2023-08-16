using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour
{
    [SerializeField] private Transform nextPosition;

    public Vector3 GetNext() {
        return nextPosition.position;
    }
}
