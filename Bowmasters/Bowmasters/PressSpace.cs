using System;
using System.Threading;

///ETML
///Auteur : Maël Naudet
///Date : 31.01.2025

namespace Bowmasters
{
    /// <summary>
    /// Affiche une bar de progression et quand on appuie sur espace, retourne le temps d'attente avant la pression (max 5 secondes)
    /// </summary>
    internal class PressSpace
    {
        /// <summary>
        /// Propriétés
        /// </summary>
        private PositionByte position ;
        public PositionByte Position
        {
            get { return position; }
            set { position = value; }
        }

        private  readonly float maxHoldTime;    //temps max possible de pression
        private float holdTime;                 //temps de pression 

        /// <summary>
        /// Constructeur qui demande une position et un temps max de pression
        /// </summary>
        /// <param name="xPosition">position x</param>
        /// <param name="yPosition">position y</param>
        /// <param name="maxHoldTime">temps max de pression</param>
        public PressSpace(byte xPosition, byte yPosition, float maxHoldTime)
        {
            Position = new PositionByte(xPosition, yPosition);
            this.maxHoldTime = maxHoldTime;
            holdTime = 0;
        }

        /// <summary>
        /// Affiche le début de la bar de progression
        /// </summary>
        private void DisplayStartBar()
        {
            Console.SetCursorPosition(Position.X + ((int)holdTime % 5) - 1, Position.Y);
            Console.Write("[");
        }

        /// <summary>
        /// Affiche la progression de la bar
        /// </summary>
        private void DisplayBar()
        {
            // on se positionne en fonction du temps passé
            Console.SetCursorPosition(Position.X + (int)holdTime * 2, Position.Y);
            Console.Write("■");
        }

        /// <summary>
        /// Affiche la fin de la bar de progression
        /// </summary>
        private void DisplayEndBar()
        {
            // on se positionne en fonction du temps max
            Console.SetCursorPosition(Position.X + (int) maxHoldTime * 2 + 1, Position.Y);
            Console.Write("]");
        }

        /// <summary>
        /// Efface la bar en entier
        /// </summary>
        public void EraseBar()
        {
            for(int i = 0; i < (int)maxHoldTime * 2 + 3; i++) 
            {
                Console.SetCursorPosition(Position.X - 1 + i, Position.Y);
                Console.Write(" ");
            }
            
        }

        /// <summary>
        /// Démarre le processus de chargement de la vitesse de la balle,
        /// Affiche une barre de progression qui augmente en fonction du temps d'attente,
        /// jusqu'à ce que l'utilisateur appuie sur espace.
        /// </summary>
        /// <returns> le temps tenu </returns>
        public float Start()
        {
            // temps au début
            DateTime startTime = DateTime.Now;
            // pour savoir quand l'utilisateur appuie
            bool notPressed = false;

            // affiche le début et la fin de la bar de progression
            DisplayStartBar();
            DisplayEndBar();

            // tant que l'utilisateur n'appuie pas
            while(!notPressed)
            {
                // s'il appuie sur espace
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                    //on sort
                    notPressed = true;
                }
                // sinon
                else
                {
                    // Calcul du temps écoulé depuis le début
                    holdTime = (float)(DateTime.Now - startTime).TotalSeconds;
                    holdTime = Math.Min(holdTime, maxHoldTime); // Limite à maxHoldTime

                    // Affichage de la barre de progression
                    DisplayBar();                  
                }
                // petit temps d'attente
                Thread.Sleep(50);
            }
            // retourne le temps 
            return holdTime;
        }
    }
}
