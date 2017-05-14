using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Laser : MonoBehaviour {

    [SerializeField]
    float raycastDistance = 5f;

    LineRenderer laserLine;

    public Vector3 startPos;
    public Vector3 endPos;

	// Use this for initialization
	void Start () {
        laserLine = GetComponent<LineRenderer>();

    }
	
	// Update is called once per frame
	void Update () {

//        Vector3 startPosition = transform.position;
//        Vector3 endPosition = startPosition + Random.insideUnitSphere * 5f;

        Vector3 startPosition = startPos;
        Vector3 endPosition = endPos;



        laserLine.SetPosition(0, startPosition);

        //Try hitting stuff
        RaycastHit hitInfo;

        Vector3 direction = endPosition - startPosition;

        bool hitSomething = Physics.Raycast(transform.position, direction, out hitInfo, raycastDistance);
        if(hitSomething) {
            laserLine.positionCount = 3;
          //  print(hitInfo.point);
            laserLine.SetPosition(1, hitInfo.point);
            //Reflection
            Vector3 pos = Vector3.Reflect(direction * raycastDistance, hitInfo.normal);
            laserLine.SetPosition(2, pos);
        }
        else {
            laserLine.positionCount = 2;
            laserLine.SetPosition(1, endPosition);
        }

    }
}
