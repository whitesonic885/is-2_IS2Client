using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;

namespace IS2Client
{
	/// <summary>
	/// [出荷実績]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// MDD 2008.06.12 東都）高木 運賃が０の場合[＊]表示 
	// MOD 2008.07.09 東都）高木 未発行分を除外する 
	// MOD 2008.07.25 東都）高木 網掛けをはずす 
	//--------------------------------------------------------------------------
	// MOD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 
	// MOD 2009.04.06 東都）高木 [ご依頼主印字なし]、[運賃印字なし]の機能の追加 
	// MOD 2009.05.01 東都）高木 オプションの項目追加 
	// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 
	//--------------------------------------------------------------------------
	// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）
	// MOD 2010.10.01 東都）高木 お客様番号１６桁化 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない 
	// MOD 2011.01.25 東都）高木 「ロードに失敗」対応 
	// MOD 2011.04.13 東都）高木 重量入力不可対応 
	// MOD 2011.07.14 東都）高木 記事行の追加 
	//--------------------------------------------------------------------------
	// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加
	//--------------------------------------------------------------------------
	// MOD 2015.10.21 BEVAS）松本 支店止め出荷の場合、お届け先住所の表記を変更
	//--------------------------------------------------------------------------
	// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存
	//--------------------------------------------------------------------------
	public class 出荷実績 : 共通フォーム
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label lab出荷実績タイトル;
		private System.Windows.Forms.ComboBox cmb出荷日;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dt開始日付;
		private System.Windows.Forms.DateTimePicker dt終了日付;
		private System.Windows.Forms.Button btnＣＳＶ出力;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button btn印刷;
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.CheckBox cBox未発行分を除く;
		private System.Windows.Forms.CheckBox cBox網掛けなし;
		private System.Windows.Forms.RadioButton rb８行;
		private System.Windows.Forms.CheckBox cbお届け先住所印刷;
		private System.Windows.Forms.RadioButton rb２行;
		private System.Windows.Forms.Label lab明細印刷;

// ADD 2006.08.09 東都）山本 検索条件に依頼主を追加 START
		private string s依頼主ＣＤ;
		private System.Windows.Forms.Label labオプション;
		private string s依頼主名;
// ADD 2006.08.09 東都）山本 検索条件に依頼主を追加 END
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 START
		private string s届け先ＣＤ = "";
		private string s届け先名   = "";
		private string s請求先ＣＤ = "";
		private string s部課ＣＤ   = "";
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 END

		private System.Windows.Forms.CheckBox cBox運賃印字なし;
		private System.Windows.Forms.Label labお客様番号;
		private System.Windows.Forms.Label label3;
		private IS2Client.共通テキストボックス texお客様番号開始;
		private IS2Client.共通テキストボックス texお客様番号終了;
		private System.Windows.Forms.GroupBox gb出力形式;
		private System.Windows.Forms.TextBox tex依頼主名;
		private IS2Client.共通テキストボックス tex依頼主コード;
		private System.Windows.Forms.Button btn依頼主検索;
		private System.Windows.Forms.RadioButton rb指定なし;
		private System.Windows.Forms.RadioButton rbご依頼主別;
		private System.Windows.Forms.RadioButton rb請求先別;
		private System.Windows.Forms.RadioButton rbお届け先別;
		private IS2Client.共通テキストボックス tex請求先コード;
		private System.Windows.Forms.TextBox tex届け先名;
		private System.Windows.Forms.Button btn届け先検索;
		private IS2Client.共通テキストボックス tex届け先コード;
		private System.Windows.Forms.ComboBox cmb請求先;
		private System.Windows.Forms.Label lab請求先コード;
		private System.Windows.Forms.CheckBox cBox発店ＣＤ出力;
		private System.Windows.Forms.CheckBox cBox配完Ｓ出力;
		private System.Windows.Forms.CheckBox cBoxご依頼主印字なし;

