using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy
{
	public partial class StudentForm : HumanForm
	{
		Models.Student student;
		private int? editingStudentId = null;
		public StudentForm()
		{
			InitializeComponent();
			cbStudentsGroup.DataSource = DataBase.Connector.Load("SELECT * FROM Groups");
			cbStudentsGroup.DisplayMember = "group_name";
			cbStudentsGroup.ValueMember = "group_id";
		}
		//конструктор, принимает ID, которе мы выбираем в обработчике события DoubleClick
		public StudentForm(int studentId) : this()  // : this() сначала вызов конструкторf без параметров
		{
			editingStudentId = studentId; 
			this.Text = "Редактирование студента";  // смена заголовка у окна

			string query = $@"
            SELECT last_name, first_name, middle_name, birth_date, [group]
            FROM Students
            WHERE stud_id = {editingStudentId.Value}";

			DataTable dt = DataBase.Connector.Load(query);

			if (dt.Rows.Count > 0)
			{
				DataRow row = dt.Rows[0];

				textBoxLastName.Text = row["last_name"].ToString();
				textBoxFirstName.Text = row["first_name"].ToString();
				textBoxMiddleName.Text = row["middle_name"].ToString();
				dtpBirthDate.Value = Convert.ToDateTime(row["birth_date"]);
				cbStudentsGroup.SelectedValue = Convert.ToInt32(row["group"]);
			}
		}

		protected override void buttonOK_Click(object sender, EventArgs e)
		{
			base.buttonOK_Click(sender, e);
			
			if (editingStudentId == null)   //если ID пустое, то вставляем нового студента
			{
				student = new Models.Student(human, (int)cbStudentsGroup.SelectedValue);
				student.id =
				Convert.ToInt32
				(
	DataBase.Connector.Scalar
	($"INSERT Students({student.GetNames()}) VALUES ({student.GetValues()});SELECT SCOPE_IDENTITY();")
				);
			}
			else
			{
				student = new Models.Student(human, (int)cbStudentsGroup.SelectedValue);
				student.id = editingStudentId.Value;
				
				DataBase.Connector.Update
					(
					$"UPDATE Students SET {student.GetUpdateString()} WHERE stud_id = {student.id}"
					);
			}
		}
	}
}
