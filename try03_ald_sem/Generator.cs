using System;
using System.Collections.Generic;

namespace try03_ald_sem
{
    public class Generator
    {
        //16 choices
        private Random random;
        //The main Grid of tiles that will be forwarded to the GUI
        public GridValue[,] Grid;
        //The Secondary Grid that will be used for the algorithm (0-undefined,1-frontier,2-defined)
        public int[,] Grid2;
        //the Tertiary Grid in which is stored information about links between tiles (bool: left,top,right,bottom)
        private bool[,,] helperGrid;
        private int ii, jj, chosenFrontier, c, s;
        private bool cycle;
        private List<Crate> frontiers;

        public bool[,] Compatibility;// = new bool[17, 4];

        private void setCompatibility()
        {
            helper(0, false, false, false, false);
            helper(1, false, true, false, false);
            helper(2, false, false, false, true);
            helper(3, true, false, false, false);
            helper(4, false, false, true, false);
            helper(5, true, true, false, false);
            helper(6, false, true, true, false);
            helper(7, false, false, true, true);
            helper(8, true, false, false, true);
            helper(9, true, false, true, false);
            helper(10, false, true, false, true);
            helper(11, true, true, true, false);
            helper(12, false, true, true, true);
            helper(13, true, false, true, true);
            helper(14, true, true, false, true);
            helper(15, true, true, true, true);
            helper(16, true, true, true, true);
        }

        /// <summary>
        /// helper method for easier enlisting of Compatibility
        /// </summary>
        private void helper(int a, bool left, bool top, bool right, bool bott)
        {
            Compatibility[a, 0] = left;
            Compatibility[a, 1] = top;
            Compatibility[a, 2] = right;
            Compatibility[a, 3] = bott;
        }
        /// <summary>
        /// method for choosing the wanted tile number from Compatibility by its compatibility (for better understanding check methods: helper,setCompatibility)
        /// </summary>
        /// <returns>number of the desired tile</returns>
        private int getWanted(bool b1, bool b2, bool b3, bool b4)
        {
            for (int i = 0; i < 16; i++)
            {
                if (Compatibility[i, 0] == b1 && Compatibility[i, 1] == b2 && Compatibility[i, 2] == b3 && Compatibility[i, 3] == b4)
                {
                    return i;
                }
            }
            return 16;
        }
        



