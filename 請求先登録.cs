using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [請求先情報メンテナンス]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// ADD 2007.03.28 東都）高木 ORA-00936（missing expression）対応 
	// MOD 2007.07.26 東都）高木 依頼主に登録がないにもかかわらず請求先が削除できない 
	//--------------------------------------------------------------------------
	// ADD 2008.03.27 東都）高木 取消時の更新日時クリア対応 
	// ADD 2008.03.27 東都）高木 一覧に既にあるデータの対応 
	// ADD 2008.11.20 東都）高木 得意先部課コードの空白時対応 
	//                Oracle入替時の設定移行もれ？ or バージョンによる差異
	//--------------------------------------------------------------------------
	// MOD 2010.02.02 東都）高木 先頭に空白行を入れる 
	// MOD 2010.09.02 東都）高木 選択時のずれの対応 
	//--------------------------------------------------------------------------
	public class 請求先登録 : 共通フォーム//System.Windows.Forms.Form
	{
		private string s郵便番号 = "";
		private string s更新日時 = "";
		private short nOldRow = 0;

		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.Label lab請求先タイトル;
		private System.Windows.Forms.Label lab得意先部課名;
		private System.Windows.Forms.Button btn請求先取消;
		private System.Windows.Forms.Button btn請求先削除;
		private System.Windows.Forms.Button btn請求先登録;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lab得意先コード;
		private System.Windows.Forms.Label lab得意先部課コード;
		private AxGTABLE32V2Lib.AxGTable32 axGT請求先;
		private System.Windows.Forms.Panel pnl請求先;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private 共通テキストボックス tex得意先コード;
		private 共通テキストボックス tex得意先部課コード;
		private 共通テキストボックス tex得意先部課名;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.Label lab注意書き;
		private System.ComponentModel.IContainer components = null;

		public 請求先登録()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
			ＤＰＩ表示サイズ変換();
//			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
				this.axGT請求先.Size = new System.Drawing.Size(306, 217);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(請求先登録));
			this.pnl請求先 = new System.Windows.Forms.Panel();
			this.lab注意書き = new System.Windows.Forms.Label();
			this.tex得意先部課名 = new IS2Client.共通テキストボックス();
			this.tex得意先部課コード = new IS2Client.共通テキストボックス();
			this.tex得意先コード = new IS2Client.共通テキストボックス();
			this.label2 = new System.Windows.Forms.Label();
			this.lab得意先部課コード = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lab得意先コード = new System.Windows.Forms.Label();
			this.axGT請求先 = new AxGTABLE32V2Lib.AxGTable32();
			this.lab得意先部課名 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.btn請求先削除 = new System.Windows.Forms.Button();
			this.btn請求先取消 = new System.Windows.Forms.Button();
			this.btn請求先登録 = new System.Windows.Forms.Button();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab請求先タイトル = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.texメッセージ = new System.Windows.Forms.TextBox();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.pnl請求先.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axGT請求先)).BeginInit();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnl請求先
			// 
			this.pnl請求先.BackColor = System.Drawing.Color.Honeydew;
			this.pnl請求先.Controls.Add(this.lab注意書き);
			this.pnl請求先.Controls.Add(this.tex得意先部課名);
			this.pnl請求先.Controls.Add(this.tex得意先部課コード);
			this.pnl請求先.Controls.Add(this.tex得意先コード);
			this.pnl請求先.Controls.Add(this.label2);
			this.pnl請求先.Controls.Add(this.lab得意先部課コード);
			this.pnl請求先.Controls.Add(this.label3);
			this.pnl請求先.Controls.Add(this.lab得意先コード);
			this.pnl請求先.Controls.Add(this.axGT請求先);
			this.pnl請求先.Controls.Add(this.lab得意先部課名);
			this.pnl請求先.Controls.Add(this.label22);
			this.pnl請求先.Controls.Add(this.btn請求先削除);
			this.pnl請求先.Controls.Add(this.btn請求先取消);
			this.pnl請求先.Controls.Add(this.btn請求先登録);
			this.pnl請求先.Location = new System.Drawing.Point(0, 6);
			this.pnl請求先.Name = "pnl請求先";
			this.pnl請求先.Size = new System.Drawing.Size(370, 442);
			this.pnl請求先.TabIndex = 1;
			// 
			// lab注意書き
			// 
			this.lab注意書き.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab注意書き.ForeColor = System.Drawing.Color.Red;
			this.lab注意書き.Location = new System.Drawing.Point(42, 240);
			this.lab注意書き.Name = "lab注意書き";
			this.lab注意書き.Size = new System.Drawing.Size(302, 30);
			this.lab注意書き.TabIndex = 79;
			this.lab注意書き.Text = "得意先コード及び得意先部課コードは、最寄の弊社営業所までお問合せください。";
			this.lab注意書き.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tex得意先部課名
			// 
			this.tex得意先部課名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex得意先部課名.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex得意先部課名.Location = new System.Drawing.Point(158, 338);
			this.tex得意先部課名.MaxLength = 10;
			this.tex得意先部課名.Name = "tex得意先部課名";
			this.tex得意先部課名.Size = new System.Drawing.Size(174, 23);
			this.tex得意先部課名.TabIndex = 4;
			this.tex得意先部課名.Text = "";
			// 
			// tex得意先部課コード
			// 
			this.tex得意先部課コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex得意先部課コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex得意先部課コード.Location = new System.Drawing.Point(158, 308);
			this.tex得意先部課コード.MaxLength = 6;
			this.tex得意先部課コード.Name = "tex得意先部課コード";
			this.tex得意先部課コード.Size = new System.Drawing.Size(86, 23);
			this.tex得意先部課コード.TabIndex = 3;
			this.tex得意先部課コード.Text = "";
			// 
			// tex得意先コード
			// 
			this.tex得意先コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex得意先コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex得意先コード.Location = new System.Drawing.Point(158, 280);
			this.tex得意先コード.MaxLength = 12;
			this.tex得意先コード.Name = "tex得意先コード";
			this.tex得意先コード.Size = new System.Drawing.Size(156, 23);
			this.tex得意先コード.TabIndex = 2;
			this.tex得意先コード.Text = "";
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(42, 342);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 14);
			this.label2.TabIndex = 78;
			this.label2.Text = "※";
			// 
			// lab得意先部課コード
			// 
			this.lab得意先部課コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab得意先部課コード.Location = new System.Drawing.Point(56, 312);
			this.lab得意先部課コード.Name = "lab得意先部課コード";
			this.lab得意先部課コード.Size = new System.Drawing.Size(95, 14);
			this.lab得意先部課コード.TabIndex = 77;
			this.lab得意先部課コード.Text = "得意先部課コード";
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(42, 286);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 14);
			this.label3.TabIndex = 76;
			this.label3.Text = "※";
			// 
			// lab得意先コード
			// 
			this.lab得意先コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab得意先コード.Location = new System.Drawing.Point(56, 286);
			this.lab得意先コード.Name = "lab得意先コード";
			this.lab得意先コード.Size = new System.Drawing.Size(95, 14);
			this.lab得意先コード.TabIndex = 75;
			this.lab得意先コード.Text = "得意先コード";
			// 
			// axGT請求先
			// 
			this.axGT請求先.ContainingControl = this;
			this.axGT請求先.DataSource = null;
			this.axGT請求先.Location = new System.Drawing.Point(44, 12);
			this.axGT請求先.Name = "axGT請求先";
			this.axGT請求先.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT請求先.OcxState")));
			this.axGT請求先.Size = new System.Drawing.Size(306, 217);
			this.axGT請求先.TabIndex = 0;
			this.axGT請求先.KeyDownEvent += new AxGTABLE32V2Lib._DGTable32Events_KeyDownEventHandler(this.axGT請求先_KeyDownEvent);
			this.axGT請求先.CelDblClick += new AxGTABLE32V2Lib._DGTable32Events_CelDblClickEventHandler(this.axGT請求先_CelDblClick);
			this.axGT請求先.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT請求先_CurPlaceChanged);
			// 
			// lab得意先部課名
			// 
			this.lab得意先部課名.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab得意先部課名.Location = new System.Drawing.Point(56, 342);
			this.lab得意先部課名.Name = "lab得意先部課名";
			this.lab得意先部課名.Size = new System.Drawing.Size(95, 14);
			this.lab得意先部課名.TabIndex = 52;
			this.lab得意先部課名.Text = "得意先部課名";
			// 
			// label22
			// 
			this.label22.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label22.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label22.ForeColor = System.Drawing.Color.Blue;
			this.label22.Location = new System.Drawing.Point(0, 0);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(22, 444);
			this.label22.TabIndex = 50;
			this.label22.Text = "請求先情報";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn請求先削除
			// 
			this.btn請求先削除.BackColor = System.Drawing.Color.SteelBlue;
			this.btn請求先削除.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn請求先削除.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn請求先削除.ForeColor = System.Drawing.Color.White;
			this.btn請求先削除.Location = new System.Drawing.Point(288, 406);
			this.btn請求先削除.Name = "btn請求先削除";
			this.btn請求先削除.Size = new System.Drawing.Size(64, 22);
			this.btn請求先削除.TabIndex = 13;
			this.btn請求先削除.Text = "削除";
			this.btn請求先削除.Click += new System.EventHandler(this.btn請求先削除_Click);
			// 
			// btn請求先取消
			// 
			this.btn請求先取消.BackColor = System.Drawing.Color.SteelBlue;
			this.btn請求先取消.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn請求先取消.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn請求先取消.ForeColor = System.Drawing.Color.White;
			this.btn請求先取消.Location = new System.Drawing.Point(210, 406);
			this.btn請求先取消.Name = "btn請求先取消";
			this.btn請求先取消.Size = new System.Drawing.Size(64, 22);
			this.btn請求先取消.TabIndex = 12;
			this.btn請求先取消.Text = "取消";
			this.btn請求先取消.Click += new System.EventHandler(this.btn請求先取消_Click);
			// 
			// btn請求先登録
			// 
			this.btn請求先登録.BackColor = System.Drawing.Color.SteelBlue;
			this.btn請求先登録.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn請求先登録.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn請求先登録.ForeColor = System.Drawing.Color.White;
			this.btn請求先登録.Location = new System.Drawing.Point(134, 406);
			this.btn請求先登録.Name = "btn請求先登録";
			this.btn請求先登録.Size = new System.Drawing.Size(64, 22);
			this.btn請求先登録.TabIndex = 10;
			this.btn請求先登録.Text = "保存";
			this.btn請求先登録.Click += new System.EventHandler(this.btn請求先登録_Click);
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.PaleGreen;
			this.panel6.Location = new System.Drawing.Point(0, 26);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(396, 26);
			this.panel6.TabIndex = 12;
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.lab請求先タイトル);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(396, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab請求先タイトル
			// 
			this.lab請求先タイトル.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab請求先タイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab請求先タイトル.ForeColor = System.Drawing.Color.White;
			this.lab請求先タイトル.Location = new System.Drawing.Point(12, 2);
			this.lab請求先タイトル.Name = "lab請求先タイトル";
			this.lab請求先タイトル.Size = new System.Drawing.Size(264, 24);
			this.lab請求先タイトル.TabIndex = 0;
			this.lab請求先タイトル.Text = "請求先情報メンテナンス";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.texメッセージ);
			this.panel8.Controls.Add(this.btn閉じる);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(396, 58);
			this.panel8.TabIndex = 2;
			// 
			// texメッセージ
			// 
			this.texメッセージ.BackColor = System.Drawing.Color.PaleGreen;
			this.texメッセージ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texメッセージ.ForeColor = System.Drawing.Color.Red;
			this.texメッセージ.Location = new System.Drawing.Point(126, 4);
			this.texメッセージ.Multiline = true;
			this.texメッセージ.Name = "texメッセージ";
			this.texメッセージ.ReadOnly = true;
			this.texメッセージ.Size = new System.Drawing.Size(256, 50);
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
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.pnl請求先);
			this.groupBox2.Location = new System.Drawing.Point(8, 58);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(372, 450);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// 請求先登録
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(388, 574);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(394, 605);
			this.Name = "請求先登録";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 請求先情報メンテナンス";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
			this.Load += new System.EventHandler(this.請求先登録_Load);
			this.Closed += new System.EventHandler(this.請求先登録_Closed);
			this.pnl請求先.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axGT請求先)).EndInit();
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		private void 請求先登録_Load(object sender, System.EventArgs e)
		{
			初期モード();
			
			// 請求先リストの初期設定
			axGT請求先.Cols = 4;
// MOD 2010.02.02 東都）高木 先頭に空白行を入れる START
//			axGT請求先.Rows = 6;
			axGT請求先.Rows = 11;
// MOD 2010.02.02 東都）高木 先頭に空白行を入れる END
			axGT請求先.ColSep = "|";
			axGT請求先.CaretRow = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 START
//			axGT請求先.CaretCol = 2;
			axGT請求先.CaretCol = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 END
			axGT請求先.NoBeep = true;			

			axGT請求先.set_RowsText(0, "|得意先コード|部課コード|部課名|更新日時|");
			axGT請求先.ColsWidth = "0|7|5|10|0|";
// MOD 2010.09.02 東都）高木 選択時のずれの対応 START
			カラム幅の補正(axGT請求先);
// MOD 2010.09.02 東都）高木 選択時のずれの対応 END
			axGT請求先.ColsAlignHorz = "1|1|1|0|0|";
            
//			axGT請求先.set_CelForeColor(axGT請求先.CaretRow,0,111111);
			axGT請求先.set_CelForeColor(axGT請求先.CaretRow,0,0x98FB98);  //BGR
			axGT請求先.set_CelBackColor(axGT請求先.CaretRow,0,0x006000);

			axGT請求先.Clear();
			請求先一覧検索();
		}

		private void 初期モード()
		{
			請求先登録モード();
			tex得意先コード.Focus();
		}

		private void 請求先登録モード()
		{
			tex得意先コード.Text = "";
			tex得意先部課コード.Text = "";
			tex得意先部課名.Text = "";

			axGT請求先.set_CelForeColor(nOldRow,0,0);
			axGT請求先.set_CelBackColor(nOldRow,0,0xFFFFFF);
//			axGT請求先.set_CelForeColor(axGT請求先.CaretRow,0,111111);
			axGT請求先.set_CelForeColor(axGT請求先.CaretRow,0,0x98FB98);  //BGR
			axGT請求先.set_CelBackColor(axGT請求先.CaretRow,0,0x006000);
			nOldRow = axGT請求先.CaretRow;
			axGT請求先.Focus();
			tex得意先コード.Text     = axGT請求先.get_CelText(axGT請求先.CaretRow,1);
			tex得意先部課コード.Text = axGT請求先.get_CelText(axGT請求先.CaretRow,2);
			tex得意先部課名.Text     = axGT請求先.get_CelText(axGT請求先.CaretRow,3);
			s更新日時                = axGT請求先.get_CelText(axGT請求先.CaretRow,4);
		}

		private void 請求先一覧検索()
		{
// MOD 2010.02.02 東都）高木 先頭に空白行を入れる START
//			short s表示数 = 1;
//			axGT請求先.Clear();
//			axGT請求先.Rows = 6;
			short s表示数 = 2;
			axGT請求先.Clear();
			axGT請求先.Rows = 11;
// MOD 2010.02.02 東都）高木 先頭に空白行を入れる END
// MOD 2010.09.02 東都）高木 選択時のずれの対応 START
//			axGT請求先.CaretRow = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 END

			axGT請求先.Clear();
			texメッセージ.Text = "検索中．．．";
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;

			try
			{
				if(sv_seikyuu == null) sv_seikyuu = new is2seikyuu.Service1();
// DEL 2005.05.20 東都）高木 セションコントロールの廃止 START
//				sv_seikyuu.CookieContainer = cContainer;
// DEL 2005.05.20 東都）高木 セションコントロールの廃止 END
				String[] sList = sv_seikyuu.Get_Claim(gsaユーザ,gs会員ＣＤ.Trim(),gs部門ＣＤ.Trim());
				s郵便番号 = sList[1];
				if(sList[0].Equals("正常終了") || sList[0].Equals("該当データがありません"))
				{
					texメッセージ.Text = "";
// MOD 2010.02.02 東都）高木 先頭に空白行を入れる START
//					if (axGT請求先.Rows < sList.Length - 2)
//					{
//						axGT請求先.Rows = (short)(sList.Length - 2);
//					}
					//行数設定
					if(axGT請求先.Rows < (sList.Length - 1)){
						axGT請求先.Rows = (short)(sList.Length - 1);
					}
// MOD 2010.02.02 東都）高木 先頭に空白行を入れる END
					for(short nCnt = 2; nCnt < sList.Length; nCnt++)
					{
						axGT請求先.set_RowsText(s表示数, sList[nCnt]);
						s表示数++;
					}
					tex得意先コード.Text     = axGT請求先.get_CelText(axGT請求先.CaretRow,1);
					tex得意先部課コード.Text = axGT請求先.get_CelText(axGT請求先.CaretRow,2);
					tex得意先部課名.Text     = axGT請求先.get_CelText(axGT請求先.CaretRow,3);
					s更新日時                = axGT請求先.get_CelText(axGT請求先.CaretRow,4);
				}
				else
				{
					texメッセージ.Text = sList[0];
				}
			}
// ADD 2005.07.04 東都）高木 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				texメッセージ.Text = gs通信エラー;
				ビープ音();
				初期モード();
			}
