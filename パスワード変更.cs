using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace IS2Client
{
	/// <summary>
	/// [パスワード変更]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// ADD 2008.06.30 東都）高木 パスワードチェックの強化 
	//--------------------------------------------------------------------------
	public class パスワード変更 : 共通フォーム
	{
// ADD 2008.06.30 東都）高木 パスワードチェックの強化 START
		public string sモード = "";
		public string s結果   = "";
// ADD 2008.06.30 東都）高木 パスワードチェックの強化 END

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn更新;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.Label lab新パスワード;
		private System.Windows.Forms.Label labパスワード変更タイトル;
		private 共通テキストボックス texパスワード;
		private System.Windows.Forms.Label lab再入力;
		private 共通テキストボックス tex再入力;
		private System.Windows.Forms.GroupBox groupBox1;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public パスワード変更()
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
			this.texパスワード = new IS2Client.共通テキストボックス();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lab再入力 = new System.Windows.Forms.Label();
			this.tex再入力 = new IS2Client.共通テキストボックス();
			this.label1 = new System.Windows.Forms.Label();
			this.lab新パスワード = new System.Windows.Forms.Label();
			this.btn更新 = new System.Windows.Forms.Button();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.panel7 = new System.Windows.Forms.Panel();
			this.labパスワード変更タイトル = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1.SuspendLayout();
			this.panel7.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// texパスワード
			// 
			this.texパスワード.BackColor = System.Drawing.SystemColors.Window;
			this.texパスワード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texパスワード.Location = new System.Drawing.Point(152, 22);
			this.texパスワード.MaxLength = 40;
			this.texパスワード.Name = "texパスワード";
			this.texパスワード.PasswordChar = '*';
			this.texパスワード.Size = new System.Drawing.Size(170, 23);
			this.texパスワード.TabIndex = 1;
			this.texパスワード.Text = "";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Honeydew;
			this.panel1.Controls.Add(this.lab再入力);
			this.panel1.Controls.Add(this.tex再入力);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.lab新パスワード);
			this.panel1.Controls.Add(this.texパスワード);
			this.panel1.Controls.Add(this.btn更新);
			this.panel1.Controls.Add(this.btn閉じる);
			this.panel1.Location = new System.Drawing.Point(1, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(361, 142);
			this.panel1.TabIndex = 0;
			// 
			// lab再入力
			// 
			this.lab再入力.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab再入力.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab再入力.Location = new System.Drawing.Point(46, 54);
			this.lab再入力.Name = "lab再入力";
			this.lab再入力.Size = new System.Drawing.Size(102, 14);
			this.lab再入力.TabIndex = 50;
			this.lab再入力.Text = "新パスワード再入力";
			// 
			// tex再入力
			// 
			this.tex再入力.BackColor = System.Drawing.SystemColors.Window;
			this.tex再入力.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex再入力.Location = new System.Drawing.Point(152, 50);
			this.tex再入力.MaxLength = 40;
			this.tex再入力.Name = "tex再入力";
			this.tex再入力.PasswordChar = '*';
			this.tex再入力.Size = new System.Drawing.Size(170, 23);
			this.tex再入力.TabIndex = 2;
			this.tex再入力.Text = "";
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
			// lab新パスワード
			// 
			this.lab新パスワード.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab新パスワード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab新パスワード.Location = new System.Drawing.Point(46, 26);
			this.lab新パスワード.Name = "lab新パスワード";
			this.lab新パスワード.Size = new System.Drawing.Size(102, 14);
			this.lab新パスワード.TabIndex = 42;
			this.lab新パスワード.Text = "新パスワード";
			// 
			// btn更新
			// 
			this.btn更新.BackColor = System.Drawing.Color.PaleGreen;
			this.btn更新.ForeColor = System.Drawing.Color.Blue;
			this.btn更新.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn更新.Location = new System.Drawing.Point(260, 86);
			this.btn更新.Name = "btn更新";
			this.btn更新.Size = new System.Drawing.Size(54, 48);
			this.btn更新.TabIndex = 4;
			this.btn更新.Text = "保存";
			this.btn更新.Click += new System.EventHandler(this.btn更新_Click);
			// 
			// btn閉じる
			// 
			this.btn閉じる.BackColor = System.Drawing.Color.PaleGreen;
			this.btn閉じる.ForeColor = System.Drawing.Color.Red;
			this.btn閉じる.Location = new System.Drawing.Point(66, 86);
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
			this.panel7.Controls.Add(this.labパスワード変更タイトル);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(364, 26);
			this.panel7.TabIndex = 13;
			// 
			// labパスワード変更タイトル
			// 
			this.labパスワード変更タイトル.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.labパスワード変更タイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labパスワード変更タイトル.ForeColor = System.Drawing.Color.White;
			this.labパスワード変更タイトル.Location = new System.Drawing.Point(12, 2);
			this.labパスワード変更タイトル.Name = "labパスワード変更タイトル";
			this.labパスワード変更タイトル.Size = new System.Drawing.Size(264, 24);
			this.labパスワード変更タイトル.TabIndex = 0;
			this.labパスワード変更タイトル.Text = "パスワード変更";
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
			// パスワード変更
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
			this.Name = "パスワード変更";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 パスワード変更";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
			this.Load += new System.EventHandler(this.パスワード変更_Load);
			this.Closed += new System.EventHandler(this.パスワード変更_Closed);
			this.panel1.ResumeLayout(false);
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
// ADD 2008.06.30 東都）高木 パスワードチェックの強化 START
			s結果 = "";
// ADD 2008.06.30 東都）高木 パスワードチェックの強化 END
			this.Close();
		}

		private void btn更新_Click(object sender, System.EventArgs e)
		{
			// 空白除去
			texパスワード.Text = texパスワード.Text.Trim();
			tex再入力.Text     = tex再入力.Text.Trim();
			// 項目チェック
			if(!必須チェック(texパスワード,"パスワード")) return;
			if(!必須チェック(tex再入力,"再入力")) return;
			if(!半角チェック(texパスワード,"パスワード")) return;
			if(!半角チェック(tex再入力,"再入力")) return;
			// パスワードチェック
			if(texパスワード.Text != tex再入力.Text)
			{
				MessageBox.Show("パスワードと再入力の内容が異なっています。\n再度入力してください。",
								"エラー",MessageBoxButtons.OK);
				texパスワード.Focus();
				return;
			}

			// 利用者マスタの更新
			String[] sKey = new string[5];
			sKey[0] = gs会員ＣＤ;
			sKey[1] = gs利用者ＣＤ;
			sKey[2] = texパスワード.Text;
			sKey[3] = "パス変更";
			sKey[4] = gs利用者ＣＤ;

			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string sRet = "";
			try
			{
				if(sv_init == null) sv_init = new is2init.Service1();
				sRet = sv_init.Upd_riyou(gsaユーザ,sKey);
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				sRet = gs通信エラー;
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				sRet = "通信エラー：" + ex.Message;
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;

			if(sRet.Length == 4)
			{
// ADD 2008.06.30 東都）高木 パスワードチェックの強化 START
				s結果 = "更新";
// ADD 2008.06.30 東都）高木 パスワードチェックの強化 END
// MOD 2009.05.28 東都）高木 パスワード変更時の初期設定ファイルへの書込機能追加 START
				// 初期設定ファイルのパスワード書換え
				string[] s初期設定 = new string[]{"","","","",""};
				int iPos = 0;

				StreamReader sr = File.OpenText(gsInitFile);
				for(iPos = 0; iPos < s初期設定.Length; iPos++){
					s初期設定[iPos] = sr.ReadLine();
					if(s初期設定[iPos] == null){
						s初期設定[iPos] = "";
						break;
					}
				}
				sr.Close();

				if(s初期設定[0].Length > 0){
					if(gbInitFileExt){
						s初期設定[1] = 暗号化(texパスワード.Text);
					}else{
						s初期設定[1] = texパスワード.Text;
					}
					StreamWriter sw = File.CreateText(gsInitFile);
					for(iPos = 0; iPos < s初期設定.Length; iPos++){
						sw.WriteLine(s初期設定[iPos]);
					}
					sw.Close();
				}
// MOD 2009.05.28 東都）高木 パスワード変更時の初期設定ファイルへの書込機能追加 END
				this.Close();
			}
			else
			{
				MessageBox.Show(sRet,"エラー",MessageBoxButtons.OK);
			}
		}

// ADD 2005.05.24 東都）小童谷 フォーカス移動 START
		private void パスワード変更_Closed(object sender, System.EventArgs e)
		{
			texパスワード.Text = "";
			tex再入力.Text     = "";
			texパスワード.Focus();
// ADD 2008.06.30 東都）高木 パスワードチェックの強化 START
			sモード = "";
// ADD 2008.06.30 東都）高木 パスワードチェックの強化 END
		}
// ADD 2005.05.24 東都）小童谷 フォーカス移動 END

// ADD 2008.06.30 東都）高木 パスワードチェックの強化 START
		private void パスワード変更_Load(object sender, System.EventArgs e)
		{
			if(sモード.Equals("期限切れ") || sモード.Equals("パス変更")){
				this.btn閉じる.Text = "ｷｬﾝｾﾙ";
			}
		}
// ADD 2008.06.30 東都）高木 パスワードチェックの強化 END
// MOD 2009.05.28 東都）高木 パスワード変更時の初期設定ファイルへの書込機能追加 START
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
// MOD 2009.05.28 東都）高木 パスワード変更時の初期設定ファイルへの書込機能追加 END
	}
}
