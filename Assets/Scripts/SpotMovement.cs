using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SpotMovement : MonoBehaviour
{
    public float speed;
    public float pauseTimer;
    
    private float _pauseCounter;
    
    public List<Transform> waypointList;
    private Queue<Vector3> waypoint = new Queue<Vector3>();
    
    private void Start()
    {
        foreach (var point in waypointList)
        {
            waypoint.Enqueue(point.position);
        }
    }

    private void Update()
    {
        if(_pauseCounter > 0)
        {
            _pauseCounter -= Time.deltaTime;
            return;
        }
        
        Vector3 nextPoint = waypoint.Peek();
        transform.position = Vector3.MoveTowards(transform.position, nextPoint, speed * Time.deltaTime);
        
        if(transform.position == nextPoint)
        {
            Vector3 lastPoint = waypoint.Dequeue();
            waypoint.Enqueue(lastPoint);

            _pauseCounter = pauseTimer;
        }
    }
}
