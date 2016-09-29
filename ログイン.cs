using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace IS2Client
{
	/// <summary>
	/// [ログイン]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// MOD 2008.03.13 東都）高木 Vista対応 
	// ADD 2008.03.13 東都）高木 暗号・復号機能の追加 
	// ADD 2008.06.17 東都）高木 ＭＡＣアドレスチェックの追加 
	// ADD 2008.06.30 東都）高木 パスワードチェックの強化 
	// MOD 2008.07.09 東都）高木 ＭＡＣアドレス取得の強化 
	// MOD 2008.07.16 東都）高木 ＭＡＣアドレスの簡易マスキング 
	//保留 MOD 2008.10.23 東都）高木 ＭＡＣアドレスの未取得時の設定変更 
	//--------------------------------------------------------------------------
	// ADD 2009.02.16 東都）高木 [wis2.dll]ファイルのクリア 
	// ADD 2009.07.29 東都）高木 プロキシ対応 
	// 　ＩＥの[Secure]の設定からも取得する
	// 　プロキシをユーザが設定できるようにする
	// MOD 2009.07.30 東都）高木 exeのdll化対応 
	// MOD 2009.10.16 東都）高木 プロキシ機能表記の追加 
	//--------------------------------------------------------------------------
	// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 
	// MOD 2010.04.16 東都）高木 モジュール再ダウンロード 
	//--------------------------------------------------------------------------
	// MOD 2011.04.05 東都）高木 画面イメージのロード変更 
	// MOD 2011.10.11 東都）高木 ＳＳＬ証明書導入状態などのチェック 
	//--------------------------------------------------------------------------
	public class ログイン : 共通フォーム
	{
		private int iログイントライ回数 = 0;
		private string s端末 = "";

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnログイン;
		private System.Windows.Forms.Label lab利用者ＣＤ;
		private 共通テキストボックス tex利用者ＣＤ;
		private System.Windows.Forms.Label labパスワード;
		private 共通テキストボックス texパスワード;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox picログオン;
		private System.Windows.Forms.CheckBox cBox保持;
		private System.Windows.Forms.Label labバージョン;

		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ログイン()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ログイン));
			this.tex利用者ＣＤ = new IS2Client.共通テキストボックス();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labバージョン = new System.Windows.Forms.Label();
			this.cBox保持 = new System.Windows.Forms.CheckBox();
			this.picログオン = new System.Windows.Forms.PictureBox();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.labパスワード = new System.Windows.Forms.Label();
			this.texパスワード = new IS2Client.共通テキストボックス();
			this.lab利用者ＣＤ = new System.Windows.Forms.Label();
			this.btnログイン = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tex利用者ＣＤ
			// 
			this.tex利用者ＣＤ.BackColor = System.Drawing.SystemColors.Window;
			this.tex利用者ＣＤ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex利用者ＣＤ.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex利用者ＣＤ.Location = new System.Drawing.Point(134, 72);
			this.tex利用者ＣＤ.MaxLength = 6;
			this.tex利用者ＣＤ.Name = "tex利用者ＣＤ";
			this.tex利用者ＣＤ.Size = new System.Drawing.Size(170, 23);
			this.tex利用者ＣＤ.TabIndex = 0;
			this.tex利用者ＣＤ.Text = "";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.panel1.Controls.Add(this.labバージョン);
			this.panel1.Controls.Add(this.cBox保持);
			this.panel1.Controls.Add(this.picログオン);
			this.panel1.Controls.Add(this.btn閉じる);
			this.panel1.Controls.Add(this.labパスワード);
			this.panel1.Controls.Add(this.texパスワード);
			this.panel1.Controls.Add(this.lab利用者ＣＤ);
			this.panel1.Controls.Add(this.tex利用者ＣＤ);
			this.panel1.Controls.Add(this.btnログイン);
			this.panel1.Location = new System.Drawing.Point(-2, -14);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(370, 197);
			this.panel1.TabIndex = 0;
			// 
			// labバージョン
			// 
			this.labバージョン.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(191)), ((System.Byte)(190)));
			this.labバージョン.ForeColor = System.Drawing.Color.Black;
			this.labバージョン.Location = new System.Drawing.Point(304, 22);
			this.labバージョン.Name = "labバージョン";
			this.labバージョン.Size = new System.Drawing.Size(60, 12);
			this.labバージョン.TabIndex = 53;
			this.labバージョン.Text = "Ver.1.9";
			// 
			// cBox保持
			// 
			this.cBox保持.Location = new System.Drawing.Point(134, 128);
			this.cBox保持.Name = "cBox保持";
			this.cBox保持.Size = new System.Drawing.Size(128, 18);
			this.cBox保持.TabIndex = 52;
			this.cBox保持.TabStop = false;
			this.cBox保持.Text = "パスワードを保持する";
			// 
			// picログオン
			// 
			this.picログオン.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(191)), ((System.Byte)(190)));
			this.picログオン.Image = ((System.Drawing.Image)(resources.GetObject("picログオン.Image")));
			this.picログオン.Location = new System.Drawing.Point(2, 2);
			this.picログオン.Name = "picログオン";
			this.picログオン.Size = new System.Drawing.Size(366, 66);
			this.picログオン.TabIndex = 51;
			this.picログオン.TabStop = false;
			// 
			// btn閉じる
			// 
			this.btn閉じる.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btn閉じる.ForeColor = System.Drawing.Color.Black;
			this.btn閉じる.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn閉じる.Location = new System.Drawing.Point(208, 154);
			this.btn閉じる.Name = "btn閉じる";
			this.btn閉じる.Size = new System.Drawing.Size(100, 20);
			this.btn閉じる.TabIndex = 3;
			this.btn閉じる.TabStop = false;
			this.btn閉じる.Text = "キャンセル";
			this.btn閉じる.Click += new System.EventHandler(this.btn閉じる_Click);
			// 
			// labパスワード
			// 
			this.labパスワード.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labパスワード.ForeColor = System.Drawing.Color.Black;
			this.labパスワード.Location = new System.Drawing.Point(58, 102);
			this.labパスワード.Name = "labパスワード";
			this.labパスワード.Size = new System.Drawing.Size(74, 14);
			this.labパスワード.TabIndex = 50;
			this.labパスワード.Text = "パスワード：";
			// 
			// texパスワード
			// 
			this.texパスワード.BackColor = System.Drawing.SystemColors.Window;
			this.texパスワード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texパスワード.Location = new System.Drawing.Point(134, 98);
			this.texパスワード.MaxLength = 40;
			this.texパスワード.Name = "texパスワード";
			this.texパスワード.PasswordChar = '*';
			this.texパスワード.Size = new System.Drawing.Size(170, 23);
			this.texパスワード.TabIndex = 1;
			this.texパスワード.Text = "";
			this.texパスワード.KeyDown += new System.Windows.Forms.KeyEventHandler(this.texパスワード_KeyDown);
			// 
			// lab利用者ＣＤ
			// 
			this.lab利用者ＣＤ.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab利用者ＣＤ.ForeColor = System.Drawing.Color.Black;
			this.lab利用者ＣＤ.Location = new System.Drawing.Point(58, 76);
			this.lab利用者ＣＤ.Name = "lab利用者ＣＤ";
			this.lab利用者ＣＤ.Size = new System.Drawing.Size(72, 14);
			this.lab利用者ＣＤ.TabIndex = 42;
			this.lab利用者ＣＤ.Text = "ユーザー：";
			// 
			// btnログイン
			// 
			this.btnログイン.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btnログイン.ForeColor = System.Drawing.Color.Black;
			this.btnログイン.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnログイン.Location = new System.Drawing.Point(60, 154);
			this.btnログイン.Name = "btnログイン";
			this.btnログイン.Size = new System.Drawing.Size(100, 20);
			this.btnログイン.TabIndex = 2;
			this.btnログイン.Text = "ＯＫ";
			this.btnログイン.Click += new System.EventHandler(this.btnログイン_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Location = new System.Drawing.Point(0, -5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(374, 208);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			// 
			// ログイン
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(365, 175);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox1);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(373, 202);
			this.Name = "ログイン";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "is-2 ログイン";
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 START
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Onエンター移動);
            //this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Onエンターキャンセル);
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 END
            this.Load += new System.EventHandler(this.ログイン_Load);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
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