// ADD 2005.07.04 東都）高木 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				texメッセージ.Text = ex.Message;
				ビープ音();
				初期モード();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void axGT請求先_CelDblClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelDblClickEvent e)
		{
/*			string s得意先 = axGT請求先.get_CelText(axGT請求先.CaretRow,1);
			if(!s得意先.Equals(""))
			{
				tex得意先コード.Text     = s得意先;
				tex得意先部課コード.Text = axGT請求先.get_CelText(axGT請求先.CaretRow,2);
				tex得意先部課名.Text     = axGT請求先.get_CelText(axGT請求先.CaretRow,3);
//				s郵便番号                = axGT請求先.get_CelText(axGT請求先.CaretRow,1);
				s更新日時                = axGT請求先.get_CelText(axGT請求先.CaretRow,4);

			}*/
		}

		private void axGT請求先_KeyDownEvent(object sender, AxGTABLE32V2Lib._DGTable32Events_KeyDownEvent e)
		{
			if (e.keyCode == 0x0d)
			{
				this.SelectNextControl(axGT請求先, true, true, true, true);
			}
			if (e.keyCode == 0x09)
			{
				this.SelectNextControl(axGT請求先, true, true, true, true);
			}
		}
		
		private void btn請求先取消_Click(object sender, System.EventArgs e)
		{
			tex得意先コード.Text = "";
			tex得意先部課コード.Text = "";
			tex得意先部課名.Text = "";
// ADD 2008.03.27 東都）高木 取消時の更新日時クリア対応 START
			s更新日時 = "";
// ADD 2008.03.27 東都）高木 取消時の更新日時クリア対応 END
		}

		private void btn請求先登録_Click(object sender, System.EventArgs e)
		{
			tex得意先コード.Text     =  tex得意先コード.Text.Trim();
			tex得意先部課コード.Text =  tex得意先部課コード.Text.Trim();
			tex得意先部課名.Text     =  tex得意先部課名.Text.Trim();

			if(!必須チェック(tex得意先コード, "得意先コード")) return;
			if (tex得意先部課コード.Text.Length == 0)
			{
				tex得意先部課コード.Text = " ";
			}
			if(!必須チェック(tex得意先部課名, "得意先部課名")) return;

			if(!半角チェック(tex得意先コード, "得意先コード")) return;
			if(!半角チェック(tex得意先部課コード, "得意先部課コード")) return;
			if(!全角チェック(tex得意先部課名, "得意先部課名")) return;

			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				if(sv_seikyuu == null) sv_seikyuu = new is2seikyuu.Service1();
				String[] sCnt = sv_seikyuu.Get_seikyuucnt(gsaユーザ,s郵便番号,tex得意先コード.Text,tex得意先部課コード.Text);
				this.Cursor = System.Windows.Forms.Cursors.Default;

				string[] sKey  = new string[8];
				sKey[0] = s郵便番号;
				sKey[1] = tex得意先コード.Text;
				sKey[2] = tex得意先部課コード.Text;
				sKey[3] = tex得意先部課名.Text;
				sKey[4] = gs会員ＣＤ;
				sKey[5] = "請求先登";
				sKey[6] = gs利用者ＣＤ;
				sKey[7] = s更新日時;

				DialogResult result;
				if(sCnt[0] == "0")
				{
					result = MessageBox.Show("新規登録しますか？","登録",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						//請求先の追加
						texメッセージ.Text = "登録中．．．";

						if(sv_seikyuu == null) sv_seikyuu = new is2seikyuu.Service1();
						string[] sList = sv_seikyuu.Ins_Claim(gsaユーザ, sKey);
						Cursor = System.Windows.Forms.Cursors.Default;

						if (sList[0].Equals("正常終了"))
						{
							請求先一覧検索();
							請求先登録モード();
							texメッセージ.Text = "";
						}
						else
						{
							ビープ音();
							texメッセージ.Text = sList[0];
						}
					}
				}
				else
				{
// ADD 2008.03.27 東都）高木 一覧に既にあるデータの対応 START
					s更新日時 = "";
					for(short sRow = 1; sRow <= axGT請求先.Rows; sRow++){
						if(tex得意先コード.Text.Trim().Equals(axGT請求先.get_CelText(sRow,1))
						&& tex得意先部課コード.Text.Trim().Equals(axGT請求先.get_CelText(sRow,2))){
							s更新日時 = axGT請求先.get_CelText(sRow,4);
							sKey[7] = s更新日時;
							break;
						}
					}
// ADD 2008.03.27 東都）高木 一覧に既にあるデータの対応 END
// ADD 2007.03.28 東都）高木 ORA-00936（missing expression）対応 START
					if(s更新日時 == null || s更新日時.Trim().Length == 0)
					{
						MessageBox.Show("入力された得意先コード及び得意先部課コードは、\n"
										+ "既に他のお客様で使用されています。"
							,"更新",MessageBoxButtons.OK);
						return;
					}
// ADD 2007.03.28 東都）高木 ORA-00936（missing expression）対応 END

					result = MessageBox.Show("既に存在するデータに上書きしますか？","更新",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						//請求先の更新
						texメッセージ.Text = "更新中．．．";

						if(sv_seikyuu == null) sv_seikyuu = new is2seikyuu.Service1();
						string[] sList = sv_seikyuu.Upd_Claim(gsaユーザ, sKey);
						Cursor = System.Windows.Forms.Cursors.Default;

						texメッセージ.Text = sList[0];
						if (sList[0].Equals("正常終了"))
						{
							請求先一覧検索();
							請求先登録モード();
						}
						else
						{
							ビープ音();
						}
					}
				}
			}
