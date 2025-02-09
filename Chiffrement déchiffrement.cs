﻿using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Bienvenue dans le chiffrement et déchiffrement du chiffrement de Vigenère");

        Console.WriteLine("Menu principal");
        Console.WriteLine("1- Crypter un message");
        Console.WriteLine("2- Décrypter un message");
        Console.Write("Merci de rentrer votre choix [1,2]: ");

        int choix;
        while (!int.TryParse(Console.ReadLine(), out choix) || (choix != 1 && choix != 2))
        {
            Console.WriteLine("Erreur: Veuillez entrer un choix valide (1 ou 2)");
            Console.Write("Merci de rentrer votre choix [1,2]: ");
        }

        switch (choix)
        {
            case 1:
                CrypterMessage();
                break;
            case 2:
                DecrypterMessage();
                break;
        }
    }

    public static void CrypterMessage()
    {
        Console.WriteLine("Cryptage d'un message");
        Console.Write("Entrez le message à crypter : ");
        string message = Console.ReadLine().ToUpper(); // Convertir le message en majuscules
        Console.Write("Entrez la clé de chiffrement : ");
        string cle = Console.ReadLine().ToUpper(); // Convertir la clé en majuscules

        string messageCrypte = ChiffrerVigenere(message, cle);
        Console.WriteLine("Message crypté : " + messageCrypte);
    }

    public static void DecrypterMessage()
    {
        Console.WriteLine("Décryptage d'un message");
        Console.Write("Entrez le message crypté : ");
        string messageCrypte = Console.ReadLine().ToUpper(); // Convertir le message crypté en majuscules
        Console.Write("Entrez la clé de déchiffrement : ");
        string cle = Console.ReadLine().ToUpper(); // Convertir la clé en majuscules

        string messageDecrypte = DechiffrerVigenere(messageCrypte, cle);
        Console.WriteLine("Message décrypté : " + messageDecrypte);
    }

    public static string ChiffrerVigenere(string message, string cle)
    {
        string messageCrypte = "";
        int longueurCle = cle.Length;
        int indexCle = 0;

        foreach (char caractere in message)
        {
            if (char.IsLetter(caractere))
            {
                int decalage = cle[indexCle % longueurCle] - 'A';
                char caractereCrypte = (char)(((caractere - 'A' + decalage) % 26) + 'A');
                messageCrypte += caractereCrypte;
                indexCle++;
            }
            else
            {
                messageCrypte += caractere;
            }
        }

        return messageCrypte;
    }

    public static string DechiffrerVigenere(string messageCrypte, string cle)
    {
        string messageDecrypte = "";
        int longueurCle = cle.Length;
        int indexCle = 0;

        foreach (char caractere in messageCrypte)
        {
            if (char.IsLetter(caractere))
            {
                int decalage = cle[indexCle % longueurCle] - 'A';
                char caractereDecrypte = (char)(((caractere - 'A' - decalage + 26) % 26) + 'A');
                messageDecrypte += caractereDecrypte;
                indexCle++;
            }
            else
            {
                messageDecrypte += caractere;
            }
        }

        return messageDecrypte;
    }
}
