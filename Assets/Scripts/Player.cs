using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public Transform eyes;

    private float eyePos;
    private float direction;

    private void Awake()
    {
        eyePos = eyes.transform.localPosition.x;
    }

    private void Update()
    {
        direction = Input.GetAxis("Horizontal");
    }
    void FixedUpdate()
    {
        float movement = this.transform.position.x + direction * speed * Time.deltaTime;
        flip(direction);
        this.transform.position = new Vector3(movement, this.transform.position.y, this.transform.position.z);
    }

    private void flip(float direction)
    {
        if (direction > 0)
            eyes.localPosition = new Vector3(eyePos, eyes.transform.localPosition.y, eyes.transform.localPosition.z);
        else if (direction < 0)
            eyes.localPosition = new Vector3(-eyePos, eyes.transform.localPosition.y, eyes.transform.localPosition.z);
    }
}
