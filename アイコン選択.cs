using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// Form1 �̊T�v�̐����ł��B
	/// </summary>
	public class �A�C�R���I�� : ���ʃt�H�[��
	{
		public int i�A�C�R�� = 0;
		private System.Windows.Forms.ListView listView�A�C�R��;
		private System.Windows.Forms.Button btn�I��;
		private System.Windows.Forms.Button btn����;
		private System.ComponentModel.IContainer components = null;

		public �A�C�R���I��()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
			�c�o�h�\���T�C�Y�ϊ�();
// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� END
		}

		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
			this.listView�A�C�R�� = new System.Windows.Forms.ListView();
			this.btn�I�� = new System.Windows.Forms.Button();
			this.btn���� = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listView�A�C�R��
			// 
			this.listView�A�C�R��.BackColor = System.Drawing.Color.Honeydew;
			this.listView�A�C�R��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.listView�A�C�R��.LabelEdit = true;
			this.listView�A�C�R��.Location = new System.Drawing.Point(2, 2);
			this.listView�A�C�R��.MultiSelect = false;
			this.listView�A�C�R��.Name = "listView�A�C�R��";
			this.listView�A�C�R��.Size = new System.Drawing.Size(492, 304);
			this.listView�A�C�R��.TabIndex = 0;
			this.listView�A�C�R��.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView�A�C�R��_KeyDown);
			this.listView�A�C�R��.DoubleClick += new System.EventHandler(this.listView�A�C�R��_DoubleClick);
			// 
			// btn�I��
			// 
			this.btn�I��.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�I��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�I��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�I��.ForeColor = System.Drawing.Color.White;
			this.btn�I��.Location = new System.Drawing.Point(356, 310);
			this.btn�I��.Name = "btn�I��";
			this.btn�I��.Size = new System.Drawing.Size(64, 22);
			this.btn�I��.TabIndex = 2;
			this.btn�I��.TabStop = false;
			this.btn�I��.Text = "�I��";
			this.btn�I��.Click += new System.EventHandler(this.btn�I��_Click);
			// 
			// btn����
			// 
			this.btn����.BackColor = System.Drawing.Color.SteelBlue;
			this.btn����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn����.ForeColor = System.Drawing.Color.White;
			this.btn����.Location = new System.Drawing.Point(426, 310);
			this.btn����.Name = "btn����";
			this.btn����.Size = new System.Drawing.Size(64, 22);
			this.btn����.TabIndex = 3;
			this.btn����.TabStop = false;
			this.btn����.Text = "����";
			this.btn����.Click += new System.EventHandler(this.btn����_Click);
			// 
			// �A�C�R���I��
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(496, 341);
			this.Controls.Add(this.btn����);
			this.Controls.Add(this.btn�I��);
			this.Controls.Add(this.listView�A�C�R��);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(502, 366);
			this.Name = "�A�C�R���I��";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 �A�C�R���I��";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
			this.Load += new System.EventHandler(this.�A�C�R���I��_Load);
			this.Closed += new System.EventHandler(this.�A�C�R���I��_Closed);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		private void �A�C�R���I��_Load(object sender, System.EventArgs e)
		{
			// �C���[�W�̐ݒ�
			�A�C�R���C���[�W�̏�����();
			listView�A�C�R��.LargeImageList = imageList64;
			listView�A�C�R��.SmallImageList = imageList16;

			ListViewItem item;
			for(int iCnt = 0; iCnt < s�A�C�R��.Length; iCnt++)
			{
				item = new ListViewItem();
// MOD 2005.05.25 ���s�j���� �A�C�R���I����ʂ̕\�����A[.ico]��\�� START
//				item.Text = s�A�C�R��[iCnt];
				item.Text = s�A�C�R���ꗗ[iCnt];
// MOD 2005.05.25 ���s�j���� �A�C�R���I����ʂ̕\�����A[.ico]��\�� END
				item.ImageIndex = iCnt;
				listView�A�C�R��.Items.Add(item);
			}

			listView�A�C�R��.Focus();

// MOD 2005.05.09 ���s�j���� �A�C�R���ꗗ�\���̕ύX START
//			// �P�ڂ̍��ڂ�I����Ԃɂ���
//			if(listView�A�C�R��.Items.Count > 0)
//				listView�A�C�R��.Items[0].Selected = true;
			if(listView�A�C�R��.Items.Count > 0)
			{
				// �A�C�R����I����Ԃɂ���
				if( i�A�C�R�� > 0 )
					listView�A�C�R��.Items[i�A�C�R��].Selected = true;
				else
					listView�A�C�R��.Items[0].Selected = true;
			}
// MOD 2005.05.09 ���s�j���� �A�C�R���ꗗ�\���̕ύX END
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void listView�A�C�R��_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyData == Keys.Enter)
			{
				btn�I��_Click(sender, e);
			}
		}

		private void listView�A�C�R��_DoubleClick(object sender, System.EventArgs e)
		{
			btn�I��_Click(sender, e);
		}

		private void btn�I��_Click(object sender, System.EventArgs e)
		{
			// �I������Ă��Ȃ��ꍇ�ɂ͏I��
			if(listView�A�C�R��.SelectedItems.Count == 0)
			{	
				MessageBox.Show("�A�C�R�����I������Ă��܂���B", "�m�F",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				listView�A�C�R��.Focus();
				return;
			}
			i�A�C�R�� = listView�A�C�R��.SelectedItems[0].Index;
			this.Close();
		}

// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� START
		private void �A�C�R���I��_Closed(object sender, System.EventArgs e)
		{
			listView�A�C�R��.Clear();
			listView�A�C�R��.Focus();
		}
// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� END

	}
}
