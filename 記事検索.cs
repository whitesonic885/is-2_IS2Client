using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [記事登録]、[記事検索]、[輸送商品検索]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// MOD 2010.02.02 東都）高木 先頭に空白行を入れる 
	// MOD 2010.02.12 東都）高木 上記修正は[記事登録]、[記事検索]に適用する 
	// MOD 2010.03.01 東都）高木 全角半角混在可能にする 
	// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 
	// MOD 2010.05.25 東都）高木 時間指定の変更 
	// MOD 2010.09.02 東都）高木 選択時のずれの対応 
	//--------------------------------------------------------------------------
	// MOD 2011.01.25 東都）高木 「ロードに失敗」対応 
	// MOD 2011.06.07 東都）高木 王子運送の対応 
	//--------------------------------------------------------------------------
	public class 記事検索 : 共通フォーム
	{
		public string sKcode;
		public string s記事;
		public string sKcode2;
		public string s記事２;
// ADD 2005.05.16 東都）伊賀 輸送指示判定用 START
		public bool b輸送指示;
// ADD 2005.05.16 東都）伊賀 輸送指示判定用 END
// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 START
		public string s輸送商品部門 = "";
// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 START

		private short    nOldRow    = 0;
		private string   s更新日時 = "";
		private string[] s記事一覧;
		private int      i現在頁数;
		private int      i最大頁数;
		private int      i開始数;
		private int      i終了数;
		
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Button btn確定;
		public  System.Windows.Forms.Label lab記事タイトル;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.Button btn閉じる;
		private AxGTABLE32V2Lib.AxGTable32 axGT記事;
		private System.Windows.Forms.Button btn一覧表;
		private System.Windows.Forms.Label lab記事名;
		private 共通テキストボックス tex記事名;
		private 共通テキストボックス tex記事コード;
		private System.Windows.Forms.Button btn削除;
		private System.Windows.Forms.Button btn更新;
		private System.Windows.Forms.Label lab頁番号;
		private System.Windows.Forms.Button btn次頁;
		private System.Windows.Forms.Button btn前頁;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lab記事コード;
		private System.Windows.Forms.Label labコード必須;
		private System.Windows.Forms.Label lab名称必須;
		private System.Windows.Forms.Button btn戻る;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public 記事検索()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
			ＤＰＩ表示サイズ変換();
//			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
				this.axGT記事.Size = new System.Drawing.Size(320, 308);
//			}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(記事検索));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn戻る = new System.Windows.Forms.Button();
            this.lab頁番号 = new System.Windows.Forms.Label();
            this.btn次頁 = new System.Windows.Forms.Button();
            this.btn前頁 = new System.Windows.Forms.Button();
            this.btn更新 = new System.Windows.Forms.Button();
            this.btn削除 = new System.Windows.Forms.Button();
            this.lab記事コード = new System.Windows.Forms.Label();
            this.tex記事コード = new IS2Client.共通テキストボックス();
            this.labコード必須 = new System.Windows.Forms.Label();
            this.lab名称必須 = new System.Windows.Forms.Label();
            this.lab記事名 = new System.Windows.Forms.Label();
            this.tex記事名 = new IS2Client.共通テキストボックス();
            this.axGT記事 = new AxGTABLE32V2Lib.AxGTable32();
            this.btn確定 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lab記事タイトル = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btn一覧表 = new System.Windows.Forms.Button();
            this.texメッセージ = new System.Windows.Forms.TextBox();
            this.btn閉じる = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ds送り状)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGT記事)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Honeydew;
            this.panel1.Controls.Add(this.btn戻る);
            this.panel1.Controls.Add(this.lab頁番号);
            this.panel1.Controls.Add(this.btn次頁);
            this.panel1.Controls.Add(this.btn前頁);
            this.panel1.Controls.Add(this.btn更新);
            this.panel1.Controls.Add(this.btn削除);
            this.panel1.Controls.Add(this.lab記事コード);
            this.panel1.Controls.Add(this.tex記事コード);
            this.panel1.Controls.Add(this.labコード必須);
            this.panel1.Controls.Add(this.lab名称必須);
            this.panel1.Controls.Add(this.lab記事名);
            this.panel1.Controls.Add(this.tex記事名);
            this.panel1.Controls.Add(this.axGT記事);
            this.panel1.Controls.Add(this.btn確定);
            this.panel1.Location = new System.Drawing.Point(1, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 446);
            this.panel1.TabIndex = 0;
            // 
            // btn戻る
            // 
            this.btn戻る.BackColor = System.Drawing.Color.SteelBlue;
            this.btn戻る.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn戻る.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn戻る.ForeColor = System.Drawing.Color.White;
            this.btn戻る.Location = new System.Drawing.Point(230, 410);
            this.btn戻る.Name = "btn戻る";
            this.btn戻る.Size = new System.Drawing.Size(64, 22);
            this.btn戻る.TabIndex = 4;
            this.btn戻る.Text = "戻る";
            this.btn戻る.UseVisualStyleBackColor = false;
            this.btn戻る.Click += new System.EventHandler(this.btn戻る_Click);
            // 
            // lab頁番号
            // 
            this.lab頁番号.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab頁番号.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab頁番号.Location = new System.Drawing.Point(282, 326);
            this.lab頁番号.Name = "lab頁番号";
            this.lab頁番号.Size = new System.Drawing.Size(48, 14);
            this.lab頁番号.TabIndex = 64;
            this.lab頁番号.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn次頁
            // 
            this.btn次頁.BackColor = System.Drawing.Color.SteelBlue;
            this.btn次頁.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn次頁.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn次頁.ForeColor = System.Drawing.Color.White;
            this.btn次頁.Location = new System.Drawing.Point(330, 322);
            this.btn次頁.Name = "btn次頁";
            this.btn次頁.Size = new System.Drawing.Size(48, 22);
            this.btn次頁.TabIndex = 63;
            this.btn次頁.Text = "次頁";
            this.btn次頁.UseVisualStyleBackColor = false;
            this.btn次頁.Click += new System.EventHandler(this.btn次頁_Click);
            // 
            // btn前頁
            // 
            this.btn前頁.BackColor = System.Drawing.Color.SteelBlue;
            this.btn前頁.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn前頁.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn前頁.ForeColor = System.Drawing.Color.White;
            this.btn前頁.Location = new System.Drawing.Point(234, 322);
            this.btn前頁.Name = "btn前頁";
            this.btn前頁.Size = new System.Drawing.Size(48, 22);
            this.btn前頁.TabIndex = 62;
            this.btn前頁.Text = "前頁";
            this.btn前頁.UseVisualStyleBackColor = false;
            this.btn前頁.Click += new System.EventHandler(this.btn前頁_Click);
            // 
            // btn更新
            // 
            this.btn更新.BackColor = System.Drawing.Color.SteelBlue;
            this.btn更新.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn更新.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn更新.ForeColor = System.Drawing.Color.White;
            this.btn更新.Location = new System.Drawing.Point(158, 410);
            this.btn更新.Name = "btn更新";
            this.btn更新.Size = new System.Drawing.Size(64, 22);
            this.btn更新.TabIndex = 3;
            this.btn更新.Text = "保存";
            this.btn更新.UseVisualStyleBackColor = false;
            this.btn更新.Click += new System.EventHandler(this.btn更新_Click);
            // 
            // btn削除
            // 
            this.btn削除.BackColor = System.Drawing.Color.SteelBlue;
            this.btn削除.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn削除.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn削除.ForeColor = System.Drawing.Color.White;
            this.btn削除.Location = new System.Drawing.Point(230, 410);
            this.btn削除.Name = "btn削除";
            this.btn削除.Size = new System.Drawing.Size(64, 22);
            this.btn削除.TabIndex = 4;
            this.btn削除.Text = "削除";
            this.btn削除.UseVisualStyleBackColor = false;
            this.btn削除.Click += new System.EventHandler(this.btn削除_Click);
            // 
            // lab記事コード
            // 
            this.lab記事コード.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab記事コード.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab記事コード.Location = new System.Drawing.Point(22, 352);
            this.lab記事コード.Name = "lab記事コード";
            this.lab記事コード.Size = new System.Drawing.Size(58, 14);
            this.lab記事コード.TabIndex = 61;
            this.lab記事コード.Text = "記事コード";
            // 
            // tex記事コード
            // 
            this.tex記事コード.BackColor = System.Drawing.SystemColors.Window;
            this.tex記事コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex記事コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tex記事コード.Location = new System.Drawing.Point(80, 348);
            this.tex記事コード.MaxLength = 4;
            this.tex記事コード.Name = "tex記事コード";
            this.tex記事コード.Size = new System.Drawing.Size(60, 23);
            this.tex記事コード.TabIndex = 1;
            this.tex記事コード.Text = "1234";
            // 
            // labコード必須
            // 
            this.labコード必須.ForeColor = System.Drawing.Color.Red;
            this.labコード必須.Location = new System.Drawing.Point(8, 352);
            this.labコード必須.Name = "labコード必須";
            this.labコード必須.Size = new System.Drawing.Size(14, 14);
            this.labコード必須.TabIndex = 59;
            this.labコード必須.Text = "※";
            // 
            // lab名称必須
            // 
            this.lab名称必須.ForeColor = System.Drawing.Color.Red;
            this.lab名称必須.Location = new System.Drawing.Point(8, 382);
            this.lab名称必須.Name = "lab名称必須";
            this.lab名称必須.Size = new System.Drawing.Size(14, 14);
            this.lab名称必須.TabIndex = 57;
            this.lab名称必須.Text = "※";
            // 
            // lab記事名
            // 
            this.lab記事名.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab記事名.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab記事名.Location = new System.Drawing.Point(22, 382);
            this.lab記事名.Name = "lab記事名";
            this.lab記事名.Size = new System.Drawing.Size(58, 14);
            this.lab記事名.TabIndex = 56;
            this.lab記事名.Text = "記事名";
            // 
            // tex記事名
            // 
            this.tex記事名.BackColor = System.Drawing.SystemColors.Window;
            this.tex記事名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex記事名.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tex記事名.Location = new System.Drawing.Point(80, 378);
            this.tex記事名.MaxLength = 30;
            this.tex記事名.Name = "tex記事名";
            this.tex記事名.Size = new System.Drawing.Size(368, 23);
            this.tex記事名.TabIndex = 2;
            this.tex記事名.Text = "MMMMMMMMMWMMMMMMMMMWMMMMMMMMMW";
            // 
            // axGT記事
            // 
            this.axGT記事.DataSource = null;
            this.axGT記事.Location = new System.Drawing.Point(64, 10);
            this.axGT記事.Name = "axGT記事";
            this.axGT記事.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT記事.OcxState")));
            this.axGT記事.Size = new System.Drawing.Size(320, 308);
            this.axGT記事.TabIndex = 0;
            this.axGT記事.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT記事_CurPlaceChanged);
            this.axGT記事.CelClick += new AxGTABLE32V2Lib._DGTable32Events_CelClickEventHandler(this.axGT記事_CelClick);
            this.axGT記事.CelDblClick += new AxGTABLE32V2Lib._DGTable32Events_CelDblClickEventHandler(this.axGT記事_CelDblClick);
            this.axGT記事.KeyDownEvent += new AxGTABLE32V2Lib._DGTable32Events_KeyDownEventHandler(this.axGT記事_KeyDownEvent);
            // 
            // btn確定
            // 
            this.btn確定.BackColor = System.Drawing.Color.SteelBlue;
            this.btn確定.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn確定.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn確定.ForeColor = System.Drawing.Color.White;
            this.btn確定.Location = new System.Drawing.Point(302, 410);
            this.btn確定.Name = "btn確定";
            this.btn確定.Size = new System.Drawing.Size(64, 22);
            this.btn確定.TabIndex = 5;
            this.btn確定.Text = "確定";
            this.btn確定.UseVisualStyleBackColor = false;
            this.btn確定.Click += new System.EventHandler(this.btn確定_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.panel7.Controls.Add(this.lab記事タイトル);
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(800, 26);
            this.panel7.TabIndex = 13;
            // 
            // lab記事タイトル
            // 
            this.lab記事タイトル.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab記事タイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab記事タイトル.ForeColor = System.Drawing.Color.White;
            this.lab記事タイトル.Location = new System.Drawing.Point(12, 2);
            this.lab記事タイトル.Name = "lab記事タイトル";
            this.lab記事タイトル.Size = new System.Drawing.Size(264, 24);
            this.lab記事タイトル.TabIndex = 0;
            this.lab記事タイトル.Text = "記事検索";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.PaleGreen;
            this.panel8.Controls.Add(this.btn一覧表);
            this.panel8.Controls.Add(this.texメッセージ);
            this.panel8.Controls.Add(this.btn閉じる);
            this.panel8.Location = new System.Drawing.Point(0, 516);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(800, 58);
            this.panel8.TabIndex = 1;
            // 
            // btn一覧表
            // 
            this.btn一覧表.ForeColor = System.Drawing.Color.Blue;
            this.btn一覧表.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn一覧表.Location = new System.Drawing.Point(68, 6);
            this.btn一覧表.Name = "btn一覧表";
            this.btn一覧表.Size = new System.Drawing.Size(54, 48);
            this.btn一覧表.TabIndex = 7;
            this.btn一覧表.Text = "一覧表　印刷";
            this.btn一覧表.Click += new System.EventHandler(this.btn一覧表_Click);
            // 
            // texメッセージ
            // 
            this.texメッセージ.BackColor = System.Drawing.Color.PaleGreen;
            this.texメッセージ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.texメッセージ.ForeColor = System.Drawing.Color.Red;
            this.texメッセージ.Location = new System.Drawing.Point(126, 4);
            this.texメッセージ.Multiline = true;
            this.texメッセージ.Name = "texメッセージ";
            this.texメッセージ.ReadOnly = true;
            this.texメッセージ.Size = new System.Drawing.Size(336, 50);
            this.texメッセージ.TabIndex = 0;
            this.texメッセージ.TabStop = false;
            // 
            // btn閉じる
            // 
            this.btn閉じる.ForeColor = System.Drawing.Color.Red;
            this.btn閉じる.Location = new System.Drawing.Point(8, 6);
            this.btn閉じる.Name = "btn閉じる";
            this.btn閉じる.Size = new System.Drawing.Size(54, 48);
            this.btn閉じる.TabIndex = 6;
            this.btn閉じる.TabStop = false;
            this.btn閉じる.Text = "閉じる";
            this.btn閉じる.Click += new System.EventHandler(this.btn閉じる_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(0, 0);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 0;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(0, 0);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.PaleGreen;
            this.panel6.Location = new System.Drawing.Point(0, 26);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(800, 26);
            this.panel6.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(6, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 454);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // 記事検索
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(468, 574);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(474, 607);
            this.Name = "記事検索";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "is-2 記事検索";
            this.Closed += new System.EventHandler(this.記事検索_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Onエンター移動);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Onエンターキャンセル);
            ((System.ComponentModel.ISupportInitialize)(this.ds送り状)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGT記事)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
			sKcode    = "";
			s記事     = "";
			sKcode2   = "";
			s記事２   = "";

			axGT記事.Cols = 3;
// MOD 2010.02.02 東都）高木 先頭に空白行を入れる START
//			axGT記事.Rows = 15;
			axGT記事.Rows = 16;
// MOD 2010.02.02 東都）高木 先頭に空白行を入れる START
			axGT記事.ColSep = "|";

			axGT記事.set_RowsText(0, "|コード|記事||");

// MOD 2010.03.01 東都）高木 全角半角混在可能にする START
//			axGT記事.ColsWidth = "0|4|10.9|0|";
			axGT記事.ColsWidth = "0|3.4|21.2|0|";
// MOD 2010.03.01 東都）高木 全角半角混在可能にする END
// MOD 2010.09.02 東都）高木 選択時のずれの対応 START
			カラム幅の補正(axGT記事);
// MOD 2010.09.02 東都）高木 選択時のずれの対応 END
			axGT記事.ColsAlignHorz = "1|1|0|0|";
            
//			axGT記事.set_CelForeColor(axGT記事.CaretRow,0,111111);
			axGT記事.set_CelForeColor(axGT記事.CaretRow,0,0x98FB98);  //BGR
			axGT記事.set_CelBackColor(axGT記事.CaretRow,0,0x006000);

			// ADD 2005.05.16 東都）伊賀 輸送指示は更新できない START
			if(b輸送指示)
			{
				labコード必須.Visible = false;
				lab記事コード.Visible = false;
				tex記事コード.Visible = false;
				lab名称必須.Visible = false;
				lab記事名.Visible = false;
				tex記事名.Visible = false;
				btn更新.Visible = false;
				btn削除.Visible = false;
// ADD 2005.07.22 東都）小童谷 戻るボタン追加 START
				btn戻る.Visible = false;
// ADD 2005.07.22 東都）小童谷 戻るボタン追加 END
// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
//				this.Width = 800;
//				this.texメッセージ.Width = 656;
// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 END
			}
			else
			{
				labコード必須.Visible = true;
				lab記事コード.Visible = true;
				tex記事コード.Visible = true;
				lab名称必須.Visible = true;
				lab記事名.Visible = true;
				tex記事名.Visible = true;
				btn更新.Visible = true;
				btn削除.Visible = true;
// ADD 2005.07.22 東都）小童谷 戻るボタン追加 START
				btn戻る.Visible = false;
// ADD 2005.07.22 東都）小童谷 戻るボタン追加 END
// MOD 2010.03.01 東都）高木 全角半角混在可能にする START
//				this.Width = 396;
//				this.texメッセージ.Width = 256;
// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
//				this.Width = 474;
//				this.texメッセージ.Width = 336;
// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 END
// MOD 2010.03.01 東都）高木 全角半角混在可能にする END
			}
			// ADD 2005.05.16 東都）伊賀 輸送指示は更新できない END

			texメッセージ.Text = "検索中．．．";
			axGT記事.CaretRow = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 START
			axGT記事.CaretCol = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 END
			i現在頁数 = 1;
			記事一覧検索();
		}

		private void 記事一覧検索()
		{
			tex記事コード.Text = "";
			tex記事名.Text     = "";
			s更新日時        = "";
			
			s記事一覧 = new string[1];
			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
// MOD 2005.05.16 東都）伊賀 輸送指示は"default","yusoshiji"の記事を表示 START
				if(b輸送指示)
				{
// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 START
//					s記事一覧 = sv_kiji.Get_kiji(gsaユーザ,"default","yusoshiji");
// MOD 2011.06.07 東都）高木 王子運送の対応 START
				if (gs会員ＣＤ.Substring(0,1) != "J"){
// MOD 2011.06.07 東都）高木 王子運送の対応 END
					s記事一覧 = sv_kiji.Get_kiji(gsaユーザ,"yusoshohin", s輸送商品部門);
// MOD 2011.06.07 東都）高木 王子運送の対応 START
				}else{
					s記事一覧 = sv_kiji.Get_kiji(gsaユーザ,"Jyusoshohin", s輸送商品部門);
				}
// MOD 2011.06.07 東都）高木 王子運送の対応 END
// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 END
				}
				else
				{
					s記事一覧 = sv_kiji.Get_kiji(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
				}
// MOD 2005.05.16 東都）伊賀 輸送指示は"default","yusoshiji"の記事を表示 END
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				s記事一覧[0] = gs通信エラー;
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				s記事一覧[0] = "通信エラー：" + ex.Message;
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;

			texメッセージ.Text = s記事一覧[0];
			if(s記事一覧[0].Length == 4) //正常終了
			{
				texメッセージ.Text = "";
				i最大頁数 = (s記事一覧.Length - 2) / axGT記事.Rows + 1;
// MOD 2010.02.12 東都）高木 上記修正は[記事登録]、[記事検索]に適用する 
				if(!b輸送指示){
//				if(lab記事タイトル.Text.Equals("記事登録")){
					i最大頁数 = (s記事一覧.Length - 2) / (axGT記事.Rows - 1) + 1;
				}
// MOD 2010.02.12 東都）高木 上記修正は[記事登録]、[記事検索]に適用する END
				if (i現在頁数 > i最大頁数)
					i現在頁数 = i最大頁数;
				頁情報設定();
			}
			else
			{
				if (b輸送指示 &&  !s輸送商品部門.Equals("0000") && !sKcode2.Trim().Equals("")) 
				{
					//輸送商品親検索から遷移、輸送商品子なしの場合
					sKcode = "dumycode"; //ダミーのコード、念のため４桁以上
					s記事  = "";
					this.Close();
				}
				else
				{
					axGT記事.Clear();
					i現在頁数 = 1;
					btn前頁.Enabled = false;
					btn次頁.Enabled = false;
					lab頁番号.Text = "";
					ビープ音();
				}
			}
			if (b輸送指示 && !s輸送商品部門.Equals("0000")) //輸送商品子の場合
			{
				if (s記事一覧.Length == 2) //輸送商品子が一件の場合確定
				{
					btn確定_Click(null,null);
				}
// ADD 2005.07.22 東都）小童谷 戻るボタン追加 START
				else
				{
					btn戻る.Visible = true;
				}
// ADD 2005.07.22 東都）小童谷 戻るボタン追加 END
			}
		}
		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
			sKcode = "";
			this.Close();
		}

		private void axGT記事_CelClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelClickEvent e)
		{
			tex記事コード.Text = axGT記事.get_CelText(axGT記事.CaretRow,1).Trim();
			tex記事名.Text     = axGT記事.get_CelText(axGT記事.CaretRow,2).TrimEnd();
			s更新日時        = axGT記事.get_CelText(axGT記事.CaretRow,3).Trim();
		}
		private void axGT記事_CelDblClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelDblClickEvent e)
		{
			sKcode = axGT記事.get_CelText(axGT記事.CaretRow,1).Trim();
			s記事  = axGT記事.get_CelText(axGT記事.CaretRow,2).TrimEnd();
			if(sKcode != "")
			{

				if(b輸送指示 && s輸送商品部門.Equals("0000")) //輸送商品親の場合、輸送商品子を表示
				{
					sKcode2 = sKcode;
					s記事２ = s記事;
					s輸送商品部門 = sKcode;
					sKcode  = "";
					s記事   = "";
					texメッセージ.Text = "検索中．．．";
					axGT記事.set_CelForeColor(nOldRow,0,0);
					axGT記事.set_CelBackColor(nOldRow,0,0xFFFFFF);
					axGT記事.CaretRow = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 START
					axGT記事.CaretCol = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 END
					axGT記事.set_CelForeColor(axGT記事.CaretRow,0,0x98FB98);  //BGR
					axGT記事.set_CelBackColor(axGT記事.CaretRow,0,0x006000);
					nOldRow = axGT記事.CaretRow;
					i現在頁数 = 1;
					記事一覧検索();
				}
				else if(b輸送指示 && !s輸送商品部門.Equals("0000")) //輸送商品子、時間指定まで以降の場合
				{
					if (sKcode.Length > 2 && sKcode.Substring(1).Equals("1X"))
					{
						if (g指定時間入力 == null) g指定時間入力 = new 指定時間入力();
						g指定時間入力.Left  = this.Left + 15;
						g指定時間入力.Top   = this.Top + 180;
						g指定時間入力.s記事 = "";
						g指定時間入力.lab時間区分.Text = "時まで";
// MOD 2005.06.10 東都）伊賀　時間指定方法変更 START
//						g指定時間入力.nUD指定時間.Minimum = 12;
//						g指定時間入力.nUD指定時間.Maximum = 21;
//						g指定時間入力.nUD指定時間.Value = 12;
// MOD 2010.05.25 東都）高木 時間指定の変更 START
//						string[] items = {"１２","１３","１４","１５","１６","１７","１８","１９","２０","２１"};
						string[] items = {"１２","１３","１４","１５","１６","１７","１８","１９","２０"};
// MOD 2010.05.25 東都）高木 時間指定の変更 END
						g指定時間入力.cmb指定時間.Items.Clear();
						g指定時間入力.cmb指定時間.Items.AddRange(items);
						g指定時間入力.cmb指定時間.SelectedIndex = 0;
// MOD 2005.06.10 東都）伊賀　時間指定方法変更 END
						g指定時間入力.ShowDialog(this);
						if (g指定時間入力.s記事.Length != 0)
						{
							s記事 = g指定時間入力.s記事;
// MOD 2010.03.01 東都）高木 全角半角混在可能にする START
							//記事登録の場合はクローズしない
							if(lab記事タイトル.Text.Equals("記事登録")) return;
// MOD 2010.03.01 東都）高木 全角半角混在可能にする END
							this.Close();
						}
					}
					else if (sKcode.Length > 2 && sKcode.Substring(1).Equals("2X"))
					{
						if (g指定時間入力 == null) g指定時間入力 = new 指定時間入力();
						g指定時間入力.Left  = this.Left + 15;
						g指定時間入力.Top   = this.Top + 180;
						g指定時間入力.s記事 = "";
						g指定時間入力.lab時間区分.Text = "時以降";
// MOD 2005.06.10 東都）伊賀　時間指定方法変更 START
//						g指定時間入力.nUD指定時間.Minimum = 10;
//						g指定時間入力.nUD指定時間.Maximum = 19;
//						g指定時間入力.nUD指定時間.Value = 10;
// MOD 2010.05.25 東都）高木 時間指定の変更 START
//						string[] items = {"１０","１１","１２","１３","１４","１５","１６","１７","１８","１９"};
						string[] items = {"１０","１１","１２","１３","１４","１５","１６","１７","１８"};
// MOD 2010.05.25 東都）高木 時間指定の変更 END
						g指定時間入力.cmb指定時間.Items.Clear();
						g指定時間入力.cmb指定時間.Items.AddRange(items);
						g指定時間入力.cmb指定時間.SelectedIndex = 0;
// MOD 2005.06.10 東都）伊賀　時間指定方法変更 END
						g指定時間入力.ShowDialog(this);
						if (g指定時間入力.s記事.Length != 0)
						{
							s記事 = g指定時間入力.s記事;
// MOD 2010.03.01 東都）高木 全角半角混在可能にする START
							//記事登録の場合はクローズしない
							if(lab記事タイトル.Text.Equals("記事登録")) return;
// MOD 2010.03.01 東都）高木 全角半角混在可能にする END
							this.Close();
						}
					}
					else
					{
// MOD 2010.03.01 東都）高木 全角半角混在可能にする START
							//記事登録の場合はクローズしない
							if(lab記事タイトル.Text.Equals("記事登録")) return;
// MOD 2010.03.01 東都）高木 全角半角混在可能にする END
						this.Close();
					}					
				}
				else
// MOD 2010.03.01 東都）高木 全角半角混在可能にする START
				{
					//記事登録の場合はクローズしない
					if(lab記事タイトル.Text.Equals("記事登録")) return;
// MOD 2010.03.01 東都）高木 全角半角混在可能にする END
					this.Close();
// MOD 2010.03.01 東都）高木 全角半角混在可能にする START
				}
// MOD 2010.03.01 東都）高木 全角半角混在可能にする END
			}
		}

		private void axGT記事_CurPlaceChanged(object sender, AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEvent e)
		{
			axGT記事.set_CelForeColor(nOldRow,0,0);
			axGT記事.set_CelBackColor(nOldRow,0,0xFFFFFF);
//			axGT記事.set_CelForeColor(axGT記事.CaretRow,0,111111);
			axGT記事.set_CelForeColor(axGT記事.CaretRow,0,0x98FB98);  //BGR
			axGT記事.set_CelBackColor(axGT記事.CaretRow,0,0x006000);
			nOldRow = axGT記事.CaretRow;
			tex記事コード.Text = axGT記事.get_CelText(axGT記事.CaretRow,1).Trim();
			tex記事名.Text     = axGT記事.get_CelText(axGT記事.CaretRow,2).TrimEnd();
			s更新日時          = axGT記事.get_CelText(axGT記事.CaretRow,3).Trim();
		}

		private void axGT記事_KeyDownEvent(object sender, AxGTABLE32V2Lib._DGTable32Events_KeyDownEvent e)
		{
			if (e.keyCode == 13)
			{
				btn確定_Click(sender, null);
			}
			if (e.keyCode == 9)
			{
				this.SelectNextControl(axGT記事, true, true, true, true);
			}
		}

		private void btn更新_Click(object sender, System.EventArgs e)
		{
			tex記事コード.Text = tex記事コード.Text.Trim();
			tex記事名.Text     = tex記事名.Text.TrimEnd();

			if(!必須チェック(tex記事コード,"記事コード")) return;
			if(!必須チェック(tex記事名,"記事名")) return;

			if(!半角チェック(tex記事コード,"記事コード")) return;
// MOD 2010.03.01 東都）高木 全角半角混在可能にする START
//			if(!全角チェック(tex記事名,"記事名")) return;
			if(!混在チェック(tex記事名,"記事名")) return;
// MOD 2010.03.01 東都）高木 全角半角混在可能にする END

			try
			{
				texメッセージ.Text = "";
				// カーソルを砂時計にする
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
				String[] sList = sv_kiji.Get_Skiji(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,tex記事コード.Text);
				// カーソルをデフォルトに戻す
				Cursor = System.Windows.Forms.Cursors.Default;

				// エラー時
				if(sList[0].Length != 2)
				{
					texメッセージ.Text = sList[0];
					ビープ音();
					return;
				}

				string s更新ＦＧ = sList[3];

				// 更新日時がことなる場合
//				if(s更新ＦＧ == "U" && tex記事名.Text != sList[1] && s更新日時 != sList[2])
				if(s更新ＦＧ == "U" && s更新日時 != sList[2])
				{
//					texメッセージ.Text = "排他エラー：他の端末で既に更新されていました";
					ビープ音();
					DialogResult rst;
					rst = MessageBox.Show("同一のコードが既に他の端末より登録されています。\n" 
										+ "記事一覧を最新にしますか？",
										"更新",
										MessageBoxButtons.YesNo,
										MessageBoxIcon.Error);
					if(rst == DialogResult.Yes)
					{
						記事一覧検索();
					}
					return;
				}

				String[] sIUList;
				string[] sData = new string[7];
				sData[0]  = gs会員ＣＤ;
				sData[1]  = gs部門ＣＤ;
				sData[2]  = tex記事コード.Text;
				sData[3]  = tex記事名.Text;
				sData[4]  = "記事登録";
				sData[5]  = gs利用者ＣＤ;
				sData[6]  = s更新日時;

				DialogResult result;
				if(s更新ＦＧ == "I")
				{
					result = MessageBox.Show("新規登録しますか？","登録",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						texメッセージ.Text = "登録中．．．";
						// カーソルを砂時計にする
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						sIUList = sv_kiji.Ins_kiji(gsaユーザ,sData);
						if(sIUList[0].Length == 4)
						{
							記事一覧検索();
						}
						else
						{
							texメッセージ.Text = sIUList[0];
							ビープ音();
						}
						// カーソルをデフォルトに戻す
						Cursor = System.Windows.Forms.Cursors.Default;
					}
				}
				else
				{
					result = MessageBox.Show("既に存在するデータに上書きしますか？","更新",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						// カーソルを砂時計にする
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						texメッセージ.Text = "更新中．．．";
						sIUList = sv_kiji.Upd_kiji(gsaユーザ,sData);
						if(sIUList[0].Length == 4)
						{
							記事一覧検索();
						}
						else
						{
							texメッセージ.Text = sIUList[0];
							ビープ音();
						}
						// カーソルをデフォルトに戻す
						Cursor = System.Windows.Forms.Cursors.Default;
					}
				}
			}
// ADD 2005.06.01 東都）高木 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				texメッセージ.Text = gs通信エラー;
				ビープ音();
			}
