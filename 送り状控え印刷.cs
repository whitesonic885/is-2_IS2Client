using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [�o�׃��x���C���[�W���]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// ADD 2015.11.09 BEVAS�j���{ �V�K�쐬�i�o�׃��x���C���[�W�����ʒǉ��j
	//--------------------------------------------------------------------------
	public class �����T����� : ���ʃt�H�[��
	{
		public short OldRow = 0;
		private short nSrow = 0;
		private short nErow = 0;
		private short nWork = 0;
		private string s�͂���b�c;
		private string s�͂��於;
		private string s�˗���b�c;
		private string s�˗��喼;

		private string[] s�o�׈ꗗ;
		private int      i���ݕŐ�;
		private string[] sa��Ԃb�c;

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab����;
		private ���ʃe�L�X�g�{�b�N�X tex�͂���R�[�h;
		private System.Windows.Forms.Label lab�͂���;
		private System.Windows.Forms.TextBox tex�d�ʍ��v;
		private System.Windows.Forms.TextBox tex�����v;
		private System.Windows.Forms.Label lab�o�^����;
		private System.Windows.Forms.TextBox tex�o�^����;
		private System.Windows.Forms.Label lab�����v;
		private System.Windows.Forms.Label lab�d�ʍ��v;
		private System.Windows.Forms.Label lab�˗���;
		private ���ʃe�L�X�g�{�b�N�X tex�˗���R�[�h;
		private System.Windows.Forms.Label lab���;
		private System.Windows.Forms.TextBox tex�˗��喼;
		private System.Windows.Forms.TextBox tex�͂��於;
		private System.Windows.Forms.Label lab���p����;
		private System.Windows.Forms.Label lab�o�׏Ɖ�^�C�g��;
		private System.Windows.Forms.TextBox tex���b�Z�[�W;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Button btn�͂��挟��;
		private System.Windows.Forms.Button btn�˗��匟��;
		private System.Windows.Forms.Button btn�o�׌���;
		private System.Windows.Forms.Button btn�Ĕ��s;
		private System.Windows.Forms.TextBox tex���p����;
		private System.Windows.Forms.Label lab�o�ד�;
		private AxGTABLE32V2Lib.AxGTable32 axGT�o�׈ꗗ;
		private System.Windows.Forms.DateTimePicker dt�J�n���t;
		private System.Windows.Forms.DateTimePicker dt�I�����t;
		private System.Windows.Forms.ComboBox cmb���;
		private System.Windows.Forms.ComboBox cmb�o�ד�;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lab���O�C���W�דX;
		private System.Windows.Forms.TextBox tex���O�C���W�דX;
		private System.Windows.Forms.Label lab�Ŕԍ�;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Button btn�O��;
		private System.Windows.Forms.Label lab�����ԍ�;
		private System.Windows.Forms.Label lab���q�l�ԍ�;
		private System.Windows.Forms.Label label2;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex���q�l�ԍ��J�n;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex���q�l�ԍ��I��;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�����ԍ��J�n;
		private System.Windows.Forms.Label label3;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�����ԍ��I��;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.ComponentModel.IContainer components;

		public �����T�����()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			�c�o�h�\���T�C�Y�ϊ�();
			this.axGT�o�׈ꗗ.Size = new System.Drawing.Size(732, 282);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(�����T�����));
            this.tex�͂���R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
            this.lab�͂��� = new System.Windows.Forms.Label();
            this.btn�͂��挟�� = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.axGT�o�׈ꗗ = new AxGTABLE32V2Lib.AxGTable32();
            this.tex�d�ʍ��v = new System.Windows.Forms.TextBox();
            this.tex�����v = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.lab�o�^���� = new System.Windows.Forms.Label();
            this.tex�o�^���� = new System.Windows.Forms.TextBox();
            this.lab�����v = new System.Windows.Forms.Label();
            this.lab�d�ʍ��v = new System.Windows.Forms.Label();
            this.lab�˗��� = new System.Windows.Forms.Label();
            this.btn�˗��匟�� = new System.Windows.Forms.Button();
            this.tex�˗���R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tex�����ԍ��I�� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
            this.label3 = new System.Windows.Forms.Label();
            this.tex���q�l�ԍ��I�� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
            this.label2 = new System.Windows.Forms.Label();
            this.tex���q�l�ԍ��J�n = new IS2Client.���ʃe�L�X�g�{�b�N�X();
            this.lab���q�l�ԍ� = new System.Windows.Forms.Label();
            this.tex�����ԍ��J�n = new IS2Client.���ʃe�L�X�g�{�b�N�X();
            this.lab�����ԍ� = new System.Windows.Forms.Label();
            this.cmb��� = new System.Windows.Forms.ComboBox();
            this.lab��� = new System.Windows.Forms.Label();
            this.cmb�o�ד� = new System.Windows.Forms.ComboBox();
            this.btn�o�׌��� = new System.Windows.Forms.Button();
            this.tex�˗��喼 = new System.Windows.Forms.TextBox();
            this.tex�͂��於 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dt�J�n���t = new System.Windows.Forms.DateTimePicker();
            this.lab�o�ד� = new System.Windows.Forms.Label();
            this.dt�I�����t = new System.Windows.Forms.DateTimePicker();
            this.lab�Ŕԍ� = new System.Windows.Forms.Label();
            this.btn���� = new System.Windows.Forms.Button();
            this.btn�O�� = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lab���O�C���W�דX = new System.Windows.Forms.Label();
            this.tex���O�C���W�דX = new System.Windows.Forms.TextBox();
            this.lab���p���� = new System.Windows.Forms.Label();
            this.tex���p���� = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lab���� = new System.Windows.Forms.Label();
            this.lab�o�׏Ɖ�^�C�g�� = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btn�Ĕ��s = new System.Windows.Forms.Button();
            this.tex���b�Z�[�W = new System.Windows.Forms.TextBox();
            this.btn���� = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ds�����)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGT�o�׈ꗗ)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tex�͂���R�[�h
            // 
            this.tex�͂���R�[�h.BackColor = System.Drawing.SystemColors.Window;
            this.tex�͂���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex�͂���R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tex�͂���R�[�h.Location = new System.Drawing.Point(94, 2);
            this.tex�͂���R�[�h.MaxLength = 15;
            this.tex�͂���R�[�h.Name = "tex�͂���R�[�h";
            this.tex�͂���R�[�h.Size = new System.Drawing.Size(190, 23);
            this.tex�͂���R�[�h.TabIndex = 0;
            this.tex�͂���R�[�h.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�͂���R�[�h_KeyDown);
            this.tex�͂���R�[�h.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�͂���R�[�h_KeyPress);
            this.tex�͂���R�[�h.LostFocus += new System.EventHandler(this.tex�͂���R�[�h_LostFocus);
            // 
            // lab�͂���
            // 
            this.lab�͂���.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab�͂���.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab�͂���.Location = new System.Drawing.Point(12, 6);
            this.lab�͂���.Name = "lab�͂���";
            this.lab�͂���.Size = new System.Drawing.Size(70, 16);
            this.lab�͂���.TabIndex = 8;
            this.lab�͂���.Text = "���͂���";
            // 
            // btn�͂��挟��
            // 
            this.btn�͂��挟��.BackColor = System.Drawing.Color.SteelBlue;
            this.btn�͂��挟��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn�͂��挟��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn�͂��挟��.ForeColor = System.Drawing.Color.White;
            this.btn�͂��挟��.Location = new System.Drawing.Point(286, 4);
            this.btn�͂��挟��.Name = "btn�͂��挟��";
            this.btn�͂��挟��.Size = new System.Drawing.Size(64, 22);
            this.btn�͂��挟��.TabIndex = 1;
            this.btn�͂��挟��.TabStop = false;
            this.btn�͂��挟��.Text = "�A�h���X��";
            this.btn�͂��挟��.UseVisualStyleBackColor = false;
            this.btn�͂��挟��.Click += new System.EventHandler(this.btn�͂��挟��_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Honeydew;
            this.panel2.Controls.Add(this.label5);
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
            this.panel2.Size = new System.Drawing.Size(764, 316);
            this.panel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(546, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 28);
            this.label5.TabIndex = 56;
            this.label5.Text = "���\���̉^���͊T�Z�^���ł���A�ύX����邱�Ƃ�����܂��B";
            // 
            // axGT�o�׈ꗗ
            // 
            this.axGT�o�׈ꗗ.DataSource = null;
            this.axGT�o�׈ꗗ.Location = new System.Drawing.Point(28, 30);
            this.axGT�o�׈ꗗ.Name = "axGT�o�׈ꗗ";
            this.axGT�o�׈ꗗ.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT�o�׈ꗗ.OcxState")));
            this.axGT�o�׈ꗗ.Size = new System.Drawing.Size(732, 282);
            this.axGT�o�׈ꗗ.TabIndex = 51;
            this.axGT�o�׈ꗗ.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT�o�׈ꗗ_CurPlaceChanged);
            this.axGT�o�׈ꗗ.CelClick += new AxGTABLE32V2Lib._DGTable32Events_CelClickEventHandler(this.axGT�o�׈ꗗ_CelClick);
            this.axGT�o�׈ꗗ.KeyDownEvent += new AxGTABLE32V2Lib._DGTable32Events_KeyDownEventHandler(this.axGT�o�׈ꗗ_KeyDownEvent);
            // 
            // tex�d�ʍ��v
            // 
            this.tex�d�ʍ��v.BackColor = System.Drawing.SystemColors.Window;
            this.tex�d�ʍ��v.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex�d�ʍ��v.Location = new System.Drawing.Point(382, 4);
            this.tex�d�ʍ��v.Name = "tex�d�ʍ��v";
            this.tex�d�ʍ��v.ReadOnly = true;
            this.tex�d�ʍ��v.Size = new System.Drawing.Size(86, 23);
            this.tex�d�ʍ��v.TabIndex = 50;
            this.tex�d�ʍ��v.TabStop = false;
            this.tex�d�ʍ��v.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tex�����v
            // 
            this.tex�����v.BackColor = System.Drawing.SystemColors.Window;
            this.tex�����v.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex�����v.Location = new System.Drawing.Point(246, 4);
            this.tex�����v.Name = "tex�����v";
            this.tex�����v.ReadOnly = true;
            this.tex�����v.Size = new System.Drawing.Size(70, 23);
            this.tex�����v.TabIndex = 49;
            this.tex�����v.TabStop = false;
            this.tex�����v.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.label21.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(0, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(22, 316);
            this.label21.TabIndex = 3;
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab�o�^����
            // 
            this.lab�o�^����.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab�o�^����.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab�o�^����.ForeColor = System.Drawing.Color.Blue;
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
            this.tex�o�^����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex�o�^����.Location = new System.Drawing.Point(122, 4);
            this.tex�o�^����.Name = "tex�o�^����";
            this.tex�o�^����.ReadOnly = true;
            this.tex�o�^����.Size = new System.Drawing.Size(54, 23);
            this.tex�o�^����.TabIndex = 46;
            this.tex�o�^����.TabStop = false;
            this.tex�o�^����.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lab�����v
            // 
            this.lab�����v.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab�����v.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lab�d�ʍ��v.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab�d�ʍ��v.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab�d�ʍ��v.ForeColor = System.Drawing.Color.Blue;
            this.lab�d�ʍ��v.Location = new System.Drawing.Point(322, 6);
            this.lab�d�ʍ��v.Name = "lab�d�ʍ��v";
            this.lab�d�ʍ��v.Size = new System.Drawing.Size(60, 18);
            this.lab�d�ʍ��v.TabIndex = 8;
            this.lab�d�ʍ��v.Text = "�d�ʍ��v";
            this.lab�d�ʍ��v.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab�˗���
            // 
            this.lab�˗���.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab�˗���.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab�˗���.Location = new System.Drawing.Point(12, 32);
            this.lab�˗���.Name = "lab�˗���";
            this.lab�˗���.Size = new System.Drawing.Size(70, 16);
            this.lab�˗���.TabIndex = 8;
            this.lab�˗���.Text = "���˗���";
            // 
            // btn�˗��匟��
            // 
            this.btn�˗��匟��.BackColor = System.Drawing.Color.SteelBlue;
            this.btn�˗��匟��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn�˗��匟��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn�˗��匟��.ForeColor = System.Drawing.Color.White;
            this.btn�˗��匟��.Location = new System.Drawing.Point(286, 30);
            this.btn�˗��匟��.Name = "btn�˗��匟��";
            this.btn�˗��匟��.Size = new System.Drawing.Size(64, 22);
            this.btn�˗��匟��.TabIndex = 3;
            this.btn�˗��匟��.TabStop = false;
            this.btn�˗��匟��.Text = "����";
            this.btn�˗��匟��.UseVisualStyleBackColor = false;
            this.btn�˗��匟��.Click += new System.EventHandler(this.btn�˗��匟��_Click);
            // 
            // tex�˗���R�[�h
            // 
            this.tex�˗���R�[�h.BackColor = System.Drawing.SystemColors.Window;
            this.tex�˗���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex�˗���R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tex�˗���R�[�h.Location = new System.Drawing.Point(94, 28);
            this.tex�˗���R�[�h.MaxLength = 12;
            this.tex�˗���R�[�h.Name = "tex�˗���R�[�h";
            this.tex�˗���R�[�h.Size = new System.Drawing.Size(154, 23);
            this.tex�˗���R�[�h.TabIndex = 2;
            this.tex�˗���R�[�h.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�˗���R�[�h_KeyDown);
            this.tex�˗���R�[�h.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�˗���R�[�h_KeyPress);
            this.tex�˗���R�[�h.LostFocus += new System.EventHandler(this.tex�˗���R�[�h_LostFocus);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Honeydew;
            this.panel5.Controls.Add(this.tex�����ԍ��I��);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.tex���q�l�ԍ��I��);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.tex���q�l�ԍ��J�n);
            this.panel5.Controls.Add(this.lab���q�l�ԍ�);
            this.panel5.Controls.Add(this.tex�����ԍ��J�n);
            this.panel5.Controls.Add(this.lab�����ԍ�);
            this.panel5.Controls.Add(this.cmb���);
            this.panel5.Controls.Add(this.lab���);
            this.panel5.Controls.Add(this.cmb�o�ד�);
            this.panel5.Controls.Add(this.btn�o�׌���);
            this.panel5.Controls.Add(this.tex�˗��喼);
            this.panel5.Controls.Add(this.tex�͂��於);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.dt�J�n���t);
            this.panel5.Controls.Add(this.lab�o�ד�);
            this.panel5.Controls.Add(this.lab�͂���);
            this.panel5.Controls.Add(this.btn�͂��挟��);
            this.panel5.Controls.Add(this.tex�͂���R�[�h);
            this.panel5.Controls.Add(this.lab�˗���);
            this.panel5.Controls.Add(this.tex�˗���R�[�h);
            this.panel5.Controls.Add(this.btn�˗��匟��);
            this.panel5.Controls.Add(this.dt�I�����t);
            this.panel5.Location = new System.Drawing.Point(1, 8);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(589, 134);
            this.panel5.TabIndex = 0;
            // 
            // tex�����ԍ��I��
            // 
            this.tex�����ԍ��I��.BackColor = System.Drawing.SystemColors.Window;
            this.tex�����ԍ��I��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex�����ԍ��I��.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tex�����ԍ��I��.Location = new System.Drawing.Point(260, 80);
            this.tex�����ԍ��I��.MaxLength = 13;
            this.tex�����ԍ��I��.Name = "tex�����ԍ��I��";
            this.tex�����ԍ��I��.Size = new System.Drawing.Size(142, 23);
            this.tex�����ԍ��I��.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.LimeGreen;
            this.label3.Location = new System.Drawing.Point(238, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 16);
            this.label3.TabIndex = 77;
            this.label3.Text = "�`";
            // 
            // tex���q�l�ԍ��I��
            // 
            this.tex���q�l�ԍ��I��.BackColor = System.Drawing.SystemColors.Window;
            this.tex���q�l�ԍ��I��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex���q�l�ԍ��I��.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tex���q�l�ԍ��I��.Location = new System.Drawing.Point(304, 106);
            this.tex���q�l�ԍ��I��.MaxLength = 20;
            this.tex���q�l�ԍ��I��.Name = "tex���q�l�ԍ��I��";
            this.tex���q�l�ԍ��I��.Size = new System.Drawing.Size(190, 23);
            this.tex���q�l�ԍ��I��.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.LimeGreen;
            this.label2.Location = new System.Drawing.Point(284, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 16);
            this.label2.TabIndex = 75;
            this.label2.Text = "�`";
            // 
            // tex���q�l�ԍ��J�n
            // 
            this.tex���q�l�ԍ��J�n.BackColor = System.Drawing.SystemColors.Window;
            this.tex���q�l�ԍ��J�n.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex���q�l�ԍ��J�n.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tex���q�l�ԍ��J�n.Location = new System.Drawing.Point(94, 106);
            this.tex���q�l�ԍ��J�n.MaxLength = 20;
            this.tex���q�l�ԍ��J�n.Name = "tex���q�l�ԍ��J�n";
            this.tex���q�l�ԍ��J�n.Size = new System.Drawing.Size(190, 23);
            this.tex���q�l�ԍ��J�n.TabIndex = 9;
            // 
            // lab���q�l�ԍ�
            // 
            this.lab���q�l�ԍ�.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab���q�l�ԍ�.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab���q�l�ԍ�.Location = new System.Drawing.Point(8, 110);
            this.lab���q�l�ԍ�.Name = "lab���q�l�ԍ�";
            this.lab���q�l�ԍ�.Size = new System.Drawing.Size(86, 16);
            this.lab���q�l�ԍ�.TabIndex = 73;
            this.lab���q�l�ԍ�.Text = "���q�l�ԍ�";
            // 
            // tex�����ԍ��J�n
            // 
            this.tex�����ԍ��J�n.BackColor = System.Drawing.SystemColors.Window;
            this.tex�����ԍ��J�n.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex�����ԍ��J�n.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tex�����ԍ��J�n.Location = new System.Drawing.Point(94, 80);
            this.tex�����ԍ��J�n.MaxLength = 13;
            this.tex�����ԍ��J�n.Name = "tex�����ԍ��J�n";
            this.tex�����ԍ��J�n.Size = new System.Drawing.Size(142, 23);
            this.tex�����ԍ��J�n.TabIndex = 7;
            // 
            // lab�����ԍ�
            // 
            this.lab�����ԍ�.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab�����ԍ�.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab�����ԍ�.Location = new System.Drawing.Point(12, 84);
            this.lab�����ԍ�.Name = "lab�����ԍ�";
            this.lab�����ԍ�.Size = new System.Drawing.Size(82, 16);
            this.lab�����ԍ�.TabIndex = 71;
            this.lab�����ԍ�.Text = "�����ԍ�";
            // 
            // cmb���
            // 
            this.cmb���.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb���.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb���.Location = new System.Drawing.Point(488, 54);
            this.cmb���.Name = "cmb���";
            this.cmb���.Size = new System.Drawing.Size(76, 24);
            this.cmb���.TabIndex = 6;
            this.cmb���.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb���_KeyDown);
            // 
            // lab���
            // 
            this.lab���.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab���.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab���.Location = new System.Drawing.Point(412, 58);
            this.lab���.Name = "lab���";
            this.lab���.Size = new System.Drawing.Size(76, 16);
            this.lab���.TabIndex = 13;
            this.lab���.Text = "�A����";
            // 
            // cmb�o�ד�
            // 
            this.cmb�o�ד�.BackColor = System.Drawing.Color.White;
            this.cmb�o�ד�.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb�o�ד�.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb�o�ד�.ForeColor = System.Drawing.Color.LimeGreen;
            this.cmb�o�ד�.Items.AddRange(new object[] {
            "�o�ד�",
            "�o�^��"});
            this.cmb�o�ד�.Location = new System.Drawing.Point(12, 54);
            this.cmb�o�ד�.Name = "cmb�o�ד�";
            this.cmb�o�ד�.Size = new System.Drawing.Size(78, 24);
            this.cmb�o�ד�.TabIndex = 4;
            // 
            // btn�o�׌���
            // 
            this.btn�o�׌���.BackColor = System.Drawing.Color.SteelBlue;
            this.btn�o�׌���.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn�o�׌���.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn�o�׌���.ForeColor = System.Drawing.Color.White;
            this.btn�o�׌���.Location = new System.Drawing.Point(504, 94);
            this.btn�o�׌���.Name = "btn�o�׌���";
            this.btn�o�׌���.Size = new System.Drawing.Size(76, 36);
            this.btn�o�׌���.TabIndex = 11;
            this.btn�o�׌���.TabStop = false;
            this.btn�o�׌���.Text = "�Ɖ�";
            this.btn�o�׌���.UseVisualStyleBackColor = false;
            this.btn�o�׌���.Click += new System.EventHandler(this.btn�o�׌���_Click);
            // 
            // tex�˗��喼
            // 
            this.tex�˗��喼.BackColor = System.Drawing.Color.Honeydew;
            this.tex�˗��喼.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tex�˗��喼.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex�˗��喼.Location = new System.Drawing.Point(354, 32);
            this.tex�˗��喼.Name = "tex�˗��喼";
            this.tex�˗��喼.ReadOnly = true;
            this.tex�˗��喼.Size = new System.Drawing.Size(224, 16);
            this.tex�˗��喼.TabIndex = 12;
            this.tex�˗��喼.TabStop = false;
            // 
            // tex�͂��於
            // 
            this.tex�͂��於.BackColor = System.Drawing.Color.Honeydew;
            this.tex�͂��於.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tex�͂��於.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex�͂��於.Location = new System.Drawing.Point(354, 6);
            this.tex�͂��於.Name = "tex�͂��於";
            this.tex�͂��於.ReadOnly = true;
            this.tex�͂��於.Size = new System.Drawing.Size(224, 16);
            this.tex�͂��於.TabIndex = 11;
            this.tex�͂��於.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(238, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "�`";
            // 
            // dt�J�n���t
            // 
            this.dt�J�n���t.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dt�J�n���t.Location = new System.Drawing.Point(94, 54);
            this.dt�J�n���t.Name = "dt�J�n���t";
            this.dt�J�n���t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dt�J�n���t.Size = new System.Drawing.Size(144, 23);
            this.dt�J�n���t.TabIndex = 4;
            // 
            // lab�o�ד�
            // 
            this.lab�o�ד�.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab�o�ד�.ForeColor = System.Drawing.Color.Green;
            this.lab�o�ד�.Location = new System.Drawing.Point(12, 58);
            this.lab�o�ד�.Name = "lab�o�ד�";
            this.lab�o�ד�.Size = new System.Drawing.Size(70, 16);
            this.lab�o�ד�.TabIndex = 6;
            this.lab�o�ד�.Text = "�o�ד�";
            // 
            // dt�I�����t
            // 
            this.dt�I�����t.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dt�I�����t.Location = new System.Drawing.Point(260, 54);
            this.dt�I�����t.Name = "dt�I�����t";
            this.dt�I�����t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dt�I�����t.Size = new System.Drawing.Size(144, 23);
            this.dt�I�����t.TabIndex = 5;
            // 
            // lab�Ŕԍ�
            // 
            this.lab�Ŕԍ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab�Ŕԍ�.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab�Ŕԍ�.Location = new System.Drawing.Point(686, 166);
            this.lab�Ŕԍ�.Name = "lab�Ŕԍ�";
            this.lab�Ŕԍ�.Size = new System.Drawing.Size(48, 14);
            this.lab�Ŕԍ�.TabIndex = 70;
            this.lab�Ŕԍ�.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn����
            // 
            this.btn����.BackColor = System.Drawing.Color.SteelBlue;
            this.btn����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn����.ForeColor = System.Drawing.Color.White;
            this.btn����.Location = new System.Drawing.Point(734, 162);
            this.btn����.Name = "btn����";
            this.btn����.Size = new System.Drawing.Size(48, 22);
            this.btn����.TabIndex = 69;
            this.btn����.Text = "����";
            this.btn����.UseVisualStyleBackColor = false;
            // 
            // btn�O��
            // 
            this.btn�O��.BackColor = System.Drawing.Color.SteelBlue;
            this.btn�O��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn�O��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn�O��.ForeColor = System.Drawing.Color.White;
            this.btn�O��.Location = new System.Drawing.Point(638, 162);
            this.btn�O��.Name = "btn�O��";
            this.btn�O��.Size = new System.Drawing.Size(48, 22);
            this.btn�O��.TabIndex = 68;
            this.btn�O��.Text = "�O��";
            this.btn�O��.UseVisualStyleBackColor = false;
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
            this.lab���O�C���W�דX.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab���O�C���W�דX.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab���O�C���W�דX.Location = new System.Drawing.Point(694, 8);
            this.lab���O�C���W�דX.Name = "lab���O�C���W�דX";
            this.lab���O�C���W�דX.Size = new System.Drawing.Size(48, 14);
            this.lab���O�C���W�דX.TabIndex = 13;
            this.lab���O�C���W�דX.Text = "���O�C��";
            // 
            // tex���O�C���W�דX
            // 
            this.tex���O�C���W�דX.BackColor = System.Drawing.Color.PaleGreen;
            this.tex���O�C���W�דX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tex���O�C���W�דX.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.lab���p����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.tex���p����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.panel7.Controls.Add(this.lab����);
            this.panel7.Controls.Add(this.lab�o�׏Ɖ�^�C�g��);
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(792, 26);
            this.panel7.TabIndex = 13;
            // 
            // lab����
            // 
            this.lab����.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab����.ForeColor = System.Drawing.Color.White;
            this.lab����.Location = new System.Drawing.Point(674, 8);
            this.lab����.Name = "lab����";
            this.lab����.Size = new System.Drawing.Size(112, 14);
            this.lab����.TabIndex = 1;
            this.lab����.Text = "2005/xx/xx 12:00:00";
            // 
            // lab�o�׏Ɖ�^�C�g��
            // 
            this.lab�o�׏Ɖ�^�C�g��.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab�o�׏Ɖ�^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab�o�׏Ɖ�^�C�g��.ForeColor = System.Drawing.Color.White;
            this.lab�o�׏Ɖ�^�C�g��.Location = new System.Drawing.Point(12, 2);
            this.lab�o�׏Ɖ�^�C�g��.Name = "lab�o�׏Ɖ�^�C�g��";
            this.lab�o�׏Ɖ�^�C�g��.Size = new System.Drawing.Size(264, 24);
            this.lab�o�׏Ɖ�^�C�g��.TabIndex = 0;
            this.lab�o�׏Ɖ�^�C�g��.Text = "�o�׃��x���C���[�W���";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.PaleGreen;
            this.panel8.Controls.Add(this.btn�Ĕ��s);
            this.panel8.Controls.Add(this.tex���b�Z�[�W);
            this.panel8.Controls.Add(this.btn����);
            this.panel8.Location = new System.Drawing.Point(0, 516);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(792, 58);
            this.panel8.TabIndex = 2;
            // 
            // btn�Ĕ��s
            // 
            this.btn�Ĕ��s.ForeColor = System.Drawing.Color.Blue;
            this.btn�Ĕ��s.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn�Ĕ��s.Location = new System.Drawing.Point(118, 6);
            this.btn�Ĕ��s.Name = "btn�Ĕ��s";
            this.btn�Ĕ��s.Size = new System.Drawing.Size(60, 48);
            this.btn�Ĕ��s.TabIndex = 1;
            this.btn�Ĕ��s.Text = "�C���[�W�@�@���";
            this.btn�Ĕ��s.Click += new System.EventHandler(this.btn�Ĕ��s_Click);
            // 
            // tex���b�Z�[�W
            // 
            this.tex���b�Z�[�W.BackColor = System.Drawing.Color.PaleGreen;
            this.tex���b�Z�[�W.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex���b�Z�[�W.ForeColor = System.Drawing.Color.Red;
            this.tex���b�Z�[�W.Location = new System.Drawing.Point(446, 4);
            this.tex���b�Z�[�W.Multiline = true;
            this.tex���b�Z�[�W.Name = "tex���b�Z�[�W";
            this.tex���b�Z�[�W.ReadOnly = true;
            this.tex���b�Z�[�W.Size = new System.Drawing.Size(344, 50);
            this.tex���b�Z�[�W.TabIndex = 1;
            this.tex���b�Z�[�W.TabStop = false;
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
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.ForeColor = System.Drawing.Color.Green;
            this.groupBox1.Location = new System.Drawing.Point(38, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Location = new System.Drawing.Point(16, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(768, 324);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(638, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 28);
            this.label4.TabIndex = 71;
            this.label4.Text = "���ߋ��S�T���Ԃ̏o�׃f�[�^���Ɖ�\�ł��B";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(638, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 28);
            this.label6.TabIndex = 72;
            this.label6.Text = "�������s�̏o�׃f�[�^�́A����ł��܂���B";
            // 
            // �����T�����
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(792, 580);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lab�Ŕԍ�);
            this.Controls.Add(this.btn����);
            this.Controls.Add(this.btn�O��);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 607);
            this.Name = "�����T�����";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "is-2 �o�׃��x���C���[�W���";
            this.Closed += new System.EventHandler(this.�o�׏Ɖ�_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.On�G���^�[�ړ�);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.On�G���^�[�L�����Z��);
            ((System.ComponentModel.ISupportInitialize)(this.ds�����)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGT�o�׈ꗗ)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
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
			// �w�b�_�[���ڂ̐ݒ�
			if(gs���p�ҕ���X���b�c == null || gs���p�ҕ���X���b�c.Length == 0)
			{
				tex���O�C���W�דX.Text = "";
			}
			else
			{
				tex���O�C���W�דX.Text = gs���p�ҕ���X���b�c;
			}

			tex���p����.Text = gs����b�c + " " + gs���喼;

			// �����̏����ݒ�
			lab����.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled = true;

			// ��ԃR���{�̏����ݒ�
			// �{��ʗp��ԃ��X�g�쐬�i���s�ς����O���邽�߁j
			sa��Ԃb�c = new string[gsa��Ԃb�c.Length - 1];
			bool remove_flg = false; // ���O���ڂ����������ǂ����𔻒肷��t���O
			int storeId = 0;         // �{��ʗp��ԃ��X�g�̊i�[�pIndex
			for(int i = 0; i < gsa��Ԃb�c.Length; i++)
			{
				storeId = i;
				if(remove_flg)
				{
					// ���O���ꂽ��̊i�[�pIndex�́Agsa��Ԃb�c�̌��ݏ���Index�����w1�x����������
					// �iIndexOutOfRangeException��h���ׁj
					storeId = i - 1;
				}

				if(gsa��Ԃb�c[i] == "00")
				{
					//��Ԃ�[�S��]�̏ꍇ�́A��Ԃb�c���waa�x�Ƃ���
					sa��Ԃb�c[storeId] = "aa";
					continue;
				}
				else if(gsa��Ԃb�c[i] == "01")
				{
					//��Ԃ�[���s��]�̏ꍇ�́A���O���ڔ����t���O���n�m�ɂ���
					remove_flg = true;
					continue;
				}

				//��Ԃ�[���s��]�ȊO�̂��̂��i�[����
				sa��Ԃb�c[storeId] = gsa��Ԃb�c[i];
				
			}
			// �����l�ݒ�
			cmb���.Items.Clear();
			cmb���.Items.AddRange(gsa��Ԗ�);
			cmb���.Items.RemoveAt(1); // [���s��]�����O
			cmb���.SelectedIndex = 0;

			// �o�ד��R���{�̏����l�ݒ�
			cmb�o�ד�.SelectedIndex = 0;

			// �o�ד��̏����ݒ�i�����j
			����o�ד����X�V();
			dt�J�n���t.Value   = gdt�o�ד�;
			dt�I�����t.Value   = gdt�o�ד�;

			���ڏ�����();

			axGT�o�׈ꗗ.Cols = 24;
			axGT�o�׈ꗗ.Rows = 10;
			axGT�o�׈ꗗ.ColSep = "|";

			axGT�o�׈ꗗ.set_RowsText(0, "||����|�o�ד�|���͂���|��|�d��|�����ԍ�|���q�l�ԍ�|�w���|�A����|"
										+"�z�����t�E����|�A�����i�^�L���E�i��|�^��|�ی���|�o�^��|"
										+"�W���[�i���m�n|��|�o��|�o�^��||||||");
			axGT�o�׈ꗗ.ColsWidth =    "0|0|2.2|3.6|18|2.6|3|6.0|9.8|5.3|4.6|"
										+"8|12.0|5.5|5.5|4.2|"
										+"0|0|0|0|0|0|0|0|0|";
			axGT�o�׈ꗗ.ColsAlignHorz = "1|1|1|1|0|2|2|0|0|1|1|"
										+"1|0|2|2|1|"
										+"0|0|0|0|0|0|0|0|0|";
			axGT�o�׈ꗗ.set_CelForeColor(axGT�o�׈ꗗ.CaretRow,0,0x98FB98);  //BGR
			axGT�o�׈ꗗ.set_CelBackColor(axGT�o�׈ꗗ.CaretRow,0,0x006000);

			for(short i = 1; i <= axGT�o�׈ꗗ.Rows; i++ )
			{
				axGT�o�׈ꗗ.set_CelHeight(i,0,2.3);
				axGT�o�׈ꗗ.set_CelAlignVert(i,4,3);
				axGT�o�׈ꗗ.set_CelAlignVert(i,7,3);
				//�A�����i�^�L���E�i��
				axGT�o�׈ꗗ.set_CelAlignVert(i,12,3);
			}

			btn�O��.Visible = false;
			btn����.Visible = false;
			lab�Ŕԍ�.Visible = false;
		}

		private void ���ڏ�����()
		{
			tex�͂���R�[�h.Text = "";
			tex�͂��於.Text     = "";
			tex�˗���R�[�h.Text = "";
			tex�˗��喼.Text     = "";
			tex�����ԍ��J�n.Text = "";
			tex�����ԍ��I��.Text = "";
			tex���q�l�ԍ��J�n.Text = "";
			tex���q�l�ԍ��I��.Text = "";
			tex�o�^����.Text     = "";
			tex�����v.Text     = "";
			tex�d�ʍ��v.Text     = "";
			tex���b�Z�[�W.Text   = "";
			axGT�o�׈ꗗ.Clear();
			axGT�o�׈ꗗ.ColsWidth =    "0|0|2.2|3.6|18|2.6|3|6.0|9.8|5.3|4.6|"
										+"8|12.0|5.5|5.5|4.2|"
										+"0|0|0|0|0|0|0|0|0|";
			axGT�o�׈ꗗ.CaretRow = 1;
			axGT�o�׈ꗗ.CaretCol = 2;
			axGT�o�׈ꗗ_CurPlaceChanged(null,null);
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btn�͂��挟��_Click(object sender, System.EventArgs e)
		{
			tex�͂���R�[�h.Text = tex�͂���R�[�h.Text.Trim();
			if(!���p�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;

			if(g�͐挟�� == null)
			{
				g�͐挟�� = new ���͂��挟��();
			}
			g�͐挟��.Left = this.Left;
			g�͐挟��.Top = this.Top;
			g�͐挟��.sTcode = "";
			g�͐挟��.ShowDialog();

			s�͂���b�c = g�͐挟��.sTcode;
			s�͂��於   = g�͐挟��.sTname;
			if(s�͂���b�c.Length > 0)
			{
				tex�͂���R�[�h.Text = s�͂���b�c;
				tex�͂��於.Text = s�͂��於;
				tex�˗���R�[�h.Focus();
			}
			else
				tex�͂���R�[�h.Focus();
		}

		private void btn�˗��匟��_Click(object sender, System.EventArgs e)
		{
			tex�˗���R�[�h.Text = tex�˗���R�[�h.Text.Trim();
			if(!���p�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;

			if(g�˗����� == null)
			{
				g�˗����� = new ���˗��匟��();
			}
			g�˗�����.Left = this.Left;
			g�˗�����.Top = this.Top;
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
					axGT�o�׈ꗗ.set_CelForeColor(nCnt,0,0);
					axGT�o�׈ꗗ.set_CelBackColor(nCnt,0,0xFFFFFF);
				}
			}

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

			axGT�o�׈ꗗ.set_CelForeColor(axGT�o�׈ꗗ.CaretRow,0,0x98FB98);
			axGT�o�׈ꗗ.set_CelBackColor(axGT�o�׈ꗗ.CaretRow,0,0x006000);

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

		private void btn�o�׌���_Click(object sender, System.EventArgs e)
		{
			if (dt�J�n���t.Value > dt�I�����t.Value)
			{
				MessageBox.Show("���t�͈̔͂����������͂���Ă��܂���","���̓`�F�b�N",MessageBoxButtons.OK );
				dt�J�n���t.Focus();
				return;
			}

			tex�o�^����.Text = "";
			tex�����v.Text = "";
			tex�d�ʍ��v.Text = "";
			tex���b�Z�[�W.Text = "�������D�D�D";
			axGT�o�׈ꗗ.Clear();
			axGT�o�׈ꗗ.ColsWidth =    "0|0|2.2|3.6|18|2.6|3|6.0|9.8|5.3|4.6|"
										+"8|12.0|5.5|5.5|4.2|"
										+"0|0|0|0|0|0|0|0|0|";
			axGT�o�׈ꗗ.CaretRow = 1;
			axGT�o�׈ꗗ.CaretCol = 2;
			axGT�o�׈ꗗ_CurPlaceChanged(null,null);
			string sSday = YYYYMMDD�ϊ�(dt�J�n���t.Value);
			string sEday = YYYYMMDD�ϊ�(dt�I�����t.Value);

			// �󔒏���
			tex�͂���R�[�h.Text = tex�͂���R�[�h.Text.Trim();
			if(tex�͂���R�[�h.Text.Length == 0)
				tex�͂��於.Text = "";
			else
			{
				if(!���p�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;

				tex���b�Z�[�W.Text = "";
				s�͂���b�c = tex�͂���R�[�h.Text;
				�͂��挟��();
			}

			tex�˗���R�[�h.Text = tex�˗���R�[�h.Text.Trim();
			if(tex�˗���R�[�h.Text.Length == 0)
				tex�˗��喼.Text = "";
			else
			{
				if(!���p�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;

				tex���b�Z�[�W.Text = "";
				s�˗���b�c = tex�˗���R�[�h.Text;
				�˗��匟��();
			}

			tex�����ԍ��J�n.Text = tex�����ԍ��J�n.Text.TrimEnd();
			tex�����ԍ��I��.Text = tex�����ԍ��I��.Text.TrimEnd();
			tex���q�l�ԍ��J�n.Text = tex���q�l�ԍ��J�n.Text.TrimEnd();
			tex���q�l�ԍ��I��.Text = tex���q�l�ԍ��I��.Text.TrimEnd();

			if(!���p�`�F�b�N(tex�����ԍ��J�n,"�����ԍ��i�J�n�j")) return;
			if(!���p�`�F�b�N(tex�����ԍ��I��,"�����ԍ��i�I���j")) return;
			if(!���p�`�F�b�N(tex���q�l�ԍ��J�n,"���q�l�ԍ��i�J�n�j")) return;
			if(!���p�`�F�b�N(tex���q�l�ԍ��I��,"���q�l�ԍ��i�I���j")) return;
			
			if(tex�����ԍ��J�n.Text.Length > 0){
				if(tex�����ԍ��J�n.Text.Length != 11
				&& tex�����ԍ��J�n.Text.Length != 4 // SS�̎d�l
				&& tex�����ԍ��J�n.Text.Length != 5 // SS�̎d�l
				&& tex�����ԍ��J�n.Text.Length != 13 ){
					tex���b�Z�[�W.Text = "";
					MessageBox.Show("�����ԍ��͂P�P���������͂P�R���œ��͂��Ă�������"
									, "���̓`�F�b�N", MessageBoxButtons.OK );
					tex�����ԍ��J�n.Focus();
					return;
				}
			}

			if(tex�����ԍ��I��.Text.Length > 0){
				if(tex�����ԍ��I��.Text.Length != 11
				&& tex�����ԍ��I��.Text.Length != 4 // SS�̎d�l
				&& tex�����ԍ��I��.Text.Length != 5 // SS�̎d�l
				&& tex�����ԍ��I��.Text.Length != 13 ){
					tex���b�Z�[�W.Text = "";
					MessageBox.Show("�����ԍ��͂P�P���������͂P�R���œ��͂��Ă�������"
									, "���̓`�F�b�N", MessageBoxButtons.OK );
					tex�����ԍ��I��.Focus();
					return;
				}
			}

			string s��� = sa��Ԃb�c[cmb���.SelectedIndex];

			i���ݕŐ� = 1;
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				s�o�׈ꗗ = new string[1];
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
				string[] sa�������� = new string[]{
								gs����b�c
								, gs����b�c
								, tex�͂���R�[�h.Text.TrimEnd()
								, tex�˗���R�[�h.Text.TrimEnd()
								, cmb�o�ד�.SelectedIndex.ToString()
								, sSday
								, sEday
								, s���
							    , tex�����ԍ��J�n.Text.Replace("-","")
							    , tex�����ԍ��I��.Text.Replace("-","")
							    , tex���q�l�ԍ��J�n.Text.TrimEnd()
							    , tex���q�l�ԍ��I��.Text.TrimEnd()
							    , "1"	//�����s���.cs�̈ꗗ�\�������h�~
				};

				s�o�׈ꗗ = sv_syukka.Get_syukka2(gsa���[�U, sa��������);
				tex���b�Z�[�W.Text = s�o�׈ꗗ[0];
				if(s�o�׈ꗗ[0].Length == 4)
				{
					tex���b�Z�[�W.Text = "";
					tex�o�^����.Text = s�o�׈ꗗ[1];
					tex�����v.Text = s�o�׈ꗗ[2];
					tex�d�ʍ��v.Text = s�o�׈ꗗ[3];
					axGT�o�׈ꗗ.Rows = 9;
					�ŏ��ݒ�();
				}
				else
				{
					if(s�o�׈ꗗ[0].Equals("�Y���f�[�^������܂���"))
					{
						tex���b�Z�[�W.Text = "";
						MessageBox.Show("�Y���f�[�^������܂���","�o�׌���",MessageBoxButtons.OK);
					}
					else
					{
						i���ݕŐ� = 1;
						btn�O��.Enabled = false;
						btn����.Enabled = false;
						lab�Ŕԍ�.Text = "";
						�r�[�v��();
					}
					tex�͂���R�[�h.Focus();
				}
			}
			catch (System.Net.WebException)
			{
				tex���b�Z�[�W.Text = gs�ʐM�G���[;
				�r�[�v��();
				tex�͂���R�[�h.Focus();
			}
			catch (Exception ex)
			{
				tex���b�Z�[�W.Text = "�ʐM�G���[�F" + ex.Message;
				�r�[�v��();
				tex�͂���R�[�h.Focus();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
			axGT�o�׈ꗗ.CaretRow = 1;
			axGT�o�׈ꗗ.CaretCol = 2;
			axGT�o�׈ꗗ_CurPlaceChanged(sender,null);
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
						tex�͂��於.Text     = sList[10].TrimEnd();
						tex���b�Z�[�W.Text = "";
						tex�˗���R�[�h.Focus();
					}
					else
					{
						tex���b�Z�[�W.Text = "";
						tex�˗���R�[�h.Focus();
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

		private void �˗��匟��()
		{
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
						tex���b�Z�[�W.Text = "";
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

		private void tex�͂���R�[�h_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn�͂��挟��.Focus();
				btn�͂��挟��_Click(sender,e);
				e.Handled = true;
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

		private void tex�͂���R�[�h_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
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

		private void tex�˗���R�[�h_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
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

		private void axGT�o�׈ꗗ_KeyDownEvent(object sender, AxGTABLE32V2Lib._DGTable32Events_KeyDownEvent e)
		{
			if (e.keyCode == 13)
			{
				//Enter�L�[���������ꍇ
				btn�Ĕ��s_Click(sender, null);
			}
			if (e.keyCode == 9)
			{
				//Tab�L�[���������ꍇ
				this.SelectNextControl(axGT�o�׈ꗗ, true, true, true, true);
			}
		}

		private void btn�Ĕ��s_Click(object sender, System.EventArgs e)
		{
			//�o�^���`�F�b�N
			if(axGT�o�׈ꗗ.get_CelText(axGT�o�׈ꗗ.CaretRow,17).Trim().Length == 0)
			{
				return;
			}

			tex���b�Z�[�W.Text = "���x���C���[�W������D�D�D";

//			try
//			{
//				�v�����^�`�F�b�N();
//			}
//			catch(Exception ex)
//			{
//				tex���b�Z�[�W.Text = ex.Message;
//				return;
//			}

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

			short n�\���J�n = axGT�o�׈ꗗ.TopRow;
			string s�J�n�o�^��         = axGT�o�׈ꗗ.get_CelText(n�J�n,17).Trim();
			string s�J�n�W���[�i���m�n = axGT�o�׈ꗗ.get_CelText(n�J�n,16).Trim();
			string s�I���o�^��         = axGT�o�׈ꗗ.get_CelText(n�I��,17).Trim();
			string s�I���W���[�i���m�n = axGT�o�׈ꗗ.get_CelText(n�I��,16).Trim();
			string s���s�o�^��         = "";
			string s���s�W���[�i���m�n = "";
			short n���s = (short)(n�I�� + 1);
			if(n���s <= axGT�o�׈ꗗ.Rows){
				s���s�o�^��         = axGT�o�׈ꗗ.get_CelText(n���s,17).Trim();
				s���s�W���[�i���m�n = axGT�o�׈ꗗ.get_CelText(n���s,16).Trim();
			}

			�����f�[�^�N���A();

			for(short nCnt = n�J�n ; nCnt <= n�I��; nCnt++)
			{
				try
				{
					string[] sData = new string[2];
					//�o�^���A�W���[�i���m�n
					sData[0] = axGT�o�׈ꗗ.get_CelText(nCnt, 17);
					sData[1] = axGT�o�׈ꗗ.get_CelText(nCnt, 16);
					�׎D�T������w��(sData, 1, 99);

					if(!gb���)
					{
						tex���b�Z�[�W.Text = "";
						Cursor = System.Windows.Forms.Cursors.Default;
						MessageBox.Show("�W�דX���Ⴂ�܂��B����ł��܂���B", "����T���", MessageBoxButtons.OK);
						return;
					}
				}
				catch (Exception ex)
				{
					tex���b�Z�[�W.Text = ex.Message;
					�r�[�v��();
					Cursor = System.Windows.Forms.Cursors.Default;
					return;
				}
			}

			�׎D�T�����[���();

			Cursor = System.Windows.Forms.Cursors.Default;

			// �Č���
			btn�o�׌���_Click(sender, e);
			�ꗗ�J�[�\���ړ�(n�J�n, n�I��, n�\���J�n
							, s�J�n�o�^��, s�J�n�W���[�i���m�n
							, s�I���o�^��, s�I���W���[�i���m�n
							, s���s�o�^��, s���s�W���[�i���m�n);
			tex���b�Z�[�W.Text = "";
		}

		private void tex�͂���R�[�h_LostFocus(object sender, EventArgs e)
		{
			if(tex�͂���R�[�h.Text.Trim() == "")
				tex�͂��於.Text = "";
		}

		private void tex�˗���R�[�h_LostFocus(object sender, EventArgs e)
		{
			if(tex�˗���R�[�h.Text.Trim() == "")
				tex�˗��喼.Text = "";

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
			if (s�o�׈ꗗ.Length - 4 <= 9)
			{
				axGT�o�׈ꗗ.Rows = 9;
			}
			else if (axGT�o�׈ꗗ.Rows < s�o�׈ꗗ.Length - 4)
			{
				axGT�o�׈ꗗ.Rows = (short)(s�o�׈ꗗ.Length - 4);
			}

			for(short i = 1; i <= axGT�o�׈ꗗ.Rows; i++ )
			{
				axGT�o�׈ꗗ.set_CelHeight(i,0,2.3);
				axGT�o�׈ꗗ.set_CelAlignVert(i,4,3);
				axGT�o�׈ꗗ.set_CelAlignVert(i,7,3);
				//�A�����i�^�L���E�i��
				axGT�o�׈ꗗ.set_CelAlignVert(i,12,3);
			}

			axGT�o�׈ꗗ.Clear();
			axGT�o�׈ꗗ.CaretRow = 1;
			axGT�o�׈ꗗ.CaretCol = 2;
			axGT�o�׈ꗗ_CurPlaceChanged(null,null);
			short s�\���� = (short)1;

			for(short sCnt = (short)4; sCnt < s�o�׈ꗗ.Length; sCnt++)
			{
				string sRList = s�o�׈ꗗ[sCnt].Replace("\\r\\n","\r\n");
				axGT�o�׈ꗗ.set_RowsText(s�\����, sRList);
				s�\����++;
			}
			axGT�o�׈ꗗ.Focus();
		}

		private void cmb���_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				btn�o�׌���_Click(sender,e);
			}

		}

		private void �o�׏Ɖ�_Closed(object sender, System.EventArgs e)
		{
			tex�͂���R�[�h.Focus();
		}

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
			if(s�J�n�o�^�� == axGT�o�׈ꗗ.get_CelText(n�J�n,17).Trim()
			&& s�J�n�W���[�i���m�n == axGT�o�׈ꗗ.get_CelText(n�J�n,16).Trim()
			&& s�I���o�^�� == axGT�o�׈ꗗ.get_CelText(n�I��,17).Trim()
			&& s�I���W���[�i���m�n == axGT�o�׈ꗗ.get_CelText(n�I��,16).Trim()){
				n�V�J�n = n�J�n;
				n�V�I�� = n�I��;
			}else{
				for(short n�s = 1; n�s <= axGT�o�׈ꗗ.Rows; n�s++){
					//�I���J�n�s�̒l�i�o�^���A�W���[�i���m�n�j�������ꍇ
					if(s�J�n�o�^�� == axGT�o�׈ꗗ.get_CelText(n�s,17).Trim()
					&& s�J�n�W���[�i���m�n == axGT�o�׈ꗗ.get_CelText(n�s,16).Trim()){
						n�V�J�n = n�s;
					}
					//�I���I���s�̒l�i�o�^���A�W���[�i���m�n�j�������ꍇ
					if(s�I���o�^�� == axGT�o�׈ꗗ.get_CelText(n�s,17).Trim()
					&& s�I���W���[�i���m�n == axGT�o�׈ꗗ.get_CelText(n�s,16).Trim()){
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
						if(s���s�o�^�� == axGT�o�׈ꗗ.get_CelText(n�s,17).Trim()
						&& s���s�W���[�i���m�n == axGT�o�׈ꗗ.get_CelText(n�s,16).Trim()){
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
	}
}
