using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float minXClamp;
    public float maxXClamp;


    private void LateUpdate()
    {
        Vector3 cameraPostition;

        cameraPostition = transform.position;

        cameraPostition.x = Mathf.Clamp(player.transform.position.x, minXClamp, maxXClamp);
        transform.position = cameraPostition;
    }
}