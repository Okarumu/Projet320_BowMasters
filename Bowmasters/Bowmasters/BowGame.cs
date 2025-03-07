///*******************************************************
/// EMTL
/// Auteur : Maël Naudet
/// Date : 31.01.2025
/// TODO : AJOUTER SON DE LEGO YODA QUI DECEDE AVEC LE BRUIT DE LEGO QUI SE CASSE ET LE SON DE VICTOIRE HAPPY WHEELS
///*******************************************************

using System;
using System.Linq;
using System.Threading;

namespace Bowmasters
{
    /// <summary>
    /// Logique principale dans le jeu
    /// </summary>
    internal class BowGame
    {
        // Déclaration des constantes **********************************************************

        /// <summary>
        /// Nombre de dégat pris lors d'une attaque
        /// </summary>
        private const byte _AMOUNT_OF_DAMAGE = 1;

        /// <summary>
        /// Temps maximum de pression pour la barre de progression
        /// </summary>
        private const byte _MAX_HOLD_TIME = 2;

        /// <summary>
        /// Coordonnée X pour le message de fin de partie
        /// </summary>
        private const byte _X_COORDINATE_END_SCREEN = 63;

        /// <summary>
        /// Coordonnée Y pour le message de fin de partie
        /// </summary>
        private const byte _Y_COORDINATE_END_SCREEN = 15;

        /// <summary>
        /// Nombre de points attribués par coup (multiplié par un certain bonus) 
        /// </summary>
        private const int _SCORE_ADDER = 50;

        // Déclaration des attributs  **********************************************************

        /// <summary>
        /// Tableau qui contient les 2 joueurs du jeu
        /// </summary>
        private Player[] _players;

        /// <summary>
        /// Tableau qui contient les tours de chaque joueur
        /// </summary>
        private Tower[] _towers;

        /// <summary>
        /// Caractère pour le numéro du vainqueur
        /// </summary>
        private char winner;

        // Déclaration des constructeurs *******************************************************

        /// <summary>
        /// Constructeur avec 2 joueurs et 2 tours
        /// </summary>
        /// <param name="players">struct qui possède les 2 joueurs du jeu</param>
        /// <param name="towers">struct qui possède les tours des 2 joueurs</param>
        public BowGame(Players players, Towers towers)
        {
            _players = new Player[2] { players.Player1, players.Player2 };
            _towers = new Tower[2] { towers.Tower1, towers.Tower2 };
        }

        // Déclaration et implémentation des méthodes ******************************************

        /// <summary>
        /// Initialise le jeu en affichant les éléments et en chargeant les différents sons
        /// </summary>
        public void Initialize()
        {
            // Affiche les joueurs et les tours
            DisplayPlayers(_players);
            DisplayTower(_towers);

            // Charge tous les sons
            SoundEffect.PreloadSound("throw", "SoundEffect/Bow Shot (Minecraft Sound) - Sound Effect for editingCUT.wav");
            SoundEffect.PreloadSound("hitPlayer", "SoundEffect/Minecraft-Damage-_Oof_-Sound-Effect-_HD_Cut.wav");
            SoundEffect.PreloadSound("hitTower", "SoundEffect/getting_thrown_againsed_something_(sound_effect)_outCut.wav");
        }

        /// <summary>
        /// Boucle qui permet de bien faire le jeu
        /// </summary>
        public void GameLoop()
        {
            // boucle de jeu
            do
            {
                // Gestion pour le joueur 1

                // Création de la gestion de l'angle et de la vitesse
                ShootAngle anglePlayerOne = new ShootAngle(player: _players[0], isRight: true);
                PressSpace velocityBarPlayerOne = new PressSpace(_players[0], _MAX_HOLD_TIME, _players[0].Color);

                // Création de la balle
                Ball ballPlayerOne = BallPowerAndAngle(angle: anglePlayerOne, ballVelocity: velocityBarPlayerOne, throwRight: true);

                // Son de lancer
                SoundEffect.PlaySound("throw");
                Thread.Sleep(150);

                // Lancement de la balle jusqu'à ce qu'elle touche quelque chose ou qu'elle sorte des limites du terrain
                ThrowBall(ball : ballPlayerOne, thrower: _players[0], ennemy:  _players[1], myTower: _towers[0], ennemyTower:  _towers[1]);

                // Efface les points des angles et la barre de progression
                anglePlayerOne.EraseModel();
                velocityBarPlayerOne.EraseBar();

                // Raffiche les joueurs au cas où la balle en aurait touché un
                DisplayPlayers(_players);

                // joueur 2 en vie
                if (_players[1].Life > 0)
                {
                    // Gestion pour le joueur 2

                    // Création de la gestion de l'angle et de la vitesse
                    ShootAngle anglePlayerTwo = new ShootAngle(player: _players[1], isRight: false);
                    PressSpace velocityBarPlayerTwo = new PressSpace(_players[1], _MAX_HOLD_TIME, _players[1].Color);

                    // Création de la balle
                    Ball ballPlayerTwo = BallPowerAndAngle(angle: anglePlayerTwo, ballVelocity: velocityBarPlayerTwo, throwRight: false);

                    // Son pour le lancer
                    SoundEffect.PlaySound("throw");
                    Thread.Sleep(150);

                    // Lance la balle jusqu'à ce qu'elle touche quelque chose ou qu'elle sorte des limites du terrain
                    ThrowBall(ball: ballPlayerTwo, thrower: _players[1], ennemy: _players[0], myTower: _towers[1], ennemyTower: _towers[0]);

                    // Efface les points des angles et la barre de progression
                    anglePlayerTwo.EraseModel();
                    velocityBarPlayerTwo.EraseBar();

                    // Raffiche les joueurs au cas où la balle en aurait touché un
                    DisplayPlayers(_players);
                }
            } while (_players.All(v => v.Life != 0));   // tant que tous les joueurs sont en vie
        }

