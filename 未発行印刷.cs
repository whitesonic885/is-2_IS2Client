using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [再印刷]、[チョイスプリント]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// MOD 2007.02.08 東都）高木 一覧表示項目の変更 
	// MOD 2007.02.19 FJCS）桑田 メッセージ変更 
	// MOD 2007.02.20 東都）高木 再発行画面で出荷日が未来でも印刷可にする 
	// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 
	// MOD 2007.03.10 東都）高木 一覧表示項目の変更（障害） 
	// MOD 2007.07.06 東都）高木 ヘッダにログイン集荷店を表示 
	//--------------------------------------------------------------------------
	// ADD 2008.03.19 東都）高木 個別再発行機能の追加 
	// MOD 2008.10.29 東都）高木 請求先情報を追加 
	//--------------------------------------------------------------------------
	// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） 
	// MOD 2010.10.01 東都）高木 お客様番号１６桁化 
	//--------------------------------------------------------------------------
	// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 
	//--------------------------------------------------------------------------
	public class 未発行印刷 : 共通フォーム
	{
		public short OldRow = 0;
		private short nSrow = 0;
		private short nErow = 0;
		private short nWork = 0;

		private string[] s出荷一覧;
//		private int      i現在頁数;
		private int      iアクティブＦＧ = 0;

		public string sタイトル;
		public string s状態種別;

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab日時;
		private System.Windows.Forms.TextBox tex重量合計;
		private System.Windows.Forms.TextBox tex個数合計;
		private System.Windows.Forms.Label lab登録件数;
		private System.Windows.Forms.TextBox tex登録件数;
		private System.Windows.Forms.Label lab個数合計;
		private System.Windows.Forms.Label lab重量合計;
		private System.Windows.Forms.Label lab利用部門;
		private System.Windows.Forms.Label lab未発行印刷タイトル;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.Button btn再発行;
		private System.Windows.Forms.TextBox tex利用部門;
		private AxGTABLE32V2Lib.AxGTable32 axGT出荷一覧;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.TextBox texログイン集荷店;
		private System.Windows.Forms.Label labログイン集荷店;
		private System.Windows.Forms.Button btn個別再発行;
		private System.ComponentModel.IContainer components;

		public 未発行印刷()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
			ＤＰＩ表示サイズ変換();
//			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
				this.axGT出荷一覧.Size = new System.Drawing.Size(732, 416);
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(未発行印刷));
			this.panel2 = new System.Windows.Forms.Panel();
			this.axGT出荷一覧 = new AxGTABLE32V2Lib.AxGTable32();
			this.tex重量合計 = new System.Windows.Forms.TextBox();
			this.tex個数合計 = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.lab登録件数 = new System.Windows.Forms.Label();
			this.tex登録件数 = new System.Windows.Forms.TextBox();
			this.lab個数合計 = new System.Windows.Forms.Label();
			this.lab重量合計 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.labログイン集荷店 = new System.Windows.Forms.Label();
			this.texログイン集荷店 = new System.Windows.Forms.TextBox();
			this.lab利用部門 = new System.Windows.Forms.Label();
			this.tex利用部門 = new System.Windows.Forms.TextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab日時 = new System.Windows.Forms.Label();
			this.lab未発行印刷タイトル = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn個別再発行 = new System.Windows.Forms.Button();
			this.btn再発行 = new System.Windows.Forms.Button();
			this.texメッセージ = new System.Windows.Forms.TextBox();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axGT出荷一覧)).BeginInit();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Honeydew;
			this.panel2.Controls.Add(this.axGT出荷一覧);
			this.panel2.Controls.Add(this.tex重量合計);
			this.panel2.Controls.Add(this.tex個数合計);
			this.panel2.Controls.Add(this.label21);
			this.panel2.Controls.Add(this.lab登録件数);
			this.panel2.Controls.Add(this.tex登録件数);
			this.panel2.Controls.Add(this.lab個数合計);
			this.panel2.Controls.Add(this.lab重量合計);
			this.panel2.Location = new System.Drawing.Point(0, 6);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(764, 452);
			this.panel2.TabIndex = 1;
			// 
			// axGT出荷一覧
			// 
			this.axGT出荷一覧.ContainingControl = this;
			this.axGT出荷一覧.DataSource = null;
			this.axGT出荷一覧.Location = new System.Drawing.Point(28, 32);
			this.axGT出荷一覧.Name = "axGT出荷一覧";
			this.axGT出荷一覧.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT出荷一覧.OcxState")));
			this.axGT出荷一覧.Size = new System.Drawing.Size(732, 416);
			this.axGT出荷一覧.TabIndex = 51;
			this.axGT出荷一覧.KeyDownEvent += new AxGTABLE32V2Lib._DGTable32Events_KeyDownEventHandler(this.axGT出荷一覧_KeyDownEvent);
			this.axGT出荷一覧.CelClick += new AxGTABLE32V2Lib._DGTable32Events_CelClickEventHandler(this.axGT出荷一覧_CelClick);
			this.axGT出荷一覧.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT出荷一覧_CurPlaceChanged);
			// 
			// tex重量合計
			// 
			this.tex重量合計.BackColor = System.Drawing.SystemColors.Window;
			this.tex重量合計.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex重量合計.Location = new System.Drawing.Point(382, 4);
			this.tex重量合計.Name = "tex重量合計";
			this.tex重量合計.ReadOnly = true;
			this.tex重量合計.Size = new System.Drawing.Size(86, 23);
			this.tex重量合計.TabIndex = 50;
			this.tex重量合計.TabStop = false;
			this.tex重量合計.Text = "";
			this.tex重量合計.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tex個数合計
			// 
			this.tex個数合計.BackColor = System.Drawing.SystemColors.Window;
			this.tex個数合計.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex個数合計.Location = new System.Drawing.Point(246, 4);
			this.tex個数合計.Name = "tex個数合計";
			this.tex個数合計.ReadOnly = true;
			this.tex個数合計.Size = new System.Drawing.Size(70, 23);
			this.tex個数合計.TabIndex = 49;
			this.tex個数合計.TabStop = false;
			this.tex個数合計.Text = "";
			this.tex個数合計.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label21
			// 
			this.label21.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label21.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label21.ForeColor = System.Drawing.Color.White;
			this.label21.Location = new System.Drawing.Point(0, 0);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(22, 456);
			this.label21.TabIndex = 3;
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab登録件数
			// 
			this.lab登録件数.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab登録件数.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lab登録件数.ForeColor = System.Drawing.Color.BlueViolet;
			this.lab登録件数.Location = new System.Drawing.Point(62, 6);
			this.lab登録件数.Name = "lab登録件数";
			this.lab登録件数.Size = new System.Drawing.Size(60, 18);
			this.lab登録件数.TabIndex = 4;
			this.lab登録件数.Text = "登録件数";
			this.lab登録件数.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tex登録件数
			// 
			this.tex登録件数.BackColor = System.Drawing.SystemColors.Window;
			this.tex登録件数.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex登録件数.Location = new System.Drawing.Point(122, 4);
			this.tex登録件数.Name = "tex登録件数";
			this.tex登録件数.ReadOnly = true;
			this.tex登録件数.Size = new System.Drawing.Size(54, 23);
			this.tex登録件数.TabIndex = 46;
			this.tex登録件数.TabStop = false;
			this.tex登録件数.Text = "";
			this.tex登録件数.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lab個数合計
			// 
			this.lab個数合計.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab個数合計.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lab個数合計.ForeColor = System.Drawing.Color.Blue;
			this.lab個数合計.Location = new System.Drawing.Point(186, 6);
			this.lab個数合計.Name = "lab個数合計";
			this.lab個数合計.Size = new System.Drawing.Size(60, 18);
			this.lab個数合計.TabIndex = 6;
			this.lab個数合計.Text = "個数合計";
			this.lab個数合計.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab重量合計
			// 
			this.lab重量合計.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab重量合計.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lab重量合計.ForeColor = System.Drawing.Color.Blue;
			this.lab重量合計.Location = new System.Drawing.Point(322, 6);
			this.lab重量合計.Name = "lab重量合計";
			this.lab重量合計.Size = new System.Drawing.Size(60, 18);
			this.lab重量合計.TabIndex = 8;
			this.lab重量合計.Text = "重量合計";
			this.lab重量合計.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.PaleGreen;
			this.panel6.Controls.Add(this.labログイン集荷店);
			this.panel6.Controls.Add(this.texログイン集荷店);
			this.panel6.Controls.Add(this.lab利用部門);
			this.panel6.Controls.Add(this.tex利用部門);
			this.panel6.Location = new System.Drawing.Point(0, 26);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(810, 26);
			this.panel6.TabIndex = 12;
			// 
			// labログイン集荷店
			// 
			this.labログイン集荷店.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labログイン集荷店.ForeColor = System.Drawing.Color.LimeGreen;
			this.labログイン集荷店.Location = new System.Drawing.Point(694, 8);
			this.labログイン集荷店.Name = "labログイン集荷店";
			this.labログイン集荷店.Size = new System.Drawing.Size(48, 14);
			this.labログイン集荷店.TabIndex = 14;
			this.labログイン集荷店.Text = "ログイン";
			// 
			// texログイン集荷店
			// 
			this.texログイン集荷店.BackColor = System.Drawing.Color.PaleGreen;
			this.texログイン集荷店.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.texログイン集荷店.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texログイン集荷店.ForeColor = System.Drawing.Color.LimeGreen;
			this.texログイン集荷店.Location = new System.Drawing.Point(744, 6);
			this.texログイン集荷店.Name = "texログイン集荷店";
			this.texログイン集荷店.ReadOnly = true;
			this.texログイン集荷店.Size = new System.Drawing.Size(42, 16);
			this.texログイン集荷店.TabIndex = 12;
			this.texログイン集荷店.TabStop = false;
			this.texログイン集荷店.Text = "999";
			// 
			// lab利用部門
			// 
			this.lab利用部門.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab利用部門.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab利用部門.Location = new System.Drawing.Point(14, 8);
			this.lab利用部門.Name = "lab利用部門";
			this.lab利用部門.Size = new System.Drawing.Size(58, 14);
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
			this.panel7.Controls.Add(this.lab未発行印刷タイトル);
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
			// lab未発行印刷タイトル
			// 
			this.lab未発行印刷タイトル.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab未発行印刷タイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab未発行印刷タイトル.ForeColor = System.Drawing.Color.White;
			this.lab未発行印刷タイトル.Location = new System.Drawing.Point(12, 2);
			this.lab未発行印刷タイトル.Name = "lab未発行印刷タイトル";
			this.lab未発行印刷タイトル.Size = new System.Drawing.Size(264, 24);
			this.lab未発行印刷タイトル.TabIndex = 0;
			this.lab未発行印刷タイトル.Text = "未発行印刷";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn個別再発行);
			this.panel8.Controls.Add(this.btn再発行);
			this.panel8.Controls.Add(this.texメッセージ);
			this.panel8.Controls.Add(this.btn閉じる);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 2;
			// 
			// btn個別再発行
			// 
			this.btn個別再発行.ForeColor = System.Drawing.Color.Blue;
			this.btn個別再発行.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn個別再発行.Location = new System.Drawing.Point(170, 6);
			this.btn個別再発行.Name = "btn個別再発行";
			this.btn個別再発行.Size = new System.Drawing.Size(62, 48);
			this.btn個別再発行.TabIndex = 2;
			this.btn個別再発行.Text = "個別　　再発行";
			this.btn個別再発行.Click += new System.EventHandler(this.btn個別再発行_Click);
			// 
			// btn再発行
			// 
			this.btn再発行.ForeColor = System.Drawing.Color.Blue;
			this.btn再発行.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn再発行.Location = new System.Drawing.Point(98, 6);
			this.btn再発行.Name = "btn再発行";
			this.btn再発行.Size = new System.Drawing.Size(62, 48);
			this.btn再発行.TabIndex = 1;
			this.btn再発行.Text = "ラベル　　印刷";
			this.btn再発行.Click += new System.EventHandler(this.btn再発行_Click);
			// 
			// texメッセージ
			// 
			this.texメッセージ.BackColor = System.Drawing.Color.PaleGreen;
			this.texメッセージ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texメッセージ.ForeColor = System.Drawing.Color.Red;
			this.texメッセージ.Location = new System.Drawing.Point(446, 4);
			this.texメッセージ.Multiline = true;
			this.texメッセージ.Name = "texメッセージ";
			this.texメッセージ.ReadOnly = true;
			this.texメッセージ.Size = new System.Drawing.Size(344, 50);
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
			this.btn閉じる.TabIndex = 0;
			this.btn閉じる.TabStop = false;
			this.btn閉じる.Text = "閉じる";
			this.btn閉じる.Click += new System.EventHandler(this.btn閉じる_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel2);
			this.groupBox2.Location = new System.Drawing.Point(16, 52);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(768, 460);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// 未発行印刷
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 574);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.groupBox2);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "未発行印刷";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 未発行印刷";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Activated += new System.EventHandler(this.未発行印刷_Activated);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axGT出荷一覧)).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			iアクティブＦＧ = 0;
			//タイトル
			this.Text = "is-2 " + sタイトル;
			lab未発行印刷タイトル.Text = sタイトル;