// ADD 2005.06.01 東都）高木 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				texメッセージ.Text = ex.Message;
				ビープ音();
			}
		}

		private void btn削除_Click(object sender, System.EventArgs e)
		{
			// 空白除去
			tex記事コード.Text = tex記事コード.Text.Trim();

			if(!必須チェック(tex記事コード,"記事コード")) return;
			if(!半角チェック(tex記事コード,"記事コード")) return;

			try
			{
				texメッセージ.Text = "";
				// カーソルを砂時計にする
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
				String[] sList = sv_kiji.Get_Skiji(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,tex記事コード.Text);
				// カーソルをデフォルトに戻す
				Cursor = System.Windows.Forms.Cursors.Default;

				string s更新ＦＧ = sList[3];

				String[] sDList;
				string[] sData = new string[5];

				DialogResult result;
				if(s更新ＦＧ == "I")
					MessageBox.Show("コード(" + tex記事コード.Text + ")のデータは存在しません","削除",MessageBoxButtons.OK);
				else
				{
					result = MessageBox.Show("コード(" + tex記事コード.Text + ")のデータを削除しますか？","削除",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						sData[0] = gs会員ＣＤ;
						sData[1] = gs部門ＣＤ;
						sData[2] = tex記事コード.Text;
						sData[3] = "記事登録";
						sData[4] = gs利用者ＣＤ;

						// カーソルを砂時計にする
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						texメッセージ.Text = "削除中．．．";
						sDList = sv_kiji.Del_kiji(gsaユーザ,sData);

						if(sDList[0].Length == 4)
						{
							記事一覧検索();
						}
						else
						{
							texメッセージ.Text = sDList[0];
							ビープ音();
						}
						// カーソルをデフォルトに戻す
						Cursor = System.Windows.Forms.Cursors.Default;
					}
				}
			}
// ADD 2005.06.01 東都）高木 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				texメッセージ.Text = gs通信エラー;
				ビープ音();
			}
