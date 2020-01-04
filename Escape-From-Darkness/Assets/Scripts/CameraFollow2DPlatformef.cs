using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2DPlatformef : MonoBehaviour
{
    public Transform playerFollow;
    public float smoothingCamera; //dempening effect

    Vector3 offsetCameraWithPlayer;

    float lowPointCameraY;
    
    // Start is called before the first frame update
    void Start()
    {
        offsetCameraWithPlayer = transform.position - playerFollow.position;
        lowPointCameraY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCamPos = playerFollow.position + offsetCameraWithPlayer;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothingCamera*Time.deltaTime);

        if(transform.position.y < lowPointCameraY)
        {
            transform.position = new Vector3(transform.position.x, lowPointCameraY, transform.position.z);
        }
    }
}
