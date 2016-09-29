using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [ライブラリ登録]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// ADD 2008.04.25 東都）高木 品名記事の最大桁数を設定
	// ＡＣＴ）山本殿より障害報告有
	// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 
	//--------------------------------------------------------------------------
	// MOD 2009.05.01 東都）高木 オプションの項目追加 
	// MOD 2009.08.20 パソ）藤井 郵便番号の値引継ぎ 
	// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 
	// MOD 2009.09.04 東都）高木 Vista対応(TAB対応もれ) 
	// MOD 2009.09.09 東都）高木 前回検索依頼主ＣＤのクリアもれ対応 
	// MOD 2009.09.09 東都）高木 画面表示不具合の調整 
	// MOD 2009.12.01 東都）高木 全角半角混在可能にする 
	//--------------------------------------------------------------------------
	// MOD 2010.05.25 東都）高木 時間指定の変更 
	// MOD 2010.09.07 東都）高木 請求先チェックの表示変更 
	// MOD 2010.09.24 東都）高木 重量自動計算時の上限エラー対応 
	// MOD 2010.09.27 東都）高木 請求先部課名の追加 
	// MOD 2010.10.04 東都）高木 担当者（依頼主部署）フォーカス障害対応 
	// MOD 2010.11.01 東都）高木 ご依頼主情報の重量値０対応 
	// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 
	// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない 
	// MOD 2011.04.13 東都）高木 重量入力不可対応 
	// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 
	// MOD 2011.06.07 東都）高木 王子運送の対応 
	// MOD 2011.07.14 東都）高木 記事行の追加 
	// MOD 2011.07.25 東都）高木 各項目の入力不可対応 
	// MOD 2011.07.28 東都）高木 記事行の追加（文字数制限の追加） 
	// MOD 2011.08.02 東都）高木 各項目の入力不可対応（不具合調整） 
	// MOD 2011.08.05 東都）高木 記事行の追加（３行・６行切替対応） 
	// MOD 2011.09.26 東都）高木 記事行の追加（３行・６行切替対応） 
	// MOD 2011.12.08 東都）高木 住所・名前の半角入力可 
	//--------------------------------------------------------------------------
	// MOD 2015.05.07 BEVAS) 前田 王子荷主様の郵便番号存在チェックをCM14Jで行う
	// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応
	//--------------------------------------------------------------------------
	// MOD 2016.06.10 BEVAS）松本 保険料入力チェック機能の追加（31万円以上の場合）
	//--------------------------------------------------------------------------
	public class 雛型登録 : 共通フォーム
	{
		// 雛型出荷照会からジャンプした場合に使用
		public int    i雛型ＮＯ       = 0;
		public string s雛型名称       = "";
		// 出荷照会一覧からジャンプした場合に使用
		public string s登録日         = "";
		public string sジャーナルＮＯ = "";
		// 内部変数
		private bool   b更新ＦＧ      = false;
		private string sファイル名    = "";
		private string s更新年月日    = "";
		private string s届け先ＣＤ    = "";
		private string s依頼主ＣＤ    = "";
		private string s前回検索依頼主ＣＤ = "";
		private int      iアクティブＦＧ = 0;
// ADD 2005.05.13 東都）小童谷 依頼主重量 START
		private decimal d重量 = 0;
// ADD 2005.05.13 東都）小童谷 依頼主重量 END
// ADD 2005.05.17 東都）小童谷 才数 START
		private string s重量     = "";
		private string s才数     = "";
		private int    i才数ＦＧ = 1;
		private int    i才数保持 = 1;
// ADD 2005.05.17 東都）小童谷 才数 END
		private string s輸送商品親コード = "";
		private string s輸送商品子コード = "";
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 START
		private string s修正前_依頼主ＣＤ = ""; //
		private string s修正前_請求先ＣＤ = ""; //
		private string s修正前_請求先部課 = ""; //請求先部課ＣＤ
		private string s修正前_請求先名   = ""; //
		private string s修正前_個数       = ""; //
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 END
// MOD 2011.07.25 東都）高木 各項目の入力不可対応 START
		private string s画面制御_重量 = "0";
// MOD 2011.07.25 東都）高木 各項目の入力不可対応 END

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab日時;
		private 共通テキストボックス tex雛型名;
		private System.Windows.Forms.TextBox texお客様名;
		private System.Windows.Forms.Label labお客様名;
		private System.Windows.Forms.Label lab利用部門;
		private System.Windows.Forms.TextBox tex利用部門;
		private System.Windows.Forms.Label lab雛型登録タイトル;
		private 共通テキストボックス tex届け先コード;
		private 共通テキストボックス tex届け先電話番号１;
		private 共通テキストボックス tex届け先名前２;
		private 共通テキストボックス tex届け先名前１;
		private 共通テキストボックス tex届け先住所３;
		private 共通テキストボックス２ tex届け先郵便番号２;
		private 共通テキストボックス tex届け先郵便番号１;
		private 共通テキストボックス tex届け先電話番号３;
		private 共通テキストボックス tex届け先電話番号２;
		private 共通テキストボックス tex届け先住所２;
		private 共通テキストボックス tex届け先住所１;
		private System.Windows.Forms.TextBox tex依頼主請求先;
		private 共通テキストボックス tex依頼主部署;
		private System.Windows.Forms.TextBox tex依頼主名前２;
		private System.Windows.Forms.TextBox tex依頼主名前１;
		private System.Windows.Forms.TextBox tex依頼主郵便番号２;
		private System.Windows.Forms.TextBox tex依頼主郵便番号１;
		private System.Windows.Forms.TextBox tex依頼主電話番号３;
		private System.Windows.Forms.TextBox tex依頼主電話番号２;
		private System.Windows.Forms.TextBox tex依頼主電話番号１;
		private System.Windows.Forms.TextBox tex依頼主住所２;
		private System.Windows.Forms.TextBox tex依頼主住所１;
		private 共通テキストボックス tex依頼主コード;
		private 共通テキストボックス tex輸送名子;
		private 共通テキストボックス tex輸送名親;
		private 共通テキストボックス tex記事名３;
		private 共通テキストボックス tex記事名２;
		private 共通テキストボックス tex記事名１;
		private 共通テキストボックス tex輸送コード親;
		private 共通テキストボックス tex記事コード;
		private System.Windows.Forms.NumericUpDown nUD重量;
		private System.Windows.Forms.NumericUpDown nUD保険金額;
		private System.Windows.Forms.NumericUpDown nUD個数;
		private System.Windows.Forms.NumericUpDown nUD登録番号;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.Button btn削除;
		private System.Windows.Forms.Button btn取消;
		private System.Windows.Forms.Button btn更新;
		private System.Windows.Forms.Button btn届け先検索;
		private System.Windows.Forms.Button btn住所検索;
		private System.Windows.Forms.Button btn複写;
		private System.Windows.Forms.Button btn依頼主検索;
		private System.Windows.Forms.Button btn記事検索;
		private System.Windows.Forms.Button btn輸送検索;
		private System.Windows.Forms.Button btnアイコン;
		private System.Windows.Forms.Label lab届け先名前;
		private System.Windows.Forms.Label lab届け先住所;
		private System.Windows.Forms.Label lab届け先郵便番号;
		private System.Windows.Forms.Label lab届け先電話番号;
		private System.Windows.Forms.Label lab届け先コード;
		private System.Windows.Forms.Label lab依頼主部署;
		private System.Windows.Forms.Label lab依頼主名前;
		private System.Windows.Forms.Label lab依頼主住所;
		private System.Windows.Forms.Label lab依頼主郵便番号;
		private System.Windows.Forms.Label lab依頼主電話番号;
		private System.Windows.Forms.Label lab依頼主コード;
		private System.Windows.Forms.Label lab依頼主請求先;
		private System.Windows.Forms.Label lab輸送コード;
		private System.Windows.Forms.Label lab輸送指示;
		private System.Windows.Forms.Label lab記事コード;
		private System.Windows.Forms.Label lab記事;
		private System.Windows.Forms.Label lab重量;
		private System.Windows.Forms.Label lab保険金額;
		private System.Windows.Forms.Label lab個数;
		private System.Windows.Forms.Label lab登録番号;
		private System.Windows.Forms.Label lab雛型名;
		private System.Windows.Forms.Label labアイコン設定;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBox6;
		private IS2Client.共通テキストボックス tex輸送コード子;
		private System.Windows.Forms.TextBox tex請求先部課コード;
		private System.Windows.Forms.Label lab請求先コード;
		private System.Windows.Forms.TextBox tex請求先コード;
		private IS2Client.共通テキストボックス tex記事名６;
		private IS2Client.共通テキストボックス tex記事名５;
		private IS2Client.共通テキストボックス tex記事名４;
		private System.Windows.Forms.Button btn支店止め;
		private System.Windows.Forms.Button btn支店止め解除;
		private System.ComponentModel.IContainer components;

		public 雛型登録()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(雛型登録));
			this.tex届け先コード = new IS2Client.共通テキストボックス();
			this.tex届け先電話番号１ = new IS2Client.共通テキストボックス();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btn支店止め解除 = new System.Windows.Forms.Button();
			this.btn支店止め = new System.Windows.Forms.Button();
			this.btn複写 = new System.Windows.Forms.Button();
			this.label40 = new System.Windows.Forms.Label();
			this.label35 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.tex届け先名前２ = new IS2Client.共通テキストボックス();
			this.lab届け先名前 = new System.Windows.Forms.Label();
			this.tex届け先名前１ = new IS2Client.共通テキストボックス();
			this.btn住所検索 = new System.Windows.Forms.Button();
			this.tex届け先住所３ = new IS2Client.共通テキストボックス();
			this.lab届け先住所 = new System.Windows.Forms.Label();
			this.tex届け先郵便番号２ = new IS2Client.共通テキストボックス２();
			this.tex届け先郵便番号１ = new IS2Client.共通テキストボックス();
			this.label8 = new System.Windows.Forms.Label();
			this.lab届け先郵便番号 = new System.Windows.Forms.Label();
			this.tex届け先電話番号３ = new IS2Client.共通テキストボックス();
			this.tex届け先電話番号２ = new IS2Client.共通テキストボックス();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lab届け先電話番号 = new System.Windows.Forms.Label();
			this.lab届け先コード = new System.Windows.Forms.Label();
			this.tex届け先住所２ = new IS2Client.共通テキストボックス();
			this.tex届け先住所１ = new IS2Client.共通テキストボックス();
			this.btn届け先検索 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tex請求先部課コード = new System.Windows.Forms.TextBox();
			this.lab請求先コード = new System.Windows.Forms.Label();
			this.tex請求先コード = new System.Windows.Forms.TextBox();
			this.tex依頼主電話番号１ = new System.Windows.Forms.TextBox();
			this.tex依頼主請求先 = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.lab依頼主部署 = new System.Windows.Forms.Label();
			this.lab依頼主名前 = new System.Windows.Forms.Label();
			this.lab依頼主住所 = new System.Windows.Forms.Label();
			this.lab依頼主郵便番号 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.lab依頼主電話番号 = new System.Windows.Forms.Label();
			this.tex依頼主部署 = new IS2Client.共通テキストボックス();
			this.tex依頼主名前２ = new System.Windows.Forms.TextBox();
			this.tex依頼主名前１ = new System.Windows.Forms.TextBox();
			this.tex依頼主郵便番号２ = new System.Windows.Forms.TextBox();
			this.tex依頼主郵便番号１ = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.tex依頼主電話番号３ = new System.Windows.Forms.TextBox();
			this.tex依頼主電話番号２ = new System.Windows.Forms.TextBox();
			this.lab依頼主コード = new System.Windows.Forms.Label();
			this.tex依頼主住所２ = new System.Windows.Forms.TextBox();
			this.tex依頼主住所１ = new System.Windows.Forms.TextBox();
			this.btn依頼主検索 = new System.Windows.Forms.Button();
			this.label21 = new System.Windows.Forms.Label();
			this.tex依頼主コード = new IS2Client.共通テキストボックス();
			this.lab依頼主請求先 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.tex記事名６ = new IS2Client.共通テキストボックス();
			this.tex記事名５ = new IS2Client.共通テキストボックス();
			this.tex記事名４ = new IS2Client.共通テキストボックス();
			this.tex輸送名子 = new IS2Client.共通テキストボックス();
			this.tex輸送名親 = new IS2Client.共通テキストボックス();
			this.tex記事名３ = new IS2Client.共通テキストボックス();
			this.tex記事名２ = new IS2Client.共通テキストボックス();
			this.tex記事名１ = new IS2Client.共通テキストボックス();
			this.btn輸送検索 = new System.Windows.Forms.Button();
			this.tex輸送コード親 = new IS2Client.共通テキストボックス();
			this.lab輸送コード = new System.Windows.Forms.Label();
			this.lab輸送指示 = new System.Windows.Forms.Label();
			this.btn記事検索 = new System.Windows.Forms.Button();
			this.tex記事コード = new IS2Client.共通テキストボックス();
			this.lab記事コード = new System.Windows.Forms.Label();
			this.lab記事 = new System.Windows.Forms.Label();
			this.tex輸送コード子 = new IS2Client.共通テキストボックス();
			this.panel4 = new System.Windows.Forms.Panel();
			this.lab重量 = new System.Windows.Forms.Label();
			this.nUD重量 = new System.Windows.Forms.NumericUpDown();
			this.nUD保険金額 = new System.Windows.Forms.NumericUpDown();
			this.lab保険金額 = new System.Windows.Forms.Label();
			this.nUD個数 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.lab個数 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.nUD登録番号 = new System.Windows.Forms.NumericUpDown();
			this.lab登録番号 = new System.Windows.Forms.Label();
			this.tex雛型名 = new IS2Client.共通テキストボックス();
			this.lab雛型名 = new System.Windows.Forms.Label();
			this.btnアイコン = new System.Windows.Forms.Button();
			this.panel6 = new System.Windows.Forms.Panel();
			this.texお客様名 = new System.Windows.Forms.TextBox();
			this.labお客様名 = new System.Windows.Forms.Label();
			this.lab利用部門 = new System.Windows.Forms.Label();
			this.tex利用部門 = new System.Windows.Forms.TextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab日時 = new System.Windows.Forms.Label();
			this.lab雛型登録タイトル = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn削除 = new System.Windows.Forms.Button();
			this.btn取消 = new System.Windows.Forms.Button();
			this.btn更新 = new System.Windows.Forms.Button();
			this.texメッセージ = new System.Windows.Forms.TextBox();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panel9 = new System.Windows.Forms.Panel();
			this.labアイコン設定 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nUD重量)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD保険金額)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD個数)).BeginInit();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nUD登録番号)).BeginInit();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel9.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// tex届け先コード
			// 
			this.tex届け先コード.BackColor = System.Drawing.SystemColors.Window;
			this.tex届け先コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex届け先コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex届け先コード.Location = new System.Drawing.Point(110, 2);
			this.tex届け先コード.MaxLength = 15;
			this.tex届け先コード.Name = "tex届け先コード";
			this.tex届け先コード.Size = new System.Drawing.Size(172, 23);
			this.tex届け先コード.TabIndex = 0;
			this.tex届け先コード.Text = "";
			this.tex届け先コード.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex届け先コード_KeyDown);
			this.tex届け先コード.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex届け先コード_KeyPress);
			// 
			// tex届け先電話番号１
			// 
			this.tex届け先電話番号１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex届け先電話番号１.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex届け先電話番号１.Location = new System.Drawing.Point(110, 28);
			this.tex届け先電話番号１.MaxLength = 6;
			this.tex届け先電話番号１.Name = "tex届け先電話番号１";
			this.tex届け先電話番号１.Size = new System.Drawing.Size(58, 23);
			this.tex届け先電話番号１.TabIndex = 2;
			this.tex届け先電話番号１.Text = "";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Honeydew;
			this.panel1.Controls.Add(this.btn支店止め解除);
			this.panel1.Controls.Add(this.btn支店止め);
			this.panel1.Controls.Add(this.btn複写);
			this.panel1.Controls.Add(this.label40);
			this.panel1.Controls.Add(this.label35);
			this.panel1.Controls.Add(this.label34);
			this.panel1.Controls.Add(this.label31);
			this.panel1.Controls.Add(this.tex届け先名前２);
			this.panel1.Controls.Add(this.lab届け先名前);
			this.panel1.Controls.Add(this.tex届け先名前１);
			this.panel1.Controls.Add(this.btn住所検索);
			this.panel1.Controls.Add(this.tex届け先住所３);
			this.panel1.Controls.Add(this.lab届け先住所);
			this.panel1.Controls.Add(this.tex届け先郵便番号２);
			this.panel1.Controls.Add(this.tex届け先郵便番号１);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.lab届け先郵便番号);
			this.panel1.Controls.Add(this.tex届け先電話番号３);
			this.panel1.Controls.Add(this.tex届け先電話番号２);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.tex届け先電話番号１);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.lab届け先電話番号);
			this.panel1.Controls.Add(this.lab届け先コード);
			this.panel1.Controls.Add(this.tex届け先住所２);
			this.panel1.Controls.Add(this.tex届け先住所１);
			this.panel1.Controls.Add(this.btn届け先検索);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.tex届け先コード);
			this.panel1.Location = new System.Drawing.Point(0, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(448, 202);
			this.panel1.TabIndex = 1;
			// 
			// btn支店止め解除
			// 
			this.btn支店止め解除.BackColor = System.Drawing.Color.SteelBlue;
			this.btn支店止め解除.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn支店止め解除.ForeColor = System.Drawing.Color.White;
			this.btn支店止め解除.Location = new System.Drawing.Point(302, 54);
			this.btn支店止め解除.Name = "btn支店止め解除";
			this.btn支店止め解除.Size = new System.Drawing.Size(78, 22);
			this.btn支店止め解除.TabIndex = 39;
			this.btn支店止め解除.TabStop = false;
			this.btn支店止め解除.Text = "支店止解除";
			this.btn支店止め解除.Visible = false;
			this.btn支店止め解除.Click += new System.EventHandler(this.btn支店止め解除_Click);
			// 
			// btn支店止め
			// 
			this.btn支店止め.BackColor = System.Drawing.Color.SteelBlue;
			this.btn支店止め.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn支店止め.ForeColor = System.Drawing.Color.White;
			this.btn支店止め.Location = new System.Drawing.Point(302, 54);
			this.btn支店止め.Name = "btn支店止め";
			this.btn支店止め.Size = new System.Drawing.Size(52, 22);
			this.btn支店止め.TabIndex = 38;
			this.btn支店止め.TabStop = false;
			this.btn支店止め.Text = "支店止";
			this.btn支店止め.Click += new System.EventHandler(this.btn支店止め_Click);
			// 
			// btn複写
			// 
			this.btn複写.BackColor = System.Drawing.Color.SteelBlue;
			this.btn複写.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn複写.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn複写.ForeColor = System.Drawing.Color.White;
			this.btn複写.Location = new System.Drawing.Point(252, 54);
			this.btn複写.Name = "btn複写";
			this.btn複写.Size = new System.Drawing.Size(48, 22);
			this.btn複写.TabIndex = 8;
			this.btn複写.TabStop = false;
			this.btn複写.Text = "複写";
			this.btn複写.Click += new System.EventHandler(this.btn複写_Click);
			// 
			// label40
			// 
			this.label40.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label40.ForeColor = System.Drawing.Color.Red;
			this.label40.Location = new System.Drawing.Point(26, 84);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(16, 14);
			this.label40.TabIndex = 37;
			this.label40.Text = "※";
			// 
			// label35
			// 
			this.label35.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label35.ForeColor = System.Drawing.Color.Red;
			this.label35.Location = new System.Drawing.Point(26, 154);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(16, 14);
			this.label35.TabIndex = 29;
			this.label35.Text = "※";
			// 
			// label34
			// 
			this.label34.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label34.ForeColor = System.Drawing.Color.Red;
			this.label34.Location = new System.Drawing.Point(26, 58);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(16, 14);
			this.label34.TabIndex = 28;
			this.label34.Text = "※";
			// 
			// label31
			// 
			this.label31.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label31.ForeColor = System.Drawing.Color.Red;
			this.label31.Location = new System.Drawing.Point(26, 34);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(16, 14);
			this.label31.TabIndex = 27;
			this.label31.Text = "※";
			// 
			// tex届け先名前２
			// 
			this.tex届け先名前２.BackColor = System.Drawing.SystemColors.Window;
			this.tex届け先名前２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex届け先名前２.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex届け先名前２.Location = new System.Drawing.Point(110, 172);
			this.tex届け先名前２.MaxLength = 20;
			this.tex届け先名前２.Name = "tex届け先名前２";
			this.tex届け先名前２.Size = new System.Drawing.Size(330, 23);
			this.tex届け先名前２.TabIndex = 13;
			this.tex届け先名前２.Text = "";
			// 
			// lab届け先名前
			// 
			this.lab届け先名前.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab届け先名前.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab届け先名前.Location = new System.Drawing.Point(40, 154);
			this.lab届け先名前.Name = "lab届け先名前";
			this.lab届け先名前.Size = new System.Drawing.Size(56, 14);
			this.lab届け先名前.TabIndex = 24;
			this.lab届け先名前.Text = "名前";
			// 
			// tex届け先名前１
			// 
			this.tex届け先名前１.BackColor = System.Drawing.SystemColors.Window;
			this.tex届け先名前１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex届け先名前１.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex届け先名前１.Location = new System.Drawing.Point(110, 150);
			this.tex届け先名前１.MaxLength = 20;
			this.tex届け先名前１.Name = "tex届け先名前１";
			this.tex届け先名前１.Size = new System.Drawing.Size(330, 23);
			this.tex届け先名前１.TabIndex = 12;
			this.tex届け先名前１.Text = "";
			// 
			// btn住所検索
			// 
			this.btn住所検索.BackColor = System.Drawing.Color.SteelBlue;
			this.btn住所検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn住所検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn住所検索.ForeColor = System.Drawing.Color.White;
			this.btn住所検索.Location = new System.Drawing.Point(202, 54);
			this.btn住所検索.Name = "btn住所検索";
			this.btn住所検索.Size = new System.Drawing.Size(48, 22);
			this.btn住所検索.TabIndex = 7;
			this.btn住所検索.TabStop = false;
			this.btn住所検索.Text = "検索";
			this.btn住所検索.Click += new System.EventHandler(this.btn住所検索_Click);
			// 
			// tex届け先住所３
			// 
			this.tex届け先住所３.BackColor = System.Drawing.SystemColors.Window;
			this.tex届け先住所３.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex届け先住所３.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex届け先住所３.Location = new System.Drawing.Point(110, 124);
			this.tex届け先住所３.MaxLength = 20;
			this.tex届け先住所３.Name = "tex届け先住所３";
			this.tex届け先住所３.Size = new System.Drawing.Size(330, 23);
			this.tex届け先住所３.TabIndex = 11;
			this.tex届け先住所３.Text = "";
			// 
			// lab届け先住所
			// 
			this.lab届け先住所.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab届け先住所.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab届け先住所.Location = new System.Drawing.Point(40, 84);
			this.lab届け先住所.Name = "lab届け先住所";
			this.lab届け先住所.Size = new System.Drawing.Size(56, 14);
			this.lab届け先住所.TabIndex = 19;
			this.lab届け先住所.Text = "住所";
			// 
			// tex届け先郵便番号２
			// 
			this.tex届け先郵便番号２.AcceptsTab = true;
			this.tex届け先郵便番号２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex届け先郵便番号２.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex届け先郵便番号２.Location = new System.Drawing.Point(160, 54);
			this.tex届け先郵便番号２.MaxLength = 4;
			this.tex届け先郵便番号２.Name = "tex届け先郵便番号２";
			this.tex届け先郵便番号２.Size = new System.Drawing.Size(40, 23);
			this.tex届け先郵便番号２.TabIndex = 6;
			this.tex届け先郵便番号２.Text = "";
			this.tex届け先郵便番号２.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex届け先郵便番号２_KeyDown);
			this.tex届け先郵便番号２.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex届け先郵便番号２_KeyPress);
			// 
			// tex届け先郵便番号１
			// 
			this.tex届け先郵便番号１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex届け先郵便番号１.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex届け先郵便番号１.Location = new System.Drawing.Point(110, 54);
			this.tex届け先郵便番号１.MaxLength = 3;
			this.tex届け先郵便番号１.Name = "tex届け先郵便番号１";
			this.tex届け先郵便番号１.Size = new System.Drawing.Size(34, 23);
			this.tex届け先郵便番号１.TabIndex = 5;
			this.tex届け先郵便番号１.Text = "";
			this.tex届け先郵便番号１.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex届け先郵便番号１_KeyPress);
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label8.ForeColor = System.Drawing.Color.LimeGreen;
			this.label8.Location = new System.Drawing.Point(146, 60);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(12, 14);
			this.label8.TabIndex = 17;
			this.label8.Text = "－";
			// 
			// lab届け先郵便番号
			// 
			this.lab届け先郵便番号.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab届け先郵便番号.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab届け先郵便番号.Location = new System.Drawing.Point(40, 58);
			this.lab届け先郵便番号.Name = "lab届け先郵便番号";
			this.lab届け先郵便番号.Size = new System.Drawing.Size(56, 14);
			this.lab届け先郵便番号.TabIndex = 15;
			this.lab届け先郵便番号.Text = "郵便番号";
			// 
			// tex届け先電話番号３
			// 
			this.tex届け先電話番号３.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex届け先電話番号３.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex届け先電話番号３.Location = new System.Drawing.Point(238, 28);
			this.tex届け先電話番号３.MaxLength = 4;
			this.tex届け先電話番号３.Name = "tex届け先電話番号３";
			this.tex届け先電話番号３.Size = new System.Drawing.Size(38, 23);
			this.tex届け先電話番号３.TabIndex = 4;
			this.tex届け先電話番号３.Text = "";
			// 
			// tex届け先電話番号２
			// 
			this.tex届け先電話番号２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex届け先電話番号２.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex届け先電話番号２.Location = new System.Drawing.Point(182, 28);
			this.tex届け先電話番号２.MaxLength = 4;
			this.tex届け先電話番号２.Name = "tex届け先電話番号２";
			this.tex届け先電話番号２.Size = new System.Drawing.Size(38, 23);
			this.tex届け先電話番号２.TabIndex = 3;
			this.tex届け先電話番号２.Text = "";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label6.ForeColor = System.Drawing.Color.LimeGreen;
			this.label6.Location = new System.Drawing.Point(222, 34);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(12, 14);
			this.label6.TabIndex = 13;
			this.label6.Text = "－";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label5.ForeColor = System.Drawing.Color.LimeGreen;
			this.label5.Location = new System.Drawing.Point(168, 34);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(12, 14);
			this.label5.TabIndex = 11;
			this.label5.Text = "）";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label4.ForeColor = System.Drawing.Color.LimeGreen;
			this.label4.Location = new System.Drawing.Point(100, 34);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 14);
			this.label4.TabIndex = 10;
			this.label4.Text = "（";
			// 
			// lab届け先電話番号
			// 
			this.lab届け先電話番号.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab届け先電話番号.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab届け先電話番号.Location = new System.Drawing.Point(40, 34);
			this.lab届け先電話番号.Name = "lab届け先電話番号";
			this.lab届け先電話番号.Size = new System.Drawing.Size(56, 14);
			this.lab届け先電話番号.TabIndex = 9;
			this.lab届け先電話番号.Text = "電話番号";
			// 
			// lab届け先コード
			// 
			this.lab届け先コード.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab届け先コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab届け先コード.Location = new System.Drawing.Point(40, 6);
			this.lab届け先コード.Name = "lab届け先コード";
			this.lab届け先コード.Size = new System.Drawing.Size(56, 26);
			this.lab届け先コード.TabIndex = 8;
			this.lab届け先コード.Text = "お届け先コード";
			// 
			// tex届け先住所２
			// 
			this.tex届け先住所２.BackColor = System.Drawing.SystemColors.Window;
			this.tex届け先住所２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex届け先住所２.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex届け先住所２.Location = new System.Drawing.Point(110, 102);
			this.tex届け先住所２.MaxLength = 20;
			this.tex届け先住所２.Name = "tex届け先住所２";
			this.tex届け先住所２.Size = new System.Drawing.Size(330, 23);
			this.tex届け先住所２.TabIndex = 10;
			this.tex届け先住所２.Text = "";
			// 
			// tex届け先住所１
			// 
			this.tex届け先住所１.BackColor = System.Drawing.SystemColors.Window;
			this.tex届け先住所１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex届け先住所１.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex届け先住所１.Location = new System.Drawing.Point(110, 80);
			this.tex届け先住所１.MaxLength = 20;
			this.tex届け先住所１.Name = "tex届け先住所１";
			this.tex届け先住所１.Size = new System.Drawing.Size(330, 23);
			this.tex届け先住所１.TabIndex = 9;
			this.tex届け先住所１.Text = "";
			// 
			// btn届け先検索
			// 
			this.btn届け先検索.BackColor = System.Drawing.Color.SteelBlue;
			this.btn届け先検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn届け先検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn届け先検索.ForeColor = System.Drawing.Color.White;
			this.btn届け先検索.Location = new System.Drawing.Point(284, 2);
			this.btn届け先検索.Name = "btn届け先検索";
			this.btn届け先検索.Size = new System.Drawing.Size(66, 22);
			this.btn届け先検索.TabIndex = 1;
			this.btn届け先検索.TabStop = false;
			this.btn届け先検索.Text = "アドレス帳";
			this.btn届け先検索.Click += new System.EventHandler(this.btn届け先検索_Click);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Blue;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 221);
			this.label1.TabIndex = 3;
			this.label1.Text = "お届け先";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Honeydew;
			this.panel2.Controls.Add(this.tex請求先部課コード);
			this.panel2.Controls.Add(this.lab請求先コード);
			this.panel2.Controls.Add(this.tex請求先コード);
			this.panel2.Controls.Add(this.tex依頼主電話番号１);
			this.panel2.Controls.Add(this.tex依頼主請求先);
			this.panel2.Controls.Add(this.label36);
			this.panel2.Controls.Add(this.lab依頼主部署);
			this.panel2.Controls.Add(this.lab依頼主名前);
			this.panel2.Controls.Add(this.lab依頼主住所);
			this.panel2.Controls.Add(this.lab依頼主郵便番号);
			this.panel2.Controls.Add(this.label16);
			this.panel2.Controls.Add(this.label17);
			this.panel2.Controls.Add(this.label18);
			this.panel2.Controls.Add(this.lab依頼主電話番号);
			this.panel2.Controls.Add(this.tex依頼主部署);
			this.panel2.Controls.Add(this.tex依頼主名前２);
			this.panel2.Controls.Add(this.tex依頼主名前１);
			this.panel2.Controls.Add(this.tex依頼主郵便番号２);
			this.panel2.Controls.Add(this.tex依頼主郵便番号１);
			this.panel2.Controls.Add(this.label14);
			this.panel2.Controls.Add(this.tex依頼主電話番号３);
			this.panel2.Controls.Add(this.tex依頼主電話番号２);
			this.panel2.Controls.Add(this.lab依頼主コード);
			this.panel2.Controls.Add(this.tex依頼主住所２);
			this.panel2.Controls.Add(this.tex依頼主住所１);
			this.panel2.Controls.Add(this.btn依頼主検索);
			this.panel2.Controls.Add(this.label21);
			this.panel2.Controls.Add(this.tex依頼主コード);
			this.panel2.Controls.Add(this.lab依頼主請求先);
			this.panel2.Location = new System.Drawing.Point(0, 6);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(448, 194);
			this.panel2.TabIndex = 2;
			// 
			// tex請求先部課コード
			// 
			this.tex請求先部課コード.BackColor = System.Drawing.Color.Honeydew;
			this.tex請求先部課コード.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex請求先部課コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex請求先部課コード.Location = new System.Drawing.Point(392, 174);
			this.tex請求先部課コード.Name = "tex請求先部課コード";
			this.tex請求先部課コード.ReadOnly = true;
			this.tex請求先部課コード.Size = new System.Drawing.Size(48, 16);
			this.tex請求先部課コード.TabIndex = 48;
			this.tex請求先部課コード.TabStop = false;
			this.tex請求先部課コード.Text = "";
			// 
			// lab請求先コード
			// 
			this.lab請求先コード.BackColor = System.Drawing.Color.Honeydew;
			this.lab請求先コード.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab請求先コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab請求先コード.Location = new System.Drawing.Point(264, 176);
			this.lab請求先コード.Name = "lab請求先コード";
			this.lab請求先コード.Size = new System.Drawing.Size(28, 14);
			this.lab請求先コード.TabIndex = 47;
			this.lab請求先コード.Text = "ｺｰﾄﾞ";
			// 
			// tex請求先コード
			// 
			this.tex請求先コード.BackColor = System.Drawing.Color.Honeydew;
			this.tex請求先コード.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex請求先コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex請求先コード.Location = new System.Drawing.Point(294, 174);
			this.tex請求先コード.Name = "tex請求先コード";
			this.tex請求先コード.ReadOnly = true;
			this.tex請求先コード.Size = new System.Drawing.Size(96, 16);
			this.tex請求先コード.TabIndex = 46;
			this.tex請求先コード.TabStop = false;
			this.tex請求先コード.Text = "";
			// 
			// tex依頼主電話番号１
			// 
			this.tex依頼主電話番号１.BackColor = System.Drawing.Color.Honeydew;
			this.tex依頼主電話番号１.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex依頼主電話番号１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主電話番号１.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex依頼主電話番号１.Location = new System.Drawing.Point(110, 32);
			this.tex依頼主電話番号１.MaxLength = 6;
			this.tex依頼主電話番号１.Name = "tex依頼主電話番号１";
			this.tex依頼主電話番号１.ReadOnly = true;
			this.tex依頼主電話番号１.Size = new System.Drawing.Size(52, 16);
			this.tex依頼主電話番号１.TabIndex = 2;
			this.tex依頼主電話番号１.TabStop = false;
			this.tex依頼主電話番号１.Text = "";
			// 
			// tex依頼主請求先
			// 
			this.tex依頼主請求先.BackColor = System.Drawing.Color.Honeydew;
			this.tex依頼主請求先.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex依頼主請求先.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主請求先.Location = new System.Drawing.Point(100, 175);
			this.tex依頼主請求先.Name = "tex依頼主請求先";
			this.tex依頼主請求先.ReadOnly = true;
			this.tex依頼主請求先.Size = new System.Drawing.Size(162, 16);
			this.tex依頼主請求先.TabIndex = 41;
			this.tex依頼主請求先.TabStop = false;
			this.tex依頼主請求先.Text = "";
			// 
			// label36
			// 
			this.label36.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label36.ForeColor = System.Drawing.Color.Red;
			this.label36.Location = new System.Drawing.Point(26, 8);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(16, 14);
			this.label36.TabIndex = 40;
			this.label36.Text = "※";
			// 
			// lab依頼主部署
			// 
			this.lab依頼主部署.BackColor = System.Drawing.Color.Honeydew;
			this.lab依頼主部署.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab依頼主部署.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab依頼主部署.Location = new System.Drawing.Point(70, 152);
			this.lab依頼主部署.Name = "lab依頼主部署";
			this.lab依頼主部署.Size = new System.Drawing.Size(36, 14);
			this.lab依頼主部署.TabIndex = 27;
			this.lab依頼主部署.Text = "担当：";
			// 
			// lab依頼主名前
			// 
			this.lab依頼主名前.BackColor = System.Drawing.Color.Honeydew;
			this.lab依頼主名前.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab依頼主名前.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab依頼主名前.Location = new System.Drawing.Point(40, 114);
			this.lab依頼主名前.Name = "lab依頼主名前";
			this.lab依頼主名前.Size = new System.Drawing.Size(56, 14);
			this.lab依頼主名前.TabIndex = 24;
			this.lab依頼主名前.Text = "名前";
			// 
			// lab依頼主住所
			// 
			this.lab依頼主住所.BackColor = System.Drawing.Color.Honeydew;
			this.lab依頼主住所.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab依頼主住所.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab依頼主住所.Location = new System.Drawing.Point(40, 74);
			this.lab依頼主住所.Name = "lab依頼主住所";
			this.lab依頼主住所.Size = new System.Drawing.Size(56, 14);
			this.lab依頼主住所.TabIndex = 19;
			this.lab依頼主住所.Text = "住所";
			// 
			// lab依頼主郵便番号
			// 
			this.lab依頼主郵便番号.BackColor = System.Drawing.Color.Honeydew;
			this.lab依頼主郵便番号.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab依頼主郵便番号.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab依頼主郵便番号.Location = new System.Drawing.Point(40, 54);
			this.lab依頼主郵便番号.Name = "lab依頼主郵便番号";
			this.lab依頼主郵便番号.Size = new System.Drawing.Size(56, 14);
			this.lab依頼主郵便番号.TabIndex = 15;
			this.lab依頼主郵便番号.Text = "郵便番号";
			// 
			// label16
			// 
			this.label16.BackColor = System.Drawing.Color.Honeydew;
			this.label16.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label16.ForeColor = System.Drawing.Color.LimeGreen;
			this.label16.Location = new System.Drawing.Point(210, 34);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(12, 14);
			this.label16.TabIndex = 13;
			this.label16.Text = "－";
			// 
			// label17
			// 
			this.label17.BackColor = System.Drawing.Color.Honeydew;
			this.label17.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label17.ForeColor = System.Drawing.Color.LimeGreen;
			this.label17.Location = new System.Drawing.Point(160, 34);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(12, 14);
			this.label17.TabIndex = 11;
			this.label17.Text = "）";
			// 
			// label18
			// 
			this.label18.BackColor = System.Drawing.Color.Honeydew;
			this.label18.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label18.ForeColor = System.Drawing.Color.LimeGreen;
			this.label18.Location = new System.Drawing.Point(100, 34);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(12, 14);
			this.label18.TabIndex = 10;
			this.label18.Text = "（";
			// 
			// lab依頼主電話番号
			// 
			this.lab依頼主電話番号.BackColor = System.Drawing.Color.Honeydew;
			this.lab依頼主電話番号.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab依頼主電話番号.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab依頼主電話番号.Location = new System.Drawing.Point(40, 34);
			this.lab依頼主電話番号.Name = "lab依頼主電話番号";
			this.lab依頼主電話番号.Size = new System.Drawing.Size(56, 14);
			this.lab依頼主電話番号.TabIndex = 9;
			this.lab依頼主電話番号.Text = "電話番号";
			// 
			// tex依頼主部署
			// 
			this.tex依頼主部署.BackColor = System.Drawing.SystemColors.Window;
			this.tex依頼主部署.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主部署.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex依頼主部署.Location = new System.Drawing.Point(108, 148);
			this.tex依頼主部署.MaxLength = 10;
			this.tex依頼主部署.Name = "tex依頼主部署";
			this.tex依頼主部署.Size = new System.Drawing.Size(172, 23);
			this.tex依頼主部署.TabIndex = 2;
			this.tex依頼主部署.Text = "";
			// 
			// tex依頼主名前２
			// 
			this.tex依頼主名前２.BackColor = System.Drawing.Color.Honeydew;
			this.tex依頼主名前２.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex依頼主名前２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主名前２.Location = new System.Drawing.Point(110, 130);
			this.tex依頼主名前２.MaxLength = 20;
			this.tex依頼主名前２.Name = "tex依頼主名前２";
			this.tex依頼主名前２.ReadOnly = true;
			this.tex依頼主名前２.Size = new System.Drawing.Size(330, 16);
			this.tex依頼主名前２.TabIndex = 25;
			this.tex依頼主名前２.TabStop = false;
			this.tex依頼主名前２.Text = "";
			// 
			// tex依頼主名前１
			// 
			this.tex依頼主名前１.BackColor = System.Drawing.Color.Honeydew;
			this.tex依頼主名前１.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex依頼主名前１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主名前１.Location = new System.Drawing.Point(110, 112);
			this.tex依頼主名前１.MaxLength = 20;
			this.tex依頼主名前１.Name = "tex依頼主名前１";
			this.tex依頼主名前１.ReadOnly = true;
			this.tex依頼主名前１.Size = new System.Drawing.Size(330, 16);
			this.tex依頼主名前１.TabIndex = 23;
			this.tex依頼主名前１.TabStop = false;
			this.tex依頼主名前１.Text = "";
			// 
			// tex依頼主郵便番号２
			// 
			this.tex依頼主郵便番号２.BackColor = System.Drawing.Color.Honeydew;
			this.tex依頼主郵便番号２.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex依頼主郵便番号２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主郵便番号２.Location = new System.Drawing.Point(154, 52);
			this.tex依頼主郵便番号２.MaxLength = 4;
			this.tex依頼主郵便番号２.Name = "tex依頼主郵便番号２";
			this.tex依頼主郵便番号２.ReadOnly = true;
			this.tex依頼主郵便番号２.Size = new System.Drawing.Size(36, 16);
			this.tex依頼主郵便番号２.TabIndex = 18;
			this.tex依頼主郵便番号２.TabStop = false;
			this.tex依頼主郵便番号２.Text = "";
			// 
			// tex依頼主郵便番号１
			// 
			this.tex依頼主郵便番号１.BackColor = System.Drawing.Color.Honeydew;
			this.tex依頼主郵便番号１.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex依頼主郵便番号１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主郵便番号１.Location = new System.Drawing.Point(110, 52);
			this.tex依頼主郵便番号１.MaxLength = 3;
			this.tex依頼主郵便番号１.Name = "tex依頼主郵便番号１";
			this.tex依頼主郵便番号１.ReadOnly = true;
			this.tex依頼主郵便番号１.Size = new System.Drawing.Size(28, 16);
			this.tex依頼主郵便番号１.TabIndex = 16;
			this.tex依頼主郵便番号１.TabStop = false;
			this.tex依頼主郵便番号１.Text = "";
			// 
			// label14
			// 
			this.label14.BackColor = System.Drawing.Color.Honeydew;
			this.label14.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label14.ForeColor = System.Drawing.Color.LimeGreen;
			this.label14.Location = new System.Drawing.Point(138, 54);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(12, 14);
			this.label14.TabIndex = 17;
			this.label14.Text = "－";
			// 
			// tex依頼主電話番号３
			// 
			this.tex依頼主電話番号３.BackColor = System.Drawing.Color.Honeydew;
			this.tex依頼主電話番号３.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex依頼主電話番号３.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主電話番号３.Location = new System.Drawing.Point(226, 32);
			this.tex依頼主電話番号３.MaxLength = 4;
			this.tex依頼主電話番号３.Name = "tex依頼主電話番号３";
			this.tex依頼主電話番号３.ReadOnly = true;
			this.tex依頼主電話番号３.Size = new System.Drawing.Size(36, 16);
			this.tex依頼主電話番号３.TabIndex = 14;
			this.tex依頼主電話番号３.TabStop = false;
			this.tex依頼主電話番号３.Text = "";
			// 
			// tex依頼主電話番号２
			// 
			this.tex依頼主電話番号２.BackColor = System.Drawing.Color.Honeydew;
			this.tex依頼主電話番号２.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex依頼主電話番号２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主電話番号２.Location = new System.Drawing.Point(174, 32);
			this.tex依頼主電話番号２.MaxLength = 4;
			this.tex依頼主電話番号２.Name = "tex依頼主電話番号２";
			this.tex依頼主電話番号２.ReadOnly = true;
			this.tex依頼主電話番号２.Size = new System.Drawing.Size(32, 16);
			this.tex依頼主電話番号２.TabIndex = 12;
			this.tex依頼主電話番号２.TabStop = false;
			this.tex依頼主電話番号２.Text = "";
			// 
			// lab依頼主コード
			// 
			this.lab依頼主コード.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab依頼主コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab依頼主コード.Location = new System.Drawing.Point(40, 4);
			this.lab依頼主コード.Name = "lab依頼主コード";
			this.lab依頼主コード.Size = new System.Drawing.Size(56, 26);
			this.lab依頼主コード.TabIndex = 8;
			this.lab依頼主コード.Text = "ご依頼主コード";
			// 
			// tex依頼主住所２
			// 
			this.tex依頼主住所２.BackColor = System.Drawing.Color.Honeydew;
			this.tex依頼主住所２.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex依頼主住所２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主住所２.Location = new System.Drawing.Point(110, 92);
			this.tex依頼主住所２.MaxLength = 20;
			this.tex依頼主住所２.Name = "tex依頼主住所２";
			this.tex依頼主住所２.ReadOnly = true;
			this.tex依頼主住所２.Size = new System.Drawing.Size(330, 16);
			this.tex依頼主住所２.TabIndex = 7;
			this.tex依頼主住所２.TabStop = false;
			this.tex依頼主住所２.Text = "";
			// 
			// tex依頼主住所１
			// 
			this.tex依頼主住所１.BackColor = System.Drawing.Color.Honeydew;
			this.tex依頼主住所１.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex依頼主住所１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主住所１.Location = new System.Drawing.Point(110, 74);
			this.tex依頼主住所１.MaxLength = 20;
			this.tex依頼主住所１.Name = "tex依頼主住所１";
			this.tex依頼主住所１.ReadOnly = true;
			this.tex依頼主住所１.Size = new System.Drawing.Size(330, 16);
			this.tex依頼主住所１.TabIndex = 6;
			this.tex依頼主住所１.TabStop = false;
			this.tex依頼主住所１.Text = "";
			// 
			// btn依頼主検索
			// 
			this.btn依頼主検索.BackColor = System.Drawing.Color.SteelBlue;
			this.btn依頼主検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn依頼主検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn依頼主検索.ForeColor = System.Drawing.Color.White;
			this.btn依頼主検索.Location = new System.Drawing.Point(284, 4);
			this.btn依頼主検索.Name = "btn依頼主検索";
			this.btn依頼主検索.Size = new System.Drawing.Size(48, 22);
			this.btn依頼主検索.TabIndex = 1;
			this.btn依頼主検索.TabStop = false;
			this.btn依頼主検索.Text = "検索";
			this.btn依頼主検索.Click += new System.EventHandler(this.btn依頼主検索_Click);
			// 
			// label21
			// 
			this.label21.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label21.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label21.ForeColor = System.Drawing.Color.Blue;
			this.label21.Location = new System.Drawing.Point(0, 0);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(22, 194);
			this.label21.TabIndex = 3;
			this.label21.Text = "ご依頼主";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tex依頼主コード
			// 
			this.tex依頼主コード.BackColor = System.Drawing.SystemColors.Window;
			this.tex依頼主コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex依頼主コード.Location = new System.Drawing.Point(110, 4);
			this.tex依頼主コード.MaxLength = 12;
			this.tex依頼主コード.Name = "tex依頼主コード";
			this.tex依頼主コード.Size = new System.Drawing.Size(172, 23);
			this.tex依頼主コード.TabIndex = 0;
			this.tex依頼主コード.Text = "";
			this.tex依頼主コード.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex依頼主コード_KeyDown);
			this.tex依頼主コード.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex依頼主コード_KeyPress);
			// 
			// lab依頼主請求先
			// 
			this.lab依頼主請求先.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab依頼主請求先.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab依頼主請求先.Location = new System.Drawing.Point(40, 176);
			this.lab依頼主請求先.Name = "lab依頼主請求先";
			this.lab依頼主請求先.Size = new System.Drawing.Size(44, 14);
			this.lab依頼主請求先.TabIndex = 9;
			this.lab依頼主請求先.Text = "請求先";
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.Honeydew;
			this.panel3.Controls.Add(this.tex記事名６);
			this.panel3.Controls.Add(this.tex記事名５);
			this.panel3.Controls.Add(this.tex記事名４);
			this.panel3.Controls.Add(this.tex輸送名子);
			this.panel3.Controls.Add(this.tex輸送名親);
			this.panel3.Controls.Add(this.tex記事名３);
			this.panel3.Controls.Add(this.tex記事名２);
			this.panel3.Controls.Add(this.tex記事名１);
			this.panel3.Controls.Add(this.btn輸送検索);
			this.panel3.Controls.Add(this.tex輸送コード親);
			this.panel3.Controls.Add(this.lab輸送コード);
			this.panel3.Controls.Add(this.lab輸送指示);
			this.panel3.Controls.Add(this.btn記事検索);
			this.panel3.Controls.Add(this.tex記事コード);
			this.panel3.Controls.Add(this.lab記事コード);
			this.panel3.Controls.Add(this.lab記事);
			this.panel3.Controls.Add(this.tex輸送コード子);
			this.panel3.Location = new System.Drawing.Point(1, 6);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(322, 252);
			this.panel3.TabIndex = 3;
			// 
			// tex記事名６
			// 
			this.tex記事名６.BackColor = System.Drawing.SystemColors.Window;
			this.tex記事名６.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex記事名６.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex記事名６.Location = new System.Drawing.Point(74, 222);
			this.tex記事名６.MaxLength = 30;
			this.tex記事名６.Name = "tex記事名６";
			this.tex記事名６.Size = new System.Drawing.Size(246, 23);
			this.tex記事名６.TabIndex = 37;
			this.tex記事名６.Text = "";
			// 
			// tex記事名５
			// 
			this.tex記事名５.BackColor = System.Drawing.SystemColors.Window;
			this.tex記事名５.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex記事名５.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex記事名５.Location = new System.Drawing.Point(74, 198);
			this.tex記事名５.MaxLength = 30;
			this.tex記事名５.Name = "tex記事名５";
			this.tex記事名５.Size = new System.Drawing.Size(246, 23);
			this.tex記事名５.TabIndex = 36;
			this.tex記事名５.Text = "";
			// 
			// tex記事名４
			// 
			this.tex記事名４.BackColor = System.Drawing.SystemColors.Window;
			this.tex記事名４.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex記事名４.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex記事名４.Location = new System.Drawing.Point(74, 174);
			this.tex記事名４.MaxLength = 30;
			this.tex記事名４.Name = "tex記事名４";
			this.tex記事名４.Size = new System.Drawing.Size(246, 23);
			this.tex記事名４.TabIndex = 35;
			this.tex記事名４.Text = "";
			// 
			// tex輸送名子
			// 
			this.tex輸送名子.BackColor = System.Drawing.Color.Honeydew;
			this.tex輸送名子.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex輸送名子.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex輸送名子.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex輸送名子.Location = new System.Drawing.Point(74, 54);
			this.tex輸送名子.Name = "tex輸送名子";
			this.tex輸送名子.ReadOnly = true;
			this.tex輸送名子.Size = new System.Drawing.Size(246, 16);
			this.tex輸送名子.TabIndex = 3;
			this.tex輸送名子.TabStop = false;
			this.tex輸送名子.Text = "";
			// 
			// tex輸送名親
			// 
			this.tex輸送名親.BackColor = System.Drawing.Color.Honeydew;
			this.tex輸送名親.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex輸送名親.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex輸送名親.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex輸送名親.Location = new System.Drawing.Point(74, 30);
			this.tex輸送名親.Name = "tex輸送名親";
			this.tex輸送名親.ReadOnly = true;
			this.tex輸送名親.Size = new System.Drawing.Size(246, 16);
			this.tex輸送名親.TabIndex = 1;
			this.tex輸送名親.TabStop = false;
			this.tex輸送名親.Text = "";
			// 
			// tex記事名３
			// 
			this.tex記事名３.BackColor = System.Drawing.SystemColors.Window;
			this.tex記事名３.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex記事名３.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex記事名３.Location = new System.Drawing.Point(74, 150);
			this.tex記事名３.MaxLength = 30;
			this.tex記事名３.Name = "tex記事名３";
			this.tex記事名３.Size = new System.Drawing.Size(246, 23);
			this.tex記事名３.TabIndex = 8;
			this.tex記事名３.Text = "";
			// 
			// tex記事名２
			// 
			this.tex記事名２.BackColor = System.Drawing.SystemColors.Window;
			this.tex記事名２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex記事名２.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex記事名２.Location = new System.Drawing.Point(74, 126);
			this.tex記事名２.MaxLength = 30;
			this.tex記事名２.Name = "tex記事名２";
			this.tex記事名２.Size = new System.Drawing.Size(246, 23);
			this.tex記事名２.TabIndex = 7;
			this.tex記事名２.Text = "";
			// 
			// tex記事名１
			// 
			this.tex記事名１.BackColor = System.Drawing.SystemColors.Window;
			this.tex記事名１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex記事名１.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex記事名１.Location = new System.Drawing.Point(74, 102);
			this.tex記事名１.MaxLength = 30;
			this.tex記事名１.Name = "tex記事名１";
			this.tex記事名１.Size = new System.Drawing.Size(246, 23);
			this.tex記事名１.TabIndex = 6;
			this.tex記事名１.Text = "";
			// 
			// btn輸送検索
			// 
			this.btn輸送検索.BackColor = System.Drawing.Color.SteelBlue;
			this.btn輸送検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn輸送検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn輸送検索.ForeColor = System.Drawing.Color.White;
			this.btn輸送検索.Location = new System.Drawing.Point(74, 4);
			this.btn輸送検索.Name = "btn輸送検索";
			this.btn輸送検索.Size = new System.Drawing.Size(48, 22);
			this.btn輸送検索.TabIndex = 1;
			this.btn輸送検索.TabStop = false;
			this.btn輸送検索.Text = "検索";
			this.btn輸送検索.Click += new System.EventHandler(this.btn輸送検索_Click);
			// 
			// tex輸送コード親
			// 
			this.tex輸送コード親.BackColor = System.Drawing.SystemColors.Window;
			this.tex輸送コード親.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex輸送コード親.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex輸送コード親.Location = new System.Drawing.Point(30, 26);
			this.tex輸送コード親.MaxLength = 4;
			this.tex輸送コード親.Name = "tex輸送コード親";
			this.tex輸送コード親.Size = new System.Drawing.Size(42, 23);
			this.tex輸送コード親.TabIndex = 0;
			this.tex輸送コード親.Text = "";
			this.tex輸送コード親.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex輸送コード親_KeyDown);
			this.tex輸送コード親.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex輸送コード親_KeyPress);
			// 
			// lab輸送コード
			// 
			this.lab輸送コード.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab輸送コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab輸送コード.Location = new System.Drawing.Point(34, 8);
			this.lab輸送コード.Name = "lab輸送コード";
			this.lab輸送コード.Size = new System.Drawing.Size(34, 14);
			this.lab輸送コード.TabIndex = 34;
			this.lab輸送コード.Text = "コード";
			// 
			// lab輸送指示
			// 
			this.lab輸送指示.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab輸送指示.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab輸送指示.ForeColor = System.Drawing.Color.Blue;
			this.lab輸送指示.Location = new System.Drawing.Point(8, 4);
			this.lab輸送指示.Name = "lab輸送指示";
			this.lab輸送指示.Size = new System.Drawing.Size(18, 70);
			this.lab輸送指示.TabIndex = 32;
			this.lab輸送指示.Text = "輸送商品";
			this.lab輸送指示.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn記事検索
			// 
			this.btn記事検索.BackColor = System.Drawing.Color.SteelBlue;
			this.btn記事検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn記事検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn記事検索.ForeColor = System.Drawing.Color.White;
			this.btn記事検索.Location = new System.Drawing.Point(74, 78);
			this.btn記事検索.Name = "btn記事検索";
			this.btn記事検索.Size = new System.Drawing.Size(48, 22);
			this.btn記事検索.TabIndex = 5;
			this.btn記事検索.TabStop = false;
			this.btn記事検索.Text = "検索";
			this.btn記事検索.Click += new System.EventHandler(this.btn記事検索_Click);
			// 
			// tex記事コード
			// 
			this.tex記事コード.BackColor = System.Drawing.SystemColors.Window;
			this.tex記事コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex記事コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex記事コード.Location = new System.Drawing.Point(30, 102);
			this.tex記事コード.MaxLength = 4;
			this.tex記事コード.Name = "tex記事コード";
			this.tex記事コード.Size = new System.Drawing.Size(42, 23);
			this.tex記事コード.TabIndex = 4;
			this.tex記事コード.Text = "";
			this.tex記事コード.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex記事コード_KeyDown);
			this.tex記事コード.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex記事コード_KeyPress);
			// 
			// lab記事コード
			// 
			this.lab記事コード.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab記事コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab記事コード.Location = new System.Drawing.Point(34, 82);
			this.lab記事コード.Name = "lab記事コード";
			this.lab記事コード.Size = new System.Drawing.Size(34, 14);
			this.lab記事コード.TabIndex = 11;
			this.lab記事コード.Text = "コード";
			// 
			// lab記事
			// 
			this.lab記事.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab記事.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab記事.ForeColor = System.Drawing.Color.Blue;
			this.lab記事.Location = new System.Drawing.Point(8, 78);
			this.lab記事.Name = "lab記事";
			this.lab記事.Size = new System.Drawing.Size(18, 168);
			this.lab記事.TabIndex = 9;
			this.lab記事.Text = "記事・品名";
			this.lab記事.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tex輸送コード子
			// 
			this.tex輸送コード子.BackColor = System.Drawing.SystemColors.Window;
			this.tex輸送コード子.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex輸送コード子.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex輸送コード子.Location = new System.Drawing.Point(30, 50);
			this.tex輸送コード子.MaxLength = 4;
			this.tex輸送コード子.Name = "tex輸送コード子";
			this.tex輸送コード子.Size = new System.Drawing.Size(42, 23);
			this.tex輸送コード子.TabIndex = 2;
			this.tex輸送コード子.Text = "";
			this.tex輸送コード子.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex輸送コード子_KeyDown);
			this.tex輸送コード子.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex輸送コード子_KeyPress);
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.Honeydew;
			this.panel4.Controls.Add(this.lab重量);
			this.panel4.Controls.Add(this.nUD重量);
			this.panel4.Controls.Add(this.nUD保険金額);
			this.panel4.Controls.Add(this.lab保険金額);
			this.panel4.Controls.Add(this.nUD個数);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Controls.Add(this.lab個数);
			this.panel4.Location = new System.Drawing.Point(1, 6);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(322, 76);
			this.panel4.TabIndex = 4;
			// 
			// lab重量
			// 
			this.lab重量.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab重量.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab重量.ForeColor = System.Drawing.Color.Blue;
			this.lab重量.Location = new System.Drawing.Point(108, 4);
			this.lab重量.Name = "lab重量";
			this.lab重量.Size = new System.Drawing.Size(100, 32);
			this.lab重量.TabIndex = 54;
			this.lab重量.Text = "重量(kg)";
			this.lab重量.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lab重量.Visible = false;
			// 
			// nUD重量
			// 
			this.nUD重量.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.nUD重量.Location = new System.Drawing.Point(134, 40);
			this.nUD重量.Maximum = new System.Decimal(new int[] {
																  9999,
																  0,
																  0,
																  0});
			this.nUD重量.Name = "nUD重量";
			this.nUD重量.Size = new System.Drawing.Size(74, 31);
			this.nUD重量.TabIndex = 1;
			this.nUD重量.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nUD重量.ThousandsSeparator = true;
			this.nUD重量.Visible = false;
			this.nUD重量.Enter += new System.EventHandler(this.nUD重量_Enter);
			// 
			// nUD保険金額
			// 
			this.nUD保険金額.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.nUD保険金額.Location = new System.Drawing.Point(238, 40);
			this.nUD保険金額.Maximum = new System.Decimal(new int[] {
																	9999,
																	0,
																	0,
																	0});
			this.nUD保険金額.Name = "nUD保険金額";
			this.nUD保険金額.Size = new System.Drawing.Size(74, 31);
			this.nUD保険金額.TabIndex = 2;
			this.nUD保険金額.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nUD保険金額.ThousandsSeparator = true;
			this.nUD保険金額.Enter += new System.EventHandler(this.nUD保険金額_Enter);
			// 
			// lab保険金額
			// 
			this.lab保険金額.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab保険金額.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab保険金額.ForeColor = System.Drawing.Color.Blue;
			this.lab保険金額.Location = new System.Drawing.Point(212, 4);
			this.lab保険金額.Name = "lab保険金額";
			this.lab保険金額.Size = new System.Drawing.Size(100, 32);
			this.lab保険金額.TabIndex = 52;
			this.lab保険金額.Text = "保険金額（万円）";
			this.lab保険金額.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nUD個数
			// 
			this.nUD個数.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.nUD個数.Location = new System.Drawing.Point(60, 40);
			this.nUD個数.Maximum = new System.Decimal(new int[] {
																  99,
																  0,
																  0,
																  0});
			this.nUD個数.Name = "nUD個数";
			this.nUD個数.Size = new System.Drawing.Size(44, 31);
			this.nUD個数.TabIndex = 0;
			this.nUD個数.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nUD個数.ThousandsSeparator = true;
			this.nUD個数.Enter += new System.EventHandler(this.nUD個数_Enter);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label2.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(26, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(14, 16);
			this.label2.TabIndex = 37;
			this.label2.Text = "※";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lab個数
			// 
			this.lab個数.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab個数.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab個数.ForeColor = System.Drawing.Color.Blue;
			this.lab個数.Location = new System.Drawing.Point(4, 4);
			this.lab個数.Name = "lab個数";
			this.lab個数.Size = new System.Drawing.Size(100, 32);
			this.lab個数.TabIndex = 4;
			this.lab個数.Text = "個数";
			this.lab個数.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.Honeydew;
			this.panel5.Controls.Add(this.nUD登録番号);
			this.panel5.Controls.Add(this.lab登録番号);
			this.panel5.Controls.Add(this.tex雛型名);
			this.panel5.Controls.Add(this.lab雛型名);
			this.panel5.Location = new System.Drawing.Point(1, 6);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(424, 52);
			this.panel5.TabIndex = 0;
			// 
			// nUD登録番号
			// 
			this.nUD登録番号.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.nUD登録番号.Location = new System.Drawing.Point(88, 28);
			this.nUD登録番号.Maximum = new System.Decimal(new int[] {
																	99,
																	0,
																	0,
																	0});
			this.nUD登録番号.Name = "nUD登録番号";
			this.nUD登録番号.Size = new System.Drawing.Size(44, 23);
			this.nUD登録番号.TabIndex = 1;
			this.nUD登録番号.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nUD登録番号.Enter += new System.EventHandler(this.nUD登録番号_Enter);
			// 
			// lab登録番号
			// 
			this.lab登録番号.BackColor = System.Drawing.Color.Honeydew;
			this.lab登録番号.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab登録番号.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab登録番号.Location = new System.Drawing.Point(6, 31);
			this.lab登録番号.Name = "lab登録番号";
			this.lab登録番号.Size = new System.Drawing.Size(72, 14);
			this.lab登録番号.TabIndex = 8;
			this.lab登録番号.Text = "登録番号";
			// 
			// tex雛型名
			// 
			this.tex雛型名.BackColor = System.Drawing.SystemColors.Window;
			this.tex雛型名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex雛型名.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex雛型名.Location = new System.Drawing.Point(88, 2);
			this.tex雛型名.MaxLength = 50;
			this.tex雛型名.Name = "tex雛型名";
			this.tex雛型名.Size = new System.Drawing.Size(228, 23);
			this.tex雛型名.TabIndex = 0;
			this.tex雛型名.Text = "";
			// 
			// lab雛型名
			// 
			this.lab雛型名.BackColor = System.Drawing.Color.Honeydew;
			this.lab雛型名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab雛型名.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab雛型名.Location = new System.Drawing.Point(6, 4);
			this.lab雛型名.Name = "lab雛型名";
			this.lab雛型名.Size = new System.Drawing.Size(72, 16);
			this.lab雛型名.TabIndex = 6;
			this.lab雛型名.Text = "名称";
			// 
			// btnアイコン
			// 
			this.btnアイコン.BackColor = System.Drawing.Color.White;
			this.btnアイコン.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnアイコン.Location = new System.Drawing.Point(10, 22);
			this.btnアイコン.Name = "btnアイコン";
			this.btnアイコン.Size = new System.Drawing.Size(64, 64);
			this.btnアイコン.TabIndex = 1;
			this.btnアイコン.Tag = "";
			this.btnアイコン.Click += new System.EventHandler(this.btnアイコン_Click);
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.PaleGreen;
			this.panel6.Controls.Add(this.texお客様名);
			this.panel6.Controls.Add(this.labお客様名);
			this.panel6.Controls.Add(this.lab利用部門);
			this.panel6.Controls.Add(this.tex利用部門);
			this.panel6.Location = new System.Drawing.Point(0, 26);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(810, 26);
			this.panel6.TabIndex = 12;
			// 
			// texお客様名
			// 
			this.texお客様名.BackColor = System.Drawing.Color.PaleGreen;
			this.texお客様名.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.texお客様名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texお客様名.ForeColor = System.Drawing.Color.LimeGreen;
			this.texお客様名.Location = new System.Drawing.Point(624, 6);
			this.texお客様名.Name = "texお客様名";
			this.texお客様名.ReadOnly = true;
			this.texお客様名.Size = new System.Drawing.Size(162, 16);
			this.texお客様名.TabIndex = 12;
			this.texお客様名.TabStop = false;
			this.texお客様名.Text = "○×商事＿＿＿＿＿■";
			this.texお客様名.Visible = false;
			// 
			// labお客様名
			// 
			this.labお客様名.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labお客様名.ForeColor = System.Drawing.Color.LimeGreen;
			this.labお客様名.Location = new System.Drawing.Point(566, 8);
			this.labお客様名.Name = "labお客様名";
			this.labお客様名.Size = new System.Drawing.Size(52, 14);
			this.labお客様名.TabIndex = 11;
			this.labお客様名.Text = "ユーザー";
			this.labお客様名.Visible = false;
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
			this.panel7.Controls.Add(this.lab雛型登録タイトル);
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
			// lab雛型登録タイトル
			// 
			this.lab雛型登録タイトル.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab雛型登録タイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab雛型登録タイトル.ForeColor = System.Drawing.Color.White;
			this.lab雛型登録タイトル.Location = new System.Drawing.Point(12, 2);
			this.lab雛型登録タイトル.Name = "lab雛型登録タイトル";
			this.lab雛型登録タイトル.Size = new System.Drawing.Size(264, 24);
			this.lab雛型登録タイトル.TabIndex = 0;
			this.lab雛型登録タイトル.Text = "ライブラリ登録";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn削除);
			this.panel8.Controls.Add(this.btn取消);
			this.panel8.Controls.Add(this.btn更新);
			this.panel8.Controls.Add(this.texメッセージ);
			this.panel8.Controls.Add(this.btn閉じる);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 6;
			// 
			// btn削除
			// 
			this.btn削除.ForeColor = System.Drawing.Color.Blue;
			this.btn削除.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn削除.Location = new System.Drawing.Point(322, 6);
			this.btn削除.Name = "btn削除";
			this.btn削除.Size = new System.Drawing.Size(62, 48);
			this.btn削除.TabIndex = 3;
			this.btn削除.Text = "削除";
			this.btn削除.Click += new System.EventHandler(this.btn削除_Click);
			// 
			// btn取消
			// 
			this.btn取消.ForeColor = System.Drawing.Color.Blue;
			this.btn取消.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn取消.Location = new System.Drawing.Point(252, 6);
			this.btn取消.Name = "btn取消";
			this.btn取消.Size = new System.Drawing.Size(62, 48);
			this.btn取消.TabIndex = 2;
			this.btn取消.Text = "取消";
			this.btn取消.Click += new System.EventHandler(this.btn取消_Click);
			// 
			// btn更新
			// 
			this.btn更新.ForeColor = System.Drawing.Color.Blue;
			this.btn更新.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn更新.Location = new System.Drawing.Point(98, 6);
			this.btn更新.Name = "btn更新";
			this.btn更新.Size = new System.Drawing.Size(62, 48);
			this.btn更新.TabIndex = 1;
			this.btn更新.Text = "保存";
			this.btn更新.Click += new System.EventHandler(this.btn更新_Click);
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
			// panel9
			// 
			this.panel9.BackColor = System.Drawing.Color.Honeydew;
			this.panel9.Controls.Add(this.labアイコン設定);
			this.panel9.Controls.Add(this.btnアイコン);
			this.panel9.Location = new System.Drawing.Point(1, 6);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(322, 92);
			this.panel9.TabIndex = 5;
			// 
			// labアイコン設定
			// 
			this.labアイコン設定.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labアイコン設定.ForeColor = System.Drawing.Color.LimeGreen;
			this.labアイコン設定.Location = new System.Drawing.Point(8, 6);
			this.labアイコン設定.Name = "labアイコン設定";
			this.labアイコン設定.Size = new System.Drawing.Size(76, 14);
			this.labアイコン設定.TabIndex = 10;
			this.labアイコン設定.Text = "アイコン設定";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel5);
			this.groupBox1.Location = new System.Drawing.Point(32, 50);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(428, 60);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel1);
			this.groupBox2.Location = new System.Drawing.Point(10, 106);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(450, 210);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.panel2);
			this.groupBox3.Location = new System.Drawing.Point(10, 312);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(450, 202);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.panel9);
			this.groupBox4.Location = new System.Drawing.Point(462, 414);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(326, 100);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.panel4);
			this.groupBox5.Location = new System.Drawing.Point(462, 334);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(326, 84);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.panel3);
			this.groupBox6.Location = new System.Drawing.Point(462, 78);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(326, 260);
			this.groupBox6.TabIndex = 3;
			this.groupBox6.TabStop = false;
			// 
			// 雛型登録
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 580);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox3);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "雛型登録";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 ライブラリ登録";
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 START
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Onエンター移動);
            //this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Onエンターキャンセル);
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 END
            this.Load += new System.EventHandler(this.Form1_Load);
			this.Closed += new System.EventHandler(this.雛型登録_Closed);
			this.Activated += new System.EventHandler(this.雛型登録_Activated);
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nUD重量)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD保険金額)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD個数)).EndInit();
			this.panel5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nUD登録番号)).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
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
			iアクティブＦＧ = 0;
			// ヘッダー項目の設定
			texお客様名.Text = gs利用者名;
			tex利用部門.Text = gs部門ＣＤ + " " + gs部門名;

			// 日時の初期設定
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled = true;

// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
			Font fGothic = new System.Drawing.Font("MS Gothic"
							, 12F
							, System.Drawing.FontStyle.Regular
							, System.Drawing.GraphicsUnit.Point
							, ((System.Byte)(128))
							);
			tex届け先住所１.Font = fGothic;
			tex届け先住所２.Font = fGothic;
			tex届け先住所３.Font = fGothic;
			tex届け先名前１.Font = fGothic;
			tex届け先名前２.Font = fGothic;
			tex依頼主住所１.Font = fGothic;
			tex依頼主住所２.Font = fGothic;
			tex依頼主名前１.Font = fGothic;
			tex依頼主名前２.Font = fGothic;
			tex依頼主部署.Font   = fGothic;
			tex記事名１.Font     = fGothic;
			tex記事名２.Font     = fGothic;
			tex記事名３.Font     = fGothic;
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
// MOD 2011.07.14 東都）高木 記事行の追加 START
			tex記事名４.Font     = fGothic;
			tex記事名５.Font     = fGothic;
			tex記事名６.Font     = fGothic;
// MOD 2011.07.14 東都）高木 記事行の追加 END

			// イメージの設定
			アイコンイメージの初期化();

// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 START
			nUD保険金額.Minimum =  0;
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) START
//			nUD保険金額.Maximum = 30;
			nUD保険金額.Maximum = gl保険金額上限;
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) END
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 END

