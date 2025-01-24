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
        private readonly PositionDouble _initialPosition;
        private PositionDouble _actualPosition;

        public PositionDouble InitialPosition
        {
            get
            {
                return _initialPosition;
            }
        }

        public PositionDouble ActualPosition
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
        public Ball(double velocity, double angle, double initialXPosition, double initialYPosition)
        {
            this._velocity = velocity;
            this._angle = angle;
            _initialPosition = new PositionDouble(initialXPosition, initialYPosition);
            ActualPosition = new PositionDouble(initialXPosition, initialYPosition);
        }

        /// <summary>
        /// Update la position de la balle en fonction du temps
        /// </summary>
        /// <param name="time">temps</param>
        public void UpdateBallPosition(double time)
        {
            ActualPosition.X = Balistic.MovementOnXAxis(initialX: InitialPosition.X, time: time, velocity: this._velocity, angle: this._angle);
            ActualPosition.Y = Balistic.MovementOnYAxis(initialY: InitialPosition.Y, time: time, velocity: this._velocity, angle: this._angle);
        }

        /// <summary>
        /// Affiche la balle si elle est dans la console
        /// </summary>
        /// 
        public void DisplayBallInTime()
        {
            try
            {
                Console.SetCursorPosition(Convert.ToInt16(Math.Round(ActualPosition.X)), Convert.ToInt16(Math.Round(ActualPosition.Y)));
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
                Console.SetCursorPosition(Convert.ToInt16(Math.Round(ActualPosition.X)), Convert.ToInt16(Math.Round(ActualPosition.Y)));
                Console.Write(" ");
            }
            catch(System.ArgumentOutOfRangeException) { }           
        }
    }
}
