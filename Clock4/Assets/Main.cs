using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Domain;
using System;

public class Main : MonoBehaviour
{
	private float lastDrawnTime=-1;

	public GameObject CubePrefab;
	public GameObject BackgroundCubePrefab;

	private Clock clock;

	private int debug = 0;


	// Start is called before the first frame update
	void Start()
	{

		clock = new Clock(CubePrefab);

		var backgroundCube = Instantiate(BackgroundCubePrefab);
		backgroundCube.transform.position = new Vector3(0, 0, 2);

		Camera.main.transform.position -= new Vector3(0, 0, 10); //move camera backwards

		
	}

	
	void Update()
	{

		if (Time.time>lastDrawnTime+1f)
		{			
			int[] newNumbers = new int[8];
			var hours = DateTime.Now.ToString("HH");
			var minutes = DateTime.Now.ToString("mm");
			var seconds = DateTime.Now.ToString("ss");

			newNumbers[0] = int.Parse(hours.Substring(0, 1));
			newNumbers[1] = int.Parse(hours.Substring(1, 1));
			newNumbers[2] = -1; //colon
		
			newNumbers[3] = int.Parse(minutes.Substring(0, 1));
			newNumbers[4] = int.Parse(minutes.Substring(1, 1));
			newNumbers[5] = -1; //colon
			
			newNumbers[6] = int.Parse(seconds.Substring(0, 1));
			newNumbers[7] = int.Parse(seconds.Substring(1, 1));


			//debug 
			//if (debug == 0)
			//	debug = 1;
			//else
			//	debug = 0;
			//newNumbers[0] = 1;
			//newNumbers[1] = 6;
			//newNumbers[2] = -1;
			//newNumbers[3] = 2;
			//newNumbers[4] = 0;
			//newNumbers[5] = -1;
			//newNumbers[6] = 0;
			//newNumbers[7] = debug;






			clock.DrawTime(newNumbers);
			lastDrawnTime = Time.time;
		}

		clock.Update(); //updates clock animation
	}



	

	
}