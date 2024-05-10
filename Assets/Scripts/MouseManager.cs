using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UIElements;

/*

public class MouseManager : MonoBehaviour
{
    
    [Header("Mouse Info")]
    public Vector3 clickStartLocation;

    [Header("Physics")]
    public Vector3 launchVector;
    public float launchForce;

    [Header("Slime")]
    public Transform slimeTransform;
    public Rigidbody slimeRigidbody;

    //public float startingX = 8;
    //public float startingY = 1;
    //public float startingZ = 0;

    private Vector3 originalSlimePosition;
    private Quaternion originalSlimeRotation;

    private void Start()
    {
        originalSlimePosition = slimeTransform.position;
        originalSlimeRotation = slimeTransform.rotation;
    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            clickStartLocation = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mouseDifference = clickStartLocation - Input.mousePosition;
            launchVector = new Vector3(
                mouseDifference.x * 1f,
                mouseDifference.y * 1.2f,
                mouseDifference.y * 1.5f
            );
            slimeTransform.position = originalSlimePosition - launchVector / 400;
            launchVector.Normalize();

            //slimeTransform.position = new Vector3(startingX, startingY, startingZ);
        }

        if (Input.GetMouseButtonUp(0))
        {
            slimeRigidbody.isKinematic = false;
            slimeRigidbody.AddForce(launchVector * launchForce, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(1)) 
        {
            slimeTransform.position = originalSlimePosition;
            slimeTransform.rotation = originalSlimeRotation;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
        //if (other.gameObject.tag == "Ground")
        //{
            //slimeTransform.position = new Vector3(startingX, startingY, startingZ);
        //}
    //} 

*/












    public class MouseManager : MonoBehaviour
    {



    

        [Header("Mouse Info")]
        public Vector3 clickStartLocation;

        [Header("Physics")]
        public Vector3 launchVector;
        public float launchForce;

        [Header("Slime")]
        public Transform slimeTransform;
        public Rigidbody slimeRigidbody;

        [Header("Lives")]
        public LivesManager livesManager;


        private Vector3 orignalSlimePosition;
        private Quaternion originalSlimeRotation;

        //[Header("Lives")]
       // public LivesManager livesManager;

        void Start()
        {
            orignalSlimePosition = slimeTransform.position;
            originalSlimeRotation = slimeTransform.rotation;
        }

        void Update()
        {
            if (livesManager.lives < 0)
           {
                return;
           }

            if (Input.GetMouseButtonDown(0))
            {
                clickStartLocation = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 mouseDifference = clickStartLocation - Input.mousePosition;
                launchVector = new Vector3(
                    mouseDifference.x,
                    mouseDifference.y * 1.2f,
                    (mouseDifference.y) * 1.5f
                );

                slimeTransform.position = orignalSlimePosition - launchVector / 400;
                launchVector.Normalize();

            }

            if (Input.GetMouseButtonUp(0))
            {
                slimeRigidbody.isKinematic = false;
                slimeRigidbody.AddForce(launchVector * launchForce, ForceMode.Impulse);
            }

            if (Input.GetMouseButtonDown(1))
            {
                slimeRigidbody.isKinematic = true;
                slimeTransform.position = orignalSlimePosition;
                slimeTransform.rotation = originalSlimeRotation;
                livesManager.RemoveLife();
            }
        }
    }
    
//}