using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Darts : MonoBehaviour
{
    private float maxScreenSizeX;
    private float maxScreenSizeY;

    private Vector3 oldPosition;
    private Vector3 nowPower;

    private Vector3 maxScreenSize;
    private Vector2 startPos;

    public float speedY = 3.0f;
    public float speedZ = 100.0f;

    AudioSource audioSource;
    public GameObject congrats;

    private float timeElapsed;
    private bool frite;

    //float angle = 10;
    //float rad = angle * Mathf.Deg2Rad;

    // Start is called before the first frame update
    void Start()
    {
        maxScreenSizeX= Screen.width;
        maxScreenSizeY = Screen.height;
        maxScreenSize = new Vector3(Screen.width/2, Screen.height/2, 0.0f);
        frite = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nowPosition = Input.mousePosition;

        //Debug.Log(nowPosition);
        Vector3 screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition+new Vector3(0,0,3.0f));

        //Debug.Log(screenToWorldPointPosition);
        if (!frite)
        {
            gameObject.transform.position = screenToWorldPointPosition;
        }



        //速度を取る
        /*if (oldPosition.y<nowPosition.y)
        {
            nowPower += nowPosition - oldPosition;
        }
        if (oldPosition.y>=nowPosition.y)
        {
            nowPower = Vector3.zero;
        }*/

        if (Input.GetMouseButton(0)&&timeElapsed < 10)
        {
            timeElapsed += Time.deltaTime;
        }
        else if (Input.GetMouseButtonUp(0)&& !frite)
        {
            float y = speedY * timeElapsed;
            float z = speedZ * timeElapsed;
            //var Force = new Vector3(0.0f, 1.0f, 1000.0f);
            GetComponent<Rigidbody>().AddForce(0f, y, z);
            frite = true;
            timeElapsed = 0.0f;
        }

        //oldPosition = Input.mousePosition;

        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "target")
        {
            congrats.SetActive(true);
            audioSource.Play();
        }
    }
}
