using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour{
	
	public float rotationAngle = 30;
	public void CameraRotateRight(){
		transform.RotateAround(Vector3.zero, Vector3.down, rotationAngle);
	}
	public void CameraRotateLeft(){
		transform.RotateAround(Vector3.zero, Vector3.up, rotationAngle);
	}
}
