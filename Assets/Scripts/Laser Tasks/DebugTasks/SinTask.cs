using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinTask : LaserTaskBase {


    //Constructor that just uses the base class, nothing more
    public SinTask(Vector3 newStartPoint, float newSpeed = 5, int newCyclesCount = 0) : base(newStartPoint, newSpeed, newCyclesCount)
    {

    }

    public override Vector3 NextPointCalculations()
    {
        Vector3 nextPoint = new Vector3();
        nextPoint.x = Mathf.Sin(startPoint.x + currCycleProgress * 10);
        nextPoint.y = startPoint.y + currCycleProgress * 5;
        nextPoint.z = startPoint.z;
        currCycleProgress += speed * Time.deltaTime;
        return nextPoint;
    }
}