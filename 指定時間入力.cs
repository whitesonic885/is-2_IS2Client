using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// Form1 �̊T�v�̐����ł��B
	/// </summary>
	public class �w�莞�ԓ��� : ���ʃt�H�[��
	{
		public string s�L��;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn�X�V;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lab�w�莞��;
		public System.Windows.Forms.Label lab���ԋ敪;
		private System.Windows.Forms.Label lab�w�莞�ԓ��̓^�C�g��;
		public System.Windows.Forms.ComboBox cmb�w�莞��;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		public �w�莞�ԓ���()
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
			this.cmb�w�莞�� = new System.Windows.Forms.ComboBox();
			this.lab���ԋ敪 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lab�w�莞�� = new System.Windows.Forms.Label();
			this.btn�X�V = new System.Windows.Forms.Button();
			this.btn���� = new System.Windows.Forms.Button();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab�w�莞�ԓ��̓^�C�g�� = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1.SuspendLayout();
			this.panel7.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Honeydew;
			this.panel1.Controls.Add(this.cmb�w�莞��);
			this.panel1.Controls.Add(this.lab���ԋ敪);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.lab�w�莞��);
			this.panel1.Controls.Add(this.btn�X�V);
			this.panel1.Controls.Add(this.btn����);
			this.panel1.Location = new System.Drawing.Point(1, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(361, 142);
			this.panel1.TabIndex = 0;
			// 
			// cmb�w�莞��
			// 
			this.cmb�w�莞��.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb�w�莞��.Font = new System.Drawing.Font("MS UI Gothic", 12F);
			this.cmb�w�莞��.Location = new System.Drawing.Point(146, 26);
			this.cmb�w�莞��.Name = "cmb�w�莞��";
			this.cmb�w�莞��.Size = new System.Drawing.Size(52, 24);
			this.cmb�w�莞��.TabIndex = 1;
			// 
			// lab���ԋ敪
			// 
			this.lab���ԋ敪.Font = new System.Drawing.Font("MS UI Gothic", 12F);
			this.lab���ԋ敪.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���ԋ敪.Location = new System.Drawing.Point(204, 30);
			this.lab���ԋ敪.Name = "lab���ԋ敪";
			this.lab���ԋ敪.Size = new System.Drawing.Size(76, 18);
			this.lab���ԋ敪.TabIndex = 46;
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
			// lab�w�莞��
			// 
			this.lab�w�莞��.Font = new System.Drawing.Font("MS UI Gothic", 12F);
			this.lab�w�莞��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�w�莞��.Location = new System.Drawing.Point(66, 30);
			this.lab�w�莞��.Name = "lab�w�莞��";
			this.lab�w�莞��.Size = new System.Drawing.Size(76, 18);
			this.lab�w�莞��.TabIndex = 42;
			this.lab�w�莞��.Text = "�w�莞��";
			// 
			// btn�X�V
			// 
			this.btn�X�V.BackColor = System.Drawing.Color.PaleGreen;
			this.btn�X�V.ForeColor = System.Drawing.Color.Blue;
			this.btn�X�V.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�X�V.Location = new System.Drawing.Point(240, 70);
			this.btn�X�V.Name = "btn�X�V";
			this.btn�X�V.Size = new System.Drawing.Size(54, 48);
			this.btn�X�V.TabIndex = 2;
			this.btn�X�V.Text = "�m��";
			this.btn�X�V.Click += new System.EventHandler(this.btn�X�V_Click);
			// 
			// btn����
			// 
			this.btn����.BackColor = System.Drawing.Color.PaleGreen;
			this.btn����.ForeColor = System.Drawing.Color.Red;
			this.btn����.Location = new System.Drawing.Point(66, 70);
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
			this.panel7.Controls.Add(this.lab�w�莞�ԓ��̓^�C�g��);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(364, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab�w�莞�ԓ��̓^�C�g��
			// 
			this.lab�w�莞�ԓ��̓^�C�g��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�w�莞�ԓ��̓^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�w�莞�ԓ��̓^�C�g��.ForeColor = System.Drawing.Color.White;
			this.lab�w�莞�ԓ��̓^�C�g��.Location = new System.Drawing.Point(12, 2);
			this.lab�w�莞�ԓ��̓^�C�g��.Name = "lab�w�莞�ԓ��̓^�C�g��";
			this.lab�w�莞�ԓ��̓^�C�g��.Size = new System.Drawing.Size(264, 24);
			this.lab�w�莞�ԓ��̓^�C�g��.TabIndex = 0;
			this.lab�w�莞�ԓ��̓^�C�g��.Text = "�w�莞�ԓ���";
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
			// �w�莞�ԓ���
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
			this.Name = "�w�莞�ԓ���";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 �w�莞�ԓ���";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
			this.Load += new System.EventHandler(this.�w�莞�ԓ���_Load);
			this.Closed += new System.EventHandler(this.�w�莞�ԓ���_Closed);
			this.panel1.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		private void �w�莞�ԓ���_Load(object sender, System.EventArgs e)
		{
		
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			s�L�� = "";
			this.Close();
		}

		private void btn�X�V_Click(object sender, System.EventArgs e)
		{
// MOD 2005.06.10 ���s�j�ɉ�@���Ԏw����@�ύX START
//			s�L�� = "���Ԏw��" + Microsoft.VisualBasic.Strings.StrConv(nUD�w�莞��.Value.ToString(), Microsoft.VisualBasic.VbStrConv.Wide, 0) + lab���ԋ敪.Text;
			s�L�� = "���Ԏw��" + cmb�w�莞��.SelectedItem.ToString() + lab���ԋ敪.Text;
// MOD 2005.06.10 ���s�j�ɉ�@���Ԏw����@�ύX END
			this.Close();
		}

		private void �w�莞�ԓ���_Closed(object sender, System.EventArgs e)
		{
// MOD 2005.06.10 ���s�j�ɉ�@���Ԏw����@�ύX START
			//nUD�w�莞��.Focus();
			cmb�w�莞��.Focus();
// MOD 2005.06.10 ���s�j�ɉ�@���Ԏw����@�ύX END
		}
	}
}
