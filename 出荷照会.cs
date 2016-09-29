using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [出荷照会]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// MOD 2007.02.08 東都）高木 一覧表示項目の変更 
	// MOD 2007.02.19 FJCS）桑田 メッセージ変更 
	// MOD 2007.02.20 東都）高木 ＣＳＶ出力は、旧バージョンにする 
	// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 
	// MOD 2007.07.06 東都）高木 ヘッダにログイン集荷店を表示 
	//--------------------------------------------------------------------------
	// MOD 2008.10.29 東都）高木 請求先情報を追加 
	//--------------------------------------------------------------------------
	// MOD 2009.11.04 東都）高木 検索条件に送り状番号とお客様番号の項目を追加 
	//--------------------------------------------------------------------------
	// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）
	// MOD 2010.02.25 東都）高木 複写機能の追加 
	// MOD 2010.06.18 東都）高木 出荷データの参照・追加・更新・削除ログの追加 
	// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） 
	// MOD 2010.09.03 東都）高木 ＣＳＶエントリー時の請求先エラー表記修正 
	// MOD 2010.10.01 東都）高木 お客様番号１６桁化 
	// MOD 2010.11.12 東都）高木 未発行データを削除可能にする 
	// ADD 2010.12.14 ACT）垣原 王子運送の対応 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない 
	// MOD 2011.03.17 東都）高木 送り状番号の桁数チェックの変更 
	// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 
	// MOD 2011.07.14 東都）高木 記事行の追加 
	//--------------------------------------------------------------------------
	// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加
	//--------------------------------------------------------------------------
	// MOD 2015.05.07 BEVAS）前田 王子荷主様の郵便番号存在チェック対応
	//--------------------------------------------------------------------------
	// MOD 2016.05.24 BEVAS）松本 複写ボタン押下時の挙動修正
	//--------------------------------------------------------------------------
	public class 出荷照会 : 共通フォーム
	{
		public short OldRow = 0;
		private short nSrow = 0;
		private short nErow = 0;
		private short nWork = 0;
		private string s届け先ＣＤ;
		private string s届け先名;
		private string s依頼主ＣＤ;
		private string s依頼主名;

		private string[] s出荷一覧;
		private int      i現在頁数;
//		private int      i最大頁数;
//		private int      i開始数;
//		private int      i終了数;

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab日時;
		private 共通テキストボックス tex届け先コード;
		private System.Windows.Forms.Label lab届け先;
		private System.Windows.Forms.TextBox tex重量合計;
		private System.Windows.Forms.TextBox tex個数合計;
		private System.Windows.Forms.Label lab登録件数;
		private System.Windows.Forms.TextBox tex登録件数;
		private System.Windows.Forms.Label lab個数合計;
		private System.Windows.Forms.Label lab重量合計;
		private System.Windows.Forms.Label lab依頼主;
		private 共通テキストボックス tex依頼主コード;
		private System.Windows.Forms.Label lab状態;
		private System.Windows.Forms.TextBox tex依頼主名;
		private System.Windows.Forms.TextBox tex届け先名;
		private System.Windows.Forms.Label lab利用部門;
		private System.Windows.Forms.Label lab出荷照会タイトル;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.Button btn届け先検索;
		private System.Windows.Forms.Button btn依頼主検索;
		private System.Windows.Forms.Button btn出荷検索;
		private System.Windows.Forms.Button btn再発行;
		private System.Windows.Forms.Button btn出荷登録;
		private System.Windows.Forms.Button btn一括削除;
		private System.Windows.Forms.Button btn雛型登録;
		private System.Windows.Forms.TextBox tex利用部門;
		private System.Windows.Forms.Label lab出荷日;
		private AxGTABLE32V2Lib.AxGTable32 axGT出荷一覧;
		private System.Windows.Forms.DateTimePicker dt開始日付;
		private System.Windows.Forms.DateTimePicker dt終了日付;
		private System.Windows.Forms.ComboBox cmb状態;
		private System.Windows.Forms.ComboBox cmb出荷日;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnＣＳＶ出力;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label labログイン集荷店;
		private System.Windows.Forms.TextBox texログイン集荷店;
		private System.Windows.Forms.Label lab頁番号;
		private System.Windows.Forms.Button btn次頁;
		private System.Windows.Forms.Button btn前頁;
		private System.Windows.Forms.Label lab送り状番号;
		private System.Windows.Forms.Label labお客様番号;
		private System.Windows.Forms.Label label2;
		private IS2Client.共通テキストボックス texお客様番号開始;
		private IS2Client.共通テキストボックス texお客様番号終了;
		private IS2Client.共通テキストボックス tex送り状番号開始;
		private System.Windows.Forms.Label label3;
		private IS2Client.共通テキストボックス tex送り状番号終了;
		private System.Windows.Forms.Button btn複写;
		private System.Windows.Forms.Label label4;
		private System.ComponentModel.IContainer components;

		public 出荷照会()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
			ＤＰＩ表示サイズ変換();
//			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
				this.axGT出荷一覧.Size = new System.Drawing.Size(732, 282);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(出荷照会));
            this.tex届け先コード = new IS2Client.共通テキストボックス();
            this.lab届け先 = new System.Windows.Forms.Label();
            this.btn届け先検索 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.axGT出荷一覧 = new AxGTABLE32V2Lib.AxGTable32();
            this.tex重量合計 = new System.Windows.Forms.TextBox();
            this.tex個数合計 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.lab登録件数 = new System.Windows.Forms.Label();
            this.tex登録件数 = new System.Windows.Forms.TextBox();
            this.lab個数合計 = new System.Windows.Forms.Label();
            this.lab重量合計 = new System.Windows.Forms.Label();
            this.lab依頼主 = new System.Windows.Forms.Label();
            this.btn依頼主検索 = new System.Windows.Forms.Button();
            this.tex依頼主コード = new IS2Client.共通テキストボックス();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tex送り状番号終了 = new IS2Client.共通テキストボックス();
            this.label3 = new System.Windows.Forms.Label();
            this.texお客様番号終了 = new IS2Client.共通テキストボックス();
            this.label2 = new System.Windows.Forms.Label();
            this.texお客様番号開始 = new IS2Client.共通テキストボックス();
            this.labお客様番号 = new System.Windows.Forms.Label();
            this.tex送り状番号開始 = new IS2Client.共通テキストボックス();
            this.lab送り状番号 = new System.Windows.Forms.Label();
            this.cmb状態 = new System.Windows.Forms.ComboBox();
            this.lab状態 = new System.Windows.Forms.Label();
            this.cmb出荷日 = new System.Windows.Forms.ComboBox();
            this.btn出荷検索 = new System.Windows.Forms.Button();
            this.tex依頼主名 = new System.Windows.Forms.TextBox();
            this.tex届け先名 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dt開始日付 = new System.Windows.Forms.DateTimePicker();
            this.lab出荷日 = new System.Windows.Forms.Label();
            this.dt終了日付 = new System.Windows.Forms.DateTimePicker();
            this.lab頁番号 = new System.Windows.Forms.Label();
            this.btn次頁 = new System.Windows.Forms.Button();
            this.btn前頁 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.labログイン集荷店 = new System.Windows.Forms.Label();
            this.texログイン集荷店 = new System.Windows.Forms.TextBox();
            this.lab利用部門 = new System.Windows.Forms.Label();
            this.tex利用部門 = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lab日時 = new System.Windows.Forms.Label();
            this.lab出荷照会タイトル = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btn複写 = new System.Windows.Forms.Button();
            this.btnＣＳＶ出力 = new System.Windows.Forms.Button();
            this.btn雛型登録 = new System.Windows.Forms.Button();
            this.btn一括削除 = new System.Windows.Forms.Button();
            this.btn出荷登録 = new System.Windows.Forms.Button();
            this.btn再発行 = new System.Windows.Forms.Button();
            this.texメッセージ = new System.Windows.Forms.TextBox();
            this.btn閉じる = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ds送り状)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGT出荷一覧)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tex届け先コード
            // 
            this.tex届け先コード.BackColor = System.Drawing.SystemColors.Window;
            this.tex届け先コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex届け先コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tex届け先コード.Location = new System.Drawing.Point(94, 2);
            this.tex届け先コード.MaxLength = 15;
            this.tex届け先コード.Name = "tex届け先コード";
            this.tex届け先コード.Size = new System.Drawing.Size(190, 23);
            this.tex届け先コード.TabIndex = 0;
            this.tex届け先コード.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex届け先コード_KeyDown);
            this.tex届け先コード.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex届け先コード_KeyPress);
            this.tex届け先コード.LostFocus += new System.EventHandler(this.tex届け先コード_LostFocus);
            // 
            // lab届け先
            // 
            this.lab届け先.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab届け先.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab届け先.Location = new System.Drawing.Point(12, 6);
            this.lab届け先.Name = "lab届け先";
            this.lab届け先.Size = new System.Drawing.Size(70, 16);
            this.lab届け先.TabIndex = 8;
            this.lab届け先.Text = "お届け先";
            // 
            // btn届け先検索
            // 
            this.btn届け先検索.BackColor = System.Drawing.Color.SteelBlue;
            this.btn届け先検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn届け先検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn届け先検索.ForeColor = System.Drawing.Color.White;
            this.btn届け先検索.Location = new System.Drawing.Point(286, 4);
            this.btn届け先検索.Name = "btn届け先検索";
            this.btn届け先検索.Size = new System.Drawing.Size(64, 22);
            this.btn届け先検索.TabIndex = 1;
            this.btn届け先検索.TabStop = false;
            this.btn届け先検索.Text = "アドレス帳";
            this.btn届け先検索.UseVisualStyleBackColor = false;
            this.btn届け先検索.Click += new System.EventHandler(this.btn届け先検索_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Honeydew;
            this.panel2.Controls.Add(this.label5);
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
            this.panel2.Size = new System.Drawing.Size(764, 316);
            this.panel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(546, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 28);
            this.label5.TabIndex = 56;
            this.label5.Text = "※表示の運賃は概算運賃であり、変更されることがあります。";
            // 
            // axGT出荷一覧
            // 
            this.axGT出荷一覧.DataSource = null;
            this.axGT出荷一覧.Location = new System.Drawing.Point(28, 30);
            this.axGT出荷一覧.Name = "axGT出荷一覧";
            this.axGT出荷一覧.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT出荷一覧.OcxState")));
            this.axGT出荷一覧.Size = new System.Drawing.Size(732, 282);
            this.axGT出荷一覧.TabIndex = 51;
            this.axGT出荷一覧.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT出荷一覧_CurPlaceChanged);
            this.axGT出荷一覧.CelClick += new AxGTABLE32V2Lib._DGTable32Events_CelClickEventHandler(this.axGT出荷一覧_CelClick);
            this.axGT出荷一覧.KeyDownEvent += new AxGTABLE32V2Lib._DGTable32Events_KeyDownEventHandler(this.axGT出荷一覧_KeyDownEvent);
            // 
            // tex重量合計
            // 
            this.tex重量合計.BackColor = System.Drawing.SystemColors.Window;
            this.tex重量合計.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex重量合計.Location = new System.Drawing.Point(382, 4);
            this.tex重量合計.Name = "tex重量合計";
            this.tex重量合計.ReadOnly = true;
            this.tex重量合計.Size = new System.Drawing.Size(86, 23);
            this.tex重量合計.TabIndex = 50;
            this.tex重量合計.TabStop = false;
            this.tex重量合計.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tex個数合計
            // 
            this.tex個数合計.BackColor = System.Drawing.SystemColors.Window;
            this.tex個数合計.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex個数合計.Location = new System.Drawing.Point(246, 4);
            this.tex個数合計.Name = "tex個数合計";
            this.tex個数合計.ReadOnly = true;
            this.tex個数合計.Size = new System.Drawing.Size(70, 23);
            this.tex個数合計.TabIndex = 49;
            this.tex個数合計.TabStop = false;
            this.tex個数合計.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.label21.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(0, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(22, 316);
            this.label21.TabIndex = 3;
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab登録件数
            // 
            this.lab登録件数.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab登録件数.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab登録件数.ForeColor = System.Drawing.Color.Blue;
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
            this.tex登録件数.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex登録件数.Location = new System.Drawing.Point(122, 4);
            this.tex登録件数.Name = "tex登録件数";
            this.tex登録件数.ReadOnly = true;
            this.tex登録件数.Size = new System.Drawing.Size(54, 23);
            this.tex登録件数.TabIndex = 46;
            this.tex登録件数.TabStop = false;
            this.tex登録件数.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lab個数合計
            // 
            this.lab個数合計.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab個数合計.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lab重量合計.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab重量合計.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab重量合計.ForeColor = System.Drawing.Color.Blue;
            this.lab重量合計.Location = new System.Drawing.Point(322, 6);
            this.lab重量合計.Name = "lab重量合計";
            this.lab重量合計.Size = new System.Drawing.Size(60, 18);
            this.lab重量合計.TabIndex = 8;
            this.lab重量合計.Text = "重量合計";
            this.lab重量合計.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab依頼主
            // 
            this.lab依頼主.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab依頼主.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab依頼主.Location = new System.Drawing.Point(12, 32);
            this.lab依頼主.Name = "lab依頼主";
            this.lab依頼主.Size = new System.Drawing.Size(70, 16);
            this.lab依頼主.TabIndex = 8;
            this.lab依頼主.Text = "ご依頼主";
            // 
            // btn依頼主検索
            // 
            this.btn依頼主検索.BackColor = System.Drawing.Color.SteelBlue;
            this.btn依頼主検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn依頼主検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn依頼主検索.ForeColor = System.Drawing.Color.White;
            this.btn依頼主検索.Location = new System.Drawing.Point(286, 30);
            this.btn依頼主検索.Name = "btn依頼主検索";
            this.btn依頼主検索.Size = new System.Drawing.Size(64, 22);
            this.btn依頼主検索.TabIndex = 3;
            this.btn依頼主検索.TabStop = false;
            this.btn依頼主検索.Text = "検索";
            this.btn依頼主検索.UseVisualStyleBackColor = false;
            this.btn依頼主検索.Click += new System.EventHandler(this.btn依頼主検索_Click);
            // 
            // tex依頼主コード
            // 
            this.tex依頼主コード.BackColor = System.Drawing.SystemColors.Window;
            this.tex依頼主コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex依頼主コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tex依頼主コード.Location = new System.Drawing.Point(94, 28);
            this.tex依頼主コード.MaxLength = 12;
            this.tex依頼主コード.Name = "tex依頼主コード";
            this.tex依頼主コード.Size = new System.Drawing.Size(154, 23);
            this.tex依頼主コード.TabIndex = 2;
            this.tex依頼主コード.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex依頼主コード_KeyDown);
            this.tex依頼主コード.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex依頼主コード_KeyPress);
            this.tex依頼主コード.LostFocus += new System.EventHandler(this.tex依頼主コード_LostFocus);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Honeydew;
            this.panel5.Controls.Add(this.tex送り状番号終了);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.texお客様番号終了);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.texお客様番号開始);
            this.panel5.Controls.Add(this.labお客様番号);
            this.panel5.Controls.Add(this.tex送り状番号開始);
            this.panel5.Controls.Add(this.lab送り状番号);
            this.panel5.Controls.Add(this.cmb状態);
            this.panel5.Controls.Add(this.lab状態);
            this.panel5.Controls.Add(this.cmb出荷日);
            this.panel5.Controls.Add(this.btn出荷検索);
            this.panel5.Controls.Add(this.tex依頼主名);
            this.panel5.Controls.Add(this.tex届け先名);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.dt開始日付);
            this.panel5.Controls.Add(this.lab出荷日);
            this.panel5.Controls.Add(this.lab届け先);
            this.panel5.Controls.Add(this.btn届け先検索);
            this.panel5.Controls.Add(this.tex届け先コード);
            this.panel5.Controls.Add(this.lab依頼主);
            this.panel5.Controls.Add(this.tex依頼主コード);
            this.panel5.Controls.Add(this.btn依頼主検索);
            this.panel5.Controls.Add(this.dt終了日付);
            this.panel5.Location = new System.Drawing.Point(1, 8);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(589, 134);
            this.panel5.TabIndex = 0;
            // 
            // tex送り状番号終了
            // 
            this.tex送り状番号終了.BackColor = System.Drawing.SystemColors.Window;
            this.tex送り状番号終了.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex送り状番号終了.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tex送り状番号終了.Location = new System.Drawing.Point(260, 80);
            this.tex送り状番号終了.MaxLength = 13;
            this.tex送り状番号終了.Name = "tex送り状番号終了";
            this.tex送り状番号終了.Size = new System.Drawing.Size(142, 23);
            this.tex送り状番号終了.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.LimeGreen;
            this.label3.Location = new System.Drawing.Point(238, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 16);
            this.label3.TabIndex = 77;
            this.label3.Text = "～";
            // 
            // texお客様番号終了
            // 
            this.texお客様番号終了.BackColor = System.Drawing.SystemColors.Window;
            this.texお客様番号終了.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.texお客様番号終了.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.texお客様番号終了.Location = new System.Drawing.Point(304, 106);
            this.texお客様番号終了.MaxLength = 20;
            this.texお客様番号終了.Name = "texお客様番号終了";
            this.texお客様番号終了.Size = new System.Drawing.Size(190, 23);
            this.texお客様番号終了.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.LimeGreen;
            this.label2.Location = new System.Drawing.Point(284, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 16);
            this.label2.TabIndex = 75;
            this.label2.Text = "～";
            // 
            // texお客様番号開始
            // 
            this.texお客様番号開始.BackColor = System.Drawing.SystemColors.Window;
            this.texお客様番号開始.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.texお客様番号開始.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.texお客様番号開始.Location = new System.Drawing.Point(94, 106);
            this.texお客様番号開始.MaxLength = 20;
            this.texお客様番号開始.Name = "texお客様番号開始";
            this.texお客様番号開始.Size = new System.Drawing.Size(190, 23);
            this.texお客様番号開始.TabIndex = 9;
            // 
            // labお客様番号
            // 
            this.labお客様番号.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labお客様番号.ForeColor = System.Drawing.Color.LimeGreen;
            this.labお客様番号.Location = new System.Drawing.Point(8, 110);
            this.labお客様番号.Name = "labお客様番号";
            this.labお客様番号.Size = new System.Drawing.Size(86, 16);
            this.labお客様番号.TabIndex = 73;
            this.labお客様番号.Text = "お客様番号";
            // 
            // tex送り状番号開始
            // 
            this.tex送り状番号開始.BackColor = System.Drawing.SystemColors.Window;
            this.tex送り状番号開始.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex送り状番号開始.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tex送り状番号開始.Location = new System.Drawing.Point(94, 80);
            this.tex送り状番号開始.MaxLength = 13;
            this.tex送り状番号開始.Name = "tex送り状番号開始";
            this.tex送り状番号開始.Size = new System.Drawing.Size(142, 23);
            this.tex送り状番号開始.TabIndex = 7;
            // 
            // lab送り状番号
            // 
            this.lab送り状番号.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab送り状番号.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab送り状番号.Location = new System.Drawing.Point(12, 84);
            this.lab送り状番号.Name = "lab送り状番号";
            this.lab送り状番号.Size = new System.Drawing.Size(82, 16);
            this.lab送り状番号.TabIndex = 71;
            this.lab送り状番号.Text = "送り状番号";
            // 
            // cmb状態
            // 
            this.cmb状態.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb状態.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb状態.Location = new System.Drawing.Point(488, 54);
            this.cmb状態.Name = "cmb状態";
            this.cmb状態.Size = new System.Drawing.Size(76, 24);
            this.cmb状態.TabIndex = 6;
            this.cmb状態.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb状態_KeyDown);
            // 
            // lab状態
            // 
            this.lab状態.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab状態.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab状態.Location = new System.Drawing.Point(412, 58);
            this.lab状態.Name = "lab状態";
            this.lab状態.Size = new System.Drawing.Size(76, 16);
            this.lab状態.TabIndex = 13;
            this.lab状態.Text = "輸送状況";
            // 
            // cmb出荷日
            // 
            this.cmb出荷日.BackColor = System.Drawing.Color.White;
            this.cmb出荷日.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb出荷日.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb出荷日.ForeColor = System.Drawing.Color.LimeGreen;
            this.cmb出荷日.Items.AddRange(new object[] {
            "出荷日",
            "登録日"});
            this.cmb出荷日.Location = new System.Drawing.Point(12, 54);
            this.cmb出荷日.Name = "cmb出荷日";
            this.cmb出荷日.Size = new System.Drawing.Size(78, 24);
            this.cmb出荷日.TabIndex = 4;
            // 
            // btn出荷検索
            // 
            this.btn出荷検索.BackColor = System.Drawing.Color.SteelBlue;
            this.btn出荷検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn出荷検索.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn出荷検索.ForeColor = System.Drawing.Color.White;
            this.btn出荷検索.Location = new System.Drawing.Point(504, 94);
            this.btn出荷検索.Name = "btn出荷検索";
            this.btn出荷検索.Size = new System.Drawing.Size(76, 36);
            this.btn出荷検索.TabIndex = 11;
            this.btn出荷検索.TabStop = false;
            this.btn出荷検索.Text = "照会";
            this.btn出荷検索.UseVisualStyleBackColor = false;
            this.btn出荷検索.Click += new System.EventHandler(this.btn出荷検索_Click);
            // 
            // tex依頼主名
            // 
            this.tex依頼主名.BackColor = System.Drawing.Color.Honeydew;
            this.tex依頼主名.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tex依頼主名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex依頼主名.Location = new System.Drawing.Point(354, 32);
            this.tex依頼主名.Name = "tex依頼主名";
            this.tex依頼主名.ReadOnly = true;
            this.tex依頼主名.Size = new System.Drawing.Size(224, 16);
            this.tex依頼主名.TabIndex = 12;
            this.tex依頼主名.TabStop = false;
            // 
            // tex届け先名
            // 
            this.tex届け先名.BackColor = System.Drawing.Color.Honeydew;
            this.tex届け先名.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tex届け先名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex届け先名.Location = new System.Drawing.Point(354, 6);
            this.tex届け先名.Name = "tex届け先名";
            this.tex届け先名.ReadOnly = true;
            this.tex届け先名.Size = new System.Drawing.Size(224, 16);
            this.tex届け先名.TabIndex = 11;
            this.tex届け先名.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(238, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "～";
            // 
            // dt開始日付
            // 
            this.dt開始日付.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dt開始日付.Location = new System.Drawing.Point(94, 54);
            this.dt開始日付.Name = "dt開始日付";
            this.dt開始日付.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dt開始日付.Size = new System.Drawing.Size(144, 23);
            this.dt開始日付.TabIndex = 4;
            // 
            // lab出荷日
            // 
            this.lab出荷日.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab出荷日.ForeColor = System.Drawing.Color.Green;
            this.lab出荷日.Location = new System.Drawing.Point(12, 58);
            this.lab出荷日.Name = "lab出荷日";
            this.lab出荷日.Size = new System.Drawing.Size(70, 16);
            this.lab出荷日.TabIndex = 6;
            this.lab出荷日.Text = "出荷日";
            // 
            // dt終了日付
            // 
            this.dt終了日付.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dt終了日付.Location = new System.Drawing.Point(260, 54);
            this.dt終了日付.Name = "dt終了日付";
            this.dt終了日付.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dt終了日付.Size = new System.Drawing.Size(144, 23);
            this.dt終了日付.TabIndex = 5;
            // 
            // lab頁番号
            // 
            this.lab頁番号.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab頁番号.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab頁番号.Location = new System.Drawing.Point(686, 166);
            this.lab頁番号.Name = "lab頁番号";
            this.lab頁番号.Size = new System.Drawing.Size(48, 14);
            this.lab頁番号.TabIndex = 70;
            this.lab頁番号.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn次頁
            // 
            this.btn次頁.BackColor = System.Drawing.Color.SteelBlue;
            this.btn次頁.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn次頁.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn次頁.ForeColor = System.Drawing.Color.White;
            this.btn次頁.Location = new System.Drawing.Point(734, 162);
            this.btn次頁.Name = "btn次頁";
            this.btn次頁.Size = new System.Drawing.Size(48, 22);
            this.btn次頁.TabIndex = 69;
            this.btn次頁.Text = "次頁";
            this.btn次頁.UseVisualStyleBackColor = false;
            // 
            // btn前頁
            // 
            this.btn前頁.BackColor = System.Drawing.Color.SteelBlue;
            this.btn前頁.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn前頁.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn前頁.ForeColor = System.Drawing.Color.White;
            this.btn前頁.Location = new System.Drawing.Point(638, 162);
            this.btn前頁.Name = "btn前頁";
            this.btn前頁.Size = new System.Drawing.Size(48, 22);
            this.btn前頁.TabIndex = 68;
            this.btn前頁.Text = "前頁";
            this.btn前頁.UseVisualStyleBackColor = false;
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
            this.labログイン集荷店.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labログイン集荷店.ForeColor = System.Drawing.Color.LimeGreen;
            this.labログイン集荷店.Location = new System.Drawing.Point(694, 8);
            this.labログイン集荷店.Name = "labログイン集荷店";
            this.labログイン集荷店.Size = new System.Drawing.Size(48, 14);
            this.labログイン集荷店.TabIndex = 13;
            this.labログイン集荷店.Text = "ログイン";
            // 
            // texログイン集荷店
            // 
            this.texログイン集荷店.BackColor = System.Drawing.Color.PaleGreen;
            this.texログイン集荷店.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.texログイン集荷店.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.lab利用部門.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.tex利用部門.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.panel7.Controls.Add(this.lab日時);
            this.panel7.Controls.Add(this.lab出荷照会タイトル);
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(792, 26);
            this.panel7.TabIndex = 13;
            // 
            // lab日時
            // 
            this.lab日時.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab日時.ForeColor = System.Drawing.Color.White;
            this.lab日時.Location = new System.Drawing.Point(674, 8);
            this.lab日時.Name = "lab日時";
            this.lab日時.Size = new System.Drawing.Size(112, 14);
            this.lab日時.TabIndex = 1;
            this.lab日時.Text = "2005/xx/xx 12:00:00";
            // 
            // lab出荷照会タイトル
            // 
            this.lab出荷照会タイトル.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab出荷照会タイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab出荷照会タイトル.ForeColor = System.Drawing.Color.White;
            this.lab出荷照会タイトル.Location = new System.Drawing.Point(12, 2);
            this.lab出荷照会タイトル.Name = "lab出荷照会タイトル";
            this.lab出荷照会タイトル.Size = new System.Drawing.Size(264, 24);
            this.lab出荷照会タイトル.TabIndex = 0;
            this.lab出荷照会タイトル.Text = "出荷照会";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.PaleGreen;
            this.panel8.Controls.Add(this.btn複写);
            this.panel8.Controls.Add(this.btnＣＳＶ出力);
            this.panel8.Controls.Add(this.btn雛型登録);
            this.panel8.Controls.Add(this.btn一括削除);
            this.panel8.Controls.Add(this.btn出荷登録);
            this.panel8.Controls.Add(this.btn再発行);
            this.panel8.Controls.Add(this.texメッセージ);
            this.panel8.Controls.Add(this.btn閉じる);
            this.panel8.Location = new System.Drawing.Point(0, 516);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(792, 58);
            this.panel8.TabIndex = 2;
            // 
            // btn複写
            // 
            this.btn複写.ForeColor = System.Drawing.Color.Blue;
            this.btn複写.Location = new System.Drawing.Point(418, 6);
            this.btn複写.Name = "btn複写";
            this.btn複写.Size = new System.Drawing.Size(60, 48);
            this.btn複写.TabIndex = 6;
            this.btn複写.Text = "複写";
            this.btn複写.Click += new System.EventHandler(this.btn複写_Click);
            // 
            // btnＣＳＶ出力
            // 
            this.btnＣＳＶ出力.ForeColor = System.Drawing.Color.Blue;
            this.btnＣＳＶ出力.Location = new System.Drawing.Point(352, 6);
            this.btnＣＳＶ出力.Name = "btnＣＳＶ出力";
            this.btnＣＳＶ出力.Size = new System.Drawing.Size(60, 48);
            this.btnＣＳＶ出力.TabIndex = 5;
            this.btnＣＳＶ出力.Text = "ＣＳＶ　　出力";
            this.btnＣＳＶ出力.Click += new System.EventHandler(this.btnＣＳＶ出力_Click);
            // 
            // btn雛型登録
            // 
            this.btn雛型登録.ForeColor = System.Drawing.Color.Blue;
            this.btn雛型登録.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn雛型登録.Location = new System.Drawing.Point(286, 6);
            this.btn雛型登録.Name = "btn雛型登録";
            this.btn雛型登録.Size = new System.Drawing.Size(60, 48);
            this.btn雛型登録.TabIndex = 4;
            this.btn雛型登録.Text = "ライブラリ　登録";
            this.btn雛型登録.Click += new System.EventHandler(this.btn雛型登録_Click);
            // 
            // btn一括削除
            // 
            this.btn一括削除.BackColor = System.Drawing.Color.PaleGreen;
            this.btn一括削除.ForeColor = System.Drawing.Color.Blue;
            this.btn一括削除.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn一括削除.Location = new System.Drawing.Point(220, 6);
            this.btn一括削除.Name = "btn一括削除";
            this.btn一括削除.Size = new System.Drawing.Size(60, 48);
            this.btn一括削除.TabIndex = 3;
            this.btn一括削除.Text = "削除";
            this.btn一括削除.UseVisualStyleBackColor = false;
            this.btn一括削除.Click += new System.EventHandler(this.btn一括削除_Click);
            // 
            // btn出荷登録
            // 
            this.btn出荷登録.ForeColor = System.Drawing.Color.Blue;
            this.btn出荷登録.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn出荷登録.Location = new System.Drawing.Point(154, 6);
            this.btn出荷登録.Name = "btn出荷登録";
            this.btn出荷登録.Size = new System.Drawing.Size(60, 48);
            this.btn出荷登録.TabIndex = 2;
            this.btn出荷登録.Text = "修正";
            this.btn出荷登録.Click += new System.EventHandler(this.btn出荷登録_Click);
            // 
            // btn再発行
            // 
            this.btn再発行.ForeColor = System.Drawing.Color.Blue;
            this.btn再発行.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn再発行.Location = new System.Drawing.Point(88, 6);
            this.btn再発行.Name = "btn再発行";
            this.btn再発行.Size = new System.Drawing.Size(60, 48);
            this.btn再発行.TabIndex = 1;
            this.btn再発行.Text = "ラベル　　印刷";
            this.btn再発行.Click += new System.EventHandler(this.btn再発行_Click);
            // 
            // texメッセージ
            // 
            this.texメッセージ.BackColor = System.Drawing.Color.PaleGreen;
            this.texメッセージ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.texメッセージ.ForeColor = System.Drawing.Color.Red;
            this.texメッセージ.Location = new System.Drawing.Point(478, 4);
            this.texメッセージ.Multiline = true;
            this.texメッセージ.Name = "texメッセージ";
            this.texメッセージ.ReadOnly = true;
            this.texメッセージ.Size = new System.Drawing.Size(310, 50);
            this.texメッセージ.TabIndex = 1;
            this.texメッセージ.TabStop = false;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.ForeColor = System.Drawing.Color.Green;
            this.groupBox1.Location = new System.Drawing.Point(38, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Location = new System.Drawing.Point(16, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(768, 324);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(638, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 28);
            this.label4.TabIndex = 71;
            this.label4.Text = "※過去４５日間の出荷データを照会可能です。";
            // 
            // 出荷照会
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(792, 580);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lab頁番号);
            this.Controls.Add(this.btn次頁);
            this.Controls.Add(this.btn前頁);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 607);
            this.Name = "出荷照会";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "is-2 出荷照会";
            this.Closed += new System.EventHandler(this.出荷照会_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Onエンター移動);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Onエンターキャンセル);
            ((System.ComponentModel.ISupportInitialize)(this.ds送り状)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGT出荷一覧)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
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
			// コンボの初期値設定
			cmb出荷日.SelectedIndex = 0;
			cmb状態.Items.Clear();
			cmb状態.Items.AddRange(gsa状態名);
			cmb状態.SelectedIndex = 0;

			// 出荷日の初期設定（当日）
			部門出荷日情報更新();
			dt開始日付.Value   = gdt出荷日;
			dt終了日付.Value   = gdt出荷日;

