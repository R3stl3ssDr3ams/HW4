using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public static Events Instance { get; private set; }
    public Pigeon Pidgeon { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        GameObject pidgeon = GameObject.FindWithTag("Player");
        Pidgeon = pidgeon.GetComponent<Pigeon>();
    }
}