// ADD 2008.03.19 東都）高木 個別再発行機能の追加 START
			if(sタイトル.Equals("再発行")){
				this.btn個別再発行.Visible = true;
			}else{
				this.btn個別再発行.Visible = false;
			}
// ADD 2008.03.19 東都）高木 個別再発行機能の追加 END

			// ヘッダー項目の設定
// MOD 2007.07.06 東都）高木 ヘッダにログイン集荷店を表示 START
//			texお客様名.Text = gs利用者名;
			if(gs利用者部門店所ＣＤ == null || gs利用者部門店所ＣＤ.Length == 0)
			{
				texログイン集荷店.Text = "";
			}
			else
			{
				texログイン集荷店.Text = gs利用者部門店所ＣＤ;
			}
// MOD 2007.07.06 東都）高木 ヘッダにログイン集荷店を表示 END
			tex利用部門.Text = gs部門ＣＤ + " " + gs部門名;

			// 日時の初期設定
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled = true;

			// 出荷日の初期設定（当日）
			部門出荷日情報更新();

// ADD 2005.05.24 東都）小童谷 項目の初期化 START
			texメッセージ.Text = "";
			tex登録件数.Text   = "";
			tex個数合計.Text   = "";
			tex重量合計.Text   = "";
			axGT出荷一覧.Clear();