// DEL 2005.06.06 東都）伊賀 画面制御項目追加 START
// ADD 2005.05.17 東都）小童谷 才数か重量か START
//			画面制御検索();
//			if(i才数ＦＧ == 0)
//			{
//				lab重量.Text = "才数";
//				nUD重量.Maximum = 999;
//			}
//			else
//			{
//				lab重量.Text = "重量(kg)";
//				nUD重量.Maximum = 9999;
//			}
// ADD 2005.05.17 東都）小童谷 才数か重量か END
// DEL 2005.06.06 東都）伊賀 画面制御項目追加 END
// ADD 2005.06.01 東都）伊賀 画面制御項目追加 START
			画面制御検索();
// ADD 2005.06.01 東都）伊賀 画面制御項目追加 END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
			if(gs重量入力制御 == "1"){
				lab重量.Visible = true;
				nUD重量.Visible = true;
			}else{
				lab重量.Visible = false;
				nUD重量.Visible = false;
			}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 START
			s修正前_依頼主ＣＤ = "";
			s修正前_請求先ＣＤ = "";
			s修正前_請求先部課 = "";
			s修正前_請求先名   = "";
			s修正前_個数       = "";
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 END

			if(i雛型ＮＯ > 0)
			{
				// 雛型一覧から開かれた場合（更新モード）
				b更新ＦＧ           = true;
				btn削除.Visible     = true;
				tex雛型名.Text      = s雛型名称;
				nUD登録番号.Value   = i雛型ＮＯ;
				nUD登録番号.Enabled = false;
				nUD登録番号.TabStop = false;
				雛型検索();
				tex届け先コード.Focus();
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 START
				s修正前_依頼主ＣＤ = tex依頼主コード.Text.TrimEnd();
				s修正前_請求先ＣＤ = tex請求先コード.Text.TrimEnd();
				s修正前_請求先部課 = tex請求先部課コード.Text.TrimEnd();
				s修正前_請求先名   = tex依頼主請求先.Text.TrimEnd();
				s修正前_個数       = nUD個数.Text.TrimEnd();
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 END
			}else{
				// 雛型一覧から開かれた場合（追加モード）
				// 照会一覧から開かれた場合（追加モード）
				b更新ＦＧ           = false;
				btn削除.Visible     = false;
				tex雛型名.Text      = "";
				nUD登録番号.Value   = 0;
				nUD登録番号.Enabled = true;
				nUD登録番号.TabStop = true;
				if(s登録日.Length > 0 && sジャーナルＮＯ.Length > 0)
				{
					// 照会一覧から開かれた場合（追加モード）
					出荷検索();
				}
				else
				{
					輸送商品個数重量制御();
				}
//				else
//				{
//					tex依頼主コード.Text = gs荷送人ＣＤ;
//					s依頼主ＣＤ          = gs荷送人ＣＤ;
//					if(s依頼主ＣＤ.Length > 0) 依頼主検索();
//				}
				雛型番号設定();
				tex雛型名.Focus();
			}
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 START
			if(tex届け先住所１.Text.Trim().Equals("※※支店止め※※"))
			{
				// 支店止めだった場合
				tex届け先郵便番号１.Enabled = false; // 届け先郵便番号１
				tex届け先郵便番号２.Enabled = false; // 届け先郵便番号２
				tex届け先住所１.Enabled = false; // 届け先住所１
				tex届け先住所２.Enabled = false; // 届け先住所２
				tex届け先住所３.Enabled = false; // 届け先住所３
				btn支店止め.Visible = false;
				btn支店止め.Enabled = false;
				btn支店止め解除.Visible = true;
				btn支店止め解除.Enabled = true;
			}
			else
			{
				// それ以外の場合
				btn支店止め.Visible = true;
				btn支店止め.Enabled = true;
				btn支店止め解除.Visible = false;
				btn支店止め解除.Enabled = false;
			}
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 END
		}
