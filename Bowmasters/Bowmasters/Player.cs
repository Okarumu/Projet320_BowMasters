using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


		private string[] playerModel =		//modèle du joueur
		{
			@"  o  ",
			@" /░\ ",
			@" / \ ",
		};



        //Constructeurs du joueur **************************************************************

        /// <summary>
        /// Constructeur normal avec un nombre de vie personnalisé
        /// </summary>
        /// <param name="life">Nombre de vies</param>
        /// <param name="xPosition">Position x du joueur</param>
		/// <param name="yPosition">Position y du joueur</param>
        public Player(byte life, byte xPosition, byte yPosition)
		{
			this.Life = life;
			this._position = new PositionByte(xPosition, yPosition);
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
			//boucle pour parcourir les strings
			for(byte i = 0; i < playerModel.Length; i++)
			{
				//endroit ou le string doit etre placé
				Console.SetCursorPosition(Position.X, Position.Y);
				Console.Write(playerModel[i]);
				//on descend de 1
				Position.Y++;
			}

			//on remet la position Y du joueur à celle de base
			Position.Y = Convert.ToByte(Position.Y - playerModel.Length);
		}

		/// <summary>
		/// le joueur perd de la vie en fonction du nombre de dégat infligé
		/// </summary>
		/// <param name="damage">nombre de dégat infligé</param>
		public void TakeDamage(byte damage)
		{
			Life -= damage;
		}
	}
}