// ADD 2005.05.24 東都）小童谷 項目の初期化 END
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 START
			axGT出荷一覧.CaretRow = 1;
			axGT出荷一覧.CaretCol = 1;
			axGT出荷一覧_CurPlaceChanged(null,null);
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 END

			// 端末設定でプリンタを使用できない設定の場合、印刷ボタン使用不可
			if(gsプリンタＦＧ != "1")
			{
				btn再発行.Enabled = false;
			}

// MOD 2006.07.26 東都）山本 一覧に運賃と保険料の項目を追加 START
//			axGT出荷一覧.Cols = 13;
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 START
//			axGT出荷一覧.Cols = 16;
// MOD 2008.10.29 東都）高木 請求先情報を追加 START
//			axGT出荷一覧.Cols = 18;
			axGT出荷一覧.Cols = 21;
// MOD 2008.10.29 東都）高木 請求先情報を追加 END
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 END
// MOD 2006.07.26 東都）山本 一覧に運賃と保険料の項目を追加 END
			axGT出荷一覧.Rows = 14;
			axGT出荷一覧.ColSep = "|";
// MOD 2006.07.26 東都）山本 一覧に運賃と保険料の項目を追加 START
//			axGT出荷一覧.set_RowsText(0, "|出荷日|お届け先|個数|重量|輸送商品／記事・品名|送り状番号|指定日|輸送状況|登録日|お客様番号|ジャーナルＮＯ|日|出日|");
//			axGT出荷一覧.ColsWidth = "0|3.5|15|3|3.5|12|7|4.5|5|3.5|15|0|0|0|";
//			axGT出荷一覧.ColsAlignHorz = "1|1|0|2|2|0|0|1|1|1|0|0|0|0|";

