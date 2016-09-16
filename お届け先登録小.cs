using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [お届け先登録小]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// MOD 2008.03.19 東都）高木 お届け先の上書機能の追加 
	// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 
	// ADD 2008.10.16 kcl)森本 着店コード存在チェック追加 
	// ADD 2008.10.17 東都）高木 着店コードチェック機能不可視化 
	// MOD 2008.11.12 東都）高木 住所ＣＤの自動設定を行わない
	//--------------------------------------------------------------------------
	// DEL 2009.02.02 東都）高木 着店コードチェック機能可視化
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない 
	//--------------------------------------------------------------------------
	public class お届け先登録小 : 共通フォーム
	{
// MOD 2008.06.11 kcl)森本 着店コード検索方法の変更 START
//// MOD 2008.03.19 東都）高木 お届け先の上書機能の追加 START
////		public string[] sTdata = new string[18];
//		public string[] sTdata = new string[20];
//// MOD 2008.03.19 東都）高木 お届け先の上書機能の追加 END
		public string[] sTdata = new string[21];
// MOD 2008.06.11 kcl)森本 着店コード検索方法の変更 END
		private string sIUFlg;
		public string s届け先ＣＤ;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Label label1;
		private 共通テキストボックス texカナ略称;
		private 共通テキストボックス texメール;
		private 共通テキストボックス tex届け先コード;
		private System.Windows.Forms.Button btn登録;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.Label labメール;
		private System.Windows.Forms.Label labカナ略称;
		private System.Windows.Forms.Label lab届け先コード;
		private System.Windows.Forms.Label lab届け先登録タイトル;
		private System.Windows.Forms.GroupBox groupBox1;
		private IS2Client.共通テキストボックス tex着店コード;
		private IS2Client.共通テキストボックス tex住所コード;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public お届け先登録小()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
			ＤＰＩ表示サイズ変換();
// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 END
// ADD 2008.10.17 東都）高木 着店コードチェック機能不可視化 START
// DEL 2009.02.02 東都）高木 着店コードチェック機能可視化 START
//			lab住所コード.Visible = false;
//			lab着店コード.Visible = false;
// DEL 2009.02.02 東都）高木 着店コードチェック機能可視化 END
			tex住所コード.Visible = false;
			tex着店コード.Visible = false;
// ADD 2008.10.17 東都）高木 着店コードチェック機能不可視化 END
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
			this.texカナ略称 = new IS2Client.共通テキストボックス();
			this.labメール = new System.Windows.Forms.Label();
			this.texメール = new IS2Client.共通テキストボックス();
			this.label1 = new System.Windows.Forms.Label();
			this.labカナ略称 = new System.Windows.Forms.Label();
			this.btn登録 = new System.Windows.Forms.Button();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.lab届け先コード = new System.Windows.Forms.Label();
			this.tex届け先コード = new IS2Client.共通テキストボックス();
			this.panel7 = new System.Windows.Forms.Panel();
			this.label30 = new System.Windows.Forms.Label();
			this.lab届け先登録タイトル = new System.Windows.Forms.Label();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tex住所コード = new IS2Client.共通テキストボックス();
			this.tex着店コード = new IS2Client.共通テキストボックス();
			this.panel7.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// texカナ略称
			// 
			this.texカナ略称.BackColor = System.Drawing.SystemColors.Window;
			this.texカナ略称.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texカナ略称.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
			this.texカナ略称.Location = new System.Drawing.Point(130, 38);
			this.texカナ略称.MaxLength = 10;
			this.texカナ略称.Name = "texカナ略称";
			this.texカナ略称.Size = new System.Drawing.Size(94, 23);
			this.texカナ略称.TabIndex = 1;
			this.texカナ略称.Text = "";
			// 
			// labメール
			// 
			this.labメール.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labメール.ForeColor = System.Drawing.Color.LimeGreen;
			this.labメール.Location = new System.Drawing.Point(42, 70);
			this.labメール.Name = "labメール";
			this.labメール.Size = new System.Drawing.Size(80, 14);
			this.labメール.TabIndex = 50;
			this.labメール.Text = "メールアドレス";
			// 
			// texメール
			// 
			this.texメール.BackColor = System.Drawing.SystemColors.Window;
			this.texメール.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texメール.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.texメール.Location = new System.Drawing.Point(130, 64);
			this.texメール.MaxLength = 45;
			this.texメール.Name = "texメール";
			this.texメール.Size = new System.Drawing.Size(250, 23);
			this.texメール.TabIndex = 2;
			this.texメール.Text = "";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 142);
			this.label1.TabIndex = 44;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labカナ略称
			// 
			this.labカナ略称.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labカナ略称.ForeColor = System.Drawing.Color.LimeGreen;
			this.labカナ略称.Location = new System.Drawing.Point(42, 42);
			this.labカナ略称.Name = "labカナ略称";
			this.labカナ略称.Size = new System.Drawing.Size(80, 14);
			this.labカナ略称.TabIndex = 42;
			this.labカナ略称.Text = "カナ略称";
			// 
			// btn登録
			// 
			this.btn登録.BackColor = System.Drawing.Color.PaleGreen;
			this.btn登録.ForeColor = System.Drawing.Color.Blue;
			this.btn登録.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn登録.Location = new System.Drawing.Point(260, 92);
			this.btn登録.Name = "btn登録";
			this.btn登録.Size = new System.Drawing.Size(54, 48);
			this.btn登録.TabIndex = 6;
			this.btn登録.Text = "登録";
			this.btn登録.Click += new System.EventHandler(this.btn登録_Click);
			// 
			// btn閉じる
			// 
			this.btn閉じる.BackColor = System.Drawing.Color.PaleGreen;
			this.btn閉じる.ForeColor = System.Drawing.Color.Red;
			this.btn閉じる.Location = new System.Drawing.Point(66, 92);
			this.btn閉じる.Name = "btn閉じる";
			this.btn閉じる.Size = new System.Drawing.Size(54, 48);
			this.btn閉じる.TabIndex = 5;
			this.btn閉じる.TabStop = false;
			this.btn閉じる.Text = "閉じる";
			this.btn閉じる.Click += new System.EventHandler(this.btn閉じる_Click);
			// 
			// lab届け先コード
			// 
			this.lab届け先コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab届け先コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab届け先コード.Location = new System.Drawing.Point(24, 16);
			this.lab届け先コード.Name = "lab届け先コード";
			this.lab届け先コード.Size = new System.Drawing.Size(104, 16);
			this.lab届け先コード.TabIndex = 6;
			this.lab届け先コード.Text = "お届け先コード";
			// 
			// tex届け先コード
			// 
			this.tex届け先コード.BackColor = System.Drawing.SystemColors.Window;
			this.tex届け先コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex届け先コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex届け先コード.Location = new System.Drawing.Point(130, 12);
			this.tex届け先コード.MaxLength = 15;
			this.tex届け先コード.Name = "tex届け先コード";
			this.tex届け先コード.Size = new System.Drawing.Size(166, 23);
			this.tex届け先コード.TabIndex = 0;
			this.tex届け先コード.Text = "";
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.label30);
			this.panel7.Controls.Add(this.lab届け先登録タイトル);
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
			// lab届け先登録タイトル
			// 
			this.lab届け先登録タイトル.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab届け先登録タイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab届け先登録タイトル.ForeColor = System.Drawing.Color.White;
			this.lab届け先登録タイトル.Location = new System.Drawing.Point(12, 2);
			this.lab届け先登録タイトル.Name = "lab届け先登録タイトル";
			this.lab届け先登録タイトル.Size = new System.Drawing.Size(264, 24);
			this.lab届け先登録タイトル.TabIndex = 0;
			this.lab届け先登録タイトル.Text = "お届け先登録";
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
			this.groupBox1.Controls.Add(this.tex届け先コード);
			this.groupBox1.Controls.Add(this.btn登録);
			this.groupBox1.Controls.Add(this.labメール);
			this.groupBox1.Controls.Add(this.texメール);
			this.groupBox1.Controls.Add(this.btn閉じる);
			this.groupBox1.Controls.Add(this.texカナ略称);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.lab届け先コード);
			this.groupBox1.Controls.Add(this.labカナ略称);
			this.groupBox1.Controls.Add(this.tex住所コード);
			this.groupBox1.Controls.Add(this.tex着店コード);
			this.groupBox1.Location = new System.Drawing.Point(0, 22);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(388, 149);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			// 
			// tex住所コード
			// 
			this.tex住所コード.BackColor = System.Drawing.SystemColors.Window;
			this.tex住所コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex住所コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex住所コード.Location = new System.Drawing.Point(130, 90);
			this.tex住所コード.MaxLength = 16;
			this.tex住所コード.Name = "tex住所コード";
			this.tex住所コード.Size = new System.Drawing.Size(124, 23);
			this.tex住所コード.TabIndex = 1;
			this.tex住所コード.Text = "";
			// 
			// tex着店コード
			// 
			this.tex着店コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex着店コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex着店コード.Location = new System.Drawing.Point(130, 116);
			this.tex着店コード.MaxLength = 4;
			this.tex着店コード.Name = "tex着店コード";
			this.tex着店コード.Size = new System.Drawing.Size(40, 23);
			this.tex着店コード.TabIndex = 2;
			this.tex着店コード.Text = "";
			// 
			// お届け先登録小
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
			this.Name = "お届け先登録小";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 お届け先登録";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
			this.Load += new System.EventHandler(this.お届け先登録小_Load);
			this.Closed += new System.EventHandler(this.お届け先登録小_Closed);
			this.panel7.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btn登録_Click(object sender, System.EventArgs e)
		{
			tex届け先コード.Text = tex届け先コード.Text.Trim();
			texカナ略称.Text     = texカナ略称.Text.Trim();
			texメール.Text       = texメール.Text.Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
			if(gsオプション[18].Equals("1")){
				texカナ略称.Text     = texカナ略称.Text.TrimEnd();
				texメール.Text       = texメール.Text.TrimEnd();
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 START
			tex住所コード.Text   = tex住所コード.Text.Trim();
			tex着店コード.Text   = tex着店コード.Text.Trim();
// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 END

			if(!必須チェック(tex届け先コード,"届け先コード")) return;

			if(!半角チェック(tex届け先コード,"届け先コード")) return;
			if(!半角チェック(texカナ略称,"カナ略称")) return;
			if(!半角チェック(texメール,"メールアドレス")) return;
// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 START
			if(!半角チェック(tex住所コード,"住所コード")) return;
			if(!半角チェック(tex着店コード,"着店コード")) return;
// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 END

			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			String[] sList = {""};
			try
			{
				if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
				sList = sv_otodoke.Get_Stodokesaki(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,tex届け先コード.Text);

//			sUpday    = sList[14];
				//↑コメント削除可？
				sIUFlg    = sList[15];

				String[] sIUList;
				sTdata[0]  = tex届け先コード.Text;
				sTdata[1]  = texカナ略称.Text;
				sTdata[12] = " ";
				sTdata[13] = texメール.Text;
				sTdata[14] = "お届け小";
				sTdata[15] = gs利用者ＣＤ;
				sTdata[16] = gs会員ＣＤ;
				sTdata[17] = gs部門ＣＤ;
// MOD 2008.03.19 東都）高木 お届け先の上書機能の追加 START
				sTdata[18] = sList[14];		//更新日時
// MOD 2008.03.19 東都）高木 お届け先の上書機能の追加 END
// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 START
				// 住所コードが入力されている場合は、それを優先する
// MOD 2008.11.12 東都）高木 住所ＣＤの自動設定を行わない START
//				if (tex住所コード.Text.Length > 0)
// MOD 2008.11.12 東都）高木 住所ＣＤの自動設定を行わない END
				sTdata[19] = tex住所コード.Text;
				sTdata[20] = tex着店コード.Text;
// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 END
				for(int iCnt = 0 ; iCnt < sTdata.Length; iCnt++ )
				{
					if( sTdata[iCnt] == null 
						|| sTdata[iCnt].Length == 0 ) sTdata[iCnt] = " ";
				}

				if(sIUFlg == "I")
				{
					sIUList = sv_otodoke.Ins_todokesaki(gsaユーザ,sTdata);
					if(sIUList[0].Length == 4)
					{
						s届け先ＣＤ = tex届け先コード.Text;
						this.Close();
					}
					else
					{
						MessageBox.Show(sIUList[0],"エラー",MessageBoxButtons.OK);
					}
				}
				else
				{
// MOD 2008.03.19 東都）高木 お届け先の上書機能の追加 START
//					MessageBox.Show("同一のコードが既に登録されています。","登録",MessageBoxButtons.OK);
//					tex届け先コード.Focus();
					DialogResult result;
					if(btn登録.Text.Equals("登録")){
						result = MessageBox.Show("既に存在するデータに上書きしますか？","更新",MessageBoxButtons.YesNo);
					}else{
						result = DialogResult.Yes;
					}
					if(result == DialogResult.Yes)
					{
						Cursor = System.Windows.Forms.Cursors.AppStarting;
//						texメッセージ.Text = "更新中．．．";

						if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
						sIUList = sv_otodoke.Upd_todokesaki(gsaユーザ,sTdata);
						Cursor = System.Windows.Forms.Cursors.Default;
						// 正常終了時、画面をクリアする
						if(sIUList[0].Length == 4)
						{
							s届け先ＣＤ = tex届け先コード.Text;
							this.Close();
						}
						else
						{
							ビープ音();
							MessageBox.Show(sIUList[0],"エラー",MessageBoxButtons.OK);
						}
					}
// MOD 2008.03.19 東都）高木 お届け先の上書機能の追加 END
				}
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				sList[0] = gs通信エラー;
				MessageBox.Show(sList[0],"エラー",MessageBoxButtons.OK);
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				sList[0] = "通信エラー：" + ex.Message;
				MessageBox.Show(sList[0],"エラー",MessageBoxButtons.OK);
			}
			Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void お届け先登録小_Load(object sender, EventArgs e)
		{
// MOD 2008.03.19 東都）高木 お届け先の上書機能の追加 START
//			if(s届け先ＣＤ.Length == 0)
//				tex届け先コード.Text  = " ";
//			else
//				tex届け先コード.Text = s届け先ＣＤ;
			if(s届け先ＣＤ.Length == 0){
				tex届け先コード.Text  = " ";
				btn登録.Text = "登録";
			}else{
				tex届け先コード.Text = s届け先ＣＤ;
				tex届け先コード.Text = tex届け先コード.Text.Trim();
				if(!半角チェック(tex届け先コード,"届け先コード")) return;

				// カーソルを砂時計にする
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				String[] sList = {""};
				try
				{
					if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
					sList = sv_otodoke.Get_Stodokesaki(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,tex届け先コード.Text);
					if(sList[0].Equals("更新")){
						tex届け先コード.Enabled = false;
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//// MOD 2008.03.19 東都）高木 お届け先の上書機能の追加 START
//						texカナ略称.Text = sList[1].Trim();
//						texメール.Text   = sList[13].Trim();
//// MOD 2008.03.19 東都）高木 お届け先の上書機能の追加 END
						texカナ略称.Text = sList[1].TrimEnd();
						texメール.Text   = sList[13].TrimEnd();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
// ADD 2008.06.16 kcl)森本 着店コード検索方法の変更 START
						tex住所コード.Text = sList[16].Trim();
						tex着店コード.Text = sList[17].Trim();
// ADD 2008.06.16 kcl)森本 着店コード検索方法の変更 END
						btn登録.Text = "上書き";
					}else{
						btn登録.Text = "登録";
					}
					btn登録.Refresh();
				}
				catch (System.Net.WebException)
				{
					sList[0] = gs通信エラー;
					MessageBox.Show(sList[0],"エラー",MessageBoxButtons.OK);
				}
				catch (Exception ex)
				{
					sList[0] = "通信エラー：" + ex.Message;
					MessageBox.Show(sList[0],"エラー",MessageBoxButtons.OK);
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
// MOD 2008.03.19 東都）高木 お届け先の上書機能の追加 END
		}

		private void お届け先登録小_Closed(object sender, System.EventArgs e)
		{
// MOD 2008.03.19 東都）高木 お届け先の上書機能の追加 START
			tex届け先コード.Enabled = true;
// MOD 2008.03.19 東都）高木 お届け先の上書機能の追加 END
			tex届け先コード.Text  = "               ";
			texカナ略称.Text      = "";
			texメール.Text        = "";
// ADD 2008.06.16 kcl)森本 着店コード検索方法の変更 START
			tex住所コード.Text    = "";
			tex着店コード.Text    = "";
// ADD 2008.06.16 kcl)森本 着店コード検索方法の変更 END
			tex届け先コード.Focus();
		}
	}
}
