namespace ComputerCourse
{
    partial class student
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
            this.components = new System.ComponentModel.Container();
            this.studentRegistrationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.computerCourseDataSet1 = new ComputerCourse.ComputerCourseDataSet1();
            this.studentRegistrationTableAdapter = new ComputerCourse.ComputerCourseDataSet1TableAdapters.StudentRegistrationTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.computerCourseDataSet5 = new ComputerCourse.ComputerCourseDataSet5();
            this.addQuestionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.addQuestionsTableAdapter = new ComputerCourse.ComputerCourseDataSet5TableAdapters.AddQuestionsTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enterQueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correctAnsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.studentRegistrationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerCourseDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerCourseDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addQuestionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // studentRegistrationBindingSource
            // 
            this.studentRegistrationBindingSource.DataMember = "StudentRegistration";
            this.studentRegistrationBindingSource.DataSource = this.computerCourseDataSet1;
            // 
            // computerCourseDataSet1
            // 
            this.computerCourseDataSet1.DataSetName = "ComputerCourseDataSet1";
            this.computerCourseDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // studentRegistrationTableAdapter
            // 
            this.studentRegistrationTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.durationDataGridViewTextBoxColumn,
            this.courseDataGridViewTextBoxColumn,
            this.enterQueDataGridViewTextBoxColumn,
            this.optionADataGridViewTextBoxColumn,
            this.optionBDataGridViewTextBoxColumn,
            this.optionCDataGridViewTextBoxColumn,
            this.optionDDataGridViewTextBoxColumn,
            this.correctAnsDataGridViewTextBoxColumn,
            this.marksDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.addQuestionsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(-1, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1426, 328);
            this.dataGridView1.TabIndex = 0;
            // 
            // computerCourseDataSet5
            // 
            this.computerCourseDataSet5.DataSetName = "ComputerCourseDataSet5";
            this.computerCourseDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // addQuestionsBindingSource
            // 
            this.addQuestionsBindingSource.DataMember = "AddQuestions";
            this.addQuestionsBindingSource.DataSource = this.computerCourseDataSet5;
            // 
            // addQuestionsTableAdapter
            // 
            this.addQuestionsTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 150;
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
            this.durationDataGridViewTextBoxColumn.HeaderText = "Duration";
            this.durationDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            this.durationDataGridViewTextBoxColumn.Width = 150;
            // 
            // courseDataGridViewTextBoxColumn
            // 
            this.courseDataGridViewTextBoxColumn.DataPropertyName = "Course";
            this.courseDataGridViewTextBoxColumn.HeaderText = "Course";
            this.courseDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.courseDataGridViewTextBoxColumn.Name = "courseDataGridViewTextBoxColumn";
            this.courseDataGridViewTextBoxColumn.Width = 150;
            // 
            // enterQueDataGridViewTextBoxColumn
            // 
            this.enterQueDataGridViewTextBoxColumn.DataPropertyName = "EnterQue";
            this.enterQueDataGridViewTextBoxColumn.HeaderText = "EnterQue";
            this.enterQueDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.enterQueDataGridViewTextBoxColumn.Name = "enterQueDataGridViewTextBoxColumn";
            this.enterQueDataGridViewTextBoxColumn.Width = 150;
            // 
            // optionADataGridViewTextBoxColumn
            // 
            this.optionADataGridViewTextBoxColumn.DataPropertyName = "OptionA";
            this.optionADataGridViewTextBoxColumn.HeaderText = "OptionA";
            this.optionADataGridViewTextBoxColumn.MinimumWidth = 8;
            this.optionADataGridViewTextBoxColumn.Name = "optionADataGridViewTextBoxColumn";
            this.optionADataGridViewTextBoxColumn.Width = 150;
            // 
            // optionBDataGridViewTextBoxColumn
            // 
            this.optionBDataGridViewTextBoxColumn.DataPropertyName = "OptionB";
            this.optionBDataGridViewTextBoxColumn.HeaderText = "OptionB";
            this.optionBDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.optionBDataGridViewTextBoxColumn.Name = "optionBDataGridViewTextBoxColumn";
            this.optionBDataGridViewTextBoxColumn.Width = 150;
            // 
            // optionCDataGridViewTextBoxColumn
            // 
            this.optionCDataGridViewTextBoxColumn.DataPropertyName = "OptionC";
            this.optionCDataGridViewTextBoxColumn.HeaderText = "OptionC";
            this.optionCDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.optionCDataGridViewTextBoxColumn.Name = "optionCDataGridViewTextBoxColumn";
            this.optionCDataGridViewTextBoxColumn.Width = 150;
            // 
            // optionDDataGridViewTextBoxColumn
            // 
            this.optionDDataGridViewTextBoxColumn.DataPropertyName = "OptionD";
            this.optionDDataGridViewTextBoxColumn.HeaderText = "OptionD";
            this.optionDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.optionDDataGridViewTextBoxColumn.Name = "optionDDataGridViewTextBoxColumn";
            this.optionDDataGridViewTextBoxColumn.Width = 150;
            // 
            // correctAnsDataGridViewTextBoxColumn
            // 
            this.correctAnsDataGridViewTextBoxColumn.DataPropertyName = "CorrectAns";
            this.correctAnsDataGridViewTextBoxColumn.HeaderText = "CorrectAns";
            this.correctAnsDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.correctAnsDataGridViewTextBoxColumn.Name = "correctAnsDataGridViewTextBoxColumn";
            this.correctAnsDataGridViewTextBoxColumn.Width = 150;
            // 
            // marksDataGridViewTextBoxColumn
            // 
            this.marksDataGridViewTextBoxColumn.DataPropertyName = "Marks";
            this.marksDataGridViewTextBoxColumn.HeaderText = "Marks";
            this.marksDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.marksDataGridViewTextBoxColumn.Name = "marksDataGridViewTextBoxColumn";
            this.marksDataGridViewTextBoxColumn.Width = 150;
            // 
            // student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "student";
            this.Text = "student";
            this.Load += new System.EventHandler(this.student_Load);
            ((System.ComponentModel.ISupportInitialize)(this.studentRegistrationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerCourseDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerCourseDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addQuestionsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComputerCourseDataSet1 computerCourseDataSet1;
        private System.Windows.Forms.BindingSource studentRegistrationBindingSource;
        private ComputerCourseDataSet1TableAdapters.StudentRegistrationTableAdapter studentRegistrationTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ComputerCourseDataSet5 computerCourseDataSet5;
        private System.Windows.Forms.BindingSource addQuestionsBindingSource;
        private ComputerCourseDataSet5TableAdapters.AddQuestionsTableAdapter addQuestionsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enterQueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn correctAnsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marksDataGridViewTextBoxColumn;
    }
}