//			axGT出荷一覧.set_RowsText(0, "|出荷日|お届け先|個数|重量|輸送商品／記事・品名|送り状番号|指定日|輸送状況|登録日|お客様番号|ジャーナルＮＯ|日|出日|登録者|保険料（万円）|運賃（万円）|");
//			axGT出荷一覧.ColsWidth = "0|3.5|15|3|3.5|12|7|4.5|5|3.5|15|0|0|0|0|6|6|";
//			axGT出荷一覧.ColsAlignHorz = "1|1|0|2|2|0|0|1|1|1|0|0|0|0|0|2|2|";

// MOD 2007.02.08 東都）高木 一覧表示項目の変更 START
//			axGT出荷一覧.set_RowsText(0, "|出荷日|お届け先|個数|重量|保険料（万円）|運賃（万円）|輸送商品／記事・品名|送り状番号|指定日|輸送状況|登録日|お客様番号|ジャーナルＮＯ|日|出日|登録者|");
//			axGT出荷一覧.ColsWidth = "0|4|17|4|4.5|6|6|12|7|4.5|5|3.5|15.5|0|0|0|0|";
//			axGT出荷一覧.ColsAlignHorz = "1|1|0|2|2|2|2|0|0|1|1|1|0|0|0|0|0|";
			axGT出荷一覧.set_RowsText(0, "||ﾗﾍﾞﾙ|出荷日|お届け先|個数|重量|送り状番号|お客様番号|指定日|輸送状況|輸送商品／記事・品名|運賃|保険料|登録日|ジャーナルＮＯ|日|出日|登録者|");
// MOD 2008.10.29 東都）高木 請求先情報を追加 START
//			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|3|3.4|6.5|8.5|5.3|4.6|13.0|6|6|5|0|0|0|0|";
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 START
//			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|3|3.4|6.5|8.5|5.3|4.6|13.0|6|6|5|0|0|0|0|0|0|0|";
			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|2.6|3|6.0|9.8|5.3|4.6|13.0|6|6|4.2|0|0|0|0|0|0|0|";
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 END
// MOD 2008.10.29 東都）高木 請求先情報を追加 END
			axGT出荷一覧.ColsAlignHorz = "1|1|1|1|0|2|2|0|0|1|1|0|2|2|1|0|0|0|0|";
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 END
// MOD 2006.07.26 東都）山本 一覧に運賃と保険料の項目を追加 END

