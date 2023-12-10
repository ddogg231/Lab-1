using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    
    public Transform spawnPoint;
    public AudioClip BGM;
    void Start()
    {
        
        GameManager.Instance.currentLevel = this;
        GameManager.Instance.SpawnPlayer(spawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