// ADD 2005.06.10 東都）伊賀 画面制御項目追加 START
		private void 画面制御検索()
		{
// MOD 2009.05.01 東都）高木 オプションの項目追加 START
//			Cursor = System.Windows.Forms.Cursors.AppStarting;
//			string[] sList = {""};
//			try
//			{
//				texメッセージ.Text = "検索中．．．";
//				if(sv_init == null) sv_init = new is2init.Service1();
//				sList = sv_init.Get_seigyo(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
//			}
//			catch (System.Net.WebException)
//			{
//				sList[0] = gs通信エラー;
//				return;
//			}
//			catch (Exception ex)
//			{
//				sList[0] = "通信エラー：" + ex.Message;
//				return;
//			}
//			// カーソルをデフォルトに戻す
//			Cursor = System.Windows.Forms.Cursors.Default;
			string[] sList = gsオプション;
// MOD 2009.05.01 東都）高木 オプションの項目追加 END

			texメッセージ.Text = "";

			if(sList[0].Length == 4)
			{
				bool bRet;
				bRet = 画面制御設定(sList[1]);
				tex届け先住所２.TabStop = bRet;
				bRet = 画面制御設定(sList[2]);
				tex届け先住所３.TabStop = bRet;
				bRet = 画面制御設定(sList[3]);
				tex届け先名前２.TabStop = bRet;
				bRet = 画面制御設定(sList[4]);
				tex依頼主部署.TabStop = bRet;
//				bRet = 画面制御設定(sList[5]);
//				texお客様管理番号.TabStop = bRet;
				bRet = 画面制御設定(sList[6]);
				tex輸送コード親.TabStop = bRet;
				tex輸送コード子.TabStop = bRet;
// MOD 2011.08.05 東都）高木 記事行の追加（３行・６行切替対応） START
//				bRet = 画面制御設定(sList[7]);
//				tex記事コード.TabStop = bRet;
//				tex記事名１.TabStop = bRet;
//				tex記事名２.TabStop = bRet;
//				tex記事名３.TabStop = bRet;
//// MOD 2011.07.14 東都）高木 記事行の追加 START
//				tex記事名４.TabStop = bRet;
//				tex記事名５.TabStop = bRet;
//				tex記事名６.TabStop = bRet;
//// MOD 2011.07.14 東都）高木 記事行の追加 END
// MOD 2011.08.05 東都）高木 記事行の追加（３行・６行切替対応） END
				bRet = 画面制御設定(sList[8]);
				nUD重量.TabStop = bRet;
				bRet = 画面制御設定(sList[9]);
				if(bRet)
				{
					i才数ＦＧ = 1;
					i才数保持 = 1;
					lab重量.Text = "重量(kg)";
					nUD重量.Maximum = 9999;
				}
				else
				{
					i才数ＦＧ = 0;
					i才数保持 = 0;
					lab重量.Text = "才数";
					nUD重量.Maximum = 999;
				}
				bRet = 画面制御設定(sList[10]);
				nUD保険金額.TabStop = bRet;
// ADD 2009.02.06 東都）高木　 エントリオプションの項目追加 START
				bRet = 画面制御設定(sList[11]);
				tex依頼主コード.TabStop = bRet;
// ADD 2009.02.06 東都）高木　 エントリオプションの項目追加 END
// MOD 2011.07.25 東都）高木 各項目の入力不可対応 START
				画面制御設定２(tex届け先住所２, sList[1]);
				画面制御設定２(tex届け先住所３, sList[2]);
				画面制御設定２(tex届け先名前２, sList[3]);
				画面制御設定２(tex依頼主部署, sList[4]);
				// 5:お客様管理番号
				// 輸送商品
				画面制御設定２(tex輸送コード親, sList[6]);
				画面制御設定２(tex輸送コード子, sList[6]);
				// 記事・品名
// MOD 2011.08.05 東都）高木 記事行の追加（３行・６行切替対応） START
//				画面制御設定２(tex記事コード, sList[7]);
//				画面制御設定２(tex記事名１, sList[7]);
//				画面制御設定２(tex記事名２, sList[7]);
//				画面制御設定２(tex記事名３, sList[7]);
//				画面制御設定２(tex記事名４, sList[7]);
//				画面制御設定２(tex記事名５, sList[7]);
//				画面制御設定２(tex記事名６, sList[7]);
				画面制御設定３(tex記事コード, sList[7], "029");
				画面制御設定３(tex記事名１, sList[7], "029");
				画面制御設定３(tex記事名２, sList[7], "029");
				画面制御設定３(tex記事名３, sList[7], "029");
				画面制御設定３(tex記事名４, sList[7], "09");
				画面制御設定３(tex記事名５, sList[7], "09");
				画面制御設定３(tex記事名６, sList[7], "09");
// MOD 2011.08.05 東都）高木 記事行の追加（３行・６行切替対応） END
				画面制御設定２(nUD重量, sList[8]);
				s画面制御_重量          = sList[8];
				// 9:重量入力形式：重量 or 才数
				画面制御設定２(nUD保険金額, sList[10]);
				画面制御設定２(tex依頼主コード, sList[11]);
// MOD 2011.07.25 東都）高木 各項目の入力不可対応 END
			}
			else
			{
				texメッセージ.Text = sList[0];
				ビープ音();
			}
			return;
		}
		private bool 画面制御設定(string sCode)
		{
			bool bRet;
			if(sCode.Equals("9"))
			{
				bRet = true;
			}
			else
			{
				if(sCode.Equals("0"))
					bRet = true;
				else
					bRet = false;
			}
			return bRet;
		}
// ADD 2005.06.10 東都）伊賀 画面制御項目追加 END
// MOD 2011.07.25 東都）高木 各項目の入力不可対応 START
		private void 画面制御設定２(Control cntl, string sCode)
		{
			cntl.Enabled = 画面制御設定(sCode);
			if(cntl.Enabled){
				cntl.BackColor = System.Drawing.SystemColors.Window;
			}else{
				cntl.BackColor = System.Drawing.SystemColors.InactiveBorder;
			}
		}
// MOD 2011.07.25 東都）高木 各項目の入力不可対応 END
// MOD 2011.08.05 東都）高木 記事行の追加（３行・６行切替対応） START
		private void 画面制御設定３(Control cntl, string sCode, string s有効条件)
		{
			if(s有効条件.IndexOf(sCode) == -1){
				cntl.TabStop = false;
				cntl.Enabled = false;
			}else{
				cntl.TabStop = true;
				cntl.Enabled = true;
			}
			if(cntl.Enabled){
				cntl.BackColor = System.Drawing.SystemColors.Window;
			}else{
				cntl.BackColor = System.Drawing.SystemColors.InactiveBorder;
			}
		}