// ADD 2005.05.23 東都）小童谷 項目の初期化 START
			項目初期化();
// ADD 2005.05.23 東都）小童谷 項目の初期化 END

			// 端末設定でプリンタを使用できない設定の場合、印刷ボタン使用不可
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//			if(gsプリンタＦＧ != "1")
			if(gsプリンタＦＧ != "1" || gb自動出力ＯＮ)
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
			{
// MOD 2005.06.03 東都）小童谷 消す START
//				btn再発行.Enabled = false;
				btn再発行.Visible = false;
			}
			else
			{
//				btn再発行.Enabled = true;
				btn再発行.Visible = true;
// MOD 2005.06.03 東都）小童谷 消す END
			}

// MOD 2006.07.25 東都）山本 一覧に運賃と保険料の項目を追加 START
//			axGT出荷一覧.Cols = 14;
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 START
//			axGT出荷一覧.Cols = 16;
// MOD 2008.10.29 東都）高木 請求先情報を追加 START
//			axGT出荷一覧.Cols = 18;
// MOD 2010.11.12 東都）高木 未発行データを削除可能にする START
//			axGT出荷一覧.Cols = 21;
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//			axGT出荷一覧.Cols = 23;
			axGT出荷一覧.Cols = 24;
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
// MOD 2010.11.12 東都）高木 未発行データを削除可能にする END
// MOD 2008.10.29 東都）高木 請求先情報を追加 END
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 END
// MOD 2006.07.25 東都）山本 一覧に運賃と保険料の項目を追加 END
			axGT出荷一覧.Rows = 10;
			axGT出荷一覧.ColSep = "|";

