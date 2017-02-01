namespace ZebraTestPrint
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
            this.cboPrinterName = new System.Windows.Forms.ComboBox();
            this.lblPrinter = new System.Windows.Forms.Label();
            this.btnTestPrint = new System.Windows.Forms.Button();
            this.btnCOMTest = new System.Windows.Forms.Button();
            this.lblCOMPorts = new System.Windows.Forms.Label();
            this.cboPorts = new System.Windows.Forms.ComboBox();
            this.rbCPCL = new System.Windows.Forms.RadioButton();
            this.rbZPL = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // cboPrinterName
            // 
            this.cboPrinterName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPrinterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinterName.FormattingEnabled = true;
            this.cboPrinterName.Location = new System.Drawing.Point(72, 14);
            this.cboPrinterName.MaxDropDownItems = 100;
            this.cboPrinterName.Name = "cboPrinterName";
            this.cboPrinterName.Size = new System.Drawing.Size(345, 24);
            this.cboPrinterName.Sorted = true;
            this.cboPrinterName.TabIndex = 0;
            // 
            // lblPrinter
            // 
            this.lblPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrinter.AutoSize = true;
            this.lblPrinter.Location = new System.Drawing.Point(12, 15);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(54, 17);
            this.lblPrinter.TabIndex = 1;
            this.lblPrinter.Text = "Printer:";
            // 
            // btnTestPrint
            // 
            this.btnTestPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestPrint.Location = new System.Drawing.Point(278, 54);
            this.btnTestPrint.Name = "btnTestPrint";
            this.btnTestPrint.Size = new System.Drawing.Size(139, 80);
            this.btnTestPrint.TabIndex = 2;
            this.btnTestPrint.Text = "Test";
            this.btnTestPrint.UseVisualStyleBackColor = true;
            this.btnTestPrint.Click += new System.EventHandler(this.btnTestPrint_Click);
            // 
            // btnCOMTest
            // 
            this.btnCOMTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCOMTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCOMTest.Location = new System.Drawing.Point(278, 201);
            this.btnCOMTest.Name = "btnCOMTest";
            this.btnCOMTest.Size = new System.Drawing.Size(139, 80);
            this.btnCOMTest.TabIndex = 3;
            this.btnCOMTest.Text = "COM";
            this.btnCOMTest.UseVisualStyleBackColor = true;
            this.btnCOMTest.Click += new System.EventHandler(this.btnCOMTest_Click);
            // 
            // lblCOMPorts
            // 
            this.lblCOMPorts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCOMPorts.AutoSize = true;
            this.lblCOMPorts.Location = new System.Drawing.Point(12, 164);
            this.lblCOMPorts.Name = "lblCOMPorts";
            this.lblCOMPorts.Size = new System.Drawing.Size(43, 17);
            this.lblCOMPorts.TabIndex = 5;
            this.lblCOMPorts.Text = "COM:";
            // 
            // cboPorts
            // 
            this.cboPorts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPorts.FormattingEnabled = true;
            this.cboPorts.Location = new System.Drawing.Point(72, 163);
            this.cboPorts.MaxDropDownItems = 100;
            this.cboPorts.Name = "cboPorts";
            this.cboPorts.Size = new System.Drawing.Size(338, 24);
            this.cboPorts.Sorted = true;
            this.cboPorts.TabIndex = 4;
            // 
            // rbCPCL
            // 
            this.rbCPCL.AutoSize = true;
            this.rbCPCL.Checked = true;
            this.rbCPCL.Location = new System.Drawing.Point(58, 215);
            this.rbCPCL.Name = "rbCPCL";
            this.rbCPCL.Size = new System.Drawing.Size(64, 21);
            this.rbCPCL.TabIndex = 6;
            this.rbCPCL.TabStop = true;
            this.rbCPCL.Text = "CPCL";
            this.rbCPCL.UseVisualStyleBackColor = true;
            // 
            // rbZPL
            // 
            this.rbZPL.AutoSize = true;
            this.rbZPL.Location = new System.Drawing.Point(58, 237);
            this.rbZPL.Name = "rbZPL";
            this.rbZPL.Size = new System.Drawing.Size(55, 21);
            this.rbZPL.TabIndex = 7;
            this.rbZPL.Text = "ZPL";
            this.rbZPL.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 293);
            this.Controls.Add(this.rbZPL);
            this.Controls.Add(this.rbCPCL);
            this.Controls.Add(this.lblCOMPorts);
            this.Controls.Add(this.cboPorts);
            this.Controls.Add(this.btnCOMTest);
            this.Controls.Add(this.btnTestPrint);
            this.Controls.Add(this.lblPrinter);
            this.Controls.Add(this.cboPrinterName);
            this.Name = "Form1";
            this.Text = "Zebra Print Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPrinterName;
        private System.Windows.Forms.Label lblPrinter;
        private System.Windows.Forms.Button btnTestPrint;
        private System.Windows.Forms.Button btnCOMTest;
        private System.Windows.Forms.Label lblCOMPorts;
        private System.Windows.Forms.ComboBox cboPorts;
        private System.Windows.Forms.RadioButton rbCPCL;
        private System.Windows.Forms.RadioButton rbZPL;
    }
}

