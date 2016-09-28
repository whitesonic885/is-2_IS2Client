using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [ご依頼主検索]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// MOD 2008.10.01 東都）高木 一覧に請求先を表示 
	//--------------------------------------------------------------------------
	// MOD 2009.11.30 東都）高木 検索条件に名前、請求先を追加 
	//--------------------------------------------------------------------------
	// MOD 2010.02.03 東都）高木 ソート条件の保持機能を追加 
	// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 
	// MOD 2010.09.02 東都）高木 選択時のずれの対応 
	// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 東都）高木 複数件削除機能の障害対応 
	// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない 
	// MOD 2011.01.25 東都）高木 「ロードに失敗」対応 
	//--------------------------------------------------------------------------
	public class ご依頼主検索 : 共通フォーム
	{
// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 START
////		public  short OldRow = 0;
		private short nSrow = 0;
		private short nErow = 0;
		private short nWork = 0;
// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 END
		private short nOldRow = 0;
		public string sIcode;
		public string sIname;
		public string s複写;
		private string[] s依頼主一覧;
		private int      i現在頁数;
		private int      i最大頁数;
		private int      i開始数;
		private int      i終了数;
		private int      iアクティブＦＧ = 0;
// MOD 2009.11.30 東都）高木 検索条件に名前、請求先を追加 START
		private string s請求先ＣＤ = "";
		private string s部課ＣＤ   = "";
// MOD 2009.11.30 東都）高木 検索条件に名前、請求先を追加 END
// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 START
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 END

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Button btn複写;
		private 共通テキストボックス tex依頼主カナ;
		private System.Windows.Forms.Label lab依頼主カナ;
		private System.Windows.Forms.Label lab依頼主コード;
		private 共通テキストボックス tex依頼主コード;
		private System.Windows.Forms.Label lab依頼主タイトル;
		private System.Windows.Forms.Button btn確定;
		private System.Windows.Forms.Button btn検索;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.Button btn閉じる;
		private AxGTABLE32V2Lib.AxGTable32 axGT依頼主;
		private System.Windows.Forms.Label lab頁番号;
		private System.Windows.Forms.Button btn次頁;
		private System.Windows.Forms.Button btn前頁;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lab届け先名前;
		private System.Windows.Forms.ComboBox cmb請求先;
		private System.Windows.Forms.Label lab請求先;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbソート方向２;
		private System.Windows.Forms.ComboBox cb階層リスト２;
		private System.Windows.Forms.ComboBox cbソート方向１;
		private System.Windows.Forms.ComboBox cb階層リスト１;
		private IS2Client.共通テキストボックス tex依頼主名前;
		private IS2Client.共通テキストボックス tex請求先コード;
		private System.Windows.Forms.GroupBox gp表示順;
		private System.Windows.Forms.Button btn削除;
		private System.Windows.Forms.Button btn一覧印刷;
		private System.Windows.Forms.Button btnCSV出力;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ご依頼主検索()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
			ＤＰＩ表示サイズ変換();
//			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
				this.axGT依頼主.Size = new System.Drawing.Size(758, 307);
//			}
// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 END
// MOD 2010.02.03 東都）高木 ソート条件の保持機能を追加 START
			cb階層リスト１.SelectedIndex = 4;
			cbソート方向１.SelectedIndex = 0;
			cb階層リスト２.SelectedIndex = 2;
			cbソート方向２.SelectedIndex = 0;
// MOD 2010.02.03 東都）高木 ソート条件の保持機能を追加 END
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 START
			if(gsご依頼主検索_表示順１ != null){
				cb階層リスト１.Text = gsご依頼主検索_表示順１;
			}
			if(gsご依頼主検索_表示順１_方向 != null){
				cbソート方向１.Text = gsご依頼主検索_表示順１_方向;
			}
			if(gsご依頼主検索_表示順２ != null){
				cb階層リスト２.Text = gsご依頼主検索_表示順２;
			}
			if(gsご依頼主検索_表示順２_方向 != null){
				cbソート方向２.Text = gsご依頼主検索_表示順２_方向;
			}
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 END
// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 START
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 END
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ご依頼主検索));
			this.panel1 = new System.Windows.Forms.Panel();
			this.lab頁番号 = new System.Windows.Forms.Label();
			this.btn次頁 = new System.Windows.Forms.Button();
			this.btn前頁 = new System.Windows.Forms.Button();
			this.axGT依頼主 = new AxGTABLE32V2Lib.AxGTable32();
			this.btn確定 = new System.Windows.Forms.Button();
			this.panel5 = new System.Windows.Forms.Panel();
			this.tex依頼主名前 = new IS2Client.共通テキストボックス();
			this.tex請求先コード = new IS2Client.共通テキストボックス();
			this.lab請求先 = new System.Windows.Forms.Label();
			this.cmb請求先 = new System.Windows.Forms.ComboBox();
			this.lab届け先名前 = new System.Windows.Forms.Label();
			this.tex依頼主カナ = new IS2Client.共通テキストボックス();
			this.lab依頼主カナ = new System.Windows.Forms.Label();
			this.lab依頼主コード = new System.Windows.Forms.Label();
			this.tex依頼主コード = new IS2Client.共通テキストボックス();
			this.btn検索 = new System.Windows.Forms.Button();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab依頼主タイトル = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn複写 = new System.Windows.Forms.Button();
			this.texメッセージ = new System.Windows.Forms.TextBox();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.panel6 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.gp表示順 = new System.Windows.Forms.GroupBox();
			this.cbソート方向２ = new System.Windows.Forms.ComboBox();
			this.cb階層リスト２ = new System.Windows.Forms.ComboBox();
			this.cbソート方向１ = new System.Windows.Forms.ComboBox();
			this.cb階層リスト１ = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btn削除 = new System.Windows.Forms.Button();
			this.btn一覧印刷 = new System.Windows.Forms.Button();
			this.btnCSV出力 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axGT依頼主)).BeginInit();
			this.panel5.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.gp表示順.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Honeydew;
			this.panel1.Controls.Add(this.lab頁番号);
			this.panel1.Controls.Add(this.btn次頁);
			this.panel1.Controls.Add(this.btn前頁);
			this.panel1.Controls.Add(this.axGT依頼主);
			this.panel1.Controls.Add(this.btn確定);
			this.panel1.Location = new System.Drawing.Point(1, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(773, 350);
			this.panel1.TabIndex = 1;
			// 
			// lab頁番号
			// 
			this.lab頁番号.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab頁番号.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab頁番号.Location = new System.Drawing.Point(578, 326);
			this.lab頁番号.Name = "lab頁番号";
			this.lab頁番号.Size = new System.Drawing.Size(48, 14);
			this.lab頁番号.TabIndex = 70;
			this.lab頁番号.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn次頁
			// 
			this.btn次頁.BackColor = System.Drawing.Color.SteelBlue;
			this.btn次頁.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn次頁.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn次頁.ForeColor = System.Drawing.Color.White;
			this.btn次頁.Location = new System.Drawing.Point(626, 322);
			this.btn次頁.Name = "btn次頁";
			this.btn次頁.Size = new System.Drawing.Size(48, 22);
			this.btn次頁.TabIndex = 69;
			this.btn次頁.Text = "次頁";
			this.btn次頁.Click += new System.EventHandler(this.btn次頁_Click);
			// 
			// btn前頁
			// 
			this.btn前頁.BackColor = System.Drawing.Color.SteelBlue;
			this.btn前頁.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn前頁.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn前頁.ForeColor = System.Drawing.Color.White;
			this.btn前頁.Location = new System.Drawing.Point(530, 322);
			this.btn前頁.Name = "btn前頁";
			this.btn前頁.Size = new System.Drawing.Size(48, 22);
			this.btn前頁.TabIndex = 68;
			this.btn前頁.Text = "前頁";
			this.btn前頁.Click += new System.EventHandler(this.btn前頁_Click);
			// 
			// axGT依頼主
			// 
			this.axGT依頼主.ContainingControl = this;
			this.axGT依頼主.DataSource = null;
			this.axGT依頼主.Location = new System.Drawing.Point(8, 8);
			this.axGT依頼主.Name = "axGT依頼主";
			this.axGT依頼主.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT依頼主.OcxState")));
			this.axGT依頼主.Size = new System.Drawing.Size(758, 307);
			this.axGT依頼主.TabIndex = 2;
			this.axGT依頼主.KeyDownEvent += new AxGTABLE32V2Lib._DGTable32Events_KeyDownEventHandler(this.axGT依頼主_KeyDownEvent);
			this.axGT依頼主.CelDblClick += new AxGTABLE32V2Lib._DGTable32Events_CelDblClickEventHandler(this.axGT依頼主_CelDblClick);
			this.axGT依頼主.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT依頼主_CurPlaceChanged);
			// 
			// btn確定
			// 
			this.btn確定.BackColor = System.Drawing.Color.SteelBlue;
			this.btn確定.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn確定.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn確定.ForeColor = System.Drawing.Color.White;
			this.btn確定.Location = new System.Drawing.Point(692, 322);
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
			this.panel5.Controls.Add(this.tex依頼主名前);
			this.panel5.Controls.Add(this.tex請求先コード);
			this.panel5.Controls.Add(this.lab請求先);
			this.panel5.Controls.Add(this.cmb請求先);
			this.panel5.Controls.Add(this.lab届け先名前);
			this.panel5.Controls.Add(this.tex依頼主カナ);
			this.panel5.Controls.Add(this.lab依頼主カナ);
			this.panel5.Controls.Add(this.lab依頼主コード);
			this.panel5.Controls.Add(this.tex依頼主コード);
			this.panel5.Controls.Add(this.btn検索);
			this.panel5.Location = new System.Drawing.Point(1, 6);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(459, 90);
			this.panel5.TabIndex = 0;
			// 
			// tex依頼主名前
			// 
			this.tex依頼主名前.BackColor = System.Drawing.SystemColors.Window;
			this.tex依頼主名前.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主名前.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex依頼主名前.Location = new System.Drawing.Point(278, 4);
			this.tex依頼主名前.MaxLength = 10;
			this.tex依頼主名前.Name = "tex依頼主名前";
			this.tex依頼主名前.Size = new System.Drawing.Size(174, 23);
			this.tex依頼主名前.TabIndex = 1;
			this.tex依頼主名前.Text = "";
			// 
			// tex請求先コード
			// 
			this.tex請求先コード.BackColor = System.Drawing.Color.Honeydew;
			this.tex請求先コード.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex請求先コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex請求先コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex請求先コード.Location = new System.Drawing.Point(232, 64);
			this.tex請求先コード.MaxLength = 12;
			this.tex請求先コード.Name = "tex請求先コード";
			this.tex請求先コード.Size = new System.Drawing.Size(154, 16);
			this.tex請求先コード.TabIndex = 61;
			this.tex請求先コード.TabStop = false;
			this.tex請求先コード.Text = "";
			// 
			// lab請求先
			// 
			this.lab請求先.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab請求先.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab請求先.Location = new System.Drawing.Point(8, 64);
			this.lab請求先.Name = "lab請求先";
			this.lab請求先.Size = new System.Drawing.Size(56, 16);
			this.lab請求先.TabIndex = 60;
			this.lab請求先.Text = "請求先";
			// 
			// cmb請求先
			// 
			this.cmb請求先.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb請求先.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cmb請求先.Location = new System.Drawing.Point(74, 62);
			this.cmb請求先.Name = "cmb請求先";
			this.cmb請求先.Size = new System.Drawing.Size(154, 20);
			this.cmb請求先.TabIndex = 3;
			this.cmb請求先.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb請求先_KeyDown);
			this.cmb請求先.SelectedIndexChanged += new System.EventHandler(this.cmb請求先_SelectedIndexChanged);
			// 
			// lab届け先名前
			// 
			this.lab届け先名前.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab届け先名前.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab届け先名前.Location = new System.Drawing.Point(234, 8);
			this.lab届け先名前.Name = "lab届け先名前";
			this.lab届け先名前.Size = new System.Drawing.Size(40, 16);
			this.lab届け先名前.TabIndex = 58;
			this.lab届け先名前.Text = "名前";
			// 
			// tex依頼主カナ
			// 
			this.tex依頼主カナ.BackColor = System.Drawing.SystemColors.Window;
			this.tex依頼主カナ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主カナ.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
			this.tex依頼主カナ.Location = new System.Drawing.Point(74, 4);
			this.tex依頼主カナ.MaxLength = 10;
			this.tex依頼主カナ.Name = "tex依頼主カナ";
			this.tex依頼主カナ.Size = new System.Drawing.Size(126, 23);
			this.tex依頼主カナ.TabIndex = 0;
			this.tex依頼主カナ.Text = "";
			// 
			// lab依頼主カナ
			// 
			this.lab依頼主カナ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab依頼主カナ.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab依頼主カナ.Location = new System.Drawing.Point(8, 8);
			this.lab依頼主カナ.Name = "lab依頼主カナ";
			this.lab依頼主カナ.Size = new System.Drawing.Size(64, 16);
			this.lab依頼主カナ.TabIndex = 46;
			this.lab依頼主カナ.Text = "カナ略称";
			// 
			// lab依頼主コード
			// 
			this.lab依頼主コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab依頼主コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab依頼主コード.Location = new System.Drawing.Point(8, 36);
			this.lab依頼主コード.Name = "lab依頼主コード";
			this.lab依頼主コード.Size = new System.Drawing.Size(44, 16);
			this.lab依頼主コード.TabIndex = 6;
			this.lab依頼主コード.Text = "コード";
			// 
			// tex依頼主コード
			// 
			this.tex依頼主コード.BackColor = System.Drawing.SystemColors.Window;
			this.tex依頼主コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex依頼主コード.Location = new System.Drawing.Point(74, 32);
			this.tex依頼主コード.MaxLength = 12;
			this.tex依頼主コード.Name = "tex依頼主コード";
			this.tex依頼主コード.Size = new System.Drawing.Size(174, 23);
			this.tex依頼主コード.TabIndex = 2;
			this.tex依頼主コード.Text = "";
			// 
			// btn検索
			// 
			this.btn検索.BackColor = System.Drawing.Color.SteelBlue;
			this.btn検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn検索.ForeColor = System.Drawing.Color.White;
			this.btn検索.Location = new System.Drawing.Point(388, 62);
			this.btn検索.Name = "btn検索";
			this.btn検索.Size = new System.Drawing.Size(64, 22);
			this.btn検索.TabIndex = 4;
			this.btn検索.TabStop = false;
			this.btn検索.Text = "検索";
			this.btn検索.Click += new System.EventHandler(this.btn検索_Click);
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.lab依頼主タイトル);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(794, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab依頼主タイトル
			// 
			this.lab依頼主タイトル.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab依頼主タイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab依頼主タイトル.ForeColor = System.Drawing.Color.White;
			this.lab依頼主タイトル.Location = new System.Drawing.Point(12, 2);
			this.lab依頼主タイトル.Name = "lab依頼主タイトル";
			this.lab依頼主タイトル.Size = new System.Drawing.Size(264, 24);
			this.lab依頼主タイトル.TabIndex = 0;
			this.lab依頼主タイトル.Text = "ご依頼主検索";
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
			this.panel8.TabIndex = 2;
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
			this.texメッセージ.Location = new System.Drawing.Point(416, 4);
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel5);
			this.groupBox1.Location = new System.Drawing.Point(10, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(462, 98);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel1);
			this.groupBox2.Location = new System.Drawing.Point(10, 154);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(776, 358);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// gp表示順
			// 
			this.gp表示順.Controls.Add(this.cbソート方向２);
			this.gp表示順.Controls.Add(this.cb階層リスト２);
			this.gp表示順.Controls.Add(this.cbソート方向１);
			this.gp表示順.Controls.Add(this.cb階層リスト１);
			this.gp表示順.Controls.Add(this.label4);
			this.gp表示順.Controls.Add(this.label3);
			this.gp表示順.Location = new System.Drawing.Point(490, 76);
			this.gp表示順.Name = "gp表示順";
			this.gp表示順.Size = new System.Drawing.Size(278, 78);
			this.gp表示順.TabIndex = 1;
			this.gp表示順.TabStop = false;
			// 
			// cbソート方向２
			// 
			this.cbソート方向２.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbソート方向２.Items.AddRange(new object[] {
														  "昇順",
														  "降順"});
			this.cbソート方向２.Location = new System.Drawing.Point(204, 48);
			this.cbソート方向２.Name = "cbソート方向２";
			this.cbソート方向２.Size = new System.Drawing.Size(60, 20);
			this.cbソート方向２.TabIndex = 53;
			this.cbソート方向２.Visible = false;
			// 
			// cb階層リスト２
			// 
			this.cb階層リスト２.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb階層リスト２.Items.AddRange(new object[] {
														  "",
														  "カナ略称",
														  "コード",
														  "請求先",
														  "名前",
														  "電話番号",
														  "登録日時",
														  "更新日時"});
			this.cb階層リスト２.Location = new System.Drawing.Point(104, 48);
			this.cb階層リスト２.Name = "cb階層リスト２";
			this.cb階層リスト２.Size = new System.Drawing.Size(96, 20);
			this.cb階層リスト２.TabIndex = 52;
			this.cb階層リスト２.SelectedIndexChanged += new System.EventHandler(this.cb階層リスト２_select);
			// 
			// cbソート方向１
			// 
			this.cbソート方向１.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbソート方向１.Items.AddRange(new object[] {
														  "昇順",
														  "降順"});
			this.cbソート方向１.Location = new System.Drawing.Point(204, 22);
			this.cbソート方向１.Name = "cbソート方向１";
			this.cbソート方向１.Size = new System.Drawing.Size(60, 20);
			this.cbソート方向１.TabIndex = 51;
			this.cbソート方向１.Visible = false;
			// 
			// cb階層リスト１
			// 
			this.cb階層リスト１.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb階層リスト１.Items.AddRange(new object[] {
														  "",
														  "カナ略称",
														  "コード",
														  "請求先",
														  "名前",
														  "電話番号",
														  "登録日時",
														  "更新日時"});
			this.cb階層リスト１.Location = new System.Drawing.Point(104, 22);
			this.cb階層リスト１.Name = "cb階層リスト１";
			this.cb階層リスト１.Size = new System.Drawing.Size(96, 20);
			this.cb階層リスト１.TabIndex = 50;
			this.cb階層リスト１.SelectedIndexChanged += new System.EventHandler(this.cb階層リスト１_select);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label4.ForeColor = System.Drawing.Color.LimeGreen;
			this.label4.Location = new System.Drawing.Point(18, 50);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 16);
			this.label4.TabIndex = 49;
			this.label4.Text = "表示順２";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label3.ForeColor = System.Drawing.Color.LimeGreen;
			this.label3.Location = new System.Drawing.Point(18, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 48;
			this.label3.Text = "表示順１";
			// 
			// btn削除
			// 
			this.btn削除.ForeColor = System.Drawing.Color.Blue;
			this.btn削除.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn削除.Location = new System.Drawing.Point(208, 6);
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
			this.btn一覧印刷.Location = new System.Drawing.Point(278, 6);
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
			this.btnCSV出力.Location = new System.Drawing.Point(348, 5);
			this.btnCSV出力.Name = "btnCSV出力";
			this.btnCSV出力.Size = new System.Drawing.Size(62, 48);
			this.btnCSV出力.TabIndex = 3;
			this.btnCSV出力.Text = "ＣＳＶ　　出力";
			this.btnCSV出力.Visible = false;
			this.btnCSV出力.Click += new System.EventHandler(this.btnCSV出力_Click);
			// 
			// ご依頼主検索
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 574);
			this.Controls.Add(this.gp表示順);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "ご依頼主検索";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 ご依頼主検索";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Closed += new System.EventHandler(this.ご依頼主検索_Closed);
			this.Activated += new System.EventHandler(this.ご依頼主検索_Activated);
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axGT依頼主)).EndInit();
			this.panel5.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.gp表示順.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		private void Form1_Load(object sender, System.EventArgs e)
		{
// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 START
			//複数行選択を可能にする
			axGT依頼主.CaretType = GTABLE32V2Lib.CaretTypeConstants.gktbMultiRowSelect;
// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 END
// MOD 2009.11.30 東都）高木 検索条件に名前、請求先を追加 START
			tex依頼主カナ.Text = "";
			tex依頼主名前.Text = "";
			tex依頼主コード.Text = "";
			cmb請求先.Items.Clear();
			if(gsa請求先部課名 != null)
			{
				cmb請求先.Items.Add("");
				cmb請求先.Items.AddRange(gsa請求先部課名);
			}
			cmb請求先.SelectedIndex = 0;
// MOD 2010.02.03 東都）高木 ソート条件の保持機能を追加 START
////			cb階層リスト１.SelectedIndex = 0;
////			cbソート方向１.SelectedIndex = 0;
////			cb階層リスト２.SelectedIndex = 0;
////			cbソート方向２.SelectedIndex = 0;
//			cb階層リスト１.SelectedIndex = 4;
//			cbソート方向１.SelectedIndex = 0;
//			cb階層リスト２.SelectedIndex = 2;
//			cbソート方向２.SelectedIndex = 0;
// MOD 2010.02.03 東都）高木 ソート条件の保持機能を追加 END
// MOD 2009.11.30 東都）高木 検索条件に名前、請求先を追加 END
			iアクティブＦＧ = 0;
			s複写 = "";
			tex依頼主コード.Text = sIcode;
			sIcode = "";

// MOD 2008.10.01 東都）高木 一覧に請求先を表示 START
//			axGT依頼主.Cols = 5;
			axGT依頼主.Cols = 6;
// MOD 2008.10.01 東都）高木 一覧に請求先を表示 END
			axGT依頼主.Rows = 16;
			axGT依頼主.ColSep = "|";

// MOD 2008.10.01 東都）高木 一覧に請求先を表示 START
//			axGT依頼主.set_RowsText(0, "|名前|住所|コード|電話番号|カナ略称|");
			axGT依頼主.set_RowsText(0, "|名前|住所|コード|電話番号|カナ略称|請求先|");
// MOD 2008.10.01 東都）高木 一覧に請求先を表示 END

// MOD 2008.10.01 東都）高木 一覧に請求先を表示 START
//			axGT依頼主.ColsWidth = "0|14.2|14.2|9.7|8.6|7|";
//			axGT依頼主.ColsAlignHorz = "1|0|0|0|0|0|";
			axGT依頼主.ColsWidth = "0|14.6|14.2|6.0|8.0|5.9|9.7|";
// MOD 2010.09.02 東都）高木 選択時のずれの対応 START
			カラム幅の補正(axGT依頼主);
// MOD 2010.09.02 東都）高木 選択時のずれの対応 END
			axGT依頼主.ColsAlignHorz = "1|0|0|0|0|0|0|";
// MOD 2008.10.01 東都）高木 一覧に請求先を表示 END

//			axGT依頼主.set_CelForeColor(axGT依頼主.CaretRow,0,111111);
			axGT依頼主.set_CelForeColor(axGT依頼主.CaretRow,0,0x98FB98);  //BGR
			axGT依頼主.set_CelBackColor(axGT依頼主.CaretRow,0,0x006000);
// MOD 2010.09.02 東都）高木 選択時のずれの対応 START
			axGT依頼主.CaretRow = 1;
			axGT依頼主.CaretCol = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 END

			btn前頁.Enabled = false;
			btn次頁.Enabled = false;
			lab頁番号.Text = "";			
		}

		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
			sIcode = "";
			this.Close();
		}

		public void Visible複写()
		{
			btn複写.Visible = true;
		}
// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 START
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
// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 END

		private void axGT依頼主_CelDblClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelDblClickEvent e)
		{
			sIname = axGT依頼主.get_CelText(axGT依頼主.CaretRow,1);
			sIcode = axGT依頼主.get_CelText(axGT依頼主.CaretRow,3);
			if(sIcode != "")
				this.Close();

		}

		private void axGT依頼主_CurPlaceChanged(object sender, AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEvent e)
		{
// MOD 2010.09.21 東都）高木 複数選択時の背景色変更 START
//			axGT依頼主.set_CelForeColor(nOldRow,0,0);
//			axGT依頼主.set_CelBackColor(nOldRow,0,0xFFFFFF);
////			axGT依頼主.set_CelForeColor(axGT依頼主.CaretRow,0,111111);
//			axGT依頼主.set_CelForeColor(axGT依頼主.CaretRow,0,0x98FB98);  //BGR
//			axGT依頼主.set_CelBackColor(axGT依頼主.CaretRow,0,0x006000);
//			nOldRow = axGT依頼主.CaretRow;
			axGT依頼主.set_CelForeColor(nOldRow,0,0);
			axGT依頼主.set_CelBackColor(nOldRow,0,0xFFFFFF);
////			axGT依頼主.set_CelForeColor(OldRow,0,0);
////			axGT依頼主.set_CelBackColor(OldRow,0,0xFFFFFF);
			if(axGT依頼主.SelStartRow == axGT依頼主.SelEndRow){
				if(nSrow > nErow){
					nWork = nSrow;
					nSrow = nErow;
					nErow = nWork;
				}
				for(short nCnt = nSrow; nCnt <= nErow; nCnt++){
					axGT依頼主.set_CelForeColor(nCnt,0,0);
					axGT依頼主.set_CelBackColor(nCnt,0,0xFFFFFF);
				}
			}
			axGT依頼主.set_CelForeColor(axGT依頼主.SelStartRow,0,0x98FB98);
			axGT依頼主.set_CelBackColor(axGT依頼主.SelStartRow,0,0x006000);
			axGT依頼主.set_CelForeColor(axGT依頼主.SelEndRow,0,0x98FB98);
			axGT依頼主.set_CelBackColor(axGT依頼主.SelEndRow,0,0x006000);
			axGT依頼主.set_CelForeColor(axGT依頼主.CaretRow,0,0x98FB98);
			axGT依頼主.set_CelBackColor(axGT依頼主.CaretRow,0,0x006000);
			if(axGT依頼主.SelEndRow > axGT依頼主.CaretRow
				&& axGT依頼主.SelStartRow <= axGT依頼主.CaretRow
				&& axGT依頼主.get_CelForeColor(axGT依頼主.SelEndRow,0) != Color.Black){
				axGT依頼主.set_CelForeColor(axGT依頼主.SelEndRow,0,0);
				axGT依頼主.set_CelBackColor(axGT依頼主.SelEndRow,0,0xFFFFFF);
			}

			if(axGT依頼主.SelEndRow < axGT依頼主.CaretRow
				&& axGT依頼主.SelStartRow >= axGT依頼主.CaretRow
				&& axGT依頼主.get_CelForeColor(axGT依頼主.SelEndRow,0) != Color.Black){
				axGT依頼主.set_CelForeColor(axGT依頼主.SelEndRow,0,0);
				axGT依頼主.set_CelBackColor(axGT依頼主.SelEndRow,0,0xFFFFFF);
			}

			nOldRow = axGT依頼主.CaretRow;
////			OldRow = axGT依頼主.CaretRow;
			nSrow  = axGT依頼主.SelStartRow;
			nErow  = axGT依頼主.SelEndRow;
// MOD 2010.09.21 東都）高木 複数選択時の背景色変更 END
		}

		private void btn検索_Click(object sender, System.EventArgs e)
		{
			iアクティブＦＧ = 1;
			axGT依頼主.CaretRow  = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 START
			axGT依頼主.CaretCol = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 END
			axGT依頼主_CurPlaceChanged(null,null);
			axGT依頼主.Clear();
// MOD 2008.10.01 東都）高木 一覧に請求先を表示 START
			axGT依頼主.ColsWidth = "0|14.6|14.2|6.0|8.0|5.9|9.7|";
// MOD 2008.10.01 東都）高木 一覧に請求先を表示 END
// MOD 2010.09.02 東都）高木 選択時のずれの対応 START
			カラム幅の補正(axGT依頼主);
// MOD 2010.09.02 東都）高木 選択時のずれの対応 END
// MOD 2009.11.30 東都）高木 検索条件に名前、請求先を追加 START
			btn前頁.Enabled = false;
			btn次頁.Enabled = false;
			lab頁番号.Text = "";
// MOD 2009.11.30 東都）高木 検索条件に名前、請求先を追加 END

			// 空白除去
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//			tex依頼主カナ.Text   = tex依頼主カナ.Text.Trim();
			if(gsオプション[18].Equals("1")){
				tex依頼主カナ.Text   = tex依頼主カナ.Text.TrimEnd();
			}else{
				tex依頼主カナ.Text   = tex依頼主カナ.Text.Trim();
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
			tex依頼主コード.Text = tex依頼主コード.Text.Trim();
			if(!半角チェック(tex依頼主カナ,"依頼主カナ")) return;
			if(!半角チェック(tex依頼主コード,"依頼主コード")) return;
// MOD 2009.11.30 東都）高木 検索条件に名前、請求先を追加 START
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//			tex依頼主名前.Text = tex依頼主名前.Text.Trim();
			if(gsオプション[18].Equals("1")){
				tex依頼主名前.Text = tex依頼主名前.Text.TrimEnd();
			}else{
				tex依頼主名前.Text = tex依頼主名前.Text.Trim();
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
			if(!全角チェック(tex依頼主名前,"依頼主名前")) return;
// MOD 2009.11.30 東都）高木 検索条件に名前、請求先を追加 END

// MOD 2009.11.30 東都）高木 検索条件に名前、請求先を追加 START
			// 請求先情報表示
			s請求先ＣＤ = "";
			s部課ＣＤ   = "";
			tex請求先コード.Text = "";
			if(gsa請求先ＣＤ.Length > 0 && cmb請求先.SelectedIndex > 0){
				s請求先ＣＤ = gsa請求先ＣＤ[cmb請求先.SelectedIndex - 1];
				s部課ＣＤ   = gsa請求先部課ＣＤ[cmb請求先.SelectedIndex - 1];
				tex請求先コード.Text = s請求先ＣＤ.TrimEnd() + " " + s部課ＣＤ.TrimEnd();
			}
// MOD 2009.11.30 東都）高木 検索条件に名前、請求先を追加 END

			i現在頁数 = 1;
			axGT依頼主.CaretRow = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 START
			axGT依頼主.CaretCol = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 END
			axGT依頼主.set_CelForeColor(nOldRow,0,0);
//			axGT依頼主.set_CelForeColor(axGT依頼主.CaretRow,0,111111);
			axGT依頼主.set_CelForeColor(axGT依頼主.CaretRow,0,0x98FB98);  //BGR
			axGT依頼主.set_CelBackColor(axGT依頼主.CaretRow,0,0x006000);
			nOldRow = axGT依頼主.CaretRow;

			s依頼主一覧 = new string[1];
			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				texメッセージ.Text = "検索中．．．";
				if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
// MOD 2009.11.30 東都）高木 検索条件に名前、請求先を追加 START
//				s依頼主一覧 = sv_goirai.Get_irainusi(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,tex依頼主カナ.Text,tex依頼主コード.Text);
				string[] saキー = new string[]{
					gs会員ＣＤ.TrimEnd()
					, gs部門ＣＤ.TrimEnd()
					, tex依頼主カナ.Text.TrimEnd()
					, tex依頼主コード.Text.TrimEnd()
					, tex依頼主名前.Text.TrimEnd()
					, s請求先ＣＤ.TrimEnd()
					, s部課ＣＤ.TrimEnd()
					, cb階層リスト１.SelectedIndex.ToString().TrimEnd()
					, cbソート方向１.SelectedIndex.ToString().TrimEnd()
					, cb階層リスト２.SelectedIndex.ToString().TrimEnd()
					, cbソート方向２.SelectedIndex.ToString().TrimEnd()
				};
				s依頼主一覧 = sv_goirai.Get_irainusi2(gsaユーザ,saキー);
// MOD 2009.11.30 東都）高木 検索条件に名前、請求先を追加 END
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				s依頼主一覧[0] = gs通信エラー;
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				s依頼主一覧[0] = "通信エラー：" + ex.Message;
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;

			texメッセージ.Text = s依頼主一覧[0];
			if(s依頼主一覧[0].Length == 4)
			{
				texメッセージ.Text = "";
// MOD 2005.05.10 東都）小童谷 一行目空白 START
//				i最大頁数 = (s依頼主一覧.Length - 2) / axGT依頼主.Rows + 1;
				i最大頁数 = (s依頼主一覧.Length - 2) / (axGT依頼主.Rows - 1) + 1;
// MOD 2005.05.10 東都）小童谷 一行目空白 END
				if (i現在頁数 > i最大頁数)
					i現在頁数 = i最大頁数;
				頁情報設定();
			}
			else
			{
				if(s依頼主一覧[0].Equals("該当データがありません"))
				{
					texメッセージ.Text = "";
					MessageBox.Show("該当データがありません","ご依頼主検索",MessageBoxButtons.OK);
				}
				else
				{
					axGT依頼主.Clear();
					i現在頁数 = 1;
					btn前頁.Enabled = false;
					btn次頁.Enabled = false;
					lab頁番号.Text = "";
					ビープ音();
				}
				tex依頼主カナ.Focus();
			}
		}

		private void btn確定_Click(object sender, System.EventArgs e)
		{
			sIname = axGT依頼主.get_CelText(axGT依頼主.CaretRow,1);
			sIcode = axGT依頼主.get_CelText(axGT依頼主.CaretRow,3);
			if(sIcode != "")
				this.Close();

		}

		private void btn複写_Click(object sender, System.EventArgs e)
		{
			s複写 = "T";
			sIcode = axGT依頼主.get_CelText(axGT依頼主.CaretRow,3);
			if(sIcode != "")
				this.Close();
		}

		private void axGT依頼主_KeyDownEvent(object sender, AxGTABLE32V2Lib._DGTable32Events_KeyDownEvent e)
		{
			if (e.keyCode == 13)
			{
				btn確定_Click(sender, null);
			}
			if (e.keyCode == 9)
			{
				this.SelectNextControl(axGT依頼主, true, true, true, true);
			}
		}

		private void tex依頼主コード_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btn検索_Click(sender, e);
			}
		}

		private void btn前頁_Click(object sender, System.EventArgs e)
		{
			i現在頁数--;
			頁情報設定();
// ADD 2005.05.10 東都）小童谷 一行目選択 START
			axGT依頼主.CaretRow = 1;
			axGT依頼主_CurPlaceChanged(null,null);
// ADD 2005.05.10 東都）小童谷 一行目選択 END
		}

		private void btn次頁_Click(object sender, System.EventArgs e)
		{
			i現在頁数++;
			頁情報設定();
// ADD 2005.05.10 東都）小童谷 一行目選択 START
			axGT依頼主.CaretRow = 1;
			axGT依頼主_CurPlaceChanged(null,null);
// ADD 2005.05.10 東都）小童谷 一行目選択 END
		}

		private void 頁情報設定()
		{
			axGT依頼主.Clear();

// MOD 2005.05.10 東都）小童谷 一行目空白 START
//			i開始数 = (i現在頁数 - 1) * axGT依頼主.Rows + 1;
			i開始数 = (i現在頁数 - 1) * (axGT依頼主.Rows - 1) + 1;
//			i終了数 = i現在頁数 * axGT依頼主.Rows;
			i終了数 = i現在頁数 * (axGT依頼主.Rows - 1);

//			short s表示数 = (short)1;
			short s表示数 = (short)2;
// MOD 2005.05.10 東都）小童谷 一行目空白 END
			for(short sCnt = (short)i開始数; sCnt < s依頼主一覧.Length && sCnt <= i終了数 ; sCnt++)
			{
				axGT依頼主.set_RowsText(s表示数, s依頼主一覧[sCnt]);
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
			axGT依頼主.Focus();
		}

		private void ご依頼主検索_Activated(object sender, System.EventArgs e)
		{
			if(tex依頼主コード.Text.Trim().Length != 0 && iアクティブＦＧ == 0)
				btn検索_Click(sender,e);
		}

// ADD 2005.05.24 東都）小童谷 フォーカス移動 START
		private void ご依頼主検索_Closed(object sender, System.EventArgs e)
		{
// ADD 2005.07.08 東都）小童谷 複写ボタンを消す START
			btn複写.Visible = false;
// ADD 2005.07.08 東都）小童谷 複写ボタンを消す END
// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 START
			btnCSV出力.Visible = false;
			btn一覧印刷.Visible = false;
			btn削除.Visible = false;
// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 END
			tex依頼主カナ.Text   = " ";
			tex依頼主コード.Text = "";
// MOD 2009.11.30 東都）高木 検索条件に名前、請求先を追加 START
			tex依頼主名前.Text = "";
			cmb請求先.SelectedIndex = 0;
// MOD 2010.02.03 東都）高木 ソート条件の保持機能を追加 START
////			cb階層リスト１.SelectedIndex = 0;
////			cbソート方向１.SelectedIndex = 0;
////			cb階層リスト２.SelectedIndex = 0;
////			cbソート方向２.SelectedIndex = 0;
//			cb階層リスト１.SelectedIndex = 4;
//			cbソート方向１.SelectedIndex = 0;
//			cb階層リスト２.SelectedIndex = 2;
//			cbソート方向２.SelectedIndex = 0;
// MOD 2010.02.03 東都）高木 ソート条件の保持機能を追加 END
// MOD 2009.11.30 東都）高木 検索条件に名前、請求先を追加 END
			texメッセージ.Text = "";
			axGT依頼主.Clear();
			axGT依頼主.CaretRow  = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 START
			axGT依頼主.CaretCol = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 END
			axGT依頼主_CurPlaceChanged(null,null);
			tex依頼主カナ.Focus();
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 START
			gsご依頼主検索_表示順１      = cb階層リスト１.Text.TrimEnd();
			gsご依頼主検索_表示順１_方向 = cbソート方向１.Text.TrimEnd();
			gsご依頼主検索_表示順２      = cb階層リスト２.Text.TrimEnd();
			gsご依頼主検索_表示順２_方向 = cbソート方向２.Text.TrimEnd();
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 END
		}
// ADD 2005.05.24 東都）小童谷 フォーカス移動 END
// MOD 2009.11.30 東都）高木 検索条件に名前、請求先を追加 START
		private void cb階層リスト１_select(object sender, System.EventArgs e)
		{
			if(cb階層リスト１.SelectedIndex != 0){
				cbソート方向１.Visible = true;
			}else{
				cbソート方向１.Visible = false;
			}
		}

		private void cb階層リスト２_select(object sender, System.EventArgs e)
		{
			if(cb階層リスト２.SelectedIndex != 0){
				cbソート方向２.Visible = true;
			}else{
				cbソート方向２.Visible = false;
			}
		}

		private void cmb請求先_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btn検索_Click(sender, e);
			}
		}

		private void cmb請求先_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// 請求先情報表示
			s請求先ＣＤ = "";
			s部課ＣＤ   = "";
			tex請求先コード.Text = "";
			if(gsa請求先ＣＤ.Length > 0 && cmb請求先.SelectedIndex > 0)
			{
				s請求先ＣＤ = gsa請求先ＣＤ[cmb請求先.SelectedIndex - 1];
				s部課ＣＤ   = gsa請求先部課ＣＤ[cmb請求先.SelectedIndex - 1];
				tex請求先コード.Text = s請求先ＣＤ.TrimEnd() + " " + s部課ＣＤ.TrimEnd();
			}
		}
