using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_rot : MonoBehaviour
{
    
   public Transform GetWaypoint(int waypointInedx)
    {
        return transform.GetChild(waypointInedx);
    }
    public int GetNextWaypointIndex (int currentWaypointIndex)
    {
        int nextWaypointIndex = currentWaypointIndex+1;
        if (nextWaypointIndex == transform.childCount)
        {
          nextWaypointIndex = 0;
        }
        return nextWaypointIndex;
    }
}