// ADD 2005.06.01 東都）高木 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				texメッセージ.Text = ex.Message;
				ビープ音();
			}
		}

		private void btn確定_Click(object sender, System.EventArgs e)
		{
			sKcode = axGT記事.get_CelText(axGT記事.CaretRow,1).Trim();
			s記事  = axGT記事.get_CelText(axGT記事.CaretRow,2).TrimEnd();
			if(sKcode != "")
			{
				if(b輸送指示 && s輸送商品部門.Equals("0000")) //輸送商品親の場合、輸送商品子を表示
				{
					sKcode2 = sKcode;
					s記事２ = s記事;
					s輸送商品部門 = sKcode;
					sKcode  = "";
					s記事   = "";
					texメッセージ.Text = "検索中．．．";
					axGT記事.set_CelForeColor(nOldRow,0,0);
					axGT記事.set_CelBackColor(nOldRow,0,0xFFFFFF);
					axGT記事.CaretRow = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 START
					axGT記事.CaretCol = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 END
					axGT記事.set_CelForeColor(axGT記事.CaretRow,0,0x98FB98);  //BGR
					axGT記事.set_CelBackColor(axGT記事.CaretRow,0,0x006000);
					nOldRow = axGT記事.CaretRow;
					i現在頁数 = 1;
					記事一覧検索();
				}
				else if(b輸送指示 && !s輸送商品部門.Equals("0000")) //輸送商品子、時間指定まで以降の場合
				{
					if (sKcode.Length > 2 && sKcode.Substring(1).Equals("1X"))
					{
						if (g指定時間入力 == null) g指定時間入力 = new 指定時間入力();
						g指定時間入力.Left  = this.Left + 15;
						g指定時間入力.Top   = this.Top + 180;
						g指定時間入力.s記事 = "";
						g指定時間入力.lab時間区分.Text = "時まで";
						// MOD 2005.06.10 東都）伊賀　時間指定方法変更 START
//						g指定時間入力.nUD指定時間.Minimum = 12;
//						g指定時間入力.nUD指定時間.Maximum = 21;
//						g指定時間入力.nUD指定時間.Value = 12;
// MOD 2010.05.25 東都）高木 時間指定の変更 START
//						string[] items = {"１２","１３","１４","１５","１６","１７","１８","１９","２０","２１"};
						string[] items = {"１２","１３","１４","１５","１６","１７","１８","１９","２０"};
// MOD 2010.05.25 東都）高木 時間指定の変更 END
						g指定時間入力.cmb指定時間.Items.Clear();
						g指定時間入力.cmb指定時間.Items.AddRange(items);
						g指定時間入力.cmb指定時間.SelectedIndex = 0;
						// MOD 2005.06.10 東都）伊賀　時間指定方法変更 END
						g指定時間入力.ShowDialog(this);
						if (g指定時間入力.s記事.Length != 0)
						{
							s記事 = g指定時間入力.s記事;
							this.Close();
						}
					}
					else if (sKcode.Length > 2 && sKcode.Substring(1).Equals("2X"))
					{
						if (g指定時間入力 == null) g指定時間入力 = new 指定時間入力();
						g指定時間入力.Left  = this.Left + 15;
						g指定時間入力.Top   = this.Top + 180;
						g指定時間入力.s記事 = "";
						g指定時間入力.lab時間区分.Text = "時以降";
						// MOD 2005.06.10 東都）伊賀　時間指定方法変更 START
//						g指定時間入力.nUD指定時間.Minimum = 10;
//						g指定時間入力.nUD指定時間.Maximum = 19;
//						g指定時間入力.nUD指定時間.Value = 10;
// MOD 2010.05.25 東都）高木 時間指定の変更 START
//						string[] items = {"１０","１１","１２","１３","１４","１５","１６","１７","１８","１９"};
						string[] items = {"１０","１１","１２","１３","１４","１５","１６","１７","１８"};
// MOD 2010.05.25 東都）高木 時間指定の変更 END
						g指定時間入力.cmb指定時間.Items.Clear();
						g指定時間入力.cmb指定時間.Items.AddRange(items);
						g指定時間入力.cmb指定時間.SelectedIndex = 0;
						// MOD 2005.06.10 東都）伊賀　時間指定方法変更 END
						g指定時間入力.ShowDialog(this);
						if (g指定時間入力.s記事.Length != 0)
						{
							s記事 = g指定時間入力.s記事;
							this.Close();
						}
					}
					else
					{
						this.Close();
					}					
				}
				else
					this.Close();
			}
		}

		private void btn一覧表_Click(object sender, System.EventArgs e)
		{
			texメッセージ.Text = "記事一覧印刷中．．．";
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				if(sv_print == null) sv_print = new is2print.Service1();
				string[] sKey = new string[3];
				sKey[0] = gs会員ＣＤ;
				sKey[1] = gs部門ＣＤ;

				string[] sRet = new string[1];
// MOD 2011.06.07 東都）高木 王子運送の対応 START
//				IEnumerator iEnum = sv_print.Get_NotePrintData(gsaユーザ,sKey).GetEnumerator();
				IEnumerator iEnum;
				if (gs会員ＣＤ.Substring(0,1) != "J"){
					iEnum = sv_print.Get_NotePrintData(gsaユーザ,sKey).GetEnumerator();
				}else{
					if(sv_oji == null) sv_oji = new is2oji.Service1();
					iEnum = sv_oji.Get_NotePrintData(gsaユーザ,sKey).GetEnumerator();
				}
// MOD 2011.06.07 東都）高木 王子運送の対応 END
				iEnum.MoveNext();
				sRet = (string[])iEnum.Current;
// DEL 2005.05.11 東都）高木 「正常終了」は表示しない START
//				texメッセージ.Text = sRet[0];
// DEL 2005.05.11 東都）高木 「正常終了」は表示しない END
				if (sRet[0].Equals("正常終了"))
				{
					記事データ ds = new 記事データ();

					int iCnt = 1;
					//データセットに値をセット
					while(iEnum.MoveNext())
					{
						記事データ.table記事Row tr = (記事データ.table記事Row)ds.table記事.NewRow();
						tr.BeginEdit();
						tr.番号 = iCnt++;
// MOD 2005.05.16 東都）伊賀 データ構成変更 START
						string[] sData = new string[4];
						sData = (string[])iEnum.Current;
						tr.輸送指示コード = sData[0];
						tr.輸送指示名     = sData[1];
						tr.品名記事コード = sData[2];
						tr.品名記事名     = sData[3];
// MOD 2005.05.16 東都）伊賀 データ構成変更 END
						tr.EndEdit();

						ds.table記事.Rows.Add(tr);
					}

					記事帳票 cr = new 記事帳票();
					//CrystalReportにパラメータとデータセットを渡す
					cr.SetParameterValue("部門ＣＤ", gs部門ＣＤ);
					cr.SetParameterValue("部門名",   gs部門名);
					cr.SetDataSource(ds);

					//プレビュー表示
					プレビュー画面 画面 = new プレビュー画面();
					画面.Left = this.Left;
					画面.Top = this.Top;
					画面.crv帳票.PrintReport();
					画面.crv帳票.ReportSource = cr;
					画面.ShowDialog();
					texメッセージ.Text = "";
// MOD 2011.01.25 東都）高木 「ロードに失敗」対応 START
					try{
						cr.Close();
						cr.Dispose();
					}catch(Exception){
						;
					}
					//明示的領域開放
					cr  = null;
					ds  = null;

					//明示的ガベージコレクタ
					System.GC.Collect();
// MOD 2011.01.25 東都）高木 「ロードに失敗」対応 END
				}
				else
				{
// ADD 2005.05.11 東都）高木 「正常終了」は表示しない START
					texメッセージ.Text = sRet[0];
// ADD 2005.05.11 東都）高木 「正常終了」は表示しない END
					ビープ音();
				}
			}