// MOD 2010.11.12 東都）高木 未発行データを削除可能にする START
//// MOD 2006.07.25 東都）山本 一覧に運賃と保険料の項目を追加 START
////			axGT出荷一覧.set_RowsText(0, "|出荷日|お届け先|個数|重量|輸送商品／記事・品名|送り状番号|指定日|輸送状況|登録日|お客様番号|ジャーナルＮＯ|日|出日|登録者|");
////			axGT出荷一覧.ColsWidth =    "0|3.5|15|3|3.5|12|7|4.5|5|3.5|15|0|0|0|0|";
////			axGT出荷一覧.ColsAlignHorz = "1|1|0|2|2|0|0|1|1|1|0|0|0|0|0|";
//
////			axGT出荷一覧.set_RowsText(0, "|出荷日|お届け先|個数|重量|輸送商品／記事・品名|送り状番号|指定日|輸送状況|登録日|お客様番号|ジャーナルＮＯ|日|出日|登録者|保険料（万円）|運賃（万円）|");
////			axGT出荷一覧.ColsWidth =    "0|4|20|5|5.5|12|7|6|6.5|5|16.9|0|0|0|0|6|6|";
////			axGT出荷一覧.ColsAlignHorz = "1|1|0|2|2|0|0|1|1|1|0|0|0|0|0|2|2|";
//// MOD 2007.02.08 東都）高木 一覧表示項目の変更 START
////			axGT出荷一覧.set_RowsText(0, "|出荷日|お届け先|個数|重量|保険料（万円）|運賃（万円）|輸送商品／記事・品名|送り状番号|指定日|輸送状況|登録日|お客様番号|ジャーナルＮＯ|日|出日|登録者|");
////			axGT出荷一覧.ColsWidth =    "0|4|17|4|4.5|6|6|12|7|6|6.5|5|16.9|0|0|0|0|";
////			axGT出荷一覧.ColsAlignHorz = "1|1|0|2|2|2|2|0|0|1|1|1|0|0|0|0|0|";
//			axGT出荷一覧.set_RowsText(0, "||ﾗﾍﾞﾙ|出荷日|お届け先|個数|重量|送り状番号|お客様番号|指定日|輸送状況|輸送商品／記事・品名|運賃|保険料|登録日|ジャーナルＮＯ|日|出日|登録者|");
//// MOD 2008.10.29 東都）高木 請求先情報を追加 START
////			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|3|3.4|6.5|8.5|5.3|4.6|13.0|6|6|5|0|0|0|0|";
//// MOD 2010.10.01 東都）高木 お客様番号１６桁化 START
////			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|3|3.4|6.5|8.5|5.3|4.6|13.0|6|6|5|0|0|0|0|0|0|0|";
//			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|2.6|3|6.0|9.8|5.3|4.6|13.0|6|6|4.2|0|0|0|0|0|0|0|";
//// MOD 2010.10.01 東都）高木 お客様番号１６桁化 END
//// MOD 2008.10.29 東都）高木 請求先情報を追加 END
//			axGT出荷一覧.ColsAlignHorz = "1|1|1|1|0|2|2|0|0|1|1|0|2|2|1|0|0|0|0|";
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//			axGT出荷一覧.set_RowsText(0, "||ﾗﾍﾞﾙ|出荷日|お届け先|個数|重量|送り状番号|お客様番号|指定日|輸送状況|"
//										+"輸送商品／記事・品名|運賃|保険料|登録日|"
//										+"ジャーナルＮＯ|日|出日|登録者||||||");
//			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|2.6|3|6.0|9.8|5.3|4.6|"
//										+"13.0|6|6|4.2|"
//										+"0|0|0|0|0|0|0|0|0|";
//			axGT出荷一覧.ColsAlignHorz = "1|1|1|1|0|2|2|0|0|1|1|"
//										+"0|2|2|1|"
//										+"0|0|0|0|0|0|0|0|0|";
			axGT出荷一覧.set_RowsText(0, "||ﾗﾍﾞﾙ|出荷日|お届け先|個数|重量|送り状番号|お客様番号|指定日|輸送状況|"
										+"配完日付・時刻|輸送商品／記事・品名|運賃|保険料|登録日|"
										+"ジャーナルＮＯ|日|出日|登録者||||||");
			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|2.6|3|6.0|9.8|5.3|4.6|"
										+"8|12.0|5.5|5.5|4.2|"
										+"0|0|0|0|0|0|0|0|0|";
			axGT出荷一覧.ColsAlignHorz = "1|1|1|1|0|2|2|0|0|1|1|"
										+"1|0|2|2|1|"
										+"0|0|0|0|0|0|0|0|0|";
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
// MOD 2010.11.12 東都）高木 未発行データを削除可能にする END

// MOD 2007.02.08 東都）高木 一覧表示項目の変更 END
// MOD 2006.07.25 東都）山本 一覧に運賃と保険料の項目を追加 END

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
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//				axGT出荷一覧.set_CelAlignVert(i,11,3);
				//輸送商品／記事・品名
				axGT出荷一覧.set_CelAlignVert(i,12,3);
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 END
			}

//			btn前頁.Enabled = false;
//			btn次頁.Enabled = false;
//			lab頁番号.Text = "";
			btn前頁.Visible = false;
			btn次頁.Visible = false;
			lab頁番号.Visible = false;
		}

// ADD 2005.05.23 東都）小童谷 項目の初期化 START
		private void 項目初期化()
		{
			tex届け先コード.Text = "";
			tex届け先名.Text     = "";
			tex依頼主コード.Text = "";
			tex依頼主名.Text     = "";
// MOD 2009.11.04 東都）高木 検索条件に送り状番号とお客様番号の項目を追加 START
			tex送り状番号開始.Text = "";
			tex送り状番号終了.Text = "";
			texお客様番号開始.Text = "";
			texお客様番号終了.Text = "";
// MOD 2009.11.04 東都）高木 検索条件に送り状番号とお客様番号の項目を追加 END
			tex登録件数.Text     = "";
			tex個数合計.Text     = "";
			tex重量合計.Text     = "";
			texメッセージ.Text   = "";
			axGT出荷一覧.Clear();
// ADD 2007.02.08 東都）高木 一覧表示項目の変更 START
// MOD 2008.10.29 東都）高木 請求先情報を追加 START
//			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|3|3.4|6.5|8.5|5.3|4.6|13.0|6|6|5|0|0|0|0|";
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 START
//			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|3|3.4|6.5|8.5|5.3|4.6|13.0|6|6|5|0|0|0|0|0|0|0|";
// MOD 2010.11.12 東都）高木 未発行データを削除可能にする START
//			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|2.6|3|6.0|9.8|5.3|4.6|13.0|6|6|4.2|0|0|0|0|0|0|0|";
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|2.6|3|6.0|9.8|5.3|4.6|"
//										+"13.0|6|6|4.2|"
//										+"0|0|0|0|0|0|0|0|0|";
			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|2.6|3|6.0|9.8|5.3|4.6|"
										+"8|12.0|5.5|5.5|4.2|"
										+"0|0|0|0|0|0|0|0|0|";
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
// MOD 2010.11.12 東都）高木 未発行データを削除可能にする END
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 END
// MOD 2008.10.29 東都）高木 請求先情報を追加 END
// ADD 2007.02.08 東都）高木 一覧表示項目の変更 END
			axGT出荷一覧.CaretRow = 1;
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 START
			axGT出荷一覧.CaretCol = 2;
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 END
			axGT出荷一覧_CurPlaceChanged(null,null);
		}
