using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace IS2Client
{
	/// <summary>
	/// [���O�C��]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// MOD 2008.03.13 ���s�j���� Vista�Ή� 
	// ADD 2008.03.13 ���s�j���� �Í��E�����@�\�̒ǉ� 
	// ADD 2008.06.17 ���s�j���� �l�`�b�A�h���X�`�F�b�N�̒ǉ� 
	// ADD 2008.06.30 ���s�j���� �p�X���[�h�`�F�b�N�̋��� 
	// MOD 2008.07.09 ���s�j���� �l�`�b�A�h���X�擾�̋��� 
	// MOD 2008.07.16 ���s�j���� �l�`�b�A�h���X�̊ȈՃ}�X�L���O 
	//�ۗ� MOD 2008.10.23 ���s�j���� �l�`�b�A�h���X�̖��擾���̐ݒ�ύX 
	//--------------------------------------------------------------------------
	// ADD 2009.02.16 ���s�j���� [wis2.dll]�t�@�C���̃N���A 
	// ADD 2009.07.29 ���s�j���� �v���L�V�Ή� 
	// �@�h�d��[Secure]�̐ݒ肩����擾����
	// �@�v���L�V�����[�U���ݒ�ł���悤�ɂ���
	// MOD 2009.07.30 ���s�j���� exe��dll���Ή� 
	// MOD 2009.10.16 ���s�j���� �v���L�V�@�\�\�L�̒ǉ� 
	//--------------------------------------------------------------------------
	// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� 
	// MOD 2010.04.16 ���s�j���� ���W���[���ă_�E�����[�h 
	//--------------------------------------------------------------------------
	// MOD 2011.04.05 ���s�j���� ��ʃC���[�W�̃��[�h�ύX 
	// MOD 2011.10.11 ���s�j���� �r�r�k�ؖ���������ԂȂǂ̃`�F�b�N 
	//--------------------------------------------------------------------------
	public class ���O�C�� : ���ʃt�H�[��
	{
		private int i���O�C���g���C�� = 0;
		private string s�[�� = "";

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btn���O�C��;
		private System.Windows.Forms.Label lab���p�҂b�c;
		private ���ʃe�L�X�g�{�b�N�X tex���p�҂b�c;
		private System.Windows.Forms.Label lab�p�X���[�h;
		private ���ʃe�L�X�g�{�b�N�X tex�p�X���[�h;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox pic���O�I��;
		private System.Windows.Forms.CheckBox cBox�ێ�;
		private System.Windows.Forms.Label lab�o�[�W����;

		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ���O�C��()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(���O�C��));
			this.tex���p�҂b�c = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lab�o�[�W���� = new System.Windows.Forms.Label();
			this.cBox�ێ� = new System.Windows.Forms.CheckBox();
			this.pic���O�I�� = new System.Windows.Forms.PictureBox();
			this.btn���� = new System.Windows.Forms.Button();
			this.lab�p�X���[�h = new System.Windows.Forms.Label();
			this.tex�p�X���[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab���p�҂b�c = new System.Windows.Forms.Label();
			this.btn���O�C�� = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tex���p�҂b�c
			// 
			this.tex���p�҂b�c.BackColor = System.Drawing.SystemColors.Window;
			this.tex���p�҂b�c.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���p�҂b�c.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex���p�҂b�c.Location = new System.Drawing.Point(134, 72);
			this.tex���p�҂b�c.MaxLength = 6;
			this.tex���p�҂b�c.Name = "tex���p�҂b�c";
			this.tex���p�҂b�c.Size = new System.Drawing.Size(170, 23);
			this.tex���p�҂b�c.TabIndex = 0;
			this.tex���p�҂b�c.Text = "";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.panel1.Controls.Add(this.lab�o�[�W����);
			this.panel1.Controls.Add(this.cBox�ێ�);
			this.panel1.Controls.Add(this.pic���O�I��);
			this.panel1.Controls.Add(this.btn����);
			this.panel1.Controls.Add(this.lab�p�X���[�h);
			this.panel1.Controls.Add(this.tex�p�X���[�h);
			this.panel1.Controls.Add(this.lab���p�҂b�c);
			this.panel1.Controls.Add(this.tex���p�҂b�c);
			this.panel1.Controls.Add(this.btn���O�C��);
			this.panel1.Location = new System.Drawing.Point(-2, -14);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(370, 197);
			this.panel1.TabIndex = 0;
			// 
			// lab�o�[�W����
			// 
			this.lab�o�[�W����.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(191)), ((System.Byte)(190)));
			this.lab�o�[�W����.ForeColor = System.Drawing.Color.Black;
			this.lab�o�[�W����.Location = new System.Drawing.Point(304, 22);
			this.lab�o�[�W����.Name = "lab�o�[�W����";
			this.lab�o�[�W����.Size = new System.Drawing.Size(60, 12);
			this.lab�o�[�W����.TabIndex = 53;
			this.lab�o�[�W����.Text = "Ver.1.9";
			// 
			// cBox�ێ�
			// 
			this.cBox�ێ�.Location = new System.Drawing.Point(134, 128);
			this.cBox�ێ�.Name = "cBox�ێ�";
			this.cBox�ێ�.Size = new System.Drawing.Size(128, 18);
			this.cBox�ێ�.TabIndex = 52;
			this.cBox�ێ�.TabStop = false;
			this.cBox�ێ�.Text = "�p�X���[�h��ێ�����";
			// 
			// pic���O�I��
			// 
			this.pic���O�I��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(191)), ((System.Byte)(190)));
			this.pic���O�I��.Image = ((System.Drawing.Image)(resources.GetObject("pic���O�I��.Image")));
			this.pic���O�I��.Location = new System.Drawing.Point(2, 2);
			this.pic���O�I��.Name = "pic���O�I��";
			this.pic���O�I��.Size = new System.Drawing.Size(366, 66);
			this.pic���O�I��.TabIndex = 51;
			this.pic���O�I��.TabStop = false;
			// 
			// btn����
			// 
			this.btn����.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btn����.ForeColor = System.Drawing.Color.Black;
			this.btn����.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn����.Location = new System.Drawing.Point(208, 154);
			this.btn����.Name = "btn����";
			this.btn����.Size = new System.Drawing.Size(100, 20);
			this.btn����.TabIndex = 3;
			this.btn����.TabStop = false;
			this.btn����.Text = "�L�����Z��";
			this.btn����.Click += new System.EventHandler(this.btn����_Click);
			// 
			// lab�p�X���[�h
			// 
			this.lab�p�X���[�h.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�p�X���[�h.ForeColor = System.Drawing.Color.Black;
			this.lab�p�X���[�h.Location = new System.Drawing.Point(58, 102);
			this.lab�p�X���[�h.Name = "lab�p�X���[�h";
			this.lab�p�X���[�h.Size = new System.Drawing.Size(74, 14);
			this.lab�p�X���[�h.TabIndex = 50;
			this.lab�p�X���[�h.Text = "�p�X���[�h�F";
			// 
			// tex�p�X���[�h
			// 
			this.tex�p�X���[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex�p�X���[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�p�X���[�h.Location = new System.Drawing.Point(134, 98);
			this.tex�p�X���[�h.MaxLength = 40;
			this.tex�p�X���[�h.Name = "tex�p�X���[�h";
			this.tex�p�X���[�h.PasswordChar = '*';
			this.tex�p�X���[�h.Size = new System.Drawing.Size(170, 23);
			this.tex�p�X���[�h.TabIndex = 1;
			this.tex�p�X���[�h.Text = "";
			this.tex�p�X���[�h.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�p�X���[�h_KeyDown);
			// 
			// lab���p�҂b�c
			// 
			this.lab���p�҂b�c.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���p�҂b�c.ForeColor = System.Drawing.Color.Black;
			this.lab���p�҂b�c.Location = new System.Drawing.Point(58, 76);
			this.lab���p�҂b�c.Name = "lab���p�҂b�c";
			this.lab���p�҂b�c.Size = new System.Drawing.Size(72, 14);
			this.lab���p�҂b�c.TabIndex = 42;
			this.lab���p�҂b�c.Text = "���[�U�[�F";
			// 
			// btn���O�C��
			// 
			this.btn���O�C��.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btn���O�C��.ForeColor = System.Drawing.Color.Black;
			this.btn���O�C��.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn���O�C��.Location = new System.Drawing.Point(60, 154);
			this.btn���O�C��.Name = "btn���O�C��";
			this.btn���O�C��.Size = new System.Drawing.Size(100, 20);
			this.btn���O�C��.TabIndex = 2;
			this.btn���O�C��.Text = "�n�j";
			this.btn���O�C��.Click += new System.EventHandler(this.btn���O�C��_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Location = new System.Drawing.Point(0, -5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(374, 208);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			// 
			// ���O�C��
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(365, 175);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox1);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(373, 202);
			this.Name = "���O�C��";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "is-2 ���O�C��";
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX START
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.On�G���^�[�ړ�);
            //this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.On�G���^�[�L�����Z��);
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX END
            this.Load += new System.EventHandler(this.���O�C��_Load);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
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
		private void btn����_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

// ADD 2008.03.13 ���s�j���� �Í��E�����@�\�̒ǉ� START
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

		private string ������(string sText)
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
			}catch(Exception ex){
				sRet = ex.Message;
			}

			return sRet;
		}
// ADD 2008.03.13 ���s�j���� �Í��E�����@�\�̒ǉ� END
		private void btn���O�C��_Click(object sender, System.EventArgs e)
		{
			// �󔒏���
			tex���p�҂b�c.Text = tex���p�҂b�c.Text.Trim();
			tex�p�X���[�h.Text = tex�p�X���[�h.Text.Trim();
// ADD 2009.02.16 ���s�j���� [wis2.dll]�t�@�C���̃N���A START
			if(tex�p�X���[�h.Text.Length == 0){
				if(tex���p�҂b�c.Text.ToLower().Equals("i"))
				{
					// �����ݒ�t�@�C���̃N���A
					StreamWriter sw = File.CreateText(gsInitFile);
					sw.WriteLine("");
					sw.WriteLine("");
					sw.WriteLine("");
					sw.Close();

					�����o�^ F�����o�^ = new �����o�^();
					F�����o�^.ShowDialog();
					StreamReader sr = File.OpenText(gsInitFile);
					gs�[���b�c = sr.ReadLine();
					gs�[���b�c = sr.ReadLine();
					gs�[���b�c = sr.ReadLine();
					sr.Close();
					gsa���[�U[2] = gs�[���b�c;

					this.Close();
					return;
				}
// ADD 2009.07.29 ���s�j���� �v���L�V�Ή� START
				if(tex���p�҂b�c.Text.ToLower().Equals("p"))
				{
					// �v���L�V�����ݒ�t�@�C���̃N���A
					StreamWriter swp = File.CreateText(gsInitProxy);
					swp.WriteLine("");
					swp.WriteLine("");
					swp.WriteLine("");
					swp.Close();

					gs�[���b�c   = "";
					gsa���[�U[2] = gs�[���b�c;

					this.Close();
					return;
				}
				if(tex���p�҂b�c.Text.ToLower().Equals("pd"))
				{
					try{
						// �v���L�V�����ݒ�t�@�C���̍폜
						System.IO.File.Delete(gsInitProxy);
					}catch(Exception){}

					gs�[���b�c   = "";
					gsa���[�U[2] = gs�[���b�c;

					this.Close();
					return;
				}
// ADD 2009.07.29 ���s�j���� �v���L�V�Ή� END
// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� START
				if(tex���p�҂b�c.Text.ToLower().Equals("s"))
				{
					// �v���L�V�����ݒ�t�@�C���̃N���A
					StreamWriter swp = File.CreateText(gsInitSyukka);
					swp.WriteLine("3");		//3��
					swp.WriteLine("");
					swp.WriteLine("");
					swp.Close();

					gs�[���b�c   = "";
					gsa���[�U[2] = gs�[���b�c;

					this.Close();
					return;
				}
				if(tex���p�҂b�c.Text.ToLower().Equals("sd"))
				{
					try{
						// �v���L�V�����ݒ�t�@�C���̍폜
						System.IO.File.Delete(gsInitSyukka);
					}catch(Exception){}

					gs�[���b�c   = "";
					gsa���[�U[2] = gs�[���b�c;

					this.Close();
					return;
				}
// MOD 2010.04.07 ���s�j���� �o�ׂb�r�u�����o�� END
// MOD 2010.04.16 ���s�j���� ���W���[���ă_�E�����[�h START
				if(tex���p�҂b�c.Text.ToLower().Equals("is2"))
				{
					try{
						// �v���L�V�����ݒ�t�@�C���̍폜
						System.IO.File.Delete(gsFlagIS2Client);
					}catch(Exception){}

					gs�[���b�c   = "";
					gsa���[�U[2] = gs�[���b�c;

					this.Close();
					return;
				}
// MOD 2010.04.16 ���s�j���� ���W���[���ă_�E�����[�h END
			}
// ADD 2009.02.16 ���s�j���� [wis2.dll]�t�@�C���̃N���A END
			// ���ڃ`�F�b�N
			if(!�K�{�`�F�b�N(tex���p�҂b�c,"���[�U�[")) return;
			if(!�K�{�`�F�b�N(tex�p�X���[�h,"�p�X���[�h")) return;
			if(!�p�X���[�h�`�F�b�N(tex���p�҂b�c,"���[�U�[")) return;
			if(!�p�X���[�h�`�F�b�N(tex�p�X���[�h,"�p�X���[�h")) return;

			// ���p�҃}�X�^�̌���
			String[] sKey = new string[]{
//				gs����b�c,
				gs�[���b�c,
				tex���p�҂b�c.Text,
				tex�p�X���[�h.Text
// ADD 2008.06.17 ���s�j���� �l�`�b�A�h���X�`�F�b�N�̒ǉ� START
				, ""			// [ 3]�R���s���[�^��
				, ""			// [ 4]�h�o�A�h���X
				, ""			// [ 5]�l�`�b�A�h���X
// ADD 2008.06.17 ���s�j���� �l�`�b�A�h���X�`�F�b�N�̒ǉ� END
// MOD 2011.10.11 ���s�j���� �r�r�k�ؖ���������ԂȂǂ̃`�F�b�N START
				, gbInitProxyExists ? "p" : " "  
								// [ 6]�v���L�V
				, gbInitSyukkaExists ? "s" : " "
								// [ 7]�����o��
				, gsOSVer		// [ 8]�n�r�o�[�W����
				, gsNetVer		// [ 9]�m�d�s�o�[�W����
				, gsSSLStatus	// [10]�r�r�k�e�X�g����
// MOD 2011.10.11 ���s�j���� �r�r�k�ؖ���������ԂȂǂ̃`�F�b�N END
			};

// ADD 2008.06.17 ���s�j���� �l�`�b�A�h���X�`�F�b�N�̒ǉ� START
			// �R���s���[�^��
			try
			{
				sKey[3] = System.Environment.MachineName;
				// �h�o�A�h���X
				try
				{
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX START
					//System.Net.IPHostEntry iph = System.Net.Dns.GetHostByName(sKey[3]);
                    System.Net.IPHostEntry iph = System.Net.Dns.GetHostEntry(sKey[3]);
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX END

// MOD 2008.07.09 ���s�j���� �l�`�b�A�h���X�擾�̋��� START
//					sKey[4] = iph.AddressList[0].ToString();
					sKey[4] = "";
					sKey[5] = "";
					for(uint uiCnt = 0; uiCnt < iph.AddressList.Length; uiCnt++){
//�ۗ� MOD 2008.10.23 ���s�j���� �l�`�b�A�h���X�̖��擾���̐ݒ�ύX START
//						sKey[4] = "";
//						sKey[5] = "";
//�ۗ� MOD 2008.10.23 ���s�j���� �l�`�b�A�h���X�̖��擾���̐ݒ�ύX END
						sKey[4] = iph.AddressList[uiCnt].ToString();
						// �l�`�b�A�h���X�̎擾
						sKey[5] = GetMacAddress(sKey[4]);
//�ۗ� MOD 2008.10.23 ���s�j���� �l�`�b�A�h���X�̖��擾���̐ݒ�ύX START
						if(sKey[4].Trim().Length > 0 && sKey[5].Trim().Length > 0) break;
//						if(sKey[4].Trim().Length > 0 && sKey[5].Trim().Length > 1) break;
//�ۗ� MOD 2008.10.23 ���s�j���� �l�`�b�A�h���X�̖��擾���̐ݒ�ύX END
					}
// MOD 2008.07.09 ���s�j���� �l�`�b�A�h���X�擾�̋��� END
				}
				catch(Exception)
				{
					sKey[4] = "";
// ADD 2008.07.09 ���s�j���� �l�`�b�A�h���X�擾�̋��� START
					sKey[5] = "";
// ADD 2008.07.09 ���s�j���� �l�`�b�A�h���X�擾�̋��� END
				}
// DEL 2008.07.09 ���s�j���� �l�`�b�A�h���X�擾�̋��� START
//				// �l�`�b�A�h���X�̎擾
//				sKey[5] = GetMacAddress(sKey[4]);
// DEL 2008.07.09 ���s�j���� �l�`�b�A�h���X�擾�̋��� END
			}
			catch(Exception)
			{
				sKey[3] = "";
				sKey[4] = "";
				sKey[5] = "";
			}
// ADD 2008.06.17 ���s�j���� �l�`�b�A�h���X�`�F�b�N�̒ǉ� END

// ADD 2005.05.09 ���s�j���� �f���Ή� START
			if(tex���p�҂b�c.Text == "demo")
			{
				sKey[0] = "demo";
			}
// ADD 2005.05.09 ���s�j���� �f���Ή� END

			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sRet = {""};
			try
			{
				if(sv_init == null) sv_init = new is2init.Service1();
				//				sRet = sv_init.login(gsa���[�U,sKey);
				sRet = sv_init.login2(gsa���[�U,sKey);
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
			i���O�C���g���C��++;

			if(sRet[0].Length == 4)
			{
				gs���p�҂b�c = sRet[3];
				gs���p�Җ�   = sRet[4];
//				gs���b�Z�[�W += sRet[5];
// MOD 2005.05.17 ���s�j���� �N�����Ԃ�Z������ START
				gs����b�c   = sRet[1];
				gs�����     = sRet[2];
				gs�v�����^�e�f = sRet[6];
				gs�v�����^��� = sRet[7];
// MOD 2005.05.17 ���s�j���� �N�����Ԃ�Z������ END
// ADD 2005.06.07 ���s�j���� �s���{���I���̕ύX START
				if(sRet[8].Length > 0)
					gi�s���{���b�c = int.Parse(sRet[8]);
// ADD 2005.06.07 ���s�j���� �s���{���I���̕ύX END
// ADD 2005.05.09 ���s�j���� �f���Ή� START
				if(gs���p�҂b�c == "demo")
				{
//					gs����b�c = "demo";
					gs�[���b�c = "demo";
				}
// ADD 2005.05.09 ���s�j���� �f���Ή� END
// ADD 2005.05.27 ���s�j�����J �p�X���[�h�̕ێ� START
				StreamWriter sw = File.CreateText(gsInitFile);
				if(cBox�ێ�.Checked == true)
				{
					sw.WriteLine(tex���p�҂b�c.Text);
// MOD 2008.03.13 ���s�j���� Vista�Ή� START
//					sw.WriteLine(tex�p�X���[�h.Text);
					if(gbInitFileExt){
						sw.WriteLine(�Í���(tex�p�X���[�h.Text));
					}else{
						sw.WriteLine(tex�p�X���[�h.Text);
					}
// MOD 2008.03.13 ���s�j���� Vista�Ή� END
					sw.WriteLine(s�[��);
				}
				else
				{
					sw.WriteLine("");
					sw.WriteLine("");
					sw.WriteLine(s�[��);
				}
				sw.Close();

// ADD 2005.05.27 ���s�j�����J �p�X���[�h�̕ێ� END
// ADD 2008.06.30 ���s�j���� �p�X���[�h�`�F�b�N�̋��� START
				if(sRet[0].Equals("����I��")){
					;
				}else if(sRet[0].Equals("�����؂�")){
					MessageBox.Show("�p�X���[�h�̗L���������؂�܂����B\n"
									+ "�p�X���[�h�̕ύX�����肢�v���܂��B"
									, "���O�C��", 
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
					�p�X���[�h�ύX �p�X�ύX = new �p�X���[�h�ύX();
					�p�X�ύX.s���[�h = sRet[0];
					�p�X�ύX.Left = this.Left;
					�p�X�ύX.Top  = this.Top;
					this.Visible = false;
					�p�X�ύX.ShowDialog(this);
					this.Visible = true;
					if(!�p�X�ύX.s����.Equals("�X�V")){
						gs���p�҂b�c = "";
						gs���p�Җ�   = "";
					}
					�p�X�ύX = null;
				}else{
					MessageBox.Show("�p�X���[�h�̗L�������� "
									+ sRet[0].Substring(0,2) + "/"
									+ sRet[0].Substring(2)
									+ " �܂łł��B\n"
									+ "�p�X���[�h�̕ύX�����肢�v���܂��B"
									, "���O�C��", 
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
					�p�X���[�h�ύX �p�X�ύX = new �p�X���[�h�ύX();
					�p�X�ύX.s���[�h = "�p�X�ύX";
					�p�X�ύX.Left = this.Left;
					�p�X�ύX.Top  = this.Top;
					this.Visible = false;
					�p�X�ύX.ShowDialog(this);
					this.Visible = true;
					�p�X�ύX = null;
				}
// ADD 2008.06.30 ���s�j���� �p�X���[�h�`�F�b�N�̋��� END
				this.Close();
			}
// ADD 2005.07.01 ���s�j���� �[����񂪍폜����Ă����ꍇ�̑Ή� START
			else if(sRet[0].Length == 5)
			{
				MessageBox.Show("�[����񂪑��݂��܂���B�����o�^�����肢�v���܂��B", "���O�C��", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);

// ADD 2005.07.05 ���s�j���� �[����񂪍폜����Ă����ꍇ�̑Ή� START
				// �����ݒ�t�@�C���̃N���A
				StreamWriter sw = File.CreateText(gsInitFile);
				sw.WriteLine("");
				sw.WriteLine("");
				sw.WriteLine("");
				sw.Close();

				�����o�^ F�����o�^ = new �����o�^();
				F�����o�^.ShowDialog();
				StreamReader sr = File.OpenText(gsInitFile);
				gs�[���b�c = sr.ReadLine();
				gs�[���b�c = sr.ReadLine();
				gs�[���b�c = sr.ReadLine();
				sr.Close();

				gsa���[�U[2] = gs�[���b�c;
// ADD 2005.07.05 ���s�j���� �[����񂪍폜����Ă����ꍇ�̑Ή� END

				this.Close();
			}
// ADD 2005.07.01 ���s�j���� �[����񂪍폜����Ă����ꍇ�̑Ή� END
			else
			{
				MessageBox.Show(sRet[0], "���O�C��", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				if(i���O�C���g���C�� >= 10) this.Close();
				tex�p�X���[�h.Focus();
			}
		}

		private void tex�p�X���[�h_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btn���O�C��_Click(sender, e);
			}
		}

		private void ���O�C��_Load(object sender, System.EventArgs e)
		{
// MOD 2005.05.17 ���s�j���� �N�����Ԃ�Z������ START
//			pic���O�I��.Image = Image.FromFile("img\\login.gif");
// MOD 2011.04.05 ���s�j���� ��ʃC���[�W�̃��[�h�ύX START
//			try{
//				pic���O�I��.Image = Image.FromFile("img\\login.gif");
//			}catch{
//			}
			pic���O�I��.Image = Image_FromFile("img\\login.gif");
// MOD 2011.04.05 ���s�j���� ��ʃC���[�W�̃��[�h�ύX END
// MOD 2005.05.17 ���s�j���� �N�����Ԃ�Z������ END
// ADD 2007.10.26 ���s�j���� �o�[�W�������̕\�� START
			if(gsa���[�U[3].Length == 0)
			{
				int iPos = 0;
				//�P�ڂ̃s���I�h
				iPos = Application.ProductVersion.IndexOf('.');
				if(iPos >= 0)
				{
					//�Q�ڂ̃s���I�h
					iPos = Application.ProductVersion.IndexOf('.',iPos+1);
					if(iPos >= 0)
					{
						gsa���[�U[3] = Application.ProductVersion.Substring(0,iPos);
					}
				}
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� START
				if(System.IO.File.Exists("IS2Client.dll")){
					System.Diagnostics.FileVersionInfo myFileVersionInfo 
						= System.Diagnostics.FileVersionInfo.GetVersionInfo("IS2Client.dll");
					iPos = 0;
					//�P�ڂ̃s���I�h
					iPos = myFileVersionInfo.FileVersion.IndexOf('.');
					if(iPos >= 0)
					{
						//�Q�ڂ̃s���I�h
						iPos = myFileVersionInfo.FileVersion.IndexOf('.',iPos+1);
						if(iPos >= 0)
						{
							gsa���[�U[3] = myFileVersionInfo.FileVersion.Substring(0,iPos);
						}
					}
				}
// MOD 2009.07.30 ���s�j���� exe��dll���Ή� END
			}
			if(gsa���[�U[3].Length > 0) lab�o�[�W����.Text = "Ver." + gsa���[�U[3];
// MOD 2009.10.16 ���s�j���� �v���L�V�@�\�\�L�̒ǉ� START
			if(gbInitProxyExists) lab�o�[�W����.Text += " p";
// MOD 2009.10.16 ���s�j���� �v���L�V�@�\�\�L�̒ǉ� END
// ADD 2007.10.26 ���s�j���� �o�[�W�������̕\�� END
// ADD 2005.05.27 ���s�j�����J �p�X���[�h�̕ێ� START
			StreamReader sr = File.OpenText(gsInitFile);
			tex���p�҂b�c.Text = sr.ReadLine();
// MOD 2008.03.13 ���s�j���� Vista�Ή� START
//			tex�p�X���[�h.Text = sr.ReadLine();
			if(gbInitFileExt){
				tex�p�X���[�h.Text = ������(sr.ReadLine());
			}else{
				tex�p�X���[�h.Text = sr.ReadLine();
			}
// MOD 2008.03.13 ���s�j���� Vista�Ή� END
			s�[�� = sr.ReadLine();
			sr.Close();
			if(tex���p�҂b�c.Text.Trim().Length != 0)
				cBox�ێ�.Checked = true;
// ADD 2005.05.27 ���s�j�����J �p�X���[�h�̕ێ� END
		}

// ADD 2008.06.17 ���s�j���� �l�`�b�A�h���X�`�F�b�N�̒ǉ� START
		[System.Runtime.InteropServices.DllImport("IPHLPAPI.dll")] 
		private static extern uint GetAdaptersInfo(byte[] by1, out uint ui2);

		private const uint ERROR_SUCCESS = 0;
		private const uint ERROR_BUFFER_OVERFLOW = 111;
		private const uint IP_ADAPTER_INFO_LENGTH = 640;

		/*
		 * �l�`�b�A�h���X���擾����
		 */
		private string GetMacAddress(string sSelIP)
		{
			string sRet = "-";

			if(sSelIP.Length == 0) return sRet;

			try
			{
				// �K�v�ȃf�[�^�̈�T�C�Y�̎擾
				byte[] bBuff = null;
				uint uiLen = 0;
				uint uiRet = GetAdaptersInfo(bBuff, out uiLen);
				if(uiRet == ERROR_BUFFER_OVERFLOW)
				{
					// �C���^�[�t�F�[�X���̎擾
					bBuff = new byte[uiLen];
					uiRet = GetAdaptersInfo(bBuff, out uiLen);
					if(uiRet == ERROR_SUCCESS)	//	������
					{
						string sMac   = "";
						string sIP    = "";

						uint uiNext   = 0;
						uint uiMacLen = 0;
						char[] cBuff;

						uint uiBase = 0;
						uint uiPos = 0;
						while(uiBase < uiLen)
						{
							uiNext   = ByteToUint(bBuff, uiBase +   0);
//							Console.WriteLine(uiNext.ToString("X8"));
							uiMacLen = ByteToUint(bBuff, uiBase + 400);
							
							// �l�`�b�A�h���X���擾
							uiPos = uiBase + 404;
							sMac = "";
							for(uint uiCnt = 0; uiCnt < uiMacLen; uiCnt++)
							{
// MOD 2008.07.16 ���s�j���� �l�`�b�A�h���X�̊ȈՃ}�X�L���O START
//								if(uiCnt > 0) sMac += "-";
								switch(uiCnt)
								{
									case 0:
										sMac += "Z";
										break;
									case 1:
										sMac += "Y";
										break;
									case 2:
										sMac += "I";
										break;
									case 3:
										sMac += "S";
										break;
									case 4:
										sMac += "2";
										break;
								}
// MOD 2008.07.16 ���s�j���� �l�`�b�A�h���X�̊ȈՃ}�X�L���O END
								sMac += bBuff[uiPos++].ToString("X2");
							}
//							Console.WriteLine(sMac);

							// �h�o�A�h���X���擾
							uiPos = uiBase + 432;
							cBuff = new char[16];
							Array.Copy(bBuff, uiPos, cBuff, 0, 16);
							sIP = new string(cBuff);
							sIP = sIP.Substring(0, sIP.IndexOf('\0')).Trim();
							if(sIP == sSelIP)
								return sMac;
//							Console.WriteLine(sIP);

							if(uiNext == 0)
								break;

							uiBase += IP_ADAPTER_INFO_LENGTH;
						}

					}
				}
			}
			catch(Exception)
			{
				;
			}

			return sRet;
		}

		/*
		 * �o�C�g�z�񂩂�uint�^�Ƃ��ăf�[�^���擾����
		 */
		private uint ByteToUint(byte[] byData, uint uiPos)
		{
			// �����`�F�b�N
			if(byData.Length - uiPos < 4) return 0;

			unsafe
			{
				fixed (byte* pbyData = &byData[uiPos])
				{
					return *((uint*)pbyData);
				}
			}
		}
// ADD 2008.06.17 ���s�j���� �l�`�b�A�h���X�`�F�b�N�̒ǉ� END
// MOD 2011.04.05 ���s�j���� ��ʃC���[�W�̃��[�h�ύX START
		private Image Image_FromFile(string s�C���[�W�t�@�C��)
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
	}
}