// ADD 2005.07.04 東都）高木 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				texメッセージ.Text = gs通信エラー;
				ビープ音();
				初期モード();
			}
// ADD 2005.07.04 東都）高木 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				texメッセージ.Text = ex.Message;
				ビープ音();
				初期モード();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void btn請求先削除_Click(object sender, System.EventArgs e)
		{
			tex得意先コード.Text     =  tex得意先コード.Text.Trim();
			tex得意先部課コード.Text =  tex得意先部課コード.Text.Trim();

			if(!必須チェック(tex得意先コード, "得意先コード")) return;
// ADD 2008.11.20 東都）高木 得意先部課コードの空白時対応 START
			if (tex得意先部課コード.Text.Length == 0)
			{
				tex得意先部課コード.Text = " ";
			}
// ADD 2008.11.20 東都）高木 得意先部課コードの空白時対応 END
			if(!半角チェック(tex得意先コード, "得意先コード")) return;
			if(!半角チェック(tex得意先部課コード, "得意先部課コード")) return;

			//請求先の削除
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;

			string[] sKey  = new string[6];
			try
			{
				if(sv_seikyuu == null) sv_seikyuu = new is2seikyuu.Service1();
				String[] sCnt = sv_seikyuu.Get_seikyuucnt(gsaユーザ,s郵便番号,tex得意先コード.Text,tex得意先部課コード.Text);
				this.Cursor = System.Windows.Forms.Cursors.Default;

				DialogResult result;
				if(sCnt[0] == "0")
				{
					MessageBox.Show("コード(" + tex得意先コード.Text + ")のデータは存在しません","削除",MessageBoxButtons.OK);
				}
				else
				{
// ADD 2008.03.27 東都）高木 一覧に既にあるデータの対応 START
					s更新日時 = "";
					for(short sRow = 1; sRow <= axGT請求先.Rows; sRow++){
						if(tex得意先コード.Text.Trim().Equals(axGT請求先.get_CelText(sRow,1))
						&& tex得意先部課コード.Text.Trim().Equals(axGT請求先.get_CelText(sRow,2))){
							s更新日時 = axGT請求先.get_CelText(sRow,4);
							break;
						}
					}
// ADD 2008.03.27 東都）高木 一覧に既にあるデータの対応 END
// ADD 2007.03.28 東都）高木 ORA-00936（missing expression）対応 START
					if(s更新日時 == null || s更新日時.Trim().Length == 0)
					{
						MessageBox.Show("入力された得意先コード及び得意先部課コードは、\n"
										+ "他のお客様で使用されています。"
							,"削除",MessageBoxButtons.OK);
						return;
					}
// ADD 2007.03.28 東都）高木 ORA-00936（missing expression）対応 END
// ADD 2005.11.07 東都）伊賀 出荷ジャーナルチェック START
					if(sv_seikyuu == null) sv_seikyuu = new is2seikyuu.Service1();
// MOD 2007.07.26 東都）高木 依頼主に登録がないにもかかわらず請求先が削除できない START
//					string[] sCKey = new string[3];
//					sCKey[0] = gs会員ＣＤ;
//					sCKey[1] = tex得意先コード.Text;
//					sCKey[2] = tex得意先部課コード.Text;
					string[] sCKey = new string[4];
					sCKey[0] = gs会員ＣＤ;
					sCKey[1] = tex得意先コード.Text;
					sCKey[2] = tex得意先部課コード.Text;
					sCKey[3] = s郵便番号;
// MOD 2007.07.26 東都）高木 依頼主に登録がないにもかかわらず請求先が削除できない END
					if (sCKey[2].Length == 0)
						sCKey[2] = " ";
					String[] sCList = sv_seikyuu.Sel_IrainusiSeikyuu(gsaユーザ,sCKey);

					if(sCList[0].Length != 4)
					{
						ビープ音();
						texメッセージ.Text = sCList[0];
						return;
					}
// ADD 2005.11.07 東都）伊賀 出荷ジャーナルチェック END

					result = MessageBox.Show("コード(" + tex得意先コード.Text + ")のデータを削除しますか？","削除",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						texメッセージ.Text = "削除中．．．";
						sKey[0] = s郵便番号;
						sKey[1] = tex得意先コード.Text;
						sKey[2] = tex得意先部課コード.Text;
						sKey[3] = "請求先マ";
						sKey[4] = gs利用者ＣＤ;
						sKey[5] = s更新日時;

						Cursor = System.Windows.Forms.Cursors.AppStarting;

						if(sv_seikyuu == null) sv_seikyuu = new is2seikyuu.Service1();
						string[] sList = sv_seikyuu.Del_Claim(gsaユーザ, sKey);

						texメッセージ.Text = sList[0];
						if (sList[0].Equals("正常終了"))
						{
							請求先一覧検索();
							請求先登録モード();
						}
						else
						{
							ビープ音();
						}
					}
					Cursor = System.Windows.Forms.Cursors.Default;
				}
			}
// ADD 2005.07.04 東都）高木 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				texメッセージ.Text = gs通信エラー;
				ビープ音();
				初期モード();
			}