// ADD 2005.07.04 東都）高木 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				texメッセージ.Text = gs通信エラー;
				ビープ音();
			}
// ADD 2005.07.04 東都）高木 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				texメッセージ.Text = ex.Message;
				ビープ音();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void btn前頁_Click(object sender, System.EventArgs e)
		{
			i現在頁数--;
			頁情報設定();
		}

		private void btn次頁_Click(object sender, System.EventArgs e)
		{
			i現在頁数++;
			頁情報設定();
		}
		
		private void 頁情報設定()
		{
			axGT記事.Clear();

			i開始数 = (i現在頁数 - 1) * axGT記事.Rows + 1;
			i終了数 = i現在頁数 * axGT記事.Rows;

			short s表示数 = (short)1;
// MOD 2010.02.12 東都）高木 上記修正は[記事登録]、[記事検索]に適用する START
//			i開始数 = (i現在頁数 - 1) * (axGT記事.Rows - 1) + 1;
//			i終了数 = i現在頁数 * (axGT記事.Rows - 1);
//
//			short s表示数 = (short)2;
			if(!b輸送指示){
//			if(lab記事タイトル.Text.Equals("記事登録")){
				i開始数 = (i現在頁数 - 1) * (axGT記事.Rows - 1) + 1;
				i終了数 = i現在頁数 * (axGT記事.Rows - 1);
				s表示数 = (short)2;
			}
// MOD 2010.02.12 東都）高木 上記修正は[記事登録]、[記事検索]に適用する END
			for(short sCnt = (short)i開始数; sCnt < s記事一覧.Length && sCnt <= i終了数 ; sCnt++)
			{
				axGT記事.set_RowsText(s表示数, s記事一覧[sCnt]);
				s表示数++;
			}
			lab頁番号.Text = i現在頁数.ToString() + " / " + i最大頁数.ToString();
			if (i現在頁数 == 1)
				btn前頁.Enabled = false;
			else
				btn前頁.Enabled = true;
			if (i現在頁数 == i最大頁数)
				btn次頁.Enabled = false;
			else
				btn次頁.Enabled = true;
			tex記事コード.Text = axGT記事.get_CelText(axGT記事.CaretRow,1).Trim();
			tex記事名.Text     = axGT記事.get_CelText(axGT記事.CaretRow,2).TrimEnd();
			s更新日時          = axGT記事.get_CelText(axGT記事.CaretRow,3).Trim();
		}

// ADD 2005.05.24 東都）小童谷 フォーカス移動 START
		private void 記事検索_Closed(object sender, System.EventArgs e)
		{
			axGT記事.CaretRow = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 START
			axGT記事.CaretCol = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 END
			axGT記事_CurPlaceChanged(null,null);
			axGT記事.Focus();
		}
// ADD 2005.05.24 東都）小童谷 フォーカス移動 END

// ADD 2005.07.22 東都）小童谷 戻るボタン追加 START
		private void btn戻る_Click(object sender, System.EventArgs e)
		{
			sKcode    = "";
			s記事     = "";
			sKcode2   = "";
			s記事２   = "";
			texメッセージ.Text = "検索中．．．";
			axGT記事.CaretRow = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 START
			axGT記事.CaretCol = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 END
			i現在頁数 = 1;
			axGT記事_CurPlaceChanged(null,null);
			s輸送商品部門 = "0000";
			記事一覧検索();
			axGT記事.Focus();
			btn戻る.Visible = false;
		}
// ADD 2005.07.22 東都）小童谷 戻るボタン追加 END

	}
}
