namespace SimpleJobTrackerForms
{
    partial class Dashboard
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
            jobOfferDtoBindingSource = new BindingSource(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            jobOfferDtoBindingSource1 = new BindingSource(components);
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)jobOfferDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jobOfferDtoBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // jobOfferDtoBindingSource
            // 
            jobOfferDtoBindingSource.DataSource = typeof(SimpleJobTrackerAPI.Data.JobOfferDto);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.DataBindings.Add(new Binding("DataContext", jobOfferDtoBindingSource, "Position", true));
            tableLayoutPanel1.Location = new Point(72, 42);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(662, 125);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // jobOfferDtoBindingSource1
            // 
            jobOfferDtoBindingSource1.DataSource = typeof(SimpleJobTrackerAPI.Data.JobOfferDto);
            // 
            // button1
            // 
            button1.Location = new Point(305, 240);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(tableLayoutPanel1);
            Name = "Dashboard";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)jobOfferDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)jobOfferDtoBindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource jobOfferDtoBindingSource;
        private TableLayoutPanel tableLayoutPanel1;
        private BindingSource jobOfferDtoBindingSource1;
        private Button button1;
    }
}