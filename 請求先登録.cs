using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [�������񃁃��e�i���X]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// ADD 2007.03.28 ���s�j���� ORA-00936�imissing expression�j�Ή� 
	// MOD 2007.07.26 ���s�j���� �˗���ɓo�^���Ȃ��ɂ�������炸�����悪�폜�ł��Ȃ� 
	//--------------------------------------------------------------------------
	// ADD 2008.03.27 ���s�j���� ������̍X�V�����N���A�Ή� 
	// ADD 2008.03.27 ���s�j���� �ꗗ�Ɋ��ɂ���f�[�^�̑Ή� 
	// ADD 2008.11.20 ���s�j���� ���Ӑ敔�ۃR�[�h�̋󔒎��Ή� 
	//                Oracle���֎��̐ݒ�ڍs����H or �o�[�W�����ɂ�鍷��
	//--------------------------------------------------------------------------
	// MOD 2010.02.02 ���s�j���� �擪�ɋ󔒍s������ 
	// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� 
	//--------------------------------------------------------------------------
	public class ������o�^ : ���ʃt�H�[��//System.Windows.Forms.Form
	{
		private string s�X�֔ԍ� = "";
		private string s�X�V���� = "";
		private short nOldRow = 0;

		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Label lab������^�C�g��;
		private System.Windows.Forms.Label lab���Ӑ敔�ۖ�;
		private System.Windows.Forms.Button btn��������;
		private System.Windows.Forms.Button btn������폜;
		private System.Windows.Forms.Button btn������o�^;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lab���Ӑ�R�[�h;
		private System.Windows.Forms.Label lab���Ӑ敔�ۃR�[�h;
		private AxGTABLE32V2Lib.AxGTable32 axGT������;
		private System.Windows.Forms.Panel pnl������;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private ���ʃe�L�X�g�{�b�N�X tex���Ӑ�R�[�h;
		private ���ʃe�L�X�g�{�b�N�X tex���Ӑ敔�ۃR�[�h;
		private ���ʃe�L�X�g�{�b�N�X tex���Ӑ敔�ۖ�;
		private System.Windows.Forms.TextBox tex���b�Z�[�W;
		private System.Windows.Forms.Label lab���ӏ���;
		private System.ComponentModel.IContainer components = null;

		public ������o�^()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
			�c�o�h�\���T�C�Y�ϊ�();
//			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
				this.axGT������.Size = new System.Drawing.Size(306, 217);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(������o�^));
			this.pnl������ = new System.Windows.Forms.Panel();
			this.lab���ӏ��� = new System.Windows.Forms.Label();
			this.tex���Ӑ敔�ۖ� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex���Ӑ敔�ۃR�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex���Ӑ�R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.label2 = new System.Windows.Forms.Label();
			this.lab���Ӑ敔�ۃR�[�h = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lab���Ӑ�R�[�h = new System.Windows.Forms.Label();
			this.axGT������ = new AxGTABLE32V2Lib.AxGTable32();
			this.lab���Ӑ敔�ۖ� = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.btn������폜 = new System.Windows.Forms.Button();
			this.btn�������� = new System.Windows.Forms.Button();
			this.btn������o�^ = new System.Windows.Forms.Button();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab������^�C�g�� = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.tex���b�Z�[�W = new System.Windows.Forms.TextBox();
			this.btn���� = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.pnl������.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axGT������)).BeginInit();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnl������
			// 
			this.pnl������.BackColor = System.Drawing.Color.Honeydew;
			this.pnl������.Controls.Add(this.lab���ӏ���);
			this.pnl������.Controls.Add(this.tex���Ӑ敔�ۖ�);
			this.pnl������.Controls.Add(this.tex���Ӑ敔�ۃR�[�h);
			this.pnl������.Controls.Add(this.tex���Ӑ�R�[�h);
			this.pnl������.Controls.Add(this.label2);
			this.pnl������.Controls.Add(this.lab���Ӑ敔�ۃR�[�h);
			this.pnl������.Controls.Add(this.label3);
			this.pnl������.Controls.Add(this.lab���Ӑ�R�[�h);
			this.pnl������.Controls.Add(this.axGT������);
			this.pnl������.Controls.Add(this.lab���Ӑ敔�ۖ�);
			this.pnl������.Controls.Add(this.label22);
			this.pnl������.Controls.Add(this.btn������폜);
			this.pnl������.Controls.Add(this.btn��������);
			this.pnl������.Controls.Add(this.btn������o�^);
			this.pnl������.Location = new System.Drawing.Point(0, 6);
			this.pnl������.Name = "pnl������";
			this.pnl������.Size = new System.Drawing.Size(370, 442);
			this.pnl������.TabIndex = 1;
			// 
			// lab���ӏ���
			// 
			this.lab���ӏ���.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���ӏ���.ForeColor = System.Drawing.Color.Red;
			this.lab���ӏ���.Location = new System.Drawing.Point(42, 240);
			this.lab���ӏ���.Name = "lab���ӏ���";
			this.lab���ӏ���.Size = new System.Drawing.Size(302, 30);
			this.lab���ӏ���.TabIndex = 79;
			this.lab���ӏ���.Text = "���Ӑ�R�[�h�y�ѓ��Ӑ敔�ۃR�[�h�́A�Ŋ�̕��Љc�Ə��܂ł��⍇�����������B";
			this.lab���ӏ���.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tex���Ӑ敔�ۖ�
			// 
			this.tex���Ӑ敔�ۖ�.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���Ӑ敔�ۖ�.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex���Ӑ敔�ۖ�.Location = new System.Drawing.Point(158, 338);
			this.tex���Ӑ敔�ۖ�.MaxLength = 10;
			this.tex���Ӑ敔�ۖ�.Name = "tex���Ӑ敔�ۖ�";
			this.tex���Ӑ敔�ۖ�.Size = new System.Drawing.Size(174, 23);
			this.tex���Ӑ敔�ۖ�.TabIndex = 4;
			this.tex���Ӑ敔�ۖ�.Text = "";
			// 
			// tex���Ӑ敔�ۃR�[�h
			// 
			this.tex���Ӑ敔�ۃR�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���Ӑ敔�ۃR�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex���Ӑ敔�ۃR�[�h.Location = new System.Drawing.Point(158, 308);
			this.tex���Ӑ敔�ۃR�[�h.MaxLength = 6;
			this.tex���Ӑ敔�ۃR�[�h.Name = "tex���Ӑ敔�ۃR�[�h";
			this.tex���Ӑ敔�ۃR�[�h.Size = new System.Drawing.Size(86, 23);
			this.tex���Ӑ敔�ۃR�[�h.TabIndex = 3;
			this.tex���Ӑ敔�ۃR�[�h.Text = "";
			// 
			// tex���Ӑ�R�[�h
			// 
			this.tex���Ӑ�R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���Ӑ�R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex���Ӑ�R�[�h.Location = new System.Drawing.Point(158, 280);
			this.tex���Ӑ�R�[�h.MaxLength = 12;
			this.tex���Ӑ�R�[�h.Name = "tex���Ӑ�R�[�h";
			this.tex���Ӑ�R�[�h.Size = new System.Drawing.Size(156, 23);
			this.tex���Ӑ�R�[�h.TabIndex = 2;
			this.tex���Ӑ�R�[�h.Text = "";
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(42, 342);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 14);
			this.label2.TabIndex = 78;
			this.label2.Text = "��";
			// 
			// lab���Ӑ敔�ۃR�[�h
			// 
			this.lab���Ӑ敔�ۃR�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���Ӑ敔�ۃR�[�h.Location = new System.Drawing.Point(56, 312);
			this.lab���Ӑ敔�ۃR�[�h.Name = "lab���Ӑ敔�ۃR�[�h";
			this.lab���Ӑ敔�ۃR�[�h.Size = new System.Drawing.Size(95, 14);
			this.lab���Ӑ敔�ۃR�[�h.TabIndex = 77;
			this.lab���Ӑ敔�ۃR�[�h.Text = "���Ӑ敔�ۃR�[�h";
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(42, 286);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 14);
			this.label3.TabIndex = 76;
			this.label3.Text = "��";
			// 
			// lab���Ӑ�R�[�h
			// 
			this.lab���Ӑ�R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���Ӑ�R�[�h.Location = new System.Drawing.Point(56, 286);
			this.lab���Ӑ�R�[�h.Name = "lab���Ӑ�R�[�h";
			this.lab���Ӑ�R�[�h.Size = new System.Drawing.Size(95, 14);
			this.lab���Ӑ�R�[�h.TabIndex = 75;
			this.lab���Ӑ�R�[�h.Text = "���Ӑ�R�[�h";
			// 
			// axGT������
			// 
			this.axGT������.ContainingControl = this;
			this.axGT������.DataSource = null;
			this.axGT������.Location = new System.Drawing.Point(44, 12);
			this.axGT������.Name = "axGT������";
			this.axGT������.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT������.OcxState")));
			this.axGT������.Size = new System.Drawing.Size(306, 217);
			this.axGT������.TabIndex = 0;
			this.axGT������.KeyDownEvent += new AxGTABLE32V2Lib._DGTable32Events_KeyDownEventHandler(this.axGT������_KeyDownEvent);
			this.axGT������.CelDblClick += new AxGTABLE32V2Lib._DGTable32Events_CelDblClickEventHandler(this.axGT������_CelDblClick);
			this.axGT������.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT������_CurPlaceChanged);
			// 
			// lab���Ӑ敔�ۖ�
			// 
			this.lab���Ӑ敔�ۖ�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���Ӑ敔�ۖ�.Location = new System.Drawing.Point(56, 342);
			this.lab���Ӑ敔�ۖ�.Name = "lab���Ӑ敔�ۖ�";
			this.lab���Ӑ敔�ۖ�.Size = new System.Drawing.Size(95, 14);
			this.lab���Ӑ敔�ۖ�.TabIndex = 52;
			this.lab���Ӑ敔�ۖ�.Text = "���Ӑ敔�ۖ�";
			// 
			// label22
			// 
			this.label22.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label22.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label22.ForeColor = System.Drawing.Color.Blue;
			this.label22.Location = new System.Drawing.Point(0, 0);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(22, 444);
			this.label22.TabIndex = 50;
			this.label22.Text = "��������";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn������폜
			// 
			this.btn������폜.BackColor = System.Drawing.Color.SteelBlue;
			this.btn������폜.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn������폜.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn������폜.ForeColor = System.Drawing.Color.White;
			this.btn������폜.Location = new System.Drawing.Point(288, 406);
			this.btn������폜.Name = "btn������폜";
			this.btn������폜.Size = new System.Drawing.Size(64, 22);
			this.btn������폜.TabIndex = 13;
			this.btn������폜.Text = "�폜";
			this.btn������폜.Click += new System.EventHandler(this.btn������폜_Click);
			// 
			// btn��������
			// 
			this.btn��������.BackColor = System.Drawing.Color.SteelBlue;
			this.btn��������.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn��������.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn��������.ForeColor = System.Drawing.Color.White;
			this.btn��������.Location = new System.Drawing.Point(210, 406);
			this.btn��������.Name = "btn��������";
			this.btn��������.Size = new System.Drawing.Size(64, 22);
			this.btn��������.TabIndex = 12;
			this.btn��������.Text = "���";
			this.btn��������.Click += new System.EventHandler(this.btn��������_Click);
			// 
			// btn������o�^
			// 
			this.btn������o�^.BackColor = System.Drawing.Color.SteelBlue;
			this.btn������o�^.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn������o�^.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn������o�^.ForeColor = System.Drawing.Color.White;
			this.btn������o�^.Location = new System.Drawing.Point(134, 406);
			this.btn������o�^.Name = "btn������o�^";
			this.btn������o�^.Size = new System.Drawing.Size(64, 22);
			this.btn������o�^.TabIndex = 10;
			this.btn������o�^.Text = "�ۑ�";
			this.btn������o�^.Click += new System.EventHandler(this.btn������o�^_Click);
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.PaleGreen;
			this.panel6.Location = new System.Drawing.Point(0, 26);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(396, 26);
			this.panel6.TabIndex = 12;
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.lab������^�C�g��);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(396, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab������^�C�g��
			// 
			this.lab������^�C�g��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab������^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab������^�C�g��.ForeColor = System.Drawing.Color.White;
			this.lab������^�C�g��.Location = new System.Drawing.Point(12, 2);
			this.lab������^�C�g��.Name = "lab������^�C�g��";
			this.lab������^�C�g��.Size = new System.Drawing.Size(264, 24);
			this.lab������^�C�g��.TabIndex = 0;
			this.lab������^�C�g��.Text = "�������񃁃��e�i���X";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.tex���b�Z�[�W);
			this.panel8.Controls.Add(this.btn����);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(396, 58);
			this.panel8.TabIndex = 2;
			// 
			// tex���b�Z�[�W
			// 
			this.tex���b�Z�[�W.BackColor = System.Drawing.Color.PaleGreen;
			this.tex���b�Z�[�W.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���b�Z�[�W.ForeColor = System.Drawing.Color.Red;
			this.tex���b�Z�[�W.Location = new System.Drawing.Point(126, 4);
			this.tex���b�Z�[�W.Multiline = true;
			this.tex���b�Z�[�W.Name = "tex���b�Z�[�W";
			this.tex���b�Z�[�W.ReadOnly = true;
			this.tex���b�Z�[�W.Size = new System.Drawing.Size(256, 50);
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
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.pnl������);
			this.groupBox2.Location = new System.Drawing.Point(8, 58);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(372, 450);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// ������o�^
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(388, 574);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(394, 605);
			this.Name = "������o�^";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 �������񃁃��e�i���X";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
			this.Load += new System.EventHandler(this.������o�^_Load);
			this.Closed += new System.EventHandler(this.������o�^_Closed);
			this.pnl������.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axGT������)).EndInit();
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btn����_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		private void ������o�^_Load(object sender, System.EventArgs e)
		{
			�������[�h();
			
			// �����惊�X�g�̏����ݒ�
			axGT������.Cols = 4;
// MOD 2010.02.02 ���s�j���� �擪�ɋ󔒍s������ START
//			axGT������.Rows = 6;
			axGT������.Rows = 11;
// MOD 2010.02.02 ���s�j���� �擪�ɋ󔒍s������ END
			axGT������.ColSep = "|";
			axGT������.CaretRow = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� START
//			axGT������.CaretCol = 2;
			axGT������.CaretCol = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� END
			axGT������.NoBeep = true;			

			axGT������.set_RowsText(0, "|���Ӑ�R�[�h|���ۃR�[�h|���ۖ�|�X�V����|");
			axGT������.ColsWidth = "0|7|5|10|0|";
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� START
			�J�������̕␳(axGT������);
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� END
			axGT������.ColsAlignHorz = "1|1|1|0|0|";
            
//			axGT������.set_CelForeColor(axGT������.CaretRow,0,111111);
			axGT������.set_CelForeColor(axGT������.CaretRow,0,0x98FB98);  //BGR
			axGT������.set_CelBackColor(axGT������.CaretRow,0,0x006000);

			axGT������.Clear();
			������ꗗ����();
		}

		private void �������[�h()
		{
			������o�^���[�h();
			tex���Ӑ�R�[�h.Focus();
		}

		private void ������o�^���[�h()
		{
			tex���Ӑ�R�[�h.Text = "";
			tex���Ӑ敔�ۃR�[�h.Text = "";
			tex���Ӑ敔�ۖ�.Text = "";

			axGT������.set_CelForeColor(nOldRow,0,0);
			axGT������.set_CelBackColor(nOldRow,0,0xFFFFFF);
//			axGT������.set_CelForeColor(axGT������.CaretRow,0,111111);
			axGT������.set_CelForeColor(axGT������.CaretRow,0,0x98FB98);  //BGR
			axGT������.set_CelBackColor(axGT������.CaretRow,0,0x006000);
			nOldRow = axGT������.CaretRow;
			axGT������.Focus();
			tex���Ӑ�R�[�h.Text     = axGT������.get_CelText(axGT������.CaretRow,1);
			tex���Ӑ敔�ۃR�[�h.Text = axGT������.get_CelText(axGT������.CaretRow,2);
			tex���Ӑ敔�ۖ�.Text     = axGT������.get_CelText(axGT������.CaretRow,3);
			s�X�V����                = axGT������.get_CelText(axGT������.CaretRow,4);
		}

		private void ������ꗗ����()
		{
// MOD 2010.02.02 ���s�j���� �擪�ɋ󔒍s������ START
//			short s�\���� = 1;
//			axGT������.Clear();
//			axGT������.Rows = 6;
			short s�\���� = 2;
			axGT������.Clear();
			axGT������.Rows = 11;
// MOD 2010.02.02 ���s�j���� �擪�ɋ󔒍s������ END
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� START
//			axGT������.CaretRow = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� END

			axGT������.Clear();
			tex���b�Z�[�W.Text = "�������D�D�D";
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;

			try
			{
				if(sv_seikyuu == null) sv_seikyuu = new is2seikyuu.Service1();
// DEL 2005.05.20 ���s�j���� �Z�V�����R���g���[���̔p�~ START
//				sv_seikyuu.CookieContainer = cContainer;
// DEL 2005.05.20 ���s�j���� �Z�V�����R���g���[���̔p�~ END
				String[] sList = sv_seikyuu.Get_Claim(gsa���[�U,gs����b�c.Trim(),gs����b�c.Trim());
				s�X�֔ԍ� = sList[1];
				if(sList[0].Equals("����I��") || sList[0].Equals("�Y���f�[�^������܂���"))
				{
					tex���b�Z�[�W.Text = "";
// MOD 2010.02.02 ���s�j���� �擪�ɋ󔒍s������ START
//					if (axGT������.Rows < sList.Length - 2)
//					{
//						axGT������.Rows = (short)(sList.Length - 2);
//					}
					//�s���ݒ�
					if(axGT������.Rows < (sList.Length - 1)){
						axGT������.Rows = (short)(sList.Length - 1);
					}
// MOD 2010.02.02 ���s�j���� �擪�ɋ󔒍s������ END
					for(short nCnt = 2; nCnt < sList.Length; nCnt++)
					{
						axGT������.set_RowsText(s�\����, sList[nCnt]);
						s�\����++;
					}
					tex���Ӑ�R�[�h.Text     = axGT������.get_CelText(axGT������.CaretRow,1);
					tex���Ӑ敔�ۃR�[�h.Text = axGT������.get_CelText(axGT������.CaretRow,2);
					tex���Ӑ敔�ۖ�.Text     = axGT������.get_CelText(axGT������.CaretRow,3);
					s�X�V����                = axGT������.get_CelText(axGT������.CaretRow,4);
				}
				else
				{
					tex���b�Z�[�W.Text = sList[0];
				}
			}
// ADD 2005.07.04 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				tex���b�Z�[�W.Text = gs�ʐM�G���[;
				�r�[�v��();
				�������[�h();
			}
// ADD 2005.07.04 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				tex���b�Z�[�W.Text = ex.Message;
				�r�[�v��();
				�������[�h();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void axGT������_CelDblClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelDblClickEvent e)
		{
/*			string s���Ӑ� = axGT������.get_CelText(axGT������.CaretRow,1);
			if(!s���Ӑ�.Equals(""))
			{
				tex���Ӑ�R�[�h.Text     = s���Ӑ�;
				tex���Ӑ敔�ۃR�[�h.Text = axGT������.get_CelText(axGT������.CaretRow,2);
				tex���Ӑ敔�ۖ�.Text     = axGT������.get_CelText(axGT������.CaretRow,3);
//				s�X�֔ԍ�                = axGT������.get_CelText(axGT������.CaretRow,1);
				s�X�V����                = axGT������.get_CelText(axGT������.CaretRow,4);

			}*/
		}

		private void axGT������_KeyDownEvent(object sender, AxGTABLE32V2Lib._DGTable32Events_KeyDownEvent e)
		{
			if (e.keyCode == 0x0d)
			{
				this.SelectNextControl(axGT������, true, true, true, true);
			}
			if (e.keyCode == 0x09)
			{
				this.SelectNextControl(axGT������, true, true, true, true);
			}
		}
		
		private void btn��������_Click(object sender, System.EventArgs e)
		{
			tex���Ӑ�R�[�h.Text = "";
			tex���Ӑ敔�ۃR�[�h.Text = "";
			tex���Ӑ敔�ۖ�.Text = "";
// ADD 2008.03.27 ���s�j���� ������̍X�V�����N���A�Ή� START
			s�X�V���� = "";
// ADD 2008.03.27 ���s�j���� ������̍X�V�����N���A�Ή� END
		}

		private void btn������o�^_Click(object sender, System.EventArgs e)
		{
			tex���Ӑ�R�[�h.Text     =  tex���Ӑ�R�[�h.Text.Trim();
			tex���Ӑ敔�ۃR�[�h.Text =  tex���Ӑ敔�ۃR�[�h.Text.Trim();
			tex���Ӑ敔�ۖ�.Text     =  tex���Ӑ敔�ۖ�.Text.Trim();

			if(!�K�{�`�F�b�N(tex���Ӑ�R�[�h, "���Ӑ�R�[�h")) return;
			if (tex���Ӑ敔�ۃR�[�h.Text.Length == 0)
			{
				tex���Ӑ敔�ۃR�[�h.Text = " ";
			}
			if(!�K�{�`�F�b�N(tex���Ӑ敔�ۖ�, "���Ӑ敔�ۖ�")) return;

			if(!���p�`�F�b�N(tex���Ӑ�R�[�h, "���Ӑ�R�[�h")) return;
			if(!���p�`�F�b�N(tex���Ӑ敔�ۃR�[�h, "���Ӑ敔�ۃR�[�h")) return;
			if(!�S�p�`�F�b�N(tex���Ӑ敔�ۖ�, "���Ӑ敔�ۖ�")) return;

			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				if(sv_seikyuu == null) sv_seikyuu = new is2seikyuu.Service1();
				String[] sCnt = sv_seikyuu.Get_seikyuucnt(gsa���[�U,s�X�֔ԍ�,tex���Ӑ�R�[�h.Text,tex���Ӑ敔�ۃR�[�h.Text);
				this.Cursor = System.Windows.Forms.Cursors.Default;

				string[] sKey  = new string[8];
				sKey[0] = s�X�֔ԍ�;
				sKey[1] = tex���Ӑ�R�[�h.Text;
				sKey[2] = tex���Ӑ敔�ۃR�[�h.Text;
				sKey[3] = tex���Ӑ敔�ۖ�.Text;
				sKey[4] = gs����b�c;
				sKey[5] = "������o";
				sKey[6] = gs���p�҂b�c;
				sKey[7] = s�X�V����;

				DialogResult result;
				if(sCnt[0] == "0")
				{
					result = MessageBox.Show("�V�K�o�^���܂����H","�o�^",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						//������̒ǉ�
						tex���b�Z�[�W.Text = "�o�^���D�D�D";

						if(sv_seikyuu == null) sv_seikyuu = new is2seikyuu.Service1();
						string[] sList = sv_seikyuu.Ins_Claim(gsa���[�U, sKey);
						Cursor = System.Windows.Forms.Cursors.Default;

						if (sList[0].Equals("����I��"))
						{
							������ꗗ����();
							������o�^���[�h();
							tex���b�Z�[�W.Text = "";
						}
						else
						{
							�r�[�v��();
							tex���b�Z�[�W.Text = sList[0];
						}
					}
				}
				else
				{
// ADD 2008.03.27 ���s�j���� �ꗗ�Ɋ��ɂ���f�[�^�̑Ή� START
					s�X�V���� = "";
					for(short sRow = 1; sRow <= axGT������.Rows; sRow++){
						if(tex���Ӑ�R�[�h.Text.Trim().Equals(axGT������.get_CelText(sRow,1))
						&& tex���Ӑ敔�ۃR�[�h.Text.Trim().Equals(axGT������.get_CelText(sRow,2))){
							s�X�V���� = axGT������.get_CelText(sRow,4);
							sKey[7] = s�X�V����;
							break;
						}
					}
// ADD 2008.03.27 ���s�j���� �ꗗ�Ɋ��ɂ���f�[�^�̑Ή� END
// ADD 2007.03.28 ���s�j���� ORA-00936�imissing expression�j�Ή� START
					if(s�X�V���� == null || s�X�V����.Trim().Length == 0)
					{
						MessageBox.Show("���͂��ꂽ���Ӑ�R�[�h�y�ѓ��Ӑ敔�ۃR�[�h�́A\n"
										+ "���ɑ��̂��q�l�Ŏg�p����Ă��܂��B"
							,"�X�V",MessageBoxButtons.OK);
						return;
					}
// ADD 2007.03.28 ���s�j���� ORA-00936�imissing expression�j�Ή� END

					result = MessageBox.Show("���ɑ��݂���f�[�^�ɏ㏑�����܂����H","�X�V",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						//������̍X�V
						tex���b�Z�[�W.Text = "�X�V���D�D�D";

						if(sv_seikyuu == null) sv_seikyuu = new is2seikyuu.Service1();
						string[] sList = sv_seikyuu.Upd_Claim(gsa���[�U, sKey);
						Cursor = System.Windows.Forms.Cursors.Default;

						tex���b�Z�[�W.Text = sList[0];
						if (sList[0].Equals("����I��"))
						{
							������ꗗ����();
							������o�^���[�h();
						}
						else
						{
							�r�[�v��();
						}
					}
				}
			}
// ADD 2005.07.04 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				tex���b�Z�[�W.Text = gs�ʐM�G���[;
				�r�[�v��();
				�������[�h();
			}
// ADD 2005.07.04 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				tex���b�Z�[�W.Text = ex.Message;
				�r�[�v��();
				�������[�h();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void btn������폜_Click(object sender, System.EventArgs e)
		{
			tex���Ӑ�R�[�h.Text     =  tex���Ӑ�R�[�h.Text.Trim();
			tex���Ӑ敔�ۃR�[�h.Text =  tex���Ӑ敔�ۃR�[�h.Text.Trim();

			if(!�K�{�`�F�b�N(tex���Ӑ�R�[�h, "���Ӑ�R�[�h")) return;
// ADD 2008.11.20 ���s�j���� ���Ӑ敔�ۃR�[�h�̋󔒎��Ή� START
			if (tex���Ӑ敔�ۃR�[�h.Text.Length == 0)
			{
				tex���Ӑ敔�ۃR�[�h.Text = " ";
			}
// ADD 2008.11.20 ���s�j���� ���Ӑ敔�ۃR�[�h�̋󔒎��Ή� END
			if(!���p�`�F�b�N(tex���Ӑ�R�[�h, "���Ӑ�R�[�h")) return;
			if(!���p�`�F�b�N(tex���Ӑ敔�ۃR�[�h, "���Ӑ敔�ۃR�[�h")) return;

			//������̍폜
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;

			string[] sKey  = new string[6];
			try
			{
				if(sv_seikyuu == null) sv_seikyuu = new is2seikyuu.Service1();
				String[] sCnt = sv_seikyuu.Get_seikyuucnt(gsa���[�U,s�X�֔ԍ�,tex���Ӑ�R�[�h.Text,tex���Ӑ敔�ۃR�[�h.Text);
				this.Cursor = System.Windows.Forms.Cursors.Default;

				DialogResult result;
				if(sCnt[0] == "0")
				{
					MessageBox.Show("�R�[�h(" + tex���Ӑ�R�[�h.Text + ")�̃f�[�^�͑��݂��܂���","�폜",MessageBoxButtons.OK);
				}
				else
				{
// ADD 2008.03.27 ���s�j���� �ꗗ�Ɋ��ɂ���f�[�^�̑Ή� START
					s�X�V���� = "";
					for(short sRow = 1; sRow <= axGT������.Rows; sRow++){
						if(tex���Ӑ�R�[�h.Text.Trim().Equals(axGT������.get_CelText(sRow,1))
						&& tex���Ӑ敔�ۃR�[�h.Text.Trim().Equals(axGT������.get_CelText(sRow,2))){
							s�X�V���� = axGT������.get_CelText(sRow,4);
							break;
						}
					}
// ADD 2008.03.27 ���s�j���� �ꗗ�Ɋ��ɂ���f�[�^�̑Ή� END
// ADD 2007.03.28 ���s�j���� ORA-00936�imissing expression�j�Ή� START
					if(s�X�V���� == null || s�X�V����.Trim().Length == 0)
					{
						MessageBox.Show("���͂��ꂽ���Ӑ�R�[�h�y�ѓ��Ӑ敔�ۃR�[�h�́A\n"
										+ "���̂��q�l�Ŏg�p����Ă��܂��B"
							,"�폜",MessageBoxButtons.OK);
						return;
					}
// ADD 2007.03.28 ���s�j���� ORA-00936�imissing expression�j�Ή� END
// ADD 2005.11.07 ���s�j�ɉ� �o�׃W���[�i���`�F�b�N START
					if(sv_seikyuu == null) sv_seikyuu = new is2seikyuu.Service1();
// MOD 2007.07.26 ���s�j���� �˗���ɓo�^���Ȃ��ɂ�������炸�����悪�폜�ł��Ȃ� START
//					string[] sCKey = new string[3];
//					sCKey[0] = gs����b�c;
//					sCKey[1] = tex���Ӑ�R�[�h.Text;
//					sCKey[2] = tex���Ӑ敔�ۃR�[�h.Text;
					string[] sCKey = new string[4];
					sCKey[0] = gs����b�c;
					sCKey[1] = tex���Ӑ�R�[�h.Text;
					sCKey[2] = tex���Ӑ敔�ۃR�[�h.Text;
					sCKey[3] = s�X�֔ԍ�;
// MOD 2007.07.26 ���s�j���� �˗���ɓo�^���Ȃ��ɂ�������炸�����悪�폜�ł��Ȃ� END
					if (sCKey[2].Length == 0)
						sCKey[2] = " ";
					String[] sCList = sv_seikyuu.Sel_IrainusiSeikyuu(gsa���[�U,sCKey);

					if(sCList[0].Length != 4)
					{
						�r�[�v��();
						tex���b�Z�[�W.Text = sCList[0];
						return;
					}
// ADD 2005.11.07 ���s�j�ɉ� �o�׃W���[�i���`�F�b�N END

					result = MessageBox.Show("�R�[�h(" + tex���Ӑ�R�[�h.Text + ")�̃f�[�^���폜���܂����H","�폜",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						tex���b�Z�[�W.Text = "�폜���D�D�D";
						sKey[0] = s�X�֔ԍ�;
						sKey[1] = tex���Ӑ�R�[�h.Text;
						sKey[2] = tex���Ӑ敔�ۃR�[�h.Text;
						sKey[3] = "������}";
						sKey[4] = gs���p�҂b�c;
						sKey[5] = s�X�V����;

						Cursor = System.Windows.Forms.Cursors.AppStarting;

						if(sv_seikyuu == null) sv_seikyuu = new is2seikyuu.Service1();
						string[] sList = sv_seikyuu.Del_Claim(gsa���[�U, sKey);

						tex���b�Z�[�W.Text = sList[0];
						if (sList[0].Equals("����I��"))
						{
							������ꗗ����();
							������o�^���[�h();
						}
						else
						{
							�r�[�v��();
						}
					}
					Cursor = System.Windows.Forms.Cursors.Default;
				}
			}
// ADD 2005.07.04 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				tex���b�Z�[�W.Text = gs�ʐM�G���[;
				�r�[�v��();
				�������[�h();
			}
// ADD 2005.07.04 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				tex���b�Z�[�W.Text = ex.Message;
				�r�[�v��();
				�������[�h();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void axGT������_CurPlaceChanged(object sender, AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEvent e)
		{
			axGT������.set_CelForeColor(nOldRow,0,0);
			axGT������.set_CelBackColor(nOldRow,0,0xFFFFFF);
//			axGT������.set_CelForeColor(axGT������.CaretRow,0,111111);
			axGT������.set_CelForeColor(axGT������.CaretRow,0,0x98FB98);  //BGR
			axGT������.set_CelBackColor(axGT������.CaretRow,0,0x006000);
			nOldRow = axGT������.CaretRow;
			tex���Ӑ�R�[�h.Text     = axGT������.get_CelText(axGT������.CaretRow,1);
			tex���Ӑ敔�ۃR�[�h.Text = axGT������.get_CelText(axGT������.CaretRow,2);
			tex���Ӑ敔�ۖ�.Text     = axGT������.get_CelText(axGT������.CaretRow,3);
			s�X�V����                = axGT������.get_CelText(axGT������.CaretRow,4);
		}

// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� START
		private void ������o�^_Closed(object sender, System.EventArgs e)
		{
			axGT������.CaretRow = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� START
			axGT������.CaretCol = 1;
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� END
			axGT������_CurPlaceChanged(null,null);
			axGT������.Focus();
		}
// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� END

	}
}
