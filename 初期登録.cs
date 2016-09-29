using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace IS2Client
{
	/// <summary>
	/// [初期登録]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// MOD 2008.07.09 東都）高木 ＭＡＣアドレス取得の強化 
	// MOD 2008.07.16 東都）高木 ＭＡＣアドレスの簡易マスキング 
	//保留 MOD 2008.10.23 東都）高木 ＭＡＣアドレスの未取得時の設定変更 
	//--------------------------------------------------------------------------
	// MOD 2009.02.06 東都）高木 チェック時の項目名の修正 
	// ADD 2009.07.29 東都）高木 プロキシ対応 
	// 　ＩＥの[Secure]の設定からも取得する
	// 　プロキシをユーザが設定できるようにする
	// MOD 2009.07.30 東都）高木 exeのdll化対応 
	// MOD 2009.10.16 東都）高木 プロキシ機能表記の追加 
	//--------------------------------------------------------------------------
	// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 
	//--------------------------------------------------------------------------
	// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 
	// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応
	// MOD 2015.02.12 BEVAS）前田 ＴＥＣ製プリンタ(B-LV4)対応
	//--------------------------------------------------------------------------

	public class 初期登録 : 共通フォーム
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lab届け先登録タイトル;
		private System.Windows.Forms.TextBox texメッセージ;
		private 共通テキストボックス tex利用者ＣＤ;
		private System.Windows.Forms.Label labパスワード;
		private 共通テキストボックス texパスワード;
		private System.Windows.Forms.Label lab利用者ＣＤ;
		private System.Windows.Forms.Label lab会員ＣＤ;
		private 共通テキストボックス tex会員ＣＤ;
		private System.Windows.Forms.Label labプリンタ;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rBtn無し;
		private System.Windows.Forms.RadioButton rBtn有り;
		private System.Windows.Forms.ListBox listプリンタ;
		private System.Windows.Forms.Label lab発行種別;
		private System.Windows.Forms.Button btn登録;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label labバージョン;
		private System.ComponentModel.IContainer components = null;

		public 初期登録()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
			ＤＰＩ表示サイズ変換();
			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
//				this.listプリンタ.Size = new System.Drawing.Size(226, 34);
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 START
//				this.listプリンタ.Size = new System.Drawing.Size(226, (int)(34 * 1.5));
				this.listプリンタ.Size = new System.Drawing.Size(246, (int)(50 * 1.5));
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 END
			}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(初期登録));
			this.tex利用者ＣＤ = new IS2Client.共通テキストボックス();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labバージョン = new System.Windows.Forms.Label();
			this.labプリンタ = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rBtn無し = new System.Windows.Forms.RadioButton();
			this.rBtn有り = new System.Windows.Forms.RadioButton();
			this.listプリンタ = new System.Windows.Forms.ListBox();
			this.lab発行種別 = new System.Windows.Forms.Label();
			this.lab会員ＣＤ = new System.Windows.Forms.Label();
			this.tex会員ＣＤ = new IS2Client.共通テキストボックス();
			this.labパスワード = new System.Windows.Forms.Label();
			this.texパスワード = new IS2Client.共通テキストボックス();
			this.label1 = new System.Windows.Forms.Label();
			this.lab利用者ＣＤ = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab届け先登録タイトル = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.texメッセージ = new System.Windows.Forms.TextBox();
			this.btn登録 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).BeginInit();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tex利用者ＣＤ
			// 
			this.tex利用者ＣＤ.BackColor = System.Drawing.SystemColors.Window;
			this.tex利用者ＣＤ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex利用者ＣＤ.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex利用者ＣＤ.Location = new System.Drawing.Point(118, 32);
			this.tex利用者ＣＤ.MaxLength = 10;
			this.tex利用者ＣＤ.Name = "tex利用者ＣＤ";
			this.tex利用者ＣＤ.Size = new System.Drawing.Size(58, 23);
			this.tex利用者ＣＤ.TabIndex = 1;
			this.tex利用者ＣＤ.Text = "";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Honeydew;
			this.panel1.Controls.Add(this.labバージョン);
			this.panel1.Controls.Add(this.labプリンタ);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.listプリンタ);
			this.panel1.Controls.Add(this.lab発行種別);
			this.panel1.Controls.Add(this.lab会員ＣＤ);
			this.panel1.Controls.Add(this.tex会員ＣＤ);
			this.panel1.Controls.Add(this.labパスワード);
			this.panel1.Controls.Add(this.texパスワード);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.lab利用者ＣＤ);
			this.panel1.Controls.Add(this.tex利用者ＣＤ);
			this.panel1.Location = new System.Drawing.Point(0, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(370, 236);
			this.panel1.TabIndex = 0;
			// 
			// labバージョン
			// 
			this.labバージョン.BackColor = System.Drawing.Color.Honeydew;
			this.labバージョン.ForeColor = System.Drawing.Color.Black;
			this.labバージョン.Location = new System.Drawing.Point(304, 8);
			this.labバージョン.Name = "labバージョン";
			this.labバージョン.Size = new System.Drawing.Size(60, 12);
			this.labバージョン.TabIndex = 54;
			this.labバージョン.Text = "Ver.1.9";
			// 
			// labプリンタ
			// 
			this.labプリンタ.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labプリンタ.ForeColor = System.Drawing.Color.LimeGreen;
			this.labプリンタ.Location = new System.Drawing.Point(36, 86);
			this.labプリンタ.Name = "labプリンタ";
			this.labプリンタ.Size = new System.Drawing.Size(80, 14);
			this.labプリンタ.TabIndex = 52;
			this.labプリンタ.Text = "プリンタの有無";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rBtn無し);
			this.groupBox1.Controls.Add(this.rBtn有り);
			this.groupBox1.Location = new System.Drawing.Point(66, 88);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(272, 40);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// rBtn無し
			// 
			this.rBtn無し.Location = new System.Drawing.Point(106, 14);
			this.rBtn無し.Name = "rBtn無し";
			this.rBtn無し.Size = new System.Drawing.Size(58, 24);
			this.rBtn無し.TabIndex = 1;
			this.rBtn無し.Text = "無し";
			// 
			// rBtn有り
			// 
			this.rBtn有り.Checked = true;
			this.rBtn有り.Location = new System.Drawing.Point(26, 14);
			this.rBtn有り.Name = "rBtn有り";
			this.rBtn有り.Size = new System.Drawing.Size(58, 24);
			this.rBtn有り.TabIndex = 0;
			this.rBtn有り.TabStop = true;
			this.rBtn有り.Text = "有り";
			// 
			// listプリンタ
			// 
			this.listプリンタ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listプリンタ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.listプリンタ.ItemHeight = 16;
			this.listプリンタ.Items.AddRange(new object[] {
														  "ＺＥＢＲＡ製サーマルプリンタ（ＵＳＢ）",
														  "ＳＡＴＯ製サーマルプリンタ（ＵＳＢ）",
														  "東芝ＴＥＣ製サーマルプリンタ（ＵＳＢ）"});
			this.listプリンタ.Location = new System.Drawing.Point(90, 162);
			this.listプリンタ.Name = "listプリンタ";
			this.listプリンタ.Size = new System.Drawing.Size(246, 50);
			this.listプリンタ.TabIndex = 4;
			// 
			// lab発行種別
			// 
			this.lab発行種別.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab発行種別.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab発行種別.Location = new System.Drawing.Point(36, 142);
			this.lab発行種別.Name = "lab発行種別";
			this.lab発行種別.Size = new System.Drawing.Size(80, 14);
			this.lab発行種別.TabIndex = 51;
			this.lab発行種別.Text = "荷札発行種別";
			// 
			// lab会員ＣＤ
			// 
			this.lab会員ＣＤ.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab会員ＣＤ.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab会員ＣＤ.Location = new System.Drawing.Point(36, 10);
			this.lab会員ＣＤ.Name = "lab会員ＣＤ";
			this.lab会員ＣＤ.Size = new System.Drawing.Size(74, 14);
			this.lab会員ＣＤ.TabIndex = 0;
			this.lab会員ＣＤ.Text = "お客様コード";
			// 
			// tex会員ＣＤ
			// 
			this.tex会員ＣＤ.BackColor = System.Drawing.SystemColors.Window;
			this.tex会員ＣＤ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex会員ＣＤ.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex会員ＣＤ.Location = new System.Drawing.Point(118, 6);
			this.tex会員ＣＤ.MaxLength = 10;
			this.tex会員ＣＤ.Name = "tex会員ＣＤ";
			this.tex会員ＣＤ.Size = new System.Drawing.Size(106, 23);
			this.tex会員ＣＤ.TabIndex = 0;
			this.tex会員ＣＤ.Text = "";
			// 
			// labパスワード
			// 
			this.labパスワード.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labパスワード.ForeColor = System.Drawing.Color.LimeGreen;
			this.labパスワード.Location = new System.Drawing.Point(36, 62);
			this.labパスワード.Name = "labパスワード";
			this.labパスワード.Size = new System.Drawing.Size(74, 14);
			this.labパスワード.TabIndex = 48;
			this.labパスワード.Text = "パスワード";
			// 
			// texパスワード
			// 
			this.texパスワード.BackColor = System.Drawing.SystemColors.Window;
			this.texパスワード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texパスワード.Location = new System.Drawing.Point(118, 58);
			this.texパスワード.MaxLength = 25;
			this.texパスワード.Name = "texパスワード";
			this.texパスワード.PasswordChar = '*';
			this.texパスワード.Size = new System.Drawing.Size(246, 23);
			this.texパスワード.TabIndex = 2;
			this.texパスワード.Text = "";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 406);
			this.label1.TabIndex = 44;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab利用者ＣＤ
			// 
			this.lab利用者ＣＤ.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab利用者ＣＤ.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab利用者ＣＤ.Location = new System.Drawing.Point(36, 36);
			this.lab利用者ＣＤ.Name = "lab利用者ＣＤ";
			this.lab利用者ＣＤ.Size = new System.Drawing.Size(74, 14);
			this.lab利用者ＣＤ.TabIndex = 42;
			this.lab利用者ＣＤ.Text = "ユーザー";
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.lab届け先登録タイトル);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(792, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab届け先登録タイトル
			// 
			this.lab届け先登録タイトル.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab届け先登録タイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab届け先登録タイトル.ForeColor = System.Drawing.Color.White;
			this.lab届け先登録タイトル.Location = new System.Drawing.Point(12, 2);
			this.lab届け先登録タイトル.Name = "lab届け先登録タイトル";
			this.lab届け先登録タイトル.Size = new System.Drawing.Size(264, 24);
			this.lab届け先登録タイトル.TabIndex = 0;
			this.lab届け先登録タイトル.Text = "初期登録";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.texメッセージ);
			this.panel8.Controls.Add(this.btn登録);
			this.panel8.Location = new System.Drawing.Point(0, 266);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 2;
			// 
			// texメッセージ
			// 
			this.texメッセージ.BackColor = System.Drawing.Color.PaleGreen;
			this.texメッセージ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texメッセージ.ForeColor = System.Drawing.Color.Red;
			this.texメッセージ.Location = new System.Drawing.Point(66, 6);
			this.texメッセージ.Multiline = true;
			this.texメッセージ.Name = "texメッセージ";
			this.texメッセージ.ReadOnly = true;
			this.texメッセージ.Size = new System.Drawing.Size(306, 46);
			this.texメッセージ.TabIndex = 1;
			this.texメッセージ.TabStop = false;
			this.texメッセージ.Text = "";
			// 
			// btn登録
			// 
			this.btn登録.ForeColor = System.Drawing.Color.Blue;
			this.btn登録.Location = new System.Drawing.Point(8, 6);
			this.btn登録.Name = "btn登録";
			this.btn登録.Size = new System.Drawing.Size(54, 48);
			this.btn登録.TabIndex = 2;
			this.btn登録.Text = "登録";
			this.btn登録.Click += new System.EventHandler(this.btn登録_Click);
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
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel1);
			this.groupBox2.Location = new System.Drawing.Point(1, 22);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(373, 244);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			// 
			// 初期登録
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(374, 329);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.groupBox2);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(382, 356);
			this.Name = "初期登録";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "is-2 初期登録";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
			this.Load += new System.EventHandler(this.初期登録_Load);
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).EndInit();
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		private void btn登録_Click(object sender, System.EventArgs e)
		{
			// 空白除去
			tex会員ＣＤ.Text   = tex会員ＣＤ.Text.Trim();
			tex利用者ＣＤ.Text = tex利用者ＣＤ.Text.Trim();
			texパスワード.Text = texパスワード.Text.Trim();
// ADD 2009.07.29 東都）高木 プロキシ対応 START
			if(texパスワード.Text.Length == 0){
				if(tex利用者ＣＤ.Text.ToLower().Equals("p"))
				{
					// プロキシ初期設定ファイルのクリア
					StreamWriter swp = File.CreateText(gsInitProxy);
					swp.WriteLine("");
					swp.WriteLine("");
					swp.WriteLine("");
					swp.Close();

					gs端末ＣＤ   = "";
					gsaユーザ[2] = gs端末ＣＤ;

					this.Close();
					return;
				}
				if(tex利用者ＣＤ.Text.ToLower().Equals("pd"))
				{
					try{
						// プロキシ初期設定ファイルの削除
						System.IO.File.Delete(gsInitProxy);
					}catch(Exception){}

					gs端末ＣＤ   = "";
					gsaユーザ[2] = gs端末ＣＤ;

					this.Close();
					return;
				}
			}
// ADD 2009.07.29 東都）高木 プロキシ対応 END

			// 項目チェック
// MOD 2009.02.06 東都）高木 チェック時の項目名の修正 START
//			if(!必須チェック(tex会員ＣＤ,"会員ＣＤ")) return;
//			if(!必須チェック(tex利用者ＣＤ,"利用者ＣＤ")) return;
			if(!必須チェック(tex会員ＣＤ,"お客様コード")) return;
			if(!必須チェック(tex利用者ＣＤ,"ユーザー")) return;
			if(!必須チェック(texパスワード,"パスワード")) return;
//			if(!半角チェック(tex会員ＣＤ,"会員ＣＤ")) return;
//			if(!パスワードチェック(tex利用者ＣＤ,"利用者ＣＤ")) return;
			if(!半角チェック(tex会員ＣＤ,"お客様コード")) return;
			if(!パスワードチェック(tex利用者ＣＤ,"ユーザー")) return;
			if(!パスワードチェック(texパスワード,"パスワード")) return;
// MOD 2009.02.06 東都）高木 チェック時の項目名の修正 END


// DEL 2006.10.06 東都）山本 プリンタチェックをプリンタ番号設定後に行なうように変更 START
// MOD 2005.05.31 東都）小童谷 プリンタチェック START
//			if(rBtn有り.Checked)
//			{
//				try
//				{
//					プリンタチェック();
//				}
//				catch(Exception ex)
//				{
//					ビープ音();
//					MessageBox.Show(ex.Message, "プリンタチェック",
//						MessageBoxButtons.OK, MessageBoxIcon.Information);
//					return;
//				}
//			}
// MOD 2005.05.31 東都）小童谷 プリンタチェック START
// DEL 2006.10.06 東都）山本 プリンタチェックをプリンタ番号設定後に行なうように変更 END

			// データ作成
			String[] sKey = new string[8];
			sKey[0] = tex会員ＣＤ.Text;
			sKey[1] = tex利用者ＣＤ.Text;
			sKey[2] = texパスワード.Text;
			// プリンタの有無
			if(rBtn有り.Checked)
				sKey[3] = "1";
			else
				sKey[3] = "0";
			// プリンタのフォーマットの種類
			switch(listプリンタ.SelectedIndex)
			{
//// MOD 2006.09.27 東都）山本 ＴＥＣ製プリンタ対応 START
//					/*
//									case 0:	// レーザープリンタ
//										sKey[4] = "L0001  ";
//										break;
//
//									case 1:	// サーマルプリンタ（ＵＳＢ）
//										sKey[4] = "S0001  ";
//										break;
//
//									default:
//										sKey[4] = "S0001  ";
//										break;
//					*/
				case 1:		// ＳＡＴＯ製サーマルプリンタ（ＵＳＢ）
					sKey[4] = "S0002";
					break;
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 START
				case 2:		// ＴＥＣ製サーマルプリンタ（ＵＳＢ）
					sKey[4] = "S0007";
					break;
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 END
				default:	// ＺＥＢＲＡ製サーマルプリンタ（ＵＳＢ）
					sKey[4] = "S0001";
					break;
// MOD 2006.09.27 東都）山本 ＴＥＣ製プリンタ対応 END
			}

// ADD 2006.10.06 東都）山本 プリンタチェックをプリンタ番号設定後に行なうように変更 START
			if(rBtn有り.Checked)
			{
				try
				{
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 START
//					プリンタチェック(sKey[4]);
					sKey[4] = プリンタチェック(sKey[4]);
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 END
				}
				catch(Exception ex)
				{
					ビープ音();
					MessageBox.Show(ex.Message, "プリンタチェック",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
// ADD 2006.10.06 東都）山本 プリンタチェックをプリンタ番号設定後に行なうように変更 END

			// コンピュータ名
			try
			{
				sKey[5] = System.Environment.MachineName;
				// ＩＰアドレス
				try
				{
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 START
					//System.Net.IPHostEntry iph = System.Net.Dns.GetHostByName(sKey[5]);
                    System.Net.IPHostEntry iph = System.Net.Dns.GetHostEntry(sKey[5]);
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 END

// MOD 2008.07.09 東都）高木 ＭＡＣアドレス取得の強化 START
//					sKey[6] = iph.AddressList[0].ToString();
					sKey[6] = "";
					sKey[7] = "";
					for(uint uiCnt = 0; uiCnt < iph.AddressList.Length; uiCnt++){
//保留 MOD 2008.10.23 東都）高木 ＭＡＣアドレスの未取得時の設定変更 START
//						sKey[6] = "";
//						sKey[7] = "";
//保留 MOD 2008.10.23 東都）高木 ＭＡＣアドレスの未取得時の設定変更 END
						sKey[6] = iph.AddressList[uiCnt].ToString();
						// ＭＡＣアドレスの取得
						sKey[7] = GetMacAddress(sKey[6]);
//保留 MOD 2008.10.23 東都）高木 ＭＡＣアドレスの未取得時の設定変更 START
						if(sKey[6].Trim().Length > 0 && sKey[7].Trim().Length > 0) break;
//						if(sKey[6].Trim().Length > 0 && sKey[7].Trim().Length > 1) break;
//保留 MOD 2008.10.23 東都）高木 ＭＡＣアドレスの未取得時の設定変更 END
					}
// MOD 2008.07.09 東都）高木 ＭＡＣアドレス取得の強化 END
				}
				catch(Exception)
				{
					sKey[6] = "";
// ADD 2008.07.09 東都）高木 ＭＡＣアドレス取得の強化 START
					sKey[7] = "";
// ADD 2008.07.09 東都）高木 ＭＡＣアドレス取得の強化 END
				}
// DEL 2008.07.09 東都）高木 ＭＡＣアドレス取得の強化 START
//				// ＭＡＣアドレスの取得
//// MOD 2005.06.29 東都）高木 ＭＡＣアドレスの取得 START
////				sKey[7] = "-";
//				sKey[7] = GetMacAddress(sKey[6]);
//// MOD 2005.06.29 東都）高木 ＭＡＣアドレスの取得 END
// DEL 2008.07.09 東都）高木 ＭＡＣアドレス取得の強化 END
			}
			catch(Exception)
			{
				sKey[5] = "";
				sKey[6] = "";
				sKey[7] = "";
			}

			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sRet = {""};
			try
			{
				// 端末ＩＤ取得
				// 引数：会員ＣＤ、利用者ＣＤ、パスワード、サーマルプリンタ有無、プリンタ種類、
				//       コンピュータ名、ＩＰアドレス、ＭＡＣアドレス
				texメッセージ.Text = "初期登録中．．．";
				if(sv_init == null) sv_init = new is2init.Service1();
				sRet = sv_init.Set_tanmatsu(gsaユーザ,sKey);
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				sRet[0] = gs通信エラー;
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				sRet[0] = "通信エラー：" + ex.Message;
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;

			if(sRet.Length > 1 && sRet[1] == null)
			{
				if(sRet[6] == null || int.Parse(sRet[6]) < 10)
				{
					texメッセージ.Text = "入力された内容は間違っているか、サーバで準備ができていません。"
						+ "入力内容を確認して再度実行してください。";
					MessageBox.Show("入力された内容は間違っているか、サーバで準備ができていません。\r\n入力内容を確認して再度実行してください。", 
						"認証エラー", 
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					// 会員ＣＤにフォーカス
					tex会員ＣＤ.Focus();
					return;
				}
				else
				{
					//					texメッセージ.Text = "インストールが正常に行われていないか、プログラムが破損している可能性があります。"
					//									   + "アンインストール後、再度インストールを行ってください。";
					//					MessageBox.Show("インストールが正常に行われていないか、プログラムが破損している可能性があります。\r\nアンインストール後、再度インストールを行ってください。", 
					//									"認証エラー", 
					//									MessageBoxButtons.OK, MessageBoxIcon.Error);
					texメッセージ.Text = "認証エラー：最寄の営業所まで御連絡下さい。";
					MessageBox.Show("最寄の営業所まで御連絡下さい。", 
						"認証エラー", 
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					// 画面を閉じる
					this.Close();
					return;
				}
			}

			if(sRet[0].Length != 4)
			{
				texメッセージ.Text = sRet[0];
				return;
			}

			texメッセージ.Text = "";

// ADD 2008.06.30 東都）高木 パスワードチェックの強化 START
			if(sRet[0].Equals("正常終了")){
				;
			}else if(sRet[0].Equals("期限切れ")){
				MessageBox.Show("パスワードの有効期限が切れました。\n"
								+ "パスワードの変更をお願い致します。"
								, "ログイン", 
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				gs会員ＣＤ   = tex会員ＣＤ.Text;
				gs利用者ＣＤ = tex利用者ＣＤ.Text;
				パスワード変更 パス変更 = new パスワード変更();
				パス変更.sモード = sRet[0];
				パス変更.Left = this.Left;
				パス変更.Top  = this.Top;
				this.Visible = false;
				パス変更.ShowDialog(this);
				this.Visible = true;
				if(!パス変更.s結果.Equals("更新")){
					gs利用者ＣＤ = "";
					gs利用者名   = "";
					パス変更 = null;
					// 画面を閉じる
					this.Close();
					return;
				}
				パス変更 = null;
			}else{
				MessageBox.Show("パスワードの有効期限は "
								+ sRet[0].Substring(0,2) + "/"
								+ sRet[0].Substring(2)
								+ " までです。\n"
								+ "パスワードの変更をお願い致します。"
								, "ログイン", 
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				gs会員ＣＤ   = tex会員ＣＤ.Text;
				gs利用者ＣＤ = tex利用者ＣＤ.Text;
				パスワード変更 パス変更 = new パスワード変更();
				パス変更.sモード = "パス変更";
				パス変更.Left = this.Left;
				パス変更.Top  = this.Top;
				this.Visible = false;
				パス変更.ShowDialog(this);
				this.Visible = true;
				パス変更 = null;
			}
// ADD 2008.06.30 東都）高木 パスワードチェックの強化 END

			// 初期設定ファイル作成
			StreamWriter sw = File.CreateText(gsInitFile);
// MOD 2005.05.17 東都）高木 起動時間を短くする START
			//			sw.WriteLine(tex会員ＣＤ.Text);
			//			sw.WriteLine(tex利用者ＣＤ.Text);
			sw.WriteLine("");
			sw.WriteLine("");
// MOD 2005.05.17 東都）高木 起動時間を短くする END
			if(sRet[1] != null)
			{
				sw.WriteLine(sRet[1]);	// 端末ＣＤ
// MOD 2005.05.17 東都）高木 起動時間を短くする START
//				sw.WriteLine(sRet[2]);	// 会員名
//				sw.WriteLine(sRet[3]);	// 利用者名
//				sw.WriteLine(sRet[4]);	// 部門ＣＤ
//				sw.WriteLine(sRet[5]);	// 部門名

				gs会員ＣＤ   = tex会員ＣＤ.Text;
				gs利用者ＣＤ = tex利用者ＣＤ.Text;
				gs会員名     = sRet[2];
				gs利用者名   = sRet[3];
				gsプリンタＦＧ = sKey[3];
				gsプリンタ種類 = sKey[4];
// MOD 2005.05.17 東都）高木 起動時間を短くする END

				// メッセージを設定
				//				gsメッセージ += sRet[7];	// メッセージ
			}
			sw.Close();

			// 画面を閉じる
			this.Close();
		}

		private void 初期登録_Load(object sender, System.EventArgs e)
		{
// ADD 2008.03.13 東都）高木 バージョン情報の表示 START
			if(gsaユーザ[3].Length == 0)
			{
				int iPos = 0;
				//１個目のピリオド
				iPos = Application.ProductVersion.IndexOf('.');
				if(iPos >= 0)
				{
					//２個目のピリオド
					iPos = Application.ProductVersion.IndexOf('.',iPos+1);
					if(iPos >= 0)
					{
						gsaユーザ[3] = Application.ProductVersion.Substring(0,iPos);
					}
				}
// MOD 2009.07.30 東都）高木 exeのdll化対応 START
				if(System.IO.File.Exists("IS2Client.dll")){
					System.Diagnostics.FileVersionInfo myFileVersionInfo 
						= System.Diagnostics.FileVersionInfo.GetVersionInfo("IS2Client.dll");
					iPos = 0;
					//１個目のピリオド
					iPos = myFileVersionInfo.FileVersion.IndexOf('.');
					if(iPos >= 0)
					{
						//２個目のピリオド
						iPos = myFileVersionInfo.FileVersion.IndexOf('.',iPos+1);
						if(iPos >= 0)
						{
							gsaユーザ[3] = myFileVersionInfo.FileVersion.Substring(0,iPos);
						}
					}
				}
// MOD 2009.07.30 東都）高木 exeのdll化対応 END
			}
			if(gsaユーザ[3].Length > 0) labバージョン.Text = "Ver." + gsaユーザ[3];
// ADD 2008.03.13 東都）高木 バージョン情報の表示 END
// MOD 2009.10.16 東都）高木 プロキシ機能表記の追加 START
			if(gbInitProxyExists) labバージョン.Text += " p";
// MOD 2009.10.16 東都）高木 プロキシ機能表記の追加 END
// ADD 2006.10.10 東都）高木 ＳＡＴＯ製プリンタ障害対応 START
			string sプリンタ種類 = "";
// ADD 2006.10.10 東都）高木 ＳＡＴＯ製プリンタ障害対応 END
// MOD 2005.05.31 東都）小童谷 プリンタチェック START
			rBtn有り.Checked = true;
			try
			{
// MOD 2006.10.10 東都）高木 ＳＡＴＯ製プリンタ障害対応 START
//				プリンタチェック();
				sプリンタ種類 = 初期登録前プリンタチェック();
// MOD 2006.10.10 東都）高木 ＳＡＴＯ製プリンタ障害対応 END
			}
			catch
			{
				rBtn無し.Checked = true;
			}
// MOD 2005.05.31 東都）小童谷 プリンタチェック START

			// 一覧の初期設定
// MOD 2006.10.10 東都）高木 ＳＡＴＯ製プリンタ障害対応 START
//			listプリンタ.SelectedIndex = 0;
			listプリンタ.SelectedIndex = 1;
			if(sプリンタ種類 == "S0001")
			{
				listプリンタ.SelectedIndex = 0;
			}
			else if(sプリンタ種類 == "S0002")
			{
				listプリンタ.SelectedIndex = 1;
			}
// MOD 2006.10.10 東都）高木 ＳＡＴＯ製プリンタ障害対応 END
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 START
			else if(sプリンタ種類 == "S0005")
			{
				listプリンタ.SelectedIndex = 1;
			}
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 END
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 START
			else if(sプリンタ種類 == "S0006")
			{
				listプリンタ.SelectedIndex = 1;
			}
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 END
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 START
			else if(sプリンタ種類 == "S0007")
			{
				listプリンタ.SelectedIndex = 2;
			}
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 END
// MOD 2015.02.12 BEVAS）前田 ＴＥＣ製プリンタ(B-LV4)対応 START
			else if(sプリンタ種類 == "S0008")
			{
				listプリンタ.SelectedIndex = 2;
			}
// MOD 2015.02.12 BEVAS）前田 ＴＥＣ製プリンタ(B-LV4)対応 END
		}

// ADD 2005.06.29 東都）高木 ＭＡＣアドレスの取得 START
		[System.Runtime.InteropServices.DllImport("IPHLPAPI.dll")] 
		private static extern uint GetAdaptersInfo(byte[] by1, out uint ui2);

		private const uint ERROR_SUCCESS = 0;
		private const uint ERROR_BUFFER_OVERFLOW = 111;
		private const uint IP_ADAPTER_INFO_LENGTH = 640;

		/*
		 * ＭＡＣアドレスを取得する
		 */
		private string GetMacAddress(string sSelIP)
		{
			string sRet = "-";

			if(sSelIP.Length == 0) return sRet;

			try
			{
				// 必要なデータ領域サイズの取得
				byte[] bBuff = null;
				uint uiLen = 0;
				uint uiRet = GetAdaptersInfo(bBuff, out uiLen);
				if(uiRet == ERROR_BUFFER_OVERFLOW)
				{
					// インターフェース情報の取得
					bBuff = new byte[uiLen];
					uiRet = GetAdaptersInfo(bBuff, out uiLen);
					if(uiRet == ERROR_SUCCESS)	//	成功時
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
							
							// ＭＡＣアドレスを取得
							uiPos = uiBase + 404;
							sMac = "";
							for(uint uiCnt = 0; uiCnt < uiMacLen; uiCnt++)
							{
// MOD 2008.07.16 東都）高木 ＭＡＣアドレスの簡易マスキング START
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
// MOD 2008.07.16 東都）高木 ＭＡＣアドレスの簡易マスキング END
								sMac += bBuff[uiPos++].ToString("X2");
							}
//							Console.WriteLine(sMac);

							// ＩＰアドレスを取得
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
		 * バイト配列からuint型としてデータを取得する
		 */
		private uint ByteToUint(byte[] byData, uint uiPos)
		{
			// 桁数チェック
			if(byData.Length - uiPos < 4) return 0;

// MOD 2005.07.01 東都）高木 変換処理の最適化 END
//			uint uiData = 0;
//			uiData  = (uint)byData[uiPos + 3]; uiData <<= 8;
//			uiData += (uint)byData[uiPos + 2]; uiData <<= 8;
//			uiData += (uint)byData[uiPos + 1]; uiData <<= 8;
//			uiData += (uint)byData[uiPos];
//			return uiData;
			unsafe
			{
				fixed (byte* pbyData = &byData[uiPos])
				{
					return *((uint*)pbyData);
				}
			}
// MOD 2005.07.01 東都）高木 変換処理の最適化 END
		}
// ADD 2005.06.29 東都）高木 ＭＡＣアドレスの取得 END

	}
}
