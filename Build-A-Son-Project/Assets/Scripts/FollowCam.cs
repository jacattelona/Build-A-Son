using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float awayY = 4.0f;
    [SerializeField] float awayZ = 4.0f;
    float rSpeed = 2.0f;
    
    Vector3 offset;

    // Start is called before the first frame update
    void Awake()
    {
        Vector3 startPos = new Vector3();
        startPos.x = target.position.x;
        startPos.y = target.position.y + 3;
        startPos.z = target.position.z - 6;
        transform.position = startPos;
        offset = new Vector3(target.position.x, target.position.y + awayY, target.position.z + awayZ);
    }


    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rSpeed, Vector3.up) * offset;
        transform.position = target.position + offset;
        transform.LookAt(target.position);
    }
}
