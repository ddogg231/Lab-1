using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int StartingLives;
    public Transform spawnPoint;
    void Start()
    {
        GameManager.Instance.lives = StartingLives;
        GameManager.Instance.currentLevel = this;
        GameManager.Instance.SpawnPlayer(spawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