// ADD 2008.03.13 東都）高木 暗号・復号機能の追加 START
		private byte[] bKey = {51, 168, 96, 2, 36, 12, 74, 143, 11, 85, 61, 233, 202, 170, 114, 59};
		private byte[] bIv  = {100, 223, 207, 80, 29, 100, 53, 152};
		private string 暗号化(string sText)
		{
            byte[] bText;
            byte[] bRet;
			string sRet = "";

			try{
				MemoryStream msEncrypt = new MemoryStream();
				RC2CryptoServiceProvider rc2 = new RC2CryptoServiceProvider();

				// CryptoStreamオブジェクトを作成する
				ICryptoTransform transform = rc2.CreateEncryptor(bKey,bIv); // Encryptorを作成する
				CryptoStream cryptoStream = new CryptoStream( msEncrypt, transform, CryptoStreamMode.Write);

				// 暗号化する対象をバイト配列として読み込む
				bText = Encoding.GetEncoding("shift-jis").GetBytes(sText);
				
				// CryptoStreamによって暗号化して書き込む
				cryptoStream.Write( bText, 0, bText.Length );
				cryptoStream.FlushFinalBlock();

				bRet = msEncrypt.ToArray();
				//sRet = Encoding.GetEncoding("shift-jis").GetString(bRet);
				for(int iCnt = 0; iCnt < bRet.Length; iCnt++){
					sRet += bRet[iCnt].ToString("X2");
				}

				// CryptoStreamを閉じる
				cryptoStream.Close();

				// FileStreamを閉じる
				msEncrypt.Close();

				rc2          = null;
				cryptoStream = null;
				msEncrypt    = null;
			}catch(Exception ex){
				sRet = ex.Message;
			}

			return sRet;
		}

		private string 復号化(string sText)
		{
            byte[] bText;
            byte[] bRet;
			string sRet = "";

			try{
				//bText = Encoding.GetEncoding("shift-jis").GetBytes(sText);
				string sByte = "";
				bText = new byte[sText.Length / 2];
				for(int iCnt = 0; iCnt < sText.Length; iCnt+=2){
					sByte = sText.Substring(iCnt, 2);
					bText[iCnt/2] = Convert.ToByte(sByte,16);
				}

				MemoryStream inputStream = new MemoryStream(bText);
				RC2CryptoServiceProvider rc2 = new RC2CryptoServiceProvider();

				// CryptoStreamオブジェクトを作成する
				ICryptoTransform transform = rc2.CreateDecryptor(bKey,bIv); // Decryptorを作成する
				CryptoStream csDecrypt = new CryptoStream( inputStream, transform, CryptoStreamMode.Read);

				bRet = new Byte[bText.Length];
				//Read the data out of the crypto stream.
				int iLen = csDecrypt.Read(bRet, 0, bRet.Length);

				//Convert the byte array back into a string.
				sRet = Encoding.GetEncoding("shift-jis").GetString(bRet,0,iLen);

				// ストリームを閉じる
				csDecrypt.Close();
				inputStream.Close();

				rc2 = null;
				csDecrypt = null;
				inputStream = null;
			}catch(Exception ex){
				sRet = ex.Message;
			}

			return sRet;
		}
