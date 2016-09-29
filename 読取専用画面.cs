using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [読取専用画面]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// MOD 2015.07.13 TDI）綱澤 画面追加 
	//--------------------------------------------------------------------------

	public class 読取専用画面 : 共通フォーム
	{
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.Label lab読取専用画面タイトル;
		private System.Windows.Forms.TextBox tex送り状番号入力;
		private System.Windows.Forms.Label lab送り状番号;
		private System.Windows.Forms.Button btn照会;
		private System.ComponentModel.IContainer components = null;

		private string[] s出荷一覧;

		public 読取専用画面()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			ＤＰＩ表示サイズ変換();
			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
//				this.listプリンタ.Size = new System.Drawing.Size(258, 34);
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 START
//				this.listプリンタ.Size = new System.Drawing.Size(258, (int)(34 * 1.5));
//				this.listプリンタ.Size = new System.Drawing.Size(258, (int)(50 * 1.5));
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
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab読取専用画面タイトル = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.texメッセージ = new System.Windows.Forms.TextBox();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.tex送り状番号入力 = new System.Windows.Forms.TextBox();
			this.lab送り状番号 = new System.Windows.Forms.Label();
			this.btn照会 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).BeginInit();
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
			this.panel7.Controls.Add(this.lab読取専用画面タイトル);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(792, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab読取専用画面タイトル
			// 
			this.lab読取専用画面タイトル.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab読取専用画面タイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab読取専用画面タイトル.ForeColor = System.Drawing.Color.White;
			this.lab読取専用画面タイトル.Location = new System.Drawing.Point(12, 2);
			this.lab読取専用画面タイトル.Name = "lab読取専用画面タイトル";
			this.lab読取専用画面タイトル.Size = new System.Drawing.Size(264, 24);
			this.lab読取専用画面タイトル.TabIndex = 0;
			this.lab読取専用画面タイトル.Text = "読取専用画面";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.texメッセージ);
			this.panel8.Controls.Add(this.btn閉じる);
			this.panel8.Location = new System.Drawing.Point(0, 286);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 2;
			// 
			// texメッセージ
			// 
			this.texメッセージ.BackColor = System.Drawing.Color.PaleGreen;
			this.texメッセージ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texメッセージ.ForeColor = System.Drawing.Color.Red;
			this.texメッセージ.Location = new System.Drawing.Point(190, 4);
			this.texメッセージ.Multiline = true;
			this.texメッセージ.Name = "texメッセージ";
			this.texメッセージ.ReadOnly = true;
			this.texメッセージ.Size = new System.Drawing.Size(196, 50);
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
			this.btn閉じる.TabIndex = 3;
			this.btn閉じる.Text = "閉じる";
			this.btn閉じる.Click += new System.EventHandler(this.btn閉じる_Click);
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
			// tex送り状番号入力
			// 
			this.tex送り状番号入力.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex送り状番号入力.Location = new System.Drawing.Point(8, 96);
			this.tex送り状番号入力.Name = "tex送り状番号入力";
			this.tex送り状番号入力.Size = new System.Drawing.Size(280, 31);
			this.tex送り状番号入力.TabIndex = 1;
			this.tex送り状番号入力.Text = "";
			this.tex送り状番号入力.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex送り状番号入力_KeyDown);
			this.tex送り状番号入力.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex送り状番号入力_KeyPress);
			// 
			// lab送り状番号
			// 
			this.lab送り状番号.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab送り状番号.Location = new System.Drawing.Point(8, 64);
			this.lab送り状番号.Name = "lab送り状番号";
			this.lab送り状番号.TabIndex = 15;
			this.lab送り状番号.Text = "送り状№";
			// 
			// btn照会
			// 
			this.btn照会.BackColor = System.Drawing.Color.DarkGray;
			this.btn照会.Location = new System.Drawing.Point(296, 96);
			this.btn照会.Name = "btn照会";
			this.btn照会.Size = new System.Drawing.Size(48, 24);
			this.btn照会.TabIndex = 2;
			this.btn照会.Text = "照会";
			this.btn照会.Click += new System.EventHandler(this.btn照会_Click);
			// 
			// 読取専用画面
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(388, 349);
			this.Controls.Add(this.btn照会);
			this.Controls.Add(this.lab送り状番号);
			this.Controls.Add(this.tex送り状番号入力);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(394, 374);
			this.Name = "読取専用画面";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 読取専用画面";
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 START
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Onエンター移動);
            //this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Onエンターキャンセル);
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 END
            this.Load += new System.EventHandler(this.読取専用画面_Load);
			this.Closed += new System.EventHandler(this.読取専用画面_Closed);
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).EndInit();
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 START
        protected void Onエンター移動(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            base.エンター移動(sender, e);
        }

        protected void Onエンターキャンセル(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            base.エンターキャンセル(sender, e);
        }
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 END

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void 初期設定()
		{

		}

		private void 読取専用画面_Load(object sender, System.EventArgs e)
		{
			//送り状番号入力へフォーカス
			this.tex送り状番号入力.Text = "";
			tex送り状番号入力.Focus();
		}

		private void 読取専用画面_Closed(object sender, System.EventArgs e)
		{
			this.tex送り状番号入力.Text = "";
			tex送り状番号入力.Focus();
		}

		private void btn照会_Click(object sender, System.EventArgs e)
		{

			try
			{

				//出荷登録画面参照
				if (g出荷登録 == null)	 g出荷登録 = new 出荷登録();
				g出荷登録.Left = this.Left;
				g出荷登録.Top = this.Top;

				//原票番号のチェック
				string s送り状番号		= tex送り状番号入力.Text.Trim();
				string s送り状番号11	= "";

				//半角入力チェック
				if (!半角チェック(s送り状番号)) return;

				//ハイフン置換
				s送り状番号 = s送り状番号.Replace("-","");

				switch (s送り状番号.Length)
				{
					case 11:
						//送り状番号のみパターン
						s送り状番号11 = s送り状番号;
						break;
					case 13:
						//送り状番号＋連番パターン
						s送り状番号11 = s送り状番号.Substring(0,11);
						break;
					case 15:
						//ＡＡ付送り状番号＋連番パターン
						s送り状番号11 = s送り状番号.Substring(1,11);
						break;
					default:
						//所定のフォーマットではない
						MessageBox.Show("送り状番号：" + s送り状番号 + "\r\n"
										+"入力フォーマットに誤りがあります。\r\n１１桁または１３桁で入力して下さい。\r\n","確認",MessageBoxButtons.OK );
						tex送り状番号入力.Focus();
						tex送り状番号入力.SelectAll();
						return;
				}

				//数値チェック
				if (!数値チェック(s送り状番号11))
				{
					//文字列が含まれる
					MessageBox.Show("送り状番号：" + s送り状番号11 + "\r\n"
									+"入力値に数値以外が含まれています。\r\n","確認",MessageBoxButtons.OK );
					tex送り状番号入力.Focus();
					tex送り状番号入力.SelectAll();
					return;
				}

				//チェックデジットチェック
				if (!チェックデジットチェック(s送り状番号11))
				{
					//チェックデジットが不正
					MessageBox.Show("送り状番号：" + s送り状番号11 + "\r\n"
									+"チェックデジットが不正です。\r\n","確認",MessageBoxButtons.OK );
					tex送り状番号入力.Focus();
					tex送り状番号入力.SelectAll();
					return;			
				}

				//送り状番号の存在チェック（メソッド作成)
				s出荷一覧 = new string[1];
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
				string[] sa検索条件 = new string[]{
												  gs会員ＣＤ
												  , gs部門ＣＤ
												  , ""
												  , ""
												  , "0"
												  , "0"
												  , "0"
												  , "00"
												  , s送り状番号11
												  , s送り状番号11
												  , ""
												  , ""
												  , "1"
											  };
				s出荷一覧 = sv_syukka.Get_syukka2(gsaユーザ, sa検索条件);
				if (s出荷一覧[0] != "正常終了")
				{
					//該当データなし
					MessageBox.Show("送り状番号：" + s送り状番号11 + "\r\n"
									+"出荷データが存在しません。\r\nスキャン情報に誤りがある、または削除済です。\r\n","確認",MessageBoxButtons.OK );
					tex送り状番号入力.Focus();
					tex送り状番号入力.SelectAll();
					return;
				}

				//サーバ取得結果を配列に分割する
				string[] sa出荷データ = s出荷一覧[4].Split('|');

				//出荷登録（修正画面）のデータ生成処理
				if (g出荷登録 == null)	 g出荷登録 = new 出荷登録();
				g出荷登録.Left = this.Left;
				g出荷登録.Top = this.Top;
			
				g出荷登録.s登録日 = sa出荷データ[17].Trim();		
				g出荷登録.sジャーナルＮＯ = sa出荷データ[16].Trim();
				g出荷登録.s登録者ＣＤ = sa出荷データ[19].Trim();

				//出荷登録（修正画面）の呼び出し
				if(g出荷登録.sジャーナルＮＯ.Length > 0)
				{
					g出荷登録.s処理ＦＧ = "U";
					this.Visible = false;
					g出荷登録.ShowDialog();
					this.Visible = true;
					this.tex送り状番号入力.Text = "";
					this.tex送り状番号入力.Focus();
					//btn照会_Click(sender, e);
					if(texメッセージ.Text.Trim().Length == 4)
						texメッセージ.Text = "";
				}
				else
				{
					MessageBox.Show("送り状番号：" + s送り状番号11 + "\r\n"
									+"出荷データが存在しません。\r\nスキャン情報に誤りがある、または削除済です。\r\n","確認",MessageBoxButtons.OK );
					tex送り状番号入力.Focus();
					tex送り状番号入力.SelectAll();
					return;
				}
			}
			catch (System.Net.WebException)
			{
				texメッセージ.Text = gs通信エラー;
				ビープ音();
			}
			catch (Exception ex)
			{
				texメッセージ.Text = "通信エラー：" + ex.Message;
				ビープ音();
			}
		}

		private void tex送り状番号入力_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				btn照会_Click(sender, e);
			}
		}

		private void tex送り状番号入力_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn照会_Click(sender, e);
			}		
		}
		
		private new bool 数値チェック(string 送り状番号)
		{
			//.NET1.1用"TryParse"作成
			try
			{
				long.Parse(送り状番号);
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

		private bool チェックデジットチェック(string 送り状番号)
		{
			long チェック元ＣＤ = long.Parse(送り状番号.Substring(10,1));
			long チェック先ＣＤ = long.Parse(送り状番号.Substring(0,10)) % 7;
			
			if (チェック元ＣＤ != チェック先ＣＤ) return false; 

			return true;
		}


	}
}
