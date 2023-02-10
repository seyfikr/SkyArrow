using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class platform_hareket : MonoBehaviour
{
    [SerializeField]
    private platform_rot _waypointpath;
    [SerializeField]
    private float speed;
    private int _targetwaypointindex;
    private Transform _prviouswatpoint;
    private Transform _targetwaypoint;
    private float _timetowaypoint;
    private float _elapsedtime;

    void Start()
    {
        targetnextway();
    }

    
    void Update()
    {
        _elapsedtime +=Time.deltaTime;
        float elapsedpercent = _elapsedtime / _timetowaypoint;
        elapsedpercent= Mathf.SmoothStep(0,1,elapsedpercent);
        transform.position = Vector3.Lerp(_prviouswatpoint.position,_targetwaypoint.position, elapsedpercent);
        transform.rotation = Quaternion.Lerp(_prviouswatpoint.rotation, _targetwaypoint.rotation, elapsedpercent);
        if (elapsedpercent >= 1)
        {
            targetnextway();
        }
    }
    private void targetnextway()
    {
        _prviouswatpoint =_waypointpath.GetWaypoint(_targetwaypointindex);
        _targetwaypointindex=_waypointpath.GetNextWaypointIndex(_targetwaypointindex);
        _targetwaypoint = _waypointpath.GetWaypoint(_targetwaypointindex);

        _elapsedtime = 0;
        float distancewaypoint =Vector3.Distance(_prviouswatpoint.position,_targetwaypoint.position);
        _timetowaypoint=distancewaypoint / speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
