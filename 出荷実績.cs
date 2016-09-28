using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;

namespace IS2Client
{
	/// <summary>
	/// [�o�׎���]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// MDD 2008.06.12 ���s�j���� �^�����O�̏ꍇ[��]�\�� 
	// MOD 2008.07.09 ���s�j���� �����s�������O���� 
	// MOD 2008.07.25 ���s�j���� �Ԋ|�����͂��� 
	//--------------------------------------------------------------------------
	// MOD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� 
	// MOD 2009.04.06 ���s�j���� [���˗���󎚂Ȃ�]�A[�^���󎚂Ȃ�]�̋@�\�̒ǉ� 
	// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� 
	// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� 
	//--------------------------------------------------------------------------
	// MOD 2010.02.01 ���s�j���� �I�v�V�����̍��ڒǉ��i�b�r�u�o�͌`���j
	// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� 
	// MOD 2011.01.25 ���s�j���� �u���[�h�Ɏ��s�v�Ή� 
	// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� 
	// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� 
	//--------------------------------------------------------------------------
	// MOD 2013.10.07 BEVAS�j���� �z�����t�E������ǉ�
	//--------------------------------------------------------------------------
	// MOD 2015.10.21 BEVAS�j���{ �x�X�~�ߏo�ׂ̏ꍇ�A���͂���Z���̕\�L��ύX
	//--------------------------------------------------------------------------
	// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ�
	//--------------------------------------------------------------------------
	public class �o�׎��� : ���ʃt�H�[��
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tex���b�Z�[�W;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label lab�o�׎��у^�C�g��;
		private System.Windows.Forms.ComboBox cmb�o�ד�;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dt�J�n���t;
		private System.Windows.Forms.DateTimePicker dt�I�����t;
		private System.Windows.Forms.Button btn�b�r�u�o��;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button btn���;
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.CheckBox cBox�����s��������;
		private System.Windows.Forms.CheckBox cBox�Ԋ|���Ȃ�;
		private System.Windows.Forms.RadioButton rb�W�s;
		private System.Windows.Forms.CheckBox cb���͂���Z�����;
		private System.Windows.Forms.RadioButton rb�Q�s;
		private System.Windows.Forms.Label lab���׈��;

// ADD 2006.08.09 ���s�j�R�{ ���������Ɉ˗����ǉ� START
		private string s�˗���b�c;
		private System.Windows.Forms.Label lab�I�v�V����;
		private string s�˗��喼;
// ADD 2006.08.09 ���s�j�R�{ ���������Ɉ˗����ǉ� END
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� START
		private string s�͂���b�c = "";
		private string s�͂��於   = "";
		private string s������b�c = "";
		private string s���ۂb�c   = "";
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� END

		private System.Windows.Forms.CheckBox cBox�^���󎚂Ȃ�;
		private System.Windows.Forms.Label lab���q�l�ԍ�;
		private System.Windows.Forms.Label label3;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex���q�l�ԍ��J�n;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex���q�l�ԍ��I��;
		private System.Windows.Forms.GroupBox gb�o�͌`��;
		private System.Windows.Forms.TextBox tex�˗��喼;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�˗���R�[�h;
		private System.Windows.Forms.Button btn�˗��匟��;
		private System.Windows.Forms.RadioButton rb�w��Ȃ�;
		private System.Windows.Forms.RadioButton rb���˗����;
		private System.Windows.Forms.RadioButton rb�������;
		private System.Windows.Forms.RadioButton rb���͂����;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex������R�[�h;
		private System.Windows.Forms.TextBox tex�͂��於;
		private System.Windows.Forms.Button btn�͂��挟��;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�͂���R�[�h;
		private System.Windows.Forms.ComboBox cmb������;
		private System.Windows.Forms.Label lab������R�[�h;
		private System.Windows.Forms.CheckBox cBox���X�b�c�o��;
		private System.Windows.Forms.CheckBox cBox�z���r�o��;
		private System.Windows.Forms.CheckBox cBox���˗���󎚂Ȃ�;

		public �o�׎���()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
			�c�o�h�\���T�C�Y�ϊ�();
// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� END
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� START
			�o�̓I�v�V�������ݒ�();
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� END
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
			this.cBox���X�b�c�o�� = new System.Windows.Forms.CheckBox();
			this.gb�o�͌`�� = new System.Windows.Forms.GroupBox();
			this.lab������R�[�h = new System.Windows.Forms.Label();
			this.cmb������ = new System.Windows.Forms.ComboBox();
			this.tex�͂��於 = new System.Windows.Forms.TextBox();
			this.btn�͂��挟�� = new System.Windows.Forms.Button();
			this.tex�͂���R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex������R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.rb���͂���� = new System.Windows.Forms.RadioButton();
			this.rb������� = new System.Windows.Forms.RadioButton();
			this.rb���˗���� = new System.Windows.Forms.RadioButton();
			this.rb�w��Ȃ� = new System.Windows.Forms.RadioButton();
			this.tex�˗��喼 = new System.Windows.Forms.TextBox();
			this.tex�˗���R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.btn�˗��匟�� = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.tex���q�l�ԍ��I�� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex���q�l�ԍ��J�n = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab���q�l�ԍ� = new System.Windows.Forms.Label();
			this.lab�I�v�V���� = new System.Windows.Forms.Label();
			this.cBox�^���󎚂Ȃ� = new System.Windows.Forms.CheckBox();
			this.cBox���˗���󎚂Ȃ� = new System.Windows.Forms.CheckBox();
			this.cb���͂���Z����� = new System.Windows.Forms.CheckBox();
			this.lab���׈�� = new System.Windows.Forms.Label();
			this.rb�Q�s = new System.Windows.Forms.RadioButton();
			this.rb�W�s = new System.Windows.Forms.RadioButton();
			this.cBox�Ԋ|���Ȃ� = new System.Windows.Forms.CheckBox();
			this.cBox�����s�������� = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dt�J�n���t = new System.Windows.Forms.DateTimePicker();
			this.dt�I�����t = new System.Windows.Forms.DateTimePicker();
			this.cmb�o�ד� = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab�o�׎��у^�C�g�� = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn�b�r�u�o�� = new System.Windows.Forms.Button();
			this.btn��� = new System.Windows.Forms.Button();
			this.tex���b�Z�[�W = new System.Windows.Forms.TextBox();
			this.btn���� = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.cBox�z���r�o�� = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).BeginInit();
			this.panel1.SuspendLayout();
			this.gb�o�͌`��.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Honeydew;
			this.panel1.Controls.Add(this.cBox�z���r�o��);
			this.panel1.Controls.Add(this.cBox���X�b�c�o��);
			this.panel1.Controls.Add(this.gb�o�͌`��);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.tex���q�l�ԍ��I��);
			this.panel1.Controls.Add(this.tex���q�l�ԍ��J�n);
			this.panel1.Controls.Add(this.lab���q�l�ԍ�);
			this.panel1.Controls.Add(this.lab�I�v�V����);
			this.panel1.Controls.Add(this.cBox�^���󎚂Ȃ�);
			this.panel1.Controls.Add(this.cBox���˗���󎚂Ȃ�);
			this.panel1.Controls.Add(this.cb���͂���Z�����);
			this.panel1.Controls.Add(this.lab���׈��);
			this.panel1.Controls.Add(this.rb�Q�s);
			this.panel1.Controls.Add(this.rb�W�s);
			this.panel1.Controls.Add(this.cBox�Ԋ|���Ȃ�);
			this.panel1.Controls.Add(this.cBox�����s��������);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.dt�J�n���t);
			this.panel1.Controls.Add(this.dt�I�����t);
			this.panel1.Controls.Add(this.cmb�o�ד�);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(0, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(618, 432);
			this.panel1.TabIndex = 1;
			// 
			// cBox���X�b�c�o��
			// 
			this.cBox���X�b�c�o��.ForeColor = System.Drawing.Color.Black;
			this.cBox���X�b�c�o��.Location = new System.Drawing.Point(330, 308);
			this.cBox���X�b�c�o��.Name = "cBox���X�b�c�o��";
			this.cBox���X�b�c�o��.Size = new System.Drawing.Size(282, 26);
			this.cBox���X�b�c�o��.TabIndex = 62;
			this.cBox���X�b�c�o��.Text = "�����ɔ��X�R�[�h�E���X�����o�͂���i�b�r�u�̂݁j";
			// 
			// gb�o�͌`��
			// 
			this.gb�o�͌`��.Controls.Add(this.lab������R�[�h);
			this.gb�o�͌`��.Controls.Add(this.cmb������);
			this.gb�o�͌`��.Controls.Add(this.tex�͂��於);
			this.gb�o�͌`��.Controls.Add(this.btn�͂��挟��);
			this.gb�o�͌`��.Controls.Add(this.tex�͂���R�[�h);
			this.gb�o�͌`��.Controls.Add(this.tex������R�[�h);
			this.gb�o�͌`��.Controls.Add(this.rb���͂����);
			this.gb�o�͌`��.Controls.Add(this.rb�������);
			this.gb�o�͌`��.Controls.Add(this.rb���˗����);
			this.gb�o�͌`��.Controls.Add(this.rb�w��Ȃ�);
			this.gb�o�͌`��.Controls.Add(this.tex�˗��喼);
			this.gb�o�͌`��.Controls.Add(this.tex�˗���R�[�h);
			this.gb�o�͌`��.Controls.Add(this.btn�˗��匟��);
			this.gb�o�͌`��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.gb�o�͌`��.ForeColor = System.Drawing.Color.LimeGreen;
			this.gb�o�͌`��.Location = new System.Drawing.Point(30, 8);
			this.gb�o�͌`��.Name = "gb�o�͌`��";
			this.gb�o�͌`��.Size = new System.Drawing.Size(582, 158);
			this.gb�o�͌`��.TabIndex = 0;
			this.gb�o�͌`��.TabStop = false;
			this.gb�o�͌`��.Text = "�o�͌`��";
			// 
			// lab������R�[�h
			// 
			this.lab������R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab������R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab������R�[�h.Location = new System.Drawing.Point(264, 90);
			this.lab������R�[�h.Name = "lab������R�[�h";
			this.lab������R�[�h.Size = new System.Drawing.Size(32, 14);
			this.lab������R�[�h.TabIndex = 67;
			this.lab������R�[�h.Text = "�R�[�h";
			// 
			// cmb������
			// 
			this.cmb������.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb������.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cmb������.Location = new System.Drawing.Point(116, 88);
			this.cmb������.Name = "cmb������";
			this.cmb������.Size = new System.Drawing.Size(144, 20);
			this.cmb������.TabIndex = 6;
			this.cmb������.SelectedIndexChanged += new System.EventHandler(this.cmb������_SelectedIndexChanged);
			// 
			// tex�͂��於
			// 
			this.tex�͂��於.BackColor = System.Drawing.Color.Honeydew;
			this.tex�͂��於.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�͂��於.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�͂��於.Location = new System.Drawing.Point(356, 124);
			this.tex�͂��於.Name = "tex�͂��於";
			this.tex�͂��於.ReadOnly = true;
			this.tex�͂��於.Size = new System.Drawing.Size(222, 16);
			this.tex�͂��於.TabIndex = 11;
			this.tex�͂��於.TabStop = false;
			this.tex�͂��於.Text = "";
			// 
			// btn�͂��挟��
			// 
			this.btn�͂��挟��.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�͂��挟��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�͂��挟��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�͂��挟��.ForeColor = System.Drawing.Color.White;
			this.btn�͂��挟��.Location = new System.Drawing.Point(304, 122);
			this.btn�͂��挟��.Name = "btn�͂��挟��";
			this.btn�͂��挟��.Size = new System.Drawing.Size(48, 22);
			this.btn�͂��挟��.TabIndex = 10;
			this.btn�͂��挟��.TabStop = false;
			this.btn�͂��挟��.Text = "����";
			this.btn�͂��挟��.Click += new System.EventHandler(this.btn�͂��挟��_Click);
			// 
			// tex�͂���R�[�h
			// 
			this.tex�͂���R�[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex�͂���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�͂���R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�͂���R�[�h.Location = new System.Drawing.Point(116, 122);
			this.tex�͂���R�[�h.MaxLength = 15;
			this.tex�͂���R�[�h.Name = "tex�͂���R�[�h";
			this.tex�͂���R�[�h.Size = new System.Drawing.Size(186, 23);
			this.tex�͂���R�[�h.TabIndex = 9;
			this.tex�͂���R�[�h.Text = "";
			this.tex�͂���R�[�h.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�͂���R�[�h_KeyDown);
			this.tex�͂���R�[�h.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�͂���R�[�h_KeyPress);
			// 
			// tex������R�[�h
			// 
			this.tex������R�[�h.BackColor = System.Drawing.Color.Honeydew;
			this.tex������R�[�h.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex������R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex������R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex������R�[�h.Location = new System.Drawing.Point(300, 88);
			this.tex������R�[�h.MaxLength = 12;
			this.tex������R�[�h.Name = "tex������R�[�h";
			this.tex������R�[�h.Size = new System.Drawing.Size(156, 16);
			this.tex������R�[�h.TabIndex = 7;
			this.tex������R�[�h.TabStop = false;
			this.tex������R�[�h.Text = "";
			// 
			// rb���͂����
			// 
			this.rb���͂����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.rb���͂����.Location = new System.Drawing.Point(10, 124);
			this.rb���͂����.Name = "rb���͂����";
			this.rb���͂����.Size = new System.Drawing.Size(104, 22);
			this.rb���͂����.TabIndex = 8;
			this.rb���͂����.Text = "���͂����";
			this.rb���͂����.CheckedChanged += new System.EventHandler(this.rb���͂����_CheckedChanged);
			// 
			// rb�������
			// 
			this.rb�������.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.rb�������.Location = new System.Drawing.Point(10, 88);
			this.rb�������.Name = "rb�������";
			this.rb�������.Size = new System.Drawing.Size(104, 22);
			this.rb�������.TabIndex = 5;
			this.rb�������.Text = "�������";
			this.rb�������.CheckedChanged += new System.EventHandler(this.rb�������_CheckedChanged);
			// 
			// rb���˗����
			// 
			this.rb���˗����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.rb���˗����.Location = new System.Drawing.Point(10, 54);
			this.rb���˗����.Name = "rb���˗����";
			this.rb���˗����.Size = new System.Drawing.Size(104, 22);
			this.rb���˗����.TabIndex = 1;
			this.rb���˗����.Text = "���˗����";
			this.rb���˗����.CheckedChanged += new System.EventHandler(this.rb���˗����_CheckedChanged);
			// 
			// rb�w��Ȃ�
			// 
			this.rb�w��Ȃ�.Checked = true;
			this.rb�w��Ȃ�.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.rb�w��Ȃ�.Location = new System.Drawing.Point(10, 20);
			this.rb�w��Ȃ�.Name = "rb�w��Ȃ�";
			this.rb�w��Ȃ�.Size = new System.Drawing.Size(104, 22);
			this.rb�w��Ȃ�.TabIndex = 0;
			this.rb�w��Ȃ�.TabStop = true;
			this.rb�w��Ȃ�.Text = "�w��Ȃ�";
			this.rb�w��Ȃ�.CheckedChanged += new System.EventHandler(this.rb�w��Ȃ�_CheckedChanged);
			// 
			// tex�˗��喼
			// 
			this.tex�˗��喼.BackColor = System.Drawing.Color.Honeydew;
			this.tex�˗��喼.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�˗��喼.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗��喼.Location = new System.Drawing.Point(326, 54);
			this.tex�˗��喼.Name = "tex�˗��喼";
			this.tex�˗��喼.ReadOnly = true;
			this.tex�˗��喼.Size = new System.Drawing.Size(222, 16);
			this.tex�˗��喼.TabIndex = 4;
			this.tex�˗��喼.TabStop = false;
			this.tex�˗��喼.Text = "";
			// 
			// tex�˗���R�[�h
			// 
			this.tex�˗���R�[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex�˗���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗���R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�˗���R�[�h.Location = new System.Drawing.Point(116, 52);
			this.tex�˗���R�[�h.MaxLength = 12;
			this.tex�˗���R�[�h.Name = "tex�˗���R�[�h";
			this.tex�˗���R�[�h.Size = new System.Drawing.Size(156, 23);
			this.tex�˗���R�[�h.TabIndex = 2;
			this.tex�˗���R�[�h.Text = "";
			this.tex�˗���R�[�h.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�˗���R�[�h_KeyDown);
			this.tex�˗���R�[�h.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�˗���R�[�h_KeyPress);
			// 
			// btn�˗��匟��
			// 
			this.btn�˗��匟��.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�˗��匟��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�˗��匟��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�˗��匟��.ForeColor = System.Drawing.Color.White;
			this.btn�˗��匟��.Location = new System.Drawing.Point(274, 52);
			this.btn�˗��匟��.Name = "btn�˗��匟��";
			this.btn�˗��匟��.Size = new System.Drawing.Size(48, 22);
			this.btn�˗��匟��.TabIndex = 3;
			this.btn�˗��匟��.TabStop = false;
			this.btn�˗��匟��.Text = "����";
			this.btn�˗��匟��.Click += new System.EventHandler(this.btn�˗��匟��_Click);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label3.ForeColor = System.Drawing.Color.LimeGreen;
			this.label3.Location = new System.Drawing.Point(318, 212);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(22, 16);
			this.label3.TabIndex = 61;
			this.label3.Text = "�`";
			// 
			// tex���q�l�ԍ��I��
			// 
			this.tex���q�l�ԍ��I��.BackColor = System.Drawing.SystemColors.Window;
			this.tex���q�l�ԍ��I��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���q�l�ԍ��I��.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex���q�l�ԍ��I��.Location = new System.Drawing.Point(340, 208);
			this.tex���q�l�ԍ��I��.MaxLength = 20;
			this.tex���q�l�ԍ��I��.Name = "tex���q�l�ԍ��I��";
			this.tex���q�l�ԍ��I��.Size = new System.Drawing.Size(190, 23);
			this.tex���q�l�ԍ��I��.TabIndex = 5;
			this.tex���q�l�ԍ��I��.Text = "";
			// 
			// tex���q�l�ԍ��J�n
			// 
			this.tex���q�l�ԍ��J�n.BackColor = System.Drawing.SystemColors.Window;
			this.tex���q�l�ԍ��J�n.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���q�l�ԍ��J�n.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex���q�l�ԍ��J�n.Location = new System.Drawing.Point(128, 208);
			this.tex���q�l�ԍ��J�n.MaxLength = 20;
			this.tex���q�l�ԍ��J�n.Name = "tex���q�l�ԍ��J�n";
			this.tex���q�l�ԍ��J�n.Size = new System.Drawing.Size(190, 23);
			this.tex���q�l�ԍ��J�n.TabIndex = 4;
			this.tex���q�l�ԍ��J�n.Text = "";
			// 
			// lab���q�l�ԍ�
			// 
			this.lab���q�l�ԍ�.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���q�l�ԍ�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���q�l�ԍ�.Location = new System.Drawing.Point(34, 212);
			this.lab���q�l�ԍ�.Name = "lab���q�l�ԍ�";
			this.lab���q�l�ԍ�.Size = new System.Drawing.Size(86, 16);
			this.lab���q�l�ԍ�.TabIndex = 58;
			this.lab���q�l�ԍ�.Text = "���q�l�ԍ�";
			// 
			// lab�I�v�V����
			// 
			this.lab�I�v�V����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�I�v�V����.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�I�v�V����.Location = new System.Drawing.Point(34, 310);
			this.lab�I�v�V����.Name = "lab�I�v�V����";
			this.lab�I�v�V����.Size = new System.Drawing.Size(90, 16);
			this.lab�I�v�V����.TabIndex = 57;
			this.lab�I�v�V����.Text = "�o�͵�߼��";
			// 
			// cBox�^���󎚂Ȃ�
			// 
			this.cBox�^���󎚂Ȃ�.ForeColor = System.Drawing.Color.Black;
			this.cBox�^���󎚂Ȃ�.Location = new System.Drawing.Point(130, 398);
			this.cBox�^���󎚂Ȃ�.Name = "cBox�^���󎚂Ȃ�";
			this.cBox�^���󎚂Ȃ�.Size = new System.Drawing.Size(190, 24);
			this.cBox�^���󎚂Ȃ�.TabIndex = 12;
			this.cBox�^���󎚂Ȃ�.Text = "�^���󎚂Ȃ��i����̂݁j";
			// 
			// cBox���˗���󎚂Ȃ�
			// 
			this.cBox���˗���󎚂Ȃ�.ForeColor = System.Drawing.Color.Black;
			this.cBox���˗���󎚂Ȃ�.Location = new System.Drawing.Point(130, 368);
			this.cBox���˗���󎚂Ȃ�.Name = "cBox���˗���󎚂Ȃ�";
			this.cBox���˗���󎚂Ȃ�.Size = new System.Drawing.Size(190, 24);
			this.cBox���˗���󎚂Ȃ�.TabIndex = 11;
			this.cBox���˗���󎚂Ȃ�.Text = "���˗���󎚂Ȃ��i����̂݁j";
			// 
			// cb���͂���Z�����
			// 
			this.cb���͂���Z�����.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cb���͂���Z�����.ForeColor = System.Drawing.Color.Black;
			this.cb���͂���Z�����.Location = new System.Drawing.Point(180, 274);
			this.cb���͂���Z�����.Name = "cb���͂���Z�����";
			this.cb���͂���Z�����.Size = new System.Drawing.Size(118, 22);
			this.cb���͂���Z�����.TabIndex = 8;
			this.cb���͂���Z�����.Text = "���͂���Z�����";
			this.cb���͂���Z�����.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lab���׈��
			// 
			this.lab���׈��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���׈��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���׈��.Location = new System.Drawing.Point(34, 246);
			this.lab���׈��.Name = "lab���׈��";
			this.lab���׈��.Size = new System.Drawing.Size(74, 16);
			this.lab���׈��.TabIndex = 56;
			this.lab���׈��.Text = "���׈��";
			// 
			// rb�Q�s
			// 
			this.rb�Q�s.ForeColor = System.Drawing.Color.Black;
			this.rb�Q�s.Location = new System.Drawing.Point(130, 274);
			this.rb�Q�s.Name = "rb�Q�s";
			this.rb�Q�s.Size = new System.Drawing.Size(44, 22);
			this.rb�Q�s.TabIndex = 7;
			this.rb�Q�s.Text = "�Q�s";
			// 
			// rb�W�s
			// 
			this.rb�W�s.Checked = true;
			this.rb�W�s.ForeColor = System.Drawing.Color.Black;
			this.rb�W�s.Location = new System.Drawing.Point(130, 244);
			this.rb�W�s.Name = "rb�W�s";
			this.rb�W�s.Size = new System.Drawing.Size(44, 22);
			this.rb�W�s.TabIndex = 6;
			this.rb�W�s.TabStop = true;
			this.rb�W�s.Text = "�W�s";
			this.rb�W�s.CheckedChanged += new System.EventHandler(this.rb�W�s_CheckedChanged);
			// 
			// cBox�Ԋ|���Ȃ�
			// 
			this.cBox�Ԋ|���Ȃ�.ForeColor = System.Drawing.Color.Black;
			this.cBox�Ԋ|���Ȃ�.Location = new System.Drawing.Point(130, 338);
			this.cBox�Ԋ|���Ȃ�.Name = "cBox�Ԋ|���Ȃ�";
			this.cBox�Ԋ|���Ȃ�.Size = new System.Drawing.Size(144, 24);
			this.cBox�Ԋ|���Ȃ�.TabIndex = 10;
			this.cBox�Ԋ|���Ȃ�.Text = "�Ԋ|���Ȃ��i����̂݁j";
			// 
			// cBox�����s��������
			// 
			this.cBox�����s��������.ForeColor = System.Drawing.Color.Black;
			this.cBox�����s��������.Location = new System.Drawing.Point(130, 308);
			this.cBox�����s��������.Name = "cBox�����s��������";
			this.cBox�����s��������.TabIndex = 9;
			this.cBox�����s��������.Text = "�����s��������";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label2.ForeColor = System.Drawing.Color.LimeGreen;
			this.label2.Location = new System.Drawing.Point(272, 178);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(24, 16);
			this.label2.TabIndex = 48;
			this.label2.Text = "�`";
			// 
			// dt�J�n���t
			// 
			this.dt�J�n���t.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.dt�J�n���t.Location = new System.Drawing.Point(128, 174);
			this.dt�J�n���t.Name = "dt�J�n���t";
			this.dt�J�n���t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.dt�J�n���t.Size = new System.Drawing.Size(144, 23);
			this.dt�J�n���t.TabIndex = 2;
			// 
			// dt�I�����t
			// 
			this.dt�I�����t.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.dt�I�����t.Location = new System.Drawing.Point(296, 174);
			this.dt�I�����t.Name = "dt�I�����t";
			this.dt�I�����t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.dt�I�����t.Size = new System.Drawing.Size(144, 23);
			this.dt�I�����t.TabIndex = 3;
			// 
			// cmb�o�ד�
			// 
			this.cmb�o�ד�.BackColor = System.Drawing.Color.White;
			this.cmb�o�ד�.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb�o�ד�.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cmb�o�ד�.ForeColor = System.Drawing.Color.LimeGreen;
			this.cmb�o�ד�.Items.AddRange(new object[] {
														"�o�ד�",
														"�o�^��"});
			this.cmb�o�ד�.Location = new System.Drawing.Point(32, 174);
			this.cmb�o�ד�.Name = "cmb�o�ד�";
			this.cmb�o�ד�.Size = new System.Drawing.Size(78, 24);
			this.cmb�o�ד�.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 432);
			this.label1.TabIndex = 44;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			this.panel7.Controls.Add(this.lab�o�׎��у^�C�g��);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(792, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab�o�׎��у^�C�g��
			// 
			this.lab�o�׎��у^�C�g��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�o�׎��у^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�o�׎��у^�C�g��.ForeColor = System.Drawing.Color.White;
			this.lab�o�׎��у^�C�g��.Location = new System.Drawing.Point(12, 2);
			this.lab�o�׎��у^�C�g��.Name = "lab�o�׎��у^�C�g��";
			this.lab�o�׎��у^�C�g��.Size = new System.Drawing.Size(264, 24);
			this.lab�o�׎��у^�C�g��.TabIndex = 0;
			this.lab�o�׎��у^�C�g��.Text = "�o�׎���";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn�b�r�u�o��);
			this.panel8.Controls.Add(this.btn���);
			this.panel8.Controls.Add(this.tex���b�Z�[�W);
			this.panel8.Controls.Add(this.btn����);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 2;
			// 
			// btn�b�r�u�o��
			// 
			this.btn�b�r�u�o��.ForeColor = System.Drawing.Color.Blue;
			this.btn�b�r�u�o��.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�b�r�u�o��.Location = new System.Drawing.Point(134, 6);
			this.btn�b�r�u�o��.Name = "btn�b�r�u�o��";
			this.btn�b�r�u�o��.Size = new System.Drawing.Size(54, 48);
			this.btn�b�r�u�o��.TabIndex = 2;
			this.btn�b�r�u�o��.Text = "�b�r�u�@�o��";
			this.btn�b�r�u�o��.Click += new System.EventHandler(this.btn�b�r�u�o��_Click);
			// 
			// btn���
			// 
			this.btn���.ForeColor = System.Drawing.Color.Blue;
			this.btn���.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn���.Location = new System.Drawing.Point(70, 6);
			this.btn���.Name = "btn���";
			this.btn���.Size = new System.Drawing.Size(54, 48);
			this.btn���.TabIndex = 1;
			this.btn���.Text = "���";
			this.btn���.Click += new System.EventHandler(this.btn���_Click);
			// 
			// tex���b�Z�[�W
			// 
			this.tex���b�Z�[�W.BackColor = System.Drawing.Color.PaleGreen;
			this.tex���b�Z�[�W.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���b�Z�[�W.ForeColor = System.Drawing.Color.Red;
			this.tex���b�Z�[�W.Location = new System.Drawing.Point(256, 4);
			this.tex���b�Z�[�W.Multiline = true;
			this.tex���b�Z�[�W.Name = "tex���b�Z�[�W";
			this.tex���b�Z�[�W.ReadOnly = true;
			this.tex���b�Z�[�W.Size = new System.Drawing.Size(376, 50);
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
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.panel1);
			this.groupBox3.Location = new System.Drawing.Point(10, 56);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(620, 440);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			// 
			// cBox�z���r�o��
			// 
			this.cBox�z���r�o��.ForeColor = System.Drawing.Color.Black;
			this.cBox�z���r�o��.Location = new System.Drawing.Point(330, 338);
			this.cBox�z���r�o��.Name = "cBox�z���r�o��";
			this.cBox�z���r�o��.Size = new System.Drawing.Size(178, 24);
			this.cBox�z���r�o��.TabIndex = 64;
			this.cBox�z���r�o��.Text = "�z�����t�E�������o�͂���";
			// 
			// �o�׎���
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(634, 582);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(640, 607);
			this.Name = "�o�׎���";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 �o�׎���";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
			this.Load += new System.EventHandler(this.�o�׎���_Load);
			this.Closed += new System.EventHandler(this.�o�׎���_Closed);
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).EndInit();
			this.panel1.ResumeLayout(false);
			this.gb�o�͌`��.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		private void btn����_Click(object sender, System.EventArgs e)
		{
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� START
			//��ʂ���鎞�ɁA�o�̓I�v�V�����̃`�F�b�N���e��ۑ�����
			�o�̓I�v�V�������ۑ�();
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� END
			this.Close();
		}

		private void �o�׎���_Load(object sender, System.EventArgs e)
		{
			cmb�o�ד�.SelectedIndex = 0;
			dt�J�n���t.Value = gdt�o�ד�;
			dt�I�����t.Value = gdt�o�ד�;
			tex���b�Z�[�W.Text = "";
// ADD 2007.02.20 ���s�j���� ���������Ɉ˗����ǉ� START
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� START
//			tex�˗���R�[�h.Text = " ";
//			tex�˗��喼.Text     = "";
//			s�˗���b�c = "";
//			s�˗��喼   = "";
//			tex�˗���R�[�h.Focus();

			cmb������.Items.Clear();
			if(gsa�����敔�ۖ� != null)
			{
				cmb������.Items.Add("");
				cmb������.Items.AddRange(gsa�����敔�ۖ�);
			}
			rb�w��Ȃ�.Checked     = true;
			�o�͌`���N���A();
			tex���q�l�ԍ��J�n.Text = "";
			tex���q�l�ԍ��I��.Text = "";

			rb�w��Ȃ�.Focus();
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� END
// ADD 2007.02.20 ���s�j���� ���������Ɉ˗����ǉ� END
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
			if(gs�I�v�V����[0].Length == 4){
				if(gs�I�v�V����[13].Equals("1")){
					rb�Q�s.Checked = true;
				}else{
					rb�W�s.Checked = true;
				}
			}
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� END
// MOD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� START
			if(rb�W�s.Checked){
				cb���͂���Z�����.Checked = false;
				cb���͂���Z�����.Enabled = false;
				cb���͂���Z�����.Visible = false;
			}
			else
			{
				cb���͂���Z�����.Enabled = true;
				cb���͂���Z�����.Visible = true;
			}
// MOD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� END
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� START
			if(gs�o�׎���_���X�o��_�b�r�u�̂� != null)
			{
				cBox���X�b�c�o��.Visible = true;
				//�`�F�b�N�{�b�N�X���p�̕ۑ����������݂���ꍇ�A�������D��
				if(gs�o�׎���_���X�o��_�b�r�u�̂� == "1")
				{
					cBox���X�b�c�o��.Checked = true;
				}
				else
				{
					cBox���X�b�c�o��.Checked = false;
				}
			}
			else
			{
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� END
// MOD 2013.04.04 TDI�j�j�V �o�̓��C�A�E�g�ǉ��i�O���[�o����p�jSTART
				if(gs����X���b�c.Equals("047"))
				{
					cBox���X�b�c�o��.Visible = true;
					cBox���X�b�c�o��.Checked = true;
				}
				else
				{
					cBox���X�b�c�o��.Visible = true;
					cBox���X�b�c�o��.Checked = false;
				}
// MOD 2013.04.04 TDI�j�j�V �o�̓��C�A�E�g�ǉ��i�O���[�o����p�jEND
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� START
			}
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� END
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� START
			if(gs�o�׎���_�z�������o�� != null)
			{
				cBox�z���r�o��.Visible = true;
				//�`�F�b�N�{�b�N�X���p�̕ۑ����������݂���ꍇ�A�������D��
				if(gs�o�׎���_�z�������o�� == "1")
				{
					cBox�z���r�o��.Checked = true;
				}
				else
				{
					cBox�z���r�o��.Checked = false;
				}
			}
			else
			{
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� END
// MOD 2013.10.07 BEVAS�j���� �z�����t�E������ǉ� START
				//�O���[�o���ڑ��̏ꍇ�͏������'ON'�ɐݒ�
				if(gs����X���b�c.Equals("047"))
				{
					cBox�z���r�o��.Visible = true;
					cBox�z���r�o��.Checked = true;
				}
				else
				{
					cBox�z���r�o��.Visible = true;
					cBox�z���r�o��.Checked = false;
				}
// MOD 2013.10.07 BEVAS�j���� �z�����t�E������ǉ� END
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� START
			}
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� END
		}

		private void �o�׎���_Closed(object sender, System.EventArgs e)
		{
			cmb�o�ד�.SelectedIndex = 0;
			dt�J�n���t.Value = gdt�o�ד�;
			dt�I�����t.Value = gdt�o�ד�;
			tex���b�Z�[�W.Text = "";
// ADD 2007.02.20 ���s�j���� ���������Ɉ˗����ǉ� START
//			cmb�o�ד�.Focus();
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� START
//			tex�˗���R�[�h.Text = " ";
//			tex�˗��喼.Text     = "";
//			s�˗���b�c = "";
//			s�˗��喼   = "";
//			tex�˗���R�[�h.Focus();
			rb�w��Ȃ�.Checked       = true;
			�o�͌`���N���A();
//			cmb������.SelectedIndex  = 0;
//			tex������R�[�h.Text     = "";
//			tex���ۃR�[�h.Text       = "";
//			tex�͂���R�[�h.Text     = "";
//			tex�͂��於.Text         = "";
			tex���q�l�ԍ��J�n.Text   = "";
			tex���q�l�ԍ��I��.Text   = "";
			rb�w��Ȃ�.Focus();
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� END
// ADD 2007.02.20 ���s�j���� ���������Ɉ˗����ǉ� END
		}

		private void btn�b�r�u�o��_Click(object sender, System.EventArgs e)
		{
			tex���b�Z�[�W.Text = "";
			if (dt�J�n���t.Value > dt�I�����t.Value)
			{
				MessageBox.Show("���t�͈̔͂����������͂���Ă��܂���","���̓`�F�b�N",MessageBoxButtons.OK );
				dt�J�n���t.Focus();
				return;
			}
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� START
//// ADD 2006.08.09 ���s�j�R�{ ���������Ɉ˗����ǉ� START
//			s�˗���b�c = tex�˗���R�[�h.Text.Trim();
//			�˗��匟��();
//// ADD 2006.08.09 ���s�j�R�{ ���������Ɉ˗����ǉ� END

			�o�͌`���N���A();
			int i�o�͌`�� = 0;
			if(rb���˗����.Checked)      i�o�͌`�� = 1;
			else if(rb�������.Checked)   i�o�͌`�� = 2;
			else if(rb���͂����.Checked) i�o�͌`�� = 3;

			// ���˗�����\��
			tex�˗���R�[�h.Text = tex�˗���R�[�h.Text.TrimEnd();
			if(tex�˗���R�[�h.Text.Length == 0){
				tex�˗��喼.Text = "";
			}else{
				if(!���p�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;

				tex���b�Z�[�W.Text = "";
				s�˗���b�c = tex�˗���R�[�h.Text;
				�˗��匟��();
			}

			// ��������\��
			s������b�c = "";
			s���ۂb�c   = "";
			tex������R�[�h.Text = "";
			if(gsa������b�c.Length > 0 && cmb������.SelectedIndex > 0){
				s������b�c = gsa������b�c[cmb������.SelectedIndex - 1];
				s���ۂb�c   = gsa�����敔�ۂb�c[cmb������.SelectedIndex - 1];
				tex������R�[�h.Text = s������b�c.TrimEnd() + " " + s���ۂb�c.TrimEnd();
			}

			// ���͂�����\��
			tex�͂���R�[�h.Text = tex�͂���R�[�h.Text.TrimEnd();
			if(tex�͂���R�[�h.Text.Length == 0){
				tex�͂��於.Text = "";
			}else{
				if(!���p�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;

				tex���b�Z�[�W.Text = "";
				s�͂���b�c = tex�͂���R�[�h.Text;
				�͂��挟��();
			}

			tex���q�l�ԍ��J�n.Text = tex���q�l�ԍ��J�n.Text.TrimEnd();
			tex���q�l�ԍ��I��.Text = tex���q�l�ԍ��I��.Text.TrimEnd();
			if(!���p�`�F�b�N(tex���q�l�ԍ��J�n,"���q�l�ԍ��i�J�n�j")) return;
			if(!���p�`�F�b�N(tex���q�l�ԍ��I��,"���q�l�ԍ��i�I���j")) return;
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� END

// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX START
//			string sSday = dt�J�n���t.Value.ToShortDateString().Replace("/","");
//			string sEday = dt�I�����t.Value.ToShortDateString().Replace("/","");
			string sSday = YYYYMMDD�ϊ�(dt�J�n���t.Value);
			string sEday = YYYYMMDD�ϊ�(dt�I�����t.Value);
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX END

			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				String[] sList;
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� START
//// MOD 2007.02.20 ���s�j���� �b�r�u�o�͂́A���o�[�W�����ɂ��� START
////// MOD 2006.07.27 ���s�j�R�{ �^���ƕی������ڂ̒ǉ� START
//////				sList = sv_syukka.Get_csvwrite(gsa���[�U,gs����b�c,gs����b�c,"", "", cmb�o�ד�.SelectedIndex, sSday, sEday, "00");
////				sList = sv_syukka.Get_csvwrite1(gsa���[�U,gs����b�c,gs����b�c,"", "", cmb�o�ד�.SelectedIndex, sSday, sEday, "00");
////// MOD 2006.07.27 ���s�j�R�{ �^���ƕی������ڂ̒ǉ� END
//// MOD 2008.07.09 ���s�j���� �����s�������O���� START
////				sList = sv_syukka.Get_csvwrite(gsa���[�U,gs����b�c,gs����b�c,"", s�˗���b�c, cmb�o�ד�.SelectedIndex, sSday, sEday, "00");
//				if(cBox�����s��������.Checked){
//					sList = sv_syukka.Get_csvwrite(gsa���[�U,gs����b�c,gs����b�c,"", s�˗���b�c, cmb�o�ד�.SelectedIndex, sSday, sEday, "aa");
//				}else{
//					sList = sv_syukka.Get_csvwrite(gsa���[�U,gs����b�c,gs����b�c,"", s�˗���b�c, cmb�o�ד�.SelectedIndex, sSday, sEday, "00");
//				}
//// MOD 2008.07.09 ���s�j���� �����s�������O���� END
				string s��� = "";
				if(cBox�����s��������.Checked){
					s��� = "aa";
				}else{
					s��� = "00";
				}

				// MOD 2013.04.04 TDI�j�j�V �o�̓��C�A�E�g�ǉ��i�O���[�o����p�jSTART
				string s���X�b�c = "";
				if(cBox���X�b�c�o��.Checked)
				{
					s���X�b�c = "1";
				}
				else
				{
					s���X�b�c = "";
				}
				// MOD 2013.04.04 TDI�j�j�V �o�̓��C�A�E�g�ǉ��i�O���[�o����p�jEND

// MOD 2013.10.07 BEVAS�j���� �z�����t�E������ǉ� START
				string s�z���r = "";
				if(cBox�z���r�o��.Checked)
				{
					s�z���r = "1";
				}
				else
				{
					s�z���r = "";
				}
// MOD 2013.10.07 BEVAS�j���� �z�����t�E������ǉ� END

				string[] sa�������� = new string[]{
								gs����b�c
								, gs����b�c
								, tex�͂���R�[�h.Text.TrimEnd()
								, tex�˗���R�[�h.Text.TrimEnd()
								, cmb�o�ד�.SelectedIndex.ToString()
								, sSday
								, sEday
								, s���
								, ""	// �����ԍ��J�n
								, ""	// �����ԍ��I��
							    , tex���q�l�ԍ��J�n.Text.TrimEnd()
							    , tex���q�l�ԍ��I��.Text.TrimEnd()
								, s������b�c.TrimEnd()
								, s���ۂb�c.TrimEnd()
								, i�o�͌`��.ToString()
// MOD 2010.02.01 ���s�j���� �I�v�V�����̍��ڒǉ��i�b�r�u�o�͌`���jSTART
								, gs�I�v�V����[17]
// MOD 2010.02.01 ���s�j���� �I�v�V�����̍��ڒǉ��i�b�r�u�o�͌`���jEND
// MOD 2013.04.04 TDI�j�j�V �o�̓��C�A�E�g�ǉ��i�O���[�o����p�jSTART
								, s���X�b�c
// MOD 2013.04.04 TDI�j�j�V �o�̓��C�A�E�g�ǉ��i�O���[�o����p�jEND
// MOD 2013.10.07 BEVAS�j���� �z�����t�E������ǉ� START
								, s�z���r
// MOD 2013.10.07 BEVAS�j���� �z�����t�E������ǉ� END
				};
				sList = sv_syukka.Get_csvwrite2(gsa���[�U, sa��������);
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� END
// MOD 2007.02.20 ���s�j���� �b�r�u�o�͂́A���o�[�W�����ɂ��� END
				this.Cursor = System.Windows.Forms.Cursors.Default;

				if(sList[0].Length == 4)
				{
// MOD 2010.02.01 ���s�j���� �I�v�V�����̍��ڒǉ��i�b�r�u�o�͌`���jSTART
					if(gs�I�v�V����[17].Equals("1")){
						//�b�r�u�G���g���[�`��
						sList[0] = ""
							+ "\"�׎�l�R�[�h\",\"�d�b�ԍ�\","
							+ "\"�Z��\",\"�Z���Q\",\"�Z���R\","
							+ "\"���O\",\"���O�Q\","
							+ "\"�X�֔ԍ�\",\"����v\",\"���X�R�[�h\","
							+ "\"�ב��l�R�[�h\","
							+ "\"��\",\"�ː�\",\"�d��\","
							+ "\"�A�����i�P\",\"�A�����i�Q\","
							+ "\"�i���L���P\",\"�i���L���Q\",\"�i���L���R\","
							+ "\"�z�B�w���\",\"���q�l�Ǘ��ԍ�\","
							+ "\"�\��\","
							+ "\"�����敪\",\"�ی����z\","
							+ "\"�o�ד��t\",\"�o�^���t\""
							;
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
					}else if(gs�I�v�V����[17].Equals("2")){
						//�W���`���Q
						sList[0] = "\"�o�^��\",\"�o�ד�\",\"�����ԍ�\","
							+ "\"�׎�l�R�[�h\",\"�׎�l�X�֔ԍ�\",\"�׎�l�d�b�ԍ�\","
							+ "\"�׎�l�Z���P\",\"�׎�l�Z���Q\",\"�׎�l�Z���R\","
							+ "\"�׎�l���O�P\",\"�׎�l���O�Q\",\"����v\",\"���X�R�[�h\",\"���X��\","
							+ "\"�ב��l�R�[�h\",\"�ב��l�X�֔ԍ�\",\"�ב��l�d�b�ԍ�\","
							+ "\"�ב��l�Z���P\",\"�ב��l�Z���Q\","
							+ "\"�ב��l���O�P\",\"�ב��l���O�Q\","
							+ "\"��\",\"�d��\","
							+ "\"�w���\",\"�A�����i�P\",\"�A�����i�Q\","
							+ "\"�i���L���P\",\"�i���L���Q\",\"�i���L���R\","
							+ "\"�i���L���S\",\"�i���L���T\",\"�i���L���U\","
							+ "\"�����敪\","
							+ "\"�ی����z\",\"���q�l�Ǘ��ԍ�\","
							+ "\"������R�[�h\",\"�����敔�ۏ��R�[�h\""
							;
					}else if(gs�I�v�V����[17].Equals("3")){
						//�b�r�u�G���g���[�`���Q
						sList[0] = ""
							+ "\"�׎�l�R�[�h\",\"�d�b�ԍ�\","
							+ "\"�Z��\",\"�Z���Q\",\"�Z���R\","
							+ "\"���O\",\"���O�Q\","
							+ "\"�X�֔ԍ�\",\"����v\",\"���X�R�[�h\","
							+ "\"�ב��l�R�[�h\","
							+ "\"�ב��l�S����\","
							+ "\"��\",\"�ː�\",\"�d��\","
							+ "\"�A�����i�P\",\"�A�����i�Q\","
							+ "\"�i���L���P\",\"�i���L���Q\",\"�i���L���R\","
							+ "\"�i���L���S\",\"�i���L���T\",\"�i���L���U\","
							+ "\"�z�B�w���\",\"�K���敪\","
							+ "\"���q�l�Ǘ��ԍ�\","
							+ "\"�����敪\",\"�ی����z\","
							+ "\"�o�ד��t\",\"�o�^���t\""
							;
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
					}else{
// MOD 2010.02.01 ���s�j���� �I�v�V�����̍��ڒǉ��i�b�r�u�o�͌`���jEND
						sList[0] = "\"�o�^��\",\"�o�ד�\",\"�����ԍ�\","
							+ "\"�׎�l�R�[�h\",\"�׎�l�X�֔ԍ�\",\"�׎�l�d�b�ԍ�\","
							+ "\"�׎�l�Z���P\",\"�׎�l�Z���Q\",\"�׎�l�Z���R\","
							+ "\"�׎�l���O�P\",\"�׎�l���O�Q\",\"����v\",\"���X�R�[�h\",\"���X��\","
							+ "\"�ב��l�R�[�h\",\"�ב��l�X�֔ԍ�\",\"�ב��l�d�b�ԍ�\","
							+ "\"�ב��l�Z���P\",\"�ב��l�Z���Q\","
							+ "\"�ב��l���O�P\",\"�ב��l���O�Q\","
							+ "\"��\",\"�d��\","
							+ "\"�w���\",\"�A�����i�P\",\"�A�����i�Q\","
							+ "\"�i���L���P\",\"�i���L���Q\",\"�i���L���R\",\"�����敪\","
							+ "\"�ی����z\",\"���q�l�Ǘ��ԍ�\","
// MOD 2007.02.20 ���s�j���� �b�r�u�o�͂́A���o�[�W�����ɂ��� START
// MOD 2006.07.27 ���s�j�R�{ �^���ƕی������ڂ̒ǉ� START
							+ "\"������R�[�h\",\"�����敔�ۏ��R�[�h\"";
//							+ "\"������R�[�h\",\"�����敔�ۏ��R�[�h\","
//							+ "\"�^��\"";
// MOD 2006.07.27 ���s�j�R�{ �^���ƕی������ڂ̒ǉ� END
// MOD 2007.02.20 ���s�j���� �b�r�u�o�͂́A���o�[�W�����ɂ��� END
// MOD 2010.02.01 ���s�j���� �I�v�V�����̍��ڒǉ��i�b�r�u�o�͌`���jSTART
					}
// MOD 2010.02.01 ���s�j���� �I�v�V�����̍��ڒǉ��i�b�r�u�o�͌`���jEND
// MOD 2013.04.04 TDI�j�j�V �o�̓��C�A�E�g�ǉ��i�O���[�o����p�jSTART
					if(s���X�b�c.Equals("1"))
					{
						sList[0] += ",\"���X�R�[�h\",\"���X��\"";
					}
// MOD 2013.04.04 TDI�j�j�V �o�̓��C�A�E�g�ǉ��i�O���[�o����p�jEND
// MOD 2013.10.07 BEVAS�j���� �z�����t�E������ǉ� START
					if(s�z���r.Equals("1"))
					{
						sList[0] += ",\"�z�����t�E����\"";
					}
// MOD 2013.10.07 BEVAS�j���� �z�����t�E������ǉ� END

					// �f�t�H���g�̃t�H���_���f�X�N�g�b�v�t�H���_�ɂ���
					saveFileDialog1.InitialDirectory
						= Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
					saveFileDialog1.Filter = "�b�r�u�t�@�C�� (*.csv)|*.csv";
					byte[] bSJIS;
					if(saveFileDialog1.ShowDialog(this) == DialogResult.OK)
					{
						System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
						for(int iCnt = 0; iCnt < sList.Length; iCnt++)
						{
							bSJIS = toSJIS(sList[iCnt]);
							fs.Write(bSJIS, 0 , bSJIS.Length);
						}
						fs.Close();
						tex���b�Z�[�W.Text = "";
					}
				}
				else
				{
					if(sList[0].Equals("�Y���f�[�^������܂���"))
					{
						tex���b�Z�[�W.Text = "";
						�r�[�v��();
						MessageBox.Show("�Y���f�[�^������܂���","�o�׎���",MessageBoxButtons.OK);
					}
					else
					{
						�r�[�v��();
						tex���b�Z�[�W.Text = sList[0];
					}
				}
			}
// ADD 2005.07.04 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
				tex���b�Z�[�W.Text = gs�ʐM�G���[;
			}
// ADD 2005.07.04 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch(Exception ex)
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
				tex���b�Z�[�W.Text = ex.Message;
			}
		}

		private void btn���_Click(object sender, System.EventArgs e)
		{
			string s�o�ד�   = "";
// MOD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� START
//			string s���t�ێ� = "";
			string s���v�L�[ = "";
			string s���v�L�[�ێ� = "";
// MOD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� EDD
			string s�K��     = "";

			int i��  = 0;
			int i�ː�  = 0;
			int i�d��  = 0;
			int i�ی�  = 0;
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� START
			int i�ː��d�� = 0;
			string s�^���ː� = "";
			string s�^���d�� = "";
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� END

			int i�������v = 0;
			int i�����v = 0;
			int i�d�ʏ��v = 0;
			int i�ی����v = 0;
// ADD 2006.08.08 ���s�j�R�{ ������ڂɉ^����ǉ� START
			int i�^��  = 0;
			int i�^�����v = 0;
// ADD 2006.08.08 ���s�j�R�{ ������ڂɉ^����ǉ� END
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� START
//// ADD 2006.08.09 ���s�j�R�{ ���������Ɉ˗����ǉ� START
//			s�˗���b�c = tex�˗���R�[�h.Text.Trim();
//			�˗��匟��();
//// ADD 2006.08.09 ���s�j�R�{ ���������Ɉ˗����ǉ� END

			tex���b�Z�[�W.Text = "";
			�o�͌`���N���A();
			int i�o�͌`�� = 0;
			if(rb���˗����.Checked)      i�o�͌`�� = 1;
			else if(rb�������.Checked)   i�o�͌`�� = 2;
			else if(rb���͂����.Checked) i�o�͌`�� = 3;

			// ���˗�����\��
			tex�˗���R�[�h.Text = tex�˗���R�[�h.Text.TrimEnd();
			if(tex�˗���R�[�h.Text.Length == 0){
				tex�˗��喼.Text = "";
			}else{
				if(!���p�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;

				tex���b�Z�[�W.Text = "";
				s�˗���b�c = tex�˗���R�[�h.Text;
				�˗��匟��();
			}

			// ��������\��
			s������b�c = "";
			s���ۂb�c   = "";
			tex������R�[�h.Text = "";
			if(gsa������b�c.Length > 0 && cmb������.SelectedIndex > 0){
				s������b�c = gsa������b�c[cmb������.SelectedIndex - 1];
				s���ۂb�c   = gsa�����敔�ۂb�c[cmb������.SelectedIndex - 1];
				tex������R�[�h.Text = s������b�c.TrimEnd() + " " + s���ۂb�c.TrimEnd();
			}

			// ���͂�����\��
			tex�͂���R�[�h.Text = tex�͂���R�[�h.Text.TrimEnd();
			if(tex�͂���R�[�h.Text.Length == 0){
				tex�͂��於.Text = "";
			}else{
				if(!���p�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;

				tex���b�Z�[�W.Text = "";
				s�͂���b�c = tex�͂���R�[�h.Text;
				�͂��挟��();
			}
			tex���q�l�ԍ��J�n.Text = tex���q�l�ԍ��J�n.Text.TrimEnd();
			tex���q�l�ԍ��I��.Text = tex���q�l�ԍ��I��.Text.TrimEnd();
			if(!���p�`�F�b�N(tex���q�l�ԍ��J�n,"���q�l�ԍ��i�J�n�j")) return;
			if(!���p�`�F�b�N(tex���q�l�ԍ��I��,"���q�l�ԍ��i�I���j")) return;
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� END
			if (dt�J�n���t.Value > dt�I�����t.Value)
			{
				MessageBox.Show("���t�͈̔͂����������͂���Ă��܂���","���̓`�F�b�N",MessageBoxButtons.OK );
				dt�J�n���t.Focus();
				return;
			}

			tex���b�Z�[�W.Text = "�o�׎��шꗗ������D�D�D";
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				if(sv_print == null) sv_print = new is2print.Service1();

// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX START
//				string sSday = dt�J�n���t.Value.ToShortDateString().Replace("/","");
//				string sEday = dt�I�����t.Value.ToShortDateString().Replace("/","");
				string sSday = YYYYMMDD�ϊ�(dt�J�n���t.Value);
				string sEday = YYYYMMDD�ϊ�(dt�I�����t.Value);
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX END

				string[] sRet = new string[1];
// MOD 2006.08.03 ���s�j�R�{ ������ڂɉ^����ǉ� START
//				IEnumerator iEnum = sv_print.Get_PublishedPrintData(gsa���[�U,gs����b�c,gs����b�c,cmb�o�ד�.SelectedIndex, sSday, sEday).GetEnumerator();
// MOD 2008.07.09 ���s�j���� �����s�������O���� START
//				IEnumerator iEnum = sv_print.Get_PublishedPrintData2(gsa���[�U,gs����b�c,gs����b�c,cmb�o�ד�.SelectedIndex, sSday, sEday,s�˗���b�c).GetEnumerator();
				IEnumerator iEnum = null;
// MOD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� START
//				if(cBox�����s��������.Checked){
//					iEnum = sv_print.Get_PublishedPrintData3(gsa���[�U,gs����b�c,gs����b�c,cmb�o�ד�.SelectedIndex, sSday, sEday,s�˗���b�c,"aa").GetEnumerator();
//				}else{
//					iEnum = sv_print.Get_PublishedPrintData3(gsa���[�U,gs����b�c,gs����b�c,cmb�o�ד�.SelectedIndex, sSday, sEday,s�˗���b�c,"00").GetEnumerator();
//				}
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� START
//				int iSyuka = cmb�o�ד�.SelectedIndex;
//				if(rb�Q�s.Checked){
//					iSyuka += 2;
//// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
//					if(gs�I�v�V����[0].Length == 4){
//						if(gs�I�v�V����[14].Equals("1")){
//							iSyuka = cmb�o�ד�.SelectedIndex;
//						}
//					}
//// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� END
//				}
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� END
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� START
//				if(cBox�����s��������.Checked){
//					iEnum = sv_print.Get_PublishedPrintData3(gsa���[�U,gs����b�c,gs����b�c,iSyuka, sSday, sEday,s�˗���b�c,"aa").GetEnumerator();
//				}else{
//					iEnum = sv_print.Get_PublishedPrintData3(gsa���[�U,gs����b�c,gs����b�c,iSyuka, sSday, sEday,s�˗���b�c,"00").GetEnumerator();
//				}
				string s��� = "";
				if(cBox�����s��������.Checked){
					s��� = "aa";
				}else{
					s��� = "00";
				}
				string[] sa�������� = new string[]{
								gs����b�c
								, gs����b�c
								, tex�͂���R�[�h.Text.TrimEnd()
								, tex�˗���R�[�h.Text.TrimEnd()
								, cmb�o�ד�.SelectedIndex.ToString()
								, sSday
								, sEday
								, s���
								, ""	// �����ԍ��J�n
								, ""	// �����ԍ��I��
							    , tex���q�l�ԍ��J�n.Text.TrimEnd()
							    , tex���q�l�ԍ��I��.Text.TrimEnd()
								, s������b�c.TrimEnd()
								, s���ۂb�c.TrimEnd()
								, i�o�͌`��.ToString()
				};
				iEnum = sv_print.Get_PublishedPrintData4(gsa���[�U, sa��������).GetEnumerator();
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� END
// MOD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� END
// MOD 2008.07.09 ���s�j���� �����s�������O���� END
// MOD 2006.08.03 ���s�j�R�{ ������ڂɉ^����ǉ� END
				iEnum.MoveNext();
				sRet = (string[])iEnum.Current;
				if (sRet[0].Equals("����I��"))
				{
					�o�׎��уf�[�^ ds = new �o�׎��уf�[�^();

					int iCnt = 1;
					//�f�[�^�Z�b�g�ɒl���Z�b�g
					while (iEnum.MoveNext())
					{
						string[] sList = new string[40];
						sList = (string[])iEnum.Current;
					
						�o�׎��уf�[�^.table�o�׎���Row tr = (�o�׎��уf�[�^.table�o�׎���Row)ds.table�o�׎���.NewRow();
						tr.BeginEdit();

						if(cmb�o�ד�.SelectedIndex == 0)
							s�o�ד�   = sList[1].Trim();
						else
							s�o�ד�   = sList[0].Trim();

// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� START
//// MOD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� START
////						if((s���t�ێ� != "") && (s���t�ێ� != s�o�ד�))
//						if(rb�Q�s.Checked){
//							s���v�L�[ = s�o�ד� + sList[15];	//[�o�ד�]+[�ב��l�b�c]
//// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
//							if(gs�I�v�V����[0].Length == 4){
//								if(gs�I�v�V����[14].Equals("1")){
//									s���v�L�[ = s�o�ד�;
//								}
//							}
//// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� END
//						}else{
//							s���v�L�[ = s�o�ד�;
//						}
						switch(i�o�͌`��){
						case 1:		// ���˗����
							s���v�L�[ = s�o�ד� + sList[15];
							break;
						case 2:		// �������
							s���v�L�[ = s�o�ד� + sList[39] + sList[40];
							break;
						case 3:		// ���͂����
							s���v�L�[ = s�o�ד� + sList[3];
							break;
						default:
							s���v�L�[ = s�o�ד�;
							break;
						}
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� START
						if((s���v�L�[�ێ� != "") && (s���v�L�[�ێ� != s���v�L�[))
// MOD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� END
						{
// MOD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� START
//							s���t�ێ� = s�o�ד�;
							s���v�L�[�ێ� = s���v�L�[;
// MOD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� END
							tr.���v�t���O = 1;
							iCnt = 1;
							tr.�������v  = i�������v;
							tr.�����v  = i�����v;
							tr.�d�ʏ��v  = i�d�ʏ��v;
							tr.�ی����v  = i�ی����v;
// ADD 2006.08.08 ���s�j�R�{ ������ڂɉ^����ǉ� START
							tr.�^�����v  = i�^�����v;
// ADD 2006.08.08 ���s�j�R�{ ������ڂɉ^����ǉ� END
							i�������v = 1;
							i�����v = 0;
							i�d�ʏ��v = 0;
							i�ی����v = 0;
// ADD 2006.08.08 ���s�j�R�{ ������ڂɉ^����ǉ� START
							i�^�����v = 0;
// ADD 2006.08.08 ���s�j�R�{ ������ڂɉ^����ǉ� END
						}
						else
						{
// MOD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� START
//							if(s���t�ێ� == "")
//								s���t�ێ� = s�o�ד�;
							if(s���v�L�[�ێ� == "")
								s���v�L�[�ێ� = s���v�L�[;
// MOD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� END
							tr.���v�t���O = 0;
							i�������v++;
						}
// MOD 2008.07.25 ���s�j���� �Ԋ|�����͂��� START
//						tr.�ԍ� = iCnt++;
						if(cBox�Ԋ|���Ȃ�.Checked){
							tr.�ԍ� = -1;
						}else{
							tr.�ԍ� = iCnt++;
						}
// MOD 2008.07.25 ���s�j���� �Ԋ|�����͂��� END
						if(cmb�o�ד�.SelectedIndex == 0)
						{
							tr.�o�^��        = sList[0].Substring(4,2) + "/" + sList[0].Substring(6,2);
							tr.�o�ד�        = "�o�ד� " + sList[1].Substring(2,2) + "�N" + sList[1].Substring(4,2) + "��" + sList[1].Substring(6,2) + "��";
							tr.���t�^�C�g��  = "�o�^��";
						}
						else
						{
							tr.�o�ד�        = "�o�^�� " + sList[0].Substring(2,2) + "�N" + sList[0].Substring(4,2) + "��" + sList[0].Substring(6,2) + "��";
							tr.�o�^��        = sList[1].Substring(4,2) + "/" + sList[1].Substring(6,2);
							tr.���t�^�C�g��  = "�o�ד�";
						}

						if(sList[2].Trim().Length == 0)
							tr.�����ԍ�  = sList[2].Trim();
						else
							tr.�����ԍ�  = sList[2].Substring(4,3) + "-" + sList[2].Substring(7,4) + "-" + sList[2].Substring(11,4);

						tr.�׎�l�R�[�h  = sList[3].Trim();
						tr.�׎�l�X�֔ԍ�   = sList[4].Substring(0,3) + "-" + sList[4].Substring(3,4);
						if(sList[5].Trim().Length == 0)
							tr.�׎�l�d�b�ԍ� = sList[6].Trim() + "-" + sList[7].Trim();
						else
							tr.�׎�l�d�b�ԍ� = "(" + sList[5].Trim() + ")" + sList[6].Trim() + "-" + sList[7].Trim();
						tr.�׎�l�Z���P     = sList[8].Trim() + sList[9].Trim();
						tr.�׎�l�Z���Q     = sList[10].Trim();
						tr.�׎�l���O�P     = sList[11].Trim() + "  " + sList[12].Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
///						if(gs�I�v�V����[18].Equals("1")){
							tr.�׎�l�Z���P     = sList[8].TrimEnd() + sList[9].TrimEnd();
							tr.�׎�l�Z���Q     = sList[10].TrimEnd();
							tr.�׎�l���O�P     = sList[11].TrimEnd() + "  " + sList[12].TrimEnd();
///						}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
// ADD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� START
						//�p�^�[���P�̏ꍇ�ɂ́A�i���O�P�A���O�Q�j
						if(rb�Q�s.Checked){
							tr.�׎�l�Z���P = "";
							tr.�׎�l���O�P = sList[11].Trim() + "  " + sList[12].Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
///							if(gs�I�v�V����[18].Equals("1")){
								tr.�׎�l���O�P = sList[11].TrimEnd() + "  " + sList[12].TrimEnd();
///							}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
							//�p�^�[���Q�̏ꍇ�ɂ́A�i���O�P�A�Z���P�j
							if(cb���͂���Z�����.Checked){
								tr.�׎�l�Z���P = sList[8].Trim();
								tr.�׎�l���O�P = sList[11].Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
///								if(gs�I�v�V����[18].Equals("1")){
									tr.�׎�l�Z���P = sList[8].TrimEnd();
									tr.�׎�l���O�P = sList[11].TrimEnd();
///								}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
// MOD 2015.10.21 BEVAS�j���{ �x�X�~�ߏo�ׂ̏ꍇ�A���͂���Z���̕\�L��ύX START
								if(tr.�׎�l�Z���P.Equals("�����x�X�~�߁���"))
								{
									if(sList[9].Trim().Substring(0, 2) == "���q")
									{
										tr.�׎�l�Z���P = "���q�^���@" + sList[9].Trim();
									}
									else
									{
										tr.�׎�l�Z���P = "���R�ʉ^�@" + sList[9].Trim();
									}
								}
// MOD 2015.10.21 BEVAS�j���{ �x�X�~�ߏo�ׂ̏ꍇ�A���͂���Z���̕\�L��ύX END
							}
						}
// ADD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� END

						tr.���X�R�[�h  = sList[13].Trim();
						tr.���X��   = sList[14].Trim();

						tr.�ב��l�R�[�h   = sList[15].Trim();
// MOD 2005.11.08 ���s�j�ɉ� �X�֔ԍ�NULL�Ή� START
//						tr.�ב��l�X�֔ԍ�   = sList[16].Substring(0,3) + "-" + sList[16].Substring(3,4);
						if(sList[16].Trim().Length != 0)
							tr.�ב��l�X�֔ԍ�   = sList[16].Substring(0,3) + "-" + sList[16].Substring(3,4);
// MOD 2005.11.08 ���s�j�ɉ� �X�֔ԍ�NULL�Ή� END
						if(sList[17].Trim().Length == 0)
							tr.�ב��l�d�b�ԍ� = sList[18].Trim() + "-" + sList[19].Trim();
						else
							tr.�ב��l�d�b�ԍ� = "(" + sList[17].Trim() + ")" + sList[18].Trim() + "-" + sList[19].Trim();
						tr.�ב��l�Z���P     = sList[20].Trim() + sList[21].Trim();
						tr.�ב��l���O�P     = sList[22].Trim() + "  " + sList[23].Trim();
						tr.�S��     = sList[24].Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
///						if(gs�I�v�V����[18].Equals("1")){
							tr.�ב��l�Z���P     = sList[20].TrimEnd() + sList[21].TrimEnd();
							tr.�ב��l���O�P     = sList[22].TrimEnd() + "  " + sList[23].TrimEnd();
							tr.�S��     = sList[24].TrimEnd();
///						}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END

						i�� = int.Parse(sList[25].Trim());
						i�����v    = i�����v + i��;
						tr.��         = sList[25].Trim();

// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� START
						i�d�� = 0;
						i�ː� = 0;
						i�ː��d�� = 0;
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� END
// MOD 2005.09.02 ���s�j�����J �����_�Ή� START
//						i�d�� = int.Parse(sList[26].Trim());
//						i�ː� = int.Parse(sList[36].Trim());
						i�d�� = (int)(double.Parse(sList[26].Trim()) + 0.5);
						i�ː� = (int)(double.Parse(sList[36].Trim()) + 0.5);
// MOD 2005.09.02 ���s�j�����J �����_�Ή� END
						i�ː� = i�ː� * 8;
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� START
//						if(i�ː� == 0)
//						{
//							i�d�ʏ��v    = i�d�ʏ��v + i�d��;
//							tr.�d��         = i�d��.ToString("#,##0");
//						}
//						else
//						{
//							i�d�ʏ��v    = i�d�ʏ��v + i�ː�;
//							tr.�d��         = i�ː�.ToString("#,##0");
//						}
						i�ː��d�� = i�d�� + i�ː�;
						tr.�d��   = i�ː��d��.ToString("#,##0");
						if(i�ː��d�� == 0){
							// �^���ː��A�^���d�ʂ����ݒ�̏ꍇ�͋�
							s�^���ː� = sList[42].TrimEnd();
							s�^���d�� = sList[43].TrimEnd();
							if(s�^���ː�.Length == 0 && s�^���d��.Length == 0){
								tr.�d�� = "";
							}
						}
						i�d�ʏ��v += i�ː��d��;
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� END

						if(sList[37].Trim() == "0")
							s�K�� = "�K��";
						else
							s�K�� = "�w��";

						if(sList[27].Trim().Length == 1)
							tr.�w���       = "";
						else
							tr.�w���       = sList[27].Substring(4,2) + "/" + sList[27].Substring(6,2) + s�K��;

// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//						tr.�A���w���P   = sList[28].Trim();
//						tr.�A���w���Q   = sList[29].Trim();
//						tr.�i���L���P   = sList[30].Trim();
//						tr.�i���L���Q   = sList[31].Trim();
//						tr.�i���L���R   = sList[32].Trim();
						tr.�A���w���P   = sList[28].TrimEnd();
						tr.�A���w���Q   = sList[29].TrimEnd();
						tr.�i���L���P   = sList[30].TrimEnd();
						tr.�i���L���Q   = sList[31].TrimEnd();
						tr.�i���L���R   = sList[32].TrimEnd();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
						if(sList.Length > 44){
							tr.�i���L���S = sList[44].TrimEnd();
							tr.�i���L���T = sList[45].TrimEnd();
							tr.�i���L���U = sList[46].TrimEnd();
						}else{
							tr.�i���L���S = "";
							tr.�i���L���T = "";
							tr.�i���L���U = "";
						}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END

						if(sList[33].Trim() == "1")
							tr.�����敪     = "����";
						else
						{
							if(sList[33].Trim() == "2")
								tr.�����敪     = "����";
							else
								tr.�����敪     = sList[33].Trim();
						}

						i�ی�       = int.Parse(sList[34].Trim());
						i�ی����v       = i�ی����v + i�ی�;
						tr.�ی����z     = i�ی�.ToString("#,##0");

						tr.���q�l�ԍ�   = sList[35].Trim();

// ADD 2006.08.03 ���s�j�R�{ ������ڂɉ^����ǉ� START
						i�^��       = int.Parse(sList[38].Trim());
						i�^�����v       = i�^�����v + i�^��;
// MDD 2008.06.12 ���s�j���� �^�����O�̏ꍇ[��]�\�� START
//						tr.�^��     = i�^��.ToString("#,##0");
						if(i�^�� == 0){
							tr.�^�� = "*";
						}else{
							tr.�^�� = i�^��.ToString("#,##0");
						}
// MDD 2008.06.12 ���s�j���� �^�����O�̏ꍇ[��]�\�� END
// ADD 2006.08.03 ���s�j�R�{ ������ڂɉ^����ǉ� END
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� START
						switch(i�o�͌`��){
						case 1:		// ���˗����
							tr.�w�b�_�P����   = "�@���˗���" + " "
											  + sList[15].Trim() + " "
											  + sList[22].Trim() + " " + sList[23].Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
///							if(gs�I�v�V����[18].Equals("1")){
								tr.�w�b�_�P����   = "�@���˗���" + " "
												  + sList[15].Trim() + " "
												  + sList[22].TrimEnd() + " " + sList[23].TrimEnd();
///							}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
							break;
						case 2:		// �������
							tr.�w�b�_�P����   = "�@������" + " "
											  + sList[39].Trim() + " " + sList[40].Trim() + " "
											  + sList[41].Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
///							if(gs�I�v�V����[18].Equals("1")){
								tr.�w�b�_�P����   = "�@������" + " "
												  + sList[39].Trim() + " " + sList[40].Trim() + " "
												  + sList[41].TrimEnd();
///							}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
							break;
						case 3:		// ���͂����
							tr.�w�b�_�P����   = "";
							break;
						default:
							tr.�w�b�_�P����   = "";
							break;
						}
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� END
// MOD 2010.02.28 ���s�j���� ���q�^���̑Ή� START
						if(gs����b�c.Substring(0,1) != "J"){
							tr.���q�^��FLG = "0";
						}else{
							tr.���q�^��FLG = "1";
						}
// MOD 2010.02.28 ���s�j���� ���q�^���̑Ή� START
// MOD 2013.10.07 BEVAS�j���� �z�����t�E������ǉ� START
						if(cBox�z���r�o��.Checked)
						{
							tr.�z���������� = "�z�����t�E����";
							if(sList[47].Trim() != ""){
								tr.�z������ = "20" + sList[47].Substring(0,2) + "/" + sList[47].Substring(2,2) + "/" + sList[47].Substring(4,2)
									+ " " + sList[47].Substring(6,2) + ":" + sList[47].Substring(8,2);
							}else{
								if(rb�W�s.Checked)
								{
									tr.�z���������� = "";
								}
								tr.�z������ = "";
							}
						}
						else
						{
							tr.�z���������� = "";
							tr.�z������ = "";
						}
// MOD 2013.10.07 BEVAS�j���� �z�����t�E������ǉ� END

						tr.EndEdit();

						ds.table�o�׎���.Rows.Add(tr);
					}
					�o�׎��уf�[�^.table�o�׎���Row tr2 = (�o�׎��уf�[�^.table�o�׎���Row)ds.table�o�׎���.NewRow();
					tr2.���v�t���O = 2;
					tr2.�ԍ� = 1;
					tr2.�������v = i�������v;
					tr2.�����v = i�����v;
					tr2.�d�ʏ��v = i�d�ʏ��v;
					tr2.�ی����v = i�ی����v;
// ADD 2006.08.08 ���s�j�R�{ ������ڂɉ^����ǉ� START
					tr2.�^�����v = i�^�����v;
// ADD 2006.08.08 ���s�j�R�{ ������ڂɉ^����ǉ� END
					ds.table�o�׎���.Rows.Add(tr2);
					
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
//					�o�׎��ђ��[ cr = new �o�׎��ђ��[();
//// ADD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� START
//					�o�׎��ђ��[�Q cr2 = new �o�׎��ђ��[�Q();
//					if(rb�Q�s.Checked){
//						//CrystalReport�Ƀp�����[�^�ƃf�[�^�Z�b�g��n��
//						cr2.SetParameterValue("����b�c", gs����b�c);
//						cr2.SetParameterValue("���喼",   gs���喼);
//// MOD 2009.04.06 ���s�j���� [���˗���󎚂Ȃ�]�A[�^���󎚂Ȃ�]�̋@�\�̒ǉ� START
//						cr2.SetParameterValue("���˗���󎚂Ȃ�"
//											, cBox���˗���󎚂Ȃ�.Checked);
//						cr2.SetParameterValue("�^���󎚂Ȃ�"
//											, cBox�^���󎚂Ȃ�.Checked);
//// MOD 2009.04.06 ���s�j���� [���˗���󎚂Ȃ�]�A[�^���󎚂Ȃ�]�̋@�\�̒ǉ� END
//						cr2.SetDataSource(ds);
//					}else{
//// ADD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� END
//						//CrystalReport�Ƀp�����[�^�ƃf�[�^�Z�b�g��n��
//						cr.SetParameterValue("����b�c", gs����b�c);
//						cr.SetParameterValue("���喼",   gs���喼);
//// MOD 2009.04.06 ���s�j���� [���˗���󎚂Ȃ�]�A[�^���󎚂Ȃ�]�̋@�\�̒ǉ� START
//						cr.SetParameterValue("���˗���󎚂Ȃ�"
//											, cBox���˗���󎚂Ȃ�.Checked);
//						cr.SetParameterValue("�^���󎚂Ȃ�"
//											, cBox�^���󎚂Ȃ�.Checked);
//// MOD 2009.04.06 ���s�j���� [���˗���󎚂Ȃ�]�A[�^���󎚂Ȃ�]�̋@�\�̒ǉ� END
//						cr.SetDataSource(ds);
//// ADD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� START
//					}
//// ADD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� END
					ReportClass cr = new �o�׎��ђ��[();
					if(rb�Q�s.Checked){
						cr = new �o�׎��ђ��[�Q();
//						if(gs�I�v�V����[0].Length == 4){
//							if(gs�I�v�V����[14].Equals("1")){
//								cr = new �o�׎��ђ��[�R();
//							}
//						}
					}
					//CrystalReport�Ƀp�����[�^�ƃf�[�^�Z�b�g��n��
					cr.SetParameterValue("����b�c", gs����b�c);
					cr.SetParameterValue("���喼",   gs���喼);
					cr.SetParameterValue("���˗���󎚂Ȃ�"
										, cBox���˗���󎚂Ȃ�.Checked);
					cr.SetParameterValue("�^���󎚂Ȃ�"
										, cBox�^���󎚂Ȃ�.Checked);
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� END
					cr.SetParameterValue("�Ж�����", false);
					if(gs�I�v�V����[0].Length == 4){
						if(gs�I�v�V����[16].Equals("1")){
							cr.SetParameterValue("�Ж�����", true);
						}
					}
					switch(i�o�͌`��){
					case 1:		// ���˗����
						cr.SetParameterValue("�T�u�^�C�g��", "�i���˗���ʁj");
						break;
					case 2:		// �������
						cr.SetParameterValue("�T�u�^�C�g��", "�i������ʁj");
						break;
					case 3:		// ���͂����
						cr.SetParameterValue("�T�u�^�C�g��", "�i���͂���ʁj");
						break;
					default:
						cr.SetParameterValue("�T�u�^�C�g��", "");
						break;
					}
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� END
					cr.SetDataSource(ds);
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� END

					//�v���r���[�\��
					�v���r���[��� ��� = new �v���r���[���();
					���.Left = this.Left;
					���.Top = this.Top;
					���.crv���[.PrintReport();
// ADD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� START
					���.crv���[.ReportSource = cr;
//					if(rb�Q�s.Checked){
//						���.crv���[.ReportSource = cr2;
//					}else{
//						���.crv���[.ReportSource = cr;
//					}
// ADD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� END
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
					if(sRet[0].Equals("�Y���f�[�^������܂���"))
					{
						tex���b�Z�[�W.Text = "";
						�r�[�v��();
						MessageBox.Show("�Y���f�[�^������܂���","�o�׎���",MessageBoxButtons.OK);
					}
					else
					{
						tex���b�Z�[�W.Text = sRet[0];
						�r�[�v��();
					}
				}
			}
// ADD 2005.07.04 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				tex���b�Z�[�W.Text = gs�ʐM�G���[;
				�r�[�v��();
			}
// ADD 2005.07.04 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				tex���b�Z�[�W.Text = ex.Message;
				�r�[�v��();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

// ADD 2006.08.09 ���s�j�R�{ ���������Ɉ˗����ǉ� START
		private void btn�˗��匟��_Click(object sender, System.EventArgs e)
		{
//			tex�˗���R�[�h.Text = tex�˗���R�[�h.Text.Trim();
//			if(!���p�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;

			if (g�˗����� == null)	 g�˗����� = new ���˗��匟��();
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� START
//			g�˗�����.Left = this.Left - 203;
//			g�˗�����.Top = this.Top  - 116;
			g�˗�����.Left = this.Left;
			g�˗�����.Top  = this.Top;
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� END

			g�˗�����.sIcode = "";
			g�˗�����.ShowDialog();

			s�˗���b�c = g�˗�����.sIcode;
			s�˗��喼   = g�˗�����.sIname;
			if(s�˗���b�c.Length > 0)
			{
				tex�˗���R�[�h.Text = s�˗���b�c;
				tex�˗��喼.Text     = s�˗��喼;
				cmb�o�ד�.Focus();
			}
			else
				tex�˗���R�[�h.Focus();
		}

		private void tex�˗���R�[�h_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				//				btn�˗��匟��.Focus();
				// ���b�Z�[�W�̃N���A
				tex���b�Z�[�W.Text = "";
				tex�˗��喼.Text   = "";

				// �󔒏���
				tex�˗���R�[�h.Text = tex�˗���R�[�h.Text.Trim();
				if(tex�˗���R�[�h.Text.Length != 0)
				{
					if(!���p�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;

					tex���b�Z�[�W.Text = "�������D�D�D";
					s�˗���b�c = tex�˗���R�[�h.Text;
					�˗��匟��();
				}
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

		private void �˗��匟��()
		{
			if(s�˗���b�c.Trim().Length == 0) return;
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				// ����
				if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
				String[] sList = sv_goirai.Get_Sirainusi(gsa���[�U,gs����b�c,gs����b�c,s�˗���b�c);

				// ���b�Z�[�W��[�o�^]�A[�X�V]�̎��A����I��
				if(sList[0].Length == 2)
				{
					if(sList[17] == "U")
					{
						tex�˗��喼.Text     = sList[9];
						tex���b�Z�[�W.Text = "";
						cmb�o�ד�.Focus();
					}
					else
					{
						tex�˗��喼.Text     = "";
						tex���b�Z�[�W.Text = "�Y���˗���R�[�h����";
						cmb�o�ד�.Focus();
					}
				}
				else
				{
					// �ُ�I����
					�r�[�v��();
					tex���b�Z�[�W.Text = sList[0];
					tex�˗���R�[�h.Focus();
				}
			}
			catch (System.Net.WebException)
			{
				tex���b�Z�[�W.Text = gs�ʐM�G���[;
				�r�[�v��();
			}
			catch (Exception ex)
			{
				tex���b�Z�[�W.Text = "�ʐM�G���[�F" + ex.Message;
				�r�[�v��();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;

		}
// ADD 2006.08.09 ���s�j�R�{ ���������Ɉ˗����ǉ� END

// MOD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� START
		private void rb�W�s_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rb�W�s.Checked){
				cb���͂���Z�����.Checked = false;
//				cb���͂���Z�����.ForeColor = System.Drawing.Color.White;
//				cb���͂���Z�����.BackColor = System.Drawing.SystemColors.Window;
				cb���͂���Z�����.Enabled = false;
				cb���͂���Z�����.Visible = false;
//				cb���͂���Z�����.Refresh();
			}
			else
			{
//				cb���͂���Z�����.ForeColor = System.Drawing.Color.LimeGreen;
//				cb���͂���Z�����.BackColor = System.Drawing.Color.Honeydew;
				cb���͂���Z�����.Enabled = true;
				cb���͂���Z�����.Visible = true;
//				cb���͂���Z�����.Refresh();
			}
		}
// MOD 2009.01.30 ���s�j���� ���шꗗ����I�v�V�������ڂ̒ǉ� END
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� START
		private void �o�͌`���N���A()
		{
			if(rb���˗����.Checked == false){
				tex�˗���R�[�h.Text     = "";
				tex�˗��喼.Text         = "";
				btn�˗��匟��.Enabled    = false;
//				tex�˗���R�[�h.BackColor = Color.LightGray;
				tex�˗���R�[�h.BackColor = Color.FromArgb(239,233,217);
				tex�˗���R�[�h.Enabled  = false;
				s�˗���b�c = "";
				s�˗��喼   = "";
			}else{
				btn�˗��匟��.Enabled    = true;
				tex�˗���R�[�h.BackColor = Color.White;
				tex�˗���R�[�h.Enabled  = true;
			}
			if(rb�������.Checked   == false){
				cmb������.SelectedIndex  = 0;
				s������b�c              = "";
				s���ۂb�c                = "";
				tex������R�[�h.Text     = "";
				cmb������.Enabled        = false;
				tex������R�[�h.Enabled  = false;
			}else{
				cmb������.Enabled        = true;
				tex������R�[�h.Enabled  = true;
			}
			if(rb���͂����.Checked == false){
				tex�͂���R�[�h.Text     = "";
				tex�͂��於.Text         = "";
				s�͂���b�c = "";
				s�͂��於   = "";
				btn�͂��挟��.Enabled    = false;
//				tex�͂���R�[�h.BackColor = Color.LightGray;
				tex�͂���R�[�h.BackColor = Color.FromArgb(239,233,217);
				tex�͂���R�[�h.Enabled  = false;
			}else{
				btn�͂��挟��.Enabled    = true;
				tex�͂���R�[�h.BackColor = Color.White;
				tex�͂���R�[�h.Enabled  = true;
			}
		}
		private void rb�w��Ȃ�_CheckedChanged(object sender, System.EventArgs e)
		{
			�o�͌`���N���A();
		}

		private void rb���˗����_CheckedChanged(object sender, System.EventArgs e)
		{
			�o�͌`���N���A();
		}

		private void rb�������_CheckedChanged(object sender, System.EventArgs e)
		{
			�o�͌`���N���A();
		}

		private void rb���͂����_CheckedChanged(object sender, System.EventArgs e)
		{
			�o�͌`���N���A();
		}

		private void �͂��挟��()
		{
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				// ����
				if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
				String[] sList = sv_otodoke.Get_Stodokesaki(gsa���[�U,gs����b�c,gs����b�c,s�͂���b�c);

				// ���b�Z�[�W��[�o�^]�A[�X�V]�̎��A����I��
				if(sList[0].Length == 2)
				{
					if(sList[15] == "U")
					{
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//						tex�͂��於.Text     = sList[10].Trim();
						tex�͂��於.Text     = sList[10].TrimEnd();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
						tex���b�Z�[�W.Text = "";
//						tex�˗���R�[�h.Focus();
					}
					else
					{
						tex���b�Z�[�W.Text = "";
//						tex�˗���R�[�h.Focus();
					}
				}
				else
				{
					// �ُ�I����
					�r�[�v��();
					tex���b�Z�[�W.Text = sList[0];
					tex�͂���R�[�h.Focus();
				}
			}
			catch (System.Net.WebException)
			{
				tex���b�Z�[�W.Text = gs�ʐM�G���[;
				�r�[�v��();
			}
			catch (Exception ex)
			{
				tex���b�Z�[�W.Text = "�ʐM�G���[�F" + ex.Message;
				�r�[�v��();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void btn�͂��挟��_Click(object sender, System.EventArgs e)
		{
//			tex�͂���R�[�h.Text = tex�͂���R�[�h.Text.Trim();
//			if(!���p�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;

			if(g�͐挟�� == null) g�͐挟�� = new ���͂��挟��();
			g�͐挟��.Left = this.Left;
			g�͐挟��.Top  = this.Top;

			g�͐挟��.sTcode = "";
			g�͐挟��.ShowDialog();

			s�͂���b�c = g�͐挟��.sTcode;
			s�͂��於   = g�͐挟��.sTname;

			if(s�͂���b�c.Length > 0){
				tex�͂���R�[�h.Text = s�͂���b�c;
				tex�͂��於.Text     = s�͂��於;
//				tex�˗���R�[�h.Focus();
				cmb�o�ד�.Focus();
			}else{
				tex�͂���R�[�h.Focus();
			}
		}

		private void tex�͂���R�[�h_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn�͂��挟��.Focus();
				btn�͂��挟��_Click(sender,e);
				e.Handled = true;
			}		

		}

		private void tex�͂���R�[�h_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
//				btn�͂��挟��.Focus();
				// ���b�Z�[�W�̃N���A
				tex���b�Z�[�W.Text = "";
				tex�͂��於.Text   = "";

				// �󔒏���
				tex�͂���R�[�h.Text = tex�͂���R�[�h.Text.Trim();
				if(tex�͂���R�[�h.Text.Length != 0)
				{
					if(!���p�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;

					tex���b�Z�[�W.Text = "�������D�D�D";
					s�͂���b�c = tex�͂���R�[�h.Text;
					�͂��挟��();
				}
			}
		}

		private void cmb������_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			s������b�c = "";
			s���ۂb�c   = "";
			tex������R�[�h.Text = "";
			if(gsa������b�c.Length > 0 && cmb������.SelectedIndex > 0){
				s������b�c = gsa������b�c[cmb������.SelectedIndex - 1];
				s���ۂb�c   = gsa�����敔�ۂb�c[cmb������.SelectedIndex - 1];
				tex������R�[�h.Text = s������b�c.Trim() + " " + s���ۂb�c.Trim();
			}
		}
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� END
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� START
		private void �o�̓I�v�V�������ݒ�()
		{
			//[�����s��������]�`�F�b�N�{�b�N�X
			if(gs�o�׎���_�����s�����O != null)
			{
				if(gs�o�׎���_�����s�����O == "1")
				{
					cBox�����s��������.Checked = true;
				}
				else
				{
					cBox�����s��������.Checked = false;
				}
			}
			//[�Ԋ|���Ȃ��i����̂݁j]�`�F�b�N�{�b�N�X
			if(gs�o�׎���_�Ԋ|���Ȃ�_����̂� != null)
			{
				if(gs�o�׎���_�Ԋ|���Ȃ�_����̂� == "1")
				{
					cBox�Ԋ|���Ȃ�.Checked = true;
				}
				else
				{
					cBox�Ԋ|���Ȃ�.Checked = false;
				}
			}
			//[���˗���󎚂Ȃ��i����̂݁j]�`�F�b�N�{�b�N�X
			if(gs�o�׎���_���˗���󎚂Ȃ�_����̂� != null)
			{
				if(gs�o�׎���_���˗���󎚂Ȃ�_����̂� == "1")
				{
					cBox���˗���󎚂Ȃ�.Checked = true;
				}
				else
				{
					cBox���˗���󎚂Ȃ�.Checked = false;
				}
			}
			//[�^���󎚂Ȃ��i����̂݁j]�`�F�b�N�{�b�N�X
			if(gs�o�׎���_�^���󎚂Ȃ�_����̂� != null)
			{
				if(gs�o�׎���_�^���󎚂Ȃ�_����̂� == "1")
				{
					cBox�^���󎚂Ȃ�.Checked = true;
				}
				else
				{
					cBox�^���󎚂Ȃ�.Checked = false;
				}
			}
			//[�����ɔ��X�R�[�h�E���X�����o�͂���i�b�r�u�̂݁j]�`�F�b�N�{�b�N�X
			if(gs�o�׎���_���X�o��_�b�r�u�̂� != null)
			{
				if(gs�o�׎���_���X�o��_�b�r�u�̂� == "1")
				{
					cBox���X�b�c�o��.Checked = true;
				}
				else
				{
					cBox���X�b�c�o��.Checked = false;
				}
			}
			//[�z�����t�E�������o�͂���]�`�F�b�N�{�b�N�X
			if(gs�o�׎���_�z�������o�� != null)
			{
				if(gs�o�׎���_�z�������o�� == "1")
				{
					cBox�z���r�o��.Checked = true;
				}
				else
				{
					cBox�z���r�o��.Checked = false;
				}
			}
		}

		private void �o�̓I�v�V�������ۑ�()
		{
			//[�����s��������]�`�F�b�N�{�b�N�X
			if(cBox�����s��������.Checked)
			{
				gs�o�׎���_�����s�����O = "1";
			}
			else
			{
				gs�o�׎���_�����s�����O = "0";
			}
			//[�Ԋ|���Ȃ��i����̂݁j]�`�F�b�N�{�b�N�X
			if(cBox�Ԋ|���Ȃ�.Checked)
			{
				gs�o�׎���_�Ԋ|���Ȃ�_����̂� = "1";
			}
			else
			{
				gs�o�׎���_�Ԋ|���Ȃ�_����̂� = "0";
			}
			//[���˗���󎚂Ȃ��i����̂݁j]�`�F�b�N�{�b�N�X
			if(cBox���˗���󎚂Ȃ�.Checked)
			{
				gs�o�׎���_���˗���󎚂Ȃ�_����̂� = "1";
			}
			else
			{
				gs�o�׎���_���˗���󎚂Ȃ�_����̂� = "0";
			}
			//[�^���󎚂Ȃ��i����̂݁j]�`�F�b�N�{�b�N�X
			if(cBox�^���󎚂Ȃ�.Checked)
			{
				gs�o�׎���_�^���󎚂Ȃ�_����̂� = "1";
			}
			else
			{
				gs�o�׎���_�^���󎚂Ȃ�_����̂� = "0";
			}
			//[�����ɔ��X�R�[�h�E���X�����o�͂���i�b�r�u�̂݁j]�`�F�b�N�{�b�N�X
			if(cBox���X�b�c�o��.Checked)
			{
				gs�o�׎���_���X�o��_�b�r�u�̂� = "1";
			}
			else
			{
				gs�o�׎���_���X�o��_�b�r�u�̂� = "0";
			}
			//[�z�����t�E�������o�͂���]�`�F�b�N�{�b�N�X
			if(cBox�z���r�o��.Checked)
			{
				gs�o�׎���_�z�������o�� = "1";
			}
			else
			{
				gs�o�׎���_�z�������o�� = "0";
			}
		}
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� END
	}
}
