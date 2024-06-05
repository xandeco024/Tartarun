namespace Tartarun2
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            clock = new System.Windows.Forms.Timer(components);
            mainMenuPanel = new Panel();
            quitBtn = new Button();
            creditsBtn = new Button();
            turtlesBtn = new Button();
            betBtn = new Button();
            pictureBox1 = new PictureBox();
            subtitleLbl = new Label();
            titleLbl = new Label();
            startBtn = new Button();
            creditsPanel = new Panel();
            creditName3Lbl = new Label();
            creditName0Lbl = new Label();
            creditName2Lbl = new Label();
            creditName1Lbl = new Label();
            creditsBackBtn = new Button();
            label2 = new Label();
            label1 = new Label();
            turtlePanel = new Panel();
            turtleCreationTurtle = new Label();
            turtleListPanel = new Panel();
            turtleListBox = new ListBox();
            turtleCreationPanel = new Panel();
            label3 = new Label();
            textBox1 = new TextBox();
            mainMenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            creditsPanel.SuspendLayout();
            turtlePanel.SuspendLayout();
            turtleListPanel.SuspendLayout();
            turtleCreationPanel.SuspendLayout();
            SuspendLayout();
            // 
            // clock
            // 
            clock.Enabled = true;
            clock.Interval = 1;
            clock.Tick += clock_Tick;
            // 
            // mainMenuPanel
            // 
            mainMenuPanel.Controls.Add(quitBtn);
            mainMenuPanel.Controls.Add(creditsBtn);
            mainMenuPanel.Controls.Add(turtlesBtn);
            mainMenuPanel.Controls.Add(betBtn);
            mainMenuPanel.Controls.Add(pictureBox1);
            mainMenuPanel.Controls.Add(subtitleLbl);
            mainMenuPanel.Controls.Add(titleLbl);
            mainMenuPanel.Controls.Add(startBtn);
            mainMenuPanel.Dock = DockStyle.Fill;
            mainMenuPanel.Font = new Font("Upheaval TT (BRK)", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            mainMenuPanel.Location = new Point(0, 0);
            mainMenuPanel.Margin = new Padding(3, 2, 3, 2);
            mainMenuPanel.Name = "mainMenuPanel";
            mainMenuPanel.Size = new Size(1264, 681);
            mainMenuPanel.TabIndex = 1;
            // 
            // quitBtn
            // 
            quitBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            quitBtn.Font = new Font("Upheaval TT (BRK)", 26.2499962F, FontStyle.Regular, GraphicsUnit.Point);
            quitBtn.Location = new Point(135, 574);
            quitBtn.Margin = new Padding(3, 2, 3, 2);
            quitBtn.Name = "quitBtn";
            quitBtn.Size = new Size(320, 50);
            quitBtn.TabIndex = 16;
            quitBtn.Text = "SAIR";
            quitBtn.UseVisualStyleBackColor = true;
            quitBtn.Click += quitBtn_Click;
            // 
            // creditsBtn
            // 
            creditsBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            creditsBtn.Font = new Font("Upheaval TT (BRK)", 26.2499962F, FontStyle.Regular, GraphicsUnit.Point);
            creditsBtn.Location = new Point(135, 493);
            creditsBtn.Margin = new Padding(3, 2, 3, 2);
            creditsBtn.Name = "creditsBtn";
            creditsBtn.Size = new Size(320, 50);
            creditsBtn.TabIndex = 15;
            creditsBtn.Text = "CREDITOS";
            creditsBtn.UseVisualStyleBackColor = true;
            creditsBtn.Click += creditsBtn_Click;
            // 
            // turtlesBtn
            // 
            turtlesBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            turtlesBtn.Font = new Font("Upheaval TT (BRK)", 26.2499962F, FontStyle.Regular, GraphicsUnit.Point);
            turtlesBtn.Location = new Point(135, 412);
            turtlesBtn.Margin = new Padding(3, 2, 3, 2);
            turtlesBtn.Name = "turtlesBtn";
            turtlesBtn.Size = new Size(320, 50);
            turtlesBtn.TabIndex = 14;
            turtlesBtn.Text = "TARTARUGAS";
            turtlesBtn.UseVisualStyleBackColor = true;
            // 
            // betBtn
            // 
            betBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            betBtn.Font = new Font("Upheaval TT (BRK)", 26.2499962F, FontStyle.Regular, GraphicsUnit.Point);
            betBtn.Location = new Point(135, 331);
            betBtn.Margin = new Padding(3, 2, 3, 2);
            betBtn.Name = "betBtn";
            betBtn.Size = new Size(320, 50);
            betBtn.TabIndex = 13;
            betBtn.Text = "APOSTAR";
            betBtn.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = Properties.Resources.tartaruga_export;
            pictureBox1.Location = new Point(690, 112);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(512, 512);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // subtitleLbl
            // 
            subtitleLbl.AutoSize = true;
            subtitleLbl.Font = new Font("Upheaval TT (BRK)", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            subtitleLbl.Location = new Point(100, 132);
            subtitleLbl.Name = "subtitleLbl";
            subtitleLbl.Size = new Size(399, 22);
            subtitleLbl.TabIndex = 10;
            subtitleLbl.Text = "a corrida mais rápida de todas";
            // 
            // titleLbl
            // 
            titleLbl.AutoSize = true;
            titleLbl.Font = new Font("Upheaval TT (BRK)", 63.7499924F, FontStyle.Regular, GraphicsUnit.Point);
            titleLbl.Location = new Point(84, 55);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(433, 77);
            titleLbl.TabIndex = 11;
            titleLbl.Text = "tartarun";
            // 
            // startBtn
            // 
            startBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            startBtn.Font = new Font("Upheaval TT (BRK)", 26.2499962F, FontStyle.Regular, GraphicsUnit.Point);
            startBtn.Location = new Point(135, 250);
            startBtn.Margin = new Padding(3, 2, 3, 2);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(320, 50);
            startBtn.TabIndex = 9;
            startBtn.Text = "Iniciar";
            startBtn.UseVisualStyleBackColor = true;
            // 
            // creditsPanel
            // 
            creditsPanel.Controls.Add(creditName3Lbl);
            creditsPanel.Controls.Add(creditName0Lbl);
            creditsPanel.Controls.Add(creditName2Lbl);
            creditsPanel.Controls.Add(creditName1Lbl);
            creditsPanel.Controls.Add(creditsBackBtn);
            creditsPanel.Controls.Add(label2);
            creditsPanel.Controls.Add(label1);
            creditsPanel.Dock = DockStyle.Fill;
            creditsPanel.Location = new Point(0, 0);
            creditsPanel.Name = "creditsPanel";
            creditsPanel.Size = new Size(1264, 681);
            creditsPanel.TabIndex = 17;
            // 
            // creditName3Lbl
            // 
            creditName3Lbl.AutoSize = true;
            creditName3Lbl.Font = new Font("Upheaval TT (BRK)", 21.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            creditName3Lbl.Location = new Point(84, 303);
            creditName3Lbl.Name = "creditName3Lbl";
            creditName3Lbl.Size = new Size(206, 26);
            creditName3Lbl.TabIndex = 18;
            creditName3Lbl.Text = "William luz ";
            // 
            // creditName0Lbl
            // 
            creditName0Lbl.AutoSize = true;
            creditName0Lbl.Font = new Font("Upheaval TT (BRK)", 21.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            creditName0Lbl.Location = new Point(84, 182);
            creditName0Lbl.Name = "creditName0Lbl";
            creditName0Lbl.Size = new Size(352, 26);
            creditName0Lbl.TabIndex = 17;
            creditName0Lbl.Text = "FELIPE VIEIRA CANALLE";
            // 
            // creditName2Lbl
            // 
            creditName2Lbl.AutoSize = true;
            creditName2Lbl.Font = new Font("Upheaval TT (BRK)", 21.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            creditName2Lbl.Location = new Point(84, 264);
            creditName2Lbl.Name = "creditName2Lbl";
            creditName2Lbl.Size = new Size(266, 26);
            creditName2Lbl.TabIndex = 16;
            creditName2Lbl.Text = "IORI SOUZA LEITE";
            // 
            // creditName1Lbl
            // 
            creditName1Lbl.AutoSize = true;
            creditName1Lbl.Font = new Font("Upheaval TT (BRK)", 21.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            creditName1Lbl.Location = new Point(84, 222);
            creditName1Lbl.Name = "creditName1Lbl";
            creditName1Lbl.Size = new Size(532, 26);
            creditName1Lbl.TabIndex = 15;
            creditName1Lbl.Text = "GABRIEL ALEXANDER PINHEIRO BRAVO";
            // 
            // creditsBackBtn
            // 
            creditsBackBtn.Font = new Font("Upheaval TT (BRK)", 21.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            creditsBackBtn.Location = new Point(84, 562);
            creditsBackBtn.Name = "creditsBackBtn";
            creditsBackBtn.Size = new Size(182, 62);
            creditsBackBtn.TabIndex = 14;
            creditsBackBtn.Text = "VOLTAR";
            creditsBackBtn.UseVisualStyleBackColor = true;
            creditsBackBtn.Click += creditsBackBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Upheaval TT (BRK)", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(416, 86);
            label2.Name = "label2";
            label2.Size = new Size(399, 22);
            label2.TabIndex = 13;
            label2.Text = "a corrida mais rápida de todas";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Upheaval TT (BRK)", 63.7499924F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(397, 9);
            label1.Name = "label1";
            label1.Size = new Size(433, 77);
            label1.TabIndex = 12;
            label1.Text = "tartarun";
            // 
            // turtlePanel
            // 
            turtlePanel.Controls.Add(turtleCreationPanel);
            turtlePanel.Controls.Add(turtleListPanel);
            turtlePanel.Dock = DockStyle.Fill;
            turtlePanel.Location = new Point(0, 0);
            turtlePanel.Name = "turtlePanel";
            turtlePanel.Size = new Size(1264, 681);
            turtlePanel.TabIndex = 17;
            // 
            // turtleCreationTurtle
            // 
            turtleCreationTurtle.AutoSize = true;
            turtleCreationTurtle.Font = new Font("Upheaval TT (BRK)", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            turtleCreationTurtle.Location = new Point(98, 44);
            turtleCreationTurtle.Name = "turtleCreationTurtle";
            turtleCreationTurtle.Size = new Size(243, 22);
            turtleCreationTurtle.TabIndex = 0;
            turtleCreationTurtle.Text = "tartaruga numero 1";
            // 
            // turtleListPanel
            // 
            turtleListPanel.Controls.Add(turtleListBox);
            turtleListPanel.Dock = DockStyle.Left;
            turtleListPanel.Location = new Point(0, 0);
            turtleListPanel.Name = "turtleListPanel";
            turtleListPanel.Size = new Size(216, 681);
            turtleListPanel.TabIndex = 1;
            // 
            // turtleListBox
            // 
            turtleListBox.Dock = DockStyle.Fill;
            turtleListBox.FormattingEnabled = true;
            turtleListBox.ItemHeight = 11;
            turtleListBox.Location = new Point(0, 0);
            turtleListBox.Name = "turtleListBox";
            turtleListBox.Size = new Size(216, 681);
            turtleListBox.TabIndex = 0;
            // 
            // turtleCreationPanel
            // 
            turtleCreationPanel.Controls.Add(textBox1);
            turtleCreationPanel.Controls.Add(label3);
            turtleCreationPanel.Controls.Add(turtleCreationTurtle);
            turtleCreationPanel.Dock = DockStyle.Fill;
            turtleCreationPanel.Location = new Point(216, 0);
            turtleCreationPanel.Name = "turtleCreationPanel";
            turtleCreationPanel.Size = new Size(1048, 681);
            turtleCreationPanel.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Upheaval TT (BRK)", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(100, 101);
            label3.Name = "label3";
            label3.Size = new Size(69, 22);
            label3.TabIndex = 1;
            label3.Text = "Nome";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(100, 132);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(241, 19);
            textBox1.TabIndex = 2;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 11F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(turtlePanel);
            Controls.Add(mainMenuPanel);
            Controls.Add(creditsPanel);
            Font = new Font("Upheaval TT (BRK)", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Main";
            Text = "Form1";
            mainMenuPanel.ResumeLayout(false);
            mainMenuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            creditsPanel.ResumeLayout(false);
            creditsPanel.PerformLayout();
            turtlePanel.ResumeLayout(false);
            turtleListPanel.ResumeLayout(false);
            turtleCreationPanel.ResumeLayout(false);
            turtleCreationPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer clock;
        private Panel mainMenuPanel;
        private Button quitBtn;
        private Button creditsBtn;
        private Button turtlesBtn;
        private Button betBtn;
        private PictureBox pictureBox1;
        private Label subtitleLbl;
        private Label titleLbl;
        private Button startBtn;
        private Panel creditsPanel;
        private Label creditName3Lbl;
        private Label creditName0Lbl;
        private Label creditName2Lbl;
        private Label creditName1Lbl;
        private Button creditsBackBtn;
        private Label label2;
        private Label label1;
        private Panel turtlePanel;
        private Label turtleCreationTurtle;
        private Panel turtleCreationPanel;
        private Panel turtleListPanel;
        private ListBox turtleListBox;
        private TextBox textBox1;
        private Label label3;
    }
}