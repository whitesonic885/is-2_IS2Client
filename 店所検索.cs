using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [�X������]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// ADD 2014.09.01 BEVAS) �O�c �x�X�~�ߋ@�\�Ή��̂��ߓX��������ʂ�ǉ�
	//--------------------------------------------------------------------------
	public class �X������ : ���ʃt�H�[��
	{
		public short nOldRow = 0;
		public string s�X���R�[�h;
		public string s�X����;
		public string s�X��������;
		public string s�X�֔ԍ�;

		private string[] s�X���ꗗ;
		private int i���ݕŐ�;
		private int i�ő�Ő�;
		private int i�J�n��;
		private int i�I����;
		private int i�A�N�e�B�u�e�f = 0;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Button btn�m��;
		private ���ʃe�L�X�g�{�b�N�X tex���b�Z�[�W;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Button btn����;
		private AxGTABLE32V2Lib.AxGTable32 axGT�X��;
		private System.Windows.Forms.Label lab�X���^�C�g��;
		private ���ʃe�L�X�g�{�b�N�X tex�X���R�[�h;
		private System.Windows.Forms.Label lab�X���R�[�h;
		private System.Windows.Forms.Label lab�X����;
		private ���ʃe�L�X�g�{�b�N�X tex�X����;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lab�Ŕԍ�;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Button btn�O��;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmb�n��;
		private System.Windows.Forms.ComboBox cmb�s���{��;

		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		public �X������()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			�c�o�h�\���T�C�Y�ϊ�();
			this.axGT�X��.Size = new System.Drawing.Size(422, 292);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(�X������));
            this.panel1 = new System.Windows.Forms.Panel();
            this.axGT�X�� = new AxGTABLE32V2Lib.AxGTable32();
            this.lab�Ŕԍ� = new System.Windows.Forms.Label();
            this.btn���� = new System.Windows.Forms.Button();
            this.btn�O�� = new System.Windows.Forms.Button();
            this.btn�m�� = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lab�X���^�C�g�� = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tex���b�Z�[�W = new IS2Client.���ʃe�L�X�g�{�b�N�X();
            this.btn���� = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb�s���{�� = new System.Windows.Forms.ComboBox();
            this.cmb�n�� = new System.Windows.Forms.ComboBox();
            this.tex�X���R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
            this.lab�X���R�[�h = new System.Windows.Forms.Label();
            this.lab�X���� = new System.Windows.Forms.Label();
            this.tex�X���� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
            this.btn���� = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ds�����)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGT�X��)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Honeydew;
            this.panel1.Controls.Add(this.axGT�X��);
            this.panel1.Controls.Add(this.lab�Ŕԍ�);
            this.panel1.Controls.Add(this.btn����);
            this.panel1.Controls.Add(this.btn�O��);
            this.panel1.Controls.Add(this.btn�m��);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 352);
            this.panel1.TabIndex = 1;
            // 
            // axGT�X��
            // 
            this.axGT�X��.DataSource = null;
            this.axGT�X��.Location = new System.Drawing.Point(50, 25);
            this.axGT�X��.Name = "axGT�X��";
            this.axGT�X��.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT�X��.OcxState")));
            this.axGT�X��.Size = new System.Drawing.Size(267, 289);
            this.axGT�X��.TabIndex = 12;
            this.axGT�X��.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT�X��_CurPlaceChanged);
            this.axGT�X��.CelDblClick += new AxGTABLE32V2Lib._DGTable32Events_CelDblClickEventHandler(this.axGT�X��_CelDblClick);
            this.axGT�X��.KeyDownEvent += new AxGTABLE32V2Lib._DGTable32Events_KeyDownEventHandler(this.axGT�X��_KeyDownEvent);
            // 
            // lab�Ŕԍ�
            // 
            this.lab�Ŕԍ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab�Ŕԍ�.ForeColor = System.Drawing.Color.Green;
            this.lab�Ŕԍ�.Location = new System.Drawing.Point(194, 326);
            this.lab�Ŕԍ�.Name = "lab�Ŕԍ�";
            this.lab�Ŕԍ�.Size = new System.Drawing.Size(44, 20);
            this.lab�Ŕԍ�.TabIndex = 73;
            this.lab�Ŕԍ�.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn����
            // 
            this.btn����.BackColor = System.Drawing.Color.SteelBlue;
            this.btn����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn����.ForeColor = System.Drawing.Color.White;
            this.btn����.Location = new System.Drawing.Point(240, 324);
            this.btn����.Name = "btn����";
            this.btn����.Size = new System.Drawing.Size(48, 22);
            this.btn����.TabIndex = 9;
            this.btn����.TabStop = false;
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
            this.btn�O��.Location = new System.Drawing.Point(144, 324);
            this.btn�O��.Name = "btn�O��";
            this.btn�O��.Size = new System.Drawing.Size(48, 22);
            this.btn�O��.TabIndex = 8;
            this.btn�O��.TabStop = false;
            this.btn�O��.Text = "�O��";
            this.btn�O��.UseVisualStyleBackColor = false;
            this.btn�O��.Click += new System.EventHandler(this.btn�O��_Click);
            // 
            // btn�m��
            // 
            this.btn�m��.BackColor = System.Drawing.Color.Blue;
            this.btn�m��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn�m��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn�m��.ForeColor = System.Drawing.Color.White;
            this.btn�m��.Location = new System.Drawing.Point(302, 324);
            this.btn�m��.Name = "btn�m��";
            this.btn�m��.Size = new System.Drawing.Size(64, 22);
            this.btn�m��.TabIndex = 10;
            this.btn�m��.Text = "�m��";
            this.btn�m��.UseVisualStyleBackColor = false;
            this.btn�m��.Click += new System.EventHandler(this.btn�m��_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.panel7.Controls.Add(this.lab�X���^�C�g��);
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(394, 26);
            this.panel7.TabIndex = 13;
            // 
            // lab�X���^�C�g��
            // 
            this.lab�X���^�C�g��.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab�X���^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab�X���^�C�g��.ForeColor = System.Drawing.Color.White;
            this.lab�X���^�C�g��.Location = new System.Drawing.Point(12, 2);
            this.lab�X���^�C�g��.Name = "lab�X���^�C�g��";
            this.lab�X���^�C�g��.Size = new System.Drawing.Size(264, 24);
            this.lab�X���^�C�g��.TabIndex = 0;
            this.lab�X���^�C�g��.Text = "�x�X�~�ߑΉ��X������";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.PaleGreen;
            this.panel8.Controls.Add(this.tex���b�Z�[�W);
            this.panel8.Controls.Add(this.btn����);
            this.panel8.Location = new System.Drawing.Point(0, 516);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(474, 58);
            this.panel8.TabIndex = 2;
            // 
            // tex���b�Z�[�W
            // 
            this.tex���b�Z�[�W.BackColor = System.Drawing.Color.PaleGreen;
            this.tex���b�Z�[�W.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex���b�Z�[�W.ForeColor = System.Drawing.Color.Red;
            this.tex���b�Z�[�W.Location = new System.Drawing.Point(68, 4);
            this.tex���b�Z�[�W.Multiline = true;
            this.tex���b�Z�[�W.Name = "tex���b�Z�[�W";
            this.tex���b�Z�[�W.ReadOnly = true;
            this.tex���b�Z�[�W.Size = new System.Drawing.Size(314, 50);
            this.tex���b�Z�[�W.TabIndex = 7;
            this.tex���b�Z�[�W.TabStop = false;
            // 
            // btn����
            // 
            this.btn����.ForeColor = System.Drawing.Color.Red;
            this.btn����.Location = new System.Drawing.Point(8, 6);
            this.btn����.Name = "btn����";
            this.btn����.Size = new System.Drawing.Size(54, 48);
            this.btn����.TabIndex = 11;
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
            this.panel6.Size = new System.Drawing.Size(394, 26);
            this.panel6.TabIndex = 15;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Honeydew;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.cmb�s���{��);
            this.panel5.Controls.Add(this.cmb�n��);
            this.panel5.Controls.Add(this.tex�X���R�[�h);
            this.panel5.Controls.Add(this.lab�X���R�[�h);
            this.panel5.Controls.Add(this.lab�X����);
            this.panel5.Controls.Add(this.tex�X����);
            this.panel5.Controls.Add(this.btn����);
            this.panel5.Location = new System.Drawing.Point(1, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(374, 94);
            this.panel5.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(4, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 50;
            this.label1.Text = "�s���{��";
            // 
            // cmb�s���{��
            // 
            this.cmb�s���{��.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb�s���{��.Enabled = false;
            this.cmb�s���{��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb�s���{��.ForeColor = System.Drawing.Color.LimeGreen;
            this.cmb�s���{��.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmb�s���{��.Items.AddRange(new object[] {
            "���I��"});
            this.cmb�s���{��.Location = new System.Drawing.Point(222, 62);
            this.cmb�s���{��.Name = "cmb�s���{��";
            this.cmb�s���{��.Size = new System.Drawing.Size(138, 24);
            this.cmb�s���{��.TabIndex = 7;
            // 
            // cmb�n��
            // 
            this.cmb�n��.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb�n��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb�n��.ForeColor = System.Drawing.Color.LimeGreen;
            this.cmb�n��.Items.AddRange(new object[] {
            "�n�斢�I��",
            "���k�E�k�C��",
            "�֓�",
            "�b�M�z�E�k��",
            "���C",
            "�֐�",
            "����",
            "�l��",
            "��B�E����"});
            this.cmb�n��.Location = new System.Drawing.Point(82, 62);
            this.cmb�n��.Name = "cmb�n��";
            this.cmb�n��.Size = new System.Drawing.Size(128, 24);
            this.cmb�n��.TabIndex = 6;
            this.cmb�n��.SelectedIndexChanged += new System.EventHandler(this.cmb�n��_SelectedIndexChanged);
            // 
            // tex�X���R�[�h
            // 
            this.tex�X���R�[�h.BackColor = System.Drawing.SystemColors.Window;
            this.tex�X���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex�X���R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tex�X���R�[�h.Location = new System.Drawing.Point(82, 6);
            this.tex�X���R�[�h.MaxLength = 4;
            this.tex�X���R�[�h.Name = "tex�X���R�[�h";
            this.tex�X���R�[�h.Size = new System.Drawing.Size(44, 23);
            this.tex�X���R�[�h.TabIndex = 1;
            // 
            // lab�X���R�[�h
            // 
            this.lab�X���R�[�h.BackColor = System.Drawing.Color.Honeydew;
            this.lab�X���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab�X���R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab�X���R�[�h.Location = new System.Drawing.Point(8, 10);
            this.lab�X���R�[�h.Name = "lab�X���R�[�h";
            this.lab�X���R�[�h.Size = new System.Drawing.Size(58, 16);
            this.lab�X���R�[�h.TabIndex = 46;
            this.lab�X���R�[�h.Text = "�R�[�h";
            // 
            // lab�X����
            // 
            this.lab�X����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab�X����.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab�X����.Location = new System.Drawing.Point(8, 34);
            this.lab�X����.Name = "lab�X����";
            this.lab�X����.Size = new System.Drawing.Size(58, 16);
            this.lab�X����.TabIndex = 6;
            this.lab�X����.Text = "�X����";
            // 
            // tex�X����
            // 
            this.tex�X����.BackColor = System.Drawing.SystemColors.Window;
            this.tex�X����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex�X����.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tex�X����.Location = new System.Drawing.Point(82, 34);
            this.tex�X����.MaxLength = 4;
            this.tex�X����.Name = "tex�X����";
            this.tex�X����.Size = new System.Drawing.Size(74, 23);
            this.tex�X����.TabIndex = 2;
            this.tex�X����.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�X����_KeyDown);
            // 
            // btn����
            // 
            this.btn����.BackColor = System.Drawing.Color.SteelBlue;
            this.btn����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn����.ForeColor = System.Drawing.Color.White;
            this.btn����.Location = new System.Drawing.Point(292, 32);
            this.btn����.Name = "btn����";
            this.btn����.Size = new System.Drawing.Size(64, 22);
            this.btn����.TabIndex = 3;
            this.btn����.TabStop = false;
            this.btn����.Text = "����";
            this.btn����.UseVisualStyleBackColor = false;
            this.btn����.Click += new System.EventHandler(this.btn����_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Location = new System.Drawing.Point(7, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(8, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 355);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // �X������
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(388, 582);
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
            this.MinimumSize = new System.Drawing.Size(394, 607);
            this.Name = "�X������";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "is-2 �X������";
            this.Activated += new System.EventHandler(this.�X������_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.On�G���^�[�ړ�);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.On�G���^�[�L�����Z��);
            ((System.ComponentModel.ISupportInitialize)(this.ds�����)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axGT�X��)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
			i�A�N�e�B�u�e�f = 0;
			tex�X���R�[�h.Text = s�X���R�[�h;
			tex�X����.Text = s�X����;
			
			axGT�X��.Cols = 4;
			axGT�X��.Rows = 15;
			axGT�X��.ColSep = "|";
			axGT�X��.CaretRow = 1;
			axGT�X��.NoBeep = true;
			axGT�X��.set_RowsText(0, "|�R�[�h|�X����|�X��������|�X�֔ԍ�|");
			axGT�X��.ColsWidth = "0|8.0|12.5|0|0|";
			axGT�X��.ColsAlignHorz = "0|1|0|0|0|";
			axGT�X��.set_CelForeColor(axGT�X��.CaretRow,0,0x98FB98);  //BGR
			axGT�X��.set_CelBackColor(axGT�X��.CaretRow,0,0x006000);

			btn�O��.Enabled = false;
			btn����.Enabled = false;
			lab�Ŕԍ�.Text = "";
			i���ݕŐ� = 1;

			// �n��E�s���{�����N���A
			cmb�n��.SelectedIndex = 0;
			cmb�n��.ResetText();	
			cmb�n��.Enabled = true;
			cmb�n��.Visible = true;

			// �n��R���{���N���b�N�����̂��A������悤�ɂ���
			cmb�s���{��.Items.Clear();
			cmb�s���{��.Items.Add("���I��");
			cmb�s���{��.SelectedIndex = 0;
			cmb�s���{��.ResetText();
			cmb�s���{��.Visible = true;
			cmb�s���{��.Enabled = false; 
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			s�X���R�[�h = "";
			s�X���� = "";
			s�X�������� = "";
			s�X�֔ԍ� = "";
			this.Close();
		}

		private void axGT�X��_CelDblClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelDblClickEvent e)
		{
			s�X���R�[�h = axGT�X��.get_CelText(axGT�X��.CaretRow,1);
			s�X���� = axGT�X��.get_CelText(axGT�X��.CaretRow,2);
			s�X�������� = axGT�X��.get_CelText(axGT�X��.CaretRow,3);
			s�X�֔ԍ� = axGT�X��.get_CelText(axGT�X��.CaretRow,4);
			if(s�X���R�[�h != "")
				this.Close();
		}

		private void axGT�X��_CurPlaceChanged(object sender, AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEvent e)
		{
			axGT�X��.set_CelForeColor(nOldRow,0,0);
			axGT�X��.set_CelBackColor(nOldRow,0,0xFFFFFF);
			axGT�X��.set_CelForeColor(axGT�X��.CaretRow,0,0x98FB98);  //BGR
			axGT�X��.set_CelBackColor(axGT�X��.CaretRow,0,0x006000);
			nOldRow = axGT�X��.CaretRow;
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			�X���ꗗ����();		
		}

		private void btn�m��_Click(object sender, System.EventArgs e)
		{
			s�X���R�[�h = axGT�X��.get_CelText(axGT�X��.CaretRow,1);
			s�X���� = axGT�X��.get_CelText(axGT�X��.CaretRow,2);
			s�X�������� = axGT�X��.get_CelText(axGT�X��.CaretRow,3);
			s�X�֔ԍ� = axGT�X��.get_CelText(axGT�X��.CaretRow,4);
			if(s�X���R�[�h != "")
				this.Close();
		}

		private void �X���ꗗ����()
		{
			i�A�N�e�B�u�e�f = 1;
			axGT�X��.Clear();
			tex�X���R�[�h.Text = tex�X���R�[�h.Text.Trim();
			tex�X����.Text = tex�X����.Text.Trim();
			if(!���p�`�F�b�N(tex�X���R�[�h, "�R�[�h")) return;
			if(!�S�p�`�F�b�N(tex�X����, "�X����")) return;

			tex���b�Z�[�W.Text = "�������D�D�D";

			// �ȉ��̏ꍇ�́A�ʏ팟��
			// *****�X���R�[�h�^�X�����ɓ��͂���*****
			// *****�������(���������ύX�Ȃ�)*****
			if((tex�X���R�[�h.Text.Length > 0 || tex�X����.Text.Length > 0) ||
				(tex�X���R�[�h.Text.Length == 0 && tex�X����.Text.Length == 0 && cmb�s���{��.Text.Equals("���I��")))
			{
				// �n��E�s���{�����N���A
				cmb�n��.SelectedIndex = 0;
				cmb�n��.ResetText();
				cmb�s���{��.Text = "";
				cmb�s���{��.Enabled = false;

				s�X���ꗗ = new string[1];
				// �J�[�\���������v�ɂ���
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				try
				{
					string[] sKey  = new string[3];
					sKey[0] = tex�X���R�[�h.Text;
					sKey[1] = tex�X����.Text;
					if(gs����b�c.Substring(0,1) != "J")
					{
						sKey[2] = "1"; // ���R�ʉ^�̓X���~��
					}
					else
					{
						sKey[2] = "2"; // ���q�^���̓X���~��
					}

					// �x�X�~�ߑΉ��̓X���ꗗ�̎擾
					s�X���ꗗ = sv_print.Get_DeliShop(gsa���[�U, sKey);
				}
				catch (System.Net.WebException)
				{
					s�X���ꗗ[0] = gs�ʐM�G���[;
				}
				catch (Exception ex)
				{
					s�X���ꗗ[0] = "�ʐM�G���[�F" + ex.Message;
				}
				// �J�[�\�����f�t�H���g�ɖ߂�
				Cursor = System.Windows.Forms.Cursors.Default;

				if (s�X���ꗗ[0].Equals("����I��"))
				{
					tex���b�Z�[�W.Text = "";
					i�ő�Ő� = (s�X���ꗗ.Length - 2) / (axGT�X��.Rows - 1) + 1;
					if (i���ݕŐ� > i�ő�Ő�)
						i���ݕŐ� = i�ő�Ő�;
					�ŏ��ݒ�();

					axGT�X��.CaretRow = 1;
					axGT�X��_CurPlaceChanged(null,null);

					axGT�X��.Focus();
				}
				else
				{
					axGT�X��.CaretRow = 1;
					axGT�X��_CurPlaceChanged(null,null);
					if (s�X���ꗗ[0].Equals("�Y���f�[�^������܂���"))
					{
						tex���b�Z�[�W.Text = "";
						MessageBox.Show("�Y���f�[�^������܂���","�X������",MessageBoxButtons.OK);
					}
					else
					{
						tex���b�Z�[�W.Text = s�X���ꗗ[0];
						axGT�X��.Clear();
						i���ݕŐ� = 1;
						btn�O��.Enabled = false;
						btn����.Enabled = false;
						lab�Ŕԍ�.Text = "";
						�r�[�v��();
					}
					tex�X���R�[�h.Focus();
				}
			}
			// �n��^�s���{���݂̂��I����Ԃ̏ꍇ
			else if(!cmb�s���{��.Text.Equals("���I��"))
			{
				string s���� = string.Empty;
				s���� = cmb�s���{��.Text.Trim();
				���ʓX������(s����);
			}
		}

		private void axGT�X��_KeyDownEvent(object sender, AxGTABLE32V2Lib._DGTable32Events_KeyDownEvent e)
		{
			if (e.keyCode == 0x0d)
			{
				s�X���R�[�h = axGT�X��.get_CelText(axGT�X��.CaretRow,1);
				s�X���� = axGT�X��.get_CelText(axGT�X��.CaretRow,2);
				s�X�������� = axGT�X��.get_CelText(axGT�X��.CaretRow,3);
				s�X�֔ԍ� = axGT�X��.get_CelText(axGT�X��.CaretRow,4);
				if(s�X���R�[�h != "")
					this.Close();
			}
			if (e.keyCode == 0x09)
			{
				this.SelectNextControl(axGT�X��, true, true, true, true);
			}
		}

		private void tex�X����_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				�X���ꗗ����();
			}		
		}

		private void btn�O��_Click(object sender, System.EventArgs e)
		{
			i���ݕŐ�--;
			�ŏ��ݒ�();
			axGT�X��.CaretRow = 1;
			axGT�X��_CurPlaceChanged(null,null);
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			i���ݕŐ�++;
			�ŏ��ݒ�();
			axGT�X��.CaretRow = 1;
			axGT�X��_CurPlaceChanged(null,null);
		}

		private void �ŏ��ݒ�()
		{
			axGT�X��.Clear();

			i�J�n�� = (i���ݕŐ� - 1) * (axGT�X��.Rows - 1) + 1;
			i�I���� = i���ݕŐ� * (axGT�X��.Rows - 1);

			short s�\���� = (short)2;
			for(short sCnt = (short)i�J�n��; sCnt < s�X���ꗗ.Length && sCnt <= i�I���� ; sCnt++)
			{
				axGT�X��.set_RowsText(s�\����, s�X���ꗗ[sCnt]);
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
			axGT�X��.Focus();
		}

		private void �X������_Activated(object sender, System.EventArgs e)
		{
			if(i�A�N�e�B�u�e�f == 0)
				�X���ꗗ����();
		}

		private void cmb�n��_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ComboBox cmb = (ComboBox) sender;
			if (cmb.SelectedIndex > 0) 
			{
				cmb�s���{��.Items.Clear();
				cmb�s���{��.BeginUpdate();
				foreach (string sPref in jag�s���{��[cmb.SelectedIndex])
				{
					cmb�s���{��.Items.Add(sPref);
				}
				cmb�s���{��.EndUpdate();
				cmb�s���{��.SelectedIndex = 0;
				cmb�s���{��.Enabled = true;
				cmb�s���{��.ResetText();
				cmb�s���{��.Focus();
			}
			cmb�s���{��.Refresh();
		}

		private void ���ʓX������(string s����) 
		{
			tex���b�Z�[�W.Text = "�������D�D�D";

			s�X���ꗗ = new string[1];
			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try {
				string[] sKey  = new string[2];
				sKey[0] = s����;
				if(gs����b�c.Substring(0,1) != "J")
				{
					sKey[1] = "1"; // ���R�ʉ^�̎x�X�~�ߑΉ�
				}
				else
				{
					sKey[1] = "2"; // ���q�^���̎x�X�~�ߑΉ�
				}

				// ���ʂ̎x�X�~�ߑΉ��̓X���ꗗ�̎擾
				s�X���ꗗ = sv_print.Get_PrefDeliShop(gsa���[�U, sKey);
			}
			catch (System.Net.WebException) {
				s�X���ꗗ[0] = gs�ʐM�G���[;
			}
			catch (Exception ex)
			{
				s�X���ꗗ[0] = "�ʐM�G���[�F" + ex.Message;
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;

			if (s�X���ꗗ[0].Equals("����I��"))
			{
				tex���b�Z�[�W.Text = "";
				i�ő�Ő� = (s�X���ꗗ.Length - 2) / (axGT�X��.Rows - 1) + 1;
				if (i���ݕŐ� > i�ő�Ő�)
					i���ݕŐ� = i�ő�Ő�;
				�ŏ��ݒ�();

				axGT�X��.CaretRow = 1;
				axGT�X��_CurPlaceChanged(null,null);

				axGT�X��.Focus();
			}
			else
			{
				axGT�X��.CaretRow = 1;
				axGT�X��_CurPlaceChanged(null,null);
				if (s�X���ꗗ[0].Equals("�Y���f�[�^������܂���"))
				{
					tex���b�Z�[�W.Text = "";
					MessageBox.Show("�Y���f�[�^������܂���","�X������",MessageBoxButtons.OK);
				}
				else
				{
					tex���b�Z�[�W.Text = s�X���ꗗ[0];
					axGT�X��.Clear();
					i���ݕŐ� = 1;
					btn�O��.Enabled = false;
					btn����.Enabled = false;
					lab�Ŕԍ�.Text = "";
					�r�[�v��();
				}
				tex�X���R�[�h.Focus();
			}
		}

		private string[][] jag�s���{��
			= { new string[] {"���I��"},
				new string[] {"�k�C��","�X��","��茧","�{�錧","�H�c��","�R�`��","������"},
			    new string[] {"��錧","�Ȗ،�","�Q�n��","��ʌ�","��t��","�����s","�_�ސ쌧"},
			    new string[] {"�V����","�R����","���쌧","�x�R��","�ΐ쌧","���䌧"},
				new string[] {"�򕌌�","�É���","���m��","�O�d��"},
				new string[] {"���ꌧ","���s�{","���{","���Ɍ�","�ޗǌ�","�a�̎R��"},
			    new string[] {"���挧","������","���R��","�L����","�R����"},
			    new string[] {"������","���쌧","���Q��","���m��"},
			    new string[] {"������","���ꌧ","���茧","�F�{��","�啪��","�{�茧","��������","���ꌧ"}};

	}
}
