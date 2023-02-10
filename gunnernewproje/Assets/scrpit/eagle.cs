using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class eagle : MonoBehaviour
{
    
    Animator anim;
    public float eaglehp = 100;
    bool eagledied;
    public Transform hedefoyuncu;
    public float kovalamamesafe;
    float mesafe;
    NavMeshAgent eaglenavmsh;
    public float saldirmamesafe;
    

    
    
    

    void Start()
    {
        
        anim = GetComponent<Animator>();
        //hedefoyuncu = GameObject.Find("arrow");
        eaglenavmsh=this.GetComponent<NavMeshAgent>();
    }

    
    void FixedUpdate()
    {

     
        if(eaglehp <= 0)
        {
            eagledied= true;
        }
        if (eagledied == true)
        {
            anim.SetBool("died",true);
            StartCoroutine(yokol());
        }
        else
        {
             mesafe = Vector3.Distance(this.transform.position, hedefoyuncu.transform.position);
            if(mesafe < kovalamamesafe)
            {
                this.transform.LookAt(hedefoyuncu.transform.position);
                eaglenavmsh.isStopped = false;
                eaglenavmsh.SetDestination(hedefoyuncu.transform.position);
                //yurume
                anim.SetBool("ucuyor", true);
                anim.SetBool("hit", false);
            }
            else
            {
                eaglenavmsh.isStopped = true;
                anim.SetBool("ucuyor", false);
                anim.SetBool("hit", false);
            }
            if (mesafe < saldirmamesafe)
            {
                this.transform.LookAt(hedefoyuncu.transform.position);
                eaglenavmsh.isStopped = true;
                //vurma
                anim.SetBool("ucuyor", false);
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
        eaglehp -= Random.Range(18f, 29f);
    }
}
