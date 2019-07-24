using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject dartPrefab;

    Vector3 startPos;
    private Vector3 position;
    private Vector3 screenToWorldPointPosition;

    public float speed = 0;
    public GameObject dart;

    // Start is called before the first frame update
    void Start()
    {
        dart = Instantiate(dartPrefab);
        Debug.Log(dart);
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

        //ダーツがはじめから生成されていて、それがマウスポイントに追従している形の処理

        if (dart!=null)
        {
        position = Input.mousePosition;
        position.z = 10f;
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        Debug.Log(screenToWorldPointPosition);
        dart.transform.position = screenToWorldPointPosition;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //Dart = Instantiate(dartPrefab) as GameObject;
            //Dart = Instantiate(dartPrefab);
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
            dart.GetComponent<DartsController>().Shoot(worldDir.normalized * this.speed);
            dart = null;
            //カウント後にダーツ生成の処理
            dart = Instantiate(dartPrefab);

        }
        //transform.Translate(0, this.speed, 0);
        this.speed *= 0.99f;
    }
}