// ADD 2005.07.04 東都）高木 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				texメッセージ.Text = ex.Message;
				ビープ音();
				初期モード();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void axGT請求先_CurPlaceChanged(object sender, AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEvent e)
		{
			axGT請求先.set_CelForeColor(nOldRow,0,0);
			axGT請求先.set_CelBackColor(nOldRow,0,0xFFFFFF);
//			axGT請求先.set_CelForeColor(axGT請求先.CaretRow,0,111111);
			axGT請求先.set_CelForeColor(axGT請求先.CaretRow,0,0x98FB98);  //BGR
			axGT請求先.set_CelBackColor(axGT請求先.CaretRow,0,0x006000);
			nOldRow = axGT請求先.CaretRow;
			tex得意先コード.Text     = axGT請求先.get_CelText(axGT請求先.CaretRow,1);
			tex得意先部課コード.Text = axGT請求先.get_CelText(axGT請求先.CaretRow,2);
			tex得意先部課名.Text     = axGT請求先.get_CelText(axGT請求先.CaretRow,3);
			s更新日時                = axGT請求先.get_CelText(axGT請求先.CaretRow,4);
		}

// ADD 2005.05.24 東都）小童谷 フォーカス移動 START
		private void 請求先登録_Closed(object sender, System.EventArgs e)
		{
			axGT請求先.CaretRow = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 START
			axGT請求先.CaretCol = 1;
// MOD 2010.09.02 東都）高木 選択時のずれの対応 END
			axGT請求先_CurPlaceChanged(null,null);
			axGT請求先.Focus();
		}
// ADD 2005.05.24 東都）小童谷 フォーカス移動 END

	}
}
