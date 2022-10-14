using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float y_minimumValue = 0;

    float zOffset = -10;
    public float yOffset = .5f;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        updateCameraPosition();
    }

    public void updateCameraPosition()
    { 
        if(target.transform.position.y < y_minimumValue) 
        {
            //If player is below y_minimumValue, set y to y_minimumValue
            transform.position = new Vector3(target.transform.position.x, y_minimumValue + yOffset, zOffset);
        }
        else
        {
            // Otherwise follow players x and y values
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y + yOffset, zOffset);
        }
    }
    
}
