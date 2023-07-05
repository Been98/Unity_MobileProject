using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField]private Vector3 offset = new Vector3(0.0f, 10.0f, -10f);


    private float CameraSpeed = 10.0f;
    private Vector3 playerPos;

    private void FixedUpdate()
    {
        playerPos = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, player.transform.position.z + offset.z);
        transform.position = Vector3.Lerp(transform.position, playerPos, Time.deltaTime * CameraSpeed);

    }

}
