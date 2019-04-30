using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour {

	public GameObject target;
	public float positionX, positionY, positionZ, step;
    //for camera
    public bool border;
    public float minX, maxX, minY, maxY;

    public void setBorder(float minX, float maxX, float minY, float maxY)
    {
        this.minX = minX;
        this.maxX = maxX;
        this.minY = minY;
        this.maxY = maxY;
    }

	void Update(){
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position - new Vector3(positionX, positionY, positionZ), step);
        if (border)
        transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, minX, maxX),
        Mathf.Clamp(transform.position.y, minY, maxY),
        transform.position.z
    );
    }
}
