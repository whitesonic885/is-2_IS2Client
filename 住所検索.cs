using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [�Z������]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// ADD 2010.12.14 ACT�j�_�� ���q�^���Ή� 
	//--------------------------------------------------------------------------
	public class �Z������ : ���ʃt�H�[��
	{
		public short OldRow = 0;
		public string s�X�֔ԍ��P = "";
		public string s�X�֔ԍ��Q = "";
		public string s�Z��       = "";
		public string s�Z���b�c   = "";
		private string s�s���{���b�c = "";
		private string s�s�撬���b�c = "";

		private string[] s�Z���ꗗ;
		private int      i���ݕŐ�;
		private int      i�ő�Ő�;
		private int      i�J�n��;
		private int      i�I����;
		private int      i�A�N�e�B�u�e�f = 0;
// MOD 2005.06.15 ���s�j�����J �s���{���I���̕ύX START
		private int      i�s���{���b�c�����l = 0;
// MOD 2005.06.15 ���s�j�����J �s���{���I���̕ύX END
// ADD 2006.12.14 ���s�j�����J ���ׂ̗]�������� START
		private int      i�ōő�s�� = 100;
// ADD 2006.12.14 ���s�j�����J ���ׂ̗]�������� END

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lab�X�֔ԍ�;
		private System.Windows.Forms.Label lab�s���{��;
		private System.Windows.Forms.Label lab�Z�������^�C�g��;
		private System.Windows.Forms.Button btn�m��;
		private System.Windows.Forms.ComboBox cmb�s���{��;
		private ���ʃe�L�X�g�{�b�N�X tex�X�֔ԍ��Q;
		private ���ʃe�L�X�g�{�b�N�X tex�X�֔ԍ��P;
		private System.Windows.Forms.TextBox tex���b�Z�[�W;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Button btn����;
		private AxGTABLE32V2Lib.AxGTable32 axGT�Z��;
		private System.Windows.Forms.Label lab�Z��;
		private System.Windows.Forms.Label lab�Ŕԍ�;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Button btn�O��;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		public �Z������()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
			�c�o�h�\���T�C�Y�ϊ�();
//			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
				this.axGT�Z��.Size = new System.Drawing.Size(422, 292);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(�Z������));
			this.panel1 = new System.Windows.Forms.Panel();
			this.lab�Ŕԍ� = new System.Windows.Forms.Label();
			this.btn���� = new System.Windows.Forms.Button();
			this.btn�O�� = new System.Windows.Forms.Button();
			this.lab�Z�� = new System.Windows.Forms.Label();
			this.axGT�Z�� = new AxGTABLE32V2Lib.AxGTable32();
			this.btn�m�� = new System.Windows.Forms.Button();
			this.panel5 = new System.Windows.Forms.Panel();
			this.cmb�s���{�� = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tex�X�֔ԍ��Q = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�X�֔ԍ��P = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab�X�֔ԍ� = new System.Windows.Forms.Label();
			this.lab�s���{�� = new System.Windows.Forms.Label();
			this.btn���� = new System.Windows.Forms.Button();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab�Z�������^�C�g�� = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.tex���b�Z�[�W = new System.Windows.Forms.TextBox();
			this.btn���� = new System.Windows.Forms.Button();
			this.panel6 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axGT�Z��)).BeginInit();
			this.panel5.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Honeydew;
			this.panel1.Controls.Add(this.lab�Ŕԍ�);
			this.panel1.Controls.Add(this.btn����);
			this.panel1.Controls.Add(this.btn�O��);
			this.panel1.Controls.Add(this.lab�Z��);
			this.panel1.Controls.Add(this.axGT�Z��);
			this.panel1.Controls.Add(this.btn�m��);
			this.panel1.Location = new System.Drawing.Point(1, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(445, 380);
			this.panel1.TabIndex = 1;
			// 
			// lab�Ŕԍ�
			// 
			this.lab�Ŕԍ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�Ŕԍ�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�Ŕԍ�.Location = new System.Drawing.Point(312, 334);
			this.lab�Ŕԍ�.Name = "lab�Ŕԍ�";
			this.lab�Ŕԍ�.Size = new System.Drawing.Size(56, 14);
			this.lab�Ŕԍ�.TabIndex = 70;
			this.lab�Ŕԍ�.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn����
			// 
			this.btn����.BackColor = System.Drawing.Color.SteelBlue;
			this.btn����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn����.ForeColor = System.Drawing.Color.White;
			this.btn����.Location = new System.Drawing.Point(370, 330);
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
			this.btn�O��.Location = new System.Drawing.Point(262, 330);
			this.btn�O��.Name = "btn�O��";
			this.btn�O��.Size = new System.Drawing.Size(48, 22);
			this.btn�O��.TabIndex = 68;
			this.btn�O��.Text = "�O��";
			this.btn�O��.Click += new System.EventHandler(this.btn�O��_Click);
			// 
			// lab�Z��
			// 
			this.lab�Z��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold);
			this.lab�Z��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�Z��.Location = new System.Drawing.Point(16, 6);
			this.lab�Z��.Name = "lab�Z��";
			this.lab�Z��.Size = new System.Drawing.Size(314, 20);
			this.lab�Z��.TabIndex = 4;
			// 
			// axGT�Z��
			// 
			this.axGT�Z��.ContainingControl = this;
			this.axGT�Z��.DataSource = null;
			this.axGT�Z��.Location = new System.Drawing.Point(12, 32);
			this.axGT�Z��.Name = "axGT�Z��";
			this.axGT�Z��.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT�Z��.OcxState")));
			this.axGT�Z��.Size = new System.Drawing.Size(422, 292);
			this.axGT�Z��.TabIndex = 3;
			this.axGT�Z��.KeyDownEvent += new AxGTABLE32V2Lib._DGTable32Events_KeyDownEventHandler(this.axGT�Z��_KeyDownEvent);
			this.axGT�Z��.CelDblClick += new AxGTABLE32V2Lib._DGTable32Events_CelDblClickEventHandler(this.axGT�Z��_CelDblClick);
			this.axGT�Z��.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT�Z��_CurPlaceChanged);
			// 
			// btn�m��
			// 
			this.btn�m��.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�m��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�m��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�m��.ForeColor = System.Drawing.Color.White;
			this.btn�m��.Location = new System.Drawing.Point(370, 354);
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
			this.panel5.Controls.Add(this.cmb�s���{��);
			this.panel5.Controls.Add(this.label2);
			this.panel5.Controls.Add(this.tex�X�֔ԍ��Q);
			this.panel5.Controls.Add(this.tex�X�֔ԍ��P);
			this.panel5.Controls.Add(this.lab�X�֔ԍ�);
			this.panel5.Controls.Add(this.lab�s���{��);
			this.panel5.Controls.Add(this.btn����);
			this.panel5.Location = new System.Drawing.Point(1, 6);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(445, 60);
			this.panel5.TabIndex = 0;
			// 
			// cmb�s���{��
			// 
			this.cmb�s���{��.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb�s���{��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cmb�s���{��.Location = new System.Drawing.Point(94, 34);
			this.cmb�s���{��.MaxDropDownItems = 25;
			this.cmb�s���{��.Name = "cmb�s���{��";
			this.cmb�s���{��.Size = new System.Drawing.Size(102, 24);
			this.cmb�s���{��.TabIndex = 2;
			this.cmb�s���{��.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb�s���{��_KeyDown);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label2.ForeColor = System.Drawing.Color.LimeGreen;
			this.label2.Location = new System.Drawing.Point(132, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(14, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "-";
			// 
			// tex�X�֔ԍ��Q
			// 
			this.tex�X�֔ԍ��Q.BackColor = System.Drawing.SystemColors.Window;
			this.tex�X�֔ԍ��Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�X�֔ԍ��Q.Location = new System.Drawing.Point(148, 8);
			this.tex�X�֔ԍ��Q.MaxLength = 4;
			this.tex�X�֔ԍ��Q.Name = "tex�X�֔ԍ��Q";
			this.tex�X�֔ԍ��Q.Size = new System.Drawing.Size(44, 23);
			this.tex�X�֔ԍ��Q.TabIndex = 1;
			this.tex�X�֔ԍ��Q.Text = "";
			this.tex�X�֔ԍ��Q.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�X�֔ԍ��Q_KeyDown);
			// 
			// tex�X�֔ԍ��P
			// 
			this.tex�X�֔ԍ��P.BackColor = System.Drawing.SystemColors.Window;
			this.tex�X�֔ԍ��P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�X�֔ԍ��P.Location = new System.Drawing.Point(94, 8);
			this.tex�X�֔ԍ��P.MaxLength = 3;
			this.tex�X�֔ԍ��P.Name = "tex�X�֔ԍ��P";
			this.tex�X�֔ԍ��P.Size = new System.Drawing.Size(36, 23);
			this.tex�X�֔ԍ��P.TabIndex = 0;
			this.tex�X�֔ԍ��P.Text = "";
			// 
			// lab�X�֔ԍ�
			// 
			this.lab�X�֔ԍ�.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�X�֔ԍ�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�X�֔ԍ�.Location = new System.Drawing.Point(14, 10);
			this.lab�X�֔ԍ�.Name = "lab�X�֔ԍ�";
			this.lab�X�֔ԍ�.Size = new System.Drawing.Size(76, 16);
			this.lab�X�֔ԍ�.TabIndex = 46;
			this.lab�X�֔ԍ�.Text = "�X�֔ԍ�";
			// 
			// lab�s���{��
			// 
			this.lab�s���{��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�s���{��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�s���{��.Location = new System.Drawing.Point(14, 36);
			this.lab�s���{��.Name = "lab�s���{��";
			this.lab�s���{��.Size = new System.Drawing.Size(76, 16);
			this.lab�s���{��.TabIndex = 6;
			this.lab�s���{��.Text = "�s���{��";
			// 
			// btn����
			// 
			this.btn����.BackColor = System.Drawing.Color.SteelBlue;
			this.btn����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn����.ForeColor = System.Drawing.Color.White;
			this.btn����.Location = new System.Drawing.Point(206, 34);
			this.btn����.Name = "btn����";
			this.btn����.Size = new System.Drawing.Size(64, 22);
			this.btn����.TabIndex = 3;
			this.btn����.TabStop = false;
			this.btn����.Text = "����";
			this.btn����.Click += new System.EventHandler(this.btn����_Click);
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.lab�Z�������^�C�g��);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(470, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab�Z�������^�C�g��
			// 
			this.lab�Z�������^�C�g��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�Z�������^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�Z�������^�C�g��.ForeColor = System.Drawing.Color.White;
			this.lab�Z�������^�C�g��.Location = new System.Drawing.Point(12, 2);
			this.lab�Z�������^�C�g��.Name = "lab�Z�������^�C�g��";
			this.lab�Z�������^�C�g��.Size = new System.Drawing.Size(264, 24);
			this.lab�Z�������^�C�g��.TabIndex = 0;
			this.lab�Z�������^�C�g��.Text = "�Z������";
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
			this.tex���b�Z�[�W.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���b�Z�[�W.ForeColor = System.Drawing.Color.Red;
			this.tex���b�Z�[�W.Location = new System.Drawing.Point(66, 4);
			this.tex���b�Z�[�W.Multiline = true;
			this.tex���b�Z�[�W.Name = "tex���b�Z�[�W";
			this.tex���b�Z�[�W.ReadOnly = true;
			this.tex���b�Z�[�W.Size = new System.Drawing.Size(390, 50);
			this.tex���b�Z�[�W.TabIndex = 0;
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
			this.panel6.Size = new System.Drawing.Size(470, 26);
			this.panel6.TabIndex = 15;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel5);
			this.groupBox1.Location = new System.Drawing.Point(8, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(450, 68);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel1);
			this.groupBox2.Location = new System.Drawing.Point(8, 122);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(450, 388);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// �Z������
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(464, 574);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(470, 607);
			this.Name = "�Z������";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 �Z������";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Closed += new System.EventHandler(this.�Z������_Closed);
			this.Activated += new System.EventHandler(this.�Z������_Activated);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axGT�Z��)).EndInit();
			this.panel5.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
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
			// �X�֔ԍ��̐ݒ�
			tex�X�֔ԍ��P.Text = s�X�֔ԍ��P;
			tex�X�֔ԍ��Q.Text = s�X�֔ԍ��Q;

			s�Z���b�c = "";

			// �����̏����ݒ�
			cmb�s���{��.Items.Clear();
// MOD 2005.06.07 ���s�j���� �s���{���I���̕ύX START
//			cmb�s���{��.Items.AddRange(gsa����);
//			cmb�s���{��.SelectedIndex = 0;
			if(gi�s���{���b�c == 0)
			{
				cmb�s���{��.Items.AddRange(gsa����);
			}
			else
			{
				for(int iIdx = 1;iIdx < gsa����.Length; iIdx++)
				{
					if(iIdx == gi�s���{���b�c)
						cmb�s���{��.Items.Add("");
					cmb�s���{��.Items.Add(gsa����[iIdx]);
				}
			}
			cmb�s���{��.Text = "";
// MOD 2005.06.07 ���s�j���� �s���{���I���̕ύX END
// MOD 2005.06.15 ���s�j�����J �s���{���I���̕ύX START
			i�s���{���b�c�����l = gi�s���{���b�c;
// MOD 2005.06.15 ���s�j�����J �s���{���I���̕ύX END
// MOD 2009.07.08 �p�\�j���� �\�����ڂ̒ǉ��i�厚�ʏ̃J�i�E�Z���b�c�E�X���b�c�j START
//			axGT�Z��.Cols = 3;
			axGT�Z��.Cols = 6;
// MOD 2009.07.08 �p�\�j���� �\�����ڂ̒ǉ��i�厚�ʏ̃J�i�E�Z���b�c�E�X���b�c�j END
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� START
// MOD 2006.07.05 ���s�j�R�{ �P�y�[�W�\���s���̕ύX�i�X�N���[���j�Ή� START
////		axGT�Z��.Rows = 15;
//			axGT�Z��.Rows = 100;
// MOD 2006.07.05 ���s�j�R�{ �P�y�[�W�\���s���̕ύX�i�X�N���[���j�Ή� END
			axGT�Z��.Rows = 15;
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� END
			axGT�Z��.ColSep = "|";

// MOD 2009.07.08 �p�\�j���� �\�����ڂ̒ǉ��i�厚�ʏ̃J�i�E�Z���b�c�E�X���b�c�j START
//			axGT�Z��.set_RowsText(0, "|�X�֔ԍ�|�Z��|�R�[�h|");
			axGT�Z��.set_RowsText(0, "|�X�֔ԍ�|�Z��|�R�[�h|�J�i|�Z���R�[�h|�X���R�[�h|");

//			axGT�Z��.ColsWidth = "0|5.5|17|0|";

// MOD 2010.01.25 �p�\�j���� �\���T�C�Y�̕ύX START
//			axGT�Z��.ColsWidth = "0|5.5|17|0|9|5|5|";
			axGT�Z��.ColsWidth = "0|5.5|15|0|11|10|9.6|";
// MOD 2010.01.25 �p�\�j���� �\���T�C�Y�̕ύX END

//			axGT�Z��.ColsAlignHorz = "1|1|0|0|";
			axGT�Z��.ColsAlignHorz = "1|1|0|0|0|1|1|";
// MOD 2009.07.08 �p�\�j���� �\�����ڂ̒ǉ��i�厚�ʏ̃J�i�E�Z���b�c�E�X���b�c�j END
            
//			axGT�Z��.set_CelForeColor(axGT�Z��.CaretRow,0,111111);
			axGT�Z��.set_CelForeColor(axGT�Z��.CaretRow,0,0x98FB98);  //BGR
			axGT�Z��.set_CelBackColor(axGT�Z��.CaretRow,0,0x006000);

// MOD 2009.07.08 �p�\�j���� �\�����ڂ̒ǉ��i�厚�ʏ̃J�i�E�Z���b�c�E�X���b�c�j START
			axGT�Z��.CaretCol = 1;	//�ō��Z����I���i�X�N���[���o�[�߂��̂��߁j
// MOD 2009.07.08 �p�\�j���� �\�����ڂ̒ǉ��i�厚�ʏ̃J�i�E�Z���b�c�E�X���b�c�j END

			btn�O��.Enabled = false;
			btn����.Enabled = false;
			lab�Ŕԍ�.Text = "";
// MOD 2006.07.13 ���s�j�R�{ �O���Ł��Ŕԍ���\���Ή� START
			btn�O��.Visible = false;
			lab�Ŕԍ�.Visible = false;
			btn����.Visible = false;
// MOD 2006.07.13 ���s�j�R�{ �O���Ł��Ŕԍ���\���Ή� END


		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void axGT�Z��_CurPlaceChanged(object sender, AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEvent e)
		{
			axGT�Z��.set_CelForeColor(OldRow,0,0);
			axGT�Z��.set_CelBackColor(OldRow,0,0xFFFFFF);
//			axGT�Z��.set_CelForeColor(axGT�Z��.CaretRow,0,111111);
			axGT�Z��.set_CelForeColor(axGT�Z��.CaretRow,0,0x98FB98);  //BGR
			axGT�Z��.set_CelBackColor(axGT�Z��.CaretRow,0,0x006000);
			OldRow = axGT�Z��.CaretRow;
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			i�A�N�e�B�u�e�f = 1;
			tex���b�Z�[�W.Text = "";
			// �󔒏���
			tex�X�֔ԍ��P.Text = tex�X�֔ԍ��P.Text.Trim();
			tex�X�֔ԍ��Q.Text = tex�X�֔ԍ��Q.Text.Trim();
			i���ݕŐ� = 1;

// MOD 2005.06.07 ���s�j���� �s���{���I���̕ύX START
//			if(cmb�s���{��.SelectedIndex == 0 
			if(cmb�s���{��.Text.Length == 0 
// MOD 2005.06.07 ���s�j���� �s���{���I���̕ύX END
				&& tex�X�֔ԍ��P.Text.Length == 0 
				&& tex�X�֔ԍ��Q.Text.Length == 0)
			{
				tex���b�Z�[�W.Text = "";
				MessageBox.Show("������������͂��Ă�������","�Z������",MessageBoxButtons.OK);
				tex�X�֔ԍ��P.Focus();
				return;
			}
// MOD 2005.06.07 ���s�j���� �s���{���I���̕ύX START
//			if(cmb�s���{��.SelectedIndex == 0 && tex�X�֔ԍ��P.Text.Length != 3)
			if(cmb�s���{��.Text.Length   == 0 && tex�X�֔ԍ��P.Text.Length != 3)
// MOD 2005.06.07 ���s�j���� �s���{���I���̕ύX END
			{
				tex���b�Z�[�W.Text = "";
				MessageBox.Show("�X�֔ԍ��̏�3������͂��Ă�������","�Z������",MessageBoxButtons.OK);
				tex�X�֔ԍ��P.Focus();
				return;
			}

			if(tex�X�֔ԍ��P.Text.Length == 3)
			{
// MOD 2005.06.07 ���s�j���� �s���{���I���̕ύX START
////				cmb�s���{��.Text          = "";
//				cmb�s���{��.SelectedIndex = 0;
				cmb�s���{��.Text          = "";
// MOD 2005.06.07 ���s�j���� �s���{���I���̕ύX END
				s�s���{���b�c = "";
				s�s�撬���b�c = "";
				lab�Z��.Text = "";
				axGT�Z��.Clear();

				s�Z���ꗗ = new string[1];
				// �J�[�\���������v�ɂ���
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				try
				{
					tex���b�Z�[�W.Text = "�������D�D�D";
// ADD 2010.12.14 ACT�j�_�� ���q�^���Ή� START
					if (gs����b�c.Substring(0,1) != "J")
					{
// ADD 2010.12.14 ACT�j�_�� ���q�^���Ή� END
						if(sv_address == null) sv_address = new is2address.Service1();
						s�Z���ꗗ = sv_address.Get_byPostcode(gsa���[�U,tex�X�֔ԍ��P.Text + tex�X�֔ԍ��Q.Text);
// ADD 2010.12.14 ACT�j�_�� ���q�^���Ή� START
					}else{
						if(sv_oji == null) sv_oji = new is2oji.Service1();
						s�Z���ꗗ = sv_oji.Get_byPostcode(gsa���[�U,tex�X�֔ԍ��P.Text + tex�X�֔ԍ��Q.Text);
					}
// ADD 2010.12.14 ACT�j�_�� ���q�^���Ή� END
				}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
				catch (System.Net.WebException)
				{
					s�Z���ꗗ[0] = gs�ʐM�G���[;
				}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
				catch (Exception ex)
				{
					s�Z���ꗗ[0] = "�ʐM�G���[�F" + ex.Message;
				}
				// �J�[�\�����f�t�H���g�ɖ߂�
				Cursor = System.Windows.Forms.Cursors.Default;

				tex���b�Z�[�W.Text = s�Z���ꗗ[0];
				if(s�Z���ꗗ[0].Length == 4)
				{
					tex���b�Z�[�W.Text = "";
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� START
// MOD 2005.05.10 ���s�j�����J ��s�ڋ� START
////					i�ő�Ő� = (s�Z���ꗗ.Length - 2) / axGT�Z��.Rows + 1;
//					i�ő�Ő� = (s�Z���ꗗ.Length - 2) / (axGT�Z��.Rows - 1) + 1;
// MOD 2005.05.10 ���s�j�����J ��s�ڋ� END
					i�ő�Ő� = (s�Z���ꗗ.Length - 2) / (i�ōő�s�� - 1) + 1;
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� END
					if (i���ݕŐ� > i�ő�Ő�)
						i���ݕŐ� = i�ő�Ő�;
					�ŏ��ݒ�();

					axGT�Z��.Focus();
				}
				else
				{
					if(s�Z���ꗗ[0].Equals("�Y���f�[�^������܂���"))
					{
						tex���b�Z�[�W.Text = "";
						MessageBox.Show("�Y���f�[�^������܂���","�Z������",MessageBoxButtons.OK);
					}
					else
					{
						axGT�Z��.Clear();
						i���ݕŐ� = 1;
						btn�O��.Enabled = false;
						btn����.Enabled = false;
						lab�Ŕԍ�.Text = "";
						�r�[�v��();
					}
					tex�X�֔ԍ��P.Focus();
				}
			}
// MOD 2005.06.07 ���s�j���� �s���{���I���̕ύX START
//			else if(cmb�s���{��.SelectedIndex > 0)
			else if(cmb�s���{��.Text.Length   > 0)
// MOD 2005.06.07 ���s�j���� �s���{���I���̕ύX END
			{
				tex�X�֔ԍ��P.Text = "";
				tex�X�֔ԍ��Q.Text = "";
				lab�Z��.Text = cmb�s���{��.Text;
// MOD 2005.06.07 ���s�j���� �s���{���I���̕ύX START
//				s�s���{���b�c = cmb�s���{��.SelectedIndex.ToString();
// MOD 2005.06.15 ���s�j�����J �s���{���I���̕ύX START
//				if(cmb�s���{��.SelectedIndex < gi�s���{���b�c)
				if(cmb�s���{��.SelectedIndex < i�s���{���b�c�����l)
// MOD 2005.06.15 ���s�j�����J �s���{���I���̕ύX END
				{
					gi�s���{���b�c = cmb�s���{��.SelectedIndex + 1;
				}
				else
				{
					gi�s���{���b�c = cmb�s���{��.SelectedIndex;
				}
				s�s���{���b�c  = gi�s���{���b�c.ToString();
// MOD 2005.06.07 ���s�j���� �s���{���I���̕ύX END
				s�s�撬���b�c = "";
				if(s�s���{���b�c.Length == 1) s�s���{���b�c = "0" + s�s���{���b�c;
				axGT�Z��.Clear();

				s�Z���ꗗ = new string[1];
				// �J�[�\���������v�ɂ���
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				try
				{
					tex���b�Z�[�W.Text = "�������D�D�D";
					if(sv_address == null) sv_address = new is2address.Service1();
					s�Z���ꗗ = sv_address.Get_byKen(gsa���[�U,s�s���{���b�c);
				}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
				catch (System.Net.WebException)
				{
					s�Z���ꗗ[0] = gs�ʐM�G���[;
				}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
				catch (Exception ex)
				{
					s�Z���ꗗ[0] = "�ʐM�G���[�F" + ex.Message;
				}
				// �J�[�\�����f�t�H���g�ɖ߂�
				Cursor = System.Windows.Forms.Cursors.Default;

				tex���b�Z�[�W.Text = s�Z���ꗗ[0];
				if(s�Z���ꗗ[0].Length == 4)
				{
					tex���b�Z�[�W.Text = "";
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� START
// MOD 2005.05.10 ���s�j�����J ��s�ڋ� START
////					i�ő�Ő� = (s�Z���ꗗ.Length - 2) / axGT�Z��.Rows + 1;
//					i�ő�Ő� = (s�Z���ꗗ.Length - 2) / (axGT�Z��.Rows - 1) + 1;
// MOD 2005.05.10 ���s�j�����J ��s�ڋ� END
					i�ő�Ő� = (s�Z���ꗗ.Length - 2) / (i�ōő�s�� - 1) + 1;
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� END
					if (i���ݕŐ� > i�ő�Ő�)
						i���ݕŐ� = i�ő�Ő�;
					�ŏ��ݒ�();

					axGT�Z��.Focus();
				}
				else
				{
					axGT�Z��.Clear();
					i���ݕŐ� = 1;
					btn�O��.Enabled = false;
					btn����.Enabled = false;
					lab�Ŕԍ�.Text = "";
					�r�[�v��();
					cmb�s���{��.Focus();
				}
			}
			else if (axGT�Z��.Focused == true)
			{
				tex�X�֔ԍ��P.Focus();
			}
// MOD 2006.07.13 ���s�j�R�{ �O���Ł��Ŕԍ���\���Ή� START
			if(i�ő�Ő� <= 1)
			{
				btn�O��.Visible = false;
				lab�Ŕԍ�.Visible = false;
				btn����.Visible = false;
			}
			else
			{
				btn�O��.Visible = true;
				lab�Ŕԍ�.Visible = true;
				btn����.Visible = true;
			}
// MOD 2006.07.13 ���s�j�R�{ �O���Ł��Ŕԍ���\���Ή� END

// MOD 2009.07.08 �p�\�j���� �\�����ڂ̒ǉ��i�厚�ʏ̃J�i�E�Z���b�c�E�X���b�c�j START
		axGT�Z��.CaretCol = 1;	//�ō��Z����I���i�X�N���[���o�[�߂��̂��߁j
// MOD 2009.07.08 �p�\�j���� �\�����ڂ̒ǉ��i�厚�ʏ̃J�i�E�Z���b�c�E�X���b�c�j END

		}

		private void tex�X�֔ԍ��Q_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				if(tex�X�֔ԍ��P.Text.Trim().Length != 0
					|| tex�X�֔ԍ��Q.Text.Trim().Length != 0)
				{
					btn����_Click(sender, e);
					return;
				}
			}
		}

		private void cmb�s���{��_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				btn����_Click(sender, e);
				return;
			}
		}

		private void btn�m��_Click(object sender, System.EventArgs e)
		{
			if(axGT�Z��.CaretRow < 0) return;
			if(axGT�Z��.get_CelText(axGT�Z��.CaretRow,3).Length == 0) return;
			if(s�s�撬���b�c.Length == 0 && s�s���{���b�c.Length > 0)
			{
				i���ݕŐ� = 1;

				tex���b�Z�[�W.Text = "";
				lab�Z��.Text += axGT�Z��.get_CelText(axGT�Z��.CaretRow,2);
				s�s�撬���b�c = axGT�Z��.get_CelText(axGT�Z��.CaretRow,3);

				s�Z���ꗗ = new string[1];
				// �J�[�\���������v�ɂ���
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				try
				{
					tex���b�Z�[�W.Text = "�������D�D�D";
// ADD 2010.12.14 ACT�j�_�� ���q�^���Ή� START
					if (gs����b�c.Substring(0,1) != "J")
					{
// ADD 2010.12.14 ACT�j�_�� ���q�^���Ή� END
						if(sv_address == null) sv_address = new is2address.Service1();
						s�Z���ꗗ = sv_address.Get_byKenShi(gsa���[�U,s�s���{���b�c,s�s�撬���b�c);
// ADD 2010.12.14 ACT�j�_�� ���q�^���Ή� START
					}else{
						if(sv_oji == null) sv_oji = new is2oji.Service1();
						s�Z���ꗗ = sv_oji.Get_byKenShi(gsa���[�U,s�s���{���b�c,s�s�撬���b�c);
					}
// ADD 2010.12.14 ACT�j�_�� ���q�^���Ή� END
				}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
				catch (System.Net.WebException)
				{
					s�Z���ꗗ[0] = gs�ʐM�G���[;
				}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
				catch (Exception ex)
				{
					s�Z���ꗗ[0] = "�ʐM�G���[�F" + ex.Message;
				}
				// �J�[�\�����f�t�H���g�ɖ߂�
				Cursor = System.Windows.Forms.Cursors.Default;

				tex���b�Z�[�W.Text = s�Z���ꗗ[0];
				if(s�Z���ꗗ[0].Length == 4)
				{
					tex���b�Z�[�W.Text = "";
					axGT�Z��.Clear();
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� START
// MOD 2005.05.10 ���s�j�����J ��s�ڋ� START
////					i�ő�Ő� = (s�Z���ꗗ.Length - 2) / axGT�Z��.Rows + 1;
//					i�ő�Ő� = (s�Z���ꗗ.Length - 2) / (axGT�Z��.Rows - 1) + 1;
// MOD 2005.05.10 ���s�j�����J ��s�ڋ� END
					i�ő�Ő� = (s�Z���ꗗ.Length - 2) / (i�ōő�s�� - 1) + 1;
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� END

// MOD 2006.07.13 ���s�j�R�{ �O���Ł��Ŕԍ���\���Ή� START
					if(i�ő�Ő� <= 1)
					{
						btn�O��.Visible = false;
						lab�Ŕԍ�.Visible = false;
						btn����.Visible = false;
					}
					else
					{
						btn�O��.Visible = true;
						lab�Ŕԍ�.Visible = true;
						btn����.Visible = true;
					}
// MOD 2006.07.13 ���s�j�R�{ �O���Ł��Ŕԍ���\���Ή� END

					if (i���ݕŐ� > i�ő�Ő�)
						i���ݕŐ� = i�ő�Ő�;
					�ŏ��ݒ�();

// ADD 2005.05.10 ���s�j�����J ��s�ڑI�� START
					axGT�Z��.CaretRow = 1;
					axGT�Z��_CurPlaceChanged(null,null);
// ADD 2005.05.10 ���s�j�����J ��s�ڑI�� END
// MOD 2009.07.08 �p�\�j���� �\�����ڂ̒ǉ��i�厚�ʏ̃J�i�E�Z���b�c�E�X���b�c�j START
					axGT�Z��.CaretCol = 1;	//�ō��Z����I���i�X�N���[���o�[�߂��̂��߁j
// MOD 2009.07.08 �p�\�j���� �\�����ڂ̒ǉ��i�厚�ʏ̃J�i�E�Z���b�c�E�X���b�c�j END

					axGT�Z��.Focus();
				}
				else
				{
					�r�[�v��();
					axGT�Z��.Focus();
				}
			}
			else
			{
				lab�Z��.Text += axGT�Z��.get_CelText(axGT�Z��.CaretRow,2);
				s�X�֔ԍ��P = axGT�Z��.get_CelText(axGT�Z��.CaretRow,1);
				s�X�֔ԍ��P = s�X�֔ԍ��P.Replace("-","");
				if(s�X�֔ԍ��P.Length > 3)
				{
					s�X�֔ԍ��Q = s�X�֔ԍ��P.Substring(3);
					s�X�֔ԍ��P = s�X�֔ԍ��P.Substring(0,3);
				}
				s�Z��       = lab�Z��.Text;
				s�Z���b�c   = axGT�Z��.get_CelText(axGT�Z��.CaretRow,3);

				//�_�C�A���O�����
				this.Close();
			}
		}

		private void axGT�Z��_CelDblClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelDblClickEvent e)
		{
			btn�m��_Click(sender, null);
		}

		private void axGT�Z��_KeyDownEvent(object sender, AxGTABLE32V2Lib._DGTable32Events_KeyDownEvent e)
		{
			if (e.keyCode == 13)
			{
				btn�m��_Click(sender, null);
			}
			if (e.keyCode == 9)
			{
				this.SelectNextControl(axGT�Z��, true, true, true, true);
			}
		}

		private void btn�O��_Click(object sender, System.EventArgs e)
		{
			i���ݕŐ�--;
			�ŏ��ݒ�();
// ADD 2005.05.10 ���s�j�����J ��s�ڑI�� START
			axGT�Z��.CaretRow = 1;
			axGT�Z��_CurPlaceChanged(null,null);
// ADD 2005.05.10 ���s�j�����J ��s�ڑI�� END
// MOD 2009.07.08 �p�\�j���� �\�����ڂ̒ǉ��i�厚�ʏ̃J�i�E�Z���b�c�E�X���b�c�j START
			axGT�Z��.CaretCol = 1;	//�ō��Z����I���i�X�N���[���o�[�߂��̂��߁j
// MOD 2009.07.08 �p�\�j���� �\�����ڂ̒ǉ��i�厚�ʏ̃J�i�E�Z���b�c�E�X���b�c�j END
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			i���ݕŐ�++;
			�ŏ��ݒ�();
// ADD 2005.05.10 ���s�j�����J ��s�ڑI�� START
			axGT�Z��.CaretRow = 1;
			axGT�Z��_CurPlaceChanged(null,null);
// ADD 2005.05.10 ���s�j�����J ��s�ڑI�� END
// MOD 2009.07.08 �p�\�j���� �\�����ڂ̒ǉ��i�厚�ʏ̃J�i�E�Z���b�c�E�X���b�c�j START
			axGT�Z��.CaretCol = 1;	//�ō��Z����I���i�X�N���[���o�[�߂��̂��߁j
// MOD 2009.07.08 �p�\�j���� �\�����ڂ̒ǉ��i�厚�ʏ̃J�i�E�Z���b�c�E�X���b�c�j END
		}

		private void �ŏ��ݒ�()
		{
			axGT�Z��.Clear();
// ADD 2006.12.14 ���s�j�����J ���ׂ̗]�������� START
			axGT�Z��.Rows = 15;
// ADD 2006.12.14 ���s�j�����J ���ׂ̗]�������� END

// MOD 2005.05.10 ���s�j�����J ��s�ڋ� START
//			i�J�n�� = (i���ݕŐ� - 1) * axGT�Z��.Rows + 1;
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� START
//			i�J�n�� = (i���ݕŐ� - 1) * (axGT�Z��.Rows - 1) + 1;
			i�J�n�� = (i���ݕŐ� - 1) * (i�ōő�s�� - 1) + 1;
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� END
//			i�I���� = i���ݕŐ� * axGT�Z��.Rows;
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� START
//			i�I���� = i���ݕŐ� * (axGT�Z��.Rows - 1);
			i�I���� = i���ݕŐ� * (i�ōő�s�� - 1);
// MOD 2006.12.14 ���s�j�����J ���ׂ̗]�������� END

//			short s�\���� = (short)1;
			short s�\���� = (short)2;
// MOD 2005.05.10 ���s�j�����J ��s�ڋ� END
			for(short sCnt = (short)i�J�n��; sCnt < s�Z���ꗗ.Length && sCnt <= i�I���� ; sCnt++)
			{
// ADD 2006.12.14 ���s�j�����J ���ׂ̗]�������� START
				if(s�\���� > 15)
					axGT�Z��.Rows++;
// ADD 2006.12.14 ���s�j�����J ���ׂ̗]�������� END

				axGT�Z��.set_RowsText(s�\����, s�Z���ꗗ[sCnt]);
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
			axGT�Z��.Focus();
		}

		private void �Z������_Activated(object sender, System.EventArgs e)
		{
			if((tex�X�֔ԍ��P.Text.Trim().Length > 0
				|| tex�X�֔ԍ��Q.Text.Trim().Length > 0)
				&& i�A�N�e�B�u�e�f == 0)
				btn����_Click(sender,e);
		}

// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� START
		private void �Z������_Closed(object sender, System.EventArgs e)
		{
			tex�X�֔ԍ��P.Text  = " ";
			tex�X�֔ԍ��Q.Text  = "";
			cmb�s���{��.SelectedIndex = 0;
			lab�Z��.Text  = "";
			tex���b�Z�[�W.Text = "";
			axGT�Z��.Clear();
// MOD 2009.07.08 �p�\�j���� �\�����ڂ̒ǉ��i�厚�ʏ̃J�i�E�Z���b�c�E�X���b�c�j START
			axGT�Z��.Refresh();
// MOD 2009.07.08 �p�\�j���� �\�����ڂ̒ǉ��i�厚�ʏ̃J�i�E�Z���b�c�E�X���b�c�j END
			axGT�Z��.CaretRow  = 1;
			axGT�Z��_CurPlaceChanged(null,null);
			tex�X�֔ԍ��P.Focus();
		}
// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� END

	}
}
