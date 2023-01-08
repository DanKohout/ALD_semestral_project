using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Image = System.Windows.Controls.Image;

namespace try03_ald_sem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Dictionary<GridValue, ImageSource> gridValToImage = new()
        {
            {GridValue.Empty, Images.Empty },
            {GridValue.EndLeft, Images.End_1000 },
            {GridValue.EndTop, Images.End_0100 },
            {GridValue.EndRight, Images.End_0010 },
            {GridValue.EndBottom, Images.End_0001 },
            {GridValue.Curve0, Images.Curve_1100 },
            {GridValue.Curve90, Images.Curve_0110 },
            {GridValue.Curve180, Images.Curve_0011 },
            {GridValue.Curve270, Images.Curve_1001 },
            {GridValue.Straight0, Images.Straight_1010 },
            {GridValue.Straight90, Images.Straight_0101 },
            {GridValue.Cross3_0, Images.Cross3_1110 },
            {GridValue.Cross3_90, Images.Cross3_0111 },
            {GridValue.Cross3_180, Images.Cross3_1011 },
            {GridValue.Cross3_270, Images.Cross3_1101 },
            {GridValue.Cross4, Images.Cross4 },
            {GridValue.NotReady, Images.NotReady }
        };
        public static readonly int size = 10;
        private readonly int rows = size, cols = size;
        private readonly Image[,] gridImages;
        private Generator gen;



        private Image[,] SetupGrid()
        {
            Image[,] images = new Image[rows, cols];
            GameGrid.Rows = rows;
            GameGrid.Columns = cols;


            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    
                    Image image = new Image
                    {
                        Source = Images.NotReady
                    };
                    
                    images[r, c] = image;
                    GameGrid.Children.Add(image);
                }
            }
            //ScoreText.Text = "in";
            return images;

        }

        private void DrawGrid()
        {
            
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    GridValue gridVal = gen.Grid[r, c];
                    gridImages[r, c].Source = gridValToImage[gridVal];
                }
            }
        }

        private void StepbtnClick(object sender, RoutedEventArgs e)
        {
            gen.GenerateFor();
            DrawGrid();
        }
        private void FinishbtnClick(object sender, RoutedEventArgs e)
        {
            gen.allCycles();
            DrawGrid();
        }
        private void ResetbtnClick(object sender, RoutedEventArgs e)
        {
            gen.Generate();
            DrawGrid();
        }


        public MainWindow()
        {
            InitializeComponent();
            gridImages = SetupGrid();
            GameScreen.Focus();
            //-for easter egg
            GameTimer.Interval = TimeSpan.FromMilliseconds(16);
            GameTimer.Tick += GameTick;
            GameTimer.Start();
            //--------------
            gen = new Generator();
            gen.Generate();
            DrawGrid();
            ScoreText.Text = "used algorithm : Prim's Algorithm (my own implementation)";

        }


        /// <summary>
        /// movement of the red square, it is meant to be like an easter egg
        /// </summary>

        private DispatcherTimer GameTimer = new DispatcherTimer();
        private bool UpKeyPressed, DownKeyPressed, LeftKeyPressed, RightKeyPressed;

        

        private float SpeedX=0, SpeedY=0, Friction = 0.7f, Speed = 2;

        

        private void KeyboardUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                UpKeyPressed = true;
            }
            if (e.Key == Key.S)
            {
                DownKeyPressed = true;
            }
            if (e.Key == Key.A)
            {
                RightKeyPressed = true;
            }
            if (e.Key == Key.D)
            {
                LeftKeyPressed = true;
            }
        }

        private void KeyboardDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                UpKeyPressed = false;
            }
            if (e.Key == Key.S)
            {
                DownKeyPressed = false;
            }
            if (e.Key == Key.A)
            {
                RightKeyPressed = false;
            }
            if (e.Key == Key.D)
            {
                LeftKeyPressed = false;
            }
        }

        

        private void GameTick(object sender, EventArgs e)
        {
            if (UpKeyPressed)
            {
                SpeedY += Speed;
            }
            if (RightKeyPressed)
            {
                SpeedX += Speed;
            }
            if (LeftKeyPressed)
            {
                SpeedX -= Speed;
            }
            if (DownKeyPressed)
            {
                SpeedY -= Speed;
            }
            SpeedX = SpeedX * Friction;
            SpeedY = SpeedY * Friction;
            
            Canvas.SetLeft(Player, Canvas.GetLeft(Player) + SpeedX);
            Canvas.SetTop(Player, Canvas.GetTop(Player) + SpeedY);

        }

        
    }
}