// MOD 2009.11.30 東都）高木 検索条件に名前、請求先を追加 END
// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 START
		private void btn削除_Click(object sender, System.EventArgs e)
		{
			texメッセージ.Text = "";

			string[] asご依頼主ＣＤ = {};
			DialogResult result;

			result = MessageBox.Show("指定されたデータを削除します。よろしいですか？"
									,"削除",MessageBoxButtons.YesNo);
			if(result == DialogResult.Yes){
				int iCnt  = 0;
				int iPosS = 0;
				int iPosE = 0;
				if(axGT依頼主.SelEndRow >= axGT依頼主.SelStartRow){
					iPosS = (int)axGT依頼主.SelStartRow;
					iPosE = (int)axGT依頼主.SelEndRow  ;
				}else{
					iPosS = (int)axGT依頼主.SelEndRow  ;
					iPosE = (int)axGT依頼主.SelStartRow;
				}
				iCnt = iPosE - iPosS + 1;
				asご依頼主ＣＤ = new string[iCnt];
				int iPos = 0;
				for(int iLine = iPosS; iLine <= iPosE; iLine++){
					asご依頼主ＣＤ[iPos++] = axGT依頼主.get_CelText((short)iLine,3).Trim();
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
					sData[3] = "ご依頼主";
					sData[4] = gs利用者ＣＤ;

					if(sv_otodoke == null) sv_goirai = new is2goirai.Service1();
					sList = sv_goirai.Del_irainusis(gsaユーザ, sData, asご依頼主ＣＤ);
					// [正常終了]時、画面をクリアする
					if(sList[0].Length != 4){
						ビープ音();
// MOD 2011.01.18 東都）高木 複数件削除機能の障害対応 START
//						texメッセージ.Text = sList[0];
//						btn検索_Click(sender,e);
						btn検索_Click(sender,e);
						texメッセージ.Text = sList[0];
// MOD 2011.01.18 東都）高木 複数件削除機能の障害対応 END
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
			}
// MOD 2010.09.22 東都）高木 削除：[いいえ]選択時の障害修正 START
//			texメッセージ.Text = "";
//			btn検索_Click(sender,e);
// MOD 2010.09.22 東都）高木 削除：[いいえ]選択時の障害修正 END
			return;
		}

		private void btn一覧印刷_Click(object sender, System.EventArgs e)
		{
			tex依頼主カナ.Text   = tex依頼主カナ.Text.TrimEnd();
			tex依頼主コード.Text = tex依頼主コード.Text.TrimEnd();
			tex依頼主名前.Text   = tex依頼主名前.Text.TrimEnd();
			if(!半角チェック(tex依頼主カナ,"依頼主カナ")) return;
			if(!半角チェック(tex依頼主コード,"依頼主コード")) return;
			if(!全角チェック(tex依頼主名前,"依頼主名前")) return;

			// 請求先情報表示
			s請求先ＣＤ = "";
			s部課ＣＤ   = "";
			tex請求先コード.Text = "";
			if(gsa請求先ＣＤ.Length > 0 && cmb請求先.SelectedIndex > 0){
				s請求先ＣＤ = gsa請求先ＣＤ[cmb請求先.SelectedIndex - 1];
				s部課ＣＤ   = gsa請求先部課ＣＤ[cmb請求先.SelectedIndex - 1];
				tex請求先コード.Text = s請求先ＣＤ.TrimEnd() + " " + s部課ＣＤ.TrimEnd();
			}

			texメッセージ.Text = "ご依頼主一覧印刷中．．．";
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				if(sv_print == null) sv_print = new is2print.Service1();
				string[] saキー = new string[]{
					gs会員ＣＤ.TrimEnd()
					, gs部門ＣＤ.TrimEnd()
					, tex依頼主カナ.Text.TrimEnd()
					, tex依頼主コード.Text.TrimEnd()
					, tex依頼主名前.Text.TrimEnd()
					, s請求先ＣＤ.TrimEnd()
					, s部課ＣＤ.TrimEnd()
					, cb階層リスト１.SelectedIndex.ToString().TrimEnd()
					, cbソート方向１.SelectedIndex.ToString().TrimEnd()
					, cb階層リスト２.SelectedIndex.ToString().TrimEnd()
					, cbソート方向２.SelectedIndex.ToString().TrimEnd()
				};

				string[] sRet = new string[1];
				IEnumerator iEnum
				 = sv_print.Get_ConsignorPrintData(gsaユーザ,saキー).GetEnumerator();
				iEnum.MoveNext();
				sRet = (string[])iEnum.Current;
				if (sRet[0].Equals("正常終了"))
				{
					ご依頼主データ ds = new ご依頼主データ();

					int iCnt = 1;
					//データセットに値をセット
					while (iEnum.MoveNext())
					{
						string[] sList = new string[14];
						sList = (string[])iEnum.Current;
					
						ご依頼主データ.tableご依頼主Row tr = (ご依頼主データ.tableご依頼主Row)ds.tableご依頼主.NewRow();
						tr.BeginEdit();
						tr.番号     = iCnt++;
						tr.コード   = sList[0].Trim();
						tr.カナ略称 = sList[1].Trim();
						if(sList[2].Trim().Length == 0)
							tr.電話番号 = sList[3] + "-" + sList[4];
						else
							tr.電話番号 = "(" + sList[2] + ")" + sList[3] + "-" + sList[4];
						tr.郵便番号 = sList[5] + "-" + sList[6];
						tr.住所     = sList[7].Trim() + sList[8].Trim() + sList[9].Trim();
						tr.名前     = sList[10].Trim() + "  " + sList[11].Trim();
						tr.重量     = double.Parse(sList[12]);
						tr.得意先コード = sList[13].Trim();
						tr.得意先部課コード = sList[14].Trim();
						tr.得意先部課名 = sList[15].Trim();
//保留 MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
///						if(gsオプション[18].Equals("1")){
							tr.カナ略称 = sList[1].TrimEnd();
							tr.住所     = sList[7].TrimEnd() + sList[8].TrimEnd() + sList[9].TrimEnd();
							tr.名前     = sList[10].TrimEnd() + "  " + sList[11].TrimEnd();
							tr.得意先部課名 = sList[15].TrimEnd();
///						}
//保留 MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
						tr.重量入力制御 = (sList.Length > 17) ? sList[17].TrimEnd() : "0";
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
						tr.EndEdit();

						ds.tableご依頼主.Rows.Add(tr);					
					}
					
					ご依頼主帳票 cr = new ご依頼主帳票();
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
				}else{
					texメッセージ.Text = sRet[0];
					ビープ音();
				}
			}catch (System.Net.WebException){
				texメッセージ.Text = gs通信エラー;
				ビープ音();
			}catch (Exception ex){
				texメッセージ.Text = ex.Message;
				ビープ音();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
			tex依頼主カナ.Focus();
		}

		private void btnCSV出力_Click(object sender, System.EventArgs e)
		{
			texメッセージ.Text = "";
			tex依頼主カナ.Text   = tex依頼主カナ.Text.TrimEnd();
			tex依頼主コード.Text = tex依頼主コード.Text.TrimEnd();
			tex依頼主名前.Text   = tex依頼主名前.Text.TrimEnd();
			if(!半角チェック(tex依頼主カナ,"依頼主カナ")) return;
			if(!半角チェック(tex依頼主コード,"依頼主コード")) return;
			if(!全角チェック(tex依頼主名前,"依頼主名前")) return;

			// 請求先情報表示
			s請求先ＣＤ = "";
			s部課ＣＤ   = "";
			tex請求先コード.Text = "";
			if(gsa請求先ＣＤ.Length > 0 && cmb請求先.SelectedIndex > 0){
				s請求先ＣＤ = gsa請求先ＣＤ[cmb請求先.SelectedIndex - 1];
				s部課ＣＤ   = gsa請求先部課ＣＤ[cmb請求先.SelectedIndex - 1];
				tex請求先コード.Text = s請求先ＣＤ.TrimEnd() + " " + s部課ＣＤ.TrimEnd();
			}

			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try{
				String[] sList;
				if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
				string[] saキー = new string[]{
					gs会員ＣＤ.TrimEnd()
					, gs部門ＣＤ.TrimEnd()
					, tex依頼主カナ.Text.TrimEnd()
					, tex依頼主コード.Text.TrimEnd()
					, tex依頼主名前.Text.TrimEnd()
					, s請求先ＣＤ.TrimEnd()
					, s部課ＣＤ.TrimEnd()
					, cb階層リスト１.SelectedIndex.ToString().TrimEnd()
					, cbソート方向１.SelectedIndex.ToString().TrimEnd()
					, cb階層リスト２.SelectedIndex.ToString().TrimEnd()
					, cbソート方向２.SelectedIndex.ToString().TrimEnd()
				};

				sList = sv_goirai.Get_csvwrite2(gsaユーザ, saキー);
				this.Cursor = System.Windows.Forms.Cursors.Default;

				if(sList[0].Length == 4){
					// 見出し部の編集
					sList[0] = "\"荷送人コード\",\"電話番号\","
						+ "\"住所１\",\"住所２\",\"予備１\","
						+ "\"名前１\",\"名前２\",\"予備２\","
						+ "\"郵便番号\",\"カナ略称\",\"才数\",\"重量\",\"メールアドレス\","
						+ "\"請求先コード\",\"請求先部課コード\""
						;

					// デフォルトのフォルダをデスクトップフォルダにする
					saveFileDialog1.InitialDirectory
						= Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
					saveFileDialog1.Filter = "ＣＳＶファイル (*.csv)|*.csv";
					byte[] bSJIS;
					if(saveFileDialog1.ShowDialog(this) == DialogResult.OK){
						System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
						for(int iCnt = 0; iCnt < sList.Length; iCnt++){
							bSJIS = toSJIS(sList[iCnt]);
							fs.Write(bSJIS, 0 , bSJIS.Length);
						}
						fs.Close();
					}
					texメッセージ.Text = "";
				}else{
					ビープ音();
					texメッセージ.Text = sList[0];
				}
			}catch (System.Net.WebException){
				this.Cursor = System.Windows.Forms.Cursors.Default;
				texメッセージ.Text = gs通信エラー;
				ビープ音();
			}catch(Exception ex){
				this.Cursor = System.Windows.Forms.Cursors.Default;
				texメッセージ.Text = ex.Message;
			}
			tex依頼主カナ.Focus();
		}
// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 END
	}
}
