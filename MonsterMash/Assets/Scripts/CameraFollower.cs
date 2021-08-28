using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject player;

    void LateUpdate()
    {
        CameraFollow();
    }

    void CameraFollow()
    {
        Vector3 cameraPos = transform.position;
        cameraPos.z = player.transform.position.z - 12.3f;
        transform.position = cameraPos;
    }
}
