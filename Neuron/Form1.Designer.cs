namespace Neuron
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
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.cmdCompute = new System.Windows.Forms.Button();
            this.Seed = new System.Windows.Forms.Label();
            this.numSeed = new System.Windows.Forms.NumericUpDown();
            this.prbProgress = new System.Windows.Forms.ProgressBar();
            this.numNbBatches = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numBatchSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLearning = new System.Windows.Forms.Label();
            this.lblTesting = new System.Windows.Forms.Label();
            this.numTestBatchSize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNbBatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBatchSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTestBatchSize)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(3, 3);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(795, 537);
            this.txtOutput.TabIndex = 0;
            // 
            // cmdCompute
            // 
            this.cmdCompute.Location = new System.Drawing.Point(13, 547);
            this.cmdCompute.Name = "cmdCompute";
            this.cmdCompute.Size = new System.Drawing.Size(75, 23);
            this.cmdCompute.TabIndex = 1;
            this.cmdCompute.Text = "Calcul";
            this.cmdCompute.UseVisualStyleBackColor = true;
            this.cmdCompute.Click += new System.EventHandler(this.cmdCompute_Click);
            // 
            // Seed
            // 
            this.Seed.AutoSize = true;
            this.Seed.Location = new System.Drawing.Point(124, 552);
            this.Seed.Name = "Seed";
            this.Seed.Size = new System.Drawing.Size(32, 13);
            this.Seed.TabIndex = 3;
            this.Seed.Text = "Seed";
            // 
            // numSeed
            // 
            this.numSeed.Location = new System.Drawing.Point(171, 550);
            this.numSeed.Name = "numSeed";
            this.numSeed.Size = new System.Drawing.Size(47, 20);
            this.numSeed.TabIndex = 4;
            this.numSeed.Value = new decimal(new int[] {
            39,
            0,
            0,
            0});
            // 
            // prbProgress
            // 
            this.prbProgress.Location = new System.Drawing.Point(13, 576);
            this.prbProgress.Name = "prbProgress";
            this.prbProgress.Size = new System.Drawing.Size(774, 23);
            this.prbProgress.TabIndex = 5;
            this.prbProgress.Visible = false;
            // 
            // numNbBatches
            // 
            this.numNbBatches.Location = new System.Drawing.Point(313, 550);
            this.numNbBatches.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numNbBatches.Name = "numNbBatches";
            this.numNbBatches.Size = new System.Drawing.Size(47, 20);
            this.numNbBatches.TabIndex = 7;
            this.numNbBatches.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 552);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "NbBatches";
            // 
            // numBatchSize
            // 
            this.numBatchSize.Location = new System.Drawing.Point(433, 550);
            this.numBatchSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numBatchSize.Name = "numBatchSize";
            this.numBatchSize.Size = new System.Drawing.Size(47, 20);
            this.numBatchSize.TabIndex = 9;
            this.numBatchSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 552);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Batch size";
            // 
            // lblLearning
            // 
            this.lblLearning.AutoSize = true;
            this.lblLearning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLearning.Location = new System.Drawing.Point(246, 602);
            this.lblLearning.Name = "lblLearning";
            this.lblLearning.Size = new System.Drawing.Size(94, 20);
            this.lblLearning.TabIndex = 10;
            this.lblLearning.Text = "Learning...";
            this.lblLearning.Visible = false;
            // 
            // lblTesting
            // 
            this.lblTesting.AutoSize = true;
            this.lblTesting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTesting.Location = new System.Drawing.Point(445, 602);
            this.lblTesting.Name = "lblTesting";
            this.lblTesting.Size = new System.Drawing.Size(83, 20);
            this.lblTesting.TabIndex = 11;
            this.lblTesting.Text = "Testing...";
            this.lblTesting.Visible = false;
            // 
            // numTestBatchSize
            // 
            this.numTestBatchSize.Location = new System.Drawing.Point(616, 550);
            this.numTestBatchSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTestBatchSize.Name = "numTestBatchSize";
            this.numTestBatchSize.Size = new System.Drawing.Size(47, 20);
            this.numTestBatchSize.TabIndex = 13;
            this.numTestBatchSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(519, 552);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Testing batch size";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 624);
            this.Controls.Add(this.numTestBatchSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTesting);
            this.Controls.Add(this.lblLearning);
            this.Controls.Add(this.numBatchSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numNbBatches);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prbProgress);
            this.Controls.Add(this.numSeed);
            this.Controls.Add(this.Seed);
            this.Controls.Add(this.cmdCompute);
            this.Controls.Add(this.txtOutput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNbBatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBatchSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTestBatchSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button cmdCompute;
        private System.Windows.Forms.Label Seed;
        private System.Windows.Forms.NumericUpDown numSeed;
        private System.Windows.Forms.ProgressBar prbProgress;
        private System.Windows.Forms.NumericUpDown numNbBatches;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numBatchSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLearning;
        private System.Windows.Forms.Label lblTesting;
        private System.Windows.Forms.NumericUpDown numTestBatchSize;
        private System.Windows.Forms.Label label3;
    }
}

