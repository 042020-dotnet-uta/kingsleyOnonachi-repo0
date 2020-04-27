using System;
using System.Collections.Generic;
using System.Text;

namespace RPS_Game
{
	class Player
	{
		private string _Name;
		public int wins;
		public int losses;
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
		//To hold the hand of a playher
		private char hand;
		private string pHand;

		public char playerHandchar
		{
			get => hand;
			set => hand = value;
		}
		public string PlayerHand { get => pHand; set => pHand = value; }
	}
}