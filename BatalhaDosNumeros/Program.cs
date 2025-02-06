using System;
using System.Threading;

class BatalhaDosNumeros
{
    static Random random = new Random();
    static int pontosDeVidaJogador = 100; // jogador 100 pontos de vida.
    static int pontosDeVidaMonstro = 50; // Monstro 50 pontos de vida.

    static void Main(string[] args)
    {
        // Cabeçalho do Jogo
        Console.WriteLine("============================================");
        Console.WriteLine("|            BATALHA DOS NÚMEROS           |");
        Console.WriteLine("============================================\n");

        while (pontosDeVidaJogador > 0 && pontosDeVidaMonstro > 0)
        {
            Console.WriteLine($"Você tem {pontosDeVidaJogador} de vida.");
            Console.WriteLine($"O monstro tem {pontosDeVidaMonstro} de vida.");
            Console.WriteLine("Resolva a equação:");

            if (ResolverEquacao())
            {
                int danoAoMonstro = random.Next(10, 21); // Gera um dano aleatório entre 10 e 20 para o monstro.
                pontosDeVidaMonstro -= danoAoMonstro; // Subtrai o dano da vida do monstro.
                Console.WriteLine($"Você acertou! Causou {danoAoMonstro} de dano ao monstro.\n"); // Informa o dano causado.
            }
            else
            {
                int danoAoJogador = random.Next(10, 20); // Gera um dano aleatório entre 10 e 20 para o jogador.
                pontosDeVidaJogador -= danoAoJogador; // Subtrai o dano da vida do jogador.
                Console.WriteLine(
                    $"Você errou! O monstro te atacou e causou {danoAoJogador} de dano.\n"
                );
            }

            Thread.Sleep(1000); // Pausa 1s.
        }

        // Mensagem final
        if (pontosDeVidaMonstro <= 0)
        {
            Console.WriteLine("\nVocê derrotou o monstro! Você venceu o jogo!"); // Vitória.
            Console.WriteLine(
                @"
█████████
█▄█████▄█
█▼▼▼▼▼
█ Você Venceu!
█▲▲▲▲▲
█████████
 ██ ██"
            );
        }
        else
        {
            Console.WriteLine("\nVocê foi derrotado! Obrigado por jogar Batalha dos Números!"); // Mensagem de derrota.
            Console.WriteLine(
                @"
█████████
█▄█████▄█
█▼▼▼▼▼
█ Você Perdeu!
█▲▲▲▲▲
█████████
 ██ ██"
            ); // Derrota.
        }
    }

    static bool ResolverEquacao()
    {
        int num1 = random.Next(1, 21); // Gera o primeiro número aleatório entre 1 e 20.
        int num2 = random.Next(1, 21); // Gera o segundo número aleatório entre 1 e 20.
        string operacao = new[] { "+", "-" }[random.Next(2)]; // Escolhe aleatoriamente entre adição e subtração.

        int respostaCorreta = operacao switch
        {
            "+" => num1 + num2,
            "-" => num1 - num2,
            _ => 0,
        };

        Console.WriteLine($"{num1} {operacao} {num2} = ?");

        string respostaJogador = Console.ReadLine();
        return int.TryParse(respostaJogador, out int resposta) && resposta == respostaCorreta;
    }
}
