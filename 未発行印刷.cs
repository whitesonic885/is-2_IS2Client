using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [�Ĉ��]�A[�`���C�X�v�����g]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// MOD 2007.02.08 ���s�j���� �ꗗ�\�����ڂ̕ύX 
	// MOD 2007.02.19 FJCS�j�K�c ���b�Z�[�W�ύX 
	// MOD 2007.02.20 ���s�j���� �Ĕ��s��ʂŏo�ד��������ł�����ɂ��� 
	// ADD 2007.02.21 ���s�j���� ������̃J�����ʒu�̒��� 
	// MOD 2007.03.10 ���s�j���� �ꗗ�\�����ڂ̕ύX�i��Q�j 
	// MOD 2007.07.06 ���s�j���� �w�b�_�Ƀ��O�C���W�דX��\�� 
	//--------------------------------------------------------------------------
	// ADD 2008.03.19 ���s�j���� �ʍĔ��s�@�\�̒ǉ� 
	// MOD 2008.10.29 ���s�j���� ���������ǉ� 
	//--------------------------------------------------------------------------
	// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j 
	// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� 
	//--------------------------------------------------------------------------
	// MOD 2011.03.23 ���s�j���� �J�[�\���ێ��@�\�̒ǉ� 
	//--------------------------------------------------------------------------
	public class �����s��� : ���ʃt�H�[��
	{
		public short OldRow = 0;
		private short nSrow = 0;
		private short nErow = 0;
		private short nWork = 0;

		private string[] s�o�׈ꗗ;
//		private int      i���ݕŐ�;
		private int      i�A�N�e�B�u�e�f = 0;

		public string s�^�C�g��;
		public string s��Ԏ��;

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab����;
		private System.Windows.Forms.TextBox tex�d�ʍ��v;
		private System.Windows.Forms.TextBox tex�����v;
		private System.Windows.Forms.Label lab�o�^����;
		private System.Windows.Forms.TextBox tex�o�^����;
		private System.Windows.Forms.Label lab�����v;
		private System.Windows.Forms.Label lab�d�ʍ��v;
		private System.Windows.Forms.Label lab���p����;
		private System.Windows.Forms.Label lab�����s����^�C�g��;
		private System.Windows.Forms.TextBox tex���b�Z�[�W;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Button btn�Ĕ��s;
		private System.Windows.Forms.TextBox tex���p����;
		private AxGTABLE32V2Lib.AxGTable32 axGT�o�׈ꗗ;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.TextBox tex���O�C���W�דX;
		private System.Windows.Forms.Label lab���O�C���W�דX;
		private System.Windows.Forms.Button btn�ʍĔ��s;
		private System.ComponentModel.IContainer components;

		public �����s���()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
			�c�o�h�\���T�C�Y�ϊ�();
//			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
				this.axGT�o�׈ꗗ.Size = new System.Drawing.Size(732, 416);
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(�����s���));
			this.panel2 = new System.Windows.Forms.Panel();
			this.axGT�o�׈ꗗ = new AxGTABLE32V2Lib.AxGTable32();
			this.tex�d�ʍ��v = new System.Windows.Forms.TextBox();
			this.tex�����v = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.lab�o�^���� = new System.Windows.Forms.Label();
			this.tex�o�^���� = new System.Windows.Forms.TextBox();
			this.lab�����v = new System.Windows.Forms.Label();
			this.lab�d�ʍ��v = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.lab���O�C���W�דX = new System.Windows.Forms.Label();
			this.tex���O�C���W�דX = new System.Windows.Forms.TextBox();
			this.lab���p���� = new System.Windows.Forms.Label();
			this.tex���p���� = new System.Windows.Forms.TextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab���� = new System.Windows.Forms.Label();
			this.lab�����s����^�C�g�� = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn�ʍĔ��s = new System.Windows.Forms.Button();
			this.btn�Ĕ��s = new System.Windows.Forms.Button();
			this.tex���b�Z�[�W = new System.Windows.Forms.TextBox();
			this.btn���� = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axGT�o�׈ꗗ)).BeginInit();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Honeydew;
			this.panel2.Controls.Add(this.axGT�o�׈ꗗ);
			this.panel2.Controls.Add(this.tex�d�ʍ��v);
			this.panel2.Controls.Add(this.tex�����v);
			this.panel2.Controls.Add(this.label21);
			this.panel2.Controls.Add(this.lab�o�^����);
			this.panel2.Controls.Add(this.tex�o�^����);
			this.panel2.Controls.Add(this.lab�����v);
			this.panel2.Controls.Add(this.lab�d�ʍ��v);
			this.panel2.Location = new System.Drawing.Point(0, 6);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(764, 452);
			this.panel2.TabIndex = 1;
			// 
			// axGT�o�׈ꗗ
			// 
			this.axGT�o�׈ꗗ.ContainingControl = this;
			this.axGT�o�׈ꗗ.DataSource = null;
			this.axGT�o�׈ꗗ.Location = new System.Drawing.Point(28, 32);
			this.axGT�o�׈ꗗ.Name = "axGT�o�׈ꗗ";
			this.axGT�o�׈ꗗ.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT�o�׈ꗗ.OcxState")));
			this.axGT�o�׈ꗗ.Size = new System.Drawing.Size(732, 416);
			this.axGT�o�׈ꗗ.TabIndex = 51;
			this.axGT�o�׈ꗗ.KeyDownEvent += new AxGTABLE32V2Lib._DGTable32Events_KeyDownEventHandler(this.axGT�o�׈ꗗ_KeyDownEvent);
			this.axGT�o�׈ꗗ.CelClick += new AxGTABLE32V2Lib._DGTable32Events_CelClickEventHandler(this.axGT�o�׈ꗗ_CelClick);
			this.axGT�o�׈ꗗ.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT�o�׈ꗗ_CurPlaceChanged);
			// 
			// tex�d�ʍ��v
			// 
			this.tex�d�ʍ��v.BackColor = System.Drawing.SystemColors.Window;
			this.tex�d�ʍ��v.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�d�ʍ��v.Location = new System.Drawing.Point(382, 4);
			this.tex�d�ʍ��v.Name = "tex�d�ʍ��v";
			this.tex�d�ʍ��v.ReadOnly = true;
			this.tex�d�ʍ��v.Size = new System.Drawing.Size(86, 23);
			this.tex�d�ʍ��v.TabIndex = 50;
			this.tex�d�ʍ��v.TabStop = false;
			this.tex�d�ʍ��v.Text = "";
			this.tex�d�ʍ��v.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tex�����v
			// 
			this.tex�����v.BackColor = System.Drawing.SystemColors.Window;
			this.tex�����v.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�����v.Location = new System.Drawing.Point(246, 4);
			this.tex�����v.Name = "tex�����v";
			this.tex�����v.ReadOnly = true;
			this.tex�����v.Size = new System.Drawing.Size(70, 23);
			this.tex�����v.TabIndex = 49;
			this.tex�����v.TabStop = false;
			this.tex�����v.Text = "";
			this.tex�����v.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label21
			// 
			this.label21.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label21.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label21.ForeColor = System.Drawing.Color.White;
			this.label21.Location = new System.Drawing.Point(0, 0);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(22, 456);
			this.label21.TabIndex = 3;
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab�o�^����
			// 
			this.lab�o�^����.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�o�^����.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lab�o�^����.ForeColor = System.Drawing.Color.BlueViolet;
			this.lab�o�^����.Location = new System.Drawing.Point(62, 6);
			this.lab�o�^����.Name = "lab�o�^����";
			this.lab�o�^����.Size = new System.Drawing.Size(60, 18);
			this.lab�o�^����.TabIndex = 4;
			this.lab�o�^����.Text = "�o�^����";
			this.lab�o�^����.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tex�o�^����
			// 
			this.tex�o�^����.BackColor = System.Drawing.SystemColors.Window;
			this.tex�o�^����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�o�^����.Location = new System.Drawing.Point(122, 4);
			this.tex�o�^����.Name = "tex�o�^����";
			this.tex�o�^����.ReadOnly = true;
			this.tex�o�^����.Size = new System.Drawing.Size(54, 23);
			this.tex�o�^����.TabIndex = 46;
			this.tex�o�^����.TabStop = false;
			this.tex�o�^����.Text = "";
			this.tex�o�^����.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lab�����v
			// 
			this.lab�����v.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�����v.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lab�����v.ForeColor = System.Drawing.Color.Blue;
			this.lab�����v.Location = new System.Drawing.Point(186, 6);
			this.lab�����v.Name = "lab�����v";
			this.lab�����v.Size = new System.Drawing.Size(60, 18);
			this.lab�����v.TabIndex = 6;
			this.lab�����v.Text = "�����v";
			this.lab�����v.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab�d�ʍ��v
			// 
			this.lab�d�ʍ��v.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�d�ʍ��v.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lab�d�ʍ��v.ForeColor = System.Drawing.Color.Blue;
			this.lab�d�ʍ��v.Location = new System.Drawing.Point(322, 6);
			this.lab�d�ʍ��v.Name = "lab�d�ʍ��v";
			this.lab�d�ʍ��v.Size = new System.Drawing.Size(60, 18);
			this.lab�d�ʍ��v.TabIndex = 8;
			this.lab�d�ʍ��v.Text = "�d�ʍ��v";
			this.lab�d�ʍ��v.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.PaleGreen;
			this.panel6.Controls.Add(this.lab���O�C���W�דX);
			this.panel6.Controls.Add(this.tex���O�C���W�דX);
			this.panel6.Controls.Add(this.lab���p����);
			this.panel6.Controls.Add(this.tex���p����);
			this.panel6.Location = new System.Drawing.Point(0, 26);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(810, 26);
			this.panel6.TabIndex = 12;
			// 
			// lab���O�C���W�דX
			// 
			this.lab���O�C���W�דX.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���O�C���W�דX.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���O�C���W�דX.Location = new System.Drawing.Point(694, 8);
			this.lab���O�C���W�דX.Name = "lab���O�C���W�דX";
			this.lab���O�C���W�דX.Size = new System.Drawing.Size(48, 14);
			this.lab���O�C���W�דX.TabIndex = 14;
			this.lab���O�C���W�דX.Text = "���O�C��";
			// 
			// tex���O�C���W�דX
			// 
			this.tex���O�C���W�דX.BackColor = System.Drawing.Color.PaleGreen;
			this.tex���O�C���W�דX.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex���O�C���W�דX.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���O�C���W�דX.ForeColor = System.Drawing.Color.LimeGreen;
			this.tex���O�C���W�דX.Location = new System.Drawing.Point(744, 6);
			this.tex���O�C���W�דX.Name = "tex���O�C���W�דX";
			this.tex���O�C���W�דX.ReadOnly = true;
			this.tex���O�C���W�דX.Size = new System.Drawing.Size(42, 16);
			this.tex���O�C���W�דX.TabIndex = 12;
			this.tex���O�C���W�דX.TabStop = false;
			this.tex���O�C���W�דX.Text = "999";
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
			this.panel7.Controls.Add(this.lab�����s����^�C�g��);
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
			// lab�����s����^�C�g��
			// 
			this.lab�����s����^�C�g��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�����s����^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�����s����^�C�g��.ForeColor = System.Drawing.Color.White;
			this.lab�����s����^�C�g��.Location = new System.Drawing.Point(12, 2);
			this.lab�����s����^�C�g��.Name = "lab�����s����^�C�g��";
			this.lab�����s����^�C�g��.Size = new System.Drawing.Size(264, 24);
			this.lab�����s����^�C�g��.TabIndex = 0;
			this.lab�����s����^�C�g��.Text = "�����s���";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn�ʍĔ��s);
			this.panel8.Controls.Add(this.btn�Ĕ��s);
			this.panel8.Controls.Add(this.tex���b�Z�[�W);
			this.panel8.Controls.Add(this.btn����);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 2;
			// 
			// btn�ʍĔ��s
			// 
			this.btn�ʍĔ��s.ForeColor = System.Drawing.Color.Blue;
			this.btn�ʍĔ��s.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�ʍĔ��s.Location = new System.Drawing.Point(170, 6);
			this.btn�ʍĔ��s.Name = "btn�ʍĔ��s";
			this.btn�ʍĔ��s.Size = new System.Drawing.Size(62, 48);
			this.btn�ʍĔ��s.TabIndex = 2;
			this.btn�ʍĔ��s.Text = "�ʁ@�@�Ĕ��s";
			this.btn�ʍĔ��s.Click += new System.EventHandler(this.btn�ʍĔ��s_Click);
			// 
			// btn�Ĕ��s
			// 
			this.btn�Ĕ��s.ForeColor = System.Drawing.Color.Blue;
			this.btn�Ĕ��s.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�Ĕ��s.Location = new System.Drawing.Point(98, 6);
			this.btn�Ĕ��s.Name = "btn�Ĕ��s";
			this.btn�Ĕ��s.Size = new System.Drawing.Size(62, 48);
			this.btn�Ĕ��s.TabIndex = 1;
			this.btn�Ĕ��s.Text = "���x���@�@���";
			this.btn�Ĕ��s.Click += new System.EventHandler(this.btn�Ĕ��s_Click);
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
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel2);
			this.groupBox2.Location = new System.Drawing.Point(16, 52);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(768, 460);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// �����s���
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 574);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.groupBox2);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "�����s���";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 �����s���";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Activated += new System.EventHandler(this.�����s���_Activated);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axGT�o�׈ꗗ)).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			i�A�N�e�B�u�e�f = 0;
			//�^�C�g��
			this.Text = "is-2 " + s�^�C�g��;
			lab�����s����^�C�g��.Text = s�^�C�g��;
// ADD 2008.03.19 ���s�j���� �ʍĔ��s�@�\�̒ǉ� START
			if(s�^�C�g��.Equals("�Ĕ��s")){
				this.btn�ʍĔ��s.Visible = true;
			}else{
				this.btn�ʍĔ��s.Visible = false;
			}
// ADD 2008.03.19 ���s�j���� �ʍĔ��s�@�\�̒ǉ� END

			// �w�b�_�[���ڂ̐ݒ�
// MOD 2007.07.06 ���s�j���� �w�b�_�Ƀ��O�C���W�דX��\�� START
//			tex���q�l��.Text = gs���p�Җ�;
			if(gs���p�ҕ���X���b�c == null || gs���p�ҕ���X���b�c.Length == 0)
			{
				tex���O�C���W�דX.Text = "";
			}
			else
			{
				tex���O�C���W�דX.Text = gs���p�ҕ���X���b�c;
			}
// MOD 2007.07.06 ���s�j���� �w�b�_�Ƀ��O�C���W�דX��\�� END
			tex���p����.Text = gs����b�c + " " + gs���喼;

			// �����̏����ݒ�
			lab����.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled = true;

			// �o�ד��̏����ݒ�i�����j
			����o�ד����X�V();

// ADD 2005.05.24 ���s�j�����J ���ڂ̏����� START
			tex���b�Z�[�W.Text = "";
			tex�o�^����.Text   = "";
			tex�����v.Text   = "";
			tex�d�ʍ��v.Text   = "";
			axGT�o�׈ꗗ.Clear();
// ADD 2005.05.24 ���s�j�����J ���ڂ̏����� END
// ADD 2007.02.21 ���s�j���� ������̃J�����ʒu�̒��� START
			axGT�o�׈ꗗ.CaretRow = 1;
			axGT�o�׈ꗗ.CaretCol = 1;
			axGT�o�׈ꗗ_CurPlaceChanged(null,null);
// ADD 2007.02.21 ���s�j���� ������̃J�����ʒu�̒��� END

			// �[���ݒ�Ńv�����^���g�p�ł��Ȃ��ݒ�̏ꍇ�A����{�^���g�p�s��
			if(gs�v�����^�e�f != "1")
			{
				btn�Ĕ��s.Enabled = false;
			}

// MOD 2006.07.26 ���s�j�R�{ �ꗗ�ɉ^���ƕی����̍��ڂ�ǉ� START
//			axGT�o�׈ꗗ.Cols = 13;
// MOD 2007.02.08 ���s�j���� �ꗗ�\�����ڂ̕ύX START
//			axGT�o�׈ꗗ.Cols = 16;
// MOD 2008.10.29 ���s�j���� ���������ǉ� START
//			axGT�o�׈ꗗ.Cols = 18;
			axGT�o�׈ꗗ.Cols = 21;
// MOD 2008.10.29 ���s�j���� ���������ǉ� END
// MOD 2007.02.08 ���s�j���� �ꗗ�\�����ڂ̕ύX END
// MOD 2006.07.26 ���s�j�R�{ �ꗗ�ɉ^���ƕی����̍��ڂ�ǉ� END
			axGT�o�׈ꗗ.Rows = 14;
			axGT�o�׈ꗗ.ColSep = "|";
// MOD 2006.07.26 ���s�j�R�{ �ꗗ�ɉ^���ƕی����̍��ڂ�ǉ� START
//			axGT�o�׈ꗗ.set_RowsText(0, "|�o�ד�|���͂���|��|�d��|�A�����i�^�L���E�i��|�����ԍ�|�w���|�A����|�o�^��|���q�l�ԍ�|�W���[�i���m�n|��|�o��|");
//			axGT�o�׈ꗗ.ColsWidth = "0|3.5|15|3|3.5|12|7|4.5|5|3.5|15|0|0|0|";
//			axGT�o�׈ꗗ.ColsAlignHorz = "1|1|0|2|2|0|0|1|1|1|0|0|0|0|";

//			axGT�o�׈ꗗ.set_RowsText(0, "|�o�ד�|���͂���|��|�d��|�A�����i�^�L���E�i��|�����ԍ�|�w���|�A����|�o�^��|���q�l�ԍ�|�W���[�i���m�n|��|�o��|�o�^��|�ی����i���~�j|�^���i���~�j|");
//			axGT�o�׈ꗗ.ColsWidth = "0|3.5|15|3|3.5|12|7|4.5|5|3.5|15|0|0|0|0|6|6|";
//			axGT�o�׈ꗗ.ColsAlignHorz = "1|1|0|2|2|0|0|1|1|1|0|0|0|0|0|2|2|";

// MOD 2007.02.08 ���s�j���� �ꗗ�\�����ڂ̕ύX START
//			axGT�o�׈ꗗ.set_RowsText(0, "|�o�ד�|���͂���|��|�d��|�ی����i���~�j|�^���i���~�j|�A�����i�^�L���E�i��|�����ԍ�|�w���|�A����|�o�^��|���q�l�ԍ�|�W���[�i���m�n|��|�o��|�o�^��|");
//			axGT�o�׈ꗗ.ColsWidth = "0|4|17|4|4.5|6|6|12|7|4.5|5|3.5|15.5|0|0|0|0|";
//			axGT�o�׈ꗗ.ColsAlignHorz = "1|1|0|2|2|2|2|0|0|1|1|1|0|0|0|0|0|";
			axGT�o�׈ꗗ.set_RowsText(0, "||����|�o�ד�|���͂���|��|�d��|�����ԍ�|���q�l�ԍ�|�w���|�A����|�A�����i�^�L���E�i��|�^��|�ی���|�o�^��|�W���[�i���m�n|��|�o��|�o�^��|");
// MOD 2008.10.29 ���s�j���� ���������ǉ� START
//			axGT�o�׈ꗗ.ColsWidth =    "0|0|2.2|3.6|18|3|3.4|6.5|8.5|5.3|4.6|13.0|6|6|5|0|0|0|0|";
// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� START
//			axGT�o�׈ꗗ.ColsWidth =    "0|0|2.2|3.6|18|3|3.4|6.5|8.5|5.3|4.6|13.0|6|6|5|0|0|0|0|0|0|0|";
			axGT�o�׈ꗗ.ColsWidth =    "0|0|2.2|3.6|18|2.6|3|6.0|9.8|5.3|4.6|13.0|6|6|4.2|0|0|0|0|0|0|0|";
// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� END
// MOD 2008.10.29 ���s�j���� ���������ǉ� END
			axGT�o�׈ꗗ.ColsAlignHorz = "1|1|1|1|0|2|2|0|0|1|1|0|2|2|1|0|0|0|0|";
// MOD 2007.02.08 ���s�j���� �ꗗ�\�����ڂ̕ύX END
// MOD 2006.07.26 ���s�j�R�{ �ꗗ�ɉ^���ƕی����̍��ڂ�ǉ� END

//			axGT�o�׈ꗗ.set_CelForeColor(axGT�o�׈ꗗ.CaretRow,0,111111);
			axGT�o�׈ꗗ.set_CelForeColor(axGT�o�׈ꗗ.CaretRow,0,0x98FB98);  //BGR
			axGT�o�׈ꗗ.set_CelBackColor(axGT�o�׈ꗗ.CaretRow,0,0x006000);

			for(short i = 1; i <= axGT�o�׈ꗗ.Rows; i++ )
			{
				axGT�o�׈ꗗ.set_CelHeight(i,0,2.3);
// MOD 2007.02.08 ���s�j���� �ꗗ�\�����ڂ̕ύX START
//				axGT�o�׈ꗗ.set_CelAlignVert(i,2,3);
//// MOD 2006.08.03 ���s�j�R�{ �ꗗ�ɉ^���ƕی����̍��ڂ�ǉ� START
////				axGT�o�׈ꗗ.set_CelAlignVert(i,5,3);
////				axGT�o�׈ꗗ.set_CelAlignVert(i,6,3);
//				axGT�o�׈ꗗ.set_CelAlignVert(i,7,3);
//				axGT�o�׈ꗗ.set_CelAlignVert(i,8,3);
//// MOD 2006.08.03 ���s�j�R�{ �ꗗ�ɉ^���ƕی����̍��ڂ�ǉ� END
				axGT�o�׈ꗗ.set_CelAlignVert(i,4,3);
				axGT�o�׈ꗗ.set_CelAlignVert(i,7,3);
				axGT�o�׈ꗗ.set_CelAlignVert(i,11,3);
// MOD 2007.02.08 ���s�j���� �ꗗ�\�����ڂ̕ύX END
			}
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void �o�׌���()
		{
			string s�͂��� = "";
			string s�˗��� = "";
			int    i�o�ד� = 0;
// ADD 2005.06.01 ���s�j�����J �`���C�X�͓��t�͈͂Ȃ� START
//			string sSday = gdt�o�ד�.ToShortDateString().Replace("/","");
//			string sEday = gdt�o�ד�.ToShortDateString().Replace("/","");
			string sSday = "";
			string sEday = "";
			if(s��Ԏ�� != "aa")
			{
				sSday = "0";
				sEday = "0";
			}
			else
			{
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX START
//				sSday = gdt�o�ד�.ToShortDateString().Replace("/","");
//				sEday = gdt�o�ד�.ToShortDateString().Replace("/","");
				sSday = YYYYMMDD�ϊ�(gdt�o�ד�);
// MOD 2007.02.20 ���s�j���� �Ĕ��s��ʂŏo�ד��������ł�����ɂ��� START
//				sEday = YYYYMMDD�ϊ�(gdt�o�ד�);
				sEday = "99991231";
// MOD 2007.02.20 ���s�j���� �Ĕ��s��ʂŏo�ד��������ł�����ɂ��� END
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX END
			}
// ADD 2005.06.01 ���s�j�����J �`���C�X�͓��t�͈͂Ȃ� END
//			string s��� = gsa��Ԃb�c[1];
			string s��� = s��Ԏ��;

			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				s�o�׈ꗗ = new string[1];
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
// MOD 2006.07.26 ���s�j�R�{ �ꗗ�ɉ^���ƕی����̍��ڂ�ǉ� START
//				s�o�׈ꗗ = sv_syukka.Get_syukka(gsa���[�U,gs����b�c,gs����b�c,s�͂���, s�˗���, i�o�ד�, sSday, sEday, s���);
				s�o�׈ꗗ = sv_syukka.Get_syukka1(gsa���[�U,gs����b�c,gs����b�c,s�͂���, s�˗���, i�o�ד�, sSday, sEday, s���);
// MOD 2006.07.26 ���s�j�R�{ �ꗗ�ɉ^���ƕی����̍��ڂ�ǉ� END
				tex���b�Z�[�W.Text = s�o�׈ꗗ[0];
				if(s�o�׈ꗗ[0].Length == 4)
				{
					tex���b�Z�[�W.Text = "";
					tex�o�^����.Text = s�o�׈ꗗ[1];
					tex�����v.Text = s�o�׈ꗗ[2];
					tex�d�ʍ��v.Text = s�o�׈ꗗ[3];

					�ŏ��ݒ�();

				}
				else
				{
					if(s�o�׈ꗗ[0].Equals("�Y���f�[�^������܂���"))
					{
						tex���b�Z�[�W.Text = "";
						MessageBox.Show("�Y���f�[�^������܂���","�o�׌���",MessageBoxButtons.OK);
						this.Close();
					}
					else
					{
//						i���ݕŐ� = 1;
						�r�[�v��();
					}
				}
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				tex���b�Z�[�W.Text = gs�ʐM�G���[;
				�r�[�v��();
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				tex���b�Z�[�W.Text = "�ʐM�G���[�F" + ex.Message;
				�r�[�v��();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
			axGT�o�׈ꗗ.CaretRow = 1;
			axGT�o�׈ꗗ_CurPlaceChanged(null,null);

		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lab����.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

		private void axGT�o�׈ꗗ_CurPlaceChanged(object sender, AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEvent e)
		{
			axGT�o�׈ꗗ.set_CelForeColor(OldRow,0,0);
			axGT�o�׈ꗗ.set_CelBackColor(OldRow,0,0xFFFFFF);
			if(axGT�o�׈ꗗ.SelStartRow == axGT�o�׈ꗗ.SelEndRow)
			{
				if(nSrow > nErow)
				{
					nWork = nSrow;
					nSrow = nErow;
					nErow = nWork;
				}
				for(short nCnt = nSrow; nCnt <= nErow; nCnt++)
				{
//					axGT�o�׈ꗗ.set_CelForeColor(nCnt,0,0);
					axGT�o�׈ꗗ.set_CelForeColor(nCnt,0,0);
					axGT�o�׈ꗗ.set_CelBackColor(nCnt,0,0xFFFFFF);
				}
			}
//			axGT�o�׈ꗗ.set_CelForeColor(axGT�o�׈ꗗ.SelStartRow,0,111111);
//			axGT�o�׈ꗗ.set_CelForeColor(axGT�o�׈ꗗ.SelEndRow,0,111111);
//			axGT�o�׈ꗗ.set_CelForeColor(axGT�o�׈ꗗ.CaretRow,0,111111);
// MOD 2011.03.23 ���s�j���� �J�[�\���ێ��@�\�̒ǉ� START
//			axGT�o�׈ꗗ.set_CelForeColor(axGT�o�׈ꗗ.SelStartRow,0,0x98FB98);
//			axGT�o�׈ꗗ.set_CelBackColor(axGT�o�׈ꗗ.SelStartRow,0,0x006000);
//			axGT�o�׈ꗗ.set_CelForeColor(axGT�o�׈ꗗ.SelEndRow,0,0x98FB98);
//			axGT�o�׈ꗗ.set_CelBackColor(axGT�o�׈ꗗ.SelEndRow,0,0x006000);
			short n�J�n = axGT�o�׈ꗗ.SelStartRow;
			short n�I�� = axGT�o�׈ꗗ.SelEndRow;
			if(n�J�n > n�I��){
				n�J�n = axGT�o�׈ꗗ.SelEndRow;
				n�I�� = axGT�o�׈ꗗ.SelStartRow;
			}
			for(short n�s = n�J�n; n�s <= n�I��; n�s++){
				axGT�o�׈ꗗ.set_CelForeColor(n�s,0,0x98FB98);
				axGT�o�׈ꗗ.set_CelBackColor(n�s,0,0x006000);
			}
// MOD 2011.03.23 ���s�j���� �J�[�\���ێ��@�\�̒ǉ� END
			axGT�o�׈ꗗ.set_CelForeColor(axGT�o�׈ꗗ.CaretRow,0,0x98FB98);
			axGT�o�׈ꗗ.set_CelBackColor(axGT�o�׈ꗗ.CaretRow,0,0x006000);
/*			if(axGT�o�׈ꗗ.SelEndRow > axGT�o�׈ꗗ.CaretRow
				&& axGT�o�׈ꗗ.SelStartRow <= axGT�o�׈ꗗ.CaretRow
				&& axGT�o�׈ꗗ.get_CelForeColor(axGT�o�׈ꗗ.SelEndRow,0) != Color.Black)
				axGT�o�׈ꗗ.set_CelForeColor(axGT�o�׈ꗗ.SelEndRow,0,0);

			if(axGT�o�׈ꗗ.SelEndRow < axGT�o�׈ꗗ.CaretRow
				&& axGT�o�׈ꗗ.SelStartRow >= axGT�o�׈ꗗ.CaretRow
				&& axGT�o�׈ꗗ.get_CelForeColor(axGT�o�׈ꗗ.SelEndRow,0) != Color.Black)
				axGT�o�׈ꗗ.set_CelForeColor(axGT�o�׈ꗗ.SelEndRow,0,0);
*/
// MOD 2011.03.23 ���s�j���� �J�[�\���ێ��@�\�̒ǉ� START
//			if(axGT�o�׈ꗗ.SelEndRow > axGT�o�׈ꗗ.CaretRow
//				&& axGT�o�׈ꗗ.SelStartRow <= axGT�o�׈ꗗ.CaretRow
//				&& axGT�o�׈ꗗ.get_CelForeColor(axGT�o�׈ꗗ.SelEndRow,0) != Color.Black)
//			{
//				axGT�o�׈ꗗ.set_CelForeColor(axGT�o�׈ꗗ.SelEndRow,0,0);
//				axGT�o�׈ꗗ.set_CelBackColor(axGT�o�׈ꗗ.SelEndRow,0,0xFFFFFF);
//			}
//
//			if(axGT�o�׈ꗗ.SelEndRow < axGT�o�׈ꗗ.CaretRow
//				&& axGT�o�׈ꗗ.SelStartRow >= axGT�o�׈ꗗ.CaretRow
//				&& axGT�o�׈ꗗ.get_CelForeColor(axGT�o�׈ꗗ.SelEndRow,0) != Color.Black)
//			{
//				axGT�o�׈ꗗ.set_CelForeColor(axGT�o�׈ꗗ.SelEndRow,0,0);
//				axGT�o�׈ꗗ.set_CelBackColor(axGT�o�׈ꗗ.SelEndRow,0,0xFFFFFF);
//			}
// MOD 2011.03.23 ���s�j���� �J�[�\���ێ��@�\�̒ǉ� END

			OldRow = axGT�o�׈ꗗ.CaretRow;
			nSrow  = axGT�o�׈ꗗ.SelStartRow;
			nErow  = axGT�o�׈ꗗ.SelEndRow;

		}

		private void axGT�o�׈ꗗ_CelClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelClickEvent e)
		{
			axGT�o�׈ꗗ_CurPlaceChanged(null,null);
			if(axGT�o�׈ꗗ.SelStartRow != axGT�o�׈ꗗ.SelEndRow)
			{
				if(nSrow > nErow)
				{
					nWork = nSrow;
					nSrow = nErow;
					nErow = nWork;
				}
				for(short nCnt = nSrow; nCnt <= nErow; nCnt++)
				{
					axGT�o�׈ꗗ.set_CelForeColor(nCnt,0,0x98FB98);
					axGT�o�׈ꗗ.set_CelBackColor(nCnt,0,0x006000);
				}
				for(int nCnt = int.Parse(nSrow.ToString()) - 1; nCnt >= 1; nCnt--)
				{
					axGT�o�׈ꗗ.set_CelForeColor(short.Parse(nCnt.ToString()),0,0);
					axGT�o�׈ꗗ.set_CelBackColor(short.Parse(nCnt.ToString()),0,0xFFFFFF);
				}
				for(int nCnt = int.Parse(nErow.ToString()) + 1; nCnt <= axGT�o�׈ꗗ.Rows; nCnt++)
				{
					axGT�o�׈ꗗ.set_CelForeColor(short.Parse(nCnt.ToString()),0,0);
					axGT�o�׈ꗗ.set_CelBackColor(short.Parse(nCnt.ToString()),0,0xFFFFFF);
				}
			}
		}

		private void axGT�o�׈ꗗ_KeyDownEvent(object sender, AxGTABLE32V2Lib._DGTable32Events_KeyDownEvent e)
		{
			if (e.keyCode == 9)
			{
				this.SelectNextControl(axGT�o�׈ꗗ, true, true, true, true);
			}
		}

// MOD 2008.03.19 ���s�j���� �ʍĔ��s�@�\�̒ǉ� START
//		private void btn�Ĕ��s_Click(object sender, System.EventArgs e)
		private void btn�Ĕ��s_Click(int i�J�n, int i�I��)
// MOD 2008.03.19 ���s�j���� �ʍĔ��s�@�\�̒ǉ� END
		{
// MOD 2007.03.10 ���s�j���� �ꗗ�\�����ڂ̕ύX�i��Q�j START
//// MOD 2006.08.10 ���s�j�R�{ �ی������^���ǉ��Ή� START
////			if(axGT�o�׈ꗗ.get_CelText(axGT�o�׈ꗗ.CaretRow,12).Trim().Length == 0)
//			if(axGT�o�׈ꗗ.get_CelText(axGT�o�׈ꗗ.CaretRow,14).Trim().Length == 0)
//// MOD 2006.08.10 ���s�j�R�{ �ی������^���ǉ��Ή� END
			//�o�^���`�F�b�N
			if(axGT�o�׈ꗗ.get_CelText(axGT�o�׈ꗗ.CaretRow,16).Trim().Length == 0)
// MOD 2007.03.10 ���s�j���� �ꗗ�\�����ڂ̕ύX�i��Q�j END
				return;

			tex���b�Z�[�W.Text = "�����׎D������D�D�D";

			try
			{
				�v�����^�`�F�b�N();
			}
			catch(Exception ex)
			{
				tex���b�Z�[�W.Text = ex.Message;
				return;
			}
			Cursor = System.Windows.Forms.Cursors.AppStarting;

			short n�J�n;
			short n�I��;
			if(axGT�o�׈ꗗ.SelStartRow > axGT�o�׈ꗗ.SelEndRow)
			{
				n�I�� = axGT�o�׈ꗗ.SelStartRow;
				n�J�n = axGT�o�׈ꗗ.SelEndRow;
			}
			else
			{
				n�J�n = axGT�o�׈ꗗ.SelStartRow;
				n�I�� = axGT�o�׈ꗗ.SelEndRow;
			}
// MOD 2011.03.23 ���s�j���� �J�[�\���ێ��@�\�̒ǉ� START
			short n�\���J�n = axGT�o�׈ꗗ.TopRow;
			string s�J�n�o�^��         = axGT�o�׈ꗗ.get_CelText(n�J�n,16).Trim();
			string s�J�n�W���[�i���m�n = axGT�o�׈ꗗ.get_CelText(n�J�n,15).Trim();
//�ۗ��F�Ԃ̍s�̃`�F�b�N
			string s�I���o�^��         = axGT�o�׈ꗗ.get_CelText(n�I��,16).Trim();
			string s�I���W���[�i���m�n = axGT�o�׈ꗗ.get_CelText(n�I��,15).Trim();
			string s���s�o�^��         = "";
			string s���s�W���[�i���m�n = "";
			short n���s = (short)(n�I�� + 1);
			if(n���s <= axGT�o�׈ꗗ.Rows){
				s���s�o�^��         = axGT�o�׈ꗗ.get_CelText(n���s,16).Trim();
				s���s�W���[�i���m�n = axGT�o�׈ꗗ.get_CelText(n���s,15).Trim();
			}
// MOD 2011.03.23 ���s�j���� �J�[�\���ێ��@�\�̒ǉ� END

// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j START
//			ds�����.Clear();
			�����f�[�^�N���A();
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j END

			for(short nCnt = n�J�n ; nCnt <= n�I��; nCnt++)
			{
// MOD 2011.03.23 ���s�j���� �J�[�\���ێ��@�\�̒ǉ� START
				//�o�^������Ȃ玟�f�[�^��
				if(axGT�o�׈ꗗ.get_CelText(nCnt,16).Trim().Length == 0){
					continue;
				}
// MOD 2011.03.23 ���s�j���� �J�[�\���ێ��@�\�̒ǉ� END
				try
				{
					string[] sData = new string[2];
// MOD 2007.03.10 ���s�j���� �ꗗ�\�����ڂ̕ύX�i��Q�j START
//// MOD 2006.08.10 ���s�j�R�{ �ی������^���ǉ��Ή� START
////					sData[0] = axGT�o�׈ꗗ.get_CelText(nCnt, 12);
////					sData[1] = axGT�o�׈ꗗ.get_CelText(nCnt, 11);
//					sData[0] = axGT�o�׈ꗗ.get_CelText(nCnt, 14);
//					sData[1] = axGT�o�׈ꗗ.get_CelText(nCnt, 13);
//// MOD 2006.08.10 ���s�j�R�{ �ی������^���ǉ��Ή� END
					//�o�^���A�W���[�i���m�n
					sData[0] = axGT�o�׈ꗗ.get_CelText(nCnt, 16);
					sData[1] = axGT�o�׈ꗗ.get_CelText(nCnt, 15);
// MOD 2007.03.10 ���s�j���� �ꗗ�\�����ڂ̕ύX�i��Q�j END

// MOD 2008.03.19 ���s�j���� �ʍĔ��s�@�\�̒ǉ� START
//					��������w��(sData);
					��������w��(sData, i�J�n, i�I��);
// MOD 2008.03.19 ���s�j���� �ʍĔ��s�@�\�̒ǉ� END
// ADD 2006.12.12 ���s�j�����J �X���ƕ���X�����قȂ�ꍇ�́A������Ȃ� START
					if(!gb���)
					{
						tex���b�Z�[�W.Text = "";
						Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2007.02.19 FJCS�j�K�c ���b�Z�[�W�ύX START
//						MessageBox.Show("���X���Ⴂ�܂��B����ł��܂���B","������"
						MessageBox.Show("�W�דX���Ⴂ�܂��B����ł��܂���B","������"
// MOD 2007.02.19 FJCS�j�K�c ���b�Z�[�W�ύX START
							,MessageBoxButtons.OK);
						return;
					}
// ADD 2006.12.12 ���s�j�����J �X���ƕ���X�����قȂ�ꍇ�́A������Ȃ� END
				}
				catch (Exception ex)
				{
					tex���b�Z�[�W.Text = ex.Message;
					�r�[�v��();
					return;
				}
			}
			Cursor = System.Windows.Forms.Cursors.Default;

			����󒠕[���();

			// �Č���
//			btn�o�׌���_Click(sender, e);
			�o�׌���();
// MOD 2011.03.23 ���s�j���� �J�[�\���ێ��@�\�̒ǉ� START
			�ꗗ�J�[�\���ړ�(n�J�n, n�I��, n�\���J�n
							, s�J�n�o�^��, s�J�n�W���[�i���m�n
							, s�I���o�^��, s�I���W���[�i���m�n
							, s���s�o�^��, s���s�W���[�i���m�n);
// MOD 2011.03.23 ���s�j���� �J�[�\���ێ��@�\�̒ǉ� END

			tex���b�Z�[�W.Text = "";
		}


		private void �ŏ��ݒ�()
		{
//
			if (s�o�׈ꗗ.Length - 4 <= 14)
			{
				axGT�o�׈ꗗ.Rows = 14;
			}
			else if (axGT�o�׈ꗗ.Rows < s�o�׈ꗗ.Length - 4)
			{
				axGT�o�׈ꗗ.Rows = (short)(s�o�׈ꗗ.Length - 4);
			}
			for(short i = 1; i <= axGT�o�׈ꗗ.Rows; i++ )
			{
				axGT�o�׈ꗗ.set_CelHeight(i,0,2.3);
// MOD 2007.02.08 ���s�j���� �ꗗ�\�����ڂ̕ύX START
//				axGT�o�׈ꗗ.set_CelAlignVert(i,2,3);
//// MOD 2006.08.03 ���s�j�R�{ �ꗗ�ɉ^���ƕی����̍��ڂ�ǉ� START
////				axGT�o�׈ꗗ.set_CelAlignVert(i,5,3);
////				axGT�o�׈ꗗ.set_CelAlignVert(i,6,3);
//				axGT�o�׈ꗗ.set_CelAlignVert(i,7,3);
//				axGT�o�׈ꗗ.set_CelAlignVert(i,8,3);
//// MOD 2006.08.03 ���s�j�R�{ �ꗗ�ɉ^���ƕی����̍��ڂ�ǉ� END
				axGT�o�׈ꗗ.set_CelAlignVert(i,4,3);
				axGT�o�׈ꗗ.set_CelAlignVert(i,7,3);
				axGT�o�׈ꗗ.set_CelAlignVert(i,11,3);
// MOD 2007.02.08 ���s�j���� �ꗗ�\�����ڂ̕ύX END
			}
//
			axGT�o�׈ꗗ.Clear();
// ADD 2007.02.21 ���s�j���� ������̃J�����ʒu�̒��� START
			axGT�o�׈ꗗ.CaretRow = 1;
			axGT�o�׈ꗗ.CaretCol = 1;
			axGT�o�׈ꗗ_CurPlaceChanged(null,null);
// ADD 2007.02.21 ���s�j���� ������̃J�����ʒu�̒��� END

			short s�\���� = (short)1;
			for(short sCnt = (short)4; sCnt < s�o�׈ꗗ.Length; sCnt++)
			{
				string sRList = s�o�׈ꗗ[sCnt].Replace("\\r\\n","\r\n");
				axGT�o�׈ꗗ.set_RowsText(s�\����, sRList);
				s�\����++;
			}
			axGT�o�׈ꗗ.Focus();
		}

		private void �����s���_Activated(object sender, System.EventArgs e)
		{
			if(i�A�N�e�B�u�e�f == 0)
				�o�׌���();
			i�A�N�e�B�u�e�f = 1;
		}

// ADD 2008.03.19 ���s�j���� �ʍĔ��s�@�\�̒ǉ� START
		private void btn�Ĕ��s_Click(object sender, System.EventArgs e)
		{
			btn�Ĕ��s_Click(1, 99);
		}

		private void btn�ʍĔ��s_Click(object sender, System.EventArgs e)
		{
			//�o�^���`�F�b�N
			if(axGT�o�׈ꗗ.get_CelText(axGT�o�׈ꗗ.CaretRow,16).Trim().Length == 0)
				return;

			//�P�s�ȏ�
			if(axGT�o�׈ꗗ.SelStartRow != axGT�o�׈ꗗ.SelEndRow)
			{
				MessageBox.Show("�����̃f�[�^��I��������Ԃł͎��s�ł��܂���B\r\n"
								+ "�P���̂ݑI�����Ď��s���Ă��������B"
								, "�m�F", MessageBoxButtons.OK );
				return;
			}

			�ʍĔ��s g�Ĕ��s = new �ʍĔ��s();
			g�Ĕ��s.Left = this.Left + (this.Width  - g�Ĕ��s.Width)  / 2;
			g�Ĕ��s.Top  = this.Top  + (this.Height - g�Ĕ��s.Height) / 2;
			g�Ĕ��s.ShowDialog(this);

			//[����]�{�^���������ꂽ��
			if(g�Ĕ��s.i�J�n == 0 && g�Ĕ��s.i�I�� == 0) return;

			int i�J�n = g�Ĕ��s.i�J�n;
			int i�I�� = g�Ĕ��s.i�I��;
			g�Ĕ��s = null;
			btn�Ĕ��s_Click(i�J�n, i�I��);
		}
// ADD 2008.03.19 ���s�j���� �ʍĔ��s�@�\�̒ǉ� END
// MOD 2011.03.23 ���s�j���� �J�[�\���ێ��@�\�̒ǉ� START
		private void �ꗗ�J�[�\���ړ�(short n�J�n, short n�I��, short n�\���J�n
								, string s�J�n�o�^��, string s�J�n�W���[�i���m�n
								, string s�I���o�^��, string s�I���W���[�i���m�n
								, string s���s�o�^��, string s���s�W���[�i���m�n)
		{
			//�I���s�̃N���A
			axGT�o�׈ꗗ.CaretRow    = 1;
			axGT�o�׈ꗗ.SelStartRow = 1;
			axGT�o�׈ꗗ.SelEndRow   = 1;
			axGT�o�׈ꗗ.CaretCol    = 2;
			//�I���s�̐ݒ�
			short n�V�J�n = 0;
			short n�V�I�� = 0;
			//�I���J�n�s�ƑI���I���s�������Ȃ��ꍇ
			if(s�J�n�o�^�� == axGT�o�׈ꗗ.get_CelText(n�J�n,16).Trim()
			&& s�J�n�W���[�i���m�n == axGT�o�׈ꗗ.get_CelText(n�J�n,15).Trim()
			&& s�I���o�^�� == axGT�o�׈ꗗ.get_CelText(n�I��,16).Trim()
			&& s�I���W���[�i���m�n == axGT�o�׈ꗗ.get_CelText(n�I��,15).Trim()){
				n�V�J�n = n�J�n;
				n�V�I�� = n�I��;
			}else{
				for(short n�s = 1; n�s <= axGT�o�׈ꗗ.Rows; n�s++){
					//�I���J�n�s�̒l�i�o�^���A�W���[�i���m�n�j�������ꍇ
					if(s�J�n�o�^�� == axGT�o�׈ꗗ.get_CelText(n�s,16).Trim()
					&& s�J�n�W���[�i���m�n == axGT�o�׈ꗗ.get_CelText(n�s,15).Trim()){
						n�V�J�n = n�s;
					}
					//�I���I���s�̒l�i�o�^���A�W���[�i���m�n�j�������ꍇ
					if(s�I���o�^�� == axGT�o�׈ꗗ.get_CelText(n�s,16).Trim()
					&& s�I���W���[�i���m�n == axGT�o�׈ꗗ.get_CelText(n�s,15).Trim()){
						n�V�I�� = n�s;
						break;
					}
				}
			}
			//�X�N���[���ʒu�̐ݒ�
			if(n�\���J�n <= axGT�o�׈ꗗ.Rows){
				axGT�o�׈ꗗ.TopRow = n�\���J�n;
			}
			//�Č�����̈ꗗ�ɊY���f�[�^�����݂���ꍇ
			if(n�V�I�� > 0){
//�ۗ��F�Ԃ̍s�̃`�F�b�N
				//�I���s���������ꍇ
				if(n�V�J�n > 0 && (n�I�� - n�J�n == n�V�I�� - n�V�J�n)){
					axGT�o�׈ꗗ.CaretRow    = n�V�J�n;
					axGT�o�׈ꗗ.SelStartRow = n�V�J�n;
					axGT�o�׈ꗗ.SelEndRow   = n�V�I��;
				}else{
					axGT�o�׈ꗗ.CaretRow    = n�V�I��;
					axGT�o�׈ꗗ.SelStartRow = n�V�I��;
					axGT�o�׈ꗗ.SelEndRow   = n�V�I��;
				}
			}else{
				if(s���s�o�^��.Length > 0 && s���s�W���[�i���m�n.Length > 0){
					for(short n�s = 1; n�s <= axGT�o�׈ꗗ.Rows; n�s++){
						//�I���J�n�s�̒l�i�o�^���A�W���[�i���m�n�j�������ꍇ
						if(s���s�o�^�� == axGT�o�׈ꗗ.get_CelText(n�s,16).Trim()
						&& s���s�W���[�i���m�n == axGT�o�׈ꗗ.get_CelText(n�s,15).Trim()){
							axGT�o�׈ꗗ.CaretRow    = n�s;
							axGT�o�׈ꗗ.SelStartRow = n�s;
							axGT�o�׈ꗗ.SelEndRow   = n�s;
							break;
						}
					}
				}
			}
			axGT�o�׈ꗗ_CurPlaceChanged(null,null);
		}
// MOD 2011.03.23 ���s�j���� �J�[�\���ێ��@�\�̒ǉ� END

	}
}
