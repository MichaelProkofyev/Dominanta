using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Laser : MonoBehaviour {

    public int numberOfReflections = 3;

    LineRenderer laserLine;

<<<<<<< HEAD
    public Vector3 startPos;
    public Vector3 endPos;
=======
    List<LaserTaskBase> tasks = new List<LaserTaskBase>();
    int currTaskIdx = 0;
>>>>>>> 88597d54bfa8c74870f42d8c85fc1dd32d711986

	// Use this for initialization
	void Start () {
        laserLine = GetComponent<LineRenderer>();

      //  LaserTaskBase lineTask = new LineTask(new Vector3(0f, -2f, 0f), 4f, 0);
        LaserTaskBase sinTask = new SinTask(new Vector3(5f, -5f, 5f), 4f, 5);
        LaserTaskBase cosTask = new CosTask(new Vector3(5f, -10f, 5f), 4f, 0);

       // tasks.Add(lineTask);
    //    tasks.Add(sinTask);
        tasks.Add(cosTask);
    }
	
	// Update is called once per frame
	void Update () {
        if (currTaskIdx >= tasks.Count) return;  //If no tasks left - do nothing


<<<<<<< HEAD
//        Vector3 startPosition = transform.position;
//        Vector3 endPosition = startPosition + Random.insideUnitSphere * 5f;

        Vector3 startPosition = startPos;
        Vector3 endPosition = endPos;


=======
        Vector3 startPosition = transform.position;
        Vector3 endPosition = tasks[currTaskIdx].NextPoint(); // startPosition + Random.insideUnitSphere * 5f;
>>>>>>> 88597d54bfa8c74870f42d8c85fc1dd32d711986

        laserLine.SetPosition(0, startPosition);

        //HITTING STUFF AND REFLECTING
        RaycastHit hitInfo;
        Vector3 direction = endPosition - startPosition;

        float raycastDistance = Vector3.Distance(endPosition, startPosition);
        bool hitSomething = Physics.Raycast(transform.position, direction, out hitInfo, raycastDistance);
        if(hitSomething) {

            int reflectionIdx = 0;
            Vector3 reflectionEndPosition = Vector3.zero;
            for (; reflectionIdx < numberOfReflections; reflectionIdx++) {
                laserLine.positionCount = 2 + reflectionIdx + 1; 
                laserLine.SetPosition(reflectionIdx + 1, hitInfo.point);
                //Reflection
                reflectionEndPosition = Vector3.Reflect(direction * raycastDistance, hitInfo.normal);
                direction = reflectionEndPosition - hitInfo.point;
                raycastDistance = Vector3.Distance(reflectionEndPosition, hitInfo.point);
                hitSomething = Physics.Raycast(hitInfo.point, direction, out hitInfo, raycastDistance);
                if (!hitSomething) break;
            }
            laserLine.SetPosition(laserLine.positionCount - 1, reflectionEndPosition);

        }
        else {
            laserLine.positionCount = 2;
            laserLine.SetPosition(1, endPosition);
        }


        //Move to the next task, if needed
        if(tasks[currTaskIdx].isFinished) {
            currTaskIdx++;
        }
    }
}
