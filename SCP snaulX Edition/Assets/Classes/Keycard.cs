using UnityEngine;
using System.Collections;
using System;

public class Keycard : MonoBehaviour
{
    [SerializeField]
    public SecurityLevel security;
    public AudioSource take = new AudioSource();
    
    void Start()
    {
        take.clip = GameObject.Find("player").GetComponent<Main>().pick_card;
    }
}
