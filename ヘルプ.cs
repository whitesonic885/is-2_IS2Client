using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace IS2Client
{
	/// <summary>
	/// [ヘルプ]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 
	// MOD 2010.06.07 東都）高木 ＦＡＱの追加 
	//--------------------------------------------------------------------------
	// MOD 2011.02.03 東都）高木 SATO製プリンタ清掃マニュアル追加 
	// MOD 2011.06.22 東都）高木 王子運送の対応 
	// MOD 2011.07.25 東都）高木 分割マニュアルPDF名変更 
	//--------------------------------------------------------------------------
	public class ヘルプ : IS2Client.共通フォーム
	{
		public  string sヘルプＵＲＬ         = "";
		public  string sヘルプＵＲＬＢＡＳＥ = "";

		private System.Windows.Forms.Button[] btnヘルプ;

		private System.Windows.Forms.Button btnClose;
		private System.ComponentModel.IContainer components = null;

		public ヘルプ()
		{
			// この呼び出しは Windows フォーム デザイナで必要です。
			InitializeComponent();

// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
			ＤＰＩ表示サイズ変換();
// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 END
			Init();
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

		#region デザイナで生成されたコード
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
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
			this.btnClose.Text = "閉じる";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// ヘルプ
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.ClientSize = new System.Drawing.Size(210, 390);
			this.Controls.Add(this.btnClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ヘルプ";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.ResumeLayout(false);

		}
		#endregion
		//ヘルプ名
		private static string[] sヘルプ = {
			  "iS-2簡易マニュアル", "iS-2操作マニュアル"
			, "　iS-2を使用するには", "　出荷を行う", "　ラベルの再印刷"
			, "　エントリーの修正", "　実績の照会", "　お届け先の登録"
			, "　ご依頼主の登録", "　記事の登録", "　ラベルプリンタの変更"
			, "　請求先の登録", "　エントリーオプション", "　その他の便利な機能"
			, "　お知らせ", "　付録"
// MOD 2011.02.03 東都）高木 SATO製プリンタ清掃マニュアル追加 START
			, "SATO製ﾌﾟﾘﾝﾀの清掃方法"
			, "SATO製ﾌﾟﾘﾝﾀのﾗﾍﾞﾙｾｯﾄ方法"
// MOD 2011.02.03 東都）高木 SATO製プリンタ清掃マニュアル追加 END
// MOD 2010.06.07 東都）高木 ＦＡＱの追加 START
			, "自動出力操作ﾏﾆｭｱﾙ"
			, "ＦＡＱ（よくある質問）"
// MOD 2010.06.07 東都）高木 ＦＡＱの追加 END
		};
		private static int iヘルプ数 = sヘルプ.Length;
		//ヘルプのＰＤＦ
		private static string[] sヘルプＰＤＦ = {
// MOD 2010.06.07 東都）高木 ＦＡＱの追加 START
//			  "is2manual_kani.pdf", ""
			  "is2manual_kani.pdf", "is2manual.pdf"
// MOD 2010.06.07 東都）高木 ＦＡＱの追加 END
			, "1-1 iS-2を使用するには.pdf", "2-1 エントリー.pdf", "2-6 再発行.pdf"
// MOD 2011.07.25 東都）高木 分割マニュアルPDF名変更 START
//			, "2-8 エントリーの修正.pdf", "3-1 出荷照会.pdf", "4-1 お届け先情報.pdf"
//			, "4-6 ご依頼主情報.pdf", "4-10 記事情報.pdf", "4-14 端末情報.pdf"
//			, "4-15 請求先情報.pdf", "4-18 エントリーオプション.pdf", "5-1 その他の便利な機能.pdf"
			, "2-9 エントリーの修正.pdf", "3-1 出荷照会.pdf", "4-1 お届け先情報.pdf"
			, "4-7 ご依頼主情報.pdf", "4-13 記事情報.pdf", "4-17 端末情報.pdf"
			, "4-18 請求先情報.pdf", "4-21 エントリーオプション.pdf", "5-1 その他の便利な機能.pdf"
// MOD 2011.07.25 東都）高木 分割マニュアルPDF名変更 END
			, "6 お知らせ機能.pdf", "7 付録.pdf"
// MOD 2011.02.03 東都）高木 SATO製プリンタ清掃マニュアル追加 START
			, "SATO清掃資料.pdf"
			, "レスプリβラベルセット方法.pdf"
// MOD 2011.02.03 東都）高木 SATO製プリンタ清掃マニュアル追加 END
// MOD 2010.06.07 東都）高木 ＦＡＱの追加 START
//			  "is2manual_kani.pdf", ""
			, "iS-2自動出力マニュアル.pdf"
			, "/hp/faq/is2Faq.htm"
// MOD 2010.06.07 東都）高木 ＦＡＱの追加 END
		};
		private void Init()
		{
			//高さの設定
			this.Height = 26 * (1 + iヘルプ数);
			//ボタンの設定
			this.btnヘルプ = new System.Windows.Forms.Button[iヘルプ数];
			for(int iCnt = 0; iCnt < iヘルプ数; iCnt++){
				this.btnヘルプ[iCnt] = new System.Windows.Forms.Button();
				this.btnヘルプ[iCnt].BackColor = System.Drawing.Color.MediumBlue;
				this.btnヘルプ[iCnt].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
				this.btnヘルプ[iCnt].Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
				this.btnヘルプ[iCnt].ForeColor = System.Drawing.Color.White;
				this.btnヘルプ[iCnt].Location = new System.Drawing.Point(0, 26 + 26 * iCnt);
				this.btnヘルプ[iCnt].Name = "btnヘルプ" + iCnt.ToString();
				this.btnヘルプ[iCnt].Size = new System.Drawing.Size(210, 26);
				this.btnヘルプ[iCnt].TabIndex = iCnt;
				this.btnヘルプ[iCnt].Text = sヘルプ[iCnt];
				this.btnヘルプ[iCnt].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
				this.btnヘルプ[iCnt].Click += new System.EventHandler(this.btnヘルプ99_Click);
			}
			for(int iCnt = 0; iCnt < iヘルプ数; iCnt++){
				this.Controls.Add(this.btnヘルプ[iCnt]);
			}
		}
		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void btnヘルプ99_Click(object sender, System.EventArgs e)
		{
// MOD 2010.06.07 東都）高木 ＦＡＱの追加 START
//			if(sender == btnヘルプ[1]){
//				Process.Start("iexplore.exe", sヘルプＵＲＬ);
// MOD 2011.06.22 東都）高木 王子運送の対応 START
			if(gs会員ＣＤ.Substring(0,1) != "J"){
// MOD 2011.06.22 東都）高木 王子運送の対応 END
				if(sヘルプＰＤＦ[((Button)sender).TabIndex].StartsWith("/")){
					Process.Start("iexplore.exe"
						, sヘルプＵＲＬＢＡＳＥ.Replace("/is2/manual/","")
							 + sヘルプＰＤＦ[((Button)sender).TabIndex]);
// MOD 2010.06.07 東都）高木 ＦＡＱの追加 END
				}else{
					Process.Start("iexplore.exe"
						, sヘルプＵＲＬＢＡＳＥ
							 + sヘルプＰＤＦ[((Button)sender).TabIndex]);
				}
// MOD 2011.06.22 東都）高木 王子運送の対応 START
			}else{
				// 王子運送の場合
				if(sヘルプＰＤＦ[((Button)sender).TabIndex].StartsWith("/")){
					Process.Start("iexplore.exe"
						, sヘルプＵＲＬＢＡＳＥ.Replace("/is2/manual/","")
							 + sヘルプＰＤＦ[((Button)sender).TabIndex].Replace("/hp/","/hpj/"));
				}else{
					if(((Button)sender).TabIndex == 16		// "SATO清掃資料.pdf"
					|| ((Button)sender).TabIndex == 17){	// "レスプリβラベルセット方法.pdf"
						Process.Start("iexplore.exe"
							, sヘルプＵＲＬＢＡＳＥ
							 + sヘルプＰＤＦ[((Button)sender).TabIndex]);
					}else{
						Process.Start("iexplore.exe"
							, sヘルプＵＲＬＢＡＳＥ.Replace("/manual/","/manualJ/")
							 + sヘルプＰＤＦ[((Button)sender).TabIndex].Replace(".pdf","(王子).pdf"));
					}
				}
			}
// MOD 2011.06.22 東都）高木 王子運送の対応 END
			this.Close();
		}
	}
}