// ADD 2005.05.23 東都）小童谷 項目の初期化 END

		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btn届け先検索_Click(object sender, System.EventArgs e)
		{
			tex届け先コード.Text = tex届け先コード.Text.Trim();
			if(!半角チェック(tex届け先コード,"届け先コード")) return;

// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			お届け先検索 画面 = new お届け先検索();
//			画面.Left = this.Left + 404;
//			画面.Top = this.Top;

//			画面.sTcode = tex届け先コード.Text;
//			画面.ShowDialog();

//			s届け先ＣＤ = 画面.sTcode;
//			s届け先名   = 画面.sTname;
			if (g届先検索 == null)	 g届先検索 = new お届け先検索();
			g届先検索.Left = this.Left;
			g届先検索.Top = this.Top;

// MOD 2005.06.02 東都）小童谷 値の引継ぎなし START
//			g届先検索.sTcode = tex届け先コード.Text;
			g届先検索.sTcode = "";
// MOD 2005.06.02 東都）小童谷 値の引継ぎなし END
			g届先検索.ShowDialog();

			s届け先ＣＤ = g届先検索.sTcode;
			s届け先名   = g届先検索.sTname;
// MOD 2005.05.24 東都）小童谷 画面高速化 END
			if(s届け先ＣＤ.Length > 0)
			{
				tex届け先コード.Text = s届け先ＣＤ;
				tex届け先名.Text = s届け先名;
				tex依頼主コード.Focus();
//				届け先検索();
			}
			else
				tex届け先コード.Focus();
		}

		private void btn依頼主検索_Click(object sender, System.EventArgs e)
		{
			tex依頼主コード.Text = tex依頼主コード.Text.Trim();
			if(!半角チェック(tex依頼主コード,"依頼主コード")) return;

// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			ご依頼主検索 画面 = new ご依頼主検索();
//			画面.Left = this.Left + 404;
//			画面.Top = this.Top;

//			画面.sIcode = tex依頼主コード.Text.Trim();
//			画面.ShowDialog();

//			s依頼主ＣＤ = 画面.sIcode;
//			s依頼主名   = 画面.sIname;
			if (g依頼検索 == null)	 g依頼検索 = new ご依頼主検索();
			g依頼検索.Left = this.Left;
			g依頼検索.Top = this.Top;

// MOD 2005.06.02 東都）小童谷 値の引継ぎなし START
//			g依頼検索.sIcode = tex依頼主コード.Text.Trim();
			g依頼検索.sIcode = "";
// MOD 2005.06.02 東都）小童谷 値の引継ぎなし END
			g依頼検索.ShowDialog();

			s依頼主ＣＤ = g依頼検索.sIcode;
			s依頼主名   = g依頼検索.sIname;
// MOD 2005.05.24 東都）小童谷 画面高速化 END
			if(s依頼主ＣＤ.Length > 0)
			{
				tex依頼主コード.Text = s依頼主ＣＤ;
				tex依頼主名.Text     = s依頼主名;
				cmb出荷日.Focus();
//				依頼主検索();
			}
			else
				tex依頼主コード.Focus();
		}

		private void btn雛型登録_Click(object sender, System.EventArgs e)
		{
			if(axGT出荷一覧.SelStartRow != axGT出荷一覧.SelEndRow)
			{
				MessageBox.Show("複数のデータを選択した状態では実行できません。\r\n１件のみ選択して実行してください。","確認",MessageBoxButtons.OK );
				return;
			}
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 START
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 START
////			if(axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,12).Trim().Length == 0)
//			if(axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,14).Trim().Length == 0)
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 END
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//			//登録日チェック
//			if(axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,16).Trim().Length == 0)
			//登録日チェック
			if(axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,17).Trim().Length == 0)
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 END
					return;

// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			雛型登録 画面 = new 雛型登録();
//			画面.Left = this.Left;
//			画面.Top = this.Top;
//			画面.s登録日         = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,12);
//			画面.sジャーナルＮＯ = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,11);
//			this.Visible = false;
//			画面.ShowDialog();
			if (g雛型登録 == null)	 g雛型登録 = new 雛型登録();
			g雛型登録.Left = this.Left;
			g雛型登録.Top = this.Top;
			g雛型登録.s雛型名称 = "";
			g雛型登録.i雛型ＮＯ = 0;
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 START
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 START
////			g雛型登録.s登録日         = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,12);
////			g雛型登録.sジャーナルＮＯ = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,11);
//			g雛型登録.s登録日         = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,14);
//			g雛型登録.sジャーナルＮＯ = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,13);
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 END
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//			//登録日、ジャーナルＮＯ
//			g雛型登録.s登録日         = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,16);
//			g雛型登録.sジャーナルＮＯ = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,15);
			//登録日、ジャーナルＮＯ
			g雛型登録.s登録日         = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,17);
			g雛型登録.sジャーナルＮＯ = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,16);
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 END
			this.Visible = false;
			g雛型登録.ShowDialog();
// MOD 2005.05.24 東都）小童谷 画面高速化 END
			this.Visible = true;
			axGT出荷一覧.Focus();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

		private void btn出荷登録_Click(object sender, System.EventArgs e)
		{
			if(axGT出荷一覧.SelStartRow != axGT出荷一覧.SelEndRow)
			{
				MessageBox.Show("複数のデータを選択した状態では実行できません。\r\n１件のみ選択して実行してください。","確認",MessageBoxButtons.OK );
				return;
			}
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 START
			short n開始 = axGT出荷一覧.SelStartRow;
			short n終了 = axGT出荷一覧.SelEndRow;
			if(n開始 > n終了){
				n開始 = axGT出荷一覧.SelEndRow;
				n終了 = axGT出荷一覧.SelStartRow;
			}
			short n表示開始 = axGT出荷一覧.TopRow;
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//			string s開始登録日         = axGT出荷一覧.get_CelText(n開始,16).Trim();
//			string s開始ジャーナルＮＯ = axGT出荷一覧.get_CelText(n開始,15).Trim();
			string s開始登録日         = axGT出荷一覧.get_CelText(n開始,17).Trim();
			string s開始ジャーナルＮＯ = axGT出荷一覧.get_CelText(n開始,16).Trim();
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
//保留：間の行のチェック
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//			string s終了登録日         = axGT出荷一覧.get_CelText(n終了,16).Trim();
//			string s終了ジャーナルＮＯ = axGT出荷一覧.get_CelText(n終了,15).Trim();
			string s終了登録日         = axGT出荷一覧.get_CelText(n終了,17).Trim();
			string s終了ジャーナルＮＯ = axGT出荷一覧.get_CelText(n終了,16).Trim();
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
			string s次行登録日         = "";
			string s次行ジャーナルＮＯ = "";
			short n次行 = (short)(n終了 + 1);
			if(n次行 <= axGT出荷一覧.Rows){
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//				s次行登録日         = axGT出荷一覧.get_CelText(n次行,16).Trim();
//				s次行ジャーナルＮＯ = axGT出荷一覧.get_CelText(n次行,15).Trim();
				s次行登録日         = axGT出荷一覧.get_CelText(n次行,17).Trim();
				s次行ジャーナルＮＯ = axGT出荷一覧.get_CelText(n次行,16).Trim();
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
			}
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 END

// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			出荷登録 画面 = new 出荷登録();
//			画面.Left = this.Left;
//			画面.Top = this.Top;

//			画面.s登録日 = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,12);
//			画面.sジャーナルＮＯ = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,11).Trim();
//			画面.s登録者ＣＤ = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,14).Trim();
//			if(画面.sジャーナルＮＯ.Length > 0)
			if (g出荷登録 == null)	 g出荷登録 = new 出荷登録();
			g出荷登録.Left = this.Left;
			g出荷登録.Top = this.Top;

// MOD 2007.02.08 東都）高木 一覧表示項目の変更 START
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 START
////			g出荷登録.s登録日 = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,12);
////			g出荷登録.sジャーナルＮＯ = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,11).Trim();
////			g出荷登録.s登録者ＣＤ = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,14).Trim();
//			g出荷登録.s登録日 = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,14);
//			g出荷登録.sジャーナルＮＯ = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,13).Trim();
//			g出荷登録.s登録者ＣＤ = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,16).Trim();
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 END
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//			//登録日、ジャーナルＮＯ、登録者
//			g出荷登録.s登録日 = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,16);
//			g出荷登録.sジャーナルＮＯ = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,15).Trim();
//			g出荷登録.s登録者ＣＤ = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,18).Trim();
			//登録日、ジャーナルＮＯ、登録者
			g出荷登録.s登録日 = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,17);
			g出荷登録.sジャーナルＮＯ = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,16).Trim();
			g出荷登録.s登録者ＣＤ = axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,19).Trim();
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 END
			if(g出荷登録.sジャーナルＮＯ.Length > 0)
			{
//				画面.s処理ＦＧ = "U";
				g出荷登録.s処理ＦＧ = "U";
				this.Visible = false;
//				画面.ShowDialog();
				g出荷登録.ShowDialog();
				this.Visible = true;
				btn出荷検索_Click(sender, e);
				if(texメッセージ.Text.Trim().Length == 4)
					texメッセージ.Text = "";
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 START
				一覧カーソル移動(n開始, n終了, n表示開始
								, s開始登録日, s開始ジャーナルＮＯ
								, s終了登録日, s終了ジャーナルＮＯ
								, s次行登録日, s次行ジャーナルＮＯ);
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 END
			}
			else
			{
// MOD 2006.06.29 東都）山本 出荷照会にてエントリーボタン変更対応 START
				MessageBox.Show("データが選択されていません\r\n","確認",MessageBoxButtons.OK );
				return;
/*
//				画面.s処理ＦＧ = "I";
				g出荷登録.s処理ＦＧ = "I";
				this.Visible = false;
//				画面.ShowDialog();
				g出荷登録.ShowDialog();
				this.Visible = true;
*/
// MOD 2006.06.29 東都）山本 出荷照会にてエントリーボタン変更対応 END
			}
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 START
//// MOD 2005.05.24 東都）小童谷 画面高速化 END
//			axGT出荷一覧.CaretRow = 1;
//// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 START
//			axGT出荷一覧.CaretCol = 2;
//// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 END
//			axGT出荷一覧_CurPlaceChanged(sender,null);
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 END
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
					axGT出荷一覧.set_CelForeColor(nCnt,0,0);
					axGT出荷一覧.set_CelBackColor(nCnt,0,0xFFFFFF);
				}
			}
// MOD 2010.02.25 東都）高木 複写機能の追加 START
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
// MOD 2010.02.25 東都）高木 複写機能の追加 END
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
// MOD 2010.02.25 東都）高木 複写機能の追加 START
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
// MOD 2010.02.25 東都）高木 複写機能の追加 END

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

		private void btn出荷検索_Click(object sender, System.EventArgs e)
		{
			if (dt開始日付.Value > dt終了日付.Value)
			{
				MessageBox.Show("日付の範囲が正しく入力されていません","入力チェック",MessageBoxButtons.OK );
				dt開始日付.Focus();
				return;
			}

			tex登録件数.Text = "";
			tex個数合計.Text = "";
			tex重量合計.Text = "";
			texメッセージ.Text = "検索中．．．";
			axGT出荷一覧.Clear();
// ADD 2007.02.08 東都）高木 一覧表示項目の変更 START
// MOD 2008.10.29 東都）高木 請求先情報を追加 START
//			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|3|3.4|6.5|8.5|5.3|4.6|13.0|6|6|5|0|0|0|0|";
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 START
//			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|3|3.4|6.5|8.5|5.3|4.6|13.0|6|6|5|0|0|0|0|0|0|0|";
// MOD 2010.11.12 東都）高木 未発行データを削除可能にする START
//			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|2.6|3|6.0|9.8|5.3|4.6|13.0|6|6|4.2|0|0|0|0|0|0|0|";
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|2.6|3|6.0|9.8|5.3|4.6|"
//										+"13.0|6|6|4.2|"
//										+"0|0|0|0|0|0|0|0|0|";
			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|2.6|3|6.0|9.8|5.3|4.6|"
										+"8|12.0|5.5|5.5|4.2|"
										+"0|0|0|0|0|0|0|0|0|";
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
// MOD 2010.11.12 東都）高木 未発行データを削除可能にする END
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 END
// MOD 2008.10.29 東都）高木 請求先情報を追加 END
// ADD 2007.02.08 東都）高木 一覧表示項目の変更 END
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 START
			axGT出荷一覧.CaretRow = 1;
			axGT出荷一覧.CaretCol = 2;
			axGT出荷一覧_CurPlaceChanged(null,null);
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 END
// MOD 2005.07.08 東都）高木 日付変換の変更 START
//			string sSday = dt開始日付.Value.ToShortDateString().Replace("/","");
//			string sEday = dt終了日付.Value.ToShortDateString().Replace("/","");
			string sSday = YYYYMMDD変換(dt開始日付.Value);
			string sEday = YYYYMMDD変換(dt終了日付.Value);
// MOD 2005.07.08 東都）高木 日付変換の変更 END

			// 空白除去
			tex届け先コード.Text = tex届け先コード.Text.Trim();
			if(tex届け先コード.Text.Length == 0)
				tex届け先名.Text = "";
			else
			{
				if(!半角チェック(tex届け先コード,"届け先コード")) return;

				texメッセージ.Text = "";
				s届け先ＣＤ = tex届け先コード.Text;
				届け先検索();
			}

			tex依頼主コード.Text = tex依頼主コード.Text.Trim();
			if(tex依頼主コード.Text.Length == 0)
				tex依頼主名.Text = "";
			else
			{
				if(!半角チェック(tex依頼主コード,"依頼主コード")) return;

				texメッセージ.Text = "";
				s依頼主ＣＤ = tex依頼主コード.Text;
				依頼主検索();
			}
// MOD 2009.11.04 東都）高木 検索条件に送り状番号とお客様番号の項目を追加 START
			tex送り状番号開始.Text = tex送り状番号開始.Text.TrimEnd();
			tex送り状番号終了.Text = tex送り状番号終了.Text.TrimEnd();
			texお客様番号開始.Text = texお客様番号開始.Text.TrimEnd();
			texお客様番号終了.Text = texお客様番号終了.Text.TrimEnd();

			if(!半角チェック(tex送り状番号開始,"送り状番号（開始）")) return;
			if(!半角チェック(tex送り状番号終了,"送り状番号（終了）")) return;
			if(!半角チェック(texお客様番号開始,"お客様番号（開始）")) return;
			if(!半角チェック(texお客様番号終了,"お客様番号（終了）")) return;
			
			if(tex送り状番号開始.Text.Length > 0){
				if(tex送り状番号開始.Text.Length != 11
// MOD 2011.03.17 東都）高木 送り状番号の桁数チェックの変更 START
				&& tex送り状番号開始.Text.Length != 4 // SSの仕様
				&& tex送り状番号開始.Text.Length != 5 // SSの仕様
// MOD 2011.03.17 東都）高木 送り状番号の桁数チェックの変更 END
				&& tex送り状番号開始.Text.Length != 13 ){
					texメッセージ.Text = "";
					MessageBox.Show("送り状番号は１１桁もしくは１３桁で入力してください"
									, "入力チェック", MessageBoxButtons.OK );
					tex送り状番号開始.Focus();
					return;
				}
			}
			if(tex送り状番号終了.Text.Length > 0){
				if(tex送り状番号終了.Text.Length != 11
// MOD 2011.03.17 東都）高木 送り状番号の桁数チェックの変更 START
				&& tex送り状番号終了.Text.Length != 4 // SSの仕様
				&& tex送り状番号終了.Text.Length != 5 // SSの仕様
// MOD 2011.03.17 東都）高木 送り状番号の桁数チェックの変更 END
				&& tex送り状番号終了.Text.Length != 13 ){
					texメッセージ.Text = "";
					MessageBox.Show("送り状番号は１１桁もしくは１３桁で入力してください"
									, "入力チェック", MessageBoxButtons.OK );
					tex送り状番号終了.Focus();
					return;
				}
			}
// MOD 2009.11.04 東都）高木 検索条件に送り状番号とお客様番号の項目を追加 END

//			string s状態 = cmb状態.SelectedIndex.ToString().Trim();
//			if(s状態.Length == 1)
//				s状態 = "0" + s状態;
			string s状態 = gsa状態ＣＤ[cmb状態.SelectedIndex];

			i現在頁数 = 1;
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				s出荷一覧 = new string[1];
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
// MOD 2009.11.04 東都）高木 検索条件に送り状番号とお客様番号の項目を追加 START
//// MOD 2006.07.25 東都）山本 一覧に運賃と保険料の項目を追加 START
////				s出荷一覧 = sv_syukka.Get_syukka(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,tex届け先コード.Text.Trim(), tex依頼主コード.Text.Trim(), cmb出荷日.SelectedIndex, sSday, sEday, s状態);
//				s出荷一覧 = sv_syukka.Get_syukka1(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,tex届け先コード.Text.Trim(), tex依頼主コード.Text.Trim(), cmb出荷日.SelectedIndex, sSday, sEday, s状態);
//// MOD 2006.07.25 東都）山本 一覧に運賃と保険料の項目を追加 END
				string[] sa検索条件 = new string[]{
								gs会員ＣＤ
								, gs部門ＣＤ
								, tex届け先コード.Text.TrimEnd()
								, tex依頼主コード.Text.TrimEnd()
								, cmb出荷日.SelectedIndex.ToString()
								, sSday
								, sEday
								, s状態
							    , tex送り状番号開始.Text.Replace("-","")
							    , tex送り状番号終了.Text.Replace("-","")
							    , texお客様番号開始.Text.TrimEnd()
							    , texお客様番号終了.Text.TrimEnd()
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
							    , "1"	//未発行印刷.csの一覧表示ずれを防止
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
				};
				s出荷一覧 = sv_syukka.Get_syukka2(gsaユーザ, sa検索条件);
// MOD 2009.11.04 東都）高木 検索条件に送り状番号とお客様番号の項目を追加 END
				texメッセージ.Text = s出荷一覧[0];
				if(s出荷一覧[0].Length == 4)
				{
					texメッセージ.Text = "";
					tex登録件数.Text = s出荷一覧[1];
					tex個数合計.Text = s出荷一覧[2];
					tex重量合計.Text = s出荷一覧[3];

//					i最大頁数 = (s出荷一覧.Length - 5) / axGT出荷一覧.Rows + 1;
//					if (i現在頁数 > i最大頁数)
//						i現在頁数 = i最大頁数;
// ADD 2005.06.16 東都）小童谷 行数初期化 START
					axGT出荷一覧.Rows = 9;
// ADD 2005.06.16 東都）小童谷 行数初期化 END
					頁情報設定();

				}
				else
				{
					if(s出荷一覧[0].Equals("該当データがありません"))
					{
						texメッセージ.Text = "";
						MessageBox.Show("該当データがありません","出荷検索",MessageBoxButtons.OK);
					}
					else
					{
						i現在頁数 = 1;
						btn前頁.Enabled = false;
						btn次頁.Enabled = false;
						lab頁番号.Text = "";
						ビープ音();
					}
					tex届け先コード.Focus();
				}
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				texメッセージ.Text = gs通信エラー;
				ビープ音();
				tex届け先コード.Focus();
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				texメッセージ.Text = "通信エラー：" + ex.Message;
				ビープ音();
				tex届け先コード.Focus();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
			axGT出荷一覧.CaretRow = 1;
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 START
			axGT出荷一覧.CaretCol = 2;
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 END
			axGT出荷一覧_CurPlaceChanged(sender,null);
		}

		private void 届け先検索()
		{
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				// 検索
				if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
				String[] sList = sv_otodoke.Get_Stodokesaki(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,s届け先ＣＤ);

				// メッセージが[登録]、[更新]の時、正常終了
				if(sList[0].Length == 2)
				{
					if(sList[15] == "U")
					{
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//						tex届け先名.Text     = sList[10].Trim();
						tex届け先名.Text     = sList[10].TrimEnd();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
						texメッセージ.Text = "";
						tex依頼主コード.Focus();
					}
					else
					{
						texメッセージ.Text = "";
						tex依頼主コード.Focus();
					}
				}
				else
				{
					// 異常終了時
					ビープ音();
					texメッセージ.Text = sList[0];
					tex届け先コード.Focus();
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

		}

		private void 依頼主検索()
		{
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				// 検索
				if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
				String[] sList = sv_goirai.Get_Sirainusi(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,s依頼主ＣＤ);

				// メッセージが[登録]、[更新]の時、正常終了
				if(sList[0].Length == 2)
				{
					if(sList[17] == "U")
					{
						tex依頼主名.Text     = sList[9];
						texメッセージ.Text = "";
						cmb出荷日.Focus();
					}
					else
					{
						texメッセージ.Text = "";
						cmb出荷日.Focus();
					}
				}
				else
				{
					// 異常終了時
					ビープ音();
					texメッセージ.Text = sList[0];
					tex依頼主コード.Focus();
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

		}

		private void tex届け先コード_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn届け先検索.Focus();
				btn届け先検索_Click(sender,e);
				e.Handled = true;
			}		

		}

		private void tex依頼主コード_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn依頼主検索.Focus();
				btn依頼主検索_Click(sender,e);
				e.Handled = true;
			}		

		}

		private void tex届け先コード_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
