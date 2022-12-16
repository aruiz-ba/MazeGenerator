using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_animation : MonoBehaviour
{
	public	GameObject	cameraobject;
	//Small script for the open animation of the scene
	void Start()
	{
	        LeanTween.move(cameraobject, new Vector3(1, 10, 1) , 2.0f).setEase(LeanTweenType.easeOutQuad);
	}
}
