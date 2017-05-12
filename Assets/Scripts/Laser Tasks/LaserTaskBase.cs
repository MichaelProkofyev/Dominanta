using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class LaserTaskBase {

    protected Vector3 startPoint;
    protected int cyclesCount; //Number of times to repeat the pattern. 0 - infinity.
    protected float speed;

    protected float currCycleProgress = 0f; //0..1
    protected int currCycleIdx = 0;

    public bool isFinished = false;
    

    public LaserTaskBase(Vector3 newStartPoint, float newSpeed = 5f, int newCyclesCount = 0) {
        this.startPoint = newStartPoint;
        this.cyclesCount = newCyclesCount;
        this.speed = newSpeed;
    }

    //Wrapper-method for REAL CALCULATIONS in NextPointCalculations method
    public Vector3 NextPoint() {
        if (currCycleProgress >= 1f) { //End of the cycle
            currCycleIdx++;
            bool moveToNextCycle = cyclesCount == 0 || currCycleIdx < cyclesCount; //If set to infinite repeat OR cycles left
            if (moveToNextCycle) {
                currCycleProgress = 0;
            } else {
                isFinished = true;
            }
        }

        return NextPointCalculations();
    }

    abstract public Vector3 NextPointCalculations();
}
