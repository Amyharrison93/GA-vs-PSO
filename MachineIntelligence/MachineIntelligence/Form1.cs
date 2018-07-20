using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cwklib2017;

namespace MachineIntelligence
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Pool_Size.Text = "100";
            Num_Cycles.Text = "50";
            Gene_Number.Text = "3";
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            Evaluation.Series["Genetic Algorythm"].Points.Clear();
            Evaluation.Series["Particle Swarm"].Points.Clear();
            Result_Box.Clear();

            // Check if the point entered is numeric or not
            int
                k,
                GeneNumber = Convert.ToInt32(Gene_Number.Text),
                PoolSize = Convert.ToInt32(Pool_Size.Text),
                Cycles = Convert.ToInt32(Num_Cycles.Text);


            if (!int.TryParse(Pool_Size.Text, out k) && (!int.TryParse(Num_Cycles.Text, out k)))
            {
                MessageBox.Show("You must enter a whole number");
            }
            else if((GeneNumber > 10) || (GeneNumber < 2))
            {
                MessageBox.Show("There must be more then one gene");
            }
            else
            {
                GeneticAlgorythm(PoolSize, Cycles, GeneNumber);
                //GeneticWorker.RunWorkerAsync();
                ParticleSwarm(PoolSize, Cycles);
                //ParticleWorker.RunWorkerAsync();
            }
        }

        public int[] GeneticAlgorythm(int PoolSize, int Cycles, int GeneNumber)
        {
            int[][]
                GeneInt = new int[PoolSize][];   //to store the config parts as integer array array

            int
                mutate;

            string[]
                GeneString = new string[PoolSize];   //to store the configurations
            
            FitFunc
                EvaluateGene = new FitFunc();

            Random randNumGen = new Random();

            //GENERATES POOL MEMBERS
            GeneInt = poolGen(PoolSize);

            //Genetic Algorythm code to follow:

            //EVALUATE FIRST BATCH
            for (int i = 0; i < PoolSize; i++)
            {
                GeneString[i] = ToBinary(GeneInt[i]);
                GeneInt[i][11] = EvaluateGene.evalFunc(GeneString[i]);
            }


            for (int i = 0; i < Cycles; i++)
            {
                //SORT ARRAY
                GeneInt = sort(GeneInt, PoolSize);

                Evaluation.Series["Genetic Algorythm"].Points.AddXY(i, GeneInt[0][11]);
                System.Threading.Thread.Sleep(1); //Thread sleep to give UI time to updatew with fresh graph

                //REPOPULATE BOTTOM 2/3
                GeneInt = childmaker(GeneInt, PoolSize);
                if (i < 100)
                {
                    mutate = randNumGen.Next(0, 101 - i); //non-Uniform mutation prevents later pools from being too random allowing better solutions pools to be kept
                }
                else
                {
                    mutate = 0;
                }
                //MUTATE
                
                for (int m = PoolSize / GeneNumber;( m < mutate) && (m < PoolSize); m++)  //random number of mutations
                {
                    int r = randNumGen.Next(0, 11);             //mutate random parameter
                    GeneInt[m][r] = GeneInt[m][r] + randNumGen.Next(0, PoolSize);

                }

                //EVALUATE CHILDREN
                for (int j = 0; j < PoolSize; j++)
                {
                    GeneString[j] = ToBinary(GeneInt[j]);
                    GeneInt[j][11] = EvaluateGene.evalFunc(GeneString[j]);
                }
            }

            GeneInt = sort(GeneInt, PoolSize);
            Result_Box.Text = Result_Box.Text + "The Genetic Algorithm solution is: " + ToBinary(GeneInt[0]) +
                Environment.NewLine + "With a grade of: " + GeneInt[0][11] + Environment.NewLine;

            return GeneInt[0];
        }

        public int[] ParticleSwarm(int PoolSize, int Cycles)
        {
            foreach (var series in ParticleVisual.Series)
            {
                series.Points.Clear();
            }

            int[][][]
                Generation = new int[Cycles][][];

            int[][]
                ParticleInt = new int[PoolSize][],
                ParticlePlot = new int[PoolSize][],
                ParticleLocalBest = new int[PoolSize][],
                temp = new int[PoolSize][],
                GlobalBest = new int[Cycles][];


            double[][]
                velocity = new double[PoolSize][];
               
            double
                random;

            string[]
                ParticleString = new string[PoolSize];

            string
                particle;   //unused was part of attampt to graph particle score over time(cycles)

            FitFunc
                EvaluateParticle = new FitFunc();

            Random randNumGen = new Random();

            //initial velocity
            for(int a = 0; a < PoolSize; a++)
            {
                velocity[a] = new double[12];
                for (int b = 0; b < 12; b++)
                {
                    
                    velocity[a][b] = 0.1;
                }
            }
            //generate random pool of particles
            ParticleInt = poolGen(PoolSize);

            Generation[0] = ParticleInt;

            for(int a = 1; a < Cycles; a++)
            {
                Generation[a] = ParticleInt;
            }

            for (int i = 0; i < PoolSize; i++)
            {
                ParticleString[i] = ToBinary(Generation[0][i]);
                ParticleInt[i][11] = EvaluateParticle.evalFunc(ParticleString[i]);
            }

            ParticlePlot = sort(ParticleInt, PoolSize);
            GlobalBest[0] = ParticleInt[0];

           
            for (int gen = 0; gen < Cycles; gen++)
            {

                GlobalBest[gen] = Generation[gen][0];
                for (int i = 0; i < PoolSize; i++)
                {
                    ParticleString[i] = ToBinary(Generation[gen][i]);
                    Generation[gen][i][11] = EvaluateParticle.evalFunc(ParticleString[i]);
                    
                }
                ParticleLocalBest = Generation[gen];
                // Step 2 – for cycles many times do this
                for (int i = 0; i < Cycles; i++)
                {
                    //System.Threading.Thread.Sleep(1); //Thread sleep to give UI time to updatew with fresh graph
                    //PlotConvergence(i, Generation[gen][i][11]);

                    //      Step 3 - For each particle do this
                    for (int j = 0; j < PoolSize; j++)
                    {
                        //temp = (sort(Generation[gen], PoolSize));
                        //Step 4 – Evaluate the particle’s position.
                        ParticleString[j] = ToBinary(Generation[gen][j]);
                        Generation[gen][j][11] = EvaluateParticle.evalFunc(ParticleString[j]);
                    
                        //Step 5 – Compare particle’s current position to particle’s best local position, if current position is better replace it.
                        if (Generation[gen][j][11] > ParticleLocalBest[j][11])
                        {
                            int[] temp2 = new int[12];
                            temp2 = Generation[gen][j];

                            for (int k = 0; k > 12; k++)
                            {
                                ParticleLocalBest[j][k] = temp2[k];
                            }
                                          
                        }
                        //Step 6 – Compare particle’s current position to global best position of the previous cycle, if better, replace
                        if (gen > 0)
                        {
                            if (Generation[gen][j][11] > GlobalBest[gen - 1][11])
                            {                                

                                for (int k = 0; k > 12; k++)
                                {
                                    GlobalBest[gen][k] = Generation[gen][j][k];
                                }
                            }
                            else if (Generation[gen][j][11] < GlobalBest[gen - 1][11])
                            {
                                for (int k = 0; k > 12; k++)
                                {
                                    GlobalBest[gen][k] = Generation[gen - 1][j][k];
                                }
                            }
                           
                        }
                        // Step 7 - Calculate velocity vector for particles
                        for (int k = 0; k < 11; k++)
                        {
                            random = randNumGen.Next(1, 101)/100.00;
                            if (gen < 1)
                            {
                                velocity[j][k] = Convert.ToDouble(velocity[j][k] + 2 + random * (ParticleLocalBest[j][k] - Generation[gen][j][k]) + 2 * random * (GlobalBest[gen][k] - Generation[gen][j][k]));
                            }
                            else
                            {
                                velocity[j][k] = Convert.ToDouble(velocity[j][k] + 2 + random * (ParticleLocalBest[j][k] - Generation[gen][j][k]) + 2 * random * (GlobalBest[gen - 1][k] - Generation[gen][j][k]));
                            }
                            // Step 8 - Move particle according to velocity vector.
                            if(gen + 1 >= Cycles)
                            {
                                //
                            }

                            else if (k < 9)
                            {
                                if ((velocity[j][k] < 0) && (Generation[gen][j][k] != 1))
                                {
                                    Generation[gen+1][j][k] = Generation[gen][j][k]--;
                                }
                                else if ((velocity[j][k] > 0) && (Generation[gen][j][k] != 5))
                                {
                                    Generation[gen + 1][j][k] = Generation[gen][j][k]++;
                                }
                                else if(gen+1 >= Cycles)
                                {
                                    //
                                }
                                else { }
                            }
                            else if(k == 9)
                            {
                                if ((velocity[j][k] < 0) && (Generation[gen][j][k] != 1))
                                {
                                    Generation[gen + 1][j][k] = Generation[gen][j][k]--;
                                }
                                else if ((velocity[j][k] > 0) && (Generation[gen][j][k] != 32))
                                {
                                    Generation[gen + 1][j][k] = Generation[gen][j][k]++;
                                }
                                else if (gen + 1 >= Cycles)
                                {
                                    //
                                }
                                else { }
                            }
                            else if(k == 10)
                            {

                                if ((velocity[j][k] < 0) && (Generation[gen][j][k] != 1))
                                {
                                    Generation[gen + 1][j][k] = Generation[gen][j][k]--;
                                }
                                else if ((velocity[j][k] > 0) && (Generation[gen][j][k] != 3))
                                {
                                    Generation[gen + 1][j][k] = Generation[gen][j][k]++;
                                }
                                else if (gen + 1 >= Cycles)
                                {
                                    //
                                }
                                else { }
                            }
                            //ParticleVisual.Series["Velocity per cycle"].Points.AddXY(k, velocity[j][k]);
                        }                 
                    }
                    //Step 9 – Return to Step 2.
                    //ParticleGraph.RunWorkerAsync();             
                }

                if (gen < 1)
                {
                    Evaluation.Series["Particle Swarm"].Points.AddXY(gen, GlobalBest[gen][11]);
                }
                else
                {
                    Evaluation.Series["Particle Swarm"].Points.AddXY(gen, GlobalBest[gen - 1][11]);
                }
            }
            Result_Box.Text = Result_Box.Text + "The Particle Swarm solition is: " + ToBinary(GlobalBest[Cycles-1]) +
                Environment.NewLine + "With a grade of: " + GlobalBest[Cycles-1][11] + Environment.NewLine;        

            return GlobalBest[0];
        }

        public int PlotConvergence(int i, int j)
        {
            string particle;

            particle = "Particle " + i;
            ParticleVisual.Series[particle].Points.AddXY(i, j);

            return 0;
        }

        public int[][] poolGen(int particlePoolSize)
        {
            int[][] ParticleInt = new int[particlePoolSize][];   //to store the config parts as integer array array
            Random randNumGen = new Random();

            //GENERATES POOLSISE MEMBERS
            for (int i = 0; i < particlePoolSize; i++)
            {
                ParticleInt[i] = new int[12];

                for (int j = 0; j < 11; j++)
                {
                    if (j == 10)
                    {
                        ParticleInt[i][j] = randNumGen.Next(1, 4);
                    }
                    else if (j == 9)
                    {
                        ParticleInt[i][j] = randNumGen.Next(0, 32);
                    }
                    else
                    {
                        ParticleInt[i][j] = randNumGen.Next(1, 6);
                    }
                }
            }
            return ParticleInt;
        }

        public int[][] childmaker(int[][] ParticleInt, int particlePoolSize)
        {
            Random randNumGen = new Random();

            for (int i = (particlePoolSize / 3) + 1; i < particlePoolSize; i++) //Overwrites worst 2 thirds
            {
                //select 3 random parents for genes
                for (int gene = 1; gene < 4; gene++)
                {
                    int parent = randNumGen.Next(1, i + 1);
                    if (gene == 1)
                    {
                        ParticleInt[i][0] = ParticleInt[parent][0];
                        ParticleInt[i][1] = ParticleInt[parent][1];
                        ParticleInt[i][2] = ParticleInt[parent][2];
                        ParticleInt[i][3] = ParticleInt[parent][3];
                    }
                    else if (gene == 2)
                    {
                        ParticleInt[i][4] = ParticleInt[parent][4];
                        ParticleInt[i][5] = ParticleInt[parent][5];
                        ParticleInt[i][6] = ParticleInt[parent][6];
                        ParticleInt[i][7] = ParticleInt[parent][7];
                    }
                    else if (gene == 3)
                    {
                        ParticleInt[i][8] = ParticleInt[parent][8];
                        ParticleInt[i][9] = ParticleInt[parent][9];
                        ParticleInt[i][10] = ParticleInt[parent][10];
                    }
                }
            }

            return ParticleInt;
        }

        public int[][] sort(int[][] ParticleInt, int PoolSize)
        {
            
           int[][] tempJag = new int[PoolSize][];

            for (int a = 0; a < PoolSize; a++)
            {
                tempJag = ParticleInt;

                for (int i = 1; i < PoolSize; i++)
                {
                    //ParticleInt = ParticleInt.OrderBy(j => j.Skip(1).First()).ToArray();                    
                    
                    tempJag[i] = ParticleInt[i];
                    if (ParticleInt[i][11] > ParticleInt[i - 1][11])
                    {
                        int[] temp = new int[12];
                        temp = ParticleInt[i - 1];
                        ParticleInt[i - 1] = ParticleInt[i];
                        ParticleInt[i] = temp;
                    }
                    
                }
            }

            return ParticleInt;
        }

        public string ToBinary(int[] x)
        {
            string 
                binaryPart = "", 
                binaryVal = "";

            for (int i = 0; i < 11; i++)
            {
                if (i == 10)
                {
                    if (x[i] > 3)
                    {
                        x[i] = x[i]%3;
                    }

                    if (x[i] == 1)
                    {
                        binaryPart = "001";
                    }
                    else if (x[i] == 2)
                    {
                        binaryPart = "010";
                    }
                    else if (x[i] == 3)
                    {
                        binaryPart = "100";
                    }

                }
                else if (i == 9)
                {
                    if (x[i] > 31)
                    {
                        x[i] = x[i]%31;
                    }

                    binaryPart = UCLanToBin(x[i]);
                }
                else
                {
                    if (x[i] > 5)
                    {
                        x[i] = x[i]%5;
                    }

                    if (x[i] == 1)
                    {
                        binaryPart = "00001";
                    }
                    else if (x[i] == 2)
                    {
                        binaryPart = "00010";
                    }
                    else if (x[i] == 3)
                    {
                        binaryPart = "00100";
                    }
                    else if (x[i] == 4)
                    {
                        binaryPart = "01000";
                    }
                    else if (x[i] == 5)
                    {
                        binaryPart = "10000";
                    }
                }

                binaryVal = binaryVal + binaryPart;
            }
            return binaryVal;

        }

        public string UCLanToBin(int x)
        {
            string binaryVal = "";

            for (int i = 5; i > 0; i--)
            {
                
                if (x%2 == 1)
                {
                    x = (x - (x % 2))/2;
                    binaryVal = binaryVal + "1";
                }
                else
                {
                    x = x / 2;
                    binaryVal = binaryVal + "0";
                }
            }
            
            return binaryVal;
        }

        private void bruteForce_Click(object sender, EventArgs e)
        {
            BruteWorker.RunWorkerAsync(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BruteWorker.CancelAsync();
        }

        private void GeneticWorker_DoWork(object sender, DoWorkEventArgs Genetic)
        {
            object[] GeneticAlgorythm = Genetic.Argument as object[];



            Genetic.Result = true;
        }
        private void GeneticWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs Genetic)
        {
            object result = Genetic.Result;

            // Handle what to do when complete.                        
        }

        private void GeneticWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Evaluation.Series["Particle Swarm"].Points.AddXY(i, GlobalBest[11]);
        }

        private void ParticleWorker_DoWork(object sender, DoWorkEventArgs Particle)
        {
            object[] ParticleSwarm = Particle.Argument as object[];

            Particle.Result = true;
        }
        private void ParticleWorler_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs Particle)
        {
            object result = Particle.Result;

            // Handle what to do when complete.                        
        }

        private void ParticleWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Evaluation.Series["Particle Swarm"].Points.AddXY(i, GlobalBest[11]);
        }

        public string toBinary(int x)
        {
            string
                binaryVal = "";

            for (int i = 5; i > 0; i--)
            {
                if (x % 2 == 1)
                {
                    x = (x - (x % 2)) / 2;
                    binaryVal = binaryVal + "1";
                }
                else
                {
                    x = x / 2;
                    binaryVal = binaryVal + "0";
                }
            }

            return binaryVal;
        }

        private void BruteWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string
                bruteExTemp = "",
                bruteInTemp = "",
                bruteCyPre = "",
                bruteVOP = "",
                bruteLoTor = "",
                bruteNOx = "",
                bruteCO = "",
                bruteHC = "",
                brutePM = "",
                bruteUCLan = "",
                bruteString = "",
                optimalSettings = "";
            int
                gradeValue = 0,
                newGradeValue,
                progress = 0,
                Iterations = 0;
            //Extern temp
            for (int i = 0; i < 5; i++)
            {
                
                bruteExTemp = toBinary(2 ^ i);

                //Intern temp
                for (int j = 0; j < 5; j++)
                {
                    
                    bruteInTemp = bruteExTemp + toBinary(2 ^ j);

                    //Cylinder Pressure
                    for (int k = 0; k < 5; k++)
                    {
                        
                        bruteCyPre = bruteExTemp + bruteInTemp + toBinary(2 ^ k);

                        //Valve Opening Pressure
                        for (int l = 0; l < 5; l++)
                        {
                            
                            bruteVOP = bruteExTemp + bruteInTemp + bruteCyPre + toBinary(2 ^ l);

                            //Load torque
                            for (int m = 0; m < 5; m++)
                            {
                                bruteLoTor = bruteExTemp + bruteInTemp + bruteCyPre + bruteVOP + toBinary(2 ^ m);

                                //NOx Emissions
                                for (int n = 0; n < 5; n++)
                                {
                                    bruteNOx = bruteExTemp + bruteInTemp + bruteCyPre + bruteVOP + bruteLoTor + toBinary(2 ^ n);

                                    //CO Emissions
                                    for (int o = 0; o < 5; o++)
                                    {
                                        bruteCO = bruteExTemp + bruteInTemp + bruteCyPre + bruteVOP + bruteLoTor + bruteNOx + toBinary(2 ^ o);

                                        //HC Emissions
                                        for (int p = 0; p < 5; p++)
                                        {
                                            bruteHC = bruteExTemp + bruteInTemp + bruteCyPre + bruteVOP + bruteLoTor + bruteNOx + bruteCO + toBinary(2 ^ p);

                                            //PM Emissions
                                            for (int q = 0; q < 5; q++)
                                            {
                                                brutePM = bruteExTemp + bruteInTemp + bruteCyPre + bruteVOP + bruteLoTor + bruteNOx + bruteCO + bruteHC + toBinary(2 ^ q);

                                                //UCLan Stuff
                                                for (int r = 0; r < 32; r++)
                                                {
                                                    bruteUCLan = bruteExTemp + bruteInTemp + bruteCyPre + bruteVOP + bruteLoTor + bruteNOx + bruteCO + bruteHC + brutePM + toBinary(r);

                                                    //
                                                    for (int s = 0; s < 3; s++)
                                                    {
                                                        //temp
                                                        if (s == 0)
                                                        {
                                                            //high
                                                            bruteString = bruteExTemp + bruteInTemp + bruteCyPre + bruteVOP + bruteLoTor + bruteNOx + bruteCO + bruteHC + brutePM + bruteUCLan + "001";
                                                        }
                                                        else if (s == 1)
                                                        {
                                                            //Middle
                                                            bruteString = bruteExTemp + bruteInTemp + bruteCyPre + bruteVOP + bruteLoTor + bruteNOx + bruteCO + bruteHC + brutePM + bruteUCLan + "010";
                                                        }
                                                        else
                                                        {
                                                            //low
                                                            bruteString = bruteExTemp + bruteInTemp + bruteCyPre + bruteVOP + bruteLoTor + bruteNOx + bruteCO + bruteHC + brutePM + bruteUCLan + "100";
                                                        }

                                                        //shows the progress in progress bar
                                                        progress = (Iterations+1/187500000);
                                                        BruteWorker.ReportProgress(progress, BruteProgress);
                                                        System.Threading.Thread.Sleep(1000);

                                                        if (BruteWorker.CancellationPending)
                                                        {
                                                            e.Cancel = true;                                                         
                                                        }

                                                        FitFunc newtest = new FitFunc();
                                                        newGradeValue = newtest.evalFunc(bruteString);
                                                        if (newGradeValue > gradeValue)
                                                        {
                                                            gradeValue = newGradeValue;
                                                            optimalSettings = bruteString;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //fin
            MessageBox.Show("Optimal Settings found: " + optimalSettings + Environment.NewLine + "With a grade of: " + gradeValue);
            Result_Box.Text = "Optimal Settings found: " + optimalSettings + Environment.NewLine + "With a grade of: " + gradeValue;
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void ThreadOpto_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Sorry this currently needs more development" +Environment.NewLine + "Complete will show when thread has stopped.");

            Evaluation.Series["Genetic Algorythm"].Points.Clear();
            Evaluation.Series["Particle Swarm"].Points.Clear();
            Result_Box.Clear();
            
            int
                k,
                GeneNumber = Convert.ToInt32(Gene_Number.Text),
                PoolSize = Convert.ToInt32(Pool_Size.Text),
                Cycles = Convert.ToInt32(Num_Cycles.Text);

            if (!int.TryParse(Pool_Size.Text, out k) && (!int.TryParse(Num_Cycles.Text, out k)))
            {
                MessageBox.Show("You must enter a whole number");
            }
            else if ((GeneNumber > 10) || (GeneNumber < 2))
            {
                MessageBox.Show("There must be more then one gene");
            }
            else
            {
                //not the correct way to thread apparently, does not work
                GeneticWorker.RunWorkerAsync(GeneticAlgorythm(PoolSize, Cycles, GeneNumber)); 
            
                ParticleWorker.RunWorkerAsync(ParticleSwarm(PoolSize, Cycles));

                Result_Box.Text = Result_Box.Text + Environment.NewLine + "Completed";                
            }
        }

        private void ParticleGraph_DoWork(object sender, DoWorkEventArgs e)
        {
            //Evaluation.Series["Particle Swarm"].Points.AddXY(i, GlobalBest[11]);
        }
    }
}
