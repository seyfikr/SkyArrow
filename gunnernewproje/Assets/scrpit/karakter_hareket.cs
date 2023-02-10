using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class karakter_hareket : MonoBehaviour
{
   public  Slider slider;
    Animator anim;
    [SerializeField]
    private float karakterhiz;
    [SerializeField]
    private float rkarakterhiz;
    public Rigidbody rb;
    float x, z;
    public float jumpspeed;
    public float minjump;

    public Transform cam;
    Vector3 rmove = Vector3.zero;

    private float hp=150;
    bool hayattami;
    
    

    void Start()
    {
        anim=this.GetComponent<Animator>();
        hayattami = true;
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        slider.value = hp;
        
        if(hp <= 0)
        {
            hayattami=false;

            anim.SetBool("ölme", true);
        }
        if (hayattami == true)

        {
            if ((Input.GetKey(KeyCode.LeftShift)))
            {

                //anim.SetBool("run", true);
                //anim.SetBool("run", false);
                //x = Input.GetAxis("Horizontal");
                //z = Input.GetAxis("Vertical");
                //rmove = new Vector3(x, 0, z) * Time.deltaTime * rkarakterhiz;
                //rb.MovePosition(transform.position + transform.TransformDirection(rmove));
                float yatay = Input.GetAxis("Horizontal");
                float dikey = Input.GetAxis("Vertical");
                anim.SetFloat("Horizontal", yatay);
                anim.SetFloat("Vertical", dikey);
                this.gameObject.transform.Translate(yatay * rkarakterhiz * Time.deltaTime, 0, dikey * rkarakterhiz * Time.deltaTime);


            }

            else
            {
                hareket();
            }

            hareket();
            
            
        }
        
        

    }
   
    public bool YasiyorMu()
    {
        return hayattami;
    }
    void hareket()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        anim.SetFloat("Horizontal",yatay);
        anim.SetFloat("Vertical", dikey);
        this.gameObject.transform.Translate(yatay * karakterhiz*Time.deltaTime, 0, dikey * karakterhiz*Time.deltaTime);

        if(Input.GetMouseButtonDown(0))
        {
            anim.SetBool("hit", true);
        }
        else
            anim.SetBool("hit", false);

    }
    public void hasaral()
    {
        hp -= Random.Range(15,19);
    }
    public float GetHP()
    {
        return hp;
    }
    void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector3.up * Time.deltaTime * jumpspeed;

            if (x != 0 || z != 0)
            {
                rb.AddForce(Vector3.up * Time.deltaTime * minjump, ForceMode.VelocityChange);
            }
        }
        if (x != 0 || z != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, cam.transform.rotation, 0.3f);
        }

        //if (Input.GetKeyDown("space"))
        //{
        //    transform.Translate(Vector3.up * 150 * Time.deltaTime, Space.World);
        //}

    }


}

