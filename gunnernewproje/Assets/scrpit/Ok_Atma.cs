using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ok_Atma : MonoBehaviour
{
    public Vector3 m_target;
    public float speed;
     void Update()
    {
        float step =speed*Time.deltaTime;
        if(m_target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_target, step);
        }
    }
    public void setTarget(Vector3 target)
    {
        m_target = target;
    }
}
