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
	/// [���O�C���Q]�i���͐�S���폜�p�j
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// MOD 2011.04.05 ���s�j���� ��ʃC���[�W�̃��[�h�ύX 
	//--------------------------------------------------------------------------
	public class ���O�C���Q : ���ʃt�H�[��
	{
		private int i���O�C���g���C�� = 0;

		public bool b�폜���O�C�� = false;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btn���O�C��;
		private System.Windows.Forms.Label lab���p�҂b�c;
		private ���ʃe�L�X�g�{�b�N�X tex���p�҂b�c;
		private System.Windows.Forms.Label lab�p�X���[�h;
		private ���ʃe�L�X�g�{�b�N�X tex�p�X���[�h;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox pic���O�I��;

		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ���O�C���Q()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(���O�C���Q));
			this.tex���p�҂b�c = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.panel1 = new System.Windows.Forms.Panel();
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
			this.tex���p�҂b�c.Location = new System.Drawing.Point(134, 84);
			this.tex���p�҂b�c.MaxLength = 6;
			this.tex���p�҂b�c.Name = "tex���p�҂b�c";
			this.tex���p�҂b�c.Size = new System.Drawing.Size(170, 23);
			this.tex���p�҂b�c.TabIndex = 0;
			this.tex���p�҂b�c.Text = "";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
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
			this.lab�p�X���[�h.Location = new System.Drawing.Point(58, 114);
			this.lab�p�X���[�h.Name = "lab�p�X���[�h";
			this.lab�p�X���[�h.Size = new System.Drawing.Size(74, 14);
			this.lab�p�X���[�h.TabIndex = 50;
			this.lab�p�X���[�h.Text = "�p�X���[�h�F";
			// 
			// tex�p�X���[�h
			// 
			this.tex�p�X���[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex�p�X���[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�p�X���[�h.Location = new System.Drawing.Point(134, 110);
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
			this.lab���p�҂b�c.Location = new System.Drawing.Point(58, 88);
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
			// ���O�C���Q
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(365, 168);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox1);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(373, 202);
			this.Name = "���O�C���Q";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "is-2 ���O�C��";
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX START
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.On�G���^�[�ړ�);
            //this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.On�G���^�[�L�����Z��);
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX END
            this.Load += new System.EventHandler(this.���O�C���Q_Load);
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
			tex���p�҂b�c.Focus();
			b�폜���O�C�� = false;
			this.Close();
		}

		private void btn���O�C��_Click(object sender, System.EventArgs e)
		{
			// �󔒏���
			tex���p�҂b�c.Text = tex���p�҂b�c.Text.Trim();
			tex�p�X���[�h.Text = tex�p�X���[�h.Text.Trim();
			// ���ڃ`�F�b�N
			if(!�K�{�`�F�b�N(tex���p�҂b�c,"���[�U�[")) return;
			if(!�K�{�`�F�b�N(tex�p�X���[�h,"�p�X���[�h")) return;
			if(!�p�X���[�h�`�F�b�N(tex���p�҂b�c,"���[�U�[")) return;
			if(!�p�X���[�h�`�F�b�N(tex�p�X���[�h,"�p�X���[�h")) return;

			// ���p�҃}�X�^�̌���
			String[] sKey = new string[]{
				gs����b�c,
				tex���p�҂b�c.Text,
				tex�p�X���[�h.Text,
				gs����b�c
			};

			if(tex���p�҂b�c.Text == "demo")
			{
				sKey[0] = "demo";
			}

			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sRet = {""};
			try
			{
				if(sv_init == null) sv_init = new is2init.Service1();
				sRet = sv_init.login3(gsa���[�U,sKey);
			}
			catch (System.Net.WebException)
			{
				sRet[0] = gs�ʐM�G���[;
			}
			catch (Exception ex)
			{
				sRet[0] = "�ʐM�G���[�F" + ex.Message;
			}
			// �J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;
			i���O�C���g���C��++;

			if(sRet[0].Length == 4)
			{
				tex���p�҂b�c.Focus();
				b�폜���O�C�� = true;
				this.Close();
			}
			else
			{
				MessageBox.Show(sRet[0], "���O�C��", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				if(i���O�C���g���C�� >= 10)
				{
					b�폜���O�C�� = false;
					this.Close();
				}
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

		private void ���O�C���Q_Load(object sender, System.EventArgs e)
		{
// MOD 2011.04.05 ���s�j���� ��ʃC���[�W�̃��[�h�ύX START
//			try{
//				pic���O�I��.Image = Image.FromFile("img\\login.gif");
//			}catch{
//			}
			pic���O�I��.Image = Image_FromFile("img\\login.gif");
// MOD 2011.04.05 ���s�j���� ��ʃC���[�W�̃��[�h�ύX END
			tex���p�҂b�c.Text = "";
			tex�p�X���[�h.Text = "";
			tex���p�҂b�c.Focus();
		}
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
