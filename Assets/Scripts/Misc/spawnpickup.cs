using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnpickup : MonoBehaviour
{
    public GameObject[] spawnpoint;
    void Start()
    {
        Instantiate(spawnpoint[Random.Range(0, spawnpoint.Length)], this.transform);
    }

}
