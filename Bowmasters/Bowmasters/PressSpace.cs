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

        private readonly ConsoleColor _color;

        private  readonly float maxHoldTime;    //temps max possible de pression
        private float holdTime;                 //temps de pression 

        /// <summary>
        /// Constructeur qui demande une position et un temps max de pression
        /// </summary>
        /// <param name="xPosition">position x</param>
        /// <param name="yPosition">position y</param>
        /// <param name="maxHoldTime">temps max de pression</param>
        public PressSpace(Player player, float maxHoldTime, ConsoleColor color)
        {
            Position = new PositionByte(player.Position.X, player.Position.Y);
            this.maxHoldTime = maxHoldTime;
            holdTime = 0;
            this._color = color;
        }

        /// <summary>
        /// Affiche le début de la bar de progression
        /// </summary>
        private void DisplayStartBar()
        {
            Console.ForegroundColor = _color;
            Console.SetCursorPosition(Position.X - 5, Position.Y - 26);
            Console.Write("[");
        }

        /// <summary>
        /// Affiche la progression de la bar
        /// </summary>
        private void DisplayBar()
        {
            Console.ForegroundColor = _color;
            // on se positionne en fonction du temps passé
            Console.SetCursorPosition(Position.X - 4 + (int)(holdTime / maxHoldTime * 20), Position.Y - 26);
            Console.Write("■");
        }

        /// <summary>
        /// Affiche la fin de la bar de progression
        /// </summary>
        private void DisplayEndBar()
        {
            Console.ForegroundColor = _color;
            // on se positionne en fonction du temps max
            Console.SetCursorPosition(Position.X + 17, Position.Y - 26);
            Console.Write("]");
        }

        /// <summary>
        /// Efface la bar en entier
        /// </summary>
        public void EraseBar()
        {
            for(int i = 0; i <  21; i++) 
            {
                Console.SetCursorPosition(Position.X - 4 + i, Position.Y - 26);
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
            //DisplayStartBar();
            //DisplayEndBar();

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
            return (holdTime / maxHoldTime) * 50;
        }
    }
}
