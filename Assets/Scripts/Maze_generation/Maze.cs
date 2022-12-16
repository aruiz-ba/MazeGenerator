using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maze : MonoBehaviour
{
	public	GameObject	Floor;
	public	GameObject	wall_vertical;
	public	GameObject	wall_horizontal;
	public	wall_grid[,]	wall;
	public	GameObject[,]	floor_grid;
	public	int		height = 2;
	public	int		width = 2;
	public	InputField	height_inp;
	public	InputField	width_inp;


	public void regen_button() //regenerate maze button
	{
		//Proteccting the input from text, unvalid values or values that are too big.
		if (int.TryParse(width_inp.text, out int out_width) 
				&& int.TryParse(height_inp.text, out int out_height)
				&& out_width > 0 && out_height > 0 && out_width < 150 && out_height < 150)
		{
			for(int h = 0; h < height; h++)	//Loop for Destroying all the objects
			{
				for(int w = 0; w < width; w++)
				{	
					Destroy(wall[w, h].left);
					Destroy(wall[w, h].bottom);
					Destroy(wall[w, h].right);
					Destroy(wall[w, h].top);
					Destroy(floor_grid[w,h]);
				}
			}
			height = out_height; //set the new values from the input
			width = out_width;
			generate_grid();
			recursion(0, 0);
		}
		else
			Debug.Log("Error: you need to add valid values");
	}

	int	size_posible_paths(int x, int y)
	{
		int	size = 0;

		if (y < (height - 1) && wall[x, y + 1].state == false) //top
			size++;
		if (y > 0 && wall[x, y - 1].state == false) //down
			size++;
		if (x < (width - 1) && wall[x + 1, y].state == false) //right
			size++;
		if (x > 0 && wall[x - 1, y].state == false) //left
			size++;
		return (size);
	}

	//Creates an array with the posible directions to move from the current cell
	//Posible cells would be those within the limits of the maze grid that havent been visited
	int[] 	all_posible_paths(int x, int y) 
	{
		int	i = 0;
		int[] posible = new int[size_posible_paths(x, y)];
		if (y < (height - 1) && wall[x, y + 1].state == false) //top
			posible[i++] = 1;
		if (y > 0 && wall[x, y - 1].state == false) //down
			posible[i++] = 2;
		if (x < (width - 1) && wall[x + 1, y].state == false) //right
			posible[i++] = 3;
		if (x > 0 && wall[x - 1, y].state == false) //left
			posible[i++] = 4;
		return (posible);
	}

	int	recursion(int x, int y)
	{
		wall[x, y].state = true;
		while (size_posible_paths(x, y) != 0)
		{
			int[] posible = all_posible_paths(x,y);		//gives me an array with the posible paths to take on this cell
			int i = Random.Range(0, size_posible_paths(x, y));	//choose a random number between 0 and the size of previous array
			int n = posible[i];			//gives me random posible direction to go with 1-2-3-4 representing each direction
			if (n == 1) //top
			{
				Destroy(wall[x, y].top);	//I destroy the wall conecting to the cell im going
				Destroy(wall[x, y + 1].bottom);	// I destroy the wall of the new cell from where I came
				recursion(x, y + 1);
			}
			if (n == 2) //down
			{
				Destroy(wall[x, y].bottom);
				Destroy(wall[x, y - 1].top);
				recursion(x, y - 1);
			}
			if (n == 3) //right
			{
				Destroy(wall[x, y].right);
				Destroy(wall[x + 1, y].left);
				recursion(x + 1, y);
			}
			if (n == 4) //left
			{
				Destroy(wall[x, y].left);
				Destroy(wall[x - 1, y].right);
				recursion(x - 1, y);
			}
		}
		//when the loop breaks having no more posibilities to move it returns to the previous cell
		return (0);
	}

	public void generate_grid()
	{
		wall = new wall_grid[width, height];
		floor_grid = new GameObject[width, height];
		for (int h = 0; h < height; h++)
		{
			for (int w = 0; w < width; w++) 
			{
				//Create 4 walls for each cell of the maze and save them in an array with the cell coordinates
				GameObject floor = Instantiate(Floor, new Vector3(w * 2, 0, h * 2), Quaternion.identity); //Create floor_cells
				floor.name = "Floor_cell[" + w + "," + h + "]"; //name the object
				GameObject left = Instantiate(wall_vertical, new Vector3((w * 2) - 0.9f , 1.25f, h * 2), Quaternion.identity);
				left.name = "Left_wall[" + w + "," + h + "]"; 
				GameObject bottom = Instantiate(wall_horizontal, new Vector3(w * 2 , 1.25f, (h * 2) - 0.9f ), Quaternion.identity);
				bottom.name = "Bottom_wall[" + w + "," + h + "]"; 
				GameObject right = Instantiate(wall_vertical, new Vector3(((w + 1) * 2) - 0.9f , 1.25f, h * 2), Quaternion.identity);
				right.name = "Right_wall[" + w + "," + h + "]"; 
				GameObject top = Instantiate(wall_horizontal, new Vector3(w * 2 , 1.25f, ((h + 1) * 2) - 0.9f ), Quaternion.identity);
				top.name = "top_wall[" + w + "," + h + "]"; 
				wall[w, h] = new wall_grid();
				wall[w, h].left = left;
				wall[w, h].bottom = bottom;
				wall[w, h].right = right;
				wall[w, h].top = top;
				floor_grid[w, h] = floor;
			}
		}
	}

	// Before the first frame update we stablish the base of our maze
	void Start()
	{
		generate_grid(); //generate grid with 2x2 size by default
		recursion(0, 0); //call the backtracking recursive algorithm
	}
}
