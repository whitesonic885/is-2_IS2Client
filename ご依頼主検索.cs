using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [���˗��匟��]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// MOD 2008.10.01 ���s�j���� �ꗗ�ɐ������\�� 
	//--------------------------------------------------------------------------
	// MOD 2009.11.30 ���s�j���� ���������ɖ��O�A�������ǉ� 
	//--------------------------------------------------------------------------
	// MOD 2010.02.03 ���s�j���� �\�[�g�����̕ێ��@�\��ǉ� 
	// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� 
	// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� 
	// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 ���s�j���� �������폜�@�\�̏�Q�Ή� 
	// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� 
	// MOD 2011.01.25 ���s�j���� �u���[�h�Ɏ��s�v�Ή� 
	//--------------------------------------------------------------------------
	public class ���˗��匟�� : ���ʃt�H�[��
	{
// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� START
////		public  short OldRow = 0;
		private short nSrow = 0;
		private short nErow = 0;
		private short nWork = 0;
// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� END
		private short nOldRow = 0;
		public string sIcode;
		public string sIname;
		public string s����;
		private string[] s�˗���ꗗ;
		private int      i���ݕŐ�;
		private int      i�ő�Ő�;
		private int      i�J�n��;
		private int      i�I����;
		private int      i�A�N�e�B�u�e�f = 0;
// MOD 2009.11.30 ���s�j���� ���������ɖ��O�A�������ǉ� START
		private string s������b�c = "";
		private string s���ۂb�c   = "";
// MOD 2009.11.30 ���s�j���� ���������ɖ��O�A�������ǉ� END
// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� START
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� END

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Button btn����;
		private ���ʃe�L�X�g�{�b�N�X tex�˗���J�i;
		private System.Windows.Forms.Label lab�˗���J�i;
		private System.Windows.Forms.Label lab�˗���R�[�h;
		private ���ʃe�L�X�g�{�b�N�X tex�˗���R�[�h;
		private System.Windows.Forms.Label lab�˗���^�C�g��;
		private System.Windows.Forms.Button btn�m��;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.TextBox tex���b�Z�[�W;
		private System.Windows.Forms.Button btn����;
		private AxGTABLE32V2Lib.AxGTable32 axGT�˗���;
		private System.Windows.Forms.Label lab�Ŕԍ�;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Button btn�O��;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lab�͂��於�O;
		private System.Windows.Forms.ComboBox cmb������;
		private System.Windows.Forms.Label lab������;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cb�\�[�g�����Q;
		private System.Windows.Forms.ComboBox cb�K�w���X�g�Q;
		private System.Windows.Forms.ComboBox cb�\�[�g�����P;
		private System.Windows.Forms.ComboBox cb�K�w���X�g�P;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�˗��喼�O;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex������R�[�h;
		private System.Windows.Forms.GroupBox gp�\����;
		private System.Windows.Forms.Button btn�폜;
		private System.Windows.Forms.Button btn�ꗗ���;
		private System.Windows.Forms.Button btnCSV�o��;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ���˗��匟��()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
			�c�o�h�\���T�C�Y�ϊ�();
//			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
				this.axGT�˗���.Size = new System.Drawing.Size(758, 307);
//			}
// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� END
// MOD 2010.02.03 ���s�j���� �\�[�g�����̕ێ��@�\��ǉ� START
			cb�K�w���X�g�P.SelectedIndex = 4;
			cb�\�[�g�����P.SelectedIndex = 0;
			cb�K�w���X�g�Q.SelectedIndex = 2;
			cb�\�[�g�����Q.SelectedIndex = 0;
// MOD 2010.02.03 ���s�j���� �\�[�g�����̕ێ��@�\��ǉ� END
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� START
			if(gs���˗��匟��_�\�����P != null){
				cb�K�w���X�g�P.Text = gs���˗��匟��_�\�����P;
			}
			if(gs���˗��匟��_�\�����P_���� != null){
				cb�\�[�g�����P.Text = gs���˗��匟��_�\�����P_����;
			}
			if(gs���˗��匟��_�\�����Q != null){
				cb�K�w���X�g�Q.Text = gs���˗��匟��_�\�����Q;
			}
			if(gs���˗��匟��_�\�����Q_���� != null){
				cb�\�[�g�����Q.Text = gs���˗��匟��_�\�����Q_����;
			}
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� END
// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� START
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� END
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(���˗��匟��));
			this.panel1 = new System.Windows.Forms.Panel();
			this.lab�Ŕԍ� = new System.Windows.Forms.Label();
			this.btn���� = new System.Windows.Forms.Button();
			this.btn�O�� = new System.Windows.Forms.Button();
			this.axGT�˗��� = new AxGTABLE32V2Lib.AxGTable32();
			this.btn�m�� = new System.Windows.Forms.Button();
			this.panel5 = new System.Windows.Forms.Panel();
			this.tex�˗��喼�O = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex������R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab������ = new System.Windows.Forms.Label();
			this.cmb������ = new System.Windows.Forms.ComboBox();
			this.lab�͂��於�O = new System.Windows.Forms.Label();
			this.tex�˗���J�i = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab�˗���J�i = new System.Windows.Forms.Label();
			this.lab�˗���R�[�h = new System.Windows.Forms.Label();
			this.tex�˗���R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.btn���� = new System.Windows.Forms.Button();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab�˗���^�C�g�� = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn���� = new System.Windows.Forms.Button();
			this.tex���b�Z�[�W = new System.Windows.Forms.TextBox();
			this.btn���� = new System.Windows.Forms.Button();
			this.panel6 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.gp�\���� = new System.Windows.Forms.GroupBox();
			this.cb�\�[�g�����Q = new System.Windows.Forms.ComboBox();
			this.cb�K�w���X�g�Q = new System.Windows.Forms.ComboBox();
			this.cb�\�[�g�����P = new System.Windows.Forms.ComboBox();
			this.cb�K�w���X�g�P = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btn�폜 = new System.Windows.Forms.Button();
			this.btn�ꗗ��� = new System.Windows.Forms.Button();
			this.btnCSV�o�� = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axGT�˗���)).BeginInit();
			this.panel5.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.gp�\����.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Honeydew;
			this.panel1.Controls.Add(this.lab�Ŕԍ�);
			this.panel1.Controls.Add(this.btn����);
			this.panel1.Controls.Add(this.btn�O��);
			this.panel1.Controls.Add(this.axGT�˗���);
			this.panel1.Controls.Add(this.btn�m��);
			this.panel1.Location = new System.Drawing.Point(1, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(773, 350);
			this.panel1.TabIndex = 1;
			// 
			// lab�Ŕԍ�
			// 
			this.lab�Ŕԍ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�Ŕԍ�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�Ŕԍ�.Location = new System.Drawing.Point(578, 326);
			this.lab�Ŕԍ�.Name = "lab�Ŕԍ�";
			this.lab�Ŕԍ�.Size = new System.Drawing.Size(48, 14);
			this.lab�Ŕԍ�.TabIndex = 70;
			this.lab�Ŕԍ�.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn����
			// 
			this.btn����.BackColor = System.Drawing.Color.SteelBlue;
			this.btn����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn����.ForeColor = System.Drawing.Color.White;
			this.btn����.Location = new System.Drawing.Point(626, 322);
			this.btn����.Name = "btn����";
			this.btn����.Size = new System.Drawing.Size(48, 22);
			this.btn����.TabIndex = 69;
			this.btn����.Text = "����";
			this.btn����.Click += new System.EventHandler(this.btn����_Click);
			// 
			// btn�O��
			// 
			this.btn�O��.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�O��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�O��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�O��.ForeColor = System.Drawing.Color.White;
			this.btn�O��.Location = new System.Drawing.Point(530, 322);
			this.btn�O��.Name = "btn�O��";
			this.btn�O��.Size = new System.Drawing.Size(48, 22);
			this.btn�O��.TabIndex = 68;
			this.btn�O��.Text = "�O��";
			this.btn�O��.Click += new System.EventHandler(this.btn�O��_Click);
			// 
			// axGT�˗���
			// 
			this.axGT�˗���.ContainingControl = this;
			this.axGT�˗���.DataSource = null;
			this.axGT�˗���.Location = new System.Drawing.Point(8, 8);
			this.axGT�˗���.Name = "axGT�˗���";
			this.axGT�˗���.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT�˗���.OcxState")));
			this.axGT�˗���.Size = new System.Drawing.Size(758, 307);
			this.axGT�˗���.TabIndex = 2;
			this.axGT�˗���.KeyDownEvent += new AxGTABLE32V2Lib._DGTable32Events_KeyDownEventHandler(this.axGT�˗���_KeyDownEvent);
			this.axGT�˗���.CelDblClick += new AxGTABLE32V2Lib._DGTable32Events_CelDblClickEventHandler(this.axGT�˗���_CelDblClick);
			this.axGT�˗���.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT�˗���_CurPlaceChanged);
			// 
			// btn�m��
			// 
			this.btn�m��.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�m��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�m��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�m��.ForeColor = System.Drawing.Color.White;
			this.btn�m��.Location = new System.Drawing.Point(692, 322);
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
			this.panel5.Controls.Add(this.tex�˗��喼�O);
			this.panel5.Controls.Add(this.tex������R�[�h);
			this.panel5.Controls.Add(this.lab������);
			this.panel5.Controls.Add(this.cmb������);
			this.panel5.Controls.Add(this.lab�͂��於�O);
			this.panel5.Controls.Add(this.tex�˗���J�i);
			this.panel5.Controls.Add(this.lab�˗���J�i);
			this.panel5.Controls.Add(this.lab�˗���R�[�h);
			this.panel5.Controls.Add(this.tex�˗���R�[�h);
			this.panel5.Controls.Add(this.btn����);
			this.panel5.Location = new System.Drawing.Point(1, 6);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(459, 90);
			this.panel5.TabIndex = 0;
			// 
			// tex�˗��喼�O
			// 
			this.tex�˗��喼�O.BackColor = System.Drawing.SystemColors.Window;
			this.tex�˗��喼�O.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗��喼�O.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�˗��喼�O.Location = new System.Drawing.Point(278, 4);
			this.tex�˗��喼�O.MaxLength = 10;
			this.tex�˗��喼�O.Name = "tex�˗��喼�O";
			this.tex�˗��喼�O.Size = new System.Drawing.Size(174, 23);
			this.tex�˗��喼�O.TabIndex = 1;
			this.tex�˗��喼�O.Text = "";
			// 
			// tex������R�[�h
			// 
			this.tex������R�[�h.BackColor = System.Drawing.Color.Honeydew;
			this.tex������R�[�h.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex������R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex������R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex������R�[�h.Location = new System.Drawing.Point(232, 64);
			this.tex������R�[�h.MaxLength = 12;
			this.tex������R�[�h.Name = "tex������R�[�h";
			this.tex������R�[�h.Size = new System.Drawing.Size(154, 16);
			this.tex������R�[�h.TabIndex = 61;
			this.tex������R�[�h.TabStop = false;
			this.tex������R�[�h.Text = "";
			// 
			// lab������
			// 
			this.lab������.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab������.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab������.Location = new System.Drawing.Point(8, 64);
			this.lab������.Name = "lab������";
			this.lab������.Size = new System.Drawing.Size(56, 16);
			this.lab������.TabIndex = 60;
			this.lab������.Text = "������";
			// 
			// cmb������
			// 
			this.cmb������.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb������.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cmb������.Location = new System.Drawing.Point(74, 62);
			this.cmb������.Name = "cmb������";
			this.cmb������.Size = new System.Drawing.Size(154, 20);
			this.cmb������.TabIndex = 3;
			this.cmb������.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb������_KeyDown);
			this.cmb������.SelectedIndexChanged += new System.EventHandler(this.cmb������_SelectedIndexChanged);
			// 
			// lab�͂��於�O
			// 
			this.lab�͂��於�O.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�͂��於�O.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�͂��於�O.Location = new System.Drawing.Point(234, 8);
			this.lab�͂��於�O.Name = "lab�͂��於�O";
			this.lab�͂��於�O.Size = new System.Drawing.Size(40, 16);
			this.lab�͂��於�O.TabIndex = 58;
			this.lab�͂��於�O.Text = "���O";
			// 
			// tex�˗���J�i
			// 
			this.tex�˗���J�i.BackColor = System.Drawing.SystemColors.Window;
			this.tex�˗���J�i.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗���J�i.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
			this.tex�˗���J�i.Location = new System.Drawing.Point(74, 4);
			this.tex�˗���J�i.MaxLength = 10;
			this.tex�˗���J�i.Name = "tex�˗���J�i";
			this.tex�˗���J�i.Size = new System.Drawing.Size(126, 23);
			this.tex�˗���J�i.TabIndex = 0;
			this.tex�˗���J�i.Text = "";
			// 
			// lab�˗���J�i
			// 
			this.lab�˗���J�i.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�˗���J�i.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�˗���J�i.Location = new System.Drawing.Point(8, 8);
			this.lab�˗���J�i.Name = "lab�˗���J�i";
			this.lab�˗���J�i.Size = new System.Drawing.Size(64, 16);
			this.lab�˗���J�i.TabIndex = 46;
			this.lab�˗���J�i.Text = "�J�i����";
			// 
			// lab�˗���R�[�h
			// 
			this.lab�˗���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�˗���R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�˗���R�[�h.Location = new System.Drawing.Point(8, 36);
			this.lab�˗���R�[�h.Name = "lab�˗���R�[�h";
			this.lab�˗���R�[�h.Size = new System.Drawing.Size(44, 16);
			this.lab�˗���R�[�h.TabIndex = 6;
			this.lab�˗���R�[�h.Text = "�R�[�h";
			// 
			// tex�˗���R�[�h
			// 
			this.tex�˗���R�[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex�˗���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗���R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�˗���R�[�h.Location = new System.Drawing.Point(74, 32);
			this.tex�˗���R�[�h.MaxLength = 12;
			this.tex�˗���R�[�h.Name = "tex�˗���R�[�h";
			this.tex�˗���R�[�h.Size = new System.Drawing.Size(174, 23);
			this.tex�˗���R�[�h.TabIndex = 2;
			this.tex�˗���R�[�h.Text = "";
			// 
			// btn����
			// 
			this.btn����.BackColor = System.Drawing.Color.SteelBlue;
			this.btn����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn����.ForeColor = System.Drawing.Color.White;
			this.btn����.Location = new System.Drawing.Point(388, 62);
			this.btn����.Name = "btn����";
			this.btn����.Size = new System.Drawing.Size(64, 22);
			this.btn����.TabIndex = 4;
			this.btn����.TabStop = false;
			this.btn����.Text = "����";
			this.btn����.Click += new System.EventHandler(this.btn����_Click);
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.lab�˗���^�C�g��);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(794, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab�˗���^�C�g��
			// 
			this.lab�˗���^�C�g��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�˗���^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�˗���^�C�g��.ForeColor = System.Drawing.Color.White;
			this.lab�˗���^�C�g��.Location = new System.Drawing.Point(12, 2);
			this.lab�˗���^�C�g��.Name = "lab�˗���^�C�g��";
			this.lab�˗���^�C�g��.Size = new System.Drawing.Size(264, 24);
			this.lab�˗���^�C�g��.TabIndex = 0;
			this.lab�˗���^�C�g��.Text = "���˗��匟��";
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
			this.panel8.TabIndex = 2;
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
			this.tex���b�Z�[�W.Location = new System.Drawing.Point(416, 4);
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel5);
			this.groupBox1.Location = new System.Drawing.Point(10, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(462, 98);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel1);
			this.groupBox2.Location = new System.Drawing.Point(10, 154);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(776, 358);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// gp�\����
			// 
			this.gp�\����.Controls.Add(this.cb�\�[�g�����Q);
			this.gp�\����.Controls.Add(this.cb�K�w���X�g�Q);
			this.gp�\����.Controls.Add(this.cb�\�[�g�����P);
			this.gp�\����.Controls.Add(this.cb�K�w���X�g�P);
			this.gp�\����.Controls.Add(this.label4);
			this.gp�\����.Controls.Add(this.label3);
			this.gp�\����.Location = new System.Drawing.Point(490, 76);
			this.gp�\����.Name = "gp�\����";
			this.gp�\����.Size = new System.Drawing.Size(278, 78);
			this.gp�\����.TabIndex = 1;
			this.gp�\����.TabStop = false;
			// 
			// cb�\�[�g�����Q
			// 
			this.cb�\�[�g�����Q.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb�\�[�g�����Q.Items.AddRange(new object[] {
														  "����",
														  "�~��"});
			this.cb�\�[�g�����Q.Location = new System.Drawing.Point(204, 48);
			this.cb�\�[�g�����Q.Name = "cb�\�[�g�����Q";
			this.cb�\�[�g�����Q.Size = new System.Drawing.Size(60, 20);
			this.cb�\�[�g�����Q.TabIndex = 53;
			this.cb�\�[�g�����Q.Visible = false;
			// 
			// cb�K�w���X�g�Q
			// 
			this.cb�K�w���X�g�Q.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb�K�w���X�g�Q.Items.AddRange(new object[] {
														  "",
														  "�J�i����",
														  "�R�[�h",
														  "������",
														  "���O",
														  "�d�b�ԍ�",
														  "�o�^����",
														  "�X�V����"});
			this.cb�K�w���X�g�Q.Location = new System.Drawing.Point(104, 48);
			this.cb�K�w���X�g�Q.Name = "cb�K�w���X�g�Q";
			this.cb�K�w���X�g�Q.Size = new System.Drawing.Size(96, 20);
			this.cb�K�w���X�g�Q.TabIndex = 52;
			this.cb�K�w���X�g�Q.SelectedIndexChanged += new System.EventHandler(this.cb�K�w���X�g�Q_select);
			// 
			// cb�\�[�g�����P
			// 
			this.cb�\�[�g�����P.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb�\�[�g�����P.Items.AddRange(new object[] {
														  "����",
														  "�~��"});
			this.cb�\�[�g�����P.Location = new System.Drawing.Point(204, 22);
			this.cb�\�[�g�����P.Name = "cb�\�[�g�����P";
			this.cb�\�[�g�����P.Size = new System.Drawing.Size(60, 20);
			this.cb�\�[�g�����P.TabIndex = 51;
			this.cb�\�[�g�����P.Visible = false;
			// 
			// cb�K�w���X�g�P
			// 
			this.cb�K�w���X�g�P.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb�K�w���X�g�P.Items.AddRange(new object[] {
														  "",
														  "�J�i����",
														  "�R�[�h",
														  "������",
														  "���O",
														  "�d�b�ԍ�",
														  "�o�^����",
														  "�X�V����"});
			this.cb�K�w���X�g�P.Location = new System.Drawing.Point(104, 22);
			this.cb�K�w���X�g�P.Name = "cb�K�w���X�g�P";
			this.cb�K�w���X�g�P.Size = new System.Drawing.Size(96, 20);
			this.cb�K�w���X�g�P.TabIndex = 50;
			this.cb�K�w���X�g�P.SelectedIndexChanged += new System.EventHandler(this.cb�K�w���X�g�P_select);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label4.ForeColor = System.Drawing.Color.LimeGreen;
			this.label4.Location = new System.Drawing.Point(18, 50);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 16);
			this.label4.TabIndex = 49;
			this.label4.Text = "�\�����Q";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label3.ForeColor = System.Drawing.Color.LimeGreen;
			this.label3.Location = new System.Drawing.Point(18, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 48;
			this.label3.Text = "�\�����P";
			// 
			// btn�폜
			// 
			this.btn�폜.ForeColor = System.Drawing.Color.Blue;
			this.btn�폜.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�폜.Location = new System.Drawing.Point(208, 6);
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
			this.btn�ꗗ���.Location = new System.Drawing.Point(278, 6);
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
			this.btnCSV�o��.Location = new System.Drawing.Point(348, 5);
			this.btnCSV�o��.Name = "btnCSV�o��";
			this.btnCSV�o��.Size = new System.Drawing.Size(62, 48);
			this.btnCSV�o��.TabIndex = 3;
			this.btnCSV�o��.Text = "�b�r�u�@�@�o��";
			this.btnCSV�o��.Visible = false;
			this.btnCSV�o��.Click += new System.EventHandler(this.btnCSV�o��_Click);
			// 
			// ���˗��匟��
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 574);
			this.Controls.Add(this.gp�\����);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "���˗��匟��";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 ���˗��匟��";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Closed += new System.EventHandler(this.���˗��匟��_Closed);
			this.Activated += new System.EventHandler(this.���˗��匟��_Activated);
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axGT�˗���)).EndInit();
			this.panel5.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.gp�\����.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		private void Form1_Load(object sender, System.EventArgs e)
		{
// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� START
			//�����s�I�����\�ɂ���
			axGT�˗���.CaretType = GTABLE32V2Lib.CaretTypeConstants.gktbMultiRowSelect;
// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� END
// MOD 2009.11.30 ���s�j���� ���������ɖ��O�A�������ǉ� START
			tex�˗���J�i.Text = "";
			tex�˗��喼�O.Text = "";
			tex�˗���R�[�h.Text = "";
			cmb������.Items.Clear();
			if(gsa�����敔�ۖ� != null)
			{
				cmb������.Items.Add("");
				cmb������.Items.AddRange(gsa�����敔�ۖ�);
			}
			cmb������.SelectedIndex = 0;
// MOD 2010.02.03 ���s�j���� �\�[�g�����̕ێ��@�\��ǉ� START
////			cb�K�w���X�g�P.SelectedIndex = 0;
////			cb�\�[�g�����P.SelectedIndex = 0;
////			cb�K�w���X�g�Q.SelectedIndex = 0;
////			cb�\�[�g�����Q.SelectedIndex = 0;
//			cb�K�w���X�g�P.SelectedIndex = 4;
//			cb�\�[�g�����P.SelectedIndex = 0;
//			cb�K�w���X�g�Q.SelectedIndex = 2;
//			cb�\�[�g�����Q.SelectedIndex = 0;
// MOD 2010.02.03 ���s�j���� �\�[�g�����̕ێ��@�\��ǉ� END
// MOD 2009.11.30 ���s�j���� ���������ɖ��O�A�������ǉ� END
			i�A�N�e�B�u�e�f = 0;
			s���� = "";
			tex�˗���R�[�h.Text = sIcode;
			sIcode = "";

// MOD 2008.10.01 ���s�j���� �ꗗ�ɐ������\�� START
//			axGT�˗���.Cols = 5;
			axGT�˗���.Cols = 6;
// MOD 2008.10.01 ���s�j���� �ꗗ�ɐ������\�� END
			axGT�˗���.Rows = 16;
			axGT�˗���.ColSep = "|";

// MOD 2008.10.01 ���s�j���� �ꗗ�ɐ������\�� START
//			axGT�˗���.set_RowsText(0, "|���O|�Z��|�R�[�h|�d�b�ԍ�|�J�i����|");
			axGT�˗���.set_RowsText(0, "|���O|�Z��|�R�[�h|�d�b�ԍ�|�J�i����|������|");
// MOD 2008.10.01 ���s�j���� �ꗗ�ɐ������\�� END

// MOD 2008.10.01 ���s�j���� �ꗗ�ɐ������\�� START
//			axGT�˗���.ColsWidth = "0|14.2|14.2|9.7|8.6|7|";
//			axGT�˗���.ColsAlignHorz = "1|0|0|0|0|0|";
			axGT�˗���.ColsWidth = "0|14.6|14.2|6.0|8.0|5.9|9.7|";
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� START
			�J�������̕␳(axGT�˗���);
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� END
			axGT�˗���.ColsAlignHorz = "1|0|0|0|0|0|0|";
// MOD 2008.10.01 ���s�j���� �ꗗ�ɐ������\�� END

//			axGT�˗���.set_CelForeColor(axGT�˗���.CaretRow,0,111111);
			axGT�˗���.set_CelForeColor(axGT�˗���.CaretRow,0,0x98FB98);  //BGR
			axGT�˗���.set_CelBackColor(axGT�˗���.CaretRow,0,0x006000);
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� START
			axGT�˗���.CaretRow = 1;
			axGT�˗���.CaretCol = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� END

			btn�O��.Enabled = false;
			btn����.Enabled = false;
			lab�Ŕԍ�.Text = "";			
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			sIcode = "";
			this.Close();
		}

		public void Visible����()
		{
			btn����.Visible = true;
		}
// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� START
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
// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� END

		private void axGT�˗���_CelDblClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelDblClickEvent e)
		{
			sIname = axGT�˗���.get_CelText(axGT�˗���.CaretRow,1);
			sIcode = axGT�˗���.get_CelText(axGT�˗���.CaretRow,3);
			if(sIcode != "")
				this.Close();

		}

		private void axGT�˗���_CurPlaceChanged(object sender, AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEvent e)
		{
// MOD 2010.09.21 ���s�j���� �����I�����̔w�i�F�ύX START
//			axGT�˗���.set_CelForeColor(nOldRow,0,0);
//			axGT�˗���.set_CelBackColor(nOldRow,0,0xFFFFFF);
////			axGT�˗���.set_CelForeColor(axGT�˗���.CaretRow,0,111111);
//			axGT�˗���.set_CelForeColor(axGT�˗���.CaretRow,0,0x98FB98);  //BGR
//			axGT�˗���.set_CelBackColor(axGT�˗���.CaretRow,0,0x006000);
//			nOldRow = axGT�˗���.CaretRow;
			axGT�˗���.set_CelForeColor(nOldRow,0,0);
			axGT�˗���.set_CelBackColor(nOldRow,0,0xFFFFFF);
////			axGT�˗���.set_CelForeColor(OldRow,0,0);
////			axGT�˗���.set_CelBackColor(OldRow,0,0xFFFFFF);
			if(axGT�˗���.SelStartRow == axGT�˗���.SelEndRow){
				if(nSrow > nErow){
					nWork = nSrow;
					nSrow = nErow;
					nErow = nWork;
				}
				for(short nCnt = nSrow; nCnt <= nErow; nCnt++){
					axGT�˗���.set_CelForeColor(nCnt,0,0);
					axGT�˗���.set_CelBackColor(nCnt,0,0xFFFFFF);
				}
			}
			axGT�˗���.set_CelForeColor(axGT�˗���.SelStartRow,0,0x98FB98);
			axGT�˗���.set_CelBackColor(axGT�˗���.SelStartRow,0,0x006000);
			axGT�˗���.set_CelForeColor(axGT�˗���.SelEndRow,0,0x98FB98);
			axGT�˗���.set_CelBackColor(axGT�˗���.SelEndRow,0,0x006000);
			axGT�˗���.set_CelForeColor(axGT�˗���.CaretRow,0,0x98FB98);
			axGT�˗���.set_CelBackColor(axGT�˗���.CaretRow,0,0x006000);
			if(axGT�˗���.SelEndRow > axGT�˗���.CaretRow
				&& axGT�˗���.SelStartRow <= axGT�˗���.CaretRow
				&& axGT�˗���.get_CelForeColor(axGT�˗���.SelEndRow,0) != Color.Black){
				axGT�˗���.set_CelForeColor(axGT�˗���.SelEndRow,0,0);
				axGT�˗���.set_CelBackColor(axGT�˗���.SelEndRow,0,0xFFFFFF);
			}

			if(axGT�˗���.SelEndRow < axGT�˗���.CaretRow
				&& axGT�˗���.SelStartRow >= axGT�˗���.CaretRow
				&& axGT�˗���.get_CelForeColor(axGT�˗���.SelEndRow,0) != Color.Black){
				axGT�˗���.set_CelForeColor(axGT�˗���.SelEndRow,0,0);
				axGT�˗���.set_CelBackColor(axGT�˗���.SelEndRow,0,0xFFFFFF);
			}

			nOldRow = axGT�˗���.CaretRow;
////			OldRow = axGT�˗���.CaretRow;
			nSrow  = axGT�˗���.SelStartRow;
			nErow  = axGT�˗���.SelEndRow;
// MOD 2010.09.21 ���s�j���� �����I�����̔w�i�F�ύX END
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			i�A�N�e�B�u�e�f = 1;
			axGT�˗���.CaretRow  = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� START
			axGT�˗���.CaretCol = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� END
			axGT�˗���_CurPlaceChanged(null,null);
			axGT�˗���.Clear();
// MOD 2008.10.01 ���s�j���� �ꗗ�ɐ������\�� START
			axGT�˗���.ColsWidth = "0|14.6|14.2|6.0|8.0|5.9|9.7|";
// MOD 2008.10.01 ���s�j���� �ꗗ�ɐ������\�� END
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� START
			�J�������̕␳(axGT�˗���);
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� END
// MOD 2009.11.30 ���s�j���� ���������ɖ��O�A�������ǉ� START
			btn�O��.Enabled = false;
			btn����.Enabled = false;
			lab�Ŕԍ�.Text = "";
// MOD 2009.11.30 ���s�j���� ���������ɖ��O�A�������ǉ� END

			// �󔒏���
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//			tex�˗���J�i.Text   = tex�˗���J�i.Text.Trim();
			if(gs�I�v�V����[18].Equals("1")){
				tex�˗���J�i.Text   = tex�˗���J�i.Text.TrimEnd();
			}else{
				tex�˗���J�i.Text   = tex�˗���J�i.Text.Trim();
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
			tex�˗���R�[�h.Text = tex�˗���R�[�h.Text.Trim();
			if(!���p�`�F�b�N(tex�˗���J�i,"�˗���J�i")) return;
			if(!���p�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;
// MOD 2009.11.30 ���s�j���� ���������ɖ��O�A�������ǉ� START
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//			tex�˗��喼�O.Text = tex�˗��喼�O.Text.Trim();
			if(gs�I�v�V����[18].Equals("1")){
				tex�˗��喼�O.Text = tex�˗��喼�O.Text.TrimEnd();
			}else{
				tex�˗��喼�O.Text = tex�˗��喼�O.Text.Trim();
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
			if(!�S�p�`�F�b�N(tex�˗��喼�O,"�˗��喼�O")) return;
// MOD 2009.11.30 ���s�j���� ���������ɖ��O�A�������ǉ� END

// MOD 2009.11.30 ���s�j���� ���������ɖ��O�A�������ǉ� START
			// ��������\��
			s������b�c = "";
			s���ۂb�c   = "";
			tex������R�[�h.Text = "";
			if(gsa������b�c.Length > 0 && cmb������.SelectedIndex > 0){
				s������b�c = gsa������b�c[cmb������.SelectedIndex - 1];
				s���ۂb�c   = gsa�����敔�ۂb�c[cmb������.SelectedIndex - 1];
				tex������R�[�h.Text = s������b�c.TrimEnd() + " " + s���ۂb�c.TrimEnd();
			}
// MOD 2009.11.30 ���s�j���� ���������ɖ��O�A�������ǉ� END

			i���ݕŐ� = 1;
			axGT�˗���.CaretRow = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� START
			axGT�˗���.CaretCol = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� END
			axGT�˗���.set_CelForeColor(nOldRow,0,0);
//			axGT�˗���.set_CelForeColor(axGT�˗���.CaretRow,0,111111);
			axGT�˗���.set_CelForeColor(axGT�˗���.CaretRow,0,0x98FB98);  //BGR
			axGT�˗���.set_CelBackColor(axGT�˗���.CaretRow,0,0x006000);
			nOldRow = axGT�˗���.CaretRow;

			s�˗���ꗗ = new string[1];
			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				tex���b�Z�[�W.Text = "�������D�D�D";
				if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
// MOD 2009.11.30 ���s�j���� ���������ɖ��O�A�������ǉ� START
//				s�˗���ꗗ = sv_goirai.Get_irainusi(gsa���[�U,gs����b�c,gs����b�c,tex�˗���J�i.Text,tex�˗���R�[�h.Text);
				string[] sa�L�[ = new string[]{
					gs����b�c.TrimEnd()
					, gs����b�c.TrimEnd()
					, tex�˗���J�i.Text.TrimEnd()
					, tex�˗���R�[�h.Text.TrimEnd()
					, tex�˗��喼�O.Text.TrimEnd()
					, s������b�c.TrimEnd()
					, s���ۂb�c.TrimEnd()
					, cb�K�w���X�g�P.SelectedIndex.ToString().TrimEnd()
					, cb�\�[�g�����P.SelectedIndex.ToString().TrimEnd()
					, cb�K�w���X�g�Q.SelectedIndex.ToString().TrimEnd()
					, cb�\�[�g�����Q.SelectedIndex.ToString().TrimEnd()
				};
				s�˗���ꗗ = sv_goirai.Get_irainusi2(gsa���[�U,sa�L�[);
// MOD 2009.11.30 ���s�j���� ���������ɖ��O�A�������ǉ� END
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				s�˗���ꗗ[0] = gs�ʐM�G���[;
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				s�˗���ꗗ[0] = "�ʐM�G���[�F" + ex.Message;
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;

			tex���b�Z�[�W.Text = s�˗���ꗗ[0];
			if(s�˗���ꗗ[0].Length == 4)
			{
				tex���b�Z�[�W.Text = "";
// MOD 2005.05.10 ���s�j�����J ��s�ڋ� START
//				i�ő�Ő� = (s�˗���ꗗ.Length - 2) / axGT�˗���.Rows + 1;
				i�ő�Ő� = (s�˗���ꗗ.Length - 2) / (axGT�˗���.Rows - 1) + 1;
// MOD 2005.05.10 ���s�j�����J ��s�ڋ� END
				if (i���ݕŐ� > i�ő�Ő�)
					i���ݕŐ� = i�ő�Ő�;
				�ŏ��ݒ�();
			}
			else
			{
				if(s�˗���ꗗ[0].Equals("�Y���f�[�^������܂���"))
				{
					tex���b�Z�[�W.Text = "";
					MessageBox.Show("�Y���f�[�^������܂���","���˗��匟��",MessageBoxButtons.OK);
				}
				else
				{
					axGT�˗���.Clear();
					i���ݕŐ� = 1;
					btn�O��.Enabled = false;
					btn����.Enabled = false;
					lab�Ŕԍ�.Text = "";
					�r�[�v��();
				}
				tex�˗���J�i.Focus();
			}
		}

		private void btn�m��_Click(object sender, System.EventArgs e)
		{
			sIname = axGT�˗���.get_CelText(axGT�˗���.CaretRow,1);
			sIcode = axGT�˗���.get_CelText(axGT�˗���.CaretRow,3);
			if(sIcode != "")
				this.Close();

		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			s���� = "T";
			sIcode = axGT�˗���.get_CelText(axGT�˗���.CaretRow,3);
			if(sIcode != "")
				this.Close();
		}

		private void axGT�˗���_KeyDownEvent(object sender, AxGTABLE32V2Lib._DGTable32Events_KeyDownEvent e)
		{
			if (e.keyCode == 13)
			{
				btn�m��_Click(sender, null);
			}
			if (e.keyCode == 9)
			{
				this.SelectNextControl(axGT�˗���, true, true, true, true);
			}
		}

		private void tex�˗���R�[�h_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btn����_Click(sender, e);
			}
		}

		private void btn�O��_Click(object sender, System.EventArgs e)
		{
			i���ݕŐ�--;
			�ŏ��ݒ�();
// ADD 2005.05.10 ���s�j�����J ��s�ڑI�� START
			axGT�˗���.CaretRow = 1;
			axGT�˗���_CurPlaceChanged(null,null);
// ADD 2005.05.10 ���s�j�����J ��s�ڑI�� END
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			i���ݕŐ�++;
			�ŏ��ݒ�();
// ADD 2005.05.10 ���s�j�����J ��s�ڑI�� START
			axGT�˗���.CaretRow = 1;
			axGT�˗���_CurPlaceChanged(null,null);
// ADD 2005.05.10 ���s�j�����J ��s�ڑI�� END
		}

		private void �ŏ��ݒ�()
		{
			axGT�˗���.Clear();

// MOD 2005.05.10 ���s�j�����J ��s�ڋ� START
//			i�J�n�� = (i���ݕŐ� - 1) * axGT�˗���.Rows + 1;
			i�J�n�� = (i���ݕŐ� - 1) * (axGT�˗���.Rows - 1) + 1;
//			i�I���� = i���ݕŐ� * axGT�˗���.Rows;
			i�I���� = i���ݕŐ� * (axGT�˗���.Rows - 1);

//			short s�\���� = (short)1;
			short s�\���� = (short)2;
// MOD 2005.05.10 ���s�j�����J ��s�ڋ� END
			for(short sCnt = (short)i�J�n��; sCnt < s�˗���ꗗ.Length && sCnt <= i�I���� ; sCnt++)
			{
				axGT�˗���.set_RowsText(s�\����, s�˗���ꗗ[sCnt]);
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
			axGT�˗���.Focus();
		}

		private void ���˗��匟��_Activated(object sender, System.EventArgs e)
		{
			if(tex�˗���R�[�h.Text.Trim().Length != 0 && i�A�N�e�B�u�e�f == 0)
				btn����_Click(sender,e);
		}

// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� START
		private void ���˗��匟��_Closed(object sender, System.EventArgs e)
		{
// ADD 2005.07.08 ���s�j�����J ���ʃ{�^�������� START
			btn����.Visible = false;
// ADD 2005.07.08 ���s�j�����J ���ʃ{�^�������� END
// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� START
			btnCSV�o��.Visible = false;
			btn�ꗗ���.Visible = false;
			btn�폜.Visible = false;
// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� END
			tex�˗���J�i.Text   = " ";
			tex�˗���R�[�h.Text = "";
// MOD 2009.11.30 ���s�j���� ���������ɖ��O�A�������ǉ� START
			tex�˗��喼�O.Text = "";
			cmb������.SelectedIndex = 0;
// MOD 2010.02.03 ���s�j���� �\�[�g�����̕ێ��@�\��ǉ� START
////			cb�K�w���X�g�P.SelectedIndex = 0;
////			cb�\�[�g�����P.SelectedIndex = 0;
////			cb�K�w���X�g�Q.SelectedIndex = 0;
////			cb�\�[�g�����Q.SelectedIndex = 0;
//			cb�K�w���X�g�P.SelectedIndex = 4;
//			cb�\�[�g�����P.SelectedIndex = 0;
//			cb�K�w���X�g�Q.SelectedIndex = 2;
//			cb�\�[�g�����Q.SelectedIndex = 0;
// MOD 2010.02.03 ���s�j���� �\�[�g�����̕ێ��@�\��ǉ� END
// MOD 2009.11.30 ���s�j���� ���������ɖ��O�A�������ǉ� END
			tex���b�Z�[�W.Text = "";
			axGT�˗���.Clear();
			axGT�˗���.CaretRow  = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� START
			axGT�˗���.CaretCol = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� END
			axGT�˗���_CurPlaceChanged(null,null);
			tex�˗���J�i.Focus();
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� START
			gs���˗��匟��_�\�����P      = cb�K�w���X�g�P.Text.TrimEnd();
			gs���˗��匟��_�\�����P_���� = cb�\�[�g�����P.Text.TrimEnd();
			gs���˗��匟��_�\�����Q      = cb�K�w���X�g�Q.Text.TrimEnd();
			gs���˗��匟��_�\�����Q_���� = cb�\�[�g�����Q.Text.TrimEnd();
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� END
		}
// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� END
// MOD 2009.11.30 ���s�j���� ���������ɖ��O�A�������ǉ� START
		private void cb�K�w���X�g�P_select(object sender, System.EventArgs e)
		{
			if(cb�K�w���X�g�P.SelectedIndex != 0){
				cb�\�[�g�����P.Visible = true;
			}else{
				cb�\�[�g�����P.Visible = false;
			}
		}

		private void cb�K�w���X�g�Q_select(object sender, System.EventArgs e)
		{
			if(cb�K�w���X�g�Q.SelectedIndex != 0){
				cb�\�[�g�����Q.Visible = true;
			}else{
				cb�\�[�g�����Q.Visible = false;
			}
		}

		private void cmb������_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btn����_Click(sender, e);
			}
		}

		private void cmb������_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// ��������\��
			s������b�c = "";
			s���ۂb�c   = "";
			tex������R�[�h.Text = "";
			if(gsa������b�c.Length > 0 && cmb������.SelectedIndex > 0)
			{
				s������b�c = gsa������b�c[cmb������.SelectedIndex - 1];
				s���ۂb�c   = gsa�����敔�ۂb�c[cmb������.SelectedIndex - 1];
				tex������R�[�h.Text = s������b�c.TrimEnd() + " " + s���ۂb�c.TrimEnd();
			}
		}
// MOD 2009.11.30 ���s�j���� ���������ɖ��O�A�������ǉ� END
// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� START
		private void btn�폜_Click(object sender, System.EventArgs e)
		{
			tex���b�Z�[�W.Text = "";

			string[] as���˗���b�c = {};
			DialogResult result;

			result = MessageBox.Show("�w�肳�ꂽ�f�[�^���폜���܂��B��낵���ł����H"
									,"�폜",MessageBoxButtons.YesNo);
			if(result == DialogResult.Yes){
				int iCnt  = 0;
				int iPosS = 0;
				int iPosE = 0;
				if(axGT�˗���.SelEndRow >= axGT�˗���.SelStartRow){
					iPosS = (int)axGT�˗���.SelStartRow;
					iPosE = (int)axGT�˗���.SelEndRow  ;
				}else{
					iPosS = (int)axGT�˗���.SelEndRow  ;
					iPosE = (int)axGT�˗���.SelStartRow;
				}
				iCnt = iPosE - iPosS + 1;
				as���˗���b�c = new string[iCnt];
				int iPos = 0;
				for(int iLine = iPosS; iLine <= iPosE; iLine++){
					as���˗���b�c[iPos++] = axGT�˗���.get_CelText((short)iLine,3).Trim();
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
					sData[3] = "���˗���";
					sData[4] = gs���p�҂b�c;

					if(sv_otodoke == null) sv_goirai = new is2goirai.Service1();
					sList = sv_goirai.Del_irainusis(gsa���[�U, sData, as���˗���b�c);
					// [����I��]���A��ʂ��N���A����
					if(sList[0].Length != 4){
						�r�[�v��();
// MOD 2011.01.18 ���s�j���� �������폜�@�\�̏�Q�Ή� START
//						tex���b�Z�[�W.Text = sList[0];
//						btn����_Click(sender,e);
						btn����_Click(sender,e);
						tex���b�Z�[�W.Text = sList[0];
// MOD 2011.01.18 ���s�j���� �������폜�@�\�̏�Q�Ή� END
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
			}
// MOD 2010.09.22 ���s�j���� �폜�F[������]�I�����̏�Q�C�� START
//			tex���b�Z�[�W.Text = "";
//			btn����_Click(sender,e);
// MOD 2010.09.22 ���s�j���� �폜�F[������]�I�����̏�Q�C�� END
			return;
		}

		private void btn�ꗗ���_Click(object sender, System.EventArgs e)
		{
			tex�˗���J�i.Text   = tex�˗���J�i.Text.TrimEnd();
			tex�˗���R�[�h.Text = tex�˗���R�[�h.Text.TrimEnd();
			tex�˗��喼�O.Text   = tex�˗��喼�O.Text.TrimEnd();
			if(!���p�`�F�b�N(tex�˗���J�i,"�˗���J�i")) return;
			if(!���p�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;
			if(!�S�p�`�F�b�N(tex�˗��喼�O,"�˗��喼�O")) return;

			// ��������\��
			s������b�c = "";
			s���ۂb�c   = "";
			tex������R�[�h.Text = "";
			if(gsa������b�c.Length > 0 && cmb������.SelectedIndex > 0){
				s������b�c = gsa������b�c[cmb������.SelectedIndex - 1];
				s���ۂb�c   = gsa�����敔�ۂb�c[cmb������.SelectedIndex - 1];
				tex������R�[�h.Text = s������b�c.TrimEnd() + " " + s���ۂb�c.TrimEnd();
			}

			tex���b�Z�[�W.Text = "���˗���ꗗ������D�D�D";
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				if(sv_print == null) sv_print = new is2print.Service1();
				string[] sa�L�[ = new string[]{
					gs����b�c.TrimEnd()
					, gs����b�c.TrimEnd()
					, tex�˗���J�i.Text.TrimEnd()
					, tex�˗���R�[�h.Text.TrimEnd()
					, tex�˗��喼�O.Text.TrimEnd()
					, s������b�c.TrimEnd()
					, s���ۂb�c.TrimEnd()
					, cb�K�w���X�g�P.SelectedIndex.ToString().TrimEnd()
					, cb�\�[�g�����P.SelectedIndex.ToString().TrimEnd()
					, cb�K�w���X�g�Q.SelectedIndex.ToString().TrimEnd()
					, cb�\�[�g�����Q.SelectedIndex.ToString().TrimEnd()
				};

				string[] sRet = new string[1];
				IEnumerator iEnum
				 = sv_print.Get_ConsignorPrintData(gsa���[�U,sa�L�[).GetEnumerator();
				iEnum.MoveNext();
				sRet = (string[])iEnum.Current;
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
				}else{
					tex���b�Z�[�W.Text = sRet[0];
					�r�[�v��();
				}
			}catch (System.Net.WebException){
				tex���b�Z�[�W.Text = gs�ʐM�G���[;
				�r�[�v��();
			}catch (Exception ex){
				tex���b�Z�[�W.Text = ex.Message;
				�r�[�v��();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
			tex�˗���J�i.Focus();
		}

		private void btnCSV�o��_Click(object sender, System.EventArgs e)
		{
			tex���b�Z�[�W.Text = "";
			tex�˗���J�i.Text   = tex�˗���J�i.Text.TrimEnd();
			tex�˗���R�[�h.Text = tex�˗���R�[�h.Text.TrimEnd();
			tex�˗��喼�O.Text   = tex�˗��喼�O.Text.TrimEnd();
			if(!���p�`�F�b�N(tex�˗���J�i,"�˗���J�i")) return;
			if(!���p�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;
			if(!�S�p�`�F�b�N(tex�˗��喼�O,"�˗��喼�O")) return;

			// ��������\��
			s������b�c = "";
			s���ۂb�c   = "";
			tex������R�[�h.Text = "";
			if(gsa������b�c.Length > 0 && cmb������.SelectedIndex > 0){
				s������b�c = gsa������b�c[cmb������.SelectedIndex - 1];
				s���ۂb�c   = gsa�����敔�ۂb�c[cmb������.SelectedIndex - 1];
				tex������R�[�h.Text = s������b�c.TrimEnd() + " " + s���ۂb�c.TrimEnd();
			}

			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try{
				String[] sList;
				if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
				string[] sa�L�[ = new string[]{
					gs����b�c.TrimEnd()
					, gs����b�c.TrimEnd()
					, tex�˗���J�i.Text.TrimEnd()
					, tex�˗���R�[�h.Text.TrimEnd()
					, tex�˗��喼�O.Text.TrimEnd()
					, s������b�c.TrimEnd()
					, s���ۂb�c.TrimEnd()
					, cb�K�w���X�g�P.SelectedIndex.ToString().TrimEnd()
					, cb�\�[�g�����P.SelectedIndex.ToString().TrimEnd()
					, cb�K�w���X�g�Q.SelectedIndex.ToString().TrimEnd()
					, cb�\�[�g�����Q.SelectedIndex.ToString().TrimEnd()
				};

				sList = sv_goirai.Get_csvwrite2(gsa���[�U, sa�L�[);
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
			tex�˗���J�i.Focus();
		}
// MOD 2010.09.08 ���s�j���� �b�r�u�o�͋@�\�̒ǉ� END
	}
}
