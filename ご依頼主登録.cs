using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [���˗���o�^]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� 
	//--------------------------------------------------------------------------
	// MOD 2009.08.20 �p�\�j���� �X�֔ԍ��̒l���p�� 
	//--------------------------------------------------------------------------
	// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N 
	// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� 
	// MOD 2011.01.25 ���s�j���� �u���[�h�Ɏ��s�v�Ή� 
	// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� 
	// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� 
	//--------------------------------------------------------------------------
	public class ���˗���o�^ : ���ʃt�H�[��
	{
// MOD 2007.06.21 ���s�j���� ORA-00921����єr���G���[�Ή� START
//		private string sIUFlg;
//		private string sUpday;
		private string s�X�V���� = "";
// MOD 2007.06.21 ���s�j���� ORA-00921����єr���G���[�Ή� END
		private string s�˗���b�c;
// ADD 2006.08.10 ���s�j�R�{ �˗��l���u�����\���Ɏg�p����v�������\�ɂ���Ή� START
		private bool bDefFlg;
// ADD 2006.08.10 ���s�j�R�{ �˗��l���u�����\���Ɏg�p����v�������\�ɂ���Ή� END
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab����;
		private ���ʃe�L�X�g�{�b�N�X tex�J�i����;
		private ���ʃe�L�X�g�{�b�N�X tex�d�b�ԍ��P;
		private ���ʃe�L�X�g�{�b�N�X tex���O�Q;
		private ���ʃe�L�X�g�{�b�N�X tex���O�P;
		private ���ʃe�L�X�g�{�b�N�X tex�X�֔ԍ��Q;
		private ���ʃe�L�X�g�{�b�N�X tex�X�֔ԍ��P;
		private ���ʃe�L�X�g�{�b�N�X tex�d�b�ԍ��R;
		private ���ʃe�L�X�g�{�b�N�X tex�d�b�ԍ��Q;
		private ���ʃe�L�X�g�{�b�N�X tex�Z���Q;
		private ���ʃe�L�X�g�{�b�N�X tex�Z���P;
		private ���ʃe�L�X�g�{�b�N�X tex�˗���R�[�h;
		private ���ʃe�L�X�g�{�b�N�X tex���q�l��;
		private ���ʃe�L�X�g�{�b�N�X tex���p����;
		private System.Windows.Forms.Label lab�˗���o�^;
		private ���ʃe�L�X�g�{�b�N�X tex���[��;
		private System.Windows.Forms.NumericUpDown nUD�d��;
		private ���ʃe�L�X�g�{�b�N�X tex���b�Z�[�W;
		private System.Windows.Forms.Button btn�Z������;
		private System.Windows.Forms.Button btn�˗��匟��;
		private System.Windows.Forms.Button btn�˗�����s;
		private System.Windows.Forms.Button btn�ꗗ�\;
		private System.Windows.Forms.Button btn�폜;
		private System.Windows.Forms.Button btn���;
		private System.Windows.Forms.Button btn�X�V;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Label lab���[��;
		private System.Windows.Forms.Label lab�d��;
		private System.Windows.Forms.Label lab�J�i����;
		private System.Windows.Forms.Label lab���O;
		private System.Windows.Forms.Label lab�Z��;
		private System.Windows.Forms.Label lab�X�֔ԍ�;
		private System.Windows.Forms.Label lab�d�b�ԍ�;
		private System.Windows.Forms.Label lab�˗���R�[�h;
		private System.Windows.Forms.Label lab���q�l��;
		private System.Windows.Forms.Label lab���p����;
		private System.Windows.Forms.Label lab������;
		private System.Windows.Forms.ComboBox cmb������;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox cBox�f�t�H���g;
		private System.Windows.Forms.NumericUpDown nUD�ː�;
		private System.Windows.Forms.Label lab�ː�;
		private System.Windows.Forms.Label lab������R�[�h;
		private System.Windows.Forms.TextBox tex�����敔�ۃR�[�h;
		private System.Windows.Forms.TextBox tex������R�[�h;
		private System.Windows.Forms.Button btn�b�r�u�o��;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.ComponentModel.IContainer components;

		public ���˗���o�^()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(���˗���o�^));
			this.tex�J�i���� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�d�b�ԍ��P = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.label11 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmb������ = new System.Windows.Forms.ComboBox();
			this.lab���[�� = new System.Windows.Forms.Label();
			this.tex���[�� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.nUD�d�� = new System.Windows.Forms.NumericUpDown();
			this.label22 = new System.Windows.Forms.Label();
			this.lab�d�� = new System.Windows.Forms.Label();
			this.lab�J�i���� = new System.Windows.Forms.Label();
			this.lab������ = new System.Windows.Forms.Label();
			this.tex���O�Q = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab���O = new System.Windows.Forms.Label();
			this.tex���O�P = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.btn�Z������ = new System.Windows.Forms.Button();
			this.lab�Z�� = new System.Windows.Forms.Label();
			this.tex�X�֔ԍ��Q = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�X�֔ԍ��P = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.label8 = new System.Windows.Forms.Label();
			this.lab�X�֔ԍ� = new System.Windows.Forms.Label();
			this.tex�d�b�ԍ��R = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�d�b�ԍ��Q = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lab�d�b�ԍ� = new System.Windows.Forms.Label();
			this.tex�Z���Q = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�Z���P = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.btn�˗��匟�� = new System.Windows.Forms.Button();
			this.btn�˗�����s = new System.Windows.Forms.Button();
			this.lab�˗���R�[�h = new System.Windows.Forms.Label();
			this.tex�˗���R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.panel6 = new System.Windows.Forms.Panel();
			this.tex���q�l�� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab���q�l�� = new System.Windows.Forms.Label();
			this.lab���p���� = new System.Windows.Forms.Label();
			this.tex���p���� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab���� = new System.Windows.Forms.Label();
			this.lab�˗���o�^ = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn�b�r�u�o�� = new System.Windows.Forms.Button();
			this.btn�ꗗ�\ = new System.Windows.Forms.Button();
			this.btn�폜 = new System.Windows.Forms.Button();
			this.btn��� = new System.Windows.Forms.Button();
			this.btn�X�V = new System.Windows.Forms.Button();
			this.tex���b�Z�[�W = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.btn���� = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tex�����敔�ۃR�[�h = new System.Windows.Forms.TextBox();
			this.tex������R�[�h = new System.Windows.Forms.TextBox();
			this.lab������R�[�h = new System.Windows.Forms.Label();
			this.lab�ː� = new System.Windows.Forms.Label();
			this.nUD�ː� = new System.Windows.Forms.NumericUpDown();
			this.cBox�f�t�H���g = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD�d��)).BeginInit();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nUD�ː�)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tex�J�i����
			// 
			this.tex�J�i����.BackColor = System.Drawing.SystemColors.Window;
			this.tex�J�i����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�J�i����.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
			this.tex�J�i����.Location = new System.Drawing.Point(136, 168);
			this.tex�J�i����.MaxLength = 10;
			this.tex�J�i����.Name = "tex�J�i����";
			this.tex�J�i����.Size = new System.Drawing.Size(110, 23);
			this.tex�J�i����.TabIndex = 10;
			this.tex�J�i����.Text = "";
			// 
			// tex�d�b�ԍ��P
			// 
			this.tex�d�b�ԍ��P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�d�b�ԍ��P.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�d�b�ԍ��P.Location = new System.Drawing.Point(136, 16);
			this.tex�d�b�ԍ��P.MaxLength = 6;
			this.tex�d�b�ԍ��P.Name = "tex�d�b�ԍ��P";
			this.tex�d�b�ԍ��P.Size = new System.Drawing.Size(56, 23);
			this.tex�d�b�ԍ��P.TabIndex = 0;
			this.tex�d�b�ԍ��P.Text = "";
			// 
			// label11
			// 
			this.label11.ForeColor = System.Drawing.Color.Red;
			this.label11.Location = new System.Drawing.Point(28, 224);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(16, 14);
			this.label11.TabIndex = 60;
			this.label11.Text = "��";
			// 
			// label7
			// 
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(28, 122);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(16, 14);
			this.label7.TabIndex = 57;
			this.label7.Text = "��";
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(28, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 14);
			this.label3.TabIndex = 56;
			this.label3.Text = "��";
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(28, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 14);
			this.label2.TabIndex = 55;
			this.label2.Text = "��";
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(28, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(16, 14);
			this.label1.TabIndex = 54;
			this.label1.Text = "��";
			// 
			// cmb������
			// 
			this.cmb������.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb������.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cmb������.Location = new System.Drawing.Point(136, 220);
			this.cmb������.Name = "cmb������";
			this.cmb������.Size = new System.Drawing.Size(144, 20);
			this.cmb������.TabIndex = 14;
			this.cmb������.SelectedIndexChanged += new System.EventHandler(this.cmb������_SelectedIndexChanged);
			// 
			// lab���[��
			// 
			this.lab���[��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���[��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���[��.Location = new System.Drawing.Point(40, 198);
			this.lab���[��.Name = "lab���[��";
			this.lab���[��.Size = new System.Drawing.Size(72, 14);
			this.lab���[��.TabIndex = 52;
			this.lab���[��.Text = "���[���A�h���X";
			// 
			// tex���[��
			// 
			this.tex���[��.BackColor = System.Drawing.SystemColors.Window;
			this.tex���[��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���[��.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex���[��.Location = new System.Drawing.Point(136, 194);
			this.tex���[��.MaxLength = 45;
			this.tex���[��.Name = "tex���[��";
			this.tex���[��.Size = new System.Drawing.Size(330, 23);
			this.tex���[��.TabIndex = 13;
			this.tex���[��.Text = "";
			// 
			// nUD�d��
			// 
			this.nUD�d��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.nUD�d��.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.nUD�d��.Location = new System.Drawing.Point(136, 298);
			this.nUD�d��.Maximum = new System.Decimal(new int[] {
																  9999,
																  0,
																  0,
																  0});
			this.nUD�d��.Name = "nUD�d��";
			this.nUD�d��.Size = new System.Drawing.Size(58, 23);
			this.nUD�d��.TabIndex = 72;
			this.nUD�d��.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nUD�d��.ThousandsSeparator = true;
			this.nUD�d��.Visible = false;
			this.nUD�d��.Enter += new System.EventHandler(this.nUD�d��_Enter);
			// 
			// label22
			// 
			this.label22.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label22.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label22.ForeColor = System.Drawing.Color.White;
			this.label22.Location = new System.Drawing.Point(0, 6);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(22, 336);
			this.label22.TabIndex = 50;
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab�d��
			// 
			this.lab�d��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�d��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�d��.Location = new System.Drawing.Point(40, 302);
			this.lab�d��.Name = "lab�d��";
			this.lab�d��.Size = new System.Drawing.Size(74, 14);
			this.lab�d��.TabIndex = 48;
			this.lab�d��.Text = "�d��(kg)";
			this.lab�d��.Visible = false;
			// 
			// lab�J�i����
			// 
			this.lab�J�i����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�J�i����.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�J�i����.Location = new System.Drawing.Point(40, 172);
			this.lab�J�i����.Name = "lab�J�i����";
			this.lab�J�i����.Size = new System.Drawing.Size(74, 14);
			this.lab�J�i����.TabIndex = 42;
			this.lab�J�i����.Text = "�J�i����";
			// 
			// lab������
			// 
			this.lab������.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab������.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab������.Location = new System.Drawing.Point(40, 224);
			this.lab������.Name = "lab������";
			this.lab������.Size = new System.Drawing.Size(74, 14);
			this.lab������.TabIndex = 36;
			this.lab������.Text = "������";
			// 
			// tex���O�Q
			// 
			this.tex���O�Q.BackColor = System.Drawing.SystemColors.Window;
			this.tex���O�Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���O�Q.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex���O�Q.Location = new System.Drawing.Point(136, 142);
			this.tex���O�Q.MaxLength = 20;
			this.tex���O�Q.Name = "tex���O�Q";
			this.tex���O�Q.Size = new System.Drawing.Size(330, 23);
			this.tex���O�Q.TabIndex = 9;
			this.tex���O�Q.Text = "";
			// 
			// lab���O
			// 
			this.lab���O.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���O.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���O.Location = new System.Drawing.Point(40, 122);
			this.lab���O.Name = "lab���O";
			this.lab���O.Size = new System.Drawing.Size(74, 14);
			this.lab���O.TabIndex = 24;
			this.lab���O.Text = "���O";
			// 
			// tex���O�P
			// 
			this.tex���O�P.BackColor = System.Drawing.SystemColors.Window;
			this.tex���O�P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���O�P.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex���O�P.Location = new System.Drawing.Point(136, 118);
			this.tex���O�P.MaxLength = 20;
			this.tex���O�P.Name = "tex���O�P";
			this.tex���O�P.Size = new System.Drawing.Size(330, 23);
			this.tex���O�P.TabIndex = 8;
			this.tex���O�P.Text = "";
			// 
			// btn�Z������
			// 
			this.btn�Z������.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�Z������.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�Z������.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�Z������.ForeColor = System.Drawing.Color.White;
			this.btn�Z������.Location = new System.Drawing.Point(222, 42);
			this.btn�Z������.Name = "btn�Z������";
			this.btn�Z������.Size = new System.Drawing.Size(48, 22);
			this.btn�Z������.TabIndex = 5;
			this.btn�Z������.TabStop = false;
			this.btn�Z������.Text = "����";
			this.btn�Z������.Click += new System.EventHandler(this.btn�Z������_Click);
			// 
			// lab�Z��
			// 
			this.lab�Z��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�Z��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�Z��.Location = new System.Drawing.Point(40, 72);
			this.lab�Z��.Name = "lab�Z��";
			this.lab�Z��.Size = new System.Drawing.Size(74, 14);
			this.lab�Z��.TabIndex = 19;
			this.lab�Z��.Text = "�Z��";
			// 
			// tex�X�֔ԍ��Q
			// 
			this.tex�X�֔ԍ��Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�X�֔ԍ��Q.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�X�֔ԍ��Q.Location = new System.Drawing.Point(180, 42);
			this.tex�X�֔ԍ��Q.MaxLength = 4;
			this.tex�X�֔ԍ��Q.Name = "tex�X�֔ԍ��Q";
			this.tex�X�֔ԍ��Q.Size = new System.Drawing.Size(40, 23);
			this.tex�X�֔ԍ��Q.TabIndex = 4;
			this.tex�X�֔ԍ��Q.Text = "";
			this.tex�X�֔ԍ��Q.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�X�֔ԍ��Q_KeyDown);
			this.tex�X�֔ԍ��Q.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�X�֔ԍ��Q_KeyPress);
			// 
			// tex�X�֔ԍ��P
			// 
			this.tex�X�֔ԍ��P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�X�֔ԍ��P.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�X�֔ԍ��P.Location = new System.Drawing.Point(136, 42);
			this.tex�X�֔ԍ��P.MaxLength = 3;
			this.tex�X�֔ԍ��P.Name = "tex�X�֔ԍ��P";
			this.tex�X�֔ԍ��P.Size = new System.Drawing.Size(32, 23);
			this.tex�X�֔ԍ��P.TabIndex = 3;
			this.tex�X�֔ԍ��P.Text = "";
			this.tex�X�֔ԍ��P.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�X�֔ԍ��P_KeyPress);
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label8.ForeColor = System.Drawing.Color.LimeGreen;
			this.label8.Location = new System.Drawing.Point(168, 46);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(12, 14);
			this.label8.TabIndex = 17;
			this.label8.Text = "�|";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab�X�֔ԍ�
			// 
			this.lab�X�֔ԍ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�X�֔ԍ�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�X�֔ԍ�.Location = new System.Drawing.Point(40, 46);
			this.lab�X�֔ԍ�.Name = "lab�X�֔ԍ�";
			this.lab�X�֔ԍ�.Size = new System.Drawing.Size(74, 14);
			this.lab�X�֔ԍ�.TabIndex = 15;
			this.lab�X�֔ԍ�.Text = "�X�֔ԍ�";
			// 
			// tex�d�b�ԍ��R
			// 
			this.tex�d�b�ԍ��R.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�d�b�ԍ��R.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�d�b�ԍ��R.Location = new System.Drawing.Point(260, 16);
			this.tex�d�b�ԍ��R.MaxLength = 4;
			this.tex�d�b�ԍ��R.Name = "tex�d�b�ԍ��R";
			this.tex�d�b�ԍ��R.Size = new System.Drawing.Size(40, 23);
			this.tex�d�b�ԍ��R.TabIndex = 2;
			this.tex�d�b�ԍ��R.Text = "";
			// 
			// tex�d�b�ԍ��Q
			// 
			this.tex�d�b�ԍ��Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�d�b�ԍ��Q.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�d�b�ԍ��Q.Location = new System.Drawing.Point(208, 16);
			this.tex�d�b�ԍ��Q.MaxLength = 4;
			this.tex�d�b�ԍ��Q.Name = "tex�d�b�ԍ��Q";
			this.tex�d�b�ԍ��Q.Size = new System.Drawing.Size(40, 23);
			this.tex�d�b�ԍ��Q.TabIndex = 1;
			this.tex�d�b�ԍ��Q.Text = "";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label6.ForeColor = System.Drawing.Color.LimeGreen;
			this.label6.Location = new System.Drawing.Point(246, 22);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(12, 14);
			this.label6.TabIndex = 13;
			this.label6.Text = "�|";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label5.ForeColor = System.Drawing.Color.LimeGreen;
			this.label5.Location = new System.Drawing.Point(192, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(12, 14);
			this.label5.TabIndex = 11;
			this.label5.Text = "�j";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label4.ForeColor = System.Drawing.Color.LimeGreen;
			this.label4.Location = new System.Drawing.Point(126, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 14);
			this.label4.TabIndex = 10;
			this.label4.Text = "�i";
			// 
			// lab�d�b�ԍ�
			// 
			this.lab�d�b�ԍ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�d�b�ԍ�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�d�b�ԍ�.Location = new System.Drawing.Point(40, 22);
			this.lab�d�b�ԍ�.Name = "lab�d�b�ԍ�";
			this.lab�d�b�ԍ�.Size = new System.Drawing.Size(64, 14);
			this.lab�d�b�ԍ�.TabIndex = 9;
			this.lab�d�b�ԍ�.Text = "�d�b�ԍ�";
			// 
			// tex�Z���Q
			// 
			this.tex�Z���Q.BackColor = System.Drawing.SystemColors.Window;
			this.tex�Z���Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�Z���Q.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�Z���Q.Location = new System.Drawing.Point(136, 92);
			this.tex�Z���Q.MaxLength = 20;
			this.tex�Z���Q.Name = "tex�Z���Q";
			this.tex�Z���Q.Size = new System.Drawing.Size(330, 23);
			this.tex�Z���Q.TabIndex = 7;
			this.tex�Z���Q.Text = "";
			// 
			// tex�Z���P
			// 
			this.tex�Z���P.BackColor = System.Drawing.SystemColors.Window;
			this.tex�Z���P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�Z���P.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�Z���P.Location = new System.Drawing.Point(136, 68);
			this.tex�Z���P.MaxLength = 20;
			this.tex�Z���P.Name = "tex�Z���P";
			this.tex�Z���P.Size = new System.Drawing.Size(330, 23);
			this.tex�Z���P.TabIndex = 6;
			this.tex�Z���P.Text = "";
			// 
			// btn�˗��匟��
			// 
			this.btn�˗��匟��.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�˗��匟��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�˗��匟��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�˗��匟��.ForeColor = System.Drawing.Color.White;
			this.btn�˗��匟��.Location = new System.Drawing.Point(272, 12);
			this.btn�˗��匟��.Name = "btn�˗��匟��";
			this.btn�˗��匟��.Size = new System.Drawing.Size(48, 22);
			this.btn�˗��匟��.TabIndex = 1;
			this.btn�˗��匟��.TabStop = false;
			this.btn�˗��匟��.Text = "����";
			this.btn�˗��匟��.Click += new System.EventHandler(this.btn�˗��匟��_Click);
			// 
			// btn�˗�����s
			// 
			this.btn�˗�����s.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�˗�����s.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�˗�����s.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�˗�����s.ForeColor = System.Drawing.Color.White;
			this.btn�˗�����s.Location = new System.Drawing.Point(324, 12);
			this.btn�˗�����s.Name = "btn�˗�����s";
			this.btn�˗�����s.Size = new System.Drawing.Size(48, 22);
			this.btn�˗�����s.TabIndex = 2;
			this.btn�˗�����s.TabStop = false;
			this.btn�˗�����s.Text = "���s";
			this.btn�˗�����s.Click += new System.EventHandler(this.btn�˗�����s_Click);
			// 
			// lab�˗���R�[�h
			// 
			this.lab�˗���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�˗���R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�˗���R�[�h.Location = new System.Drawing.Point(6, 16);
			this.lab�˗���R�[�h.Name = "lab�˗���R�[�h";
			this.lab�˗���R�[�h.Size = new System.Drawing.Size(106, 17);
			this.lab�˗���R�[�h.TabIndex = 6;
			this.lab�˗���R�[�h.Text = "���˗���R�[�h";
			// 
			// tex�˗���R�[�h
			// 
			this.tex�˗���R�[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex�˗���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗���R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�˗���R�[�h.Location = new System.Drawing.Point(114, 12);
			this.tex�˗���R�[�h.MaxLength = 12;
			this.tex�˗���R�[�h.Name = "tex�˗���R�[�h";
			this.tex�˗���R�[�h.Size = new System.Drawing.Size(154, 23);
			this.tex�˗���R�[�h.TabIndex = 0;
			this.tex�˗���R�[�h.Text = "";
			this.tex�˗���R�[�h.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�˗���R�[�h_KeyDown);
			this.tex�˗���R�[�h.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�˗���R�[�h_KeyPress);
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
			this.panel7.Controls.Add(this.lab�˗���o�^);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(792, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab����
			// 
			this.lab����.ForeColor = System.Drawing.Color.White;
			this.lab����.Location = new System.Drawing.Point(674, 8);
			this.lab����.Name = "lab����";
			this.lab����.Size = new System.Drawing.Size(112, 14);
			this.lab����.TabIndex = 1;
			this.lab����.Text = "2005/xx/xx 12:00:00";
			// 
			// lab�˗���o�^
			// 
			this.lab�˗���o�^.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�˗���o�^.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�˗���o�^.ForeColor = System.Drawing.Color.White;
			this.lab�˗���o�^.Location = new System.Drawing.Point(12, 2);
			this.lab�˗���o�^.Name = "lab�˗���o�^";
			this.lab�˗���o�^.Size = new System.Drawing.Size(264, 24);
			this.lab�˗���o�^.TabIndex = 0;
			this.lab�˗���o�^.Text = "���˗���o�^";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn�b�r�u�o��);
			this.panel8.Controls.Add(this.btn�ꗗ�\);
			this.panel8.Controls.Add(this.btn�폜);
			this.panel8.Controls.Add(this.btn���);
			this.panel8.Controls.Add(this.btn�X�V);
			this.panel8.Controls.Add(this.tex���b�Z�[�W);
			this.panel8.Controls.Add(this.btn����);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 17;
			// 
			// btn�b�r�u�o��
			// 
			this.btn�b�r�u�o��.ForeColor = System.Drawing.Color.Blue;
			this.btn�b�r�u�o��.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�b�r�u�o��.Location = new System.Drawing.Point(378, 6);
			this.btn�b�r�u�o��.Name = "btn�b�r�u�o��";
			this.btn�b�r�u�o��.Size = new System.Drawing.Size(62, 48);
			this.btn�b�r�u�o��.TabIndex = 5;
			this.btn�b�r�u�o��.Text = "�b�r�u\n �o��";
			this.btn�b�r�u�o��.Click += new System.EventHandler(this.btn�b�r�u�o��_Click);
			// 
			// btn�ꗗ�\
			// 
			this.btn�ꗗ�\.ForeColor = System.Drawing.Color.Blue;
			this.btn�ꗗ�\.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�ꗗ�\.Location = new System.Drawing.Point(308, 6);
			this.btn�ꗗ�\.Name = "btn�ꗗ�\";
			this.btn�ꗗ�\.Size = new System.Drawing.Size(62, 48);
			this.btn�ꗗ�\.TabIndex = 4;
			this.btn�ꗗ�\.Text = "�ꗗ�\�@���";
			this.btn�ꗗ�\.Click += new System.EventHandler(this.btn�ꗗ�\_Click);
			// 
			// btn�폜
			// 
			this.btn�폜.ForeColor = System.Drawing.Color.Blue;
			this.btn�폜.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�폜.Location = new System.Drawing.Point(238, 6);
			this.btn�폜.Name = "btn�폜";
			this.btn�폜.Size = new System.Drawing.Size(62, 48);
			this.btn�폜.TabIndex = 3;
			this.btn�폜.Text = "�폜";
			this.btn�폜.Click += new System.EventHandler(this.btn�폜_Click);
			// 
			// btn���
			// 
			this.btn���.ForeColor = System.Drawing.Color.Blue;
			this.btn���.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn���.Location = new System.Drawing.Point(168, 6);
			this.btn���.Name = "btn���";
			this.btn���.Size = new System.Drawing.Size(62, 48);
			this.btn���.TabIndex = 2;
			this.btn���.Text = "���";
			this.btn���.Click += new System.EventHandler(this.btn���_Click);
			// 
			// btn�X�V
			// 
			this.btn�X�V.ForeColor = System.Drawing.Color.Blue;
			this.btn�X�V.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�X�V.Location = new System.Drawing.Point(98, 6);
			this.btn�X�V.Name = "btn�X�V";
			this.btn�X�V.Size = new System.Drawing.Size(62, 48);
			this.btn�X�V.TabIndex = 1;
			this.btn�X�V.Text = "�ۑ�";
			this.btn�X�V.Click += new System.EventHandler(this.btn�X�V_Click);
			// 
			// tex���b�Z�[�W
			// 
			this.tex���b�Z�[�W.BackColor = System.Drawing.Color.PaleGreen;
			this.tex���b�Z�[�W.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���b�Z�[�W.ForeColor = System.Drawing.Color.Red;
			this.tex���b�Z�[�W.Location = new System.Drawing.Point(446, 4);
			this.tex���b�Z�[�W.Multiline = true;
			this.tex���b�Z�[�W.Name = "tex���b�Z�[�W";
			this.tex���b�Z�[�W.ReadOnly = true;
			this.tex���b�Z�[�W.Size = new System.Drawing.Size(344, 50);
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
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tex�����敔�ۃR�[�h);
			this.groupBox1.Controls.Add(this.tex������R�[�h);
			this.groupBox1.Controls.Add(this.lab������R�[�h);
			this.groupBox1.Controls.Add(this.lab�ː�);
			this.groupBox1.Controls.Add(this.nUD�ː�);
			this.groupBox1.Controls.Add(this.cBox�f�t�H���g);
			this.groupBox1.Controls.Add(this.lab�d�b�ԍ�);
			this.groupBox1.Controls.Add(this.tex�X�֔ԍ��P);
			this.groupBox1.Controls.Add(this.tex�d�b�ԍ��P);
			this.groupBox1.Controls.Add(this.tex�Z���P);
			this.groupBox1.Controls.Add(this.lab�d��);
			this.groupBox1.Controls.Add(this.lab�J�i����);
			this.groupBox1.Controls.Add(this.lab������);
			this.groupBox1.Controls.Add(this.tex���O�Q);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.lab���O);
			this.groupBox1.Controls.Add(this.tex�d�b�ԍ��R);
			this.groupBox1.Controls.Add(this.tex���O�P);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.lab�Z��);
			this.groupBox1.Controls.Add(this.lab�X�֔ԍ�);
			this.groupBox1.Controls.Add(this.tex�X�֔ԍ��Q);
			this.groupBox1.Controls.Add(this.tex�J�i����);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cmb������);
			this.groupBox1.Controls.Add(this.lab���[��);
			this.groupBox1.Controls.Add(this.tex�d�b�ԍ��Q);
			this.groupBox1.Controls.Add(this.tex���[��);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.btn�Z������);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.nUD�d��);
			this.groupBox1.Controls.Add(this.tex�Z���Q);
			this.groupBox1.Controls.Add(this.label22);
			this.groupBox1.Location = new System.Drawing.Point(22, 96);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(478, 340);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			// 
			// tex�����敔�ۃR�[�h
			// 
			this.tex�����敔�ۃR�[�h.BackColor = System.Drawing.Color.Honeydew;
			this.tex�����敔�ۃR�[�h.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�����敔�ۃR�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�����敔�ۃR�[�h.Location = new System.Drawing.Point(416, 222);
			this.tex�����敔�ۃR�[�h.Name = "tex�����敔�ۃR�[�h";
			this.tex�����敔�ۃR�[�h.ReadOnly = true;
			this.tex�����敔�ۃR�[�h.Size = new System.Drawing.Size(52, 16);
			this.tex�����敔�ۃR�[�h.TabIndex = 66;
			this.tex�����敔�ۃR�[�h.TabStop = false;
			this.tex�����敔�ۃR�[�h.Text = "";
			// 
			// tex������R�[�h
			// 
			this.tex������R�[�h.BackColor = System.Drawing.Color.Honeydew;
			this.tex������R�[�h.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex������R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex������R�[�h.Location = new System.Drawing.Point(318, 222);
			this.tex������R�[�h.Name = "tex������R�[�h";
			this.tex������R�[�h.ReadOnly = true;
			this.tex������R�[�h.Size = new System.Drawing.Size(96, 16);
			this.tex������R�[�h.TabIndex = 65;
			this.tex������R�[�h.TabStop = false;
			this.tex������R�[�h.Text = "";
			// 
			// lab������R�[�h
			// 
			this.lab������R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab������R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab������R�[�h.Location = new System.Drawing.Point(284, 224);
			this.lab������R�[�h.Name = "lab������R�[�h";
			this.lab������R�[�h.Size = new System.Drawing.Size(32, 14);
			this.lab������R�[�h.TabIndex = 64;
			this.lab������R�[�h.Text = "�R�[�h";
			// 
			// lab�ː�
			// 
			this.lab�ː�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�ː�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�ː�.Location = new System.Drawing.Point(40, 276);
			this.lab�ː�.Name = "lab�ː�";
			this.lab�ː�.Size = new System.Drawing.Size(74, 14);
			this.lab�ː�.TabIndex = 63;
			this.lab�ː�.Text = "�ː�";
			this.lab�ː�.Visible = false;
			// 
			// nUD�ː�
			// 
			this.nUD�ː�.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.nUD�ː�.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.nUD�ː�.Location = new System.Drawing.Point(136, 272);
			this.nUD�ː�.Maximum = new System.Decimal(new int[] {
																  999,
																  0,
																  0,
																  0});
			this.nUD�ː�.Name = "nUD�ː�";
			this.nUD�ː�.Size = new System.Drawing.Size(58, 23);
			this.nUD�ː�.TabIndex = 71;
			this.nUD�ː�.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nUD�ː�.ThousandsSeparator = true;
			this.nUD�ː�.Visible = false;
			// 
			// cBox�f�t�H���g
			// 
			this.cBox�f�t�H���g.ForeColor = System.Drawing.Color.LimeGreen;
			this.cBox�f�t�H���g.Location = new System.Drawing.Point(136, 246);
			this.cBox�f�t�H���g.Name = "cBox�f�t�H���g";
			this.cBox�f�t�H���g.Size = new System.Drawing.Size(140, 16);
			this.cBox�f�t�H���g.TabIndex = 61;
			this.cBox�f�t�H���g.Text = "�����\���Ɏg�p����";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btn�˗��匟��);
			this.groupBox2.Controls.Add(this.btn�˗�����s);
			this.groupBox2.Controls.Add(this.lab�˗���R�[�h);
			this.groupBox2.Controls.Add(this.tex�˗���R�[�h);
			this.groupBox2.Location = new System.Drawing.Point(44, 56);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(456, 42);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			// 
			// ���˗���o�^
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 574);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "���˗���o�^";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 ���˗���o�^";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
			this.Load += new System.EventHandler(this.���˗���o�^_Load);
			this.Closed += new System.EventHandler(this.���˗���o�^_Closed);
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD�d��)).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nUD�ː�)).EndInit();
			this.groupBox2.ResumeLayout(false);
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

		private void btn�Z������_Click(object sender, System.EventArgs e)
		{
			// �󔒏���
			tex�X�֔ԍ��P.Text = tex�X�֔ԍ��P.Text.Trim();
			tex�X�֔ԍ��Q.Text = tex�X�֔ԍ��Q.Text.Trim();

			// ���̓`�F�b�N
			if(!���p�`�F�b�N(tex�X�֔ԍ��P,"�X�֔ԍ��P")) return;
			if(!���p�`�F�b�N(tex�X�֔ԍ��Q,"�X�֔ԍ��Q")) return;

// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			�Z������ ��� = new �Z������();
//			���.Left = this.Left + 404;
//			���.Top = this.Top;
//			//��ʏ����l�̐ݒ�
//			���.s�X�֔ԍ��P = tex�X�֔ԍ��P.Text;
//			���.s�X�֔ԍ��Q = tex�X�֔ԍ��Q.Text;
//			���.ShowDialog();
//			//�߂�l�̐ݒ�
//			if(���.s�Z���b�c.Length > 0)
			if (g�Z������ == null)	 g�Z������ = new �Z������();
			g�Z������.Left = this.Left + 404;
			g�Z������.Top = this.Top;
			//��ʏ����l�̐ݒ�
// MOD 2009.08.20 �p�\�j����@�X�֔ԍ��̒l���p��  START
// MOD 2005.06.02 ���s�j�����J �l�̈��p���Ȃ� START
			g�Z������.s�X�֔ԍ��P = tex�X�֔ԍ��P.Text;
			g�Z������.s�X�֔ԍ��Q = tex�X�֔ԍ��Q.Text;
//			g�Z������.s�X�֔ԍ��P = "";
//			g�Z������.s�X�֔ԍ��Q = "";
// MOD 2005.06.02 ���s�j�����J �l�̈��p���Ȃ� END
// MOD 2009.08.20 �p�\�j����@�X�֔ԍ��̒l���p��  END
			g�Z������.s�Z��       = tex�Z���P.Text;
			g�Z������.ShowDialog();
			//�߂�l�̐ݒ�
			if(g�Z������.s�Z���b�c.Length > 0)
			{
//				tex�X�֔ԍ��P.Text = ���.s�X�֔ԍ��P;
//				tex�X�֔ԍ��Q.Text = ���.s�X�֔ԍ��Q;
//				if(���.s�Z��.Length > 40)
				tex�X�֔ԍ��P.Text = g�Z������.s�X�֔ԍ��P;
				tex�X�֔ԍ��Q.Text = g�Z������.s�X�֔ԍ��Q;
				if(g�Z������.s�Z��.Length > 40)
				{
//					tex�Z���P.Text     = ���.s�Z��.Substring(0,20);
//					tex�Z���Q.Text     = ���.s�Z��.Substring(20,20);
					tex�Z���P.Text     = g�Z������.s�Z��.Substring(0,20);
					tex�Z���Q.Text     = g�Z������.s�Z��.Substring(20,20);
				}
//				else if(���.s�Z��.Length > 20)
				else if(g�Z������.s�Z��.Length > 20)
				{
//					tex�Z���P.Text     = ���.s�Z��.Substring(0,20);
//					tex�Z���Q.Text     = ���.s�Z��.Substring(20);
					tex�Z���P.Text     = g�Z������.s�Z��.Substring(0,20);
					tex�Z���Q.Text     = g�Z������.s�Z��.Substring(20);
				}
				else
				{
//					tex�Z���P.Text     = ���.s�Z��;
					tex�Z���P.Text     = g�Z������.s�Z��;
					tex�Z���Q.Text     = "";
				}
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
				//�t�H�[�J�X�ݒ�
				tex�Z���Q.Focus();
			}
			else
			{
				tex�X�֔ԍ��P.Focus();
			}
		}

		private void btn�˗��匟��_Click(object sender, System.EventArgs e)
		{
			tex�˗���R�[�h.Text = tex�˗���R�[�h.Text.Trim();
			if(!���p�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;

// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
			// ������ʂ��E���ɕ\������
//			���˗��匟�� ��� = new ���˗��匟��();
//			���.Left = this.Left + 404;
//			���.Top = this.Top;
//			���.Visible����();
			// �R�[�h�̏����\��
//			���.sIcode = tex�˗���R�[�h.Text;
//			���.ShowDialog();
			if (g�˗����� == null)	 g�˗����� = new ���˗��匟��();
			g�˗�����.Left = this.Left;
			g�˗�����.Top = this.Top;
			g�˗�����.Visible����();
// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� START
			g�˗�����.VisibleCSV�o��();
			g�˗�����.Visible�ꗗ���();
			g�˗�����.Visible�폜();
// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� END
			// �R�[�h�̏����\��
// MOD 2005.06.02 ���s�j�����J �l�̈��p���Ȃ� START
//			g�˗�����.sIcode = tex�˗���R�[�h.Text;
			g�˗�����.sIcode = "";
// MOD 2005.06.02 ���s�j�����J �l�̈��p���Ȃ� END
			g�˗�����.ShowDialog(this);
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END

			s�˗���b�c = g�˗�����.sIcode;
			if(s�˗���b�c.Length > 0)
			{
				if(g�˗�����.s���� == "T")
				{
					btn�˗�����s_Click();
					tex�˗���R�[�h.Text = " ";
					tex�˗���R�[�h.Focus();
				}
				else
				{
					tex�˗���R�[�h.Text = s�˗���b�c;
					btn�˗�����s_Click();
					tex�d�b�ԍ��P.Focus();
				}
			}
			else
			{
				tex�˗���R�[�h.Focus();
			}
		}

		private void ���˗���o�^_Load(object sender, System.EventArgs e)
		{
			// �w�b�_�[���ڂ̐ݒ�
			tex���q�l��.Text = gs���p�Җ�;
			tex���p����.Text = gs����b�c + " " + gs���喼;

			// �����̏����ݒ�
			lab����.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled = true;

			cmb������.Items.Clear();
			if(gsa�����敔�ۖ� != null)
			{
				cmb������.Items.AddRange(gsa�����敔�ۖ�);
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N START
				cmb������.Items.Add("");
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N END
				cmb������.SelectedIndex = 0;
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� START
				tex������R�[�h.Text     = "";
				tex�����敔�ۃR�[�h.Text = "";
				if(gsa������b�c.Length > 0){
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N START
					if(cmb������.SelectedIndex < gsa������b�c.Length){
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N END
						tex������R�[�h.Text     = gsa������b�c[cmb������.SelectedIndex];
						tex�����敔�ۃR�[�h.Text = gsa�����敔�ۂb�c[cmb������.SelectedIndex];
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N START
					}
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N END
				}
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� END
			}

// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
			Font fGothic = new System.Drawing.Font("MS Gothic"
							, 12F
							, System.Drawing.FontStyle.Regular
							, System.Drawing.GraphicsUnit.Point
							, ((System.Byte)(128))
							);
			tex�Z���P.Font = fGothic;
			tex�Z���Q.Font = fGothic;
			tex���O�P.Font = fGothic;
			tex���O�Q.Font = fGothic;
			tex�J�i����.Font = fGothic;
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
			if(gs�d�ʓ��͐��� == "1"){
				lab�ː�.Visible = true;
				nUD�ː�.Visible = true;
				lab�d��.Visible = true;
				nUD�d��.Visible = true;
			}else{
				lab�ː�.Visible = false;
				nUD�ː�.Visible = false;
				lab�d��.Visible = false;
				nUD�d��.Visible = false;
			}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lab����.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

		private void btn���_Click(object sender, System.EventArgs e)
		{
//			tex�˗���R�[�h.Text = "";
			tex�J�i����.Text     = "";
			tex�d�b�ԍ��P.Text   = "";
			tex�d�b�ԍ��Q.Text   = "";
			tex�d�b�ԍ��R.Text   = "";
			tex�X�֔ԍ��P.Text   = "";
			tex�X�֔ԍ��Q.Text   = "";
			tex�Z���P.Text       = "";
			tex�Z���Q.Text       = "";
			tex���O�P.Text       = "";
			tex���O�Q.Text       = "";
			nUD�ː�.Value        = 0;
			nUD�d��.Value        = 0;
			nUD�ː�.Text        = "0";
			nUD�d��.Text        = "0";
			tex���[��.Text       = "";
			cmb������.SelectedIndex = 0;
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� START
			tex������R�[�h.Text     = "";
			tex�����敔�ۃR�[�h.Text = "";
			if(gsa������b�c.Length > 0){
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N START
				if(cmb������.SelectedIndex < gsa������b�c.Length){
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N END
					tex������R�[�h.Text     = gsa������b�c[cmb������.SelectedIndex];
					tex�����敔�ۃR�[�h.Text = gsa�����敔�ۂb�c[cmb������.SelectedIndex];
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N START
				}
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N END
			}
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� END
			cBox�f�t�H���g.Checked = false;
			tex���b�Z�[�W.Text   = "";
// ADD 2007.06.21 ���s�j���� ORA-00921����єr���G���[�Ή� START
			s�X�V����            = "";
// ADD 2007.06.21 ���s�j���� ORA-00921����єr���G���[�Ή� END

		}

		private void btn�˗�����s_Click()
		{
			tex���b�Z�[�W.Text = "�������D�D�D";

			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			String[] sList = {""};
			try
			{
				if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
				sList = sv_goirai.Get_Sirainusi(gsa���[�U,gs����b�c,gs����b�c,s�˗���b�c);
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

// ADD 2006.08.10 ���s�j�R�{ �˗��l���u�����\���Ɏg�p����v�������\�ɂ���Ή� START
			if(sList[2] != null)
			{
				String[] sList1 = {""};
				try
				{
					sList1 = sv_goirai.Get_riyo(gsa���[�U,gs����b�c,gs���p�҂b�c);
				}
				catch (System.Net.WebException)
				{
					sList[0] = gs�ʐM�G���[;
				}
				catch (Exception ex)
				{
					sList[0] = "�ʐM�G���[�F" + ex.Message;
				}
			
				if(sList1[0] == s�˗���b�c)
				{
					cBox�f�t�H���g.Checked = true;
					bDefFlg = true;
				}
				else
				{
					cBox�f�t�H���g.Checked = false;
					bDefFlg = false;
				}
			}
// ADD 2006.08.10 ���s�j�R�{ �˗��l���u�����\���Ɏg�p����v�������\�ɂ���Ή� END


			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;

			if(sList[2] != null)
			{
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//				tex�J�i����.Text   = sList[1];
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
				tex�d�b�ԍ��P.Text = sList[2];
				tex�d�b�ԍ��Q.Text = sList[3];
				tex�d�b�ԍ��R.Text = sList[4];
				tex�X�֔ԍ��P.Text = sList[5];
				tex�X�֔ԍ��Q.Text = sList[6];
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//				tex�Z���P.Text     = sList[7];
//				tex�Z���Q.Text     = sList[8];
//				tex���O�P.Text     = sList[9];
//				tex���O�Q.Text     = sList[10];
				if(gs�I�v�V����[18].Equals("1")){
					tex�Z���P.Text     = sList[7].TrimEnd();
					tex�Z���Q.Text     = sList[8].TrimEnd();
					tex���O�P.Text     = sList[9].TrimEnd();
					tex���O�Q.Text     = sList[10].TrimEnd();
					tex�J�i����.Text   = sList[1].TrimEnd();
				}else{
					tex�Z���P.Text     = sList[7].Trim();
					tex�Z���Q.Text     = sList[8].Trim();
					tex���O�P.Text     = sList[9].Trim();
					tex���O�Q.Text     = sList[10].Trim();
					tex�J�i����.Text   = sList[1].Trim();
				}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
				if(gs�d�ʓ��͐��� == "1"){
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
// MOD 2005.05.17 ���s�j�����J �ː����� START
					nUD�ː�.Value      = decimal.Parse(sList[11]);
					nUD�ː�.Text       = sList[11];
// MOD 2005.05.17 ���s�j�����J �ː����� END
					nUD�d��.Value      = decimal.Parse(sList[12]);
					nUD�d��.Text       = sList[12];
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
				}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
				tex���[��.Text     = sList[13];
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� START
				tex������R�[�h.Text = sList[14];
				tex�����敔�ۃR�[�h.Text = sList[15];
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� END

// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N START
				cmb������.Text = "";
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N END
				int iCnt;
				if(gsa������b�c != null)
				{
					for(iCnt = 0 ; iCnt < gsa������b�c.Length; iCnt++ )
					{
						if(gsa������b�c[iCnt] == null || gsa�����敔�ۂb�c[iCnt] == null)
							cmb������.SelectedIndex = 0;
						else
						{
							if(gsa������b�c[iCnt] == sList[14] && gsa�����敔�ۂb�c[iCnt] == sList[15])
							{
								cmb������.SelectedIndex = iCnt;
								break;
							}
						}
					}
				}
			}

			tex���b�Z�[�W.Text = sList[0];
// MOD 2007.06.21 ���s�j���� ORA-00921����єr���G���[�Ή� START
//			sUpday             = sList[16];
//			sIUFlg             = sList[17];
			s�X�V����          = sList[16];
// MOD 2007.06.21 ���s�j���� ORA-00921����єr���G���[�Ή� END

			// ���b�Z�[�W��[�o�^]�A[�X�V]�̎��A����I��
			if(sList[0].Length == 2)
			{
				tex���b�Z�[�W.Text = "";
				tex�d�b�ԍ��P.Focus();
			}
			else
			{
				// �ُ�I����
				�r�[�v��();
				tex�˗���R�[�h.Focus();
			}
		}

		private void btn�폜_Click(object sender, System.EventArgs e)
		{
			// �󔒏���
			tex�˗���R�[�h.Text = tex�˗���R�[�h.Text.Trim();

			if(!�K�{�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;
			if(!���p�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;

			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			String[] sList = {""};
			try
			{
				if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
				sList = sv_goirai.Get_Sirainusi(gsa���[�U,gs����b�c,gs����b�c,tex�˗���R�[�h.Text.Trim());
				Cursor = System.Windows.Forms.Cursors.Default;
			
				//			sUpday    = sList[14];
// MOD 2007.06.21 ���s�j���� ORA-00921����єr���G���[�Ή� START
//				sIUFlg    = sList[17];
				if(sList[17] == "U"){
					s�X�V���� = sList[16];
				}else{
					s�X�V���� = "";
				}
// MOD 2007.06.21 ���s�j���� ORA-00921����єr���G���[�Ή� END

				String[] sDList;
				string[] sData = new string[5];

				DialogResult result;
// MOD 2007.06.21 ���s�j���� ORA-00921����єr���G���[�Ή� START
//				if(sIUFlg == "I")
				if(s�X�V����.Length == 0)
// MOD 2007.06.21 ���s�j���� ORA-00921����єr���G���[�Ή� END
					MessageBox.Show("�R�[�h(" + tex�˗���R�[�h.Text + ")�̃f�[�^�͑��݂��܂���","�폜",MessageBoxButtons.OK);
				else
				{
// ADD 2005.11.07 ���s�j�ɉ� �o�׃W���[�i���`�F�b�N START
					if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
					string[] sCData = new string[3];
					sCData[0] = gs����b�c;
					sCData[1] = gs����b�c;
					sCData[2]  = tex�˗���R�[�h.Text.Trim();
					String[] sCList = sv_goirai.Sel_SyukkaIrainusi(gsa���[�U,sCData);

					if(sCList[0].Length != 4)
					{
						�r�[�v��();
						tex���b�Z�[�W.Text = sCList[0];
						return;
					}
// ADD 2005.11.07 ���s�j�ɉ� �o�׃W���[�i���`�F�b�N END

					result = MessageBox.Show("�R�[�h(" + tex�˗���R�[�h.Text + ")�̃f�[�^���폜���܂����H","�폜",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						tex���b�Z�[�W.Text = "�폜���D�D�D";
						sData[0] = gs����b�c;
						sData[1] = gs����b�c;
						sData[2]  = tex�˗���R�[�h.Text.Trim();
						sData[3] = "���˗���";
						sData[4] = gs���p�҂b�c;

						Cursor = System.Windows.Forms.Cursors.AppStarting;

						if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
						sDList = sv_goirai.Del_irainusi(gsa���[�U,sData);
						Cursor = System.Windows.Forms.Cursors.Default;
						if(sDList[0].Length == 4)
						{
							tex�˗���R�[�h.Text = "";
							btn���_Click(sender,e);
						}
						else
						{
							�r�[�v��();
							tex���b�Z�[�W.Text = sDList[0];
						}
					}
				}
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				sList[0] = gs�ʐM�G���[;
				Cursor = System.Windows.Forms.Cursors.Default;
				tex���b�Z�[�W.Text = sList[0];
				�r�[�v��();
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				sList[0] = "�ʐM�G���[�F" + ex.Message;
				Cursor = System.Windows.Forms.Cursors.Default;
				tex���b�Z�[�W.Text = sList[0];
				�r�[�v��();
			}

		}

		private void btn�X�V_Click(object sender, System.EventArgs e)
		{
			tex�˗���R�[�h.Text = tex�˗���R�[�h.Text.Trim();
			tex�d�b�ԍ��P.Text   = tex�d�b�ԍ��P.Text.Trim();
			tex�d�b�ԍ��Q.Text   = tex�d�b�ԍ��Q.Text.Trim();
			tex�d�b�ԍ��R.Text   = tex�d�b�ԍ��R.Text.Trim();
			tex�X�֔ԍ��P.Text   = tex�X�֔ԍ��P.Text.Trim();
			tex�X�֔ԍ��Q.Text   = tex�X�֔ԍ��Q.Text.Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//			tex�Z���P.Text       = tex�Z���P.Text.Trim();
//			tex�Z���Q.Text       = tex�Z���Q.Text.Trim();
//			tex���O�P.Text       = tex���O�P.Text.Trim();
//			tex���O�Q.Text       = tex���O�Q.Text.Trim();
//			tex�J�i����.Text     = tex�J�i����.Text.Trim();
			if(gs�I�v�V����[18].Equals("1")){
				tex�Z���P.Text       = tex�Z���P.Text.TrimEnd();
				tex�Z���Q.Text       = tex�Z���Q.Text.TrimEnd();
				tex���O�P.Text       = tex���O�P.Text.TrimEnd();
				tex���O�Q.Text       = tex���O�Q.Text.TrimEnd();
				tex�J�i����.Text     = tex�J�i����.Text.TrimEnd();
			}else{
				tex�Z���P.Text       = tex�Z���P.Text.Trim();
				tex�Z���Q.Text       = tex�Z���Q.Text.Trim();
				tex���O�P.Text       = tex���O�P.Text.Trim();
				tex���O�Q.Text       = tex���O�Q.Text.Trim();
				tex�J�i����.Text     = tex�J�i����.Text.Trim();
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
			tex���[��.Text       = tex���[��.Text.Trim();
			cmb������.Text       = cmb������.Text.Trim();

			if(!�K�{�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;
			if(!�K�{�`�F�b�N(tex�d�b�ԍ��P,"�d�b�ԍ��P")) return;
			if(!�K�{�`�F�b�N(tex�d�b�ԍ��Q,"�d�b�ԍ��Q")) return;
			if(!�K�{�`�F�b�N(tex�d�b�ԍ��R,"�d�b�ԍ��R")) return;
			if(!�K�{�`�F�b�N(tex�X�֔ԍ��P,"�X�֔ԍ��P")) return;
			if(!�K�{�`�F�b�N(tex�X�֔ԍ��Q,"�X�֔ԍ��Q")) return;
			if(!�K�{�`�F�b�N(tex�Z���P,"�Z���P")) return;
			if(!�K�{�`�F�b�N(tex���O�P,"���O�P")) return;

			if(!���p�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;
			if(!���l�`�F�b�N(tex�d�b�ԍ��P,"�d�b�ԍ��P")) return;
			if(!���l�`�F�b�N(tex�d�b�ԍ��Q,"�d�b�ԍ��Q")) return;
			if(!���l�`�F�b�N(tex�d�b�ԍ��R,"�d�b�ԍ��R")) return;
			if(!���p�`�F�b�N(tex�X�֔ԍ��P,"�X�֔ԍ��P")) return;
			if(!���p�`�F�b�N(tex�X�֔ԍ��Q,"�X�֔ԍ��Q")) return;
			if(!�S�p�`�F�b�N(tex�Z���P,"�Z���P")) return;
			if(!�S�p�`�F�b�N(tex�Z���Q,"�Z���Q")) return;
			if(!�S�p�`�F�b�N(tex���O�P,"���O�P")) return;
			if(!�S�p�`�F�b�N(tex���O�Q,"���O�Q")) return;
			if(!���p�`�F�b�N(tex�J�i����,"�J�i����")) return;
			if(!���p�`�F�b�N(tex���[��,"���[���A�h���X")) return;

// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
			if(gs�d�ʓ��͐��� == "1"){
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
				if(nUD�d��.Text.Length == 0 ) nUD�d��.Text = "0";
				if(nUD�ː�.Text.Length == 0 ) nUD�ː�.Text = "0";

				if(!�͈̓`�F�b�N(nUD�d��,"�d��")) return;
// ADD 2005.05.17 ���s�j�����J �ː����� START
				if(!�͈̓`�F�b�N(nUD�ː�,"�ː�")) return;
// ADD 2005.05.17 ���s�j�����J �ː����� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
			}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END

			if(cmb������.Text.Length == 0 )
			{
				MessageBox.Show("�K�{���ځi������j�����͂���Ă��܂���","���̓`�F�b�N",MessageBoxButtons.OK);
				cmb������.Focus();
				return;
			}

// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� START
			tex������R�[�h.Text     = "";
			tex�����敔�ۃR�[�h.Text = "";
			if(gsa������b�c.Length > 0){
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N START
				if(cmb������.SelectedIndex < gsa������b�c.Length){
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N END
					tex������R�[�h.Text     = gsa������b�c[cmb������.SelectedIndex];
					tex�����敔�ۃR�[�h.Text = gsa�����敔�ۂb�c[cmb������.SelectedIndex];
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N START
				}
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N END
			}
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� END

			//�X�֔ԍ����݃`�F�b�N
			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string s�X�֔ԍ� = tex�X�֔ԍ��P.Text + tex�X�֔ԍ��Q.Text;
			string[] sRet = {""};
			try
			{
				if(sv_address == null) sv_address = new is2address.Service1();
				sRet = sv_address.Get_byPostcode2(gsa���[�U,s�X�֔ԍ�);
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

			if(sRet[0].Length != 4)
			{
				if(sRet[0].Equals("�Y���f�[�^������܂���"))
					sRet[0] = "�X�֔ԍ������݂��܂���";
				tex���b�Z�[�W.Text = sRet[0];
				�r�[�v��();
				tex�X�֔ԍ��P.Focus();
				Cursor = System.Windows.Forms.Cursors.Default;
				return;
			}


			tex���b�Z�[�W.Text = "";
			// �J�[�\���������v�ɂ���
			String[] sList = {""};
			try
			{
				if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
				sList = sv_goirai.Get_Sirainusi(gsa���[�U,gs����b�c,gs����b�c,tex�˗���R�[�h.Text.Trim());
				Cursor = System.Windows.Forms.Cursors.Default;
//			sUpday    = sList[14];
// MOD 2007.06.21 ���s�j���� ORA-00921����єr���G���[�Ή� START
//				sIUFlg    = sList[17];
				if(sList[17] == "U"){
					s�X�V���� = sList[16];
				}else{
					s�X�V���� = "";
				}
// MOD 2007.06.21 ���s�j���� ORA-00921����єr���G���[�Ή� END

				String[] sIUList;
// MOD 2006.08.10 ���s�j�R�{ �˗��l���u�����\���Ɏg�p����v�������\�ɂ���Ή� START
//				string[] sData = new string[22];
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
//				string[] sData = new string[23];
				string[] sData = new string[24];
				sData[23] = gs�d�ʓ��͐���;
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
// MOD 2006.08.10 ���s�j�R�{ �˗��l���u�����\���Ɏg�p����v�������\�ɂ���Ή� END
				sData[0]  = tex�˗���R�[�h.Text;
				sData[1]  = tex�J�i����.Text;
				sData[2]  = tex�d�b�ԍ��P.Text;
				sData[3]  = tex�d�b�ԍ��Q.Text;
				sData[4]  = tex�d�b�ԍ��R.Text;
// MOD 2005.09.02 ���s�j�����J �󔒂��� START
//				sData[5]  = tex�X�֔ԍ��P.Text;
				sData[5]  = tex�X�֔ԍ��P.Text.PadRight(3,' ');
// MOD 2005.09.02 ���s�j�����J �󔒂��� END
				sData[6]  = tex�X�֔ԍ��Q.Text;
				sData[7]  = tex�Z���P.Text;
				sData[8]  = tex�Z���Q.Text;
				sData[9]  = tex���O�P.Text;
				sData[10] = tex���O�Q.Text;
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
				if(gs�d�ʓ��͐��� == "1"){
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
// MOD 2005.05.17 ���s�j�����J �ː����� START
					sData[11] = nUD�ː�.Value.ToString();
// MOD 2005.05.17 ���s�j�����J �ː����� END
					sData[12] = nUD�d��.Value.ToString();
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
				}else{
					sData[11] = "0";
					sData[12] = "0";
				}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
				sData[13] = tex���[��.Text;
				sData[14] = "���˗���";
				sData[15] = gs���p�҂b�c;
				sData[16] = gs����b�c;
				sData[17] = gs����b�c;
// MOD 2007.06.21 ���s�j���� ORA-00921����єr���G���[�Ή� START
//				sData[18] = sUpday;
				sData[18] = s�X�V����;
// MOD 2007.06.21 ���s�j���� ORA-00921����єr���G���[�Ή� END
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N START
				sData[19] = " ";
				sData[20] = " ";
				if(cmb������.SelectedIndex < gsa������b�c.Length){
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N END
					sData[19] = gsa������b�c[cmb������.SelectedIndex];
					sData[20] = gsa�����敔�ۂb�c[cmb������.SelectedIndex];
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N START
				}
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N END
				if(cBox�f�t�H���g.Checked == true)
					sData[21] = "1";
				else
					sData[21] = "0";
// ADD 2006.08.10 ���s�j�R�{ �˗��l���u�����\���Ɏg�p����v�������\�ɂ���Ή� START
				if(bDefFlg == true)
				{
					if(cBox�f�t�H���g.Checked == false)
						sData[22] = "1";
					else
						sData[22] = "0";
				}
				else
					sData[22] = "0";
// ADD 2006.08.10 ���s�j�R�{ �˗��l���u�����\���Ɏg�p����v�������\�ɂ���Ή� END

				for(int iCnt = 0 ; iCnt < sData.Length; iCnt++ )
				{
					if( sData[iCnt] == null 
						|| sData[iCnt].Length == 0 ) sData[iCnt] = " ";
				}

				DialogResult result;
// MOD 2007.06.21 ���s�j���� ORA-00921����єr���G���[�Ή� START
//				if(sIUFlg == "I")
				if(s�X�V����.Length == 0)
// MOD 2007.06.21 ���s�j���� ORA-00921����єr���G���[�Ή� END
				{
					result = MessageBox.Show("�V�K�o�^���܂����H","�o�^",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						tex���b�Z�[�W.Text = "�o�^���D�D�D";

						if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
						sIUList = sv_goirai.Ins_irainusi(gsa���[�U,sData);
						Cursor = System.Windows.Forms.Cursors.Default;
						if(sIUList[0].Length == 4)
						{
							if(cBox�f�t�H���g.Checked == true)
								gs�ב��l�b�c = tex�˗���R�[�h.Text;
							tex�˗���R�[�h.Text = "";
							btn���_Click(sender,e);
						}
						else
						{
							�r�[�v��();
							tex���b�Z�[�W.Text = sIUList[0];
						}
					}
				}
				else
				{
					result = MessageBox.Show("���ɑ��݂���f�[�^�ɏ㏑�����܂����H","�X�V",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						tex���b�Z�[�W.Text = "�X�V���D�D�D";

						if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
// MOD 2006.08.10 ���s�j�R�{ �˗��l���u�����\���Ɏg�p����v�������\�ɂ���Ή� START
//						sIUList = sv_goirai.Upd_irainusi(gsa���[�U,sData);
						sIUList = sv_goirai.Upd_irainusi1(gsa���[�U,sData);
// MOD 2006.08.10 ���s�j�R�{ �˗��l���u�����\���Ɏg�p����v�������\�ɂ���Ή� END
						Cursor = System.Windows.Forms.Cursors.Default;
						if(sIUList[0].Length == 4)
						{
							if(cBox�f�t�H���g.Checked == true)
								gs�ב��l�b�c = tex�˗���R�[�h.Text;
// ADD 2006.08.10 ���s�j�R�{ �˗��l���u�����\���Ɏg�p����v�������\�ɂ���Ή� START
							if(sData[22] == "1")
								gs�ב��l�b�c = "";
// ADD 2006.08.10 ���s�j�R�{ �˗��l���u�����\���Ɏg�p����v�������\�ɂ���Ή� END
							tex�˗���R�[�h.Text = "";
							btn���_Click(sender,e);
						}
						else
						{
							�r�[�v��();
							tex���b�Z�[�W.Text = sIUList[0];
						}
					}
				}
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				sList[0] = gs�ʐM�G���[;
				Cursor = System.Windows.Forms.Cursors.Default;
				tex���b�Z�[�W.Text = sList[0];
				�r�[�v��();
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				sList[0] = "�ʐM�G���[�F" + ex.Message;
				Cursor = System.Windows.Forms.Cursors.Default;
				tex���b�Z�[�W.Text = sList[0];
				�r�[�v��();
			}
		}

		private void btn�˗�����s_Click(object sender, System.EventArgs e)
		{
			// ���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
			btn���_Click(sender,e);

			// �󔒏���
			tex�˗���R�[�h.Text = tex�˗���R�[�h.Text.Trim();

			if(!�K�{�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;
			if(!���p�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;

			s�˗���b�c = tex�˗���R�[�h.Text.Trim();
			btn�˗�����s_Click();

		}

		private void tex�˗���R�[�h_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				if(tex�˗���R�[�h.Text.Trim().Length == 0)
				{
					tex�˗���R�[�h.Focus();
					btn�˗��匟��_Click(sender, e);
				}
				else
				{
					btn�˗�����s_Click(sender, e);
				}
				return;
			}
		}

		private void tex�X�֔ԍ��Q_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				// �󔒏���
				tex�X�֔ԍ��P.Text = tex�X�֔ԍ��P.Text.Trim();
				tex�X�֔ԍ��Q.Text = tex�X�֔ԍ��Q.Text.Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//				tex�Z���P.Text = tex�Z���P.Text.Trim();
//				tex�Z���Q.Text = tex�Z���Q.Text.Trim();
				if(gs�I�v�V����[18].Equals("1")){
					tex�Z���P.Text       = tex�Z���P.Text.TrimEnd();
					tex�Z���Q.Text       = tex�Z���Q.Text.TrimEnd();
				}else{
					tex�Z���P.Text       = tex�Z���P.Text.Trim();
					tex�Z���Q.Text       = tex�Z���Q.Text.Trim();
				}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END

				// ���̓`�F�b�N
				if(!���p�`�F�b�N(tex�X�֔ԍ��P,"�X�֔ԍ��P")) return;
				if(!���p�`�F�b�N(tex�X�֔ԍ��Q,"�X�֔ԍ��Q")) return;

				string s�X�֔ԍ� = tex�X�֔ԍ��P.Text + tex�X�֔ԍ��Q.Text;
				if(s�X�֔ԍ�.Length == 7)
				{
					if(tex�Z���P.Text.Length == 0 
						&& tex�Z���Q.Text.Length == 0)
					{
						// �J�[�\���������v�ɂ���
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						string[] sRet = {""};
						try
						{
							if(sv_address == null) sv_address = new is2address.Service1();
							tex���b�Z�[�W.Text = "�������D�D�D";
							sRet = sv_address.Get_byPostcode2(gsa���[�U,s�X�֔ԍ�);
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
						Cursor = System.Windows.Forms.Cursors.Default;

						if(sRet[0].Length == 4)
						{
// �ۗ�						sRet[1]�F�X�֔ԍ�
// �ۗ�						sRet[3]�F�Z���b�c
							if(sRet[2].Length > 40){
								tex�Z���P.Text     = sRet[2].Substring(0,20);
								tex�Z���Q.Text     = sRet[2].Substring(20,20);
							}else if(sRet[2].Length > 20){
								tex�Z���P.Text     = sRet[2].Substring(0,20);
								tex�Z���Q.Text     = sRet[2].Substring(20);
							}else{
								tex�Z���P.Text     = sRet[2];
								tex�Z���Q.Text     = "";
							}
							tex���b�Z�[�W.Text = "";
							//�t�H�[�J�X�ݒ�
							tex�Z���Q.Focus();
						}
						else
						{
							if(sRet[0].Equals("�Y���f�[�^������܂���"))
								sRet[0] = "�X�֔ԍ������݂��܂���";
							tex���b�Z�[�W.Text = sRet[0];
							//�t�H�[�J�X�ݒ�
							�r�[�v��();
							tex�X�֔ԍ��P.Focus();
						}
					}
				}
				else
				{
					btn�Z������.Focus();
					btn�Z������_Click(sender, e);
				}

				return;
			}
		}

		private void tex�˗���R�[�h_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn�˗��匟��.Focus();
				btn�˗��匟��_Click(sender,e);
				e.Handled = true;
			}		

		}

		private void tex�X�֔ԍ��P_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn�Z������.Focus();
				btn�Z������_Click(sender,e);
				e.Handled = true;
			}		
		}

		private void tex�X�֔ԍ��Q_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn�Z������.Focus();
				btn�Z������_Click(sender,e);
				e.Handled = true;
			}		
		}

		private void btn�ꗗ�\_Click(object sender, System.EventArgs e)
		{
			tex���b�Z�[�W.Text = "���˗���ꗗ������D�D�D";
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				if(sv_print == null) sv_print = new is2print.Service1();
				string[] sKey = new string[3];
				sKey[0] = gs����b�c;
				sKey[1] = gs����b�c;

				string[] sRet = new string[1];
				IEnumerator iEnum = sv_print.Get_ConsignorPrintData(gsa���[�U,sKey).GetEnumerator();
				iEnum.MoveNext();
				sRet = (string[])iEnum.Current;
// DEL 2005.05.11 ���s�j���� �u����I���v�͕\�����Ȃ� START
//				tex���b�Z�[�W.Text = sRet[0];
// DEL 2005.05.11 ���s�j���� �u����I���v�͕\�����Ȃ� END
				if (sRet[0].Equals("����I��"))
				{
					���˗���f�[�^ ds = new ���˗���f�[�^();

					int iCnt = 1;
					//�f�[�^�Z�b�g�ɒl���Z�b�g
					while (iEnum.MoveNext())
					{
						string[] sList = new string[14];
						sList = (string[])iEnum.Current;
					
						���˗���f�[�^.table���˗���Row tr = (���˗���f�[�^.table���˗���Row)ds.table���˗���.NewRow();
						tr.BeginEdit();
						tr.�ԍ�     = iCnt++;
						tr.�R�[�h   = sList[0].Trim();
						tr.�J�i���� = sList[1].Trim();
						if(sList[2].Trim().Length == 0)
							tr.�d�b�ԍ� = sList[3] + "-" + sList[4];
						else
							tr.�d�b�ԍ� = "(" + sList[2] + ")" + sList[3] + "-" + sList[4];
						tr.�X�֔ԍ� = sList[5] + "-" + sList[6];
						tr.�Z��     = sList[7].Trim() + sList[8].Trim() + sList[9].Trim();
						tr.���O     = sList[10].Trim() + "  " + sList[11].Trim();
						tr.�d��     = double.Parse(sList[12]);
						tr.���Ӑ�R�[�h = sList[13].Trim();
						tr.���Ӑ敔�ۃR�[�h = sList[14].Trim();
						tr.���Ӑ敔�ۖ� = sList[15].Trim();
//�ۗ� MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
///						if(gs�I�v�V����[18].Equals("1")){
							tr.�J�i���� = sList[1].TrimEnd();
							tr.�Z��     = sList[7].TrimEnd() + sList[8].TrimEnd() + sList[9].TrimEnd();
							tr.���O     = sList[10].TrimEnd() + "  " + sList[11].TrimEnd();
							tr.���Ӑ敔�ۖ� = sList[15].TrimEnd();
///						}
//�ۗ� MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
						tr.�d�ʓ��͐��� = (sList.Length > 17) ? sList[17].TrimEnd() : "0";
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
						tr.EndEdit();

						ds.table���˗���.Rows.Add(tr);					
					}
					
					���˗��咠�[ cr = new ���˗��咠�[();
					//CrystalReport�Ƀp�����[�^�ƃf�[�^�Z�b�g��n��
					cr.SetParameterValue("����b�c", gs����b�c);
					cr.SetParameterValue("���喼",   gs���喼);
					cr.SetDataSource(ds);

					//�v���r���[�\��
					�v���r���[��� ��� = new �v���r���[���();
					���.Left = this.Left;
					���.Top = this.Top;
					���.crv���[.PrintReport();
					���.crv���[.ReportSource = cr;
					���.ShowDialog();
					tex���b�Z�[�W.Text = "";
// MOD 2011.01.25 ���s�j���� �u���[�h�Ɏ��s�v�Ή� START
					try{
						cr.Close();
						cr.Dispose();
					}catch(Exception){
						;
					}
					//�����I�̈�J��
					cr  = null;
					ds  = null;

					//�����I�K�x�[�W�R���N�^
					System.GC.Collect();
// MOD 2011.01.25 ���s�j���� �u���[�h�Ɏ��s�v�Ή� END
				}
				else
				{
// ADD 2005.05.11 ���s�j���� �u����I���v�͕\�����Ȃ� START
					tex���b�Z�[�W.Text = sRet[0];
// ADD 2005.05.11 ���s�j���� �u����I���v�͕\�����Ȃ� END
					�r�[�v��();
				}
			}
// ADD 2005.06.27 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				tex���b�Z�[�W.Text = gs�ʐM�G���[;
				�r�[�v��();
			}
// ADD 2005.06.27 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				tex���b�Z�[�W.Text = ex.Message;
				�r�[�v��();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void nUD�d��_Enter(object sender, System.EventArgs e)
		{
			if(nUD�d��.Text.Length > 0) nUD�d��.Select(0, nUD�d��.Text.Length);
		}

// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� START
		private void ���˗���o�^_Closed(object sender, System.EventArgs e)
		{
			tex�˗���R�[�h.Text = " ";
			btn���_Click(sender,e);
			tex�˗���R�[�h.Focus();
		}
// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� END

// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� START
		private void cmb������_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			tex������R�[�h.Text     = "";
			tex�����敔�ۃR�[�h.Text = "";
			if(gsa������b�c.Length > 0){
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N START
				if(cmb������.SelectedIndex < gsa������b�c.Length){
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N END
					tex������R�[�h.Text     = gsa������b�c[cmb������.SelectedIndex];
					tex�����敔�ۃR�[�h.Text = gsa�����敔�ۂb�c[cmb������.SelectedIndex];
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N START
				}
// MOD 2010.09.07 ���s�j���� ������R�[�h�̑��݃`�F�b�N END
			}
		}
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� END

// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� START
		private void btn�b�r�u�o��_Click(object sender, System.EventArgs e)
		{
// MOD 2010.09.22 ���s�j���� �b�r�u�o�́F[�L�����Z��]�I�����̏�Q�C�� START
			tex���b�Z�[�W.Text = "";
// MOD 2010.09.22 ���s�j���� �b�r�u�o�́F[�L�����Z��]�I�����̏�Q�C�� END
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try{
				String[] sList;
				if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
				sList = sv_goirai.Get_csvwrite(gsa���[�U,gs����b�c,gs����b�c);
				this.Cursor = System.Windows.Forms.Cursors.Default;

				if(sList[0].Length == 4){
					// ���o�����̕ҏW
					sList[0] = "\"�ב��l�R�[�h\",\"�d�b�ԍ�\","
						+ "\"�Z���P\",\"�Z���Q\",\"�\���P\","
						+ "\"���O�P\",\"���O�Q\",\"�\���Q\","
						+ "\"�X�֔ԍ�\",\"�J�i����\",\"�ː�\",\"�d��\",\"���[���A�h���X\","
						+ "\"������R�[�h\",\"�����敔�ۃR�[�h\""
						;

					// �f�t�H���g�̃t�H���_���f�X�N�g�b�v�t�H���_�ɂ���
					saveFileDialog1.InitialDirectory
						= Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
					saveFileDialog1.Filter = "�b�r�u�t�@�C�� (*.csv)|*.csv";
					byte[] bSJIS;
					if(saveFileDialog1.ShowDialog(this) == DialogResult.OK){
						System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
						for(int iCnt = 0; iCnt < sList.Length; iCnt++){
							bSJIS = toSJIS(sList[iCnt]);
							fs.Write(bSJIS, 0 , bSJIS.Length);
						}
						fs.Close();
					}
					tex���b�Z�[�W.Text = "";
				}else{
					�r�[�v��();
					tex���b�Z�[�W.Text = sList[0];
				}
			}catch (System.Net.WebException){
				this.Cursor = System.Windows.Forms.Cursors.Default;
				tex���b�Z�[�W.Text = gs�ʐM�G���[;
				�r�[�v��();
			}catch(Exception ex){
				this.Cursor = System.Windows.Forms.Cursors.Default;
				tex���b�Z�[�W.Text = ex.Message;
			}
			tex�˗���R�[�h.Focus();
		}
// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� END

	}
}
