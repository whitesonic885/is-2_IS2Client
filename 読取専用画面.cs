using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [�ǎ��p���]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// MOD 2015.07.13 TDI�j�j�V ��ʒǉ� 
	//--------------------------------------------------------------------------

	public class �ǎ��p��� : ���ʃt�H�[��
	{
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.TextBox tex���b�Z�[�W;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Label lab�ǎ��p��ʃ^�C�g��;
		private System.Windows.Forms.TextBox tex�����ԍ�����;
		private System.Windows.Forms.Label lab�����ԍ�;
		private System.Windows.Forms.Button btn�Ɖ�;
		private System.ComponentModel.IContainer components = null;

		private string[] s�o�׈ꗗ;

		public �ǎ��p���()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			�c�o�h�\���T�C�Y�ϊ�();
			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
//				this.list�v�����^.Size = new System.Drawing.Size(258, 34);
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� START
//				this.list�v�����^.Size = new System.Drawing.Size(258, (int)(34 * 1.5));
//				this.list�v�����^.Size = new System.Drawing.Size(258, (int)(50 * 1.5));
// MOD 2013.10.22 BEVAS�j���� �s�d�b���v�����^(B-EV4)�Ή� END
			}
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
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab�ǎ��p��ʃ^�C�g�� = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.tex���b�Z�[�W = new System.Windows.Forms.TextBox();
			this.btn���� = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.tex�����ԍ����� = new System.Windows.Forms.TextBox();
			this.lab�����ԍ� = new System.Windows.Forms.Label();
			this.btn�Ɖ� = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).BeginInit();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.SuspendLayout();
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
			this.panel7.Controls.Add(this.lab�ǎ��p��ʃ^�C�g��);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(792, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab�ǎ��p��ʃ^�C�g��
			// 
			this.lab�ǎ��p��ʃ^�C�g��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�ǎ��p��ʃ^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�ǎ��p��ʃ^�C�g��.ForeColor = System.Drawing.Color.White;
			this.lab�ǎ��p��ʃ^�C�g��.Location = new System.Drawing.Point(12, 2);
			this.lab�ǎ��p��ʃ^�C�g��.Name = "lab�ǎ��p��ʃ^�C�g��";
			this.lab�ǎ��p��ʃ^�C�g��.Size = new System.Drawing.Size(264, 24);
			this.lab�ǎ��p��ʃ^�C�g��.TabIndex = 0;
			this.lab�ǎ��p��ʃ^�C�g��.Text = "�ǎ��p���";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.tex���b�Z�[�W);
			this.panel8.Controls.Add(this.btn����);
			this.panel8.Location = new System.Drawing.Point(0, 286);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 2;
			// 
			// tex���b�Z�[�W
			// 
			this.tex���b�Z�[�W.BackColor = System.Drawing.Color.PaleGreen;
			this.tex���b�Z�[�W.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���b�Z�[�W.ForeColor = System.Drawing.Color.Red;
			this.tex���b�Z�[�W.Location = new System.Drawing.Point(190, 4);
			this.tex���b�Z�[�W.Multiline = true;
			this.tex���b�Z�[�W.Name = "tex���b�Z�[�W";
			this.tex���b�Z�[�W.ReadOnly = true;
			this.tex���b�Z�[�W.Size = new System.Drawing.Size(196, 50);
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
			this.btn����.TabIndex = 3;
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
			// tex�����ԍ�����
			// 
			this.tex�����ԍ�����.Font = new System.Drawing.Font("�l�r �S�V�b�N", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�����ԍ�����.Location = new System.Drawing.Point(8, 96);
			this.tex�����ԍ�����.Name = "tex�����ԍ�����";
			this.tex�����ԍ�����.Size = new System.Drawing.Size(280, 31);
			this.tex�����ԍ�����.TabIndex = 1;
			this.tex�����ԍ�����.Text = "";
			this.tex�����ԍ�����.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex�����ԍ�����_KeyDown);
			this.tex�����ԍ�����.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex�����ԍ�����_KeyPress);
			// 
			// lab�����ԍ�
			// 
			this.lab�����ԍ�.Font = new System.Drawing.Font("�l�r �S�V�b�N", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�����ԍ�.Location = new System.Drawing.Point(8, 64);
			this.lab�����ԍ�.Name = "lab�����ԍ�";
			this.lab�����ԍ�.TabIndex = 15;
			this.lab�����ԍ�.Text = "�����";
			// 
			// btn�Ɖ�
			// 
			this.btn�Ɖ�.BackColor = System.Drawing.Color.DarkGray;
			this.btn�Ɖ�.Location = new System.Drawing.Point(296, 96);
			this.btn�Ɖ�.Name = "btn�Ɖ�";
			this.btn�Ɖ�.Size = new System.Drawing.Size(48, 24);
			this.btn�Ɖ�.TabIndex = 2;
			this.btn�Ɖ�.Text = "�Ɖ�";
			this.btn�Ɖ�.Click += new System.EventHandler(this.btn�Ɖ�_Click);
			// 
			// �ǎ��p���
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(388, 349);
			this.Controls.Add(this.btn�Ɖ�);
			this.Controls.Add(this.lab�����ԍ�);
			this.Controls.Add(this.tex�����ԍ�����);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(394, 374);
			this.Name = "�ǎ��p���";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 �ǎ��p���";
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX START
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.On�G���^�[�ړ�);
            //this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.On�G���^�[�L�����Z��);
// MOD 2016.09.28 Vivouac) �e�r Visual Studio 2013�`���ɕύX END
            this.Load += new System.EventHandler(this.�ǎ��p���_Load);
			this.Closed += new System.EventHandler(this.�ǎ��p���_Closed);
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).EndInit();
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
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

		private void �����ݒ�()
		{

		}

		private void �ǎ��p���_Load(object sender, System.EventArgs e)
		{
			//�����ԍ����͂փt�H�[�J�X
			this.tex�����ԍ�����.Text = "";
			tex�����ԍ�����.Focus();
		}

		private void �ǎ��p���_Closed(object sender, System.EventArgs e)
		{
			this.tex�����ԍ�����.Text = "";
			tex�����ԍ�����.Focus();
		}

		private void btn�Ɖ�_Click(object sender, System.EventArgs e)
		{

			try
			{

				//�o�דo�^��ʎQ��
				if (g�o�דo�^ == null)	 g�o�דo�^ = new �o�דo�^();
				g�o�דo�^.Left = this.Left;
				g�o�דo�^.Top = this.Top;

				//���[�ԍ��̃`�F�b�N
				string s�����ԍ�		= tex�����ԍ�����.Text.Trim();
				string s�����ԍ�11	= "";

				//���p���̓`�F�b�N
				if (!���p�`�F�b�N(s�����ԍ�)) return;

				//�n�C�t���u��
				s�����ԍ� = s�����ԍ�.Replace("-","");

				switch (s�����ԍ�.Length)
				{
					case 11:
						//�����ԍ��̂݃p�^�[��
						s�����ԍ�11 = s�����ԍ�;
						break;
					case 13:
						//�����ԍ��{�A�ԃp�^�[��
						s�����ԍ�11 = s�����ԍ�.Substring(0,11);
						break;
					case 15:
						//�`�`�t�����ԍ��{�A�ԃp�^�[��
						s�����ԍ�11 = s�����ԍ�.Substring(1,11);
						break;
					default:
						//����̃t�H�[�}�b�g�ł͂Ȃ�
						MessageBox.Show("�����ԍ��F" + s�����ԍ� + "\r\n"
										+"���̓t�H�[�}�b�g�Ɍ�肪����܂��B\r\n�P�P���܂��͂P�R���œ��͂��ĉ������B\r\n","�m�F",MessageBoxButtons.OK );
						tex�����ԍ�����.Focus();
						tex�����ԍ�����.SelectAll();
						return;
				}

				//���l�`�F�b�N
				if (!���l�`�F�b�N(s�����ԍ�11))
				{
					//�����񂪊܂܂��
					MessageBox.Show("�����ԍ��F" + s�����ԍ�11 + "\r\n"
									+"���͒l�ɐ��l�ȊO���܂܂�Ă��܂��B\r\n","�m�F",MessageBoxButtons.OK );
					tex�����ԍ�����.Focus();
					tex�����ԍ�����.SelectAll();
					return;
				}

				//�`�F�b�N�f�W�b�g�`�F�b�N
				if (!�`�F�b�N�f�W�b�g�`�F�b�N(s�����ԍ�11))
				{
					//�`�F�b�N�f�W�b�g���s��
					MessageBox.Show("�����ԍ��F" + s�����ԍ�11 + "\r\n"
									+"�`�F�b�N�f�W�b�g���s���ł��B\r\n","�m�F",MessageBoxButtons.OK );
					tex�����ԍ�����.Focus();
					tex�����ԍ�����.SelectAll();
					return;			
				}

				//�����ԍ��̑��݃`�F�b�N�i���\�b�h�쐬)
				s�o�׈ꗗ = new string[1];
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
				string[] sa�������� = new string[]{
												  gs����b�c
												  , gs����b�c
												  , ""
												  , ""
												  , "0"
												  , "0"
												  , "0"
												  , "00"
												  , s�����ԍ�11
												  , s�����ԍ�11
												  , ""
												  , ""
												  , "1"
											  };
				s�o�׈ꗗ = sv_syukka.Get_syukka2(gsa���[�U, sa��������);
				if (s�o�׈ꗗ[0] != "����I��")
				{
					//�Y���f�[�^�Ȃ�
					MessageBox.Show("�����ԍ��F" + s�����ԍ�11 + "\r\n"
									+"�o�׃f�[�^�����݂��܂���B\r\n�X�L�������Ɍ�肪����A�܂��͍폜�ςł��B\r\n","�m�F",MessageBoxButtons.OK );
					tex�����ԍ�����.Focus();
					tex�����ԍ�����.SelectAll();
					return;
				}

				//�T�[�o�擾���ʂ�z��ɕ�������
				string[] sa�o�׃f�[�^ = s�o�׈ꗗ[4].Split('|');

				//�o�דo�^�i�C����ʁj�̃f�[�^��������
				if (g�o�דo�^ == null)	 g�o�דo�^ = new �o�דo�^();
				g�o�דo�^.Left = this.Left;
				g�o�דo�^.Top = this.Top;
			
				g�o�דo�^.s�o�^�� = sa�o�׃f�[�^[17].Trim();		
				g�o�דo�^.s�W���[�i���m�n = sa�o�׃f�[�^[16].Trim();
				g�o�דo�^.s�o�^�҂b�c = sa�o�׃f�[�^[19].Trim();

				//�o�דo�^�i�C����ʁj�̌Ăяo��
				if(g�o�דo�^.s�W���[�i���m�n.Length > 0)
				{
					g�o�דo�^.s�����e�f = "U";
					this.Visible = false;
					g�o�דo�^.ShowDialog();
					this.Visible = true;
					this.tex�����ԍ�����.Text = "";
					this.tex�����ԍ�����.Focus();
					//btn�Ɖ�_Click(sender, e);
					if(tex���b�Z�[�W.Text.Trim().Length == 4)
						tex���b�Z�[�W.Text = "";
				}
				else
				{
					MessageBox.Show("�����ԍ��F" + s�����ԍ�11 + "\r\n"
									+"�o�׃f�[�^�����݂��܂���B\r\n�X�L�������Ɍ�肪����A�܂��͍폜�ςł��B\r\n","�m�F",MessageBoxButtons.OK );
					tex�����ԍ�����.Focus();
					tex�����ԍ�����.SelectAll();
					return;
				}
			}
			catch (System.Net.WebException)
			{
				tex���b�Z�[�W.Text = gs�ʐM�G���[;
				�r�[�v��();
			}
			catch (Exception ex)
			{
				tex���b�Z�[�W.Text = "�ʐM�G���[�F" + ex.Message;
				�r�[�v��();
			}
		}

		private void tex�����ԍ�����_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				btn�Ɖ�_Click(sender, e);
			}
		}

		private void tex�����ԍ�����_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn�Ɖ�_Click(sender, e);
			}		
		}
		
		private new bool ���l�`�F�b�N(string �����ԍ�)
		{
			//.NET1.1�p"TryParse"�쐬
			try
			{
				long.Parse(�����ԍ�);
			}
			catch (StackOverflowException)
			{
				throw;
			}
			catch (OutOfMemoryException)
			{
				throw;
			}
			catch (System.Threading.ThreadAbortException)
			{
				throw;
			}
			catch
			{
				return false;
			}

			return true;
		}

		private bool �`�F�b�N�f�W�b�g�`�F�b�N(string �����ԍ�)
		{
			long �`�F�b�N���b�c = long.Parse(�����ԍ�.Substring(10,1));
			long �`�F�b�N��b�c = long.Parse(�����ԍ�.Substring(0,10)) % 7;
			
			if (�`�F�b�N���b�c != �`�F�b�N��b�c) return false; 

			return true;
		}


	}
}
