using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antidote : MonoBehaviour
{
    [SerializeField] bool isAntidote;

    public bool isRealAntidote()
    {
        return isAntidote;
    }
}
