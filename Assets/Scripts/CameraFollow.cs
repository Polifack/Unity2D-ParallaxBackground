using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followeable;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(followeable.position.x, this.transform.position.y, this.transform.position.z) ;
    }
}
