using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [�A�h���X��]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// ADD 2007.01.30 FJCS�j�K�c ���������ɖ��O�ǉ� 
	// MOD 2007.02.08 FJCS�j�K�c �����ύX 
	// MOD 2007.03.12 FJCS�j�K�c �G���^�[�L�[�����ɂ�錟���J�n�^�C�~���O�̕ύX 
	// ADD 2007.03.12 FJCS�j�K�c ���ڃN���A 
	//--------------------------------------------------------------------------
	// ADD 2009.01.29 ���s�j���� �ꗗ�ɖ��O�Q�A�Z���Q�A�Z���R��ǉ� 
	// MOD 2009.12.08 ���s�j���� �ňړ��N���A�����̒ǉ� 
	//--------------------------------------------------------------------------
	// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� 
	// MOD 2010.02.03 ���s�j���� ���������ɍX�V����ǉ� 
	// MOD 2010.02.03 ���s�j���� �\�[�g�����̕ێ��@�\��ǉ� 
	// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� 
	// MOD 2010.06.03 ���s�j���� �������폜�@�\�̍����� 
	// MOD 2010.09.22 ���s�j���� �폜�F[������]�I�����̏�Q�C�� 
	// MOD 2010.09.22 ���s�j���� �b�r�u�o�́F[�L�����Z��]�I�����̏�Q�C�� 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� 
	// MOD 2011.01.25 ���s�j���� �u���[�h�Ɏ��s�v�Ή� 
	//--------------------------------------------------------------------------
	public class ���͂��挟�� : ���ʃt�H�[��
	{
		public short OldRow = 0;
		private short nSrow = 0;
		private short nErow = 0;
		private short nWork = 0;

		public string sTcode = "";
		public string sTname = "";
		private short nOldRow = 0;
		public string s����;

		private string[] s�͂���ꗗ;
		private int      i���ݕŐ�;
		private int      i�ő�Ő�;
		private int      i�J�n��;
		private int      i�I����;
		private int      i�A�N�e�B�u�e�f = 0;
// ADD 2006.12.14 ���s�j�����J ���ׂ̗]�������� START
		private int      i�ōő�s�� = 100;
// ADD 2006.12.14 ���s�j�����J ���ׂ̗]�������� END
		
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Button btn����;
		private ���ʃe�L�X�g�{�b�N�X tex�͂���J�i;
		private System.Windows.Forms.Button btn�m��;
		private ���ʃe�L�X�g�{�b�N�X tex�͂���R�[�h;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.TextBox tex���b�Z�[�W;
		private System.Windows.Forms.Button btn����;
		private AxGTABLE32V2Lib.AxGTable32 axGT�͂���;
		private System.Windows.Forms.Label lab�͂���J�i;
		private System.Windows.Forms.Label lab�͂���R�[�h;
		private System.Windows.Forms.Label lab�͂���^�C�g��;
		private System.Windows.Forms.Label lab�Ŕԍ�;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Button btn�O��;
		private System.Windows.Forms.Label label1;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�d�b�ԍ�;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cb�K�w���X�g�P;
		private System.Windows.Forms.ComboBox cb�K�w���X�g�Q;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�d�b�ԍ�2;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�d�b�ԍ�3;
		private System.Windows.Forms.Button btnCSV�o��;
		private System.Windows.Forms.Button btn�ꗗ���;
		private System.Windows.Forms.Button btn�폜;
		private System.Windows.Forms.ComboBox cb�\�[�g�����P;
		private System.Windows.Forms.ComboBox cb�\�[�g�����Q;
// ADD 2006.07.05 ���s�j�b�r�u�o�͋@�\�ǉ� START
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lab�͂��於�O;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�͂��於�O;
		private System.Windows.Forms.CheckBox cb���O�Z���ڍו\��;
		private System.Windows.Forms.CheckBox cb�X�V��;
		private System.Windows.Forms.GroupBox gp����;
		private System.Windows.Forms.GroupBox gp�ꗗ;
		private System.Windows.Forms.DateTimePicker dt�X�V��;
		private System.Windows.Forms.GroupBox gp�\����;
// ADD 2006.07.05 ���s�j�b�r�u�o�͋@�\�ǉ� END
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ���͂��挟��()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
			�c�o�h�\���T�C�Y�ϊ�();
//			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
				this.axGT�͂���.Size = new System.Drawing.Size(716, 326);
//			}
// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� END
// MOD 2010.02.03 ���s�j���� �\�[�g�����̕ێ��@�\��ǉ� START
			cb�K�w���X�g�P.SelectedIndex = 1;
			cb�K�w���X�g�Q.SelectedIndex = 0;
			cb�\�[�g�����P.SelectedIndex = 0;
			cb�\�[�g�����Q.SelectedIndex = 0;
// MOD 2010.02.03 ���s�j���� �\�[�g�����̕ێ��@�\��ǉ� END
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� START
			if(gs�A�h���X��_�\�����P != null){
				cb�K�w���X�g�P.Text = gs�A�h���X��_�\�����P;
			}
			if(gs�A�h���X��_�\�����P_���� != null){
				cb�\�[�g�����P.Text = gs�A�h���X��_�\�����P_����;
			}
			if(gs�A�h���X��_�\�����Q != null){
				cb�K�w���X�g�Q.Text = gs�A�h���X��_�\�����Q;
			}
			if(gs�A�h���X��_�\�����Q_���� != null){
				cb�\�[�g�����Q.Text = gs�A�h���X��_�\�����Q_����;
			}
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� END
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(���͂��挟��));
			this.panel1 = new System.Windows.Forms.Panel();
			this.axGT�͂��� = new AxGTABLE32V2Lib.AxGTable32();
			this.lab�Ŕԍ� = new System.Windows.Forms.Label();
			this.btn���� = new System.Windows.Forms.Button();
			this.btn�O�� = new System.Windows.Forms.Button();
			this.btn�m�� = new System.Windows.Forms.Button();
			this.panel5 = new System.Windows.Forms.Panel();
			this.gp�\���� = new System.Windows.Forms.GroupBox();
			this.cb�\�[�g�����P = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cb�K�w���X�g�P = new System.Windows.Forms.ComboBox();
			this.cb�K�w���X�g�Q = new System.Windows.Forms.ComboBox();
			this.cb�\�[�g�����Q = new System.Windows.Forms.ComboBox();
			this.dt�X�V�� = new System.Windows.Forms.DateTimePicker();
			this.cb�X�V�� = new System.Windows.Forms.CheckBox();
			this.cb���O�Z���ڍו\�� = new System.Windows.Forms.CheckBox();
			this.tex�͂��於�O = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab�͂��於�O = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.tex�d�b�ԍ�2 = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tex�d�b�ԍ�3 = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�d�b�ԍ� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�͂���J�i = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab�͂���J�i = new System.Windows.Forms.Label();
			this.lab�͂���R�[�h = new System.Windows.Forms.Label();
			this.tex�͂���R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.btn���� = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab�͂���^�C�g�� = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn�폜 = new System.Windows.Forms.Button();
			this.btn�ꗗ��� = new System.Windows.Forms.Button();
			this.btnCSV�o�� = new System.Windows.Forms.Button();
			this.btn���� = new System.Windows.Forms.Button();
			this.tex���b�Z�[�W = new System.Windows.Forms.TextBox();
			this.btn���� = new System.Windows.Forms.Button();
			this.panel6 = new System.Windows.Forms.Panel();
			this.gp���� = new System.Windows.Forms.GroupBox();
			this.gp�ꗗ = new System.Windows.Forms.GroupBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axGT�͂���)).BeginInit();
			this.panel5.SuspendLayout();
			this.gp�\����.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.gp����.SuspendLayout();
			this.gp�ꗗ.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Honeydew;
			this.panel1.Controls.Add(this.axGT�͂���);
			this.panel1.Controls.Add(this.lab�Ŕԍ�);
			this.panel1.Controls.Add(this.btn����);
			this.panel1.Controls.Add(this.btn�O��);
			this.panel1.Controls.Add(this.btn�m��);
			this.panel1.Location = new System.Drawing.Point(1, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(739, 360);
			this.panel1.TabIndex = 0;
			// 
			// axGT�͂���
			// 
			this.axGT�͂���.ContainingControl = this;
			this.axGT�͂���.DataSource = null;
			this.axGT�͂���.Location = new System.Drawing.Point(14, 4);
			this.axGT�͂���.Name = "axGT�͂���";
			this.axGT�͂���.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT�͂���.OcxState")));
			this.axGT�͂���.Size = new System.Drawing.Size(716, 326);
			this.axGT�͂���.TabIndex = 0;
			this.axGT�͂���.KeyDownEvent += new AxGTABLE32V2Lib._DGTable32Events_KeyDownEventHandler(this.axGT�͂���_KeyDownEvent);
			this.axGT�͂���.CelClick += new AxGTABLE32V2Lib._DGTable32Events_CelClickEventHandler(this.axGT�͂���_CelClick);
			this.axGT�͂���.CelDblClick += new AxGTABLE32V2Lib._DGTable32Events_CelDblClickEventHandler(this.axGT�͂���_CelDblClick);
			this.axGT�͂���.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT�͂���_CurPlaceChanged);
			// 
			// lab�Ŕԍ�
			// 
			this.lab�Ŕԍ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�Ŕԍ�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�Ŕԍ�.Location = new System.Drawing.Point(518, 338);
			this.lab�Ŕԍ�.Name = "lab�Ŕԍ�";
			this.lab�Ŕԍ�.Size = new System.Drawing.Size(56, 14);
			this.lab�Ŕԍ�.TabIndex = 67;
			this.lab�Ŕԍ�.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn����
			// 
			this.btn����.BackColor = System.Drawing.Color.SteelBlue;
			this.btn����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn����.ForeColor = System.Drawing.Color.White;
			this.btn����.Location = new System.Drawing.Point(576, 334);
			this.btn����.Name = "btn����";
			this.btn����.Size = new System.Drawing.Size(48, 22);
			this.btn����.TabIndex = 66;
			this.btn����.Text = "����";
			this.btn����.Click += new System.EventHandler(this.btn����_Click);
			// 
			// btn�O��
			// 
			this.btn�O��.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�O��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�O��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�O��.ForeColor = System.Drawing.Color.White;
			this.btn�O��.Location = new System.Drawing.Point(468, 334);
			this.btn�O��.Name = "btn�O��";
			this.btn�O��.Size = new System.Drawing.Size(48, 22);
			this.btn�O��.TabIndex = 65;
			this.btn�O��.Text = "�O��";
			this.btn�O��.Click += new System.EventHandler(this.btn�O��_Click);
			// 
			// btn�m��
			// 
			this.btn�m��.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�m��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�m��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�m��.ForeColor = System.Drawing.Color.White;
			this.btn�m��.Location = new System.Drawing.Point(648, 334);
			this.btn�m��.Name = "btn�m��";
			this.btn�m��.Size = new System.Drawing.Size(64, 22);
			this.btn�m��.TabIndex = 1;
			this.btn�m��.TabStop = false;
			this.btn�m��.Text = "�m��";
			this.btn�m��.Click += new System.EventHandler(this.btn�m��_Click);
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.Honeydew;
			this.panel5.Controls.Add(this.gp�\����);
			this.panel5.Controls.Add(this.dt�X�V��);
			this.panel5.Controls.Add(this.cb�X�V��);
			this.panel5.Controls.Add(this.cb���O�Z���ڍו\��);
			this.panel5.Controls.Add(this.tex�͂��於�O);
			this.panel5.Controls.Add(this.lab�͂��於�O);
			this.panel5.Controls.Add(this.label8);
			this.panel5.Controls.Add(this.tex�d�b�ԍ�2);
			this.panel5.Controls.Add(this.label7);
			this.panel5.Controls.Add(this.label6);
			this.panel5.Controls.Add(this.tex�d�b�ԍ�3);
			this.panel5.Controls.Add(this.tex�d�b�ԍ�);
			this.panel5.Controls.Add(this.tex�͂���J�i);
			this.panel5.Controls.Add(this.lab�͂���J�i);
			this.panel5.Controls.Add(this.lab�͂���R�[�h);
			this.panel5.Controls.Add(this.tex�͂���R�[�h);
			this.panel5.Controls.Add(this.btn����);
			this.panel5.Controls.Add(this.label5);
			this.panel5.Location = new System.Drawing.Point(2, 6);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(738, 88);
			this.panel5.TabIndex = 0;
			// 
			// gp�\����
			// 
			this.gp�\����.Controls.Add(this.cb�\�[�g�����P);
			this.gp�\����.Controls.Add(this.label4);
			this.gp�\����.Controls.Add(this.label3);
			this.gp�\����.Controls.Add(this.cb�K�w���X�g�P);
			this.gp�\����.Controls.Add(this.cb�K�w���X�g�Q);
			this.gp�\����.Controls.Add(this.cb�\�[�g�����Q);
			this.gp�\����.Location = new System.Drawing.Point(498, -2);
			this.gp�\����.Name = "gp�\����";
			this.gp�\����.Size = new System.Drawing.Size(236, 60);
			this.gp�\����.TabIndex = 57;
			this.gp�\����.TabStop = false;
			// 
			// cb�\�[�g�����P
			// 
			this.cb�\�[�g�����P.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb�\�[�g�����P.Items.AddRange(new object[] {
														  "����",
														  "�~��"});
			this.cb�\�[�g�����P.Location = new System.Drawing.Point(170, 10);
			this.cb�\�[�g�����P.Name = "cb�\�[�g�����P";
			this.cb�\�[�g�����P.Size = new System.Drawing.Size(60, 20);
			this.cb�\�[�g�����P.TabIndex = 10;
			this.cb�\�[�g�����P.Visible = false;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label4.ForeColor = System.Drawing.Color.LimeGreen;
			this.label4.Location = new System.Drawing.Point(6, 36);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 49;
			this.label4.Text = "�\�����Q";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label3.ForeColor = System.Drawing.Color.LimeGreen;
			this.label3.Location = new System.Drawing.Point(6, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 48;
			this.label3.Text = "�\�����P";
			// 
			// cb�K�w���X�g�P
			// 
			this.cb�K�w���X�g�P.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb�K�w���X�g�P.Items.AddRange(new object[] {
														  "",
														  "�J�i����",
														  "���͂���R�[�h",
														  "�d�b�ԍ�",
														  "���O",
														  "�o�^����",
														  "�X�V����"});
			this.cb�K�w���X�g�P.Location = new System.Drawing.Point(70, 10);
			this.cb�K�w���X�g�P.Name = "cb�K�w���X�g�P";
			this.cb�K�w���X�g�P.Size = new System.Drawing.Size(96, 20);
			this.cb�K�w���X�g�P.TabIndex = 9;
			this.cb�K�w���X�g�P.SelectedIndexChanged += new System.EventHandler(this.cb�K�w�P�I��_select);
			// 
			// cb�K�w���X�g�Q
			// 
			this.cb�K�w���X�g�Q.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb�K�w���X�g�Q.Items.AddRange(new object[] {
														  "",
														  "�J�i����",
														  "���͂���R�[�h",
														  "�d�b�ԍ�",
														  "���O",
														  "�o�^����",
														  "�X�V����"});
			this.cb�K�w���X�g�Q.Location = new System.Drawing.Point(70, 34);
			this.cb�K�w���X�g�Q.Name = "cb�K�w���X�g�Q";
			this.cb�K�w���X�g�Q.Size = new System.Drawing.Size(96, 20);
			this.cb�K�w���X�g�Q.TabIndex = 11;
			this.cb�K�w���X�g�Q.SelectedIndexChanged += new System.EventHandler(this.cb�K�w�Q�I��_select);
			// 
			// cb�\�[�g�����Q
			// 
			this.cb�\�[�g�����Q.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb�\�[�g�����Q.Items.AddRange(new object[] {
														  "����",
														  "�~��"});
			this.cb�\�[�g�����Q.Location = new System.Drawing.Point(170, 34);
			this.cb�\�[�g�����Q.Name = "cb�\�[�g�����Q";
			this.cb�\�[�g�����Q.Size = new System.Drawing.Size(60, 20);
			this.cb�\�[�g�����Q.TabIndex = 12;
			this.cb�\�[�g�����Q.Visible = false;
			// 
			// dt�X�V��
			// 
			this.dt�X�V��.Enabled = false;
			this.dt�X�V��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.dt�X�V��.Location = new System.Drawing.Point(344, 4);
			this.dt�X�V��.Name = "dt�X�V��";
			this.dt�X�V��.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.dt�X�V��.Size = new System.Drawing.Size(144, 23);
			this.dt�X�V��.TabIndex = 2;
			// 
			// cb�X�V��
			// 
			this.cb�X�V��.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold);
			this.cb�X�V��.ForeColor = System.Drawing.Color.LimeGreen;
			this.cb�X�V��.Location = new System.Drawing.Point(272, 4);
			this.cb�X�V��.Name = "cb�X�V��";
			this.cb�X�V��.Size = new System.Drawing.Size(72, 24);
			this.cb�X�V��.TabIndex = 1;
			this.cb�X�V��.Text = "�X�V��";
			this.cb�X�V��.CheckedChanged += new System.EventHandler(this.cb�X�V��_CheckedChanged);
			// 
			// cb���O�Z���ڍו\��
			// 
			this.cb���O�Z���ڍו\��.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold);
			this.cb���O�Z���ڍו\��.ForeColor = System.Drawing.Color.LimeGreen;
			this.cb���O�Z���ڍו\��.Location = new System.Drawing.Point(272, 32);
			this.cb���O�Z���ڍו\��.Name = "cb���O�Z���ڍו\��";
			this.cb���O�Z���ڍו\��.Size = new System.Drawing.Size(172, 24);
			this.cb���O�Z���ڍו\��.TabIndex = 6;
			this.cb���O�Z���ڍו\��.Text = "���O�E�Z���ڍו\��";
			// 
			// tex�͂��於�O
			// 
			this.tex�͂��於�O.BackColor = System.Drawing.SystemColors.Window;
			this.tex�͂��於�O.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�͂��於�O.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�͂��於�O.Location = new System.Drawing.Point(254, 60);
			this.tex�͂��於�O.MaxLength = 20;
			this.tex�͂��於�O.Name = "tex�͂��於�O";
			this.tex�͂��於�O.Size = new System.Drawing.Size(234, 23);
			this.tex�͂��於�O.TabIndex = 8;
			this.tex�͂��於�O.Text = "";
			this.tex�͂��於�O.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�͂��於�O_KeyDown);
			// 
			// lab�͂��於�O
			// 
			this.lab�͂��於�O.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�͂��於�O.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�͂��於�O.Location = new System.Drawing.Point(214, 62);
			this.lab�͂��於�O.Name = "lab�͂��於�O";
			this.lab�͂��於�O.Size = new System.Drawing.Size(38, 16);
			this.lab�͂��於�O.TabIndex = 56;
			this.lab�͂��於�O.Text = "���O";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label8.ForeColor = System.Drawing.Color.LimeGreen;
			this.label8.Location = new System.Drawing.Point(92, 36);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(10, 16);
			this.label8.TabIndex = 3;
			this.label8.Text = "�i";
			// 
			// tex�d�b�ԍ�2
			// 
			this.tex�d�b�ԍ�2.BackColor = System.Drawing.SystemColors.Window;
			this.tex�d�b�ԍ�2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�d�b�ԍ�2.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�d�b�ԍ�2.Location = new System.Drawing.Point(154, 32);
			this.tex�d�b�ԍ�2.MaxLength = 4;
			this.tex�d�b�ԍ�2.Name = "tex�d�b�ԍ�2";
			this.tex�d�b�ԍ�2.Size = new System.Drawing.Size(42, 23);
			this.tex�d�b�ԍ�2.TabIndex = 4;
			this.tex�d�b�ԍ�2.Text = "";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label7.ForeColor = System.Drawing.Color.LimeGreen;
			this.label7.Location = new System.Drawing.Point(192, 36);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(18, 16);
			this.label7.TabIndex = 54;
			this.label7.Text = "�|";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label6.ForeColor = System.Drawing.Color.LimeGreen;
			this.label6.Location = new System.Drawing.Point(144, 36);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(8, 16);
			this.label6.TabIndex = 2;
			this.label6.Text = "�j";
			// 
			// tex�d�b�ԍ�3
			// 
			this.tex�d�b�ԍ�3.BackColor = System.Drawing.SystemColors.Window;
			this.tex�d�b�ԍ�3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�d�b�ԍ�3.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�d�b�ԍ�3.Location = new System.Drawing.Point(210, 32);
			this.tex�d�b�ԍ�3.MaxLength = 5;
			this.tex�d�b�ԍ�3.Name = "tex�d�b�ԍ�3";
			this.tex�d�b�ԍ�3.Size = new System.Drawing.Size(50, 23);
			this.tex�d�b�ԍ�3.TabIndex = 5;
			this.tex�d�b�ԍ�3.Text = "";
			// 
			// tex�d�b�ԍ�
			// 
			this.tex�d�b�ԍ�.BackColor = System.Drawing.SystemColors.Window;
			this.tex�d�b�ԍ�.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�d�b�ԍ�.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�d�b�ԍ�.Location = new System.Drawing.Point(104, 32);
			this.tex�d�b�ԍ�.MaxLength = 4;
			this.tex�d�b�ԍ�.Name = "tex�d�b�ԍ�";
			this.tex�d�b�ԍ�.Size = new System.Drawing.Size(42, 23);
			this.tex�d�b�ԍ�.TabIndex = 3;
			this.tex�d�b�ԍ�.Text = "";
			// 
			// tex�͂���J�i
			// 
			this.tex�͂���J�i.BackColor = System.Drawing.SystemColors.Window;
			this.tex�͂���J�i.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�͂���J�i.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
			this.tex�͂���J�i.Location = new System.Drawing.Point(104, 60);
			this.tex�͂���J�i.MaxLength = 10;
			this.tex�͂���J�i.Name = "tex�͂���J�i";
			this.tex�͂���J�i.Size = new System.Drawing.Size(104, 23);
			this.tex�͂���J�i.TabIndex = 7;
			this.tex�͂���J�i.Text = "";
			// 
			// lab�͂���J�i
			// 
			this.lab�͂���J�i.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�͂���J�i.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�͂���J�i.Location = new System.Drawing.Point(6, 62);
			this.lab�͂���J�i.Name = "lab�͂���J�i";
			this.lab�͂���J�i.Size = new System.Drawing.Size(70, 16);
			this.lab�͂���J�i.TabIndex = 46;
			this.lab�͂���J�i.Text = "�J�i����";
			// 
			// lab�͂���R�[�h
			// 
			this.lab�͂���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�͂���R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�͂���R�[�h.Location = new System.Drawing.Point(6, 8);
			this.lab�͂���R�[�h.Name = "lab�͂���R�[�h";
			this.lab�͂���R�[�h.Size = new System.Drawing.Size(96, 16);
			this.lab�͂���R�[�h.TabIndex = 6;
			this.lab�͂���R�[�h.Text = "���͂���R�[�h";
			// 
			// tex�͂���R�[�h
			// 
			this.tex�͂���R�[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex�͂���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�͂���R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�͂���R�[�h.Location = new System.Drawing.Point(104, 4);
			this.tex�͂���R�[�h.MaxLength = 15;
			this.tex�͂���R�[�h.Name = "tex�͂���R�[�h";
			this.tex�͂���R�[�h.Size = new System.Drawing.Size(150, 23);
			this.tex�͂���R�[�h.TabIndex = 0;
			this.tex�͂���R�[�h.Text = "";
			// 
			// btn����
			// 
			this.btn����.BackColor = System.Drawing.Color.SteelBlue;
			this.btn����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn����.ForeColor = System.Drawing.Color.White;
			this.btn����.Location = new System.Drawing.Point(496, 60);
			this.btn����.Name = "btn����";
			this.btn����.Size = new System.Drawing.Size(64, 22);
			this.btn����.TabIndex = 13;
			this.btn����.TabStop = false;
			this.btn����.Text = "����";
			this.btn����.Click += new System.EventHandler(this.btn����_Click);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label5.ForeColor = System.Drawing.Color.LimeGreen;
			this.label5.Location = new System.Drawing.Point(6, 36);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 16);
			this.label5.TabIndex = 50;
			this.label5.Text = "�d�b�ԍ�";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.lab�͂���^�C�g��);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(794, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab�͂���^�C�g��
			// 
			this.lab�͂���^�C�g��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�͂���^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�͂���^�C�g��.ForeColor = System.Drawing.Color.White;
			this.lab�͂���^�C�g��.Location = new System.Drawing.Point(12, 2);
			this.lab�͂���^�C�g��.Name = "lab�͂���^�C�g��";
			this.lab�͂���^�C�g��.Size = new System.Drawing.Size(264, 24);
			this.lab�͂���^�C�g��.TabIndex = 0;
			this.lab�͂���^�C�g��.Text = "�A�h���X��";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn�폜);
			this.panel8.Controls.Add(this.btn�ꗗ���);
			this.panel8.Controls.Add(this.btnCSV�o��);
			this.panel8.Controls.Add(this.btn����);
			this.panel8.Controls.Add(this.tex���b�Z�[�W);
			this.panel8.Controls.Add(this.btn����);
			this.panel8.Location = new System.Drawing.Point(0, 518);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(794, 58);
			this.panel8.TabIndex = 7;
			// 
			// btn�폜
			// 
			this.btn�폜.ForeColor = System.Drawing.Color.Blue;
			this.btn�폜.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�폜.Location = new System.Drawing.Point(206, 6);
			this.btn�폜.Name = "btn�폜";
			this.btn�폜.Size = new System.Drawing.Size(62, 48);
			this.btn�폜.TabIndex = 5;
			this.btn�폜.Text = "�폜";
			this.btn�폜.Visible = false;
			this.btn�폜.Click += new System.EventHandler(this.btn�폜_Click);
			// 
			// btn�ꗗ���
			// 
			this.btn�ꗗ���.ForeColor = System.Drawing.Color.Blue;
			this.btn�ꗗ���.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�ꗗ���.Location = new System.Drawing.Point(276, 6);
			this.btn�ꗗ���.Name = "btn�ꗗ���";
			this.btn�ꗗ���.Size = new System.Drawing.Size(62, 48);
			this.btn�ꗗ���.TabIndex = 4;
			this.btn�ꗗ���.Text = "�ꗗ�\�@���";
			this.btn�ꗗ���.Visible = false;
			this.btn�ꗗ���.Click += new System.EventHandler(this.btn�ꗗ���_Click);
			// 
			// btnCSV�o��
			// 
			this.btnCSV�o��.ForeColor = System.Drawing.Color.Blue;
			this.btnCSV�o��.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnCSV�o��.Location = new System.Drawing.Point(346, 5);
			this.btnCSV�o��.Name = "btnCSV�o��";
			this.btnCSV�o��.Size = new System.Drawing.Size(62, 48);
			this.btnCSV�o��.TabIndex = 3;
			this.btnCSV�o��.Text = "�b�r�u�@�@�o��";
			this.btnCSV�o��.Visible = false;
			this.btnCSV�o��.Click += new System.EventHandler(this.btnCSV�o��_Click);
			// 
			// btn����
			// 
			this.btn����.ForeColor = System.Drawing.Color.Blue;
			this.btn����.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn����.Location = new System.Drawing.Point(98, 6);
			this.btn����.Name = "btn����";
			this.btn����.Size = new System.Drawing.Size(62, 48);
			this.btn����.TabIndex = 1;
			this.btn����.Text = "����";
			this.btn����.Visible = false;
			this.btn����.Click += new System.EventHandler(this.btn����_Click);
			// 
			// tex���b�Z�[�W
			// 
			this.tex���b�Z�[�W.BackColor = System.Drawing.Color.PaleGreen;
			this.tex���b�Z�[�W.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���b�Z�[�W.ForeColor = System.Drawing.Color.Red;
			this.tex���b�Z�[�W.Location = new System.Drawing.Point(414, 4);
			this.tex���b�Z�[�W.Multiline = true;
			this.tex���b�Z�[�W.Name = "tex���b�Z�[�W";
			this.tex���b�Z�[�W.ReadOnly = true;
			this.tex���b�Z�[�W.Size = new System.Drawing.Size(376, 50);
			this.tex���b�Z�[�W.TabIndex = 2;
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
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.PaleGreen;
			this.panel6.Location = new System.Drawing.Point(0, 26);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(794, 26);
			this.panel6.TabIndex = 15;
			// 
			// gp����
			// 
			this.gp����.Controls.Add(this.panel5);
			this.gp����.Location = new System.Drawing.Point(26, 52);
			this.gp����.Name = "gp����";
			this.gp����.Size = new System.Drawing.Size(742, 96);
			this.gp����.TabIndex = 0;
			this.gp����.TabStop = false;
			// 
			// gp�ꗗ
			// 
			this.gp�ꗗ.Controls.Add(this.panel1);
			this.gp�ꗗ.Location = new System.Drawing.Point(26, 148);
			this.gp�ꗗ.Name = "gp�ꗗ";
			this.gp�ꗗ.Size = new System.Drawing.Size(742, 368);
			this.gp�ꗗ.TabIndex = 6;
			this.gp�ꗗ.TabStop = false;
			// 
			// ���͂��挟��
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 574);
			this.Controls.Add(this.gp�ꗗ);
			this.Controls.Add(this.gp����);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "���͂��挟��";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 �A�h���X��";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Closed += new System.EventHandler(this.���͂��挟��_Closed);
			this.Activated += new System.EventHandler(this.���͂��挟��_Activated);
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axGT�͂���)).EndInit();
			this.panel5.ResumeLayout(false);
			this.gp�\����.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.gp����.ResumeLayout(false);
			this.gp�ꗗ.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			i�A�N�e�B�u�e�f = 0;
			tex�͂���R�[�h.Text = sTcode;
			sTcode = "";
			s���� = "";
// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� START
//			axGT�͂���.Cols = 5;
			axGT�͂���.Cols = 13;
// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� END
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� START
// MOD 2006.07.05 ���s�j�R�{ �P�y�[�W�\���s���̕ύX�i�X�N���[���j�Ή� START
////		axGT�͂���.Rows = 16;
//			axGT�͂���.Rows = 100;
// MOD 2006.07.05 ���s�j�R�{ �P�y�[�W�\���s���̕ύX�i�X�N���[���j�Ή� END
			axGT�͂���.Rows = 16;
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� END
			axGT�͂���.ColSep = "|";

// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� START
//// MOD 2007.02.08 FJCS�j�K�c �����ύX START
////			axGT�͂���.set_RowsText(0, "|���O|�Z��|�G���g���[�R�[�h|�d�b�ԍ�|�J�i����|");
//			axGT�͂���.set_RowsText(0, "|���O|�Z��|���͂���R�[�h|�d�b�ԍ�|�J�i����|");
//// MOD 2007.02.08 FJCS�j�K�c �����ύX END
//
//			axGT�͂���.ColsWidth = "0|14.2|14.2|9.7|8.6|7|";
//			axGT�͂���.ColsAlignHorz = "1|0|0|0|0|0|";

			axGT�͂���.set_RowsText(0, "|���O|�Z��|���͂���R�[�h|�d�b�ԍ�|�J�i����|�X�֔ԍ�|����v|���[���A�h���X|�Z���R�[�h|���X|�o�^����|�X�V����|����-�g�p��|");
			axGT�͂���.ColsWidth = "0|14.2|14.2|9.7|8.6|7|4.2|0|0|0|0|9.2|9.2|5.8|";
			axGT�͂���.ColsAlignHorz = "1|0|0|0|0|0|1|0|0|0|1|1|1|1|";
// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� END

//			axGT�͂���.set_CelForeColor(axGT�͂���.CaretRow,0,111111);
			axGT�͂���.set_CelForeColor(axGT�͂���.CaretRow,0,0x98FB98);  //BGR
			axGT�͂���.set_CelBackColor(axGT�͂���.CaretRow,0,0x006000);
			
			btn�O��.Enabled = false;
			btn����.Enabled = false;
			lab�Ŕԍ�.Text = "";

// MOD 2010.02.03 ���s�j���� �\�[�g�����̕ێ��@�\��ǉ� START
//// ADD 2006.07.04 ���s�j�R�{ �\�[�g�@�\�ǉ� START
//			cb�K�w���X�g�P.SelectedIndex = 1;
//			cb�K�w���X�g�Q.SelectedIndex = 0;
//			cb�\�[�g�����P.SelectedIndex = 0;
//			cb�\�[�g�����Q.SelectedIndex = 0;
//// ADD 2006.07.04 ���s�j�R�{ �\�[�g�@�\�ǉ� END
// MOD 2010.02.03 ���s�j���� �\�[�g�����̕ێ��@�\��ǉ� END
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			sTcode = "";
			this.Close();
		}

		public void Visible����()
		{
			btn����.Visible = true;
		}

		private void axGT�͂���_CelDblClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelDblClickEvent e)
		{
			sTname = axGT�͂���.get_CelText(axGT�͂���.CaretRow,1);
			sTcode = axGT�͂���.get_CelText(axGT�͂���.CaretRow,3);
			if(sTcode != "")
				this.Close();

		}

		private void axGT�͂���_CurPlaceChanged(object sender, AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEvent e)
		{
// MOD 2006.12.11 ���s�j�����J �����I�����̔w�i�F�ύX START
/*			axGT�͂���.set_CelForeColor(nOldRow,0,0);
			axGT�͂���.set_CelBackColor(nOldRow,0,0xFFFFFF);
//			axGT�͂���.set_CelForeColor(axGT�͂���.CaretRow,0,111111);
			axGT�͂���.set_CelForeColor(axGT�͂���.CaretRow,0,0x98FB98);  //BGR
			axGT�͂���.set_CelBackColor(axGT�͂���.CaretRow,0,0x006000);
			nOldRow = axGT�͂���.CaretRow;
*/
			axGT�͂���.set_CelForeColor(OldRow,0,0);
			axGT�͂���.set_CelBackColor(OldRow,0,0xFFFFFF);
			if(axGT�͂���.SelStartRow == axGT�͂���.SelEndRow)
			{
				if(nSrow > nErow)
				{
					nWork = nSrow;
					nSrow = nErow;
					nErow = nWork;
				}
				for(short nCnt = nSrow; nCnt <= nErow; nCnt++)
				{
					axGT�͂���.set_CelForeColor(nCnt,0,0);
					axGT�͂���.set_CelBackColor(nCnt,0,0xFFFFFF);
				}
			}
			axGT�͂���.set_CelForeColor(axGT�͂���.SelStartRow,0,0x98FB98);
			axGT�͂���.set_CelBackColor(axGT�͂���.SelStartRow,0,0x006000);
			axGT�͂���.set_CelForeColor(axGT�͂���.SelEndRow,0,0x98FB98);
			axGT�͂���.set_CelBackColor(axGT�͂���.SelEndRow,0,0x006000);
			axGT�͂���.set_CelForeColor(axGT�͂���.CaretRow,0,0x98FB98);
			axGT�͂���.set_CelBackColor(axGT�͂���.CaretRow,0,0x006000);
			if(axGT�͂���.SelEndRow > axGT�͂���.CaretRow
				&& axGT�͂���.SelStartRow <= axGT�͂���.CaretRow
				&& axGT�͂���.get_CelForeColor(axGT�͂���.SelEndRow,0) != Color.Black)
			{
				axGT�͂���.set_CelForeColor(axGT�͂���.SelEndRow,0,0);
				axGT�͂���.set_CelBackColor(axGT�͂���.SelEndRow,0,0xFFFFFF);
			}

			if(axGT�͂���.SelEndRow < axGT�͂���.CaretRow
				&& axGT�͂���.SelStartRow >= axGT�͂���.CaretRow
				&& axGT�͂���.get_CelForeColor(axGT�͂���.SelEndRow,0) != Color.Black)
			{
				axGT�͂���.set_CelForeColor(axGT�͂���.SelEndRow,0,0);
				axGT�͂���.set_CelBackColor(axGT�͂���.SelEndRow,0,0xFFFFFF);
			}

			OldRow = axGT�͂���.CaretRow;
			nSrow  = axGT�͂���.SelStartRow;
			nErow  = axGT�͂���.SelEndRow;
// MOD 2006.12.11 ���s�j�����J �����I�����̔w�i�F�ύX END

		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� START
			tex���b�Z�[�W.Text = "";
// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� END

			i�A�N�e�B�u�e�f = 1;
			axGT�͂���.CaretRow  = 1;
// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� START
			axGT�͂���.CaretCol  = 1;
// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� END
			axGT�͂���_CurPlaceChanged(null,null);
			axGT�͂���.Clear();
// MOD 2009.12.08 ���s�j���� �ňړ��N���A�����̒ǉ� START
			btn�O��.Enabled = false;
			btn����.Enabled = false;
			lab�Ŕԍ�.Text = "";
// MOD 2009.12.08 ���s�j���� �ňړ��N���A�����̒ǉ� END

// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//			tex�͂���J�i.Text   = tex�͂���J�i.Text.Trim();
			if(gs�I�v�V����[18].Equals("1")){
				tex�͂���J�i.Text   = tex�͂���J�i.Text.TrimEnd();
			}else{
				tex�͂���J�i.Text   = tex�͂���J�i.Text.Trim();
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END

			tex�͂���R�[�h.Text = tex�͂���R�[�h.Text.Trim();
// ADD 2006.07.04 ���s�j�R�{ ���������ɓd�b�ԍ��ǉ� START
			tex�d�b�ԍ�.Text  = tex�d�b�ԍ�.Text.Trim();
			tex�d�b�ԍ�2.Text = tex�d�b�ԍ�2.Text.Trim();
			tex�d�b�ԍ�3.Text = tex�d�b�ԍ�3.Text.Trim();
// ADD 2006.07.04 ���s�j�R�{ ���������ɓd�b�ԍ��ǉ� END
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//// ADD 2007.01.30 FJCS�j�K�c ���������ɖ��O�ǉ� START
//			tex�͂��於�O.Text  = tex�͂��於�O.Text.Trim();
//// ADD 2007.01.30 FJCS�j�K�c ���������ɖ��O�ǉ� END
			if(gs�I�v�V����[18].Equals("1")){
				tex�͂��於�O.Text  = tex�͂��於�O.Text.TrimEnd();
			}else{
				tex�͂��於�O.Text  = tex�͂��於�O.Text.Trim();
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END

			if(!���p�`�F�b�N(tex�͂���J�i,"�͂���J�i")) return;
			if(!���p�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;
// ADD 2007.01.30 FJCS�j�K�c ���������ɖ��O�ǉ� START
			if(!�S�p�`�F�b�N(tex�͂��於�O,"�͂��於�O")) return;
// ADD 2007.01.30 FJCS�j�K�c ���������ɖ��O�ǉ� END

			i���ݕŐ� = 1;
			axGT�͂���.CaretRow = 1;
// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� START
			axGT�͂���.CaretCol = 1;
// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� END
			axGT�͂���.set_CelForeColor(nOldRow,0,0);
//			axGT�͂���.set_CelForeColor(axGT�͂���.CaretRow,0,111111);
			axGT�͂���.set_CelForeColor(axGT�͂���.CaretRow,0,0x98FB98);  //BGR
			axGT�͂���.set_CelBackColor(axGT�͂���.CaretRow,0,0x006000);
			nOldRow = axGT�͂���.CaretRow;

			s�͂���ꗗ = new string[1];
			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				tex���b�Z�[�W.Text = "�������D�D�D";
				if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
// MOD 2010.02.03 ���s�j���� ���������ɍX�V����ǉ� START
//// ADD 2009.01.29 ���s�j���� �ꗗ�ɖ��O�Q�A�Z���Q�A�Z���R��ǉ� START
////				s�͂���ꗗ = sv_otodoke.Get_todokesaki2(gsa���[�U,gs����b�c, gs����b�c,
////// ADD 2006.07.04 ���s�j�R�{ ���������ɓd�b�ԍ����\�[�g�@�\�ǉ� START
//////												tex�͂���J�i.Text, tex�͂���R�[�h.Text);
////// ADD 2007.01.30 FJCS�j�K�c ���������ɖ��O�ǉ� START
//////												tex�͂���J�i.Text, tex�͂���R�[�h.Text,tex�d�b�ԍ�.Text,tex�d�b�ԍ�2.Text,tex�d�b�ԍ�3.Text,
////												tex�͂���J�i.Text, tex�͂���R�[�h.Text,tex�d�b�ԍ�.Text,tex�d�b�ԍ�2.Text,tex�d�b�ԍ�3.Text,tex�͂��於�O.Text,
////// ADD 2007.01.30 FJCS�j�K�c ���������ɖ��O�ǉ� END
////												cb�K�w���X�g�P.SelectedIndex,cb�\�[�g�����P.SelectedIndex,
////												cb�K�w���X�g�Q.SelectedIndex,cb�\�[�g�����Q.SelectedIndex);
////// ADD 2006.07.04 ���s�j�R�{ ���������ɓd�b�ԍ����\�[�g�@�\�ǉ� END
//				s�͂���ꗗ = sv_otodoke.Get_todokesaki3(
//					gsa���[�U, gs����b�c, gs����b�c
//					, tex�͂���J�i.Text, tex�͂���R�[�h.Text
//					, tex�d�b�ԍ�.Text, tex�d�b�ԍ�2.Text, tex�d�b�ԍ�3.Text
//					, tex�͂��於�O.Text
//					, cb�K�w���X�g�P.SelectedIndex,cb�\�[�g�����P.SelectedIndex
//					, cb�K�w���X�g�Q.SelectedIndex,cb�\�[�g�����Q.SelectedIndex
//					, cb���O�Z���ڍו\��.Checked
//					);
//// ADD 2009.01.29 ���s�j���� �ꗗ�ɖ��O�Q�A�Z���Q�A�Z���R��ǉ� END
				s�͂���ꗗ = sv_otodoke.Get_todokesaki4(
					gsa���[�U, gs����b�c, gs����b�c
					, tex�͂���J�i.Text, tex�͂���R�[�h.Text
					, tex�d�b�ԍ�.Text, tex�d�b�ԍ�2.Text, tex�d�b�ԍ�3.Text
					, tex�͂��於�O.Text
					, cb�K�w���X�g�P.SelectedIndex,cb�\�[�g�����P.SelectedIndex
					, cb�K�w���X�g�Q.SelectedIndex,cb�\�[�g�����Q.SelectedIndex
					, cb���O�Z���ڍו\��.Checked
					, (cb�X�V��.Checked) ? dt�X�V��.Value.ToString("yyyyMMdd") : ""
					);
// MOD 2010.02.03 ���s�j���� ���������ɍX�V����ǉ� END
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				s�͂���ꗗ[0] = gs�ʐM�G���[;
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				s�͂���ꗗ[0] = "�ʐM�G���[�F" + ex.Message;
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;

			tex���b�Z�[�W.Text = s�͂���ꗗ[0];
			if(s�͂���ꗗ[0].Length == 4) //����I��
			{
				tex���b�Z�[�W.Text = "";
// MOD 2005.05.10 ���s�j�����J ��s�ڋ� START
//				i�ő�Ő� = (s�͂���ꗗ.Length - 2) / axGT�͂���.Rows + 1;
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� START
//				i�ő�Ő� = (s�͂���ꗗ.Length - 2) / (axGT�͂���.Rows - 1) + 1;
				i�ő�Ő� = (s�͂���ꗗ.Length - 2) / (i�ōő�s�� - 1) + 1;
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� END
// MOD 2005.05.10 ���s�j�����J ��s�ڋ� END
				if (i���ݕŐ� > i�ő�Ő�)
					i���ݕŐ� = i�ő�Ő�;
				�ŏ��ݒ�();
			}
			else
			{
				if(s�͂���ꗗ[0].Equals("�Y���f�[�^������܂���"))
				{
					tex���b�Z�[�W.Text = "";
					MessageBox.Show("�Y���f�[�^������܂���","���͂��挟��",MessageBoxButtons.OK);
				}
				else
				{
					axGT�͂���.Clear();
					i���ݕŐ� = 1;
					btn�O��.Enabled = false;
					btn����.Enabled = false;
					lab�Ŕԍ�.Text = "";
					�r�[�v��();
				}
// MOD 2006.12.11 ���s�j�����J ���C�A�E�g�ύX START
//				tex�͂���J�i.Focus();
				tex�͂���R�[�h.Focus();
// MOD 2006.12.11 ���s�j�����J ���C�A�E�g�ύX END
			}
		}

		private void btn�m��_Click(object sender, System.EventArgs e)
		{
			sTname = axGT�͂���.get_CelText(axGT�͂���.CaretRow,1);
			sTcode = axGT�͂���.get_CelText(axGT�͂���.CaretRow,3);
			if(sTcode != "")
				this.Close();
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			s���� = "T";
			sTcode = axGT�͂���.get_CelText(axGT�͂���.CaretRow,3);
			if(sTcode != "")
				this.Close();

		}

		private void axGT�͂���_KeyDownEvent(object sender, AxGTABLE32V2Lib._DGTable32Events_KeyDownEvent e)
		{
			if (e.keyCode == 13)
			{
				btn�m��_Click(sender, null);
			}
			if (e.keyCode == 9)
			{
				this.SelectNextControl(axGT�͂���, true, true, true, true);
			}
		}

// MOD 2007.03.12 FJCS�j�K�c �G���^�[�L�[�����ɂ�錟���J�n�^�C�~���O�̕ύX START
//		private void tex�͂���R�[�h_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
//		{
//			if (e.KeyCode == Keys.Enter)
//			{
//				btn����_Click(sender, e);
//			}
//		}
		private void tex�͂��於�O_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btn����_Click(sender, e);
			}
		}
// MOD 2007.03.12 FJCS�j�K�c �G���^�[�L�[�����ɂ�錟���J�n�^�C�~���O�̕ύX END

		private void btn�O��_Click(object sender, System.EventArgs e)
		{
			i���ݕŐ�--;
			�ŏ��ݒ�();
// ADD 2005.05.10 ���s�j�����J ��s�ڑI�� START
			axGT�͂���.CaretRow = 1;
// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� START
			axGT�͂���.CaretCol = 1;
// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� END
			axGT�͂���_CurPlaceChanged(null,null);
// ADD 2005.05.10 ���s�j�����J ��s�ڑI�� END
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			i���ݕŐ�++;
			�ŏ��ݒ�();
// ADD 2005.05.10 ���s�j�����J ��s�ڑI�� START
			axGT�͂���.CaretRow = 1;
// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� START
			axGT�͂���.CaretCol = 1;
// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� END
			axGT�͂���_CurPlaceChanged(null,null);
// ADD 2005.05.10 ���s�j�����J ��s�ڑI�� END
		}

		private void �ŏ��ݒ�()
		{
			axGT�͂���.Clear();
// ADD 2006.12.14 ���s�j�����J ���ׂ̗]�������� START
			axGT�͂���.Rows = 16;
// ADD 2006.12.14 ���s�j�����J ���ׂ̗]�������� END

// MOD 2005.05.10 ���s�j�����J ��s�ڋ� START
//			i�J�n�� = (i���ݕŐ� - 1) * axGT�͂���.Rows + 1;
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� START
//			i�J�n�� = (i���ݕŐ� - 1) * (axGT�͂���.Rows - 1) + 1;
			i�J�n�� = (i���ݕŐ� - 1) * (i�ōő�s�� - 1) + 1;
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� END
//			i�I���� = i���ݕŐ� * axGT�͂���.Rows;
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� START
//			i�I���� = i���ݕŐ� * (axGT�͂���.Rows - 1);
			i�I���� = i���ݕŐ� * (i�ōő�s�� - 1);
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� END

// ADD 2009.01.29 ���s�j���� �ꗗ�ɖ��O�Q�A�Z���Q�A�Z���R��ǉ� START
			if(cb���O�Z���ڍו\��.Checked){
				axGT�͂���.set_CelHeight(1, 0, 3.0);
			}else{
				axGT�͂���.set_CelHeight(0, 0, 1.5);
			}
// ADD 2009.01.29 ���s�j���� �ꗗ�ɖ��O�Q�A�Z���Q�A�Z���R��ǉ� END
//			short s�\���� = (short)1;
			short s�\���� = (short)2;
// MOD 2005.05.10 ���s�j�����J ��s�ڋ� END
			for(short sCnt = (short)i�J�n��; sCnt < s�͂���ꗗ.Length && sCnt <= i�I���� ; sCnt++)
			{
// ADD 2006.12.14 ���s�j�����J ���ׂ̗]�������� START
				if(s�\���� > 16)
					axGT�͂���.Rows++;
// ADD 2006.12.14 ���s�j�����J ���ׂ̗]�������� END
// ADD 2009.01.29 ���s�j���� �ꗗ�ɖ��O�Q�A�Z���Q�A�Z���R��ǉ� START
				if(cb���O�Z���ڍו\��.Checked){
					axGT�͂���.set_CelHeight(s�\����, 0, 3.0);
					axGT�͂���.set_CelAlignVert(s�\����, 1, 3);
					axGT�͂���.set_CelAlignVert(s�\����, 2, 3);
					s�͂���ꗗ[sCnt] = s�͂���ꗗ[sCnt].Replace("\\r\\n","\r\n");
				}
// ADD 2009.01.29 ���s�j���� �ꗗ�ɖ��O�Q�A�Z���Q�A�Z���R��ǉ� END

				axGT�͂���.set_RowsText(s�\����, s�͂���ꗗ[sCnt]);
				s�\����++;
			}
			lab�Ŕԍ�.Text = i���ݕŐ�.ToString() + " / " + i�ő�Ő�.ToString();
			if (i���ݕŐ� == 1)
				btn�O��.Enabled = false;
			else
				btn�O��.Enabled = true;
			if (i���ݕŐ� == i�ő�Ő�)
				btn����.Enabled = false;
			else
				btn����.Enabled = true;
			axGT�͂���.Focus();
		}

		private void ���͂��挟��_Activated(object sender, System.EventArgs e)
		{
			if(tex�͂���R�[�h.Text.Trim().Length != 0 && i�A�N�e�B�u�e�f == 0)
				btn����_Click(sender,e);
		}

// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� START
		private void ���͂��挟��_Closed(object sender, System.EventArgs e)
		{
// ADD 2005.07.08 ���s�j�����J ���ʃ{�^�������� START
			btn����.Visible = false;
// ADD 2005.07.08 ���s�j�����J ���ʃ{�^�������� END
			tex�͂���J�i.Text   = " ";
//			tex�͂���R�[�h.Text = "";
			tex���b�Z�[�W.Text = "";
			axGT�͂���.Clear();
			axGT�͂���.CaretRow  = 1;
// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� START
			axGT�͂���.CaretCol  = 1;
// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� END
			axGT�͂���_CurPlaceChanged(null,null);
// MOD 2006.12.11 ���s�j�����J ���C�A�E�g�ύX START
//			tex�͂���J�i.Focus();
			tex�͂���R�[�h.Focus();
// MOD 2006.12.11 ���s�j�����J ���C�A�E�g�ύX END
// ADD 2006.07.04 ���s�j�R�{ �폜���ꗗ������b�r�u�o�̓{�^������ START
			btnCSV�o��.Visible = false;
			btn�ꗗ���.Visible = false;
			btn�폜.Visible = false;
// ADD 2006.07.04 ���s�j�R�{ �폜���ꗗ������b�r�u�o�̓{�^������ END
// ADD 2007.03.12 FJCS�j�K�c ���ڃN���A START
			tex�d�b�ԍ�.Text = "";
			tex�d�b�ԍ�2.Text = "";
			tex�d�b�ԍ�3.Text = "";
			tex�͂��於�O.Text = "";
// ADD 2007.03.12 FJCS�j�K�c ���ڃN���A END
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� START
			gs�A�h���X��_�\�����P      = cb�K�w���X�g�P.Text.TrimEnd();
			gs�A�h���X��_�\�����P_���� = cb�\�[�g�����P.Text.TrimEnd();
			gs�A�h���X��_�\�����Q      = cb�K�w���X�g�Q.Text.TrimEnd();
			gs�A�h���X��_�\�����Q_���� = cb�\�[�g�����Q.Text.TrimEnd();
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� END
		}
// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� END

// ADD 2006.07.04 ���s�j�R�{ �\�[�g�@�\�ǉ� START
		private void cb�K�w�P�I��_select(object sender, System.EventArgs e)
		{
			if(cb�K�w���X�g�P.SelectedIndex != 0)
				cb�\�[�g�����P.Visible = true;
			else
				cb�\�[�g�����P.Visible = false;
		}

		private void cb�K�w�Q�I��_select(object sender, System.EventArgs e)
		{
			if(cb�K�w���X�g�Q.SelectedIndex != 0)
				cb�\�[�g�����Q.Visible = true;
			else
				cb�\�[�g�����Q.Visible = false;
		}
// ADD 2006.07.04 ���s�j�R�{ �\�[�g�@�\�ǉ� END

// ADD 2006.07.04 ���s�j�R�{ �폜���ꗗ������b�r�u�o�͋@�\�ǉ� START
		public void VisibleCSV�o��()
		{
			btnCSV�o��.Visible = true;
		}
		public void Visible�ꗗ���()
		{
			btn�ꗗ���.Visible = true;
		}
		public void Visible�폜()
		{
			btn�폜.Visible = true;
		}

		private void btn�폜_Click(object sender, System.EventArgs e)
		{
// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� START
			tex���b�Z�[�W.Text = "";
// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� END

// MOD 2010.06.03 ���s�j���� �������폜�@�\�̍����� START
//			string tex�͂���b�c;
			string[] tex�͂���b�c = {};
// MOD 2010.06.03 ���s�j���� �������폜�@�\�̍����� END
			DialogResult result;
//		    string sIUFlg;

			result = MessageBox.Show("�w�肳�ꂽ�f�[�^���폜���܂��B��낵���ł����H","�폜",MessageBoxButtons.YesNo);
			if(result == DialogResult.Yes)
			{
// MOD 2010.06.03 ���s�j���� �������폜�@�\�̍����� START
//				for( short CelCnt=axGT�͂���.SelStartRow;CelCnt <= axGT�͂���.SelEndRow;CelCnt++)
//				{
//					tex�͂���b�c = axGT�͂���.get_CelText(CelCnt,3).Trim();
//					if(tex�͂���b�c.Length == 0)
//						continue;
//					// �J�[�\���������v�ɂ���
//					Cursor = System.Windows.Forms.Cursors.AppStarting;
//					String[] sList = {""};
//					try
//					{
//						if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
//						sList = sv_otodoke.Get_Stodokesaki(gsa���[�U,gs����b�c,gs����b�c,tex�͂���b�c);
//						sIUFlg    = sList[15];
//
//						Cursor = System.Windows.Forms.Cursors.Default;
//
//						String[] sDList;
//						string[] sData = new string[5];
//
//						if(sIUFlg == "I")
//						{
//							MessageBox.Show("�R�[�h(" + tex�͂���b�c + ")�̃f�[�^�͑��݂��܂���","�폜",MessageBoxButtons.OK);
//							tex���b�Z�[�W.Text = "";
//							btn����_Click(sender,e);
//							return;
//						}
//						else
//						{
//							tex���b�Z�[�W.Text = "�폜���D�D�D";
//							sData[0] = gs����b�c;
//							sData[1] = gs����b�c;
//							sData[2] = tex�͂���b�c;
//							sData[3] = "���͂���";
//							sData[4] = gs���p�҂b�c;
//
//							Cursor = System.Windows.Forms.Cursors.AppStarting;
//
//							if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
//							sDList = sv_otodoke.Del_todokesaki(gsa���[�U,sData);
//							// [����I��]���A��ʂ��N���A����
//							if(sDList[0].Length != 4)
//							{
//								�r�[�v��();
//								tex���b�Z�[�W.Text = sDList[0];
//								btn����_Click(sender,e);
//								return;
//							}
//						}
//						Cursor = System.Windows.Forms.Cursors.Default;
//					}
//					catch (System.Net.WebException)
//					{
//						sList[0] = gs�ʐM�G���[;
//						Cursor = System.Windows.Forms.Cursors.Default;
//						tex���b�Z�[�W.Text = sList[0];
//						�r�[�v��();
//					}
//					catch (Exception ex)
//					{
//						sList[0] = "�ʐM�G���[�F" + ex.Message;
//						Cursor = System.Windows.Forms.Cursors.Default;
//						tex���b�Z�[�W.Text = sList[0];
//						�r�[�v��();
//					}
//				}
				int iCnt  = 0;
				int iPosS = 0;
				int iPosE = 0;
				if(axGT�͂���.SelEndRow >= axGT�͂���.SelStartRow){
					iPosS = (int)axGT�͂���.SelStartRow;
					iPosE = (int)axGT�͂���.SelEndRow  ;
				}else{
					iPosS = (int)axGT�͂���.SelEndRow  ;
					iPosE = (int)axGT�͂���.SelStartRow;
				}
				iCnt = iPosE - iPosS + 1;
				tex�͂���b�c = new string[iCnt];
				int iPos = 0;
				for(int iLine = iPosS; iLine <= iPosE; iLine++){
					tex�͂���b�c[iPos++] = axGT�͂���.get_CelText((short)iLine,3).Trim();
				}
				// �J�[�\���������v�ɂ���
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				string[] sList = {""};
				string[] sData = new string[5];
				try{
					tex���b�Z�[�W.Text = "�폜���D�D�D";
					sData[0] = gs����b�c;
					sData[1] = gs����b�c;
					sData[2] = "";
					sData[3] = "���͂���";
					sData[4] = gs���p�҂b�c;

					if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
					sList = sv_otodoke.Del_todokesakis(gsa���[�U, sData, tex�͂���b�c);
					// [����I��]���A��ʂ��N���A����
					if(sList[0].Length != 4){
						�r�[�v��();
						tex���b�Z�[�W.Text = sList[0];
						btn����_Click(sender,e);
						return;
					}
					Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2010.09.22 ���s�j���� �폜�F[������]�I�����̏�Q�C�� START
					tex���b�Z�[�W.Text = "";
					btn����_Click(sender,e);
// MOD 2010.09.22 ���s�j���� �폜�F[������]�I�����̏�Q�C�� END
				}catch (System.Net.WebException){
					sList[0] = gs�ʐM�G���[;
					Cursor = System.Windows.Forms.Cursors.Default;
					tex���b�Z�[�W.Text = sList[0];
					�r�[�v��();
				}catch (Exception ex){
					sList[0] = "�ʐM�G���[�F" + ex.Message;
					Cursor = System.Windows.Forms.Cursors.Default;
					tex���b�Z�[�W.Text = sList[0];
					�r�[�v��();
				}
// MOD 2010.06.03 ���s�j���� �������폜�@�\�̍����� END
			}
// MOD 2010.09.22 ���s�j���� �폜�F[������]�I�����̏�Q�C�� START
//			tex���b�Z�[�W.Text = "";
//			btn����_Click(sender,e);
// MOD 2010.09.22 ���s�j���� �폜�F[������]�I�����̏�Q�C�� END
			return;
		}

		private void btn�ꗗ���_Click(object sender, System.EventArgs e)
		{
// MOD 2010.02.03 ���s�j���� ���������ɍX�V����ǉ� START
			tex�͂���J�i.Text   = tex�͂���J�i.Text.TrimEnd();
			tex�͂���R�[�h.Text = tex�͂���R�[�h.Text.TrimEnd();
			tex�d�b�ԍ�.Text     = tex�d�b�ԍ�.Text.TrimEnd();
			tex�d�b�ԍ�2.Text    = tex�d�b�ԍ�2.Text.TrimEnd();
			tex�d�b�ԍ�3.Text    = tex�d�b�ԍ�3.Text.TrimEnd();
			tex�͂��於�O.Text   = tex�͂��於�O.Text.TrimEnd();
// MOD 2010.02.03 ���s�j���� ���������ɍX�V����ǉ� END

			tex���b�Z�[�W.Text = "���͂���ꗗ������D�D�D";
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				if(sv_print == null) sv_print = new is2print.Service1();
				string[] sKey = new string[3];
				sKey[0] = gs����b�c;
				sKey[1] = gs����b�c;

				string[] sRet = new string[1];
// MOD 2010.02.03 ���s�j���� ���������ɍX�V����ǉ� START
//				IEnumerator iEnum = sv_print.Get_ConsigneePrintData2(gsa���[�U,sKey,
//// ADD 2007.01.30 FJCS�j�K�c ���������ɖ��O�ǉ� START
////												tex�͂���J�i.Text, tex�͂���R�[�h.Text,tex�d�b�ԍ�.Text,tex�d�b�ԍ�2.Text,tex�d�b�ԍ�3.Text,
//												tex�͂���J�i.Text, tex�͂���R�[�h.Text,tex�d�b�ԍ�.Text,tex�d�b�ԍ�2.Text,tex�d�b�ԍ�3.Text,tex�͂��於�O.Text,
//// ADD 2007.01.30 FJCS�j�K�c ���������ɖ��O�ǉ� END
//												cb�K�w���X�g�P.SelectedIndex,cb�\�[�g�����P.SelectedIndex,
//												cb�K�w���X�g�Q.SelectedIndex,cb�\�[�g�����Q.SelectedIndex).GetEnumerator();
				IEnumerator iEnum
				 = sv_print.Get_ConsigneePrintData3(
						gsa���[�U,sKey
						, tex�͂���J�i.Text, tex�͂���R�[�h.Text
						, tex�d�b�ԍ�.Text, tex�d�b�ԍ�2.Text, tex�d�b�ԍ�3.Text
						, tex�͂��於�O.Text
						, cb�K�w���X�g�P.SelectedIndex, cb�\�[�g�����P.SelectedIndex
						, cb�K�w���X�g�Q.SelectedIndex, cb�\�[�g�����Q.SelectedIndex
						, (cb�X�V��.Checked) ? dt�X�V��.Value.ToString("yyyyMMdd") : ""
					).GetEnumerator();
// MOD 2010.02.03 ���s�j���� ���������ɍX�V����ǉ� END
				iEnum.MoveNext();
				sRet = (string[])iEnum.Current;
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
					tex���b�Z�[�W.Text = sRet[0];
					�r�[�v��();
				}
			}
			catch (System.Net.WebException)
			{
				tex���b�Z�[�W.Text = gs�ʐM�G���[;
				�r�[�v��();
			}
			catch (Exception ex)
			{
				tex���b�Z�[�W.Text = ex.Message;
				�r�[�v��();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		
		}

		private void btnCSV�o��_Click(object sender, System.EventArgs e)
		{
// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� START
			tex���b�Z�[�W.Text = "";
// MOD 2010.02.02 ���s�j���� �ꗗ�ɓo�^�����A�X�V�����A�o�׎g�p����ǉ� END

// MOD 2010.02.03 ���s�j���� ���������ɍX�V����ǉ� START
			tex�͂���J�i.Text   = tex�͂���J�i.Text.TrimEnd();
			tex�͂���R�[�h.Text = tex�͂���R�[�h.Text.TrimEnd();
			tex�d�b�ԍ�.Text     = tex�d�b�ԍ�.Text.TrimEnd();
			tex�d�b�ԍ�2.Text    = tex�d�b�ԍ�2.Text.TrimEnd();
			tex�d�b�ԍ�3.Text    = tex�d�b�ԍ�3.Text.TrimEnd();
			tex�͂��於�O.Text   = tex�͂��於�O.Text.TrimEnd();
// MOD 2010.02.03 ���s�j���� ���������ɍX�V����ǉ� END

			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				String[] sList;
				if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();

// MOD 2010.02.03 ���s�j���� ���������ɍX�V����ǉ� START
//				sList = sv_otodoke.Get_csvwrite2(gsa���[�U,gs����b�c,gs����b�c,
//// ADD 2007.01.30 FJCS�j�K�c ���������ɖ��O�ǉ� START
////												tex�͂���J�i.Text, tex�͂���R�[�h.Text,tex�d�b�ԍ�.Text,tex�d�b�ԍ�2.Text,tex�d�b�ԍ�3.Text,
//												tex�͂���J�i.Text, tex�͂���R�[�h.Text,tex�d�b�ԍ�.Text,tex�d�b�ԍ�2.Text,tex�d�b�ԍ�3.Text,tex�͂��於�O.Text,
//// ADD 2007.01.30 FJCS�j�K�c ���������ɖ��O�ǉ� END
//												cb�K�w���X�g�P.SelectedIndex,cb�\�[�g�����P.SelectedIndex,
//												cb�K�w���X�g�Q.SelectedIndex,cb�\�[�g�����Q.SelectedIndex);
				sList
				 = sv_otodoke.Get_csvwrite3(
			 			gsa���[�U, gs����b�c, gs����b�c
						, tex�͂���J�i.Text, tex�͂���R�[�h.Text
						, tex�d�b�ԍ�.Text, tex�d�b�ԍ�2.Text, tex�d�b�ԍ�3.Text
						, tex�͂��於�O.Text
						, cb�K�w���X�g�P.SelectedIndex, cb�\�[�g�����P.SelectedIndex
						, cb�K�w���X�g�Q.SelectedIndex, cb�\�[�g�����Q.SelectedIndex
						, (cb�X�V��.Checked) ? dt�X�V��.Value.ToString("yyyyMMdd") : ""
					);
// MOD 2010.02.03 ���s�j���� ���������ɍX�V����ǉ� END
												// �c�a�i�r�l�O�Q�׎�l�t�@�C���j�̓ǂݍ��݂��s�Ȃ��B
				this.Cursor = System.Windows.Forms.Cursors.Default;

				if(sList[0].Length == 4)		// ����ɓǂݍ��݂������H
				{
					sList[0] = "\"�׎�l�R�[�h\",\"�d�b�ԍ�\",\"�e�`�w�ԍ�\","
						+ "\"�Z���P\",\"�Z���Q\",\"�Z���R\","
						+ "\"���O�P\",\"���O�Q\",\"�\��\",\"�X�֔ԍ�\","
						+ "\"�J�i����\",\"��ďo�׋敪\",\"����v\",\"���X�R�[�h\"";
												// ���o�����̕ҏW���s�Ȃ�

					// �f�t�H���g�̃t�H���_���f�X�N�g�b�v�t�H���_�ɂ���
					saveFileDialog1.InitialDirectory
						= Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
					saveFileDialog1.Filter = "�b�r�u�t�@�C�� (*.csv)|*.csv";
					byte[] bSJIS;
					if(saveFileDialog1.ShowDialog(this) == DialogResult.OK)
					{							// �t�@�C���ۑ��R�����_�C�A���O�̕\�����s�Ȃ�
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
			catch (System.Net.WebException)
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
				tex���b�Z�[�W.Text = gs�ʐM�G���[;
				�r�[�v��();
			}
			catch(Exception ex)
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
				tex���b�Z�[�W.Text = ex.Message;
			}
			tex�͂���R�[�h.Focus();		
		}

		private void axGT�͂���_CelClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelClickEvent e)
		{
			axGT�͂���_CurPlaceChanged(null,null);
			if(axGT�͂���.SelStartRow != axGT�͂���.SelEndRow)
			{
				if(nSrow > nErow)
				{
					nWork = nSrow;
					nSrow = nErow;
					nErow = nWork;
				}
				for(short nCnt = nSrow; nCnt <= nErow; nCnt++)
				{
					axGT�͂���.set_CelForeColor(nCnt,0,0x98FB98);
					axGT�͂���.set_CelBackColor(nCnt,0,0x006000);
				}
				for(int nCnt = int.Parse(nSrow.ToString()) - 1; nCnt >= 1; nCnt--)
				{
					axGT�͂���.set_CelForeColor(short.Parse(nCnt.ToString()),0,0);
					axGT�͂���.set_CelBackColor(short.Parse(nCnt.ToString()),0,0xFFFFFF);
				}
				for(int nCnt = int.Parse(nErow.ToString()) + 1; nCnt <= axGT�͂���.Rows; nCnt++)
				{
					axGT�͂���.set_CelForeColor(short.Parse(nCnt.ToString()),0,0);
					axGT�͂���.set_CelBackColor(short.Parse(nCnt.ToString()),0,0xFFFFFF);
				}
			}
		}
// ADD 2006.07.04 ���s�j�R�{ �폜���ꗗ������b�r�u�o�͋@�\�ǉ� END
// MOD 2010.02.03 ���s�j���� ���������ɍX�V����ǉ� START
		private void cb�X�V��_CheckedChanged(object sender, System.EventArgs e)
		{
			dt�X�V��.Enabled = cb�X�V��.Checked;
		}
// MOD 2010.02.03 ���s�j���� ���������ɍX�V����ǉ� END
	}
}
