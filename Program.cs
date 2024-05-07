using System;

namespace Task1
{
    public class Player
    {
        public List<int> steps = new List<int>();
        public char symbol { get; set; }
        public Player(char S = 'X') { symbol = S; }
        public bool cur_step(int pos, Player enemy)
        {
            if (pos < 0 || pos > 8)
            {
                Console.WriteLine("Ход невозможен, повторите попытку");
                return false;
            }
            foreach (var step in steps)
            {
                if (step == pos)
                {
                    Console.WriteLine("Ход невозможен, повторите попытку");
                    return false;
                }
            }
            foreach(var step in enemy.steps)
            {
                if (step == pos)
                {
                    Console.WriteLine("Ход невозможен, повторите попытку");
                    return false;
                }
            }
            steps.Add(pos);
            return true;
        }
    }
    public class Programm
    {
        static void init(ref char[,] field)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    field[i, j] = '*';
        }
        static void print(char[,] field)
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                    Console.Write("{0}  ", field[i, j]);
                Console.WriteLine();
            }
        }

        static bool win(char[,] field, Player player)
        {
            for(int i = 0; i < 3; ++i)
                if(field[i, 0] == field[i, 1] && field[i, 2] == field[i, 0] && field[i, 0] == player.symbol) return true;
            for (int i = 0; i < 3; ++i)
                if (field[0, i] == field[1, i] && field[2, i] == field[0, i] && field[0, i] == player.symbol) return true;
            if (field[0, 0] == field[2, 2] && field[1, 1] == field[2, 2] && field[1, 1] == player.symbol) return true;
            if (field[0, 2] == field[1, 1] && field[2, 0] == field[1, 1] && field[1, 1] == player.symbol) return true;
            return false;
        }

        static void Main()
        {
            char[,] field_game = new char[3, 3];
            init(ref field_game);
            Player player1 = new Player('X');
            Player player2 = new Player('O');
            bool flag = true;
            short t = 0;
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                    Console.Write("{0}  ", t++);
                Console.WriteLine();
            }
            while (flag)
            {
                Console.WriteLine("{0} введите позицию хода", nameof(player1));
                int temp = Convert.ToInt32(Console.ReadLine());
                bool f = player1.cur_step(temp, player2);
                while(f != true)
                {
                    Console.WriteLine("{0} введите позицию хода", nameof(player1));
                    temp = Convert.ToInt32(Console.ReadLine());
                    f = player1.cur_step(temp, player2);
                }
                field_game[temp / 3, temp % 3] = player1.symbol;
                print(field_game);
                if (win(field_game, player1) == true)
                {
                    Console.WriteLine("Победил игрок - {0}", nameof(player1));
                    break;
                }
                Console.WriteLine("{0} введите позицию хода", nameof(player2));
                temp = Convert.ToInt32(Console.ReadLine());
                f = player2.cur_step(temp, player1);
                while (f != true)
                {
                    Console.WriteLine("{0} введите позицию хода", nameof(player2));
                    temp = Convert.ToInt32(Console.ReadLine());
                    f = player2.cur_step(temp, player1);
                }
                field_game[temp / 3, temp % 3] = player2.symbol;
                if (win(field_game, player2) == true)
                {
                    Console.WriteLine("Победил игрок - {0}", nameof(player2));
                    flag = false;
                    break;
                }
                print(field_game);
                if(player1.steps.Count() + player2.steps.Count() == 9)
                {
                    Console.WriteLine("Ничья");
                    flag = false;
                }
                Thread.Sleep(450);
                Console.Clear();
            }
            Console.WriteLine("Игра завершена");
        }
    }
}

