using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float minXClamp;
    public float maxXClamp;
    public float minYClamp;
    public float maxYClamp;

    private void LateUpdate()
    {
        if (!GameManager.Instance) return;
        if (!GameManager.Instance.playerInstance) return;

        Vector3 cameraPosition;

        cameraPosition = transform.position;

        cameraPosition.x = Mathf.Clamp(GameManager.Instance.playerInstance.transform.position.x, minXClamp, maxXClamp);

        transform.position = cameraPosition;
    }
}