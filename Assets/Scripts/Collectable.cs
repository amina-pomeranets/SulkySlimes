using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public float distanceToMove;

    private Vector3 startingPostion;
    private Vector3 endingPosition;

    public float speed = 0.1f;
    public float direction = -1f;

    // Start is called before the first frame update
    void Start()
    {
        startingPostion = transform.position;
        endingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < startingPostion.z)
        {
            direction = 1f;
        }

        if (transform.position.z > startingPostion.z)
        {
            direction = -1f;
        }

        //transform.position = Time.deltaTime * distanceToMove;

    }
}