        /// <summary>
        /// Message de fin de jeu
        /// </summary>
        public void EndGame()
        {
            Console.ForegroundColor = ConsoleColor.White;

            // Choix de quel joueur a gagné et met le bon joueur à terre
            if (_players[0].Life != 0)
            {
                winner = '1';
                _players[1].DisplayLying();
            }
            else
            {
                winner = '2';
                _players[2].DisplayLying();
            }
            //SON DE YODA QUI MEURT
            Thread.Sleep(500);
            //SON DE VICTOIRE HAPPY WHEELS
            // Ecriture du message de victoire
            Console.SetCursorPosition(_X_COORDINATE_END_SCREEN, _Y_COORDINATE_END_SCREEN);
            Console.WriteLine($"Félicitations au joueur {winner}");

            Console.ReadLine();
        }

        /// <summary>
        /// Regarde si une balle touche une tour
        /// </summary>
        /// <param name="ball">balle qui est lancée</param>
        /// <param name="tower">tour possiblement touchée</param>
        /// <returns>un booléen disant si une tour a été touchée ou non</returns>
        private bool CollisionsTower(Ball ball, Tower tower)
        {
            // parcourt toutes les pièces de la tour
            foreach (TowerPiece piece in tower.Pieces)
            {
                // balle au même endroit qu'une pièce + la pièce n'est pas déjà détruite
                if (ball.ActualPosition.X == piece.Position.X && ball.ActualPosition.Y == piece.Position.Y && !piece.IsDestroyed)
                {
                    // détruit la pièce
                    piece.DestroyPiece();
                    // indique qu'elle a été touchée
                    return true;
                }
            }
            // pas de tour touchée
            return false;
        }

        /// <summary>
        /// Regarde si une balle touche un joueur
        /// </summary>
        /// <param name="ball">balle qui est lancée</param>
        /// <param name="ennemy">joueur ennemi</param>
        /// <returns>un booléen disant si un joueur est touché ou non</returns>
        private bool CollisionsPlayer(Ball ball, Player ennemy)
        {
            // parcourt toutes les positions des la hitbox du joueur
            foreach (PositionByte position in ennemy.Hitbox.HitBoxes)
            {
                // si la balle est dans cette hitbox
                if (ball.ActualPosition.X == position.X && ball.ActualPosition.Y == position.Y)
                {
                    // touché
                    return true;
                }
            }
            // pas touché
            return false;
        }

        /// <summary>
        /// Regarde que la balle soit toujours dans la fenêtre
        /// </summary>
        /// <param name="ball"></param>
        /// <returns></returns>
        private bool CheckBallInGame(Ball ball)
        {
            // balle dans la fenêtre
            if (ball.ActualPosition.X <= Console.WindowWidth && ball.ActualPosition.X > 1 &&
                ball.ActualPosition.Y <= Console.WindowHeight)
            {
                // retourne qu'elle y est
                return true;
            }
            // balle en dehors
            else
            {
                // retourne qu'elle n'y est pas
                return false;
            }
        }

