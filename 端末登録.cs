using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [�[���o�^]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// MOD 2008.10.17 ���s�j���� �e�X�g����@�\�̒ǉ� 
	//--------------------------------------------------------------------------
	// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j 
	//--------------------------------------------------------------------------
	// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� 
	//--------------------------------------------------------------------------
	// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� 
	// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή�
	// MOD 2015.02.12 BEVAS�j�O�c �s�d�b���v�����^(B-LV4)�Ή�
	//--------------------------------------------------------------------------

	public class �[���o�^ : ���ʃt�H�[��
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lab�[���o�^�^�C�g��;
		private System.Windows.Forms.Label lab�[��ID;
		private System.Windows.Forms.Label lab�[��;
		private System.Windows.Forms.RadioButton rBtn����;
		private System.Windows.Forms.RadioButton rBtn�L��;
		private System.Windows.Forms.Button btn�X�V;
		private System.Windows.Forms.TextBox tex���b�Z�[�W;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Label lab�v�����^;
		private System.Windows.Forms.Label lab���s���;
		private System.Windows.Forms.ListBox list�v�����^;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btn�e�X�g���;
		private System.ComponentModel.IContainer components = null;

		public �[���o�^()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
			�c�o�h�\���T�C�Y�ϊ�();
			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
//				this.list�v�����^.Size = new System.Drawing.Size(258, 34);
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� START
//				this.list�v�����^.Size = new System.Drawing.Size(258, (int)(34 * 1.5));
				this.list�v�����^.Size = new System.Drawing.Size(258, (int)(50 * 1.5));
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.lab�v�����^ = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rBtn���� = new System.Windows.Forms.RadioButton();
			this.rBtn�L�� = new System.Windows.Forms.RadioButton();
			this.list�v�����^ = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lab���s��� = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab�[���o�^�^�C�g�� = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn�e�X�g��� = new System.Windows.Forms.Button();
			this.btn�X�V = new System.Windows.Forms.Button();
			this.tex���b�Z�[�W = new System.Windows.Forms.TextBox();
			this.btn���� = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.panel5 = new System.Windows.Forms.Panel();
			this.lab�[��ID = new System.Windows.Forms.Label();
			this.lab�[�� = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).BeginInit();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel5.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Honeydew;
			this.panel1.Controls.Add(this.lab�v�����^);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.list�v�����^);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.lab���s���);
			this.panel1.Location = new System.Drawing.Point(0, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(370, 176);
			this.panel1.TabIndex = 1;
			// 
			// lab�v�����^
			// 
			this.lab�v�����^.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�v�����^.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�v�����^.Location = new System.Drawing.Point(32, 12);
			this.lab�v�����^.Name = "lab�v�����^";
			this.lab�v�����^.Size = new System.Drawing.Size(80, 14);
			this.lab�v�����^.TabIndex = 46;
			this.lab�v�����^.Text = "�v�����^�̗L��";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rBtn����);
			this.groupBox1.Controls.Add(this.rBtn�L��);
			this.groupBox1.Location = new System.Drawing.Point(62, 14);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(272, 40);
			this.groupBox1.TabIndex = 0;
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
			this.rBtn�L��.TabIndex = 1;
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
			this.list�v�����^.Location = new System.Drawing.Point(70, 88);
			this.list�v�����^.Name = "list�v�����^";
			this.list�v�����^.Size = new System.Drawing.Size(258, 50);
			this.list�v�����^.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 404);
			this.label1.TabIndex = 44;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab���s���
			// 
			this.lab���s���.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���s���.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���s���.Location = new System.Drawing.Point(32, 68);
			this.lab���s���.Name = "lab���s���";
			this.lab���s���.Size = new System.Drawing.Size(80, 14);
			this.lab���s���.TabIndex = 42;
			this.lab���s���.Text = "�׎D���s���";
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.PaleGreen;
			this.panel6.Location = new System.Drawing.Point(0, 26);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(810, 26);
			this.panel6.TabIndex = 12;
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.lab�[���o�^�^�C�g��);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(792, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab�[���o�^�^�C�g��
			// 
			this.lab�[���o�^�^�C�g��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�[���o�^�^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�[���o�^�^�C�g��.ForeColor = System.Drawing.Color.White;
			this.lab�[���o�^�^�C�g��.Location = new System.Drawing.Point(12, 2);
			this.lab�[���o�^�^�C�g��.Name = "lab�[���o�^�^�C�g��";
			this.lab�[���o�^�^�C�g��.Size = new System.Drawing.Size(264, 24);
			this.lab�[���o�^�^�C�g��.TabIndex = 0;
			this.lab�[���o�^�^�C�g��.Text = "�[���o�^";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn�e�X�g���);
			this.panel8.Controls.Add(this.btn�X�V);
			this.panel8.Controls.Add(this.tex���b�Z�[�W);
			this.panel8.Controls.Add(this.btn����);
			this.panel8.Location = new System.Drawing.Point(0, 286);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 2;
			// 
			// btn�e�X�g���
			// 
			this.btn�e�X�g���.ForeColor = System.Drawing.Color.Blue;
			this.btn�e�X�g���.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�e�X�g���.Location = new System.Drawing.Point(132, 6);
			this.btn�e�X�g���.Name = "btn�e�X�g���";
			this.btn�e�X�g���.Size = new System.Drawing.Size(54, 48);
			this.btn�e�X�g���.TabIndex = 7;
			this.btn�e�X�g���.Text = "�e�X�g�@�@���";
			this.btn�e�X�g���.Click += new System.EventHandler(this.btn�e�X�g���_Click);
			// 
			// btn�X�V
			// 
			this.btn�X�V.ForeColor = System.Drawing.Color.Blue;
			this.btn�X�V.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�X�V.Location = new System.Drawing.Point(70, 6);
			this.btn�X�V.Name = "btn�X�V";
			this.btn�X�V.Size = new System.Drawing.Size(54, 48);
			this.btn�X�V.TabIndex = 1;
			this.btn�X�V.Text = "�ۑ�";
			this.btn�X�V.Click += new System.EventHandler(this.btn�X�V_Click);
			// 
			// tex���b�Z�[�W
			// 
			this.tex���b�Z�[�W.BackColor = System.Drawing.Color.PaleGreen;
			this.tex���b�Z�[�W.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���b�Z�[�W.ForeColor = System.Drawing.Color.Red;
			this.tex���b�Z�[�W.Location = new System.Drawing.Point(190, 4);
			this.tex���b�Z�[�W.Multiline = true;
			this.tex���b�Z�[�W.Name = "tex���b�Z�[�W";
			this.tex���b�Z�[�W.ReadOnly = true;
			this.tex���b�Z�[�W.Size = new System.Drawing.Size(196, 50);
			this.tex���b�Z�[�W.TabIndex = 1;
			this.tex���b�Z�[�W.TabStop = false;
			this.tex���b�Z�[�W.Text = "";
			// 
			// btn����
			// 
			this.btn����.ForeColor = System.Drawing.Color.Red;
			this.btn����.Location = new System.Drawing.Point(8, 6);
			this.btn����.Name = "btn����";
			this.btn����.Size = new System.Drawing.Size(54, 48);
			this.btn����.TabIndex = 0;
			this.btn����.TabStop = false;
			this.btn����.Text = "����";
			this.btn����.Click += new System.EventHandler(this.btn����_Click);
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
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.Honeydew;
			this.panel5.Controls.Add(this.lab�[��ID);
			this.panel5.Controls.Add(this.lab�[��);
			this.panel5.Location = new System.Drawing.Point(1, 6);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(346, 32);
			this.panel5.TabIndex = 0;
			// 
			// lab�[��ID
			// 
			this.lab�[��ID.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�[��ID.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�[��ID.Location = new System.Drawing.Point(78, 8);
			this.lab�[��ID.Name = "lab�[��ID";
			this.lab�[��ID.Size = new System.Drawing.Size(86, 16);
			this.lab�[��ID.TabIndex = 7;
			this.lab�[��ID.Text = "12345678";
			// 
			// lab�[��
			// 
			this.lab�[��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�[��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�[��.Location = new System.Drawing.Point(10, 8);
			this.lab�[��.Name = "lab�[��";
			this.lab�[��.Size = new System.Drawing.Size(56, 16);
			this.lab�[��.TabIndex = 6;
			this.lab�[��.Text = "�[���h�c";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel5);
			this.groupBox2.Location = new System.Drawing.Point(32, 52);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(349, 40);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.panel1);
			this.groupBox3.Location = new System.Drawing.Point(10, 94);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(372, 184);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			// 
			// �[���o�^
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(388, 349);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.groupBox2);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(394, 374);
			this.Name = "�[���o�^";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 �[���o�^";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
			this.Load += new System.EventHandler(this.�[���o�^_Load);
			this.Closed += new System.EventHandler(this.�[���o�^_Closed);
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).EndInit();
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		private void btn����_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void �����ݒ�()
		{
			// �[���h�c
			lab�[��ID.Text = gs�[���b�c;
			// �v�����^�L��
			if(gs�v�����^�e�f == "1")
			{
				rBtn�L��.Checked = true;
				rBtn����.Checked = false;
// ADD 2008.10.17 ���s�j���� �e�X�g����@�\�̒ǉ� START
				btn�e�X�g���.Visible = true;
// ADD 2008.10.17 ���s�j���� �e�X�g����@�\�̒ǉ� END
			}
			else
			{
				rBtn�L��.Checked = false;
				rBtn����.Checked = true;
// ADD 2008.10.17 ���s�j���� �e�X�g����@�\�̒ǉ� START
				btn�e�X�g���.Visible = false;
// ADD 2008.10.17 ���s�j���� �e�X�g����@�\�̒ǉ� END
			}
			// �v�����^���
			//���[�U�v�����^�폜
//			if(gs�v�����^��� == "L0001  ")
				list�v�����^.SelectedIndex = 0;
//			else
//				list�v�����^.SelectedIndex = 1;
// ADD 2006.06.20 ���s�j���� �r�`�s�n���v�����^�Ή� START
			// �r�`�s�n���T�[�}���v�����^�i�t�r�a�j
			if(gs�v�����^��� == "S0002")
				list�v�����^.SelectedIndex = 1;
// ADD 2006.06.20 ���s�j���� �r�`�s�n���v�����^�Ή� END
//// ADD 2006.07.19 ���s�j���� �s�d�b���v�����^�Ή� START
//			// �s�d�b���T�[�}���v�����^�i�t�r�a�j
//			if(gs�v�����^��� == "S0003")
//				list�v�����^.SelectedIndex = 2;
//// ADD 2006.07.19 ���s�j���� �s�d�b���v�����^�Ή� END
//// ADD 2006.08.10 ���s�j���� �h�b�^�O�Ή��r�`�s�n���v�����^�Ή� START
//			// �h�b�^�O�Ή��r�`�s�n���T�[�}���v�����^
//			if(gs�v�����^��� == "S0004")
//				list�v�����^.SelectedIndex = 3;
//// ADD 2006.08.10 ���s�j���� �h�b�^�O�Ή��r�`�s�n���v�����^�Ή� END
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� START
			// �r�`�s�n���T�[�}���v�����^�iCS408T�j
			if(gs�v�����^��� == "S0005"){
				list�v�����^.SelectedIndex = 1;
			}
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� END
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� START
			// �r�`�s�n���T�[�}���v�����^�iCF408T�j
			if(gs�v�����^��� == "S0006")
			{
				list�v�����^.SelectedIndex = 1;
			}
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� END
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� START
			// �s�d�b���T�[�}���v�����^�iB-EV4�j
			if(gs�v�����^��� == "S0007")
			{
				list�v�����^.SelectedIndex = 2;
			}
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� END
// MOD 2015.02.12 BEVAS�j�O�c �s�d�b���v�����^(B-LV4)�Ή� START
			// �s�d�b���T�[�}���v�����^�iB-LV4�j
			if(gs�v�����^��� == "S0008")
			{
				list�v�����^.SelectedIndex = 2;
			}
// MOD 2015.02.12 BEVAS�j�O�c �s�d�b���v�����^(B-LV4)�Ή� END
		}
		private void �[���o�^_Load(object sender, System.EventArgs e)
		{

			�����ݒ�();
		}

		private void btn�X�V_Click(object sender, System.EventArgs e)
		{
// MOD 2005.05.31 ���s�j�����J �v�����^�`�F�b�N START
			tex���b�Z�[�W.Text = "";
// DEL 2006.07.19 ���s�j���� �s�d�b���v�����^�Ή� START
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
// DEL 2006.07.19 ���s�j���� �s�d�b���v�����^�Ή� END
// MOD 2005.05.31 ���s�j�����J �v�����^�`�F�b�N START

			// �f�[�^�쐬
			String[] sKey = new string[5];
			sKey[0] = gs�[���b�c;
			// �v�����^�̗L��
			if(rBtn�L��.Checked)
				sKey[1] = "1";
			else
				sKey[1] = "0";
			// �v�����^�̃t�H�[�}�b�g�̎��
			switch(list�v�����^.SelectedIndex)
			{
// MOD 2006.06.20 ���s�j���� �r�`�s�n���v�����^�Ή� START
//				case 0:	// ���[�U�[�v�����^
//					sKey[2] = "L0001  ";
//					break;
//
//				case 1:		// �T�[�}���v�����^�i�t�r�a�j
//					sKey[2] = "S0001  ";
//					break;
//
//				default:
//					sKey[2] = "S0001  ";
//					break;

				case 1:		// �r�`�s�n���T�[�}���v�����^�i�t�r�a�j
					sKey[2] = "S0002";
					break;
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� START
				case 2:		// �r�`�s�n���T�[�}���v�����^�i�t�r�a�j
					sKey[2] = "S0007";
					break;
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� END
/*
// ADD 2006.07.19 ���s�j���� �s�d�b���v�����^�Ή� START
				case 2:		// �s�d�b���T�[�}���v�����^�i�t�r�a�j
					sKey[2] = "S0003";
					break;
// ADD 2006.07.19 ���s�j���� �s�d�b���v�����^�Ή� END

// ADD 2006.08.10 ���s�j���� �h�b�^�O�Ή��r�`�s�n���v�����^�Ή� START
				case 3:		// �h�b�^�O�Ή��r�`�s�n���T�[�}���v�����^
					sKey[2] = "S0004";
					break;
// ADD 2006.08.10 ���s�j���� �h�b�^�O�Ή��r�`�s�n���v�����^�Ή� END
*/
				default:	// �y�d�a�q�`���T�[�}���v�����^�i�t�r�a�j
					sKey[2] = "S0001";
					break;
// MOD 2006.06.20 ���s�j���� �r�`�s�n���v�����^�Ή� END
			}
			sKey[3] = "�[���o�^";
			sKey[4] = gs���p�҂b�c;
// ADD 2006.07.19 ���s�j���� �s�d�b���v�����^�Ή� START
			if(rBtn�L��.Checked)
			{
				try
				{
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� START
//					�v�����^�`�F�b�N(sKey[2]);
					sKey[2] = �v�����^�`�F�b�N(sKey[2]);
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
// ADD 2006.07.19 ���s�j���� �s�d�b���v�����^�Ή� END

//			DialogResult result = MessageBox.Show("���ɑ��݂���f�[�^�ɏ㏑�����܂����H","�X�V",MessageBoxButtons.YesNo);
//			if(result == DialogResult.Yes)
//			{
				// �J�[�\���������v�ɂ���
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				string sRet = "";
				try
				{
					// �[�����X�V
					// �����F����b�c�A���p�҂b�c�A�T�[�}���v�����^�L���A�v�����^��ށA
					tex���b�Z�[�W.Text = "�X�V���D�D�D";
					if(sv_init == null) sv_init = new is2init.Service1();
					sRet = sv_init.Upd_tanmatsu(gsa���[�U,sKey);
				}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
				catch (System.Net.WebException)
				{
					sRet = gs�ʐM�G���[;
				}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
				catch (Exception ex)
				{
					sRet = "�ʐM�G���[�F" + ex.Message;
				}
				// �J�[�\�����f�t�H���g�ɖ߂�
				Cursor = System.Windows.Forms.Cursors.Default;

				tex���b�Z�[�W.Text = sRet;
				// ����I����
				if(sRet.Length == 4)
				{
					tex���b�Z�[�W.Text = "";
					gs�v�����^�e�f = sKey[1];
					gs�v�����^��� = sKey[2];
					this.Close();
				}
//			}
		}

// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� START
		private void �[���o�^_Closed(object sender, System.EventArgs e)
		{
			tex���b�Z�[�W.Text = "";
			if(rBtn�L��.Checked == true)
				rBtn�L��.Focus();
			else
				rBtn����.Focus();
		}
// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� END

		private void btn�e�X�g���_Click(object sender, System.EventArgs e)
		{
			// �v�����^�̗L��
			if(rBtn�L��.Checked == false) return; 

			// �v�����^�̃t�H�[�}�b�g�̎��
			string sPrtFormat = "";
			switch(list�v�����^.SelectedIndex)
			{
				case 1:		// �r�`�s�n���T�[�}���v�����^�i�t�r�a�j
					sPrtFormat = "S0002";
					break;
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� START
				case 2:		// �s�d�b���T�[�}���v�����^�i�t�r�a�j
					sPrtFormat = "S0007";
					break;
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� END
				default:	// �y�d�a�q�`���T�[�}���v�����^�i�t�r�a�j
					sPrtFormat = "S0001";
					break;
			}

			try
			{
				�v�����^�`�F�b�N(sPrtFormat);
			}
			catch(Exception ex)
			{
				�r�[�v��();
				MessageBox.Show(ex.Message, "�v�����^�`�F�b�N",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			Cursor = System.Windows.Forms.Cursors.AppStarting;

// DEL 2008.10.15 ���s�j���� �e�X�g����@�\�̒ǉ� START
//			i�����e�f = 1;
// DEL 2008.10.15 ���s�j���� �e�X�g����@�\�̒ǉ� END

// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j START
//			ds�����.Clear();
			�����f�[�^�N���A();
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j END

			try
			{
				�e�X�g����w��(sender, e);
			}
			catch (Exception ex)
			{
				tex���b�Z�[�W.Text = ex.Message;
				�r�[�v��();
				return;
			}
			Cursor = System.Windows.Forms.Cursors.Default;

// DEL 2008.10.15 ���s�j���� �e�X�g����@�\�̒ǉ� START
//			if(i�����e�f == 1)
// DEL 2008.10.15 ���s�j���� �e�X�g����@�\�̒ǉ� END
				����󒠕[���();
		
			tex���b�Z�[�W.Text = "";
// DEL 2008.10.15 ���s�j���� �e�X�g����@�\�̒ǉ� START
//			if(i�����e�f == 1)
//				Close();
// DEL 2008.10.15 ���s�j���� �e�X�g����@�\�̒ǉ� END
		}

// ADD 2008.10.17 ���s�j���� �e�X�g����@�\�̒ǉ� START
		private void �e�X�g����w��(object sender, System.EventArgs e)
		{
			try
			{
				//���̓`�F�b�N
//				i����e�f = 0;
//				btn�X�V_Click(sender,e);
//				if(i����e�f == 0)
//				{
//					Cursor = System.Windows.Forms.Cursors.Default;
//					return;
//				}

				//�f�[�^�ݒ�
				string[] sPrintData = new string[39];
				sPrintData[0]  = "";
				sPrintData[1]  = "";	// tex�͂���R�[�h.Text;    
				sPrintData[2]  = "";	// tex�͂���d�b�ԍ��P.Text;
				sPrintData[3]  = "";	// tex�͂���d�b�ԍ��Q.Text;
				sPrintData[4]  = "";	// tex�͂���d�b�ԍ��R.Text;
				if(sPrintData[2].Length == 0) sPrintData[2] = "123456";
				if(sPrintData[3].Length == 0) sPrintData[3] = "2234";
				if(sPrintData[4].Length == 0) sPrintData[4] = "3234";

				sPrintData[5]  = "";	// tex�͂���Z���P.Text;    
				sPrintData[6]  = "";	// tex�͂���Z���Q.Text;    
				sPrintData[7]  = "";	// tex�͂���Z���R.Text;    
				sPrintData[8]  = "";	// tex�͂��於�O�P.Text;    
				sPrintData[9]  = "";	// tex�͂��於�O�Q.Text;    
				sPrintData[10] = gs�o�ד�;	// YYYYMMDD�ϊ�(dt�o�ד�.Value);;

				//�����ԍ�
				sPrintData[11] = "00001234567890";
				//�`�F�b�N�f�W�b�g�i�V�Ŋ������]��j�̕t��
				sPrintData[11] = sPrintData[11] + (long.Parse(sPrintData[11]) % 7).ToString();

				sPrintData[12] = "";	// tex�͂���X�֔ԍ��P.Text + tex�͂���X�֔ԍ��Q.Text;
//�ۗ��@���X�b�c�̌���
//�ۗ��@���X��\��
//�ۗ��@���X���̌���
//�ۗ��@�d���̌���
				sPrintData[13] = "0999";	//���X�b�c
				if(gs���p�ҕ���X���b�c == null || gs���p�ҕ���X���b�c.Length == 0){
					sPrintData[14] = "0888";
				}else{
					sPrintData[14] = "0" + gs���p�ҕ���X���b�c.Trim();
				}
				sPrintData[15] = "";	// tex�˗���d�b�ԍ��P.Text;
				sPrintData[16] = "";	// tex�˗���d�b�ԍ��Q.Text;
				sPrintData[17] = "";	// tex�˗���d�b�ԍ��R.Text;
				if(sPrintData[15].Length == 0) sPrintData[15] = "423456";
				if(sPrintData[16].Length == 0) sPrintData[16] = "5234";
				if(sPrintData[17].Length == 0) sPrintData[17] = "6234";
				sPrintData[18] = "";	// tex�˗���Z���P.Text;
				sPrintData[19] = "";	// tex�˗���Z���Q.Text;
				sPrintData[20] = "";	//�˗���Z���R
				sPrintData[21] = "";	// tex�˗��喼�O�P.Text;
				sPrintData[22] = "";	// tex�˗��喼�O�Q.Text;
				sPrintData[23] = "0";	// nUD��.Value.ToString();
				if(sPrintData[23].Length == 0) sPrintData[23] = "99";
				if(sPrintData[23].Trim().Equals("0")) sPrintData[23] = "99";

				//�ː��̏ꍇ�F�d�ʁ��ː����W
//				if(i�ː��e�f == 0){
//					sPrintData[24] = "0";	// (nUD�d��.Value * 8).ToString();
//				}else{
					sPrintData[24] = "0";	// nUD�d��.Value.ToString();
//				}
				sPrintData[25] = "0";	// nUD�ی����z.Value.ToString();

//				if(cBox�w���.Checked == true){
//					sPrintData[26] = YYYYMMDD�ϊ�(dt�w���.Value);
//				}else{
					sPrintData[26] = "0";
//				}

				sPrintData[27] = "";	// tex�A�����e.Text;        
				sPrintData[28] = "";	// tex�A�����q.Text;        
				sPrintData[29] = "";	// tex�L�����P.Text;        
				sPrintData[30] = "";	// tex�L�����Q.Text;        
				sPrintData[31] = "";	// tex�L�����R.Text;        

				sPrintData[32] = "1";	//�����敪
				sPrintData[33] = "0";	//����󔭍s�ςe�f

				sPrintData[34] = "";	// tex�˗��啔��.Text;      
				sPrintData[35] = "";	// tex���q�l�Ǘ��ԍ�.Text;  
				sPrintData[36] = "0";	//�O�F�K���A�P�F�w��

//				sPrintData[37] = "XXX";	//�d���b�c
//				sPrintData[38] = "���X���S";	//���X��
				sPrintData[37] = "ý�";	//�d���b�c
				sPrintData[38] = "�w�w�w�w";	//���X��

				{
					�����f�[�^.table�����Row tr = (�����f�[�^.table�����Row)ds�����.table�����.NewRow();
						
					tr.BeginEdit();
					tr.����� = i�����++;
					tr.�׎�l�b�c     = sPrintData[1];
					tr.�׎�l�d�b�ԍ� = "(" + sPrintData[2] + ")" + sPrintData[3] + "-" + sPrintData[4];

// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//					string s�Z���ҏW  = �Z���ҏW(sPrintData[5]);
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
//					string[] s�Z������ = s�Z���ҏW.Split(' ');
					string[] s�Z������ = new string []{"�����������@�e�X�g����@����������"};
					tr.�׎�l�Z����   = s�Z������[0];
					if (s�Z������.Length > 1)
						tr.�׎�l�Z���s = s�Z������[1].PadLeft(s�Z������[1].Length + s�Z������[0].Length);
					else 
						tr.�׎�l�Z���s = "";
					if (s�Z������.Length > 2)
					{
						if (s�Z������[0].Length + s�Z������[1].Length >= 9)
							tr.�׎�l�Z���� = s�Z������[2].PadLeft(s�Z������[2].Length + s�Z������[0].Length + s�Z������[1].Length + 1);
						else
							tr.�׎�l�Z���� = s�Z������[2].PadLeft(s�Z������[2].Length + s�Z������[0].Length + s�Z������[1].Length);
					}
					else
						tr.�׎�l�Z���� = "";

//					tr.�׎�l�Z���P   = sPrintData[5];
					tr.�׎�l�Z���P   = "�����������@�e�X�g����@����������";
					tr.�׎�l�Z���Q   = sPrintData[6];
					tr.�׎�l�Z���R   = sPrintData[7];
					tr.�׎�l���O�P   = sPrintData[8];
					tr.�׎�l���O�Q   = sPrintData[9];
					tr.�o�ד��N       = sPrintData[10].Substring(2, 2);
					if(sPrintData[10].Substring(4, 1) == "0")
						tr.�o�ד���       = " " + sPrintData[10].Substring(5, 1);
					else
						tr.�o�ד���       = sPrintData[10].Substring(4, 2);
					if(sPrintData[10].Substring(6, 1) == "0")
						tr.�o�ד���       = " " + sPrintData[10].Substring(7, 1);
					else
						tr.�o�ד���       = sPrintData[10].Substring(6, 2);
					tr.�����ԍ�     = sPrintData[11].Substring(4,3) + "-" + sPrintData[11].Substring(7,4) + "-" + sPrintData[11].Substring(11,4);

					tr.�o�[�R�[�h     = "A" + sPrintData[11].Substring(4) + "01" + "A";

					if(sPrintData[13].Length == 0)
						tr.���X�b�c       = "";
					else
						tr.���X�b�c       = sPrintData[13].Substring(1);

					//�d���b�c���ݒ肳��Ă���ꍇ�A�d���b�c�A���X������
					if(sPrintData[37].Length > 0){
						tr.�d���b�c       = sPrintData[37];
						tr.���X��         = sPrintData[38];
					}else{
						tr.�d���b�c       = "";
						tr.���X��         = "";
					}
					tr.���X�b�c       = sPrintData[14].Substring(1, 3);

					if(sPrintData[14].Substring(1, 3) == "047"){
						tr.�o�ד��N       = "";
						tr.�o�ד���       = "";
						tr.�o�ד���       = "";
						tr.���X��         = "";
						tr.���X�b�c       = "";
					}

					tr.�ב��l�d�b�ԍ� = "(" + sPrintData[15] + ")" + sPrintData[16] + "-" + sPrintData[17];

//�ۗ� MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
					tr.�ב��l�Z���P   = �Z���ҏW(sPrintData[18]);
//					tr.�ב��l�Z���P   = sPrintData[18];
//�ۗ� MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
					tr.�ב��l�Z���Q   = sPrintData[19];
					tr.�ב��l�Z���R   = sPrintData[18];
					tr.�ב��l���O�P   = sPrintData[21];
					tr.�ב��l���O�Q   = sPrintData[22];
					tr.�S����         = sPrintData[34];
					tr.��           = sPrintData[23];

					tr.�A��           = "1";

					tr.�d��           = sPrintData[24];
					int i�ی��� = int.Parse(sPrintData[25]) * 10;
					if(i�ی��� > 0 && i�ی��� < 50)
					{
						tr.�ی���     = "50";
					}
					else
					{
						string s�ی��� = i�ی���.ToString();
						if(s�ی���.Length == 4)
							s�ی��� = s�ی���.Insert(1,",");
						else
						{
							if(s�ی���.Length == 5)
								s�ی��� = s�ی���.Insert(2,",");
						}
						tr.�ی���     = s�ی���;
					}
					string s�w�茎;
					string s�w���;
					if (sPrintData[26] != null && !sPrintData[26].Equals("") && !sPrintData[26].Equals("0"))
					{
						if(sPrintData[26].Substring(4, 1) == "0")
							s�w�茎 = " " + sPrintData[26].Substring(5, 1);
						else
							s�w�茎 = sPrintData[26].Substring(4, 2);

						if(sPrintData[26].Substring(6, 1) == "0")
							s�w��� = " " + sPrintData[26].Substring(7, 1);
						else
							s�w��� = sPrintData[26].Substring(6, 2);

						tr.�w���     = s�w�茎 + "��" + s�w��� + "��";
						if (sPrintData[36].Equals("0"))
							tr.�w��� += "�K��";
						else if (sPrintData[36].Equals("1"))
							tr.�w��� += "�w��";
					}
					else
						tr.�w���     = "";

					if(sPrintData[35].Length != 0)
						tr.���q�l�ԍ�     = "���q�l�ԍ�:" + sPrintData[35];
					else
						tr.���q�l�ԍ�     = sPrintData[35];

					tr.�A���L���P     = sPrintData[27];
					tr.�A���L���Q     = sPrintData[28];
					tr.�i���L���P     = sPrintData[29];
					tr.�i���L���Q     = sPrintData[30];
					tr.�i���L���R     = sPrintData[31];

					tr.EndEdit();
					ds�����.table�����.Rows.Add(tr);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
// ADD 2008.10.17 ���s�j���� �e�X�g����@�\�̒ǉ� END

	}
}
