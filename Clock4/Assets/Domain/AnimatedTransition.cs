using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Domain
{
	public class AnimatedTransition : Transition
	{

		private List<AnimatedCube> animatedCubes = new List<AnimatedCube>();

		private float journeyTime = .5f;
		private float startTime;

		public AnimatedTransition(List<GameObject> oldCubesInNumbers, List<GameObject> cubesInNumbers) : base(oldCubesInNumbers, cubesInNumbers)
		{
			startTime = Time.time;

			var midPoint = (oldCubesInNumbers.Count - 1) / 2;
			var firstPart = oldCubesInNumbers.GetRange(0, midPoint);
			var lastPart = oldCubesInNumbers.GetRange(midPoint, oldCubesInNumbers.Count - midPoint);
			oldCubesInNumbers = new List<GameObject>(lastPart.Concat(firstPart));

			for (int i = 0; i < cubesInNumbers.Count; i++)
			{
				var oldCubePos = oldCubesInNumbers[0].transform.position; //first cubes' pos 
				if (oldCubesInNumbers.Count >= i + 1)
					oldCubePos = oldCubesInNumbers[i].transform.position;

				var animatedCube =new AnimatedCube() {cube=cubesInNumbers[i], startPos=oldCubePos, endPos=cubesInNumbers[i].transform.position};
				animatedCube.cube.transform.position = animatedCube.startPos;
				animatedCubes.Add(animatedCube);
			}
			
			RecycleCubes(oldCubesInNumbers);
		}
		
		public override void Animate()
		{

			foreach (var animatedCube in animatedCubes)
			{
				animatedCube.cube.transform.position = Vector3.Slerp(animatedCube.startPos, animatedCube.endPos, (Time.time - startTime) / journeyTime);
				//animatedCube.cube.transform.Rotate(new Vector3(0, (Time.time - startTime) * 2, 0));
			}
			
		}


		internal class AnimatedCube
		{
			internal GameObject cube;
			internal Vector3 startPos;
			internal Vector3 endPos;

		}

	}
}
