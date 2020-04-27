using System;
using System.Collections.Generic;
using System.Text;

namespace RPS_Game
{
    public class Player
    {
		private string _Name;
		public string Name
		{
			get {return _Name;}
			set { _Name = value; }
		}

		private int _wins;
		public int Wins
		{
			get { return _wins; }
			set { _wins = value; }
		}

		private int _losses;
		public int Losses
		{
			get { return _losses; }
			set { _losses = value; }
		}

		public Player() { }

		public Player(string name)
		{
			_Name = name;
		}




	}
}