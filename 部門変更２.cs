using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [�Z�N�V�����ύX]
	/// </summary>
	//--------------------------------------------------------------------------
	// �C������
	//--------------------------------------------------------------------------
	// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� 
	// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� 
	//--------------------------------------------------------------------------
	// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� 
	//--------------------------------------------------------------------------
	// MOD 2016.05.24 BEVAS�j���{ �\���`���C������ь����@�\�ǉ�
	//--------------------------------------------------------------------------
	public class ����ύX�Q : ���ʃt�H�[��
	{
// MOD 2016.05.24 BEVAS�j���{ �\���`���C������ь����@�\�ǉ� START
//		private object o�����h�c�w = null;
		public short nOldRow = 0;
		public string s����R�[�h;
		public string s���喼;
		private string[] s����ꗗ;
		private int i���ݕŐ�;
		private int i�ő�Ő�;
		private int i�J�n��;
		private int i�I����;
		private int i�A�N�e�B�u�e�f = 0;
		private int i�ōő�s�� = 100;
// MOD 2016.05.24 BEVAS�j���{ �\���`���C������ь����@�\�ǉ� END

		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label lab����ύX�^�C�g��;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lab���喼;
		private System.Windows.Forms.Label lab����;
		private System.Windows.Forms.Panel panel5;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex����R�[�h;
		private IS2Client.���ʃe�L�X�g�{�b�N�X tex���喼;
		private System.Windows.Forms.Label lab����R�[�h;
		private System.Windows.Forms.Label lab�����;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lab�Ŕԍ�;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Button btn�O��;
		private AxGTABLE32V2Lib.AxGTable32 axGT����;
		private System.Windows.Forms.Button btn����;
		private System.Windows.Forms.Button btn�X�V;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ����ύX�Q()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� START
			�c�o�h�\���T�C�Y�ϊ�();
// MOD 2010.03.31 ���s�j���� �c�o�h�\���T�C�Y�ϊ� END
//// MOD 2016.05.24 BEVAS�j���{ �\���`���C������ь����@�\�ǉ� START
//			this.axGT����.Size = new System.Drawing.Size(422, 292);
//// MOD 2016.05.24 BEVAS�j���{ �\���`���C������ь����@�\�ǉ� END
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(����ύX�Q));
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab����ύX�^�C�g�� = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.tex����R�[�h = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.tex���喼 = new IS2Client.���ʃe�L�X�g�{�b�N�X();
			this.lab����R�[�h = new System.Windows.Forms.Label();
			this.lab����� = new System.Windows.Forms.Label();
			this.btn���� = new System.Windows.Forms.Button();
			this.lab���喼 = new System.Windows.Forms.Label();
			this.lab���� = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lab�Ŕԍ� = new System.Windows.Forms.Label();
			this.btn���� = new System.Windows.Forms.Button();
			this.btn�O�� = new System.Windows.Forms.Button();
			this.axGT���� = new AxGTABLE32V2Lib.AxGTable32();
			this.btn���� = new System.Windows.Forms.Button();
			this.btn�X�V = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).BeginInit();
			this.panel7.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel5.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axGT����)).BeginInit();
			this.SuspendLayout();
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.lab����ύX�^�C�g��);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(394, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab����ύX�^�C�g��
			// 
			this.lab����ύX�^�C�g��.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab����ύX�^�C�g��.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab����ύX�^�C�g��.ForeColor = System.Drawing.Color.White;
			this.lab����ύX�^�C�g��.Location = new System.Drawing.Point(12, 2);
			this.lab����ύX�^�C�g��.Name = "lab����ύX�^�C�g��";
			this.lab����ύX�^�C�g��.Size = new System.Drawing.Size(264, 24);
			this.lab����ύX�^�C�g��.TabIndex = 0;
			this.lab����ύX�^�C�g��.Text = "�Z�N�V�����ύX";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel5);
			this.groupBox2.Location = new System.Drawing.Point(8, 92);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(378, 70);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.Honeydew;
			this.panel5.Controls.Add(this.tex����R�[�h);
			this.panel5.Controls.Add(this.tex���喼);
			this.panel5.Controls.Add(this.lab����R�[�h);
			this.panel5.Controls.Add(this.lab�����);
			this.panel5.Controls.Add(this.btn����);
			this.panel5.Location = new System.Drawing.Point(3, 8);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(370, 60);
			this.panel5.TabIndex = 50;
			// 
			// tex����R�[�h
			// 
			this.tex����R�[�h.BackColor = System.Drawing.SystemColors.Window;
			this.tex����R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex����R�[�h.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex����R�[�h.Location = new System.Drawing.Point(116, 5);
			this.tex����R�[�h.MaxLength = 10;
			this.tex����R�[�h.Name = "tex����R�[�h";
			this.tex����R�[�h.Size = new System.Drawing.Size(146, 23);
			this.tex����R�[�h.TabIndex = 1;
			this.tex����R�[�h.Text = "";
			// 
			// tex���喼
			// 
			this.tex���喼.BackColor = System.Drawing.SystemColors.Window;
			this.tex���喼.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex���喼.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex���喼.Location = new System.Drawing.Point(116, 33);
			this.tex���喼.MaxLength = 100;
			this.tex���喼.Name = "tex���喼";
			this.tex���喼.Size = new System.Drawing.Size(174, 23);
			this.tex���喼.TabIndex = 2;
			this.tex���喼.Text = "";
			this.tex���喼.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex���喼_KeyDown);
			// 
			// lab����R�[�h
			// 
			this.lab����R�[�h.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab����R�[�h.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab����R�[�h.Location = new System.Drawing.Point(4, 10);
			this.lab����R�[�h.Name = "lab����R�[�h";
			this.lab����R�[�h.Size = new System.Drawing.Size(108, 16);
			this.lab����R�[�h.TabIndex = 0;
			this.lab����R�[�h.Text = "�Z�N�V�����R�[�h";
			// 
			// lab�����
			// 
			this.lab�����.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�����.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab�����.Location = new System.Drawing.Point(4, 34);
			this.lab�����.Name = "lab�����";
			this.lab�����.Size = new System.Drawing.Size(92, 16);
			this.lab�����.TabIndex = 6;
			this.lab�����.Text = "�Z�N�V������";
			// 
			// btn����
			// 
			this.btn����.BackColor = System.Drawing.Color.SteelBlue;
			this.btn����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn����.ForeColor = System.Drawing.Color.White;
			this.btn����.Location = new System.Drawing.Point(302, 32);
			this.btn����.Name = "btn����";
			this.btn����.Size = new System.Drawing.Size(64, 22);
			this.btn����.TabIndex = 3;
			this.btn����.TabStop = false;
			this.btn����.Text = "����";
			this.btn����.Click += new System.EventHandler(this.btn����_Click);
			// 
			// lab���喼
			// 
			this.lab���喼.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab���喼.Location = new System.Drawing.Point(6, 64);
			this.lab���喼.Name = "lab���喼";
			this.lab���喼.Size = new System.Drawing.Size(382, 24);
			this.lab���喼.TabIndex = 49;
			this.lab���喼.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab����
			// 
			this.lab����.Image = ((System.Drawing.Image)(resources.GetObject("lab����.Image")));
			this.lab����.Location = new System.Drawing.Point(180, 30);
			this.lab����.Name = "lab����";
			this.lab����.Size = new System.Drawing.Size(32, 32);
			this.lab����.TabIndex = 48;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.panel2);
			this.groupBox3.Location = new System.Drawing.Point(10, 172);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(377, 346);
			this.groupBox3.TabIndex = 52;
			this.groupBox3.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Honeydew;
			this.panel2.Controls.Add(this.lab�Ŕԍ�);
			this.panel2.Controls.Add(this.btn����);
			this.panel2.Controls.Add(this.btn�O��);
			this.panel2.Controls.Add(this.axGT����);
			this.panel2.Location = new System.Drawing.Point(5, 8);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(366, 328);
			this.panel2.TabIndex = 51;
			// 
			// lab�Ŕԍ�
			// 
			this.lab�Ŕԍ�.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab�Ŕԍ�.ForeColor = System.Drawing.Color.Green;
			this.lab�Ŕԍ�.Location = new System.Drawing.Point(248, 308);
			this.lab�Ŕԍ�.Name = "lab�Ŕԍ�";
			this.lab�Ŕԍ�.Size = new System.Drawing.Size(56, 14);
			this.lab�Ŕԍ�.TabIndex = 79;
			this.lab�Ŕԍ�.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn����
			// 
			this.btn����.BackColor = System.Drawing.Color.SteelBlue;
			this.btn����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn����.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn����.ForeColor = System.Drawing.Color.White;
			this.btn����.Location = new System.Drawing.Point(304, 304);
			this.btn����.Name = "btn����";
			this.btn����.Size = new System.Drawing.Size(48, 22);
			this.btn����.TabIndex = 78;
			this.btn����.TabStop = false;
			this.btn����.Text = "����";
			this.btn����.Click += new System.EventHandler(this.btn����_Click);
			// 
			// btn�O��
			// 
			this.btn�O��.BackColor = System.Drawing.Color.SteelBlue;
			this.btn�O��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn�O��.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn�O��.ForeColor = System.Drawing.Color.White;
			this.btn�O��.Location = new System.Drawing.Point(200, 304);
			this.btn�O��.Name = "btn�O��";
			this.btn�O��.Size = new System.Drawing.Size(48, 22);
			this.btn�O��.TabIndex = 77;
			this.btn�O��.TabStop = false;
			this.btn�O��.Text = "�O��";
			this.btn�O��.Click += new System.EventHandler(this.btn�O��_Click);
			// 
			// axGT����
			// 
			this.axGT����.ContainingControl = this;
			this.axGT����.DataSource = null;
			this.axGT����.Location = new System.Drawing.Point(24, 16);
			this.axGT����.Name = "axGT����";
			this.axGT����.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT����.OcxState")));
			this.axGT����.Size = new System.Drawing.Size(328, 272);
			this.axGT����.TabIndex = 4;
			this.axGT����.KeyDownEvent += new AxGTABLE32V2Lib._DGTable32Events_KeyDownEventHandler(this.axGT����_KeyDownEvent);
			this.axGT����.CelDblClick += new AxGTABLE32V2Lib._DGTable32Events_CelDblClickEventHandler(this.axGT����_CelDblClick);
			this.axGT����.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT����_CurPlaceChanged);
			// 
			// btn����
			// 
			this.btn����.BackColor = System.Drawing.Color.PaleGreen;
			this.btn����.ForeColor = System.Drawing.Color.Red;
			this.btn����.Location = new System.Drawing.Point(118, 526);
			this.btn����.Name = "btn����";
			this.btn����.Size = new System.Drawing.Size(54, 48);
			this.btn����.TabIndex = 57;
			this.btn����.TabStop = false;
			this.btn����.Text = "����";
			this.btn����.Click += new System.EventHandler(this.btn����_Click);
			// 
			// btn�X�V
			// 
			this.btn�X�V.BackColor = System.Drawing.Color.PaleGreen;
			this.btn�X�V.ForeColor = System.Drawing.Color.Blue;
			this.btn�X�V.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn�X�V.Location = new System.Drawing.Point(222, 526);
			this.btn�X�V.Name = "btn�X�V";
			this.btn�X�V.Size = new System.Drawing.Size(54, 48);
			this.btn�X�V.TabIndex = 56;
			this.btn�X�V.Text = "�ۑ�";
			this.btn�X�V.Click += new System.EventHandler(this.btn�X�V_Click);
			// 
			// ����ύX�Q
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(392, 582);
			this.Controls.Add(this.btn����);
			this.Controls.Add(this.btn�X�V);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.lab���喼);
			this.Controls.Add(this.lab����);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.groupBox2);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(398, 607);
			this.Name = "����ύX�Q";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "is-2 �Z�N�V�����ύX";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.�G���^�[�ړ�);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.�G���^�[�L�����Z��);
			this.Load += new System.EventHandler(this.����ύX_Load);
			this.Closed += new System.EventHandler(this.����ύX�Q_Closed);
			this.Activated += new System.EventHandler(this.����ύX�Q_Activated);
			((System.ComponentModel.ISupportInitialize)(this.ds�����)).EndInit();
			this.panel7.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axGT����)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		private void ����ύX_Load(object sender, System.EventArgs e)
		{
// MOD 2016.05.24 BEVAS�j���{ �\���`���C������ь����@�\�ǉ� START
//			// ���C�u�����̏����ݒ�
//			����A�C�R���̏�����();
//			listView����.LargeImageList = imageList����;
//
//			listView����.Items.Clear();
//
//			lab���喼.Text = gs���喼;
//
//			// ���݂̕����̈ʒu���擾
//			o�����h�c�w = gh����b�c[gs����b�c];
//
//			ListViewItem item;
//			for(int iCnt = 0; iCnt < gsa���喼.Length; iCnt++)
//			{
//				// ���݂̕����̓��X�g�ɕ\�����Ȃ�
//				if(o�����h�c�w != null && iCnt == (int)o�����h�c�w) continue;  
//				item = new ListViewItem();
//				item.Text = gsa���喼[iCnt];
//				item.ImageIndex = 0;
//				listView����.Items.Add(item);
//			}
//
//			listView����.Focus();
			i�A�N�e�B�u�e�f = 0;
			lab���喼.Text = gs���喼;
			tex����R�[�h.Text = s����R�[�h;
			tex���喼.Text = s���喼;

			axGT����.Cols = 4;
			axGT����.Rows = 15;
			axGT����.ColSep = "|";
			axGT����.CaretRow = 1;
			axGT����.NoBeep = true;
			
			axGT����.set_RowsText(0, "|�R�[�h|�Z�N�V������|�o�ד�|���q�l�R�[�h|");
			axGT����.ColsWidth = "0|7|16.7|0|0|";
			axGT����.ColsAlignHorz = "1|1|0|0|0|";
			axGT����.set_CelForeColor(axGT����.CaretRow, 0, 0x98FB98);  //BGR
			axGT����.set_CelBackColor(axGT����.CaretRow, 0, 0x006000);

			btn�O��.Enabled = false;
			btn����.Enabled = false;
			lab�Ŕԍ�.Text = "";
			i���ݕŐ� = 1;

			axGT����.CaretRow = 1;
			axGT����_CurPlaceChanged(null, null);
// MOD 2016.05.24 BEVAS�j���{ �\���`���C������ь����@�\�ǉ� END
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
// MOD 2016.05.24 BEVAS�j���{ �\���`���C������ь����@�\�ǉ� START
			s����R�[�h = "";
			s���喼 = "";
// MOD 2016.05.24 BEVAS�j���{ �\���`���C������ь����@�\�ǉ� END
			this.Close();
		}

		private void btn�X�V_Click(object sender, System.EventArgs e)
		{
// MOD 2016.05.24 BEVAS�j���{ �\���`���C������ь����@�\�ǉ� START
//			// �I������Ă��Ȃ��ꍇ�ɂ͏I��
//			if(listView����.SelectedItems.Count == 0)
//			{	
//				MessageBox.Show("�Z�N�V�������I������Ă��܂���B", "�m�F",
//					MessageBoxButtons.OK, MessageBoxIcon.Warning);
//				listView����.Focus();
//				return;
//			}
//
//			int i�I������ = listView����.SelectedItems[0].Index;
//
//			if(i�I������ >= 0)
//			{
//				if(o�����h�c�w != null && i�I������ >= (int)o�����h�c�w)
//					i�I������++;
//				gs���喼   = gsa���喼[i�I������];
//				gs����b�c = gsa����b�c[i�I������];
//				gs�o�ד�   = gsa�o�ד�[i�I������];
//				if(gs�o�ד�.Length == 8)
//				{
//					gdt�o�ד� = new DateTime(int.Parse(gs�o�ד�.Substring(0,4)), 
//											int.Parse(gs�o�ד�.Substring(4,2)),
//											int.Parse(gs�o�ד�.Substring(6)) );
//				}
////�ۗ��@������폜 START
//				gsa������b�c     = null;
//				gsa�����敔�ۂb�c = null;
//				gsa�����敔�ۖ�   = null;
//
//				// �J�[�\���������v�ɂ���
//				Cursor = System.Windows.Forms.Cursors.AppStarting;
//				string[] sRet = {""};
//				try
//				{
//					// ��������̎擾�igs����b�c�Ags����b�c�j
//					if(sv_init == null) sv_init = new is2init.Service1();
//					sRet = sv_init.Get_seikyu(gsa���[�U,gs����b�c, gs����b�c);
//
//					// �������񐔂̎擾
//					int iCntTokui  = int.Parse(sRet[1]);
//					// ��{���̍ŏI�C���f�b�N�X
//					int iPos = 2;
//
//					// ��������̐ݒ�
//					if(iCntTokui > 0)
//					{
//						gsa������b�c     = new string[iCntTokui];
//						gsa�����敔�ۂb�c = new string[iCntTokui];
//						gsa�����敔�ۖ�   = new string[iCntTokui];
//						for(int iCnt = 0; iCnt < iCntTokui; iCnt++)
//						{
//							gsa������b�c[iCnt]     = sRet[iPos++];
//							gsa�����敔�ۂb�c[iCnt] = sRet[iPos++];
//							gsa�����敔�ۖ�[iCnt]   = sRet[iPos++];
//						}
//					}
//				}
//// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� START
//				catch (System.Net.WebException)
//				{
//					sRet[0] = gs�ʐM�G���[;
//				}
//// ADD 2005.05.24 ���s�j�����J �ʐM�G���[�̃��b�Z�[�W�C�� END
//				catch (Exception ex)
//				{
//					sRet[0] = "�ʐM�G���[�F" + ex.Message;
//				}
//				// �J�[�\�����f�t�H���g�ɖ߂�
//				Cursor = System.Windows.Forms.Cursors.Default;
//
//				if(sRet[0].Length != 4)
//				{
//					MessageBox.Show(sRet[0], "�Z�N�V�����ύX", 
//						MessageBoxButtons.OK, MessageBoxIcon.Error);
//					return;
//				}
////�ۗ��@������폜 END
//			}
			//�I������Ă��Ȃ��ꍇ�ɂ͏I��
			if(axGT����.get_CelText(axGT����.CaretRow, 1).Trim().Length == 0)
			{
				MessageBox.Show("�Z�N�V�������I������Ă��܂���B", "�m�F", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				axGT����.Focus();
				return;
			}

			gs����b�c = axGT����.get_CelText(axGT����.CaretRow, 1).Trim();
			gs���喼 = axGT����.get_CelText(axGT����.CaretRow, 2).Trim();
			gs�o�ד� = axGT����.get_CelText(axGT����.CaretRow, 3).Trim();
			if(gs�o�ד�.Length == 8)
			{
				gdt�o�ד� = new DateTime(int.Parse(gs�o�ד�.Substring(0, 4)), 
					int.Parse(gs�o�ד�.Substring(4, 2)),
					int.Parse(gs�o�ד�.Substring(6)) );
			}

//�ۗ��@������폜 START
			gsa������b�c = null;
			gsa�����敔�ۂb�c = null;
			gsa�����敔�ۖ� = null;

			//�J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sRet = {""};
			try
			{
				//��������̎擾�igs����b�c�Ags����b�c�j
				if(sv_init == null) sv_init = new is2init.Service1();
				sRet = sv_init.Get_seikyu(gsa���[�U, gs����b�c, gs����b�c);

				//�������񐔂̎擾
				int iCntTokui  = int.Parse(sRet[1]);

				//��{���̍ŏI�C���f�b�N�X
				int iPos = 2;

				//��������̐ݒ�
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
			catch(System.Net.WebException)
			{
				sRet[0] = gs�ʐM�G���[;
			}
			catch(Exception ex)
			{
				sRet[0] = "�ʐM�G���[�F" + ex.Message;
			}

			//�J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;

			if(sRet[0].Length != 4)
			{
				MessageBox.Show(sRet[0], "�Z�N�V�����ύX", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
//�ۗ��@������폜 END
// MOD 2016.05.24 BEVAS�j���{ �\���`���C������ь����@�\�ǉ� END
// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� START
			gs����X���b�c = "";
			gs����X���b�c = ����X���擾(gs����b�c);
// MOD 2009.12.02 ���s�j���� �O���[�o���̏ꍇ�A�z�B�w���������{�X�O�� END

			this.Close();
		}

// MOD 2016.05.24 BEVAS�j���{ �\���`���C������ь����@�\�ǉ� START
		//�s�v�ׁ̈A�R�����g��
//		private void listView����_DoubleClick(object sender, System.EventArgs e)
//		{
//			btn�X�V_Click(sender, e);
//		}
// MOD 2016.05.24 BEVAS�j���{ �\���`���C������ь����@�\�ǉ� END

// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� START
		private void ����ύX�Q_Closed(object sender, System.EventArgs e)
		{
			btn�X�V.Focus();
		}

// ADD 2005.05.24 ���s�j�����J �t�H�[�J�X�ړ� END
// MOD 2016.05.24 BEVAS�j���{ �\���`���C������ь����@�\�ǉ� START
		private void axGT����_CelDblClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelDblClickEvent e)
		{
			btn�X�V_Click(sender, null);
		}

		private void axGT����_CurPlaceChanged(object sender, AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEvent e)
		{
			axGT����.set_CelForeColor(nOldRow, 0, 0);
			axGT����.set_CelBackColor(nOldRow, 0, 0xFFFFFF);
			axGT����.set_CelForeColor(axGT����.CaretRow, 0, 0x98FB98);  //BGR
			axGT����.set_CelBackColor(axGT����.CaretRow, 0, 0x006000);
			nOldRow = axGT����.CaretRow;
		}

		private void axGT����_KeyDownEvent(object sender, AxGTABLE32V2Lib._DGTable32Events_KeyDownEvent e)
		{
			if(e.keyCode == 0x0d)
			{
				s����R�[�h = axGT����.get_CelText(axGT����.CaretRow, 1);
				s���喼 = axGT����.get_CelText(axGT����.CaretRow, 2);
				if(s����R�[�h != "")
				{
					this.Close();
				}
			}
			if(e.keyCode == 0x09)
			{
				this.SelectNextControl(axGT����, true, true, true, true);
			}
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			����ꗗ����();
		}

		private void tex���喼_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				����ꗗ����();
			}	
		}

		private void btn�O��_Click(object sender, System.EventArgs e)
		{
			i���ݕŐ�--;
			�ŏ��ݒ�();
			axGT����.CaretRow = 1;
			axGT����_CurPlaceChanged(null, null);
		}

		private void btn����_Click(object sender, System.EventArgs e)
		{
			i���ݕŐ�++;
			�ŏ��ݒ�();
			axGT����.CaretRow = 1;
			axGT����_CurPlaceChanged(null, null);
		}

		private void ����ꗗ����()
		{
			i�A�N�e�B�u�e�f = 1;
			axGT����.Clear();

			tex����R�[�h.Text = tex����R�[�h.Text.Trim();
			tex���喼.Text = tex���喼.Text.Trim();
			if(!���p�`�F�b�N(tex����R�[�h, "�Z�N�V�����R�[�h")) return;
			if(!�S�p�`�F�b�N(tex���喼, "�Z�N�V������")) return;

//			tex���b�Z�[�W.Text = "�������D�D�D";
			s����ꗗ = new string[1];

			// �J�[�\���������v�ɂ���
			Cursor = System.Windows.Forms.Cursors.AppStarting;

			try
			{
				string[] sKey  = new string[3];
				sKey[0] = gs����b�c;
				sKey[1] = tex����R�[�h.Text;
				sKey[2] = tex���喼.Text;

				if(sv_init == null) sv_init = new is2init.Service1();
				s����ꗗ = sv_init.Get_bumon2(gsa���[�U, sKey);
			}
			catch (System.Net.WebException)
			{
				s����ꗗ[0] = gs�ʐM�G���[;
			}
			catch (Exception ex)
			{
				s����ꗗ[0] = "�ʐM�G���[�F" + ex.Message;
			}

			//�J�[�\�����f�t�H���g�ɖ߂�
			Cursor = System.Windows.Forms.Cursors.Default;

			if(s����ꗗ[0].Equals("����I��"))
			{
//				tex���b�Z�[�W.Text = "";
				i�ő�Ő� = (s����ꗗ.Length - 2) / axGT����.Rows + 1;
				i�ő�Ő� = (s����ꗗ.Length - 2) / i�ōő�s�� + 1;
				if(i���ݕŐ� > i�ő�Ő�)
				{
					i���ݕŐ� = i�ő�Ő�;
				}
				�ŏ��ݒ�();
				axGT����.CaretRow = 1;
				axGT����_CurPlaceChanged(null, null);
				axGT����.Focus();
			}
			else
			{
				if(s����ꗗ[0].Equals("�Y���f�[�^������܂���"))
				{
//					tex���b�Z�[�W.Text = "";
					MessageBox.Show("�Y���f�[�^������܂���", "���匟��", MessageBoxButtons.OK);
				}
				else
				{
//					tex���b�Z�[�W.Text = s����ꗗ[0];
					MessageBox.Show(s����ꗗ[0], "���匟��", MessageBoxButtons.OK);
					axGT����.Clear();
					i���ݕŐ� = 1;
					btn�O��.Enabled = false;
					btn����.Enabled = false;
					lab�Ŕԍ�.Text = "";
					�r�[�v��();
				}
				tex����R�[�h.Focus();
			}
		}

		private void �ŏ��ݒ�()
		{
			axGT����.Clear();
			axGT����.Rows = 15;

//			i�J�n�� = (i���ݕŐ� - 1) * axGT����.Rows + 1;
//			i�I���� = i���ݕŐ� * axGT����.Rows;
			i�J�n�� = (i���ݕŐ� - 1) * i�ōő�s�� + 1;
			i�I���� = i���ݕŐ� * i�ōő�s��;

			short s�\���� = (short)1;
			for(short sCnt = (short)i�J�n��; sCnt < s����ꗗ.Length && sCnt <= i�I���� ; sCnt++)
			{
				if(s�\���� > 15)
				{
					axGT����.Rows++;
				}
				axGT����.set_RowsText(s�\����, s����ꗗ[sCnt]);
				s�\����++;
			}

			lab�Ŕԍ�.Text = i���ݕŐ�.ToString() + " / " + i�ő�Ő�.ToString();

			//btn�O��
			if(i���ݕŐ� == 1)
			{
				btn�O��.Enabled = false;
			}
			else
			{
				btn�O��.Enabled = true;
			}

			//btn����
			if(i���ݕŐ� == i�ő�Ő�)
			{
				btn����.Enabled = false;
			}
			else
			{
				btn����.Enabled = true;
			}

			axGT����.Focus();
		}

		private void ����ύX�Q_Activated(object sender, System.EventArgs e)
		{
			if(i�A�N�e�B�u�e�f == 0)
			{
				����ꗗ����();
			}
		}
// MOD 2016.05.24 BEVAS�j���{ �\���`���C������ь����@�\�ǉ� END
	}
}
