using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace IS2Client
{
	/// <summary>
	/// [�����o�^]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// MOD 2008.07.09 ���s�j���� �l�`�b�A�h���X�擾�̋��� 
	// MOD 2008.07.16 ���s�j���� �l�`�b�A�h���X�̊ȈՃ}�X�L���O 
	//�ۗ� MOD 2008.10.23 ���s�j���� �l�`�b�A�h���X�̖��擾���̐ݒ�ύX 
	//--------------------------------------------------------------------------
	// MOD 2009.02.06 ���s�j���� �`�F�b�N���̍��ږ��̏C�� 
	// ADD 2009.07.29 ���s�j���� �v���L�V�Ή� 
	// �@�h�d��[Secure]�̐ݒ肩����擾����
	// �@�v���L�V�����[�U���ݒ�ł���悤�ɂ���
	// MOD 2009.07.30 ���s�j���� exe��dll���Ή� 
	// MOD 2009.10.16 ���s�j���� �v���L�V�@�\�\�L�̒ǉ� 
	//--------------------------------------------------------------------------
	// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� 
	//--------------------------------------------------------------------------
	// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� 
	// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή�
	// MOD 2015.02.12 BEVAS�j�O�c �s�d�b���v�����^(B-LV4)�Ή�
	//--------------------------------------------------------------------------

	public class �����o�^ : ���ʃt�H�[��
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lab�͂���o�^�^�C�g��;
		private System.Windows.Forms.TextBox tex���b�Z�[�W;
		private ���ʃe�L�X�g�{�b�N�X tex���p�҂b�c;
		private System.Windows.Forms.Label lab�p�X���[�h;
		private ���ʃe�L�X�g�{�b�N�X tex�p�X���[�h;
		private System.Windows.Forms.Label lab���p�҂b�c;
		private System.Windows.Forms.Label lab����b�c;
		private ���ʃe�L�X�g�{�b�N�X tex����b�c;
		private System.Windows.Forms.Label lab�v�����^;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rBtn����;
		private System.Windows.Forms.RadioButton rBtn�L��;
		private System.Windows.Forms.ListBox list�v�����^;
		private System.Windows.Forms.Label lab���s���;
		private System.Windows.Forms.Button btn�o�^;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lab�o�[�W����;
		private System.ComponentModel.IContainer components = null;

		public �����o�^()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
			�c�o�h�\���T�C�Y�ϊ�();
			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
//				this.list�v�����^.Size = new System.Drawing.Size(226, 34);
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� START
//				this.list�v�����^.Size = new System.Drawing.Size(226, (int)(34 * 1.5));
				this.list�v�����^.Size = new System.Drawing.Size(246, (int)(50 * 1.5));
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� END
			}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(�����o�^));
			this.tex���p�҂b�c = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lab�o�[�W���� = new System.Windows.Forms.Label();
			this.lab�v�����^ = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rBtn���� = new System.Windows.Forms.RadioButton();
			this.rBtn�L�� = new System.Windows.Forms.RadioButton();
			this.list�v�����^ = new System.Windows.Forms.ListBox();
			this.lab���s��� = new System.Windows.Forms.Label();
			this.lab����b�c = new System.Windows.Forms.Label();
			this.tex����b�c = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab�p�X���[�h = new System.Windows.Forms.Label();
			this.tex�p�X���[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.label1 = new System.Windows.Forms.Label();
			this.lab���p�҂b�c = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab�͂���o�^�^�C�g�� = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.tex���b�Z�[�W = new System.Windows.Forms.TextBox();
			this.btn�o�^ = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).BeginInit();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tex���p�҂b�c
			// 
			this.tex���p�҂b�c.BackColor = System.Drawing.SystemColors.Window;
			this.tex���p�҂b�c.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���p�҂b�c.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex���p�҂b�c.Location = new System.Drawing.Point(118, 32);
			this.tex���p�҂b�c.MaxLength = 10;
			this.tex���p�҂b�c.Name = "tex���p�҂b�c";
			this.tex���p�҂b�c.Size = new System.Drawing.Size(58, 23);
			this.tex���p�҂b�c.TabIndex = 1;
			this.tex���p�҂b�c.Text = "";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Honeydew;
			this.panel1.Controls.Add(this.lab�o�[�W����);
			this.panel1.Controls.Add(this.lab�v�����^);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.list�v�����^);
			this.panel1.Controls.Add(this.lab���s���);
			this.panel1.Controls.Add(this.lab����b�c);
			this.panel1.Controls.Add(this.tex����b�c);
			this.panel1.Controls.Add(this.lab�p�X���[�h);
			this.panel1.Controls.Add(this.tex�p�X���[�h);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.lab���p�҂b�c);
			this.panel1.Controls.Add(this.tex���p�҂b�c);
			this.panel1.Location = new System.Drawing.Point(0, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(370, 236);
			this.panel1.TabIndex = 0;
			// 
			// lab�o�[�W����
			// 
			this.lab�o�[�W����.BackColor = System.Drawing.Color.Honeydew;
			this.lab�o�[�W����.ForeColor = System.Drawing.Color.Black;
			this.lab�o�[�W����.Location = new System.Drawing.Point(304, 8);
			this.lab�o�[�W����.Name = "lab�o�[�W����";
			this.lab�o�[�W����.Size = new System.Drawing.Size(60, 12);
			this.lab�o�[�W����.TabIndex = 54;
			this.lab�o�[�W����.Text = "Ver.1.9";
			// 
			// lab�v�����^
			// 
			this.lab�v�����^.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�v�����^.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�v�����^.Location = new System.Drawing.Point(36, 86);
			this.lab�v�����^.Name = "lab�v�����^";
			this.lab�v�����^.Size = new System.Drawing.Size(80, 14);
			this.lab�v�����^.TabIndex = 52;
			this.lab�v�����^.Text = "�v�����^�̗L��";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rBtn����);
			this.groupBox1.Controls.Add(this.rBtn�L��);
			this.groupBox1.Location = new System.Drawing.Point(66, 88);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(272, 40);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// rBtn����
			// 
			this.rBtn����.Location = new System.Drawing.Point(106, 14);
			this.rBtn����.Name = "rBtn����";
			this.rBtn����.Size = new System.Drawing.Size(58, 24);
			this.rBtn����.TabIndex = 1;
			this.rBtn����.Text = "����";
			// 
			// rBtn�L��
			// 
			this.rBtn�L��.Checked = true;
			this.rBtn�L��.Location = new System.Drawing.Point(26, 14);
			this.rBtn�L��.Name = "rBtn�L��";
			this.rBtn�L��.Size = new System.Drawing.Size(58, 24);
			this.rBtn�L��.TabIndex = 0;
			this.rBtn�L��.TabStop = true;
			this.rBtn�L��.Text = "�L��";
			// 
			// list�v�����^
			// 
			this.list�v�����^.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.list�v�����^.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.list�v�����^.ItemHeight = 16;
			this.list�v�����^.Items.AddRange(new object[] {
														  "�y�d�a�q�`���T�[�}���v�����^�i�t�r�a�j",
														  "�r�`�s�n���T�[�}���v�����^�i�t�r�a�j",
														  "���łs�d�b���T�[�}���v�����^�i�t�r�a�j"});
			this.list�v�����^.Location = new System.Drawing.Point(90, 162);
			this.list�v�����^.Name = "list�v�����^";
			this.list�v�����^.Size = new System.Drawing.Size(246, 50);
			this.list�v�����^.TabIndex = 4;
			// 
			// lab���s���
			// 
			this.lab���s���.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���s���.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���s���.Location = new System.Drawing.Point(36, 142);
			this.lab���s���.Name = "lab���s���";
			this.lab���s���.Size = new System.Drawing.Size(80, 14);
			this.lab���s���.TabIndex = 51;
			this.lab���s���.Text = "�׎D���s���";
			// 
			// lab����b�c
			// 
			this.lab����b�c.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab����b�c.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab����b�c.Location = new System.Drawing.Point(36, 10);
			this.lab����b�c.Name = "lab����b�c";
			this.lab����b�c.Size = new System.Drawing.Size(74, 14);
			this.lab����b�c.TabIndex = 0;
			this.lab����b�c.Text = "���q�l�R�[�h";
			// 
			// tex����b�c
			// 
			this.tex����b�c.BackColor = System.Drawing.SystemColors.Window;
			this.tex����b�c.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex����b�c.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex����b�c.Location = new System.Drawing.Point(118, 6);
			this.tex����b�c.MaxLength = 10;
			this.tex����b�c.Name = "tex����b�c";
			this.tex����b�c.Size = new System.Drawing.Size(106, 23);
			this.tex����b�c.TabIndex = 0;
			this.tex����b�c.Text = "";
			// 
			// lab�p�X���[�h
			// 
			this.lab�p�X���[�h.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�p�X���[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�p�X���[�h.Location = new System.Drawing.Point(36, 62);
			this.lab�p�X���[�h.Name = "lab�p�X���[�h";
			this.lab�p�X���[�h.Size = new System.Drawing.Size(74, 14);
			this.lab�p�X���[�h.TabIndex = 48;
			this.lab�p�X���[�h.Text = "�p�X���[�h";
			// 
			// tex�p�X���[�h
			// 
			this.tex�p�X���[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex�p�X���[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�p�X���[�h.Location = new System.Drawing.Point(118, 58);
			this.tex�p�X���[�h.MaxLength = 25;
			this.tex�p�X���[�h.Name = "tex�p�X���[�h";
			this.tex�p�X���[�h.PasswordChar = '*';
			this.tex�p�X���[�h.Size = new System.Drawing.Size(246, 23);
			this.tex�p�X���[�h.TabIndex = 2;
			this.tex�p�X���[�h.Text = "";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 406);
			this.label1.TabIndex = 44;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab���p�҂b�c
			// 
			this.lab���p�҂b�c.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���p�҂b�c.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���p�҂b�c.Location = new System.Drawing.Point(36, 36);
			this.lab���p�҂b�c.Name = "lab���p�҂b�c";
			this.lab���p�҂b�c.Size = new System.Drawing.Size(74, 14);
			this.lab���p�҂b�c.TabIndex = 42;
			this.lab���p�҂b�c.Text = "���[�U�[";
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.lab�͂���o�^�^�C�g��);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(792, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab�͂���o�^�^�C�g��
			// 
			this.lab�͂���o�^�^�C�g��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�͂���o�^�^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�͂���o�^�^�C�g��.ForeColor = System.Drawing.Color.White;
			this.lab�͂���o�^�^�C�g��.Location = new System.Drawing.Point(12, 2);
			this.lab�͂���o�^�^�C�g��.Name = "lab�͂���o�^�^�C�g��";
			this.lab�͂���o�^�^�C�g��.Size = new System.Drawing.Size(264, 24);
			this.lab�͂���o�^�^�C�g��.TabIndex = 0;
			this.lab�͂���o�^�^�C�g��.Text = "�����o�^";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.tex���b�Z�[�W);
			this.panel8.Controls.Add(this.btn�o�^);
			this.panel8.Location = new System.Drawing.Point(0, 266);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 2;
			// 
			// tex���b�Z�[�W
			// 
			this.tex���b�Z�[�W.BackColor = System.Drawing.Color.PaleGreen;
			this.tex���b�Z�[�W.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���b�Z�[�W.ForeColor = System.Drawing.Color.Red;
			this.tex���b�Z�[�W.Location = new System.Drawing.Point(66, 6);
			this.tex���b�Z�[�W.Multiline = true;
			this.tex���b�Z�[�W.Name = "tex���b�Z�[�W";
			this.tex���b�Z�[�W.ReadOnly = true;
			this.tex���b�Z�[�W.Size = new System.Drawing.Size(306, 46);
			this.tex���b�Z�[�W.TabIndex = 1;
			this.tex���b�Z�[�W.TabStop = false;
			this.tex���b�Z�[�W.Text = "";
			// 
			// btn�o�^
			// 
			this.btn�o�^.ForeColor = System.Drawing.Color.Blue;
			this.btn�o�^.Location = new System.Drawing.Point(8, 6);
			this.btn�o�^.Name = "btn�o�^";
			this.btn�o�^.Size = new System.Drawing.Size(54, 48);
			this.btn�o�^.TabIndex = 2;
			this.btn�o�^.Text = "�o�^";
			this.btn�o�^.Click += new System.EventHandler(this.btn�o�^_Click);
			// 
			// button13
			// 
			this.button13.Location = new System.Drawing.Point(0, 0);
			this.button13.Name = "button13";
			this.button13.TabIndex = 0;
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(0, 0);
			this.button12.Name = "button12";
			this.button12.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel1);
			this.groupBox2.Location = new System.Drawing.Point(1, 22);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(373, 244);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			// 
			// �����o�^
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(374, 329);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.groupBox2);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(382, 356);
			this.Name = "�����o�^";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "is-2 �����o�^";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
			this.Load += new System.EventHandler(this.�����o�^_Load);
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).EndInit();
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		private void btn�o�^_Click(object sender, System.EventArgs e)
		{
			// �󔒏���
			tex����b�c.Text   = tex����b�c.Text.Trim();
			tex���p�҂b�c.Text = tex���p�҂b�c.Text.Trim();
			tex�p�X���[�h.Text = tex�p�X���[�h.Text.Trim();
// ADD 2009.07.29 ���s�j���� �v���L�V�Ή� START
			if(tex�p�X���[�h.Text.Length == 0){
				if(tex���p�҂b�c.Text.ToLower().Equals("p"))
				{
					// �v���L�V�����ݒ�t�@�C���̃N���A
					StreamWriter swp = File.CreateText(gsInitProxy);
					swp.WriteLine("");
					swp.WriteLine("");
					swp.WriteLine("");
					swp.Close();

					gs�[���b�c   = "";
					gsa���[�U[2] = gs�[���b�c;

					this.Close();
					return;
				}
				if(tex���p�҂b�c.Text.ToLower().Equals("pd"))
				{
					try{
						// �v���L�V�����ݒ�t�@�C���̍폜
						System.IO.File.Delete(gsInitProxy);
					}catch(Exception){}

					gs�[���b�c   = "";
					gsa���[�U[2] = gs�[���b�c;

					this.Close();
					return;
				}
			}
// ADD 2009.07.29 ���s�j���� �v���L�V�Ή� END

			// ���ڃ`�F�b�N
// MOD 2009.02.06 ���s�j���� �`�F�b�N���̍��ږ��̏C�� START
//			if(!�K�{�`�F�b�N(tex����b�c,"����b�c")) return;
//			if(!�K�{�`�F�b�N(tex���p�҂b�c,"���p�҂b�c")) return;
			if(!�K�{�`�F�b�N(tex����b�c,"���q�l�R�[�h")) return;
			if(!�K�{�`�F�b�N(tex���p�҂b�c,"���[�U�[")) return;
			if(!�K�{�`�F�b�N(tex�p�X���[�h,"�p�X���[�h")) return;
//			if(!���p�`�F�b�N(tex����b�c,"����b�c")) return;
//			if(!�p�X���[�h�`�F�b�N(tex���p�҂b�c,"���p�҂b�c")) return;
			if(!���p�`�F�b�N(tex����b�c,"���q�l�R�[�h")) return;
			if(!�p�X���[�h�`�F�b�N(tex���p�҂b�c,"���[�U�[")) return;
			if(!�p�X���[�h�`�F�b�N(tex�p�X���[�h,"�p�X���[�h")) return;
// MOD 2009.02.06 ���s�j���� �`�F�b�N���̍��ږ��̏C�� END


// DEL 2006.10.06 ���s�j�R�{ �v�����^�`�F�b�N���v�����^�ԍ��ݒ��ɍs�Ȃ��悤�ɕύX START
// MOD 2005.05.31 ���s�j�����J �v�����^�`�F�b�N START
//			if(rBtn�L��.Checked)
//			{
//				try
//				{
//					�v�����^�`�F�b�N();
//				}
//				catch(Exception ex)
//				{
//					�r�[�v��();
//					MessageBox.Show(ex.Message, "�v�����^�`�F�b�N",
//						MessageBoxButtons.OK, MessageBoxIcon.Information);
//					return;
//				}
//			}
// MOD 2005.05.31 ���s�j�����J �v�����^�`�F�b�N START
// DEL 2006.10.06 ���s�j�R�{ �v�����^�`�F�b�N���v�����^�ԍ��ݒ��ɍs�Ȃ��悤�ɕύX END

			// �f�[�^�쐬
			String[] sKey = new string[8];
			sKey[0] = tex����b�c.Text;
			sKey[1] = tex���p�҂b�c.Text;
			sKey[2] = tex�p�X���[�h.Text;
			// �v�����^�̗L��
			if(rBtn�L��.Checked)
				sKey[3] = "1";
			else
				sKey[3] = "0";
			// �v�����^�̃t�H�[�}�b�g�̎��
			switch(list�v�����^.SelectedIndex)
			{
//// MOD 2006.09.27 ���s�j�R�{ �s�d�b���v�����^�Ή� START
//					/*
//									case 0:	// ���[�U�[�v�����^
//										sKey[4] = "L0001  ";
//										break;
//
//									case 1:	// �T�[�}���v�����^�i�t�r�a�j
//										sKey[4] = "S0001  ";
//										break;
//
//									default:
//										sKey[4] = "S0001  ";
//										break;
//					*/
				case 1:		// �r�`�s�n���T�[�}���v�����^�i�t�r�a�j
					sKey[4] = "S0002";
					break;
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� START
				case 2:		// �s�d�b���T�[�}���v�����^�i�t�r�a�j
					sKey[4] = "S0007";
					break;
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� END
				default:	// �y�d�a�q�`���T�[�}���v�����^�i�t�r�a�j
					sKey[4] = "S0001";
					break;
// MOD 2006.09.27 ���s�j�R�{ �s�d�b���v�����^�Ή� END
			}

// ADD 2006.10.06 ���s�j�R�{ �v�����^�`�F�b�N���v�����^�ԍ��ݒ��ɍs�Ȃ��悤�ɕύX START
			if(rBtn�L��.Checked)
			{
				try
				{
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� START
//					�v�����^�`�F�b�N(sKey[4]);
					sKey[4] = �v�����^�`�F�b�N(sKey[4]);
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� END
				}
				catch(Exception ex)
				{
					�r�[�v��();
					MessageBox.Show(ex.Message, "�v�����^�`�F�b�N",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
// ADD 2006.10.06 ���s�j�R�{ �v�����^�`�F�b�N���v�����^�ԍ��ݒ��ɍs�Ȃ��悤�ɕύX END

			// �R���s���[�^��
			try
			{
				sKey[5] = System.Environment.MachineName;
				// �h�o�A�h���X
				try
				{
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX START
					//System.Net.IPHostEntry iph = System.Net.Dns.GetHostByName(sKey[5]);
                    System.Net.IPHostEntry iph = System.Net.Dns.GetHostEntry(sKey[5]);
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX END

// MOD 2008.07.09 ���s�j���� �l�`�b�A�h���X�擾�̋��� START
//					sKey[6] = iph.AddressList[0].ToString();
					sKey[6] = "";
					sKey[7] = "";
					for(uint uiCnt = 0; uiCnt < iph.AddressList.Length; uiCnt++){
//�ۗ� MOD 2008.10.23 ���s�j���� �l�`�b�A�h���X�̖��擾���̐ݒ�ύX START
//						sKey[6] = "";
//						sKey[7] = "";
//�ۗ� MOD 2008.10.23 ���s�j���� �l�`�b�A�h���X�̖��擾���̐ݒ�ύX END
						sKey[6] = iph.AddressList[uiCnt].ToString();
						// �l�`�b�A�h���X�̎擾
						sKey[7] = GetMacAddress(sKey[6]);
//�ۗ� MOD 2008.10.23 ���s�j���� �l�`�b�A�h���X�̖��擾���̐ݒ�ύX START
						if(sKey[6].Trim().Length > 0 && sKey[7].Trim().Length > 0) break;
//						if(sKey[6].Trim().Length > 0 && sKey[7].Trim().Length > 1) break;
//�ۗ� MOD 2008.10.23 ���s�j���� �l�`�b�A�h���X�̖��擾���̐ݒ�ύX END
					}
// MOD 2008.07.09 ���s�j���� �l�`�b�A�h���X�擾�̋��� END
				}
				catch(Exception)
				{
					sKey[6] = "";
// ADD 2008.07.09 ���s�j���� �l�`�b�A�h���X�擾�̋��� START
					sKey[7] = "";
// ADD 2008.07.09 ���s�j���� �l�`�b�A�h���X�擾�̋��� END
				}
// DEL 2008.07.09 ���s�j���� �l�`�b�A�h���X�擾�̋��� START
//				// �l�`�b�A�h���X�̎擾
//// MOD 2005.06.29 ���s�j���� �l�`�b�A�h���X�̎擾 START
////				sKey[7] = "-";
//				sKey[7] = GetMacAddress(sKey[6]);
//// MOD 2005.06.29 ���s�j���� �l�`�b�A�h���X�̎擾 END
// DEL 2008.07.09 ���s�j���� �l�`�b�A�h���X�擾�̋��� END
			}
			catch(Exception)
			{
				sKey[5] = "";
				sKey[6] = "";
				sKey[7] = "";
			}

			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sRet = {""};
			try
			{
				// �[���h�c�擾
				// �����F����b�c�A���p�҂b�c�A�p�X���[�h�A�T�[�}���v�����^�L���A�v�����^��ށA
				//       �R���s���[�^���A�h�o�A�h���X�A�l�`�b�A�h���X
				tex���b�Z�[�W.Text = "�����o�^���D�D�D";
				if(sv_init == null) sv_init = new is2init.Service1();
				sRet = sv_init.Set_tanmatsu(gsa���[�U,sKey);
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				sRet[0] = gs�ʐM�G���[;
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				sRet[0] = "�ʐM�G���[�F" + ex.Message;
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;

			if(sRet.Length > 1 && sRet[1] == null)
			{
				if(sRet[6] == null || int.Parse(sRet[6]) < 10)
				{
					tex���b�Z�[�W.Text = "���͂��ꂽ���e�͊Ԉ���Ă��邩�A�T�[�o�ŏ������ł��Ă��܂���B"
						+ "���͓��e���m�F���čēx���s���Ă��������B";
					MessageBox.Show("���͂��ꂽ���e�͊Ԉ���Ă��邩�A�T�[�o�ŏ������ł��Ă��܂���B\r\n���͓��e���m�F���čēx���s���Ă��������B", 
						"�F�؃G���[", 
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					// ����b�c�Ƀt�H�[�J�X
					tex����b�c.Focus();
					return;
				}
				else
				{
					//					tex���b�Z�[�W.Text = "�C���X�g�[��������ɍs���Ă��Ȃ����A�v���O�������j�����Ă���\��������܂��B"
					//									   + "�A���C���X�g�[����A�ēx�C���X�g�[�����s���Ă��������B";
					//					MessageBox.Show("�C���X�g�[��������ɍs���Ă��Ȃ����A�v���O�������j�����Ă���\��������܂��B\r\n�A���C���X�g�[����A�ēx�C���X�g�[�����s���Ă��������B", 
					//									"�F�؃G���[", 
					//									MessageBoxButtons.OK, MessageBoxIcon.Error);
					tex���b�Z�[�W.Text = "�F�؃G���[�F�Ŋ�̉c�Ə��܂Ō�A���������B";
					MessageBox.Show("�Ŋ�̉c�Ə��܂Ō�A���������B", 
						"�F�؃G���[", 
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					// ��ʂ����
					this.Close();
					return;
				}
			}

			if(sRet[0].Length != 4)
			{
				tex���b�Z�[�W.Text = sRet[0];
				return;
			}

			tex���b�Z�[�W.Text = "";

// ADD 2008.06.30 ���s�j���� �p�X���[�h�`�F�b�N�̋��� START
			if(sRet[0].Equals("����I��")){
				;
			}else if(sRet[0].Equals("�����؂�")){
				MessageBox.Show("�p�X���[�h�̗L���������؂�܂����B\n"
								+ "�p�X���[�h�̕ύX�����肢�v���܂��B"
								, "���O�C��", 
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				gs����b�c   = tex����b�c.Text;
				gs���p�҂b�c = tex���p�҂b�c.Text;
				�p�X���[�h�ύX �p�X�ύX = new �p�X���[�h�ύX();
				�p�X�ύX.s���[�h = sRet[0];
				�p�X�ύX.Left = this.Left;
				�p�X�ύX.Top  = this.Top;
				this.Visible = false;
				�p�X�ύX.ShowDialog(this);
				this.Visible = true;
				if(!�p�X�ύX.s����.Equals("�X�V")){
					gs���p�҂b�c = "";
					gs���p�Җ�   = "";
					�p�X�ύX = null;
					// ��ʂ����
					this.Close();
					return;
				}
				�p�X�ύX = null;
			}else{
				MessageBox.Show("�p�X���[�h�̗L�������� "
								+ sRet[0].Substring(0,2) + "/"
								+ sRet[0].Substring(2)
								+ " �܂łł��B\n"
								+ "�p�X���[�h�̕ύX�����肢�v���܂��B"
								, "���O�C��", 
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				gs����b�c   = tex����b�c.Text;
				gs���p�҂b�c = tex���p�҂b�c.Text;
				�p�X���[�h�ύX �p�X�ύX = new �p�X���[�h�ύX();
				�p�X�ύX.s���[�h = "�p�X�ύX";
				�p�X�ύX.Left = this.Left;
				�p�X�ύX.Top  = this.Top;
				this.Visible = false;
				�p�X�ύX.ShowDialog(this);
				this.Visible = true;
				�p�X�ύX = null;
			}
// ADD 2008.06.30 ���s�j���� �p�X���[�h�`�F�b�N�̋��� END

			// �����ݒ�t�@�C���쐬
			StreamWriter sw = File.CreateText(gsInitFile);
// MOD 2005.05.17 ���s�j���� �N�����Ԃ�Z������ START
			//			sw.WriteLine(tex����b�c.Text);
			//			sw.WriteLine(tex���p�҂b�c.Text);
			sw.WriteLine("");
			sw.WriteLine("");
// MOD 2005.05.17 ���s�j���� �N�����Ԃ�Z������ END
			if(sRet[1] != null)
			{
				sw.WriteLine(sRet[1]);	// �[���b�c
// MOD 2005.05.17 ���s�j���� �N�����Ԃ�Z������ START
//				sw.WriteLine(sRet[2]);	// �����
//				sw.WriteLine(sRet[3]);	// ���p�Җ�
//				sw.WriteLine(sRet[4]);	// ����b�c
//				sw.WriteLine(sRet[5]);	// ���喼

				gs����b�c   = tex����b�c.Text;
				gs���p�҂b�c = tex���p�҂b�c.Text;
				gs�����     = sRet[2];
				gs���p�Җ�   = sRet[3];
				gs�v�����^�e�f = sKey[3];
				gs�v�����^��� = sKey[4];
// MOD 2005.05.17 ���s�j���� �N�����Ԃ�Z������ END

				// ���b�Z�[�W��ݒ�
				//				gs���b�Z�[�W += sRet[7];	// ���b�Z�[�W
			}
			sw.Close();

			// ��ʂ����
			this.Close();
		}

		private void �����o�^_Load(object sender, System.EventArgs e)
		{
// ADD 2008.03.13 ���s�j���� �o�[�W�������̕\�� START
			if(gsa���[�U[3].Length == 0)
			{
				int iPos = 0;
				//�P�ڂ̃s���I�h
				iPos = Application.ProductVersion.IndexOf('.');
				if(iPos >= 0)
				{
					//�Q�ڂ̃s���I�h
					iPos = Application.ProductVersion.IndexOf('.',iPos+1);
					if(iPos >= 0)
					{
						gsa���[�U[3] = Application.ProductVersion.Substring(0,iPos);
					}
				}
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� START
				if(System.IO.File.Exists("IS2Client.dll")){
					System.Diagnostics.FileVersionInfo myFileVersionInfo 
						= System.Diagnostics.FileVersionInfo.GetVersionInfo("IS2Client.dll");
					iPos = 0;
					//�P�ڂ̃s���I�h
					iPos = myFileVersionInfo.FileVersion.IndexOf('.');
					if(iPos >= 0)
					{
						//�Q�ڂ̃s���I�h
						iPos = myFileVersionInfo.FileVersion.IndexOf('.',iPos+1);
						if(iPos >= 0)
						{
							gsa���[�U[3] = myFileVersionInfo.FileVersion.Substring(0,iPos);
						}
					}
				}
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� END
			}
			if(gsa���[�U[3].Length > 0) lab�o�[�W����.Text = "Ver." + gsa���[�U[3];
// ADD 2008.03.13 ���s�j���� �o�[�W�������̕\�� END
// MOD 2009.10.16 ���s�j���� �v���L�V�@�\�\�L�̒ǉ� START
			if(gbInitProxyExists) lab�o�[�W����.Text += " p";
// MOD 2009.10.16 ���s�j���� �v���L�V�@�\�\�L�̒ǉ� END
// ADD 2006.10.10 ���s�j���� �r�`�s�n���v�����^��Q�Ή� START
			string s�v�����^��� = "";
// ADD 2006.10.10 ���s�j���� �r�`�s�n���v�����^��Q�Ή� END
// MOD 2005.05.31 ���s�j�����J �v�����^�`�F�b�N START
			rBtn�L��.Checked = true;
			try
			{
// MOD 2006.10.10 ���s�j���� �r�`�s�n���v�����^��Q�Ή� START
//				�v�����^�`�F�b�N();
				s�v�����^��� = �����o�^�O�v�����^�`�F�b�N();
// MOD 2006.10.10 ���s�j���� �r�`�s�n���v�����^��Q�Ή� END
			}
			catch
			{
				rBtn����.Checked = true;
			}
// MOD 2005.05.31 ���s�j�����J �v�����^�`�F�b�N START

			// �ꗗ�̏����ݒ�
// MOD 2006.10.10 ���s�j���� �r�`�s�n���v�����^��Q�Ή� START
//			list�v�����^.SelectedIndex = 0;
			list�v�����^.SelectedIndex = 1;
			if(s�v�����^��� == "S0001")
			{
				list�v�����^.SelectedIndex = 0;
			}
			else if(s�v�����^��� == "S0002")
			{
				list�v�����^.SelectedIndex = 1;
			}
// MOD 2006.10.10 ���s�j���� �r�`�s�n���v�����^��Q�Ή� END
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� START
			else if(s�v�����^��� == "S0005")
			{
				list�v�����^.SelectedIndex = 1;
			}
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� END
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� START
			else if(s�v�����^��� == "S0006")
			{
				list�v�����^.SelectedIndex = 1;
			}
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� END
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� START
			else if(s�v�����^��� == "S0007")
			{
				list�v�����^.SelectedIndex = 2;
			}
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� END
// MOD 2015.02.12 BEVAS�j�O�c �s�d�b���v�����^(B-LV4)�Ή� START
			else if(s�v�����^��� == "S0008")
			{
				list�v�����^.SelectedIndex = 2;
			}
// MOD 2015.02.12 BEVAS�j�O�c �s�d�b���v�����^(B-LV4)�Ή� END
		}

// ADD 2005.06.29 ���s�j���� �l�`�b�A�h���X�̎擾 START
		[System.Runtime.InteropServices.DllImport("IPHLPAPI.dll")] 
		private static extern uint GetAdaptersInfo(byte[] by1, out uint ui2);

		private const uint ERROR_SUCCESS = 0;
		private const uint ERROR_BUFFER_OVERFLOW = 111;
		private const uint IP_ADAPTER_INFO_LENGTH = 640;

		/*
		 * �l�`�b�A�h���X���擾����
		 */
		private string GetMacAddress(string sSelIP)
		{
			string sRet = "-";

			if(sSelIP.Length == 0) return sRet;

			try
			{
				// �K�v�ȃf�[�^�̈�T�C�Y�̎擾
				byte[] bBuff = null;
				uint uiLen = 0;
				uint uiRet = GetAdaptersInfo(bBuff, out uiLen);
				if(uiRet == ERROR_BUFFER_OVERFLOW)
				{
					// �C���^�[�t�F�[�X���̎擾
					bBuff = new byte[uiLen];
					uiRet = GetAdaptersInfo(bBuff, out uiLen);
					if(uiRet == ERROR_SUCCESS)	//	������
					{
						string sMac   = "";
						string sIP    = "";

						uint uiNext   = 0;
						uint uiMacLen = 0;
						char[] cBuff;

						uint uiBase = 0;
						uint uiPos = 0;
						while(uiBase < uiLen)
						{
							uiNext   = ByteToUint(bBuff, uiBase +   0);
//							Console.WriteLine(uiNext.ToString("X8"));
							uiMacLen = ByteToUint(bBuff, uiBase + 400);
							
							// �l�`�b�A�h���X���擾
							uiPos = uiBase + 404;
							sMac = "";
							for(uint uiCnt = 0; uiCnt < uiMacLen; uiCnt++)
							{
// MOD 2008.07.16 ���s�j���� �l�`�b�A�h���X�̊ȈՃ}�X�L���O START
//								if(uiCnt > 0) sMac += "-";
								switch(uiCnt)
								{
									case 0:
										sMac += "Z";
										break;
									case 1:
										sMac += "Y";
										break;
									case 2:
										sMac += "I";
										break;
									case 3:
										sMac += "S";
										break;
									case 4:
										sMac += "2";
										break;
								}
// MOD 2008.07.16 ���s�j���� �l�`�b�A�h���X�̊ȈՃ}�X�L���O END
								sMac += bBuff[uiPos++].ToString("X2");
							}
//							Console.WriteLine(sMac);

							// �h�o�A�h���X���擾
							uiPos = uiBase + 432;
							cBuff = new char[16];
							Array.Copy(bBuff, uiPos, cBuff, 0, 16);
							sIP = new string(cBuff);
							sIP = sIP.Substring(0, sIP.IndexOf('\0')).Trim();
							if(sIP == sSelIP)
								return sMac;
//							Console.WriteLine(sIP);

							if(uiNext == 0)
								break;

							uiBase += IP_ADAPTER_INFO_LENGTH;
						}

					}
				}
			}
			catch(Exception)
			{
				;
			}

			return sRet;
		}

		/*
		 * �o�C�g�z�񂩂�uint�^�Ƃ��ăf�[�^���擾����
		 */
		private uint ByteToUint(byte[] byData, uint uiPos)
		{
			// �����`�F�b�N
			if(byData.Length - uiPos < 4) return 0;

// MOD 2005.07.01 ���s�j���� �ϊ������̍œK�� END
//			uint uiData = 0;
//			uiData  = (uint)byData[uiPos + 3]; uiData <<= 8;
//			uiData += (uint)byData[uiPos + 2]; uiData <<= 8;
//			uiData += (uint)byData[uiPos + 1]; uiData <<= 8;
//			uiData += (uint)byData[uiPos];
//			return uiData;
			unsafe
			{
				fixed (byte* pbyData = &byData[uiPos])
				{
					return *((uint*)pbyData);
				}
			}
// MOD 2005.07.01 ���s�j���� �ϊ������̍œK�� END
		}
// ADD 2005.06.29 ���s�j���� �l�`�b�A�h���X�̎擾 END

	}
}
