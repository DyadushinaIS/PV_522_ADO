namespace Academy
{
	partial class HumanForm
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
			this.labelLastName = new System.Windows.Forms.Label();
			this.labelFirstName = new System.Windows.Forms.Label();
			this.labelMiddleName = new System.Windows.Forms.Label();
			this.labelBirthDate = new System.Windows.Forms.Label();
			this.labelEmail = new System.Windows.Forms.Label();
			this.labelPhone = new System.Windows.Forms.Label();
			this.textBoxLastName = new System.Windows.Forms.TextBox();
			this.textBoxFirstName = new System.Windows.Forms.TextBox();
			this.textBoxMiddleName = new System.Windows.Forms.TextBox();
			this.textBoxEmail = new System.Windows.Forms.TextBox();
			this.textBoxPhone = new System.Windows.Forms.TextBox();
			this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
			this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelID = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
			this.SuspendLayout();
			// 
			// labelLastName
			// 
			this.labelLastName.AutoSize = true;
			this.labelLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelLastName.Location = new System.Drawing.Point(75, 22);
			this.labelLastName.Name = "labelLastName";
			this.labelLastName.Size = new System.Drawing.Size(110, 25);
			this.labelLastName.TabIndex = 0;
			this.labelLastName.Text = "Фамилия:";
			// 
			// labelFirstName
			// 
			this.labelFirstName.AutoSize = true;
			this.labelFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelFirstName.Location = new System.Drawing.Point(126, 64);
			this.labelFirstName.Name = "labelFirstName";
			this.labelFirstName.Size = new System.Drawing.Size(59, 25);
			this.labelFirstName.TabIndex = 1;
			this.labelFirstName.Text = "Имя:";
			// 
			// labelMiddleName
			// 
			this.labelMiddleName.AutoSize = true;
			this.labelMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMiddleName.Location = new System.Drawing.Point(74, 106);
			this.labelMiddleName.Name = "labelMiddleName";
			this.labelMiddleName.Size = new System.Drawing.Size(111, 25);
			this.labelMiddleName.TabIndex = 2;
			this.labelMiddleName.Text = "Отчество:";
			// 
			// labelBirthDate
			// 
			this.labelBirthDate.AutoSize = true;
			this.labelBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelBirthDate.Location = new System.Drawing.Point(13, 148);
			this.labelBirthDate.Name = "labelBirthDate";
			this.labelBirthDate.Size = new System.Drawing.Size(172, 25);
			this.labelBirthDate.TabIndex = 3;
			this.labelBirthDate.Text = "Дата рождения:";
			// 
			// labelEmail
			// 
			this.labelEmail.AutoSize = true;
			this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelEmail.Location = new System.Drawing.Point(107, 190);
			this.labelEmail.Name = "labelEmail";
			this.labelEmail.Size = new System.Drawing.Size(78, 25);
			this.labelEmail.TabIndex = 4;
			this.labelEmail.Text = "E-mail:";
			// 
			// labelPhone
			// 
			this.labelPhone.AutoSize = true;
			this.labelPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPhone.Location = new System.Drawing.Point(77, 232);
			this.labelPhone.Name = "labelPhone";
			this.labelPhone.Size = new System.Drawing.Size(108, 25);
			this.labelPhone.TabIndex = 5;
			this.labelPhone.Text = "Телефон:";
			// 
			// textBoxLastName
			// 
			this.textBoxLastName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.textBoxLastName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textBoxLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxLastName.Location = new System.Drawing.Point(186, 19);
			this.textBoxLastName.Name = "textBoxLastName";
			this.textBoxLastName.Size = new System.Drawing.Size(248, 31);
			this.textBoxLastName.TabIndex = 6;
			// 
			// textBoxFirstName
			// 
			this.textBoxFirstName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.textBoxFirstName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textBoxFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxFirstName.Location = new System.Drawing.Point(186, 61);
			this.textBoxFirstName.Name = "textBoxFirstName";
			this.textBoxFirstName.Size = new System.Drawing.Size(248, 31);
			this.textBoxFirstName.TabIndex = 7;
			// 
			// textBoxMiddleName
			// 
			this.textBoxMiddleName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.textBoxMiddleName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textBoxMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxMiddleName.Location = new System.Drawing.Point(186, 103);
			this.textBoxMiddleName.Name = "textBoxMiddleName";
			this.textBoxMiddleName.Size = new System.Drawing.Size(248, 31);
			this.textBoxMiddleName.TabIndex = 8;
			// 
			// textBoxEmail
			// 
			this.textBoxEmail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.textBoxEmail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxEmail.Location = new System.Drawing.Point(186, 187);
			this.textBoxEmail.Name = "textBoxEmail";
			this.textBoxEmail.Size = new System.Drawing.Size(248, 31);
			this.textBoxEmail.TabIndex = 9;
			// 
			// textBoxPhone
			// 
			this.textBoxPhone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.textBoxPhone.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textBoxPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxPhone.Location = new System.Drawing.Point(186, 229);
			this.textBoxPhone.Name = "textBoxPhone";
			this.textBoxPhone.Size = new System.Drawing.Size(248, 31);
			this.textBoxPhone.TabIndex = 10;
			// 
			// dtpBirthDate
			// 
			this.dtpBirthDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dtpBirthDate.CustomFormat = "yyyy.MMMM.dd";
			this.dtpBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpBirthDate.Location = new System.Drawing.Point(186, 145);
			this.dtpBirthDate.Name = "dtpBirthDate";
			this.dtpBirthDate.Size = new System.Drawing.Size(248, 31);
			this.dtpBirthDate.TabIndex = 11;
			// 
			// pictureBoxPhoto
			// 
			this.pictureBoxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxPhoto.Location = new System.Drawing.Point(440, 19);
			this.pictureBoxPhoto.Name = "pictureBoxPhoto";
			this.pictureBoxPhoto.Size = new System.Drawing.Size(188, 241);
			this.pictureBoxPhoto.TabIndex = 12;
			this.pictureBoxPhoto.TabStop = false;
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonBrowse.Location = new System.Drawing.Point(440, 266);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(188, 33);
			this.buttonBrowse.TabIndex = 13;
			this.buttonBrowse.Text = "Обзор";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonOK.Location = new System.Drawing.Point(246, 319);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(188, 33);
			this.buttonOK.TabIndex = 14;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonCancel.Location = new System.Drawing.Point(440, 319);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(188, 33);
			this.buttonCancel.TabIndex = 15;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// labelID
			// 
			this.labelID.AutoSize = true;
			this.labelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelID.Location = new System.Drawing.Point(13, 322);
			this.labelID.Name = "labelID";
			this.labelID.Size = new System.Drawing.Size(0, 25);
			this.labelID.TabIndex = 16;
			// 
			// HumanForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(645, 364);
			this.Controls.Add(this.labelID);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonBrowse);
			this.Controls.Add(this.pictureBoxPhoto);
			this.Controls.Add(this.dtpBirthDate);
			this.Controls.Add(this.textBoxPhone);
			this.Controls.Add(this.textBoxEmail);
			this.Controls.Add(this.textBoxMiddleName);
			this.Controls.Add(this.textBoxFirstName);
			this.Controls.Add(this.textBoxLastName);
			this.Controls.Add(this.labelPhone);
			this.Controls.Add(this.labelEmail);
			this.Controls.Add(this.labelBirthDate);
			this.Controls.Add(this.labelMiddleName);
			this.Controls.Add(this.labelFirstName);
			this.Controls.Add(this.labelLastName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HumanForm";
			this.Text = "HumanForm";
			this.Load += new System.EventHandler(this.HumanForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		protected System.Windows.Forms.Label labelLastName;
		protected System.Windows.Forms.Label labelFirstName;
		protected System.Windows.Forms.Label labelMiddleName;
		protected System.Windows.Forms.Label labelBirthDate;
		protected System.Windows.Forms.Label labelEmail;
		protected System.Windows.Forms.Label labelPhone;
		protected System.Windows.Forms.TextBox textBoxLastName;
		protected System.Windows.Forms.TextBox textBoxFirstName;
		protected System.Windows.Forms.TextBox textBoxMiddleName;
		protected System.Windows.Forms.TextBox textBoxEmail;
		protected System.Windows.Forms.TextBox textBoxPhone;
		protected System.Windows.Forms.DateTimePicker dtpBirthDate;
		protected System.Windows.Forms.PictureBox pictureBoxPhoto;
		protected System.Windows.Forms.Button buttonBrowse;
		protected System.Windows.Forms.Button buttonOK;
		protected System.Windows.Forms.Button buttonCancel;
		protected System.Windows.Forms.Label labelID;
	}
}