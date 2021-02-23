namespace prjWinCsRemax2013417
{
    partial class frmSearch
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
            this.radioHouse = new System.Windows.Forms.RadioButton();
            this.radioAgent = new System.Windows.Forms.RadioButton();
            this.comboBoxHouses = new System.Windows.Forms.ComboBox();
            this.comboBoxAgents = new System.Windows.Forms.ComboBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.gridResult = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).BeginInit();
            this.SuspendLayout();
            // 
            // radioHouse
            // 
            this.radioHouse.AutoSize = true;
            this.radioHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioHouse.Location = new System.Drawing.Point(42, 13);
            this.radioHouse.Name = "radioHouse";
            this.radioHouse.Size = new System.Drawing.Size(87, 22);
            this.radioHouse.TabIndex = 0;
            this.radioHouse.Text = "Houses";
            this.radioHouse.UseVisualStyleBackColor = true;
            this.radioHouse.CheckedChanged += new System.EventHandler(this.radioHouse_CheckedChanged_1);
            // 
            // radioAgent
            // 
            this.radioAgent.AutoSize = true;
            this.radioAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAgent.Location = new System.Drawing.Point(42, 50);
            this.radioAgent.Name = "radioAgent";
            this.radioAgent.Size = new System.Drawing.Size(80, 22);
            this.radioAgent.TabIndex = 1;
            this.radioAgent.Text = "Agents";
            this.radioAgent.UseVisualStyleBackColor = true;
            this.radioAgent.CheckedChanged += new System.EventHandler(this.radioAgent_CheckedChanged_1);
            // 
            // comboBoxHouses
            // 
            this.comboBoxHouses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxHouses.FormattingEnabled = true;
            this.comboBoxHouses.Location = new System.Drawing.Point(172, 13);
            this.comboBoxHouses.Name = "comboBoxHouses";
            this.comboBoxHouses.Size = new System.Drawing.Size(121, 26);
            this.comboBoxHouses.TabIndex = 2;
            // 
            // comboBoxAgents
            // 
            this.comboBoxAgents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAgents.FormattingEnabled = true;
            this.comboBoxAgents.Location = new System.Drawing.Point(172, 50);
            this.comboBoxAgents.Name = "comboBoxAgents";
            this.comboBoxAgents.Size = new System.Drawing.Size(121, 26);
            this.comboBoxAgents.TabIndex = 3;
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(364, 35);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(94, 36);
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "FIND";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // gridResult
            // 
            this.gridResult.AllowUserToAddRows = false;
            this.gridResult.AllowUserToDeleteRows = false;
            this.gridResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridResult.Location = new System.Drawing.Point(12, 98);
            this.gridResult.Name = "gridResult";
            this.gridResult.ReadOnly = true;
            this.gridResult.RowTemplate.Height = 24;
            this.gridResult.Size = new System.Drawing.Size(776, 340);
            this.gridResult.TabIndex = 5;
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridResult);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.comboBoxAgents);
            this.Controls.Add(this.comboBoxHouses);
            this.Controls.Add(this.radioAgent);
            this.Controls.Add(this.radioHouse);
            this.Name = "frmSearch";
            this.Text = "frmSearch";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioHouse;
        private System.Windows.Forms.RadioButton radioAgent;
        private System.Windows.Forms.ComboBox comboBoxHouses;
        private System.Windows.Forms.ComboBox comboBoxAgents;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.DataGridView gridResult;
    }
}