using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [アドレス帳]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// ADD 2007.01.30 FJCS）桑田 検索条件に名前追加 
	// MOD 2007.02.08 FJCS）桑田 文言変更 
	// MOD 2007.03.12 FJCS）桑田 エンターキー押下による検索開始タイミングの変更 
	// ADD 2007.03.12 FJCS）桑田 項目クリア 
	//--------------------------------------------------------------------------
	// ADD 2009.01.29 東都）高木 一覧に名前２、住所２、住所３を追加 
	// MOD 2009.12.08 東都）高木 頁移動クリア処理の追加 
	//--------------------------------------------------------------------------
	// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 
	// MOD 2010.02.03 東都）高木 検索条件に更新日を追加 
	// MOD 2010.02.03 東都）高木 ソート条件の保持機能を追加 
	// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 
	// MOD 2010.06.03 東都）高木 複数件削除機能の高速化 
	// MOD 2010.09.22 東都）高木 削除：[いいえ]選択時の障害修正 
	// MOD 2010.09.22 東都）高木 ＣＳＶ出力：[キャンセル]選択時の障害修正 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない 
	// MOD 2011.01.25 東都）高木 「ロードに失敗」対応 
	//--------------------------------------------------------------------------
	public class お届け先検索 : 共通フォーム
	{
		public short OldRow = 0;
		private short nSrow = 0;
		private short nErow = 0;
		private short nWork = 0;

		public string sTcode = "";
		public string sTname = "";
		private short nOldRow = 0;
		public string s複写;

		private string[] s届け先一覧;
		private int      i現在頁数;
		private int      i最大頁数;
		private int      i開始数;
		private int      i終了数;
		private int      iアクティブＦＧ = 0;
// ADD 2006.12.14 東都）小童谷 明細の余白を除去 START
		private int      i頁最大行数 = 100;
// ADD 2006.12.14 東都）小童谷 明細の余白を除去 END
		
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Button btn複写;
		private 共通テキストボックス tex届け先カナ;
		private System.Windows.Forms.Button btn確定;
		private 共通テキストボックス tex届け先コード;
		private System.Windows.Forms.Button btn検索;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.Button btn閉じる;
		private AxGTABLE32V2Lib.AxGTable32 axGT届け先;
		private System.Windows.Forms.Label lab届け先カナ;
		private System.Windows.Forms.Label lab届け先コード;
		private System.Windows.Forms.Label lab届け先タイトル;
		private System.Windows.Forms.Label lab頁番号;
		private System.Windows.Forms.Button btn次頁;
		private System.Windows.Forms.Button btn前頁;
		private System.Windows.Forms.Label label1;
		private IS2Client.共通テキストボックス tex電話番号;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cb階層リスト１;
		private System.Windows.Forms.ComboBox cb階層リスト２;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private IS2Client.共通テキストボックス tex電話番号2;
		private IS2Client.共通テキストボックス tex電話番号3;
		private System.Windows.Forms.Button btnCSV出力;
		private System.Windows.Forms.Button btn一覧印刷;
		private System.Windows.Forms.Button btn削除;
		private System.Windows.Forms.ComboBox cbソート方向１;
		private System.Windows.Forms.ComboBox cbソート方向２;
// ADD 2006.07.05 東都）ＣＳＶ出力機能追加 START
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lab届け先名前;
		private IS2Client.共通テキストボックス tex届け先名前;
		private System.Windows.Forms.CheckBox cb名前住所詳細表示;
		private System.Windows.Forms.CheckBox cb更新日;
		private System.Windows.Forms.GroupBox gp検索;
		private System.Windows.Forms.GroupBox gp一覧;
		private System.Windows.Forms.DateTimePicker dt更新日;
		private System.Windows.Forms.GroupBox gp表示順;
// ADD 2006.07.05 東都）ＣＳＶ出力機能追加 END
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public お届け先検索()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
			ＤＰＩ表示サイズ変換();
//			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
				this.axGT届け先.Size = new System.Drawing.Size(716, 326);
//			}
// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 END
// MOD 2010.02.03 東都）高木 ソート条件の保持機能を追加 START
			cb階層リスト１.SelectedIndex = 1;
			cb階層リスト２.SelectedIndex = 0;
			cbソート方向１.SelectedIndex = 0;
			cbソート方向２.SelectedIndex = 0;
// MOD 2010.02.03 東都）高木 ソート条件の保持機能を追加 END
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 START
			if(gsアドレス帳_表示順１ != null){
				cb階層リスト１.Text = gsアドレス帳_表示順１;
			}
			if(gsアドレス帳_表示順１_方向 != null){
				cbソート方向１.Text = gsアドレス帳_表示順１_方向;
			}
			if(gsアドレス帳_表示順２ != null){
				cb階層リスト２.Text = gsアドレス帳_表示順２;
			}
			if(gsアドレス帳_表示順２_方向 != null){
				cbソート方向２.Text = gsアドレス帳_表示順２_方向;
			}
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 END
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(お届け先検索));
			this.panel1 = new System.Windows.Forms.Panel();
			this.axGT届け先 = new AxGTABLE32V2Lib.AxGTable32();
			this.lab頁番号 = new System.Windows.Forms.Label();
			this.btn次頁 = new System.Windows.Forms.Button();
			this.btn前頁 = new System.Windows.Forms.Button();
			this.btn確定 = new System.Windows.Forms.Button();
			this.panel5 = new System.Windows.Forms.Panel();
			this.gp表示順 = new System.Windows.Forms.GroupBox();
			this.cbソート方向１ = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cb階層リスト１ = new System.Windows.Forms.ComboBox();
			this.cb階層リスト２ = new System.Windows.Forms.ComboBox();
			this.cbソート方向２ = new System.Windows.Forms.ComboBox();
			this.dt更新日 = new System.Windows.Forms.DateTimePicker();
			this.cb更新日 = new System.Windows.Forms.CheckBox();
			this.cb名前住所詳細表示 = new System.Windows.Forms.CheckBox();
			this.tex届け先名前 = new IS2Client.共通テキストボックス();
			this.lab届け先名前 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.tex電話番号2 = new IS2Client.共通テキストボックス();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tex電話番号3 = new IS2Client.共通テキストボックス();
			this.tex電話番号 = new IS2Client.共通テキストボックス();
			this.tex届け先カナ = new IS2Client.共通テキストボックス();
			this.lab届け先カナ = new System.Windows.Forms.Label();
			this.lab届け先コード = new System.Windows.Forms.Label();
			this.tex届け先コード = new IS2Client.共通テキストボックス();
			this.btn検索 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab届け先タイトル = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn削除 = new System.Windows.Forms.Button();
			this.btn一覧印刷 = new System.Windows.Forms.Button();
			this.btnCSV出力 = new System.Windows.Forms.Button();
			this.btn複写 = new System.Windows.Forms.Button();
			this.texメッセージ = new System.Windows.Forms.TextBox();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.panel6 = new System.Windows.Forms.Panel();
			this.gp検索 = new System.Windows.Forms.GroupBox();
			this.gp一覧 = new System.Windows.Forms.GroupBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axGT届け先)).BeginInit();
			this.panel5.SuspendLayout();
			this.gp表示順.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.gp検索.SuspendLayout();
			this.gp一覧.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Honeydew;
			this.panel1.Controls.Add(this.axGT届け先);
			this.panel1.Controls.Add(this.lab頁番号);
			this.panel1.Controls.Add(this.btn次頁);
			this.panel1.Controls.Add(this.btn前頁);
			this.panel1.Controls.Add(this.btn確定);
			this.panel1.Location = new System.Drawing.Point(1, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(739, 360);
			this.panel1.TabIndex = 0;
			// 
			// axGT届け先
			// 
			this.axGT届け先.ContainingControl = this;
			this.axGT届け先.DataSource = null;
			this.axGT届け先.Location = new System.Drawing.Point(14, 4);
			this.axGT届け先.Name = "axGT届け先";
			this.axGT届け先.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT届け先.OcxState")));
			this.axGT届け先.Size = new System.Drawing.Size(716, 326);
			this.axGT届け先.TabIndex = 0;
			this.axGT届け先.KeyDownEvent += new AxGTABLE32V2Lib._DGTable32Events_KeyDownEventHandler(this.axGT届け先_KeyDownEvent);
			this.axGT届け先.CelClick += new AxGTABLE32V2Lib._DGTable32Events_CelClickEventHandler(this.axGT届け先_CelClick);
			this.axGT届け先.CelDblClick += new AxGTABLE32V2Lib._DGTable32Events_CelDblClickEventHandler(this.axGT届け先_CelDblClick);
			this.axGT届け先.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT届け先_CurPlaceChanged);
			// 
			// lab頁番号
			// 
			this.lab頁番号.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab頁番号.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab頁番号.Location = new System.Drawing.Point(518, 338);
			this.lab頁番号.Name = "lab頁番号";
			this.lab頁番号.Size = new System.Drawing.Size(56, 14);
			this.lab頁番号.TabIndex = 67;
			this.lab頁番号.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn次頁
			// 
			this.btn次頁.BackColor = System.Drawing.Color.SteelBlue;
			this.btn次頁.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn次頁.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn次頁.ForeColor = System.Drawing.Color.White;
			this.btn次頁.Location = new System.Drawing.Point(576, 334);
			this.btn次頁.Name = "btn次頁";
			this.btn次頁.Size = new System.Drawing.Size(48, 22);
			this.btn次頁.TabIndex = 66;
			this.btn次頁.Text = "次頁";
			this.btn次頁.Click += new System.EventHandler(this.btn次頁_Click);
			// 
			// btn前頁
			// 
			this.btn前頁.BackColor = System.Drawing.Color.SteelBlue;
			this.btn前頁.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn前頁.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn前頁.ForeColor = System.Drawing.Color.White;
			this.btn前頁.Location = new System.Drawing.Point(468, 334);
			this.btn前頁.Name = "btn前頁";
			this.btn前頁.Size = new System.Drawing.Size(48, 22);
			this.btn前頁.TabIndex = 65;
			this.btn前頁.Text = "前頁";
			this.btn前頁.Click += new System.EventHandler(this.btn前頁_Click);
			// 
			// btn確定
			// 
			this.btn確定.BackColor = System.Drawing.Color.SteelBlue;
			this.btn確定.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn確定.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn確定.ForeColor = System.Drawing.Color.White;
			this.btn確定.Location = new System.Drawing.Point(648, 334);
			this.btn確定.Name = "btn確定";
			this.btn確定.Size = new System.Drawing.Size(64, 22);
			this.btn確定.TabIndex = 1;
			this.btn確定.TabStop = false;
			this.btn確定.Text = "確定";
			this.btn確定.Click += new System.EventHandler(this.btn確定_Click);
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.Honeydew;
			this.panel5.Controls.Add(this.gp表示順);
			this.panel5.Controls.Add(this.dt更新日);
			this.panel5.Controls.Add(this.cb更新日);
			this.panel5.Controls.Add(this.cb名前住所詳細表示);
			this.panel5.Controls.Add(this.tex届け先名前);
			this.panel5.Controls.Add(this.lab届け先名前);
			this.panel5.Controls.Add(this.label8);
			this.panel5.Controls.Add(this.tex電話番号2);
			this.panel5.Controls.Add(this.label7);
			this.panel5.Controls.Add(this.label6);
			this.panel5.Controls.Add(this.tex電話番号3);
			this.panel5.Controls.Add(this.tex電話番号);
			this.panel5.Controls.Add(this.tex届け先カナ);
			this.panel5.Controls.Add(this.lab届け先カナ);
			this.panel5.Controls.Add(this.lab届け先コード);
			this.panel5.Controls.Add(this.tex届け先コード);
			this.panel5.Controls.Add(this.btn検索);
			this.panel5.Controls.Add(this.label5);
			this.panel5.Location = new System.Drawing.Point(2, 6);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(738, 88);
			this.panel5.TabIndex = 0;
			// 
			// gp表示順
			// 
			this.gp表示順.Controls.Add(this.cbソート方向１);
			this.gp表示順.Controls.Add(this.label4);
			this.gp表示順.Controls.Add(this.label3);
			this.gp表示順.Controls.Add(this.cb階層リスト１);
			this.gp表示順.Controls.Add(this.cb階層リスト２);
			this.gp表示順.Controls.Add(this.cbソート方向２);
			this.gp表示順.Location = new System.Drawing.Point(498, -2);
			this.gp表示順.Name = "gp表示順";
			this.gp表示順.Size = new System.Drawing.Size(236, 60);
			this.gp表示順.TabIndex = 57;
			this.gp表示順.TabStop = false;
			// 
			// cbソート方向１
			// 
			this.cbソート方向１.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbソート方向１.Items.AddRange(new object[] {
														  "昇順",
														  "降順"});
			this.cbソート方向１.Location = new System.Drawing.Point(170, 10);
			this.cbソート方向１.Name = "cbソート方向１";
			this.cbソート方向１.Size = new System.Drawing.Size(60, 20);
			this.cbソート方向１.TabIndex = 10;
			this.cbソート方向１.Visible = false;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label4.ForeColor = System.Drawing.Color.LimeGreen;
			this.label4.Location = new System.Drawing.Point(6, 36);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 49;
			this.label4.Text = "表示順２";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label3.ForeColor = System.Drawing.Color.LimeGreen;
			this.label3.Location = new System.Drawing.Point(6, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 48;
			this.label3.Text = "表示順１";
			// 
			// cb階層リスト１
			// 
			this.cb階層リスト１.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb階層リスト１.Items.AddRange(new object[] {
														  "",
														  "カナ略称",
														  "お届け先コード",
														  "電話番号",
														  "名前",
														  "登録日時",
														  "更新日時"});
			this.cb階層リスト１.Location = new System.Drawing.Point(70, 10);
			this.cb階層リスト１.Name = "cb階層リスト１";
			this.cb階層リスト１.Size = new System.Drawing.Size(96, 20);
			this.cb階層リスト１.TabIndex = 9;
			this.cb階層リスト１.SelectedIndexChanged += new System.EventHandler(this.cb階層１選択_select);
			// 
			// cb階層リスト２
			// 
			this.cb階層リスト２.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb階層リスト２.Items.AddRange(new object[] {
														  "",
														  "カナ略称",
														  "お届け先コード",
														  "電話番号",
														  "名前",
														  "登録日時",
														  "更新日時"});
			this.cb階層リスト２.Location = new System.Drawing.Point(70, 34);
			this.cb階層リスト２.Name = "cb階層リスト２";
			this.cb階層リスト２.Size = new System.Drawing.Size(96, 20);
			this.cb階層リスト２.TabIndex = 11;
			this.cb階層リスト２.SelectedIndexChanged += new System.EventHandler(this.cb階層２選択_select);
			// 
			// cbソート方向２
			// 
			this.cbソート方向２.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbソート方向２.Items.AddRange(new object[] {
														  "昇順",
														  "降順"});
			this.cbソート方向２.Location = new System.Drawing.Point(170, 34);
			this.cbソート方向２.Name = "cbソート方向２";
			this.cbソート方向２.Size = new System.Drawing.Size(60, 20);
			this.cbソート方向２.TabIndex = 12;
			this.cbソート方向２.Visible = false;
			// 
			// dt更新日
			// 
			this.dt更新日.Enabled = false;
			this.dt更新日.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.dt更新日.Location = new System.Drawing.Point(344, 4);
			this.dt更新日.Name = "dt更新日";
			this.dt更新日.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.dt更新日.Size = new System.Drawing.Size(144, 23);
			this.dt更新日.TabIndex = 2;
			// 
			// cb更新日
			// 
			this.cb更新日.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold);
			this.cb更新日.ForeColor = System.Drawing.Color.LimeGreen;
			this.cb更新日.Location = new System.Drawing.Point(272, 4);
			this.cb更新日.Name = "cb更新日";
			this.cb更新日.Size = new System.Drawing.Size(72, 24);
			this.cb更新日.TabIndex = 1;
			this.cb更新日.Text = "更新日";
			this.cb更新日.CheckedChanged += new System.EventHandler(this.cb更新日_CheckedChanged);
			// 
			// cb名前住所詳細表示
			// 
			this.cb名前住所詳細表示.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold);
			this.cb名前住所詳細表示.ForeColor = System.Drawing.Color.LimeGreen;
			this.cb名前住所詳細表示.Location = new System.Drawing.Point(272, 32);
			this.cb名前住所詳細表示.Name = "cb名前住所詳細表示";
			this.cb名前住所詳細表示.Size = new System.Drawing.Size(172, 24);
			this.cb名前住所詳細表示.TabIndex = 6;
			this.cb名前住所詳細表示.Text = "名前・住所詳細表示";
			// 
			// tex届け先名前
			// 
			this.tex届け先名前.BackColor = System.Drawing.SystemColors.Window;
			this.tex届け先名前.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex届け先名前.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex届け先名前.Location = new System.Drawing.Point(254, 60);
			this.tex届け先名前.MaxLength = 20;
			this.tex届け先名前.Name = "tex届け先名前";
			this.tex届け先名前.Size = new System.Drawing.Size(234, 23);
			this.tex届け先名前.TabIndex = 8;
			this.tex届け先名前.Text = "";
			this.tex届け先名前.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex届け先名前_KeyDown);
			// 
			// lab届け先名前
			// 
			this.lab届け先名前.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab届け先名前.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab届け先名前.Location = new System.Drawing.Point(214, 62);
			this.lab届け先名前.Name = "lab届け先名前";
			this.lab届け先名前.Size = new System.Drawing.Size(38, 16);
			this.lab届け先名前.TabIndex = 56;
			this.lab届け先名前.Text = "名前";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label8.ForeColor = System.Drawing.Color.LimeGreen;
			this.label8.Location = new System.Drawing.Point(92, 36);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(10, 16);
			this.label8.TabIndex = 3;
			this.label8.Text = "（";
			// 
			// tex電話番号2
			// 
			this.tex電話番号2.BackColor = System.Drawing.SystemColors.Window;
			this.tex電話番号2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex電話番号2.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex電話番号2.Location = new System.Drawing.Point(154, 32);
			this.tex電話番号2.MaxLength = 4;
			this.tex電話番号2.Name = "tex電話番号2";
			this.tex電話番号2.Size = new System.Drawing.Size(42, 23);
			this.tex電話番号2.TabIndex = 4;
			this.tex電話番号2.Text = "";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label7.ForeColor = System.Drawing.Color.LimeGreen;
			this.label7.Location = new System.Drawing.Point(192, 36);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(18, 16);
			this.label7.TabIndex = 54;
			this.label7.Text = "－";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label6.ForeColor = System.Drawing.Color.LimeGreen;
			this.label6.Location = new System.Drawing.Point(144, 36);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(8, 16);
			this.label6.TabIndex = 2;
			this.label6.Text = "）";
			// 
			// tex電話番号3
			// 
			this.tex電話番号3.BackColor = System.Drawing.SystemColors.Window;
			this.tex電話番号3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex電話番号3.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex電話番号3.Location = new System.Drawing.Point(210, 32);
			this.tex電話番号3.MaxLength = 5;
			this.tex電話番号3.Name = "tex電話番号3";
			this.tex電話番号3.Size = new System.Drawing.Size(50, 23);
			this.tex電話番号3.TabIndex = 5;
			this.tex電話番号3.Text = "";
			// 
			// tex電話番号
			// 
			this.tex電話番号.BackColor = System.Drawing.SystemColors.Window;
			this.tex電話番号.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex電話番号.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex電話番号.Location = new System.Drawing.Point(104, 32);
			this.tex電話番号.MaxLength = 4;
			this.tex電話番号.Name = "tex電話番号";
			this.tex電話番号.Size = new System.Drawing.Size(42, 23);
			this.tex電話番号.TabIndex = 3;
			this.tex電話番号.Text = "";
			// 
			// tex届け先カナ
			// 
			this.tex届け先カナ.BackColor = System.Drawing.SystemColors.Window;
			this.tex届け先カナ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex届け先カナ.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
			this.tex届け先カナ.Location = new System.Drawing.Point(104, 60);
			this.tex届け先カナ.MaxLength = 10;
			this.tex届け先カナ.Name = "tex届け先カナ";
			this.tex届け先カナ.Size = new System.Drawing.Size(104, 23);
			this.tex届け先カナ.TabIndex = 7;
			this.tex届け先カナ.Text = "";
			// 
			// lab届け先カナ
			// 
			this.lab届け先カナ.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab届け先カナ.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab届け先カナ.Location = new System.Drawing.Point(6, 62);
			this.lab届け先カナ.Name = "lab届け先カナ";
			this.lab届け先カナ.Size = new System.Drawing.Size(70, 16);
			this.lab届け先カナ.TabIndex = 46;
			this.lab届け先カナ.Text = "カナ略称";
			// 
			// lab届け先コード
			// 
			this.lab届け先コード.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab届け先コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab届け先コード.Location = new System.Drawing.Point(6, 8);
			this.lab届け先コード.Name = "lab届け先コード";
			this.lab届け先コード.Size = new System.Drawing.Size(96, 16);
			this.lab届け先コード.TabIndex = 6;
			this.lab届け先コード.Text = "お届け先コード";
			// 
			// tex届け先コード
			// 
			this.tex届け先コード.BackColor = System.Drawing.SystemColors.Window;
			this.tex届け先コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex届け先コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex届け先コード.Location = new System.Drawing.Point(104, 4);
			this.tex届け先コード.MaxLength = 15;
			this.tex届け先コード.Name = "tex届け先コード";
			this.tex届け先コード.Size = new System.Drawing.Size(150, 23);
			this.tex届け先コード.TabIndex = 0;
			this.tex届け先コード.Text = "";
			// 
			// btn検索
			// 
			this.btn検索.BackColor = System.Drawing.Color.SteelBlue;
			this.btn検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn検索.ForeColor = System.Drawing.Color.White;
			this.btn検索.Location = new System.Drawing.Point(496, 60);
			this.btn検索.Name = "btn検索";
			this.btn検索.Size = new System.Drawing.Size(64, 22);
			this.btn検索.TabIndex = 13;
			this.btn検索.TabStop = false;
			this.btn検索.Text = "検索";
			this.btn検索.Click += new System.EventHandler(this.btn検索_Click);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label5.ForeColor = System.Drawing.Color.LimeGreen;
			this.label5.Location = new System.Drawing.Point(6, 36);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 16);
			this.label5.TabIndex = 50;
			this.label5.Text = "電話番号";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.lab届け先タイトル);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(794, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab届け先タイトル
			// 
			this.lab届け先タイトル.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab届け先タイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab届け先タイトル.ForeColor = System.Drawing.Color.White;
			this.lab届け先タイトル.Location = new System.Drawing.Point(12, 2);
			this.lab届け先タイトル.Name = "lab届け先タイトル";
			this.lab届け先タイトル.Size = new System.Drawing.Size(264, 24);
			this.lab届け先タイトル.TabIndex = 0;
			this.lab届け先タイトル.Text = "アドレス帳";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn削除);
			this.panel8.Controls.Add(this.btn一覧印刷);
			this.panel8.Controls.Add(this.btnCSV出力);
			this.panel8.Controls.Add(this.btn複写);
			this.panel8.Controls.Add(this.texメッセージ);
			this.panel8.Controls.Add(this.btn閉じる);
			this.panel8.Location = new System.Drawing.Point(0, 518);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(794, 58);
			this.panel8.TabIndex = 7;
			// 
			// btn削除
			// 
			this.btn削除.ForeColor = System.Drawing.Color.Blue;
			this.btn削除.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn削除.Location = new System.Drawing.Point(206, 6);
			this.btn削除.Name = "btn削除";
			this.btn削除.Size = new System.Drawing.Size(62, 48);
			this.btn削除.TabIndex = 5;
			this.btn削除.Text = "削除";
			this.btn削除.Visible = false;
			this.btn削除.Click += new System.EventHandler(this.btn削除_Click);
			// 
			// btn一覧印刷
			// 
			this.btn一覧印刷.ForeColor = System.Drawing.Color.Blue;
			this.btn一覧印刷.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn一覧印刷.Location = new System.Drawing.Point(276, 6);
			this.btn一覧印刷.Name = "btn一覧印刷";
			this.btn一覧印刷.Size = new System.Drawing.Size(62, 48);
			this.btn一覧印刷.TabIndex = 4;
			this.btn一覧印刷.Text = "一覧表　印刷";
			this.btn一覧印刷.Visible = false;
			this.btn一覧印刷.Click += new System.EventHandler(this.btn一覧印刷_Click);
			// 
			// btnCSV出力
			// 
			this.btnCSV出力.ForeColor = System.Drawing.Color.Blue;
			this.btnCSV出力.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnCSV出力.Location = new System.Drawing.Point(346, 5);
			this.btnCSV出力.Name = "btnCSV出力";
			this.btnCSV出力.Size = new System.Drawing.Size(62, 48);
			this.btnCSV出力.TabIndex = 3;
			this.btnCSV出力.Text = "ＣＳＶ　　出力";
			this.btnCSV出力.Visible = false;
			this.btnCSV出力.Click += new System.EventHandler(this.btnCSV出力_Click);
			// 
			// btn複写
			// 
			this.btn複写.ForeColor = System.Drawing.Color.Blue;
			this.btn複写.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn複写.Location = new System.Drawing.Point(98, 6);
			this.btn複写.Name = "btn複写";
			this.btn複写.Size = new System.Drawing.Size(62, 48);
			this.btn複写.TabIndex = 1;
			this.btn複写.Text = "複写";
			this.btn複写.Visible = false;
			this.btn複写.Click += new System.EventHandler(this.btn複写_Click);
			// 
			// texメッセージ
			// 
			this.texメッセージ.BackColor = System.Drawing.Color.PaleGreen;
			this.texメッセージ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texメッセージ.ForeColor = System.Drawing.Color.Red;
			this.texメッセージ.Location = new System.Drawing.Point(414, 4);
			this.texメッセージ.Multiline = true;
			this.texメッセージ.Name = "texメッセージ";
			this.texメッセージ.ReadOnly = true;
			this.texメッセージ.Size = new System.Drawing.Size(376, 50);
			this.texメッセージ.TabIndex = 2;
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
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.PaleGreen;
			this.panel6.Location = new System.Drawing.Point(0, 26);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(794, 26);
			this.panel6.TabIndex = 15;
			// 
			// gp検索
			// 
			this.gp検索.Controls.Add(this.panel5);
			this.gp検索.Location = new System.Drawing.Point(26, 52);
			this.gp検索.Name = "gp検索";
			this.gp検索.Size = new System.Drawing.Size(742, 96);
			this.gp検索.TabIndex = 0;
			this.gp検索.TabStop = false;
			// 
			// gp一覧
			// 
			this.gp一覧.Controls.Add(this.panel1);
			this.gp一覧.Location = new System.Drawing.Point(26, 148);
			this.gp一覧.Name = "gp一覧";
			this.gp一覧.Size = new System.Drawing.Size(742, 368);
			this.gp一覧.TabIndex = 6;
			this.gp一覧.TabStop = false;
			// 
			// お届け先検索
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 574);
			this.Controls.Add(this.gp一覧);
			this.Controls.Add(this.gp検索);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "お届け先検索";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 アドレス帳";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Closed += new System.EventHandler(this.お届け先検索_Closed);
			this.Activated += new System.EventHandler(this.お届け先検索_Activated);
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axGT届け先)).EndInit();
			this.panel5.ResumeLayout(false);
			this.gp表示順.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.gp検索.ResumeLayout(false);
			this.gp一覧.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			iアクティブＦＧ = 0;
			tex届け先コード.Text = sTcode;
			sTcode = "";
			s複写 = "";
// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 START
//			axGT届け先.Cols = 5;
			axGT届け先.Cols = 13;
// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 END
// MOD 2006.12.14 東都）小童谷 明細の余白を除去 START
// MOD 2006.07.05 東都）山本 １ページ表示行数の変更（スクロール）対応 START
////		axGT届け先.Rows = 16;
//			axGT届け先.Rows = 100;
// MOD 2006.07.05 東都）山本 １ページ表示行数の変更（スクロール）対応 END
			axGT届け先.Rows = 16;
// MOD 2006.12.14 東都）小童谷 明細の余白を除去 END
			axGT届け先.ColSep = "|";

// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 START
//// MOD 2007.02.08 FJCS）桑田 文言変更 START
////			axGT届け先.set_RowsText(0, "|名前|住所|エントリーコード|電話番号|カナ略称|");
//			axGT届け先.set_RowsText(0, "|名前|住所|お届け先コード|電話番号|カナ略称|");
//// MOD 2007.02.08 FJCS）桑田 文言変更 END
//
//			axGT届け先.ColsWidth = "0|14.2|14.2|9.7|8.6|7|";
//			axGT届け先.ColsAlignHorz = "1|0|0|0|0|0|";

			axGT届け先.set_RowsText(0, "|名前|住所|お届け先コード|電話番号|カナ略称|郵便番号|特殊計|メールアドレス|住所コード|着店|登録日時|更新日時|ｴﾝﾄﾘ-使用日|");
			axGT届け先.ColsWidth = "0|14.2|14.2|9.7|8.6|7|4.2|0|0|0|0|9.2|9.2|5.8|";
			axGT届け先.ColsAlignHorz = "1|0|0|0|0|0|1|0|0|0|1|1|1|1|";
// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 END

//			axGT届け先.set_CelForeColor(axGT届け先.CaretRow,0,111111);
			axGT届け先.set_CelForeColor(axGT届け先.CaretRow,0,0x98FB98);  //BGR
			axGT届け先.set_CelBackColor(axGT届け先.CaretRow,0,0x006000);
			
			btn前頁.Enabled = false;
			btn次頁.Enabled = false;
			lab頁番号.Text = "";

// MOD 2010.02.03 東都）高木 ソート条件の保持機能を追加 START
//// ADD 2006.07.04 東都）山本 ソート機能追加 START
//			cb階層リスト１.SelectedIndex = 1;
//			cb階層リスト２.SelectedIndex = 0;
//			cbソート方向１.SelectedIndex = 0;
//			cbソート方向２.SelectedIndex = 0;
//// ADD 2006.07.04 東都）山本 ソート機能追加 END
// MOD 2010.02.03 東都）高木 ソート条件の保持機能を追加 END
		}

		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
			sTcode = "";
			this.Close();
		}

		public void Visible複写()
		{
			btn複写.Visible = true;
		}

		private void axGT届け先_CelDblClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelDblClickEvent e)
		{
			sTname = axGT届け先.get_CelText(axGT届け先.CaretRow,1);
			sTcode = axGT届け先.get_CelText(axGT届け先.CaretRow,3);
			if(sTcode != "")
				this.Close();

		}

		private void axGT届け先_CurPlaceChanged(object sender, AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEvent e)
		{
// MOD 2006.12.11 東都）小童谷 複数選択時の背景色変更 START
/*			axGT届け先.set_CelForeColor(nOldRow,0,0);
			axGT届け先.set_CelBackColor(nOldRow,0,0xFFFFFF);
//			axGT届け先.set_CelForeColor(axGT届け先.CaretRow,0,111111);
			axGT届け先.set_CelForeColor(axGT届け先.CaretRow,0,0x98FB98);  //BGR
			axGT届け先.set_CelBackColor(axGT届け先.CaretRow,0,0x006000);
			nOldRow = axGT届け先.CaretRow;
*/
			axGT届け先.set_CelForeColor(OldRow,0,0);
			axGT届け先.set_CelBackColor(OldRow,0,0xFFFFFF);
			if(axGT届け先.SelStartRow == axGT届け先.SelEndRow)
			{
				if(nSrow > nErow)
				{
					nWork = nSrow;
					nSrow = nErow;
					nErow = nWork;
				}
				for(short nCnt = nSrow; nCnt <= nErow; nCnt++)
				{
					axGT届け先.set_CelForeColor(nCnt,0,0);
					axGT届け先.set_CelBackColor(nCnt,0,0xFFFFFF);
				}
			}
			axGT届け先.set_CelForeColor(axGT届け先.SelStartRow,0,0x98FB98);
			axGT届け先.set_CelBackColor(axGT届け先.SelStartRow,0,0x006000);
			axGT届け先.set_CelForeColor(axGT届け先.SelEndRow,0,0x98FB98);
			axGT届け先.set_CelBackColor(axGT届け先.SelEndRow,0,0x006000);
			axGT届け先.set_CelForeColor(axGT届け先.CaretRow,0,0x98FB98);
			axGT届け先.set_CelBackColor(axGT届け先.CaretRow,0,0x006000);
			if(axGT届け先.SelEndRow > axGT届け先.CaretRow
				&& axGT届け先.SelStartRow <= axGT届け先.CaretRow
				&& axGT届け先.get_CelForeColor(axGT届け先.SelEndRow,0) != Color.Black)
			{
				axGT届け先.set_CelForeColor(axGT届け先.SelEndRow,0,0);
				axGT届け先.set_CelBackColor(axGT届け先.SelEndRow,0,0xFFFFFF);
			}

			if(axGT届け先.SelEndRow < axGT届け先.CaretRow
				&& axGT届け先.SelStartRow >= axGT届け先.CaretRow
				&& axGT届け先.get_CelForeColor(axGT届け先.SelEndRow,0) != Color.Black)
			{
				axGT届け先.set_CelForeColor(axGT届け先.SelEndRow,0,0);
				axGT届け先.set_CelBackColor(axGT届け先.SelEndRow,0,0xFFFFFF);
			}

			OldRow = axGT届け先.CaretRow;
			nSrow  = axGT届け先.SelStartRow;
			nErow  = axGT届け先.SelEndRow;
// MOD 2006.12.11 東都）小童谷 複数選択時の背景色変更 END

		}

		private void btn検索_Click(object sender, System.EventArgs e)
		{
// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 START
			texメッセージ.Text = "";
// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 END

			iアクティブＦＧ = 1;
			axGT届け先.CaretRow  = 1;
// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 START
			axGT届け先.CaretCol  = 1;
// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 END
			axGT届け先_CurPlaceChanged(null,null);
			axGT届け先.Clear();
// MOD 2009.12.08 東都）高木 頁移動クリア処理の追加 START
			btn前頁.Enabled = false;
			btn次頁.Enabled = false;
			lab頁番号.Text = "";
// MOD 2009.12.08 東都）高木 頁移動クリア処理の追加 END

// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//			tex届け先カナ.Text   = tex届け先カナ.Text.Trim();
			if(gsオプション[18].Equals("1")){
				tex届け先カナ.Text   = tex届け先カナ.Text.TrimEnd();
			}else{
				tex届け先カナ.Text   = tex届け先カナ.Text.Trim();
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END

			tex届け先コード.Text = tex届け先コード.Text.Trim();
// ADD 2006.07.04 東都）山本 検索条件に電話番号追加 START
			tex電話番号.Text  = tex電話番号.Text.Trim();
			tex電話番号2.Text = tex電話番号2.Text.Trim();
			tex電話番号3.Text = tex電話番号3.Text.Trim();
// ADD 2006.07.04 東都）山本 検索条件に電話番号追加 END
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//// ADD 2007.01.30 FJCS）桑田 検索条件に名前追加 START
//			tex届け先名前.Text  = tex届け先名前.Text.Trim();
//// ADD 2007.01.30 FJCS）桑田 検索条件に名前追加 END
			if(gsオプション[18].Equals("1")){
				tex届け先名前.Text  = tex届け先名前.Text.TrimEnd();
			}else{
				tex届け先名前.Text  = tex届け先名前.Text.Trim();
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END

			if(!半角チェック(tex届け先カナ,"届け先カナ")) return;
			if(!半角チェック(tex届け先コード,"届け先コード")) return;
// ADD 2007.01.30 FJCS）桑田 検索条件に名前追加 START
			if(!全角チェック(tex届け先名前,"届け先名前")) return;
// ADD 2007.01.30 FJCS）桑田 検索条件に名前追加 END

			i現在頁数 = 1;
			axGT届け先.CaretRow = 1;
// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 START
			axGT届け先.CaretCol = 1;
// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 END
			axGT届け先.set_CelForeColor(nOldRow,0,0);
//			axGT届け先.set_CelForeColor(axGT届け先.CaretRow,0,111111);
			axGT届け先.set_CelForeColor(axGT届け先.CaretRow,0,0x98FB98);  //BGR
			axGT届け先.set_CelBackColor(axGT届け先.CaretRow,0,0x006000);
			nOldRow = axGT届け先.CaretRow;

			s届け先一覧 = new string[1];
			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				texメッセージ.Text = "検索中．．．";
				if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
// MOD 2010.02.03 東都）高木 検索条件に更新日を追加 START
//// ADD 2009.01.29 東都）高木 一覧に名前２、住所２、住所３を追加 START
////				s届け先一覧 = sv_otodoke.Get_todokesaki2(gsaユーザ,gs会員ＣＤ, gs部門ＣＤ,
////// ADD 2006.07.04 東都）山本 検索条件に電話番号＆ソート機能追加 START
//////												tex届け先カナ.Text, tex届け先コード.Text);
////// ADD 2007.01.30 FJCS）桑田 検索条件に名前追加 START
//////												tex届け先カナ.Text, tex届け先コード.Text,tex電話番号.Text,tex電話番号2.Text,tex電話番号3.Text,
////												tex届け先カナ.Text, tex届け先コード.Text,tex電話番号.Text,tex電話番号2.Text,tex電話番号3.Text,tex届け先名前.Text,
////// ADD 2007.01.30 FJCS）桑田 検索条件に名前追加 END
////												cb階層リスト１.SelectedIndex,cbソート方向１.SelectedIndex,
////												cb階層リスト２.SelectedIndex,cbソート方向２.SelectedIndex);
////// ADD 2006.07.04 東都）山本 検索条件に電話番号＆ソート機能追加 END
//				s届け先一覧 = sv_otodoke.Get_todokesaki3(
//					gsaユーザ, gs会員ＣＤ, gs部門ＣＤ
//					, tex届け先カナ.Text, tex届け先コード.Text
//					, tex電話番号.Text, tex電話番号2.Text, tex電話番号3.Text
//					, tex届け先名前.Text
//					, cb階層リスト１.SelectedIndex,cbソート方向１.SelectedIndex
//					, cb階層リスト２.SelectedIndex,cbソート方向２.SelectedIndex
//					, cb名前住所詳細表示.Checked
//					);
//// ADD 2009.01.29 東都）高木 一覧に名前２、住所２、住所３を追加 END
				s届け先一覧 = sv_otodoke.Get_todokesaki4(
					gsaユーザ, gs会員ＣＤ, gs部門ＣＤ
					, tex届け先カナ.Text, tex届け先コード.Text
					, tex電話番号.Text, tex電話番号2.Text, tex電話番号3.Text
					, tex届け先名前.Text
					, cb階層リスト１.SelectedIndex,cbソート方向１.SelectedIndex
					, cb階層リスト２.SelectedIndex,cbソート方向２.SelectedIndex
					, cb名前住所詳細表示.Checked
					, (cb更新日.Checked) ? dt更新日.Value.ToString("yyyyMMdd") : ""
					);
// MOD 2010.02.03 東都）高木 検索条件に更新日を追加 END
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				s届け先一覧[0] = gs通信エラー;
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				s届け先一覧[0] = "通信エラー：" + ex.Message;
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;

			texメッセージ.Text = s届け先一覧[0];
			if(s届け先一覧[0].Length == 4) //正常終了
			{
				texメッセージ.Text = "";
// MOD 2005.05.10 東都）小童谷 一行目空白 START
//				i最大頁数 = (s届け先一覧.Length - 2) / axGT届け先.Rows + 1;
// MOD 2006.12.14 東都）小童谷 明細の余白を除去 START
//				i最大頁数 = (s届け先一覧.Length - 2) / (axGT届け先.Rows - 1) + 1;
				i最大頁数 = (s届け先一覧.Length - 2) / (i頁最大行数 - 1) + 1;
// MOD 2006.12.14 東都）小童谷 明細の余白を除去 END
// MOD 2005.05.10 東都）小童谷 一行目空白 END
				if (i現在頁数 > i最大頁数)
					i現在頁数 = i最大頁数;
				頁情報設定();
			}
			else
			{
				if(s届け先一覧[0].Equals("該当データがありません"))
				{
					texメッセージ.Text = "";
					MessageBox.Show("該当データがありません","お届け先検索",MessageBoxButtons.OK);
				}
				else
				{
					axGT届け先.Clear();
					i現在頁数 = 1;
					btn前頁.Enabled = false;
					btn次頁.Enabled = false;
					lab頁番号.Text = "";
					ビープ音();
				}
// MOD 2006.12.11 東都）小童谷 レイアウト変更 START
//				tex届け先カナ.Focus();
				tex届け先コード.Focus();
// MOD 2006.12.11 東都）小童谷 レイアウト変更 END
			}
		}

		private void btn確定_Click(object sender, System.EventArgs e)
		{
			sTname = axGT届け先.get_CelText(axGT届け先.CaretRow,1);
			sTcode = axGT届け先.get_CelText(axGT届け先.CaretRow,3);
			if(sTcode != "")
				this.Close();
		}

		private void btn複写_Click(object sender, System.EventArgs e)
		{
			s複写 = "T";
			sTcode = axGT届け先.get_CelText(axGT届け先.CaretRow,3);
			if(sTcode != "")
				this.Close();

		}

		private void axGT届け先_KeyDownEvent(object sender, AxGTABLE32V2Lib._DGTable32Events_KeyDownEvent e)
		{
			if (e.keyCode == 13)
			{
				btn確定_Click(sender, null);
			}
			if (e.keyCode == 9)
			{
				this.SelectNextControl(axGT届け先, true, true, true, true);
			}
		}

// MOD 2007.03.12 FJCS）桑田 エンターキー押下による検索開始タイミングの変更 START
//		private void tex届け先コード_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
//		{
//			if (e.KeyCode == Keys.Enter)
//			{
//				btn検索_Click(sender, e);
//			}
//		}
		private void tex届け先名前_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btn検索_Click(sender, e);
			}
		}