//				btn届け先検索.Focus();
				// メッセージのクリア
				texメッセージ.Text = "";
				tex届け先名.Text   = "";

				// 空白除去
				tex届け先コード.Text = tex届け先コード.Text.Trim();
				if(tex届け先コード.Text.Length != 0)
				{
					if(!半角チェック(tex届け先コード,"届け先コード")) return;

					texメッセージ.Text = "検索中．．．";
					s届け先ＣＤ = tex届け先コード.Text;
					届け先検索();
				}
			}
		}

		private void tex依頼主コード_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
//				btn依頼主検索.Focus();
				// メッセージのクリア
				texメッセージ.Text = "";
				tex依頼主名.Text   = "";

				// 空白除去
				tex依頼主コード.Text = tex依頼主コード.Text.Trim();
				if(tex依頼主コード.Text.Length != 0)
				{
					if(!半角チェック(tex依頼主コード,"依頼主コード")) return;

					texメッセージ.Text = "検索中．．．";
					s依頼主ＣＤ = tex依頼主コード.Text;
					依頼主検索();
				}
			}
		}

		private void btn一括削除_Click(object sender, System.EventArgs e)
		{
			int i = 0;
			short n開始;
			short n終了;
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 START
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 START
////			if(axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,12).Trim().Length == 0)
//			if(axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,14).Trim().Length == 0)
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 END
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//			//登録日チェック
//			if(axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,16).Trim().Length == 0)
			//登録日チェック
			if(axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,17).Trim().Length == 0)
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 END
				return;

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
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//			string s開始登録日         = axGT出荷一覧.get_CelText(n開始,16).Trim();
//			string s開始ジャーナルＮＯ = axGT出荷一覧.get_CelText(n開始,15).Trim();
			string s開始登録日         = axGT出荷一覧.get_CelText(n開始,17).Trim();
			string s開始ジャーナルＮＯ = axGT出荷一覧.get_CelText(n開始,16).Trim();
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
//保留：間の行のチェック
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//			string s終了登録日         = axGT出荷一覧.get_CelText(n終了,16).Trim();
//			string s終了ジャーナルＮＯ = axGT出荷一覧.get_CelText(n終了,15).Trim();
			string s終了登録日         = axGT出荷一覧.get_CelText(n終了,17).Trim();
			string s終了ジャーナルＮＯ = axGT出荷一覧.get_CelText(n終了,16).Trim();
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
			string s次行登録日         = "";
			string s次行ジャーナルＮＯ = "";
			short n次行 = (short)(n終了 + 1);
			if(n次行 <= axGT出荷一覧.Rows){
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//				s次行登録日         = axGT出荷一覧.get_CelText(n次行,16).Trim();
//				s次行ジャーナルＮＯ = axGT出荷一覧.get_CelText(n次行,15).Trim();
				s次行登録日         = axGT出荷一覧.get_CelText(n次行,17).Trim();
				s次行ジャーナルＮＯ = axGT出荷一覧.get_CelText(n次行,16).Trim();
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
			}
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 END
			int n配列数 = int.Parse(n終了.ToString()) - int.Parse(n開始.ToString()) + 1;
			string[] s登録日 = new string[n配列数];
			string[] sＮＯ   = new string[n配列数];
// MOD 2010.06.18 東都）高木 出荷データの参照・追加・更新・削除ログの追加 START
			string[] s送り状 = new string[n配列数];
// MOD 2010.06.18 東都）高木 出荷データの参照・追加・更新・削除ログの追加 END
// MOD 2010.11.12 東都）高木 未発行データを削除可能にする START
			bool b過去日付出荷済ＦＧ = false;
// MOD 2010.11.12 東都）高木 未発行データを削除可能にする END

			部門出荷日情報更新();
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 START
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 START
////			for(short nCnt = n開始 ; nCnt <= n終了 && axGT出荷一覧.get_CelText(nCnt,11) != ""; nCnt++)
//			for(short nCnt = n開始 ; nCnt <= n終了 && axGT出荷一覧.get_CelText(nCnt,13) != ""; nCnt++)
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 END
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//			//（ジャーナルＮＯが空白でなければ続行）
//			for(short nCnt = n開始 ; nCnt <= n終了 && axGT出荷一覧.get_CelText(nCnt,15) != ""; nCnt++)
			//（ジャーナルＮＯが空白でなければ続行）
			for(short nCnt = n開始 ; nCnt <= n終了 && axGT出荷一覧.get_CelText(nCnt,16) != ""; nCnt++)
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 END
			{
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 START
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 START
//// MOD 2005.07.08 東都）高木 日付変換の変更 START
////				if(gdt出荷日 <= DateTime.Parse(axGT出荷一覧.get_CelText(nCnt,13))
////				if(gdt出荷日 <= YYYYMMDD変換(axGT出荷一覧.get_CelText(nCnt,13))
//// MOD 2005.07.08 東都）高木 日付変換の変更 END
////					&& gs利用者ＣＤ == axGT出荷一覧.get_CelText(nCnt,14).Trim())
//				if(gdt出荷日 <= YYYYMMDD変換(axGT出荷一覧.get_CelText(nCnt,15))
//					&& gs利用者ＣＤ == axGT出荷一覧.get_CelText(nCnt,16).Trim())
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 END
//				{
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 START
////					sＮＯ[i]   = axGT出荷一覧.get_CelText(nCnt,11);
////					s登録日[i] = axGT出荷一覧.get_CelText(nCnt,12);
//					sＮＯ[i]   = axGT出荷一覧.get_CelText(nCnt,13);
//					s登録日[i] = axGT出荷一覧.get_CelText(nCnt,14);
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 END
//					i++;
//				}
				//出荷日、登録者チェック
// MOD 2010.11.12 東都）高木 未発行データを削除可能にする START
//				if(gdt出荷日 <= YYYYMMDD変換(axGT出荷一覧.get_CelText(nCnt,17))
//					&& gs利用者ＣＤ == axGT出荷一覧.get_CelText(nCnt,18).Trim())
//				{
				// 削除条件チェック
				// 　出荷日が当日以降もしくはラベル印刷されていないもので
				// 　かつ、ログインユーザと登録者が同じ場合には、削除可
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//				DateTime dt一覧出荷日 = YYYYMMDD変換(axGT出荷一覧.get_CelText(nCnt,17).TrimEnd());
//				string   s一覧登録者  = axGT出荷一覧.get_CelText(nCnt,18).TrimEnd();
				DateTime dt一覧出荷日 = YYYYMMDD変換(axGT出荷一覧.get_CelText(nCnt,18).TrimEnd());
				string   s一覧登録者  = axGT出荷一覧.get_CelText(nCnt,19).TrimEnd();
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
				string   s一覧送番号  = axGT出荷一覧.get_CelText(nCnt, 7).TrimEnd();
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//				string   s一覧状態    = axGT出荷一覧.get_CelText(nCnt,22).TrimEnd();
//				string   s一覧出荷Ｆ  = axGT出荷一覧.get_CelText(nCnt,23).TrimEnd();
				string   s一覧状態    = axGT出荷一覧.get_CelText(nCnt,23).TrimEnd();
				string   s一覧出荷Ｆ  = axGT出荷一覧.get_CelText(nCnt,24).TrimEnd();
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
				if((dt一覧出荷日 >= gdt出荷日 || s一覧状態 == "01")
						&& gs利用者ＣＤ == s一覧登録者){
					// 出荷日が過去日付で「出荷済」である場合
					if(dt一覧出荷日 < gdt出荷日 && s一覧送番号.Length > 0 && s一覧出荷Ｆ == "1"){
						b過去日付出荷済ＦＧ = true;
					}
// MOD 2010.11.12 東都）高木 未発行データを削除可能にする END
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//					//登録日、ジャーナルＮＯ
//					sＮＯ[i]   = axGT出荷一覧.get_CelText(nCnt,15);
//					s登録日[i] = axGT出荷一覧.get_CelText(nCnt,16);
					//登録日、ジャーナルＮＯ
					sＮＯ[i]   = axGT出荷一覧.get_CelText(nCnt,16);
					s登録日[i] = axGT出荷一覧.get_CelText(nCnt,17);
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
// MOD 2010.06.18 東都）高木 出荷データの参照・追加・更新・削除ログの追加 START
					string sWork = axGT出荷一覧.get_CelText(nCnt,7).TrimEnd();
					if(sWork.Length > 11){
						s送り状[i] = sWork.Substring(0,11);
					}
// MOD 2010.06.18 東都）高木 出荷データの参照・追加・更新・削除ログの追加 END
					i++;
				}
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 END
			}
			if(i != n配列数)
			{
//				MessageBox.Show("削除できない出荷日のデータが選択されています。\r\n選択範囲を見直してください。","削除",MessageBoxButtons.OK);
				MessageBox.Show("削除できないデータが選択されています。\r\n選択範囲を見直してください。","削除",MessageBoxButtons.OK);
				return;
			}

// MOD 2010.02.25 東都）高木 複写機能の追加 START
//			DialogResult result = MessageBox.Show("選択したデータをすべて削除しますか？","削除",MessageBoxButtons.YesNo);
			DialogResult result;
			if(n開始 == n終了){
				result = MessageBox.Show("選択したデータを削除しますか？"
										,"削除",MessageBoxButtons.YesNo);
			}else{
				result = MessageBox.Show("選択したデータをすべて削除しますか？"
										,"削除",MessageBoxButtons.YesNo);
			}
