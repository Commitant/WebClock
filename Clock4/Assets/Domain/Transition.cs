using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Domain
{
	public class Transition
	{		
		internal List<GameObject> oldCubesInNumbers, cubesInNumbers;

		public Transition(List<GameObject> oldCubesInNumbers, List<GameObject> cubesInNumbers)
		{
			this.oldCubesInNumbers = oldCubesInNumbers;
			this.cubesInNumbers = cubesInNumbers;

		}

		public virtual void Animate()
		{
			//simple no-animation, removes old cubes only
			if (oldCubesInNumbers != null)
			{
				RecycleCubes(oldCubesInNumbers);
				oldCubesInNumbers = null;
			}
		}

		internal void RecycleCubes(List<GameObject> cubes)
		{


			foreach (GameObject cube in cubes)
			{

				UnityEngine.Object.Destroy(cube);
			}
		}
	}
}
