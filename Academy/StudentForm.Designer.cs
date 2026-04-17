namespace Academy
{
	partial class StudentForm
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
			this.cbStudentsGroup = new System.Windows.Forms.ComboBox();
			this.labelGroup = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cbStudentsGroup
			// 
			this.cbStudentsGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStudentsGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.cbStudentsGroup.FormattingEnabled = true;
			this.cbStudentsGroup.Location = new System.Drawing.Point(186, 267);
			this.cbStudentsGroup.Name = "cbStudentsGroup";
			this.cbStudentsGroup.Size = new System.Drawing.Size(248, 32);
			this.cbStudentsGroup.TabIndex = 17;
			// 
			// labelGroup
			// 
			this.labelGroup.AutoSize = true;
			this.labelGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelGroup.Location = new System.Drawing.Point(96, 271);
			this.labelGroup.Name = "labelGroup";
			this.labelGroup.Size = new System.Drawing.Size(89, 25);
			this.labelGroup.TabIndex = 18;
			this.labelGroup.Text = "Группа:";
			// 
			// StudentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(640, 363);
			this.Controls.Add(this.labelGroup);
			this.Controls.Add(this.cbStudentsGroup);
			this.Name = "StudentForm";
			this.Text = "StudentForm";
			this.Controls.SetChildIndex(this.cbStudentsGroup, 0);
			this.Controls.SetChildIndex(this.labelGroup, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbStudentsGroup;
		private System.Windows.Forms.Label labelGroup;
	}
}