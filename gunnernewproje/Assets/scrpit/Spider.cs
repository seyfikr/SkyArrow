using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Spider : MonoBehaviour
{
    public Slider Slider;

    Animator anim;
    public float Spiderhp = 100;
    bool spiderdied;
    public Transform hedefoyuncu;
    public float kovalamamesafe;
    float mesafe;
    NavMeshAgent Spidernacymesh;
    public float saldirmamesafe;

    void Start()
    {

        anim = GetComponent<Animator>();
        //hedefoyuncu = GameObject.Find("arrow");
        Spidernacymesh = this.GetComponent<NavMeshAgent>();

    }


    void FixedUpdate()
    {
        Slider.value = Spiderhp;

        if (Spiderhp <= 0)
        {
            spiderdied = true;
        }
        if (spiderdied == true)
        {
            anim.SetBool("died", true);
            StartCoroutine(yokol());
        }
        else
        {
            mesafe = Vector3.Distance(this.transform.position, hedefoyuncu.transform.position);
            if (mesafe < kovalamamesafe)
            {
                this.transform.LookAt(hedefoyuncu.transform.position);
                Spidernacymesh.isStopped = false;
                Spidernacymesh.SetDestination(hedefoyuncu.transform.position);
                //yurume
                anim.SetBool("yuruyor", true);
                anim.SetBool("hit", false);
            }
            else
            {
                Spidernacymesh.isStopped = true;
                anim.SetBool("yuruyor", false);
                anim.SetBool("hit", false);
            }
            if (mesafe < saldirmamesafe)
            {
                this.transform.LookAt(hedefoyuncu.transform.position);
                Spidernacymesh.isStopped = true;
                
                anim.SetBool("yuruyor", false);
                anim.SetBool("hit", true);




            }
        }

    }
    public void HasarAL()
    {
        Spiderhp -= Random.Range(30,32);
    }
    public void HasarVer()
    {

        hedefoyuncu.GetComponent<karakter_hareket>().hasaral();

    }
    IEnumerator yokol()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
        Destroy(this.gameObject);
    }
   
}
