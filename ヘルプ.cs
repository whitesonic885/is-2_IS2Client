using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace IS2Client
{
	/// <summary>
	/// [�w���v]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� 
	// MOD 2010.06.07 ���s�j���� �e�`�p�̒ǉ� 
	//--------------------------------------------------------------------------
	// MOD 2011.02.03 ���s�j���� SATO���v�����^���|�}�j���A���ǉ� 
	// MOD 2011.06.22 ���s�j���� ���q�^���̑Ή� 
	// MOD 2011.07.25 ���s�j���� �����}�j���A��PDF���ύX 
	//--------------------------------------------------------------------------
	public class �w���v : IS2Client.���ʃt�H�[��
	{
		public  string s�w���v�t�q�k         = "";
		public  string s�w���v�t�q�k�a�`�r�d = "";

		private System.Windows.Forms.Button[] btn�w���v;

		private System.Windows.Forms.Button btnClose;
		private System.ComponentModel.IContainer components = null;

		public �w���v()
		{
			// ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
			InitializeComponent();

// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
			�c�o�h�\���T�C�Y�ϊ�();
// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� END
			Init();
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

		#region �f�U�C�i�Ő������ꂽ�R�[�h
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.BackColor = System.Drawing.Color.MediumBlue;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btnClose.ForeColor = System.Drawing.Color.White;
			this.btnClose.Location = new System.Drawing.Point(0, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(210, 26);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "����";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// �w���v
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.ClientSize = new System.Drawing.Size(210, 390);
			this.Controls.Add(this.btnClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "�w���v";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.ResumeLayout(false);

		}
		#endregion
		//�w���v��
		private static string[] s�w���v = {
			  "iS-2�ȈՃ}�j���A��", "iS-2����}�j���A��"
			, "�@iS-2���g�p����ɂ�", "�@�o�ׂ��s��", "�@���x���̍Ĉ��"
			, "�@�G���g���[�̏C��", "�@���т̏Ɖ�", "�@���͂���̓o�^"
			, "�@���˗���̓o�^", "�@�L���̓o�^", "�@���x���v�����^�̕ύX"
			, "�@������̓o�^", "�@�G���g���[�I�v�V����", "�@���̑��֗̕��ȋ@�\"
			, "�@���m�点", "�@�t�^"
// MOD 2011.02.03 ���s�j���� SATO���v�����^���|�}�j���A���ǉ� START
			, "SATO��������̐��|���@"
			, "SATO������������پ�ĕ��@"
// MOD 2011.02.03 ���s�j���� SATO���v�����^���|�}�j���A���ǉ� END
// MOD 2010.06.07 ���s�j���� �e�`�p�̒ǉ� START
			, "�����o�͑����ƭ��"
			, "�e�`�p�i�悭���鎿��j"
// MOD 2010.06.07 ���s�j���� �e�`�p�̒ǉ� END
		};
		private static int i�w���v�� = s�w���v.Length;
		//�w���v�̂o�c�e
		private static string[] s�w���v�o�c�e = {
// MOD 2010.06.07 ���s�j���� �e�`�p�̒ǉ� START
//			  "is2manual_kani.pdf", ""
			  "is2manual_kani.pdf", "is2manual.pdf"
// MOD 2010.06.07 ���s�j���� �e�`�p�̒ǉ� END
			, "1-1 iS-2���g�p����ɂ�.pdf", "2-1 �G���g���[.pdf", "2-6 �Ĕ��s.pdf"
// MOD 2011.07.25 ���s�j���� �����}�j���A��PDF���ύX START
//			, "2-8 �G���g���[�̏C��.pdf", "3-1 �o�׏Ɖ�.pdf", "4-1 ���͂�����.pdf"
//			, "4-6 ���˗�����.pdf", "4-10 �L�����.pdf", "4-14 �[�����.pdf"
//			, "4-15 ��������.pdf", "4-18 �G���g���[�I�v�V����.pdf", "5-1 ���̑��֗̕��ȋ@�\.pdf"
			, "2-9 �G���g���[�̏C��.pdf", "3-1 �o�׏Ɖ�.pdf", "4-1 ���͂�����.pdf"
			, "4-7 ���˗�����.pdf", "4-13 �L�����.pdf", "4-17 �[�����.pdf"
			, "4-18 ��������.pdf", "4-21 �G���g���[�I�v�V����.pdf", "5-1 ���̑��֗̕��ȋ@�\.pdf"
// MOD 2011.07.25 ���s�j���� �����}�j���A��PDF���ύX END
			, "6 ���m�点�@�\.pdf", "7 �t�^.pdf"
// MOD 2011.02.03 ���s�j���� SATO���v�����^���|�}�j���A���ǉ� START
			, "SATO���|����.pdf"
			, "���X�v�������x���Z�b�g���@.pdf"
// MOD 2011.02.03 ���s�j���� SATO���v�����^���|�}�j���A���ǉ� END
// MOD 2010.06.07 ���s�j���� �e�`�p�̒ǉ� START
//			  "is2manual_kani.pdf", ""
			, "iS-2�����o�̓}�j���A��.pdf"
			, "/hp/faq/is2Faq.htm"
// MOD 2010.06.07 ���s�j���� �e�`�p�̒ǉ� END
		};
		private void Init()
		{
			//�����̐ݒ�
			this.Height = 26 * (1 + i�w���v��);
			//�{�^���̐ݒ�
			this.btn�w���v = new System.Windows.Forms.Button[i�w���v��];
			for(int iCnt = 0; iCnt < i�w���v��; iCnt++){
				this.btn�w���v[iCnt] = new System.Windows.Forms.Button();
				this.btn�w���v[iCnt].BackColor = System.Drawing.Color.MediumBlue;
				this.btn�w���v[iCnt].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
				this.btn�w���v[iCnt].Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
				this.btn�w���v[iCnt].ForeColor = System.Drawing.Color.White;
				this.btn�w���v[iCnt].Location = new System.Drawing.Point(0, 26 + 26 * iCnt);
				this.btn�w���v[iCnt].Name = "btn�w���v" + iCnt.ToString();
				this.btn�w���v[iCnt].Size = new System.Drawing.Size(210, 26);
				this.btn�w���v[iCnt].TabIndex = iCnt;
				this.btn�w���v[iCnt].Text = s�w���v[iCnt];
				this.btn�w���v[iCnt].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
				this.btn�w���v[iCnt].Click += new System.EventHandler(this.btn�w���v99_Click);
			}
			for(int iCnt = 0; iCnt < i�w���v��; iCnt++){
				this.Controls.Add(this.btn�w���v[iCnt]);
			}
		}
		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void btn�w���v99_Click(object sender, System.EventArgs e)
		{
// MOD 2010.06.07 ���s�j���� �e�`�p�̒ǉ� START
//			if(sender == btn�w���v[1]){
//				Process.Start("iexplore.exe", s�w���v�t�q�k);
// MOD 2011.06.22 ���s�j���� ���q�^���̑Ή� START
			if(gs����b�c.Substring(0,1) != "J"){
// MOD 2011.06.22 ���s�j���� ���q�^���̑Ή� END
				if(s�w���v�o�c�e[((Button)sender).TabIndex].StartsWith("/")){
					Process.Start("iexplore.exe"
						, s�w���v�t�q�k�a�`�r�d.Replace("/is2/manual/","")
							 + s�w���v�o�c�e[((Button)sender).TabIndex]);
// MOD 2010.06.07 ���s�j���� �e�`�p�̒ǉ� END
				}else{
					Process.Start("iexplore.exe"
						, s�w���v�t�q�k�a�`�r�d
							 + s�w���v�o�c�e[((Button)sender).TabIndex]);
				}
// MOD 2011.06.22 ���s�j���� ���q�^���̑Ή� START
			}else{
				// ���q�^���̏ꍇ
				if(s�w���v�o�c�e[((Button)sender).TabIndex].StartsWith("/")){
					Process.Start("iexplore.exe"
						, s�w���v�t�q�k�a�`�r�d.Replace("/is2/manual/","")
							 + s�w���v�o�c�e[((Button)sender).TabIndex].Replace("/hp/","/hpj/"));
				}else{
					if(((Button)sender).TabIndex == 16		// "SATO���|����.pdf"
					|| ((Button)sender).TabIndex == 17){	// "���X�v�������x���Z�b�g���@.pdf"
						Process.Start("iexplore.exe"
							, s�w���v�t�q�k�a�`�r�d
							 + s�w���v�o�c�e[((Button)sender).TabIndex]);
					}else{
						Process.Start("iexplore.exe"
							, s�w���v�t�q�k�a�`�r�d.Replace("/manual/","/manualJ/")
							 + s�w���v�o�c�e[((Button)sender).TabIndex].Replace(".pdf","(���q).pdf"));
					}
				}
			}
// MOD 2011.06.22 ���s�j���� ���q�^���̑Ή� END
			this.Close();
		}
	}
}

