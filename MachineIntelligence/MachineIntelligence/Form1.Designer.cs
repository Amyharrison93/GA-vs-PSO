namespace MachineIntelligence
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.Evaluation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.StartBtn = new System.Windows.Forms.Button();
            this.CancelBrute = new System.Windows.Forms.Button();
            this.Result_Box = new System.Windows.Forms.TextBox();
            this.bruteForce = new System.Windows.Forms.Button();
            this.Pool_Size = new System.Windows.Forms.TextBox();
            this.Num_Cycles = new System.Windows.Forms.TextBox();
            this.Gene_Number = new System.Windows.Forms.TextBox();
            this.GeneticWorker = new System.ComponentModel.BackgroundWorker();
            this.ParticleWorker = new System.ComponentModel.BackgroundWorker();
            this.BruteWorker = new System.ComponentModel.BackgroundWorker();
            this.BruteProgress = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ParticleVisual = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ThreadOpto = new System.Windows.Forms.Button();
            this.ParticleGraph = new System.ComponentModel.BackgroundWorker();
            this.GeneticGraph = new System.ComponentModel.BackgroundWorker();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.Evaluation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleVisual)).BeginInit();
            this.SuspendLayout();
            // 
            // Evaluation
            // 
            chartArea1.Name = "ChartArea1";
            this.Evaluation.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Evaluation.Legends.Add(legend1);
            this.Evaluation.Location = new System.Drawing.Point(6, 6);
            this.Evaluation.Margin = new System.Windows.Forms.Padding(2);
            this.Evaluation.Name = "Evaluation";
            this.Evaluation.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Genetic Algorythm";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Particle Swarm";
            this.Evaluation.Series.Add(series1);
            this.Evaluation.Series.Add(series2);
            this.Evaluation.Size = new System.Drawing.Size(638, 596);
            this.Evaluation.TabIndex = 0;
            this.Evaluation.Text = "chart1";
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(646, 561);
            this.StartBtn.Margin = new System.Windows.Forms.Padding(2);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(102, 42);
            this.StartBtn.TabIndex = 1;
            this.StartBtn.Text = "Start Optimisation";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // CancelBrute
            // 
            this.CancelBrute.Location = new System.Drawing.Point(981, 561);
            this.CancelBrute.Margin = new System.Windows.Forms.Padding(2);
            this.CancelBrute.Name = "CancelBrute";
            this.CancelBrute.Size = new System.Drawing.Size(124, 42);
            this.CancelBrute.TabIndex = 2;
            this.CancelBrute.Text = "Cancel Brute Force";
            this.CancelBrute.UseVisualStyleBackColor = true;
            this.CancelBrute.Click += new System.EventHandler(this.button2_Click);
            // 
            // Result_Box
            // 
            this.Result_Box.Location = new System.Drawing.Point(646, 468);
            this.Result_Box.Margin = new System.Windows.Forms.Padding(2);
            this.Result_Box.Multiline = true;
            this.Result_Box.Name = "Result_Box";
            this.Result_Box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Result_Box.Size = new System.Drawing.Size(460, 91);
            this.Result_Box.TabIndex = 3;
            // 
            // bruteForce
            // 
            this.bruteForce.Location = new System.Drawing.Point(853, 563);
            this.bruteForce.Margin = new System.Windows.Forms.Padding(2);
            this.bruteForce.Name = "bruteForce";
            this.bruteForce.Size = new System.Drawing.Size(124, 42);
            this.bruteForce.TabIndex = 4;
            this.bruteForce.Text = "Brute Force";
            this.bruteForce.UseVisualStyleBackColor = true;
            this.bruteForce.Click += new System.EventHandler(this.bruteForce_Click);
            // 
            // Pool_Size
            // 
            this.Pool_Size.Location = new System.Drawing.Point(645, 414);
            this.Pool_Size.Margin = new System.Windows.Forms.Padding(2);
            this.Pool_Size.Multiline = true;
            this.Pool_Size.Name = "Pool_Size";
            this.Pool_Size.Size = new System.Drawing.Size(118, 32);
            this.Pool_Size.TabIndex = 5;
            // 
            // Num_Cycles
            // 
            this.Num_Cycles.Location = new System.Drawing.Point(817, 414);
            this.Num_Cycles.Margin = new System.Windows.Forms.Padding(2);
            this.Num_Cycles.Multiline = true;
            this.Num_Cycles.Name = "Num_Cycles";
            this.Num_Cycles.Size = new System.Drawing.Size(118, 32);
            this.Num_Cycles.TabIndex = 6;
            // 
            // Gene_Number
            // 
            this.Gene_Number.Location = new System.Drawing.Point(988, 414);
            this.Gene_Number.Margin = new System.Windows.Forms.Padding(2);
            this.Gene_Number.Multiline = true;
            this.Gene_Number.Name = "Gene_Number";
            this.Gene_Number.Size = new System.Drawing.Size(118, 32);
            this.Gene_Number.TabIndex = 7;
            // 
            // GeneticWorker
            // 
            this.GeneticWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GeneticWorker_DoWork);
            // 
            // ParticleWorker
            // 
            this.ParticleWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ParticleWorker_DoWork);
            // 
            // BruteWorker
            // 
            this.BruteWorker.WorkerReportsProgress = true;
            this.BruteWorker.WorkerSupportsCancellation = true;
            this.BruteWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BruteWorker_DoWork);
            // 
            // BruteProgress
            // 
            this.BruteProgress.Location = new System.Drawing.Point(645, 26);
            this.BruteProgress.Name = "BruteProgress";
            this.BruteProgress.Size = new System.Drawing.Size(460, 23);
            this.BruteProgress.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(642, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Brute Force Progress";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(643, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Size of pool";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(814, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Number of cycles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(950, 399);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Division factor for genetic pool";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(649, 453);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Results and info";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(417, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Plot of the best resault from each optomisation method giving direct comparison m" +
    "ethod";
            // 
            // ParticleVisual
            // 
            chartArea2.Name = "ChartArea1";
            this.ParticleVisual.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ParticleVisual.Legends.Add(legend2);
            this.ParticleVisual.Location = new System.Drawing.Point(645, 55);
            this.ParticleVisual.Name = "ParticleVisual";
            this.ParticleVisual.Size = new System.Drawing.Size(460, 341);
            this.ParticleVisual.TabIndex = 16;
            this.ParticleVisual.Text = "chart2";
            this.ParticleVisual.Click += new System.EventHandler(this.chart2_Click);
            // 
            // ThreadOpto
            // 
            this.ThreadOpto.Location = new System.Drawing.Point(752, 561);
            this.ThreadOpto.Margin = new System.Windows.Forms.Padding(2);
            this.ThreadOpto.Name = "ThreadOpto";
            this.ThreadOpto.Size = new System.Drawing.Size(102, 42);
            this.ThreadOpto.TabIndex = 17;
            this.ThreadOpto.Text = "Start Optimisation With Threading";
            this.ThreadOpto.UseVisualStyleBackColor = true;
            this.ThreadOpto.Click += new System.EventHandler(this.ThreadOpto_Click);
            // 
            // ParticleGraph
            // 
            this.ParticleGraph.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ParticleGraph_DoWork);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(200, 100);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "tabPage2";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(200, 100);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "tabPage3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 606);
            this.Controls.Add(this.ThreadOpto);
            this.Controls.Add(this.ParticleVisual);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BruteProgress);
            this.Controls.Add(this.Gene_Number);
            this.Controls.Add(this.Num_Cycles);
            this.Controls.Add(this.Pool_Size);
            this.Controls.Add(this.bruteForce);
            this.Controls.Add(this.Result_Box);
            this.Controls.Add(this.CancelBrute);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.Evaluation);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Evaluation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleVisual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Evaluation;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button CancelBrute;
        private System.Windows.Forms.TextBox Result_Box;
        private System.Windows.Forms.Button bruteForce;
        private System.Windows.Forms.TextBox Pool_Size;
        private System.Windows.Forms.TextBox Num_Cycles;
        private System.Windows.Forms.TextBox Gene_Number;
        private System.ComponentModel.BackgroundWorker GeneticWorker;
        private System.ComponentModel.BackgroundWorker ParticleWorker;
        private System.ComponentModel.BackgroundWorker BruteWorker;
        private System.Windows.Forms.ProgressBar BruteProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataVisualization.Charting.Chart ParticleVisual;
        private System.Windows.Forms.Button ThreadOpto;
        private System.ComponentModel.BackgroundWorker ParticleGraph;
        private System.ComponentModel.BackgroundWorker GeneticGraph;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
    }
}

