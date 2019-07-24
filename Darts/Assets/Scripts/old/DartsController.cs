using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartsController : MonoBehaviour
{

    public void Shoot(Vector3 dir)
    {
        //GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(dir);
    }

    public void dartSpeed()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Shoot(new Vector3(0, 200, 2000));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