// MOD 2011.08.05 東都）高木 記事行の追加（３行・６行切替対応） END

		private void 雛型番号設定()
		{
			// 部門で一番大きい雛型番号を取得する;
			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sList = {""};
			try
			{
// MOD 2009.09.09 東都）高木 画面表示不具合の調整 
//				texメッセージ.Text = "登録番号取得中．．．";
				if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
				sList = sv_hinagata.Get_hinagataNo(gsaユーザ,gs会員ＣＤ, gs部門ＣＤ);
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				sList[0] = gs通信エラー;
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				sList[0] = "通信エラー：" + ex.Message;
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;

// MOD 2009.09.09 東都）高木 画面表示不具合の調整 
//			texメッセージ.Text = sList[0];

			// メッセージが[正常終了]
			if(sList[0].Length != 4)
			{
// MOD 2009.09.09 東都）高木 画面表示不具合の調整 
				texメッセージ.Text = sList[0];
				ビープ音();
				nUD登録番号.Focus();
				return;
			}
// MOD 2009.09.09 東都）高木 画面表示不具合の調整 
//			texメッセージ.Text = "";
// ADD 2006.02.08 東都）高木 雛型番号が[99]→[100]になった時のエラー対応 START
			if(int.Parse(sList[1]) < 99)
// ADD 2006.02.08 東都）高木 雛型番号が[99]→[100]になった時のエラー対応 END
				nUD登録番号.Value = int.Parse(sList[1]) + 1;
		}

		private void 雛型検索()
		{
			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sList = {""};
			try
			{
				texメッセージ.Text = "雛型検索中．．．";
				if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
				sList = sv_hinagata.Get_Hinagata2(gsaユーザ,gs会員ＣＤ, gs部門ＣＤ, i雛型ＮＯ);
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				sList[0] = gs通信エラー;
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				sList[0] = "通信エラー：" + ex.Message;
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;

			texメッセージ.Text = sList[0];

			// メッセージが[正常終了]
			if(sList[0].Length == 4)
			{
// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 START
				texメッセージ.Text = "";
// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 END
				int iPos = 1;
				tex雛型名.Text            = sList[iPos++].Trim();
				sファイル名               = sList[iPos++].Trim();
				tex届け先コード.Text      = sList[iPos++].Trim();
				tex届け先電話番号１.Text  = sList[iPos++].Trim();
				tex届け先電話番号２.Text  = sList[iPos++].Trim();
				tex届け先電話番号３.Text  = sList[iPos++].Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//				tex届け先住所１.Text      = sList[iPos++].Trim();
//				tex届け先住所２.Text      = sList[iPos++].Trim();
//				tex届け先住所３.Text      = sList[iPos++].Trim();
//				tex届け先名前１.Text      = sList[iPos++].Trim();
//				tex届け先名前２.Text      = sList[iPos++].Trim();
				if(gsオプション[18].Equals("1")){
					tex届け先住所１.Text  = sList[iPos++].TrimEnd();
					tex届け先住所２.Text  = sList[iPos++].TrimEnd();
					tex届け先住所３.Text  = sList[iPos++].TrimEnd();
					tex届け先名前１.Text  = sList[iPos++].TrimEnd();
					tex届け先名前２.Text  = sList[iPos++].TrimEnd();
				}else{
					tex届け先住所１.Text  = sList[iPos++].Trim();
					tex届け先住所２.Text  = sList[iPos++].Trim();
					tex届け先住所３.Text  = sList[iPos++].Trim();
					tex届け先名前１.Text  = sList[iPos++].Trim();
					tex届け先名前２.Text  = sList[iPos++].Trim();
				}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
				tex届け先郵便番号１.Text  = sList[iPos++].Trim();
				tex届け先郵便番号２.Text  = sList[iPos++].Trim();
				tex依頼主コード.Text      = sList[iPos++].Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//				tex依頼主部署.Text        = sList[iPos++].Trim();
				if(gsオプション[18].Equals("1")){
					tex依頼主部署.Text    = sList[iPos++].TrimEnd();
				}else{
					tex依頼主部署.Text    = sList[iPos++].Trim();
				}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END

// ADD 2005.06.01 東都）伊賀 輸送商品コード追加 START
				s輸送商品親コード         = sList[39].Trim();
				s輸送商品子コード         = sList[40].Trim();
				輸送商品個数重量制御();
// ADD 2005.06.01 東都）伊賀 輸送商品コード追加 END

				nUD個数.Value             = decimal.Parse(sList[iPos++].Trim());
// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 START
//// MOD 2005.05.17 東都）小童谷 才数追加 START
////				nUD重量.Value             = decimal.Parse(sList[iPos++].Trim());
//				if(i才数ＦＧ == 0)
//					nUD重量.Value         = decimal.Parse(sList[37].Trim());
//				else
//					nUD重量.Value         = decimal.Parse(sList[17].Trim());
//				iPos++;
//// MOD 2005.05.17 東都）小童谷 才数追加 END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
				if(gs重量入力制御 == "1"){
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
					if(i才数ＦＧ == 0){
						nUD重量.Value         = decimal.Parse(sList[37].Trim());
						if(decimal.Parse(sList[17]) > 0){
							texメッセージ.Text = "ワーニング：重量(kg)が入力されているにもかかわらず、\r\n"
												+ "エントリーオプションで才数が選択されています";
							ビープ音();
//						MessageBox.Show("重量(kg)が入力されているにもかかわらず、\n"
//										+ "エントリーオプションで才数が選択されています"
//										,"エントリーオプション設定ワーニング"
//										,MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}else{
						nUD重量.Value         = decimal.Parse(sList[17].Trim());
						if(decimal.Parse(sList[37]) > 0){
							texメッセージ.Text = "ワーニング：才数が入力されているにもかかわらず、\r\n"
												+ "エントリーオプションで重量(kg)が選択されています";
							ビープ音();
//						MessageBox.Show("才数が入力されているにもかかわらず、\n"
//										+ "エントリーオプションで重量(kg)が選択されています"
//										,"エントリーオプション設定ワーニング"
//										,MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
				}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
				iPos++;
// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 END

				tex輸送名親.Text          = sList[iPos++].TrimEnd();
				tex輸送名子.Text          = sList[iPos++].TrimEnd();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//				tex記事名１.Text          = sList[iPos++].TrimEnd();
//				tex記事名２.Text          = sList[iPos++].TrimEnd();
//				tex記事名３.Text          = sList[iPos++].TrimEnd();
				if(gsオプション[18].Equals("1")){
					tex記事名１.Text      = sList[iPos++].TrimEnd();
					tex記事名２.Text      = sList[iPos++].TrimEnd();
					tex記事名３.Text      = sList[iPos++].TrimEnd();
// MOD 2011.07.14 東都）高木 記事行の追加 START
					if(sList.Length > 41){
						tex記事名４.Text      = sList[41].TrimEnd();
						tex記事名５.Text      = sList[42].TrimEnd();
						tex記事名６.Text      = sList[43].TrimEnd();
					}
// MOD 2011.07.14 東都）高木 記事行の追加 END
				}else{
					tex記事名１.Text      = sList[iPos++].Trim();
					tex記事名２.Text      = sList[iPos++].Trim();
					tex記事名３.Text      = sList[iPos++].Trim();
// MOD 2011.07.14 東都）高木 記事行の追加 START
					if(sList.Length > 41){
						tex記事名４.Text      = sList[41].Trim();
						tex記事名５.Text      = sList[42].Trim();
						tex記事名６.Text      = sList[43].Trim();
					}
// MOD 2011.07.14 東都）高木 記事行の追加 END
				}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 START
//				nUD保険金額.Value         = decimal.Parse(sList[iPos++].Trim());
				decimal d保険金額         = decimal.Parse(sList[iPos++].TrimEnd());
				if(d保険金額 < 0){
					nUD保険金額.Minimum   = d保険金額;
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) START
//				}else if(d保険金額 > 30){
				}else if(d保険金額 > gl保険金額上限){
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) END
					nUD保険金額.Maximum   = d保険金額;
				}
				nUD保険金額.Value         = d保険金額;
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 END
				s更新年月日               = sList[iPos++].Trim();

				tex依頼主電話番号１.Text  = sList[iPos++].Trim();
				tex依頼主電話番号２.Text  = sList[iPos++].Trim();
				tex依頼主電話番号３.Text  = sList[iPos++].Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//				tex依頼主住所１.Text      = sList[iPos++].Trim();
//				tex依頼主住所２.Text      = sList[iPos++].Trim();
//				tex依頼主名前１.Text      = sList[iPos++].Trim();
//				tex依頼主名前２.Text      = sList[iPos++].Trim();
				if(gsオプション[18].Equals("1")){
					tex依頼主住所１.Text  = sList[iPos++].TrimEnd();
					tex依頼主住所２.Text  = sList[iPos++].TrimEnd();
					tex依頼主名前１.Text  = sList[iPos++].TrimEnd();
					tex依頼主名前２.Text  = sList[iPos++].TrimEnd();
				}else{
					tex依頼主住所１.Text  = sList[iPos++].Trim();
					tex依頼主住所２.Text  = sList[iPos++].Trim();
					tex依頼主名前１.Text  = sList[iPos++].Trim();
					tex依頼主名前２.Text  = sList[iPos++].Trim();
				}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
				tex依頼主郵便番号１.Text  = sList[iPos++].Trim();
				tex依頼主郵便番号２.Text  = sList[iPos++].Trim();
				string s請求先ＣＤ        = sList[iPos++].Trim();
				string s請求先部課ＣＤ    = sList[iPos++].Trim();
				tex依頼主請求先.Text = "";
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 START
				tex請求先コード.Text      = s請求先ＣＤ;
				tex請求先部課コード.Text  = s請求先部課ＣＤ;
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 END
				tex輸送コード親.Text   = "";
// ADD 2005.06.01 東都）伊賀 輸送商品コード追加 START
				tex輸送コード子.Text = "";
// ADD 2005.06.01 東都）伊賀 輸送商品コード追加 END
				tex記事コード.Text   = "";
//				if(System.IO.File.Exists("icon\\"+sファイル名))
//				{
//					btnアイコン.Image = new Bitmap("icon\\"+sファイル名);
					btnアイコン.Image = imageList64.Images[アイコンイメージの取得(sファイル名)];
//				}
				if(gsa請求先ＣＤ != null && s請求先ＣＤ.Length > 0)
				{
					if(gsa請求先ＣＤ != null)
					{
						for(int iCnt = 0 ; iCnt < gsa請求先ＣＤ.Length; iCnt++ )
						{
							if(gsa請求先ＣＤ[iCnt] == null || gsa請求先部課ＣＤ[iCnt] == null)
								continue;
							if(gsa請求先ＣＤ[iCnt] == s請求先ＣＤ && gsa請求先部課ＣＤ[iCnt] == s請求先部課ＣＤ)
							{
								tex依頼主請求先.Text = gsa請求先部課名[iCnt];
								break;
							}
						}
					}
				}
// MOD 2009.09.09 東都）高木 画面表示不具合の調整 
				s依頼主ＣＤ         = tex依頼主コード.Text;
				s前回検索依頼主ＣＤ = tex依頼主コード.Text;
// ADD 2005.05.12 東都）小童谷 依頼主重量 START
// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 STRAT
//// MOD 2005.05.17 東都）小童谷 才数追加 START
////				d重量 = decimal.Parse(sList[36].Trim());
//				if(i才数ＦＧ == 0)
//					d重量 = decimal.Parse(sList[38]);
//				else
//					d重量 = decimal.Parse(sList[36]);
//// MOD 2005.05.17 東都）小童谷 才数追加 END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
				if(gs重量入力制御 == "1"){
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
					if(i才数ＦＧ == 0){ 
					// 才数の時
						d重量 = decimal.Parse(sList[38]);
						if(d重量 == 0){
							// 重量÷８
							d重量 = decimal.Parse(sList[36]) / 8;
// MOD 2011.03.11 東都）高木 才数計算の補正 START
							d重量 = decimal.Truncate(d重量 + decimal.Parse("0.9"));
// MOD 2011.03.11 東都）高木 才数計算の補正 END
						}
					}else{
					// 重量の時
						d重量 = decimal.Parse(sList[36]);
						if(d重量 == 0){
							// 才数×８
							d重量 = decimal.Parse(sList[38]) * 8;
						}
					}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
				}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 END
// ADD 2005.05.12 東都）小童谷 依頼主重量 END
// MOD 2009.09.09 東都）高木 画面表示不具合の調整 
//				texメッセージ.Text = "";
				tex届け先コード.Focus();
			}
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 START
			if(tex届け先住所１.Text.Equals("※※支店止め※※"))
			{
				// ロック
				tex届け先郵便番号１.Enabled = false; // 届け先郵便番号１
				tex届け先郵便番号２.Enabled = false; // 届け先郵便番号２
				tex届け先住所１.Enabled = false; // 届け先住所１
				tex届け先住所２.Enabled = false; // 届け先住所２
				tex届け先住所３.Enabled = false; // 届け先住所３

				// 支店止めボタンを非表示、解除ボタンを表示
				btn支店止め.Visible = false;
				btn支店止め.Enabled = false;
				btn支店止め解除.Visible = true;
				btn支店止め解除.Enabled = true;
			}
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 END
		}

		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
// ADD 2007.11.05 東都）高木 依頼主情報の最新化 START
			s前回検索依頼主ＣＤ = "";
// ADD 2007.11.05 東都）高木 依頼主情報の最新化 END
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 START
			// ロックを解除
			tex届け先郵便番号１.Enabled = true; // 郵便番号１
			tex届け先郵便番号２.Enabled = true; // 郵便番号２
			tex届け先住所１.Enabled = true; // 住所１
			tex届け先住所２.Enabled = true; // 住所２
			tex届け先住所３.Enabled = true; // 住所３
			// 支店止めボタンを表示、解除ボタンを非表示
			btn支店止め.Visible = true;
			btn支店止め.Enabled = true;
			btn支店止め解除.Visible = false;
			btn支店止め解除.Enabled = false;
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 END
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
			if (g届先検索 == null)	 g届先検索 = new お届け先検索();
			g届先検索.Left = this.Left;
			g届先検索.Top = this.Top;

// MOD 2005.06.02 東都）小童谷 値の引継ぎなし START
//			g届先検索.sTcode = tex届け先コード.Text;
			g届先検索.sTcode = "";
// MOD 2005.06.02 東都）小童谷 値の引継ぎなし END
			g届先検索.ShowDialog();

			s届け先ＣＤ = g届先検索.sTcode;
// MOD 2005.05.24 東都）小童谷 画面高速化 END
			if(s届け先ＣＤ.Length > 0)
			{
				届け先項目クリア();
				tex届け先コード.Text = s届け先ＣＤ;
				届け先検索(false);
			}
			else
			{
				tex届け先コード.Focus();
			}
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
			if (g依頼検索 == null)	 g依頼検索 = new ご依頼主検索();
			g依頼検索.Left   = this.Left;
			g依頼検索.Top    = this.Top;
// MOD 2005.06.02 東都）小童谷 値の引継ぎなし START
//			g依頼検索.sIcode = tex依頼主コード.Text.Trim();
			g依頼検索.sIcode = "";
// MOD 2005.06.02 東都）小童谷 値の引継ぎなし END
			g依頼検索.ShowDialog(this);
// MOD 2005.05.24 東都）小童谷 画面高速化 END

			s依頼主ＣＤ = g依頼検索.sIcode;
			if(s依頼主ＣＤ.Length > 0)
			{
// MOD 2009.09.09 東都）高木 画面表示不具合の調整 
//				if(s依頼主ＣＤ != s前回検索依頼主ＣＤ)
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 START
//				if((s依頼主ＣＤ != s前回検索依頼主ＣＤ)
//					|| (s依頼主ＣＤ == s前回検索依頼主ＣＤ
//					&& tex依頼主電話番号１.Text.Trim() == ""))
//				{
//					依頼主項目クリア();
//					tex依頼主コード.Text = s依頼主ＣＤ;
//					依頼主検索();
//				}
//				else
//				{
//					tex依頼主コード.Text = s依頼主ＣＤ;
//					tex依頼主コード.Focus();
//				}
				依頼主項目クリア();
				tex依頼主コード.Text = s依頼主ＣＤ;
				依頼主検索();
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 END
			}
			else
			{
				tex依頼主コード.Focus();
			}
		}

		private void btn記事検索_Click(object sender, System.EventArgs e)
		{
// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			記事検索 画面 = new 記事検索();
//			画面.Left = this.Left;
//			画面.Top = this.Top;
			// ADD 2005.05.16 東都）伊賀 品名記事 START
//			画面.b輸送指示 = false;
			// ADD 2005.05.16 東都）伊賀 品名記事 END
//			画面.ShowDialog();
			if (g記事検索 == null)	 g記事検索 = new 記事検索();
			g記事検索.Left  = this.Left;
			g記事検索.Top   = this.Top;
			g記事検索.b輸送指示 = false;
			g記事検索.Text                 = "is-2 記事検索";
			g記事検索.lab記事タイトル.Text = "記事検索";
			g記事検索.ShowDialog();
// MOD 2005.05.24 東都）小童谷 画面高速化 END

// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//			tex記事名１.Text = tex記事名１.Text.Trim();
//			tex記事名２.Text = tex記事名２.Text.Trim();
//			tex記事名３.Text = tex記事名３.Text.Trim();
			if(gsオプション[18].Equals("1")){
				tex記事名１.Text = tex記事名１.Text.TrimEnd();
				tex記事名２.Text = tex記事名２.Text.TrimEnd();
				tex記事名３.Text = tex記事名３.Text.TrimEnd();
// MOD 2011.07.14 東都）高木 記事行の追加 START
				tex記事名４.Text = tex記事名４.Text.TrimEnd();
				tex記事名５.Text = tex記事名５.Text.TrimEnd();
				tex記事名６.Text = tex記事名６.Text.TrimEnd();
// MOD 2011.07.14 東都）高木 記事行の追加 END
			}else{
				tex記事名１.Text = tex記事名１.Text.Trim();
				tex記事名２.Text = tex記事名２.Text.Trim();
				tex記事名３.Text = tex記事名３.Text.Trim();
// MOD 2011.07.14 東都）高木 記事行の追加 START
				tex記事名４.Text = tex記事名４.Text.Trim();
				tex記事名５.Text = tex記事名５.Text.Trim();
				tex記事名６.Text = tex記事名６.Text.Trim();
// MOD 2011.07.14 東都）高木 記事行の追加 END
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END

// MOD 2011.07.14 東都）高木 記事行の追加 START
//			if(tex記事名１.Text == "")
//			{
//				tex記事名１.Text = g記事検索.s記事;
//			}
//			else
//			{
//				if(tex記事名２.Text == "")
//				{
//					tex記事名２.Text = g記事検索.s記事;
//				}
//				else
//				{
//					if(tex記事名３.Text == "")
//						tex記事名３.Text = g記事検索.s記事;
//				}
//			}
			if(tex記事名１.Text == ""){
				tex記事名１.Text = g記事検索.s記事;
			}else if(tex記事名２.Text == ""){
				tex記事名２.Text = g記事検索.s記事;
			}else if(tex記事名３.Text == ""){
				tex記事名３.Text = g記事検索.s記事;
// MOD 2011.09.26 東都）高木 記事行の追加（３行・６行切替対応） START
//			}else if(tex記事名４.Text == ""){
//				tex記事名４.Text = g記事検索.s記事;
//			}else if(tex記事名５.Text == ""){
//				tex記事名５.Text = g記事検索.s記事;
//			}else if(tex記事名６.Text == ""){
//				tex記事名６.Text = g記事検索.s記事;
//			}else if(tex記事名４.Enabled && tex記事名４.Text == ""){
//				tex記事名４.Text = g記事検索.s記事;
//			}else if(tex記事名５.Enabled && tex記事名５.Text == ""){
//				tex記事名５.Text = g記事検索.s記事;
//			}else if(tex記事名６.Enabled && tex記事名６.Text == ""){
//				tex記事名６.Text = g記事検索.s記事;
			// [２:３行入力]の時のみ入力不可
			}else if(gsオプション[7] != "2" && tex記事名４.Text == ""){
				tex記事名４.Text = g記事検索.s記事;
			}else if(gsオプション[7] != "2" && tex記事名５.Text == ""){
				tex記事名５.Text = g記事検索.s記事;
			}else if(gsオプション[7] != "2" && tex記事名６.Text == ""){
				tex記事名６.Text = g記事検索.s記事;
// MOD 2011.09.26 東都）高木 記事行の追加（３行・６行切替対応） END
			}
// MOD 2011.07.14 東都）高木 記事行の追加 END
			texメッセージ.Text = "";
			tex記事コード.Focus();
		}

		private void btn住所検索_Click(object sender, System.EventArgs e)
		{
			// 空白除去
			tex届け先郵便番号１.Text = tex届け先郵便番号１.Text.Trim();
			tex届け先郵便番号２.Text = tex届け先郵便番号２.Text.Trim();

			// 入力チェック
			if(!半角チェック(tex届け先郵便番号１,"郵便番号１")) return;
			if(!半角チェック(tex届け先郵便番号２,"郵便番号２")) return;

// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			住所検索 画面 = new 住所検索();
//			画面.Left = this.Left + 404;
//			画面.Top = this.Top;
//			//画面初期値の設定
//			画面.s郵便番号１ = tex届け先郵便番号１.Text;
//			画面.s郵便番号２ = tex届け先郵便番号２.Text;
//			画面.ShowDialog();
//			//戻り値の設定
//			if(画面.s住所ＣＤ.Length > 0)
			if (g住所検索 == null)	 g住所検索 = new 住所検索();
			g住所検索.Left = this.Left + 404;
			g住所検索.Top = this.Top;
			//画面初期値の設定
// MOD 2009.08.20 パソ）藤井　郵便番号の値引継ぎ  START
// MOD 2005.06.02 東都）小童谷 値の引継ぎなし START
			g住所検索.s郵便番号１ = tex届け先郵便番号１.Text;
			g住所検索.s郵便番号２ = tex届け先郵便番号２.Text;
//			g住所検索.s郵便番号１ = "";
//			g住所検索.s郵便番号２ = "";
// MOD 2005.06.02 東都）小童谷 値の引継ぎなし END
// MOD 2009.08.20 パソ）藤井　郵便番号の値引継ぎ  END
// MOD 2009.09.09 東都）高木 画面表示不具合の調整 
			g住所検索.s住所       = tex届け先住所１.Text;
			g住所検索.ShowDialog();
			//戻り値の設定
			if(g住所検索.s住所ＣＤ.Length > 0)
			{
//				tex届け先郵便番号１.Text = 画面.s郵便番号１;
//				tex届け先郵便番号２.Text = 画面.s郵便番号２;
//				if(画面.s住所.Length > 60)
				tex届け先郵便番号１.Text = g住所検索.s郵便番号１;
				tex届け先郵便番号２.Text = g住所検索.s郵便番号２;
				if(g住所検索.s住所.Length > 60)
				{
//					tex届け先住所１.Text     = 画面.s住所.Substring(0,20);
//					tex届け先住所２.Text     = 画面.s住所.Substring(20,20);
//					tex届け先住所３.Text     = 画面.s住所.Substring(40,20);
					tex届け先住所１.Text     = g住所検索.s住所.Substring(0,20);
					tex届け先住所２.Text     = g住所検索.s住所.Substring(20,20);
					tex届け先住所３.Text     = g住所検索.s住所.Substring(40,20);
				}
//				else if(画面.s住所.Length > 40)
				else if(g住所検索.s住所.Length > 40)
				{
//					tex届け先住所１.Text     = 画面.s住所.Substring(0,20);
//					tex届け先住所２.Text     = 画面.s住所.Substring(20,20);
//					tex届け先住所３.Text     = 画面.s住所.Substring(40);
					tex届け先住所１.Text     = g住所検索.s住所.Substring(0,20);
					tex届け先住所２.Text     = g住所検索.s住所.Substring(20,20);
					tex届け先住所３.Text     = g住所検索.s住所.Substring(40);
				}
//				else if(画面.s住所.Length > 20)
				else if(g住所検索.s住所.Length > 20)
				{
//					tex届け先住所１.Text     = 画面.s住所.Substring(0,20);
//					tex届け先住所２.Text     = 画面.s住所.Substring(20);
					tex届け先住所１.Text     = g住所検索.s住所.Substring(0,20);
					tex届け先住所２.Text     = g住所検索.s住所.Substring(20);
					tex届け先住所３.Text     = "";
				}
				else
				{
//					tex届け先住所１.Text     = 画面.s住所;
					tex届け先住所１.Text     = g住所検索.s住所;
					tex届け先住所２.Text     = "";
					tex届け先住所３.Text     = "";
				}
// MOD 2005.05.24 東都）小童谷 画面高速化 END
				//フォーカス設定
				tex届け先住所２.Focus();
			}
			else
			{
				tex届け先郵便番号１.Focus();
			}
		}

		private void btn複写_Click(object sender, System.EventArgs e)
		{
// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			お届け先検索 画面 = new お届け先検索();
//			画面.Left = this.Left + 404;
//			画面.Top = this.Top;
//
//			画面.sTcode = tex届け先コード.Text;
//			画面.ShowDialog();
//
//			s届け先ＣＤ = 画面.sTcode;
			if (g届先検索 == null)	 g届先検索 = new お届け先検索();
			g届先検索.Left = this.Left;
			g届先検索.Top = this.Top;

// MOD 2005.06.16 東都）小童谷 値の引継ぎなし START
//			g届先検索.sTcode = tex届け先コード.Text;
			g届先検索.sTcode = "";
// MOD 2005.06.16 東都）小童谷 値の引継ぎなし END
			g届先検索.ShowDialog();

			s届け先ＣＤ = g届先検索.sTcode;
// MOD 2005.05.24 東都）小童谷 画面高速化 END
			if(s届け先ＣＤ.Length > 0)
			{
				届け先検索(true);
			}
			else
			{
				tex届け先コード.Focus();
			}
		}

// MOD 2005.05.26 東都）伊賀 輸送商品仕様変更 START
		private void btn輸送検索_Click(object sender, System.EventArgs e)
		{
// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			記事検索 画面 = new 記事検索();
//			画面.Left = this.Left;
//			画面.Top = this.Top;
// ADD 2005.05.16 東都）伊賀 輸送指示 START
//			画面.b輸送指示 = true;
// ADD 2005.05.16 東都）伊賀 輸送指示 END
//			画面.ShowDialog();
			if (g記事検索 == null)	 g記事検索 = new 記事検索();
			g記事検索.Left  = this.Left;
			g記事検索.Top   = this.Top;
			g記事検索.b輸送指示 = true;
			g記事検索.Text                 = "is-2 輸送商品検索";
			g記事検索.lab記事タイトル.Text = "輸送商品検索";
// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 START
// MOD 2005.06.01 東都）伊賀 輸送商品仕様変更 START
//			if (tex輸送コード親.Text.Trim().Length == 0 || s輸送商品親コード.Length == 0)
//			{
//				//輸送商品親検索
//				g記事検索.s輸送商品部門 = "0000";
//			}
//			else
//			{
//				//輸送商品子検索
//				g記事検索.s輸送商品部門 = s輸送商品親コード;
//			}
			//輸送商品親検索
			g記事検索.s輸送商品部門 = "0000";
// MOD 2005.06.01 東都）伊賀 輸送商品仕様変更 END
// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 START
			g記事検索.ShowDialog();
// MOD 2005.05.24 東都）小童谷 画面高速化 END

// MOD 2005.05.26 東都）伊賀 輸送商品仕様変更 START
//			tex輸送名親.Text = tex輸送名親.Text.Trim();
//			tex輸送名子.Text = tex輸送名子.Text.Trim();
//			if(tex輸送名親.Text.Length == 0)
//			{
//				tex輸送名親.Text = g記事検索.s記事;
//			}
//			else
//			{
//				if(tex輸送名子.Text == "")
//					tex輸送名子.Text = g記事検索.s記事;
//			}
// MOD 2005.06.01 東都）伊賀 輸送商品仕様変更 START
//			if (tex輸送コード親.Text.Trim().Length == 0 || s輸送商品親コード.Length == 0)
//			{
//				//輸送商品親検索
//				if (g記事検索.sKcode.Length != 0)
//				{
//					tex輸送コード親.Text = g記事検索.sKcode2;
//					tex輸送名親.Text = g記事検索.s記事２;
//					if (!g記事検索.sKcode.Equals("dumycode"))
//					{
//						tex輸送コード子.Text = g記事検索.sKcode;
//						tex輸送名子.Text = g記事検索.s記事;
//						s輸送商品子コード = g記事検索.sKcode;
//					}
//					else
//					{
//						tex輸送コード子.Text = " ";
//						tex輸送名子.Text = "";
//						s輸送商品子コード = "";
//					}
//					s輸送商品親コード = g記事検索.sKcode2;
//					tex記事コード.Focus();
//				}
//			}
//			else
//			{
//				if (g記事検索.sKcode.Length != 0)
//				{
//					//輸送商品子検索
//					tex輸送コード子.Text = g記事検索.sKcode;
//					tex輸送名子.Text = g記事検索.s記事;
//					s輸送商品子コード = g記事検索.sKcode;
//					tex記事コード.Focus();
//				}
//			}
			//輸送商品親検索
			if (g記事検索.sKcode.Length != 0)
			{
				tex輸送コード親.Text = g記事検索.sKcode2;
				tex輸送名親.Text = g記事検索.s記事２;
				if (!g記事検索.sKcode.Equals("dumycode"))
				{
					tex輸送コード子.Text = g記事検索.sKcode;
					tex輸送名子.Text = g記事検索.s記事;
					s輸送商品子コード = g記事検索.sKcode;
				}
				else
				{
					tex輸送コード子.Text = " ";
					tex輸送名子.Text = "";
					s輸送商品子コード = "";
				}
				s輸送商品親コード = g記事検索.sKcode2;
// ADD 2005.06.07 東都）伊賀 輸送商品仕様変更 START
				輸送商品個数重量制御();
// ADD 2005.06.07 東都）伊賀 輸送商品仕様変更 END
				tex記事コード.Focus();
			}
// MOD 2005.06.01 東都）伊賀 輸送商品仕様変更 END
// MOD 2005.05.26 東都）伊賀 輸送商品仕様変更 END
			texメッセージ.Text = "";
		}
// MOD 2005.05.26 東都）伊賀 輸送商品仕様変更 END

		private void btnアイコン_Click(object sender, System.EventArgs e)
		{
// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			アイコン選択 画面 = new アイコン選択();
//			画面.Left = this.Left + (this.Width  - 画面.Width)  / 2;
//			画面.Top  = this.Top  + (this.Height - 画面.Height) / 2;
//			int iアイコン = アイコンイメージの取得(sファイル名);
//			if( iアイコン > 0 )
//				画面.iアイコン = iアイコン; 
//			画面.ShowDialog(this);
//			if( iアイコン != 画面.iアイコン )
			if (gアイコン == null)	 gアイコン = new アイコン選択();
			gアイコン.Left = this.Left + (this.Width  - gアイコン.Width)  / 2;
			gアイコン.Top  = this.Top  + (this.Height - gアイコン.Height) / 2;
			int iアイコン = アイコンイメージの取得(sファイル名);
			if( iアイコン > 0 )
				gアイコン.iアイコン = iアイコン; 
			gアイコン.ShowDialog(this);
			if( iアイコン != gアイコン.iアイコン )
			{
//				sファイル名       = sアイコン[画面.iアイコン];
//				btnアイコン.Image = imageList64.Images[画面.iアイコン];
				sファイル名       = sアイコン[gアイコン.iアイコン];
				btnアイコン.Image = imageList64.Images[gアイコン.iアイコン];
			}
// MOD 2005.05.24 東都）小童谷 画面高速化 END
/*
			openFileDialog1.InitialDirectory
//				 = System.IO.Directory.GetCurrentDirectory() + "\\icon";
				 = gsアプリフォルダ + "\\icon";
			if(openFileDialog1.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
//					System.Drawing.Bitmap bm = new Bitmap(openFileDialog1.FileName);
					int iLastPath = openFileDialog1.FileName.LastIndexOf('\\');
					if(iLastPath >= 0)
						sファイル名 = openFileDialog1.FileName.Substring(iLastPath + 1);
					else
						sファイル名 = openFileDialog1.FileName;
//					btnアイコン.Image = bm;
					btnアイコン.Image = imageList64.Images[アイコンイメージの取得(sファイル名)];
				}
				catch(Exception){};
			}
*/
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

		private void btn更新_Click(object sender, System.EventArgs e)
		{
			texメッセージ.Text = "";

			tex雛型名.Text             = tex雛型名.Text.Trim();
			tex届け先コード.Text       = tex届け先コード.Text.Trim();
			tex届け先電話番号１.Text   = tex届け先電話番号１.Text.Trim();
			tex届け先電話番号２.Text   = tex届け先電話番号２.Text.Trim();
			tex届け先電話番号３.Text   = tex届け先電話番号３.Text.Trim();
			tex届け先郵便番号１.Text   = tex届け先郵便番号１.Text.Trim();
			tex届け先郵便番号２.Text   = tex届け先郵便番号２.Text.Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//			tex届け先住所１.Text       = tex届け先住所１.Text.Trim();
//			tex届け先住所２.Text       = tex届け先住所２.Text.Trim();
//			tex届け先住所３.Text       = tex届け先住所３.Text.Trim();
//			tex届け先名前１.Text       = tex届け先名前１.Text.Trim();
//			tex届け先名前２.Text       = tex届け先名前２.Text.Trim();
//			tex依頼主コード.Text       = tex依頼主コード.Text.Trim();
//			tex依頼主部署.Text         = tex依頼主部署.Text.Trim();
			if(gsオプション[18].Equals("1")){
				tex届け先住所１.Text   = tex届け先住所１.Text.TrimEnd();
				tex届け先住所２.Text   = tex届け先住所２.Text.TrimEnd();
				tex届け先住所３.Text   = tex届け先住所３.Text.TrimEnd();
				tex届け先名前１.Text   = tex届け先名前１.Text.TrimEnd();
				tex届け先名前２.Text   = tex届け先名前２.Text.TrimEnd();
				tex依頼主部署.Text     = tex依頼主部署.Text.TrimEnd();
			}else{
				tex届け先住所１.Text   = tex届け先住所１.Text.Trim();
				tex届け先住所２.Text   = tex届け先住所２.Text.Trim();
				tex届け先住所３.Text   = tex届け先住所３.Text.Trim();
				tex届け先名前１.Text   = tex届け先名前１.Text.Trim();
				tex届け先名前２.Text   = tex届け先名前２.Text.Trim();
				tex依頼主部署.Text     = tex依頼主部署.Text.Trim();
			}
			tex依頼主コード.Text       = tex依頼主コード.Text.Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
//			texお客様管理番号.Text     = texお客様管理番号.Text.Trim();
			tex輸送コード親.Text         = tex輸送コード親.Text.Trim();
			tex記事コード.Text         = tex記事コード.Text.Trim();
//			tex輸送名親.Text           = tex輸送名親.Text.Trim();
//			tex輸送名子.Text           = tex輸送名子.Text.Trim();
			tex輸送名親.Text           = tex輸送名親.Text.TrimEnd();
			tex輸送名子.Text           = tex輸送名子.Text.TrimEnd();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//			tex記事名１.Text           = tex記事名１.Text.TrimEnd();
//			tex記事名２.Text           = tex記事名２.Text.TrimEnd();
//			tex記事名３.Text           = tex記事名３.Text.TrimEnd();
			if(gsオプション[18].Equals("1")){
				tex記事名１.Text       = tex記事名１.Text.TrimEnd();
				tex記事名２.Text       = tex記事名２.Text.TrimEnd();
				tex記事名３.Text       = tex記事名３.Text.TrimEnd();
// MOD 2011.07.14 東都）高木 記事行の追加 START
				tex記事名４.Text       = tex記事名４.Text.TrimEnd();
				tex記事名５.Text       = tex記事名５.Text.TrimEnd();
				tex記事名６.Text       = tex記事名６.Text.TrimEnd();
				tex依頼主請求先.Text   = tex依頼主請求先.Text.TrimEnd();
// MOD 2011.07.14 東都）高木 記事行の追加 END
			}else{
				tex記事名１.Text       = tex記事名１.Text.Trim();
				tex記事名２.Text       = tex記事名２.Text.Trim();
				tex記事名３.Text       = tex記事名３.Text.Trim();
// MOD 2011.07.14 東都）高木 記事行の追加 START
				tex記事名４.Text       = tex記事名４.Text.Trim();
				tex記事名５.Text       = tex記事名５.Text.Trim();
				tex記事名６.Text       = tex記事名６.Text.Trim();
				tex依頼主請求先.Text   = tex依頼主請求先.Text.Trim();
// MOD 2011.07.14 東都）高木 記事行の追加 END
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
//			tex依頼主請求先.Text       = tex依頼主請求先.Text.Trim();
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 START
			tex請求先コード.Text       = tex請求先コード.Text.Trim();
			tex請求先部課コード.Text   = tex請求先部課コード.Text.Trim();
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 END

			if(!必須チェック(tex雛型名,"名称")) return;
			if(!必須チェック(tex届け先電話番号１,"届け先電話番号１")) return;
			if(!必須チェック(tex届け先電話番号２,"届け先電話番号２")) return;
			if(!必須チェック(tex届け先電話番号３,"届け先電話番号３")) return;
			if(!必須チェック(tex届け先郵便番号１,"届け先郵便番号１")) return;
			if(!必須チェック(tex届け先郵便番号２,"届け先郵便番号２")) return;
			if(!必須チェック(tex届け先住所１,"届け先住所１")) return;
			if(!必須チェック(tex届け先名前１,"届け先名前１")) return;
			if(!必須チェック(tex依頼主コード,"依頼主コード")) return;
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 START
//			if(!必須チェック(tex依頼主請求先,"依頼主請求先"))
//			{
//				tex依頼主コード.Focus();
//				return;
//			}
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 END
// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 START
			//輸送名親のみ入力されて、輸送名子が存在する場合エラー
			if(tex輸送名親.Text.TrimEnd().Length != 0 && tex輸送名子.Text.TrimEnd().Length == 0)
			{
				string[] sList = {""};
				try
				{
					if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
// MOD 2011.06.07 東都）高木 王子運送の対応 START
					if (gs会員ＣＤ.Substring(0,1) != "J"){
// MOD 2011.06.07 東都）高木 王子運送の対応 END
						sList = sv_kiji.Get_kiji(gsaユーザ,"yusoshohin",s輸送商品親コード);
// MOD 2011.06.07 東都）高木 王子運送の対応 START
					}else{
						sList = sv_kiji.Get_kiji(gsaユーザ,"Jyusoshohin",s輸送商品親コード);
					}
// MOD 2011.06.07 東都）高木 王子運送の対応 END
				}
				catch (System.Net.WebException)
				{
					texメッセージ.Text = gs通信エラー;
					ビープ音();
					return;
				}
				catch (Exception ex)
				{
					texメッセージ.Text = "通信エラー：" + ex.Message;
					ビープ音();
					return;
				}
				// カーソルをデフォルトに戻す
				Cursor = System.Windows.Forms.Cursors.Default;

				// エラー時
				if(sList[0].Equals("正常終了"))
				{
					//エラーメッセージ保留
					MessageBox.Show("輸送商品親が入力されている場合、輸送商品子は必須項目です","入力チェック",MessageBoxButtons.OK);
					tex輸送コード子.Focus();
					return;
				}
				else if(!sList[0].Equals("該当データがありません"))
				{
					texメッセージ.Text = sList[0];
					ビープ音();
					return;
				}
			}
// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 END

			if(!半角チェック(tex届け先コード,"届け先コード")) return;
			if(!数値チェック(tex届け先電話番号１,"届け先電話番号１")) return;
			if(!数値チェック(tex届け先電話番号２,"届け先電話番号２")) return;
			if(!数値チェック(tex届け先電話番号３,"届け先電話番号３")) return;
			if(!半角チェック(tex届け先郵便番号１,"届け先郵便番号１")) return;
			if(!半角チェック(tex届け先郵便番号２,"届け先郵便番号２")) return;
			if(!半角チェック(tex依頼主コード,"依頼主コード")) return;
//			if(!半角チェック(texお客様管理番号,"お客様管理番号")) return;
//			if(!半角チェック(tex輸送コード親      )) return;
//			if(!半角チェック(tex記事コード      )) return;
			if(!全角チェック(tex雛型名,"名称")) return;
// MOD 2011.12.08 東都）高木 住所・名前の半角入力可 START
//			if(!全角チェック(tex届け先住所１,"届け先住所１")) return;
//			if(!全角チェック(tex届け先住所２,"届け先住所２")) return;
//			if(!全角チェック(tex届け先住所３,"届け先住所３")) return;
//			if(!全角チェック(tex届け先名前１,"届け先名前１")) return;
//			if(!全角チェック(tex届け先名前２,"届け先名前２")) return;
//			if(!全角チェック(tex依頼主部署,"依頼主部署")) return;
			if(!全角変換チェック(tex届け先住所１,"届け先住所１")) return;
			if(!全角変換チェック(tex届け先住所２,"届け先住所２")) return;
			if(!全角変換チェック(tex届け先住所３,"届け先住所３")) return;
			if(!全角変換チェック(tex届け先名前１,"届け先名前１")) return;
			if(!全角変換チェック(tex届け先名前２,"届け先名前２")) return;
			if(!全角変換チェック(tex依頼主部署,"依頼主担当")) return;
// MOD 2011.12.08 東都）高木 住所・名前の半角入力可 END
//			if(!全角チェック(tex輸送名親,"輸送名１")) return;
//			if(!全角チェック(tex輸送名子,"輸送名２")) return;
// MOD 2009.12.01 東都）高木 全角半角混在可能にする START
//			if(!全角チェック(tex記事名１,"記事名１")) return;
//			if(!全角チェック(tex記事名２,"記事名２")) return;
//			if(!全角チェック(tex記事名３,"記事名３")) return;
// MOD 2011.07.28 東都）高木 記事行の追加（文字数制限の追加） START
//			if(!混在チェック(tex記事名１,"記事名１")) return;
//			if(!混在チェック(tex記事名２,"記事名２")) return;
//			if(!混在チェック(tex記事名３,"記事名３")) return;
//// MOD 2009.12.01 東都）高木 全角半角混在可能にする END
//// MOD 2011.07.14 東都）高木 記事行の追加 START
//			if(!混在チェック(tex記事名４,"記事名４")) return;
//			if(!混在チェック(tex記事名５,"記事名５")) return;
//			if(!混在チェック(tex記事名６,"記事名６")) return;
//// MOD 2011.07.14 東都）高木 記事行の追加 END
			// 品名記事４～６のいずれかにデータある場合
			if(tex記事名４.Text.Trim().Length > 0
				|| tex記事名５.Text.Trim().Length > 0
				|| tex記事名６.Text.Trim().Length > 0
			){
				if(!混在チェック２(tex記事名１,"記事名１",18)) return;
				if(!混在チェック２(tex記事名２,"記事名２",18)) return;
				if(!混在チェック２(tex記事名３,"記事名３",18)) return;
				if(!混在チェック２(tex記事名４,"記事名４",18)) return;
				if(!混在チェック２(tex記事名５,"記事名５",18)) return;
				if(!混在チェック２(tex記事名６,"記事名６",18)) return;
			}else{
				if(!混在チェック(tex記事名１,"記事名１")) return;
				if(!混在チェック(tex記事名２,"記事名２")) return;
				if(!混在チェック(tex記事名３,"記事名３")) return;
			}
// MOD 2011.07.28 東都）高木 記事行の追加（文字数制限の追加） END
			if(!b更新ＦＧ){
				if(nUD登録番号.Text.Length == 0 )
				{
					MessageBox.Show("必須項目（登録番号）が入力されていません","入力チェック",MessageBoxButtons.OK);
					nUD登録番号.Focus();
					return;
				}
				if(!範囲チェック(nUD登録番号,"登録番号")) return;
				if(nUD登録番号.Value == 0 )
				{
					MessageBox.Show("必須項目（登録番号）が入力されていません","入力チェック",MessageBoxButtons.OK);
					nUD登録番号.Focus();
					return;
				}
			}

			if(nUD個数.Text.Length == 0 )
			{
				MessageBox.Show("必須項目（個数）が入力されていません","入力チェック",MessageBoxButtons.OK);
				nUD個数.Focus();
				return;
			}
			if(!範囲チェック(nUD個数,"個数")) return;
			if(nUD個数.Value == 0 )
			{
				MessageBox.Show("必須項目（個数）が入力されていません","入力チェック",MessageBoxButtons.OK);
				nUD個数.Focus();
				return;
			}

// ADD 2009.03.02 東都）高木 重量０入力時の不具合調整 START
			//依頼主情報の検索
			s依頼主ＣＤ = tex依頼主コード.Text;
			依頼主項目クリア２();
			tex依頼主コード.Text = s依頼主ＣＤ;
			依頼主検索();
			//依頼主もしくは請求先が存在しない場合
			if(tex依頼主請求先.Text.Trim().Length == 0){
// MOD 2009.08.25 東都）高木 エントリー登録での請求先の存在チェックの追加 START
// MOD 2010.09.07 東都）高木 請求先チェックの表示変更 START
//				MessageBox.Show("入力されたご依頼主コードの請求先はマスタに存在しません"
//					,"入力チェック",MessageBoxButtons.OK);
				string s請求先ＣＤ = tex請求先コード.Text.Trim();
				if(tex請求先部課コード.Text.Trim().Length > 0){
					s請求先ＣＤ += "-" + tex請求先部課コード.Text.Trim();
				}
				MessageBox.Show("入力されたご依頼主の請求先["+s請求先ＣＤ+"]は登録されていません"
					,"入力チェック",MessageBoxButtons.OK);
// MOD 2010.09.07 東都）高木 請求先チェックの表示変更 END
				tex依頼主コード.Focus();
// MOD 2009.08.25 東都）高木 エントリー登録での請求先の存在チェックの追加 END
				return;
			}
			panel2.Refresh();
// ADD 2009.03.02 東都）高木 重量０入力時の不具合調整 END
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 START
			// 雛形更新モードで開かれた場合
			if(i雛型ＮＯ > 0){
				if(s修正前_依頼主ＣＤ == tex依頼主コード.Text.TrimEnd()){
					if(s修正前_請求先ＣＤ != tex請求先コード.Text.TrimEnd()
					|| s修正前_請求先部課 != tex請求先部課コード.Text.TrimEnd()
					|| s修正前_請求先名   != tex依頼主請求先.Text.TrimEnd()){
						MessageBox.Show(
							"請求先が、ご依頼主情報の最新の請求先に変更されました　"
							,"入力チェック"
							,MessageBoxButtons.OK
							,MessageBoxIcon.Information);
					}
				}
			}
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 END


// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
			if(gs重量入力制御 == "1"){
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
// MOD 2010.11.01 東都）高木 ご依頼主情報の重量値０対応 START
				if(d重量 > 0){
// MOD 2010.11.01 東都）高木 ご依頼主情報の重量値０対応 END
// MOD 2005.05.12 東都）小童谷 重量が０の場合、個数 * 依頼主の重量 START
//			if(nUD重量.Text.Length == 0 )
// MOD 2005.09.02 東都）小童谷 ValueをTextに START
//			if(nUD重量.Text.Length == 0 || nUD重量.Value == 0)
// MOD 2009.03.02 東都）高木 重量０入力時の不具合調整 START
//			if(nUD重量.Text.Length == 0 || nUD重量.Text == "0")
					if(nUD重量.Text.Length == 0 || nUD重量.Text == "0"
						 || nUD重量.Text.Replace("0","").Length == 0)
// MOD 2009.03.02 東都）高木 重量０入力時の不具合調整 END
// MOD 2005.09.02 東都）小童谷 ValueをTextに END
					{
// MOD 2010.09.24 東都）高木 重量自動計算時の上限エラー対応 START
////				nUD重量.Value = 0;
//				nUD重量.Value = nUD個数.Value * d重量;
//// ADD 2009.03.02 東都）高木 重量０入力時の不具合調整 START
//				nUD重量.Text = (nUD個数.Value * d重量).ToString();
//				nUD重量.Refresh();
//// ADD 2009.03.02 東都）高木 重量０入力時の不具合調整 END
						if(nUD個数.Value * d重量 > nUD重量.Maximum){
							string sMsg = "";
							if(i才数ＦＧ == 0){
								sMsg = "才数の上限値 "+nUD重量.Maximum+" を超えました\n"
									 + "個数またはご依頼主の才数の設定を見直ししてください　";
							}else{
								sMsg = "重量の上限値 "+nUD重量.Maximum+" を超えました\n"
									 + "個数またはご依頼主の重量の設定を見直ししてください　";
							}
							MessageBox.Show(sMsg,"入力チェック",MessageBoxButtons.OK);
							nUD個数.Focus();
							return;
						}else{
							nUD重量.Value = nUD個数.Value * d重量;
							nUD重量.Text = (nUD個数.Value * d重量).ToString();
							nUD重量.Refresh();
						}
// MOD 2010.09.24 東都）高木 重量自動計算時の上限エラー対応 END
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 START
					}else{
						// 更新モード or 雛形参照モードで開かれた場合
						if(i雛型ＮＯ > 0){
							//個数が変更され、依頼主重量の計算値が異なる場合
							if(s修正前_個数 != nUD個数.Text.TrimEnd()){
								if(nUD重量.Value != nUD個数.Value * d重量){
									string sMsg = "";
									if(i才数ＦＧ == 0){
										sMsg = "個数が変更されました。 才数を "
										+ nUD個数.Value * d重量 +" に変更しますか？　";
									}else{
										sMsg = "個数が変更されました。 重量を "
										+ nUD個数.Value * d重量 +" に変更しますか？　";
									}
									DialogResult rstJyuryo
									 = MessageBox.Show(sMsg
										,"入力チェック"
										,MessageBoxButtons.YesNoCancel
										,MessageBoxIcon.Information);
									if(rstJyuryo == DialogResult.Yes){
// MOD 2010.09.24 東都）高木 重量自動計算時の上限エラー対応 START
//								nUD重量.Value = nUD個数.Value * d重量;
										if(nUD個数.Value * d重量 > nUD重量.Maximum){
											if(i才数ＦＧ == 0){
												sMsg = "才数の上限値 "+nUD重量.Maximum+" を超えました\n"
													 + "個数またはご依頼主の才数の設定を見直ししてください　";
											}else{
												sMsg = "重量の上限値 "+nUD重量.Maximum+" を超えました\n"
													 + "個数またはご依頼主の重量の設定を見直ししてください　";
											}
											MessageBox.Show(sMsg,"入力チェック",MessageBoxButtons.OK);
											nUD個数.Focus();
											return;
										}else{
											nUD重量.Value = nUD個数.Value * d重量;
											nUD重量.Text = (nUD個数.Value * d重量).ToString();
											nUD重量.Refresh();
										}
// MOD 2010.09.24 東都）高木 重量自動計算時の上限エラー対応 END
									}else if(rstJyuryo == DialogResult.No){
										;
									}else{
										return;
									}
								}
							}
						}
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 END
					}
// MOD 2005.05.12 東都）小童谷 重量が０の場合、個数 * 依頼主の重量 END
// MOD 2010.11.01 東都）高木 ご依頼主情報の重量値０対応 START
				}
// MOD 2010.11.01 東都）高木 ご依頼主情報の重量値０対応 END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
			}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END

// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
			if(gs重量入力制御 == "1"){
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
// MOD 2005.05.18 東都）小童谷 才数追加 START
//				if(!範囲チェック(nUD重量,"重量")) return;
				if(i才数ＦＧ == 0)
				{
					if(!範囲チェック(nUD重量,"才数")) return;
				}
				else
				{
					if(!範囲チェック(nUD重量,"重量")) return;
				}
// MOD 2005.05.18 東都）小童谷 才数追加 END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
			}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END

			if(nUD保険金額.Text.Length == 0 )
			{
				nUD保険金額.Value = 0;
			}
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 START
//			if(!範囲チェック(nUD保険金額,"保険金額")) return;
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) START
//			if(!範囲チェック(nUD保険金額,"保険金額（万円）",0,30,"")) return;
			if(!範囲チェック(nUD保険金額,"保険金額（万円）",0,gl保険金額上限,"")) return;
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) END
//			nUD保険金額.Refresh();
//			if(nUD保険金額.Value > 30){
//				MessageBox.Show("保険金額（万円）は、30以下を入力してください　"
//					, "入力チェック", MessageBoxButtons.OK);
//				nUD保険金額.Focus();
//				return;
//			}
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 END
// MOD 2016.06.10 BEVAS）松本 保険料入力チェック機能の追加 START
			//エントリーオプション：「保険金額」項目が「入力する」にチェック
			if(!gsオプション[10].Equals("1"))
			{
				//エントリーオプション：「保険金額入力チェック」項目が「チェックする」にチェック
				if(!gsオプション[24].Equals("1"))
				{
					//保険料の入力チェックを行なう
					long l保険料 = 0L;
					try
					{
						l保険料 = long.Parse(nUD保険金額.Value.ToString().Replace(",", ""));
					}
					catch(Exception ){}
					if(l保険料 >= gl保険金額チェック基準)
					{
						string s保険料チェックMsg =
									"保険金額が【" + gl保険金額チェック基準.ToString().Replace(",", "") + "万円】以上で入力されています。\n" +
									"処理を継続しますか？\n" +
									"　※このメッセージを非表示にするには、\n" +
									"　　エントリーオプションの「保険金額入力チェック」項目を\n" +
									"　　『チェックしない』にしてください。";
						DialogResult ret保険料 = MessageBox.Show(s保険料チェックMsg, "保険金額入力チェック", MessageBoxButtons.YesNo);
						if(ret保険料 == DialogResult.No)
						{
							//［いいえ］ボタンクリック時　→　処理を中断
							//※［はい］ボタンクリック時　→　何もしない
							nUD保険金額.Focus();
							return;
						}
					}
				}
			}
// MOD 2016.06.10 BEVAS）松本 保険料入力チェック機能の追加 END

			//郵便番号存在チェック
			string s郵便番号 = tex届け先郵便番号１.Text + tex届け先郵便番号２.Text;
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sRet = {""};
			try
			{
// MOD 2015.05.07 BEVAS）前田 王子運送郵便番号存在チェック対応 START
				//if(sv_address == null) sv_address = new is2address.Service1();
				//sRet = sv_address.Get_byPostcode2(gsaユーザ,s郵便番号);
				sRet = ＣＭ１４郵便番号存在チェック(s郵便番号);
// MOD 2015.05.07 BEVAS）前田 王子運送郵便番号存在チェック対応 END
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				sRet[0] = gs通信エラー;
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				sRet[0] = "通信エラー：" + ex.Message;
			}
			Cursor = System.Windows.Forms.Cursors.Default;

			if(sRet[0].Length != 4)
			{
				if(sRet[0].Equals("該当データがありません"))
					sRet[0] = "郵便番号が存在しません";
				texメッセージ.Text = sRet[0];
				ビープ音();
				tex届け先郵便番号１.Focus();
				return;
			}

// DEL 2009.03.02 東都）高木 重量０入力時の不具合調整 START
//// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 START
//			//依頼主情報の検索
//			s依頼主ＣＤ = tex依頼主コード.Text;
//			依頼主項目クリア();
//			tex依頼主コード.Text = s依頼主ＣＤ;
//			依頼主検索();
//			//依頼主もしくは請求先が存在しない場合
//			if(tex依頼主請求先.Text.Trim().Length == 0){
//				return;
//			}
//// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 END
// DEL 2009.03.02 東都）高木 重量０入力時の不具合調整 END


// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
			if(gs重量入力制御 == "1"){
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
// ADD 2005.05.17 東都）小童谷 才数か重量か START
				if(i才数ＦＧ == 0)
				{
					s重量 = "0";
					s才数 = nUD重量.Value.ToString();
				}
				else
				{
					s重量 = nUD重量.Value.ToString();
					s才数 = "0";
				}
// ADD 2005.05.17 東都）小童谷 才数か重量か END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
			}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END

// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 START
			if(tex届け先住所１.Text.Equals("※※支店止め※※"))
			{
				/** 支店止めの出荷雛型を手入力でしようとした時の考慮 */

				// 届け先住所３の入力チェック
				if(tex届け先住所３.Text.Trim().Equals(""))
				{
					// 届け先住所３に何も入力されていない
					texメッセージ.Text = "支店止めは、支店止めボタンによる入力でお願い致します。";
					ビープ音();
					tex届け先住所１.Focus();
					Cursor = System.Windows.Forms.Cursors.Default;
					return;
				}

				// ＣＭ１０存在チェック
				string[] sChkList = new string[2];
				try
				{
					if(sv_syukka == null)
					{
						sv_syukka = new is2syukka.Service1();
					}
					sChkList = sv_syukka.CheckCM10_GeneralDelivery(gsaユーザ, tex届け先住所３.Text, s郵便番号);

					if(sChkList[0].Length == 4)
					{
						// 正常終了時
						tex届け先住所２.Text = sChkList[1] + "止め";
					}
					else
					{
						// 異常終了時
						texメッセージ.Text = "支店止めは、支店止めボタンによる入力でお願い致します。";
						ビープ音();
						tex届け先住所１.Focus();
						Cursor = System.Windows.Forms.Cursors.Default;
						return;
					}
				}
				catch (System.Net.WebException)
				{
					sChkList[0] = gs通信エラー;
					Cursor = System.Windows.Forms.Cursors.Default;
					texメッセージ.Text = sChkList[0];
					tex届け先住所１.Focus();
					ビープ音();
					return;
				}
				catch (Exception ex)
				{
					sChkList[0] = "通信エラー：" + ex.Message;
					Cursor = System.Windows.Forms.Cursors.Default;
					texメッセージ.Text = sChkList[0];
					tex届け先住所１.Focus();
					ビープ音();
					return;
				}
			}
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 END

			string[] s出荷Ｄ = {
				gs会員ＣＤ,
				gs部門ＣＤ,
				nUD登録番号.Value.ToString(),
				s更新年月日,
				tex雛型名.Text.Trim(),
				sファイル名,
				tex届け先コード.Text.Trim(),
				tex届け先電話番号１.Text.Trim(),
				tex届け先電話番号２.Text.Trim(),
				tex届け先電話番号３.Text.Trim(),
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//				tex届け先住所１.Text.Trim(),
//				tex届け先住所２.Text.Trim(),
//				tex届け先住所３.Text.Trim(),
//				tex届け先名前１.Text.Trim(),
//				tex届け先名前２.Text.Trim(),
				tex届け先住所１.Text.TrimEnd(),
				tex届け先住所２.Text.TrimEnd(),
				tex届け先住所３.Text.TrimEnd(),
				tex届け先名前１.Text.TrimEnd(),
				tex届け先名前２.Text.TrimEnd(),
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
				tex届け先郵便番号１.Text.Trim(),
				tex届け先郵便番号２.Text.Trim(),
				tex依頼主コード.Text.Trim(),
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//				tex依頼主部署.Text.Trim(),
				tex依頼主部署.Text.TrimEnd(),
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
				nUD個数.Value.ToString(),
// MOD 2011.04.13 東都）高木 重量入力不可対応 START
//// MOD 2005.05.17 東都）小童谷 才数追加 START
////				nUD重量.Value.ToString(),
//				s重量.Trim(),
//// MOD 2005.05.17 東都）小童谷 才数追加 START
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
//				"0",
				(gs重量入力制御 == "1") ? s重量.Trim() : "0",
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
// MOD 2011.04.13 東都）高木 重量入力不可対応 END
				tex輸送名親.Text.TrimEnd(),
				tex輸送名子.Text.TrimEnd(),
				tex記事名１.Text.TrimEnd(),
				tex記事名２.Text.TrimEnd(),
				tex記事名３.Text.TrimEnd(),
				nUD保険金額.Value.ToString(),
				"雛型登録",
				gs利用者ＣＤ,
// MOD 2011.04.13 東都）高木 重量入力不可対応 START
//// ADD 2005.05.17 東都）小童谷 才数追加 START
//				s才数.Trim()
//// ADD 2005.05.17 東都）小童谷 才数追加 START
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
//				"0"
				(gs重量入力制御 == "1") ? s才数.Trim() : "0"
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
// MOD 2011.04.13 東都）高木 重量入力不可対応 END
// ADD 2005.05.30 東都）伊賀 輸送商品コード追加 START
				,s輸送商品親コード,s輸送商品子コード
// ADD 2005.05.30 東都）伊賀 輸送商品コード追加 START
// MOD 2011.07.14 東都）高木 記事行の追加 START
				,tex記事名４.Text.TrimEnd()
				,tex記事名５.Text.TrimEnd()
				,tex記事名６.Text.TrimEnd()
// MOD 2011.07.14 東都）高木 記事行の追加 END
			};

			for(int iCnt = 0 ; iCnt < s出荷Ｄ.Length; iCnt++ )
			{
				if( s出荷Ｄ[iCnt] == null 
					|| s出荷Ｄ[iCnt].Length == 0 ) s出荷Ｄ[iCnt] = " ";
			}

			string[] sIUList = new string[5];
			DialogResult result;
			if(!b更新ＦＧ)
			{
//				result = MessageBox.Show("新規登録しますか？","登録",MessageBoxButtons.YesNo);
//				if(result == DialogResult.Yes)
//				{
					// カーソルを砂時計にする
					Cursor = System.Windows.Forms.Cursors.AppStarting;
					try
					{
						texメッセージ.Text = "登録中．．．";
						if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
						sIUList = sv_hinagata.Ins_hinagata(gsaユーザ,s出荷Ｄ);
					}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
					catch (System.Net.WebException)
					{
						sIUList[0] = gs通信エラー;
					}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
					catch (Exception ex)
					{
						sIUList[0] = "通信エラー：" + ex.Message;
					}
					// カーソルをデフォルトに戻す
					Cursor = System.Windows.Forms.Cursors.Default;

					// 異常終了時
					if(sIUList[0] == "0")
					{
						texメッセージ.Text = "";
						MessageBox.Show("入力されたご依頼主コードはマスタに存在しません",
										"登録",MessageBoxButtons.OK);
						tex依頼主コード.Focus();
						return;
					}
					if(sIUList[0] == "1")
					{
						texメッセージ.Text = "";
						MessageBox.Show("同一のコードが既に登録されています",
										"登録",MessageBoxButtons.OK);
						nUD登録番号.Focus();
						return;
					}

					texメッセージ.Text = sIUList[0];
					if(sIUList[0].Length == 4)
					{
						i雛型ＮＯ       = 0;
						s登録日         = "";
						sジャーナルＮＯ = "";
						btn取消_Click(sender,e);
					}
					else
					{
						ビープ音();
						return;
					}

					// 正常終了時
//					Close();
//				}

			}
			else
			{
				result = MessageBox.Show("既に存在するデータに上書きしますか？","更新",MessageBoxButtons.YesNo);
				if(result == DialogResult.Yes)
				{
					// カーソルを砂時計にする
					Cursor = System.Windows.Forms.Cursors.AppStarting;
					try
					{
						texメッセージ.Text = "更新中．．．";
						if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
						sIUList = sv_hinagata.Upd_hinagata(gsaユーザ,s出荷Ｄ);
					}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
					catch (System.Net.WebException)
					{
						sIUList[0] = gs通信エラー;
					}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
					catch (Exception ex)
					{
						sIUList[0] = "通信エラー：" + ex.Message;
					}
					// カーソルをデフォルトに戻す
					Cursor = System.Windows.Forms.Cursors.Default;

					// エラー時
					if(sIUList[0] == "0")
					{
						tex依頼主コード.Focus();
						texメッセージ.Text = "";
						MessageBox.Show("入力されたご依頼主コードはマスタに存在しません",
										"更新",MessageBoxButtons.OK);
						return;
					}

					texメッセージ.Text = sIUList[0];
					if(sIUList[0].Length != 4)
					{
						ビープ音();
						return;
					}

					// 正常終了時
					Close();
				}
			}

		}

		private void 出荷検索()
		{
			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sList = {""};
			try
			{
				texメッセージ.Text = "検索中．．．";
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
				sList = sv_syukka.Get_Ssyukka(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,s登録日,int.Parse(sジャーナルＮＯ));
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				sList[0] = gs通信エラー;
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				sList[0] = "通信エラー：" + ex.Message;
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;

// MOD 2009.09.09 東都）高木 画面表示不具合の調整 
//			texメッセージ.Text = sList[0];
			if(sList[0].Length == 4) texメッセージ.Text = "";

			// 異常終了時
// MOD 2005.05.13 東都）小童谷 依頼主重量追加 START
//			if(sList[0].Length != 4 || sList[38] == "I")
//			if(sList[0].Length != 4 || sList[39] == "I")
// MOD 2005.05.13 東都）小童谷 依頼主重量追加 END
// MOD 2005.05.30 東都）伊賀 輸送商品コード追加 START
// MOD 2005.05.17 東都）小童谷 才数追加 START
//			if(sList[0].Length != 4 || sList[39] == "I")
//			if(sList[0].Length != 4 || sList[41] == "I")
// MOD 2009.02.06 東都）高木 指定日区分追加 START
//			if(sList[0].Length != 4 || sList[44] == "I")
			if(sList[0].Length != 4 || sList[45] == "I")
// MOD 2009.02.06 東都）高木 指定日区分追加 END
// MOD 2005.05.17 東都）小童谷 才数追加 END
// MOD 2005.05.30 東都）伊賀 輸送商品コード追加 END
			{
// MOD 2009.02.06 東都）高木 エントリオプションの項目追加 START
//				ビープ音();
//
//				Close();
				texメッセージ.Text = sList[0];
				ビープ音();
				tex依頼主コード.Focus();
// MOD 2009.09.04 東都）高木 Vista対応(TAB対応もれ) END
//				if(tex依頼主コード.TabStop == false)
//					System.Windows.Forms.SendKeys.SendWait("{TAB}");
				if(tex依頼主コード.TabStop == false){
// MOD 2011.08.02 東都）高木 各項目の入力不可対応（不具合調整） START
//					this.SelectNextControl(this.ActiveControl, true, true, true, true);
					this.SelectNextControl(tex依頼主コード, true, true, true, true);
// MOD 2011.08.02 東都）高木 各項目の入力不可対応（不具合調整） END
				}
// MOD 2009.09.04 東都）高木 Vista対応(TAB対応もれ) END
				return;
// MOD 2009.02.06 東都）高木 エントリオプションの項目追加 END
			}

//			texお客様管理番号.Text    = sList[2];
			tex届け先コード.Text      = sList[3];
			tex届け先電話番号１.Text  = sList[4];
			tex届け先電話番号２.Text  = sList[5];
			tex届け先電話番号３.Text  = sList[6];
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//			tex届け先住所１.Text      = sList[7];
//			tex届け先住所２.Text      = sList[8];
//			tex届け先住所３.Text      = sList[9];
//			tex届け先名前１.Text      = sList[10];
//			tex届け先名前２.Text      = sList[11];
			if(gsオプション[18].Equals("1")){
				tex届け先住所１.Text  = sList[7].TrimEnd();
				tex届け先住所２.Text  = sList[8].TrimEnd();
				tex届け先住所３.Text  = sList[9].TrimEnd();
				tex届け先名前１.Text  = sList[10].TrimEnd();
				tex届け先名前２.Text  = sList[11].TrimEnd();
			}else{
				tex届け先住所１.Text  = sList[7].Trim();
				tex届け先住所２.Text  = sList[8].Trim();
				tex届け先住所３.Text  = sList[9].Trim();
				tex届け先名前１.Text  = sList[10].Trim();
				tex届け先名前２.Text  = sList[11].Trim();
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
			tex届け先郵便番号１.Text  = sList[12];
			tex届け先郵便番号２.Text  = sList[13];
			tex依頼主コード.Text      = sList[14];
//			tex依頼主請求先.Text      = sList[15];
// ADD 2005.05.30 東都）伊賀 輸送商品コード追加 START
			s輸送商品親コード         = sList[41];
			s輸送商品子コード         = sList[42];
			輸送商品個数重量制御();
// ADD 2005.05.30 東都）伊賀 輸送商品コード追加 END
			nUD個数.Value             = decimal.Parse(sList[16]);
// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 START
//// MOD 2005.05.17 東都）小童谷 才数追加 START
////			nUD重量.Value             = decimal.Parse(sList[17]);
//			if(i才数ＦＧ == 0)
//				nUD重量.Value             = decimal.Parse(sList[39]);
//			else
//				nUD重量.Value             = decimal.Parse(sList[17]);
//// MOD 2005.05.17 東都）小童谷 才数追加 END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
			if(gs重量入力制御 == "1"){
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
				if(i才数ＦＧ == 0){
					nUD重量.Value             = decimal.Parse(sList[39]);
					if(decimal.Parse(sList[17]) > 0){
						texメッセージ.Text = "ワーニング：重量(kg)が入力されているにもかかわらず、\r\n"
											+ "エントリーオプションで才数が選択されています";
						ビープ音();
//					MessageBox.Show("重量(kg)が入力されているにもかかわらず、\n"
//									+ "エントリーオプションで才数が選択されています"
//									,"エントリーオプション設定ワーニング"
//									,MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}else{
					nUD重量.Value             = decimal.Parse(sList[17]);
					if(decimal.Parse(sList[39]) > 0){
						texメッセージ.Text = "ワーニング：才数が入力されているにもかかわらず、\r\n"
											+ "エントリーオプションで重量(kg)が選択されています";
						ビープ音();
//					MessageBox.Show("才数が入力されているにもかかわらず、\n"
//									+ "エントリーオプションで重量(kg)が選択されています"
//									,"エントリーオプション設定ワーニング"
//									,MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
			}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END

			tex輸送名親.Text          = sList[19];
			tex輸送名子.Text          = sList[20];
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//			tex記事名１.Text          = sList[21];
//			tex記事名２.Text          = sList[22];
//			tex記事名３.Text          = sList[23];
			if(gsオプション[18].Equals("1")){
				tex記事名１.Text      = sList[21].TrimEnd();
				tex記事名２.Text      = sList[22].TrimEnd();
				tex記事名３.Text      = sList[23].TrimEnd();
// MOD 2011.07.14 東都）高木 記事行の追加 START
				if(sList.Length > 53){
					tex記事名４.Text  = sList[53].TrimEnd();
					tex記事名５.Text  = sList[54].TrimEnd();
					tex記事名６.Text  = sList[55].TrimEnd();
				}
// MOD 2011.07.14 東都）高木 記事行の追加 END
			}else{
				tex記事名１.Text      = sList[21].Trim();
				tex記事名２.Text      = sList[22].Trim();
				tex記事名３.Text      = sList[23].Trim();
// MOD 2011.07.14 東都）高木 記事行の追加 START
				if(sList.Length > 53){
					tex記事名４.Text  = sList[53].Trim();
					tex記事名５.Text  = sList[54].Trim();
					tex記事名６.Text  = sList[55].Trim();
				}
// MOD 2011.07.14 東都）高木 記事行の追加 END
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 START
//			nUD保険金額.Value         = decimal.Parse(sList[24]);
			decimal d保険金額         = decimal.Parse(sList[24]);
			if(d保険金額 < 0){
				nUD保険金額.Minimum   = d保険金額;
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) START
//			}else if(d保険金額 > 30){
			}else if(d保険金額 > gl保険金額上限){
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) END
				nUD保険金額.Maximum   = d保険金額;
			}
			nUD保険金額.Value         = d保険金額;
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 END
			tex依頼主電話番号１.Text  = sList[26];
			tex依頼主電話番号２.Text  = sList[27];
			tex依頼主電話番号３.Text  = sList[28];
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//			tex依頼主住所１.Text      = sList[29];
//			tex依頼主住所２.Text      = sList[30];
//			tex依頼主名前１.Text      = sList[31];
//			tex依頼主名前２.Text      = sList[32];
			if(gsオプション[18].Equals("1")){
				tex依頼主住所１.Text  = sList[29].TrimEnd();
				tex依頼主住所２.Text  = sList[30].TrimEnd();
				tex依頼主名前１.Text  = sList[31].TrimEnd();
				tex依頼主名前２.Text  = sList[32].TrimEnd();
			}else{
				tex依頼主住所１.Text  = sList[29].Trim();
				tex依頼主住所２.Text  = sList[30].Trim();
				tex依頼主名前１.Text  = sList[31].Trim();
				tex依頼主名前２.Text  = sList[32].Trim();
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
			tex依頼主郵便番号１.Text  = sList[33];
			tex依頼主郵便番号２.Text  = sList[34];
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 START
			tex請求先コード.Text      = sList[35];
			tex請求先部課コード.Text  = sList[36];
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 END
			if(sList[35] != " ")
			{
				int iCnt;
				if(gsa請求先ＣＤ != null)
				{
					for(iCnt = 0 ; iCnt < gsa請求先ＣＤ.Length; iCnt++ )
					{
						if(gsa請求先ＣＤ[iCnt] == null || gsa請求先部課ＣＤ[iCnt] == null)
						{
							tex依頼主請求先.Text = "";
						}
						else
						{
							if(gsa請求先ＣＤ[iCnt] == sList[35] && gsa請求先部課ＣＤ[iCnt] == sList[36])
							{
								tex依頼主請求先.Text = gsa請求先部課名[iCnt];
								break;
							}
						}
					}
				}
			}
// MOD 2009.09.09 東都）高木 画面表示不具合の調整 
//			texメッセージ.Text = "";
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//			tex依頼主部署.Text = sList[37];
			if(gsオプション[18].Equals("1")){
				tex依頼主部署.Text = sList[37].TrimEnd();
			}else{
				tex依頼主部署.Text = sList[37].Trim();
			}
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 START
			// 現行の請求先情報を表示
			tex請求先コード.Text     = sList[47];
			tex請求先部課コード.Text = sList[48];
			tex依頼主請求先.Text     = sList[15];
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 END

// MOD 2009.09.09 東都）高木 画面表示不具合の調整 
			// 届け先コードにフォーカス
			s依頼主ＣＤ         = tex依頼主コード.Text;
			s前回検索依頼主ＣＤ = tex依頼主コード.Text;

// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 STRAT
//// ADD 2005.05.12 東都）小童谷 依頼主重量 START
//// MOD 2005.05.17 東都）小童谷 才数追加 START
////			d重量 = decimal.Parse(sList[38]);
//			if(i才数ＦＧ == 0)
//				d重量 = decimal.Parse(sList[40]);
//			else
//				d重量 = decimal.Parse(sList[38]);
//// MOD 2005.05.17 東都）小童谷 才数追加 END
//// ADD 2005.05.12 東都）小童谷 依頼主重量 END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
			if(gs重量入力制御 == "1"){
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
				if(i才数ＦＧ == 0){ 
				// 才数の時
					d重量 = decimal.Parse(sList[40]);
					if(d重量 == 0){
						// 重量÷８
						d重量 = decimal.Parse(sList[38]) / 8;
// MOD 2011.03.11 東都）高木 才数計算の補正 START
						d重量 = decimal.Truncate(d重量 + decimal.Parse("0.9"));
// MOD 2011.03.11 東都）高木 才数計算の補正 END
					}
				}else{
				// 重量の時
					d重量 = decimal.Parse(sList[38]);
					if(d重量 == 0){
						// 才数×８
						d重量 = decimal.Parse(sList[40]) * 8;
					}
				}
// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
			}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END

		}

// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 START
		private void 輸送商品子チェック(string sCode)
		{
			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sList = {""};
			try
			{
				if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
// MOD 2011.06.07 東都）高木 王子運送の対応 START
				if (gs会員ＣＤ.Substring(0,1) != "J"){
// MOD 2011.06.07 東都）高木 王子運送の対応 END
					sList = sv_kiji.Get_kiji(gsaユーザ,"yusoshohin",sCode);
// MOD 2011.06.07 東都）高木 王子運送の対応 START
				}else{
					sList = sv_kiji.Get_kiji(gsaユーザ,"Jyusoshohin",sCode);
				}
// MOD 2011.06.07 東都）高木 王子運送の対応 END
			}
			catch (System.Net.WebException)
			{
				sList[0] = gs通信エラー;
			}
			catch (Exception ex)
			{
				sList[0] = "通信エラー：" + ex.Message;
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;

			// エラー時
			if(!sList[0].Equals("正常終了") && !sList[0].Equals("該当データがありません"))
			{
				ビープ音();
				texメッセージ.Text = sList[0];
				tex輸送コード子.Focus();
				return;
			}

			if(sList.Length == 1)
			{
				tex輸送コード子.Text = " ";
				tex輸送名子.Text = "";
				s輸送商品子コード = " ";
				texメッセージ.Text = "";
				tex記事コード.Focus();
			}
			else if(sList.Length == 2)
			{
				string[] s記事 = sList[1].Split('|');
				if (s記事.Length > 2)
				{
					tex輸送コード子.Text = s記事[1];
					tex輸送名子.Text = s記事[2];
					s輸送商品子コード = s記事[1];
				}
				texメッセージ.Text = "";
				tex記事コード.Focus();
			}
		}
// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 END

// MOD 2005.05.26 東都）伊賀 輸送商品仕様変更 START
		private void tex輸送コード親_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				// メッセージのクリア
				texメッセージ.Text = "";

// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 START
				// 空白除去
				tex輸送コード親.Text = tex輸送コード親.Text.Trim();
//				if((tex輸送コード親.Text.Length > 0)
//					&& (tex輸送名親.Text.Trim().Length == 0
//					||  tex輸送名子.Text.Trim().Length == 0))
				if(tex輸送コード親.Text.Length > 0)
				{
//					if(!必須チェック(tex輸送コード親,"輸送商品親コード")) return;
					if(!半角チェック(tex輸送コード親,"輸送商品親コード")) return;

					// カーソルを砂時計にする
					Cursor = System.Windows.Forms.Cursors.AppStarting;
					string[] sList = {""};
					try
					{
						texメッセージ.Text = "検索中．．．";
						if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
//						sList = sv_kiji.Get_Skiji(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,tex輸送コード親.Text);
// MOD 2011.06.07 東都）高木 王子運送の対応 START
						if (gs会員ＣＤ.Substring(0,1) != "J"){
// MOD 2011.06.07 東都）高木 王子運送の対応 END
							// 会員コード:"yusoshohin" 部門コード:"0000"で検索
							sList = sv_kiji.Get_Skiji(gsaユーザ,"yusoshohin", "0000", tex輸送コード親.Text);
// MOD 2011.06.07 東都）高木 王子運送の対応 START
						}else{
							sList = sv_kiji.Get_Skiji(gsaユーザ,"Jyusoshohin", "0000", tex輸送コード親.Text);
						}
// MOD 2011.06.07 東都）高木 王子運送の対応 END
					}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
					catch (System.Net.WebException)
					{
						sList[0] = gs通信エラー;
					}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
					catch (Exception ex)
					{
						sList[0] = "通信エラー：" + ex.Message;
					}
					// カーソルをデフォルトに戻す
					Cursor = System.Windows.Forms.Cursors.Default;

					// エラー時
					if(sList[0].Length != 2)
					{
						ビープ音();
						texメッセージ.Text = sList[0];
						tex輸送コード親.Focus();
						return;
					}

					// 存在しない時
					if(sList[3] == "I")
					{
//						ビープ音();
//						texメッセージ.Text = "入力された輸送コードはマスタに存在しません。";
						texメッセージ.Text = "";
//						MessageBox.Show("入力された輸送コードはマスタに存在しません。","輸送検索",MessageBoxButtons.OK);
						MessageBox.Show("入力された輸送商品親コードはマスタに存在しません。","輸送検索",MessageBoxButtons.OK);
						tex輸送コード親.Focus();
						return;
					}

					// 空白除去
//					tex輸送名親.Text = tex輸送名親.Text.Trim();
//					tex輸送名子.Text = tex輸送名子.Text.Trim();
					if(sList[1] != null)
					{
//						if(tex輸送名親.Text.Length == 0){
//							tex輸送名親.Text = sList[1];
//							tex輸送コード親.Text = "";
//						}else if(tex輸送名子.Text .Length == 0){
//							tex輸送名子.Text = sList[1];
//							tex輸送コード親.Text = "";
//						}
						tex輸送名親.Text = sList[1];
						if (!tex輸送コード親.Text.Equals(s輸送商品親コード))
						{
							tex輸送コード子.Text = " ";
							tex輸送名子.Text = "";
							s輸送商品子コード = "";
						}
						s輸送商品親コード = tex輸送コード親.Text;

						texメッセージ.Text = "";
						tex輸送コード子.Focus();
					}
					輸送商品個数重量制御();
					輸送商品子チェック(s輸送商品親コード);
				}
			}
			else if (e.KeyCode == Keys.Delete)
			{
				tex輸送コード親.Text = " ";
				tex輸送名親.Text = "";
				tex輸送コード子.Text = " ";
				tex輸送名子.Text = "";
				s輸送商品親コード = "";
				s輸送商品子コード = "";
				tex輸送コード親.Focus();
			}
		}

		private void tex輸送コード子_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				// メッセージのクリア
				texメッセージ.Text = "";

				// 空白除去
				tex輸送コード子.Text = tex輸送コード子.Text.Trim();
				if(tex輸送コード子.Text.Length > 0)
				{
					if(s輸送商品親コード.Length == 0)
					{
						MessageBox.Show("輸送商品親コードが入力されていません。","入力チェック",MessageBoxButtons.OK);
						return;
					}
					if(!半角チェック(tex輸送コード子,"輸送商品子コード")) return;

					// カーソルを砂時計にする
					Cursor = System.Windows.Forms.Cursors.AppStarting;
					string[] sList = {""};
					try
					{
						texメッセージ.Text = "検索中．．．";
						if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
// MOD 2011.06.07 東都）高木 王子運送の対応 START
						if (gs会員ＣＤ.Substring(0,1) != "J"){
// MOD 2011.06.07 東都）高木 王子運送の対応 END
							sList = sv_kiji.Get_Skiji(gsaユーザ,"yusoshohin",s輸送商品親コード,tex輸送コード子.Text);
// MOD 2011.06.07 東都）高木 王子運送の対応 START
						}else{
							sList = sv_kiji.Get_Skiji(gsaユーザ,"Jyusoshohin",s輸送商品親コード,tex輸送コード子.Text);
						}
// MOD 2011.06.07 東都）高木 王子運送の対応 END
					}
					catch (System.Net.WebException)
					{
						sList[0] = gs通信エラー;
					}
					catch (Exception ex)
					{
						sList[0] = "通信エラー：" + ex.Message;
					}
					// カーソルをデフォルトに戻す
					Cursor = System.Windows.Forms.Cursors.Default;

					// エラー時
					if(sList[0].Length != 2)
					{
						ビープ音();
						texメッセージ.Text = sList[0];
						tex輸送コード子.Focus();
						return;
					}

					// 存在しない時
					if(sList[3] == "I")
					{
						texメッセージ.Text = "";
						MessageBox.Show("入力された輸送商品子コードはマスタに存在しません。","輸送検索",MessageBoxButtons.OK);
						tex輸送コード子.Focus();
						return;
					}

					if(sList[1] != null)
					{
// MOD 2005.06.17 東都）小童谷 指定時間入力追加 START
//						tex輸送名子.Text = sList[1];
//						s輸送商品子コード = tex輸送コード子.Text;
//						texメッセージ.Text = "";
//						tex記事コード.Focus();
						texメッセージ.Text = "";
						if (tex輸送コード子.Text.Length > 2 && tex輸送コード子.Text.Substring(1).Equals("1X"))
						{
							if (g指定時間入力 == null) g指定時間入力 = new 指定時間入力();
							g指定時間入力.Left  = this.Left + (this.Width  - g指定時間入力.Width)  / 2;
							g指定時間入力.Top   = this.Top  + (this.Height - g指定時間入力.Height) / 2;
							g指定時間入力.s記事 = "";
							g指定時間入力.lab時間区分.Text = "時まで";
// MOD 2010.05.25 東都）高木 時間指定の変更 START
//							string[] items = {"１２","１３","１４","１５","１６","１７","１８","１９","２０","２１"};
							string[] items = {"１２","１３","１４","１５","１６","１７","１８","１９","２０"};
// MOD 2010.05.25 東都）高木 時間指定の変更 END
							g指定時間入力.cmb指定時間.Items.Clear();
							g指定時間入力.cmb指定時間.Items.AddRange(items);
							g指定時間入力.cmb指定時間.SelectedIndex = 0;
							g指定時間入力.ShowDialog(this);
							if (g指定時間入力.s記事.Length != 0)
							{
								tex輸送名子.Text = g指定時間入力.s記事;
								tex記事コード.Focus();
							}
							else
							{
								tex輸送コード子.Focus();
							}
						}
						else if (tex輸送コード子.Text.Length > 2 && tex輸送コード子.Text.Substring(1).Equals("2X"))
						{
							if (g指定時間入力 == null) g指定時間入力 = new 指定時間入力();
							g指定時間入力.Left  = this.Left + (this.Width  - g指定時間入力.Width)  / 2;
							g指定時間入力.Top   = this.Top  + (this.Height - g指定時間入力.Height) / 2;
							g指定時間入力.s記事 = "";
							g指定時間入力.lab時間区分.Text = "時以降";
// MOD 2010.05.25 東都）高木 時間指定の変更 START
//							string[] items = {"１０","１１","１２","１３","１４","１５","１６","１７","１８","１９"};
							string[] items = {"１０","１１","１２","１３","１４","１５","１６","１７","１８"};
// MOD 2010.05.25 東都）高木 時間指定の変更 END
							g指定時間入力.cmb指定時間.Items.Clear();
							g指定時間入力.cmb指定時間.Items.AddRange(items);
							g指定時間入力.cmb指定時間.SelectedIndex = 0;
							g指定時間入力.ShowDialog(this);
							if (g指定時間入力.s記事.Length != 0)
							{
								tex輸送名子.Text = g指定時間入力.s記事;
								tex記事コード.Focus();
							}
							else
							{
								tex輸送コード子.Focus();
							}
						}
						else
						{
							tex輸送名子.Text = sList[1];
							tex記事コード.Focus();
						}
						s輸送商品子コード = tex輸送コード子.Text;
// MOD 2005.06.17 東都）小童谷 指定時間入力追加 END
					}
				}
				else if (s輸送商品親コード.Length != 0 && tex輸送名子.Text.TrimEnd().Length == 0)
				{
					string[] sList = {""};
					try
					{
						if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
// MOD 2011.06.07 東都）高木 王子運送の対応 START
						if (gs会員ＣＤ.Substring(0,1) != "J"){
// MOD 2011.06.07 東都）高木 王子運送の対応 END
							sList = sv_kiji.Get_kiji(gsaユーザ,"yusoshohin",s輸送商品親コード);
// MOD 2011.06.07 東都）高木 王子運送の対応 START
						}else{
							sList = sv_kiji.Get_kiji(gsaユーザ,"Jyusoshohin",s輸送商品親コード);
						}
// MOD 2011.06.07 東都）高木 王子運送の対応 END
					}
					catch (System.Net.WebException)
					{
						sList[0] = gs通信エラー;
					}
					catch (Exception ex)
					{
						sList[0] = "通信エラー：" + ex.Message;
					}
					// カーソルをデフォルトに戻す
					Cursor = System.Windows.Forms.Cursors.Default;

					// エラー時
					if(!sList[0].Equals("正常終了") && !sList[0].Equals("該当データがありません"))
					{
						ビープ音();
						texメッセージ.Text = sList[0];
						tex輸送コード子.Focus();
						return;
					}

					if(sList.Length > 1)
					{
						if (g記事検索 == null)	 g記事検索 = new 記事検索();
						g記事検索.Left  = this.Left;
						g記事検索.Top   = this.Top;
						g記事検索.b輸送指示 = true;
						g記事検索.lab記事タイトル.Text = "輸送商品検索";
						//輸送商品子検索
						g記事検索.s輸送商品部門 = s輸送商品親コード;

						g記事検索.ShowDialog();
						if (g記事検索.sKcode.Length != 0)
						{
							//輸送商品子検索
							tex輸送コード子.Text = g記事検索.sKcode;
							tex輸送名子.Text = g記事検索.s記事;
							s輸送商品子コード = g記事検索.sKcode;
							tex記事コード.Focus();
						}
					}
				}
			}
			else if (e.KeyCode == Keys.Delete)
			{
				tex輸送コード親.Text = " ";
				tex輸送名親.Text = "";
				tex輸送コード子.Text = " ";
				tex輸送名子.Text = "";
				s輸送商品親コード = "";
				s輸送商品子コード = "";
				tex輸送コード親.Focus();
			}		
		}
// MOD 2005.05.26 東都）伊賀 輸送商品仕様変更 END

		private void tex記事コード_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				// メッセージのクリア
				texメッセージ.Text = "";

				// 空白除去
				tex記事コード.Text = tex記事コード.Text.Trim();
				if((tex記事コード.Text.Length > 0)
					&& (tex記事名１.Text.Trim().Length == 0
					||  tex記事名２.Text.Trim().Length == 0
// MOD 2011.07.14 東都）高木 記事行の追加 START
//					||  tex記事名３.Text.Trim().Length == 0))
					||  tex記事名３.Text.Trim().Length == 0
					||  tex記事名４.Text.Trim().Length == 0
					||  tex記事名５.Text.Trim().Length == 0
					||  tex記事名６.Text.Trim().Length == 0
					))
// MOD 2011.07.14 東都）高木 記事行の追加 END
				{

					if(!必須チェック(tex記事コード,"記事コード")) return;
					if(!半角チェック(tex記事コード,"記事コード")) return;

					// カーソルを砂時計にする
					Cursor = System.Windows.Forms.Cursors.AppStarting;
					string[] sList = {""};
					try
					{
						texメッセージ.Text = "検索中．．．";
						if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
						sList = sv_kiji.Get_Skiji(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,tex記事コード.Text);
					}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
					catch (System.Net.WebException)
					{
						sList[0] = gs通信エラー;
					}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
					catch (Exception ex)
					{
						sList[0] = "通信エラー：" + ex.Message;
					}
					// カーソルをデフォルトに戻す
					Cursor = System.Windows.Forms.Cursors.Default;

					// エラー時
					if(sList[0].Length != 2){
						ビープ音();
						texメッセージ.Text = sList[0];
						tex記事コード.Focus();
						return;
					}

					// 存在しない時
					if(sList[3] == "I")
					{
//						ビープ音();
//						texメッセージ.Text = "入力された記事コードはマスタに存在しません。";
						texメッセージ.Text = "";
						MessageBox.Show("入力された記事コードはマスタに存在しません。","記事検索",MessageBoxButtons.OK);
						tex記事コード.Focus();
						return;
					}

					// 空白除去
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//					tex記事名１.Text = tex記事名１.Text.Trim();
//					tex記事名２.Text = tex記事名２.Text.Trim();
//					tex記事名３.Text = tex記事名３.Text.Trim();
					if(gsオプション[18].Equals("1")){
						tex記事名１.Text = tex記事名１.Text.TrimEnd();
						tex記事名２.Text = tex記事名２.Text.TrimEnd();
						tex記事名３.Text = tex記事名３.Text.TrimEnd();
// MOD 2011.07.14 東都）高木 記事行の追加 START
						tex記事名４.Text = tex記事名４.Text.TrimEnd();
						tex記事名５.Text = tex記事名５.Text.TrimEnd();
						tex記事名６.Text = tex記事名６.Text.TrimEnd();
// MOD 2011.07.14 東都）高木 記事行の追加 END
					}else{
						tex記事名１.Text = tex記事名１.Text.Trim();
						tex記事名２.Text = tex記事名２.Text.Trim();
						tex記事名３.Text = tex記事名３.Text.Trim();
// MOD 2011.07.14 東都）高木 記事行の追加 START
						tex記事名４.Text = tex記事名４.Text.Trim();
						tex記事名５.Text = tex記事名５.Text.Trim();
						tex記事名６.Text = tex記事名６.Text.Trim();
// MOD 2011.07.14 東都）高木 記事行の追加 END
					}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
					if(sList[1] != null)
					{
// MOD 2011.07.14 東都）高木 記事行の追加 START
//						if(tex記事名１.Text.Length == 0)
//						{
//							tex記事名１.Text = sList[1];
//							tex記事コード.Text = "";
//						}
//						else if(tex記事名２.Text.Length == 0)
//						{
//							tex記事名２.Text = sList[1];
//							tex記事コード.Text = "";
//						}
//						else if(tex記事名３.Text.Length == 0)
//						{
//							tex記事名３.Text = sList[1];
//							tex記事コード.Text = "";
//						}
						if(tex記事名１.Text.Length == 0){
							tex記事名１.Text   = sList[1];
							tex記事コード.Text = "";
						}else if(tex記事名２.Text.Length == 0){
							tex記事名２.Text   = sList[1];
							tex記事コード.Text = "";
						}else if(tex記事名３.Text.Length == 0){
							tex記事名３.Text   = sList[1];
							tex記事コード.Text = "";
// MOD 2011.08.05 東都）高木 記事行の追加（３行・６行切替対応） START
//						}else if(tex記事名４.Text.Length == 0){
//							tex記事名４.Text   = sList[1];
//							tex記事コード.Text = "";
//						}else if(tex記事名５.Text.Length == 0){
//							tex記事名５.Text   = sList[1];
//							tex記事コード.Text = "";
//						}else if(tex記事名６.Text.Length == 0){
//							tex記事名６.Text   = sList[1];
//							tex記事コード.Text = "";
// MOD 2011.09.26 東都）高木 記事行の追加（３行・６行切替対応） START
//						}else if(tex記事名４.Enabled && tex記事名４.Text.Length == 0){
//							tex記事名４.Text   = sList[1];
//							tex記事コード.Text = "";
//						}else if(tex記事名５.Enabled && tex記事名５.Text.Length == 0){
//							tex記事名５.Text   = sList[1];
//							tex記事コード.Text = "";
//						}else if(tex記事名６.Enabled && tex記事名６.Text.Length == 0){
//							tex記事名６.Text   = sList[1];
//							tex記事コード.Text = "";
//// MOD 2011.08.05 東都）高木 記事行の追加（３行・６行切替対応） END
						// [２:３行入力]の時のみ入力不可
						}else if(gsオプション[7] != "2" && tex記事名４.Text.Length == 0){
							tex記事名４.Text   = sList[1];
							tex記事コード.Text = "";
						}else if(gsオプション[7] != "2" && tex記事名５.Text.Length == 0){
							tex記事名５.Text   = sList[1];
							tex記事コード.Text = "";
						}else if(gsオプション[7] != "2" && tex記事名６.Text.Length == 0){
							tex記事名６.Text   = sList[1];
							tex記事コード.Text = "";
// MOD 2011.09.26 東都）高木 記事行の追加（３行・６行切替対応） END
						}
// MOD 2011.07.14 東都）高木 記事行の追加 END
						texメッセージ.Text = "";
						tex記事コード.Focus();
					}
				}

			}
		}

		private void 届け先項目クリア()
		{
//			tex届け先コード.Text = "";
			tex届け先コード.Text = " ";
			tex届け先電話番号１.Text   = "";
			tex届け先電話番号２.Text   = "";
			tex届け先電話番号３.Text   = "";
			tex届け先郵便番号１.Text   = "";
			tex届け先郵便番号２.Text   = "";
			tex届け先住所１.Text       = "";
			tex届け先住所２.Text       = "";
			tex届け先住所３.Text       = "";
			tex届け先名前１.Text       = "";
			tex届け先名前２.Text       = "";
			texメッセージ.Text   = "";
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 START
			// ロックを解除
			tex届け先郵便番号１.Enabled = true; // 郵便番号１
			tex届け先郵便番号２.Enabled = true; // 郵便番号２
			tex届け先住所１.Enabled = true; // 住所１
			tex届け先住所２.Enabled = true; // 住所２
			tex届け先住所３.Enabled = true; // 住所３
			// 支店止めボタンを表示、解除ボタンを非表示
			btn支店止め.Visible = true;
			btn支店止め.Enabled = true;
			btn支店止め解除.Visible = false;
			btn支店止め解除.Enabled = false;
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 END

		}

		private void 依頼主項目クリア()
		{
// MOD 2009.09.09 東都）高木 前回検索依頼主ＣＤのクリアもれ対応 START
			s前回検索依頼主ＣＤ = "";
// MOD 2009.09.09 東都）高木 前回検索依頼主ＣＤのクリアもれ対応 END
			tex依頼主コード.Text = "";
			tex依頼主電話番号１.Text   = "";
			tex依頼主電話番号２.Text   = "";
			tex依頼主電話番号３.Text   = "";
			tex依頼主郵便番号１.Text   = "";
			tex依頼主郵便番号２.Text   = "";
			tex依頼主住所１.Text       = "";
			tex依頼主住所２.Text       = "";
			tex依頼主名前１.Text       = "";
			tex依頼主名前２.Text       = "";
			tex依頼主部署.Text         = "";
			tex依頼主請求先.Text       = "";
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 START
			tex請求先コード.Text       = "";
			tex請求先部課コード.Text   = "";
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 END
			texメッセージ.Text   = "";
		}

// MOD 2009.02.20 東都）高木 請求先コード表示機能の追加 START
		private void 依頼主項目クリア２()
		{
// MOD 2009.09.09 東都）高木 前回検索依頼主ＣＤのクリアもれ対応 START
			s前回検索依頼主ＣＤ = "";
// MOD 2009.09.09 東都）高木 前回検索依頼主ＣＤのクリアもれ対応 END
//			tex依頼主コード.Text = "";
			tex依頼主電話番号１.Text   = "";
			tex依頼主電話番号２.Text   = "";
			tex依頼主電話番号３.Text   = "";
			tex依頼主郵便番号１.Text   = "";
			tex依頼主郵便番号２.Text   = "";
			tex依頼主住所１.Text       = "";
			tex依頼主住所２.Text       = "";
			tex依頼主名前１.Text       = "";
			tex依頼主名前２.Text       = "";
//			tex依頼主部署.Text         = "";
			tex依頼主請求先.Text       = "";
			tex請求先コード.Text       = "";
			tex請求先部課コード.Text   = "";
			texメッセージ.Text   = "";
		}
// MOD 2009.02.20 東都）高木 請求先コード表示機能の追加 END

		private void その他項目クリア()
		{
			tex輸送コード親.Text     = "";
			tex輸送コード子.Text     = "";
			tex輸送名親.Text       = "";
			tex輸送名子.Text       = "";
			tex記事名１.Text     = "";
			tex記事名２.Text     = "";
			tex記事名３.Text     = "";
// MOD 2011.07.14 東都）高木 記事行の追加 START
			tex記事名４.Text     = "";
			tex記事名５.Text     = "";
			tex記事名６.Text     = "";
// MOD 2011.07.14 東都）高木 記事行の追加 END
			nUD個数.Value          = 0;
			nUD重量.Value          = 0;
			nUD保険金額.Value      = 0;
			nUD個数.Text          = "0";
			nUD重量.Text          = "0";
			nUD保険金額.Text      = "0";
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 START
			nUD保険金額.Minimum   =  0;
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) START
//			nUD保険金額.Maximum   = 30;
			nUD保険金額.Maximum   = gl保険金額上限;
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) END
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 END
			btnアイコン.Image = null;
			sファイル名 = "";
// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 START
			s輸送商品親コード      = "";
			s輸送商品子コード      = "";
			輸送商品個数重量制御();
// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 END

		}

		private void 届け先検索(bool b複写)
		{
			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sList = {""};
			try
			{
				texメッセージ.Text = "お届け先検索中．．．";
				if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
				sList = sv_otodoke.Get_Stodokesaki(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,s届け先ＣＤ);
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				sList[0] = gs通信エラー;
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				sList[0] = "通信エラー：" + ex.Message;
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;

			if(sList[0].Length == 2)
			{
				if(sList[15] == "U")
				{
					if(!b複写)
					{
						tex届け先電話番号１.Text = sList[2].Trim();
						tex届け先電話番号２.Text = sList[3].Trim();
						tex届け先電話番号３.Text = sList[4].Trim();
					}
					tex届け先郵便番号１.Text = sList[5].Trim();
					tex届け先郵便番号２.Text = sList[6].Trim();
					tex届け先住所１.Text     = sList[7].Trim();
					tex届け先住所２.Text     = sList[8].Trim();
					tex届け先住所３.Text     = sList[9].Trim();
					tex届け先名前１.Text     = sList[10].Trim();
					tex届け先名前２.Text     = sList[11].Trim();

// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 START
					/** 一旦、項目ロックやボタン表示を初期化 */
					tex届け先郵便番号１.Enabled = true; // 届け先郵便番号１
					tex届け先郵便番号２.Enabled = true; // 届け先郵便番号２
					tex届け先住所１.Enabled = true; // 届け先住所１
					tex届け先住所２.Enabled = true; // 届け先住所２
					tex届け先住所３.Enabled = true; // 届け先住所３
					// 支店止めボタン
					btn支店止め.Visible = true;
					btn支店止め.Enabled = true;
					// 支店止め解除ボタン
					btn支店止め解除.Visible = false;
					btn支店止め解除.Enabled = false;

					if(tex届け先住所１.Text.Equals("※※支店止め※※"))
					{
						// ロック
						tex届け先郵便番号１.Enabled = false; // 届け先郵便番号１
						tex届け先郵便番号２.Enabled = false; // 届け先郵便番号２
						tex届け先住所１.Enabled = false; // 届け先住所１
						tex届け先住所２.Enabled = false; // 届け先住所２
						tex届け先住所３.Enabled = false; // 届け先住所３

						// 支店止めボタンを非表示、解除ボタンを表示
						btn支店止め.Visible = false;
						btn支店止め.Enabled = false;
						btn支店止め解除.Visible = true;
						btn支店止め解除.Enabled = true;
					}
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 END

					texメッセージ.Text = "";
					if(b複写)
						tex届け先住所１.Focus();
					else					
// MOD 2009.02.06 東都）高木　 エントリオプションの項目追加 START
//						tex依頼主コード.Focus();
					{
						tex依頼主コード.Focus();
// MOD 2009.09.04 東都）高木 Vista対応(TAB対応もれ) START
//						if(tex依頼主コード.TabStop == false)
//							System.Windows.Forms.SendKeys.SendWait("{TAB}");
						if(tex依頼主コード.TabStop == false){
// MOD 2011.08.02 東都）高木 各項目の入力不可対応（不具合調整） START
//							this.SelectNextControl(this.ActiveControl, true, true, true, true);
							this.SelectNextControl(tex依頼主コード, true, true, true, true);
// MOD 2011.08.02 東都）高木 各項目の入力不可対応（不具合調整） END
						}
// MOD 2009.09.04 東都）高木 Vista対応(TAB対応もれ) END
					}
// MOD 2009.02.06 東都）高木　 エントリオプションの項目追加 END
				}
				else
				{
//					ビープ音();
//					texメッセージ.Text = "入力されたお届け先コードはマスタに存在しません。";
					texメッセージ.Text = "";
					MessageBox.Show("入力されたお届け先コードはマスタに存在しません。","お届け先検索",MessageBoxButtons.OK);
					tex届け先コード.Focus();
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

		private void 依頼主検索()
		{
			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sList = {""};
			try
			{
				texメッセージ.Text = "ご依頼主検索中．．．";
				if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
				sList = sv_goirai.Get_Sirainusi(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,s依頼主ＣＤ);
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				sList[0] = gs通信エラー;
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				sList[0] = "通信エラー：" + ex.Message;
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;

			if(sList[0].Length == 2)
			{
				if(sList[17] == "U"){
					tex依頼主電話番号１.Text = sList[2];
					tex依頼主電話番号２.Text = sList[3];
					tex依頼主電話番号３.Text = sList[4];
					tex依頼主郵便番号１.Text = sList[5];
					tex依頼主郵便番号２.Text = sList[6];
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//					tex依頼主住所１.Text     = sList[7];
//					tex依頼主住所２.Text     = sList[8];
//					tex依頼主名前１.Text     = sList[9];
//					tex依頼主名前２.Text     = sList[10];
					if(gsオプション[18].Equals("1")){
						tex依頼主住所１.Text = sList[7].TrimEnd();
						tex依頼主住所２.Text = sList[8].TrimEnd();
						tex依頼主名前１.Text = sList[9].TrimEnd();
						tex依頼主名前２.Text = sList[10].TrimEnd();
					}else{
						tex依頼主住所１.Text = sList[7].Trim();
						tex依頼主住所２.Text = sList[8].Trim();
						tex依頼主名前１.Text = sList[9].Trim();
						tex依頼主名前２.Text = sList[10].Trim();
					}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
					s前回検索依頼主ＣＤ      = s依頼主ＣＤ;
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 START
					tex請求先コード.Text     = sList[14];
					tex請求先部課コード.Text = sList[15];
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 END

// DEL 2005.05.12 東都）小童谷 依頼主の重量は表示しない START
//					if(nUD重量.Value == 0)
//						nUD重量.Value = decimal.Parse(sList[12]);
// DEL 2005.05.12 東都）小童谷 依頼主の重量は表示しない END
// MOD 2005.05.17 東都）小童谷 才数か重量か START
//					d重量  =  decimal.Parse(sList[12]);
// MOD 2005.05.12 東都）小童谷 依頼主の重量は表示しない END
// MOD 2005.05.17 東都）小童谷 才数か重量か START
//					d重量  =  decimal.Parse(sList[12]);
// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 STRAT
//					if(i才数ＦＧ == 0)
//						d重量 = decimal.Parse(sList[11]);
//					else
//						d重量 = decimal.Parse(sList[12]);
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
					if(gs重量入力制御 == "1"){
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
						if(i才数ＦＧ == 0){ 
						// 才数の時
							d重量 = decimal.Parse(sList[11]);
							if(d重量 == 0){
								// 重量÷８
								d重量 = decimal.Parse(sList[12]) / 8;
// MOD 2011.03.11 東都）高木 才数計算の補正 START
								d重量 = decimal.Truncate(d重量 + decimal.Parse("0.9"));
// MOD 2011.03.11 東都）高木 才数計算の補正 END
							}
						}else{
						// 重量の時
							d重量 = decimal.Parse(sList[12]);
							if(d重量 == 0){
								// 才数×８
								d重量 = decimal.Parse(sList[11]) * 8;
							}
						}
// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 END
// MOD 2005.05.17 東都）小童谷 才数か重量か END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
					}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END

// MOD 2010.09.27 東都）高木 請求先部課名の追加 START
					if(sList.Length > 18){
						tex依頼主請求先.Text = sList[18];
					}else{
// MOD 2010.09.27 東都）高木 請求先部課名の追加 END
						int iCnt;
						if(gsa請求先ＣＤ != null)
						{
							for(iCnt = 0 ; iCnt < gsa請求先ＣＤ.Length; iCnt++ )
							{
								if(gsa請求先ＣＤ[iCnt] == null || gsa請求先部課ＣＤ[iCnt] == null)
								{
									tex依頼主請求先.Text = "";
								}
								else
								{
									if(gsa請求先ＣＤ[iCnt] == sList[14] && gsa請求先部課ＣＤ[iCnt] == sList[15])
									{
										tex依頼主請求先.Text = gsa請求先部課名[iCnt];
										break;
									}
								}
							}
						}
// MOD 2010.09.27 東都）高木 請求先部課名の追加 START
					}
// MOD 2010.09.27 東都）高木 請求先部課名の追加 END
					texメッセージ.Text = "";
					tex依頼主部署.Focus();
// MOD 2010.10.04 東都）高木 担当者（依頼主部署）フォーカス障害対応 START
					if(tex依頼主部署.TabStop == false){
// MOD 2011.08.02 東都）高木 各項目の入力不可対応（不具合調整） START
//						this.SelectNextControl(this.ActiveControl, true, true, true, true);
						this.SelectNextControl(tex依頼主部署, true, true, true, true);
// MOD 2011.08.02 東都）高木 各項目の入力不可対応（不具合調整） END
					}
// MOD 2010.10.04 東都）高木 担当者（依頼主部署）フォーカス障害対応 END
				}
				else
				{
//					ビープ音();
//					texメッセージ.Text = "入力されたご依頼主コードはマスタに存在しません。";
// MOD 2005.05.31 東都）小童谷 エラーのときはクリア START
//					s前回検索依頼主ＣＤ      = s依頼主ＣＤ;
					s前回検索依頼主ＣＤ      = "";
// MOD 2005.05.31 東都）小童谷 エラーのときはクリア END
//					iアクティブＦＧ = 1;
// MOD 2009.09.09 東都）高木 画面表示不具合の調整 
					d重量  =  0;
					texメッセージ.Text = "";
					MessageBox.Show("入力されたご依頼主コードはマスタに存在しません。","ご依頼主検索",MessageBoxButtons.OK);
					tex依頼主コード.Focus();
				}
			}
			else
			{
				// 異常終了時
				ビープ音();
				texメッセージ.Text = sList[0];
				tex依頼主コード.Focus();
// ADD 2005.05.31 東都）小童谷 エラーのときはクリア START
				s前回検索依頼主ＣＤ      = "";
// ADD 2005.05.31 東都）小童谷 エラーのときはクリア END
			}
			iアクティブＦＧ = 1;

		}

		private void tex依頼主コード_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				// メッセージのクリア
				texメッセージ.Text = "";

				// 空白除去
				tex依頼主コード.Text = tex依頼主コード.Text.Trim();
				if(tex依頼主コード.Text.Length == 0)
				{
					btn依頼主検索.Focus();
					btn依頼主検索_Click(sender, e);
				}
				else
				{
					if(!半角チェック(tex依頼主コード,"依頼主コード")) return;

					s依頼主ＣＤ = tex依頼主コード.Text;
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 START
//					if(s依頼主ＣＤ.Length > 0 && s依頼主ＣＤ != s前回検索依頼主ＣＤ) 依頼主検索();
					if(s依頼主ＣＤ.Length > 0){
						依頼主検索();
					}
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 END
				}
			}
		}

		private void tex届け先コード_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				// メッセージのクリア
				texメッセージ.Text = "";

				// 空白除去
				tex届け先コード.Text = tex届け先コード.Text.Trim();
				if(tex届け先コード.Text.Length != 0)
				{
					if(!半角チェック(tex届け先コード,"届け先コード")) return;

					texメッセージ.Text = "検索中．．．";
					s届け先ＣＤ = tex届け先コード.Text;
					届け先検索(false);
				}
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

		private void tex依頼主コード_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn依頼主検索.Focus();
				btn依頼主検索_Click(sender,e);
				e.Handled = true;
			}
		}

		private void tex届け先郵便番号１_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn住所検索.Focus();
				btn住所検索_Click(sender,e);
				e.Handled = true;
			}
		}

		private void tex届け先郵便番号２_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn住所検索.Focus();
				btn住所検索_Click(sender,e);
				e.Handled = true;
			}
		}

		private void tex届け先郵便番号２_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
