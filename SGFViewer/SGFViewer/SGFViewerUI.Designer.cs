namespace SGFViewer
{
    partial class SGFViewerUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SGFViewerUI));
            this.boardControlsUI = new System.Windows.Forms.GroupBox();
            this.branchLabelUI = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.branchUpUI = new System.Windows.Forms.Button();
            this.branchDownUI = new System.Windows.Forms.Button();
            this.gotoMainBranchUI = new System.Windows.Forms.Button();
            this.branchEndUI = new System.Windows.Forms.Button();
            this.nextUI = new System.Windows.Forms.Button();
            this.previousUI = new System.Windows.Forms.Button();
            this.beginningUI = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.currentMoveUI = new System.Windows.Forms.TextBox();
            this.gamePropertiesUI = new System.Windows.Forms.GroupBox();
            this.whiteRankLabelUI = new System.Windows.Forms.Label();
            this.whiteNameLabelUI = new System.Windows.Forms.Label();
            this.blackRankLabelUI = new System.Windows.Forms.Label();
            this.blackNameLabelUI = new System.Windows.Forms.Label();
            this.resultLabelUI = new System.Windows.Forms.Label();
            this.gameLabelUI = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.loadFileUI = new System.Windows.Forms.Button();
            this.browseFilesUI = new System.Windows.Forms.Button();
            this.sourceFileUI = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.commentsUI = new System.Windows.Forms.ListBox();
            this.goBoardUI = new System.Windows.Forms.Panel();
            this.toBranchUI = new System.Windows.Forms.TextBox();
            this.boardControlsUI.SuspendLayout();
            this.gamePropertiesUI.SuspendLayout();
            this.SuspendLayout();
            // 
            // boardControlsUI
            // 
            this.boardControlsUI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boardControlsUI.Controls.Add(this.toBranchUI);
            this.boardControlsUI.Controls.Add(this.branchLabelUI);
            this.boardControlsUI.Controls.Add(this.label9);
            this.boardControlsUI.Controls.Add(this.branchUpUI);
            this.boardControlsUI.Controls.Add(this.branchDownUI);
            this.boardControlsUI.Controls.Add(this.gotoMainBranchUI);
            this.boardControlsUI.Controls.Add(this.branchEndUI);
            this.boardControlsUI.Controls.Add(this.nextUI);
            this.boardControlsUI.Controls.Add(this.previousUI);
            this.boardControlsUI.Controls.Add(this.beginningUI);
            this.boardControlsUI.Controls.Add(this.label1);
            this.boardControlsUI.Controls.Add(this.currentMoveUI);
            this.boardControlsUI.Location = new System.Drawing.Point(557, 450);
            this.boardControlsUI.Name = "boardControlsUI";
            this.boardControlsUI.Size = new System.Drawing.Size(335, 100);
            this.boardControlsUI.TabIndex = 1;
            this.boardControlsUI.TabStop = false;
            // 
            // branchLabelUI
            // 
            this.branchLabelUI.Location = new System.Drawing.Point(229, 13);
            this.branchLabelUI.Name = "branchLabelUI";
            this.branchLabelUI.ReadOnly = true;
            this.branchLabelUI.Size = new System.Drawing.Size(100, 20);
            this.branchLabelUI.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(181, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Branch:";
            // 
            // branchUpUI
            // 
            this.branchUpUI.Location = new System.Drawing.Point(175, 71);
            this.branchUpUI.Name = "branchUpUI";
            this.branchUpUI.Size = new System.Drawing.Size(75, 23);
            this.branchUpUI.TabIndex = 9;
            this.branchUpUI.Text = "Br. Up";
            this.branchUpUI.UseVisualStyleBackColor = true;
            this.branchUpUI.Click += new System.EventHandler(this.branchUpUI_Click);
            // 
            // branchDownUI
            // 
            this.branchDownUI.Location = new System.Drawing.Point(90, 71);
            this.branchDownUI.Name = "branchDownUI";
            this.branchDownUI.Size = new System.Drawing.Size(75, 23);
            this.branchDownUI.TabIndex = 8;
            this.branchDownUI.Text = "Br. Down";
            this.branchDownUI.UseVisualStyleBackColor = true;
            this.branchDownUI.Click += new System.EventHandler(this.branchDownUI_Click);
            // 
            // gotoMainBranchUI
            // 
            this.gotoMainBranchUI.Location = new System.Drawing.Point(9, 71);
            this.gotoMainBranchUI.Name = "gotoMainBranchUI";
            this.gotoMainBranchUI.Size = new System.Drawing.Size(75, 23);
            this.gotoMainBranchUI.TabIndex = 7;
            this.gotoMainBranchUI.Text = "Main Branch";
            this.gotoMainBranchUI.UseVisualStyleBackColor = true;
            // 
            // branchEndUI
            // 
            this.branchEndUI.Location = new System.Drawing.Point(254, 42);
            this.branchEndUI.Name = "branchEndUI";
            this.branchEndUI.Size = new System.Drawing.Size(75, 23);
            this.branchEndUI.TabIndex = 6;
            this.branchEndUI.Text = ">>>|";
            this.branchEndUI.UseVisualStyleBackColor = true;
            // 
            // nextUI
            // 
            this.nextUI.Location = new System.Drawing.Point(175, 42);
            this.nextUI.Name = "nextUI";
            this.nextUI.Size = new System.Drawing.Size(75, 23);
            this.nextUI.TabIndex = 5;
            this.nextUI.Text = ">";
            this.nextUI.UseVisualStyleBackColor = true;
            this.nextUI.Click += new System.EventHandler(this.nextUI_Click);
            // 
            // previousUI
            // 
            this.previousUI.Location = new System.Drawing.Point(90, 42);
            this.previousUI.Name = "previousUI";
            this.previousUI.Size = new System.Drawing.Size(75, 23);
            this.previousUI.TabIndex = 4;
            this.previousUI.Text = "<";
            this.previousUI.UseVisualStyleBackColor = true;
            this.previousUI.Click += new System.EventHandler(this.previousUI_Click);
            // 
            // beginningUI
            // 
            this.beginningUI.Location = new System.Drawing.Point(9, 42);
            this.beginningUI.Name = "beginningUI";
            this.beginningUI.Size = new System.Drawing.Size(75, 23);
            this.beginningUI.TabIndex = 3;
            this.beginningUI.Text = "| <<<";
            this.beginningUI.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Move:";
            // 
            // currentMoveUI
            // 
            this.currentMoveUI.Location = new System.Drawing.Point(90, 13);
            this.currentMoveUI.Name = "currentMoveUI";
            this.currentMoveUI.ReadOnly = true;
            this.currentMoveUI.Size = new System.Drawing.Size(75, 20);
            this.currentMoveUI.TabIndex = 0;
            // 
            // gamePropertiesUI
            // 
            this.gamePropertiesUI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gamePropertiesUI.Controls.Add(this.whiteRankLabelUI);
            this.gamePropertiesUI.Controls.Add(this.whiteNameLabelUI);
            this.gamePropertiesUI.Controls.Add(this.blackRankLabelUI);
            this.gamePropertiesUI.Controls.Add(this.blackNameLabelUI);
            this.gamePropertiesUI.Controls.Add(this.resultLabelUI);
            this.gamePropertiesUI.Controls.Add(this.gameLabelUI);
            this.gamePropertiesUI.Controls.Add(this.label8);
            this.gamePropertiesUI.Controls.Add(this.label7);
            this.gamePropertiesUI.Controls.Add(this.label6);
            this.gamePropertiesUI.Controls.Add(this.label5);
            this.gamePropertiesUI.Controls.Add(this.label4);
            this.gamePropertiesUI.Controls.Add(this.label3);
            this.gamePropertiesUI.Controls.Add(this.loadFileUI);
            this.gamePropertiesUI.Controls.Add(this.browseFilesUI);
            this.gamePropertiesUI.Controls.Add(this.sourceFileUI);
            this.gamePropertiesUI.Controls.Add(this.label2);
            this.gamePropertiesUI.Location = new System.Drawing.Point(557, 12);
            this.gamePropertiesUI.Name = "gamePropertiesUI";
            this.gamePropertiesUI.Size = new System.Drawing.Size(335, 162);
            this.gamePropertiesUI.TabIndex = 3;
            this.gamePropertiesUI.TabStop = false;
            // 
            // whiteRankLabelUI
            // 
            this.whiteRankLabelUI.AutoSize = true;
            this.whiteRankLabelUI.Location = new System.Drawing.Point(79, 116);
            this.whiteRankLabelUI.Name = "whiteRankLabelUI";
            this.whiteRankLabelUI.Size = new System.Drawing.Size(0, 13);
            this.whiteRankLabelUI.TabIndex = 15;
            // 
            // whiteNameLabelUI
            // 
            this.whiteNameLabelUI.AutoSize = true;
            this.whiteNameLabelUI.Location = new System.Drawing.Point(79, 103);
            this.whiteNameLabelUI.Name = "whiteNameLabelUI";
            this.whiteNameLabelUI.Size = new System.Drawing.Size(0, 13);
            this.whiteNameLabelUI.TabIndex = 14;
            // 
            // blackRankLabelUI
            // 
            this.blackRankLabelUI.AutoSize = true;
            this.blackRankLabelUI.Location = new System.Drawing.Point(79, 90);
            this.blackRankLabelUI.Name = "blackRankLabelUI";
            this.blackRankLabelUI.Size = new System.Drawing.Size(0, 13);
            this.blackRankLabelUI.TabIndex = 13;
            // 
            // blackNameLabelUI
            // 
            this.blackNameLabelUI.AutoSize = true;
            this.blackNameLabelUI.Location = new System.Drawing.Point(79, 77);
            this.blackNameLabelUI.Name = "blackNameLabelUI";
            this.blackNameLabelUI.Size = new System.Drawing.Size(0, 13);
            this.blackNameLabelUI.TabIndex = 12;
            // 
            // resultLabelUI
            // 
            this.resultLabelUI.AutoSize = true;
            this.resultLabelUI.Location = new System.Drawing.Point(79, 64);
            this.resultLabelUI.Name = "resultLabelUI";
            this.resultLabelUI.Size = new System.Drawing.Size(0, 13);
            this.resultLabelUI.TabIndex = 11;
            // 
            // gameLabelUI
            // 
            this.gameLabelUI.AutoSize = true;
            this.gameLabelUI.Location = new System.Drawing.Point(79, 51);
            this.gameLabelUI.Name = "gameLabelUI";
            this.gameLabelUI.Size = new System.Drawing.Size(0, 13);
            this.gameLabelUI.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Game:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Result:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Rank:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "White:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Rank:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Black:";
            // 
            // loadFileUI
            // 
            this.loadFileUI.Location = new System.Drawing.Point(254, 41);
            this.loadFileUI.Name = "loadFileUI";
            this.loadFileUI.Size = new System.Drawing.Size(75, 23);
            this.loadFileUI.TabIndex = 3;
            this.loadFileUI.Text = "Load";
            this.loadFileUI.UseVisualStyleBackColor = true;
            this.loadFileUI.Click += new System.EventHandler(this.loadFileUI_Click);
            // 
            // browseFilesUI
            // 
            this.browseFilesUI.Location = new System.Drawing.Point(254, 12);
            this.browseFilesUI.Name = "browseFilesUI";
            this.browseFilesUI.Size = new System.Drawing.Size(75, 23);
            this.browseFilesUI.TabIndex = 2;
            this.browseFilesUI.Text = "Browse";
            this.browseFilesUI.UseVisualStyleBackColor = true;
            this.browseFilesUI.Click += new System.EventHandler(this.browseFilesUI_Click);
            // 
            // sourceFileUI
            // 
            this.sourceFileUI.Location = new System.Drawing.Point(78, 14);
            this.sourceFileUI.Name = "sourceFileUI";
            this.sourceFileUI.ReadOnly = true;
            this.sourceFileUI.Size = new System.Drawing.Size(168, 20);
            this.sourceFileUI.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Source File:";
            // 
            // commentsUI
            // 
            this.commentsUI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commentsUI.FormattingEnabled = true;
            this.commentsUI.Location = new System.Drawing.Point(558, 180);
            this.commentsUI.Name = "commentsUI";
            this.commentsUI.Size = new System.Drawing.Size(334, 264);
            this.commentsUI.TabIndex = 4;
            // 
            // goBoardUI
            // 
            this.goBoardUI.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("goBoardUI.BackgroundImage")));
            this.goBoardUI.Location = new System.Drawing.Point(12, 12);
            this.goBoardUI.Name = "goBoardUI";
            this.goBoardUI.Size = new System.Drawing.Size(538, 538);
            this.goBoardUI.TabIndex = 5;
            this.goBoardUI.Paint += new System.Windows.Forms.PaintEventHandler(this.goBoardUI_Paint);
            // 
            // toBranchUI
            // 
            this.toBranchUI.Location = new System.Drawing.Point(254, 73);
            this.toBranchUI.Name = "toBranchUI";
            this.toBranchUI.ReadOnly = true;
            this.toBranchUI.Size = new System.Drawing.Size(75, 20);
            this.toBranchUI.TabIndex = 12;
            // 
            // SGFViewerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 562);
            this.Controls.Add(this.goBoardUI);
            this.Controls.Add(this.commentsUI);
            this.Controls.Add(this.gamePropertiesUI);
            this.Controls.Add(this.boardControlsUI);
            this.MaximumSize = new System.Drawing.Size(920, 600);
            this.MinimumSize = new System.Drawing.Size(920, 600);
            this.Name = "SGFViewerUI";
            this.Text = "SGFViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SGFViewerUI_FormClosing);
            this.boardControlsUI.ResumeLayout(false);
            this.boardControlsUI.PerformLayout();
            this.gamePropertiesUI.ResumeLayout(false);
            this.gamePropertiesUI.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boardControlsUI;
        private System.Windows.Forms.Button branchEndUI;
        private System.Windows.Forms.Button nextUI;
        private System.Windows.Forms.Button previousUI;
        private System.Windows.Forms.Button beginningUI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox currentMoveUI;
        private System.Windows.Forms.GroupBox gamePropertiesUI;
        private System.Windows.Forms.ListBox commentsUI;
        private System.Windows.Forms.Button browseFilesUI;
        private System.Windows.Forms.TextBox sourceFileUI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loadFileUI;
        private System.Windows.Forms.Button branchUpUI;
        private System.Windows.Forms.Button branchDownUI;
        private System.Windows.Forms.Button gotoMainBranchUI;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label whiteRankLabelUI;
        private System.Windows.Forms.Label whiteNameLabelUI;
        private System.Windows.Forms.Label blackRankLabelUI;
        private System.Windows.Forms.Label blackNameLabelUI;
        private System.Windows.Forms.Label resultLabelUI;
        private System.Windows.Forms.Label gameLabelUI;
        private System.Windows.Forms.Panel goBoardUI;
        private System.Windows.Forms.TextBox branchLabelUI;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox toBranchUI;
    }
}