// MOD 2007.03.12 FJCS）桑田 エンターキー押下による検索開始タイミングの変更 END

		private void btn前頁_Click(object sender, System.EventArgs e)
		{
			i現在頁数--;
			頁情報設定();
// ADD 2005.05.10 東都）小童谷 一行目選択 START
			axGT届け先.CaretRow = 1;
// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 START
			axGT届け先.CaretCol = 1;
// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 END
			axGT届け先_CurPlaceChanged(null,null);
// ADD 2005.05.10 東都）小童谷 一行目選択 END
		}

		private void btn次頁_Click(object sender, System.EventArgs e)
		{
			i現在頁数++;
			頁情報設定();
// ADD 2005.05.10 東都）小童谷 一行目選択 START
			axGT届け先.CaretRow = 1;
// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 START
			axGT届け先.CaretCol = 1;
// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 END
			axGT届け先_CurPlaceChanged(null,null);
// ADD 2005.05.10 東都）小童谷 一行目選択 END
		}

		private void 頁情報設定()
		{
			axGT届け先.Clear();
// ADD 2006.12.14 東都）小童谷 明細の余白を除去 START
			axGT届け先.Rows = 16;
// ADD 2006.12.14 東都）小童谷 明細の余白を除去 END

// MOD 2005.05.10 東都）小童谷 一行目空白 START
//			i開始数 = (i現在頁数 - 1) * axGT届け先.Rows + 1;
// MOD 2006.12.14 東都）小童谷 明細の余白を除去 START
//			i開始数 = (i現在頁数 - 1) * (axGT届け先.Rows - 1) + 1;
			i開始数 = (i現在頁数 - 1) * (i頁最大行数 - 1) + 1;
// MOD 2006.12.14 東都）小童谷 明細の余白を除去 END
//			i終了数 = i現在頁数 * axGT届け先.Rows;
// MOD 2006.12.14 東都）小童谷 明細の余白を除去 START
//			i終了数 = i現在頁数 * (axGT届け先.Rows - 1);
			i終了数 = i現在頁数 * (i頁最大行数 - 1);
// MOD 2006.12.14 東都）小童谷 明細の余白を除去 END

// ADD 2009.01.29 東都）高木 一覧に名前２、住所２、住所３を追加 START
			if(cb名前住所詳細表示.Checked){
				axGT届け先.set_CelHeight(1, 0, 3.0);
			}else{
				axGT届け先.set_CelHeight(0, 0, 1.5);
			}
// ADD 2009.01.29 東都）高木 一覧に名前２、住所２、住所３を追加 END
//			short s表示数 = (short)1;
			short s表示数 = (short)2;
// MOD 2005.05.10 東都）小童谷 一行目空白 END
			for(short sCnt = (short)i開始数; sCnt < s届け先一覧.Length && sCnt <= i終了数 ; sCnt++)
			{
// ADD 2006.12.14 東都）小童谷 明細の余白を除去 START
				if(s表示数 > 16)
					axGT届け先.Rows++;
// ADD 2006.12.14 東都）小童谷 明細の余白を除去 END
// ADD 2009.01.29 東都）高木 一覧に名前２、住所２、住所３を追加 START
				if(cb名前住所詳細表示.Checked){
					axGT届け先.set_CelHeight(s表示数, 0, 3.0);
					axGT届け先.set_CelAlignVert(s表示数, 1, 3);
					axGT届け先.set_CelAlignVert(s表示数, 2, 3);
					s届け先一覧[sCnt] = s届け先一覧[sCnt].Replace("\\r\\n","\r\n");
				}
// ADD 2009.01.29 東都）高木 一覧に名前２、住所２、住所３を追加 END

				axGT届け先.set_RowsText(s表示数, s届け先一覧[sCnt]);
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
			axGT届け先.Focus();
		}

		private void お届け先検索_Activated(object sender, System.EventArgs e)
		{
			if(tex届け先コード.Text.Trim().Length != 0 && iアクティブＦＧ == 0)
				btn検索_Click(sender,e);
		}

// ADD 2005.05.24 東都）小童谷 フォーカス移動 START
		private void お届け先検索_Closed(object sender, System.EventArgs e)
		{
// ADD 2005.07.08 東都）小童谷 複写ボタンを消す START
			btn複写.Visible = false;
// ADD 2005.07.08 東都）小童谷 複写ボタンを消す END
			tex届け先カナ.Text   = " ";
//			tex届け先コード.Text = "";
			texメッセージ.Text = "";
			axGT届け先.Clear();
			axGT届け先.CaretRow  = 1;
// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 START
			axGT届け先.CaretCol  = 1;
// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 END
			axGT届け先_CurPlaceChanged(null,null);
// MOD 2006.12.11 東都）小童谷 レイアウト変更 START
//			tex届け先カナ.Focus();
			tex届け先コード.Focus();
// MOD 2006.12.11 東都）小童谷 レイアウト変更 END
// ADD 2006.07.04 東都）山本 削除＆一覧印刷＆ＣＳＶ出力ボタン消去 START
			btnCSV出力.Visible = false;
			btn一覧印刷.Visible = false;
			btn削除.Visible = false;
// ADD 2006.07.04 東都）山本 削除＆一覧印刷＆ＣＳＶ出力ボタン消去 END
// ADD 2007.03.12 FJCS）桑田 項目クリア START
			tex電話番号.Text = "";
			tex電話番号2.Text = "";
			tex電話番号3.Text = "";
			tex届け先名前.Text = "";
// ADD 2007.03.12 FJCS）桑田 項目クリア END
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 START
			gsアドレス帳_表示順１      = cb階層リスト１.Text.TrimEnd();
			gsアドレス帳_表示順１_方向 = cbソート方向１.Text.TrimEnd();
			gsアドレス帳_表示順２      = cb階層リスト２.Text.TrimEnd();
			gsアドレス帳_表示順２_方向 = cbソート方向２.Text.TrimEnd();
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 END
		}
// ADD 2005.05.24 東都）小童谷 フォーカス移動 END

// ADD 2006.07.04 東都）山本 ソート機能追加 START
		private void cb階層１選択_select(object sender, System.EventArgs e)
		{
			if(cb階層リスト１.SelectedIndex != 0)
				cbソート方向１.Visible = true;
			else
				cbソート方向１.Visible = false;
		}

		private void cb階層２選択_select(object sender, System.EventArgs e)
		{
			if(cb階層リスト２.SelectedIndex != 0)
				cbソート方向２.Visible = true;
			else
				cbソート方向２.Visible = false;
		}
// ADD 2006.07.04 東都）山本 ソート機能追加 END

// ADD 2006.07.04 東都）山本 削除＆一覧印刷＆ＣＳＶ出力機能追加 START
		public void VisibleCSV出力()
		{
			btnCSV出力.Visible = true;
		}
		public void Visible一覧印刷()
		{
			btn一覧印刷.Visible = true;
		}
		public void Visible削除()
		{
			btn削除.Visible = true;
		}

		private void btn削除_Click(object sender, System.EventArgs e)
		{
// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 START
			texメッセージ.Text = "";
// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 END

// MOD 2010.06.03 東都）高木 複数件削除機能の高速化 START
//			string tex届け先ＣＤ;
			string[] tex届け先ＣＤ = {};
// MOD 2010.06.03 東都）高木 複数件削除機能の高速化 END
			DialogResult result;
//		    string sIUFlg;

			result = MessageBox.Show("指定されたデータを削除します。よろしいですか？","削除",MessageBoxButtons.YesNo);
			if(result == DialogResult.Yes)
			{
// MOD 2010.06.03 東都）高木 複数件削除機能の高速化 START
//				for( short CelCnt=axGT届け先.SelStartRow;CelCnt <= axGT届け先.SelEndRow;CelCnt++)
//				{
//					tex届け先ＣＤ = axGT届け先.get_CelText(CelCnt,3).Trim();
//					if(tex届け先ＣＤ.Length == 0)
//						continue;
//					// カーソルを砂時計にする
//					Cursor = System.Windows.Forms.Cursors.AppStarting;
//					String[] sList = {""};
//					try
//					{
//						if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
//						sList = sv_otodoke.Get_Stodokesaki(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,tex届け先ＣＤ);
//						sIUFlg    = sList[15];
//
//						Cursor = System.Windows.Forms.Cursors.Default;
//
//						String[] sDList;
//						string[] sData = new string[5];
//
//						if(sIUFlg == "I")
//						{
//							MessageBox.Show("コード(" + tex届け先ＣＤ + ")のデータは存在しません","削除",MessageBoxButtons.OK);
//							texメッセージ.Text = "";
//							btn検索_Click(sender,e);
//							return;
//						}
//						else
//						{
//							texメッセージ.Text = "削除中．．．";
//							sData[0] = gs会員ＣＤ;
//							sData[1] = gs部門ＣＤ;
//							sData[2] = tex届け先ＣＤ;
//							sData[3] = "お届け先";
//							sData[4] = gs利用者ＣＤ;
//
//							Cursor = System.Windows.Forms.Cursors.AppStarting;
//
//							if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
//							sDList = sv_otodoke.Del_todokesaki(gsaユーザ,sData);
//							// [正常終了]時、画面をクリアする
//							if(sDList[0].Length != 4)
//							{
//								ビープ音();
//								texメッセージ.Text = sDList[0];
//								btn検索_Click(sender,e);
//								return;
//							}
//						}
//						Cursor = System.Windows.Forms.Cursors.Default;
//					}
//					catch (System.Net.WebException)
//					{
//						sList[0] = gs通信エラー;
//						Cursor = System.Windows.Forms.Cursors.Default;
//						texメッセージ.Text = sList[0];
//						ビープ音();
//					}
//					catch (Exception ex)
//					{
//						sList[0] = "通信エラー：" + ex.Message;
//						Cursor = System.Windows.Forms.Cursors.Default;
//						texメッセージ.Text = sList[0];
//						ビープ音();
//					}
//				}
				int iCnt  = 0;
				int iPosS = 0;
				int iPosE = 0;
				if(axGT届け先.SelEndRow >= axGT届け先.SelStartRow){
					iPosS = (int)axGT届け先.SelStartRow;
					iPosE = (int)axGT届け先.SelEndRow  ;
				}else{
					iPosS = (int)axGT届け先.SelEndRow  ;
					iPosE = (int)axGT届け先.SelStartRow;
				}
				iCnt = iPosE - iPosS + 1;
				tex届け先ＣＤ = new string[iCnt];
				int iPos = 0;
				for(int iLine = iPosS; iLine <= iPosE; iLine++){
					tex届け先ＣＤ[iPos++] = axGT届け先.get_CelText((short)iLine,3).Trim();
				}
				// カーソルを砂時計にする
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				string[] sList = {""};
				string[] sData = new string[5];
				try{
					texメッセージ.Text = "削除中．．．";
					sData[0] = gs会員ＣＤ;
					sData[1] = gs部門ＣＤ;
					sData[2] = "";
					sData[3] = "お届け先";
					sData[4] = gs利用者ＣＤ;

					if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
					sList = sv_otodoke.Del_todokesakis(gsaユーザ, sData, tex届け先ＣＤ);
					// [正常終了]時、画面をクリアする
					if(sList[0].Length != 4){
						ビープ音();
						texメッセージ.Text = sList[0];
						btn検索_Click(sender,e);
						return;
					}
					Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2010.09.22 東都）高木 削除：[いいえ]選択時の障害修正 START
					texメッセージ.Text = "";
					btn検索_Click(sender,e);
// MOD 2010.09.22 東都）高木 削除：[いいえ]選択時の障害修正 END
				}catch (System.Net.WebException){
					sList[0] = gs通信エラー;
					Cursor = System.Windows.Forms.Cursors.Default;
					texメッセージ.Text = sList[0];
					ビープ音();
				}catch (Exception ex){
					sList[0] = "通信エラー：" + ex.Message;
					Cursor = System.Windows.Forms.Cursors.Default;
					texメッセージ.Text = sList[0];
					ビープ音();
				}
// MOD 2010.06.03 東都）高木 複数件削除機能の高速化 END
			}
// MOD 2010.09.22 東都）高木 削除：[いいえ]選択時の障害修正 START
//			texメッセージ.Text = "";
//			btn検索_Click(sender,e);
// MOD 2010.09.22 東都）高木 削除：[いいえ]選択時の障害修正 END
			return;
		}

		private void btn一覧印刷_Click(object sender, System.EventArgs e)
		{
// MOD 2010.02.03 東都）高木 検索条件に更新日を追加 START
			tex届け先カナ.Text   = tex届け先カナ.Text.TrimEnd();
			tex届け先コード.Text = tex届け先コード.Text.TrimEnd();
			tex電話番号.Text     = tex電話番号.Text.TrimEnd();
			tex電話番号2.Text    = tex電話番号2.Text.TrimEnd();
			tex電話番号3.Text    = tex電話番号3.Text.TrimEnd();
			tex届け先名前.Text   = tex届け先名前.Text.TrimEnd();
// MOD 2010.02.03 東都）高木 検索条件に更新日を追加 END

			texメッセージ.Text = "お届け先一覧印刷中．．．";
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				if(sv_print == null) sv_print = new is2print.Service1();
				string[] sKey = new string[3];
				sKey[0] = gs会員ＣＤ;
				sKey[1] = gs部門ＣＤ;

				string[] sRet = new string[1];
// MOD 2010.02.03 東都）高木 検索条件に更新日を追加 START
//				IEnumerator iEnum = sv_print.Get_ConsigneePrintData2(gsaユーザ,sKey,
//// ADD 2007.01.30 FJCS）桑田 検索条件に名前追加 START
////												tex届け先カナ.Text, tex届け先コード.Text,tex電話番号.Text,tex電話番号2.Text,tex電話番号3.Text,
//												tex届け先カナ.Text, tex届け先コード.Text,tex電話番号.Text,tex電話番号2.Text,tex電話番号3.Text,tex届け先名前.Text,
//// ADD 2007.01.30 FJCS）桑田 検索条件に名前追加 END
//												cb階層リスト１.SelectedIndex,cbソート方向１.SelectedIndex,
//												cb階層リスト２.SelectedIndex,cbソート方向２.SelectedIndex).GetEnumerator();
				IEnumerator iEnum
				 = sv_print.Get_ConsigneePrintData3(
						gsaユーザ,sKey
						, tex届け先カナ.Text, tex届け先コード.Text
						, tex電話番号.Text, tex電話番号2.Text, tex電話番号3.Text
						, tex届け先名前.Text
						, cb階層リスト１.SelectedIndex, cbソート方向１.SelectedIndex
						, cb階層リスト２.SelectedIndex, cbソート方向２.SelectedIndex
						, (cb更新日.Checked) ? dt更新日.Value.ToString("yyyyMMdd") : ""
					).GetEnumerator();
// MOD 2010.02.03 東都）高木 検索条件に更新日を追加 END
				iEnum.MoveNext();
				sRet = (string[])iEnum.Current;
				if (sRet[0].Equals("正常終了"))
				{
					お届先データ ds = new お届先データ();

					int iCnt = 1;
					//データセットに値をセット
					while (iEnum.MoveNext())
					{
						string[] sList = new string[13];
						sList = (string[])iEnum.Current;
					
						お届先データ.tableお届先Row tr = (お届先データ.tableお届先Row)ds.tableお届先.NewRow();
						tr.BeginEdit();
						tr.番号 = iCnt++;
						tr.コード   = sList[0].Trim();
						tr.カナ略称 = sList[1].Trim();
						if(sList[2].Trim().Length == 0)
							tr.電話番号 = sList[3] + "-" + sList[4];
						else
							tr.電話番号 = "(" + sList[2] + ")" + sList[3] + "-" + sList[4];
						tr.郵便番号 = sList[5] + "-" + sList[6];
						tr.住所     = sList[7].Trim() + sList[8].Trim() + sList[9].Trim();
						tr.名前     = sList[10].Trim() + "  " + sList[11].Trim();
						tr.特殊計   = sList[12].Trim();
//保留 MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
///						if(gsオプション[18].Equals("1")){
							tr.カナ略称 = sList[1].TrimEnd();
							tr.住所     = sList[7].TrimEnd() + sList[8].TrimEnd() + sList[9].TrimEnd();
							tr.名前     = sList[10].TrimEnd() + "  " + sList[11].TrimEnd();
///						}
//保留 MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
						tr.EndEdit();

						ds.tableお届先.Rows.Add(tr);					
					}
					
					お届先帳票 cr = new お届先帳票();
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
					texメッセージ.Text = sRet[0];
					ビープ音();
				}
			}
			catch (System.Net.WebException)
			{
				texメッセージ.Text = gs通信エラー;
				ビープ音();
			}
			catch (Exception ex)
			{
				texメッセージ.Text = ex.Message;
				ビープ音();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		
		}

		private void btnCSV出力_Click(object sender, System.EventArgs e)
		{
// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 START
			texメッセージ.Text = "";
// MOD 2010.02.02 東都）高木 一覧に登録日時、更新日時、出荷使用日を追加 END

// MOD 2010.02.03 東都）高木 検索条件に更新日を追加 START
			tex届け先カナ.Text   = tex届け先カナ.Text.TrimEnd();
			tex届け先コード.Text = tex届け先コード.Text.TrimEnd();
			tex電話番号.Text     = tex電話番号.Text.TrimEnd();
			tex電話番号2.Text    = tex電話番号2.Text.TrimEnd();
			tex電話番号3.Text    = tex電話番号3.Text.TrimEnd();
			tex届け先名前.Text   = tex届け先名前.Text.TrimEnd();
// MOD 2010.02.03 東都）高木 検索条件に更新日を追加 END

			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				String[] sList;
				if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();

// MOD 2010.02.03 東都）高木 検索条件に更新日を追加 START
//				sList = sv_otodoke.Get_csvwrite2(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,
//// ADD 2007.01.30 FJCS）桑田 検索条件に名前追加 START
////												tex届け先カナ.Text, tex届け先コード.Text,tex電話番号.Text,tex電話番号2.Text,tex電話番号3.Text,
//												tex届け先カナ.Text, tex届け先コード.Text,tex電話番号.Text,tex電話番号2.Text,tex電話番号3.Text,tex届け先名前.Text,
//// ADD 2007.01.30 FJCS）桑田 検索条件に名前追加 END
//												cb階層リスト１.SelectedIndex,cbソート方向１.SelectedIndex,
//												cb階層リスト２.SelectedIndex,cbソート方向２.SelectedIndex);
				sList
				 = sv_otodoke.Get_csvwrite3(
			 			gsaユーザ, gs会員ＣＤ, gs部門ＣＤ
						, tex届け先カナ.Text, tex届け先コード.Text
						, tex電話番号.Text, tex電話番号2.Text, tex電話番号3.Text
						, tex届け先名前.Text
						, cb階層リスト１.SelectedIndex, cbソート方向１.SelectedIndex
						, cb階層リスト２.SelectedIndex, cbソート方向２.SelectedIndex
						, (cb更新日.Checked) ? dt更新日.Value.ToString("yyyyMMdd") : ""
					);
// MOD 2010.02.03 東都）高木 検索条件に更新日を追加 END
												// ＤＢ（ＳＭ０２荷受人ファイル）の読み込みを行なう。
				this.Cursor = System.Windows.Forms.Cursors.Default;

				if(sList[0].Length == 4)		// 正常に読み込みが完了？
				{
					sList[0] = "\"荷受人コード\",\"電話番号\",\"ＦＡＸ番号\","
						+ "\"住所１\",\"住所２\",\"住所３\","
						+ "\"名前１\",\"名前２\",\"予約\",\"郵便番号\","
						+ "\"カナ略称\",\"一斉出荷区分\",\"特殊計\",\"着店コード\"";
												// 見出し部の編集を行なう

					// デフォルトのフォルダをデスクトップフォルダにする
					saveFileDialog1.InitialDirectory
						= Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
					saveFileDialog1.Filter = "ＣＳＶファイル (*.csv)|*.csv";
					byte[] bSJIS;
					if(saveFileDialog1.ShowDialog(this) == DialogResult.OK)
					{							// ファイル保存コモンダイアログの表示を行なう
						System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
						for(int iCnt = 0; iCnt < sList.Length; iCnt++)
						{
							bSJIS = toSJIS(sList[iCnt]);
							fs.Write(bSJIS, 0 , bSJIS.Length);
						}
						fs.Close();
// MOD 2010.09.22 東都）高木 ＣＳＶ出力：[キャンセル]選択時の障害修正 START
//						texメッセージ.Text = "";
// MOD 2010.09.22 東都）高木 ＣＳＶ出力：[キャンセル]選択時の障害修正 END
					}
// MOD 2010.09.22 東都）高木 ＣＳＶ出力：[キャンセル]選択時の障害修正 START
						texメッセージ.Text = "";
// MOD 2010.09.22 東都）高木 ＣＳＶ出力：[キャンセル]選択時の障害修正 END
				}
				else
				{
					ビープ音();
					texメッセージ.Text = sList[0];
				}
			}
			catch (System.Net.WebException)
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
				texメッセージ.Text = gs通信エラー;
				ビープ音();
			}
			catch(Exception ex)
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
				texメッセージ.Text = ex.Message;
			}
			tex届け先コード.Focus();		
		}

		private void axGT届け先_CelClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelClickEvent e)
		{
			axGT届け先_CurPlaceChanged(null,null);
			if(axGT届け先.SelStartRow != axGT届け先.SelEndRow)
			{
				if(nSrow > nErow)
				{
					nWork = nSrow;
					nSrow = nErow;
					nErow = nWork;
				}
				for(short nCnt = nSrow; nCnt <= nErow; nCnt++)
				{
					axGT届け先.set_CelForeColor(nCnt,0,0x98FB98);
					axGT届け先.set_CelBackColor(nCnt,0,0x006000);
				}
				for(int nCnt = int.Parse(nSrow.ToString()) - 1; nCnt >= 1; nCnt--)
				{
					axGT届け先.set_CelForeColor(short.Parse(nCnt.ToString()),0,0);
					axGT届け先.set_CelBackColor(short.Parse(nCnt.ToString()),0,0xFFFFFF);
				}
				for(int nCnt = int.Parse(nErow.ToString()) + 1; nCnt <= axGT届け先.Rows; nCnt++)
				{
					axGT届け先.set_CelForeColor(short.Parse(nCnt.ToString()),0,0);
					axGT届け先.set_CelBackColor(short.Parse(nCnt.ToString()),0,0xFFFFFF);
				}
			}
		}
// ADD 2006.07.04 東都）山本 削除＆一覧印刷＆ＣＳＶ出力機能追加 END
// MOD 2010.02.03 東都）高木 検索条件に更新日を追加 START
		private void cb更新日_CheckedChanged(object sender, System.EventArgs e)
		{
			dt更新日.Enabled = cb更新日.Checked;
		}
// MOD 2010.02.03 東都）高木 検索条件に更新日を追加 END
	}
}
