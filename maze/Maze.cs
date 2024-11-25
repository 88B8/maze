using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;
using System.Data.SqlTypes;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.Remoting.Contexts;

namespace labirint
{
    internal class Maze
    {
        private struct Cell
        {
            public int y;
            public int x;
            public Cell(int y, int x)
            {
                this.y = y;
                this.x = x;
            }
        }

        private enum Direction { Right, Left, Down, Up }
        private List<Direction> Directions = new List<Direction>();
        private List<Cell> Stack = new List<Cell>(); //стек клеток
        private List<int> Player = new List<int> { 1, 1 };
        private Random random = new Random();
        private int[][] Maze_Matrix, Path_Matrix; //представление лабиринта в виде матрицы
        private bool solved = false;
        private int last; //направление последнего движения
        public int clickcount = 0;

        public Maze(int rows, int columns)
        {
            Maze_Matrix = new int[rows][];
            Path_Matrix = new int[rows][];
            for (int y = 0; y < rows; y++)
            {
                Maze_Matrix[y] = new int[columns];
                Path_Matrix[y] = new int[columns];
                for (int x = 0; x < columns; x++)
                {
                    Maze_Matrix[y][x] = 1;
                    Path_Matrix[y][x] = 0;
                }
            }
            Maze_Matrix[1][1] = 0;
            Stack.Add(new Cell(1, 1));
        }
        public void playerMovement(char key)    
        {
            if (key == 's' && Player[1] + 1 < Maze_Matrix.Length && Maze_Matrix[Player[1] + 1][Player[0]] != 1) Player[1]++;
            else if (key == 'w' && Player[1] - 1 > 0 && Maze_Matrix[Player[1] - 1][Player[0]] != 1) Player[1]--;
            else if (key == 'd' && Player[0] + 1 < Maze_Matrix[0].Length && Maze_Matrix[Player[1]][Player[0] + 1] != 1) Player[0]++;
            else if (key == 'a' && Player[0] - 1 > 0 && Maze_Matrix[Player[1]][Player[0] - 1] != 1) Player[0]--;

            if (Player[0] == Maze_Matrix[0].Length - 2 && Player[1] == Maze_Matrix.Length - 2) MessageBox.Show("Поздравляю, вы прошли лабиринт");
        }

        public Bitmap drawMaze(int width, int height, int size, bool showpath)
        {
            Bitmap picture = new Bitmap(width, height);
            Graphics context = Graphics.FromImage(picture);
            int rectX, rectY,
                left = width / 2 - (size * Maze_Matrix[0].Length + (Maze_Matrix[0].Length - 1)) / 2, //расположение по центру
                top = height / 2 - (size * Maze_Matrix.Length + (Maze_Matrix.Length - 1)) / 2;
            Color color;

            for (int y = 0; y < Maze_Matrix.Length; y++)
            {
                for (int x = 0; x < Maze_Matrix[0].Length; x++)
                {
                    rectX = x * size + 1 * x + left;
                    rectY = y * size + 1 * y + top;
                    if (showpath) mazeSolver();
                    if (Maze_Matrix[y][x] == 0 && clickcount % 2 == 0) color = Color.SteelBlue; //выход из лабиринта
                    else if (Maze_Matrix[y][x] == 1) color = Color.Black; //стены
                    else color = Color.Gray; //посещенные клетки
                    
                    context.FillRectangle(new SolidBrush(color), rectX, rectY, size, size);
                }
            }
            if (Stack.Count != 0)
            context.FillRectangle(new SolidBrush(Color.Red), Stack.Last().x * size + Stack.Last().x + left, Stack.Last().y * size + Stack.Last().y + top, size, size);

            context.FillRectangle(new SolidBrush(Color.Red), (Maze_Matrix[0].Length - 2) * size + (Maze_Matrix[0].Length - 2) + left, (Maze_Matrix.Length - 2) * size + (Maze_Matrix.Length - 2) + top, size, size);
            context.FillRectangle(new SolidBrush(Color.Blue), Player[0] * size + Player[0] + left, Player[1] * size + Player[1] + top, size, size);
            return picture;
        }

