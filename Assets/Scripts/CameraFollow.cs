using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void FixedUpdate()
    {
        if (player)
            transform.position = new Vector3(player.position.x + offset.x, offset.y, offset.z); // Camera follows the player with specified offset position
    }
}
