using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float raycastDistance = 5f;

    LineRenderer laserLine;

    List<LaserTaskBase> tasks = new List<LaserTaskBase>();
    int currTaskIdx = 0;

	// Use this for initialization
	void Start () {
        laserLine = GetComponent<LineRenderer>();

      //  LaserTaskBase lineTask = new LineTask(new Vector3(0f, -2f, 0f), 4f, 0);
        LaserTaskBase sinTask = new SinTask(new Vector3(5f, -5f, 5f), 4f, 5);
        LaserTaskBase cosTask = new CosTask(new Vector3(5f, -5f, 5f), 4f, 0);

       // tasks.Add(lineTask);
        tasks.Add(sinTask);
        tasks.Add(cosTask);
    }
	
	// Update is called once per frame
	void Update () {
        if (currTaskIdx >= tasks.Count) return;  //If no tasks left - do nothing


        Vector3 startPosition = transform.position;
        Vector3 endPosition = tasks[currTaskIdx].NextPoint(); // startPosition + Random.insideUnitSphere * 5f;

        laserLine.SetPosition(0, startPosition);

        //HITTING STUFF AND REFLECTING
        RaycastHit hitInfo;
        Vector3 direction = endPosition - startPosition;

        raycastDistance = Vector3.Distance(endPosition, startPosition);
        bool hitSomething = Physics.Raycast(transform.position, direction, out hitInfo, raycastDistance);
        if(hitSomething) {
            laserLine.positionCount = 3;
            laserLine.SetPosition(1, hitInfo.point);
            //Reflection
            Vector3 pos = Vector3.Reflect(direction * raycastDistance, hitInfo.normal);
            laserLine.SetPosition(2, pos);
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
