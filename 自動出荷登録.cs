using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Threading;

namespace IS2Client
{
	/// <summary>
	/// [�b�r�u�G���g���[]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// MOD 2008.04.25 ���s�j���� ����v�͑S�p�͕s�ɂ���
	// �`�b�s�j�R�{�a����Q�񍐗L
	// ADD 2008.04.11 ACT Vista�Ή� 
	// ADD 2008.05.14 ���s�j���� Unicode�t�@�C���̉��s�Ή� 
	// MOD 2008.06.12 kcl)�X�{ ���X�R�[�h�������@�̕ύX
	//  btn�m�F_Click
	// MOD 2008.11.19 ���s�j���� ���X�R�[�h���󔒂ł��G���[�łȂ����� 
	// MOD 2008.12.25 kcl)�X�{ ���X�R�[�h�������@�̍ĕύX
	//--------------------------------------------------------------------------
	// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N 
	// MOD 2009.04.06 ���s�j���� �擪�s�����@�\�̒ǉ� 
	// MOD 2009.11.25 ���s�j���� ���Ԏw��`�F�b�N�̒ǉ� 
	// MOD 2009.12.01 ���s�j���� �S�p���p���݉\�ɂ��� 
	// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� 
	//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� 
	// MOD 2009.12.08 ���s�j���� �w����̏����Q�i��L�̃O���[�o���Ή��̏�Q�j
	//--------------------------------------------------------------------------
	// MOD 2010.02.25 ���s�j���� ���ڐ��`�F�b�N�̏C�� 
	// MOD 2010.02.25 ���s�j���� �w�b�_�s�������ʋ@�\�̒ǉ� 
	// MOD 2010.03.18 ���s�j���� �f�[�^�����`�F�b�N�̒ǉ� 
	// MOD 2010.03.30 ���s�j���� �g�ѓd�b�Ή� 
	// MOD 2010.04.19 ���s�j���� �o�̓t�@�C�����̕ύX 
	// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX 
	// MOD 2010.09.03 ���s�j���� �b�r�u�G���g���[���̐�����G���[�\�L�C�� 
	// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� 
	// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX 
	// MOD 2010.11.02 ���s�j���� ���l�͈̓`�F�b�N�̕ύX 
	// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) 
	// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� 
	// MOD 2011.01.25 ���s�j���� �u���[�h�Ɏ��s�v�Ή� 
	// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� 
	// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� 
	// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� 
	// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� 
	// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� 
	// MOD 2011.07.28 ���s�j���� �L���s�̒ǉ��i�����������̒ǉ��j 
	// MOD 2011.08.04 ���s�j���� �L���s�̒ǉ��i�擪�s������Q�Ή��j 
	// MOD 2011.08.11 ���s�j���� �L���s�̒ǉ��i�o�^���t�ȗ�����Q�Ή��j 
	//--------------------------------------------------------------------------
	// MOD 2012.09.26 COA)���R ���t���ڎ捞����
	//                         �i�����ɃX�y�[�X���܂ޏꍇ�C�X�y�[�X���[���ɕϊ����Ď捞�j
	//--------------------------------------------------------------------------
	// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ�
	//--------------------------------------------------------------------------
	// MOD 2016.04.13 BEVAS�j���{ �z�B�w�������̊g��
	//--------------------------------------------------------------------------
	// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή�
	//--------------------------------------------------------------------------
	public class �����o�דo�^ : ���ʃt�H�[��
	{
		private string[] s�捞�f�[�^;
		private string[] s�捞�G���[;
		private bool b�捞          = false;
		private bool b�G���[�o��    = false;
		private string s�Ώۃt�@�C�� = "";
		private short    nOldRow    = 0;
		private int i�捞����		= 0;
		private int i�G���[����		= 0;
// MOD 2009.11.25 ���s�j���� ���Ԏw��`�F�b�N�̒ǉ� START
		private string[] sa���Ԏw��`�F�b�N = {
			"�P�O","�P�P","�P�Q","�P�R","�P�S",
			"�P�T","�P�U","�P�V","�P�W","�P�X",
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX START
//			"�Q�O","�Q�P"
			"�Q�O"
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX END
		};
// MOD 2009.11.25 ���s�j���� ���Ԏw��`�F�b�N�̒ǉ� END
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
		private int i�b�r�u�G���g���[�`�� = 1;
		private enum �`���P {
			�׎�l�b�c, �d�b�ԍ�, �Z��, �Z���Q, �Z���R
			, ���O, ���O�Q, �X�֔ԍ�, ����v, ���X�b�c
			, �ב��l�b�c, ��, �ː�, �d��, �A�����i�P
			, �A�����i�Q, �i���L���P, �i���L���Q, �i���L���R, �z�B�w���
			, ���q�l�Ǘ��ԍ�, �\��, �����敪, �ی����z, �o�ד��t
			, �o�^���t
		};
		private enum �`���Q {
			�׎�l�b�c, �d�b�ԍ�, �Z��, �Z���Q, �Z���R
			, ���O, ���O�Q, �X�֔ԍ�, ����v, ���X�b�c
			, �ב��l�b�c, �ב��S����, ��, �ː�, �d��
			, �A�����i�P, �A�����i�Q, �i���L���P, �i���L���Q, �i���L���R
			, �i���L���S, �i���L���T, �i���L���U, �z�B�w���, �K���敪
			, ���q�l�Ǘ��ԍ�, �����敪, �ی����z, �o�ד��t, �o�^���t
		};
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END

		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab����;
		private System.Windows.Forms.Label lab���q�l��;
		private System.Windows.Forms.Label lab���p����;
		private System.Windows.Forms.TextBox tex���q�l��;
		private System.Windows.Forms.TextBox tex���p����;
		private System.Windows.Forms.TextBox tex���b�Z�[�W;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lab�t�@�C����;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�t�@�C����;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn�J��;
		private System.Windows.Forms.Label lab�����o�דo�^;
		private System.Windows.Forms.OpenFileDialog ofd�����o�דo�^�f�[�^;
		private System.Windows.Forms.Button btn�m�F;
		private System.Windows.Forms.Button btn�捞;
		private System.Windows.Forms.Button btn�ꗗ�\;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblInputCnt;
		private System.Windows.Forms.Label lblErrorCnt;
		private System.Windows.Forms.CheckBox cBox�擪�s����;
		private System.Windows.Forms.Label lab���ߏd��;
		private AxGTABLE32V2Lib.AxGTable32 axGT�捞�f�[�^�ꗗ;

		public �����o�דo�^()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
			�c�o�h�\���T�C�Y�ϊ�();
//			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
				this.axGT�捞�f�[�^�ꗗ.Size = new System.Drawing.Size(696, 220);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(�����o�דo�^));
			this.panel6 = new System.Windows.Forms.Panel();
			this.tex���q�l�� = new System.Windows.Forms.TextBox();
			this.lab���q�l�� = new System.Windows.Forms.Label();
			this.lab���p���� = new System.Windows.Forms.Label();
			this.tex���p���� = new System.Windows.Forms.TextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab���� = new System.Windows.Forms.Label();
			this.lab�����o�דo�^ = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn�ꗗ�\ = new System.Windows.Forms.Button();
			this.tex���b�Z�[�W = new System.Windows.Forms.TextBox();
			this.btn���� = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lab���ߏd�� = new System.Windows.Forms.Label();
			this.cBox�擪�s���� = new System.Windows.Forms.CheckBox();
			this.lblErrorCnt = new System.Windows.Forms.Label();
			this.lblInputCnt = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btn�捞 = new System.Windows.Forms.Button();
			this.axGT�捞�f�[�^�ꗗ = new AxGTABLE32V2Lib.AxGTable32();
			this.btn�m�F = new System.Windows.Forms.Button();
			this.lab�t�@�C���� = new System.Windows.Forms.Label();
			this.tex�t�@�C���� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.btn�J�� = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.ofd�����o�דo�^�f�[�^ = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).BeginInit();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axGT�捞�f�[�^�ꗗ)).BeginInit();
			this.SuspendLayout();
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
			this.panel7.Controls.Add(this.lab�����o�דo�^);
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
			// lab�����o�דo�^
			// 
			this.lab�����o�דo�^.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�����o�דo�^.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�����o�דo�^.ForeColor = System.Drawing.Color.White;
			this.lab�����o�דo�^.Location = new System.Drawing.Point(12, 2);
			this.lab�����o�דo�^.Name = "lab�����o�דo�^";
			this.lab�����o�דo�^.Size = new System.Drawing.Size(264, 24);
			this.lab�����o�דo�^.TabIndex = 0;
			this.lab�����o�דo�^.Text = "�b�r�u�G���g���[";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn�ꗗ�\);
			this.panel8.Controls.Add(this.tex���b�Z�[�W);
			this.panel8.Controls.Add(this.btn����);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 14;
			// 
			// btn�ꗗ�\
			// 
			this.btn�ꗗ�\.ForeColor = System.Drawing.Color.Blue;
			this.btn�ꗗ�\.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�ꗗ�\.Location = new System.Drawing.Point(96, 6);
			this.btn�ꗗ�\.Name = "btn�ꗗ�\";
			this.btn�ꗗ�\.Size = new System.Drawing.Size(62, 48);
			this.btn�ꗗ�\.TabIndex = 8;
			this.btn�ꗗ�\.Text = "�G���[\n�ꗗ�\\n���";
			this.btn�ꗗ�\.Click += new System.EventHandler(this.btn�ꗗ�\_Click);
			// 
			// tex���b�Z�[�W
			// 
			this.tex���b�Z�[�W.BackColor = System.Drawing.Color.PaleGreen;
			this.tex���b�Z�[�W.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���b�Z�[�W.ForeColor = System.Drawing.Color.Red;
			this.tex���b�Z�[�W.Location = new System.Drawing.Point(456, 4);
			this.tex���b�Z�[�W.Multiline = true;
			this.tex���b�Z�[�W.Name = "tex���b�Z�[�W";
			this.tex���b�Z�[�W.ReadOnly = true;
			this.tex���b�Z�[�W.Size = new System.Drawing.Size(334, 50);
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
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lab���ߏd��);
			this.groupBox2.Controls.Add(this.cBox�擪�s����);
			this.groupBox2.Controls.Add(this.lblErrorCnt);
			this.groupBox2.Controls.Add(this.lblInputCnt);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.btn�捞);
			this.groupBox2.Controls.Add(this.axGT�捞�f�[�^�ꗗ);
			this.groupBox2.Controls.Add(this.btn�m�F);
			this.groupBox2.Controls.Add(this.lab�t�@�C����);
			this.groupBox2.Controls.Add(this.tex�t�@�C����);
			this.groupBox2.Controls.Add(this.btn�J��);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(22, 96);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(746, 370);
			this.groupBox2.TabIndex = 17;
			this.groupBox2.TabStop = false;
			// 
			// lab���ߏd��
			// 
			this.lab���ߏd��.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���ߏd��.ForeColor = System.Drawing.Color.Red;
			this.lab���ߏd��.Location = new System.Drawing.Point(436, 336);
			this.lab���ߏd��.Name = "lab���ߏd��";
			this.lab���ߏd��.Size = new System.Drawing.Size(284, 30);
			this.lab���ߏd��.TabIndex = 59;
			this.lab���ߏd��.Text = "�i���d�ʁE�ː��̓��͂͂ł��܂���\n�@�@�d�ʁE�ː��̒l�́u0�v�Ŏ�荞�݂܂��j";
			// 
			// cBox�擪�s����
			// 
			this.cBox�擪�s����.ForeColor = System.Drawing.Color.LimeGreen;
			this.cBox�擪�s����.Location = new System.Drawing.Point(136, 50);
			this.cBox�擪�s����.Name = "cBox�擪�s����";
			this.cBox�擪�s����.Size = new System.Drawing.Size(188, 24);
			this.cBox�擪�s����.TabIndex = 49;
			this.cBox�擪�s����.Text = "�擪�P�s�ڂ͎�荞�܂Ȃ�";
			// 
			// lblErrorCnt
			// 
			this.lblErrorCnt.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lblErrorCnt.ForeColor = System.Drawing.Color.Black;
			this.lblErrorCnt.Location = new System.Drawing.Point(680, 316);
			this.lblErrorCnt.Name = "lblErrorCnt";
			this.lblErrorCnt.Size = new System.Drawing.Size(48, 14);
			this.lblErrorCnt.TabIndex = 48;
			this.lblErrorCnt.Text = "0��";
			this.lblErrorCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblInputCnt
			// 
			this.lblInputCnt.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lblInputCnt.ForeColor = System.Drawing.Color.Black;
			this.lblInputCnt.Location = new System.Drawing.Point(552, 316);
			this.lblInputCnt.Name = "lblInputCnt";
			this.lblInputCnt.Size = new System.Drawing.Size(48, 14);
			this.lblInputCnt.TabIndex = 47;
			this.lblInputCnt.Text = "0��";
			this.lblInputCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.LimeGreen;
			this.label3.Location = new System.Drawing.Point(616, 316);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 46;
			this.label3.Text = "�G���[�����F";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.LimeGreen;
			this.label2.Location = new System.Drawing.Point(488, 316);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 45;
			this.label2.Text = "�捞�����F";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btn�捞
			// 
			this.btn�捞.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�捞.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�捞.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�捞.ForeColor = System.Drawing.Color.White;
			this.btn�捞.Location = new System.Drawing.Point(352, 320);
			this.btn�捞.Name = "btn�捞";
			this.btn�捞.Size = new System.Drawing.Size(80, 32);
			this.btn�捞.TabIndex = 4;
			this.btn�捞.TabStop = false;
			this.btn�捞.Text = "�捞";
			this.btn�捞.Click += new System.EventHandler(this.btn�捞_Click);
			// 
			// axGT�捞�f�[�^�ꗗ
			// 
			this.axGT�捞�f�[�^�ꗗ.ContainingControl = this;
			this.axGT�捞�f�[�^�ꗗ.DataSource = null;
			this.axGT�捞�f�[�^�ꗗ.Location = new System.Drawing.Point(40, 80);
			this.axGT�捞�f�[�^�ꗗ.Name = "axGT�捞�f�[�^�ꗗ";
			this.axGT�捞�f�[�^�ꗗ.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT�捞�f�[�^�ꗗ.OcxState")));
			this.axGT�捞�f�[�^�ꗗ.Size = new System.Drawing.Size(696, 220);
			this.axGT�捞�f�[�^�ꗗ.TabIndex = 3;
			this.axGT�捞�f�[�^�ꗗ.CelDblClick += new AxGTABLE32V2Lib._DGTable32Events_CelDblClickEventHandler(this.axGT�捞�f�[�^�ꗗ_CelDblClick);
			this.axGT�捞�f�[�^�ꗗ.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT�捞�f�[�^�ꗗ_CurPlaceChanged);
			// 
			// btn�m�F
			// 
			this.btn�m�F.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�m�F.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�m�F.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�m�F.ForeColor = System.Drawing.Color.White;
			this.btn�m�F.Location = new System.Drawing.Point(360, 52);
			this.btn�m�F.Name = "btn�m�F";
			this.btn�m�F.Size = new System.Drawing.Size(65, 22);
			this.btn�m�F.TabIndex = 2;
			this.btn�m�F.TabStop = false;
			this.btn�m�F.Text = "���e�m�F";
			this.btn�m�F.Click += new System.EventHandler(this.btn�m�F_Click);
			// 
			// lab�t�@�C����
			// 
			this.lab�t�@�C����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�t�@�C����.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�t�@�C����.Location = new System.Drawing.Point(72, 32);
			this.lab�t�@�C����.Name = "lab�t�@�C����";
			this.lab�t�@�C����.Size = new System.Drawing.Size(60, 14);
			this.lab�t�@�C����.TabIndex = 15;
			this.lab�t�@�C����.Text = "�t�@�C����";
			// 
			// tex�t�@�C����
			// 
			this.tex�t�@�C����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�t�@�C����.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.tex�t�@�C����.Location = new System.Drawing.Point(136, 24);
			this.tex�t�@�C����.MaxLength = 100;
			this.tex�t�@�C����.Name = "tex�t�@�C����";
			this.tex�t�@�C����.Size = new System.Drawing.Size(488, 23);
			this.tex�t�@�C����.TabIndex = 0;
			this.tex�t�@�C����.Text = "";
			// 
			// btn�J��
			// 
			this.btn�J��.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�J��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�J��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�J��.ForeColor = System.Drawing.Color.White;
			this.btn�J��.Location = new System.Drawing.Point(632, 24);
			this.btn�J��.Name = "btn�J��";
			this.btn�J��.Size = new System.Drawing.Size(65, 22);
			this.btn�J��.TabIndex = 1;
			this.btn�J��.TabStop = false;
			this.btn�J��.Text = "�J��";
			this.btn�J��.Click += new System.EventHandler(this.btn�J��_Click);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 370);
			this.label1.TabIndex = 44;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ofd�����o�דo�^�f�[�^
			// 
			this.ofd�����o�דo�^�f�[�^.FileOk += new System.ComponentModel.CancelEventHandler(this.of���͂���f�[�^_FileOk);
			// 
			// �����o�דo�^
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 574);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "�����o�דo�^";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 �b�r�u�G���g���[";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Closed += new System.EventHandler(this.�����o�דo�^_Closed);
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axGT�捞�f�[�^�ꗗ)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			// �w�b�_�[���ڂ̐ݒ�
			tex���q�l��.Text = gs���p�Җ�;
			tex���p����.Text = gs����b�c + " " + gs���喼;

			// �����̏����ݒ�
			lab����.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled = true;

// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� START
			//����X�����擾����Ă��Ȃ��ꍇ�ɂ́A
			if(gs����X���b�c == null || gs����X���b�c.Length == 0){
				gs����X���b�c = ����X���擾(gs����b�c);
			}
// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� END

			// �f�t�H���g�̃t�H���_���f�X�N�g�b�v�t�H���_�ɂ���
			ofd�����o�דo�^�f�[�^.InitialDirectory
				= Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			ofd�����o�דo�^�f�[�^.Filter = "�b�r�u�t�@�C�� (*.csv)|*.csv|���ׂ�(*.*)|*.*";

			axGT�捞�f�[�^�ꗗ.Cols = 26;
			axGT�捞�f�[�^�ꗗ.Rows = 1;
			axGT�捞�f�[�^�ꗗ.ColSep = "|";
			axGT�捞�f�[�^�ꗗ.RowSep = ";";
// MOD 2005.07.15 ���s�j�R�{ ���ږ��̏C�� START
//			axGT�捞�f�[�^�ꗗ.set_RowsText(0, "|�׎�l�R�[�h|�d�b�ԍ�|�Z���P|�Z���Q|�Z���R|���O�P|���O�P|�X�֔ԍ�|����v|���X�R�[�h|�ב��l�R�[�h|��|�ː�|�d��|�A�����i�P|�A�����i�Q|�i���L���P|�i���L���Q|�i���L���R|�\���P|�\���Q|�\���R|�����敪|�ی����z|�o�ד��t|�o�^���t|");
// MOD 2006.10.05 FJCS�j�K�c ���ڂ̕ύX�i�\���P��z�B�w����ɂ���j START
//			axGT�捞�f�[�^�ꗗ.set_RowsText(0, "|�׎�l�R�[�h|�d�b�ԍ�|�Z���P|�Z���Q|�Z���R|���O�P|���O�Q|�X�֔ԍ�|����v|���X�R�[�h|�ב��l�R�[�h|��|�ː�|�d��|�A�����i�P|�A�����i�Q|�i���L���P|�i���L���Q|�i���L���R|�\���P|�\���Q|�\���R|�����敪|�ی����z|�o�ד��t|�o�^���t|");
// MOD 2007.10.25 ���s�j���� ���ڂ̕ύX�i�\���Q�����q�l�Ǘ��ԍ��ɂ���j START
//			axGT�捞�f�[�^�ꗗ.set_RowsText(0, "|�׎�l�R�[�h|�d�b�ԍ�|�Z���P|�Z���Q|�Z���R|���O�P|���O�Q|�X�֔ԍ�|����v|���X�R�[�h|�ב��l�R�[�h|��|�ː�|�d��|�A�����i�P|�A�����i�Q|�i���L���P|�i���L���Q|�i���L���R|�z�B�w���|�\���Q|�\���R|�����敪|�ی����z|�o�ד��t|�o�^���t|");
			axGT�捞�f�[�^�ꗗ.set_RowsText(0, "|�׎�l�R�[�h|�d�b�ԍ�|�Z���P|�Z���Q|�Z���R|���O�P|���O�Q|�X�֔ԍ�|����v|���X�R�[�h|�ב��l�R�[�h|��|�ː�|�d��|�A�����i�P|�A�����i�Q|�i���L���P|�i���L���Q|�i���L���R|�z�B�w���|���q�l�Ǘ��ԍ�|�\���R|�����敪|�ی����z|�o�ד��t|�o�^���t|");
// MOD 2007.10.25 ���s�j���� ���ڂ̕ύX�i�\���Q�����q�l�Ǘ��ԍ��ɂ���j END
// MOD 2006.10.05 FJCS�j�K�c ���ڂ̕ύX�i�\���P��z�B�w����ɂ���j END
// MOD 2005.07.15 ���s�j�R�{ ���ږ��̏C�� END

// MOD 2006.10.05 FJCS�j�K�c ���ڂ̕ύX�i�\���P��z�B�w����ɂ���j START
//			axGT�捞�f�[�^�ꗗ.ColsWidth = "2|7.5|8.5|10|10|10|10|10|7|3|0|7.5|2|3|3|9|9|9|9|9|0|0|0|5|6|6|6|";
//			axGT�捞�f�[�^�ꗗ.ColsAlignHorz = "1|0|0|0|0|0|0|0|1|0|1|0|2|2|2|0|0|0|0|0|0|0|0|1|2|1|1|";
// MOD 2007.10.25 ���s�j���� ���ڂ̕ύX�i�\���Q�����q�l�Ǘ��ԍ��ɂ���j START
//			axGT�捞�f�[�^�ꗗ.ColsWidth = "2|7.5|8.5|10|10|10|10|10|7|3|0|7.5|2|3|3|9|9|9|9|9|6|0|0|5|6|6|6|";
// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� START
//			axGT�捞�f�[�^�ꗗ.ColsWidth = "2|7.5|8.5|14|12|8|11|11|5|3|0|7.5|2.5|3|3|8|8|9|9|8|5|9|0|4|6|4.5|4.5|";
			axGT�捞�f�[�^�ꗗ.ColsWidth = "2|7.5|8.5|14|12|8|11|11|5|3|0|7.5|2.5|3|3|8|8|9|9|8|5|10|0|4|5|4.5|4.5|";
// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� END
// MOD 2007.10.25 ���s�j���� ���ڂ̕ύX�i�\���Q�����q�l�Ǘ��ԍ��ɂ���j END
			axGT�捞�f�[�^�ꗗ.ColsAlignHorz = "1|0|0|0|0|0|0|0|1|0|1|0|2|2|2|0|0|0|0|0|1|0|0|1|2|1|1|";
// MOD 2006.10.05 FJCS�j�K�c ���ڂ̕ύX�i�\���P��z�B�w����ɂ���j END
			axGT�捞�f�[�^�ꗗ.set_CelForeColor(axGT�捞�f�[�^�ꗗ.CaretRow,0,0x98FB98);  //BGR
			axGT�捞�f�[�^�ꗗ.set_CelBackColor(axGT�捞�f�[�^�ꗗ.CaretRow,0,0x006000);
			axGT�捞�f�[�^�ꗗ.MarkingColor = System.Drawing.Color.Red;
			axGT�捞�f�[�^�ꗗ.Clear();
// ADD 2007.02.21 ���s�j���� ������̃J�����ʒu�̒��� START
			axGT�捞�f�[�^�ꗗ.CaretRow = 1;
			axGT�捞�f�[�^�ꗗ.CaretCol = 1;
			axGT�捞�f�[�^�ꗗ_CurPlaceChanged(null,null);
// ADD 2007.02.21 ���s�j���� ������̃J�����ʒu�̒��� END
			axGT�捞�f�[�^�ꗗ.set_CelText(1,0,""); 
			axGT�捞�f�[�^�ꗗ.Rows = 10;
			axGT�捞�f�[�^�ꗗ.set_CelMarking(0,0,false);
			b�捞 = false;
			btn�捞.Enabled = false;
			b�G���[�o�� = false;
			btn�ꗗ�\.Enabled = false;
			s�Ώۃt�@�C�� = "";
// MOD 2006.10.31 FJCS�j�K�c �����\���̃N���A START
			lblInputCnt.Text = "0��";
			lblErrorCnt.Text = "0��";
// MOD 2006.10.31 FJCS�j�K�c �����\���̃N���A END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
			if(gs�d�ʓ��͐��� == "1"){
				lab���ߏd��.Visible = false;
			}else{
				lab���ߏd��.Visible = true;
			}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
			i�b�r�u�G���g���[�`�� = 1;
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lab����.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

		private void btn�J��_Click(object sender, System.EventArgs e)
		{
			ofd�����o�דo�^�f�[�^.ShowDialog();
		}

		private void of���͂���f�[�^_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			tex�t�@�C����.Text = ofd�����o�דo�^�f�[�^.FileName;
		}

		private void btn�m�F_Click(object sender, System.EventArgs e)
		{
			s�Ώۃt�@�C�� = tex�t�@�C����.Text;
			if (s�Ώۃt�@�C��.Trim().Length == 0) return;
 
// ADD 2008.04.11 ACT Vista�Ή� START
			string sErr = "";
// ADD 2008.04.11 ACT Vista�Ή� END

			btn�捞.Enabled = false;
			btn�ꗗ�\.Enabled = false;
// ADD 2006.06.29 ���s�j�R�{ �捞�������G���[�����̕\���Ή� START
			lblInputCnt.Text="0��";
			lblErrorCnt.Text="0��";
// ADD 2006.06.29 ���s�j�R�{ �捞�������G���[�����̕\���Ή� END

// MOD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� START
//			tex���b�Z�[�W.Text = "���s���D�D�D";
			tex���b�Z�[�W.Text = "�b�r�u�t�@�C���Ǎ����D�D�D";

			btn�捞.Refresh();
			btn�ꗗ�\.Refresh();
			lblInputCnt.Refresh();
			lblErrorCnt.Refresh();
			tex���b�Z�[�W.Refresh();
// MOD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� END

			axGT�捞�f�[�^�ꗗ.Clear();
// ADD 2007.02.21 ���s�j���� ������̃J�����ʒu�̒��� START
			axGT�捞�f�[�^�ꗗ.CaretRow = 1;
			axGT�捞�f�[�^�ꗗ.CaretCol = 1;
			axGT�捞�f�[�^�ꗗ_CurPlaceChanged(null,null);
// ADD 2007.02.21 ���s�j���� ������̃J�����ʒu�̒��� END
			axGT�捞�f�[�^�ꗗ.set_CelMarking(0,0,false);
			axGT�捞�f�[�^�ꗗ.set_CelBackColor(0,0,0xFFFFFF);
			if (!System.IO.File.Exists(s�Ώۃt�@�C��))
			{
				tex���b�Z�[�W.Text = "�w�肵���t�@�C�������݂��܂���B";
				axGT�捞�f�[�^�ꗗ.Rows = 10;
				return;
			}
			if (!axGT�捞�f�[�^�ꗗ.LoadCsvFile(s�Ώۃt�@�C��))
			{
				tex���b�Z�[�W.Text = "CSV�t�@�C���̎�荞�݂Ɏ��s���܂���";
				axGT�捞�f�[�^�ꗗ.Rows = 10;
				return;
			}
// MOD 2010.02.25 ���s�j���� �w�b�_�s�������ʋ@�\�̒ǉ� START
			if(axGT�捞�f�[�^�ꗗ.Rows > 0){
				//�w�b�_�s�Ȃ̂Ő擪�s����
				if(axGT�捞�f�[�^�ꗗ.get_CelText(1,1).IndexOf("�׎�l�R�[�h") >= 0
				 && axGT�捞�f�[�^�ꗗ.get_CelText(1,2).IndexOf("�d�b�ԍ�") >= 0
				 && axGT�捞�f�[�^�ꗗ.get_CelText(1,3).IndexOf("�Z��") >= 0){
					cBox�擪�s����.Checked = true;
					cBox�擪�s����.Refresh();
				}
			}
// MOD 2010.02.25 ���s�j���� �w�b�_�s�������ʋ@�\�̒ǉ� END
// MOD 2009.04.06 ���s�j���� �擪�s�����@�\�̒ǉ� START 
			if( cBox�擪�s����.Checked && axGT�捞�f�[�^�ꗗ.Rows > 0){
				int iRet = axGT�捞�f�[�^�ꗗ.DeleteItem(1);
			}
			axGT�捞�f�[�^�ꗗ.Clear();
// MOD 2009.04.06 ���s�j���� �擪�s�����@�\�̒ǉ� END
// ADD 2006.10.05 FJCS�j�K�c ���ڂ̕ύX�i�\���P��z�B�w����ɂ���j START
			StreamReader sr1 = new StreamReader(s�Ώۃt�@�C��, System.Text.Encoding.Default);
// MOD 2011.08.04 ���s�j���� �L���s�̒ǉ��i�擪�s������Q�Ή��j START
			if( cBox�擪�s����.Checked ){
				string sDataDummy1 = sr1.ReadLine();
			}
// MOD 2011.08.04 ���s�j���� �L���s�̒ǉ��i�擪�s������Q�Ή��j END
			string sData1 = sr1.ReadLine();

// ADD 2008.05.14 ���s�j���� Unicode�t�@�C���̉��s�Ή� START
			//UniCode�t�@�C���̉��s�Ή�
			if(sData1 == null) sData1 = "";
// ADD 2008.05.14 ���s�j���� Unicode�t�@�C���̉��s�Ή� END

			string[] sValue1 = sData1.Replace("\"","").Replace("\'","").Split(',');
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
			i�b�r�u�G���g���[�`�� = 1;
			while(sValue1.Length <= 1){
				if(sr1.Peek() == -1) break; // EOF�̎�
				sData1 = sr1.ReadLine();
				if(sData1 != null && sData1 != ""){
					sValue1 = sData1.Split(',');
				}
			}
			if(sValue1.Length != 26 && sValue1.Length != 25
				&& sValue1.Length != 30 && sValue1.Length != 29){
				sr1.Close();
				tex���b�Z�[�W.Text = "���ڐ����Ⴂ�܂��B";
				axGT�捞�f�[�^�ꗗ.Rows = 10;
				return;
			}
			if(sValue1.Length == 30 || sValue1.Length == 29){
				i�b�r�u�G���g���[�`�� = 2;
			}
			sValue1 = null;
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
			sr1.Close();
// ADD 2006.10.05 FJCS�j�K�c ���ڂ̕ύX�i�\���P��z�B�w����ɂ���j END
// ADD 2005.06.02 ���s�j�ɉ� �V�[�g�̍Ē�` START
			axGT�捞�f�[�^�ꗗ.Cols = 26;
// MOD 2006.10.05 FJCS�j�K�c ���ڂ̕ύX�i�\���P��z�B�w����ɂ���j START
//			axGT�捞�f�[�^�ꗗ.set_RowsText(0, "|�׎�l�R�[�h|�d�b�ԍ�|�Z���P|�Z���Q|�Z���R|���O�P|���O�Q|�X�֔ԍ�|����v|���X�R�[�h|�ב��l�R�[�h|��|�ː�|�d��|�A�����i�P|�A�����i�Q|�i���L���P|�i���L���Q|�i���L���R|�\���P|�\���Q|�\���R|�����敪|�ی����z|�o�ד��t|�o�^���t|");
//			axGT�捞�f�[�^�ꗗ.ColsWidth = "2|7.5|8.5|10|10|10|10|10|7|3|0|7.5|2|3|3|9|9|9|9|9|0|0|0|5|6|6|6|";
//			axGT�捞�f�[�^�ꗗ.ColsAlignHorz = "1|0|0|0|0|0|0|0|1|0|1|0|2|2|2|0|0|0|0|0|0|0|0|1|2|1|1|";
// MOD 2007.10.25 ���s�j���� ���ڂ̕ύX�i�\���Q�����q�l�Ǘ��ԍ��ɂ���j START
//			axGT�捞�f�[�^�ꗗ.set_RowsText(0, "|�׎�l�R�[�h|�d�b�ԍ�|�Z���P|�Z���Q|�Z���R|���O�P|���O�Q|�X�֔ԍ�|����v|���X�R�[�h|�ב��l�R�[�h|��|�ː�|�d��|�A�����i�P|�A�����i�Q|�i���L���P|�i���L���Q|�i���L���R|�z�B�w���|�\���Q|�\���R|�����敪|�ی����z|�o�ד��t|�o�^���t|");
//			axGT�捞�f�[�^�ꗗ.ColsWidth = "2|7.5|8.5|10|10|10|10|10|7|3|0|7.5|2|3|3|9|9|9|9|9|6|0|0|5|6|6|6|";
			axGT�捞�f�[�^�ꗗ.set_RowsText(0, "|�׎�l�R�[�h|�d�b�ԍ�|�Z���P|�Z���Q|�Z���R|���O�P|���O�Q|�X�֔ԍ�|����v|���X�R�[�h|�ב��l�R�[�h|��|�ː�|�d��|�A�����i�P|�A�����i�Q|�i���L���P|�i���L���Q|�i���L���R|�z�B�w���|���q�l�Ǘ��ԍ�|�\���R|�����敪|�ی����z|�o�ד��t|�o�^���t|");
// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� START
//			axGT�捞�f�[�^�ꗗ.ColsWidth = "2|7.5|8.5|14|12|8|11|11|5|3|0|7.5|2.5|3|3|8|8|9|9|8|5|9|0|4|6|4.5|4.5|";
			axGT�捞�f�[�^�ꗗ.ColsWidth = "2|7.5|8.5|14|12|8|11|11|5|3|0|7.5|2.5|3|3|8|8|9|9|8|5|10|0|4|5|4.5|4.5|";
// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� END
// MOD 2007.10.25 ���s�j���� ���ڂ̕ύX�i�\���Q�����q�l�Ǘ��ԍ��ɂ���j END
			axGT�捞�f�[�^�ꗗ.ColsAlignHorz = "1|0|0|0|0|0|0|0|1|0|1|0|2|2|2|0|0|0|0|0|1|0|0|1|2|1|1|";
// MOD 2006.10.05 FJCS�j�K�c ���ڂ̕ύX�i�\���P��z�B�w����ɂ���j END
// ADD 2005.06.02 ���s�j�ɉ� �V�[�g�̍Ē�` END
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
		if(i�b�r�u�G���g���[�`�� == 2){
			axGT�捞�f�[�^�ꗗ.Cols = 30;
			axGT�捞�f�[�^�ꗗ.set_RowsText(0, "|�׎�l�R�[�h|�d�b�ԍ�|�Z���P|�Z���Q|�Z���R|���O�P|���O�Q|�X�֔ԍ�|����v|���X�R�[�h|�ב��l�R�[�h|�ב��S����|��|�ː�|�d��|�A�����i�P|�A�����i�Q|�i���L���P|�i���L���Q|�i���L���R|�i���L���S|�i���L���T|�i���L���U|�z�B�w���|�K���敪|���q�l�Ǘ��ԍ�|�����敪|�ی����z|�o�ד��t|�o�^���t|");
			axGT�捞�f�[�^�ꗗ.ColsWidth = "2|7.5|8.5|14|12|8|11|11|5|3|0|7.5|7.5|2.5|3|3|8|8|9|9|8|8|8|8|5|4|10|4|5|4.5|4.5|";
			axGT�捞�f�[�^�ꗗ.ColsAlignHorz = "1|0|0|0|0|0|0|0|1|0|1|0|0|2|2|2|0|0|0|0|0|0|0|0|1|1|0|1|2|1|1|";
		}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END

			StreamReader sr = new StreamReader(s�Ώۃt�@�C��, System.Text.Encoding.Default);
// MOD 2009.04.06 ���s�j���� �擪�s�����@�\�̒ǉ� START 
			if( cBox�擪�s����.Checked ){
				string sDataDummy = sr.ReadLine();
			}
// MOD 2009.04.06 ���s�j���� �擪�s�����@�\�̒ǉ� END
			axGT�捞�f�[�^�ꗗ.CaretRow = 1;
			axGT�捞�f�[�^�ꗗ.set_CelForeColor(nOldRow,0,0);
			axGT�捞�f�[�^�ꗗ.set_CelBackColor(nOldRow,0,0xFFFFFF);
			axGT�捞�f�[�^�ꗗ.set_CelForeColor(axGT�捞�f�[�^�ꗗ.CaretRow,0,0x98FB98);  //BGR
			axGT�捞�f�[�^�ꗗ.set_CelBackColor(axGT�捞�f�[�^�ꗗ.CaretRow,0,0x006000);
			nOldRow = axGT�捞�f�[�^�ꗗ.CaretRow;
			try
			{
				s�捞�f�[�^ = new string[(int)axGT�捞�f�[�^�ꗗ.Rows];
				s�捞�G���[ = new string[(int)axGT�捞�f�[�^�ꗗ.Rows];
				b�捞 = true;
				b�G���[�o�� = false;
// MOD 2006.06.29 ���s�j�R�{ �捞�������G���[�����̕\���Ή� START
//				int i�捞���� = (int)axGT�捞�f�[�^�ꗗ.Rows;
				i�捞���� = (int)axGT�捞�f�[�^�ꗗ.Rows;
				i�G���[���� = 0;
// MOD 2006.06.29 ���s�j�R�{ �捞�������G���[�����̕\���Ή� END
				if (axGT�捞�f�[�^�ꗗ.Rows < 10) axGT�捞�f�[�^�ꗗ.Rows = 10;

//�ۗ� MOD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� START
//�ۗ� MOD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� END
// ADD 2005.06.02 ���s�j�ɉ� ���e�m�F���������� START
				����o�ד����X�V();
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				string[] sRet = {""};
				string s���X�b�c   = "";
				string s���X��     = "";
				string s�W��X�b�c = "";
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� START
				//�Г��`����̈��X�o�^�`�F�b�N
				if(gs����X���b�c.Equals("044"))
				{
					string[] saChkRet = �b�l�O�T������X�e�`�F�b�N();
					int iChkRet = int.Parse(saChkRet[0]);
					string sChkRet = saChkRet[1];
					if(iChkRet ==1)
					{
						//�ُ�I����
						string s���b�Z�[�W =
							"�����p�̉���Ɉ��X�o�^���Ȃ��ׁA�o�דo�^�ł��܂���B\n" +
							"���R�ʉ^�̉c�Ɩ{���ւ��₢���킹�������B\n" +
							"�@�@�@�y�`�F�b�N�Ώۉ���z " + gs����b�c;
						MessageBox.Show(this, s���b�Z�[�W, "���X�`�F�b�N", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						if(sChkRet.Equals("�Y���f�[�^������܂���"))
						{
							throw new Exception("�����p�̉���Ɉ��X�o�^������܂���ł���");
						}
						else
						{
							throw new Exception(sChkRet);
						}
					}
				}
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� END
				//���X�擾
				try
				{
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� START
					if(gs����X���b�c.Equals("044"))
					{
						//�Г��`��������́A���X���擾
						if(gs����b�c.Substring(0,1) != "J")
						{
							//���R�ʉ^����
							if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
							sRet = sv_syukka.Get_hatuten2_HouseSlip(gsa���[�U,gs����b�c);
						}
					}
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� END
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� START
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� START
//					if (gs����b�c.Substring(0,1) != "J")
					else if (gs����b�c.Substring(0,1) != "J")
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� END
					{
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END
						if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
						sRet = sv_syukka.Get_hatuten2(gsa���[�U,gs����b�c,gs����b�c);
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� START
					}
					else
					{
						if(sv_oji == null) sv_oji = new is2oji.Service1();
						sRet = sv_oji.Get_hatuten2(gsa���[�U,gs����b�c,gs����b�c);
					}
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END
				}
				catch (System.Net.WebException)
				{
					throw new Exception(gs�ʐM�G���[);
				}
				catch (Exception ex)
				{
					throw new Exception("�ʐM�G���[�F" + ex.Message);
				}
				if(sRet[0].Equals("����I��"))
				{
					s���X�b�c = sRet[1];	//���X�b�c
					s���X��   = sRet[2];	//���X��
					if (s���X��.Length == 0) s���X�� = " ";
				}
				else
				{
					if(sRet[0].Equals("�Y���f�[�^������܂���"))
						throw new Exception("���X�����߂��܂���ł���");
					else
						throw new Exception(sRet[0]);
				}
				//�W��X�擾
				try
				{
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� START
					if(gs����X���b�c.Equals("044"))
					{
						//�Г��`��������́A�W��X���擾
						if(gs����b�c.Substring(0,1) != "J")
						{
							//���R�ʉ^����
							if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
							sRet = sv_syukka.Get_syuuyakuten2_HouseSlip(gsa���[�U,gs����b�c);
						}
					}
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� END
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� START
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� START
//					if (gs����b�c.Substring(0,1) != "J")
					else if (gs����b�c.Substring(0,1) != "J")
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� END
					{
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END
					if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
					sRet = sv_syukka.Get_syuuyakuten2(gsa���[�U,gs����b�c,gs����b�c);
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� START
					}
					else
					{
						if(sv_oji == null) sv_oji = new is2oji.Service1();
						sRet = sv_oji.Get_syuuyakuten2(gsa���[�U,gs����b�c,gs����b�c);
					}
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END
				}
				catch (System.Net.WebException)
				{
					throw new Exception(gs�ʐM�G���[);
				}
				catch (Exception ex)
				{
					throw new Exception("�ʐM�G���[�F" + ex.Message);
				}
				if(sRet[0] != " ")
				{
					s�W��X�b�c = sRet[1];	//�W��X�b�c
				}
				else
				{
					if(sRet[0].Equals("�Y���f�[�^������܂���"))
						throw new Exception("�W��X�����߂��܂���ł���");
					else
						throw new Exception(sRet[0]);
				}
// ADD 2005.06.02 ���s�j�ɉ� ���e�m�F���������� END

// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX START
				string sChkMsg = "";
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX END
				for (int iCnt = 1; iCnt <= i�捞����; iCnt++)
				{
// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� START
					tex���b�Z�[�W.Text = "���e�m�F���D�D�D" + iCnt + "����";
					tex���b�Z�[�W.Refresh();
// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� END
// MOD 2010.03.18 ���s�j���� �f�[�^�����`�F�b�N�̒ǉ� START
//					axGT�捞�f�[�^�ꗗ.set_CelText((short)iCnt,0, iCnt.ToString()); 
// MOD 2010.03.18 ���s�j���� �f�[�^�����`�F�b�N�̒ǉ� END
					string sData = sr.ReadLine();

// ADD 2008.05.14 ���s�j���� Unicode�t�@�C���̉��s�Ή� START
					//UniCode�̉��s�Ή�
					if(sData == null){
						sData = "";
//						break;	//���捞�����ɊԈႢ����������
					}
// ADD 2008.05.14 ���s�j���� Unicode�t�@�C���̉��s�Ή� END

// MOD 2005.09.15 ���s�j�ɉ� "' ���폜 START
//					string[] sValue = sData.Replace("\"", "").Split(',');
					string[] sValue = sData.Replace("\"","").Replace("\'","").Split(',');
// MOD 2010.03.18 ���s�j���� �f�[�^�����`�F�b�N�̒ǉ� START
					if (sValue.Length <= 1) continue;
//�ۗ� MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� START
//					// �ː��E�d�ʂɂO��ݒ�
//					if(sValue.Length > 12) sValue[12] = "0";
//					if(sValue.Length > 13) sValue[13] = "0";
//�ۗ� MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� END
					//�s���\��
					axGT�捞�f�[�^�ꗗ.set_CelText((short)iCnt,0, iCnt.ToString()); 
// MOD 2010.03.18 ���s�j���� �f�[�^�����`�F�b�N�̒ǉ� END
					for (int i = 0; i < sValue.Length; i++)
					{
						axGT�捞�f�[�^�ꗗ.set_CelText((short)iCnt, (short)(i+1), sValue[i]);
					}
// MOD 2005.09.15 ���s�j�ɉ� "' ���폜 END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
//// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� START
//					// �ː��E�d�ʂɂO��ݒ�
//					axGT�捞�f�[�^�ꗗ.set_CelText((short)iCnt, (short)(12+1), "0");
//					axGT�捞�f�[�^�ꗗ.set_CelText((short)iCnt, (short)(13+1), "0");
//// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� END
//					string[] sKey   = new string[46];
					if(gs�d�ʓ��͐��� != "1"){
						// �ː��E�d�ʂɂO��ݒ�
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
						if(i�b�r�u�G���g���[�`�� == 2){
							axGT�捞�f�[�^�ꗗ.set_CelText((short)iCnt, (short)((int)�`���Q.�ː�+1), "0");
							axGT�捞�f�[�^�ꗗ.set_CelText((short)iCnt, (short)((int)�`���Q.�d��+1), "0");
						}else{
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
							axGT�捞�f�[�^�ꗗ.set_CelText((short)iCnt, (short)(12+1), "0");
							axGT�捞�f�[�^�ꗗ.set_CelText((short)iCnt, (short)(13+1), "0");
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
						}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
					}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
//					string[] sKey   = new string[47];
					string[] sKey = null;
					if(i�b�r�u�G���g���[�`�� == 2){
						sKey = new string[50];
					}else{
						sKey = new string[47];
					}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
					sKey[46] = gs�d�ʓ��͐���;
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
// MOD 2010.02.25 ���s�j���� ���ڐ��`�F�b�N�̏C�� START
//					if (sValue.Length != 26)
//					{
//						�G���[�o��(iCnt, 0, "���ڐ����Ⴂ�܂�\r\n");
//						continue;
//					}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
//					if (sValue.Length != 26 && sValue.Length != 25){
					if (sValue.Length != 26 && sValue.Length != 25
						&& sValue.Length != 30 && sValue.Length != 29){
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
						�G���[�o��(iCnt, 0, "���ڐ����Ⴂ�܂�\r\n");
						continue;
					}
// MOD 2010.02.25 ���s�j���� ���ڐ��`�F�b�N�̏C�� END
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
					string[] sValue�ꗗ�s = new string[sValue.Length];
					if(i�b�r�u�G���g���[�`�� == 2){
						System.Array.Copy(sValue, sValue�ꗗ�s, sValue.Length);
//						for(int iCnt�ꗗ�s = 0; iCnt�ꗗ�s < sValue.Length; iCnt�ꗗ�s++){
//							sValue�ꗗ�s[iCnt�ꗗ�s] = sValue[iCnt�ꗗ�s];
//						}
						sValue[(int)�`���P.��] = sValue�ꗗ�s[(int)�`���Q.��];
						sValue[(int)�`���P.�ː�] = sValue�ꗗ�s[(int)�`���Q.�ː�];
						sValue[(int)�`���P.�d��] = sValue�ꗗ�s[(int)�`���Q.�d��];
						sValue[(int)�`���P.�A�����i�P] = sValue�ꗗ�s[(int)�`���Q.�A�����i�P];
						sValue[(int)�`���P.�A�����i�Q] = sValue�ꗗ�s[(int)�`���Q.�A�����i�Q];
						sValue[(int)�`���P.�i���L���P] = sValue�ꗗ�s[(int)�`���Q.�i���L���P];
						sValue[(int)�`���P.�i���L���Q] = sValue�ꗗ�s[(int)�`���Q.�i���L���Q];
						sValue[(int)�`���P.�i���L���R] = sValue�ꗗ�s[(int)�`���Q.�i���L���R];
						sValue[(int)�`���P.�z�B�w���] = sValue�ꗗ�s[(int)�`���Q.�z�B�w���];
						sValue[(int)�`���P.���q�l�Ǘ��ԍ�] = sValue�ꗗ�s[(int)�`���Q.���q�l�Ǘ��ԍ�];
						sValue[(int)�`���P.�\��] = "";
						sValue[(int)�`���P.�����敪] = sValue�ꗗ�s[(int)�`���Q.�����敪];
						sValue[(int)�`���P.�ی����z] = sValue�ꗗ�s[(int)�`���Q.�ی����z];
						sValue[(int)�`���P.�o�ד��t] = sValue�ꗗ�s[(int)�`���Q.�o�ד��t];
// MOD 2011.08.11 ���s�j���� �L���s�̒ǉ��i�o�^���t�ȗ�����Q�Ή��j  START
//						sValue[(int)�`���P.�o�^���t] = sValue�ꗗ�s[(int)�`���Q.�o�^���t];
						if(sValue�ꗗ�s.Length > (int)�`���Q.�o�^���t){
							sValue[(int)�`���P.�o�^���t] = sValue�ꗗ�s[(int)�`���Q.�o�^���t];
						}else{
							sValue[(int)�`���P.�o�^���t] = "";
						}
// MOD 2011.08.11 ���s�j���� �L���s�̒ǉ��i�o�^���t�ȗ�����Q�Ή��j  END
					}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
					sKey[0] = gs����b�c;
					sKey[1] = gs����b�c;
					sKey[3] = " ";

					//�׎�l�R�[�h
					sKey[5]  = " ";				//�d�b�ԍ��P
					sKey[6]  = " ";				//�d�b�ԍ��Q
					sKey[7]  = " ";				//�d�b�ԍ��R
					sKey[9]  = " ";				//�Z���P
					sKey[10] = " ";				//�Z���Q
					sKey[11] = " ";				//�Z���R
					sKey[12] = " ";				//���O�P
					sKey[13] = " ";				//���O�Q
					sKey[14] = " ";				//�X�֔ԍ�
					sKey[17] = " ";				//����v
					sValue[0] = sValue[0].Trim();
					if(sValue[0].Length != 0)
					{
						if(!���p�`�F�b�N(sValue[0])) �G���[�o��(iCnt, 1, "�׎�l�R�[�h�͔��p�����œ��͂��Ă�������\r\n");
						sKey[4] = sValue[0];
						if(���p�`�F�b�N(sValue[0]))
						{
// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
							if(!�L���`�F�b�N(sValue[0])){
								�G���[�o��(iCnt, 1, "�׎�l�R�[�h�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
							}else{
// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END
								//�׎�l�R�[�h���݃`�F�b�N
								try
								{
									if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
//�ۗ� MOD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� START
//�ۗ� MOD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� END
									sRet = sv_otodoke.Get_Stodokesaki(gsa���[�U,gs����b�c,gs����b�c,sKey[4]);
								}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
								catch (System.Net.WebException)
								{
									throw new Exception(gs�ʐM�G���[);
								}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
								catch (Exception ex)
								{
									throw new Exception("�ʐM�G���[�F" + ex.Message);
								}
//�ۗ� MOD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� START
//�ۗ� MOD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� END
								if(!sRet[0].Equals("�X�V"))
								{
									if(sRet[0].Equals("�o�^"))
									{
										�G���[�o��(iCnt, 1, "�׎�l�R�[�h�����݂��܂���\r\n");
									}
									else
									{
										throw new Exception(sRet[0]);
									}
								}
								else
								{
									sKey[5]  = sRet[2];				//�d�b�ԍ��P
									if (sKey[5].Length == 0) sKey[5] = " ";
									sKey[6]  = sRet[3];				//�d�b�ԍ��Q
									if (sKey[6].Length == 0) sKey[6] = " ";
									sKey[7]  = sRet[4];				//�d�b�ԍ��R
									if (sKey[7].Length == 0) sKey[7] = " ";
									sKey[9]  = sRet[7];				//�Z���P
									if (sKey[9].Length == 0) sKey[9] = " ";
									sKey[10] = sRet[8];				//�Z���Q
									if (sKey[10].Length == 0) sKey[10] = " ";
									sKey[11] = sRet[9];				//�Z���R
									if (sKey[11].Length == 0) sKey[11] = " ";
									sKey[12] = sRet[10];			//���O�P
									if (sKey[12].Length == 0) sKey[12] = " ";
									sKey[13] = sRet[11];			//���O�Q
									if (sKey[13].Length == 0) sKey[13] = " ";
									sKey[14] = sRet[5] + sRet[6];	//�X�֔ԍ�
									sKey[17] = sRet[12];			//����v
									if (sKey[17].Length == 0) sKey[17] = " ";
									if (sKey[14].Length != 0)
									{
										//�Z�����݃`�F�b�N
										try
										{
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� START
												if (gs����b�c.Substring(0,1) != "J")
												{
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END
											if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
// MOD 2008.12.25 kcl)�X�{ ���X�R�[�h�������@�̍ĕύX START
//// ADD 2008.06.12 kcl)�X�{ ���X�R�[�h�������@�̕ύX START
////										sRet = sv_syukka.Get_autoEntryPref(gsa���[�U,sKey[14]);
//										sRet = sv_syukka.Get_autoEntryPref3(gsa���[�U, sKey[0], sKey[1], sKey[4], sKey[14], sKey[9] + sKey[10] + sKey[11]);
//// ADD 2008.06.12 kcl)�X�{ ���X�R�[�h�������@�̕ύX END
											sRet = sv_syukka.Get_autoEntryPref3(gsa���[�U, sKey[0], sKey[1], sKey[4], sKey[14], sKey[9] + sKey[10] + sKey[11], sKey[12] + sKey[13]);
// MOD 2008.12.25 kcl)�X�{ ���X�R�[�h�������@�̍ĕύX START
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� START
												}
												else
												{
													if(sv_oji == null) sv_oji = new is2oji.Service1();
													sRet = sv_oji.Get_autoEntryPref3(gsa���[�U, sKey[0], sKey[1], sKey[4], sKey[14], sKey[9] + sKey[10] + sKey[11], sKey[12] + sKey[13]);
												}
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END
										}
										catch (System.Net.WebException)
										{
											throw new Exception(gs�ʐM�G���[);
										}
										catch (Exception ex)
										{
											throw new Exception("�ʐM�G���[�F" + ex.Message);
										}
										if(sRet[0].Length != 4)
										{
											if(sRet[0].Equals("�Y���f�[�^������܂���"))
											{
												�G���[�o��(iCnt, 1, "�X�֔ԍ������݂��܂���\r\n");
											}
											else
											{
												throw new Exception(sRet[0]);
											}
										}
										else
										{
											sKey[15] = sRet[2];	//���X�b�c
											sKey[16] = sRet[3];	//���X��
											if (sKey[16].Length == 0) sKey[16] = " ";
											sKey[8]  = sRet[1];	//�Z���b�c
// MOD 2008.11.19 ���s�j���� ���X�R�[�h���󔒂ł��G���[�łȂ����� START
//										if (sKey[15].Trim().Length == 0) �G���[�o��(iCnt, 1, "�z�B�X�����߂��܂���ł���\r\n");
// MOD 2008.11.19 ���s�j���� ���X�R�[�h���󔒂ł��G���[�łȂ����� END
										}
									}
									else
									{
										sKey[14] = " ";
									}
								}
// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
							}
// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END
						}
					}
					else
					{
						sKey[4] = " ";
					}

					//�d�b�ԍ�
					sValue[1] = sValue[1].Trim();
					if (sKey[4].Trim().Length == 0 && !�K�{�`�F�b�N(sValue[1])) �G���[�o��(iCnt, 2, "�d�b�ԍ��͕K�{���ڂł�\r\n");
					if (sValue[1].Length != 0)
					{
						try
						{
							if (!���p�`�F�b�N(sValue[1])) �G���[�o��(iCnt, 2, "�d�b�ԍ��͔��p�����œ��͂��Ă�������\r\n");
							if (sValue[1].IndexOf("(") == -1 && sValue[1].LastIndexOf(")") == -1)
							{
								if (sValue[1].IndexOf("-") == sValue[1].LastIndexOf("-") && sValue[1].IndexOf("-") != -1)
								{
									sKey[5] = " ";
									sKey[6] = sValue[1].Substring(0, sValue[1].IndexOf("-"));
									sKey[7] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
									if (!���l�`�F�b�N(sKey[6]) || !���l�`�F�b�N(sKey[7]))
										�G���[�o��(iCnt, 2, "�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
								}
								else if (sValue[1].IndexOf("-") != sValue[1].LastIndexOf("-") && sValue[1].IndexOf("-") != -1)
								{
									sKey[5] = sValue[1].Substring(0, sValue[1].IndexOf("-"));
									sKey[6] = sValue[1].Substring(sValue[1].IndexOf("-") + 1, sValue[1].LastIndexOf("-") - sValue[1].IndexOf("-") - 1);
									sKey[7] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
									if (!���l�`�F�b�N(sKey[5]) || !���l�`�F�b�N(sKey[6]) || !���l�`�F�b�N(sKey[7]))
										�G���[�o��(iCnt, 2, "�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
								}
// ADD 2005.09.15 ���s�j�ɉ� �d�b�ԍ��`���ǉ��Ή� START
								else if (sValue[1].Length == 9)
								{
									//�d�b�ԍ��X��
									if (sValue[1].Substring(0,1).Equals("3") || sValue[1].Substring(0,1).Equals("6"))
									{
										//�����A���� 1-4-4�ŕҏW
										sKey[5] = sValue[1].Substring(0,1);
										sKey[6] = sValue[1].Substring(1,4);
										sKey[7] = sValue[1].Substring(5,4);
									}
									else
									{
										//����ȊO��3-2-4�ŕҏW
										sKey[5] = sValue[1].Substring(0,3);
										sKey[6] = sValue[1].Substring(3,2);
										sKey[7] = sValue[1].Substring(5,4);
									}
									if (!���l�`�F�b�N(sKey[5]) || !���l�`�F�b�N(sKey[6]) || !���l�`�F�b�N(sKey[7]))
										�G���[�o��(iCnt, 2, "�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
								}
								else if (sValue[1].Length == 10)
								{
									//�d�b�ԍ��P�O��
									if (sValue[1].Substring(0,2).Equals("03") || sValue[1].Substring(0,2).Equals("06"))
									{
										//�����A���� 2-4-4�ŕҏW
										sKey[5] = sValue[1].Substring(0,2);
										sKey[6] = sValue[1].Substring(2,4);
										sKey[7] = sValue[1].Substring(6,4);
									}
									else
									{
										//����ȊO��4-2-4�ŕҏW
										sKey[5] = sValue[1].Substring(0,4);
										sKey[6] = sValue[1].Substring(4,2);
										sKey[7] = sValue[1].Substring(6,4);
									}
									if (!���l�`�F�b�N(sKey[5]) || !���l�`�F�b�N(sKey[6]) || !���l�`�F�b�N(sKey[7]))
										�G���[�o��(iCnt, 2, "�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
								}
								else if (sValue[1].Length == 11)
								{
									//�d�b�ԍ��P�P��
// MOD 2010.03.30 ���s�j���� �g�ѓd�b�Ή� START
									if(sValue[1].Substring(0,3).Equals("090")
									 || sValue[1].Substring(0,3).Equals("080")
									 || sValue[1].Substring(0,3).Equals("070")
									 || sValue[1].Substring(0,3).Equals("050")){
										//�g�ѓd�b�� 3-4-4�ŕҏW
										sKey[5] = sValue[1].Substring(0,3);
										sKey[6] = sValue[1].Substring(3,4);
										sKey[7] = sValue[1].Substring(7,4);
									}else{
// MOD 2010.03.30 ���s�j���� �g�ѓd�b�Ή� END
										//4-3-4�ŕҏW
										sKey[5] = sValue[1].Substring(0,4);
										sKey[6] = sValue[1].Substring(4,3);
										sKey[7] = sValue[1].Substring(7,4);
// MOD 2010.03.30 ���s�j���� �g�ѓd�b�Ή� START
									}
// MOD 2010.03.30 ���s�j���� �g�ѓd�b�Ή� END
									if (!���l�`�F�b�N(sKey[5]) || !���l�`�F�b�N(sKey[6]) || !���l�`�F�b�N(sKey[7]))
										�G���[�o��(iCnt, 2, "�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
								}
								else if (sValue[1].Length == 12)
								{
									//�d�b�ԍ��P�Q��
									//4-4-4�ŕҏW
									sKey[5] = sValue[1].Substring(0,4);
									sKey[6] = sValue[1].Substring(4,4);
									sKey[7] = sValue[1].Substring(8,4);
									if (!���l�`�F�b�N(sKey[5]) || !���l�`�F�b�N(sKey[6]) || !���l�`�F�b�N(sKey[7]))
										�G���[�o��(iCnt, 2, "�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
								}
// ADD 2005.09.15 ���s�j�ɉ� �d�b�ԍ��`���ǉ��Ή� END
								else
								{
									�G���[�o��(iCnt, 2, "�d�b�ԍ��̌`���Ɍ�肪����܂�\r\n");
								}
							}
							else if (sValue[1].IndexOf("(") != -1 && sValue[1].LastIndexOf(")") != -1)
							{
								sKey[5] = sValue[1].Substring(sValue[1].IndexOf("(") + 1, sValue[1].LastIndexOf(")") - sValue[1].IndexOf("(") - 1);
								sKey[6] = sValue[1].Substring(sValue[1].IndexOf(")") + 1, sValue[1].LastIndexOf("-") - sValue[1].IndexOf(")") - 1);
								sKey[7] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
								if (!���l�`�F�b�N(sKey[5]) || !���l�`�F�b�N(sKey[6]) || !���l�`�F�b�N(sKey[7]))
									�G���[�o��(iCnt, 2, "�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
							}
							else
							{
								�G���[�o��(iCnt, 2, "�d�b�ԍ��̌`���Ɍ�肪����܂�\r\n");
							}
							if (sKey[5].Length > 6) �G���[�o��(iCnt, 2, "�d�b�ԍ�(�s�O)�͂U�����ȓ��œ��͂��Ă�������\r\n");
							if (sKey[6].Length > 4) �G���[�o��(iCnt, 2, "�d�b�ԍ�(�s��)�͂S�����ȓ��œ��͂��Ă�������\r\n");
							if (sKey[7].Length > 4) �G���[�o��(iCnt, 2, "�d�b�ԍ�(�ԍ�)�͂S�����ȓ��œ��͂��Ă�������\r\n");
						}
						catch
						{
							�G���[�o��(iCnt, 2, "�d�b�ԍ��̌`���Ɍ�肪����܂�\r\n");
						}
					}
					
					//�Z��
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//					sValue[2] = sValue[2].Trim();
//					sValue[3] = sValue[3].Trim();
//					sValue[4] = sValue[4].Trim();
					if(gs�I�v�V����[18].Equals("1")){
						sValue[2] = sValue[2].TrimEnd();
						sValue[3] = sValue[3].TrimEnd();
						sValue[4] = sValue[4].TrimEnd();
					}else{
						sValue[2] = sValue[2].Trim();
						sValue[3] = sValue[3].Trim();
						sValue[4] = sValue[4].Trim();
					}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
					if (sValue[2].Length != 0 || sValue[3].Length != 0 || sValue[4].Length != 0)
					{
						if (!�K�{�`�F�b�N(sValue[2])) �G���[�o��(iCnt, 3, "�Z���P�͕K�{���ڂł�\r\n");
// ADD 2008.04.11 ACT Vista�Ή� START
						if (sValue[2].Length != 0)
						{
							if (!�����ϊ�_CSV(ref sValue[2], ref sErr))
							{
								�G���[�o��(iCnt, 3, "�Z���P��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}
							else
							{
								�����ϊ���o��(iCnt, 3, sValue[2]);
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� START
							if(!�S�p�ϊ��`�F�b�N(ref sValue[2], ref sErr)){
								�G���[�o��(iCnt, 3, "�Z���P�͑S�p�����ϊ��������Ȃ��܂���ł���"
													 + "�w" + sErr + "�x\r\n");
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� END
						}
						if (sValue[3].Length != 0)
						{
							if (!�����ϊ�_CSV(ref sValue[3], ref sErr))
							{
								�G���[�o��(iCnt, 4, "�Z���Q��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}
							else
							{
								�����ϊ���o��(iCnt, 4, sValue[3]);
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� START
							if(!�S�p�ϊ��`�F�b�N(ref sValue[3], ref sErr)){
								�G���[�o��(iCnt, 4, "�Z���Q�͑S�p�����ϊ��������Ȃ��܂���ł���"
													 + "�w" + sErr + "�x\r\n");
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� END
						}
						if (sValue[4].Length != 0)
						{
							if (!�����ϊ�_CSV(ref sValue[4], ref sErr))
							{
								�G���[�o��(iCnt, 5, "�Z���R��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}
							else
							{
								�����ϊ���o��(iCnt, 5, sValue[4]);
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� START
							if(!�S�p�ϊ��`�F�b�N(ref sValue[4], ref sErr)){
								�G���[�o��(iCnt, 5, "�Z���R�͑S�p�����ϊ��������Ȃ��܂���ł���"
													 + "�w" + sErr + "�x\r\n");
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� END
						}
// ADD 2008.04.11 ACT Vista�Ή� END
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� START
//						sValue[2] = Microsoft.VisualBasic.Strings.StrConv(sValue[2], Microsoft.VisualBasic.VbStrConv.Wide, 0);
//						sValue[3] = Microsoft.VisualBasic.Strings.StrConv(sValue[3], Microsoft.VisualBasic.VbStrConv.Wide, 0);
//						sValue[4] = Microsoft.VisualBasic.Strings.StrConv(sValue[4], Microsoft.VisualBasic.VbStrConv.Wide, 0);
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� END
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� START
//						sValue[2] = sValue[2].Replace('\\','��');
//						sValue[3] = sValue[3].Replace('\\','��');
//						sValue[4] = sValue[4].Replace('\\','��');
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� END
						//�S�p�Q�O���𒴂��鍀�ڂ�����ꍇ�������čĕ��z
						if (sValue[2].Length > 20 || sValue[3].Length > 20 || sValue[4].Length > 20)
						{
							string s�Z�� = sValue[2] + sValue[3] + sValue[4];
							sKey[9] = s�Z��.Substring(0, 20);
							if (s�Z��.Length <= 40)
								sKey[10] = s�Z��.Substring(20);
							else
							{
								sKey[10] = s�Z��.Substring(20, 20);
								if (s�Z��.Length <= 60)
									sKey[11] = s�Z��.Substring(40);
								else
									sKey[11] = s�Z��.Substring(40, 20);
							}
						}
						else
						{
							sKey[9]  = sValue[2];
							sKey[10] = sValue[3];
							sKey[11] = sValue[4];
						}
						if (sKey[9].Length == 0)  sKey[9]  = " ";
						if (sKey[10].Length == 0) sKey[10] = " ";
						if (sKey[11].Length == 0) sKey[11] = " ";
					}
					else if (sKey[4].Trim().Length == 0) �G���[�o��(iCnt, 3, "�Z���P�͕K�{���ڂł�\r\n");

					//���O
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//					sValue[5] = sValue[5].Trim();
//					sValue[6] = sValue[6].Trim();
					if(gs�I�v�V����[18].Equals("1")){
						sValue[5] = sValue[5].TrimEnd();
						sValue[6] = sValue[6].TrimEnd();
					}else{
						sValue[5] = sValue[5].Trim();
						sValue[6] = sValue[6].Trim();
					}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
					if (sValue[5].Length != 0 || sValue[6].Length != 0)
					{
						if (!�K�{�`�F�b�N(sValue[5])) �G���[�o��(iCnt, 6, "���O�P�͕K�{���ڂł�\r\n");
// ADD 2008.04.11 ACT Vista�Ή� START
						if (sValue[5].Length != 0)
						{
							if (!�����ϊ�_CSV(ref sValue[5], ref sErr))
							{
								�G���[�o��(iCnt, 6, "���O�P��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}
							else
							{
								�����ϊ���o��(iCnt, 6, sValue[5]);
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� START
							if(!�S�p�ϊ��`�F�b�N(ref sValue[5], ref sErr)){
								�G���[�o��(iCnt, 6, "���O�P�͑S�p�����ϊ��������Ȃ��܂���ł���"
													 + "�w" + sErr + "�x\r\n");
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� END
						}
						if (sValue[6].Length != 0)
						{
							if (!�����ϊ�_CSV(ref sValue[6], ref sErr))
							{
								�G���[�o��(iCnt, 7, "���O�Q��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}
							else
							{
								�����ϊ���o��(iCnt, 7, sValue[6]);
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� START
							if(!�S�p�ϊ��`�F�b�N(ref sValue[6], ref sErr)){
								�G���[�o��(iCnt, 7, "���O�Q�͑S�p�����ϊ��������Ȃ��܂���ł���"
													 + "�w" + sErr + "�x\r\n");
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� END
						}
// ADD 2008.04.11 ACT Vista�Ή� END
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� START
//						sValue[5] = Microsoft.VisualBasic.Strings.StrConv(sValue[5], Microsoft.VisualBasic.VbStrConv.Wide, 0);
//						sValue[6] = Microsoft.VisualBasic.Strings.StrConv(sValue[6], Microsoft.VisualBasic.VbStrConv.Wide, 0);
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� END
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� START
//						sValue[5] = sValue[5].Replace('\\','��');
//						sValue[6] = sValue[6].Replace('\\','��');
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� END
						//�S�p�Q�O���𒴂��鍀�ڂ�����ꍇ�������čĕ��z
						if (sValue[5].Length > 20 || sValue[6].Length > 20)
						{
							string s���O = sValue[5] + sValue[6];
							sKey[12] = s���O.Substring(0, 20);
							if (s���O.Length <= 40)
								sKey[13] = s���O.Substring(20);
							else
								sKey[13] = s���O.Substring(20, 20);
						}
						else
						{
							sKey[12] = sValue[5];
							sKey[13] = sValue[6];
						}
						if (sKey[12].Length == 0) sKey[12] = " ";
						if (sKey[13].Length == 0) sKey[13] = " ";
					}
					else if (sKey[4].Trim().Length == 0) �G���[�o��(iCnt, 6, "���O�P�͕K�{���ڂł�\r\n");
					
					//�X�֔ԍ�
					sValue[7] = sValue[7].Trim().Replace("-", "");
					if (sKey[4].Trim().Length == 0 && !�K�{�`�F�b�N(sValue[7])) �G���[�o��(iCnt, 8, "�X�֔ԍ��͕K�{���ڂł�\r\n");
					if (sValue[7].Length != 0)
					{
						if (!���l�`�F�b�N(sValue[7])) �G���[�o��(iCnt, 8, "�X�֔ԍ��͐��l�œ��͂��Ă�������\r\n");
						if (sValue[7].Length > 7) �G���[�o��(iCnt, 8, "�X�֔ԍ��͂V�����ȓ��œ��͂��Ă�������\r\n");
						if (���l�`�F�b�N(sValue[7]) && sValue[7].Length <= 7)
						{
							//�Z�����݃`�F�b�N
							try
							{
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� START
						if (gs����b�c.Substring(0,1) != "J")
						{
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END
								if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
//�ۗ� MOD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� START
//�ۗ� MOD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� END
// MOD 2008.12.25 kcl)�X�{ ���X�R�[�h�������@�̍ĕύX START
//// ADD 2008.06.12 kcl)�X�{ ���X�R�[�h�������@�̕ύX START
////								sRet = sv_syukka.Get_autoEntryPref(gsa���[�U,sValue[7]);
//								sRet = sv_syukka.Get_autoEntryPref3(gsa���[�U, sKey[0], sKey[1], sKey[4], sValue[7], sValue[2] + sValue[3] + sValue[4]);
//// ADD 2008.06.12 kcl)�X�{ ���X�R�[�h�������@�̕ύX END
								sRet = sv_syukka.Get_autoEntryPref3(gsa���[�U, sKey[0], sKey[1], sKey[4], sValue[7], sValue[2] + sValue[3] + sValue[4], sValue[5] + sValue[6]);
// MOD 2008.12.25 kcl)�X�{ ���X�R�[�h�������@�̍ĕύX START
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� START
						}
						else
						{
							if(sv_oji == null) sv_oji = new is2oji.Service1();
							sRet = sv_oji.Get_autoEntryPref3(gsa���[�U, sKey[0], sKey[1], sKey[4], sValue[7], sValue[2] + sValue[3] + sValue[4], sValue[5] + sValue[6]);
						}
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END
							}
							catch (System.Net.WebException)
							{
								throw new Exception(gs�ʐM�G���[);
							}
							catch (Exception ex)
							{
								throw new Exception("�ʐM�G���[�F" + ex.Message);
							}
							if(sRet[0].Length != 4)
							{
								if(sRet[0].Equals("�Y���f�[�^������܂���"))
								{
									�G���[�o��(iCnt, 8, "�X�֔ԍ������݂��܂���\r\n");
								}
								else
								{
									throw new Exception(sRet[0]);
								}
							}
							else
							{
								sKey[15] = sRet[2];	//���X�b�c
								sKey[16] = sRet[3];	//���X��
								if (sKey[16].Length == 0) sKey[16] = " ";
								sKey[8]  = sRet[1];	//�Z���b�c
// MOD 2008.11.19 ���s�j���� ���X�R�[�h���󔒂ł��G���[�łȂ����� START
//								if (sKey[15].Trim().Length == 0) �G���[�o��(iCnt, 8, "���͂��ꂽ�X�֔ԍ��ł͔z�B�X�����߂��܂���ł���\r\n");
// MOD 2008.11.19 ���s�j���� ���X�R�[�h���󔒂ł��G���[�łȂ����� END
							}
						}
						sKey[14] = sValue[7];
					}
					sKey[21] = s���X�b�c;
					sKey[22] = s���X��;
					sKey[20] = s�W��X�b�c;
					
					//����v
					sValue[8] = sValue[8].Trim();
					if (sValue[8].Length != 0)
					{
						sKey[17] = sValue[8];
						if (sKey[17].Length == 0) sKey[17] = " ";
// ADD 2007.11.20 ���s�j���� �����`�F�b�N�̒ǉ� START
						if (���p�`�F�b�N(sValue[8]))
						{
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
//							if(!�L���`�F�b�N(sValue[8])) �G���[�o��(iCnt, 9, "����v�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END
							if (sValue[8].Length > 5) �G���[�o��(iCnt, 9, "����v�͔��p�T�����ȓ��œ��͂��Ă�������\r\n");
						}
						else
						{
// MOD 2008.04.25 ���s�j���� ����v�͑S�p�͕s�ɂ��� START
//							if (sValue[8].Length > 2) �G���[�o��(iCnt, 9, "����v�͔��p�T�����ȓ��œ��͂��Ă�������\r\n");
							�G���[�o��(iCnt, 9, "����v�͔��p�����œ��͂��Ă�������\r\n");
// MOD 2008.04.25 ���s�j���� ����v�͑S�p�͕s�ɂ��� END
						}
// ADD 2007.11.20 ���s�j���� �����`�F�b�N�̒ǉ� END
					}

					//�ב��l�R�[�h
					sValue[10] = sValue[10].Trim();
					if (!�K�{�`�F�b�N(sValue[10])) �G���[�o��(iCnt, 11, "�ב��l�R�[�h�͕K�{���ڂł�\r\n");
					if (!���p�`�F�b�N(sValue[10])) �G���[�o��(iCnt, 11, "�ב��l�R�[�h�͔��p�����œ��͂��Ă�������\r\n");
					sKey[18] = sValue[10];
					sKey[23] = " ";
					sKey[24] = " ";
					sKey[25] = " ";
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� START
					int i�ב��l�Œ�d�� = 0;
					int i�ב��l�Œ�ː� = 0;
					bool b�d�ʍː��Đݒ�FLG = false;
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
					//�ב��l�R�[�h���݃`�F�b�N
					if (�K�{�`�F�b�N(sKey[18]) && ���p�`�F�b�N(sKey[18]))
					{
// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
						if(!�L���`�F�b�N(sValue[10])){
							�G���[�o��(iCnt, 11, "�ב��l�R�[�h�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
						}else{
// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END
							//�ב��l���݃`�F�b�N
							try
							{
								if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
//�ۗ� MOD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� START
//�ۗ� MOD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� END
								sRet = sv_syukka.Get_autoEntryClaim(gsa���[�U,gs����b�c,gs����b�c,sKey[18]);
							}
							catch (System.Net.WebException)
							{
								throw new Exception(gs�ʐM�G���[);
							}
							catch (Exception ex)
							{
								throw new Exception("�ʐM�G���[�F" + ex.Message);
							}
							if(sRet[0].Length != 4)
							{
								if(sRet[0].Equals("�Y���f�[�^������܂���"))
								{
									�G���[�o��(iCnt, 11, "�ב��l�R�[�h�����݂��܂���\r\n");
								}
								else
								{
									throw new Exception(sRet[0]);
								}
							}
							else
							{
								sKey[23] = sRet[1];	//���Ӑ�b�c
								sKey[24] = sRet[2];	//���ۂb�c
// ADD 2005.08.19 ���s�j���� �m�t�k�k�G���[�̑Ή� START
								if(sKey[24].Length == 0) sKey[24] = " ";
// ADD 2005.08.19 ���s�j���� �m�t�k�k�G���[�̑Ή� END
								sKey[25] = sRet[3]; //���Ӑ敔�ۖ�
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� START
								i�ב��l�Œ�d�� = int.Parse(sRet[4].Trim());
								i�ב��l�Œ�ː� = int.Parse(sRet[5].Trim());
								b�d�ʍː��Đݒ�FLG = true;
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
// MOD 2010.09.03 ���s�j���� �b�r�u�G���g���[���̐�����G���[�\�L�C�� START
//								if (sKey[25].Trim().Length == 0) �G���[�o��(iCnt, 11, "���Ӑ敔�ۖ������݂��܂���\r\n");
								if(sKey[25].Trim().Length == 0)
								{
									string s������b�c = sRet[1].Trim();
									if(sRet[2].Trim().Length > 0){
										s������b�c += "-" + sRet[2].Trim();
									}
									�G���[�o��(iCnt, 11
									, "�ב��l�̐�����["+s������b�c+"]�͓o�^����Ă��܂���\r\n");
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� START
									b�d�ʍː��Đݒ�FLG = false;
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
								}
// MOD 2010.09.03 ���s�j���� �b�r�u�G���g���[���̐�����G���[�\�L�C�� END
							}
// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
						}
// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END
					}
					
					//�ב��l������
					sKey[19] = " ";
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
					if(i�b�r�u�G���g���[�`�� == 2){
						if(sValue�ꗗ�s[(int)�`���Q.�ב��S����].Length != 0){
//							if(!�S�p�`�F�b�N(sValue�ꗗ�s[(int)�`���Q.�ב��S����])){
//								�G���[�o�͂Q(iCnt, (int)�`���Q.�ב��S����
//									, "�ב��S���҂͑S�p�����œ��͂��Ă�������\r\n");
//							}
//							if(sValue�ꗗ�s[(int)�`���Q.�ב��S����].Length > 10){
//								�G���[�o�͂Q(iCnt, (int)�`���Q.�ב��S����
//									, "�ב��S���҂͂P�O�����ȓ��œ��͂��Ă�������\r\n");
//							}
//							sKey[19] = sValue�ꗗ�s[(int)�`���Q.�ב��S����];
							if(!�����ϊ�_CSV(ref sValue�ꗗ�s[(int)�`���Q.�ב��S����], ref sErr)){
								�G���[�o�͂Q(iCnt, (int)�`���Q.�ב��S����
								, "�ב��S���҂�Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���"
													 + "�w" + sErr + "�x\r\n");
							}else{
								�����ϊ���o��(iCnt, (int)�`���Q.�ב��S���� + 1
													, sValue�ꗗ�s[(int)�`���Q.�ב��S����]);
							}
							if(!�S�p�ϊ��`�F�b�N(ref sValue�ꗗ�s[(int)�`���Q.�ב��S����], ref sErr)){
								�G���[�o�͂Q(iCnt, (int)�`���Q.�ב��S����
								, "�ב��S���҂͑S�p�����ϊ��������Ȃ��܂���ł���"
													 + "�w" + sErr + "�x\r\n");
							}
							if(sValue�ꗗ�s[(int)�`���Q.�ב��S����].Length > 10){
								sKey[19] = sValue�ꗗ�s[(int)�`���Q.�ב��S����].Substring(0,10);
							}else{
								sKey[19] = sValue�ꗗ�s[(int)�`���Q.�ב��S����];
							}
						}
					}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END

					//��
					sValue[11] = sValue[11].Trim();
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� START
//					if (!�K�{�`�F�b�N(sValue[11]) || sValue[11].Equals("0")) �G���[�o��(iCnt, 12, "���͕K�{���ڂł�\r\n");
					if(!�K�{�`�F�b�N(sValue[11]) || sValue[11].Equals("0"))
					{
						�G���[�o��(iCnt, 12, "���͕K�{���ڂł�\r\n");
						b�d�ʍː��Đݒ�FLG = false;
					}
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
// MOD 2010.11.02 ���s�j���� ���l�͈̓`�F�b�N�̕ύX START
//					if (!���l�`�F�b�N(sValue[11])) �G���[�o��(iCnt, 12, "���͐��l�œ��͂��Ă�������\r\n");
//// ADD 2006.11.20 FJCS�j�K�c �O�[���Ή� START
////					if (sValue[11].Trim().Length > 2) �G���[�o��(iCnt, 12, "���͂Q���ȓ��œ��͂��Ă�������\r\n");
//					if (���l�`�F�b�N(sValue[11]))
//					{	
//// MOD 2007.11.08 ���s�j���� �����ӂ��Q�Ή� START
////						if (int.Parse(sValue[11].Trim()) > 99) �G���[�o��(iCnt, 12, "���͂Q���ȓ��œ��͂��Ă�������\r\n");
//						if (long.Parse(sValue[11].Trim()) > 99) �G���[�o��(iCnt, 12, "���͂Q���ȓ��œ��͂��Ă�������\r\n");
//// MOD 2007.11.08 ���s�j���� �����ӂ��Q�Ή� END
//					}
//// ADD 2006.11.20 FJCS�j�K�c �O�[���Ή� END
					sChkMsg = ���l�͈̓`�F�b�N("��", sValue[11], 0, 99, "�Q���ȓ�");
					if(sChkMsg.Length > 0){
						�G���[�o��(iCnt, 12, sChkMsg +"\r\n");
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� START
						b�d�ʍː��Đݒ�FLG = false;
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
					}
// MOD 2010.11.02 ���s�j���� ���l�͈̓`�F�b�N�̕ύX END
					sKey[26] = sValue[11];
					
					//�ː�
					sValue[12] = sValue[12].Trim();
// ADD 2005.09.15 ���s�j�ɉ� �󔒂̏ꍇ"0"�Ƃ��Ĕ��� START
					if (sValue[12].Length == 0) sValue[12] = "0";
// ADD 2005.09.15 ���s�j�ɉ� �󔒂̏ꍇ"0"�Ƃ��Ĕ��� END
// MOD 2010.11.02 ���s�j���� ���l�͈̓`�F�b�N�̕ύX START
//					if (!���l�`�F�b�N(sValue[12])) �G���[�o��(iCnt, 13, "�ː��͐��l�œ��͂��Ă�������\r\n");
//					if (sValue[12].Trim().Length > 3) �G���[�o��(iCnt, 13, "�ː��͂R���ȓ��œ��͂��Ă�������\r\n");
					sChkMsg = ���l�͈̓`�F�b�N("�ː�", sValue[12], 0, 999, "�R���ȓ�");
					if(sChkMsg.Length > 0){
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� START
////						�G���[�o��(iCnt, 12, sChkMsg +"\r\n");
//						�G���[�o��(iCnt, 13, sChkMsg +"\r\n");
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
//						sValue[12] = "0";
						if(gs�d�ʓ��͐��� == "1")
						{
							�G���[�o��(iCnt, 13, sChkMsg +"\r\n");
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� START
							b�d�ʍː��Đݒ�FLG = false;
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
						}
						else
						{
							sValue[12] = "0";
						}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� END
					}
// MOD 2010.11.02 ���s�j���� ���l�͈̓`�F�b�N�̕ύX END
					sKey[27] = sValue[12];
					
					//�d��
					sValue[13] = sValue[13].Trim();
// ADD 2005.09.15 ���s�j�ɉ� �󔒂̏ꍇ"0"�Ƃ��Ĕ��� START
					if (sValue[13].Length == 0) sValue[13] = "0";
// ADD 2005.09.15 ���s�j�ɉ� �󔒂̏ꍇ"0"�Ƃ��Ĕ��� END
// MOD 2010.11.02 ���s�j���� ���l�͈̓`�F�b�N�̕ύX START
//					if (!���l�`�F�b�N(sValue[13])) �G���[�o��(iCnt, 14, "�d�ʂ͐��l�œ��͂��Ă�������\r\n");
//					if (sValue[13].Trim().Length > 4) �G���[�o��(iCnt, 14, "�d�ʂ͂S���ȓ��œ��͂��Ă�������\r\n");
					sChkMsg = ���l�͈̓`�F�b�N("�d��", sValue[13], 0, 9999, "�S���ȓ�");
					if(sChkMsg.Length > 0){
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� START
////						�G���[�o��(iCnt, 12, sChkMsg +"\r\n");
//						�G���[�o��(iCnt, 14, sChkMsg +"\r\n");
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
//						sValue[13] = "0";
						if(gs�d�ʓ��͐��� == "1")
						{
							�G���[�o��(iCnt, 14, sChkMsg +"\r\n");
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� START
							b�d�ʍː��Đݒ�FLG = false;
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
						}
						else
						{
							sValue[13] = "0";
						}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� END
					}
// MOD 2010.11.02 ���s�j���� ���l�͈̓`�F�b�N�̕ύX END
					sKey[28] = sValue[13];
					
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� START
//					if (!sValue[12].Equals("0")  && !sValue[13].Equals("0"))
//					{
//						�G���[�o��(iCnt, 13, "�ː��Əd�ʂ͂ǂ��炩�������͂��Ă�������\r\n");
//						axGT�捞�f�[�^�ꗗ.set_CelMarking((short)(iCnt),(short)(14),true);
//					}
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
					if(gs�d�ʓ��͐��� == "1")
					{
						if (!sValue[12].Equals("0")  && !sValue[13].Equals("0")){
							�G���[�o��(iCnt, 13, "�ː��Əd�ʂ͂ǂ��炩�������͂��Ă�������\r\n");
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� START
							b�d�ʍː��Đݒ�FLG = false;
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
//							axGT�捞�f�[�^�ꗗ.set_CelMarking((short)(iCnt),(short)(14),true);
							if(i�b�r�u�G���g���[�`�� == 2)
							{
								axGT�捞�f�[�^�ꗗ.set_CelMarking((short)(iCnt),(short)((int)�`���Q.�d��+1),true);
							}else{
								axGT�捞�f�[�^�ꗗ.set_CelMarking((short)(iCnt),(short)((int)�`���P.�d��+1),true);
							}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
						}
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� START
						if(b�d�ʍː��Đݒ�FLG)
						{
							//�ב��l�R�[�h�A���A�ː��A�d�ʂ̊e�`�F�b�N�ŁA��������G���[���Ȃ������ꍇ�ɏ���
							int i�b�r�u�� = int.Parse(sKey[26].Trim());
							int i�b�r�u�ː� = int.Parse(sKey[27].Trim());
							int i�b�r�u�d�� = int.Parse(sKey[28].Trim());
							int i�o�^�ː� = 0;
							int i�o�^�d�� = 0;

							if(gs�I�v�V����[23] == "1")
							{
								//�G���g���[�I�v�V�����́y���˗���Œ�d�ʁz���ڂ��u�l������v�̏ꍇ
								if(i�b�r�u�ː� == 0 && i�b�r�u�d�� == 0)
								{
									//CSV�f�[�^�̏d�ʁA�ː��������u0�v�̏ꍇ�݂̂��Ώ�
									if(gs�I�v�V����[9] == "1")
									{
										//�G���g���[�I�v�V�����́y�d�ʓ��͕��@�z���ڂ��u�ː��v�̏ꍇ
										//�@�@���u�ː�(�ב��l�}�X�^)�v�~�u��(CSV�f�[�^)�v���Z�b�g
										i�o�^�ː� = i�ב��l�Œ�ː� * i�b�r�u��;
									}
									else
									{
										//�G���g���[�I�v�V�����́y�d�ʓ��͕��@�z���ڂ��u�d�ʁv�܂��́u���ݒ�v�̏ꍇ
										//�@�@���u�d��(�ב��l�}�X�^)�v�~�u��(CSV�f�[�^)�v���Z�b�g
										i�o�^�d�� = i�ב��l�Œ�d�� * i�b�r�u��;
									}
								}
								else
								{
									//CSV�f�[�^�̏d�ʁA�ː����ǂ��炩����ł����͂���Ă�����ACSV�̒l���Z�b�g
									i�o�^�ː� = i�b�r�u�ː�;
									i�o�^�d�� = i�b�r�u�d��;
								}
							}
							else
							{
								//�G���g���[�I�v�V�����́y���˗���Œ�d�ʁz���ڂ��u�l�����Ȃ��v�܂��́u���ݒ�v�̏ꍇ�ACSV�̒l���Z�b�g
								i�o�^�ː� = i�b�r�u�ː�;
								i�o�^�d�� = i�b�r�u�d��;
							}

							//�l����̏d�ʂ���эː����Đݒ肷��
							sKey[27] = i�o�^�ː�.ToString(); // �ː�
							sKey[28] = i�o�^�d��.ToString(); // �d��

							//�����ĉ�ʏ�̕\�����Đݒ肷��
							if(i�b�r�u�G���g���[�`�� == 2)
							{
								axGT�捞�f�[�^�ꗗ.set_CelText((short)iCnt, (short)((int)�`���Q.�ː� + 1), sKey[27]); // �ː�
								axGT�捞�f�[�^�ꗗ.set_CelText((short)iCnt, (short)((int)�`���Q.�d�� + 1), sKey[28]); // �d��
							}
							else
							{
								axGT�捞�f�[�^�ꗗ.set_CelText((short)iCnt, (short)((int)�`���P.�ː� + 1), sKey[27]); // �ː�
								axGT�捞�f�[�^�ꗗ.set_CelText((short)iCnt, (short)((int)�`���P.�d�� + 1), sKey[28]); // �d��
							}
						}
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
					}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END

					//�A���w���P
					sValue[14] = sValue[14].TrimEnd();
// ADD 2005.10.13 ���s�j�ɉ� �G���[�Ή� START
					sKey[31] = "000";
					sKey[32] = " ";
// ADD 2005.10.13 ���s�j�ɉ� �G���[�Ή� END
					if (sValue[14].Length != 0)
					{
// ADD 2006.11.07 FJCS�j�K�c �A�����i�̓R�[�h�ł��n�j�Ƃ��� START
						if (���p�`�F�b�N(sValue[14]))
						{
							if (!���l�`�F�b�N(sValue[14])) �G���[�o��(iCnt, 15, "�A�����i�P�R�[�h�͐��l�̂ݓ��͉\�ł�\r\n");
							if (sValue[14].Length != 3) �G���[�o��(iCnt, 15, "�A�����i�P�R�[�h�͂R���œ��͂��Ă�������\r\n");
							if (���l�`�F�b�N(sValue[14]) && sValue[14].Length == 3)
							{
								string[] sList = {""};
								try
								{
									if(sv_kiji == null) sv_kiji = new is2kiji.Service1();
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
									if (gs����b�c.Substring(0,1) != "J"){
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
										sList = sv_kiji.Get_Skiji(gsa���[�U,"yusoshohin","0000",sValue[14]);
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
									}else{
										sList = sv_kiji.Get_Skiji(gsa���[�U,"Jyusoshohin","0000",sValue[14]);
									}
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
								}
								catch (System.Net.WebException)
								{
									throw new Exception(gs�ʐM�G���[);
								}
								catch (Exception ex)
								{
									throw new Exception("�ʐM�G���[:" + ex.Message);
								}
								//���݂��Ȃ���
								if (sList[3] == "I")
								{
									�G���[�o��(iCnt,15,"���͂��ꂽ�A�����i�P�R�[�h�̓}�X�^�ɑ��݂��܂���B\r\n");
								}
								else
								{
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//									sKey[32] = sList[1].Trim();
									sKey[32] = sList[1].TrimEnd();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
								}
								sKey[31] = sValue[14];
							}
						}
						else
							// ADD 2006.11.07 FJCS�j�K�c �A�����i�̓R�[�h�ł��n�j�Ƃ��� END
						{
// ADD 2008.04.11 ACT Vista�Ή� START
							if (!�����ϊ�_CSV(ref sValue[14], ref sErr)) 
							{
								�G���[�o��(iCnt, 15, "�A�����i�P��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}
							else
							{
								�����ϊ���o��(iCnt, 15, sValue[14]);
							}
// ADD 2008.04.11 ACT Vista�Ή� END
							if (!�S�p�`�F�b�N(sValue[14])) �G���[�o��(iCnt, 15, "�A�����i�P�̖��̂͑S�p�����ŁA�R�[�h�͔��p�����œ��͂��Ă��������i�ǂ��炩����݂̂ł��j\r\n");
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� START
//							sKey[32] = Microsoft.VisualBasic.Strings.StrConv(sValue[14], Microsoft.VisualBasic.VbStrConv.Wide, 0);
							sKey[32] = sValue[14];
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� END
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� START
//							sKey[32] = sKey[32].Replace('\\','��');
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� END
							if (sKey[32].Length > 15) sKey[32] = sKey[32].Substring(0, 15);
							//�A�����i�R�[�h����
							if (�S�p�`�F�b�N(sValue[14]))
							{
								try
								{
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
									if (gs����b�c.Substring(0,1) != "J"){
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
										if(sv_kiji == null) sv_kiji = new is2kiji.Service1();
										sRet = sv_kiji.Get_kijiCD(gsa���[�U,"0000",sValue[14]);
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
									}else{
										if(sv_oji == null) sv_oji = new is2oji.Service1();
										sRet = sv_oji.Get_kijiCD(gsa���[�U,"0000",sValue[14]);
									}
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
								}
								catch (System.Net.WebException)
								{
									throw new Exception(gs�ʐM�G���[);
								}
								catch (Exception ex)
								{
									throw new Exception("�ʐM�G���[�F" + ex.Message);
								}
								if(sRet[0].Length != 4)
								{
									if(sRet[0].Equals("�Y���f�[�^������܂���"))
									{
										sKey[31] = "000";
										�G���[�o��(iCnt, 15, "�A�����i�P�����݂��܂���\r\n");
									}
									else
									{
										throw new Exception(sRet[0]);
									}
								}
								else
								{
									sKey[31] = sRet[1];
								}
							}
						}
					}
					else
					{
						sKey[31] = "000";
						sKey[32] = " ";
					}
					//�A���w���Q
					sValue[15] = sValue[15].TrimEnd();
					sKey[33] = "000";
					sKey[34] = " ";
					//�A�����i�Q�����`�F�b�N
					if (!sKey[31].Equals("000") && sValue[15].Length == 0)
					{
						string[] sList = {""};
						try
						{
							if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
							if (gs����b�c.Substring(0,1) != "J"){
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
								sList = sv_kiji.Get_kiji(gsa���[�U,"yusoshohin",sKey[31]);
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
							}else{
								sList = sv_kiji.Get_kiji(gsa���[�U,"Jyusoshohin",sKey[31]);
							}
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
						}
						catch (System.Net.WebException)
						{
							throw new Exception(gs�ʐM�G���[);
						}
						catch (Exception ex)
						{
							throw new Exception("�ʐM�G���[�F" + ex.Message);
						}
						if(sList[0].Equals("����I��"))
						{
							for (int i = 1; i < sList.Length; i++)
							{
								//�A�����i�P�Ɠ����R�[�h������ꍇ�͗A�����i�Q���w��Ȃ��Ɣ���
								string[] s�L�� = sList[i].Split('|');
								if (s�L��.Length > 2 && sKey[31].Equals(s�L��[1]))
								{
									sKey[33] = s�L��[1];
									sKey[34] = s�L��[2];
									break;
								}
							}
							if (sKey[33].Equals("000")) �G���[�o��(iCnt, 16, "�A�����i�P�����͂���Ă���ꍇ�A�A�����i�Q�͕K�{���ڂł�\r\n");
						}
						else if (!sList[0].Equals("�Y���f�[�^������܂���"))
						{
							throw new Exception(sList[0]);
						}
					}
					if (sValue[15].Length != 0)
					{
						if (sValue[14].Length == 0) �G���[�o��(iCnt, 15, "�A�����i�P����͂��Ă�������\r\n");
// ADD 2006.11.07 FJCS�j�K�c �A�����i�̓R�[�h�ł��n�j�Ƃ��� START
						if (���p�`�F�b�N(sValue[15]))
						{
							if (!���l�`�F�b�N(sValue[15])) �G���[�o��(iCnt, 16, "�A�����i�Q�R�[�h�͐��l�̂ݓ��͉\�ł�\r\n");
							if (sValue[15].Length != 3) �G���[�o��(iCnt, 16, "�A�����i�Q�R�[�h�͂R���œ��͂��Ă�������\r\n");
							if (���l�`�F�b�N(sValue[15]) && sValue[15].Length == 3)
							{
								string[] sList = {""};
								try
								{
									if(sv_kiji == null) sv_kiji = new is2kiji.Service1();
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
									if (gs����b�c.Substring(0,1) != "J"){
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
										// ����R�[�h:"yusoshohin" ����R�[�h:"0000"�Ō���
										sList = sv_kiji.Get_Skiji(gsa���[�U,"yusoshohin",sKey[31],sValue[15]);
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
									}else{
										sList = sv_kiji.Get_Skiji(gsa���[�U,"Jyusoshohin",sKey[31],sValue[15]);
									}
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
								}
								catch (System.Net.WebException)
								{
									throw new Exception(gs�ʐM�G���[);
								}
								catch (Exception ex)
								{
									throw new Exception("�ʐM�G���[�F" + ex.Message);
								}
								//���݂��Ȃ���
								if(sList[3] == "I")
								{
									�G���[�o��(iCnt,16,"���͂��ꂽ�A�����i�Q�R�[�h�̓}�X�^�ɑ��݂��܂���B\r\n");
								}
								else
								{
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//									sKey[34] = sList[1].Trim();
									sKey[34] = sList[1].TrimEnd();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
								}
								sKey[33] = sValue[15];
							}
						}
						else
// ADD 2006.11.07 FJCS�j�K�c �A�����i�̓R�[�h�ł��n�j�Ƃ��� END
						{
// ADD 2008.04.11 ACT Vista�Ή� START
							if (!�����ϊ�_CSV(ref sValue[15], ref sErr)) 
							{
								�G���[�o��(iCnt, 16, "�A�����i�Q��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}
							else
							{
								�����ϊ���o��(iCnt, 16, sValue[15]);
							}
// ADD 2008.04.11 ACT Vista�Ή� END
							if (!�S�p�`�F�b�N(sValue[15])) �G���[�o��(iCnt, 16, "�A�����i�Q�̖��̂͑S�p�����ŁA�R�[�h�͔��p�����œ��͂��Ă��������i�ǂ��炩����݂̂ł��j\r\n");
// MOD 2009.11.25 ���s�j���� ���Ԏw��`�F�b�N�̒ǉ� START
							if(sValue[14].Length != 0 && �S�p�`�F�b�N(sValue[15]) && sKey[31].Equals("100")){
								if(sValue[15].Equals("�`�l�w��")){
									sValue[15] = "�`�l�w��i�P�O���`�P�Q���j";
								}
							}
// MOD 2009.11.25 ���s�j���� ���Ԏw��`�F�b�N�̒ǉ� END
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� START
//							sKey[34] = Microsoft.VisualBasic.Strings.StrConv(sValue[15], Microsoft.VisualBasic.VbStrConv.Wide, 0);
							sKey[34] = sValue[15];
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� END
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� START
//							sKey[34] = sKey[34].Replace('\\','��');
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� END
							if (sKey[34].Length > 15) sKey[34] = sKey[34].Substring(0, 15);
							//�A�����i�R�[�h����
							if (sValue[14].Length != 0 && �S�p�`�F�b�N(sValue[15]) && !sKey[31].Equals("000"))
							{
								try
								{
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
									if (gs����b�c.Substring(0,1) != "J"){
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
										if(sv_kiji == null) sv_kiji = new is2kiji.Service1();
										sRet = sv_kiji.Get_kijiCD(gsa���[�U,sKey[31],sValue[15]);
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
									}else{
										if(sv_oji == null) sv_oji = new is2oji.Service1();
										sRet = sv_oji.Get_kijiCD(gsa���[�U,sKey[31],sValue[15]);
									}
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
								}
								catch (System.Net.WebException)
								{
									throw new Exception(gs�ʐM�G���[);
								}
								catch (Exception ex)
								{
									throw new Exception("�ʐM�G���[�F" + ex.Message);
								}
								if(sRet[0].Length != 4)
								{
									if(sRet[0].Equals("�Y���f�[�^������܂���"))
									{
										sKey[33] = "000";
										�G���[�o��(iCnt, 16, "�A�����i�Q�����݂��܂���\r\n");
									}
									else
									{
										throw new Exception(sRet[0]);
									}
								}
								else
								{
// MOD 2009.11.25 ���s�j���� ���Ԏw��`�F�b�N�̒ǉ� START
									if(sKey[31].Equals("100")){
										if(sRet[1].Equals("11X")){
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX START
//											���Ԏw��`�F�b�N(iCnt, sValue[15], 12, 21);
											���Ԏw��`�F�b�N(iCnt, sValue[15], 12, 20);
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX END
										}else if(sRet[1].Equals("12X")){
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX START
//											���Ԏw��`�F�b�N(iCnt, sValue[15], 10, 19);
											���Ԏw��`�F�b�N(iCnt, sValue[15], 10, 18);
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX END
										}
									}else if(sKey[31].Equals("200")){
										if(sRet[1].Equals("21X")){
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX START
//											���Ԏw��`�F�b�N(iCnt, sValue[15], 12, 21);
											���Ԏw��`�F�b�N(iCnt, sValue[15], 12, 20);
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX END
										}else if(sRet[1].Equals("22X")){
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX START
//											���Ԏw��`�F�b�N(iCnt, sValue[15], 10, 19);
											���Ԏw��`�F�b�N(iCnt, sValue[15], 10, 18);
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX END
										}
									}
// MOD 2009.11.25 ���s�j���� ���Ԏw��`�F�b�N�̒ǉ� END
									sKey[33] = sRet[1];
								}
							}
						}
					}
// ADD 2005.06.02 ���s�j�ɉ� �A�����i�ɂ����d�ʐ��� START
					// �p�[�Z�������̏ꍇ
					if (sKey[31].Equals("001"))
					{
						if (!sKey[26].Equals("1")) �G���[�o��(iCnt, 12, "�A�����i�P��" + sKey[32] + "�̏ꍇ�A����'1'����͂��Ă�������\r\n");
						if (!sKey[28].Equals("1")) �G���[�o��(iCnt, 14, "�A�����i�P��" + sKey[32] + "�̏ꍇ�A�d�ʂ�'1'����͂��Ă�������\r\n");
					}
					// �p�[�Z���p�b�N�̏ꍇ
					if (sKey[31].Equals("002"))
					{
						if (!sKey[26].Equals("1")) �G���[�o��(iCnt, 12, "�A�����i�P��" + sKey[32] + "�̏ꍇ�A����'1'����͂��Ă�������\r\n");
						if (���l�`�F�b�N(sKey[28]) && int.Parse(sKey[28]) > 30) �G���[�o��(iCnt, 14, "�A�����i�P��" + sKey[32] + "�̏ꍇ�A�d�ʂ͂R�O�ȉ�����͂��Ă�������\r\n");
						if (���l�`�F�b�N(sKey[27]) && ���l�`�F�b�N(sKey[28]) && int.Parse(sKey[27]) > 0 && int.Parse(sKey[28]) == 0) �G���[�o��(iCnt, 14, "�A�����i�P��" + sKey[32] + "�̏ꍇ�A�d�ʂ���͂��Ă�������\r\n");
					}
// ADD 2005.06.02 ���s�j�ɉ� �A�����i�ɂ����d�ʐ��� END

					//�i���L���P
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//					sValue[16] = sValue[16].TrimEnd();
					if(gs�I�v�V����[18].Equals("1")){
						sValue[16] = sValue[16].TrimEnd();
					}else{
						sValue[16] = sValue[16].Trim();
					}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
					if (sValue[16].Length != 0)
					{
// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
						if(!�L���`�F�b�N�Q(sValue[16])) �G���[�o��(iCnt, 17, "�i���L���P�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END
// ADD 2008.04.11 ACT Vista�Ή� START
						if (!�����ϊ�_CSV(ref sValue[16], ref sErr)) 
						{
							�G���[�o��(iCnt, 17, "�i���L���P��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
						}
						else
						{
							�����ϊ���o��(iCnt, 17, sValue[16]);
						}
// ADD 2008.04.11 ACT Vista�Ή� END
// MOD 2009.12.01 ���s�j���� �S�p���p���݉\�ɂ��� START
//						sKey[35] = Microsoft.VisualBasic.Strings.StrConv(sValue[16], Microsoft.VisualBasic.VbStrConv.Wide, 0);
//						if (sKey[35].Length > 15) sKey[35] = sKey[35].Substring(0, 15);
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� START
//						sKey[35] = sKey[35].Replace('\\','��');
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� END
						sKey[35] = �o�C�g���J�b�g(sValue[16], 30);
// MOD 2009.12.01 ���s�j���� �S�p���p���݉\�ɂ��� END
					}
					else
					{
						sKey[35] = " ";
					}

					//�i���L���Q
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//					sValue[17] = sValue[17].TrimEnd();
					if(gs�I�v�V����[18].Equals("1")){
						sValue[17] = sValue[17].TrimEnd();
					}else{
						sValue[17] = sValue[17].Trim();
					}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
					if (sValue[17].Length != 0)
					{
// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
						if(!�L���`�F�b�N�Q(sValue[17])) �G���[�o��(iCnt, 18, "�i���L���Q�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END
// ADD 2008.04.11 ACT Vista�Ή� START
						if (!�����ϊ�_CSV(ref sValue[17], ref sErr)) 
						{
							�G���[�o��(iCnt, 18, "�i���L���Q��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
						}
						else
						{
							�����ϊ���o��(iCnt, 18, sValue[17]);
						}
// ADD 2008.04.11 ACT Vista�Ή� END
// MOD 2009.12.01 ���s�j���� �S�p���p���݉\�ɂ��� START
//						sKey[36] = Microsoft.VisualBasic.Strings.StrConv(sValue[17], Microsoft.VisualBasic.VbStrConv.Wide, 0);
//						if (sKey[36].Length > 15) sKey[36] = sKey[36].Substring(0, 15);
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� START
//						sKey[36] = sKey[36].Replace('\\','��');
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� END
						sKey[36] = �o�C�g���J�b�g(sValue[17], 30);
// MOD 2009.12.01 ���s�j���� �S�p���p���݉\�ɂ��� END
					}
					else
					{
						sKey[36] = " ";
					}

					//�i���L���R
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//					sValue[18] = sValue[18].TrimEnd();
					if(gs�I�v�V����[18].Equals("1")){
						sValue[18] = sValue[18].TrimEnd();
					}else{
						sValue[18] = sValue[18].Trim();
					}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
					if (sValue[18].Length != 0)
					{
// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
						if(!�L���`�F�b�N�Q(sValue[18])) �G���[�o��(iCnt, 19, "�i���L���R�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END
// ADD 2008.04.11 ACT Vista�Ή� START
						if (!�����ϊ�_CSV(ref sValue[18], ref sErr)) 
						{
							�G���[�o��(iCnt, 19, "�i���L���R��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
						}
						else
						{
							�����ϊ���o��(iCnt, 19, sValue[18]);
						}
// ADD 2008.04.11 ACT Vista�Ή� END
// MOD 2009.12.01 ���s�j���� �S�p���p���݉\�ɂ��� START
//						sKey[37] = Microsoft.VisualBasic.Strings.StrConv(sValue[18], Microsoft.VisualBasic.VbStrConv.Wide, 0);
//						if (sKey[37].Length > 15) sKey[37] = sKey[37].Substring(0, 15);
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� START
//						sKey[37] = sKey[37].Replace('\\','��');
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� END
						sKey[37] = �o�C�g���J�b�g(sValue[18], 30);
// MOD 2009.12.01 ���s�j���� �S�p���p���݉\�ɂ��� END
					}
					else
					{
						sKey[37] = " ";
					}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
					if(i�b�r�u�G���g���[�`�� == 2){
						sKey[47] = " ";
						if(sValue�ꗗ�s[(int)�`���Q.�i���L���S].Length != 0){
							if(!�L���`�F�b�N�Q(sValue�ꗗ�s[(int)�`���Q.�i���L���S])){
								�G���[�o�͂Q(iCnt, (int)�`���Q.�i���L���S
								, "�i���L���S�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
							}
							if(!�����ϊ�_CSV(ref sValue�ꗗ�s[(int)�`���Q.�i���L���S], ref sErr)){
								�G���[�o�͂Q(iCnt, (int)�`���Q.�i���L���S
								, "�i���L���S��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}else{
								�����ϊ���o��(iCnt, (int)�`���Q.�i���L���S + 1
								, sValue�ꗗ�s[(int)�`���Q.�i���L���S]);
							}
							sKey[47] = �o�C�g���J�b�g(sValue�ꗗ�s[(int)�`���Q.�i���L���S], 30);
						}
						sKey[48] = " ";
						if(sValue�ꗗ�s[(int)�`���Q.�i���L���T].Length != 0){
							if(!�L���`�F�b�N�Q(sValue�ꗗ�s[(int)�`���Q.�i���L���T])){
								�G���[�o�͂Q(iCnt, (int)�`���Q.�i���L���T
								, "�i���L���T�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
							}
							if(!�����ϊ�_CSV(ref sValue�ꗗ�s[(int)�`���Q.�i���L���T], ref sErr)){
								�G���[�o�͂Q(iCnt, (int)�`���Q.�i���L���T
								, "�i���L���T��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}else{
								�����ϊ���o��(iCnt, (int)�`���Q.�i���L���T + 1
								, sValue�ꗗ�s[(int)�`���Q.�i���L���T]);
							}
							sKey[48] = �o�C�g���J�b�g(sValue�ꗗ�s[(int)�`���Q.�i���L���T], 30);
						}
						sKey[49] = " ";
						if(sValue�ꗗ�s[(int)�`���Q.�i���L���U].Length != 0){
							if(!�L���`�F�b�N�Q(sValue�ꗗ�s[(int)�`���Q.�i���L���U])){
								�G���[�o�͂Q(iCnt, (int)�`���Q.�i���L���U
								, "�i���L���U�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
							}
							if(!�����ϊ�_CSV(ref sValue�ꗗ�s[(int)�`���Q.�i���L���U], ref sErr)){
								�G���[�o�͂Q(iCnt, (int)�`���Q.�i���L���U
								, "�i���L���U��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}else{
								�����ϊ���o��(iCnt, (int)�`���Q.�i���L���U + 1
								, sValue�ꗗ�s[(int)�`���Q.�i���L���U]);
							}
							sKey[49] = �o�C�g���J�b�g(sValue�ꗗ�s[(int)�`���Q.�i���L���U], 30);
						}
// MOD 2011.07.28 ���s�j���� �L���s�̒ǉ��i�����������̒ǉ��j START
						// �i���L���S�`�U�̂����ꂩ�Ƀf�[�^����ꍇ
						if(sKey[47].Trim().Length > 0
							|| sKey[48].Trim().Length > 0
							|| sKey[49].Trim().Length > 0
						){
							sKey[35] = �o�C�g���J�b�g(sKey[35], 18); // �i���L���P
							sKey[36] = �o�C�g���J�b�g(sKey[36], 18); // �i���L���Q
							sKey[37] = �o�C�g���J�b�g(sKey[37], 18); // �i���L���R
							sKey[47] = �o�C�g���J�b�g(sKey[47], 18); // �i���L���S
							sKey[48] = �o�C�g���J�b�g(sKey[48], 18); // �i���L���T
							sKey[49] = �o�C�g���J�b�g(sKey[49], 18); // �i���L���U
						}
// MOD 2011.07.28 ���s�j���� �L���s�̒ǉ��i�����������̒ǉ��j END
					}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
					
// MOD 2007.10.25 ���s�j���� ���ڂ̕ύX�i�\���Q�����q�l�Ǘ��ԍ��ɂ���j START
					//���q�l�Ǘ��ԍ�
					sValue[20] = sValue[20].Trim();
					if (sValue[20] == "0")	sValue[20]=""; // �H
					if (sValue[20].Length != 0)
					{
						if (!���p�`�F�b�N(sValue[20])) �G���[�o��(iCnt, 21, "���q�l�Ǘ��ԍ��͔��p�����œ��͂��Ă�������\r\n");
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
//						if(!�L���`�F�b�N(sValue[20])) �G���[�o��(iCnt, 21, "���q�l�Ǘ��ԍ��Ɏg�p�ł��Ȃ��L��������܂�\r\n");
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END
// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� START
//						if (sValue[20].Length > 15) �G���[�o��(iCnt, 21, "���q�l�Ǘ��ԍ��͂P�T���ȓ��œ��͂��Ă�������\r\n");
						if (sValue[20].Length > 16){
							�G���[�o��(iCnt, 21, "���q�l�Ǘ��ԍ��͂P�U���ȓ��œ��͂��Ă�������\r\n");
						}
// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� END
						sKey[3] = sValue[20];
					}
// MOD 2007.10.25 ���s�j���� ���ڂ̕ύX�i�\���Q�����q�l�Ǘ��ԍ��ɂ���j END

					//�����敪
					sValue[22] = sValue[22].Trim();
					if (!sValue[22].Equals("1"))
					{
						�G���[�o��(iCnt, 23, "�����敪��'1'����͂��Ă�������\r\n");
					}
					sKey[38] = sValue[22];
					
					//�ی����z
					sValue[23] = sValue[23].Trim();
// ADD 2005.09.15 ���s�j�ɉ� �󔒂̏ꍇ"0"�Ƃ��Ĕ��� START
					if (sValue[23].Length == 0) sValue[23] = "0";
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX START
//// ADD 2005.09.15 ���s�j�ɉ� �󔒂̏ꍇ"0"�Ƃ��Ĕ��� END
//					if (!���l�`�F�b�N(sValue[23])) �G���[�o��(iCnt, 24, "�ی����z�͐��l�œ��͂��Ă�������\r\n");
//// ADD 2006.10.16 FJCS�j�K�c �o�O�C�� START
////					if (sValue[21].Trim().Length > 4) �G���[�o��(iCnt, 24, "�ی����z�͂S���ȓ��œ��͂��Ă�������\r\n");
//// ADD 2006.11.20 FJCS�j�K�c �O�[���Ή� START
////					if (sValue[23].Trim().Length > 4) �G���[�o��(iCnt, 24, "�ی����z�͂S���ȓ��œ��͂��Ă�������\r\n");
//					if (���l�`�F�b�N(sValue[23]))
//					{	
//// MOD 2007.11.08 ���s�j���� �����ӂ��Q�Ή� START
////						if (int.Parse(sValue[23].Trim()) > 9999) �G���[�o��(iCnt, 24, "�ی����z�͂S���ȓ��œ��͂��Ă�������\r\n");
//						if (long.Parse(sValue[23].Trim()) > 9999) �G���[�o��(iCnt, 24, "�ی����z�͂S���ȓ��œ��͂��Ă�������\r\n");
//// MOD 2007.11.08 ���s�j���� �����ӂ��Q�Ή� END
//					}
//// ADD 2006.11.20 FJCS�j�K�c �O�[���Ή� END
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) START
//					sChkMsg = ���l�͈̓`�F�b�N("�ی����z", sValue[23], 0, 30, "");
					sChkMsg = ���l�͈̓`�F�b�N("�ی����z", sValue[23], 0, gl�ی����z���, "�S���ȓ�");
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) END
					if(sChkMsg.Length > 0){
						�G���[�o��(iCnt, 24, sChkMsg +"\r\n");
					}
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX END

// ADD 2006.10.16 FJCS�j�K�c �o�O�C�� END
					sKey[39] = sValue[23];
					
					//�o�ד�
					sValue[24] = sValue[24].Trim();
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N START
					DateTime dt�o�ד� = DateTime.Today;
					bool     b�o�ד��ݒ� = false;
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N END
// ADD 2007.11.20 ���s�j���� �����`�F�b�N�̒ǉ� START
					if (!�K�{�`�F�b�N(sValue[24])) �G���[�o��(iCnt, 25, "�o�ד��͕K�{���ڂł�\r\n");
					if (sValue[24].Length != 0)
					{
						if (!���p�`�F�b�N(sValue[24])) �G���[�o��(iCnt, 25, "�o�ד��͔��p�����œ��͂��Ă�������\r\n");
						if (sValue[24].Length != 8)
						{
							�G���[�o��(iCnt, 25, "�o�ד��͂W�����œ��͂��Ă�������\r\n");
						}
						else
						{
// ADD 2007.11.20 ���s�j���� �����`�F�b�N�̒ǉ� END
							try
							{
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N START
//								if (new DateTime(int.Parse(sValue[24].Substring(0,4)),
//									int.Parse(sValue[24].Substring(4,2)),
//									int.Parse(sValue[24].Substring(6))) < gdt�o�ד�)
//								{
//									�G���[�o��(iCnt, 25, "�o�ד���" + gdt�o�ד�.ToString("yyyy�NMM��dd��") + "�ȍ~�œ��͂��Ă�������\r\n");
//								}
								dt�o�ד� = new DateTime(int.Parse(sValue[24].Substring(0,4)),
														int.Parse(sValue[24].Substring(4,2)),
														int.Parse(sValue[24].Substring(6)));
								b�o�ד��ݒ� = true;
								if(dt�o�ד� < gdt�o�ד�)
								{
//									�G���[�o��(iCnt, 25, "�o�ד��͓����ȍ~����͂��Ă�������\r\n");
									�G���[�o��(iCnt, 25, "�o�ד���" + gdt�o�ד�.ToString(" M�� d��") + "�ȍ~����͂��Ă�������\r\n");
								}
								//�����i�o�^���j����Q�T�Ԃ܂�
//								else if(dt�o�ד� > DateTime.Today.AddDays(14))
								else if(dt�o�ד� > gdt�o�ד��ő�l�b�r�u)
								{
//									�G���[�o��(iCnt, 25, "�o�ד���" + DateTime.Today.AddDays(14).ToString("yyyy�NMM��dd��")
									�G���[�o��(iCnt, 25, "�o�ד���" + gdt�o�ד��ő�l�b�r�u.ToString(" M�� d��")
									 + "�ȑO����͂��Ă�������\r\n");
								}
								// ADD-S 2012.09.26 COA)���R ���t���ڎ捞����
								else 
								{
									sValue[24] = YYYYMMDD�ϊ�(dt�o�ד�);
								}
								// ADD-E 2012.09.26 COA)���R ���t���ڎ捞����
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N END
							}
							catch
							{
								�G���[�o��(iCnt, 25, "�o�ד���yyyyMMdd�̌`���œ��͂��Ă�������\r\n");
							}
// ADD 2007.11.20 ���s�j���� �����`�F�b�N�̒ǉ� START
						}
					}
// ADD 2007.11.20 ���s�j���� �����`�F�b�N�̒ǉ� END
					sKey[2] = sValue[24];
					
// MOD 2010.02.25 ���s�j���� ���ڐ��`�F�b�N�̏C�� START
					//�o�^���̏����ݒ�
					sKey[40] = YYYYMMDD�ϊ�(DateTime.Now);
					if(sValue.Length > 25){
// MOD 2010.02.25 ���s�j���� ���ڐ��`�F�b�N�̏C�� END
						//�o�^��
						sValue[25] = sValue[25].Trim();
// ADD 2006.10.05 FJCS�j�K�c ���ڂ̕ύX�i�\���P��z�B�w����ɂ���j START
						string   s����    = YYYYMMDD�ϊ�(DateTime.Now);
// ADD 2006.10.05 FJCS�j�K�c ���ڂ̕ύX�i�\���P��z�B�w����ɂ���j END
// MOD 2006.06.29 ���s�j�R�{ �o�^���ȗ����̃V�X�e�����t�ҏW�Ή� START
// ADD 2006.11.07 FJCS�j�K�c 0�͋��e���� START
						sValue[25] = sValue[25].Trim();
						if (sValue[25] == "0")	sValue[25]="";
// ADD 2006.11.07 FJCS�j�K�c 0�͋��e���� END
						if (sValue[25].Length != 0)
						{	
							try
							{
								DateTime dt�o�^�� = new DateTime(int.Parse(sValue[25].Substring(0,4)),int.Parse(sValue[25].Substring(4,2)), int.Parse(sValue[25].Substring(6)));
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX START
//								string   s����    = DateTime.Now.ToString("yyyyMMdd");
//								string   s����    = YYYYMMDD�ϊ�(DateTime.Now);
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX END
								if (!sValue[25].Equals(s����)) �G���[�o��(iCnt, 26, "�o�^���͓�������͂��Ă�������\r\n");
							}
							catch
							{
								�G���[�o��(iCnt, 26, "�o�^����yyyyMMdd�̌`���œ��͂��Ă�������\r\n");
							}
						}
						else 
							sValue[25] = s����;
// MOD 2006.06.29 ���s�j�R�{ �o�^���ȗ����̃V�X�e�����t�ҏW�Ή� END
						sKey[40] = sValue[25];
// MOD 2010.02.25 ���s�j���� ���ڐ��`�F�b�N�̏C�� START
					}
// MOD 2010.02.25 ���s�j���� ���ڐ��`�F�b�N�̏C�� END
					//�w���
					sKey[29] = "0";
					//�w����敪
					sKey[30] = "0";
// AOD 2006.10.05 FJCS�j�K�c ���ڂ̕ύX�i�\���P��z�B�w����ɂ���j START
					sValue[19] = sValue[19].Trim();
					if (sValue[19] == "0")	sValue[19]="";
					if (sValue[19].Length != 0)
					{
// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� START
						if(sValue[19].Length != 8){
							�G���[�o��(iCnt, 20, "�z�B�w����͂W�����œ��͂��Ă�������\r\n");
						}else{
// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� END
						try
						{
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N START
//							DateTime dtWork0 = new DateTime(int.Parse(sValue[19].Substring(0,4)),int.Parse(sValue[19].Substring(4,2)), int.Parse(sValue[19].Substring(6)));
//							DateTime dtWork = new DateTime(int.Parse(s����.Substring(0,4)),int.Parse(s����.Substring(4,2)), int.Parse(s����.Substring(6)));
//							DateTime dt�w��� =dtWork.AddMonths(1);
//							string   dt���Z�w��� = YYYYMMDD�ϊ�(dt�w���);
//							if (int.Parse(sValue[19]) >= int.Parse(dt���Z�w���) ) �G���[�o��(iCnt, 20, "�z�B�w����͓����ȍ~�P�����ȓ��œ��͂��Ă�������\r\n");
//							if (int.Parse(sValue[19]) < int.Parse(s����) ) �G���[�o��(iCnt, 20, "�z�B�w����͓����ȍ~����͂��Ă�������\r\n");
							DateTime dt�z�B�w��� = new DateTime(
															int.Parse(sValue[19].Substring(0,4))
															, int.Parse(sValue[19].Substring(4,2))
															, int.Parse(sValue[19].Substring(6)));
							// ADD-S 2012.09.26 COA)���R ���t���ڎ捞����
							bool	wk_bNoErr_�z�B�w���	= true;
							// ADD-E 2012.09.26 COA)���R ���t���ڎ捞����

							if(b�o�ד��ݒ�){
// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� START
//								//�o�ד�����P�S���܂�
//								if(dt�z�B�w��� < dt�o�ד�)
//								{
//									�G���[�o��(iCnt, 20, "�z�B�w����͏o�ד��ȍ~����͂��Ă�������\r\n");
//								}
//								if(dt�z�B�w��� > dt�o�ד�.AddDays(14))
//								{
//									�G���[�o��(iCnt, 20, "�z�B�w�����" + dt�o�ד�.AddDays(14).ToString(" M�� d��")
//									 + "�ȑO����͂��Ă�������\r\n");
//								}
								//�o�ד�����i�P�S�� or �X�O���j�܂�
								DateTime dt�w����ő�l;
// MOD 2009.12.08 ���s�j���� �w����̏����Q�i��L�̃O���[�o���Ή��̏�Q�jSTART
//								if(gs����X���b�c.Equals("047")){
//									dt�w����ő�l = gdt�o�ד�.AddDays(90);
//								}else{
//									dt�w����ő�l = gdt�o�ד�.AddDays(14);
//								}
								if(gs����X���b�c.Equals("047")){
									dt�w����ő�l = dt�o�ד�.AddDays(90);
								}else{
									dt�w����ő�l = dt�o�ד�.AddDays(14);
								}
// MOD 2009.12.08 ���s�j���� �w����̏����Q�i��L�̃O���[�o���Ή��̏�Q�jEND
// MOD 2016.04.13 BEVAS�j���{ �z�B�w�������̊g�� START
								//�Z���A�l�̏ꍇ�A�z�B�w����̏����180���ɂ܂Ŋg��
								if(gs����b�c.Equals(gs�w�������g������b�c))
								{
									dt�w����ő�l = dt�o�ד�.AddDays(180);
								}
// MOD 2016.04.13 BEVAS�j���{ �z�B�w�������̊g�� END
								if(dt�z�B�w��� < dt�o�ד�)
								{
									�G���[�o��(iCnt, 20, "�z�B�w����͏o�ד��ȍ~����͂��Ă�������\r\n");
									// ADD-S 2012.09.26 COA)���R ���t���ڎ捞����
									wk_bNoErr_�z�B�w���	= false;
									// ADD-E 2012.09.26 COA)���R ���t���ڎ捞����

								}
								if(dt�z�B�w��� > dt�w����ő�l)
								{
									�G���[�o��(iCnt, 20, "�z�B�w�����" + dt�w����ő�l.ToString(" M�� d��")
									 + "�ȑO����͂��Ă�������\r\n");
									// ADD-S 2012.09.26 COA)���R ���t���ڎ捞����
									wk_bNoErr_�z�B�w���	= false;
									// ADD-E 2012.09.26 COA)���R ���t���ڎ捞����
								}

								// ADD-S 2012.09.26 COA)���R ���t���ڎ捞����
								if (wk_bNoErr_�z�B�w��� == true) 
								{
									sValue[19] =  YYYYMMDD�ϊ�(dt�z�B�w���);
								}
								// ADD-E 2012.09.26 COA)���R ���t���ڎ捞����
// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� END
							}
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N END
						}
						catch
						{
							�G���[�o��(iCnt, 20, "�z�B�w�����yyyyMMdd�̌`���œ��͂��Ă�������\r\n");
						}
// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� START
						}
// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� END
						sKey[29] = sValue[19];
						sKey[30] = "1"; // 1:�w��
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
						if(i�b�r�u�G���g���[�`�� == 2){
							if(sValue�ꗗ�s[(int)�`���Q.�K���敪].Length != 0){
								if(���p�`�F�b�N(sValue�ꗗ�s[(int)�`���Q.�K���敪])){
									if(sValue�ꗗ�s[(int)�`���Q.�K���敪] == "0"){
										sKey[30] = "0"; // 0:�K�� 1:�w��
									}else if(sValue�ꗗ�s[(int)�`���Q.�K���敪] == "1"){
										sKey[30] = "1"; // 0:�K�� 1:�w��
									}else{
										�G���[�o�͂Q(iCnt, (int)�`���Q.�K���敪
										, "�K���敪��[0]��������[1]�œ��͂��Ă�������\r\n");
									}
								}else{
									if(sValue�ꗗ�s[(int)�`���Q.�K���敪] == "�K��"){
										sKey[30] = "0"; // 0:�K�� 1:�w��
									}else if(sValue�ꗗ�s[(int)�`���Q.�K���敪] == "�w��"){
										sKey[30] = "1"; // 0:�K�� 1:�w��
									}else{
										�G���[�o�͂Q(iCnt, (int)�`���Q.�K���敪
										, "�K���敪��[�K��]��������[�w��]�œ��͂��Ă�������\r\n");
									}
								}
							}
						}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
					}
// ADD 2006.10.05 FJCS�j�K�c ���ڂ̕ύX�i�\���P��z�B�w����ɂ���j END
					//����󔭍s�ςe�f
					sKey[41] = "0";
					//�o�׍ςe�f
					sKey[42] = "0";
					//�ꊇ�o�ׂe�f
					sKey[43] = "0";
					sKey[44] = "�����o��";
					sKey[45] = gs���p�҂b�c;
					
					StringBuilder sbKeyData = new StringBuilder();
					for (int j = 0; j < sKey.Length; j++)
					{
						sbKeyData.Append(sKey[j] + ",");
					}
					s�捞�f�[�^[iCnt - 1] = sbKeyData.ToString();
				}
				tex���b�Z�[�W.Text = "";
				axGT�捞�f�[�^�ꗗ.Focus();
			}
			catch (Exception ex)
			{
				tex���b�Z�[�W.Text = ex.Message;
				axGT�捞�f�[�^�ꗗ.Clear();
// ADD 2007.02.21 ���s�j���� ������̃J�����ʒu�̒��� START
				axGT�捞�f�[�^�ꗗ.CaretRow = 1;
				axGT�捞�f�[�^�ꗗ.CaretCol = 1;
				axGT�捞�f�[�^�ꗗ_CurPlaceChanged(null,null);
// ADD 2007.02.21 ���s�j���� ������̃J�����ʒu�̒��� END
				b�捞 = false;
				b�G���[�o�� = false;
			}
			finally
			{
				sr.Close();
			}

// MOD 2010.03.18 ���s�j���� �f�[�^�����`�F�b�N�̒ǉ� START
			if(s�捞�f�[�^.Length == 1){
				if(s�捞�f�[�^[0] == null){
					Cursor = System.Windows.Forms.Cursors.Default;
					tex���b�Z�[�W.Text = "�f�[�^������܂���";
					tex���b�Z�[�W.Refresh();
					return;
				}else if(s�捞�f�[�^[0].Trim().Length == 0){
					Cursor = System.Windows.Forms.Cursors.Default;
					tex���b�Z�[�W.Text = "�f�[�^������܂���";
					tex���b�Z�[�W.Refresh();
					return;
				}
			}
// MOD 2010.03.18 ���s�j���� �f�[�^�����`�F�b�N�̒ǉ� END

			if (b�捞)
				btn�捞.Enabled = true;
			else
				tex���b�Z�[�W.Text += "�G���[������܂�";
			if (b�G���[�o��)
				btn�ꗗ�\.Enabled = true;
			Cursor = System.Windows.Forms.Cursors.Default;

// ADD 2006.06.29 ���s�j�R�{ �捞�������G���[�����̕\���Ή� START
			if (b�G���[�o��)
			{
				for(int Kensu=0;Kensu < s�捞�G���[.Length ;Kensu++)
				{
// MOD 2006.10.16 FJCS�j�K�c �o�O�C�� START
					//if(s�捞�G���[[Kensu].Length != 0)
					if(s�捞�G���[[Kensu] != null)
// MOD 2006.10.016FJCS�j�K�c �o�O�C�� END
						i�G���[����++;
				}
			}
			int Wrkcnt = i�捞���� - i�G���[����;
			lblInputCnt.Text=Wrkcnt.ToString()+"��";
			lblErrorCnt.Text=i�G���[����.ToString()+"��";
// ADD 2006.06.29 ���s�j�R�{ �捞�������G���[�����̕\���Ή� END
		}

		private void btn�捞_Click(object sender, System.EventArgs e)
		{
// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� START
			btn�捞.Enabled = false;
			btn�捞.Refresh();
			tex���b�Z�[�W.Text = "�捞���D�D�D";
			tex���b�Z�[�W.Refresh();
			Cursor = System.Windows.Forms.Cursors.AppStarting;
// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� END
			try
			{
				if (sv_syukka == null)
				{
					sv_syukka = new is2syukka.Service1();
// DEL 2005.05.20 ���s�j���� �Z�V�����R���g���[���̔p�~ START
//					sv_syukka.CookieContainer = cContainer;
// DEL 2005.05.20 ���s�j���� �Z�V�����R���g���[���̔p�~ END
				}
				string[] sRet = sv_syukka.Ins_autoEntryData(gsa���[�U,s�捞�f�[�^);
				tex���b�Z�[�W.Text = sRet[0];
				if(sRet[0].Length == 0)
				{
					MessageBox.Show("����Ɏ�荞�܂�܂���","�b�r�u�G���g���[",MessageBoxButtons.OK);
				}
// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� START
				else
				{
					btn�捞.Enabled = true;
				}
// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� END
			}
// ADD 2005.07.05 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				tex���b�Z�[�W.Text = gs�ʐM�G���[;
// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� START
				btn�捞.Enabled = true;
// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� END
			}
// ADD 2005.07.05 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				tex���b�Z�[�W.Text = ex.Message;
// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� START
				btn�捞.Enabled = true;
// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� END
			}
// MOD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� START
//			btn�捞.Enabled = false;
			Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� END
		}

// DEL 2005.06.30 ���s�j�����J ���ʃt�H�[���ֈړ� START
//		private bool �K�{�`�F�b�N(string data)
//		{
//			if (data.Trim().Length == 0)
//				return false;
//			else
//				return true;
//		}
//
//		private bool �S�p�`�F�b�N(string data)
//		{
//			string sUnicode = data;
//			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
//			if(bSjis.Length == sUnicode.Length * 2) return true;
//			return false;
//		}
//
//		private bool ���p�`�F�b�N(string data)
//		{
//			string sUnicode = data;
//			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
//			if(bSjis.Length != sUnicode.Length) return false;
//			return true;
//		}
//
//		private bool ���l�`�F�b�N(string data)
//		{
//			try
//			{
//				int iChk = int.Parse(data.Replace(",",""));
//				return true;
//			}
//			catch(System.FormatException)
//			{
//				return false;
//			}
//		}
// DEL 2005.06.30 ���s�j�����J ���ʃt�H�[���ֈړ� END

		private void �G���[�o��(int nRow, int nCol, string message)
		{
//			axGT�捞�f�[�^�ꗗ.set_CelBackColor((short)nRow,(short)(nCol + 1),0x0000FF);
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
			if(i�b�r�u�G���g���[�`�� == 2){
				switch(nCol - 1){
				case (int)�`���P.��: // 11
					nCol = (int)�`���Q.��;
					nCol++;
					break;
				case (int)�`���P.�ː�: // 12
					nCol = (int)�`���Q.�ː�;
					nCol++;
					break;
				case (int)�`���P.�d��: // 13
					nCol = (int)�`���Q.�d��;
					nCol++;
					break;
				case (int)�`���P.�A�����i�P: // 14
					nCol = (int)�`���Q.�A�����i�P;
					nCol++;
					break;
				case (int)�`���P.�A�����i�Q: // 15
					nCol = (int)�`���Q.�A�����i�Q;
					nCol++;
					break;
				case (int)�`���P.�i���L���P: // 16
					nCol = (int)�`���Q.�i���L���P;
					nCol++;
					break;
				case (int)�`���P.�i���L���Q: // 17
					nCol = (int)�`���Q.�i���L���Q;
					nCol++;
					break;
				case (int)�`���P.�i���L���R: // 18
					nCol = (int)�`���Q.�i���L���R;
					nCol++;
					break;
				case (int)�`���P.�z�B�w���: // 19
					nCol = (int)�`���Q.�z�B�w���;
					nCol++;
					break;
				case (int)�`���P.���q�l�Ǘ��ԍ�: // 20
					nCol = (int)�`���Q.���q�l�Ǘ��ԍ�;
					nCol++;
					break;
//				case (int)�`���P.�\��:
//					break;
				case (int)�`���P.�����敪: // 22
					nCol = (int)�`���Q.�����敪;
					nCol++;
					break;
				case (int)�`���P.�ی����z: // 23
					nCol = (int)�`���Q.�ی����z;
					nCol++;
					break;
				case (int)�`���P.�o�ד��t: // 24
					nCol = (int)�`���Q.�o�ד��t;
					nCol++;
					break;
				case (int)�`���P.�o�^���t: // 25
					nCol = (int)�`���Q.�o�^���t;
					nCol++;
					break;
				}
			}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
			axGT�捞�f�[�^�ꗗ.set_CelMarking((short)nRow,(short)(nCol),true);
			s�捞�G���[[nRow - 1] += message;
			b�捞 = false;
			b�G���[�o�� = true;
		}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
		private void �G���[�o�͂Q(int nRow, int nCol, string message)
		{
			axGT�捞�f�[�^�ꗗ.set_CelMarking((short)nRow,(short)(nCol + 1),true);
			s�捞�G���[[nRow - 1] += message;
			b�捞 = false;
			b�G���[�o�� = true;
		}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END

		private void axGT�捞�f�[�^�ꗗ_CelDblClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelDblClickEvent e)
		{
			if (s�捞�G���[.Length < axGT�捞�f�[�^�ꗗ.CaretRow) return;
			string errMessage = s�捞�G���[[(int)axGT�捞�f�[�^�ꗗ.CaretRow - 1];
			if (errMessage.Trim().Length != 0) MessageBox.Show(errMessage,"���̓`�F�b�N",MessageBoxButtons.OK);
		}

		private void axGT�捞�f�[�^�ꗗ_CurPlaceChanged(object sender, AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEvent e)
		{
			axGT�捞�f�[�^�ꗗ.set_CelForeColor(nOldRow,0,0);
			axGT�捞�f�[�^�ꗗ.set_CelBackColor(nOldRow,0,0xFFFFFF);
			axGT�捞�f�[�^�ꗗ.set_CelForeColor(axGT�捞�f�[�^�ꗗ.CaretRow,0,0x98FB98);  //BGR
			axGT�捞�f�[�^�ꗗ.set_CelBackColor(axGT�捞�f�[�^�ꗗ.CaretRow,0,0x006000);
			nOldRow = axGT�捞�f�[�^�ꗗ.CaretRow;
		}

		private void �����o�דo�^_Closed(object sender, System.EventArgs e)
		{
			tex�t�@�C����.Text  = " ";
			tex���b�Z�[�W.Text  = "";
			axGT�捞�f�[�^�ꗗ.Clear();
			axGT�捞�f�[�^�ꗗ.CaretRow  = 1;
// ADD 2007.02.21 ���s�j���� ������̃J�����ʒu�̒��� START
			axGT�捞�f�[�^�ꗗ.CaretCol = 1;
// ADD 2007.02.21 ���s�j���� ������̃J�����ʒu�̒��� END
			axGT�捞�f�[�^�ꗗ_CurPlaceChanged(null,null);
			tex�t�@�C����.Focus();
		}

// ADD 2005.06.08 ���s�j�ɉ� �ꗗ�\�o�͒ǉ� START
		private void btn�ꗗ�\_Click(object sender, System.EventArgs e)
		{
			tex���b�Z�[�W.Text = "�G���[�ꗗ������D�D�D";
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;

			int i�s�ԍ� = 1;
			�����o�׃G���[�f�[�^ ds = new �����o�׃G���[�f�[�^();
			for (int iCnt = 0; iCnt < s�捞�G���[.Length; iCnt++)
			{
				if (s�捞�G���[[iCnt] == null) continue;
				string[] s�捞�G���[�ڍ� = s�捞�G���[[iCnt].Replace("\r\n", ",").Split(',');
				for (int jCnt = 0; jCnt < s�捞�G���[�ڍ�.Length - 1; jCnt++)
				{
					�����o�׃G���[�f�[�^.table�����o�׃G���[Row tr = (�����o�׃G���[�f�[�^.table�����o�׃G���[Row)ds.table�����o�׃G���[.NewRow();
					tr.BeginEdit();
					tr.�ԍ� = i�s�ԍ�++;
					tr.�G���[�s = (iCnt + 1).ToString() + "�s��";
					tr.�G���[���e = s�捞�G���[�ڍ�[jCnt];
					tr.EndEdit();
					ds.table�����o�׃G���[.Rows.Add(tr);					
				}
			}
			�����o�׃G���[���[ cr = new �����o�׃G���[���[();
			//CrystalReport�Ƀp�����[�^�ƃf�[�^�Z�b�g��n��
			cr.SetParameterValue("����b�c", gs����b�c);
			cr.SetParameterValue("���喼",   gs���喼);
			cr.SetParameterValue("�Ώۃt�@�C��", s�Ώۃt�@�C��);
			cr.SetDataSource(ds);
			this.Cursor = System.Windows.Forms.Cursors.Default;

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
// ADD 2005.06.08 ���s�j�ɉ� �ꗗ�\�o�͒ǉ� END
// ADD 2008.04.11 ACT Vista�Ή� START
		private void �����ϊ���o��(int nRow, int nCol, string message)
		{
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
			if(i�b�r�u�G���g���[�`�� == 2){
				switch(nCol - 1){
				case (int)�`���P.�A�����i�P:
					nCol = (int)�`���Q.�A�����i�P + 1;
					break;
				case (int)�`���P.�A�����i�Q:
					nCol = (int)�`���Q.�A�����i�Q + 1;
					break;
				case (int)�`���P.�i���L���P:
					nCol = (int)�`���Q.�i���L���P + 1;
					break;
				case (int)�`���P.�i���L���Q:
					nCol = (int)�`���Q.�i���L���Q + 1;
					break;
				case (int)�`���P.�i���L���R:
					nCol = (int)�`���Q.�i���L���R + 1;
					break;
				}
			}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
			axGT�捞�f�[�^�ꗗ.set_CelText((short)nRow, (short)nCol, message);
		}
// ADD 2008.04.11 ACT Vista�Ή� END
// MOD 2009.11.25 ���s�j���� ���Ԏw��`�F�b�N�̒ǉ� START
		private void ���Ԏw��`�F�b�N(int iCnt, string sData, int iHourMin, int iHourMax)
		{
			if(sData.Length != 9){
//				�G���[�o��(iCnt, 16, "�A�����i�Q�̎��Ԏw��̕����̒����Ɍ�肪����܂�\r\n");
				�G���[�o��(iCnt, 16, "�A�����i�Q�̎��Ԏw��Ɍ�肪����܂�["+sData+"]\r\n");
				return;
			}
			if(!sData.Substring(6,1).Equals("��")){
//				�G���[�o��(iCnt, 16, "�A�����i�Q�̎��Ԏw��̎����Ɍ�肪����܂�[��]\r\n");
				�G���[�o��(iCnt, 16, "�A�����i�Q�̎��Ԏw��Ɍ�肪����܂�["+sData+"]\r\n");
				return;
			}
			string s���� = sData.Substring(4,2);
			int iHour = 0;
			for(int iPos = 0;iPos < sa���Ԏw��`�F�b�N.Length; iPos++){
				if(s����.Equals(sa���Ԏw��`�F�b�N[iPos])){
					iHour = 10 + iPos;
					break;
				}
			}
			if(iHour == 0 || iHour < iHourMin || iHour > iHourMax){
				�G���[�o��(iCnt, 16, "�A�����i�Q�̎��Ԏw��̎����Ɍ�肪����܂�["+s����+"]\r\n");
				return;
			}
		}
// MOD 2009.11.25 ���s�j���� ���Ԏw��`�F�b�N�̒ǉ� END
	}
}