//			axGT出荷一覧.set_CelForeColor(axGT出荷一覧.CaretRow,0,111111);
			axGT出荷一覧.set_CelForeColor(axGT出荷一覧.CaretRow,0,0x98FB98);  //BGR
			axGT出荷一覧.set_CelBackColor(axGT出荷一覧.CaretRow,0,0x006000);

			for(short i = 1; i <= axGT出荷一覧.Rows; i++ )
			{
				axGT出荷一覧.set_CelHeight(i,0,2.3);
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 START
//				axGT出荷一覧.set_CelAlignVert(i,2,3);
//// MOD 2006.08.03 東都）山本 一覧に運賃と保険料の項目を追加 START
////				axGT出荷一覧.set_CelAlignVert(i,5,3);
////				axGT出荷一覧.set_CelAlignVert(i,6,3);
//				axGT出荷一覧.set_CelAlignVert(i,7,3);
//				axGT出荷一覧.set_CelAlignVert(i,8,3);
//// MOD 2006.08.03 東都）山本 一覧に運賃と保険料の項目を追加 END
				axGT出荷一覧.set_CelAlignVert(i,4,3);
				axGT出荷一覧.set_CelAlignVert(i,7,3);
				axGT出荷一覧.set_CelAlignVert(i,11,3);
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 END
			}
		}

		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void 出荷検索()
		{
			string s届け先 = "";
			string s依頼主 = "";
			int    i出荷日 = 0;
// ADD 2005.06.01 東都）小童谷 チョイスは日付範囲なし START
//			string sSday = gdt出荷日.ToShortDateString().Replace("/","");
//			string sEday = gdt出荷日.ToShortDateString().Replace("/","");
			string sSday = "";
			string sEday = "";
			if(s状態種別 != "aa")
			{
				sSday = "0";
				sEday = "0";
			}
			else
			{
// MOD 2005.07.08 東都）高木 日付変換の変更 START
//				sSday = gdt出荷日.ToShortDateString().Replace("/","");
//				sEday = gdt出荷日.ToShortDateString().Replace("/","");
				sSday = YYYYMMDD変換(gdt出荷日);
// MOD 2007.02.20 東都）高木 再発行画面で出荷日が未来でも印刷可にする START
//				sEday = YYYYMMDD変換(gdt出荷日);
				sEday = "99991231";
// MOD 2007.02.20 東都）高木 再発行画面で出荷日が未来でも印刷可にする END
// MOD 2005.07.08 東都）高木 日付変換の変更 END
			}
// ADD 2005.06.01 東都）小童谷 チョイスは日付範囲なし END
//			string s状態 = gsa状態ＣＤ[1];
			string s状態 = s状態種別;

			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				s出荷一覧 = new string[1];
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
// MOD 2006.07.26 東都）山本 一覧に運賃と保険料の項目を追加 START
//				s出荷一覧 = sv_syukka.Get_syukka(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,s届け先, s依頼主, i出荷日, sSday, sEday, s状態);
				s出荷一覧 = sv_syukka.Get_syukka1(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,s届け先, s依頼主, i出荷日, sSday, sEday, s状態);
// MOD 2006.07.26 東都）山本 一覧に運賃と保険料の項目を追加 END
				texメッセージ.Text = s出荷一覧[0];
				if(s出荷一覧[0].Length == 4)
				{
					texメッセージ.Text = "";
					tex登録件数.Text = s出荷一覧[1];
					tex個数合計.Text = s出荷一覧[2];
					tex重量合計.Text = s出荷一覧[3];

					頁情報設定();

				}
				else
				{
					if(s出荷一覧[0].Equals("該当データがありません"))
					{
						texメッセージ.Text = "";
						MessageBox.Show("該当データがありません","出荷検索",MessageBoxButtons.OK);
						this.Close();
					}
					else
					{
//						i現在頁数 = 1;
						ビープ音();
					}
				}
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				texメッセージ.Text = gs通信エラー;
				ビープ音();
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				texメッセージ.Text = "通信エラー：" + ex.Message;
				ビープ音();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
			axGT出荷一覧.CaretRow = 1;
			axGT出荷一覧_CurPlaceChanged(null,null);

		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

		private void axGT出荷一覧_CurPlaceChanged(object sender, AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEvent e)
		{
			axGT出荷一覧.set_CelForeColor(OldRow,0,0);
			axGT出荷一覧.set_CelBackColor(OldRow,0,0xFFFFFF);
			if(axGT出荷一覧.SelStartRow == axGT出荷一覧.SelEndRow)
			{
				if(nSrow > nErow)
				{
					nWork = nSrow;
					nSrow = nErow;
					nErow = nWork;
				}
				for(short nCnt = nSrow; nCnt <= nErow; nCnt++)
				{
//					axGT出荷一覧.set_CelForeColor(nCnt,0,0);
					axGT出荷一覧.set_CelForeColor(nCnt,0,0);
					axGT出荷一覧.set_CelBackColor(nCnt,0,0xFFFFFF);
				}
			}
//			axGT出荷一覧.set_CelForeColor(axGT出荷一覧.SelStartRow,0,111111);
//			axGT出荷一覧.set_CelForeColor(axGT出荷一覧.SelEndRow,0,111111);
//			axGT出荷一覧.set_CelForeColor(axGT出荷一覧.CaretRow,0,111111);
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 START
//			axGT出荷一覧.set_CelForeColor(axGT出荷一覧.SelStartRow,0,0x98FB98);
//			axGT出荷一覧.set_CelBackColor(axGT出荷一覧.SelStartRow,0,0x006000);
//			axGT出荷一覧.set_CelForeColor(axGT出荷一覧.SelEndRow,0,0x98FB98);
//			axGT出荷一覧.set_CelBackColor(axGT出荷一覧.SelEndRow,0,0x006000);
			short n開始 = axGT出荷一覧.SelStartRow;
			short n終了 = axGT出荷一覧.SelEndRow;
			if(n開始 > n終了){
				n開始 = axGT出荷一覧.SelEndRow;
				n終了 = axGT出荷一覧.SelStartRow;
			}
			for(short n行 = n開始; n行 <= n終了; n行++){
				axGT出荷一覧.set_CelForeColor(n行,0,0x98FB98);
				axGT出荷一覧.set_CelBackColor(n行,0,0x006000);
			}
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 END
			axGT出荷一覧.set_CelForeColor(axGT出荷一覧.CaretRow,0,0x98FB98);
			axGT出荷一覧.set_CelBackColor(axGT出荷一覧.CaretRow,0,0x006000);
/*			if(axGT出荷一覧.SelEndRow > axGT出荷一覧.CaretRow
				&& axGT出荷一覧.SelStartRow <= axGT出荷一覧.CaretRow
				&& axGT出荷一覧.get_CelForeColor(axGT出荷一覧.SelEndRow,0) != Color.Black)
				axGT出荷一覧.set_CelForeColor(axGT出荷一覧.SelEndRow,0,0);

			if(axGT出荷一覧.SelEndRow < axGT出荷一覧.CaretRow
				&& axGT出荷一覧.SelStartRow >= axGT出荷一覧.CaretRow
				&& axGT出荷一覧.get_CelForeColor(axGT出荷一覧.SelEndRow,0) != Color.Black)
				axGT出荷一覧.set_CelForeColor(axGT出荷一覧.SelEndRow,0,0);
*/
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 START
//			if(axGT出荷一覧.SelEndRow > axGT出荷一覧.CaretRow
//				&& axGT出荷一覧.SelStartRow <= axGT出荷一覧.CaretRow
//				&& axGT出荷一覧.get_CelForeColor(axGT出荷一覧.SelEndRow,0) != Color.Black)
//			{
//				axGT出荷一覧.set_CelForeColor(axGT出荷一覧.SelEndRow,0,0);
//				axGT出荷一覧.set_CelBackColor(axGT出荷一覧.SelEndRow,0,0xFFFFFF);
//			}
//
//			if(axGT出荷一覧.SelEndRow < axGT出荷一覧.CaretRow
//				&& axGT出荷一覧.SelStartRow >= axGT出荷一覧.CaretRow
//				&& axGT出荷一覧.get_CelForeColor(axGT出荷一覧.SelEndRow,0) != Color.Black)
//			{
//				axGT出荷一覧.set_CelForeColor(axGT出荷一覧.SelEndRow,0,0);
//				axGT出荷一覧.set_CelBackColor(axGT出荷一覧.SelEndRow,0,0xFFFFFF);
//			}
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 END

			OldRow = axGT出荷一覧.CaretRow;
			nSrow  = axGT出荷一覧.SelStartRow;
			nErow  = axGT出荷一覧.SelEndRow;

		}

		private void axGT出荷一覧_CelClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelClickEvent e)
		{
			axGT出荷一覧_CurPlaceChanged(null,null);
			if(axGT出荷一覧.SelStartRow != axGT出荷一覧.SelEndRow)
			{
				if(nSrow > nErow)
				{
					nWork = nSrow;
					nSrow = nErow;
					nErow = nWork;
				}
				for(short nCnt = nSrow; nCnt <= nErow; nCnt++)
				{
					axGT出荷一覧.set_CelForeColor(nCnt,0,0x98FB98);
					axGT出荷一覧.set_CelBackColor(nCnt,0,0x006000);
				}
				for(int nCnt = int.Parse(nSrow.ToString()) - 1; nCnt >= 1; nCnt--)
				{
					axGT出荷一覧.set_CelForeColor(short.Parse(nCnt.ToString()),0,0);
					axGT出荷一覧.set_CelBackColor(short.Parse(nCnt.ToString()),0,0xFFFFFF);
				}
				for(int nCnt = int.Parse(nErow.ToString()) + 1; nCnt <= axGT出荷一覧.Rows; nCnt++)
				{
					axGT出荷一覧.set_CelForeColor(short.Parse(nCnt.ToString()),0,0);
					axGT出荷一覧.set_CelBackColor(short.Parse(nCnt.ToString()),0,0xFFFFFF);
				}
			}
		}

		private void axGT出荷一覧_KeyDownEvent(object sender, AxGTABLE32V2Lib._DGTable32Events_KeyDownEvent e)
		{
			if (e.keyCode == 9)
			{
				this.SelectNextControl(axGT出荷一覧, true, true, true, true);
			}
		}