// MOD 2010.02.25 東都）高木 複写機能の追加 END
			if(result == DialogResult.Yes)
			{
// MOD 2010.11.12 東都）高木 未発行データを削除可能にする START
				if(b過去日付出荷済ＦＧ){
					result = MessageBox.Show(
						"既にラベル発行を行っていますが、　\n"
						+ "削除してよろしいですか？　\n"
						, "削除"
						, MessageBoxButtons.YesNo
						, MessageBoxIcon.Warning);
					// [Yes]以外は終了
					if(result != DialogResult.Yes){
						return;
					}
				}
// MOD 2010.11.12 東都）高木 未発行データを削除可能にする END
				String[] sDList;
				string[] sData = new string[4];

				texメッセージ.Text = "削除中．．．";
				sData[0] = gs会員ＣＤ;
				sData[1] = gs部門ＣＤ;
				sData[2] = "出荷照会";
				sData[3] = gs利用者ＣＤ;

				this.Cursor = System.Windows.Forms.Cursors.AppStarting;
				try
				{
					if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
// MOD 2010.06.18 東都）高木 出荷データの参照・追加・更新・削除ログの追加 START
//					sDList = sv_syukka.Del_ikkatu(gsaユーザ,sData,s登録日,sＮＯ);
					sDList = sv_syukka.Del_ikkatu2(gsaユーザ,sData,s登録日,sＮＯ,s送り状);
// MOD 2010.06.18 東都）高木 出荷データの参照・追加・更新・削除ログの追加 END

					// [正常終了]時、画面をクリアする
					if(sDList[0].Length == 4)
					{
						btn出荷検索_Click(sender, e);
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 START
						一覧カーソル移動(n開始, n終了, n表示開始
										, s開始登録日, s開始ジャーナルＮＯ
										, s終了登録日, s終了ジャーナルＮＯ
										, s次行登録日, s次行ジャーナルＮＯ);
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 END
					}
					else
					{
						ビープ音();
						texメッセージ.Text = sDList[0];
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
			}

		}

		private void axGT出荷一覧_KeyDownEvent(object sender, AxGTABLE32V2Lib._DGTable32Events_KeyDownEvent e)
		{
			if (e.keyCode == 13)
			{
				btn出荷登録_Click(sender, null);
			}
			if (e.keyCode == 9)
			{
				this.SelectNextControl(axGT出荷一覧, true, true, true, true);
			}
		}

		private void btn再発行_Click(object sender, System.EventArgs e)
		{
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 START
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 START
////			if(axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,12).Trim().Length == 0)
//			if(axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,14).Trim().Length == 0)
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 END
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//			//登録日チェック
//			if(axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,16).Trim().Length == 0)
			//登録日チェック
			if(axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,17).Trim().Length == 0)
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 END
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
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//			string s開始登録日         = axGT出荷一覧.get_CelText(n開始,16).Trim();
//			string s開始ジャーナルＮＯ = axGT出荷一覧.get_CelText(n開始,15).Trim();
			string s開始登録日         = axGT出荷一覧.get_CelText(n開始,17).Trim();
			string s開始ジャーナルＮＯ = axGT出荷一覧.get_CelText(n開始,16).Trim();
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
//保留：間の行のチェック
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//			string s終了登録日         = axGT出荷一覧.get_CelText(n終了,16).Trim();
//			string s終了ジャーナルＮＯ = axGT出荷一覧.get_CelText(n終了,15).Trim();
			string s終了登録日         = axGT出荷一覧.get_CelText(n終了,17).Trim();
			string s終了ジャーナルＮＯ = axGT出荷一覧.get_CelText(n終了,16).Trim();
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
			string s次行登録日         = "";
			string s次行ジャーナルＮＯ = "";
			short n次行 = (short)(n終了 + 1);
			if(n次行 <= axGT出荷一覧.Rows){
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//				s次行登録日         = axGT出荷一覧.get_CelText(n次行,16).Trim();
//				s次行ジャーナルＮＯ = axGT出荷一覧.get_CelText(n次行,15).Trim();
				s次行登録日         = axGT出荷一覧.get_CelText(n次行,17).Trim();
				s次行ジャーナルＮＯ = axGT出荷一覧.get_CelText(n次行,16).Trim();
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
			}
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 END

// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） START
//			ds送り状.Clear();
			送り状データクリア();
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） END

			for(short nCnt = n開始 ; nCnt <= n終了; nCnt++)
			{
				try
				{
					string[] sData = new string[2];
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 START
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 START
////					sData[0] = axGT出荷一覧.get_CelText(nCnt, 12);
////					sData[1] = axGT出荷一覧.get_CelText(nCnt, 11);
//					sData[0] = axGT出荷一覧.get_CelText(nCnt, 14);
//					sData[1] = axGT出荷一覧.get_CelText(nCnt, 13);
//// MOD 2006.08.10 東都）山本 保険料＆運賃追加対応 END
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//					//登録日、ジャーナルＮＯ
//					sData[0] = axGT出荷一覧.get_CelText(nCnt, 16);
//					sData[1] = axGT出荷一覧.get_CelText(nCnt, 15);
					//登録日、ジャーナルＮＯ
					sData[0] = axGT出荷一覧.get_CelText(nCnt, 17);
					sData[1] = axGT出荷一覧.get_CelText(nCnt, 16);
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 END

					送り状印刷指示(sData);
// ADD 2006.12.12 東都）小童谷 店所と部門店所が異なる場合は、印刷しない START
					if(!gb印刷)
					{
						texメッセージ.Text = "";
						Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2007.02.19 FJCS）桑田 メッセージ変更 START
//						MessageBox.Show("発店が違います。印刷できません。","送状印刷"
						MessageBox.Show("集荷店が違います。印刷できません。","送状印刷"
// MOD 2007.02.19 FJCS）桑田 メッセージ変更 END
							,MessageBoxButtons.OK);
						return;
					}
// ADD 2006.12.12 東都）小童谷 店所と部門店所が異なる場合は、印刷しない END

// ADD 2006.06.26 東都）高木 ＳＡＴＯ製プリンタ対応 START
					送り状帳票印刷();
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） START
//					ds送り状.Clear();
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） END
// ADD 2006.06.26 東都）高木 ＳＡＴＯ製プリンタ対応 END  
				}
				catch (Exception ex)
				{
					texメッセージ.Text = ex.Message;
					ビープ音();
					Cursor = System.Windows.Forms.Cursors.Default;
					return;
				}
			}
			Cursor = System.Windows.Forms.Cursors.Default;

// DEL 2006.06.26 東都）高木 ＳＡＴＯ製プリンタ対応 START
//			送り状帳票印刷();
// DEL 2006.06.26 東都）高木 ＳＡＴＯ製プリンタ対応 END  

			// 再検索
			btn出荷検索_Click(sender, e);
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 START
			一覧カーソル移動(n開始, n終了, n表示開始
							, s開始登録日, s開始ジャーナルＮＯ
							, s終了登録日, s終了ジャーナルＮＯ
							, s次行登録日, s次行ジャーナルＮＯ);
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 END

			texメッセージ.Text = "";
		}

		private void tex届け先コード_LostFocus(object sender, EventArgs e)
		{
			if(tex届け先コード.Text.Trim() == "")
				tex届け先名.Text = "";
		}

		private void tex依頼主コード_LostFocus(object sender, EventArgs e)
		{
			if(tex依頼主コード.Text.Trim() == "")
				tex依頼主名.Text = "";

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
//
			if (s出荷一覧.Length - 4 <= 9)
			{
				axGT出荷一覧.Rows = 9;
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
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//				axGT出荷一覧.set_CelAlignVert(i,11,3);
				//輸送商品／記事・品名
				axGT出荷一覧.set_CelAlignVert(i,12,3);
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
// MOD 2007.02.08 東都）高木 一覧表示項目の変更 END
			}
//
			axGT出荷一覧.Clear();
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 START
			axGT出荷一覧.CaretRow = 1;
			axGT出荷一覧.CaretCol = 2;
			axGT出荷一覧_CurPlaceChanged(null,null);
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 END

//			i開始数 = (i現在頁数 - 1) * axGT出荷一覧.Rows + 4;
//			i終了数 = i現在頁数 * axGT出荷一覧.Rows + 3;

			short s表示数 = (short)1;
//			for(short sCnt = (short)i開始数; sCnt < s出荷一覧.Length && sCnt <= i終了数 ; sCnt++)
			for(short sCnt = (short)4; sCnt < s出荷一覧.Length; sCnt++)
			{
				string sRList = s出荷一覧[sCnt].Replace("\\r\\n","\r\n");
				axGT出荷一覧.set_RowsText(s表示数, sRList);
				s表示数++;
			}
//			lab頁番号.Text = i現在頁数.ToString() + " / " + i最大頁数.ToString();
//			if (i現在頁数 == 1)
//				btn前頁.Enabled = false;
//			else
//				btn前頁.Enabled = true;
//			if (i現在頁数 == i最大頁数)
//				btn次頁.Enabled = false;
//			else
//				btn次頁.Enabled = true;
			axGT出荷一覧.Focus();
		}

		private void cmb状態_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				btn出荷検索_Click(sender,e);
			}

		}

		private void btnＣＳＶ出力_Click(object sender, System.EventArgs e)
		{
// MOD 2005.07.08 東都）高木 日付変換の変更 START
//			string sSday = dt開始日付.Value.ToShortDateString().Replace("/","");
//			string sEday = dt終了日付.Value.ToShortDateString().Replace("/","");
			string sSday = YYYYMMDD変換(dt開始日付.Value);
			string sEday = YYYYMMDD変換(dt終了日付.Value);
// MOD 2005.07.08 東都）高木 日付変換の変更 END

			// 空白除去
			tex届け先コード.Text = tex届け先コード.Text.Trim();
			if(tex届け先コード.Text.Length == 0)
				tex届け先名.Text = "";
			else
			{
				if(!半角チェック(tex届け先コード,"届け先コード")) return;

				texメッセージ.Text = "";
				s届け先ＣＤ = tex届け先コード.Text;
				届け先検索();
			}

			tex依頼主コード.Text = tex依頼主コード.Text.Trim();
			if(tex依頼主コード.Text.Length == 0)
				tex依頼主名.Text = "";
			else
			{
				if(!半角チェック(tex依頼主コード,"依頼主コード")) return;

				texメッセージ.Text = "";
				s依頼主ＣＤ = tex依頼主コード.Text;
				依頼主検索();
			}

// MOD 2011.03.17 東都）高木 送り状番号の桁数チェックの変更 START
			tex送り状番号開始.Text = tex送り状番号開始.Text.TrimEnd();
			tex送り状番号終了.Text = tex送り状番号終了.Text.TrimEnd();
			texお客様番号開始.Text = texお客様番号開始.Text.TrimEnd();
			texお客様番号終了.Text = texお客様番号終了.Text.TrimEnd();

			if(!半角チェック(tex送り状番号開始,"送り状番号（開始）")) return;
			if(!半角チェック(tex送り状番号終了,"送り状番号（終了）")) return;
			if(!半角チェック(texお客様番号開始,"お客様番号（開始）")) return;
			if(!半角チェック(texお客様番号終了,"お客様番号（終了）")) return;
			
			if(tex送り状番号開始.Text.Length > 0){
				if(tex送り状番号開始.Text.Length != 11
				&& tex送り状番号開始.Text.Length != 4 // SSの仕様
				&& tex送り状番号開始.Text.Length != 5 // SSの仕様
				&& tex送り状番号開始.Text.Length != 13 ){
					texメッセージ.Text = "";
					MessageBox.Show("送り状番号は１１桁もしくは１３桁で入力してください"
									, "入力チェック", MessageBoxButtons.OK );
					tex送り状番号開始.Focus();
					return;
				}
			}
			if(tex送り状番号終了.Text.Length > 0){
				if(tex送り状番号終了.Text.Length != 11
				&& tex送り状番号終了.Text.Length != 4 // SSの仕様
				&& tex送り状番号終了.Text.Length != 5 // SSの仕様
				&& tex送り状番号終了.Text.Length != 13 ){
					texメッセージ.Text = "";
					MessageBox.Show("送り状番号は１１桁もしくは１３桁で入力してください"
									, "入力チェック", MessageBoxButtons.OK );
					tex送り状番号終了.Focus();
					return;
				}
			}
// MOD 2011.03.17 東都）高木 送り状番号の桁数チェックの変更 END

//			string s状態 = cmb状態.SelectedIndex.ToString().Trim();
//			if(s状態.Length == 1)
//				s状態 = "0" + s状態;
			string s状態 = gsa状態ＣＤ[cmb状態.SelectedIndex];

			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				String[] sList;
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
// MOD 2009.11.04 東都）高木 検索条件に送り状番号とお客様番号の項目を追加 START
//// MOD 2007.02.20 東都）高木 ＣＳＶ出力は、旧バージョンにする START
//// MOD 2006.07.27 東都）山本 運賃と保険料項目の追加 START
//				sList = sv_syukka.Get_csvwrite(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,tex届け先コード.Text.Trim(), tex依頼主コード.Text.Trim(), cmb出荷日.SelectedIndex, sSday, sEday, s状態);
////				sList = sv_syukka.Get_csvwrite1(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,tex届け先コード.Text.Trim(), tex依頼主コード.Text.Trim(), cmb出荷日.SelectedIndex, sSday, sEday, s状態,"");
//// MOD 2006.07.27 東都）山本 運賃と保険料項目の追加 END
//// MOD 2007.02.20 東都）高木 ＣＳＶ出力は、旧バージョンにする END
				string[] sa検索条件 = new string[]{
								gs会員ＣＤ
								, gs部門ＣＤ
								, tex届け先コード.Text.TrimEnd()
								, tex依頼主コード.Text.TrimEnd()
								, cmb出荷日.SelectedIndex.ToString()
								, sSday
								, sEday
								, s状態
								, tex送り状番号開始.Text.Replace("-","")
								, tex送り状番号終了.Text.Replace("-","")
								, texお客様番号開始.Text.TrimEnd()
								, texお客様番号終了.Text.TrimEnd()
								, ""	// 請求先コード
// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）START
								, ""	// 部課コード
								, "0"	// 帳票出力形式
								, gsオプション[17]
// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）END
				};
				sList = sv_syukka.Get_csvwrite2(gsaユーザ, sa検索条件);
// MOD 2009.11.04 東都）高木 検索条件に送り状番号とお客様番号の項目を追加 END
				this.Cursor = System.Windows.Forms.Cursors.Default;

				if(sList[0].Length == 4)
				{
// ADD 2005.06.03 東都）小童谷 荷送人情報追加 START
/*					sList[0] = "\"登録日\",\"登録番号\",\"荷受人コード\",\"郵便番号\","
							 + "\"電話番号\",\"住所１\",\"住所２\",\"住所３\","
							 + "\"名前１\",\"名前２\",\"特殊計\",\"着店コード\",\"着店名\","
							 + "\"荷送人コード\",\"個数\",\"重量\","
							 + "\"指定日\",\"輸送指示１\",\"輸送指示２\","
							 + "\"品名記事１\",\"品名記事２\",\"品名記事３\",\"元着区分\","
							 + "\"保険金額\",\"お客様管理番号\",\"出荷日\","
							 + "\"請求先コード\",\"請求先部課所コード\",\"送り状番号\"";
*/
// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）START
					if(gsオプション[17].Equals("1")){
						//ＣＳＶエントリー形式
						sList[0] = ""
							+ "\"荷受人コード\",\"電話番号\","
							+ "\"住所\",\"住所２\",\"住所３\","
							+ "\"名前\",\"名前２\","
							+ "\"郵便番号\",\"特殊計\",\"着店コード\","
							+ "\"荷送人コード\","
							+ "\"個数\",\"才数\",\"重量\","
							+ "\"輸送商品１\",\"輸送商品２\","
							+ "\"品名記事１\",\"品名記事２\",\"品名記事３\","
							+ "\"配達指定日\",\"お客様管理番号\","
							+ "\"予備\","
							+ "\"元払区分\",\"保険金額\","
							+ "\"出荷日付\",\"登録日付\""
							;
// MOD 2011.07.14 東都）高木 記事行の追加 START
					}else if(gsオプション[17].Equals("2")){
						//標準形式２
						sList[0] = "\"登録日\",\"出荷日\",\"送り状番号\","
							+ "\"荷受人コード\",\"荷受人郵便番号\",\"荷受人電話番号\","
							+ "\"荷受人住所１\",\"荷受人住所２\",\"荷受人住所３\","
							+ "\"荷受人名前１\",\"荷受人名前２\",\"特殊計\",\"着店コード\",\"着店名\","
							+ "\"荷送人コード\",\"荷送人郵便番号\",\"荷送人電話番号\","
							+ "\"荷送人住所１\",\"荷送人住所２\","
							+ "\"荷送人名前１\",\"荷送人名前２\","
							+ "\"個数\",\"重量\","
							+ "\"指定日\",\"輸送商品１\",\"輸送商品２\","
							+ "\"品名記事１\",\"品名記事２\",\"品名記事３\","
							+ "\"品名記事４\",\"品名記事５\",\"品名記事６\","
							+ "\"元着区分\","
							+ "\"保険金額\",\"お客様管理番号\","
							+ "\"請求先コード\",\"請求先部課所コード\""
							;
					}else if(gsオプション[17].Equals("3")){
						//ＣＳＶエントリー形式２
						sList[0] = ""
							+ "\"荷受人コード\",\"電話番号\","
							+ "\"住所\",\"住所２\",\"住所３\","
							+ "\"名前\",\"名前２\","
							+ "\"郵便番号\",\"特殊計\",\"着店コード\","
							+ "\"荷送人コード\","
							+ "\"荷送人担当者\","
							+ "\"個数\",\"才数\",\"重量\","
							+ "\"輸送商品１\",\"輸送商品２\","
							+ "\"品名記事１\",\"品名記事２\",\"品名記事３\","
							+ "\"品名記事４\",\"品名記事５\",\"品名記事６\","
							+ "\"配達指定日\",\"必着区分\","
							+ "\"お客様管理番号\","
							+ "\"元払区分\",\"保険金額\","
							+ "\"出荷日付\",\"登録日付\""
							;
// MOD 2011.07.14 東都）高木 記事行の追加 END
					}else{
// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）END
						sList[0] = "\"登録日\",\"出荷日\",\"送り状番号\","
							+ "\"荷受人コード\",\"荷受人郵便番号\",\"荷受人電話番号\","
							+ "\"荷受人住所１\",\"荷受人住所２\",\"荷受人住所３\","
							+ "\"荷受人名前１\",\"荷受人名前２\",\"特殊計\",\"着店コード\",\"着店名\","
							+ "\"荷送人コード\",\"荷送人郵便番号\",\"荷送人電話番号\","
							+ "\"荷送人住所１\",\"荷送人住所２\","
							+ "\"荷送人名前１\",\"荷送人名前２\","
							+ "\"個数\",\"重量\","
							+ "\"指定日\",\"輸送商品１\",\"輸送商品２\","
							+ "\"品名記事１\",\"品名記事２\",\"品名記事３\",\"元着区分\","
							+ "\"保険金額\",\"お客様管理番号\","
// MOD 2007.02.20 東都）高木 ＣＳＶ出力は、旧バージョンにする START
// MOD 2006.07.27 東都）山本 運賃と保険料項目の追加 START
							+ "\"請求先コード\",\"請求先部課所コード\"";
//							+ "\"請求先コード\",\"請求先部課所コード\","
//							+ "\"運賃\"";
// MOD 2006.07.27 東都）山本 運賃と保険料項目の追加 END
// MOD 2007.02.20 東都）高木 ＣＳＶ出力は、旧バージョンにする END
// ADD 2005.06.03 東都）小童谷 荷送人情報追加 END
// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）START
					}
// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）END

					// デフォルトのフォルダをデスクトップフォルダにする
					saveFileDialog1.InitialDirectory
						= Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
					saveFileDialog1.Filter = "ＣＳＶファイル (*.csv)|*.csv";
					byte[] bSJIS;
					if(saveFileDialog1.ShowDialog(this) == DialogResult.OK)
					{
						System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
						for(int iCnt = 0; iCnt < sList.Length; iCnt++)
						{
							bSJIS = toSJIS(sList[iCnt]);
							fs.Write(bSJIS, 0 , bSJIS.Length);
						}
						fs.Close();
						texメッセージ.Text = "";
					}
				}
				else
				{
					ビープ音();
					texメッセージ.Text = sList[0];
				}
			}
