using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    GameObject carrying;
    Vector3 offset = new Vector3(1, 0, 0);


    void Update()
    {
        if (carrying != null)
        {
            Vector3 temp = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            carrying.transform.position = temp + transform.forward * 1.5f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "BodyPart")
        {
            print("Oh Boy I hit it hooray");
            carrying = collision.gameObject;
        }

        if (collision.transform.tag == "Altar" && carrying != null)
        {
            Vector3 temp = collision.transform.position;
            temp.y += 1;
            carrying.transform.position = temp;
            carrying.tag = "Untagged";
            carrying = null;
        }
    }
}
