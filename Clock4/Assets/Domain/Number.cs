using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Domain
{
	public class Number
	{

		public int No { get; set; }

		private int currentLine = 4; // top, line 5, 4-0 


		public List<Position> Blocks = new List<Position>();


		public void Addline(int pos1, int pos2, int pos3)
		{
			if (pos1==1) SetBlock(0, currentLine);
			if (pos2==1) SetBlock(1, currentLine);
			if (pos3==1) SetBlock(2, currentLine);

			currentLine--;
		}

		public Number(params string[] strings)
		{
			foreach (string str in strings)
			{
				var parts = str.Split(',');
				SetBlock(int.Parse(parts[0]), int.Parse(parts[1]));
			}
		}
		public void SetBlock(int x, int y)
		{
			Blocks.Add(new Position { x = x, y = y });
		}


		public class Position
		{
			public int  x { get; set; }
			public int  y { get; set; }

		}

	}

}
