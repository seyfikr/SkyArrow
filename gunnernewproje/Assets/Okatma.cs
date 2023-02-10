using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Okatma : MonoBehaviour
{
    public Transform okçu, okatma, ok,okpoz;
    Transform klon;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
           klon= Instantiate(ok, okpoz.position, okatma.rotation);
            klon.GetComponent<Rigidbody>().AddForce(klon.forward * 1000f);
        }
    }
}
