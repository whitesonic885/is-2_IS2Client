using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IS2Client
{
	public class �ʍĔ��s : IS2Client.���ʃt�H�[��
	{
		public int i�J�n = 0;
		public int i�I�� = 0;

		private System.Windows.Forms.Label lab����;
		private System.Windows.Forms.Label lab����;
		private System.Windows.Forms.Label lab���b�Z�[�W;
		private System.Windows.Forms.Button btn�Ĕ��s;
		private System.Windows.Forms.Button btn����;
		private IS2Client.���ʃe�L�X�g�{�b�N�X txt���J�n;
		private IS2Client.���ʃe�L�X�g�{�b�N�X txt���I��;
		private System.Windows.Forms.Label lab����;
		private System.ComponentModel.IContainer components = null;

		public �ʍĔ��s()
		{
			// ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
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

		#region �f�U�C�i�Ő������ꂽ�R�[�h
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
			this.lab���� = new System.Windows.Forms.Label();
			this.lab���� = new System.Windows.Forms.Label();
			this.lab���b�Z�[�W = new System.Windows.Forms.Label();
			this.btn�Ĕ��s = new System.Windows.Forms.Button();
			this.btn���� = new System.Windows.Forms.Button();
			this.txt���J�n = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.txt���I�� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab���� = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lab����
			// 
			this.lab����.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab����.Location = new System.Drawing.Point(94, 38);
			this.lab����.Name = "lab����";
			this.lab����.Size = new System.Drawing.Size(20, 23);
			this.lab����.TabIndex = 2;
			this.lab����.Text = "�`";
			this.lab����.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab����
			// 
			this.lab����.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab����.Location = new System.Drawing.Point(148, 38);
			this.lab����.Name = "lab����";
			this.lab����.Size = new System.Drawing.Size(44, 23);
			this.lab����.TabIndex = 4;
			this.lab����.Text = "����";
			this.lab����.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lab���b�Z�[�W
			// 
			this.lab���b�Z�[�W.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���b�Z�[�W.Location = new System.Drawing.Point(10, 10);
			this.lab���b�Z�[�W.Name = "lab���b�Z�[�W";
			this.lab���b�Z�[�W.Size = new System.Drawing.Size(194, 20);
			this.lab���b�Z�[�W.TabIndex = 5;
			this.lab���b�Z�[�W.Text = "����͈͂�ݒ肵�Ă�������";
			this.lab���b�Z�[�W.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn�Ĕ��s
			// 
			this.btn�Ĕ��s.BackColor = System.Drawing.Color.PaleGreen;
			this.btn�Ĕ��s.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�Ĕ��s.ForeColor = System.Drawing.Color.Blue;
			this.btn�Ĕ��s.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�Ĕ��s.Location = new System.Drawing.Point(130, 92);
			this.btn�Ĕ��s.Name = "btn�Ĕ��s";
			this.btn�Ĕ��s.Size = new System.Drawing.Size(68, 34);
			this.btn�Ĕ��s.TabIndex = 6;
			this.btn�Ĕ��s.Text = "���";
			this.btn�Ĕ��s.Click += new System.EventHandler(this.btn�Ĕ��s_Click);
			// 
			// btn����
			// 
			this.btn����.BackColor = System.Drawing.Color.PaleGreen;
			this.btn����.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn����.ForeColor = System.Drawing.Color.Red;
			this.btn����.Location = new System.Drawing.Point(26, 92);
			this.btn����.Name = "btn����";
			this.btn����.Size = new System.Drawing.Size(68, 34);
			this.btn����.TabIndex = 7;
			this.btn����.TabStop = false;
			this.btn����.Text = "����";
			this.btn����.Click += new System.EventHandler(this.btn����_Click);
			// 
			// txt���J�n
			// 
			this.txt���J�n.Font = new System.Drawing.Font("MS UI Gothic", 15.75F);
			this.txt���J�n.Location = new System.Drawing.Point(60, 34);
			this.txt���J�n.MaxLength = 2;
			this.txt���J�n.Name = "txt���J�n";
			this.txt���J�n.Size = new System.Drawing.Size(30, 28);
			this.txt���J�n.TabIndex = 8;
			this.txt���J�n.Text = "1";
			this.txt���J�n.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt���I��
			// 
			this.txt���I��.Font = new System.Drawing.Font("MS UI Gothic", 15.75F);
			this.txt���I��.Location = new System.Drawing.Point(116, 34);
			this.txt���I��.MaxLength = 2;
			this.txt���I��.Name = "txt���I��";
			this.txt���I��.Size = new System.Drawing.Size(30, 28);
			this.txt���I��.TabIndex = 9;
			this.txt���I��.Text = "99";
			this.txt���I��.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lab����
			// 
			this.lab����.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab����.Location = new System.Drawing.Point(114, 64);
			this.lab����.Name = "lab����";
			this.lab����.Size = new System.Drawing.Size(120, 20);
			this.lab����.TabIndex = 10;
			this.lab����.Text = "(��[99]�͍ŏI��)";
			this.lab����.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// �ʍĔ��s
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(234, 138);
			this.Controls.Add(this.lab����);
			this.Controls.Add(this.txt���I��);
			this.Controls.Add(this.txt���J�n);
			this.Controls.Add(this.lab���b�Z�[�W);
			this.Controls.Add(this.lab����);
			this.Controls.Add(this.lab����);
			this.Controls.Add(this.btn�Ĕ��s);
			this.Controls.Add(this.btn����);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(240, 170);
			this.Name = "�ʍĔ��s";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 �ʍĔ��s";
			this.ResumeLayout(false);

		}
		#endregion

		private void btn����_Click(object sender, System.EventArgs e)
		{
			//�Ȃɂ����Ȃ��ꍇ�́A�ϐ����O�ɂ���
			this.i�J�n = 0;
			this.i�I�� = 0;
			this.Close();
		}

		private void btn�Ĕ��s_Click(object sender, System.EventArgs e)
		{
			//�K�{�`�F�b�N
			if(txt���J�n.Text.Length == 0 && txt���I��.Text.Length == 0){
				if(!�K�{�`�F�b�N(txt���J�n,"�J�n��")) return;
				return;
			}

			this.i�J�n = 0;
			this.i�I�� = 0;
			//���l�`�F�b�N
			if(txt���J�n.Text.Length > 0){
				if(!���p�`�F�b�N(txt���J�n,"�J�n��")) return;
				if(!���l�`�F�b�N(txt���J�n,"�J�n��")) return;
				this.i�J�n = int.Parse(txt���J�n.Text);
				if(this.i�J�n < 0 || this.i�J�n > 99){
					MessageBox.Show("�J�n�ł�1�`99�̊Ԃœ��͂��Ă�������"
						, "���̓`�F�b�N", MessageBoxButtons.OK);
					txt���J�n.Focus();
					return;
				}
			}
			if(txt���I��.Text.Length > 0){
				if(!���p�`�F�b�N(txt���I��,"�I����")) return;
				if(!���l�`�F�b�N(txt���I��,"�I����")) return;
				this.i�I�� = int.Parse(txt���I��.Text);
				if(this.i�I�� < 0 || this.i�I�� > 99){
					MessageBox.Show("�I���ł�1�`99�̊Ԃœ��͂��Ă�������"
						, "���̓`�F�b�N", MessageBoxButtons.OK);
					txt���I��.Focus();
					return;
				}
				//�召�֌W�`�F�b�N
				if(this.i�J�n > this.i�I��){
					MessageBox.Show("�ł͈̔͂����������͂���Ă��܂���"
						, "���̓`�F�b�N", MessageBoxButtons.OK);
					txt���I��.Focus();
					return;
				}
			}

			//�Е����ȗ�����Ă���ꍇ
			if(this.i�J�n == 0) this.i�J�n = this.i�I��;
			if(this.i�I�� == 0) this.i�I�� = this.i�J�n;
			this.Close();
		}
	}
}

