using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [�G���g���[�I�v�V����]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// MOD 2006.06.28 ���s�j�R�{�@ �G���g���I�v�V�����̍��ڒǉ� 
	// MOD 2006.12.14 ���s�j�����J ���͐�S���폜�ǉ� 
	//--------------------------------------------------------------------------
	// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� 
	// MOD 2009.10.23 PSN�j����@�I�v�V�����̍��ڒǉ��i�׎D�t�H���g�����g��j
	// MOD 2009.11.06 PSN�j����@�o�׎��шꗗ�\�Ή�
	//--------------------------------------------------------------------------
	// MOD 2010.02.01 ���s�j���� �I�v�V�����̍��ڒǉ��i�b�r�u�o�͌`���j
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� 
	// MOD 2011.03.08 ���s�j���� ���q�^���Ή� 
	// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� 
	// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� 
	// MOD 2011.05.09 ���s�j���� �G�R�[�����ł̃I�v�V�����̃}�[�W 
	// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� 
	// MOD 2011.08.05 ���s�j���� �L���s�̒ǉ��i�R�s�E�U�s�֑ؑΉ��j 
	//--------------------------------------------------------------------------
	// MOD 2012.04.10 ���s�j���� ���x�����X���̈󎚐���Ή� 
	//--------------------------------------------------------------------------
	// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ�
	//--------------------------------------------------------------------------
	// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ�
	// MOD 2016.06.10 BEVAS�j���{ �ی������̓`�F�b�N�@�\�̒ǉ��i31���~�ȏ�̏ꍇ�j
	//--------------------------------------------------------------------------
	public class �ː��؂�ւ� : ���ʃt�H�[��
	{
// MOD 2006.06.28 ���s�j�R�{�@ �G���g���I�v�V�����̍��ڒǉ� START
//		private string[] s���䍀�ږ�   = {"�Z���Q","�Z���R","���O�Q","�S��","���q�l�ԍ�","�A�����i","�i���L��","�d��","���͕��@","�ی���"};
//		private string[] s���䍀�ڂe�f = new string[10];
//		private string[] s���䍀�ڗL�� = new string[10];
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
//		private string[] s���䍀�ږ�   = {"�Z���Q","�Z���R","���O�Q","�S��","���q�l�ԍ�","�A�����i","�i���L��","�d��","���͕��@","�ی���","�˗���"};
// MOD 2009.11.06 PSN�j����@�o�׎��шꗗ�\�Ή� START
// MOD 2009.10.23 PSN�j����@�I�v�V�����̍��ڒǉ� START
//		private string[] s���䍀�ږ�   = {
//											"�Z���Q","�Z���R","���O�Q","�S��","���q�l�ԍ�"
//											,"�A�����i","�i���L��","�d��","���͕��@","�ی���"
//											,"�˗���","���x���׎�l�b�c","�o�׎��шꗗ�\�s��"
//											,"�o�׎��шꗗ�\�˗���"
//										};
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� END

		private string[] s���䍀�ږ�   = {
										"�Z���Q","�Z���R","���O�Q","�S��","���q�l�ԍ�"
										,"�A�����i","�i���L��","�d��","���͕��@","�ی���"
										,"�˗���","���x���׎�l�b�c","�o�׎��шꗗ�\�s��"
										,"�o�׎��шꗗ�\�˗���"
										,"���x���׎�l�g��","�o�׎��шꗗ�\�Ж�"
// MOD 2010.02.01 ���s�j���� �I�v�V�����̍��ڒǉ��i�b�r�u�o�͌`���jSTART
										,"�b�r�u�o�͌`��"
// MOD 2010.02.01 ���s�j���� �I�v�V�����̍��ڒǉ��i�b�r�u�o�͌`���jEND
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
										,"�Z�������O�l��"
										,"���x���X�֔ԍ�"
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
// MOD 2011.05.09 ���s�j���� �G�R�[�����ł̃I�v�V�����̃}�[�W START
										,"��̈�󎚃��x��"
// MOD 2011.05.09 ���s�j���� �G�R�[�����ł̃I�v�V�����̃}�[�W END
// MOD 2012.04.10 ���s�j���� ���x�����X���̈󎚐���Ή� 
										,"���x�����X��"
// MOD 2012.04.10 ���s�j���� ���x�����X���̈󎚐���Ή� 
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� START
										,"�o�[�R�[�h�ǎ���"
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� END
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� START
										,"�˗���Œ�d�ʍl��"
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
// MOD 2016.06.10 BEVAS�j���{ �ی������̓`�F�b�N�@�\�̒ǉ� START
										,"�ی������̓`�F�b�N"
// MOD 2016.06.10 BEVAS�j���{ �ی������̓`�F�b�N�@�\�̒ǉ� END
									};
// MOD 2009.10.23 PSN�j����@�I�v�V�����̍��ڒǉ� END
// MOD 2009.11.06 PSN�j����@�o�׎��шꗗ�\�Ή� END
		private string[] s���䍀�ڂe�f = new string[11];
		private string[] s���䍀�ڗL�� = new string[11];
// MOD 2006.06.28 ���s�j�R�{�@ �G���g���I�v�V�����̍��ڒǉ� END

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lab�ː��؂�ւ��^�C�g��;
		private System.Windows.Forms.Button btn�X�V;
		private System.Windows.Forms.TextBox tex���b�Z�[�W;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label lab�͂���Z���Q;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RadioButton rBtn�͂���Z���Q����;
		private System.Windows.Forms.RadioButton rBtn�͂���Z���Q���Ȃ�;
		private System.Windows.Forms.Label lab�͂���Z���R;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.RadioButton rBtn�͂���Z���R����;
		private System.Windows.Forms.RadioButton rBtn�͂���Z���R���Ȃ�;
		private System.Windows.Forms.Label lab�͂��於�O�Q;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.RadioButton rBtn�͂��於�O�Q����;
		private System.Windows.Forms.RadioButton rBtn�͂��於�O�Q���Ȃ�;
		private System.Windows.Forms.Label lab�S��;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.RadioButton rBtn�S������;
		private System.Windows.Forms.RadioButton rBtn�S�����Ȃ�;
		private System.Windows.Forms.Label lab���q�l�ԍ�;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.RadioButton rBtn���q�l�ԍ�����;
		private System.Windows.Forms.RadioButton rBtn���q�l�ԍ����Ȃ�;
		private System.Windows.Forms.Label lab�A�����i;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.RadioButton rBtn�A�����i����;
		private System.Windows.Forms.RadioButton rBtn�A�����i���Ȃ�;
		private System.Windows.Forms.Label lab�i���L���P;
		private System.Windows.Forms.Panel pnl�i���L���P;
		private System.Windows.Forms.RadioButton rBtn�i���L���P�Q�U�s;
		private System.Windows.Forms.RadioButton rBtn�i���L���P���Ȃ�;
		private System.Windows.Forms.Label lab�d��;
		private System.Windows.Forms.Panel panel14;
		private System.Windows.Forms.RadioButton rBtn�d�ʂ���;
		private System.Windows.Forms.RadioButton rBtn�d�ʂ��Ȃ�;
		private System.Windows.Forms.Label lab�d�ʓ��͕��@;
		private System.Windows.Forms.Panel panel15;
		private System.Windows.Forms.RadioButton rBtn�d�ʓ���;
		private System.Windows.Forms.RadioButton rBtn�ː�����;
		private System.Windows.Forms.Label lab�ی����z;
		private System.Windows.Forms.Panel panel16;
		private System.Windows.Forms.RadioButton rBtn�ی����z����;
		private System.Windows.Forms.RadioButton rBtn�ی����z���Ȃ�;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel12;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RadioButton rBtn�˗�����͂���;
		private System.Windows.Forms.RadioButton rBtn�˗�����͂��Ȃ�;
		private System.Windows.Forms.Button btn�폜;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox gpb��;
		private System.Windows.Forms.GroupBox gpb�E;
		private System.Windows.Forms.Label lab���[���;
		private System.Windows.Forms.Panel pnl�׎�l�R�[�h;
		private System.Windows.Forms.Label lab�o�׎��шꗗ�\;
		private System.Windows.Forms.Panel pnl�o�׎��шꗗ�\;
		private System.Windows.Forms.RadioButton rBtn�o�׎��тW�s;
		private System.Windows.Forms.RadioButton rBtn�o�׎��тQ�s;
		private System.Windows.Forms.Label lab���͂���R�[�h;
		private System.Windows.Forms.RadioButton rBtn���x�����͂���b�c���Ȃ�;
		private System.Windows.Forms.RadioButton rBtn���x�����͂���b�c����;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Panel pn�׎�l�t�H���g�T�C�Y;
		private System.Windows.Forms.RadioButton rBtn�t�H���g�����g�債�Ȃ�;
		private System.Windows.Forms.RadioButton rBtn�t�H���g�����g�傷��;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Panel panel13;
		private System.Windows.Forms.RadioButton rBtn�Ж��󎚂��Ȃ�;
		private System.Windows.Forms.RadioButton rBtn�Ж��󎚂���;
		private System.Windows.Forms.GroupBox grp�E��;
		private System.Windows.Forms.Panel pnl�b�r�u�o�͌`��;
		private System.Windows.Forms.RadioButton rBtn�o�ׂb�r�u�W��;
		private System.Windows.Forms.RadioButton rBtn�o�ׂb�r�u�G���g���[;
		private System.Windows.Forms.Label lab�o�ׂb�r�u�o��;
		private System.Windows.Forms.Label lab�o�ׂb�r�u�o�͌`��;
		private System.Windows.Forms.Label lab�X�֔ԍ�;
		private System.Windows.Forms.Panel pan�X�֔ԍ�;
		private System.Windows.Forms.RadioButton rBtn���x���X�֔ԍ����Ȃ�;
		private System.Windows.Forms.RadioButton rBtn���x���X�֔ԍ�����;
		private System.Windows.Forms.Label lab���͂�����;
		private System.Windows.Forms.Panel pan�O�l��;
		private System.Windows.Forms.RadioButton rBtn�O�l�߂���;
		private System.Windows.Forms.RadioButton rBtn�O�l�߂��Ȃ�;
		private System.Windows.Forms.Label lab�O�l��;
		private System.Windows.Forms.Label lab���x�����;
		private System.Windows.Forms.RadioButton rBtn�o�ׂb�r�u�W���Q;
		private System.Windows.Forms.RadioButton rBtn�o�ׂb�r�u�G���g���[�Q;
		private System.Windows.Forms.RadioButton rBtn�i���L���P�Q�R�s;
		private System.Windows.Forms.Label lab���X��;
		private System.Windows.Forms.Panel pnl���X��;
		private System.Windows.Forms.RadioButton rBtn���x�����X������;
		private System.Windows.Forms.RadioButton rBtn���x�����X�����Ȃ�;
		private System.Windows.Forms.Label lab�o�[�R�[�h�ǎ��p;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.RadioButton rBtn�ǎ�\������;
		private System.Windows.Forms.RadioButton rBtn�ǎ�\�����Ȃ�;
		private System.Windows.Forms.Label lab�˗���d�ʍl��;
		private System.Windows.Forms.Panel pnl�˗���d�ʍl��;
		private System.Windows.Forms.RadioButton rBtn�˗���d�ʍl�����Ȃ�;
		private System.Windows.Forms.RadioButton rBtn�˗���d�ʍl������;
		private System.Windows.Forms.Panel pnl�ی����z�`�F�b�N;
		private System.Windows.Forms.RadioButton rBtn�ی����z�`�F�b�N����;
		private System.Windows.Forms.RadioButton rBtn�ی����z�`�F�b�N���Ȃ�;
		private System.Windows.Forms.Label lab�ی����z�`�F�b�N;
		private System.ComponentModel.IContainer components = null;

		public �ː��؂�ւ�()
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.grp�E�� = new System.Windows.Forms.GroupBox();
			this.lab���͂����� = new System.Windows.Forms.Label();
			this.lab�o�ׂb�r�u�o�͌`�� = new System.Windows.Forms.Label();
			this.pnl�b�r�u�o�͌`�� = new System.Windows.Forms.Panel();
			this.rBtn�o�ׂb�r�u�G���g���[�Q = new System.Windows.Forms.RadioButton();
			this.rBtn�o�ׂb�r�u�W���Q = new System.Windows.Forms.RadioButton();
			this.rBtn�o�ׂb�r�u�W�� = new System.Windows.Forms.RadioButton();
			this.rBtn�o�ׂb�r�u�G���g���[ = new System.Windows.Forms.RadioButton();
			this.lab�o�ׂb�r�u�o�� = new System.Windows.Forms.Label();
			this.btn�폜 = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.gpb�E = new System.Windows.Forms.GroupBox();
			this.lab���X�� = new System.Windows.Forms.Label();
			this.pnl���X�� = new System.Windows.Forms.Panel();
			this.rBtn���x�����X������ = new System.Windows.Forms.RadioButton();
			this.rBtn���x�����X�����Ȃ� = new System.Windows.Forms.RadioButton();
			this.lab���x����� = new System.Windows.Forms.Label();
			this.pan�X�֔ԍ� = new System.Windows.Forms.Panel();
			this.rBtn���x���X�֔ԍ����Ȃ� = new System.Windows.Forms.RadioButton();
			this.rBtn���x���X�֔ԍ����� = new System.Windows.Forms.RadioButton();
			this.lab�X�֔ԍ� = new System.Windows.Forms.Label();
			this.panel13 = new System.Windows.Forms.Panel();
			this.rBtn�Ж��󎚂��Ȃ� = new System.Windows.Forms.RadioButton();
			this.rBtn�Ж��󎚂��� = new System.Windows.Forms.RadioButton();
			this.label11 = new System.Windows.Forms.Label();
			this.pn�׎�l�t�H���g�T�C�Y = new System.Windows.Forms.Panel();
			this.rBtn�t�H���g�����g�債�Ȃ� = new System.Windows.Forms.RadioButton();
			this.rBtn�t�H���g�����g�傷�� = new System.Windows.Forms.RadioButton();
			this.label10 = new System.Windows.Forms.Label();
			this.lab���[��� = new System.Windows.Forms.Label();
			this.lab���͂���R�[�h = new System.Windows.Forms.Label();
			this.pnl�׎�l�R�[�h = new System.Windows.Forms.Panel();
			this.rBtn���x�����͂���b�c���Ȃ� = new System.Windows.Forms.RadioButton();
			this.rBtn���x�����͂���b�c���� = new System.Windows.Forms.RadioButton();
			this.lab�o�׎��шꗗ�\ = new System.Windows.Forms.Label();
			this.pnl�o�׎��шꗗ�\ = new System.Windows.Forms.Panel();
			this.rBtn�o�׎��тW�s = new System.Windows.Forms.RadioButton();
			this.rBtn�o�׎��тQ�s = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.gpb�� = new System.Windows.Forms.GroupBox();
			this.lab�˗���d�ʍl�� = new System.Windows.Forms.Label();
			this.pnl�˗���d�ʍl�� = new System.Windows.Forms.Panel();
			this.rBtn�˗���d�ʍl�����Ȃ� = new System.Windows.Forms.RadioButton();
			this.rBtn�˗���d�ʍl������ = new System.Windows.Forms.RadioButton();
			this.panel11 = new System.Windows.Forms.Panel();
			this.rBtn�ǎ�\������ = new System.Windows.Forms.RadioButton();
			this.rBtn�ǎ�\�����Ȃ� = new System.Windows.Forms.RadioButton();
			this.lab�o�[�R�[�h�ǎ��p = new System.Windows.Forms.Label();
			this.lab�O�l�� = new System.Windows.Forms.Label();
			this.pan�O�l�� = new System.Windows.Forms.Panel();
			this.rBtn�O�l�߂��� = new System.Windows.Forms.RadioButton();
			this.rBtn�O�l�߂��Ȃ� = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.panel12 = new System.Windows.Forms.Panel();
			this.rBtn�˗�����͂��� = new System.Windows.Forms.RadioButton();
			this.rBtn�˗�����͂��Ȃ� = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel16 = new System.Windows.Forms.Panel();
			this.rBtn�ی����z���� = new System.Windows.Forms.RadioButton();
			this.rBtn�ی����z���Ȃ� = new System.Windows.Forms.RadioButton();
			this.lab�ی����z = new System.Windows.Forms.Label();
			this.panel15 = new System.Windows.Forms.Panel();
			this.rBtn�d�ʓ��� = new System.Windows.Forms.RadioButton();
			this.rBtn�ː����� = new System.Windows.Forms.RadioButton();
			this.lab�d�ʓ��͕��@ = new System.Windows.Forms.Label();
			this.panel14 = new System.Windows.Forms.Panel();
			this.rBtn�d�ʂ��� = new System.Windows.Forms.RadioButton();
			this.rBtn�d�ʂ��Ȃ� = new System.Windows.Forms.RadioButton();
			this.lab�d�� = new System.Windows.Forms.Label();
			this.pnl�i���L���P = new System.Windows.Forms.Panel();
			this.rBtn�i���L���P�Q�U�s = new System.Windows.Forms.RadioButton();
			this.rBtn�i���L���P���Ȃ� = new System.Windows.Forms.RadioButton();
			this.rBtn�i���L���P�Q�R�s = new System.Windows.Forms.RadioButton();
			this.lab�i���L���P = new System.Windows.Forms.Label();
			this.panel10 = new System.Windows.Forms.Panel();
			this.rBtn�A�����i���� = new System.Windows.Forms.RadioButton();
			this.rBtn�A�����i���Ȃ� = new System.Windows.Forms.RadioButton();
			this.lab�A�����i = new System.Windows.Forms.Label();
			this.panel9 = new System.Windows.Forms.Panel();
			this.rBtn���q�l�ԍ����� = new System.Windows.Forms.RadioButton();
			this.rBtn���q�l�ԍ����Ȃ� = new System.Windows.Forms.RadioButton();
			this.lab���q�l�ԍ� = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.rBtn�S������ = new System.Windows.Forms.RadioButton();
			this.rBtn�S�����Ȃ� = new System.Windows.Forms.RadioButton();
			this.lab�S�� = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.rBtn�͂��於�O�Q���� = new System.Windows.Forms.RadioButton();
			this.rBtn�͂��於�O�Q���Ȃ� = new System.Windows.Forms.RadioButton();
			this.lab�͂��於�O�Q = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.rBtn�͂���Z���R���� = new System.Windows.Forms.RadioButton();
			this.rBtn�͂���Z���R���Ȃ� = new System.Windows.Forms.RadioButton();
			this.lab�͂���Z���R = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.rBtn�͂���Z���Q���� = new System.Windows.Forms.RadioButton();
			this.rBtn�͂���Z���Q���Ȃ� = new System.Windows.Forms.RadioButton();
			this.lab�͂���Z���Q = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab�ː��؂�ւ��^�C�g�� = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn�X�V = new System.Windows.Forms.Button();
			this.tex���b�Z�[�W = new System.Windows.Forms.TextBox();
			this.btn���� = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.pnl�ی����z�`�F�b�N = new System.Windows.Forms.Panel();
			this.rBtn�ی����z�`�F�b�N���� = new System.Windows.Forms.RadioButton();
			this.rBtn�ی����z�`�F�b�N���Ȃ� = new System.Windows.Forms.RadioButton();
			this.lab�ی����z�`�F�b�N = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).BeginInit();
			this.panel1.SuspendLayout();
			this.grp�E��.SuspendLayout();
			this.pnl�b�r�u�o�͌`��.SuspendLayout();
			this.gpb�E.SuspendLayout();
			this.pnl���X��.SuspendLayout();
			this.pan�X�֔ԍ�.SuspendLayout();
			this.panel13.SuspendLayout();
			this.pn�׎�l�t�H���g�T�C�Y.SuspendLayout();
			this.pnl�׎�l�R�[�h.SuspendLayout();
			this.pnl�o�׎��шꗗ�\.SuspendLayout();
			this.gpb��.SuspendLayout();
			this.pnl�˗���d�ʍl��.SuspendLayout();
			this.panel11.SuspendLayout();
			this.pan�O�l��.SuspendLayout();
			this.panel12.SuspendLayout();
			this.panel16.SuspendLayout();
			this.panel15.SuspendLayout();
			this.panel14.SuspendLayout();
			this.pnl�i���L���P.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.pnl�ی����z�`�F�b�N.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Honeydew;
			this.panel1.Controls.Add(this.grp�E��);
			this.panel1.Controls.Add(this.gpb�E);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.gpb��);
			this.panel1.Location = new System.Drawing.Point(0, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(778, 448);
			this.panel1.TabIndex = 1;
			// 
			// grp�E��
			// 
			this.grp�E��.Controls.Add(this.lab���͂�����);
			this.grp�E��.Controls.Add(this.lab�o�ׂb�r�u�o�͌`��);
			this.grp�E��.Controls.Add(this.pnl�b�r�u�o�͌`��);
			this.grp�E��.Controls.Add(this.lab�o�ׂb�r�u�o��);
			this.grp�E��.Controls.Add(this.btn�폜);
			this.grp�E��.Controls.Add(this.label9);
			this.grp�E��.Controls.Add(this.label8);
			this.grp�E��.Controls.Add(this.label7);
			this.grp�E��.Location = new System.Drawing.Point(412, 4);
			this.grp�E��.Name = "grp�E��";
			this.grp�E��.Size = new System.Drawing.Size(344, 200);
			this.grp�E��.TabIndex = 1;
			this.grp�E��.TabStop = false;
			// 
			// lab���͂�����
			// 
			this.lab���͂�����.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab���͂�����.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lab���͂�����.ForeColor = System.Drawing.Color.White;
			this.lab���͂�����.Location = new System.Drawing.Point(1, 112);
			this.lab���͂�����.Name = "lab���͂�����";
			this.lab���͂�����.Size = new System.Drawing.Size(343, 22);
			this.lab���͂�����.TabIndex = 92;
			this.lab���͂�����.Text = "���͂�����";
			this.lab���͂�����.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab�o�ׂb�r�u�o�͌`��
			// 
			this.lab�o�ׂb�r�u�o�͌`��.BackColor = System.Drawing.Color.Honeydew;
			this.lab�o�ׂb�r�u�o�͌`��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�o�ׂb�r�u�o�͌`��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�o�ׂb�r�u�o�͌`��.Location = new System.Drawing.Point(14, 32);
			this.lab�o�ׂb�r�u�o�͌`��.Name = "lab�o�ׂb�r�u�o�͌`��";
			this.lab�o�ׂb�r�u�o�͌`��.Size = new System.Drawing.Size(112, 14);
			this.lab�o�ׂb�r�u�o�͌`��.TabIndex = 91;
			this.lab�o�ׂb�r�u�o�͌`��.Text = "�o�ׂb�r�u�o�͌`��";
			// 
			// pnl�b�r�u�o�͌`��
			// 
			this.pnl�b�r�u�o�͌`��.Controls.Add(this.rBtn�o�ׂb�r�u�G���g���[�Q);
			this.pnl�b�r�u�o�͌`��.Controls.Add(this.rBtn�o�ׂb�r�u�W���Q);
			this.pnl�b�r�u�o�͌`��.Controls.Add(this.rBtn�o�ׂb�r�u�W��);
			this.pnl�b�r�u�o�͌`��.Controls.Add(this.rBtn�o�ׂb�r�u�G���g���[);
			this.pnl�b�r�u�o�͌`��.Location = new System.Drawing.Point(140, 26);
			this.pnl�b�r�u�o�͌`��.Name = "pnl�b�r�u�o�͌`��";
			this.pnl�b�r�u�o�͌`��.Size = new System.Drawing.Size(202, 62);
			this.pnl�b�r�u�o�͌`��.TabIndex = 0;
			// 
			// rBtn�o�ׂb�r�u�G���g���[�Q
			// 
			this.rBtn�o�ׂb�r�u�G���g���[�Q.Location = new System.Drawing.Point(88, 26);
			this.rBtn�o�ׂb�r�u�G���g���[�Q.Name = "rBtn�o�ׂb�r�u�G���g���[�Q";
			this.rBtn�o�ׂb�r�u�G���g���[�Q.Size = new System.Drawing.Size(114, 30);
			this.rBtn�o�ׂb�r�u�G���g���[�Q.TabIndex = 4;
			this.rBtn�o�ׂb�r�u�G���g���[�Q.Text = "CSV����-�`���Q �i�L���U�s�j";
			// 
			// rBtn�o�ׂb�r�u�W���Q
			// 
			this.rBtn�o�ׂb�r�u�W���Q.Location = new System.Drawing.Point(0, 26);
			this.rBtn�o�ׂb�r�u�W���Q.Name = "rBtn�o�ׂb�r�u�W���Q";
			this.rBtn�o�ׂb�r�u�W���Q.Size = new System.Drawing.Size(82, 30);
			this.rBtn�o�ׂb�r�u�W���Q.TabIndex = 3;
			this.rBtn�o�ׂb�r�u�W���Q.Text = "�W���`���Q �i�L���U�s�j";
			// 
			// rBtn�o�ׂb�r�u�W��
			// 
			this.rBtn�o�ׂb�r�u�W��.Checked = true;
			this.rBtn�o�ׂb�r�u�W��.Location = new System.Drawing.Point(0, 0);
			this.rBtn�o�ׂb�r�u�W��.Name = "rBtn�o�ׂb�r�u�W��";
			this.rBtn�o�ׂb�r�u�W��.Size = new System.Drawing.Size(82, 24);
			this.rBtn�o�ׂb�r�u�W��.TabIndex = 1;
			this.rBtn�o�ׂb�r�u�W��.TabStop = true;
			this.rBtn�o�ׂb�r�u�W��.Text = "�W���`��";
			// 
			// rBtn�o�ׂb�r�u�G���g���[
			// 
			this.rBtn�o�ׂb�r�u�G���g���[.Location = new System.Drawing.Point(88, 0);
			this.rBtn�o�ׂb�r�u�G���g���[.Name = "rBtn�o�ׂb�r�u�G���g���[";
			this.rBtn�o�ׂb�r�u�G���g���[.Size = new System.Drawing.Size(114, 24);
			this.rBtn�o�ׂb�r�u�G���g���[.TabIndex = 2;
			this.rBtn�o�ׂb�r�u�G���g���[.Text = "CSV����-�`��";
			// 
			// lab�o�ׂb�r�u�o��
			// 
			this.lab�o�ׂb�r�u�o��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�o�ׂb�r�u�o��.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lab�o�ׂb�r�u�o��.ForeColor = System.Drawing.Color.White;
			this.lab�o�ׂb�r�u�o��.Location = new System.Drawing.Point(0, 0);
			this.lab�o�ׂb�r�u�o��.Name = "lab�o�ׂb�r�u�o��";
			this.lab�o�ׂb�r�u�o��.Size = new System.Drawing.Size(343, 22);
			this.lab�o�ׂb�r�u�o��.TabIndex = 87;
			this.lab�o�ׂb�r�u�o��.Text = "�o�ׂb�r�u�o�́i�o�׏Ɖ�E�o�׎��сj";
			this.lab�o�ׂb�r�u�o��.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn�폜
			// 
			this.btn�폜.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�폜.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�폜.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�폜.ForeColor = System.Drawing.Color.White;
			this.btn�폜.Location = new System.Drawing.Point(14, 140);
			this.btn�폜.Name = "btn�폜";
			this.btn�폜.Size = new System.Drawing.Size(66, 22);
			this.btn�폜.TabIndex = 1;
			this.btn�폜.TabStop = false;
			this.btn�폜.Text = "�S���폜";
			this.btn�폜.Click += new System.EventHandler(this.btn�폜_Click);
			// 
			// label9
			// 
			this.label9.ForeColor = System.Drawing.Color.Red;
			this.label9.Location = new System.Drawing.Point(90, 138);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(16, 14);
			this.label9.TabIndex = 47;
			this.label9.Text = "��";
			// 
			// label8
			// 
			this.label8.ForeColor = System.Drawing.Color.Red;
			this.label8.Location = new System.Drawing.Point(106, 174);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(196, 24);
			this.label8.TabIndex = 46;
			this.label8.Text = "�܂��A���O��CSV�o�͂ɂ��o�b�N�A�b�v������肭�������B";
			// 
			// label7
			// 
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(106, 138);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(188, 42);
			this.label7.TabIndex = 45;
			this.label7.Text = "���͂����S���폜����ꍇ�A�폜��͕����ł��܂���̂ŁA���ʂȏꍇ�ȊO�͍s��Ȃ��ł��������B";
			// 
			// gpb�E
			// 
			this.gpb�E.Controls.Add(this.lab���X��);
			this.gpb�E.Controls.Add(this.pnl���X��);
			this.gpb�E.Controls.Add(this.lab���x�����);
			this.gpb�E.Controls.Add(this.pan�X�֔ԍ�);
			this.gpb�E.Controls.Add(this.lab�X�֔ԍ�);
			this.gpb�E.Controls.Add(this.panel13);
			this.gpb�E.Controls.Add(this.label11);
			this.gpb�E.Controls.Add(this.pn�׎�l�t�H���g�T�C�Y);
			this.gpb�E.Controls.Add(this.label10);
			this.gpb�E.Controls.Add(this.lab���[���);
			this.gpb�E.Controls.Add(this.lab���͂���R�[�h);
			this.gpb�E.Controls.Add(this.pnl�׎�l�R�[�h);
			this.gpb�E.Controls.Add(this.lab�o�׎��шꗗ�\);
			this.gpb�E.Controls.Add(this.pnl�o�׎��шꗗ�\);
			this.gpb�E.Location = new System.Drawing.Point(412, 204);
			this.gpb�E.Name = "gpb�E";
			this.gpb�E.Size = new System.Drawing.Size(344, 240);
			this.gpb�E.TabIndex = 2;
			this.gpb�E.TabStop = false;
			// 
			// lab���X��
			// 
			this.lab���X��.BackColor = System.Drawing.Color.Honeydew;
			this.lab���X��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���X��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���X��.Location = new System.Drawing.Point(18, 32);
			this.lab���X��.Name = "lab���X��";
			this.lab���X��.Size = new System.Drawing.Size(100, 14);
			this.lab���X��.TabIndex = 102;
			this.lab���X��.Text = "���X��";
			// 
			// pnl���X��
			// 
			this.pnl���X��.Controls.Add(this.rBtn���x�����X������);
			this.pnl���X��.Controls.Add(this.rBtn���x�����X�����Ȃ�);
			this.pnl���X��.Location = new System.Drawing.Point(140, 26);
			this.pnl���X��.Name = "pnl���X��";
			this.pnl���X��.Size = new System.Drawing.Size(180, 24);
			this.pnl���X��.TabIndex = 0;
			// 
			// rBtn���x�����X������
			// 
			this.rBtn���x�����X������.Checked = true;
			this.rBtn���x�����X������.Location = new System.Drawing.Point(0, 0);
			this.rBtn���x�����X������.Name = "rBtn���x�����X������";
			this.rBtn���x�����X������.Size = new System.Drawing.Size(80, 24);
			this.rBtn���x�����X������.TabIndex = 1;
			this.rBtn���x�����X������.TabStop = true;
			this.rBtn���x�����X������.Text = "�󎚂���";
			// 
			// rBtn���x�����X�����Ȃ�
			// 
			this.rBtn���x�����X�����Ȃ�.Location = new System.Drawing.Point(100, 0);
			this.rBtn���x�����X�����Ȃ�.Name = "rBtn���x�����X�����Ȃ�";
			this.rBtn���x�����X�����Ȃ�.Size = new System.Drawing.Size(80, 24);
			this.rBtn���x�����X�����Ȃ�.TabIndex = 2;
			this.rBtn���x�����X�����Ȃ�.Text = "�󎚂��Ȃ�";
			// 
			// lab���x�����
			// 
			this.lab���x�����.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab���x�����.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lab���x�����.ForeColor = System.Drawing.Color.White;
			this.lab���x�����.Location = new System.Drawing.Point(0, 0);
			this.lab���x�����.Name = "lab���x�����";
			this.lab���x�����.Size = new System.Drawing.Size(343, 22);
			this.lab���x�����.TabIndex = 87;
			this.lab���x�����.Text = "���x�����";
			this.lab���x�����.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pan�X�֔ԍ�
			// 
			this.pan�X�֔ԍ�.Controls.Add(this.rBtn���x���X�֔ԍ����Ȃ�);
			this.pan�X�֔ԍ�.Controls.Add(this.rBtn���x���X�֔ԍ�����);
			this.pan�X�֔ԍ�.Location = new System.Drawing.Point(140, 104);
			this.pan�X�֔ԍ�.Name = "pan�X�֔ԍ�";
			this.pan�X�֔ԍ�.Size = new System.Drawing.Size(180, 24);
			this.pan�X�֔ԍ�.TabIndex = 3;
			// 
			// rBtn���x���X�֔ԍ����Ȃ�
			// 
			this.rBtn���x���X�֔ԍ����Ȃ�.Location = new System.Drawing.Point(100, 0);
			this.rBtn���x���X�֔ԍ����Ȃ�.Name = "rBtn���x���X�֔ԍ����Ȃ�";
			this.rBtn���x���X�֔ԍ����Ȃ�.Size = new System.Drawing.Size(80, 24);
			this.rBtn���x���X�֔ԍ����Ȃ�.TabIndex = 2;
			this.rBtn���x���X�֔ԍ����Ȃ�.Text = "�󎚂��Ȃ�";
			// 
			// rBtn���x���X�֔ԍ�����
			// 
			this.rBtn���x���X�֔ԍ�����.Checked = true;
			this.rBtn���x���X�֔ԍ�����.Location = new System.Drawing.Point(0, 0);
			this.rBtn���x���X�֔ԍ�����.Name = "rBtn���x���X�֔ԍ�����";
			this.rBtn���x���X�֔ԍ�����.Size = new System.Drawing.Size(80, 24);
			this.rBtn���x���X�֔ԍ�����.TabIndex = 1;
			this.rBtn���x���X�֔ԍ�����.TabStop = true;
			this.rBtn���x���X�֔ԍ�����.Text = "�󎚂���";
			// 
			// lab�X�֔ԍ�
			// 
			this.lab�X�֔ԍ�.BackColor = System.Drawing.Color.Honeydew;
			this.lab�X�֔ԍ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�X�֔ԍ�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�X�֔ԍ�.Location = new System.Drawing.Point(18, 110);
			this.lab�X�֔ԍ�.Name = "lab�X�֔ԍ�";
			this.lab�X�֔ԍ�.Size = new System.Drawing.Size(100, 14);
			this.lab�X�֔ԍ�.TabIndex = 100;
			this.lab�X�֔ԍ�.Text = "�X�֔ԍ�";
			// 
			// panel13
			// 
			this.panel13.Controls.Add(this.rBtn�Ж��󎚂��Ȃ�);
			this.panel13.Controls.Add(this.rBtn�Ж��󎚂���);
			this.panel13.Location = new System.Drawing.Point(140, 188);
			this.panel13.Name = "panel13";
			this.panel13.Size = new System.Drawing.Size(180, 24);
			this.panel13.TabIndex = 4;
			// 
			// rBtn�Ж��󎚂��Ȃ�
			// 
			this.rBtn�Ж��󎚂��Ȃ�.Checked = true;
			this.rBtn�Ж��󎚂��Ȃ�.Location = new System.Drawing.Point(0, 0);
			this.rBtn�Ж��󎚂��Ȃ�.Name = "rBtn�Ж��󎚂��Ȃ�";
			this.rBtn�Ж��󎚂��Ȃ�.Size = new System.Drawing.Size(80, 24);
			this.rBtn�Ж��󎚂��Ȃ�.TabIndex = 3;
			this.rBtn�Ж��󎚂��Ȃ�.TabStop = true;
			this.rBtn�Ж��󎚂��Ȃ�.Text = "�󎚂��Ȃ�";
			// 
			// rBtn�Ж��󎚂���
			// 
			this.rBtn�Ж��󎚂���.Location = new System.Drawing.Point(100, 0);
			this.rBtn�Ж��󎚂���.Name = "rBtn�Ж��󎚂���";
			this.rBtn�Ж��󎚂���.Size = new System.Drawing.Size(80, 24);
			this.rBtn�Ж��󎚂���.TabIndex = 3;
			this.rBtn�Ж��󎚂���.Text = "�󎚂���";
			// 
			// label11
			// 
			this.label11.BackColor = System.Drawing.Color.Honeydew;
			this.label11.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label11.ForeColor = System.Drawing.Color.LimeGreen;
			this.label11.Location = new System.Drawing.Point(18, 194);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 14);
			this.label11.TabIndex = 98;
			this.label11.Text = "���R�ʉ^�Ж�";
			// 
			// pn�׎�l�t�H���g�T�C�Y
			// 
			this.pn�׎�l�t�H���g�T�C�Y.Controls.Add(this.rBtn�t�H���g�����g�債�Ȃ�);
			this.pn�׎�l�t�H���g�T�C�Y.Controls.Add(this.rBtn�t�H���g�����g�傷��);
			this.pn�׎�l�t�H���g�T�C�Y.Location = new System.Drawing.Point(140, 78);
			this.pn�׎�l�t�H���g�T�C�Y.Name = "pn�׎�l�t�H���g�T�C�Y";
			this.pn�׎�l�t�H���g�T�C�Y.Size = new System.Drawing.Size(198, 24);
			this.pn�׎�l�t�H���g�T�C�Y.TabIndex = 2;
			// 
			// rBtn�t�H���g�����g�債�Ȃ�
			// 
			this.rBtn�t�H���g�����g�債�Ȃ�.Location = new System.Drawing.Point(100, 0);
			this.rBtn�t�H���g�����g�債�Ȃ�.Name = "rBtn�t�H���g�����g�債�Ȃ�";
			this.rBtn�t�H���g�����g�債�Ȃ�.TabIndex = 3;
			this.rBtn�t�H���g�����g�債�Ȃ�.Text = "�����g�債�Ȃ�";
			// 
			// rBtn�t�H���g�����g�傷��
			// 
			this.rBtn�t�H���g�����g�傷��.Checked = true;
			this.rBtn�t�H���g�����g�傷��.Location = new System.Drawing.Point(0, 0);
			this.rBtn�t�H���g�����g�傷��.Name = "rBtn�t�H���g�����g�傷��";
			this.rBtn�t�H���g�����g�傷��.Size = new System.Drawing.Size(94, 24);
			this.rBtn�t�H���g�����g�傷��.TabIndex = 2;
			this.rBtn�t�H���g�����g�傷��.TabStop = true;
			this.rBtn�t�H���g�����g�傷��.Text = "�����g�傷��";
			// 
			// label10
			// 
			this.label10.BackColor = System.Drawing.Color.Honeydew;
			this.label10.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label10.ForeColor = System.Drawing.Color.LimeGreen;
			this.label10.Location = new System.Drawing.Point(18, 84);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(112, 14);
			this.label10.TabIndex = 96;
			this.label10.Text = "�׎�l�t�H���g�T�C�Y";
			// 
			// lab���[���
			// 
			this.lab���[���.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab���[���.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lab���[���.ForeColor = System.Drawing.Color.White;
			this.lab���[���.Location = new System.Drawing.Point(0, 136);
			this.lab���[���.Name = "lab���[���";
			this.lab���[���.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lab���[���.Size = new System.Drawing.Size(343, 22);
			this.lab���[���.TabIndex = 92;
			this.lab���[���.Text = "���[���";
			this.lab���[���.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab���͂���R�[�h
			// 
			this.lab���͂���R�[�h.BackColor = System.Drawing.Color.Honeydew;
			this.lab���͂���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���͂���R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���͂���R�[�h.Location = new System.Drawing.Point(18, 58);
			this.lab���͂���R�[�h.Name = "lab���͂���R�[�h";
			this.lab���͂���R�[�h.Size = new System.Drawing.Size(100, 14);
			this.lab���͂���R�[�h.TabIndex = 91;
			this.lab���͂���R�[�h.Text = "���͂���R�[�h";
			// 
			// pnl�׎�l�R�[�h
			// 
			this.pnl�׎�l�R�[�h.Controls.Add(this.rBtn���x�����͂���b�c���Ȃ�);
			this.pnl�׎�l�R�[�h.Controls.Add(this.rBtn���x�����͂���b�c����);
			this.pnl�׎�l�R�[�h.Location = new System.Drawing.Point(140, 52);
			this.pnl�׎�l�R�[�h.Name = "pnl�׎�l�R�[�h";
			this.pnl�׎�l�R�[�h.Size = new System.Drawing.Size(180, 24);
			this.pnl�׎�l�R�[�h.TabIndex = 1;
			// 
			// rBtn���x�����͂���b�c���Ȃ�
			// 
			this.rBtn���x�����͂���b�c���Ȃ�.Checked = true;
			this.rBtn���x�����͂���b�c���Ȃ�.Location = new System.Drawing.Point(0, 0);
			this.rBtn���x�����͂���b�c���Ȃ�.Name = "rBtn���x�����͂���b�c���Ȃ�";
			this.rBtn���x�����͂���b�c���Ȃ�.Size = new System.Drawing.Size(80, 24);
			this.rBtn���x�����͂���b�c���Ȃ�.TabIndex = 1;
			this.rBtn���x�����͂���b�c���Ȃ�.TabStop = true;
			this.rBtn���x�����͂���b�c���Ȃ�.Text = "�󎚂��Ȃ�";
			// 
			// rBtn���x�����͂���b�c����
			// 
			this.rBtn���x�����͂���b�c����.Location = new System.Drawing.Point(100, 0);
			this.rBtn���x�����͂���b�c����.Name = "rBtn���x�����͂���b�c����";
			this.rBtn���x�����͂���b�c����.Size = new System.Drawing.Size(80, 24);
			this.rBtn���x�����͂���b�c����.TabIndex = 2;
			this.rBtn���x�����͂���b�c����.Text = "�󎚂���";
			// 
			// lab�o�׎��шꗗ�\
			// 
			this.lab�o�׎��шꗗ�\.BackColor = System.Drawing.Color.Honeydew;
			this.lab�o�׎��шꗗ�\.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�o�׎��шꗗ�\.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�o�׎��шꗗ�\.Location = new System.Drawing.Point(18, 168);
			this.lab�o�׎��шꗗ�\.Name = "lab�o�׎��шꗗ�\";
			this.lab�o�׎��шꗗ�\.Size = new System.Drawing.Size(100, 14);
			this.lab�o�׎��шꗗ�\.TabIndex = 89;
			this.lab�o�׎��шꗗ�\.Text = "�o�׎��шꗗ�\";
			// 
			// pnl�o�׎��шꗗ�\
			// 
			this.pnl�o�׎��шꗗ�\.Controls.Add(this.rBtn�o�׎��тW�s);
			this.pnl�o�׎��шꗗ�\.Controls.Add(this.rBtn�o�׎��тQ�s);
			this.pnl�o�׎��шꗗ�\.Location = new System.Drawing.Point(140, 162);
			this.pnl�o�׎��шꗗ�\.Name = "pnl�o�׎��шꗗ�\";
			this.pnl�o�׎��шꗗ�\.Size = new System.Drawing.Size(180, 24);
			this.pnl�o�׎��шꗗ�\.TabIndex = 3;
			// 
			// rBtn�o�׎��тW�s
			// 
			this.rBtn�o�׎��тW�s.Checked = true;
			this.rBtn�o�׎��тW�s.Location = new System.Drawing.Point(0, 0);
			this.rBtn�o�׎��тW�s.Name = "rBtn�o�׎��тW�s";
			this.rBtn�o�׎��тW�s.Size = new System.Drawing.Size(80, 24);
			this.rBtn�o�׎��тW�s.TabIndex = 1;
			this.rBtn�o�׎��тW�s.TabStop = true;
			this.rBtn�o�׎��тW�s.Text = "�W�s";
			// 
			// rBtn�o�׎��тQ�s
			// 
			this.rBtn�o�׎��тQ�s.Location = new System.Drawing.Point(100, 0);
			this.rBtn�o�׎��тQ�s.Name = "rBtn�o�׎��тQ�s";
			this.rBtn�o�׎��тQ�s.Size = new System.Drawing.Size(80, 24);
			this.rBtn�o�׎��тQ�s.TabIndex = 2;
			this.rBtn�o�׎��тQ�s.Text = "�Q�s";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 450);
			this.label1.TabIndex = 44;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// gpb��
			// 
			this.gpb��.BackColor = System.Drawing.Color.Honeydew;
			this.gpb��.Controls.Add(this.lab�ی����z�`�F�b�N);
			this.gpb��.Controls.Add(this.pnl�ی����z�`�F�b�N);
			this.gpb��.Controls.Add(this.lab�˗���d�ʍl��);
			this.gpb��.Controls.Add(this.pnl�˗���d�ʍl��);
			this.gpb��.Controls.Add(this.panel11);
			this.gpb��.Controls.Add(this.lab�o�[�R�[�h�ǎ��p);
			this.gpb��.Controls.Add(this.lab�O�l��);
			this.gpb��.Controls.Add(this.pan�O�l��);
			this.gpb��.Controls.Add(this.label6);
			this.gpb��.Controls.Add(this.panel12);
			this.gpb��.Controls.Add(this.label4);
			this.gpb��.Controls.Add(this.label3);
			this.gpb��.Controls.Add(this.label2);
			this.gpb��.Controls.Add(this.panel16);
			this.gpb��.Controls.Add(this.lab�ی����z);
			this.gpb��.Controls.Add(this.panel15);
			this.gpb��.Controls.Add(this.lab�d�ʓ��͕��@);
			this.gpb��.Controls.Add(this.panel14);
			this.gpb��.Controls.Add(this.lab�d��);
			this.gpb��.Controls.Add(this.pnl�i���L���P);
			this.gpb��.Controls.Add(this.lab�i���L���P);
			this.gpb��.Controls.Add(this.panel10);
			this.gpb��.Controls.Add(this.lab�A�����i);
			this.gpb��.Controls.Add(this.panel9);
			this.gpb��.Controls.Add(this.lab���q�l�ԍ�);
			this.gpb��.Controls.Add(this.panel5);
			this.gpb��.Controls.Add(this.lab�S��);
			this.gpb��.Controls.Add(this.panel4);
			this.gpb��.Controls.Add(this.lab�͂��於�O�Q);
			this.gpb��.Controls.Add(this.panel3);
			this.gpb��.Controls.Add(this.lab�͂���Z���R);
			this.gpb��.Controls.Add(this.panel2);
			this.gpb��.Controls.Add(this.lab�͂���Z���Q);
			this.gpb��.ForeColor = System.Drawing.Color.Black;
			this.gpb��.Location = new System.Drawing.Point(44, 4);
			this.gpb��.Name = "gpb��";
			this.gpb��.Size = new System.Drawing.Size(344, 440);
			this.gpb��.TabIndex = 0;
			this.gpb��.TabStop = false;
			// 
			// lab�˗���d�ʍl��
			// 
			this.lab�˗���d�ʍl��.BackColor = System.Drawing.Color.Honeydew;
			this.lab�˗���d�ʍl��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�˗���d�ʍl��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�˗���d�ʍl��.Location = new System.Drawing.Point(18, 382);
			this.lab�˗���d�ʍl��.Name = "lab�˗���d�ʍl��";
			this.lab�˗���d�ʍl��.Size = new System.Drawing.Size(112, 14);
			this.lab�˗���d�ʍl��.TabIndex = 92;
			this.lab�˗���d�ʍl��.Text = "���˗���Œ�d��";
			// 
			// pnl�˗���d�ʍl��
			// 
			this.pnl�˗���d�ʍl��.Controls.Add(this.rBtn�˗���d�ʍl�����Ȃ�);
			this.pnl�˗���d�ʍl��.Controls.Add(this.rBtn�˗���d�ʍl������);
			this.pnl�˗���d�ʍl��.Location = new System.Drawing.Point(140, 376);
			this.pnl�˗���d�ʍl��.Name = "pnl�˗���d�ʍl��";
			this.pnl�˗���d�ʍl��.Size = new System.Drawing.Size(180, 24);
			this.pnl�˗���d�ʍl��.TabIndex = 91;
			// 
			// rBtn�˗���d�ʍl�����Ȃ�
			// 
			this.rBtn�˗���d�ʍl�����Ȃ�.Checked = true;
			this.rBtn�˗���d�ʍl�����Ȃ�.Location = new System.Drawing.Point(0, 0);
			this.rBtn�˗���d�ʍl�����Ȃ�.Name = "rBtn�˗���d�ʍl�����Ȃ�";
			this.rBtn�˗���d�ʍl�����Ȃ�.Size = new System.Drawing.Size(80, 24);
			this.rBtn�˗���d�ʍl�����Ȃ�.TabIndex = 1;
			this.rBtn�˗���d�ʍl�����Ȃ�.TabStop = true;
			this.rBtn�˗���d�ʍl�����Ȃ�.Text = "�g�p���Ȃ�";
			// 
			// rBtn�˗���d�ʍl������
			// 
			this.rBtn�˗���d�ʍl������.Location = new System.Drawing.Point(100, 0);
			this.rBtn�˗���d�ʍl������.Name = "rBtn�˗���d�ʍl������";
			this.rBtn�˗���d�ʍl������.Size = new System.Drawing.Size(80, 24);
			this.rBtn�˗���d�ʍl������.TabIndex = 2;
			this.rBtn�˗���d�ʍl������.Text = "�g�p����";
			// 
			// panel11
			// 
			this.panel11.Controls.Add(this.rBtn�ǎ�\������);
			this.panel11.Controls.Add(this.rBtn�ǎ�\�����Ȃ�);
			this.panel11.Location = new System.Drawing.Point(140, 400);
			this.panel11.Name = "panel11";
			this.panel11.Size = new System.Drawing.Size(180, 24);
			this.panel11.TabIndex = 12;
			// 
			// rBtn�ǎ�\������
			// 
			this.rBtn�ǎ�\������.Checked = true;
			this.rBtn�ǎ�\������.Location = new System.Drawing.Point(0, 0);
			this.rBtn�ǎ�\������.Name = "rBtn�ǎ�\������";
			this.rBtn�ǎ�\������.Size = new System.Drawing.Size(80, 24);
			this.rBtn�ǎ�\������.TabIndex = 1;
			this.rBtn�ǎ�\������.TabStop = true;
			this.rBtn�ǎ�\������.Text = "�\������";
			// 
			// rBtn�ǎ�\�����Ȃ�
			// 
			this.rBtn�ǎ�\�����Ȃ�.Location = new System.Drawing.Point(100, 0);
			this.rBtn�ǎ�\�����Ȃ�.Name = "rBtn�ǎ�\�����Ȃ�";
			this.rBtn�ǎ�\�����Ȃ�.Size = new System.Drawing.Size(80, 24);
			this.rBtn�ǎ�\�����Ȃ�.TabIndex = 2;
			this.rBtn�ǎ�\�����Ȃ�.Text = "�\�����Ȃ�";
			// 
			// lab�o�[�R�[�h�ǎ��p
			// 
			this.lab�o�[�R�[�h�ǎ��p.BackColor = System.Drawing.Color.Honeydew;
			this.lab�o�[�R�[�h�ǎ��p.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�o�[�R�[�h�ǎ��p.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�o�[�R�[�h�ǎ��p.Location = new System.Drawing.Point(16, 406);
			this.lab�o�[�R�[�h�ǎ��p.Name = "lab�o�[�R�[�h�ǎ��p";
			this.lab�o�[�R�[�h�ǎ��p.Size = new System.Drawing.Size(122, 14);
			this.lab�o�[�R�[�h�ǎ��p.TabIndex = 90;
			this.lab�o�[�R�[�h�ǎ��p.Text = "�ް���ޓǎ��p���";
			// 
			// lab�O�l��
			// 
			this.lab�O�l��.BackColor = System.Drawing.Color.Honeydew;
			this.lab�O�l��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�O�l��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�O�l��.Location = new System.Drawing.Point(18, 310);
			this.lab�O�l��.Name = "lab�O�l��";
			this.lab�O�l��.Size = new System.Drawing.Size(120, 14);
			this.lab�O�l��.TabIndex = 89;
			this.lab�O�l��.Text = "�Z���E�������̑O�l��";
			// 
			// pan�O�l��
			// 
			this.pan�O�l��.Controls.Add(this.rBtn�O�l�߂���);
			this.pan�O�l��.Controls.Add(this.rBtn�O�l�߂��Ȃ�);
			this.pan�O�l��.Location = new System.Drawing.Point(140, 304);
			this.pan�O�l��.Name = "pan�O�l��";
			this.pan�O�l��.Size = new System.Drawing.Size(180, 24);
			this.pan�O�l��.TabIndex = 9;
			// 
			// rBtn�O�l�߂���
			// 
			this.rBtn�O�l�߂���.Checked = true;
			this.rBtn�O�l�߂���.Location = new System.Drawing.Point(0, 0);
			this.rBtn�O�l�߂���.Name = "rBtn�O�l�߂���";
			this.rBtn�O�l�߂���.Size = new System.Drawing.Size(80, 24);
			this.rBtn�O�l�߂���.TabIndex = 1;
			this.rBtn�O�l�߂���.TabStop = true;
			this.rBtn�O�l�߂���.Text = "�O�l�߂���";
			// 
			// rBtn�O�l�߂��Ȃ�
			// 
			this.rBtn�O�l�߂��Ȃ�.Location = new System.Drawing.Point(100, 0);
			this.rBtn�O�l�߂��Ȃ�.Name = "rBtn�O�l�߂��Ȃ�";
			this.rBtn�O�l�߂��Ȃ�.Size = new System.Drawing.Size(80, 24);
			this.rBtn�O�l�߂��Ȃ�.TabIndex = 2;
			this.rBtn�O�l�߂��Ȃ�.Text = "���Ȃ�";
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Honeydew;
			this.label6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label6.ForeColor = System.Drawing.Color.LimeGreen;
			this.label6.Location = new System.Drawing.Point(18, 120);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 14);
			this.label6.TabIndex = 87;
			this.label6.Text = "���˗���R�[�h";
			// 
			// panel12
			// 
			this.panel12.Controls.Add(this.rBtn�˗�����͂���);
			this.panel12.Controls.Add(this.rBtn�˗�����͂��Ȃ�);
			this.panel12.Location = new System.Drawing.Point(140, 114);
			this.panel12.Name = "panel12";
			this.panel12.Size = new System.Drawing.Size(180, 24);
			this.panel12.TabIndex = 3;
			// 
			// rBtn�˗�����͂���
			// 
			this.rBtn�˗�����͂���.Checked = true;
			this.rBtn�˗�����͂���.Location = new System.Drawing.Point(0, 0);
			this.rBtn�˗�����͂���.Name = "rBtn�˗�����͂���";
			this.rBtn�˗�����͂���.Size = new System.Drawing.Size(80, 24);
			this.rBtn�˗�����͂���.TabIndex = 1;
			this.rBtn�˗�����͂���.TabStop = true;
			this.rBtn�˗�����͂���.Text = "���͂���";
			// 
			// rBtn�˗�����͂��Ȃ�
			// 
			this.rBtn�˗�����͂��Ȃ�.Location = new System.Drawing.Point(100, 0);
			this.rBtn�˗�����͂��Ȃ�.Name = "rBtn�˗�����͂��Ȃ�";
			this.rBtn�˗�����͂��Ȃ�.Size = new System.Drawing.Size(80, 24);
			this.rBtn�˗�����͂��Ȃ�.TabIndex = 2;
			this.rBtn�˗�����͂��Ȃ�.Text = "���͂��Ȃ�";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label4.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(0, 162);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(343, 22);
			this.label4.TabIndex = 85;
			this.label4.Text = "���̑�";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label3.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(0, 92);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(343, 22);
			this.label3.TabIndex = 84;
			this.label3.Text = "���˗���";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label2.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(343, 22);
			this.label2.TabIndex = 83;
			this.label2.Text = "���͂���";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel16
			// 
			this.panel16.Controls.Add(this.rBtn�ی����z����);
			this.panel16.Controls.Add(this.rBtn�ی����z���Ȃ�);
			this.panel16.Location = new System.Drawing.Point(140, 256);
			this.panel16.Name = "panel16";
			this.panel16.Size = new System.Drawing.Size(180, 24);
			this.panel16.TabIndex = 8;
			// 
			// rBtn�ی����z����
			// 
			this.rBtn�ی����z����.Checked = true;
			this.rBtn�ی����z����.Location = new System.Drawing.Point(0, 0);
			this.rBtn�ی����z����.Name = "rBtn�ی����z����";
			this.rBtn�ی����z����.Size = new System.Drawing.Size(80, 24);
			this.rBtn�ی����z����.TabIndex = 1;
			this.rBtn�ی����z����.TabStop = true;
			this.rBtn�ی����z����.Text = "���͂���";
			// 
			// rBtn�ی����z���Ȃ�
			// 
			this.rBtn�ی����z���Ȃ�.Location = new System.Drawing.Point(100, 0);
			this.rBtn�ی����z���Ȃ�.Name = "rBtn�ی����z���Ȃ�";
			this.rBtn�ی����z���Ȃ�.Size = new System.Drawing.Size(80, 24);
			this.rBtn�ی����z���Ȃ�.TabIndex = 2;
			this.rBtn�ی����z���Ȃ�.Text = "���͂��Ȃ�";
			// 
			// lab�ی����z
			// 
			this.lab�ی����z.BackColor = System.Drawing.Color.Honeydew;
			this.lab�ی����z.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�ی����z.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�ی����z.Location = new System.Drawing.Point(18, 262);
			this.lab�ی����z.Name = "lab�ی����z";
			this.lab�ی����z.Size = new System.Drawing.Size(100, 14);
			this.lab�ی����z.TabIndex = 81;
			this.lab�ی����z.Text = "�ی����z";
			// 
			// panel15
			// 
			this.panel15.Controls.Add(this.rBtn�d�ʓ���);
			this.panel15.Controls.Add(this.rBtn�ː�����);
			this.panel15.Location = new System.Drawing.Point(140, 352);
			this.panel15.Name = "panel15";
			this.panel15.Size = new System.Drawing.Size(180, 24);
			this.panel15.TabIndex = 11;
			this.panel15.Visible = false;
			// 
			// rBtn�d�ʓ���
			// 
			this.rBtn�d�ʓ���.Checked = true;
			this.rBtn�d�ʓ���.Location = new System.Drawing.Point(0, 0);
			this.rBtn�d�ʓ���.Name = "rBtn�d�ʓ���";
			this.rBtn�d�ʓ���.Size = new System.Drawing.Size(80, 24);
			this.rBtn�d�ʓ���.TabIndex = 1;
			this.rBtn�d�ʓ���.TabStop = true;
			this.rBtn�d�ʓ���.Text = "�d��";
			// 
			// rBtn�ː�����
			// 
			this.rBtn�ː�����.Location = new System.Drawing.Point(100, 0);
			this.rBtn�ː�����.Name = "rBtn�ː�����";
			this.rBtn�ː�����.Size = new System.Drawing.Size(80, 24);
			this.rBtn�ː�����.TabIndex = 2;
			this.rBtn�ː�����.Text = "�ː�";
			// 
			// lab�d�ʓ��͕��@
			// 
			this.lab�d�ʓ��͕��@.BackColor = System.Drawing.Color.Honeydew;
			this.lab�d�ʓ��͕��@.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�d�ʓ��͕��@.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�d�ʓ��͕��@.Location = new System.Drawing.Point(54, 358);
			this.lab�d�ʓ��͕��@.Name = "lab�d�ʓ��͕��@";
			this.lab�d�ʓ��͕��@.Size = new System.Drawing.Size(60, 14);
			this.lab�d�ʓ��͕��@.TabIndex = 79;
			this.lab�d�ʓ��͕��@.Text = "���͕��@";
			this.lab�d�ʓ��͕��@.Visible = false;
			// 
			// panel14
			// 
			this.panel14.Controls.Add(this.rBtn�d�ʂ���);
			this.panel14.Controls.Add(this.rBtn�d�ʂ��Ȃ�);
			this.panel14.Location = new System.Drawing.Point(140, 328);
			this.panel14.Name = "panel14";
			this.panel14.Size = new System.Drawing.Size(180, 24);
			this.panel14.TabIndex = 10;
			this.panel14.Visible = false;
			// 
			// rBtn�d�ʂ���
			// 
			this.rBtn�d�ʂ���.Checked = true;
			this.rBtn�d�ʂ���.Location = new System.Drawing.Point(0, 0);
			this.rBtn�d�ʂ���.Name = "rBtn�d�ʂ���";
			this.rBtn�d�ʂ���.Size = new System.Drawing.Size(80, 24);
			this.rBtn�d�ʂ���.TabIndex = 1;
			this.rBtn�d�ʂ���.TabStop = true;
			this.rBtn�d�ʂ���.Text = "���͂���";
			// 
			// rBtn�d�ʂ��Ȃ�
			// 
			this.rBtn�d�ʂ��Ȃ�.Location = new System.Drawing.Point(100, 0);
			this.rBtn�d�ʂ��Ȃ�.Name = "rBtn�d�ʂ��Ȃ�";
			this.rBtn�d�ʂ��Ȃ�.Size = new System.Drawing.Size(80, 24);
			this.rBtn�d�ʂ��Ȃ�.TabIndex = 2;
			this.rBtn�d�ʂ��Ȃ�.Text = "���͂��Ȃ�";
			// 
			// lab�d��
			// 
			this.lab�d��.BackColor = System.Drawing.Color.Honeydew;
			this.lab�d��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�d��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�d��.Location = new System.Drawing.Point(18, 334);
			this.lab�d��.Name = "lab�d��";
			this.lab�d��.Size = new System.Drawing.Size(100, 14);
			this.lab�d��.TabIndex = 77;
			this.lab�d��.Text = "�d��";
			this.lab�d��.Visible = false;
			// 
			// pnl�i���L���P
			// 
			this.pnl�i���L���P.Controls.Add(this.rBtn�i���L���P�Q�U�s);
			this.pnl�i���L���P.Controls.Add(this.rBtn�i���L���P���Ȃ�);
			this.pnl�i���L���P.Controls.Add(this.rBtn�i���L���P�Q�R�s);
			this.pnl�i���L���P.Location = new System.Drawing.Point(140, 232);
			this.pnl�i���L���P.Name = "pnl�i���L���P";
			this.pnl�i���L���P.Size = new System.Drawing.Size(180, 24);
			this.pnl�i���L���P.TabIndex = 7;
			// 
			// rBtn�i���L���P�Q�U�s
			// 
			this.rBtn�i���L���P�Q�U�s.Checked = true;
			this.rBtn�i���L���P�Q�U�s.Location = new System.Drawing.Point(0, 0);
			this.rBtn�i���L���P�Q�U�s.Name = "rBtn�i���L���P�Q�U�s";
			this.rBtn�i���L���P�Q�U�s.Size = new System.Drawing.Size(48, 24);
			this.rBtn�i���L���P�Q�U�s.TabIndex = 1;
			this.rBtn�i���L���P�Q�U�s.TabStop = true;
			this.rBtn�i���L���P�Q�U�s.Text = "�U�s";
			// 
			// rBtn�i���L���P���Ȃ�
			// 
			this.rBtn�i���L���P���Ȃ�.Location = new System.Drawing.Point(100, 0);
			this.rBtn�i���L���P���Ȃ�.Name = "rBtn�i���L���P���Ȃ�";
			this.rBtn�i���L���P���Ȃ�.Size = new System.Drawing.Size(80, 24);
			this.rBtn�i���L���P���Ȃ�.TabIndex = 2;
			this.rBtn�i���L���P���Ȃ�.Text = "���͂��Ȃ�";
			// 
			// rBtn�i���L���P�Q�R�s
			// 
			this.rBtn�i���L���P�Q�R�s.Location = new System.Drawing.Point(50, 0);
			this.rBtn�i���L���P�Q�R�s.Name = "rBtn�i���L���P�Q�R�s";
			this.rBtn�i���L���P�Q�R�s.Size = new System.Drawing.Size(48, 24);
			this.rBtn�i���L���P�Q�R�s.TabIndex = 3;
			this.rBtn�i���L���P�Q�R�s.Text = "�R�s";
			// 
			// lab�i���L���P
			// 
			this.lab�i���L���P.BackColor = System.Drawing.Color.Honeydew;
			this.lab�i���L���P.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�i���L���P.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�i���L���P.Location = new System.Drawing.Point(18, 238);
			this.lab�i���L���P.Name = "lab�i���L���P";
			this.lab�i���L���P.Size = new System.Drawing.Size(100, 14);
			this.lab�i���L���P.TabIndex = 71;
			this.lab�i���L���P.Text = "�L���E�i��";
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.rBtn�A�����i����);
			this.panel10.Controls.Add(this.rBtn�A�����i���Ȃ�);
			this.panel10.Location = new System.Drawing.Point(140, 208);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(180, 24);
			this.panel10.TabIndex = 6;
			// 
			// rBtn�A�����i����
			// 
			this.rBtn�A�����i����.Checked = true;
			this.rBtn�A�����i����.Location = new System.Drawing.Point(0, 0);
			this.rBtn�A�����i����.Name = "rBtn�A�����i����";
			this.rBtn�A�����i����.Size = new System.Drawing.Size(80, 24);
			this.rBtn�A�����i����.TabIndex = 1;
			this.rBtn�A�����i����.TabStop = true;
			this.rBtn�A�����i����.Text = "���͂���";
			// 
			// rBtn�A�����i���Ȃ�
			// 
			this.rBtn�A�����i���Ȃ�.Location = new System.Drawing.Point(100, 0);
			this.rBtn�A�����i���Ȃ�.Name = "rBtn�A�����i���Ȃ�";
			this.rBtn�A�����i���Ȃ�.Size = new System.Drawing.Size(80, 24);
			this.rBtn�A�����i���Ȃ�.TabIndex = 2;
			this.rBtn�A�����i���Ȃ�.Text = "���͂��Ȃ�";
			// 
			// lab�A�����i
			// 
			this.lab�A�����i.BackColor = System.Drawing.Color.Honeydew;
			this.lab�A�����i.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�A�����i.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�A�����i.Location = new System.Drawing.Point(18, 214);
			this.lab�A�����i.Name = "lab�A�����i";
			this.lab�A�����i.Size = new System.Drawing.Size(100, 14);
			this.lab�A�����i.TabIndex = 69;
			this.lab�A�����i.Text = "�A�����i";
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.rBtn���q�l�ԍ�����);
			this.panel9.Controls.Add(this.rBtn���q�l�ԍ����Ȃ�);
			this.panel9.Location = new System.Drawing.Point(140, 184);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(180, 24);
			this.panel9.TabIndex = 5;
			// 
			// rBtn���q�l�ԍ�����
			// 
			this.rBtn���q�l�ԍ�����.Checked = true;
			this.rBtn���q�l�ԍ�����.Location = new System.Drawing.Point(0, 0);
			this.rBtn���q�l�ԍ�����.Name = "rBtn���q�l�ԍ�����";
			this.rBtn���q�l�ԍ�����.Size = new System.Drawing.Size(80, 24);
			this.rBtn���q�l�ԍ�����.TabIndex = 1;
			this.rBtn���q�l�ԍ�����.TabStop = true;
			this.rBtn���q�l�ԍ�����.Text = "���͂���";
			// 
			// rBtn���q�l�ԍ����Ȃ�
			// 
			this.rBtn���q�l�ԍ����Ȃ�.Location = new System.Drawing.Point(100, 0);
			this.rBtn���q�l�ԍ����Ȃ�.Name = "rBtn���q�l�ԍ����Ȃ�";
			this.rBtn���q�l�ԍ����Ȃ�.Size = new System.Drawing.Size(80, 24);
			this.rBtn���q�l�ԍ����Ȃ�.TabIndex = 2;
			this.rBtn���q�l�ԍ����Ȃ�.Text = "���͂��Ȃ�";
			// 
			// lab���q�l�ԍ�
			// 
			this.lab���q�l�ԍ�.BackColor = System.Drawing.Color.Honeydew;
			this.lab���q�l�ԍ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���q�l�ԍ�.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���q�l�ԍ�.Location = new System.Drawing.Point(18, 190);
			this.lab���q�l�ԍ�.Name = "lab���q�l�ԍ�";
			this.lab���q�l�ԍ�.Size = new System.Drawing.Size(100, 14);
			this.lab���q�l�ԍ�.TabIndex = 67;
			this.lab���q�l�ԍ�.Text = "���q�l�ԍ�";
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.rBtn�S������);
			this.panel5.Controls.Add(this.rBtn�S�����Ȃ�);
			this.panel5.Location = new System.Drawing.Point(140, 138);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(180, 24);
			this.panel5.TabIndex = 4;
			// 
			// rBtn�S������
			// 
			this.rBtn�S������.Checked = true;
			this.rBtn�S������.Location = new System.Drawing.Point(0, 0);
			this.rBtn�S������.Name = "rBtn�S������";
			this.rBtn�S������.Size = new System.Drawing.Size(80, 24);
			this.rBtn�S������.TabIndex = 1;
			this.rBtn�S������.TabStop = true;
			this.rBtn�S������.Text = "���͂���";
			// 
			// rBtn�S�����Ȃ�
			// 
			this.rBtn�S�����Ȃ�.Location = new System.Drawing.Point(100, 0);
			this.rBtn�S�����Ȃ�.Name = "rBtn�S�����Ȃ�";
			this.rBtn�S�����Ȃ�.Size = new System.Drawing.Size(80, 24);
			this.rBtn�S�����Ȃ�.TabIndex = 2;
			this.rBtn�S�����Ȃ�.Text = "���͂��Ȃ�";
			// 
			// lab�S��
			// 
			this.lab�S��.BackColor = System.Drawing.Color.Honeydew;
			this.lab�S��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�S��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�S��.Location = new System.Drawing.Point(18, 144);
			this.lab�S��.Name = "lab�S��";
			this.lab�S��.Size = new System.Drawing.Size(100, 14);
			this.lab�S��.TabIndex = 65;
			this.lab�S��.Text = "�S��";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.rBtn�͂��於�O�Q����);
			this.panel4.Controls.Add(this.rBtn�͂��於�O�Q���Ȃ�);
			this.panel4.Location = new System.Drawing.Point(140, 68);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(180, 24);
			this.panel4.TabIndex = 2;
			// 
			// rBtn�͂��於�O�Q����
			// 
			this.rBtn�͂��於�O�Q����.Checked = true;
			this.rBtn�͂��於�O�Q����.Location = new System.Drawing.Point(0, 0);
			this.rBtn�͂��於�O�Q����.Name = "rBtn�͂��於�O�Q����";
			this.rBtn�͂��於�O�Q����.Size = new System.Drawing.Size(80, 24);
			this.rBtn�͂��於�O�Q����.TabIndex = 1;
			this.rBtn�͂��於�O�Q����.TabStop = true;
			this.rBtn�͂��於�O�Q����.Text = "���͂���";
			// 
			// rBtn�͂��於�O�Q���Ȃ�
			// 
			this.rBtn�͂��於�O�Q���Ȃ�.Location = new System.Drawing.Point(100, 0);
			this.rBtn�͂��於�O�Q���Ȃ�.Name = "rBtn�͂��於�O�Q���Ȃ�";
			this.rBtn�͂��於�O�Q���Ȃ�.Size = new System.Drawing.Size(80, 24);
			this.rBtn�͂��於�O�Q���Ȃ�.TabIndex = 2;
			this.rBtn�͂��於�O�Q���Ȃ�.Text = "���͂��Ȃ�";
			// 
			// lab�͂��於�O�Q
			// 
			this.lab�͂��於�O�Q.BackColor = System.Drawing.Color.Honeydew;
			this.lab�͂��於�O�Q.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�͂��於�O�Q.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�͂��於�O�Q.Location = new System.Drawing.Point(18, 74);
			this.lab�͂��於�O�Q.Name = "lab�͂��於�O�Q";
			this.lab�͂��於�O�Q.Size = new System.Drawing.Size(108, 14);
			this.lab�͂��於�O�Q.TabIndex = 63;
			this.lab�͂��於�O�Q.Text = "���͂��於�O�Q�s��";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.rBtn�͂���Z���R����);
			this.panel3.Controls.Add(this.rBtn�͂���Z���R���Ȃ�);
			this.panel3.Location = new System.Drawing.Point(140, 44);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(180, 24);
			this.panel3.TabIndex = 1;
			// 
			// rBtn�͂���Z���R����
			// 
			this.rBtn�͂���Z���R����.Checked = true;
			this.rBtn�͂���Z���R����.Location = new System.Drawing.Point(0, 0);
			this.rBtn�͂���Z���R����.Name = "rBtn�͂���Z���R����";
			this.rBtn�͂���Z���R����.Size = new System.Drawing.Size(80, 24);
			this.rBtn�͂���Z���R����.TabIndex = 1;
			this.rBtn�͂���Z���R����.TabStop = true;
			this.rBtn�͂���Z���R����.Text = "���͂���";
			// 
			// rBtn�͂���Z���R���Ȃ�
			// 
			this.rBtn�͂���Z���R���Ȃ�.Location = new System.Drawing.Point(100, 0);
			this.rBtn�͂���Z���R���Ȃ�.Name = "rBtn�͂���Z���R���Ȃ�";
			this.rBtn�͂���Z���R���Ȃ�.Size = new System.Drawing.Size(80, 24);
			this.rBtn�͂���Z���R���Ȃ�.TabIndex = 2;
			this.rBtn�͂���Z���R���Ȃ�.Text = "���͂��Ȃ�";
			// 
			// lab�͂���Z���R
			// 
			this.lab�͂���Z���R.BackColor = System.Drawing.Color.Honeydew;
			this.lab�͂���Z���R.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�͂���Z���R.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�͂���Z���R.Location = new System.Drawing.Point(88, 50);
			this.lab�͂���Z���R.Name = "lab�͂���Z���R";
			this.lab�͂���Z���R.Size = new System.Drawing.Size(38, 14);
			this.lab�͂���Z���R.TabIndex = 61;
			this.lab�͂���Z���R.Text = "�R�s��";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.rBtn�͂���Z���Q����);
			this.panel2.Controls.Add(this.rBtn�͂���Z���Q���Ȃ�);
			this.panel2.Location = new System.Drawing.Point(140, 22);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(180, 24);
			this.panel2.TabIndex = 0;
			// 
			// rBtn�͂���Z���Q����
			// 
			this.rBtn�͂���Z���Q����.Checked = true;
			this.rBtn�͂���Z���Q����.Location = new System.Drawing.Point(0, -2);
			this.rBtn�͂���Z���Q����.Name = "rBtn�͂���Z���Q����";
			this.rBtn�͂���Z���Q����.Size = new System.Drawing.Size(80, 24);
			this.rBtn�͂���Z���Q����.TabIndex = 1;
			this.rBtn�͂���Z���Q����.TabStop = true;
			this.rBtn�͂���Z���Q����.Text = "���͂���";
			// 
			// rBtn�͂���Z���Q���Ȃ�
			// 
			this.rBtn�͂���Z���Q���Ȃ�.Location = new System.Drawing.Point(100, -2);
			this.rBtn�͂���Z���Q���Ȃ�.Name = "rBtn�͂���Z���Q���Ȃ�";
			this.rBtn�͂���Z���Q���Ȃ�.Size = new System.Drawing.Size(80, 24);
			this.rBtn�͂���Z���Q���Ȃ�.TabIndex = 2;
			this.rBtn�͂���Z���Q���Ȃ�.Text = "���͂��Ȃ�";
			// 
			// lab�͂���Z���Q
			// 
			this.lab�͂���Z���Q.BackColor = System.Drawing.Color.Honeydew;
			this.lab�͂���Z���Q.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�͂���Z���Q.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�͂���Z���Q.Location = new System.Drawing.Point(18, 26);
			this.lab�͂���Z���Q.Name = "lab�͂���Z���Q";
			this.lab�͂���Z���Q.Size = new System.Drawing.Size(108, 14);
			this.lab�͂���Z���Q.TabIndex = 60;
			this.lab�͂���Z���Q.Text = "���͂���Z���Q�s��";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(0, 0);
			this.label5.Name = "label5";
			this.label5.TabIndex = 0;
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.PaleGreen;
			this.panel6.Location = new System.Drawing.Point(0, 26);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(810, 26);
			this.panel6.TabIndex = 12;
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.lab�ː��؂�ւ��^�C�g��);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(796, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab�ː��؂�ւ��^�C�g��
			// 
			this.lab�ː��؂�ւ��^�C�g��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�ː��؂�ւ��^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�ː��؂�ւ��^�C�g��.ForeColor = System.Drawing.Color.White;
			this.lab�ː��؂�ւ��^�C�g��.Location = new System.Drawing.Point(12, 2);
			this.lab�ː��؂�ւ��^�C�g��.Name = "lab�ː��؂�ւ��^�C�g��";
			this.lab�ː��؂�ւ��^�C�g��.Size = new System.Drawing.Size(264, 24);
			this.lab�ː��؂�ւ��^�C�g��.TabIndex = 0;
			this.lab�ː��؂�ւ��^�C�g��.Text = "�G���g���[�I�v�V����";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn�X�V);
			this.panel8.Controls.Add(this.tex���b�Z�[�W);
			this.panel8.Controls.Add(this.btn����);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(794, 58);
			this.panel8.TabIndex = 2;
			// 
			// btn�X�V
			// 
			this.btn�X�V.ForeColor = System.Drawing.Color.Blue;
			this.btn�X�V.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�X�V.Location = new System.Drawing.Point(70, 6);
			this.btn�X�V.Name = "btn�X�V";
			this.btn�X�V.Size = new System.Drawing.Size(54, 48);
			this.btn�X�V.TabIndex = 1;
			this.btn�X�V.Text = "�ۑ�";
			this.btn�X�V.Click += new System.EventHandler(this.btn�X�V_Click);
			// 
			// tex���b�Z�[�W
			// 
			this.tex���b�Z�[�W.BackColor = System.Drawing.Color.PaleGreen;
			this.tex���b�Z�[�W.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���b�Z�[�W.ForeColor = System.Drawing.Color.Red;
			this.tex���b�Z�[�W.Location = new System.Drawing.Point(130, 4);
			this.tex���b�Z�[�W.Multiline = true;
			this.tex���b�Z�[�W.Name = "tex���b�Z�[�W";
			this.tex���b�Z�[�W.ReadOnly = true;
			this.tex���b�Z�[�W.Size = new System.Drawing.Size(382, 50);
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
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.panel1);
			this.groupBox3.Location = new System.Drawing.Point(8, 54);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(780, 456);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			// 
			// pnl�ی����z�`�F�b�N
			// 
			this.pnl�ی����z�`�F�b�N.Controls.Add(this.rBtn�ی����z�`�F�b�N����);
			this.pnl�ی����z�`�F�b�N.Controls.Add(this.rBtn�ی����z�`�F�b�N���Ȃ�);
			this.pnl�ی����z�`�F�b�N.Location = new System.Drawing.Point(140, 280);
			this.pnl�ی����z�`�F�b�N.Name = "pnl�ی����z�`�F�b�N";
			this.pnl�ی����z�`�F�b�N.Size = new System.Drawing.Size(198, 24);
			this.pnl�ی����z�`�F�b�N.TabIndex = 93;
			// 
			// rBtn�ی����z�`�F�b�N����
			// 
			this.rBtn�ی����z�`�F�b�N����.Checked = true;
			this.rBtn�ی����z�`�F�b�N����.Location = new System.Drawing.Point(0, 0);
			this.rBtn�ی����z�`�F�b�N����.Name = "rBtn�ی����z�`�F�b�N����";
			this.rBtn�ی����z�`�F�b�N����.Size = new System.Drawing.Size(80, 24);
			this.rBtn�ی����z�`�F�b�N����.TabIndex = 1;
			this.rBtn�ی����z�`�F�b�N����.TabStop = true;
			this.rBtn�ی����z�`�F�b�N����.Text = "�`�F�b�N����";
			// 
			// rBtn�ی����z�`�F�b�N���Ȃ�
			// 
			this.rBtn�ی����z�`�F�b�N���Ȃ�.Location = new System.Drawing.Point(100, 0);
			this.rBtn�ی����z�`�F�b�N���Ȃ�.Name = "rBtn�ی����z�`�F�b�N���Ȃ�";
			this.rBtn�ی����z�`�F�b�N���Ȃ�.Size = new System.Drawing.Size(92, 24);
			this.rBtn�ی����z�`�F�b�N���Ȃ�.TabIndex = 2;
			this.rBtn�ی����z�`�F�b�N���Ȃ�.Text = "�`�F�b�N���Ȃ�";
			// 
			// lab�ی����z�`�F�b�N
			// 
			this.lab�ی����z�`�F�b�N.BackColor = System.Drawing.Color.Honeydew;
			this.lab�ی����z�`�F�b�N.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�ی����z�`�F�b�N.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�ی����z�`�F�b�N.Location = new System.Drawing.Point(18, 286);
			this.lab�ی����z�`�F�b�N.Name = "lab�ی����z�`�F�b�N";
			this.lab�ی����z�`�F�b�N.Size = new System.Drawing.Size(114, 14);
			this.lab�ی����z�`�F�b�N.TabIndex = 94;
			this.lab�ی����z�`�F�b�N.Text = "�ی����z���̓`�F�b�N";
			// 
			// �ː��؂�ւ�
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(794, 582);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "�ː��؂�ւ�";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 �G���g���[�I�v�V����";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
			this.Load += new System.EventHandler(this.�ː��؂�ւ�_Load);
			this.Closed += new System.EventHandler(this.�ː��؂�ւ�_Closed);
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).EndInit();
			this.panel1.ResumeLayout(false);
			this.grp�E��.ResumeLayout(false);
			this.pnl�b�r�u�o�͌`��.ResumeLayout(false);
			this.gpb�E.ResumeLayout(false);
			this.pnl���X��.ResumeLayout(false);
			this.pan�X�֔ԍ�.ResumeLayout(false);
			this.panel13.ResumeLayout(false);
			this.pn�׎�l�t�H���g�T�C�Y.ResumeLayout(false);
			this.pnl�׎�l�R�[�h.ResumeLayout(false);
			this.pnl�o�׎��шꗗ�\.ResumeLayout(false);
			this.gpb��.ResumeLayout(false);
			this.pnl�˗���d�ʍl��.ResumeLayout(false);
			this.panel11.ResumeLayout(false);
			this.pan�O�l��.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			this.panel16.ResumeLayout(false);
			this.panel15.ResumeLayout(false);
			this.panel14.ResumeLayout(false);
			this.pnl�i���L���P.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.pnl�ی����z�`�F�b�N.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		private void btn����_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void �ː��؂�ւ�_Load(object sender, System.EventArgs e)
		{
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
			s���䍀�ڂe�f = new string[s���䍀�ږ�.Length];
			s���䍀�ڗL�� = new string[s���䍀�ږ�.Length];
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� END
// MOD 2005.06.10 ���s�j�ɉ� ��ʐ��䍀�ڒǉ� START
//			try
//			{
//				��ʐ��䌟��(rBtn�͂���Z���Q����,rBtn�͂���Z���Q���Ȃ�,0);
//				��ʐ��䌟��(rBtn�͂���Z���R����,rBtn�͂���Z���R���Ȃ�,1);
//				��ʐ��䌟��(rBtn�͂��於�O�Q����,rBtn�͂��於�O�Q���Ȃ�,2);
//				��ʐ��䌟��(rBtn�S������,rBtn�S�����Ȃ�,3);
//				��ʐ��䌟��(rBtn���q�l�ԍ�����,rBtn���q�l�ԍ����Ȃ�,4);
//				��ʐ��䌟��(rBtn�A�����i����,rBtn�A�����i���Ȃ�,5);
//				��ʐ��䌟��(rBtn�i���L���P����,rBtn�i���L���P���Ȃ�,6);
//				��ʐ��䌟��(rBtn�d�ʂ���,rBtn�d�ʂ��Ȃ�,7);
//				��ʐ��䌟��(rBtn�d�ʓ���,rBtn�ː�����,8);
//				��ʐ��䌟��(rBtn�ی����z����,rBtn�ی����z���Ȃ�,9);
//			}
//			catch(Exception ex)
//			{
//				tex���b�Z�[�W.Text = ex.Message;
//			}
			��ʐ��䌟��();
			��ʐ���ݒ�(rBtn�͂���Z���Q����,rBtn�͂���Z���Q���Ȃ�,0);
			��ʐ���ݒ�(rBtn�͂���Z���R����,rBtn�͂���Z���R���Ȃ�,1);
			��ʐ���ݒ�(rBtn�͂��於�O�Q����,rBtn�͂��於�O�Q���Ȃ�,2);
			��ʐ���ݒ�(rBtn�S������,rBtn�S�����Ȃ�,3);
			��ʐ���ݒ�(rBtn���q�l�ԍ�����,rBtn���q�l�ԍ����Ȃ�,4);
			��ʐ���ݒ�(rBtn�A�����i����,rBtn�A�����i���Ȃ�,5);
// MOD 2011.08.05 ���s�j���� �L���s�̒ǉ��i�R�s�E�U�s�֑ؑΉ��j START
//			��ʐ���ݒ�(rBtn�i���L���P����,rBtn�i���L���P���Ȃ�,6);
			��ʐ���ݒ�p�l��(pnl�i���L���P,6);
// MOD 2011.08.05 ���s�j���� �L���s�̒ǉ��i�R�s�E�U�s�֑ؑΉ��j END
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� START
//			��ʐ���ݒ�(rBtn�d�ʂ���,rBtn�d�ʂ��Ȃ�,7);
//			��ʐ���ݒ�(rBtn�d�ʓ���,rBtn�ː�����,8);
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� END
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
			��ʐ���ݒ�(rBtn�d�ʂ���,rBtn�d�ʂ��Ȃ�,7);
			��ʐ���ݒ�(rBtn�d�ʓ���,rBtn�ː�����,8);
			if(gs�d�ʓ��͐��� == "1"){
				lab�d�ʓ��͕��@.Visible = true;
				panel14.Visible = true;
				lab�d��.Visible = true;
				panel15.Visible = true;
			}else{
				lab�d�ʓ��͕��@.Visible = false;
				panel14.Visible = false;
				lab�d��.Visible = false;
				panel15.Visible = false;
			}
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END
			��ʐ���ݒ�(rBtn�ی����z����,rBtn�ی����z���Ȃ�,9);
// MOD 2005.06.10 ���s�j�ɉ� ��ʐ��䍀�ڒǉ� END
// ADD 2006.06.28 ���s�j�R�{�@ �G���g���I�v�V�����̍��ڒǉ� START
			��ʐ���ݒ�(rBtn�˗�����͂���,rBtn�˗�����͂��Ȃ�,10);
// ADD 2006.06.28 ���s�j�R�{�@ �G���g���I�v�V�����̍��ڒǉ� END
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
			��ʐ���ݒ�(rBtn���x�����͂���b�c���Ȃ�,rBtn���x�����͂���b�c����,11);
			��ʐ���ݒ�(rBtn�o�׎��тW�s,rBtn�o�׎��тQ�s,12);
// MOD 2009.11.06 PSN�j����@�o�׎��шꗗ�\�Ή� START
//			��ʐ���ݒ�(rBtn�o�׎��ш˗�����ł���,rBtn�o�׎��ш˗�����łȂ�,13);
//			if(rBtn�o�׎��тV�s.Checked){
//				rBtn�o�׎��ш˗�����ł���.Visible = false;
//				rBtn�o�׎��ш˗�����łȂ�.Visible = false;
//			}
// MOD 2009.11.06 PSN�j����@�o�׎��шꗗ�\�Ή� END
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� END
// MOD 2009.10.23 PSN�j����@�I�v�V�����̍��ڒǉ� END
			��ʐ���ݒ�(rBtn�t�H���g�����g�傷��,rBtn�t�H���g�����g�債�Ȃ�,14);
// MOD 2009.10.23 PSN�j����@�I�v�V�����̍��ڒǉ� END
// MOD 2009.11.06 PSN�j����@�o�׎��шꗗ�\�Ή� START
			��ʐ���ݒ�(rBtn�Ж��󎚂��Ȃ�,rBtn�Ж��󎚂���,15);
// MOD 2009.11.06 PSN�j����@�o�׎��шꗗ�\�Ή� END
// MOD 2010.02.01 ���s�j���� �I�v�V�����̍��ڒǉ��i�b�r�u�o�͌`���jSTART
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
//			��ʐ���ݒ�(rBtn�o�ׂb�r�u�W��,rBtn�o�ׂb�r�u�G���g���[,16);
			��ʐ���ݒ�p�l��(pnl�b�r�u�o�͌`��,16);
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
// MOD 2010.02.01 ���s�j���� �I�v�V�����̍��ڒǉ��i�b�r�u�o�͌`���jEND
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
			��ʐ���ݒ�(rBtn�O�l�߂���,rBtn�O�l�߂��Ȃ�,17);
			��ʐ���ݒ�(rBtn���x���X�֔ԍ�����,rBtn���x���X�֔ԍ����Ȃ�,18);
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
// MOD 2011.03.08 ���s�j���� ���q�^���Ή� START
			if(gs����b�c.Substring(0,1) != "J"){
				label11.Text = "���R�ʉ^�Ж�";
			}else{
				label11.Text = "���q�^���Ж�";
			}
// MOD 2011.03.08 ���s�j���� ���q�^���Ή� END
// MOD 2012.04.10 ���s�j���� ���x�����X���̈󎚐���Ή� START
			��ʐ���ݒ�(rBtn���x�����X������,rBtn���x�����X�����Ȃ�,20);
// MOD 2012.04.10 ���s�j���� ���x�����X���̈󎚐���Ή� END
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� START
			��ʐ���ݒ�(rBtn�ǎ�\������,rBtn�ǎ�\�����Ȃ�,21);
			if(s���䍀�ڂe�f[21].Equals("9"))
			{
				//�f�t�H���g(��AM04��ʐ���ɊY�����R�[�h�����݂��Ȃ��ꍇ)�ł̃`�F�b�N�́A�u�\�����Ȃ��v�̕��Ƀ`�F�b�N
				rBtn�ǎ�\������.Checked = false;
				rBtn�ǎ�\�����Ȃ�.Checked = true;
			}
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� END
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� START
			��ʐ���ݒ�(rBtn�˗���d�ʍl�����Ȃ�,rBtn�˗���d�ʍl������,22);
			if(gs�d�ʓ��͐��� == "1")
			{
				lab�˗���d�ʍl��.Visible = true;
				pnl�˗���d�ʍl��.Visible = true;
			}
			else
			{
				lab�˗���d�ʍl��.Visible = false;
				pnl�˗���d�ʍl��.Visible = false;
			}
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
// MOD 2016.06.10 BEVAS�j���{ �ی������̓`�F�b�N�@�\�̒ǉ� START
			��ʐ���ݒ�(rBtn�ی����z�`�F�b�N����,rBtn�ی����z�`�F�b�N���Ȃ�,23);
			//�u�ی����z�v���ڂ��w���͂���x�Ƀ`�F�b�N�������Ă���ꍇ�A�u�ی����z���̓`�F�b�N�v���ڂ�\������
			if(rBtn�ی����z����.Checked)
			{
				lab�ی����z�`�F�b�N.Visible = true;
				pnl�ی����z�`�F�b�N.Visible = true;
			}
			else
			{
				lab�ی����z�`�F�b�N.Visible = false;
				pnl�ی����z�`�F�b�N.Visible = false;
			}
// MOD 2016.06.10 BEVAS�j���{ �ی������̓`�F�b�N�@�\�̒ǉ� END
		}
// ADD 2005.06.10 ���s�j�ɉ� ��ʐ��䍀�ڒǉ� START
		private void ��ʐ��䌟��()
		{
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sList = {""};
			try
			{
				tex���b�Z�[�W.Text = "�������D�D�D";
				if(sv_init == null) sv_init = new is2init.Service1();
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
//				sList = sv_init.Get_seigyo(gsa���[�U,gs����b�c,gs����b�c);
				sList = sv_init.Get_seigyo2(gsa���[�U,gs����b�c,gs����b�c, s���䍀�ڂe�f.Length);
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� END
			}
			catch (System.Net.WebException)
			{
				sList[0] = gs�ʐM�G���[;
				return;
			}
			catch (Exception ex)
			{
				sList[0] = "�ʐM�G���[�F" + ex.Message;
				return;
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;

			tex���b�Z�[�W.Text = "";

			if(sList[0].Length == 4)
			{
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
//				for (int iCnt = 1; iCnt < sList.Length; iCnt++)
				int iCnt = 1;
				for (; iCnt-1 < s���䍀�ڂe�f.Length && iCnt < sList.Length; iCnt++)
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� END
				{
					s���䍀�ڂe�f[iCnt-1] = sList[iCnt];
				}
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
				for (; iCnt-1 < s���䍀�ڂe�f.Length; iCnt++)
				{
					s���䍀�ڂe�f[iCnt-1] = "9";
				}
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� END
			}
			else
			{
				tex���b�Z�[�W.Text = sList[0];
				�r�[�v��();
			}
			return;
		}
		private void ��ʐ���ݒ�(System.Windows.Forms.RadioButton rBtn���ڂP, System.Windows.Forms.RadioButton rBtn���ڂQ, int iCnt)
		{
			if(s���䍀�ڂe�f[iCnt].Equals("9"))
			{
				rBtn���ڂP.Checked = true;
				rBtn���ڂQ.Checked = false;
				s���䍀�ڗL��[iCnt] = "0";
			}
			else
			{
				if(s���䍀�ڂe�f[iCnt].Equals("0"))
				{
					rBtn���ڂP.Checked = true;
					rBtn���ڂQ.Checked = false;
				}
				else
				{
					rBtn���ڂP.Checked = false;
					rBtn���ڂQ.Checked = true;
				}
				s���䍀�ڗL��[iCnt] = "1";
			}
		}
// ADD 2005.06.10 ���s�j�ɉ� ��ʐ��䍀�ڒǉ� END
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
		private void ��ʐ���ݒ�p�l��(Panel pnl����, int iCnt)
		{
			if(s���䍀�ڂe�f[iCnt].Equals("9")){
				foreach(object obj in pnl����.Controls){
					if(obj is RadioButton){
						RadioButton rBtn���� = (RadioButton)obj;
						if(rBtn����.TabIndex == 1){
							rBtn����.Checked = true;
							break;
						}
					}
				}
				s���䍀�ڗL��[iCnt] = "0";
			}else{
				foreach(object obj in pnl����.Controls){
					if(obj is RadioButton){
						RadioButton rBtn���� = (RadioButton)obj;
						if((rBtn����.TabIndex - 1).ToString() == s���䍀�ڂe�f[iCnt]){
							rBtn����.Checked = true;
							break;
						}
					}
				}
				s���䍀�ڗL��[iCnt] = "1";
			}
		}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END

// DEL 2005.06.10 ���s�j�ɉ� ��ʐ��䍀�ڒǉ� START
/*
		private void ��ʐ��䌟��(System.Windows.Forms.RadioButton rBtn���ڂP, System.Windows.Forms.RadioButton rBtn���ڂQ, int iCnt)
		{
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sList = {""};
			try
			{
				tex���b�Z�[�W.Text = "�������D�D�D";
				if(sv_init == null) sv_init = new is2init.Service1();
//				sList = sv_init.Get_seigyo(gsa���[�U,gs����b�c,gs����b�c,(iCnt+1).ToString());
			}
			catch (System.Net.WebException)
			{
				sList[0] = gs�ʐM�G���[;
				throw new Exception(sList[0]);
			}
			catch (Exception ex)
			{
				sList[0] = "�ʐM�G���[�F" + ex.Message;
				throw new Exception(sList[0]);
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;

			tex���b�Z�[�W.Text = "";

			// �ُ�I����
			if(sList[0].Length == 1)
			{
				if(sList[0].Equals("9"))
				{
					rBtn���ڂP.Checked = true;
					rBtn���ڂQ.Checked = false;
					s���䍀�ڗL��[iCnt] = "0";
				}
				else
				{
					if(sList[0].Equals("0"))
					{
						rBtn���ڂP.Checked = true;
						rBtn���ڂQ.Checked = false;
					}
					else
					{
						rBtn���ڂP.Checked = false;
						rBtn���ڂQ.Checked = true;
					}
					s���䍀�ڗL��[iCnt] = "1";
				}
			}
			else
			{
				tex���b�Z�[�W.Text = sList[0];
				�r�[�v��();
				throw new Exception(sList[0]);
			}
		}
*/
// DEL 2005.06.10 ���s�j�ɉ� ��ʐ��䍀�ڒǉ� END

		private void btn�X�V_Click(object sender, System.EventArgs e)
		{
			try
			{
				��ʐ���X�V(rBtn�͂���Z���Q����,0);
				��ʐ���X�V(rBtn�͂���Z���R����,1);
				��ʐ���X�V(rBtn�͂��於�O�Q����,2);
				��ʐ���X�V(rBtn�S������,3);
				��ʐ���X�V(rBtn���q�l�ԍ�����,4);
				��ʐ���X�V(rBtn�A�����i����,5);
// MOD 2011.08.05 ���s�j���� �L���s�̒ǉ��i�R�s�E�U�s�֑ؑΉ��j START
//				��ʐ���X�V(rBtn�i���L���P����,6);
				��ʐ���X�V�p�l��(pnl�i���L���P,6);
// MOD 2011.08.05 ���s�j���� �L���s�̒ǉ��i�R�s�E�U�s�֑ؑΉ��j END
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� START
//				��ʐ���X�V(rBtn�d�ʂ���,7);
//				��ʐ���X�V(rBtn�d�ʓ���,8);
// MOD 2011.04.13 ���s�j���� �d�ʓ��͕s�Ή� END
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
				��ʐ���X�V(rBtn�d�ʂ���,7);
				��ʐ���X�V(rBtn�d�ʓ���,8);
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END
				��ʐ���X�V(rBtn�ی����z����,9);
// ADD 2006.06.28 ���s�j�R�{�@ �G���g���I�v�V�����̍��ڒǉ� START
				��ʐ���X�V(rBtn�˗�����͂���,10);
// ADD 2006.06.28 ���s�j�R�{�@ �G���g���I�v�V�����̍��ڒǉ� END
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
				��ʐ���X�V(rBtn���x�����͂���b�c���Ȃ�,11);
				��ʐ���X�V(rBtn�o�׎��тW�s,12);
// MOD 2009.11.06 PSN�j����@�o�׎��шꗗ�\�Ή� START
//				��ʐ���X�V(rBtn�o�׎��ш˗�����ł���,13);
// MOD 2009.11.06 PSN�j����@�o�׎��шꗗ�\�Ή� END
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� END

// MOD 2009.10.23 PSN�j����@�I�v�V�����̍��ڒǉ� START
				��ʐ���X�V(rBtn�t�H���g�����g�傷��,14);
// MOD 2009.10.23 PSN�j����@�I�v�V�����̍��ڒǉ� END
// MOD 2009.11.06 PSN�j����@�o�׎��шꗗ�\�Ή� START
				��ʐ���X�V(rBtn�Ж��󎚂��Ȃ�,15);
// MOD 2009.11.06 PSN�j����@�o�׎��шꗗ�\�Ή� END
// MOD 2010.02.01 ���s�j���� �I�v�V�����̍��ڒǉ��i�b�r�u�o�͌`���jSTART
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
//				��ʐ���X�V(rBtn�o�ׂb�r�u�W��,16);
				��ʐ���X�V�p�l��(pnl�b�r�u�o�͌`��,16);
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
// MOD 2010.02.01 ���s�j���� �I�v�V�����̍��ڒǉ��i�b�r�u�o�͌`���jEND
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
				��ʐ���X�V(rBtn�O�l�߂���,17);
				��ʐ���X�V(rBtn���x���X�֔ԍ�����,18);
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
// MOD 2012.04.10 ���s�j���� ���x�����X���̈󎚐���Ή� START
				��ʐ���X�V(rBtn���x�����X������,20);
// MOD 2012.04.10 ���s�j���� ���x�����X���̈󎚐���Ή� END
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� START
				��ʐ���X�V(rBtn�ǎ�\������,21);
// ADD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ� END
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� START
				��ʐ���X�V(rBtn�˗���d�ʍl�����Ȃ�,22);
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
// MOD 2016.06.10 BEVAS�j���{ �ی������̓`�F�b�N�@�\�̒ǉ� START
				��ʐ���X�V(rBtn�ی����z�`�F�b�N����,23);
// MOD 2016.06.10 BEVAS�j���{ �ی������̓`�F�b�N�@�\�̒ǉ� END
				this.Close();
			}
			catch(Exception ex)
			{
				tex���b�Z�[�W.Text = ex.Message;
			}
		}


		private void ��ʐ���X�V(System.Windows.Forms.RadioButton rBtn����, int iCnt)
		{
			// �f�[�^�쐬
			String[] sKey = new string[7];
			sKey[0] = gs����b�c;
			sKey[1] = gs����b�c;
			sKey[2] = (iCnt + 1).ToString();
			sKey[3] = s���䍀�ږ�[iCnt];

			if(rBtn����.Checked)
				sKey[4] = "0"; // ���͂���
			else
				sKey[4] = "1"; // ���͂��Ȃ�

			sKey[5] = "��ʐ���";
			sKey[6] = gs���p�҂b�c;

			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string sRet = "";
			try
			{
				if(s���䍀�ڗL��[iCnt].Equals("0"))
				{
					tex���b�Z�[�W.Text = "�o�^���D�D�D";
					if(sv_init == null) sv_init = new is2init.Service1();
					sRet = sv_init.Ins_seigyo(gsa���[�U,sKey);
				}
				else
				{
					tex���b�Z�[�W.Text = "�X�V���D�D�D";
					if(sv_init == null) sv_init = new is2init.Service1();
					sRet = sv_init.Upd_seigyo(gsa���[�U,sKey);
				}
			}
			catch (System.Net.WebException)
			{
				sRet = gs�ʐM�G���[;
				throw new Exception(sRet);
			}
			catch (Exception ex)
			{
				sRet = "�ʐM�G���[�F" + ex.Message;
				throw new Exception(sRet);
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;
			tex���b�Z�[�W.Text = sRet;
			// ����I����
			if(sRet.Length == 4)
			{
				tex���b�Z�[�W.Text = "";
			}
			else
			{
				�r�[�v��();
				throw new Exception(sRet);
			}
		}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
		private void ��ʐ���X�V�p�l��(Panel pnl����, int iCnt)
		{
			// �f�[�^�쐬
			String[] sKey = new string[7];
			sKey[0] = gs����b�c;
			sKey[1] = gs����b�c;
			sKey[2] = (iCnt + 1).ToString();
			sKey[3] = s���䍀�ږ�[iCnt];

			foreach(object obj in pnl����.Controls){
				if(obj is RadioButton){
					RadioButton rBtn���� = (RadioButton)obj;
					if(rBtn����.Checked){
						sKey[4] = (rBtn����.TabIndex - 1).ToString();
						break;
					}
				}
			}

			sKey[5] = "��ʐ���";
			sKey[6] = gs���p�҂b�c;

			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string sRet = "";
			try
			{
				if(s���䍀�ڗL��[iCnt].Equals("0"))
				{
					tex���b�Z�[�W.Text = "�o�^���D�D�D";
					if(sv_init == null) sv_init = new is2init.Service1();
					sRet = sv_init.Ins_seigyo(gsa���[�U,sKey);
				}
				else
				{
					tex���b�Z�[�W.Text = "�X�V���D�D�D";
					if(sv_init == null) sv_init = new is2init.Service1();
					sRet = sv_init.Upd_seigyo(gsa���[�U,sKey);
				}
			}
			catch (System.Net.WebException)
			{
				sRet = gs�ʐM�G���[;
				throw new Exception(sRet);
			}
			catch (Exception ex)
			{
				sRet = "�ʐM�G���[�F" + ex.Message;
				throw new Exception(sRet);
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;
			tex���b�Z�[�W.Text = sRet;
			// ����I����
			if(sRet.Length == 4)
			{
				tex���b�Z�[�W.Text = "";
			}
			else
			{
				�r�[�v��();
				throw new Exception(sRet);
			}
		}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END

		private void �ː��؂�ւ�_Closed(object sender, System.EventArgs e)
		{
			tex���b�Z�[�W.Text = "";
			if(rBtn�͂���Z���Q����.Checked)
				rBtn�͂���Z���Q����.Focus();
			else
				rBtn�͂���Z���Q���Ȃ�.Focus();
		}

// MOD 2006.12.14 ���s�j�����J ���͐�S���폜�ǉ� START
		private void btn�폜_Click(object sender, System.EventArgs e)
		{
			DialogResult result;

			if (g���O�C���Q == null)	 g���O�C���Q = new ���O�C���Q();
			g���O�C���Q.b�폜���O�C�� = false;
			g���O�C���Q.ShowDialog(this);

			if(!g���O�C���Q.b�폜���O�C��) return;

			result = MessageBox.Show("���͐����S�č폜���܂����H","�S���폜",MessageBoxButtons.YesNo);
			if(result == DialogResult.Yes)
			{
				// �J�[�\���������v�ɂ���
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				String[] sDList = {""};
				string[] sData = new string[4];
				try
				{
					tex���b�Z�[�W.Text = "�폜���D�D�D";
					sData[0] = gs����b�c;
					sData[1] = gs����b�c;
					sData[2] = "��ʐ���";
					sData[3] = gs���p�҂b�c;

					Cursor = System.Windows.Forms.Cursors.AppStarting;

					if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
					sDList = sv_otodoke.Del_todokesaki3(gsa���[�U,sData);
					tex���b�Z�[�W.Text = sDList[0];
					Cursor = System.Windows.Forms.Cursors.Default;
					// [����I��]���A��ʂ��N���A����
					if(sDList[0].Length != 4)
					{
						�r�[�v��();
						return;
					}
				}
				catch (System.Net.WebException)
				{
					sDList[0] = gs�ʐM�G���[;
					Cursor = System.Windows.Forms.Cursors.Default;
					tex���b�Z�[�W.Text = sDList[0];
					�r�[�v��();
				}
				catch (Exception ex)
				{
					sDList[0] = "�ʐM�G���[�F" + ex.Message;
					Cursor = System.Windows.Forms.Cursors.Default;
					tex���b�Z�[�W.Text = sDList[0];
					�r�[�v��();
				}
			}
		}

// MOD 2006.12.14 ���s�j�����J ���͐�S���폜�ǉ� END

// MOD 2009.11.06 PSN�j����@�o�׎��шꗗ�\�Ή� START
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
//		private void rBtn�o�׎��тV�s_CheckedChanged(object sender, System.EventArgs e)
//		{
//			rBtn�o�׎��ш˗�����ł���.Visible = false;
//			rBtn�o�׎��ш˗�����łȂ�.Visible = false;
//		}

//		private void rBtn�o�׎��тQ�s_CheckedChanged(object sender, System.EventArgs e)
//		{
//			rBtn�o�׎��ш˗�����ł���.Visible = true;
//			rBtn�o�׎��ш˗�����łȂ�.Visible = true;
//		}
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� END
// MOD 2009.11.06 PSN�j����@�o�׎��шꗗ�\�Ή� END
	}
}