// ADD 2005.07.04 東都）高木 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
				texメッセージ.Text = gs通信エラー;
			}
// ADD 2005.07.04 東都）高木 通信エラーのメッセージ修正 END
			catch(Exception ex)
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
				texメッセージ.Text = ex.Message;
			}
			tex届け先コード.Focus();

		}

// ADD 2005.05.23 東都）小童谷 フォーカス移動 START
		private void 出荷照会_Closed(object sender, System.EventArgs e)
		{
			tex届け先コード.Focus();
		}
// ADD 2005.05.23 東都）小童谷 フォーカス移動 END
// MOD 2010.02.25 東都）高木 複写機能の追加 START
		private void btn複写_Click(object sender, System.EventArgs e)
		{
			short n表示開始 = axGT出荷一覧.TopRow;
			short n開始 = axGT出荷一覧.SelStartRow;
			short n終了 = axGT出荷一覧.SelEndRow;
			//下から上に選択した場合
			if(n開始 > n終了){
				n開始 = axGT出荷一覧.SelEndRow;
				n終了 = axGT出荷一覧.SelStartRow;
			}
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//			string s開始登録日         = axGT出荷一覧.get_CelText(n開始,16).Trim();
//			string s開始ジャーナルＮＯ = axGT出荷一覧.get_CelText(n開始,15).Trim();
			string s開始登録日         = axGT出荷一覧.get_CelText(n開始,17).Trim();
			string s開始ジャーナルＮＯ = axGT出荷一覧.get_CelText(n開始,16).Trim();
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 START
//保留：間の行のチェック
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//			string s終了登録日         = axGT出荷一覧.get_CelText(n終了,16).Trim();
//			string s終了ジャーナルＮＯ = axGT出荷一覧.get_CelText(n終了,15).Trim();
			string s終了登録日         = axGT出荷一覧.get_CelText(n終了,17).Trim();
			string s終了ジャーナルＮＯ = axGT出荷一覧.get_CelText(n終了,16).Trim();
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
			string s次行登録日         = "";
			string s次行ジャーナルＮＯ = "";
			short n次行 = (short)(n終了 + 1);
			if(n次行 <= axGT出荷一覧.Rows){
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//				s次行登録日         = axGT出荷一覧.get_CelText(n次行,16).Trim();
//				s次行ジャーナルＮＯ = axGT出荷一覧.get_CelText(n次行,15).Trim();
				s次行登録日         = axGT出荷一覧.get_CelText(n次行,17).Trim();
				s次行ジャーナルＮＯ = axGT出荷一覧.get_CelText(n次行,16).Trim();
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
			}
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 END
			
//			//複数行選択の場合
//			if(n開始 != n終了){
//				MessageBox.Show("複数のデータを選択した状態では実行できません。\r\n"
//								+ "１件のみ選択して実行してください。"
//								,"確認",MessageBoxButtons.OK );
//				return;
//			}

// MOD 2016.05.24 BEVAS）松本 複写ボタン押下時の挙動修正 START
			int i複写Cnt = 0;
// MOD 2016.05.24 BEVAS）松本 複写ボタン押下時の挙動修正 END
			for(short n行 = n開始; n行 <= n終了; n行++){
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//				string s登録日         = axGT出荷一覧.get_CelText(n行,16).Trim();
//				string sジャーナルＮＯ = axGT出荷一覧.get_CelText(n行,15).Trim();
				string s登録日         = axGT出荷一覧.get_CelText(n行,17).Trim();
				string sジャーナルＮＯ = axGT出荷一覧.get_CelText(n行,16).Trim();
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END

				//登録日、sジャーナルＮＯチェック
				if(s登録日.Length == 0) return;
				if(sジャーナルＮＯ.Length == 0) return;

//他のセクションの場合には複写を許可するか？

				// カーソルを砂時計にする
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				string[] sList = {""};
				try{
					texメッセージ.Text = "参照中．．．";
					texメッセージ.Refresh();
					if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
					sList = sv_syukka.Get_Ssyukka(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,s登録日,int.Parse(sジャーナルＮＯ));
				}catch (System.Net.WebException){
					sList[0] = gs通信エラー;
				}catch (Exception ex){
					sList[0] = "通信エラー：" + ex.Message;
				}
				// カーソルをデフォルトに戻す
				Cursor = System.Windows.Forms.Cursors.Default;
				if(sList[0].Length != 4){
					texメッセージ.Text = sList[0];
					texメッセージ.Refresh();
					ビープ音();
					return;
				}

				//仕様：参照元の出荷データの更新されていてもＯＫとする

				//ご依頼主マスタ存在チェック
				texメッセージ.Text = "ご依頼主チェック中．．．";
				texメッセージ.Refresh();
				if(sList[26].TrimEnd().Length == 0){
// MOD 2010.09.03 東都）高木 ＣＳＶエントリー時の請求先エラー表記修正 START
//					texメッセージ.Text = "ご依頼主（"+ sList[14].TrimEnd()
//										+"）はマスタに存在しません。";
					texメッセージ.Text = "ご依頼主["+ sList[14].TrimEnd()
										+"]は登録されていません。";
// MOD 2010.09.03 東都）高木 ＣＳＶエントリー時の請求先エラー表記修正 END
					ビープ音();
					return;
				}
				
				//請求先存在チェック
				texメッセージ.Text = "請求先チェック中．．．";
				texメッセージ.Refresh();
				bool b請求先存在 = false;
				if(gsa請求先ＣＤ != null){
					for(int iCnt = 0 ; iCnt < gsa請求先ＣＤ.Length; iCnt++){
						if(gsa請求先ＣＤ[iCnt] == null
						 || gsa請求先部課ＣＤ[iCnt] == null){
							continue;
						}
						if(gsa請求先ＣＤ[iCnt] == sList[35]
						 && gsa請求先部課ＣＤ[iCnt] == sList[36]){
							b請求先存在 = true;
							break;
						}
					}
				}
				if(b請求先存在 == false){
// MOD 2010.09.03 東都）高木 ＣＳＶエントリー時の請求先エラー表記修正 START
//					if(sList[36].TrimEnd().Length > 0){
//						texメッセージ.Text = "請求先（"+ sList[35].TrimEnd() 
//											+"-" + sList[36].TrimEnd() 
//											+"）はマスタに存在しません。";
//					}else{
//						texメッセージ.Text = "請求先（"+ sList[35].TrimEnd() 
//											+"）はマスタに存在しません。";
//					}
					if(sList[36].TrimEnd().Length > 0){
						texメッセージ.Text = "ご依頼主の請求先["+ sList[35].TrimEnd() 
											+"-" + sList[36].TrimEnd() 
											+"]は登録されていません。";
					}else{
						texメッセージ.Text = "ご依頼主の請求先["+ sList[35].TrimEnd() 
											+"]は登録されていません。";
					}
// MOD 2010.09.03 東都）高木 ＣＳＶエントリー時の請求先エラー表記修正 END
					ビープ音();
					return;
				}

				//お届け先の郵便番号マスタ存在チェック
				texメッセージ.Text = "お届け先郵便番号チェック中．．．";
				texメッセージ.Refresh();
				string s郵便番号 = sList[12] + sList[13];
				string[] sRet = {""};
				try{
// MOD 2015.05.07 BEVAS）前田 王子運送郵便番号存在チェック対応 START
					//if(sv_address == null) sv_address = new is2address.Service1();
					//sRet = sv_address.Get_byPostcode2(gsaユーザ,s郵便番号);
					sRet = ＣＭ１４郵便番号存在チェック(s郵便番号);
// MOD 2015.05.07 BEVAS）前田 王子運送郵便番号存在チェック対応 END
				}
				catch(System.Net.WebException)
				{
					sRet[0] = gs通信エラー;
				}catch(Exception ex){
					sRet[0] = "通信エラー：" + ex.Message;
				}
				if(sRet[0].Length != 4){
					if(sRet[0].Equals("該当データがありません")){
// MOD 2010.09.03 東都）高木 ＣＳＶエントリー時の請求先エラー表記修正 START
//						sRet[0] = "お届け先の郵便番号（"+ sList[12].TrimEnd()
//								+"-" + sList[13].TrimEnd()
//								+"）はマスタに存在しません。";
						sRet[0] = "お届け先の郵便番号["+ sList[12].TrimEnd()
								+"-" + sList[13].TrimEnd()
								+"]はマスタに存在しません。";
// MOD 2010.09.03 東都）高木 ＣＳＶエントリー時の請求先エラー表記修正 END
					}
					texメッセージ.Text = sRet[0];
					ビープ音();
					return;
				}

				String[] sIUList;
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
//				string[] s出荷Ｄ = new string[42];
// MOD 2011.07.14 東都）高木 記事行の追加 START
//				string[] s出荷Ｄ = new string[43];
				string[] s出荷Ｄ = new string[46];
// MOD 2011.07.14 東都）高木 記事行の追加 END
				s出荷Ｄ[42] = gs重量入力制御;
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
// MOD 2016.05.24 BEVAS）松本 複写ボタン押下時の挙動修正 START
//				bool f出荷日変更   = false;
//				bool f指定日クリア = false;
// MOD 2016.05.24 BEVAS）松本 複写ボタン押下時の挙動修正 END
				s出荷Ｄ[0]  = gs会員ＣＤ;
				s出荷Ｄ[1]  = gs部門ＣＤ;
				//出荷日が未来の場合
				if(YYYYMMDD変換(sList[1]) >= gdt出荷日){
					s出荷Ｄ[2]  = sList[1].Replace("/","");	 //出荷日
					s出荷Ｄ[21] = sList[18].Replace("/",""); //指定日
					s出荷Ｄ[41] = sList[44];				 //指定日区分
				//出荷日が過去の場合
				}else{
					s出荷Ｄ[2]  = gs出荷日;
					//指定日をクリア
					s出荷Ｄ[21] = "0";
					s出荷Ｄ[41] = "0";

// MOD 2016.05.24 BEVAS）松本 複写ボタン押下時の挙動修正 START
//					f出荷日変更 = true;
//					//参照元データが指定日が設定されていた場合
//					if(sList[18].Trim().Length >= 8){
//						f指定日クリア = true;
//					}
// MOD 2016.05.24 BEVAS）松本 複写ボタン押下時の挙動修正 END
				}
				s出荷Ｄ[3]  = sList[2]; //お客様管理番号
				s出荷Ｄ[4]  = sList[3]; //届け先コード
				s出荷Ｄ[5]  = sList[4]; //届け先電話番号１
				s出荷Ｄ[6]  = sList[5]; //届け先電話番号２
				s出荷Ｄ[7]  = sList[6]; //届け先電話番号３
				s出荷Ｄ[8]  = sList[7]; //届け先住所１
				s出荷Ｄ[9]  = sList[8]; //届け先住所２
				s出荷Ｄ[10] = sList[9]; //届け先住所３
				s出荷Ｄ[11] = sList[10]; //届け先名前１
				s出荷Ｄ[12] = sList[11]; //届け先名前２
				s出荷Ｄ[13] = sList[12]; //届け先郵便番号１
				s出荷Ｄ[14] = sList[13]; //届け先郵便番号２
				s出荷Ｄ[15] = sList[14]; //依頼主コード
				//請求先情報
				s出荷Ｄ[16] = sList[35]; //請求先コード（サーバで再設定される）
				s出荷Ｄ[17] = sList[36]; //請求先部課コード（サーバで再設定される）
				s出荷Ｄ[18] = sList[15]; //請求先部課名（サーバで再設定される）
				s出荷Ｄ[19] = sList[16]; //個数
				s出荷Ｄ[20] = sList[17]; //才数
				//s出荷Ｄ[21]は指定日

				s出荷Ｄ[22] = sList[19]; //輸送名親
				s出荷Ｄ[23] = sList[20]; //輸送名子
				s出荷Ｄ[24] = sList[21]; //記事名１
				s出荷Ｄ[25] = sList[22]; //記事名２
				s出荷Ｄ[26] = sList[23]; //記事名３
// MOD 2011.07.14 東都）高木 記事行の追加 START
				if(sList.Length > 53){
					s出荷Ｄ[43] = sList[53]; //記事名４
					s出荷Ｄ[44] = sList[54]; //記事名５
					s出荷Ｄ[45] = sList[55]; //記事名６
				}else{
					s出荷Ｄ[43] = " ";
					s出荷Ｄ[44] = " ";
					s出荷Ｄ[45] = " ";
				}
// MOD 2011.07.14 東都）高木 記事行の追加 END
				s出荷Ｄ[27] = "1";		 //元着区分
				s出荷Ｄ[28] = sList[24]; //nUD保険金額
				s出荷Ｄ[29] = "0";		 //送り状発行済ＦＧ
				s出荷Ｄ[30] = "0";		 //出荷済ＦＧ
				s出荷Ｄ[31] = "0";		 //一括出荷ＦＧ
				s出荷Ｄ[32] = "出荷照会";
				s出荷Ｄ[33] = gs利用者ＣＤ;
				s出荷Ｄ[34] = " "; //ジャーナルＮＯ（未使用）
				s出荷Ｄ[35] = " "; //登録日（未使用）
				s出荷Ｄ[36] = " "; //更新日時（未使用）
				s出荷Ｄ[37] = sList[37]; //荷送人担当者名
				s出荷Ｄ[38] = sList[39]; //重量
				s出荷Ｄ[39] = sList[41]; //輸送商品親コード
				s出荷Ｄ[40] = sList[42]; //輸送商品子コード
				//s出荷Ｄ[41]は指定日区分
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//保留
//				if(!gsオプション[18].Equals("1")){
//					s出荷Ｄ[8]  = sList[7].Trim(); //届け先住所１
//					s出荷Ｄ[9]  = sList[8].Trim(); //届け先住所２
//					s出荷Ｄ[10] = sList[9].Trim(); //届け先住所３
//					s出荷Ｄ[11] = sList[10].Trim(); //届け先名前１
//					s出荷Ｄ[12] = sList[11].Trim(); //届け先名前２
//					s出荷Ｄ[24] = sList[21].Trim(); //記事名１
//					s出荷Ｄ[25] = sList[22].Trim(); //記事名２
//					s出荷Ｄ[26] = sList[23].Trim(); //記事名３
//				}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END

				for(int iCnt = 0 ; iCnt < s出荷Ｄ.Length; iCnt++ ){
					if( s出荷Ｄ[iCnt] == null 
						|| s出荷Ｄ[iCnt].Length == 0 ) s出荷Ｄ[iCnt] = " ";
				}

				// カーソルを砂時計にする
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				sIUList = new string[]{""};
				try{
					texメッセージ.Text = "複写中．．．";
					texメッセージ.Refresh();
// ADD 2010.12.14 ACT）垣原 王子運送の対応 START
					if (gs会員ＣＤ.Substring(0,1) != "J")
					{
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END
						
						if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
						sIUList = sv_syukka.Ins_syukka(gsaユーザ,s出荷Ｄ);
// ADD 2010.12.14 ACT）垣原 王子運送の対応 START
					}
					else
					{
						if(sv_oji == null) sv_oji = new is2oji.Service1();
						sIUList = sv_oji.Ins_syukka(gsaユーザ,s出荷Ｄ);
					}
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END

				}
				catch (System.Net.WebException)
				{
					sIUList[0] = gs通信エラー;
				}catch (Exception ex){
					sIUList[0] = "通信エラー：" + ex.Message;
				}
				// カーソルをデフォルトに戻す
				Cursor = System.Windows.Forms.Cursors.Default;

				// 異常終了時
				if(sIUList[0] == "0")
				{
					texメッセージ.Text = "";
					texメッセージ.Refresh();
					ビープ音();
					MessageBox.Show("参照された出荷データの\n"
									+ "ご依頼主コードはマスタに存在しません",
									"複写",MessageBoxButtons.OK);
					return;
				}

				//出荷日エラー
				//（表示されないはずですが、出荷登録とあわせました）
				string s出荷年;
				string s出荷月;
				string s出荷日;
				if(sIUList[0] == "1")
				{
					texメッセージ.Text = "";
					texメッセージ.Refresh();
					ビープ音();
					s出荷年 = sIUList[1].Substring(0,4);
					s出荷月 = sIUList[1].Substring(4,2);
					if(s出荷月.Substring(0,1) == "0") s出荷月 = " " + s出荷月.Substring(1,1);
					s出荷日 = sIUList[1].Substring(6,2);
					if(s出荷日.Substring(0,1) == "0") s出荷日 = " " + s出荷日.Substring(1,1);
					s出荷日 = s出荷月 + "月" + s出荷日 + "日";
					MessageBox.Show("出荷日は、" + s出荷日 + "以降を入力してください。",
									"複写",MessageBoxButtons.OK);
					return;
				}

				// [正常終了]時
				if(sIUList[0].Length == 4){
					texメッセージ.Text = "";
// MOD 2016.05.24 BEVAS）松本 複写ボタン押下時の挙動修正 START
//					s出荷日 = s出荷Ｄ[2].Substring(0,4)
//							+ "/" + s出荷Ｄ[2].Substring(4,2)
//							+ "/" + s出荷Ｄ[2].Substring(6,2);
//					if(f出荷日変更){
//						if(f指定日クリア){
//							MessageBox.Show("出荷日を " + s出荷日 + " に変更し、\n"
//											+ "指定日をクリアし、複写しました。"
//								, "複写", MessageBoxButtons.OK);
//						}else{
//							MessageBox.Show("出荷日を " + s出荷日 + " に変更し、複写しました。"
//								, "複写", MessageBoxButtons.OK);
//						}
//					}else{
//						MessageBox.Show("複写しました。"
//							, "複写", MessageBoxButtons.OK);
//					}
					i複写Cnt++;
// MOD 2016.05.24 BEVAS）松本 複写ボタン押下時の挙動修正 END
				}
				else
				{
					texメッセージ.Text = sIUList[0];
					ビープ音();
					return;
				}
			}
			if(texメッセージ.Text.Trim().Length == 0)
			{
// MOD 2016.05.24 BEVAS）松本 複写ボタン押下時の挙動修正 START
				if(i複写Cnt > 0)
				{
					//複写処理が全て終了したのち、メッセージを表示
					MessageBox.Show("合計 " + i複写Cnt.ToString() + " 件のデータを複写しました。", "複写", MessageBoxButtons.OK);
				}
// MOD 2016.05.24 BEVAS）松本 複写ボタン押下時の挙動修正 END
				//再検索
				btn出荷検索_Click(sender, e);
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 START
//				//選択行のクリア
//				axGT出荷一覧.CaretRow    = 1;
//				axGT出荷一覧.SelStartRow = 1;
//				axGT出荷一覧.SelEndRow   = 1;
//				axGT出荷一覧.CaretCol    = 2;
//				//選択行の設定
//				if(n開始 <= axGT出荷一覧.Rows){
//					//選択開始行の値（登録日、ジャーナルＮＯ）が同じ場合
//					if(s開始登録日 == axGT出荷一覧.get_CelText(n開始,16).Trim()
//					&& s開始ジャーナルＮＯ == axGT出荷一覧.get_CelText(n開始,15).Trim()){
//						//スクロール位置の設定
//						if(n表示開始 <= axGT出荷一覧.Rows){
//							axGT出荷一覧.TopRow = n表示開始;
//						}
//						axGT出荷一覧.CaretRow    = n開始;
//						axGT出荷一覧.SelStartRow = n開始;
//						if(n終了 <= axGT出荷一覧.Rows){
//							axGT出荷一覧.SelEndRow = n終了;
//						}else{
//							axGT出荷一覧.SelEndRow = axGT出荷一覧.Rows;
//						}
//					}
//				}
//				axGT出荷一覧_CurPlaceChanged(sender,null);
				一覧カーソル移動(n開始, n終了, n表示開始
								, s開始登録日, s開始ジャーナルＮＯ
								, s終了登録日, s終了ジャーナルＮＯ
								, s次行登録日, s次行ジャーナルＮＯ);
// MOD 2011.03.23 東都）高木 カーソル保持機能の追加 END
			}
		}