// MOD 2008.03.19 東都）高木 個別再発行機能の追加 START
//		private void btn再発行_Click(object sender, System.EventArgs e)
		private void btn再発行_Click(int i開始, int i終了)
// MOD 2008.03.19 東都）高木 個別再発行機能の追加 END
		{
// MOD 2007.03.10 東都）高木 一覧表示項目の変更（障害） START
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 START
////			if(axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,12).Trim().Length == 0)
//			if(axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,14).Trim().Length == 0)
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 END
			//登録日チェック
			if(axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,16).Trim().Length == 0)
// MOD 2007.03.10 東都）高木 一覧表示項目の変更（障害） END
				return;

			texメッセージ.Text = "送り状荷札印刷中．．．";

			try
			{
				プリンタチェック();
			}
			catch(Exception ex)
			{
				texメッセージ.Text = ex.Message;
				return;
			}
			Cursor = System.Windows.Forms.Cursors.AppStarting;

			short n開始;
			short n終了;
			if(axGT出荷一覧.SelStartRow > axGT出荷一覧.SelEndRow)
			{
				n終了 = axGT出荷一覧.SelStartRow;
				n開始 = axGT出荷一覧.SelEndRow;
			}
			else
			{
				n開始 = axGT出荷一覧.SelStartRow;
				n終了 = axGT出荷一覧.SelEndRow;
			}
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 START
			short n表示開始 = axGT出荷一覧.TopRow;
			string s開始登録日         = axGT出荷一覧.get_CelText(n開始,16).Trim();
			string s開始ジャーナルＮＯ = axGT出荷一覧.get_CelText(n開始,15).Trim();
