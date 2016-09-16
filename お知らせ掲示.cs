// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Text;

namespace IS2Client
{
	/// <summary>
	/// お知らせ表示フォームの概要の説明です。
	/// </summary>
	public class お知らせ表示 : 共通フォーム
	{
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;		
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab日時;
		private System.Windows.Forms.Label labお客様名;
		private System.Windows.Forms.Label lab利用部門;
		private System.Windows.Forms.TextBox texお客様名;
		private System.Windows.Forms.TextBox tex利用部門;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tex詳細内容;
		private System.Windows.Forms.Label labお知らせ表示;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tex登録日;
		private System.Windows.Forms.TextBox tex表題;
		private System.Windows.Forms.Label label3;
		private System.ComponentModel.IContainer components;

		// 登録日
		private string _s登録日 = string.Empty;
		/// <summary>
		/// お知らせの登録日を設定します。
		/// </summary>
		public string s登録日 
		{
			set { _s登録日 = (value == null) ? string.Empty : value; }
		}
		// 表題
		private string _s表題 = string.Empty;
		private System.Windows.Forms.Button btn詳細;
		/// <summary>
		/// お知らせの表題を設定します。
		/// </summary>
		public string s表題 
		{
			set { _s表題 = (value == null) ? string.Empty : value; }
		}
		// 詳細内容
		private string _s詳細内容 = string.Empty;
		/// <summary>
		/// お知らせの詳細内容を設定します。
		/// </summary>
		public string s詳細内容 
		{
			set { _s詳細内容 = (value == null) ? string.Empty : value; }
		}
		// ボタン名
		private string _sボタン名 = string.Empty;
		/// <summary>
		/// 詳細を表示するボタンのラベルを設定します。
		/// </summary>
		public string sボタン名 
		{
			set { _sボタン名 = (value == null) ? string.Empty : value; }
		}
		// アドレス
		private string _sアドレス = string.Empty;
		/// <summary>
		/// 詳細データのアドレス（URL）を設定します。
		/// </summary>
		public string sアドレス 
		{
			set { _sアドレス = (value == null) ? string.Empty : value; }
		}

