using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static bool escapeSequence;

    private void Awake()
    {
        escapeSequence = true;
    }
}
