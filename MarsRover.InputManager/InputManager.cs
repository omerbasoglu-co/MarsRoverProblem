using System;
using System.Collections.Generic;
using MarsRover.Enum;
using MarsRover.Helper;
using MarsRover.InputManager.Entity;

namespace MarsRover.InputManager
{
    public static class InputManager
    {
        public static Input GetInput(string inputStr)
        {
            Queue<string> lines = GetLines(inputStr);

            Input input = new Input()
            {
                X = 0,
                Y = 0,
                InputRovers = new List<InputRover>()
            };

            if ((lines.Count) > 1 && (lines.Count - 1) % 2 == 0)
            {

                #region plateau
                string[] plateauArr = lines.Dequeue().Split(' ');

                if (plateauArr.Length != 2)
                {
                    throw new Exception("Oluşturulacak alan parametreleri hatalı örn :5 5");
                }

                int x;
                int.TryParse(plateauArr[0], out x);
                int y;
                int.TryParse(plateauArr[1], out y);

                if (x == 0)
                {
                    throw new FormatException("Oluşturulacak alan parametresi hatalı.Parametre  adı X");
                }

                if (y == 0)
                {
                    throw new FormatException("Oluşturulacak alan parametresi hatalı.Parametre  adı Y");
                }

                input.X = x;
                input.Y = y;
                #endregion

                while (lines.Count > 0)
                {
                    string[] roverPositionArr = lines.Dequeue().Split(' ');

                    if (roverPositionArr.Length != 3)
                    {
                        throw new Exception("Oluşturulacak rover'in parametreleri hatalı örn :1 2 N");
                    }

                    int positionX;
                    int.TryParse(roverPositionArr[0], out positionX);
                    int positionY;
                    int.TryParse(roverPositionArr[1], out positionY);

                    string directionStr = roverPositionArr[2];

                    if (positionX == 0)
                    {
                        throw new FormatException("Oluşturulacak alan parametresi hatalı.Parametre  adı X,sayısal veri olmalıdır.");
                    }

                    if (positionX == 0)
                    {
                        throw new FormatException("Oluşturulacak alan parametresi hatalı.Parametre  adı Y,sayılsal veri olmalıdır.");
                    }

                    Direction direction = directionStr.GetValueFromDescription<Direction>();

                    if (direction == Direction.None)
                    {
                        throw new FormatException("Oluşturulacak alan parametresi hatalı.Parametre  adı Direction,{N,E,S,W} karakterlerini içermelidir.");
                    }

                    string commamds = lines.Dequeue().Replace(" ","");

                    input.InputRovers.Add(new InputRover
                    {
                        X = positionX,
                        Y = positionY,
                        CurrentDirection = direction,
                        Commands = commamds
                    });
                }
            }
            else
            {
                throw new FormatException("Girilen input'un formatı hatalı");
            }

            return input;
        }

        public static Queue<string> GetLines(string input)
        {
            string[] lines = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            Queue<string> lineList = new Queue<string>();

            foreach (var item in lines)
            {
                string temp = item.ClearMultipleSpace();
                if (!string.IsNullOrEmpty(temp))
                {
                    lineList.Enqueue(temp.ToUpper());
                }
            }

            return lineList;
        }
    }
}
