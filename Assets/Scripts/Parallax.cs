using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float backgroundSize;
    public float parallaxSpeed;
    public Transform cameraTransform;

    private int leftBckg;
    private int rightBckg;
    private Transform[] backgrounds; //Array of backgrounds to be parallaxed
    private float viewZone = 10;
    private float lastCameraX;


    private int mod(int k, int n) { return ((k %= n) < 0) ? k + n : k; }


    // Start is called before the first frame update
    void Start()
    {
        lastCameraX = cameraTransform.position.x;
        backgrounds = new Transform[transform.childCount];
        for(int i=0; i<transform.childCount; i++)
        {
            backgrounds[i] = transform.GetChild(i);
        }

        leftBckg = 0;
        rightBckg = transform.childCount - 1;

    }

    private void ScrollLeft()
    {
        backgrounds[rightBckg].position = new Vector3((backgrounds[leftBckg].position.x - backgroundSize), backgrounds[rightBckg].position.y, 
            backgrounds[rightBckg].position.z);
        leftBckg = rightBckg;

        rightBckg--;
        rightBckg = mod(rightBckg, backgrounds.Length);
    }

    private void ScrollRight()
    {
        backgrounds[leftBckg].position = new Vector3((backgrounds[rightBckg].position.x + backgroundSize), backgrounds[leftBckg].position.y,
            backgrounds[leftBckg].position.z);
        rightBckg = leftBckg;

        leftBckg++;
        leftBckg = mod(leftBckg, backgrounds.Length);

    }

    private void Scroll(int direction)
    {
        //right = 1 ; left = -1



        rightBckg = mod(rightBckg, backgrounds.Length);
        leftBckg  = mod(leftBckg, backgrounds.Length);
    }

    private void FixedUpdate()
    {
        float deltaX = cameraTransform.position.x - lastCameraX;
        this.transform.position += Vector3.right * (deltaX * parallaxSpeed);
        lastCameraX = cameraTransform.position.x;        

        if (cameraTransform.position.x < (backgrounds[leftBckg].position.x) + viewZone)
            ScrollLeft();

        if (cameraTransform.position.x > (backgrounds[rightBckg].position.x) - viewZone)
            ScrollRight();
    }
}
