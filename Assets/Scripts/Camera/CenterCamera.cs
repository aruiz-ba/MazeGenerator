using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Centers the camera and calculates the apropiate distance to the maze
public class CenterCamera : MonoBehaviour
{
	public	InputField	height_inp;
	public	InputField	width_inp;
	public	GameObject	cameraobject;
	int			space;

	public	void center_camera()
	{
		if (int.TryParse(width_inp.text, out int out_width) 
			&& int.TryParse(height_inp.text, out int out_height)
			&& out_width > 0 && out_height > 0 && out_width < 150 && out_height < 150) //protect from reading non valid values
		{
			if (out_width > 70)
				space = 70;
			else if (out_width > 50)
				space = 40;
			else if (out_width > 20)
				space = 20;
			else
				space = 10;
			out_height *= 2;
			out_width *= 2;
			float camera_distance = (out_width/2) / (Mathf.Sqrt(3) / 3); //calculating distance using trigonometry
			//out_width/2 to get the half of the board. 
			//It has a -1 to correct 0,0 starting from the center of the cells
			LeanTween.move(cameraobject, new Vector3((float)((out_width/2) - 1), camera_distance + space, (float)((out_height/2) - 1)), 3.0f).setEase(LeanTweenType.easeOutQuad);
		}
	}
}
