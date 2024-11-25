using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labirint
{
    public partial class MazeForm : System.Windows.Forms.Form
    {
        private static int input_rows = 5, input_cols = 5, size;
        private Maze maze = new Maze(input_rows, input_cols);

        private static int Clamp(int min, int value, int max)
        {
            if (value < min) return min;
            else if (value > max) return max;
            return value;
        }

        private static int evenMask(int value)
        {
            if (value % 2 == 0) return ++value;
            return value;
        }

        public MazeForm()
        {
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(MazeForm_KeyPress);

            InitializeComponent();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            input_rows = evenMask(Clamp(5, Convert.ToInt32(rowsTextbox.Text), 301));
            input_cols = evenMask(Clamp(5, Convert.ToInt32(colsTextbox.Text), 301));
            rowsTextbox.Text = Convert.ToString(input_rows);
            colsTextbox.Text = Convert.ToString(input_cols);

            size = pictureBox.Height / Math.Max(input_rows, input_cols) - 1;
            maze = new Maze(input_rows, input_cols);
            maze.generateMaze();
            pictureBox.Image = maze.drawMaze(pictureBox.Width, pictureBox.Height, size, false);
        }

        private void buttonSolution_Click(object sender, EventArgs e)
        {
            pictureBox.Image = maze.drawMaze(pictureBox.Width, pictureBox.Height, size, true);
            maze.clickcount++;
        }

        private void MazeForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            maze.playerMovement(e.KeyChar);
            pictureBox.Image = maze.drawMaze(pictureBox.Width, pictureBox.Height, size, false);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            maze.Clear();
            pictureBox.Image = maze.drawMaze(pictureBox.Width, pictureBox.Height, size, false);
        }

        private void buttonStep_Click(object sender, EventArgs e)
        {
            maze.generateWalls();
            pictureBox.Image = maze.drawMaze(pictureBox.Width, pictureBox.Height, size, false);
        }
    }
}