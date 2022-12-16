using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_start : MonoBehaviour
{
	public	GameObject	cameraobject;

	public void loadlevel(string level)
	{
		LeanTween.move(cameraobject, new Vector3(20, 0, 20) , 2.0f).setEase(LeanTweenType.easeOutQuad);
	}
	// Start is called before the first frame update
	void Start()
	{
	    
	}
	
	// Update is called once per frame
	void Update()
	{
		if (cameraobject.transform.position.y == 0)
			SceneManager.LoadScene("MazeGenerator");
	}
}
