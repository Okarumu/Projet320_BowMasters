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
        // Déclaration et initialisation des constantes *******************************

        /// <summary>
        /// ajustement x du tableau d'informations
        /// </summary>
        private const byte _X_DIFFERENCE_INFORMATION_TAB = 5;

        /// <summary>
        ///  ajustement y du tableau d'informations
        /// </summary>
        private const byte _Y_DIFFERENCE_INFORMATION_TAB = 30;

        /// <summary>
		/// ajustement x du nombre de vie
		/// </summary>
        private const byte _X_DIFFERENCE_LIFE_TAB = 12;

        /// <summary>
		/// ajustement y du nombre de vie
		/// </summary>
        private const byte _Y_DIFFERENCE_LIFE_TAB = 29;

        /// <summary>
		/// ajustement x du score
		/// </summary>
        private const byte _X_DIFFERENCE_SCORE_TAB = 12;

        /// <summary>
		/// ajustement y du score
		/// </summary>
        private const byte _Y_DIFFERENCE_SCORE_TAB = 28;

        /// <summary>
		/// modèle du joueur
		/// </summary>
        private string[] _PLAYER_MODEL =						
		{
            @"  o  ",
            @" /░\ ",
            @" / \ ",
        };

		private string[] _PLAYER_MODEL_DOWN =
		{
			@" |  /",
			@"o--- ",
		};


        // Déclaration des attributs **************************************************

        /// <summary>
		/// numéro de joueur en lecture seule
		/// </summary>
        private readonly byte _playerNumber;

        /// <summary>
		/// position du joueur en lecture seule
		/// </summary>
        private readonly PositionByte _position;

        /// <summary>
		/// hitbox du joueur	en lecture seule
		/// </summary>
        private readonly Hitbox _hitbox;

        /// <summary>
		/// couleur du joueur en lecture seule
		/// </summary>
        private readonly ConsoleColor _color;

        /// <summary>
		/// affiche les informations des joueurs
		/// </summary>
        private readonly string[] _infos;

        /// <summary>
		/// vie du joueur
		/// </summary>
        private byte _life;

        /// <summary>
		/// score du joueur
		/// </summary>
        private int _score;


        // Déclaration des propriétés **************************************************

        /// <summary>
		/// Obtient la position du joueur
		/// </summary>
        public PositionByte Position		
		{
			get
			{
				return _position;
			}
		}

        /// <summary>
		/// Obtient la hitbox du joueur
		/// </summary>
        public Hitbox Hitbox				
		{
			get
			{
				return _hitbox;
			}
		}

        /// <summary>
		/// Obtient la couleur du joueur
		/// </summary>
        public ConsoleColor Color			
		{
			get
			{
				return _color;
			}
		}

        /// <summary>
		/// Obtient le nombre de point de vie du joueur
		/// </summary>
        public byte Life					
        {
            get 
			{ 
				return _life; 
			}
        }

        /// <summary>
		/// Obtient le score du joueur et permet de le modifier
		/// </summary>
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


        // Déclaration du constructeur ***********************************************************

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
			this._hitbox = new Hitbox((byte)_PLAYER_MODEL[0].Length, (byte)_PLAYER_MODEL.Count(), xPosition, yPosition);

			// initialise les informations du joueur + la barre de progression
			_infos = new string[]{
                "╔═════════════════════╗",
				$"║  Joueur {_playerNumber}           ║",
				"║  Score :            ║",
				"╚═════════════════════╝",
                "[                     ]"
            };
		}


		// Déclaration et implémentation des méthodes du joueur ***********************************

		/// <summary>
		/// affiche le joueur à un endroit dans la carte
		/// </summary>
		public void DisplayStanding()
		{
			Console.ForegroundColor = this._color;

			//boucle pour parcourir les strings
			for(byte i = 0; i < _PLAYER_MODEL.Length; i++)
			{
				//endroit ou le string doit etre placé
				Console.SetCursorPosition(Position.X, Position.Y);
				Console.Write(_PLAYER_MODEL[i]);
				//on descend de 1
				Position.Y++;
			}

			//on remet la position Y du joueur à celle de base
			Position.Y = Convert.ToByte(Position.Y - _PLAYER_MODEL.Length);

			Console.ForegroundColor = ConsoleColor.White;
		}

		/// <summary>
		/// Affiche le modèle du joueur à terre
		/// </summary>
		public void DisplayLying()
		{
			// Efface d'abord le modèle du joueur de base
			ErasePlayer();
            Console.ForegroundColor = this._color;

            //boucle pour parcourir les strings
            for (byte i = 0; i < _PLAYER_MODEL_DOWN.Length; i++)
            {
                //endroit ou le string doit etre placé
                Console.SetCursorPosition(Position.X, Position.Y + 1);
                Console.Write(_PLAYER_MODEL_DOWN[i]);
                //on descend de 1
                Position.Y++;
            }

            //on remet la position Y du joueur à celle de base
            Position.Y = Convert.ToByte(Position.Y - _PLAYER_MODEL_DOWN.Length);

            Console.ForegroundColor = ConsoleColor.White;
        }

		/// <summary>
		/// Efface le modèle du joueur debout
		/// </summary>
		public void ErasePlayer()
		{
            Console.ForegroundColor = this._color;

            //boucle pour parcourir les strings
            for (byte i = 0; i < _PLAYER_MODEL.Length; i++)
            {
                //endroit ou le string doit etre placé
                Console.SetCursorPosition(Position.X, Position.Y);
                Console.Write("     ");
                //on descend de 1
                Position.Y++;
            }

            //on remet la position Y du joueur à celle de base
            Position.Y = Convert.ToByte(Position.Y - _PLAYER_MODEL.Length);

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
			for(int i = 0; i < _infos.Length; i++)
			{
				Console.SetCursorPosition(Position.X - _X_DIFFERENCE_INFORMATION_TAB, Position.Y - _Y_DIFFERENCE_INFORMATION_TAB + i);
				Console.Write(_infos[i]);				
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
			Console.SetCursorPosition(Position.X + _X_DIFFERENCE_LIFE_TAB, Position.Y - _Y_DIFFERENCE_LIFE_TAB);
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
            Console.SetCursorPosition(Position.X + _X_DIFFERENCE_SCORE_TAB, Position.Y - _Y_DIFFERENCE_SCORE_TAB);
			Console.Write(Score);
        }

		/// <summary>
		/// Efface toutes les informations
		/// </summary>
		private void EraseInfo()
		{
			for(int i = 0; i < _infos.Length;i++)
			{
				Console.SetCursorPosition(Position.X - _X_DIFFERENCE_INFORMATION_TAB, Position.Y - _Y_DIFFERENCE_INFORMATION_TAB + i);
				Console.Write("                       ");
			}
        }
    }
}
