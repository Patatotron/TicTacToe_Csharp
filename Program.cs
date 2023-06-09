class Board
{
    List<string> _board = new();
    public Board()
    {
        for (int i = 0; i < 9; i++)
        {
            _board.Add("#");
        }
    }

    public void Print()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                Console.Write(_board[y + 3 * x] + " ");
            }
            Console.Write('\n');
        }
    }
    public bool CheckWinner(string player)
    {
        if (_board[0] == player && _board[1] == player && _board[2] == player)
        {
            return true;
        }
        else if (_board[3] == player && _board[4] == player && _board[5] == player)
        {
            return true;
        }
        else if (_board[6] == player && _board[7] == player && _board[8] == player)
        {
            return true;
        }
        else if (_board[0] == player && _board[3] == player && _board[6] == player)
        {
            return true;
        }
        else if (_board[1] == player && _board[4] == player && _board[7] == player)
        {
            return true;
        }
        else if (_board[2] == player && _board[5] == player && _board[8] == player)
        {
            return true;
        }
        else if (_board[0] == player && _board[4] == player && _board[8] == player)
        {
            return true;
        }
        else if (_board[2] == player && _board[4] == player && _board[6] == player)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool CheckPlayer()
    {
        return _board.Count(n => n == "X") > _board.Count(n => n == "O");
    }

    public void PlaceSign()
    {
        while (true)
        {
            Console.Write("\n" + "Enter your move: ");
            int PlayerMove = Convert.ToInt16(Console.ReadLine()) - 1;
            if (_board[PlayerMove] == "#")
            {
                if (CheckPlayer())
                {
                    _board[PlayerMove] = "O";
                    break;
                }
                else
                {
                    _board[PlayerMove] = "X";
                    break;
                }
            }
            else
            {
                Console.WriteLine("You can't place anything here, please try again.");
                Thread.Sleep(2000);
                Console.Clear();
                Print();
                continue;
            }
        }
    }
}
class MainClass
{
    public static void Main()
    {
        Board board = new();
        while (board.CheckWinner("X") || board.CheckWinner("O") == false)
        {
            Console.Clear();
            board.Print();
            board.PlaceSign();
            if (board.CheckWinner("X"))
            {
                Console.Clear();
                board.Print();
                Console.Write("\n");
                Console.WriteLine("Player X won!");
                break;
            }
            else if (board.CheckWinner("O"))
            {
                Console.Clear();
                board.Print();
                Console.Write("\n");
                Console.WriteLine("Player O won!");
                break;
            }
        }
    }
}