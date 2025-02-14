﻿using System;
using System.Linq;

///ETML
///Auteur : Maël Naudet
///Date : 17.01.2025

namespace Bowmasters
{
	/// <summary>
	/// Joueur qui sera afficher avec un nombre de vies pouvant se prendre des dégats.
	/// </summary>
    public class Player
    {
		//Déclaration des propriétés **********************************************************

		private byte _life;					//vie du joueur
		public byte Life
		{
			get { return _life; }
			set { _life = value; }
		}

		private readonly PositionByte _position;

		public PositionByte Position
		{
			get
			{
				return _position;
			}
		}


		private string[] _playerModel =		//modèle du joueur
		{
			@"  o  ",
			@" /░\ ",
			@" / \ ",
		};

		private readonly Hitbox _hitbox;

		public Hitbox Hitbox
		{
			get
			{
				return _hitbox;
			}
		}

		private readonly byte playerNumber;

		private readonly ConsoleColor _color;
		public ConsoleColor Color
		{
			get
			{
				return _color;
			}
		}

		private int _score;
		public int Score
		{
			get
			{
				return _score;
			}
			set
			{
				_score = value;
			}
		}


        //Constructeurs du joueur **************************************************************

        /// <summary>
        /// Constructeur normal avec un nombre de vie personnalisé
        /// </summary>
        /// <param name="life">Nombre de vies</param>
        /// <param name="xPosition">Position x du joueur</param>
		/// <param name="yPosition">Position y du joueur</param>
        public Player(byte life, byte xPosition, byte yPosition, ConsoleColor color, byte playernumber)
		{
			this.Life = life;
			this._position = new PositionByte(xPosition, yPosition);
			this._color = color;
			this.playerNumber = playernumber;
			this._hitbox = new Hitbox((byte)_playerModel[0].Length, (byte)_playerModel.Count());
		}

		/// <summary>
		/// Constructeur par défaut avec uniquement 3 vies
		/// </summary>
		public Player()
		{
			this._life = 3;
		}

		//Méthodes du joueur ********************************************************************

		/// <summary>
		/// affiche le joueur à un endroit dans la carte
		/// </summary>
		public void Display()
		{
			Console.ForegroundColor = this._color;

			//boucle pour parcourir les strings
			for(byte i = 0; i < _playerModel.Length; i++)
			{
				//endroit ou le string doit etre placé
				Console.SetCursorPosition(Position.X, Position.Y);
				Console.Write(_playerModel[i]);
				//on descend de 1
				Position.Y++;
			}

			//on remet la position Y du joueur à celle de base
			Position.Y = Convert.ToByte(Position.Y - _playerModel.Length);

			Console.ForegroundColor = ConsoleColor.White;
		}

		/// <summary>
		/// le joueur perd de la vie en fonction du nombre de dégat infligé
		/// </summary>
		/// <param name="damage">nombre de dégat infligé</param>
		public void TakeDamage(byte damage)
		{
			Life -= damage;
		}

		public void DisplayInfo()
		{
			EraseInfo();
			Console.ForegroundColor = this._color;
			Console.SetCursorPosition(Position.X - 5, Position.Y - 30);
			Console.Write("╔═════════════════════╗");
            Console.SetCursorPosition(Position.X - 5, Position.Y - 29);
			Console.Write($"║  Joueur {playerNumber}           ║");
            Console.SetCursorPosition(Position.X - 5, Position.Y - 28);
			Console.Write($"║  Score :            ║");
            Console.SetCursorPosition(Position.X - 5, Position.Y - 27);
			Console.Write("╚═════════════════════╝");

            Console.SetCursorPosition(Position.X - 5, Position.Y - 26);
			Console.Write("[                     ]");

            DisplayLife();
			DisplayScore();

			Console.ForegroundColor = ConsoleColor.White;
        }

		private void DisplayLife()
		{
			Console.SetCursorPosition(Position.X + 12, Position.Y - 29);
            for(byte i = 0; i < Life; i++)
			{
                Console.Write("♥");
            }
        }

		private void DisplayScore()
		{
            Console.SetCursorPosition(Position.X + 12, Position.Y - 28);
			Console.Write(Score);
        }

		private void EraseInfo()
		{
            Console.SetCursorPosition(Position.X - 5, Position.Y - 30);
            Console.Write("                       ");
            Console.SetCursorPosition(Position.X - 5, Position.Y - 29);
            Console.Write("                       ");
            Console.SetCursorPosition(Position.X - 5, Position.Y - 28);
            Console.Write("                       ");
            Console.SetCursorPosition(Position.X - 5, Position.Y - 27);
            Console.Write("                       ");
            Console.SetCursorPosition(Position.X - 5, Position.Y - 26);
            Console.Write("                       ");
        }
    }
}
