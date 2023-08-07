using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boolian : MonoBehaviour
{

    public static Boolian Instance { get; private set; }
    public bool useApi;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

}
