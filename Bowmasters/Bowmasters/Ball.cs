using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

///ETML
///Auteur : Maël Naudet
///Date : 20.01.2025

namespace Bowmasters
{
    /// <summary>
    /// Balle que le joueur lance
    /// </summary>
    public class Ball
    {
        //Déclaraton des propriétés ***************************************
        private double _velocity;
        private double _angle;
        private readonly PositionByte _initialPosition;
        private PositionByte _actualPosition;


        public PositionByte InitialPosition
        {
            get
            {
                return _initialPosition;
            }
        }

        public PositionByte ActualPosition
        {
            get
            {
                return _actualPosition;
            }
            set
            {
                _actualPosition = value;
            }
        }

        //Déclaration des constructeurs ***********************************
        public Ball(double velocity, double angle, byte initialXPosition, byte initialYPosition)
        {
            this._velocity = velocity;
            this._angle = angle;
            _initialPosition = new PositionByte(initialXPosition, initialYPosition);
            ActualPosition = new PositionByte(initialXPosition, initialYPosition);
        }

        /// <summary>
        /// Update la position de la balle en fonction du temps
        /// </summary>
        /// <param name="time">temps</param>
        public void UpdateBallPosition(double time)
        {
            ActualPosition.X = Convert.ToByte(Balistic.MovementOnXAxis(initialX: InitialPosition.X, time: time, velocity: this._velocity, angle: this._angle));
            ActualPosition.Y = Convert.ToByte(Balistic.MovementOnYAxis(initialY: InitialPosition.Y, time: time, velocity: this._velocity, angle: this._angle));
        }

        /// <summary>
        /// Affiche la balle si elle est dans la console
        /// </summary>
        /// 
        public void DisplayBallInTime()
        {
            try
            {
                Console.SetCursorPosition(Convert.ToInt16(ActualPosition.X), Convert.ToInt16(ActualPosition.Y));
                Console.Write("X");
            }
            catch (System.ArgumentOutOfRangeException) { }          
        }

        /// <summary>
        /// Effacer la balle si elle est dans la console
        /// </summary>
        public void ErasePreviousBall()
        {
            try
            {
                Console.SetCursorPosition(Convert.ToInt16(ActualPosition.X), Convert.ToInt16(ActualPosition.Y));
                Console.Write(" ");
            }
            catch(System.ArgumentOutOfRangeException) { }           
        }
    }
}
