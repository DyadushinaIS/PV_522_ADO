using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using DBtools;

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
					"group_id,group_name,direction_name",
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
			//			l-value = r-value;
			StudentForm student = new StudentForm();
			//student.ShowDialog();
			if (student.ShowDialog() == DialogResult.OK) tabControl_SelectedIndexChanged(tabControl, null);
		}

		private void dgvStudents_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			int id = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells[0].Value);
			StudentForm form = new StudentForm(id);
			if (form.ShowDialog() == DialogResult.OK) tabControl_SelectedIndexChanged(tabControl, null);
		}
	}
}
