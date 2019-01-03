using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Domain
{
	public class Clock
	{
		public GameObject CubePrefab { get; set; }

		private Dictionary<int, Number> numbers = InitNumbers();

		private List<GameObject>[] cubesInNumbers = new List<GameObject>[8]; //array of lists
		private int[] currentNumbers = new int[8];

		private float xOffset = -3.8f * 4;
		private float dist = 4f;

		private List<Transition> currentTransitions = new List<Transition>();
		

		public Clock(GameObject cubePrefab)
		{
			//init
			CubePrefab = cubePrefab;

		

			for (int i = 0; i < currentNumbers.Length; i++)
			{
				currentNumbers[i] = 0;
				cubesInNumbers[i] = CreateNumberBlocks(numbers[currentNumbers[i]], xOffset + dist * i, 0);
			}

		}

		public void DrawTime(int[] newNumbers)
		{
			currentTransitions.Clear();

			for (int i = 0; i < currentNumbers.Length; i++)
			{
				if (newNumbers[i] != currentNumbers[i])
				{
					var oldCubesInNumbers = cubesInNumbers[i];
					cubesInNumbers[i] = CreateNumberBlocks(numbers[newNumbers[i]], xOffset + dist * i, 0);
					currentTransitions.Add(new AnimatedTransition(oldCubesInNumbers, cubesInNumbers[i]));
					currentNumbers[i] = newNumbers[i];
				}
			}

			
		}

		public void Update()
		{
			foreach (var currentTransition in currentTransitions)
				currentTransition.Animate();

		}




		private List<GameObject> CreateNumberBlocks(Number number, float xOffset, float yOffset)
		{

			var cubesInNumber = new List<GameObject>();
			float padding = .1f;


			foreach (var block in number.Blocks)
			{
				var cube = GetCube();

				var currentXOffset = xOffset + (float)block.x * padding;
				var currentYOffset = yOffset + (float)block.y * padding;
				cube.transform.position = new Vector3((float)block.x + currentXOffset, (float)block.y + currentYOffset);

				cubesInNumber.Add(cube);
			}

			return cubesInNumber;
		}




		private GameObject GetCube()
		{
			var cube = UnityEngine.Object.Instantiate(CubePrefab);
			return cube;


		}

		private void RecycleCubes(List<GameObject> cubes)
		{


			foreach (GameObject cube in cubes)
			{
				
				UnityEngine.Object.Destroy(cube);
			}
		}



		private static Dictionary<int, Number> InitNumbers()
		{
			Dictionary<int, Number> numbers = new Dictionary<int, Number>();


			//0
			Number number = new Number();
			number.Addline(1, 1, 1);
			number.Addline(1, 0, 1);
			number.Addline(1, 0, 1);
			number.Addline(1, 0, 1);
			number.Addline(1, 1, 1);
			numbers.Add(0, number);


			//1
			number = new Number();
			number.Addline(0, 1, 0);
			number.Addline(0, 1, 0);
			number.Addline(0, 1, 0);
			number.Addline(0, 1, 0);
			number.Addline(0, 1, 0);
			numbers.Add(1, number);


			//2
			number = new Number();
			number.Addline(1, 1, 1);
			number.Addline(0, 0, 1);
			number.Addline(1, 1, 1);
			number.Addline(1, 0, 0);
			number.Addline(1, 1, 1);
			numbers.Add(2, number);

			//3
			number = new Number();
			number.Addline(1, 1, 1);
			number.Addline(0, 0, 1);
			number.Addline(1, 1, 1);
			number.Addline(0, 0, 1);
			number.Addline(1, 1, 1);
			numbers.Add(3, number);

			//4
			number = new Number();
			number.Addline(1, 0, 1);
			number.Addline(1, 0, 1);
			number.Addline(1, 1, 1);
			number.Addline(0, 0, 1);
			number.Addline(0, 0, 1);
			numbers.Add(4, number);

			//5
			number = new Number();
			number.Addline(1, 1, 1);
			number.Addline(1, 0, 0);
			number.Addline(1, 1, 1);
			number.Addline(0, 0, 1);
			number.Addline(1, 1, 1);
			numbers.Add(5, number);

			//6
			number = new Number();
			number.Addline(1, 1, 1);
			number.Addline(1, 0, 0);
			number.Addline(1, 1, 1);
			number.Addline(1, 0, 1);
			number.Addline(1, 1, 1);
			numbers.Add(6, number);

			//7
			number = new Number();
			number.Addline(1, 1, 1);
			number.Addline(0, 0, 1);
			number.Addline(0, 0, 1);
			number.Addline(0, 0, 1);
			number.Addline(0, 0, 1);
			numbers.Add(7, number);

			//8
			number = new Number();
			number.Addline(1, 1, 1);
			number.Addline(1, 0, 1);
			number.Addline(1, 1, 1);
			number.Addline(1, 0, 1);
			number.Addline(1, 1, 1);
			numbers.Add(8, number);

			//9
			number = new Number();
			number.Addline(1, 1, 1);
			number.Addline(1, 0, 1);
			number.Addline(1, 1, 1);
			number.Addline(0, 0, 1);
			number.Addline(1, 1, 1);
			numbers.Add(9, number);

			//: colon
			number = new Number();
			number.Addline(0, 0, 0);
			number.Addline(0, 1, 0);
			number.Addline(0, 0, 0);
			number.Addline(0, 1, 0);
			number.Addline(0, 0, 0);
			numbers.Add(-1, number);

			return numbers;
		}
	}


}