        /// <summary>
        /// Utilisation de la gestion de l'angle et de la vitesse afin de retourner une balle prête à être utilisée
        /// </summary>
        /// <param name="angle">gestion de l'angle de la balle par l'utilisateur</param>
        /// <param name="ballVelocity">gestion de la vélocité de la balle de l'utilisateur</param>
        /// <param name="throwRight">savoir si l'utilisateur tire à droite ou à gauche</param>
        /// <returns>une balle prête à être utilisée</returns>
        private Ball BallPowerAndAngle(ShootAngle angle, PressSpace ballVelocity, bool throwRight)
        {
            // gestion de l'angle de la balle
            double ballAngle = angle.UpdateBallAngle();

            // gestion de la barre de progression
            double velocity = ballVelocity.Start();

            // tire à droite
            if (throwRight)
            {
                // retourne une balle qui part depuis le point angle le plus proche
                return new Ball(velocity, ballAngle, (byte)(angle.Position[(int)Math.Round(ballAngle / 22.5)].X + 1), (byte)(angle.Position[(int)Math.Round(ballAngle / 22.5)].Y));

                // à décommenter si on veut tester pour toucher directement le joueur 2
                //return new Ball(32, 45, (byte)(angle.Position[(int)Math.Round(90 / 22.5)].X + 1), (byte)(angle.Position[(int)Math.Round(90 / 22.5)].Y));

            }
            // tire à gauche
            else
            {
                // retourne une balle qui part depuis le point angle le plus proche
                return new Ball(velocity, ballAngle, (byte)(angle.Position[(int)Math.Round((ballAngle - 90) / 22.5)].X - 1), (byte)(angle.Position[(int)Math.Round((ballAngle - 90) / 22.5)].Y));

                // à décommenter si on veut tester pour toucher directement le joueur 1
                //return new Ball(32, 135, (byte)(angle.Position[(int)Math.Round(90 / 22.5)].X + 1), (byte)(angle.Position[(int)Math.Round(90 / 22.5)].Y));
            }
        }

        /// <summary>
        /// Lance la balle selon le joueur et arrête le tour en fonction de si la balle touche une tour, un joueur ou sort des limites du terrain
        /// </summary>
        /// <param name="ball">balle à lancer</param>
        /// <param name="thrower">le joueur qui lance la balle</param>
        /// <param name="ennemy">le joueur adverse</param>
        /// <param name="myTower">la tour du lancer</param>
        /// <param name="ennemyTower">la tour de l'ennemi</param>
        private void ThrowBall(Ball ball, Player thrower, Player ennemy, Tower myTower, Tower ennemyTower)
        {
            // bool de controle pour terminer le tour
            bool endTurn = false;
            // début du timer (référence à quand il a commencé)
            DateTime startTime = DateTime.Now;
            // le timer est égal à 0
            double time = 0;

            // boucle do...while qui affiche la balle en fonction du temps et l'arrete si elle touche un élément
            do
            {
                // on update la position de la balle en fonction du temps
                ball.UpdateBallPosition(time);
                // on augmente le timer
                time = (DateTime.Now - startTime).TotalSeconds;
                // on affiche la balle
                ball.DisplayBallInTime();

                // on réaffiche les informations des personnages au cas où la balle les a effacés
                ennemy.DisplayInfo();
                thrower.DisplayInfo();

                // s'il y a une collision avec l'ennemy
                if (CollisionsPlayer(ball, ennemy))
                {
                    // on fait le son de hit
                    SoundEffect.PlaySound("hitPlayer");
                    Thread.Sleep(100);

                    // on raffiche le joueur en lui enlevant de la vie
                    ennemy.DisplayStanding();
                    ennemy.TakeDamage(_AMOUNT_OF_DAMAGE);
                    // on rajoute du score au lanceur
                    thrower.Score += _SCORE_ADDER * 3;

                    // on raffiche les infos des joueurs updatés
                    ennemy.DisplayInfo();
                    thrower.DisplayInfo();

                    // on indique que le tour est fini
                    endTurn = true;
                }
                // s'il y a une collision avec sa propre tour
                else if (CollisionsTower(ball, myTower))
                {
                    // on fait le son de cassage de tour
                    SoundEffect.PlaySound("hitTower");
                    Thread.Sleep(100);
                    // on enlève du score au joueur et on le remontre
                    thrower.Score -= _SCORE_ADDER / 2;
                    thrower.DisplayInfo();

                    // on indique que le tour est fini
                    endTurn = true;
                }
                // s'il y a une collision avec la tour ennemie
                else if (CollisionsTower(ball, ennemyTower))
                {
                    // on fait le son de cassage de tour
                    SoundEffect.PlaySound("hitTower");
                    Thread.Sleep(100);

                    // on ajoute du score au lanceur et on l'update
                    thrower.Score += _SCORE_ADDER;
                    thrower.DisplayInfo();

                    // on indique que le tour est fini
                    endTurn = true;
                }

                Thread.Sleep(10);

                // on efface la balle
                ball.ErasePreviousBall();

            } // tant que la balle est dans le jeu et que le tour n'est pas fini 
            while (CheckBallInGame(ball) && !endTurn);
        }

        /// <summary>
        /// Affiche tous les joueurs d'une liste
        /// </summary>
        /// <param name="players"></param>
        private void DisplayPlayers(Player[] players)
        {
            // affiche tous les joueurs et leurs infos
            for (byte i = 0; i < players.Length; i++)
            {
                players[i].DisplayStanding();
                players[i].DisplayInfo();
            }
        }

        /// <summary>
        /// Affiche toutes les tours d'une liste
        /// </summary>
        /// <param name="towers">list of tower</param>
        private void DisplayTower(Tower[] towers)
        {
            // affiche toutes les tours
            for (byte i = 0; i < towers.Length; i++)
            {
                towers[i].Display();
            }
        }
    }
}