		public 出荷実績()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
			ＤＰＩ表示サイズ変換();
// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 END
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 START
			出力オプション情報設定();
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 END
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.cBox発店ＣＤ出力 = new System.Windows.Forms.CheckBox();
			this.gb出力形式 = new System.Windows.Forms.GroupBox();
			this.lab請求先コード = new System.Windows.Forms.Label();
			this.cmb請求先 = new System.Windows.Forms.ComboBox();
			this.tex届け先名 = new System.Windows.Forms.TextBox();
			this.btn届け先検索 = new System.Windows.Forms.Button();
			this.tex届け先コード = new IS2Client.共通テキストボックス();
			this.tex請求先コード = new IS2Client.共通テキストボックス();
			this.rbお届け先別 = new System.Windows.Forms.RadioButton();
			this.rb請求先別 = new System.Windows.Forms.RadioButton();
			this.rbご依頼主別 = new System.Windows.Forms.RadioButton();
			this.rb指定なし = new System.Windows.Forms.RadioButton();
			this.tex依頼主名 = new System.Windows.Forms.TextBox();
			this.tex依頼主コード = new IS2Client.共通テキストボックス();
			this.btn依頼主検索 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.texお客様番号終了 = new IS2Client.共通テキストボックス();
			this.texお客様番号開始 = new IS2Client.共通テキストボックス();
			this.labお客様番号 = new System.Windows.Forms.Label();
			this.labオプション = new System.Windows.Forms.Label();
			this.cBox運賃印字なし = new System.Windows.Forms.CheckBox();
			this.cBoxご依頼主印字なし = new System.Windows.Forms.CheckBox();
			this.cbお届け先住所印刷 = new System.Windows.Forms.CheckBox();
			this.lab明細印刷 = new System.Windows.Forms.Label();
			this.rb２行 = new System.Windows.Forms.RadioButton();
			this.rb８行 = new System.Windows.Forms.RadioButton();
			this.cBox網掛けなし = new System.Windows.Forms.CheckBox();
			this.cBox未発行分を除く = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dt開始日付 = new System.Windows.Forms.DateTimePicker();
			this.dt終了日付 = new System.Windows.Forms.DateTimePicker();
			this.cmb出荷日 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab出荷実績タイトル = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btnＣＳＶ出力 = new System.Windows.Forms.Button();
			this.btn印刷 = new System.Windows.Forms.Button();
			this.texメッセージ = new System.Windows.Forms.TextBox();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.cBox配完Ｓ出力 = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).BeginInit();
			this.panel1.SuspendLayout();
			this.gb出力形式.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Honeydew;
			this.panel1.Controls.Add(this.cBox配完Ｓ出力);
			this.panel1.Controls.Add(this.cBox発店ＣＤ出力);
			this.panel1.Controls.Add(this.gb出力形式);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.texお客様番号終了);
			this.panel1.Controls.Add(this.texお客様番号開始);
			this.panel1.Controls.Add(this.labお客様番号);
			this.panel1.Controls.Add(this.labオプション);
			this.panel1.Controls.Add(this.cBox運賃印字なし);
			this.panel1.Controls.Add(this.cBoxご依頼主印字なし);
			this.panel1.Controls.Add(this.cbお届け先住所印刷);
			this.panel1.Controls.Add(this.lab明細印刷);
			this.panel1.Controls.Add(this.rb２行);
			this.panel1.Controls.Add(this.rb８行);
			this.panel1.Controls.Add(this.cBox網掛けなし);
			this.panel1.Controls.Add(this.cBox未発行分を除く);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.dt開始日付);
			this.panel1.Controls.Add(this.dt終了日付);
			this.panel1.Controls.Add(this.cmb出荷日);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(0, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(618, 432);
			this.panel1.TabIndex = 1;
			// 
			// cBox発店ＣＤ出力
			// 
			this.cBox発店ＣＤ出力.ForeColor = System.Drawing.Color.Black;
			this.cBox発店ＣＤ出力.Location = new System.Drawing.Point(330, 308);
			this.cBox発店ＣＤ出力.Name = "cBox発店ＣＤ出力";
			this.cBox発店ＣＤ出力.Size = new System.Drawing.Size(282, 26);
			this.cBox発店ＣＤ出力.TabIndex = 62;
			this.cBox発店ＣＤ出力.Text = "末尾に発店コード・発店名を出力する（ＣＳＶのみ）";
			// 
			// gb出力形式
			// 
			this.gb出力形式.Controls.Add(this.lab請求先コード);
			this.gb出力形式.Controls.Add(this.cmb請求先);
			this.gb出力形式.Controls.Add(this.tex届け先名);
			this.gb出力形式.Controls.Add(this.btn届け先検索);
			this.gb出力形式.Controls.Add(this.tex届け先コード);
			this.gb出力形式.Controls.Add(this.tex請求先コード);
			this.gb出力形式.Controls.Add(this.rbお届け先別);
			this.gb出力形式.Controls.Add(this.rb請求先別);
			this.gb出力形式.Controls.Add(this.rbご依頼主別);
			this.gb出力形式.Controls.Add(this.rb指定なし);
			this.gb出力形式.Controls.Add(this.tex依頼主名);
			this.gb出力形式.Controls.Add(this.tex依頼主コード);
			this.gb出力形式.Controls.Add(this.btn依頼主検索);
			this.gb出力形式.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.gb出力形式.ForeColor = System.Drawing.Color.LimeGreen;
			this.gb出力形式.Location = new System.Drawing.Point(30, 8);
			this.gb出力形式.Name = "gb出力形式";
			this.gb出力形式.Size = new System.Drawing.Size(582, 158);
			this.gb出力形式.TabIndex = 0;
			this.gb出力形式.TabStop = false;
			this.gb出力形式.Text = "出力形式";
			// 
			// lab請求先コード
			// 
			this.lab請求先コード.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab請求先コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab請求先コード.Location = new System.Drawing.Point(264, 90);
			this.lab請求先コード.Name = "lab請求先コード";
			this.lab請求先コード.Size = new System.Drawing.Size(32, 14);
			this.lab請求先コード.TabIndex = 67;
			this.lab請求先コード.Text = "コード";
			// 
			// cmb請求先
			// 
			this.cmb請求先.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb請求先.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cmb請求先.Location = new System.Drawing.Point(116, 88);
			this.cmb請求先.Name = "cmb請求先";
			this.cmb請求先.Size = new System.Drawing.Size(144, 20);
			this.cmb請求先.TabIndex = 6;
			this.cmb請求先.SelectedIndexChanged += new System.EventHandler(this.cmb請求先_SelectedIndexChanged);
			// 
			// tex届け先名
			// 
			this.tex届け先名.BackColor = System.Drawing.Color.Honeydew;
			this.tex届け先名.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex届け先名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex届け先名.Location = new System.Drawing.Point(356, 124);
			this.tex届け先名.Name = "tex届け先名";
			this.tex届け先名.ReadOnly = true;
			this.tex届け先名.Size = new System.Drawing.Size(222, 16);
			this.tex届け先名.TabIndex = 11;
			this.tex届け先名.TabStop = false;
			this.tex届け先名.Text = "";
			// 
			// btn届け先検索
			// 
			this.btn届け先検索.BackColor = System.Drawing.Color.SteelBlue;
			this.btn届け先検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn届け先検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn届け先検索.ForeColor = System.Drawing.Color.White;
			this.btn届け先検索.Location = new System.Drawing.Point(304, 122);
			this.btn届け先検索.Name = "btn届け先検索";
			this.btn届け先検索.Size = new System.Drawing.Size(48, 22);
			this.btn届け先検索.TabIndex = 10;
			this.btn届け先検索.TabStop = false;
			this.btn届け先検索.Text = "検索";
			this.btn届け先検索.Click += new System.EventHandler(this.btn届け先検索_Click);
			// 
			// tex届け先コード
			// 
			this.tex届け先コード.BackColor = System.Drawing.SystemColors.Window;
			this.tex届け先コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex届け先コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex届け先コード.Location = new System.Drawing.Point(116, 122);
			this.tex届け先コード.MaxLength = 15;
			this.tex届け先コード.Name = "tex届け先コード";
			this.tex届け先コード.Size = new System.Drawing.Size(186, 23);
			this.tex届け先コード.TabIndex = 9;
			this.tex届け先コード.Text = "";
			this.tex届け先コード.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex届け先コード_KeyDown);
			this.tex届け先コード.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex届け先コード_KeyPress);
			// 
			// tex請求先コード
			// 
			this.tex請求先コード.BackColor = System.Drawing.Color.Honeydew;
			this.tex請求先コード.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex請求先コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex請求先コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex請求先コード.Location = new System.Drawing.Point(300, 88);
			this.tex請求先コード.MaxLength = 12;
			this.tex請求先コード.Name = "tex請求先コード";
			this.tex請求先コード.Size = new System.Drawing.Size(156, 16);
			this.tex請求先コード.TabIndex = 7;
			this.tex請求先コード.TabStop = false;
			this.tex請求先コード.Text = "";
			// 
			// rbお届け先別
			// 
			this.rbお届け先別.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.rbお届け先別.Location = new System.Drawing.Point(10, 124);
			this.rbお届け先別.Name = "rbお届け先別";
			this.rbお届け先別.Size = new System.Drawing.Size(104, 22);
			this.rbお届け先別.TabIndex = 8;
			this.rbお届け先別.Text = "お届け先別";
			this.rbお届け先別.CheckedChanged += new System.EventHandler(this.rbお届け先別_CheckedChanged);
			// 
			// rb請求先別
			// 
			this.rb請求先別.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.rb請求先別.Location = new System.Drawing.Point(10, 88);
			this.rb請求先別.Name = "rb請求先別";
			this.rb請求先別.Size = new System.Drawing.Size(104, 22);
			this.rb請求先別.TabIndex = 5;
			this.rb請求先別.Text = "請求先別";
			this.rb請求先別.CheckedChanged += new System.EventHandler(this.rb請求先別_CheckedChanged);
			// 
			// rbご依頼主別
			// 
			this.rbご依頼主別.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.rbご依頼主別.Location = new System.Drawing.Point(10, 54);
			this.rbご依頼主別.Name = "rbご依頼主別";
			this.rbご依頼主別.Size = new System.Drawing.Size(104, 22);
			this.rbご依頼主別.TabIndex = 1;
			this.rbご依頼主別.Text = "ご依頼主別";
			this.rbご依頼主別.CheckedChanged += new System.EventHandler(this.rbご依頼主別_CheckedChanged);
			// 
			// rb指定なし
			// 
			this.rb指定なし.Checked = true;
			this.rb指定なし.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.rb指定なし.Location = new System.Drawing.Point(10, 20);
			this.rb指定なし.Name = "rb指定なし";
			this.rb指定なし.Size = new System.Drawing.Size(104, 22);
			this.rb指定なし.TabIndex = 0;
			this.rb指定なし.TabStop = true;
			this.rb指定なし.Text = "指定なし";
			this.rb指定なし.CheckedChanged += new System.EventHandler(this.rb指定なし_CheckedChanged);
			// 
			// tex依頼主名
			// 
			this.tex依頼主名.BackColor = System.Drawing.Color.Honeydew;
			this.tex依頼主名.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex依頼主名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主名.Location = new System.Drawing.Point(326, 54);
			this.tex依頼主名.Name = "tex依頼主名";
			this.tex依頼主名.ReadOnly = true;
			this.tex依頼主名.Size = new System.Drawing.Size(222, 16);
			this.tex依頼主名.TabIndex = 4;
			this.tex依頼主名.TabStop = false;
			this.tex依頼主名.Text = "";
			// 
			// tex依頼主コード
			// 
			this.tex依頼主コード.BackColor = System.Drawing.SystemColors.Window;
			this.tex依頼主コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex依頼主コード.Location = new System.Drawing.Point(116, 52);
			this.tex依頼主コード.MaxLength = 12;
			this.tex依頼主コード.Name = "tex依頼主コード";
			this.tex依頼主コード.Size = new System.Drawing.Size(156, 23);
			this.tex依頼主コード.TabIndex = 2;
			this.tex依頼主コード.Text = "";
			this.tex依頼主コード.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex依頼主コード_KeyDown);
			this.tex依頼主コード.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex依頼主コード_KeyPress);
			// 
			// btn依頼主検索
			// 
			this.btn依頼主検索.BackColor = System.Drawing.Color.SteelBlue;
			this.btn依頼主検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn依頼主検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn依頼主検索.ForeColor = System.Drawing.Color.White;
			this.btn依頼主検索.Location = new System.Drawing.Point(274, 52);
			this.btn依頼主検索.Name = "btn依頼主検索";
			this.btn依頼主検索.Size = new System.Drawing.Size(48, 22);
			this.btn依頼主検索.TabIndex = 3;
			this.btn依頼主検索.TabStop = false;
			this.btn依頼主検索.Text = "検索";
			this.btn依頼主検索.Click += new System.EventHandler(this.btn依頼主検索_Click);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label3.ForeColor = System.Drawing.Color.LimeGreen;
			this.label3.Location = new System.Drawing.Point(318, 212);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(22, 16);
			this.label3.TabIndex = 61;
			this.label3.Text = "～";
			// 
			// texお客様番号終了
			// 
			this.texお客様番号終了.BackColor = System.Drawing.SystemColors.Window;
			this.texお客様番号終了.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texお客様番号終了.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.texお客様番号終了.Location = new System.Drawing.Point(340, 208);
			this.texお客様番号終了.MaxLength = 20;
			this.texお客様番号終了.Name = "texお客様番号終了";
			this.texお客様番号終了.Size = new System.Drawing.Size(190, 23);
			this.texお客様番号終了.TabIndex = 5;
			this.texお客様番号終了.Text = "";
			// 
			// texお客様番号開始
			// 
			this.texお客様番号開始.BackColor = System.Drawing.SystemColors.Window;
			this.texお客様番号開始.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texお客様番号開始.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.texお客様番号開始.Location = new System.Drawing.Point(128, 208);
			this.texお客様番号開始.MaxLength = 20;
			this.texお客様番号開始.Name = "texお客様番号開始";
			this.texお客様番号開始.Size = new System.Drawing.Size(190, 23);
			this.texお客様番号開始.TabIndex = 4;
			this.texお客様番号開始.Text = "";
			// 
			// labお客様番号
			// 
			this.labお客様番号.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labお客様番号.ForeColor = System.Drawing.Color.LimeGreen;
			this.labお客様番号.Location = new System.Drawing.Point(34, 212);
			this.labお客様番号.Name = "labお客様番号";
			this.labお客様番号.Size = new System.Drawing.Size(86, 16);
			this.labお客様番号.TabIndex = 58;
			this.labお客様番号.Text = "お客様番号";
			// 
			// labオプション
			// 
			this.labオプション.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labオプション.ForeColor = System.Drawing.Color.LimeGreen;
			this.labオプション.Location = new System.Drawing.Point(34, 310);
			this.labオプション.Name = "labオプション";
			this.labオプション.Size = new System.Drawing.Size(90, 16);
			this.labオプション.TabIndex = 57;
			this.labオプション.Text = "出力ｵﾌﾟｼｮﾝ";
			// 
			// cBox運賃印字なし
			// 
			this.cBox運賃印字なし.ForeColor = System.Drawing.Color.Black;
			this.cBox運賃印字なし.Location = new System.Drawing.Point(130, 398);
			this.cBox運賃印字なし.Name = "cBox運賃印字なし";
			this.cBox運賃印字なし.Size = new System.Drawing.Size(190, 24);
			this.cBox運賃印字なし.TabIndex = 12;
			this.cBox運賃印字なし.Text = "運賃印字なし（印刷のみ）";
			// 
			// cBoxご依頼主印字なし
			// 
			this.cBoxご依頼主印字なし.ForeColor = System.Drawing.Color.Black;
			this.cBoxご依頼主印字なし.Location = new System.Drawing.Point(130, 368);
			this.cBoxご依頼主印字なし.Name = "cBoxご依頼主印字なし";
			this.cBoxご依頼主印字なし.Size = new System.Drawing.Size(190, 24);
			this.cBoxご依頼主印字なし.TabIndex = 11;
			this.cBoxご依頼主印字なし.Text = "ご依頼主印字なし（印刷のみ）";
			// 
			// cbお届け先住所印刷
			// 
			this.cbお届け先住所印刷.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cbお届け先住所印刷.ForeColor = System.Drawing.Color.Black;
			this.cbお届け先住所印刷.Location = new System.Drawing.Point(180, 274);
			this.cbお届け先住所印刷.Name = "cbお届け先住所印刷";
			this.cbお届け先住所印刷.Size = new System.Drawing.Size(118, 22);
			this.cbお届け先住所印刷.TabIndex = 8;
			this.cbお届け先住所印刷.Text = "お届け先住所印刷";
			this.cbお届け先住所印刷.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lab明細印刷
			// 
			this.lab明細印刷.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab明細印刷.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab明細印刷.Location = new System.Drawing.Point(34, 246);
			this.lab明細印刷.Name = "lab明細印刷";
			this.lab明細印刷.Size = new System.Drawing.Size(74, 16);
			this.lab明細印刷.TabIndex = 56;
			this.lab明細印刷.Text = "明細印刷";
			// 
			// rb２行
			// 
			this.rb２行.ForeColor = System.Drawing.Color.Black;
			this.rb２行.Location = new System.Drawing.Point(130, 274);
			this.rb２行.Name = "rb２行";
			this.rb２行.Size = new System.Drawing.Size(44, 22);
			this.rb２行.TabIndex = 7;
			this.rb２行.Text = "２行";
			// 
			// rb８行
			// 
			this.rb８行.Checked = true;
			this.rb８行.ForeColor = System.Drawing.Color.Black;
			this.rb８行.Location = new System.Drawing.Point(130, 244);
			this.rb８行.Name = "rb８行";
			this.rb８行.Size = new System.Drawing.Size(44, 22);
			this.rb８行.TabIndex = 6;
			this.rb８行.TabStop = true;
			this.rb８行.Text = "８行";
			this.rb８行.CheckedChanged += new System.EventHandler(this.rb８行_CheckedChanged);
			// 
			// cBox網掛けなし
			// 
			this.cBox網掛けなし.ForeColor = System.Drawing.Color.Black;
			this.cBox網掛けなし.Location = new System.Drawing.Point(130, 338);
			this.cBox網掛けなし.Name = "cBox網掛けなし";
			this.cBox網掛けなし.Size = new System.Drawing.Size(144, 24);
			this.cBox網掛けなし.TabIndex = 10;
			this.cBox網掛けなし.Text = "網掛けなし（印刷のみ）";
			// 
			// cBox未発行分を除く
			// 
			this.cBox未発行分を除く.ForeColor = System.Drawing.Color.Black;
			this.cBox未発行分を除く.Location = new System.Drawing.Point(130, 308);
			this.cBox未発行分を除く.Name = "cBox未発行分を除く";
			this.cBox未発行分を除く.TabIndex = 9;
			this.cBox未発行分を除く.Text = "未発行分を除く";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label2.ForeColor = System.Drawing.Color.LimeGreen;
			this.label2.Location = new System.Drawing.Point(272, 178);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(24, 16);
			this.label2.TabIndex = 48;
			this.label2.Text = "～";
			// 
			// dt開始日付
			// 
			this.dt開始日付.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.dt開始日付.Location = new System.Drawing.Point(128, 174);
			this.dt開始日付.Name = "dt開始日付";
			this.dt開始日付.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.dt開始日付.Size = new System.Drawing.Size(144, 23);
			this.dt開始日付.TabIndex = 2;
			// 
			// dt終了日付
			// 
			this.dt終了日付.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.dt終了日付.Location = new System.Drawing.Point(296, 174);
			this.dt終了日付.Name = "dt終了日付";
			this.dt終了日付.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.dt終了日付.Size = new System.Drawing.Size(144, 23);
			this.dt終了日付.TabIndex = 3;
			// 
			// cmb出荷日
			// 
			this.cmb出荷日.BackColor = System.Drawing.Color.White;
			this.cmb出荷日.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb出荷日.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cmb出荷日.ForeColor = System.Drawing.Color.LimeGreen;
			this.cmb出荷日.Items.AddRange(new object[] {
														"出荷日",
														"登録日"});
			this.cmb出荷日.Location = new System.Drawing.Point(32, 174);
			this.cmb出荷日.Name = "cmb出荷日";
			this.cmb出荷日.Size = new System.Drawing.Size(78, 24);
			this.cmb出荷日.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 432);
			this.label1.TabIndex = 44;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.PaleGreen;
			this.panel6.Location = new System.Drawing.Point(0, 26);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(810, 26);
			this.panel6.TabIndex = 12;
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.lab出荷実績タイトル);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(792, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab出荷実績タイトル
			// 
			this.lab出荷実績タイトル.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab出荷実績タイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab出荷実績タイトル.ForeColor = System.Drawing.Color.White;
			this.lab出荷実績タイトル.Location = new System.Drawing.Point(12, 2);
			this.lab出荷実績タイトル.Name = "lab出荷実績タイトル";
			this.lab出荷実績タイトル.Size = new System.Drawing.Size(264, 24);
			this.lab出荷実績タイトル.TabIndex = 0;
			this.lab出荷実績タイトル.Text = "出荷実績";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btnＣＳＶ出力);
			this.panel8.Controls.Add(this.btn印刷);
			this.panel8.Controls.Add(this.texメッセージ);
			this.panel8.Controls.Add(this.btn閉じる);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 2;
			// 
			// btnＣＳＶ出力
			// 
			this.btnＣＳＶ出力.ForeColor = System.Drawing.Color.Blue;
			this.btnＣＳＶ出力.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnＣＳＶ出力.Location = new System.Drawing.Point(134, 6);
			this.btnＣＳＶ出力.Name = "btnＣＳＶ出力";
			this.btnＣＳＶ出力.Size = new System.Drawing.Size(54, 48);
			this.btnＣＳＶ出力.TabIndex = 2;
			this.btnＣＳＶ出力.Text = "ＣＳＶ　出力";
			this.btnＣＳＶ出力.Click += new System.EventHandler(this.btnＣＳＶ出力_Click);
			// 
			// btn印刷
			// 
			this.btn印刷.ForeColor = System.Drawing.Color.Blue;
			this.btn印刷.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn印刷.Location = new System.Drawing.Point(70, 6);
			this.btn印刷.Name = "btn印刷";
			this.btn印刷.Size = new System.Drawing.Size(54, 48);
			this.btn印刷.TabIndex = 1;
			this.btn印刷.Text = "印刷";
			this.btn印刷.Click += new System.EventHandler(this.btn印刷_Click);
			// 
			// texメッセージ
			// 
			this.texメッセージ.BackColor = System.Drawing.Color.PaleGreen;
			this.texメッセージ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texメッセージ.ForeColor = System.Drawing.Color.Red;
			this.texメッセージ.Location = new System.Drawing.Point(256, 4);
			this.texメッセージ.Multiline = true;
			this.texメッセージ.Name = "texメッセージ";
			this.texメッセージ.ReadOnly = true;
			this.texメッセージ.Size = new System.Drawing.Size(376, 50);
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
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.panel1);
			this.groupBox3.Location = new System.Drawing.Point(10, 56);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(620, 440);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			// 
			// cBox配完Ｓ出力
			// 
			this.cBox配完Ｓ出力.ForeColor = System.Drawing.Color.Black;
			this.cBox配完Ｓ出力.Location = new System.Drawing.Point(330, 338);
			this.cBox配完Ｓ出力.Name = "cBox配完Ｓ出力";
			this.cBox配完Ｓ出力.Size = new System.Drawing.Size(178, 24);
			this.cBox配完Ｓ出力.TabIndex = 64;
			this.cBox配完Ｓ出力.Text = "配完日付・時刻を出力する";
			// 
			// 出荷実績
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(634, 582);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(640, 607);
			this.Name = "出荷実績";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 出荷実績";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
			this.Load += new System.EventHandler(this.出荷実績_Load);
			this.Closed += new System.EventHandler(this.出荷実績_Closed);
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).EndInit();
			this.panel1.ResumeLayout(false);
			this.gb出力形式.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 START
			//画面を閉じる時に、出力オプションのチェック内容を保存する
			出力オプション情報保存();
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 END
			this.Close();
		}

		private void 出荷実績_Load(object sender, System.EventArgs e)
		{
			cmb出荷日.SelectedIndex = 0;
			dt開始日付.Value = gdt出荷日;
			dt終了日付.Value = gdt出荷日;
			texメッセージ.Text = "";
// ADD 2007.02.20 東都）高木 検索条件に依頼主を追加 START
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 START
//			tex依頼主コード.Text = " ";
//			tex依頼主名.Text     = "";
//			s依頼主ＣＤ = "";
//			s依頼主名   = "";
//			tex依頼主コード.Focus();

			cmb請求先.Items.Clear();
			if(gsa請求先部課名 != null)
			{
				cmb請求先.Items.Add("");
				cmb請求先.Items.AddRange(gsa請求先部課名);
			}
			rb指定なし.Checked     = true;
			出力形式クリア();
			texお客様番号開始.Text = "";
			texお客様番号終了.Text = "";

			rb指定なし.Focus();
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 END
// ADD 2007.02.20 東都）高木 検索条件に依頼主を追加 END
// MOD 2009.05.01 東都）高木 オプションの項目追加 START
			if(gsオプション[0].Length == 4){
				if(gsオプション[13].Equals("1")){
					rb２行.Checked = true;
				}else{
					rb８行.Checked = true;
				}
			}
// MOD 2009.05.01 東都）高木 オプションの項目追加 END
// MOD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 START
			if(rb８行.Checked){
				cbお届け先住所印刷.Checked = false;
				cbお届け先住所印刷.Enabled = false;
				cbお届け先住所印刷.Visible = false;
			}
			else
			{
				cbお届け先住所印刷.Enabled = true;
				cbお届け先住所印刷.Visible = true;
			}
// MOD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 END
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 START
			if(gs出荷実績_発店出力_ＣＳＶのみ != null)
			{
				cBox発店ＣＤ出力.Visible = true;
				//チェックボックス内用の保存履歴が存在する場合、そちらを優先
				if(gs出荷実績_発店出力_ＣＳＶのみ == "1")
				{
					cBox発店ＣＤ出力.Checked = true;
				}
				else
				{
					cBox発店ＣＤ出力.Checked = false;
				}
			}
			else
			{
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 END
// MOD 2013.04.04 TDI）綱澤 出力レイアウト追加（グローバル専用）START
				if(gs部門店所ＣＤ.Equals("047"))
				{
					cBox発店ＣＤ出力.Visible = true;
					cBox発店ＣＤ出力.Checked = true;
				}
				else
				{
					cBox発店ＣＤ出力.Visible = true;
					cBox発店ＣＤ出力.Checked = false;
				}
// MOD 2013.04.04 TDI）綱澤 出力レイアウト追加（グローバル専用）END
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 START
			}
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 END
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 START
			if(gs出荷実績_配完日時出力 != null)
			{
				cBox配完Ｓ出力.Visible = true;
				//チェックボックス内用の保存履歴が存在する場合、そちらを優先
				if(gs出荷実績_配完日時出力 == "1")
				{
					cBox配完Ｓ出力.Checked = true;
				}
				else
				{
					cBox配完Ｓ出力.Checked = false;
				}
			}
			else
			{
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 END
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
				//グローバル接続の場合は初期状態'ON'に設定
				if(gs部門店所ＣＤ.Equals("047"))
				{
					cBox配完Ｓ出力.Visible = true;
					cBox配完Ｓ出力.Checked = true;
				}
				else
				{
					cBox配完Ｓ出力.Visible = true;
					cBox配完Ｓ出力.Checked = false;
				}
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 START
			}
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 END
		}

		private void 出荷実績_Closed(object sender, System.EventArgs e)
		{
			cmb出荷日.SelectedIndex = 0;
			dt開始日付.Value = gdt出荷日;
			dt終了日付.Value = gdt出荷日;
			texメッセージ.Text = "";
// ADD 2007.02.20 東都）高木 検索条件に依頼主を追加 START
//			cmb出荷日.Focus();
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 START
//			tex依頼主コード.Text = " ";
//			tex依頼主名.Text     = "";
//			s依頼主ＣＤ = "";
//			s依頼主名   = "";
//			tex依頼主コード.Focus();
			rb指定なし.Checked       = true;
			出力形式クリア();
//			cmb請求先.SelectedIndex  = 0;
//			tex請求先コード.Text     = "";
//			tex部課コード.Text       = "";
//			tex届け先コード.Text     = "";
//			tex届け先名.Text         = "";
			texお客様番号開始.Text   = "";
			texお客様番号終了.Text   = "";
			rb指定なし.Focus();
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 END
// ADD 2007.02.20 東都）高木 検索条件に依頼主を追加 END
		}

		private void btnＣＳＶ出力_Click(object sender, System.EventArgs e)
		{
			texメッセージ.Text = "";
			if (dt開始日付.Value > dt終了日付.Value)
			{
				MessageBox.Show("日付の範囲が正しく入力されていません","入力チェック",MessageBoxButtons.OK );
				dt開始日付.Focus();
				return;
			}
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 START
//// ADD 2006.08.09 東都）山本 検索条件に依頼主を追加 START
//			s依頼主ＣＤ = tex依頼主コード.Text.Trim();
//			依頼主検索();
//// ADD 2006.08.09 東都）山本 検索条件に依頼主を追加 END

			出力形式クリア();
			int i出力形式 = 0;
			if(rbご依頼主別.Checked)      i出力形式 = 1;
			else if(rb請求先別.Checked)   i出力形式 = 2;
			else if(rbお届け先別.Checked) i出力形式 = 3;

			// ご依頼主情報表示
			tex依頼主コード.Text = tex依頼主コード.Text.TrimEnd();
			if(tex依頼主コード.Text.Length == 0){
				tex依頼主名.Text = "";
			}else{
				if(!半角チェック(tex依頼主コード,"依頼主コード")) return;

				texメッセージ.Text = "";
				s依頼主ＣＤ = tex依頼主コード.Text;
				依頼主検索();
			}

			// 請求先情報表示
			s請求先ＣＤ = "";
			s部課ＣＤ   = "";
			tex請求先コード.Text = "";
			if(gsa請求先ＣＤ.Length > 0 && cmb請求先.SelectedIndex > 0){
				s請求先ＣＤ = gsa請求先ＣＤ[cmb請求先.SelectedIndex - 1];
				s部課ＣＤ   = gsa請求先部課ＣＤ[cmb請求先.SelectedIndex - 1];
				tex請求先コード.Text = s請求先ＣＤ.TrimEnd() + " " + s部課ＣＤ.TrimEnd();
			}

			// お届け先情報表示
			tex届け先コード.Text = tex届け先コード.Text.TrimEnd();
			if(tex届け先コード.Text.Length == 0){
				tex届け先名.Text = "";
			}else{
				if(!半角チェック(tex届け先コード,"届け先コード")) return;

				texメッセージ.Text = "";
				s届け先ＣＤ = tex届け先コード.Text;
				届け先検索();
			}

			texお客様番号開始.Text = texお客様番号開始.Text.TrimEnd();
			texお客様番号終了.Text = texお客様番号終了.Text.TrimEnd();
			if(!半角チェック(texお客様番号開始,"お客様番号（開始）")) return;
			if(!半角チェック(texお客様番号終了,"お客様番号（終了）")) return;
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 END

// MOD 2005.07.08 東都）高木 日付変換の変更 START
//			string sSday = dt開始日付.Value.ToShortDateString().Replace("/","");
//			string sEday = dt終了日付.Value.ToShortDateString().Replace("/","");
			string sSday = YYYYMMDD変換(dt開始日付.Value);
			string sEday = YYYYMMDD変換(dt終了日付.Value);
// MOD 2005.07.08 東都）高木 日付変換の変更 END

			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				String[] sList;
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 START
//// MOD 2007.02.20 東都）高木 ＣＳＶ出力は、旧バージョンにする START
////// MOD 2006.07.27 東都）山本 運賃と保険料項目の追加 START
//////				sList = sv_syukka.Get_csvwrite(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,"", "", cmb出荷日.SelectedIndex, sSday, sEday, "00");
////				sList = sv_syukka.Get_csvwrite1(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,"", "", cmb出荷日.SelectedIndex, sSday, sEday, "00");
////// MOD 2006.07.27 東都）山本 運賃と保険料項目の追加 END
//// MOD 2008.07.09 東都）高木 未発行分を除外する START
////				sList = sv_syukka.Get_csvwrite(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,"", s依頼主ＣＤ, cmb出荷日.SelectedIndex, sSday, sEday, "00");
//				if(cBox未発行分を除く.Checked){
//					sList = sv_syukka.Get_csvwrite(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,"", s依頼主ＣＤ, cmb出荷日.SelectedIndex, sSday, sEday, "aa");
//				}else{
//					sList = sv_syukka.Get_csvwrite(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,"", s依頼主ＣＤ, cmb出荷日.SelectedIndex, sSday, sEday, "00");
//				}
//// MOD 2008.07.09 東都）高木 未発行分を除外する END
				string s状態 = "";
				if(cBox未発行分を除く.Checked){
					s状態 = "aa";
				}else{
					s状態 = "00";
				}

				// MOD 2013.04.04 TDI）綱澤 出力レイアウト追加（グローバル専用）START
				string s発店ＣＤ = "";
				if(cBox発店ＣＤ出力.Checked)
				{
					s発店ＣＤ = "1";
				}
				else
				{
					s発店ＣＤ = "";
				}
				// MOD 2013.04.04 TDI）綱澤 出力レイアウト追加（グローバル専用）END

// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
				string s配完Ｓ = "";
				if(cBox配完Ｓ出力.Checked)
				{
					s配完Ｓ = "1";
				}
				else
				{
					s配完Ｓ = "";
				}
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END

				string[] sa検索条件 = new string[]{
								gs会員ＣＤ
								, gs部門ＣＤ
								, tex届け先コード.Text.TrimEnd()
								, tex依頼主コード.Text.TrimEnd()
								, cmb出荷日.SelectedIndex.ToString()
								, sSday
								, sEday
								, s状態
								, ""	// 送り状番号開始
								, ""	// 送り状番号終了
							    , texお客様番号開始.Text.TrimEnd()
							    , texお客様番号終了.Text.TrimEnd()
								, s請求先ＣＤ.TrimEnd()
								, s部課ＣＤ.TrimEnd()
								, i出力形式.ToString()
// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）START
								, gsオプション[17]
// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）END
// MOD 2013.04.04 TDI）綱澤 出力レイアウト追加（グローバル専用）START
								, s発店ＣＤ
// MOD 2013.04.04 TDI）綱澤 出力レイアウト追加（グローバル専用）END
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
								, s配完Ｓ
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END
				};
				sList = sv_syukka.Get_csvwrite2(gsaユーザ, sa検索条件);
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 END
// MOD 2007.02.20 東都）高木 ＣＳＶ出力は、旧バージョンにする END
				this.Cursor = System.Windows.Forms.Cursors.Default;

				if(sList[0].Length == 4)
				{
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
// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）START
					}
// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）END
// MOD 2013.04.04 TDI）綱澤 出力レイアウト追加（グローバル専用）START
					if(s発店ＣＤ.Equals("1"))
					{
						sList[0] += ",\"発店コード\",\"発店名\"";
					}
// MOD 2013.04.04 TDI）綱澤 出力レイアウト追加（グローバル専用）END
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
					if(s配完Ｓ.Equals("1"))
					{
						sList[0] += ",\"配完日付・時刻\"";
					}
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END

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
					if(sList[0].Equals("該当データがありません"))
					{
						texメッセージ.Text = "";
						ビープ音();
						MessageBox.Show("該当データがありません","出荷実績",MessageBoxButtons.OK);
					}
					else
					{
						ビープ音();
						texメッセージ.Text = sList[0];
					}
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
		}

		private void btn印刷_Click(object sender, System.EventArgs e)
		{
			string s出荷日   = "";
// MOD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 START
//			string s日付保持 = "";
			string s小計キー = "";
			string s小計キー保持 = "";
// MOD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 EDD
			string s必着     = "";

			int i個数  = 0;
			int i才数  = 0;
			int i重量  = 0;
			int i保険  = 0;
// MOD 2011.04.13 東都）高木 重量入力不可対応 START
			int i才数重量 = 0;
			string s運賃才数 = "";
			string s運賃重量 = "";
// MOD 2011.04.13 東都）高木 重量入力不可対応 END

			int i件数小計 = 0;
			int i個数小計 = 0;
			int i重量小計 = 0;
			int i保険小計 = 0;
// ADD 2006.08.08 東都）山本 印刷項目に運賃を追加 START
			int i運賃  = 0;
			int i運賃小計 = 0;
// ADD 2006.08.08 東都）山本 印刷項目に運賃を追加 END
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 START
//// ADD 2006.08.09 東都）山本 検索条件に依頼主を追加 START
//			s依頼主ＣＤ = tex依頼主コード.Text.Trim();
//			依頼主検索();
//// ADD 2006.08.09 東都）山本 検索条件に依頼主を追加 END

			texメッセージ.Text = "";
			出力形式クリア();
			int i出力形式 = 0;
			if(rbご依頼主別.Checked)      i出力形式 = 1;
			else if(rb請求先別.Checked)   i出力形式 = 2;
			else if(rbお届け先別.Checked) i出力形式 = 3;

			// ご依頼主情報表示
			tex依頼主コード.Text = tex依頼主コード.Text.TrimEnd();
			if(tex依頼主コード.Text.Length == 0){
				tex依頼主名.Text = "";
			}else{
				if(!半角チェック(tex依頼主コード,"依頼主コード")) return;

				texメッセージ.Text = "";
				s依頼主ＣＤ = tex依頼主コード.Text;
				依頼主検索();
			}

			// 請求先情報表示
			s請求先ＣＤ = "";
			s部課ＣＤ   = "";
			tex請求先コード.Text = "";
			if(gsa請求先ＣＤ.Length > 0 && cmb請求先.SelectedIndex > 0){
				s請求先ＣＤ = gsa請求先ＣＤ[cmb請求先.SelectedIndex - 1];
				s部課ＣＤ   = gsa請求先部課ＣＤ[cmb請求先.SelectedIndex - 1];
				tex請求先コード.Text = s請求先ＣＤ.TrimEnd() + " " + s部課ＣＤ.TrimEnd();
			}

			// お届け先情報表示
			tex届け先コード.Text = tex届け先コード.Text.TrimEnd();
			if(tex届け先コード.Text.Length == 0){
				tex届け先名.Text = "";
			}else{
				if(!半角チェック(tex届け先コード,"届け先コード")) return;

				texメッセージ.Text = "";
				s届け先ＣＤ = tex届け先コード.Text;
				届け先検索();
			}
			texお客様番号開始.Text = texお客様番号開始.Text.TrimEnd();
			texお客様番号終了.Text = texお客様番号終了.Text.TrimEnd();
			if(!半角チェック(texお客様番号開始,"お客様番号（開始）")) return;
			if(!半角チェック(texお客様番号終了,"お客様番号（終了）")) return;
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 END
			if (dt開始日付.Value > dt終了日付.Value)
			{
				MessageBox.Show("日付の範囲が正しく入力されていません","入力チェック",MessageBoxButtons.OK );
				dt開始日付.Focus();
				return;
			}

			texメッセージ.Text = "出荷実績一覧印刷中．．．";
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				if(sv_print == null) sv_print = new is2print.Service1();

// MOD 2005.07.08 東都）高木 日付変換の変更 START
//				string sSday = dt開始日付.Value.ToShortDateString().Replace("/","");
//				string sEday = dt終了日付.Value.ToShortDateString().Replace("/","");
				string sSday = YYYYMMDD変換(dt開始日付.Value);
				string sEday = YYYYMMDD変換(dt終了日付.Value);
// MOD 2005.07.08 東都）高木 日付変換の変更 END

				string[] sRet = new string[1];
// MOD 2006.08.03 東都）山本 印刷項目に運賃を追加 START
//				IEnumerator iEnum = sv_print.Get_PublishedPrintData(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,cmb出荷日.SelectedIndex, sSday, sEday).GetEnumerator();
// MOD 2008.07.09 東都）高木 未発行分を除外する START
//				IEnumerator iEnum = sv_print.Get_PublishedPrintData2(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,cmb出荷日.SelectedIndex, sSday, sEday,s依頼主ＣＤ).GetEnumerator();
				IEnumerator iEnum = null;
// MOD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 START
//				if(cBox未発行分を除く.Checked){
//					iEnum = sv_print.Get_PublishedPrintData3(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,cmb出荷日.SelectedIndex, sSday, sEday,s依頼主ＣＤ,"aa").GetEnumerator();
//				}else{
//					iEnum = sv_print.Get_PublishedPrintData3(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,cmb出荷日.SelectedIndex, sSday, sEday,s依頼主ＣＤ,"00").GetEnumerator();
//				}
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 START
//				int iSyuka = cmb出荷日.SelectedIndex;
//				if(rb２行.Checked){
//					iSyuka += 2;
//// MOD 2009.05.01 東都）高木 オプションの項目追加 START
//					if(gsオプション[0].Length == 4){
//						if(gsオプション[14].Equals("1")){
//							iSyuka = cmb出荷日.SelectedIndex;
//						}
//					}
//// MOD 2009.05.01 東都）高木 オプションの項目追加 END
//				}
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 END
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 START
//				if(cBox未発行分を除く.Checked){
//					iEnum = sv_print.Get_PublishedPrintData3(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,iSyuka, sSday, sEday,s依頼主ＣＤ,"aa").GetEnumerator();
//				}else{
//					iEnum = sv_print.Get_PublishedPrintData3(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,iSyuka, sSday, sEday,s依頼主ＣＤ,"00").GetEnumerator();
//				}
				string s状態 = "";
				if(cBox未発行分を除く.Checked){
					s状態 = "aa";
				}else{
					s状態 = "00";
				}
				string[] sa検索条件 = new string[]{
								gs会員ＣＤ
								, gs部門ＣＤ
								, tex届け先コード.Text.TrimEnd()
								, tex依頼主コード.Text.TrimEnd()
								, cmb出荷日.SelectedIndex.ToString()
								, sSday
								, sEday
								, s状態
								, ""	// 送り状番号開始
								, ""	// 送り状番号終了
							    , texお客様番号開始.Text.TrimEnd()
							    , texお客様番号終了.Text.TrimEnd()
								, s請求先ＣＤ.TrimEnd()
								, s部課ＣＤ.TrimEnd()
								, i出力形式.ToString()
				};
				iEnum = sv_print.Get_PublishedPrintData4(gsaユーザ, sa検索条件).GetEnumerator();
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 END
// MOD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 END
// MOD 2008.07.09 東都）高木 未発行分を除外する END
// MOD 2006.08.03 東都）山本 印刷項目に運賃を追加 END
				iEnum.MoveNext();
				sRet = (string[])iEnum.Current;
				if (sRet[0].Equals("正常終了"))
				{
					出荷実績データ ds = new 出荷実績データ();

					int iCnt = 1;
					//データセットに値をセット
					while (iEnum.MoveNext())
					{
						string[] sList = new string[40];
						sList = (string[])iEnum.Current;
					
						出荷実績データ.table出荷実績Row tr = (出荷実績データ.table出荷実績Row)ds.table出荷実績.NewRow();
						tr.BeginEdit();

						if(cmb出荷日.SelectedIndex == 0)
							s出荷日   = sList[1].Trim();
						else
							s出荷日   = sList[0].Trim();

// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 START
//// MOD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 START
////						if((s日付保持 != "") && (s日付保持 != s出荷日))
//						if(rb２行.Checked){
//							s小計キー = s出荷日 + sList[15];	//[出荷日]+[荷送人ＣＤ]
//// MOD 2009.05.01 東都）高木 オプションの項目追加 START
//							if(gsオプション[0].Length == 4){
//								if(gsオプション[14].Equals("1")){
//									s小計キー = s出荷日;
//								}
//							}
//// MOD 2009.05.01 東都）高木 オプションの項目追加 END
//						}else{
//							s小計キー = s出荷日;
//						}
						switch(i出力形式){
						case 1:		// ご依頼主別
							s小計キー = s出荷日 + sList[15];
							break;
						case 2:		// 請求先別
							s小計キー = s出荷日 + sList[39] + sList[40];
							break;
						case 3:		// お届け先別
							s小計キー = s出荷日 + sList[3];
							break;
						default:
							s小計キー = s出荷日;
							break;
						}
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 START
						if((s小計キー保持 != "") && (s小計キー保持 != s小計キー))
// MOD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 END
						{
// MOD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 START
//							s日付保持 = s出荷日;
							s小計キー保持 = s小計キー;
// MOD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 END
							tr.小計フラグ = 1;
							iCnt = 1;
							tr.件数小計  = i件数小計;
							tr.個数小計  = i個数小計;
							tr.重量小計  = i重量小計;
							tr.保険小計  = i保険小計;
// ADD 2006.08.08 東都）山本 印刷項目に運賃を追加 START
							tr.運賃小計  = i運賃小計;
// ADD 2006.08.08 東都）山本 印刷項目に運賃を追加 END
							i件数小計 = 1;
							i個数小計 = 0;
							i重量小計 = 0;
							i保険小計 = 0;
// ADD 2006.08.08 東都）山本 印刷項目に運賃を追加 START
							i運賃小計 = 0;
// ADD 2006.08.08 東都）山本 印刷項目に運賃を追加 END
						}
						else
						{
// MOD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 START
//							if(s日付保持 == "")
//								s日付保持 = s出荷日;
							if(s小計キー保持 == "")
								s小計キー保持 = s小計キー;
// MOD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 END
							tr.小計フラグ = 0;
							i件数小計++;
						}
// MOD 2008.07.25 東都）高木 網掛けをはずす START
//						tr.番号 = iCnt++;
						if(cBox網掛けなし.Checked){
							tr.番号 = -1;
						}else{
							tr.番号 = iCnt++;
						}
// MOD 2008.07.25 東都）高木 網掛けをはずす END
						if(cmb出荷日.SelectedIndex == 0)
						{
							tr.登録日        = sList[0].Substring(4,2) + "/" + sList[0].Substring(6,2);
							tr.出荷日        = "出荷日 " + sList[1].Substring(2,2) + "年" + sList[1].Substring(4,2) + "月" + sList[1].Substring(6,2) + "日";
							tr.日付タイトル  = "登録日";
						}
						else
						{
							tr.出荷日        = "登録日 " + sList[0].Substring(2,2) + "年" + sList[0].Substring(4,2) + "月" + sList[0].Substring(6,2) + "日";
							tr.登録日        = sList[1].Substring(4,2) + "/" + sList[1].Substring(6,2);
							tr.日付タイトル  = "出荷日";
						}

						if(sList[2].Trim().Length == 0)
							tr.送り状番号  = sList[2].Trim();
						else
							tr.送り状番号  = sList[2].Substring(4,3) + "-" + sList[2].Substring(7,4) + "-" + sList[2].Substring(11,4);

						tr.荷受人コード  = sList[3].Trim();
						tr.荷受人郵便番号   = sList[4].Substring(0,3) + "-" + sList[4].Substring(3,4);
						if(sList[5].Trim().Length == 0)
							tr.荷受人電話番号 = sList[6].Trim() + "-" + sList[7].Trim();
						else
							tr.荷受人電話番号 = "(" + sList[5].Trim() + ")" + sList[6].Trim() + "-" + sList[7].Trim();
						tr.荷受人住所１     = sList[8].Trim() + sList[9].Trim();
						tr.荷受人住所２     = sList[10].Trim();
						tr.荷受人名前１     = sList[11].Trim() + "  " + sList[12].Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
///						if(gsオプション[18].Equals("1")){
							tr.荷受人住所１     = sList[8].TrimEnd() + sList[9].TrimEnd();
							tr.荷受人住所２     = sList[10].TrimEnd();
							tr.荷受人名前１     = sList[11].TrimEnd() + "  " + sList[12].TrimEnd();
///						}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
// ADD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 START
						//パターン１の場合には、（名前１、名前２）
						if(rb２行.Checked){
							tr.荷受人住所１ = "";
							tr.荷受人名前１ = sList[11].Trim() + "  " + sList[12].Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
///							if(gsオプション[18].Equals("1")){
								tr.荷受人名前１ = sList[11].TrimEnd() + "  " + sList[12].TrimEnd();
///							}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
							//パターン２の場合には、（名前１、住所１）
							if(cbお届け先住所印刷.Checked){
								tr.荷受人住所１ = sList[8].Trim();
								tr.荷受人名前１ = sList[11].Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
///								if(gsオプション[18].Equals("1")){
									tr.荷受人住所１ = sList[8].TrimEnd();
									tr.荷受人名前１ = sList[11].TrimEnd();
///								}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
// MOD 2015.10.21 BEVAS）松本 支店止め出荷の場合、お届け先住所の表記を変更 START
								if(tr.荷受人住所１.Equals("※※支店止め※※"))
								{
									if(sList[9].Trim().Substring(0, 2) == "王子")
									{
										tr.荷受人住所１ = "王子運送　" + sList[9].Trim();
									}
									else
									{
										tr.荷受人住所１ = "福山通運　" + sList[9].Trim();
									}
								}
// MOD 2015.10.21 BEVAS）松本 支店止め出荷の場合、お届け先住所の表記を変更 END
							}
						}
// ADD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 END

						tr.着店コード  = sList[13].Trim();
						tr.着店名   = sList[14].Trim();

						tr.荷送人コード   = sList[15].Trim();
// MOD 2005.11.08 東都）伊賀 郵便番号NULL対応 START
//						tr.荷送人郵便番号   = sList[16].Substring(0,3) + "-" + sList[16].Substring(3,4);
						if(sList[16].Trim().Length != 0)
							tr.荷送人郵便番号   = sList[16].Substring(0,3) + "-" + sList[16].Substring(3,4);
// MOD 2005.11.08 東都）伊賀 郵便番号NULL対応 END
						if(sList[17].Trim().Length == 0)
							tr.荷送人電話番号 = sList[18].Trim() + "-" + sList[19].Trim();
						else
							tr.荷送人電話番号 = "(" + sList[17].Trim() + ")" + sList[18].Trim() + "-" + sList[19].Trim();
						tr.荷送人住所１     = sList[20].Trim() + sList[21].Trim();
						tr.荷送人名前１     = sList[22].Trim() + "  " + sList[23].Trim();
						tr.担当     = sList[24].Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
///						if(gsオプション[18].Equals("1")){
							tr.荷送人住所１     = sList[20].TrimEnd() + sList[21].TrimEnd();
							tr.荷送人名前１     = sList[22].TrimEnd() + "  " + sList[23].TrimEnd();
							tr.担当     = sList[24].TrimEnd();
///						}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END

						i個数 = int.Parse(sList[25].Trim());
						i個数小計    = i個数小計 + i個数;
						tr.個数         = sList[25].Trim();

// MOD 2011.04.13 東都）高木 重量入力不可対応 START
						i重量 = 0;
						i才数 = 0;
						i才数重量 = 0;
// MOD 2011.04.13 東都）高木 重量入力不可対応 END
// MOD 2005.09.02 東都）小童谷 小数点対応 START
//						i重量 = int.Parse(sList[26].Trim());
//						i才数 = int.Parse(sList[36].Trim());
						i重量 = (int)(double.Parse(sList[26].Trim()) + 0.5);
						i才数 = (int)(double.Parse(sList[36].Trim()) + 0.5);
// MOD 2005.09.02 東都）小童谷 小数点対応 END
						i才数 = i才数 * 8;
// MOD 2011.04.13 東都）高木 重量入力不可対応 START
//						if(i才数 == 0)
//						{
//							i重量小計    = i重量小計 + i重量;
//							tr.重量         = i重量.ToString("#,##0");
//						}
//						else
//						{
//							i重量小計    = i重量小計 + i才数;
//							tr.重量         = i才数.ToString("#,##0");
//						}
						i才数重量 = i重量 + i才数;
						tr.重量   = i才数重量.ToString("#,##0");
						if(i才数重量 == 0){
							// 運賃才数、運賃重量が未設定の場合は空白
							s運賃才数 = sList[42].TrimEnd();
							s運賃重量 = sList[43].TrimEnd();
							if(s運賃才数.Length == 0 && s運賃重量.Length == 0){
								tr.重量 = "";
							}
						}
						i重量小計 += i才数重量;
// MOD 2011.04.13 東都）高木 重量入力不可対応 END

						if(sList[37].Trim() == "0")
							s必着 = "必着";
						else
							s必着 = "指定";

						if(sList[27].Trim().Length == 1)
							tr.指定日       = "";
						else
							tr.指定日       = sList[27].Substring(4,2) + "/" + sList[27].Substring(6,2) + s必着;

// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//						tr.輸送指示１   = sList[28].Trim();
//						tr.輸送指示２   = sList[29].Trim();
//						tr.品名記事１   = sList[30].Trim();
//						tr.品名記事２   = sList[31].Trim();
//						tr.品名記事３   = sList[32].Trim();
						tr.輸送指示１   = sList[28].TrimEnd();
						tr.輸送指示２   = sList[29].TrimEnd();
						tr.品名記事１   = sList[30].TrimEnd();
						tr.品名記事２   = sList[31].TrimEnd();
						tr.品名記事３   = sList[32].TrimEnd();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
// MOD 2011.07.14 東都）高木 記事行の追加 START
						if(sList.Length > 44){
							tr.品名記事４ = sList[44].TrimEnd();
							tr.品名記事５ = sList[45].TrimEnd();
							tr.品名記事６ = sList[46].TrimEnd();
						}else{
							tr.品名記事４ = "";
							tr.品名記事５ = "";
							tr.品名記事６ = "";
						}
// MOD 2011.07.14 東都）高木 記事行の追加 END

						if(sList[33].Trim() == "1")
							tr.元着区分     = "元払";
						else
						{
							if(sList[33].Trim() == "2")
								tr.元着区分     = "着払";
							else
								tr.元着区分     = sList[33].Trim();
						}

						i保険       = int.Parse(sList[34].Trim());
						i保険小計       = i保険小計 + i保険;
						tr.保険金額     = i保険.ToString("#,##0");

						tr.お客様番号   = sList[35].Trim();

// ADD 2006.08.03 東都）山本 印刷項目に運賃を追加 START
						i運賃       = int.Parse(sList[38].Trim());
						i運賃小計       = i運賃小計 + i運賃;
// MDD 2008.06.12 東都）高木 運賃が０の場合[＊]表示 START
//						tr.運賃     = i運賃.ToString("#,##0");
						if(i運賃 == 0){
							tr.運賃 = "*";
						}else{
							tr.運賃 = i運賃.ToString("#,##0");
						}
// MDD 2008.06.12 東都）高木 運賃が０の場合[＊]表示 END
// ADD 2006.08.03 東都）山本 印刷項目に運賃を追加 END
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 START
						switch(i出力形式){
						case 1:		// ご依頼主別
							tr.ヘッダ１名称   = "　ご依頼主" + " "
											  + sList[15].Trim() + " "
											  + sList[22].Trim() + " " + sList[23].Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
///							if(gsオプション[18].Equals("1")){
								tr.ヘッダ１名称   = "　ご依頼主" + " "
												  + sList[15].Trim() + " "
												  + sList[22].TrimEnd() + " " + sList[23].TrimEnd();
///							}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
							break;
						case 2:		// 請求先別
							tr.ヘッダ１名称   = "　請求先" + " "
											  + sList[39].Trim() + " " + sList[40].Trim() + " "
											  + sList[41].Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
///							if(gsオプション[18].Equals("1")){
								tr.ヘッダ１名称   = "　請求先" + " "
												  + sList[39].Trim() + " " + sList[40].Trim() + " "
												  + sList[41].TrimEnd();
///							}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
							break;
						case 3:		// お届け先別
							tr.ヘッダ１名称   = "";
							break;
						default:
							tr.ヘッダ１名称   = "";
							break;
						}
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 END
// MOD 2010.02.28 東都）高木 王子運送の対応 START
						if(gs会員ＣＤ.Substring(0,1) != "J"){
							tr.王子運送FLG = "0";
						}else{
							tr.王子運送FLG = "1";
						}
// MOD 2010.02.28 東都）高木 王子運送の対応 START
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 START
						if(cBox配完Ｓ出力.Checked)
						{
							tr.配完日時あり = "配完日付・時刻";
							if(sList[47].Trim() != ""){
								tr.配完日時 = "20" + sList[47].Substring(0,2) + "/" + sList[47].Substring(2,2) + "/" + sList[47].Substring(4,2)
									+ " " + sList[47].Substring(6,2) + ":" + sList[47].Substring(8,2);
							}else{
								if(rb８行.Checked)
								{
									tr.配完日時あり = "";
								}
								tr.配完日時 = "";
							}
						}
						else
						{
							tr.配完日時あり = "";
							tr.配完日時 = "";
						}
// MOD 2013.10.07 BEVAS）高杉 配完日付・時刻を追加 END

						tr.EndEdit();

						ds.table出荷実績.Rows.Add(tr);
					}
					出荷実績データ.table出荷実績Row tr2 = (出荷実績データ.table出荷実績Row)ds.table出荷実績.NewRow();
					tr2.小計フラグ = 2;
					tr2.番号 = 1;
					tr2.件数小計 = i件数小計;
					tr2.個数小計 = i個数小計;
					tr2.重量小計 = i重量小計;
					tr2.保険小計 = i保険小計;
// ADD 2006.08.08 東都）山本 印刷項目に運賃を追加 START
					tr2.運賃小計 = i運賃小計;
// ADD 2006.08.08 東都）山本 印刷項目に運賃を追加 END
					ds.table出荷実績.Rows.Add(tr2);
					
// MOD 2009.05.01 東都）高木 オプションの項目追加 START
//					出荷実績帳票 cr = new 出荷実績帳票();
//// ADD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 START
//					出荷実績帳票２ cr2 = new 出荷実績帳票２();
//					if(rb２行.Checked){
//						//CrystalReportにパラメータとデータセットを渡す
//						cr2.SetParameterValue("部門ＣＤ", gs部門ＣＤ);
//						cr2.SetParameterValue("部門名",   gs部門名);
//// MOD 2009.04.06 東都）高木 [ご依頼主印字なし]、[運賃印字なし]の機能の追加 START
//						cr2.SetParameterValue("ご依頼主印字なし"
//											, cBoxご依頼主印字なし.Checked);
//						cr2.SetParameterValue("運賃印字なし"
//											, cBox運賃印字なし.Checked);
//// MOD 2009.04.06 東都）高木 [ご依頼主印字なし]、[運賃印字なし]の機能の追加 END
//						cr2.SetDataSource(ds);
//					}else{
//// ADD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 END
//						//CrystalReportにパラメータとデータセットを渡す
//						cr.SetParameterValue("部門ＣＤ", gs部門ＣＤ);
//						cr.SetParameterValue("部門名",   gs部門名);
//// MOD 2009.04.06 東都）高木 [ご依頼主印字なし]、[運賃印字なし]の機能の追加 START
//						cr.SetParameterValue("ご依頼主印字なし"
//											, cBoxご依頼主印字なし.Checked);
//						cr.SetParameterValue("運賃印字なし"
//											, cBox運賃印字なし.Checked);
//// MOD 2009.04.06 東都）高木 [ご依頼主印字なし]、[運賃印字なし]の機能の追加 END
//						cr.SetDataSource(ds);
//// ADD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 START
//					}
//// ADD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 END
					ReportClass cr = new 出荷実績帳票();
					if(rb２行.Checked){
						cr = new 出荷実績帳票２();
//						if(gsオプション[0].Length == 4){
//							if(gsオプション[14].Equals("1")){
//								cr = new 出荷実績帳票３();
//							}
//						}
					}
					//CrystalReportにパラメータとデータセットを渡す
					cr.SetParameterValue("部門ＣＤ", gs部門ＣＤ);
					cr.SetParameterValue("部門名",   gs部門名);
					cr.SetParameterValue("ご依頼主印字なし"
										, cBoxご依頼主印字なし.Checked);
					cr.SetParameterValue("運賃印字なし"
										, cBox運賃印字なし.Checked);
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 END
					cr.SetParameterValue("社名あり", false);
					if(gsオプション[0].Length == 4){
						if(gsオプション[16].Equals("1")){
							cr.SetParameterValue("社名あり", true);
						}
					}
					switch(i出力形式){
					case 1:		// ご依頼主別
						cr.SetParameterValue("サブタイトル", "（ご依頼主別）");
						break;
					case 2:		// 請求先別
						cr.SetParameterValue("サブタイトル", "（請求先別）");
						break;
					case 3:		// お届け先別
						cr.SetParameterValue("サブタイトル", "（お届け先別）");
						break;
					default:
						cr.SetParameterValue("サブタイトル", "");
						break;
					}
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 END
					cr.SetDataSource(ds);
// MOD 2009.05.01 東都）高木 オプションの項目追加 END

					//プレビュー表示
					プレビュー画面 画面 = new プレビュー画面();
					画面.Left = this.Left;
					画面.Top = this.Top;
					画面.crv帳票.PrintReport();
// ADD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 START
					画面.crv帳票.ReportSource = cr;
//					if(rb２行.Checked){
//						画面.crv帳票.ReportSource = cr2;
//					}else{
//						画面.crv帳票.ReportSource = cr;
//					}
// ADD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 END
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
					if(sRet[0].Equals("該当データがありません"))
					{
						texメッセージ.Text = "";
						ビープ音();
						MessageBox.Show("該当データがありません","出荷実績",MessageBoxButtons.OK);
					}
					else
					{
						texメッセージ.Text = sRet[0];
						ビープ音();
					}
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

// ADD 2006.08.09 東都）山本 検索条件に依頼主を追加 START
		private void btn依頼主検索_Click(object sender, System.EventArgs e)
		{
//			tex依頼主コード.Text = tex依頼主コード.Text.Trim();
//			if(!半角チェック(tex依頼主コード,"依頼主コード")) return;

			if (g依頼検索 == null)	 g依頼検索 = new ご依頼主検索();
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 START
//			g依頼検索.Left = this.Left - 203;
//			g依頼検索.Top = this.Top  - 116;
			g依頼検索.Left = this.Left;
			g依頼検索.Top  = this.Top;
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 END

			g依頼検索.sIcode = "";
			g依頼検索.ShowDialog();

			s依頼主ＣＤ = g依頼検索.sIcode;
			s依頼主名   = g依頼検索.sIname;
			if(s依頼主ＣＤ.Length > 0)
			{
				tex依頼主コード.Text = s依頼主ＣＤ;
				tex依頼主名.Text     = s依頼主名;
				cmb出荷日.Focus();
			}
			else
				tex依頼主コード.Focus();
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

		private void tex依頼主コード_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn依頼主検索.Focus();
				btn依頼主検索_Click(sender,e);
				e.Handled = true;
			}		
		
		}

		private void 依頼主検索()
		{
			if(s依頼主ＣＤ.Trim().Length == 0) return;
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
						tex依頼主名.Text     = "";
						texメッセージ.Text = "該当依頼主コード無し";
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
			catch (System.Net.WebException)
			{
				texメッセージ.Text = gs通信エラー;
				ビープ音();
			}
			catch (Exception ex)
			{
				texメッセージ.Text = "通信エラー：" + ex.Message;
				ビープ音();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;

		}
// ADD 2006.08.09 東都）山本 検索条件に依頼主を追加 END

// MOD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 START
		private void rb８行_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rb８行.Checked){
				cbお届け先住所印刷.Checked = false;
//				cbお届け先住所印刷.ForeColor = System.Drawing.Color.White;
//				cbお届け先住所印刷.BackColor = System.Drawing.SystemColors.Window;
				cbお届け先住所印刷.Enabled = false;
				cbお届け先住所印刷.Visible = false;
//				cbお届け先住所印刷.Refresh();
			}
			else
			{
//				cbお届け先住所印刷.ForeColor = System.Drawing.Color.LimeGreen;
//				cbお届け先住所印刷.BackColor = System.Drawing.Color.Honeydew;
				cbお届け先住所印刷.Enabled = true;
				cbお届け先住所印刷.Visible = true;
//				cbお届け先住所印刷.Refresh();
			}
		}