// ADD 2008.03.13 東都）高木 暗号・復号機能の追加 END
		private void btnログイン_Click(object sender, System.EventArgs e)
		{
			// 空白除去
			tex利用者ＣＤ.Text = tex利用者ＣＤ.Text.Trim();
			texパスワード.Text = texパスワード.Text.Trim();
// ADD 2009.02.16 東都）高木 [wis2.dll]ファイルのクリア START
			if(texパスワード.Text.Length == 0){
				if(tex利用者ＣＤ.Text.ToLower().Equals("i"))
				{
					// 初期設定ファイルのクリア
					StreamWriter sw = File.CreateText(gsInitFile);
					sw.WriteLine("");
					sw.WriteLine("");
					sw.WriteLine("");
					sw.Close();

					初期登録 F初期登録 = new 初期登録();
					F初期登録.ShowDialog();
					StreamReader sr = File.OpenText(gsInitFile);
					gs端末ＣＤ = sr.ReadLine();
					gs端末ＣＤ = sr.ReadLine();
					gs端末ＣＤ = sr.ReadLine();
					sr.Close();
					gsaユーザ[2] = gs端末ＣＤ;

					this.Close();
					return;
				}
// ADD 2009.07.29 東都）高木 プロキシ対応 START
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
// ADD 2009.07.29 東都）高木 プロキシ対応 END
// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 START
				if(tex利用者ＣＤ.Text.ToLower().Equals("s"))
				{
					// プロキシ初期設定ファイルのクリア
					StreamWriter swp = File.CreateText(gsInitSyukka);
					swp.WriteLine("3");		//3分
					swp.WriteLine("");
					swp.WriteLine("");
					swp.Close();

					gs端末ＣＤ   = "";
					gsaユーザ[2] = gs端末ＣＤ;

					this.Close();
					return;
				}
				if(tex利用者ＣＤ.Text.ToLower().Equals("sd"))
				{
					try{
						// プロキシ初期設定ファイルの削除
						System.IO.File.Delete(gsInitSyukka);
					}catch(Exception){}

					gs端末ＣＤ   = "";
					gsaユーザ[2] = gs端末ＣＤ;

					this.Close();
					return;
				}
// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 END
// MOD 2010.04.16 東都）高木 モジュール再ダウンロード START
				if(tex利用者ＣＤ.Text.ToLower().Equals("is2"))
				{
					try{
						// プロキシ初期設定ファイルの削除
						System.IO.File.Delete(gsFlagIS2Client);
					}catch(Exception){}

					gs端末ＣＤ   = "";
					gsaユーザ[2] = gs端末ＣＤ;

					this.Close();
					return;
				}
// MOD 2010.04.16 東都）高木 モジュール再ダウンロード END
			}
// ADD 2009.02.16 東都）高木 [wis2.dll]ファイルのクリア END
			// 項目チェック
			if(!必須チェック(tex利用者ＣＤ,"ユーザー")) return;
			if(!必須チェック(texパスワード,"パスワード")) return;
			if(!パスワードチェック(tex利用者ＣＤ,"ユーザー")) return;
			if(!パスワードチェック(texパスワード,"パスワード")) return;

			// 利用者マスタの検索
			String[] sKey = new string[]{
//				gs会員ＣＤ,
				gs端末ＣＤ,
				tex利用者ＣＤ.Text,
				texパスワード.Text
// ADD 2008.06.17 東都）高木 ＭＡＣアドレスチェックの追加 START
				, ""			// [ 3]コンピュータ名
				, ""			// [ 4]ＩＰアドレス
				, ""			// [ 5]ＭＡＣアドレス
// ADD 2008.06.17 東都）高木 ＭＡＣアドレスチェックの追加 END
// MOD 2011.10.11 東都）高木 ＳＳＬ証明書導入状態などのチェック START
				, gbInitProxyExists ? "p" : " "  
								// [ 6]プロキシ
				, gbInitSyukkaExists ? "s" : " "
								// [ 7]自動出力
				, gsOSVer		// [ 8]ＯＳバージョン
				, gsNetVer		// [ 9]ＮＥＴバージョン
				, gsSSLStatus	// [10]ＳＳＬテスト結果
// MOD 2011.10.11 東都）高木 ＳＳＬ証明書導入状態などのチェック END
			};

// ADD 2008.06.17 東都）高木 ＭＡＣアドレスチェックの追加 START
			// コンピュータ名
			try
			{
				sKey[3] = System.Environment.MachineName;
				// ＩＰアドレス
				try
				{
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 START
					//System.Net.IPHostEntry iph = System.Net.Dns.GetHostByName(sKey[3]);
                    System.Net.IPHostEntry iph = System.Net.Dns.GetHostEntry(sKey[3]);
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 END

// MOD 2008.07.09 東都）高木 ＭＡＣアドレス取得の強化 START
//					sKey[4] = iph.AddressList[0].ToString();
					sKey[4] = "";
					sKey[5] = "";
					for(uint uiCnt = 0; uiCnt < iph.AddressList.Length; uiCnt++){
//保留 MOD 2008.10.23 東都）高木 ＭＡＣアドレスの未取得時の設定変更 START
//						sKey[4] = "";
//						sKey[5] = "";
//保留 MOD 2008.10.23 東都）高木 ＭＡＣアドレスの未取得時の設定変更 END
						sKey[4] = iph.AddressList[uiCnt].ToString();
						// ＭＡＣアドレスの取得
						sKey[5] = GetMacAddress(sKey[4]);
//保留 MOD 2008.10.23 東都）高木 ＭＡＣアドレスの未取得時の設定変更 START
						if(sKey[4].Trim().Length > 0 && sKey[5].Trim().Length > 0) break;
//						if(sKey[4].Trim().Length > 0 && sKey[5].Trim().Length > 1) break;
//保留 MOD 2008.10.23 東都）高木 ＭＡＣアドレスの未取得時の設定変更 END
					}
// MOD 2008.07.09 東都）高木 ＭＡＣアドレス取得の強化 END
				}
				catch(Exception)
				{
					sKey[4] = "";
// ADD 2008.07.09 東都）高木 ＭＡＣアドレス取得の強化 START
					sKey[5] = "";
// ADD 2008.07.09 東都）高木 ＭＡＣアドレス取得の強化 END
				}
// DEL 2008.07.09 東都）高木 ＭＡＣアドレス取得の強化 START
//				// ＭＡＣアドレスの取得
//				sKey[5] = GetMacAddress(sKey[4]);
// DEL 2008.07.09 東都）高木 ＭＡＣアドレス取得の強化 END
			}
			catch(Exception)
			{
				sKey[3] = "";
				sKey[4] = "";
				sKey[5] = "";
			}
// ADD 2008.06.17 東都）高木 ＭＡＣアドレスチェックの追加 END

// ADD 2005.05.09 東都）高木 デモ対応 START
			if(tex利用者ＣＤ.Text == "demo")
			{
				sKey[0] = "demo";
			}
// ADD 2005.05.09 東都）高木 デモ対応 END

			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sRet = {""};
			try
			{
				if(sv_init == null) sv_init = new is2init.Service1();
				//				sRet = sv_init.login(gsaユーザ,sKey);
				sRet = sv_init.login2(gsaユーザ,sKey);
			}
// ADD 2005.05.24 東都）高木 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				sRet[0] = gs通信エラー;
			}
