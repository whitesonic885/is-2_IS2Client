using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// Form1 の概要の説明です。
	/// </summary>
	public class 指定時間入力 : 共通フォーム
	{
		public string s記事;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn更新;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lab指定時間;
		public System.Windows.Forms.Label lab時間区分;
		private System.Windows.Forms.Label lab指定時間入力タイトル;
		public System.Windows.Forms.ComboBox cmb指定時間;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public 指定時間入力()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
			ＤＰＩ表示サイズ変換();
// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 END
		}

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
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

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.cmb指定時間 = new System.Windows.Forms.ComboBox();
			this.lab時間区分 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lab指定時間 = new System.Windows.Forms.Label();
			this.btn更新 = new System.Windows.Forms.Button();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab指定時間入力タイトル = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1.SuspendLayout();
			this.panel7.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Honeydew;
			this.panel1.Controls.Add(this.cmb指定時間);
			this.panel1.Controls.Add(this.lab時間区分);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.lab指定時間);
			this.panel1.Controls.Add(this.btn更新);
			this.panel1.Controls.Add(this.btn閉じる);
			this.panel1.Location = new System.Drawing.Point(1, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(361, 142);
			this.panel1.TabIndex = 0;
			// 
			// cmb指定時間
			// 
			this.cmb指定時間.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb指定時間.Font = new System.Drawing.Font("MS UI Gothic", 12F);
			this.cmb指定時間.Location = new System.Drawing.Point(146, 26);
			this.cmb指定時間.Name = "cmb指定時間";
			this.cmb指定時間.Size = new System.Drawing.Size(52, 24);
			this.cmb指定時間.TabIndex = 1;
			// 
			// lab時間区分
			// 
			this.lab時間区分.Font = new System.Drawing.Font("MS UI Gothic", 12F);
			this.lab時間区分.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab時間区分.Location = new System.Drawing.Point(204, 30);
			this.lab時間区分.Name = "lab時間区分";
			this.lab時間区分.Size = new System.Drawing.Size(76, 18);
			this.lab時間区分.TabIndex = 46;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 144);
			this.label1.TabIndex = 44;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab指定時間
			// 
			this.lab指定時間.Font = new System.Drawing.Font("MS UI Gothic", 12F);
			this.lab指定時間.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab指定時間.Location = new System.Drawing.Point(66, 30);
			this.lab指定時間.Name = "lab指定時間";
			this.lab指定時間.Size = new System.Drawing.Size(76, 18);
			this.lab指定時間.TabIndex = 42;
			this.lab指定時間.Text = "指定時間";
			// 
			// btn更新
			// 
			this.btn更新.BackColor = System.Drawing.Color.PaleGreen;
			this.btn更新.ForeColor = System.Drawing.Color.Blue;
			this.btn更新.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn更新.Location = new System.Drawing.Point(240, 70);
			this.btn更新.Name = "btn更新";
			this.btn更新.Size = new System.Drawing.Size(54, 48);
			this.btn更新.TabIndex = 2;
			this.btn更新.Text = "確定";
			this.btn更新.Click += new System.EventHandler(this.btn更新_Click);
			// 
			// btn閉じる
			// 
			this.btn閉じる.BackColor = System.Drawing.Color.PaleGreen;
			this.btn閉じる.ForeColor = System.Drawing.Color.Red;
			this.btn閉じる.Location = new System.Drawing.Point(66, 70);
			this.btn閉じる.Name = "btn閉じる";
			this.btn閉じる.Size = new System.Drawing.Size(54, 48);
			this.btn閉じる.TabIndex = 3;
			this.btn閉じる.TabStop = false;
			this.btn閉じる.Text = "閉じる";
			this.btn閉じる.Click += new System.EventHandler(this.btn閉じる_Click);
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.lab指定時間入力タイトル);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(364, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab指定時間入力タイトル
			// 
			this.lab指定時間入力タイトル.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab指定時間入力タイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab指定時間入力タイトル.ForeColor = System.Drawing.Color.White;
			this.lab指定時間入力タイトル.Location = new System.Drawing.Point(12, 2);
			this.lab指定時間入力タイトル.Name = "lab指定時間入力タイトル";
			this.lab指定時間入力タイトル.Size = new System.Drawing.Size(264, 24);
			this.lab指定時間入力タイトル.TabIndex = 0;
			this.lab指定時間入力タイトル.Text = "指定時間入力";
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
			// 指定時間入力
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
			this.Name = "指定時間入力";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 指定時間入力";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
			this.Load += new System.EventHandler(this.指定時間入力_Load);
			this.Closed += new System.EventHandler(this.指定時間入力_Closed);
			this.panel1.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		private void 指定時間入力_Load(object sender, System.EventArgs e)
		{
		
		}

		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
			s記事 = "";
			this.Close();
		}

		private void btn更新_Click(object sender, System.EventArgs e)
		{
// MOD 2005.06.10 東都）伊賀　時間指定方法変更 START
//			s記事 = "時間指定" + Microsoft.VisualBasic.Strings.StrConv(nUD指定時間.Value.ToString(), Microsoft.VisualBasic.VbStrConv.Wide, 0) + lab時間区分.Text;
			s記事 = "時間指定" + cmb指定時間.SelectedItem.ToString() + lab時間区分.Text;
// MOD 2005.06.10 東都）伊賀　時間指定方法変更 END
			this.Close();
		}

		private void 指定時間入力_Closed(object sender, System.EventArgs e)
		{
// MOD 2005.06.10 東都）伊賀　時間指定方法変更 START
			//nUD指定時間.Focus();
			cmb指定時間.Focus();
// MOD 2005.06.10 東都）伊賀　時間指定方法変更 END
		}
	}
}
