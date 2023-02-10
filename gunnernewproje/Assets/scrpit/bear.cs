using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class bear : MonoBehaviour
{
    public Slider Slider;

    Animator anim;
    public float bearhp = 100;
    bool beardied;
    public Transform hedefoyuncu;
    public float kovalamamesafe;
    float mesafe;
    NavMeshAgent bearnavmsh;
    public float saldirmamesafe;

    void Start()
    {

        anim = GetComponent<Animator>();
        //hedefoyuncu = GameObject.Find("arrow");
        bearnavmsh = this.GetComponent<NavMeshAgent>();
       
    }


    void FixedUpdate()
    {
        Slider.value = bearhp;

        if (bearhp <= 0)
        {
            beardied = true;
        }
        if (beardied == true)
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
                bearnavmsh.isStopped = false;
                bearnavmsh.SetDestination(hedefoyuncu.transform.position);
                //yurume
                anim.SetBool("yuruyor", true);
                anim.SetBool("hit", false);
            }
            else
            {
                bearnavmsh.isStopped = true;
                anim.SetBool("yuruyor", false);
                anim.SetBool("hit", false);
            }
            if (mesafe < saldirmamesafe)
            {
                this.transform.LookAt(hedefoyuncu.transform.position);
                bearnavmsh.isStopped = true;
                //vurma
                anim.SetBool("yuruyor", false);
                anim.SetBool("hit", true);




            }
        }

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
    public void HasarAL()
    {
        bearhp -= Random.Range(17f, 25f);
    }
}
