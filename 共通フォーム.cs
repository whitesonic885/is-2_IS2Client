using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Runtime.InteropServices;

namespace IS2Client
{
	/// <summary>
	/// [���ʃt�H�[��]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// ADD 2008.03.13 ���s�j���� Vista�Ή� 
	// ADD 2008.03.19 ���s�j���� �ʍĔ��s�@�\�̒ǉ� 
	// ADD 2008.04.11 ACT Vista�Ή� 
	//�ۗ� ADD 2008.06.12 ���s�j���� �s�d�b���v�����^�Ή� 
	// ADD 2008.06.17 ���s�j���� �Z���P��[�_][�a][��]�Ŏn�܂肩�R���������̏ꍇ�̑Ή� 
	//--------------------------------------------------------------------------
	//�ۗ� DEL 2009.02.06 ���s�j���� ���x���p���T�C�Y��`�`�F�b�N�̔p�~
	// �@�y�d�a�q�`�����x���v�����^�����ōs���Ă���
	// ADD 2009.04.02 ���s�j���� �ғ����Ή� 
	// ADD 2009.04.07 ���s�j���� ���X�b�c[000]�Ή� 
	// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� 
	// ADD 2009.07.29 ���s�j���� �v���L�V�Ή� 
	// �@�h�d��[Secure]�̐ݒ肩����擾����
	// �@�v���L�V�����[�U���ݒ�ł���悤�ɂ���
	// MOD 2009.11.04 ���s�j���� ���͂���b�c�ɋL��[+]�𗘗p�\�ɂ��� 
	// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� 
	//                           �i�r�r�Ƃ̋��ʎd�l�ׁ̈A�ꉞ���킹��j
	// MOD 2009.11.06 PSN�j����@�I�v�V�����̍��ڒǉ�
	// MOD 2009.11.09 PSN�j����@�I�v�V�����̍��ڒǉ�
	// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� 
	// MOD 2009.12.01 ���s�j���� �S�p���p���݉\�ɂ��� 
	// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� 
	//--------------------------------------------------------------------------
	// MOD 2010.01.15 ���s�j���� �������J�b�g�̃��b�Z�[�W�̕ύX 
	// MOD 2010.02.01 ���s�j���� �I�v�V�����̍��ڒǉ��i�b�r�u�o�͌`���j
	// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� 
	// MOD 2010.03.12 ���s�j���� �P�O�O�O�O���`�F�b�N�����@�\�̒ǉ� 
	// MOD 2010.03.17 ���s�j���� �׎�l�d�b�ԍ���ALL0�ł���Δ�\�� 
	// MOD 2010.03.17 ���s�j���� �o�ד��̏o�ד��̔N���S���\���ɂ��� 
	// MOD 2010.03.18 ���s�j���� �׎�l�Z���̓s���{���Ǝs��S����؂�Ȃ� 
	// MOD 2010.03.19 ���s�j���� ������̎w��i���Ή��P�j 
	// MOD 2010.03.30 ���s�j���� �׎�l�d�b�ԍ���0�ł���Δ�\�� 
	// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� 
	// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� 
	// MOD 2010.04.16 ���s�j���� ���W���[���ă_�E�����[�h 
	// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� 
	// MOD 2010.06.01 ���s�j���� �t�@�C���o�͎��̉��s�̕ύX 
	// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� 
	// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j 
	// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� 
	// MOD 2010.08.27 ���s�j���� ���˗���捞�i�b�r�u�j�@�\�ǉ� 
	// MOD 2010.11.01 ���s�j���� �o�׍ς̏ꍇ�A�o�ד����X�V 
	// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX 
	// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) 
	// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� 
	//--------------------------------------------------------------------------
	// MOD 2011.01.06 ���s�j���� �X�֔ԍ��̈�� 
	// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� 
	// MOD 2011.01.25 ���s�j���� �u���[�h�Ɏ��s�v�Ή� 
	// MOD 2010.02.28 ���s�j���� ���q�^���̑Ή� 
	// MOD 2011.03.03 ���s�j���� �v�����^���Ƃ̕␳�Ή� 
	// MOD 2011.04.26 ���s�j���� �v�����^���Ƃ̕␳�Ή� 
	// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� 
	// MOD 2011.05.09 ���s�j���� �G�R�[�����ł̃I�v�V�����̃}�[�W 
	// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� 
	// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� 
	// MOD 2011.07.28 ���s�j���� �L���s�̒ǉ��i���͐����̒ǉ��j 
	// MOD 2011.10.11 ���s�j���� �r�r�k�ؖ���������ԂȂǂ̃`�F�b�N 
	// MOD 2011.12.06 ���s�j���� ���x���w�b�_���ɔ��X���E���X������ 
	// MOD 2011.12.08 ���s�j���� �Z���E���O�̔��p���͉� 
	// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� 
	// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� 
	//--------------------------------------------------------------------------
	// MOD 2012.04.10 ���s�j���� ���x�����X���̈󎚐���Ή� 
	//--------------------------------------------------------------------------
	// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή�
	// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή�
	// MOD 2013.10.22 BEVAS�j���� �r�`�s�n���v�����^(CS408T)�v�����^���������Ή�
	//--------------------------------------------------------------------------
	// MOD 2015.02.12 BEVAS�j�O�c �s�d�b���v�����^(B-LV4)�Ή�
	// ADD 2015.03.05 BEVAS�j�O�c �x�X�~�ߋ@�\�ǉ��Ή�
	// MOD 2015.04.13 BEVAS) �O�c�@�����o�͊Ԋu�b�Ή� 
	// MOD 2015.05.07 BEVAS) �O�c ���qCM14J�X�֔ԍ����݃`�F�b�N�Ή�
	// MOD 2015.07.13 TDI) �j�V �o�[�R�[�h�ǎ��p��ʒǉ� 
	// MOD 2015.07.13 BEVAS) ���{ �o�[�R�[�h�ǎ��p��ʒǉ�
	// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ�
	//--------------------------------------------------------------------------
	// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ�
	// MOD 2016.04.13 BEVAS�j���{ �z�B�w�������̊g��
	// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή�
	// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ�
	// MOD 2016.06.10 BEVAS�j���{ �ی������̓`�F�b�N�@�\�̒ǉ��i31���~�ȏ�̏ꍇ�j
	//--------------------------------------------------------------------------
	public class ���ʃt�H�[�� : System.Windows.Forms.Form
	{
// ADD 2005.07.11 ���s�j�����J ������̐��� START
		protected static int i����� = 0;
// ADD 2005.07.11 ���s�j�����J ������̐��� END

		protected static String gsInitFile = System.Environment.SystemDirectory
										  + "\\wis2.dll";
// ADD 2009.07.29 ���s�j���� �v���L�V�Ή� START
		protected static String gsInitProxy = AppDomain.CurrentDomain.BaseDirectory
										  + "proxy.ini";
		protected static bool gbInitProxyExists = false;
// ADD 2009.07.29 ���s�j���� �v���L�V�Ή� END
// MOD 2011.10.11 ���s�j���� �r�r�k�ؖ���������ԂȂǂ̃`�F�b�N START
		protected static bool gbInitSyukkaExists = false;
		protected static string gsOSVer  = "";
		protected static string gsNetVer = "";
		protected static string gsSSLStatus = "";
// MOD 2011.10.11 ���s�j���� �r�r�k�ؖ���������ԂȂǂ̃`�F�b�N END
// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� START
		protected static String gsInitKiji = AppDomain.CurrentDomain.BaseDirectory
										  + "kiji.ini";
// MOD 2009.11.04 ���s�j���� �L���̌Œ���e��[�����Ƃɕۑ� END
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� START
		protected static String gsInitClient = AppDomain.CurrentDomain.BaseDirectory
										  + "IS2Client.ini";
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� END
// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� START
		protected static String gsInitSyukka = AppDomain.CurrentDomain.BaseDirectory
										  + "syukka.ini";
		protected static String gsPathSyukka = AppDomain.CurrentDomain.BaseDirectory
										  + "Syukka";
		protected static String gsPathSyukkaIn  = gsPathSyukka + "\\In";
		protected static String gsPathSyukkaOut = gsPathSyukka + "\\Out";
		protected static String gsPathSyukkaLog = gsPathSyukka + "\\Log";
		protected static bool gb�����o�͂n�m = false;
		protected static int  gi�����o�̓^�C�}�[ = 3;
// ADD 2015.04.13 BEVAS)�O�c �����o�̓^�C�}�[�@�b�P�ʎw��Ή� START
		protected static int  gi�����o�̓^�C�}�[�b = 0;
// ADD 2015.04.13 BEVAS)�O�c �����o�̓^�C�}�[�@�b�P�ʎw��Ή� END

// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� END
// MOD 2010.04.16 ���s�j���� ���W���[���ă_�E�����[�h START
		protected static String gsFlagIS2Client = AppDomain.CurrentDomain.BaseDirectory
										  + "zs2Client.txt";
// MOD 2010.04.16 ���s�j���� ���W���[���ă_�E�����[�h END
// ADD 2008.03.13 ���s�j���� Vista�Ή� START
		protected static bool gbInitFileExt = false;
// ADD 2008.03.13 ���s�j���� Vista�Ή� END
		protected static String gs�A�v���t�H���_ = "";

		protected static string[] gsa����
			= { "",												// �s���{���b�c
				  "�k�C��","�X��","��茧","�{�錧","�H�c��",		// 01 -
				  "�R�`��","������","��錧","�Ȗ،�","�Q�n��",		//    - 10
				  "��ʌ�","��t��","�����s","�_�ސ쌧","�V����",	// 11 -
				  "�x�R��","�ΐ쌧","���䌧","�R����","���쌧",		//    - 20
				  "�򕌌�","�É���","���m��","�O�d��","���ꌧ",		// 21 -
				  "���s�{","���{","���Ɍ�","�ޗǌ�","�a�̎R��",	//    - 30
				  "���挧","������","���R��","�L����","�R����",		// 31 -
				  "������","���쌧","���Q��","���m��","������",		//    - 39
				  "���ꌧ","���茧","�F�{��","�啪��","�{�茧",		// 41 -
				  "��������","���ꌧ"								//    - 
			  };
// ADD 2005.06.07 ���s�j���� �s���{���I���̕ύX START
		protected static int      gi�s���{���b�c = 0;
// ADD 2005.06.07 ���s�j���� �s���{���I���̕ύX END
		protected static string[] gsa�s��S
			= { "�s���s","�s��s","���s�s","�]�s�S","���S�s",
				  "�S��s","���S�s","�S�R�s","���s�S","�S��S",
				  "�����s�s","�l���s�s","�����s��s"
			  };
		protected static Hashtable h�s���{��   = null;

		protected static String gs����b�c     = "";
		protected static String gs�����       = "";
		protected static String gs����b�c     = "";
		protected static String gs���喼       = "";
		protected static String gs�o�ד�       = "";
		protected static String gs���p�҂b�c   = "";
		protected static String gs���p�Җ�     = "";
		protected static String gs�[���b�c     = "";
		protected static String gs�v�����^�e�f = "";
		protected static String gs�v�����^��� = "";
		protected static String gs�ב��l�b�c   = "";
		protected static String[] gsa����b�c = {""};
		protected static String[] gsa���喼   = {""};
		protected static String[] gsa�o�ד�   = {""};
		protected static Hashtable gh����b�c = null;
		protected static String[] gsa������b�c     = {""};
		protected static String[] gsa�����敔�ۂb�c = {""};
		protected static String[] gsa�����敔�ۖ�   = {""};
		protected static DateTime gdt�o�ד� = DateTime.Today;
		protected static String[] gsa��Ԃb�c = {""};
		protected static String[] gsa��Ԗ�   = {""};
// MOD 2007.10.26 ���s�j���� �o�[�W��������\������ START
//		protected static String[] gsa���[�U = new string[3];
		protected static String[] gsa���[�U = {"","","",""};
// MOD 2007.10.26 ���s�j���� �o�[�W��������\������ END
//		protected static string gs���b�Z�[�W = new String('�@',25) + "�����m�点���@";
		protected static string gs���b�Z�[�W = "";

// MDD 2005.05.25 ���s�j���� �A�C�R���I����ʂ̕\�����A[.ico]��\�� START
//		protected static String[] s�A�C�R�� = { "", 
//												"Icon0008.ico", "Icon0009.ico", "Icon0010.ico", 
//												"Icon0011.ico", "Icon0023.ico", "Icon0024.ico", 
//												"Icon0035.ico", "Icon0069.ico", "Icon0072.ico", 
//												"Icon0075.ico", "Icon0076.ico", "Icon0077.ico", 
//												"Icon0078.ico", "Icon0084.ico", "Icon0113.ico", 
//												"Icon0114.ico", "Icon0142.ico", 
//												"zblue.ico", "zgreen.ico", "zpurple.ico"};
		protected static String[] s�A�C�R�� = { "" };
		protected static String[] s�A�C�R���ꗗ = { "" };
// MDD 2005.05.25 ���s�j���� �A�C�R���I����ʂ̕\�����A[.ico]��\�� END
		protected static Hashtable h�A�C�R�� = null;
		protected static ImageList imageList64 = null;
		protected static ImageList imageList16 = null;
		protected static ImageList imageList���� = null;
// ADD 2009.07.29 ���s�j���� �v���L�V�Ή� START
		protected static string gsProxyAdr        = "";
		protected static string gsProxyAdrUserSet = "";
		protected static string gsProxyAdrSecure  = "";
		protected static string gsProxyAdrHttp    = "";
		protected static string gsProxyAdrAll     = "";
		protected static int    giProxyNo         = 0;
		protected static int    giProxyNoUserSet  = 0;
		protected static int    giProxyNoSecure   = 0;
		protected static int    giProxyNoHttp     = 0;
		protected static int    giProxyNoAll      = 0;
		protected static System.Net.WebProxy gProxy;
		protected static int    giConnectTimeOut  = 0;
// ADD 2009.07.29 ���s�j���� �v���L�V�Ή� END
// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� START
		protected static bool   gbProxyOnUserSet   = false;
		protected static bool   gbProxyIdOnUserSet = false;
		protected static string gsProxyIdUserSet   = "";
		protected static string gsProxyPaUserSet   = "";
// MOD 2011.12.06 ���s�j���� �v���L�V�F�؂̒ǉ� END
		// �v�����T�[�r�X�ϐ�
		protected static is2address.Service1  sv_address  = null;
		protected static is2goirai.Service1   sv_goirai   = null;
		protected static is2hinagata.Service1 sv_hinagata = null;
		protected static is2init.Service1     sv_init     = null;
		protected static is2kiji.Service1     sv_kiji     = null;
		protected static is2otodoke.Service1  sv_otodoke  = null;
		protected static is2print.Service1    sv_print    = null;
		protected static is2syukka.Service1   sv_syukka   = null;
		protected static is2seikyuu.Service1  sv_seikyuu  = null;
// ADD 2007.12.11 KCL) �X�{ ���m�点�ǉ� START
		protected static is2oshirase.Service1 sv_oshirase = null;
// ADD 2007.12.11 KCL) �X�{ ���m�点�ǉ� END
// ADD 2010.12.13 ACT) �_�� ���q�^���Ή� START
		protected static is2oji.Service1 sv_oji = null;
// ADD 2010.12.13 ACT) �_�� ���q�^���Ή� END

// DEL 2005.05.20 ���s�j���� �Z�V�����R���g���[���̔p�~ START
//		// Cookie��ۑ����Ă���CookieContainer
//		protected static System.Net.CookieContainer cContainer = new System.Net.CookieContainer();
// DEL 2005.05.20 ���s�j���� �Z�V�����R���g���[���̔p�~ END
		// ���^�o�דo�^��ʂ��X�^�[�g��ʂɂ���ꍇ�́Atrue
		protected static bool   b���^�o�דo�^ = false;
		protected static string s���^�o�דo�^�m�n = "";
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
//		// ��������p�f�[�^�Z�b�g
//		protected static �����f�[�^ ds����� = new �����f�[�^();
//		// �T�[�}���v�����^�`�F�b�N�p
//		protected static System.Drawing.Printing.PrintDocument pd�T�[�}���v�����^ = new System.Drawing.Printing.PrintDocument();
		// ��������p�f�[�^�Z�b�g
		protected �����f�[�^ ds����� = new �����f�[�^();
		// �T�[�}���v�����^�`�F�b�N�p
		protected System.Drawing.Printing.PrintDocument pd�T�[�}���v�����^ = new System.Drawing.Printing.PrintDocument();
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END

// ADD 2005.05.20 ���s�j���� �X���b�h�� START
		protected static ����ύX�Q  g����ύX       = null;
		protected static �o�׏Ɖ�    g�o�׏Ɖ�       = null;
// ADD 2005.05.20 ���s�j���� �X���b�h�� END
// ADD 2005.05.24 ���s�j�����J �X���b�h�� START
		protected static �A�C�R���I��   g�A�C�R��    = null;
		protected static ���͂��挟��   g�͐挟��    = null;
		protected static ���͂���捞   g�͐�捞    = null;
		protected static ���͂���o�^   g�͐�o�^    = null;
		protected static ���͂���o�^�� g�͐�o��    = null;
		protected static ���˗��匟��   g�˗�����    = null;
// MOD 2010.08.27 ���s�j���� ���˗���捞�i�b�r�u�j�@�\�ǉ� START
		protected static ���˗���捞   g�˗��捞    = null;
// MOD 2010.08.27 ���s�j���� ���˗���捞�i�b�r�u�j�@�\�ǉ� END
		protected static ���˗���o�^   g�˗��o�^    = null;
		protected static �p�X���[�h�ύX g�p�X�ύX    = null;
		protected static �L������       g�L������    = null;
		protected static �ː��؂�ւ�   g�ː��ؑ�    = null;
		protected static �����o�דo�^   g�����o�^    = null;
		protected static �Z������       g�Z������    = null;
		protected static �o�דo�^       g�o�דo�^    = null;
		protected static ���^�o�דo�^   g���o�o�^    = null;
		protected static ���^�o�^       g���^�o�^    = null;
		protected static ������o�^     g�����o�^    = null;
		protected static �[���o�^       g�[���o�^    = null;
		protected static �����s���     g�������    = null;
		protected static �w�莞�ԓ���   g�w�莞�ԓ��� = null;
		protected static �o�׎���       g�o�׎���    = null;
// ADD 2015.03.05 BEVAS) �O�c �x�X�~�ߋ@�\�ǉ��Ή� START
		protected static �X������       g�X������    = null;
// ADD 2014.03.05 BEVAS) �O�c �x�X�~�ߋ@�\�ǉ��Ή� END

// ADD 2006.12.22 ���s�j�����J ��ʒǉ� START
		protected static ���O�C���Q     g���O�C���Q  = null;
// ADD 2006.12.22 ���s�j�����J ��ʒǉ� END
// ADD 2005.05.24 ���s�j�����J �X���b�h�� END
// ADD 2007.12.06 KCL) �X�{ ���m�点�ǉ� START
		protected static ���m�点�\��    g���m�\��   = null;
// ADD 2007.12.06 KCL) �X�{ ���m�点�ǉ� END
// ADD 2015.07.13 TDI�j�j�V �o�[�R�[�h�ǎ��p��ʒǉ� START
		protected static �ǎ��p���    g�ǎ��p��� = null;
// ADD 2015.07.13 TDI�j�j�V �o�[�R�[�h�ǎ��p��ʒǉ� END
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� START
		protected static �����T����� g�T����� = null;
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� END

// ADD 2005.05.24 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� START
//		protected static String gs�ʐM�G���[
		protected const string gs�ʐM�G���[
			= "�T�[�o�[�Ƃ̒ʐM�Ɏ��s���܂���\n"
			+ " �k�`�m�P�[�u����l�b�g���[�N�ݒ蓙���m�F���Ă�������";
// ADD 2005.05.24 ���s�j���� �ʐM�G���[�̃��b�Z�[�W�C�� END
// ADD 2005.07.21 ���s�j���� �X�����[�U�Ή� START
		protected static string gs�����P = "";
// ADD 2005.07.21 ���s�j���� �X�����[�U�Ή� END
// ADD 2006.12.12 ���s�j�����J ����X���擾 START
		protected static string gs���p�ҕ���X���b�c = "";
		protected static bool   gb��� = true;
// ADD 2006.12.12 ���s�j�����J ����X���擾 END
// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� START
		protected static string gs����X���b�c = "";
// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� END

// ADD 2006.12.14 ���s�j�����J �������� START
		protected static string gs���p�ҕ���b�c = "";
// ADD 2006.12.14 ���s�j�����J �������� END
// ADD 2008.04.11 ACT Vista�Ή� START
		protected static Hashtable gh�����ϊ� = null;
// ADD 2008.04.11 ACT Vista�Ή� END
// ADD 2009.04.02 ���s�j���� �ғ����Ή� START
		protected static string[] gs�ғ���;
		protected static DateTime gdt�o�ד��ő�l;
		protected static DateTime gdt�o�ד��ő�l�b�r�u;
// ADD 2009.04.02 ���s�j���� �ғ����Ή� END
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
// MOD 2010.02.01 ���s�j���� �I�v�V�����̍��ڒǉ��i�b�r�u�o�͌`���jSTART
//// MOD 2009.11.06 PSN�j����@�I�v�V�����̍��ڒǉ� START
////		protected static int      gi�I�v�V������ = 14;
//		protected static int      gi�I�v�V������ = 16;
//// MOD 2009.11.06 PSN�j����@�I�v�V�����̍��ڒǉ� END
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//		protected static int      gi�I�v�V������ = 17;
// MOD 2011.05.09 ���s�j���� �G�R�[�����ł̃I�v�V�����̃}�[�W START
//		protected static int      gi�I�v�V������ = 19;
// MOD 2012.04.10 ���s�j���� ���x�����X���̈󎚐���Ή� START
//		protected static int      gi�I�v�V������ = 20;
// MOD 2015.07.13 BEVAS)���{ �o�[�R�[�h�ǎ��p��ʒǉ� START
//		protected static int      gi�I�v�V������ = 21;
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� START
//		protected static int      gi�I�v�V������ = 22;
// MOD 2016.06.10 BEVAS�j���{ �ی������̓`�F�b�N�@�\�̒ǉ� START
//		protected static int      gi�I�v�V������ = 23;
		protected static int      gi�I�v�V������ = 24;
// MOD 2016.06.10 BEVAS�j���{ �ی������̓`�F�b�N�@�\�̒ǉ� END
// MOD 2016.02.02 BEVAS�j���{ �ב��l�}�X�^�̌Œ�d�ʁA�Œ�ː��̍l���ǉ� END
// MOD 2015.07.13 BEVAS)���{ �o�[�R�[�h�ǎ��p��ʒǉ� END
// MOD 2012.04.10 ���s�j���� ���x�����X���̈󎚐���Ή� END
// MOD 2011.05.09 ���s�j���� �G�R�[�����ł̃I�v�V�����̃}�[�W END
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
// MOD 2010.02.01 ���s�j���� �I�v�V�����̍��ڒǉ��i�b�r�u�o�͌`���jEND
		protected static string[] gs�I�v�V���� = new string[gi�I�v�V������+1];
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� END
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
		protected static string gs�d�ʓ��͐��� = "0";
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� START
		protected static string gs�A�h���X��_�\�����P        = null;
		protected static string gs�A�h���X��_�\�����P_����   = null;
		protected static string gs�A�h���X��_�\�����Q        = null;
		protected static string gs�A�h���X��_�\�����Q_����   = null;
		protected static string gs���˗��匟��_�\�����P      = null;
		protected static string gs���˗��匟��_�\�����P_���� = null;
		protected static string gs���˗��匟��_�\�����Q      = null;
		protected static string gs���˗��匟��_�\�����Q_���� = null;
// MOD 2010.03.01 ���s�j���� �[�����Ƃɕ\��������ێ�����@�\�̒ǉ� END
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� START
		protected static string gs�o�׎���_�����s�����O              = null;
		protected static string gs�o�׎���_�Ԋ|���Ȃ�_����̂�       = null;
		protected static string gs�o�׎���_���˗���󎚂Ȃ�_����̂� = null;
		protected static string gs�o�׎���_�^���󎚂Ȃ�_����̂�     = null;
		protected static string gs�o�׎���_���X�o��_�b�r�u�̂�       = null;
		protected static string gs�o�׎���_�z�������o��              = null;
// MOD 2016.06.10 BEVAS�j���{ �o�׎��щ�ʂ̃I�v�V�����`�F�b�N���e��[�����ɕۑ� END
// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
		protected static int giDisplayDpiX = 0;
		protected static int giDisplayDpiY = 0;
// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� END
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� START
		protected static string gs���m�点�ē����b�Z�[�W = "";
// MOD 2010.07.01 ���s�j���� �c�Ə��p���m�点�o�^�@�\�̒ǉ� END
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) START
		protected const long gl�ی����z��� = 9999;
// MOD 2010.12.01 ���s�j���� �ی����z��������ɖ߂�(9999��) END
// MOD 2016.04.13 BEVAS�j���{ �z�B�w�������̊g�� START
		protected static string gs�w�������g������b�c = "0584898934";  //�Z���A�l�̂ݑΏ�
// MOD 2016.04.13 BEVAS�j���{ �z�B�w�������̊g�� END
// MOD 2016.06.10 BEVAS�j���{ �ی������̓`�F�b�N�@�\�̒ǉ� START
		protected const long gl�ی����z�`�F�b�N� = 31;
// MOD 2016.06.10 BEVAS�j���{ �ی������̓`�F�b�N�@�\�̒ǉ� END

		[System.Runtime.InteropServices.DllImport("user32.dll")] 
		protected static extern int MessageBeep(uint n); 
// MOD 2010.03.12 ���s�j���� �P�O�O�O�O���`�F�b�N�����@�\�̒ǉ� START
		[System.Runtime.InteropServices.DllImport("user32.dll")] 
		protected static extern short GetAsyncKeyState(Keys vKey); 
// MOD 2010.03.12 ���s�j���� �P�O�O�O�O���`�F�b�N�����@�\�̒ǉ� END

		protected void �G���^�[�ړ�(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyCode){
				// [Enter]�L�[�������ꂽ���A���̃R���g���[���փt�H�[�J�X�ړ�
				case Keys.Enter:
//					System.Windows.Forms.SendKeys.Send("{TAB}");
// MOD 2007.11.22 KCL) �X�{ Vista�Ή� START
//// ADD 2007.11.08 ���s�j���� Vista�Ή� START
//					try
//					{
//// ADD 2007.11.08 ���s�j���� Vista�Ή� END
//						System.Windows.Forms.SendKeys.SendWait("{TAB}");
//// ADD 2007.11.08 ���s�j���� Vista�Ή� START
//					}
//					catch(System.Security.SecurityException)
//					{
//					}
//// ADD 2007.11.08 ���s�j���� Vista�Ή� END
					// �ʂ̕��@ - ���̂P
					//this.ProcessTabKey(!e.Shift);

					// �ʂ̕��@ - ���̂Q
					this.SelectNextControl(this.ActiveControl, true, true, true, true);
// MOD 2007.11.22 KCL) �X�{ Vista�Ή� END
					break;
				// [Esc]�L�[�������ꂽ���A�t�H�[�������
				case Keys.Escape:
					Close();
					break;
			}
		}
		protected void �G���^�[�L�����Z��(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == 0x0d)
			{
				e.Handled = true;
			}
		}
		protected static bool �K�{�`�F�b�N(TextBox tex, string name)
		{
			if(tex.Text.Length > 0) return true;
			MessageBox.Show("�K�{����(" + name + ")�����͂���Ă��܂���",
				"���̓`�F�b�N",MessageBoxButtons.OK);
			tex.Focus();
			return false;
		}

// ADD 2007.03.29 ���s�j���� �r�i�h�r�`�F�b�N�@�\�̒ǉ� START
// MOD 2008.04.11 ACT Vista�Ή� START
//		private static bool �r�i�h�r�`�F�b�N(TextBox tex, string name, string sUnicode, byte[] bSjis)
		private static bool �r�i�h�r�`�F�b�N(TextBox tex, string name, ref string sUnicode, ref byte[] bSjis)
// MOD 2008.04.11 ACT Vista�Ή� END
		{
			//�t�ϊ����Ăr�i�h�r�������`�F�b�N����
			string sRevUnicode = System.Text.Encoding.GetEncoding("shift-jis").GetString(bSjis);
			string sErrChars = "";
			for(int iPos = 0; iPos < sUnicode.Length && iPos < sRevUnicode.Length; iPos++)
			{
				if(sUnicode[iPos] != sRevUnicode[iPos])
				{
// DEL 2007.11.22 KCL) �X�{ Unicode �T���Q�[�g�E�y�A�Ή� START
//					if(sErrChars.IndexOf(sUnicode[iPos]) == -1)
//					{
//						if(sErrChars.Length > 0) sErrChars += "�A";
// DEL 2007.11.22 KCL) �X�{ Unicode �T���Q�[�g�E�y�A�Ή� END
						sErrChars += sUnicode[iPos];
// DEL 2007.11.22 KCL) �X�{ Unicode �T���Q�[�g�E�y�A�Ή� START
//					}
// DEL 2007.11.22 KCL) �X�{ Unicode �T���Q�[�g�E�y�A�Ή� END
				}
			}
			if(sErrChars.Length > 0)
			{
// MOD 2008.04.11 ACT Vista�Ή� START
//				MessageBox.Show(name + "�Ɏg�p�ł��Ȃ�����������܂�\n"
//					+ "�w" + sErrChars + "�x",
//					"���̓`�F�b�N",MessageBoxButtons.OK);
//				tex.Focus();
//				return false;
				return �����ϊ�(tex, name, ref sUnicode, ref bSjis);
// MOD 2008.04.11 ACT Vista�Ή� END
			}
			return true;
		}

// ADD 2007.03.29 ���s�j���� �r�i�h�r�`�F�b�N�@�\�̒ǉ� END

		protected static bool �S�p�`�F�b�N(TextBox tex, string name)
		{
			string sUnicode = tex.Text;
			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
// MOD 2008.04.11 ACT Vista�Ή� START
//// ADD 2007.03.29 ���s�j���� �r�i�h�r�`�F�b�N�@�\�̒ǉ� START
//			if(!�r�i�h�r�`�F�b�N(tex, name, sUnicode, bSjis)) return false;
			if(!�r�i�h�r�`�F�b�N(tex, name, ref sUnicode, ref bSjis)) return false;
//// ADD 2007.03.29 ���s�j���� �r�i�h�r�`�F�b�N�@�\�̒ǉ� END
// MOD 2008.04.11 ACT Vista�Ή� END
			if(bSjis.Length == sUnicode.Length * 2) return true;
			MessageBox.Show(name + "�͑S�p�����œ��͂��Ă�������",
				"���̓`�F�b�N",MessageBoxButtons.OK);
			tex.Focus();
			return false;
		}

// MOD 2011.12.08 ���s�j���� �Z���E���O�̔��p���͉� START
		//
		// ���͍��ڂ̒����������Z���J�b�g����K�v���������׍쐬
		// �i�L���̒����`�F�b�N�j
		//
		protected bool �S�p�ϊ��`�F�b�N(TextBox tex, string name)
		{
			string sUnicode = tex.Text;
			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
			if(!�r�i�h�r�`�F�b�N(tex, name, ref sUnicode, ref bSjis)) return false;

			// ���ׂđS�p�����̏ꍇ�́A���^�[��
			if(bSjis.Length == sUnicode.Length * 2) return true;

			DialogResult result;
			result = MessageBox.Show(name + "�ɔ��p�������܂܂�Ă��܂��B"
				+ "�S�p�����ɕϊ����Ă�낵���ł����H"
				, "���̓`�F�b�N", MessageBoxButtons.YesNo);
			if(result != DialogResult.Yes){
				tex.Focus();
				return false;
			}

			string sErr = "";
			bool bRet = �S�p�ϊ��`�F�b�N(ref sUnicode, ref sErr);
			if(bRet == false){
//�ۗ� �G���[����
				MessageBox.Show(name + "�Ɏg�p�ł��Ȃ�����������܂�\n"
					+ "�w" + sErr + " �� ? �x",
					"���̓`�F�b�N",MessageBoxButtons.OK);
				tex.Focus();
				return false;
			}

			// �����`�F�b�N
			if(sUnicode.Length > tex.MaxLength){
				result = MessageBox.Show(name + "�̐����������𒴂��Ă��܂��i"
					+ (sUnicode.Length - tex.MaxLength)+"�������߁j\n"
					+ "���ߕ����J�b�g���Ă�낵���ł����H"
					, "���̓`�F�b�N", MessageBoxButtons.YesNo);
				if(result != DialogResult.Yes){
					tex.Focus();
					return false;
				}
				tex.Text = �o�C�g���J�b�g(sUnicode, tex.MaxLength * 2);
				tex.Refresh();
				return true;
			}

			tex.Text = sUnicode;
			tex.Refresh();
			return true;
		}
// MOD 2011.12.08 ���s�j���� �Z���E���O�̔��p���͉� END

		protected static bool ���p�`�F�b�N(TextBox tex, string name)
		{
			string sUnicode = tex.Text;
			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
// MOD 2008.04.11 ACT Vista�Ή� START
//// ADD 2007.03.29 ���s�j���� �r�i�h�r�`�F�b�N�@�\�̒ǉ� START
//			if(!�r�i�h�r�`�F�b�N(tex, name, sUnicode, bSjis)) return false;
			if(!�r�i�h�r�`�F�b�N(tex, name, ref sUnicode, ref bSjis)) return false;
//// ADD 2007.03.29 ���s�j���� �r�i�h�r�`�F�b�N�@�\�̒ǉ� END
// MOD 2008.04.11 ACT Vista�Ή� END
			if(bSjis.Length != sUnicode.Length)
			{
				MessageBox.Show(name + "�͔��p�����œ��͂��Ă�������",
					"���̓`�F�b�N",MessageBoxButtons.OK);
				tex.Focus();
				return false;
			}

			for(int i = 0; i < tex.Text.Length; i++)
			{
				// [!"#$%&'()*,]
				// [:;<=>?]
				// [[]^]
				// [{|}]
				// [\]
// MOD 2009.11.04 ���s�j���� ���͂���b�c�ɋL��[+]�𗘗p�\�ɂ��� START
//				if((tex.Text[i] >= 0x21 && tex.Text[i] <= 0x2C)
				if((tex.Text[i] >= 0x21 && tex.Text[i] <= 0x2A)
					|| (tex.Text[i] == 0x2C)
// MOD 2009.11.04 ���s�j���� ���͂���b�c�ɋL��[+]�𗘗p�\�ɂ��� END
					|| (tex.Text[i] >= 0x3A && tex.Text[i] <= 0x3F)
					|| (tex.Text[i] >= 0x5B && tex.Text[i] <= 0x5E)
					|| (tex.Text[i] >= 0x7B && tex.Text[i] <= 0x7D)
					|| (tex.Text[i] == 0xA5))
				{
					MessageBox.Show(name + "�ɋL�������͂���Ă��܂�","���̓`�F�b�N",MessageBoxButtons.OK);
					tex.Focus();
					return false;
				}
			}
			return true;
		}

		protected static bool �p�X���[�h�`�F�b�N(TextBox tex, string name)
		{
			string sUnicode = tex.Text;
			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
// MOD 2008.05.13 ���s�j���� Vista�Ή� START
//// ADD 2008.03.13 ���s�j���� �r�i�h�r�`�F�b�N�@�\�̒ǉ� START
//			if(!�r�i�h�r�`�F�b�N(tex, name, sUnicode, bSjis)) return false;
			if(!�r�i�h�r�`�F�b�N(tex, name, ref sUnicode, ref bSjis)) return false;
//// ADD 2008.03.13 ���s�j���� �r�i�h�r�`�F�b�N�@�\�̒ǉ� END
// MOD 2008.05.13 ���s�j���� Vista�Ή� END
			//���p�`�F�b�N
			if(bSjis.Length != sUnicode.Length)
			{
				MessageBox.Show("���p�҂b�c�������̓p�X���[�h�Ɍ�肪����܂�",
					"���̓`�F�b�N",MessageBoxButtons.OK);
				tex.Focus();
				return false;
			}

			for(int i = 0; i < tex.Text.Length; i++)
			{
				// [!"#$%&'()*,]
				// [:;<=>?]
				// [[]^]
				// [{|}]
				// [\]
// MOD 2009.11.04 ���s�j���� ���͂���b�c�ɋL��[+]�𗘗p�\�ɂ��� START
//				if((tex.Text[i] >= 0x21 && tex.Text[i] <= 0x2C)
				if((tex.Text[i] >= 0x21 && tex.Text[i] <= 0x2A)
					|| (tex.Text[i] == 0x2C)
// MOD 2009.11.04 ���s�j���� ���͂���b�c�ɋL��[+]�𗘗p�\�ɂ��� END
					|| (tex.Text[i] >= 0x3A && tex.Text[i] <= 0x3F)
					|| (tex.Text[i] >= 0x5B && tex.Text[i] <= 0x5E)
					|| (tex.Text[i] >= 0x7B && tex.Text[i] <= 0x7D)
					|| (tex.Text[i] == 0xA5))
				{
					MessageBox.Show("���p�҂b�c�������̓p�X���[�h�Ɍ�肪����܂�","���̓`�F�b�N",MessageBoxButtons.OK);
					tex.Focus();
					return false;
				}
			}
			return true;
		}

// MOD 2009.12.01 ���s�j���� �S�p���p���݉\�ɂ��� START
		protected static bool ���݃`�F�b�N(TextBox tex, string name)
		{
			string sUnicode = tex.Text;
			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
			if(!�r�i�h�r�`�F�b�N(tex, name, ref sUnicode, ref bSjis)) return false;

			// �����`�F�b�N
			if(bSjis.Length > tex.MaxLength){
				DialogResult result;
// MOD 2010.01.15 ���s�j���� �������J�b�g�̃��b�Z�[�W�̕ύX START
//				result = MessageBox.Show(name + "�̕������� "
//					+ (bSjis.Length - tex.MaxLength) +"�o�C�g���������܂�\n"
//					+ tex.MaxLength+"�o�C�g�ȓ��œ��͂��Ă�������\n"
//					+ "�i���p������ 1�o�C�g�A�S�p������ 2�o�C�g�Ƃ��Đ����܂��j\n"
//					+ "�擪���� 30�o�C�g���ŃJ�b�g���Ă�낵���ł����H"
				result = MessageBox.Show(name + "�̐����������𒴂��Ă��܂��i"
					+ (bSjis.Length - tex.MaxLength)+"�o�C�g���߁j\n"
					+ "���ߕ����J�b�g���Ă�낵���ł����H\n"
					+ "�i�����p������ 1�o�C�g�A�S�p������ 2�o�C�g�Ƃ��Đ����܂��j\n"
// MOD 2010.01.15 ���s�j���� �������J�b�g�̃��b�Z�[�W�̕ύX END
					, "���̓`�F�b�N", MessageBoxButtons.YesNo);
				if(result != DialogResult.Yes){
					tex.Focus();
					return false;
				}
				tex.Text = �o�C�g���J�b�g(tex.Text, tex.MaxLength);
				tex.Refresh();
			}

			for(int i = 0; i < tex.Text.Length; i++)
			{
//				// [!"#$%&'()*,]
//				// [:;<=>?]
//				// [[]^]
//				// [{|}]
//				// [\]
//// MOD 2009.11.04 ���s�j���� ���͂���b�c�ɋL��[+]�𗘗p�\�ɂ��� START
////				if((tex.Text[i] >= 0x21 && tex.Text[i] <= 0x2C)
//				if((tex.Text[i] >= 0x21 && tex.Text[i] <= 0x2A)
//					|| (tex.Text[i] == 0x2C)
//// MOD 2009.11.04 ���s�j���� ���͂���b�c�ɋL��[+]�𗘗p�\�ɂ��� END
//					|| (tex.Text[i] >= 0x3A && tex.Text[i] <= 0x3F)
//					|| (tex.Text[i] >= 0x5B && tex.Text[i] <= 0x5E)
//					|| (tex.Text[i] >= 0x7B && tex.Text[i] <= 0x7D)
//					|| (tex.Text[i] == 0xA5))
//				{
//					MessageBox.Show(name + "�ɋL�������͂���Ă��܂�","���̓`�F�b�N",MessageBoxButtons.OK);
//					tex.Focus();
//					return false;
//				}
				// ["',;|]
				if(tex.Text[i] == 0x22 || tex.Text[i] == 0x27 
					|| tex.Text[i] == 0x2C || tex.Text[i] == 0x3B
					|| tex.Text[i] == 0x7C )
				{
					MessageBox.Show(name + "�ɋL��["+tex.Text[i]+"]�����͂���Ă��܂�"
						,"���̓`�F�b�N",MessageBoxButtons.OK);
					tex.Focus();
					return false;
				}
			}
			
			return true;
		}
// MOD 2009.12.01 ���s�j���� �S�p���p���݉\�ɂ��� END
// MOD 2011.07.28 ���s�j���� �L���s�̒ǉ��i���͐����̒ǉ��j START
		//
		// ���͍��ڂ̒����������Z���J�b�g����K�v���������׍쐬
		// �i�L���̒����`�F�b�N�j
		//
		protected static bool ���݃`�F�b�N�Q(TextBox tex, string name, int iMaxLength)
		{
			string sUnicode = tex.Text;
			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
			if(!�r�i�h�r�`�F�b�N(tex, name, ref sUnicode, ref bSjis)) return false;

			// �����`�F�b�N
			if(bSjis.Length > iMaxLength){
				DialogResult result;
				result = MessageBox.Show(name + "�̐����������𒴂��Ă��܂��i"
					+ (bSjis.Length - iMaxLength)+"�o�C�g���߁j\n"
					+ "���ߕ����J�b�g���Ă�낵���ł����H\n"
					+ "�i�����p������ 1�o�C�g�A�S�p������ 2�o�C�g�Ƃ��Đ����܂��j\n"
					, "���̓`�F�b�N", MessageBoxButtons.YesNo);
				if(result != DialogResult.Yes){
					tex.Focus();
					return false;
				}
				tex.Text = �o�C�g���J�b�g(tex.Text, iMaxLength);
				tex.Refresh();
			}

			for(int i = 0; i < tex.Text.Length; i++)
			{
				// ["',;|]
				if(tex.Text[i] == 0x22 || tex.Text[i] == 0x27 
					|| tex.Text[i] == 0x2C || tex.Text[i] == 0x3B
					|| tex.Text[i] == 0x7C )
				{
					MessageBox.Show(name + "�ɋL��["+tex.Text[i]+"]�����͂���Ă��܂�"
						,"���̓`�F�b�N",MessageBoxButtons.OK);
					tex.Focus();
					return false;
				}
			}
			
			return true;
		}
// MOD 2011.07.28 ���s�j���� �L���s�̒ǉ��i���͐����̒ǉ��j END

		protected static bool ���l�`�F�b�N(TextBox tex, string name)
		{
			try
			{
// MOD 2006.05.30 ���s�j���� ���l�`�F�b�N�̌����ӂ�Ή� START
//				int iChk = int.Parse(tex.Text.Replace(",",""));
				long lChk = long.Parse(tex.Text.Replace(",",""));
// MOD 2006.05.30 ���s�j���� ���l�`�F�b�N�̌����ӂ�Ή� END
				return true;
			}
// MOD 2006.05.30 ���s�j���� ���l�`�F�b�N�̌����ӂ�Ή� START
//			catch(System.FormatException)
			catch(Exception)
// MOD 2006.05.30 ���s�j���� ���l�`�F�b�N�̌����ӂ�Ή� END
			{
				MessageBox.Show(name + "�ɐ��l�����͂���Ă��܂���","���̓`�F�b�N",MessageBoxButtons.OK);
				tex.Focus();
				
				return false;
			}
		}

		//NumericUpDown�p
		protected static bool �͈̓`�F�b�N(NumericUpDown num, string name)
		{
			try
			{
// MOD 2006.05.30 ���s�j���� ���l�`�F�b�N�̌����ӂ�Ή� START
//				int iChk = int.Parse(num.Text.Replace(",",""));
//				if (iChk >= num.Minimum && iChk <= num.Maximum) return true;
				long lChk = long.Parse(num.Text.Replace(",",""));
// ADD 2007.03.29 ���s�j���� �����`�F�b�N�@�\�̋��� START
				//�������l�ɕ\�����l�����i�������͏�Q�Ή��j
				num.Value = lChk;
// ADD 2007.03.29 ���s�j���� �����`�F�b�N�@�\�̋��� END
				if (lChk >= num.Minimum && lChk <= num.Maximum) return true;
// MOD 2006.05.30 ���s�j���� ���l�`�F�b�N�̌����ӂ�Ή� END
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX START
//				MessageBox.Show(name + "��" + num.Minimum + "�`" + num.Maximum + "�̊Ԃœ��͂��Ă�������","���̓`�F�b�N",MessageBoxButtons.OK);
				MessageBox.Show(name + "�� "
					+ num.Minimum + "�`" + num.Maximum + " �̒l����͂��Ă��������@"
					, "���̓`�F�b�N", MessageBoxButtons.OK);
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX END
				num.Focus();
				return false;
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX START
			}catch(System.ArgumentException){
				// �R���g���[���̉����l�������͏���l�𒴂�����
				MessageBox.Show(name + "�� "
					+ num.Minimum + "�`" + num.Maximum + " �̒l����͂��Ă��������@"
					, "���̓`�F�b�N", MessageBoxButtons.OK);
				num.Focus();
				return false;
			}catch(System.OverflowException){
				// long�^�̉����l�������͏���l�𒴂�����
				// �i�����ӂꓙ�j
				MessageBox.Show(name + "�� "
					+ num.Minimum + "�`" + num.Maximum + " �̒l����͂��Ă��������@"
					, "���̓`�F�b�N", MessageBoxButtons.OK);
				num.Focus();
				return false;
			}catch(System.FormatException){
				// �R���g���[���̃t�H�[�}�b�g�`���ƈقȂ鎞
				// �i�����_�␔���ȊO�����͂���Ă���ꍇ���j
				MessageBox.Show(name + "�� "
					+ num.Minimum + "�`" + num.Maximum + " �̐�������͂��Ă��������@"
					, "���̓`�F�b�N", MessageBoxButtons.OK);
				num.Focus();
				return false;
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX END
			}
// MOD 2006.05.30 ���s�j���� ���l�`�F�b�N�̌����ӂ�Ή� START
//			catch(System.FormatException)
			catch(Exception)
// MOD 2006.05.30 ���s�j���� ���l�`�F�b�N�̌����ӂ�Ή� END
			{
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX START
//// ADD 2005.09.02 ���s�j�����J ���b�Z�[�W�ύX START
////				MessageBox.Show(name + "�ɐ��l�����͂���Ă��܂���","���̓`�F�b�N",MessageBoxButtons.OK);
//				MessageBox.Show(name + "�ɐ��������͂���Ă��܂���","���̓`�F�b�N",MessageBoxButtons.OK);
//// ADD 2005.09.02 ���s�j�����J ���b�Z�[�W�ύX END
				MessageBox.Show(name + "�� "
					+ num.Minimum + "�`" + num.Maximum + " �̐�������͂��Ă��������@"
					, "���̓`�F�b�N", MessageBoxButtons.OK);
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX END
				num.Focus();
				return false;
			}
		}

// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX START
		protected static bool �͈̓`�F�b�N(NumericUpDown num, string name, long lMin, long lMax, string sMaxMsg)
		{
			try{
				string data = num.Text.Replace(",","");
				string sChkMsg = ���l�͈̓`�F�b�N(name, data, lMin, lMax, sMaxMsg);
				if(sChkMsg.Length > 0){
					MessageBox.Show(sChkMsg + "�@"
						, "���̓`�F�b�N", MessageBoxButtons.OK);
					num.Focus();
					return false;
				}
				long lChk = long.Parse(data);
				//�������l�ɕ\�����l�����i�������͏�Q�Ή��j
				num.Value = lChk;
			}catch(System.ArgumentException){
				// �R���g���[���̉����l�������͏���l�𒴂�����
				MessageBox.Show(name + "�� "
					+ lMin + "�`" + lMax + " �̒l����͂��Ă��������@"
					, "���̓`�F�b�N", MessageBoxButtons.OK);
				num.Focus();
				return false;
			}catch(Exception){
				MessageBox.Show(name + "�� "
					+ lMin + "�`" + lMax + " �̐�������͂��Ă��������@"
					, "���̓`�F�b�N", MessageBoxButtons.OK);
				num.Focus();
				return false;
			}
			return true;
		}

