using System;
using System.Collections.Generic;
using System.Text;
using static _5TTI_Ramsamy_Ewan_Jeu_de_dame.Program;

namespace _5TTI_Ramsamy_Ewan_Jeu_de_dame
{
    struct MethodesDuProjet
    {
        public void RemplissagePlateau(ref char[,] plateau)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        if (i < 4)
                        {
                            plateau[i, j] = '+';
                        }
                        else if (i > 5)
                        {
                            plateau[i, j] = '-';
                        }
                        else
                        {
                            plateau[i, j] = '0';
                        }

                    }
                    else 
                    { 
                        plateau[i, j] = '0';
                    }
                }
            }
        }
        public void AfficherPlateau(ref char[,] plateau)
        {
            ChaineColoree[] text = new ChaineColoree[0];
            for (int i = 0; i < plateau.GetLength(0); i++)
            {
                for (int j = 0; j < plateau.GetLength(1); j++)
                {
                    if (plateau[i,j] == '+')
                    {
                        Array.Resize(ref text, text.Length + 1);
                        text[text.Length - 1] = new ChaineColoree(ConsoleColor.White, "+");
                    }
                    else if (plateau[i, j] == 'X')
                    {
                        Array.Resize(ref text, text.Length + 1);
                        text[text.Length - 1] = new ChaineColoree(ConsoleColor.White, "X");
                    }
                    else if (plateau[i, j] == '-')
                    {
                        Array.Resize(ref text, text.Length + 1);
                        text[text.Length - 1] = new ChaineColoree(ConsoleColor.Red, "-");
                    }
                    else if (plateau[i, j] == '/')
                    {
                        Array.Resize(ref text, text.Length + 1);
                        text[text.Length - 1] = new ChaineColoree(ConsoleColor.Red, "/");
                    }
                    else if (plateau[i, j] == '0' && (i + j) % 2 == 1)
                    {
                        Array.Resize(ref text, text.Length + 1);
                        text[text.Length - 1] = new ChaineColoree(ConsoleColor.Gray, "0");
                    }
                    else
                    {
                        Array.Resize(ref text, text.Length + 1);
                        text[text.Length - 1] = new ChaineColoree(ConsoleColor.Black, "0");
                    }
                }
                Array.Resize(ref text, text.Length + 1);
                text[text.Length - 1] = new ChaineColoree(ConsoleColor.White, "\n");
            }
            EcrireCouleurConsole(text);
            Console.Write("\n");
        }
        public void MouvementPion(ref char[,] plateau, char pionAllie, char pionEnnemi, char pionRAllie, char pionREnnemi, int coefficient, ref int compteur)
        {
            int ligne = 0;
            int colonne = 0;
            bool mouvement = false;
            int choix = 0;

            while (mouvement == false)
            {
                AfficherPlateau(ref plateau);

                Console.WriteLine("Sur quelle ligne se trouve le pion que vous voulez bouger ?");
                ligne = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Sur quelle colonne se trouve le pion que vous voulez bouger ?");
                colonne = int.Parse(Console.ReadLine()) - 1;

                if(plateau[colonne, ligne] == pionAllie)
                {
                    if (plateau[colonne + 1, ligne + coefficient] == pionEnnemi && plateau[colonne + 2, ligne + 2 * coefficient] == '0')
                    {
                        plateau[colonne, ligne] = '0';
                        plateau[colonne + 1, ligne + coefficient] = '0';
                        plateau[colonne + 2, ligne + 2 * coefficient] = pionAllie;
                        compteur = compteur - 1;
                        mouvement = true;
                    }
                    else if (plateau[colonne - 1, ligne + coefficient] == pionEnnemi && plateau[colonne - 2, ligne + 2 * coefficient] == '0')
                    {
                        plateau[colonne, ligne] = '0';
                        plateau[colonne - 1, ligne + coefficient] = '0';
                        plateau[colonne - 2, ligne + 2 * coefficient] = pionAllie;
                        compteur = compteur - 1;
                        mouvement = true;
                    }
                    else
                    {
                        Console.WriteLine("Où voulez-vous aller ? \n 1 = vers la gauche \n 2 = vers la droite");
                        choix = int.Parse(Console.ReadLine());

                        if (choix == 1 && plateau[colonne - 1, ligne + coefficient] == '0')
                        {
                            plateau[colonne, ligne] = '0';
                            plateau[colonne - 1, ligne + coefficient] = pionAllie;
                            mouvement = true;

                            for (int i = 0; i < 10; i++)
                            {
                                if (pionAllie == '+' && plateau[i, 9] == '+')
                                {
                                    plateau[i, 9] = 'X';
                                }
                                else if (pionAllie == '-' && plateau[i, 0] == '-')
                                {
                                    plateau[i, 0] = '/';
                                }
                            }
                        }
                        else if (choix == 2 && plateau[colonne + 1, ligne + coefficient] == '0')
                        {
                            plateau[colonne, ligne] = '0';
                            plateau[colonne + 1, ligne + coefficient] = pionAllie;
                            mouvement = true;

                            for (int i = 0; i < 10; i++)
                            {
                                if (pionAllie == '+' && plateau[i, 9] == '+')
                                {
                                    plateau[i, 9] = 'X';
                                }
                                else if (pionAllie == '-' && plateau[i, 0] == '-')
                                {
                                    plateau[i, 0] = '/';
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ce n'est pas un choix pris en compte");
                            Console.ReadLine();
                        }
                    }
                    
                }
                if (plateau[colonne, ligne] == pionRAllie)
                {
                    if (plateau[colonne + 1, ligne + coefficient] == pionEnnemi && plateau[colonne + 2, ligne + 2 * coefficient] == '0')
                    {
                        plateau[colonne, ligne] = '0';
                        plateau[colonne + 1, ligne + coefficient] = '0';
                        plateau[colonne + 2, ligne + 2 * coefficient] = pionAllie;
                        compteur = compteur - 1;
                        mouvement = true;
                    }
                    else if (plateau[colonne - 1, ligne + coefficient] == pionEnnemi && plateau[colonne - 2, ligne + 2 * coefficient] == '0')
                    {
                        plateau[colonne, ligne] = '0';
                        plateau[colonne - 1, ligne + coefficient] = '0';
                        plateau[colonne - 2, ligne + 2 * coefficient] = pionAllie;
                        compteur = compteur - 1;
                        mouvement = true;
                    }
                    else if (plateau[colonne + 1, ligne - coefficient] == pionEnnemi && plateau[colonne + 2, ligne - 2 * coefficient] == '0')
                    {
                        plateau[colonne, ligne] = '0';
                        plateau[colonne + 1, ligne - coefficient] = '0';
                        plateau[colonne + 2, ligne - 2 * coefficient] = pionAllie;
                        compteur = compteur - 1;
                        mouvement = true;
                    }
                    else if (plateau[colonne - 1, ligne - coefficient] == pionEnnemi && plateau[colonne - 2, ligne - 2 * coefficient] == '0')
                    {
                        plateau[colonne, ligne] = '0';
                        plateau[colonne - 1, ligne - coefficient] = '0';
                        plateau[colonne - 2, ligne - 2 * coefficient] = pionAllie;
                        compteur = compteur - 1;
                        mouvement = true;
                    }
                    else
                    {
                        Console.WriteLine("Où voulez-vous aller ? \n 1 = vers l'avant gauche \n 2 = vers l'avant droite \n 3 = vers l'arrière gauche \n 4 = vers l'arrière droite");
                        choix = int.Parse(Console.ReadLine());

                        if (choix == 1 && plateau[colonne - 1, ligne + coefficient] == '0')
                        {
                            plateau[colonne, ligne] = '0';
                            plateau[colonne - 1, ligne + coefficient] = pionAllie;
                            mouvement = true;
                        }
                        else if (choix == 2 && plateau[colonne + 1, ligne + coefficient] == '0')
                        {
                            plateau[colonne, ligne] = '0';
                            plateau[colonne + 1, ligne + coefficient] = pionAllie;
                            mouvement = true;
                        }
                        else if (choix == 3 && plateau[colonne - 1, ligne - coefficient] == '0')
                        {
                            plateau[colonne, ligne] = '0';
                            plateau[colonne - 1, ligne - coefficient] = pionAllie;
                            mouvement = true;
                        }
                        else if (choix == 2 && plateau[colonne + 1, ligne - coefficient] == '0')
                        {
                            plateau[colonne, ligne] = '0';
                            plateau[colonne + 1, ligne - coefficient] = pionAllie;
                            mouvement = true;
                        }
                        else
                        {
                            Console.WriteLine("Ce n'est pas un choix pris en compte");
                            Console.ReadLine();
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Le pion sélectionné n'est pas le vôtre");
                    Console.ReadLine();
                }
            }
        }
        public static void EcrireCouleurConsole(params ChaineColoree[] strings)
        {
            var originalColor = Console.ForegroundColor;
            foreach (var str in strings)
            {
                Console.ForegroundColor = str.Couleur;
                Console.Write(str.Texte);
            }
            Console.ForegroundColor = originalColor;
        }

    }
}
