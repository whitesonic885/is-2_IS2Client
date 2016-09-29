using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Xml;
using System.Net;
using System.Text;
using System.Security.Cryptography;

using IS2Client;

namespace IS2Client
{
	/// <summary>
	/// [Home]�i���j���[�j
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// MOD 2008.01.30 KCL) �X�{ �\���X�s�[�h�ύX 
	// MOD 2008.02.08 KCL) �X�{ ���m�点�C�� 
	// MOD 2008.02.13 ���s�j���� �w���v�̍ו����Ή� 
	// ADD 2008.03.13 ���s�j���� Vista�Ή� 
	// ADD 2008.04.11 ACT Vista�Ή� 
	// MOD 2008.05.20 ���s�j���� [wis2.dll]�̃t�H���_�̕ύX
	// ADD 2008.06.17 ���s�j���� �f�B���N�g�����݃`�F�b�N�̒ǉ� 
	//--------------------------------------------------------------------------
	// ADD 2009.04.02 ���s�j���� �ғ����Ή� 
	// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� 
	// ADD 2009.07.29 ���s�j���� �v���L�V�Ή� 
	// �@�h�d��[Secure]�̐ݒ肩����擾����
	// �@�v���L�V�����[�U���ݒ�ł���悤�ɂ���
	// MOD 2009.07.30 ���s�j���� exe��dll���Ή� 
	// MOD 2009.10.14 ���s�j���� config�Ǎ��Ȃ� 
	// MOD 2009.10.16 ���s�j���� �v���L�V�@�\�\�L�̒ǉ� 
	// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� 
	// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� 
	//--------------------------------------------------------------------------
	// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A 
	// MOD 2010.02.04 ���s�j���� �o�׎��щ�ʂ̃Z���^�����O 
	// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� 
	// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� 
	// MOD 2010.04.16 ���s�j���� ���W���[���ă_�E�����[�h 
	// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� 
	// MOD 2010.05.24 ���s�j���� 120DPI�Ή����̕\���ʒu���� 
	// MOD 2010.04.21 ���s�j���� �n���O�ߎ�����̖h�~ 
	// MOD 2010.05.25 ���s�j���� ���b�Z�[�W�̃X���b�h�� 
	// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX 
	// MOD 2010.06.01 ���s�j���� �����o�̓{�^���̈ړ� 
	// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� 
	// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j 
	// MOD 2010.07.30 ���s�j���� �f�t�H���g�v���L�V�ݒ�̏C�� 
	// MOD 2010.08.27 ���s�j���� ���˗���捞�i�b�r�u�j�@�\�ǉ� 
	// MOD 2010.09.03 ���s�j���� �b�r�u�G���g���[���̐�����G���[�\�L�C�� 
	// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� 
	// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX 
	// MOD 2010.11.02 ���s�j���� ���l�͈̓`�F�b�N�̕ύX 
	// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) 
	// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� 
	//--------------------------------------------------------------------------
	// MOD 2011.01.11 ���s�j���� ���q�^���̑Ή� 
	// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� 
	// MOD 2011.02.03 ���s�j���� SATO���v�����^���|�}�j���A���ǉ� 
	// MOD 2011.03.08 ���s�j���� ���q�^���Ή��i���j���[��ʂ̐ؑցj 
	// MOD 2011.04.05 ���s�j���� ��ʃC���[�W�̃��[�h�ύX 
	// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� 
	// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� 
	// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� 
	// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� 
	// MOD 2011.07.28 ���s�j���� �L���s�̒ǉ��i�����������̒ǉ��j 
	// MOD 2011.08.03 ���s�j���� �I�����Ɏ����o�͂������ɂȂ��Q�Ή� 
	// MOD 2011.08.11 ���s�j���� �L���s�̒ǉ��i�o�^���t�ȗ�����Q�Ή��j 
	// MOD 2011.09.05 ���s�j���� �o�ד��̏�����b�r�u�G���g���[�Ɠ��l�ɂ��� 
	// MOD 2011.10.11 ���s�j���� �r�r�k�ؖ���������ԂȂǂ̃`�F�b�N 
	// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� 
	//--------------------------------------------------------------------------
	// MOD 2012.09.26 COA)���R ���t���ڎ捞����
	//                         �i�����ɃX�y�[�X���܂ޏꍇ�C�X�y�[�X���[���ɕϊ����Ď捞�j
	//--------------------------------------------------------------------------
	// ADD 2013.02.15 TDI)�j�V �O���[�o���o�ד������g���Ή�(14����62��)
	//--------------------------------------------------------------------------
	// MOD 2015.04.13 BEVAS) �O�c �����o�̓^�C�}�[ (�b�P�ʎw��Ή�)
	// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ�
	// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ�
	//--------------------------------------------------------------------------
	// MOD 2016.01.15 BEVAS) ���{ WinXP��Ή��ɔ����Y���[���ւ̒��ӕ��\���Ή�
	// MOD 2016.01.21 BEVAS) ���{ ���m�点�{�^���̐F�ؑւ����C
	//                            �i�\��̐擪�Ɂu�y�d�v�z�v���t�����̂̓{�^���̐F��ς���j
	// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ�
	// MOD 2016.04.13 BEVAS�j���{ �z�B�w�������̊g��
	// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή�
	// MOD 2016.05.24 BEVAS�j���{ �Z�N�V�����ؑ։�ʉ��C�Ή�
	// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ�
    //--------------------------------------------------------------------------
    // MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX
    //--------------------------------------------------------------------------
	public class ���j���[ : ���ʃt�H�[��
	{
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� START
//		private static System.Threading.Mutex mutex;
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� END
// DEL 2005.05.27 ���s�j���� �X���b�h�ʒu�̈ړ� START
//		private Image[,]  imageMenu = null;
//		private Image[,,] imageCmd  = null;
// DEL 2005.05.27 ���s�j���� �X���b�h�ʒu�̈ړ� END
		private bool b���b�Z�[�W�X�V�� = false;
		private int i���b�Z�[�W�X�V�b�m�s = 0;
		private int i���b�Z�[�W�\���ʒu = 0;
		private int i���b�Z�[�W�b�m�s = 0;
		private System.Windows.Forms.Timer tim���b�Z�[�W;
		private int i�I���e�f = 0;
// MOD 2005.05.27 ���s�j���� �X���b�h�ʒu�̈ړ� START
//// ADD 2005.05.20 ���s�j���� �X���b�h�� START
//		private Thread trd = null;
//// ADD 2005.05.20 ���s�j���� �X���b�h�� END
		private static Image[,]  imageMenu = null;
		private static Image[,,] imageCmd  = null;
		private static Thread trd = null;
// MOD 2005.05.27 ���s�j���� �X���b�h�ʒu�̈ړ� END
// ADD 2005.05.25 ���s�j���� �w���v�t�q�k��config����擾 START
		private string s�w���v�t�q�k = "http://wwwis2.fukutsu.co.jp/is2/manual/is2manual.pdf";
// ADD 2005.05.25 ���s�j���� �w���v�t�q�k��config����擾 END
// MOD 2007.11.29 ���s�j���� ���O�C�����̃t�H�[�J�X��Q�Ή� START
		private static �����o�^ F�����o�^ = null;
		private static ���O�C�� F���O�C�� = null;
// MOD 2007.11.29 ���s�j���� ���O�C�����̃t�H�[�J�X��Q�Ή� END
// MOD 2009.10.14 ���s�j���� config�Ǎ��Ȃ� START
		private static string sUrl_address  = "";
		private static string sUrl_goirai   = "";
		private static string sUrl_hinagata = "";
		private static string sUrl_init     = "";
		private static string sUrl_kiji     = "";
		private static string sUrl_otodoke  = "";
		private static string sUrl_print    = "";
		private static string sUrl_syukka   = "";
		private static string sUrl_seikyuu  = "";
		private static string sUrl_oshirase = "";
// MOD 2009.10.14 ���s�j���� config�Ǎ��Ȃ� END
// MOD 2011.01.11 ���s�j���� ���q�^���̑Ή� START
		private static string sUrl_oji      = "";
// MOD 2011.01.11 ���s�j���� ���q�^���̑Ή� END
// MOD 2008.02.08 KCL) �X�{ ���m�点�C�� START
		private ���m�点�\��{�^�� [] btnList = new ���m�点�\��{�^�� [5];
// MOD 2008.02.08 KCL) �X�{ ���m�点�C�� END
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
		private string [][] s���m�点�ꗗ = null;
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
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

// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� START
		private System.Windows.Forms.Timer tim�o�ׂb�r�u�����o��;
		private static Encoding enc = Encoding.GetEncoding("shift-jis");
// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� END
// MOD 2010.04.21 ���s�j���� �n���O�ߎ�����̖h�~ START
		private string[]    sFiles1;
		private DateTime[] dtFiles1;
		private long[]     lsFiles1;
		public  Thread     trd1 = null;
// MOD 2010.04.21 ���s�j���� �n���O�ߎ�����̖h�~ END
// MOD 2010.05.25 ���s�j���� ���b�Z�[�W�̃X���b�h�� START
		public  Thread     trdMsg = null;
// MOD 2010.05.25 ���s�j���� ���b�Z�[�W�̃X���b�h�� END
// MOD 2011.10.11 ���s�j���� �r�r�k�ؖ���������ԂȂǂ̃`�F�b�N START
		public static Thread  trdSSLTest = null;
// MOD 2011.10.11 ���s�j���� �r�r�k�ؖ���������ԂȂǂ̃`�F�b�N END

		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab����;
		private System.Windows.Forms.Button btn�p�X���[�h�ύX;
		private System.Windows.Forms.Button btn�I��;
		private System.Windows.Forms.TextBox tex���喼;
		private System.Windows.Forms.TextBox tex���b�Z�[�W;
		private System.Windows.Forms.Button btn����ύX;
		private System.Windows.Forms.PictureBox pic�o�׏Ɖ�;
		private System.Windows.Forms.PictureBox pic������o�^;
		private System.Windows.Forms.PictureBox pic�[�����;
		private System.Windows.Forms.PictureBox pic�L�����;
		private System.Windows.Forms.PictureBox pic���˗�����;
		private System.Windows.Forms.PictureBox pic���˗���捞;
		private System.Windows.Forms.PictureBox pic���͂�����;
		private System.Windows.Forms.PictureBox pic���j���[�S;
		private System.Windows.Forms.PictureBox pic���j���[�R;
		private System.Windows.Forms.PictureBox pic���j���[�Q;
		private System.Windows.Forms.PictureBox pic���j���[�P;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pic�����׎D���s;
		private System.Windows.Forms.PictureBox pic���^�o�דo�^;
		private System.Windows.Forms.PictureBox pic�����o�דo�^;
		private System.Windows.Forms.PictureBox pictureBox7;
		private System.Windows.Forms.PictureBox pic�o�דo�^;
		private System.Windows.Forms.PictureBox pic���͐�捞;
		private System.Windows.Forms.Panel pan���C��;
		private System.Windows.Forms.Panel pan���j���[�P;
		private System.Windows.Forms.Panel pan���j���[�Q;
		private System.Windows.Forms.Panel pan���j���[�R;
		private System.Windows.Forms.Panel pan���j���[�S;
		private System.Drawing.Printing.PrintDocument is2PrintDocument;
		private System.Windows.Forms.Label lab���b�Z�[�W;
		private System.Windows.Forms.PictureBox pic�`���C�X�v�����g;
		private System.Windows.Forms.PictureBox pic�Ĕ��s;
		private System.Windows.Forms.Button btn�w���v;
		private System.Windows.Forms.PictureBox pic�ː��ؑ�;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tex�����;
		private System.Windows.Forms.PictureBox pic�o�׎���;
		private System.Windows.Forms.Label lab���b�Z�[�W��;
		private System.Windows.Forms.PictureBox pic�z�[��;
		private System.Windows.Forms.Label lab�o�[�W����;
		private System.Windows.Forms.PictureBox pic���j���[�U;
		private System.Windows.Forms.Panel pan���j���[�U;
		private IS2Client.���m�点�\��{�^�� btn���m�点�P;
		private IS2Client.���m�点�\��{�^�� btn���m�点�Q;
		private IS2Client.���m�点�\��{�^�� btn���m�点�R;
		private IS2Client.���m�点�\��{�^�� btn���m�点�S;
		private IS2Client.���m�点�\��{�^�� btn���m�点�T;
		private System.Windows.Forms.Label lab�����o�͂n�m;
		private System.Windows.Forms.Button btn�����o�̓t�H���_;
		private System.Windows.Forms.Button btn�����o��;
		private System.Windows.Forms.Label lbl���q�^��;
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� START
		private System.Windows.Forms.PictureBox pic�o�[�R�[�h�ǎ�;
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� END
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� START
		private System.Windows.Forms.PictureBox pic���x���C���[�W���;
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� END
		private System.ComponentModel.IContainer components;

		public ���j���[()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
			�c�o�h�\���T�C�Y�ϊ�();
			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
				this.pictureBox7.Size = new System.Drawing.Size(162, 418);
				this.pic���j���[�P.Size = new System.Drawing.Size(128, 33);
				this.pic���j���[�Q.Size = new System.Drawing.Size(128, 33);
				this.pic���j���[�R.Size = new System.Drawing.Size(128, 33);
				this.pic���j���[�S.Size = new System.Drawing.Size(128, 33);
				this.pic���j���[�U.Size = new System.Drawing.Size(128, 33);
// MOD 2010.05.24 ���s�j���� 120DPI�Ή����̕\���ʒu���� START
//				this.Top  = 0;
//				this.Left = 0;
//				this.Left = 15;
//				this.Left = (SystemInformation.WorkingArea.Width
//								- this.Width) / 2;
				//�Q�l�l�FSystem.Drawing.Size(800, 607);
				this.Top  = (SystemInformation.WorkingArea.Height
								- �c�o�h�T�C�Y�ʒu����(607, giDisplayDpiY)) / 2;
				this.Left = (SystemInformation.WorkingArea.Width
								- �c�o�h�T�C�Y�ʒu����(800, giDisplayDpiX)) / 2;
				this.Top  = �c�o�h�T�C�Y�ʒu����(this.Top, giDisplayDpiY);
				this.Left = �c�o�h�T�C�Y�ʒu����(this.Left, giDisplayDpiX);
// MOD 2010.05.24 ���s�j���� 120DPI�Ή����̕\���ʒu���� END
			}
// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� END
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
			// �����ݒ�
			this.���m�点�����ݒ�();
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
		}

		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );

// MOD 2009.07.30 ���s�j���� exe��dll���Ή� START
//			// �~���[�e�b�N�X�̔j��
//			mutex.Close();
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� END
		}

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(���j���[));
			this.panel7 = new System.Windows.Forms.Panel();
			this.pic�z�[�� = new System.Windows.Forms.PictureBox();
			this.lab���� = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.tex����� = new System.Windows.Forms.TextBox();
			this.panel6 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.btn�w���v = new System.Windows.Forms.Button();
			this.tex���喼 = new System.Windows.Forms.TextBox();
			this.btn����ύX = new System.Windows.Forms.Button();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn�����o�̓t�H���_ = new System.Windows.Forms.Button();
			this.btn�����o�� = new System.Windows.Forms.Button();
			this.btn�p�X���[�h�ύX = new System.Windows.Forms.Button();
			this.tex���b�Z�[�W = new System.Windows.Forms.TextBox();
			this.btn�I�� = new System.Windows.Forms.Button();
			this.lab�����o�͂n�m = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.pic���͂����� = new System.Windows.Forms.PictureBox();
			this.pic���˗����� = new System.Windows.Forms.PictureBox();
			this.pic���˗���捞 = new System.Windows.Forms.PictureBox();
			this.pic�L����� = new System.Windows.Forms.PictureBox();
			this.pic�[����� = new System.Windows.Forms.PictureBox();
			this.pic������o�^ = new System.Windows.Forms.PictureBox();
			this.pic�o�׏Ɖ� = new System.Windows.Forms.PictureBox();
			this.pan���C�� = new System.Windows.Forms.Panel();
			this.lbl���q�^�� = new System.Windows.Forms.Label();
			this.pan���j���[�U = new System.Windows.Forms.Panel();
			this.btn���m�点�P = new IS2Client.���m�点�\��{�^��();
			this.btn���m�点�T = new IS2Client.���m�点�\��{�^��();
			this.btn���m�点�S = new IS2Client.���m�点�\��{�^��();
			this.btn���m�点�R = new IS2Client.���m�点�\��{�^��();
			this.btn���m�点�Q = new IS2Client.���m�点�\��{�^��();
			this.pic���j���[�U = new System.Windows.Forms.PictureBox();
			this.lab�o�[�W���� = new System.Windows.Forms.Label();
			this.pic���j���[�S = new System.Windows.Forms.PictureBox();
			this.pic���j���[�R = new System.Windows.Forms.PictureBox();
			this.pic���j���[�Q = new System.Windows.Forms.PictureBox();
			this.pic���j���[�P = new System.Windows.Forms.PictureBox();
			this.pan���j���[�S = new System.Windows.Forms.Panel();
			this.pic�ː��ؑ� = new System.Windows.Forms.PictureBox();
			this.pan���j���[�R = new System.Windows.Forms.Panel();
			this.pic���͐�捞 = new System.Windows.Forms.PictureBox();
			this.pan���j���[�P = new System.Windows.Forms.Panel();
			this.pic�`���C�X�v�����g = new System.Windows.Forms.PictureBox();
			this.pic�����׎D���s = new System.Windows.Forms.PictureBox();
			this.pic���^�o�דo�^ = new System.Windows.Forms.PictureBox();
			this.pic�o�דo�^ = new System.Windows.Forms.PictureBox();
			this.pic�����o�דo�^ = new System.Windows.Forms.PictureBox();
			this.pan���j���[�Q = new System.Windows.Forms.Panel();
			this.pic�o�׎��� = new System.Windows.Forms.PictureBox();
			this.pic�Ĕ��s = new System.Windows.Forms.PictureBox();
			this.pic�o�[�R�[�h�ǎ� = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox7 = new System.Windows.Forms.PictureBox();
			this.lab���b�Z�[�W = new System.Windows.Forms.Label();
			this.lab���b�Z�[�W�� = new System.Windows.Forms.Label();
			this.is2PrintDocument = new System.Drawing.Printing.PrintDocument();
			this.pic���x���C���[�W��� = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).BeginInit();
			this.panel7.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel8.SuspendLayout();
			this.pan���C��.SuspendLayout();
			this.pan���j���[�U.SuspendLayout();
			this.pan���j���[�S.SuspendLayout();
			this.pan���j���[�R.SuspendLayout();
			this.pan���j���[�P.SuspendLayout();
			this.pan���j���[�Q.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.pic�z�[��);
			this.panel7.Controls.Add(this.lab����);
			this.panel7.Controls.Add(this.label29);
			this.panel7.Controls.Add(this.tex�����);
			this.panel7.Location = new System.Drawing.Point(0, -2);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(792, 26);
			this.panel7.TabIndex = 15;
			// 
			// pic�z�[��
			// 
			this.pic�z�[��.Image = ((System.Drawing.Image)(resources.GetObject("pic�z�[��.Image")));
			this.pic�z�[��.Location = new System.Drawing.Point(8, 4);
			this.pic�z�[��.Name = "pic�z�[��";
			this.pic�z�[��.Size = new System.Drawing.Size(22, 22);
			this.pic�z�[��.TabIndex = 2;
			this.pic�z�[��.TabStop = false;
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
			// label29
			// 
			this.label29.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label29.Font = new System.Drawing.Font("MS UI Gothic", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label29.ForeColor = System.Drawing.Color.White;
			this.label29.Location = new System.Drawing.Point(32, 6);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(76, 24);
			this.label29.TabIndex = 0;
			this.label29.Text = "Home";
			// 
			// tex�����
			// 
			this.tex�����.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.tex�����.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex�����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�����.ForeColor = System.Drawing.Color.SeaGreen;
			this.tex�����.Location = new System.Drawing.Point(118, 8);
			this.tex�����.Name = "tex�����";
			this.tex�����.ReadOnly = true;
			this.tex�����.Size = new System.Drawing.Size(536, 16);
			this.tex�����.TabIndex = 13;
			this.tex�����.TabStop = false;
			this.tex�����.Text = "����������������������������������������";
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.PaleGreen;
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.btn�w���v);
			this.panel6.Controls.Add(this.tex���喼);
			this.panel6.Controls.Add(this.btn����ύX);
			this.panel6.Location = new System.Drawing.Point(-2, 24);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(810, 26);
			this.panel6.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label1.ForeColor = System.Drawing.Color.LimeGreen;
			this.label1.Location = new System.Drawing.Point(12, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 16);
			this.label1.TabIndex = 12;
			this.label1.Text = "�Z�N�V����";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn�w���v
			// 
			this.btn�w���v.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�w���v.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�w���v.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�w���v.ForeColor = System.Drawing.Color.White;
			this.btn�w���v.Location = new System.Drawing.Point(714, 2);
			this.btn�w���v.Name = "btn�w���v";
			this.btn�w���v.Size = new System.Drawing.Size(70, 22);
			this.btn�w���v.TabIndex = 11;
			this.btn�w���v.Text = "�w���v";
			this.btn�w���v.Click += new System.EventHandler(this.btn�w���v_Click);
			// 
			// tex���喼
			// 
			this.tex���喼.BackColor = System.Drawing.Color.PaleGreen;
			this.tex���喼.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex���喼.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���喼.ForeColor = System.Drawing.Color.LimeGreen;
			this.tex���喼.Location = new System.Drawing.Point(74, 6);
			this.tex���喼.Name = "tex���喼";
			this.tex���喼.ReadOnly = true;
			this.tex���喼.Size = new System.Drawing.Size(540, 16);
			this.tex���喼.TabIndex = 8;
			this.tex���喼.TabStop = false;
			this.tex���喼.Text = "��������������������";
			// 
			// btn����ύX
			// 
			this.btn����ύX.BackColor = System.Drawing.Color.SteelBlue;
			this.btn����ύX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn����ύX.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn����ύX.ForeColor = System.Drawing.Color.White;
			this.btn����ύX.Location = new System.Drawing.Point(626, 2);
			this.btn����ύX.Name = "btn����ύX";
			this.btn����ύX.Size = new System.Drawing.Size(84, 22);
			this.btn����ύX.TabIndex = 9;
			this.btn����ύX.Text = "�Z�N�V�����ύX";
			this.btn����ύX.Click += new System.EventHandler(this.btn����ύX_Click);
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn�����o�̓t�H���_);
			this.panel8.Controls.Add(this.btn�����o��);
			this.panel8.Controls.Add(this.btn�p�X���[�h�ύX);
			this.panel8.Controls.Add(this.tex���b�Z�[�W);
			this.panel8.Controls.Add(this.btn�I��);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 2;
			// 
			// btn�����o�̓t�H���_
			// 
			this.btn�����o�̓t�H���_.BackColor = System.Drawing.Color.PaleGreen;
			this.btn�����o�̓t�H���_.ForeColor = System.Drawing.Color.Blue;
			this.btn�����o�̓t�H���_.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�����o�̓t�H���_.Location = new System.Drawing.Point(238, 6);
			this.btn�����o�̓t�H���_.Name = "btn�����o�̓t�H���_";
			this.btn�����o�̓t�H���_.Size = new System.Drawing.Size(62, 48);
			this.btn�����o�̓t�H���_.TabIndex = 12;
			this.btn�����o�̓t�H���_.Text = "�����o�� �t�H���_ �\��";
			this.btn�����o�̓t�H���_.Click += new System.EventHandler(this.btn�����o�̓t�H���__Click);
			// 
			// btn�����o��
			// 
			this.btn�����o��.BackColor = System.Drawing.Color.PaleGreen;
			this.btn�����o��.ForeColor = System.Drawing.Color.Blue;
			this.btn�����o��.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�����o��.Location = new System.Drawing.Point(168, 6);
			this.btn�����o��.Name = "btn�����o��";
			this.btn�����o��.Size = new System.Drawing.Size(62, 48);
			this.btn�����o��.TabIndex = 11;
			this.btn�����o��.Text = "�����o�� ON";
			this.btn�����o��.Click += new System.EventHandler(this.btn�����o��_Click);
			// 
			// btn�p�X���[�h�ύX
			// 
			this.btn�p�X���[�h�ύX.ForeColor = System.Drawing.Color.Blue;
			this.btn�p�X���[�h�ύX.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�p�X���[�h�ύX.Location = new System.Drawing.Point(98, 6);
			this.btn�p�X���[�h�ύX.Name = "btn�p�X���[�h�ύX";
			this.btn�p�X���[�h�ύX.Size = new System.Drawing.Size(62, 48);
			this.btn�p�X���[�h�ύX.TabIndex = 1;
			this.btn�p�X���[�h�ύX.Text = "�p�X���[�h�ύX";
			this.btn�p�X���[�h�ύX.Click += new System.EventHandler(this.btn�p�X���[�h�ύX_Click);
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
			// btn�I��
			// 
			this.btn�I��.ForeColor = System.Drawing.Color.Red;
			this.btn�I��.Location = new System.Drawing.Point(8, 6);
			this.btn�I��.Name = "btn�I��";
			this.btn�I��.Size = new System.Drawing.Size(54, 48);
			this.btn�I��.TabIndex = 0;
			this.btn�I��.TabStop = false;
			this.btn�I��.Text = "�I��";
			this.btn�I��.Click += new System.EventHandler(this.btn�I��_Click);
			// 
			// lab�����o�͂n�m
			// 
			this.lab�����o�͂n�m.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(101)), ((System.Byte)(255)));
			this.lab�����o�͂n�m.Font = new System.Drawing.Font("HG�ۺ޼��M-PRO", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�����o�͂n�m.ForeColor = System.Drawing.Color.White;
			this.lab�����o�͂n�m.Location = new System.Drawing.Point(0, 398);
			this.lab�����o�͂n�m.Name = "lab�����o�͂n�m";
			this.lab�����o�͂n�m.Size = new System.Drawing.Size(160, 42);
			this.lab�����o�͂n�m.TabIndex = 3;
			this.lab�����o�͂n�m.Text = "�����o�͂n�m";
			this.lab�����o�͂n�m.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// pic���͂�����
			// 
			this.pic���͂�����.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic���͂�����.Location = new System.Drawing.Point(16, 16);
			this.pic���͂�����.Name = "pic���͂�����";
			this.pic���͂�����.Size = new System.Drawing.Size(482, 42);
			this.pic���͂�����.TabIndex = 22;
			this.pic���͂�����.TabStop = false;
			this.pic���͂�����.Click += new System.EventHandler(this.pic���͂�����_Click);
			this.pic���͂�����.MouseEnter += new System.EventHandler(this.pic���͂�����_MouseEnter);
			this.pic���͂�����.MouseLeave += new System.EventHandler(this.pic���͂�����_MouseLeave);
			// 
			// pic���˗�����
			// 
			this.pic���˗�����.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic���˗�����.Location = new System.Drawing.Point(16, 144);
			this.pic���˗�����.Name = "pic���˗�����";
			this.pic���˗�����.Size = new System.Drawing.Size(482, 42);
			this.pic���˗�����.TabIndex = 23;
			this.pic���˗�����.TabStop = false;
			this.pic���˗�����.Click += new System.EventHandler(this.pic���˗�����_Click);
			this.pic���˗�����.MouseEnter += new System.EventHandler(this.pic���˗�����_MouseEnter);
			this.pic���˗�����.MouseLeave += new System.EventHandler(this.pic���˗�����_MouseLeave);
			// 
			// pic���˗���捞
			// 
			this.pic���˗���捞.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic���˗���捞.Location = new System.Drawing.Point(16, 208);
			this.pic���˗���捞.Name = "pic���˗���捞";
			this.pic���˗���捞.Size = new System.Drawing.Size(482, 42);
			this.pic���˗���捞.TabIndex = 23;
			this.pic���˗���捞.TabStop = false;
			this.pic���˗���捞.Click += new System.EventHandler(this.pic���˗���捞_Click);
			this.pic���˗���捞.MouseEnter += new System.EventHandler(this.pic���˗���捞_MouseEnter);
			this.pic���˗���捞.MouseLeave += new System.EventHandler(this.pic���˗���捞_MouseLeave);
			// 
			// pic�L�����
			// 
			this.pic�L�����.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic�L�����.Location = new System.Drawing.Point(16, 16);
			this.pic�L�����.Name = "pic�L�����";
			this.pic�L�����.Size = new System.Drawing.Size(482, 42);
			this.pic�L�����.TabIndex = 24;
			this.pic�L�����.TabStop = false;
			this.pic�L�����.Click += new System.EventHandler(this.pic�L�����_Click);
			this.pic�L�����.MouseEnter += new System.EventHandler(this.pic�L�����_MouseEnter);
			this.pic�L�����.MouseLeave += new System.EventHandler(this.pic�L�����_MouseLeave);
			// 
			// pic�[�����
			// 
			this.pic�[�����.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic�[�����.Location = new System.Drawing.Point(16, 144);
			this.pic�[�����.Name = "pic�[�����";
			this.pic�[�����.Size = new System.Drawing.Size(482, 42);
			this.pic�[�����.TabIndex = 24;
			this.pic�[�����.TabStop = false;
			this.pic�[�����.Click += new System.EventHandler(this.pic�[�����_Click);
			this.pic�[�����.MouseEnter += new System.EventHandler(this.pic�[�����_MouseEnter);
			this.pic�[�����.MouseLeave += new System.EventHandler(this.pic�[�����_MouseLeave);
			// 
			// pic������o�^
			// 
			this.pic������o�^.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic������o�^.Location = new System.Drawing.Point(16, 80);
			this.pic������o�^.Name = "pic������o�^";
			this.pic������o�^.Size = new System.Drawing.Size(482, 42);
			this.pic������o�^.TabIndex = 24;
			this.pic������o�^.TabStop = false;
			this.pic������o�^.Click += new System.EventHandler(this.pic������o�^_Click);
			this.pic������o�^.MouseEnter += new System.EventHandler(this.pic������o�^_MouseEnter);
			this.pic������o�^.MouseLeave += new System.EventHandler(this.pic������o�^_MouseLeave);
			// 
			// pic�o�׏Ɖ�
			// 
			this.pic�o�׏Ɖ�.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic�o�׏Ɖ�.Location = new System.Drawing.Point(16, 16);
			this.pic�o�׏Ɖ�.Name = "pic�o�׏Ɖ�";
			this.pic�o�׏Ɖ�.Size = new System.Drawing.Size(482, 42);
			this.pic�o�׏Ɖ�.TabIndex = 22;
			this.pic�o�׏Ɖ�.TabStop = false;
			this.pic�o�׏Ɖ�.Click += new System.EventHandler(this.pic�o�׏Ɖ�_Click);
			this.pic�o�׏Ɖ�.MouseEnter += new System.EventHandler(this.pic�o�׏Ɖ�_MouseEnter);
			this.pic�o�׏Ɖ�.MouseLeave += new System.EventHandler(this.pic�o�׏Ɖ�_MouseLeave);
			// 
			// pan���C��
			// 
			this.pan���C��.Controls.Add(this.lbl���q�^��);
			this.pan���C��.Controls.Add(this.pan���j���[�U);
			this.pan���C��.Controls.Add(this.lab�����o�͂n�m);
			this.pan���C��.Controls.Add(this.pic���j���[�U);
			this.pan���C��.Controls.Add(this.lab�o�[�W����);
			this.pan���C��.Controls.Add(this.pic���j���[�S);
			this.pan���C��.Controls.Add(this.pic���j���[�R);
			this.pan���C��.Controls.Add(this.pic���j���[�Q);
			this.pan���C��.Controls.Add(this.pic���j���[�P);
			this.pan���C��.Controls.Add(this.pan���j���[�S);
			this.pan���C��.Controls.Add(this.pan���j���[�R);
			this.pan���C��.Controls.Add(this.pan���j���[�P);
			this.pan���C��.Controls.Add(this.pan���j���[�Q);
			this.pan���C��.Controls.Add(this.pictureBox2);
			this.pan���C��.Controls.Add(this.pictureBox7);
			this.pan���C��.Controls.Add(this.lab���b�Z�[�W);
			this.pan���C��.Controls.Add(this.lab���b�Z�[�W��);
			this.pan���C��.Location = new System.Drawing.Point(0, 52);
			this.pan���C��.Name = "pan���C��";
			this.pan���C��.Size = new System.Drawing.Size(784, 458);
			this.pan���C��.TabIndex = 20;
			// 
			// lbl���q�^��
			// 
			this.lbl���q�^��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(255)));
			this.lbl���q�^��.Font = new System.Drawing.Font("Arial Black", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbl���q�^��.ForeColor = System.Drawing.Color.White;
			this.lbl���q�^��.Location = new System.Drawing.Point(474, 10);
			this.lbl���q�^��.Name = "lbl���q�^��";
			this.lbl���q�^��.Size = new System.Drawing.Size(202, 48);
			this.lbl���q�^��.TabIndex = 40;
			this.lbl���q�^��.Text = "���q�^��";
			// 
			// pan���j���[�U
			// 
			this.pan���j���[�U.Controls.Add(this.btn���m�点�P);
			this.pan���j���[�U.Controls.Add(this.btn���m�点�T);
			this.pan���j���[�U.Controls.Add(this.btn���m�点�S);
			this.pan���j���[�U.Controls.Add(this.btn���m�点�R);
			this.pan���j���[�U.Controls.Add(this.btn���m�点�Q);
			this.pan���j���[�U.Location = new System.Drawing.Point(184, 82);
			this.pan���j���[�U.Name = "pan���j���[�U";
			this.pan���j���[�U.Size = new System.Drawing.Size(544, 338);
			this.pan���j���[�U.TabIndex = 38;
			// 
			// btn���m�点�P
			// 
			this.btn���m�点�P.Location = new System.Drawing.Point(16, 16);
			this.btn���m�点�P.Name = "btn���m�点�P";
			this.btn���m�点�P.Size = new System.Drawing.Size(482, 42);
			this.btn���m�点�P.TabIndex = 26;
			this.btn���m�点�P.Visible = false;
			this.btn���m�点�P.ButtonClicked += new System.EventHandler(this.pic���m�点�P_Click);
			// 
			// btn���m�点�T
			// 
			this.btn���m�点�T.Location = new System.Drawing.Point(16, 272);
			this.btn���m�点�T.Name = "btn���m�点�T";
			this.btn���m�点�T.Size = new System.Drawing.Size(482, 42);
			this.btn���m�点�T.TabIndex = 29;
			this.btn���m�点�T.Visible = false;
			this.btn���m�点�T.ButtonClicked += new System.EventHandler(this.pic���m�点�T_Click);
			// 
			// btn���m�点�S
			// 
			this.btn���m�点�S.Location = new System.Drawing.Point(16, 208);
			this.btn���m�点�S.Name = "btn���m�点�S";
			this.btn���m�点�S.Size = new System.Drawing.Size(482, 42);
			this.btn���m�点�S.TabIndex = 28;
			this.btn���m�点�S.Visible = false;
			this.btn���m�点�S.ButtonClicked += new System.EventHandler(this.pic���m�点�S_Click);
			// 
			// btn���m�点�R
			// 
			this.btn���m�点�R.Location = new System.Drawing.Point(16, 144);
			this.btn���m�点�R.Name = "btn���m�点�R";
			this.btn���m�点�R.Size = new System.Drawing.Size(482, 42);
			this.btn���m�点�R.TabIndex = 27;
			this.btn���m�点�R.Visible = false;
			this.btn���m�点�R.ButtonClicked += new System.EventHandler(this.pic���m�点�R_Click);
			// 
			// btn���m�点�Q
			// 
			this.btn���m�点�Q.Location = new System.Drawing.Point(16, 80);
			this.btn���m�点�Q.Name = "btn���m�点�Q";
			this.btn���m�点�Q.Size = new System.Drawing.Size(482, 42);
			this.btn���m�点�Q.TabIndex = 26;
			this.btn���m�点�Q.Visible = false;
			this.btn���m�点�Q.ButtonClicked += new System.EventHandler(this.pic���m�点�Q_Click);
			// 
			// pic���j���[�U
			// 
			this.pic���j���[�U.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(255)));
			this.pic���j���[�U.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic���j���[�U.Location = new System.Drawing.Point(0, 354);
			this.pic���j���[�U.Name = "pic���j���[�U";
			this.pic���j���[�U.Size = new System.Drawing.Size(162, 42);
			this.pic���j���[�U.TabIndex = 39;
			this.pic���j���[�U.TabStop = false;
			this.pic���j���[�U.Click += new System.EventHandler(this.pic���j���[�U_Click);
			this.pic���j���[�U.MouseEnter += new System.EventHandler(this.pic���j���[�U_MouseEnter);
			this.pic���j���[�U.MouseLeave += new System.EventHandler(this.pic���j���[�U_MouseLeave);
			// 
			// lab�o�[�W����
			// 
			this.lab�o�[�W����.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(101)), ((System.Byte)(255)));
			this.lab�o�[�W����.ForeColor = System.Drawing.Color.White;
			this.lab�o�[�W����.Location = new System.Drawing.Point(704, 16);
			this.lab�o�[�W����.Name = "lab�o�[�W����";
			this.lab�o�[�W����.Size = new System.Drawing.Size(60, 12);
			this.lab�o�[�W����.TabIndex = 38;
			this.lab�o�[�W����.Text = "Ver.1.9";
			// 
			// pic���j���[�S
			// 
			this.pic���j���[�S.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(255)));
			this.pic���j���[�S.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic���j���[�S.Location = new System.Drawing.Point(0, 228);
			this.pic���j���[�S.Name = "pic���j���[�S";
			this.pic���j���[�S.Size = new System.Drawing.Size(162, 42);
			this.pic���j���[�S.TabIndex = 31;
			this.pic���j���[�S.TabStop = false;
			this.pic���j���[�S.Click += new System.EventHandler(this.pic���j���[�S_Click);
			this.pic���j���[�S.MouseEnter += new System.EventHandler(this.pic���j���[�S_MouseEnter);
			this.pic���j���[�S.MouseLeave += new System.EventHandler(this.pic���j���[�S_MouseLeave);
			// 
			// pic���j���[�R
			// 
			this.pic���j���[�R.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(255)));
			this.pic���j���[�R.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic���j���[�R.Location = new System.Drawing.Point(0, 186);
			this.pic���j���[�R.Name = "pic���j���[�R";
			this.pic���j���[�R.Size = new System.Drawing.Size(162, 42);
			this.pic���j���[�R.TabIndex = 30;
			this.pic���j���[�R.TabStop = false;
			this.pic���j���[�R.Click += new System.EventHandler(this.pic���j���[�R_Click);
			this.pic���j���[�R.MouseEnter += new System.EventHandler(this.pic���j���[�R_MouseEnter);
			this.pic���j���[�R.MouseLeave += new System.EventHandler(this.pic���j���[�R_MouseLeave);
			// 
			// pic���j���[�Q
			// 
			this.pic���j���[�Q.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(255)));
			this.pic���j���[�Q.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic���j���[�Q.Location = new System.Drawing.Point(0, 144);
			this.pic���j���[�Q.Name = "pic���j���[�Q";
			this.pic���j���[�Q.Size = new System.Drawing.Size(162, 42);
			this.pic���j���[�Q.TabIndex = 29;
			this.pic���j���[�Q.TabStop = false;
			this.pic���j���[�Q.Click += new System.EventHandler(this.pic���j���[�Q_Click);
			this.pic���j���[�Q.MouseEnter += new System.EventHandler(this.pic���j���[�Q_MouseEnter);
			this.pic���j���[�Q.MouseLeave += new System.EventHandler(this.pic���j���[�Q_MouseLeave);
			// 
			// pic���j���[�P
			// 
			this.pic���j���[�P.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(255)));
			this.pic���j���[�P.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic���j���[�P.Location = new System.Drawing.Point(0, 102);
			this.pic���j���[�P.Name = "pic���j���[�P";
			this.pic���j���[�P.Size = new System.Drawing.Size(162, 42);
			this.pic���j���[�P.TabIndex = 28;
			this.pic���j���[�P.TabStop = false;
			this.pic���j���[�P.Click += new System.EventHandler(this.pic���j���[�P_Click);
			this.pic���j���[�P.MouseEnter += new System.EventHandler(this.pic���j���[�P_MouseEnter);
			this.pic���j���[�P.MouseLeave += new System.EventHandler(this.pic���j���[�P_MouseLeave);
			// 
			// pan���j���[�S
			// 
			this.pan���j���[�S.Controls.Add(this.pic������o�^);
			this.pan���j���[�S.Controls.Add(this.pic�L�����);
			this.pan���j���[�S.Controls.Add(this.pic�[�����);
			this.pan���j���[�S.Controls.Add(this.pic�ː��ؑ�);
			this.pan���j���[�S.Location = new System.Drawing.Point(184, 82);
			this.pan���j���[�S.Name = "pan���j���[�S";
			this.pan���j���[�S.Size = new System.Drawing.Size(544, 338);
			this.pan���j���[�S.TabIndex = 33;
			// 
			// pic�ː��ؑ�
			// 
			this.pic�ː��ؑ�.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic�ː��ؑ�.Location = new System.Drawing.Point(16, 208);
			this.pic�ː��ؑ�.Name = "pic�ː��ؑ�";
			this.pic�ː��ؑ�.Size = new System.Drawing.Size(482, 42);
			this.pic�ː��ؑ�.TabIndex = 25;
			this.pic�ː��ؑ�.TabStop = false;
			this.pic�ː��ؑ�.Click += new System.EventHandler(this.pic�ː��ؑ�_Click);
			this.pic�ː��ؑ�.MouseEnter += new System.EventHandler(this.pic�ː��ؑ�_MouseEnter);
			this.pic�ː��ؑ�.MouseLeave += new System.EventHandler(this.pic�ː��ؑ�_MouseLeave);
			// 
			// pan���j���[�R
			// 
			this.pan���j���[�R.Controls.Add(this.pic���͂�����);
			this.pan���j���[�R.Controls.Add(this.pic���˗�����);
			this.pan���j���[�R.Controls.Add(this.pic���˗���捞);
			this.pan���j���[�R.Controls.Add(this.pic���͐�捞);
			this.pan���j���[�R.Location = new System.Drawing.Point(184, 82);
			this.pan���j���[�R.Name = "pan���j���[�R";
			this.pan���j���[�R.Size = new System.Drawing.Size(544, 338);
			this.pan���j���[�R.TabIndex = 33;
			// 
			// pic���͐�捞
			// 
			this.pic���͐�捞.BackColor = System.Drawing.Color.Transparent;
			this.pic���͐�捞.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic���͐�捞.Location = new System.Drawing.Point(16, 80);
			this.pic���͐�捞.Name = "pic���͐�捞";
			this.pic���͐�捞.Size = new System.Drawing.Size(482, 42);
			this.pic���͐�捞.TabIndex = 22;
			this.pic���͐�捞.TabStop = false;
			this.pic���͐�捞.Click += new System.EventHandler(this.pic���͐�捞_Click);
			this.pic���͐�捞.MouseEnter += new System.EventHandler(this.pic���͐�捞_MouseEnter);
			this.pic���͐�捞.MouseLeave += new System.EventHandler(this.pic���͐�捞_MouseLeave);
			// 
			// pan���j���[�P
			// 
			this.pan���j���[�P.Controls.Add(this.pic�`���C�X�v�����g);
			this.pan���j���[�P.Controls.Add(this.pic�����׎D���s);
			this.pan���j���[�P.Controls.Add(this.pic���^�o�דo�^);
			this.pan���j���[�P.Controls.Add(this.pic�o�דo�^);
			this.pan���j���[�P.Controls.Add(this.pic�����o�דo�^);
			this.pan���j���[�P.Location = new System.Drawing.Point(184, 82);
			this.pan���j���[�P.Name = "pan���j���[�P";
			this.pan���j���[�P.Size = new System.Drawing.Size(544, 338);
			this.pan���j���[�P.TabIndex = 33;
			// 
			// pic�`���C�X�v�����g
			// 
			this.pic�`���C�X�v�����g.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic�`���C�X�v�����g.Location = new System.Drawing.Point(16, 272);
			this.pic�`���C�X�v�����g.Name = "pic�`���C�X�v�����g";
			this.pic�`���C�X�v�����g.Size = new System.Drawing.Size(482, 42);
			this.pic�`���C�X�v�����g.TabIndex = 25;
			this.pic�`���C�X�v�����g.TabStop = false;
			this.pic�`���C�X�v�����g.Click += new System.EventHandler(this.pic�`���C�X�v�����g_Click);
			this.pic�`���C�X�v�����g.MouseEnter += new System.EventHandler(this.pic�`���C�X�v�����g_MouseEnter);
			this.pic�`���C�X�v�����g.MouseLeave += new System.EventHandler(this.pic�`���C�X�v�����g_MouseLeave);
			// 
			// pic�����׎D���s
			// 
			this.pic�����׎D���s.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic�����׎D���s.Location = new System.Drawing.Point(16, 208);
			this.pic�����׎D���s.Name = "pic�����׎D���s";
			this.pic�����׎D���s.Size = new System.Drawing.Size(482, 42);
			this.pic�����׎D���s.TabIndex = 24;
			this.pic�����׎D���s.TabStop = false;
			this.pic�����׎D���s.Click += new System.EventHandler(this.pic�����׎D���s_Click);
			this.pic�����׎D���s.MouseEnter += new System.EventHandler(this.pic�����׎D���s_MouseEnter);
			this.pic�����׎D���s.MouseLeave += new System.EventHandler(this.pic�����׎D���s_MouseLeave);
			// 
			// pic���^�o�דo�^
			// 
			this.pic���^�o�דo�^.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic���^�o�דo�^.Location = new System.Drawing.Point(16, 80);
			this.pic���^�o�דo�^.Name = "pic���^�o�דo�^";
			this.pic���^�o�דo�^.Size = new System.Drawing.Size(482, 42);
			this.pic���^�o�דo�^.TabIndex = 23;
			this.pic���^�o�דo�^.TabStop = false;
			this.pic���^�o�דo�^.Click += new System.EventHandler(this.pic���^�o�דo�^_Click);
			this.pic���^�o�דo�^.MouseEnter += new System.EventHandler(this.pic���^�o�דo�^_MouseEnter);
			this.pic���^�o�דo�^.MouseLeave += new System.EventHandler(this.pic���^�o�דo�^_MouseLeave);
			// 
			// pic�o�דo�^
			// 
			this.pic�o�דo�^.BackColor = System.Drawing.Color.Transparent;
			this.pic�o�דo�^.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic�o�דo�^.Location = new System.Drawing.Point(16, 16);
			this.pic�o�דo�^.Name = "pic�o�דo�^";
			this.pic�o�דo�^.Size = new System.Drawing.Size(482, 42);
			this.pic�o�דo�^.TabIndex = 22;
			this.pic�o�דo�^.TabStop = false;
			this.pic�o�דo�^.Click += new System.EventHandler(this.pic�o�דo�^_Click);
			this.pic�o�דo�^.MouseEnter += new System.EventHandler(this.pic�o�דo�^_MouseEnter);
			this.pic�o�דo�^.MouseLeave += new System.EventHandler(this.pic�o�דo�^_MouseLeave);
			// 
			// pic�����o�דo�^
			// 
			this.pic�����o�דo�^.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic�����o�דo�^.Location = new System.Drawing.Point(16, 144);
			this.pic�����o�דo�^.Name = "pic�����o�דo�^";
			this.pic�����o�דo�^.Size = new System.Drawing.Size(482, 42);
			this.pic�����o�דo�^.TabIndex = 23;
			this.pic�����o�דo�^.TabStop = false;
			this.pic�����o�דo�^.Click += new System.EventHandler(this.pic�����o�דo�^_Click);
			this.pic�����o�דo�^.MouseEnter += new System.EventHandler(this.pic�����o�דo�^_MouseEnter);
			this.pic�����o�דo�^.MouseLeave += new System.EventHandler(this.pic�����o�דo�^_MouseLeave);
			// 
			// pan���j���[�Q
			// 
			this.pan���j���[�Q.Controls.Add(this.pic���x���C���[�W���);
			this.pan���j���[�Q.Controls.Add(this.pic�o�׎���);
			this.pan���j���[�Q.Controls.Add(this.pic�o�׏Ɖ�);
			this.pan���j���[�Q.Controls.Add(this.pic�Ĕ��s);
			this.pan���j���[�Q.Controls.Add(this.pic�o�[�R�[�h�ǎ�);
			this.pan���j���[�Q.Location = new System.Drawing.Point(184, 82);
			this.pan���j���[�Q.Name = "pan���j���[�Q";
			this.pan���j���[�Q.Size = new System.Drawing.Size(544, 338);
			this.pan���j���[�Q.TabIndex = 33;
			// 
			// pic�o�׎���
			// 
			this.pic�o�׎���.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic�o�׎���.Location = new System.Drawing.Point(16, 80);
			this.pic�o�׎���.Name = "pic�o�׎���";
			this.pic�o�׎���.Size = new System.Drawing.Size(482, 42);
			this.pic�o�׎���.TabIndex = 27;
			this.pic�o�׎���.TabStop = false;
			this.pic�o�׎���.Click += new System.EventHandler(this.pic�o�׎���_Click);
			this.pic�o�׎���.MouseEnter += new System.EventHandler(this.pic�o�׎���_MouseEnter);
			this.pic�o�׎���.MouseLeave += new System.EventHandler(this.pic�o�׎���_MouseLeave);
			// 
			// pic�Ĕ��s
			// 
			this.pic�Ĕ��s.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic�Ĕ��s.Location = new System.Drawing.Point(16, 144);
			this.pic�Ĕ��s.Name = "pic�Ĕ��s";
			this.pic�Ĕ��s.Size = new System.Drawing.Size(482, 42);
			this.pic�Ĕ��s.TabIndex = 26;
			this.pic�Ĕ��s.TabStop = false;
			this.pic�Ĕ��s.Click += new System.EventHandler(this.pic�Ĕ��s_Click);
			this.pic�Ĕ��s.MouseEnter += new System.EventHandler(this.pic�Ĕ��s_MouseEnter);
			this.pic�Ĕ��s.MouseLeave += new System.EventHandler(this.pic�Ĕ��s_MouseLeave);
			// 
			// pic�o�[�R�[�h�ǎ�
			// 
			this.pic�o�[�R�[�h�ǎ�.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic�o�[�R�[�h�ǎ�.Location = new System.Drawing.Point(16, 208);
			this.pic�o�[�R�[�h�ǎ�.Name = "pic�o�[�R�[�h�ǎ�";
			this.pic�o�[�R�[�h�ǎ�.Size = new System.Drawing.Size(482, 42);
			this.pic�o�[�R�[�h�ǎ�.TabIndex = 41;
			this.pic�o�[�R�[�h�ǎ�.TabStop = false;
			this.pic�o�[�R�[�h�ǎ�.Click += new System.EventHandler(this.pic�o�[�R�[�h�ǎ�_Click);
			this.pic�o�[�R�[�h�ǎ�.MouseEnter += new System.EventHandler(this.pic�o�[�R�[�h�ǎ�_MouseEnter);
			this.pic�o�[�R�[�h�ǎ�.MouseLeave += new System.EventHandler(this.pic�o�[�R�[�h�ǎ�_MouseLeave);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(255)));
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(0, 10);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(782, 65);
			this.pictureBox2.TabIndex = 26;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox7
			// 
			this.pictureBox7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(255)));
			this.pictureBox7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox7.BackgroundImage")));
			this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
			this.pictureBox7.Location = new System.Drawing.Point(0, 46);
			this.pictureBox7.Name = "pictureBox7";
			this.pictureBox7.Size = new System.Drawing.Size(160, 418);
			this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox7.TabIndex = 25;
			this.pictureBox7.TabStop = false;
			// 
			// lab���b�Z�[�W
			// 
			this.lab���b�Z�[�W.BackColor = System.Drawing.Color.SkyBlue;
			this.lab���b�Z�[�W.Font = new System.Drawing.Font("�l�r �S�V�b�N", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���b�Z�[�W.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lab���b�Z�[�W.Location = new System.Drawing.Point(136, 434);
			this.lab���b�Z�[�W.Name = "lab���b�Z�[�W";
			this.lab���b�Z�[�W.Size = new System.Drawing.Size(682, 24);
			this.lab���b�Z�[�W.TabIndex = 34;
			this.lab���b�Z�[�W.Tag = "";
			this.lab���b�Z�[�W.Text = "�@�@";
			this.lab���b�Z�[�W.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lab���b�Z�[�W��
			// 
			this.lab���b�Z�[�W��.BackColor = System.Drawing.Color.SkyBlue;
			this.lab���b�Z�[�W��.Font = new System.Drawing.Font("�l�r �S�V�b�N", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���b�Z�[�W��.Location = new System.Drawing.Point(136, 434);
			this.lab���b�Z�[�W��.Name = "lab���b�Z�[�W��";
			this.lab���b�Z�[�W��.Size = new System.Drawing.Size(662, 24);
			this.lab���b�Z�[�W��.TabIndex = 37;
			this.lab���b�Z�[�W��.Tag = "";
			this.lab���b�Z�[�W��.Text = "�@�@";
			this.lab���b�Z�[�W��.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// pic���x���C���[�W���
			// 
			this.pic���x���C���[�W���.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic���x���C���[�W���.Location = new System.Drawing.Point(16, 272);
			this.pic���x���C���[�W���.Name = "pic���x���C���[�W���";
			this.pic���x���C���[�W���.Size = new System.Drawing.Size(482, 42);
			this.pic���x���C���[�W���.TabIndex = 42;
			this.pic���x���C���[�W���.TabStop = false;
			this.pic���x���C���[�W���.Click += new System.EventHandler(this.pic���x���C���[�W���_Click);
			this.pic���x���C���[�W���.MouseEnter += new System.EventHandler(this.pic���x���C���[�W���_MouseEnter);
			this.pic���x���C���[�W���.MouseLeave += new System.EventHandler(this.pic���x���C���[�W���_MouseLeave);
			// 
			// ���j���[
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 580);
			this.Controls.Add(this.pan���C��);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "���j���[";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "is-2 Home";
			this.Load += new System.EventHandler(this.���j���[_Load);
			this.Activated += new System.EventHandler(this.���j���[_Activated);
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).EndInit();
			this.panel7.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.pan���C��.ResumeLayout(false);
			this.pan���j���[�U.ResumeLayout(false);
			this.pan���j���[�S.ResumeLayout(false);
			this.pan���j���[�R.ResumeLayout(false);
			this.pan���j���[�P.ResumeLayout(false);
			this.pan���j���[�Q.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		[STAThread]
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� START
//		static void Main(string[] args) 
// MOD 2009.10.14 ���s�j���� config�Ǎ��Ȃ� START
//		public static void Main(string[] args) 
		public void Main(string[] args) 
// MOD 2009.10.14 ���s�j���� config�Ǎ��Ȃ� END
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� END
		{
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� START
//			// �A�v���P�[�V�����̓�d�N���h�~
//			mutex = new System.Threading.Mutex(false, "is2Client");
//			if( mutex.WaitOne(0, false) == false) return;
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� END

// MOD 2005.05.20 ���s�j�ɉ� �N�C�b�N�G���g���V���[�g�J�b�g�Ή� START
//			if(args.Length > 0 && args[0].Trim() == "hinagata")
			if(args.Length > 0 && args[0].IndexOf("hinagata") != -1)
			{
				b���^�o�דo�^ = true;
				if (args[0].IndexOf("_") != -1)
				{
					s���^�o�דo�^�m�n = args[0].Substring(args[0].IndexOf("_") + 1);
				}
			}
// MOD 2005.05.20 ���s�j�ɉ� �N�C�b�N�G���g���V���[�g�J�b�g�Ή� END

			// �J�����g�f�B���N�g���̎擾
			gs�A�v���t�H���_ = System.IO.Directory.GetCurrentDirectory();

// MOD 2009.10.14 ���s�j���� config�Ǎ��Ȃ� START
			try{
				FileInfo finfo = new FileInfo("IS2Client.dll.config");
				if(finfo.Exists){
					XmlDocument xmldoc = new XmlDocument();
					xmldoc.Load(finfo.FullName);
					foreach(XmlNode node in xmldoc["configuration"]["appSettings"]){
						if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2address.Service1")){
							sUrl_address = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2goirai.Service1")){
							sUrl_goirai = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2hinagata.Service1")){
							sUrl_hinagata = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2init.Service1")){
							sUrl_init = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2kiji.Service1")){
							sUrl_kiji = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2otodoke.Service1")){
							sUrl_otodoke = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2print.Service1")){
							sUrl_print = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2syukka.Service1")){
							sUrl_syukka = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2seikyuu.Service1")){
							sUrl_seikyuu = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2oshirase.Service1")){
							sUrl_oshirase = node.Attributes.GetNamedItem("value").Value;
						}
// MOD 2011.01.11 ���s�j���� ���q�^���̑Ή� START
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2oji.Service1")){
							sUrl_oji = node.Attributes.GetNamedItem("value").Value;
						}
// MOD 2011.01.11 ���s�j���� ���q�^���̑Ή� END
						else if(node.Attributes.GetNamedItem("key").Value.Equals("HelpURL")){
							s�w���v�t�q�k = node.Attributes.GetNamedItem("value").Value;
						}
					}
					xmldoc = null;
				}
				finfo = null;
			}catch(Exception){
				;
			}
// MOD 2009.10.14 ���s�j���� config�Ǎ��Ȃ� END
// ADD 2005.05.27 ���s�j���� �X���b�h�ʒu�̈ړ� START
			trd = new Thread(new ThreadStart(ThreadTask));
			trd.IsBackground = true;
			trd.Start();
// ADD 2005.05.27 ���s�j���� �X���b�h�ʒu�̈ړ� END

			// XML�T�[�r�X�̏�����
			try
			{
// MOD 2005.05.17 ���s�j���� �N�����Ԃ�Z������ START
//				if(sv_init == null) sv_init = new is2init.Service1();
//				sv_init.CookieContainer = cContainer;
// MOD 2005.05.17 ���s�j���� �N�����Ԃ�Z������ END

				bool b���O�C�� = true;

// ADD 2008.05.20 ���s�j���� [wis2.dll]�̃t�H���_�̕ύX START
				//[wis2.dll]���V�X�e���t�H���_�ɗL��ꍇ
				//�i�C���X�g�[���[�̃o�[�W�������Â��ꍇ�j
				if(File.Exists(gsInitFile)){
// ADD 2008.05.20 ���s�j���� [wis2.dll]�̃t�H���_�̕ύX END
// ADD 2008.03.13 ���s�j���� Vista�Ή� START
					//�������݌������Ȃ��ꍇ�iVista�Ή��A�h���C���Ή��j
					try{
						StreamWriter sw = File.AppendText(gsInitFile);
						sw.Write("");
						sw.Close();
					}catch(Exception){
// ADD 2008.06.17 ���s�j���� �f�B���N�g�����݃`�F�b�N�̒ǉ� START
						if(Directory.Exists(gs�A�v���t�H���_.Substring(0,gs�A�v���t�H���_.Length-4))){
// ADD 2008.06.17 ���s�j���� �f�B���N�g�����݃`�F�b�N�̒ǉ� END
							gbInitFileExt = true;
// MOD 2008.03.13 ���s�j���� Vista�Ή� START
//						gsInitFile = gs�A�v���t�H���_ + "\\wis2.dll";
							gsInitFile
							 = gs�A�v���t�H���_.Substring(0,gs�A�v���t�H���_.Length-4)
							 + "\\wis2.dll";
// MOD 2008.03.13 ���s�j���� Vista�Ή� END
// ADD 2008.06.17 ���s�j���� �f�B���N�g�����݃`�F�b�N�̒ǉ� START
						}
// ADD 2008.06.17 ���s�j���� �f�B���N�g�����݃`�F�b�N�̒ǉ� END
					}
// ADD 2008.03.13 ���s�j���� Vista�Ή� END
// ADD 2008.05.20 ���s�j���� [wis2.dll]�̃t�H���_�̕ύX START
				}else{
// ADD 2008.06.17 ���s�j���� �f�B���N�g�����݃`�F�b�N�̒ǉ� START
					if(Directory.Exists(gs�A�v���t�H���_.Substring(0,gs�A�v���t�H���_.Length-4))){
// ADD 2008.06.17 ���s�j���� �f�B���N�g�����݃`�F�b�N�̒ǉ� END
						gbInitFileExt = true;
						gsInitFile
						 = gs�A�v���t�H���_.Substring(0,gs�A�v���t�H���_.Length-4)
						 + "\\wis2.dll";
// ADD 2008.06.17 ���s�j���� �f�B���N�g�����݃`�F�b�N�̒ǉ� START
					}
// ADD 2008.06.17 ���s�j���� �f�B���N�g�����݃`�F�b�N�̒ǉ� END
				}
// ADD 2008.05.20 ���s�j���� [wis2.dll]�̃t�H���_�̕ύX END
// ADD 2009.07.29 ���s�j���� �v���L�V�Ή� START
				if(Directory.Exists(gs�A�v���t�H���_.Substring(0,gs�A�v���t�H���_.Length-4))){
					gsInitProxy
					 = gs�A�v���t�H���_.Substring(0,gs�A�v���t�H���_.Length-4)
					 + "\\proxy.ini";
// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� START
					gsInitKiji
					 = gs�A�v���t�H���_.Substring(0,gs�A�v���t�H���_.Length-4)
					 + "\\kiji.ini";
// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� END
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� START
					gsInitClient
					 = gs�A�v���t�H���_.Substring(0,gs�A�v���t�H���_.Length-4)
					 + "\\IS2Client.ini";
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� END
// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� START
					gsInitSyukka
					 = gs�A�v���t�H���_.Substring(0,gs�A�v���t�H���_.Length-4)
					 + "\\syukka.ini";
					gsPathSyukka
					 = gs�A�v���t�H���_.Substring(0,gs�A�v���t�H���_.Length-4)
					 + "\\Syukka";
					gsPathSyukkaIn  = gsPathSyukka + "\\In";
					gsPathSyukkaOut = gsPathSyukka + "\\Out";
					gsPathSyukkaLog = gsPathSyukka + "\\Log";
// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� END
// MOD 2010.04.16 ���s�j���� ���W���[���ă_�E�����[�h START
					gsFlagIS2Client
					 = gs�A�v���t�H���_.Substring(0,gs�A�v���t�H���_.Length-4)
					 + "\\zs2Client.txt";
// MOD 2010.04.16 ���s�j���� ���W���[���ă_�E�����[�h END
				}
// ADD 2009.07.29 ���s�j���� �v���L�V�Ή� END
// MOD 2011.10.11 ���s�j���� �r�r�k�ؖ���������ԂȂǂ̃`�F�b�N START
				gbInitSyukkaExists = false;
				try{
					if(File.Exists(gsInitSyukka)){
						gbInitSyukkaExists = true;
					}
				}catch{
					gbInitSyukkaExists = false;
				}
				gsOSVer = "";
				try{
					gsOSVer = System.Environment.OSVersion.Version.ToString();
				}catch(Exception ex){
					gsOSVer = "e:"+ex.Message;
				}
				gsNetVer = "";
				try{
					gsNetVer = System.Environment.Version.ToString();
				}catch(Exception ex){
					gsNetVer = "e:"+ex.Message;
				}
// MOD 2011.10.11 ���s�j���� �r�r�k�ؖ���������ԂȂǂ̃`�F�b�N END
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� START
				�[�����Ƃ̏����ݒ�t�@�C���Ǎ�();
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� END
// ADD 2008.04.11 ACT Vista�Ή� START

				try
				{
					�����ϊ��n�b�V���ݒ�();
				}
				catch(Exception ex)
				{
					�r�[�v��();
					MessageBox.Show(ex.Message, 
						"�����ϊ��擾", 
						MessageBoxButtons.OK, MessageBoxIcon.Error);
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� START
//					// �~���[�e�b�N�X�̔j��
//					mutex.Close();
//					Application.Exit();
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� END
					return;
				}		
// ADD 2008.04.11 ACT Vista�Ή� END

// ADD 2008.10.30 ���s�j���� �v���L�V�Ή� START
				gbInitProxyExists = false;
				gsProxyAdrUserSet = "";
				giProxyNoUserSet  = 0;
				giConnectTimeOut  = 50; // 50�b
// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� START
				gbProxyOnUserSet   = false;
				gbProxyIdOnUserSet = false;
				gsProxyIdUserSet   = "";
				gsProxyPaUserSet   = "";
// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� END

				string sConnectTimeOut  = "";
				string sProxyAdrUserSet = "";
				string sProxyNoUserSet  = "";
// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� START
				string sProxyOnUserSet   = "";
				string sProxyIdOnUserSet = "";
				string sProxyIdUserSet   = "";
				string sProxyPaUserSet   = "";
// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� END

				StreamReader srp = null;
				try
				{
					srp = File.OpenText(gsInitProxy);
					gbInitProxyExists = true;
					sConnectTimeOut  = srp.ReadLine();
					sProxyAdrUserSet = srp.ReadLine();
					sProxyNoUserSet  = srp.ReadLine();
// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� START
//					if(srp != null) srp.Close();
					sProxyOnUserSet   = srp.ReadLine();
					sProxyIdOnUserSet = srp.ReadLine();
					sProxyIdUserSet   = srp.ReadLine();
					sProxyPaUserSet   = srp.ReadLine();
					if(sConnectTimeOut   == null) sConnectTimeOut   = "";
					if(sProxyAdrUserSet  == null) sProxyAdrUserSet  = "";
					if(sProxyNoUserSet   == null) sProxyNoUserSet   = "";
					if(sProxyOnUserSet   == null) sProxyOnUserSet   = "";
					if(sProxyIdOnUserSet == null) sProxyIdOnUserSet = "";
					if(sProxyIdUserSet   == null) sProxyIdUserSet   = "";
					if(sProxyPaUserSet   == null) sProxyPaUserSet   = "";

					if(sProxyIdUserSet.Length > 0){
						sProxyIdUserSet  = �������Q(sProxyIdUserSet);
						sProxyPaUserSet  = �������Q(sProxyPaUserSet);
					}
// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� END
				}
//				catch(System.IO.FileNotFoundException ex)
//				{
//					With _myLogRecord
//						.Target = "�v���L�V�ݒ�t�@�C�����݂���܂���ł���"
//						.Result = "NG"
//						.Remark = ex.Message
//					End With
//					_myLog.WriteLog(_myLogRecord)
//				}
				catch(Exception)
				{
//					With _myLogRecord
//						.Target = "�v���L�V�ݒ�t�@�C�� Exception:"
//						.Result = "NG"
//						.Remark = ex.Message
//					End With
//					_myLog.WriteLog(_myLogRecord)
				}
// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� START
				finally
				{
					if(srp != null) srp.Close();
				}
// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� END

// ADD 2009.10.03 ���s�j���� [proxy.ini]�����݂��Ȃ����A�v���L�V���ŋ@�\��~ START
				if(gbInitProxyExists){
// ADD 2009.10.03 ���s�j���� [proxy.ini]�����݂��Ȃ����A�v���L�V���ŋ@�\��~ END
					try
					{
						if(sConnectTimeOut.Length > 0){
							if(���p�`�F�b�N(sConnectTimeOut)){
								if(���l�`�F�b�N(sConnectTimeOut)){
									giConnectTimeOut = int.Parse(sConnectTimeOut);
								}
							}
						}
						if(sProxyAdrUserSet != null){
							if(���p�`�F�b�N(sProxyAdrUserSet)){
							    gsProxyAdrUserSet = sProxyAdrUserSet;
							}
						}
						if(sProxyNoUserSet.Length > 0){
							if(���p�`�F�b�N(sProxyNoUserSet)){
								if(���l�`�F�b�N(sProxyNoUserSet)){
									giProxyNoUserSet = int.Parse(sProxyNoUserSet);
								}
							}
						}
// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� START
						if(sProxyOnUserSet != null){
							if(���p�`�F�b�N(sProxyOnUserSet)){
								if(sProxyOnUserSet.Equals("1")){
									gbProxyOnUserSet = true;
								}
							}
						}
						if(sProxyOnUserSet == null || sProxyOnUserSet.Length == 0){
							if(gsProxyAdrUserSet.Length > 0){
								gbProxyOnUserSet = true;
							}
						}
						if(sProxyIdOnUserSet != null){
							if(���p�`�F�b�N(sProxyIdOnUserSet)){
								if(sProxyIdOnUserSet.Equals("1")){
									gbProxyIdOnUserSet = true;
								}
							}
						}
						if(sProxyIdUserSet != null){
							if(���p�`�F�b�N(sProxyIdUserSet)){
							    gsProxyIdUserSet = sProxyIdUserSet;
							}
						}
						if(sProxyPaUserSet != null){
							if(���p�`�F�b�N(sProxyPaUserSet)){
							    gsProxyPaUserSet = sProxyPaUserSet;
							}
						}
// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� END
					}
//					catch(Exception ex)
					catch(Exception)
					{
	//'//�ۗ��@�G���[����
	//					With _myLogRecord
	//						.Target = "XmlReadServer Exception:"
	//						.Result = "NG"
	//						.Remark = ex.Message
	//					End With
	//					_myLog.WriteLog(_myLogRecord)
					}

					bool bRet = false;
					int  iRet = 0;
					�h�d�v���L�V�擾();
// MOD 2009.10.14 ���s�j���� config�Ǎ��Ȃ� START
//					sv_init = new is2init.Service1();
					�v�����T�[�r�X�̏�����init();
// MOD 2009.10.14 ���s�j���� config�Ǎ��Ȃ� END
					sv_init.Timeout = giConnectTimeOut * 1000;

					//���ł̂��q�l�Ŗ��ݒ�̃v���L�V���ݒ�̂��q�l�́A[]
					//���ł̂��q�l�Ŗ��ݒ�̃v���L�V�ݒ�̂��q�l�́A[50]
					//[proxy.ini]�̂P�s�ڂ����ݒ�̏ꍇ�A�J���n���ڑ��Ƃ���
					//����ȊO��[https]�ʐM�ɋ����I�ɂ���
// MOD 2009.10.14 ���s�j���� config�Ǎ��Ȃ� START
//					if(sConnectTimeOut.Length > 0){
//						sv_init.Url = sv_init.Url.Replace("http://","https://");
//					}
// MOD 2009.10.14 ���s�j���� config�Ǎ��Ȃ� END

// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� START
//					if(bRet == false && gsProxyAdrUserSet.Length > 0){
//						//�h�d�̃v���L�V�ݒ�(���[�U�ݒ�)
//						bRet = �v���L�V�ݒ�(gsProxyAdrUserSet, giProxyNoUserSet);
//					}
					if(bRet == false){
						if(gbProxyOnUserSet){
							if(gbProxyIdOnUserSet){
								//�h�d�̃v���L�V�ݒ�(���[�U�ݒ�F�F�ؗL)
								bRet = �v���L�V�ݒ�Q(gsProxyAdrUserSet, giProxyNoUserSet
														, gsProxyIdUserSet, gsProxyPaUserSet);
							}else{
								//�h�d�̃v���L�V�ݒ�(���[�U�ݒ�)
								bRet = �v���L�V�ݒ�(gsProxyAdrUserSet, giProxyNoUserSet);
							}
						}else{
							//�h�d�̃v���L�V�ݒ�(�v���L�V����)
							bRet = �v���L�V�ݒ�("", 0);
						}
					}
// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� END

					if(bRet == false && gsProxyAdr.Length > 0){
						//�h�d�̃v���L�V�ݒ�(�f�t�H���g)
						iRet = �f�t�H���g�v���L�V�ݒ�();
						if(iRet == 1) bRet = true;
					}

					//�h�d�̃v���L�V�ݒ�(�r�r�k�A�r�����X�g�L��)���x�X�g���Ǝv����
					if(bRet == false && gsProxyAdr.Length > 0){
						//�h�d�̃v���L�V�ݒ�(Select)
						bRet = �v���L�V�ݒ�(gsProxyAdr, giProxyNo);
					}

					if(bRet == false && gsProxyAdrHttp.Length > 0){
						//�h�d�̃v���L�V�ݒ�(HTTP)
						bRet = �v���L�V�ݒ�(gsProxyAdrHttp, giProxyNoHttp);
					}

					if(bRet == false){
						//�h�d�̃v���L�V�ݒ�(�v���L�V����)
						bRet = �v���L�V�ݒ�("", 0);
					}

//					sv_init.Timeout = 100000; // �f�t�H���g�l�̂P�O�O�b�ɖ߂�
// ADD 2009.10.03 ���s�j���� [proxy.ini]�����݂��Ȃ����A�v���L�V���ŋ@�\��~ START
				}else{
					// [proxy.ini]�����݂��Ȃ��ꍇ
					�v�����T�[�r�X�̏�����init();
					�v�����T�[�r�X�̏�����others();
				}
// ADD 2009.10.03 ���s�j���� [proxy.ini]�����݂��Ȃ����A�v���L�V���ŋ@�\��~ END
// ADD 2009.07.29 ���s�j���� �v���L�V�Ή� END
// MOD 2011.10.11 ���s�j���� �r�r�k�ؖ���������ԂȂǂ̃`�F�b�N START
				trdSSLTest = new Thread(new ThreadStart(�r�r�k�ؖ���������ԃ`�F�b�N));
				trdSSLTest.IsBackground = true;
				trdSSLTest.Start();
// MOD 2011.10.11 ���s�j���� �r�r�k�ؖ���������ԂȂǂ̃`�F�b�N END

				// �����ݒ�t�@�C�������݂��Ȃ��ꍇ�F�����o�^��ʂ�\��
				if( !File.Exists(gsInitFile) )
				{
// MOD 2007.11.29 ���s�j���� ���O�C�����̃t�H�[�J�X��Q�Ή� START
//					�����o�^ ��� = new �����o�^();
//					���.ShowDialog();
					F�����o�^ = new �����o�^();
					F�����o�^.WindowState = FormWindowState.Normal;
					F�����o�^.ShowDialog();
					F�����o�^ = null;
// MOD 2007.11.29 ���s�j���� ���O�C�����̃t�H�[�J�X��Q�Ή� END
					b���O�C�� = false;	// ���O�C����ʂ͔�\��
				}
				// �����ݒ�t�@�C�������݂��Ȃ��ꍇ�F�A�v���I��
				if( !File.Exists(gsInitFile) )
				{
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� START
//					// �~���[�e�b�N�X�̔j��
//					mutex.Close();
//					Application.Exit();
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� END
					return;
				}

// MOD 2005.05.17 ���s�j���� �N�����Ԃ�Z������ START
//				// �[���b�c�̎擾
//				StreamReader sr = File.OpenText(gsInitFile);
//				gs����b�c   = sr.ReadLine();
//				if(gs����b�c == null)
//				{
//					sr.Close();
//
//					�����o�^ F�����o�^ = new �����o�^();
//					F�����o�^.ShowDialog();
//					b���O�C�� = false;	// ���O�C����ʂ͔�\��
//
//					sr = File.OpenText(gsInitFile);
//					gs����b�c   = sr.ReadLine();
//				}
//				gs���p�҂b�c = sr.ReadLine();
//				gs�[���b�c   = sr.ReadLine();
//				gs�����     = sr.ReadLine();
//				gs���p�Җ�   = sr.ReadLine();
//				gs����b�c   = sr.ReadLine();
//				gs���喼     = sr.ReadLine();
//				sr.Close();
//				// ����b�c�A�[���b�c���ݒ肳��Ă��Ȃ��ꍇ�F�A�v���I��
//				if(gs����b�c == null || gs����b�c.Trim().Length == 0
//					|| gs�[���b�c == null || gs�[���b�c.Trim().Length == 0)
//				{
//					// �~���[�e�b�N�X�̔j��
//					mutex.Close();
//					Application.Exit();
//					return;
//				}
//
//				gs�����   = "";
//
//				�[�����擾();
//				// �}�X�^�ݒ肪�K�����Ȃ��ꍇ�ɂ͏I��
//				if(gs�����.Length == 0)
//				{
//					// �~���[�e�b�N�X�̔j��
//					mutex.Close();
//					Application.Exit();
//					return;
//				}
//				gsa���[�U[2] = gs�[���b�c;

				// �[���b�c�̎擾
				StreamReader sr = File.OpenText(gsInitFile);
				gs�[���b�c = sr.ReadLine();
				gs�[���b�c = sr.ReadLine();
				gs�[���b�c = sr.ReadLine();
				sr.Close();

				if(gs�[���b�c == null || gs�[���b�c.Trim().Length == 0)
				{
// MOD 2007.11.29 ���s�j���� ���O�C�����̃t�H�[�J�X��Q�Ή� START
//					�����o�^ F�����o�^ = new �����o�^();
					F�����o�^ = new �����o�^();
					F�����o�^.WindowState = FormWindowState.Normal;
// MOD 2007.11.29 ���s�j���� ���O�C�����̃t�H�[�J�X��Q�Ή� END
					F�����o�^.ShowDialog();
// ADD 2007.11.29 ���s�j���� ���O�C�����̃t�H�[�J�X��Q�Ή� START
					F�����o�^ = null;
// ADD 2007.11.29 ���s�j���� ���O�C�����̃t�H�[�J�X��Q�Ή� END
					b���O�C�� = false;	// ���O�C����ʂ͔�\��

					sr = File.OpenText(gsInitFile);
					gs�[���b�c = sr.ReadLine();
					gs�[���b�c = sr.ReadLine();
					gs�[���b�c = sr.ReadLine();
					sr.Close();
				}
				// �[���b�c���ݒ肳��Ă��Ȃ��ꍇ�F�A�v���I��
				if(gs�[���b�c == null || gs�[���b�c.Trim().Length == 0)
				{
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� START
//					// �~���[�e�b�N�X�̔j��
//					mutex.Close();
//					Application.Exit();
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� END
					return;
				}
				gsa���[�U[2] = gs�[���b�c;
// MOD 2005.05.17 ���s�j���� �N�����Ԃ�Z������ END

				// �����o�^��ʂ��J����Ȃ��������Ɏ��s
				if(b���O�C��)
				{
					gs���p�҂b�c = "";
					gs���p�Җ�   = "";
// MOD 2007.11.29 ���s�j���� ���O�C�����̃t�H�[�J�X��Q�Ή� START
//					���O�C�� F���O�C�� = new ���O�C��();
					F���O�C�� = new ���O�C��();
					F���O�C��.WindowState = FormWindowState.Normal;
// MOD 2007.11.29 ���s�j���� ���O�C�����̃t�H�[�J�X��Q�Ή� END
					F���O�C��.ShowDialog();
// ADD 2007.11.29 ���s�j���� ���O�C�����̃t�H�[�J�X��Q�Ή� START
					F���O�C�� = null;
// ADD 2007.11.29 ���s�j���� ���O�C�����̃t�H�[�J�X��Q�Ή� END
					// �}�X�^�ݒ肪�K�����Ȃ��ꍇ�ɂ͏I��
					if(gs���p�҂b�c.Length == 0 || gs���p�Җ�.Length == 0)
					{
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� START
//						// �~���[�e�b�N�X�̔j��
//						mutex.Close();
//						Application.Exit();
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� END
						return;
					}
				}
				���p�ҏ��擾();
// ADD 2006.12.14 ���s�j�����J �������� START
				gs���p�ҕ���b�c = gs����b�c;
// ADD 2006.12.14 ���s�j�����J �������� END

// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� START
//// ADD 2006.12.12 ���s�j�����J ����X���擾 START
//				���p�ҕ���X���擾();
//// ADD 2006.12.12 ���s�j�����J ����X���擾 END
				gs���p�ҕ���X���b�c = ����X���擾(gs���p�ҕ���b�c);
				gs����X���b�c = gs���p�ҕ���X���b�c;
// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� END

// ADD 2009.04.02 ���s�j���� �ғ����Ή� START
				�ғ������擾();
// ADD 2009.04.02 ���s�j���� �ғ����Ή� END
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
				�I�v�V�������擾();
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� END
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
				�d�ʓ��͐���擾();
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END

// ADD 2005.07.21 ���s�j���� �X�����[�U�Ή� START
				if(gs�����P == "T")
					gs�v�����^�e�f = "0"; // �v�����^����
// ADD 2005.07.21 ���s�j���� �X�����[�U�Ή� END
			}
			catch (Exception)
			{
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� START
//				// �~���[�e�b�N�X�̔j��
//				mutex.Close();
//				Application.Exit();
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� END
				return;
			}

			gsa���[�U[0] = gs����b�c;
			gsa���[�U[1] = gs���p�҂b�c;

// DEL 2005.05.20 ���s�j���� �X���b�h�� START
//			if(sv_address == null) sv_address = new is2address.Service1();
//			sv_address.CookieContainer = cContainer;
//
//			if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
//			sv_goirai.CookieContainer = cContainer;
//
//			if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
//			sv_hinagata.CookieContainer = cContainer;
//
//			if(sv_kiji == null) sv_kiji = new is2kiji.Service1();
//			sv_kiji.CookieContainer = cContainer;
//
//			if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
//			sv_otodoke.CookieContainer = cContainer;
//
//			if(sv_print == null) sv_print = new is2print.Service1();
//			sv_print.CookieContainer = cContainer;
//
//			if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
//			sv_syukka.CookieContainer = cContainer;
//
//			if(sv_seikyuu == null) sv_seikyuu = new is2seikyuu.Service1();
//			sv_seikyuu.CookieContainer = cContainer;
// DEL 2005.05.20 ���s�j���� �X���b�h�� END

// MOD 2005.05.27 ���s�j���� �N�����Ԃ�Z������ START
//			try
//			{	
//				// ��ԃ��X�g���擾
//				if(sv_init == null) sv_init = new is2init.Service1();
////				sv_init.CookieContainer = cContainer;
//				string[] sRet = sv_init.Get_jyotai(gsa���[�U);
//				if( sRet[0].Length == 4 ){
//					int i��Ԑ� = int.Parse(sRet[1]);
//					if(i��Ԑ� > 0)
//					{
//						gsa��Ԃb�c = new string[1 + i��Ԑ�];
//						gsa��Ԗ��@ = new string[1 + i��Ԑ�];
//						gsa��Ԃb�c[0] = "00";
//						gsa��Ԗ�[0]   = "�S��";
//						int iPos = 2;
//						for(int iCnt = 1; iCnt <= i��Ԑ� && iPos < sRet.Length; iCnt++)
//						{
//							gsa��Ԃb�c[iCnt] = sRet[iPos++];
//							gsa��Ԗ�[iCnt]   = sRet[iPos++];
//						}
//					}
//				}
//			}
//			catch (Exception)
//			{
//				// �~���[�e�b�N�X�̔j��
//				mutex.Close();
//				Application.Exit();
//				return;
//			}

			// �X���b�h�ł͎��s�ł��Ȃ��̂ŁA�����Ŏ��{
			if(g�o�׏Ɖ� == null) g�o�׏Ɖ� = new �o�׏Ɖ�();
			if(g�͐挟�� == null) g�͐挟�� = new ���͂��挟��();
			if(g�˗����� == null) g�˗����� = new ���˗��匟��();
			if(g�L������ == null) g�L������ = new �L������();
			if(g�����o�^ == null) g�����o�^ = new �����o�דo�^();
			if(g�Z������ == null) g�Z������ = new �Z������();
			if(g�����o�^ == null) g�����o�^ = new ������o�^();
			if(g������� == null) g������� = new �����s���();
// ADD 2006.12.22 ���s�j�����J ��ʒǉ� START
			if(g���O�C���Q == null) g���O�C���Q = new ���O�C���Q();
// ADD 2006.12.22 ���s�j�����J ��ʒǉ� END
// ADD 2007.12.06 KCL) �X�{ ���m�点�ǉ� START
			if(g���m�\�� == null) g���m�\�� = new ���m�点�\��();
// ADD 2007.12.06 KCL) �X�{ ���m�点�ǉ� END
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� START
			if(g�T����� == null) g�T����� = new �����T�����();
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� END

			if(��ԏ��擾() == false)
			{
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� START
//				// �~���[�e�b�N�X�̔j��
//				mutex.Close();
//				Application.Exit();
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� END
				return;
			}

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

// MOD 2005.05.27 ���s�j���� �N�����Ԃ�Z������ END

// MOD 2009.10.14 ���s�j���� config�Ǎ��Ȃ� START
//			Application.Run(new ���j���[());
			Application.Run(this);
// MOD 2009.10.14 ���s�j���� config�Ǎ��Ȃ� END
		}

// ADD 2005.05.27 ���s�j���� �N�����Ԃ�Z������ START
		private static bool ��ԏ��擾()
		{
			// ���Ɏ擾���Ă����ꍇ�ɂ͏I��
			if(gsa��Ԃb�c.Length > 1 && gsa��Ԃb�c[0].Length > 0) return true;

			try
			{	
				// ��ԃ��X�g���擾
				if(sv_init == null) sv_init = new is2init.Service1();
				string[] sRet = sv_init.Get_jyotai(gsa���[�U);
				if( sRet[0].Length == 4 ){
					int i��Ԑ� = int.Parse(sRet[1]);
					if(i��Ԑ� > 0)
					{
						gsa��Ԃb�c = new string[1 + i��Ԑ�];
						gsa��Ԗ��@ = new string[1 + i��Ԑ�];
						gsa��Ԃb�c[0] = "00";
						gsa��Ԗ�[0]   = "�S��";
						int iPos = 2;
						for(int iCnt = 1; iCnt <= i��Ԑ� && iPos < sRet.Length; iCnt++)
						{
							gsa��Ԃb�c[iCnt] = sRet[iPos++];
							gsa��Ԗ�[iCnt]   = sRet[iPos++];
						}
					}
				}
			}
// MOD 2005.06.30 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� START
//			catch (Exception)
//			{
//				return false;
//			}
			catch (System.Net.WebException)
			{
				�r�[�v��();
				MessageBox.Show(gs�ʐM�G���[, 
								"�ʐM�G���[", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			catch (Exception ex)
			{
				�r�[�v��();
				MessageBox.Show(ex.Message, 
								"�ʐM�G���[", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
// MOD 2005.06.30 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� END

			return true;
		}
// ADD 2005.05.27 ���s�j���� �N�����Ԃ�Z������ END

// MOD 2005.05.17 ���s�j���� �N�����Ԃ�Z������ START
		static public void �[�����擾()
		{
			// �J�[�\���������v�ɂ���
//			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				// �[�����̎擾�i����b�c�E���A�v�����^���j
				if(sv_init == null) sv_init = new is2init.Service1();
//				tex���b�Z�[�W.Text = "�[�����擾���D�D�D";
//				sv_init.CookieContainer = cContainer;
				String[] sRet = sv_init.Get_tanmatsu2(gsa���[�U,gs�[���b�c);
//				cContainer = sv_init.CookieContainer;
//				tex���b�Z�[�W.Text = sRet[0];
				if(sRet[0].Length != 4)
				{
					�r�[�v��();
					MessageBox.Show(sRet[0],
									"�[�����擾", 
									MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

// MOD 2005.05.17 ���s�j���� �N�����Ԃ�Z������ START
//// MOD 2005.05.11 ���s�j���� demo���[�U�̑Ή� START
////				gs����b�c     = sRet[1];
////				gs�v�����^�e�f = sRet[2];
////				gs�v�����^��� = sRet[3];
////				gs�����       = sRet[4];
//				if(gs����b�c == "demo")
//				{
//					gs�v�����^�e�f = sRet[2];
//					gs�v�����^��� = sRet[3];
//				}
//				else
//				{
//					gs����b�c     = sRet[1];
//					gs�v�����^�e�f = sRet[2];
//					gs�v�����^��� = sRet[3];
//					gs�����       = sRet[4];
//				}
//// MOD 2005.05.11 ���s�j���� demo���[�U�̑Ή� END
				gs�v�����^�e�f = sRet[2];
				gs�v�����^��� = sRet[3];
// MOD 2005.05.17 ���s�j���� �N�����Ԃ�Z������ END
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				�r�[�v��();
				MessageBox.Show(gs�ʐM�G���[, 
								"�ʐM�G���[", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				�r�[�v��();
				MessageBox.Show(ex.Message, 
								"�ʐM�G���[", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
//			Cursor = System.Windows.Forms.Cursors.Default;
		}
// MOD 2005.05.17 ���s�j���� �N�����Ԃ�Z������ END

		static private void ���p�ҏ��擾()
		{
			// �J�[�\���������v�ɂ���
//			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				// ���p�ҏ��擾�̎擾�i���p�Җ��A������A��������j
				if(sv_init == null) sv_init = new is2init.Service1();
//				tex���b�Z�[�W.Text = "���p�ҏ��擾���D�D�D";
//				sv_init.CookieContainer = cContainer;
				String[] sRet = sv_init.Get_riyou(gsa���[�U,gs����b�c, gs���p�҂b�c);
//				cContainer = sv_init.CookieContainer;
//				tex���b�Z�[�W.Text = sRet[0];
				if(sRet[0].Length != 4)
				{
					�r�[�v��();
					MessageBox.Show(sRet[0],
									"���p�ҏ��擾", 
									MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				gs���p�Җ�     = sRet[1];
				gs����b�c     = sRet[2];
				gs���喼       = sRet[3];
				gs�o�ד�       = sRet[4];
				if(gs�o�ד�.Length == 8)
				{
					gdt�o�ד� = new DateTime(int.Parse(gs�o�ד�.Substring(0,4)), 
											int.Parse(gs�o�ד�.Substring(4,2)),
											int.Parse(gs�o�ד�.Substring(6)) );
				}
				gs�ב��l�b�c   = sRet[5];
				// �����񐔂̎擾
				int iCntBumon  = int.Parse(sRet[6]);
				// �������񐔂̎擾
				int iCntTokui  = int.Parse(sRet[7]);
				// ��{���̍ŏI�C���f�b�N�X
				int iPos = 8;

				// ������̐ݒ�
				if(iCntBumon > 0)
				{
					gsa����b�c = new string[iCntBumon];
					gsa���喼   = new string[iCntBumon];
					gsa�o�ד�   = new string[iCntBumon];
					gh����b�c  = new Hashtable();
					for(int iCnt = 0; iCnt < iCntBumon; iCnt++)
					{
						gsa����b�c[iCnt] = sRet[iPos++];
						gsa���喼[iCnt]   = sRet[iPos++];
						gsa�o�ד�[iCnt]   = sRet[iPos++];
						gh����b�c.Add(gsa����b�c[iCnt],iCnt);
					}
				}
				// ��������̐ݒ�
				if(iCntTokui > 0)
				{
					gsa������b�c     = new string[iCntTokui];
					gsa�����敔�ۂb�c = new string[iCntTokui];
					gsa�����敔�ۖ�   = new string[iCntTokui];
					for(int iCnt = 0; iCnt < iCntTokui; iCnt++)
					{
						gsa������b�c[iCnt]     = sRet[iPos++];
						gsa�����敔�ۂb�c[iCnt] = sRet[iPos++];
						gsa�����敔�ۖ�[iCnt]   = sRet[iPos++];
					}
				}
// ADD 2005.07.21 ���s�j���� �X�����[�U�Ή� START
				gs�����P = sRet[sRet.Length -1];
// ADD 2005.07.21 ���s�j���� �X�����[�U�Ή� END
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				�r�[�v��();
				MessageBox.Show(gs�ʐM�G���[, 
								"�ʐM�G���[", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				�r�[�v��();
				MessageBox.Show(ex.Message, 
								"�ʐM�G���[", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
//			Cursor = System.Windows.Forms.Cursors.Default;
		}

// DEL 2007.03.28 ���s�j���� �W�דX�擾�G���[�Ή� START
//// ADD 2006.12.12 ���s�j�����J ����X���擾 START
//		static private void ���p�ҕ���X���擾()
//		{
//			try
//			{
//				// ���p�ҏ��擾�̎擾�i���p�Җ��A������A��������j
//				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
//				String[] sRet = sv_syukka.Get_hatuten2(gsa���[�U,gs����b�c,gs����b�c);
//				if(sRet[0].Length != 4)
//				{
//					�r�[�v��();
//					MessageBox.Show(sRet[0],
//						"���p�ҕ���X���擾", 
//						MessageBoxButtons.OK, MessageBoxIcon.Error);
//					return;
//				}
//
//				gs����X��     = sRet[1];
//			}
//			catch (System.Net.WebException)
//			{
//				�r�[�v��();
//				MessageBox.Show(gs�ʐM�G���[, 
//					"�ʐM�G���[", 
//					MessageBoxButtons.OK, MessageBoxIcon.Error);
//			}
//			catch (Exception ex)
//			{
//				�r�[�v��();
//				MessageBox.Show(ex.Message, 
//					"�ʐM�G���[", 
//					MessageBoxButtons.OK, MessageBoxIcon.Error);
//			}
//		}
//// ADD 2006.12.12 ���s�j�����J ����X���擾 END
// DEL 2007.03.28 ���s�j���� �W�דX�擾�G���[�Ή� END

		static private void ������擾()
		{
			// �J�[�\���������v�ɂ���
//			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				// ������擾�̎擾
				if(sv_init == null) sv_init = new is2init.Service1();
//				tex���b�Z�[�W.Text = "������擾���D�D�D";
//				sv_init.CookieContainer = cContainer;
				String[] sRet = sv_init.Get_bumon(gsa���[�U,gs����b�c);
//				cContainer = sv_init.CookieContainer;
//				tex���b�Z�[�W.Text = sRet[0];
				if(sRet[0].Length != 4)
				{
					�r�[�v��();
					MessageBox.Show(sRet[0],
									"������擾", 
									MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				// �����񐔂̎擾
				int iCntBumon  = int.Parse(sRet[1]);
				// ��{���̍ŏI�C���f�b�N�X
				int iPos = 2;

				// ������̐ݒ�
				if(iCntBumon > 0)
				{
					gsa����b�c = new string[iCntBumon];
					gsa���喼   = new string[iCntBumon];
					gsa�o�ד�   = new string[iCntBumon];
					gh����b�c  = new Hashtable();
					for(int iCnt = 0; iCnt < iCntBumon; iCnt++)
					{
						gsa����b�c[iCnt] = sRet[iPos++];
						gsa���喼[iCnt]   = sRet[iPos++];
						gsa�o�ד�[iCnt]   = sRet[iPos++];
						gh����b�c.Add(gsa����b�c[iCnt],iCnt);
					}
				}
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				�r�[�v��();
				MessageBox.Show(gs�ʐM�G���[, 
								"�ʐM�G���[", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				�r�[�v��();
				MessageBox.Show(ex.Message, 
								"�ʐM�G���[", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
//			Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void ���j���[_Load(object sender, System.EventArgs e)
		{
// ADD 2007.10.26 ���s�j���� �o�[�W�������̕\�� START
			if(gsa���[�U[3].Length > 0) lab�o�[�W����.Text = "Ver." + gsa���[�U[3];
// ADD 2007.10.26 ���s�j���� �o�[�W�������̕\�� END
// MOD 2009.10.16 ���s�j���� �v���L�V�@�\�\�L�̒ǉ� START
			if(gbInitProxyExists) lab�o�[�W����.Text += " p";
// MOD 2009.10.16 ���s�j���� �v���L�V�@�\�\�L�̒ǉ� END
			// �w�b�_�[���ڂ̐ݒ�
// DEL 2005.06.02 ���s�j�����J �폜 START
//			tex���p�Җ�.Text = gs���p�Җ�;
// DEL 2005.06.02 ���s�j�����J �폜 END
			tex���喼.Text   = gs����b�c + " " + gs���喼;
			tex�����.Text   = gs�����;
			// �����̏����ݒ�
			lab����.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled = true;
			// ���b�Z�[�W�̐ݒ�
			lab���b�Z�[�W.Text = "";
			tim���b�Z�[�W = new System.Windows.Forms.Timer(this.components);
			tim���b�Z�[�W.Tick += new System.EventHandler(tim���b�Z�[�W_Tick);
// MOD 2008.01.30 KCL) �X�{ �\���X�s�[�h�ύX START
//// MOD 2007.03.13 FJCS�j�K�c�@�\���X�s�[�h�ύX START
////			tim���b�Z�[�W.Interval = 100; // 0.1�b
//			tim���b�Z�[�W.Interval = 50; // 0.05�b
			tim���b�Z�[�W.Interval = 30; // 0.03�b
//// MOD 2007.03.13 FJCS�j�K�c�@�\���X�s�[�h�ύX END
// MOD 2008.01.30 KCL) �X�{ �\���X�s�[�h�ύX END
			tim���b�Z�[�W.Enabled = true;

			���j���[�C���[�W�̏�����();
// MOD 2011.04.05 ���s�j���� ��ʃC���[�W�̃��[�h�ύX START
//// MOD 2011.03.08 ���s�j���� ���q�^���Ή��i���j���[��ʂ̐ؑցj START
//			if(gs����b�c.Substring(0,1) != "J"){
//				imageMenu[4,0] = Image.FromFile("img\\upperbar.gif");
//			}else{
//				imageMenu[4,0] = Image.FromFile("img\\upperbar_oji.gif");
//			}
//// MOD 2011.03.08 ���s�j���� ���q�^���Ή��i���j���[��ʂ̐ؑցj END
			if(gs����b�c.Substring(0,1) != "J"){
				imageMenu[4,0] = Image_FromFile("img\\upperbar.gif");
			}else{
				imageMenu[4,0] = Image_FromFile("img\\upperbar_oji.gif");
			}
// MOD 2011.04.05 ���s�j���� ��ʃC���[�W�̃��[�h�ύX END
			�R�}���h�C���[�W�̏�����();

			// ���j���[
// MOD 2011.04.05 ���s�j���� ��ʃC���[�W�̃��[�h�ύX START
//			pic�z�[��.Image       = Image.FromFile("img\\home.gif");
			pic�z�[��.Image       = Image_FromFile("img\\home.gif");
// MOD 2011.04.05 ���s�j���� ��ʃC���[�W�̃��[�h�ύX END
			pic���j���[�P.Image   = imageMenu[0,1]; // �G���g���[
			pic���j���[�Q.Image   = imageMenu[1,0]; // �G���g���[�f�[�^
			pic���j���[�R.Image   = imageMenu[2,0]; // �A�h���X��
			pic���j���[�S.Image   = imageMenu[3,0]; // �I�v�V����
//			pic���j���[�T.Image   = imageMenu[6,0]; // �ݒ�
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
			pic���j���[�U.Image   = imageMenu[6,0]; // ���m�点
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
			pan���j���[�P.Visible = true;
			pan���j���[�Q.Visible = false;
			pan���j���[�R.Visible = false;
			pan���j���[�S.Visible = false;
//			pan���j���[�T.Visible = false;
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
			pan���j���[�U.Visible = false;
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
			pictureBox2.Image     = imageMenu[4,0];
//			pictureBox3.Image     = imageMenu[5,0];
			pictureBox7.Image     = imageMenu[4,1];
			// �R�}���h
			pic�o�דo�^.Image         = imageCmd[1,1,0];
			pic���^�o�דo�^.Image     = imageCmd[1,2,0];
			pic�����o�דo�^.Image     = imageCmd[1,3,0];
			pic�����׎D���s.Image   = imageCmd[1,4,0];
			pic�`���C�X�v�����g.Image = imageCmd[1,5,0];
			pic�o�׏Ɖ�.Image         = imageCmd[2,1,0];
			pic�o�׎���.Image         = imageCmd[2,2,0];
			pic�Ĕ��s.Image           = imageCmd[2,3,0];
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� START
			pic�o�[�R�[�h�ǎ�.Image    = imageCmd[2,4,0];
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� END
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� START
			pic���x���C���[�W���.Image    = imageCmd[2,5,0];
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� END
			pic���͂�����.Image     = imageCmd[3,1,0];
			pic���͐�捞.Image       = imageCmd[3,2,0];
			pic���˗�����.Image     = imageCmd[3,3,0];
// MOD 2010.08.27 ���s�j���� ���˗���捞�i�b�r�u�j�@�\�ǉ� START
			pic���˗���捞.Image     = imageCmd[3,4,0];
// MOD 2010.08.27 ���s�j���� ���˗���捞�i�b�r�u�j�@�\�ǉ� END
			pic�L�����.Image         = imageCmd[4,1,0];
			pic������o�^.Image       = imageCmd[4,2,0];
			pic�[�����.Image         = imageCmd[4,3,0];
			pic�ː��ؑ�.Image         = imageCmd[4,4,0];

// DEL 2008.02.08 KCL) �X�{ ���m�点�C�� START
//// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
//			pic���m�点�P.Image       = imageCmd[5,1,0];
//			pic���m�点�Q.Image       = imageCmd[5,1,0];
//			pic���m�点�R.Image       = imageCmd[5,1,0];
//			pic���m�点�S.Image       = imageCmd[5,1,0];
//			pic���m�点�T.Image       = imageCmd[5,1,0];
//// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
// DEL 2008.02.08 KCL) �X�{ ���m�点�C�� END

// DEL 2005.05.27 ���s�j���� �X���b�h�ʒu�̈ړ� START
//// ADD 2005.05.20 ���s�j���� �X���b�h�� START
//			trd = new Thread(new ThreadStart(ThreadTask));
//			trd.IsBackground = true;
//			trd.Start();
//// ADD 2005.05.20 ���s�j���� �X���b�h�� END
// DEL 2005.05.27 ���s�j���� �X���b�h�ʒu�̈ړ� END

// ADD 2005.05.25 ���s�j���� �w���v�t�q�k��config����擾 START
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� START
//			System.Type type = System.Type.GetType("System.String");
//			System.Configuration.AppSettingsReader config = new System.Configuration.AppSettingsReader();
//			s�w���v�t�q�k = config.GetValue("HelpURL", type).ToString();
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� END
// ADD 2005.05.25 ���s�j���� �w���v�t�q�k��config����擾 END

// ADD 2005.05.31 ���s�j�����J �v�����^�Ȃ��Ȃ烁�j���[������ START
			if(gs�v�����^�e�f == "0")
			{
				pic�����׎D���s.Visible   = false;
				pic�`���C�X�v�����g.Visible = false;
				pic�Ĕ��s.Visible           = false;
			}
			else
			{
				pic�����׎D���s.Visible   = true;
				pic�`���C�X�v�����g.Visible = true;
				pic�Ĕ��s.Visible           = true;
			}
// ADD 2005.05.31 ���s�j�����J �v�����^�Ȃ��Ȃ烁�j���[������ END

			if( b���^�o�דo�^ )
			{
// MOD 2005.05.20 ���s�j�ɉ� �N�C�b�N�G���g���V���[�g�J�b�g�Ή� START
				if (s���^�o�דo�^�m�n != null && !s���^�o�דo�^�m�n.Equals(""))
				{
					�o�דo�^ ��� = new �o�דo�^();
					���.Left = this.Left;
					���.Top = this.Top;
					���.s�����e�f = "I";
					���.dt���^�o�ד� = new DateTime(int.Parse(gs�o�ד�.Substring(0,4)), 
											int.Parse(gs�o�ד�.Substring(4,2)),
											int.Parse(gs�o�ד�.Substring(6)) );
					���.b���^�w���  = false;	//�w��Ȃ�
					���.i���^�m�n = int.Parse(s���^�o�דo�^�m�n);
					���.ShowDialog(this);
				}
				else
				{
					���^�o�דo�^ ��� = new ���^�o�דo�^();
					���.Left = this.Left;
					���.Top = this.Top;
					���.ShowDialog(this);
				}
// MOD 2005.05.20 ���s�j�ɉ� �N�C�b�N�G���g���V���[�g�J�b�g�Ή� END
			}
// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� START
			if( File.Exists(gsInitSyukka) && gs�v�����^�e�f == "1"){
				btn�����o��        .Visible = true;
				btn�����o�̓t�H���_.Visible = true;
			}else{
				btn�����o��        .Visible = false;
				btn�����o�̓t�H���_.Visible = false;
			}
			�o�ׂb�r�u�����o�͉ߋ��t�@�C���폜();
// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� END
// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� START
			if(gb�����o�͂n�m){
				lab�����o�͂n�m.Visible = true;
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
				pic�����׎D���s.Visible   = false;
				pic�`���C�X�v�����g.Visible = false;
				pic�Ĕ��s.Visible           = false;
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
// MOD 2010.06.01 ���s�j���� �����o�̓{�^���̈ړ� START
				pic�����o�דo�^.Visible     = false;
// MOD 2010.06.01 ���s�j���� �����o�̓{�^���̈ړ� END
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� START
				pic�o�[�R�[�h�ǎ�.Visible   = false;
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� END
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� START
				pic���x���C���[�W���.Visible = false;
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� END
			}
			else
			{
				lab�����o�͂n�m.Visible = false;
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
				if(gs�v�����^�e�f == "1"){
					pic�����׎D���s.Visible   = true;
					pic�`���C�X�v�����g.Visible = true;
					pic�Ĕ��s.Visible           = true;
				}
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� START
				// �G���g���[�I�v�V�����ɐݒ肵���l�ɂ��A���Y�{�^���̕\���E��\����؂�ւ���
				if(gs�I�v�V����[22].Equals("0"))
				{
					pic�o�[�R�[�h�ǎ�.Visible = true;
				}
				else
				{
					pic�o�[�R�[�h�ǎ�.Visible = false;
				}
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� END
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� START
				pic���x���C���[�W���.Visible = true;
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� END
// MOD 2010.06.01 ���s�j���� �����o�̓{�^���̈ړ� START
				pic�����o�דo�^.Visible     = true;
// MOD 2010.06.01 ���s�j���� �����o�̓{�^���̈ړ� END
			}
// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� END
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
			i�b�r�u�G���g���[�`�� = 1;
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
		}

		private void setButtonImage(PictureBox picButton, string sImage)
		{
			try
			{
				picButton.Image = Bitmap.FromFile(sImage);
			}
			catch(System.IO.FileNotFoundException)
			{
				// �t�@�C�������݂��Ȃ��ꍇ
				picButton.BackColor = Color.PaleGreen;
			}
		}

		private void btn�I��_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� START
			�[�����Ƃ̏����ݒ�t�@�C���ۑ�();
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� END
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
// MOD 2011.08.03 ���s�j���� �I�����Ɏ����o�͂������ɂȂ��Q�Ή� START
//			if(gb�����o�͂n�m) gb�����o�͂n�m = false;
			bool b�����o�͏I������� = gb�����o�͂n�m;
			if(gb�����o�͂n�m){
				���O�o�͂Q(" �I�������� �����o�͂n�e�e");
				gb�����o�͂n�m = false;
			}
// MOD 2011.08.03 ���s�j���� �I�����Ɏ����o�͂������ɂȂ��Q�Ή� END
//			if(g�����o�^ != null){
				if(trd1 != null && trd1.IsAlive){
					//�T�b�܂ő҂�
					for(int iCnt = 0;iCnt < 5; iCnt++){
						if(trd1 == null) break;
						if(trd1.IsAlive == false) break;
						Thread.Sleep(1000); // 1�b�҂�
					}
				}
				while(trd1 != null && trd1.IsAlive){
					if(trd1 != null && trd1.IsAlive){
						�r�[�v��();
						DialogResult dlgRst = MessageBox.Show(
							"�����o�͂����s���ł��������I�����܂����H\n"
							+ "�i[������]�̏ꍇ�́A�U�O�b�܂ő҂��܂��j"
							, "�I��"
							, MessageBoxButtons.YesNo
							, MessageBoxIcon.Warning);
						if(dlgRst == DialogResult.Yes){
							break;
						}
					}
					//�U�O�b�܂ő҂�
					for(int iCnt = 0;iCnt < 60; iCnt++){
						if(trd1 == null) break;
						if(trd1.IsAlive == false) break;
						Thread.Sleep(1000); // 1�b�҂�
					}
				}
//			}
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
			i�I���e�f = 0;
			if(gs�v�����^�e�f == "1")
			{
// MOD 2005.06.30 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� START
//				���o�׃f�[�^���s();
				try
				{
					���o�׃f�[�^���s();
				}
				catch (System.Net.WebException)
				{
					�r�[�v��();
					MessageBox.Show(gs�ʐM�G���[, 
									"�ʐM�G���[", 
									MessageBoxButtons.OK, MessageBoxIcon.Error);
					i�I���e�f = 1;
				}
				catch (Exception ex)
				{
					�r�[�v��();
					MessageBox.Show(ex.Message, 
									"�ʐM�G���[", 
									MessageBoxButtons.OK, MessageBoxIcon.Error);
					i�I���e�f = 1;
				}
				// �J�[�\�����f�t�H���g�ɖ߂�
				Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2005.06.30 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� END
			}
			else
			{
				DialogResult result = MessageBox.Show("�I�����܂����H", "�I��", 
					MessageBoxButtons.YesNo);
// MOD 2011.08.03 ���s�j���� �I�����Ɏ����o�͂������ɂȂ��Q�Ή� START
//				if (result == DialogResult.Yes)
//					Application.Exit();
//				else
//					return;
				if(result == DialogResult.Yes){
					Application.Exit();
				}else{
					if(b�����o�͏I�������){
						���O�o�͂Q(" �I�������� �����o�͂n�m");
						gb�����o�͂n�m = true;
					}
					return;
				}
// MOD 2011.08.03 ���s�j���� �I�����Ɏ����o�͂������ɂȂ��Q�Ή� END
			}

			if(i�I���e�f == 0)
			{
//				Application.Exit();
// MOD 2007.02.08 ���s�j���� �N���C�A���g�A�v���̍����� START
//// ADD 2005.06.30 ���s�j�����J �[���}�X�^�X�V START
//				try
//				{
//					if(sv_init == null) sv_init = new is2init.Service1();
//					string[] sRet = sv_init.Upd_tanmatu(gsa���[�U,gs���p�҂b�c);
//					Application.Exit();
//				}
//				catch
//				{
//					Application.Exit();
//				}
//// ADD 2005.06.30 ���s�j�����J �[���}�X�^�X�V END
				Application.Exit();
// MOD 2007.02.08 ���s�j���� �N���C�A���g�A�v���̍����� END
			}
			else
			{
				DialogResult result = MessageBox.Show("�I�����܂����H", "�I��", 
					MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
				{
//					Application.Exit();
// MOD 2007.02.08 ���s�j���� �N���C�A���g�A�v���̍����� START
//// ADD 2005.06.30 ���s�j�����J �[���}�X�^�X�V START
//					try
//					{
//						if(sv_init == null) sv_init = new is2init.Service1();
//						string[] sRet = sv_init.Upd_tanmatu(gsa���[�U,gs���p�҂b�c);
//						Application.Exit();
//					}
//					catch
//					{
//						Application.Exit();
//					}
//// ADD 2005.06.30 ���s�j�����J �[���}�X�^�X�V END
					Application.Exit();
// MOD 2007.02.08 ���s�j���� �N���C�A���g�A�v���̍����� END
// MOD 2011.08.03 ���s�j���� �I�����Ɏ����o�͂������ɂȂ��Q�Ή� START
				}else{
					if(b�����o�͏I�������){
						���O�o�͂Q(" �I�������� �����o�͂n�m");
						gb�����o�͂n�m = true;
					}
// MOD 2011.08.03 ���s�j���� �I�����Ɏ����o�͂������ɂȂ��Q�Ή� END
				}
			}
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lab����.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

		// ���̃C�x���g�̔����Ԋu�@�@0.01�b
		// �i���b�Z�[�W���e�X�V�Ԋu�i�T�[�o�ʐM�Ԋu�@�@30���j
		private void tim���b�Z�[�W_Tick(object sender, System.EventArgs e)
		{
			if(b���b�Z�[�W�X�V��) return;
			b���b�Z�[�W�X�V�� = true;

			if(i���b�Z�[�W�X�V�b�m�s == 0){
				string[] sRet = {""};
				try
				{
					if(sv_init == null) sv_init = new is2init.Service1();
					sRet = sv_init.Get_message(gsa���[�U, gs����b�c, gs����b�c);
					if(sRet[0].Length == 4){
// MOD 2005.05.24 ���s�j���� �V�X�e�����b�Z�[�W�̒ǉ� START
//// MOD 2005.05.09 ���s�j���� ���b�Z�[�W�̕ύX START
////						gs���b�Z�[�W = new String('�@',25) + "�����m�点���@"
////									 + sRet[1] + "�@�@�@" + sRet[2];
//						gs���b�Z�[�W = new String('�@',25) + "�����m�点���@"
//									 + sRet[1];
//						if(sRet[1].Length == 0 && sRet[2].Length == 0)
//						{
//							lab���b�Z�[�W.Text = "";
//						}
//						else if(sRet[1].Length > 0 && sRet[2].Length > 0)
//						{
//							gs���b�Z�[�W += "�@�@�@";
//						}
//						gs���b�Z�[�W += sRet[2];
//// MOD 2005.05.09 ���s�j���� ���b�Z�[�W�̕ύX END
						if(sRet[1].Length == 0 && sRet[2].Length == 0 && sRet[3].Length == 0)
						{
							gs���b�Z�[�W       = "";
							lab���b�Z�[�W.Text = "";
// MOD 2016.01.15 BEVAS) ���{ WinXP��Ή��ɔ����Y���[���ւ̒��ӕ��\���Ή� START
							if(gsOSVer.StartsWith("5"))
							{
								//���O�C���[���̂n�r��Vista�����O�̏ꍇ�A�e���b�v��\������
								string s��Ή����b�Z�[�W = s��Ή����b�Z�[�W = "�����p�̃p�\�R���́A���r�s�`�q�|�Q�T�|�[�g�ΏۊO�n�r�ƂȂ�܂��B�ڂ����́A���m�点�u�y�d�v�z�v�������������@�w�o�ȑO�̒[���������p�̂��q�l�ցv�������������B";
								gs���b�Z�[�W = new String('�@', 31) + "�����m�点���@" + s��Ή����b�Z�[�W;
							}
// MOD 2016.01.15 BEVAS) ���{ WinXP��Ή��ɔ����Y���[���ւ̒��ӕ��\���Ή� END
						}
						else
						{
//							gs���b�Z�[�W = new String('�@',25) + "�����m�点���@" + sRet[1];
							gs���b�Z�[�W = new String('�@',31) + "�����m�点���@" + sRet[1];
							if(sRet[2].Length > 0)
							{
								if(sRet[1].Length > 0)
									gs���b�Z�[�W += "�@�@�@";
								gs���b�Z�[�W += sRet[2];
							}
							if(sRet[3].Length > 0)
							{
								if(sRet[1].Length > 0 || sRet[2].Length > 0)
									gs���b�Z�[�W += "�@�@�@";
								gs���b�Z�[�W += sRet[3];
							}
						}
// MOD 2005.05.24 ���s�j���� �V�X�e�����b�Z�[�W�̒ǉ� END
					}
// MOD 2016.01.15 BEVAS) ���{ WinXP��Ή��ɔ����Y���[���ւ̒��ӕ��\���Ή� START
					if(gs���b�Z�[�W.IndexOf("�����p�̃p�\�R���́A") >= 0)
					{
						//���O�C���[���̂n�r��Vista�����O
						lab���b�Z�[�W.ForeColor = Color.Crimson;
						lab���b�Z�[�W.Font = new Font(lab���b�Z�[�W.Font, FontStyle.Bold);
					}
					else
					{
						lab���b�Z�[�W.ForeColor = SystemColors.ControlText;
						lab���b�Z�[�W.Font = new Font(
							"�l�r �S�V�b�N",
							15.75F,
							System.Drawing.FontStyle.Regular,
							System.Drawing.GraphicsUnit.Point,
							((System.Byte)(128)));
					}
// MOD 2016.01.15 BEVAS) ���{ WinXP��Ή��ɔ����Y���[���ւ̒��ӕ��\���Ή� END
				}
				catch (Exception)
				{
					;
				}
			}
			i���b�Z�[�W�X�V�b�m�s++;
// MOD 2008.01.30 KCL) �X�{ �\���X�s�[�h�ύX START
////			if(i���b�Z�[�W�X�V�b�m�s == 6000){
//			////////////////////////////////////////////
//			// ���b�Z�[�W�X�V�Ԋu
//			// 36000 x 0.05 �� 1800�b �� 30��
//			////////////////////////////////////////////
//			if(i���b�Z�[�W�X�V�b�m�s == 36000)
			////////////////////////////////////////////
			// ���b�Z�[�W�X�V�Ԋu
			// cnt_limit x Interval �� 1800�b �� 30��
			////////////////////////////////////////////
			int cnt_limit = 1800000 / tim���b�Z�[�W.Interval;
			if(i���b�Z�[�W�X�V�b�m�s == cnt_limit)
// MOD 2008.01.30 KCL) �X�{ �\���X�s�[�h�ύX END
			{
				i���b�Z�[�W�X�V�b�m�s = 0;
			}
			b���b�Z�[�W�X�V�� = false;

//			if(gs���b�Z�[�W.Length > 32)
			if(gs���b�Z�[�W.Length > 31+7)
			{
				i���b�Z�[�W�b�m�s++;
//				if(i���b�Z�[�W�b�m�s <=  9)
//				if(i���b�Z�[�W�b�m�s <= 18)
				if(i���b�Z�[�W�b�m�s <= 10)
				{
//					lab���b�Z�[�W.Visible = false;
					lab���b�Z�[�W.Left -= 2;
//					lab���b�Z�[�W.Left -= 1;
//					lab���b�Z�[�W.Visible = true;
				}
				else
				{
					if(i���b�Z�[�W�\���ʒu < gs���b�Z�[�W.Length)
						i���b�Z�[�W�\���ʒu++;
					else
						i���b�Z�[�W�\���ʒu = 0;
					lab���b�Z�[�W.Visible = false;
//					lab���b�Z�[�W.Left += 18;
					lab���b�Z�[�W.Left += 20;
//					if(gs���b�Z�[�W.Length - i���b�Z�[�W�\���ʒu < 25)
					if(gs���b�Z�[�W.Length - i���b�Z�[�W�\���ʒu < 31)
						lab���b�Z�[�W.Text = gs���b�Z�[�W.Substring(i���b�Z�[�W�\���ʒu);
					else
//						lab���b�Z�[�W.Text = gs���b�Z�[�W.Substring(i���b�Z�[�W�\���ʒu,25);
						lab���b�Z�[�W.Text = gs���b�Z�[�W.Substring(i���b�Z�[�W�\���ʒu,31);
					lab���b�Z�[�W.Visible = true;
					i���b�Z�[�W�b�m�s = 0;
				}
			}
		}

		private void pic�o�דo�^_Click(object sender, System.EventArgs e)
		{
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
			�d�ʓ��͐���擾();
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
// ADD 2005.05.11 ���s�j���� �����悪�O�����̑Ή� START
			if(!��������擾()) return;
// ADD 2005.05.11 ���s�j���� �����悪�O�����̑Ή� END

// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			�o�דo�^ ��� = new �o�דo�^();
//			���.Left = this.Left;
//			���.Top = this.Top;
//			���.s�����e�f = "I";
//			this.Visible = false;
//			���.ShowDialog(this);
//			this.Visible = true;
			if (g�o�דo�^ == null)	 g�o�דo�^ = new �o�דo�^();
			g�o�דo�^.Left = this.Left;
			g�o�דo�^.Top = this.Top;
			g�o�דo�^.s�����e�f = "I";
			g�o�דo�^.i���^�m�n = 0;
			this.Visible = false;
			g�o�דo�^.ShowDialog(this);
			this.Visible = true;
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
		}

		private void pic���^�o�דo�^_Click(object sender, System.EventArgs e)
		{
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
			�d�ʓ��͐���擾();
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
// ADD 2005.05.11 ���s�j���� �����悪�O�����̑Ή� START
			if(!��������擾()) return;
// ADD 2005.05.11 ���s�j���� �����悪�O�����̑Ή� END

// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			���^�o�דo�^ ��� = new ���^�o�דo�^();
//			���.Left = this.Left;
//			���.Top = this.Top;
//			this.Visible = false;
//			���.ShowDialog(this);
//			this.Visible = true;
			if (g���o�o�^ == null)	 g���o�o�^ = new ���^�o�דo�^();
			g���o�o�^.Left = this.Left;
			g���o�o�^.Top = this.Top;
			this.Visible = false;
			g���o�o�^.ShowDialog(this);
			this.Visible = true;
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
		}

		private void pic�����׎D���s_Click(object sender, System.EventArgs e)
		{
//�ۗ� MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
//�ۗ�			�d�ʓ��͐���擾();
//�ۗ� MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
			if(gs�v�����^�e�f != "1") return;
// MOD 2005.06.08 ���s�j�����J ���b�Z�[�W�̏��Ԃ̕ύX START
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
			if(gb�����o�͂n�m) return;
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
//			DialogResult result = MessageBox.Show("�����s�̃��x����S�Ĕ��s���܂�", "���x�����", 
//				MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
//			if (result == DialogResult.OK)
//			{
// MOD 2005.06.30 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� START
//				�����׎D���s();
				try
				{
					�����׎D���s();
				}
				catch (System.Net.WebException)
				{
					�r�[�v��();
					MessageBox.Show(gs�ʐM�G���[, 
									"�ʐM�G���[", 
									MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception ex)
				{
					�r�[�v��();
					MessageBox.Show(ex.Message, 
									"�ʐM�G���[", 
									MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				// �J�[�\�����f�t�H���g�ɖ߂�
				Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2005.06.30 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� END
//			}
// MOD 2005.06.08 ���s�j�����J ���b�Z�[�W�̏��Ԃ̕ύX END
		}

		private void pic�`���C�X�v�����g_Click(object sender, System.EventArgs e)
		{
//�ۗ� MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
//�ۗ�			�d�ʓ��͐���擾();
//�ۗ� MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
			if(gs�v�����^�e�f != "1") return;
// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
			if(gb�����o�͂n�m) return;
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
//			�����s��� ��� = new �����s���();
//			���.Left = this.Left;
//			���.Top = this.Top;
			//�����s
//			���.s�^�C�g��   = "�`���C�X�v�����g";
//			���.s��Ԏ�� = gsa��Ԃb�c[1];
//			this.Visible = false;
//			���.ShowDialog(this);
//			this.Visible = true;
			if (g������� == null)	 g������� = new �����s���();
			g�������.Left = this.Left;
			g�������.Top = this.Top;
			g�������.s�^�C�g��  = "�`���C�X�v�����g";
			g�������.s��Ԏ��  = gsa��Ԃb�c[1];
			this.Visible = false;
			g�������.ShowDialog(this);
			this.Visible = true;
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
		}

		private void pic�Ĕ��s_Click(object sender, System.EventArgs e)
		{
//�ۗ� MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
//�ۗ�			�d�ʓ��͐���擾();
//�ۗ� MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
			if(gs�v�����^�e�f != "1") return;
// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
			if(gb�����o�͂n�m) return;
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
//			�����s��� ��� = new �����s���();
//			���.Left = this.Left;
//			���.Top = this.Top;
			//���s��
//			���.s�^�C�g��   = "�Ĕ��s";
//			���.s��Ԏ�� = "aa";
//			this.Visible = false;
//			���.ShowDialog(this);
//			this.Visible = true;
			if (g������� == null)	 g������� = new �����s���();
			g�������.Left = this.Left;
			g�������.Top = this.Top;
			g�������.s�^�C�g��  = "�Ĕ��s";
			g�������.s��Ԏ��  = "aa";
			this.Visible = false;
			g�������.ShowDialog(this);
			this.Visible = true;
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
		}

		private void pic�o�׏Ɖ�_Click(object sender, System.EventArgs e)
		{
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
			�d�ʓ��͐���擾();
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
// MOD 2005.05.20 ���s�j���� ��ʍ����� START
//			�o�׏Ɖ� ��� = new �o�׏Ɖ�();
//			���.Left = this.Left;
//			���.Top = this.Top;
//			this.Visible = false;
//			���.ShowDialog(this);
//			this.Visible = true;
			if (g�o�׏Ɖ� == null)	 g�o�׏Ɖ� = new �o�׏Ɖ�();
			g�o�׏Ɖ�.Left = this.Left;
			g�o�׏Ɖ�.Top = this.Top;
			this.Visible = false;
			g�o�׏Ɖ�.ShowDialog(this);
			this.Visible = true;
// MOD 2005.05.20 ���s�j���� ��ʍ����� END
		}

		private void pic�o�׎���_Click(object sender, System.EventArgs e)
		{
//�ۗ� MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
//�ۗ�			�d�ʓ��͐���擾();
//�ۗ� MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
			if (g�o�׎��� == null)	 g�o�׎��� = new �o�׎���();
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� START
//			g�o�׎���.Left = this.Left + (this.Width  - g�o�׎���.Width)  / 2;
//			g�o�׎���.Top  = this.Top  + (this.Height - g�o�׎���.Height) / 2;
// MOD 2010.02.04 ���s�j���� �o�׎��щ�ʂ̃Z���^�����O START
//			g�o�׎���.Left = this.Left;
			g�o�׎���.Left = this.Left + (this.Width  - g�o�׎���.Width)  / 2;
// MOD 2010.02.04 ���s�j���� �o�׎��щ�ʂ̃Z���^�����O END
			g�o�׎���.Top  = this.Top;
// MOD 2009.11.06 ���s�j���� ���������ɐ�����A���͂���A���q�l�ԍ���ǉ� END
			g�o�׎���.ShowDialog();
		}

// ADD 2005.05.20 ���s�j�ɉ� �����o�דo�^�ǉ��̑Ή� START
		private void pic�����o�דo�^_Click(object sender, System.EventArgs e)
		{
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
			�d�ʓ��͐���擾();
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			�����o�דo�^ ��� = new �����o�דo�^();
//			���.Left = this.Left;
//			���.Top = this.Top;
//			this.Visible = false;
//			���.ShowDialog(this);
//			this.Visible = true;
// MOD 2010.06.01 ���s�j���� �����o�̓{�^���̈ړ� START
			if(gb�����o�͂n�m) return;
// MOD 2010.06.01 ���s�j���� �����o�̓{�^���̈ړ� END
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
			if (g�����o�^ == null)	 g�����o�^ = new �����o�דo�^();
			g�����o�^.Left = this.Left;
			g�����o�^.Top = this.Top;
			this.Visible = false;
			g�����o�^.ShowDialog(this);
// MOD 2010.06.01 ���s�j���� �����o�̓{�^���̈ړ� START
//// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� START
//			if(gb�����o�͂n�m){
//				lab�����o�͂n�m.Visible = true;
//// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
//				pic�����׎D���s.Visible   = false;
//				pic�`���C�X�v�����g.Visible = false;
//				pic�Ĕ��s.Visible           = false;
//// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
//			}else{
//				lab�����o�͂n�m.Visible = false;
//// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
//				if(gs�v�����^�e�f == "1"){
//					pic�����׎D���s.Visible   = true;
//					pic�`���C�X�v�����g.Visible = true;
//					pic�Ĕ��s.Visible           = true;
//				}
//// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
//			}
//// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� END
// MOD 2010.06.01 ���s�j���� �����o�̓{�^���̈ړ� END
			this.Visible = true;
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
		}
// ADD 2005.05.20 ���s�j�ɉ� �����o�דo�^�ǉ��̑Ή� END

		private void pic���͂�����_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			���͂���o�^ ��� = new ���͂���o�^();
//			���.Left = this.Left;
//			���.Top = this.Top;
//			this.Visible = false;
//			���.ShowDialog(this);
//			this.Visible = true;
			if (g�͐�o�^ == null)	 g�͐�o�^ = new ���͂���o�^();
			g�͐�o�^.Left = this.Left;
			g�͐�o�^.Top = this.Top;
			this.Visible = false;
			g�͐�o�^.ShowDialog(this);
			this.Visible = true;
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
		}

		private void pic���˗�����_Click(object sender, System.EventArgs e)
		{
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
			�d�ʓ��͐���擾();
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
			if(!��������擾()) return;

// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			���˗���o�^ ��� = new ���˗���o�^();
//			���.Left = this.Left;
//			���.Top = this.Top;
//			this.Visible = false;
//			���.ShowDialog(this);
//			this.Visible = true;
			if (g�˗��o�^ == null)	 g�˗��o�^ = new ���˗���o�^();
			g�˗��o�^.Left = this.Left;
			g�˗��o�^.Top = this.Top;
			g�˗��o�^.ShowInTaskbar = true;
			this.Visible = false;
			g�˗��o�^.ShowDialog(this);
			this.Visible = true;
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
		}

// MOD 2010.08.27 ���s�j���� ���˗���捞�i�b�r�u�j�@�\�ǉ� START
		private void pic���˗���捞_Click(object sender, System.EventArgs e)
		{
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
			�d�ʓ��͐���擾();
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
			if(!��������擾()) return;

			if (g�˗��捞 == null)	 g�˗��捞 = new ���˗���捞();
			g�˗��捞.Left = this.Left;
			g�˗��捞.Top = this.Top;
			g�˗��捞.ShowInTaskbar = true;
			this.Visible = false;
			g�˗��捞.ShowDialog(this);
			this.Visible = true;
		}
// MOD 2010.08.27 ���s�j���� ���˗���捞�i�b�r�u�j�@�\�ǉ� END

		private bool ��������擾()
		{
// ADD 2005.05.11 ���s�j���� �����悪�O�����̑Ή� START
			int iCntTokui  = 0;
// ADD 2005.05.11 ���s�j���� �����悪�O�����̑Ή� END
			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sRet = {""};
			try
			{
				tex���b�Z�[�W.Text = "��������擾���D�D�D";
				// ��������̎擾�igs����b�c�Ags����b�c�j
				if(sv_init == null) sv_init = new is2init.Service1();
				sRet = sv_init.Get_seikyu(gsa���[�U,gs����b�c, gs����b�c);
				tex���b�Z�[�W.Text = "";

				// �������񐔂̎擾
// MOD 2005.05.11 ���s�j���� �����悪�O�����̑Ή� START
//				int iCntTokui  = int.Parse(sRet[1]);
				iCntTokui  = int.Parse(sRet[1]);
// MOD 2005.05.11 ���s�j���� �����悪�O�����̑Ή� END
				// ��{���̍ŏI�C���f�b�N�X
				int iPos = 2;

				// ��������̐ݒ�
				if(iCntTokui > 0)
				{
					gsa������b�c     = new string[iCntTokui];
					gsa�����敔�ۂb�c = new string[iCntTokui];
					gsa�����敔�ۖ�   = new string[iCntTokui];
					for(int iCnt = 0; iCnt < iCntTokui; iCnt++)
					{
						gsa������b�c[iCnt]     = sRet[iPos++];
						gsa�����敔�ۂb�c[iCnt] = sRet[iPos++];
						gsa�����敔�ۖ�[iCnt]   = sRet[iPos++];
					}
				}
			}
// ADD 2005.05.24 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				sRet[0] = gs�ʐM�G���[;
			}
// ADD 2005.05.24 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				sRet[0] = "�ʐM�G���[�F" + ex.Message;
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;

			if(sRet[0].Length != 4)
			{
				MessageBox.Show(sRet[0], "��������擾", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
// ADD 2005.05.11 ���s�j���� �����悪�O�����̑Ή� START
			else if(iCntTokui == 0)
			{
				MessageBox.Show("�܂�������̓o�^�����肢�v���܂��B",
					"��������擾", MessageBoxButtons.OK, MessageBoxIcon.Error);
				pic������o�^_Click(null, null);
				return false;
			}
// ADD 2005.05.11 ���s�j���� �����悪�O�����̑Ή� END

			return true;
		}

		private void pic�L�����_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			�L������ ��� = new �L������();
//			���.Left = this.Left + (this.Width - ���.Width) / 2;
//			���.Top  = this.Top;
			// �^�C�g���̕ύX
//			���.Text                = "is-2 �L���o�^";
//			���.lab�L���^�C�g��.Text = "�L���o�^";
			// ADD 2005.05.16 ���s�j�ɉ� �i���L�� START
//			���.b�A���w�� = false;
			// ADD 2005.05.16 ���s�j�ɉ� �i���L�� END
//			���.ShowDialog();
			if (g�L������ == null)	 g�L������ = new �L������();
//			g�L������.Left = this.Left + (this.Width - g�L������.Width) / 2;
// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
//			g�L������.Left = this.Left + (this.Width - 396) / 2;
			g�L������.Left = this.Left + (this.Width - g�L������.Width) / 2;
// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� END
			g�L������.Top = this.Top;
			g�L������.Text                 = "is-2 �L���o�^";
			g�L������.lab�L���^�C�g��.Text = "�L���o�^";
			g�L������.b�A���w�� = false;
			g�L������.ShowDialog(this);
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
		}

		private void pic�[�����_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
// ADD 2005.07.21 ���s�j���� �X�����[�U�Ή� START
			// �X�����[�U�͒[���ύX�s��
			if(gs�����P == "T")
			{
				MessageBox.Show("���݂̃��[�U�ł͕ύX�ł��܂���B", "�[�����", 
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
// ADD 2005.07.21 ���s�j���� �X�����[�U�Ή� END

			�[�����擾();
// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			�[���o�^ ��� = new �[���o�^();
//			���.Left = this.Left + (this.Width  - ���.Width)  / 2;
//			���.Top  = this.Top  + (this.Height - ���.Height) / 2;
//			���.ShowDialog();
			if (g�[���o�^ == null)	 g�[���o�^ = new �[���o�^();
			g�[���o�^.Left = this.Left + (this.Width  - g�[���o�^.Width)  / 2;
			g�[���o�^.Top  = this.Top  + (this.Height - g�[���o�^.Height) / 2;
			g�[���o�^.ShowDialog(this);
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
// ADD 2005.05.31 ���s�j�����J �v�����^�Ȃ��Ȃ烁�j���[������ START
			if(gs�v�����^�e�f == "0")
			{
				pic�����׎D���s.Visible   = false;
				pic�`���C�X�v�����g.Visible = false;
				pic�Ĕ��s.Visible           = false;
			}
			else
			{
				pic�����׎D���s.Visible   = true;
				pic�`���C�X�v�����g.Visible = true;
				pic�Ĕ��s.Visible           = true;
			}
// ADD 2005.05.31 ���s�j�����J �v�����^�Ȃ��Ȃ烁�j���[������ END
// MOD 2010.06.01 ���s�j���� �����o�̓{�^���̈ړ� START
			if( File.Exists(gsInitSyukka) && gs�v�����^�e�f == "1"){
				btn�����o��        .Visible = true;
				btn�����o�̓t�H���_.Visible = true;
			}else{
				btn�����o��        .Visible = false;
				btn�����o�̓t�H���_.Visible = false;

				gb�����o�͂n�m              = false;
				���O�o�͂Q(" �����o�͂n�e�e");
				btn�����o��.Text = "�����o�� ON";
				lab�����o�͂n�m.Visible = false;
				pic�����o�דo�^.Visible     = true;
			}
			if(gb�����o�͂n�m){
				pic�����׎D���s.Visible   = false;
				pic�`���C�X�v�����g.Visible = false;
				pic�Ĕ��s.Visible           = false;
			}
// MOD 2010.06.01 ���s�j���� �����o�̓{�^���̈ړ� END
		}

		private void pic������o�^_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			������o�^ ��� = new ������o�^();
//			���.Left = this.Left + (this.Width - ���.Width) / 2;
//			���.Top = this.Top;
//			���.ShowDialog();
			if (g�����o�^ == null)	 g�����o�^ = new ������o�^();
			g�����o�^.Left = this.Left + (this.Width - g�����o�^.Width) / 2;
			g�����o�^.Top  = this.Top;
			g�����o�^.ShowDialog(this);
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
		}

		private void pic�ː��ؑ�_Click(object sender, System.EventArgs e)
		{
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
			�d�ʓ��͐���擾();
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			�ː��؂�ւ� ��� = new �ː��؂�ւ�();
//			���.Left = this.Left + (this.Width  - ���.Width)  / 2;
//			���.Top  = this.Top  + (this.Height - ���.Height) / 2;
//			���.ShowDialog();
			if (g�ː��ؑ� == null)	 g�ː��ؑ� = new �ː��؂�ւ�();
// MOD 2010.05.24 ���s�j���� 120DPI�Ή����̕\���ʒu���� START
//			g�ː��ؑ�.Left = this.Left + (this.Width  - g�ː��ؑ�.Width)  / 2;
//			g�ː��ؑ�.Top  = this.Top  + (this.Height - g�ː��ؑ�.Height) / 2;
			g�ː��ؑ�.Left = this.Left;
			g�ː��ؑ�.Top  = this.Top;
// MOD 2010.05.24 ���s�j���� 120DPI�Ή����̕\���ʒu���� END
			g�ː��ؑ�.ShowDialog(this);
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
			�I�v�V�������擾();
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� END
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� START
			//�G���g���[�I�v�V�����ɐݒ肵���l�Ǝ����o�͂��n�m���ǂ����ɂ��A
			//���Y�{�^���̕\���E��\����؂�ւ���
			if(gb�����o�͂n�m)
			{
				//�����o�͂��n�m �� �{�^���͕K����\��
				pic�o�[�R�[�h�ǎ�.Visible = false;
			}
			else
			{
				//�����o�͂��n�e�e
				if(gs�I�v�V����[22].Equals("0"))
				{
					pic�o�[�R�[�h�ǎ�.Visible = true;
				}
				else
				{
					pic�o�[�R�[�h�ǎ�.Visible = false;
				}
			}
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� END
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
			�d�ʓ��͐���擾();
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END
		}

		private void btn�p�X���[�h�ύX_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			�p�X���[�h�ύX ��� = new �p�X���[�h�ύX();
//			���.Left = this.Left;
//			���.Top = this.Bottom - ���.Height;
//			���.Left = this.Left + (this.Width  - ���.Width)  / 2;
//			���.Top  = this.Top  + (this.Height - ���.Height) / 2;
//			���.ShowDialog();
			if (g�p�X�ύX == null)	 g�p�X�ύX = new �p�X���[�h�ύX();
			g�p�X�ύX.Left = this.Left + (this.Width  - g�p�X�ύX.Width)  / 2;
			g�p�X�ύX.Top  = this.Top  + (this.Height - g�p�X�ύX.Height) / 2;
			g�p�X�ύX.ShowDialog(this);
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
		}

		private void btn����ύX_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
			������擾();
//			����ύX ��� = new ����ύX();
//			���.Left = this.Left;
// MOD 2005.05.20 ���s�j���� ��ʍ����� START
//			����ύX�Q ��� = new ����ύX�Q();
//			���.Left = this.Left + (this.Width - ���.Width) / 2;
//			���.Top = this.Top + 68;
//			���.ShowDialog();
			if (g����ύX == null)	 g����ύX = new ����ύX�Q();

			g����ύX.Left = this.Left + (this.Width - g����ύX.Width) / 2;
			g����ύX.Top = this.Top + 68;
// MOD 2016.05.24 BEVAS�j���{ �Z�N�V�����ؑ։�ʉ��C�Ή� START
			g����ύX.s����R�[�h = "";
			g����ύX.s���喼 = "";
// MOD 2016.05.24 BEVAS�j���{ �Z�N�V�����ؑ։�ʉ��C�Ή� END
			g����ύX.ShowDialog();
// MOD 2005.05.20 ���s�j���� ��ʍ����� END
// ADD 2009.04.02 ���s�j���� �ғ����Ή� START
			�ғ������擾();
// ADD 2009.04.02 ���s�j���� �ғ����Ή� END
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
			�I�v�V�������擾();
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� END
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
			�d�ʓ��͐���擾();
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END

			// �w�b�_�[���ڂ̐ݒ�
// DEL 2005.06.02 ���s�j�����J �폜 START
//			tex���p�Җ�.Text = gs���p�Җ�;
// DEL 2005.06.02 ���s�j�����J �폜 END
// DEL 2005.05.13 ���s�j�����J ������ɕύX START
//			tex���喼.Text   = gs����b�c + " " + gs���喼;
// DEL 2005.05.13 ���s�j�����J ������ɕύX END

// ADD 2005.05.09 ���s�j���� ���b�Z�[�W�̕ύX START
			// ���b�Z�[�W�̎擾���s��
			i���b�Z�[�W�X�V�b�m�s = 0;
// ADD 2005.05.09 ���s�j���� ���b�Z�[�W�̕ύX END
// ADD 2006.12.12 ���s�j�����J �Z�N�V�������ύX START
			tex���喼.Text   = gs����b�c + " " + gs���喼;
// ADD 2006.12.12 ���s�j�����J �Z�N�V�������ύX END
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� START
			//�G���g���[�I�v�V�����ɐݒ肵���l�Ǝ����o�͂��n�m���ǂ����ɂ��A
			//���Y�{�^���̕\���E��\����؂�ւ���
			if(gb�����o�͂n�m)
			{
				//�����o�͂��n�m �� �{�^���͕K����\��
				pic�o�[�R�[�h�ǎ�.Visible = false;
			}
			else
			{
				//�����o�͂��n�e�e
				if(gs�I�v�V����[22].Equals("0"))
				{
					pic�o�[�R�[�h�ǎ�.Visible = true;
				}
				else
				{
					pic�o�[�R�[�h�ǎ�.Visible = false;
				}
			}
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� END
		}

		private void pic���͐�捞_MouseEnter(object sender, System.EventArgs e)
		{
			pic���͐�捞.Image        = imageCmd[3,2,1];
		}

		private void pic���͐�捞_MouseLeave(object sender, System.EventArgs e)
		{
			pic���͐�捞.Image        = imageCmd[3,2,0];
		}

		private void pic���͐�捞_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
// MOD 2005.05.24 ���s�j�����J ��ʍ����� START
//			���͂���捞 ��� = new ���͂���捞();
//			���.Left = this.Left;
//			���.Top = this.Top;
//			this.Visible = false;
//			���.ShowDialog(this);
//			this.Visible = true;
			if (g�͐�捞 == null)	 g�͐�捞 = new ���͂���捞();
			g�͐�捞.Left = this.Left;
			g�͐�捞.Top = this.Top;
			this.Visible = false;
			g�͐�捞.ShowDialog(this);
			this.Visible = true;
// MOD 2005.05.24 ���s�j�����J ��ʍ����� END
		}
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
		private string [] ���m�点�ڍד��e�擾(string s�o�^��, string s�V�[�P���X�m��) 
		{
			string [] sResults = new string[3];

			// �����ݒ�
			string [] sKey = new string [2];
			sKey[0] = s�o�^��;
			sKey[1] = s�V�[�P���X�m��;

			// ���m�点���擾
			string [] sRet = null;
			try
			{
				if (sv_oshirase == null) sv_oshirase = new IS2Client.is2oshirase.Service1();
				sRet = sv_oshirase.Sel_Oshirase(gsa���[�U, sKey);
			}
			catch (System.Net.WebException)
			{
				// �ʐM�G���[����
				sRet[0] = gs�ʐM�G���[;
			}
			catch (Exception ex)
			{
				// ���̑��̃G���[����
				sRet[0] = "�ʐM�G���[�F" + ex.Message;
			}

			// ���ʏ���
			switch (sRet[0].Trim()) 
			{
				case "����I��" :	// ����I���̏ꍇ

					// �ڍד��e�A�{�^�����A�A�h���X��Ԃ�
					sResults[0] = sRet[3].Replace("\n", "\r\n");		// �ڍד��e
					sResults[1] = sRet[4];								// �{�^����
					sResults[2] = sRet[5];								// �A�h���X

					break;

				default :			// �ُ�I���̏ꍇ

					// �󕶎����Ԃ�
					sResults[0] = sResults[1] = sResults[2] = string.Empty;
					// �x����
					�r�[�v��();
					// �G���[���b�Z�[�W�\��
					tex���b�Z�[�W.Text = sRet[0];

					break;
			}

			return sResults;
		}
		private void pic���m�点�P_Click(object sender, System.EventArgs e)
		{
			if (s���m�点�ꗗ.Length > 0) 
			{
				this.���m�点�ڍו\��(1);
			}
		}

		private void pic���m�点�Q_Click(object sender, System.EventArgs e)
		{
			if (s���m�点�ꗗ.Length > 1) 
			{
				this.���m�点�ڍו\��(2);
			}
		}

		private void pic���m�点�R_Click(object sender, System.EventArgs e)
		{
			if (s���m�点�ꗗ.Length > 2) 
			{
				this.���m�点�ڍו\��(3);
			}
		}

		private void pic���m�点�S_Click(object sender, System.EventArgs e)
		{
			if (s���m�点�ꗗ.Length > 3) 
			{
				this.���m�点�ڍו\��(4);
			}
		}

		private void pic���m�点�T_Click(object sender, System.EventArgs e)
		{
			if (s���m�点�ꗗ.Length > 4) 
			{
				this.���m�点�ڍו\��(5);
			}
		}

		private void ���m�点�ڍו\��(int no) 
		{
			int idx = no - 1;

			if (g���m�\�� == null) g���m�\�� = new ���m�点�\��();
			g���m�\��.s�o�^��	= s���m�点�ꗗ[idx][0];
			g���m�\��.s�\��		= s���m�点�ꗗ[idx][1];
			string [] naiyo		= this.���m�点�ڍד��e�擾(s���m�点�ꗗ[idx][2], s���m�点�ꗗ[idx][3]);
			g���m�\��.s�ڍד��e	= naiyo[0];
			g���m�\��.s�{�^����  = naiyo[1];
			g���m�\��.s�A�h���X	= naiyo[2];
			g���m�\��.Top		= this.Top;
			g���m�\��.Left		= this.Left;
			this.Visible		= false;
			g���m�\��.ShowDialog(this);
			this.Visible		= true;
		}
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END

		private void pic�o�דo�^_MouseEnter(object sender, System.EventArgs e)
		{
			pic�o�דo�^.Image        = imageCmd[1,1,1];
		}

		private void pic�o�דo�^_MouseLeave(object sender, System.EventArgs e)
		{
			pic�o�דo�^.Image        = imageCmd[1,1,0];
		}

		private void pic���^�o�דo�^_MouseEnter(object sender, System.EventArgs e)
		{
			pic���^�o�דo�^.Image    = imageCmd[1,2,1];
		}

		private void pic���^�o�דo�^_MouseLeave(object sender, System.EventArgs e)
		{
			pic���^�o�דo�^.Image    = imageCmd[1,2,0];
		}

		private void pic�����׎D���s_MouseEnter(object sender, System.EventArgs e)
		{
			pic�����׎D���s.Cursor = Cursors.Default;
			if(gs�v�����^�e�f != "1") return;
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
			if(gb�����o�͂n�m) return;
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
			pic�����׎D���s.Cursor = Cursors.Hand;
			pic�����׎D���s.Image  = imageCmd[1,4,1];
		}

		private void pic�����׎D���s_MouseLeave(object sender, System.EventArgs e)
		{
			if(gs�v�����^�e�f != "1") return;
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
			if(gb�����o�͂n�m) return;
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
			pic�����׎D���s.Image  = imageCmd[1,4,0];
		}

		private void pic�`���C�X�v�����g_MouseEnter(object sender, System.EventArgs e)
		{
			pic�`���C�X�v�����g.Cursor = Cursors.Default;
			if(gs�v�����^�e�f != "1") return;
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
			if(gb�����o�͂n�m) return;
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
			pic�`���C�X�v�����g.Cursor = Cursors.Hand;
			pic�`���C�X�v�����g.Image  = imageCmd[1,5,1];
		}

		private void pic�`���C�X�v�����g_MouseLeave(object sender, System.EventArgs e)
		{
			if(gs�v�����^�e�f != "1") return;
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
			if(gb�����o�͂n�m) return;
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
			pic�`���C�X�v�����g.Image  = imageCmd[1,5,0];
		}

		private void pic�Ĕ��s_MouseEnter(object sender, System.EventArgs e)
		{
			pic�Ĕ��s.Cursor = Cursors.Default;
			if(gs�v�����^�e�f != "1") return;
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
			if(gb�����o�͂n�m) return;
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
			pic�Ĕ��s.Cursor = Cursors.Hand;
			pic�Ĕ��s.Image  = imageCmd[2,3,1];
		}

		private void pic�Ĕ��s_MouseLeave(object sender, System.EventArgs e)
		{
			if(gs�v�����^�e�f != "1") return;
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
			if(gb�����o�͂n�m) return;
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
			pic�Ĕ��s.Image  = imageCmd[2,3,0];
		}

		private void pic�o�׏Ɖ�_MouseEnter(object sender, System.EventArgs e)
		{
			pic�o�׏Ɖ�.Image        = imageCmd[2,1,1];
		}

		private void pic�o�׏Ɖ�_MouseLeave(object sender, System.EventArgs e)
		{
			pic�o�׏Ɖ�.Image        = imageCmd[2,1,0];
		}

		private void pic�o�׎���_MouseEnter(object sender, System.EventArgs e)
		{
			pic�o�׎���.Image        = imageCmd[2,2,1];
		}

		private void pic�o�׎���_MouseLeave(object sender, System.EventArgs e)
		{
			pic�o�׎���.Image        = imageCmd[2,2,0];
		}

		private void pic�����o�דo�^_MouseEnter(object sender, System.EventArgs e)
		{
			pic�����o�דo�^.Image    = imageCmd[1,3,1];
		}

		private void pic�����o�דo�^_MouseLeave(object sender, System.EventArgs e)
		{
			pic�����o�דo�^.Image    = imageCmd[1,3,0];
		}

		private void pic���͂�����_MouseEnter(object sender, System.EventArgs e)
		{
			pic���͂�����.Image    = imageCmd[3,1,1];
		}

		private void pic���͂�����_MouseLeave(object sender, System.EventArgs e)
		{
			pic���͂�����.Image    = imageCmd[3,1,0];
		}

		private void pic���˗�����_MouseEnter(object sender, System.EventArgs e)
		{
			pic���˗�����.Image    = imageCmd[3,3,1];
		}

		private void pic���˗�����_MouseLeave(object sender, System.EventArgs e)
		{
			pic���˗�����.Image    = imageCmd[3,3,0];
		}
// MOD 2010.08.27 ���s�j���� ���˗���捞�i�b�r�u�j�@�\�ǉ� START
		private void pic���˗���捞_MouseEnter(object sender, System.EventArgs e)
		{
			pic���˗���捞.Image    = imageCmd[3,4,1];
		}

		private void pic���˗���捞_MouseLeave(object sender, System.EventArgs e)
		{
			pic���˗���捞.Image    = imageCmd[3,4,0];
		}
// MOD 2010.08.27 ���s�j���� ���˗���捞�i�b�r�u�j�@�\�ǉ� END

		private void pic�L�����_MouseEnter(object sender, System.EventArgs e)
		{
			pic�L�����.Image        = imageCmd[4,1,1];
		}

		private void pic�L�����_MouseLeave(object sender, System.EventArgs e)
		{
			pic�L�����.Image        = imageCmd[4,1,0];
		}

		private void pic�[�����_MouseEnter(object sender, System.EventArgs e)
		{
			pic�[�����.Image        = imageCmd[4,3,1];
		}

		private void pic�[�����_MouseLeave(object sender, System.EventArgs e)
		{
			pic�[�����.Image        = imageCmd[4,3,0];
		}

		private void pic������o�^_MouseEnter(object sender, System.EventArgs e)
		{
			pic������o�^.Image      = imageCmd[4,2,1];
		}

		private void pic������o�^_MouseLeave(object sender, System.EventArgs e)
		{
			pic������o�^.Image      = imageCmd[4,2,0];
		}

		private void pic�ː��ؑ�_MouseEnter(object sender, System.EventArgs e)
		{
			pic�ː��ؑ�.Image        = imageCmd[4,4,1];
		}

		private void pic�ː��ؑ�_MouseLeave(object sender, System.EventArgs e)
		{
			pic�ː��ؑ�.Image        = imageCmd[4,4,0];
		}

// DEL 2008.02.08 KCL) �X�{ ���m�点�C�� START
//// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
//		private void pic���m�点�P_MouseEnter(object sender, System.EventArgs e)
//		{
//			pic���m�点�P.Image        = imageCmd[5,1,1];
//			lab���m�点�P.ForeColor    = this._SelectedColor;
//		}
//
//		private void pic���m�点�P_MouseLeave(object sender, System.EventArgs e)
//		{
//			pic���m�点�P.Image        = imageCmd[5,1,0];
//			lab���m�点�P.ForeColor    = this._UnSelectedColor1;
//		}
//
//		private void pic���m�点�Q_MouseEnter(object sender, System.EventArgs e)
//		{
//			pic���m�点�Q.Image        = imageCmd[5,1,1];
//			lab���m�点�Q.ForeColor    = this._SelectedColor;
//		}
//
//		private void pic���m�点�Q_MouseLeave(object sender, System.EventArgs e)
//		{
//			pic���m�点�Q.Image        = imageCmd[5,1,0];
//			lab���m�点�Q.ForeColor    = this._UnSelectedColor2;
//		}
//
//		private void pic���m�点�R_MouseEnter(object sender, System.EventArgs e)
//		{
//			pic���m�点�R.Image        = imageCmd[5,1,1];
//			lab���m�点�R.ForeColor    = this._SelectedColor;
//		}
//
//		private void pic���m�点�R_MouseLeave(object sender, System.EventArgs e)
//		{
//			pic���m�点�R.Image        = imageCmd[5,1,0];
//			lab���m�点�R.ForeColor    = this._UnSelectedColor1;
//		}
//
//		private void pic���m�点�S_MouseEnter(object sender, System.EventArgs e)
//		{
//			pic���m�点�S.Image        = imageCmd[5,1,1];
//			lab���m�点�S.ForeColor    = this._SelectedColor;
//		}
//
//		private void pic���m�点�S_MouseLeave(object sender, System.EventArgs e)
//		{
//			pic���m�点�S.Image        = imageCmd[5,1,0];
//			lab���m�点�S.ForeColor    = this._UnSelectedColor2;
//		}
//
//		private void pic���m�点�T_MouseEnter(object sender, System.EventArgs e)
//		{
//			pic���m�点�T.Image        = imageCmd[5,1,1];
//			lab���m�点�T.ForeColor    = this._SelectedColor;
//		}
//
//		private void pic���m�点�T_MouseLeave(object sender, System.EventArgs e)
//		{
//			pic���m�点�T.Image        = imageCmd[5,1,0];
//			lab���m�点�T.ForeColor    = this._UnSelectedColor1;
//		}
//// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
// DEL 2008.02.08 KCL) �X�{ ���m�点�C�� START


		private void pic���j���[�P_MouseEnter(object sender, System.EventArgs e)
		{
			pic���j���[�P.Image = imageMenu[0,1];
		}

		private void pic���j���[�P_MouseLeave(object sender, System.EventArgs e)
		{
			if(pan���j���[�P.Visible == false)
				pic���j���[�P.Image = imageMenu[0,0];
		}

		private void pic���j���[�Q_MouseEnter(object sender, System.EventArgs e)
		{
			pic���j���[�Q.Image = imageMenu[1,1];
		}

		private void pic���j���[�Q_MouseLeave(object sender, System.EventArgs e)
		{
			if(pan���j���[�Q.Visible == false)
				pic���j���[�Q.Image = imageMenu[1,0];
		}

		private void pic���j���[�R_MouseEnter(object sender, System.EventArgs e)
		{
			pic���j���[�R.Image = imageMenu[2,1];
		}

		private void pic���j���[�R_MouseLeave(object sender, System.EventArgs e)
		{
			if(pan���j���[�R.Visible == false)
				pic���j���[�R.Image = imageMenu[2,0];
		}

		private void pic���j���[�S_MouseEnter(object sender, System.EventArgs e)
		{
			pic���j���[�S.Image = imageMenu[3,1];
		}

		private void pic���j���[�S_MouseLeave(object sender, System.EventArgs e)
		{
			if(pan���j���[�S.Visible == false)
				pic���j���[�S.Image = imageMenu[3,0];
		}

/*		private void pic���j���[�T_MouseEnter(object sender, System.EventArgs e)
		{
			pic���j���[�T.Image = imageMenu[6,1];
		}

		private void pic���j���[�T_MouseLeave(object sender, System.EventArgs e)
		{
			if(pan���j���[�T.Visible == false)
				pic���j���[�T.Image = imageMenu[6,0];
		}
*/
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
		private void pic���j���[�U_MouseEnter(object sender, System.EventArgs e) 
		{
			pic���j���[�U.Image = imageMenu[6,1];
		}
		private void pic���j���[�U_MouseLeave(object sender, System.EventArgs e) 
		{
			if(pan���j���[�U.Visible == false)
				pic���j���[�U.Image = imageMenu[6,0];
		}
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
		private void pic���j���[�P_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� START
			if(gs���m�点�ē����b�Z�[�W.Length > 0){
				tex���b�Z�[�W.Text = gs���m�点�ē����b�Z�[�W;
			}
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� END
			pic���j���[�P.Image   = imageMenu[0,1];
			pic���j���[�Q.Image   = imageMenu[1,0];
			pic���j���[�R.Image   = imageMenu[2,0];
			pic���j���[�S.Image   = imageMenu[3,0];
//			pic���j���[�T.Image   = imageMenu[6,0];
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
			pic���j���[�U.Image   = imageMenu[6,0];
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
			pan���j���[�P.Visible = true;
			pan���j���[�Q.Visible = false;
			pan���j���[�R.Visible = false;
			pan���j���[�S.Visible = false;
//			pan���j���[�T.Visible = false;
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
			pan���j���[�U.Visible = false;
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
		}

		private void pic���j���[�Q_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� START
			if(gs���m�点�ē����b�Z�[�W.Length > 0){
				tex���b�Z�[�W.Text = gs���m�点�ē����b�Z�[�W;
			}
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� END
			pic���j���[�P.Image   = imageMenu[0,0];
			pic���j���[�Q.Image   = imageMenu[1,1];
			pic���j���[�R.Image   = imageMenu[2,0];
			pic���j���[�S.Image   = imageMenu[3,0];
//			pic���j���[�T.Image   = imageMenu[6,0];
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
			pic���j���[�U.Image   = imageMenu[6,0];
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
			pan���j���[�P.Visible = false;
			pan���j���[�Q.Visible = true;
			pan���j���[�R.Visible = false;
			pan���j���[�S.Visible = false;
//			pan���j���[�T.Visible = false;
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
			pan���j���[�U.Visible = false;
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
		}

		private void pic���j���[�R_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� START
			if(gs���m�点�ē����b�Z�[�W.Length > 0){
				tex���b�Z�[�W.Text = gs���m�点�ē����b�Z�[�W;
			}
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� END
			pic���j���[�P.Image   = imageMenu[0,0];
			pic���j���[�Q.Image   = imageMenu[1,0];
			pic���j���[�R.Image   = imageMenu[2,1];
			pic���j���[�S.Image   = imageMenu[3,0];
//			pic���j���[�T.Image   = imageMenu[6,0];
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
			pic���j���[�U.Image   = imageMenu[6,0];
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
			pan���j���[�P.Visible = false;
			pan���j���[�Q.Visible = false;
			pan���j���[�R.Visible = true;
			pan���j���[�S.Visible = false;
//			pan���j���[�T.Visible = false;
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
			pan���j���[�U.Visible = false;
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
		}

		private void pic���j���[�S_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� START
			if(gs���m�点�ē����b�Z�[�W.Length > 0){
				tex���b�Z�[�W.Text = gs���m�点�ē����b�Z�[�W;
			}
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� END
			pic���j���[�P.Image   = imageMenu[0,0];
			pic���j���[�Q.Image   = imageMenu[1,0];
			pic���j���[�R.Image   = imageMenu[2,0];
			pic���j���[�S.Image   = imageMenu[3,1];
//			pic���j���[�T.Image   = imageMenu[6,0];
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
			pic���j���[�U.Image   = imageMenu[6,0];
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
			pan���j���[�P.Visible = false;
			pan���j���[�Q.Visible = false;
			pan���j���[�R.Visible = false;
			pan���j���[�S.Visible = true;
//			pan���j���[�T.Visible = false;
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
			pan���j���[�U.Visible = false;
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
		}

/*		private void pic���j���[�T_Click(object sender, System.EventArgs e)
		{
			pic���j���[�P.Image   = imageMenu[0,0];
			pic���j���[�Q.Image   = imageMenu[1,0];
			pic���j���[�R.Image   = imageMenu[2,0];
			pic���j���[�S.Image   = imageMenu[3,0];
			pic���j���[�T.Image   = imageMenu[6,1];
			pan���j���[�P.Visible = false;
			pan���j���[�Q.Visible = false;
			pan���j���[�R.Visible = false;
			pan���j���[�S.Visible = false;
			pan���j���[�T.Visible = true;
		}
*/
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
		private void pic���j���[�U_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� START
			if(gs���m�点�ē����b�Z�[�W.Length > 0){
				tex���b�Z�[�W.Text = gs���m�点�ē����b�Z�[�W;
			}
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� END
			pic���j���[�P.Image   = imageMenu[0,0];
			pic���j���[�Q.Image   = imageMenu[1,0];
			pic���j���[�R.Image   = imageMenu[2,0];
			pic���j���[�S.Image   = imageMenu[3,0];
			pic���j���[�U.Image   = imageMenu[6,1];
			pan���j���[�P.Visible = false;
			pan���j���[�Q.Visible = false;
			pan���j���[�R.Visible = false;
			pan���j���[�S.Visible = false;
			pan���j���[�U.Visible = true;

			// ���m�点�̐ݒ�
			this.���m�点�̎擾�ƕ\��();
		}
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
// MOD 2005.05.27 ���s�j���� �X���b�h�ʒu�̈ړ� START
//		private void ���j���[�C���[�W�̏�����()
		private static void ���j���[�C���[�W�̏�����()
// MOD 2005.05.27 ���s�j���� �X���b�h�ʒu�̈ړ� END
		{
			if(imageMenu != null) return;

//			imageMenu = new Image[4,2];
// MOD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
//			imageMenu = new Image[6,2];
			imageMenu = new Image[8,2];
// MOD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
// MOD 2011.04.05 ���s�j���� ��ʃC���[�W�̃��[�h�ύX START
//			imageMenu[0,0] = Image.FromFile("img\\m1a.gif");
//			imageMenu[0,1] = Image.FromFile("img\\m1b.gif");
//			imageMenu[1,0] = Image.FromFile("img\\m2a.gif");
//			imageMenu[1,1] = Image.FromFile("img\\m2b.gif");
//			imageMenu[2,0] = Image.FromFile("img\\m3a.gif");
//			imageMenu[2,1] = Image.FromFile("img\\m3b.gif");
//			imageMenu[3,0] = Image.FromFile("img\\m4a.gif");
//			imageMenu[3,1] = Image.FromFile("img\\m4b.gif");
//			imageMenu[4,0] = Image.FromFile("img\\upperbar.gif");
//			imageMenu[4,1] = Image.FromFile("img\\sidebar.gif");
//			imageMenu[5,0] = Image.FromFile("img\\i-start.gif");
////		imageMenu[6,0] = Image.FromFile("img\\m5a.gif");
////		imageMenu[6,1] = Image.FromFile("img\\m5b.gif");
//// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
//			imageMenu[6,0] = Image.FromFile("img\\m6a.gif");
//			imageMenu[6,1] = Image.FromFile("img\\m6b.gif");
//// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
			imageMenu[0,0] = Image_FromFile("img\\m1a.gif");
			imageMenu[0,1] = Image_FromFile("img\\m1b.gif");
			imageMenu[1,0] = Image_FromFile("img\\m2a.gif");
			imageMenu[1,1] = Image_FromFile("img\\m2b.gif");
			imageMenu[2,0] = Image_FromFile("img\\m3a.gif");
			imageMenu[2,1] = Image_FromFile("img\\m3b.gif");
			imageMenu[3,0] = Image_FromFile("img\\m4a.gif");
			imageMenu[3,1] = Image_FromFile("img\\m4b.gif");
			imageMenu[4,0] = Image_FromFile("img\\upperbar.gif");
			imageMenu[4,1] = Image_FromFile("img\\sidebar.gif");
			imageMenu[5,0] = Image_FromFile("img\\i-start.gif");
			imageMenu[6,0] = Image_FromFile("img\\m6a.gif");
			imageMenu[6,1] = Image_FromFile("img\\m6b.gif");
// MOD 2011.04.05 ���s�j���� ��ʃC���[�W�̃��[�h�ύX END
		}

// MOD 2005.05.27 ���s�j���� �X���b�h�ʒu�̈ړ� START
//		private void �R�}���h�C���[�W�̏�����()
		private static void �R�}���h�C���[�W�̏�����()
// MOD 2005.05.27 ���s�j���� �X���b�h�ʒu�̈ړ� END
		{
			if(imageCmd != null) return;

			// �{���́A[5,5,2]�ł悢���o�f�㌩�₷�������[5,6,2]�Ƃ���
// MOD 2008.02.08 KCL) �X�{ ���m�点�C�� START
//// MOD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
////			imageCmd = new Image[5,6,2];
//			imageCmd = new Image[6,6,2];
//// MOD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
			imageCmd = new Image[5,6,2];
// MOD 2008.02.08 KCL) �X�{ ���m�点�C�� END
// MOD 2011.04.05 ���s�j���� ��ʃC���[�W�̃��[�h�ύX START
//			imageCmd[1,1,0] = Image.FromFile("img\\m101a.gif");
//			imageCmd[1,1,1] = Image.FromFile("img\\m101b.gif");
//			imageCmd[1,2,0] = Image.FromFile("img\\m102a.gif");
//			imageCmd[1,2,1] = Image.FromFile("img\\m102b.gif");
//			imageCmd[1,3,0] = Image.FromFile("img\\m103a.gif");
//			imageCmd[1,3,1] = Image.FromFile("img\\m103b.gif");
//			imageCmd[1,4,0] = Image.FromFile("img\\m104a.gif");
//			imageCmd[1,4,1] = Image.FromFile("img\\m104b.gif");
//			imageCmd[1,5,0] = Image.FromFile("img\\m105a.gif");
//			imageCmd[1,5,1] = Image.FromFile("img\\m105b.gif");
//
//			imageCmd[2,1,0] = Image.FromFile("img\\m201a.gif");
//			imageCmd[2,1,1] = Image.FromFile("img\\m201b.gif");
//			imageCmd[2,2,0] = Image.FromFile("img\\m202a.gif");
//			imageCmd[2,2,1] = Image.FromFile("img\\m202b.gif");
//			imageCmd[2,3,0] = Image.FromFile("img\\m203a.gif");
//			imageCmd[2,3,1] = Image.FromFile("img\\m203b.gif");
//
//			imageCmd[3,1,0] = Image.FromFile("img\\m301a.gif");
//			imageCmd[3,1,1] = Image.FromFile("img\\m301b.gif");
//			imageCmd[3,2,0] = Image.FromFile("img\\m302a.gif");
//			imageCmd[3,2,1] = Image.FromFile("img\\m302b.gif");
//			imageCmd[3,3,0] = Image.FromFile("img\\m303a.gif");
//			imageCmd[3,3,1] = Image.FromFile("img\\m303b.gif");
//// MOD 2010.08.27 ���s�j���� ���˗���捞�i�b�r�u�j�@�\�ǉ� START
//			imageCmd[3,4,0] = Image.FromFile("img\\m304a.gif");
//			imageCmd[3,4,1] = Image.FromFile("img\\m304b.gif");
//// MOD 2010.08.27 ���s�j���� ���˗���捞�i�b�r�u�j�@�\�ǉ� END
//			imageCmd[4,1,0] = Image.FromFile("img\\m401a.gif");
//			imageCmd[4,1,1] = Image.FromFile("img\\m401b.gif");
//			imageCmd[4,2,0] = Image.FromFile("img\\m402a.gif");
//			imageCmd[4,2,1] = Image.FromFile("img\\m402b.gif");
//			imageCmd[4,3,0] = Image.FromFile("img\\m403a.gif");
//			imageCmd[4,3,1] = Image.FromFile("img\\m403b.gif");
//			imageCmd[4,4,0] = Image.FromFile("img\\m404a.gif");
//			imageCmd[4,4,1] = Image.FromFile("img\\m404b.gif");
			imageCmd[1,1,0] = Image_FromFile("img\\m101a.gif");
			imageCmd[1,1,1] = Image_FromFile("img\\m101b.gif");
			imageCmd[1,2,0] = Image_FromFile("img\\m102a.gif");
			imageCmd[1,2,1] = Image_FromFile("img\\m102b.gif");
			imageCmd[1,3,0] = Image_FromFile("img\\m103a.gif");
			imageCmd[1,3,1] = Image_FromFile("img\\m103b.gif");
			imageCmd[1,4,0] = Image_FromFile("img\\m104a.gif");
			imageCmd[1,4,1] = Image_FromFile("img\\m104b.gif");
			imageCmd[1,5,0] = Image_FromFile("img\\m105a.gif");
			imageCmd[1,5,1] = Image_FromFile("img\\m105b.gif");

			imageCmd[2,1,0] = Image_FromFile("img\\m201a.gif");
			imageCmd[2,1,1] = Image_FromFile("img\\m201b.gif");
			imageCmd[2,2,0] = Image_FromFile("img\\m202a.gif");
			imageCmd[2,2,1] = Image_FromFile("img\\m202b.gif");
			imageCmd[2,3,0] = Image_FromFile("img\\m203a.gif");
			imageCmd[2,3,1] = Image_FromFile("img\\m203b.gif");
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� START
			imageCmd[2,4,0] = Image_FromFile("img\\m204a.gif");
			imageCmd[2,4,1] = Image_FromFile("img\\m204b.gif");
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� END
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� START
			imageCmd[2,5,0] = Image_FromFile("img\\m205a.gif");
			imageCmd[2,5,1] = Image_FromFile("img\\m205b.gif");
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� END

			imageCmd[3,1,0] = Image_FromFile("img\\m301a.gif");
			imageCmd[3,1,1] = Image_FromFile("img\\m301b.gif");
			imageCmd[3,2,0] = Image_FromFile("img\\m302a.gif");
			imageCmd[3,2,1] = Image_FromFile("img\\m302b.gif");
			imageCmd[3,3,0] = Image_FromFile("img\\m303a.gif");
			imageCmd[3,3,1] = Image_FromFile("img\\m303b.gif");
			imageCmd[3,4,0] = Image_FromFile("img\\m304a.gif");
			imageCmd[3,4,1] = Image_FromFile("img\\m304b.gif");
			imageCmd[4,1,0] = Image_FromFile("img\\m401a.gif");
			imageCmd[4,1,1] = Image_FromFile("img\\m401b.gif");
			imageCmd[4,2,0] = Image_FromFile("img\\m402a.gif");
			imageCmd[4,2,1] = Image_FromFile("img\\m402b.gif");
			imageCmd[4,3,0] = Image_FromFile("img\\m403a.gif");
			imageCmd[4,3,1] = Image_FromFile("img\\m403b.gif");
			imageCmd[4,4,0] = Image_FromFile("img\\m404a.gif");
			imageCmd[4,4,1] = Image_FromFile("img\\m404b.gif");
// MOD 2011.04.05 ���s�j���� ��ʃC���[�W�̃��[�h�ύX END
//			imageCmd[4,5,0] = Image.FromFile("img\\m405a.gif");
//			imageCmd[4,5,1] = Image.FromFile("img\\m405b.gif");
//			imageCmd[5,1,0] = Image.FromFile("img\\m501a.gif");
//			imageCmd[5,1,1] = Image.FromFile("img\\m501b.gif");
//			imageCmd[5,2,0] = Image.FromFile("img\\m502a.gif");
//			imageCmd[5,2,1] = Image.FromFile("img\\m502b.gif");

// DEL 2008.02.08 KCL) �X�{ ���m�点�C�� START
//// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
//			imageCmd[5,1,0] = Image.FromFile("img\\m601a.gif");
//			imageCmd[5,1,1] = Image.FromFile("img\\m601b.gif");
//// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
// DEL 2008.02.08 KCL) �X�{ ���m�点�C�� END
		}

		private void �����׎D���s()
		{
			tex���b�Z�[�W.Text = "";

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

			if(sv_print == null) sv_print = new is2print.Service1();

			//�Ώۃf�[�^�̎擾
			String[] sKey = new string[2];
			sKey[0] = gs����b�c;
			sKey[1] = gs����b�c;

			IEnumerator iEnum = sv_print.Get_ShippedUnpublished(gsa���[�U,sKey).GetEnumerator();
			iEnum.MoveNext();
			string[] sData = (string[])iEnum.Current;
			if (sData[0].Equals("����I��"))
			{
// MOD 2005.06.08 ���s�j�����J ���b�Z�[�W�̏��Ԃ̕ύX START
				Cursor = System.Windows.Forms.Cursors.Default;
				DialogResult result = MessageBox.Show("�����s�̃��x����S�Ĕ��s���܂�", "���x�����", 
					MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
				if (result == DialogResult.OK)
				{
					Cursor = System.Windows.Forms.Cursors.AppStarting;
					tex���b�Z�[�W.Text = "���x��������D�D�D";
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j START
//					ds�����.Clear();
					�����f�[�^�N���A();
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j END

// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� START
					int iCnt = 0;
// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� END
					while(iEnum.MoveNext())
					{
// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� START
						iCnt++;
						tex���b�Z�[�W.Text = "���x���f�[�^�ҏW���D�D�D" + iCnt + "����";
						tex���b�Z�[�W.Refresh();
// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� END
						try
						{
							sData = (string[])iEnum.Current;
							��������w��(sData);
// ADD 2006.12.12 ���s�j�����J �X���ƕ���X�����قȂ�ꍇ�́A������Ȃ� START
							if(!gb���)
							{
								tex���b�Z�[�W.Text = "";
// MOD 2007.2.19 FJCS�j�K�c ���b�Z�[�W�ύX START
//								MessageBox.Show("���X���Ⴂ�܂��B����ł��܂���B","������"
								MessageBox.Show("�W�דX���Ⴂ�܂��B����ł��܂���B","������"
// MOD 2007.2.19 FJCS�j�K�c ���b�Z�[�W�ύX END
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
// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� START
					tex���b�Z�[�W.Text = "���x��������D�D�D";
					tex���b�Z�[�W.Refresh();
// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� END
					����󒠕[���();
				}
// MOD 2005.06.08 ���s�j�����J ���b�Z�[�W�̏��Ԃ̕ύX END

				tex���b�Z�[�W.Text = "";
			}
			else
			{
				if(sData[0].Equals("�����͂��ׂĈ���ςł��B"))
				{
					MessageBox.Show("�����͂��ׂĈ���ςł�", "���x�����", 
						MessageBoxButtons.OK);
				}
				else
				{
					tex���b�Z�[�W.Text = sData[0];
				}
			}
			Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void ���o�׃f�[�^���s()
		{
//			try
//			{
//				�v�����^�`�F�b�N();
//			}
//			catch(Exception ex)
//			{
//// MOD 2005.05.31 ���s�j�����J ���b�Z�[�W�{�b�N�X�ɕύX START
////				tex���b�Z�[�W.Text = ex.Message;
//				�r�[�v��();
//				MessageBox.Show(ex.Message, "�v�����^�`�F�b�N", 
//					MessageBoxButtons.OK, MessageBoxIcon.Information);
//				i�I���e�f = 1;
//// MOD 2005.05.31 ���s�j�����J ���b�Z�[�W�{�b�N�X�ɕύX END
//				return;
//			}
			Cursor = System.Windows.Forms.Cursors.AppStarting;

			if(sv_print == null) sv_print = new is2print.Service1();

			DialogResult result;
			//�Ώۃf�[�^�̎擾
			String[] sKey = new string[2];
			sKey[0] = gs����b�c;
			sKey[1] = gs����b�c;

			IEnumerator iEnum = sv_print.Get_Unpublished(gsa���[�U,sKey).GetEnumerator();
			iEnum.MoveNext();
			string[] sData = (string[])iEnum.Current;
			if (sData[0].Equals("����I��"))
			{
				i�I���e�f = 0;
				result = MessageBox.Show("������ς�ł��Ȃ��o�׃f�[�^������܂�\r\n������������܂����H", "���x�����", 
					MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (result != DialogResult.Yes) return;

// MOD 2005.06.11 ���s�j�����J �v�����^�`�F�b�N�ړ� START
				try
				{
					�v�����^�`�F�b�N();
				}
				catch(Exception ex)
				{
// MOD 2005.05.31 ���s�j�����J ���b�Z�[�W�{�b�N�X�ɕύX START
//				tex���b�Z�[�W.Text = ex.Message;
					�r�[�v��();
					MessageBox.Show(ex.Message, "�v�����^�`�F�b�N", 
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					i�I���e�f = 1;
// MOD 2005.05.31 ���s�j�����J ���b�Z�[�W�{�b�N�X�ɕύX END
					return;
				}
// MOD 2005.06.11 ���s�j�����J �v�����^�`�F�b�N�ړ� END

				tex���b�Z�[�W.Text = "���x��������D�D�D";

// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j START
//				ds�����.Clear();
				�����f�[�^�N���A();
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j END

// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� START
				int iCnt = 0;
// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� END
				while(iEnum.MoveNext())
				{
// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� START
					iCnt++;
					tex���b�Z�[�W.Text = "���x���f�[�^�ҏW���D�D�D" + iCnt + "����";
					tex���b�Z�[�W.Refresh();
// ADD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� END
					try
					{
						sData = (string[])iEnum.Current;
						��������w��(sData);
// ADD 2006.12.12 ���s�j�����J �X���ƕ���X�����قȂ�ꍇ�́A������Ȃ� START
						if(!gb���)
						{
							tex���b�Z�[�W.Text = "";
							Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2007.2.19 FJCS�j�K�c ���b�Z�[�W�ύX START
//							MessageBox.Show("���X���Ⴂ�܂��B����ł��܂���B","������"
							MessageBox.Show("�W�דX���Ⴂ�܂��B����ł��܂���B","������"
// MOD 2007.2.19 FJCS�j�K�c ���b�Z�[�W�ύX END
								,MessageBoxButtons.OK);
							return;
						}
// ADD 2006.12.12 ���s�j�����J �X���ƕ���X�����قȂ�ꍇ�́A������Ȃ� END
					}
					catch (Exception ex)
					{
// MOD 2005.05.31 ���s�j�����J ���b�Z�[�W�{�b�N�X�ɕύX START
//						tex���b�Z�[�W.Text = ex.Message;
//						�r�[�v��();
						�r�[�v��();
						MessageBox.Show(ex.Message, "���x������G���[", 
							MessageBoxButtons.OK, MessageBoxIcon.Error);
						i�I���e�f = 1;
// MOD 2005.05.31 ���s�j�����J ���b�Z�[�W�{�b�N�X�ɕύX END
						return;
					}
				}

				����󒠕[���();

				tex���b�Z�[�W.Text = "";
				Cursor = System.Windows.Forms.Cursors.Default;
			}
			else
			{
				Cursor = System.Windows.Forms.Cursors.Default;
// ADD 2005.05.31 ���s�j�����J �G���[�� START
				if (!sData[0].Equals("�����͂��ׂĈ���ςł��B"))
				{
					�r�[�v��();
					MessageBox.Show(sData[0], "���x������G���[", 
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
// ADD 2005.05.31 ���s�j�����J �G���[�� END
				i�I���e�f = 1;
			}
		}

// ADD 2005.05.20 ���s�j���� �X���b�h�� START
		private static  void ThreadTask()
		{
// ADD 2005.05.27 ���s�j���� �X���b�h�ʒu�̈ړ� START
// MOD 2009.10.14 ���s�j���� config�Ǎ��Ȃ� START
//			if(sv_init     == null) sv_init     = new is2init.Service1();
// MOD 2009.10.14 ���s�j���� config�Ǎ��Ȃ� END
			���j���[�C���[�W�̏�����();
			�R�}���h�C���[�W�̏�����();
// ADD 2005.05.27 ���s�j���� �X���b�h�ʒu�̈ړ� END
// DEL 2005.06.10 ���s�j���� �N�����Ԃ�Z������ START
//// ADD 2005.05.27 ���s�j���� �N�����Ԃ�Z������ START
//			bool bRet = ��ԏ��擾();
//// ADD 2005.05.27 ���s�j���� �N�����Ԃ�Z������ END
// DEL 2005.06.10 ���s�j���� �N�����Ԃ�Z������ END
// MOD 2009.10.14 ���s�j���� config�Ǎ��Ȃ� START
//			if(sv_address  == null) sv_address  = new is2address.Service1();
//			if(sv_goirai   == null) sv_goirai   = new is2goirai.Service1();
//			if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
//			if(sv_kiji     == null) sv_kiji     = new is2kiji.Service1();
//			if(sv_otodoke  == null) sv_otodoke  = new is2otodoke.Service1();
//			if(sv_print    == null) sv_print    = new is2print.Service1();
//			if(sv_syukka   == null) sv_syukka   = new is2syukka.Service1();
//			if(sv_seikyuu  == null) sv_seikyuu  = new is2seikyuu.Service1();
//// ADD 2007.12.11 KCL) �X�{ ���m�点�ǉ� START
//			if(sv_oshirase == null) sv_oshirase = new is2oshirase.Service1();
//// ADD 2007.12.11 KCL) �X�{ ���m�点�ǉ� END
// MOD 2009.10.14 ���s�j���� config�Ǎ��Ȃ� END

// ADD 2005.05.24 ���s�j���� ��ʑJ�ڂ̍����� START
// MOD 2016.05.24 BEVAS�j���{ �Z�N�V�����ؑ։�ʉ��C�Ή� START
			//�X�v���b�h�V�[�g�g�p�ɂ��A�R�����g��
//			if(g����ύX == null) g����ύX = new ����ύX�Q();
// MOD 2016.05.24 BEVAS�j���{ �Z�N�V�����ؑ։�ʉ��C�Ή� END
			if(g�A�C�R�� == null) g�A�C�R�� = new �A�C�R���I��();
			if(g�͐�捞 == null) g�͐�捞 = new ���͂���捞();
			if(g�͐�o�^ == null) g�͐�o�^ = new ���͂���o�^();
			if(g�͐�o�� == null) g�͐�o�� = new ���͂���o�^��();
			if(g�˗��o�^ == null) g�˗��o�^ = new ���˗���o�^();
			if(g�p�X�ύX == null) g�p�X�ύX = new �p�X���[�h�ύX();
			if(g�ː��ؑ� == null) g�ː��ؑ� = new �ː��؂�ւ�();
			if(g�o�דo�^ == null) g�o�דo�^ = new �o�דo�^();
			if(g���o�o�^ == null) g���o�o�^ = new ���^�o�דo�^();
			if(g���^�o�^ == null) g���^�o�^ = new ���^�o�^();
			if(g�[���o�^ == null) g�[���o�^ = new �[���o�^();
			if(g�w�莞�ԓ��� == null) g�w�莞�ԓ��� = new �w�莞�ԓ���();
			if(g�o�׎��� == null) g�o�׎��� = new �o�׎���();
// �ۗ� �X�v���b�h�V�[�g��������̂́A���L�̃G���[���ł�
//	'System.Reflection.TargetInvocationException' �̃n���h������Ă��Ȃ���O�� 
//	system.windows.forms.dll �Ŕ������܂����B
//	�ǉ���� : 'AxGTable32' �R���g���[���̃E�B���h�E �n���h�����擾�ł��܂���B
//	�E�B���h�E�Ȃ��� ActiveX �R���g���[���̓T�|�[�g����Ă��܂���B
//
//			if(g�o�׏Ɖ� == null) g�o�׏Ɖ� = new �o�׏Ɖ�();
//			if(g�͐挟�� == null) g�͐挟�� = new ���͂��挟��();
//			if(g�˗����� == null) g�˗����� = new ���˗��匟��();
//			if(g�L������ == null) g�L������ = new �L������();
//			if(g�����o�^ == null) g�����o�^ = new �����o�דo�^();
//			if(g�Z������ == null) g�Z������ = new �Z������();
//			if(g�����o�^ == null) g�����o�^ = new ������o�^();
//			if(g������� == null) g������� = new �����s���();
// ADD 2005.05.24 ���s�j���� ��ʑJ�ڂ̍����� END

// ADD 2005.05.25 ���s�j���� ��ʑJ�ڂ̍����� START
			�A�C�R���C���[�W�̏�����();
// ADD 2005.05.25 ���s�j���� ��ʑJ�ڂ̍����� END

//			MessageBox.Show("�X���b�h�I��",
//				"�X���b�h", 
//				MessageBoxButtons.OK);
// ADD 2007.11.29 ���s�j���� ���O�C�����̃t�H�[�J�X��Q�Ή� START
			if(F�����o�^ != null) F�����o�^.Focus();
			else if(F���O�C�� != null) F���O�C��.Focus();
// ADD 2007.11.29 ���s�j���� ���O�C�����̃t�H�[�J�X��Q�Ή� END
		}
// ADD 2005.05.20 ���s�j���� �X���b�h�� END

// ADD 2005.05.20 ���s�j�����J �w���v�ǉ� START
		private void btn�w���v_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A START
			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";
// MOD 2010.01.15 ���s�j���� �G���[���b�Z�[�W�̃N���A END
// MOD 2005.05.25 ���s�j���� �w���v�t�q�k��config����擾 START
//			Process.Start("iexplore.exe", "http://wwwis2.fukutsu.co.jp/is2/manual/is2manual.pdf");
// MOD 2008.02.13 ���s�j���� �w���v�̍ו����Ή� START
//			Process.Start("iexplore.exe", s�w���v�t�q�k);
			�w���v F�w���v = new �w���v();
			if(F�w���v.s�w���v�t�q�k.Length == 0)
			{
				F�w���v.s�w���v�t�q�k = this.s�w���v�t�q�k;
				int iPos = this.s�w���v�t�q�k.LastIndexOf("/") + 1;
				F�w���v.s�w���v�t�q�k�a�`�r�d = this.s�w���v�t�q�k.Substring(0,iPos);
			}
			F�w���v.Top  = this.Top  + panel6.Top + panel6.Height
// MOD 2011.02.03 ���s�j���� SATO���v�����^���|�}�j���A���ǉ� START
//									+ btn�w���v.Top + btn�w���v.Height;
									+ btn�w���v.Top;
// MOD 2011.02.03 ���s�j���� SATO���v�����^���|�}�j���A���ǉ� END
// MOD 2010.05.24 ���s�j���� 120DPI�Ή����̕\���ʒu���� START
//			F�w���v.Left = this.Left + this.Width - F�w���v.Width - 4;
			F�w���v.Left = this.Left
						 + this.Width - �c�o�h�T�C�Y�ʒu����(F�w���v.Width, giDisplayDpiX)
						 - 4;
// MOD 2010.05.24 ���s�j���� 120DPI�Ή����̕\���ʒu���� END
			F�w���v.WindowState = FormWindowState.Normal;
			F�w���v.ShowDialog();
// MOD 2008.02.13 ���s�j���� �w���v�̍ו����Ή� END
// MOD 2005.05.25 ���s�j���� �w���v�t�q�k��config����擾 END
		}
// ADD 2005.05.20 ���s�j�����J �w���v�ǉ� END

// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� START
		private void ���m�点�����ݒ�() 
		{
// MOD 2008.02.08 KCL) �X�{ ���m�点�C�� START
//			// Label ��z��ɂ���
//			labList[0] = lab���m�点�P;
//			labList[1] = lab���m�点�Q;
//			labList[2] = lab���m�点�R;
//			labList[3] = lab���m�点�S;
//			labList[4] = lab���m�点�T;
//
//			// PictureBox ��z��ɂ���
//			picList[0] = pic���m�点�P;
//			picList[1] = pic���m�点�Q;
//			picList[2] = pic���m�点�R;
//			picList[3] = pic���m�点�S;
//			picList[4] = pic���m�点�T;
//
			// ���m�点�\��{�^����z��ɂ���
			btnList[0] = btn���m�点�P;
			btnList[1] = btn���m�点�Q;
			btnList[2] = btn���m�点�R;
			btnList[3] = btn���m�点�S;
			btnList[4] = btn���m�点�T;
// MOD 2008.02.08 KCL) �X�{ ���m�点�C�� END
		}
		private void ���m�点�̎擾�ƕ\��() 
		{
			// ���m�点�擾�����̐ݒ�
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� START
//			string [] sKey = new string [5];
			string [] sKey = new string [7];
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� END
			sKey[0] = string.Empty;		// �J�n�o�^��
			sKey[1] = string.Empty;		// �I���o�^��
			sKey[2] = string.Empty;		// �\��
			sKey[3] = string.Empty;		// �ڍד��e
			sKey[4] = "5";				// ��ʂm��
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� START
			sKey[5] = "���m�点�{�^���׎�"; // �@�\
			sKey[6] = gs���p�ҕ���X���b�c; // �X���b�c
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� END

			// ���m�点�ꗗ���擾
			string [] sRet = null;
			try
			{
				if (sv_oshirase == null) sv_oshirase = new is2oshirase.Service1();
				sRet = sv_oshirase.Get_OshiraseTopN(gsa���[�U, sKey);
			}
			catch (System.Net.WebException)
			{
				// �ʐM�G���[����
				sRet[0] = gs�ʐM�G���[;
			}
			catch (Exception ex)
			{
				// ���̑��̃G���[����
				sRet[0] = "�ʐM�G���[�F" + ex.Message;
			}

			// ���ʏ���
			try 
			{
				switch (sRet[0].Trim()) 
				{
					case "����I��" :		// ����I���̏ꍇ

						// ���m�点�擾
						s���m�点�ꗗ = new string [sRet.Length - 1][];
						for (int i=1; i<sRet.Length; i++) 
						{
							string [] s���� = sRet[i].Split('|');
							s���m�点�ꗗ[i-1] = new string [] {
															 s����[1],	// �o�^���i�\���p�j
															 s����[2],	// �\��
															 s����[3],	// �o�^���i�����W���j
															 s����[4]	// �V�[�P���X�m��
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� START
															 ,s����[5]	// �Ǘ��ҋ敪
															 ,s����[6]	// �X���b�c
															 ,s����[7]	// ����b�c
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� END
														 };
						}

						break;

					default :				// �ُ�I���̏ꍇ

						throw new Exception(sRet[0]);
				}
			} 
			catch (Exception ex) 
			{
				// ���m�点�̎擾�Ɏ��s

				// �{�^�������ׂĔ�\����
				for (int i=0; i<5; i++) 
				{
// MOD 2008.02.08 KCL) �X�{ ���m�点�C�� START
//					labList[i].Visible = false;
//					picList[i].Visible = false;
//
					btnList[i].Visible = false;
// MOD 2008.02.08 KCL) �X�{ ���m�点�C�� START
				}
				// �x����
				�r�[�v��();
				// �G���[���b�Z�[�W�\��
				tex���b�Z�[�W.Text = "���m�点�̎擾�Ɏ��s���܂����B" + ex.Message;

				return;
			}

			// ���m�点�{�^����\��
			for (int i=0; i<5; i++) 
			{
				if (s���m�点�ꗗ.Length > i) 
				{
					// �\�����邨�m�点�L

// MOD 2008.02.08 KCL) �X�{ ���m�点�C�� START
//					// �{�^����\��
//					labList[i].Visible = true;
//					picList[i].Visible = true;
//
//					// �o�^���ƕ\���\��
//					string title = s���m�点�ꗗ[i][1];
//					int len = title.Length;
//					labList[i].Text = string.Format("{0}�@{1}", s���m�点�ꗗ[i][0], title);
//
					// �{�^����\��
					btnList[i].Visible = true;

					// �o�^���ƕ\���\��
					btnList[i].���t = s���m�点�ꗗ[i][0];
					btnList[i].�\�� = s���m�点�ꗗ[i][1];
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� START
					if(s���m�点�ꗗ[i][5].Length > 0){	// �X���b�c
						btnList[i].���[�h = 2;
					}else{
						btnList[i].���[�h = 0;
					}
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� END
// MOD 2016.01.21 BEVAS) ���{ ���m�点�{�^���̐F�ؑւ����C START
					//���m�点�\��̐擪�Ɂu�y�d�v�z�v���t���Ƃ��́A�{�^���̐F��ς���
					if(s���m�点�ꗗ[i][1].StartsWith("�y�d�v�z"))
					{
						btnList[i].���[�h = 2;
					}
// MOD 2016.01.21 BEVAS) ���{ ���m�点�{�^���̐F�ؑւ����C END
// MOD 2008.02.08 KCL) �X�{ ���m�点�C�� END
				} 
				else 
				{
					// �\�����邨�m�点��

// MOD 2008.02.08 KCL) �X�{ ���m�点�C�� START
//					// �{�^����\�����Ȃ�
//					labList[i].Visible = false;
//					picList[i].Visible = false;
//
					// �{�^����\�����Ȃ�
					btnList[i].Visible = false;
// MOD 2008.02.08 KCL) �X�{ ���m�点�C�� END
				}
			}
		}
// ADD 2007.11.30 KCL) �X�{ ���m�点�ǉ� END
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� START
		private void ���m�点�ē����b�Z�[�W�擾() 
		{
			// ���m�点�擾�����̐ݒ�
			string [] sKey = new string [7];
			sKey[0] = string.Empty;		// �J�n�o�^��
			sKey[1] = string.Empty;		// �I���o�^��
			sKey[2] = string.Empty;		// �\��
			sKey[3] = string.Empty;		// �ڍד��e
			sKey[4] = "5";				// ��ʂm��
			sKey[5] = "���j���[�׎�"; // �@�\
			sKey[6] = gs���p�ҕ���X���b�c; // �X���b�c

			// ���m�点�ꗗ���擾
			string [] sRet = null;
			try{
				if (sv_oshirase == null) sv_oshirase = new is2oshirase.Service1();
				sRet = sv_oshirase.Get_OshiraseTopN(gsa���[�U, sKey);
			}catch (System.Net.WebException){
				// �ʐM�G���[����
				sRet[0] = gs�ʐM�G���[;
			}catch (Exception ex){
				// ���̑��̃G���[����
				sRet[0] = "�ʐM�G���[�F" + ex.Message;
			}

			try{
				if(sRet[0].Length == 4){	// ����I���̏ꍇ
					// ���m�点�擾
					s���m�点�ꗗ = new string [sRet.Length - 1][];
					for(int iCnt = 1; iCnt < sRet.Length; iCnt++){
						string [] s���� = sRet[iCnt].Split('|');
						s���m�点�ꗗ[iCnt-1]
						 = new string []{
							  s����[ 3]	// 0:�o�^���i�����W���j
							 ,s����[ 4]	// 1:�V�[�P���X�m��
							 ,s����[ 6]	// 2:�X���b�c
							 ,s����[ 7]	// 3:����b�c
							 ,s����[ 8]	// 4:�ڍד��e
							 ,s����[ 9]	// 5:���b�Z�[�W
							 ,s����[10]	// 6:�\�����ԊJ�n
							 ,s����[11]	// 7:�\�����ԏI��
							 ,s����[12]	// 8:�\���e�f
							 ,s����[13]	// 9:�V�X�e�����t
						 };
					}
				}else{
					throw new Exception(sRet[0]);
				}
			}catch (Exception ex){
				�r�[�v��();
				tex���b�Z�[�W.Text = "���m�点�̎擾�Ɏ��s���܂����B" + ex.Message;
				return;
			}

			// ���b�Z�[�W��\��
			for(int iCnt = 0; iCnt < s���m�点�ꗗ.Length; iCnt++){
				// �X���b�c�`�F�b�N
				if(s���m�点�ꗗ[iCnt][2].Length == 0) continue;

				// ����b�c�`�F�b�N
				if(s���m�点�ꗗ[iCnt][3].Length > 0){
					// �\���e�f�`�F�b�N
					if(s���m�点�ꗗ[iCnt][8].Equals("1")){
						MessageBox.Show(s���m�点�ꗗ[iCnt][4]
							, ""
							, MessageBoxButtons.OK);
						���m�点�\���e�f�X�V(
							s���m�点�ꗗ[iCnt][0], s���m�点�ꗗ[iCnt][1]);
					}
				}

				// �\�����ԃ`�F�b�N
				string s�\�����ԊJ�n = s���m�点�ꗗ[iCnt][6];
				string s�\�����ԏI�� = s���m�点�ꗗ[iCnt][7];
				string s�V�X�e�����t = s���m�点�ꗗ[iCnt][9];
				if(s�\�����ԊJ�n.CompareTo(s�V�X�e�����t) > 0) continue;
				if(s�\�����ԏI��.CompareTo(s�V�X�e�����t) < 0) continue;
				gs���m�点�ē����b�Z�[�W = s���m�点�ꗗ[iCnt][5];
//				tex���b�Z�[�W.Text = gs���m�点�ē����b�Z�[�W;
			}
		}
		private void ���m�点�\���e�f�X�V(string s�o�^��, string s�V�[�P���X�m��) 
		{
			// ���m�点�擾�����̐ݒ�
			string [] sKey = new string[]{
				  s�o�^��
				, s�V�[�P���X�m��
				, gs���p�҂b�c
			};

			string [] sRet = null;
			try{
				if(sv_oshirase == null) sv_oshirase = new is2oshirase.Service1();
				sRet = sv_oshirase.Upd_HyoujiFG(gsa���[�U, sKey);
			}catch(System.Net.WebException){
				// �ʐM�G���[����
				sRet[0] = gs�ʐM�G���[;
			}catch(Exception ex){
				// ���̑��̃G���[����
				sRet[0] = "�ʐM�G���[�F" + ex.Message;
			}

			if(sRet[0].Length != 4){
				�r�[�v��();
				tex���b�Z�[�W.Text = sRet[0];
				return;
			}
		}
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� END
// ADD 2009.04.02 ���s�j���� �ғ����Ή� START
		static private void �ғ������擾()
		{
			//�����ݒ�
// MOD 2011.09.05 ���s�j���� �o�ד��̏�����b�r�u�G���g���[�Ɠ��l�ɂ��� START
//			gdt�o�ד��ő�l       = gdt�o�ד�.AddDays(7);
			gdt�o�ד��ő�l       = gdt�o�ד�.AddDays(14);
// MOD 2011.09.05 ���s�j���� �o�ד��̏�����b�r�u�G���g���[�Ɠ��l�ɂ��� END
			gdt�o�ד��ő�l�b�r�u = gdt�o�ד�.AddDays(14);

			DateTime dt�J�n�� = gdt�o�ד�;
			DateTime dt�I���� = gdt�o�ד�.AddMonths(1).AddDays(-1);

			try
			{
				// �ғ������擾
				if(sv_init == null) sv_init = new is2init.Service1();
				String[] sRet = sv_init.Get_Kadobi(gsa���[�U, dt�J�n��.ToString("yyyyMMdd")
															, dt�I����.ToString("yyyyMMdd"));
				if(sRet[0].Length != 4)
				{
					�r�[�v��();
					MessageBox.Show(sRet[0],
									"�ғ������擾", 
									MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

// MOD 2011.09.05 ���s�j���� �o�ד��̏�����b�r�u�G���g���[�Ɠ��l�ɂ��� START
//				try{
//					if(sRet[1].Length == 8){
//						gdt�o�ד��ő�l = new DateTime(int.Parse(sRet[1].Substring(0,4)), 
//											int.Parse(sRet[1].Substring(4,2)),
//											int.Parse(sRet[1].Substring(6)) );
//					}
//				}catch(Exception){}
// MOD 2011.09.05 ���s�j���� �o�ד��̏�����b�r�u�G���g���[�Ɠ��l�ɂ��� END
				try{
					if(sRet[2].Length == 8){
						gdt�o�ד��ő�l�b�r�u = new DateTime(int.Parse(sRet[2].Substring(0,4)), 
											int.Parse(sRet[2].Substring(4,2)),
											int.Parse(sRet[2].Substring(6)) );
// MOD 2011.09.05 ���s�j���� �o�ד��̏�����b�r�u�G���g���[�Ɠ��l�ɂ��� START
						gdt�o�ד��ő�l       = gdt�o�ד��ő�l�b�r�u;
// MOD 2011.09.05 ���s�j���� �o�ד��̏�����b�r�u�G���g���[�Ɠ��l�ɂ��� END
					}
				}catch(Exception){}
// ADD 2013.02.15 TDI)�j�V �O���[�o���o�ד������g���Ή�(14����62��) ADD START
// �O���[�o���׎�̏ꍇ�́A�o�ד��ő�l��62���ԂƂ���B�㏑��
				try
				{
					if(gs����X���b�c.Equals("047"))
					{
						gdt�o�ד��ő�l = gdt�o�ד�.AddDays(62);
						gdt�o�ד��ő�l�b�r�u = gdt�o�ד�.AddDays(62);
					}
					else
					{
						//�������Ȃ�
					}
				}
				catch(Exception){}
// ADD 2013.02.15 TDI)�j�V �O���[�o���o�ד������g���Ή�(14����62��) ADD END

			}
			catch (System.Net.WebException)
			{
				�r�[�v��();
				MessageBox.Show(gs�ʐM�G���[, 
								"�ʐM�G���[", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				�r�[�v��();
				MessageBox.Show(ex.Message, 
								"�ʐM�G���[", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
// ADD 2009.04.02 ���s�j���� �ғ����Ή� END
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
		static protected void �I�v�V�������擾()
		{
			string[] sRet = new string[]{""};
//			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
//				tex���b�Z�[�W.Text = "�������D�D�D";
				if(sv_init == null) sv_init = new is2init.Service1();
				sRet = sv_init.Get_seigyo2(gsa���[�U,gs����b�c,gs����b�c,gi�I�v�V������);
			}
			catch (System.Net.WebException)
			{
				�r�[�v��();
				MessageBox.Show(gs�ʐM�G���[, 
					"�ʐM�G���[", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			catch (Exception ex)
			{
				�r�[�v��();
				MessageBox.Show(ex.Message, 
					"�ʐM�G���[", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
//			Cursor = System.Windows.Forms.Cursors.Default;

			if(sRet[0].Length == 4)
			{
				int iCnt = 0;
				for (; iCnt < gs�I�v�V����.Length && iCnt < sRet.Length; iCnt++)
				{
					gs�I�v�V����[iCnt] = sRet[iCnt];
				}
				for (; iCnt < gs�I�v�V����.Length; iCnt++)
				{
					gs�I�v�V����[iCnt] = "9";
				}
			}
			else
			{
				�r�[�v��();
				MessageBox.Show(sRet[0], 
					"�ʐM�G���[", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return;
		}
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
		static protected void �d�ʓ��͐���擾()
		{
			string[] sRet = new string[]{"",""};
			gs�d�ʓ��͐��� = "0";
			try{
				sRet = sv_init.Get_seigyo3(gsa���[�U,gs����b�c,gs����b�c);
			}catch (System.Net.WebException){
//				�r�[�v��();
//				MessageBox.Show(gs�ʐM�G���[, 
//					"�ʐM�G���[", 
//					MessageBoxButtons.OK, MessageBoxIcon.Error);
//				return;
//			}catch (Exception ex){
			}catch (Exception){
//				�r�[�v��();
//				MessageBox.Show(ex.Message, 
//					"�ʐM�G���[", 
//					MessageBoxButtons.OK, MessageBoxIcon.Error);
//				return;
			}
			if(sRet[0].Length == 4){
				gs�d�ʓ��͐��� = sRet[1];
			}
			return;
		}
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END

// ADD 2009.07.29 ���s�j���� �v���L�V�Ή� START
		// �h�d�̃v���L�V�̐ݒ���e�����W�X�g������擾
		private static void �h�d�v���L�V�擾()
		{
//			LogWriter.GetInstance().WriteInfo("�h�d�v���L�V�擾()");

			Microsoft.Win32.RegistryKey regkey =
				Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", false);
			//�L�[�����݂��Ȃ��Ƃ��� null ���Ԃ����
			if (regkey == null) return;

//			int iProxyEnable = (int)regkey.GetValue("ProxyEnable");
//			string[] sProxyServer   = ((string)regkey.GetValue("ProxyServer")).Split(new char[]{';'});
			int iProxyEnable = 0;
			if(regkey.GetValue("ProxyEnable") != null){
				iProxyEnable = (int)regkey.GetValue("ProxyEnable");
//				LogWriter.GetInstance().WriteInfo("ProxyEnable[" + iProxyEnable + "]");
			}
			string[] sProxyServer   = {""};
			if(regkey.GetValue("ProxyServer") != null){
				sProxyServer   = ((string)regkey.GetValue("ProxyServer")).Split(new char[]{';'});
//				LogWriter.GetInstance().WriteInfo("ProxyServer["
//								 + (string)regkey.GetValue("ProxyServer") + "]");
			}

			string[] sProxyOverride = {""};
			if(regkey.GetValue("ProxyOverride") != null){
				sProxyOverride = ((string)regkey.GetValue("ProxyOverride")).Split(new char[]{';'});
//				LogWriter.GetInstance().WriteInfo("ProxyOverride["
//								 + (string)regkey.GetValue("ProxyOverride") + "]");
			}
			regkey.Close();
			if(iProxyEnable == 1){
				for(int iCnt = 0; iCnt < sProxyServer.Length; iCnt++){
					string[] sParam = sProxyServer[iCnt].Split(new char[]{':'});
					if(sParam[0].StartsWith("https=")){
						gsProxyAdrSecure = sParam[0].Substring(6);
						if(sParam.Length >= 2) giProxyNoSecure = int.Parse(sParam[1]);
					}else if(sParam[0].StartsWith("http=")){
						gsProxyAdrHttp = sParam[0].Substring(5);
						if(sParam.Length >= 2) giProxyNoHttp   = int.Parse(sParam[1]);
					}else if(sParam[0].StartsWith("ftp=")){
						;
					}else if(sParam[0].StartsWith("socks=")){
						;
					}else{
						gsProxyAdrAll  = sParam[0];
						if(sParam.Length >= 2) giProxyNoAll    = int.Parse(sParam[1]);
					}
				}
				for(int iCnt = 0; iCnt < sProxyOverride.Length; iCnt++){
					if(sProxyOverride[iCnt].Equals("wwwis2.fukutsu.co.jp")) return;
					if(sProxyOverride[iCnt].Equals("fukutsu.co.jp")) return;
				}
				if(gsProxyAdrAll.Length > 0){
					gsProxyAdr = gsProxyAdrAll;
					giProxyNo  = giProxyNoAll;
				}else if(gsProxyAdrSecure.Length > 0){
					gsProxyAdr = gsProxyAdrSecure;
					giProxyNo  = giProxyNoSecure;
				}else if(gsProxyAdrHttp.Length > 0){
					gsProxyAdr = gsProxyAdrHttp;
					giProxyNo  = giProxyNoHttp;
				}
			}
		}

		//
		// �f�t�H���g�v���L�V�̐ݒ���s��
		//
		public static int �f�t�H���g�v���L�V�ݒ�()
		{
			int iRet = 0;

			try{
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX START
				//System.Net.GlobalProxySelection.Select = System.Net.WebProxy.GetDefaultProxy();
                System.Net.WebRequest.DefaultWebProxy = System.Net.WebRequest.GetSystemWebProxy();
				//sv_init.Proxy = System.Net.WebProxy.GetDefaultProxy();
                sv_init.Proxy = System.Net.WebRequest.GetSystemWebProxy();
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX END

				string sRet = sv_init.wakeupDB();
// MOD 2010.07.30 ���s�j���� �f�t�H���g�v���L�V�ݒ�̏C�� START
				�v�����T�[�r�X�̏�����others();
// MOD 2010.07.30 ���s�j���� �f�t�H���g�v���L�V�ݒ�̏C�� END
				iRet = 1;
			}catch(System.Net.WebException ex){
				iRet = -1;
				switch(ex.Status){
				case WebExceptionStatus.NameResolutionFailure:
				    iRet = -11;
					break;
				case WebExceptionStatus.Timeout:
				    iRet = -12;
					break;
				case WebExceptionStatus.TrustFailure:
					iRet = -13;
					break;
				case WebExceptionStatus.ConnectFailure:
					iRet = -14;
					break;
				default:
					iRet = -19;
					break;
				}
				return iRet;
//			}catch(Exception ex){
			}catch(Exception){
				iRet = -2;
				return iRet;
			}

			return iRet;
		}
		//
		public static bool �v���L�V�ݒ�(string sProxyAdr, int iProxyNo)
// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� START
		{
			return �v���L�V�ݒ�Q(sProxyAdr, iProxyNo, "", "");
		}
		private static bool �v���L�V�ݒ�Q(string sProxyAdr, int iProxyNo
											, string sProxyId, string sProxyPa)
// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� END
		{
			try{
				if(sProxyAdr.Length > 0)
				{
					if(iProxyNo > 0)
					{
						gProxy = new System.Net.WebProxy(sProxyAdr, iProxyNo);
					}
					else
					{
						gProxy = new System.Net.WebProxy(sProxyAdr);
					}
// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� START
					if(sProxyId.Length > 0){
						gProxy.Credentials = new NetworkCredential(sProxyId, sProxyPa);
					}
// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� END

// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX START
					//System.Net.GlobalProxySelection.Select = gProxy;
                    System.Net.WebRequest.DefaultWebProxy = gProxy;
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX END
					sv_init.Proxy = gProxy;
				}
				else
				{
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX START
					//System.Net.GlobalProxySelection.Select = System.Net.GlobalProxySelection.GetEmptyWebProxy();
                    System.Net.WebRequest.DefaultWebProxy = null;
					//sv_init.Proxy = System.Net.GlobalProxySelection.GetEmptyWebProxy();
                    sv_init.Proxy = null;
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX END
				}
				string sRet = "";
//				try
//				{
					sRet = sv_init.wakeupDB();
//				}
//				catch (Exception)
//				{
//					if(sv_init.Url.StartsWith("http://")){
//						sv_init.Url     = sv_init.Url.Replace("http://","https://");
//
//						sv_address.Url  = sv_address.Url.Replace("http://","https://");
//						sv_goirai.Url   = sv_goirai.Url.Replace("http://","https://");
//						sv_hinagata.Url = sv_hinagata.Url.Replace("http://","https://");
//						sv_kiji.Url     = sv_kiji.Url.Replace("http://","https://");
//						sv_otodoke.Url  = sv_otodoke.Url.Replace("http://","https://");
//						sv_print.Url    = sv_print.Url.Replace("http://","https://");
//						sv_syukka.Url   = sv_syukka.Url.Replace("http://","https://");
//						sv_seikyuu.Url  = sv_seikyuu.Url.Replace("http://","https://");
//						sv_oshirase.Url = sv_oshirase.Url.Replace("http://","https://");
//					}else if(sv_init.Url.StartsWith("https://")){
//						sv_init.Url     = sv_init.Url.Replace("https://","http://");
//
//						sv_address.Url  = sv_address.Url.Replace("https://","http://");
//						sv_goirai.Url   = sv_goirai.Url.Replace("https://","http://");
//						sv_hinagata.Url = sv_hinagata.Url.Replace("https://","http://");
//						sv_kiji.Url     = sv_kiji.Url.Replace("https://","http://");
//						sv_otodoke.Url  = sv_otodoke.Url.Replace("https://","http://");
//						sv_print.Url    = sv_print.Url.Replace("https://","http://");
//						sv_syukka.Url   = sv_syukka.Url.Replace("https://","http://");
//						sv_seikyuu.Url  = sv_seikyuu.Url.Replace("https://","http://");
//						sv_oshirase.Url = sv_oshirase.Url.Replace("https://","http://");
//					}
//					sRet = sv_init.wakeupDB();
//					return false;
//				}

//				if(sv_address  == null) sv_address  = new is2address.Service1();
//				if(sv_goirai   == null) sv_goirai   = new is2goirai.Service1();
//				if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
//				if(sv_kiji     == null) sv_kiji     = new is2kiji.Service1();
//				if(sv_otodoke  == null) sv_otodoke  = new is2otodoke.Service1();
//				if(sv_print    == null) sv_print    = new is2print.Service1();
//				if(sv_syukka   == null) sv_syukka   = new is2syukka.Service1();
//				if(sv_seikyuu  == null) sv_seikyuu  = new is2seikyuu.Service1();
//				if(sv_oshirase == null) sv_oshirase = new is2oshirase.Service1();

				�v�����T�[�r�X�̏�����others();

				return true;
//			}catch (System.Net.WebException ex){
			}catch (System.Net.WebException){
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX START
                //���̏�Ԃɖ߂�
				//System.Net.GlobalProxySelection.Select = System.Net.WebProxy.GetDefaultProxy();
                System.Net.WebRequest.DefaultWebProxy = System.Net.WebRequest.GetSystemWebProxy();
				//sv_init.Proxy = System.Net.WebProxy.GetDefaultProxy();
                sv_init.Proxy = System.Net.WebRequest.GetSystemWebProxy();
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX END
				return false;
//			}catch (Exception ex){
			}catch (Exception){
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX START
				//���̏�Ԃɖ߂�
				//System.Net.GlobalProxySelection.Select = System.Net.WebProxy.GetDefaultProxy();
                System.Net.WebRequest.DefaultWebProxy = System.Net.WebRequest.GetSystemWebProxy();
				//sv_init.Proxy = System.Net.WebProxy.GetDefaultProxy();
                sv_init.Proxy = System.Net.WebRequest.GetSystemWebProxy();
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX END
				return false;
			}
		}
// ADD 2009.07.29 ���s�j���� �v���L�V�Ή� END
// MOD 2009.10.14 ���s�j���� config�Ǎ��Ȃ� START
		static void �v�����T�[�r�X�̏�����init()
		{
			sv_init     = new is2init.Service1();
			if(sUrl_init.Length     > 0) sv_init.Url     = sUrl_init;
		}
		static void �v�����T�[�r�X�̏�����others()
		{
			sv_address  = new is2address.Service1();
			sv_goirai   = new is2goirai.Service1();
			sv_hinagata = new is2hinagata.Service1();
			sv_kiji     = new is2kiji.Service1();
			sv_otodoke  = new is2otodoke.Service1();
			sv_print    = new is2print.Service1();
			sv_syukka   = new is2syukka.Service1();
			sv_seikyuu  = new is2seikyuu.Service1();
			sv_oshirase = new is2oshirase.Service1();
// MOD 2011.01.11 ���s�j���� ���q�^���̑Ή� START
			sv_oji      = new is2oji.Service1();
// MOD 2011.01.11 ���s�j���� ���q�^���̑Ή� END

			if(sUrl_address.Length  > 0) sv_address.Url  = sUrl_address;
			if(sUrl_goirai.Length   > 0) sv_goirai.Url   = sUrl_goirai;
			if(sUrl_hinagata.Length > 0) sv_hinagata.Url = sUrl_hinagata;
			if(sUrl_kiji.Length     > 0) sv_kiji.Url     = sUrl_kiji;
			if(sUrl_otodoke.Length  > 0) sv_otodoke.Url  = sUrl_otodoke;
			if(sUrl_print.Length    > 0) sv_print.Url    = sUrl_print;
			if(sUrl_syukka.Length   > 0) sv_syukka.Url   = sUrl_syukka;
			if(sUrl_seikyuu.Length  > 0) sv_seikyuu.Url  = sUrl_seikyuu;
			if(sUrl_oshirase.Length > 0) sv_oshirase.Url = sUrl_oshirase;
// MOD 2011.01.11 ���s�j���� ���q�^���̑Ή� START
			if(sUrl_oji.Length      > 0) sv_oji.Url      = sUrl_oji;
// MOD 2011.01.11 ���s�j���� ���q�^���̑Ή� END

			sv_address.Proxy  = sv_init.Proxy;
			sv_goirai.Proxy   = sv_init.Proxy;
			sv_hinagata.Proxy = sv_init.Proxy;
			sv_kiji.Proxy     = sv_init.Proxy;
			sv_otodoke.Proxy  = sv_init.Proxy;
			sv_print.Proxy    = sv_init.Proxy;
			sv_syukka.Proxy   = sv_init.Proxy;
			sv_seikyuu.Proxy  = sv_init.Proxy;
			sv_oshirase.Proxy = sv_init.Proxy;
// MOD 2011.01.11 ���s�j���� ���q�^���̑Ή� START
			sv_oji.Proxy      = sv_init.Proxy;
// MOD 2011.01.11 ���s�j���� ���q�^���̑Ή� END
		}
// MOD 2009.10.14 ���s�j���� config�Ǎ��Ȃ� END
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� START
		private void �[�����Ƃ̏����ݒ�t�@�C���Ǎ�()
		{
			try{
				FileInfo finfo = new FileInfo(gsInitClient);
				if(finfo.Exists){
					XmlDocument xmldoc = new XmlDocument();
					xmldoc.Load(finfo.FullName);
					foreach(XmlNode node in xmldoc["configuration"]["appSettings"]){
						if(node.Attributes.GetNamedItem("key").Value.Equals("�A�h���X��_�\�����P")){
							gs�A�h���X��_�\�����P   = node.Attributes.GetNamedItem("value").Value;
						}else if(node.Attributes.GetNamedItem("key").Value.Equals("�A�h���X��_�\�����P_����")){
							gs�A�h���X��_�\�����P_����   = node.Attributes.GetNamedItem("value").Value;
						}else if(node.Attributes.GetNamedItem("key").Value.Equals("�A�h���X��_�\�����Q")){
							gs�A�h���X��_�\�����Q   = node.Attributes.GetNamedItem("value").Value;
						}else if(node.Attributes.GetNamedItem("key").Value.Equals("�A�h���X��_�\�����Q_����")){
							gs�A�h���X��_�\�����Q_����   = node.Attributes.GetNamedItem("value").Value;
						}else if(node.Attributes.GetNamedItem("key").Value.Equals("���˗��匟��_�\�����P")){
							gs���˗��匟��_�\�����P = node.Attributes.GetNamedItem("value").Value;
						}else if(node.Attributes.GetNamedItem("key").Value.Equals("���˗��匟��_�\�����P_����")){
							gs���˗��匟��_�\�����P_���� = node.Attributes.GetNamedItem("value").Value;
						}else if(node.Attributes.GetNamedItem("key").Value.Equals("���˗��匟��_�\�����Q")){
							gs���˗��匟��_�\�����Q = node.Attributes.GetNamedItem("value").Value;
						}else if(node.Attributes.GetNamedItem("key").Value.Equals("���˗��匟��_�\�����Q_����")){
							gs���˗��匟��_�\�����Q_���� = node.Attributes.GetNamedItem("value").Value;
						}
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� START
						//[IS2Client.ini]�t�@�C���ɁA�o�׎��ѕ\�����ʂ̏o�̓I�v�V�����̃`�F�b�N���e��ێ�������
						else if(node.Attributes.GetNamedItem("key").Value.Equals("�o�׎���_�����s�����O"))
						{
							gs�o�׎���_�����s�����O = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("�o�׎���_�Ԋ|���Ȃ�_����̂�"))
						{
							gs�o�׎���_�Ԋ|���Ȃ�_����̂� = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("�o�׎���_���˗���󎚂Ȃ�_����̂�"))
						{
							gs�o�׎���_���˗���󎚂Ȃ�_����̂� = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("�o�׎���_�^���󎚂Ȃ�_����̂�"))
						{
							gs�o�׎���_�^���󎚂Ȃ�_����̂� = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("�o�׎���_���X�o��_�b�r�u�̂�"))
						{
							gs�o�׎���_���X�o��_�b�r�u�̂� = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("�o�׎���_�z�������o��"))
						{
							gs�o�׎���_�z�������o�� = node.Attributes.GetNamedItem("value").Value;
						}
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� END
					}
					xmldoc = null;
				}
				finfo = null;
			}catch(Exception){
				;
			}
		}
		private void �[�����Ƃ̏����ݒ�t�@�C���ۑ�()
		{
			try{
				FileInfo finfo = new FileInfo(gsInitClient);
				XmlDocument xmldoc = new XmlDocument();
				xmldoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?>"
								+ "<configuration>"
								+ "<appSettings>"
								+ "</appSettings>"
								+ "</configuration>"
								);
				XmlNode node = xmldoc["configuration"]["appSettings"];
				node.InnerXml = "";
				if(gs�A�h���X��_�\�����P != null){
					node.InnerXml += "<add key=\"�A�h���X��_�\�����P\" value=\""+gs�A�h���X��_�\�����P+"\" />";
				}
				if(gs�A�h���X��_�\�����P_���� != null){
					node.InnerXml += "<add key=\"�A�h���X��_�\�����P_����\" value=\""+gs�A�h���X��_�\�����P_����+"\" />";
				}
				if(gs�A�h���X��_�\�����Q != null){
					node.InnerXml += "<add key=\"�A�h���X��_�\�����Q\" value=\""+gs�A�h���X��_�\�����Q+"\" />";
				}
				if(gs�A�h���X��_�\�����Q_���� != null){
					node.InnerXml += "<add key=\"�A�h���X��_�\�����Q_����\" value=\""+gs�A�h���X��_�\�����Q_����+"\" />";
				}
				if(gs���˗��匟��_�\�����P != null){
					node.InnerXml += "<add key=\"���˗��匟��_�\�����P\" value=\""+gs���˗��匟��_�\�����P+"\" />";
				}
				if(gs���˗��匟��_�\�����P_���� != null){
					node.InnerXml += "<add key=\"���˗��匟��_�\�����P_����\" value=\""+gs���˗��匟��_�\�����P_����+"\" />";
				}
				if(gs���˗��匟��_�\�����Q != null){
					node.InnerXml += "<add key=\"���˗��匟��_�\�����Q\" value=\""+gs���˗��匟��_�\�����Q+"\" />";
				}
				if(gs���˗��匟��_�\�����Q_���� != null){
					node.InnerXml += "<add key=\"���˗��匟��_�\�����Q_����\" value=\""+gs���˗��匟��_�\�����Q_����+"\" />";
				}
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� START
				//[IS2Client.ini]�t�@�C���ɁA�o�׎��ѕ\�����ʂ̏o�̓I�v�V�����̃`�F�b�N���e��ێ�������
				if(gs�o�׎���_�����s�����O != null)
				{
					node.InnerXml += "<add key=\"�o�׎���_�����s�����O\" value=\""+gs�o�׎���_�����s�����O+"\" />";
				}
				if(gs�o�׎���_�Ԋ|���Ȃ�_����̂� != null)
				{
					node.InnerXml += "<add key=\"�o�׎���_�Ԋ|���Ȃ�_����̂�\" value=\""+gs�o�׎���_�Ԋ|���Ȃ�_����̂�+"\" />";
				}
				if(gs�o�׎���_���˗���󎚂Ȃ�_����̂� != null)
				{
					node.InnerXml += "<add key=\"�o�׎���_���˗���󎚂Ȃ�_����̂�\" value=\""+gs�o�׎���_���˗���󎚂Ȃ�_����̂�+"\" />";
				}
				if(gs�o�׎���_�^���󎚂Ȃ�_����̂� != null)
				{
					node.InnerXml += "<add key=\"�o�׎���_�^���󎚂Ȃ�_����̂�\" value=\""+gs�o�׎���_�^���󎚂Ȃ�_����̂�+"\" />";
				}
				if(gs�o�׎���_���X�o��_�b�r�u�̂� != null)
				{
					node.InnerXml += "<add key=\"�o�׎���_���X�o��_�b�r�u�̂�\" value=\""+gs�o�׎���_���X�o��_�b�r�u�̂�+"\" />";
				}
				if(gs�o�׎���_�z�������o�� != null)
				{
					node.InnerXml += "<add key=\"�o�׎���_�z�������o��\" value=\""+gs�o�׎���_�z�������o��+"\" />";
				}
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� END
				if(node.InnerXml.Length > 0)
				{
					XmlTextWriter writer = new XmlTextWriter(finfo.FullName, System.Text.UTF8Encoding.UTF8);
					writer.Formatting = Formatting.Indented;
					xmldoc.WriteContentTo(writer);
					writer.Flush();
					writer.Close();
				}
				xmldoc = null;
				finfo  = null;
			}catch(Exception ex){
				//ex = ex;
                string dummy = ex.Message;
			}
		}
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� END
// MOD 2010.05.24 ���s�j���� 120DPI�Ή����̕\���ʒu���� START
		private int �c�o�h�T�C�Y�ʒu����(int iSize, int iDisplayDpi)
		{
			if(iDisplayDpi == 0 || iDisplayDpi == 96) return iSize;
			if(iSize <= 0) return 0;
			return iSize * iDisplayDpi / 96;
		}
// MOD 2010.05.24 ���s�j���� 120DPI�Ή����̕\���ʒu���� END
// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� START
		private void �o�ׂb�r�u�����o�͐ݒ�t�@�C���Ǎ�()
		{
			// �t�@�C�������݂��Ȃ���ΏI��
			if( !File.Exists(gsInitSyukka) ) return;

			try{
				gi�����o�̓^�C�}�[  = 3; // 3��
// ADD 2015.04.13 BEVAS)�O�c�@�����o�̓^�C�}�[�b�P�ʎw�� START
				gi�����o�̓^�C�}�[�b  = 0; // 0�b ���@�f�t�H���g����3�� + 0�b�Ԋu�Ƃ���B
// ADD 2015.04.13 BEVAS)�O�c�@�����o�̓^�C�}�[�b�P�ʎw�� END
				string s�����o�̓^�C�}�[  = "";

				StreamReader sr = new StreamReader(gsInitSyukka, System.Text.Encoding.Default);
				s�����o�̓^�C�}�[ = sr.ReadLine();
				sr.Close();

				if(s�����o�̓^�C�}�[.Length > 0){
					if(���p�`�F�b�N(s�����o�̓^�C�}�[)){
						if(���l�`�F�b�N(s�����o�̓^�C�}�[))
						{
							gi�����o�̓^�C�}�[ = int.Parse(s�����o�̓^�C�}�[);
							// �����60��
							if(gi�����o�̓^�C�}�[ > 60)
							{
								gi�����o�̓^�C�}�[ = 60; // 60��
							}
						}
// ADD 2015.04.13 BEVAS)�O�c �����o�̓^�C�}�[�̕b�P�ʎw�� START
						else 
						{
							if ((s�����o�̓^�C�}�[.Substring(0,1) == "S") || (s�����o�̓^�C�}�[.Substring(0,1) == "s")) 
							{
								// �b�P�ʂŏo�͊Ԋu���w��
								if(���l�`�F�b�N(s�����o�̓^�C�}�[.Substring(1)))
								{
									gi�����o�̓^�C�}�[�b = int.Parse(s�����o�̓^�C�}�[.Substring(1));
									// 
									if (gi�����o�̓^�C�}�[�b < 1) 
									{
										gi�����o�̓^�C�}�[�b = 180; // 3��
										���O�o�͂Q("�����o�͂̊Ԋu��1�b�ȏ��ݒ肵�Ă��������B");
										
									}
									if(gi�����o�̓^�C�}�[�b > 3600)
									{
										gi�����o�̓^�C�}�[�b = 3600; // 60��
										���O�o�͂Q("�����o�͂̊Ԋu��60��(3600�b)�ȓ��ł�");
									}

									gi�����o�̓^�C�}�[ = gi�����o�̓^�C�}�[�b / 60;
									gi�����o�̓^�C�}�[�b = gi�����o�̓^�C�}�[�b % 60;
								}
								else 
								{
									���O�o�͂Q("�����o�͂̊Ԋu�Ƃ��ĕs���ȕ�����Ȏw�肳��Ă��܂�:" + s�����o�̓^�C�}�[);
								}
							}
							else {
								���O�o�͂Q("�����o�͂̊Ԋu�Ƃ��ĕs���ȕ�����Ȏw�肳��Ă��܂�:" + s�����o�̓^�C�}�[);
							}
						}
					}
					else 
					{
						���O�o�͂Q("�����o�͂̊Ԋu�Ƃ��ĕs���ȕ�����Ȏw�肳��Ă��܂�:" + s�����o�̓^�C�}�[);
					}
// ADD 2015.04.13 BEVAS)�O�c �����o�̓^�C�}�[�̕b�P�ʎw�� END
				}
			}catch(Exception ex){
				���O�o�͂Q(" �ݒ�t�@�C���Ǎ�"+ex.Message);
//�ۗ�
//				MessageBox.Show("�o�ׂb�r�u�����o�͗p�ݒ�t�@�C���̓Ǎ��Ɏ��s���܂���\n"
//								+ ex.Message 
//								,"�o�ׂb�r�u�����o��"
//								, MessageBoxButtons.OK);
			}
		}
		private void �o�ׂb�r�u�����o�̓t�H���_�쐬()
		{
			// �f�B���N�g�������݂��Ȃ���΍쐬����
			try{
				if(!Directory.Exists(gsPathSyukka)){
					Directory.CreateDirectory(gsPathSyukka);
				}
				if(!Directory.Exists(gsPathSyukkaIn)){
					Directory.CreateDirectory(gsPathSyukkaIn);
				}
				if(!Directory.Exists(gsPathSyukkaOut)){
					Directory.CreateDirectory(gsPathSyukkaOut);
				}
				if(!Directory.Exists(gsPathSyukkaLog)){
					Directory.CreateDirectory(gsPathSyukkaLog);
				}
			}catch(Exception ex){
				���O�o�͂Q(" �t�H���_�쐬"+ex.Message);
				MessageBox.Show("�o�ׂb�r�u�����o�͗p�t�H���_�̍쐬�Ɏ��s���܂���\n"
								+ ex.Message 
								,"�o�ׂb�r�u�����o��"
								, MessageBoxButtons.OK);
			}
		}
		private void �o�ׂb�r�u�����o�͉ߋ��t�@�C���폜()
		{
			// �f�B���N�g�������݂��Ȃ���΍쐬����
			try{
				if(Directory.Exists(gsPathSyukkaOut)){
					�ߋ��t�@�C���폜(gsPathSyukkaOut);
				}
				if(Directory.Exists(gsPathSyukkaLog)){
					�ߋ��t�@�C���폜(gsPathSyukkaLog);
				}
			}catch(Exception ex){
				���O�o�͂Q(" �ߋ��t�@�C���폜"+ex.Message);
				MessageBox.Show("�o�ׂb�r�u�����o�͗p�t�H���_�̉ߋ��t�@�C���폜�Ɏ��s���܂���\n"
								+ ex.Message 
								,"�o�ׂb�r�u�����o��"
								, MessageBoxButtons.OK);
			}
		}
		private void �ߋ��t�@�C���폜(string sPath)
		{
			try{
				// �t�@�C���ꗗ�擾
				string[] sFiles = Directory.GetFiles(sPath);
				if(sFiles.Length == 0) return;

				DateTime dt�U���O = DateTime.Now.Date.AddDays(-6);
				DateTime dtFile;
				for(int iCnt = 0; iCnt < sFiles.Length; iCnt++){
					// �t�@�C���X�^���v�̔�r
					dtFile = File.GetLastWriteTime(sFiles[iCnt]);
					if(dtFile < dt�U���O){
						File.Delete(sFiles[iCnt]);
					}
				}
			}catch(Exception ex){
//�ۗ��@�G���[����
				���O�o�͂Q(" �ߋ��t�@�C���폜"+ex.Message);
			}
		}

		private string s���O�o�͂Q = "";
		private void ���O�o�͂Q(string message)
		{
			if(s���O�o�͂Q.Length == 0){
				s���O�o�͂Q = gsPathSyukkaLog + "\\" + YYYYMMDD�ϊ�(DateTime.Now) + ".log";
			}

			// ���O�p�t�H���_���Ȃ���Ζ߂�
			if(!Directory.Exists(gsPathSyukkaLog)) return;

			StringBuilder sbBuff = new StringBuilder(2048);
			sbBuff.Append("["+ System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") +"]");
			sbBuff.Append(message);

			try{
				StreamWriter swp = new StreamWriter(s���O�o�͂Q, true, enc);
				swp.WriteLine(sbBuff);
				swp.Close();
				
			}catch(Exception ){
//�ۗ�			;
			}
		}

		private bool b�G���[�o�͂Q = false;
		private int  i�G���[�s���Q = 0;
		private int  i�O��G���[�s = 0;
		private void �G���[�o�͂Q(string sErrFile, int nRow, int nCol, string message)
		{
			b�G���[�o�͂Q = true;
			if(i�O��G���[�s != nRow){
				i�O��G���[�s = nRow;
				i�G���[�s���Q++;
			}

			// �o�͗p�t�H���_���Ȃ���Ζ߂�
			if(!Directory.Exists(gsPathSyukkaOut)) return;

			try{
				StreamWriter swp = new StreamWriter(sErrFile, true, enc);
//				swp.WriteLine(nRow.ToString("00000")+"�s��:"+message);
				swp.Write(nRow.ToString("00000")+"�s��:"+message);
				swp.Close();
				
			}catch(Exception ){
//�ۗ�			;
			}
		}
// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� END

		private void btn�����o��_Click(object sender, System.EventArgs e)
		{
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
			�d�ʓ��͐���擾();
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END
			�o�ׂb�r�u�����o�̓t�H���_�쐬();
			if(btn�����o��.Text == "�����o�� ON"){
				�o�ׂb�r�u�����o�͐ݒ�t�@�C���Ǎ�();
// MOD 2015.04.13 BEVAS)�O�c �����o�̓^�C�}�[�b�Ή� START
				//if(gi�����o�̓^�C�}�[ > 0){
				if((gi�����o�̓^�C�}�[ > 0) || (gi�����o�̓^�C�}�[�b > 0)){
// MOD 2015.04.13 BEVAS)�O�c �����o�̓^�C�}�[�b�Ή� END
					gb�����o�͂n�m   = true;
					btn�����o��.Text = "�����o�� OFF";
					���O�o�͂Q(" �����o�͂n�m");
// MOD 2015.04.13 BEVAS)�O�c �����o�̓^�C�}�[�b�Ή� START
					//���O�o�͂Q(" �t�@�C���m�F�Ԋu�F"+gi�����o�̓^�C�}�[+"��");
					���O�o�͂Q(" �t�@�C���m�F�Ԋu�F"+gi�����o�̓^�C�}�[+"��"+gi�����o�̓^�C�}�[�b+"�b");
// MOD 2015.04.13 BEVAS)�O�c �����o�̓^�C�}�[�b�Ή� END
				}
				else
				{
					gb�����o�͂n�m   = false;
					btn�����o��.Text = "�����o�� ON";
					���O�o�͂Q(" �����o�͂n�e�e");
				}
			}else{
				gb�����o�͂n�m   = false;
				btn�����o��.Text = "�����o�� ON";
				���O�o�͂Q(" �����o�͂n�e�e");
			}
			btn�����o��.Refresh();

			if(gb�����o�͂n�m){
//�ۗ� MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
//�ۗ�				btn�m�F.Enabled = false;
//�ۗ� MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
//				�o�ׂb�r�u�����o�̓t�H���_�쐬();
// MOD 2010.04.21 ���s�j���� �n���O�ߎ�����̖h�~ START
//				�t�@�C���ꗗ�擾�P();
				if(!b���s��_ThreadTask1) �t�@�C���ꗗ�擾�P();
// MOD 2010.04.21 ���s�j���� �n���O�ߎ�����̖h�~ END
				// �^�C�}�[�̐ݒ������
				if(tim�o�ׂb�r�u�����o�� == null){
					tim�o�ׂb�r�u�����o�� = new System.Windows.Forms.Timer(this.components);
					tim�o�ׂb�r�u�����o��.Tick += new System.EventHandler(tim�o�ׂb�r�u�����o��_Tick);
//					if(gi�����o�̓^�C�}�[ == 1){
//						tim�o�ׂb�r�u�����o��.Interval = 3 * 1000; // 3�b
//					}else{
//						tim�o�ׂb�r�u�����o��.Interval = (gi�����o�̓^�C�}�[ - 1) * 60 * 1000;
//					}
				}
// MOD 2015.04.13 BEVAS)�O�c�@�����o�̓^�C�}�[�b�Ή� START
				//tim�o�ׂb�r�u�����o��.Interval = gi�����o�̓^�C�}�[ * 60 * 1000;
				tim�o�ׂb�r�u�����o��.Interval = ((gi�����o�̓^�C�}�[ * 60) + gi�����o�̓^�C�}�[�b) * 1000;
// MOD 2015.04.13 BEVAS)�O�c�@�����o�̓^�C�}�[�b�Ή� END
				tim�o�ׂb�r�u�����o��.Enabled = true;
			}else{
//�ۗ� MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
//�ۗ�				btn�m�F.Enabled = true;
//�ۗ� MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
				if(tim�o�ׂb�r�u�����o�� != null){
					tim�o�ׂb�r�u�����o��.Enabled = false;
				}
			}
// MOD 2010.06.01 ���s�j���� �����o�̓{�^���̈ړ� START
			if(gb�����o�͂n�m){
				lab�����o�͂n�m.Visible = true;
				pic�����׎D���s.Visible   = false;
				pic�`���C�X�v�����g.Visible = false;
				pic�Ĕ��s.Visible           = false;
				pic�����o�דo�^.Visible     = false;
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� START
				pic�o�[�R�[�h�ǎ�.Visible = false;
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� END
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� START
				pic���x���C���[�W���.Visible = false;
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� END
			}
			else
			{
				lab�����o�͂n�m.Visible = false;
				if(gs�v�����^�e�f == "1"){
					pic�����׎D���s.Visible   = true;
					pic�`���C�X�v�����g.Visible = true;
					pic�Ĕ��s.Visible           = true;
				}
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� START
				// �G���g���[�I�v�V�����ɐݒ肵���l�ɂ��A���Y�{�^���̕\���E��\����؂�ւ���
				if(gs�I�v�V����[22].Equals("0"))
				{
					pic�o�[�R�[�h�ǎ�.Visible = true;
				}
				else
				{
					pic�o�[�R�[�h�ǎ�.Visible = false;
				}
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� END
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� START
				pic���x���C���[�W���.Visible = true;
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� END
				pic�����o�דo�^.Visible     = true;
			}
// MOD 2010.06.01 ���s�j���� �����o�̓{�^���̈ړ� END
		}

		private void btn�����o�̓t�H���__Click(object sender, System.EventArgs e)
		{
			�o�ׂb�r�u�����o�̓t�H���_�쐬();
			if(!Directory.Exists(gsPathSyukka)) return;

			// �G�N�X�v���[���ŊJ��
			System.Diagnostics.Process process = new System.Diagnostics.Process(); 
			process.StartInfo.Arguments = "\"" + gsPathSyukka + "\"";
			process.StartInfo.WorkingDirectory = gsPathSyukka;
			process.StartInfo.FileName = "explorer.exe";
			try{
				process.Start();
			}catch(System.ComponentModel.Win32Exception ex){
				���O�o�͂Q(" �G�N�X�v���[���̋N��"+ex.Message);
			    // �t�@�C����������Ȃ������ꍇ�A
			    // �֘A�t����ꂽ�A�v���P�[�V������������Ȃ������ꍇ��
				MessageBox.Show("�G�N�X�v���[���̋N���Ɏ��s���܂���\n"
								+ ex.Message 
								,"�o�ׂb�r�u�����o��"
								, MessageBoxButtons.OK);
			}catch(System.Exception ex ){
				���O�o�͂Q(" �G�N�X�v���[���̋N��"+ex.Message);
			    // ���̑�
				MessageBox.Show("�G�N�X�v���[���̋N���Ɏ��s���܂���\n"
								+ ex.Message 
								,"�o�ׂb�r�u�����o��"
								, MessageBoxButtons.OK);
			}
		}
// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� END

		private bool b���s��_tim�o�ׂb�r�u�����o��_Tick = false; // �N���t���O
		private void tim�o�ׂb�r�u�����o��_Tick(object sender, System.EventArgs e)
		{
			if(b���s��_tim�o�ׂb�r�u�����o��_Tick) return;
// MOD 2010.04.21 ���s�j���� �n���O�ߎ�����̖h�~ START
			if(b���s��_ThreadTask1) return;
// MOD 2010.04.21 ���s�j���� �n���O�ߎ�����̖h�~ END
			b���s��_tim�o�ׂb�r�u�����o��_Tick = true;
			try{
				if(!Directory.Exists(gsPathSyukka))    return;
				if(!Directory.Exists(gsPathSyukkaIn))  return;
				if(!Directory.Exists(gsPathSyukkaOut)) return;
				if(!Directory.Exists(gsPathSyukkaLog)) return;

// MOD 2010.04.21 ���s�j���� �n���O�ߎ�����̖h�~ START
//				// �t�@�C���ꗗ�擾�P
////				���O�o�͂Q(" �t�@�C���ꗗ�擾�P");
//				string[] sFiles1 = Directory.GetFiles(gsPathSyukkaIn);
//				if(sFiles1.Length == 0) return;
//				DateTime[] dtFiles1 = new DateTime[sFiles1.Length];
//				long[]     lsFiles1 = new long[sFiles1.Length];
//				for(int iCnt = 0; iCnt < sFiles1.Length; iCnt++){
//					dtFiles1[iCnt] = File.GetLastWriteTime(sFiles1[iCnt]);
//					try{
//						FileStream fs = new FileStream(sFiles1[iCnt], FileMode.Open);
//						lsFiles1[iCnt] = fs.Length;
//						fs.Close();
//					}catch(IOException ex){
////�ۗ��@�G���[����
//						���O�o�͂Q(" �t�@�C���T�C�Y�擾�P "+ex.Message);
//					}
//				}
//
////�ۗ��@�e�X�g���̓R�����g
////				System.Threading.Thread.Sleep(60 * 1000); // �P���ԑ҂�
//				System.Threading.Thread.Sleep(20 * 1000); // �Q�O�b�҂�
//				if(sFiles1 == null) return;
				if(sFiles1.Length == 0){
					�t�@�C���ꗗ�擾�P();
					return;
				}
				//�X���b�h�����ɋN�����ł���΁A�I�������j������
				if(trd1 != null){
					trd1.Abort();
					trd1 = null;
				}
				if(!gb�����o�͂n�m) return; //�����o�͂������ł���ΏI��
				//�X���b�h���쐬
				trd1 = new Thread(new ThreadStart(ThreadTask1));
				trd1.IsBackground = true;
				trd1.Start();
			}catch(Exception ex){
//�ۗ��@�G���[����
				���O�o�͂Q(" �t�@�C���ꗗ�擾�Q "+ex.Message);
			}finally{
				b���s��_tim�o�ׂb�r�u�����o��_Tick = false;
			}
		}

		public bool b���s��_ThreadTask1 = false; // �N���t���O
		private void ThreadTask1()
		{
			if(b���s��_ThreadTask1) return;
			b���s��_ThreadTask1 = true;
			try{
// MOD 2010.04.21 ���s�j���� �n���O�ߎ�����̖h�~ END
				// �t�@�C���ꗗ�擾�Q
//				���O�o�͂Q(" �t�@�C���ꗗ�擾�Q");
				string[] sFiles2 = Directory.GetFiles(gsPathSyukkaIn);
				if(sFiles2.Length == 0) return;
				// �t�@�C���X�^���v�̌Â����Ƀ\�[�g����
				DateTime[] dtFiles2 = new DateTime[sFiles2.Length];
				for(int iCnt2 = 0; iCnt2 < sFiles2.Length; iCnt2++){
					// �t�@�C���X�^���v�̎擾
					dtFiles2[iCnt2] = File.GetLastWriteTime(sFiles2[iCnt2]);
				}
				Array.Sort(dtFiles2, sFiles2);
				if(!gb�����o�͂n�m) return; //�����o�͂������ł���ΏI��
				long     lsFile;
// MOD 2010.04.21 ���s�j���� �n���O�ߎ�����̖h�~ START
//				string[] s�X����� = �X����񓙎擾();
				string[] s�X����� = null;
// MOD 2010.04.21 ���s�j���� �n���O�ߎ�����̖h�~ END
				for(int iCnt2 = 0; iCnt2 < sFiles2.Length; iCnt2++){
					if(!gb�����o�͂n�m) return; //�����o�͂������ł���ΏI��
					//�O��̃t�@�C���ꗗ���ʂƔ�r
					for(int iCnt1 = 0; iCnt1 < sFiles1.Length; iCnt1++){
						if(!gb�����o�͂n�m) return; //�����o�͂������ł���ΏI��
						// �t�@�C�����̔�r
						if(sFiles2[iCnt2] != sFiles1[iCnt1]) continue;
						// �t�@�C���X�^���v�̔�r
						if(dtFiles2[iCnt2] != dtFiles1[iCnt1]) break;
						// �t�@�C���T�C�Y�̔�r
						try{
							FileStream fs = new FileStream(sFiles2[iCnt2], FileMode.Open);
							lsFile = fs.Length;
							fs.Close();
							if(lsFile != lsFiles1[iCnt1]) break;
						}catch(IOException ex){
//�ۗ��@�G���[����
							���O�o�͂Q(" �t�@�C���T�C�Y�擾�Q "+ex.Message);
							break;
						}

// MOD 2010.04.21 ���s�j���� �n���O�ߎ�����̖h�~ START
						if(s�X����� == null){
							s�X����� = �X����񓙎擾();
						}
						System.Threading.Thread.Sleep(200); // 0.2�b�҂�
// MOD 2010.04.21 ���s�j���� �n���O�ߎ�����̖h�~ END
						�o�ׂb�r�u���(sFiles2[iCnt2], s�X�����[1]
									, s�X�����[2], s�X�����[3]);
						break;
					}
				}
// MOD 2010.04.21 ���s�j���� �n���O�ߎ�����̖h�~ START
				�t�@�C���ꗗ�擾�P();
// MOD 2010.04.21 ���s�j���� �n���O�ߎ�����̖h�~ END
			}catch(Exception ex){
//�ۗ��@�G���[����
				���O�o�͂Q(" �t�@�C���ꗗ�擾�Q "+ex.Message);
			}finally{
// MOD 2010.04.21 ���s�j���� �n���O�ߎ�����̖h�~ START
//				b���s��_tim�o�ׂb�r�u�����o��_Tick = false;
				b���s��_ThreadTask1 = false;
// MOD 2010.04.21 ���s�j���� �n���O�ߎ�����̖h�~ END
			}
		}

		private string[] �X����񓙎擾()
		{
			string[] sCsvRet = {"","","",""};

//			tex���b�Z�[�W.Text = "�o�ד��擾���D�D�D";
//			tex���b�Z�[�W.Refresh();
			���O�o�͂Q(" �o�ד��擾");
//			Cursor = System.Windows.Forms.Cursors.AppStarting;

			����o�ד����X�V();
			Cursor = System.Windows.Forms.Cursors.Default;

			string[] sRet = {""};
			string s���X�b�c   = "";
			string s���X��     = "";
			string s�W��X�b�c = "";

//			tex���b�Z�[�W.Text = "���X�擾���D�D�D";
//			tex���b�Z�[�W.Refresh();
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� START
			//�Г��`����̈��X�o�^�`�F�b�N
			if(gs����X���b�c.Equals("044"))
			{
				���O�o�͂Q(" �Г��`������X�`�F�b�N");
				Cursor = System.Windows.Forms.Cursors.AppStarting;

				string[] saChkRet = �b�l�O�T������X�e�`�F�b�N();
				int iChkRet = int.Parse(saChkRet[0]);
				string sChkRet = saChkRet[1];

				Cursor = System.Windows.Forms.Cursors.Default;
				if(iChkRet == 1)
				{
					if(sChkRet.Equals("�Y���f�[�^������܂���"))
					{
						���O�o�͂Q(" �Г��`������X�`�F�b�N�G���[�F�����p�̉���Ɉ��X�o�^������܂���ł���");
						throw new Exception("�����p�̉���Ɉ��X�o�^������܂���ł���");
					}
					else
					{
						���O�o�͂Q(" �Г��`������X�`�F�b�N�G���[�F" + sChkRet);
						throw new Exception(sChkRet);
					}
				}
			}
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� END
			���O�o�͂Q(" ���X�擾");
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			//���X�擾
			try{
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
//				if (gs����b�c.Substring(0,1) != "J")
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
				���O�o�͂Q(" ���X�擾�G���[�F"+gs�ʐM�G���[);
				throw new Exception(gs�ʐM�G���[);
			}catch (Exception ex){
				���O�o�͂Q(" ���X�擾�G���[�F"+ex.Message);
				throw new Exception("�ʐM�G���[�F" + ex.Message);
			}finally{
				Cursor = System.Windows.Forms.Cursors.Default;
			}
			if(sRet[0].Equals("����I��")){
				s���X�b�c = sRet[1];	//���X�b�c
				s���X��   = sRet[2];	//���X��
				if (s���X��.Length == 0) s���X�� = " ";
			}else{
				if(sRet[0].Equals("�Y���f�[�^������܂���")){
					���O�o�͂Q(" ���X�擾�G���[�F���X�����߂��܂���ł���");
					throw new Exception("���X�����߂��܂���ł���");
				}else{
					���O�o�͂Q(" ���X�擾�G���[�F"+sRet[0]);
					throw new Exception(sRet[0]);
				}
			}
//			tex���b�Z�[�W.Text = "�W��X�擾���D�D�D";
//			tex���b�Z�[�W.Refresh();
			���O�o�͂Q(" �W��X�擾");
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			//�W��X�擾
			try{
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
//				if (gs����b�c.Substring(0,1) != "J")
				else if (gs����b�c.Substring(0,1) != "J")
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� END
				{
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END
					if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
					sRet = sv_syukka.Get_syuuyakuten2(gsa���[�U,gs����b�c,gs����b�c);
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� START
				}
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� START
				else if(gs����X���b�c.Equals("044"))
				{
					//�Г��`��������́A�W��X���擾
					if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
					sRet = sv_syukka.Get_syuuyakuten2_HouseSlip(gsa���[�U,gs����b�c);
				}
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� END
				else
				{
					if(sv_oji == null) sv_oji = new is2oji.Service1();
					sRet = sv_oji.Get_syuuyakuten2(gsa���[�U,gs����b�c,gs����b�c);
				}
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END
			}catch (System.Net.WebException){
				���O�o�͂Q(" �W��X�擾�G���[�F"+gs�ʐM�G���[);
				throw new Exception(gs�ʐM�G���[);
			}catch (Exception ex){
				���O�o�͂Q(" �W��X�擾�G���[�F"+ex.Message);
				throw new Exception("�ʐM�G���[�F" + ex.Message);
			}finally{
				Cursor = System.Windows.Forms.Cursors.Default;
			}
			if(sRet[0] != " "){
				s�W��X�b�c = sRet[1];	//�W��X�b�c
			}else{
				if(sRet[0].Equals("�Y���f�[�^������܂���")){
					���O�o�͂Q(" �W��X�擾�G���[�F�W��X�����߂��܂���ł���");
					throw new Exception("�W��X�����߂��܂���ł���");
				}else{
					���O�o�͂Q(" �W��X�擾�G���[�F"+sRet[0]);
					throw new Exception(sRet[0]);
				}
			}
			sCsvRet[1] = s���X�b�c; 
			sCsvRet[2] = s���X��; 
			sCsvRet[3] = s�W��X�b�c; 

			return sCsvRet;
		}
		private void �o�ׂb�r�u���(string sCsvFile, string s���X�b�c, string s���X��, string s�W��X�b�c)
		{
			string sErr = "";
			string[] sRet = {""};
// MOD 2010.04.19 ���s�j���� �o�̓t�@�C�����̕ύX START
//			string sErrFile = gsPathSyukkaOut + "\\" + Path.GetFileName(sCsvFile) + ".txt";
			string s���s���� = DateTime.Now.ToString("yyyyMMddHHmmss");
			string sErrFile  = gsPathSyukkaOut + "\\" + Path.GetFileName(sCsvFile)
							 + "_" + s���s���� + ".txt";
// MOD 2010.04.19 ���s�j���� �o�̓t�@�C�����̕ύX END

// �ۗ��@�b�r�u�`���`�F�b�N
//			if (!axGT�捞�f�[�^�ꗗ.LoadCsvFile(sCsvFile))
//			{
//				tex���b�Z�[�W.Text = "CSV�t�@�C���̎�荞�݂Ɏ��s���܂���";
//				axGT�捞�f�[�^�ꗗ.Rows = 10;
//				return;
//			}

			b�G���[�o�͂Q = false;
			i�G���[�s���Q = 0;
			i�O��G���[�s = 0;

//�ۗ��@1000���͉��ݒ�
			string[] s�捞�f�[�^�Q = new string[1000];
			int i�捞�s���Q = 0;
			int iCnt = 0;

//			tex���b�Z�[�W.Text = "�o�ׂb�r�u�����o�� �Ǎ����D�D�D";
//			tex���b�Z�[�W.Refresh();
			���O�o�͂Q(" ���̓t�@�C��["+sCsvFile+"]");
			���O�o�͂Q(" �`�F�b�N�J�n");
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			StreamReader sr = new StreamReader(sCsvFile, System.Text.Encoding.Default);
//�ۗ��@��ʂ̐擪�s������L���ɂ��邩
//			if( cBox�擪�s����.Checked ){
//				if(sr.Peek() != -1) iCnt++;
//				string sDataDummy = sr.ReadLine();
//			}

			try
			{
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX START
				string sChkMsg = "";
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX END
//�ۗ��@1000���͉��ݒ�
//				while(iCnt <= 1000)
				while(iCnt <= 2000)
				{
					if(!gb�����o�͂n�m) return; //�����o�͂������ł���ΏI��
					if(sr.Peek() == -1) break;
//					tex���b�Z�[�W.Text = "�o�ׂb�r�u�����o�� �m�F���D�D�D" + iCnt + "����";
//					tex���b�Z�[�W.Refresh();
					iCnt++;
					���O�o�͂Q(" �`�F�b�N " + iCnt.ToString("0000") + " �s��");
					string sData = sr.ReadLine();

					//UniCode�̉��s�Ή�
					if(sData == null) sData = "";

					string[] sValue = sData.Replace("\"","").Replace("\'","").Split(',');
					if(sValue.Length <= 1){
						continue;
					}

// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
//					if(sValue.Length != 26 && sValue.Length != 25){
//						�G���[�o�͂Q(sErrFile, iCnt, 0, "���ڐ����Ⴂ�܂�\r\n");
//						continue;
//					}
					if(sValue.Length != 26 && sValue.Length != 25
						&& sValue.Length != 30 && sValue.Length != 29){
						�G���[�o�͂Q(sErrFile, iCnt, 0, "���ڐ����Ⴂ�܂�\r\n");
						continue;
					}
					if(sValue.Length == 30 || sValue.Length == 29)
					{
						i�b�r�u�G���g���[�`�� = 2;
					}
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� START
					//�u�L��6�s�t�H�[�}�b�gCSV���L��3�s�t�H�[�}�b�gCSV�v�̎捞���̃o�O���C��
					//�@�@���uIndex was outside the bounds of the array.�i��IndexOutOfRangeException�j�v������
					else if(sValue.Length == 26 || sValue.Length == 25)
					{
						i�b�r�u�G���g���[�`�� = 1;
					}
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END

					//�w�b�_�s�Ȃ̂œǂݔ�΂�
					if(sValue[0].IndexOf("�׎�l�R�[�h") >= 0
						&& sValue[1].IndexOf("�d�b�ԍ�") >= 0
						&& sValue[2].IndexOf("�Z��") >= 0){
						continue;
					}
//�ۗ��@1000���͉��ݒ�
					if(i�捞�s���Q >= s�捞�f�[�^�Q.Length){
						�G���[�o�͂Q(sErrFile, iCnt, 0
							, s�捞�f�[�^�Q.Length + "���𒴂����̂ŏ����ł��܂���B\r\n");
						break;
					}

//�ۗ� MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� START
//					// �ː��E�d�ʂɂO��ݒ�
//					if(sValue.Length > 12) sValue[12] = "0";
//					if(sValue.Length > 13) sValue[13] = "0";
//�ۗ� MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� END

// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
//					string[] sKey   = new string[46];
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
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
					string[] sValue�ꗗ�s = new string[sValue.Length];
					if(i�b�r�u�G���g���[�`�� == 2){
						System.Array.Copy(sValue, sValue�ꗗ�s, sValue.Length);
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
						if(!���p�`�F�b�N(sValue[0])) �G���[�o�͂Q(sErrFile, iCnt, 1, "�׎�l�R�[�h�͔��p�����œ��͂��Ă�������\r\n");
						sKey[4] = sValue[0];
						if(���p�`�F�b�N(sValue[0]))
						{
							if(!�L���`�F�b�N(sValue[0])){
								�G���[�o�͂Q(sErrFile, iCnt, 1, "�׎�l�R�[�h�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
							}else{
								//�׎�l�R�[�h���݃`�F�b�N
								try
								{
//�ۗ��@�`�F�b�N���܂Ƃ߂�\��
//		sValue[0]�͔��p
//		sValue[0]�͋L���ł͂Ȃ�
//		sValue[0]�͂V���ȓ�
//	�����F
//		gs����b�c
//		gs����b�c
//		sKey[4]		�׎�l�b�c
//	�߂�l�F
//		[0]		����
//		[2-12]	�l�i�d�b�ԍ��P�Ȃǁj
//	�T�v�F
//		���͂�������擾����
									if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
									sRet = sv_otodoke.Get_Stodokesaki(gsa���[�U,gs����b�c,gs����b�c,sKey[4]);
								}
								catch (System.Net.WebException)
								{
									�G���[�o�͂Q(sErrFile, iCnt, 1
										, "�׎�l���擾�G���[�F"+gs�ʐM�G���[+"\r\n");
									throw new Exception(gs�ʐM�G���[);
								}
								catch (Exception ex)
								{
									�G���[�o�͂Q(sErrFile, iCnt, 1
										, "�׎�l���擾�G���[�F"+ex.Message+"\r\n");
									throw new Exception("�ʐM�G���[�F" + ex.Message);
								}
								if(!sRet[0].Equals("�X�V"))
								{
									if(sRet[0].Equals("�o�^"))
									{
										�G���[�o�͂Q(sErrFile, iCnt, 1
											, "�׎�l�R�[�h["+sKey[4]+"]�����݂��܂���\r\n");
									}
									else
									{
										�G���[�o�͂Q(sErrFile, iCnt, 1
											, "�׎�l���擾�G���[�F"+sRet[0]+"\r\n");
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
//�ۗ��@�`�F�b�N���܂Ƃ߂�\��
//		sKey[14]�i�X�֔ԍ��j������
//	�����F
//		sKey[0]		����b�c
//		sKey[1]		����b�c
//		sKey[4]		�׎�l�b�c
//		sKey[14]	�X�֔ԍ�
//		sKey[9]+[10]+[11] �Z���P�Q�R
//		sKey[12]+[13] ���O�P�Q
//	�߂�l�F
//		[0]		����
//		[1]		�Z���b�c
//		[2]		���X�b�c
//		[3]		���X��
//	�T�v�F
//		���X�����擾����

// MOD 2015.05.07 BEVAS�j�O�c ���q�^���X�֔ԍ����݃`�F�b�N�Ή� START
											if (gs����b�c.Substring(0,1) != "J") 
											{
// MOD 2015.05.07 BEVAS�j�O�c ���q�^���X�֔ԍ����݃`�F�b�N�Ή� END
												if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
												sRet = sv_syukka.Get_autoEntryPref3(gsa���[�U, sKey[0], sKey[1], sKey[4]
													, sKey[14], sKey[9] + sKey[10] + sKey[11], sKey[12] + sKey[13]);
// MOD 2015.05.07 BEVAS�j�O�c ���q�^���X�֔ԍ����݃`�F�b�N�Ή� START
											} 
											else 
											{
												// ���q�̉���l�̏ꍇ�͉��q�̗X�֔ԍ��}�X�^���`�F�b�N
												if(sv_oji == null) sv_oji = new is2oji.Service1();
												sRet = sv_oji.Get_autoEntryPref3(gsa���[�U, sKey[0], sKey[1], sKey[4]
													, sKey[14], sKey[9] + sKey[10] + sKey[11], sKey[12] + sKey[13]);
											}
// MOD 2015.05.07 BEVAS�j�O�c ���q�^���X�֔ԍ����݃`�F�b�N�Ή� END

										}
										catch (System.Net.WebException)
										{
											�G���[�o�͂Q(sErrFile, iCnt, 1
												, "�׎�l���X�擾�G���[�F"+gs�ʐM�G���[+"\r\n");
											throw new Exception(gs�ʐM�G���[);
										}
										catch (Exception ex)
										{
											�G���[�o�͂Q(sErrFile, iCnt, 1
												, "�׎�l���X�擾�G���[�F"+ex.Message+"\r\n");
											throw new Exception("�ʐM�G���[�F" + ex.Message);
										}
										if(sRet[0].Length != 4)
										{
											if(sRet[0].Equals("�Y���f�[�^������܂���"))
											{
												�G���[�o�͂Q(sErrFile, iCnt, 1
													, "�X�֔ԍ�["+sKey[14]+"]�����݂��܂���\r\n");
											}
											else
											{
												�G���[�o�͂Q(sErrFile, iCnt, 1
													, "�׎�l���X�擾�G���[�F"+sRet[0]+"\r\n");
												throw new Exception(sRet[0]);
											}
										}
										else
										{
											sKey[15] = sRet[2];	//���X�b�c
											sKey[16] = sRet[3];	//���X��
											if (sKey[16].Length == 0) sKey[16] = " ";
											sKey[8]  = sRet[1];	//�Z���b�c
										}
									}
									else
									{
										sKey[14] = " "; // �׎�l�b�c
									}
								}
							}
						}
					}
					else
					{
						sKey[4] = " "; // �׎�l�b�c
					}

					//�d�b�ԍ�
					sValue[1] = sValue[1].Trim();
					if (sKey[4].Trim().Length == 0 && !�K�{�`�F�b�N(sValue[1])) �G���[�o�͂Q(sErrFile, iCnt, 2, "�d�b�ԍ��͕K�{���ڂł�\r\n");
					if (sValue[1].Length != 0)
					{
						try
						{
							if (!���p�`�F�b�N(sValue[1])) �G���[�o�͂Q(sErrFile, iCnt, 2, "�d�b�ԍ��͔��p�����œ��͂��Ă�������\r\n");
							if (sValue[1].IndexOf("(") == -1 && sValue[1].LastIndexOf(")") == -1)
							{
								if (sValue[1].IndexOf("-") == sValue[1].LastIndexOf("-") && sValue[1].IndexOf("-") != -1)
								{
									sKey[5] = " ";
									sKey[6] = sValue[1].Substring(0, sValue[1].IndexOf("-"));
									sKey[7] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
									if (!���l�`�F�b�N(sKey[6]) || !���l�`�F�b�N(sKey[7]))
										�G���[�o�͂Q(sErrFile, iCnt, 2, "�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
								}
								else if (sValue[1].IndexOf("-") != sValue[1].LastIndexOf("-") && sValue[1].IndexOf("-") != -1)
								{
									sKey[5] = sValue[1].Substring(0, sValue[1].IndexOf("-"));
									sKey[6] = sValue[1].Substring(sValue[1].IndexOf("-") + 1, sValue[1].LastIndexOf("-") - sValue[1].IndexOf("-") - 1);
									sKey[7] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
									if (!���l�`�F�b�N(sKey[5]) || !���l�`�F�b�N(sKey[6]) || !���l�`�F�b�N(sKey[7]))
										�G���[�o�͂Q(sErrFile, iCnt, 2, "�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
								}
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
										�G���[�o�͂Q(sErrFile, iCnt, 2, "�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
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
										�G���[�o�͂Q(sErrFile, iCnt, 2, "�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
								}
								else if (sValue[1].Length == 11)
								{
									//�d�b�ԍ��P�P��
									if(sValue[1].Substring(0,3).Equals("090")
									 || sValue[1].Substring(0,3).Equals("080")
									 || sValue[1].Substring(0,3).Equals("070")
									 || sValue[1].Substring(0,3).Equals("050")){
										//�g�ѓd�b�� 3-4-4�ŕҏW
										sKey[5] = sValue[1].Substring(0,3);
										sKey[6] = sValue[1].Substring(3,4);
										sKey[7] = sValue[1].Substring(7,4);
									}else{
										//4-3-4�ŕҏW
										sKey[5] = sValue[1].Substring(0,4);
										sKey[6] = sValue[1].Substring(4,3);
										sKey[7] = sValue[1].Substring(7,4);
									}
									if (!���l�`�F�b�N(sKey[5]) || !���l�`�F�b�N(sKey[6]) || !���l�`�F�b�N(sKey[7]))
										�G���[�o�͂Q(sErrFile, iCnt, 2, "�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
								}
								else if (sValue[1].Length == 12)
								{
									//�d�b�ԍ��P�Q��
									//4-4-4�ŕҏW
									sKey[5] = sValue[1].Substring(0,4);
									sKey[6] = sValue[1].Substring(4,4);
									sKey[7] = sValue[1].Substring(8,4);
									if (!���l�`�F�b�N(sKey[5]) || !���l�`�F�b�N(sKey[6]) || !���l�`�F�b�N(sKey[7]))
										�G���[�o�͂Q(sErrFile, iCnt, 2, "�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
								}
								else
								{
									�G���[�o�͂Q(sErrFile, iCnt, 2, "�d�b�ԍ��̌`���Ɍ�肪����܂�\r\n");
								}
							}
							else if (sValue[1].IndexOf("(") != -1 && sValue[1].LastIndexOf(")") != -1)
							{
								sKey[5] = sValue[1].Substring(sValue[1].IndexOf("(") + 1, sValue[1].LastIndexOf(")") - sValue[1].IndexOf("(") - 1);
								sKey[6] = sValue[1].Substring(sValue[1].IndexOf(")") + 1, sValue[1].LastIndexOf("-") - sValue[1].IndexOf(")") - 1);
								sKey[7] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
								if (!���l�`�F�b�N(sKey[5]) || !���l�`�F�b�N(sKey[6]) || !���l�`�F�b�N(sKey[7]))
									�G���[�o�͂Q(sErrFile, iCnt, 2, "�d�b�ԍ��͐��l�œ��͂��Ă�������\r\n");
							}
							else
							{
								�G���[�o�͂Q(sErrFile, iCnt, 2, "�d�b�ԍ��̌`���Ɍ�肪����܂�\r\n");
							}
							if (sKey[5].Length > 6) �G���[�o�͂Q(sErrFile, iCnt, 2, "�d�b�ԍ�(�s�O)�͂U�����ȓ��œ��͂��Ă�������\r\n");
							if (sKey[6].Length > 4) �G���[�o�͂Q(sErrFile, iCnt, 2, "�d�b�ԍ�(�s��)�͂S�����ȓ��œ��͂��Ă�������\r\n");
							if (sKey[7].Length > 4) �G���[�o�͂Q(sErrFile, iCnt, 2, "�d�b�ԍ�(�ԍ�)�͂S�����ȓ��œ��͂��Ă�������\r\n");
						}
						catch
						{
							�G���[�o�͂Q(sErrFile, iCnt, 2, "�d�b�ԍ��̌`���Ɍ�肪����܂�\r\n");
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
						if (!�K�{�`�F�b�N(sValue[2])) �G���[�o�͂Q(sErrFile, iCnt, 3, "�Z���P�͕K�{���ڂł�\r\n");
						if (sValue[2].Length != 0)
						{
							if (!�����ϊ�_CSV(ref sValue[2], ref sErr))
							{
								�G���[�o�͂Q(sErrFile, iCnt, 3, "�Z���P��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}
							else
							{
								// �����ϊ���o��(iCnt, 3, sValue[2]);
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� START
							if(!�S�p�ϊ��`�F�b�N(ref sValue[2], ref sErr)){
								�G���[�o�͂Q(sErrFile, iCnt, 3, "�Z���P�͑S�p�����ϊ��������Ȃ��܂���ł���"
													 + "�w" + sErr + "�x\r\n");
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� END
						}
						if (sValue[3].Length != 0)
						{
							if (!�����ϊ�_CSV(ref sValue[3], ref sErr))
							{
								�G���[�o�͂Q(sErrFile, iCnt, 4, "�Z���Q��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}
							else
							{
								// �����ϊ���o��(iCnt, 4, sValue[3]);
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� START
							if(!�S�p�ϊ��`�F�b�N(ref sValue[3], ref sErr)){
								�G���[�o�͂Q(sErrFile, iCnt, 4, "�Z���Q�͑S�p�����ϊ��������Ȃ��܂���ł���"
													 + "�w" + sErr + "�x\r\n");
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� END
						}
						if (sValue[4].Length != 0)
						{
							if (!�����ϊ�_CSV(ref sValue[4], ref sErr))
							{
								�G���[�o�͂Q(sErrFile, iCnt, 5, "�Z���R��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}
							else
							{
								// �����ϊ���o��(iCnt, 5, sValue[4]);
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� START
							if(!�S�p�ϊ��`�F�b�N(ref sValue[4], ref sErr)){
								�G���[�o�͂Q(sErrFile, iCnt, 5, "�Z���R�͑S�p�����ϊ��������Ȃ��܂���ł���"
													 + "�w" + sErr + "�x\r\n");
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� END
						}
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
					else if (sKey[4].Trim().Length == 0) �G���[�o�͂Q(sErrFile, iCnt, 3, "�Z���P�͕K�{���ڂł�\r\n");

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
						if (!�K�{�`�F�b�N(sValue[5])) �G���[�o�͂Q(sErrFile, iCnt, 6, "���O�P�͕K�{���ڂł�\r\n");
						if (sValue[5].Length != 0)
						{
							if (!�����ϊ�_CSV(ref sValue[5], ref sErr))
							{
								�G���[�o�͂Q(sErrFile, iCnt, 6, "���O�P��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}
							else
							{
								// �����ϊ���o��(iCnt, 6, sValue[5]);
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� START
							if(!�S�p�ϊ��`�F�b�N(ref sValue[5], ref sErr)){
								�G���[�o�͂Q(sErrFile, iCnt, 6, "���O�P�͑S�p�����ϊ��������Ȃ��܂���ł���"
													 + "�w" + sErr + "�x\r\n");
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� END
						}
						if (sValue[6].Length != 0)
						{
							if (!�����ϊ�_CSV(ref sValue[6], ref sErr))
							{
								�G���[�o�͂Q(sErrFile, iCnt, 7, "���O�Q��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}
							else
							{
								// �����ϊ���o��(iCnt, 7, sValue[6]);
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� START
							if(!�S�p�ϊ��`�F�b�N(ref sValue[6], ref sErr)){
								�G���[�o�͂Q(sErrFile, iCnt, 7, "���O�Q�͑S�p�����ϊ��������Ȃ��܂���ł���"
													 + "�w" + sErr + "�x\r\n");
							}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� END
						}
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
					else if (sKey[4].Trim().Length == 0) �G���[�o�͂Q(sErrFile, iCnt, 6, "���O�P�͕K�{���ڂł�\r\n");
					
					//�X�֔ԍ�
					sValue[7] = sValue[7].Trim().Replace("-", "");
					if (sKey[4].Trim().Length == 0 && !�K�{�`�F�b�N(sValue[7])) �G���[�o�͂Q(sErrFile, iCnt, 8, "�X�֔ԍ��͕K�{���ڂł�\r\n");
					if (sValue[7].Length != 0)
					{
						if (!���l�`�F�b�N(sValue[7])) �G���[�o�͂Q(sErrFile, iCnt, 8, "�X�֔ԍ��͐��l�œ��͂��Ă�������\r\n");
						if (sValue[7].Length > 7) �G���[�o�͂Q(sErrFile, iCnt, 8, "�X�֔ԍ��͂V�����ȓ��œ��͂��Ă�������\r\n");
						if (���l�`�F�b�N(sValue[7]) && sValue[7].Length <= 7)
						{
							//�Z�����݃`�F�b�N
							try
							{
//�ۗ��@�`�F�b�N���܂Ƃ߂�\��
//		sValue[7]�i�X�֔ԍ��j�͐��l
//		sValue[7]�i�X�֔ԍ��j�͂V���ȓ�
//	�����F
//		sKey[0]		����b�c
//		sKey[1]		����b�c
//		sKey[4]		�׎�l�b�c
//		sValue[7]	�X�֔ԍ�
//		sValue[2]+[3]+[4] �Z���P�Q�R
//		sValue[5]+[6] ���O�P�Q
//	�߂�l�F
//		[0]		����
//		[1]		�Z���b�c
//		[2]		���X�b�c
//		[3]		���X��
//	�T�v�F
//		���X�����擾����


// MOD 2015.05.07 BEVAS�j�O�c ���q�^���X�֔ԍ����݃`�F�b�N�Ή� START
								if (gs����b�c.Substring(0,1) != "J") 
								{
// MOD 2015.05.07 BEVAS�j�O�c ���q�^���X�֔ԍ����݃`�F�b�N�Ή� END
									if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
									sRet = sv_syukka.Get_autoEntryPref3(gsa���[�U, sKey[0], sKey[1], sKey[4], sValue[7]
										, sValue[2] + sValue[3] + sValue[4], sValue[5] + sValue[6]);
// MOD 2015.05.07 BEVAS�j�O�c ���q�^���X�֔ԍ����݃`�F�b�N�Ή� START
								} 
								else 
								{
// ���q�̉���l�̏ꍇ�͉��q�̗X�֔ԍ��}�X�^���`�F�b�N
									if(sv_oji == null) sv_oji = new is2oji.Service1();
									sRet = sv_oji.Get_autoEntryPref3(gsa���[�U, sKey[0], sKey[1], sKey[4], sValue[7]
										, sValue[2] + sValue[3] + sValue[4], sValue[5] + sValue[6]);	
								}
// MOD 2015.05.07 BEVAS�j�O�c ���q�^���X�֔ԍ����݃`�F�b�N�Ή� END

							}
							catch (System.Net.WebException)
							{
								�G���[�o�͂Q(sErrFile, iCnt, 8
									, "�׎�l���X�擾�G���[�F"+gs�ʐM�G���[+"\r\n");
								throw new Exception(gs�ʐM�G���[);
							}
							catch (Exception ex)
							{
								�G���[�o�͂Q(sErrFile, iCnt, 8
									, "�׎�l���X�擾�G���[�F"+ex.Message+"\r\n");
								throw new Exception("�ʐM�G���[�F" + ex.Message);
							}
							if(sRet[0].Length != 4)
							{
								if(sRet[0].Equals("�Y���f�[�^������܂���"))
								{
									�G���[�o�͂Q(sErrFile, iCnt, 8
										, "�X�֔ԍ�["+sValue[7]+"]�����݂��܂���\r\n");
								}
								else
								{
									�G���[�o�͂Q(sErrFile, iCnt, 8
										, "�׎�l���X�擾�G���[�F"+sRet[0]+"\r\n");
									throw new Exception(sRet[0]);
								}
							}
							else
							{
								sKey[15] = sRet[2];	//���X�b�c
								sKey[16] = sRet[3];	//���X��
								if (sKey[16].Length == 0) sKey[16] = " ";
								sKey[8]  = sRet[1];	//�Z���b�c
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
						if (���p�`�F�b�N(sValue[8]))
						{
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
//							if(!�L���`�F�b�N(sValue[8])) �G���[�o�͂Q(sErrFile, iCnt, 9, "����v�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END
							if (sValue[8].Length > 5) �G���[�o�͂Q(sErrFile, iCnt, 9, "����v�͔��p�T�����ȓ��œ��͂��Ă�������\r\n");
						}
						else
						{
							�G���[�o�͂Q(sErrFile, iCnt, 9, "����v�͔��p�����œ��͂��Ă�������\r\n");
						}
					}

					//�ב��l�R�[�h
					sValue[10] = sValue[10].Trim();
					if (!�K�{�`�F�b�N(sValue[10])) �G���[�o�͂Q(sErrFile, iCnt, 11, "�ב��l�R�[�h�͕K�{���ڂł�\r\n");
					if (!���p�`�F�b�N(sValue[10])) �G���[�o�͂Q(sErrFile, iCnt, 11, "�ב��l�R�[�h�͔��p�����œ��͂��Ă�������\r\n");
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
						if(!�L���`�F�b�N(sValue[10])){
							�G���[�o�͂Q(sErrFile, iCnt, 11, "�ב��l�R�[�h�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
						}else{
							//�ב��l���݃`�F�b�N
							try
							{
//�ۗ��@�`�F�b�N���܂Ƃ߂�\��
//		sValue[10]�͕K�{
//		sValue[10] -> sKey[18]�i�ב��l�R�[�h�j�����p
								if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
//�ۗ� MOD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� START
//�ۗ� MOD 2007.04.20 ���s�j���� �b�r�u�G���g���i�����o�דo�^�j�̍����� END
								sRet = sv_syukka.Get_autoEntryClaim(gsa���[�U,gs����b�c,gs����b�c,sKey[18]);
							}
							catch (System.Net.WebException)
							{
								�G���[�o�͂Q(sErrFile, iCnt, 11
									, "�ב��l���擾�G���[�F"+gs�ʐM�G���[+"\r\n");
								throw new Exception(gs�ʐM�G���[);
							}
							catch (Exception ex)
							{
								�G���[�o�͂Q(sErrFile, iCnt, 11
									, "�ב��l���擾�G���[�F"+ex.Message+"\r\n");
								throw new Exception("�ʐM�G���[�F" + ex.Message);
							}
							if(sRet[0].Length != 4)
							{
								if(sRet[0].Equals("�Y���f�[�^������܂���"))
								{
									�G���[�o�͂Q(sErrFile, iCnt, 11
										, "�ב��l�R�[�h["+sKey[18]+"]�����݂��܂���\r\n");
								}
								else
								{
									�G���[�o�͂Q(sErrFile, iCnt, 11
										, "�ב��l���擾�G���[�F"+sRet[0]+"\r\n");
									throw new Exception(sRet[0]);
								}
							}
							else
							{
								sKey[23] = sRet[1];	//���Ӑ�b�c
								sKey[24] = sRet[2];	//���ۂb�c
								if(sKey[24].Length == 0) sKey[24] = " ";
								sKey[25] = sRet[3]; //���Ӑ敔�ۖ�
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� START
								i�ב��l�Œ�d�� = int.Parse(sRet[4].Trim());
								i�ב��l�Œ�ː� = int.Parse(sRet[5].Trim());
								b�d�ʍː��Đݒ�FLG = true;
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
// MOD 2010.09.03 ���s�j���� �b�r�u�G���g���[���̐�����G���[�\�L�C�� START
//								if (sKey[25].Trim().Length == 0) �G���[�o�͂Q(sErrFile, iCnt, 11, "���Ӑ敔�ۖ������݂��܂���\r\n");
								if(sKey[25].Trim().Length == 0)
								{
									string s������b�c = sRet[1].Trim();
									if(sRet[2].Trim().Length > 0){
										s������b�c += "-" + sRet[2].Trim();
									}
									�G���[�o�͂Q(sErrFile, iCnt, 11
									, "�ב��l�̐�����["+s������b�c+"]�͓o�^����Ă��܂���\r\n");
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� START
									b�d�ʍː��Đݒ�FLG = false;
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
								}
// MOD 2010.09.03 ���s�j���� �b�r�u�G���g���[���̐�����G���[�\�L�C�� END
							}
						}
					}
					
					//�ב��l������
					sKey[19] = " ";
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
					if(i�b�r�u�G���g���[�`�� == 2){
						if(sValue�ꗗ�s[(int)�`���Q.�ב��S����].Length != 0){
//							if(!�S�p�`�F�b�N(sValue�ꗗ�s[(int)�`���Q.�ב��S����])){
//								�G���[�o�͂Q(sErrFile, iCnt, (int)�`���Q.�ב��S����
//									, "�ב��S���҂͑S�p�����œ��͂��Ă�������\r\n");
//							}
//							if(sValue�ꗗ�s[(int)�`���Q.�ב��S����].Length > 10){
//								�G���[�o�͂Q(sErrFile, iCnt, (int)�`���Q.�ב��S����
//									, "�ב��S���҂͂P�O�����ȓ��œ��͂��Ă�������\r\n");
//							}
//							sKey[19] = sValue�ꗗ�s[(int)�`���Q.�ב��S����];
							if(!�����ϊ�_CSV(ref sValue�ꗗ�s[(int)�`���Q.�ב��S����], ref sErr)){
								�G���[�o�͂Q(sErrFile, iCnt, (int)�`���Q.�ב��S����
								, "�ב��S���҂�Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���"
													 + "�w" + sErr + "�x\r\n");
							}else{
								// �����ϊ���o��(iCnt, (int)�`���Q.�ב��S����
								//					, sValue�ꗗ�s[(int)�`���Q.�ב��S����]);
							}
							if(!�S�p�ϊ��`�F�b�N(ref sValue�ꗗ�s[(int)�`���Q.�ב��S����], ref sErr)){
								�G���[�o�͂Q(sErrFile, iCnt, (int)�`���Q.�ב��S����
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
//					if (!�K�{�`�F�b�N(sValue[11]) || sValue[11].Equals("0")) �G���[�o�͂Q(sErrFile, iCnt, 12, "���͕K�{���ڂł�\r\n");
					if(!�K�{�`�F�b�N(sValue[11]) || sValue[11].Equals("0"))
					{
						�G���[�o�͂Q(sErrFile, iCnt, 12, "���͕K�{���ڂł�\r\n");
						b�d�ʍː��Đݒ�FLG = false;
					}
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
// MOD 2010.11.02 ���s�j���� ���l�͈̓`�F�b�N�̕ύX START
//					if (!���l�`�F�b�N(sValue[11])) �G���[�o�͂Q(sErrFile, iCnt, 12, "���͐��l�œ��͂��Ă�������\r\n");
//					if (���l�`�F�b�N(sValue[11]))
//					{	
//						if (long.Parse(sValue[11].Trim()) > 99) �G���[�o�͂Q(sErrFile, iCnt, 12, "���͂Q���ȓ��œ��͂��Ă�������\r\n");
//					}
					sChkMsg = ���l�͈̓`�F�b�N("��", sValue[11], 0, 99, "�Q���ȓ�");
					if(sChkMsg.Length > 0){
						�G���[�o�͂Q(sErrFile, iCnt, 12, sChkMsg +"\r\n");
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� START
						b�d�ʍː��Đݒ�FLG = false;
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
					}
// MOD 2010.11.02 ���s�j���� ���l�͈̓`�F�b�N�̕ύX END
					sKey[26] = sValue[11];
					
					//�ː�
					sValue[12] = sValue[12].Trim();
					if (sValue[12].Length == 0) sValue[12] = "0";
// MOD 2010.11.02 ���s�j���� ���l�͈̓`�F�b�N�̕ύX START
//					if (!���l�`�F�b�N(sValue[12])) �G���[�o�͂Q(sErrFile, iCnt, 13, "�ː��͐��l�œ��͂��Ă�������\r\n");
//					if (sValue[12].Trim().Length > 3) �G���[�o�͂Q(sErrFile, iCnt, 13, "�ː��͂R���ȓ��œ��͂��Ă�������\r\n");
					sChkMsg = ���l�͈̓`�F�b�N("�ː�", sValue[12], 0, 999, "�R���ȓ�");
					if(sChkMsg.Length > 0){
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� START
////						�G���[�o�͂Q(sErrFile, iCnt, 12, sChkMsg +"\r\n");
//						�G���[�o�͂Q(sErrFile, iCnt, 13, sChkMsg +"\r\n");
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
//						sValue[12] = "0";
						if(gs�d�ʓ��͐��� == "1")
						{
							�G���[�o�͂Q(sErrFile, iCnt, 13, sChkMsg +"\r\n");
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
					if (sValue[13].Length == 0) sValue[13] = "0";
// MOD 2010.11.02 ���s�j���� ���l�͈̓`�F�b�N�̕ύX START
//					if (!���l�`�F�b�N(sValue[13])) �G���[�o�͂Q(sErrFile, iCnt, 14, "�d�ʂ͐��l�œ��͂��Ă�������\r\n");
//					if (sValue[13].Trim().Length > 4) �G���[�o�͂Q(sErrFile, iCnt, 14, "�d�ʂ͂S���ȓ��œ��͂��Ă�������\r\n");
					sChkMsg = ���l�͈̓`�F�b�N("�d��", sValue[13], 0, 9999, "�S���ȓ�");
					if(sChkMsg.Length > 0){
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� START
////						�G���[�o�͂Q(sErrFile, iCnt, 12, sChkMsg +"\r\n");
//						�G���[�o�͂Q(sErrFile, iCnt, 14, sChkMsg +"\r\n");
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
//						sValue[13] = "0";
						if(gs�d�ʓ��͐��� == "1")
						{
							�G���[�o�͂Q(sErrFile, iCnt, 14, sChkMsg +"\r\n");
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
//						�G���[�o�͂Q(sErrFile, iCnt, 13, "�ː��Əd�ʂ͂ǂ��炩�������͂��Ă�������\r\n");
////						axGT�捞�f�[�^�ꗗ.set_CelMarking((short)(iCnt),(short)(14),true);
//					}
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� END
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� START
					if(gs�d�ʓ��͐��� == "1")
					{
						if (!sValue[12].Equals("0")  && !sValue[13].Equals("0")){
							�G���[�o�͂Q(sErrFile, iCnt, 13
								, "�ː��Əd�ʂ͂ǂ��炩�������͂��Ă�������\r\n");
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� START
							b�d�ʍː��Đݒ�FLG = false;
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
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
						}
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
					}
// MOD 2011.05.06 ���s�j���� ���q�l���Ƃɏd�ʓ��͐��� END

					//�A���w���P
					sValue[14] = sValue[14].TrimEnd();
					sKey[31] = "000";
					sKey[32] = " ";
					if (sValue[14].Length != 0)
					{
						if (���p�`�F�b�N(sValue[14]))
						{
							if (!���l�`�F�b�N(sValue[14])) �G���[�o�͂Q(sErrFile, iCnt, 15, "�A�����i�P�R�[�h�͐��l�̂ݓ��͉\�ł�\r\n");
							if (sValue[14].Length != 3) �G���[�o�͂Q(sErrFile, iCnt, 15, "�A�����i�P�R�[�h�͂R���œ��͂��Ă�������\r\n");
							if (���l�`�F�b�N(sValue[14]) && sValue[14].Length == 3)
							{
								string[] sList = {""};
								try
								{
//�ۗ��@�`�F�b�N���܂Ƃ߂�\��
//		sValue[14]�i�A���w���P�j�����p
//		sValue[14]�i�A���w���P�j������
//		sValue[14]�i�A���w���P�j���R��
//���ʂ�
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
									�G���[�o�͂Q(sErrFile, iCnt, 15
										, "�A�����i�P���擾�G���[�F"+gs�ʐM�G���[+"\r\n");
									throw new Exception(gs�ʐM�G���[);
								}
								catch (Exception ex)
								{
									�G���[�o�͂Q(sErrFile, iCnt, 15
										, "�A�����i�P���擾�G���[�F"+ex.Message+"\r\n");
									throw new Exception("�ʐM�G���[:" + ex.Message);
								}
								//���݂��Ȃ���
								if (sList[3] == "I")
								{
									�G���[�o�͂Q(sErrFile, iCnt,15,"���͂��ꂽ�A�����i�P�R�[�h�̓}�X�^�ɑ��݂��܂���B\r\n");
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
						{
							if (!�����ϊ�_CSV(ref sValue[14], ref sErr)) 
							{
								�G���[�o�͂Q(sErrFile, iCnt, 15, "�A�����i�P��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}
							else
							{
								// �����ϊ���o��(iCnt, 15, sValue[14]);
							}
							if (!�S�p�`�F�b�N(sValue[14])) �G���[�o�͂Q(sErrFile, iCnt, 15, "�A�����i�P�̖��̂͑S�p�����ŁA�R�[�h�͔��p�����œ��͂��Ă��������i�ǂ��炩����݂̂ł��j\r\n");
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
//�ۗ��@�`�F�b�N���܂Ƃ߂�\��
//		sValue[14]�i�A���w���P�j���S�p
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
									�G���[�o�͂Q(sErrFile, iCnt, 15
										, "�A�����i�P�b�c�擾�G���[�F"+gs�ʐM�G���[+"\r\n");
									throw new Exception(gs�ʐM�G���[);
								}
								catch (Exception ex)
								{
									�G���[�o�͂Q(sErrFile, iCnt, 15
										, "�A�����i�P�b�c�擾�G���[�F"+ex.Message+"\r\n");
									throw new Exception("�ʐM�G���[�F" + ex.Message);
								}
								if(sRet[0].Length != 4)
								{
									if(sRet[0].Equals("�Y���f�[�^������܂���"))
									{
										sKey[31] = "000";
										�G���[�o�͂Q(sErrFile, iCnt, 15, "�A�����i�P�����݂��܂���\r\n");
									}
									else
									{
										�G���[�o�͂Q(sErrFile, iCnt, 15
											, "�A�����i�P�b�c�擾�G���[�F"+sRet[0]+"\r\n");
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
//�ۗ��@�`�F�b�N���܂Ƃ߂�\��
//		sKey[31]�i�A���w���P�j��[000]�ȊO
//		sValue[15]�i�A���w���Q�j��������
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
							if (sKey[33].Equals("000")) �G���[�o�͂Q(sErrFile, iCnt, 16, "�A�����i�P�����͂���Ă���ꍇ�A�A�����i�Q�͕K�{���ڂł�\r\n");
						}
						else if (!sList[0].Equals("�Y���f�[�^������܂���"))
						{
							�G���[�o�͂Q(sErrFile, iCnt, 16
								, "�A�����i�Q���擾�G���[�F"+sRet[0]+"\r\n");
							throw new Exception(sList[0]);
						}
					}
					if (sValue[15].Length != 0)
					{
						if (sValue[14].Length == 0) �G���[�o�͂Q(sErrFile, iCnt, 15, "�A�����i�P����͂��Ă�������\r\n");
						if (���p�`�F�b�N(sValue[15]))
						{
							if (!���l�`�F�b�N(sValue[15])) �G���[�o�͂Q(sErrFile, iCnt, 16, "�A�����i�Q�R�[�h�͐��l�̂ݓ��͉\�ł�\r\n");
							if (sValue[15].Length != 3) �G���[�o�͂Q(sErrFile, iCnt, 16, "�A�����i�Q�R�[�h�͂R���œ��͂��Ă�������\r\n");
							if (���l�`�F�b�N(sValue[15]) && sValue[15].Length == 3)
							{
								string[] sList = {""};
								try
								{
//�ۗ��@�`�F�b�N���܂Ƃ߂�\��
//		sValue[14]�i�A���w���P�j�ɓ��͂���
//		sValue[15]�i�A���w���Q�j�����p
//		sValue[15]�i�A���w���Q�j�����l
//		sValue[15]�i�A���w���Q�j���R��
// MOD 2011.06.07 ���s�j���� ���q�^���̑Ή� START
									if(sv_kiji == null) sv_kiji = new is2kiji.Service1();
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
									�G���[�o�͂Q(sErrFile, iCnt, 16
										, "�A�����i�Q���擾�G���[�F"+gs�ʐM�G���[+"\r\n");
									throw new Exception(gs�ʐM�G���[);
								}
								catch (Exception ex)
								{
									�G���[�o�͂Q(sErrFile, iCnt, 16
										, "�A�����i�Q���擾�G���[�F"+ex.Message+"\r\n");
									throw new Exception("�ʐM�G���[�F" + ex.Message);
								}
								//���݂��Ȃ���
								if(sList[3] == "I")
								{
									�G���[�o�͂Q(sErrFile, iCnt,16,"���͂��ꂽ�A�����i�Q�R�[�h�̓}�X�^�ɑ��݂��܂���B\r\n");
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
						{
							if (!�����ϊ�_CSV(ref sValue[15], ref sErr)) 
							{
								�G���[�o�͂Q(sErrFile, iCnt, 16, "�A�����i�Q��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}
							else
							{
								// �����ϊ���o��(iCnt, 16, sValue[15]);
							}
							if (!�S�p�`�F�b�N(sValue[15])) �G���[�o�͂Q(sErrFile, iCnt, 16, "�A�����i�Q�̖��̂͑S�p�����ŁA�R�[�h�͔��p�����œ��͂��Ă��������i�ǂ��炩����݂̂ł��j\r\n");
							if(sValue[14].Length != 0 && �S�p�`�F�b�N(sValue[15]) && sKey[31].Equals("100")){
								if(sValue[15].Equals("�`�l�w��")){
									sValue[15] = "�`�l�w��i�P�O���`�P�Q���j";
								}
							}
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
//�ۗ��@�`�F�b�N���܂Ƃ߂�\��
//		sValue[14]�i�A���w���P�j�����͗L��
//		sValue[15]�i�A���w���Q�j���S�p
//		sKey[31]�i�A���w���P�R�[�h�j��[000]�ȊO
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
									�G���[�o�͂Q(sErrFile, iCnt, 16
										, "�A�����i�Q�b�c�擾�G���[�F"+gs�ʐM�G���[+"\r\n");
									throw new Exception(gs�ʐM�G���[);
								}
								catch (Exception ex)
								{
									�G���[�o�͂Q(sErrFile, iCnt, 16
										, "�A�����i�Q�b�c�擾�G���[�F"+ex.Message+"\r\n");
									throw new Exception("�ʐM�G���[�F" + ex.Message);
								}
								if(sRet[0].Length != 4)
								{
									if(sRet[0].Equals("�Y���f�[�^������܂���"))
									{
										sKey[33] = "000";
										�G���[�o�͂Q(sErrFile, iCnt, 16, "�A�����i�Q�����݂��܂���\r\n");
									}
									else
									{
										�G���[�o�͂Q(sErrFile, iCnt, 16
											, "�A�����i�Q�b�c�擾�G���[�F"+sRet[0]+"\r\n");
										throw new Exception(sRet[0]);
									}
								}
								else
								{
									if(sKey[31].Equals("100")){
										if(sRet[1].Equals("11X")){
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX START
//											���Ԏw��`�F�b�N(iCnt, sValue[15], 12, 21);
											���Ԏw��`�F�b�N�Q(sErrFile, iCnt, sValue[15], 12, 20);
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX END
										}else if(sRet[1].Equals("12X")){
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX START
//											���Ԏw��`�F�b�N(iCnt, sValue[15], 10, 19);
											���Ԏw��`�F�b�N�Q(sErrFile, iCnt, sValue[15], 10, 18);
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX END
										}
									}else if(sKey[31].Equals("200")){
										if(sRet[1].Equals("21X")){
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX START
//											���Ԏw��`�F�b�N(iCnt, sValue[15], 12, 21);
											���Ԏw��`�F�b�N�Q(sErrFile, iCnt, sValue[15], 12, 20);
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX END
										}else if(sRet[1].Equals("22X")){
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX START
//											���Ԏw��`�F�b�N(iCnt, sValue[15], 10, 19);
											���Ԏw��`�F�b�N�Q(sErrFile, iCnt, sValue[15], 10, 18);
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX END
										}
									}
									sKey[33] = sRet[1];
								}
							}
						}
					}
					// �p�[�Z�������̏ꍇ
					if (sKey[31].Equals("001"))
					{
						if (!sKey[26].Equals("1")) �G���[�o�͂Q(sErrFile, iCnt, 12, "�A�����i�P��" + sKey[32] + "�̏ꍇ�A����'1'����͂��Ă�������\r\n");
						if (!sKey[28].Equals("1")) �G���[�o�͂Q(sErrFile, iCnt, 14, "�A�����i�P��" + sKey[32] + "�̏ꍇ�A�d�ʂ�'1'����͂��Ă�������\r\n");
					}
					// �p�[�Z���p�b�N�̏ꍇ
					if (sKey[31].Equals("002"))
					{
						if (!sKey[26].Equals("1")) �G���[�o�͂Q(sErrFile, iCnt, 12, "�A�����i�P��" + sKey[32] + "�̏ꍇ�A����'1'����͂��Ă�������\r\n");
						if (���l�`�F�b�N(sKey[28]) && int.Parse(sKey[28]) > 30) �G���[�o�͂Q(sErrFile, iCnt, 14, "�A�����i�P��" + sKey[32] + "�̏ꍇ�A�d�ʂ͂R�O�ȉ�����͂��Ă�������\r\n");
						if (���l�`�F�b�N(sKey[27]) && ���l�`�F�b�N(sKey[28]) && int.Parse(sKey[27]) > 0 && int.Parse(sKey[28]) == 0) �G���[�o�͂Q(sErrFile, iCnt, 14, "�A�����i�P��" + sKey[32] + "�̏ꍇ�A�d�ʂ���͂��Ă�������\r\n");
					}

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
						if(!�L���`�F�b�N�Q(sValue[16])) �G���[�o�͂Q(sErrFile, iCnt, 17, "�i���L���P�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
						if (!�����ϊ�_CSV(ref sValue[16], ref sErr)) 
						{
							�G���[�o�͂Q(sErrFile, iCnt, 17, "�i���L���P��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
						}
						else
						{
							// �����ϊ���o��(iCnt, 17, sValue[16]);
						}
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� START
//						sKey[35] = sKey[35].Replace('\\','��');
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� END
						sKey[35] = �o�C�g���J�b�g(sValue[16], 30);
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
						if(!�L���`�F�b�N�Q(sValue[17])) �G���[�o�͂Q(sErrFile, iCnt, 18, "�i���L���Q�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
						if (!�����ϊ�_CSV(ref sValue[17], ref sErr)) 
						{
							�G���[�o�͂Q(sErrFile, iCnt, 18, "�i���L���Q��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
						}
						else
						{
							// �����ϊ���o��(iCnt, 18, sValue[17]);
						}
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� START
//						sKey[36] = sKey[36].Replace('\\','��');
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� END
						sKey[36] = �o�C�g���J�b�g(sValue[17], 30);
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
						if(!�L���`�F�b�N�Q(sValue[18])) �G���[�o�͂Q(sErrFile, iCnt, 19, "�i���L���R�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
						if (!�����ϊ�_CSV(ref sValue[18], ref sErr)) 
						{
							�G���[�o�͂Q(sErrFile, iCnt, 19, "�i���L���R��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
						}
						else
						{
							// �����ϊ���o��(iCnt, 19, sValue[18]);
						}
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� START
//						sKey[37] = sKey[37].Replace('\\','��');
//�ۗ� MOD 2009.12.15 ���s�j���� [\]��[��]�ϊ��̒ǉ� END
						sKey[37] = �o�C�g���J�b�g(sValue[18], 30);
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
								�G���[�o�͂Q(sErrFile, iCnt, (int)�`���Q.�i���L���S
								, "�i���L���S�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
							}
							if(!�����ϊ�_CSV(ref sValue�ꗗ�s[(int)�`���Q.�i���L���S], ref sErr)){
								�G���[�o�͂Q(sErrFile, iCnt, (int)�`���Q.�i���L���S
								, "�i���L���S��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}else{
								// �����ϊ���o��(iCnt, (int)�`���Q.�i���L���S
								// , sValue�ꗗ�s[(int)�`���Q.�i���L���S]);
							}
							sKey[47] = �o�C�g���J�b�g(sValue�ꗗ�s[(int)�`���Q.�i���L���S], 30);
						}
						sKey[48] = " ";
						if(sValue�ꗗ�s[(int)�`���Q.�i���L���T].Length != 0){
							if(!�L���`�F�b�N�Q(sValue�ꗗ�s[(int)�`���Q.�i���L���T])){
								�G���[�o�͂Q(sErrFile, iCnt, (int)�`���Q.�i���L���T
								, "�i���L���T�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
							}
							if(!�����ϊ�_CSV(ref sValue�ꗗ�s[(int)�`���Q.�i���L���T], ref sErr)){
								�G���[�o�͂Q(sErrFile, iCnt, (int)�`���Q.�i���L���T
								, "�i���L���T��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}else{
								// �����ϊ���o��(iCnt, (int)�`���Q.�i���L���T
								// , sValue�ꗗ�s[(int)�`���Q.�i���L���T]);
							}
							sKey[48] = �o�C�g���J�b�g(sValue�ꗗ�s[(int)�`���Q.�i���L���T], 30);
						}
						sKey[49] = " ";
						if(sValue�ꗗ�s[(int)�`���Q.�i���L���U].Length != 0){
							if(!�L���`�F�b�N�Q(sValue�ꗗ�s[(int)�`���Q.�i���L���U])){
								�G���[�o�͂Q(sErrFile, iCnt, (int)�`���Q.�i���L���U
								, "�i���L���U�Ɏg�p�ł��Ȃ��L��������܂�\r\n");
							}
							if(!�����ϊ�_CSV(ref sValue�ꗗ�s[(int)�`���Q.�i���L���U], ref sErr)){
								�G���[�o�͂Q(sErrFile, iCnt, (int)�`���Q.�i���L���U
								, "�i���L���U��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���" + "�w" + sErr + "�x\r\n");
							}else{
								// �����ϊ���o��(iCnt, (int)�`���Q.�i���L���U
								// , sValue�ꗗ�s[(int)�`���Q.�i���L���U]);
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
					
					//���q�l�Ǘ��ԍ�
					sValue[20] = sValue[20].Trim();
					if (sValue[20] == "0")	sValue[20]=""; // �H
					if (sValue[20].Length != 0)
					{
						if (!���p�`�F�b�N(sValue[20])) �G���[�o�͂Q(sErrFile, iCnt, 21, "���q�l�Ǘ��ԍ��͔��p�����œ��͂��Ă�������\r\n");
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
//						if(!�L���`�F�b�N(sValue[20])) �G���[�o�͂Q(sErrFile, iCnt, 21, "���q�l�Ǘ��ԍ��Ɏg�p�ł��Ȃ��L��������܂�\r\n");
//�ۗ� MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END
// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� START
//						if (sValue[20].Length > 15) �G���[�o�͂Q(sErrFile, iCnt, 21, "���q�l�Ǘ��ԍ��͂P�T���ȓ��œ��͂��Ă�������\r\n");
						if (sValue[20].Length > 16){
							�G���[�o�͂Q(sErrFile, iCnt, 21, "���q�l�Ǘ��ԍ��͂P�U���ȓ��œ��͂��Ă�������\r\n");
						}
// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� END
						sKey[3] = sValue[20];
					}

					//�����敪
					sValue[22] = sValue[22].Trim();
					if (!sValue[22].Equals("1"))
					{
						�G���[�o�͂Q(sErrFile, iCnt, 23, "�����敪��'1'����͂��Ă�������\r\n");
					}
					sKey[38] = sValue[22];
					
					//�ی����z
					sValue[23] = sValue[23].Trim();
					if (sValue[23].Length == 0) sValue[23] = "0";
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX START
//					if (!���l�`�F�b�N(sValue[23])) �G���[�o�͂Q(sErrFile, iCnt, 24, "�ی����z�͐��l�œ��͂��Ă�������\r\n");
//					if (���l�`�F�b�N(sValue[23]))
//					{	
//						if (long.Parse(sValue[23].Trim()) > 9999) �G���[�o�͂Q(sErrFile, iCnt, 24, "�ی����z�͂S���ȓ��œ��͂��Ă�������\r\n");
//					}
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) START
//					sChkMsg = ���l�͈̓`�F�b�N("�ی����z", sValue[23], 0, 30, "");
					sChkMsg = ���l�͈̓`�F�b�N("�ی����z", sValue[23], 0, gl�ی����z���, "�S���ȓ�");
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) END
					if(sChkMsg.Length > 0){
						�G���[�o�͂Q(sErrFile, iCnt, 24, sChkMsg +"\r\n");
					}
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX END
					sKey[39] = sValue[23];
					
					//�o�ד�
					sValue[24] = sValue[24].Trim();
					DateTime dt�o�ד� = DateTime.Today;
					bool     b�o�ד��ݒ� = false;
					if (!�K�{�`�F�b�N(sValue[24])) �G���[�o�͂Q(sErrFile, iCnt, 25, "�o�ד��͕K�{���ڂł�\r\n");
					if (sValue[24].Length != 0)
					{
						if (!���p�`�F�b�N(sValue[24])) �G���[�o�͂Q(sErrFile, iCnt, 25, "�o�ד��͔��p�����œ��͂��Ă�������\r\n");
						if (sValue[24].Length != 8)
						{
							�G���[�o�͂Q(sErrFile, iCnt, 25, "�o�ד��͂W�����œ��͂��Ă�������\r\n");
						}
						else
						{
							try
							{
								dt�o�ד� = new DateTime(int.Parse(sValue[24].Substring(0,4)),
														int.Parse(sValue[24].Substring(4,2)),
														int.Parse(sValue[24].Substring(6)));
								b�o�ד��ݒ� = true;
								if(dt�o�ד� < gdt�o�ד�)
								{
									�G���[�o�͂Q(sErrFile, iCnt, 25, "�o�ד���" + gdt�o�ד�.ToString(" M�� d��") + "�ȍ~����͂��Ă�������\r\n");
								}
								//�����i�o�^���j����Q�T�Ԃ܂�
								else if(dt�o�ד� > gdt�o�ד��ő�l�b�r�u)
								{
									�G���[�o�͂Q(sErrFile, iCnt, 25, "�o�ד���" + gdt�o�ד��ő�l�b�r�u.ToString(" M�� d��")
									 + "�ȑO����͂��Ă�������\r\n");
								}
								// ADD-S 2012.09.26 COA)���R ���t���ڎ捞����
								else 
								{
									sValue[24] = YYYYMMDD�ϊ�(dt�o�ד�);
								}
								// ADD-E 2012.09.26 COA)���R ���t���ڎ捞����
							}
							catch
							{
								�G���[�o�͂Q(sErrFile, iCnt, 25, "�o�ד���yyyyMMdd�̌`���œ��͂��Ă�������\r\n");
							}
						}
					}
					sKey[2] = sValue[24];
					
					//�o�^���̏����ݒ�
					sKey[40] = YYYYMMDD�ϊ�(DateTime.Now);
					if(sValue.Length > 25){
						//�o�^��
						sValue[25] = sValue[25].Trim();
						string   s����    = YYYYMMDD�ϊ�(DateTime.Now);
						sValue[25] = sValue[25].Trim();
						if (sValue[25] == "0")	sValue[25]="";
						if (sValue[25].Length != 0)
						{	
							try
							{
								DateTime dt�o�^�� = new DateTime(int.Parse(sValue[25].Substring(0,4)),int.Parse(sValue[25].Substring(4,2)), int.Parse(sValue[25].Substring(6)));
								if (!sValue[25].Equals(s����)) �G���[�o�͂Q(sErrFile, iCnt, 26, "�o�^���͓�������͂��Ă�������\r\n");
							}
							catch
							{
								�G���[�o�͂Q(sErrFile, iCnt, 26, "�o�^����yyyyMMdd�̌`���œ��͂��Ă�������\r\n");
							}
						}
						else 
							sValue[25] = s����;
						sKey[40] = sValue[25];
					}

					//�w���
					sKey[29] = "0";
					//�w����敪
					sKey[30] = "0";
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
					if(i�b�r�u�G���g���[�`�� == 2){
						if(sValue�ꗗ�s[(int)�`���Q.�K���敪].Length != 0){
							if(���p�`�F�b�N(sValue�ꗗ�s[(int)�`���Q.�K���敪])){
								if(sValue�ꗗ�s[(int)�`���Q.�K���敪] == "0"){
									sKey[30] = "0"; // 0:�K�� 1:�w��
								}else if(sValue�ꗗ�s[(int)�`���Q.�K���敪] == "1"){
									sKey[30] = "1"; // 0:�K�� 1:�w��
								}else{
									�G���[�o�͂Q(sErrFile, iCnt, (int)�`���Q.�K���敪
									, "�K���敪��[0]��������[1]�œ��͂��Ă�������\r\n");
								}
							}else{
								if(sValue�ꗗ�s[(int)�`���Q.�K���敪] == "�K��"){
									sKey[30] = "0"; // 0:�K�� 1:�w��
								}else if(sValue�ꗗ�s[(int)�`���Q.�K���敪] == "�w��"){
									sKey[30] = "1"; // 0:�K�� 1:�w��
								}else{
									�G���[�o�͂Q(sErrFile, iCnt, (int)�`���Q.�K���敪
									, "�K���敪��[�K��]��������[�w��]�œ��͂��Ă�������\r\n");
								}
							}
						}
					}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END

					sValue[19] = sValue[19].Trim();
					if (sValue[19] == "0")	sValue[19]="";
					if (sValue[19].Length != 0)
					{
// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� START
						if(sValue[19].Length != 8){
							�G���[�o�͂Q(sErrFile, iCnt, 20, "�z�B�w����͂W�����œ��͂��Ă�������\r\n");
						}else{
// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� END
						try
						{
							DateTime dt�z�B�w��� = new DateTime(
															int.Parse(sValue[19].Substring(0,4))
															, int.Parse(sValue[19].Substring(4,2))
															, int.Parse(sValue[19].Substring(6)));
							// ADD-S 2012.09.26 COA)���R ���t���ڎ捞����
							bool	wk_bNoErr_�z�B�w���	= true;
							// ADD-E 2012.09.26 COA)���R ���t���ڎ捞����

							if(b�o�ד��ݒ�)
							{
								//�o�ד�����i�P�S�� or �X�O���j�܂�
								DateTime dt�w����ő�l;
								if(gs����X���b�c.Equals("047")){
									dt�w����ő�l = dt�o�ד�.AddDays(90);
								}else{
									dt�w����ő�l = dt�o�ד�.AddDays(14);
								}
// MOD 2016.04.13 BEVAS�j���{ �z�B�w�������̊g�� START
								//�Z���A�l�̏ꍇ�A�z�B�w����̏����180���ɂ܂Ŋg��
								if(gs����b�c.Equals(gs�w�������g������b�c))
								{
									dt�w����ő�l = dt�o�ד�.AddDays(180);
								}
// MOD 2016.04.13 BEVAS�j���{ �z�B�w�������̊g�� END
								if(dt�z�B�w��� < dt�o�ד�)
								{
									�G���[�o�͂Q(sErrFile, iCnt, 20, "�z�B�w����͏o�ד��ȍ~����͂��Ă�������\r\n");
									// ADD-S 2012.09.26 COA)���R ���t���ڎ捞����
									wk_bNoErr_�z�B�w���	= false;
									// ADD-E 2012.09.26 COA)���R ���t���ڎ捞����
								}
								if(dt�z�B�w��� > dt�w����ő�l)
								{
									�G���[�o�͂Q(sErrFile, iCnt, 20, "�z�B�w�����" + dt�w����ő�l.ToString(" M�� d��")
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
							}
						}
						catch
						{
							�G���[�o�͂Q(sErrFile, iCnt, 20, "�z�B�w�����yyyyMMdd�̌`���œ��͂��Ă�������\r\n");
						}
// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� START
						}
// MOD 2010.10.01 ���s�j���� ���q�l�ԍ��P�U���� END
						sKey[29] = sValue[19];
						sKey[30] = "1";
					}
					sKey[41] = "0";			// ����󔭍s�ςe�f
					sKey[42] = "0";			// �o�׍ςe�f
					sKey[43] = "0";			// �ꊇ�o�ׂe�f
					sKey[44] = "�����o��";	
					sKey[45] = gs���p�҂b�c;
					
					StringBuilder sbKeyData = new StringBuilder();
					for (int j = 0; j < sKey.Length; j++){
						sbKeyData.Append(sKey[j] + ",");
					}
					s�捞�f�[�^�Q[i�捞�s���Q++] = sbKeyData.ToString();

//					if(i�捞�s���Q % 10 == 0){
//						System.Threading.Thread.Sleep(100); // 0.1�b�҂�
//					}
				}
//				tex���b�Z�[�W.Text = "";
			}catch (Exception ex){
//				tex���b�Z�[�W.Text = ex.Message;
				���O�o�͂Q(" "+ex.Message);
//				b�G���[�o�͂Q = false;
			}finally{
				sr.Close();
				Cursor = System.Windows.Forms.Cursors.Default;
			}
			���O�o�͂Q(" �`�F�b�N�I��");

			���O�o�͂Q(" �Ǎ��s���@�F"+iCnt.ToString("0000"));
//			���O�o�͂Q(" �捞�s���@�F"+i�捞�s���Q.ToString("0000"));
			���O�o�͂Q(" �G���[�s���F"+i�G���[�s���Q.ToString("0000"));

			if(!gb�����o�͂n�m) return; //�����o�͂������ł���ΏI��

			// �t�@�C�����ړ�����
			try{
// MOD 2010.04.19 ���s�j���� �o�̓t�@�C�����̕ύX START
//				File.Move(sCsvFile
//						, gsPathSyukkaOut + "\\" + Path.GetFileName(sCsvFile));
				File.Move(sCsvFile
						, gsPathSyukkaOut + "\\" + Path.GetFileName(sCsvFile)
						+ "_" + s���s����);
// MOD 2010.04.19 ���s�j���� �o�̓t�@�C�����̕ύX END
			}catch(Exception ex){
//�ۗ��@�G���[����
				���O�o�͂Q(" "+ex.Message);
				return;
			}

			// �G���[���������Ă����ꍇ�́A�I��
			if(b�G���[�o�͂Q){
//				MessageBox.Show("�o�ׂb�r�u�����o�͂ŃG���[���������܂����B\n"
//								+ "�G���[�t�@�C��["+sErrFile+"]���m�F���ĉ������B"
//								,"�o�ׂb�r�u�����o��"
//								,MessageBoxButtons.OK);
// MOD 2010.05.25 ���s�j���� ���b�Z�[�W�̃X���b�h�� START
//				DialogResult dlgRst = MessageBox.Show(
//								"�o�ׂb�r�u�����o�͂ŃG���[���������܂����B\n"
//								+ "�b�r�u�G���g���[��ʂ�[�����o�̓t�H���_�\��]�{�^���������āA\n"
//								+ "�G���[�t�@�C��[Out\\"+Path.GetFileName(sErrFile)+"]�̓��e���m�F���ĉ������B\n"
//								, "�o�ׂb�r�u�����o��"
//								, MessageBoxButtons.OK
//								, MessageBoxIcon.Error);
				sTaskMsgErrFile = sErrFile;
				trdMsg = new Thread(new ThreadStart(ThreadTaskMsg));
				trdMsg.IsBackground = true;
				trdMsg.Start();
// MOD 2010.05.25 ���s�j���� ���b�Z�[�W�̃X���b�h�� END
				return;
			}

			// �捞�\�茏�����O�̏ꍇ
			if(i�捞�s���Q == 0) return;

			// �z��f�[�^�̍č쐬���s��
			string[] s�捞�f�[�^�Q�v = new string[i�捞�s���Q];
			System.Array.Copy(s�捞�f�[�^�Q, s�捞�f�[�^�Q�v, i�捞�s���Q);
			s�捞�f�[�^�Q = null;

//			tex���b�Z�[�W.Text = "�o�ׂb�r�u�����o�� �捞���D�D�D";
//			tex���b�Z�[�W.Refresh();
			���O�o�͂Q(" �捞�J�n");
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try{
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
				sRet = sv_syukka.Ins_autoEntryData(gsa���[�U,s�捞�f�[�^�Q�v);
//				tex���b�Z�[�W.Text = sRet[0];
//				tex���b�Z�[�W.Refresh();
				if(sRet[0].Length != 0){
					���O�o�͂Q(" "+sRet[0]);
					return;
				}
			}catch (System.Net.WebException){
//				tex���b�Z�[�W.Text = gs�ʐM�G���[;
//				tex���b�Z�[�W.Refresh();
				���O�o�͂Q(" "+gs�ʐM�G���[);
				return;
			}catch (Exception ex){
//				tex���b�Z�[�W.Text = ex.Message;
//				tex���b�Z�[�W.Refresh();
				���O�o�͂Q(" "+ex.Message);
				return;
			}finally{
				Cursor = System.Windows.Forms.Cursors.Default;
			}
			���O�o�͂Q(" �捞�I��");

//			tex���b�Z�[�W.Text = "�o�ׂb�r�u�����o�� ������D�D�D";
//			tex���b�Z�[�W.Refresh();
			���O�o�͂Q(" ����J�n");
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try{
				�v�����^�`�F�b�N();
			}catch(Exception ex){
				Cursor = System.Windows.Forms.Cursors.Default;
//				tex���b�Z�[�W.Text = ex.Message;
				���O�o�͂Q(" "+ex.Message);
				return;
			}

// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j START
//			ds�����.Clear();
			�����f�[�^�N���A();
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j END
			int iRetCnt = 1;
			while(iRetCnt < sRet.Length){
				if(sRet[iRetCnt] == null) break;
				// �o�^���A�W���[�i���m�n
				string[] sPrtData = {sRet[iRetCnt++], sRet[iRetCnt++]};
				��������w��(sPrtData);
//�ۗ��@�����炭�s�v
//				if(!gb���){
//					tex���b�Z�[�W.Text = "";
//					Cursor = System.Windows.Forms.Cursors.Default;
//					MessageBox.Show("�W�דX���Ⴂ�܂��B����ł��܂���B","������"
//						,MessageBoxButtons.OK);
//					return;
//				}

//�ۗ� �P�����������
//				����󒠕[���();
//				ds�����.Clear();

//				if(iRetCnt % 60 == 1){
//					System.Threading.Thread.Sleep(300); // 0.3�b�҂�
//				}
			}
//�ۗ� �܂Ƃ߂Ĉ������
			����󒠕[���();
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j START
//			ds�����.Clear();
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j END

			Cursor = System.Windows.Forms.Cursors.Default;
			���O�o�͂Q(" ����I��");
		}
// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� END
// MOD 2010.04.21 ���s�j���� �n���O�ߎ�����̖h�~ START
		private void �t�@�C���ꗗ�擾�P()
		{
			try{
				if(!Directory.Exists(gsPathSyukka))    return;
				if(!Directory.Exists(gsPathSyukkaIn))  return;
				if(!Directory.Exists(gsPathSyukkaOut)) return;
				if(!Directory.Exists(gsPathSyukkaLog)) return;

				// �t�@�C���ꗗ�擾�P
//				���O�o�͂Q(" �t�@�C���ꗗ�擾�P");
				sFiles1 = Directory.GetFiles(gsPathSyukkaIn);
				if(sFiles1.Length == 0) return;
				dtFiles1 = new DateTime[sFiles1.Length];
				lsFiles1 = new long[sFiles1.Length];
				for(int iCnt = 0; iCnt < sFiles1.Length; iCnt++){
					dtFiles1[iCnt] = File.GetLastWriteTime(sFiles1[iCnt]);
					lsFiles1[iCnt] = 0;
					try{
						FileStream fs = new FileStream(sFiles1[iCnt], FileMode.Open);
						lsFiles1[iCnt] = fs.Length;
						fs.Close();
					}catch(IOException ex){
//�ۗ��@�G���[����
						���O�o�͂Q(" �t�@�C���T�C�Y�擾�P "+ex.Message);
					}
				}
			}catch(Exception ex){
//�ۗ��@�G���[����
				���O�o�͂Q(" �t�@�C���ꗗ�擾�P "+ex.Message);
			}finally{
//				b���s��_tim�o�ׂb�r�u�����o��_Tick = false;
			}
		}
// MOD 2010.04.21 ���s�j���� �n���O�ߎ�����̖h�~ END
// MOD 2010.05.25 ���s�j���� ���b�Z�[�W�̃X���b�h�� START
		private string sTaskMsgErrFile = "";
		private void ThreadTaskMsg()
		{
			DialogResult dlgRst = MessageBox.Show(
							"�o�ׂb�r�u�����o�͂ŃG���[���������܂����B\n"
							+ "�b�r�u�G���g���[��ʂ�[�����o�̓t�H���_�\��]�{�^���������āA\n"
							+ "�G���[�t�@�C��[Out\\"+Path.GetFileName(sTaskMsgErrFile)+"]�̓��e���m�F���ĉ������B\n"
							, "�o�ׂb�r�u�����o��"
							, MessageBoxButtons.OK
							, MessageBoxIcon.Error);
		}
// MOD 2010.05.25 ���s�j���� ���b�Z�[�W�̃X���b�h�� END
// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX START
		private void ���Ԏw��`�F�b�N�Q(string sErrFile, int iCnt, string sData, int iHourMin, int iHourMax)
		{
			if(sData.Length != 9){
//				�G���[�o�͂Q(sErrFile, iCnt, 16, "�A�����i�Q�̎��Ԏw��̕����̒����Ɍ�肪����܂�\r\n");
				�G���[�o�͂Q(sErrFile, iCnt, 16, "�A�����i�Q�̎��Ԏw��Ɍ�肪����܂�["+sData+"]\r\n");
				return;
			}
			if(!sData.Substring(6,1).Equals("��")){
//				�G���[�o�͂Q(sErrFile, iCnt, 16, "�A�����i�Q�̎��Ԏw��̎����Ɍ�肪����܂�[��]\r\n");
				�G���[�o�͂Q(sErrFile, iCnt, 16, "�A�����i�Q�̎��Ԏw��Ɍ�肪����܂�["+sData+"]\r\n");
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
				�G���[�o�͂Q(sErrFile, iCnt, 16, "�A�����i�Q�̎��Ԏw��̎����Ɍ�肪����܂�["+s����+"]\r\n");
				return;
			}
		}

// MOD 2010.05.25 ���s�j���� ���Ԏw��̕ύX END
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� START
		private bool b���j���[_Activated = false;
		private void ���j���[_Activated(object sender, System.EventArgs e)
		{
			if(b���j���[_Activated == false){
				���m�点�ē����b�Z�[�W�擾();
			}
			b���j���[_Activated = true;
			if(gs���m�点�ē����b�Z�[�W.Length > 0){
				tex���b�Z�[�W.Text = gs���m�点�ē����b�Z�[�W;
			}
		}
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� END
// MOD 2011.04.05 ���s�j���� ��ʃC���[�W�̃��[�h�ύX START
		private static Image Image_FromFile(string s�C���[�W�t�@�C��)
		{
			Image retImage = null;
			try{
//				retImage = Image.FromFile(gs�A�v���t�H���_+"\\"+s�C���[�W�t�@�C��);
				FileStream fs = new FileStream(gs�A�v���t�H���_+"\\"+s�C���[�W�t�@�C��
										, FileMode.Open, FileAccess.Read); 
				Bitmap bmp = (Bitmap)System.Drawing.Bitmap.FromStream(fs); 
				fs.Close(); 
				retImage = new Bitmap(bmp); 
			}catch{
			}
			return retImage;
		}
// MOD 2011.04.05 ���s�j���� ��ʃC���[�W�̃��[�h�ύX END
// MOD 2011.10.11 ���s�j���� �r�r�k�ؖ���������ԂȂǂ̃`�F�b�N START
		private static void �r�r�k�ؖ���������ԃ`�F�b�N()
		{
			if(gsSSLStatus.Length > 0) return;

			is2init.Service1 sv_test = new is2init.Service1();;
			sv_test.Url   = sv_init.Url;
			sv_test.Proxy = sv_init.Proxy;
			
			int iTimeout = 100000; // �f�t�H���g�́A100�b
			try{
				iTimeout = sv_test.Timeout;
				sv_test.Timeout = 10000; // 10�b
				sv_test.Url = sv_test.Url.Replace("wwwis2","www.is2edi");
				gsSSLStatus = sv_test.wakeupDB();
				if(gsSSLStatus.Length == 0){
					gsSSLStatus = "o";
				}
			}catch(Exception ex){
				gsSSLStatus = "e:"+ex.Message;
			}finally{
				// ���̐ݒ�ɖ߂�
				sv_test.Timeout = iTimeout; // ���ɖ߂�
				sv_test.Url = sv_test.Url.Replace("www.is2edi","wwwis2");
			}
		}
// MOD 2011.10.11 ���s�j���� �r�r�k�ؖ���������ԂȂǂ̃`�F�b�N END
// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� START
		private byte[] bKey = {51, 168, 96, 2, 36, 12, 74, 143, 11, 85, 61, 233, 202, 170, 114, 59};
		private byte[] bIv  = {100, 223, 207, 80, 29, 100, 53, 152};
		private string �������Q(string sText)
		{
			byte[] bText;
			byte[] bRet;
			string sRet = "";

			try{
				//bText = Encoding.GetEncoding("shift-jis").GetBytes(sText);
				string sByte = "";
				bText = new byte[sText.Length / 2];
				for(int iCnt = 0; iCnt < sText.Length; iCnt+=2){
					sByte = sText.Substring(iCnt, 2);
					bText[iCnt/2] = Convert.ToByte(sByte,16);
				}

				MemoryStream inputStream = new MemoryStream(bText);
				RC2CryptoServiceProvider rc2 = new RC2CryptoServiceProvider();

				// CryptoStream�I�u�W�F�N�g���쐬����
				ICryptoTransform transform = rc2.CreateDecryptor(bKey,bIv); // Decryptor���쐬����
				CryptoStream csDecrypt = new CryptoStream( inputStream, transform, CryptoStreamMode.Read);

				bRet = new Byte[bText.Length];
				//Read the data out of the crypto stream.
				int iLen = csDecrypt.Read(bRet, 0, bRet.Length);

				//Convert the byte array back into a string.
				sRet = Encoding.GetEncoding("shift-jis").GetString(bRet,0,iLen);

				// �X�g���[�������
				csDecrypt.Close();
				inputStream.Close();
				

				rc2 = null;
				csDecrypt = null;
				inputStream = null;	

				if(sRet.Length >= 2){
					// �擪����і����̃_�~�[�������폜
					sRet = sRet.Substring(1,sRet.Length-2);
				}
			}catch(Exception ex){
				sRet = ex.Message;
			}
										
			return sRet;
		}
// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� END
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� START
		private void pic�o�[�R�[�h�ǎ�_Click(object sender, System.EventArgs e)
		{
			tex���b�Z�[�W.Text = "";
			if(gb�����o�͂n�m) return;
			if (g�ǎ��p��� == null)
			{
				g�ǎ��p��� = new �ǎ��p���();
			}
			g�ǎ��p���.ShowDialog(this);
		}

		private void pic�o�[�R�[�h�ǎ�_MouseEnter(object sender, System.EventArgs e)
		{
			pic�o�[�R�[�h�ǎ�.Cursor = Cursors.Default;
			if(gb�����o�͂n�m) return;
			pic�o�[�R�[�h�ǎ�.Cursor = Cursors.Hand;
			pic�o�[�R�[�h�ǎ�.Image = imageCmd[2,4,1];
		}

		private void pic�o�[�R�[�h�ǎ�_MouseLeave(object sender, System.EventArgs e)
		{
			if(gb�����o�͂n�m) return;
			pic�o�[�R�[�h�ǎ�.Image  = imageCmd[2,4,0];
										}
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� END
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� START
		private void pic���x���C���[�W���_Click(object sender, System.EventArgs e)
		{
			//���q�l���̏d�ʓ��͕s�Ή�
			�d�ʓ��͐���擾();

			//�G���[���b�Z�[�W�̃N���A
			tex���b�Z�[�W.Text = "";

			// �����o�͂�ON�̏ꍇ�́A��ʑJ�ڂ��Ȃ�
			if(gb�����o�͂n�m) return;

			if (g�T����� == null)
			{
				g�T����� = new �����T�����();
			}
			g�T�����.Left = this.Left;
			g�T�����.Top = this.Top;
			this.Visible = false;
			g�T�����.ShowDialog(this);
			this.Visible = true;
		}

		private void pic���x���C���[�W���_MouseEnter(object sender, System.EventArgs e)
		{
			pic���x���C���[�W���.Cursor = Cursors.Default;
			if(gb�����o�͂n�m) return;
			pic���x���C���[�W���.Cursor = Cursors.Hand;
			pic���x���C���[�W���.Image  = imageCmd[2,5,1];
		}
						
		private void pic���x���C���[�W���_MouseLeave(object sender, System.EventArgs e)
		{
			if(gb�����o�͂n�m) return;
			pic���x���C���[�W���.Image  = imageCmd[2,5,0];
		}
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� END
	}
}
