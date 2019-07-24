using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartsGenerator : MonoBehaviour
{
    public GameObject dartPrefab;

    Vector3 startPos;
    //private Vector3 position;
    //private Vector3 screenToWorldPointPosition;

    public float speed = 0;
    public GameObject Dart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            GameObject Dart = Instantiate(dartPrefab) as GameObject;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            Dart.GetComponent<DartsController>().Shoot(worldDir.normalized * 2000);
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            //Dart = Instantiate(dartPrefab) as GameObject;
            Dart = Instantiate(dartPrefab);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //Dart.GetComponent<Rigidbody>().isKinematic = false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            Vector3 endPos = Input.mousePosition;

            float swipeLength = endPos.y - this.startPos.y;
            this.speed = swipeLength / 1.5f;
            Dart.GetComponent<DartsController>().Shoot(worldDir.normalized * this.speed);
        }
        //transform.Translate(0, this.speed, 0);
        this.speed *= 0.99f;
    }
}
