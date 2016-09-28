using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [セクション変更]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 
	// ADD 2005.05.24 東都）小童谷 フォーカス移動 
	//--------------------------------------------------------------------------
	// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 
	//--------------------------------------------------------------------------
	// MOD 2016.05.24 BEVAS）松本 表示形式修正および検索機能追加
	//--------------------------------------------------------------------------
	public class 部門変更２ : 共通フォーム
	{
// MOD 2016.05.24 BEVAS）松本 表示形式修正および検索機能追加 START
//		private object o部署ＩＤＸ = null;
		public short nOldRow = 0;
		public string s部門コード;
		public string s部門名;
		private string[] s部門一覧;
		private int i現在頁数;
		private int i最大頁数;
		private int i開始数;
		private int i終了数;
		private int iアクティブＦＧ = 0;
		private int i頁最大行数 = 100;
// MOD 2016.05.24 BEVAS）松本 表示形式修正および検索機能追加 END

		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label lab部門変更タイトル;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lab部門名;
		private System.Windows.Forms.Label lab部門;
		private System.Windows.Forms.Panel panel5;
		private IS2Client.共通テキストボックス tex部門コード;
		private IS2Client.共通テキストボックス tex部門名;
		private System.Windows.Forms.Label lab会員コード;
		private System.Windows.Forms.Label lab会員名;
		private System.Windows.Forms.Button btn検索;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lab頁番号;
		private System.Windows.Forms.Button btn次頁;
		private System.Windows.Forms.Button btn前頁;
		private AxGTABLE32V2Lib.AxGTable32 axGT部門;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.Button btn更新;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public 部門変更２()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
			ＤＰＩ表示サイズ変換();
// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 END
//// MOD 2016.05.24 BEVAS）松本 表示形式修正および検索機能追加 START
//			this.axGT部門.Size = new System.Drawing.Size(422, 292);
//// MOD 2016.05.24 BEVAS）松本 表示形式修正および検索機能追加 END
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(部門変更２));
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab部門変更タイトル = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.tex部門コード = new IS2Client.共通テキストボックス();
			this.tex部門名 = new IS2Client.共通テキストボックス();
			this.lab会員コード = new System.Windows.Forms.Label();
			this.lab会員名 = new System.Windows.Forms.Label();
			this.btn検索 = new System.Windows.Forms.Button();
			this.lab部門名 = new System.Windows.Forms.Label();
			this.lab部門 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lab頁番号 = new System.Windows.Forms.Label();
			this.btn次頁 = new System.Windows.Forms.Button();
			this.btn前頁 = new System.Windows.Forms.Button();
			this.axGT部門 = new AxGTABLE32V2Lib.AxGTable32();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.btn更新 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).BeginInit();
			this.panel7.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel5.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axGT部門)).BeginInit();
			this.SuspendLayout();
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.lab部門変更タイトル);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(394, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab部門変更タイトル
			// 
			this.lab部門変更タイトル.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab部門変更タイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab部門変更タイトル.ForeColor = System.Drawing.Color.White;
			this.lab部門変更タイトル.Location = new System.Drawing.Point(12, 2);
			this.lab部門変更タイトル.Name = "lab部門変更タイトル";
			this.lab部門変更タイトル.Size = new System.Drawing.Size(264, 24);
			this.lab部門変更タイトル.TabIndex = 0;
			this.lab部門変更タイトル.Text = "セクション変更";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel5);
			this.groupBox2.Location = new System.Drawing.Point(8, 92);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(378, 70);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.Honeydew;
			this.panel5.Controls.Add(this.tex部門コード);
			this.panel5.Controls.Add(this.tex部門名);
			this.panel5.Controls.Add(this.lab会員コード);
			this.panel5.Controls.Add(this.lab会員名);
			this.panel5.Controls.Add(this.btn検索);
			this.panel5.Location = new System.Drawing.Point(3, 8);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(370, 60);
			this.panel5.TabIndex = 50;
			// 
			// tex部門コード
			// 
			this.tex部門コード.BackColor = System.Drawing.SystemColors.Window;
			this.tex部門コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex部門コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex部門コード.Location = new System.Drawing.Point(116, 5);
			this.tex部門コード.MaxLength = 10;
			this.tex部門コード.Name = "tex部門コード";
			this.tex部門コード.Size = new System.Drawing.Size(146, 23);
			this.tex部門コード.TabIndex = 1;
			this.tex部門コード.Text = "";
			// 
			// tex部門名
			// 
			this.tex部門名.BackColor = System.Drawing.SystemColors.Window;
			this.tex部門名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex部門名.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex部門名.Location = new System.Drawing.Point(116, 33);
			this.tex部門名.MaxLength = 100;
			this.tex部門名.Name = "tex部門名";
			this.tex部門名.Size = new System.Drawing.Size(174, 23);
			this.tex部門名.TabIndex = 2;
			this.tex部門名.Text = "";
			this.tex部門名.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex部門名_KeyDown);
			// 
			// lab会員コード
			// 
			this.lab会員コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab会員コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab会員コード.Location = new System.Drawing.Point(4, 10);
			this.lab会員コード.Name = "lab会員コード";
			this.lab会員コード.Size = new System.Drawing.Size(108, 16);
			this.lab会員コード.TabIndex = 0;
			this.lab会員コード.Text = "セクションコード";
			// 
			// lab会員名
			// 
			this.lab会員名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab会員名.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab会員名.Location = new System.Drawing.Point(4, 34);
			this.lab会員名.Name = "lab会員名";
			this.lab会員名.Size = new System.Drawing.Size(92, 16);
			this.lab会員名.TabIndex = 6;
			this.lab会員名.Text = "セクション名";
			// 
			// btn検索
			// 
			this.btn検索.BackColor = System.Drawing.Color.SteelBlue;
			this.btn検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn検索.ForeColor = System.Drawing.Color.White;
			this.btn検索.Location = new System.Drawing.Point(302, 32);
			this.btn検索.Name = "btn検索";
			this.btn検索.Size = new System.Drawing.Size(64, 22);
			this.btn検索.TabIndex = 3;
			this.btn検索.TabStop = false;
			this.btn検索.Text = "検索";
			this.btn検索.Click += new System.EventHandler(this.btn検索_Click);
			// 
			// lab部門名
			// 
			this.lab部門名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab部門名.Location = new System.Drawing.Point(6, 64);
			this.lab部門名.Name = "lab部門名";
			this.lab部門名.Size = new System.Drawing.Size(382, 24);
			this.lab部門名.TabIndex = 49;
			this.lab部門名.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab部門
			// 
			this.lab部門.Image = ((System.Drawing.Image)(resources.GetObject("lab部門.Image")));
			this.lab部門.Location = new System.Drawing.Point(180, 30);
			this.lab部門.Name = "lab部門";
			this.lab部門.Size = new System.Drawing.Size(32, 32);
			this.lab部門.TabIndex = 48;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.panel2);
			this.groupBox3.Location = new System.Drawing.Point(10, 172);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(377, 346);
			this.groupBox3.TabIndex = 52;
			this.groupBox3.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Honeydew;
			this.panel2.Controls.Add(this.lab頁番号);
			this.panel2.Controls.Add(this.btn次頁);
			this.panel2.Controls.Add(this.btn前頁);
			this.panel2.Controls.Add(this.axGT部門);
			this.panel2.Location = new System.Drawing.Point(5, 8);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(366, 328);
			this.panel2.TabIndex = 51;
			// 
			// lab頁番号
			// 
			this.lab頁番号.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab頁番号.ForeColor = System.Drawing.Color.Green;
			this.lab頁番号.Location = new System.Drawing.Point(248, 308);
			this.lab頁番号.Name = "lab頁番号";
			this.lab頁番号.Size = new System.Drawing.Size(56, 14);
			this.lab頁番号.TabIndex = 79;
			this.lab頁番号.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn次頁
			// 
			this.btn次頁.BackColor = System.Drawing.Color.SteelBlue;
			this.btn次頁.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn次頁.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn次頁.ForeColor = System.Drawing.Color.White;
			this.btn次頁.Location = new System.Drawing.Point(304, 304);
			this.btn次頁.Name = "btn次頁";
			this.btn次頁.Size = new System.Drawing.Size(48, 22);
			this.btn次頁.TabIndex = 78;
			this.btn次頁.TabStop = false;
			this.btn次頁.Text = "次頁";
			this.btn次頁.Click += new System.EventHandler(this.btn次頁_Click);
			// 
			// btn前頁
			// 
			this.btn前頁.BackColor = System.Drawing.Color.SteelBlue;
			this.btn前頁.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn前頁.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn前頁.ForeColor = System.Drawing.Color.White;
			this.btn前頁.Location = new System.Drawing.Point(200, 304);
			this.btn前頁.Name = "btn前頁";
			this.btn前頁.Size = new System.Drawing.Size(48, 22);
			this.btn前頁.TabIndex = 77;
			this.btn前頁.TabStop = false;
			this.btn前頁.Text = "前頁";
			this.btn前頁.Click += new System.EventHandler(this.btn前頁_Click);
			// 
			// axGT部門
			// 
			this.axGT部門.ContainingControl = this;
			this.axGT部門.DataSource = null;
			this.axGT部門.Location = new System.Drawing.Point(24, 16);
			this.axGT部門.Name = "axGT部門";
			this.axGT部門.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT部門.OcxState")));
			this.axGT部門.Size = new System.Drawing.Size(328, 272);
			this.axGT部門.TabIndex = 4;
			this.axGT部門.KeyDownEvent += new AxGTABLE32V2Lib._DGTable32Events_KeyDownEventHandler(this.axGT部門_KeyDownEvent);
			this.axGT部門.CelDblClick += new AxGTABLE32V2Lib._DGTable32Events_CelDblClickEventHandler(this.axGT部門_CelDblClick);
			this.axGT部門.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT部門_CurPlaceChanged);
			// 
			// btn閉じる
			// 
			this.btn閉じる.BackColor = System.Drawing.Color.PaleGreen;
			this.btn閉じる.ForeColor = System.Drawing.Color.Red;
			this.btn閉じる.Location = new System.Drawing.Point(118, 526);
			this.btn閉じる.Name = "btn閉じる";
			this.btn閉じる.Size = new System.Drawing.Size(54, 48);
			this.btn閉じる.TabIndex = 57;
			this.btn閉じる.TabStop = false;
			this.btn閉じる.Text = "閉じる";
			this.btn閉じる.Click += new System.EventHandler(this.btn閉じる_Click);
			// 
			// btn更新
			// 
			this.btn更新.BackColor = System.Drawing.Color.PaleGreen;
			this.btn更新.ForeColor = System.Drawing.Color.Blue;
			this.btn更新.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn更新.Location = new System.Drawing.Point(222, 526);
			this.btn更新.Name = "btn更新";
			this.btn更新.Size = new System.Drawing.Size(54, 48);
			this.btn更新.TabIndex = 56;
			this.btn更新.Text = "保存";
			this.btn更新.Click += new System.EventHandler(this.btn更新_Click);
			// 
			// 部門変更２
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(392, 582);
			this.Controls.Add(this.btn閉じる);
			this.Controls.Add(this.btn更新);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.lab部門名);
			this.Controls.Add(this.lab部門);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.groupBox2);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(398, 607);
			this.Name = "部門変更２";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "is-2 セクション変更";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
			this.Load += new System.EventHandler(this.部門変更_Load);
			this.Closed += new System.EventHandler(this.部門変更２_Closed);
			this.Activated += new System.EventHandler(this.部門変更２_Activated);
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).EndInit();
			this.panel7.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axGT部門)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		private void 部門変更_Load(object sender, System.EventArgs e)
		{
// MOD 2016.05.24 BEVAS）松本 表示形式修正および検索機能追加 START
//			// ライブラリの初期設定
//			部門アイコンの初期化();
//			listView部門.LargeImageList = imageList部門;
//
//			listView部門.Items.Clear();
//
//			lab部門名.Text = gs部門名;
//
//			// 現在の部署の位置を取得
//			o部署ＩＤＸ = gh部門ＣＤ[gs部門ＣＤ];
//
//			ListViewItem item;
//			for(int iCnt = 0; iCnt < gsa部門名.Length; iCnt++)
//			{
//				// 現在の部署はリストに表示しない
//				if(o部署ＩＤＸ != null && iCnt == (int)o部署ＩＤＸ) continue;  
//				item = new ListViewItem();
//				item.Text = gsa部門名[iCnt];
//				item.ImageIndex = 0;
//				listView部門.Items.Add(item);
//			}
//
//			listView部門.Focus();
			iアクティブＦＧ = 0;
			lab部門名.Text = gs部門名;
			tex部門コード.Text = s部門コード;
			tex部門名.Text = s部門名;

			axGT部門.Cols = 4;
			axGT部門.Rows = 15;
			axGT部門.ColSep = "|";
			axGT部門.CaretRow = 1;
			axGT部門.NoBeep = true;
			
			axGT部門.set_RowsText(0, "|コード|セクション名|出荷日|お客様コード|");
			axGT部門.ColsWidth = "0|7|16.7|0|0|";
			axGT部門.ColsAlignHorz = "1|1|0|0|0|";
			axGT部門.set_CelForeColor(axGT部門.CaretRow, 0, 0x98FB98);  //BGR
			axGT部門.set_CelBackColor(axGT部門.CaretRow, 0, 0x006000);

			btn前頁.Enabled = false;
			btn次頁.Enabled = false;
			lab頁番号.Text = "";
			i現在頁数 = 1;

			axGT部門.CaretRow = 1;
			axGT部門_CurPlaceChanged(null, null);
// MOD 2016.05.24 BEVAS）松本 表示形式修正および検索機能追加 END
		}

		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