		public お知らせ表示()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(お知らせ表示));
			this.panel6 = new System.Windows.Forms.Panel();
			this.texお客様名 = new System.Windows.Forms.TextBox();
			this.labお客様名 = new System.Windows.Forms.Label();
			this.lab利用部門 = new System.Windows.Forms.Label();
			this.tex利用部門 = new System.Windows.Forms.TextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab日時 = new System.Windows.Forms.Label();
			this.labお知らせ表示 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.texメッセージ = new System.Windows.Forms.TextBox();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btn詳細 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.tex表題 = new System.Windows.Forms.TextBox();
			this.tex登録日 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tex詳細内容 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.PaleGreen;
			this.panel6.Controls.Add(this.texお客様名);
			this.panel6.Controls.Add(this.labお客様名);
			this.panel6.Controls.Add(this.lab利用部門);
			this.panel6.Controls.Add(this.tex利用部門);
			this.panel6.Location = new System.Drawing.Point(0, 26);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(810, 26);
			this.panel6.TabIndex = 12;
			// 
			// texお客様名
			// 
			this.texお客様名.BackColor = System.Drawing.Color.PaleGreen;
			this.texお客様名.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.texお客様名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texお客様名.ForeColor = System.Drawing.Color.LimeGreen;
			this.texお客様名.Location = new System.Drawing.Point(624, 6);
			this.texお客様名.Name = "texお客様名";
			this.texお客様名.ReadOnly = true;
			this.texお客様名.Size = new System.Drawing.Size(162, 16);
			this.texお客様名.TabIndex = 12;
			this.texお客様名.TabStop = false;
			this.texお客様名.Text = "○×商事＿＿＿＿＿■";
			this.texお客様名.Visible = false;
			// 
			// labお客様名
			// 
			this.labお客様名.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labお客様名.ForeColor = System.Drawing.Color.LimeGreen;
			this.labお客様名.Location = new System.Drawing.Point(566, 8);
			this.labお客様名.Name = "labお客様名";
			this.labお客様名.Size = new System.Drawing.Size(52, 14);
			this.labお客様名.TabIndex = 11;
			this.labお客様名.Text = "ユーザー";
			this.labお客様名.Visible = false;
			// 
			// lab利用部門
			// 
			this.lab利用部門.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab利用部門.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab利用部門.Location = new System.Drawing.Point(18, 8);
			this.lab利用部門.Name = "lab利用部門";
			this.lab利用部門.Size = new System.Drawing.Size(54, 14);
			this.lab利用部門.TabIndex = 10;
			this.lab利用部門.Text = "セクション";
			// 
			// tex利用部門
			// 
			this.tex利用部門.BackColor = System.Drawing.Color.PaleGreen;
			this.tex利用部門.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex利用部門.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex利用部門.ForeColor = System.Drawing.Color.LimeGreen;
			this.tex利用部門.Location = new System.Drawing.Point(78, 6);
			this.tex利用部門.Name = "tex利用部門";
			this.tex利用部門.ReadOnly = true;
			this.tex利用部門.Size = new System.Drawing.Size(474, 16);
			this.tex利用部門.TabIndex = 8;
			this.tex利用部門.TabStop = false;
			this.tex利用部門.Text = "1234 本社＿＿＿＿＿＿＿■";
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.lab日時);
			this.panel7.Controls.Add(this.labお知らせ表示);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(792, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab日時
			// 
			this.lab日時.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab日時.ForeColor = System.Drawing.Color.White;
			this.lab日時.Location = new System.Drawing.Point(674, 8);
			this.lab日時.Name = "lab日時";
			this.lab日時.Size = new System.Drawing.Size(112, 14);
			this.lab日時.TabIndex = 1;
			this.lab日時.Text = "2005/xx/xx 12:00:00";
			// 
			// labお知らせ表示
			// 
			this.labお知らせ表示.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.labお知らせ表示.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labお知らせ表示.ForeColor = System.Drawing.Color.White;
			this.labお知らせ表示.Location = new System.Drawing.Point(12, 2);
			this.labお知らせ表示.Name = "labお知らせ表示";
			this.labお知らせ表示.Size = new System.Drawing.Size(264, 24);
			this.labお知らせ表示.TabIndex = 0;
			this.labお知らせ表示.Text = "お知らせ表示";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.texメッセージ);
			this.panel8.Controls.Add(this.btn閉じる);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 14;
			// 
			// texメッセージ
			// 
			this.texメッセージ.BackColor = System.Drawing.Color.PaleGreen;
			this.texメッセージ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texメッセージ.ForeColor = System.Drawing.Color.Red;
			this.texメッセージ.Location = new System.Drawing.Point(456, 4);
			this.texメッセージ.Multiline = true;
			this.texメッセージ.Name = "texメッセージ";
			this.texメッセージ.ReadOnly = true;
			this.texメッセージ.Size = new System.Drawing.Size(334, 50);
			this.texメッセージ.TabIndex = 1;
			this.texメッセージ.TabStop = false;
			this.texメッセージ.Text = "";
			// 
			// btn閉じる
			// 
			this.btn閉じる.ForeColor = System.Drawing.Color.Red;
			this.btn閉じる.Location = new System.Drawing.Point(8, 6);
			this.btn閉じる.Name = "btn閉じる";
			this.btn閉じる.Size = new System.Drawing.Size(54, 48);
			this.btn閉じる.TabIndex = 1;
			this.btn閉じる.Text = "閉じる";
			this.btn閉じる.Click += new System.EventHandler(this.btn閉じる_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btn詳細);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.tex表題);
			this.groupBox2.Controls.Add(this.tex登録日);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.tex詳細内容);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(10, 64);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(770, 440);
			this.groupBox2.TabIndex = 17;
			this.groupBox2.TabStop = false;
			// 
			// btn詳細
			// 
			this.btn詳細.BackColor = System.Drawing.Color.SteelBlue;
			this.btn詳細.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn詳細.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn詳細.ForeColor = System.Drawing.Color.White;
			this.btn詳細.Location = new System.Drawing.Point(704, 24);
			this.btn詳細.Name = "btn詳細";
			this.btn詳細.Size = new System.Drawing.Size(48, 22);
			this.btn詳細.TabIndex = 47;
			this.btn詳細.TabStop = false;
			this.btn詳細.Text = "詳細";
			this.btn詳細.Click += new System.EventHandler(this.btn詳細_Click);
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.White;
			this.label3.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(48, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(8, 312);
			this.label3.TabIndex = 46;
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tex表題
			// 
			this.tex表題.BackColor = System.Drawing.Color.Honeydew;
			this.tex表題.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex表題.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex表題.ForeColor = System.Drawing.Color.LimeGreen;
			this.tex表題.Location = new System.Drawing.Point(48, 56);
			this.tex表題.Name = "tex表題";
			this.tex表題.ReadOnly = true;
			this.tex表題.Size = new System.Drawing.Size(712, 22);
			this.tex表題.TabIndex = 0;
			this.tex表題.TabStop = false;
			this.tex表題.Text = "表題";
			// 
			// tex登録日
			// 
			this.tex登録日.BackColor = System.Drawing.Color.Honeydew;
			this.tex登録日.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex登録日.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex登録日.ForeColor = System.Drawing.Color.LimeGreen;
			this.tex登録日.Location = new System.Drawing.Point(48, 24);
			this.tex登録日.Name = "tex登録日";
			this.tex登録日.ReadOnly = true;
			this.tex登録日.Size = new System.Drawing.Size(136, 22);
			this.tex登録日.TabIndex = 0;
			this.tex登録日.TabStop = false;
			this.tex登録日.Text = "登録日";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Lime;
			this.label2.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(48, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(672, 16);
			this.label2.TabIndex = 45;
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tex詳細内容
			// 
			this.tex詳細内容.BackColor = System.Drawing.SystemColors.Window;
			this.tex詳細内容.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex詳細内容.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex詳細内容.Location = new System.Drawing.Point(56, 96);
			this.tex詳細内容.MaxLength = 2000;
			this.tex詳細内容.Multiline = true;
			this.tex詳細内容.Name = "tex詳細内容";
			this.tex詳細内容.ReadOnly = true;
			this.tex詳細内容.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tex詳細内容.Size = new System.Drawing.Size(664, 310);
			this.tex詳細内容.TabIndex = 0;
			this.tex詳細内容.TabStop = false;
			this.tex詳細内容.Text = @"国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王国国国国国王王王王王";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 434);
			this.label1.TabIndex = 44;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// お知らせ表示
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 574);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "お知らせ表示";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 お知らせ表示";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
			this.Load += new System.EventHandler(this.お知らせ表示_Load);
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void お知らせ表示_Load(object sender, System.EventArgs e)
		{
			// ヘッダー項目の設定
			texお客様名.Text = gs利用者名;
			tex利用部門.Text = gs部門ＣＤ + " " + gs部門名;

			// 日時の初期設定
			lab日時.Text		= DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled	= true;

			// お知らせ表示
			tex登録日.Text	= _s登録日;
			tex表題.Text		= _s表題;
			tex詳細内容.Text	= _s詳細内容;

			// 詳細ボタンの設定
			if (_sアドレス != string.Empty) 
			{
				// アドレスが登録されている
				// ボタンのラベル設定
				if (_sボタン名 == string.Empty) 
					_sボタン名 = "詳細";
				btn詳細.Text = _sボタン名;
				// ボタンのサイズ・表示位置調整
				int len = _sボタン名.Length;
				if (len > 2) 
				{
					// 大きさ可変長
					int diff = (len - 2)*12;
					btn詳細.Size = new Size(48 + diff, 22);
					btn詳細.Location = new Point(704 - diff, 24);
				} 
				else 
				{
					// デフォルトの大きさ・位置
					btn詳細.Size = new Size(48, 22);
					btn詳細.Location = new Point(704, 24);
				}
				// ボタン表示
				btn詳細.Visible = true;
			} 
			else 
			{
				// アドレスが登録されていない
				// ボタン非表示
				btn詳細.Visible = false;
			}
		}

		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
			// 設定内容クリア
			_s登録日		= string.Empty;
			_s表題		= string.Empty;
			_s詳細内容	= string.Empty;

			// このフォームを閉じる	
			this.Close();
		}

		private void btn詳細_Click(object sender, System.EventArgs e)
		{
			// 登録されている詳細ファイルを IE で開く
			System.Diagnostics.Process.Start("iexplore.exe", _sアドレス);
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			// 日付／時間表示
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}
	}
}
// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
