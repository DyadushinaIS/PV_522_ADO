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
	public partial class HumanForm : Form
	{
		internal Models.Human human;
		public HumanForm()
		{
			InitializeComponent();
		}
		protected virtual void Compress()
		{
			human = new Models.Human
				(
				Convert.ToInt32(labelID.Text == "" ? "0" : labelID.Text.Split(':').Last()),//ID:213
				textBoxLastName.Text,
				textBoxFirstName.Text,
				textBoxMiddleName.Text,
				dtpBirthDate.Value.ToString("yyyy-MM-dd"),
				textBoxEmail.Text,
				textBoxPhone.Text,
				pictureBoxPhoto.Image
				);
		}
		protected virtual void Extract()
		{
			labelID.Text = $"ID:{human.id}";
			textBoxLastName.Text = human.last_name;
			textBoxFirstName.Text = human.first_name;
			textBoxMiddleName.Text = human.middle_name;
			dtpBirthDate.Value = Convert.ToDateTime(human.birth_date);
			textBoxEmail.Text = human.email;
			textBoxPhone.Text = human.phone;
		}
		protected virtual void buttonOK_Click(object sender, EventArgs e)
		{
			Compress();
		}

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
			OpenFileDialog dialog=new OpenFileDialog();   //открываем окно диалога				
			dialog.Filter =								 //настраиваем фильтры, котоые будут отображать нужные типы файлов
"JPG files(*.jpg)|*.jpg|PNG files(*.png)|*.png|All image files|*.png;*.jpg|All files (*.*)|*.*";
            /*
			---------------------------------------------------------------------------------
			фильтр это самая обычная строка, составленная по определенным правилам:
			Описание1|*.ext1;*.ext2;...,*.ext3|Описание2|*.ext1;*.ext2;...,*.ext3|...ОписаниеN|*.ext1;*.ext2;...,*.ext3|
			.ext - extantion (расширение имени файла)
			---------------------------------------------------------------------------------
			 */

			//проверяем, если пользователь нажал OK, то загружаем файл в окно
            if (dialog.ShowDialog() == DialogResult.OK)
				pictureBoxPhoto.Image=Image.FromFile(dialog.FileName);

        }
    }
}