        public void generateWalls()
        {
            if (Stack.Count != 0)
            {
                {
                    Directions.Clear();
                    Cell current = Stack.Last();
                    if (current.x + 2 < Maze_Matrix[0].Length && Maze_Matrix[current.y][current.x + 2] == 1)
                    {
                        Directions.Add(Direction.Right);
                    }
                    if (current.x - 2 > 0 && Maze_Matrix[current.y][current.x - 2] == 1)
                    {
                        Directions.Add(Direction.Left);
                    }
                    if (current.y + 2 < Maze_Matrix.Length && Maze_Matrix[current.y + 2][current.x] == 1)
                    {
                        Directions.Add(Direction.Down);
                    }
                    if (current.y - 2 > 0 && Maze_Matrix[current.y - 2][current.x] == 1)
                    {
                        Directions.Add(Direction.Up);
                    }

                    int rand = random.Next(Directions.Count);
                    if (Directions.Count > 0)
                    {
                        switch (Directions[rand])
                        {
                            case Direction.Right:
                                Maze_Matrix[current.y][current.x + 1] = 0;
                                Maze_Matrix[current.y][current.x + 2] = 0;
                                Stack.Add(new Cell(current.y, current.x + 2));
                                break;
                            case Direction.Left:
                                Maze_Matrix[current.y][current.x - 1] = 0;
                                Maze_Matrix[current.y][current.x - 2] = 0;
                                Stack.Add(new Cell(current.y, current.x - 2));
                                last = 1;
                                break;
                            case Direction.Down:
                                Maze_Matrix[current.y + 1][current.x] = 0;
                                Maze_Matrix[current.y + 2][current.x] = 0;
                                Stack.Add(new Cell(current.y + 2, current.x));
                                break;
                            case Direction.Up:
                                Maze_Matrix[current.y - 1][current.x] = 0;
                                Maze_Matrix[current.y - 2][current.x] = 0;
                                Stack.Add(new Cell(current.y - 2, current.x));
                                last = 2;
                                break;
                        }
                    }
                    else
                    {
                        if (Maze_Matrix[current.y][current.x - 1] == 0) //бектрек
                            Maze_Matrix[current.y][current.x - 1] = 2;
                        else if (Maze_Matrix[current.y][current.x + 1] == 0)
                            Maze_Matrix[current.y][current.x + 1] = 2;
                        else if (Maze_Matrix[current.y - 1][current.x] == 0)
                            Maze_Matrix[current.y - 1][current.x] = 2;
                        else if (Maze_Matrix[current.y + 1][current.x] == 0)
                            Maze_Matrix[current.y + 1][current.x] = 2;

                        Maze_Matrix[current.y][current.x] = 2;
                        Stack.RemoveAt(Stack.Count - 1);
                    }
                    if (current.x == Maze_Matrix[0].Length - 2 && current.y == Maze_Matrix.Length - 2 && !solved)
                    {
                        solved = true;
                        for (int y = 1; y < Maze_Matrix.Length - 1; y++) //(сейчас там хранятся клетки, формирующие путь)
                        {
                            for (int x = 1; x < Maze_Matrix[0].Length - 1; x++)
                            {
                                if (Maze_Matrix[Maze_Matrix.Length - 3][Maze_Matrix[0].Length - 2] == 2) Path_Matrix[Maze_Matrix.Length - 3][Maze_Matrix[0].Length - 2] = 0; //1000$ fix
                                else if (Maze_Matrix[Maze_Matrix.Length - 2][Maze_Matrix[0].Length - 3] == 2) Path_Matrix[Maze_Matrix.Length - 2][Maze_Matrix[0].Length - 3] = 0;
                                else if (last == 1) { Path_Matrix[Maze_Matrix.Length - 2][Maze_Matrix[0].Length - 3] = 2; Path_Matrix[Maze_Matrix.Length - 2][Maze_Matrix[0].Length - 4] = 2; }
                                else if (last == 2) { Path_Matrix[Maze_Matrix.Length - 3][Maze_Matrix[0].Length - 2] = 2; Path_Matrix[Maze_Matrix.Length - 4][Maze_Matrix[0].Length - 2] = 2; }

                                Path_Matrix[y][x] = Maze_Matrix[y][x];
                            }
                        }
                    }
                }
            }
        }

        public void generateMaze()
        {
            do
            {
                generateWalls();
            } while (Stack.Count != 1);
        }

        public void Clear()
        {
            for (int y = 1; y < Maze_Matrix.Length; y++)
            {
                for (int x = 1; x < Maze_Matrix[0].Length; x++)
                {
                    if (Maze_Matrix[y][x] != 1)
                    {
                        Maze_Matrix[y][x] = 1;
                        Path_Matrix[y][x] = 1;
                    }
                }
            }
        }

        private void mazeSolver()
        {
            for (int y = 1; y < Path_Matrix.Length - 1; y++)
            {
                for (int x = 1; x < Path_Matrix[0].Length - 1; x++)
                {
                    if (Path_Matrix[y][x] == 0) Maze_Matrix[y][x] = 0;
                }
            }
        }
    }
}