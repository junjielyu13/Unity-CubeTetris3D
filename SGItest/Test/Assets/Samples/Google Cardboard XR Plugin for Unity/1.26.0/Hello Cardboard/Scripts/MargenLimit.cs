using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MargenLimit : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxYPosition = 20f;
    public float minXPosition = -2.5f;
    public float maxXPosition = 2.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > maxYPosition)
        {
            Vector3 clampedPosition = transform.position;
            clampedPosition.y = maxYPosition;
            transform.position = clampedPosition;
        }

        if (transform.position.x > maxXPosition)
        {
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = maxYPosition;
            transform.position = clampedPosition;
        }

        if (transform.position.x < minXPosition)
        {
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = minXPosition;
            transform.position = clampedPosition;
        }
    }
}
