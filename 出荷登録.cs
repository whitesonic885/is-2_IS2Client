using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [�G���g���[]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// MOD 2008.03.19 ���s�j���� ���͂���̏㏑�@�\�̒ǉ� 
	// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� 
	// MOD 2008.11.14 ���s�j���� �w����敪�̕��� 
	//--------------------------------------------------------------------------
	// ADD 2009.03.02 ���s�j���� �d�ʂO���͎��̕s����� 
	// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N 
	// ADD 2009.04.02 ���s�j���� �ғ����Ή� 
	// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� 
	// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� 
	// MOD 2009.08.20 �p�\�j���� �X�֔ԍ��̒l���p�� 
	// ADD 2009.09.01 �p�\�j���� �L���E�i���^���̌Œ�@�\�̒ǉ� 
	// MOD 2009.08.25 ���s�j���� �G���g���[�o�^�ł̐�����̑��݃`�F�b�N�̒ǉ� 
	// MOD 2009.09.04 ���s�j���� Vista�Ή�(TAB�Ή�����) 
	// MOD 2009.09.09 ���s�j���� �O�񌟍��˗���b�c�̃N���A����Ή� 
	// MOD 2009.10.05 �p�\�j����@�L���E�i���^���̍s�ʌŒ�@�\�̒ǉ�
	// MOD 2009.10.16 ���s�j���� �L���E�i���Œ�`�F�b�N�����@�\�̒ǉ� 
	// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� 
	// MOD 2009.12.01 ���s�j���� �S�p���p���݉\�ɂ��� 
	// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� 
	// MOD 2009.12.08 ���s�j���� �w����̏����Q�i��L�̃O���[�o���Ή��̏�Q�j
	//--------------------------------------------------------------------------
	// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� 
	// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� 
	// MOD 2010.05.25 ���s�j���؁@���Ԏw��̕ύX 
	// MOD 2010.06.18 ���s�j���� �o�׃f�[�^�̎Q�ƁE�ǉ��E�X�V�E�폜���O�̒ǉ� 
	// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j 
	// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� 
	// MOD 2010.08.31 ���s�j���� �d�ʂO���͎��̎d�l�ύX 
	// MOD 2010.09.07 ���s�j���� ������`�F�b�N�̕\���ύX 
	// MOD 2010.09.24 ���s�j���� �d�ʎ����v�Z���̏���G���[�Ή� 
	// MOD 2010.09.27 ���s�j���� �����敔�ۖ��̒ǉ� 
	// MOD 2010.09.30 ���s�j���� �S���ҁi�˗��啔���j�N���A��Q�Ή� 
	// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� 
	// MOD 2010.10.04 ���s�j���� �S���ҁi�˗��啔���j�t�H�[�J�X��Q�Ή� 
	// MOD 2010.11.01 ���s�j���� ���˗�����̏d�ʒl�O�Ή� 
	// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX 
	// MOD 2010.11.12 ���s�j���� �����s�f�[�^���폜�\�ɂ��� 
	// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) 
	// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� 
	// MOD 2011.01.24 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������i���˗���A�o�ד��j
	// MOD 2011.03.11 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������̋��� 
	// MOD 2011.03.11 ���s�j���� �ː��v�Z�̕␳ 
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
	// MOD 2015.05.07 BEVAS) �O�c ���q�^���׎�l�̗X�֔ԍ����݃`�F�b�N��CM14J�g�p
	// MOD 2015.07.13 TDI�j�j�V �o�[�R�[�h�ǎ��p��ʒǉ�
	// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή�
	//--------------------------------------------------------------------------
	// MOD 2016.03.24 BEVAS�j���{ ���q�^���ŃO���[�o���^�p�Ή� 
	// MOD 2016.04.13 BEVAS�j���{ �z�B�w�������̊g��
	// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή�
	// MOD 2016.06.10 BEVAS�j���{ �L���̌Œ���e���o�דo�^���ȊO�ł��ۑ�
	// MOD 2016.06.10 BEVAS�j���{ �ی������̓`�F�b�N�@�\�̒ǉ��i31���~�ȏ�̏ꍇ�j
	//--------------------------------------------------------------------------
	public class �o�דo�^ : ���ʃt�H�[��
	{
		// ���J�ϐ�
		public  string s�����e�f  = "";
		public  string s�W���[�i���m�n  ="";
		public  string s�o�^��    = "";
		public  string s�o�^�҂b�c   = "";

		// ���^�o�׏Ɖ��W�����v�����ꍇ�Ɏg�p
		public  int      i���^�m�n  = 0;
		public  DateTime dt���^�o�ד�;
		public  bool     b���^�w��� = false;
		public  DateTime dt���^�w���;
		public  int      i���^�w����敪 = 0;

		// �����ϐ�
		private string s�͂���b�c = "";
		private string s�˗���b�c = "";
		private string sUpday     = "0";
		private string s�O�񌟍��˗���b�c = "";
		private int    i����e�f = 0;
		private decimal d�d�� = 0;
		private int    i�����e�f = 0;
		private int    i�A�N�e�B�u�e�f = 0;
		private int    i�X�V�e�f  = 0;
		private int    i�ː��e�f = 1;
		private int    i�ː��ێ� = 1;
		private string s�A�����i�e�R�[�h = "";
		private string s�A�����i�q�R�[�h = "";
		private string s�o�^�A�����i�R�[�h = "";
		private string s�o�^�����ԍ� = "";
// ADD 2009.04.02 ���s�j���� �ғ����Ή� START
		private string s�o�^�o�f = "";
		private DateTime dt�w����ő�l;
		private DateTime dt�w����ŏ��l;
// ADD 2009.04.02 ���s�j���� �ғ����Ή� END
// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� START
		private string[] sa�L���i���Œ�;
// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� END
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
		private bool b�w����`�F�b�N�l�r�f�L = false;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� START
		private string s�C���O_�˗���b�c = ""; //
		private string s�C���O_������b�c = ""; //
		private string s�C���O_�����敔�� = ""; //�����敔�ۂb�c
		private string s�C���O_�����於   = ""; //
		private string s�C���O_��       = ""; //
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� END
// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� START
		private string s��ʐ���_�d��   = "0";
		private string s��ʐ���_�˗��� = "0";
// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� END
// MOD 2015.07.13 TDI�j�j�V �o�[�R�[�h�ǎ��p��ʒǉ� START
		private string[] sa�O���[�o���`�F�b�N;
// MOD 2015.07.13 TDI�j�j�V �o�[�R�[�h�ǎ��p��ʒǉ� END

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
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.DateTimePicker dt�o�ד�;
		private System.Windows.Forms.DateTimePicker dt�w���;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab����;
		private System.Windows.Forms.TextBox tex���q�l��;
		private System.Windows.Forms.Label lab���q�l��;
		private System.Windows.Forms.Label lab���p����;
		private System.Windows.Forms.TextBox tex���p����;
		private System.Windows.Forms.Label lab�o�דo�^�^�C�g��;
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
		private ���ʃe�L�X�g�{�b�N�X tex�A���R�[�h�e;
		private ���ʃe�L�X�g�{�b�N�X tex�L�����R;
		private ���ʃe�L�X�g�{�b�N�X tex�L�����Q;
		private ���ʃe�L�X�g�{�b�N�X tex�L�����P;
		private ���ʃe�L�X�g�{�b�N�X tex�L���R�[�h;
		private ���ʃe�L�X�g�{�b�N�X tex���q�l�Ǘ��ԍ�;
		private System.Windows.Forms.NumericUpDown nUD�d��;
		private System.Windows.Forms.NumericUpDown nUD�ی����z;
		private System.Windows.Forms.NumericUpDown nUD��;
		private System.Windows.Forms.Button btn�폜;
		private System.Windows.Forms.Button btn���;
		private System.Windows.Forms.Button btn�X�V;
		private System.Windows.Forms.TextBox tex���b�Z�[�W;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Button btn�������;
		private System.Windows.Forms.Button btn�͂��挟��;
		private System.Windows.Forms.Button btn�˗��匟��;
		private System.Windows.Forms.Button btn�Z������;
		private System.Windows.Forms.Button btn�A������;
		private System.Windows.Forms.Button btn�L������;
		private System.Windows.Forms.Button btn�˗���o�^;
		private System.Windows.Forms.Button btn�͂���o�^;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.CheckBox cBox�˗���Œ�;
		private System.Windows.Forms.CheckBox cBox�o�ד��Œ�;
		private System.Windows.Forms.Label lab�͂���R�[�h;
		private System.Windows.Forms.Label lab�˗��啔��;
		private System.Windows.Forms.Label lab�˗��喼�O;
		private System.Windows.Forms.Label lab�˗���Z��;
		private System.Windows.Forms.Label lab�˗���X�֔ԍ�;
		private System.Windows.Forms.Label lab�˗���d�b�ԍ�;
		private System.Windows.Forms.Label lab�˗���R�[�h;
		private System.Windows.Forms.Label lab�˗��吿����;
		private System.Windows.Forms.Label lab�A���R�[�h;
		private System.Windows.Forms.Label lab�A���w���;
		private System.Windows.Forms.Label lab�A���w��;
		private System.Windows.Forms.Label lab�L���R�[�h;
		private System.Windows.Forms.Label lab�L��;
		private System.Windows.Forms.Label lab���q�l�Ǘ��ԍ�;
		private System.Windows.Forms.Label lab�d��;
		private System.Windows.Forms.Label lab�ی����z;
		private System.Windows.Forms.Label lab��;
		private System.Windows.Forms.Label lab�o�ד�;
		private System.Windows.Forms.Label lab�͂��於�O;
		private System.Windows.Forms.Label lab�͂���Z��;
		private System.Windows.Forms.Label lab�͂���X�֔ԍ�;
		private System.Windows.Forms.Label lab�͂���d�b�ԍ�;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox tex���b�Z�[�W�Q;
		private System.Windows.Forms.CheckBox cBox�w���;
		private System.Windows.Forms.CheckBox cBox�w����Œ�;
		private System.Windows.Forms.Label label3;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�A���R�[�h�q;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�A�����e;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�A�����q;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cmb�w����敪;
		private System.Windows.Forms.TextBox tex������R�[�h;
		private System.Windows.Forms.Label lab������R�[�h;
		private System.Windows.Forms.TextBox tex�����敔�ۃR�[�h;
		private System.Windows.Forms.CheckBox cBox���Œ�;
		private System.Windows.Forms.CheckBox cBox�L���i���Œ�P;
		private System.Windows.Forms.CheckBox cBox�L���i���Œ�R;
		private System.Windows.Forms.CheckBox cBox�L���i���Œ�Q;
		private System.Windows.Forms.Button btn�L���i���Œ�;
		private System.Windows.Forms.Label lbl���q�^��;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�L�����S;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�L�����T;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�L�����U;
		private System.Windows.Forms.CheckBox cBox�L���i���Œ�S;
		private System.Windows.Forms.CheckBox cBox�L���i���Œ�T;
		private System.Windows.Forms.CheckBox cBox�L���i���Œ�U;
		private System.Windows.Forms.Button btn�x�X�~��;
		private System.Windows.Forms.Button btn�x�X�~�߉���;
		private System.ComponentModel.IContainer components;

		public �o�דo�^()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(�o�דo�^));
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
			this.btn�͂���o�^ = new System.Windows.Forms.Button();
			this.btn�͂��挟�� = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tex�����敔�ۃR�[�h = new System.Windows.Forms.TextBox();
			this.lab������R�[�h = new System.Windows.Forms.Label();
			this.tex������R�[�h = new System.Windows.Forms.TextBox();
			this.lab�˗���Z�� = new System.Windows.Forms.Label();
			this.tex�˗���d�b�ԍ��P = new System.Windows.Forms.TextBox();
			this.tex�˗��吿���� = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.lab�˗��啔�� = new System.Windows.Forms.Label();
			this.lab�˗��喼�O = new System.Windows.Forms.Label();
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
			this.btn�˗���o�^ = new System.Windows.Forms.Button();
			this.btn�˗��匟�� = new System.Windows.Forms.Button();
			this.label21 = new System.Windows.Forms.Label();
			this.tex�˗���R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab�˗��吿���� = new System.Windows.Forms.Label();
			this.cBox�˗���Œ� = new System.Windows.Forms.CheckBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.cBox�L���i���Œ�U = new System.Windows.Forms.CheckBox();
			this.cBox�L���i���Œ�T = new System.Windows.Forms.CheckBox();
			this.cBox�L���i���Œ�S = new System.Windows.Forms.CheckBox();
			this.tex�L�����U = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�L�����T = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�L�����S = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.btn�L���i���Œ� = new System.Windows.Forms.Button();
			this.cBox�L���i���Œ�P = new System.Windows.Forms.CheckBox();
			this.cBox�L���i���Œ�R = new System.Windows.Forms.CheckBox();
			this.cBox�L���i���Œ�Q = new System.Windows.Forms.CheckBox();
			this.cmb�w����敪 = new System.Windows.Forms.ComboBox();
			this.tex�A�����q = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�A�����e = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�A���R�[�h�q = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.label3 = new System.Windows.Forms.Label();
			this.cBox�w����Œ� = new System.Windows.Forms.CheckBox();
			this.cBox�w��� = new System.Windows.Forms.CheckBox();
			this.dt�w��� = new System.Windows.Forms.DateTimePicker();
			this.btn�A������ = new System.Windows.Forms.Button();
			this.tex�A���R�[�h�e = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab�A���R�[�h = new System.Windows.Forms.Label();
			this.lab�A���w��� = new System.Windows.Forms.Label();
			this.lab�A���w�� = new System.Windows.Forms.Label();
			this.tex�L�����R = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�L�����Q = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex�L�����P = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.btn�L������ = new System.Windows.Forms.Button();
			this.tex�L���R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab�L���R�[�h = new System.Windows.Forms.Label();
			this.lab�L�� = new System.Windows.Forms.Label();
			this.tex���q�l�Ǘ��ԍ� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab���q�l�Ǘ��ԍ� = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.lab�d�� = new System.Windows.Forms.Label();
			this.nUD�d�� = new System.Windows.Forms.NumericUpDown();
			this.nUD�ی����z = new System.Windows.Forms.NumericUpDown();
			this.lab�ی����z = new System.Windows.Forms.Label();
			this.nUD�� = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.lab�� = new System.Windows.Forms.Label();
			this.cBox���Œ� = new System.Windows.Forms.CheckBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.cBox�o�ד��Œ� = new System.Windows.Forms.CheckBox();
			this.dt�o�ד� = new System.Windows.Forms.DateTimePicker();
			this.lab�o�ד� = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.lbl���q�^�� = new System.Windows.Forms.Label();
			this.tex���q�l�� = new System.Windows.Forms.TextBox();
			this.lab���q�l�� = new System.Windows.Forms.Label();
			this.lab���p���� = new System.Windows.Forms.Label();
			this.tex���p���� = new System.Windows.Forms.TextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab���� = new System.Windows.Forms.Label();
			this.lab�o�דo�^�^�C�g�� = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn�폜 = new System.Windows.Forms.Button();
			this.btn��� = new System.Windows.Forms.Button();
			this.btn�X�V = new System.Windows.Forms.Button();
			this.tex���b�Z�[�W = new System.Windows.Forms.TextBox();
			this.btn���� = new System.Windows.Forms.Button();
			this.btn������� = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.tex���b�Z�[�W�Q = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nUD�d��)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD�ی����z)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD��)).BeginInit();
			this.panel5.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// tex�͂���R�[�h
			// 
			this.tex�͂���R�[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex�͂���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�͂���R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�͂���R�[�h.Location = new System.Drawing.Point(106, 2);
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
			this.tex�͂���d�b�ԍ��P.Location = new System.Drawing.Point(106, 28);
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
			this.panel1.Controls.Add(this.btn�͂���o�^);
			this.panel1.Controls.Add(this.btn�͂��挟��);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.tex�͂���R�[�h);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Location = new System.Drawing.Point(0, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(442, 221);
			this.panel1.TabIndex = 1;
			// 
			// btn�x�X�~�߉���
			// 
			this.btn�x�X�~�߉���.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�x�X�~�߉���.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�x�X�~�߉���.ForeColor = System.Drawing.Color.White;
			this.btn�x�X�~�߉���.Location = new System.Drawing.Point(296, 54);
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
			this.btn�x�X�~��.Location = new System.Drawing.Point(296, 54);
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
			this.btn����.Location = new System.Drawing.Point(246, 54);
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
			this.label35.Location = new System.Drawing.Point(26, 152);
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
			this.tex�͂��於�O�Q.Location = new System.Drawing.Point(106, 170);
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
			this.lab�͂��於�O.Location = new System.Drawing.Point(40, 152);
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
			this.tex�͂��於�O�P.Location = new System.Drawing.Point(106, 148);
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
			this.btn�Z������.Location = new System.Drawing.Point(196, 54);
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
			this.tex�͂���Z���R.Location = new System.Drawing.Point(106, 124);
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
			this.tex�͂���X�֔ԍ��Q.Location = new System.Drawing.Point(154, 54);
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
			this.tex�͂���X�֔ԍ��P.Location = new System.Drawing.Point(106, 54);
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
			this.label8.Location = new System.Drawing.Point(140, 60);
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
			this.tex�͂���d�b�ԍ��R.Location = new System.Drawing.Point(230, 28);
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
			this.tex�͂���d�b�ԍ��Q.Location = new System.Drawing.Point(176, 28);
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
			this.label6.Location = new System.Drawing.Point(216, 34);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(12, 14);
			this.label6.TabIndex = 13;
			this.label6.Text = "�|";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label5.ForeColor = System.Drawing.Color.LimeGreen;
			this.label5.Location = new System.Drawing.Point(166, 34);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(12, 14);
			this.label5.TabIndex = 11;
			this.label5.Text = "�j";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label4.ForeColor = System.Drawing.Color.LimeGreen;
			this.label4.Location = new System.Drawing.Point(96, 34);
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
			this.lab�͂���R�[�h.Location = new System.Drawing.Point(40, 4);
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
			this.tex�͂���Z���Q.Location = new System.Drawing.Point(106, 102);
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
			this.tex�͂���Z���P.Location = new System.Drawing.Point(106, 80);
			this.tex�͂���Z���P.MaxLength = 20;
			this.tex�͂���Z���P.Name = "tex�͂���Z���P";
			this.tex�͂���Z���P.Size = new System.Drawing.Size(330, 23);
			this.tex�͂���Z���P.TabIndex = 9;
			this.tex�͂���Z���P.Text = "";
			// 
			// btn�͂���o�^
			// 
			this.btn�͂���o�^.BackColor = System.Drawing.Color.Blue;
			this.btn�͂���o�^.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�͂���o�^.ForeColor = System.Drawing.Color.White;
			this.btn�͂���o�^.Location = new System.Drawing.Point(330, 196);
			this.btn�͂���o�^.Name = "btn�͂���o�^";
			this.btn�͂���o�^.Size = new System.Drawing.Size(92, 22);
			this.btn�͂���o�^.TabIndex = 14;
			this.btn�͂���o�^.TabStop = false;
			this.btn�͂���o�^.Text = "���͂���o�^";
			this.btn�͂���o�^.Click += new System.EventHandler(this.btn�͂���o�^_Click);
			// 
			// btn�͂��挟��
			// 
			this.btn�͂��挟��.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�͂��挟��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�͂��挟��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�͂��挟��.ForeColor = System.Drawing.Color.White;
			this.btn�͂��挟��.Location = new System.Drawing.Point(280, 2);
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
			this.label1.Size = new System.Drawing.Size(20, 221);
			this.label1.TabIndex = 3;
			this.label1.Text = "���͂���";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(26, 202);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(18, 14);
			this.label7.TabIndex = 28;
			this.label7.Text = "��";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label9.ForeColor = System.Drawing.Color.Blue;
			this.label9.Location = new System.Drawing.Point(44, 202);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(178, 14);
			this.label9.TabIndex = 29;
			this.label9.Text = "�󂪂��鍀�ڂ͕K�{���͍��ڂł��B";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Honeydew;
			this.panel2.Controls.Add(this.tex�����敔�ۃR�[�h);
			this.panel2.Controls.Add(this.lab������R�[�h);
			this.panel2.Controls.Add(this.tex������R�[�h);
			this.panel2.Controls.Add(this.lab�˗���Z��);
			this.panel2.Controls.Add(this.tex�˗���d�b�ԍ��P);
			this.panel2.Controls.Add(this.tex�˗��吿����);
			this.panel2.Controls.Add(this.label36);
			this.panel2.Controls.Add(this.lab�˗��啔��);
			this.panel2.Controls.Add(this.lab�˗��喼�O);
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
			this.panel2.Controls.Add(this.btn�˗���o�^);
			this.panel2.Controls.Add(this.btn�˗��匟��);
			this.panel2.Controls.Add(this.label21);
			this.panel2.Controls.Add(this.tex�˗���R�[�h);
			this.panel2.Controls.Add(this.lab�˗��吿����);
			this.panel2.Controls.Add(this.cBox�˗���Œ�);
			this.panel2.Location = new System.Drawing.Point(0, 6);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(442, 196);
			this.panel2.TabIndex = 2;
			// 
			// tex�����敔�ۃR�[�h
			// 
			this.tex�����敔�ۃR�[�h.BackColor = System.Drawing.Color.Honeydew;
			this.tex�����敔�ۃR�[�h.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�����敔�ۃR�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�����敔�ۃR�[�h.Location = new System.Drawing.Point(390, 174);
			this.tex�����敔�ۃR�[�h.Name = "tex�����敔�ۃR�[�h";
			this.tex�����敔�ۃR�[�h.ReadOnly = true;
			this.tex�����敔�ۃR�[�h.Size = new System.Drawing.Size(48, 16);
			this.tex�����敔�ۃR�[�h.TabIndex = 45;
			this.tex�����敔�ۃR�[�h.TabStop = false;
			this.tex�����敔�ۃR�[�h.Text = "";
			// 
			// lab������R�[�h
			// 
			this.lab������R�[�h.BackColor = System.Drawing.Color.Honeydew;
			this.lab������R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab������R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab������R�[�h.Location = new System.Drawing.Point(262, 176);
			this.lab������R�[�h.Name = "lab������R�[�h";
			this.lab������R�[�h.Size = new System.Drawing.Size(28, 14);
			this.lab������R�[�h.TabIndex = 44;
			this.lab������R�[�h.Text = "����";
			// 
			// tex������R�[�h
			// 
			this.tex������R�[�h.BackColor = System.Drawing.Color.Honeydew;
			this.tex������R�[�h.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex������R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex������R�[�h.Location = new System.Drawing.Point(292, 174);
			this.tex������R�[�h.Name = "tex������R�[�h";
			this.tex������R�[�h.ReadOnly = true;
			this.tex������R�[�h.Size = new System.Drawing.Size(96, 16);
			this.tex������R�[�h.TabIndex = 43;
			this.tex������R�[�h.TabStop = false;
			this.tex������R�[�h.Text = "";
			// 
			// lab�˗���Z��
			// 
			this.lab�˗���Z��.BackColor = System.Drawing.Color.Honeydew;
			this.lab�˗���Z��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�˗���Z��.Location = new System.Drawing.Point(40, 74);
			this.lab�˗���Z��.Name = "lab�˗���Z��";
			this.lab�˗���Z��.Size = new System.Drawing.Size(56, 14);
			this.lab�˗���Z��.TabIndex = 42;
			this.lab�˗���Z��.Text = "�Z��";
			// 
			// tex�˗���d�b�ԍ��P
			// 
			this.tex�˗���d�b�ԍ��P.BackColor = System.Drawing.Color.Honeydew;
			this.tex�˗���d�b�ԍ��P.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�˗���d�b�ԍ��P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗���d�b�ԍ��P.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�˗���d�b�ԍ��P.Location = new System.Drawing.Point(106, 32);
			this.tex�˗���d�b�ԍ��P.MaxLength = 6;
			this.tex�˗���d�b�ԍ��P.Name = "tex�˗���d�b�ԍ��P";
			this.tex�˗���d�b�ԍ��P.ReadOnly = true;
			this.tex�˗���d�b�ԍ��P.Size = new System.Drawing.Size(52, 16);
			this.tex�˗���d�b�ԍ��P.TabIndex = 3;
			this.tex�˗���d�b�ԍ��P.TabStop = false;
			this.tex�˗���d�b�ԍ��P.Text = "";
			// 
			// tex�˗��吿����
			// 
			this.tex�˗��吿����.BackColor = System.Drawing.Color.Honeydew;
			this.tex�˗��吿����.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�˗��吿����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗��吿����.Location = new System.Drawing.Point(98, 175);
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
			this.lab�˗��啔��.Location = new System.Drawing.Point(66, 152);
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
			this.lab�˗��喼�O.Location = new System.Drawing.Point(40, 112);
			this.lab�˗��喼�O.Name = "lab�˗��喼�O";
			this.lab�˗��喼�O.Size = new System.Drawing.Size(56, 14);
			this.lab�˗��喼�O.TabIndex = 24;
			this.lab�˗��喼�O.Text = "���O";
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
			this.label16.Location = new System.Drawing.Point(206, 34);
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
			this.label17.Location = new System.Drawing.Point(156, 34);
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
			this.label18.Location = new System.Drawing.Point(96, 34);
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
			this.tex�˗��啔��.Location = new System.Drawing.Point(104, 148);
			this.tex�˗��啔��.MaxLength = 10;
			this.tex�˗��啔��.Name = "tex�˗��啔��";
			this.tex�˗��啔��.Size = new System.Drawing.Size(172, 23);
			this.tex�˗��啔��.TabIndex = 12;
			this.tex�˗��啔��.Text = "";
			// 
			// tex�˗��喼�O�Q
			// 
			this.tex�˗��喼�O�Q.BackColor = System.Drawing.Color.Honeydew;
			this.tex�˗��喼�O�Q.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�˗��喼�O�Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗��喼�O�Q.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�˗��喼�O�Q.Location = new System.Drawing.Point(106, 128);
			this.tex�˗��喼�O�Q.MaxLength = 20;
			this.tex�˗��喼�O�Q.Name = "tex�˗��喼�O�Q";
			this.tex�˗��喼�O�Q.ReadOnly = true;
			this.tex�˗��喼�O�Q.Size = new System.Drawing.Size(330, 16);
			this.tex�˗��喼�O�Q.TabIndex = 11;
			this.tex�˗��喼�O�Q.TabStop = false;
			this.tex�˗��喼�O�Q.Text = "";
			// 
			// tex�˗��喼�O�P
			// 
			this.tex�˗��喼�O�P.BackColor = System.Drawing.Color.Honeydew;
			this.tex�˗��喼�O�P.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�˗��喼�O�P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗��喼�O�P.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�˗��喼�O�P.Location = new System.Drawing.Point(106, 110);
			this.tex�˗��喼�O�P.MaxLength = 20;
			this.tex�˗��喼�O�P.Name = "tex�˗��喼�O�P";
			this.tex�˗��喼�O�P.ReadOnly = true;
			this.tex�˗��喼�O�P.Size = new System.Drawing.Size(330, 16);
			this.tex�˗��喼�O�P.TabIndex = 10;
			this.tex�˗��喼�O�P.TabStop = false;
			this.tex�˗��喼�O�P.Text = "";
			// 
			// tex�˗���X�֔ԍ��Q
			// 
			this.tex�˗���X�֔ԍ��Q.BackColor = System.Drawing.Color.Honeydew;
			this.tex�˗���X�֔ԍ��Q.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�˗���X�֔ԍ��Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗���X�֔ԍ��Q.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�˗���X�֔ԍ��Q.Location = new System.Drawing.Point(150, 52);
			this.tex�˗���X�֔ԍ��Q.MaxLength = 4;
			this.tex�˗���X�֔ԍ��Q.Name = "tex�˗���X�֔ԍ��Q";
			this.tex�˗���X�֔ԍ��Q.ReadOnly = true;
			this.tex�˗���X�֔ԍ��Q.Size = new System.Drawing.Size(36, 16);
			this.tex�˗���X�֔ԍ��Q.TabIndex = 7;
			this.tex�˗���X�֔ԍ��Q.TabStop = false;
			this.tex�˗���X�֔ԍ��Q.Text = "";
			// 
			// tex�˗���X�֔ԍ��P
			// 
			this.tex�˗���X�֔ԍ��P.BackColor = System.Drawing.Color.Honeydew;
			this.tex�˗���X�֔ԍ��P.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�˗���X�֔ԍ��P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗���X�֔ԍ��P.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�˗���X�֔ԍ��P.Location = new System.Drawing.Point(106, 52);
			this.tex�˗���X�֔ԍ��P.MaxLength = 3;
			this.tex�˗���X�֔ԍ��P.Name = "tex�˗���X�֔ԍ��P";
			this.tex�˗���X�֔ԍ��P.ReadOnly = true;
			this.tex�˗���X�֔ԍ��P.Size = new System.Drawing.Size(28, 16);
			this.tex�˗���X�֔ԍ��P.TabIndex = 6;
			this.tex�˗���X�֔ԍ��P.TabStop = false;
			this.tex�˗���X�֔ԍ��P.Text = "";
			// 
			// label14
			// 
			this.label14.BackColor = System.Drawing.Color.Honeydew;
			this.label14.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label14.ForeColor = System.Drawing.Color.LimeGreen;
			this.label14.Location = new System.Drawing.Point(134, 54);
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
			this.tex�˗���d�b�ԍ��R.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�˗���d�b�ԍ��R.Location = new System.Drawing.Point(222, 32);
			this.tex�˗���d�b�ԍ��R.MaxLength = 4;
			this.tex�˗���d�b�ԍ��R.Name = "tex�˗���d�b�ԍ��R";
			this.tex�˗���d�b�ԍ��R.ReadOnly = true;
			this.tex�˗���d�b�ԍ��R.Size = new System.Drawing.Size(36, 16);
			this.tex�˗���d�b�ԍ��R.TabIndex = 5;
			this.tex�˗���d�b�ԍ��R.TabStop = false;
			this.tex�˗���d�b�ԍ��R.Text = "";
			// 
			// tex�˗���d�b�ԍ��Q
			// 
			this.tex�˗���d�b�ԍ��Q.BackColor = System.Drawing.Color.Honeydew;
			this.tex�˗���d�b�ԍ��Q.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�˗���d�b�ԍ��Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗���d�b�ԍ��Q.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�˗���d�b�ԍ��Q.Location = new System.Drawing.Point(170, 32);
			this.tex�˗���d�b�ԍ��Q.MaxLength = 4;
			this.tex�˗���d�b�ԍ��Q.Name = "tex�˗���d�b�ԍ��Q";
			this.tex�˗���d�b�ԍ��Q.ReadOnly = true;
			this.tex�˗���d�b�ԍ��Q.Size = new System.Drawing.Size(32, 16);
			this.tex�˗���d�b�ԍ��Q.TabIndex = 4;
			this.tex�˗���d�b�ԍ��Q.TabStop = false;
			this.tex�˗���d�b�ԍ��Q.Text = "";
			// 
			// lab�˗���R�[�h
			// 
			this.lab�˗���R�[�h.BackColor = System.Drawing.Color.Honeydew;
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
			this.tex�˗���Z���Q.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�˗���Z���Q.Location = new System.Drawing.Point(106, 90);
			this.tex�˗���Z���Q.MaxLength = 20;
			this.tex�˗���Z���Q.Name = "tex�˗���Z���Q";
			this.tex�˗���Z���Q.ReadOnly = true;
			this.tex�˗���Z���Q.Size = new System.Drawing.Size(330, 16);
			this.tex�˗���Z���Q.TabIndex = 9;
			this.tex�˗���Z���Q.TabStop = false;
			this.tex�˗���Z���Q.Text = "";
			// 
			// tex�˗���Z���P
			// 
			this.tex�˗���Z���P.BackColor = System.Drawing.Color.Honeydew;
			this.tex�˗���Z���P.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�˗���Z���P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗���Z���P.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�˗���Z���P.Location = new System.Drawing.Point(106, 72);
			this.tex�˗���Z���P.MaxLength = 20;
			this.tex�˗���Z���P.Name = "tex�˗���Z���P";
			this.tex�˗���Z���P.ReadOnly = true;
			this.tex�˗���Z���P.Size = new System.Drawing.Size(330, 16);
			this.tex�˗���Z���P.TabIndex = 8;
			this.tex�˗���Z���P.TabStop = false;
			this.tex�˗���Z���P.Text = "";
			// 
			// btn�˗���o�^
			// 
			this.btn�˗���o�^.BackColor = System.Drawing.Color.Blue;
			this.btn�˗���o�^.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�˗���o�^.ForeColor = System.Drawing.Color.White;
			this.btn�˗���o�^.Location = new System.Drawing.Point(330, 148);
			this.btn�˗���o�^.Name = "btn�˗���o�^";
			this.btn�˗���o�^.Size = new System.Drawing.Size(92, 22);
			this.btn�˗���o�^.TabIndex = 14;
			this.btn�˗���o�^.TabStop = false;
			this.btn�˗���o�^.Text = "���˗���o�^";
			this.btn�˗���o�^.Click += new System.EventHandler(this.btn�˗���o�^_Click);
			// 
			// btn�˗��匟��
			// 
			this.btn�˗��匟��.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�˗��匟��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�˗��匟��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�˗��匟��.ForeColor = System.Drawing.Color.White;
			this.btn�˗��匟��.Location = new System.Drawing.Point(280, 4);
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
			this.label21.Size = new System.Drawing.Size(20, 216);
			this.label21.TabIndex = 3;
			this.label21.Text = "���˗���";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tex�˗���R�[�h
			// 
			this.tex�˗���R�[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex�˗���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�˗���R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�˗���R�[�h.Location = new System.Drawing.Point(106, 4);
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
			this.lab�˗��吿����.BackColor = System.Drawing.Color.Honeydew;
			this.lab�˗��吿����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�˗��吿����.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�˗��吿����.Location = new System.Drawing.Point(40, 176);
			this.lab�˗��吿����.Name = "lab�˗��吿����";
			this.lab�˗��吿����.Size = new System.Drawing.Size(44, 14);
			this.lab�˗��吿����.TabIndex = 9;
			this.lab�˗��吿����.Text = "������";
			// 
			// cBox�˗���Œ�
			// 
			this.cBox�˗���Œ�.ForeColor = System.Drawing.Color.Red;
			this.cBox�˗���Œ�.Location = new System.Drawing.Point(338, 8);
			this.cBox�˗���Œ�.Name = "cBox�˗���Œ�";
			this.cBox�˗���Œ�.Size = new System.Drawing.Size(70, 16);
			this.cBox�˗���Œ�.TabIndex = 2;
			this.cBox�˗���Œ�.TabStop = false;
			this.cBox�˗���Œ�.Text = "�Œ肷��";
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.Honeydew;
			this.panel3.Controls.Add(this.cBox�L���i���Œ�U);
			this.panel3.Controls.Add(this.cBox�L���i���Œ�T);
			this.panel3.Controls.Add(this.cBox�L���i���Œ�S);
			this.panel3.Controls.Add(this.tex�L�����U);
			this.panel3.Controls.Add(this.tex�L�����T);
			this.panel3.Controls.Add(this.tex�L�����S);
			this.panel3.Controls.Add(this.btn�L���i���Œ�);
			this.panel3.Controls.Add(this.cBox�L���i���Œ�P);
			this.panel3.Controls.Add(this.cBox�L���i���Œ�R);
			this.panel3.Controls.Add(this.cBox�L���i���Œ�Q);
			this.panel3.Controls.Add(this.cmb�w����敪);
			this.panel3.Controls.Add(this.tex�A�����q);
			this.panel3.Controls.Add(this.tex�A�����e);
			this.panel3.Controls.Add(this.tex�A���R�[�h�q);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.cBox�w����Œ�);
			this.panel3.Controls.Add(this.cBox�w���);
			this.panel3.Controls.Add(this.dt�w���);
			this.panel3.Controls.Add(this.btn�A������);
			this.panel3.Controls.Add(this.tex�A���R�[�h�e);
			this.panel3.Controls.Add(this.lab�A���R�[�h);
			this.panel3.Controls.Add(this.lab�A���w���);
			this.panel3.Controls.Add(this.lab�A���w��);
			this.panel3.Controls.Add(this.tex�L�����R);
			this.panel3.Controls.Add(this.tex�L�����Q);
			this.panel3.Controls.Add(this.tex�L�����P);
			this.panel3.Controls.Add(this.btn�L������);
			this.panel3.Controls.Add(this.tex�L���R�[�h);
			this.panel3.Controls.Add(this.lab�L���R�[�h);
			this.panel3.Controls.Add(this.lab�L��);
			this.panel3.Controls.Add(this.tex���q�l�Ǘ��ԍ�);
			this.panel3.Controls.Add(this.lab���q�l�Ǘ��ԍ�);
			this.panel3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.panel3.Location = new System.Drawing.Point(2, 6);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(336, 294);
			this.panel3.TabIndex = 3;
			// 
			// cBox�L���i���Œ�U
			// 
			this.cBox�L���i���Œ�U.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cBox�L���i���Œ�U.ForeColor = System.Drawing.Color.Red;
			this.cBox�L���i���Œ�U.Location = new System.Drawing.Point(320, 272);
			this.cBox�L���i���Œ�U.Name = "cBox�L���i���Œ�U";
			this.cBox�L���i���Œ�U.Size = new System.Drawing.Size(14, 14);
			this.cBox�L���i���Œ�U.TabIndex = 55;
			this.cBox�L���i���Œ�U.TabStop = false;
			// 
			// cBox�L���i���Œ�T
			// 
			this.cBox�L���i���Œ�T.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cBox�L���i���Œ�T.ForeColor = System.Drawing.Color.Red;
			this.cBox�L���i���Œ�T.Location = new System.Drawing.Point(320, 248);
			this.cBox�L���i���Œ�T.Name = "cBox�L���i���Œ�T";
			this.cBox�L���i���Œ�T.Size = new System.Drawing.Size(14, 14);
			this.cBox�L���i���Œ�T.TabIndex = 54;
			this.cBox�L���i���Œ�T.TabStop = false;
			// 
			// cBox�L���i���Œ�S
			// 
			this.cBox�L���i���Œ�S.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cBox�L���i���Œ�S.ForeColor = System.Drawing.Color.Red;
			this.cBox�L���i���Œ�S.Location = new System.Drawing.Point(320, 224);
			this.cBox�L���i���Œ�S.Name = "cBox�L���i���Œ�S";
			this.cBox�L���i���Œ�S.Size = new System.Drawing.Size(14, 14);
			this.cBox�L���i���Œ�S.TabIndex = 53;
			this.cBox�L���i���Œ�S.TabStop = false;
			// 
			// tex�L�����U
			// 
			this.tex�L�����U.BackColor = System.Drawing.SystemColors.Window;
			this.tex�L�����U.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�L�����U.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�L�����U.Location = new System.Drawing.Point(70, 268);
			this.tex�L�����U.MaxLength = 30;
			this.tex�L�����U.Name = "tex�L�����U";
			this.tex�L�����U.Size = new System.Drawing.Size(246, 23);
			this.tex�L�����U.TabIndex = 52;
			this.tex�L�����U.Text = "";
			// 
			// tex�L�����T
			// 
			this.tex�L�����T.BackColor = System.Drawing.SystemColors.Window;
			this.tex�L�����T.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�L�����T.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�L�����T.Location = new System.Drawing.Point(70, 244);
			this.tex�L�����T.MaxLength = 30;
			this.tex�L�����T.Name = "tex�L�����T";
			this.tex�L�����T.Size = new System.Drawing.Size(246, 23);
			this.tex�L�����T.TabIndex = 51;
			this.tex�L�����T.Text = "";
			// 
			// tex�L�����S
			// 
			this.tex�L�����S.BackColor = System.Drawing.SystemColors.Window;
			this.tex�L�����S.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�L�����S.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�L�����S.Location = new System.Drawing.Point(70, 220);
			this.tex�L�����S.MaxLength = 30;
			this.tex�L�����S.Name = "tex�L�����S";
			this.tex�L�����S.Size = new System.Drawing.Size(246, 23);
			this.tex�L�����S.TabIndex = 50;
			this.tex�L�����S.Text = "";
			// 
			// btn�L���i���Œ�
			// 
			this.btn�L���i���Œ�.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�L���i���Œ�.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�L���i���Œ�.Font = new System.Drawing.Font("MS UI Gothic", 9F);
			this.btn�L���i���Œ�.ForeColor = System.Drawing.Color.White;
			this.btn�L���i���Œ�.Location = new System.Drawing.Point(211, 124);
			this.btn�L���i���Œ�.Name = "btn�L���i���Œ�";
			this.btn�L���i���Œ�.Size = new System.Drawing.Size(124, 22);
			this.btn�L���i���Œ�.TabIndex = 0;
			this.btn�L���i���Œ�.TabStop = false;
			this.btn�L���i���Œ�.Text = "�L���E�i�����Œ肷��";
			this.btn�L���i���Œ�.Click += new System.EventHandler(this.btn�L���i���Œ�_Click);
			// 
			// cBox�L���i���Œ�P
			// 
			this.cBox�L���i���Œ�P.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cBox�L���i���Œ�P.ForeColor = System.Drawing.Color.Red;
			this.cBox�L���i���Œ�P.Location = new System.Drawing.Point(320, 152);
			this.cBox�L���i���Œ�P.Name = "cBox�L���i���Œ�P";
			this.cBox�L���i���Œ�P.Size = new System.Drawing.Size(14, 14);
			this.cBox�L���i���Œ�P.TabIndex = 49;
			this.cBox�L���i���Œ�P.TabStop = false;
			// 
			// cBox�L���i���Œ�R
			// 
			this.cBox�L���i���Œ�R.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cBox�L���i���Œ�R.ForeColor = System.Drawing.Color.Red;
			this.cBox�L���i���Œ�R.Location = new System.Drawing.Point(320, 200);
			this.cBox�L���i���Œ�R.Name = "cBox�L���i���Œ�R";
			this.cBox�L���i���Œ�R.Size = new System.Drawing.Size(14, 14);
			this.cBox�L���i���Œ�R.TabIndex = 48;
			this.cBox�L���i���Œ�R.TabStop = false;
			// 
			// cBox�L���i���Œ�Q
			// 
			this.cBox�L���i���Œ�Q.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cBox�L���i���Œ�Q.ForeColor = System.Drawing.Color.Red;
			this.cBox�L���i���Œ�Q.Location = new System.Drawing.Point(320, 176);
			this.cBox�L���i���Œ�Q.Name = "cBox�L���i���Œ�Q";
			this.cBox�L���i���Œ�Q.Size = new System.Drawing.Size(14, 14);
			this.cBox�L���i���Œ�Q.TabIndex = 47;
			this.cBox�L���i���Œ�Q.TabStop = false;
			// 
			// cmb�w����敪
			// 
			this.cmb�w����敪.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb�w����敪.Items.AddRange(new object[] {
														  "�K��",
														  "�w��"});
			this.cmb�w����敪.Location = new System.Drawing.Point(200, 26);
			this.cmb�w����敪.Name = "cmb�w����敪";
			this.cmb�w����敪.Size = new System.Drawing.Size(56, 24);
			this.cmb�w����敪.TabIndex = 43;
			this.cmb�w����敪.TabStop = false;
			// 
			// tex�A�����q
			// 
			this.tex�A�����q.BackColor = System.Drawing.Color.Honeydew;
			this.tex�A�����q.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�A�����q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�A�����q.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�A�����q.Location = new System.Drawing.Point(72, 100);
			this.tex�A�����q.MaxLength = 15;
			this.tex�A�����q.Name = "tex�A�����q";
			this.tex�A�����q.ReadOnly = true;
			this.tex�A�����q.Size = new System.Drawing.Size(246, 16);
			this.tex�A�����q.TabIndex = 42;
			this.tex�A�����q.TabStop = false;
			this.tex�A�����q.Text = "";
			// 
			// tex�A�����e
			// 
			this.tex�A�����e.BackColor = System.Drawing.Color.Honeydew;
			this.tex�A�����e.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�A�����e.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�A�����e.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�A�����e.Location = new System.Drawing.Point(72, 78);
			this.tex�A�����e.MaxLength = 15;
			this.tex�A�����e.Name = "tex�A�����e";
			this.tex�A�����e.ReadOnly = true;
			this.tex�A�����e.Size = new System.Drawing.Size(246, 16);
			this.tex�A�����e.TabIndex = 41;
			this.tex�A�����e.TabStop = false;
			this.tex�A�����e.Text = "";
			// 
			// tex�A���R�[�h�q
			// 
			this.tex�A���R�[�h�q.BackColor = System.Drawing.SystemColors.Window;
			this.tex�A���R�[�h�q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�A���R�[�h�q.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�A���R�[�h�q.Location = new System.Drawing.Point(26, 96);
			this.tex�A���R�[�h�q.MaxLength = 4;
			this.tex�A���R�[�h�q.Name = "tex�A���R�[�h�q";
			this.tex�A���R�[�h�q.Size = new System.Drawing.Size(42, 23);
			this.tex�A���R�[�h�q.TabIndex = 5;
			this.tex�A���R�[�h�q.Text = "";
			this.tex�A���R�[�h�q.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�A���R�[�h�q_KeyDown);
			this.tex�A���R�[�h�q.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�A���R�[�h�q_KeyPress);
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(74, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(108, 16);
			this.label3.TabIndex = 38;
			// 
			// cBox�w����Œ�
			// 
			this.cBox�w����Œ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cBox�w����Œ�.ForeColor = System.Drawing.Color.Red;
			this.cBox�w����Œ�.Location = new System.Drawing.Point(258, 30);
			this.cBox�w����Œ�.Name = "cBox�w����Œ�";
			this.cBox�w����Œ�.Size = new System.Drawing.Size(68, 18);
			this.cBox�w����Œ�.TabIndex = 3;
			this.cBox�w����Œ�.TabStop = false;
			this.cBox�w����Œ�.Text = "�Œ肷��";
			// 
			// cBox�w���
			// 
			this.cBox�w���.Location = new System.Drawing.Point(54, 28);
			this.cBox�w���.Name = "cBox�w���";
			this.cBox�w���.Size = new System.Drawing.Size(16, 20);
			this.cBox�w���.TabIndex = 1;
			this.cBox�w���.TabStop = false;
			this.cBox�w���.Click += new System.EventHandler(this.cBox�w���_Click);
			// 
			// dt�w���
			// 
			this.dt�w���.CalendarFont = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.dt�w���.CustomFormat = "";
			this.dt�w���.Font = new System.Drawing.Font("MS UI Gothic", 12F);
			this.dt�w���.Location = new System.Drawing.Point(70, 26);
			this.dt�w���.MaxDate = new System.DateTime(2105, 12, 31, 0, 0, 0, 0);
			this.dt�w���.MinDate = new System.DateTime(2005, 1, 1, 0, 0, 0, 0);
			this.dt�w���.Name = "dt�w���";
			this.dt�w���.Size = new System.Drawing.Size(132, 23);
			this.dt�w���.TabIndex = 2;
			this.dt�w���.TabStop = false;
			this.dt�w���.Value = new System.DateTime(2005, 1, 26, 0, 0, 0, 0);
			this.dt�w���.DropDown += new System.EventHandler(this.dt�w���_DropDown);
			this.dt�w���.CloseUp += new System.EventHandler(this.dt�w���_CloseUp);
			// 
			// btn�A������
			// 
			this.btn�A������.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�A������.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�A������.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�A������.ForeColor = System.Drawing.Color.White;
			this.btn�A������.Location = new System.Drawing.Point(70, 52);
			this.btn�A������.Name = "btn�A������";
			this.btn�A������.Size = new System.Drawing.Size(48, 22);
			this.btn�A������.TabIndex = 3;
			this.btn�A������.TabStop = false;
			this.btn�A������.Text = "����";
			this.btn�A������.Click += new System.EventHandler(this.btn�A������_Click);
			// 
			// tex�A���R�[�h�e
			// 
			this.tex�A���R�[�h�e.BackColor = System.Drawing.SystemColors.Window;
			this.tex�A���R�[�h�e.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�A���R�[�h�e.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�A���R�[�h�e.Location = new System.Drawing.Point(26, 74);
			this.tex�A���R�[�h�e.MaxLength = 4;
			this.tex�A���R�[�h�e.Name = "tex�A���R�[�h�e";
			this.tex�A���R�[�h�e.Size = new System.Drawing.Size(42, 23);
			this.tex�A���R�[�h�e.TabIndex = 4;
			this.tex�A���R�[�h�e.Text = "";
			this.tex�A���R�[�h�e.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�A���R�[�h�e_KeyDown);
			this.tex�A���R�[�h�e.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�A���R�[�h�e_KeyPress);
			// 
			// lab�A���R�[�h
			// 
			this.lab�A���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�A���R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�A���R�[�h.Location = new System.Drawing.Point(26, 56);
			this.lab�A���R�[�h.Name = "lab�A���R�[�h";
			this.lab�A���R�[�h.Size = new System.Drawing.Size(42, 14);
			this.lab�A���R�[�h.TabIndex = 36;
			this.lab�A���R�[�h.Text = "�R�[�h";
			// 
			// lab�A���w���
			// 
			this.lab�A���w���.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�A���w���.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�A���w���.Location = new System.Drawing.Point(4, 30);
			this.lab�A���w���.Name = "lab�A���w���";
			this.lab�A���w���.Size = new System.Drawing.Size(64, 14);
			this.lab�A���w���.TabIndex = 33;
			this.lab�A���w���.Text = "�w���";
			// 
			// lab�A���w��
			// 
			this.lab�A���w��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�A���w��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�A���w��.ForeColor = System.Drawing.Color.Blue;
			this.lab�A���w��.Location = new System.Drawing.Point(4, 56);
			this.lab�A���w��.Name = "lab�A���w��";
			this.lab�A���w��.Size = new System.Drawing.Size(18, 62);
			this.lab�A���w��.TabIndex = 32;
			this.lab�A���w��.Text = "�A�����i";
			this.lab�A���w��.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tex�L�����R
			// 
			this.tex�L�����R.BackColor = System.Drawing.SystemColors.Window;
			this.tex�L�����R.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�L�����R.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�L�����R.Location = new System.Drawing.Point(70, 196);
			this.tex�L�����R.MaxLength = 30;
			this.tex�L�����R.Name = "tex�L�����R";
			this.tex�L�����R.Size = new System.Drawing.Size(246, 23);
			this.tex�L�����R.TabIndex = 14;
			this.tex�L�����R.Text = "";
			// 
			// tex�L�����Q
			// 
			this.tex�L�����Q.BackColor = System.Drawing.SystemColors.Window;
			this.tex�L�����Q.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�L�����Q.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�L�����Q.Location = new System.Drawing.Point(70, 172);
			this.tex�L�����Q.MaxLength = 30;
			this.tex�L�����Q.Name = "tex�L�����Q";
			this.tex�L�����Q.Size = new System.Drawing.Size(246, 23);
			this.tex�L�����Q.TabIndex = 12;
			this.tex�L�����Q.Text = "";
			// 
			// tex�L�����P
			// 
			this.tex�L�����P.BackColor = System.Drawing.SystemColors.Window;
			this.tex�L�����P.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�L�����P.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex�L�����P.Location = new System.Drawing.Point(70, 148);
			this.tex�L�����P.MaxLength = 30;
			this.tex�L�����P.Name = "tex�L�����P";
			this.tex�L�����P.Size = new System.Drawing.Size(246, 23);
			this.tex�L�����P.TabIndex = 10;
			this.tex�L�����P.Text = "";
			// 
			// btn�L������
			// 
			this.btn�L������.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�L������.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�L������.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�L������.ForeColor = System.Drawing.Color.White;
			this.btn�L������.Location = new System.Drawing.Point(70, 124);
			this.btn�L������.Name = "btn�L������";
			this.btn�L������.Size = new System.Drawing.Size(48, 22);
			this.btn�L������.TabIndex = 9;
			this.btn�L������.TabStop = false;
			this.btn�L������.Text = "����";
			this.btn�L������.Click += new System.EventHandler(this.btn�L������_Click);
			// 
			// tex�L���R�[�h
			// 
			this.tex�L���R�[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex�L���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�L���R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�L���R�[�h.Location = new System.Drawing.Point(26, 148);
			this.tex�L���R�[�h.MaxLength = 4;
			this.tex�L���R�[�h.Name = "tex�L���R�[�h";
			this.tex�L���R�[�h.Size = new System.Drawing.Size(42, 23);
			this.tex�L���R�[�h.TabIndex = 8;
			this.tex�L���R�[�h.Text = "";
			this.tex�L���R�[�h.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�L���R�[�h_KeyDown);
			this.tex�L���R�[�h.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�L���R�[�h_KeyPress);
			// 
			// lab�L���R�[�h
			// 
			this.lab�L���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�L���R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�L���R�[�h.Location = new System.Drawing.Point(26, 126);
			this.lab�L���R�[�h.Name = "lab�L���R�[�h";
			this.lab�L���R�[�h.Size = new System.Drawing.Size(42, 14);
			this.lab�L���R�[�h.TabIndex = 11;
			this.lab�L���R�[�h.Text = "�R�[�h";
			// 
			// lab�L��
			// 
			this.lab�L��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�L��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�L��.ForeColor = System.Drawing.Color.Blue;
			this.lab�L��.Location = new System.Drawing.Point(4, 122);
			this.lab�L��.Name = "lab�L��";
			this.lab�L��.Size = new System.Drawing.Size(18, 168);
			this.lab�L��.TabIndex = 9;
			this.lab�L��.Text = "�L���E�i��";
			this.lab�L��.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tex���q�l�Ǘ��ԍ�
			// 
			this.tex���q�l�Ǘ��ԍ�.BackColor = System.Drawing.SystemColors.Window;
			this.tex���q�l�Ǘ��ԍ�.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���q�l�Ǘ��ԍ�.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex���q�l�Ǘ��ԍ�.Location = new System.Drawing.Point(70, 2);
			this.tex���q�l�Ǘ��ԍ�.MaxLength = 16;
			this.tex���q�l�Ǘ��ԍ�.Name = "tex���q�l�Ǘ��ԍ�";
			this.tex���q�l�Ǘ��ԍ�.Size = new System.Drawing.Size(190, 23);
			this.tex���q�l�Ǘ��ԍ�.TabIndex = 0;
			this.tex���q�l�Ǘ��ԍ�.Text = "";
			// 
			// lab���q�l�Ǘ��ԍ�
			// 
			this.lab���q�l�Ǘ��ԍ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���q�l�Ǘ��ԍ�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���q�l�Ǘ��ԍ�.Location = new System.Drawing.Point(4, 8);
			this.lab���q�l�Ǘ��ԍ�.Name = "lab���q�l�Ǘ��ԍ�";
			this.lab���q�l�Ǘ��ԍ�.Size = new System.Drawing.Size(70, 14);
			this.lab���q�l�Ǘ��ԍ�.TabIndex = 9;
			this.lab���q�l�Ǘ��ԍ�.Text = "���q�l�ԍ�";
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
			this.panel4.Controls.Add(this.cBox���Œ�);
			this.panel4.Location = new System.Drawing.Point(2, 6);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(336, 92);
			this.panel4.TabIndex = 4;
			// 
			// lab�d��
			// 
			this.lab�d��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�d��.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�d��.ForeColor = System.Drawing.Color.Blue;
			this.lab�d��.Location = new System.Drawing.Point(112, 4);
			this.lab�d��.Name = "lab�d��";
			this.lab�d��.Size = new System.Drawing.Size(104, 30);
			this.lab�d��.TabIndex = 50;
			this.lab�d��.Text = "�d��(kg)";
			this.lab�d��.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lab�d��.Visible = false;
			// 
			// nUD�d��
			// 
			this.nUD�d��.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.nUD�d��.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.nUD�d��.Location = new System.Drawing.Point(142, 38);
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
			this.nUD�ی����z.Location = new System.Drawing.Point(250, 38);
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
			this.lab�ی����z.Location = new System.Drawing.Point(220, 4);
			this.lab�ی����z.Name = "lab�ی����z";
			this.lab�ی����z.Size = new System.Drawing.Size(104, 30);
			this.lab�ی����z.TabIndex = 10;
			this.lab�ی����z.Text = "�ی����z�i���~�j";
			this.lab�ی����z.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nUD��
			// 
			this.nUD��.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.nUD��.Location = new System.Drawing.Point(64, 38);
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
			this.label2.Location = new System.Drawing.Point(26, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(12, 16);
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
			this.lab��.Size = new System.Drawing.Size(104, 30);
			this.lab��.TabIndex = 4;
			this.lab��.Text = "��";
			this.lab��.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cBox���Œ�
			// 
			this.cBox���Œ�.ForeColor = System.Drawing.Color.Red;
			this.cBox���Œ�.Location = new System.Drawing.Point(6, 72);
			this.cBox���Œ�.Name = "cBox���Œ�";
			this.cBox���Œ�.Size = new System.Drawing.Size(102, 16);
			this.cBox���Œ�.TabIndex = 46;
			this.cBox���Œ�.TabStop = false;
			this.cBox���Œ�.Text = "�����Œ肷��";
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.Honeydew;
			this.panel5.Controls.Add(this.cBox�o�ד��Œ�);
			this.panel5.Controls.Add(this.dt�o�ד�);
			this.panel5.Controls.Add(this.lab�o�ד�);
			this.panel5.Location = new System.Drawing.Point(2, 6);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(420, 32);
			this.panel5.TabIndex = 0;
			// 
			// cBox�o�ד��Œ�
			// 
			this.cBox�o�ד��Œ�.ForeColor = System.Drawing.Color.Red;
			this.cBox�o�ד��Œ�.Location = new System.Drawing.Point(238, 8);
			this.cBox�o�ד��Œ�.Name = "cBox�o�ד��Œ�";
			this.cBox�o�ד��Œ�.Size = new System.Drawing.Size(114, 16);
			this.cBox�o�ד��Œ�.TabIndex = 1;
			this.cBox�o�ד��Œ�.TabStop = false;
			this.cBox�o�ד��Œ�.Text = "�o�ד����Œ肷��";
			// 
			// dt�o�ד�
			// 
			this.dt�o�ד�.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.dt�o�ד�.Location = new System.Drawing.Point(84, 5);
			this.dt�o�ד�.MaxDate = new System.DateTime(2105, 12, 31, 0, 0, 0, 0);
			this.dt�o�ד�.MinDate = new System.DateTime(2005, 1, 1, 0, 0, 0, 0);
			this.dt�o�ד�.Name = "dt�o�ד�";
			this.dt�o�ד�.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.dt�o�ד�.Size = new System.Drawing.Size(144, 23);
			this.dt�o�ד�.TabIndex = 0;
			this.dt�o�ד�.TabStop = false;
			this.dt�o�ד�.Value = new System.DateTime(2005, 1, 26, 0, 0, 0, 0);
			this.dt�o�ד�.ValueChanged += new System.EventHandler(this.dt�o�ד�_ValueChanged);
			// 
			// lab�o�ד�
			// 
			this.lab�o�ד�.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�o�ד�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�o�ד�.Location = new System.Drawing.Point(18, 8);
			this.lab�o�ד�.Name = "lab�o�ד�";
			this.lab�o�ד�.Size = new System.Drawing.Size(56, 16);
			this.lab�o�ד�.TabIndex = 6;
			this.lab�o�ד�.Text = "�o�ד�";
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.PaleGreen;
			this.panel6.Controls.Add(this.lbl���q�^��);
			this.panel6.Controls.Add(this.tex���q�l��);
			this.panel6.Controls.Add(this.lab���q�l��);
			this.panel6.Controls.Add(this.lab���p����);
			this.panel6.Controls.Add(this.tex���p����);
			this.panel6.Location = new System.Drawing.Point(0, 26);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(810, 26);
			this.panel6.TabIndex = 12;
			// 
			// lbl���q�^��
			// 
			this.lbl���q�^��.Font = new System.Drawing.Font("�l�r �S�V�b�N", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lbl���q�^��.ForeColor = System.Drawing.Color.Red;
			this.lbl���q�^��.Location = new System.Drawing.Point(626, 2);
			this.lbl���q�^��.Name = "lbl���q�^��";
			this.lbl���q�^��.Size = new System.Drawing.Size(156, 32);
			this.lbl���q�^��.TabIndex = 20;
			this.lbl���q�^��.Text = "���q�^���Ή�";
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
			this.panel7.Controls.Add(this.lab�o�דo�^�^�C�g��);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(792, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab����
			// 
			this.lab����.ForeColor = System.Drawing.Color.White;
			this.lab����.Location = new System.Drawing.Point(674, 8);
			this.lab����.Name = "lab����";
			this.lab����.Size = new System.Drawing.Size(112, 14);
			this.lab����.TabIndex = 1;
			this.lab����.Text = "2005/xx/xx 12:00:00";
			// 
			// lab�o�דo�^�^�C�g��
			// 
			this.lab�o�דo�^�^�C�g��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�o�דo�^�^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�o�דo�^�^�C�g��.ForeColor = System.Drawing.Color.White;
			this.lab�o�דo�^�^�C�g��.Location = new System.Drawing.Point(12, 2);
			this.lab�o�דo�^�^�C�g��.Name = "lab�o�דo�^�^�C�g��";
			this.lab�o�דo�^�^�C�g��.Size = new System.Drawing.Size(264, 24);
			this.lab�o�דo�^�^�C�g��.TabIndex = 0;
			this.lab�o�דo�^�^�C�g��.Text = "�G���g���[";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn�폜);
			this.panel8.Controls.Add(this.btn���);
			this.panel8.Controls.Add(this.btn�X�V);
			this.panel8.Controls.Add(this.tex���b�Z�[�W);
			this.panel8.Controls.Add(this.btn����);
			this.panel8.Controls.Add(this.btn�������);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 14;
			// 
			// btn�폜
			// 
			this.btn�폜.ForeColor = System.Drawing.Color.Blue;
			this.btn�폜.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�폜.Location = new System.Drawing.Point(322, 6);
			this.btn�폜.Name = "btn�폜";
			this.btn�폜.Size = new System.Drawing.Size(62, 48);
			this.btn�폜.TabIndex = 4;
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
			this.btn���.TabIndex = 3;
			this.btn���.Text = "���";
			this.btn���.Click += new System.EventHandler(this.btn���_Click);
			// 
			// btn�X�V
			// 
			this.btn�X�V.ForeColor = System.Drawing.Color.Blue;
			this.btn�X�V.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�X�V.Location = new System.Drawing.Point(168, 6);
			this.btn�X�V.Name = "btn�X�V";
			this.btn�X�V.Size = new System.Drawing.Size(62, 48);
			this.btn�X�V.TabIndex = 2;
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
			this.tex���b�Z�[�W.TabIndex = 5;
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
			// btn�������
			// 
			this.btn�������.ForeColor = System.Drawing.Color.Blue;
			this.btn�������.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�������.Location = new System.Drawing.Point(98, 6);
			this.btn�������.Name = "btn�������";
			this.btn�������.Size = new System.Drawing.Size(62, 48);
			this.btn�������.TabIndex = 1;
			this.btn�������.Text = "���x���@�@���";
			this.btn�������.Click += new System.EventHandler(this.btn�������_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel5);
			this.groupBox1.Location = new System.Drawing.Point(24, 50);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(424, 40);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel1);
			this.groupBox2.Location = new System.Drawing.Point(4, 85);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(444, 229);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.panel2);
			this.groupBox3.Location = new System.Drawing.Point(4, 310);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(444, 204);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.panel3);
			this.groupBox4.Location = new System.Drawing.Point(450, 85);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(340, 303);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.panel4);
			this.groupBox5.Location = new System.Drawing.Point(450, 385);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(340, 100);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			// 
			// tex���b�Z�[�W�Q
			// 
			this.tex���b�Z�[�W�Q.BackColor = System.Drawing.Color.PaleGreen;
			this.tex���b�Z�[�W�Q.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���b�Z�[�W�Q.ForeColor = System.Drawing.Color.Red;
			this.tex���b�Z�[�W�Q.Location = new System.Drawing.Point(450, 462);
			this.tex���b�Z�[�W�Q.Multiline = true;
			this.tex���b�Z�[�W�Q.Name = "tex���b�Z�[�W�Q";
			this.tex���b�Z�[�W�Q.ReadOnly = true;
			this.tex���b�Z�[�W�Q.Size = new System.Drawing.Size(340, 52);
			this.tex���b�Z�[�W�Q.TabIndex = 15;
			this.tex���b�Z�[�W�Q.TabStop = false;
			this.tex���b�Z�[�W�Q.Text = "";
			// 
			// �o�דo�^
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 580);
			this.Controls.Add(this.tex���b�Z�[�W�Q);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox5);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "�o�דo�^";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 �G���g���[";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Closed += new System.EventHandler(this.�o�דo�^_Closed);
			this.Activated += new System.EventHandler(this.�o�דo�^_Activated);
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nUD�d��)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD�ی����z)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD��)).EndInit();
			this.panel5.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		private void Form1_Load(object sender, System.EventArgs e)
		{
// ADD 2005.06.24 ���s�j�����J ������ START
			i�����e�f = 0;
// ADD 2005.06.24 ���s�j�����J ������ END
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

// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� START
			//����X�����擾����Ă��Ȃ��ꍇ�ɂ́A
			if(gs����X���b�c == null || gs����X���b�c.Length == 0){
				gs����X���b�c = ����X���擾(gs����b�c);
			}
// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� END

			tex���b�Z�[�W�Q.Visible = false;

// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� START
			if (gs����b�c.Substring(0,1) != "J")
			{
				lbl���q�^��.Visible=false;
			}
			else
			{
				lbl���q�^��.Visible=true;
			}
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END


			// �o�ד��̏����ݒ�i�����j
			����o�ד����X�V();
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
			//�w����`�F�b�N�𖳌��ɂ���
			//�idt�o�ד�.Value�j��ύX�����C�x���g�Ń`�F�b�N�������
			cBox�w���.Checked = false;
			b�w����`�F�b�N�l�r�f�L = false;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
			dt�o�ד�.Value   = gdt�o�ד�;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
			b�w����`�F�b�N�l�r�f�L = true;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
			dt�o�ד�.MinDate = gdt�o�ד�;
// ADD 2009.04.02 ���s�j���� �ғ����Ή� START
//			dt�o�ד�.MaxDate = gdt�o�ד�.AddDays(7);
			dt�o�ד�.MaxDate = gdt�o�ד��ő�l;
// ADD 2009.04.02 ���s�j���� �ғ����Ή� END
			// �z�B�w����̏����ݒ�i�����{�Q���j
// MOD 2006.06.27 ���s�j�R�{�@�o�ד��𗂓��ɕύX�@START
			dt�w���.Value   = gdt�o�ד�.AddDays(1);
//			dt�w���.Value   = gdt�o�ד�.AddDays(2);
// MOD 2006.06.27 ���s�j�R�{�@�o�ד��𗂓��ɕύX�@END
			dt�w���.MinDate = gdt�o�ד�;
// ADD 2009.04.02 ���s�j���� �ғ����Ή� START
//			dt�w���.MaxDate = gdt�o�ד�.AddDays(20);
// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� START
//			dt�w���.MaxDate = gdt�o�ד�.AddDays(14);
			if(gs����X���b�c.Equals("047")){
				dt�w���.MaxDate = gdt�o�ד�.AddDays(90);
			}else{
				dt�w���.MaxDate = gdt�o�ד�.AddDays(14);
			}
// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� END
// MOD 2016.04.13 BEVAS�j���{ �z�B�w�������̊g�� START
			//�Z���A�l�̏ꍇ�A�z�B�w����̏����180���ɂ܂Ŋg��
			if(gs����b�c.Equals(gs�w�������g������b�c))
			{
				dt�w���.MaxDate = gdt�o�ד�.AddDays(180);
			}
// MOD 2016.04.13 BEVAS�j���{ �z�B�w�������̊g�� END
// ADD 2009.04.02 ���s�j���� �ғ����Ή� END
			cBox�w���.Checked = false;
			label3.Visible = true;
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
//			label�K��.Visible = false;
			cmb�w����敪.Visible = false;
			cmb�w����敪.SelectedIndex = 0;
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� END
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@END
			cBox�w����Œ�.Visible = false;
			cBox�w����Œ�.Checked = false;

// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX START
			nUD�ی����z.Minimum =  0;
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) START
//			nUD�ی����z.Maximum = 30;
			nUD�ی����z.Maximum = gl�ی����z���;
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) END
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX END

			�X�V�\����();

//			btn�������.Visible = false;
			btn�폜.Visible = false;

// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
//			if(gs�v�����^�e�f != "1")
//				btn�������.Visible = false;
			if(gs�v�����^�e�f != "1" || gb�����o�͂n�m){
				btn�������.Visible = false;
			}else{
				btn�������.Visible = true;
			}
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END

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
			// �X�V���[�h�ŊJ���ꂽ�ꍇ
			if(s�����e�f == "U")
			{
// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� START
				�L���i���Œ薳��();
// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� END
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
//				btn�������.Visible = true;
//				// �[���ݒ�Ńv�����^���g�p�ł��Ȃ��ݒ�̏ꍇ�A����{�^���g�p�s��
//				if(gs�v�����^�e�f != "1")
//					btn�������.Visible = false;
				// �[���ݒ�Ńv�����^���g�p�ł��Ȃ��ݒ�̏ꍇ�A����{�^���g�p�s��
				if(gs�v�����^�e�f != "1" || gb�����o�͂n�m){
					btn�������.Visible = false;
				}else{
					btn�������.Visible = true;
				}
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
				btn�폜.Visible = true;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
				b�w����`�F�b�N�l�r�f�L = false;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
				�o�׌���();
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
				b�w����`�F�b�N�l�r�f�L = true;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� START
				s�C���O_�˗���b�c = tex�˗���R�[�h.Text.TrimEnd();
				s�C���O_������b�c = tex������R�[�h.Text.TrimEnd();
				s�C���O_�����敔�� = tex�����敔�ۃR�[�h.Text.TrimEnd();
				s�C���O_�����於   = tex�˗��吿����.Text.TrimEnd();
				s�C���O_��       = nUD��.Text.TrimEnd();
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� END
			}
			else
			{
				if(i���^�m�n > 0)
				{
// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� START
					�L���i���Œ薳��();
// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� END
					���^����();
					dt�o�ד�.Value = dt���^�o�ד�;
					if(b���^�w���)
					{
						dt�w���.Value = dt���^�w���;
						cBox�w���.Checked = true;
						label3.Visible = false;
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
//						label�K��.Visible = true;
						cmb�w����敪.Visible = true;
						cmb�w����敪.SelectedIndex = i���^�w����敪;
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� END
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@END
						cBox�w����Œ�.Visible = true;
					}
					else
					{
						label3.Visible = true;
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
//						label�K��.Visible = false;
						cmb�w����敪.Visible = false;
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� END
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@END
						cBox�w���.Checked = false;
						cBox�w����Œ�.Visible = false;
					}
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� START
					s�C���O_�˗���b�c = tex�˗���R�[�h.Text.TrimEnd();
					s�C���O_������b�c = tex������R�[�h.Text.TrimEnd();
					s�C���O_�����敔�� = tex�����敔�ۃR�[�h.Text.TrimEnd();
					s�C���O_�����於   = tex�˗��吿����.Text.TrimEnd();
					s�C���O_��       = nUD��.Text.TrimEnd();
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� END
				}
				else
				{
// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� START
					�L���i���Œ�L��();
					�L���i���Œ�Ǎ�();
// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� END
					�A�����i���d�ʐ���();
				}
//				else
//				{
//					tex�˗���R�[�h.Text = gs�ב��l�b�c;
//					s�˗���b�c          = gs�ב��l�b�c;
//					if(s�˗���b�c.Length > 0) �˗��匟��();
//				}
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
				bRet = ��ʐ���ݒ�(sList[5]);
				tex���q�l�Ǘ��ԍ�.TabStop = bRet;
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
// ADD 2006.06.28 ���s�j�R�{�@ �G���g���I�v�V�����̍��ڒǉ� START
				bRet = ��ʐ���ݒ�(sList[11]);
				tex�˗���R�[�h.TabStop = bRet;
// ADD 2006.06.28 ���s�j�R�{�@ �G���g���I�v�V�����̍��ڒǉ� END
// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� START
				��ʐ���ݒ�Q(tex�͂���Z���Q, sList[1]);
				��ʐ���ݒ�Q(tex�͂���Z���R, sList[2]);
				��ʐ���ݒ�Q(tex�͂��於�O�Q, sList[3]);
				��ʐ���ݒ�Q(tex�˗��啔��, sList[4]);
				��ʐ���ݒ�Q(tex���q�l�Ǘ��ԍ�, sList[5]);
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
				s��ʐ���_�˗���        = sList[11];
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

		private void btn�͂���o�^_Click(object sender, System.EventArgs e)
		{
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
			if(gs�I�v�V����[18].Equals("1")){
				tex�͂���Z���P.Text       = tex�͂���Z���P.Text.TrimEnd();
				tex�͂���Z���Q.Text       = tex�͂���Z���Q.Text.TrimEnd();
				tex�͂���Z���R.Text       = tex�͂���Z���R.Text.TrimEnd();
				tex�͂��於�O�P.Text       = tex�͂��於�O�P.Text.TrimEnd();
				tex�͂��於�O�Q.Text       = tex�͂��於�O�Q.Text.TrimEnd();
			}else{
				tex�͂���Z���P.Text       = tex�͂���Z���P.Text.Trim();
				tex�͂���Z���Q.Text       = tex�͂���Z���Q.Text.Trim();
				tex�͂���Z���R.Text       = tex�͂���Z���R.Text.Trim();
				tex�͂��於�O�P.Text       = tex�͂��於�O�P.Text.Trim();
				tex�͂��於�O�Q.Text       = tex�͂��於�O�Q.Text.Trim();
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END

			//�R�[�h�̈��p���Ȃ�
//			if(!�K�{�`�F�b�N(tex�͂���R�[�h)) return;
			if(!�K�{�`�F�b�N(tex�͂���d�b�ԍ��P,"�͂���d�b�ԍ��P")) return;
			if(!�K�{�`�F�b�N(tex�͂���d�b�ԍ��Q,"�͂���d�b�ԍ��Q")) return;
			if(!�K�{�`�F�b�N(tex�͂���d�b�ԍ��R,"�͂���d�b�ԍ��R")) return;
			if(!�K�{�`�F�b�N(tex�͂���X�֔ԍ��P,"�͂���X�֔ԍ��P")) return;
			if(!�K�{�`�F�b�N(tex�͂���X�֔ԍ��Q,"�͂���X�֔ԍ��Q")) return;
			if(!�K�{�`�F�b�N(tex�͂���Z���P,"�͂���Z���P")) return;
			if(!�K�{�`�F�b�N(tex�͂��於�O�P,"�͂��於�O�P")) return;

//			if(!���p�`�F�b�N(tex�͂���R�[�h)) return;
			if(!���l�`�F�b�N(tex�͂���d�b�ԍ��P,"�͂���d�b�ԍ��P")) return;
			if(!���l�`�F�b�N(tex�͂���d�b�ԍ��Q,"�͂���d�b�ԍ��Q")) return;
			if(!���l�`�F�b�N(tex�͂���d�b�ԍ��R,"�͂���d�b�ԍ��R")) return;
			if(!���p�`�F�b�N(tex�͂���X�֔ԍ��P,"�͂���X�֔ԍ��P")) return;
			if(!���p�`�F�b�N(tex�͂���X�֔ԍ��Q,"�͂���X�֔ԍ��Q")) return;
// MOD 2011.12.08 ���s�j���� �Z���E���O�̔��p���͉� START
//			if(!�S�p�`�F�b�N(tex�͂���Z���P,"�͂���Z���P")) return;
//			if(!�S�p�`�F�b�N(tex�͂���Z���Q,"�͂���Z���Q")) return;
//			if(!�S�p�`�F�b�N(tex�͂���Z���R,"�͂���Z���R")) return;
//			if(!�S�p�`�F�b�N(tex�͂��於�O�P,"�͂��於�O�P")) return;
//			if(!�S�p�`�F�b�N(tex�͂��於�O�Q,"�͂��於�O�Q")) return;
			if(!�S�p�ϊ��`�F�b�N(tex�͂���Z���P,"�͂���Z���P")) return;
			if(!�S�p�ϊ��`�F�b�N(tex�͂���Z���Q,"�͂���Z���Q")) return;
			if(!�S�p�ϊ��`�F�b�N(tex�͂���Z���R,"�͂���Z���R")) return;
			if(!�S�p�ϊ��`�F�b�N(tex�͂��於�O�P,"�͂��於�O�P")) return;
			if(!�S�p�ϊ��`�F�b�N(tex�͂��於�O�Q,"�͂��於�O�Q")) return;
// MOD 2011.12.08 ���s�j���� �Z���E���O�̔��p���͉� END

			//�X�֔ԍ����݃`�F�b�N
			string s�X�֔ԍ� = tex�͂���X�֔ԍ��P.Text + tex�͂���X�֔ԍ��Q.Text;
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

			if(sRet[0].Length != 4)
			{
				if(sRet[0].Equals("�Y���f�[�^������܂���"))
					sRet[0] = "�X�֔ԍ������݂��܂���";
				tex���b�Z�[�W.Text = sRet[0];
				�r�[�v��();
				tex�͂���X�֔ԍ��P.Focus();
				return;
			}



// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			���͂���o�^�� ��� = new ���͂���o�^��();
//			���.Height = ���.Height + 13;////
//			���.Left = this.Left + panel2.Left + 1;
//			���.Top = this.Top + panel2.Top + 10;
//
//			���.sTdata[2]  = tex�͂���d�b�ԍ��P.Text;
//			���.sTdata[3]  = tex�͂���d�b�ԍ��Q.Text;
//			���.sTdata[4]  = tex�͂���d�b�ԍ��R.Text;
//			���.sTdata[5]  = tex�͂���X�֔ԍ��P.Text;
//			���.sTdata[6]  = tex�͂���X�֔ԍ��Q.Text;
//			���.sTdata[7]  = tex�͂���Z���P.Text;
//			���.sTdata[8]  = tex�͂���Z���Q.Text;
//			���.sTdata[9]  = tex�͂���Z���R.Text;
//			���.sTdata[10] = tex�͂��於�O�P.Text;
//			���.sTdata[11] = tex�͂��於�O�Q.Text;
//
//			���.s�͂���b�c = tex�͂���R�[�h.Text;
//			���.ShowDialog();
//			tex�͂���R�[�h.Text = ���.s�͂���b�c;
			if (g�͐�o�� == null)	 g�͐�o�� = new ���͂���o�^��();
// MOD 2008.03.19 ���s�j���� ���͂���̏㏑�@�\�̒ǉ� START
//			g�͐�o��.Left = this.Left + panel2.Left + 1;
//			g�͐�o��.Top = this.Top + panel2.Top + 10;
			g�͐�o��.Left = this.Left + (this.Width  - g�͐�o��.Width)  / 2;
			g�͐�o��.Top  = this.Top  + (this.Height - g�͐�o��.Height) / 2;
// MOD 2008.03.19 ���s�j���� ���͂���̏㏑�@�\�̒ǉ� END

			g�͐�o��.sTdata[2]  = tex�͂���d�b�ԍ��P.Text;
			g�͐�o��.sTdata[3]  = tex�͂���d�b�ԍ��Q.Text;
			g�͐�o��.sTdata[4]  = tex�͂���d�b�ԍ��R.Text;
			g�͐�o��.sTdata[5]  = tex�͂���X�֔ԍ��P.Text;
			g�͐�o��.sTdata[6]  = tex�͂���X�֔ԍ��Q.Text;
			g�͐�o��.sTdata[7]  = tex�͂���Z���P.Text;
			g�͐�o��.sTdata[8]  = tex�͂���Z���Q.Text;
			g�͐�o��.sTdata[9]  = tex�͂���Z���R.Text;
			g�͐�o��.sTdata[10] = tex�͂��於�O�P.Text;
			g�͐�o��.sTdata[11] = tex�͂��於�O�Q.Text;
// MOD 2008.03.19 ���s�j���� ���͂���̏㏑�@�\�̒ǉ� START
			g�͐�o��.sTdata[19] = sRet[3];		//�Z���b�c
// MOD 2008.03.19 ���s�j���� ���͂���̏㏑�@�\�̒ǉ� END

			g�͐�o��.s�͂���b�c = tex�͂���R�[�h.Text;
			g�͐�o��.ShowDialog();
			tex�͂���R�[�h.Text = g�͐�o��.s�͂���b�c;

			tex�˗���R�[�h.Focus();
// MOD 2009.09.04 ���s�j���� Vista�Ή�(TAB�Ή�����) START
//// ADD 2006.10.17 ���s�j���؁@ �G���g���I�v�V�����̍��ڒǉ� START
//			if(tex�˗���R�[�h.TabStop == false)
//				System.Windows.Forms.SendKeys.SendWait("{TAB}");
//// ADD 2006.10.17 ���s�j���؁@ �G���g���I�v�V�����̍��ڒǉ� END
			if(tex�˗���R�[�h.TabStop == false){
// MOD 2011.08.02 ���s�j���� �e���ڂ̓��͕s�Ή��i�s������j START
//				this.SelectNextControl(this.ActiveControl, true, true, true, true);
				this.SelectNextControl(tex�˗���R�[�h, true, true, true, true);
// MOD 2011.08.02 ���s�j���� �e���ڂ̓��͕s�Ή��i�s������j END
			}
// MOD 2009.09.04 ���s�j���� Vista�Ή�(TAB�Ή�����) END
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
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
// MOD 2016.06.10 BEVAS�j���{ �L���̌Œ���e���o�דo�^���ȊO�ł��ۑ� START
			//����{�^���������ɂ��A�L���̌Œ���e��ۑ�����
			�L���i���Œ菑��();
// MOD 2016.06.10 BEVAS�j���{ �L���̌Œ���e���o�דo�^���ȊO�ł��ۑ� END
			this.Close();
		}

		private void btn�˗���o�^_Click(object sender, System.EventArgs e)
		{
// ADD 2007.11.05 ���s�j���� �˗�����̍ŐV�� START
			s�O�񌟍��˗���b�c = "";
// ADD 2007.11.05 ���s�j���� �˗�����̍ŐV�� END
// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			���˗���o�^ ��� = new ���˗���o�^();
//			���.Left = this.Left;
//			���.Top = this.Top;
//			���.ShowDialog();
//			tex�˗���R�[�h.Focus();
			if (g�˗��o�^ == null)	 g�˗��o�^ = new ���˗���o�^();
			g�˗��o�^.Left  = this.Left;
			g�˗��o�^.Top   = this.Top;
			g�˗��o�^.ShowInTaskbar = false;
			g�˗��o�^.ShowDialog(this);
			tex�˗���R�[�h.Focus();
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
// ADD 2007.11.05 ���s�j���� �˗�����̍ŐV�� START
			tex�˗���R�[�h.Text = tex�˗���R�[�h.Text.Trim();
			if(tex�˗���R�[�h.Text.Length > 0)
			{
				if(!���p�`�F�b�N(tex�˗���R�[�h,"�˗���R�[�h")) return;

				s�˗���b�c = tex�˗���R�[�h.Text;
				�˗��區�ڃN���A();
				tex�˗���R�[�h.Text = s�˗���b�c;
				�˗��匟��(true);
			}
// ADD 2007.11.05 ���s�j���� �˗�����̍ŐV�� END
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
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� START
//				if((s�˗���b�c != s�O�񌟍��˗���b�c)
//					|| (s�˗���b�c == s�O�񌟍��˗���b�c
//					&& tex�˗���d�b�ԍ��P.Text.Trim() == ""))
//				{
//					�˗��區�ڃN���A();
//					tex�˗���R�[�h.Text = s�˗���b�c;
//					�˗��匟��(true);
//				}
//				else
//				{
//					tex�˗���R�[�h.Text = s�˗���b�c;
//					tex�˗���R�[�h.Focus();
//				}
				�˗��區�ڃN���A();
				tex�˗���R�[�h.Text = s�˗���b�c;
				�˗��匟��(true);
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

		private void btn�������_Click(object sender, System.EventArgs e)
		{
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

			i�����e�f = 1;
			i����e�f = 0;

			if(i�X�V�e�f == 0)
				btn�X�V_Click(sender,e);
			else
				i����e�f = 1;

			i�X�V�e�f = 0;

			if(i����e�f == 0)
			{
				Cursor = System.Windows.Forms.Cursors.Default;
				return;
			}

// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j START
//			ds�����.Clear();
			�����f�[�^�N���A();
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j END

			try
			{
				string[] sData = new string[2];
				sData[0] = s�o�^��;
				sData[1] = s�W���[�i���m�n;

				��������w��(sData);
			}
			catch (Exception ex)
			{
				tex���b�Z�[�W.Text = ex.Message;
				�r�[�v��();
				return;
			}
			Cursor = System.Windows.Forms.Cursors.Default;

// MOD 2006.12.12 ���s�j�����J �X���ƕ���X�����قȂ�ꍇ�́A������Ȃ� START
//			����󒠕[���();
			
//			tex���b�Z�[�W.Text = "";
//			if(i�����e�f == 1)
//				Close();
			if(gb���)
			{
				����󒠕[���();
			
				tex���b�Z�[�W.Text = "";
				if(i�����e�f == 1)
					Close();
			}
			else
			{
				tex���b�Z�[�W.Text = "";
// MOD 2007.2.19 FJCS�j�K�c ���b�Z�[�W�ύX START
//				MessageBox.Show("���X���Ⴂ�܂��B����ł��܂���B","������"
				MessageBox.Show("�W�דX���Ⴂ�܂��B����ł��܂���B","������"
// MOD 2007.2.19 FJCS�j�K�c ���b�Z�[�W�ύX END
					,MessageBoxButtons.OK);
				if(i�����e�f == 1)
					Close();
			}
// MOD 2006.12.12 ���s�j�����J �X���ƕ���X�����قȂ�ꍇ�́A������Ȃ� END

		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lab����.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

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
// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX END
		}

// ADD 2007.11.21 KCL) �X�{ �A���R�[�h���̓`�F�b�N�ǉ� START
		private bool CheckYusoCodeOya() {

			bool retValue = false;

			if (tex�A���R�[�h�e.Text.Length > 0) {

				if (! ���p�`�F�b�N(tex�A���R�[�h�e,"�A�����i�e�R�[�h")) return false;

				// �J�[�\���������v�ɂ���
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				tex���b�Z�[�W.Text = "�������D�D�D";

				// �e�A�������擾
				string [] sList = {""};
				try {
					if (sv_kiji == null) sv_kiji = new is2kiji.Service1();
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
				} catch (System.Net.WebException) {
					sList[0] = gs�ʐM�G���[;
				} catch (Exception ex) {
					sList[0] = "�ʐM�G���[�F" + ex.Message;
				}

				// �J�[�\�����f�t�H���g�ɖ߂�
				Cursor = System.Windows.Forms.Cursors.Default;
				tex���b�Z�[�W.Text = "";

				// �G���[��
				if (sList[0].Length != 2) {
					�r�[�v��();
					tex���b�Z�[�W.Text = sList[0];
					return false;
				}

				// ���݂��Ȃ���
				if (sList[3] == "I") {
					tex���b�Z�[�W.Text = "";
					MessageBox.Show("���͂��ꂽ�A�����i�e�R�[�h�̓}�X�^�ɑ��݂��܂���B","�A������",MessageBoxButtons.OK);
					return false;
				}

				// �󔒏���
				if (sList[1] != null) {
					tex�A�����e.Text = sList[1];
					s�A�����i�e�R�[�h = tex�A���R�[�h�e.Text;
				}

				�A�����i���d�ʐ���();

				retValue = true;
			}

			return retValue;
		}
// ADD 2007.11.21 KCL) �X�{ �A���R�[�h���̓`�F�b�N�ǉ� END
// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX START
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
// MOD 2007.11.21 KCL) �X�{ �A���R�[�h���̓`�F�b�N�ǉ� START
//						MessageBox.Show("�A�����i�e�R�[�h�����͂���Ă��܂���B","���̓`�F�b�N",MessageBoxButtons.OK);
//						return;
						// �A���R�[�h�i�e�j�̊m�F
						if (! this.CheckYusoCodeOya()) 
						{
							MessageBox.Show("�A�����i�e�R�[�h�����͂���Ă��܂���B","���̓`�F�b�N",MessageBoxButtons.OK);
							tex�A���R�[�h�e.Focus();
							return;
						}
// MOD 2007.11.21 KCL) �X�{ �A���R�[�h���̓`�F�b�N�ǉ� END
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
// MOD 2010.05.25 ���s�j���؁@���Ԏw��̕ύX START
//							string[] items = {"�P�Q","�P�R","�P�S","�P�T","�P�U","�P�V","�P�W","�P�X","�Q�O","�Q�P"};
							string[] items = {"�P�Q","�P�R","�P�S","�P�T","�P�U","�P�V","�P�W","�P�X","�Q�O"};
// MOD 2010.05.25 ���s�j���؁@���Ԏw��̕ύX END
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
// MOD 2010.05.25 ���s�j���؁@���Ԏw��̕ύX START
//							string[] items = {"�P�O","�P�P","�P�Q","�P�R","�P�S","�P�T","�P�U","�P�V","�P�W","�P�X"};
							string[] items = {"�P�O","�P�P","�P�Q","�P�R","�P�S","�P�T","�P�U","�P�V","�P�W"};
// MOD 2010.05.25 ���s�j���؁@���Ԏw��̕ύX END
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
// ADD 2007.11.21 KCL) �X�{ �A���R�[�h���̓`�F�b�N�ǉ� START
				} 
				else 
				{
					// �A���R�[�h�i�e�j�̊m�F
					this.CheckYusoCodeOya();
// ADD 2007.11.21 KCL) �X�{ �A���R�[�h���̓`�F�b�N�ǉ� END
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
// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX END

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
// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� START
			i���^�m�n = 0;
// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� END
			tex���q�l�Ǘ��ԍ�.Text = "";
			if(cBox�w����Œ�.Checked == false)
			{
				cBox�w���.Checked   = false;
				label3.Visible = true;
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
//				label�K��.Visible = false;
				cmb�w����敪.Visible = false;
				cmb�w����敪.SelectedIndex = 0;
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� END
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@END
				cBox�w����Œ�.Visible = false;
// MOD 2006.06.27 ���s�j�R�{�@�o�ד��𗂓��ɕύX�@START
// DEL 2009.04.02 ���s�j���� �ғ����Ή� START
//				dt�w���.Value       = gdt�o�ד�.AddDays(1);				
// DEL 2009.04.02 ���s�j���� �ғ����Ή� END
//				dt�w���.Value       = gdt�o�ד�.AddDays(2);				
// MOD 2006.06.27 ���s�j�R�{�@�o�ד��𗂓��ɕύX�@END
			}
			tex�A���R�[�h�e.Text   = "";
			tex�A���R�[�h�q.Text   = "";
			tex�A�����e.Text       = "";
			tex�A�����q.Text       = "";
// MOD 2009.09.01 �p�\�j���� �L���E�i���^���̌Œ�@�\�̒ǉ� START
//			tex�L�����P.Text       = "";
//			tex�L�����Q.Text       = "";
//			tex�L�����R.Text       = "";
//			nUD��.Value          = 0;
//			nUD��.Text           = "0";
			tex�L���R�[�h.Text		  = "";		//�N���A�Y��̂��ߒǉ�
// MOD 2009.10.05 �p�\�j����@�L���E�i���^���̍s�ʌŒ�@�\�̒ǉ� START
			//if(cBox�L���i���Œ�.Checked == false)
			//{
			//	tex�L�����P.Text       = "";
			//	tex�L�����Q.Text       = "";
			//	tex�L�����R.Text       = "";
			//}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
//			if(cBox�L���i���Œ�P.Checked == false)
//			{
//				tex�L�����P.Text       = "";
//			}
//			if(cBox�L���i���Œ�Q.Checked == false)
//			{
//				tex�L�����Q.Text       = "";
//			}
//			if(cBox�L���i���Œ�R.Checked == false)
//			{
//				tex�L�����R.Text       = "";
//			}
			if(cBox�L���i���Œ�P.Checked == false){
				tex�L�����P.Text   = "";
			}
			if(cBox�L���i���Œ�Q.Checked == false){
				tex�L�����Q.Text   = "";
			}
			if(cBox�L���i���Œ�R.Checked == false){
				tex�L�����R.Text   = "";
			}
			if(cBox�L���i���Œ�S.Checked == false){
				tex�L�����S.Text   = "";
			}
			if(cBox�L���i���Œ�T.Checked == false){
				tex�L�����T.Text   = "";
			}
			if(cBox�L���i���Œ�U.Checked == false){
				tex�L�����U.Text   = "";
			}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
// MOD 2009.10.05 �p�\�j����@�L���E�i���^���̍s�ʌŒ�@�\�̒ǉ� END
			if(cBox���Œ�.Checked == false)
			{
				nUD��.Value          = 0;
				nUD��.Text           = "0";
			}
// MOD 2009.09.01 �p�\�j���� �L���E�i���^���̌Œ�@�\�̒ǉ� END
// MOD 2005.05.12 ���s�j�����J �����d�ʂO START
//			nUD�d��.Value          = d�d��;
			nUD�d��.Value          = 0;
			nUD�d��.Text           = "0";
// MOD 2005.05.12 ���s�j�����J �����d�ʂO END
			nUD�ی����z.Value      = 0;
			nUD�ی����z.Text       = "0";
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX START
			nUD�ی����z.Minimum    =  0;
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) START
//			nUD�ی����z.Maximum    = 30;
			nUD�ی����z.Maximum    = gl�ی����z���;
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) END
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX END
// ADD 2005.05.26 ���s�j�ɉ� �A�����i�d�l�ύX START
			s�A�����i�e�R�[�h      = "";
			s�A�����i�q�R�[�h      = "";
		    s�o�^�A�����i�R�[�h    = "";
		    s�o�^�����ԍ�        = "";
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
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
					if(gs�I�v�V����[18].Equals("1")){
						tex�͂���Z���P.Text     = sList[7].TrimEnd();
						tex�͂���Z���Q.Text     = sList[8].TrimEnd();
						tex�͂���Z���R.Text     = sList[9].TrimEnd();
						tex�͂��於�O�P.Text     = sList[10].TrimEnd();
						tex�͂��於�O�Q.Text     = sList[11].TrimEnd();
					}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
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
// MOD 2006.10.17 ���s�j���؁@ �G���g���I�v�V�����̍��ڒǉ� START
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
// MOD 2006.10.17 ���s�j���؁@ �G���g���I�v�V�����̍��ڒǉ� END
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

		private void �˗��匟��(bool bMsgYN)
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
					d�d��  =  0;
					tex���b�Z�[�W.Text = "";
					if(bMsgYN)
					{
						MessageBox.Show("���͂��ꂽ���˗���R�[�h�̓}�X�^�ɑ��݂��܂���B","���˗��匟��",MessageBoxButtons.OK);
					}
					else
					{
						tex�˗���R�[�h.Text = "";
					}
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
//					if(s�˗���b�c.Length > 0 && s�˗���b�c != s�O�񌟍��˗���b�c) �˗��匟��(true);
					if(s�˗���b�c.Length > 0){
						�˗��匟��(true);
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

		private void btn�X�V_Click(object sender, System.EventArgs e)
		{
			tex���b�Z�[�W.Text = "";

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
				tex�͂���Z���P.Text       = tex�͂���Z���P.Text.TrimEnd();
				tex�͂���Z���Q.Text       = tex�͂���Z���Q.Text.TrimEnd();
				tex�͂���Z���R.Text       = tex�͂���Z���R.Text.TrimEnd();
				tex�͂��於�O�P.Text       = tex�͂��於�O�P.Text.TrimEnd();
				tex�͂��於�O�Q.Text       = tex�͂��於�O�Q.Text.TrimEnd();
				tex�˗��啔��.Text         = tex�˗��啔��.Text.TrimEnd();
			}else{
				tex�͂���Z���P.Text       = tex�͂���Z���P.Text.Trim();
				tex�͂���Z���Q.Text       = tex�͂���Z���Q.Text.Trim();
				tex�͂���Z���R.Text       = tex�͂���Z���R.Text.Trim();
				tex�͂��於�O�P.Text       = tex�͂��於�O�P.Text.Trim();
				tex�͂��於�O�Q.Text       = tex�͂��於�O�Q.Text.Trim();
				tex�˗��啔��.Text         = tex�˗��啔��.Text.Trim();
			}
			tex�˗���R�[�h.Text       = tex�˗���R�[�h.Text.Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
			tex���q�l�Ǘ��ԍ�.Text     = tex���q�l�Ǘ��ԍ�.Text.Trim();
//			tex�A���R�[�h�e.Text         = tex�A���R�[�h�e.Text.Trim();
//			tex�L���R�[�h.Text         = tex�L���R�[�h.Text.Trim();
//			tex�A�����e.Text           = tex�A�����e.Text.Trim();
//			tex�A�����q.Text           = tex�A�����q.Text.Trim();
			tex�A�����e.Text           = tex�A�����e.Text.TrimEnd();
			tex�A�����q.Text           = tex�A�����q.Text.TrimEnd();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//			tex�L�����P.Text           = tex�L�����P.Text.Trim();
//			tex�L�����Q.Text           = tex�L�����Q.Text.Trim();
//			tex�L�����R.Text           = tex�L�����R.Text.Trim();
//			tex�˗��吿����.Text       = tex�˗��吿����.Text.Trim();
			if(gs�I�v�V����[18].Equals("1")){
				tex�L�����P.Text           = tex�L�����P.Text.TrimEnd();
				tex�L�����Q.Text           = tex�L�����Q.Text.TrimEnd();
				tex�L�����R.Text           = tex�L�����R.Text.TrimEnd();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
				tex�L�����S.Text           = tex�L�����S.Text.TrimEnd();
				tex�L�����T.Text           = tex�L�����T.Text.TrimEnd();
				tex�L�����U.Text           = tex�L�����U.Text.TrimEnd();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
				tex�˗��吿����.Text       = tex�˗��吿����.Text.TrimEnd();
			}else{
				tex�L�����P.Text           = tex�L�����P.Text.Trim();
				tex�L�����Q.Text           = tex�L�����Q.Text.Trim();
				tex�L�����R.Text           = tex�L�����R.Text.Trim();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
				tex�L�����S.Text           = tex�L�����S.Text.Trim();
				tex�L�����T.Text           = tex�L�����T.Text.Trim();
				tex�L�����U.Text           = tex�L�����U.Text.Trim();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
				tex�˗��吿����.Text       = tex�˗��吿����.Text.Trim();
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� START
			tex������R�[�h.Text       = tex������R�[�h.Text.Trim();
			tex�����敔�ۃR�[�h.Text   = tex�����敔�ۃR�[�h.Text.Trim();
// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� END

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
// ADD 2005.06.07 ���s�j�ɉ� �A�����i�d�l�ύX START
			//�W�d�w�o�A�X�d�w�o�A�P�O�d�w�o�A�����q��ւ̏ꍇ�͎w����K�{
			if((s�A�����i�e�R�[�h.Equals("200") || s�A�����i�e�R�[�h.Equals("300") || s�A�����i�e�R�[�h.Equals("400") || s�A�����i�e�R�[�h.Equals("500"))
				&& cBox�w���.Checked == false)
			{
// MOD 2005.06.13 ���s�j���� ���b�Z�[�W�̕ύX START
//				MessageBox.Show("�z�B�w����͕K�{���ڂł�","���̓`�F�b�N",
				MessageBox.Show("���ݑI�����Ă���A�����i�ł́A�w����͕K�{���ڂł�","���̓`�F�b�N",
// MOD 2005.06.13 ���s�j���� ���b�Z�[�W�̕ύX END
					MessageBoxButtons.OK );
				dt�w���.Focus();
				return;
			}
			//�����o�^�ς݂̃f�[�^��
			if(s�o�^�����ԍ�.Length != 0)
			{
				//�p�[�Z������p�[�Z���ȊO�ɕύX�ł��Ȃ�
				if(s�o�^�A�����i�R�[�h.Equals("001") || s�o�^�A�����i�R�[�h.Equals("002"))
				{
					if(!s�A�����i�e�R�[�h.Equals("001") && !s�A�����i�e�R�[�h.Equals("002"))
					{
						MessageBox.Show("���s�ς݂̃f�[�^�̗A�����i�́A�p�[�Z������p�[�Z���ȊO�ɕύX�ł��܂���","���̓`�F�b�N",
							MessageBoxButtons.OK );
						tex�A���R�[�h�e.Focus();
						return;
					}
				}
				//�p�[�Z������p�[�Z���ȊO�ɕύX�ł��Ȃ�
				if(!s�o�^�A�����i�R�[�h.Equals("001") && !s�o�^�A�����i�R�[�h.Equals("002"))
				{
					if(s�A�����i�e�R�[�h.Equals("001") || s�A�����i�e�R�[�h.Equals("002"))
					{
						MessageBox.Show("���s�ς݂̃f�[�^�̗A�����i�́A�p�[�Z���ȊO����p�[�Z���ɕύX�ł��܂���","���̓`�F�b�N",
							MessageBoxButtons.OK );
						tex�A���R�[�h�e.Focus();
						return;
					}
				}
			}
// ADD 2005.06.07 ���s�j�ɉ� �A�����i�d�l�ύX END
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
			if(!���p�`�F�b�N(tex���q�l�Ǘ��ԍ�,"���q�l�Ǘ��ԍ�")) return;
//			if(!���p�`�F�b�N(tex�A���R�[�h�e,"�A���R�[�h")) return;
//			if(!���p�`�F�b�N(tex�L���R�[�h,"�L���R�[�h")) return;
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
// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� START
			if(s�����e�f == "I" && i���^�m�n == 0){
				�L���i���Œ菑��();
			}
// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� END
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
			�˗��匟��(true);
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
			// �X�V���[�h or ���`�Q�ƃ��[�h�ŊJ���ꂽ�ꍇ
			if(s�����e�f == "U" || i���^�m�n > 0){
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
//			if(nUD�d��.Text.Length == 0)
// MOD 2005.09.02 ���s�j�����J Value��Text�� START
//			if(nUD�d��.Text.Length == 0 || nUD�d��.Value == 0)
// MOD 2009.03.02 ���s�j���� �d�ʂO���͎��̕s����� START
//			if(nUD�d��.Text.Length == 0 || nUD�d��.Text == "0")
// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� START
//			nUD�d��.Text = nUD�d��.Text.Trim();
// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� END
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
						if(s�����e�f == "U" || i���^�m�n > 0){
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
//			if(!�͈̓`�F�b�N(nUD�d��,"�d��")) return;
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

			// �o�ד��`�F�b�N
			����o�ד����X�V();
			if (dt�o�ד�.Value < gdt�o�ד�)
			{
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N START
//				string s�o�ד� = gs�o�ד�.Substring(0,4) + "�N";
				string s�o�ד� = "";
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N END
				if(gs�o�ד�[4] == '0')
					s�o�ד� = s�o�ד� + " " + gs�o�ד�.Substring(5,1) + "��";
				else
					s�o�ד� = s�o�ד� + gs�o�ד�.Substring(4,2) + "��";
				if(gs�o�ד�[6] == '0')
					s�o�ד� = s�o�ד� + " " + gs�o�ד�.Substring(7,1) + "��";
				else
					s�o�ד� = s�o�ד� + gs�o�ד�.Substring(6,2) + "��";

				MessageBox.Show("�o�ד���" + s�o�ד� + "�ȍ~����͂��Ă�������",
					"���̓`�F�b�N",
					MessageBoxButtons.OK );
// DEL 2005.07.08 ���s�j���� �d�����Ă���׍폜 START
//				MessageBox.Show("�o�ד���"	+ s�o�ד�.Substring(0,4) + "�N"
//											+ s�o�ד�.Substring(4,2) + "��"
//											+ s�o�ד�.Substring(6,2) + "��"
//											+ "�ȍ~�œ��͂��Ă�������","���̓`�F�b�N",
//					MessageBoxButtons.OK );
// DEL 2005.07.08 ���s�j���� �d�����Ă���׍폜 END
				dt�o�ד�.Focus();
				return;
			}

			// �z�B�w����`�F�b�N
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N START
//			if (cBox�w���.Checked == true && dt�w���.Value < dt�o�ד�.Value)
//			{
//				MessageBox.Show("�z�B�w��������������͂���Ă��܂���","���̓`�F�b�N",
//									MessageBoxButtons.OK );
//				dt�w���.Focus();
//				return;
//			}
			if (cBox�w���.Checked)
			{
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
				b�w����`�F�b�N�l�r�f�L = true;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
				bool bRet = �o�ד��`�F�b�N();
				if(bRet == false) return;
			}
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N END

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

// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� START
			if(tex�͂���Z���P.Text.Equals("�����x�X�~�߁���"))
			{
				/** �x�X�~�߂̏o�ׂ�����͂ł��悤�Ƃ������̍l�� */

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

// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� START
			if(gs����X���b�c.Equals("044"))
			{
				//���O�C�����[�U�[���Г��`����������ꍇ�A�b�l�O�T�e�̑��݃`�F�b�N�����{
				string[] saRet = new string[2];
				Cursor = System.Windows.Forms.Cursors.AppStarting;

				saRet = �b�l�O�T������X�e�`�F�b�N();
				int iRet = int.Parse(saRet[0]);
				string sChkRet = saRet[1];

				Cursor = System.Windows.Forms.Cursors.Default;
				if(iRet == 1)
				{
					//�ُ�I����
					�r�[�v��();
					string s���b�Z�[�W = "�����p�̉���Ɉ��X�o�^���Ȃ��ׁA�o�דo�^�ł��܂���B\n" +
										"���R�ʉ^�̉c�Ɩ{���ւ��₢���킹�������B\n" +
										"�@�@�y�`�F�b�N�Ώۉ���z " + gs����b�c;
					MessageBox.Show(this, s���b�Z�[�W, "���X�o�^�`�F�b�N", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					if(sChkRet.Equals("�Y���f�[�^������܂���"))
					{
						tex���b�Z�[�W.Text = "�y�Г��`������X�`�F�b�N�G���[�z�����p�̉���Ɉ��X�o�^������܂���ł���";
					}
					else
					{
						tex���b�Z�[�W.Text = "�y�Г��`������X�`�F�b�N�G���[�z" + sChkRet;
					}
					tex�͂���R�[�h.Focus();
					return;
				}
			}
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� END

// DEL 2009.03.02 ���s�j���� �d�ʂO���͎��̕s����� START
//// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� START
//			//�˗�����̌���
//			s�˗���b�c = tex�˗���R�[�h.Text;
//			�˗��區�ڃN���A�Q();
//			tex�˗���R�[�h.Text = s�˗���b�c;
//			�˗��匟��(true);
//			//�˗���������͐����悪���݂��Ȃ��ꍇ
//			if(tex�˗��吿����.Text.Trim().Length == 0){
//				return;
//			}
//// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� END
// DEL 2009.03.02 ���s�j���� �d�ʂO���͎��̕s����� END

			String[] sIUList;
// MOD 2005.06.08 ���s�j�ɉ� �w����敪�ǉ� START
// MOD 2005.05.30 ���s�j�ɉ� �A�����i�R�[�h�ǉ� START
// MOD 2005.05.17 ���s�j�����J �ː��ǉ� START
//			string[] s�o�ׂc = new string[38];
//			string[] s�o�ׂc = new string[39];
//			string[] s�o�ׂc = new string[41];
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
//			string[] s�o�ׂc = new string[42];
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
//			string[] s�o�ׂc = new string[43];
			string[] s�o�ׂc = new string[46];
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
			s�o�ׂc[42] = gs�d�ʓ��͐���;
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
// MOD 2005.05.17 ���s�j�����J �ː��ǉ� END
// MOD 2005.05.17 ���s�j�ɉ� �A�����i�R�[�h�ǉ� END
// MOD 2005.06.08 ���s�j�ɉ� �w����敪�ǉ� END
			s�o�ׂc[0]  = gs����b�c;
			s�o�ׂc[1]  = gs����b�c;
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX START
//			s�o�ׂc[2]  = dt�o�ד�.Value.ToShortDateString().Replace("/","");
			s�o�ׂc[2]  = YYYYMMDD�ϊ�(dt�o�ד�.Value);
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX END
			s�o�ׂc[3]  = tex���q�l�Ǘ��ԍ�.Text.Trim();
			s�o�ׂc[4]  = tex�͂���R�[�h.Text.Trim();
			s�o�ׂc[5]  = tex�͂���d�b�ԍ��P.Text.Trim();
			s�o�ׂc[6]  = tex�͂���d�b�ԍ��Q.Text.Trim();
			s�o�ׂc[7]  = tex�͂���d�b�ԍ��R.Text.Trim();
			s�o�ׂc[8]  = tex�͂���Z���P.Text.Trim();
			s�o�ׂc[9]  = tex�͂���Z���Q.Text.Trim();
			s�o�ׂc[10] = tex�͂���Z���R.Text.Trim();
			s�o�ׂc[11] = tex�͂��於�O�P.Text.Trim();
			s�o�ׂc[12] = tex�͂��於�O�Q.Text.Trim();
			s�o�ׂc[13] = tex�͂���X�֔ԍ��P.Text.Trim();
			s�o�ׂc[14] = tex�͂���X�֔ԍ��Q.Text.Trim();
			s�o�ׂc[15] = tex�˗���R�[�h.Text.Trim();
// MOD 2009.03.02 ���s�j���� �d�ʂO���͎��̕s����� START
//// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� START
//			s�o�ׂc[17] = tex������R�[�h.Text.Trim();
//			s�o�ׂc[18] = tex�����敔�ۃR�[�h.Text.Trim();
//// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� END
//
//			// ������̎擾
//			if(tex�˗��吿����.Text.Trim() == "")
//			{
//				s�o�ׂc[16] = " ";
//// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� START
////				s�o�ׂc[17] = " ";
////				s�o�ׂc[18] = " ";
//// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� END
//			}
//			else
//			{
//				int iCnt;
//				if(gsa������b�c != null)
//				{
//					for(iCnt = 0 ; iCnt < gsa������b�c.Length; iCnt++ )
//					{
//						if(gsa�����敔�ۖ�[iCnt] == null)
//						{
//							s�o�ׂc[16] = " ";
//// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� START
////							s�o�ׂc[17] = " ";
////							s�o�ׂc[18] = " ";
//// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� END
//						}
//						else
//						{
//							if(tex�˗��吿����.Text.Trim() == gsa�����敔�ۖ�[iCnt])
//							{
//								s�o�ׂc[16] = gsa������b�c[iCnt];
//// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� START
////								s�o�ׂc[17] = gsa�����敔�ۂb�c[iCnt];
////								s�o�ׂc[18] = gsa�����敔�ۖ�[iCnt];
//// MOD 2008.10.28 ���s�j���� ������R�[�h�\���@�\�̒ǉ� END
//								break;
//							}
//						}
//					}
//				}
//			}
			s�o�ׂc[16] = tex������R�[�h.Text.Trim();
			s�o�ׂc[17] = tex�����敔�ۃR�[�h.Text.Trim();
			s�o�ׂc[18] = tex�˗��吿����.Text.Trim();
// MOD 2009.03.02 ���s�j���� �d�ʂO���͎��̕s����� END
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
			if(gs�I�v�V����[18].Equals("1")){
				s�o�ׂc[8]  = tex�͂���Z���P.Text.TrimEnd();
				s�o�ׂc[9]  = tex�͂���Z���Q.Text.TrimEnd();
				s�o�ׂc[10] = tex�͂���Z���R.Text.TrimEnd();
				s�o�ׂc[11] = tex�͂��於�O�P.Text.TrimEnd();
				s�o�ׂc[12] = tex�͂��於�O�Q.Text.TrimEnd();
				s�o�ׂc[18] = tex�˗��吿����.Text.TrimEnd();
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END

			s�o�ׂc[19] = nUD��.Value.ToString();
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
			if(gs�d�ʓ��͐��� == "1"){
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
// MOD 2005.05.17 ���s�j�����J �ː����d�ʂ� START
//			s�o�ׂc[20] = nUD�d��.Value.ToString();
				if(i�ː��e�f == 0)
				{
					s�o�ׂc[20] = "0";
					s�o�ׂc[38] = nUD�d��.Value.ToString();
				}
				else
				{
					s�o�ׂc[20] = nUD�d��.Value.ToString();
					s�o�ׂc[38] = "0";
				}
// MOD 2005.05.17 ���s�j�����J �ː����d�ʂ� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
			}else{
				s�o�ׂc[20] = "0";
				s�o�ׂc[38] = "0";
			}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END

// MOD 2005.06.08 ���s�j�ɉ� �w����敪�ǉ� START
			if(cBox�w���.Checked == true)
			{
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX START
//				s�o�ׂc[21] = dt�w���.Value.ToShortDateString().Replace("/","");
				s�o�ׂc[21] = YYYYMMDD�ϊ�(dt�w���.Value);
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX END
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
//				s�o�ׂc[41] = "0";
				s�o�ׂc[41] = cmb�w����敪.SelectedIndex.ToString();
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� END
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@END
			}
			else
			{
				s�o�ׂc[21] = "0";
				s�o�ׂc[41] = "0";
			}
// MOD 2005.06.08 ���s�j�ɉ� �w����敪�ǉ� END

// ADD 2005.05.30 ���s�j�ɉ� �A�����i�R�[�h�ǉ� START
			s�o�ׂc[39] = s�A�����i�e�R�[�h.Trim();
			s�o�ׂc[40] = s�A�����i�q�R�[�h.Trim();
// ADD 2005.05.30 ���s�j�ɉ� �A�����i�R�[�h�ǉ� END
			s�o�ׂc[22] = tex�A�����e.Text.TrimEnd();
			s�o�ׂc[23] = tex�A�����q.Text.TrimEnd();
			s�o�ׂc[24] = tex�L�����P.Text.Trim();
			s�o�ׂc[25] = tex�L�����Q.Text.Trim();
			s�o�ׂc[26] = tex�L�����R.Text.Trim();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
			s�o�ׂc[43] = tex�L�����S.Text.Trim();
			s�o�ׂc[44] = tex�L�����T.Text.Trim();
			s�o�ׂc[45] = tex�L�����U.Text.Trim();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
			if(gs�I�v�V����[18].Equals("1")){
				s�o�ׂc[24] = tex�L�����P.Text.TrimEnd();
				s�o�ׂc[25] = tex�L�����Q.Text.TrimEnd();
				s�o�ׂc[26] = tex�L�����R.Text.TrimEnd();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
				s�o�ׂc[43] = tex�L�����S.Text.TrimEnd();
				s�o�ׂc[44] = tex�L�����T.Text.TrimEnd();
				s�o�ׂc[45] = tex�L�����U.Text.TrimEnd();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
			s�o�ׂc[27] = "1";		//�����敪
			s�o�ׂc[28] = nUD�ی����z.Value.ToString();
			s�o�ׂc[29] = "0";					//����󔭍s�ςe�f
			s�o�ׂc[30] = "0";					//�o�׍ςe�f
			s�o�ׂc[31] = "0";					//�ꊇ�o�ׂe�f
			s�o�ׂc[32] = "�o�דo�^";
			s�o�ׂc[33] = gs���p�҂b�c;
			s�o�ׂc[34] = s�W���[�i���m�n;
			s�o�ׂc[35] = s�o�^��;
			s�o�ׂc[36] = sUpday;
			// �ב��l������
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//			s�o�ׂc[37] = tex�˗��啔��.Text;
			if(gs�I�v�V����[18].Equals("1")){
				s�o�ׂc[37] = tex�˗��啔��.Text.TrimEnd();
			}else{
				s�o�ׂc[37] = tex�˗��啔��.Text.Trim();
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END

			for(int iCnt = 0 ; iCnt < s�o�ׂc.Length; iCnt++ )
			{
				if( s�o�ׂc[iCnt] == null 
					|| s�o�ׂc[iCnt].Length == 0 ) s�o�ׂc[iCnt] = " ";
			}

			DialogResult result;
			if(s�����e�f == "I")
			{
//				result = MessageBox.Show("�V�K�o�^���܂����H","�o�^",MessageBoxButtons.YesNo);
//				if(result == DialogResult.Yes)
//				{
					// �J�[�\���������v�ɂ���
					Cursor = System.Windows.Forms.Cursors.AppStarting;
					sIUList = new string[]{""};
					try
					{
						tex���b�Z�[�W.Text = "�o�^���D�D�D";
						
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� START
						if (gs����b�c.Substring(0,1) != "J")
						{
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END

							if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
							sIUList = sv_syukka.Ins_syukka(gsa���[�U,s�o�ׂc);
							
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� START
						}
						else
						{
							if(sv_oji == null) sv_oji = new is2oji.Service1();
							sIUList = sv_oji.Ins_syukka(gsa���[�U,s�o�ׂc);
						}
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END

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

					//�o�ד��G���[
					string s�o�הN;
					string s�o�׌�;
					string s�o�ד�;
					if(sIUList[0] == "1")
					{
						s�o�הN = sIUList[1].Substring(0,4);
						s�o�׌� = sIUList[1].Substring(4,2);
						if(s�o�׌�.Substring(0,1) == "0") s�o�׌� = " " + s�o�׌�.Substring(1,1);
						s�o�ד� = sIUList[1].Substring(6,2);
						if(s�o�ד�.Substring(0,1) == "0") s�o�ד� = " " + s�o�ד�.Substring(1,1);
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N START
//						s�o�ד� = s�o�הN + "�N" + s�o�׌� + "��" + s�o�ד� + "��";
						s�o�ד� = s�o�׌� + "��" + s�o�ד� + "��";
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N END
						tex���b�Z�[�W.Text = "�o�ד��́A" + s�o�ד� + "�ȍ~����͂��Ă��������B";
						dt�o�ד�.Focus();
						return;
					}

					if(sIUList[0].Length == 4)
					{
						i�����e�f = 2;
						i����e�f = 1;
						s�o�^�� = sIUList[1];
						s�W���[�i���m�n = sIUList[2];
						btn���_Click(sender, e);
					}
					else
					{
						tex���b�Z�[�W.Text = sIUList[0];
						�r�[�v��();
						// �͂���R�[�h�Ƀt�H�[�J�X
						tex�͂���R�[�h.Focus();
					}
//				}

			}
			else
			{
				result = MessageBox.Show("���ɑ��݂���f�[�^�ɏ㏑�����܂����H","�X�V",MessageBoxButtons.YesNo);
				if(result == DialogResult.Yes)
				{
					// �J�[�\���������v�ɂ���
					Cursor = System.Windows.Forms.Cursors.AppStarting;
					sIUList = new string[]{""};
					try
					{
// MOD 2011.01.24 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������i���˗���A�o�ד��jSTART
						string[] sList = {""};
						tex���b�Z�[�W.Text = "�������D�D�D";
						tex���b�Z�[�W.Refresh();
						if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
						sList = sv_syukka.Get_Ssyukka(gsa���[�U
							, gs����b�c, gs����b�c, s�o�^��, int.Parse(s�W���[�i���m�n));
						// �G���[��
						if(sList[0].Length != 4){
							Cursor = System.Windows.Forms.Cursors.Default;
							�r�[�v��();
							tex���b�Z�[�W.Text = sList[0];
							return;
						}
						string s�����ԍ� = sList[43];
//						string s���       = sList[49];
						string s�o�׍ςe�f = sList[50];
// MOD 2011.03.11 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������̋��� START
						string s����ςe�f = (sList.Length > 51) ? sList[51] : "";
//						string s���M�ςe�f = (sList.Length > 52) ? sList[52] : "";
// MOD 2011.03.11 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������̋��� END
// MOD 2015.07.13 TDI�j�j�V �o�[�R�[�h�ǎ��p��ʒǉ� START
						//���X���`�F�b�N
						bool b�O���[�o���`�F�b�N�P;
						//���W�׃`�F�b�N
						bool b�O���[�o���`�F�b�N�Q;

						b�O���[�o���`�F�b�N�P = �O���[�o���`�F�b�N�P();
						if (s�����ԍ�.Trim() != "")
						{
							b�O���[�o���`�F�b�N�Q = �O���[�o���`�F�b�N�Q(s�����ԍ�.Substring(4,11));
						}
						else
						{
							//�󔒎��͏C����������
							b�O���[�o���`�F�b�N�Q = true;
						}
// MOD 2015.07.13 TDI�j�j�V �o�[�R�[�h�ǎ��p��ʒǉ� END
						// �o�׍ςe�f�������Ă���ꍇ�́A
						// �o�ד�����т��˗���R�[�h�̏C���������Ȃ�
						//   ��������
						// �o�ד��������ȑO�ŁA����ς̃f�[�^�́A
						// �o�ד�����т��˗���R�[�h�̏C���������Ȃ�
// MOD 2011.03.11 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������̋��� START
//						if(s�����ԍ�.Length > 0 && s�o�׍ςe�f == "1"){
						if((s�����ԍ�.Length > 0 && s�o�׍ςe�f == "1")
						|| (sList[1].Replace("/","").CompareTo(gs�o�ד�) <= 0 && s����ςe�f == "1") ){
// MOD 2011.03.11 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������̋��� END
							// �o�ד�
// MOD 2015.07.13 TDI�j�j�V �o�[�R�[�h�ǎ��p��ʒǉ� START
//							if(s�o�ׂc[2].Trim() != sList[1].Replace("/","").Trim())
//							{
//								tex���b�Z�[�W.Text = "";
//								tex���b�Z�[�W.Refresh();
//								Cursor = System.Windows.Forms.Cursors.Default;
//								�r�[�v��();
//								MessageBox.Show("�o�ד����ύX����Ă��܂��B\n"
//									+ "����σf�[�^��ύX����ꍇ�́A���̃f�[�^���폜������A\n"
//									+ "�ēx�A�G���g���[���s���ĉ������B\n"
//									+ "\n"
//									+ "�i���폜����O�ɁA�o�׏Ɖ��ʂ��畡�ʋ@�\�𗘗p����ƊȒP��\n"
//									+ "�@�G���g���[���\�ł��B�j\n"
//									+ "\n"
//								, "�X�V"
//								, MessageBoxButtons.OK);
//								if(dt�o�ד�.Enabled) dt�o�ד�.Focus();
//								return;
//							}
							if(s�o�ׂc[2].Trim() != sList[1].Replace("/","").Trim())
							{
								if(!b�O���[�o���`�F�b�N�P || !b�O���[�o���`�F�b�N�Q)
								{
									tex���b�Z�[�W.Text = "";
									tex���b�Z�[�W.Refresh();
									Cursor = System.Windows.Forms.Cursors.Default;
									�r�[�v��();
									MessageBox.Show("�o�ד����ύX����Ă��܂��B\n"
										+ "����σf�[�^��ύX����ꍇ�́A���̃f�[�^���폜������A\n"
										+ "�ēx�A�G���g���[���s���ĉ������B\n"
										+ "\n"
										+ "�i���폜����O�ɁA�o�׏Ɖ��ʂ��畡�ʋ@�\�𗘗p����ƊȒP��\n"
										+ "�@�G���g���[���\�ł��B�j\n"
										+ "\n"
										, "�X�V"
										, MessageBoxButtons.OK);
									if(dt�o�ד�.Enabled) dt�o�ד�.Focus();
									return;
								}
								else
								{
									//�o�ד��ύX�̃��b�Z�[�W�͏o���Ȃ�
									tex���b�Z�[�W.Text = "";
									tex���b�Z�[�W.Refresh();
									MessageBox.Show("�o�דo�^���e���ύX����܂��B\n"
										+ "���s�ς̉׎D�͕K���j�����ĉ������A\n"
										, "�X�V"
										, MessageBoxButtons.OK);
								}
							}
// MOD 2015.07.13 TDI�j�j�V �o�[�R�[�h�ǎ��p��ʒǉ� END
							// ���˗���R�[�h
							if(s�o�ׂc[15].Trim() != sList[14].Trim())
							{
								tex���b�Z�[�W.Text = "";
								tex���b�Z�[�W.Refresh();
								Cursor = System.Windows.Forms.Cursors.Default;
								�r�[�v��();
								MessageBox.Show("���˗��傪�ύX����Ă��܂��B\n"
									+ "����σf�[�^��ύX����ꍇ�́A���̃f�[�^���폜������A\n"
									+ "�ēx�A�G���g���[���s���ĉ������B\n"
									+ "\n"
									+ "�i���폜����O�ɁA�o�׏Ɖ��ʂ��畡�ʋ@�\�𗘗p����ƊȒP��\n"
									+ "�@�G���g���[���\�ł��B�j\n"
									+ "\n"
								, "�X�V"
								, MessageBoxButtons.OK);
								if(tex�˗���R�[�h.Enabled) tex�˗���R�[�h.Focus();
								return;
							}
							// ������R�[�h�A�����敔�ۃR�[�h�A�����於
							if(s�o�ׂc[16].Trim() != sList[47].Trim()
							|| s�o�ׂc[17].Trim() != sList[48].Trim()
							|| s�o�ׂc[18].Trim() != sList[15].Trim()){
								tex���b�Z�[�W.Text = "";
								tex���b�Z�[�W.Refresh();
								Cursor = System.Windows.Forms.Cursors.Default;
								�r�[�v��();
								MessageBox.Show("���˗���̐����悪�ύX����Ă��܂��B\n"
									+ "����σf�[�^��ύX����ꍇ�́A���̃f�[�^���폜������A\n"
									+ "�ēx�A�G���g���[���s���ĉ������B\n"
									+ "\n"
									+ "�i���폜����O�ɁA�o�׏Ɖ��ʂ��畡�ʋ@�\�𗘗p����ƊȒP��\n"
									+ "�@�G���g���[���\�ł��B�j\n"
									+ "\n"
								, "�X�V"
								, MessageBoxButtons.OK);
								if(tex�˗���R�[�h.Enabled) tex�˗���R�[�h.Focus();
								return;
							}
						}
// MOD 2011.01.24 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������i���˗���A�o�ד��jEND
						tex���b�Z�[�W.Text = "�X�V���D�D�D";
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� START
						if (gs����b�c.Substring(0,1) != "J")
						{
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END
							if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
// MOD 2010.06.18 ���s�j���� �o�׃f�[�^�̎Q�ƁE�ǉ��E�X�V�E�폜���O�̒ǉ� START
//						sIUList = sv_syukka.Upd_syukka(gsa���[�U,s�o�ׂc);

							sIUList = sv_syukka.Upd_syukka2(gsa���[�U,s�o�ׂc,s�o�^�����ԍ�);

// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� START
						}
						else
						{
							if(sv_oji == null) sv_oji = new is2oji.Service1();
							sIUList = sv_oji.Upd_syukka2(gsa���[�U,s�o�ׂc,s�o�^�����ԍ�);
						}
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END

						
// MOD 2010.06.18 ���s�j���� �o�׃f�[�^�̎Q�ƁE�ǉ��E�X�V�E�폜���O�̒ǉ� END
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
						MessageBox.Show("���͂��ꂽ���˗���R�[�h�̓}�X�^�ɑ��݂��܂���","�X�V",MessageBoxButtons.OK);
						return;
					}

					//�o�ד��G���[
					string s�o�הN;
					string s�o�׌�;
					string s�o�ד�;
					if(sIUList[0] == "1")
					{
						s�o�הN = sIUList[1].Substring(0,4);
						s�o�׌� = sIUList[1].Substring(4,2);
						if(s�o�׌�.Substring(0,1) == "0") s�o�׌� = " " + s�o�׌�.Substring(1,1);
						s�o�ד� = sIUList[1].Substring(6,2);
						if(s�o�ד�.Substring(0,1) == "0") s�o�ד� = " " + s�o�ד�.Substring(1,1);
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N START
//						s�o�ד� = s�o�הN + "�N" + s�o�׌� + "��" + s�o�ד� + "��";
						s�o�ד� = s�o�׌� + "��" + s�o�ד� + "��";
// MOD 2009.03.05 ���s�j���� �o�ד�����єz�B�w����̐������`�F�b�N END
						tex���b�Z�[�W.Text = "�o�ד��́A" + s�o�ד� + "�ȍ~����͂��Ă��������B";
						dt�o�ד�.Focus();
						return;
					}

					if(sIUList[0].Length == 4)
					{
						tex���b�Z�[�W.Text = "";
						if(i�����e�f == 0)
							Close();
						else
							i����e�f = 1;
//						btn���_Click(sender, e);
						s�o�^�A�����i�R�[�h = s�A�����i�e�R�[�h;
					}
					else
					{
						tex���b�Z�[�W.Text = sIUList[0];
						�r�[�v��();
					}
					// �͂���R�[�h�Ƀt�H�[�J�X
					tex�͂���R�[�h.Focus();
				}
			}

		}

		private void �X�V�s����()
		{
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX START
//			dt�o�ד�.MaxDate = DateTime.Parse("2105/12/31");
//			dt�o�ד�.MinDate = DateTime.Parse("2005/01/01");
			dt�o�ד�.MaxDate = YYYYMMDD�ϊ�("2105/12/31");
			dt�o�ד�.MinDate = YYYYMMDD�ϊ�("2005/01/01");
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX END
// MOD 2009.04.22 ���s�j���� ���t�ϊ��̕ύX START
			dt�w���.MaxDate = YYYYMMDD�ϊ�("2105/12/31");
			dt�w���.MinDate = YYYYMMDD�ϊ�("2005/01/01");
// MOD 2009.04.22 ���s�j���� ���t�ϊ��̕ύX END
			panel1.Enabled = false;
			panel2.Enabled = false;
			panel3.Enabled = false;
			panel4.Enabled = false;
			panel5.Enabled = false;
			btn�X�V.Enabled = false;
			btn���.Enabled = false;
			btn�폜.Enabled = false;
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� START
			if(tex�͂���Z���P.Text.Trim().Equals("�����x�X�~�߁���"))
			{
				// �x�X�~�߂������ꍇ
				btn�x�X�~��.Visible = false;
				btn�x�X�~��.Enabled = false;
				btn�x�X�~�߉���.Visible = true;
				btn�x�X�~�߉���.Enabled = false;
			}
			else
			{
				// ����ȊO�̏ꍇ
				btn�x�X�~��.Visible = true;
				btn�x�X�~��.Enabled = false;
				btn�x�X�~�߉���.Visible = false;
				btn�x�X�~�߉���.Enabled = false;
			}
// MOD 2015.07.30 BEVAS) ���{ �x�X�~�ߋ@�\�Ή� END
			tex���b�Z�[�W�Q.Visible = true;
		}

		private void �X�V�\����()
		{
			panel1.Enabled = true;
			panel2.Enabled = true;
			panel3.Enabled = true;
			panel4.Enabled = true;
			panel5.Enabled = true;
			btn�X�V.Enabled = true;
			btn�������.Visible = true;
			btn���.Enabled = true;
			btn�폜.Enabled = true;
			tex���b�Z�[�W�Q.Visible = false;
// MOD 2011.01.24 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������i���˗���A�o�ד��jSTART
			dt�o�ד�       .Enabled = true;
			tex�˗���R�[�h.Enabled = true;
// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� START
			��ʐ���ݒ�Q(tex�˗���R�[�h, s��ʐ���_�˗���);
// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� END
			btn�˗��匟��  .Enabled = true;
// MOD 2011.01.24 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������i���˗���A�o�ד��jEND
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

			tex���b�Z�[�W.Text = "";

			// �ُ�I����
// MOD 2005.06.08 ���s�j�ɉ� �w����敪�ǉ� START
// MOD 2005.06.01 ���s�j�ɉ� �A���w���R�[�h�ǉ� START
// MOD 2005.05.17 ���s�j�����J �ː��ǉ� START
//			if(sList[0].Length != 4 || sList[39] == "I")
//			if(sList[0].Length != 4 || sList[41] == "I")
//			if(sList[0].Length != 4 || sList[44] == "I")
			if(sList[0].Length != 4 || sList[45] == "I")
// MOD 2005.05.17 ���s�j�����J �ː��ǉ� END
// MOD 2005.06.01 ���s�j�ɉ� �A���w���R�[�h�ǉ� END
// MOD 2005.06.08 ���s�j�ɉ� �w����敪�ǉ� END
			{
				tex���b�Z�[�W.Text = sList[0];
				�r�[�v��();
				tex�˗���R�[�h.Focus();
// MOD 2009.09.04 ���s�j���� Vista�Ή�(TAB�Ή�����) START
//// ADD 2006.10.17 ���s�j���؁@ �G���g���I�v�V�����̍��ڒǉ� START
//				if(tex�˗���R�[�h.TabStop == false)
//					System.Windows.Forms.SendKeys.SendWait("{TAB}");
//// ADD 2006.10.17 ���s�j���؁@ �G���g���I�v�V�����̍��ڒǉ� END
				if(tex�˗���R�[�h.TabStop == false){
// MOD 2011.08.02 ���s�j���� �e���ڂ̓��͕s�Ή��i�s������j START
//					this.SelectNextControl(this.ActiveControl, true, true, true, true);
					this.SelectNextControl(tex�˗���R�[�h, true, true, true, true);
// MOD 2011.08.02 ���s�j���� �e���ڂ̓��͕s�Ή��i�s������j END
				}
// MOD 2009.09.04 ���s�j���� Vista�Ή�(TAB�Ή�����) END
				return;
			}

// ADD 2009.04.02 ���s�j���� �ғ����Ή� START
			if(sList.Length > 46) s�o�^�o�f = sList[46];
// ADD 2009.04.02 ���s�j���� �ғ����Ή� END
// MOD 2011.01.24 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������i���˗���A�o�ד��jSTART
			string s�o�׍ςe�f = sList[50];
// MOD 2011.01.24 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������i���˗���A�o�ד��jEND
// MOD 2011.03.11 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������̋��� START
			string s����ςe�f = (sList.Length > 51) ? sList[51] : "";
//			string s���M�ςe�f = (sList.Length > 52) ? sList[52] : "";
// MOD 2011.03.11 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������̋��� END
// MOD 2015.07.13 TDI�j�j�V�@�o�[�R�[�h�ǎ��p��ʒǉ� START
			string s�����ԍ� = sList[43];
			bool b�O���[�o���`�F�b�N�P;
			bool b�O���[�o���`�F�b�N�Q;
			b�O���[�o���`�F�b�N�P = �O���[�o���`�F�b�N�P();
			if (s�����ԍ�.Trim() != "")
			{
				b�O���[�o���`�F�b�N�Q = �O���[�o���`�F�b�N�Q(s�����ԍ�.Substring(4,11));
			}
			else
			{
				b�O���[�o���`�F�b�N�Q = true;
			}
// MOD 2015.07.13 TDI�j�j�V�@�o�[�R�[�h�ǎ��p��ʒǉ� END

			try
			{

// ADD 2009.04.02 ���s�j���� �ғ����Ή� START
				if(s�o�^�o�f.Equals("�����o��"))
				{
					dt�o�ד�.MaxDate = gdt�o�ד��ő�l�b�r�u;
				}else{
					dt�o�ד�.MaxDate = gdt�o�ד��ő�l;
				}
// MOD 2009.12.08 ���s�j���� �w����̏����Q�i��L�̃O���[�o���Ή��̏�Q�jSTART
//// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� START
////				dt�w���.MaxDate = dt�o�ד�.Value.AddDays(14);
//				if(gs����X���b�c.Equals("047")){
//					dt�w���.MaxDate = gdt�o�ד�.AddDays(90);
//				}else{
//					dt�w���.MaxDate = gdt�o�ד�.AddDays(14);
//				}
//// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� END
				if(gs����X���b�c.Equals("047")){
					dt�w���.MaxDate = dt�o�ד�.Value.AddDays(90);
				}else{
					dt�w���.MaxDate = dt�o�ד�.Value.AddDays(14);
				}
// MOD 2009.12.08 ���s�j���� �w����̏����Q�i��L�̃O���[�o���Ή��̏�Q�jEND
// ADD 2009.04.02 ���s�j���� �ғ����Ή� END
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX START
//				dt�o�ד�.Value       = DateTime.Parse(sList[1]);
				dt�o�ד�.Value       = YYYYMMDD�ϊ�(sList[1]);
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX END

				if(gs���p�҂b�c != s�o�^�҂b�c)
				{
					tex���b�Z�[�W�Q.Text = "���̃f�[�^�́A�o�^�҂��Ⴄ�ׁA"
						+ "�C������э폜���ł��܂���B�C������э폜���s���ꍇ�ɂ́A"
						+ "�o�^�҂Ń��O�C�����ĉ������B";
					�X�V�s����();
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX START
//					dt�o�ד�.Value   = DateTime.Parse(sList[1]);
					dt�o�ד�.Value   = YYYYMMDD�ϊ�(sList[1]);
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX END
					i�X�V�e�f = 1;
				}
			}
			catch (Exception)
			{
// MOD 2015.07.13 TDI�j�j�V �o�[�R�[�h�ǎ��p��ʒǉ� START
//				tex���b�Z�[�W�Q.Text = "���̃f�[�^�́A�m�肳��Ă���ׁA"
//				    + "�C������э폜���ł��܂���B�C������э폜���s���ꍇ�ɂ́A"
//					+ "�Ŋ�̉c�Ə��܂Ō�A���������B";
//				btn�������.Visible = false;
//				�X�V�s����();
//// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX START
////				dt�o�ד�.Value   = DateTime.Parse(sList[1]);
//				dt�o�ד�.Value   = YYYYMMDD�ϊ�(sList[1]);
//// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX END
//// MOD 2010.11.12 ���s�j���� �����s�f�[�^���폜�\�ɂ��� START
//				if(gs���p�҂b�c == s�o�^�҂b�c){
//					string s���       = sList[49];
//					if(s��� == "01"){ // [���]���u�����s�v�̏ꍇ
//						tex���b�Z�[�W�Q.Text = "���̃f�[�^�́A�m�肳��Ă���ׁA"
//						    + "�C�����ł��܂���B�C�����s���ꍇ�ɂ́A"
//							+ "�Ŋ�̉c�Ə��܂Ō�A���������B";
//						btn�폜.Enabled = true;
//					}
//				}
//// MOD 2010.11.12 ���s�j���� �����s�f�[�^���폜�\�ɂ��� END
				if (!b�O���[�o���`�F�b�N�P || !b�O���[�o���`�F�b�N�Q)
				{
					//�O���[�o������׎�ł͂Ȃ�
					tex���b�Z�[�W�Q.Text = "���̃f�[�^�́A�m�肳��Ă���ׁA"
						+ "�C������э폜���ł��܂���B�C������э폜���s���ꍇ�ɂ́A"
						+ "�Ŋ�̉c�Ə��܂Ō�A���������B";
					btn�������.Visible = false;
					�X�V�s����();
					// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX START
					//				dt�o�ד�.Value   = DateTime.Parse(sList[1]);
					dt�o�ד�.Value   = YYYYMMDD�ϊ�(sList[1]);
					// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX END
					// MOD 2010.11.12 ���s�j���� �����s�f�[�^���폜�\�ɂ��� START
					if(gs���p�҂b�c == s�o�^�҂b�c)
					{
						string s���       = sList[49];
						if(s��� == "01")
						{ // [���]���u�����s�v�̏ꍇ
							tex���b�Z�[�W�Q.Text = "���̃f�[�^�́A�m�肳��Ă���ׁA"
								+ "�C�����ł��܂���B�C�����s���ꍇ�ɂ́A"
								+ "�Ŋ�̉c�Ə��܂Ō�A���������B";
							btn�폜.Enabled = true;
						}
					}
					// MOD 2010.11.12 ���s�j���� �����s�f�[�^���폜�\�ɂ��� END
				}
				else
				{
					//�O���[�o������׎�ł���
					//tex���b�Z�[�W�Q.Text = "�O���[�o���o�׏C������";

					//�o�ד��͓����ɏC������
					dt�o�ד�.Value   = DateTime.Today;

					if(gs���p�҂b�c == s�o�^�҂b�c)
					{
						string s���       = sList[49];
						if(s��� == "01")
						{ // [���]���u�����s�v�̏ꍇ
							tex���b�Z�[�W�Q.Text = "���̃f�[�^�́A�m�肳��Ă���ׁA"
								+ "�C�����ł��܂���B�C�����s���ꍇ�ɂ́A"
								+ "�Ŋ�̉c�Ə��܂Ō�A���������B";
							btn�폜.Enabled = true;
						}
						else
						{
							nUD��.Focus();
						}
					}
				}
// MOD 2015.07.13 TDI�j�j�V �o�[�R�[�h�ǎ��p��ʒǉ� END
			}
// MOD 2011.01.24 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������i���˗���A�o�ד��jSTART
// MOD 2011.03.11 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������̋��� START
//			if(s�o�׍ςe�f == "1"){
			if((s�o�׍ςe�f == "1")
			|| (sList[1].Replace("/","").CompareTo(gs�o�ד�) <= 0 && s����ςe�f == "1")){
// MOD 2011.03.11 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������̋��� END
				dt�o�ד�       .Enabled = false;
				tex�˗���R�[�h.Enabled = false;
				btn�˗��匟��  .Enabled = false;
			}else{
				dt�o�ד�       .Enabled = true;
				tex�˗���R�[�h.Enabled = true;
// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� START
				��ʐ���ݒ�Q(tex�˗���R�[�h, s��ʐ���_�˗���);
// MOD 2011.07.25 ���s�j���� �e���ڂ̓��͕s�Ή� END
				btn�˗��匟��  .Enabled = true;
			}
// MOD 2011.01.24 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������i���˗���A�o�ד��jEND

			tex���q�l�Ǘ��ԍ�.Text    = sList[2];
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
//				tex�˗��吿����.Text      = sList[15];
// ADD 2005.06.01 ���s�j�ɉ� �A���w���R�[�h�ǉ� START
			s�A�����i�e�R�[�h         = sList[41];
			s�A�����i�q�R�[�h         = sList[42];
			�A�����i���d�ʐ���();
// ADD 2005.06.01 ���s�j�ɉ� �A���w���R�[�h�ǉ� END
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
			if(sList[18] == "0")
			{
				cBox�w���.Checked    = false;
				label3.Visible = true;
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
//				label�K��.Visible = false;
				cmb�w����敪.Visible = false;
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� END
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@END
				cBox�w����Œ�.Visible = false;
			}
			else
			{
				label3.Visible = false;
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
//				label�K��.Visible = true;
				cmb�w����敪.Visible = true;
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� END
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@END
				cBox�w���.Checked    = true;
				cBox�w����Œ�.Visible = true;
				try
				{
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX START
//					dt�w���.Value        = DateTime.Parse(sList[18]);
					dt�w���.Value        = YYYYMMDD�ϊ�(sList[18]);
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX END
				}
				catch (Exception)
				{
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX START
//					dt�w���.MaxDate = DateTime.Parse("2105/12/31");
//					dt�w���.MinDate = DateTime.Parse("2005/01/01");
//					dt�w���.Value   = DateTime.Parse(sList[18]);
					dt�w���.MaxDate = YYYYMMDD�ϊ�("2105/12/31");
					dt�w���.MinDate = YYYYMMDD�ϊ�("2005/01/01");
					dt�w���.Value   = YYYYMMDD�ϊ�(sList[18]);
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX END
					panel1.Enabled = false;
					panel2.Enabled = false;
					panel3.Enabled = false;
					panel4.Enabled = false;
					panel5.Enabled = false;
					btn�X�V.Enabled = false;
					btn�������.Visible = false;
					btn���.Enabled = false;
					btn�폜.Enabled = false;
					tex���b�Z�[�W�Q.Visible = true;
				}
			}
// DEL 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
// ADD 2005.06.08 ���s�j�ɉ� �w����敪�ǉ� START
			if (sList[44].Length != 0)
				cmb�w����敪.SelectedIndex = int.Parse(sList[44]);
			else
				cmb�w����敪.SelectedIndex = 0;
// ADD 2005.06.08 ���s�j�ɉ� �w����敪�ǉ� END
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� END
// DEL 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@END
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
			nUD�ی����z.Value         = decimal.Parse(sList[24]);
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
			tex�˗��啔��.Text = sList[37];
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� START
			// ���s�̐��������\��
			tex������R�[�h.Text     = sList[47];
			tex�����敔�ۃR�[�h.Text = sList[48];
			tex�˗��吿����.Text     = sList[15];
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� END

			sUpday             = sList[25];

			// �͂���R�[�h�Ƀt�H�[�J�X
			s�˗���b�c         = tex�˗���R�[�h.Text;
			s�O�񌟍��˗���b�c = tex�˗���R�[�h.Text;
// MOD 2005.05.12 ���s�j�����J �˗���d�� START
//			d�d�� = nUD�d��.Value;
// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� STRAT
//// MOD 2005.05.17 ���s�j�����J �ː��ǉ� START
////			d�d�� = decimal.Parse(sList[38]);
//			if(i�ː��e�f == 0)
//				d�d�� = decimal.Parse(sList[40]);
//			else
//				d�d�� = decimal.Parse(sList[38]);
//// MOD 2005.05.17 ���s�j�����J �ː��ǉ� END
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
// MOD 2005.05.12 ���s�j�����J �˗���d�� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
			}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
			s�o�^�����ԍ� = sList[43].Trim();
			if (s�o�^�����ԍ�.Length != 0)
				s�o�^�A�����i�R�[�h = s�A�����i�e�R�[�h;
			tex�͂���R�[�h.Focus();
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
//				int iPos = 1;
//				tex���^��.Text            = sList[iPos++].Trim();
//				s�t�@�C����               = sList[iPos++].Trim();
				int iPos = 3;
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
					tex�͂���Z���P.Text      = sList[iPos++].TrimEnd();
					tex�͂���Z���Q.Text      = sList[iPos++].TrimEnd();
					tex�͂���Z���R.Text      = sList[iPos++].TrimEnd();
					tex�͂��於�O�P.Text      = sList[iPos++].TrimEnd();
					tex�͂��於�O�Q.Text      = sList[iPos++].TrimEnd();
				}else{
					tex�͂���Z���P.Text      = sList[iPos++].Trim();
					tex�͂���Z���Q.Text      = sList[iPos++].Trim();
					tex�͂���Z���R.Text      = sList[iPos++].Trim();
					tex�͂��於�O�P.Text      = sList[iPos++].Trim();
					tex�͂��於�O�Q.Text      = sList[iPos++].Trim();
				}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
				tex�͂���X�֔ԍ��P.Text  = sList[iPos++].Trim();
				tex�͂���X�֔ԍ��Q.Text  = sList[iPos++].Trim();
				tex�˗���R�[�h.Text      = sList[iPos++].Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//				tex�˗��啔��.Text        = sList[iPos++].Trim();
				if(gs�I�v�V����[18].Equals("1")){
					tex�˗��啔��.Text        = sList[iPos++].TrimEnd();
				}else{
					tex�˗��啔��.Text        = sList[iPos++].Trim();
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

//				tex�A�����e.Text          = sList[iPos++].Trim();
//				tex�A�����q.Text          = sList[iPos++].Trim();
				tex�A�����e.Text          = sList[iPos++].TrimEnd();
				tex�A�����q.Text          = sList[iPos++].TrimEnd();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//				tex�L�����P.Text          = sList[iPos++].Trim();
//				tex�L�����Q.Text          = sList[iPos++].Trim();
//				tex�L�����R.Text          = sList[iPos++].Trim();
				if(gs�I�v�V����[18].Equals("1")){
					tex�L�����P.Text          = sList[iPos++].TrimEnd();
					tex�L�����Q.Text          = sList[iPos++].TrimEnd();
					tex�L�����R.Text          = sList[iPos++].TrimEnd();
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
					if(sList.Length > 41){
						tex�L�����S.Text      = sList[41].TrimEnd();
						tex�L�����T.Text      = sList[42].TrimEnd();
						tex�L�����U.Text      = sList[43].TrimEnd();
					}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
				}else{
					tex�L�����P.Text          = sList[iPos++].Trim();
					tex�L�����Q.Text          = sList[iPos++].Trim();
					tex�L�����R.Text          = sList[iPos++].Trim();
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
//				s�X�V�N����               = sList[iPos++].Trim();
				iPos++;

				tex�˗���d�b�ԍ��P.Text  = sList[iPos++].Trim();
				tex�˗���d�b�ԍ��Q.Text  = sList[iPos++].Trim();
				tex�˗���d�b�ԍ��R.Text  = sList[iPos++].Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
//				tex�˗���Z���P.Text      = sList[iPos++].Trim();
//				tex�˗���Z���Q.Text      = sList[iPos++].Trim();
//				tex�˗��喼�O�P.Text      = sList[iPos++].Trim();
//				tex�˗��喼�O�Q.Text      = sList[iPos++].Trim();
				if(gs�I�v�V����[18].Equals("1")){
					tex�˗���Z���P.Text      = sList[iPos++].TrimEnd();
					tex�˗���Z���Q.Text      = sList[iPos++].TrimEnd();
					tex�˗��喼�O�P.Text      = sList[iPos++].TrimEnd();
					tex�˗��喼�O�Q.Text      = sList[iPos++].TrimEnd();
				}else{
					tex�˗���Z���P.Text      = sList[iPos++].Trim();
					tex�˗���Z���Q.Text      = sList[iPos++].Trim();
					tex�˗��喼�O�P.Text      = sList[iPos++].Trim();
					tex�˗��喼�O�Q.Text      = sList[iPos++].Trim();
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
// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� START
//				tex���b�Z�[�W.Text = "";
// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� END
				s�˗���b�c         = tex�˗���R�[�h.Text;
				s�O�񌟍��˗���b�c = tex�˗���R�[�h.Text;
// MOD 2005.05.12 ���s�j�����J �˗���d�� START
//				d�d�� = nUD�d��.Value;
//				d�d�� = decimal.Parse(sList[36].Trim());
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
// MOD 2009.06.11 ���s�j���� ���˗�����̏d�ʁE�ː��O�Ή� END
// MOD 2005.05.12 ���s�j�����J �˗���d�� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
				}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END
			}
		}

		private void btn�폜_Click(object sender, System.EventArgs e)
		{			
			DialogResult result = MessageBox.Show("���̃f�[�^���폜���܂����H","�폜",MessageBoxButtons.YesNo);
			if(result == DialogResult.Yes)
			{
				string[] sData = new string[6];
				sData[0] = gs����b�c;
				sData[1] = gs����b�c;
				sData[2] = s�o�^��;
				sData[3] = s�W���[�i���m�n;
				sData[4] = "�o�דo�^";
				sData[5] = gs���p�҂b�c;
				// �J�[�\���������v�ɂ���
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				string[] sDList = {""};
				try
				{
// MOD 2010.11.12 ���s�j���� �����s�f�[�^���폜�\�ɂ��� START
					if(gs���p�҂b�c != s�o�^�҂b�c){
						Cursor = System.Windows.Forms.Cursors.Default;
						�r�[�v��();
						tex���b�Z�[�W.Text = "�o�^�҂��Ⴄ�׍폜�ł��܂���ł���";
						return;
					}
					// �m��f�[�^�H�i�ҏW�s�ŏo�ד��Ȃǂ��͈͊O�j�̎�
					if(tex���b�Z�[�W�Q.Visible){
						string[] sList = {""};
						tex���b�Z�[�W.Text = "�������D�D�D";
						if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
						sList = sv_syukka.Get_Ssyukka(gsa���[�U
							, gs����b�c, gs����b�c, s�o�^��, int.Parse(s�W���[�i���m�n));
						// �G���[��
						if(sList[0].Length != 4){
							Cursor = System.Windows.Forms.Cursors.Default;
							�r�[�v��();
							tex���b�Z�[�W.Text = sList[0];
							return;
						}
						string s�����ԍ� = sList[43];
						string s���       = sList[49];
						string s�o�׍ςe�f = sList[50];
// MOD 2011.03.11 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������̋��� START
						string s����ςe�f = (sList.Length > 51) ? sList[51] : "";
//						string s���M�ςe�f = (sList.Length > 52) ? sList[52] : "";
// MOD 2011.03.11 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������̋��� END
						if(s��� != "01"){ // [���]���u�����s�v�̈ȊO�̏ꍇ
							Cursor = System.Windows.Forms.Cursors.Default;
							�r�[�v��();
							tex���b�Z�[�W.Text = "�u�����s�v�łȂ��׍폜�ł��܂���ł���";
							return;
						}
						// ����[�����ԍ�]���̔Ԃ���A�u�o�׍ρv�̏ꍇ
// MOD 2011.03.11 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������̋��� START
//						if(s�����ԍ�.Length > 0 && s�o�׍ςe�f == "1"){
						if((s�����ԍ�.Length > 0 && s�o�׍ςe�f == "1")
						|| (sList[1].Replace("/","").CompareTo(gs�o�ד�) <= 0 && s����ςe�f == "1") ){
// MOD 2011.03.11 ���s�j���� �f�o���M�ρi�o�׍ρj�f�[�^�̏C�������̋��� END
							result = MessageBox.Show(
								"���Ƀ��x�����s���s���Ă��܂����A�@\n"
								+ "�폜���Ă�낵���ł����H�@\n"
								, "�폜"
								, MessageBoxButtons.YesNo
								, MessageBoxIcon.Warning);
							// [Yes]�ȊO�͏I��
							if(result != DialogResult.Yes){
								Cursor = System.Windows.Forms.Cursors.Default;
								tex���b�Z�[�W.Text = "";
								return;
							}
						}
					}
// MOD 2010.11.12 ���s�j���� �����s�f�[�^���폜�\�ɂ��� END
					tex���b�Z�[�W.Text = "�폜���D�D�D";
					if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
// MOD 2010.06.18 ���s�j���� �o�׃f�[�^�̎Q�ƁE�ǉ��E�X�V�E�폜���O�̒ǉ� START
//					sDList = sv_syukka.Del_syukka(gsa���[�U,sData);
					sDList = sv_syukka.Del_syukka2(gsa���[�U,sData,s�o�^�����ԍ�);
// MOD 2010.06.18 ���s�j���� �o�׃f�[�^�̎Q�ƁE�ǉ��E�X�V�E�폜���O�̒ǉ� END
				}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
				catch (System.Net.WebException)
				{
					sDList[0] = gs�ʐM�G���[;
				}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
				catch (Exception ex)
				{
					sDList[0] = "�ʐM�G���[�F" + ex.Message;
				}
				// �J�[�\�����f�t�H���g�ɖ߂�
				Cursor = System.Windows.Forms.Cursors.Default;

				// �G���[��
				if(sDList[0].Length != 4)
				{
					�r�[�v��();
					tex���b�Z�[�W.Text = sDList[0];
				}
				else
					// [����I��]���A��ʂ��N���A����
					btn���_Click(sender, e);

			}

		}

		private void btn���_Click(object sender, System.EventArgs e)
		{
			if(cBox�o�ד��Œ�.Checked == false){
// MOD 2009.04.22 ���s�j���� ���t�ϊ��̕ύX START
				if(cBox�w����Œ�.Checked == false)
				{
					dt�w���.MinDate = YYYYMMDD�ϊ�("2005/01/01");
					dt�w���.MaxDate = YYYYMMDD�ϊ�("2105/12/31");
					dt�w���.Value   = gdt�o�ד�.AddDays(1);
					dt�w���.MinDate = gdt�o�ד�;
// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� START
//					dt�w���.MaxDate = gdt�o�ד�.AddDays(14);
					if(gs����X���b�c.Equals("047")){
						dt�w���.MaxDate = gdt�o�ד�.AddDays(90);
					}else{
						dt�w���.MaxDate = gdt�o�ד�.AddDays(14);
					}
// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� END
				}
// MOD 2009.04.22 ���s�j���� ���t�ϊ��̕ύX END
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
				b�w����`�F�b�N�l�r�f�L = false;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
				dt�o�ד�.Value = gdt�o�ד�;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
				b�w����`�F�b�N�l�r�f�L = true;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
			}

			�͂��捀�ڃN���A();
			���̑����ڃN���A();
// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� START
			�L���i���Œ�L��();
			�L���i���Œ�Ǎ�();
// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� END

			if(cBox�˗���Œ�.Checked == false){
				tex�˗��啔��.Text         = "";
				tex�˗���R�[�h.Text = gs�ב��l�b�c;
				s�˗���b�c          = gs�ב��l�b�c;
			}
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� START
//			if(s�˗���b�c != s�O�񌟍��˗���b�c) 
//			{
//				�˗��區�ڃN���A();
//				tex�˗���R�[�h.Text = s�˗���b�c;
//				if(s�˗���b�c.Length > 0) �˗��匟��(false);
//			}
// MOD 2010.09.30 ���s�j���� �S���ҁi�˗��啔���j�N���A��Q�Ή� START
//			�˗��區�ڃN���A();
			�˗��區�ڃN���A�Q();
// MOD 2010.09.30 ���s�j���� �S���ҁi�˗��啔���j�N���A��Q�Ή� END
			tex�˗���R�[�h.Text = s�˗���b�c;
			if(s�˗���b�c.Length > 0){
				�˗��匟��(false);
			}
// MOD 2010.08.31 ���s�j���� ���s�̐�������̕\�� END
			tex�͂���R�[�h.Focus();
// MOD 2005.05.12 ���s�j�����J �����d�ʂO START
//			nUD�d��.Value = d�d��;
// MOD 2005.05.12 ���s�j�����J �����d�ʂO START

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
// MOD 2006.06.27 ���s�j�R�{�@�X�֔ԍ����͎�TAB�����ɂďZ�������@START
			if((e.KeyCode == Keys.Enter)||(e.KeyCode == Keys.Tab))
//			if(e.KeyCode == Keys.Enter)
// MOD 2006.06.27 ���s�j�R�{�@�X�֔ԍ����͎�TAB�����ɂďZ�������@END
			{
				// �󔒏���
				tex�͂���X�֔ԍ��P.Text = tex�͂���X�֔ԍ��P.Text.Trim();
				tex�͂���X�֔ԍ��Q.Text = tex�͂���X�֔ԍ��Q.Text.Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//				tex�͂���Z���P.Text = tex�͂���Z���P.Text.Trim();
//				tex�͂���Z���Q.Text = tex�͂���Z���Q.Text.Trim();
//				tex�͂���Z���R.Text = tex�͂���Z���R.Text.Trim();
				if(gs�I�v�V����[18].Equals("1")){
					tex�͂���Z���P.Text = tex�͂���Z���P.Text.TrimEnd();
					tex�͂���Z���Q.Text = tex�͂���Z���Q.Text.TrimEnd();
					tex�͂���Z���R.Text = tex�͂���Z���R.Text.TrimEnd();
				}else{
					tex�͂���Z���P.Text = tex�͂���Z���P.Text.Trim();
					tex�͂���Z���Q.Text = tex�͂���Z���Q.Text.Trim();
					tex�͂���Z���R.Text = tex�͂���Z���R.Text.Trim();
				}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
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
// MOD 2007.06.21 ���s�j���� �X�֔ԍ��ύX���̃J�[�\���ړ��̏C�� START
					}else{
						if(e.KeyCode == Keys.Tab) tex�͂���Z���P.Focus();
// MOD 2007.06.21 ���s�j���� �X�֔ԍ��ύX���̃J�[�\���ړ��̏C�� END
					}
				}
// MOD 2006.12.14 ���s�j�����J�@�X�֔ԍ����͎�TAB�����ɂďZ�������@START
//				else
				else if(e.KeyCode == Keys.Enter)
// MOD 2006.12.14 ���s�j�����J�@�X�֔ԍ����͎�TAB�����ɂďZ�������@END
				{
					btn�Z������.Focus();
					btn�Z������_Click(sender, e);
				}
// MOD 2007.06.21 ���s�j���� �X�֔ԍ��ύX���̃J�[�\���ړ��̏C�� START
				else
				{
					tex�͂���Z���P.Focus();
				}
// MOD 2007.06.21 ���s�j���� �X�֔ԍ��ύX���̃J�[�\���ړ��̏C�� END

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

		private void tex�L���R�[�h_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn�L������_Click(sender,e);
				e.Handled = true;
			}
		}

		private void �o�דo�^_Activated(object sender, System.EventArgs e)
		{
			if(i�A�N�e�B�u�e�f == 0)
			{
				tex�͂���R�[�h.Focus();

// ADD 2005.05.11 ���s�j���� �����悪���݂��Ȃ����̑Ή� START
				i�A�N�e�B�u�e�f = 1;
// ADD 2005.05.11 ���s�j���� �����悪���݂��Ȃ����̑Ή� END
				// �X�V���[�h�ȊO�i�o�^�j
				// ���A���`�o�^�ȊO
				if(s�����e�f != "U" && i���^�m�n <= 0)
				{
					tex�˗���R�[�h.Text = gs�ב��l�b�c;
					s�˗���b�c          = gs�ב��l�b�c;
					if(s�˗���b�c.Length > 0) �˗��匟��(false);

// MOD 2010.10.04 ���s�j���� �S���ҁi�˗��啔���j�t�H�[�J�X��Q�Ή� START
//					if(s�����e�f == "U")
//						tex�˗��啔��.Focus();
//					else
//						tex�͂���R�[�h.Focus();
					tex�͂���R�[�h.Focus();
// MOD 2010.10.04 ���s�j���� �S���ҁi�˗��啔���j�t�H�[�J�X��Q�Ή� END
				}
			}
// DEL 2005.05.11 ���s�j���� �����悪���݂��Ȃ����̑Ή� START
//			i�A�N�e�B�u�e�f = 1;
// DEL 2005.05.11 ���s�j���� �����悪���݂��Ȃ����̑Ή� END
		}

		private void cBox�w���_Click(object sender, System.EventArgs e)
		{
			if(cBox�w���.Checked == true)
			{
				label3.Visible = false;
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
//				label�K��.Visible = true;
				cmb�w����敪.Visible = true;
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� END
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@END
				cBox�w����Œ�.Visible = true;
			}
			else
			{
				label3.Visible = true;
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
//				label�K��.Visible = false;
				cmb�w����敪.Visible = false;
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� END
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@END
				cBox�w����Œ�.Visible = false;
			}
		}

		private void dt�w���_DropDown(object sender, System.EventArgs e)
		{
			label3.Visible = false;
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@START
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� START
//			label�K��.Visible = true;
			cmb�w����敪.Visible = true;
// MOD 2008.11.14 ���s�j���� �w����敪�̕��� END
// MOD 2006.06.27 ���s�j�R�{�@�w�����K���ɌŒ�@END
			cBox�w����Œ�.Visible = true;
			cBox�w���.Checked = true;
		}

		private void dt�w���_CloseUp(object sender, System.EventArgs e)
		{
			tex�A���R�[�h�e.Focus();
		}

// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� START
		private void �o�דo�^_Closed(object sender, System.EventArgs e)
		{
			cBox�o�ד��Œ�.Checked = false;
			cBox�˗���Œ�.Checked = false;
// MOD 2009.10.05 �p�\�j����@�L���E�i���^���̍s�ʌŒ�@�\�̒ǉ� START
// ADD 2009.09.01 �p�\�j���� �L���E�i���^���̌Œ�@�\�̒ǉ� START
//			cBox�L���i���Œ�.Checked = false;
			cBox���Œ�.Checked = false;
// ADD 2009.09.01 �p�\�j���� �L���E�i���^���̌Œ�@�\�̒ǉ� END
			cBox�L���i���Œ�P.Checked = false;
			cBox�L���i���Œ�Q.Checked = false;
			cBox�L���i���Œ�R.Checked = false;
// MOD 2009.10.05 �p�\�j����@�L���E�i���^���̍s�ʌŒ�@�\�̒ǉ� END
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
			cBox�L���i���Œ�S.Checked = false;
			cBox�L���i���Œ�T.Checked = false;
			cBox�L���i���Œ�U.Checked = false;
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
			�͂��捀�ڃN���A();
			�˗��區�ڃN���A();
			���̑����ڃN���A();
		}
// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� END
// ADD 2009.04.02 ���s�j���� �ғ����Ή� START
		private void dt�o�ד�_ValueChanged(object sender, System.EventArgs e)
		{
			�o�ד��`�F�b�N();
		}
		private bool �o�ד��`�F�b�N()
		{
			try
			{
				//�w����͈̔͂̕ύX
				//�ŏ��l�F�o�ד��A�ő�l�F�o�ד��{�P�S�� or �X�O��
// MOD 2009.12.08 ���s�j���� �w����̏����Q�i��L�̃O���[�o���Ή��̏�Q�jSTART
//// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� START
////				dt�w����ő�l = dt�o�ד�.Value.AddDays(14);
//				if(gs����X���b�c.Equals("047")){
//					dt�w����ő�l = gdt�o�ד�.AddDays(90);
//				}else{
//					dt�w����ő�l = gdt�o�ד�.AddDays(14);
//				}
//// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� END
				if(gs����X���b�c.Equals("047")){
					dt�w����ő�l = dt�o�ד�.Value.AddDays(90);
				}else{
					dt�w����ő�l = dt�o�ד�.Value.AddDays(14);
				}
// MOD 2009.12.08 ���s�j���� �w����̏����Q�i��L�̃O���[�o���Ή��̏�Q�jEND
// MOD 2016.04.13 BEVAS�j���{ �z�B�w�������̊g�� START
				//�Z���A�l�̏ꍇ�A�z�B�w����̏����180���ɂ܂Ŋg��
				if(gs����b�c.Equals(gs�w�������g������b�c))
				{
					dt�w����ő�l = dt�o�ד�.Value.AddDays(180);
				}
// MOD 2016.04.13 BEVAS�j���{ �z�B�w�������̊g�� END
				dt�w����ŏ��l = dt�o�ד�.Value;

				//[�w���]�̃`�F�b�N�������Ă��Ȃ���
				if(cBox�w���.Checked == false){
					dt�w���.MaxDate = YYYYMMDD�ϊ�("2105/12/31");
					dt�w���.MinDate = YYYYMMDD�ϊ�("2005/01/01");
					dt�w���.Value   = dt�o�ד�.Value.AddDays(1);
					dt�w���.MaxDate = dt�w����ő�l;
					dt�w���.MinDate = dt�w����ŏ��l;
					return true;
				}

				//�ȉ���[�w���]�̃`�F�b�N�������Ă��鎞

				if(dt�w���.Value < dt�w����ŏ��l){
					dt�w���.MaxDate = dt�w����ő�l;
					dt�w���.MinDate = dt�w���.Value;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
					if(b�w����`�F�b�N�l�r�f�L){
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
						//�G���[���b�Z�[�W�\����A�t�H�[�J�X�ړ�
						MessageBox.Show("�z�B�w����͏o�ד��ȍ~����͂��Ă�������\n"
										+ "�i" 
										+ dt�w����ŏ��l.Month + "��"
										+ dt�w����ŏ��l.Day   + "�� �` "
										+ dt�w����ő�l.Month + "��"
										+ dt�w����ő�l.Day   + "���j"
										,"���̓`�F�b�N"
										,MessageBoxButtons.OK);
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
					}
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
					dt�w���.Refresh();
					dt�w���.Focus();
					return false;
				}else if(dt�w���.Value > dt�w����ő�l){
					dt�w���.MaxDate = dt�w���.Value;
					dt�w���.MinDate = dt�w����ŏ��l;
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
					if(b�w����`�F�b�N�l�r�f�L){
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
						//�G���[���b�Z�[�W�\����A�t�H�[�J�X�ړ�
						MessageBox.Show("�z�B�w�����ύX���Ă�������\n"
										+ "�i" 
										+ dt�w����ŏ��l.Month + "��"
										+ dt�w����ŏ��l.Day   + "�� �` "
										+ dt�w����ő�l.Month + "��"
										+ dt�w����ő�l.Day   + "���j"
										,"���̓`�F�b�N"
										,MessageBoxButtons.OK);
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� START
					}
// MOD 2010.03.26 ���s�j���� �w����Œ�`�F�b�N���̏�Q�Ή� END
					dt�w���.Refresh();
					dt�w���.Focus();
					return false;
				}else{
					dt�w���.MaxDate = dt�w����ő�l;
					dt�w���.MinDate = dt�w����ŏ��l;
				}
			}
			catch (Exception)
			{
				;
				return false;
			}
			return true;
		}

// MOD 2009.10.05 �p�\�j����@�L���E�i���^���̍s�ʌŒ�@�\�̒ǉ� START
		private void btn�L���i���Œ�_Click(object sender, System.EventArgs e)
		{
// MOD 2009.10.16 ���s�j���� �L���E�i���Œ�`�F�b�N�����@�\�̒ǉ� START
			if(cBox�L���i���Œ�P.Checked
			&& cBox�L���i���Œ�Q.Checked
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
//			&& cBox�L���i���Œ�R.Checked){
			&& cBox�L���i���Œ�R.Checked
			&& cBox�L���i���Œ�S.Checked
			&& cBox�L���i���Œ�T.Checked
			&& cBox�L���i���Œ�U.Checked
			){
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
				cBox�L���i���Œ�P.Checked = false;
				cBox�L���i���Œ�Q.Checked = false;
				cBox�L���i���Œ�R.Checked = false;
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
				cBox�L���i���Œ�S.Checked = false;
				cBox�L���i���Œ�T.Checked = false;
				cBox�L���i���Œ�U.Checked = false;
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
				//tex�L���R�[�h.Focus();
			}else{
// MOD 2009.10.16 ���s�j���� �L���E�i���Œ�`�F�b�N�����@�\�̒ǉ� END
				cBox�L���i���Œ�P.Checked = true;
				cBox�L���i���Œ�Q.Checked = true;
				cBox�L���i���Œ�R.Checked = true;
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
				cBox�L���i���Œ�S.Checked = true;
				cBox�L���i���Œ�T.Checked = true;
				cBox�L���i���Œ�U.Checked = true;
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
				//tex�L���R�[�h.Focus();
// MOD 2009.10.16 ���s�j���� �L���E�i���Œ�`�F�b�N�����@�\�̒ǉ� START
			}
// MOD 2009.10.16 ���s�j���� �L���E�i���Œ�`�F�b�N�����@�\�̒ǉ� END
		}
// MOD 2009.10.05 �p�\�j����@�L���E�i���^���̍s�ʌŒ�@�\�̒ǉ� END

// ADD 2009.04.02 ���s�j���� �ғ����Ή� END
// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� START
		private void �L���i���Œ�L��()
		{
			btn�L���i���Œ�.Visible    = true;
			cBox�L���i���Œ�P.Visible = true;
			cBox�L���i���Œ�Q.Visible = true;
			cBox�L���i���Œ�R.Visible = true;
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
			cBox�L���i���Œ�S.Visible = true;
			cBox�L���i���Œ�T.Visible = true;
			cBox�L���i���Œ�U.Visible = true;
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
		}
		private void �L���i���Œ薳��()
		{
			btn�L���i���Œ�.Visible    = false;
			cBox�L���i���Œ�P.Visible = false;
			cBox�L���i���Œ�Q.Visible = false;
			cBox�L���i���Œ�R.Visible = false;
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
			cBox�L���i���Œ�S.Visible = false;
			cBox�L���i���Œ�T.Visible = false;
			cBox�L���i���Œ�U.Visible = false;
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
		}
		private void �L���i���Œ�Ǎ�()
		{
			if(sa�L���i���Œ� == null){
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
//				sa�L���i���Œ� = new string[]{"","","","","",""};
				sa�L���i���Œ� = new string[]{
					"","","","","",""
					, "","","","","",""
				};
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END

				StreamReader srp = null;
				try
				{
					srp = File.OpenText(gsInitKiji);
					for(int iCnt = 0; iCnt < sa�L���i���Œ�.Length; iCnt++){
						sa�L���i���Œ�[iCnt] = srp.ReadLine();
					}
				}
				catch(Exception)
				{
					;
				}
				finally
				{
					if(srp != null) srp.Close();
				}
			}

			if(sa�L���i���Œ�[0] == "1"){
				cBox�L���i���Œ�P.Checked = true;
				tex�L�����P.Text = sa�L���i���Œ�[1];
			}
			if(sa�L���i���Œ�[2] == "1"){
				cBox�L���i���Œ�Q.Checked = true;
				tex�L�����Q.Text = sa�L���i���Œ�[3];
			}
			if(sa�L���i���Œ�[4] == "1"){
				cBox�L���i���Œ�R.Checked = true;
				tex�L�����R.Text = sa�L���i���Œ�[5];
			}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
			if(sa�L���i���Œ�[6] == "1"){
				cBox�L���i���Œ�S.Checked = true;
				tex�L�����S.Text = sa�L���i���Œ�[7];
			}
			if(sa�L���i���Œ�[8] == "1"){
				cBox�L���i���Œ�T.Checked = true;
				tex�L�����T.Text = sa�L���i���Œ�[9];
			}
			if(sa�L���i���Œ�[10] == "1"){
				cBox�L���i���Œ�U.Checked = true;
				tex�L�����U.Text = sa�L���i���Œ�[11];
			}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
		}
		private void �L���i���Œ菑��()
		{
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
//			sa�L���i���Œ� = new string[]{"","","","","",""};
			sa�L���i���Œ� = new string[]{
				"","","","","",""
				, "","","","","",""
			};
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END

			if(cBox�L���i���Œ�P.Checked){
				sa�L���i���Œ�[0] = "1";
				sa�L���i���Œ�[1] = tex�L�����P.Text.TrimEnd();
			}
			if(cBox�L���i���Œ�Q.Checked){
				sa�L���i���Œ�[2] = "1";
				sa�L���i���Œ�[3] = tex�L�����Q.Text.TrimEnd();
			}
			if(cBox�L���i���Œ�R.Checked){
				sa�L���i���Œ�[4] = "1";
				sa�L���i���Œ�[5] = tex�L�����R.Text.TrimEnd();
			}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
			if(cBox�L���i���Œ�S.Checked){
				sa�L���i���Œ�[6] = "1";
				sa�L���i���Œ�[7] = tex�L�����S.Text.TrimEnd();
			}
			if(cBox�L���i���Œ�T.Checked){
				sa�L���i���Œ�[8] = "1";
				sa�L���i���Œ�[9] = tex�L�����T.Text.TrimEnd();
			}
			if(cBox�L���i���Œ�U.Checked){
				sa�L���i���Œ�[10] = "1";
				sa�L���i���Œ�[11] = tex�L�����U.Text.TrimEnd();
			}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END

			StreamWriter swp = null;
			try
			{
				swp = File.CreateText(gsInitKiji);
				for(int iCnt = 0; iCnt < sa�L���i���Œ�.Length; iCnt++){
					swp.WriteLine(sa�L���i���Œ�[iCnt]);
				}
			}
			catch(Exception)
			{
				;
			}
			finally
			{
				if(swp != null) swp.Close();
			}
		}

// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� END
// MOD 2015.07.13 TDI�j�j�V �o�[�R�[�h�ǎ��p��ʒǉ� START
		private bool �O���[�o���`�F�b�N�P()
		{
// MOD 2016.03.24 BEVAS�j���{ ���q�^���ŃO���[�o���^�p�Ή� START
//			if (gs����b�c.Substring(0,2).ToUpper() == "GL")
			if(gs����X���b�c.Equals("047"))
// MOD 2016.03.24 BEVAS�j���{ ���q�^���ŃO���[�o���^�p�Ή� END
			{
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
				//����O���[�o���׎傩�m�F����B
				sa�O���[�o���`�F�b�N = sv_syukka.Get_GlobalCount(gsa���[�U);
				if (sa�O���[�o���`�F�b�N[0] != "����I��") return false;
				if (sa�O���[�o���`�F�b�N[1] != "1") return false;
			}
			else
			{
				//�O���[�o���׎�łȂ�
				return false;
			}

			return true;
		}
// MOD 2015.07.13 TDI�j�j�V �o�[�R�[�h�ǎ��p��ʒǉ� END
// MOD 2015.07.13 TDI�j�j�V �o�[�R�[�h�ǎ��p��ʒǉ� START
		private bool �O���[�o���`�F�b�N�Q(string �����ԍ�)
		{
// MOD 2016.03.24 BEVAS�j���{ ���q�^���ŃO���[�o���^�p�Ή� START
//			if (gs����b�c.Substring(0,2).ToUpper() == "GL")
			if(gs����X���b�c.Equals("047"))
// MOD 2016.03.24 BEVAS�j���{ ���q�^���ŃO���[�o���^�p�Ή� END
			{
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
				//�W�׍ςłȂ����`�F�b�N����
				sa�O���[�o���`�F�b�N = sv_syukka.Get_ModifiableSyukkaCount(gsa���[�U,�����ԍ�);
				if (sa�O���[�o���`�F�b�N[0] != "����I��") return false;
				if (sa�O���[�o���`�F�b�N[1] != "1") return false;
			}
			else
			{
				//�O���[�o���׎�łȂ�
				return false;
			}

			return true;
		}
// MOD 2015.07.13 TDI�j�j�V �o�[�R�[�h�ǎ��p��ʒǉ� END
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
