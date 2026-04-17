using Academy.Models;
using DBtools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy
{
	public partial class MainForm : Form
	{
		Connector connector;
		DataGridView[] tables;
		Query[] queries =
			{
				new Query
				(
					"stud_id,last_name,first_name,middle_name,birth_date,group_name,direction_name",
					"Students,Groups,Directions",
					"[group]=group_id AND direction=direction_id"
				),
				new Query
				(
					"group_id,group_name,direction_name", //group_id,group_name,start_date,start_time,learning_days,direction_name",
					"Groups,Directions",
					"direction=direction_id"
				),
				new Query("*", "Directions"),
				new Query("*", "Disciplines"),
				new Query("*", "Teachers")
			};
		public MainForm()
		{
			InitializeComponent();

			tables = new DataGridView[] { dgvStudents, dgvGroups, dgvDirections, dgvDisciplines, dgvTeachers };

			connector = new Connector(ConfigurationManager.ConnectionStrings["PV_522_Import"].ConnectionString);
			//dgvDirections.DataSource = connector.Select("SELECT * FROM Directions");
			tabControl_SelectedIndexChanged(tabControl, null);

			cbGroupsDirection.DataSource = connector.Load("SELECT * FROM Directions");
			cbGroupsDirection.DisplayMember = "direction_name";
			cbGroupsDirection.ValueMember = "direction_id";
		}

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			int i = (sender as TabControl).SelectedIndex;   //Получаем номер выбранной вкладки
			tables[i].DataSource = connector.Load(queries[i].ToString());
			//tables[i].DataSource = connector.Select("*", tabControl.SelectedTab.Text);
			toolStripStatusLabel.Text = $"Количество записей: {tables[i].RowCount-1}";
		}

		private void cbGroupsDirection_SelectionChangeCommitted(object sender, EventArgs e)
		{
			dgvGroups.DataSource = connector.Load
				(
				queries[1].ToString() + $" AND direction={cbGroupsDirection.SelectedValue}"
				);
			toolStripStatusLabel.Text = $"Количество записей: {dgvGroups.RowCount - 1}";
		}

		private void buttonAddStudent_Click(object sender, EventArgs e)
		{

			StudentForm student = new StudentForm();
			//student.ShowDialog();

			/*if (student.ShowDialog() == DialogResult.OK)
			//{
			//	tables[0].DataSource = connector.Load(queries[0].ToString());
			//	//tables[i].DataSource = connector.Select("*", tabControl.SelectedTab.Text);
			//	toolStripStatusLabel.Text = $"Количество записей: {tables[0].RowCount - 1}";
			//	return;
			//}
			//if (student.ShowDialog() == DialogResult.Cancel)
				return; */

			if (student.ShowDialog() == DialogResult.OK)
			{
				tables[0].DataSource = connector.Load(queries[0].ToString());
				toolStripStatusLabel.Text = $"Количество записей: {tables[0].RowCount - 1}";
			}
		}

		private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}

		private void dgvStudents_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			//получаем id студента, по которому сделали двойной клик и сохраняем в переменную
			//.Rows - встроенное свойство
			//e.RowIndex - номер строки, по которой кликнули
			//.Cells - тоже встроено, в скобках пишем название поля, с которым хотим поработать (строку мы уже указали свойством Row
			//.Value - берет значение из выбранной ячейки. В нашем случае это и получается id студента, по которому сделали двойной клик

			int studentId;
			studentId = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells["stud_id"].Value);

			// Создаём форму редактирования и передаём туда ID студента
			StudentForm editForm = new StudentForm(studentId);

			// Открываем форму и ждём, пока пользователь нажмёт ОК или Отмена
			if (editForm.ShowDialog() == DialogResult.OK)
			{
				// Если нажали ОК - обновляем таблицу студентов
				tables[0].DataSource = connector.Load(queries[0].ToString());
				toolStripStatusLabel.Text = $"Количество записей: {tables[0].RowCount - 1}";
			}
		}
	}
}
