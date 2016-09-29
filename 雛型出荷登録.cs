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
	/// [�N�C�b�N�G���g���[]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// MOD 2008.11.14 ���s�j���� �w����敪�̕��� 
	//--------------------------------------------------------------------------
	// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N 
	// ADD 2009.04.02 ���s�j���� �ғ����Ή� 
	// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� 
	//--------------------------------------------------------------------------
	// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� 
	// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� 
	// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j 
	// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� 
	// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� 
	//--------------------------------------------------------------------------
	// MOD 2016.04.13 BEVAS�j���{ �z�B�w�������̊g��
	//--------------------------------------------------------------------------
	public class ���^�o�דo�^ : ���ʃt�H�[��
	{
		private int  i����e�f = 0;
		private int  i���^�m�n = 0;
		private string s�W���[�i���m�n = "";
		private string s�o�^�� = "";
// ADD 2009.04.02 ���s�j���� �ғ����Ή� START
		private DateTime dt�w����ő�l;
		private DateTime dt�w����ŏ��l;
// ADD 2009.04.02 ���s�j���� �ғ����Ή� END
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
		private bool b�w����`�F�b�N�l�r�f�L = false;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END

		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn�A�C�R���\��;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ListView listView���^;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Button btn�o�דo�^;
		private System.Windows.Forms.Button btn�������;
		private System.Windows.Forms.Button btn���^�쐬;
		private System.Windows.Forms.Button btn���^�ҏW;
		private System.Windows.Forms.Button btn���^�폜;
		private System.Windows.Forms.DateTimePicker dt�o�ד�;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab����;
		private System.Windows.Forms.DateTimePicker dt�w���;
		private System.Windows.Forms.TextBox tex���q�l��;
		private System.Windows.Forms.Label lab���q�l��;
		private System.Windows.Forms.Label lab���p����;
		private System.Windows.Forms.TextBox tex���p����;
		private System.Windows.Forms.Label lab���^�o�דo�^;
		private System.Windows.Forms.TextBox tex���b�Z�[�W;
		private System.Windows.Forms.Label lab�o�ד�;
		private System.Windows.Forms.Label lab�w���;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox cBox�w���;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn�V���[�g�J�b�g;
		private System.Windows.Forms.ComboBox cmb�w����敪;
		private System.Boolean �A�C�R���\����� = true;

		public ���^�o�דo�^()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(���^�o�דo�^));
			this.panel6 = new System.Windows.Forms.Panel();
			this.tex���q�l�� = new System.Windows.Forms.TextBox();
			this.lab���q�l�� = new System.Windows.Forms.Label();
			this.lab���p���� = new System.Windows.Forms.Label();
			this.tex���p���� = new System.Windows.Forms.TextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab���� = new System.Windows.Forms.Label();
			this.lab���^�o�דo�^ = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn���^�폜 = new System.Windows.Forms.Button();
			this.btn���^�ҏW = new System.Windows.Forms.Button();
			this.btn���^�쐬 = new System.Windows.Forms.Button();
			this.btn������� = new System.Windows.Forms.Button();
			this.btn�o�דo�^ = new System.Windows.Forms.Button();
			this.tex���b�Z�[�W = new System.Windows.Forms.TextBox();
			this.btn���� = new System.Windows.Forms.Button();
			this.btn�V���[�g�J�b�g = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.panel5 = new System.Windows.Forms.Panel();
			this.cmb�w����敪 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cBox�w��� = new System.Windows.Forms.CheckBox();
			this.dt�o�ד� = new System.Windows.Forms.DateTimePicker();
			this.lab�o�ד� = new System.Windows.Forms.Label();
			this.dt�w��� = new System.Windows.Forms.DateTimePicker();
			this.lab�w��� = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btn�A�C�R���\�� = new System.Windows.Forms.Button();
			this.listView���^ = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel5.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.PaleGreen;
			this.panel6.Controls.Add(this.tex���q�l��);
			this.panel6.Controls.Add(this.lab���q�l��);
			this.panel6.Controls.Add(this.lab���p����);
			this.panel6.Controls.Add(this.tex���p����);
			this.panel6.Location = new System.Drawing.Point(0, 26);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(810, 26);
			this.panel6.TabIndex = 12;
			// 
			// tex���q�l��
			// 
			this.tex���q�l��.BackColor = System.Drawing.Color.PaleGreen;
			this.tex���q�l��.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex���q�l��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���q�l��.ForeColor = System.Drawing.Color.LimeGreen;
			this.tex���q�l��.Location = new System.Drawing.Point(624, 6);
			this.tex���q�l��.Name = "tex���q�l��";
			this.tex���q�l��.ReadOnly = true;
			this.tex���q�l��.Size = new System.Drawing.Size(162, 16);
			this.tex���q�l��.TabIndex = 12;
			this.tex���q�l��.TabStop = false;
			this.tex���q�l��.Text = "���~�����Q�Q�Q�Q�Q��";
			this.tex���q�l��.Visible = false;
			// 
			// lab���q�l��
			// 
			this.lab���q�l��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���q�l��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���q�l��.Location = new System.Drawing.Point(566, 8);
			this.lab���q�l��.Name = "lab���q�l��";
			this.lab���q�l��.Size = new System.Drawing.Size(52, 14);
			this.lab���q�l��.TabIndex = 11;
			this.lab���q�l��.Text = "���[�U�[";
			this.lab���q�l��.Visible = false;
			// 
			// lab���p����
			// 
			this.lab���p����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���p����.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���p����.Location = new System.Drawing.Point(14, 8);
			this.lab���p����.Name = "lab���p����";
			this.lab���p����.Size = new System.Drawing.Size(58, 14);
			this.lab���p����.TabIndex = 10;
			this.lab���p����.Text = "�Z�N�V����";
			// 
			// tex���p����
			// 
			this.tex���p����.BackColor = System.Drawing.Color.PaleGreen;
			this.tex���p����.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex���p����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���p����.ForeColor = System.Drawing.Color.LimeGreen;
			this.tex���p����.Location = new System.Drawing.Point(78, 6);
			this.tex���p����.Name = "tex���p����";
			this.tex���p����.ReadOnly = true;
			this.tex���p����.Size = new System.Drawing.Size(474, 16);
			this.tex���p����.TabIndex = 8;
			this.tex���p����.TabStop = false;
			this.tex���p����.Text = "1234 �{�ЁQ�Q�Q�Q�Q�Q�Q��";
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.lab����);
			this.panel7.Controls.Add(this.lab���^�o�דo�^);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(792, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab����
			// 
			this.lab����.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab����.ForeColor = System.Drawing.Color.White;
			this.lab����.Location = new System.Drawing.Point(674, 8);
			this.lab����.Name = "lab����";
			this.lab����.Size = new System.Drawing.Size(112, 14);
			this.lab����.TabIndex = 1;
			this.lab����.Text = "2005/xx/xx 12:00:00";
			// 
			// lab���^�o�דo�^
			// 
			this.lab���^�o�דo�^.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab���^�o�דo�^.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���^�o�דo�^.ForeColor = System.Drawing.Color.White;
			this.lab���^�o�דo�^.Location = new System.Drawing.Point(12, 2);
			this.lab���^�o�דo�^.Name = "lab���^�o�דo�^";
			this.lab���^�o�דo�^.Size = new System.Drawing.Size(264, 24);
			this.lab���^�o�דo�^.TabIndex = 0;
			this.lab���^�o�דo�^.Text = "�N�C�b�N�G���g���[";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn���^�폜);
			this.panel8.Controls.Add(this.btn���^�ҏW);
			this.panel8.Controls.Add(this.btn���^�쐬);
			this.panel8.Controls.Add(this.btn�������);
			this.panel8.Controls.Add(this.btn�o�דo�^);
			this.panel8.Controls.Add(this.tex���b�Z�[�W);
			this.panel8.Controls.Add(this.btn����);
			this.panel8.Controls.Add(this.btn�V���[�g�J�b�g);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 14;
			// 
			// btn���^�폜
			// 
			this.btn���^�폜.ForeColor = System.Drawing.Color.Blue;
			this.btn���^�폜.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn���^�폜.Location = new System.Drawing.Point(372, 6);
			this.btn���^�폜.Name = "btn���^�폜";
			this.btn���^�폜.Size = new System.Drawing.Size(62, 48);
			this.btn���^�폜.TabIndex = 10;
			this.btn���^�폜.Text = "���C�u�����@�폜";
			this.btn���^�폜.Click += new System.EventHandler(this.btn���^�폜_Click);
			// 
			// btn���^�ҏW
			// 
			this.btn���^�ҏW.ForeColor = System.Drawing.Color.Blue;
			this.btn���^�ҏW.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn���^�ҏW.Location = new System.Drawing.Point(302, 6);
			this.btn���^�ҏW.Name = "btn���^�ҏW";
			this.btn���^�ҏW.Size = new System.Drawing.Size(62, 48);
			this.btn���^�ҏW.TabIndex = 9;
			this.btn���^�ҏW.Text = "���C�u�����@�ҏW";
			this.btn���^�ҏW.Click += new System.EventHandler(this.btn���^�ҏW_Click);
			// 
			// btn���^�쐬
			// 
			this.btn���^�쐬.ForeColor = System.Drawing.Color.Blue;
			this.btn���^�쐬.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn���^�쐬.Location = new System.Drawing.Point(232, 6);
			this.btn���^�쐬.Name = "btn���^�쐬";
			this.btn���^�쐬.Size = new System.Drawing.Size(62, 48);
			this.btn���^�쐬.TabIndex = 8;
			this.btn���^�쐬.Text = "���C�u�����@�o�^";
			this.btn���^�쐬.Click += new System.EventHandler(this.btn���^�쐬_Click);
			// 
			// btn�������
			// 
			this.btn�������.ForeColor = System.Drawing.Color.Blue;
			this.btn�������.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�������.Location = new System.Drawing.Point(82, 6);
			this.btn�������.Name = "btn�������";
			this.btn�������.Size = new System.Drawing.Size(62, 48);
			this.btn�������.TabIndex = 2;
			this.btn�������.Text = "���x���@�@���";
			this.btn�������.Click += new System.EventHandler(this.btn�������_Click);
			// 
			// btn�o�דo�^
			// 
			this.btn�o�דo�^.ForeColor = System.Drawing.Color.Blue;
			this.btn�o�דo�^.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�o�דo�^.Location = new System.Drawing.Point(152, 6);
			this.btn�o�דo�^.Name = "btn�o�דo�^";
			this.btn�o�דo�^.Size = new System.Drawing.Size(62, 48);
			this.btn�o�דo�^.TabIndex = 7;
			this.btn�o�דo�^.Text = "�G���g���[";
			this.btn�o�דo�^.Click += new System.EventHandler(this.btn�o�דo�^_Click);
			// 
			// tex���b�Z�[�W
			// 
			this.tex���b�Z�[�W.BackColor = System.Drawing.Color.PaleGreen;
			this.tex���b�Z�[�W.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���b�Z�[�W.ForeColor = System.Drawing.Color.Red;
			this.tex���b�Z�[�W.Location = new System.Drawing.Point(520, 4);
			this.tex���b�Z�[�W.Multiline = true;
			this.tex���b�Z�[�W.Name = "tex���b�Z�[�W";
			this.tex���b�Z�[�W.ReadOnly = true;
			this.tex���b�Z�[�W.Size = new System.Drawing.Size(270, 50);
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
			// btn�V���[�g�J�b�g
			// 
			this.btn�V���[�g�J�b�g.ForeColor = System.Drawing.Color.Blue;
			this.btn�V���[�g�J�b�g.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�V���[�g�J�b�g.Location = new System.Drawing.Point(450, 6);
			this.btn�V���[�g�J�b�g.Name = "btn�V���[�g�J�b�g";
			this.btn�V���[�g�J�b�g.Size = new System.Drawing.Size(62, 48);
			this.btn�V���[�g�J�b�g.TabIndex = 19;
			this.btn�V���[�g�J�b�g.Text = "�޽�į�߂ɓ\�t";
			this.btn�V���[�g�J�b�g.Click += new System.EventHandler(this.btn�V���[�g�J�b�g_Click);
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
			this.panel5.Controls.Add(this.cmb�w����敪);
			this.panel5.Controls.Add(this.cBox�w���);
			this.panel5.Controls.Add(this.dt�o�ד�);
			this.panel5.Controls.Add(this.lab�o�ד�);
			this.panel5.Controls.Add(this.lab�w���);
			this.panel5.Controls.Add(this.label2);
			this.panel5.Controls.Add(this.dt�w���);
			this.panel5.Font = new System.Drawing.Font("MS UI Gothic", 12F);
			this.panel5.Location = new System.Drawing.Point(1, 6);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(579, 32);
			this.panel5.TabIndex = 1;
			// 
			// cmb�w����敪
			// 
			this.cmb�w����敪.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb�w����敪.Items.AddRange(new object[] {
														  "�K��",
														  "�w��"});
			this.cmb�w����敪.Location = new System.Drawing.Point(490, 4);
			this.cmb�w����敪.Name = "cmb�w����敪";
			this.cmb�w����敪.Size = new System.Drawing.Size(56, 24);
			this.cmb�w����敪.TabIndex = 44;
			this.cmb�w����敪.TabStop = false;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(350, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 16);
			this.label2.TabIndex = 10;
			// 
			// cBox�w���
			// 
			this.cBox�w���.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cBox�w���.Location = new System.Drawing.Point(326, 8);
			this.cBox�w���.Name = "cBox�w���";
			this.cBox�w���.Size = new System.Drawing.Size(16, 16);
			this.cBox�w���.TabIndex = 8;
			this.cBox�w���.TabStop = false;
			this.cBox�w���.Text = "checkBox1";
			this.cBox�w���.Click += new System.EventHandler(this.cBox�w���_Click);
			// 
			// dt�o�ד�
			// 
			this.dt�o�ד�.Location = new System.Drawing.Point(86, 4);
			this.dt�o�ד�.MaxDate = new System.DateTime(2105, 12, 31, 0, 0, 0, 0);
			this.dt�o�ד�.MinDate = new System.DateTime(2005, 1, 1, 0, 0, 0, 0);
			this.dt�o�ד�.Name = "dt�o�ד�";
			this.dt�o�ד�.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.dt�o�ד�.Size = new System.Drawing.Size(144, 23);
			this.dt�o�ד�.TabIndex = 0;
			this.dt�o�ד�.ValueChanged += new System.EventHandler(this.dt�o�ד�_ValueChanged);
			// 
			// lab�o�ד�
			// 
			this.lab�o�ד�.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�o�ד�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�o�ד�.Location = new System.Drawing.Point(8, 8);
			this.lab�o�ד�.Name = "lab�o�ד�";
			this.lab�o�ד�.Size = new System.Drawing.Size(56, 16);
			this.lab�o�ד�.TabIndex = 6;
			this.lab�o�ד�.Text = "�o�ד�";
			// 
			// dt�w���
			// 
			this.dt�w���.Location = new System.Drawing.Point(346, 4);
			this.dt�w���.MaxDate = new System.DateTime(2105, 12, 31, 0, 0, 0, 0);
			this.dt�w���.MinDate = new System.DateTime(2005, 1, 1, 0, 0, 0, 0);
			this.dt�w���.Name = "dt�w���";
			this.dt�w���.Size = new System.Drawing.Size(142, 23);
			this.dt�w���.TabIndex = 9;
			this.dt�w���.TabStop = false;
			this.dt�w���.Value = new System.DateTime(2005, 2, 2, 0, 0, 0, 0);
			this.dt�w���.DropDown += new System.EventHandler(this.dt�w���_DropDown);
			// 
			// lab�w���
			// 
			this.lab�w���.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�w���.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�w���.Location = new System.Drawing.Point(256, 8);
			this.lab�w���.Name = "lab�w���";
			this.lab�w���.Size = new System.Drawing.Size(56, 16);
			this.lab�w���.TabIndex = 6;
			this.lab�w���.Text = "�w���";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Blue;
			this.label1.Location = new System.Drawing.Point(22, 90);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 380);
			this.label1.TabIndex = 17;
			this.label1.Text = "���C�u����";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn�A�C�R���\��
			// 
			this.btn�A�C�R���\��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.btn�A�C�R���\��.ForeColor = System.Drawing.Color.Blue;
			this.btn�A�C�R���\��.Location = new System.Drawing.Point(690, 58);
			this.btn�A�C�R���\��.Name = "btn�A�C�R���\��";
			this.btn�A�C�R���\��.Size = new System.Drawing.Size(78, 26);
			this.btn�A�C�R���\��.TabIndex = 18;
			this.btn�A�C�R���\��.Text = "�ꗗ�\��";
			this.btn�A�C�R���\��.Click += new System.EventHandler(this.btn�A�C�R���\��_Click);
			// 
			// listView���^
			// 
			this.listView���^.BackColor = System.Drawing.Color.Honeydew;
			this.listView���^.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.columnHeader1,
																						 this.columnHeader2});
			this.listView���^.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.listView���^.LabelEdit = true;
			this.listView���^.Location = new System.Drawing.Point(44, 90);
			this.listView���^.Name = "listView���^";
			this.listView���^.Size = new System.Drawing.Size(726, 380);
			this.listView���^.TabIndex = 0;
			this.listView���^.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView���^_KeyDown);
			this.listView���^.DoubleClick += new System.EventHandler(this.listView���^_DoubleClick);
			this.listView���^.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView���^_ColumnClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "���^��";
			this.columnHeader1.Width = 662;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "�\����";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel5);
			this.groupBox1.Location = new System.Drawing.Point(44, 473);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(584, 40);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// ���^�o�דo�^
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 574);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btn�A�C�R���\��);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listView���^);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "���^�o�דo�^";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 �N�C�b�N�G���g���[";
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX START
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.On�G���^�[�ړ�);
            //this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.On�G���^�[�L�����Z��);
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX END
            this.Load += new System.EventHandler(this.���^�o�דo�^_Load);
			this.Closed += new System.EventHandler(this.���^�o�דo�^_Closed);
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX START
        protected void On�G���^�[�ړ�(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            base.�G���^�[�ړ�(sender, e);
        }

        protected void On�G���^�[�L�����Z��(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            base.�G���^�[�L�����Z��(sender, e);
        }
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX END

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		private void ���^�o�דo�^_Load(object sender, System.EventArgs e)
		{
			// �w�b�_�[���ڂ̐ݒ�
			tex���q�l��.Text = gs���p�Җ�;
			tex���p����.Text = gs����b�c + " " + gs���喼;

			// �����̏����ݒ�
			lab����.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled = true;

// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� START
			//����X�����擾����Ă��Ȃ��ꍇ�ɂ́A
			if(gs����X���b�c == null || gs����X���b�c.Length == 0){
				gs����X���b�c = ����X���擾(gs����b�c);
			}
// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� END

			// �o�ד��̏����ݒ�i�����j
			����o�ד����X�V();
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
			//�w����`�F�b�N�𖳌��ɂ���
			//�idt�o�ד�.Value�j��ύX�����C�x���g�Ń`�F�b�N�������
			cBox�w���.Checked = false;
			b�w����`�F�b�N�l�r�f�L = false;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
			dt�o�ד�.Value   = gdt�o�ד�;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
			b�w����`�F�b�N�l�r�f�L = true;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
			dt�o�ד�.MinDate = gdt�o�ד�;
// ADD 2009.04.02 ���s�j���� �ғ����Ή� START
//			dt�o�ד�.MaxDate = gdt�o�ד�.AddDays(7);
			dt�o�ד�.MaxDate = gdt�o�ד��ő�l;
// ADD 2009.04.02 ���s�j���� �ғ����Ή� END
			// �w����̏����ݒ�i�����{�Q���j
// MOD 2007.02.20 ���s�j���� �o�ד��𗂓��ɕύX START
//			dt�w���.Value   = gdt�o�ד�.AddDays(2);
			dt�w���.Value   = gdt�o�ד�.AddDays(1);
// MOD 2007.02.20 ���s�j���� �o�ד��𗂓��ɕύX END
			dt�w���.MinDate = gdt�o�ד�;
// ADD 2009.04.02 ���s�j���� �ғ����Ή� START
//			dt�w���.MaxDate = gdt�o�ד�.AddDays(20);
// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� START
//			dt�w���.MaxDate = gdt�o�ד�.AddDays(14);
			if(gs����X���b�c.Equals("047")){
				dt�w���.MaxDate = gdt�o�ד�.AddDays(90);
			}else{
				dt�w���.MaxDate = gdt�o�ד�.AddDays(14);
			}
// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� END
// MOD 2016.04.13 BEVAS�j���{ �z�B�w�������̊g�� START
			//�Z���A�l�̏ꍇ�A�z�B�w����̏����180���ɂ܂Ŋg��
			if(gs����b�c.Equals(gs�w�������g������b�c))
			{
				dt�w���.MaxDate = gdt�o�ד�.AddDays(180);
			}
// MOD 2016.04.13 BEVAS�j���{ �z�B�w�������̊g�� END
// ADD 2009.04.02 ���s�j���� �ғ����Ή� END
//			dt�w���.Checked = false;
			cBox�w���.Checked = false;
//			dt�w���.Visible   = false;
			label2.Visible = true;
// MOD 2007.02.20 ���s�j���� �w�����K���ɌŒ� START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
			cmb�w����敪.Visible = false;
			cmb�w����敪.SelectedIndex = 0;
//			lab�K��.Visible = false;
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� END
// MOD 2007.02.20 ���s�j���� �w�����K���ɌŒ� END

			// �[���ݒ�Ńv�����^���g�p�ł��Ȃ��ݒ�̏ꍇ�A����{�^���g�p�s��
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
//			if(gs�v�����^�e�f != "1")
			if(gs�v�����^�e�f != "1" || gb�����o�͂n�m)
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
			{
				btn�������.Visible = false;
			}
			else
			{
				btn�������.Visible = true;
			}

			// �C���[�W�̐ݒ�
			�A�C�R���C���[�W�̏�����();
			listView���^.LargeImageList = imageList64;
			listView���^.SmallImageList = imageList16;

			���C�u�����X�V();
			listView���^.Focus();

			// �P�ڂ̍��ڂ�I����Ԃɂ���
			if(listView���^.Items.Count > 0)
				listView���^.Items[0].Selected = true;
		}

		private void ���C�u�����X�V()
		{
			// ���C�u�����̏����ݒ�
			listView���^.Items.Clear();

			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			String[] sRet = {""};
			try
			{
				// ���C�u�����̎擾
				// �����F����b�c�A����b�c
				// �ߒl�F�X�e�[�^�X�A�����A���^�m�n�A���^���́A�t�@�C����
				tex���b�Z�[�W.Text = "�f�[�^�擾���D�D�D";
				if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
				sRet = sv_hinagata.Get_hinagata(gsa���[�U,gs����b�c, gs����b�c);
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

			tex���b�Z�[�W.Text = sRet[0];

			// ����I���ȊO�͏I��
			if(sRet[0].Length != 4) return;

			ListViewItem item;
			int iCntHinagata = int.Parse(sRet[1]);
			int iPos = 2;
			for(int iCnt = 0; iCnt < iCntHinagata; iCnt++)
			{
				item = new ListViewItem();
				item.Text = sRet[iPos++];
				item.SubItems.Add(sRet[iPos++]);
				item.ImageIndex = �A�C�R���C���[�W�̎擾(sRet[iPos++]);
				item.SubItems.Add(sRet[iPos++]);
				listView���^.Items.Add(item);
			}
			tex���b�Z�[�W.Text = "";
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btn�A�C�R���\��_Click(object sender, System.EventArgs e)
		{
			if( �A�C�R���\����� )
			{
				listView���^.View = View.Details;
				�A�C�R���\����� = false;
				btn�A�C�R���\��.Text = "�A�C�R���\��";
			}
			else
			{
				listView���^.View = View.LargeIcon;
				�A�C�R���\����� = true;
				btn�A�C�R���\��.Text = "�ꗗ�\��";
			}
		}

		private void btn���^�쐬_Click(object sender, System.EventArgs e)
		{
// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			���^�o�^ ��� = new ���^�o�^();
//			���.Left = this.Left;
//			���.Top  = this.Top;
//			���.s���^���� = "";
//			���.i���^�m�n = 0;
//			���.s�o�^�� = "";
//			���.s�W���[�i���m�n = "";
//			this.Visible = false;
//			���.ShowDialog();
//			this.Visible = true;
			if (g���^�o�^ == null)	 g���^�o�^ = new ���^�o�^();
			g���^�o�^.Left = this.Left;
			g���^�o�^.Top  = this.Top;
			g���^�o�^.s���^���� = "";
			g���^�o�^.i���^�m�n = 0;
			g���^�o�^.s�o�^�� = "";
			g���^�o�^.s�W���[�i���m�n = "";
			this.Visible = false;
			g���^�o�^.ShowDialog();
			this.Visible = true;
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END

			���C�u�����X�V();
			listView���^.Focus();
		}

		private void btn���^�ҏW_Click(object sender, System.EventArgs e)
		{
			// �I������Ă��Ȃ��ꍇ�ɂ͏I��
			if(listView���^.SelectedItems.Count == 0)
			{	
				MessageBox.Show("�f�[�^���P�����I������Ă��܂���B", "�m�F",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				listView���^.Focus();
				return;
			}
			// �����I�����ɂ͏I��
			if(listView���^.SelectedItems.Count > 1)
			{	
				MessageBox.Show("�����̃f�[�^��I��������Ԃł͎��s�ł��܂���B\r\n�P���̂ݑI�����Ď��s���Ă��������B", "�m�F",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				listView���^.Focus();
				return;
			}

			int i�I������ = listView���^.SelectedItems[0].Index;

// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			���^�o�^ ��� = new ���^�o�^();
//			���.Left = this.Left;
//			���.Top  = this.Top;
//			���.s���^���� = listView���^.SelectedItems[0].Text;
//			���.i���^�m�n = int.Parse(listView���^.SelectedItems[0].SubItems[1].Text);
//			this.Visible = false;
//			���.ShowDialog();
//			this.Visible = true;
			if (g���^�o�^ == null)	 g���^�o�^ = new ���^�o�^();
			g���^�o�^.Left = this.Left;
			g���^�o�^.Top  = this.Top;
			g���^�o�^.s���^���� = listView���^.SelectedItems[0].Text;
			g���^�o�^.i���^�m�n = int.Parse(listView���^.SelectedItems[0].SubItems[1].Text);
			this.Visible = false;
			g���^�o�^.ShowDialog();
			this.Visible = true;
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END

			���C�u�����X�V();
			listView���^.Focus();
			if(listView���^.Items.Count > 0 && i�I������ < listView���^.Items.Count)
			{
				listView���^.Items[i�I������].Selected = true;
			}
		}

		private void btn�o�דo�^_Click(object sender, System.EventArgs e)
		{
			// �I������Ă��Ȃ��ꍇ�ɂ͏I��
			if(listView���^.SelectedItems.Count == 0)
			{	
				MessageBox.Show("�f�[�^���P�����I������Ă��܂���B", "�m�F",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				listView���^.Focus();
				return;
			}
			// �����I�����ɂ͏I��
			if(listView���^.SelectedItems.Count > 1)
			{	
				MessageBox.Show("�����̃f�[�^��I��������Ԃł͎��s�ł��܂���B\r\n�P���̂ݑI�����Ď��s���Ă��������B", "�m�F",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				listView���^.Focus();
				return;
			}

			// �o�ד��`�F�b�N
			����o�ד����X�V();
			if (dt�o�ד�.Value < gdt�o�ד�)
			{
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N START
//				string s�o�ד� = gs�o�ד�.Substring(0,4) + "�N";
				string s�o�ד� = "";
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N END
				if(gs�o�ד�[4] == '0')
					s�o�ד� = s�o�ד� + " " + gs�o�ד�.Substring(5,1) + "��";
				else
					s�o�ד� = s�o�ד� + gs�o�ד�.Substring(4,2) + "��";
				if(gs�o�ד�[6] == '0')
					s�o�ד� = s�o�ד� + " " + gs�o�ד�.Substring(7,1) + "��";
				else
					s�o�ד� = s�o�ד� + gs�o�ד�.Substring(6,2) + "��";

				MessageBox.Show("�o�ד���" + s�o�ד� + "�ȍ~�œ��͂��Ă�������",
					"���̓`�F�b�N",
					MessageBoxButtons.OK );
				dt�o�ד�.Focus();
				return;
			}

// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N START
			// �z�B�w����`�F�b�N
			if (cBox�w���.Checked)
			{
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
				b�w����`�F�b�N�l�r�f�L = true;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
				bool bRet = �o�ד��`�F�b�N();
				if(bRet == false) return;
			}
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N END

			int i�I������ = listView���^.SelectedItems[0].Index;

// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			�o�דo�^ ��� = new �o�דo�^();
//			���.Left = this.Left;
//			���.Top = this.Top;
//			���.s�����e�f = "I";
//			���.dt���^�o�ד� = dt�o�ד�.Value;
			if (g�o�דo�^ == null)	 g�o�דo�^ = new �o�דo�^();
			g�o�דo�^.Left = this.Left;
			g�o�דo�^.Top = this.Top;
			g�o�דo�^.s�����e�f = "I";
			g�o�דo�^.dt���^�o�ד� = dt�o�ד�.Value;
//			if(dt�w���.Checked)
			if(cBox�w���.Checked)
			{
//				���.b���^�w���  = true;
//				���.dt���^�w��� = dt�w���.Value;
				g�o�דo�^.b���^�w���  = true;
				g�o�דo�^.dt���^�w��� = dt�w���.Value;
// DEL 2007.02.20 ���s�j���� �w�����K���ɌŒ� START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
				g�o�דo�^.i���^�w����敪 = cmb�w����敪.SelectedIndex;
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� END
// DEL 2007.02.20 ���s�j���� �w�����K���ɌŒ� END
			}
			else
			{
//				���.b���^�w���  = false;
				g�o�דo�^.b���^�w���  = false;
			}
//			���.i���^�m�n = int.Parse(listView���^.SelectedItems[0].SubItems[1].Text);
			g�o�דo�^.i���^�m�n = int.Parse(listView���^.SelectedItems[0].SubItems[1].Text);
			this.Visible = false;
//			���.ShowDialog();
			g�o�דo�^.ShowDialog();
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
			this.Visible = true;
//			���C�u�����X�V();
			listView���^.Focus();
//			if(listView���^.Items.Count > 0 && i�I������ < listView���^.Items.Count){
//				listView���^.Items[i�I������].Selected = true;
//			}
		}

		private void btn�������_Click(object sender, System.EventArgs e)
		{
			// �I������Ă��Ȃ��ꍇ�ɂ͏I��
			if(listView���^.SelectedItems.Count == 0)
			{	
				MessageBox.Show("�f�[�^���P�����I������Ă��܂���B", "�m�F",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				listView���^.Focus();
				return;
			}

			// �o�ד��`�F�b�N
			����o�ד����X�V();
			if (dt�o�ד�.Value < gdt�o�ד�)
			{
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N START
//				string s�o�ד� = gs�o�ד�.Substring(0,4) + "�N";
				string s�o�ד� = "";
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N END
				if(gs�o�ד�[4] == '0')
					s�o�ד� = s�o�ד� + " " + gs�o�ד�.Substring(5,1) + "��";
				else
					s�o�ד� = s�o�ד� + gs�o�ד�.Substring(4,2) + "��";
				if(gs�o�ד�[6] == '0')
					s�o�ד� = s�o�ד� + " " + gs�o�ד�.Substring(7,1) + "��";
				else
					s�o�ד� = s�o�ד� + gs�o�ד�.Substring(6,2) + "��";

				MessageBox.Show("�o�ד���" + s�o�ד� + "�ȍ~�œ��͂��Ă�������",
					"���̓`�F�b�N",
					MessageBoxButtons.OK );
				dt�o�ד�.Focus();
				return;
			}

			// �w����`�F�b�N
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N START
//			if (cBox�w���.Checked == true && dt�w���.Value < dt�o�ד�.Value)
//			{
//				MessageBox.Show("�w��������������͂���Ă��܂���","���̓`�F�b�N",
//					MessageBoxButtons.OK );
//				dt�w���.Focus();
//				return;
//			}
			// �z�B�w����`�F�b�N
			if (cBox�w���.Checked)
			{
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
				b�w����`�F�b�N�l�r�f�L = true;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
				bool bRet = �o�ד��`�F�b�N();
				if(bRet == false) return;
			}
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N END

			String strMsg = "�I�����ꂽ���x����������܂��B\r\n";
			foreach( ListViewItem oItem in listView���^.SelectedItems )
			{
				strMsg += "\r\n�w" + oItem.Text + "�x";
			}
			DialogResult result;
			result = MessageBox.Show(strMsg, "���x�����", 
				MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

			if(result == DialogResult.OK)
			{
				string s�G���[�m�n = "";
				int i�I�� = listView���^.SelectedItems.Count;

				for(int iCnt = 0; iCnt < i�I��; iCnt++)
				{
					i���^�m�n = int.Parse(listView���^.SelectedItems[iCnt].SubItems[1].Text);
					�o�דo�^();
					if(i����e�f == 1)
					{
// MOD 2006.12.12 ���s�j�����J �X���ƕ���X�����قȂ�ꍇ�́A������Ȃ� START
//						�������();
						if(!�������())
						{
							return;
						}
// MOD 2006.12.12 ���s�j�����J �X���ƕ���X�����قȂ�ꍇ�́A������Ȃ� START
						if(i����e�f == 0)
						{
//							tex���b�Z�[�W.Text = "��������Ɏ��s���܂���";
							�r�[�v��();
							s�G���[�m�n = i���^�m�n.ToString();
							break;
						}
					}
					else
					{
//						tex���b�Z�[�W.Text = "�o�דo�^�Ɏ��s���܂���";
						�r�[�v��();
						s�G���[�m�n = i���^�m�n.ToString();
						break;
					}
				}
				for(int iCnt = 0; iCnt < listView���^.Items.Count; iCnt++)
				{
					if(s�G���[�m�n != listView���^.Items[iCnt].SubItems[1].Text)
						listView���^.Items[iCnt].Selected = false;
				}
				if(i����e�f == 1)
					tex���b�Z�[�W.Text = "";

			}

			listView���^.Focus();
		}

		private void listView���^_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyData == Keys.Enter)
			{
				btn�������_Click(sender, e);
			}
		}

		private void listView���^_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			switch(e.Column)
			{
				case 0:
					if(listView���^.Sorting == System.Windows.Forms.SortOrder.Ascending)
					{
						listView���^.Sorting = System.Windows.Forms.SortOrder.Descending;
					}
					else
					{
						listView���^.Sorting = System.Windows.Forms.SortOrder.Ascending;
					}
					break;
				case 1:
					listView���^.Sorting = System.Windows.Forms.SortOrder.None;
					//�ۗ� ���בւ�
					break;
			}
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lab����.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

		private void btn���^�폜_Click(object sender, System.EventArgs e)
		{
			// �I������Ă��Ȃ��ꍇ�ɂ͏I��
			if(listView���^.SelectedItems.Count == 0)
			{	
				MessageBox.Show("�f�[�^���P�����I������Ă��܂���B", "�m�F",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				listView���^.Focus();
				return;
			}
			// �����I�����ɂ͏I��
			if(listView���^.SelectedItems.Count > 1)
			{	
				MessageBox.Show("�����̃f�[�^��I��������Ԃł͎��s�ł��܂���B\r\n�P���̂ݑI�����Ď��s���Ă��������B", "�m�F",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				listView���^.Focus();
				return;
			}

			DialogResult result = MessageBox.Show("�I�������f�[�^�����ׂč폜���܂����H","�폜",MessageBoxButtons.YesNo);
			if(result == DialogResult.Yes)
			{
				string[] sKey = new string[6];
				sKey[0] = gs����b�c;
				sKey[1] = gs����b�c;
				sKey[2] = listView���^.SelectedItems[0].SubItems[1].Text;
				sKey[3] = listView���^.SelectedItems[0].SubItems[2].Text;
				sKey[4] = "���^�o��";
				sKey[5] = gs���p�҂b�c;

				int i�I������ = listView���^.SelectedItems[0].Index;

				// �J�[�\���������v�ɂ���
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				string sRet = "";
				try
				{
					// ���^�̍폜
					// �����F����b�c�A����b�c�A���^�m�n�A�X�V�����A�X�V�o�f�A�X�V��
					// �ߒl�F�X�e�[�^�X
					tex���b�Z�[�W.Text = "�폜���D�D�D";
					if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
					sRet = sv_hinagata.Del_hinagata(gsa���[�U,sKey);
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

				���C�u�����X�V();
				if(tex���b�Z�[�W.Text.Trim() == "" && sRet.Length != 4)
					tex���b�Z�[�W.Text = sRet;

				if(listView���^.Items.Count > 0 && i�I������ < listView���^.Items.Count)
				{
					listView���^.Items[i�I������].Selected = true;
				}
			}
			listView���^.Focus();
		}

		private void �o�דo�^()
		{
			i����e�f = 0;

			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sList = {""};
			try
			{
				tex���b�Z�[�W.Text = "�������D�D�D";
				if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
				sList = sv_hinagata.Get_Hinagata2(gsa���[�U,gs����b�c, gs����b�c, i���^�m�n);
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				sList[0] = gs�ʐM�G���[;
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				sList[0] = "�ʐM�G���[�F" + ex.Message;
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;

			tex���b�Z�[�W.Text = sList[0];

			// ���b�Z�[�W��[����I��]
			if(sList[0].Length != 4) return;

			String[] sIUList;
// MOD 2005.06.08 ���s�j�ɉ� �w����敪�ǉ� START
// MOD 2005.05.17 ���s�j�����J �ː��ǉ� START
//			string[] s�o�ׂc = new string[38];
//			string[] s�o�ׂc = new string[39];
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
//			string[] s�o�ׂc = new string[42];
			string[] s�o�ׂc = new string[45];
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
// MOD 2005.05.17 ���s�j�����J �ː��ǉ� END
// MOD 2005.06.08 ���s�j�ɉ� �w����敪�ǉ� END
			s�o�ׂc[0]    = gs����b�c;
			s�o�ׂc[1]    = gs����b�c;
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX START
//			s�o�ׂc[2]    = dt�o�ד�.Value.ToShortDateString().Replace("/","");
			s�o�ׂc[2]    = YYYYMMDD�ϊ�(dt�o�ד�.Value);
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX END
			s�o�ׂc[3]    = " ";                    //���q�l�Ǘ��ԍ�
			s�o�ׂc[4]    = sList[3].Trim();   //�͂���R�[�h
			s�o�ׂc[5]    = sList[4].Trim();   //�͂���d�b�ԍ��P
			s�o�ׂc[6]    = sList[5].Trim();   //�͂���d�b�ԍ��Q
			s�o�ׂc[7]    = sList[6].Trim();   //�͂���d�b�ԍ��R
			s�o�ׂc[8]    = sList[7].Trim();   //�͂���Z���P
			s�o�ׂc[9]    = sList[8].Trim();   //�͂���Z���Q
			s�o�ׂc[10]   = sList[9].Trim();   //�͂���Z���R
			s�o�ׂc[11]   = sList[10].Trim();   //�͂��於�O�P
			s�o�ׂc[12]   = sList[11].Trim();   //�͂��於�O�Q
			s�o�ׂc[13]   = sList[12].Trim();   //�͂���X�֔ԍ��P
			s�o�ׂc[14]   = sList[13].Trim();   //�͂���X�֔ԍ��Q
			s�o�ׂc[15]   = sList[14].Trim();   //�˗���R�[�h
			s�o�ׂc[37]   = sList[15].Trim();    //�˗��啔��

			s�o�ׂc[19]   = sList[16].Trim();   //��
			s�o�ׂc[20]   = sList[17].Trim();   //�d��

// MOD 2005.06.08 ���s�j�ɉ� �w����敪�ǉ� START
			if(cBox�w���.Checked == true)
			{
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX START
//				s�o�ׂc[21] = dt�w���.Value.ToShortDateString().Replace("/","");
				s�o�ׂc[21] = YYYYMMDD�ϊ�(dt�w���.Value);
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX END
// MOD 2007.02.20 ���s�j���� �w�����K���ɌŒ� START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
				s�o�ׂc[41] = cmb�w����敪.SelectedIndex.ToString();
//				s�o�ׂc[41] = "0";
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� END
// MOD 2007.02.20 ���s�j���� �w�����K���ɌŒ� END
			}
			else
			{
				s�o�ׂc[21] = "0";
				s�o�ׂc[41] = "0";
			}
// MOD 2005.06.08 ���s�j�ɉ� �w����敪�ǉ� END

// ADD 2005.05.30 ���s�j�ɉ� �A�����i�R�[�h�ǉ� START
			s�o�ׂc[39] = sList[39].Trim();
			s�o�ׂc[40] = sList[40].Trim();
// ADD 2005.05.30 ���s�j�ɉ� �A�����i�R�[�h�ǉ� END

// ADD 2005.06.08 ���s�j�ɉ� �w����敪�ǉ� START
			//�W�d�w�o�A�X�d�w�o�A�P�O�d�w�o�A�����q��ւ̏ꍇ�͎w����K�{
			if((s�o�ׂc[39].Equals("200") || s�o�ׂc[39].Equals("300") || s�o�ׂc[39].Equals("400") || s�o�ׂc[39].Equals("500"))
				&& cBox�w���.Checked == false)
			{
				MessageBox.Show("�z�B�w����͕K�{���ڂł�","���̓`�F�b�N",
					MessageBoxButtons.OK );
				dt�w���.Focus();
				return;
			}
// ADD 2005.06.08 ���s�j�ɉ� �w����敪�ǉ� END

			s�o�ׂc[22]   = sList[18].Trim();   //�A�����P
			s�o�ׂc[23]   = sList[19].Trim();   //�A�����Q
			s�o�ׂc[24]   = sList[20].Trim();   //�L�����P
			s�o�ׂc[25]   = sList[21].Trim();   //�L�����Q
			s�o�ׂc[26]   = sList[22].Trim();   //�L�����R
			s�o�ׂc[27]   = "1";		//�����敪
			s�o�ׂc[28]   = sList[23].Trim();   //�ی����z
			s�o�ׂc[29] = "0";					//����󔭍s�ςe�f
			s�o�ׂc[30] = "0";					//�o�׍ςe�f
			s�o�ׂc[31] = "0";					//�ꊇ�o�ׂe�f
			s�o�ׂc[32] = "���^�o��";
			s�o�ׂc[33] = gs���p�҂b�c;
			s�o�ׂc[34] = " ";
			s�o�ׂc[35] = " ";
			s�o�ׂc[36] = " ";

// ADD 2005.05.17 ���s�j�����J �ː��ǉ� START
			s�o�ׂc[38]   = sList[37].Trim();   //�ː�
// ADD 2005.05.17 ���s�j�����J �ː��ǉ� START

			string s������b�c        = sList[34].Trim();
			string s�����敔�ۂb�c    = sList[35].Trim();

			s�o�ׂc[16] = s������b�c;
			s�o�ׂc[17] = s�����敔�ۂb�c;
			s�o�ׂc[18] = " ";

			if(gsa������b�c != null && s������b�c.Length > 0)
			{
				if(gsa������b�c != null)
				{
					for(int iCnt = 0 ; iCnt < gsa������b�c.Length; iCnt++ )
					{
						if(gsa������b�c[iCnt] == null || gsa�����敔�ۂb�c[iCnt] == null)
							continue;
						if(gsa������b�c[iCnt] == s������b�c && gsa�����敔�ۂb�c[iCnt] == s�����敔�ۂb�c)
						{
							s�o�ׂc[18] = gsa�����敔�ۖ�[iCnt];
							break;
						}
					}
				}
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
///			if(gs�I�v�V����[18].Equals("1")){
				s�o�ׂc[8]  = sList[7].TrimEnd();  // �͂���Z���P
				s�o�ׂc[9]  = sList[8].TrimEnd();  // �͂���Z���Q
				s�o�ׂc[10] = sList[9].TrimEnd();  // �͂���Z���R
				s�o�ׂc[11] = sList[10].TrimEnd(); // �͂��於�O�P
				s�o�ׂc[12] = sList[11].TrimEnd(); // �͂��於�O�Q
				s�o�ׂc[37] = sList[15].TrimEnd(); // �˗��啔��

				s�o�ׂc[22] = sList[18].TrimEnd(); // �A�����P
				s�o�ׂc[23] = sList[19].TrimEnd(); // �A�����Q
				s�o�ׂc[24] = sList[20].TrimEnd(); // �L�����P
				s�o�ׂc[25] = sList[21].TrimEnd(); // �L�����Q
				s�o�ׂc[26] = sList[22].TrimEnd(); // �L�����R
///			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
			if(sList.Length > 41){
				s�o�ׂc[42] = sList[41].TrimEnd(); // �L�����S
				s�o�ׂc[43] = sList[42].TrimEnd(); // �L�����T
				s�o�ׂc[44] = sList[43].TrimEnd(); // �L�����U
			}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END

			for(int iCnt = 0 ; iCnt < s�o�ׂc.Length; iCnt++ )
			{
				if( s�o�ׂc[iCnt] == null 
					|| s�o�ׂc[iCnt].Length == 0 ) s�o�ׂc[iCnt] = " ";
			}

			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			sIUList = new string[]{""};
			try
			{
				tex���b�Z�[�W.Text = "�o�^���D�D�D";
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� START
				if(sv_oji == null) sv_oji = new is2oji.Service1();
				if (gs����b�c.Substring(0,1) != "J")
				{
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END
					
					sIUList = sv_syukka.Ins_syukka(gsa���[�U,s�o�ׂc);

// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� START
				}
				else
				{
					sIUList = sv_oji.Ins_syukka(gsa���[�U,s�o�ׂc);
				}
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END

			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				sIUList[0] = gs�ʐM�G���[;
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				sIUList[0] = "�ʐM�G���[�F" + ex.Message;
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;

			// �ُ�I����
			if(sIUList[0] == "0")
			{
				tex���b�Z�[�W.Text = "���͂��ꂽ���˗���R�[�h�̓}�X�^�ɑ��݂��܂���";
//				MessageBox.Show("���˗���R�[�h�����݂��܂���",
//					"�o�^",MessageBoxButtons.OK);
				return;
			}

			tex���b�Z�[�W.Text = sIUList[0];
			if(sIUList[0].Length == 4)
			{
				i����e�f = 1;
				s�o�^�� = sIUList[1];
				s�W���[�i���m�n = sIUList[2];
			}
		}

		private bool �������()
		{
			i����e�f = 0;

			try
			{
				�v�����^�`�F�b�N();
			}
			catch(Exception ex)
			{
				tex���b�Z�[�W.Text = ex.Message;
				return true;
			}
			Cursor = System.Windows.Forms.Cursors.AppStarting;

// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j START
//			ds�����.Clear();
			�����f�[�^�N���A();
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j END

			try
			{
				string[] sData = new string[2];
				sData[0] = s�o�^��;
				sData[1] = s�W���[�i���m�n;

				��������w��(sData);
// ADD 2006.12.12 ���s�j�����J �X���ƕ���X�����قȂ�ꍇ�́A������Ȃ� START
				if(!gb���)
				{
					tex���b�Z�[�W.Text = "";
					Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2007.2.19 FJCS�j�K�c ���b�Z�[�W�ύX START
//					MessageBox.Show("���X���Ⴂ�܂��B����ł��܂���B","������"
					MessageBox.Show("�W�דX���Ⴂ�܂��B����ł��܂���B","������"
// MOD 2007.2.19 FJCS�j�K�c ���b�Z�[�W�ύX END
						,MessageBoxButtons.OK);
					return false;
				}
// ADD 2006.12.12 ���s�j�����J �X���ƕ���X�����قȂ�ꍇ�́A������Ȃ� END
			}
			catch (Exception ex)
			{
				tex���b�Z�[�W.Text = ex.Message;
				�r�[�v��();
				return true;
			}

			����󒠕[���();
			Cursor = System.Windows.Forms.Cursors.Default;

			i����e�f = 1;
			tex���b�Z�[�W.Text = "";
			return true;
		}

		private void listView���^_DoubleClick(object sender, System.EventArgs e)
		{
			btn�o�דo�^_Click(sender, e);
		}

		private void cBox�w���_Click(object sender, System.EventArgs e)
		{
			if(cBox�w���.Checked == true)
			{
				label2.Visible = false;
// MOD 2007.02.20 ���s�j���� �w�����K���ɌŒ� START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
				cmb�w����敪.Visible = true;
//				lab�K��.Visible = true;
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� END
// MOD 2007.02.20 ���s�j���� �w�����K���ɌŒ� END
				dt�w���.TabStop = true;
// DEL 2007.02.20 ���s�j���� �w�����K���ɌŒ� START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
				cmb�w����敪.TabStop = true;
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� END
// DEL 2007.02.20 ���s�j���� �w�����K���ɌŒ� END
			}
			else
			{
				label2.Visible = true;
// MOD 2007.02.20 ���s�j���� �w�����K���ɌŒ� START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
				cmb�w����敪.Visible = false;
//				lab�K��.Visible = false;
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
// MOD 2007.02.20 ���s�j���� �w�����K���ɌŒ� END
				dt�w���.TabStop = false;
// DEL 2007.02.20 ���s�j���� �w�����K���ɌŒ� START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
				cmb�w����敪.TabStop = false;
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
// DEL 2007.02.20 ���s�j���� �w�����K���ɌŒ� END
			}
		}

		private void dt�w���_DropDown(object sender, System.EventArgs e)
		{
			label2.Visible = false;
			cBox�w���.Checked = true;
// MOD 2007.02.20 ���s�j���� �w�����K���ɌŒ� START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
			cmb�w����敪.Visible = true;
//			lab�K��.Visible = true;
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� END
// MOD 2007.02.20 ���s�j���� �w�����K���ɌŒ� END
			dt�w���.TabStop = true;
// DEL 2007.02.20 ���s�j���� �w�����K���ɌŒ� START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
			cmb�w����敪.TabStop = true;
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� END
// DEL 2007.02.20 ���s�j���� �w�����K���ɌŒ� END
		}

		private void btn�V���[�g�J�b�g_Click(object sender, System.EventArgs e)
		{
			// �I������Ă��Ȃ��ꍇ�ɂ͏I��
			if(listView���^.SelectedItems.Count == 0)
			{	
				MessageBox.Show("�f�[�^���P�����I������Ă��܂���B", "�m�F",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				listView���^.Focus();
				return;
			}

			String strMsg = "�I�����ꂽ���x�����f�X�N�g�b�v�ɓ\��t���܂��B\r\n";
			foreach( ListViewItem oItem in listView���^.SelectedItems )
			{
				strMsg += "\r\n�w" + oItem.Text + "�x";
			}
			DialogResult result;
			result = MessageBox.Show(strMsg, "�f�X�N�g�b�v�ɓ\�t", 
				MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

			if(result == DialogResult.OK)
			{
				try
				{
					int i�I�� = listView���^.SelectedItems.Count;

					for(int iCnt = 0; iCnt < i�I��; iCnt++)
					{
						string shortcurPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop ), "�N�C�b�N�G���g���[_" + listView���^.SelectedItems[iCnt].SubItems[0].Text + ".lnk" );
						// �V���[�g�J�b�g���쐬
						ShellLink shortcut = new ShellLink();
						shortcut.Description = "�N�C�b�N�G���g���[�̃V���[�g�J�b�g";
						shortcut.TargetPath = Path.Combine(gs�A�v���t�H���_, "..\\AutoUpGrade.exe");
						shortcut.WorkingDirectory = Path.Combine(gs�A�v���t�H���_, "..\\");
						shortcut.Arguments = "hinagata_" + int.Parse(listView���^.SelectedItems[iCnt].SubItems[1].Text);
						shortcut.IconFile = Path.Combine(gs�A�v���t�H���_, "icon\\" + s�A�C�R��[listView���^.SelectedItems[iCnt].ImageIndex]);
						shortcut.Save(shortcurPath);
						shortcut.Dispose();
						shortcut = null;
					}
				}
				catch (Exception ex)
				{
					tex���b�Z�[�W.Text = ex.Message;
				}
			}
//			���C�u�����X�V();
			listView���^.Focus();
		}

// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� START
		private void ���^�o�דo�^_Closed(object sender, System.EventArgs e)
		{
			tex���b�Z�[�W.Text = "";
			listView���^.Focus();
		}
// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� END
// ADD 2009.04.02 ���s�j���� �ғ����Ή� START
		private void dt�o�ד�_ValueChanged(object sender, System.EventArgs e)
		{
			�o�ד��`�F�b�N();
		}
		private bool �o�ד��`�F�b�N()
		{
			try
			{
				//�w����͈̔͂̕ύX
				//�ŏ��l�F�o�ד��A�ő�l�F�o�ד��{�P�S�� or �X�O��
// MOD 2009.12.08 ���s�j���� �w����̏����Q�i��L�̃O���[�o���Ή��̏�Q�jSTART
//// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� START
////				dt�w����ő�l = dt�o�ד�.Value.AddDays(14);
//				if(gs����X���b�c.Equals("047")){
//					dt�w����ő�l = gdt�o�ד�.AddDays(90);
//				}else{
//					dt�w����ő�l = gdt�o�ד�.AddDays(14);
//				}
//// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� END
				if(gs����X���b�c.Equals("047")){
					dt�w����ő�l = dt�o�ד�.Value.AddDays(90);
				}else{
					dt�w����ő�l = dt�o�ד�.Value.AddDays(14);
				}
// MOD 2009.12.08 ���s�j���� �w����̏����Q�i��L�̃O���[�o���Ή��̏�Q�jEND
// MOD 2016.04.13 BEVAS�j���{ �z�B�w�������̊g�� START
				//�Z���A�l�̏ꍇ�A�z�B�w����̏����180���ɂ܂Ŋg��
				if(gs����b�c.Equals(gs�w�������g������b�c))
				{
					dt�w����ő�l = dt�o�ד�.Value.AddDays(180);
				}
// MOD 2016.04.13 BEVAS�j���{ �z�B�w�������̊g�� END
				dt�w����ŏ��l = dt�o�ד�.Value;

				//[�w���]�̃`�F�b�N�������Ă��Ȃ���
				if(cBox�w���.Checked == false){
					dt�w���.MaxDate = YYYYMMDD�ϊ�("2105/12/31");
					dt�w���.MinDate = YYYYMMDD�ϊ�("2005/01/01");
					dt�w���.Value   = dt�o�ד�.Value.AddDays(1);
					dt�w���.MaxDate = dt�w����ő�l;
					dt�w���.MinDate = dt�w����ŏ��l;
					return true;
				}

				//�ȉ���[�w���]�̃`�F�b�N�������Ă��鎞

				if(dt�w���.Value < dt�w����ŏ��l){
					dt�w���.MaxDate = dt�w����ő�l;
					dt�w���.MinDate = dt�w���.Value;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
					if(b�w����`�F�b�N�l�r�f�L){
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
						//�G���[���b�Z�[�W�\����A�t�H�[�J�X�ړ�
						MessageBox.Show("�z�B�w����͏o�ד��ȍ~����͂��Ă�������\n"
										+ "�i" 
										+ dt�w����ŏ��l.Month + "��"
										+ dt�w����ŏ��l.Day   + "�� �` "
										+ dt�w����ő�l.Month + "��"
										+ dt�w����ő�l.Day   + "���j"
										,"���̓`�F�b�N"
										,MessageBoxButtons.OK);
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
					}
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
					dt�w���.Refresh();
					dt�w���.Focus();
					return false;
				}else if(dt�w���.Value > dt�w����ő�l){
					dt�w���.MaxDate = dt�w���.Value;
					dt�w���.MinDate = dt�w����ŏ��l;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
					if(b�w����`�F�b�N�l�r�f�L){
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
						//�G���[���b�Z�[�W�\����A�t�H�[�J�X�ړ�
						MessageBox.Show("�z�B�w�����ύX���Ă�������\n"
										+ "�i" 
										+ dt�w����ŏ��l.Month + "��"
										+ dt�w����ŏ��l.Day   + "�� �` "
										+ dt�w����ő�l.Month + "��"
										+ dt�w����ő�l.Day   + "���j"
										,"���̓`�F�b�N"
										,MessageBoxButtons.OK);
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
					}
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
					dt�w���.Refresh();
					dt�w���.Focus();
					return false;
				}else{
					dt�w���.MaxDate = dt�w����ő�l;
					dt�w���.MinDate = dt�w����ŏ��l;
				}
			}
			catch (Exception)
			{
				;
				return false;
			}
			return true;
		}
// ADD 2009.04.02 ���s�j���� �ғ����Ή� END

	}
}
