using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [���C�u�����o�^]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// ADD 2008.04.25 ���s�j���� �i���L���̍ő包����ݒ�
	// �`�b�s�j�R�{�a����Q�񍐗L
	// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� 
	//--------------------------------------------------------------------------
	// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� 
	// MOD 2009.08.20 �p�\�j���� �X�֔ԍ��̒l���p�� 
	// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� 
	// MOD 2009.09.04 ���s�j���� Vista�Ή�(TAB�Ή�����) 
	// MOD 2009.09.09 ���s�j���� �O�񌟍��˗���b�c�̃N���A����Ή� 
	// MOD 2009.09.09 ���s�j���� ��ʕ\���s��̒��� 
	// MOD 2009.12.01 ���s�j���� �S�p���p���݉\�ɂ��� 
	//--------------------------------------------------------------------------
	// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX 
	// MOD 2010.09.07 ���s�j���� ������`�F�b�N�̕\���ύX 
	// MOD 2010.09.24 ���s�j���� �d�ʎ����v�Z���̏���G���[�Ή� 
	// MOD 2010.09.27 ���s�j���� �����敔�ۖ��̒ǉ� 
	// MOD 2010.10.04 ���s�j���� �S���ҁi�˗��啔���j�t�H�[�J�X��Q�Ή� 
	// MOD 2010.11.01 ���s�j���� ���˗�����̏d�ʒl�O�Ή� 
	// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX 
	// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� 
	// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� 
	// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� 
	// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� 
	// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� 
	// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� 
	// MOD 2011.07.28 ���s�j���� �L���s�̒ǉ��i�����������̒ǉ��j 
	// MOD 2011.08.02 ���s�j���� �e���ڂ̓��͕s�Ή��i�s������j 
	// MOD 2011.08.05 ���s�j���� �L���s�̒ǉ��i�R�s�E�U�s�֑ؑΉ��j 
	// MOD 2011.09.26 ���s�j���� �L���s�̒ǉ��i�R�s�E�U�s�֑ؑΉ��j 
	// MOD 2011.12.08 ���s�j���� �Z���E���O�̔��p���͉� 
	//--------------------------------------------------------------------------
	// MOD 2015.05.07 BEVAS) �O�c ���q�׎�l�̗X�֔ԍ����݃`�F�b�N��CM14J�ōs��
	// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή�
	//--------------------------------------------------------------------------
	// MOD 2016.06.10 BEVAS�j���{ �ی������̓`�F�b�N�@�\�̒ǉ��i31���~�ȏ�̏ꍇ�j
	//--------------------------------------------------------------------------
	public class ���^�o�^ : ���ʃt�H�[��
	{
		// ���^�o�׏Ɖ��W�����v�����ꍇ�Ɏg�p
		public int    i���^�m�n       = 0;
		public string s���^����       = "";
		// �o�׏Ɖ�ꗗ����W�����v�����ꍇ�Ɏg�p
		public string s�o�^��         = "";
		public string s�W���[�i���m�n = "";
		// �����ϐ�
		private bool   b�X�V�e�f      = false;
		private string s�t�@�C����    = "";
		private string s�X�V�N����    = "";
		private string s�͂���b�c    = "";
		private string s�˗���b�c    = "";
		private string s�O�񌟍��˗���b�c = "";
		private int      i�A�N�e�B�u�e�f = 0;
// ADD 2005.05.13 ���s�j�����J �˗���d�� START
		private decimal d�d�� = 0;
// ADD 2005.05.13 ���s�j�����J �˗���d�� END
// ADD 2005.05.17 ���s�j�����J �ː� START
		private string s�d��     = "";
		private string s�ː�     = "";
		private int    i�ː��e�f = 1;
		private int    i�ː��ێ� = 1;
// ADD 2005.05.17 ���s�j�����J �ː� END
		private string s�A�����i�e�R�[�h = "";
		private string s�A�����i�q�R�[�h = "";
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� START
		private string s�C���O_�˗���b�c = ""; //
		private string s�C���O_������b�c = ""; //
		private string s�C���O_�����敔�� = ""; //�����敔�ۂb�c
		private string s�C���O_�����於   = ""; //
		private string s�C���O_��       = ""; //
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� END
// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� START
		private string s��ʐ���_�d�� = "0";
// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� END

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab����;
		private ���ʃe�L�X�g�{�b�N�X tex���^��;
		private System.Windows.Forms.TextBox tex���q�l��;
		private System.Windows.Forms.Label lab���q�l��;
		private System.Windows.Forms.Label lab���p����;
		private System.Windows.Forms.TextBox tex���p����;
		private System.Windows.Forms.Label lab���^�o�^�^�C�g��;
		private ���ʃe�L�X�g�{�b�N�X tex�͂���R�[�h;
		private ���ʃe�L�X�g�{�b�N�X tex�͂���d�b�ԍ��P;
		private ���ʃe�L�X�g�{�b�N�X tex�͂��於�O�Q;
		private ���ʃe�L�X�g�{�b�N�X tex�͂��於�O�P;
		private ���ʃe�L�X�g�{�b�N�X tex�͂���Z���R;
		private ���ʃe�L�X�g�{�b�N�X�Q tex�͂���X�֔ԍ��Q;
		private ���ʃe�L�X�g�{�b�N�X tex�͂���X�֔ԍ��P;
		private ���ʃe�L�X�g�{�b�N�X tex�͂���d�b�ԍ��R;
		private ���ʃe�L�X�g�{�b�N�X tex�͂���d�b�ԍ��Q;
		private ���ʃe�L�X�g�{�b�N�X tex�͂���Z���Q;
		private ���ʃe�L�X�g�{�b�N�X tex�͂���Z���P;
		private System.Windows.Forms.TextBox tex�˗��吿����;
		private ���ʃe�L�X�g�{�b�N�X tex�˗��啔��;
		private System.Windows.Forms.TextBox tex�˗��喼�O�Q;
		private System.Windows.Forms.TextBox tex�˗��喼�O�P;
		private System.Windows.Forms.TextBox tex�˗���X�֔ԍ��Q;
		private System.Windows.Forms.TextBox tex�˗���X�֔ԍ��P;
		private System.Windows.Forms.TextBox tex�˗���d�b�ԍ��R;
		private System.Windows.Forms.TextBox tex�˗���d�b�ԍ��Q;
		private System.Windows.Forms.TextBox tex�˗���d�b�ԍ��P;
		private System.Windows.Forms.TextBox tex�˗���Z���Q;
		private System.Windows.Forms.TextBox tex�˗���Z���P;
		private ���ʃe�L�X�g�{�b�N�X tex�˗���R�[�h;
		private ���ʃe�L�X�g�{�b�N�X tex�A�����q;
		private ���ʃe�L�X�g�{�b�N�X tex�A�����e;
		private ���ʃe�L�X�g�{�b�N�X tex�L�����R;
		private ���ʃe�L�X�g�{�b�N�X tex�L�����Q;
		private ���ʃe�L�X�g�{�b�N�X tex�L�����P;
		private ���ʃe�L�X�g�{�b�N�X tex�A���R�[�h�e;
		private ���ʃe�L�X�g�{�b�N�X tex�L���R�[�h;
		private System.Windows.Forms.NumericUpDown nUD�d��;
		private System.Windows.Forms.NumericUpDown nUD�ی����z;
		private System.Windows.Forms.NumericUpDown nUD��;
		private System.Windows.Forms.NumericUpDown nUD�o�^�ԍ�;
		private System.Windows.Forms.TextBox tex���b�Z�[�W;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Button btn�폜;
		private System.Windows.Forms.Button btn���;
		private System.Windows.Forms.Button btn�X�V;
		private System.Windows.Forms.Button btn�͂��挟��;
		private System.Windows.Forms.Button btn�Z������;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Button btn�˗��匟��;
		private System.Windows.Forms.Button btn�L������;
		private System.Windows.Forms.Button btn�A������;
		private System.Windows.Forms.Button btn�A�C�R��;
		private System.Windows.Forms.Label lab�͂��於�O;
		private System.Windows.Forms.Label lab�͂���Z��;
		private System.Windows.Forms.Label lab�͂���X�֔ԍ�;
		private System.Windows.Forms.Label lab�͂���d�b�ԍ�;
		private System.Windows.Forms.Label lab�͂���R�[�h;
		private System.Windows.Forms.Label lab�˗��啔��;
		private System.Windows.Forms.Label lab�˗��喼�O;
		private System.Windows.Forms.Label lab�˗���Z��;
		private System.Windows.Forms.Label lab�˗���X�֔ԍ�;
		private System.Windows.Forms.Label lab�˗���d�b�ԍ�;
		private System.Windows.Forms.Label lab�˗���R�[�h;
		private System.Windows.Forms.Label lab�˗��吿����;
		private System.Windows.Forms.Label lab�A���R�[�h;
		private System.Windows.Forms.Label lab�A���w��;
		private System.Windows.Forms.Label lab�L���R�[�h;
		private System.Windows.Forms.Label lab�L��;
		private System.Windows.Forms.Label lab�d��;
		private System.Windows.Forms.Label lab�ی����z;
		private System.Windows.Forms.Label lab��;
		private System.Windows.Forms.Label lab�o�^�ԍ�;
		private System.Windows.Forms.Label lab���^��;
		private System.Windows.Forms.Label lab�A�C�R���ݒ�;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBox6;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�A���R�[�h�q;
		private System.Windows.Forms.TextBox tex�����敔�ۃR�[�h;
		private System.Windows.Forms.Label lab������R�[�h;
		private System.Windows.Forms.TextBox tex������R�[�h;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�L�����U;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�L�����T;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�L�����S;
		private System.Windows.Forms.Button btn�x�X�~��;
		private System.Windows.Forms.Button btn�x�X�~�߉���;
		private System.ComponentModel.IContainer components;

		public ���^�o�^()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(���^�o�^));
			this.tex�͂���R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�͂���d�b�ԍ��P = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btn�x�X�~�߉��� = new System.Windows.Forms.Button();
			this.btn�x�X�~�� = new System.Windows.Forms.Button();
			this.btn���� = new System.Windows.Forms.Button();
			this.label40 = new System.Windows.Forms.Label();
			this.label35 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.tex�͂��於�O�Q = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab�͂��於�O = new System.Windows.Forms.Label();
			this.tex�͂��於�O�P = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.btn�Z������ = new System.Windows.Forms.Button();
			this.tex�͂���Z���R = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab�͂���Z�� = new System.Windows.Forms.Label();
			this.tex�͂���X�֔ԍ��Q = new IS2Client.���ʃe�L�X�g�{�b�N�X�Q();
			this.tex�͂���X�֔ԍ��P = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.label8 = new System.Windows.Forms.Label();
			this.lab�͂���X�֔ԍ� = new System.Windows.Forms.Label();
			this.tex�͂���d�b�ԍ��R = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�͂���d�b�ԍ��Q = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lab�͂���d�b�ԍ� = new System.Windows.Forms.Label();
			this.lab�͂���R�[�h = new System.Windows.Forms.Label();
			this.tex�͂���Z���Q = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�͂���Z���P = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.btn�͂��挟�� = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tex�����敔�ۃR�[�h = new System.Windows.Forms.TextBox();
			this.lab������R�[�h = new System.Windows.Forms.Label();
			this.tex������R�[�h = new System.Windows.Forms.TextBox();
			this.tex�˗���d�b�ԍ��P = new System.Windows.Forms.TextBox();
			this.tex�˗��吿���� = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.lab�˗��啔�� = new System.Windows.Forms.Label();
			this.lab�˗��喼�O = new System.Windows.Forms.Label();
			this.lab�˗���Z�� = new System.Windows.Forms.Label();
			this.lab�˗���X�֔ԍ� = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.lab�˗���d�b�ԍ� = new System.Windows.Forms.Label();
			this.tex�˗��啔�� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�˗��喼�O�Q = new System.Windows.Forms.TextBox();
			this.tex�˗��喼�O�P = new System.Windows.Forms.TextBox();
			this.tex�˗���X�֔ԍ��Q = new System.Windows.Forms.TextBox();
			this.tex�˗���X�֔ԍ��P = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.tex�˗���d�b�ԍ��R = new System.Windows.Forms.TextBox();
			this.tex�˗���d�b�ԍ��Q = new System.Windows.Forms.TextBox();
			this.lab�˗���R�[�h = new System.Windows.Forms.Label();
			this.tex�˗���Z���Q = new System.Windows.Forms.TextBox();
			this.tex�˗���Z���P = new System.Windows.Forms.TextBox();
			this.btn�˗��匟�� = new System.Windows.Forms.Button();
			this.label21 = new System.Windows.Forms.Label();
			this.tex�˗���R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab�˗��吿���� = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.tex�L�����U = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�L�����T = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�L�����S = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�A�����q = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�A�����e = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�L�����R = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�L�����Q = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�L�����P = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.btn�A������ = new System.Windows.Forms.Button();
			this.tex�A���R�[�h�e = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab�A���R�[�h = new System.Windows.Forms.Label();
			this.lab�A���w�� = new System.Windows.Forms.Label();
			this.btn�L������ = new System.Windows.Forms.Button();
			this.tex�L���R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab�L���R�[�h = new System.Windows.Forms.Label();
			this.lab�L�� = new System.Windows.Forms.Label();
			this.tex�A���R�[�h�q = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.panel4 = new System.Windows.Forms.Panel();
			this.lab�d�� = new System.Windows.Forms.Label();
			this.nUD�d�� = new System.Windows.Forms.NumericUpDown();
			this.nUD�ی����z = new System.Windows.Forms.NumericUpDown();
			this.lab�ی����z = new System.Windows.Forms.Label();
			this.nUD�� = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.lab�� = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.nUD�o�^�ԍ� = new System.Windows.Forms.NumericUpDown();
			this.lab�o�^�ԍ� = new System.Windows.Forms.Label();
			this.tex���^�� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab���^�� = new System.Windows.Forms.Label();
			this.btn�A�C�R�� = new System.Windows.Forms.Button();
			this.panel6 = new System.Windows.Forms.Panel();
			this.tex���q�l�� = new System.Windows.Forms.TextBox();
			this.lab���q�l�� = new System.Windows.Forms.Label();
			this.lab���p���� = new System.Windows.Forms.Label();
			this.tex���p���� = new System.Windows.Forms.TextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab���� = new System.Windows.Forms.Label();
			this.lab���^�o�^�^�C�g�� = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn�폜 = new System.Windows.Forms.Button();
			this.btn��� = new System.Windows.Forms.Button();
			this.btn�X�V = new System.Windows.Forms.Button();
			this.tex���b�Z�[�W = new System.Windows.Forms.TextBox();
			this.btn���� = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panel9 = new System.Windows.Forms.Panel();
			this.lab�A�C�R���ݒ� = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nUD�d��)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD�ی����z)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD��)).BeginInit();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nUD�o�^�ԍ�)).BeginInit();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel9.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// tex�͂���R�[�h
			// 
			this.tex�͂���R�[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex�͂���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�͂���R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�͂���R�[�h.Location = new System.Drawing.Point(110, 2);
			this.tex�͂���R�[�h.MaxLength = 15;
			this.tex�͂���R�[�h.Name = "tex�͂���R�[�h";
			this.tex�͂���R�[�h.Size = new System.Drawing.Size(172, 23);
			this.tex�͂���R�[�h.TabIndex = 0;
			this.tex�͂���R�[�h.Text = "";
			this.tex�͂���R�[�h.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�͂���R�[�h_KeyDown);
			this.tex�͂���R�[�h.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�͂���R�[�h_KeyPress);
			// 
			// tex�͂���d�b�ԍ��P
			// 
			this.tex�͂���d�b�ԍ��P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�͂���d�b�ԍ��P.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�͂���d�b�ԍ��P.Location = new System.Drawing.Point(110, 28);
			this.tex�͂���d�b�ԍ��P.MaxLength = 6;
			this.tex�͂���d�b�ԍ��P.Name = "tex�͂���d�b�ԍ��P";
			this.tex�͂���d�b�ԍ��P.Size = new System.Drawing.Size(58, 23);
			this.tex�͂���d�b�ԍ��P.TabIndex = 2;
			this.tex�͂���d�b�ԍ��P.Text = "";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Honeydew;
			this.panel1.Controls.Add(this.btn�x�X�~�߉���);
			this.panel1.Controls.Add(this.btn�x�X�~��);
			this.panel1.Controls.Add(this.btn����);
			this.panel1.Controls.Add(this.label40);
			this.panel1.Controls.Add(this.label35);
			this.panel1.Controls.Add(this.label34);
			this.panel1.Controls.Add(this.label31);
			this.panel1.Controls.Add(this.tex�͂��於�O�Q);
			this.panel1.Controls.Add(this.lab�͂��於�O);
			this.panel1.Controls.Add(this.tex�͂��於�O�P);
			this.panel1.Controls.Add(this.btn�Z������);
			this.panel1.Controls.Add(this.tex�͂���Z���R);
			this.panel1.Controls.Add(this.lab�͂���Z��);
			this.panel1.Controls.Add(this.tex�͂���X�֔ԍ��Q);
			this.panel1.Controls.Add(this.tex�͂���X�֔ԍ��P);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.lab�͂���X�֔ԍ�);
			this.panel1.Controls.Add(this.tex�͂���d�b�ԍ��R);
			this.panel1.Controls.Add(this.tex�͂���d�b�ԍ��Q);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.tex�͂���d�b�ԍ��P);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.lab�͂���d�b�ԍ�);
			this.panel1.Controls.Add(this.lab�͂���R�[�h);
			this.panel1.Controls.Add(this.tex�͂���Z���Q);
			this.panel1.Controls.Add(this.tex�͂���Z���P);
			this.panel1.Controls.Add(this.btn�͂��挟��);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.tex�͂���R�[�h);
			this.panel1.Location = new System.Drawing.Point(0, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(448, 202);
			this.panel1.TabIndex = 1;
			// 
			// btn�x�X�~�߉���
			// 
			this.btn�x�X�~�߉���.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�x�X�~�߉���.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�x�X�~�߉���.ForeColor = System.Drawing.Color.White;
			this.btn�x�X�~�߉���.Location = new System.Drawing.Point(302, 54);
			this.btn�x�X�~�߉���.Name = "btn�x�X�~�߉���";
			this.btn�x�X�~�߉���.Size = new System.Drawing.Size(78, 22);
			this.btn�x�X�~�߉���.TabIndex = 39;
			this.btn�x�X�~�߉���.TabStop = false;
			this.btn�x�X�~�߉���.Text = "�x�X�~����";
			this.btn�x�X�~�߉���.Visible = false;
			this.btn�x�X�~�߉���.Click += new System.EventHandler(this.btn�x�X�~�߉���_Click);
			// 
			// btn�x�X�~��
			// 
			this.btn�x�X�~��.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�x�X�~��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�x�X�~��.ForeColor = System.Drawing.Color.White;
			this.btn�x�X�~��.Location = new System.Drawing.Point(302, 54);
			this.btn�x�X�~��.Name = "btn�x�X�~��";
			this.btn�x�X�~��.Size = new System.Drawing.Size(52, 22);
			this.btn�x�X�~��.TabIndex = 38;
			this.btn�x�X�~��.TabStop = false;
			this.btn�x�X�~��.Text = "�x�X�~";
			this.btn�x�X�~��.Click += new System.EventHandler(this.btn�x�X�~��_Click);
			// 
			// btn����
			// 
			this.btn����.BackColor = System.Drawing.Color.SteelBlue;
			this.btn����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn����.ForeColor = System.Drawing.Color.White;
			this.btn����.Location = new System.Drawing.Point(252, 54);
			this.btn����.Name = "btn����";
			this.btn����.Size = new System.Drawing.Size(48, 22);
			this.btn����.TabIndex = 8;
			this.btn����.TabStop = false;
			this.btn����.Text = "����";
			this.btn����.Click += new System.EventHandler(this.btn����_Click);
			// 
			// label40
			// 
			this.label40.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label40.ForeColor = System.Drawing.Color.Red;
			this.label40.Location = new System.Drawing.Point(26, 84);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(16, 14);
			this.label40.TabIndex = 37;
			this.label40.Text = "��";
			// 
			// label35
			// 
			this.label35.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label35.ForeColor = System.Drawing.Color.Red;
			this.label35.Location = new System.Drawing.Point(26, 154);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(16, 14);
			this.label35.TabIndex = 29;
			this.label35.Text = "��";
			// 
			// label34
			// 
			this.label34.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label34.ForeColor = System.Drawing.Color.Red;
			this.label34.Location = new System.Drawing.Point(26, 58);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(16, 14);
			this.label34.TabIndex = 28;
			this.label34.Text = "��";
			// 
			// label31
			// 
			this.label31.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label31.ForeColor = System.Drawing.Color.Red;
			this.label31.Location = new System.Drawing.Point(26, 34);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(16, 14);
			this.label31.TabIndex = 27;
			this.label31.Text = "��";
			// 
			// tex�͂��於�O�Q
			// 
			this.tex�͂��於�O�Q.BackColor = System.Drawing.SystemColors.Window;
			this.tex�͂��於�O�Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�͂��於�O�Q.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�͂��於�O�Q.Location = new System.Drawing.Point(110, 172);
			this.tex�͂��於�O�Q.MaxLength = 20;
			this.tex�͂��於�O�Q.Name = "tex�͂��於�O�Q";
			this.tex�͂��於�O�Q.Size = new System.Drawing.Size(330, 23);
			this.tex�͂��於�O�Q.TabIndex = 13;
			this.tex�͂��於�O�Q.Text = "";
			// 
			// lab�͂��於�O
			// 
			this.lab�͂��於�O.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�͂��於�O.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�͂��於�O.Location = new System.Drawing.Point(40, 154);
			this.lab�͂��於�O.Name = "lab�͂��於�O";
			this.lab�͂��於�O.Size = new System.Drawing.Size(56, 14);
			this.lab�͂��於�O.TabIndex = 24;
			this.lab�͂��於�O.Text = "���O";
			// 
			// tex�͂��於�O�P
			// 
			this.tex�͂��於�O�P.BackColor = System.Drawing.SystemColors.Window;
			this.tex�͂��於�O�P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�͂��於�O�P.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�͂��於�O�P.Location = new System.Drawing.Point(110, 150);
			this.tex�͂��於�O�P.MaxLength = 20;
			this.tex�͂��於�O�P.Name = "tex�͂��於�O�P";
			this.tex�͂��於�O�P.Size = new System.Drawing.Size(330, 23);
			this.tex�͂��於�O�P.TabIndex = 12;
			this.tex�͂��於�O�P.Text = "";
			// 
			// btn�Z������
			// 
			this.btn�Z������.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�Z������.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�Z������.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�Z������.ForeColor = System.Drawing.Color.White;
			this.btn�Z������.Location = new System.Drawing.Point(202, 54);
			this.btn�Z������.Name = "btn�Z������";
			this.btn�Z������.Size = new System.Drawing.Size(48, 22);
			this.btn�Z������.TabIndex = 7;
			this.btn�Z������.TabStop = false;
			this.btn�Z������.Text = "����";
			this.btn�Z������.Click += new System.EventHandler(this.btn�Z������_Click);
			// 
			// tex�͂���Z���R
			// 
			this.tex�͂���Z���R.BackColor = System.Drawing.SystemColors.Window;
			this.tex�͂���Z���R.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�͂���Z���R.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�͂���Z���R.Location = new System.Drawing.Point(110, 124);
			this.tex�͂���Z���R.MaxLength = 20;
			this.tex�͂���Z���R.Name = "tex�͂���Z���R";
			this.tex�͂���Z���R.Size = new System.Drawing.Size(330, 23);
			this.tex�͂���Z���R.TabIndex = 11;
			this.tex�͂���Z���R.Text = "";
			// 
			// lab�͂���Z��
			// 
			this.lab�͂���Z��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�͂���Z��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�͂���Z��.Location = new System.Drawing.Point(40, 84);
			this.lab�͂���Z��.Name = "lab�͂���Z��";
			this.lab�͂���Z��.Size = new System.Drawing.Size(56, 14);
			this.lab�͂���Z��.TabIndex = 19;
			this.lab�͂���Z��.Text = "�Z��";
			// 
			// tex�͂���X�֔ԍ��Q
			// 
			this.tex�͂���X�֔ԍ��Q.AcceptsTab = true;
			this.tex�͂���X�֔ԍ��Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�͂���X�֔ԍ��Q.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�͂���X�֔ԍ��Q.Location = new System.Drawing.Point(160, 54);
			this.tex�͂���X�֔ԍ��Q.MaxLength = 4;
			this.tex�͂���X�֔ԍ��Q.Name = "tex�͂���X�֔ԍ��Q";
			this.tex�͂���X�֔ԍ��Q.Size = new System.Drawing.Size(40, 23);
			this.tex�͂���X�֔ԍ��Q.TabIndex = 6;
			this.tex�͂���X�֔ԍ��Q.Text = "";
			this.tex�͂���X�֔ԍ��Q.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�͂���X�֔ԍ��Q_KeyDown);
			this.tex�͂���X�֔ԍ��Q.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�͂���X�֔ԍ��Q_KeyPress);
			// 
			// tex�͂���X�֔ԍ��P
			// 
			this.tex�͂���X�֔ԍ��P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�͂���X�֔ԍ��P.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�͂���X�֔ԍ��P.Location = new System.Drawing.Point(110, 54);
			this.tex�͂���X�֔ԍ��P.MaxLength = 3;
			this.tex�͂���X�֔ԍ��P.Name = "tex�͂���X�֔ԍ��P";
			this.tex�͂���X�֔ԍ��P.Size = new System.Drawing.Size(34, 23);
			this.tex�͂���X�֔ԍ��P.TabIndex = 5;
			this.tex�͂���X�֔ԍ��P.Text = "";
			this.tex�͂���X�֔ԍ��P.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�͂���X�֔ԍ��P_KeyPress);
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label8.ForeColor = System.Drawing.Color.LimeGreen;
			this.label8.Location = new System.Drawing.Point(146, 60);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(12, 14);
			this.label8.TabIndex = 17;
			this.label8.Text = "�|";
			// 
			// lab�͂���X�֔ԍ�
			// 
			this.lab�͂���X�֔ԍ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�͂���X�֔ԍ�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�͂���X�֔ԍ�.Location = new System.Drawing.Point(40, 58);
			this.lab�͂���X�֔ԍ�.Name = "lab�͂���X�֔ԍ�";
			this.lab�͂���X�֔ԍ�.Size = new System.Drawing.Size(56, 14);
			this.lab�͂���X�֔ԍ�.TabIndex = 15;
			this.lab�͂���X�֔ԍ�.Text = "�X�֔ԍ�";
			// 
			// tex�͂���d�b�ԍ��R
			// 
			this.tex�͂���d�b�ԍ��R.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�͂���d�b�ԍ��R.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�͂���d�b�ԍ��R.Location = new System.Drawing.Point(238, 28);
			this.tex�͂���d�b�ԍ��R.MaxLength = 4;
			this.tex�͂���d�b�ԍ��R.Name = "tex�͂���d�b�ԍ��R";
			this.tex�͂���d�b�ԍ��R.Size = new System.Drawing.Size(38, 23);
			this.tex�͂���d�b�ԍ��R.TabIndex = 4;
			this.tex�͂���d�b�ԍ��R.Text = "";
			// 
			// tex�͂���d�b�ԍ��Q
			// 
			this.tex�͂���d�b�ԍ��Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�͂���d�b�ԍ��Q.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�͂���d�b�ԍ��Q.Location = new System.Drawing.Point(182, 28);
			this.tex�͂���d�b�ԍ��Q.MaxLength = 4;
			this.tex�͂���d�b�ԍ��Q.Name = "tex�͂���d�b�ԍ��Q";
			this.tex�͂���d�b�ԍ��Q.Size = new System.Drawing.Size(38, 23);
			this.tex�͂���d�b�ԍ��Q.TabIndex = 3;
			this.tex�͂���d�b�ԍ��Q.Text = "";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label6.ForeColor = System.Drawing.Color.LimeGreen;
			this.label6.Location = new System.Drawing.Point(222, 34);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(12, 14);
			this.label6.TabIndex = 13;
			this.label6.Text = "�|";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label5.ForeColor = System.Drawing.Color.LimeGreen;
			this.label5.Location = new System.Drawing.Point(168, 34);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(12, 14);
			this.label5.TabIndex = 11;
			this.label5.Text = "�j";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label4.ForeColor = System.Drawing.Color.LimeGreen;
			this.label4.Location = new System.Drawing.Point(100, 34);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 14);
			this.label4.TabIndex = 10;
			this.label4.Text = "�i";
			// 
			// lab�͂���d�b�ԍ�
			// 
			this.lab�͂���d�b�ԍ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�͂���d�b�ԍ�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�͂���d�b�ԍ�.Location = new System.Drawing.Point(40, 34);
			this.lab�͂���d�b�ԍ�.Name = "lab�͂���d�b�ԍ�";
			this.lab�͂���d�b�ԍ�.Size = new System.Drawing.Size(56, 14);
			this.lab�͂���d�b�ԍ�.TabIndex = 9;
			this.lab�͂���d�b�ԍ�.Text = "�d�b�ԍ�";
			// 
			// lab�͂���R�[�h
			// 
			this.lab�͂���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�͂���R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�͂���R�[�h.Location = new System.Drawing.Point(40, 6);
			this.lab�͂���R�[�h.Name = "lab�͂���R�[�h";
			this.lab�͂���R�[�h.Size = new System.Drawing.Size(56, 26);
			this.lab�͂���R�[�h.TabIndex = 8;
			this.lab�͂���R�[�h.Text = "���͂���R�[�h";
			// 
			// tex�͂���Z���Q
			// 
			this.tex�͂���Z���Q.BackColor = System.Drawing.SystemColors.Window;
			this.tex�͂���Z���Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�͂���Z���Q.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�͂���Z���Q.Location = new System.Drawing.Point(110, 102);
			this.tex�͂���Z���Q.MaxLength = 20;
			this.tex�͂���Z���Q.Name = "tex�͂���Z���Q";
			this.tex�͂���Z���Q.Size = new System.Drawing.Size(330, 23);
			this.tex�͂���Z���Q.TabIndex = 10;
			this.tex�͂���Z���Q.Text = "";
			// 
			// tex�͂���Z���P
			// 
			this.tex�͂���Z���P.BackColor = System.Drawing.SystemColors.Window;
			this.tex�͂���Z���P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�͂���Z���P.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�͂���Z���P.Location = new System.Drawing.Point(110, 80);
			this.tex�͂���Z���P.MaxLength = 20;
			this.tex�͂���Z���P.Name = "tex�͂���Z���P";
			this.tex�͂���Z���P.Size = new System.Drawing.Size(330, 23);
			this.tex�͂���Z���P.TabIndex = 9;
			this.tex�͂���Z���P.Text = "";
			// 
			// btn�͂��挟��
			// 
			this.btn�͂��挟��.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�͂��挟��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�͂��挟��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�͂��挟��.ForeColor = System.Drawing.Color.White;
			this.btn�͂��挟��.Location = new System.Drawing.Point(284, 2);
			this.btn�͂��挟��.Name = "btn�͂��挟��";
			this.btn�͂��挟��.Size = new System.Drawing.Size(66, 22);
			this.btn�͂��挟��.TabIndex = 1;
			this.btn�͂��挟��.TabStop = false;
			this.btn�͂��挟��.Text = "�A�h���X��";
			this.btn�͂��挟��.Click += new System.EventHandler(this.btn�͂��挟��_Click);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Blue;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 221);
			this.label1.TabIndex = 3;
			this.label1.Text = "���͂���";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Honeydew;
			this.panel2.Controls.Add(this.tex�����敔�ۃR�[�h);
			this.panel2.Controls.Add(this.lab������R�[�h);
			this.panel2.Controls.Add(this.tex������R�[�h);
			this.panel2.Controls.Add(this.tex�˗���d�b�ԍ��P);
			this.panel2.Controls.Add(this.tex�˗��吿����);
			this.panel2.Controls.Add(this.label36);
			this.panel2.Controls.Add(this.lab�˗��啔��);
			this.panel2.Controls.Add(this.lab�˗��喼�O);
			this.panel2.Controls.Add(this.lab�˗���Z��);
			this.panel2.Controls.Add(this.lab�˗���X�֔ԍ�);
			this.panel2.Controls.Add(this.label16);
			this.panel2.Controls.Add(this.label17);
			this.panel2.Controls.Add(this.label18);
			this.panel2.Controls.Add(this.lab�˗���d�b�ԍ�);
			this.panel2.Controls.Add(this.tex�˗��啔��);
			this.panel2.Controls.Add(this.tex�˗��喼�O�Q);
			this.panel2.Controls.Add(this.tex�˗��喼�O�P);
			this.panel2.Controls.Add(this.tex�˗���X�֔ԍ��Q);
			this.panel2.Controls.Add(this.tex�˗���X�֔ԍ��P);
			this.panel2.Controls.Add(this.label14);
			this.panel2.Controls.Add(this.tex�˗���d�b�ԍ��R);
			this.panel2.Controls.Add(this.tex�˗���d�b�ԍ��Q);
			this.panel2.Controls.Add(this.lab�˗���R�[�h);
			this.panel2.Controls.Add(this.tex�˗���Z���Q);
			this.panel2.Controls.Add(this.tex�˗���Z���P);
			this.panel2.Controls.Add(this.btn�˗��匟��);
			this.panel2.Controls.Add(this.label21);
			this.panel2.Controls.Add(this.tex�˗���R�[�h);
			this.panel2.Controls.Add(this.lab�˗��吿����);
			this.panel2.Location = new System.Drawing.Point(0, 6);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(448, 194);
			this.panel2.TabIndex = 2;
			// 
			// tex�����敔�ۃR�[�h
			// 
			this.tex�����敔�ۃR�[�h.BackColor = System.Drawing.Color.Honeydew;
			this.tex�����敔�ۃR�[�h.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�����敔�ۃR�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�����敔�ۃR�[�h.Location = new System.Drawing.Point(392, 174);
			this.tex�����敔�ۃR�[�h.Name = "tex�����敔�ۃR�[�h";
			this.tex�����敔�ۃR�[�h.ReadOnly = true;
			this.tex�����敔�ۃR�[�h.Size = new System.Drawing.Size(48, 16);
			this.tex�����敔�ۃR�[�h.TabIndex = 48;
			this.tex�����敔�ۃR�[�h.TabStop = false;
			this.tex�����敔�ۃR�[�h.Text = "";
			// 
			// lab������R�[�h
			// 
			this.lab������R�[�h.BackColor = System.Drawing.Color.Honeydew;
			this.lab������R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab������R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab������R�[�h.Location = new System.Drawing.Point(264, 176);
			this.lab������R�[�h.Name = "lab������R�[�h";
			this.lab������R�[�h.Size = new System.Drawing.Size(28, 14);
			this.lab������R�[�h.TabIndex = 47;
			this.lab������R�[�h.Text = "����";
			// 
			// tex������R�[�h
			// 
			this.tex������R�[�h.BackColor = System.Drawing.Color.Honeydew;
			this.tex������R�[�h.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex������R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex������R�[�h.Location = new System.Drawing.Point(294, 174);
			this.tex������R�[�h.Name = "tex������R�[�h";
			this.tex������R�[�h.ReadOnly = true;
			this.tex������R�[�h.Size = new System.Drawing.Size(96, 16);
			this.tex������R�[�h.TabIndex = 46;
			this.tex������R�[�h.TabStop = false;
			this.tex������R�[�h.Text = "";
			// 
			// tex�˗���d�b�ԍ��P
			// 
			this.tex�˗���d�b�ԍ��P.BackColor = System.Drawing.Color.Honeydew;
			this.tex�˗���d�b�ԍ��P.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�˗���d�b�ԍ��P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗���d�b�ԍ��P.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�˗���d�b�ԍ��P.Location = new System.Drawing.Point(110, 32);
			this.tex�˗���d�b�ԍ��P.MaxLength = 6;
			this.tex�˗���d�b�ԍ��P.Name = "tex�˗���d�b�ԍ��P";
			this.tex�˗���d�b�ԍ��P.ReadOnly = true;
			this.tex�˗���d�b�ԍ��P.Size = new System.Drawing.Size(52, 16);
			this.tex�˗���d�b�ԍ��P.TabIndex = 2;
			this.tex�˗���d�b�ԍ��P.TabStop = false;
			this.tex�˗���d�b�ԍ��P.Text = "";
			// 
			// tex�˗��吿����
			// 
			this.tex�˗��吿����.BackColor = System.Drawing.Color.Honeydew;
			this.tex�˗��吿����.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�˗��吿����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗��吿����.Location = new System.Drawing.Point(100, 175);
			this.tex�˗��吿����.Name = "tex�˗��吿����";
			this.tex�˗��吿����.ReadOnly = true;
			this.tex�˗��吿����.Size = new System.Drawing.Size(162, 16);
			this.tex�˗��吿����.TabIndex = 41;
			this.tex�˗��吿����.TabStop = false;
			this.tex�˗��吿����.Text = "";
			// 
			// label36
			// 
			this.label36.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label36.ForeColor = System.Drawing.Color.Red;
			this.label36.Location = new System.Drawing.Point(26, 8);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(16, 14);
			this.label36.TabIndex = 40;
			this.label36.Text = "��";
			// 
			// lab�˗��啔��
			// 
			this.lab�˗��啔��.BackColor = System.Drawing.Color.Honeydew;
			this.lab�˗��啔��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�˗��啔��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�˗��啔��.Location = new System.Drawing.Point(70, 152);
			this.lab�˗��啔��.Name = "lab�˗��啔��";
			this.lab�˗��啔��.Size = new System.Drawing.Size(36, 14);
			this.lab�˗��啔��.TabIndex = 27;
			this.lab�˗��啔��.Text = "�S���F";
			// 
			// lab�˗��喼�O
			// 
			this.lab�˗��喼�O.BackColor = System.Drawing.Color.Honeydew;
			this.lab�˗��喼�O.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�˗��喼�O.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�˗��喼�O.Location = new System.Drawing.Point(40, 114);
			this.lab�˗��喼�O.Name = "lab�˗��喼�O";
			this.lab�˗��喼�O.Size = new System.Drawing.Size(56, 14);
			this.lab�˗��喼�O.TabIndex = 24;
			this.lab�˗��喼�O.Text = "���O";
			// 
			// lab�˗���Z��
			// 
			this.lab�˗���Z��.BackColor = System.Drawing.Color.Honeydew;
			this.lab�˗���Z��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�˗���Z��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�˗���Z��.Location = new System.Drawing.Point(40, 74);
			this.lab�˗���Z��.Name = "lab�˗���Z��";
			this.lab�˗���Z��.Size = new System.Drawing.Size(56, 14);
			this.lab�˗���Z��.TabIndex = 19;
			this.lab�˗���Z��.Text = "�Z��";
			// 
			// lab�˗���X�֔ԍ�
			// 
			this.lab�˗���X�֔ԍ�.BackColor = System.Drawing.Color.Honeydew;
			this.lab�˗���X�֔ԍ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�˗���X�֔ԍ�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�˗���X�֔ԍ�.Location = new System.Drawing.Point(40, 54);
			this.lab�˗���X�֔ԍ�.Name = "lab�˗���X�֔ԍ�";
			this.lab�˗���X�֔ԍ�.Size = new System.Drawing.Size(56, 14);
			this.lab�˗���X�֔ԍ�.TabIndex = 15;
			this.lab�˗���X�֔ԍ�.Text = "�X�֔ԍ�";
			// 
			// label16
			// 
			this.label16.BackColor = System.Drawing.Color.Honeydew;
			this.label16.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label16.ForeColor = System.Drawing.Color.LimeGreen;
			this.label16.Location = new System.Drawing.Point(210, 34);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(12, 14);
			this.label16.TabIndex = 13;
			this.label16.Text = "�|";
			// 
			// label17
			// 
			this.label17.BackColor = System.Drawing.Color.Honeydew;
			this.label17.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label17.ForeColor = System.Drawing.Color.LimeGreen;
			this.label17.Location = new System.Drawing.Point(160, 34);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(12, 14);
			this.label17.TabIndex = 11;
			this.label17.Text = "�j";
			// 
			// label18
			// 
			this.label18.BackColor = System.Drawing.Color.Honeydew;
			this.label18.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label18.ForeColor = System.Drawing.Color.LimeGreen;
			this.label18.Location = new System.Drawing.Point(100, 34);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(12, 14);
			this.label18.TabIndex = 10;
			this.label18.Text = "�i";
			// 
			// lab�˗���d�b�ԍ�
			// 
			this.lab�˗���d�b�ԍ�.BackColor = System.Drawing.Color.Honeydew;
			this.lab�˗���d�b�ԍ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�˗���d�b�ԍ�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�˗���d�b�ԍ�.Location = new System.Drawing.Point(40, 34);
			this.lab�˗���d�b�ԍ�.Name = "lab�˗���d�b�ԍ�";
			this.lab�˗���d�b�ԍ�.Size = new System.Drawing.Size(56, 14);
			this.lab�˗���d�b�ԍ�.TabIndex = 9;
			this.lab�˗���d�b�ԍ�.Text = "�d�b�ԍ�";
			// 
			// tex�˗��啔��
			// 
			this.tex�˗��啔��.BackColor = System.Drawing.SystemColors.Window;
			this.tex�˗��啔��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗��啔��.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�˗��啔��.Location = new System.Drawing.Point(108, 148);
			this.tex�˗��啔��.MaxLength = 10;
			this.tex�˗��啔��.Name = "tex�˗��啔��";
			this.tex�˗��啔��.Size = new System.Drawing.Size(172, 23);
			this.tex�˗��啔��.TabIndex = 2;
			this.tex�˗��啔��.Text = "";
			// 
			// tex�˗��喼�O�Q
			// 
			this.tex�˗��喼�O�Q.BackColor = System.Drawing.Color.Honeydew;
			this.tex�˗��喼�O�Q.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�˗��喼�O�Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗��喼�O�Q.Location = new System.Drawing.Point(110, 130);
			this.tex�˗��喼�O�Q.MaxLength = 20;
			this.tex�˗��喼�O�Q.Name = "tex�˗��喼�O�Q";
			this.tex�˗��喼�O�Q.ReadOnly = true;
			this.tex�˗��喼�O�Q.Size = new System.Drawing.Size(330, 16);
			this.tex�˗��喼�O�Q.TabIndex = 25;
			this.tex�˗��喼�O�Q.TabStop = false;
			this.tex�˗��喼�O�Q.Text = "";
			// 
			// tex�˗��喼�O�P
			// 
			this.tex�˗��喼�O�P.BackColor = System.Drawing.Color.Honeydew;
			this.tex�˗��喼�O�P.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�˗��喼�O�P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗��喼�O�P.Location = new System.Drawing.Point(110, 112);
			this.tex�˗��喼�O�P.MaxLength = 20;
			this.tex�˗��喼�O�P.Name = "tex�˗��喼�O�P";
			this.tex�˗��喼�O�P.ReadOnly = true;
			this.tex�˗��喼�O�P.Size = new System.Drawing.Size(330, 16);
			this.tex�˗��喼�O�P.TabIndex = 23;
			this.tex�˗��喼�O�P.TabStop = false;
			this.tex�˗��喼�O�P.Text = "";
			// 
			// tex�˗���X�֔ԍ��Q
			// 
			this.tex�˗���X�֔ԍ��Q.BackColor = System.Drawing.Color.Honeydew;
			this.tex�˗���X�֔ԍ��Q.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�˗���X�֔ԍ��Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗���X�֔ԍ��Q.Location = new System.Drawing.Point(154, 52);
			this.tex�˗���X�֔ԍ��Q.MaxLength = 4;
			this.tex�˗���X�֔ԍ��Q.Name = "tex�˗���X�֔ԍ��Q";
			this.tex�˗���X�֔ԍ��Q.ReadOnly = true;
			this.tex�˗���X�֔ԍ��Q.Size = new System.Drawing.Size(36, 16);
			this.tex�˗���X�֔ԍ��Q.TabIndex = 18;
			this.tex�˗���X�֔ԍ��Q.TabStop = false;
			this.tex�˗���X�֔ԍ��Q.Text = "";
			// 
			// tex�˗���X�֔ԍ��P
			// 
			this.tex�˗���X�֔ԍ��P.BackColor = System.Drawing.Color.Honeydew;
			this.tex�˗���X�֔ԍ��P.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�˗���X�֔ԍ��P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗���X�֔ԍ��P.Location = new System.Drawing.Point(110, 52);
			this.tex�˗���X�֔ԍ��P.MaxLength = 3;
			this.tex�˗���X�֔ԍ��P.Name = "tex�˗���X�֔ԍ��P";
			this.tex�˗���X�֔ԍ��P.ReadOnly = true;
			this.tex�˗���X�֔ԍ��P.Size = new System.Drawing.Size(28, 16);
			this.tex�˗���X�֔ԍ��P.TabIndex = 16;
			this.tex�˗���X�֔ԍ��P.TabStop = false;
			this.tex�˗���X�֔ԍ��P.Text = "";
			// 
			// label14
			// 
			this.label14.BackColor = System.Drawing.Color.Honeydew;
			this.label14.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label14.ForeColor = System.Drawing.Color.LimeGreen;
			this.label14.Location = new System.Drawing.Point(138, 54);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(12, 14);
			this.label14.TabIndex = 17;
			this.label14.Text = "�|";
			// 
			// tex�˗���d�b�ԍ��R
			// 
			this.tex�˗���d�b�ԍ��R.BackColor = System.Drawing.Color.Honeydew;
			this.tex�˗���d�b�ԍ��R.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�˗���d�b�ԍ��R.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗���d�b�ԍ��R.Location = new System.Drawing.Point(226, 32);
			this.tex�˗���d�b�ԍ��R.MaxLength = 4;
			this.tex�˗���d�b�ԍ��R.Name = "tex�˗���d�b�ԍ��R";
			this.tex�˗���d�b�ԍ��R.ReadOnly = true;
			this.tex�˗���d�b�ԍ��R.Size = new System.Drawing.Size(36, 16);
			this.tex�˗���d�b�ԍ��R.TabIndex = 14;
			this.tex�˗���d�b�ԍ��R.TabStop = false;
			this.tex�˗���d�b�ԍ��R.Text = "";
			// 
			// tex�˗���d�b�ԍ��Q
			// 
			this.tex�˗���d�b�ԍ��Q.BackColor = System.Drawing.Color.Honeydew;
			this.tex�˗���d�b�ԍ��Q.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�˗���d�b�ԍ��Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗���d�b�ԍ��Q.Location = new System.Drawing.Point(174, 32);
			this.tex�˗���d�b�ԍ��Q.MaxLength = 4;
			this.tex�˗���d�b�ԍ��Q.Name = "tex�˗���d�b�ԍ��Q";
			this.tex�˗���d�b�ԍ��Q.ReadOnly = true;
			this.tex�˗���d�b�ԍ��Q.Size = new System.Drawing.Size(32, 16);
			this.tex�˗���d�b�ԍ��Q.TabIndex = 12;
			this.tex�˗���d�b�ԍ��Q.TabStop = false;
			this.tex�˗���d�b�ԍ��Q.Text = "";
			// 
			// lab�˗���R�[�h
			// 
			this.lab�˗���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�˗���R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�˗���R�[�h.Location = new System.Drawing.Point(40, 4);
			this.lab�˗���R�[�h.Name = "lab�˗���R�[�h";
			this.lab�˗���R�[�h.Size = new System.Drawing.Size(56, 26);
			this.lab�˗���R�[�h.TabIndex = 8;
			this.lab�˗���R�[�h.Text = "���˗���R�[�h";
			// 
			// tex�˗���Z���Q
			// 
			this.tex�˗���Z���Q.BackColor = System.Drawing.Color.Honeydew;
			this.tex�˗���Z���Q.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�˗���Z���Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗���Z���Q.Location = new System.Drawing.Point(110, 92);
			this.tex�˗���Z���Q.MaxLength = 20;
			this.tex�˗���Z���Q.Name = "tex�˗���Z���Q";
			this.tex�˗���Z���Q.ReadOnly = true;
			this.tex�˗���Z���Q.Size = new System.Drawing.Size(330, 16);
			this.tex�˗���Z���Q.TabIndex = 7;
			this.tex�˗���Z���Q.TabStop = false;
			this.tex�˗���Z���Q.Text = "";
			// 
			// tex�˗���Z���P
			// 
			this.tex�˗���Z���P.BackColor = System.Drawing.Color.Honeydew;
			this.tex�˗���Z���P.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�˗���Z���P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗���Z���P.Location = new System.Drawing.Point(110, 74);
			this.tex�˗���Z���P.MaxLength = 20;
			this.tex�˗���Z���P.Name = "tex�˗���Z���P";
			this.tex�˗���Z���P.ReadOnly = true;
			this.tex�˗���Z���P.Size = new System.Drawing.Size(330, 16);
			this.tex�˗���Z���P.TabIndex = 6;
			this.tex�˗���Z���P.TabStop = false;
			this.tex�˗���Z���P.Text = "";
			// 
			// btn�˗��匟��
			// 
			this.btn�˗��匟��.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�˗��匟��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�˗��匟��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�˗��匟��.ForeColor = System.Drawing.Color.White;
			this.btn�˗��匟��.Location = new System.Drawing.Point(284, 4);
			this.btn�˗��匟��.Name = "btn�˗��匟��";
			this.btn�˗��匟��.Size = new System.Drawing.Size(48, 22);
			this.btn�˗��匟��.TabIndex = 1;
			this.btn�˗��匟��.TabStop = false;
			this.btn�˗��匟��.Text = "����";
			this.btn�˗��匟��.Click += new System.EventHandler(this.btn�˗��匟��_Click);
			// 
			// label21
			// 
			this.label21.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label21.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label21.ForeColor = System.Drawing.Color.Blue;
			this.label21.Location = new System.Drawing.Point(0, 0);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(22, 194);
			this.label21.TabIndex = 3;
			this.label21.Text = "���˗���";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tex�˗���R�[�h
			// 
			this.tex�˗���R�[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex�˗���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗���R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�˗���R�[�h.Location = new System.Drawing.Point(110, 4);
			this.tex�˗���R�[�h.MaxLength = 12;
			this.tex�˗���R�[�h.Name = "tex�˗���R�[�h";
			this.tex�˗���R�[�h.Size = new System.Drawing.Size(172, 23);
			this.tex�˗���R�[�h.TabIndex = 0;
			this.tex�˗���R�[�h.Text = "";
			this.tex�˗���R�[�h.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�˗���R�[�h_KeyDown);
			this.tex�˗���R�[�h.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�˗���R�[�h_KeyPress);
			// 
			// lab�˗��吿����
			// 
			this.lab�˗��吿����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�˗��吿����.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�˗��吿����.Location = new System.Drawing.Point(40, 176);
			this.lab�˗��吿����.Name = "lab�˗��吿����";
			this.lab�˗��吿����.Size = new System.Drawing.Size(44, 14);
			this.lab�˗��吿����.TabIndex = 9;
			this.lab�˗��吿����.Text = "������";
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.Honeydew;
			this.panel3.Controls.Add(this.tex�L�����U);
			this.panel3.Controls.Add(this.tex�L�����T);
			this.panel3.Controls.Add(this.tex�L�����S);
			this.panel3.Controls.Add(this.tex�A�����q);
			this.panel3.Controls.Add(this.tex�A�����e);
			this.panel3.Controls.Add(this.tex�L�����R);
			this.panel3.Controls.Add(this.tex�L�����Q);
			this.panel3.Controls.Add(this.tex�L�����P);
			this.panel3.Controls.Add(this.btn�A������);
			this.panel3.Controls.Add(this.tex�A���R�[�h�e);
			this.panel3.Controls.Add(this.lab�A���R�[�h);
			this.panel3.Controls.Add(this.lab�A���w��);
			this.panel3.Controls.Add(this.btn�L������);
			this.panel3.Controls.Add(this.tex�L���R�[�h);
			this.panel3.Controls.Add(this.lab�L���R�[�h);
			this.panel3.Controls.Add(this.lab�L��);
			this.panel3.Controls.Add(this.tex�A���R�[�h�q);
			this.panel3.Location = new System.Drawing.Point(1, 6);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(322, 252);
			this.panel3.TabIndex = 3;
			// 
			// tex�L�����U
			// 
			this.tex�L�����U.BackColor = System.Drawing.SystemColors.Window;
			this.tex�L�����U.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�L�����U.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�L�����U.Location = new System.Drawing.Point(74, 222);
			this.tex�L�����U.MaxLength = 30;
			this.tex�L�����U.Name = "tex�L�����U";
			this.tex�L�����U.Size = new System.Drawing.Size(246, 23);
			this.tex�L�����U.TabIndex = 37;
			this.tex�L�����U.Text = "";
			// 
			// tex�L�����T
			// 
			this.tex�L�����T.BackColor = System.Drawing.SystemColors.Window;
			this.tex�L�����T.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�L�����T.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�L�����T.Location = new System.Drawing.Point(74, 198);
			this.tex�L�����T.MaxLength = 30;
			this.tex�L�����T.Name = "tex�L�����T";
			this.tex�L�����T.Size = new System.Drawing.Size(246, 23);
			this.tex�L�����T.TabIndex = 36;
			this.tex�L�����T.Text = "";
			// 
			// tex�L�����S
			// 
			this.tex�L�����S.BackColor = System.Drawing.SystemColors.Window;
			this.tex�L�����S.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�L�����S.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�L�����S.Location = new System.Drawing.Point(74, 174);
			this.tex�L�����S.MaxLength = 30;
			this.tex�L�����S.Name = "tex�L�����S";
			this.tex�L�����S.Size = new System.Drawing.Size(246, 23);
			this.tex�L�����S.TabIndex = 35;
			this.tex�L�����S.Text = "";
			// 
			// tex�A�����q
			// 
			this.tex�A�����q.BackColor = System.Drawing.Color.Honeydew;
			this.tex�A�����q.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�A�����q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�A�����q.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�A�����q.Location = new System.Drawing.Point(74, 54);
			this.tex�A�����q.Name = "tex�A�����q";
			this.tex�A�����q.ReadOnly = true;
			this.tex�A�����q.Size = new System.Drawing.Size(246, 16);
			this.tex�A�����q.TabIndex = 3;
			this.tex�A�����q.TabStop = false;
			this.tex�A�����q.Text = "";
			// 
			// tex�A�����e
			// 
			this.tex�A�����e.BackColor = System.Drawing.Color.Honeydew;
			this.tex�A�����e.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�A�����e.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�A�����e.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�A�����e.Location = new System.Drawing.Point(74, 30);
			this.tex�A�����e.Name = "tex�A�����e";
			this.tex�A�����e.ReadOnly = true;
			this.tex�A�����e.Size = new System.Drawing.Size(246, 16);
			this.tex�A�����e.TabIndex = 1;
			this.tex�A�����e.TabStop = false;
			this.tex�A�����e.Text = "";
			// 
			// tex�L�����R
			// 
			this.tex�L�����R.BackColor = System.Drawing.SystemColors.Window;
			this.tex�L�����R.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�L�����R.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�L�����R.Location = new System.Drawing.Point(74, 150);
			this.tex�L�����R.MaxLength = 30;
			this.tex�L�����R.Name = "tex�L�����R";
			this.tex�L�����R.Size = new System.Drawing.Size(246, 23);
			this.tex�L�����R.TabIndex = 8;
			this.tex�L�����R.Text = "";
			// 
			// tex�L�����Q
			// 
			this.tex�L�����Q.BackColor = System.Drawing.SystemColors.Window;
			this.tex�L�����Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�L�����Q.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�L�����Q.Location = new System.Drawing.Point(74, 126);
			this.tex�L�����Q.MaxLength = 30;
			this.tex�L�����Q.Name = "tex�L�����Q";
			this.tex�L�����Q.Size = new System.Drawing.Size(246, 23);
			this.tex�L�����Q.TabIndex = 7;
			this.tex�L�����Q.Text = "";
			// 
			// tex�L�����P
			// 
			this.tex�L�����P.BackColor = System.Drawing.SystemColors.Window;
			this.tex�L�����P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�L�����P.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�L�����P.Location = new System.Drawing.Point(74, 102);
			this.tex�L�����P.MaxLength = 30;
			this.tex�L�����P.Name = "tex�L�����P";
			this.tex�L�����P.Size = new System.Drawing.Size(246, 23);
			this.tex�L�����P.TabIndex = 6;
			this.tex�L�����P.Text = "";
			// 
			// btn�A������
			// 
			this.btn�A������.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�A������.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�A������.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�A������.ForeColor = System.Drawing.Color.White;
			this.btn�A������.Location = new System.Drawing.Point(74, 4);
			this.btn�A������.Name = "btn�A������";
			this.btn�A������.Size = new System.Drawing.Size(48, 22);
			this.btn�A������.TabIndex = 1;
			this.btn�A������.TabStop = false;
			this.btn�A������.Text = "����";
			this.btn�A������.Click += new System.EventHandler(this.btn�A������_Click);
			// 
			// tex�A���R�[�h�e
			// 
			this.tex�A���R�[�h�e.BackColor = System.Drawing.SystemColors.Window;
			this.tex�A���R�[�h�e.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�A���R�[�h�e.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�A���R�[�h�e.Location = new System.Drawing.Point(30, 26);
			this.tex�A���R�[�h�e.MaxLength = 4;
			this.tex�A���R�[�h�e.Name = "tex�A���R�[�h�e";
			this.tex�A���R�[�h�e.Size = new System.Drawing.Size(42, 23);
			this.tex�A���R�[�h�e.TabIndex = 0;
			this.tex�A���R�[�h�e.Text = "";
			this.tex�A���R�[�h�e.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�A���R�[�h�e_KeyDown);
			this.tex�A���R�[�h�e.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�A���R�[�h�e_KeyPress);
			// 
			// lab�A���R�[�h
			// 
			this.lab�A���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�A���R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�A���R�[�h.Location = new System.Drawing.Point(34, 8);
			this.lab�A���R�[�h.Name = "lab�A���R�[�h";
			this.lab�A���R�[�h.Size = new System.Drawing.Size(34, 14);
			this.lab�A���R�[�h.TabIndex = 34;
			this.lab�A���R�[�h.Text = "�R�[�h";
			// 
			// lab�A���w��
			// 
			this.lab�A���w��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�A���w��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�A���w��.ForeColor = System.Drawing.Color.Blue;
			this.lab�A���w��.Location = new System.Drawing.Point(8, 4);
			this.lab�A���w��.Name = "lab�A���w��";
			this.lab�A���w��.Size = new System.Drawing.Size(18, 70);
			this.lab�A���w��.TabIndex = 32;
			this.lab�A���w��.Text = "�A�����i";
			this.lab�A���w��.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn�L������
			// 
			this.btn�L������.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�L������.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�L������.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�L������.ForeColor = System.Drawing.Color.White;
			this.btn�L������.Location = new System.Drawing.Point(74, 78);
			this.btn�L������.Name = "btn�L������";
			this.btn�L������.Size = new System.Drawing.Size(48, 22);
			this.btn�L������.TabIndex = 5;
			this.btn�L������.TabStop = false;
			this.btn�L������.Text = "����";
			this.btn�L������.Click += new System.EventHandler(this.btn�L������_Click);
			// 
			// tex�L���R�[�h
			// 
			this.tex�L���R�[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex�L���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�L���R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�L���R�[�h.Location = new System.Drawing.Point(30, 102);
			this.tex�L���R�[�h.MaxLength = 4;
			this.tex�L���R�[�h.Name = "tex�L���R�[�h";
			this.tex�L���R�[�h.Size = new System.Drawing.Size(42, 23);
			this.tex�L���R�[�h.TabIndex = 4;
			this.tex�L���R�[�h.Text = "";
			this.tex�L���R�[�h.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�L���R�[�h_KeyDown);
			this.tex�L���R�[�h.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�L���R�[�h_KeyPress);
			// 
			// lab�L���R�[�h
			// 
			this.lab�L���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�L���R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�L���R�[�h.Location = new System.Drawing.Point(34, 82);
			this.lab�L���R�[�h.Name = "lab�L���R�[�h";
			this.lab�L���R�[�h.Size = new System.Drawing.Size(34, 14);
			this.lab�L���R�[�h.TabIndex = 11;
			this.lab�L���R�[�h.Text = "�R�[�h";
			// 
			// lab�L��
			// 
			this.lab�L��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�L��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�L��.ForeColor = System.Drawing.Color.Blue;
			this.lab�L��.Location = new System.Drawing.Point(8, 78);
			this.lab�L��.Name = "lab�L��";
			this.lab�L��.Size = new System.Drawing.Size(18, 168);
			this.lab�L��.TabIndex = 9;
			this.lab�L��.Text = "�L���E�i��";
			this.lab�L��.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tex�A���R�[�h�q
			// 
			this.tex�A���R�[�h�q.BackColor = System.Drawing.SystemColors.Window;
			this.tex�A���R�[�h�q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�A���R�[�h�q.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�A���R�[�h�q.Location = new System.Drawing.Point(30, 50);
			this.tex�A���R�[�h�q.MaxLength = 4;
			this.tex�A���R�[�h�q.Name = "tex�A���R�[�h�q";
			this.tex�A���R�[�h�q.Size = new System.Drawing.Size(42, 23);
			this.tex�A���R�[�h�q.TabIndex = 2;
			this.tex�A���R�[�h�q.Text = "";
			this.tex�A���R�[�h�q.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�A���R�[�h�q_KeyDown);
			this.tex�A���R�[�h�q.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�A���R�[�h�q_KeyPress);
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.Honeydew;
			this.panel4.Controls.Add(this.lab�d��);
			this.panel4.Controls.Add(this.nUD�d��);
			this.panel4.Controls.Add(this.nUD�ی����z);
			this.panel4.Controls.Add(this.lab�ی����z);
			this.panel4.Controls.Add(this.nUD��);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Controls.Add(this.lab��);
			this.panel4.Location = new System.Drawing.Point(1, 6);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(322, 76);
			this.panel4.TabIndex = 4;
			// 
			// lab�d��
			// 
			this.lab�d��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�d��.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�d��.ForeColor = System.Drawing.Color.Blue;
			this.lab�d��.Location = new System.Drawing.Point(108, 4);
			this.lab�d��.Name = "lab�d��";
			this.lab�d��.Size = new System.Drawing.Size(100, 32);
			this.lab�d��.TabIndex = 54;
			this.lab�d��.Text = "�d��(kg)";
			this.lab�d��.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lab�d��.Visible = false;
			// 
			// nUD�d��
			// 
			this.nUD�d��.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.nUD�d��.Location = new System.Drawing.Point(134, 40);
			this.nUD�d��.Maximum = new System.Decimal(new int[] {
																  9999,
																  0,
																  0,
																  0});
			this.nUD�d��.Name = "nUD�d��";
			this.nUD�d��.Size = new System.Drawing.Size(74, 31);
			this.nUD�d��.TabIndex = 1;
			this.nUD�d��.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nUD�d��.ThousandsSeparator = true;
			this.nUD�d��.Visible = false;
			this.nUD�d��.Enter += new System.EventHandler(this.nUD�d��_Enter);
			// 
			// nUD�ی����z
			// 
			this.nUD�ی����z.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.nUD�ی����z.Location = new System.Drawing.Point(238, 40);
			this.nUD�ی����z.Maximum = new System.Decimal(new int[] {
																	9999,
																	0,
																	0,
																	0});
			this.nUD�ی����z.Name = "nUD�ی����z";
			this.nUD�ی����z.Size = new System.Drawing.Size(74, 31);
			this.nUD�ی����z.TabIndex = 2;
			this.nUD�ی����z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nUD�ی����z.ThousandsSeparator = true;
			this.nUD�ی����z.Enter += new System.EventHandler(this.nUD�ی����z_Enter);
			// 
			// lab�ی����z
			// 
			this.lab�ی����z.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�ی����z.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�ی����z.ForeColor = System.Drawing.Color.Blue;
			this.lab�ی����z.Location = new System.Drawing.Point(212, 4);
			this.lab�ی����z.Name = "lab�ی����z";
			this.lab�ی����z.Size = new System.Drawing.Size(100, 32);
			this.lab�ی����z.TabIndex = 52;
			this.lab�ی����z.Text = "�ی����z�i���~�j";
			this.lab�ی����z.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nUD��
			// 
			this.nUD��.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.nUD��.Location = new System.Drawing.Point(60, 40);
			this.nUD��.Maximum = new System.Decimal(new int[] {
																  99,
																  0,
																  0,
																  0});
			this.nUD��.Name = "nUD��";
			this.nUD��.Size = new System.Drawing.Size(44, 31);
			this.nUD��.TabIndex = 0;
			this.nUD��.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nUD��.ThousandsSeparator = true;
			this.nUD��.Enter += new System.EventHandler(this.nUD��_Enter);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label2.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(26, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(14, 16);
			this.label2.TabIndex = 37;
			this.label2.Text = "��";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lab��
			// 
			this.lab��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab��.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab��.ForeColor = System.Drawing.Color.Blue;
			this.lab��.Location = new System.Drawing.Point(4, 4);
			this.lab��.Name = "lab��";
			this.lab��.Size = new System.Drawing.Size(100, 32);
			this.lab��.TabIndex = 4;
			this.lab��.Text = "��";
			this.lab��.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.Honeydew;
			this.panel5.Controls.Add(this.nUD�o�^�ԍ�);
			this.panel5.Controls.Add(this.lab�o�^�ԍ�);
			this.panel5.Controls.Add(this.tex���^��);
			this.panel5.Controls.Add(this.lab���^��);
			this.panel5.Location = new System.Drawing.Point(1, 6);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(424, 52);
			this.panel5.TabIndex = 0;
			// 
			// nUD�o�^�ԍ�
			// 
			this.nUD�o�^�ԍ�.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.nUD�o�^�ԍ�.Location = new System.Drawing.Point(88, 28);
			this.nUD�o�^�ԍ�.Maximum = new System.Decimal(new int[] {
																	99,
																	0,
																	0,
																	0});
			this.nUD�o�^�ԍ�.Name = "nUD�o�^�ԍ�";
			this.nUD�o�^�ԍ�.Size = new System.Drawing.Size(44, 23);
			this.nUD�o�^�ԍ�.TabIndex = 1;
			this.nUD�o�^�ԍ�.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nUD�o�^�ԍ�.Enter += new System.EventHandler(this.nUD�o�^�ԍ�_Enter);
			// 
			// lab�o�^�ԍ�
			// 
			this.lab�o�^�ԍ�.BackColor = System.Drawing.Color.Honeydew;
			this.lab�o�^�ԍ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�o�^�ԍ�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�o�^�ԍ�.Location = new System.Drawing.Point(6, 31);
			this.lab�o�^�ԍ�.Name = "lab�o�^�ԍ�";
			this.lab�o�^�ԍ�.Size = new System.Drawing.Size(72, 14);
			this.lab�o�^�ԍ�.TabIndex = 8;
			this.lab�o�^�ԍ�.Text = "�o�^�ԍ�";
			// 
			// tex���^��
			// 
			this.tex���^��.BackColor = System.Drawing.SystemColors.Window;
			this.tex���^��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���^��.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex���^��.Location = new System.Drawing.Point(88, 2);
			this.tex���^��.MaxLength = 50;
			this.tex���^��.Name = "tex���^��";
			this.tex���^��.Size = new System.Drawing.Size(228, 23);
			this.tex���^��.TabIndex = 0;
			this.tex���^��.Text = "";
			// 
			// lab���^��
			// 
			this.lab���^��.BackColor = System.Drawing.Color.Honeydew;
			this.lab���^��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���^��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���^��.Location = new System.Drawing.Point(6, 4);
			this.lab���^��.Name = "lab���^��";
			this.lab���^��.Size = new System.Drawing.Size(72, 16);
			this.lab���^��.TabIndex = 6;
			this.lab���^��.Text = "����";
			// 
			// btn�A�C�R��
			// 
			this.btn�A�C�R��.BackColor = System.Drawing.Color.White;
			this.btn�A�C�R��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�A�C�R��.Location = new System.Drawing.Point(10, 22);
			this.btn�A�C�R��.Name = "btn�A�C�R��";
			this.btn�A�C�R��.Size = new System.Drawing.Size(64, 64);
			this.btn�A�C�R��.TabIndex = 1;
			this.btn�A�C�R��.Tag = "";
			this.btn�A�C�R��.Click += new System.EventHandler(this.btn�A�C�R��_Click);
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
			this.panel7.Controls.Add(this.lab���^�o�^�^�C�g��);
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
			// lab���^�o�^�^�C�g��
			// 
			this.lab���^�o�^�^�C�g��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab���^�o�^�^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���^�o�^�^�C�g��.ForeColor = System.Drawing.Color.White;
			this.lab���^�o�^�^�C�g��.Location = new System.Drawing.Point(12, 2);
			this.lab���^�o�^�^�C�g��.Name = "lab���^�o�^�^�C�g��";
			this.lab���^�o�^�^�C�g��.Size = new System.Drawing.Size(264, 24);
			this.lab���^�o�^�^�C�g��.TabIndex = 0;
			this.lab���^�o�^�^�C�g��.Text = "���C�u�����o�^";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn�폜);
			this.panel8.Controls.Add(this.btn���);
			this.panel8.Controls.Add(this.btn�X�V);
			this.panel8.Controls.Add(this.tex���b�Z�[�W);
			this.panel8.Controls.Add(this.btn����);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 6;
			// 
			// btn�폜
			// 
			this.btn�폜.ForeColor = System.Drawing.Color.Blue;
			this.btn�폜.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�폜.Location = new System.Drawing.Point(322, 6);
			this.btn�폜.Name = "btn�폜";
			this.btn�폜.Size = new System.Drawing.Size(62, 48);
			this.btn�폜.TabIndex = 3;
			this.btn�폜.Text = "�폜";
			this.btn�폜.Click += new System.EventHandler(this.btn�폜_Click);
			// 
			// btn���
			// 
			this.btn���.ForeColor = System.Drawing.Color.Blue;
			this.btn���.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn���.Location = new System.Drawing.Point(252, 6);
			this.btn���.Name = "btn���";
			this.btn���.Size = new System.Drawing.Size(62, 48);
			this.btn���.TabIndex = 2;
			this.btn���.Text = "���";
			this.btn���.Click += new System.EventHandler(this.btn���_Click);
			// 
			// btn�X�V
			// 
			this.btn�X�V.ForeColor = System.Drawing.Color.Blue;
			this.btn�X�V.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�X�V.Location = new System.Drawing.Point(98, 6);
			this.btn�X�V.Name = "btn�X�V";
			this.btn�X�V.Size = new System.Drawing.Size(62, 48);
			this.btn�X�V.TabIndex = 1;
			this.btn�X�V.Text = "�ۑ�";
			this.btn�X�V.Click += new System.EventHandler(this.btn�X�V_Click);
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
			// panel9
			// 
			this.panel9.BackColor = System.Drawing.Color.Honeydew;
			this.panel9.Controls.Add(this.lab�A�C�R���ݒ�);
			this.panel9.Controls.Add(this.btn�A�C�R��);
			this.panel9.Location = new System.Drawing.Point(1, 6);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(322, 92);
			this.panel9.TabIndex = 5;
			// 
			// lab�A�C�R���ݒ�
			// 
			this.lab�A�C�R���ݒ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�A�C�R���ݒ�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�A�C�R���ݒ�.Location = new System.Drawing.Point(8, 6);
			this.lab�A�C�R���ݒ�.Name = "lab�A�C�R���ݒ�";
			this.lab�A�C�R���ݒ�.Size = new System.Drawing.Size(76, 14);
			this.lab�A�C�R���ݒ�.TabIndex = 10;
			this.lab�A�C�R���ݒ�.Text = "�A�C�R���ݒ�";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel5);
			this.groupBox1.Location = new System.Drawing.Point(32, 50);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(428, 60);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel1);
			this.groupBox2.Location = new System.Drawing.Point(10, 106);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(450, 210);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.panel2);
			this.groupBox3.Location = new System.Drawing.Point(10, 312);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(450, 202);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.panel9);
			this.groupBox4.Location = new System.Drawing.Point(462, 414);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(326, 100);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.panel4);
			this.groupBox5.Location = new System.Drawing.Point(462, 334);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(326, 84);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.panel3);
			this.groupBox6.Location = new System.Drawing.Point(462, 78);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(326, 260);
			this.groupBox6.TabIndex = 3;
			this.groupBox6.TabStop = false;
			// 
			// ���^�o�^
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 580);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox3);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "���^�o�^";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 ���C�u�����o�^";
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX START
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.On�G���^�[�ړ�);
            //this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.On�G���^�[�L�����Z��);
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX END
            this.Load += new System.EventHandler(this.Form1_Load);
			this.Closed += new System.EventHandler(this.���^�o�^_Closed);
			this.Activated += new System.EventHandler(this.���^�o�^_Activated);
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nUD�d��)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD�ی����z)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD��)).EndInit();
			this.panel5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nUD�o�^�ԍ�)).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
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
			// �w�b�_�[���ڂ̐ݒ�
			tex���q�l��.Text = gs���p�Җ�;
			tex���p����.Text = gs����b�c + " " + gs���喼;

			// �����̏����ݒ�
			lab����.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled = true;

// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
			Font fGothic = new System.Drawing.Font("MS Gothic"
							, 12F
							, System.Drawing.FontStyle.Regular
							, System.Drawing.GraphicsUnit.Point
							, ((System.Byte)(128))
							);
			tex�͂���Z���P.Font = fGothic;
			tex�͂���Z���Q.Font = fGothic;
			tex�͂���Z���R.Font = fGothic;
			tex�͂��於�O�P.Font = fGothic;
			tex�͂��於�O�Q.Font = fGothic;
			tex�˗���Z���P.Font = fGothic;
			tex�˗���Z���Q.Font = fGothic;
			tex�˗��喼�O�P.Font = fGothic;
			tex�˗��喼�O�Q.Font = fGothic;
			tex�˗��啔��.Font   = fGothic;
			tex�L�����P.Font     = fGothic;
			tex�L�����Q.Font     = fGothic;
			tex�L�����R.Font     = fGothic;
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
			tex�L�����S.Font     = fGothic;
			tex�L�����T.Font     = fGothic;
			tex�L�����U.Font     = fGothic;
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END

			// �C���[�W�̐ݒ�
			�A�C�R���C���[�W�̏�����();

// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX START
			nUD�ی����z.Minimum =  0;
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) START
//			nUD�ی����z.Maximum = 30;
			nUD�ی����z.Maximum = gl�ی����z���;
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) END
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX END

// DEL 2005.06.06 ���s�j�ɉ� ��ʐ��䍀�ڒǉ� START
// ADD 2005.05.17 ���s�j�����J �ː����d�ʂ� START
//			��ʐ��䌟��();
//			if(i�ː��e�f == 0)
//			{
//				lab�d��.Text = "�ː�";
//				nUD�d��.Maximum = 999;
//			}
//			else
//			{
//				lab�d��.Text = "�d��(kg)";
//				nUD�d��.Maximum = 9999;
//			}
// ADD 2005.05.17 ���s�j�����J �ː����d�ʂ� END
// DEL 2005.06.06 ���s�j�ɉ� ��ʐ��䍀�ڒǉ� END
// ADD 2005.06.01 ���s�j�ɉ� ��ʐ��䍀�ڒǉ� START
			��ʐ��䌟��();
// ADD 2005.06.01 ���s�j�ɉ� ��ʐ��䍀�ڒǉ� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
			if(gs�d�ʓ��͐��� == "1"){
				lab�d��.Visible = true;
				nUD�d��.Visible = true;
			}else{
				lab�d��.Visible = false;
				nUD�d��.Visible = false;
			}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� START
			s�C���O_�˗���b�c = "";
			s�C���O_������b�c = "";
			s�C���O_�����敔�� = "";
			s�C���O_�����於   = "";
			s�C���O_��       = "";
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� END

			if(i���^�m�n > 0)
			{
				// ���^�ꗗ����J���ꂽ�ꍇ�i�X�V���[�h�j
				b�X�V�e�f           = true;
				btn�폜.Visible     = true;
				tex���^��.Text      = s���^����;
				nUD�o�^�ԍ�.Value   = i���^�m�n;
				nUD�o�^�ԍ�.Enabled = false;
				nUD�o�^�ԍ�.TabStop = false;
				���^����();
				tex�͂���R�[�h.Focus();
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� START
				s�C���O_�˗���b�c = tex�˗���R�[�h.Text.TrimEnd();
				s�C���O_������b�c = tex������R�[�h.Text.TrimEnd();
				s�C���O_�����敔�� = tex�����敔�ۃR�[�h.Text.TrimEnd();
				s�C���O_�����於   = tex�˗��吿����.Text.TrimEnd();
				s�C���O_��       = nUD��.Text.TrimEnd();
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� END
			}else{
				// ���^�ꗗ����J���ꂽ�ꍇ�i�ǉ����[�h�j
				// �Ɖ�ꗗ����J���ꂽ�ꍇ�i�ǉ����[�h�j
				b�X�V�e�f           = false;
				btn�폜.Visible     = false;
				tex���^��.Text      = "";
				nUD�o�^�ԍ�.Value   = 0;
				nUD�o�^�ԍ�.Enabled = true;
				nUD�o�^�ԍ�.TabStop = true;
				if(s�o�^��.Length > 0 && s�W���[�i���m�n.Length > 0)
				{
					// �Ɖ�ꗗ����J���ꂽ�ꍇ�i�ǉ����[�h�j
					�o�׌���();
				}
				else
				{
					�A�����i���d�ʐ���();
				}
//				else
//				{
//					tex�˗���R�[�h.Text = gs�ב��l�b�c;
//					s�˗���b�c          = gs�ב��l�b�c;
//					if(s�˗���b�c.Length > 0) �˗��匟��();
//				}
				���^�ԍ��ݒ�();
				tex���^��.Focus();
			}
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� START
			if(tex�͂���Z���P.Text.Trim().Equals("�����x�X�~�߁���"))
			{
				// �x�X�~�߂������ꍇ
				tex�͂���X�֔ԍ��P.Enabled = false; // �͂���X�֔ԍ��P
				tex�͂���X�֔ԍ��Q.Enabled = false; // �͂���X�֔ԍ��Q
				tex�͂���Z���P.Enabled = false; // �͂���Z���P
				tex�͂���Z���Q.Enabled = false; // �͂���Z���Q
				tex�͂���Z���R.Enabled = false; // �͂���Z���R
				btn�x�X�~��.Visible = false;
				btn�x�X�~��.Enabled = false;
				btn�x�X�~�߉���.Visible = true;
				btn�x�X�~�߉���.Enabled = true;
			}
			else
			{
				// ����ȊO�̏ꍇ
				btn�x�X�~��.Visible = true;
				btn�x�X�~��.Enabled = true;
				btn�x�X�~�߉���.Visible = false;
				btn�x�X�~�߉���.Enabled = false;
			}
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� END
		}
// ADD 2005.06.10 ���s�j�ɉ� ��ʐ��䍀�ڒǉ� START
		private void ��ʐ��䌟��()
		{
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
//			Cursor = System.Windows.Forms.Cursors.AppStarting;
//			string[] sList = {""};
//			try
//			{
//				tex���b�Z�[�W.Text = "�������D�D�D";
//				if(sv_init == null) sv_init = new is2init.Service1();
//				sList = sv_init.Get_seigyo(gsa���[�U,gs����b�c,gs����b�c);
//			}
//			catch (System.Net.WebException)
//			{
//				sList[0] = gs�ʐM�G���[;
//				return;
//			}
//			catch (Exception ex)
//			{
//				sList[0] = "�ʐM�G���[�F" + ex.Message;
//				return;
//			}
//			// �J�[�\�����f�t�H���g�ɖ߂�
//			Cursor = System.Windows.Forms.Cursors.Default;
			string[] sList = gs�I�v�V����;
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� END

			tex���b�Z�[�W.Text = "";

			if(sList[0].Length == 4)
			{
				bool bRet;
				bRet = ��ʐ���ݒ�(sList[1]);
				tex�͂���Z���Q.TabStop = bRet;
				bRet = ��ʐ���ݒ�(sList[2]);
				tex�͂���Z���R.TabStop = bRet;
				bRet = ��ʐ���ݒ�(sList[3]);
				tex�͂��於�O�Q.TabStop = bRet;
				bRet = ��ʐ���ݒ�(sList[4]);
				tex�˗��啔��.TabStop = bRet;
//				bRet = ��ʐ���ݒ�(sList[5]);
//				tex���q�l�Ǘ��ԍ�.TabStop = bRet;
				bRet = ��ʐ���ݒ�(sList[6]);
				tex�A���R�[�h�e.TabStop = bRet;
				tex�A���R�[�h�q.TabStop = bRet;
// MOD 2011.08.05 ���s�j���� �L���s�̒ǉ��i�R�s�E�U�s�֑ؑΉ��j START
//				bRet = ��ʐ���ݒ�(sList[7]);
//				tex�L���R�[�h.TabStop = bRet;
//				tex�L�����P.TabStop = bRet;
//				tex�L�����Q.TabStop = bRet;
//				tex�L�����R.TabStop = bRet;
//// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
//				tex�L�����S.TabStop = bRet;
//				tex�L�����T.TabStop = bRet;
//				tex�L�����U.TabStop = bRet;
//// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
// MOD 2011.08.05 ���s�j���� �L���s�̒ǉ��i�R�s�E�U�s�֑ؑΉ��j END
				bRet = ��ʐ���ݒ�(sList[8]);
				nUD�d��.TabStop = bRet;
				bRet = ��ʐ���ݒ�(sList[9]);
				if(bRet)
				{
					i�ː��e�f = 1;
					i�ː��ێ� = 1;
					lab�d��.Text = "�d��(kg)";
					nUD�d��.Maximum = 9999;
				}
				else
				{
					i�ː��e�f = 0;
					i�ː��ێ� = 0;
					lab�d��.Text = "�ː�";
					nUD�d��.Maximum = 999;
				}
				bRet = ��ʐ���ݒ�(sList[10]);
				nUD�ی����z.TabStop = bRet;
// ADD 2009.02.06 ���s�j���؁@ �G���g���I�v�V�����̍��ڒǉ� START
				bRet = ��ʐ���ݒ�(sList[11]);
				tex�˗���R�[�h.TabStop = bRet;
// ADD 2009.02.06 ���s�j���؁@ �G���g���I�v�V�����̍��ڒǉ� END
// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� START
				��ʐ���ݒ�Q(tex�͂���Z���Q, sList[1]);
				��ʐ���ݒ�Q(tex�͂���Z���R, sList[2]);
				��ʐ���ݒ�Q(tex�͂��於�O�Q, sList[3]);
				��ʐ���ݒ�Q(tex�˗��啔��, sList[4]);
				// 5:���q�l�Ǘ��ԍ�
				// �A�����i
				��ʐ���ݒ�Q(tex�A���R�[�h�e, sList[6]);
				��ʐ���ݒ�Q(tex�A���R�[�h�q, sList[6]);
				// �L���E�i��
// MOD 2011.08.05 ���s�j���� �L���s�̒ǉ��i�R�s�E�U�s�֑ؑΉ��j START
//				��ʐ���ݒ�Q(tex�L���R�[�h, sList[7]);
//				��ʐ���ݒ�Q(tex�L�����P, sList[7]);
//				��ʐ���ݒ�Q(tex�L�����Q, sList[7]);
//				��ʐ���ݒ�Q(tex�L�����R, sList[7]);
//				��ʐ���ݒ�Q(tex�L�����S, sList[7]);
//				��ʐ���ݒ�Q(tex�L�����T, sList[7]);
//				��ʐ���ݒ�Q(tex�L�����U, sList[7]);
				��ʐ���ݒ�R(tex�L���R�[�h, sList[7], "029");
				��ʐ���ݒ�R(tex�L�����P, sList[7], "029");
				��ʐ���ݒ�R(tex�L�����Q, sList[7], "029");
				��ʐ���ݒ�R(tex�L�����R, sList[7], "029");
				��ʐ���ݒ�R(tex�L�����S, sList[7], "09");
				��ʐ���ݒ�R(tex�L�����T, sList[7], "09");
				��ʐ���ݒ�R(tex�L�����U, sList[7], "09");
// MOD 2011.08.05 ���s�j���� �L���s�̒ǉ��i�R�s�E�U�s�֑ؑΉ��j END
				��ʐ���ݒ�Q(nUD�d��, sList[8]);
				s��ʐ���_�d��          = sList[8];
				// 9:�d�ʓ��͌`���F�d�� or �ː�
				��ʐ���ݒ�Q(nUD�ی����z, sList[10]);
				��ʐ���ݒ�Q(tex�˗���R�[�h, sList[11]);
// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� END
			}
			else
			{
				tex���b�Z�[�W.Text = sList[0];
				�r�[�v��();
			}
			return;
		}
		private bool ��ʐ���ݒ�(string sCode)
		{
			bool bRet;
			if(sCode.Equals("9"))
			{
				bRet = true;
			}
			else
			{
				if(sCode.Equals("0"))
					bRet = true;
				else
					bRet = false;
			}
			return bRet;
		}
// ADD 2005.06.10 ���s�j�ɉ� ��ʐ��䍀�ڒǉ� END
// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� START
		private void ��ʐ���ݒ�Q(Control cntl, string sCode)
		{
			cntl.Enabled = ��ʐ���ݒ�(sCode);
			if(cntl.Enabled){
				cntl.BackColor = System.Drawing.SystemColors.Window;
			}else{
				cntl.BackColor = System.Drawing.SystemColors.InactiveBorder;
			}
		}
// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� END
// MOD 2011.08.05 ���s�j���� �L���s�̒ǉ��i�R�s�E�U�s�֑ؑΉ��j START
		private void ��ʐ���ݒ�R(Control cntl, string sCode, string s�L������)
		{
			if(s�L������.IndexOf(sCode) == -1){
				cntl.TabStop = false;
				cntl.Enabled = false;
			}else{
				cntl.TabStop = true;
				cntl.Enabled = true;
			}
			if(cntl.Enabled){
				cntl.BackColor = System.Drawing.SystemColors.Window;
			}else{
				cntl.BackColor = System.Drawing.SystemColors.InactiveBorder;
			}
		}
// MOD 2011.08.05 ���s�j���� �L���s�̒ǉ��i�R�s�E�U�s�֑ؑΉ��j END

		private void ���^�ԍ��ݒ�()
		{
			// ����ň�ԑ傫�����^�ԍ����擾����;
			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sList = {""};
			try
			{
// MOD 2009.09.09 ���s�j���� ��ʕ\���s��̒��� 
//				tex���b�Z�[�W.Text = "�o�^�ԍ��擾���D�D�D";
				if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
				sList = sv_hinagata.Get_hinagataNo(gsa���[�U,gs����b�c, gs����b�c);
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				sList[0] = gs�ʐM�G���[;
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				sList[0] = "�ʐM�G���[�F" + ex.Message;
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;

// MOD 2009.09.09 ���s�j���� ��ʕ\���s��̒��� 
//			tex���b�Z�[�W.Text = sList[0];

			// ���b�Z�[�W��[����I��]
			if(sList[0].Length != 4)
			{
// MOD 2009.09.09 ���s�j���� ��ʕ\���s��̒��� 
				tex���b�Z�[�W.Text = sList[0];
				�r�[�v��();
				nUD�o�^�ԍ�.Focus();
				return;
			}
// MOD 2009.09.09 ���s�j���� ��ʕ\���s��̒��� 
//			tex���b�Z�[�W.Text = "";
// ADD 2006.02.08 ���s�j���� ���^�ԍ���[99]��[100]�ɂȂ������̃G���[�Ή� START
			if(int.Parse(sList[1]) < 99)
// ADD 2006.02.08 ���s�j���� ���^�ԍ���[99]��[100]�ɂȂ������̃G���[�Ή� END
				nUD�o�^�ԍ�.Value = int.Parse(sList[1]) + 1;
		}

		private void ���^����()
		{
			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sList = {""};
			try
			{
				tex���b�Z�[�W.Text = "���^�������D�D�D";
				if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
				sList = sv_hinagata.Get_Hinagata2(gsa���[�U,gs����b�c, gs����b�c, i���^�m�n);
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				sList[0] = gs�ʐM�G���[;
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				sList[0] = "�ʐM�G���[�F" + ex.Message;
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;

			tex���b�Z�[�W.Text = sList[0];

			// ���b�Z�[�W��[����I��]
			if(sList[0].Length == 4)
			{
// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� START
				tex���b�Z�[�W.Text = "";
// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� END
				int iPos = 1;
				tex���^��.Text            = sList[iPos++].Trim();
				s�t�@�C����               = sList[iPos++].Trim();
				tex�͂���R�[�h.Text      = sList[iPos++].Trim();
				tex�͂���d�b�ԍ��P.Text  = sList[iPos++].Trim();
				tex�͂���d�b�ԍ��Q.Text  = sList[iPos++].Trim();
				tex�͂���d�b�ԍ��R.Text  = sList[iPos++].Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//				tex�͂���Z���P.Text      = sList[iPos++].Trim();
//				tex�͂���Z���Q.Text      = sList[iPos++].Trim();
//				tex�͂���Z���R.Text      = sList[iPos++].Trim();
//				tex�͂��於�O�P.Text      = sList[iPos++].Trim();
//				tex�͂��於�O�Q.Text      = sList[iPos++].Trim();
				if(gs�I�v�V����[18].Equals("1")){
					tex�͂���Z���P.Text  = sList[iPos++].TrimEnd();
					tex�͂���Z���Q.Text  = sList[iPos++].TrimEnd();
					tex�͂���Z���R.Text  = sList[iPos++].TrimEnd();
					tex�͂��於�O�P.Text  = sList[iPos++].TrimEnd();
					tex�͂��於�O�Q.Text  = sList[iPos++].TrimEnd();
				}else{
					tex�͂���Z���P.Text  = sList[iPos++].Trim();
					tex�͂���Z���Q.Text  = sList[iPos++].Trim();
					tex�͂���Z���R.Text  = sList[iPos++].Trim();
					tex�͂��於�O�P.Text  = sList[iPos++].Trim();
					tex�͂��於�O�Q.Text  = sList[iPos++].Trim();
				}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
				tex�͂���X�֔ԍ��P.Text  = sList[iPos++].Trim();
				tex�͂���X�֔ԍ��Q.Text  = sList[iPos++].Trim();
				tex�˗���R�[�h.Text      = sList[iPos++].Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//				tex�˗��啔��.Text        = sList[iPos++].Trim();
				if(gs�I�v�V����[18].Equals("1")){
					tex�˗��啔��.Text    = sList[iPos++].TrimEnd();
				}else{
					tex�˗��啔��.Text    = sList[iPos++].Trim();
				}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END

// ADD 2005.06.01 ���s�j�ɉ� �A�����i�R�[�h�ǉ� START
				s�A�����i�e�R�[�h         = sList[39].Trim();
				s�A�����i�q�R�[�h         = sList[40].Trim();
				�A�����i���d�ʐ���();
// ADD 2005.06.01 ���s�j�ɉ� �A�����i�R�[�h�ǉ� END

				nUD��.Value             = decimal.Parse(sList[iPos++].Trim());
// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� START
//// MOD 2005.05.17 ���s�j�����J �ː��ǉ� START
////				nUD�d��.Value             = decimal.Parse(sList[iPos++].Trim());
//				if(i�ː��e�f == 0)
//					nUD�d��.Value         = decimal.Parse(sList[37].Trim());
//				else
//					nUD�d��.Value         = decimal.Parse(sList[17].Trim());
//				iPos++;
//// MOD 2005.05.17 ���s�j�����J �ː��ǉ� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
				if(gs�d�ʓ��͐��� == "1"){
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
					if(i�ː��e�f == 0){
						nUD�d��.Value         = decimal.Parse(sList[37].Trim());
						if(decimal.Parse(sList[17]) > 0){
							tex���b�Z�[�W.Text = "���[�j���O�F�d��(kg)�����͂���Ă���ɂ�������炸�A\r\n"
												+ "�G���g���[�I�v�V�����ōː����I������Ă��܂�";
							�r�[�v��();
//						MessageBox.Show("�d��(kg)�����͂���Ă���ɂ�������炸�A\n"
//										+ "�G���g���[�I�v�V�����ōː����I������Ă��܂�"
//										,"�G���g���[�I�v�V�����ݒ胏�[�j���O"
//										,MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}else{
						nUD�d��.Value         = decimal.Parse(sList[17].Trim());
						if(decimal.Parse(sList[37]) > 0){
							tex���b�Z�[�W.Text = "���[�j���O�F�ː������͂���Ă���ɂ�������炸�A\r\n"
												+ "�G���g���[�I�v�V�����ŏd��(kg)���I������Ă��܂�";
							�r�[�v��();
//						MessageBox.Show("�ː������͂���Ă���ɂ�������炸�A\n"
//										+ "�G���g���[�I�v�V�����ŏd��(kg)���I������Ă��܂�"
//										,"�G���g���[�I�v�V�����ݒ胏�[�j���O"
//										,MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
				}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
				iPos++;
// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� END

				tex�A�����e.Text          = sList[iPos++].TrimEnd();
				tex�A�����q.Text          = sList[iPos++].TrimEnd();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//				tex�L�����P.Text          = sList[iPos++].TrimEnd();
//				tex�L�����Q.Text          = sList[iPos++].TrimEnd();
//				tex�L�����R.Text          = sList[iPos++].TrimEnd();
				if(gs�I�v�V����[18].Equals("1")){
					tex�L�����P.Text      = sList[iPos++].TrimEnd();
					tex�L�����Q.Text      = sList[iPos++].TrimEnd();
					tex�L�����R.Text      = sList[iPos++].TrimEnd();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
					if(sList.Length > 41){
						tex�L�����S.Text      = sList[41].TrimEnd();
						tex�L�����T.Text      = sList[42].TrimEnd();
						tex�L�����U.Text      = sList[43].TrimEnd();
					}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
				}else{
					tex�L�����P.Text      = sList[iPos++].Trim();
					tex�L�����Q.Text      = sList[iPos++].Trim();
					tex�L�����R.Text      = sList[iPos++].Trim();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
					if(sList.Length > 41){
						tex�L�����S.Text      = sList[41].Trim();
						tex�L�����T.Text      = sList[42].Trim();
						tex�L�����U.Text      = sList[43].Trim();
					}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
				}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX START
//				nUD�ی����z.Value         = decimal.Parse(sList[iPos++].Trim());
				decimal d�ی����z         = decimal.Parse(sList[iPos++].TrimEnd());
				if(d�ی����z < 0){
					nUD�ی����z.Minimum   = d�ی����z;
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) START
//				}else if(d�ی����z > 30){
				}else if(d�ی����z > gl�ی����z���){
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) END
					nUD�ی����z.Maximum   = d�ی����z;
				}
				nUD�ی����z.Value         = d�ی����z;
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX END
				s�X�V�N����               = sList[iPos++].Trim();

				tex�˗���d�b�ԍ��P.Text  = sList[iPos++].Trim();
				tex�˗���d�b�ԍ��Q.Text  = sList[iPos++].Trim();
				tex�˗���d�b�ԍ��R.Text  = sList[iPos++].Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//				tex�˗���Z���P.Text      = sList[iPos++].Trim();
//				tex�˗���Z���Q.Text      = sList[iPos++].Trim();
//				tex�˗��喼�O�P.Text      = sList[iPos++].Trim();
//				tex�˗��喼�O�Q.Text      = sList[iPos++].Trim();
				if(gs�I�v�V����[18].Equals("1")){
					tex�˗���Z���P.Text  = sList[iPos++].TrimEnd();
					tex�˗���Z���Q.Text  = sList[iPos++].TrimEnd();
					tex�˗��喼�O�P.Text  = sList[iPos++].TrimEnd();
					tex�˗��喼�O�Q.Text  = sList[iPos++].TrimEnd();
				}else{
					tex�˗���Z���P.Text  = sList[iPos++].Trim();
					tex�˗���Z���Q.Text  = sList[iPos++].Trim();
					tex�˗��喼�O�P.Text  = sList[iPos++].Trim();
					tex�˗��喼�O�Q.Text  = sList[iPos++].Trim();
				}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
				tex�˗���X�֔ԍ��P.Text  = sList[iPos++].Trim();
				tex�˗���X�֔ԍ��Q.Text  = sList[iPos++].Trim();
				string s������b�c        = sList[iPos++].Trim();
				string s�����敔�ۂb�c    = sList[iPos++].Trim();
				tex�˗��吿����.Text = "";
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� START
				tex������R�[�h.Text      = s������b�c;
				tex�����敔�ۃR�[�h.Text  = s�����敔�ۂb�c;
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� END
				tex�A���R�[�h�e.Text   = "";
// ADD 2005.06.01 ���s�j�ɉ� �A�����i�R�[�h�ǉ� START
				tex�A���R�[�h�q.Text = "";
// ADD 2005.06.01 ���s�j�ɉ� �A�����i�R�[�h�ǉ� END
				tex�L���R�[�h.Text   = "";
//				if(System.IO.File.Exists("icon\\"+s�t�@�C����))
//				{
//					btn�A�C�R��.Image = new Bitmap("icon\\"+s�t�@�C����);
					btn�A�C�R��.Image = imageList64.Images[�A�C�R���C���[�W�̎擾(s�t�@�C����)];
//				}
				if(gsa������b�c != null && s������b�c.Length > 0)
				{
					if(gsa������b�c != null)
					{
						for(int iCnt = 0 ; iCnt < gsa������b�c.Length; iCnt++ )
						{
							if(gsa������b�c[iCnt] == null || gsa�����敔�ۂb�c[iCnt] == null)
								continue;
							if(gsa������b�c[iCnt] == s������b�c && gsa�����敔�ۂb�c[iCnt] == s�����敔�ۂb�c)
							{
								tex�˗��吿����.Text = gsa�����敔�ۖ�[iCnt];
								break;
							}
						}
					}
				}
// MOD 2009.09.09 ���s�j���� ��ʕ\���s��̒��� 
				s�˗���b�c         = tex�˗���R�[�h.Text;
				s�O�񌟍��˗���b�c = tex�˗���R�[�h.Text;
// ADD 2005.05.12 ���s�j�����J �˗���d�� START
// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� STRAT
//// MOD 2005.05.17 ���s�j�����J �ː��ǉ� START
////				d�d�� = decimal.Parse(sList[36].Trim());
//				if(i�ː��e�f == 0)
//					d�d�� = decimal.Parse(sList[38]);
//				else
//					d�d�� = decimal.Parse(sList[36]);
//// MOD 2005.05.17 ���s�j�����J �ː��ǉ� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
				if(gs�d�ʓ��͐��� == "1"){
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
					if(i�ː��e�f == 0){ 
					// �ː��̎�
						d�d�� = decimal.Parse(sList[38]);
						if(d�d�� == 0){
							// �d�ʁ��W
							d�d�� = decimal.Parse(sList[36]) / 8;
// MOD 2011.03.11 ���s�j���� �ː��v�Z�̕␳ START
							d�d�� = decimal.Truncate(d�d�� + decimal.Parse("0.9"));
// MOD 2011.03.11 ���s�j���� �ː��v�Z�̕␳ END
						}
					}else{
					// �d�ʂ̎�
						d�d�� = decimal.Parse(sList[36]);
						if(d�d�� == 0){
							// �ː��~�W
							d�d�� = decimal.Parse(sList[38]) * 8;
						}
					}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
				}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� END
// ADD 2005.05.12 ���s�j�����J �˗���d�� END
// MOD 2009.09.09 ���s�j���� ��ʕ\���s��̒��� 
//				tex���b�Z�[�W.Text = "";
				tex�͂���R�[�h.Focus();
			}
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� START
			if(tex�͂���Z���P.Text.Equals("�����x�X�~�߁���"))
			{
				// ���b�N
				tex�͂���X�֔ԍ��P.Enabled = false; // �͂���X�֔ԍ��P
				tex�͂���X�֔ԍ��Q.Enabled = false; // �͂���X�֔ԍ��Q
				tex�͂���Z���P.Enabled = false; // �͂���Z���P
				tex�͂���Z���Q.Enabled = false; // �͂���Z���Q
				tex�͂���Z���R.Enabled = false; // �͂���Z���R

				// �x�X�~�߃{�^�����\���A�����{�^����\��
				btn�x�X�~��.Visible = false;
				btn�x�X�~��.Enabled = false;
				btn�x�X�~�߉���.Visible = true;
				btn�x�X�~�߉���.Enabled = true;
			}
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� END
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
// ADD 2007.11.05 ���s�j���� �˗�����̍ŐV�� START
			s�O�񌟍��˗���b�c = "";
// ADD 2007.11.05 ���s�j���� �˗�����̍ŐV�� END
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� START
			// ���b�N������
			tex�͂���X�֔ԍ��P.Enabled = true; // �X�֔ԍ��P
			tex�͂���X�֔ԍ��Q.Enabled = true; // �X�֔ԍ��Q
			tex�͂���Z���P.Enabled = true; // �Z���P
			tex�͂���Z���Q.Enabled = true; // �Z���Q
			tex�͂���Z���R.Enabled = true; // �Z���R
			// �x�X�~�߃{�^����\���A�����{�^�����\��
			btn�x�X�~��.Visible = true;
			btn�x�X�~��.Enabled = true;
			btn�x�X�~�߉���.Visible = false;
			btn�x�X�~�߉���.Enabled = false;
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� END
			this.Close();
		}

		private void btn�͂��挟��_Click(object sender, System.EventArgs e)
		{
			tex�͂���R�[�h.Text = tex�͂���R�[�h.Text.Trim();
			if(!���p�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;

// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			���͂��挟�� ��� = new ���͂��挟��();
//			���.Left = this.Left + 404;
//			���.Top = this.Top;

//			���.sTcode = tex�͂���R�[�h.Text;
//			���.ShowDialog();

//			s�͂���b�c = ���.sTcode;
			if (g�͐挟�� == null)	 g�͐挟�� = new ���͂��挟��();
			g�͐挟��.Left = this.Left;
			g�͐挟��.Top = this.Top;

// MOD 2005.06.02 ���s�j�����J �l�̈��p���Ȃ� START
//			g�͐挟��.sTcode = tex�͂���R�[�h.Text;
			g�͐挟��.sTcode = "";
// MOD 2005.06.02 ���s�j�����J �l�̈��p���Ȃ� END
			g�͐挟��.ShowDialog();

			s�͂���b�c = g�͐挟��.sTcode;
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
			if(s�͂���b�c.Length > 0)
			{
				�͂��捀�ڃN���A();
				tex�͂���R�[�h.Text = s�͂���b�c;
				�͂��挟��(false);
			}
			else
			{
				tex�͂���R�[�h.Focus();
			}
		}

		private void btn�˗��匟��_Click(object sender, System.EventArgs e)
		{
			tex�˗���R�[�h.Text = tex�˗���R�[�h.Text.Trim();
			if(!���p�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;

// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			���˗��匟�� ��� = new ���˗��匟��();
//			���.Left = this.Left + 404;
//			���.Top = this.Top;

//			���.sIcode = tex�˗���R�[�h.Text.Trim();
//			���.ShowDialog();
			if (g�˗����� == null)	 g�˗����� = new ���˗��匟��();
			g�˗�����.Left   = this.Left;
			g�˗�����.Top    = this.Top;
// MOD 2005.06.02 ���s�j�����J �l�̈��p���Ȃ� START
//			g�˗�����.sIcode = tex�˗���R�[�h.Text.Trim();
			g�˗�����.sIcode = "";
// MOD 2005.06.02 ���s�j�����J �l�̈��p���Ȃ� END
			g�˗�����.ShowDialog(this);
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END

			s�˗���b�c = g�˗�����.sIcode;
			if(s�˗���b�c.Length > 0)
			{
// MOD 2009.09.09 ���s�j���� ��ʕ\���s��̒��� 
//				if(s�˗���b�c != s�O�񌟍��˗���b�c)
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� START
//				if((s�˗���b�c != s�O�񌟍��˗���b�c)
//					|| (s�˗���b�c == s�O�񌟍��˗���b�c
//					&& tex�˗���d�b�ԍ��P.Text.Trim() == ""))
//				{
//					�˗��區�ڃN���A();
//					tex�˗���R�[�h.Text = s�˗���b�c;
//					�˗��匟��();
//				}
//				else
//				{
//					tex�˗���R�[�h.Text = s�˗���b�c;
//					tex�˗���R�[�h.Focus();
//				}
				�˗��區�ڃN���A();
				tex�˗���R�[�h.Text = s�˗���b�c;
				�˗��匟��();
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� END
			}
			else
			{
				tex�˗���R�[�h.Focus();
			}
		}

		private void btn�L������_Click(object sender, System.EventArgs e)
		{
// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			�L������ ��� = new �L������();
//			���.Left = this.Left;
//			���.Top = this.Top;
			// ADD 2005.05.16 ���s�j�ɉ� �i���L�� START
//			���.b�A���w�� = false;
			// ADD 2005.05.16 ���s�j�ɉ� �i���L�� END
//			���.ShowDialog();
			if (g�L������ == null)	 g�L������ = new �L������();
			g�L������.Left  = this.Left;
			g�L������.Top   = this.Top;
			g�L������.b�A���w�� = false;
			g�L������.Text                 = "is-2 �L������";
			g�L������.lab�L���^�C�g��.Text = "�L������";
			g�L������.ShowDialog();
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END

// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//			tex�L�����P.Text = tex�L�����P.Text.Trim();
//			tex�L�����Q.Text = tex�L�����Q.Text.Trim();
//			tex�L�����R.Text = tex�L�����R.Text.Trim();
			if(gs�I�v�V����[18].Equals("1")){
				tex�L�����P.Text = tex�L�����P.Text.TrimEnd();
				tex�L�����Q.Text = tex�L�����Q.Text.TrimEnd();
				tex�L�����R.Text = tex�L�����R.Text.TrimEnd();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
				tex�L�����S.Text = tex�L�����S.Text.TrimEnd();
				tex�L�����T.Text = tex�L�����T.Text.TrimEnd();
				tex�L�����U.Text = tex�L�����U.Text.TrimEnd();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
			}else{
				tex�L�����P.Text = tex�L�����P.Text.Trim();
				tex�L�����Q.Text = tex�L�����Q.Text.Trim();
				tex�L�����R.Text = tex�L�����R.Text.Trim();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
				tex�L�����S.Text = tex�L�����S.Text.Trim();
				tex�L�����T.Text = tex�L�����T.Text.Trim();
				tex�L�����U.Text = tex�L�����U.Text.Trim();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END

// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
//			if(tex�L�����P.Text == "")
//			{
//				tex�L�����P.Text = g�L������.s�L��;
//			}
//			else
//			{
//				if(tex�L�����Q.Text == "")
//				{
//					tex�L�����Q.Text = g�L������.s�L��;
//				}
//				else
//				{
//					if(tex�L�����R.Text == "")
//						tex�L�����R.Text = g�L������.s�L��;
//				}
//			}
			if(tex�L�����P.Text == ""){
				tex�L�����P.Text = g�L������.s�L��;
			}else if(tex�L�����Q.Text == ""){
				tex�L�����Q.Text = g�L������.s�L��;
			}else if(tex�L�����R.Text == ""){
				tex�L�����R.Text = g�L������.s�L��;
// MOD 2011.09.26 ���s�j���� �L���s�̒ǉ��i�R�s�E�U�s�֑ؑΉ��j START
//			}else if(tex�L�����S.Text == ""){
//				tex�L�����S.Text = g�L������.s�L��;
//			}else if(tex�L�����T.Text == ""){
//				tex�L�����T.Text = g�L������.s�L��;
//			}else if(tex�L�����U.Text == ""){
//				tex�L�����U.Text = g�L������.s�L��;
//			}else if(tex�L�����S.Enabled && tex�L�����S.Text == ""){
//				tex�L�����S.Text = g�L������.s�L��;
//			}else if(tex�L�����T.Enabled && tex�L�����T.Text == ""){
//				tex�L�����T.Text = g�L������.s�L��;
//			}else if(tex�L�����U.Enabled && tex�L�����U.Text == ""){
//				tex�L�����U.Text = g�L������.s�L��;
			// [�Q:�R�s����]�̎��̂ݓ��͕s��
			}else if(gs�I�v�V����[7] != "2" && tex�L�����S.Text == ""){
				tex�L�����S.Text = g�L������.s�L��;
			}else if(gs�I�v�V����[7] != "2" && tex�L�����T.Text == ""){
				tex�L�����T.Text = g�L������.s�L��;
			}else if(gs�I�v�V����[7] != "2" && tex�L�����U.Text == ""){
				tex�L�����U.Text = g�L������.s�L��;
// MOD 2011.09.26 ���s�j���� �L���s�̒ǉ��i�R�s�E�U�s�֑ؑΉ��j END
			}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
			tex���b�Z�[�W.Text = "";
			tex�L���R�[�h.Focus();
		}

		private void btn�Z������_Click(object sender, System.EventArgs e)
		{
			// �󔒏���
			tex�͂���X�֔ԍ��P.Text = tex�͂���X�֔ԍ��P.Text.Trim();
			tex�͂���X�֔ԍ��Q.Text = tex�͂���X�֔ԍ��Q.Text.Trim();

			// ���̓`�F�b�N
			if(!���p�`�F�b�N(tex�͂���X�֔ԍ��P,"�X�֔ԍ��P")) return;
			if(!���p�`�F�b�N(tex�͂���X�֔ԍ��Q,"�X�֔ԍ��Q")) return;

// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			�Z������ ��� = new �Z������();
//			���.Left = this.Left + 404;
//			���.Top = this.Top;
//			//��ʏ����l�̐ݒ�
//			���.s�X�֔ԍ��P = tex�͂���X�֔ԍ��P.Text;
//			���.s�X�֔ԍ��Q = tex�͂���X�֔ԍ��Q.Text;
//			���.ShowDialog();
//			//�߂�l�̐ݒ�
//			if(���.s�Z���b�c.Length > 0)
			if (g�Z������ == null)	 g�Z������ = new �Z������();
			g�Z������.Left = this.Left + 404;
			g�Z������.Top = this.Top;
			//��ʏ����l�̐ݒ�
// MOD 2009.08.20 �p�\�j����@�X�֔ԍ��̒l���p��  START
// MOD 2005.06.02 ���s�j�����J �l�̈��p���Ȃ� START
			g�Z������.s�X�֔ԍ��P = tex�͂���X�֔ԍ��P.Text;
			g�Z������.s�X�֔ԍ��Q = tex�͂���X�֔ԍ��Q.Text;
//			g�Z������.s�X�֔ԍ��P = "";
//			g�Z������.s�X�֔ԍ��Q = "";
// MOD 2005.06.02 ���s�j�����J �l�̈��p���Ȃ� END
// MOD 2009.08.20 �p�\�j����@�X�֔ԍ��̒l���p��  END
// MOD 2009.09.09 ���s�j���� ��ʕ\���s��̒��� 
			g�Z������.s�Z��       = tex�͂���Z���P.Text;
			g�Z������.ShowDialog();
			//�߂�l�̐ݒ�
			if(g�Z������.s�Z���b�c.Length > 0)
			{
//				tex�͂���X�֔ԍ��P.Text = ���.s�X�֔ԍ��P;
//				tex�͂���X�֔ԍ��Q.Text = ���.s�X�֔ԍ��Q;
//				if(���.s�Z��.Length > 60)
				tex�͂���X�֔ԍ��P.Text = g�Z������.s�X�֔ԍ��P;
				tex�͂���X�֔ԍ��Q.Text = g�Z������.s�X�֔ԍ��Q;
				if(g�Z������.s�Z��.Length > 60)
				{
//					tex�͂���Z���P.Text     = ���.s�Z��.Substring(0,20);
//					tex�͂���Z���Q.Text     = ���.s�Z��.Substring(20,20);
//					tex�͂���Z���R.Text     = ���.s�Z��.Substring(40,20);
					tex�͂���Z���P.Text     = g�Z������.s�Z��.Substring(0,20);
					tex�͂���Z���Q.Text     = g�Z������.s�Z��.Substring(20,20);
					tex�͂���Z���R.Text     = g�Z������.s�Z��.Substring(40,20);
				}
//				else if(���.s�Z��.Length > 40)
				else if(g�Z������.s�Z��.Length > 40)
				{
//					tex�͂���Z���P.Text     = ���.s�Z��.Substring(0,20);
//					tex�͂���Z���Q.Text     = ���.s�Z��.Substring(20,20);
//					tex�͂���Z���R.Text     = ���.s�Z��.Substring(40);
					tex�͂���Z���P.Text     = g�Z������.s�Z��.Substring(0,20);
					tex�͂���Z���Q.Text     = g�Z������.s�Z��.Substring(20,20);
					tex�͂���Z���R.Text     = g�Z������.s�Z��.Substring(40);
				}
//				else if(���.s�Z��.Length > 20)
				else if(g�Z������.s�Z��.Length > 20)
				{
//					tex�͂���Z���P.Text     = ���.s�Z��.Substring(0,20);
//					tex�͂���Z���Q.Text     = ���.s�Z��.Substring(20);
					tex�͂���Z���P.Text     = g�Z������.s�Z��.Substring(0,20);
					tex�͂���Z���Q.Text     = g�Z������.s�Z��.Substring(20);
					tex�͂���Z���R.Text     = "";
				}
				else
				{
//					tex�͂���Z���P.Text     = ���.s�Z��;
					tex�͂���Z���P.Text     = g�Z������.s�Z��;
					tex�͂���Z���Q.Text     = "";
					tex�͂���Z���R.Text     = "";
				}
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
				//�t�H�[�J�X�ݒ�
				tex�͂���Z���Q.Focus();
			}
			else
			{
				tex�͂���X�֔ԍ��P.Focus();
			}
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			���͂��挟�� ��� = new ���͂��挟��();
//			���.Left = this.Left + 404;
//			���.Top = this.Top;
//
//			���.sTcode = tex�͂���R�[�h.Text;
//			���.ShowDialog();
//
//			s�͂���b�c = ���.sTcode;
			if (g�͐挟�� == null)	 g�͐挟�� = new ���͂��挟��();
			g�͐挟��.Left = this.Left;
			g�͐挟��.Top = this.Top;

// MOD 2005.06.16 ���s�j�����J �l�̈��p���Ȃ� START
//			g�͐挟��.sTcode = tex�͂���R�[�h.Text;
			g�͐挟��.sTcode = "";
// MOD 2005.06.16 ���s�j�����J �l�̈��p���Ȃ� END
			g�͐挟��.ShowDialog();

			s�͂���b�c = g�͐挟��.sTcode;
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
			if(s�͂���b�c.Length > 0)
			{
				�͂��挟��(true);
			}
			else
			{
				tex�͂���R�[�h.Focus();
			}
		}

// MOD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX START
		private void btn�A������_Click(object sender, System.EventArgs e)
		{
// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			�L������ ��� = new �L������();
//			���.Left = this.Left;
//			���.Top = this.Top;
// ADD 2005.05.16 ���s�j�ɉ� �A���w�� START
//			���.b�A���w�� = true;
// ADD 2005.05.16 ���s�j�ɉ� �A���w�� END
//			���.ShowDialog();
			if (g�L������ == null)	 g�L������ = new �L������();
			g�L������.Left  = this.Left;
			g�L������.Top   = this.Top;
			g�L������.b�A���w�� = true;
			g�L������.Text                 = "is-2 �A�����i����";
			g�L������.lab�L���^�C�g��.Text = "�A�����i����";
// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX START
// MOD 2005.06.01 ���s�j�ɉ� �A�����i�d�l�ύX START
//			if (tex�A���R�[�h�e.Text.Trim().Length == 0 || s�A�����i�e�R�[�h.Length == 0)
//			{
//				//�A�����i�e����
//				g�L������.s�A�����i���� = "0000";
//			}
//			else
//			{
//				//�A�����i�q����
//				g�L������.s�A�����i���� = s�A�����i�e�R�[�h;
//			}
			//�A�����i�e����
			g�L������.s�A�����i���� = "0000";
// MOD 2005.06.01 ���s�j�ɉ� �A�����i�d�l�ύX END
// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX START
			g�L������.ShowDialog();
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END

// MOD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX START
//			tex�A�����e.Text = tex�A�����e.Text.Trim();
//			tex�A�����q.Text = tex�A�����q.Text.Trim();
//			if(tex�A�����e.Text.Length == 0)
//			{
//				tex�A�����e.Text = g�L������.s�L��;
//			}
//			else
//			{
//				if(tex�A�����q.Text == "")
//					tex�A�����q.Text = g�L������.s�L��;
//			}
// MOD 2005.06.01 ���s�j�ɉ� �A�����i�d�l�ύX START
//			if (tex�A���R�[�h�e.Text.Trim().Length == 0 || s�A�����i�e�R�[�h.Length == 0)
//			{
//				//�A�����i�e����
//				if (g�L������.sKcode.Length != 0)
//				{
//					tex�A���R�[�h�e.Text = g�L������.sKcode2;
//					tex�A�����e.Text = g�L������.s�L���Q;
//					if (!g�L������.sKcode.Equals("dumycode"))
//					{
//						tex�A���R�[�h�q.Text = g�L������.sKcode;
//						tex�A�����q.Text = g�L������.s�L��;
//						s�A�����i�q�R�[�h = g�L������.sKcode;
//					}
//					else
//					{
//						tex�A���R�[�h�q.Text = " ";
//						tex�A�����q.Text = "";
//						s�A�����i�q�R�[�h = "";
//					}
//					s�A�����i�e�R�[�h = g�L������.sKcode2;
//					tex�L���R�[�h.Focus();
//				}
//			}
//			else
//			{
//				if (g�L������.sKcode.Length != 0)
//				{
//					//�A�����i�q����
//					tex�A���R�[�h�q.Text = g�L������.sKcode;
//					tex�A�����q.Text = g�L������.s�L��;
//					s�A�����i�q�R�[�h = g�L������.sKcode;
//					tex�L���R�[�h.Focus();
//				}
//			}
			//�A�����i�e����
			if (g�L������.sKcode.Length != 0)
			{
				tex�A���R�[�h�e.Text = g�L������.sKcode2;
				tex�A�����e.Text = g�L������.s�L���Q;
				if (!g�L������.sKcode.Equals("dumycode"))
				{
					tex�A���R�[�h�q.Text = g�L������.sKcode;
					tex�A�����q.Text = g�L������.s�L��;
					s�A�����i�q�R�[�h = g�L������.sKcode;
				}
				else
				{
					tex�A���R�[�h�q.Text = " ";
					tex�A�����q.Text = "";
					s�A�����i�q�R�[�h = "";
				}
				s�A�����i�e�R�[�h = g�L������.sKcode2;
// ADD 2005.06.07 ���s�j�ɉ� �A�����i�d�l�ύX START
				�A�����i���d�ʐ���();
// ADD 2005.06.07 ���s�j�ɉ� �A�����i�d�l�ύX END
				tex�L���R�[�h.Focus();
			}
// MOD 2005.06.01 ���s�j�ɉ� �A�����i�d�l�ύX END
// MOD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX END
			tex���b�Z�[�W.Text = "";
		}
// MOD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX END

		private void btn�A�C�R��_Click(object sender, System.EventArgs e)
		{
// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			�A�C�R���I�� ��� = new �A�C�R���I��();
//			���.Left = this.Left + (this.Width  - ���.Width)  / 2;
//			���.Top  = this.Top  + (this.Height - ���.Height) / 2;
//			int i�A�C�R�� = �A�C�R���C���[�W�̎擾(s�t�@�C����);
//			if( i�A�C�R�� > 0 )
//				���.i�A�C�R�� = i�A�C�R��; 
//			���.ShowDialog(this);
//			if( i�A�C�R�� != ���.i�A�C�R�� )
			if (g�A�C�R�� == null)	 g�A�C�R�� = new �A�C�R���I��();
			g�A�C�R��.Left = this.Left + (this.Width  - g�A�C�R��.Width)  / 2;
			g�A�C�R��.Top  = this.Top  + (this.Height - g�A�C�R��.Height) / 2;
			int i�A�C�R�� = �A�C�R���C���[�W�̎擾(s�t�@�C����);
			if( i�A�C�R�� > 0 )
				g�A�C�R��.i�A�C�R�� = i�A�C�R��; 
			g�A�C�R��.ShowDialog(this);
			if( i�A�C�R�� != g�A�C�R��.i�A�C�R�� )
			{
//				s�t�@�C����       = s�A�C�R��[���.i�A�C�R��];
//				btn�A�C�R��.Image = imageList64.Images[���.i�A�C�R��];
				s�t�@�C����       = s�A�C�R��[g�A�C�R��.i�A�C�R��];
				btn�A�C�R��.Image = imageList64.Images[g�A�C�R��.i�A�C�R��];
			}
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
/*
			openFileDialog1.InitialDirectory
//				 = System.IO.Directory.GetCurrentDirectory() + "\\icon";
				 = gs�A�v���t�H���_ + "\\icon";
			if(openFileDialog1.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
//					System.Drawing.Bitmap bm = new Bitmap(openFileDialog1.FileName);
					int iLastPath = openFileDialog1.FileName.LastIndexOf('\\');
					if(iLastPath >= 0)
						s�t�@�C���� = openFileDialog1.FileName.Substring(iLastPath + 1);
					else
						s�t�@�C���� = openFileDialog1.FileName;
//					btn�A�C�R��.Image = bm;
					btn�A�C�R��.Image = imageList64.Images[�A�C�R���C���[�W�̎擾(s�t�@�C����)];
				}
				catch(Exception){};
			}
*/
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lab����.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

		private void btn�X�V_Click(object sender, System.EventArgs e)
		{
			tex���b�Z�[�W.Text = "";

			tex���^��.Text             = tex���^��.Text.Trim();
			tex�͂���R�[�h.Text       = tex�͂���R�[�h.Text.Trim();
			tex�͂���d�b�ԍ��P.Text   = tex�͂���d�b�ԍ��P.Text.Trim();
			tex�͂���d�b�ԍ��Q.Text   = tex�͂���d�b�ԍ��Q.Text.Trim();
			tex�͂���d�b�ԍ��R.Text   = tex�͂���d�b�ԍ��R.Text.Trim();
			tex�͂���X�֔ԍ��P.Text   = tex�͂���X�֔ԍ��P.Text.Trim();
			tex�͂���X�֔ԍ��Q.Text   = tex�͂���X�֔ԍ��Q.Text.Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//			tex�͂���Z���P.Text       = tex�͂���Z���P.Text.Trim();
//			tex�͂���Z���Q.Text       = tex�͂���Z���Q.Text.Trim();
//			tex�͂���Z���R.Text       = tex�͂���Z���R.Text.Trim();
//			tex�͂��於�O�P.Text       = tex�͂��於�O�P.Text.Trim();
//			tex�͂��於�O�Q.Text       = tex�͂��於�O�Q.Text.Trim();
//			tex�˗���R�[�h.Text       = tex�˗���R�[�h.Text.Trim();
//			tex�˗��啔��.Text         = tex�˗��啔��.Text.Trim();
			if(gs�I�v�V����[18].Equals("1")){
				tex�͂���Z���P.Text   = tex�͂���Z���P.Text.TrimEnd();
				tex�͂���Z���Q.Text   = tex�͂���Z���Q.Text.TrimEnd();
				tex�͂���Z���R.Text   = tex�͂���Z���R.Text.TrimEnd();
				tex�͂��於�O�P.Text   = tex�͂��於�O�P.Text.TrimEnd();
				tex�͂��於�O�Q.Text   = tex�͂��於�O�Q.Text.TrimEnd();
				tex�˗��啔��.Text     = tex�˗��啔��.Text.TrimEnd();
			}else{
				tex�͂���Z���P.Text   = tex�͂���Z���P.Text.Trim();
				tex�͂���Z���Q.Text   = tex�͂���Z���Q.Text.Trim();
				tex�͂���Z���R.Text   = tex�͂���Z���R.Text.Trim();
				tex�͂��於�O�P.Text   = tex�͂��於�O�P.Text.Trim();
				tex�͂��於�O�Q.Text   = tex�͂��於�O�Q.Text.Trim();
				tex�˗��啔��.Text     = tex�˗��啔��.Text.Trim();
			}
			tex�˗���R�[�h.Text       = tex�˗���R�[�h.Text.Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
//			tex���q�l�Ǘ��ԍ�.Text     = tex���q�l�Ǘ��ԍ�.Text.Trim();
			tex�A���R�[�h�e.Text         = tex�A���R�[�h�e.Text.Trim();
			tex�L���R�[�h.Text         = tex�L���R�[�h.Text.Trim();
//			tex�A�����e.Text           = tex�A�����e.Text.Trim();
//			tex�A�����q.Text           = tex�A�����q.Text.Trim();
			tex�A�����e.Text           = tex�A�����e.Text.TrimEnd();
			tex�A�����q.Text           = tex�A�����q.Text.TrimEnd();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//			tex�L�����P.Text           = tex�L�����P.Text.TrimEnd();
//			tex�L�����Q.Text           = tex�L�����Q.Text.TrimEnd();
//			tex�L�����R.Text           = tex�L�����R.Text.TrimEnd();
			if(gs�I�v�V����[18].Equals("1")){
				tex�L�����P.Text       = tex�L�����P.Text.TrimEnd();
				tex�L�����Q.Text       = tex�L�����Q.Text.TrimEnd();
				tex�L�����R.Text       = tex�L�����R.Text.TrimEnd();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
				tex�L�����S.Text       = tex�L�����S.Text.TrimEnd();
				tex�L�����T.Text       = tex�L�����T.Text.TrimEnd();
				tex�L�����U.Text       = tex�L�����U.Text.TrimEnd();
				tex�˗��吿����.Text   = tex�˗��吿����.Text.TrimEnd();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
			}else{
				tex�L�����P.Text       = tex�L�����P.Text.Trim();
				tex�L�����Q.Text       = tex�L�����Q.Text.Trim();
				tex�L�����R.Text       = tex�L�����R.Text.Trim();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
				tex�L�����S.Text       = tex�L�����S.Text.Trim();
				tex�L�����T.Text       = tex�L�����T.Text.Trim();
				tex�L�����U.Text       = tex�L�����U.Text.Trim();
				tex�˗��吿����.Text   = tex�˗��吿����.Text.Trim();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
//			tex�˗��吿����.Text       = tex�˗��吿����.Text.Trim();
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� START
			tex������R�[�h.Text       = tex������R�[�h.Text.Trim();
			tex�����敔�ۃR�[�h.Text   = tex�����敔�ۃR�[�h.Text.Trim();
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� END

			if(!�K�{�`�F�b�N(tex���^��,"����")) return;
			if(!�K�{�`�F�b�N(tex�͂���d�b�ԍ��P,"�͂���d�b�ԍ��P")) return;
			if(!�K�{�`�F�b�N(tex�͂���d�b�ԍ��Q,"�͂���d�b�ԍ��Q")) return;
			if(!�K�{�`�F�b�N(tex�͂���d�b�ԍ��R,"�͂���d�b�ԍ��R")) return;
			if(!�K�{�`�F�b�N(tex�͂���X�֔ԍ��P,"�͂���X�֔ԍ��P")) return;
			if(!�K�{�`�F�b�N(tex�͂���X�֔ԍ��Q,"�͂���X�֔ԍ��Q")) return;
			if(!�K�{�`�F�b�N(tex�͂���Z���P,"�͂���Z���P")) return;
			if(!�K�{�`�F�b�N(tex�͂��於�O�P,"�͂��於�O�P")) return;
			if(!�K�{�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� START
//			if(!�K�{�`�F�b�N(tex�˗��吿����,"�˗��吿����"))
//			{
//				tex�˗���R�[�h.Focus();
//				return;
//			}
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� END
// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX START
			//�A�����e�̂ݓ��͂���āA�A�����q�����݂���ꍇ�G���[
			if(tex�A�����e.Text.TrimEnd().Length != 0 && tex�A�����q.Text.TrimEnd().Length == 0)
			{
				string[] sList = {""};
				try
				{
					if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
					if (gs����b�c.Substring(0,1) != "J"){
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
						sList = sv_kiji.Get_kiji(gsa���[�U,"yusoshohin",s�A�����i�e�R�[�h);
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
					}else{
						sList = sv_kiji.Get_kiji(gsa���[�U,"Jyusoshohin",s�A�����i�e�R�[�h);
					}
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
				}
				catch (System.Net.WebException)
				{
					tex���b�Z�[�W.Text = gs�ʐM�G���[;
					�r�[�v��();
					return;
				}
				catch (Exception ex)
				{
					tex���b�Z�[�W.Text = "�ʐM�G���[�F" + ex.Message;
					�r�[�v��();
					return;
				}
				// �J�[�\�����f�t�H���g�ɖ߂�
				Cursor = System.Windows.Forms.Cursors.Default;

				// �G���[��
				if(sList[0].Equals("����I��"))
				{
					//�G���[���b�Z�[�W�ۗ�
					MessageBox.Show("�A�����i�e�����͂���Ă���ꍇ�A�A�����i�q�͕K�{���ڂł�","���̓`�F�b�N",MessageBoxButtons.OK);
					tex�A���R�[�h�q.Focus();
					return;
				}
				else if(!sList[0].Equals("�Y���f�[�^������܂���"))
				{
					tex���b�Z�[�W.Text = sList[0];
					�r�[�v��();
					return;
				}
			}
// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX END

			if(!���p�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;
			if(!���l�`�F�b�N(tex�͂���d�b�ԍ��P,"�͂���d�b�ԍ��P")) return;
			if(!���l�`�F�b�N(tex�͂���d�b�ԍ��Q,"�͂���d�b�ԍ��Q")) return;
			if(!���l�`�F�b�N(tex�͂���d�b�ԍ��R,"�͂���d�b�ԍ��R")) return;
			if(!���p�`�F�b�N(tex�͂���X�֔ԍ��P,"�͂���X�֔ԍ��P")) return;
			if(!���p�`�F�b�N(tex�͂���X�֔ԍ��Q,"�͂���X�֔ԍ��Q")) return;
			if(!���p�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;
//			if(!���p�`�F�b�N(tex���q�l�Ǘ��ԍ�,"���q�l�Ǘ��ԍ�")) return;
//			if(!���p�`�F�b�N(tex�A���R�[�h�e      )) return;
//			if(!���p�`�F�b�N(tex�L���R�[�h      )) return;
			if(!�S�p�`�F�b�N(tex���^��,"����")) return;
// MOD 2011.12.08 ���s�j���� �Z���E���O�̔��p���͉� START
//			if(!�S�p�`�F�b�N(tex�͂���Z���P,"�͂���Z���P")) return;
//			if(!�S�p�`�F�b�N(tex�͂���Z���Q,"�͂���Z���Q")) return;
//			if(!�S�p�`�F�b�N(tex�͂���Z���R,"�͂���Z���R")) return;
//			if(!�S�p�`�F�b�N(tex�͂��於�O�P,"�͂��於�O�P")) return;
//			if(!�S�p�`�F�b�N(tex�͂��於�O�Q,"�͂��於�O�Q")) return;
//			if(!�S�p�`�F�b�N(tex�˗��啔��,"�˗��啔��")) return;
			if(!�S�p�ϊ��`�F�b�N(tex�͂���Z���P,"�͂���Z���P")) return;
			if(!�S�p�ϊ��`�F�b�N(tex�͂���Z���Q,"�͂���Z���Q")) return;
			if(!�S�p�ϊ��`�F�b�N(tex�͂���Z���R,"�͂���Z���R")) return;
			if(!�S�p�ϊ��`�F�b�N(tex�͂��於�O�P,"�͂��於�O�P")) return;
			if(!�S�p�ϊ��`�F�b�N(tex�͂��於�O�Q,"�͂��於�O�Q")) return;
			if(!�S�p�ϊ��`�F�b�N(tex�˗��啔��,"�˗���S��")) return;
// MOD 2011.12.08 ���s�j���� �Z���E���O�̔��p���͉� END
//			if(!�S�p�`�F�b�N(tex�A�����e,"�A�����P")) return;
//			if(!�S�p�`�F�b�N(tex�A�����q,"�A�����Q")) return;
// MOD 2009.12.01 ���s�j���� �S�p���p���݉\�ɂ��� START
//			if(!�S�p�`�F�b�N(tex�L�����P,"�L�����P")) return;
//			if(!�S�p�`�F�b�N(tex�L�����Q,"�L�����Q")) return;
//			if(!�S�p�`�F�b�N(tex�L�����R,"�L�����R")) return;
// MOD 2011.07.28 ���s�j���� �L���s�̒ǉ��i�����������̒ǉ��j START
//			if(!���݃`�F�b�N(tex�L�����P,"�L�����P")) return;
//			if(!���݃`�F�b�N(tex�L�����Q,"�L�����Q")) return;
//			if(!���݃`�F�b�N(tex�L�����R,"�L�����R")) return;
//// MOD 2009.12.01 ���s�j���� �S�p���p���݉\�ɂ��� END
//// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
//			if(!���݃`�F�b�N(tex�L�����S,"�L�����S")) return;
//			if(!���݃`�F�b�N(tex�L�����T,"�L�����T")) return;
//			if(!���݃`�F�b�N(tex�L�����U,"�L�����U")) return;
//// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
			// �i���L���S�`�U�̂����ꂩ�Ƀf�[�^����ꍇ
			if(tex�L�����S.Text.Trim().Length > 0
				|| tex�L�����T.Text.Trim().Length > 0
				|| tex�L�����U.Text.Trim().Length > 0
			){
				if(!���݃`�F�b�N�Q(tex�L�����P,"�L�����P",18)) return;
				if(!���݃`�F�b�N�Q(tex�L�����Q,"�L�����Q",18)) return;
				if(!���݃`�F�b�N�Q(tex�L�����R,"�L�����R",18)) return;
				if(!���݃`�F�b�N�Q(tex�L�����S,"�L�����S",18)) return;
				if(!���݃`�F�b�N�Q(tex�L�����T,"�L�����T",18)) return;
				if(!���݃`�F�b�N�Q(tex�L�����U,"�L�����U",18)) return;
			}else{
				if(!���݃`�F�b�N(tex�L�����P,"�L�����P")) return;
				if(!���݃`�F�b�N(tex�L�����Q,"�L�����Q")) return;
				if(!���݃`�F�b�N(tex�L�����R,"�L�����R")) return;
			}
// MOD 2011.07.28 ���s�j���� �L���s�̒ǉ��i�����������̒ǉ��j END
			if(!b�X�V�e�f){
				if(nUD�o�^�ԍ�.Text.Length == 0 )
				{
					MessageBox.Show("�K�{���ځi�o�^�ԍ��j�����͂���Ă��܂���","���̓`�F�b�N",MessageBoxButtons.OK);
					nUD�o�^�ԍ�.Focus();
					return;
				}
				if(!�͈̓`�F�b�N(nUD�o�^�ԍ�,"�o�^�ԍ�")) return;
				if(nUD�o�^�ԍ�.Value == 0 )
				{
					MessageBox.Show("�K�{���ځi�o�^�ԍ��j�����͂���Ă��܂���","���̓`�F�b�N",MessageBoxButtons.OK);
					nUD�o�^�ԍ�.Focus();
					return;
				}
			}

			if(nUD��.Text.Length == 0 )
			{
				MessageBox.Show("�K�{���ځi���j�����͂���Ă��܂���","���̓`�F�b�N",MessageBoxButtons.OK);
				nUD��.Focus();
				return;
			}
			if(!�͈̓`�F�b�N(nUD��,"��")) return;
			if(nUD��.Value == 0 )
			{
				MessageBox.Show("�K�{���ځi���j�����͂���Ă��܂���","���̓`�F�b�N",MessageBoxButtons.OK);
				nUD��.Focus();
				return;
			}

// ADD 2009.03.02 ���s�j���� �d�ʂO���͎��̕s����� START
			//�˗�����̌���
			s�˗���b�c = tex�˗���R�[�h.Text;
			�˗��區�ڃN���A�Q();
			tex�˗���R�[�h.Text = s�˗���b�c;
			�˗��匟��();
			//�˗���������͐����悪���݂��Ȃ��ꍇ
			if(tex�˗��吿����.Text.Trim().Length == 0){
// MOD 2009.08.25 ���s�j���� �G���g���[�o�^�ł̐�����̑��݃`�F�b�N�̒ǉ� START
// MOD 2010.09.07 ���s�j���� ������`�F�b�N�̕\���ύX START
//				MessageBox.Show("���͂��ꂽ���˗���R�[�h�̐�����̓}�X�^�ɑ��݂��܂���"
//					,"���̓`�F�b�N",MessageBoxButtons.OK);
				string s������b�c = tex������R�[�h.Text.Trim();
				if(tex�����敔�ۃR�[�h.Text.Trim().Length > 0){
					s������b�c += "-" + tex�����敔�ۃR�[�h.Text.Trim();
				}
				MessageBox.Show("���͂��ꂽ���˗���̐�����["+s������b�c+"]�͓o�^����Ă��܂���"
					,"���̓`�F�b�N",MessageBoxButtons.OK);
// MOD 2010.09.07 ���s�j���� ������`�F�b�N�̕\���ύX END
				tex�˗���R�[�h.Focus();
// MOD 2009.08.25 ���s�j���� �G���g���[�o�^�ł̐�����̑��݃`�F�b�N�̒ǉ� END
				return;
			}
			panel2.Refresh();
// ADD 2009.03.02 ���s�j���� �d�ʂO���͎��̕s����� END
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� START
			// ���`�X�V���[�h�ŊJ���ꂽ�ꍇ
			if(i���^�m�n > 0){
				if(s�C���O_�˗���b�c == tex�˗���R�[�h.Text.TrimEnd()){
					if(s�C���O_������b�c != tex������R�[�h.Text.TrimEnd()
					|| s�C���O_�����敔�� != tex�����敔�ۃR�[�h.Text.TrimEnd()
					|| s�C���O_�����於   != tex�˗��吿����.Text.TrimEnd()){
						MessageBox.Show(
							"�����悪�A���˗�����̍ŐV�̐�����ɕύX����܂����@"
							,"���̓`�F�b�N"
							,MessageBoxButtons.OK
							,MessageBoxIcon.Information);
					}
				}
			}
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� END


// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
			if(gs�d�ʓ��͐��� == "1"){
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
// MOD 2010.11.01 ���s�j���� ���˗�����̏d�ʒl�O�Ή� START
				if(d�d�� > 0){
// MOD 2010.11.01 ���s�j���� ���˗�����̏d�ʒl�O�Ή� END
// MOD 2005.05.12 ���s�j�����J �d�ʂ��O�̏ꍇ�A�� * �˗���̏d�� START
//			if(nUD�d��.Text.Length == 0 )
// MOD 2005.09.02 ���s�j�����J Value��Text�� START
//			if(nUD�d��.Text.Length == 0 || nUD�d��.Value == 0)
// MOD 2009.03.02 ���s�j���� �d�ʂO���͎��̕s����� START
//			if(nUD�d��.Text.Length == 0 || nUD�d��.Text == "0")
					if(nUD�d��.Text.Length == 0 || nUD�d��.Text == "0"
						 || nUD�d��.Text.Replace("0","").Length == 0)
// MOD 2009.03.02 ���s�j���� �d�ʂO���͎��̕s����� END
// MOD 2005.09.02 ���s�j�����J Value��Text�� END
					{
// MOD 2010.09.24 ���s�j���� �d�ʎ����v�Z���̏���G���[�Ή� START
////				nUD�d��.Value = 0;
//				nUD�d��.Value = nUD��.Value * d�d��;
//// ADD 2009.03.02 ���s�j���� �d�ʂO���͎��̕s����� START
//				nUD�d��.Text = (nUD��.Value * d�d��).ToString();
//				nUD�d��.Refresh();
//// ADD 2009.03.02 ���s�j���� �d�ʂO���͎��̕s����� END
						if(nUD��.Value * d�d�� > nUD�d��.Maximum){
							string sMsg = "";
							if(i�ː��e�f == 0){
								sMsg = "�ː��̏���l "+nUD�d��.Maximum+" �𒴂��܂���\n"
									 + "���܂��͂��˗���̍ː��̐ݒ�����������Ă��������@";
							}else{
								sMsg = "�d�ʂ̏���l "+nUD�d��.Maximum+" �𒴂��܂���\n"
									 + "���܂��͂��˗���̏d�ʂ̐ݒ�����������Ă��������@";
							}
							MessageBox.Show(sMsg,"���̓`�F�b�N",MessageBoxButtons.OK);
							nUD��.Focus();
							return;
						}else{
							nUD�d��.Value = nUD��.Value * d�d��;
							nUD�d��.Text = (nUD��.Value * d�d��).ToString();
							nUD�d��.Refresh();
						}
// MOD 2010.09.24 ���s�j���� �d�ʎ����v�Z���̏���G���[�Ή� END
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� START
					}else{
						// �X�V���[�h or ���`�Q�ƃ��[�h�ŊJ���ꂽ�ꍇ
						if(i���^�m�n > 0){
							//�����ύX����A�˗���d�ʂ̌v�Z�l���قȂ�ꍇ
							if(s�C���O_�� != nUD��.Text.TrimEnd()){
								if(nUD�d��.Value != nUD��.Value * d�d��){
									string sMsg = "";
									if(i�ː��e�f == 0){
										sMsg = "�����ύX����܂����B �ː��� "
										+ nUD��.Value * d�d�� +" �ɕύX���܂����H�@";
									}else{
										sMsg = "�����ύX����܂����B �d�ʂ� "
										+ nUD��.Value * d�d�� +" �ɕύX���܂����H�@";
									}
									DialogResult rstJyuryo
									 = MessageBox.Show(sMsg
										,"���̓`�F�b�N"
										,MessageBoxButtons.YesNoCancel
										,MessageBoxIcon.Information);
									if(rstJyuryo == DialogResult.Yes){
// MOD 2010.09.24 ���s�j���� �d�ʎ����v�Z���̏���G���[�Ή� START
//								nUD�d��.Value = nUD��.Value * d�d��;
										if(nUD��.Value * d�d�� > nUD�d��.Maximum){
											if(i�ː��e�f == 0){
												sMsg = "�ː��̏���l "+nUD�d��.Maximum+" �𒴂��܂���\n"
													 + "���܂��͂��˗���̍ː��̐ݒ�����������Ă��������@";
											}else{
												sMsg = "�d�ʂ̏���l "+nUD�d��.Maximum+" �𒴂��܂���\n"
													 + "���܂��͂��˗���̏d�ʂ̐ݒ�����������Ă��������@";
											}
											MessageBox.Show(sMsg,"���̓`�F�b�N",MessageBoxButtons.OK);
											nUD��.Focus();
											return;
										}else{
											nUD�d��.Value = nUD��.Value * d�d��;
											nUD�d��.Text = (nUD��.Value * d�d��).ToString();
											nUD�d��.Refresh();
										}
// MOD 2010.09.24 ���s�j���� �d�ʎ����v�Z���̏���G���[�Ή� END
									}else if(rstJyuryo == DialogResult.No){
										;
									}else{
										return;
									}
								}
							}
						}
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� END
					}
// MOD 2005.05.12 ���s�j�����J �d�ʂ��O�̏ꍇ�A�� * �˗���̏d�� END
// MOD 2010.11.01 ���s�j���� ���˗�����̏d�ʒl�O�Ή� START
				}
// MOD 2010.11.01 ���s�j���� ���˗�����̏d�ʒl�O�Ή� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
			}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END

// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
			if(gs�d�ʓ��͐��� == "1"){
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
// MOD 2005.05.18 ���s�j�����J �ː��ǉ� START
//				if(!�͈̓`�F�b�N(nUD�d��,"�d��")) return;
				if(i�ː��e�f == 0)
				{
					if(!�͈̓`�F�b�N(nUD�d��,"�ː�")) return;
				}
				else
				{
					if(!�͈̓`�F�b�N(nUD�d��,"�d��")) return;
				}
// MOD 2005.05.18 ���s�j�����J �ː��ǉ� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
			}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END

			if(nUD�ی����z.Text.Length == 0 )
			{
				nUD�ی����z.Value = 0;
			}
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX START
//			if(!�͈̓`�F�b�N(nUD�ی����z,"�ی����z")) return;
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) START
//			if(!�͈̓`�F�b�N(nUD�ی����z,"�ی����z�i���~�j",0,30,"")) return;
			if(!�͈̓`�F�b�N(nUD�ی����z,"�ی����z�i���~�j",0,gl�ی����z���,"")) return;
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) END
//			nUD�ی����z.Refresh();
//			if(nUD�ی����z.Value > 30){
//				MessageBox.Show("�ی����z�i���~�j�́A30�ȉ�����͂��Ă��������@"
//					, "���̓`�F�b�N", MessageBoxButtons.OK);
//				nUD�ی����z.Focus();
//				return;
//			}
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX END
// MOD 2016.06.10 BEVAS�j���{ �ی������̓`�F�b�N�@�\�̒ǉ� START
			//�G���g���[�I�v�V�����F�u�ی����z�v���ڂ��u���͂���v�Ƀ`�F�b�N
			if(!gs�I�v�V����[10].Equals("1"))
			{
				//�G���g���[�I�v�V�����F�u�ی����z���̓`�F�b�N�v���ڂ��u�`�F�b�N����v�Ƀ`�F�b�N
				if(!gs�I�v�V����[24].Equals("1"))
				{
					//�ی����̓��̓`�F�b�N���s�Ȃ�
					long l�ی��� = 0L;
					try
					{
						l�ی��� = long.Parse(nUD�ی����z.Value.ToString().Replace(",", ""));
					}
					catch(Exception ){}
					if(l�ی��� >= gl�ی����z�`�F�b�N�)
					{
						string s�ی����`�F�b�NMsg =
									"�ی����z���y" + gl�ی����z�`�F�b�N�.ToString().Replace(",", "") + "���~�z�ȏ�œ��͂���Ă��܂��B\n" +
									"�������p�����܂����H\n" +
									"�@�����̃��b�Z�[�W���\���ɂ���ɂ́A\n" +
									"�@�@�G���g���[�I�v�V�����́u�ی����z���̓`�F�b�N�v���ڂ�\n" +
									"�@�@�w�`�F�b�N���Ȃ��x�ɂ��Ă��������B";
						DialogResult ret�ی��� = MessageBox.Show(s�ی����`�F�b�NMsg, "�ی����z���̓`�F�b�N", MessageBoxButtons.YesNo);
						if(ret�ی��� == DialogResult.No)
						{
							//�m�������n�{�^���N���b�N���@���@�����𒆒f
							//���m�͂��n�{�^���N���b�N���@���@�������Ȃ�
							nUD�ی����z.Focus();
							return;
						}
					}
				}
			}
// MOD 2016.06.10 BEVAS�j���{ �ی������̓`�F�b�N�@�\�̒ǉ� END

			//�X�֔ԍ����݃`�F�b�N
			string s�X�֔ԍ� = tex�͂���X�֔ԍ��P.Text + tex�͂���X�֔ԍ��Q.Text;
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sRet = {""};
			try
			{
// MOD 2015.05.07 BEVAS�j�O�c ���q�^���X�֔ԍ����݃`�F�b�N�Ή� START
				//if(sv_address == null) sv_address = new is2address.Service1();
				//sRet = sv_address.Get_byPostcode2(gsa���[�U,s�X�֔ԍ�);
				sRet = �b�l�P�S�X�֔ԍ����݃`�F�b�N(s�X�֔ԍ�);
// MOD 2015.05.07 BEVAS�j�O�c ���q�^���X�֔ԍ����݃`�F�b�N�Ή� END
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				sRet[0] = gs�ʐM�G���[;
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				sRet[0] = "�ʐM�G���[�F" + ex.Message;
			}
			Cursor = System.Windows.Forms.Cursors.Default;

			if(sRet[0].Length != 4)
			{
				if(sRet[0].Equals("�Y���f�[�^������܂���"))
					sRet[0] = "�X�֔ԍ������݂��܂���";
				tex���b�Z�[�W.Text = sRet[0];
				�r�[�v��();
				tex�͂���X�֔ԍ��P.Focus();
				return;
			}

// DEL 2009.03.02 ���s�j���� �d�ʂO���͎��̕s����� START
//// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� START
//			//�˗�����̌���
//			s�˗���b�c = tex�˗���R�[�h.Text;
//			�˗��區�ڃN���A();
//			tex�˗���R�[�h.Text = s�˗���b�c;
//			�˗��匟��();
//			//�˗���������͐����悪���݂��Ȃ��ꍇ
//			if(tex�˗��吿����.Text.Trim().Length == 0){
//				return;
//			}
//// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� END
// DEL 2009.03.02 ���s�j���� �d�ʂO���͎��̕s����� END


// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
			if(gs�d�ʓ��͐��� == "1"){
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
// ADD 2005.05.17 ���s�j�����J �ː����d�ʂ� START
				if(i�ː��e�f == 0)
				{
					s�d�� = "0";
					s�ː� = nUD�d��.Value.ToString();
				}
				else
				{
					s�d�� = nUD�d��.Value.ToString();
					s�ː� = "0";
				}
// ADD 2005.05.17 ���s�j�����J �ː����d�ʂ� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
			}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END

// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� START
			if(tex�͂���Z���P.Text.Equals("�����x�X�~�߁���"))
			{
				/** �x�X�~�߂̏o�א��^������͂ł��悤�Ƃ������̍l�� */

				// �͂���Z���R�̓��̓`�F�b�N
				if(tex�͂���Z���R.Text.Trim().Equals(""))
				{
					// �͂���Z���R�ɉ������͂���Ă��Ȃ�
					tex���b�Z�[�W.Text = "�x�X�~�߂́A�x�X�~�߃{�^���ɂ����͂ł��肢�v���܂��B";
					�r�[�v��();
					tex�͂���Z���P.Focus();
					Cursor = System.Windows.Forms.Cursors.Default;
					return;
				}

				// �b�l�P�O���݃`�F�b�N
				string[] sChkList = new string[2];
				try
				{
					if(sv_syukka == null)
					{
						sv_syukka = new is2syukka.Service1();
					}
					sChkList = sv_syukka.CheckCM10_GeneralDelivery(gsa���[�U, tex�͂���Z���R.Text, s�X�֔ԍ�);

					if(sChkList[0].Length == 4)
					{
						// ����I����
						tex�͂���Z���Q.Text = sChkList[1] + "�~��";
					}
					else
					{
						// �ُ�I����
						tex���b�Z�[�W.Text = "�x�X�~�߂́A�x�X�~�߃{�^���ɂ����͂ł��肢�v���܂��B";
						�r�[�v��();
						tex�͂���Z���P.Focus();
						Cursor = System.Windows.Forms.Cursors.Default;
						return;
					}
				}
				catch (System.Net.WebException)
				{
					sChkList[0] = gs�ʐM�G���[;
					Cursor = System.Windows.Forms.Cursors.Default;
					tex���b�Z�[�W.Text = sChkList[0];
					tex�͂���Z���P.Focus();
					�r�[�v��();
					return;
				}
				catch (Exception ex)
				{
					sChkList[0] = "�ʐM�G���[�F" + ex.Message;
					Cursor = System.Windows.Forms.Cursors.Default;
					tex���b�Z�[�W.Text = sChkList[0];
					tex�͂���Z���P.Focus();
					�r�[�v��();
					return;
				}
			}
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� END

			string[] s�o�ׂc = {
				gs����b�c,
				gs����b�c,
				nUD�o�^�ԍ�.Value.ToString(),
				s�X�V�N����,
				tex���^��.Text.Trim(),
				s�t�@�C����,
				tex�͂���R�[�h.Text.Trim(),
				tex�͂���d�b�ԍ��P.Text.Trim(),
				tex�͂���d�b�ԍ��Q.Text.Trim(),
				tex�͂���d�b�ԍ��R.Text.Trim(),
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//				tex�͂���Z���P.Text.Trim(),
//				tex�͂���Z���Q.Text.Trim(),
//				tex�͂���Z���R.Text.Trim(),
//				tex�͂��於�O�P.Text.Trim(),
//				tex�͂��於�O�Q.Text.Trim(),
				tex�͂���Z���P.Text.TrimEnd(),
				tex�͂���Z���Q.Text.TrimEnd(),
				tex�͂���Z���R.Text.TrimEnd(),
				tex�͂��於�O�P.Text.TrimEnd(),
				tex�͂��於�O�Q.Text.TrimEnd(),
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
				tex�͂���X�֔ԍ��P.Text.Trim(),
				tex�͂���X�֔ԍ��Q.Text.Trim(),
				tex�˗���R�[�h.Text.Trim(),
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//				tex�˗��啔��.Text.Trim(),
				tex�˗��啔��.Text.TrimEnd(),
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
				nUD��.Value.ToString(),
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� START
//// MOD 2005.05.17 ���s�j�����J �ː��ǉ� START
////				nUD�d��.Value.ToString(),
//				s�d��.Trim(),
//// MOD 2005.05.17 ���s�j�����J �ː��ǉ� START
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
//				"0",
				(gs�d�ʓ��͐��� == "1") ? s�d��.Trim() : "0",
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� END
				tex�A�����e.Text.TrimEnd(),
				tex�A�����q.Text.TrimEnd(),
				tex�L�����P.Text.TrimEnd(),
				tex�L�����Q.Text.TrimEnd(),
				tex�L�����R.Text.TrimEnd(),
				nUD�ی����z.Value.ToString(),
				"���^�o�^",
				gs���p�҂b�c,
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� START
//// ADD 2005.05.17 ���s�j�����J �ː��ǉ� START
//				s�ː�.Trim()
//// ADD 2005.05.17 ���s�j�����J �ː��ǉ� START
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
//				"0"
				(gs�d�ʓ��͐��� == "1") ? s�ː�.Trim() : "0"
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� END
// ADD 2005.05.30 ���s�j�ɉ� �A�����i�R�[�h�ǉ� START
				,s�A�����i�e�R�[�h,s�A�����i�q�R�[�h
// ADD 2005.05.30 ���s�j�ɉ� �A�����i�R�[�h�ǉ� START
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
				,tex�L�����S.Text.TrimEnd()
				,tex�L�����T.Text.TrimEnd()
				,tex�L�����U.Text.TrimEnd()
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
			};

			for(int iCnt = 0 ; iCnt < s�o�ׂc.Length; iCnt++ )
			{
				if( s�o�ׂc[iCnt] == null 
					|| s�o�ׂc[iCnt].Length == 0 ) s�o�ׂc[iCnt] = " ";
			}

			string[] sIUList = new string[5];
			DialogResult result;
			if(!b�X�V�e�f)
			{
//				result = MessageBox.Show("�V�K�o�^���܂����H","�o�^",MessageBoxButtons.YesNo);
//				if(result == DialogResult.Yes)
//				{
					// �J�[�\���������v�ɂ���
					Cursor = System.Windows.Forms.Cursors.AppStarting;
					try
					{
						tex���b�Z�[�W.Text = "�o�^���D�D�D";
						if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
						sIUList = sv_hinagata.Ins_hinagata(gsa���[�U,s�o�ׂc);
					}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
					catch (System.Net.WebException)
					{
						sIUList[0] = gs�ʐM�G���[;
					}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
					catch (Exception ex)
					{
						sIUList[0] = "�ʐM�G���[�F" + ex.Message;
					}
					// �J�[�\�����f�t�H���g�ɖ߂�
					Cursor = System.Windows.Forms.Cursors.Default;

					// �ُ�I����
					if(sIUList[0] == "0")
					{
						tex���b�Z�[�W.Text = "";
						MessageBox.Show("���͂��ꂽ���˗���R�[�h�̓}�X�^�ɑ��݂��܂���",
										"�o�^",MessageBoxButtons.OK);
						tex�˗���R�[�h.Focus();
						return;
					}
					if(sIUList[0] == "1")
					{
						tex���b�Z�[�W.Text = "";
						MessageBox.Show("����̃R�[�h�����ɓo�^����Ă��܂�",
										"�o�^",MessageBoxButtons.OK);
						nUD�o�^�ԍ�.Focus();
						return;
					}

					tex���b�Z�[�W.Text = sIUList[0];
					if(sIUList[0].Length == 4)
					{
						i���^�m�n       = 0;
						s�o�^��         = "";
						s�W���[�i���m�n = "";
						btn���_Click(sender,e);
					}
					else
					{
						�r�[�v��();
						return;
					}

					// ����I����
//					Close();
//				}

			}
			else
			{
				result = MessageBox.Show("���ɑ��݂���f�[�^�ɏ㏑�����܂����H","�X�V",MessageBoxButtons.YesNo);
				if(result == DialogResult.Yes)
				{
					// �J�[�\���������v�ɂ���
					Cursor = System.Windows.Forms.Cursors.AppStarting;
					try
					{
						tex���b�Z�[�W.Text = "�X�V���D�D�D";
						if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
						sIUList = sv_hinagata.Upd_hinagata(gsa���[�U,s�o�ׂc);
					}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
					catch (System.Net.WebException)
					{
						sIUList[0] = gs�ʐM�G���[;
					}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
					catch (Exception ex)
					{
						sIUList[0] = "�ʐM�G���[�F" + ex.Message;
					}
					// �J�[�\�����f�t�H���g�ɖ߂�
					Cursor = System.Windows.Forms.Cursors.Default;

					// �G���[��
					if(sIUList[0] == "0")
					{
						tex�˗���R�[�h.Focus();
						tex���b�Z�[�W.Text = "";
						MessageBox.Show("���͂��ꂽ���˗���R�[�h�̓}�X�^�ɑ��݂��܂���",
										"�X�V",MessageBoxButtons.OK);
						return;
					}

					tex���b�Z�[�W.Text = sIUList[0];
					if(sIUList[0].Length != 4)
					{
						�r�[�v��();
						return;
					}

					// ����I����
					Close();
				}
			}

		}

		private void �o�׌���()
		{
			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sList = {""};
			try
			{
				tex���b�Z�[�W.Text = "�������D�D�D";
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
				sList = sv_syukka.Get_Ssyukka(gsa���[�U,gs����b�c,gs����b�c,s�o�^��,int.Parse(s�W���[�i���m�n));
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				sList[0] = gs�ʐM�G���[;
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				sList[0] = "�ʐM�G���[�F" + ex.Message;
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;

// MOD 2009.09.09 ���s�j���� ��ʕ\���s��̒��� 
//			tex���b�Z�[�W.Text = sList[0];
			if(sList[0].Length == 4) tex���b�Z�[�W.Text = "";

			// �ُ�I����
// MOD 2005.05.13 ���s�j�����J �˗���d�ʒǉ� START
//			if(sList[0].Length != 4 || sList[38] == "I")
//			if(sList[0].Length != 4 || sList[39] == "I")
// MOD 2005.05.13 ���s�j�����J �˗���d�ʒǉ� END
// MOD 2005.05.30 ���s�j�ɉ� �A�����i�R�[�h�ǉ� START
// MOD 2005.05.17 ���s�j�����J �ː��ǉ� START
//			if(sList[0].Length != 4 || sList[39] == "I")
//			if(sList[0].Length != 4 || sList[41] == "I")
// MOD 2009.02.06 ���s�j���� �w����敪�ǉ� START
//			if(sList[0].Length != 4 || sList[44] == "I")
			if(sList[0].Length != 4 || sList[45] == "I")
// MOD 2009.02.06 ���s�j���� �w����敪�ǉ� END
// MOD 2005.05.17 ���s�j�����J �ː��ǉ� END
// MOD 2005.05.30 ���s�j�ɉ� �A�����i�R�[�h�ǉ� END
			{
// MOD 2009.02.06 ���s�j���� �G���g���I�v�V�����̍��ڒǉ� START
//				�r�[�v��();
//
//				Close();
				tex���b�Z�[�W.Text = sList[0];
				�r�[�v��();
				tex�˗���R�[�h.Focus();
// MOD 2009.09.04 ���s�j���� Vista�Ή�(TAB�Ή�����) END
//				if(tex�˗���R�[�h.TabStop == false)
//					System.Windows.Forms.SendKeys.SendWait("{TAB}");
				if(tex�˗���R�[�h.TabStop == false){
// MOD 2011.08.02 ���s�j���� �e���ڂ̓��͕s�Ή��i�s������j START
//					this.SelectNextControl(this.ActiveControl, true, true, true, true);
					this.SelectNextControl(tex�˗���R�[�h, true, true, true, true);
// MOD 2011.08.02 ���s�j���� �e���ڂ̓��͕s�Ή��i�s������j END
				}
// MOD 2009.09.04 ���s�j���� Vista�Ή�(TAB�Ή�����) END
				return;
// MOD 2009.02.06 ���s�j���� �G���g���I�v�V�����̍��ڒǉ� END
			}

//			tex���q�l�Ǘ��ԍ�.Text    = sList[2];
			tex�͂���R�[�h.Text      = sList[3];
			tex�͂���d�b�ԍ��P.Text  = sList[4];
			tex�͂���d�b�ԍ��Q.Text  = sList[5];
			tex�͂���d�b�ԍ��R.Text  = sList[6];
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//			tex�͂���Z���P.Text      = sList[7];
//			tex�͂���Z���Q.Text      = sList[8];
//			tex�͂���Z���R.Text      = sList[9];
//			tex�͂��於�O�P.Text      = sList[10];
//			tex�͂��於�O�Q.Text      = sList[11];
			if(gs�I�v�V����[18].Equals("1")){
				tex�͂���Z���P.Text  = sList[7].TrimEnd();
				tex�͂���Z���Q.Text  = sList[8].TrimEnd();
				tex�͂���Z���R.Text  = sList[9].TrimEnd();
				tex�͂��於�O�P.Text  = sList[10].TrimEnd();
				tex�͂��於�O�Q.Text  = sList[11].TrimEnd();
			}else{
				tex�͂���Z���P.Text  = sList[7].Trim();
				tex�͂���Z���Q.Text  = sList[8].Trim();
				tex�͂���Z���R.Text  = sList[9].Trim();
				tex�͂��於�O�P.Text  = sList[10].Trim();
				tex�͂��於�O�Q.Text  = sList[11].Trim();
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
			tex�͂���X�֔ԍ��P.Text  = sList[12];
			tex�͂���X�֔ԍ��Q.Text  = sList[13];
			tex�˗���R�[�h.Text      = sList[14];
//			tex�˗��吿����.Text      = sList[15];
// ADD 2005.05.30 ���s�j�ɉ� �A�����i�R�[�h�ǉ� START
			s�A�����i�e�R�[�h         = sList[41];
			s�A�����i�q�R�[�h         = sList[42];
			�A�����i���d�ʐ���();
// ADD 2005.05.30 ���s�j�ɉ� �A�����i�R�[�h�ǉ� END
			nUD��.Value             = decimal.Parse(sList[16]);
// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� START
//// MOD 2005.05.17 ���s�j�����J �ː��ǉ� START
////			nUD�d��.Value             = decimal.Parse(sList[17]);
//			if(i�ː��e�f == 0)
//				nUD�d��.Value             = decimal.Parse(sList[39]);
//			else
//				nUD�d��.Value             = decimal.Parse(sList[17]);
//// MOD 2005.05.17 ���s�j�����J �ː��ǉ� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
			if(gs�d�ʓ��͐��� == "1"){
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
				if(i�ː��e�f == 0){
					nUD�d��.Value             = decimal.Parse(sList[39]);
					if(decimal.Parse(sList[17]) > 0){
						tex���b�Z�[�W.Text = "���[�j���O�F�d��(kg)�����͂���Ă���ɂ�������炸�A\r\n"
											+ "�G���g���[�I�v�V�����ōː����I������Ă��܂�";
						�r�[�v��();
//					MessageBox.Show("�d��(kg)�����͂���Ă���ɂ�������炸�A\n"
//									+ "�G���g���[�I�v�V�����ōː����I������Ă��܂�"
//									,"�G���g���[�I�v�V�����ݒ胏�[�j���O"
//									,MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}else{
					nUD�d��.Value             = decimal.Parse(sList[17]);
					if(decimal.Parse(sList[39]) > 0){
						tex���b�Z�[�W.Text = "���[�j���O�F�ː������͂���Ă���ɂ�������炸�A\r\n"
											+ "�G���g���[�I�v�V�����ŏd��(kg)���I������Ă��܂�";
						�r�[�v��();
//					MessageBox.Show("�ː������͂���Ă���ɂ�������炸�A\n"
//									+ "�G���g���[�I�v�V�����ŏd��(kg)���I������Ă��܂�"
//									,"�G���g���[�I�v�V�����ݒ胏�[�j���O"
//									,MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
			}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END

			tex�A�����e.Text          = sList[19];
			tex�A�����q.Text          = sList[20];
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//			tex�L�����P.Text          = sList[21];
//			tex�L�����Q.Text          = sList[22];
//			tex�L�����R.Text          = sList[23];
			if(gs�I�v�V����[18].Equals("1")){
				tex�L�����P.Text      = sList[21].TrimEnd();
				tex�L�����Q.Text      = sList[22].TrimEnd();
				tex�L�����R.Text      = sList[23].TrimEnd();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
				if(sList.Length > 53){
					tex�L�����S.Text  = sList[53].TrimEnd();
					tex�L�����T.Text  = sList[54].TrimEnd();
					tex�L�����U.Text  = sList[55].TrimEnd();
				}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
			}else{
				tex�L�����P.Text      = sList[21].Trim();
				tex�L�����Q.Text      = sList[22].Trim();
				tex�L�����R.Text      = sList[23].Trim();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
				if(sList.Length > 53){
					tex�L�����S.Text  = sList[53].Trim();
					tex�L�����T.Text  = sList[54].Trim();
					tex�L�����U.Text  = sList[55].Trim();
				}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX START
//			nUD�ی����z.Value         = decimal.Parse(sList[24]);
			decimal d�ی����z         = decimal.Parse(sList[24]);
			if(d�ی����z < 0){
				nUD�ی����z.Minimum   = d�ی����z;
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) START
//			}else if(d�ی����z > 30){
			}else if(d�ی����z > gl�ی����z���){
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) END
				nUD�ی����z.Maximum   = d�ی����z;
			}
			nUD�ی����z.Value         = d�ی����z;
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX END
			tex�˗���d�b�ԍ��P.Text  = sList[26];
			tex�˗���d�b�ԍ��Q.Text  = sList[27];
			tex�˗���d�b�ԍ��R.Text  = sList[28];
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//			tex�˗���Z���P.Text      = sList[29];
//			tex�˗���Z���Q.Text      = sList[30];
//			tex�˗��喼�O�P.Text      = sList[31];
//			tex�˗��喼�O�Q.Text      = sList[32];
			if(gs�I�v�V����[18].Equals("1")){
				tex�˗���Z���P.Text  = sList[29].TrimEnd();
				tex�˗���Z���Q.Text  = sList[30].TrimEnd();
				tex�˗��喼�O�P.Text  = sList[31].TrimEnd();
				tex�˗��喼�O�Q.Text  = sList[32].TrimEnd();
			}else{
				tex�˗���Z���P.Text  = sList[29].Trim();
				tex�˗���Z���Q.Text  = sList[30].Trim();
				tex�˗��喼�O�P.Text  = sList[31].Trim();
				tex�˗��喼�O�Q.Text  = sList[32].Trim();
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
			tex�˗���X�֔ԍ��P.Text  = sList[33];
			tex�˗���X�֔ԍ��Q.Text  = sList[34];
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� START
			tex������R�[�h.Text      = sList[35];
			tex�����敔�ۃR�[�h.Text  = sList[36];
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� END
			if(sList[35] != " ")
			{
				int iCnt;
				if(gsa������b�c != null)
				{
					for(iCnt = 0 ; iCnt < gsa������b�c.Length; iCnt++ )
					{
						if(gsa������b�c[iCnt] == null || gsa�����敔�ۂb�c[iCnt] == null)
						{
							tex�˗��吿����.Text = "";
						}
						else
						{
							if(gsa������b�c[iCnt] == sList[35] && gsa�����敔�ۂb�c[iCnt] == sList[36])
							{
								tex�˗��吿����.Text = gsa�����敔�ۖ�[iCnt];
								break;
							}
						}
					}
				}
			}
// MOD 2009.09.09 ���s�j���� ��ʕ\���s��̒��� 
//			tex���b�Z�[�W.Text = "";
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//			tex�˗��啔��.Text = sList[37];
			if(gs�I�v�V����[18].Equals("1")){
				tex�˗��啔��.Text = sList[37].TrimEnd();
			}else{
				tex�˗��啔��.Text = sList[37].Trim();
			}
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� START
			// ���s�̐��������\��
			tex������R�[�h.Text     = sList[47];
			tex�����敔�ۃR�[�h.Text = sList[48];
			tex�˗��吿����.Text     = sList[15];
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� END

// MOD 2009.09.09 ���s�j���� ��ʕ\���s��̒��� 
			// �͂���R�[�h�Ƀt�H�[�J�X
			s�˗���b�c         = tex�˗���R�[�h.Text;
			s�O�񌟍��˗���b�c = tex�˗���R�[�h.Text;

// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� STRAT
//// ADD 2005.05.12 ���s�j�����J �˗���d�� START
//// MOD 2005.05.17 ���s�j�����J �ː��ǉ� START
////			d�d�� = decimal.Parse(sList[38]);
//			if(i�ː��e�f == 0)
//				d�d�� = decimal.Parse(sList[40]);
//			else
//				d�d�� = decimal.Parse(sList[38]);
//// MOD 2005.05.17 ���s�j�����J �ː��ǉ� END
//// ADD 2005.05.12 ���s�j�����J �˗���d�� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
			if(gs�d�ʓ��͐��� == "1"){
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
				if(i�ː��e�f == 0){ 
				// �ː��̎�
					d�d�� = decimal.Parse(sList[40]);
					if(d�d�� == 0){
						// �d�ʁ��W
						d�d�� = decimal.Parse(sList[38]) / 8;
// MOD 2011.03.11 ���s�j���� �ː��v�Z�̕␳ START
						d�d�� = decimal.Truncate(d�d�� + decimal.Parse("0.9"));
// MOD 2011.03.11 ���s�j���� �ː��v�Z�̕␳ END
					}
				}else{
				// �d�ʂ̎�
					d�d�� = decimal.Parse(sList[38]);
					if(d�d�� == 0){
						// �ː��~�W
						d�d�� = decimal.Parse(sList[40]) * 8;
					}
				}
// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
			}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END

		}

// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX START
		private void �A�����i�q�`�F�b�N(string sCode)
		{
			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sList = {""};
			try
			{
				if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
				if (gs����b�c.Substring(0,1) != "J"){
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
					sList = sv_kiji.Get_kiji(gsa���[�U,"yusoshohin",sCode);
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
				}else{
					sList = sv_kiji.Get_kiji(gsa���[�U,"Jyusoshohin",sCode);
				}
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
			}
			catch (System.Net.WebException)
			{
				sList[0] = gs�ʐM�G���[;
			}
			catch (Exception ex)
			{
				sList[0] = "�ʐM�G���[�F" + ex.Message;
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;

			// �G���[��
			if(!sList[0].Equals("����I��") && !sList[0].Equals("�Y���f�[�^������܂���"))
			{
				�r�[�v��();
				tex���b�Z�[�W.Text = sList[0];
				tex�A���R�[�h�q.Focus();
				return;
			}

			if(sList.Length == 1)
			{
				tex�A���R�[�h�q.Text = " ";
				tex�A�����q.Text = "";
				s�A�����i�q�R�[�h = " ";
				tex���b�Z�[�W.Text = "";
				tex�L���R�[�h.Focus();
			}
			else if(sList.Length == 2)
			{
				string[] s�L�� = sList[1].Split('|');
				if (s�L��.Length > 2)
				{
					tex�A���R�[�h�q.Text = s�L��[1];
					tex�A�����q.Text = s�L��[2];
					s�A�����i�q�R�[�h = s�L��[1];
				}
				tex���b�Z�[�W.Text = "";
				tex�L���R�[�h.Focus();
			}
		}
// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX END

// MOD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX START
		private void tex�A���R�[�h�e_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				// ���b�Z�[�W�̃N���A
				tex���b�Z�[�W.Text = "";

// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX START
				// �󔒏���
				tex�A���R�[�h�e.Text = tex�A���R�[�h�e.Text.Trim();
//				if((tex�A���R�[�h�e.Text.Length > 0)
//					&& (tex�A�����e.Text.Trim().Length == 0
//					||  tex�A�����q.Text.Trim().Length == 0))
				if(tex�A���R�[�h�e.Text.Length > 0)
				{
//					if(!�K�{�`�F�b�N(tex�A���R�[�h�e,"�A�����i�e�R�[�h")) return;
					if(!���p�`�F�b�N(tex�A���R�[�h�e,"�A�����i�e�R�[�h")) return;

					// �J�[�\���������v�ɂ���
					Cursor = System.Windows.Forms.Cursors.AppStarting;
					string[] sList = {""};
					try
					{
						tex���b�Z�[�W.Text = "�������D�D�D";
						if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
//						sList = sv_kiji.Get_Skiji(gsa���[�U,gs����b�c,gs����b�c,tex�A���R�[�h�e.Text);
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
						if (gs����b�c.Substring(0,1) != "J"){
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
							// ����R�[�h:"yusoshohin" ����R�[�h:"0000"�Ō���
							sList = sv_kiji.Get_Skiji(gsa���[�U,"yusoshohin", "0000", tex�A���R�[�h�e.Text);
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
						}else{
							sList = sv_kiji.Get_Skiji(gsa���[�U,"Jyusoshohin", "0000", tex�A���R�[�h�e.Text);
						}
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
					}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
					catch (System.Net.WebException)
					{
						sList[0] = gs�ʐM�G���[;
					}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
					catch (Exception ex)
					{
						sList[0] = "�ʐM�G���[�F" + ex.Message;
					}
					// �J�[�\�����f�t�H���g�ɖ߂�
					Cursor = System.Windows.Forms.Cursors.Default;

					// �G���[��
					if(sList[0].Length != 2)
					{
						�r�[�v��();
						tex���b�Z�[�W.Text = sList[0];
						tex�A���R�[�h�e.Focus();
						return;
					}

					// ���݂��Ȃ���
					if(sList[3] == "I")
					{
//						�r�[�v��();
//						tex���b�Z�[�W.Text = "���͂��ꂽ�A���R�[�h�̓}�X�^�ɑ��݂��܂���B";
						tex���b�Z�[�W.Text = "";
//						MessageBox.Show("���͂��ꂽ�A���R�[�h�̓}�X�^�ɑ��݂��܂���B","�A������",MessageBoxButtons.OK);
						MessageBox.Show("���͂��ꂽ�A�����i�e�R�[�h�̓}�X�^�ɑ��݂��܂���B","�A������",MessageBoxButtons.OK);
						tex�A���R�[�h�e.Focus();
						return;
					}

					// �󔒏���
//					tex�A�����e.Text = tex�A�����e.Text.Trim();
//					tex�A�����q.Text = tex�A�����q.Text.Trim();
					if(sList[1] != null)
					{
//						if(tex�A�����e.Text.Length == 0){
//							tex�A�����e.Text = sList[1];
//							tex�A���R�[�h�e.Text = "";
//						}else if(tex�A�����q.Text .Length == 0){
//							tex�A�����q.Text = sList[1];
//							tex�A���R�[�h�e.Text = "";
//						}
						tex�A�����e.Text = sList[1];
						if (!tex�A���R�[�h�e.Text.Equals(s�A�����i�e�R�[�h))
						{
							tex�A���R�[�h�q.Text = " ";
							tex�A�����q.Text = "";
							s�A�����i�q�R�[�h = "";
						}
						s�A�����i�e�R�[�h = tex�A���R�[�h�e.Text;

						tex���b�Z�[�W.Text = "";
						tex�A���R�[�h�q.Focus();
					}
					�A�����i���d�ʐ���();
					�A�����i�q�`�F�b�N(s�A�����i�e�R�[�h);
				}
			}
			else if (e.KeyCode == Keys.Delete)
			{
				tex�A���R�[�h�e.Text = " ";
				tex�A�����e.Text = "";
				tex�A���R�[�h�q.Text = " ";
				tex�A�����q.Text = "";
				s�A�����i�e�R�[�h = "";
				s�A�����i�q�R�[�h = "";
				tex�A���R�[�h�e.Focus();
			}
		}

		private void tex�A���R�[�h�q_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				// ���b�Z�[�W�̃N���A
				tex���b�Z�[�W.Text = "";

				// �󔒏���
				tex�A���R�[�h�q.Text = tex�A���R�[�h�q.Text.Trim();
				if(tex�A���R�[�h�q.Text.Length > 0)
				{
					if(s�A�����i�e�R�[�h.Length == 0)
					{
						MessageBox.Show("�A�����i�e�R�[�h�����͂���Ă��܂���B","���̓`�F�b�N",MessageBoxButtons.OK);
						return;
					}
					if(!���p�`�F�b�N(tex�A���R�[�h�q,"�A�����i�q�R�[�h")) return;

					// �J�[�\���������v�ɂ���
					Cursor = System.Windows.Forms.Cursors.AppStarting;
					string[] sList = {""};
					try
					{
						tex���b�Z�[�W.Text = "�������D�D�D";
						if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
						if (gs����b�c.Substring(0,1) != "J"){
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
							sList = sv_kiji.Get_Skiji(gsa���[�U,"yusoshohin",s�A�����i�e�R�[�h,tex�A���R�[�h�q.Text);
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
						}else{
							sList = sv_kiji.Get_Skiji(gsa���[�U,"Jyusoshohin",s�A�����i�e�R�[�h,tex�A���R�[�h�q.Text);
						}
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
					}
					catch (System.Net.WebException)
					{
						sList[0] = gs�ʐM�G���[;
					}
					catch (Exception ex)
					{
						sList[0] = "�ʐM�G���[�F" + ex.Message;
					}
					// �J�[�\�����f�t�H���g�ɖ߂�
					Cursor = System.Windows.Forms.Cursors.Default;

					// �G���[��
					if(sList[0].Length != 2)
					{
						�r�[�v��();
						tex���b�Z�[�W.Text = sList[0];
						tex�A���R�[�h�q.Focus();
						return;
					}

					// ���݂��Ȃ���
					if(sList[3] == "I")
					{
						tex���b�Z�[�W.Text = "";
						MessageBox.Show("���͂��ꂽ�A�����i�q�R�[�h�̓}�X�^�ɑ��݂��܂���B","�A������",MessageBoxButtons.OK);
						tex�A���R�[�h�q.Focus();
						return;
					}

					if(sList[1] != null)
					{
// MOD 2005.06.17 ���s�j�����J �w�莞�ԓ��͒ǉ� START
//						tex�A�����q.Text = sList[1];
//						s�A�����i�q�R�[�h = tex�A���R�[�h�q.Text;
//						tex���b�Z�[�W.Text = "";
//						tex�L���R�[�h.Focus();
						tex���b�Z�[�W.Text = "";
						if (tex�A���R�[�h�q.Text.Length > 2 && tex�A���R�[�h�q.Text.Substring(1).Equals("1X"))
						{
							if (g�w�莞�ԓ��� == null) g�w�莞�ԓ��� = new �w�莞�ԓ���();
							g�w�莞�ԓ���.Left  = this.Left + (this.Width  - g�w�莞�ԓ���.Width)  / 2;
							g�w�莞�ԓ���.Top   = this.Top  + (this.Height - g�w�莞�ԓ���.Height) / 2;
							g�w�莞�ԓ���.s�L�� = "";
							g�w�莞�ԓ���.lab���ԋ敪.Text = "���܂�";
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX START
//							string[] items = {"�P�Q","�P�R","�P�S","�P�T","�P�U","�P�V","�P�W","�P�X","�Q�O","�Q�P"};
							string[] items = {"�P�Q","�P�R","�P�S","�P�T","�P�U","�P�V","�P�W","�P�X","�Q�O"};
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX END
							g�w�莞�ԓ���.cmb�w�莞��.Items.Clear();
							g�w�莞�ԓ���.cmb�w�莞��.Items.AddRange(items);
							g�w�莞�ԓ���.cmb�w�莞��.SelectedIndex = 0;
							g�w�莞�ԓ���.ShowDialog(this);
							if (g�w�莞�ԓ���.s�L��.Length != 0)
							{
								tex�A�����q.Text = g�w�莞�ԓ���.s�L��;
								tex�L���R�[�h.Focus();
							}
							else
							{
								tex�A���R�[�h�q.Focus();
							}
						}
						else if (tex�A���R�[�h�q.Text.Length > 2 && tex�A���R�[�h�q.Text.Substring(1).Equals("2X"))
						{
							if (g�w�莞�ԓ��� == null) g�w�莞�ԓ��� = new �w�莞�ԓ���();
							g�w�莞�ԓ���.Left  = this.Left + (this.Width  - g�w�莞�ԓ���.Width)  / 2;
							g�w�莞�ԓ���.Top   = this.Top  + (this.Height - g�w�莞�ԓ���.Height) / 2;
							g�w�莞�ԓ���.s�L�� = "";
							g�w�莞�ԓ���.lab���ԋ敪.Text = "���ȍ~";
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX START
//							string[] items = {"�P�O","�P�P","�P�Q","�P�R","�P�S","�P�T","�P�U","�P�V","�P�W","�P�X"};
							string[] items = {"�P�O","�P�P","�P�Q","�P�R","�P�S","�P�T","�P�U","�P�V","�P�W"};
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX END
							g�w�莞�ԓ���.cmb�w�莞��.Items.Clear();
							g�w�莞�ԓ���.cmb�w�莞��.Items.AddRange(items);
							g�w�莞�ԓ���.cmb�w�莞��.SelectedIndex = 0;
							g�w�莞�ԓ���.ShowDialog(this);
							if (g�w�莞�ԓ���.s�L��.Length != 0)
							{
								tex�A�����q.Text = g�w�莞�ԓ���.s�L��;
								tex�L���R�[�h.Focus();
							}
							else
							{
								tex�A���R�[�h�q.Focus();
							}
						}
						else
						{
							tex�A�����q.Text = sList[1];
							tex�L���R�[�h.Focus();
						}
						s�A�����i�q�R�[�h = tex�A���R�[�h�q.Text;
// MOD 2005.06.17 ���s�j�����J �w�莞�ԓ��͒ǉ� END
					}
				}
				else if (s�A�����i�e�R�[�h.Length != 0 && tex�A�����q.Text.TrimEnd().Length == 0)
				{
					string[] sList = {""};
					try
					{
						if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
						if (gs����b�c.Substring(0,1) != "J"){
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
							sList = sv_kiji.Get_kiji(gsa���[�U,"yusoshohin",s�A�����i�e�R�[�h);
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
						}else{
							sList = sv_kiji.Get_kiji(gsa���[�U,"Jyusoshohin",s�A�����i�e�R�[�h);
						}
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� END
					}
					catch (System.Net.WebException)
					{
						sList[0] = gs�ʐM�G���[;
					}
					catch (Exception ex)
					{
						sList[0] = "�ʐM�G���[�F" + ex.Message;
					}
					// �J�[�\�����f�t�H���g�ɖ߂�
					Cursor = System.Windows.Forms.Cursors.Default;

					// �G���[��
					if(!sList[0].Equals("����I��") && !sList[0].Equals("�Y���f�[�^������܂���"))
					{
						�r�[�v��();
						tex���b�Z�[�W.Text = sList[0];
						tex�A���R�[�h�q.Focus();
						return;
					}

					if(sList.Length > 1)
					{
						if (g�L������ == null)	 g�L������ = new �L������();
						g�L������.Left  = this.Left;
						g�L������.Top   = this.Top;
						g�L������.b�A���w�� = true;
						g�L������.lab�L���^�C�g��.Text = "�A�����i����";
						//�A�����i�q����
						g�L������.s�A�����i���� = s�A�����i�e�R�[�h;

						g�L������.ShowDialog();
						if (g�L������.sKcode.Length != 0)
						{
							//�A�����i�q����
							tex�A���R�[�h�q.Text = g�L������.sKcode;
							tex�A�����q.Text = g�L������.s�L��;
							s�A�����i�q�R�[�h = g�L������.sKcode;
							tex�L���R�[�h.Focus();
						}
					}
				}
			}
			else if (e.KeyCode == Keys.Delete)
			{
				tex�A���R�[�h�e.Text = " ";
				tex�A�����e.Text = "";
				tex�A���R�[�h�q.Text = " ";
				tex�A�����q.Text = "";
				s�A�����i�e�R�[�h = "";
				s�A�����i�q�R�[�h = "";
				tex�A���R�[�h�e.Focus();
			}		
		}
// MOD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX END

		private void tex�L���R�[�h_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				// ���b�Z�[�W�̃N���A
				tex���b�Z�[�W.Text = "";

				// �󔒏���
				tex�L���R�[�h.Text = tex�L���R�[�h.Text.Trim();
				if((tex�L���R�[�h.Text.Length > 0)
					&& (tex�L�����P.Text.Trim().Length == 0
					||  tex�L�����Q.Text.Trim().Length == 0
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
//					||  tex�L�����R.Text.Trim().Length == 0))
					||  tex�L�����R.Text.Trim().Length == 0
					||  tex�L�����S.Text.Trim().Length == 0
					||  tex�L�����T.Text.Trim().Length == 0
					||  tex�L�����U.Text.Trim().Length == 0
					))
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
				{

					if(!�K�{�`�F�b�N(tex�L���R�[�h,"�L���R�[�h")) return;
					if(!���p�`�F�b�N(tex�L���R�[�h,"�L���R�[�h")) return;

					// �J�[�\���������v�ɂ���
					Cursor = System.Windows.Forms.Cursors.AppStarting;
					string[] sList = {""};
					try
					{
						tex���b�Z�[�W.Text = "�������D�D�D";
						if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
						sList = sv_kiji.Get_Skiji(gsa���[�U,gs����b�c,gs����b�c,tex�L���R�[�h.Text);
					}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
					catch (System.Net.WebException)
					{
						sList[0] = gs�ʐM�G���[;
					}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
					catch (Exception ex)
					{
						sList[0] = "�ʐM�G���[�F" + ex.Message;
					}
					// �J�[�\�����f�t�H���g�ɖ߂�
					Cursor = System.Windows.Forms.Cursors.Default;

					// �G���[��
					if(sList[0].Length != 2){
						�r�[�v��();
						tex���b�Z�[�W.Text = sList[0];
						tex�L���R�[�h.Focus();
						return;
					}

					// ���݂��Ȃ���
					if(sList[3] == "I")
					{
//						�r�[�v��();
//						tex���b�Z�[�W.Text = "���͂��ꂽ�L���R�[�h�̓}�X�^�ɑ��݂��܂���B";
						tex���b�Z�[�W.Text = "";
						MessageBox.Show("���͂��ꂽ�L���R�[�h�̓}�X�^�ɑ��݂��܂���B","�L������",MessageBoxButtons.OK);
						tex�L���R�[�h.Focus();
						return;
					}

					// �󔒏���
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//					tex�L�����P.Text = tex�L�����P.Text.Trim();
//					tex�L�����Q.Text = tex�L�����Q.Text.Trim();
//					tex�L�����R.Text = tex�L�����R.Text.Trim();
					if(gs�I�v�V����[18].Equals("1")){
						tex�L�����P.Text = tex�L�����P.Text.TrimEnd();
						tex�L�����Q.Text = tex�L�����Q.Text.TrimEnd();
						tex�L�����R.Text = tex�L�����R.Text.TrimEnd();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
						tex�L�����S.Text = tex�L�����S.Text.TrimEnd();
						tex�L�����T.Text = tex�L�����T.Text.TrimEnd();
						tex�L�����U.Text = tex�L�����U.Text.TrimEnd();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
					}else{
						tex�L�����P.Text = tex�L�����P.Text.Trim();
						tex�L�����Q.Text = tex�L�����Q.Text.Trim();
						tex�L�����R.Text = tex�L�����R.Text.Trim();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
						tex�L�����S.Text = tex�L�����S.Text.Trim();
						tex�L�����T.Text = tex�L�����T.Text.Trim();
						tex�L�����U.Text = tex�L�����U.Text.Trim();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
					}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
					if(sList[1] != null)
					{
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
//						if(tex�L�����P.Text.Length == 0)
//						{
//							tex�L�����P.Text = sList[1];
//							tex�L���R�[�h.Text = "";
//						}
//						else if(tex�L�����Q.Text.Length == 0)
//						{
//							tex�L�����Q.Text = sList[1];
//							tex�L���R�[�h.Text = "";
//						}
//						else if(tex�L�����R.Text.Length == 0)
//						{
//							tex�L�����R.Text = sList[1];
//							tex�L���R�[�h.Text = "";
//						}
						if(tex�L�����P.Text.Length == 0){
							tex�L�����P.Text   = sList[1];
							tex�L���R�[�h.Text = "";
						}else if(tex�L�����Q.Text.Length == 0){
							tex�L�����Q.Text   = sList[1];
							tex�L���R�[�h.Text = "";
						}else if(tex�L�����R.Text.Length == 0){
							tex�L�����R.Text   = sList[1];
							tex�L���R�[�h.Text = "";
// MOD 2011.08.05 ���s�j���� �L���s�̒ǉ��i�R�s�E�U�s�֑ؑΉ��j START
//						}else if(tex�L�����S.Text.Length == 0){
//							tex�L�����S.Text   = sList[1];
//							tex�L���R�[�h.Text = "";
//						}else if(tex�L�����T.Text.Length == 0){
//							tex�L�����T.Text   = sList[1];
//							tex�L���R�[�h.Text = "";
//						}else if(tex�L�����U.Text.Length == 0){
//							tex�L�����U.Text   = sList[1];
//							tex�L���R�[�h.Text = "";
// MOD 2011.09.26 ���s�j���� �L���s�̒ǉ��i�R�s�E�U�s�֑ؑΉ��j START
//						}else if(tex�L�����S.Enabled && tex�L�����S.Text.Length == 0){
//							tex�L�����S.Text   = sList[1];
//							tex�L���R�[�h.Text = "";
//						}else if(tex�L�����T.Enabled && tex�L�����T.Text.Length == 0){
//							tex�L�����T.Text   = sList[1];
//							tex�L���R�[�h.Text = "";
//						}else if(tex�L�����U.Enabled && tex�L�����U.Text.Length == 0){
//							tex�L�����U.Text   = sList[1];
//							tex�L���R�[�h.Text = "";
//// MOD 2011.08.05 ���s�j���� �L���s�̒ǉ��i�R�s�E�U�s�֑ؑΉ��j END
						// [�Q:�R�s����]�̎��̂ݓ��͕s��
						}else if(gs�I�v�V����[7] != "2" && tex�L�����S.Text.Length == 0){
							tex�L�����S.Text   = sList[1];
							tex�L���R�[�h.Text = "";
						}else if(gs�I�v�V����[7] != "2" && tex�L�����T.Text.Length == 0){
							tex�L�����T.Text   = sList[1];
							tex�L���R�[�h.Text = "";
						}else if(gs�I�v�V����[7] != "2" && tex�L�����U.Text.Length == 0){
							tex�L�����U.Text   = sList[1];
							tex�L���R�[�h.Text = "";
// MOD 2011.09.26 ���s�j���� �L���s�̒ǉ��i�R�s�E�U�s�֑ؑΉ��j END
						}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
						tex���b�Z�[�W.Text = "";
						tex�L���R�[�h.Focus();
					}
				}

			}
		}

		private void �͂��捀�ڃN���A()
		{
//			tex�͂���R�[�h.Text = "";
			tex�͂���R�[�h.Text = " ";
			tex�͂���d�b�ԍ��P.Text   = "";
			tex�͂���d�b�ԍ��Q.Text   = "";
			tex�͂���d�b�ԍ��R.Text   = "";
			tex�͂���X�֔ԍ��P.Text   = "";
			tex�͂���X�֔ԍ��Q.Text   = "";
			tex�͂���Z���P.Text       = "";
			tex�͂���Z���Q.Text       = "";
			tex�͂���Z���R.Text       = "";
			tex�͂��於�O�P.Text       = "";
			tex�͂��於�O�Q.Text       = "";
			tex���b�Z�[�W.Text   = "";
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� START
			// ���b�N������
			tex�͂���X�֔ԍ��P.Enabled = true; // �X�֔ԍ��P
			tex�͂���X�֔ԍ��Q.Enabled = true; // �X�֔ԍ��Q
			tex�͂���Z���P.Enabled = true; // �Z���P
			tex�͂���Z���Q.Enabled = true; // �Z���Q
			tex�͂���Z���R.Enabled = true; // �Z���R
			// �x�X�~�߃{�^����\���A�����{�^�����\��
			btn�x�X�~��.Visible = true;
			btn�x�X�~��.Enabled = true;
			btn�x�X�~�߉���.Visible = false;
			btn�x�X�~�߉���.Enabled = false;
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� END

		}

		private void �˗��區�ڃN���A()
		{
// MOD 2009.09.09 ���s�j���� �O�񌟍��˗���b�c�̃N���A����Ή� START
			s�O�񌟍��˗���b�c = "";
// MOD 2009.09.09 ���s�j���� �O�񌟍��˗���b�c�̃N���A����Ή� END
			tex�˗���R�[�h.Text = "";
			tex�˗���d�b�ԍ��P.Text   = "";
			tex�˗���d�b�ԍ��Q.Text   = "";
			tex�˗���d�b�ԍ��R.Text   = "";
			tex�˗���X�֔ԍ��P.Text   = "";
			tex�˗���X�֔ԍ��Q.Text   = "";
			tex�˗���Z���P.Text       = "";
			tex�˗���Z���Q.Text       = "";
			tex�˗��喼�O�P.Text       = "";
			tex�˗��喼�O�Q.Text       = "";
			tex�˗��啔��.Text         = "";
			tex�˗��吿����.Text       = "";
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� START
			tex������R�[�h.Text       = "";
			tex�����敔�ۃR�[�h.Text   = "";
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� END
			tex���b�Z�[�W.Text   = "";
		}

// MOD 2009.02.20 ���s�j���� ������R�[�h�\���@�\�̒ǉ� START
		private void �˗��區�ڃN���A�Q()
		{
// MOD 2009.09.09 ���s�j���� �O�񌟍��˗���b�c�̃N���A����Ή� START
			s�O�񌟍��˗���b�c = "";
// MOD 2009.09.09 ���s�j���� �O�񌟍��˗���b�c�̃N���A����Ή� END
//			tex�˗���R�[�h.Text = "";
			tex�˗���d�b�ԍ��P.Text   = "";
			tex�˗���d�b�ԍ��Q.Text   = "";
			tex�˗���d�b�ԍ��R.Text   = "";
			tex�˗���X�֔ԍ��P.Text   = "";
			tex�˗���X�֔ԍ��Q.Text   = "";
			tex�˗���Z���P.Text       = "";
			tex�˗���Z���Q.Text       = "";
			tex�˗��喼�O�P.Text       = "";
			tex�˗��喼�O�Q.Text       = "";
//			tex�˗��啔��.Text         = "";
			tex�˗��吿����.Text       = "";
			tex������R�[�h.Text       = "";
			tex�����敔�ۃR�[�h.Text   = "";
			tex���b�Z�[�W.Text   = "";
		}
// MOD 2009.02.20 ���s�j���� ������R�[�h�\���@�\�̒ǉ� END

		private void ���̑����ڃN���A()
		{
			tex�A���R�[�h�e.Text     = "";
			tex�A���R�[�h�q.Text     = "";
			tex�A�����e.Text       = "";
			tex�A�����q.Text       = "";
			tex�L�����P.Text     = "";
			tex�L�����Q.Text     = "";
			tex�L�����R.Text     = "";
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
			tex�L�����S.Text     = "";
			tex�L�����T.Text     = "";
			tex�L�����U.Text     = "";
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
			nUD��.Value          = 0;
			nUD�d��.Value          = 0;
			nUD�ی����z.Value      = 0;
			nUD��.Text          = "0";
			nUD�d��.Text          = "0";
			nUD�ی����z.Text      = "0";
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX START
			nUD�ی����z.Minimum   =  0;
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) START
//			nUD�ی����z.Maximum   = 30;
			nUD�ی����z.Maximum   = gl�ی����z���;
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) END
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX END
			btn�A�C�R��.Image = null;
			s�t�@�C���� = "";
// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX START
			s�A�����i�e�R�[�h      = "";
			s�A�����i�q�R�[�h      = "";
			�A�����i���d�ʐ���();
// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX END

		}

		private void �͂��挟��(bool b����)
		{
			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sList = {""};
			try
			{
				tex���b�Z�[�W.Text = "���͂��挟�����D�D�D";
				if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
				sList = sv_otodoke.Get_Stodokesaki(gsa���[�U,gs����b�c,gs����b�c,s�͂���b�c);
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				sList[0] = gs�ʐM�G���[;
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				sList[0] = "�ʐM�G���[�F" + ex.Message;
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;

			if(sList[0].Length == 2)
			{
				if(sList[15] == "U")
				{
					if(!b����)
					{
						tex�͂���d�b�ԍ��P.Text = sList[2].Trim();
						tex�͂���d�b�ԍ��Q.Text = sList[3].Trim();
						tex�͂���d�b�ԍ��R.Text = sList[4].Trim();
					}
					tex�͂���X�֔ԍ��P.Text = sList[5].Trim();
					tex�͂���X�֔ԍ��Q.Text = sList[6].Trim();
					tex�͂���Z���P.Text     = sList[7].Trim();
					tex�͂���Z���Q.Text     = sList[8].Trim();
					tex�͂���Z���R.Text     = sList[9].Trim();
					tex�͂��於�O�P.Text     = sList[10].Trim();
					tex�͂��於�O�Q.Text     = sList[11].Trim();

// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� START
					/** ��U�A���ڃ��b�N��{�^���\���������� */
					tex�͂���X�֔ԍ��P.Enabled = true; // �͂���X�֔ԍ��P
					tex�͂���X�֔ԍ��Q.Enabled = true; // �͂���X�֔ԍ��Q
					tex�͂���Z���P.Enabled = true; // �͂���Z���P
					tex�͂���Z���Q.Enabled = true; // �͂���Z���Q
					tex�͂���Z���R.Enabled = true; // �͂���Z���R
					// �x�X�~�߃{�^��
					btn�x�X�~��.Visible = true;
					btn�x�X�~��.Enabled = true;
					// �x�X�~�߉����{�^��
					btn�x�X�~�߉���.Visible = false;
					btn�x�X�~�߉���.Enabled = false;

					if(tex�͂���Z���P.Text.Equals("�����x�X�~�߁���"))
					{
						// ���b�N
						tex�͂���X�֔ԍ��P.Enabled = false; // �͂���X�֔ԍ��P
						tex�͂���X�֔ԍ��Q.Enabled = false; // �͂���X�֔ԍ��Q
						tex�͂���Z���P.Enabled = false; // �͂���Z���P
						tex�͂���Z���Q.Enabled = false; // �͂���Z���Q
						tex�͂���Z���R.Enabled = false; // �͂���Z���R

						// �x�X�~�߃{�^�����\���A�����{�^����\��
						btn�x�X�~��.Visible = false;
						btn�x�X�~��.Enabled = false;
						btn�x�X�~�߉���.Visible = true;
						btn�x�X�~�߉���.Enabled = true;
					}
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� END

					tex���b�Z�[�W.Text = "";
					if(b����)
						tex�͂���Z���P.Focus();
					else					
// MOD 2009.02.06 ���s�j���؁@ �G���g���I�v�V�����̍��ڒǉ� START
//						tex�˗���R�[�h.Focus();
					{
						tex�˗���R�[�h.Focus();
// MOD 2009.09.04 ���s�j���� Vista�Ή�(TAB�Ή�����) START
//						if(tex�˗���R�[�h.TabStop == false)
//							System.Windows.Forms.SendKeys.SendWait("{TAB}");
						if(tex�˗���R�[�h.TabStop == false){
// MOD 2011.08.02 ���s�j���� �e���ڂ̓��͕s�Ή��i�s������j START
//							this.SelectNextControl(this.ActiveControl, true, true, true, true);
							this.SelectNextControl(tex�˗���R�[�h, true, true, true, true);
// MOD 2011.08.02 ���s�j���� �e���ڂ̓��͕s�Ή��i�s������j END
						}
// MOD 2009.09.04 ���s�j���� Vista�Ή�(TAB�Ή�����) END
					}
// MOD 2009.02.06 ���s�j���؁@ �G���g���I�v�V�����̍��ڒǉ� END
				}
				else
				{
//					�r�[�v��();
//					tex���b�Z�[�W.Text = "���͂��ꂽ���͂���R�[�h�̓}�X�^�ɑ��݂��܂���B";
					tex���b�Z�[�W.Text = "";
					MessageBox.Show("���͂��ꂽ���͂���R�[�h�̓}�X�^�ɑ��݂��܂���B","���͂��挟��",MessageBoxButtons.OK);
					tex�͂���R�[�h.Focus();
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

		private void �˗��匟��()
		{
			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sList = {""};
			try
			{
				tex���b�Z�[�W.Text = "���˗��匟�����D�D�D";
				if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
				sList = sv_goirai.Get_Sirainusi(gsa���[�U,gs����b�c,gs����b�c,s�˗���b�c);
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				sList[0] = gs�ʐM�G���[;
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				sList[0] = "�ʐM�G���[�F" + ex.Message;
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;

			if(sList[0].Length == 2)
			{
				if(sList[17] == "U"){
					tex�˗���d�b�ԍ��P.Text = sList[2];
					tex�˗���d�b�ԍ��Q.Text = sList[3];
					tex�˗���d�b�ԍ��R.Text = sList[4];
					tex�˗���X�֔ԍ��P.Text = sList[5];
					tex�˗���X�֔ԍ��Q.Text = sList[6];
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//					tex�˗���Z���P.Text     = sList[7];
//					tex�˗���Z���Q.Text     = sList[8];
//					tex�˗��喼�O�P.Text     = sList[9];
//					tex�˗��喼�O�Q.Text     = sList[10];
					if(gs�I�v�V����[18].Equals("1")){
						tex�˗���Z���P.Text = sList[7].TrimEnd();
						tex�˗���Z���Q.Text = sList[8].TrimEnd();
						tex�˗��喼�O�P.Text = sList[9].TrimEnd();
						tex�˗��喼�O�Q.Text = sList[10].TrimEnd();
					}else{
						tex�˗���Z���P.Text = sList[7].Trim();
						tex�˗���Z���Q.Text = sList[8].Trim();
						tex�˗��喼�O�P.Text = sList[9].Trim();
						tex�˗��喼�O�Q.Text = sList[10].Trim();
					}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
					s�O�񌟍��˗���b�c      = s�˗���b�c;
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� START
					tex������R�[�h.Text     = sList[14];
					tex�����敔�ۃR�[�h.Text = sList[15];
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� END

// DEL 2005.05.12 ���s�j�����J �˗���̏d�ʂ͕\�����Ȃ� START
//					if(nUD�d��.Value == 0)
//						nUD�d��.Value = decimal.Parse(sList[12]);
// DEL 2005.05.12 ���s�j�����J �˗���̏d�ʂ͕\�����Ȃ� END
// MOD 2005.05.17 ���s�j�����J �ː����d�ʂ� START
//					d�d��  =  decimal.Parse(sList[12]);
// MOD 2005.05.12 ���s�j�����J �˗���̏d�ʂ͕\�����Ȃ� END
// MOD 2005.05.17 ���s�j�����J �ː����d�ʂ� START
//					d�d��  =  decimal.Parse(sList[12]);
// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� STRAT
//					if(i�ː��e�f == 0)
//						d�d�� = decimal.Parse(sList[11]);
//					else
//						d�d�� = decimal.Parse(sList[12]);
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
					if(gs�d�ʓ��͐��� == "1"){
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
						if(i�ː��e�f == 0){ 
						// �ː��̎�
							d�d�� = decimal.Parse(sList[11]);
							if(d�d�� == 0){
								// �d�ʁ��W
								d�d�� = decimal.Parse(sList[12]) / 8;
// MOD 2011.03.11 ���s�j���� �ː��v�Z�̕␳ START
								d�d�� = decimal.Truncate(d�d�� + decimal.Parse("0.9"));
// MOD 2011.03.11 ���s�j���� �ː��v�Z�̕␳ END
							}
						}else{
						// �d�ʂ̎�
							d�d�� = decimal.Parse(sList[12]);
							if(d�d�� == 0){
								// �ː��~�W
								d�d�� = decimal.Parse(sList[11]) * 8;
							}
						}
// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� END
// MOD 2005.05.17 ���s�j�����J �ː����d�ʂ� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
					}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END

// MOD 2010.09.27 ���s�j���� �����敔�ۖ��̒ǉ� START
					if(sList.Length > 18){
						tex�˗��吿����.Text = sList[18];
					}else{
// MOD 2010.09.27 ���s�j���� �����敔�ۖ��̒ǉ� END
						int iCnt;
						if(gsa������b�c != null)
						{
							for(iCnt = 0 ; iCnt < gsa������b�c.Length; iCnt++ )
							{
								if(gsa������b�c[iCnt] == null || gsa�����敔�ۂb�c[iCnt] == null)
								{
									tex�˗��吿����.Text = "";
								}
								else
								{
									if(gsa������b�c[iCnt] == sList[14] && gsa�����敔�ۂb�c[iCnt] == sList[15])
									{
										tex�˗��吿����.Text = gsa�����敔�ۖ�[iCnt];
										break;
									}
								}
							}
						}
// MOD 2010.09.27 ���s�j���� �����敔�ۖ��̒ǉ� START
					}
// MOD 2010.09.27 ���s�j���� �����敔�ۖ��̒ǉ� END
					tex���b�Z�[�W.Text = "";
					tex�˗��啔��.Focus();
// MOD 2010.10.04 ���s�j���� �S���ҁi�˗��啔���j�t�H�[�J�X��Q�Ή� START
					if(tex�˗��啔��.TabStop == false){
// MOD 2011.08.02 ���s�j���� �e���ڂ̓��͕s�Ή��i�s������j START
//						this.SelectNextControl(this.ActiveControl, true, true, true, true);
						this.SelectNextControl(tex�˗��啔��, true, true, true, true);
// MOD 2011.08.02 ���s�j���� �e���ڂ̓��͕s�Ή��i�s������j END
					}
// MOD 2010.10.04 ���s�j���� �S���ҁi�˗��啔���j�t�H�[�J�X��Q�Ή� END
				}
				else
				{
//					�r�[�v��();
//					tex���b�Z�[�W.Text = "���͂��ꂽ���˗���R�[�h�̓}�X�^�ɑ��݂��܂���B";
// MOD 2005.05.31 ���s�j�����J �G���[�̂Ƃ��̓N���A START
//					s�O�񌟍��˗���b�c      = s�˗���b�c;
					s�O�񌟍��˗���b�c      = "";
// MOD 2005.05.31 ���s�j�����J �G���[�̂Ƃ��̓N���A END
//					i�A�N�e�B�u�e�f = 1;
// MOD 2009.09.09 ���s�j���� ��ʕ\���s��̒��� 
					d�d��  =  0;
					tex���b�Z�[�W.Text = "";
					MessageBox.Show("���͂��ꂽ���˗���R�[�h�̓}�X�^�ɑ��݂��܂���B","���˗��匟��",MessageBoxButtons.OK);
					tex�˗���R�[�h.Focus();
				}
			}
			else
			{
				// �ُ�I����
				�r�[�v��();
				tex���b�Z�[�W.Text = sList[0];
				tex�˗���R�[�h.Focus();
// ADD 2005.05.31 ���s�j�����J �G���[�̂Ƃ��̓N���A START
				s�O�񌟍��˗���b�c      = "";
// ADD 2005.05.31 ���s�j�����J �G���[�̂Ƃ��̓N���A END
			}
			i�A�N�e�B�u�e�f = 1;

		}

		private void tex�˗���R�[�h_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				// ���b�Z�[�W�̃N���A
				tex���b�Z�[�W.Text = "";

				// �󔒏���
				tex�˗���R�[�h.Text = tex�˗���R�[�h.Text.Trim();
				if(tex�˗���R�[�h.Text.Length == 0)
				{
					btn�˗��匟��.Focus();
					btn�˗��匟��_Click(sender, e);
				}
				else
				{
					if(!���p�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;

					s�˗���b�c = tex�˗���R�[�h.Text;
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� START
//					if(s�˗���b�c.Length > 0 && s�˗���b�c != s�O�񌟍��˗���b�c) �˗��匟��();
					if(s�˗���b�c.Length > 0){
						�˗��匟��();
					}
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� END
				}
			}
		}

		private void tex�͂���R�[�h_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				// ���b�Z�[�W�̃N���A
				tex���b�Z�[�W.Text = "";

				// �󔒏���
				tex�͂���R�[�h.Text = tex�͂���R�[�h.Text.Trim();
				if(tex�͂���R�[�h.Text.Length != 0)
				{
					if(!���p�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;

					tex���b�Z�[�W.Text = "�������D�D�D";
					s�͂���b�c = tex�͂���R�[�h.Text;
					�͂��挟��(false);
				}
			}

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

		private void tex�͂���X�֔ԍ��P_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn�Z������.Focus();
				btn�Z������_Click(sender,e);
				e.Handled = true;
			}
		}

		private void tex�͂���X�֔ԍ��Q_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn�Z������.Focus();
				btn�Z������_Click(sender,e);
				e.Handled = true;
			}
		}

		private void tex�͂���X�֔ԍ��Q_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
// MOD 2009.02.06 ���s�j���؁@�X�֔ԍ����͎�TAB�����ɂďZ�������@START
			if((e.KeyCode == Keys.Enter)||(e.KeyCode == Keys.Tab))
//			if(e.KeyCode == Keys.Enter)
// MOD 2009.02.06 ���s�j���؁@�X�֔ԍ����͎�TAB�����ɂďZ�������@END
			{
				// �󔒏���
				tex�͂���X�֔ԍ��P.Text = tex�͂���X�֔ԍ��P.Text.Trim();
				tex�͂���X�֔ԍ��Q.Text = tex�͂���X�֔ԍ��Q.Text.Trim();
				tex�͂���Z���P.Text = tex�͂���Z���P.Text.Trim();
				tex�͂���Z���Q.Text = tex�͂���Z���Q.Text.Trim();
				tex�͂���Z���R.Text = tex�͂���Z���R.Text.Trim();

				// ���̓`�F�b�N
				if(!���p�`�F�b�N(tex�͂���X�֔ԍ��P, "�X�֔ԍ��P")) return;
				if(!���p�`�F�b�N(tex�͂���X�֔ԍ��Q, "�X�֔ԍ��Q")) return;

				string s�X�֔ԍ� = tex�͂���X�֔ԍ��P.Text + tex�͂���X�֔ԍ��Q.Text;
				if(s�X�֔ԍ�.Length == 7)
				{
					if(tex�͂���Z���P.Text.Length == 0 
						&& tex�͂���Z���Q.Text.Length == 0
						&& tex�͂���Z���R.Text.Length == 0)
					{
						// �J�[�\���������v�ɂ���
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						String[] sRet = {""};
						try
						{
							tex���b�Z�[�W.Text = "�������D�D�D";
// MOD 2015.05.07 BEVAS�j�O�c ���q�^���X�֔ԍ����݃`�F�b�N�Ή� START
							//if(sv_address == null) sv_address = new is2address.Service1();
							//sRet = sv_address.Get_byPostcode2(gsa���[�U,s�X�֔ԍ�);
							sRet = �b�l�P�S�X�֔ԍ����݃`�F�b�N(s�X�֔ԍ�);
// MOD 2015.05.07 BEVAS�j�O�c ���q�^���X�֔ԍ����݃`�F�b�N�Ή� END
						}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
						catch (System.Net.WebException)
						{
							sRet[0] = gs�ʐM�G���[;
						}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
						catch (Exception ex)
						{
							sRet[0] = "�ʐM�G���[�F" + ex.Message;
						}
						// �J�[�\�����f�t�H���g�ɖ߂�
						Cursor = System.Windows.Forms.Cursors.Default;

						if(sRet[0].Length == 4)
						{
// �ۗ�						sRet[1]�F�X�֔ԍ�
// �ۗ�						sRet[3]�F�Z���b�c
							if(sRet[2].Length > 60){
								tex�͂���Z���P.Text     = sRet[2].Substring(0,20);
								tex�͂���Z���Q.Text     = sRet[2].Substring(20,20);
								tex�͂���Z���R.Text     = sRet[2].Substring(40,20);
							}else if(sRet[2].Length > 40){
								tex�͂���Z���P.Text     = sRet[2].Substring(0,20);
								tex�͂���Z���Q.Text     = sRet[2].Substring(20,20);
								tex�͂���Z���R.Text     = sRet[2].Substring(40);
							}else if(sRet[2].Length > 20){
								tex�͂���Z���P.Text     = sRet[2].Substring(0,20);
								tex�͂���Z���Q.Text     = sRet[2].Substring(20);
								tex�͂���Z���R.Text     = "";
							}else{
								tex�͂���Z���P.Text     = sRet[2];
								tex�͂���Z���Q.Text     = "";
								tex�͂���Z���R.Text     = "";
							}
							tex���b�Z�[�W.Text = "";
							//�t�H�[�J�X�ݒ�
							tex�͂���Z���Q.Focus();
						}
						else
						{
							if(sRet[0].Equals("�Y���f�[�^������܂���"))
								sRet[0] = "�X�֔ԍ������݂��܂���";
							tex���b�Z�[�W.Text = sRet[0];
							//�t�H�[�J�X�ݒ�
							tex�͂���X�֔ԍ��P.Focus();
						}
// MOD 2009.02.06 ���s�j���� �X�֔ԍ��ύX���̃J�[�\���ړ��̏C�� START
					}else{
						if(e.KeyCode == Keys.Tab) tex�͂���Z���P.Focus();
// MOD 2009.02.06 ���s�j���� �X�֔ԍ��ύX���̃J�[�\���ړ��̏C�� END
					}
				}
// MOD 2009.02.06 ���s�j���؁@�X�֔ԍ����͎�TAB�����ɂďZ�������@START
//				else
				else if(e.KeyCode == Keys.Enter)
// MOD 2009.02.06 ���s�j���؁@�X�֔ԍ����͎�TAB�����ɂďZ�������@END
				{
					btn�Z������.Focus();
					btn�Z������_Click(sender, e);
				}
// MOD 2009.02.06 ���s�j���� �X�֔ԍ��ύX���̃J�[�\���ړ��̏C�� START
				else
				{
					tex�͂���Z���P.Focus();
				}
// MOD 2009.02.06 ���s�j���� �X�֔ԍ��ύX���̃J�[�\���ړ��̏C�� END

				return;
			}
		}

		private void nUD��_Enter(object sender, System.EventArgs e)
		{
			if(nUD��.Text.Length > 0) nUD��.Select(0, nUD��.Text.Length);
		}

		private void nUD�d��_Enter(object sender, System.EventArgs e)
		{
			if(nUD�d��.Text.Length > 0) nUD�d��.Select(0, nUD�d��.Text.Length);
		}

		private void nUD�ی����z_Enter(object sender, System.EventArgs e)
		{
			if(nUD�ی����z.Text.Length > 0) nUD�ی����z.Select(0, nUD�ی����z.Text.Length);
		}

		private void tex�A���R�[�h�e_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				tex�A���R�[�h�e.Text = " ";
				btn�A������_Click(sender,e);
				e.Handled = true;
			}
		}

// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX START
		private void tex�A���R�[�h�q_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				if(s�A�����i�e�R�[�h.Length != 0)
				{
// MOD 2005.06.01 ���s�j�ɉ� �A�����i�d�l�ύX START
//					tex�A���R�[�h�e.Text = s�A�����i�e�R�[�h;
//					tex�A���R�[�h�q.Text = " ";
//					btn�A������_Click(sender,e);
					if (g�L������ == null)	 g�L������ = new �L������();
					g�L������.Left  = this.Left;
					g�L������.Top   = this.Top;
					g�L������.b�A���w�� = true;
					g�L������.lab�L���^�C�g��.Text = "�A�����i����";
					//�A�����i�q����
					g�L������.s�A�����i���� = s�A�����i�e�R�[�h;

					g�L������.ShowDialog();
					if (g�L������.sKcode.Length != 0)
					{
						//�A�����i�q����
						tex�A���R�[�h�q.Text = g�L������.sKcode;
						tex�A�����q.Text = g�L������.s�L��;
						s�A�����i�q�R�[�h = g�L������.sKcode;
						tex�L���R�[�h.Focus();
					}
// MOD 2005.06.01 ���s�j�ɉ� �A�����i�d�l�ύX END
				}
				e.Handled = true;
			}
		}
// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX END

// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX START
		private void �A�����i���d�ʐ���()
		{
			if (s�A�����i�e�R�[�h.Equals("001"))
			{
				nUD��.Value = 1;
				nUD��.Enabled = false;
				i�ː��e�f = 1;
				nUD�d��.Value = 1;
				lab�d��.Text = "�d��(kg)";
				nUD�d��.Maximum = 1;
				nUD�d��.Enabled = false;
			}
			else if (s�A�����i�e�R�[�h.Equals("002"))
			{
				nUD��.Value = 1;
				nUD��.Enabled = false;
				i�ː��e�f = 1;
				lab�d��.Text = "�d��(kg)";
				nUD�d��.Maximum = 30;
				nUD�d��.Enabled = true;
// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� START
				��ʐ���ݒ�Q(nUD�d��, s��ʐ���_�d��);
// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� END
			}
			else
			{
				i�ː��e�f = i�ː��ێ�;
				if(i�ː��e�f == 1)
				{
					nUD��.Enabled = true;
					lab�d��.Text = "�d��(kg)";
					nUD�d��.Maximum = 9999;
					nUD�d��.Enabled = true;
// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� START
					��ʐ���ݒ�Q(nUD�d��, s��ʐ���_�d��);
// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� END
				}
				else
				{
					nUD��.Enabled = true;
					lab�d��.Text = "�ː�";
					nUD�d��.Maximum = 999;
					nUD�d��.Enabled = true;
// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� START
					��ʐ���ݒ�Q(nUD�d��, s��ʐ���_�d��);
// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� END
				}
			}
		}
// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX END

		private void tex�L���R�[�h_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn�L������_Click(sender,e);
				e.Handled = true;
			}
		}

		private void nUD�o�^�ԍ�_Enter(object sender, System.EventArgs e)
		{
			if(nUD�o�^�ԍ�.Text.Length > 0) nUD�o�^�ԍ�.Select(0, nUD�o�^�ԍ�.Text.Length);
		}

		private void btn���_Click(object sender, System.EventArgs e)
		{
			if(i���^�m�n > 0)
			{
				// ���^�ꗗ����J���ꂽ�ꍇ�i�X�V���[�h�j
				b�X�V�e�f           = true;
				btn�폜.Visible     = true;
				tex���^��.Text      = s���^����;
				nUD�o�^�ԍ�.Value   = i���^�m�n;
				nUD�o�^�ԍ�.Enabled = false;
				nUD�o�^�ԍ�.TabStop = false;
				���^����();
				tex�͂���R�[�h.Focus();
			}
			else
			{
				// �Ɖ�ꗗ����J���ꂽ�ꍇ�i�ǉ����[�h�j
				b�X�V�e�f           = false;
				btn�폜.Visible     = false;
				tex���^��.Text      = "";
				nUD�o�^�ԍ�.Value   = 0;
				nUD�o�^�ԍ�.Enabled = true;
				nUD�o�^�ԍ�.TabStop = true;
				tex���^��.Focus();
				if(s�o�^��.Length > 0 && s�W���[�i���m�n.Length > 0)
				{
					// �Ɖ�ꗗ����J���ꂽ�ꍇ�i�ǉ����[�h�j
					�o�׌���();
					tex���^��.Focus();
				}
				else
				{
					�͂��捀�ڃN���A();
					�˗��區�ڃN���A();
					���̑����ڃN���A();
					tex�˗���R�[�h.Text = gs�ב��l�b�c;
					s�˗���b�c          = gs�ב��l�b�c;
					if(s�˗���b�c.Length > 0) �˗��匟��();
					tex���^��.Focus();
				}
				���^�ԍ��ݒ�();
			}
		}

		private void btn�폜_Click(object sender, System.EventArgs e)
		{
			// �X�V���[�h�ȊO�́A�N�����Ȃ�
			if(!b�X�V�e�f) return;
			DialogResult result = MessageBox.Show("���̃f�[�^���폜���܂����H","�폜",MessageBoxButtons.YesNo);
			if(result == DialogResult.Yes)
			{
 
				string[] sKey = new string[6];
				sKey[0] = gs����b�c;
				sKey[1] = gs����b�c;
				sKey[2] = i���^�m�n.ToString();
				sKey[3] = s�X�V�N����;
				sKey[4] = "���^�o��";
				sKey[5] = gs���p�҂b�c;

				// �J�[�\���������v�ɂ���
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				string sRet = "";
				try
				{
					// ���^�̍폜
					// �����F����b�c�A����b�c�A���^�m�n�A�X�V�����A�X�V�o�f�A�X�V��
					// �ߒl�F�X�e�[�^�X
					tex���b�Z�[�W.Text = "�폜���D�D�D";
					if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
					sRet = sv_hinagata.Del_hinagata(gsa���[�U,sKey);
				}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
				catch (System.Net.WebException)
				{
					sRet = gs�ʐM�G���[;
				}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
				catch (Exception ex)
				{
					sRet = "�ʐM�G���[�F" + ex.Message;
				}
				// �J�[�\�����f�t�H���g�ɖ߂�
				Cursor = System.Windows.Forms.Cursors.Default;

				// �ُ�I���̎�
				if(sRet.Length != 4)
				{
					�r�[�v��();
					tex���b�Z�[�W.Text = sRet;
					return;
				}

				Close();
			}
		}

		private void ���^�o�^_Activated(object sender, System.EventArgs e)
		{
			if(i�A�N�e�B�u�e�f == 0)
				tex���^��.Focus();

			if(i���^�m�n <= 0
				&& (s�o�^��.Length == 0 || s�W���[�i���m�n.Length == 0)
				&& i�A�N�e�B�u�e�f == 0)
			{
				i�A�N�e�B�u�e�f = 1;
				tex�˗���R�[�h.Text = gs�ב��l�b�c;
				s�˗���b�c          = gs�ב��l�b�c;
				if(s�˗���b�c.Length > 0) �˗��匟��();
				tex���^��.Focus();
			}
		}

// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� START
		private void ���^�o�^_Closed(object sender, System.EventArgs e)
		{
			�͂��捀�ڃN���A();
			�˗��區�ڃN���A();
			���̑����ڃN���A();
		}
// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� END

// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� START
		private void btn�x�X�~��_Click(object sender, System.EventArgs e)
		{
			// �X��������ʂ��N��
			if (g�X������ == null)
			{
				g�X������ = new �X������();
			}
			g�X������.Left = this.Left + 404;
			g�X������.Top = this.Top;
			// ��ʏ����l�̐ݒ�
			g�X������.s�X���R�[�h = "";
			g�X������.s�X���� = "";
			g�X������.s�X�������� = "";
			g�X������.s�X�֔ԍ� = "";
			g�X������.ShowDialog();

			if(g�X������.s�X���R�[�h.Length > 0)
			{
				/** �X��������ʂ���A�X���R�[�h�����p����Ă����ꍇ */
				// �X��������ʂŎ擾�����l���A�e���ڂɐݒ�
				tex�͂���X�֔ԍ��P.Text = g�X������.s�X�֔ԍ�.Substring(0, 3); // �͂���X�֔ԍ��P
				tex�͂���X�֔ԍ��Q.Text = g�X������.s�X�֔ԍ�.Substring(3, 4); // �͂���X�֔ԍ��Q
				tex�͂���Z���P.Text = "�����x�X�~�߁���"; // �͂���Z���P
				tex�͂���Z���Q.Text = g�X������.s�X�������� + "�~��"; // �͂���Z���Q
				tex�͂���Z���R.Text = �S�p�����ϊ�(g�X������.s�X���R�[�h); // �͂���Z���R

				// �͂���X�֔ԍ�����ѓ͂���Z���P�`�R�����b�N
				tex�͂���X�֔ԍ��P.Enabled = false; // �͂���X�֔ԍ��P
				tex�͂���X�֔ԍ��Q.Enabled = false; // �͂���X�֔ԍ��Q
				tex�͂���Z���P.Enabled = false; // �͂���Z���P
				tex�͂���Z���Q.Enabled = false; // �͂���Z���Q
				tex�͂���Z���R.Enabled = false; // �͂���Z���R

				// �x�X�~�߃{�^�����\���A�����{�^����\��
				btn�x�X�~��.Visible = false;
				btn�x�X�~��.Enabled = false;
				btn�x�X�~�߉���.Visible = true;
				btn�x�X�~�߉���.Enabled = true;

				// �t�H�[�J�X���w�͂��於�O�P�x�ɐݒ�
				tex�͂��於�O�P.Focus();
			}
			else
			{
				/** ����ȊO�̏ꍇ */
				// �t�H�[�J�X���w�Z���P�x�ɐݒ�
				tex�͂���Z���P.Focus();
			}
		}

		private void btn�x�X�~�߉���_Click(object sender, System.EventArgs e)
		{
			// �͂���X�֔ԍ�����ѓ͂���Z���P�`�R�̃��b�N������
			tex�͂���X�֔ԍ��P.Enabled = true; // �͂���X�֔ԍ��P
			tex�͂���X�֔ԍ��Q.Enabled = true; // �͂���X�֔ԍ��Q
			tex�͂���Z���P.Enabled = true; // �͂���Z���P
			tex�͂���Z���Q.Enabled = true; // �͂���Z���Q
			tex�͂���Z���R.Enabled = true; // �͂���Z���R

			// �͂���X�֔ԍ�����ѓ͂���Z���P�`�R�̓��͒l���N���A
			tex�͂���X�֔ԍ��P.Text = ""; // �͂���X�֔ԍ��P
			tex�͂���X�֔ԍ��Q.Text = ""; // �͂���X�֔ԍ��Q
			tex�͂���Z���P.Text = ""; // �͂���Z���P
			tex�͂���Z���Q.Text = ""; // �͂���Z���Q
			tex�͂���Z���R.Text = ""; // �͂���Z���R

			// �x�X�~�߃{�^����\���A�����{�^�����\��
			btn�x�X�~��.Visible = true;
			btn�x�X�~��.Enabled = true;
			btn�x�X�~�߉���.Visible = false;
			btn�x�X�~�߉���.Enabled = false;

			// �t�H�[�J�X���w�͂���X�֔ԍ��P�x�ɐݒ�
			tex�͂���X�֔ԍ��P.Focus();
		}
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� END
	}
}