// MOD 2009.01.30 東都）高木 実績一覧印刷オプション項目の追加 END
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 START
		private void 出力形式クリア()
		{
			if(rbご依頼主別.Checked == false){
				tex依頼主コード.Text     = "";
				tex依頼主名.Text         = "";
				btn依頼主検索.Enabled    = false;
//				tex依頼主コード.BackColor = Color.LightGray;
				tex依頼主コード.BackColor = Color.FromArgb(239,233,217);
				tex依頼主コード.Enabled  = false;
				s依頼主ＣＤ = "";
				s依頼主名   = "";
			}else{
				btn依頼主検索.Enabled    = true;
				tex依頼主コード.BackColor = Color.White;
				tex依頼主コード.Enabled  = true;
			}
			if(rb請求先別.Checked   == false){
				cmb請求先.SelectedIndex  = 0;
				s請求先ＣＤ              = "";
				s部課ＣＤ                = "";
				tex請求先コード.Text     = "";
				cmb請求先.Enabled        = false;
				tex請求先コード.Enabled  = false;
			}else{
				cmb請求先.Enabled        = true;
				tex請求先コード.Enabled  = true;
			}
			if(rbお届け先別.Checked == false){
				tex届け先コード.Text     = "";
				tex届け先名.Text         = "";
				s届け先ＣＤ = "";
				s届け先名   = "";
				btn届け先検索.Enabled    = false;
//				tex届け先コード.BackColor = Color.LightGray;
				tex届け先コード.BackColor = Color.FromArgb(239,233,217);
				tex届け先コード.Enabled  = false;
			}else{
				btn届け先検索.Enabled    = true;
				tex届け先コード.BackColor = Color.White;
				tex届け先コード.Enabled  = true;
			}
		}
		private void rb指定なし_CheckedChanged(object sender, System.EventArgs e)
		{
			出力形式クリア();
		}

		private void rbご依頼主別_CheckedChanged(object sender, System.EventArgs e)
		{
			出力形式クリア();
		}

		private void rb請求先別_CheckedChanged(object sender, System.EventArgs e)
		{
			出力形式クリア();
		}

		private void rbお届け先別_CheckedChanged(object sender, System.EventArgs e)
		{
			出力形式クリア();
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
//						tex依頼主コード.Focus();
					}
					else
					{
						texメッセージ.Text = "";
//						tex依頼主コード.Focus();
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
			catch (System.Net.WebException)
			{
				texメッセージ.Text = gs通信エラー;
				ビープ音();
			}
			catch (Exception ex)
			{
				texメッセージ.Text = "通信エラー：" + ex.Message;
				ビープ音();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void btn届け先検索_Click(object sender, System.EventArgs e)
		{
//			tex届け先コード.Text = tex届け先コード.Text.Trim();
//			if(!半角チェック(tex届け先コード,"届け先コード")) return;

			if(g届先検索 == null) g届先検索 = new お届け先検索();
			g届先検索.Left = this.Left;
			g届先検索.Top  = this.Top;

			g届先検索.sTcode = "";
			g届先検索.ShowDialog();

			s届け先ＣＤ = g届先検索.sTcode;
			s届け先名   = g届先検索.sTname;

			if(s届け先ＣＤ.Length > 0){
				tex届け先コード.Text = s届け先ＣＤ;
				tex届け先名.Text     = s届け先名;
//				tex依頼主コード.Focus();
				cmb出荷日.Focus();
			}else{
				tex届け先コード.Focus();
			}
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

		private void cmb請求先_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			s請求先ＣＤ = "";
			s部課ＣＤ   = "";
			tex請求先コード.Text = "";
			if(gsa請求先ＣＤ.Length > 0 && cmb請求先.SelectedIndex > 0){
				s請求先ＣＤ = gsa請求先ＣＤ[cmb請求先.SelectedIndex - 1];
				s部課ＣＤ   = gsa請求先部課ＣＤ[cmb請求先.SelectedIndex - 1];
				tex請求先コード.Text = s請求先ＣＤ.Trim() + " " + s部課ＣＤ.Trim();
			}
		}
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 END
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 START
		private void 出力オプション情報設定()
		{
			//[未発行分を除く]チェックボックス
			if(gs出荷実績_未発行分除外 != null)
			{
				if(gs出荷実績_未発行分除外 == "1")
				{
					cBox未発行分を除く.Checked = true;
				}
				else
				{
					cBox未発行分を除く.Checked = false;
				}
			}
			//[網掛けなし（印刷のみ）]チェックボックス
			if(gs出荷実績_網掛けなし_印刷のみ != null)
			{
				if(gs出荷実績_網掛けなし_印刷のみ == "1")
				{
					cBox網掛けなし.Checked = true;
				}
				else
				{
					cBox網掛けなし.Checked = false;
				}
			}
			//[ご依頼主印字なし（印刷のみ）]チェックボックス
			if(gs出荷実績_ご依頼主印字なし_印刷のみ != null)
			{
				if(gs出荷実績_ご依頼主印字なし_印刷のみ == "1")
				{
					cBoxご依頼主印字なし.Checked = true;
				}
				else
				{
					cBoxご依頼主印字なし.Checked = false;
				}
			}
			//[運賃印字なし（印刷のみ）]チェックボックス
			if(gs出荷実績_運賃印字なし_印刷のみ != null)
			{
				if(gs出荷実績_運賃印字なし_印刷のみ == "1")
				{
					cBox運賃印字なし.Checked = true;
				}
				else
				{
					cBox運賃印字なし.Checked = false;
				}
			}
			//[末尾に発店コード・発店名を出力する（ＣＳＶのみ）]チェックボックス
			if(gs出荷実績_発店出力_ＣＳＶのみ != null)
			{
				if(gs出荷実績_発店出力_ＣＳＶのみ == "1")
				{
					cBox発店ＣＤ出力.Checked = true;
				}
				else
				{
					cBox発店ＣＤ出力.Checked = false;
				}
			}
			//[配完日付・時刻を出力する]チェックボックス
			if(gs出荷実績_配完日時出力 != null)
			{
				if(gs出荷実績_配完日時出力 == "1")
				{
					cBox配完Ｓ出力.Checked = true;
				}
				else
				{
					cBox配完Ｓ出力.Checked = false;
				}
			}
		}

		private void 出力オプション情報保存()
		{
			//[未発行分を除く]チェックボックス
			if(cBox未発行分を除く.Checked)
			{
				gs出荷実績_未発行分除外 = "1";
			}
			else
			{
				gs出荷実績_未発行分除外 = "0";
			}
			//[網掛けなし（印刷のみ）]チェックボックス
			if(cBox網掛けなし.Checked)
			{
				gs出荷実績_網掛けなし_印刷のみ = "1";
			}
			else
			{
				gs出荷実績_網掛けなし_印刷のみ = "0";
			}
			//[ご依頼主印字なし（印刷のみ）]チェックボックス
			if(cBoxご依頼主印字なし.Checked)
			{
				gs出荷実績_ご依頼主印字なし_印刷のみ = "1";
			}
			else
			{
				gs出荷実績_ご依頼主印字なし_印刷のみ = "0";
			}
			//[運賃印字なし（印刷のみ）]チェックボックス
			if(cBox運賃印字なし.Checked)
			{
				gs出荷実績_運賃印字なし_印刷のみ = "1";
			}
			else
			{
				gs出荷実績_運賃印字なし_印刷のみ = "0";
			}
			//[末尾に発店コード・発店名を出力する（ＣＳＶのみ）]チェックボックス
			if(cBox発店ＣＤ出力.Checked)
			{
				gs出荷実績_発店出力_ＣＳＶのみ = "1";
			}
			else
			{
				gs出荷実績_発店出力_ＣＳＶのみ = "0";
			}
			//[配完日付・時刻を出力する]チェックボックス
			if(cBox配完Ｓ出力.Checked)
			{
				gs出荷実績_配完日時出力 = "1";
			}
			else
			{
				gs出荷実績_配完日時出力 = "0";
			}
		}
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 END
	}
}
