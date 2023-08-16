using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    [SerializeField] private string detail;

    public string GetName()
    {
        return detail;
    }


}
