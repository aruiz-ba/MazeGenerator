using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class error_message : MonoBehaviour
{
	public void	error_message()
	{
	Text tempTextBox = Instantiate(textPrefab, nextPosition, transform.rotation) as Text;
	//Parent to the panel
	tempTextBox.transform.SetParent(renderCanvas.transform, false);
	//Set the text box's text element font size and style:
	tempTextBox.fontSize = defaultFontSize;
	//Set the text box's text element to the current textToDisplay:
	tempTextBox.text = "Error: you need to add valid values";
	}
}
