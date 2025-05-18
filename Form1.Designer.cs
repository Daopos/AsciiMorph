namespace AsciiMorph
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            numInputsSelector = new NumericUpDown();
            lblInputCount = new Label();
            lblSerialNo = new Label();
            symbolInputPanel = new FlowLayoutPanel();
            lblPattern = new Label();
            txtPattern = new TextBox();
            btnGenerate = new Button();
            btnClear = new Button();
            lblOutputTitle = new Label();
            lblOutput = new TextBox();
            mainLayout = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)numInputsSelector).BeginInit();
            mainLayout.SuspendLayout();
            SuspendLayout();
            // 
            // numInputsSelector
            // 
            numInputsSelector.BackColor = Color.White;
            numInputsSelector.Font = new Font("Segoe UI", 13F);
            numInputsSelector.ForeColor = Color.Black;
            numInputsSelector.Location = new Point(184, 13);
            numInputsSelector.Maximum = new decimal(new int[] { 25, 0, 0, 0 });
            numInputsSelector.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numInputsSelector.Name = "numInputsSelector";
            numInputsSelector.Size = new Size(128, 31);
            numInputsSelector.TabIndex = 1;
            numInputsSelector.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numInputsSelector.ValueChanged += NumInputsSelector_ValueChanged;
            // 
            // lblInputCount
            // 
            lblInputCount.Dock = DockStyle.Fill;
            lblInputCount.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblInputCount.ForeColor = Color.FromArgb(51, 51, 51);
            lblInputCount.Location = new Point(13, 10);
            lblInputCount.Name = "lblInputCount";
            lblInputCount.Size = new Size(165, 40);
            lblInputCount.TabIndex = 0;
            lblInputCount.Text = "Number of Columns:";
            lblInputCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSerialNo
            // 
            mainLayout.SetColumnSpan(lblSerialNo, 2);
            lblSerialNo.Dock = DockStyle.Fill;
            lblSerialNo.Font = new Font("Segoe UI", 12F);
            lblSerialNo.ForeColor = Color.FromArgb(51, 51, 51);
            lblSerialNo.Location = new Point(13, 50);
            lblSerialNo.Name = "lblSerialNo";
            lblSerialNo.Size = new Size(774, 40);
            lblSerialNo.TabIndex = 8;
            lblSerialNo.Text = "SERIAL NO:";
            lblSerialNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // symbolInputPanel
            // 
            symbolInputPanel.AutoScroll = true;
            symbolInputPanel.BackColor = Color.FromArgb(245, 245, 245);
            symbolInputPanel.BorderStyle = BorderStyle.FixedSingle;
            mainLayout.SetColumnSpan(symbolInputPanel, 2);
            symbolInputPanel.Dock = DockStyle.Fill;
            symbolInputPanel.Location = new Point(13, 93);
            symbolInputPanel.Name = "symbolInputPanel";
            symbolInputPanel.Padding = new Padding(10);
            symbolInputPanel.Size = new Size(774, 194);
            symbolInputPanel.TabIndex = 2;
            // 
            // lblPattern
            // 
            lblPattern.Dock = DockStyle.Fill;
            lblPattern.Font = new Font("Segoe UI", 15F);
            lblPattern.ForeColor = Color.FromArgb(51, 51, 51);
            lblPattern.Location = new Point(13, 290);
            lblPattern.Name = "lblPattern";
            lblPattern.Size = new Size(165, 40);
            lblPattern.TabIndex = 3;
            lblPattern.Text = "Pattern Value:";
            lblPattern.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPattern
            // 
            txtPattern.BackColor = Color.White;
            txtPattern.Dock = DockStyle.Fill;
            txtPattern.Font = new Font("Segoe UI", 14F);
            txtPattern.ForeColor = Color.Black;
            txtPattern.Location = new Point(184, 293);
            txtPattern.Name = "txtPattern";
            txtPattern.Size = new Size(603, 32);
            txtPattern.TabIndex = 4;
            txtPattern.Text = "1";
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.FromArgb(0, 123, 255);
            btnGenerate.Dock = DockStyle.Fill;
            btnGenerate.FlatAppearance.BorderSize = 0;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGenerate.ForeColor = Color.White;
            btnGenerate.Location = new Point(184, 333);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(603, 44);
            btnGenerate.TabIndex = 5;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(220, 53, 69);
            btnClear.Dock = DockStyle.Fill;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(184, 463);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(603, 44);
            btnClear.TabIndex = 9;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += BtnClear_Click;
            // 
            // lblOutputTitle
            // 
            lblOutputTitle.Dock = DockStyle.Fill;
            lblOutputTitle.Font = new Font("Segoe UI", 15F);
            lblOutputTitle.ForeColor = Color.FromArgb(51, 51, 51);
            lblOutputTitle.Location = new Point(13, 380);
            lblOutputTitle.Name = "lblOutputTitle";
            lblOutputTitle.Size = new Size(165, 80);
            lblOutputTitle.TabIndex = 6;
            lblOutputTitle.Text = "Output:";
            lblOutputTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOutput
            // 
            lblOutput.BackColor = Color.White;
            lblOutput.BorderStyle = BorderStyle.FixedSingle;
            lblOutput.Dock = DockStyle.Fill;
            lblOutput.Font = new Font("Consolas", 14F);
            lblOutput.ForeColor = Color.FromArgb(51, 51, 51);
            lblOutput.Location = new Point(184, 383);
            lblOutput.Multiline = true;
            lblOutput.Name = "lblOutput";
            lblOutput.ReadOnly = true;
            lblOutput.Size = new Size(603, 74);
            lblOutput.TabIndex = 7;
            lblOutput.TextAlign = HorizontalAlignment.Center;
            // 
            // mainLayout
            // 
            mainLayout.BackColor = Color.White;
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.05F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.95F));
            mainLayout.Controls.Add(lblInputCount, 0, 0);
            mainLayout.Controls.Add(numInputsSelector, 1, 0);
            mainLayout.Controls.Add(lblSerialNo, 0, 1);
            mainLayout.Controls.Add(symbolInputPanel, 0, 2);
            mainLayout.Controls.Add(lblPattern, 0, 3);
            mainLayout.Controls.Add(txtPattern, 1, 3);
            mainLayout.Controls.Add(btnGenerate, 1, 4);
            mainLayout.Controls.Add(lblOutputTitle, 0, 5);
            mainLayout.Controls.Add(lblOutput, 1, 5);
            mainLayout.Controls.Add(btnClear, 1, 6);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.Padding = new Padding(10);
            mainLayout.RowCount = 8;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Size = new Size(800, 600);
            mainLayout.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 600);
            Controls.Add(mainLayout);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(600, 400);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AsciiMorph";
            ((System.ComponentModel.ISupportInitialize)numInputsSelector).EndInit();
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.NumericUpDown numInputsSelector;
        private System.Windows.Forms.Label lblInputCount;
        private System.Windows.Forms.Label lblSerialNo;
        private System.Windows.Forms.FlowLayoutPanel symbolInputPanel;
        private System.Windows.Forms.Label lblPattern;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnClear; // <--- Added this
        private System.Windows.Forms.Label lblOutputTitle;
        private System.Windows.Forms.TextBox lblOutput;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
    }
}
