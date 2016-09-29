using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [ログイン２]（お届先全件削除用）
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// MOD 2011.04.05 東都）高木 画面イメージのロード変更 
	//--------------------------------------------------------------------------
	public class ログイン２ : 共通フォーム
	{
		private int iログイントライ回数 = 0;

		public bool b削除ログイン = false;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnログイン;
		private System.Windows.Forms.Label lab利用者ＣＤ;
		private 共通テキストボックス tex利用者ＣＤ;
		private System.Windows.Forms.Label labパスワード;
		private 共通テキストボックス texパスワード;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox picログオン;

		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ログイン２()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ログイン２));
			this.tex利用者ＣＤ = new IS2Client.共通テキストボックス();
			this.panel1 = new System.Windows.Forms.Panel();
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
			this.tex利用者ＣＤ.Location = new System.Drawing.Point(134, 84);
			this.tex利用者ＣＤ.MaxLength = 6;
			this.tex利用者ＣＤ.Name = "tex利用者ＣＤ";
			this.tex利用者ＣＤ.Size = new System.Drawing.Size(170, 23);
			this.tex利用者ＣＤ.TabIndex = 0;
			this.tex利用者ＣＤ.Text = "";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
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
			this.labパスワード.Location = new System.Drawing.Point(58, 114);
			this.labパスワード.Name = "labパスワード";
			this.labパスワード.Size = new System.Drawing.Size(74, 14);
			this.labパスワード.TabIndex = 50;
			this.labパスワード.Text = "パスワード：";
			// 
			// texパスワード
			// 
			this.texパスワード.BackColor = System.Drawing.SystemColors.Window;
			this.texパスワード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texパスワード.Location = new System.Drawing.Point(134, 110);
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
			this.lab利用者ＣＤ.Location = new System.Drawing.Point(58, 88);
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
			// ログイン２
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(365, 168);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox1);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(373, 202);
			this.Name = "ログイン２";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "is-2 ログイン";
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 START
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Onエンター移動);
            //this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Onエンターキャンセル);
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 END
            this.Load += new System.EventHandler(this.ログイン２_Load);
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
			tex利用者ＣＤ.Focus();
			b削除ログイン = false;
			this.Close();
		}

		private void btnログイン_Click(object sender, System.EventArgs e)
		{
			// 空白除去
			tex利用者ＣＤ.Text = tex利用者ＣＤ.Text.Trim();
			texパスワード.Text = texパスワード.Text.Trim();
			// 項目チェック
			if(!必須チェック(tex利用者ＣＤ,"ユーザー")) return;
			if(!必須チェック(texパスワード,"パスワード")) return;
			if(!パスワードチェック(tex利用者ＣＤ,"ユーザー")) return;
			if(!パスワードチェック(texパスワード,"パスワード")) return;

			// 利用者マスタの検索
			String[] sKey = new string[]{
				gs会員ＣＤ,
				tex利用者ＣＤ.Text,
				texパスワード.Text,
				gs部門ＣＤ
			};

			if(tex利用者ＣＤ.Text == "demo")
			{
				sKey[0] = "demo";
			}

			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sRet = {""};
			try
			{
				if(sv_init == null) sv_init = new is2init.Service1();
				sRet = sv_init.login3(gsaユーザ,sKey);
			}
			catch (System.Net.WebException)
			{
				sRet[0] = gs通信エラー;
			}
			catch (Exception ex)
			{
				sRet[0] = "通信エラー：" + ex.Message;
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;
			iログイントライ回数++;

			if(sRet[0].Length == 4)
			{
				tex利用者ＣＤ.Focus();
				b削除ログイン = true;
				this.Close();
			}
			else
			{
				MessageBox.Show(sRet[0], "ログイン", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				if(iログイントライ回数 >= 10)
				{
					b削除ログイン = false;
					this.Close();
				}
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

		private void ログイン２_Load(object sender, System.EventArgs e)
		{
// MOD 2011.04.05 東都）高木 画面イメージのロード変更 START
//			try{
//				picログオン.Image = Image.FromFile("img\\login.gif");
//			}catch{
//			}
			picログオン.Image = Image_FromFile("img\\login.gif");
// MOD 2011.04.05 東都）高木 画面イメージのロード変更 END
			tex利用者ＣＤ.Text = "";
			texパスワード.Text = "";
			tex利用者ＣＤ.Focus();
		}
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
