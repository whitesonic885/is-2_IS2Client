using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace IS2Client
{
	/// <summary>
	/// [�p�X���[�h�ύX]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// ADD 2008.06.30 ���s�j���� �p�X���[�h�`�F�b�N�̋��� 
	//--------------------------------------------------------------------------
	public class �p�X���[�h�ύX : ���ʃt�H�[��
	{
// ADD 2008.06.30 ���s�j���� �p�X���[�h�`�F�b�N�̋��� START
		public string s���[�h = "";
		public string s����   = "";
// ADD 2008.06.30 ���s�j���� �p�X���[�h�`�F�b�N�̋��� END

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn�X�V;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Label lab�V�p�X���[�h;
		private System.Windows.Forms.Label lab�p�X���[�h�ύX�^�C�g��;
		private ���ʃe�L�X�g�{�b�N�X tex�p�X���[�h;
		private System.Windows.Forms.Label lab�ē���;
		private ���ʃe�L�X�g�{�b�N�X tex�ē���;
		private System.Windows.Forms.GroupBox groupBox1;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		public �p�X���[�h�ύX()
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
			this.tex�p�X���[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lab�ē��� = new System.Windows.Forms.Label();
			this.tex�ē��� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.label1 = new System.Windows.Forms.Label();
			this.lab�V�p�X���[�h = new System.Windows.Forms.Label();
			this.btn�X�V = new System.Windows.Forms.Button();
			this.btn���� = new System.Windows.Forms.Button();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab�p�X���[�h�ύX�^�C�g�� = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1.SuspendLayout();
			this.panel7.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tex�p�X���[�h
			// 
			this.tex�p�X���[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex�p�X���[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�p�X���[�h.Location = new System.Drawing.Point(152, 22);
			this.tex�p�X���[�h.MaxLength = 40;
			this.tex�p�X���[�h.Name = "tex�p�X���[�h";
			this.tex�p�X���[�h.PasswordChar = '*';
			this.tex�p�X���[�h.Size = new System.Drawing.Size(170, 23);
			this.tex�p�X���[�h.TabIndex = 1;
			this.tex�p�X���[�h.Text = "";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Honeydew;
			this.panel1.Controls.Add(this.lab�ē���);
			this.panel1.Controls.Add(this.tex�ē���);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.lab�V�p�X���[�h);
			this.panel1.Controls.Add(this.tex�p�X���[�h);
			this.panel1.Controls.Add(this.btn�X�V);
			this.panel1.Controls.Add(this.btn����);
			this.panel1.Location = new System.Drawing.Point(1, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(361, 142);
			this.panel1.TabIndex = 0;
			// 
			// lab�ē���
			// 
			this.lab�ē���.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�ē���.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�ē���.Location = new System.Drawing.Point(46, 54);
			this.lab�ē���.Name = "lab�ē���";
			this.lab�ē���.Size = new System.Drawing.Size(102, 14);
			this.lab�ē���.TabIndex = 50;
			this.lab�ē���.Text = "�V�p�X���[�h�ē���";
			// 
			// tex�ē���
			// 
			this.tex�ē���.BackColor = System.Drawing.SystemColors.Window;
			this.tex�ē���.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�ē���.Location = new System.Drawing.Point(152, 50);
			this.tex�ē���.MaxLength = 40;
			this.tex�ē���.Name = "tex�ē���";
			this.tex�ē���.PasswordChar = '*';
			this.tex�ē���.Size = new System.Drawing.Size(170, 23);
			this.tex�ē���.TabIndex = 2;
			this.tex�ē���.Text = "";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 144);
			this.label1.TabIndex = 44;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab�V�p�X���[�h
			// 
			this.lab�V�p�X���[�h.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�V�p�X���[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�V�p�X���[�h.Location = new System.Drawing.Point(46, 26);
			this.lab�V�p�X���[�h.Name = "lab�V�p�X���[�h";
			this.lab�V�p�X���[�h.Size = new System.Drawing.Size(102, 14);
			this.lab�V�p�X���[�h.TabIndex = 42;
			this.lab�V�p�X���[�h.Text = "�V�p�X���[�h";
			// 
			// btn�X�V
			// 
			this.btn�X�V.BackColor = System.Drawing.Color.PaleGreen;
			this.btn�X�V.ForeColor = System.Drawing.Color.Blue;
			this.btn�X�V.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�X�V.Location = new System.Drawing.Point(260, 86);
			this.btn�X�V.Name = "btn�X�V";
			this.btn�X�V.Size = new System.Drawing.Size(54, 48);
			this.btn�X�V.TabIndex = 4;
			this.btn�X�V.Text = "�ۑ�";
			this.btn�X�V.Click += new System.EventHandler(this.btn�X�V_Click);
			// 
			// btn����
			// 
			this.btn����.BackColor = System.Drawing.Color.PaleGreen;
			this.btn����.ForeColor = System.Drawing.Color.Red;
			this.btn����.Location = new System.Drawing.Point(66, 86);
			this.btn����.Name = "btn����";
			this.btn����.Size = new System.Drawing.Size(54, 48);
			this.btn����.TabIndex = 3;
			this.btn����.TabStop = false;
			this.btn����.Text = "����";
			this.btn����.Click += new System.EventHandler(this.btn����_Click);
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.lab�p�X���[�h�ύX�^�C�g��);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(364, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab�p�X���[�h�ύX�^�C�g��
			// 
			this.lab�p�X���[�h�ύX�^�C�g��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�p�X���[�h�ύX�^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�p�X���[�h�ύX�^�C�g��.ForeColor = System.Drawing.Color.White;
			this.lab�p�X���[�h�ύX�^�C�g��.Location = new System.Drawing.Point(12, 2);
			this.lab�p�X���[�h�ύX�^�C�g��.Name = "lab�p�X���[�h�ύX�^�C�g��";
			this.lab�p�X���[�h�ύX�^�C�g��.Size = new System.Drawing.Size(264, 24);
			this.lab�p�X���[�h�ύX�^�C�g��.TabIndex = 0;
			this.lab�p�X���[�h�ύX�^�C�g��.Text = "�p�X���[�h�ύX";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Location = new System.Drawing.Point(0, 22);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(364, 150);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			// 
			// �p�X���[�h�ύX
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(363, 171);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.groupBox1);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(369, 203);
			this.Name = "�p�X���[�h�ύX";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 �p�X���[�h�ύX";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
			this.Load += new System.EventHandler(this.�p�X���[�h�ύX_Load);
			this.Closed += new System.EventHandler(this.�p�X���[�h�ύX_Closed);
			this.panel1.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		private void btn����_Click(object sender, System.EventArgs e)
		{
// ADD 2008.06.30 ���s�j���� �p�X���[�h�`�F�b�N�̋��� START
			s���� = "";
// ADD 2008.06.30 ���s�j���� �p�X���[�h�`�F�b�N�̋��� END
			this.Close();
		}

		private void btn�X�V_Click(object sender, System.EventArgs e)
		{
			// �󔒏���
			tex�p�X���[�h.Text = tex�p�X���[�h.Text.Trim();
			tex�ē���.Text     = tex�ē���.Text.Trim();
			// ���ڃ`�F�b�N
			if(!�K�{�`�F�b�N(tex�p�X���[�h,"�p�X���[�h")) return;
			if(!�K�{�`�F�b�N(tex�ē���,"�ē���")) return;
			if(!���p�`�F�b�N(tex�p�X���[�h,"�p�X���[�h")) return;
			if(!���p�`�F�b�N(tex�ē���,"�ē���")) return;
			// �p�X���[�h�`�F�b�N
			if(tex�p�X���[�h.Text != tex�ē���.Text)
			{
				MessageBox.Show("�p�X���[�h�ƍē��͂̓��e���قȂ��Ă��܂��B\n�ēx���͂��Ă��������B",
								"�G���[",MessageBoxButtons.OK);
				tex�p�X���[�h.Focus();
				return;
			}

			// ���p�҃}�X�^�̍X�V
			String[] sKey = new string[5];
			sKey[0] = gs����b�c;
			sKey[1] = gs���p�҂b�c;
			sKey[2] = tex�p�X���[�h.Text;
			sKey[3] = "�p�X�ύX";
			sKey[4] = gs���p�҂b�c;

			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string sRet = "";
			try
			{
				if(sv_init == null) sv_init = new is2init.Service1();
				sRet = sv_init.Upd_riyou(gsa���[�U,sKey);
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

			if(sRet.Length == 4)
			{
// ADD 2008.06.30 ���s�j���� �p�X���[�h�`�F�b�N�̋��� START
				s���� = "�X�V";
// ADD 2008.06.30 ���s�j���� �p�X���[�h�`�F�b�N�̋��� END
// MOD 2009.05.28 ���s�j���� �p�X���[�h�ύX���̏����ݒ�t�@�C���ւ̏����@�\�ǉ� START
				// �����ݒ�t�@�C���̃p�X���[�h������
				string[] s�����ݒ� = new string[]{"","","","",""};
				int iPos = 0;

				StreamReader sr = File.OpenText(gsInitFile);
				for(iPos = 0; iPos < s�����ݒ�.Length; iPos++){
					s�����ݒ�[iPos] = sr.ReadLine();
					if(s�����ݒ�[iPos] == null){
						s�����ݒ�[iPos] = "";
						break;
					}
				}
				sr.Close();

				if(s�����ݒ�[0].Length > 0){
					if(gbInitFileExt){
						s�����ݒ�[1] = �Í���(tex�p�X���[�h.Text);
					}else{
						s�����ݒ�[1] = tex�p�X���[�h.Text;
					}
					StreamWriter sw = File.CreateText(gsInitFile);
					for(iPos = 0; iPos < s�����ݒ�.Length; iPos++){
						sw.WriteLine(s�����ݒ�[iPos]);
					}
					sw.Close();
				}
// MOD 2009.05.28 ���s�j���� �p�X���[�h�ύX���̏����ݒ�t�@�C���ւ̏����@�\�ǉ� END
				this.Close();
			}
			else
			{
				MessageBox.Show(sRet,"�G���[",MessageBoxButtons.OK);
			}
		}

// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� START
		private void �p�X���[�h�ύX_Closed(object sender, System.EventArgs e)
		{
			tex�p�X���[�h.Text = "";
			tex�ē���.Text     = "";
			tex�p�X���[�h.Focus();
// ADD 2008.06.30 ���s�j���� �p�X���[�h�`�F�b�N�̋��� START
			s���[�h = "";
// ADD 2008.06.30 ���s�j���� �p�X���[�h�`�F�b�N�̋��� END
		}
// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� END

// ADD 2008.06.30 ���s�j���� �p�X���[�h�`�F�b�N�̋��� START
		private void �p�X���[�h�ύX_Load(object sender, System.EventArgs e)
		{
			if(s���[�h.Equals("�����؂�") || s���[�h.Equals("�p�X�ύX")){
				this.btn����.Text = "��ݾ�";
			}
		}
// ADD 2008.06.30 ���s�j���� �p�X���[�h�`�F�b�N�̋��� END
// MOD 2009.05.28 ���s�j���� �p�X���[�h�ύX���̏����ݒ�t�@�C���ւ̏����@�\�ǉ� START
		private byte[] bKey = {51, 168, 96, 2, 36, 12, 74, 143, 11, 85, 61, 233, 202, 170, 114, 59};
		private byte[] bIv  = {100, 223, 207, 80, 29, 100, 53, 152};
		private string �Í���(string sText)
		{
            byte[] bText;
            byte[] bRet;
			string sRet = "";

			try{
				MemoryStream msEncrypt = new MemoryStream();
				RC2CryptoServiceProvider rc2 = new RC2CryptoServiceProvider();

				// CryptoStream�I�u�W�F�N�g���쐬����
				ICryptoTransform transform = rc2.CreateEncryptor(bKey,bIv); // Encryptor���쐬����
				CryptoStream cryptoStream = new CryptoStream( msEncrypt, transform, CryptoStreamMode.Write);

				// �Í�������Ώۂ��o�C�g�z��Ƃ��ēǂݍ���
				bText = Encoding.GetEncoding("shift-jis").GetBytes(sText);
				
				// CryptoStream�ɂ���ĈÍ������ď�������
				cryptoStream.Write( bText, 0, bText.Length );
				cryptoStream.FlushFinalBlock();

				bRet = msEncrypt.ToArray();
				//sRet = Encoding.GetEncoding("shift-jis").GetString(bRet);
				for(int iCnt = 0; iCnt < bRet.Length; iCnt++){
					sRet += bRet[iCnt].ToString("X2");
				}

				// CryptoStream�����
				cryptoStream.Close();

				// FileStream�����
				msEncrypt.Close();

				rc2          = null;
				cryptoStream = null;
				msEncrypt    = null;
			}catch(Exception ex){
				sRet = ex.Message;
			}

			return sRet;
		}
// MOD 2009.05.28 ���s�j���� �p�X���[�h�ύX���̏����ݒ�t�@�C���ւ̏����@�\�ǉ� END
	}
}
