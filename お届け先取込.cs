using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Text;

namespace IS2Client
{
	/// <summary>
	/// ���͂���捞
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// ADD 2008.04.23 ���s�j���� �Œ蒷�t�@�C���̃G���[�t�@�C���o�͑Ή� 
	// �`�b�s�j�R�{�a����Q�񍐗L
	// ���ہF�Œ蒷�t�@�C���捞���A�G���[������ɂ�������炸�c�a���X�V�����
	// �����F�Œ蒷�t�@�C���ւ̑Ή�����
	// ADD 2008.04.11 ACT Vista�Ή� 
	// ADD 2008.05.15 ACT Vista�Ή��i�G���[�����\���j 
	//--------------------------------------------------------------------------
	// MOD 2009.04.06 ���s�j���� �擪�s�����@�\�̒ǉ� 
	// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� 
	// MOD 2009.12.01 ���s�j���� �f�[�^�o�^���̃G���[�`�F�b�N��ǉ� 
	//--------------------------------------------------------------------------
	// MOD 2010.03.12 ���s�j���� �P�O�O�O�O���`�F�b�N�����@�\�̒ǉ� 
	// MOD 2010.03.30 ���s�j���� �d�b�ԍ��`���ǉ��Ή� 
	// MOD 2010.03.30 ���s�j���� �g�ѓd�b�Ή� 
	// MOD 2010.04.26 ���s�j���� �P�O�O�O�O���`�F�b�N�@�\�̕ύX 
	// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� 
	// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� 
	// MOD 2010.11.25 ���s�j���� GetAsyncKeyState�̒��� 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� 
	//--------------------------------------------------------------------------
	// MOD 2015.05.13 BEVAS) �O�c ���q����l�̗X�֔ԍ��`�F�b�N�����q�}�X�^�ōs��
	//--------------------------------------------------------------------------
	public class ���͂���捞 : ���ʃt�H�[��
	{
		private string fileName = "";
// ADD 2006.06.30 ���s�j�R�{�@�捞���̎捞�������G���[�����̕\���Ή� START
		private int i�o�^����		= 0;
		private int i�G���[����		= 0;
// MOD 2007.01.17 FJCS) �K�c�@�׎呍�������V�[�g�������ɕύX START
//		private int i�׎呍����		= 0;
		private int i�V�[�g������	= 0;
// MOD 2007.01.17 FJCS) �K�c�@�׎呍�������V�[�g�������ɕύX END
// ADD 2006.06.30 ���s�j�R�{�@�捞���̎捞�������G���[�����̕\���Ή� END
// DEL 2006.12.01 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̍폜 START
//// ADD 2006.07.14 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̒ǉ� START
//		private static Hashtable h�s���{���Q = null;
//		private static string s�����܂�����
//			= "�P��Q��R�Q�S�T�U�V�W�X�̔T���K�����|";
//		private static string s�����܂������ϊ�
//			= "�����O�O�l�ܘZ������m�m�P�P�P�P�c�[";
//		private static string[] sa������
//		= {
//			 "�����b�˚�佚���Οy�����j�Z�T誙ǟT����"
//			,"�z�I�ĉo�ʙ�郚��|��d���g��^�w��t�r��"
//			,"�J斛��`���Z�d�Ӝ~�����G���y�ꝰ���v�S"
//			,"�{�Ԟ��}�������ɟc����V�|�g��蜊�����"
//			,"�y��M���P�d��ꝙE�Eน����p���������p�v"
//			,"��꟝������{��㸜l���ڝ����S����j���P"
//			,"�Y㞙r�L�����������p���鄚��hꉝ��A����"
//			,"�k�i���c�����Z�ꙝ���s���N�e�ᦙҜ̞�"
//			,"����ӟk�N��ꏘ��Z��[����A�q���י��"
//			,"����榜n�F���s��Ù|���R�����О_���i暘�"
//			,"���Śߛo�����g�t��Ԛ��\�����ĝ��������"
//			,"�ʚ��C���������钝ɞ���[�Ő������V���"
//			,"���D���I�_��t�����A��W�\���^��ꋙԚ�r"
//			,"����x�`��������z�f�U��㔙���֑ƞ��[��"
//			,"����i�띢�V����漚d�^�[���[������o�"
//			,"����h�k浜L�U���U�����N����d��z�y�B�\"
//			,"���}�����X���c�骘���椞\��㊘����K�"
//			,"���I�P�E�`�u����墙���㭝U���O�w�u�_�y"
//			,"�c�ś���y�����s�n�����������᤟���"
//			,"��ꠘ��ݟ���������p���U�W�\�Z��MሗO��"
//			,"�P�o棝����~����ꡘҘ��T�_�P�V���_�y��"
//			,"�A������ܟ����X���ꔜ���࢙��L�����R�i"
//			,"�s��ઘ�G����㰛�ⲛ������B�]柚�藚��"
//			,"�Q���D�f�k�����猜S�^霜��͜�@�M���מD"
//			,"���F����A�J�r�m�w���w��������������"
//			,"�f������h�����������T�������"
//			,"��������������X��l�p��m�r�����H��"
//			,"�����@�I�V�n��"
//		};
//		private static string[] sa�V����
//		= {
//			 "�������������͈׈���������B�K�T�X�b"
//			,"�c�g�h�n�q�r�w�~������������������������"
//			,"���܉�����������G�I�V�W�a�b�g�h�k�o"
//			,"�w�x�y���������������ʊϊЊӊ֊׊׊ي��"
//			,"���������A�C�T�U�Y�]�p����������������"
//			,"���ċŋɋ��M�Q�a�b�e�g�k�o�p�s�u�y�z�{"
//			,"�|���������������������������Ռی��L�P�W"
//			,"�e�z���������ύӍ܍���������G�H�Q�S�V"
//			,"�\�]�^�c�������������������ǎɎʎߎ��"
//			,"���H�Q�]�a�b�c�l�����������������ď̏؏�"
//			,"�����������������G�O�Q�T�W�^�n�s�x"
//			,"�|�}�~���������������������������ÐĐې�"
//			,"��������@�D�G�H�K�P�T�]�a�h�k�l�o�s�{"
//			,"�}�����������������������������Ǒȑ̑�"
//			,"�ёؑ������B�G�K�P�S�_�c�e�f�p�s�t�x"
//			,"�������������������������ْ��S�Z�]�_�`�e"
//			,"�v�}�����������������ƓǓȓ͓����B�D�U"
//			,"�Y�]�e�p�q�t�~���������������ؔ�O�X�l�x"
//			,"���������͕ϕӕٕܕ����G�J�L�`�e�v�{"
//			,"�|�����������������˖ٖݖ��������N�\"
//			,"�]�^�_�h�l�q�s�w�x�y��������������������"
//			,"�ėƗחڗۗܗ���������F�J�N�O�U�\�j"
//			,"�p���ט�H�l�m�p�����ƙ̙͙Ϛ\����������"
//			,"�����C�e�j���ěƜN�R�]�i���Μ���L���؞E"
//			,"�e������@�K�s�������v����������������"
//			,"�e�n����g�����������S�����l��"
//			,"��������������W�\�k�q��n�s�~����G��"
//			,"�����A�H�U�o�"
//		};
//// ADD 2006.07.14 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̒ǉ� END
// DEL 2006.12.01 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̍폜 END

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
		private System.Windows.Forms.Label lab���͂���捞;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lab�t�@�C����;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�t�@�C����;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn�J��;
		private System.Windows.Forms.Button btn�捞;
		private System.Windows.Forms.TextBox tex�f�[�^�G���[;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lbl�G���[����;
		private System.Windows.Forms.Label lbl�捞����;
		private System.Windows.Forms.Label label4;
// MOD 2007.01.17 FJCS) �K�c�@�׎呍�������V�[�g�������ɕύX START
//		private System.Windows.Forms.Label lbl�׎呍����;
		private System.Windows.Forms.Label lbl�V�[�g������;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox cBox�擪�s����;
// MOD 2007.01.17 FJCS) �K�c�@�׎呍�������V�[�g�������ɕύX END
		private System.Windows.Forms.OpenFileDialog ofd���͂���f�[�^;

		public ���͂���捞()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
			�c�o�h�\���T�C�Y�ϊ�();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(���͂���捞));
			this.panel6 = new System.Windows.Forms.Panel();
			this.tex���q�l�� = new System.Windows.Forms.TextBox();
			this.lab���q�l�� = new System.Windows.Forms.Label();
			this.lab���p���� = new System.Windows.Forms.Label();
			this.tex���p���� = new System.Windows.Forms.TextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab���� = new System.Windows.Forms.Label();
			this.lab���͂���捞 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.tex���b�Z�[�W = new System.Windows.Forms.TextBox();
			this.btn���� = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cBox�擪�s���� = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.lbl�V�[�g������ = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lbl�捞���� = new System.Windows.Forms.Label();
			this.lbl�G���[���� = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tex�f�[�^�G���[ = new System.Windows.Forms.TextBox();
			this.btn�捞 = new System.Windows.Forms.Button();
			this.lab�t�@�C���� = new System.Windows.Forms.Label();
			this.tex�t�@�C���� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.btn�J�� = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.ofd���͂���f�[�^ = new System.Windows.Forms.OpenFileDialog();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox2.SuspendLayout();
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
			this.lab���p����.Location = new System.Drawing.Point(18, 8);
			this.lab���p����.Name = "lab���p����";
			this.lab���p����.Size = new System.Drawing.Size(54, 14);
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
			this.panel7.Controls.Add(this.lab���͂���捞);
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
			// lab���͂���捞
			// 
			this.lab���͂���捞.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab���͂���捞.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���͂���捞.ForeColor = System.Drawing.Color.White;
			this.lab���͂���捞.Location = new System.Drawing.Point(12, 2);
			this.lab���͂���捞.Name = "lab���͂���捞";
			this.lab���͂���捞.Size = new System.Drawing.Size(264, 24);
			this.lab���͂���捞.TabIndex = 0;
			this.lab���͂���捞.Text = "���͂���捞";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.tex���b�Z�[�W);
			this.panel8.Controls.Add(this.btn����);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 14;
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
			this.groupBox2.Controls.Add(this.cBox�擪�s����);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.lbl�V�[�g������);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.lbl�捞����);
			this.groupBox2.Controls.Add(this.lbl�G���[����);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.tex�f�[�^�G���[);
			this.groupBox2.Controls.Add(this.btn�捞);
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
			// cBox�擪�s����
			// 
			this.cBox�擪�s����.ForeColor = System.Drawing.Color.LimeGreen;
			this.cBox�擪�s����.Location = new System.Drawing.Point(136, 62);
			this.cBox�擪�s����.Name = "cBox�擪�s����";
			this.cBox�擪�s����.Size = new System.Drawing.Size(196, 24);
			this.cBox�擪�s����.TabIndex = 2;
			this.cBox�擪�s����.Text = "�擪�P�s�ڂ͎�荞�܂Ȃ�";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label5.ForeColor = System.Drawing.Color.Red;
			this.label5.Location = new System.Drawing.Point(136, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(176, 16);
			this.label5.TabIndex = 57;
			this.label5.Text = "CSV�t�@�C����I�����Ă��������B";
			// 
			// lbl�V�[�g������
			// 
			this.lbl�V�[�g������.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lbl�V�[�g������.ForeColor = System.Drawing.Color.Black;
			this.lbl�V�[�g������.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lbl�V�[�g������.Location = new System.Drawing.Point(232, 344);
			this.lbl�V�[�g������.Name = "lbl�V�[�g������";
			this.lbl�V�[�g������.Size = new System.Drawing.Size(64, 14);
			this.lbl�V�[�g������.TabIndex = 52;
			this.lbl�V�[�g������.Text = "0��";
			this.lbl�V�[�g������.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label4.ForeColor = System.Drawing.Color.LimeGreen;
			this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label4.Location = new System.Drawing.Point(136, 344);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 14);
			this.label4.TabIndex = 50;
			this.label4.Text = "�������F";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbl�捞����
			// 
			this.lbl�捞����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lbl�捞����.ForeColor = System.Drawing.Color.Black;
			this.lbl�捞����.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lbl�捞����.Location = new System.Drawing.Point(464, 344);
			this.lbl�捞����.Name = "lbl�捞����";
			this.lbl�捞����.Size = new System.Drawing.Size(48, 14);
			this.lbl�捞����.TabIndex = 49;
			this.lbl�捞����.Text = "0��";
			this.lbl�捞����.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbl�G���[����
			// 
			this.lbl�G���[����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lbl�G���[����.ForeColor = System.Drawing.Color.Black;
			this.lbl�G���[����.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lbl�G���[����.Location = new System.Drawing.Point(592, 344);
			this.lbl�G���[����.Name = "lbl�G���[����";
			this.lbl�G���[����.Size = new System.Drawing.Size(48, 14);
			this.lbl�G���[����.TabIndex = 48;
			this.lbl�G���[����.Text = "0��";
			this.lbl�G���[����.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label3.ForeColor = System.Drawing.Color.LimeGreen;
			this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label3.Location = new System.Drawing.Point(528, 344);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 14);
			this.label3.TabIndex = 47;
			this.label3.Text = "�G���[�����F";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label2.ForeColor = System.Drawing.Color.LimeGreen;
			this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label2.Location = new System.Drawing.Point(400, 344);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 14);
			this.label2.TabIndex = 46;
			this.label2.Text = "�捞�����F";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tex�f�[�^�G���[
			// 
			this.tex�f�[�^�G���[.BackColor = System.Drawing.SystemColors.Window;
			this.tex�f�[�^�G���[.Location = new System.Drawing.Point(136, 94);
			this.tex�f�[�^�G���[.Multiline = true;
			this.tex�f�[�^�G���[.Name = "tex�f�[�^�G���[";
			this.tex�f�[�^�G���[.ReadOnly = true;
			this.tex�f�[�^�G���[.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tex�f�[�^�G���[.Size = new System.Drawing.Size(504, 240);
			this.tex�f�[�^�G���[.TabIndex = 4;
			this.tex�f�[�^�G���[.Text = "";
			this.tex�f�[�^�G���[.WordWrap = false;
			// 
			// btn�捞
			// 
			this.btn�捞.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�捞.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�捞.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�捞.ForeColor = System.Drawing.Color.White;
			this.btn�捞.Location = new System.Drawing.Point(650, 64);
			this.btn�捞.Name = "btn�捞";
			this.btn�捞.Size = new System.Drawing.Size(65, 22);
			this.btn�捞.TabIndex = 3;
			this.btn�捞.TabStop = false;
			this.btn�捞.Text = "�捞";
			this.btn�捞.Click += new System.EventHandler(this.btn�捞_Click);
			// 
			// lab�t�@�C����
			// 
			this.lab�t�@�C����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�t�@�C����.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�t�@�C����.Location = new System.Drawing.Point(72, 40);
			this.lab�t�@�C����.Name = "lab�t�@�C����";
			this.lab�t�@�C����.Size = new System.Drawing.Size(60, 14);
			this.lab�t�@�C����.TabIndex = 15;
			this.lab�t�@�C����.Text = "�t�@�C����";
			// 
			// tex�t�@�C����
			// 
			this.tex�t�@�C����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�t�@�C����.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.tex�t�@�C����.Location = new System.Drawing.Point(136, 32);
			this.tex�t�@�C����.MaxLength = 100;
			this.tex�t�@�C����.Name = "tex�t�@�C����";
			this.tex�t�@�C����.Size = new System.Drawing.Size(504, 23);
			this.tex�t�@�C����.TabIndex = 0;
			this.tex�t�@�C����.Text = "";
			// 
			// btn�J��
			// 
			this.btn�J��.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�J��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�J��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�J��.ForeColor = System.Drawing.Color.White;
			this.btn�J��.Location = new System.Drawing.Point(650, 32);
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
			// ofd���͂���f�[�^
			// 
			this.ofd���͂���f�[�^.FileOk += new System.ComponentModel.CancelEventHandler(this.of���͂���f�[�^_FileOk);
			// 
			// ���͂���捞
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
			this.Name = "���͂���捞";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 ���͂���捞";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
			this.Load += new System.EventHandler(this.���͂���捞_Load);
			this.Closed += new System.EventHandler(this.���͂���捞_Closed);
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
		private void ���͂���捞_Load(object sender, System.EventArgs e)
		{
			// �w�b�_�[���ڂ̐ݒ�
			tex���q�l��.Text = gs���p�Җ�;
			tex���p����.Text = gs����b�c + " " + gs���喼;

			// �����̏����ݒ�
			lab����.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled = true;

			// �f�t�H���g�̃t�H���_���f�X�N�g�b�v�t�H���_�ɂ���
			ofd���͂���f�[�^.InitialDirectory
				= Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			ofd���͂���f�[�^.Filter = "�t�@�C�� (*.csv;*.dat)|*.csv;*.dat|���ׂ�(*.*)|*.*";
// ADD 2006.07.03 ���s�j�R�{ �捞�������G���[�����̕\���Ή� START
			lbl�捞����.Text="0��";
			lbl�G���[����.Text="0��";
// MOD 2007.01.17 FJCS) �K�c�@�׎呍�������V�[�g�������ɕύX START
//			lbl�׎呍����.Text="0��";
			lbl�V�[�g������.Text="0��";
// MOD 2007.01.17 FJCS) �K�c�@�׎呍�������V�[�g�������ɕύX END
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
			lbl�捞����.Refresh();
			lbl�G���[����.Refresh();
			lbl�V�[�g������.Refresh();
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
// ADD 2006.07.03 ���s�j�R�{ �捞�������G���[�����̕\���Ή� END
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
			ofd���͂���f�[�^.ShowDialog();
		}

		private void of���͂���f�[�^_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			tex�t�@�C����.Text = ofd���͂���f�[�^.FileName;
		}

		private void btn�捞_Click(object sender, System.EventArgs e)
		{
			tex�f�[�^�G���[.Text = "";
			fileName = tex�t�@�C����.Text;
			if (fileName.Trim().Length == 0) return;
			if (!System.IO.File.Exists(fileName))
			{
				�r�[�v��();
				tex���b�Z�[�W.Text = "�w�肵���t�@�C�������݂��܂���B";
				return;
			}
// MOD 2010.04.26 ���s�j���� �P�O�O�O�O���`�F�b�N�@�\�̕ύX START
// MOD 2010.11.25 ���s�j���� GetAsyncKeyState�̒��� START
//			bool bAltKey   = (GetAsyncKeyState(Keys.Menu    ) == 0) ? false : true;
//			bool bShiftKey = (GetAsyncKeyState(Keys.ShiftKey) == 0) ? false : true;
			bool bAltKey   = ((GetAsyncKeyState(Keys.Menu) & 0x8000) == 0) ? false : true;
			bool bShiftKey = ((GetAsyncKeyState(Keys.ShiftKey) & 0x8000) == 0) ? false : true;
// MOD 2010.11.25 ���s�j���� GetAsyncKeyState�̒��� END
			if(bAltKey && bShiftKey){
				;
			}else{
				int i���o�^�� = 0;
				tex���b�Z�[�W.Text = "�����f�[�^�����`�F�b�N���D�D�D";
				try{
					string[] sRet = {""};
					if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
					sRet = sv_otodoke.Get_otodokeCount(gsa���[�U,gs����b�c,gs����b�c);
					if(sRet[0].Length != 4){
						�r�[�v��();
						tex���b�Z�[�W.Text = sRet[0];
						return;
					}
					i���o�^�� = int.Parse(sRet[1]);
				}catch (System.Net.WebException){
					�r�[�v��();
					tex���b�Z�[�W.Text = gs�ʐM�G���[;
					return;
				}catch (Exception ex){
					�r�[�v��();
					tex���b�Z�[�W.Text = "�ʐM�G���[�F" + ex.Message;
					return;
				}

				tex���b�Z�[�W.Text = "�f�[�^�����`�F�b�N���D�D�D";
				int iDataCnt = 0;
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				StreamReader sr = null;
				try{
					string sData = null;
					sr = new StreamReader(fileName, System.Text.Encoding.Default);
					sData = sr.ReadLine();
					if( cBox�擪�s����.Checked ){
						sData = sr.ReadLine();
					}
					while(sData != null){
						string[] sValue = sData.Replace("\"", "").Replace("\'","").Split(',');
						//�P���ږڂ�"�׎�l�R�[�h"�ȊO�Ȃ�f�[�^�Ƃ݂Ȃ�
						if(!sValue[0].Equals("�׎�l�R�[�h")){
							iDataCnt++;
						}
						sData = sr.ReadLine();
					}
				}catch (Exception ex){
					�r�[�v��();
					MessageBox.Show(ex.Message,"���͂���捞",MessageBoxButtons.OK);
					return;
				}finally{
					tex���b�Z�[�W.Text = "";
					Cursor = System.Windows.Forms.Cursors.Default;
					if(sr != null) sr.Close();
				}
				if(iDataCnt == 0){
//					tex���b�Z�[�W.Text = "�f�[�^�������O���ł��B";
					�r�[�v��();
					MessageBox.Show("�f�[�^�������O���ł��B"
									, "���͂���捞", MessageBoxButtons.OK);
					return;
				}
				// �P�����𒴂���΁A�P�O�O�O���`�F�b�N
				if(i���o�^�� >= 10000){
					if(iDataCnt > 1000){
//						tex���b�Z�[�W.Text = "�f�[�^�������P�O�O�O���𒴂��Ă��܂��B";
						�r�[�v��();
						MessageBox.Show("CSV�捞�\�ő匏���i1000���j�𒴂��Ă��܂��B\n"
										+ "����ɕ����Ď捞���s���ĉ������B\n"
										+ "�i����10000���ȏ�o�^�ς̏ꍇ�A1�񂠂���̎捞�\������1000���ł��B\n"
										+ "���ݓo�^�����F"+i���o�^��+"���j"
										, "���͂���捞", MessageBoxButtons.OK);
						return;
					}
				// �P���������Ȃ�A�P�O�O�O�O���`�F�b�N
				}else{
					if(iDataCnt > 10000){
//						tex���b�Z�[�W.Text = "�f�[�^�������P�O�O�O�O���𒴂��Ă��܂��B";
						�r�[�v��();
						MessageBox.Show("CSV�捞�\�ő匏���i10000���j�𒴂��Ă��܂��B\n"
										+ "����ɕ����Ď捞���s���ĉ������B\n"
										, "���͂���捞", MessageBoxButtons.OK);
						return;
					}
				}
			}
// MOD 2010.04.26 ���s�j���� �P�O�O�O�O���`�F�b�N�@�\�̕ύX END
			tex���b�Z�[�W.Text = "���s���D�D�D";

//			if(tex�t�@�C����.Text.Trim().EndsWith(".csv"))
				�b�r�u�t�@�C���捞();
//			else
//				�c�`�s�t�@�C���捞();
		}

// MOD 2006.07.10 ���s�j�R�{ �b�r�u�捞�����l�`�w�R�O�O�O�O���i�o�^�͂P�O�O���P�ʁj�ύX START
// 2006.10.26 FJCS)�K�c �l�`�w�P�O�O�O�O���ɕύX //
		private void �b�r�u�t�@�C���捞()
		{
			StringBuilder sbErr = new StringBuilder();
// MOD 2010.04.26 ���s�j���� �P�O�O�O�O���`�F�b�N�@�\�̕ύX START
//// MOD 2010.03.12 ���s�j���� �P�O�O�O�O���`�F�b�N�����@�\�̒ǉ� START
//			bool bAltKey   = (GetAsyncKeyState(Keys.Menu    ) == 0) ? false : true;
//			bool bShiftKey = (GetAsyncKeyState(Keys.ShiftKey) == 0) ? false : true;
//// MOD 2010.03.12 ���s�j���� �P�O�O�O�O���`�F�b�N�����@�\�̒ǉ� END
// MOD 2010.04.26 ���s�j���� �P�O�O�O�O���`�F�b�N�@�\�̕ύX END

			Cursor = System.Windows.Forms.Cursors.AppStarting;
			StreamReader sr = null;
			try
			{
				sr = new StreamReader(fileName, System.Text.Encoding.Default);
			}
			catch (Exception ex)
			{
				tex���b�Z�[�W.Text = "";
				Cursor = System.Windows.Forms.Cursors.Default;
				MessageBox.Show(ex.Message,"���͂���捞",MessageBoxButtons.OK);
				return;
			}
			String errfileName = fileName + ".err";
			StreamWriter sw    = null;
			int iLenErrMsg     = 0;
			int iLenErrMsgOld  = 0;
			i�o�^����		= 0;
			i�G���[����		= 0;
// MOD 2007.01.17 FJCS) �K�c�@�׎呍�������V�[�g�������ɕύX START
//			i�׎呍����		= 0;
			i�V�[�g������		= 0;
// MOD 2007.01.17 FJCS) �K�c�@�׎呍�������V�[�g�������ɕύX END
			bool iErrorFlg   = true;
			bool iTxtMsgDsp  = true;

// MOD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� START
//			int iCnt = 1;
			int iCnt = 0;
// MOD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� END
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
			int iLineCnt = 0;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
			int iSetCnt = 0; 
			try
			{
				if (sv_otodoke == null)
				{
					sv_otodoke = new is2otodoke.Service1();
				}
				while(true)
				{
// MOD 2010.04.26 ���s�j���� �P�O�O�O�O���`�F�b�N�@�\�̕ύX START
//// MOD 2010.03.12 ���s�j���� �P�O�O�O�O���`�F�b�N�����@�\�̒ǉ� START
//				if(bAltKey && bShiftKey){
//					;
//				}else{
//// MOD 2010.03.12 ���s�j���� �P�O�O�O�O���`�F�b�N�����@�\�̒ǉ� END
//					String[] sList1 = {""};
//					sList1 = sv_otodoke.Get_ninushiCount(gsa���[�U,gs����b�c,gs����b�c);
//					int DataCnt = int.Parse(sList1[1]);
//// DEL 2007.01.17 FJCS) �K�c�@�׎呍�������V�[�g�������ɕύX START
////					i�׎呍���� = DataCnt;
//// DEL 2007.01.17 FJCS) �K�c�@�׎呍�������V�[�g�������ɕύX END
//
//// MOD 2006.10.26 FJCS)�K�c �l�`�w�P�O�O�O�O���ɕύX SATRT
////					if( DataCnt >= 30000)
////					{
////						tex���b�Z�[�W.Text = "�o�^�������R�O�O�O�O���𒴉߂��܂��B";
//					if( DataCnt >= 10000)
//					{
//// MOD 2007.02.21 ���s�j���� �������|�P�ɂȂ� START
////						tex���b�Z�[�W.Text = "�o�^�������P�O�O�O�O���𒴉߂��܂��B";
//						tex���b�Z�[�W.Text = "�o�^�������P�O�O�O�O���𒴂��Ă��܂��B";
//						i�G���[����++;
//						sbErr.Append("�o�^�������P�O�O�O�O���𒴂��Ă��܂�\r\n");
//						iErrorFlg = false;
//// MOD 2007.02.21 ���s�j���� �������|�P�ɂȂ� END
//// MOD 2006.10.26 FJCS)�K�c �l�`�w�P�O�O�O�O���ɕύX END
//						iTxtMsgDsp = false;
//						break;
//					}
//// MOD 2010.03.12 ���s�j���� �P�O�O�O�O���`�F�b�N�����@�\�̒ǉ� START
//				}
//// MOD 2010.03.12 ���s�j���� �P�O�O�O�O���`�F�b�N�����@�\�̒ǉ� END
// MOD 2010.04.26 ���s�j���� �P�O�O�O�O���`�F�b�N�@�\�̕ύX END

					string sData = sr.ReadLine();
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
//// ADD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� START
//					iCnt++;
//// ADD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� END
					if(sData != null)iCnt++;
					if(sData != null)iLineCnt++;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
 					if(sData == null)
						break;
// MOD 2009.04.06 ���s�j���� �擪�s�����@�\�̒ǉ� START
// MOD 2010.04.26 ���s�j���� �P�O�O�O�O���`�F�b�N�@�\�̕ύX START
//					if( cBox�擪�s����.Checked ){
					if( iCnt == 1 && cBox�擪�s����.Checked ){
// MOD 2010.04.26 ���s�j���� �P�O�O�O�O���`�F�b�N�@�\�̕ύX END
						sData = sr.ReadLine();
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
						if(sData != null)iLineCnt++;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
						if(sData == null){
							break;
						}
					}
// MOD 2009.04.06 ���s�j���� �擪�s�����@�\�̒ǉ� END
					ArrayList alKey = new ArrayList();
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
					string[] saData = new string[101];
					int[]    iaData = new int[101];
					int i�T�[�o���M�s = 1;
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
					while(sData != null)
					{

						byte[] bSjis = Encoding.GetEncoding("shift-jis").GetBytes(sData);

// MOD 2009.12.01 ���s�j���� ['] ���폜 START
//						string[] sValue = sData.Replace("\"", "").Split(',');
						string[] sValue = sData.Replace("\"", "").Replace("\'","").Split(',');
// MOD 2009.12.01 ���s�j���� ['] ���폜 END
						//�P�s�ڂ̂P���ږڂ�"�׎�l�R�[�h"�Ȃ�΃w�b�_�Ƃ݂Ȃ��ǂݔ�΂��܂�
						if (iCnt == 1 && sValue.Length > 0 && sValue[0].Equals("�׎�l�R�[�h"))
						{
							sData = sr.ReadLine();
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
							if(sData != null)iLineCnt++;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
							continue;
						}
// MOD 2006.12.01 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̍폜 START
//// MOD 2006.07.14 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̒ǉ� START
////						string[] sKey   = new string[21];
//						string[] sKey   = new string[22];
//// MOD 2006.07.14 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̒ǉ� END
						string[] sKey   = new string[21];
// MOD 2006.12.01 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̍폜 END

// ADD 2008.04.11 ACT Vista�Ή� START
						string sErr = "";
						string sHData = sData;
						iErrorFlg = true;
						if (!�����ϊ�_CSV(ref sHData, ref sErr))
						{
							sbErr.Append(iLineCnt + "�s��:Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							iLenErrMsg = sbErr.ToString().Trim().Length;
							iLenErrMsgOld = iLenErrMsg;
							sw = �G���[�t�@�C���o��(sw, errfileName, sData);
							if(sw == null) return;
							sData = sr.ReadLine();
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
//							iCnt++;
							if(sData != null)iCnt++;
							if(sData != null)iLineCnt++;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
// ADD 2008.05.15 ACT Vista�Ή��i�G���[�����\���j START
							i�G���[����++;
// ADD 2008.05.15 ACT Vista�Ή��i�G���[�����\���j END
							iErrorFlg = false;
							continue;
						}
						bSjis = Encoding.GetEncoding("shift-jis").GetBytes(sHData);
// MOD 2009.12.01 ���s�j���� ['] ���폜 START
//						sValue = sHData.Replace("\"", "").Split(',');
						sValue = sHData.Replace("\"", "").Replace("\'","").Split(',');
// MOD 2009.12.01 ���s�j���� ['] ���폜 END
// ADD 2008.04.11 ACT Vista�Ή� END

						if ((sValue.Length < 10 || sValue.Length > 14) && bSjis.Length == 338)
						{
							sr.Close();
// ADD 2008.04.11 ACT Vista�Ή� START
							if(sw != null) sw.Close();
// ADD 2008.04.11 ACT Vista�Ή� END
// MOD 2008.04.23 ���s�j���� �Œ蒷�t�@�C���̃G���[�t�@�C���o�͑Ή� START
//							�c�`�s�t�@�C���捞();
							�c�`�s�t�@�C���捞(errfileName);
// MOD 2008.04.23 ���s�j���� �Œ蒷�t�@�C���̃G���[�t�@�C���o�͑Ή� END
							return;
						}
						iErrorFlg = true;
						if (sValue.Length < 10 || sValue.Length > 14)
						{
							sbErr.Append(iLineCnt + "�s��:���ڐ��܂��́A�f�[�^�����Ⴂ�܂�\r\n");
							iLenErrMsg = sbErr.ToString().Trim().Length;
							iLenErrMsgOld = iLenErrMsg;
							sw = �G���[�t�@�C���o��(sw, errfileName, sData);
							if(sw == null) return;
							sData = sr.ReadLine();
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
//							iCnt++;
							if(sData != null)iCnt++;
							if(sData != null)iLineCnt++;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
// ADD 2008.05.15 ACT Vista�Ή��i�G���[�����\���j START
							i�G���[����++;
// ADD 2008.05.15 ACT Vista�Ή��i�G���[�����\���j END
							iErrorFlg = false;
							continue;
						}
						sKey[0] = gs����b�c;
						sKey[1] = gs����b�c;
						sKey[20] = gs���p�҂b�c;
						//�׎�l�R�[�h
						sValue[0] = sValue[0].Trim();
						if (!�K�{�`�F�b�N(sValue[0])) 
						{
							sbErr.Append(iLineCnt + "�s��:�׎�l�R�[�h�͕K�{���ڂł�\r\n");
							iErrorFlg = false;
						}
						if (!���p�`�F�b�N(sValue[0])) 
						{
							sbErr.Append(iLineCnt + "�s��:�׎�l�R�[�h�͔��p�����œ��͂��Ă�������\r\n");
							iErrorFlg = false;
						}
// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
						if(!�L���`�F�b�N(sValue[0])){
							sbErr.Append(iLineCnt + "�s��:�׎�l�R�[�h�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
							iErrorFlg = false;
						}
// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END
						sKey[2] = sValue[0];
						if (sKey[2].Length > 15)
						{
							sbErr.Append(iLineCnt + "�s��:�׎�l�R�[�h�͂P�T�����ȓ��œ��͂��Ă�������\r\n");
							iErrorFlg = false;
						}
						//�d�b�ԍ�
						sKey[3] = " ";
						sKey[4] = " ";
						sKey[5] = " ";
						sValue[1] = sValue[1].Trim();
						if (!�K�{�`�F�b�N(sValue[1]))
						{
							sbErr.Append(iLineCnt + "�s��:�d�b�ԍ��͕K�{���ڂł�\r\n");
							iErrorFlg = false;
						}
						if (!���p�`�F�b�N(sValue[1])) 
						{
							sbErr.Append(iLineCnt + "�s��:�d�b�ԍ��͔��p�����œ��͂��Ă�������\r\n");
							iErrorFlg = false;
						}
						try
						{
							sValue[1] = sValue[1].Replace(" ", "");
							if (sValue[1].Length > 0)
							{
								//�J�b�R[()]���Ȃ���
								if (sValue[1].IndexOf("(") == -1 && sValue[1].LastIndexOf(")") == -1)
								{
									// �n�C�t��[-]���P�̎�
									if (sValue[1].IndexOf("-") == sValue[1].LastIndexOf("-") && sValue[1].IndexOf("-") != -1)
									{
										sKey[3] = " ";
										sKey[4] = sValue[1].Substring(0, sValue[1].IndexOf("-"));
										sKey[5] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
										if (!���l�`�F�b�N(sKey[4]) || !���l�`�F�b�N(sKey[5]))
										{
											sbErr.Append(iLineCnt + "�s��:�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
											iErrorFlg = false;
										}
									}
									// �n�C�t��[-]���Q�ȏ�̎�
									else if (sValue[1].IndexOf("-") != sValue[1].LastIndexOf("-") && sValue[1].IndexOf("-") != -1)
									{
										sKey[3] = sValue[1].Substring(0, sValue[1].IndexOf("-"));
										sKey[4] = sValue[1].Substring(sValue[1].IndexOf("-") + 1, sValue[1].LastIndexOf("-") - sValue[1].IndexOf("-") - 1);
										sKey[5] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
										if (!���l�`�F�b�N(sKey[3]) || !���l�`�F�b�N(sKey[4]) || !���l�`�F�b�N(sKey[5]))
										{
											sbErr.Append(iLineCnt + "�s��:�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
											iErrorFlg = false;
										}
									}
// MOD 2010.03.30 ���s�j���� �d�b�ԍ��`���ǉ��Ή� START
									// �n�C�t����������
									// �d�b�ԍ����X���̎�
									else if(sValue[1].Length == 9){
										if (sValue[1].Substring(0,1).Equals("3") || sValue[1].Substring(0,1).Equals("6")){
											//�����A���� 1-4-4�ŕҏW
											sKey[3] = sValue[1].Substring(0,1);
											sKey[4] = sValue[1].Substring(1,4);
											sKey[5] = sValue[1].Substring(5,4);
										}else{
											//����ȊO��3-2-4�ŕҏW
											sKey[3] = sValue[1].Substring(0,3);
											sKey[4] = sValue[1].Substring(3,2);
											sKey[5] = sValue[1].Substring(5,4);
										}
										if(!���l�`�F�b�N(sKey[3]) || !���l�`�F�b�N(sKey[4]) || !���l�`�F�b�N(sKey[5])){
											sbErr.Append(iLineCnt + "�s��:�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
											iErrorFlg = false;
										}
									// �d�b�ԍ����P�O���̎�
									}else if(sValue[1].Length == 10){
										if(sValue[1].Substring(0,2).Equals("03") || sValue[1].Substring(0,2).Equals("06")){
											//�����A���� 2-4-4�ŕҏW
											sKey[3] = sValue[1].Substring(0,2);
											sKey[4] = sValue[1].Substring(2,4);
											sKey[5] = sValue[1].Substring(6,4);
										}else{
											//����ȊO��4-2-4�ŕҏW
											sKey[3] = sValue[1].Substring(0,4);
											sKey[4] = sValue[1].Substring(4,2);
											sKey[5] = sValue[1].Substring(6,4);
										}
										if(!���l�`�F�b�N(sKey[3]) || !���l�`�F�b�N(sKey[4]) || !���l�`�F�b�N(sKey[5])){
											sbErr.Append(iLineCnt + "�s��:�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
											iErrorFlg = false;
										}
									// �d�b�ԍ����P�P���̎�
									}else if(sValue[1].Length == 11){
// MOD 2010.03.30 ���s�j���� �g�ѓd�b�Ή� START
										if(sValue[1].Substring(0,3).Equals("090")
										 || sValue[1].Substring(0,3).Equals("080")
										 || sValue[1].Substring(0,3).Equals("070")
										 || sValue[1].Substring(0,3).Equals("050")){
											//�g�ѓd�b�� 3-4-4�ŕҏW
											sKey[3] = sValue[1].Substring(0,3);
											sKey[4] = sValue[1].Substring(3,4);
											sKey[5] = sValue[1].Substring(7,4);
										}else{
// MOD 2010.03.30 ���s�j���� �g�ѓd�b�Ή� END
											//4-3-4�ŕҏW
											sKey[3] = sValue[1].Substring(0,4);
											sKey[4] = sValue[1].Substring(4,3);
											sKey[5] = sValue[1].Substring(7,4);
											if(!���l�`�F�b�N(sKey[3]) || !���l�`�F�b�N(sKey[4]) || !���l�`�F�b�N(sKey[5])){
												sbErr.Append(iLineCnt + "�s��:�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
												iErrorFlg = false;
											}
// MOD 2010.03.30 ���s�j���� �g�ѓd�b�Ή� START
										}
// MOD 2010.03.30 ���s�j���� �g�ѓd�b�Ή� END
									// �d�b�ԍ����P�Q���̎�
									}else if(sValue[1].Length == 12){
										//4-4-4�ŕҏW
										sKey[3] = sValue[1].Substring(0,4);
										sKey[4] = sValue[1].Substring(4,4);
										sKey[5] = sValue[1].Substring(8,4);
										if(!���l�`�F�b�N(sKey[3]) || !���l�`�F�b�N(sKey[4]) || !���l�`�F�b�N(sKey[5])){
											sbErr.Append(iLineCnt + "�s��:�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
											iErrorFlg = false;
										}
									}
// MOD 2010.03.30 ���s�j���� �d�b�ԍ��`���ǉ��Ή� END
									else
									{
										sbErr.Append(iLineCnt + "�s��:�d�b�ԍ��̌`���Ɍ�肪����܂�\r\n");
										iErrorFlg = false;
									}
								}
								//�J�b�R[()]�����鎞
								else if (sValue[1].IndexOf("(") != -1 && sValue[1].LastIndexOf(")") != -1)
								{
									sKey[3] = sValue[1].Substring(sValue[1].IndexOf("(") + 1, sValue[1].LastIndexOf(")") - sValue[1].IndexOf("(") - 1);
									sKey[4] = sValue[1].Substring(sValue[1].IndexOf(")") + 1, sValue[1].LastIndexOf("-") - sValue[1].IndexOf(")") - 1);
									sKey[5] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
									if (!���l�`�F�b�N(sKey[3]) || !���l�`�F�b�N(sKey[4]) || !���l�`�F�b�N(sKey[5]))
									{
										sbErr.Append(iLineCnt + "�s��:�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
										iErrorFlg = false;
									}							
								}
								else
								{
									sbErr.Append(iLineCnt + "�s��:�d�b�ԍ��̌`���Ɍ�肪����܂�\r\n");
									iErrorFlg = false;
								}
								if (sKey[3].Length > 6)	
								{
									sbErr.Append(iLineCnt + "�s��:�d�b�ԍ�(�s�O)�͂U�����ȓ��œ��͂��Ă�������\r\n");
									iErrorFlg = false;
								}
								if (sKey[4].Length > 4)	
								{
									sbErr.Append(iLineCnt + "�s��:�d�b�ԍ�(�s��)�͂S�����ȓ��œ��͂��Ă�������\r\n");
									iErrorFlg = false;
								}
								if (sKey[5].Length > 4)							
								{
									sbErr.Append(iLineCnt + "�s��:�d�b�ԍ�(�ԍ�)�͂S�����ȓ��œ��͂��Ă�������\r\n");
									iErrorFlg = false;
								}
							}
						}
						catch
						{
							sbErr.Append(iLineCnt + "�s��:�d�b�ԍ��̌`���Ɍ�肪����܂�\r\n");
							iErrorFlg = false;
						}
						//�e�`�w�ԍ�
						sKey[6] = " ";
						sKey[7] = " ";
						sKey[8] = " ";
						sValue[2] = sValue[2].Trim();
						try
						{
							sValue[2] = sValue[2].Replace(" ", "");
							if (sValue[2].Trim().Length != 0)
							{
								if (!���p�`�F�b�N(sValue[2])) 
								{
									sbErr.Append(iLineCnt + "�s��:�e�`�w�ԍ��͔��p�����œ��͂��Ă�������\r\n");
									iErrorFlg = false;
								}
								if (sValue[2].IndexOf("(") == -1 && sValue[2].LastIndexOf(")") == -1)
								{
									if (sValue[2].IndexOf("-") == sValue[2].LastIndexOf("-") && sValue[2].IndexOf("-") != -1)
									{
										sKey[6] = " ";
										sKey[7] = sValue[2].Substring(0, sValue[2].IndexOf("-"));
										sKey[8] = sValue[2].Substring(sValue[2].LastIndexOf("-") + 1);
										if (!���l�`�F�b�N(sKey[7]) || !���l�`�F�b�N(sKey[8]))
										{
											sbErr.Append(iLineCnt + "�s��:�e�`�w�ԍ��͐��l�œ��͂��Ă�������\r\n");
											iErrorFlg = false;
										}
									}
									else if (sValue[2].IndexOf("-") != sValue[2].LastIndexOf("-") && sValue[2].IndexOf("-") != -1)
									{
										sKey[6] = sValue[2].Substring(0, sValue[2].IndexOf("-"));
										sKey[7] = sValue[2].Substring(sValue[2].IndexOf("-") + 1, sValue[2].LastIndexOf("-") - sValue[2].IndexOf("-") - 1);
										sKey[8] = sValue[2].Substring(sValue[2].LastIndexOf("-") + 1);
										if (!���l�`�F�b�N(sKey[6]) || !���l�`�F�b�N(sKey[7]) || !���l�`�F�b�N(sKey[8]))	
										{
											sbErr.Append(iLineCnt + "�s��:�e�`�w�ԍ��͐��l�œ��͂��Ă�������\r\n");
											iErrorFlg = false;
										}
									}
									else
									{
										sbErr.Append(iLineCnt + "�s��:�e�`�w�ԍ��̌`���Ɍ�肪����܂�\r\n");
										iErrorFlg = false;
									}
								}
								else if (sValue[2].IndexOf("(") != -1 && sValue[2].LastIndexOf(")") != -1)
								{
									sKey[6] = sValue[2].Substring(sValue[2].IndexOf("(") + 1, sValue[2].LastIndexOf(")") - sValue[2].IndexOf("(") - 1);
									sKey[7] = sValue[2].Substring(sValue[2].IndexOf(")") + 1, sValue[2].LastIndexOf("-") - sValue[2].IndexOf(")") - 1);
									sKey[8] = sValue[2].Substring(sValue[2].LastIndexOf("-") + 1);
									if (!���l�`�F�b�N(sKey[6]) || !���l�`�F�b�N(sKey[7]) || !���l�`�F�b�N(sKey[8]))	
									{
										sbErr.Append(iLineCnt + "�s��:�e�`�w�ԍ��͐��l�œ��͂��Ă�������\r\n");
										iErrorFlg = false;
									}
								}
								else
								{
									sbErr.Append(iLineCnt + "�s��:�e�`�w�ԍ��̌`���Ɍ�肪����܂�\r\n");
									iErrorFlg = false;
								}
							}
							if (sKey[6].Length > 6)
							{
								sbErr.Append(iLineCnt + "�s��:�e�`�w�ԍ�(�s�O)�͂U�����ȓ��œ��͂��Ă�������\r\n");
								iErrorFlg = false;
							}
							if (sKey[7].Length > 4)
							{
								sbErr.Append(iLineCnt + "�s��:�e�`�w�ԍ�(�s��)�͂S�����ȓ��œ��͂��Ă�������\r\n");
								iErrorFlg = false;
							}
							if (sKey[8].Length > 4)
							{
								sbErr.Append(iLineCnt + "�s��:�e�`�w�ԍ�(�ԍ�)�͂S�����ȓ��œ��͂��Ă�������\r\n");
								iErrorFlg = false;
							}
						}
						catch
						{
							sbErr.Append(iLineCnt + "�s��:�e�`�w�ԍ��̌`���Ɍ�肪����܂�\r\n");
							iErrorFlg = false;
						}
						//�Z���P
						if (!�K�{�`�F�b�N(sValue[3]))
						{ 
							sbErr.Append(iLineCnt + "�s��:�Z���P�͕K�{���ڂł�\r\n");
							iErrorFlg = false;
						}
						sKey[9] = Microsoft.VisualBasic.Strings.StrConv(sValue[3], Microsoft.VisualBasic.VbStrConv.Wide, 0);
						if (sKey[9].Length > 20) sKey[9] = sKey[9].Substring(0, 20);
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
						if(gs�I�v�V����[18].Equals("1")){
							sKey[9] = sKey[9].TrimEnd();
						}else{
							sKey[9] = sKey[9].Trim();
						}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
						//�Z���Q
						if (sValue[4].Trim().Length != 0)
						{
							sKey[10] = Microsoft.VisualBasic.Strings.StrConv(sValue[4], Microsoft.VisualBasic.VbStrConv.Wide, 0);
							if (sKey[10].Length > 20) sKey[10] = sKey[10].Substring(0, 20);
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
							if(gs�I�v�V����[18].Equals("1")){
								sKey[10] = sKey[10].TrimEnd();
							}else{
								sKey[10] = sKey[10].Trim();
							}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
						}
						if (sKey[10] == null || sKey[10].Length == 0) sKey[10] = " ";
						//�Z���R
						if (sValue[5].Trim().Length != 0)
						{
							sKey[11] = Microsoft.VisualBasic.Strings.StrConv(sValue[5], Microsoft.VisualBasic.VbStrConv.Wide, 0);
							if (sKey[11].Length > 20) sKey[11] = sKey[11].Substring(0, 20);
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
							if(gs�I�v�V����[18].Equals("1")){
								sKey[11] = sKey[11].TrimEnd();
							}else{
								sKey[11] = sKey[11].Trim();
							}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
						}
						if (sKey[11] == null || sKey[11].Length == 0) sKey[11] = " ";
						//���O�P
						if (!�K�{�`�F�b�N(sValue[6])) 
						{
							sbErr.Append(iLineCnt + "�s��:���O�P�͕K�{���ڂł�\r\n");
							iErrorFlg = false;
						}
						sKey[12] = Microsoft.VisualBasic.Strings.StrConv(sValue[6], Microsoft.VisualBasic.VbStrConv.Wide, 0);
						if (sKey[12].Length > 20) sKey[12] = sKey[12].Substring(0, 20);
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
						if(gs�I�v�V����[18].Equals("1")){
							sKey[12] = sKey[12].TrimEnd();
						}else{
							sKey[12] = sKey[12].Trim();
						}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
						sKey[13] = " ";
						//���O�Q
						if (sValue[7].Trim().Length != 0)
						{
							sKey[13] = Microsoft.VisualBasic.Strings.StrConv(sValue[7], Microsoft.VisualBasic.VbStrConv.Wide, 0);
							if (sKey[13].Length > 20) sKey[13] = sKey[13].Substring(0, 20);
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
							if(gs�I�v�V����[18].Equals("1")){
								sKey[13] = sKey[13].TrimEnd();
							}else{
								sKey[13] = sKey[13].Trim();
							}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
						}
						if (sKey[13] == null || sKey[13].Length == 0) sKey[13] = " ";
						sKey[14] = " ";
						//���O�R ���g�p
						if (sValue[8].Trim().Length != 0)
						{
							sKey[14] = Microsoft.VisualBasic.Strings.StrConv(sValue[8], Microsoft.VisualBasic.VbStrConv.Wide, 0);
							if (sKey[14].Length > 20) sKey[14] = sKey[14].Substring(0, 20);
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
							if(gs�I�v�V����[18].Equals("1")){
								sKey[14] = sKey[14].TrimEnd();
							}else{
								sKey[14] = sKey[14].Trim();
							}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
						}
						if (sKey[14] == null || sKey[14].Length == 0) sKey[14] = " ";
						sKey[15] = " ";
						//�X�֔ԍ�
						sValue[9] = sValue[9].Trim();
						sKey[15] = sValue[9].Replace("-", "");
// DEL 2006.12.01 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̍폜 START
//// ADD 2006.07.14 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̒ǉ� START
//						sKey[21] = " ";
//						//�X�֔ԍ��������͂̏ꍇ
//						if(sKey[15].Length == 0){
//							string[] sRet = new string[6];
//							sRet = �X�֔ԍ��擾(sKey[9].Trim() + sKey[10].Trim() + sKey[11].Trim());
//							if(sRet[0].Length == 4)
//							{
//								//�X�֔ԍ������݂��A�X���b�c�������Ă��Ă��鎞
//								//if(sRet[1].Length == 7 && sRet[3].Trim().Length > 0)
//								if(sRet[1].Length == 7)
//								{
//									sKey[15] = sRet[1];	//�X�֔ԍ�
//									sKey[21] = sRet[2];	//�Z���b�c�W��
//									sKey[19] = sRet[3]; //�X���b�c
//									//sRet[4]; //�s���{���b�c
//									//sRet[5]; //�s�撬���b�c
//								}
//							}
////							else if(sRet[0].Length > 4)
////							{ 
////								sbErr.Append(iLineCnt + "�s��:" + sRet[0] +"\r\n");
////								iErrorFlg = false;
////							}
//						}
//// ADD 2006.07.14 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̒ǉ� END
// DEL 2006.12.01 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̍폜 END
						if (!�K�{�`�F�b�N(sKey[15]))
						{
							sbErr.Append(iLineCnt + "�s��:�X�֔ԍ��͕K�{���ڂł�\r\n");
							iErrorFlg = false;
						}
						if (sKey[15].Length > 0)
						{
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
//							if (!���l�`�F�b�N(sKey[15]))
//							{
//								sbErr.Append(iLineCnt + "�s��:�X�֔ԍ��͐��l�œ��͂��Ă�������\r\n");
//								iErrorFlg = false;
//							}
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
							if (sKey[15].Length > 7) 
							{
								sbErr.Append(iLineCnt + "�s��:�X�֔ԍ��͂V�����ȓ��œ��͂��Ă�������\r\n");
								iErrorFlg = false;
							}
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
//							if (���l�`�F�b�N(sKey[15]) && sKey[15].Length <= 7)
//							{
//								//�X�֔ԍ����݃`�F�b�N
//								string[] sRet = {""};
//								try
//								{
//									if(sv_address == null) sv_address = new is2address.Service1();
//									sRet = sv_address.Get_byPostcode2(gsa���[�U,sKey[15]);
//								}
//								catch (System.Net.WebException)
//								{
//									sbErr.Append(iLineCnt + "�s��:"+ gs�ʐM�G���[ +"\r\n");
//									iErrorFlg = false;
//								}
//								catch (Exception ex)
//								{
//									sbErr.Append(iLineCnt + "�s��:�ʐM�G���[�F" + ex.Message +"\r\n");
//									iErrorFlg = false;
//								}
//
//								if(sRet[0].Length != 4)
//								{
//									sbErr.Append(iLineCnt + "�s��:�X�֔ԍ������݂��܂���\r\n");
//									iErrorFlg = false;
//								}
//							}
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
						}
						if (sKey[15].Length == 0) sKey[15] = " ";
						sKey[16] = " ";
						if (sValue.Length > 10)
						{
							//�J�i����
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//							sValue[10] = sValue[10].Trim();
//							if (sValue[10].Trim().Length != 0)
							if(gs�I�v�V����[18].Equals("1")){
								sValue[10] = sValue[10].TrimEnd();
							}else{
								sValue[10] = sValue[10].Trim();
							}
							if (sValue[10].Length != 0)
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
							{
								if (!���p�`�F�b�N(sValue[10])) 
								{
									sbErr.Append(iLineCnt + "�s��:�J�i���͔̂��p�����œ��͂��Ă�������\r\n");
									iErrorFlg = false;
								}
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
//								if(!�L���`�F�b�N(sValue[10])){
//									sbErr.Append(iLineCnt + "�s��:�J�i���̂Ɏg�p�ł��Ȃ��L��������܂�\r\n");
//									iErrorFlg = false;
//								}
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END
							}
							sKey[16] = sValue[10];
							if (sKey[16].Length > 10) 
							{
								sbErr.Append(iLineCnt + "�s��:�J�i���̂͂P�O�����ȓ��œ��͂��Ă�������\r\n");
								iErrorFlg = false;
							}
							if (sKey[16].Length == 0) sKey[16] = " ";
						}
						sKey[17] = " ";
						if (sValue.Length > 11)
						{
							//��ďo�׋敪 ���g�p
							sValue[11] = sValue[11].Trim();
							if (!���p�`�F�b�N(sValue[11])) 
							{
								sbErr.Append(iLineCnt + "�s��:��ďo�׋敪�͔��p�����œ��͂��Ă�������\r\n");
								iErrorFlg = false;
							}
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
//							if(!�L���`�F�b�N(sValue[11])){
//								sbErr.Append(iLineCnt + "�s��:��ďo�׋敪�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
//								iErrorFlg = false;
//							}
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END
							sKey[17] = sValue[11];
							if (sKey[17].Length > 2) 
							{
								sbErr.Append(iLineCnt + "�s��:��ďo�׋敪�͂Q�����ȓ��œ��͂��Ă�������\r\n");
								iErrorFlg = false;
							}
							if (sKey[17].Length == 0) sKey[17] = " ";
						}
						sKey[18] = " ";
						if (sValue.Length > 12)
						{
							//����v ���g�p
							sValue[12] = sValue[12].Trim();
							if (!���p�`�F�b�N(sValue[12])) 
							{
								sbErr.Append(iLineCnt + "�s��:����v�͔��p�����œ��͂��Ă�������\r\n");
								iErrorFlg = false;
							}
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
//							if(!�L���`�F�b�N(sValue[12])){
//								sbErr.Append(iLineCnt + "�s��:����v�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
//								iErrorFlg = false;
//							}
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END
							sKey[18] = sValue[12];
							if (sKey[18].Length > 5) 
							{
								sbErr.Append(iLineCnt + "�s��:����v�͂T�����ȓ��œ��͂��Ă�������\r\n");
								iErrorFlg = false;
							}
							if (sKey[18].Length == 0) sKey[18] = " ";
						}
						sKey[19] = " ";
						if (sValue.Length > 13)
						{
							//���X�R�[�h
							sKey[19] = sValue[13];
							if (sKey[19].Length == 0) sKey[19] = " ";
						}

						//
						//�`�F�b�N���I���������ɃG���[���b�Z�[�W���������Ă����
						//���̍s�́A�ēx�ҏW�ΏۂɂȂ�̂ŃG���[�t�@�C���ɏo�͂���
						//�iiErrorFlg�́H�A�����炭�R�{�a�ɂ��ǉ����ꂽ�t���O��
						//�@��ʂɒǉ�����ׁA�R�����g���ȗ������͂�...�j
						//
						iLenErrMsg = sbErr.ToString().Trim().Length;
						if(iLenErrMsg != iLenErrMsgOld)
						{
							iLenErrMsgOld = iLenErrMsg;
							sw = �G���[�t�@�C���o��(sw, errfileName, sData);
							if(sw == null) return;
						}
						else
						{
							StringBuilder sbKeyData = new StringBuilder();
							for (int j = 0; j < sKey.Length; j++)
							{
								sbKeyData.Append(sKey[j] + ",");
							}
							alKey.Add(sbKeyData.ToString().Substring(0, sbKeyData.ToString().Length - 1));
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
							saData[i�T�[�o���M�s] = sData;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
//							iaData[i�T�[�o���M�s] = iCnt;
							iaData[i�T�[�o���M�s] = iLineCnt;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
							i�T�[�o���M�s++;
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
						}

						if(iErrorFlg == false)
						{
							i�G���[����++;
							lbl�G���[����.Text=i�G���[����.ToString()+"��";
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
							lbl�G���[����.Refresh();
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
							iErrorFlg = true;
						}
						else
						{
							iSetCnt++;
// ADD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� START
							// �P�O�O�����Ƃɓo�^
							if(iSetCnt >= 100)
								break;
// ADD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� END
						}
// DEL 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� START
//						if(iSetCnt >= 100)
//							break;
// DEL 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� END
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
						i�V�[�g������ = iCnt;
						lbl�V�[�g������.Text=i�V�[�g������.ToString()+"��";
						lbl�V�[�g������.Refresh();
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
						sData = sr.ReadLine();
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
//						iCnt++;
						if(sData != null)iCnt++;
						if(sData != null)iLineCnt++;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
					}

					if (alKey.Count > 0)
					{
						string[] sList = new string[alKey.Count];
						IEnumerator enumList = alKey.GetEnumerator();
						int i = 0;
						while(enumList.MoveNext())
						{
							sList[i] = enumList.Current.ToString();
							i++;
						}
						string[] sRet = {""};
						try
						{
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
//							sRet = sv_otodoke.Ins_uploadData(gsa���[�U,sList);
// MOD 2015.05.13 BEVAS) �O�c�@���q����l�̗X�֔ԍ����݃`�F�b�N�����q�}�X�^�ōs�� START
							if (gs����b�c.Substring(0,1) != "J")
							{
// MOD 2015.05.13 BEVAS) �O�c�@���q����l�̗X�֔ԍ����݃`�F�b�N�����q�}�X�^�ōs�� END
							sRet = sv_otodoke.Ins_uploadData2(gsa���[�U,sList);
// MOD 2015.05.13 BEVAS) �O�c�@���q����l�̗X�֔ԍ����݃`�F�b�N�����q�}�X�^�ōs�� START
							} 
							else 
							{
								sRet = sv_oji.otodoke_Ins_uploadData2(gsa���[�U,sList);
							}
// MOD 2015.05.13 BEVAS) �O�c�@���q����l�̗X�֔ԍ����݃`�F�b�N�����q�}�X�^�ōs�� END

// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
// MOD 2009.12.01 ���s�j���� �f�[�^�o�^���̃G���[�`�F�b�N��ǉ� START
							//�o�^���ɃG���[�����������ꍇ�I������
							if(sRet[0].Length > 0)
							{
								tex���b�Z�[�W.Text = sRet[0];
								iTxtMsgDsp  = false;
								break;
							}
// MOD 2009.12.01 ���s�j���� �f�[�^�o�^���̃G���[�`�F�b�N��ǉ� END
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
							for(int iLine2 = 1; iLine2 < sRet.Length; iLine2++){
								if(sRet[iLine2].Length > 0){
									i�G���[����++;
									iSetCnt--;
									sbErr.Append(iaData[iLine2] + "�s��:�X�֔ԍ�["+sRet[iLine2]+"]�����݂��܂���\r\n");
									iLenErrMsg = sbErr.ToString().Trim().Length;
									if(iLenErrMsg != iLenErrMsgOld){
										iLenErrMsgOld = iLenErrMsg;
									}
									sw = �G���[�t�@�C���o��(sw, errfileName, saData[iLine2]);
									if(sw == null) return;
								}
							}
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
						}
						catch (System.Net.WebException)
						{
							sRet[0] = gs�ʐM�G���[;
							tex���b�Z�[�W.Text = sRet[0];
							iTxtMsgDsp = false;
							break;
						}
						catch (Exception ex)
						{
							sRet[0] = "�ʐM�G���[�F" + ex.Message;
							tex���b�Z�[�W.Text = sRet[0];
							iTxtMsgDsp = false;
							break;
						}
						i�o�^���� += iSetCnt;
						lbl�捞����.Text=i�o�^����.ToString()+"��";
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
						lbl�捞����.Refresh();

						lbl�G���[����.Text=i�G���[����.ToString()+"��";
						lbl�G���[����.Refresh();
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
// ADD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� START
						alKey = null;
						enumList = null;
// ADD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� END
						iSetCnt = 0;
					}
// ADD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� START
 					if(sData == null){
						break;
					}
// ADD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� END
				}
			}
			catch (Exception ex)
			{
				sbErr.Append(ex.Message);
			}
			finally
			{
				sr.Close();
				if(sw != null) sw.Close();
			}
			tex�f�[�^�G���[.Text = sbErr.ToString();
			Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
//			int Wrkcnt = i�o�^����;
//			lbl�捞����.Text=Wrkcnt.ToString()+"��";
			lbl�捞����.Text=i�o�^����.ToString()+"��";
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
			lbl�G���[����.Text=i�G���[����.ToString()+"��";
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
//// MOD 2007.01.17 FJCS) �K�c�@�׎呍�������V�[�g�������ɕύX START
////			lbl�׎呍����.Text=i�׎呍����.ToString()+"��";
//			i�V�[�g������ = iCnt - 1;
//// ADD 2007.02.21 ���s�j���� �������|�P�ɂȂ� START
			i�V�[�g������ = iCnt;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
			if(i�V�[�g������ < 0) i�V�[�g������ = 0;
// ADD 2007.02.21 ���s�j���� �������|�P�ɂȂ� END
			lbl�V�[�g������.Text=i�V�[�g������.ToString()+"��";
// MOD 2007.01.17 FJCS) �K�c�@�׎呍�������V�[�g�������ɕύX END
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
			lbl�捞����.Refresh();
			lbl�G���[����.Refresh();
			lbl�V�[�g������.Refresh();
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
			if(iTxtMsgDsp == true)
				tex���b�Z�[�W.Text = "";
// MOD 2007.02.21 ���s�j���� �G���[���̊������b�Z�[�W�̕ύX START
//			MessageBox.Show("�捞�������������܂����B","���͂���捞",MessageBoxButtons.OK);
			if(i�G���[���� == 0 && i�V�[�g������ == 0){
				MessageBox.Show("�捞�f�[�^�����݂��܂���ł����B"
								,"���͂���捞",MessageBoxButtons.OK);
			}else{
				if(i�o�^���� == 0){
					MessageBox.Show("�G���[�����������ׁA��荞�߂܂���ł����B"
									,"���͂���捞",MessageBoxButtons.OK);
				}else if(i�G���[���� > 0 || i�V�[�g������ != i�o�^����){
					MessageBox.Show("�G���[�����������ׁA��荞�߂Ȃ������f�[�^������܂��B"
									,"���͂���捞",MessageBoxButtons.OK);
				}else{
					MessageBox.Show("�捞�������������܂����B"
									,"���͂���捞",MessageBoxButtons.OK);
				}
			}
// MOD 2007.02.21 ���s�j���� �G���[���̊������b�Z�[�W�̕ύX END
		}
// MOD 2006.07.10 ���s�j�R�{ �b�r�u�捞�����l�`�w�R�O�O�O�O���i�o�^�͂P�O�O���P�ʁj�ύX END

// ADD 2006.05.17 ���s�j���� �b�r�u�捞�̃G���[�t�@�C���o�� START
		private StreamWriter �G���[�t�@�C���o��(StreamWriter sw, String errfileName, String sData)
		{
			if(sw == null){
				try
				{
					sw = new StreamWriter(errfileName, false, System.Text.Encoding.Default);
				}
				catch (Exception ex)
				{
					tex���b�Z�[�W.Text = "";
					Cursor = System.Windows.Forms.Cursors.Default;
					MessageBox.Show(ex.Message,"���͂���捞",MessageBoxButtons.OK);
					return null;
				}
			}
			sw.WriteLine(sData);
			return sw;
		}
// ADD 2006.05.17 ���s�j���� �b�r�u�捞�̃G���[�t�@�C���o�� END

// MOD 2006.07.10 ���s�j�R�{ �b�r�u�捞�����l�`�w�R�O�O�O�O���i�o�^�͂P�O�O���P�ʁj�ύX START
// 2006.10.26 FJCS)�K�c �l�`�w�P�O�O�O�O���ɕύX //
// MOD 2008.04.23 ���s�j���� �Œ蒷�t�@�C���̃G���[�t�@�C���o�͑Ή� START
//		private void �c�`�s�t�@�C���捞()
//		{
		private void �c�`�s�t�@�C���捞(String errfileName)
		{
			StreamWriter sw    = null;
			int iLenErrMsg     = 0;
			int iLenErrMsgOld  = 0;
// MOD 2008.04.23 ���s�j���� �Œ蒷�t�@�C���̃G���[�t�@�C���o�͑Ή� END
			StringBuilder sbErr = new StringBuilder();
// MOD 2010.04.26 ���s�j���� �P�O�O�O�O���`�F�b�N�@�\�̕ύX START
//// MOD 2010.03.12 ���s�j���� �P�O�O�O�O���`�F�b�N�����@�\�̒ǉ� START
//			bool bAltKey   = (GetAsyncKeyState(Keys.Menu    ) == 0) ? false : true;
//			bool bShiftKey = (GetAsyncKeyState(Keys.ShiftKey) == 0) ? false : true;
//// MOD 2010.03.12 ���s�j���� �P�O�O�O�O���`�F�b�N�����@�\�̒ǉ� END
// MOD 2010.04.26 ���s�j���� �P�O�O�O�O���`�F�b�N�@�\�̕ύX END

			Cursor = System.Windows.Forms.Cursors.AppStarting;
			StreamReader sr = new StreamReader(fileName, System.Text.Encoding.GetEncoding("shift-jis"));
			i�G���[����		= 0;
			bool iErrorFlg   = true;
			bool iTxtMsgDsp  = true;

// MOD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� START
//			int iCnt = 1;
			int iCnt = 0;
// MOD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� END
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
			int iLineCnt = 0;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
			int iSetCnt = 0; 
			try
			{
				if (sv_otodoke == null)
				{
					sv_otodoke = new is2otodoke.Service1();
				}
				while(true)
				{
// MOD 2010.04.26 ���s�j���� �P�O�O�O�O���`�F�b�N�@�\�̕ύX START
//// MOD 2010.03.12 ���s�j���� �P�O�O�O�O���`�F�b�N�����@�\�̒ǉ� START
//				if(bAltKey && bShiftKey){
//					;
//				}else{
//// MOD 2010.03.12 ���s�j���� �P�O�O�O�O���`�F�b�N�����@�\�̒ǉ� END
//					String[] sList1 = {""};
//					sList1 = sv_otodoke.Get_ninushiCount(gsa���[�U,gs����b�c,gs����b�c);
//					int DataCnt = int.Parse(sList1[1]);
//// DEL 2007.01.17 FJCS) �K�c�@�׎呍�������V�[�g�������ɕύX START
////					i�׎呍���� = DataCnt;
//// DEL 2007.01.17 FJCS) �K�c�@�׎呍�������V�[�g�������ɕύX END
//// MOD 2006.10.26 FJCS)�K�c �l�`�w�P�O�O�O�O���ɕύX SATRT
////					if( DataCnt >= 30000)
////					{
////						tex���b�Z�[�W.Text = "�o�^�������R�O�O�O�O���𒴉߂��܂��B";
//					if( DataCnt >= 10000)
//					{
//// MOD 2007.02.21 ���s�j���� �������|�P�ɂȂ� START
////						tex���b�Z�[�W.Text = "�o�^�������P�O�O�O�O���𒴉߂��܂��B";
//						tex���b�Z�[�W.Text = "�o�^�������P�O�O�O�O���𒴂��Ă��܂��B";
//						i�G���[����++;
//						sbErr.Append("�o�^�������P�O�O�O�O���𒴂��Ă��܂�\r\n");
//						iErrorFlg = false;
//// MOD 2007.02.21 ���s�j���� �������|�P�ɂȂ� END
//// MOD 2006.10.26 FJCS)�K�c �l�`�w�P�O�O�O�O���ɕύX END
//						iTxtMsgDsp  = false;
//						break;
//					}
//// MOD 2010.03.12 ���s�j���� �P�O�O�O�O���`�F�b�N�����@�\�̒ǉ� START
//				}
//// MOD 2010.03.12 ���s�j���� �P�O�O�O�O���`�F�b�N�����@�\�̒ǉ� END
// MOD 2010.04.26 ���s�j���� �P�O�O�O�O���`�F�b�N�@�\�̕ύX END

					string sData = sr.ReadLine();
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
//// ADD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� START
//					iCnt++;
//// ADD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� END
					if(sData != null)iCnt++;
					if(sData != null)iLineCnt++;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
					if(sData == null)
						break;
// MOD 2009.04.06 ���s�j���� �擪�s�����@�\�̒ǉ� START
// MOD 2010.04.26 ���s�j���� �P�O�O�O�O���`�F�b�N�@�\�̕ύX START
//					if( cBox�擪�s����.Checked ){
					if( iCnt == 1 && cBox�擪�s����.Checked ){
// MOD 2010.04.26 ���s�j���� �P�O�O�O�O���`�F�b�N�@�\�̕ύX END
						sData = sr.ReadLine();
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
						if(sData != null)iLineCnt++;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
						if(sData == null){
							break;
						}
					}
// MOD 2009.04.06 ���s�j���� �擪�s�����@�\�̒ǉ� END
					ArrayList alKey = new ArrayList();
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
					string[] saData = new string[101];
					int[]    iaData = new int[101];
					int i�T�[�o���M�s = 1;
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END

					System.Text.Encoding enc = Encoding.GetEncoding("shift-jis");
					string[] sValue = new string[22];
					byte[] bSjis;

					while(sData != null)
					{
						bSjis = enc.GetBytes(sData);
						if(bSjis.Length  == 0)
						{
							sData = sr.ReadLine();
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
							if(sData != null)iLineCnt++;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
							continue;
						}

// ADD 2008.04.11 ACT Vista�Ή� START
						string sErr = "";
						string sHData = sData;
						iErrorFlg = true;
						if (!�����ϊ�_CSV(ref sHData, ref sErr))
						{
							sbErr.Append(iLineCnt + "�s��:Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							iLenErrMsg = sbErr.ToString().Trim().Length;
							iLenErrMsgOld = iLenErrMsg;
							sw = �G���[�t�@�C���o��(sw, errfileName, sData);
							if(sw == null) return;
							sData = sr.ReadLine();
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
//							iCnt++;
							if(sData != null)iCnt++;
							if(sData != null)iLineCnt++;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
							i�G���[����++;
							continue;
						}
						bSjis = Encoding.GetEncoding("shift-jis").GetBytes(sHData);
// ADD 2008.04.11 ACT Vista�Ή� END

						iErrorFlg = true;
						if(bSjis.Length < 338)
						{
							sbErr.Append(iLineCnt + "�s��:�f�[�^�����Ⴂ�܂�\r\n");
							sData = sr.ReadLine();
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
//							iCnt++;
							if(sData != null)iCnt++;
							if(sData != null)iLineCnt++;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
							i�G���[����++;
							continue;
						}

						sValue[0]  = new string(enc.GetChars(bSjis,  0,15)).Trim();	//�׎�l�R�[�h
						sValue[1]  = new string(enc.GetChars(bSjis, 15, 6)).Trim();	//�d�b�ԍ��P
						sValue[2]  = new string(enc.GetChars(bSjis, 21, 4)).Trim();	//�d�b�ԍ��Q
						sValue[3]  = new string(enc.GetChars(bSjis, 25, 4)).Trim();	//�d�b�ԍ��R
						sValue[4]  = new string(enc.GetChars(bSjis, 29, 6)).Trim();	//�e�`�w�ԍ��P
						sValue[5]  = new string(enc.GetChars(bSjis, 35, 4)).Trim();	//�e�`�w�ԍ��Q
						sValue[6]  = new string(enc.GetChars(bSjis, 39, 4)).Trim();	//�e�`�w�ԍ��R
						sValue[7]  = new string(enc.GetChars(bSjis, 43,40)).Trim();	//�Z���P
						sValue[8]  = new string(enc.GetChars(bSjis, 83,40)).Trim();	//�Z���Q
						sValue[9]  = new string(enc.GetChars(bSjis,123,40)).Trim();	//�Z���R
						sValue[10] = new string(enc.GetChars(bSjis,163,40)).Trim();	//���O�P
						sValue[11] = new string(enc.GetChars(bSjis,203,40)).Trim();	//���O�Q
						sValue[12] = new string(enc.GetChars(bSjis,243,40)).Trim();	//���g�p�iSS:���O�R�j
						sValue[13] = new string(enc.GetChars(bSjis,283, 3)).Trim();	//�X�֔ԍ��P
						sValue[14] = new string(enc.GetChars(bSjis,286, 4)).Trim();	//�X�֔ԍ��Q
						sValue[15] = new string(enc.GetChars(bSjis,290, 3)).Trim();	//���X�R�[�h
						sValue[16] = new string(enc.GetChars(bSjis,293,10)).Trim();	//�J�i����
						sValue[17] = new string(enc.GetChars(bSjis,303,16)).Trim();	//���g�p�iSS:�Z���b�c�j
						sValue[18] = new string(enc.GetChars(bSjis,319, 2)).Trim();	//��ďo�׋敪
						sValue[19] = new string(enc.GetChars(bSjis,321, 5)).Trim();	//����v
						sValue[20] = new string(enc.GetChars(bSjis,326, 6)).Trim();	//���g�p�iSS:�o�^���t�j
						sValue[21] = new string(enc.GetChars(bSjis,332, 6)).Trim();	//���g�p�iSS:�X�V���t�j
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
						if(gs�I�v�V����[18].Equals("1")){
							sValue[7]  = new string(enc.GetChars(bSjis, 43,40)).TrimEnd(); // �Z���P
							sValue[8]  = new string(enc.GetChars(bSjis, 83,40)).TrimEnd(); // �Z���Q
							sValue[9]  = new string(enc.GetChars(bSjis,123,40)).TrimEnd(); // �Z���R
							sValue[10] = new string(enc.GetChars(bSjis,163,40)).TrimEnd(); // ���O�P
							sValue[11] = new string(enc.GetChars(bSjis,203,40)).TrimEnd(); // ���O�Q
							sValue[12] = new string(enc.GetChars(bSjis,243,40)).TrimEnd(); // ���g�p�iSS:���O�R�j
							sValue[16] = new string(enc.GetChars(bSjis,293,10)).TrimEnd(); // �J�i����
						}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END

// MOD 2008.06.16 kcl)�X�{ ���X�R�[�h�������@�̕ύX START
//// MOD 2006.12.01 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̍폜 START
////// MOD 2006.07.14 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̒ǉ� START
//////						string[] sKey   = new string[21];
////						string[] sKey   = new string[22];
////// MOD 2006.07.14 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̒ǉ� END
//						string[] sKey   = new string[21];
//// MOD 2006.12.01 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̍폜 END
						string[] sKey   = new string[22];
// MOD 2008.06.16 kcl)�X�{ ���X�R�[�h�������@�̕ύX END

						if (sValue.Length != 22)
						{
							sbErr.Append(iLineCnt + "�s��:���ڐ����Ⴂ�܂�\r\n");
							sData = sr.ReadLine();
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
//							iCnt++;
							if(sData != null)iCnt++;
							if(sData != null)iLineCnt++;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
							i�G���[����++;
							continue;
						}

						sKey[0] = gs����b�c;
						sKey[1] = gs����b�c;
						sKey[20] = gs���p�҂b�c;
						//�׎�l�R�[�h
						sValue[0] = sValue[0];
						if (!�K�{�`�F�b�N(sValue[0]))
						{
							sbErr.Append(iLineCnt + "�s��:�׎�l�R�[�h�͕K�{���ڂł�\r\n");
							iErrorFlg = false;
						}
						if (!���p�`�F�b�N(sValue[0]))
						{
							sbErr.Append(iLineCnt + "�s��:�׎�l�R�[�h�͔��p�����œ��͂��Ă�������\r\n");
							iErrorFlg = false;
						}
// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
						if(!�L���`�F�b�N(sValue[0])){
							sbErr.Append(iLineCnt + "�s��:�׎�l�R�[�h�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
							iErrorFlg = false;
						}
// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END
						sKey[2] = sValue[0];
						if (sKey[2].Length > 15)
						{
							sbErr.Append(iLineCnt + "�s��:�׎�l�R�[�h�͂P�T�����ȓ��œ��͂��Ă�������\r\n");
							iErrorFlg = false;
						}
						//�d�b�ԍ�
						sKey[3] = sValue[1];
						sKey[4] = sValue[2];
						sKey[5] = sValue[3];
						if (sKey[3] == null || sKey[3].Length == 0) sKey[3] = " ";
						if (sKey[4] == null || sKey[4].Length == 0) sKey[4] = " ";
						if (sKey[5] == null || sKey[5].Length == 0) sKey[5] = " ";
						string sTel = sValue[1] + sValue[2] + sValue[3];
						if (!�K�{�`�F�b�N(sTel))
						{
							sbErr.Append(iLineCnt + "�s��:�d�b�ԍ��͕K�{���ڂł�\r\n");
							iErrorFlg = false;
						}
// MOD 2008.04.11 ACT Vista�Ή� START
//						if (!���p�`�F�b�N(sTel))
						if (!���l�`�F�b�N(sTel))
// MOD 2008.04.11 ACT Vista�Ή� END
						{
// MOD 2008.04.11 ACT Vista�Ή� START
//							sbErr.Append(iLineCnt + "�s��:�d�b�ԍ��͔��p�����œ��͂��Ă�������\r\n");
							sbErr.Append(iLineCnt + "�s��:�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
// MOD 2008.04.11 ACT Vista�Ή� END
							iErrorFlg = false;
						}
						//�e�`�w�ԍ�
						string sFax = sValue[4] + sValue[5] + sValue[6];
// MOD 2008.04.11 ACT Vista�Ή� START
//						if (!���p�`�F�b�N(sFax))
						if (!���l�`�F�b�N(sFax))
// MOD 2008.04.11 ACT Vista�Ή� END
						{
// MOD 2008.04.11 ACT Vista�Ή� START
//							sbErr.Append(iLineCnt + "�s��:�e�`�w�ԍ��͔��p�����œ��͂��Ă�������\r\n");
							sbErr.Append(iLineCnt + "�s��:�e�`�w�ԍ��͐��l�œ��͂��Ă�������\r\n");
// MOD 2008.04.11 ACT Vista�Ή� END
							iErrorFlg = false;
						}
						sKey[6] = sValue[4];
						sKey[7] = sValue[5];
						sKey[8] = sValue[6];
						if (sKey[6] == null || sKey[6].Length == 0) sKey[6] = " ";
						if (sKey[7] == null || sKey[7].Length == 0) sKey[7] = " ";
						if (sKey[8] == null || sKey[8].Length == 0) sKey[8] = " ";
						//�Z���P
						if (!�K�{�`�F�b�N(sValue[7]))
						{
							sbErr.Append(iLineCnt + "�s��:�Z���P�͕K�{���ڂł�\r\n");
							iErrorFlg = false;
						}
						if (!�S�p�`�F�b�N(sValue[7]))
						{
							sbErr.Append(iLineCnt + "�s��:�Z���P�͑S�p�����œ��͂��Ă�������\r\n");
							iErrorFlg = false;
						}
						sKey[9] = sValue[7];
						//�Z���Q
						if (sValue[8].Length != 0)
						{
							if (!�S�p�`�F�b�N(sValue[8]))
							{
								sbErr.Append(iLineCnt + "�s��:�Z���Q�͑S�p�����œ��͂��Ă�������\r\n");
								iErrorFlg = false;
							}
							sKey[10] = sValue[8];
						}
						if (sKey[10] == null || sKey[10].Length == 0) sKey[10] = " ";
						//�Z���R
						if (sValue[9].Length != 0)
						{
							if (!�S�p�`�F�b�N(sValue[9]))
							{
								sbErr.Append(iLineCnt + "�s��:�Z���R�͑S�p�����œ��͂��Ă�������\r\n");
								iErrorFlg = false;
							}
							sKey[11] = sValue[9];
						}
						if (sKey[11] == null || sKey[11].Length == 0) sKey[11] = " ";
						//���O�P
						if (!�K�{�`�F�b�N(sValue[10]))
						{
							sbErr.Append(iLineCnt + "�s��:���O�P�͕K�{���ڂł�\r\n");
							iErrorFlg = false;
						}
						if (!�S�p�`�F�b�N(sValue[10]))
						{
							sbErr.Append(iLineCnt + "�s��:���O�P�͑S�p�����œ��͂��Ă�������\r\n");
							iErrorFlg = false;
						}
						sKey[12] = sValue[10];
						//���O�Q
						if (sValue[11].Length != 0)
						{
							if (!�S�p�`�F�b�N(sValue[11]))
							{
								sbErr.Append(iLineCnt + "�s��:���O�Q�͑S�p�����œ��͂��Ă�������\r\n");
								iErrorFlg = false;
							}
							sKey[13] = sValue[11];
						}
						if (sKey[13] == null || sKey[13].Length == 0) sKey[13] = " ";
						//���O�R ���g�p
						if (sValue[12].Length != 0)
						{
							if (!�S�p�`�F�b�N(sValue[12]))
							{
								sbErr.Append(iLineCnt + "�s��:���O�R�͑S�p�����œ��͂��Ă�������\r\n");
								iErrorFlg = false;
							}
							sKey[14] = sValue[12];
						}
						if (sKey[14] == null || sKey[14].Length == 0) sKey[14] = " ";
						//�X�֔ԍ�
						sKey[15] = sValue[13] + sValue[14];
// DEL 2006.12.01 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̍폜 START
//// ADD 2006.07.14 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̒ǉ� START
//						sKey[21] = " ";
//						//�X�֔ԍ��������͂̏ꍇ
//						if(sKey[15].Length == 0){
//							string[] sRet = {"","","","","",""};
//							sRet = �X�֔ԍ��擾(sKey[9].Trim() + sKey[10].Trim() + sKey[11].Trim());
//							if(sRet[0].Length == 4)
//							{
//								//�X�֔ԍ������݂��A�X���b�c�������Ă��Ă��鎞
//								//if(sRet[1].Length == 7 && sRet[3].Trim().Length > 0)
//								if(sRet[1].Length == 7)
//								{
//									sKey[15] = sRet[1];	//�X�֔ԍ�
//									sKey[21] = sRet[2];	//�Z���b�c�W��
//									sKey[19] = sRet[3]; //�X���b�c
//									//sRet[4]; //�s���{���b�c
//									//sRet[5]; //�s�撬���b�c
//								}
//							}
////							else if(sRet[0].Length > 4)
////							{ 
////								sbErr.Append(iLineCnt + "�s��:" + sRet[0] +"\r\n");
////								iErrorFlg = false;
////							}
//						}
//// ADD 2006.07.14 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̒ǉ� END
// DEL 2006.12.01 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̍폜 END
						if (!�K�{�`�F�b�N(sKey[15])) 
						{
							sbErr.Append(iLineCnt + "�s��:�X�֔ԍ��͕K�{���ڂł�\r\n");
							iErrorFlg = false;
						}
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
//						if (!���l�`�F�b�N(sKey[15]))
//						{
//							sbErr.Append(iLineCnt + "�s��:�X�֔ԍ��͐��l�œ��͂��Ă�������\r\n");
//							iErrorFlg = false;
//						}
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
						if (sKey[15].Length > 7)
						{
							sbErr.Append(iLineCnt + "�s��:�X�֔ԍ��͂V�����ȓ��œ��͂��Ă�������\r\n");
							iErrorFlg = false;
						}
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
//						if (���l�`�F�b�N(sKey[15]) && sKey[15].Length <= 7)
//						{
//							//�X�֔ԍ����݃`�F�b�N
//							string[] sRet = {""};
//							try
//							{
//								if(sv_address == null) sv_address = new is2address.Service1();
//								sRet = sv_address.Get_byPostcode2(gsa���[�U,sKey[15]);
//							}
//							catch (System.Net.WebException)
//							{
//								sbErr.Append(iLineCnt + "�s��:"+ gs�ʐM�G���[ +"\r\n");
//								iErrorFlg = false;
//							}
//							catch (Exception ex)
//							{
//								sbErr.Append(iLineCnt + "�s��:�ʐM�G���[�F" + ex.Message +"\r\n");
//								iErrorFlg = false;
//							}
//
//							if(sRet[0].Length != 4)
//							{
//								sbErr.Append(iLineCnt + "�s��:�X�֔ԍ������݂��܂���\r\n");
//								iErrorFlg = false;
//							}
//						}
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
						if (sKey[15].Length == 0) sKey[15] = " ";
						//�J�i����
						sValue[16] = sValue[16];
						if (sValue[16].Trim().Length != 0)
						{
							if (!���p�`�F�b�N(sValue[16]))
							{
								sbErr.Append(iLineCnt + "�s��:�J�i���͔̂��p�����œ��͂��Ă�������\r\n");
								iErrorFlg = false;
							}
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
//							if(!�L���`�F�b�N(sValue[16])){
//								sbErr.Append(iLineCnt + "�s��:�J�i���̂Ɏg�p�ł��Ȃ��L��������܂�\r\n");
//								iErrorFlg = false;
//							}
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END
						}
						sKey[16] = sValue[16];
						if (sKey[16].Length > 10)
						{
							sbErr.Append(iLineCnt + "�s��:�J�i���̂͂P�O�����ȓ��œ��͂��Ă�������\r\n");
							iErrorFlg = false;
						}
						if (sKey[16].Length == 0) sKey[16] = " ";
						//��ďo�׋敪 ���g�p
						sValue[18] = sValue[18];
						if (!���p�`�F�b�N(sValue[18]))
						{
							sbErr.Append(iLineCnt + "�s��:��ďo�׋敪�͔��p�����œ��͂��Ă�������\r\n");
							iErrorFlg = false;
						}
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
//						if(!�L���`�F�b�N(sValue[18])){
//							sbErr.Append(iLineCnt + "�s��:��ďo�׋敪�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
//							iErrorFlg = false;
//						}
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END
						sKey[17] = sValue[18];
						if (sKey[17].Length > 2)
						{
							sbErr.Append(iLineCnt + "�s��:��ďo�׋敪�͂Q�����ȓ��œ��͂��Ă�������\r\n");
							iErrorFlg = false;
						}
						if (sKey[17].Length == 0) sKey[17] = " ";
						//����v ���g�p
						sValue[19] = sValue[19];
						if (!���p�`�F�b�N(sValue[19])) 
						{
							sbErr.Append(iLineCnt + "�s��:����v�͔��p�����œ��͂��Ă�������\r\n");
							iErrorFlg = false;
						}
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
//						if(!�L���`�F�b�N(sValue[19])){
//							sbErr.Append(iLineCnt + "�s��:����v�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
//							iErrorFlg = false;
//						}
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END
						sKey[18] = sValue[19];
						if (sKey[18].Length > 5) 
						{
							sbErr.Append(iLineCnt + "�s��:����v�͂T�����ȓ��œ��͂��Ă�������\r\n");
							iErrorFlg = false;
						}
						if (sKey[18].Length == 0) sKey[18] = " ";
						//���X�R�[�h
						sKey[19] = sValue[15];
// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX START
						//�Z���R�[�h
						sKey[21] = sValue[17].Trim();
// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX END
// ADD 2008.04.23 ���s�j���� �Œ蒷�t�@�C���̃G���[�t�@�C���o�͑Ή� START
						iLenErrMsg = sbErr.ToString().Trim().Length;
						if(iLenErrMsg != iLenErrMsgOld)
						{
							iLenErrMsgOld = iLenErrMsg;
							sw = �G���[�t�@�C���o��(sw, errfileName, sData);
							if(sw == null) return;
						}
						else
						{
// ADD 2008.04.23 ���s�j���� �Œ蒷�t�@�C���̃G���[�t�@�C���o�͑Ή� END
							StringBuilder sbKeyData = new StringBuilder();
							for (int j = 0; j < sKey.Length; j++)
							{
								sbKeyData.Append(sKey[j] + ",");
							}
							alKey.Add(sbKeyData.ToString().Substring(0, sbKeyData.ToString().Length - 1));
// ADD 2008.04.23 ���s�j���� �Œ蒷�t�@�C���̃G���[�t�@�C���o�͑Ή� START
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
							saData[i�T�[�o���M�s] = sData;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
//							iaData[i�T�[�o���M�s] = iCnt;
							iaData[i�T�[�o���M�s] = iLineCnt;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
							i�T�[�o���M�s++;
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
						}
// ADD 2008.04.23 ���s�j���� �Œ蒷�t�@�C���̃G���[�t�@�C���o�͑Ή� END
						if(iErrorFlg == false)
						{
							i�G���[����++;
							lbl�G���[����.Text=i�G���[����.ToString()+"��";
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
							lbl�G���[����.Refresh();
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
							iErrorFlg = true;
						}
						else
						{
							iSetCnt++;
// ADD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� START
							if(iSetCnt >= 100)
								break;
// ADD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� END
						}
// DEL 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� START
//						if(iSetCnt >= 100)
//							break;
// DEL 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� END
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
						i�V�[�g������ = iCnt;
						lbl�V�[�g������.Text=i�V�[�g������.ToString()+"��";
						lbl�V�[�g������.Refresh();
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
						sData = sr.ReadLine();
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
//						iCnt++;
						if(sData != null)iCnt++;
						if(sData != null)iLineCnt++;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
					}
					if (alKey.Count > 0)
					{
						string[] sList = new string[alKey.Count];
						IEnumerator enumList = alKey.GetEnumerator();
						int i = 0;
						while(enumList.MoveNext())
						{
							sList[i] = enumList.Current.ToString();
							i++;
						}
						string[] sRet = {""};
						try
						{
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
//							sRet = sv_otodoke.Ins_uploadData(gsa���[�U,sList);
// MOD 2015.05.13 BEVAS) �O�c ���q����l�͉��q�X�֔ԍ��}�X�^�ő��݃`�F�b�N�@START
							if (gs����b�c.Substring(0,1) != "J") 
							{
// MOD 2015.05.13 BEVAS) �O�c ���q����l�͉��q�X�֔ԍ��}�X�^�ő��݃`�F�b�N�@END
								sRet = sv_otodoke.Ins_uploadData2(gsa���[�U,sList);
// MOD 2015.05.13 BEVAS) �O�c ���q����l�͉��q�X�֔ԍ��}�X�^�ő��݃`�F�b�N�@START
							} 
							else 
							{
								if(sv_oji == null) sv_oji = new is2oji.Service1();
								sRet = sv_oji.otodoke_Ins_uploadData2(gsa���[�U, sList); 
							}
// MOD 2015.05.13 BEVAS) �O�c ���q����l�͉��q�X�֔ԍ��}�X�^�ő��݃`�F�b�N�@END

// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
// MOD 2009.12.01 ���s�j���� �f�[�^�o�^���̃G���[�`�F�b�N��ǉ� START
							//�o�^���ɃG���[�����������ꍇ�I������
							if(sRet[0].Length > 0)
							{
								tex���b�Z�[�W.Text = sRet[0];
								iTxtMsgDsp  = false;
								break;
							}
// MOD 2009.12.01 ���s�j���� �f�[�^�o�^���̃G���[�`�F�b�N��ǉ� END
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
							for(int iLine2 = 1; iLine2 < sRet.Length; iLine2++){
								if(sRet[iLine2].Length > 0){
									i�G���[����++;
									iSetCnt--;
									sbErr.Append(iaData[iLine2] + "�s��:�X�֔ԍ�["+sRet[iLine2]+"]�����݂��܂���\r\n");
									iLenErrMsg = sbErr.ToString().Trim().Length;
									if(iLenErrMsg != iLenErrMsgOld){
										iLenErrMsgOld = iLenErrMsg;
									}
									sw = �G���[�t�@�C���o��(sw, errfileName, saData[iLine2]);
									if(sw == null) return;
								}
							}
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
						}
						catch (System.Net.WebException)
						{
							sRet[0] = gs�ʐM�G���[;
							tex���b�Z�[�W.Text = sRet[0];
							iTxtMsgDsp  = false;
							break;
						}
						catch (Exception ex)
						{
							sRet[0] = "�ʐM�G���[�F" + ex.Message;
							tex���b�Z�[�W.Text = sRet[0];
							iTxtMsgDsp  = false;
							break;
						}
						i�o�^���� += iSetCnt;
						lbl�捞����.Text=i�o�^����.ToString()+"��";
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
						lbl�捞����.Refresh();

						lbl�G���[����.Text=i�G���[����.ToString()+"��";
						lbl�G���[����.Refresh();
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
// ADD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� START
						alKey = null;
						enumList = null;
// ADD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� END
						iSetCnt = 0;
					}
// ADD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� START
 					if(sData == null){
						break;
					}
// ADD 2007.02.20 ���s�j���� �s���J�E���g�̏�Q�C�� END
				}
			}
			catch (Exception ex)
			{
				sbErr.Append(ex.Message);
			}
			finally
			{
				sr.Close();
// ADD 2008.04.23 ���s�j���� �Œ蒷�t�@�C���̃G���[�t�@�C���o�͑Ή� START
				if(sw != null) sw.Close();
// ADD 2008.04.23 ���s�j���� �Œ蒷�t�@�C���̃G���[�t�@�C���o�͑Ή� END
			}
			tex�f�[�^�G���[.Text = sbErr.ToString();
			
			Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
//			int Wrkcnt = i�o�^����;
//			lbl�捞����.Text=Wrkcnt.ToString()+"��";
			lbl�捞����.Text=i�o�^����.ToString()+"��";
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
			lbl�G���[����.Text=i�G���[����.ToString()+"��";
// MOD 2007.01.17 FJCS) �K�c�@�׎呍�������V�[�g�������ɕύX START
//			lbl�׎呍����.Text=i�׎呍����.ToString()+"��";
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� START
//			i�V�[�g������ = iCnt - 1;
			i�V�[�g������ = iCnt;
// MOD 2010.05.11 ���s�j���� �s���\���̏�Q�C�� END
// ADD 2007.02.21 ���s�j���� �������|�P�ɂȂ� START
			if(i�V�[�g������ < 0) i�V�[�g������ = 0;
// ADD 2007.02.21 ���s�j���� �������|�P�ɂȂ� END
			lbl�V�[�g������.Text=i�V�[�g������.ToString()+"��";
// MOD 2007.01.17 FJCS) �K�c�@�׎呍�������V�[�g�������ɕύX END
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� START
			lbl�捞����.Refresh();
			lbl�G���[����.Refresh();
			lbl�V�[�g������.Refresh();
// MOD 2010.05.07 ���s�j���� �b�r�u�捞���̗X�֔ԍ��P�O�O���ꊇ�`�F�b�N��ǉ� END
			if(iTxtMsgDsp == true)
				tex���b�Z�[�W.Text = "";
// MOD 2007.02.21 ���s�j���� �G���[���̊������b�Z�[�W�̕ύX START
//			MessageBox.Show("�捞�������������܂����B","���͂���捞",MessageBoxButtons.OK);
			if(i�G���[���� == 0 && i�V�[�g������ == 0){
				MessageBox.Show("�捞�f�[�^�����݂��܂���ł����B"
								,"���͂���捞",MessageBoxButtons.OK);
			}else{
				if(i�o�^���� == 0){
					MessageBox.Show("�G���[�����������ׁA��荞�߂܂���ł����B"
									,"���͂���捞",MessageBoxButtons.OK);
				}else if(i�G���[���� > 0 || i�V�[�g������ != i�o�^����){
					MessageBox.Show("�G���[�����������ׁA��荞�߂Ȃ������f�[�^������܂��B"
									,"���͂���捞",MessageBoxButtons.OK);
				}else{
					MessageBox.Show("�捞�������������܂����B"
									,"���͂���捞",MessageBoxButtons.OK);
				}
			}
// MOD 2007.02.21 ���s�j���� �G���[���̊������b�Z�[�W�̕ύX END
		}
// MOD 2006.07.10 ���s�j�R�{ �b�r�u�捞�����l�`�w�R�O�O�O�O���i�o�^�͂P�O�O���P�ʁj�ύX END

// DEL 2005.06.30 ���s�j�����J ���ʃt�H�[���ֈړ� START
//		private bool �K�{�`�F�b�N(string data)
//		{
//			if (data.Trim().Length == 0)
//				return false;
//			else
//				return true;
//		}

//		private bool �S�p�`�F�b�N(string data)
//		{
//			string sUnicode = data.Trim();
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

// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� START
		private void ���͂���捞_Closed(object sender, System.EventArgs e)
		{
			tex�t�@�C����.Text   = " ";
			tex�f�[�^�G���[.Text = "";
			tex���b�Z�[�W.Text   = "";
			tex�t�@�C����.Focus();
		}
// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� END
// DEL 2006.12.01 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̍폜 START
//// ADD 2006.07.14 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̒ǉ� START
//		private int �s�撬���擾(string s�Z��, int i�J�n�ʒu)
//		{
//			int i�s�撬���P = s�Z��.Length;
//			int i�s�P = s�Z��.IndexOf("�s", i�J�n�ʒu);
//			int i��P = s�Z��.IndexOf("��", i�J�n�ʒu);
//			int i���P = s�Z��.IndexOf("��", i�J�n�ʒu);
//			int i���P = s�Z��.IndexOf("��", i�J�n�ʒu);
//
//			if(i�s�P >= 0 && i�s�P < i�s�撬���P) i�s�撬���P = i�s�P;
//			if(i��P >= 0 && i��P < i�s�撬���P) i�s�撬���P = i��P;
//			if(i���P >= 0 && i���P < i�s�撬���P) i�s�撬���P = i���P;
//			if(i���P >= 0 && i���P < i�s�撬���P) i�s�撬���P = i���P;
//
//			if(i�s�撬���P == s�Z��.Length) return -1;
//
//			return i�s�撬���P;
//		}
//
//		private string[] �X�֔ԍ��擾(string s�Z��)
//		{
//			string[] sRet = {"","","","","",""};
//			string s�s���{���b�c = "";
//			string s�s�撬���P   = "";
//			string s�s�撬���Q   = "";
//			string s�ҏW�Z��     = "";
//
//			s�Z�� = s�Z��.Replace(" ","");	//���p�󔒏���
//			s�Z�� = s�Z��.Replace("�@","");	//�S�p�󔒏���
//			
//			//�s���{���n�b�V���e�[�u���̍쐬
//			if(h�s���{���Q == null)
//			{
//				h�s���{���Q = new Hashtable();
//				for(int iCnt1 = 1; iCnt1 < gsa����.Length; iCnt1++)
//				{
//					h�s���{���Q.Add(gsa����[iCnt1],iCnt1.ToString("00"));
//				}
//			}
//
//			if(s�Z��.Length >= 3)
//			{
//				//�s���{���b�c�̎擾
//				string s�ҏW��     = "";
//				int    iIndex      = 0;
//				// �u�_�ސ쌧�v�A�u�a�̎R���v�A�u���������v�͂S�����ŕ�������r����
//				if((s�Z��[0] == '�_' || s�Z��[0] == '�a' || s�Z��[0] == '��')
//					&& s�Z��.Length >= 4 
//					&& s�Z��[3] == '��')
//				{
//					s�ҏW�� = s�Z��.Substring(0,4);
//					iIndex  = 4;
//				}
//				else
//				{
//					s�ҏW�� = s�Z��.Substring(0,3);
//					iIndex  = 3;
//				}
//				Object obj = h�s���{���Q[s�ҏW��];
//				if(obj != null)
//				{
//					s�s���{���b�c = (string)obj;
//					s�Z�� = s�Z��.Remove(0,iIndex);
//				}
//			}
//			s�ҏW�Z�� = s�Z��;
//
//			//�����܂�������ϊ�
//			for(int iCnt1 = 0; iCnt1 < s�����܂�����.Length; iCnt1++)
//			{
//				if(s�Z��.IndexOf(s�����܂�����[iCnt1]) >= 0)
//					s�Z�� = s�Z��.Replace(s�����܂�����[iCnt1], s�����܂������ϊ�[iCnt1]);
//			}
//			s�ҏW�Z�� = s�Z��;
//
//			//������������ϊ�
//			for(int iCnt1 = 0; iCnt1 < sa������.Length; iCnt1++)
//			{
//				for(int iCnt2 = 0; iCnt2 < sa������[iCnt1].Length; iCnt2++)
//				{
//					if(s�Z��.IndexOf(sa������[iCnt1][iCnt2]) >= 0)
//						s�Z�� = s�Z��.Replace(sa������[iCnt1][iCnt2], sa�V����[iCnt1][iCnt2]);
//				}
//			}
//			s�ҏW�Z�� = s�Z��;
//
//			//�ȗ��\�������폜
//			s�Z�� = s�Z��.Replace("��","");
//			s�Z�� = s�Z��.Replace("��","");
//			s�Z�� = s�Z��.Replace("��","");
//			s�Z�� = s�Z��.Replace("�i","");
//			s�Z�� = s�Z��.Replace("�j","");
//			s�ҏW�Z�� = s�Z��;
//
//			//�s�撬���̋�؂�
//			int i�s�撬���P = �s�撬���擾(s�Z��, 0);
//			if(i�s�撬���P >= 0)
//			{
//				s�s�撬���P = s�Z��.Substring(0, i�s�撬���P + 1);
//				if(i�s�撬���P < s�Z��.Length)
//				{
//					int i�s�撬���Q = �s�撬���擾(s�Z��, i�s�撬���P + 1);
//					if(i�s�撬���Q >= 0){
//						s�s�撬���Q = s�Z��.Substring(0, i�s�撬���Q + 1);
//					}
//				}
//			}
//
//			try
//			{
//				if(sv_address == null) sv_address = new is2address.Service1();
//				sRet = sv_address.GetPostcode(gsa���[�U, s�s���{���b�c, 
//											s�s�撬���P, s�s�撬���Q, s�ҏW�Z��);
//			}
//			catch (System.Net.WebException)
//			{
//				sRet[0] = gs�ʐM�G���[;
//			}
//			catch (Exception ex)
//			{
//				sRet[0] = "�ʐM�G���[�F" + ex.Message;
//			}
//
//			return sRet;
//		}
//// ADD 2006.07.14 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̒ǉ� END
// DEL 2006.12.01 ���s�j���� �Z�����X�֔ԍ��ϊ��@�\�̍폜 END

	}
}
