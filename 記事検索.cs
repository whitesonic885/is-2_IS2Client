using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [�L���o�^]�A[�L������]�A[�A�����i����]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// MOD 2010.02.02 ���s�j���� �擪�ɋ󔒍s������ 
	// MOD 2010.02.12 ���s�j���� ��L�C����[�L���o�^]�A[�L������]�ɓK�p���� 
	// MOD 2010.03.01 ���s�j���� �S�p���p���݉\�ɂ��� 
	// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� 
	// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX 
	// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� 
	//--------------------------------------------------------------------------
	// MOD 2011.01.25 ���s�j���� �u���[�h�Ɏ��s�v�Ή� 
	// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� 
	//--------------------------------------------------------------------------
	public class �L������ : ���ʃt�H�[��
	{
		public string sKcode;
		public string s�L��;
		public string sKcode2;
		public string s�L���Q;
// ADD 2005.05.16 ���s�j�ɉ� �A���w������p START
		public bool b�A���w��;
// ADD 2005.05.16 ���s�j�ɉ� �A���w������p END
// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX START
		public string s�A�����i���� = "";
// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX START

		private short    nOldRow    = 0;
		private string   s�X�V���� = "";
		private string[] s�L���ꗗ;
		private int      i���ݕŐ�;
		private int      i�ő�Ő�;
		private int      i�J�n��;
		private int      i�I����;
		
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Button btn�m��;
		public  System.Windows.Forms.Label lab�L���^�C�g��;
		private System.Windows.Forms.TextBox tex���b�Z�[�W;
		private System.Windows.Forms.Button btn����;
		private AxGTABLE32V2Lib.AxGTable32 axGT�L��;
		private System.Windows.Forms.Button btn�ꗗ�\;
		private System.Windows.Forms.Label lab�L����;
		private ���ʃe�L�X�g�{�b�N�X tex�L����;
		private ���ʃe�L�X�g�{�b�N�X tex�L���R�[�h;
		private System.Windows.Forms.Button btn�폜;
		private System.Windows.Forms.Button btn�X�V;
		private System.Windows.Forms.Label lab�Ŕԍ�;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Button btn�O��;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lab�L���R�[�h;
		private System.Windows.Forms.Label lab�R�[�h�K�{;
		private System.Windows.Forms.Label lab���̕K�{;
		private System.Windows.Forms.Button btn�߂�;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		public �L������()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
			�c�o�h�\���T�C�Y�ϊ�();
//			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
				this.axGT�L��.Size = new System.Drawing.Size(320, 308);
//			}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(�L������));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn�߂� = new System.Windows.Forms.Button();
            this.lab�Ŕԍ� = new System.Windows.Forms.Label();
            this.btn���� = new System.Windows.Forms.Button();
            this.btn�O�� = new System.Windows.Forms.Button();
            this.btn�X�V = new System.Windows.Forms.Button();
            this.btn�폜 = new System.Windows.Forms.Button();
            this.lab�L���R�[�h = new System.Windows.Forms.Label();
            this.tex�L���R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
            this.lab�R�[�h�K�{ = new System.Windows.Forms.Label();
            this.lab���̕K�{ = new System.Windows.Forms.Label();
            this.lab�L���� = new System.Windows.Forms.Label();
            this.tex�L���� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
            this.axGT�L�� = new AxGTABLE32V2Lib.AxGTable32();
            this.btn�m�� = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lab�L���^�C�g�� = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btn�ꗗ�\ = new System.Windows.Forms.Button();
            this.tex���b�Z�[�W = new System.Windows.Forms.TextBox();
            this.btn���� = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ds�����)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGT�L��)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Honeydew;
            this.panel1.Controls.Add(this.btn�߂�);
            this.panel1.Controls.Add(this.lab�Ŕԍ�);
            this.panel1.Controls.Add(this.btn����);
            this.panel1.Controls.Add(this.btn�O��);
            this.panel1.Controls.Add(this.btn�X�V);
            this.panel1.Controls.Add(this.btn�폜);
            this.panel1.Controls.Add(this.lab�L���R�[�h);
            this.panel1.Controls.Add(this.tex�L���R�[�h);
            this.panel1.Controls.Add(this.lab�R�[�h�K�{);
            this.panel1.Controls.Add(this.lab���̕K�{);
            this.panel1.Controls.Add(this.lab�L����);
            this.panel1.Controls.Add(this.tex�L����);
            this.panel1.Controls.Add(this.axGT�L��);
            this.panel1.Controls.Add(this.btn�m��);
            this.panel1.Location = new System.Drawing.Point(1, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 446);
            this.panel1.TabIndex = 0;
            // 
            // btn�߂�
            // 
            this.btn�߂�.BackColor = System.Drawing.Color.SteelBlue;
            this.btn�߂�.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn�߂�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn�߂�.ForeColor = System.Drawing.Color.White;
            this.btn�߂�.Location = new System.Drawing.Point(230, 410);
            this.btn�߂�.Name = "btn�߂�";
            this.btn�߂�.Size = new System.Drawing.Size(64, 22);
            this.btn�߂�.TabIndex = 4;
            this.btn�߂�.Text = "�߂�";
            this.btn�߂�.UseVisualStyleBackColor = false;
            this.btn�߂�.Click += new System.EventHandler(this.btn�߂�_Click);
            // 
            // lab�Ŕԍ�
            // 
            this.lab�Ŕԍ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab�Ŕԍ�.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab�Ŕԍ�.Location = new System.Drawing.Point(282, 326);
            this.lab�Ŕԍ�.Name = "lab�Ŕԍ�";
            this.lab�Ŕԍ�.Size = new System.Drawing.Size(48, 14);
            this.lab�Ŕԍ�.TabIndex = 64;
            this.lab�Ŕԍ�.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn����
            // 
            this.btn����.BackColor = System.Drawing.Color.SteelBlue;
            this.btn����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn����.ForeColor = System.Drawing.Color.White;
            this.btn����.Location = new System.Drawing.Point(330, 322);
            this.btn����.Name = "btn����";
            this.btn����.Size = new System.Drawing.Size(48, 22);
            this.btn����.TabIndex = 63;
            this.btn����.Text = "����";
            this.btn����.UseVisualStyleBackColor = false;
            this.btn����.Click += new System.EventHandler(this.btn����_Click);
            // 
            // btn�O��
            // 
            this.btn�O��.BackColor = System.Drawing.Color.SteelBlue;
            this.btn�O��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn�O��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn�O��.ForeColor = System.Drawing.Color.White;
            this.btn�O��.Location = new System.Drawing.Point(234, 322);
            this.btn�O��.Name = "btn�O��";
            this.btn�O��.Size = new System.Drawing.Size(48, 22);
            this.btn�O��.TabIndex = 62;
            this.btn�O��.Text = "�O��";
            this.btn�O��.UseVisualStyleBackColor = false;
            this.btn�O��.Click += new System.EventHandler(this.btn�O��_Click);
            // 
            // btn�X�V
            // 
            this.btn�X�V.BackColor = System.Drawing.Color.SteelBlue;
            this.btn�X�V.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn�X�V.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn�X�V.ForeColor = System.Drawing.Color.White;
            this.btn�X�V.Location = new System.Drawing.Point(158, 410);
            this.btn�X�V.Name = "btn�X�V";
            this.btn�X�V.Size = new System.Drawing.Size(64, 22);
            this.btn�X�V.TabIndex = 3;
            this.btn�X�V.Text = "�ۑ�";
            this.btn�X�V.UseVisualStyleBackColor = false;
            this.btn�X�V.Click += new System.EventHandler(this.btn�X�V_Click);
            // 
            // btn�폜
            // 
            this.btn�폜.BackColor = System.Drawing.Color.SteelBlue;
            this.btn�폜.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn�폜.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn�폜.ForeColor = System.Drawing.Color.White;
            this.btn�폜.Location = new System.Drawing.Point(230, 410);
            this.btn�폜.Name = "btn�폜";
            this.btn�폜.Size = new System.Drawing.Size(64, 22);
            this.btn�폜.TabIndex = 4;
            this.btn�폜.Text = "�폜";
            this.btn�폜.UseVisualStyleBackColor = false;
            this.btn�폜.Click += new System.EventHandler(this.btn�폜_Click);
            // 
            // lab�L���R�[�h
            // 
            this.lab�L���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab�L���R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab�L���R�[�h.Location = new System.Drawing.Point(22, 352);
            this.lab�L���R�[�h.Name = "lab�L���R�[�h";
            this.lab�L���R�[�h.Size = new System.Drawing.Size(58, 14);
            this.lab�L���R�[�h.TabIndex = 61;
            this.lab�L���R�[�h.Text = "�L���R�[�h";
            // 
            // tex�L���R�[�h
            // 
            this.tex�L���R�[�h.BackColor = System.Drawing.SystemColors.Window;
            this.tex�L���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex�L���R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tex�L���R�[�h.Location = new System.Drawing.Point(80, 348);
            this.tex�L���R�[�h.MaxLength = 4;
            this.tex�L���R�[�h.Name = "tex�L���R�[�h";
            this.tex�L���R�[�h.Size = new System.Drawing.Size(60, 23);
            this.tex�L���R�[�h.TabIndex = 1;
            this.tex�L���R�[�h.Text = "1234";
            // 
            // lab�R�[�h�K�{
            // 
            this.lab�R�[�h�K�{.ForeColor = System.Drawing.Color.Red;
            this.lab�R�[�h�K�{.Location = new System.Drawing.Point(8, 352);
            this.lab�R�[�h�K�{.Name = "lab�R�[�h�K�{";
            this.lab�R�[�h�K�{.Size = new System.Drawing.Size(14, 14);
            this.lab�R�[�h�K�{.TabIndex = 59;
            this.lab�R�[�h�K�{.Text = "��";
            // 
            // lab���̕K�{
            // 
            this.lab���̕K�{.ForeColor = System.Drawing.Color.Red;
            this.lab���̕K�{.Location = new System.Drawing.Point(8, 382);
            this.lab���̕K�{.Name = "lab���̕K�{";
            this.lab���̕K�{.Size = new System.Drawing.Size(14, 14);
            this.lab���̕K�{.TabIndex = 57;
            this.lab���̕K�{.Text = "��";
            // 
            // lab�L����
            // 
            this.lab�L����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab�L����.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab�L����.Location = new System.Drawing.Point(22, 382);
            this.lab�L����.Name = "lab�L����";
            this.lab�L����.Size = new System.Drawing.Size(58, 14);
            this.lab�L����.TabIndex = 56;
            this.lab�L����.Text = "�L����";
            // 
            // tex�L����
            // 
            this.tex�L����.BackColor = System.Drawing.SystemColors.Window;
            this.tex�L����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex�L����.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tex�L����.Location = new System.Drawing.Point(80, 378);
            this.tex�L����.MaxLength = 30;
            this.tex�L����.Name = "tex�L����";
            this.tex�L����.Size = new System.Drawing.Size(368, 23);
            this.tex�L����.TabIndex = 2;
            this.tex�L����.Text = "MMMMMMMMMWMMMMMMMMMWMMMMMMMMMW";
            // 
            // axGT�L��
            // 
            this.axGT�L��.DataSource = null;
            this.axGT�L��.Location = new System.Drawing.Point(64, 10);
            this.axGT�L��.Name = "axGT�L��";
            this.axGT�L��.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT�L��.OcxState")));
            this.axGT�L��.Size = new System.Drawing.Size(320, 308);
            this.axGT�L��.TabIndex = 0;
            this.axGT�L��.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT�L��_CurPlaceChanged);
            this.axGT�L��.CelClick += new AxGTABLE32V2Lib._DGTable32Events_CelClickEventHandler(this.axGT�L��_CelClick);
            this.axGT�L��.CelDblClick += new AxGTABLE32V2Lib._DGTable32Events_CelDblClickEventHandler(this.axGT�L��_CelDblClick);
            this.axGT�L��.KeyDownEvent += new AxGTABLE32V2Lib._DGTable32Events_KeyDownEventHandler(this.axGT�L��_KeyDownEvent);
            // 
            // btn�m��
            // 
            this.btn�m��.BackColor = System.Drawing.Color.SteelBlue;
            this.btn�m��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn�m��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn�m��.ForeColor = System.Drawing.Color.White;
            this.btn�m��.Location = new System.Drawing.Point(302, 410);
            this.btn�m��.Name = "btn�m��";
            this.btn�m��.Size = new System.Drawing.Size(64, 22);
            this.btn�m��.TabIndex = 5;
            this.btn�m��.Text = "�m��";
            this.btn�m��.UseVisualStyleBackColor = false;
            this.btn�m��.Click += new System.EventHandler(this.btn�m��_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.panel7.Controls.Add(this.lab�L���^�C�g��);
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(800, 26);
            this.panel7.TabIndex = 13;
            // 
            // lab�L���^�C�g��
            // 
            this.lab�L���^�C�g��.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab�L���^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab�L���^�C�g��.ForeColor = System.Drawing.Color.White;
            this.lab�L���^�C�g��.Location = new System.Drawing.Point(12, 2);
            this.lab�L���^�C�g��.Name = "lab�L���^�C�g��";
            this.lab�L���^�C�g��.Size = new System.Drawing.Size(264, 24);
            this.lab�L���^�C�g��.TabIndex = 0;
            this.lab�L���^�C�g��.Text = "�L������";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.PaleGreen;
            this.panel8.Controls.Add(this.btn�ꗗ�\);
            this.panel8.Controls.Add(this.tex���b�Z�[�W);
            this.panel8.Controls.Add(this.btn����);
            this.panel8.Location = new System.Drawing.Point(0, 516);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(800, 58);
            this.panel8.TabIndex = 1;
            // 
            // btn�ꗗ�\
            // 
            this.btn�ꗗ�\.ForeColor = System.Drawing.Color.Blue;
            this.btn�ꗗ�\.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn�ꗗ�\.Location = new System.Drawing.Point(68, 6);
            this.btn�ꗗ�\.Name = "btn�ꗗ�\";
            this.btn�ꗗ�\.Size = new System.Drawing.Size(54, 48);
            this.btn�ꗗ�\.TabIndex = 7;
            this.btn�ꗗ�\.Text = "�ꗗ�\�@���";
            this.btn�ꗗ�\.Click += new System.EventHandler(this.btn�ꗗ�\_Click);
            // 
            // tex���b�Z�[�W
            // 
            this.tex���b�Z�[�W.BackColor = System.Drawing.Color.PaleGreen;
            this.tex���b�Z�[�W.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex���b�Z�[�W.ForeColor = System.Drawing.Color.Red;
            this.tex���b�Z�[�W.Location = new System.Drawing.Point(126, 4);
            this.tex���b�Z�[�W.Multiline = true;
            this.tex���b�Z�[�W.Name = "tex���b�Z�[�W";
            this.tex���b�Z�[�W.ReadOnly = true;
            this.tex���b�Z�[�W.Size = new System.Drawing.Size(336, 50);
            this.tex���b�Z�[�W.TabIndex = 0;
            this.tex���b�Z�[�W.TabStop = false;
            // 
            // btn����
            // 
            this.btn����.ForeColor = System.Drawing.Color.Red;
            this.btn����.Location = new System.Drawing.Point(8, 6);
            this.btn����.Name = "btn����";
            this.btn����.Size = new System.Drawing.Size(54, 48);
            this.btn����.TabIndex = 6;
            this.btn����.TabStop = false;
            this.btn����.Text = "����";
            this.btn����.Click += new System.EventHandler(this.btn����_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(0, 0);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 0;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(0, 0);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.PaleGreen;
            this.panel6.Location = new System.Drawing.Point(0, 26);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(800, 26);
            this.panel6.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(6, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 454);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // �L������
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(468, 574);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(474, 607);
            this.Name = "�L������";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "is-2 �L������";
            this.Closed += new System.EventHandler(this.�L������_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.On�G���^�[�ړ�);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.On�G���^�[�L�����Z��);
            ((System.ComponentModel.ISupportInitialize)(this.ds�����)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGT�L��)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
			sKcode    = "";
			s�L��     = "";
			sKcode2   = "";
			s�L���Q   = "";

			axGT�L��.Cols = 3;
// MOD 2010.02.02 ���s�j���� �擪�ɋ󔒍s������ START
//			axGT�L��.Rows = 15;
			axGT�L��.Rows = 16;
// MOD 2010.02.02 ���s�j���� �擪�ɋ󔒍s������ START
			axGT�L��.ColSep = "|";

			axGT�L��.set_RowsText(0, "|�R�[�h|�L��||");

// MOD 2010.03.01 ���s�j���� �S�p���p���݉\�ɂ��� START
//			axGT�L��.ColsWidth = "0|4|10.9|0|";
			axGT�L��.ColsWidth = "0|3.4|21.2|0|";
// MOD 2010.03.01 ���s�j���� �S�p���p���݉\�ɂ��� END
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� START
			�J�������̕␳(axGT�L��);
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� END
			axGT�L��.ColsAlignHorz = "1|1|0|0|";
            
//			axGT�L��.set_CelForeColor(axGT�L��.CaretRow,0,111111);
			axGT�L��.set_CelForeColor(axGT�L��.CaretRow,0,0x98FB98);  //BGR
			axGT�L��.set_CelBackColor(axGT�L��.CaretRow,0,0x006000);

			// ADD 2005.05.16 ���s�j�ɉ� �A���w���͍X�V�ł��Ȃ� START
			if(b�A���w��)
			{
				lab�R�[�h�K�{.Visible = false;
				lab�L���R�[�h.Visible = false;
				tex�L���R�[�h.Visible = false;
				lab���̕K�{.Visible = false;
				lab�L����.Visible = false;
				tex�L����.Visible = false;
				btn�X�V.Visible = false;
				btn�폜.Visible = false;
// ADD 2005.07.22 ���s�j�����J �߂�{�^���ǉ� START
				btn�߂�.Visible = false;
// ADD 2005.07.22 ���s�j�����J �߂�{�^���ǉ� END
// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
//				this.Width = 800;
//				this.tex���b�Z�[�W.Width = 656;
// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� END
			}
			else
			{
				lab�R�[�h�K�{.Visible = true;
				lab�L���R�[�h.Visible = true;
				tex�L���R�[�h.Visible = true;
				lab���̕K�{.Visible = true;
				lab�L����.Visible = true;
				tex�L����.Visible = true;
				btn�X�V.Visible = true;
				btn�폜.Visible = true;
// ADD 2005.07.22 ���s�j�����J �߂�{�^���ǉ� START
				btn�߂�.Visible = false;
// ADD 2005.07.22 ���s�j�����J �߂�{�^���ǉ� END
// MOD 2010.03.01 ���s�j���� �S�p���p���݉\�ɂ��� START
//				this.Width = 396;
//				this.tex���b�Z�[�W.Width = 256;
// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
//				this.Width = 474;
//				this.tex���b�Z�[�W.Width = 336;
// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� END
// MOD 2010.03.01 ���s�j���� �S�p���p���݉\�ɂ��� END
			}
			// ADD 2005.05.16 ���s�j�ɉ� �A���w���͍X�V�ł��Ȃ� END

			tex���b�Z�[�W.Text = "�������D�D�D";
			axGT�L��.CaretRow = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� START
			axGT�L��.CaretCol = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� END
			i���ݕŐ� = 1;
			�L���ꗗ����();
		}

		private void �L���ꗗ����()
		{
			tex�L���R�[�h.Text = "";
			tex�L����.Text     = "";
			s�X�V����        = "";
			
			s�L���ꗗ = new string[1];
			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
// MOD 2005.05.16 ���s�j�ɉ� �A���w����"default","yusoshiji"�̋L����\�� START
				if(b�A���w��)
				{
// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX START
//					s�L���ꗗ = sv_kiji.Get_kiji(gsa���[�U,"default","yusoshiji");
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
				if (gs����b�c.Substring(0,1) != "J"){
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
					s�L���ꗗ = sv_kiji.Get_kiji(gsa���[�U,"yusoshohin", s�A�����i����);
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
				}else{
					s�L���ꗗ = sv_kiji.Get_kiji(gsa���[�U,"Jyusoshohin", s�A�����i����);
				}
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX END
				}
				else
				{
					s�L���ꗗ = sv_kiji.Get_kiji(gsa���[�U,gs����b�c,gs����b�c);
				}
// MOD 2005.05.16 ���s�j�ɉ� �A���w����"default","yusoshiji"�̋L����\�� END
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				s�L���ꗗ[0] = gs�ʐM�G���[;
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				s�L���ꗗ[0] = "�ʐM�G���[�F" + ex.Message;
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;

			tex���b�Z�[�W.Text = s�L���ꗗ[0];
			if(s�L���ꗗ[0].Length == 4) //����I��
			{
				tex���b�Z�[�W.Text = "";
				i�ő�Ő� = (s�L���ꗗ.Length - 2) / axGT�L��.Rows + 1;
// MOD 2010.02.12 ���s�j���� ��L�C����[�L���o�^]�A[�L������]�ɓK�p���� 
				if(!b�A���w��){
//				if(lab�L���^�C�g��.Text.Equals("�L���o�^")){
					i�ő�Ő� = (s�L���ꗗ.Length - 2) / (axGT�L��.Rows - 1) + 1;
				}
// MOD 2010.02.12 ���s�j���� ��L�C����[�L���o�^]�A[�L������]�ɓK�p���� END
				if (i���ݕŐ� > i�ő�Ő�)
					i���ݕŐ� = i�ő�Ő�;
				�ŏ��ݒ�();
			}
			else
			{
				if (b�A���w�� &&  !s�A�����i����.Equals("0000") && !sKcode2.Trim().Equals("")) 
				{
					//�A�����i�e��������J�ځA�A�����i�q�Ȃ��̏ꍇ
					sKcode = "dumycode"; //�_�~�[�̃R�[�h�A�O�̂��߂S���ȏ�
					s�L��  = "";
					this.Close();
				}
				else
				{
					axGT�L��.Clear();
					i���ݕŐ� = 1;
					btn�O��.Enabled = false;
					btn����.Enabled = false;
					lab�Ŕԍ�.Text = "";
					�r�[�v��();
				}
			}
			if (b�A���w�� && !s�A�����i����.Equals("0000")) //�A�����i�q�̏ꍇ
			{
				if (s�L���ꗗ.Length == 2) //�A�����i�q���ꌏ�̏ꍇ�m��
				{
					btn�m��_Click(null,null);
				}
// ADD 2005.07.22 ���s�j�����J �߂�{�^���ǉ� START
				else
				{
					btn�߂�.Visible = true;
				}
// ADD 2005.07.22 ���s�j�����J �߂�{�^���ǉ� END
			}
		}
		private void btn����_Click(object sender, System.EventArgs e)
		{
			sKcode = "";
			this.Close();
		}

		private void axGT�L��_CelClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelClickEvent e)
		{
			tex�L���R�[�h.Text = axGT�L��.get_CelText(axGT�L��.CaretRow,1).Trim();
			tex�L����.Text     = axGT�L��.get_CelText(axGT�L��.CaretRow,2).TrimEnd();
			s�X�V����        = axGT�L��.get_CelText(axGT�L��.CaretRow,3).Trim();
		}
		private void axGT�L��_CelDblClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelDblClickEvent e)
		{
			sKcode = axGT�L��.get_CelText(axGT�L��.CaretRow,1).Trim();
			s�L��  = axGT�L��.get_CelText(axGT�L��.CaretRow,2).TrimEnd();
			if(sKcode != "")
			{

				if(b�A���w�� && s�A�����i����.Equals("0000")) //�A�����i�e�̏ꍇ�A�A�����i�q��\��
				{
					sKcode2 = sKcode;
					s�L���Q = s�L��;
					s�A�����i���� = sKcode;
					sKcode  = "";
					s�L��   = "";
					tex���b�Z�[�W.Text = "�������D�D�D";
					axGT�L��.set_CelForeColor(nOldRow,0,0);
					axGT�L��.set_CelBackColor(nOldRow,0,0xFFFFFF);
					axGT�L��.CaretRow = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� START
					axGT�L��.CaretCol = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� END
					axGT�L��.set_CelForeColor(axGT�L��.CaretRow,0,0x98FB98);  //BGR
					axGT�L��.set_CelBackColor(axGT�L��.CaretRow,0,0x006000);
					nOldRow = axGT�L��.CaretRow;
					i���ݕŐ� = 1;
					�L���ꗗ����();
				}
				else if(b�A���w�� && !s�A�����i����.Equals("0000")) //�A�����i�q�A���Ԏw��܂ňȍ~�̏ꍇ
				{
					if (sKcode.Length > 2 && sKcode.Substring(1).Equals("1X"))
					{
						if (g�w�莞�ԓ��� == null) g�w�莞�ԓ��� = new �w�莞�ԓ���();
						g�w�莞�ԓ���.Left  = this.Left + 15;
						g�w�莞�ԓ���.Top   = this.Top + 180;
						g�w�莞�ԓ���.s�L�� = "";
						g�w�莞�ԓ���.lab���ԋ敪.Text = "���܂�";
// MOD 2005.06.10 ���s�j�ɉ�@���Ԏw����@�ύX START
//						g�w�莞�ԓ���.nUD�w�莞��.Minimum = 12;
//						g�w�莞�ԓ���.nUD�w�莞��.Maximum = 21;
//						g�w�莞�ԓ���.nUD�w�莞��.Value = 12;
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX START
//						string[] items = {"�P�Q","�P�R","�P�S","�P�T","�P�U","�P�V","�P�W","�P�X","�Q�O","�Q�P"};
						string[] items = {"�P�Q","�P�R","�P�S","�P�T","�P�U","�P�V","�P�W","�P�X","�Q�O"};
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX END
						g�w�莞�ԓ���.cmb�w�莞��.Items.Clear();
						g�w�莞�ԓ���.cmb�w�莞��.Items.AddRange(items);
						g�w�莞�ԓ���.cmb�w�莞��.SelectedIndex = 0;
// MOD 2005.06.10 ���s�j�ɉ�@���Ԏw����@�ύX END
						g�w�莞�ԓ���.ShowDialog(this);
						if (g�w�莞�ԓ���.s�L��.Length != 0)
						{
							s�L�� = g�w�莞�ԓ���.s�L��;
// MOD 2010.03.01 ���s�j���� �S�p���p���݉\�ɂ��� START
							//�L���o�^�̏ꍇ�̓N���[�Y���Ȃ�
							if(lab�L���^�C�g��.Text.Equals("�L���o�^")) return;
// MOD 2010.03.01 ���s�j���� �S�p���p���݉\�ɂ��� END
							this.Close();
						}
					}
					else if (sKcode.Length > 2 && sKcode.Substring(1).Equals("2X"))
					{
						if (g�w�莞�ԓ��� == null) g�w�莞�ԓ��� = new �w�莞�ԓ���();
						g�w�莞�ԓ���.Left  = this.Left + 15;
						g�w�莞�ԓ���.Top   = this.Top + 180;
						g�w�莞�ԓ���.s�L�� = "";
						g�w�莞�ԓ���.lab���ԋ敪.Text = "���ȍ~";
// MOD 2005.06.10 ���s�j�ɉ�@���Ԏw����@�ύX START
//						g�w�莞�ԓ���.nUD�w�莞��.Minimum = 10;
//						g�w�莞�ԓ���.nUD�w�莞��.Maximum = 19;
//						g�w�莞�ԓ���.nUD�w�莞��.Value = 10;
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX START
//						string[] items = {"�P�O","�P�P","�P�Q","�P�R","�P�S","�P�T","�P�U","�P�V","�P�W","�P�X"};
						string[] items = {"�P�O","�P�P","�P�Q","�P�R","�P�S","�P�T","�P�U","�P�V","�P�W"};
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX END
						g�w�莞�ԓ���.cmb�w�莞��.Items.Clear();
						g�w�莞�ԓ���.cmb�w�莞��.Items.AddRange(items);
						g�w�莞�ԓ���.cmb�w�莞��.SelectedIndex = 0;
// MOD 2005.06.10 ���s�j�ɉ�@���Ԏw����@�ύX END
						g�w�莞�ԓ���.ShowDialog(this);
						if (g�w�莞�ԓ���.s�L��.Length != 0)
						{
							s�L�� = g�w�莞�ԓ���.s�L��;
// MOD 2010.03.01 ���s�j���� �S�p���p���݉\�ɂ��� START
							//�L���o�^�̏ꍇ�̓N���[�Y���Ȃ�
							if(lab�L���^�C�g��.Text.Equals("�L���o�^")) return;
// MOD 2010.03.01 ���s�j���� �S�p���p���݉\�ɂ��� END
							this.Close();
						}
					}
					else
					{
// MOD 2010.03.01 ���s�j���� �S�p���p���݉\�ɂ��� START
							//�L���o�^�̏ꍇ�̓N���[�Y���Ȃ�
							if(lab�L���^�C�g��.Text.Equals("�L���o�^")) return;
// MOD 2010.03.01 ���s�j���� �S�p���p���݉\�ɂ��� END
						this.Close();
					}					
				}
				else
// MOD 2010.03.01 ���s�j���� �S�p���p���݉\�ɂ��� START
				{
					//�L���o�^�̏ꍇ�̓N���[�Y���Ȃ�
					if(lab�L���^�C�g��.Text.Equals("�L���o�^")) return;
// MOD 2010.03.01 ���s�j���� �S�p���p���݉\�ɂ��� END
					this.Close();
// MOD 2010.03.01 ���s�j���� �S�p���p���݉\�ɂ��� START
				}
// MOD 2010.03.01 ���s�j���� �S�p���p���݉\�ɂ��� END
			}
		}

		private void axGT�L��_CurPlaceChanged(object sender, AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEvent e)
		{
			axGT�L��.set_CelForeColor(nOldRow,0,0);
			axGT�L��.set_CelBackColor(nOldRow,0,0xFFFFFF);
//			axGT�L��.set_CelForeColor(axGT�L��.CaretRow,0,111111);
			axGT�L��.set_CelForeColor(axGT�L��.CaretRow,0,0x98FB98);  //BGR
			axGT�L��.set_CelBackColor(axGT�L��.CaretRow,0,0x006000);
			nOldRow = axGT�L��.CaretRow;
			tex�L���R�[�h.Text = axGT�L��.get_CelText(axGT�L��.CaretRow,1).Trim();
			tex�L����.Text     = axGT�L��.get_CelText(axGT�L��.CaretRow,2).TrimEnd();
			s�X�V����          = axGT�L��.get_CelText(axGT�L��.CaretRow,3).Trim();
		}

		private void axGT�L��_KeyDownEvent(object sender, AxGTABLE32V2Lib._DGTable32Events_KeyDownEvent e)
		{
			if (e.keyCode == 13)
			{
				btn�m��_Click(sender, null);
			}
			if (e.keyCode == 9)
			{
				this.SelectNextControl(axGT�L��, true, true, true, true);
			}
		}

		private void btn�X�V_Click(object sender, System.EventArgs e)
		{
			tex�L���R�[�h.Text = tex�L���R�[�h.Text.Trim();
			tex�L����.Text     = tex�L����.Text.TrimEnd();

			if(!�K�{�`�F�b�N(tex�L���R�[�h,"�L���R�[�h")) return;
			if(!�K�{�`�F�b�N(tex�L����,"�L����")) return;

			if(!���p�`�F�b�N(tex�L���R�[�h,"�L���R�[�h")) return;
// MOD 2010.03.01 ���s�j���� �S�p���p���݉\�ɂ��� START
//			if(!�S�p�`�F�b�N(tex�L����,"�L����")) return;
			if(!���݃`�F�b�N(tex�L����,"�L����")) return;
// MOD 2010.03.01 ���s�j���� �S�p���p���݉\�ɂ��� END

			try
			{
				tex���b�Z�[�W.Text = "";
				// �J�[�\���������v�ɂ���
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
				String[] sList = sv_kiji.Get_Skiji(gsa���[�U,gs����b�c,gs����b�c,tex�L���R�[�h.Text);
				// �J�[�\�����f�t�H���g�ɖ߂�
				Cursor = System.Windows.Forms.Cursors.Default;

				// �G���[��
				if(sList[0].Length != 2)
				{
					tex���b�Z�[�W.Text = sList[0];
					�r�[�v��();
					return;
				}

				string s�X�V�e�f = sList[3];

				// �X�V���������ƂȂ�ꍇ
//				if(s�X�V�e�f == "U" && tex�L����.Text != sList[1] && s�X�V���� != sList[2])
				if(s�X�V�e�f == "U" && s�X�V���� != sList[2])
				{
//					tex���b�Z�[�W.Text = "�r���G���[�F���̒[���Ŋ��ɍX�V����Ă��܂���";
					�r�[�v��();
					DialogResult rst;
					rst = MessageBox.Show("����̃R�[�h�����ɑ��̒[�����o�^����Ă��܂��B\n" 
										+ "�L���ꗗ���ŐV�ɂ��܂����H",
										"�X�V",
										MessageBoxButtons.YesNo,
										MessageBoxIcon.Error);
					if(rst == DialogResult.Yes)
					{
						�L���ꗗ����();
					}
					return;
				}

				String[] sIUList;
				string[] sData = new string[7];
				sData[0]  = gs����b�c;
				sData[1]  = gs����b�c;
				sData[2]  = tex�L���R�[�h.Text;
				sData[3]  = tex�L����.Text;
				sData[4]  = "�L���o�^";
				sData[5]  = gs���p�҂b�c;
				sData[6]  = s�X�V����;

				DialogResult result;
				if(s�X�V�e�f == "I")
				{
					result = MessageBox.Show("�V�K�o�^���܂����H","�o�^",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						tex���b�Z�[�W.Text = "�o�^���D�D�D";
						// �J�[�\���������v�ɂ���
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						sIUList = sv_kiji.Ins_kiji(gsa���[�U,sData);
						if(sIUList[0].Length == 4)
						{
							�L���ꗗ����();
						}
						else
						{
							tex���b�Z�[�W.Text = sIUList[0];
							�r�[�v��();
						}
						// �J�[�\�����f�t�H���g�ɖ߂�
						Cursor = System.Windows.Forms.Cursors.Default;
					}
				}
				else
				{
					result = MessageBox.Show("���ɑ��݂���f�[�^�ɏ㏑�����܂����H","�X�V",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						// �J�[�\���������v�ɂ���
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						tex���b�Z�[�W.Text = "�X�V���D�D�D";
						sIUList = sv_kiji.Upd_kiji(gsa���[�U,sData);
						if(sIUList[0].Length == 4)
						{
							�L���ꗗ����();
						}
						else
						{
							tex���b�Z�[�W.Text = sIUList[0];
							�r�[�v��();
						}
						// �J�[�\�����f�t�H���g�ɖ߂�
						Cursor = System.Windows.Forms.Cursors.Default;
					}
				}
			}
// ADD 2005.06.01 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				tex���b�Z�[�W.Text = gs�ʐM�G���[;
				�r�[�v��();
			}
// ADD 2005.06.01 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				tex���b�Z�[�W.Text = ex.Message;
				�r�[�v��();
			}
		}

		private void btn�폜_Click(object sender, System.EventArgs e)
		{
			// �󔒏���
			tex�L���R�[�h.Text = tex�L���R�[�h.Text.Trim();

			if(!�K�{�`�F�b�N(tex�L���R�[�h,"�L���R�[�h")) return;
			if(!���p�`�F�b�N(tex�L���R�[�h,"�L���R�[�h")) return;

			try
			{
				tex���b�Z�[�W.Text = "";
				// �J�[�\���������v�ɂ���
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
				String[] sList = sv_kiji.Get_Skiji(gsa���[�U,gs����b�c,gs����b�c,tex�L���R�[�h.Text);
				// �J�[�\�����f�t�H���g�ɖ߂�
				Cursor = System.Windows.Forms.Cursors.Default;

				string s�X�V�e�f = sList[3];

				String[] sDList;
				string[] sData = new string[5];

				DialogResult result;
				if(s�X�V�e�f == "I")
					MessageBox.Show("�R�[�h(" + tex�L���R�[�h.Text + ")�̃f�[�^�͑��݂��܂���","�폜",MessageBoxButtons.OK);
				else
				{
					result = MessageBox.Show("�R�[�h(" + tex�L���R�[�h.Text + ")�̃f�[�^���폜���܂����H","�폜",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						sData[0] = gs����b�c;
						sData[1] = gs����b�c;
						sData[2] = tex�L���R�[�h.Text;
						sData[3] = "�L���o�^";
						sData[4] = gs���p�҂b�c;

						// �J�[�\���������v�ɂ���
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						tex���b�Z�[�W.Text = "�폜���D�D�D";
						sDList = sv_kiji.Del_kiji(gsa���[�U,sData);

						if(sDList[0].Length == 4)
						{
							�L���ꗗ����();
						}
						else
						{
							tex���b�Z�[�W.Text = sDList[0];
							�r�[�v��();
						}
						// �J�[�\�����f�t�H���g�ɖ߂�
						Cursor = System.Windows.Forms.Cursors.Default;
					}
				}
			}
// ADD 2005.06.01 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				tex���b�Z�[�W.Text = gs�ʐM�G���[;
				�r�[�v��();
			}
// ADD 2005.06.01 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				tex���b�Z�[�W.Text = ex.Message;
				�r�[�v��();
			}
		}

		private void btn�m��_Click(object sender, System.EventArgs e)
		{
			sKcode = axGT�L��.get_CelText(axGT�L��.CaretRow,1).Trim();
			s�L��  = axGT�L��.get_CelText(axGT�L��.CaretRow,2).TrimEnd();
			if(sKcode != "")
			{
				if(b�A���w�� && s�A�����i����.Equals("0000")) //�A�����i�e�̏ꍇ�A�A�����i�q��\��
				{
					sKcode2 = sKcode;
					s�L���Q = s�L��;
					s�A�����i���� = sKcode;
					sKcode  = "";
					s�L��   = "";
					tex���b�Z�[�W.Text = "�������D�D�D";
					axGT�L��.set_CelForeColor(nOldRow,0,0);
					axGT�L��.set_CelBackColor(nOldRow,0,0xFFFFFF);
					axGT�L��.CaretRow = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� START
					axGT�L��.CaretCol = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� END
					axGT�L��.set_CelForeColor(axGT�L��.CaretRow,0,0x98FB98);  //BGR
					axGT�L��.set_CelBackColor(axGT�L��.CaretRow,0,0x006000);
					nOldRow = axGT�L��.CaretRow;
					i���ݕŐ� = 1;
					�L���ꗗ����();
				}
				else if(b�A���w�� && !s�A�����i����.Equals("0000")) //�A�����i�q�A���Ԏw��܂ňȍ~�̏ꍇ
				{
					if (sKcode.Length > 2 && sKcode.Substring(1).Equals("1X"))
					{
						if (g�w�莞�ԓ��� == null) g�w�莞�ԓ��� = new �w�莞�ԓ���();
						g�w�莞�ԓ���.Left  = this.Left + 15;
						g�w�莞�ԓ���.Top   = this.Top + 180;
						g�w�莞�ԓ���.s�L�� = "";
						g�w�莞�ԓ���.lab���ԋ敪.Text = "���܂�";
						// MOD 2005.06.10 ���s�j�ɉ�@���Ԏw����@�ύX START
//						g�w�莞�ԓ���.nUD�w�莞��.Minimum = 12;
//						g�w�莞�ԓ���.nUD�w�莞��.Maximum = 21;
//						g�w�莞�ԓ���.nUD�w�莞��.Value = 12;
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX START
//						string[] items = {"�P�Q","�P�R","�P�S","�P�T","�P�U","�P�V","�P�W","�P�X","�Q�O","�Q�P"};
						string[] items = {"�P�Q","�P�R","�P�S","�P�T","�P�U","�P�V","�P�W","�P�X","�Q�O"};
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX END
						g�w�莞�ԓ���.cmb�w�莞��.Items.Clear();
						g�w�莞�ԓ���.cmb�w�莞��.Items.AddRange(items);
						g�w�莞�ԓ���.cmb�w�莞��.SelectedIndex = 0;
						// MOD 2005.06.10 ���s�j�ɉ�@���Ԏw����@�ύX END
						g�w�莞�ԓ���.ShowDialog(this);
						if (g�w�莞�ԓ���.s�L��.Length != 0)
						{
							s�L�� = g�w�莞�ԓ���.s�L��;
							this.Close();
						}
					}
					else if (sKcode.Length > 2 && sKcode.Substring(1).Equals("2X"))
					{
						if (g�w�莞�ԓ��� == null) g�w�莞�ԓ��� = new �w�莞�ԓ���();
						g�w�莞�ԓ���.Left  = this.Left + 15;
						g�w�莞�ԓ���.Top   = this.Top + 180;
						g�w�莞�ԓ���.s�L�� = "";
						g�w�莞�ԓ���.lab���ԋ敪.Text = "���ȍ~";
						// MOD 2005.06.10 ���s�j�ɉ�@���Ԏw����@�ύX START
//						g�w�莞�ԓ���.nUD�w�莞��.Minimum = 10;
//						g�w�莞�ԓ���.nUD�w�莞��.Maximum = 19;
//						g�w�莞�ԓ���.nUD�w�莞��.Value = 10;
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX START
//						string[] items = {"�P�O","�P�P","�P�Q","�P�R","�P�S","�P�T","�P�U","�P�V","�P�W","�P�X"};
						string[] items = {"�P�O","�P�P","�P�Q","�P�R","�P�S","�P�T","�P�U","�P�V","�P�W"};
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX END
						g�w�莞�ԓ���.cmb�w�莞��.Items.Clear();
						g�w�莞�ԓ���.cmb�w�莞��.Items.AddRange(items);
						g�w�莞�ԓ���.cmb�w�莞��.SelectedIndex = 0;
						// MOD 2005.06.10 ���s�j�ɉ�@���Ԏw����@�ύX END
						g�w�莞�ԓ���.ShowDialog(this);
						if (g�w�莞�ԓ���.s�L��.Length != 0)
						{
							s�L�� = g�w�莞�ԓ���.s�L��;
							this.Close();
						}
					}
					else
					{
						this.Close();
					}					
				}
				else
					this.Close();
			}
		}

		private void btn�ꗗ�\_Click(object sender, System.EventArgs e)
		{
			tex���b�Z�[�W.Text = "�L���ꗗ������D�D�D";
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				if(sv_print == null) sv_print = new is2print.Service1();
				string[] sKey = new string[3];
				sKey[0] = gs����b�c;
				sKey[1] = gs����b�c;

				string[] sRet = new string[1];
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
//				IEnumerator iEnum = sv_print.Get_NotePrintData(gsa���[�U,sKey).GetEnumerator();
				IEnumerator iEnum;
				if (gs����b�c.Substring(0,1) != "J"){
					iEnum = sv_print.Get_NotePrintData(gsa���[�U,sKey).GetEnumerator();
				}else{
					if(sv_oji == null) sv_oji = new is2oji.Service1();
					iEnum = sv_oji.Get_NotePrintData(gsa���[�U,sKey).GetEnumerator();
				}
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
				iEnum.MoveNext();
				sRet = (string[])iEnum.Current;
// DEL 2005.05.11 ���s�j���� �u����I���v�͕\�����Ȃ� START
//				tex���b�Z�[�W.Text = sRet[0];
// DEL 2005.05.11 ���s�j���� �u����I���v�͕\�����Ȃ� END
				if (sRet[0].Equals("����I��"))
				{
					�L���f�[�^ ds = new �L���f�[�^();

					int iCnt = 1;
					//�f�[�^�Z�b�g�ɒl���Z�b�g
					while(iEnum.MoveNext())
					{
						�L���f�[�^.table�L��Row tr = (�L���f�[�^.table�L��Row)ds.table�L��.NewRow();
						tr.BeginEdit();
						tr.�ԍ� = iCnt++;
// MOD 2005.05.16 ���s�j�ɉ� �f�[�^�\���ύX START
						string[] sData = new string[4];
						sData = (string[])iEnum.Current;
						tr.�A���w���R�[�h = sData[0];
						tr.�A���w����     = sData[1];
						tr.�i���L���R�[�h = sData[2];
						tr.�i���L����     = sData[3];
// MOD 2005.05.16 ���s�j�ɉ� �f�[�^�\���ύX END
						tr.EndEdit();

						ds.table�L��.Rows.Add(tr);
					}

					�L�����[ cr = new �L�����[();
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

		private void btn�O��_Click(object sender, System.EventArgs e)
		{
			i���ݕŐ�--;
			�ŏ��ݒ�();
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			i���ݕŐ�++;
			�ŏ��ݒ�();
		}
		
		private void �ŏ��ݒ�()
		{
			axGT�L��.Clear();

			i�J�n�� = (i���ݕŐ� - 1) * axGT�L��.Rows + 1;
			i�I���� = i���ݕŐ� * axGT�L��.Rows;

			short s�\���� = (short)1;
// MOD 2010.02.12 ���s�j���� ��L�C����[�L���o�^]�A[�L������]�ɓK�p���� START
//			i�J�n�� = (i���ݕŐ� - 1) * (axGT�L��.Rows - 1) + 1;
//			i�I���� = i���ݕŐ� * (axGT�L��.Rows - 1);
//
//			short s�\���� = (short)2;
			if(!b�A���w��){
//			if(lab�L���^�C�g��.Text.Equals("�L���o�^")){
				i�J�n�� = (i���ݕŐ� - 1) * (axGT�L��.Rows - 1) + 1;
				i�I���� = i���ݕŐ� * (axGT�L��.Rows - 1);
				s�\���� = (short)2;
			}
// MOD 2010.02.12 ���s�j���� ��L�C����[�L���o�^]�A[�L������]�ɓK�p���� END
			for(short sCnt = (short)i�J�n��; sCnt < s�L���ꗗ.Length && sCnt <= i�I���� ; sCnt++)
			{
				axGT�L��.set_RowsText(s�\����, s�L���ꗗ[sCnt]);
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
			tex�L���R�[�h.Text = axGT�L��.get_CelText(axGT�L��.CaretRow,1).Trim();
			tex�L����.Text     = axGT�L��.get_CelText(axGT�L��.CaretRow,2).TrimEnd();
			s�X�V����          = axGT�L��.get_CelText(axGT�L��.CaretRow,3).Trim();
		}

// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� START
		private void �L������_Closed(object sender, System.EventArgs e)
		{
			axGT�L��.CaretRow = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� START
			axGT�L��.CaretCol = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� END
			axGT�L��_CurPlaceChanged(null,null);
			axGT�L��.Focus();
		}
// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� END

// ADD 2005.07.22 ���s�j�����J �߂�{�^���ǉ� START
		private void btn�߂�_Click(object sender, System.EventArgs e)
		{
			sKcode    = "";
			s�L��     = "";
			sKcode2   = "";
			s�L���Q   = "";
			tex���b�Z�[�W.Text = "�������D�D�D";
			axGT�L��.CaretRow = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� START
			axGT�L��.CaretCol = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� END
			i���ݕŐ� = 1;
			axGT�L��_CurPlaceChanged(null,null);
			s�A�����i���� = "0000";
			�L���ꗗ����();
			axGT�L��.Focus();
			btn�߂�.Visible = false;
		}
// ADD 2005.07.22 ���s�j�����J �߂�{�^���ǉ� END

	}
}