//保留：間の行のチェック
			string s終了登録日         = axGT出荷一覧.get_CelText(n終了,16).Trim();
			string s終了ジャーナルＮＯ = axGT出荷一覧.get_CelText(n終了,15).Trim();
			string s次行登録日         = "";
			string s次行ジャーナルＮＯ = "";
			short n次行 = (short)(n終了 + 1);
			if(n次行 <= axGT出荷一覧.Rows){
				s次行登録日         = axGT出荷一覧.get_CelText(n次行,16).Trim();
				s次行ジャーナルＮＯ = axGT出荷一覧.get_CelText(n次行,15).Trim();
			}
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 END

// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） START
//			ds送り状.Clear();
			送り状データクリア();
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） END

			for(short nCnt = n開始 ; nCnt <= n終了; nCnt++)
			{
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 START
				//登録日が空なら次データへ
				if(axGT出荷一覧.get_CelText(nCnt,16).Trim().Length == 0){
					continue;
				}
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 END
				try
				{
					string[] sData = new string[2];
// MOD 2007.03.10 東都）高木 一覧表示項目の変更（障害） START
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 START
////					sData[0] = axGT出荷一覧.get_CelText(nCnt, 12);
////					sData[1] = axGT出荷一覧.get_CelText(nCnt, 11);
//					sData[0] = axGT出荷一覧.get_CelText(nCnt, 14);
//					sData[1] = axGT出荷一覧.get_CelText(nCnt, 13);
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 END
					//登録日、ジャーナルＮＯ
					sData[0] = axGT出荷一覧.get_CelText(nCnt, 16);
					sData[1] = axGT出荷一覧.get_CelText(nCnt, 15);
// MOD 2007.03.10 東都）高木 一覧表示項目の変更（障害） END

// MOD 2008.03.19 東都）高木 個別再発行機能の追加 START
//					送り状印刷指示(sData);
					送り状印刷指示(sData, i開始, i終了);
// MOD 2008.03.19 東都）高木 個別再発行機能の追加 END
// ADD 2006.12.12 東都）小童谷 店所と部門店所が異なる場合は、印刷しない START
					if(!gb印刷)
					{
						texメッセージ.Text = "";
						Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2007.02.19 FJCS）桑田 メッセージ変更 START
//						MessageBox.Show("発店が違います。印刷できません。","送状印刷"
						MessageBox.Show("集荷店が違います。印刷できません。","送状印刷"
// MOD 2007.02.19 FJCS）桑田 メッセージ変更 START
							,MessageBoxButtons.OK);
						return;
					}
// ADD 2006.12.12 東都）小童谷 店所と部門店所が異なる場合は、印刷しない END
				}
				catch (Exception ex)
				{
					texメッセージ.Text = ex.Message;
					ビープ音();
					return;
				}
			}
			Cursor = System.Windows.Forms.Cursors.Default;

			送り状帳票印刷();

			// 再検索
//			btn出荷検索_Click(sender, e);
			出荷検索();
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 START
			一覧カーソル移動(n開始, n終了, n表示開始
							, s開始登録日, s開始ジャーナルＮＯ
							, s終了登録日, s終了ジャーナルＮＯ
							, s次行登録日, s次行ジャーナルＮＯ);
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 END

			texメッセージ.Text = "";
		}


		private void 頁情報設定()
		{
//
			if (s出荷一覧.Length - 4 <= 14)
			{
				axGT出荷一覧.Rows = 14;
			}
			else if (axGT出荷一覧.Rows < s出荷一覧.Length - 4)
			{
				axGT出荷一覧.Rows = (short)(s出荷一覧.Length - 4);
			}
			for(short i = 1; i <= axGT出荷一覧.Rows; i++ )
			{
				axGT出荷一覧.set_CelHeight(i,0,2.3);
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 START
//				axGT出荷一覧.set_CelAlignVert(i,2,3);
//// MOD 2006.08.03 東都）山本 一覧に運賃と保険料の項目を追加 START
////				axGT出荷一覧.set_CelAlignVert(i,5,3);
////				axGT出荷一覧.set_CelAlignVert(i,6,3);
//				axGT出荷一覧.set_CelAlignVert(i,7,3);
//				axGT出荷一覧.set_CelAlignVert(i,8,3);
//// MOD 2006.08.03 東都）山本 一覧に運賃と保険料の項目を追加 END
				axGT出荷一覧.set_CelAlignVert(i,4,3);
				axGT出荷一覧.set_CelAlignVert(i,7,3);
				axGT出荷一覧.set_CelAlignVert(i,11,3);
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 END
			}
//
			axGT出荷一覧.Clear();
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 START
			axGT出荷一覧.CaretRow = 1;
			axGT出荷一覧.CaretCol = 1;
			axGT出荷一覧_CurPlaceChanged(null,null);
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 END

			short s表示数 = (short)1;
			for(short sCnt = (short)4; sCnt < s出荷一覧.Length; sCnt++)
			{
				string sRList = s出荷一覧[sCnt].Replace("\\r\\n","\r\n");
				axGT出荷一覧.set_RowsText(s表示数, sRList);
				s表示数++;
			}
			axGT出荷一覧.Focus();
		}

		private void 未発行印刷_Activated(object sender, System.EventArgs e)
		{
			if(iアクティブＦＧ == 0)
				出荷検索();
			iアクティブＦＧ = 1;
		}