// MOD 2016.05.24 BEVAS）松本 表示形式修正および検索機能追加 START
			s部門コード = "";
			s部門名 = "";
// MOD 2016.05.24 BEVAS）松本 表示形式修正および検索機能追加 END
			this.Close();
		}

		private void btn更新_Click(object sender, System.EventArgs e)
		{
// MOD 2016.05.24 BEVAS）松本 表示形式修正および検索機能追加 START
//			// 選択されていない場合には終了
//			if(listView部門.SelectedItems.Count == 0)
//			{	
//				MessageBox.Show("セクションが選択されていません。", "確認",
//					MessageBoxButtons.OK, MessageBoxIcon.Warning);
//				listView部門.Focus();
//				return;
//			}
//
//			int i選択項目 = listView部門.SelectedItems[0].Index;
//
//			if(i選択項目 >= 0)
//			{
//				if(o部署ＩＤＸ != null && i選択項目 >= (int)o部署ＩＤＸ)
//					i選択項目++;
//				gs部門名   = gsa部門名[i選択項目];
//				gs部門ＣＤ = gsa部門ＣＤ[i選択項目];
//				gs出荷日   = gsa出荷日[i選択項目];
//				if(gs出荷日.Length == 8)
//				{
//					gdt出荷日 = new DateTime(int.Parse(gs出荷日.Substring(0,4)), 
//											int.Parse(gs出荷日.Substring(4,2)),
//											int.Parse(gs出荷日.Substring(6)) );
//				}
////保留　いずれ削除 START
//				gsa請求先ＣＤ     = null;
//				gsa請求先部課ＣＤ = null;
//				gsa請求先部課名   = null;
//
//				// カーソルを砂時計にする
//				Cursor = System.Windows.Forms.Cursors.AppStarting;
//				string[] sRet = {""};
//				try
//				{
//					// 請求先情報の取得（gs会員ＣＤ、gs部門ＣＤ）
//					if(sv_init == null) sv_init = new is2init.Service1();
//					sRet = sv_init.Get_seikyu(gsaユーザ,gs会員ＣＤ, gs部門ＣＤ);
//
//					// 請求先情報数の取得
//					int iCntTokui  = int.Parse(sRet[1]);
//					// 基本情報の最終インデックス
//					int iPos = 2;
//
//					// 請求先情報の設定
//					if(iCntTokui > 0)
//					{
//						gsa請求先ＣＤ     = new string[iCntTokui];
//						gsa請求先部課ＣＤ = new string[iCntTokui];
//						gsa請求先部課名   = new string[iCntTokui];
//						for(int iCnt = 0; iCnt < iCntTokui; iCnt++)
//						{
//							gsa請求先ＣＤ[iCnt]     = sRet[iPos++];
//							gsa請求先部課ＣＤ[iCnt] = sRet[iPos++];
//							gsa請求先部課名[iCnt]   = sRet[iPos++];
//						}
//					}
//				}
//// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
//				catch (System.Net.WebException)
//				{
//					sRet[0] = gs通信エラー;
//				}
//// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
//				catch (Exception ex)
//				{
//					sRet[0] = "通信エラー：" + ex.Message;
//				}
//				// カーソルをデフォルトに戻す
//				Cursor = System.Windows.Forms.Cursors.Default;
//
//				if(sRet[0].Length != 4)
//				{
//					MessageBox.Show(sRet[0], "セクション変更", 
//						MessageBoxButtons.OK, MessageBoxIcon.Error);
//					return;
//				}
////保留　いずれ削除 END
//			}
			//選択されていない場合には終了
			if(axGT部門.get_CelText(axGT部門.CaretRow, 1).Trim().Length == 0)
			{
				MessageBox.Show("セクションが選択されていません。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				axGT部門.Focus();
				return;
			}

			gs部門ＣＤ = axGT部門.get_CelText(axGT部門.CaretRow, 1).Trim();
			gs部門名 = axGT部門.get_CelText(axGT部門.CaretRow, 2).Trim();
			gs出荷日 = axGT部門.get_CelText(axGT部門.CaretRow, 3).Trim();
			if(gs出荷日.Length == 8)
			{
				gdt出荷日 = new DateTime(int.Parse(gs出荷日.Substring(0, 4)), 
					int.Parse(gs出荷日.Substring(4, 2)),
					int.Parse(gs出荷日.Substring(6)) );
			}

//保留　いずれ削除 START
			gsa請求先ＣＤ = null;
			gsa請求先部課ＣＤ = null;
			gsa請求先部課名 = null;

			//カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sRet = {""};
			try
			{
				//請求先情報の取得（gs会員ＣＤ、gs部門ＣＤ）
				if(sv_init == null) sv_init = new is2init.Service1();
				sRet = sv_init.Get_seikyu(gsaユーザ, gs会員ＣＤ, gs部門ＣＤ);

				//請求先情報数の取得
				int iCntTokui  = int.Parse(sRet[1]);

				//基本情報の最終インデックス
				int iPos = 2;

				//請求先情報の設定
				if(iCntTokui > 0)
				{
					gsa請求先ＣＤ     = new string[iCntTokui];
					gsa請求先部課ＣＤ = new string[iCntTokui];
					gsa請求先部課名   = new string[iCntTokui];
					for(int iCnt = 0; iCnt < iCntTokui; iCnt++)
					{
						gsa請求先ＣＤ[iCnt]     = sRet[iPos++];
						gsa請求先部課ＣＤ[iCnt] = sRet[iPos++];
						gsa請求先部課名[iCnt]   = sRet[iPos++];
					}
				}
			}
			catch(System.Net.WebException)
			{
				sRet[0] = gs通信エラー;
			}
			catch(Exception ex)
			{
				sRet[0] = "通信エラー：" + ex.Message;
			}

			//カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;

			if(sRet[0].Length != 4)
			{
				MessageBox.Show(sRet[0], "セクション変更", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
//保留　いずれ削除 END
// MOD 2016.05.24 BEVAS）松本 表示形式修正および検索機能追加 END
// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 START
			gs部門店所ＣＤ = "";
			gs部門店所ＣＤ = 部門店所取得(gs部門ＣＤ);
// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 END

			this.Close();
		}

// MOD 2016.05.24 BEVAS）松本 表示形式修正および検索機能追加 START
		//不要の為、コメント化
//		private void listView部門_DoubleClick(object sender, System.EventArgs e)
//		{
//			btn更新_Click(sender, e);
//		}
// MOD 2016.05.24 BEVAS）松本 表示形式修正および検索機能追加 END

// ADD 2005.05.24 東都）小童谷 フォーカス移動 START
		private void 部門変更２_Closed(object sender, System.EventArgs e)
		{
			btn更新.Focus();
		}

// ADD 2005.05.24 東都）小童谷 フォーカス移動 END
// MOD 2016.05.24 BEVAS）松本 表示形式修正および検索機能追加 START
		private void axGT部門_CelDblClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelDblClickEvent e)
		{
			btn更新_Click(sender, null);
		}

		private void axGT部門_CurPlaceChanged(object sender, AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEvent e)
		{
			axGT部門.set_CelForeColor(nOldRow, 0, 0);
			axGT部門.set_CelBackColor(nOldRow, 0, 0xFFFFFF);
			axGT部門.set_CelForeColor(axGT部門.CaretRow, 0, 0x98FB98);  //BGR
			axGT部門.set_CelBackColor(axGT部門.CaretRow, 0, 0x006000);
			nOldRow = axGT部門.CaretRow;
		}

		private void axGT部門_KeyDownEvent(object sender, AxGTABLE32V2Lib._DGTable32Events_KeyDownEvent e)
		{
			if(e.keyCode == 0x0d)
			{
				s部門コード = axGT部門.get_CelText(axGT部門.CaretRow, 1);
				s部門名 = axGT部門.get_CelText(axGT部門.CaretRow, 2);
				if(s部門コード != "")
				{
					this.Close();
				}
			}
			if(e.keyCode == 0x09)
			{
				this.SelectNextControl(axGT部門, true, true, true, true);
			}
		}

		private void btn検索_Click(object sender, System.EventArgs e)
		{
			部門一覧検索();
		}

		private void tex部門名_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				部門一覧検索();
			}	
		}

		private void btn前頁_Click(object sender, System.EventArgs e)
		{
			i現在頁数--;
			頁情報設定();
			axGT部門.CaretRow = 1;
			axGT部門_CurPlaceChanged(null, null);
		}

		private void btn次頁_Click(object sender, System.EventArgs e)
		{
			i現在頁数++;
			頁情報設定();
			axGT部門.CaretRow = 1;
			axGT部門_CurPlaceChanged(null, null);
		}

		private void 部門一覧検索()
		{
			iアクティブＦＧ = 1;
			axGT部門.Clear();

			tex部門コード.Text = tex部門コード.Text.Trim();
			tex部門名.Text = tex部門名.Text.Trim();
			if(!半角チェック(tex部門コード, "セクションコード")) return;
			if(!全角チェック(tex部門名, "セクション名")) return;

//			texメッセージ.Text = "検索中．．．";
			s部門一覧 = new string[1];

			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;

			try
			{
				string[] sKey  = new string[3];
				sKey[0] = gs会員ＣＤ;
				sKey[1] = tex部門コード.Text;
				sKey[2] = tex部門名.Text;

				if(sv_init == null) sv_init = new is2init.Service1();
				s部門一覧 = sv_init.Get_bumon2(gsaユーザ, sKey);
			}
			catch (System.Net.WebException)
			{
				s部門一覧[0] = gs通信エラー;
			}
			catch (Exception ex)
			{
				s部門一覧[0] = "通信エラー：" + ex.Message;
			}

			//カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;

			if(s部門一覧[0].Equals("正常終了"))
			{
//				texメッセージ.Text = "";
				i最大頁数 = (s部門一覧.Length - 2) / axGT部門.Rows + 1;
				i最大頁数 = (s部門一覧.Length - 2) / i頁最大行数 + 1;
				if(i現在頁数 > i最大頁数)
				{
					i現在頁数 = i最大頁数;
				}
				頁情報設定();
				axGT部門.CaretRow = 1;
				axGT部門_CurPlaceChanged(null, null);
				axGT部門.Focus();
			}
			else
			{
				if(s部門一覧[0].Equals("該当データがありません"))
				{
//					texメッセージ.Text = "";
					MessageBox.Show("該当データがありません", "部門検索", MessageBoxButtons.OK);
				}
				else
				{
//					texメッセージ.Text = s部門一覧[0];
					MessageBox.Show(s部門一覧[0], "部門検索", MessageBoxButtons.OK);
					axGT部門.Clear();
					i現在頁数 = 1;
					btn前頁.Enabled = false;
					btn次頁.Enabled = false;
					lab頁番号.Text = "";
					ビープ音();
				}
				tex部門コード.Focus();
			}
		}

		private void 頁情報設定()
		{
			axGT部門.Clear();
			axGT部門.Rows = 15;

//			i開始数 = (i現在頁数 - 1) * axGT部門.Rows + 1;
//			i終了数 = i現在頁数 * axGT部門.Rows;
			i開始数 = (i現在頁数 - 1) * i頁最大行数 + 1;
			i終了数 = i現在頁数 * i頁最大行数;

			short s表示数 = (short)1;
			for(short sCnt = (short)i開始数; sCnt < s部門一覧.Length && sCnt <= i終了数 ; sCnt++)
			{
				if(s表示数 > 15)
				{
					axGT部門.Rows++;
				}
				axGT部門.set_RowsText(s表示数, s部門一覧[sCnt]);
				s表示数++;
			}

			lab頁番号.Text = i現在頁数.ToString() + " / " + i最大頁数.ToString();

			//btn前頁
			if(i現在頁数 == 1)
			{
				btn前頁.Enabled = false;
			}
			else
			{
				btn前頁.Enabled = true;
			}

			//btn次頁
			if(i現在頁数 == i最大頁数)
			{
				btn次頁.Enabled = false;
			}
			else
			{
				btn次頁.Enabled = true;
			}

			axGT部門.Focus();
		}

		private void 部門変更２_Activated(object sender, System.EventArgs e)
		{
			if(iアクティブＦＧ == 0)
			{
				部門一覧検索();
			}
		}
// MOD 2016.05.24 BEVAS）松本 表示形式修正および検索機能追加 END
	}
}
