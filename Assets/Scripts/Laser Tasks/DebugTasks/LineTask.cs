using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTask : LaserTaskBase {


    //Constructor that just uses the base class, nothing more
    public LineTask(Vector3 newStartPoint, float newSpeed = 5, int newCyclesCount = 0) : base(newStartPoint, newSpeed, newCyclesCount)
    {

    }

    public override Vector3 NextPointCalculations()
    {
        return startPoint;
    }
}