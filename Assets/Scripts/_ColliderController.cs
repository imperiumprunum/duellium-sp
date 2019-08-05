using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class _ColliderController : MonoBehaviour {

    GameObject outerRing;
    EdgeCollider2D edgeCollider;

    //GameObject bulletPrefab;


    // Use this for initialization
    void Start () {

        outerRing = GameObject.Find("OUTER-RING");
        outerRing.AddComponent<EdgeCollider2D>();

       //bulletPrefab = (GameObject)Resources.Load("Prefabs/PLAYER_BULLET");
        CreateCollider();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(transform.position, Vector3.up * (outerRing.GetComponent<Renderer>().bounds.size.x)/2f, Color.cyan);
    }

    Vector2[] CalcEdgeColliderPoints(float scaleFactor)
    {
        int STEP = 10;
        int angle = 0;
        int angleEnd = 360;

        Vector2[] colliderPoints = new Vector2[(angleEnd / STEP)+1];


        //  360 + STEP <-------- for missing part of circle collider
        while (angle != (angleEnd+STEP))
        {
            colliderPoints[angle/STEP] = new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad)) * scaleFactor;
            //  DEBUG
            //Instantiate(bulletPrefab, new Vector3(colliderPoints[angle / STEP].x, colliderPoints[angle / STEP].y, 0), Quaternion.identity);
            angle += STEP;
        }

        return colliderPoints;
    }

    void CreateCollider()
    {
        edgeCollider = outerRing.GetComponent<EdgeCollider2D>();
        edgeCollider.points = CalcEdgeColliderPoints(1.2f).Concat(CalcEdgeColliderPoints(1.3f)).ToArray();
    }
}