		protected static string ���l�͈̓`�F�b�N(string name, string data, long lMin, long lMax, string sMaxMsg)
		{
			string sRet = "";
			try{
				if(data.IndexOf(".") >= 0){
					sRet = name + "�͐�������͂��Ă�������";
					return sRet;
				}
				long lChk = long.Parse(data.Replace(",",""));
				// �͈͓��Ȃ�n�j
				if(lChk >= lMin && lChk <= lMax){
					return sRet;
				}
				if(sMaxMsg.Length > 0 && lChk > lMin){
					sRet = name + "��"+ sMaxMsg + "�œ��͂��Ă�������";
				}else{
					sRet = name + "�� "+ lMin + "�`" + lMax + " �̒l����͂��Ă�������";
				}
//			}catch(System.ArgumentException){
//				// �R���g���[���̉����l�������͏���l�𒴂�����
//				sRet = name + "�� "+ lMin + "�`" + lMax + " �̒l����͂��Ă�������";
			}catch(System.OverflowException){
				// long�^�̉����l�������͏���l�𒴂�����
				// �i�����ӂꓙ�j
				sRet = name + "�� "+ lMin + "�`" + lMax + " �̒l����͂��Ă�������";
			}catch(System.FormatException){
				// �R���g���[���̃t�H�[�}�b�g�`���ƈقȂ鎞
				// �i�����_�␔���ȊO�����͂���Ă���ꍇ���j
				sRet = name + "�� "+ lMin + "�`" + lMax + " �̐�������͂��Ă�������";
			}catch(Exception){
				sRet = name + "�� "+ lMin + "�`" + lMax + " �̐�������͂��Ă�������";
			}
			return sRet;
		}
// MOD 2010.11.02 ���s�j���� �ی����z�����30���ɕύX END

// ADD 2005.06.30 ���s�j�����J �f�[�^�捞���̃`�F�b�N START
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
//		protected static bool �K�{�`�F�b�N(string data)
		protected bool �K�{�`�F�b�N(string data)
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
		{
			if (data.Trim().Length == 0)
				return false;
			else
				return true;
		}
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
//		protected static bool �S�p�`�F�b�N(string data)
		protected bool �S�p�`�F�b�N(string data)
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
		{
			string sUnicode = data;
			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
			if(bSjis.Length == sUnicode.Length * 2) return true;

			return false;
		}
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
//		protected static bool ���p�`�F�b�N(string data)
		protected bool ���p�`�F�b�N(string data)
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
		{
			string sUnicode = data;
			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
			if(bSjis.Length != sUnicode.Length) return false;
			return true;
		}

// MOD 2009.12.01 ���s�j���� �S�p���p���݉\�ɂ��� START
		protected static string �o�C�g���J�b�g(string data, int iMaxLength)
		{
			string sRet = data;
			byte[] bSjis;

			bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(data);
			//�͈͓��Ȃ炻�̂܂ܖ߂�
			if(bSjis.Length <= iMaxLength){
				return sRet;
			}

			try{
				string sUnicode;
				for(int iLen = iMaxLength / 2; iLen <= data.Length; iLen++){
					sUnicode = data.Substring(0,iLen);
					bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
					if(bSjis.Length > iMaxLength){
						break;
					}
					sRet = sUnicode;
				}
			}catch(Exception){
				;
			}

			return sRet;
		}
// MOD 2009.12.01 ���s�j���� �S�p���p���݉\�ɂ��� END

// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� START
//		protected static bool �L���`�F�b�N(string data)
		protected bool �L���`�F�b�N(string data)
		{
			for(int i = 0; i < data.Length; i++)
			{
				// [!"#$%&'()*,]
				// [:;<=>?]
				// [[]^]
				// [{|}]
				// [\]
				if((data[i] >= 0x21 && data[i] <= 0x2A)
					|| (data[i] == 0x2C)
					|| (data[i] >= 0x3A && data[i] <= 0x3F)
					|| (data[i] >= 0x5B && data[i] <= 0x5E)
					|| (data[i] >= 0x7B && data[i] <= 0x7D)
					|| (data[i] == 0xA5))
				{
					return false;
				}
			}
			return true;
		}
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
//		protected static bool �L���`�F�b�N�Q(string data)
		protected bool �L���`�F�b�N�Q(string data)
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
		{
			for(int i = 0; i < data.Length; i++)
			{
//				// ["',;|]
//				if(data[i] == 0x22 || data[i] == 0x27 
//					|| data[i] == 0x2C || data[i] == 0x3B
//					|| data[i] == 0x7C )
				// [;|]
				if(data[i] == 0x3B || data[i] == 0x7C)
				{
					return false;
				}
			}
			return true;
		}
// MOD 2009.11.30 ���s�j���� �b�r�u�G���g���[���ɋL���`�F�b�N�@�\��ǉ� END

// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
//		protected static bool ���l�`�F�b�N(string data)
		protected bool ���l�`�F�b�N(string data)
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
		{
			try
			{
// MOD 2006.05.30 ���s�j���� ���l�`�F�b�N�̌����ӂ�Ή� END
//				int iChk = int.Parse(data.Replace(",",""));
				long lChk = long.Parse(data.Replace(",",""));
// MOD 2006.05.30 ���s�j���� ���l�`�F�b�N�̌����ӂ�Ή� END
				return true;
			}
// MOD 2006.05.30 ���s�j���� ���l�`�F�b�N�̌����ӂ�Ή� START
//			catch(System.FormatException)
			catch(Exception)
// MOD 2006.05.30 ���s�j���� ���l�`�F�b�N�̌����ӂ�Ή� END
			{
				return false;
			}
		}

// ADD 2005.06.30 ���s�j�����J �f�[�^�捞���̃`�F�b�N END

// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
//		protected static string �Z���ҏW(string s�Z��)
		protected string �Z���ҏW(string s�Z��)
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
		{
// ADD 2005.08.08 ���s�j�����J 2�����ȉ��̎��͕ҏW���Ȃ� START
			if(s�Z��.Length <= 2) return s�Z��;
// ADD 2005.08.08 ���s�j�����J 2�����ȉ��̎��͕ҏW���Ȃ� END

			// �s���{���n�b�V���e�[�u���̍쐬
			if(h�s���{�� == null)
			{
				h�s���{�� = new Hashtable();
				for(int iCnt = 1; iCnt < gsa����.Length; iCnt++)
				{
					h�s���{��.Add(iCnt,gsa����[iCnt]);
				}
			}

			string s����   = "";
			string s�s��S = "";
			string s�ҏW�� = "";
			string s�ҏW�� = "";
			int    iIndex  = 0;

			// �u�_�ސ쌧�v�A�u�a�̎R���v�A�u���������v�͂S�����ŕ�������r����
			if(s�Z��.StartsWith("�_") || s�Z��.StartsWith("�a") || s�Z��.StartsWith("��"))
			{
//				s�ҏW�� = s�Z��.Insert(4," ");
// ADD 2008.06.17 ���s�j���� �Z���P��[�_][�a][��]�Ŏn�܂肩�R���������̏ꍇ�̑Ή� START
				// [�a��s]�A[�����s]�Ȃ�
//				if(s�ҏW��.Length >= 4){
				if(s�Z��.Length >= 4){
// ADD 2008.06.17 ���s�j���� �Z���P��[�_][�a][��]�Ŏn�܂肩�R���������̏ꍇ�̑Ή� END
					s�ҏW�� = s�Z��.Substring(0,4);
					iIndex  = 4;
// ADD 2008.06.17 ���s�j���� �Z���P��[�_][�a][��]�Ŏn�܂肩�R���������̏ꍇ�̑Ή� START
				}
// ADD 2008.06.17 ���s�j���� �Z���P��[�_][�a][��]�Ŏn�܂肩�R���������̏ꍇ�̑Ή� END
			}
			else
			{
//				s�ҏW�� = s�Z��.Insert(3," ");
				s�ҏW�� = s�Z��.Substring(0,3);
				iIndex  = 3;
			}

			if(h�s���{��.ContainsValue(s�ҏW��))
			{
//				s����   = s�Z��.Insert(iIndex," ");
				s����   = s�ҏW��;
				s�ҏW�� = s�Z��.Remove(0,iIndex);
			}
			else
				s�ҏW�� = s�Z��;

			s�s��S = s�ҏW��;
			for(int iCnt = 0; iCnt < gsa�s��S.Length; iCnt++)
			{
				if(gsa�s��S[iCnt].Length <= s�s��S.Length)
				{
					if(gsa�s��S[iCnt] == s�s��S.Substring(0,gsa�s��S[iCnt].Length))
					{
						s�s��S = s�ҏW��.Insert(gsa�s��S[iCnt].Length," ");
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
						if(gs�I�v�V����[18].Equals("1")){
							if(s����.Trim().Length > 0){
								s�ҏW�� = s���� + " " + s�s��S;
							}else{
								s�ҏW�� = s�s��S;
							}
							return s�ҏW��.TrimEnd();
						}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
						s�ҏW�� = s���� + " " + s�s��S;
						return s�ҏW��.Trim();
					}
				}
			}

			for(iIndex = 1; iIndex < s�ҏW��.Length; iIndex++)
			{
				if(s�ҏW��.Substring(iIndex,1) == "�s"
					|| s�ҏW��.Substring(iIndex,1) == "��"
					|| s�ҏW��.Substring(iIndex,1) == "�S")
				{
					s�s��S = s�ҏW��.Insert(iIndex + 1," ");
// MOD 2006.05.24 ���s�j���� �s��S�����̏I�������̏C�� START
//					iIndex = 15;
					break;
// MOD 2006.05.24 ���s�j���� �s��S�����̏I�������̏C�� END
				}
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
			if(gs�I�v�V����[18].Equals("1")){
				if(s����.Trim().Length > 0){
					s�ҏW�� = s���� + " " + s�s��S;
				}else{
					s�ҏW�� = s�s��S;
				}
				return s�ҏW��.TrimEnd();
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
			s�ҏW�� = s���� + " " + s�s��S;
			return s�ҏW��.Trim();
		}

		protected static void �r�[�v��()
		{
			MessageBeep(0x00000030);

		}

		protected static void �A�C�R���C���[�W�̏�����()
		{
			if(imageList16 != null && imageList64 != null) return;

			imageList64 = new ImageList();
//			imageList64.ImageSize = new System.Drawing.Size(64, 64);
			imageList64.ImageSize = new System.Drawing.Size(32, 32);
			imageList64.TransparentColor = System.Drawing.Color.Transparent;
			imageList16 = new ImageList();
			imageList16.ImageSize = new System.Drawing.Size(16, 16);
			imageList16.TransparentColor = System.Drawing.Color.Transparent;
			
			imageList64.Images.Add(System.Drawing.SystemIcons.WinLogo);
			imageList16.Images.Add(System.Drawing.SystemIcons.WinLogo);

//			string[] s�t�@�C�� = Directory.GetFiles("icon\\", "*.ico");
// ���� 2005.05.09 DEL 2005.05.06 ���s�j���� �A�C�R���I���̏C�� START
			string[] s�t�@�C�� = Directory.GetFiles(gs�A�v���t�H���_ + "\\icon\\", "*.ico");
			s�A�C�R�� = new string[s�t�@�C��.Length + 1];
			s�A�C�R��[0] = "";
// ���� 2005.05.09 DEL 2005.05.06 ���s�j���� �A�C�R���I���̏C�� END  
// ADD 2005.05.25 ���s�j���� �A�C�R���I����ʂ̕\�����A[.ico]��\�� START
			s�A�C�R���ꗗ = new string[s�t�@�C��.Length + 1];
			s�A�C�R���ꗗ[0] = "";
// ADD 2005.05.25 ���s�j���� �A�C�R���I����ʂ̕\�����A[.ico]��\�� END

			h�A�C�R�� = new Hashtable();

			for(int iCnt = 1; iCnt < s�A�C�R��.Length; iCnt++)
			{
// ���� 2005.05.09 MOD 2005.05.06 ���s�j���� �A�C�R���I���̏C�� START
				int iLastPath = s�t�@�C��[iCnt - 1].LastIndexOf('\\');
				if(iLastPath >= 0)
					s�A�C�R��[iCnt] = s�t�@�C��[iCnt - 1].Substring(iLastPath + 1);
				else
					s�A�C�R��[iCnt] = s�t�@�C��[iCnt - 1];

				h�A�C�R��.Add(s�A�C�R��[iCnt],iCnt);
// ADD 2005.05.25 ���s�j���� �A�C�R���I����ʂ̕\�����A[.ico]��\�� START
				int iLastExt = s�A�C�R��[iCnt].LastIndexOf(".");
				if(iLastExt > 0)
					s�A�C�R���ꗗ[iCnt] = s�A�C�R��[iCnt].Substring(0,iLastExt);
				else
					s�A�C�R���ꗗ[iCnt] = s�A�C�R��[iCnt];
// ADD 2005.05.25 ���s�j���� �A�C�R���I����ʂ̕\�����A[.ico]��\�� END
// ADD 2005.06.03 ���s�j���� �A�C�R���I����ʂ̕\�����A�擪�R������\�� START
				if(s�A�C�R���ꗗ[iCnt].Length > 3)
					s�A�C�R���ꗗ[iCnt] = s�A�C�R���ꗗ[iCnt].Substring(3);
// ADD 2005.06.03 ���s�j���� �A�C�R���I����ʂ̕\�����A�擪�R������\�� END

				imageList64.Images.Add(Image.FromFile(s�t�@�C��[iCnt - 1]));
				imageList16.Images.Add(Image.FromFile(s�t�@�C��[iCnt - 1]));
//				h�A�C�R��.Add(s�A�C�R��[iCnt],iCnt);
//				imageList64.Images.Add(Image.FromFile(gs�A�v���t�H���_ + "\\icon\\" + s�A�C�R��[iCnt]));
//				imageList16.Images.Add(Image.FromFile(gs�A�v���t�H���_ + "\\icon\\" + s�A�C�R��[iCnt]));
// ���� 2005.05.09 MOD 2005.05.06 ���s�j���� �A�C�R���I���̏C�� END  
			}
		}

		protected static int �A�C�R���C���[�W�̎擾(string s�t�@�C����)
		{
			object obj = h�A�C�R��[s�t�@�C����];
			if(obj == null) return 0;

			return (int)obj;
		}

		protected static void ����A�C�R���̏�����()
		{
			if(imageList���� != null) return;

			imageList���� = new ImageList();
			imageList����.ImageSize = new System.Drawing.Size(32, 32);
			imageList����.TransparentColor = System.Drawing.Color.Transparent;
// MOD 2005.05.06 ���s�j���� �A�C�R���I���̏C�� START
//			imageList����.Images.Add(Image.FromFile(gs�A�v���t�H���_ + "\\img\\Icon0002.ico"));
// MOD 2005.05.09 ���s�j���� ����A�C�R���̃t�H���_�ύX START
//			imageList����.Images.Add(Image.FromFile(gs�A�v���t�H���_ + "\\icon\\Icon0002.ico"));
			imageList����.Images.Add(Image.FromFile(gs�A�v���t�H���_ + "\\bumon\\Icon0002.ico"));
// MOD 2005.05.09 ���s�j���� ����A�C�R���̃t�H���_�ύX END
// MOD 2005.05.06 ���s�j���� �A�C�R���I���̏C�� END  
		}

		protected static byte[] toSJIS(string s�f�[�^)
		{
			byte[] bSJIS;

// MOD 2010.06.01 ���s�j���� �t�@�C���o�͎��̉��s�̕ύX START
//			bSJIS = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(s�f�[�^ + "\n");
			bSJIS = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(s�f�[�^ + "\r\n");
// MOD 2010.06.01 ���s�j���� �t�@�C���o�͎��̉��s�̕ύX END
			return bSJIS;
		}

		private void InitializeComponent()
		{
			// 
			// ���ʃt�H�[��
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "���ʃt�H�[��";

		}
		
// ADD 2006.10.10 ���s�j���� �r�`�s�n���v�����^��Q�Ή� START
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
//		protected static string �����o�^�O�v�����^�`�F�b�N()
		protected string �����o�^�O�v�����^�`�F�b�N()
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
		{
			string s�v�����^��� = "";
			string sPrinter = "";
			int iCnt = 0;

			// �v�����^�ݒ�̑��݃`�F�b�N
			for(iCnt = 0; iCnt < PrinterSettings.InstalledPrinters.Count; iCnt++)
			{
				sPrinter = PrinterSettings.InstalledPrinters[iCnt];

//�ۗ� ADD 2008.06.12 ���s�j���� �s�d�b���v�����^�Ή� START
//				//�s�d�b���T�[�}���v�����^�i�t�r�a�j
//				if(sPrinter.IndexOf("B-SV4-JP") >= 0)
//				{
//					pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
//					if(pd�T�[�}���v�����^.PrinterSettings.IsValid)
//					{
//						s�v�����^��� = "S0003";
//						break;
//					}
//				}
//�ۗ� ADD 2008.06.12 ���s�j���� �s�d�b���v�����^�Ή� END  

// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� START
				//�r�`�s�n���T�[�}���v�����^�iCS408T�j
// MOD 2013.10.22 BEVAS�j���� �r�`�s�n���v�����^(CS408T)�v�����^���������Ή� START
//				if(sPrinter.IndexOf("CS408T") >= 0)
				if(sPrinter.IndexOf("CS408T") >= 0 || sPrinter.IndexOf("cs408t") >= 0)
// MOD 2013.10.22 BEVAS�j���� �r�`�s�n���v�����^(CS408T)�v�����^���������Ή� END
				{
					pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
					if(pd�T�[�}���v�����^.PrinterSettings.IsValid)
					{
						s�v�����^��� = "S0005";
						break;
					}
				}
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� END

// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� START
				//�r�`�s�n���T�[�}���v�����^�iCS408T�j
				// MOD 2013.04.11 TDI�j�j�V �v�����^���������Ή� START
				//if(sPrinter.IndexOf("CF408T") >= 0)
				if(sPrinter.IndexOf("CF408T") >= 0 || sPrinter.IndexOf("cf408") >= 0)
				// MOD 2013.04.11 TDI�j�j�V �v�����^���������Ή� END
				{
					pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
					if(pd�T�[�}���v�����^.PrinterSettings.IsValid)
					{
						s�v�����^��� = "S0006";
						break;
					}
				}
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� END
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� START
				//�s�d�b���T�[�}���v�����^�iB-EV4�j
				if(sPrinter.IndexOf("B-EV4-G-Fukuyama") >= 0 || sPrinter.IndexOf("b-ev4-g-fukuyama") >= 0)
				{
					pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
					if(pd�T�[�}���v�����^.PrinterSettings.IsValid)
					{
						s�v�����^��� = "S0007";
						break;
					}
				}
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� END
// MOD 2015.02.12 BEVAS�j�O�c �s�d�b���v�����^(B-LV4)�Ή� START
				//�s�d�b���T�[�}���v�����^�iB-LV4�j
				if(sPrinter.IndexOf("B-LV4-G-Fukuyama") >= 0 || sPrinter.IndexOf("b-lv4-g-fukuyama") >= 0)
				{
					pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
					if(pd�T�[�}���v�����^.PrinterSettings.IsValid)
					{
						s�v�����^��� = "S0008";
						break;
					}
				}
// MOD 2015.02.12 BEVAS�j�O�c �s�d�b���v�����^(B-LV4)�Ή� END

				//�r�`�s�n���T�[�}���v�����^�i�t�r�a�j
				if(sPrinter.IndexOf("ڽ��؃�") >= 0)
				{
					pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
					if(pd�T�[�}���v�����^.PrinterSettings.IsValid)
					{
						s�v�����^��� = "S0002";
						break;
					}
				}

				//�y�d�a�q�`���T�[�}���v�����^�i�t�r�a�j
				if(sPrinter.IndexOf("LP2844") >= 0)
				{
					pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
					if(pd�T�[�}���v�����^.PrinterSettings.IsValid)
					{
						s�v�����^��� = "S0001";
					}
				}

			}

			// ���[�J���ڑ��̃v�����^�����݂��Ȃ��ꍇ
			// �l�b�g���[�N�̋��L�v�����^����������
			if(iCnt == PrinterSettings.InstalledPrinters.Count)
			{
				// �l�b�g���[�N���L�v�����^[ZebraLP2]�̌���
				for(iCnt = 0; iCnt < PrinterSettings.InstalledPrinters.Count; iCnt++)
				{
					sPrinter = PrinterSettings.InstalledPrinters[iCnt];
//�ۗ� ADD 2008.06.12 ���s�j���� �s�d�b���v�����^�Ή� START
//					//�s�d�b���T�[�}���v�����^�i�t�r�a�j
//					if(sPrinter.IndexOf("TECB-SV4") >= 0)
//					{
//						pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
//						if(pd�T�[�}���v�����^.PrinterSettings.IsValid)
//						{
//							s�v�����^��� = "S0003";
//							break;
//						}
//					}
//�ۗ� ADD 2008.06.12 ���s�j���� �s�d�b���v�����^�Ή� END

// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� START
					//�r�`�s�n���T�[�}���v�����^�iCS408T�j
// MOD 2013.10.22 BEVAS�j���� �r�`�s�n���v�����^(CS408T)�v�����^���������Ή� START
//					if(sPrinter.IndexOf("SATOCS40") >= 0)
					if(sPrinter.IndexOf("SATOCS40") >= 0 || sPrinter.IndexOf("satocs40") >= 0)
// MOD 2013.10.22 BEVAS�j���� �r�`�s�n���v�����^(CS408T)�v�����^���������Ή� END
					{
						pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
						if(pd�T�[�}���v�����^.PrinterSettings.IsValid)
						{
							s�v�����^��� = "S0005";
							break;
						}
					}
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� END

// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� START
					//�r�`�s�n���T�[�}���v�����^�iCS408T�j
					// MOD 2013.04.11 TDI�j�j�V �v�����^���������Ή� START
					//if(sPrinter.IndexOf("SATOCF40") >= 0)
					if(sPrinter.IndexOf("SATOCF40") >= 0 || sPrinter.IndexOf("satocf40") >= 0)
					// MOD 2013.04.11 TDI�j�j�V �v�����^���������Ή� END 
					{
						pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
						if(pd�T�[�}���v�����^.PrinterSettings.IsValid)
						{
							s�v�����^��� = "S0006";
							break;
						}
					}
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� END
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� START
					//�s�d�b���T�[�}���v�����^�iB-EV4�j
					if(sPrinter.IndexOf("TECB-EV4") >= 0 || sPrinter.IndexOf("tecb-ev4") >= 0)
					{
						pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
						if(pd�T�[�}���v�����^.PrinterSettings.IsValid)
						{
							s�v�����^��� = "S0007";
							break;
						}
					}
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� END
// MOD 2015.02.12 BEVAS�j�O�c �s�d�b���v�����^(B-LV4)�Ή� START
					//�s�d�b���T�[�}���v�����^�iB-LV4�j
					if(sPrinter.IndexOf("TECB-LV4") >= 0 || sPrinter.IndexOf("tecb-lv4") >= 0 
						|| sPrinter.IndexOf("TEC B-LV4") >= 0 || sPrinter.IndexOf("tec b-lv4") >= 0)
					{
						pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
						if(pd�T�[�}���v�����^.PrinterSettings.IsValid)
						{
							s�v�����^��� = "S0008";
							break;
						} 
					}
// MOD 2015.02.12 BEVAS�j�O�c �s�d�b���v�����^(B-LV4)�Ή� END

					//�r�`�s�n���T�[�}���v�����^�i�t�r�a�j
					if(sPrinter.IndexOf("SATOڽ��") >= 0)
					{
						pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
						if(pd�T�[�}���v�����^.PrinterSettings.IsValid)
						{
							s�v�����^��� = "S0002";
							break;
						}
					}

					//�y�d�a�q�`���T�[�}���v�����^�i�t�r�a�j
					if(sPrinter.IndexOf("ZebraLP2") >= 0)
					{
						pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
						if(pd�T�[�}���v�����^.PrinterSettings.IsValid)
						{
							s�v�����^��� = "S0001";
						}
					}
				}
			}
//			if(iCnt == PrinterSettings.InstalledPrinters.Count)
			if(s�v�����^���.Length == 0)
				throw new Exception("�v�����^���g�p�ł��܂���B");

			return s�v�����^���;
		}
// ADD 2006.10.10 ���s�j���� �r�`�s�n���v�����^��Q�Ή� END

// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
//		protected static void �v�����^�`�F�b�N()
		protected void �v�����^�`�F�b�N()
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
		{
// ADD 2006.07.19 ���s�j���� �s�d�b���v�����^�Ή� START
			�v�����^�`�F�b�N(gs�v�����^���);
		}

// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� START
//// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
////		protected static void �v�����^�`�F�b�N(string gs�v�����^���)
//		protected void �v�����^�`�F�b�N(string gs�v�����^���)
//// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
//		{
//// ADD 2006.08.10 ���s�j���� �h�b�^�O�Ή��r�`�s�n���v�����^�Ή� START
//			if(gs�v�����^��� == "S0004") return;
//// ADD 2006.08.10 ���s�j���� �h�b�^�O�Ή��r�`�s�n���v�����^�Ή� END
		protected string �v�����^�`�F�b�N(string gs�v�����^���)
		{
			string sRtn�v�����^��� = gs�v�����^���;
			if(gs�v�����^��� == "S0004"){
				return sRtn�v�����^���;
			}
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� END

// ADD 2006.07.19 ���s�j���� �s�d�b���v�����^�Ή� END

			//�v�����^�̎擾
// MOD 2006.06.20 ���s�j���� �r�`�s�n���v�����^�Ή� START
//			pd�T�[�}���v�����^.PrinterSettings.PrinterName = "Zebra  LP2844";
			if(gs�v�����^��� == "S0002")
			{
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� START
//				//�r�`�s�n���T�[�}���v�����^�i�t�r�a�j
//				pd�T�[�}���v�����^.PrinterSettings.PrinterName = "SATO ڽ��؃�";
				//�r�`�s�n���T�[�}���v�����^�iCS408T�j
				pd�T�[�}���v�����^.PrinterSettings.PrinterName = "SATO CS408T";
				if(pd�T�[�}���v�����^.PrinterSettings.IsValid == true){
					sRtn�v�����^��� = "S0005";
				}
				else{
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� START
//					//�r�`�s�n���T�[�}���v�����^�i�t�r�a�j
					pd�T�[�}���v�����^.PrinterSettings.PrinterName = "SATO CF408T";
					if(pd�T�[�}���v�����^.PrinterSettings.IsValid == true)
					{
						sRtn�v�����^��� = "S0006";
					}
					else
					{
						pd�T�[�}���v�����^.PrinterSettings.PrinterName = "SATO ڽ��؃�";
					}
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� END
				}
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� END
			}
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� START
			else if(gs�v�����^��� == "S0005")
			{
				//�r�`�s�n���T�[�}���v�����^�iCS408T�j
				pd�T�[�}���v�����^.PrinterSettings.PrinterName = "SATO CS408T";
			}
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� END
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� START
			else if(gs�v�����^��� == "S0006")
			{
				//�r�`�s�n���T�[�}���v�����^�iCF408T�j
				pd�T�[�}���v�����^.PrinterSettings.PrinterName = "SATO CF408T";
			}
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� END
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� START
			else if(gs�v�����^��� == "S0007")
			{
// MOD 2015.02.12 BEVAS�j�O�c �s�d�b���v�����^(B-LV4)�Ή� START
				//�s�d�b���T�[�}���v�����^�iB-EV4�j���邢��B-LV4�̂ǂ��炩�𔻒�
				pd�T�[�}���v�����^.PrinterSettings.PrinterName = "TEC B-LV4-G-Fukuyama";
				if(pd�T�[�}���v�����^.PrinterSettings.IsValid == true)
				{
					sRtn�v�����^��� = "S0008"; // TEC��B-LV4�Ƃ��ĔF������
				}
				else
				{
					//�s�d�b���T�[�}���v�����^�iB-EV4�j
					pd�T�[�}���v�����^.PrinterSettings.PrinterName = "TEC B-EV4-G-Fukuyama";
				}


				////�s�d�b���T�[�}���v�����^�iB-EV4�j
				//pd�T�[�}���v�����^.PrinterSettings.PrinterName = "TEC B-EV4-G-Fukuyama";
// MOD 2015.02.12 BEVAS�j�O�c �s�d�b���v�����^(B-LV4)�Ή� END
			}
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� END

//�ۗ� ADD 2008.06.12 ���s�j���� �s�d�b���v�����^�Ή� START
//			else if(gs�v�����^��� == "S0003")
//			{
//				//�s�d�b���T�[�}���v�����^�i�t�r�a�j
//				pd�T�[�}���v�����^.PrinterSettings.PrinterName = "TEC B-SV4-JP";
//			}
//�ۗ� ADD 2008.06.12 ���s�j���� �s�d�b���v�����^�Ή� END  
			else
			{
				//�y�d�a�q�`���T�[�}���v�����^�i�t�r�a�j
				pd�T�[�}���v�����^.PrinterSettings.PrinterName = "Zebra  LP2844";
			}
// MOD 2006.06.20 ���s�j���� �r�`�s�n���v�����^�Ή� END
			if (pd�T�[�}���v�����^.PrinterSettings.IsValid == false)
			{
// MOD 2005.06.13 ���s�j���� �v�����^�`�F�b�N�̊g�� START
//				throw new Exception("�v�����^���g�p�ł��܂���B");
				string sPrinter = "";
				int iCnt = 0;
				// �v�����^[LP2844]�̌���
				for(iCnt = 0; iCnt < PrinterSettings.InstalledPrinters.Count; iCnt++)
				{
					sPrinter = PrinterSettings.InstalledPrinters[iCnt];
// ADD 2006.06.20 ���s�j���� �r�`�s�n���v�����^�Ή� START
					if(gs�v�����^��� == "S0002")
					{
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� START
						//�r�`�s�n���T�[�}���v�����^�i�t�r�a�j
// MOD 2013.10.22 BEVAS�j���� �r�`�s�n���v�����^(CS408T)�v�����^���������Ή�
//						if(sPrinter.IndexOf("CS408T") >= 0)
						if(sPrinter.IndexOf("CS408T") >= 0 || sPrinter.IndexOf("cs408t") >= 0)
// MOD 2013.10.22 BEVAS�j���� �r�`�s�n���v�����^(CS408T)�v�����^���������Ή�
						{
							pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
							if(pd�T�[�}���v�����^.PrinterSettings.IsValid)
							{
								sRtn�v�����^��� = "S0005";
								break;
							}
						}
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� END
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� START
						//�r�`�s�n���T�[�}���v�����^�i�t�r�a�j
						// MOD 2013.04.11 TDI�j�j�V �v�����^���������Ή� START
						//if(sPrinter.IndexOf("CF408T") >= 0)
						if(sPrinter.IndexOf("CF408T") >= 0 || sPrinter.IndexOf("cf408t") >= 0)
						// MOD 2013.04.11 TDI�j�j�V �v�����^���������Ή� END
						{
							pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
							if(pd�T�[�}���v�����^.PrinterSettings.IsValid)
							{
								sRtn�v�����^��� = "S0006";
								break;
							}
						}
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� END


						//�r�`�s�n���T�[�}���v�����^�i�t�r�a�j
						if(sPrinter.IndexOf("ڽ��؃�") >= 0)
						{
							pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
							if(pd�T�[�}���v�����^.PrinterSettings.IsValid) break;
						}
						continue;
					}
// ADD 2006.06.20 ���s�j���� �r�`�s�n���v�����^�Ή� END
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� START
					else if(gs�v�����^��� == "S0005")
					{
						//�r�`�s�n���T�[�}���v�����^�iCS408T�j
// MOD 2013.10.22 BEVAS�j���� �r�`�s�n���v�����^(CS408T)�v�����^���������Ή� START
//						if(sPrinter.IndexOf("CS408T") >= 0)
						if(sPrinter.IndexOf("CS408T") >= 0 || sPrinter.IndexOf("cs408t") >= 0)
// MOD 2013.10.22 BEVAS�j���� �r�`�s�n���v�����^(CS408T)�v�����^���������Ή� END
						{
							pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
							if(pd�T�[�}���v�����^.PrinterSettings.IsValid) break;
						}
						continue;
					}
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� END
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� START
					else if(gs�v�����^��� == "S0006")
					{
						//�r�`�s�n���T�[�}���v�����^�iCF408T�j
						// MOD 2013.04.11 TDI�j�j�V �v�����^���������Ή� START
						//if(sPrinter.IndexOf("CF408T") >= 0)
						if(sPrinter.IndexOf("CF408T") >= 0 || sPrinter.IndexOf("cf408t") >= 0)
						// MOD 2013.04.11 TDI�j�j�V �v�����^���������Ή� END
						{
							pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
							if(pd�T�[�}���v�����^.PrinterSettings.IsValid) break;
						}
						continue;
					}
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� END
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� START
					else if(gs�v�����^��� == "S0007")
					{
						//�s�d�b���T�[�}���v�����^�iB-EV4-G�j
						if(sPrinter.IndexOf("B-EV4-G-Fukuyama") >= 0 || sPrinter.IndexOf("b-ev4-g-fukuyama") >= 0)
						{
							pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
							if(pd�T�[�}���v�����^.PrinterSettings.IsValid) break;
						}
						continue;
					}
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� END
// MOD 2015.02.12 BEVAS�j�O�c �s�d�b���v�����^(B-LV4)�Ή� START
					else if(gs�v�����^��� == "S0008")
					{
						//�s�d�b���T�[�}���v�����^�iB-LV4-G�j
						if(sPrinter.IndexOf("B-LV4-G-Fukuyama") >= 0 || sPrinter.IndexOf("b-lv4-g-fukuyama") >= 0)
						{
							pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
							if(pd�T�[�}���v�����^.PrinterSettings.IsValid) break;
						}
						continue;
					}
// MOD 2015.02.12 BEVAS�j�O�c �s�d�b���v�����^(B-LV4)�Ή� END
//�ۗ� ADD 2008.06.12 ���s�j���� �s�d�b���v�����^�Ή� START
//					else if(gs�v�����^��� == "S0003")
//					{
//						//�s�d�b���T�[�}���v�����^�i�t�r�a�j
//						if(sPrinter.IndexOf("B-SV4-JP") >= 0)
//						{
//							pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
//							if(pd�T�[�}���v�����^.PrinterSettings.IsValid) break;
//						}
//						continue;
//					}
//�ۗ� ADD 2008.06.12 ���s�j���� �s�d�b���v�����^�Ή� END
// ADD 2006.10.10 ���s�j���� �r�`�s�n���v�����^��Q�Ή� START
// MOD 2006.10.13 ���s�j���� �r�`�s�n���v�����^��Q�Ή� START
//					else if(gs�v�����^��� == "S0001")
					else
// MOD 2006.10.13 ���s�j���� �r�`�s�n���v�����^��Q�Ή� END
					{
// ADD 2006.10.10 ���s�j���� �r�`�s�n���v�����^��Q�Ή� END
						//�y�d�a�q�`���T�[�}���v�����^�i�t�r�a�j
						if(sPrinter.IndexOf("LP2844") >= 0)
						{
							pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
							if(pd�T�[�}���v�����^.PrinterSettings.IsValid) break;
						}
// ADD 2006.10.10 ���s�j���� �r�`�s�n���v�����^��Q�Ή� START
					}
// ADD 2006.10.10 ���s�j���� �r�`�s�n���v�����^��Q�Ή� END
				}

				// ���[�J���ڑ��̃v�����^�����݂��Ȃ��ꍇ
				// �l�b�g���[�N�̋��L�v�����^����������
				if(iCnt == PrinterSettings.InstalledPrinters.Count)
				{
					// �l�b�g���[�N���L�v�����^[ZebraLP2]�̌���
					for(iCnt = 0; iCnt < PrinterSettings.InstalledPrinters.Count; iCnt++)
					{
						sPrinter = PrinterSettings.InstalledPrinters[iCnt];
// ADD 2006.10.10 ���s�j���� �r�`�s�n���v�����^��Q�Ή� START
						//�r�`�s�n���T�[�}���v�����^�i�t�r�a�j
						if(gs�v�����^��� == "S0002")
						{
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� START
// MOD 2013.10.22 BEVAS�j���� �r�`�s�n���v�����^(CS408T)�v�����^���������Ή� START
//							if(sPrinter.IndexOf("SATOCS40") >= 0)
							if(sPrinter.IndexOf("SATOCS40") >= 0 || sPrinter.IndexOf("satocs40") >= 0)
// MOD 2013.10.22 BEVAS�j���� �r�`�s�n���v�����^(CS408T)�v�����^���������Ή� END
							{
								pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
								if(pd�T�[�}���v�����^.PrinterSettings.IsValid)
								{
									sRtn�v�����^��� = "S0005";
									break;
								}
							}
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� END
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� START
							// MOD 2013.04.11 TDI�j�j�V �v�����^���������Ή� START
							//if(sPrinter.IndexOf("SATOCF40") >= 0)
							if(sPrinter.IndexOf("SATOCF40") >= 0 || sPrinter.IndexOf("satocf40") >= 0)
							// MOD 2013.04.11 TDI�j�j�V �v�����^���������Ή� END
							{
								pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
								if(pd�T�[�}���v�����^.PrinterSettings.IsValid)
								{
									sRtn�v�����^��� = "S0006";
									break;
								}
							}
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� END

							if(sPrinter.IndexOf("SATOڽ��") >= 0)
							{
								pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
								if(pd�T�[�}���v�����^.PrinterSettings.IsValid) break;
							}
							continue;
						}
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� START
						//�r�`�s�n���T�[�}���v�����^�iCS408T�j
						else if(gs�v�����^��� == "S0005")
						{
// MOD 2013.10.22 BEVAS�j���� �r�`�s�n���v�����^(CS408T)�v�����^���������Ή� START
//							if(sPrinter.IndexOf("SATOCS40") >= 0)
							if(sPrinter.IndexOf("SATOCS40") >= 0 || sPrinter.IndexOf("satocs40") >= 0)
// MOD 2013.10.22 BEVAS�j���� �r�`�s�n���v�����^(CS408T)�v�����^���������Ή� END
							{
								pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
								if(pd�T�[�}���v�����^.PrinterSettings.IsValid) break;
							}
							continue;
						}
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� END
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� START
						//�r�`�s�n���T�[�}���v�����^�iCF408T�j
						else if(gs�v�����^��� == "S0006")
						{
							// MOD 2013.04.11 TDI�j�j�V �v�����^���������Ή� START
							//if(sPrinter.IndexOf("SATOCF40") >= 0)
							if(sPrinter.IndexOf("SATOCF40") >= 0 || sPrinter.IndexOf("satocf40") >= 0)
							// MOD 2013.04.11 TDI�j�j�V �v�����^���������Ή� END
							{
								pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
								if(pd�T�[�}���v�����^.PrinterSettings.IsValid) break;
							}
							continue;
						}
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� END
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� START
						else if(gs�v�����^��� == "S0007")
						{
							//�s�d�b���T�[�}���v�����^�iB-EV4�j
							if(sPrinter.IndexOf("B-EV4-G-Fukuyama") >= 0 || sPrinter.IndexOf("b-ev4-g-fukuyama") >= 0)
							{
								pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
								if(pd�T�[�}���v�����^.PrinterSettings.IsValid) break;
							} 
// ADD 2015.02.12 BEVAS�j�O�c �s�d�b���v�����^(B-LV4)�Ή� START
							//�s�d�b���T�[�}���v�����^�iB-LV4�j
							else if(sPrinter.IndexOf("B-LV4-G-Fukuyama") >= 0 || sPrinter.IndexOf("b-lv4-g-fukuyama") >= 0)
							{
								pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
								if(pd�T�[�}���v�����^.PrinterSettings.IsValid) 
								{
									gs�v�����^��� = "S0008";
									break;
								}
							}
// ADD 2015.02.12 BEVAS�j�O�c �s�d�b���v�����^(B-LV4)�Ή� END
							continue;
						}
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� END
//�ۗ� ADD 2008.06.12 ���s�j���� �s�d�b���v�����^�Ή� START
//						else if(gs�v�����^��� == "S0003")
//						{
//							//�s�d�b���T�[�}���v�����^�i�t�r�a�j
//							if(sPrinter.IndexOf("TECB-SV4") >= 0)
//							{
//								pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
//								if(pd�T�[�}���v�����^.PrinterSettings.IsValid) break;
//							}
//							continue;
//						}
//�ۗ� ADD 2008.06.12 ���s�j���� �s�d�b���v�����^�Ή� END
// MOD 2006.10.13 ���s�j���� �r�`�s�n���v�����^��Q�Ή� START
//						else if(gs�v�����^��� == "S0001")
						else
// MOD 2006.10.13 ���s�j���� �r�`�s�n���v�����^��Q�Ή� END
						{
// ADD 2006.10.10 ���s�j���� �r�`�s�n���v�����^��Q�Ή� END
							if(sPrinter.IndexOf("ZebraLP2") >= 0)
							{
								pd�T�[�}���v�����^.PrinterSettings.PrinterName = sPrinter;
								if(pd�T�[�}���v�����^.PrinterSettings.IsValid) break;
							}
// ADD 2006.10.10 ���s�j���� �r�`�s�n���v�����^��Q�Ή� END
						}
// ADD 2006.10.10 ���s�j���� �r�`�s�n���v�����^��Q�Ή� END
					}
				}
				if(iCnt == PrinterSettings.InstalledPrinters.Count) 
					throw new Exception("�v�����^���g�p�ł��܂���B");
// MOD 2005.06.13 ���s�j���� �v�����^�`�F�b�N�̊g�� END
			}

//�ۗ� DEL 2009.02.06 ���s�j���� ���x���p���T�C�Y��`�`�F�b�N�̔p�~ START
// ADD 2006.10.10 ���s�j���� �r�`�s�n���v�����^��Q�Ή� START
			//�p���T�C�Y�̃`�F�b�N�́A�y�d�a�q�`�̎��ȊO�͍s��Ȃ��B
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� START
//			if(gs�v�����^��� != "S0001") return;
			if(gs�v�����^��� != "S0001"){
				return sRtn�v�����^���;
			}
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� END
// ADD 2006.10.10 ���s�j���� �r�`�s�n���v�����^��Q�Ή� END

			//�p���T�C�Y�̃`�F�b�N
			if (pd�T�[�}���v�����^.DefaultPageSettings.PaperSize.Width != 425 
				|| pd�T�[�}���v�����^.DefaultPageSettings.PaperSize.Height != 651)
			{
				throw new Exception("�p���T�C�Y���Ⴂ�܂��B\r\n��10.80cm �c16.54cm�ɐݒ肵�Ă��������B");
			}
//�ۗ� DEL 2009.02.06 ���s�j���� ���x���p���T�C�Y��`�`�F�b�N�̔p�~ END
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� START
			return sRtn�v�����^���;
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� END
		}

// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� START
//// ADD 2007.03.28 ���s�j���� �W�דX�擾�G���[�Ή� START
//		protected static void ���p�ҕ���X���擾()
//		{
//			try
//			{
//				// ���p�ҏ��擾�̎擾�i���p�Җ��A������A��������j
//				if(sv_init == null) sv_init = new is2init.Service1();
//				String[] sRet = sv_init.Get_hatuten3(gsa���[�U,gs����b�c,gs���p�ҕ���b�c);
//				if(sRet[0].Length != 4)
//				{
//					�r�[�v��();
//					MessageBox.Show(sRet[0],
//						"���p�ҏW�דX�擾", 
//						MessageBoxButtons.OK, MessageBoxIcon.Error);
//					return;
//				}
//
//				gs���p�ҕ���X��     = sRet[1];
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
//// ADD 2007.03.28 ���s�j���� �W�דX�擾�G���[�Ή� END
		protected static string ����X���擾(string s����b�c)
		{
			try{
				// ����X���̎擾
				if(sv_init == null) sv_init = new is2init.Service1();
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� START
//				String[] sRet = sv_init.Get_hatuten3(gsa���[�U, gs����b�c, s����b�c);
				if(sv_oji == null) sv_oji = new is2oji.Service1();
				String[] sRet;
				if (gs����b�c.Substring(0,1) != "J")
				{
					sRet = sv_init.Get_hatuten3(gsa���[�U, gs����b�c, s����b�c);

				}
				else
				{
					sRet = sv_oji.Get_hatuten3(gsa���[�U, gs����b�c, s����b�c);
				}
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END

				if(sRet[0].Length != 4)
				{
					�r�[�v��();
					MessageBox.Show(sRet[0],
						"�W�דX�擾", 
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}else{
					return sRet[1];
				}
			}catch(System.Net.WebException){
				�r�[�v��();
				MessageBox.Show(gs�ʐM�G���[, 
					"�ʐM�G���[", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}catch(Exception ex){
				�r�[�v��();
				MessageBox.Show(ex.Message, 
					"�ʐM�G���[", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return "";
		}
// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� END

// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
//		protected static void ��������w��(string[] sData)
		protected void ��������w��(string[] sData)
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
// ADD 2008.03.19 ���s�j���� �ʍĔ��s�@�\�̒ǉ� START
		{
			��������w��(sData, 1, 99);
		}
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
//		protected static void ��������w��(string[] sData, int i�J�n, int i�I��)
		protected void ��������w��(string[] sData, int i�J�n, int i�I��)
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
// ADD 2008.03.19 ���s�j���� �ʍĔ��s�@�\�̒ǉ� END
		{
			gb��� = true;
			try
			{
				if(sv_print == null) sv_print = new is2print.Service1();

				//����f�[�^�̍쐬
// MOD 2011.03.25 ���s�j���� �����ԍ��̏㏑���h�~ START
//				String[] sPrintKey = new string[4];
//				sPrintKey[0] = gs����b�c;
//				sPrintKey[1] = gs����b�c;
//				sPrintKey[2] = sData[0];
//				sPrintKey[3] = sData[1];
				//���O�C�����ɒS���W�דX�b�c���擾����Ă��Ȃ��ꍇ�ɂ́A
				if(gs���p�ҕ���X���b�c == null || gs���p�ҕ���X���b�c.Length == 0){
					gs���p�ҕ���X���b�c = "";
					gs���p�ҕ���X���b�c = ����X���擾(gs���p�ҕ���b�c);
				}
				string[] sPrintKey = new string[]{
					gs����b�c
					, gs����b�c
					, sData[0]
					, sData[1]
					, gs���p�ҕ���X���b�c
				};
// MOD 2011.03.25 ���s�j���� �����ԍ��̏㏑���h�~ END
				
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� START
//				String[] sPrintData = sv_print.Get_InvoicePrintData(gsa���[�U,sPrintKey);
				if(sv_oji == null) sv_oji = new is2oji.Service1();
				String[] sPrintData;
				if (gs����b�c.Substring(0,1) != "J")
				{
					sPrintData = sv_print.Get_InvoicePrintData(gsa���[�U,sPrintKey);
				}
				else
				{
					sPrintData = sv_oji.Get_InvoicePrintData(gsa���[�U,sPrintKey);
				}
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END
				
				if (!sPrintData[0].Equals("����I��"))
				{
					throw new Exception(sPrintData[0]);
				}
// ADD 2007.03.28 ���s�j���� �W�דX�擾�G���[�Ή� START
				//���O�C�����ɒS���W�דX�b�c���擾����Ă��Ȃ��ꍇ�ɂ́A
				if(gs���p�ҕ���X���b�c == null || gs���p�ҕ���X���b�c.Length == 0)
				{
// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� START
//					���p�ҕ���X���擾();
					gs���p�ҕ���X���b�c = ����X���擾(gs���p�ҕ���b�c);
// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� END
				}
				//�S���W�דX�b�c���擾�ł��Ȃ��ꍇ�ɂ́A�X���[������
				if(gs���p�ҕ���X���b�c == null || gs���p�ҕ���X���b�c.Length == 0)
				{
//					gb��� = false;
//					throw new Exception("�S���X�����̎擾�Ɏ��s���܂���");
				}else{
// ADD 2007.03.28 ���s�j���� �W�דX�擾�G���[�Ή� END
// ADD 2006.12.12 ���s�j�����J �X���ƕ���X�����قȂ�ꍇ�́A������Ȃ� START
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� START
//					if(!gs���p�ҕ���X���b�c.Trim().Equals(sPrintData[14].Trim().Substring(1, 3)))
//					{
//						gb��� = false;
//						return;
//					}
					//�Г��`�̏ꍇ�́A�X���ƕ���X�����قȂ��Ă��悢
					if(!gs���p�ҕ���X���b�c.Equals("044"))
					{
						if(!gs���p�ҕ���X���b�c.Trim().Equals(sPrintData[14].Trim().Substring(1, 3)))
						{
							gb��� = false;
							return;
						}
					}
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� END
// ADD 2006.12.12 ���s�j�����J �X���ƕ���X�����قȂ�ꍇ�́A������Ȃ� END
// ADD 2007.03.28 ���s�j���� �W�דX�擾�G���[�Ή� START
				}
// ADD 2007.03.28 ���s�j���� �W�דX�擾�G���[�Ή� END
				//����󔭍s�̃`�F�b�N
				if (!sPrintData[33].Equals("1")) // ����󔭍s�ςe�f
				{
					//����󂪖����s�̏ꍇ�B�����ԍ��̍̔�
					String[] sGetKey = new string[4];
					sGetKey[0] = gs����b�c;
					sGetKey[1] = gs����b�c;
// MOD 2005.06.07 ���s�j�ɉ� �A�����i�ɂ���Ēl��ύX START
//					sGetKey[2] = sPrintData[32] + "0";	//�����敪 + "0"
					sGetKey[2] = sPrintData[32]; //�����敪 + "0" or "1"
// MOD 2005.06.07 ���s�j�ɉ� �A�����i�ɂ���Ēl��ύX END
// ADD 2007.10.17 ���s�j���� �O���[�o���Ή��i�o�ד��A���X�̔�\���j START
					if(sPrintData[14].Substring(1, 3) == "047"){
						sGetKey[2] = sPrintData[32].Substring(0,1) + "G"; //�����敪 + "G"
					}
// ADD 2007.10.17 ���s�j���� �O���[�o���Ή��i�o�ד��A���X�̔�\���j END
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� START
					if(gs���p�ҕ���X���b�c.Equals("044"))
					{
						sGetKey[2] = sPrintData[32].Substring(0,1) + "F"; //�����敪 + "F"
					}
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� END
					sGetKey[3] = gs���p�҂b�c;
// ADD 2005.05.13 ���s�j�����J �����s�ŏo�ד����ߋ��̂��̂͏o�ד��𓖓��ɂ��� START

// MOD 2010.11.01 ���s�j���� �o�׍ς̏ꍇ�A�o�ד����X�V START
					string s�o�׍ςe�f = (sPrintData.Length >= 40 ? sPrintData[39] : "0");
					if(s�o�׍ςe�f.Equals("0")){
// MOD 2010.11.01 ���s�j���� �o�׍ς̏ꍇ�A�o�ד����X�V END
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX START
//						string s���� = DateTime.Today.ToShortDateString().Replace("/","");
						string s���� = YYYYMMDD�ϊ�(DateTime.Today);
// MOD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX END
						if(int.Parse(sPrintData[10]) < int.Parse(s����))
// MOD 2005.06.10 ���s�j�����J �o�ד��̍X�V START
//							sPrintData[10] = s����;
						{
							sPrintData[10] = s����;

							String[] sKeyData = new string[7];
							sKeyData[0] = gs����b�c;
							sKeyData[1] = gs����b�c;
							sKeyData[2] = sData[0];
							sKeyData[3] = sData[1];
							sKeyData[4] = s����;
							sKeyData[5] = "���ʃt�H";
							sKeyData[6] = gs���p�҂b�c;
							if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
							String[] sSyuData = sv_syukka.Upd_syukkabi(gsa���[�U,sKeyData);
							if (!sSyuData[0].Equals("����I��"))
							{
								throw new Exception(sSyuData[0]);
							}

						}
// MOD 2005.06.10 ���s�j�����J �o�ד��̍X�V END
// ADD 2005.05.13 ���s�j�����J �����s�ŏo�ד����ߋ��̂��̂͏o�ד��𓖓��ɂ��� END
// MOD 2010.11.01 ���s�j���� �o�׍ς̏ꍇ�A�o�ד����X�V START
					}
// MOD 2010.11.01 ���s�j���� �o�׍ς̏ꍇ�A�o�ד����X�V END

					// �����m�n���o�^����Ă��Ȃ��ꍇ
					if (sPrintData[11].Length == 0) // �����ԍ�
					{
						if(sv_print == null) sv_print = new is2print.Service1();
						String[] sGetData = sv_print.Get_InvoiceNo(gsa���[�U,sGetKey);
						if (!sGetData[0].Equals("����I��"))
						{
							throw new Exception(sGetData[0]);
						}
						//�����ԍ��̃Z�b�g
						sPrintData[11] = sGetData[1].PadLeft(14, '0');
						//�`�F�b�N�f�W�b�g�i�V�Ŋ������]��j�̕t��
//						sPrintData[11] = sPrintData[11] + (int.Parse(sPrintData[11]) % 7).ToString();
						sPrintData[11] = sPrintData[11] + (long.Parse(sPrintData[11]) % 7).ToString();
					}

					//�����ԍ��X�V
					//�i�����ԍ��A����󔭍s�ςe�f�A��ԁA���X�̍X�V�j
					String[] sSetKey = new string[6];
					sSetKey[0] = gs����b�c;
					sSetKey[1] = gs����b�c;
					sSetKey[2] = sData[0];       // �o�^��
					sSetKey[3] = sData[1];       // �W���[�i���m�n
					sSetKey[4] = sPrintData[11]; // �����ԍ�
					sSetKey[5] = gs���p�҂b�c;

					if(sv_print == null) sv_print = new is2print.Service1();
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� START
//					String[] sSetData = sv_print.Set_InvoiceNo(gsa���[�U,sSetKey);
					if(sv_oji == null) sv_oji = new is2oji.Service1();
					String[] sSetData;
					if (gs����b�c.Substring(0,1) != "J")
					{
						sSetData = sv_print.Set_InvoiceNo(gsa���[�U,sSetKey);

					}
					else
					{
						sSetData = sv_oji.Set_InvoiceNo(gsa���[�U,sSetKey);
					}
// ADD 2010.12.14 ACT�j�_�� ���q�^���̑Ή� END

					
					if (!sSetData[0].Equals("����I��"))
					{
						throw new Exception(sSetData[0]);
					}
				}

// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
				if(gs�I�v�V����[18].Equals("1"))
				{
					sPrintData[5] = sPrintData[5].TrimEnd(); // �׎�l�Z���P
					sPrintData[6] = sPrintData[6].TrimEnd(); // �׎�l�Z���Q
					sPrintData[7] = sPrintData[7].TrimEnd(); // �׎�l�Z���R
					sPrintData[8] = sPrintData[8].TrimEnd(); // �׎�l���O�P
					sPrintData[9] = sPrintData[9].TrimEnd(); // �׎�l���O�Q

					sPrintData[18] = sPrintData[18].TrimEnd(); // �ב��l�Z���P
					sPrintData[19] = sPrintData[19].TrimEnd(); // �ב��l�Z���Q
					sPrintData[21] = sPrintData[21].TrimEnd(); // �ב��l���O�P
					sPrintData[22] = sPrintData[22].TrimEnd(); // �ב��l���O�Q
					sPrintData[34] = sPrintData[34].TrimEnd(); // �S����
					
					sPrintData[29] = sPrintData[29].TrimEnd(); // �i���L���P
					sPrintData[30] = sPrintData[30].TrimEnd(); // �i���L���Q
					sPrintData[31] = sPrintData[31].TrimEnd(); // �i���L���R
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
					if(sPrintData.Length > 42){
						sPrintData[42] = sPrintData[42].TrimEnd(); // �i���L���S
						sPrintData[43] = sPrintData[43].TrimEnd(); // �i���L���T
						sPrintData[44] = sPrintData[44].TrimEnd(); // �i���L���U
					}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
				}else{
					sPrintData[5] = sPrintData[5].Trim(); // �׎�l�Z���P
					sPrintData[6] = sPrintData[6].Trim(); // �׎�l�Z���Q
					sPrintData[7] = sPrintData[7].Trim(); // �׎�l�Z���R
					sPrintData[8] = sPrintData[8].Trim(); // �׎�l���O�P
					sPrintData[9] = sPrintData[9].Trim(); // �׎�l���O�Q

					sPrintData[18] = sPrintData[18].Trim(); // �ב��l�Z���P
					sPrintData[19] = sPrintData[19].Trim(); // �ב��l�Z���Q
					sPrintData[21] = sPrintData[21].Trim(); // �ב��l���O�P
					sPrintData[22] = sPrintData[22].Trim(); // �ב��l���O�Q
					sPrintData[34] = sPrintData[34].Trim(); // �S����
					
					sPrintData[29] = sPrintData[29].Trim(); // �i���L���P
					sPrintData[30] = sPrintData[30].Trim(); // �i���L���Q
					sPrintData[31] = sPrintData[31].Trim(); // �i���L���R
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
					if(sPrintData.Length > 42){
						sPrintData[42] = sPrintData[42].Trim(); // �i���L���S
						sPrintData[43] = sPrintData[43].Trim(); // �i���L���T
						sPrintData[44] = sPrintData[44].Trim(); // �i���L���U
					}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
				}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END

// ADD 2006.08.10 ���s�j���� �h�b�^�O�Ή��r�`�s�n���v�����^�Ή� START
				if(gs�v�����^��� == "S0004"){
					string s�p�X�� = "C:\\";
					string s�t�@�C���� = "�ו��f�[�^�t�@�C��.csv";
					try
					{
						System.IO.FileStream fs = new FileStream(s�p�X�� + s�t�@�C����, 
							FileMode.Append, FileAccess.Write,FileShare.Read);
						try
						{
							string sCSVData = "";
							for (int iCnt = 0; iCnt < int.Parse(sPrintData[23]); iCnt++)
							{
								int    i�A�� = iCnt + 1;
								string s�A�� = i�A��.ToString();
								string s�ו��ԍ� = sPrintData[11].Substring(4) + s�A��.PadLeft(2, '0');

								//�ו��ԍ�
								sCSVData = s�ו��ԍ�;
								�ו��f�[�^�o��(fs, sCSVData, false);
								//�׎�l�d�b�ԍ�
								sCSVData = "(" + sPrintData[2] + ")" + sPrintData[3] + "-" + sPrintData[4];
// MOD 2010.03.17 ���s�j���� �׎�l�d�b�ԍ���ALL0�ł���Δ�\�� START
// MOD 2010.03.30 ���s�j���� �׎�l�d�b�ԍ���0�ł���Δ�\�� START
//								if(sPrintData[2] == "000000"
//								&& sPrintData[3] == "0000"
//								&& sPrintData[4] == "0000"){
								if(sPrintData[2].Replace("0","").Trim().Length == 0
								&& sPrintData[3].Replace("0","").Trim().Length == 0
								&& sPrintData[4].Replace("0","").Trim().Length == 0){
// MOD 2010.03.30 ���s�j���� �׎�l�d�b�ԍ���0�ł���Δ�\�� END
									sCSVData = " ";
								}
// MOD 2010.03.17 ���s�j���� �׎�l�d�b�ԍ���ALL0�ł���Δ�\�� END
								�ו��f�[�^�o��(fs, sCSVData, false);

								//�׎�l�Z���̓s���{���A�s�撬���A���̑��̕���
								string s�Z���ҏW  = �Z���ҏW(sPrintData[5]);
								string[] s�Z������ = s�Z���ҏW.Split(' ');

								//�׎�l�Z����
								�ו��f�[�^�o��(fs, s�Z������[0], false);

								//�׎�l�Z���s
								if (s�Z������.Length > 1){
									//sCSVData = s�Z������[1].PadLeft(s�Z������[1].Length + s�Z������[0].Length);
									//�ו��f�[�^�o��(fs, sCSVData, false);
									�ו��f�[�^�o��(fs, s�Z������[1], false);
								}else{
									�ו��f�[�^�o��(fs, "", false);
								}
								//�׎�l�Z����
								if (s�Z������.Length > 2){
									//if (s�Z������[0].Length + s�Z������[1].Length >= 9)
									//	sCSVData = s�Z������[2].PadLeft(s�Z������[2].Length + s�Z������[0].Length + s�Z������[1].Length + 1);
									//else
									//	sCSVData = s�Z������[2].PadLeft(s�Z������[2].Length + s�Z������[0].Length + s�Z������[1].Length);
									//�ו��f�[�^�o��(fs, sCSVData, false);
									�ו��f�[�^�o��(fs, s�Z������[2], false);
								}else{
									�ו��f�[�^�o��(fs, "", false);
								}

								�ו��f�[�^�o��(fs, sPrintData[5], false);		//�׎�l�Z���P
								�ו��f�[�^�o��(fs, sPrintData[6], false);		//�׎�l�Z���Q
								�ו��f�[�^�o��(fs, sPrintData[7], false);		//�׎�l�Z���R
								�ו��f�[�^�o��(fs, sPrintData[8], false);		//�׎�l���O�P
								�ו��f�[�^�o��(fs, sPrintData[9], false);		//�׎�l���O�Q
// ADD 2007.10.13 ���s�j���� �O���[�o���Ή��i�o�ד��A���X�̔�\���j START
								if(sPrintData[14].Substring(1, 3) == "047"){
									�ו��f�[�^�o��(fs, "", false);	//�o�ד��N
									�ו��f�[�^�o��(fs, "", false);	//�o�ד���
									�ו��f�[�^�o��(fs, "", false);	//�o�ד���
								}else{
// ADD 2007.10.13 ���s�j���� �O���[�o���Ή��i�o�ד��A���X�̔�\���j END
// MOD 2010.03.17 ���s�j���� �o�ד��̔N���S���\���ɂ��� START
//									�ו��f�[�^�o��(fs, sPrintData[10].Substring(2, 2), false);	//�o�ד��N
									�ו��f�[�^�o��(fs, sPrintData[10], false);	//�o�ד��N
// MOD 2010.03.17 ���s�j���� �o�ד��̔N���S���\���ɂ��� END
									//�o�ד���
									if(sPrintData[10].Substring(4, 1) == "0")
										sCSVData = " " + sPrintData[10].Substring(5, 1);
									else
										sCSVData = sPrintData[10].Substring(4, 2);
									�ו��f�[�^�o��(fs, sCSVData, false);
									//�o�ד���
									if(sPrintData[10].Substring(6, 1) == "0")
										sCSVData = " " + sPrintData[10].Substring(7, 1);
									else
										sCSVData = sPrintData[10].Substring(6, 2);
									�ו��f�[�^�o��(fs, sCSVData, false);
// ADD 2007.10.13 ���s�j���� �O���[�o���Ή��i�o�ד��A���X�̔�\���j START
								}
// ADD 2007.10.13 ���s�j���� �O���[�o���Ή��i�o�ד��A���X�̔�\���j END
								//�����ԍ�
								sCSVData = sPrintData[11].Substring(4,3) + "-" + sPrintData[11].Substring(7,4) + "-" + sPrintData[11].Substring(11,4);
								�ו��f�[�^�o��(fs, sCSVData, false);
								//�o�[�R�[�h
								sCSVData = "A" + s�ו��ԍ� + "A";
								�ו��f�[�^�o��(fs, sCSVData, false);
								//���X�b�c
								if(sPrintData[13].Length == 0)
									sCSVData = "";
								else
									sCSVData = sPrintData[13].Substring(1, 1) + "-" + sPrintData[13].Substring(2,2);
								�ו��f�[�^�o��(fs, sCSVData, false);
								//���X�b�c
// MOD 2007.10.13 ���s�j���� �O���[�o���Ή��i�o�ד��A���X�̔�\���j START
//								�ו��f�[�^�o��(fs, sPrintData[14].Substring(1, 3), false);
								if(sPrintData[14].Substring(1, 3) == "047"){
									�ו��f�[�^�o��(fs, "", false);
								}else{
									�ו��f�[�^�o��(fs, sPrintData[14].Substring(1, 3), false);
								}
// MOD 2007.10.13 ���s�j���� �O���[�o���Ή��i�o�ד��A���X�̔�\���j END
								//�ב��l�d�b�ԍ�
								sCSVData = "(" + sPrintData[15] + ")" + sPrintData[16] + "-" + sPrintData[17];
								�ו��f�[�^�o��(fs, sCSVData, false);

								�ו��f�[�^�o��(fs, �Z���ҏW(sPrintData[18]), false);	//�ב��l�Z���P
								�ו��f�[�^�o��(fs, sPrintData[19], false);				//�ב��l�Z���Q
								�ו��f�[�^�o��(fs, sPrintData[18], false);				//�ב��l�Z���R
								�ו��f�[�^�o��(fs, sPrintData[21], false);				//�ב��l���O�P
								�ו��f�[�^�o��(fs, sPrintData[22], false);				//�ב��l���O�Q
								�ו��f�[�^�o��(fs, sPrintData[34], false);				//�S����

								�ו��f�[�^�o��(fs, int.Parse(sPrintData[23]), false);	//��
								�ו��f�[�^�o��(fs, i�A��, false);						//�A��
								�ו��f�[�^�o��(fs, int.Parse(sPrintData[24]), false);	//�d��

								//�ی���
								int iCSVData = int.Parse(sPrintData[25]) * 10;
								if(iCSVData > 0 && iCSVData < 50) iCSVData = 50;
								�ו��f�[�^�o��(fs, iCSVData, false);

								//�w���
								string s�w�茎;
								string s�w���;
								if (sPrintData[26] != null && !sPrintData[26].Equals("") && !sPrintData[26].Equals("0"))
								{
									if(sPrintData[26].Substring(4, 1) == "0")
										s�w�茎 = " " + sPrintData[26].Substring(5, 1);
									else
										s�w�茎 = sPrintData[26].Substring(4, 2);

									if(sPrintData[26].Substring(6, 1) == "0")
										s�w��� = " " + sPrintData[26].Substring(7, 1);
									else
										s�w��� = sPrintData[26].Substring(6, 2);

									sCSVData     = s�w�茎 + "��" + s�w��� + "��";
									if (sPrintData[36].Equals("0"))
										sCSVData += "�K��";
									else if (sPrintData[36].Equals("1"))
										sCSVData += "�w��";
									�ו��f�[�^�o��(fs, sCSVData, false);
								}
								else
								{
									�ו��f�[�^�o��(fs, "", false);
								}

								//���q�l�ԍ�
								if(sPrintData[35].Length == 0)
									�ו��f�[�^�o��(fs, "", false);
								else
									�ו��f�[�^�o��(fs, "���q�l�ԍ�:" + sPrintData[35], false);

								�ו��f�[�^�o��(fs, sPrintData[27], false);		//�A���L���P
								�ו��f�[�^�o��(fs, sPrintData[28], false);		//�A���L���Q
								�ו��f�[�^�o��(fs, sPrintData[29], false);		//�i���L���P
								�ו��f�[�^�o��(fs, sPrintData[30], false);		//�i���L���Q
								�ו��f�[�^�o��(fs, sPrintData[31], false);		//�i���L���R
								if(iCnt == 0){
									�ו��f�[�^�o��(fs, sPrintData[27], false);	//���x���R�A���L���P
									�ו��f�[�^�o��(fs, sPrintData[28], false);	//���x���R�A���L���Q
									�ו��f�[�^�o��(fs, sPrintData[29], false);	//���x���R�i���L���P
									�ו��f�[�^�o��(fs, sPrintData[30], false);	//���x���R�i���L���Q
									�ו��f�[�^�o��(fs, sPrintData[31], false);	//���x���R�i���L���R
									�ו��f�[�^�o��(fs, "", true);				//���x���R���\�L
								}else{
									�ו��f�[�^�o��(fs, "", false);				//���x���R�A���L���P
									�ו��f�[�^�o��(fs, "", false);				//���x���R�A���L���Q
									�ו��f�[�^�o��(fs, "", false);				//���x���R�i���L���P
									�ו��f�[�^�o��(fs, "", false);				//���x���R�i���L���Q
									�ו��f�[�^�o��(fs, "", false);				//���x���R�i���L���R
									�ו��f�[�^�o��(fs, "�׎D" + s�A��.PadLeft(3,' ') + "��", true);
																				//���x���R���\�L
								}
							}
						}
						catch(Exception ex)
						{
							throw new Exception(ex.Message);
						}
						fs.Close();
					}
					catch(Exception ex)
					{
						throw new Exception(ex.Message);
					}
					return;
				}
// ADD 2006.08.10 ���s�j���� �h�b�^�O�Ή��r�`�s�n���v�����^�Ή� END

// MOD 2008.03.19 ���s�j���� �ʍĔ��s�@�\�̒ǉ� START
//				for (int i = 0; i < int.Parse(sPrintData[23]); i++)
				int iLabel�I�� = int.Parse(sPrintData[23]);
				if(iLabel�I�� > i�I��){
					iLabel�I�� = i�I��;
				}
				for (int iPage = i�J�n; iPage <= iLabel�I��; iPage++)
// MOD 2008.03.19 ���s�j���� �ʍĔ��s�@�\�̒ǉ� END
				{
					�����f�[�^.table�����Row tr = (�����f�[�^.table�����Row)ds�����.table�����.NewRow();
						
					tr.BeginEdit();
// ADD 2005.07.11 ���s�j�����J ������̐��� START
					tr.����� = i�����++;
// ADD 2005.07.11 ���s�j�����J ������̐��� END
// MOD 2011.01.06 ���s�j���� �X�֔ԍ��̈�� START
					if(!gs�I�v�V����[19].Equals("1") && sPrintData[12].Length >= 7){
						tr.�׎�l�X�֔ԍ� = "��";
						tr.�׎�l�X�֔ԍ� += sPrintData[12].Substring(0,3);
						tr.�׎�l�X�֔ԍ� += "-";
						tr.�׎�l�X�֔ԍ� += sPrintData[12].Substring(3,4);
					}else{
						tr.�׎�l�X�֔ԍ� = "";
					}
// MOD 2011.01.06 ���s�j���� �X�֔ԍ��̈�� END
					tr.�׎�l�b�c     = sPrintData[1];
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� START
					if(gs�I�v�V����[0].Length == 4){
						if(!gs�I�v�V����[12].Equals("1")){
							tr.�׎�l�b�c     = " ";
						}
					}
// MOD 2009.05.01 ���s�j���� �I�v�V�����̍��ڒǉ� END
					tr.�׎�l�d�b�ԍ� = "(" + sPrintData[2] + ")" + sPrintData[3] + "-" + sPrintData[4];
// MOD 2010.03.17 ���s�j���� �׎�l�d�b�ԍ���ALL0�ł���Δ�\�� START
// MOD 2010.03.30 ���s�j���� �׎�l�d�b�ԍ���0�ł���Δ�\�� START
//					if(sPrintData[2] == "000000"
//					&& sPrintData[3] == "0000"
//					&& sPrintData[4] == "0000"){
					if(sPrintData[2].Replace("0","").Trim().Length == 0
					&& sPrintData[3].Replace("0","").Trim().Length == 0
					&& sPrintData[4].Replace("0","").Trim().Length == 0){
// MOD 2010.03.30 ���s�j���� �׎�l�d�b�ԍ���0�ł���Δ�\�� END
						tr.�׎�l�d�b�ԍ� = " ";
					}
// MOD 2010.03.18 ���s�j���� �׎�l�Z���̓s���{���Ǝs��S����؂�Ȃ� START
//// MOD 2010.03.17 ���s�j���� �׎�l�d�b�ԍ���ALL0�ł���Δ�\�� END
////					tr.�׎�l�Z���P   = �Z���ҏW(sPrintData[5]);
////					tr.�׎�l�Z���P   = sPrintData[5];
//					string s�Z���ҏW  = �Z���ҏW(sPrintData[5]);
//					string[] s�Z������ = s�Z���ҏW.Split(' ');
//					tr.�׎�l�Z����   = s�Z������[0];
//					if (s�Z������.Length > 1)
//						tr.�׎�l�Z���s = s�Z������[1].PadLeft(s�Z������[1].Length + s�Z������[0].Length);
//					else 
//						tr.�׎�l�Z���s = "";
//					if (s�Z������.Length > 2)
//// MOD 2006.05.24 ���s�j�ɉ� �Z���\���ʒu�̒��� START
////						tr.�׎�l�Z���� = s�Z������[2].PadLeft(s�Z������[2].Length + s�Z������[0].Length + s�Z������[1].Length);
//					{
//						if (s�Z������[0].Length + s�Z������[1].Length >= 9)
//							tr.�׎�l�Z���� = s�Z������[2].PadLeft(s�Z������[2].Length + s�Z������[0].Length + s�Z������[1].Length + 1);
//						else
//							tr.�׎�l�Z���� = s�Z������[2].PadLeft(s�Z������[2].Length + s�Z������[0].Length + s�Z������[1].Length);
//					}
//// MOD 2005.05.24 ���s�j�ɉ� �Z���\���ʒu�̒��� END
//					else
//						tr.�׎�l�Z���� = "";
					tr.�׎�l�Z����   = "";
					tr.�׎�l�Z���s   = "";
					tr.�׎�l�Z����   = "";
// MOD 2010.03.18 ���s�j���� �׎�l�Z���̓s���{���Ǝs��S����؂�Ȃ� END
					tr.�׎�l�Z���P   = sPrintData[5];
//					tr.�׎�l�Z���P   = s�Z���ҏW;
					tr.�׎�l�Z���Q   = sPrintData[6];
					tr.�׎�l�Z���R   = sPrintData[7];
					tr.�׎�l���O�P   = sPrintData[8];
					tr.�׎�l���O�Q   = sPrintData[9];
// ADD 2015.03.23 BEVAS) �O�c �x�X�~�ߑΉ��ǉ� START
					if (sPrintData[5].Equals("�����x�X�~�߁���"))
					{
						// �x�X�~�߂ł���Ƃ��A�׎�l�Z�����ڂɈȉ��̐ݒ���s�Ȃ�
						// �@�E�׎�l�Z�����F�u�����x�X�~�߁����v�i���[���ڂ̕\������Ɏg�p�A��\�����ځj
						// �@�E�׎�l�Z���P�F�u���R�ʉ^�^���q�^���v����
						// �@�E�׎�l�Z���Q�F�u�����x�X�^�c�Ə��~�߁v
						// �@�E�׎�l�Z���R�F�����󎚂��Ȃ�
						tr.�׎�l�Z���� = sPrintData[5];
						if(sPrintData[6].Substring(0, 2) == "���q")
						{
							tr.�׎�l�Z���P = "���q�^��";
						}
						else
						{
							tr.�׎�l�Z���P = "���R�ʉ^";
						}
						tr.�׎�l�Z���R = "";
					}
// ADD 2015.03.23 BEVAS) �O�c �x�X�~�ߑΉ��ǉ� END
// MOD 2010.03.17 ���s�j���� �o�ד��̔N���S���\���ɂ��� START
//					tr.�o�ד��N       = sPrintData[10].Substring(2, 2);
					tr.�o�ד��N       = sPrintData[10];
// MOD 2010.03.17 ���s�j���� �o�ד��̔N���S���\���ɂ��� END
					if(sPrintData[10].Substring(4, 1) == "0")
						tr.�o�ד���       = " " + sPrintData[10].Substring(5, 1);
					else
						tr.�o�ד���       = sPrintData[10].Substring(4, 2);
					if(sPrintData[10].Substring(6, 1) == "0")
						tr.�o�ד���       = " " + sPrintData[10].Substring(7, 1);
					else
						tr.�o�ד���       = sPrintData[10].Substring(6, 2);
					tr.�����ԍ�     = sPrintData[11].Substring(4,3) + "-" + sPrintData[11].Substring(7,4) + "-" + sPrintData[11].Substring(11,4);
// MOD 2008.03.19 ���s�j���� �ʍĔ��s�@�\�̒ǉ� START
//					tr.�o�[�R�[�h     = "A" + sPrintData[11].Substring(4) + (i + 1).ToString().PadLeft(2, '0') + "A";
					tr.�o�[�R�[�h     = "A" + sPrintData[11].Substring(4) + iPage.ToString().PadLeft(2, '0') + "A";
// MOD 2008.03.19 ���s�j���� �ʍĔ��s�@�\�̒ǉ� END
					if(sPrintData[13].Length == 0)
						tr.���X�b�c       = "";
					else
// MOD 2007.02.08 ���s�j���� �d���b�c�A���X���̒ǉ� START
//						tr.���X�b�c       = sPrintData[13].Substring(1, 1) + "-" + sPrintData[13].Substring(2,2);
						tr.���X�b�c       = sPrintData[13].Substring(1);
// MOD 2007.02.08 ���s�j���� �d���b�c�A���X���̒ǉ� END
// ADD 2009.04.07 ���s�j���� ���X�b�c[000]�Ή� START
					if(sPrintData[13].Equals("0000")){
						tr.���X�b�c       = "";
					}
// ADD 2009.04.07 ���s�j���� ���X�b�c[000]�Ή� END

// MOD 2007.02.15 ���s�j���� �d���b�c�A���X���̈󎚏����̕ύX START
//// MOD 2007.02.08 ���s�j���� �d���b�c�A���X���̒ǉ� START
//					if(sPrintData[37].Length == 0)
//						tr.�d���b�c       = "";
//					else
//						tr.�d���b�c       = "-" + sPrintData[37];
//					tr.���X��         = sPrintData[38];
//// MOD 2007.02.08 ���s�j���� �d���b�c�A���X���̒ǉ� END
					//�d���b�c���ݒ肳��Ă���ꍇ�A�d���b�c�A���X������
					if(sPrintData[37].Length > 0){
// MOD 2007.03.14 FJCS�j�K�c �n�C�t������ START
//						tr.�d���b�c       = "-" + sPrintData[37];
						tr.�d���b�c       = sPrintData[37];
// MOD 2007.03.14 FJCS�j�K�c �n�C�t������ END
// MOD 2011.12.06 ���s�j���� ���x���󎚍��ڂɔ��X���E���X����ǉ� START
//						tr.���X��         = sPrintData[38];
// MOD 2011.12.06 ���s�j���� ���x���󎚍��ڂɔ��X���E���X����ǉ� END
					}else{
						tr.�d���b�c       = "";
// MOD 2011.12.06 ���s�j���� ���x���󎚍��ڂɔ��X���E���X����ǉ� START
//						tr.���X��         = "";
// MOD 2011.12.06 ���s�j���� ���x���󎚍��ڂɔ��X���E���X����ǉ� END
					}
// MOD 2007.02.15 ���s�j���� �d���b�c�A���X���̈󎚏����̕ύX END
					tr.���X�b�c       = sPrintData[14].Substring(1, 3);
// ADD 2007.10.13 ���s�j���� �O���[�o���Ή��i�o�ד��A���X�̔�\���j START
					if(sPrintData[14].Substring(1, 3) == "047"){
						tr.�o�ד��N       = "";
						tr.�o�ד���       = "";
						tr.�o�ד���       = "";
						tr.���X��         = "";
						tr.���X�b�c       = "";
					}
// ADD 2007.10.13 ���s�j���� �O���[�o���Ή��i�o�ד��A���X�̔�\���j END
// MOD 2011.01.06 ���s�j���� �X�֔ԍ��̈�� START
					if(!gs�I�v�V����[19].Equals("1")
					 && sPrintData.Length > 40 && sPrintData[40].Length >= 7){
						tr.�ב��l�X�֔ԍ� = "��";
						tr.�ב��l�X�֔ԍ� += sPrintData[40].Substring(0,3);
						tr.�ב��l�X�֔ԍ� += "-";
						tr.�ב��l�X�֔ԍ� += sPrintData[40].Substring(3,4);
					}else{
						tr.�ב��l�X�֔ԍ� = "";
					}
// MOD 2011.01.06 ���s�j���� �X�֔ԍ��̈�� END
					tr.�ב��l�d�b�ԍ� = "(" + sPrintData[15] + ")" + sPrintData[16] + "-" + sPrintData[17];
					//				tr.�ב��l�Z���P   = sPrintData[18];
//�ۗ� MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
					tr.�ב��l�Z���P   = �Z���ҏW(sPrintData[18]);
//					tr.�ב��l�Z���P   = sPrintData[18];
//�ۗ� MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
					tr.�ב��l�Z���Q   = sPrintData[19];
//					tr.�ב��l�Z���R   = sPrintData[20];
					tr.�ב��l�Z���R   = sPrintData[18];
					tr.�ב��l���O�P   = sPrintData[21];
					tr.�ב��l���O�Q   = sPrintData[22];
// ADD 2005.06.01 ���s�j�����J �S���Ғǉ� START
					tr.�S����         = sPrintData[34];
// ADD 2005.06.01 ���s�j�����J �S���Ғǉ� END
					tr.��           = sPrintData[23];
// MOD 2008.03.19 ���s�j���� �ʍĔ��s�@�\�̒ǉ� START
//					tr.�A��           = (i + 1).ToString();
					tr.�A��           = iPage.ToString();
// MOD 2008.03.19 ���s�j���� �ʍĔ��s�@�\�̒ǉ� END
					tr.�d��           = sPrintData[24];
					int i�ی��� = int.Parse(sPrintData[25]) * 10;
					if(i�ی��� > 0 && i�ی��� < 50)
					{
						tr.�ی���     = "50";
					}
					else
					{
						string s�ی��� = i�ی���.ToString();
						if(s�ی���.Length == 4)
							s�ی��� = s�ی���.Insert(1,",");
						else
						{
							if(s�ی���.Length == 5)
								s�ی��� = s�ی���.Insert(2,",");
						}
						tr.�ی���     = s�ی���;
//						tr.�ی���     = i�ی���.ToString();
					}
					string s�w�茎;
					string s�w���;
					if (sPrintData[26] != null && !sPrintData[26].Equals("") && !sPrintData[26].Equals("0"))
					{
						if(sPrintData[26].Substring(4, 1) == "0")
							s�w�茎 = " " + sPrintData[26].Substring(5, 1);
						else
							s�w�茎 = sPrintData[26].Substring(4, 2);

						if(sPrintData[26].Substring(6, 1) == "0")
							s�w��� = " " + sPrintData[26].Substring(7, 1);
						else
							s�w��� = sPrintData[26].Substring(6, 2);
// MOD 2005.06.01 ���s�j�ɉ� �w����敪�ǉ� START
						tr.�w���     = s�w�茎 + "��" + s�w��� + "��";
						if (sPrintData[36].Equals("0"))
							tr.�w��� += "�K��";
						else if (sPrintData[36].Equals("1"))
							tr.�w��� += "�w��";
// MOD 2005.06.01 ���s�j�ɉ� �w����敪�ǉ� END
//						tr.�w���     = sPrintData[26].Substring(4, 2) + "��" + sPrintData[26].Substring(6, 2) + "���K��";
					}
					else
						tr.�w���     = "";
// ADD 2005.06.01 ���s�j�����J ���q�l�ԍ��ǉ� START
					if(sPrintData[35].Length != 0)
						tr.���q�l�ԍ�     = "���q�l�ԍ�:" + sPrintData[35];
					else
						tr.���q�l�ԍ�     = sPrintData[35];
// ADD 2005.06.01 ���s�j�����J ���q�l�ԍ��ǉ� END
					tr.�A���L���P     = sPrintData[27];
					tr.�A���L���Q     = sPrintData[28];
					tr.�i���L���P     = sPrintData[29];
					tr.�i���L���Q     = sPrintData[30];
					tr.�i���L���R     = sPrintData[31];
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� START
					if(sPrintData.Length > 42){
						tr.�i���L���S = sPrintData[42];
						tr.�i���L���T = sPrintData[43];
						tr.�i���L���U = sPrintData[44];
					}else{
						tr.�i���L���S = "";
						tr.�i���L���T = "";
						tr.�i���L���U = "";
					}
					// �i���L���S�`�U�̂����ꂩ�Ƀf�[�^����ꍇ
					if(tr.�i���L���S.Length > 0
						|| tr.�i���L���T.Length > 0
						|| tr.�i���L���U.Length > 0
					){
						// �S�p�X�����A���͔��p�P�W����
						tr.�i���L���P = �o�C�g���J�b�g(tr.�i���L���P, 18);
						tr.�i���L���Q = �o�C�g���J�b�g(tr.�i���L���Q, 18);
						tr.�i���L���R = �o�C�g���J�b�g(tr.�i���L���R, 18);
						tr.�i���L���S = �o�C�g���J�b�g(tr.�i���L���S, 18);
						tr.�i���L���T = �o�C�g���J�b�g(tr.�i���L���T, 18);
						tr.�i���L���U = �o�C�g���J�b�g(tr.�i���L���U, 18);
					}
// MOD 2011.07.14 ���s�j���� �L���s�̒ǉ� END
// ADD 2007.02.08 ���s�j���� �d���b�c�A���X���̒ǉ� START
//					//���C�A�E�g�󎚗p
//					tr.���X�b�c       = "888";
//					tr.�d���b�c       = "-" + "WWW";
//					tr.���X��         = "��������";
//					tr.�A���L���P     = "������������������������������";
//					tr.�A���L���Q     = "������������������������������";
// ADD 2007.02.08 ���s�j���� �d���b�c�A���X���̒ǉ� END

// MOD 2009.11.09 PSN�j����@�I�v�V�����̍��ڒǉ� START
					if(!gs�I�v�V����[15].Equals("1"))
					{
						tr.�׎�l�t�H���g�T�C�Y�g��FLG     = "0";
					}else{
						tr.�׎�l�t�H���g�T�C�Y�g��FLG     = "1";
					}
// MOD 2009.11.09 PSN�j����@�I�v�V�����̍��ڒǉ� END
// MOD 2010.02.28 ���s�j���� ���q�^���̑Ή� START
					if(gs����b�c.Substring(0,1) != "J"){
						tr.���q�^��FLG = "0";
					}else{
						tr.���q�^��FLG = "1";
					}
// MOD 2010.02.28 ���s�j���� ���q�^���̑Ή� END
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� START
					string s�d�ʓ��͐��� = (sPrintData.Length > 41) ? sPrintData[41] : "0";
					tr.�d�ʓ��͐��� = s�d�ʓ��͐���;
//�ۗ�				tr.�d�ʓ��͐��� = gs�d�ʓ��͐���;
// MOD 2011.05.09 ���s�j���� ���q�l���̏d�ʓ��͕s�Ή� END
// MOD 2011.12.06 ���s�j���� ���x���w�b�_���ɔ��X���E���X������ START
					if(tr.���X�b�c == "" || tr.���X�b�c == "000"){
						tr.���X��     = ""; // ���X�b�c�����ݒ莞(�O���[�o����)
// MOD 2012.04.10 ���s�j���� ���x�����X���̈󎚐���Ή� START
					}else if(gs�I�v�V����[21].Equals("1")){
						tr.���X��     = "";
// MOD 2012.04.10 ���s�j���� ���x�����X���̈󎚐���Ή� END
					}else{
						if(sPrintData[38] == ""){
// MOD 2015.01.16 BEVAS)�O�c ���X���̈󎚊g�� START
							//tr.���X��     = "��:" + tr.���X�b�c;
							tr.���X��     = tr.���X�b�c;
						}
						else
						{
							//tr.���X��     = "��:" + sPrintData[38];
							tr.���X��     = sPrintData[38];
// MOD 2015.01.16 BEVAS)�O�c ���X���̈󎚊g�� END
						}
					}
					string s���X�� = (sPrintData.Length > 45) ? sPrintData[45] : "";
					if(tr.���X�b�c == "" || tr.���X�b�c == "000"){
						tr.���X��     = ""; // ���X�b�c�����ݒ莞
					}else{
						if(s���X�� == ""){
// MOD 2015.01.16 BEVAS)�O�c ���X���̈󎚊g�� START
							//tr.���X��     = "��:" + tr.���X�b�c;
							tr.���X��     = tr.���X�b�c;
						}
						else
						{
							//tr.���X��     = "��:" + s���X��;
							tr.���X��     = s���X��;
// MOD 2015.01.16 BEVAS)�O�c ���X���̈󎚊g�� END
						}
					}
					// �����x���̃o�b�N�̍��h��[���X��]�ɐݒ肵�Ă����
					//   ���X�����\������Ȃ����A�o�b�N�̐F�������܂�
					// 
// MOD 2011.12.06 ���s�j���� ���x���w�b�_���ɔ��X���E���X������ END
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� START
					//�Г��`�[�ł���΁A�l���Z�b�g����
					if(gs���p�ҕ���X���b�c.Equals("044"))
					{
						// �Г��`�[�ł���Ƃ��A�׎�l�Z�����ڂɈȉ��̐ݒ���s�Ȃ�
						// �@�E�׎�l�Z�����@�@�@�@�@�F�u�����Г��`�[�����v
						//�@�@�@�i���[���ڂ̕\������Ɏg�p�A��\�����ځj
						// �@�E���X�b�c�i��j�@�@�@�@�F�󎚂��Ȃ�
						// �@�E���X�b�c�i���j�@�@�@�@�F�󎚂���
						// �@�E�w�Г���p�x�e�L�X�g�F�󎚂���
						tr.�׎�l�Z���� = "�����Г��`�[����";
					}
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� END

					tr.EndEdit();

					ds�����.table�����.Rows.Add(tr);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� START
//		protected static void ����󒠕[���()
		protected void ����󒠕[���()
// MOD 2010.05.11 ���s�j���� ���x������̃X���b�h�Ή� END
		{
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j START
			//�����I�K�x�[�W�R���N�^
			System.GC.Collect();
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j END
// ADD 2006.08.10 ���s�j���� �h�b�^�O�Ή��r�`�s�n���v�����^�Ή� START
			if(gs�v�����^��� == "S0004"){
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j START
//				i����� = 0;
//				ds�����.Clear();
				�����f�[�^�N���A();
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j END
				return;
			}
// ADD 2006.08.10 ���s�j���� �h�b�^�O�Ή��r�`�s�n���v�����^�Ή� END

			//����󒠕[ cr = new ����󒠕[();
			//����󒠕[�Q cr = new ����󒠕[�Q();
			����󒠕[�R cr = new ����󒠕[�R();
// MOD 2011.03.03 ���s�j���� �v�����^���Ƃ̕␳�Ή� START
#if DEBUG
			System.IO.FileStream fs = null;
			try{
				fs = new FileStream(
					Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
					+ @"\���x����`_is2"
					+ "_" + DateTime.Now.ToString("yyyyMMdd")
					+ "_" + gsa���[�U[3]
					+ ".txt", 
					FileMode.Create, FileAccess.Write,FileShare.Read);
			}catch(Exception ex){
				throw new Exception(ex.Message);
			}finally{
				if(fs != null) fs.Close();
			}
			CheckReportDefOut(cr.Section1);
			CheckReportDefOut(cr.Section2);
			CheckReportDefOut(cr.Section3);
			CheckReportDefOut(cr.Section5);
			CheckReportDefOut(cr.Section6);
			CheckReportDefOut(cr.Section9);
			CheckReportDefOut(cr.Section10);
//			if(gs�v�����^���.Length > 0){
//				�����f�[�^�N���A();
//				return;
//			}
#endif
// MOD 2011.03.03 ���s�j���� �v�����^���Ƃ̕␳�Ή� END
// MOD 2011.03.03 ���s�j���� �v�����^���Ƃ̕␳�Ή� START
			//------------------------------------------------------------------
			// << �Q�l�F�P�� >>
			//------------------------------------------------------------------
			// 1 inch = 25.4 mm
			// 1 inch = 1440 Twp
			// �� 1   mm = 56.69 Twp
			// �� 1/4 mm = 14.17 Twp
			//------------------------------------------------------------------
			// << �Q�l�F�p���T�C�Y�ݒ�l����ш󎚖��x >>
			//------------------------------------------------------------------
			// Zebra  �F��   4.25 inch �c   6.51 inch
			//       ���� 6120.0 Twp  �c 9374.4 Twp
			// ( Zebra �F��  108.0 mm   �c  165.4 mm  )
			// (       ���� 6122.8 Twp  �c 9377.0 Twp )
			// LP2844 �F�󎚖��x 203 x 203 dpi (8 dots/mm) 
			//------------------------------------------------------------------
			// Sato   �F��  107.0 mm   �c  164.0 mm
			//       ���� 6066.1 Twp  �c 9297.6 Twp
			// ڽ��؃��F�󎚖��x 203 x 203 dpi (8 dots/mm) 
			//------------------------------------------------------------------
			// << �Q�l�F���x���p���T�C�Y >>
			//------------------------------------------------------------------
			// �����F��  110.0 mm   �c  6-1/2 inch
			//       ���� 6236.2 Twp  �c 9360.0 Twp
			//------------------------------------------------------------------

			//------------------------------------------------------------------
			// << �Q�l�FCrystalreports �Z�N�V���������̏����l >>
			//------------------------------------------------------------------
//			cr.Section1.Height  =    0; // ReportHeader
//			cr.Section2.Height  = 1185; // PageHeader
//			cr.Section3.Height  = 3510; // Detail a
//			cr.Section5.Height  = 3012; // PageFooter
//			cr.Section6.Height  =    0; // ReportFooter
//			cr.Section9.Height  = 1585; // Detail b 1����
//			cr.Section10.Height = 1585; // Detail c 2���ڈȍ~
//							���v  9292 Twp �� ���ۂ̗p���̃T�C�Y��� 32 Twp Over

			//------------------------------------------------------------------
			// << �␳�P�� >>
			//------------------------------------------------------------------
			int i�␳�P�� = 14; // �� 1/4 mm
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� START
			int i�w�b�_�[���㉺�␳�s = 0;
			int i�ڍו��P�㉺�␳�s   = 0;
			int i�ڍו��Q�㉺�␳�s   = 0; 
			int i�t�b�^�[���㉺�␳�s = 0;
			int i���E�␳�s = 0;
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� END
			if(gs�v�����^��� == "S0002"){
				//------------------------------------------------------------------
				// ���X�v�����̏ꍇ
				//------------------------------------------------------------------
				//------------------------------------------------------------------
				// << �㉺�ʒu����э����␳ >>
				//------------------------------------------------------------------
				//------------------------------------------------------------------
				// < �t�b�^�[���F�㉺�ʒu�␳ >
				//------------------------------------------------------------------
// MOD 2011.04.26 ���s�j���� �v�����^���Ƃ̕␳�Ή� START
//				// �t�b�^�[���F�o�הN����
//				cr.Section5.ReportObjects["Field40"].Top  += i�␳�P�� * (-1);
//				cr.Section5.ReportObjects["Field41"].Top  += i�␳�P�� * (-1);
//				cr.Section5.ReportObjects["Field42"].Top  += i�␳�P�� * (-1);
// MOD 2011.04.26 ���s�j���� �v�����^���Ƃ̕␳�Ή� END
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� START
			}else if(gs�v�����^��� == "S0005"){
				//------------------------------------------------------------------
				// �r�`�s�n���v�����^(CS408T)�̏ꍇ
				//------------------------------------------------------------------
				//------------------------------------------------------------------
				// << �㉺�ʒu����э����␳ >>
				//------------------------------------------------------------------
// MOD 2011.12.20 ���s�j���� �r�`�s�n���v�����^(CS408T)�Ή� END
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� START
			}
			else if(gs�v�����^��� == "S0006")
			{
				//------------------------------------------------------------------
				// �r�`�s�n���v�����^(CS408T)�̏ꍇ
				//------------------------------------------------------------------
				//------------------------------------------------------------------
				// << �㉺�ʒu����э����␳ >>
				//------------------------------------------------------------------
// MOD 2013.04.05 TDI�j�j�V �r�`�s�n���v�����^(CF408T)�Ή� END
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� START
// MOD 2015.02.12 BEVAS�j�O�c �s�d�b���v�����^(B-LV4)�Ή� START
			}
			//else if(gs�v�����^��� == "S0007")
			else if((gs�v�����^��� == "S0007") || (gs�v�����^��� == "S0008"))
			{
				//------------------------------------------------------------------
//				// �s�d�b���v�����^(B-EV4-G)�̏ꍇ
				// �s�d�b���v�����^(B-EV4-G�����B-LV4-G)�̏ꍇ
				//------------------------------------------------------------------
// MOD 2015.02.12 BEVAS�j���� �s�d�b���v�����^(B-LV4)�Ή� START
				//------------------------------------------------------------------
				// << �㉺�ʒu����э����␳ >>
				//------------------------------------------------------------------
				i�w�b�_�[���㉺�␳�s = i�␳�P�� * ( 0); // 
				i�ڍו��P�㉺�␳�s   = i�␳�P�� * (-7); // �� 1.75 mm(��)
				i�ڍו��Q�㉺�␳�s   = i�␳�P�� * (-2); // �� 0.50 mm(��)
				i�t�b�^�[���㉺�␳�s = i�␳�P�� * ( 0); // 
				//------------------------------------------------------------------
				// < �ڍו��P�F�㉺�ʒu�␳ >
				//------------------------------------------------------------------
				cr.Section3.ReportObjects["Field8" ].Top  += i�ڍו��P�㉺�␳�s; // �o�[�R�[�h��
				cr.Section3.ReportObjects["Field9" ].Top  += i�ڍו��P�㉺�␳�s; // �o�[�R�[�h��
				cr.Section3.ReportObjects["Field74"].Top  += i�ڍו��P�㉺�␳�s; // �o�[�R�[�h��
				cr.Section3.ReportObjects["Field19"].Top  += i�ڍו��P�㉺�␳�s; // �o�[�R�[�h����
				cr.Section3.ReportObjects["Text21" ].Top  += i�ڍו��P�㉺�␳�s; // ���q�^��******
				cr.Section3.ReportObjects["Field16"].Top  += i�ڍו��P�㉺�␳�s; // �o�ד�(�N)
				cr.Section3.ReportObjects["Field17"].Top  += i�ڍו��P�㉺�␳�s; // �o�ד�(��)
				cr.Section3.ReportObjects["Field18"].Top  += i�ڍו��P�㉺�␳�s; // �o�ד�(��)
				cr.Section3.ReportObjects["Text17" ].Top  += i�ڍו��P�㉺�␳�s; // ���X�b�c(����)
				cr.Section3.ReportObjects["Field50"].Top  += i�ڍו��P�㉺�␳�s; // ���X�b�c
				cr.Section3.ReportObjects["Text18" ].Top  += i�ڍו��P�㉺�␳�s; // ����
				cr.Section3.ReportObjects["Text1"  ].Top  += i�ڍו��P�㉺�␳�s; // �����ԍ�(����)
				cr.Section3.ReportObjects["Field51"].Top  += i�ڍו��P�㉺�␳�s; // �����ԍ�
				//------------------------------------------------------------------
				// < �e�Z�N�V���������␳ >
				//------------------------------------------------------------------
				// �w�b�_�[�������␳
				cr.Section2.Height  += i�w�b�_�[���㉺�␳�s;
				// �ڍו��P
				cr.Section3.Height  += i�ڍו��P�㉺�␳�s;
				// �ڍו��Q�|�P // 1����
				cr.Section9.Height  += i�ڍו��Q�㉺�␳�s;
				// �ڍו��Q�|�Q // 2���ڈȍ~
				cr.Section10.Height += i�ڍו��Q�㉺�␳�s;
				// �t�b�^�[�������␳
				cr.Section5.Height  += i�t�b�^�[���㉺�␳�s;
				//------------------------------------------------------------------
				// << ���E�ʒu�␳ >>
				//------------------------------------------------------------------
				i���E�␳�s = i�␳�P�� * ( 8); // �� 2.00 mm(�E)
				//------------------------------------------------------------------
				// < �w�b�_�[���F�㉺�ʒu�␳ >
				//------------------------------------------------------------------
				cr.Section2.ReportObjects["Field1" ].Left += i���E�␳�s; //���X�b�c
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� START
				cr.Section2.ReportObjects["Field83"].Left += i���E�␳�s; //���X�b�c�i���j
				cr.Section2.ReportObjects["Text3" ].Left += i���E�␳�s;  //�w�Г���p�x�e�L�X�g
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� END
				cr.Section2.ReportObjects["Field49"].Left += i���E�␳�s; // ���X��
				cr.Section2.ReportObjects["Field71"].Left += i���E�␳�s; // ���X���i�o�b�N�j
				cr.Section2.ReportObjects["Field81"].Left += i���E�␳�s; // ���X��
				cr.Section2.ReportObjects["Field82"].Left += i���E�␳�s; // ���X���i�o�b�N�j
				cr.Section2.ReportObjects["Field72"].Left += i���E�␳�s; // �d���b�c
// ADD 2015.01.20 BEVAS)�O�c ���X���g��󎚑Ή� START
				cr.Section2.ReportObjects["Text24"].Left += i���E�␳�s; // �u���v����
				cr.Section2.ReportObjects["Text25"].Left += i���E�␳�s; // �u���v����
// ADD 2015.01.20 BEVAS)�O�c ���X���g��󎚑Ή� END

				cr.Section2.ReportObjects["Field2" ].Left += i���E�␳�s; // �w���
				cr.Section2.ReportObjects["Field3" ].Left += i���E�␳�s; // �A���L���P
				cr.Section2.ReportObjects["Field4" ].Left += i���E�␳�s; // �A���L���Q
				//------------------------------------------------------------------
				// < �ڍו��P�F���E�ʒu�␳ >
				//------------------------------------------------------------------
				cr.Section3.ReportObjects["Field11"].Left += i���E�␳�s; //�׎�l�Z���P
				cr.Section3.ReportObjects["Field12"].Left += i���E�␳�s; //�׎�l�Z���Q
				cr.Section3.ReportObjects["Field13"].Left += i���E�␳�s; //�׎�l�Z���R
				cr.Section3.ReportObjects["Field14"].Left += i���E�␳�s; //�׎�l���O�P
				cr.Section3.ReportObjects["Field15"].Left += i���E�␳�s; //�׎�l���O�Q
				cr.Section3.ReportObjects["Field60"].Left += i���E�␳�s; //�׎�l�Z���P(�啶��)
				cr.Section3.ReportObjects["Field75"].Left += i���E�␳�s; //�׎�l�Z���Q(�啶��)
				cr.Section3.ReportObjects["Field76"].Left += i���E�␳�s; //�׎�l���O�P(�啶��)

				cr.Section3.ReportObjects["Text21" ].Left += i���E�␳�s; //���q�^��******
				cr.Section3.ReportObjects["Field16"].Left += i���E�␳�s; //�o�ד�(�N)
				cr.Section3.ReportObjects["Field17"].Left += i���E�␳�s; //�o�ד�(��)
				cr.Section3.ReportObjects["Field18"].Left += i���E�␳�s; //�o�ד�(��)
				//------------------------------------------------------------------
				// < �ڍו��Q�|�P�F���E�ʒu�␳ >
				//------------------------------------------------------------------
				cr.Section9.ReportObjects["Field79"].Left += i���E�␳�s; //�ב��l�X�֔ԍ�
				cr.Section9.ReportObjects["Field61"].Left += i���E�␳�s; //�ב��l�Z���P
				cr.Section9.ReportObjects["Field62"].Left += i���E�␳�s; //�ב��l�Z���Q
				cr.Section9.ReportObjects["Field63"].Left += i���E�␳�s; //�ב��l���O�P
				cr.Section9.ReportObjects["Field64"].Left += i���E�␳�s; //�ב��l���O�Q
				cr.Section9.ReportObjects["Field45"].Left += i���E�␳�s; //�ב��l�S����

// ADD 2015.01.20 BEVAS)�O�c ���͗��ǉ��󎚑Ή� START
				//cr.Section9.ReportObjects["Text2"].Left        += i���E�␳�s; // ��̈󕶎�
				cr.Section9.ReportObjects["Text13"].Left       += i���E�␳�s; // �ی����w�i
				cr.Section9.ReportObjects["Text6"].Left        += i���E�␳�s; // �ی���(����)
				cr.Section9.ReportObjects["Field54"].Left      += i���E�␳�s; // �ی���(���z)
				cr.Section9.ReportObjects["Text7"].Left        += i���E�␳�s; // �~
				cr.Section9.ReportObjects["�e�׎Dkg�g"].Left    += i���E�␳�s;
				cr.Section9.ReportObjects["�e�׎Dcm�g"].Left    += i���E�␳�s;
				cr.Section9.ReportObjects["�e�׎D�ː��g"].Left  += i���E�␳�s;
				cr.Section9.ReportObjects["txt�e�׎Dkg"].Left   += i���E�␳�s;
				cr.Section9.ReportObjects["txt�e�׎Dcm"].Left   += i���E�␳�s;
				cr.Section9.ReportObjects["txt�e�׎D�ː�"].Left += i���E�␳�s;
// ADD 2015.01.20 BEVAS)�O�c ���͗��ǉ��󎚑Ή� END
							
				//------------------------------------------------------------------
				// < �ڍו��Q�|�Q�F���E�ʒu�␳ >
				//------------------------------------------------------------------
				cr.Section10.ReportObjects["Field21"].Left += i���E�␳�s; //�ב��l�X�֔ԍ�
				cr.Section10.ReportObjects["Field66"].Left += i���E�␳�s; //�ב��l�Z���P
				cr.Section10.ReportObjects["Field67"].Left += i���E�␳�s; //�ב��l�Z���Q
				cr.Section10.ReportObjects["Field68"].Left += i���E�␳�s; //�ב��l���O�P
				cr.Section10.ReportObjects["Field69"].Left += i���E�␳�s; //�ב��l���O�Q
				cr.Section10.ReportObjects["Field20"].Left += i���E�␳�s; //�ב��l�S����
// ADD 2015.01.20 BEVAS)�O�c ���͗��ǉ��󎚑Ή� START
				cr.Section10.ReportObjects["Text16"].Left      += i���E�␳�s; // �ی����w�i
				cr.Section10.ReportObjects["Text19"].Left      += i���E�␳�s; // �ی���(����)
				cr.Section10.ReportObjects["Field56"].Left     += i���E�␳�s; // �ی���(���z)
				cr.Section10.ReportObjects["Text20"].Left      += i���E�␳�s; // �~
				cr.Section10.ReportObjects["�q�׎Dkg�g"].Left   += i���E�␳�s;
				cr.Section10.ReportObjects["�q�׎Dcm�g"].Left   += i���E�␳�s;
				cr.Section10.ReportObjects["�q�׎D�ː��g"].Left += i���E�␳�s;
				cr.Section10.ReportObjects["txt�q�׎Dkg"].Left  += i���E�␳�s;
				cr.Section10.ReportObjects["txt�q�׎Dcm"].Left  += i���E�␳�s;
				cr.Section10.ReportObjects["txt�q�׎D�ː�"].Left+= i���E�␳�s;
// ADD 2015.01.20 BEVAS)�O�c ���͗��ǉ��󎚑Ή� END
				//------------------------------------------------------------------
				// < �t�b�^�[���F���E�ʒu�␳ >
				//------------------------------------------------------------------
				cr.Section5.ReportObjects["Field80"].Left += i���E�␳�s; //�׎�l�X�֔ԍ�
				cr.Section5.ReportObjects["Field23"].Left += i���E�␳�s; //�׎�l�Z���P
				cr.Section5.ReportObjects["Field24"].Left += i���E�␳�s; //�׎�l�Z���Q
				cr.Section5.ReportObjects["Field25"].Left += i���E�␳�s; //�׎�l�Z���R
				cr.Section5.ReportObjects["Field77"].Left += i���E�␳�s; //�׎�l�Z���P(�啶��)
				cr.Section5.ReportObjects["Field78"].Left += i���E�␳�s; //�׎�l�Z���Q(�啶��)
				cr.Section5.ReportObjects["Field26"].Left += i���E�␳�s; //�׎�l���O�P
				cr.Section5.ReportObjects["Field27"].Left += i���E�␳�s; //�׎�l���O�Q

				cr.Section5.ReportObjects["Field40"].Left += i���E�␳�s; //�o�ד�(�N)
				cr.Section5.ReportObjects["Field41"].Left += i���E�␳�s; //�o�ד�(��)
				cr.Section5.ReportObjects["Field42"].Left += i���E�␳�s; //�o�ד�(��)

				cr.Section5.ReportObjects["Field5" ].Left += i���E�␳�s; //�ב��l�X�֔ԍ�
				cr.Section5.ReportObjects["Field48"].Left += i���E�␳�s; //�ב��l�Z���P
				cr.Section5.ReportObjects["Field29"].Left += i���E�␳�s; //�ב��l�Z���Q
				cr.Section5.ReportObjects["Field31"].Left += i���E�␳�s; //�ב��l���O�P
				cr.Section5.ReportObjects["Field32"].Left += i���E�␳�s; //�ב��l���O�Q
				cr.Section5.ReportObjects["Field28"].Left += i���E�␳�s; //�ב��l�S����

				cr.Section5.ReportObjects["Text22" ].Left += i���E�␳�s; //******
				cr.Section5.ReportObjects["Text23" ].Left += i���E�␳�s; //���q�^��
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� END
			}
			else
			{
				//------------------------------------------------------------------
				// ���X�v�����ȊO�i�y���������j�̏ꍇ
				//------------------------------------------------------------------
				//------------------------------------------------------------------
				// << �㉺�ʒu����э����␳ >>
				//------------------------------------------------------------------
//				int i�w�b�_�[���㉺�␳ = i�␳�P�� * (-6); // �� 1.5  mm
				int i�w�b�_�[���㉺�␳ = i�␳�P�� * (-5); // �� 1.25 mm
				int i�ڍו��P�㉺�␳   = i�␳�P�� * ( 0); // 
				int i�ڍו��Q�㉺�␳   = i�␳�P�� * (-3); // �� 0.75 mm(-4��X�A-3�܂�)
				int i�t�b�^�[���㉺�␳ = i�␳�P�� * ( 8); // �� 2.00 mm
				//------------------------------------------------------------------
				// < �w�b�_�[���F�㉺�ʒu�␳ >
				//------------------------------------------------------------------
				// �w�b�_�[���F���X�R�[�h
				cr.Section2.ReportObjects["Field1" ].Top  += i�w�b�_�[���㉺�␳; // ���X�b�c
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� START
				cr.Section2.ReportObjects["Field83"].Top += i�w�b�_�[���㉺�␳;  //���X�b�c�i���j
				cr.Section2.ReportObjects["Text3" ].Top += i�w�b�_�[���㉺�␳;   //�w����G���A�x�e�L�X�g
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� END
				// �w�b�_�[���F�d���R�[�h
// MOD 2011.12.06 ���s�j���� ���x���w�b�_���ɔ��X���E���X������ START
//				cr.Section2.ReportObjects["Field71"].Top  += i�w�b�_�[���㉺�␳;
				cr.Section2.ReportObjects["Field49"].Top  += i�w�b�_�[���㉺�␳; // ���X��
				cr.Section2.ReportObjects["Field71"].Top  += i�w�b�_�[���㉺�␳; // ���X���i�o�b�N�j
				cr.Section2.ReportObjects["Field81"].Top  += i�w�b�_�[���㉺�␳; // ���X��
				cr.Section2.ReportObjects["Field82"].Top  += i�w�b�_�[���㉺�␳; // ���X���i�o�b�N�j
// MOD 2011.12.06 ���s�j���� ���x���w�b�_���ɔ��X���E���X������ END
				cr.Section2.ReportObjects["Field72"].Top  += i�w�b�_�[���㉺�␳; // �d���b�c
				// �w�b�_�[���F�w����A�A���L��
				cr.Section2.ReportObjects["Field2" ].Top  += i�w�b�_�[���㉺�␳; // �w���
				cr.Section2.ReportObjects["Field3" ].Top  += i�w�b�_�[���㉺�␳; // �A���L���P
				cr.Section2.ReportObjects["Field4" ].Top  += i�w�b�_�[���㉺�␳; // �A���L���Q
// ADD 2015.01.20 BEVAS)�O�c ���X���g��󎚑Ή� START
// ���܂܂�Field49, Field81�Ɂu���F�v�A�u���F�v���܂߂Ă������A���X���Ƃ܂Ƃ߂Ċg�傳��Ȃ��悤����
				cr.Section2.ReportObjects["Text24" ].Top  += i�w�b�_�[���㉺�␳; // [��]�e�L�X�g
				cr.Section2.ReportObjects["Text25" ].Top  += i�w�b�_�[���㉺�␳; // [��]�e�L�X�g
// ADD 2015.01.20 BEVAS)�O�c ���X���g��󎚑Ή� END
// MOD 2011.04.26 ���s�j���� �v�����^���Ƃ̕␳�Ή� START
//				//------------------------------------------------------------------
//				// < �t�b�^�[���F�㉺�ʒu�␳ >
//				//------------------------------------------------------------------
//				// �t�b�^�[���F�o�הN����
//				cr.Section5.ReportObjects["Field40"].Top  += i�␳�P�� * (-1);
//				cr.Section5.ReportObjects["Field41"].Top  += i�␳�P�� * (-1);
//				cr.Section5.ReportObjects["Field42"].Top  += i�␳�P�� * (-1);
// MOD 2011.04.26 ���s�j���� �v�����^���Ƃ̕␳�Ή� END
				//------------------------------------------------------------------
				// < �e�Z�N�V���������␳ >
				//------------------------------------------------------------------
				// �w�b�_�[�������␳
				cr.Section2.Height  += i�w�b�_�[���㉺�␳;
				// �ڍו��P
				cr.Section3.Height  += i�ڍו��P�㉺�␳;
				// �ڍו��Q�|�P // 1����
				cr.Section9.Height  += i�ڍו��Q�㉺�␳;
				// �ڍו��Q�|�Q // 2���ڈȍ~
				cr.Section10.Height += i�ڍו��Q�㉺�␳;
				// �t�b�^�[�������␳
				cr.Section5.Height  += i�t�b�^�[���㉺�␳;
				//------------------------------------------------------------------
				// << ���E�ʒu�␳ >>
				//------------------------------------------------------------------
				int i���E�␳ = i�␳�P�� * (-4); // �� 1 mm
				//------------------------------------------------------------------
				// < �ڍו��P�F���E�ʒu�␳ >
				//------------------------------------------------------------------
				// �ڍו��P�F�o�הN����
				cr.Section3.ReportObjects["Field16"].Left += i���E�␳;
				cr.Section3.ReportObjects["Field17"].Left += i���E�␳;
				cr.Section3.ReportObjects["Field18"].Left += i���E�␳;
				//------------------------------------------------------------------
				// < �ڍו��Q�|�P�F���E�ʒu�␳ >
				//------------------------------------------------------------------
				// �ڍו��Q�|�P�F�ב��l�X�֔ԍ��A�Z���A���O
				cr.Section9.ReportObjects["Field79"].Left += i���E�␳;
				cr.Section9.ReportObjects["Field61"].Left += i���E�␳;
				cr.Section9.ReportObjects["Field62"].Left += i���E�␳;
				cr.Section9.ReportObjects["Field63"].Left += i���E�␳;
				cr.Section9.ReportObjects["Field64"].Left += i���E�␳;
				// �ڍו��Q�|�P�F�ב��l�S����
				cr.Section9.ReportObjects["Field45"].Left += i���E�␳;
// ADD 2015.01.20 BEVAS)�O�c ���͗��ǉ��󎚑Ή� START
//				cr.Section9.ReportObjects["Box2"].Left    += i���E�␳;    // ��̈�g
				cr.Section9.ReportObjects["Text2"].Left    += i���E�␳;   // ��̈󕶎�
				cr.Section9.ReportObjects["Text13"].Left    += i���E�␳;  // �ی����w�i
				cr.Section9.ReportObjects["Text6"].Left    += i���E�␳;   // �ی���(����)
				cr.Section9.ReportObjects["Field54"].Left    += i���E�␳; // �ی���(���z)
				cr.Section9.ReportObjects["Text7"].Left    += i���E�␳;   // �~

				cr.Section9.ReportObjects["�e�׎Dkg�g"].Left    += i���E�␳;
				cr.Section9.ReportObjects["�e�׎Dcm�g"].Left    += i���E�␳;
				cr.Section9.ReportObjects["�e�׎D�ː��g"].Left  += i���E�␳;
				cr.Section9.ReportObjects["txt�e�׎Dkg"].Left   += i���E�␳;
				cr.Section9.ReportObjects["txt�e�׎Dcm"].Left   += i���E�␳;
				cr.Section9.ReportObjects["txt�e�׎D�ː�"].Left += i���E�␳;
// ADD 2015.01.20 BEVAS)�O�c ���͗��ǉ��󎚑Ή� END
				//------------------------------------------------------------------
				// < �ڍו��Q�|�Q�F���E�ʒu�␳ >
				//------------------------------------------------------------------
				// �ڍו��Q�|�Q�F�ב��l�X�֔ԍ��A�Z���A���O
				cr.Section10.ReportObjects["Field21"].Left += i���E�␳;
				cr.Section10.ReportObjects["Field66"].Left += i���E�␳;
				cr.Section10.ReportObjects["Field67"].Left += i���E�␳;
				cr.Section10.ReportObjects["Field68"].Left += i���E�␳;
				cr.Section10.ReportObjects["Field69"].Left += i���E�␳;
				// �ڍו��Q�|�Q�F�ב��l�S����
				cr.Section10.ReportObjects["Field20"].Left += i���E�␳;
// ADD 2015.01.20 BEVAS)�O�c ���͗��ǉ��󎚑Ή� START
				cr.Section10.ReportObjects["Text16"].Left    += i���E�␳;  // �ی����w�i
				cr.Section10.ReportObjects["Text19"].Left    += i���E�␳;  // �ی���(����)
				cr.Section10.ReportObjects["Field56"].Left   += i���E�␳;  // �ی���(���z)
				cr.Section10.ReportObjects["Text20"].Left    += i���E�␳;  // �~
				
				cr.Section10.ReportObjects["�q�׎Dkg�g"].Left    += i���E�␳;
				cr.Section10.ReportObjects["�q�׎Dcm�g"].Left    += i���E�␳;
				cr.Section10.ReportObjects["�q�׎D�ː��g"].Left  += i���E�␳;
				cr.Section10.ReportObjects["txt�q�׎Dkg"].Left   += i���E�␳;
				cr.Section10.ReportObjects["txt�q�׎Dcm"].Left   += i���E�␳;
				cr.Section10.ReportObjects["txt�q�׎D�ː�"].Left += i���E�␳;
// ADD 2015.01.20 BEVAS)�O�c ���͗��ǉ��󎚑Ή� END
				//------------------------------------------------------------------
				// < �t�b�^�[���F���E�ʒu�␳ >
				//------------------------------------------------------------------
				// �t�b�^�[���F�׎�l�d�b�ԍ��A�׎�l�R�[�h
				cr.Section5.ReportObjects["Field43"].Left += i���E�␳;
				cr.Section5.ReportObjects["Field59"].Left += i���E�␳;
				// �t�b�^�[���F�o�הN����
				cr.Section5.ReportObjects["Field40"].Left += i���E�␳;
				cr.Section5.ReportObjects["Field41"].Left += i���E�␳;
				cr.Section5.ReportObjects["Field42"].Left += i���E�␳;
				// �t�b�^�[���F�׎�l�X�֔ԍ�
				cr.Section5.ReportObjects["Field80"].Left += i���E�␳;
				// �t�b�^�[���F�׎�l�Z��
				cr.Section5.ReportObjects["Field23"].Left += i���E�␳;
				cr.Section5.ReportObjects["Field24"].Left += i���E�␳;
				cr.Section5.ReportObjects["Field25"].Left += i���E�␳;
				cr.Section5.ReportObjects["Field77"].Left += i���E�␳;
				cr.Section5.ReportObjects["Field78"].Left += i���E�␳;
				// �t�b�^�[���F�׎�l���O
				cr.Section5.ReportObjects["Field26"].Left += i���E�␳;
				cr.Section5.ReportObjects["Field27"].Left += i���E�␳;
				// �t�b�^�[���F�ב��l�X�֔ԍ��A�Z���A���O
				cr.Section5.ReportObjects["Field5" ].Left += i���E�␳;
				cr.Section5.ReportObjects["Field48"].Left += i���E�␳;
				cr.Section5.ReportObjects["Field29"].Left += i���E�␳;
				cr.Section5.ReportObjects["Field31"].Left += i���E�␳;
				cr.Section5.ReportObjects["Field32"].Left += i���E�␳;
				// �t�b�^�[���F�ב��l�S����
				cr.Section5.ReportObjects["Field28"].Left += i���E�␳;
			}
// MOD 2011.03.03 ���s�j���� �v�����^���Ƃ̕␳�Ή� END


// MOD 2010.03.19 ���s�j���� ������̎w��i���Ή��P�j START
//			cr.SetDataSource(ds�����);
//�ĂP START
//			cr.SetDataSource(ds�����.table�����);
//�ĂP END 
//�ĂQ START �~
//			DataTable dt2 = ds�����.table�����.Clone();
//			DataRow[] dra = ds�����.table�����.Select();//�Ȃ���������ɂȂ�//���Ȃ�Ȃ�
//			foreach (DataRow dr in dra){
//				dt2.ImportRow(dr);
//			}
//			dt2.AcceptChanges();
//			cr.SetDataSource(dt2);
//�ĂQ END
//�ĂR START
			DataView dv = ds�����.table�����.DefaultView;
			dv.Sort = "����� ASC";
//			dv.Sort = "����� DESC"; //���t���Ƀv���r���[���ꂽ
			DataTable dt2 = ds�����.table�����.Clone();
			foreach (DataRowView drv in dv) {
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j START
//				dt2.ImportRow(drv.Row);
				dt2.Rows.Add(drv.Row.ItemArray);
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j END
			}
			dt2.AcceptChanges();
			cr.SetDataSource(dt2);
//�ĂR END
// MOD 2010.03.19 ���s�j���� ������̎w��i���Ή��P�j END

			//CrystalReport�̈���ݒ�
			cr.PrintOptions.PrinterName = pd�T�[�}���v�����^.PrinterSettings.PrinterName;

#if DEBUG
#else
			//���
			cr.PrintToPrinter(1, false, 0, 0);
#endif

			//�v���r���[�\��
#if DEBUG
			�v���r���[��� ��� = new �v���r���[���();
			���.crv���[.PrintReport();
			���.crv���[.ReportSource = cr;
			���.ShowDialog();

			//���
			cr.PrintToPrinter(1, false, 0, 0);
#endif

// MOD 2011.01.25 ���s�j���� �u���[�h�Ɏ��s�v�Ή� START
			try{
				cr.Close();
				cr.Dispose();
			}catch(Exception){
				;
			}
// MOD 2011.01.25 ���s�j���� �u���[�h�Ɏ��s�v�Ή� END
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j START
			//�����I�̈�J��
			cr  = null;
			dv  = null;
			dt2 = null;

			//�����I�K�x�[�W�R���N�^
			System.GC.Collect();

// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j END
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j START
//// ADD 2005.07.11 ���s�j�����J ������̐��� START
//			i����� = 0;
//// ADD 2005.07.11 ���s�j�����J ������̐��� END
//
//			ds�����.Clear();
			�����f�[�^�N���A();
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j END
		}		
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j START
		protected void �����f�[�^�N���A()
		{
			i����� = 0;

			ds�����.Clear();

			//�����I�̈�J��
			ds����� = null;

			//�����I�K�x�[�W�R���N�^
			System.GC.Collect();

			//�����f�[�^�̈�č쐬
			ds����� = new �����f�[�^();
		}
// MOD 2010.07.26 ���s�j���� ������̎w��i���Ή��Q�j END

		protected string ����o�ד����X�V()
		{
			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sRet = {""};
			try
			{
				// ��������̎擾�igs����b�c�Ags����b�c�j
				if(sv_init == null) sv_init = new is2init.Service1();
				sRet = sv_init.Get_syukabi(gsa���[�U,gs����b�c, gs����b�c);

				if(sRet[0].Length == 4){
					gs�o�ד�       = sRet[1];
					if(gs�o�ד�.Length == 8)
					{
						gdt�o�ד� = new DateTime(int.Parse(gs�o�ד�.Substring(0,4)), 
												int.Parse(gs�o�ד�.Substring(4,2)),
												int.Parse(gs�o�ד�.Substring(6)) );
					}
				}
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

			// ����I����
			if(sRet[0].Length == 4) return "";

			return sRet[0];
		}

// ADD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX START
		protected static string YYYYMMDD�ϊ�(DateTime dtDate)
		{
			return dtDate.Year.ToString() + dtDate.ToString("MMdd");
		}

		protected static DateTime YYYYMMDD�ϊ�(string sDate)
		{
			sDate = sDate.Replace("/","");
			if(sDate.Length == 6) sDate = "20" + sDate;
			if(sDate.Length != 8) return DateTime.Today;
			
			return new DateTime(int.Parse(sDate.Substring(0,4)), 
								int.Parse(sDate.Substring(4,2)),
								int.Parse(sDate.Substring(6)));
		}
// ADD 2005.07.08 ���s�j���� ���t�ϊ��̕ύX END

// ADD 2006.08.10 ���s�j���� �h�b�^�O�Ή��r�`�s�n���v�����^�Ή� START
		private static byte[] toSJIS_CSV(string s�f�[�^, bool bCRLF)
		{

			byte[] bSJIS;
			if(bCRLF)
				bSJIS = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(s�f�[�^ + "\n");
			else
				bSJIS = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(s�f�[�^ + ",");
			return bSJIS;
		}

		private static void �ו��f�[�^�o��(FileStream fs, int iCSVData, bool bCRLF)
		{
			byte[] bSJIS;
			string sCSVData = iCSVData.ToString();
			bSJIS = toSJIS_CSV(sCSVData, bCRLF);
			fs.Write(bSJIS, 0 , bSJIS.Length);
		}

		private static void �ו��f�[�^�o��(FileStream fs, string sCSVData, bool bCRLF)
		{
			byte[] bSJIS;
			bSJIS = toSJIS_CSV("\"" + sCSVData + "\"", bCRLF);
			fs.Write(bSJIS, 0 , bSJIS.Length);
		}
// ADD 2006.08.10 ���s�j���� �h�b�^�O�Ή��r�`�s�n���v�����^�Ή� END
// ADD 2008.04.11 ACT Vista�Ή� START
		protected static void �����ϊ��n�b�V���ݒ�()
		{
			string [,] s�����ϊ� = CharConvUtility.CharConvUtility.GetCharConvTable();
			gh�����ϊ�  = new Hashtable();
			for(int iCnt = 0; iCnt < s�����ϊ�.GetLength(0); iCnt++)
			{
				gh�����ϊ�.Add(s�����ϊ�[iCnt,0],s�����ϊ�[iCnt,1]);
			}
		}

		private static bool �����ϊ�(TextBox tex, string name, ref string sUnicode, ref byte[] bSjis)
		{
			string sErrChars = "";
			string sOKHChars = "";
			string sNotHChars = "";
			string sAllChars = "";
			string sBefChars = "";
			string sMessage = "";
			string sMessage2 = "";
			string sAfterCode = null;
			int iNotHash = 0;

			string sOneMozi = "";
			string sOneUni = "";
			System.Text.Encoding enc = System.Text.Encoding.GetEncoding("unicodeFFFE");
			//������̒�����1���������o��
			System.Globalization.TextElementEnumerator Enumerator = System.Globalization.StringInfo.GetTextElementEnumerator(sUnicode);
			while (Enumerator.MoveNext())
			{
				sOneMozi = Enumerator.Current.ToString();

				//���o����1�������o�C�g�^�ɕϊ�
				byte[] bOneCode = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sOneMozi);
				//�o�C�g�^��string�^�ɕϊ�
				string sRevUnicode = System.Text.Encoding.GetEncoding("shift-jis").GetString(bOneCode);

				if(sOneMozi != sRevUnicode)
				{
					//�ϊ��e�[�u����8���Ή�
					byte [] bytes = enc.GetBytes(sOneMozi);
					sOneUni = BitConverter.ToString(bytes).Replace("-","");
					if(sOneUni.Length == 4)
					{
						sOneUni += sOneUni;
					}
					//�����ϊ�
					sAfterCode = (string)gh�����ϊ�[sOneUni];
					if(sAfterCode != null)
					{
						if(sAfterCode == "" || sAfterCode == "4040")
						{
							//�ϊ��ł��Ȃ���������
							sNotHChars += sOneMozi;
							sAllChars += sOneMozi;
						}
						else
						{
							//�R�[�h���當�����擾
							int iAfter = Convert.ToInt16(sAfterCode,16);
							char cAfter = (char)iAfter;
							string sAfterL = Convert.ToString(cAfter);
							//�ϊ���̕�������
							sOKHChars += sAfterL;
							sAllChars += sAfterL;
							//�ϊ��O�̕�������
							sBefChars += sOneMozi;
						}	
					}
					else
					{
						//�e�[�u���ɑ��݂��Ȃ���������
						sErrChars += sOneMozi;
						sAllChars += sOneMozi;
						sAfterCode = "";
						iNotHash = 1;	
					}	
				}
				else
				{	
					sAllChars += sOneMozi;
				}
			}
			Enumerator.Reset();

			bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sAllChars);
			string sBefMozi = "";
			sBefMozi = sUnicode;

			if(sAfterCode != null)
			{
				if(sNotHChars.Length > 0)
				{
					sMessage = "2";
				}
				else if(sOKHChars.Length > 0)
				{
					sMessage = "1";
				}
			}

			if(iNotHash == 1)
			{
				sMessage2 = "3";
			}

			if(sMessage == "1")
			{
				tex.Text = sAllChars;
				DialogResult result = MessageBox.Show(name + "��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���\n" 
					+ "�w" + sBefChars + " �� " + sOKHChars + "�x", "���̓`�F�b�N", 
					MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
				if (result == DialogResult.Cancel)
				{
					tex.Text = sBefMozi;
					tex.Focus();
					return false;
				}
				else
				{
					sUnicode = sAllChars;
				}
			}
			if(sMessage == "2")
			{
				MessageBox.Show(name + "��Vista�Ή��ɂ�蕶���ϊ��������Ȃ��܂���ł���\n"
					+ "�w" + sNotHChars + " �� ? �x",
					"���̓`�F�b�N",MessageBoxButtons.OK);
				if(sMessage2 != "3")
				{
					tex.Focus();
					return false;
				}
			}
			if(sMessage2 == "3")
			{
				MessageBox.Show(name + "�Ɏg�p�ł��Ȃ�����������܂�\n"
					+ "�w" + sErrChars + " �� ? �x",
					"���̓`�F�b�N",MessageBoxButtons.OK);
				tex.Focus();
				return false;
			}
			return true;
		}
		
		protected static bool �����ϊ�_CSV(ref string data, ref string err)
		{
			string sUnicode = data;
			string sErrChars = "";
			string sOKHChars = "";
			string sAllChars = "";
			string sAfterCode = null;

			string sOneMozi = "";
			string sOneUni = "";
			System.Text.Encoding enc = System.Text.Encoding.GetEncoding("unicodeFFFE");
			//������̒�����1���������o��
			System.Globalization.TextElementEnumerator Enumerator = System.Globalization.StringInfo.GetTextElementEnumerator(sUnicode);
			while (Enumerator.MoveNext())
			{
				sOneMozi = Enumerator.Current.ToString();

				//���o����1�������o�C�g�^�ɕϊ�
				byte[] bOneCode = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sOneMozi);
				//�o�C�g�^��string�^�ɕϊ�
				string sRevUnicode = System.Text.Encoding.GetEncoding("shift-jis").GetString(bOneCode);

				if(sOneMozi != sRevUnicode)
				{
					//�ϊ��e�[�u����8���Ή�
					byte [] bytes = enc.GetBytes(sOneMozi);
					sOneUni = BitConverter.ToString(bytes).Replace("-","");
					if(sOneUni.Length == 4)
					{
						sOneUni += sOneUni;
					}
					//�����ϊ�
					sAfterCode = (string)gh�����ϊ�[sOneUni];
					if(sAfterCode != null)
					{
						if(sAfterCode == "" || sAfterCode == "4040")
						{
							//�ϊ��ł��Ȃ���������
							sErrChars += sOneMozi;
							sAllChars += sOneMozi;
						}
						else
						{
							//�R�[�h���當�����擾
							int iAfter = Convert.ToInt16(sAfterCode,16);
							char cAfter = (char)iAfter;
							string sAfterL = Convert.ToString(cAfter);
							//�ϊ���̕�������
							sOKHChars += sAfterL;
							sAllChars += sAfterL;
						}	
					}
					else
					{
						//�e�[�u���ɑ��݂��Ȃ���������
						sErrChars += sOneMozi;
						sAllChars += sOneMozi;
						sAfterCode = "";	
					}	
				}
				else
				{	
					sAllChars += sOneMozi;
				}
			}
			Enumerator.Reset();

			if(sErrChars.Length > 0)
			{
				data = sAllChars;
				err = sErrChars;
				return false;
			}

			data = sAllChars;
			err = sErrChars;
			return true;
		}
// ADD 2008.04.11 ACT Vista�Ή� END
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� START
		// Microsoft.VisualBasic.Strings.StrConv(string, Microsoft.VisualBasic.VbStrConv.Wide, int);
		[DllImport("kernel32.dll",CharSet=CharSet.Unicode, SetLastError = true)] 
		private static extern int LCMapString(int Locale, uint dwMapFlags, string lpSrcStr, int cchSrc, [MarshalAs(UnmanagedType.LPArray)]  char[] lpDestStr, int cchDest);
		private static string MapString(string source)
		{
			char[] buffer = new char[source.Length * 2];
			//StringBuilder buffer = new StringBuilder(source.Length*2);
			int len = LCMapString((int)0x0411, (uint)0x00800000, source, source.Length, buffer, buffer.Length);
			if (len < 0){
				throw new ArgumentException("\"LCMAP_SORTKEY\" is not support ");
			}
			return new String(buffer,0,len);
		}
		protected bool �S�p�ϊ���`�F�b�N(string sSrc, string sDes)
		{
			// �ϊ��シ�ׂđS�p�����̏ꍇ
			if(!�S�p�`�F�b�N(sDes)){
#if DEBUG
				MessageBox.Show(
					"2883:�S�p�ϊ��Ɏ��s\n"
					+ "���p�������܂����Ă��܂���"
					, "["+sSrc+"]"
					, MessageBoxButtons.OK);
#endif
				return false;
			}

			// �ϊ���̕������Ɍ�肪����ꍇ
			int i���������� = 0;
			for(int iCnt = 0; iCnt < sSrc.Length; iCnt++){
				if(sSrc[iCnt] == '�'){
					i����������++;
					continue;
				}
				if(sSrc[iCnt] == '�'){
					i����������++;
					continue;
				}
			}
			if(sDes.Length >= sSrc.Length - i����������){
//				sSrc = sDes2;
				return true;
			}
#if DEBUG
			MessageBox.Show(
				"2875:�S�p�ϊ��Ɏ��s\n"
				+ "������["+sSrc.Length+"]��["+sDes.Length+"]"
				, "["+sSrc+"]"
				, MessageBoxButtons.OK);
#endif
			return false;
		}
		protected bool �S�p�ϊ��`�F�b�N(ref string data, ref string err)
		{
			// ���ׂđS�p�����̏ꍇ�́A���^�[��
			if(�S�p�`�F�b�N(data)){
				return true;
			}

			// ���p[\]�����݂���ꍇ�́A�S�p[��]�ɕϊ�
			if(data.IndexOf('\\') >= 0){
				data = data.Replace('\\','��');
			}

			// ���ׂđS�p�����̏ꍇ�́A���^�[��
			if(�S�p�`�F�b�N(data)){
				return true;
			}

			bool   bRet = true;
			string sRet = "";
			// �S�p�����ɕϊ�
			try{
				sRet = Microsoft.VisualBasic.Strings.StrConv(data
							, Microsoft.VisualBasic.VbStrConv.Wide
							, 0x0411);
#if DEBUG
			}catch(Exception ex){
				// StrConv�Ɏ��s
				MessageBox.Show(
					"2798:StrConv�Ɏ��s�iException�j\n"
					+ ex.Message
					, "["+data+"]"
					, MessageBoxButtons.OK);
#else
			}catch(Exception){
				// StrConv�Ɏ��s
#endif
				bRet = false;
			}

			// ����ɕϊ��ł����ꍇ
			if(bRet){
				// �ϊ��シ�ׂđS�p�����̏ꍇ�́A���^�[��
				if(�S�p�ϊ���`�F�b�N(data, sRet)){
					data = sRet;
					return true;
				}
				bRet = false;
			}
			
			try{
				string sRet2 = "";
				sRet2 = MapString(data);
				// �ϊ��シ�ׂđS�p�����̏ꍇ�́A���^�[��
				if(�S�p�ϊ���`�F�b�N(data, sRet2)){
					data = sRet2;
					return true;
				}
				bRet = false;
#if DEBUG
				MessageBox.Show(
					"2866:MapString�Ɏ��s\n"
					+ "[" + sRet2 + "]"
					, "["+data+"]"
					, MessageBoxButtons.OK);
#endif
#if DEBUG
			}catch(Exception ex){
				MessageBox.Show(
					"2892:MapString�Ɏ��s�iException�j\n"
					+ ex.Message
					, "["+data+"]"
					, MessageBoxButtons.OK);
#else
			}catch(Exception){
#endif
			}

			// �P�������ϊ����`�F�b�N����
//�ۗ�		bRet = true;
			sRet = "";
			string sErrChars = "";
			string sData = "";
			string sData2 = "";
			string sWide = "";
			string sRevUnicode = "";
			byte[] bSjis;

			for(int iCnt = 0; iCnt < data.Length; iCnt++){
				sData = "";
				sData = data.Substring(iCnt,1);
				if(�S�p�`�F�b�N(sData)){
					sRet += sData;
					continue;
				}
				// �����Ή�
				sData2 = "";
				if(iCnt+1 < data.Length){
					sData2 = data.Substring(iCnt+1,1);
				}
				try{
					bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sData);
					// �r�i�h�r�o�C�g�ϊ��G���[���F�X�L�b�v���Ď��̕�����
					if(bSjis == null || bSjis.Length == 0){
						sErrChars += sData;
						bRet = false;
#if DEBUG
						MessageBox.Show(
							"2827:GetEncoding(shift-jis).GetBytes�Ɏ��s�i�O�o�C�g�j"
							+ "[" + sData + "]"
							, "["+data+"]"
							, MessageBoxButtons.OK);
#endif
						continue;
					}
					////////////////////////////////////////////
					// �Q�o�C�g�����i�S�p�����j�̏ꍇ�F�������Ď��̕�����
					////////////////////////////////////////////
					if(bSjis.Length == 2){
						sRet += sData;
						continue;
					}
					// �P�o�C�g�����ȊO�̏ꍇ�F�X�L�b�v���Ď��̕�����
					if(bSjis.Length != 1){
						sErrChars += sData;
#if DEBUG
						MessageBox.Show(
							"2846:GetEncoding(shift-jis).GetBytes�Ɏ��s�i�P�o�C�g�ȊO�j"
							+ "[" + sData + "]"
							+ "[" + bSjis.Length + "]"
							, "["+data+"]"
							, MessageBoxButtons.OK);
#endif
						bRet = false;
						continue;
					}
					////////////////////////////////////////////
					// �P�o�C�g�����i���p�����j�̏ꍇ
					////////////////////////////////////////////
					// �����Ή�
					if(sData2 == "�" || sData2 == "�"){
						sData += sData2;
						iCnt++;
					}
					// �S�p�����ɕϊ�
					sWide = "";
					try{
						sWide = Microsoft.VisualBasic.Strings.StrConv(sData
									, Microsoft.VisualBasic.VbStrConv.Wide
									, 0x0411);
#if DEBUG
					}catch(Exception ex){
						MessageBox.Show(
							"2872:StrConv�Ɏ��s�iException�j"
							+ "[" + sData + "]\n"
							+ ex.Message
							, "["+data+"]"
							, MessageBoxButtons.OK);
#else
					}catch(Exception){
#endif
						sErrChars += sData;
						bRet = false;
						continue;
					}
					// �S�p�����ϊ��G���[���F�X�L�b�v���Ď��̕�����
					if(sWide == null || sWide.Length != 1){
						sErrChars += sData;
						bRet = false;
#if DEBUG
						MessageBox.Show(
							"2886:StrConv�Ɏ��s�i�P�����ȊO�j"
							+ "[" + sData + "]"
							+ "[" + sWide.Length + "]"
							, "["+data+"]"
							, MessageBoxButtons.OK);
#endif
						continue;
					}
					bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sWide);
					// �r�i�h�r�o�C�g�ϊ��G���[���F�X�L�b�v���Ď��̕�����
					if(bSjis == null || bSjis.Length == 0){
						sErrChars += sData;
						bRet = false;
#if DEBUG
						MessageBox.Show(
							"2900:GetEncoding(shift-jis).GetBytes�Ɏ��s�i�O�o�C�g�j"
							+ "[" + sData + "]"
							, "["+data+"]"
							, MessageBoxButtons.OK);
#endif
						continue;
					}
					// �ϊ���Q�o�C�g�����łȂ������ꍇ�F�X�L�b�v���Ď��̕�����
					if(bSjis.Length != 2){
						sErrChars += sData;
#if DEBUG
						MessageBox.Show(
							"2945:GetEncoding(shift-jis).GetBytes�Ɏ��s�i�Q�o�C�g�ȊO�j"
							+ "[" + sData + "]"
							+ "[" + bSjis.Length + "]"
							, "["+data+"]"
							, MessageBoxButtons.OK);
#endif
						bRet = false;
						continue;
					}
					//�o�C�g�^��string�^�ɕϊ�
					sRevUnicode = "";
					sRevUnicode = System.Text.Encoding.GetEncoding("shift-jis").GetString(bSjis);
					// �t�ϊ��㕶�����قȂ�ꍇ�F�X�L�b�v���Ď��̕�����
					if(sRevUnicode != sWide){
						sErrChars += sData;
#if DEBUG
						MessageBox.Show(
							"2961:GetEncoding(shift-jis).GetBytes�Ɏ��s�i�t�ϊ��Ɏ��s�j"
							+ "[" + sData + "]"
							, "["+data+"]"
							, MessageBoxButtons.OK);
#endif
						bRet = false;
						continue;
					}
					sRet += sWide;
#if DEBUG
				}catch(Exception ex){
					MessageBox.Show(
						"2973:���s�iException�j\n"
						+ "[" + sData + "]\n"
						+ ex.Message
						, "["+data+"]"
						, MessageBoxButtons.OK);
#else
				}catch(Exception){
#endif
					bRet = false;
					break;
				}
			}

//�ۗ�			if(bRet){
//�ۗ�				data = sRet;
//�ۗ�				return true;
//�ۗ�			}

			if(sErrChars.Length == 0){
				err = data;
			}else{
				err  = sErrChars;
			}

			return bRet;
		}
// MOD 2011.06.28 ���s�j���� Windows7��StrConv��Q�Ή� END
// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
		protected void �c�o�h�\���T�C�Y�ϊ�()
		{
			if(giDisplayDpiX == 0 || giDisplayDpiY == 0){
				//�𑜓x(dpi)���擾.
				Graphics g = this.CreateGraphics();
				giDisplayDpiX = (int)g.DpiX;
				giDisplayDpiY = (int)g.DpiY;
				g.Dispose();
			}
//			int iDisplayX = 0; 
//			int iDisplayY = 0; 
//			if(giDisplayDpiX != 96 || giDisplayDpiY != 96){
//				iDisplayX  = this.Width  * giDisplayDpiX / 96;
//				iDisplayY  = this.Height * giDisplayDpiY / 96;
//				this.MaximumSize = new Size(iDisplayX, iDisplayY);
//				this.Width  = iDisplayX;
//				this.Height = iDisplayY;
			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
				this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			}
		}
// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� END
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� START
		private string gsColsWidth = "";
		protected void �J�������̕␳(AxGTABLE32V2Lib.AxGTable32 ax�ꗗ)
		{
			if(giDisplayDpiX == 96){
				return;
			}
			if(gsColsWidth.Length > 0){
				ax�ꗗ.ColsWidth = gsColsWidth;
				return;
			}

			double d�␳�l�P = 0.95; // �L�������Ȃ�
			double d�␳�l�Q = 0.90; // �L�������Ȃ�
			if(this.Text == "is-2 �������񃁃��e�i���X"){
				d�␳�l�P = 0.99;
				d�␳�l�Q = 0.90;
			}
			if(this.Text == "is-2 ���˗��匟��"){
				d�␳�l�P = 0.99;
				d�␳�l�Q = 0.60;
			}

			string sColsWidth = ax�ꗗ.ColsWidth;
			string sWork = "";
			try{
				string[] sCols = sColsWidth.Split('|');
				for(int iCnt = 0; iCnt < sCols.Length; iCnt++){
					string sCol = sCols[iCnt].Trim();
					if(sCol == ""){
						sWork += "";
					}else if(sCol == "0"){
						sWork += "0";
					}else{
						try{
							double dCol = double.Parse(sCol);
							// ������Q�ʂ�؂�グ
							sWork += ((int)(dCol*10*d�␳�l�P+d�␳�l�Q))/10;
						}catch(Exception){
							sWork += sCol;
						}
					}
					if(iCnt != sCols.Length - 1){
						sWork += "|";
					}
				}
			}catch(Exception){
				sWork = sColsWidth;
			}
			gsColsWidth = sWork;
			ax�ꗗ.ColsWidth = gsColsWidth;
			return ;
		}
// MOD 2010.09.02 ���s�j���� �I�����̂���̑Ή� END
// MOD 2011.03.03 ���s�j���� �v�����^���Ƃ̕␳�Ή� START
		private void CheckReportDefOut(Section sec)
		{
			ReportObjects robj = sec.ReportObjects;
			
			string[] sTypeName = new string[robj.Count];
			string[] sName     = new string[robj.Count];
			string[] sValue    = new string[robj.Count];
			string[] sFontName = new string[robj.Count];
			string[] sFontSize = new string[robj.Count];
			string[] sFontStyle = new string[robj.Count];
			int[]    iTop      = new int[robj.Count];
			int[]    iHeight   = new int[robj.Count];
			int[]    iLeft     = new int[robj.Count];
			int[]    iWidth    = new int[robj.Count];
			object      oTmp   = null;
			FieldObject fldTmp = null;
			TextObject  texTmp = null;
			BoxObject   boxTmp = null;

			System.IO.FileStream fs = null;
			try{
				fs = new FileStream(
					Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
					+ @"\���x����`_is2"
					+ "_" + DateTime.Now.ToString("yyyyMMdd")
					+ "_" + gsa���[�U[3]
					+ ".txt", 
					FileMode.Append, FileAccess.Write,FileShare.Read);
				�ו��f�[�^�o��(fs, "["+sec.Kind+"]", false);
				�ו��f�[�^�o��(fs, sec.Name, false);
				�ו��f�[�^�o��(fs, sec.Height, true);

				int iPos = 0;
				while(robj.MoveNext()){
					oTmp = robj.Current;
					sTypeName[iPos] = oTmp.GetType().ToString();
					if(oTmp is FieldObject){
						fldTmp = (FieldObject)robj.Current;
						sName [iPos] = fldTmp.Name;
						sValue[iPos] = "["+fldTmp.DataSource.Name+"]";
						sFontName[iPos]  = fldTmp.Font.Name;
						sFontSize[iPos]  = fldTmp.Font.Size.ToString();
						sFontStyle[iPos] = "";
						if(fldTmp.Font.Bold){
							sFontStyle[iPos] += "Bold ";
						}
						iTop[iPos]    = fldTmp.Top;
						iLeft[iPos]   = fldTmp.Left;
						iHeight[iPos] = fldTmp.Height;
						iWidth[iPos]  = fldTmp.Width;
					}else if(oTmp is TextObject){
						texTmp = (TextObject)robj.Current;
						sName [iPos] = texTmp.Name;
						sValue[iPos] = texTmp.Text;
						sFontName[iPos]  = texTmp.Font.Name;
						sFontSize[iPos]  = texTmp.Font.Size.ToString();
						sFontStyle[iPos] = "";
						if(texTmp.Font.Bold){
							sFontStyle[iPos] += "Bold ";
						}
						iTop[iPos]    = texTmp.Top;
						iLeft[iPos]   = texTmp.Left;
						iHeight[iPos] = texTmp.Height;
						iWidth[iPos]  = texTmp.Width;
					}else if(oTmp is BoxObject){
						boxTmp = (BoxObject)robj.Current;
						sName [iPos] = boxTmp.Name;
						sValue[iPos] = "";
						sFontName[iPos]  = "";
						sFontSize[iPos]  = "";
						sFontStyle[iPos] = "";
						iTop[iPos]    = boxTmp.Top;
						iLeft[iPos]   = boxTmp.Left;
						iHeight[iPos] = boxTmp.Height;
						iWidth[iPos]  = boxTmp.Width;
					}else{
						�ו��f�[�^�o��(fs, sTypeName[iPos], true);
						iPos++;
						continue;
					}
					�ו��f�[�^�o��(fs, sName[iPos], false);
					�ו��f�[�^�o��(fs, sValue[iPos], false);
					�ו��f�[�^�o��(fs, sFontName[iPos], false);
					�ו��f�[�^�o��(fs, sFontSize[iPos], false);
					�ו��f�[�^�o��(fs, sFontStyle[iPos], false);
					�ו��f�[�^�o��(fs, iTop[iPos], false);
					�ו��f�[�^�o��(fs, iLeft[iPos], false);
					�ו��f�[�^�o��(fs, iHeight[iPos], false);
					�ו��f�[�^�o��(fs, iWidth[iPos], true);
					iPos++;
				}
			}catch(Exception ex){
				throw new Exception(ex.Message);
			}finally{
				if(fs != null) fs.Close();
			}
			return;
		}
		private void SetRptFontSize(ReportObject robj, double dSize)
		{
			FieldObject fldTmp = null;
			Font fntTmp = null;
			try{
				if(robj is FieldObject){
					fldTmp = (FieldObject)robj;
//					fntTmp = new Font(fldTmp.Name, fldTmp.Font.Size, FontStyle.Bold);
					fntTmp = new Font(fldTmp.Name, fldTmp.Font.Size);
					fldTmp.ApplyFont(fntTmp);
				}
			}catch(Exception ex){
				throw new Exception(ex.Message);
			}
			return;
		}
// MOD 2011.03.03 ���s�j���� �v�����^���Ƃ̕␳�Ή� END

// ADD 2015.03.05 BEVAS) �O�c�@�x�X�~�ߑΉ� START
		protected string �S�p�����ϊ�(string sData)
		{
			// �����`�F�b�N
			if(sData.Length != 3)
			{
				return "�X���R�[�h���R���ł͂���܂���B";
			}

			string wk = "";
			for(int i = 0; i < sData.Length; i++)
			{
				string sData_letter = sData.Substring(i, 1);
				switch(sData_letter)
				{
					case "0":
						sData_letter = sData_letter.Replace("0", "�O");
						break;
					case "1":
						sData_letter = sData_letter.Replace("1", "�P");
						break;
					case "2":
						sData_letter = sData_letter.Replace("2", "�Q");
						break;
					case "3":
						sData_letter = sData_letter.Replace("3", "�R");
						break;
					case "4":
						sData_letter = sData_letter.Replace("4", "�S");
						break;
					case "5":
						sData_letter = sData_letter.Replace("5", "�T");
						break;
					case "6":
						sData_letter = sData_letter.Replace("6", "�U");
						break;
					case "7":
						sData_letter = sData_letter.Replace("7", "�V");
						break;
					case "8":
						sData_letter = sData_letter.Replace("8", "�W");
						break;
					case "9":
						sData_letter = sData_letter.Replace("9", "�X");
						break;
				}
				wk += sData_letter;
				sData_letter = "";
			}

			// �ϊ���̓X���R�[�h���s���ł������ꍇ
			if(wk.Length != 3)
			{
				return "�ϊ���̓X���R�[�h���A���p�����R���ł͂���܂���B�s���Ȍ`���ł��B";
			}

			return wk;
		}
// ADD 2015.03.05 BEVAS) �O�c�@�x�X�~�ߑΉ� END

// MOD 2015.05.07 BEVAS) �O�c ���qCM14J�X�֔ԍ����݃`�F�b�N�Ή� START
		protected string[] �b�l�P�S�X�֔ԍ����݃`�F�b�N(string s�X�֔ԍ�) 
		{
			string[] sRet = {""};
 
			if (gs����b�c.Substring(0,1) != "J")
			{
				// ���ʂ̗X�֔ԍ��}�X�^���`�F�b�N
				if(sv_address == null) sv_address = new is2address.Service1();
				sRet = sv_address.Get_byPostcode2(gsa���[�U,s�X�֔ԍ�);
			}
			else
			{
				// ���q�̗X�֔ԍ��}�X�^���`�F�b�N
				if(sv_oji == null) sv_oji = new is2oji.Service1();
				sRet = sv_oji.Get_byPostcode2(gsa���[�U,s�X�֔ԍ�);
			}
			return sRet;
		}
// MOD 2015.05.07 BEVAS) �O�c ���qCM14J�X�֔ԍ����݃`�F�b�N�Ή� END

// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� START
		protected void �׎D�T������w��(string[] sData, int i�J�n, int i�I��)
		{
			gb��� = true;
			try
			{
				if(gs���p�ҕ���X���b�c == null || gs���p�ҕ���X���b�c.Length == 0)
				{
					gs���p�ҕ���X���b�c = "";
					gs���p�ҕ���X���b�c = ����X���擾(gs���p�ҕ���b�c);
				}

				//����f�[�^�̍쐬
				String[] sPrintKey = new string[5];
				sPrintKey[0] = gs����b�c;
				sPrintKey[1] = gs����b�c;
				sPrintKey[2] = sData[0];	//�o�^��
				sPrintKey[3] = sData[1];	//�W���[�i���m�n
				sPrintKey[4] = gs���p�ҕ���X���b�c;

				if(sv_print == null) sv_print = new is2print.Service1();
				if(sv_oji == null) sv_oji = new is2oji.Service1();
				String[] sPrintData;
				if (gs����b�c.Substring(0,1) != "J")
				{
					sPrintData = sv_print.Get_InvoicePrintData(gsa���[�U,sPrintKey);
				}
				else
				{
					sPrintData = sv_oji.Get_InvoicePrintData(gsa���[�U,sPrintKey);
				}
				
				if (!sPrintData[0].Equals("����I��"))
				{
					throw new Exception(sPrintData[0]);
				}

				if(gs���p�ҕ���X���b�c == null || gs���p�ҕ���X���b�c.Length == 0)
				{
					gs���p�ҕ���X���b�c = ����X���擾(gs���p�ҕ���b�c);
				}

				if(gs���p�ҕ���X���b�c == null || gs���p�ҕ���X���b�c.Length == 0)
				{
					// �������Ȃ�
				}
				else
				{
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� START
//					// �X���ƕ���X�����قȂ�ꍇ(�W�דX�擾�G���[)�́A������Ȃ�
//					if(!gs���p�ҕ���X���b�c.Trim().Equals(sPrintData[14].Trim().Substring(1, 3)))
//					{
//						gb��� = false;
//						return;
//					}
					//�Г��`�̏ꍇ�́A�X���ƕ���X�����قȂ��Ă��悢
					if(!gs���p�ҕ���X���b�c.Equals("044"))
					{
						// �X���ƕ���X�����قȂ�ꍇ(�W�דX�擾�G���[)�́A������Ȃ�
						if(!gs���p�ҕ���X���b�c.Trim().Equals(sPrintData[14].Trim().Substring(1, 3)))
						{
							gb��� = false;
							return;
						}
					}
				}
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� END
//				//����󔭍s�̃`�F�b�N
//				if (!sPrintData[33].Equals("1")) // ����󔭍s�ςe�f
//				{
//					//����󂪖����s�̏ꍇ�B�����ԍ��̍̔�
//					String[] sGetKey = new string[4];
//					sGetKey[0] = gs����b�c;
//					sGetKey[1] = gs����b�c;
//					// �A�����i�ɂ���Ēl��ύX
//					sGetKey[2] = sPrintData[32]; //�����敪 + "0" or "1"
//					// �O���[�o���Ή��i�o�ד��A���X�̔�\���j
//					if(sPrintData[14].Substring(1, 3) == "047")
//					{
//						sGetKey[2] = sPrintData[32].Substring(0,1) + "G"; //�����敪 + "G"
//					}
//					sGetKey[3] = gs���p�҂b�c;
//
//					//�����ԍ��X�V
//					//�i�����ԍ��A����󔭍s�ςe�f�A��ԁA���X�̍X�V�j
//					String[] sSetKey = new string[6];
//					sSetKey[0] = gs����b�c;
//					sSetKey[1] = gs����b�c;
//					sSetKey[2] = sData[0];       // �o�^��
//					sSetKey[3] = sData[1];       // �W���[�i���m�n
//					sSetKey[4] = sPrintData[11]; // �����ԍ�
//					sSetKey[5] = gs���p�҂b�c;
//
//					if(sv_print == null) sv_print = new is2print.Service1();
//					if(sv_oji == null) sv_oji = new is2oji.Service1();
//					String[] sSetData;
//					if (gs����b�c.Substring(0,1) != "J")
//					{
//						sSetData = sv_print.Set_InvoiceNo(gsa���[�U,sSetKey);
//
//					}
//					else
//					{
//						sSetData = sv_oji.Set_InvoiceNo(gsa���[�U,sSetKey);
//					}
//					
//					if (!sSetData[0].Equals("����I��"))
//					{
//						throw new Exception(sSetData[0]);
//					}
//				}

				if(gs�I�v�V����[18].Equals("1"))
				{
					sPrintData[5] = sPrintData[5].TrimEnd(); // �׎�l�Z���P
					sPrintData[6] = sPrintData[6].TrimEnd(); // �׎�l�Z���Q
					sPrintData[7] = sPrintData[7].TrimEnd(); // �׎�l�Z���R
					sPrintData[8] = sPrintData[8].TrimEnd(); // �׎�l���O�P
					sPrintData[9] = sPrintData[9].TrimEnd(); // �׎�l���O�Q

					sPrintData[18] = sPrintData[18].TrimEnd(); // �ב��l�Z���P
					sPrintData[19] = sPrintData[19].TrimEnd(); // �ב��l�Z���Q
					sPrintData[21] = sPrintData[21].TrimEnd(); // �ב��l���O�P
					sPrintData[22] = sPrintData[22].TrimEnd(); // �ב��l���O�Q
					sPrintData[34] = sPrintData[34].TrimEnd(); // �S����
					
					sPrintData[29] = sPrintData[29].TrimEnd(); // �i���L���P
					sPrintData[30] = sPrintData[30].TrimEnd(); // �i���L���Q
					sPrintData[31] = sPrintData[31].TrimEnd(); // �i���L���R
					if(sPrintData.Length > 42)
					{
						sPrintData[42] = sPrintData[42].TrimEnd(); // �i���L���S
						sPrintData[43] = sPrintData[43].TrimEnd(); // �i���L���T
						sPrintData[44] = sPrintData[44].TrimEnd(); // �i���L���U
					}
				}
				else
				{
					sPrintData[5] = sPrintData[5].Trim(); // �׎�l�Z���P
					sPrintData[6] = sPrintData[6].Trim(); // �׎�l�Z���Q
					sPrintData[7] = sPrintData[7].Trim(); // �׎�l�Z���R
					sPrintData[8] = sPrintData[8].Trim(); // �׎�l���O�P
					sPrintData[9] = sPrintData[9].Trim(); // �׎�l���O�Q

					sPrintData[18] = sPrintData[18].Trim(); // �ב��l�Z���P
					sPrintData[19] = sPrintData[19].Trim(); // �ב��l�Z���Q
					sPrintData[21] = sPrintData[21].Trim(); // �ב��l���O�P
					sPrintData[22] = sPrintData[22].Trim(); // �ב��l���O�Q
					sPrintData[34] = sPrintData[34].Trim(); // �S����
					
					sPrintData[29] = sPrintData[29].Trim(); // �i���L���P
					sPrintData[30] = sPrintData[30].Trim(); // �i���L���Q
					sPrintData[31] = sPrintData[31].Trim(); // �i���L���R
					if(sPrintData.Length > 42)
					{
						sPrintData[42] = sPrintData[42].Trim(); // �i���L���S
						sPrintData[43] = sPrintData[43].Trim(); // �i���L���T
						sPrintData[44] = sPrintData[44].Trim(); // �i���L���U
					}
				}

				if(gs�v�����^��� == "S0004")
				{
					string s�p�X�� = "C:\\";
					string s�t�@�C���� = "�ו��f�[�^�t�@�C��.csv";
					try
					{
						System.IO.FileStream fs = new FileStream(s�p�X�� + s�t�@�C����, 
							FileMode.Append, FileAccess.Write,FileShare.Read);
						try
						{
							string sCSVData = "";
							for (int iCnt = 0; iCnt < int.Parse(sPrintData[23]); iCnt++)
							{
								int    i�A�� = iCnt + 1;
								string s�A�� = i�A��.ToString();
								string s�ו��ԍ� = sPrintData[11].Substring(4) + s�A��.PadLeft(2, '0');

								//�ו��ԍ�
								sCSVData = s�ו��ԍ�;
								�ו��f�[�^�o��(fs, sCSVData, false);
								//�׎�l�d�b�ԍ�
								sCSVData = "(" + sPrintData[2] + ")" + sPrintData[3] + "-" + sPrintData[4];
								if(sPrintData[2].Replace("0","").Trim().Length == 0
									&& sPrintData[3].Replace("0","").Trim().Length == 0
									&& sPrintData[4].Replace("0","").Trim().Length == 0)
								{
									sCSVData = " ";
								}
								�ו��f�[�^�o��(fs, sCSVData, false);

								//�׎�l�Z���̓s���{���A�s�撬���A���̑��̕���
								string s�Z���ҏW  = �Z���ҏW(sPrintData[5]);
								string[] s�Z������ = s�Z���ҏW.Split(' ');

								//�׎�l�Z����
								�ו��f�[�^�o��(fs, s�Z������[0], false);

								//�׎�l�Z���s
								if (s�Z������.Length > 1)
								{
									�ו��f�[�^�o��(fs, s�Z������[1], false);
								}
								else
								{
									�ו��f�[�^�o��(fs, "", false);
								}
								//�׎�l�Z����
								if (s�Z������.Length > 2)
								{
									�ו��f�[�^�o��(fs, s�Z������[2], false);
								}
								else
								{
									�ו��f�[�^�o��(fs, "", false);
								}

								�ו��f�[�^�o��(fs, sPrintData[5], false);		//�׎�l�Z���P
								�ו��f�[�^�o��(fs, sPrintData[6], false);		//�׎�l�Z���Q
								�ו��f�[�^�o��(fs, sPrintData[7], false);		//�׎�l�Z���R
								�ו��f�[�^�o��(fs, sPrintData[8], false);		//�׎�l���O�P
								�ו��f�[�^�o��(fs, sPrintData[9], false);		//�׎�l���O�Q

								if(sPrintData[14].Substring(1, 3) == "047")
								{
									�ו��f�[�^�o��(fs, "", false);	//�o�ד��N
									�ו��f�[�^�o��(fs, "", false);	//�o�ד���
									�ו��f�[�^�o��(fs, "", false);	//�o�ד���
								}
								else
								{
									�ו��f�[�^�o��(fs, sPrintData[10], false);	//�o�ד��N
									//�o�ד���
									if(sPrintData[10].Substring(4, 1) == "0")
										sCSVData = " " + sPrintData[10].Substring(5, 1);
									else
										sCSVData = sPrintData[10].Substring(4, 2);
									�ו��f�[�^�o��(fs, sCSVData, false);
									//�o�ד���
									if(sPrintData[10].Substring(6, 1) == "0")
										sCSVData = " " + sPrintData[10].Substring(7, 1);
									else
										sCSVData = sPrintData[10].Substring(6, 2);
									�ו��f�[�^�o��(fs, sCSVData, false);
								}
								//�����ԍ�
								sCSVData = sPrintData[11].Substring(4,3) + "-" + sPrintData[11].Substring(7,4) + "-" + sPrintData[11].Substring(11,4);
								�ו��f�[�^�o��(fs, sCSVData, false);
								//�o�[�R�[�h
								sCSVData = "A" + s�ו��ԍ� + "A";
								�ו��f�[�^�o��(fs, sCSVData, false);
								//���X�b�c
								if(sPrintData[13].Length == 0)
									sCSVData = "";
								else
									sCSVData = sPrintData[13].Substring(1, 1) + "-" + sPrintData[13].Substring(2,2);
								�ו��f�[�^�o��(fs, sCSVData, false);
								//���X�b�c
								if(sPrintData[14].Substring(1, 3) == "047")
								{
									�ו��f�[�^�o��(fs, "", false);
								}
								else
								{
									�ו��f�[�^�o��(fs, sPrintData[14].Substring(1, 3), false);
								}
								//�ב��l�d�b�ԍ�
								sCSVData = "(" + sPrintData[15] + ")" + sPrintData[16] + "-" + sPrintData[17];
								�ו��f�[�^�o��(fs, sCSVData, false);

								�ו��f�[�^�o��(fs, �Z���ҏW(sPrintData[18]), false);	//�ב��l�Z���P
								�ו��f�[�^�o��(fs, sPrintData[19], false);				//�ב��l�Z���Q
								�ו��f�[�^�o��(fs, sPrintData[18], false);				//�ב��l�Z���R
								�ו��f�[�^�o��(fs, sPrintData[21], false);				//�ב��l���O�P
								�ו��f�[�^�o��(fs, sPrintData[22], false);				//�ב��l���O�Q
								�ו��f�[�^�o��(fs, sPrintData[34], false);				//�S����

								�ו��f�[�^�o��(fs, int.Parse(sPrintData[23]), false);	//��
								�ו��f�[�^�o��(fs, i�A��, false);						//�A��
								�ו��f�[�^�o��(fs, int.Parse(sPrintData[24]), false);	//�d��

								//�ی���
								int iCSVData = int.Parse(sPrintData[25]) * 10;
								if(iCSVData > 0 && iCSVData < 50) iCSVData = 50;
								�ו��f�[�^�o��(fs, iCSVData, false);

								//�w���
								string s�w�茎;
								string s�w���;
								if (sPrintData[26] != null && !sPrintData[26].Equals("") && !sPrintData[26].Equals("0"))
								{
									if(sPrintData[26].Substring(4, 1) == "0")
										s�w�茎 = " " + sPrintData[26].Substring(5, 1);
									else
										s�w�茎 = sPrintData[26].Substring(4, 2);

									if(sPrintData[26].Substring(6, 1) == "0")
										s�w��� = " " + sPrintData[26].Substring(7, 1);
									else
										s�w��� = sPrintData[26].Substring(6, 2);

									sCSVData     = s�w�茎 + "��" + s�w��� + "��";
									if (sPrintData[36].Equals("0"))
										sCSVData += "�K��";
									else if (sPrintData[36].Equals("1"))
										sCSVData += "�w��";
									�ו��f�[�^�o��(fs, sCSVData, false);
								}
								else
								{
									�ו��f�[�^�o��(fs, "", false);
								}

								//���q�l�ԍ�
								if(sPrintData[35].Length == 0)
									�ו��f�[�^�o��(fs, "", false);
								else
									�ו��f�[�^�o��(fs, "���q�l�ԍ�:" + sPrintData[35], false);

								�ו��f�[�^�o��(fs, sPrintData[27], false);		//�A���L���P
								�ו��f�[�^�o��(fs, sPrintData[28], false);		//�A���L���Q
								�ו��f�[�^�o��(fs, sPrintData[29], false);		//�i���L���P
								�ו��f�[�^�o��(fs, sPrintData[30], false);		//�i���L���Q
								�ו��f�[�^�o��(fs, sPrintData[31], false);		//�i���L���R
								if(iCnt == 0)
								{
									�ו��f�[�^�o��(fs, sPrintData[27], false);	//���x���R�A���L���P
									�ו��f�[�^�o��(fs, sPrintData[28], false);	//���x���R�A���L���Q
									�ו��f�[�^�o��(fs, sPrintData[29], false);	//���x���R�i���L���P
									�ו��f�[�^�o��(fs, sPrintData[30], false);	//���x���R�i���L���Q
									�ו��f�[�^�o��(fs, sPrintData[31], false);	//���x���R�i���L���R
									�ו��f�[�^�o��(fs, "", true);				//���x���R���\�L
								}
								else
								{
									�ו��f�[�^�o��(fs, "", false);				//���x���R�A���L���P
									�ו��f�[�^�o��(fs, "", false);				//���x���R�A���L���Q
									�ו��f�[�^�o��(fs, "", false);				//���x���R�i���L���P
									�ו��f�[�^�o��(fs, "", false);				//���x���R�i���L���Q
									�ו��f�[�^�o��(fs, "", false);				//���x���R�i���L���R
									�ו��f�[�^�o��(fs, "�׎D" + s�A��.PadLeft(3,' ') + "��", true);
									//���x���R���\�L
								}
							}
						}
						catch(Exception ex)
						{
							throw new Exception(ex.Message);
						}
						fs.Close();
					}
					catch(Exception ex)
					{
						throw new Exception(ex.Message);
					}
					return;
				}

				// ��(sPrintData[23])�͎g�p�����A�P��݈̂������
//				int iLabel�I�� = int.Parse(sPrintData[23]);
				int iLabel�I�� = 1;
				if(iLabel�I�� > i�I��)
				{
					iLabel�I�� = i�I��;
				}

				for (int iPage = i�J�n; iPage <= iLabel�I��; iPage++)
				{
					�����f�[�^.table�����Row tr = (�����f�[�^.table�����Row)ds�����.table�����.NewRow();
						
					tr.BeginEdit();
					tr.����� = i�����++;

					if(!gs�I�v�V����[19].Equals("1") && sPrintData[12].Length >= 7)
					{
						tr.�׎�l�X�֔ԍ� = "��";
						tr.�׎�l�X�֔ԍ� += sPrintData[12].Substring(0,3);
						tr.�׎�l�X�֔ԍ� += "-";
						tr.�׎�l�X�֔ԍ� += sPrintData[12].Substring(3,4);
					}
					else
					{
						tr.�׎�l�X�֔ԍ� = "";
					}
					tr.�׎�l�b�c     = sPrintData[1];
					if(gs�I�v�V����[0].Length == 4)
					{
						if(!gs�I�v�V����[12].Equals("1"))
						{
							tr.�׎�l�b�c     = " ";
						}
					}
					tr.�׎�l�d�b�ԍ� = "(" + sPrintData[2] + ")" + sPrintData[3] + "-" + sPrintData[4];
					if(sPrintData[2].Replace("0","").Trim().Length == 0
						&& sPrintData[3].Replace("0","").Trim().Length == 0
						&& sPrintData[4].Replace("0","").Trim().Length == 0)
					{
						tr.�׎�l�d�b�ԍ� = " ";
					}
					tr.�׎�l�Z����   = "";
					tr.�׎�l�Z���s   = "";
					tr.�׎�l�Z����   = "";
					tr.�׎�l�Z���P   = sPrintData[5];
					tr.�׎�l�Z���Q   = sPrintData[6];
					tr.�׎�l�Z���R   = sPrintData[7];
					tr.�׎�l���O�P   = sPrintData[8];
					tr.�׎�l���O�Q   = sPrintData[9];
					if (sPrintData[5].Equals("�����x�X�~�߁���"))
					{
						// �x�X�~�߂ł���Ƃ��A�׎�l�Z�����ڂɈȉ��̐ݒ���s�Ȃ�
						// �@�E�׎�l�Z�����F�u�����x�X�~�߁����v�i���[���ڂ̕\������Ɏg�p�A��\�����ځj
						// �@�E�׎�l�Z���P�F�u���R�ʉ^�^���q�^���v����
						// �@�E�׎�l�Z���Q�F�u�����x�X�^�c�Ə��~�߁v
						// �@�E�׎�l�Z���R�F�����󎚂��Ȃ�
						tr.�׎�l�Z���� = sPrintData[5];
						if(sPrintData[6].Substring(0, 2) == "���q")
						{
							tr.�׎�l�Z���P = "���q�^��";
						}
						else
						{
							tr.�׎�l�Z���P = "���R�ʉ^";
						}
						tr.�׎�l�Z���R = "";
					}

					tr.�o�ד��N       = sPrintData[10];
					if(sPrintData[10].Substring(4, 1) == "0")
						tr.�o�ד���       = " " + sPrintData[10].Substring(5, 1);
					else
						tr.�o�ד���       = sPrintData[10].Substring(4, 2);
					if(sPrintData[10].Substring(6, 1) == "0")
						tr.�o�ד���       = " " + sPrintData[10].Substring(7, 1);
					else
						tr.�o�ד���       = sPrintData[10].Substring(6, 2);

					tr.�����ԍ�     = sPrintData[11].Substring(4,3) + "-" + sPrintData[11].Substring(7,4) + "-" + sPrintData[11].Substring(11,4);
					tr.�o�[�R�[�h     = "A" + sPrintData[11].Substring(4) + "A";

					if(sPrintData[13].Length == 0)
						tr.���X�b�c       = "";
					else
						tr.���X�b�c       = sPrintData[13].Substring(1);
					if(sPrintData[13].Equals("0000"))
					{
						tr.���X�b�c       = "";
					}

					//�d���b�c���ݒ肳��Ă���ꍇ�A�d���b�c�A���X������
					if(sPrintData[37].Length > 0)
					{
						tr.�d���b�c       = sPrintData[37];
					}
					else
					{
						tr.�d���b�c       = "";
					}
					tr.���X�b�c       = sPrintData[14].Substring(1, 3);
					if(sPrintData[14].Substring(1, 3) == "047")
					{
						tr.�o�ד��N       = "";
						tr.�o�ד���       = "";
						tr.�o�ד���       = "";
						tr.���X��         = "";
						tr.���X�b�c       = "";
					}

					if(!gs�I�v�V����[19].Equals("1")
						&& sPrintData.Length > 40 && sPrintData[40].Length >= 7)
					{
						tr.�ב��l�X�֔ԍ� = "��";
						tr.�ב��l�X�֔ԍ� += sPrintData[40].Substring(0,3);
						tr.�ב��l�X�֔ԍ� += "-";
						tr.�ב��l�X�֔ԍ� += sPrintData[40].Substring(3,4);
					}
					else
					{
						tr.�ב��l�X�֔ԍ� = "";
					}
					tr.�ב��l�d�b�ԍ� = "(" + sPrintData[15] + ")" + sPrintData[16] + "-" + sPrintData[17];
					tr.�ב��l�Z���P   = �Z���ҏW(sPrintData[18]);
					tr.�ב��l�Z���Q   = sPrintData[19];
					tr.�ב��l�Z���R   = sPrintData[18];
					tr.�ב��l���O�P   = sPrintData[21];
					tr.�ב��l���O�Q   = sPrintData[22];
					tr.�S����         = sPrintData[34];
					tr.��           = sPrintData[23];

					// �A�Ԃ͂O�Œ�Ƃ���B
//					tr.�A��           = iPage.ToString();
					tr.�A��           = "0";

					tr.�d��           = sPrintData[24];
					int i�ی��� = int.Parse(sPrintData[25]) * 10;
					if(i�ی��� > 0 && i�ی��� < 50)
					{
						tr.�ی���     = "50";
					}
					else
					{
						string s�ی��� = i�ی���.ToString();
						if(s�ی���.Length == 4)
							s�ی��� = s�ی���.Insert(1,",");
						else
						{
							if(s�ی���.Length == 5)
								s�ی��� = s�ی���.Insert(2,",");
						}
						tr.�ی���     = s�ی���;
					}
					string s�w�茎;
					string s�w���;
					if (sPrintData[26] != null && !sPrintData[26].Equals("") && !sPrintData[26].Equals("0"))
					{
						if(sPrintData[26].Substring(4, 1) == "0")
							s�w�茎 = " " + sPrintData[26].Substring(5, 1);
						else
							s�w�茎 = sPrintData[26].Substring(4, 2);

						if(sPrintData[26].Substring(6, 1) == "0")
							s�w��� = " " + sPrintData[26].Substring(7, 1);
						else
							s�w��� = sPrintData[26].Substring(6, 2);
						tr.�w���     = s�w�茎 + "��" + s�w��� + "��";
						if (sPrintData[36].Equals("0"))
							tr.�w��� += "�K��";
						else if (sPrintData[36].Equals("1"))
							tr.�w��� += "�w��";
					}
					else
						tr.�w���     = "";
					if(sPrintData[35].Length != 0)
						tr.���q�l�ԍ�     = "���q�l�ԍ�:" + sPrintData[35];
					else
						tr.���q�l�ԍ�     = sPrintData[35];
					tr.�A���L���P     = sPrintData[27];
					tr.�A���L���Q     = sPrintData[28];
					tr.�i���L���P     = sPrintData[29];
					tr.�i���L���Q     = sPrintData[30];
					tr.�i���L���R     = sPrintData[31];
					if(sPrintData.Length > 42)
					{
						tr.�i���L���S = sPrintData[42];
						tr.�i���L���T = sPrintData[43];
						tr.�i���L���U = sPrintData[44];
					}
					else
					{
						tr.�i���L���S = "";
						tr.�i���L���T = "";
						tr.�i���L���U = "";
					}
					if(tr.�i���L���S.Length > 0
						|| tr.�i���L���T.Length > 0
						|| tr.�i���L���U.Length > 0
						)
					{
						// �S�p�X�����A���͔��p�P�W����
						tr.�i���L���P = �o�C�g���J�b�g(tr.�i���L���P, 18);
						tr.�i���L���Q = �o�C�g���J�b�g(tr.�i���L���Q, 18);
						tr.�i���L���R = �o�C�g���J�b�g(tr.�i���L���R, 18);
						tr.�i���L���S = �o�C�g���J�b�g(tr.�i���L���S, 18);
						tr.�i���L���T = �o�C�g���J�b�g(tr.�i���L���T, 18);
						tr.�i���L���U = �o�C�g���J�b�g(tr.�i���L���U, 18);
					}

					if(!gs�I�v�V����[15].Equals("1"))
					{
						tr.�׎�l�t�H���g�T�C�Y�g��FLG     = "0";
					}
					else
					{
						tr.�׎�l�t�H���g�T�C�Y�g��FLG     = "1";
					}

					if(gs����b�c.Substring(0,1) != "J")
					{
						tr.���q�^��FLG = "0";
					}
					else
					{
						tr.���q�^��FLG = "1";
					}

					string s�d�ʓ��͐��� = (sPrintData.Length > 41) ? sPrintData[41] : "0";
					tr.�d�ʓ��͐��� = s�d�ʓ��͐���;
					if(tr.���X�b�c == "" || tr.���X�b�c == "000")
					{
						tr.���X��     = ""; // ���X�b�c�����ݒ莞(�O���[�o����)
					}
					else if(gs�I�v�V����[21].Equals("1"))
					{
						tr.���X��     = "";
					}
					else
					{
						if(sPrintData[38] == "")
						{
							tr.���X��     = tr.���X�b�c;
						}
						else
						{
							tr.���X��     = sPrintData[38];
						}
					}
					string s���X�� = (sPrintData.Length > 45) ? sPrintData[45] : "";
					if(tr.���X�b�c == "" || tr.���X�b�c == "000")
					{
						tr.���X��     = ""; // ���X�b�c�����ݒ莞
					}
					else
					{
						if(s���X�� == "")
						{
							tr.���X��     = tr.���X�b�c;
						}
						else
						{
							tr.���X��     = s���X��;
						}
					}
					// �����x���̃o�b�N�̍��h��[���X��]�ɐݒ肵�Ă����
					//   ���X�����\������Ȃ����A�o�b�N�̐F�������܂�

// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� START
					//�Г��`�[�ł���΁A�l���Z�b�g����
					if(gs����X���b�c.Equals("044"))
					{
						// �Г��`�[�ł���Ƃ��A�׎�l�Z�����ڂɈȉ��̐ݒ���s�Ȃ�
						// �@�E�׎�l�Z�����@�@�@�@�@�F�u�����Г��`�[�����v
						//�@�@�@�i���[���ڂ̕\������Ɏg�p�A��\�����ځj
						// �@�E���X�b�c�i��j�@�@�@�@�F�󎚂��Ȃ�
						// �@�E���X�b�c�i���j�@�@�@�@�F�󎚂���
						// �@�E�w�Г���p�x�e�L�X�g�F�󎚂���
						tr.�׎�l�Z���� = "�����Г��`�[����";
					}
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� END

					tr.EndEdit();

					ds�����.table�����.Rows.Add(tr);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		protected void �׎D�T�����[���()
		{
			// �����I�K�x�[�W�R���N�^
			System.GC.Collect();
			if(gs�v�����^��� == "S0004")
			{
				�����f�[�^�N���A();
				return;
			}

			// �v���r���[�\��
			�����T���`�S���[ crA4 = new �����T���`�S���[();

			DataView dv = ds�����.table�����.DefaultView;
			dv.Sort = "����� ASC";
			DataTable dt2 = ds�����.table�����.Clone();
			foreach (DataRowView drv in dv) 
			{
				dt2.Rows.Add(drv.Row.ItemArray);
			}
			dt2.AcceptChanges();
			crA4.SetDataSource(dt2);

			�v���r���[��� ��� = new �v���r���[���();
			���.crv���[.PrintReport();
			���.crv���[.ReportSource = crA4;
			���.ShowDialog();

			// �����I�̈�J��
			crA4 = null;
			dv  = null;
			dt2 = null;

			// �����I�K�x�[�W�R���N�^
			System.GC.Collect();

			�����f�[�^�N���A();
		}
// ADD 2015.11.02 BEVAS�j���{ �o�׃��x���C���[�W�����ʒǉ� END
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� START
		protected string[] �b�l�O�T������X�e�`�F�b�N()
		{
			string[] sRet = new string[2];
			try
			{
				string[] sList = new string[2];
				if(sv_syukka == null)
				{
					sv_syukka = new is2syukka.Service1();
				}
				sList = sv_syukka.CheckCM22_HouseSlip(gsa���[�U, gs����b�c);

				if(sList[0] == "����I��")
				{
					//����I����
					sRet[0] = "0"; //���Ȃ�
					sRet[1] = "";
				}
				else
				{
					//�ُ�I����
					sRet[0] = "1"; //��肠��
					sRet[1] = sList[0].Trim();
				}
			}
			catch(System.Net.WebException)
			{
				sRet[0] = "1"; //��肠��
				sRet[1] = gs�ʐM�G���[;
			}
			catch(Exception ex)
			{
				sRet[0] = "1"; //��肠��
				sRet[1] = "�ʐM�G���[�F" + ex.Message;
			}
			return sRet;
		}
// MOD 2016.04.15 BEVAS�j���{ �Г��`�[�@�\�ǉ��Ή� END
	}
}
