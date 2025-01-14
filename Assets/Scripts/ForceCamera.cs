﻿using UnityEngine;
using System.Collections;

public class ForceCamera : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object


    public Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset.x = transform.position.x - player.transform.position.x;
        offset.z = transform.position.z - player.transform.position.z;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        // transform.position = player.transform.position + offset;
        transform.position = new Vector3(player.transform.position.x + offset.x, 10.5f, player.transform.position.z + offset.z);

    }
}