// ADD 2005.05.24 東都）高木 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				sRet[0] = "通信エラー：" + ex.Message;
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;
			iログイントライ回数++;

			if(sRet[0].Length == 4)
			{
				gs利用者ＣＤ = sRet[3];
				gs利用者名   = sRet[4];
//				gsメッセージ += sRet[5];
// MOD 2005.05.17 東都）高木 起動時間を短くする START
				gs会員ＣＤ   = sRet[1];
				gs会員名     = sRet[2];
				gsプリンタＦＧ = sRet[6];
				gsプリンタ種類 = sRet[7];
// MOD 2005.05.17 東都）高木 起動時間を短くする END
// ADD 2005.06.07 東都）高木 都道府県選択の変更 START
				if(sRet[8].Length > 0)
					gi都道府県ＣＤ = int.Parse(sRet[8]);
// ADD 2005.06.07 東都）高木 都道府県選択の変更 END
// ADD 2005.05.09 東都）高木 デモ対応 START
				if(gs利用者ＣＤ == "demo")
				{
//					gs会員ＣＤ = "demo";
					gs端末ＣＤ = "demo";
				}
// ADD 2005.05.09 東都）高木 デモ対応 END
// ADD 2005.05.27 東都）小童谷 パスワードの保持 START
				StreamWriter sw = File.CreateText(gsInitFile);
				if(cBox保持.Checked == true)
				{
					sw.WriteLine(tex利用者ＣＤ.Text);
// MOD 2008.03.13 東都）高木 Vista対応 START
//					sw.WriteLine(texパスワード.Text);
					if(gbInitFileExt){
						sw.WriteLine(暗号化(texパスワード.Text));
					}else{
						sw.WriteLine(texパスワード.Text);
					}
// MOD 2008.03.13 東都）高木 Vista対応 END
					sw.WriteLine(s端末);
				}
				else
				{
					sw.WriteLine("");
					sw.WriteLine("");
					sw.WriteLine(s端末);
				}
				sw.Close();

// ADD 2005.05.27 東都）小童谷 パスワードの保持 END
// ADD 2008.06.30 東都）高木 パスワードチェックの強化 START
				if(sRet[0].Equals("正常終了")){
					;
				}else if(sRet[0].Equals("期限切れ")){
					MessageBox.Show("パスワードの有効期限が切れました。\n"
									+ "パスワードの変更をお願い致します。"
									, "ログイン", 
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
				this.Close();
			}
// ADD 2005.07.01 東都）高木 端末情報が削除されていた場合の対応 START
			else if(sRet[0].Length == 5)
			{
				MessageBox.Show("端末情報が存在しません。初期登録をお願い致します。", "ログイン", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);

// ADD 2005.07.05 東都）高木 端末情報が削除されていた場合の対応 START
				// 初期設定ファイルのクリア
				StreamWriter sw = File.CreateText(gsInitFile);
				sw.WriteLine("");
				sw.WriteLine("");
				sw.WriteLine("");
				sw.Close();

				初期登録 F初期登録 = new 初期登録();
				F初期登録.ShowDialog();
				StreamReader sr = File.OpenText(gsInitFile);
				gs端末ＣＤ = sr.ReadLine();
				gs端末ＣＤ = sr.ReadLine();
				gs端末ＣＤ = sr.ReadLine();
				sr.Close();

				gsaユーザ[2] = gs端末ＣＤ;
// ADD 2005.07.05 東都）高木 端末情報が削除されていた場合の対応 END

				this.Close();
			}
// ADD 2005.07.01 東都）高木 端末情報が削除されていた場合の対応 END
			else
			{
				MessageBox.Show(sRet[0], "ログイン", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				if(iログイントライ回数 >= 10) this.Close();
				texパスワード.Focus();
			}
		}

		private void texパスワード_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnログイン_Click(sender, e);
			}
		}

		private void ログイン_Load(object sender, System.EventArgs e)
		{
// MOD 2005.05.17 東都）高木 起動時間を短くする START
//			picログオン.Image = Image.FromFile("img\\login.gif");
// MOD 2011.04.05 東都）高木 画面イメージのロード変更 START
//			try{
//				picログオン.Image = Image.FromFile("img\\login.gif");
//			}catch{
//			}
			picログオン.Image = Image_FromFile("img\\login.gif");
// MOD 2011.04.05 東都）高木 画面イメージのロード変更 END
// MOD 2005.05.17 東都）高木 起動時間を短くする END
// ADD 2007.10.26 東都）高木 バージョン情報の表示 START
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
// MOD 2009.10.16 東都）高木 プロキシ機能表記の追加 START
			if(gbInitProxyExists) labバージョン.Text += " p";
// MOD 2009.10.16 東都）高木 プロキシ機能表記の追加 END
// ADD 2007.10.26 東都）高木 バージョン情報の表示 END
// ADD 2005.05.27 東都）小童谷 パスワードの保持 START
			StreamReader sr = File.OpenText(gsInitFile);
			tex利用者ＣＤ.Text = sr.ReadLine();
// MOD 2008.03.13 東都）高木 Vista対応 START
//			texパスワード.Text = sr.ReadLine();
			if(gbInitFileExt){
				texパスワード.Text = 復号化(sr.ReadLine());
			}else{
				texパスワード.Text = sr.ReadLine();
			}
// MOD 2008.03.13 東都）高木 Vista対応 END
			s端末 = sr.ReadLine();
			sr.Close();
			if(tex利用者ＣＤ.Text.Trim().Length != 0)
				cBox保持.Checked = true;
// ADD 2005.05.27 東都）小童谷 パスワードの保持 END
		}

// ADD 2008.06.17 東都）高木 ＭＡＣアドレスチェックの追加 START
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

			unsafe
			{
				fixed (byte* pbyData = &byData[uiPos])
				{
					return *((uint*)pbyData);
				}
			}
		}
// ADD 2008.06.17 東都）高木 ＭＡＣアドレスチェックの追加 END
// MOD 2011.04.05 東都）高木 画面イメージのロード変更 START
		private Image Image_FromFile(string sイメージファイル)
		{
			Image retImage = null;
			try{
//				retImage = Image.FromFile(gsアプリフォルダ+"\\"+sイメージファイル);
				FileStream fs = new FileStream(gsアプリフォルダ+"\\"+sイメージファイル
										, FileMode.Open, FileAccess.Read); 
				Bitmap bmp = (Bitmap)System.Drawing.Bitmap.FromStream(fs); 
				fs.Close(); 
				retImage = new Bitmap(bmp); 
			}catch{
			}
			return retImage;
		}
// MOD 2011.04.05 東都）高木 画面イメージのロード変更 END
	}
}