        /// <summary>
        /// the Constructor
        /// </summary>
        public Generator()
        {
            random = new Random();
            Grid = new GridValue[MainWindow.size, MainWindow.size];
            Grid2 = new int[MainWindow.size, MainWindow.size];
            int s = MainWindow.size;
            Compatibility = new bool[17, 4];
            setCompatibility();
            helperGrid = new bool[s, s, 4];
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    Grid[i, j] = (GridValue)16;
                    Grid2[i, j] = 0;
                    helperGrid[i, j, 0] = false;
                    helperGrid[i, j, 1] = false;
                    helperGrid[i, j, 2] = false;
                    helperGrid[i, j, 3] = false;
                }
            }
            frontiers = new List<Crate>();
            c = 0;
            cycle = false;
        }

        /// <summary>
        /// method for automating all cycles of GenerateFor() method
        /// </summary>
        public void allCycles()
        {
            while (cycle)
            {
                GenerateFor();
            }
        }

        /// <summary>
        ///     the starter of the algorithm 
        /// </summary>
        public void Generate()
        {

            s = MainWindow.size;
            for (int m = 0; m < s; m++)
            {
                for (int n = 0; n < s; n++)
                {
                    Grid[m, n] = (GridValue)16;
                    Grid2[m, n] = 0;
                    helperGrid[m, n, 0] = false;
                    helperGrid[m, n, 1] = false;
                    helperGrid[m, n, 2] = false;
                    helperGrid[m, n, 3] = false;

                }
            }

            frontiers.Clear();

            chosenFrontier = 0;
            ii = random.Next(0, s);
            jj = random.Next(0, s);
            Grid2[ii, jj] = 2;

            cycle = true;
            GenerateFor();



        }
        /// <summary>
        /// insides of the main cycle (in separate method, because of the visual option of stepping)
        /// here is located implementation of the Prim's algorithm
        /// </summary>
        public void GenerateFor()
        {
            if (cycle)//for (c = 0; cycle; c++)
            {
                //cycle
                if (ii != 0)//adding neighbours to frontiers 
                {
                    if (Grid2[ii - 1, jj] == 0) { frontiers.Add(new Crate(ii - 1, jj)); Grid2[ii - 1, jj] = 1; }
                }
                if (ii != s - 1)
                {
                    if (Grid2[ii + 1, jj] == 0) { frontiers.Add(new Crate(ii + 1, jj)); Grid2[ii + 1, jj] = 1; }
                }
                if (jj != 0)
                {
                    if (Grid2[ii, jj - 1] == 0) { frontiers.Add(new Crate(ii, jj - 1)); Grid2[ii, jj - 1] = 1; }
                }
                if (jj != s - 1)
                {
                    if (Grid2[ii, jj + 1] == 0) { frontiers.Add(new Crate(ii, jj + 1)); Grid2[ii, jj + 1] = 1; }
                }

                //neighbour + helperGrid check
                List<Crate> neighbourCount = new List<Crate>();
                if (ii != 0) { if (Grid2[ii - 1, jj] == 2) { neighbourCount.Add(new Crate(ii - 1, jj)); } }
                if (ii != s - 1) { if (Grid2[ii + 1, jj] == 2) { neighbourCount.Add(new Crate(ii + 1, jj)); } }
                if (jj != 0) { if (Grid2[ii, jj - 1] == 2) { neighbourCount.Add(new Crate(ii, jj - 1)); } }
                if (jj != s - 1) { if (Grid2[ii, jj + 1] == 2) { neighbourCount.Add(new Crate(ii, jj + 1)); } }
                if (neighbourCount.Count > 0)
                {
                    int p = random.Next(0, neighbourCount.Count);
                    int i2 = neighbourCount[p].getI();
                    int j2 = neighbourCount[p].getJ();


                    if (ii != i2)
                    {
                        if (ii > i2)
                        {
                            helperGrid[ii, jj, 1] = true;
                            helperGrid[i2, j2, 3] = true;
                        }
                        else
                        {
                            helperGrid[ii, jj, 3] = true;
                            helperGrid[i2, j2, 1] = true;
                        }
                    }
                    else if (jj != j2)
                    {
                        if (jj > j2)
                        {
                            helperGrid[ii, jj, 0] = true;
                            helperGrid[i2, j2, 2] = true;
                        }
                        else
                        {
                            helperGrid[ii, jj, 2] = true;
                            helperGrid[i2, j2, 0] = true;
                        }
                    }
                }


                if (frontiers.Count <= 0) { cycle = false; }
                else
                {
                    chosenFrontier = random.Next(0, frontiers.Count);// choosing of the next frontier

                    ii = frontiers[chosenFrontier].getI();
                    jj = frontiers[chosenFrontier].getJ();
                    Grid2[ii, jj] = 2;
                    frontiers.Remove(frontiers[chosenFrontier]);
                }
            }

            drawHelper();
        }


        /// <summary>
        /// choosing the desired tile for the Grid[,] using calculated links in helperGrid[,,]
        /// </summary>
        private void drawHelper()
        {
            int s = MainWindow.size;
            for (int k = 0; k < s; k++)
            {
                for (int l = 0; l < s; l++)
                {
                    Grid[k, l] = (GridValue)getWanted(helperGrid[k, l, 0], helperGrid[k, l, 1], helperGrid[k, l, 2], helperGrid[k, l, 3]);//pocatek -> random
                }
            }

        }




    }
}