// ADD 2008.03.19 東都）高木 個別再発行機能の追加 START
		private void btn再発行_Click(object sender, System.EventArgs e)
		{
			btn再発行_Click(1, 99);
		}

		private void btn個別再発行_Click(object sender, System.EventArgs e)
		{
			//登録日チェック
			if(axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,16).Trim().Length == 0)
				return;

			//１行以上
			if(axGT出荷一覧.SelStartRow != axGT出荷一覧.SelEndRow)
			{
				MessageBox.Show("複数のデータを選択した状態では実行できません。\r\n"
								+ "１件のみ選択して実行してください。"
								, "確認", MessageBoxButtons.OK );
				return;
			}

			個別再発行 g個再発行 = new 個別再発行();
			g個再発行.Left = this.Left + (this.Width  - g個再発行.Width)  / 2;
			g個再発行.Top  = this.Top  + (this.Height - g個再発行.Height) / 2;
			g個再発行.ShowDialog(this);

			//[閉じる]ボタンを押された時
			if(g個再発行.i開始 == 0 && g個再発行.i終了 == 0) return;

			int i開始 = g個再発行.i開始;
			int i終了 = g個再発行.i終了;
			g個再発行 = null;
			btn再発行_Click(i開始, i終了);
		}
// ADD 2008.03.19 東都）高木 個別再発行機能の追加 END
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 START
		private void 一覧カーソル移動(short n開始, short n終了, short n表示開始
								, string s開始登録日, string s開始ジャーナルＮＯ
								, string s終了登録日, string s終了ジャーナルＮＯ
								, string s次行登録日, string s次行ジャーナルＮＯ)
		{
			//選択行のクリア
			axGT出荷一覧.CaretRow    = 1;
			axGT出荷一覧.SelStartRow = 1;
			axGT出荷一覧.SelEndRow   = 1;
			axGT出荷一覧.CaretCol    = 2;
			//選択行の設定
			short n新開始 = 0;
			short n新終了 = 0;
			//選択開始行と選択終了行がかわらない場合
			if(s開始登録日 == axGT出荷一覧.get_CelText(n開始,16).Trim()
			&& s開始ジャーナルＮＯ == axGT出荷一覧.get_CelText(n開始,15).Trim()
			&& s終了登録日 == axGT出荷一覧.get_CelText(n終了,16).Trim()
			&& s終了ジャーナルＮＯ == axGT出荷一覧.get_CelText(n終了,15).Trim()){
				n新開始 = n開始;
				n新終了 = n終了;
			}else{
				for(short n行 = 1; n行 <= axGT出荷一覧.Rows; n行++){
					//選択開始行の値（登録日、ジャーナルＮＯ）が同じ場合
					if(s開始登録日 == axGT出荷一覧.get_CelText(n行,16).Trim()
					&& s開始ジャーナルＮＯ == axGT出荷一覧.get_CelText(n行,15).Trim()){
						n新開始 = n行;
					}
					//選択終了行の値（登録日、ジャーナルＮＯ）が同じ場合
					if(s終了登録日 == axGT出荷一覧.get_CelText(n行,16).Trim()
					&& s終了ジャーナルＮＯ == axGT出荷一覧.get_CelText(n行,15).Trim()){
						n新終了 = n行;
						break;
					}
				}
			}
			//スクロール位置の設定
			if(n表示開始 <= axGT出荷一覧.Rows){
				axGT出荷一覧.TopRow = n表示開始;
			}
			//再検索後の一覧に該当データが存在する場合
			if(n新終了 > 0){
//保留：間の行のチェック
				//選択行数が同じ場合
				if(n新開始 > 0 && (n終了 - n開始 == n新終了 - n新開始)){
					axGT出荷一覧.CaretRow    = n新開始;
					axGT出荷一覧.SelStartRow = n新開始;
					axGT出荷一覧.SelEndRow   = n新終了;
				}else{
					axGT出荷一覧.CaretRow    = n新終了;
					axGT出荷一覧.SelStartRow = n新終了;
					axGT出荷一覧.SelEndRow   = n新終了;
				}
			}else{
				if(s次行登録日.Length > 0 && s次行ジャーナルＮＯ.Length > 0){
					for(short n行 = 1; n行 <= axGT出荷一覧.Rows; n行++){
						//選択開始行の値（登録日、ジャーナルＮＯ）が同じ場合
						if(s次行登録日 == axGT出荷一覧.get_CelText(n行,16).Trim()
						&& s次行ジャーナルＮＯ == axGT出荷一覧.get_CelText(n行,15).Trim()){
							axGT出荷一覧.CaretRow    = n行;
							axGT出荷一覧.SelStartRow = n行;
							axGT出荷一覧.SelEndRow   = n行;
							break;
						}
					}
				}
			}
			axGT出荷一覧_CurPlaceChanged(null,null);
		}
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 END

	}
}
