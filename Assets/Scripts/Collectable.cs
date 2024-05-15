using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectable : MonoBehaviour
{

    public float distanceToMove;

    private Vector3 startingPostion;
    private Vector3 leftEndingPosition;
    private Vector3 rightEndingPosition;

    public float speed = 0.1f;
    public float direction = -1f;

    [Header("Scene to Load")]
    public int sceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        startingPostion = transform.position;
        rightEndingPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + distanceToMove);
        leftEndingPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - distanceToMove);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= leftEndingPosition.z || transform.position.z >= rightEndingPosition.z)
        {
            direction *= -1;
        }

        //transform.position = Time.deltaTime * distanceToMove;
        transform.position += new Vector3(0, 0, direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Invoke("LoadNextScene", 2f);
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
