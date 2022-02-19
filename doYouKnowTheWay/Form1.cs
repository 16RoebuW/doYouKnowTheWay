using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace doYouKnowTheWay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        GridSquare[,] grid;
        Point gridSize;

        private void btnGenGrid_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Generating grid";
            tabController.SelectTab("pgVisualisation");

            int x = 10;
            int y = 10;

            if (int.TryParse(tbxSizeX.Text, out x) && int.TryParse(tbxSizeY.Text, out y))
            {
                lblStatus.Text = "Drawing grid";
            }
            else
            {
                lblStatus.Text = "Invalid sizes, using default";
            }

            grid = new GridSquare[x, y];
            gridSize.X = x;
            gridSize.Y = y;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    GridSquare square = new GridSquare(i, j);
                    grid[i, j] = square;
                }
            }

            DrawGrid(x, y);
        }

        public void DrawGrid(int x, int y)
        {
            Bitmap bmp = new Bitmap(pgVisualisation.Width, pgVisualisation.Height - 20);
            // 20 is the height of the status bar
            Graphics g = Graphics.FromImage(bmp);
            int w = pgVisualisation.Width / x;
            int h = (pgVisualisation.Height - 20 ) / y;
            Pen pen = new Pen(Color.Black);
            SolidBrush brushDefault = new SolidBrush(Color.Gray);
            SolidBrush brushObstacle = new SolidBrush(Color.Red);
            SolidBrush brushStart = new SolidBrush(Color.Lime);
            SolidBrush brushEnd = new SolidBrush(Color.Gold);
            SolidBrush brushPath = new SolidBrush(Color.RoyalBlue);

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    GridSquare square = grid[i, j];
                    SolidBrush brush = brushDefault;

                    if (square.type == SquareType.Obstacle)
                    {
                        brush = brushObstacle;
                    }
                    else if (square.type == SquareType.StartPoint)
                    {
                        brush = brushStart;
                    }
                    else if (square.type ==  SquareType.EndPoint)
                    {
                        brush = brushEnd;
                    }
                    else if (square.isPath)
                    {
                        brush = brushPath;
                    }

                    g.FillRectangle(brush, i * w, j * h, w, h);
                    g.DrawRectangle(pen, i * w, j * h, w, h);
                    
                }
            }

            pgVisualisation.BackgroundImage = bmp;
        }

        private void pgVisualisation_Resize(object sender, EventArgs e)
        {
            DrawGrid(gridSize.X, gridSize.Y);
        }

        public Point ScreenToGrid(int x, int y)
        {

            Point p = new Point(x, y);
            p.X = x * gridSize.X / pgVisualisation.Width;
            p.Y = y * gridSize.Y / (pgVisualisation.Height - 20);
            return p;
        }

        private void pgVisualisation_MouseMove(object sender, MouseEventArgs mouse)
        {
            //lblStatus.Text = $"Mouse is at {mouse.X} {mouse.Y}";
            lblStatus.Text = $"Mouse is at {ScreenToGrid(mouse.X, mouse.Y)}";
        }

        private void pgVisualisation_MouseClick(object sender, MouseEventArgs e)
        {
            Point mousePos = ScreenToGrid(e.X, e.Y);
            // Clicking cycles through properties
            GridSquare currentGridSquare = grid[mousePos.X, mousePos.Y];

            // Left click toggles between obstacle and normal, right click toggles between start and end
            if (e.Button == MouseButtons.Left)
            {
                switch (currentGridSquare.type)
                {
                    case SquareType.Normal:
                        currentGridSquare.type = SquareType.Obstacle;
                        break;
                    case SquareType.Obstacle:
                        currentGridSquare.type = SquareType.Normal;
                        break;
                    default:
                        currentGridSquare.type = SquareType.Normal;
                        break;
                }             
            }
            else
            {
                switch (currentGridSquare.type)
                {
                    case SquareType.Normal:
                        currentGridSquare.type = SquareType.StartPoint;
                        break;
                    case SquareType.Obstacle:
                        currentGridSquare.type = SquareType.StartPoint;
                        break;
                    case SquareType.StartPoint:
                        currentGridSquare.type = SquareType.EndPoint;
                        break;
                    case SquareType.EndPoint:
                        currentGridSquare.type = SquareType.StartPoint;
                        break;
                }
            }
            DrawGrid(gridSize.X, gridSize.Y);
        }

        private void btnFindPath_ButtonClick(object sender, EventArgs e)
        {
            int startCount = 0;
            int endCount = 0;

            for (int i = 0; i < gridSize.X; i++)
            {
                for (int j = 0; j < gridSize.Y; j++)
                {
                    if (grid[i,j].type == SquareType.StartPoint)
                    {
                        startCount++;
                    }
                    else if (grid[i,j].type == SquareType.EndPoint)
                    {
                        endCount++;
                    }
                }
            }


            if (startCount != 1)
            {
                lblStatus.Text = "You must have exactly one start point";
                return;
            }

            if (endCount != 1)
            {
                lblStatus.Text = "You must have exactly one end point";
                return;
            }

            lblStatus.Text = "Finding shortest path";

            // run Dijkstra's algorithm

            // Mark all nodes unvisited. Create a set of all the unvisited nodes called the unvisited set.
            List<GridSquare> unvisitedNodes = new List<GridSquare>();
            GridSquare currentNode = null;
            GridSquare destinationNode = null;

            foreach (GridSquare g in grid)
            {
                g.visited = false;
                g.isPath = false;

                if (g.type != SquareType.Obstacle)
                {
                    unvisitedNodes.Add(g);
                    g.tentativeDist = int.MaxValue;
                }
                if (g.type == SquareType.StartPoint)
                {
                    currentNode = g;
                }
                if (g.type == SquareType.EndPoint)
                {
                    destinationNode = g;
                }
            }

            // Assign to every node a tentative distance value: set it to zero for our initial node and to infinity for all other nodes. 
            // The tentative distance of a node v is the length of the shortest path discovered so far between the node v and the starting node. 
            // Since initially no path is known to any other vertex than the source itself (which is a path of length zero), all other tentative distances are initially set to infinity. 
            // Set the initial node as current.

            currentNode.tentativeDist = 0;

            // For the current node, consider all of its unvisited neighbors and calculate their tentative distances through the current node. 
            // Compare the newly calculated tentative distance to the current assigned value and assign the smaller one. 
            // For example, if the current node A is marked with a distance of 6, and the edge connecting it with a neighbor B has length 2, then the distance to B through A will be 6 + 2 = 8. 
            // If B was previously marked with a distance greater than 8 then change it to 8. Otherwise, the current value will be kept.

            while (destinationNode.visited == false)
            {
                List<GridSquare> unvisitedNeighbours = GetUnvisitedNeighbours(currentNode);

                foreach (GridSquare g in unvisitedNeighbours)
                {
                    int newTentDist = currentNode.tentativeDist + 1;
                    if (newTentDist < g.tentativeDist)
                    {
                        g.tentativeDist = newTentDist;
                        g.previous = currentNode;
                    }
                }

                // When we are done considering all of the unvisited neighbors of the current node, mark the current node as visited and remove it from the unvisited set. 
                // A visited node will never be checked again.

                currentNode.visited = true;
                unvisitedNodes.Remove(currentNode);

                // If the destination node has been marked visited or if the smallest tentative distance among the nodes in the unvisited set is infinity 
                // which occurs when there is no connection between the initial node and remaining unvisited nodes), then stop. 
                // The algorithm has finished.
                unvisitedNodes.Sort();

                // Otherwise, select the unvisited node that is marked with the smallest tentative distance, set it as the new current node, and go back to step 3.
                if (unvisitedNodes.Count > 0)
                {                   
                    currentNode = unvisitedNodes[0];
                    if (currentNode.tentativeDist == int.MaxValue)
                    {
                        lblStatus.Text = "No routes found";
                    }
                }
                else
                {
                    lblStatus.Text = "No more nodes to explore";
                    break;                   
                }
            }

            // Retrace steps to show path
            currentNode = destinationNode.previous;

            while (currentNode.type != SquareType.StartPoint)
            {
                currentNode.isPath = true;
                currentNode = currentNode.previous;
            }

            DrawGrid(gridSize.X, gridSize.Y);
        }

        private List<GridSquare> GetUnvisitedNeighbours(GridSquare currentNode)
        {
            List<GridSquare> outputList = new List<GridSquare>();

            // Left
            if (currentNode.posX > 0 )            
            {
                GridSquare neighbour = grid[currentNode.posX - 1, currentNode.posY];
                if (neighbour.type != SquareType.Obstacle && !neighbour.visited)
                {
                    outputList.Add(neighbour);
                }
            }
            // Right
            if (currentNode.posX < gridSize.X - 1)
            {
                GridSquare neighbour = grid[currentNode.posX + 1, currentNode.posY];
                if (neighbour.type != SquareType.Obstacle && !neighbour.visited)
                {
                    outputList.Add(neighbour);
                }
            }

            // Down
            if (currentNode.posY > 0)
            {
                GridSquare neighbour = grid[currentNode.posX, currentNode.posY - 1];
                if (neighbour.type != SquareType.Obstacle && !neighbour.visited)
                {
                    outputList.Add(neighbour);
                }
            }
            // Up
            if (currentNode.posY < gridSize.Y - 1)
            {
                GridSquare neighbour = grid[currentNode.posX, currentNode.posY + 1];
                if (neighbour.type != SquareType.Obstacle && !neighbour.visited)
                {
                    outputList.Add(neighbour);
                }
            }

            return outputList;
        }

        private void btnHelp_ButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("Grey = None\nRed = Obstacle\nGreen = Start\nGold = End\n\nPress left mouse to toggle between obstacles and clear\nPress right mouse to toggle between start and end\n\nClick \"Find path\" to find a route from start to end", "Help, I need somebody", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pgVisualisation, new object[] { true });
            // I have no idea what this code is actually doing but now my form doesn't flicker, so that's cool
            // Source: https://stackoverflow.com/questions/8046560/how-to-stop-flickering-c-sharp-winforms
        }
    }
}