// MOD 2010.02.25 東都）高木 複写機能の追加 END
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
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//			if(s開始登録日 == axGT出荷一覧.get_CelText(n開始,16).Trim()
//			&& s開始ジャーナルＮＯ == axGT出荷一覧.get_CelText(n開始,15).Trim()
//			&& s終了登録日 == axGT出荷一覧.get_CelText(n終了,16).Trim()
//			&& s終了ジャーナルＮＯ == axGT出荷一覧.get_CelText(n終了,15).Trim()){
			if(s開始登録日 == axGT出荷一覧.get_CelText(n開始,17).Trim()
			&& s開始ジャーナルＮＯ == axGT出荷一覧.get_CelText(n開始,16).Trim()
			&& s終了登録日 == axGT出荷一覧.get_CelText(n終了,17).Trim()
			&& s終了ジャーナルＮＯ == axGT出荷一覧.get_CelText(n終了,16).Trim()){
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
				n新開始 = n開始;
				n新終了 = n終了;
			}else{
				for(short n行 = 1; n行 <= axGT出荷一覧.Rows; n行++){
					//選択開始行の値（登録日、ジャーナルＮＯ）が同じ場合
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//					if(s開始登録日 == axGT出荷一覧.get_CelText(n行,16).Trim()
//					&& s開始ジャーナルＮＯ == axGT出荷一覧.get_CelText(n行,15).Trim()){
					if(s開始登録日 == axGT出荷一覧.get_CelText(n行,17).Trim()
					&& s開始ジャーナルＮＯ == axGT出荷一覧.get_CelText(n行,16).Trim()){
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
						n新開始 = n行;
					}
					//選択終了行の値（登録日、ジャーナルＮＯ）が同じ場合
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//					if(s終了登録日 == axGT出荷一覧.get_CelText(n行,16).Trim()
//					&& s終了ジャーナルＮＯ == axGT出荷一覧.get_CelText(n行,15).Trim()){
					if(s終了登録日 == axGT出荷一覧.get_CelText(n行,17).Trim()
					&& s終了ジャーナルＮＯ == axGT出荷一覧.get_CelText(n行,16).Trim()){
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
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
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
//						if(s次行登録日 == axGT出荷一覧.get_CelText(n行,16).Trim()
//						&& s次行ジャーナルＮＯ == axGT出荷一覧.get_CelText(n行,15).Trim()){
						if(s次行登録日 == axGT出荷一覧.get_CelText(n行,17).Trim()
						&& s次行ジャーナルＮＯ == axGT出荷一覧.get_CelText(n行,16).Trim()){
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
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
