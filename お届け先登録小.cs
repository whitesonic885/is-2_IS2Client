using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [���͂���o�^��]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// MOD 2008.03.19 ���s�j���� ���͂���̏㏑�@�\�̒ǉ� 
	// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX 
	// ADD 2008.10.16 kcl)�X�{ ���X�R�[�h���݃`�F�b�N�ǉ� 
	// ADD 2008.10.17 ���s�j���� ���X�R�[�h�`�F�b�N�@�\�s���� 
	// MOD 2008.11.12 ���s�j���� �Z���b�c�̎����ݒ���s��Ȃ�
	//--------------------------------------------------------------------------
	// DEL 2009.02.02 ���s�j���� ���X�R�[�h�`�F�b�N�@�\����
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� 
	//--------------------------------------------------------------------------
	public class ���͂���o�^�� : ���ʃt�H�[��
	{
// MOD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX START
//// MOD 2008.03.19 ���s�j���� ���͂���̏㏑�@�\�̒ǉ� START
////		public string[] sTdata = new string[18];
//		public string[] sTdata = new string[20];
//// MOD 2008.03.19 ���s�j���� ���͂���̏㏑�@�\�̒ǉ� END
		public string[] sTdata = new string[21];
// MOD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX END
		private string sIUFlg;
		public string s�͂���b�c;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Label label1;
		private ���ʃe�L�X�g�{�b�N�X tex�J�i����;
		private ���ʃe�L�X�g�{�b�N�X tex���[��;
		private ���ʃe�L�X�g�{�b�N�X tex�͂���R�[�h;
		private System.Windows.Forms.Button btn�o�^;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Label lab���[��;
		private System.Windows.Forms.Label lab�J�i����;
		private System.Windows.Forms.Label lab�͂���R�[�h;
		private System.Windows.Forms.Label lab�͂���o�^�^�C�g��;
		private System.Windows.Forms.GroupBox groupBox1;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex���X�R�[�h;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex�Z���R�[�h;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ���͂���o�^��()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
			�c�o�h�\���T�C�Y�ϊ�();
// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� END
// ADD 2008.10.17 ���s�j���� ���X�R�[�h�`�F�b�N�@�\�s���� START
// DEL 2009.02.02 ���s�j���� ���X�R�[�h�`�F�b�N�@�\���� START
//			lab�Z���R�[�h.Visible = false;
//			lab���X�R�[�h.Visible = false;
// DEL 2009.02.02 ���s�j���� ���X�R�[�h�`�F�b�N�@�\���� END
			tex�Z���R�[�h.Visible = false;
			tex���X�R�[�h.Visible = false;
// ADD 2008.10.17 ���s�j���� ���X�R�[�h�`�F�b�N�@�\�s���� END
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
			this.tex�J�i���� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab���[�� = new System.Windows.Forms.Label();
			this.tex���[�� = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.label1 = new System.Windows.Forms.Label();
			this.lab�J�i���� = new System.Windows.Forms.Label();
			this.btn�o�^ = new System.Windows.Forms.Button();
			this.btn���� = new System.Windows.Forms.Button();
			this.lab�͂���R�[�h = new System.Windows.Forms.Label();
			this.tex�͂���R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.panel7 = new System.Windows.Forms.Panel();
			this.label30 = new System.Windows.Forms.Label();
			this.lab�͂���o�^�^�C�g�� = new System.Windows.Forms.Label();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tex�Z���R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex���X�R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.panel7.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tex�J�i����
			// 
			this.tex�J�i����.BackColor = System.Drawing.SystemColors.Window;
			this.tex�J�i����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�J�i����.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
			this.tex�J�i����.Location = new System.Drawing.Point(130, 38);
			this.tex�J�i����.MaxLength = 10;
			this.tex�J�i����.Name = "tex�J�i����";
			this.tex�J�i����.Size = new System.Drawing.Size(94, 23);
			this.tex�J�i����.TabIndex = 1;
			this.tex�J�i����.Text = "";
			// 
			// lab���[��
			// 
			this.lab���[��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���[��.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab���[��.Location = new System.Drawing.Point(42, 70);
			this.lab���[��.Name = "lab���[��";
			this.lab���[��.Size = new System.Drawing.Size(80, 14);
			this.lab���[��.TabIndex = 50;
			this.lab���[��.Text = "���[���A�h���X";
			// 
			// tex���[��
			// 
			this.tex���[��.BackColor = System.Drawing.SystemColors.Window;
			this.tex���[��.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���[��.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex���[��.Location = new System.Drawing.Point(130, 64);
			this.tex���[��.MaxLength = 45;
			this.tex���[��.Name = "tex���[��";
			this.tex���[��.Size = new System.Drawing.Size(250, 23);
			this.tex���[��.TabIndex = 2;
			this.tex���[��.Text = "";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("�l�r �o�S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 142);
			this.label1.TabIndex = 44;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab�J�i����
			// 
			this.lab�J�i����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�J�i����.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�J�i����.Location = new System.Drawing.Point(42, 42);
			this.lab�J�i����.Name = "lab�J�i����";
			this.lab�J�i����.Size = new System.Drawing.Size(80, 14);
			this.lab�J�i����.TabIndex = 42;
			this.lab�J�i����.Text = "�J�i����";
			// 
			// btn�o�^
			// 
			this.btn�o�^.BackColor = System.Drawing.Color.PaleGreen;
			this.btn�o�^.ForeColor = System.Drawing.Color.Blue;
			this.btn�o�^.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�o�^.Location = new System.Drawing.Point(260, 92);
			this.btn�o�^.Name = "btn�o�^";
			this.btn�o�^.Size = new System.Drawing.Size(54, 48);
			this.btn�o�^.TabIndex = 6;
			this.btn�o�^.Text = "�o�^";
			this.btn�o�^.Click += new System.EventHandler(this.btn�o�^_Click);
			// 
			// btn����
			// 
			this.btn����.BackColor = System.Drawing.Color.PaleGreen;
			this.btn����.ForeColor = System.Drawing.Color.Red;
			this.btn����.Location = new System.Drawing.Point(66, 92);
			this.btn����.Name = "btn����";
			this.btn����.Size = new System.Drawing.Size(54, 48);
			this.btn����.TabIndex = 5;
			this.btn����.TabStop = false;
			this.btn����.Text = "����";
			this.btn����.Click += new System.EventHandler(this.btn����_Click);
			// 
			// lab�͂���R�[�h
			// 
			this.lab�͂���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�͂���R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�͂���R�[�h.Location = new System.Drawing.Point(24, 16);
			this.lab�͂���R�[�h.Name = "lab�͂���R�[�h";
			this.lab�͂���R�[�h.Size = new System.Drawing.Size(104, 16);
			this.lab�͂���R�[�h.TabIndex = 6;
			this.lab�͂���R�[�h.Text = "���͂���R�[�h";
			// 
			// tex�͂���R�[�h
			// 
			this.tex�͂���R�[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex�͂���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�͂���R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�͂���R�[�h.Location = new System.Drawing.Point(130, 12);
			this.tex�͂���R�[�h.MaxLength = 15;
			this.tex�͂���R�[�h.Name = "tex�͂���R�[�h";
			this.tex�͂���R�[�h.Size = new System.Drawing.Size(166, 23);
			this.tex�͂���R�[�h.TabIndex = 0;
			this.tex�͂���R�[�h.Text = "";
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.label30);
			this.panel7.Controls.Add(this.lab�͂���o�^�^�C�g��);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(394, 26);
			this.panel7.TabIndex = 13;
			// 
			// label30
			// 
			this.label30.ForeColor = System.Drawing.Color.White;
			this.label30.Location = new System.Drawing.Point(674, 8);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(112, 14);
			this.label30.TabIndex = 1;
			this.label30.Text = "2005/xx/xx 12:00:00";
			// 
			// lab�͂���o�^�^�C�g��
			// 
			this.lab�͂���o�^�^�C�g��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab�͂���o�^�^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�͂���o�^�^�C�g��.ForeColor = System.Drawing.Color.White;
			this.lab�͂���o�^�^�C�g��.Location = new System.Drawing.Point(12, 2);
			this.lab�͂���o�^�^�C�g��.Name = "lab�͂���o�^�^�C�g��";
			this.lab�͂���o�^�^�C�g��.Size = new System.Drawing.Size(264, 24);
			this.lab�͂���o�^�^�C�g��.TabIndex = 0;
			this.lab�͂���o�^�^�C�g��.Text = "���͂���o�^";
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tex�͂���R�[�h);
			this.groupBox1.Controls.Add(this.btn�o�^);
			this.groupBox1.Controls.Add(this.lab���[��);
			this.groupBox1.Controls.Add(this.tex���[��);
			this.groupBox1.Controls.Add(this.btn����);
			this.groupBox1.Controls.Add(this.tex�J�i����);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.lab�͂���R�[�h);
			this.groupBox1.Controls.Add(this.lab�J�i����);
			this.groupBox1.Controls.Add(this.tex�Z���R�[�h);
			this.groupBox1.Controls.Add(this.tex���X�R�[�h);
			this.groupBox1.Location = new System.Drawing.Point(0, 22);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(388, 149);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			// 
			// tex�Z���R�[�h
			// 
			this.tex�Z���R�[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex�Z���R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex�Z���R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex�Z���R�[�h.Location = new System.Drawing.Point(130, 90);
			this.tex�Z���R�[�h.MaxLength = 16;
			this.tex�Z���R�[�h.Name = "tex�Z���R�[�h";
			this.tex�Z���R�[�h.Size = new System.Drawing.Size(124, 23);
			this.tex�Z���R�[�h.TabIndex = 1;
			this.tex�Z���R�[�h.Text = "";
			// 
			// tex���X�R�[�h
			// 
			this.tex���X�R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���X�R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex���X�R�[�h.Location = new System.Drawing.Point(130, 116);
			this.tex���X�R�[�h.MaxLength = 4;
			this.tex���X�R�[�h.Name = "tex���X�R�[�h";
			this.tex���X�R�[�h.Size = new System.Drawing.Size(40, 23);
			this.tex���X�R�[�h.TabIndex = 2;
			this.tex���X�R�[�h.Text = "";
			// 
			// ���͂���o�^��
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(390, 173);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.groupBox1);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(396, 205);
			this.Name = "���͂���o�^��";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 ���͂���o�^";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
			this.Load += new System.EventHandler(this.���͂���o�^��_Load);
			this.Closed += new System.EventHandler(this.���͂���o�^��_Closed);
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
			this.Close();
		}

		private void btn�o�^_Click(object sender, System.EventArgs e)
		{
			tex�͂���R�[�h.Text = tex�͂���R�[�h.Text.Trim();
			tex�J�i����.Text     = tex�J�i����.Text.Trim();
			tex���[��.Text       = tex���[��.Text.Trim();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
			if(gs�I�v�V����[18].Equals("1")){
				tex�J�i����.Text     = tex�J�i����.Text.TrimEnd();
				tex���[��.Text       = tex���[��.Text.TrimEnd();
			}
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX START
			tex�Z���R�[�h.Text   = tex�Z���R�[�h.Text.Trim();
			tex���X�R�[�h.Text   = tex���X�R�[�h.Text.Trim();
// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX END

			if(!�K�{�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;

			if(!���p�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;
			if(!���p�`�F�b�N(tex�J�i����,"�J�i����")) return;
			if(!���p�`�F�b�N(tex���[��,"���[���A�h���X")) return;
// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX START
			if(!���p�`�F�b�N(tex�Z���R�[�h,"�Z���R�[�h")) return;
			if(!���p�`�F�b�N(tex���X�R�[�h,"���X�R�[�h")) return;
// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX END

			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			String[] sList = {""};
			try
			{
				if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
				sList = sv_otodoke.Get_Stodokesaki(gsa���[�U,gs����b�c,gs����b�c,tex�͂���R�[�h.Text);

//			sUpday    = sList[14];
				//���R�����g�폜�H
				sIUFlg    = sList[15];

				String[] sIUList;
				sTdata[0]  = tex�͂���R�[�h.Text;
				sTdata[1]  = tex�J�i����.Text;
				sTdata[12] = " ";
				sTdata[13] = tex���[��.Text;
				sTdata[14] = "���͂���";
				sTdata[15] = gs���p�҂b�c;
				sTdata[16] = gs����b�c;
				sTdata[17] = gs����b�c;
// MOD 2008.03.19 ���s�j���� ���͂���̏㏑�@�\�̒ǉ� START
				sTdata[18] = sList[14];		//�X�V����
// MOD 2008.03.19 ���s�j���� ���͂���̏㏑�@�\�̒ǉ� END
// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX START
				// �Z���R�[�h�����͂���Ă���ꍇ�́A�����D�悷��
// MOD 2008.11.12 ���s�j���� �Z���b�c�̎����ݒ���s��Ȃ� START
//				if (tex�Z���R�[�h.Text.Length > 0)
// MOD 2008.11.12 ���s�j���� �Z���b�c�̎����ݒ���s��Ȃ� END
				sTdata[19] = tex�Z���R�[�h.Text;
				sTdata[20] = tex���X�R�[�h.Text;
// ADD 2008.06.11 kcl)�X�{ ���X�R�[�h�������@�̕ύX END
				for(int iCnt = 0 ; iCnt < sTdata.Length; iCnt++ )
				{
					if( sTdata[iCnt] == null 
						|| sTdata[iCnt].Length == 0 ) sTdata[iCnt] = " ";
				}

				if(sIUFlg == "I")
				{
					sIUList = sv_otodoke.Ins_todokesaki(gsa���[�U,sTdata);
					if(sIUList[0].Length == 4)
					{
						s�͂���b�c = tex�͂���R�[�h.Text;
						this.Close();
					}
					else
					{
						MessageBox.Show(sIUList[0],"�G���[",MessageBoxButtons.OK);
					}
				}
				else
				{
// MOD 2008.03.19 ���s�j���� ���͂���̏㏑�@�\�̒ǉ� START
//					MessageBox.Show("����̃R�[�h�����ɓo�^����Ă��܂��B","�o�^",MessageBoxButtons.OK);
//					tex�͂���R�[�h.Focus();
					DialogResult result;
					if(btn�o�^.Text.Equals("�o�^")){
						result = MessageBox.Show("���ɑ��݂���f�[�^�ɏ㏑�����܂����H","�X�V",MessageBoxButtons.YesNo);
					}else{
						result = DialogResult.Yes;
					}
					if(result == DialogResult.Yes)
					{
						Cursor = System.Windows.Forms.Cursors.AppStarting;
//						tex���b�Z�[�W.Text = "�X�V���D�D�D";

						if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
						sIUList = sv_otodoke.Upd_todokesaki(gsa���[�U,sTdata);
						Cursor = System.Windows.Forms.Cursors.Default;
						// ����I�����A��ʂ��N���A����
						if(sIUList[0].Length == 4)
						{
							s�͂���b�c = tex�͂���R�[�h.Text;
							this.Close();
						}
						else
						{
							�r�[�v��();
							MessageBox.Show(sIUList[0],"�G���[",MessageBoxButtons.OK);
						}
					}
// MOD 2008.03.19 ���s�j���� ���͂���̏㏑�@�\�̒ǉ� END
				}
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
			catch (System.Net.WebException)
			{
				sList[0] = gs�ʐM�G���[;
				MessageBox.Show(sList[0],"�G���[",MessageBoxButtons.OK);
			}
// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
			catch (Exception ex)
			{
				sList[0] = "�ʐM�G���[�F" + ex.Message;
				MessageBox.Show(sList[0],"�G���[",MessageBoxButtons.OK);
			}
			Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void ���͂���o�^��_Load(object sender, EventArgs e)
		{
// MOD 2008.03.19 ���s�j���� ���͂���̏㏑�@�\�̒ǉ� START
//			if(s�͂���b�c.Length == 0)
//				tex�͂���R�[�h.Text  = " ";
//			else
//				tex�͂���R�[�h.Text = s�͂���b�c;
			if(s�͂���b�c.Length == 0){
				tex�͂���R�[�h.Text  = " ";
				btn�o�^.Text = "�o�^";
			}else{
				tex�͂���R�[�h.Text = s�͂���b�c;
				tex�͂���R�[�h.Text = tex�͂���R�[�h.Text.Trim();
				if(!���p�`�F�b�N(tex�͂���R�[�h,"�͂���R�[�h")) return;

				// �J�[�\���������v�ɂ���
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				String[] sList = {""};
				try
				{
					if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
					sList = sv_otodoke.Get_Stodokesaki(gsa���[�U,gs����b�c,gs����b�c,tex�͂���R�[�h.Text);
					if(sList[0].Equals("�X�V")){
						tex�͂���R�[�h.Enabled = false;
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� START
//// MOD 2008.03.19 ���s�j���� ���͂���̏㏑�@�\�̒ǉ� START
//						tex�J�i����.Text = sList[1].Trim();
//						tex���[��.Text   = sList[13].Trim();
//// MOD 2008.03.19 ���s�j���� ���͂���̏㏑�@�\�̒ǉ� END
						tex�J�i����.Text = sList[1].TrimEnd();
						tex���[��.Text   = sList[13].TrimEnd();
// MOD 2011.01.18 ���s�j���� �Z�����O�̑OSPACE���߂Ȃ� END
// ADD 2008.06.16 kcl)�X�{ ���X�R�[�h�������@�̕ύX START
						tex�Z���R�[�h.Text = sList[16].Trim();
						tex���X�R�[�h.Text = sList[17].Trim();
// ADD 2008.06.16 kcl)�X�{ ���X�R�[�h�������@�̕ύX END
						btn�o�^.Text = "�㏑��";
					}else{
						btn�o�^.Text = "�o�^";
					}
					btn�o�^.Refresh();
				}
				catch (System.Net.WebException)
				{
					sList[0] = gs�ʐM�G���[;
					MessageBox.Show(sList[0],"�G���[",MessageBoxButtons.OK);
				}
				catch (Exception ex)
				{
					sList[0] = "�ʐM�G���[�F" + ex.Message;
					MessageBox.Show(sList[0],"�G���[",MessageBoxButtons.OK);
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
// MOD 2008.03.19 ���s�j���� ���͂���̏㏑�@�\�̒ǉ� END
		}

		private void ���͂���o�^��_Closed(object sender, System.EventArgs e)
		{
// MOD 2008.03.19 ���s�j���� ���͂���̏㏑�@�\�̒ǉ� START
			tex�͂���R�[�h.Enabled = true;
// MOD 2008.03.19 ���s�j���� ���͂���̏㏑�@�\�̒ǉ� END
			tex�͂���R�[�h.Text  = "               ";
			tex�J�i����.Text      = "";
			tex���[��.Text        = "";
// ADD 2008.06.16 kcl)�X�{ ���X�R�[�h�������@�̕ύX START
			tex�Z���R�[�h.Text    = "";
			tex���X�R�[�h.Text    = "";
// ADD 2008.06.16 kcl)�X�{ ���X�R�[�h�������@�̕ύX END
			tex�͂���R�[�h.Focus();
		}
	}
}
