using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls camera movement
public class CameraMovement : MonoBehaviour {

    public int minPosition;
    public int maxPosition;

    private PlayerMovement player;
    public bool isFollowing;

    public float xOffset;
    public float yOffset;
    public float zOffset;
    public float smoothing;
    private Vector3 wantedPosition;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerMovement>();
        isFollowing = true;
    }

    void FixedUpdate()
    {
        if (isFollowing)
        {
            if (player.transform.position.x <= minPosition)
            {
                wantedPosition = new Vector3(minPosition + xOffset, player.transform.position.y + yOffset, -zOffset);
                transform.position = Vector3.Lerp(transform.position, wantedPosition, smoothing * Time.deltaTime);
            }
            else if (player.transform.position.x >= maxPosition)
            {
                wantedPosition = new Vector3(maxPosition + xOffset, player.transform.position.y + yOffset, -zOffset);
                transform.position = Vector3.Lerp(transform.position, wantedPosition, smoothing * Time.deltaTime);
            }
            else
            {
                wantedPosition = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, -zOffset);
                transform.position = Vector3.Lerp(transform.position, wantedPosition, smoothing * Time.deltaTime);
                //transform.position = new Vector3(Mathf.Clamp((player.transform.position.x + xOffset), minPosition, maxPosition), player.transform.position.y + yOffset, -zOffset);
            }
        }
    }
}