// MOD 2009.02.06 東都）高木　郵便番号入力時TAB押下にて住所検索　START
			if((e.KeyCode == Keys.Enter)||(e.KeyCode == Keys.Tab))
//			if(e.KeyCode == Keys.Enter)
// MOD 2009.02.06 東都）高木　郵便番号入力時TAB押下にて住所検索　END
			{
				// 空白除去
				tex届け先郵便番号１.Text = tex届け先郵便番号１.Text.Trim();
				tex届け先郵便番号２.Text = tex届け先郵便番号２.Text.Trim();
				tex届け先住所１.Text = tex届け先住所１.Text.Trim();
				tex届け先住所２.Text = tex届け先住所２.Text.Trim();
				tex届け先住所３.Text = tex届け先住所３.Text.Trim();

				// 入力チェック
				if(!半角チェック(tex届け先郵便番号１, "郵便番号１")) return;
				if(!半角チェック(tex届け先郵便番号２, "郵便番号２")) return;

				string s郵便番号 = tex届け先郵便番号１.Text + tex届け先郵便番号２.Text;
				if(s郵便番号.Length == 7)
				{
					if(tex届け先住所１.Text.Length == 0 
						&& tex届け先住所２.Text.Length == 0
						&& tex届け先住所３.Text.Length == 0)
					{
						// カーソルを砂時計にする
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						String[] sRet = {""};
						try
						{
							texメッセージ.Text = "検索中．．．";
// MOD 2015.05.07 BEVAS）前田 王子運送郵便番号存在チェック対応 START
							//if(sv_address == null) sv_address = new is2address.Service1();
							//sRet = sv_address.Get_byPostcode2(gsaユーザ,s郵便番号);
							sRet = ＣＭ１４郵便番号存在チェック(s郵便番号);
// MOD 2015.05.07 BEVAS）前田 王子運送郵便番号存在チェック対応 END
						}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
						catch (System.Net.WebException)
						{
							sRet[0] = gs通信エラー;
						}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
						catch (Exception ex)
						{
							sRet[0] = "通信エラー：" + ex.Message;
						}
						// カーソルをデフォルトに戻す
						Cursor = System.Windows.Forms.Cursors.Default;

						if(sRet[0].Length == 4)
						{
// 保留						sRet[1]：郵便番号
// 保留						sRet[3]：住所ＣＤ
							if(sRet[2].Length > 60){
								tex届け先住所１.Text     = sRet[2].Substring(0,20);
								tex届け先住所２.Text     = sRet[2].Substring(20,20);
								tex届け先住所３.Text     = sRet[2].Substring(40,20);
							}else if(sRet[2].Length > 40){
								tex届け先住所１.Text     = sRet[2].Substring(0,20);
								tex届け先住所２.Text     = sRet[2].Substring(20,20);
								tex届け先住所３.Text     = sRet[2].Substring(40);
							}else if(sRet[2].Length > 20){
								tex届け先住所１.Text     = sRet[2].Substring(0,20);
								tex届け先住所２.Text     = sRet[2].Substring(20);
								tex届け先住所３.Text     = "";
							}else{
								tex届け先住所１.Text     = sRet[2];
								tex届け先住所２.Text     = "";
								tex届け先住所３.Text     = "";
							}
							texメッセージ.Text = "";
							//フォーカス設定
							tex届け先住所２.Focus();
						}
						else
						{
							if(sRet[0].Equals("該当データがありません"))
								sRet[0] = "郵便番号が存在しません";
							texメッセージ.Text = sRet[0];
							//フォーカス設定
							tex届け先郵便番号１.Focus();
						}
// MOD 2009.02.06 東都）高木 郵便番号変更時のカーソル移動の修正 START
					}else{
						if(e.KeyCode == Keys.Tab) tex届け先住所１.Focus();
// MOD 2009.02.06 東都）高木 郵便番号変更時のカーソル移動の修正 END
					}
				}
// MOD 2009.02.06 東都）高木　郵便番号入力時TAB押下にて住所検索　START
//				else
				else if(e.KeyCode == Keys.Enter)
// MOD 2009.02.06 東都）高木　郵便番号入力時TAB押下にて住所検索　END
				{
					btn住所検索.Focus();
					btn住所検索_Click(sender, e);
				}
// MOD 2009.02.06 東都）高木 郵便番号変更時のカーソル移動の修正 START
				else
				{
					tex届け先住所１.Focus();
				}
// MOD 2009.02.06 東都）高木 郵便番号変更時のカーソル移動の修正 END

				return;
			}
		}

		private void nUD個数_Enter(object sender, System.EventArgs e)
		{
			if(nUD個数.Text.Length > 0) nUD個数.Select(0, nUD個数.Text.Length);
		}

		private void nUD重量_Enter(object sender, System.EventArgs e)
		{
			if(nUD重量.Text.Length > 0) nUD重量.Select(0, nUD重量.Text.Length);
		}

		private void nUD保険金額_Enter(object sender, System.EventArgs e)
		{
			if(nUD保険金額.Text.Length > 0) nUD保険金額.Select(0, nUD保険金額.Text.Length);
		}

		private void tex輸送コード親_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				tex輸送コード親.Text = " ";
				btn輸送検索_Click(sender,e);
				e.Handled = true;
			}
		}

// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 START
		private void tex輸送コード子_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				if(s輸送商品親コード.Length != 0)
				{
// MOD 2005.06.01 東都）伊賀 輸送商品仕様変更 START
//					tex輸送コード親.Text = s輸送商品親コード;
//					tex輸送コード子.Text = " ";
//					btn輸送検索_Click(sender,e);
					if (g記事検索 == null)	 g記事検索 = new 記事検索();
					g記事検索.Left  = this.Left;
					g記事検索.Top   = this.Top;
					g記事検索.b輸送指示 = true;
					g記事検索.lab記事タイトル.Text = "輸送商品検索";
					//輸送商品子検索
					g記事検索.s輸送商品部門 = s輸送商品親コード;

					g記事検索.ShowDialog();
					if (g記事検索.sKcode.Length != 0)
					{
						//輸送商品子検索
						tex輸送コード子.Text = g記事検索.sKcode;
						tex輸送名子.Text = g記事検索.s記事;
						s輸送商品子コード = g記事検索.sKcode;
						tex記事コード.Focus();
					}
// MOD 2005.06.01 東都）伊賀 輸送商品仕様変更 END
				}
				e.Handled = true;
			}
		}
// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 END

// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 START
		private void 輸送商品個数重量制御()
		{
			if (s輸送商品親コード.Equals("001"))
			{
				nUD個数.Value = 1;
				nUD個数.Enabled = false;
				i才数ＦＧ = 1;
				nUD重量.Value = 1;
				lab重量.Text = "重量(kg)";
				nUD重量.Maximum = 1;
				nUD重量.Enabled = false;
			}
			else if (s輸送商品親コード.Equals("002"))
			{
				nUD個数.Value = 1;
				nUD個数.Enabled = false;
				i才数ＦＧ = 1;
				lab重量.Text = "重量(kg)";
				nUD重量.Maximum = 30;
				nUD重量.Enabled = true;
// MOD 2011.07.25 東都）高木 各項目の入力不可対応 START
				画面制御設定２(nUD重量, s画面制御_重量);
// MOD 2011.07.25 東都）高木 各項目の入力不可対応 END
			}
			else
			{
				i才数ＦＧ = i才数保持;
				if(i才数ＦＧ == 1)
				{
					nUD個数.Enabled = true;
					lab重量.Text = "重量(kg)";
					nUD重量.Maximum = 9999;
					nUD重量.Enabled = true;
// MOD 2011.07.25 東都）高木 各項目の入力不可対応 START
					画面制御設定２(nUD重量, s画面制御_重量);
// MOD 2011.07.25 東都）高木 各項目の入力不可対応 END
				}
				else
				{
					nUD個数.Enabled = true;
					lab重量.Text = "才数";
					nUD重量.Maximum = 999;
					nUD重量.Enabled = true;
// MOD 2011.07.25 東都）高木 各項目の入力不可対応 START
					画面制御設定２(nUD重量, s画面制御_重量);
// MOD 2011.07.25 東都）高木 各項目の入力不可対応 END
				}
			}
		}
// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 END

		private void tex記事コード_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn記事検索_Click(sender,e);
				e.Handled = true;
			}
		}

		private void nUD登録番号_Enter(object sender, System.EventArgs e)
		{
			if(nUD登録番号.Text.Length > 0) nUD登録番号.Select(0, nUD登録番号.Text.Length);
		}

		private void btn取消_Click(object sender, System.EventArgs e)
		{
			if(i雛型ＮＯ > 0)
			{
				// 雛型一覧から開かれた場合（更新モード）
				b更新ＦＧ           = true;
				btn削除.Visible     = true;
				tex雛型名.Text      = s雛型名称;
				nUD登録番号.Value   = i雛型ＮＯ;
				nUD登録番号.Enabled = false;
				nUD登録番号.TabStop = false;
				雛型検索();
				tex届け先コード.Focus();
			}
			else
			{
				// 照会一覧から開かれた場合（追加モード）
				b更新ＦＧ           = false;
				btn削除.Visible     = false;
				tex雛型名.Text      = "";
				nUD登録番号.Value   = 0;
				nUD登録番号.Enabled = true;
				nUD登録番号.TabStop = true;
				tex雛型名.Focus();
				if(s登録日.Length > 0 && sジャーナルＮＯ.Length > 0)
				{
					// 照会一覧から開かれた場合（追加モード）
					出荷検索();
					tex雛型名.Focus();
				}
				else
				{
					届け先項目クリア();
					依頼主項目クリア();
					その他項目クリア();
					tex依頼主コード.Text = gs荷送人ＣＤ;
					s依頼主ＣＤ          = gs荷送人ＣＤ;
					if(s依頼主ＣＤ.Length > 0) 依頼主検索();
					tex雛型名.Focus();
				}
				雛型番号設定();
			}
		}

		private void btn削除_Click(object sender, System.EventArgs e)
		{
			// 更新モード以外は、起動しない
			if(!b更新ＦＧ) return;
			DialogResult result = MessageBox.Show("このデータを削除しますか？","削除",MessageBoxButtons.YesNo);
			if(result == DialogResult.Yes)
			{
 
				string[] sKey = new string[6];
				sKey[0] = gs会員ＣＤ;
				sKey[1] = gs部門ＣＤ;
				sKey[2] = i雛型ＮＯ.ToString();
				sKey[3] = s更新年月日;
				sKey[4] = "雛型出荷";
				sKey[5] = gs利用者ＣＤ;

				// カーソルを砂時計にする
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				string sRet = "";
				try
				{
					// 雛型の削除
					// 引数：会員ＣＤ、部門ＣＤ、雛型ＮＯ、更新日時、更新ＰＧ、更新者
					// 戻値：ステータス
					texメッセージ.Text = "削除中．．．";
					if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
					sRet = sv_hinagata.Del_hinagata(gsaユーザ,sKey);
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

				// 異常終了の時
				if(sRet.Length != 4)
				{
					ビープ音();
					texメッセージ.Text = sRet;
					return;
				}

				Close();
			}
		}

		private void 雛型登録_Activated(object sender, System.EventArgs e)
		{
			if(iアクティブＦＧ == 0)
				tex雛型名.Focus();

			if(i雛型ＮＯ <= 0
				&& (s登録日.Length == 0 || sジャーナルＮＯ.Length == 0)
				&& iアクティブＦＧ == 0)
			{
				iアクティブＦＧ = 1;
				tex依頼主コード.Text = gs荷送人ＣＤ;
				s依頼主ＣＤ          = gs荷送人ＣＤ;
				if(s依頼主ＣＤ.Length > 0) 依頼主検索();
				tex雛型名.Focus();
			}
		}

// ADD 2005.05.24 東都）小童谷 フォーカス移動 START
		private void 雛型登録_Closed(object sender, System.EventArgs e)
		{
			届け先項目クリア();
			依頼主項目クリア();
			その他項目クリア();
		}
// ADD 2005.05.24 東都）小童谷 フォーカス移動 END

// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 START
		private void btn支店止め_Click(object sender, System.EventArgs e)
		{
			// 店所検索画面を起動
			if (g店所検索 == null)
			{
				g店所検索 = new 店所検索();
			}
			g店所検索.Left = this.Left + 404;
			g店所検索.Top = this.Top;
			// 画面初期値の設定
			g店所検索.s店所コード = "";
			g店所検索.s店所名 = "";
			g店所検索.s店所正式名 = "";
			g店所検索.s郵便番号 = "";
			g店所検索.ShowDialog();

			if(g店所検索.s店所コード.Length > 0)
			{
				/** 店所検索画面から、店所コードが引継がれてきた場合 */
				// 店所検索画面で取得した値を、各項目に設定
				tex届け先郵便番号１.Text = g店所検索.s郵便番号.Substring(0, 3); // 届け先郵便番号１
				tex届け先郵便番号２.Text = g店所検索.s郵便番号.Substring(3, 4); // 届け先郵便番号２
				tex届け先住所１.Text = "※※支店止め※※"; // 届け先住所１
				tex届け先住所２.Text = g店所検索.s店所正式名 + "止め"; // 届け先住所２
				tex届け先住所３.Text = 全角数字変換(g店所検索.s店所コード); // 届け先住所３

				// 届け先郵便番号および届け先住所１～３をロック
				tex届け先郵便番号１.Enabled = false; // 届け先郵便番号１
				tex届け先郵便番号２.Enabled = false; // 届け先郵便番号２
				tex届け先住所１.Enabled = false; // 届け先住所１
				tex届け先住所２.Enabled = false; // 届け先住所２
				tex届け先住所３.Enabled = false; // 届け先住所３

				// 支店止めボタンを非表示、解除ボタンを表示
				btn支店止め.Visible = false;
				btn支店止め.Enabled = false;
				btn支店止め解除.Visible = true;
				btn支店止め解除.Enabled = true;

				// フォーカスを『届け先名前１』に設定
				tex届け先名前１.Focus();
			}
			else
			{
				/** それ以外の場合 */
				// フォーカスを『住所１』に設定
				tex届け先住所１.Focus();
			}
		}

		private void btn支店止め解除_Click(object sender, System.EventArgs e)
		{
			// 届け先郵便番号および届け先住所１～３のロックを解除
			tex届け先郵便番号１.Enabled = true; // 届け先郵便番号１
			tex届け先郵便番号２.Enabled = true; // 届け先郵便番号２
			tex届け先住所１.Enabled = true; // 届け先住所１
			tex届け先住所２.Enabled = true; // 届け先住所２
			tex届け先住所３.Enabled = true; // 届け先住所３

			// 届け先郵便番号および届け先住所１～３の入力値をクリア
			tex届け先郵便番号１.Text = ""; // 届け先郵便番号１
			tex届け先郵便番号２.Text = ""; // 届け先郵便番号２
			tex届け先住所１.Text = ""; // 届け先住所１
			tex届け先住所２.Text = ""; // 届け先住所２
			tex届け先住所３.Text = ""; // 届け先住所３

			// 支店止めボタンを表示、解除ボタンを非表示
			btn支店止め.Visible = true;
			btn支店止め.Enabled = true;
			btn支店止め解除.Visible = false;
			btn支店止め解除.Enabled = false;

			// フォーカスを『届け先郵便番号１』に設定
			tex届け先郵便番号１.Focus();
		}
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 END
	}
}
