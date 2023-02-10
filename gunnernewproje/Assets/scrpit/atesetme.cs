using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atesetme : MonoBehaviour
{
    Vector2 Vector2 = new Vector2(0, 10);
    public Camera cam;
    public LayerMask eaglekatman;
    public LayerMask bearkatman;
    public LayerMask wolfkatman;
    karakter_hareket hpkontrol;
    Animator anim;
    float firlatma_hizi;
    //public GameObject arrowObject;
    //public Transform arrowPoint;





    void Start()
    {
        anim = GetComponent<Animator>();
        cam=Camera.main;
        hpkontrol=this.gameObject.GetComponent<karakter_hareket>();

    }

    
    void Update()
    {
        
        if (hpkontrol.YasiyorMu() == true)
        {
            if (Input.GetMouseButton(0))
            {
                anim.SetBool("hit", true);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                anim.SetBool("hit", false);
            }
            
        }
       
        
    }
   
     public void AtesEtme()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;


        //GameObject arrow = Instantiate(arrowObject, arrowPoint.position, transform.rotation);
        //arrow.GetComponent<Rigidbody>().AddForce(transform.forward * 20f, ForceMode.Impulse);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, wolfkatman))
        {
            hit.collider.gameObject.GetComponent<Spider>().HasarAL();
        }



        if (Physics.Raycast(ray, out hit, Mathf.Infinity, eaglekatman))
        {

            hit.collider.gameObject.GetComponent<eagle>().HasarAL();
           
            
        }

       if (Physics.Raycast(ray, out hit, Mathf.Infinity, bearkatman))
        {
            hit.collider.gameObject.GetComponent<bear>().HasarAL();
        }
     

    }
    public void Ok()
    {
        anim.SetBool("ok", true);
    }
         
    
}
