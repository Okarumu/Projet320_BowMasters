///*******************************************************
/// ETML
/// Auteur : Maël Naudet
/// Date : 17.01.2025
///*******************************************************

using System;
using System.Linq;

namespace Bowmasters
{
	/// <summary>
	/// Joueur qui sera afficher avec un nombre de vies, un score et pouvant se prendre des dégats
	/// </summary>
    public class Player
    {
		// Déclaration des constantes *********************************************************
		private const byte X_DIFFERENCE_INFORMATION_TAB = 5;	// ajustement x du tableau d'informations
		private const byte Y_DIFFERENCE_INFORMATION_TAB = 30;   // ajustement y du tableau d'informations
        private const byte X_DIFFERENCE_LIFE_TAB = 12;          // ajustement x du nombre de vie
        private const byte Y_DIFFERENCE_LIFE_TAB = 29;          // ajustement y du nombre de vie
        private const byte X_DIFFERENCE_SCORE_TAB = 12;         // ajustement x du score
        private const byte Y_DIFFERENCE_SCORE_TAB = 28;			// ajustement y du score

        // Déclaration des attributs **********************************************************
        private readonly byte _playerNumber;        // numéro de joueur en lecture seule
        private readonly PositionByte _position;    // position du joueur en lecture seule
        private readonly Hitbox _hitbox;			// hitbox du joueur	en lecture seule
        private readonly ConsoleColor _color;       // couleur du joueur en lecture seule
        private readonly string[] infos;			// affiche les informations des joueurs
        private byte _life;                         // vie du joueur
        private int _score;                         // score du joueur
        private string[] _playerModel =				// modèle du joueur
		{
            @"  o  ",
            @" /░\ ",
            @" / \ ",
        };

        // Déclaration des propriétés *********************************************************
        public PositionByte Position		// Obtient la position du joueur
		{
			get
			{
				return _position;
			}
		}
		

		public Hitbox Hitbox				// Obtient la hitbox du joueur
		{
			get
			{
				return _hitbox;
			}
		}
		
		public ConsoleColor Color			// Obtient la couleur du joueur
		{
			get
			{
				return _color;
			}
		}
        public byte Life					// Obtient le nombre de point de vie du joueur
        {
            get 
			{ 
				return _life; 
			}
        }

        public int Score					// Obtient le score du joueur et permet de le modifier
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
			this._life = life;
			this._position = new PositionByte(xPosition, yPosition);
			this._color = color;
			this._playerNumber = playernumber;
			this._hitbox = new Hitbox((byte)_playerModel[0].Length, (byte)_playerModel.Count(), xPosition, yPosition);

			// initialise les informations du joueur + la barre de progression
			infos = new string[]{
                "╔═════════════════════╗",
				$"║  Joueur {_playerNumber}           ║",
				"║  Score :            ║",
				"╚═════════════════════╝",
                "[                     ]"
            };
		}

		// Méthodes du joueur ********************************************************************

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
			_life -= damage;
		}

		/// <summary>
		/// Efface les informations du joueurs et la barre de lancer et les réaffiche 
		/// </summary>
		public void DisplayInfo()
		{
			// Efface les informations du joueur pour les réecrire
			EraseInfo();
			// Remet la bonne couleur
			Console.ForegroundColor = this.Color;

			// Tableau des informations, se positionne juste au dessus du joueur
			for(int i = 0; i < infos.Length; i++)
			{
				Console.SetCursorPosition(Position.X - X_DIFFERENCE_INFORMATION_TAB, Position.Y - Y_DIFFERENCE_INFORMATION_TAB + i);
				Console.Write(infos[i]);				
			}

			// Affiche les informations nécessaires
            DisplayLife();
			DisplayScore();

			// Remet la couleur en blanc au cas où
			Console.ForegroundColor = ConsoleColor.White;
        }

		/// <summary>
		/// Affiche le nombre de point de vie sous forme de coeur
		/// </summary>
		private void DisplayLife()
		{
			Console.SetCursorPosition(Position.X + X_DIFFERENCE_LIFE_TAB, Position.Y - Y_DIFFERENCE_LIFE_TAB);
            for(byte i = 0; i < Life; i++)
			{
                Console.Write("♥");
            }
        }

		/// <summary>
		/// Affiche le score du joueur
		/// </summary>
		private void DisplayScore()
		{
            Console.SetCursorPosition(Position.X + X_DIFFERENCE_SCORE_TAB, Position.Y - Y_DIFFERENCE_SCORE_TAB);
			Console.Write(Score);
        }

		/// <summary>
		/// Efface toutes les informations
		/// </summary>
		private void EraseInfo()
		{
			for(int i = 0; i < infos.Length;i++)
			{
				Console.SetCursorPosition(Position.X - X_DIFFERENCE_INFORMATION_TAB, Position.Y - Y_DIFFERENCE_INFORMATION_TAB + i);
				Console.Write("                       ");
			}
        }
    }
}
