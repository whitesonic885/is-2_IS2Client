using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [���͂���o�^]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX 
	// ADD 2008.10.16 kcl)�X�{ ���X�R�[�h���݃`�F�b�N�ǉ� 
	// ADD 2008.10.17 ���s�j���� ���X�R�[�h�`�F�b�N�@�\�s���� 
	// MOD 2008.11.12 ���s�j���� �Z���b�c�̎����ݒ���s��Ȃ�
	//--------------------------------------------------------------------------
	// DEL 2009.02.02 ���s�j���� ���X�R�[�h�`�F�b�N�@�\����
	// MOD 2009.08.20 �p�\�j���� �X�֔ԍ��̒l���p�� 
	//--------------------------------------------------------------------------
	// MOD 2010.09.22 ���s�j���� �b�r�u�o�́F[�L�����Z��]�I�����̏�Q�C�� 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� 
	// MOD 2011.01.25 ���s�j���� �u���[�h�Ɏ��s�v�Ή� 
	// MOD 2011.12.08 ���s�j���� �Z���E���O�̔��p���͉� 
	//--------------------------------------------------------------------------
    // MOD 2015.05.07 BEVAS) �O�c�@���q�X�֔ԍ��}�X�^���݃`�F�b�N�Ή�
	//--------------------------------------------------------------------------
	// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή�
	//--------------------------------------------------------------------------

	public class ���͂���o�^ : ���ʃt�H�[��
	{
// ADD 2007.02.13 ���s�j���� ORA-00921����єr���G���[�Ή� START
//		private string sIUFlg;
//		private string sUpday;
		private string s�X�V���� = "";
// ADD 2007.02.13 ���s�j���� ORA-00921����єr���G���[�Ή� END
		private string s�͂���b�c;

		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab����;
		private System.Windows.Forms.Button btn�͂��挟��;
		private ���ʃe�L�X�g�{�b�N�X tex�͂���R�[�h;
		private System.Windows.Forms.Label lab�͂���o�^�^�C�g��;
		private ���ʃe�L�X�g�{�b�N�X tex�J�i����;
		private ���ʃe�L�X�g�{�b�N�X tex�d�b�ԍ��P;
		private ���ʃe�L�X�g�{�b�N�X tex���[��;
		private ���ʃe�L�X�g�{�b�N�X tex����v;
		private ���ʃe�L�X�g�{�b�N�X tex���O�Q;
		private ���ʃe�L�X�g�{�b�N�X tex���O�P;
		private ���ʃe�L�X�g�{�b�N�X tex�Z���R;
		private ���ʃe�L�X�g�{�b�N�X tex�X�֔ԍ��Q;
		private ���ʃe�L�X�g�{�b�N�X tex�X�֔ԍ��P;
		private ���ʃe�L�X�g�{�b�N�X tex�d�b�ԍ��R;
		private ���ʃe�L�X�g�{�b�N�X tex�d�b�ԍ��Q;
		private ���ʃe�L�X�g�{�b�N�X tex�Z���Q;
		private ���ʃe�L�X�g�{�b�N�X tex�Z���P;
		private System.Windows.Forms.Button btn�͂�����s;
		private System.Windows.Forms.TextBox tex���q�l��;
		private System.Windows.Forms.Label lab���p����;
		private System.Windows.Forms.TextBox tex���p����;
		private System.Windows.Forms.Button btn�Z������;
		private System.Windows.Forms.Label lab���[��;
		private System.Windows.Forms.Label lab�J�i����;
		private System.Windows.Forms.Label lab����v;
		private System.Windows.Forms.Label lab���O;
		private System.Windows.Forms.Label lab�Z��;
		private System.Windows.Forms.Label lab�X�֔ԍ�;
		private System.Windows.Forms.Label lab�d�b�ԍ�;
		private System.Windows.Forms.Label lab�͂���R�[�h;
		private System.Windows.Forms.Label lab���q�l��;
		private System.Windows.Forms.Button btn�ꗗ�\;
		private System.Windows.Forms.Button btn�폜;
		private System.Windows.Forms.Button btn���;
		private System.Windows.Forms.Button btn�X�V;
		private System.Windows.Forms.TextBox tex���b�Z�[�W;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btn�b�r�u�o��;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Label lbl�׎呍����;
		private System.Windows.Forms.Button btn�����擾;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label lab�Z���R�[�h;
		private System.Windows.Forms.Label lab���X�R�[�h;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�Z���R�[�h;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex���X�R�[�h;
		private System.Windows.Forms.Label lab�Z���R�[�h����;
		private System.Windows.Forms.Label lab���X�R�[�h����;
		private System.Windows.Forms.Button btn�x�X�~��;
		private System.Windows.Forms.Button btn�x�X�~�߉���;
		private System.ComponentModel.IContainer components;

		public ���͂���o�^()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
			�c�o�h�\���T�C�Y�ϊ�();
// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� END
// ADD 2008.10.17 ���s�j���� ���X�R�[�h�`�F�b�N�@�\�s���� START
// DEL 2009.02.02 ���s�j���� ���X�R�[�h�`�F�b�N�@�\���� START
//			lab�Z���R�[�h.Visible = false;
//			lab���X�R�[�h.Visible = false;
//			tex�Z���R�[�h.Visible = false;
//			tex���X�R�[�h.Visible = false;
// DEL 2009.02.02 ���s�j���� ���X�R�[�h�`�F�b�N�@�\���� END
// ADD 2008.10.17 ���s�j���� ���X�R�[�h�`�F�b�N�@�\�s���� END
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(���͂���o�^));
			this.tex�J�i���� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�d�b�ԍ��P = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lab���[�� = new System.Windows.Forms.Label();
			this.tex���[�� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.label1 = new System.Windows.Forms.Label();
			this.lab�J�i���� = new System.Windows.Forms.Label();
			this.tex����v = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab����v = new System.Windows.Forms.Label();
			this.tex���O�Q = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab���O = new System.Windows.Forms.Label();
			this.tex���O�P = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.btn�Z������ = new System.Windows.Forms.Button();
			this.tex�Z���R = new IS2Client.���ʃe�L�X�g�{�b�N�X();
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
			this.btn�͂��挟�� = new System.Windows.Forms.Button();
			this.btn�͂�����s = new System.Windows.Forms.Button();
			this.lab�͂���R�[�h = new System.Windows.Forms.Label();
			this.tex�͂���R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.panel6 = new System.Windows.Forms.Panel();
			this.tex���q�l�� = new System.Windows.Forms.TextBox();
			this.lab���q�l�� = new System.Windows.Forms.Label();
			this.lab���p���� = new System.Windows.Forms.Label();
			this.tex���p���� = new System.Windows.Forms.TextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab���� = new System.Windows.Forms.Label();
			this.lab�͂���o�^�^�C�g�� = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn�b�r�u�o�� = new System.Windows.Forms.Button();
			this.btn�폜 = new System.Windows.Forms.Button();
			this.btn��� = new System.Windows.Forms.Button();
			this.btn�X�V = new System.Windows.Forms.Button();
			this.tex���b�Z�[�W = new System.Windows.Forms.TextBox();
			this.btn���� = new System.Windows.Forms.Button();
			this.btn�ꗗ�\ = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn�x�X�~�߉��� = new System.Windows.Forms.Button();
			this.btn�x�X�~�� = new System.Windows.Forms.Button();
			this.lab���X�R�[�h���� = new System.Windows.Forms.Label();
			this.lab�Z���R�[�h���� = new System.Windows.Forms.Label();
			this.lab���X�R�[�h = new System.Windows.Forms.Label();
			this.lab�Z���R�[�h = new System.Windows.Forms.Label();
			this.tex���X�R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�Z���R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btn�����擾 = new System.Windows.Forms.Button();
			this.lbl�׎呍���� = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).BeginInit();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tex�J�i����
			// 
			this.tex�J�i����.BackColor = System.Drawing.SystemColors.Window;
			this.tex�J�i����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�J�i����.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
			this.tex�J�i����.Location = new System.Drawing.Point(134, 192);
			this.tex�J�i����.MaxLength = 10;
			this.tex�J�i����.Name = "tex�J�i����";
			this.tex�J�i����.Size = new System.Drawing.Size(110, 23);
			this.tex�J�i����.TabIndex = 15;
			this.tex�J�i����.Text = "";
			// 
			// tex�d�b�ԍ��P
			// 
			this.tex�d�b�ԍ��P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�d�b�ԍ��P.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�d�b�ԍ��P.Location = new System.Drawing.Point(134, 16);
			this.tex�d�b�ԍ��P.MaxLength = 6;
			this.tex�d�b�ԍ��P.Name = "tex�d�b�ԍ��P";
			this.tex�d�b�ԍ��P.Size = new System.Drawing.Size(56, 23);
			this.tex�d�b�ԍ��P.TabIndex = 1;
			this.tex�d�b�ԍ��P.Text = "";
			// 
			// label9
			// 
			this.label9.ForeColor = System.Drawing.Color.Red;
			this.label9.Location = new System.Drawing.Point(30, 148);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(16, 14);
			this.label9.TabIndex = 52;
			this.label9.Text = "��";
			// 
			// label7
			// 
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(30, 72);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(16, 14);
			this.label7.TabIndex = 51;
			this.label7.Text = "��";
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(30, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 14);
			this.label3.TabIndex = 50;
			this.label3.Text = "��";
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(30, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 14);
			this.label2.TabIndex = 49;
			this.label2.Text = "��";
			// 
			// lab���[��
			// 
			this.lab���[��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���[��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���[��.Location = new System.Drawing.Point(44, 250);
			this.lab���[��.Name = "lab���[��";
			this.lab���[��.Size = new System.Drawing.Size(70, 14);
			this.lab���[��.TabIndex = 48;
			this.lab���[��.Text = "���[���A�h���X";
			// 
			// tex���[��
			// 
			this.tex���[��.BackColor = System.Drawing.SystemColors.Window;
			this.tex���[��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���[��.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex���[��.Location = new System.Drawing.Point(134, 244);
			this.tex���[��.MaxLength = 45;
			this.tex���[��.Name = "tex���[��";
			this.tex���[��.Size = new System.Drawing.Size(330, 23);
			this.tex���[��.TabIndex = 47;
			this.tex���[��.Text = "";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 334);
			this.label1.TabIndex = 44;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab�J�i����
			// 
			this.lab�J�i����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�J�i����.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�J�i����.Location = new System.Drawing.Point(44, 198);
			this.lab�J�i����.Name = "lab�J�i����";
			this.lab�J�i����.Size = new System.Drawing.Size(70, 14);
			this.lab�J�i����.TabIndex = 42;
			this.lab�J�i����.Text = "�J�i����";
			// 
			// tex����v
			// 
			this.tex����v.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex����v.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex����v.Location = new System.Drawing.Point(134, 218);
			this.tex����v.MaxLength = 5;
			this.tex����v.Name = "tex����v";
			this.tex����v.Size = new System.Drawing.Size(56, 23);
			this.tex����v.TabIndex = 16;
			this.tex����v.Text = "";
			// 
			// lab����v
			// 
			this.lab����v.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab����v.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab����v.Location = new System.Drawing.Point(44, 224);
			this.lab����v.Name = "lab����v";
			this.lab����v.Size = new System.Drawing.Size(70, 14);
			this.lab����v.TabIndex = 37;
			this.lab����v.Text = "����v";
			// 
			// tex���O�Q
			// 
			this.tex���O�Q.BackColor = System.Drawing.SystemColors.Window;
			this.tex���O�Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���O�Q.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex���O�Q.Location = new System.Drawing.Point(134, 166);
			this.tex���O�Q.MaxLength = 20;
			this.tex���O�Q.Name = "tex���O�Q";
			this.tex���O�Q.Size = new System.Drawing.Size(330, 23);
			this.tex���O�Q.TabIndex = 14;
			this.tex���O�Q.Text = "";
			// 
			// lab���O
			// 
			this.lab���O.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���O.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���O.Location = new System.Drawing.Point(44, 148);
			this.lab���O.Name = "lab���O";
			this.lab���O.Size = new System.Drawing.Size(70, 14);
			this.lab���O.TabIndex = 24;
			this.lab���O.Text = "���O";
			// 
			// tex���O�P
			// 
			this.tex���O�P.BackColor = System.Drawing.SystemColors.Window;
			this.tex���O�P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���O�P.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex���O�P.Location = new System.Drawing.Point(134, 142);
			this.tex���O�P.MaxLength = 20;
			this.tex���O�P.Name = "tex���O�P";
			this.tex���O�P.Size = new System.Drawing.Size(330, 23);
			this.tex���O�P.TabIndex = 13;
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
			this.btn�Z������.TabIndex = 9;
			this.btn�Z������.TabStop = false;
			this.btn�Z������.Text = "����";
			this.btn�Z������.Click += new System.EventHandler(this.btn�Z������_Click);
			// 
			// tex�Z���R
			// 
			this.tex�Z���R.BackColor = System.Drawing.SystemColors.Window;
			this.tex�Z���R.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�Z���R.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�Z���R.Location = new System.Drawing.Point(134, 116);
			this.tex�Z���R.MaxLength = 20;
			this.tex�Z���R.Name = "tex�Z���R";
			this.tex�Z���R.Size = new System.Drawing.Size(330, 23);
			this.tex�Z���R.TabIndex = 12;
			this.tex�Z���R.Text = "";
			// 
			// lab�Z��
			// 
			this.lab�Z��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�Z��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�Z��.Location = new System.Drawing.Point(44, 72);
			this.lab�Z��.Name = "lab�Z��";
			this.lab�Z��.Size = new System.Drawing.Size(70, 14);
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
			this.tex�X�֔ԍ��Q.TabIndex = 8;
			this.tex�X�֔ԍ��Q.Text = "";
			this.tex�X�֔ԍ��Q.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�X�֔ԍ��Q_KeyDown);
			this.tex�X�֔ԍ��Q.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�X�֔ԍ��Q_KeyPress);
			// 
			// tex�X�֔ԍ��P
			// 
			this.tex�X�֔ԍ��P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�X�֔ԍ��P.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�X�֔ԍ��P.Location = new System.Drawing.Point(134, 42);
			this.tex�X�֔ԍ��P.MaxLength = 3;
			this.tex�X�֔ԍ��P.Name = "tex�X�֔ԍ��P";
			this.tex�X�֔ԍ��P.Size = new System.Drawing.Size(32, 23);
			this.tex�X�֔ԍ��P.TabIndex = 7;
			this.tex�X�֔ԍ��P.Text = "";
			this.tex�X�֔ԍ��P.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�X�֔ԍ��P_KeyPress);
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label8.ForeColor = System.Drawing.Color.LimeGreen;
			this.label8.Location = new System.Drawing.Point(166, 48);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(12, 14);
			this.label8.TabIndex = 17;
			this.label8.Text = "�|";
			// 
			// lab�X�֔ԍ�
			// 
			this.lab�X�֔ԍ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�X�֔ԍ�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�X�֔ԍ�.Location = new System.Drawing.Point(44, 48);
			this.lab�X�֔ԍ�.Name = "lab�X�֔ԍ�";
			this.lab�X�֔ԍ�.Size = new System.Drawing.Size(70, 14);
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
			this.tex�d�b�ԍ��R.TabIndex = 3;
			this.tex�d�b�ԍ��R.Text = "";
			// 
			// tex�d�b�ԍ��Q
			// 
			this.tex�d�b�ԍ��Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�d�b�ԍ��Q.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�d�b�ԍ��Q.Location = new System.Drawing.Point(206, 16);
			this.tex�d�b�ԍ��Q.MaxLength = 4;
			this.tex�d�b�ԍ��Q.Name = "tex�d�b�ԍ��Q";
			this.tex�d�b�ԍ��Q.Size = new System.Drawing.Size(40, 23);
			this.tex�d�b�ԍ��Q.TabIndex = 2;
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
			this.label5.Location = new System.Drawing.Point(190, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(12, 14);
			this.label5.TabIndex = 11;
			this.label5.Text = "�j";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label4.ForeColor = System.Drawing.Color.LimeGreen;
			this.label4.Location = new System.Drawing.Point(124, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(10, 14);
			this.label4.TabIndex = 10;
			this.label4.Text = "�i";
			// 
			// lab�d�b�ԍ�
			// 
			this.lab�d�b�ԍ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�d�b�ԍ�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�d�b�ԍ�.Location = new System.Drawing.Point(44, 22);
			this.lab�d�b�ԍ�.Name = "lab�d�b�ԍ�";
			this.lab�d�b�ԍ�.Size = new System.Drawing.Size(63, 14);
			this.lab�d�b�ԍ�.TabIndex = 9;
			this.lab�d�b�ԍ�.Text = "�d�b�ԍ�";
			// 
			// tex�Z���Q
			// 
			this.tex�Z���Q.BackColor = System.Drawing.SystemColors.Window;
			this.tex�Z���Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�Z���Q.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�Z���Q.Location = new System.Drawing.Point(134, 92);
			this.tex�Z���Q.MaxLength = 20;
			this.tex�Z���Q.Name = "tex�Z���Q";
			this.tex�Z���Q.Size = new System.Drawing.Size(330, 23);
			this.tex�Z���Q.TabIndex = 11;
			this.tex�Z���Q.Text = "";
			// 
			// tex�Z���P
			// 
			this.tex�Z���P.BackColor = System.Drawing.SystemColors.Window;
			this.tex�Z���P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�Z���P.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�Z���P.Location = new System.Drawing.Point(134, 68);
			this.tex�Z���P.MaxLength = 20;
			this.tex�Z���P.Name = "tex�Z���P";
			this.tex�Z���P.Size = new System.Drawing.Size(330, 23);
			this.tex�Z���P.TabIndex = 10;
			this.tex�Z���P.Text = "";
			// 
			// btn�͂��挟��
			// 
			this.btn�͂��挟��.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�͂��挟��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�͂��挟��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�͂��挟��.ForeColor = System.Drawing.Color.White;
			this.btn�͂��挟��.Location = new System.Drawing.Point(282, 14);
			this.btn�͂��挟��.Name = "btn�͂��挟��";
			this.btn�͂��挟��.Size = new System.Drawing.Size(64, 22);
			this.btn�͂��挟��.TabIndex = 1;
			this.btn�͂��挟��.TabStop = false;
			this.btn�͂��挟��.Text = "�A�h���X��";
			this.btn�͂��挟��.Click += new System.EventHandler(this.btn�͂��挟��_Click);
			// 
			// btn�͂�����s
			// 
			this.btn�͂�����s.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�͂�����s.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�͂�����s.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�͂�����s.ForeColor = System.Drawing.Color.White;
			this.btn�͂�����s.Location = new System.Drawing.Point(348, 14);
			this.btn�͂�����s.Name = "btn�͂�����s";
			this.btn�͂�����s.Size = new System.Drawing.Size(48, 22);
			this.btn�͂�����s.TabIndex = 2;
			this.btn�͂�����s.TabStop = false;
			this.btn�͂�����s.Text = "���s";
			this.btn�͂�����s.Click += new System.EventHandler(this.btn�͂�����s_Click);
			// 
			// lab�͂���R�[�h
			// 
			this.lab�͂���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�͂���R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�͂���R�[�h.Location = new System.Drawing.Point(6, 18);
			this.lab�͂���R�[�h.Name = "lab�͂���R�[�h";
			this.lab�͂���R�[�h.Size = new System.Drawing.Size(104, 16);
			this.lab�͂���R�[�h.TabIndex = 6;
			this.lab�͂���R�[�h.Text = "���͂���R�[�h";
			// 
			// tex�͂���R�[�h
			// 
			this.tex�͂���R�[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex�͂���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�͂���R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�͂���R�[�h.Location = new System.Drawing.Point(112, 14);
			this.tex�͂���R�[�h.MaxLength = 15;
			this.tex�͂���R�[�h.Name = "tex�͂���R�[�h";
			this.tex�͂���R�[�h.Size = new System.Drawing.Size(166, 23);
			this.tex�͂���R�[�h.TabIndex = 0;
			this.tex�͂���R�[�h.Text = "";
			this.tex�͂���R�[�h.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�͂���R�[�h_KeyDown);
			this.tex�͂���R�[�h.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�͂���R�[�h_KeyPress);
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
			this.panel7.Controls.Add(this.lab�͂���o�^�^�C�g��);
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
			// lab�͂���o�^�^�C�g��
			// 
			this.lab�͂���o�^�^�C�g��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�͂���o�^�^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�͂���o�^�^�C�g��.ForeColor = System.Drawing.Color.White;
			this.lab�͂���o�^�^�C�g��.Location = new System.Drawing.Point(12, 2);
			this.lab�͂���o�^�^�C�g��.Name = "lab�͂���o�^�^�C�g��";
			this.lab�͂���o�^�^�C�g��.Size = new System.Drawing.Size(264, 24);
			this.lab�͂���o�^�^�C�g��.TabIndex = 0;
			this.lab�͂���o�^�^�C�g��.Text = "���͂���o�^";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn�b�r�u�o��);
			this.panel8.Controls.Add(this.btn�폜);
			this.panel8.Controls.Add(this.btn���);
			this.panel8.Controls.Add(this.btn�X�V);
			this.panel8.Controls.Add(this.tex���b�Z�[�W);
			this.panel8.Controls.Add(this.btn����);
			this.panel8.Controls.Add(this.btn�ꗗ�\);
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
			this.btn�b�r�u�o��.TabIndex = 54;
			this.btn�b�r�u�o��.Text = "�b�r�u�@�@�o��";
			this.btn�b�r�u�o��.Click += new System.EventHandler(this.btn�b�r�u�o��_Click);
			// 
			// btn�폜
			// 
			this.btn�폜.ForeColor = System.Drawing.Color.Blue;
			this.btn�폜.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�폜.Location = new System.Drawing.Point(238, 6);
			this.btn�폜.Name = "btn�폜";
			this.btn�폜.Size = new System.Drawing.Size(62, 48);
			this.btn�폜.TabIndex = 52;
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
			this.btn���.TabIndex = 51;
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
			this.btn�X�V.TabIndex = 50;
			this.btn�X�V.Text = "�ۑ�";
			this.btn�X�V.Click += new System.EventHandler(this.btn�X�V_Click);
			// 
			// tex���b�Z�[�W
			// 
			this.tex���b�Z�[�W.BackColor = System.Drawing.Color.PaleGreen;
			this.tex���b�Z�[�W.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���b�Z�[�W.ForeColor = System.Drawing.Color.Red;
			this.tex���b�Z�[�W.Location = new System.Drawing.Point(448, 4);
			this.tex���b�Z�[�W.Multiline = true;
			this.tex���b�Z�[�W.Name = "tex���b�Z�[�W";
			this.tex���b�Z�[�W.ReadOnly = true;
			this.tex���b�Z�[�W.Size = new System.Drawing.Size(342, 50);
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
			// btn�ꗗ�\
			// 
			this.btn�ꗗ�\.BackColor = System.Drawing.Color.PaleGreen;
			this.btn�ꗗ�\.ForeColor = System.Drawing.Color.Blue;
			this.btn�ꗗ�\.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�ꗗ�\.Location = new System.Drawing.Point(308, 6);
			this.btn�ꗗ�\.Name = "btn�ꗗ�\";
			this.btn�ꗗ�\.Size = new System.Drawing.Size(60, 48);
			this.btn�ꗗ�\.TabIndex = 53;
			this.btn�ꗗ�\.Text = "�ꗗ�\�@���";
			this.btn�ꗗ�\.Click += new System.EventHandler(this.btn�ꗗ�\_Click);
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
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btn�x�X�~�߉���);
			this.groupBox1.Controls.Add(this.btn�x�X�~��);
			this.groupBox1.Controls.Add(this.lab���X�R�[�h����);
			this.groupBox1.Controls.Add(this.tex���[��);
			this.groupBox1.Controls.Add(this.tex�Z���P);
			this.groupBox1.Controls.Add(this.tex�Z���Q);
			this.groupBox1.Controls.Add(this.lab�d�b�ԍ�);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.tex�d�b�ԍ��Q);
			this.groupBox1.Controls.Add(this.tex�d�b�ԍ��R);
			this.groupBox1.Controls.Add(this.lab�X�֔ԍ�);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.tex�X�֔ԍ��P);
			this.groupBox1.Controls.Add(this.tex�X�֔ԍ��Q);
			this.groupBox1.Controls.Add(this.lab�Z��);
			this.groupBox1.Controls.Add(this.tex�Z���R);
			this.groupBox1.Controls.Add(this.btn�Z������);
			this.groupBox1.Controls.Add(this.tex���O�P);
			this.groupBox1.Controls.Add(this.lab���O);
			this.groupBox1.Controls.Add(this.tex���O�Q);
			this.groupBox1.Controls.Add(this.lab����v);
			this.groupBox1.Controls.Add(this.tex�J�i����);
			this.groupBox1.Controls.Add(this.lab�J�i����);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.lab���[��);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.tex�d�b�ԍ��P);
			this.groupBox1.Controls.Add(this.tex����v);
			this.groupBox1.Controls.Add(this.lab�Z���R�[�h����);
			this.groupBox1.Controls.Add(this.lab���X�R�[�h);
			this.groupBox1.Controls.Add(this.lab�Z���R�[�h);
			this.groupBox1.Controls.Add(this.tex���X�R�[�h);
			this.groupBox1.Controls.Add(this.tex�Z���R�[�h);
			this.groupBox1.Location = new System.Drawing.Point(22, 96);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(624, 342);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			// 
			// btn�x�X�~�߉���
			// 
			this.btn�x�X�~�߉���.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�x�X�~�߉���.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�x�X�~�߉���.ForeColor = System.Drawing.Color.White;
			this.btn�x�X�~�߉���.Location = new System.Drawing.Point(272, 42);
			this.btn�x�X�~�߉���.Name = "btn�x�X�~�߉���";
			this.btn�x�X�~�߉���.Size = new System.Drawing.Size(78, 22);
			this.btn�x�X�~�߉���.TabIndex = 60;
			this.btn�x�X�~�߉���.TabStop = false;
			this.btn�x�X�~�߉���.Text = "�x�X�~����";
			this.btn�x�X�~�߉���.Visible = false;
			this.btn�x�X�~�߉���.Click += new System.EventHandler(this.btn�x�X�~�߉���_Click);
			// 
			// btn�x�X�~��
			// 
			this.btn�x�X�~��.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�x�X�~��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�x�X�~��.ForeColor = System.Drawing.Color.White;
			this.btn�x�X�~��.Location = new System.Drawing.Point(272, 42);
			this.btn�x�X�~��.Name = "btn�x�X�~��";
			this.btn�x�X�~��.Size = new System.Drawing.Size(52, 22);
			this.btn�x�X�~��.TabIndex = 59;
			this.btn�x�X�~��.TabStop = false;
			this.btn�x�X�~��.Text = "�x�X�~";
			this.btn�x�X�~��.Click += new System.EventHandler(this.btn�x�X�~��_Click);
			// 
			// lab���X�R�[�h����
			// 
			this.lab���X�R�[�h����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���X�R�[�h����.ForeColor = System.Drawing.Color.Red;
			this.lab���X�R�[�h����.Location = new System.Drawing.Point(270, 300);
			this.lab���X�R�[�h����.Name = "lab���X�R�[�h����";
			this.lab���X�R�[�h����.Size = new System.Drawing.Size(150, 14);
			this.lab���X�R�[�h����.TabIndex = 58;
			this.lab���X�R�[�h����.Text = "���ʏ�͓��͂��Ȃ��ŉ�����";
			// 
			// lab�Z���R�[�h����
			// 
			this.lab�Z���R�[�h����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�Z���R�[�h����.ForeColor = System.Drawing.Color.Red;
			this.lab�Z���R�[�h����.Location = new System.Drawing.Point(270, 274);
			this.lab�Z���R�[�h����.Name = "lab�Z���R�[�h����";
			this.lab�Z���R�[�h����.Size = new System.Drawing.Size(150, 14);
			this.lab�Z���R�[�h����.TabIndex = 57;
			this.lab�Z���R�[�h����.Text = "���ʏ�͓��͂��Ȃ��ŉ�����";
			// 
			// lab���X�R�[�h
			// 
			this.lab���X�R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���X�R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���X�R�[�h.Location = new System.Drawing.Point(44, 302);
			this.lab���X�R�[�h.Name = "lab���X�R�[�h";
			this.lab���X�R�[�h.Size = new System.Drawing.Size(70, 14);
			this.lab���X�R�[�h.TabIndex = 54;
			this.lab���X�R�[�h.Text = "���X�R�[�h";
			// 
			// lab�Z���R�[�h
			// 
			this.lab�Z���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�Z���R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�Z���R�[�h.Location = new System.Drawing.Point(44, 276);
			this.lab�Z���R�[�h.Name = "lab�Z���R�[�h";
			this.lab�Z���R�[�h.Size = new System.Drawing.Size(70, 14);
			this.lab�Z���R�[�h.TabIndex = 53;
			this.lab�Z���R�[�h.Text = "�Z���R�[�h";
			// 
			// tex���X�R�[�h
			// 
			this.tex���X�R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���X�R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex���X�R�[�h.Location = new System.Drawing.Point(134, 296);
			this.tex���X�R�[�h.MaxLength = 4;
			this.tex���X�R�[�h.Name = "tex���X�R�[�h";
			this.tex���X�R�[�h.Size = new System.Drawing.Size(42, 23);
			this.tex���X�R�[�h.TabIndex = 56;
			this.tex���X�R�[�h.Text = "";
			// 
			// tex�Z���R�[�h
			// 
			this.tex�Z���R�[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex�Z���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�Z���R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�Z���R�[�h.Location = new System.Drawing.Point(134, 270);
			this.tex�Z���R�[�h.MaxLength = 16;
			this.tex�Z���R�[�h.Name = "tex�Z���R�[�h";
			this.tex�Z���R�[�h.Size = new System.Drawing.Size(136, 23);
			this.tex�Z���R�[�h.TabIndex = 55;
			this.tex�Z���R�[�h.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btn�����擾);
			this.groupBox2.Controls.Add(this.lbl�׎呍����);
			this.groupBox2.Controls.Add(this.tex�͂���R�[�h);
			this.groupBox2.Controls.Add(this.lab�͂���R�[�h);
			this.groupBox2.Controls.Add(this.btn�͂�����s);
			this.groupBox2.Controls.Add(this.btn�͂��挟��);
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Location = new System.Drawing.Point(44, 56);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(602, 44);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			// 
			// btn�����擾
			// 
			this.btn�����擾.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�����擾.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�����擾.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�����擾.ForeColor = System.Drawing.Color.White;
			this.btn�����擾.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btn�����擾.Location = new System.Drawing.Point(402, 14);
			this.btn�����擾.Name = "btn�����擾";
			this.btn�����擾.Size = new System.Drawing.Size(104, 22);
			this.btn�����擾.TabIndex = 45;
			this.btn�����擾.TabStop = false;
			this.btn�����擾.Text = "���͂��摍�����F";
			this.btn�����擾.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btn�����擾.Click += new System.EventHandler(this.btn�����擾_Click);
			// 
			// lbl�׎呍����
			// 
			this.lbl�׎呍����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lbl�׎呍����.ForeColor = System.Drawing.Color.Black;
			this.lbl�׎呍����.Location = new System.Drawing.Point(514, 14);
			this.lbl�׎呍����.Name = "lbl�׎呍����";
			this.lbl�׎呍����.Size = new System.Drawing.Size(74, 22);
			this.lbl�׎呍����.TabIndex = 44;
			this.lbl�׎呍����.Text = "10000 ��";
			this.lbl�׎呍����.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbl�׎呍����.Visible = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Location = new System.Drawing.Point(400, 6);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(194, 34);
			this.groupBox3.TabIndex = 46;
			this.groupBox3.TabStop = false;
			// 
			// ���͂���o�^
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 580);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.groupBox1);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "���͂���o�^";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 ���͂���o�^";
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX START
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.On�G���^�[�ړ�);
            //this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.On�G���^�[�L�����Z��);
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX END
            this.Load += new System.EventHandler(this.���͂���o�^_Load);
			this.Closed += new System.EventHandler(this.���͂���o�^_Closed);
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
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
		private void btn����_Click(object sender, System.EventArgs e)
		{
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� START
			// ���b�N������
			tex�X�֔ԍ��P.Enabled = true; // �X�֔ԍ��P
			tex�X�֔ԍ��Q.Enabled = true; // �X�֔ԍ��Q
			tex�Z���P.Enabled = true; // �Z���P
			tex�Z���Q.Enabled = true; // �Z���Q
			tex�Z���R.Enabled = true; // �Z���R

			// �x�X�~�߃{�^����\���A�����{�^�����\��
			btn�x�X�~��.Visible = true;
			btn�x�X�~�߉���.Visible = false;
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� END
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
//				if(���.s�Z��.Length > 60)
				tex�X�֔ԍ��P.Text = g�Z������.s�X�֔ԍ��P;
				tex�X�֔ԍ��Q.Text = g�Z������.s�X�֔ԍ��Q;
				if(g�Z������.s�Z��.Length > 60)
				{
//					tex�Z���P.Text     = ���.s�Z��.Substring(0,20);
//					tex�Z���Q.Text     = ���.s�Z��.Substring(20,20);
//					tex�Z���R.Text     = ���.s�Z��.Substring(40,20);
					tex�Z���P.Text     = g�Z������.s�Z��.Substring(0,20);
					tex�Z���Q.Text     = g�Z������.s�Z��.Substring(20,20);
					tex�Z���R.Text     = g�Z������.s�Z��.Substring(40,20);
				}
//				else if(���.s�Z��.Length > 40)
				else if(g�Z������.s�Z��.Length > 40)
				{
//					tex�Z���P.Text     = ���.s�Z��.Substring(0,20);
//					tex�Z���Q.Text     = ���.s�Z��.Substring(20,20);
//					tex�Z���R.Text     = ���.s�Z��.Substring(40);
					tex�Z���P.Text     = g�Z������.s�Z��.Substring(0,20);
					tex�Z���Q.Text     = g�Z������.s�Z��.Substring(20,20);
					tex�Z���R.Text     = g�Z������.s�Z��.Substring(40);
				}
//				else if(���.s�Z��.Length > 20)
				else if(g�Z������.s�Z��.Length > 20)
				{
//					tex�Z���P.Text     = ���.s�Z��.Substring(0,20);
//					tex�Z���Q.Text     = ���.s�Z��.Substring(20);
					tex�Z���P.Text     = g�Z������.s�Z��.Substring(0,20);
					tex�Z���Q.Text     = g�Z������.s�Z��.Substring(20);
					tex�Z���R.Text     = "";
				}
				else
				{
//					tex�Z���P.Text     = ���.s�Z��;
					tex�Z���P.Text     = g�Z������.s�Z��;
					tex�Z���Q.Text     = "";
					tex�Z���R.Text     = "";
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

		private void btn�͂��挟��_Click(object sender, System.EventArgs e)
		{
			tex�͂���R�[�h.Text = tex�͂���R�[�h.Text.Trim();
			if(!���p�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;

// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
			// ������ʂ��E���ɕ\������
//			���͂��挟�� ��� = new ���͂��挟��();
//			���.Left = this.Left + 404;
//			���.Top = this.Top;
//			���.Visible����();
			// �R�[�h�̏����\��
//			���.sTcode = tex�͂���R�[�h.Text;
//			���.ShowDialog();
			if (g�͐挟�� == null)	 g�͐挟�� = new ���͂��挟��();
			g�͐挟��.Left = this.Left;
			g�͐挟��.Top = this.Top;
			g�͐挟��.Visible����();
// ADD 2006.07.04 ���s�j�R�{ �폜���ꗗ������b�r�u�o�͋@�\�ǉ� START
			g�͐挟��.VisibleCSV�o��();
			g�͐挟��.Visible�ꗗ���();
			g�͐挟��.Visible�폜();
// ADD 2006.07.04 ���s�j�R�{ �폜���ꗗ������b�r�u�o�͋@�\�ǉ� END
			// �R�[�h�̏����\��
// MOD 2005.06.02 ���s�j�����J �l�̈��p���Ȃ� START
//			g�͐挟��.sTcode = tex�͂���R�[�h.Text;
			g�͐挟��.sTcode = "";
// MOD 2005.06.02 ���s�j�����J �l�̈��p���Ȃ� END
			g�͐挟��.ShowDialog(this);
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END

			s�͂���b�c = g�͐挟��.sTcode;
			if(s�͂���b�c.Length > 0)
			{
				���ڃN���A();
				if(g�͐挟��.s���� == "T")
				{
					tex�͂���R�[�h.Text = "";
					�͂��挟��();
					tex�͂���R�[�h.Focus();
				}
				else
				{
					tex�͂���R�[�h.Text = s�͂���b�c;
					�͂��挟��();
					tex�d�b�ԍ��P.Focus();
				}
			}
			else
			{
				tex�͂���R�[�h.Focus();
			}
			// MOD 2006.07.12 ���s�j�R�{ �׎呍�����̕\���Ή� START
			if(lbl�׎呍����.Text.Length != 0)
			{
				String[] sList1 = {""};
				sList1 = sv_otodoke.Get_ninushiCount(gsa���[�U,gs����b�c,gs����b�c);
// MOD 2007.02.19 FJCS�j�K�c �׎呍�����̕\���Ή� START
//				lbl�׎呍����.Text=sList1[1].ToString()+"��";
				lbl�׎呍����.Text=sList1[1].ToString()+" ��";
// MOD 2007.02.19 FJCS�j�K�c �׎呍�����̕\���Ή� END
				lbl�׎呍����.Visible=true;
			}
			// MOD 2006.07.12 ���s�j�R�{ �׎呍�����̕\���Ή� END

		}

		private void ���͂���o�^_Load(object sender, System.EventArgs e)
		{
			// �w�b�_�[���ڂ̐ݒ�
			tex���q�l��.Text = gs���p�Җ�;
			tex���p����.Text = gs����b�c + " " + gs���喼;

			// �����̏����ݒ�
			lab����.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled = true;
// ADD 2006.07.11 ���s�j�R�{ �׎呍�����\���Ή� START
			lbl�׎呍����.Text = "";
// ADD 2006.07.11 ���s�j�R�{ �׎呍�����\���Ή� END
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
			Font fGothic = new System.Drawing.Font("MS Gothic"
							, 12F
							, System.Drawing.FontStyle.Regular
							, System.Drawing.GraphicsUnit.Point
							, ((System.Byte)(128))
							);
			tex�Z���P.Font = fGothic;
			tex�Z���Q.Font = fGothic;
			tex�Z���R.Font = fGothic;
			tex���O�P.Font = fGothic;
			tex���O�Q.Font = fGothic;
			tex�J�i����.Font = fGothic;
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lab����.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

		private void btn�͂�����s_Click(object sender, System.EventArgs e)
		{
			// ���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
			���ڃN���A();

			// �󔒏���
			tex�͂���R�[�h.Text = tex�͂���R�[�h.Text.Trim();

			if(!�K�{�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;
			if(!���p�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;

			s�͂���b�c = tex�͂���R�[�h.Text.Trim();
			�͂��挟��();

		}

		private void �͂��挟��()
		{
			// ���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "�������D�D�D";

			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			String[] sList = {""};
			try
			{
				// ����
				if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
// DEL 2005.05.20 ���s�j���� �Z�V�����R���g���[���̔p�~ START
//				sv_otodoke.CookieContainer = cContainer;
// DEL 2005.05.20 ���s�j���� �Z�V�����R���g���[���̔p�~ END
				sList = sv_otodoke.Get_Stodokesaki(gsa���[�U,gs����b�c,gs����b�c,s�͂���b�c);
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

			if(sList[2] != null)
			{
				tex�J�i����.Text   = sList[1].Trim();
				tex�d�b�ԍ��P.Text = sList[2].Trim();
				tex�d�b�ԍ��Q.Text = sList[3].Trim();
				tex�d�b�ԍ��R.Text = sList[4].Trim();
				tex�X�֔ԍ��P.Text = sList[5].Trim();
				tex�X�֔ԍ��Q.Text = sList[6].Trim();
				tex�Z���P.Text     = sList[7].Trim();
				tex�Z���Q.Text     = sList[8].Trim();
				tex�Z���R.Text     = sList[9].Trim();
				tex���O�P.Text     = sList[10].Trim();
				tex���O�Q.Text     = sList[11].Trim();
				tex����v.Text     = sList[12].Trim();
				tex���[��.Text     = sList[13].Trim();
// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX START
				tex�Z���R�[�h.Text = sList[16].Trim();
				tex���X�R�[�h.Text = sList[17].Trim();
// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX END
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
				if(gs�I�v�V����[18].Equals("1")){
					tex�J�i����.Text = sList[1].TrimEnd();
					tex�Z���P.Text   = sList[7].TrimEnd();
					tex�Z���Q.Text   = sList[8].TrimEnd();
					tex�Z���R.Text   = sList[9].TrimEnd();
					tex���O�P.Text   = sList[10].TrimEnd();
					tex���O�Q.Text   = sList[11].TrimEnd();
				}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END

// MOD 2007.02.13 ���s�j���� ORA-00921����єr���G���[�Ή� START
//				sUpday             = sList[14];
//				sIUFlg             = sList[15];
				s�X�V����          = sList[14];
// MOD 2007.02.13 ���s�j���� ORA-00921����єr���G���[�Ή� END
			}
			// ���b�Z�[�W�̕\��
			tex���b�Z�[�W.Text = sList[0];

			// ���b�Z�[�W��[�o�^]�A[�X�V]�̎��A����I��
			if(sList[0].Length == 2)
			{
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� START
				if(tex�Z���P.Text.Equals("�����x�X�~�߁���"))
				{
					// ���b�N
					tex�X�֔ԍ��P.Enabled = false; // �X�֔ԍ��P
					tex�X�֔ԍ��Q.Enabled = false; // �X�֔ԍ��Q
					tex�Z���P.Enabled = false; // �Z���P
					tex�Z���Q.Enabled = false; // �Z���Q
					tex�Z���R.Enabled = false; // �Z���R

					// �x�X�~�߃{�^�����\���A�����{�^����\��
					btn�x�X�~��.Visible = false;
					btn�x�X�~�߉���.Visible = true;
				}
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� END

				tex���b�Z�[�W.Text = "";
				tex�d�b�ԍ��P.Focus();
			}
			else
			{
				// �ُ�I����
				�r�[�v��();
				tex�͂���R�[�h.Focus();
			}
		}

		private void btn�X�V_Click(object sender, System.EventArgs e)
		{
			tex���b�Z�[�W.Text = "";

			tex�͂���R�[�h.Text = tex�͂���R�[�h.Text.Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//			tex�J�i����.Text     = tex�J�i����.Text.Trim();
			if(gs�I�v�V����[18].Equals("1")){
				tex�J�i����.Text = tex�J�i����.Text.TrimEnd();
			}else{
				tex�J�i����.Text = tex�J�i����.Text.Trim();
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
			tex�d�b�ԍ��P.Text   = tex�d�b�ԍ��P.Text.Trim();
			tex�d�b�ԍ��Q.Text   = tex�d�b�ԍ��Q.Text.Trim();
			tex�d�b�ԍ��R.Text   = tex�d�b�ԍ��R.Text.Trim();
			tex�X�֔ԍ��P.Text   = tex�X�֔ԍ��P.Text.Trim();
			tex�X�֔ԍ��Q.Text   = tex�X�֔ԍ��Q.Text.Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//			tex�Z���P.Text       = tex�Z���P.Text.Trim();
//			tex�Z���Q.Text       = tex�Z���Q.Text.Trim();
//			tex�Z���R.Text       = tex�Z���R.Text.Trim();
//			tex���O�P.Text       = tex���O�P.Text.Trim();
//			tex���O�Q.Text       = tex���O�Q.Text.Trim();
			if(gs�I�v�V����[18].Equals("1")){
				tex�Z���P.Text   = tex�Z���P.Text.TrimEnd();
				tex�Z���Q.Text   = tex�Z���Q.Text.TrimEnd();
				tex�Z���R.Text   = tex�Z���R.Text.TrimEnd();
				tex���O�P.Text   = tex���O�P.Text.TrimEnd();
				tex���O�Q.Text   = tex���O�Q.Text.TrimEnd();
			}else{
				tex�Z���P.Text   = tex�Z���P.Text.Trim();
				tex�Z���Q.Text   = tex�Z���Q.Text.Trim();
				tex�Z���R.Text   = tex�Z���R.Text.Trim();
				tex���O�P.Text   = tex���O�P.Text.Trim();
				tex���O�Q.Text   = tex���O�Q.Text.Trim();
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
			tex����v.Text       = tex����v.Text.Trim();
			tex���[��.Text       = tex���[��.Text.Trim();
// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX START
			tex�Z���R�[�h.Text   = tex�Z���R�[�h.Text.Trim();
			tex���X�R�[�h.Text   = tex���X�R�[�h.Text.Trim();
// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX END

			if(!�K�{�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;
			if(!�K�{�`�F�b�N(tex�d�b�ԍ��P,"�d�b�ԍ��P")) return;
			if(!�K�{�`�F�b�N(tex�d�b�ԍ��Q,"�d�b�ԍ��Q")) return;
			if(!�K�{�`�F�b�N(tex�d�b�ԍ��R,"�d�b�ԍ��R")) return;
			if(!�K�{�`�F�b�N(tex�X�֔ԍ��P,"�X�֔ԍ��P")) return;
			if(!�K�{�`�F�b�N(tex�X�֔ԍ��Q,"�X�֔ԍ��Q")) return;
			if(!�K�{�`�F�b�N(tex�Z���P,"�Z���P")) return;
			if(!�K�{�`�F�b�N(tex���O�P,"���O�P")) return;

			if(!���p�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;
			if(!���p�`�F�b�N(tex�J�i����,"�J�i����")) return;
			if(!���l�`�F�b�N(tex�d�b�ԍ��P,"�d�b�ԍ��P")) return;
			if(!���l�`�F�b�N(tex�d�b�ԍ��Q,"�d�b�ԍ��Q")) return;
			if(!���l�`�F�b�N(tex�d�b�ԍ��R,"�d�b�ԍ��R")) return;
			if(!���p�`�F�b�N(tex�X�֔ԍ��P,"�X�֔ԍ��P")) return;
			if(!���p�`�F�b�N(tex�X�֔ԍ��Q,"�X�֔ԍ��Q")) return;
// MOD 2011.12.08 ���s�j���� �Z���E���O�̔��p���͉� START
//			if(!�S�p�`�F�b�N(tex�Z���P,"�Z���P")) return;
//			if(!�S�p�`�F�b�N(tex�Z���Q,"�Z���Q")) return;
//			if(!�S�p�`�F�b�N(tex�Z���R,"�Z���R")) return;
//			if(!�S�p�`�F�b�N(tex���O�P,"���O�P")) return;
//			if(!�S�p�`�F�b�N(tex���O�Q,"���O�Q")) return;
			if(!�S�p�ϊ��`�F�b�N(tex�Z���P,"�Z���P")) return;
			if(!�S�p�ϊ��`�F�b�N(tex�Z���Q,"�Z���Q")) return;
			if(!�S�p�ϊ��`�F�b�N(tex�Z���R,"�Z���R")) return;
			if(!�S�p�ϊ��`�F�b�N(tex���O�P,"���O�P")) return;
			if(!�S�p�ϊ��`�F�b�N(tex���O�Q,"���O�Q")) return;
// MOD 2011.12.08 ���s�j���� �Z���E���O�̔��p���͉� END
			if(!���p�`�F�b�N(tex����v,"����v")) return;
			if(!���p�`�F�b�N(tex���[��,"���[���A�h���X")) return;
// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX START
			if(!���p�`�F�b�N(tex�Z���R�[�h,"�Z���R�[�h")) return;
			if(!���p�`�F�b�N(tex���X�R�[�h,"���X�R�[�h")) return;
// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX END

			//�X�֔ԍ����݃`�F�b�N
			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
// MOD 2007.02.13 ���s�j���� �X�֔ԍ��̕ۑ���Q�Ή� START
			string s�X�֔ԍ� = tex�X�֔ԍ��P.Text + tex�X�֔ԍ��Q.Text;
//�ۗ��@�X�֔ԍ��}�X�^�`�F�b�N������������
//			string s�X�֔ԍ� = tex�X�֔ԍ��P.Text.PadRight(3,' ') + tex�X�֔ԍ��Q.Text;
// MOD 2007.02.13 ���s�j���� �X�֔ԍ��̕ۑ���Q�Ή� END
			string[] sRet = {""};
			try
			{
// MOD 2015.05.07 BEVAS�j�O�c ���q�^���X�֔ԍ����݃`�F�b�N�Ή� START
				//if(sv_address == null) sv_address = new is2address.Service1();
				//sRet = sv_address.Get_byPostcode2(gsa���[�U,s�X�֔ԍ�);
				sRet = �b�l�P�S�X�֔ԍ����݃`�F�b�N(s�X�֔ԍ�);
// MOD 2015.05.07 BEVAS�j�O�c ���q�^���X�֔ԍ����݃`�F�b�N�Ή� END
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
// MOD 2008.11.12 ���s�j���� �Z���b�c�̎����ݒ���s��Ȃ� START
//// ADD 2006.07.10 ���s�j���� �Z���b�c�̒ǉ� START
//			string s�Z���b�c = sRet[3];
//// ADD 2006.07.10 ���s�j���� �Z���b�c�̒ǉ� END
//// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX START
//			// ��ʂœ��͂���Ă���ꍇ�́A�����D�悷��
//			if (tex�Z���R�[�h.Text.Length > 0)
//				s�Z���b�c = tex�Z���R�[�h.Text;
//// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX END
// MOD 2008.11.12 ���s�j���� �Z���b�c�̎����ݒ���s��Ȃ� END

// ADD 2008.10.16 kcl)�X�{ ���X�R�[�h���݃`�F�b�N�ǉ� START
			if (tex���X�R�[�h.Text.Length > 0) 
			{
				// ���X�R�[�h�����͂���Ă���ꍇ
				string [] sRetChk = new string[1];
				try
				{
					// ���X�R�[�h���݃`�F�b�N
					if (sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
					sRetChk = sv_otodoke.Check_TensyoCode(gsa���[�U, tex���X�R�[�h.Text);
				}
				catch (System.Net.WebException)
				{
					sRetChk[0] = gs�ʐM�G���[;
				}
				catch (Exception ex)
				{
					sRetChk[0] = "�ʐM�G���[�F" + ex.Message;
				}
				if (! sRetChk[0].Equals("����I��")) 
				{
					tex���b�Z�[�W.Text = sRetChk[0];
					�r�[�v��();
					tex���X�R�[�h.Focus();
					Cursor = System.Windows.Forms.Cursors.Default;
					return;
				}
			}
// ADD 2008.10.16 kcl)�X�{ ���X�R�[�h���݃`�F�b�N�ǉ� END

// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� START
			if(tex�Z���P.Text.Equals("�����x�X�~�߁���"))
			{
				/** �x�X�~�߂�����׎�l������͂ł��悤�Ƃ������̍l�� */

				// �Z���R�̓��̓`�F�b�N
				if(tex�Z���R.Text.Trim().Equals(""))
				{
					// �Z���R�ɉ������͂���Ă��Ȃ�
					tex���b�Z�[�W.Text = "�x�X�~�߂́A�x�X�~�߃{�^���ɂ����͂ł��肢�v���܂��B";
					�r�[�v��();
					tex�Z���P.Focus();
					Cursor = System.Windows.Forms.Cursors.Default;
					return;
				}

				// �b�l�P�O���݃`�F�b�N
				string[] sChkList = new string[2];
				try
				{
					if(sv_syukka == null)
					{
						sv_syukka = new is2syukka.Service1();
					}
					sChkList = sv_syukka.CheckCM10_GeneralDelivery(gsa���[�U, tex�Z���R.Text, s�X�֔ԍ�);

					if(sChkList[0].Length == 4)
					{
						// ����I����
						tex�Z���Q.Text = sChkList[1] + "�~��";
					}
					else
					{
						// �ُ�I����
						tex���b�Z�[�W.Text = "�x�X�~�߂́A�x�X�~�߃{�^���ɂ����͂ł��肢�v���܂��B";
						�r�[�v��();
						tex�Z���P.Focus();
						Cursor = System.Windows.Forms.Cursors.Default;
						return;
					}
				}
				catch (System.Net.WebException)
				{
					sChkList[0] = gs�ʐM�G���[;
					Cursor = System.Windows.Forms.Cursors.Default;
					tex���b�Z�[�W.Text = sChkList[0];
					tex�Z���P.Focus();
					�r�[�v��();
					return;
				}
				catch (Exception ex)
				{
					sChkList[0] = "�ʐM�G���[�F" + ex.Message;
					Cursor = System.Windows.Forms.Cursors.Default;
					tex���b�Z�[�W.Text = sChkList[0];
					tex�Z���P.Focus();
					�r�[�v��();
					return;
				}
			}
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� END

			String[] sList = {""};
			try
			{
				if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
				sList = sv_otodoke.Get_Stodokesaki(gsa���[�U,gs����b�c,gs����b�c,tex�͂���R�[�h.Text);

				// �J�[�\�����f�t�H���g�ɖ߂�
				Cursor = System.Windows.Forms.Cursors.Default;
//			sUpday    = sList[14];
//���R�����g�폜�H
// MOD 2007.02.13 ���s�j���� ORA-00921����єr���G���[�Ή� START
//				sIUFlg    = sList[15];
				if(sList[15] == "U"){
//					if(s�X�V����.Length == 0) s�X�V���� = sList[14];
					s�X�V���� = sList[14];
				}else{
					s�X�V���� = "";
				}
// MOD 2007.02.13 ���s�j���� ORA-00921����єr���G���[�Ή� END

				String[] sIUList;
// MOD 2008.06.13 kcl)�X�{ ���X�R�[�h�������@�̕ύX START
//// MOD 2006.07.10 ���s�j���� �Z���b�c�̒ǉ� START
////				string[] sData = new string[19];
//				string[] sData = new string[20];
//// MOD 2006.07.10 ���s�j���� �Z���b�c�̒ǉ� END
				string[] sData = new string[21];
// MOD 2008.06.13 kcl)�X�{ ���X�R�[�h�������@�̕ύX START
				sData[0]  = tex�͂���R�[�h.Text;
				sData[1]  = tex�J�i����.Text;
				sData[2]  = tex�d�b�ԍ��P.Text;
				sData[3]  = tex�d�b�ԍ��Q.Text;
				sData[4]  = tex�d�b�ԍ��R.Text;
// MOD 2007.02.13 ���s�j���� �X�֔ԍ��̕ۑ���Q�Ή� START
//				sData[5]  = tex�X�֔ԍ��P.Text;
				sData[5]  = tex�X�֔ԍ��P.Text.PadRight(3,' ');
// MOD 2007.02.13 ���s�j���� �X�֔ԍ��̕ۑ���Q�Ή� END
				sData[6]  = tex�X�֔ԍ��Q.Text;
				sData[7]  = tex�Z���P.Text;
				sData[8]  = tex�Z���Q.Text;
				sData[9]  = tex�Z���R.Text;
				sData[10] = tex���O�P.Text;
				sData[11] = tex���O�Q.Text;
				sData[12] = tex����v.Text;
				sData[13] = tex���[��.Text;
				sData[14] = "���͂���";
				sData[15] = gs���p�҂b�c;
				sData[16] = gs����b�c;
				sData[17] = gs����b�c;
// MOD 2007.02.13 ���s�j���� ORA-00921����єr���G���[�Ή� START
//				sData[18] = sUpday;
				sData[18] = s�X�V����;
// MOD 2007.02.13 ���s�j���� ORA-00921����єr���G���[�Ή� END
// MOD 2008.11.12 ���s�j���� �Z���b�c�̎����ݒ���s��Ȃ� START
//// ADD 2006.07.10 ���s�j���� �Z���b�c�̒ǉ� START
//				sData[19] = s�Z���b�c;
//// ADD 2006.07.10 ���s�j���� �Z���b�c�̒ǉ� END
				sData[19] = tex�Z���R�[�h.Text;
// MOD 2008.11.12 ���s�j���� �Z���b�c�̎����ݒ���s��Ȃ� END
// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX START
				sData[20] = tex���X�R�[�h.Text;
// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX END

				//�C�� NOT NULL�΍� ���� Start
				for(int iCnt = 0 ; iCnt < sData.Length; iCnt++ )
				{
					if( sData[iCnt] == null 
						|| sData[iCnt].Length == 0 ) sData[iCnt] = " ";
				}
				//�C�� NOT NULL�΍� ���� End

				DialogResult result;
// MOD 2007.02.13 ���s�j���� ORA-00921����єr���G���[�Ή� START
//				if(sIUFlg == "I")
				if(s�X�V����.Length == 0)
// MOD 2007.02.13 ���s�j���� ORA-00921����єr���G���[�Ή� END
				{
					result = MessageBox.Show("�V�K�o�^���܂����H","�o�^",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						tex���b�Z�[�W.Text = "�o�^���D�D�D";

						if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
						sIUList = sv_otodoke.Ins_todokesaki(gsa���[�U,sData);
						Cursor = System.Windows.Forms.Cursors.Default;
						// ����I�����A��ʂ��N���A����
						if(sIUList[0].Length == 4)
						{
							tex�͂���R�[�h.Text = "";
							���ڃN���A();
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

						if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
						sIUList = sv_otodoke.Upd_todokesaki(gsa���[�U,sData);
						Cursor = System.Windows.Forms.Cursors.Default;
						// ����I�����A��ʂ��N���A����
						if(sIUList[0].Length == 4)
						{
							tex�͂���R�[�h.Text = "";
							���ڃN���A();
						}
						else
						{
							�r�[�v��();
							tex���b�Z�[�W.Text = sIUList[0];
						}
					}
				}
		
// MOD 2006.07.12 ���s�j�R�{ �׎呍�����̕\���Ή� START
				if(lbl�׎呍����.Text.Length != 0)
				{
					String[] sList1 = {""};
					sList1 = sv_otodoke.Get_ninushiCount(gsa���[�U,gs����b�c,gs����b�c);
// MOD 2007.02.19 FJCS�j�K�c �׎呍�����̕\���Ή� START
//					lbl�׎呍����.Text=sList1[1].ToString()+"��";
					lbl�׎呍����.Text=sList1[1].ToString()+" ��";
// MOD 2007.02.19 FJCS�j�K�c �׎呍�����̕\���Ή� END
					lbl�׎呍����.Visible=true;
				}
// MOD 2006.07.12 ���s�j�R�{ �׎呍�����̕\���Ή� END
			
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

		private void btn�폜_Click(object sender, System.EventArgs e)
		{
			// �󔒏���
			tex�͂���R�[�h.Text = tex�͂���R�[�h.Text.Trim();

			if(!�K�{�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;
			if(!���p�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;
			
			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			String[] sList = {""};
			try
			{
				if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
				sList = sv_otodoke.Get_Stodokesaki(gsa���[�U,gs����b�c,gs����b�c,tex�͂���R�[�h.Text.Trim());
//			sUpday    = sList[14];
//���R�����g�폜�H
// MOD 2007.02.13 ���s�j���� ORA-00921����єr���G���[�Ή� START
//				sIUFlg    = sList[15];
				if(sList[15] == "U"){
//					if(s�X�V����.Length == 0) s�X�V���� = sList[14];
					s�X�V���� = sList[14];
				}else{
					s�X�V���� = "";
				}
// MOD 2007.02.13 ���s�j���� ORA-00921����єr���G���[�Ή� END

				Cursor = System.Windows.Forms.Cursors.Default;

				String[] sDList;
				string[] sData = new string[5];

				DialogResult result;
// MOD 2007.02.13 ���s�j���� ORA-00921����єr���G���[�Ή� START
//				if(sIUFlg == "I")
				if(s�X�V����.Length == 0)
// MOD 2007.02.13 ���s�j���� ORA-00921����єr���G���[�Ή� END
					MessageBox.Show("�R�[�h(" + tex�͂���R�[�h.Text + ")�̃f�[�^�͑��݂��܂���","�폜",MessageBoxButtons.OK);
				else
				{
					result = MessageBox.Show("�R�[�h(" + tex�͂���R�[�h.Text + ")�̃f�[�^���폜���܂����H","�폜",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						tex���b�Z�[�W.Text = "�폜���D�D�D";
						sData[0] = gs����b�c;
						sData[1] = gs����b�c;
						sData[2] = tex�͂���R�[�h.Text.Trim();
						sData[3] = "���͂���";
						sData[4] = gs���p�҂b�c;

						Cursor = System.Windows.Forms.Cursors.AppStarting;

						if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
						sDList = sv_otodoke.Del_todokesaki(gsa���[�U,sData);
//						Cursor = System.Windows.Forms.Cursors.Default;

						// [����I��]���A��ʂ��N���A����
						if(sDList[0].Length == 4)
						{
							tex�͂���R�[�h.Text = "";
							btn���_Click(sender,e);
						}
						else
						{
							�r�[�v��();
							tex���b�Z�[�W.Text = sDList[0];
						}
// MOD 2006.07.12 ���s�j�R�{ �׎呍�����̕\���Ή� START
						if(lbl�׎呍����.Text.Length != 0)
						{
							String[] sList1 = {""};
							sList1 = sv_otodoke.Get_ninushiCount(gsa���[�U,gs����b�c,gs����b�c);
// MOD 2007.02.19 FJCS�j�K�c �׎呍�����̕\���Ή� START
//							lbl�׎呍����.Text=sList1[1].ToString()+"��";
							lbl�׎呍����.Text=sList1[1].ToString()+" ��";
// MOD 2007.02.19 FJCS�j�K�c �׎呍�����̕\���Ή� END
							lbl�׎呍����.Visible=true;
						}
// MOD 2006.07.12 ���s�j�R�{ �׎呍�����̕\���Ή� END
					}
					Cursor = System.Windows.Forms.Cursors.Default;
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

		private void ���ڃN���A()
		{
//			tex�͂���R�[�h.Text = "";
			tex�J�i����.Text     = "";
			tex�d�b�ԍ��P.Text   = "";
			tex�d�b�ԍ��Q.Text   = "";
			tex�d�b�ԍ��R.Text   = "";
			tex�X�֔ԍ��P.Text   = "";
			tex�X�֔ԍ��Q.Text   = "";
			tex�Z���P.Text       = "";
			tex�Z���Q.Text       = "";
			tex�Z���R.Text       = "";
			tex���O�P.Text       = "";
			tex���O�Q.Text       = "";
			tex����v.Text       = "";
			tex���[��.Text       = "";
// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX START
			tex�Z���R�[�h.Text   = "";
			tex���X�R�[�h.Text   = "";
// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX START
			tex���b�Z�[�W.Text   = "";
// ADD 2007.02.13 ���s�j���� ORA-00921����єr���G���[�Ή� START
			s�X�V����            = "";
// ADD 2007.02.13 ���s�j���� ORA-00921����єr���G���[�Ή� END
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� START
			// ���b�N������
			tex�X�֔ԍ��P.Enabled = true; // �X�֔ԍ��P
			tex�X�֔ԍ��Q.Enabled = true; // �X�֔ԍ��Q
			tex�Z���P.Enabled = true; // �Z���P
			tex�Z���Q.Enabled = true; // �Z���Q
			tex�Z���R.Enabled = true; // �Z���R
			// �x�X�~�߃{�^����\���A�����{�^�����\��
			btn�x�X�~��.Visible = true;
			btn�x�X�~�߉���.Visible = false;
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� END
			tex�͂���R�[�h.Focus();
		}
		
		private void btn���_Click(object sender, System.EventArgs e)
		{
			���ڃN���A();
		}

		private void tex�͂���R�[�h_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				if(tex�͂���R�[�h.Text.Trim().Length == 0)
				{
					btn�͂��挟��.Focus();
					btn�͂��挟��_Click(sender, e);
				}
				else
				{
					btn�͂�����s_Click(sender, e);
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
//				tex�Z���R.Text = tex�Z���R.Text.Trim();
				if(gs�I�v�V����[18].Equals("1")){
					tex�Z���P.Text = tex�Z���P.Text.TrimEnd();
					tex�Z���Q.Text = tex�Z���Q.Text.TrimEnd();
					tex�Z���R.Text = tex�Z���R.Text.TrimEnd();
				}else{
					tex�Z���P.Text = tex�Z���P.Text.Trim();
					tex�Z���Q.Text = tex�Z���Q.Text.Trim();
					tex�Z���R.Text = tex�Z���R.Text.Trim();
				}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END

				// ���̓`�F�b�N
				if(!���p�`�F�b�N(tex�X�֔ԍ��P,"�X�֔ԍ��P")) return;
				if(!���p�`�F�b�N(tex�X�֔ԍ��Q,"�X�֔ԍ��Q")) return;

				string s�X�֔ԍ� = tex�X�֔ԍ��P.Text + tex�X�֔ԍ��Q.Text;
				if(s�X�֔ԍ�.Length == 7)
				{
					if(tex�Z���P.Text.Length == 0 && tex�Z���Q.Text.Length == 0 && tex�Z���R.Text.Length == 0)
					{
						// �J�[�\���������v�ɂ���
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						string[] sRet = {""};
						try
						{
							tex���b�Z�[�W.Text = "�������D�D�D";
// MOD 2015.05.07 BEVAS�j�O�c ���q�^���X�֔ԍ����݃`�F�b�N�Ή� START
							//if(sv_address == null) sv_address = new is2address.Service1();
							//sRet = sv_address.Get_byPostcode2(gsa���[�U,s�X�֔ԍ�);
							sRet = �b�l�P�S�X�֔ԍ����݃`�F�b�N(s�X�֔ԍ�);
// MOD 2015.05.07 BEVAS�j�O�c ���q�^���X�֔ԍ����݃`�F�b�N�Ή� END
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
							if(sRet[2].Length > 60){
								tex�Z���P.Text     = sRet[2].Substring(0,20);
								tex�Z���Q.Text     = sRet[2].Substring(20,20);
								tex�Z���R.Text     = sRet[2].Substring(40,20);
							}else if(sRet[2].Length > 40){
								tex�Z���P.Text     = sRet[2].Substring(0,20);
								tex�Z���Q.Text     = sRet[2].Substring(20,20);
								tex�Z���R.Text     = sRet[2].Substring(40);
							}else if(sRet[2].Length > 20){
								tex�Z���P.Text     = sRet[2].Substring(0,20);
								tex�Z���Q.Text     = sRet[2].Substring(20);
								tex�Z���R.Text     = "";
							}else{
								tex�Z���P.Text     = sRet[2];
								tex�Z���Q.Text     = "";
								tex�Z���R.Text     = "";
							}
							tex���b�Z�[�W.Text = "";
							//�t�H�[�J�X�ݒ�
							tex�Z���Q.Focus();
						}else{
							//�t�H�[�J�X�ݒ�
							if(sRet[0].Equals("�Y���f�[�^������܂���"))
								sRet[0] = "�X�֔ԍ������݂��܂���";
							tex���b�Z�[�W.Text = sRet[0];
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

		private void tex�͂���R�[�h_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn�͂��挟��.Focus();
				btn�͂��挟��_Click(sender,e);
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
				btn�Z������_Click(sender,e);
				e.Handled = true;
			}		
		}

		private void btn�ꗗ�\_Click(object sender, System.EventArgs e)
		{
			tex���b�Z�[�W.Text = "���͂���ꗗ������D�D�D";
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				if(sv_print == null) sv_print = new is2print.Service1();
				string[] sKey = new string[3];
				sKey[0] = gs����b�c;
				sKey[1] = gs����b�c;

				string[] sRet = new string[1];
				IEnumerator iEnum = sv_print.Get_ConsigneePrintData(gsa���[�U,sKey).GetEnumerator();
				iEnum.MoveNext();
				sRet = (string[])iEnum.Current;
// DEL 2005.05.11 ���s�j���� �u����I���v�͕\�����Ȃ� START
//				tex���b�Z�[�W.Text = sRet[0];
// DEL 2005.05.11 ���s�j���� �u����I���v�͕\�����Ȃ� END
				if (sRet[0].Equals("����I��"))
				{
					���͐�f�[�^ ds = new ���͐�f�[�^();

					int iCnt = 1;
					//�f�[�^�Z�b�g�ɒl���Z�b�g
					while (iEnum.MoveNext())
					{
						string[] sList = new string[13];
						sList = (string[])iEnum.Current;
					
						���͐�f�[�^.table���͐�Row tr = (���͐�f�[�^.table���͐�Row)ds.table���͐�.NewRow();
						tr.BeginEdit();
						tr.�ԍ� = iCnt++;
						tr.�R�[�h   = sList[0].Trim();
						tr.�J�i���� = sList[1].Trim();
						if(sList[2].Trim().Length == 0)
							tr.�d�b�ԍ� = sList[3] + "-" + sList[4];
						else
							tr.�d�b�ԍ� = "(" + sList[2] + ")" + sList[3] + "-" + sList[4];
						tr.�X�֔ԍ� = sList[5] + "-" + sList[6];
						tr.�Z��     = sList[7].Trim() + sList[8].Trim() + sList[9].Trim();
						tr.���O     = sList[10].Trim() + "  " + sList[11].Trim();
						tr.����v   = sList[12].Trim();
//�ۗ� MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
///						if(gs�I�v�V����[18].Equals("1")){
							tr.�J�i���� = sList[1].TrimEnd();
							tr.�Z��     = sList[7].TrimEnd() + sList[8].TrimEnd() + sList[9].TrimEnd();
							tr.���O     = sList[10].TrimEnd() + "  " + sList[11].TrimEnd();
///						}
//�ۗ� MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
						tr.EndEdit();

						ds.table���͐�.Rows.Add(tr);					
					}
					
					���͐撠�[ cr = new ���͐撠�[();
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

// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� START
		private void ���͂���o�^_Closed(object sender, System.EventArgs e)
		{
			tex�͂���R�[�h.Text = " ";
			���ڃN���A();
			tex�͂���R�[�h.Focus();
		}
// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� END

// ADD 2005.06.08 ���s�j�ɉ� �b�r�u�o�͒ǉ� START
		private void btn�b�r�u�o��_Click(object sender, System.EventArgs e)
		{
// MOD 2010.09.22 ���s�j���� �b�r�u�o�́F[�L�����Z��]�I�����̏�Q�C�� START
			tex���b�Z�[�W.Text = "";
// MOD 2010.09.22 ���s�j���� �b�r�u�o�́F[�L�����Z��]�I�����̏�Q�C�� END
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				String[] sList;
				if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
				sList = sv_otodoke.Get_csvwrite(gsa���[�U,gs����b�c,gs����b�c);
				this.Cursor = System.Windows.Forms.Cursors.Default;

				if(sList[0].Length == 4)
				{
					sList[0] = "\"�׎�l�R�[�h\",\"�d�b�ԍ�\",\"�e�`�w�ԍ�\","
						+ "\"�Z���P\",\"�Z���Q\",\"�Z���R\","
// ADD 2005.11.08 ���s�j�ɉ� �w�b�_���ڕs���C�� START
//						+ "\"���O�P\",\"���O�Q\",\"�X�֔ԍ�\","
						+ "\"���O�P\",\"���O�Q\",\"�\��\",\"�X�֔ԍ�\","
// ADD 2005.11.08 ���s�j�ɉ� �w�b�_���ڕs���C�� END
						+ "\"�J�i����\",\"��ďo�׋敪\",\"����v\",\"���X�R�[�h\"";

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
// MOD 2010.09.22 ���s�j���� �b�r�u�o�́F[�L�����Z��]�I�����̏�Q�C�� START
//						tex���b�Z�[�W.Text = "";
// MOD 2010.09.22 ���s�j���� �b�r�u�o�́F[�L�����Z��]�I�����̏�Q�C�� END
					}
// MOD 2010.09.22 ���s�j���� �b�r�u�o�́F[�L�����Z��]�I�����̏�Q�C�� START
					tex���b�Z�[�W.Text = "";
// MOD 2010.09.22 ���s�j���� �b�r�u�o�́F[�L�����Z��]�I�����̏�Q�C�� END
				}
				else
				{
					�r�[�v��();
					tex���b�Z�[�W.Text = sList[0];
				}
			}
// ADD 2005.06.27 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
				tex���b�Z�[�W.Text = gs�ʐM�G���[;
				�r�[�v��();
			}
// ADD 2005.06.27 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch(Exception ex)
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
				tex���b�Z�[�W.Text = ex.Message;
			}
			tex�͂���R�[�h.Focus();

		}

// ADD 2005.06.08 ���s�j�ɉ� �b�r�u�o�͒ǉ� END
// MOD 2006.07.03 ���s�j�R�{ �׎呍�����̕\���Ή� START
		private void btn�����擾_Click(object sender, System.EventArgs e)
		{
			String[] sList = {""};
			if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
			sList = sv_otodoke.Get_ninushiCount(gsa���[�U,gs����b�c,gs����b�c);
// MOD 2007.02.19 FJCS�j�K�c �׎呍�����̕\���Ή� START
//			lbl�׎呍����.Text=sList[1].ToString()+"��";
			lbl�׎呍����.Text=sList[1].ToString()+" ��";
// MOD 2007.02.19 FJCS�j�K�c �׎呍�����̕\���Ή� END
			lbl�׎呍����.Visible=true;
		}

// MOD 2006.07.03 ���s�j�R�{ �׎呍�����̕\���Ή� END
		
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� START
		private void btn�x�X�~��_Click(object sender, System.EventArgs e)
		{
			// �X��������ʂ��N��
			if (g�X������ == null)
			{
				g�X������ = new �X������();
			}
			g�X������.Left = this.Left + 404;
			g�X������.Top = this.Top;
			// ��ʏ����l�̐ݒ�
			g�X������.s�X���R�[�h = "";
			g�X������.s�X���� = "";
			g�X������.s�X�������� = "";
			g�X������.s�X�֔ԍ� = "";
			g�X������.ShowDialog();

			if(g�X������.s�X���R�[�h.Length > 0)
			{
				/** �X��������ʂ���A�X���R�[�h�����p����Ă����ꍇ */
				// �X��������ʂŎ擾�����l���A�e���ڂɐݒ�
				tex�X�֔ԍ��P.Text = g�X������.s�X�֔ԍ�.Substring(0, 3); // �X�֔ԍ��P
				tex�X�֔ԍ��Q.Text = g�X������.s�X�֔ԍ�.Substring(3, 4); // �X�֔ԍ��Q
				tex�Z���P.Text = "�����x�X�~�߁���"; // �Z���P
				tex�Z���Q.Text = g�X������.s�X�������� + "�~��"; // �Z���Q
				tex�Z���R.Text = �S�p�����ϊ�(g�X������.s�X���R�[�h); // �Z���R

				// �X�֔ԍ�����яZ���P�`�R�����b�N
				tex�X�֔ԍ��P.Enabled = false; // �X�֔ԍ��P
				tex�X�֔ԍ��Q.Enabled = false; // �X�֔ԍ��Q
				tex�Z���P.Enabled = false; // �Z���P
				tex�Z���Q.Enabled = false; // �Z���Q
				tex�Z���R.Enabled = false; // �Z���R

				// �x�X�~�߃{�^�����\���A�����{�^����\��
				btn�x�X�~��.Visible = false;
				btn�x�X�~�߉���.Visible = true;

				// �t�H�[�J�X���w���O�P�x�ɐݒ�
				tex���O�P.Focus();
			}
			else
			{
				/** ����ȊO�̏ꍇ */
				// �t�H�[�J�X���w�Z���P�x�ɐݒ�
				tex�Z���P.Focus();
			}
		}

		private void btn�x�X�~�߉���_Click(object sender, System.EventArgs e)
		{
			// �X�֔ԍ�����яZ���P�`�R�̃��b�N������
			tex�X�֔ԍ��P.Enabled = true; // �X�֔ԍ��P
			tex�X�֔ԍ��Q.Enabled = true; // �X�֔ԍ��Q
			tex�Z���P.Enabled = true; // �Z���P
			tex�Z���Q.Enabled = true; // �Z���Q
			tex�Z���R.Enabled = true; // �Z���R

			// �X�֔ԍ�����яZ���P�`�R�̓��͒l���N���A
			tex�X�֔ԍ��P.Text = ""; // �X�֔ԍ��P
			tex�X�֔ԍ��Q.Text = ""; // �X�֔ԍ��Q
			tex�Z���P.Text = ""; // �Z���P
			tex�Z���Q.Text = ""; // �Z���Q
			tex�Z���R.Text = ""; // �Z���R

			// �x�X�~�߃{�^����\���A�����{�^�����\��
			btn�x�X�~��.Visible = true;
			btn�x�X�~�߉���.Visible = false;

			// �t�H�[�J�X���w�X�֔ԍ��P�x�ɐݒ�
			tex�X�֔ԍ��P.Focus();
		}
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� END

	}
}
