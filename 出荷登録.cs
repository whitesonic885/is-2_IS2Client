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
	/// [エントリー]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// MOD 2008.03.19 東都）高木 お届け先の上書機能の追加 
	// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 
	// MOD 2008.11.14 東都）高木 指定日区分の復活 
	//--------------------------------------------------------------------------
	// ADD 2009.03.02 東都）高木 重量０入力時の不具合調整 
	// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック 
	// ADD 2009.04.02 東都）高木 稼働日対応 
	// MOD 2009.05.01 東都）高木 オプションの項目追加 
	// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 
	// MOD 2009.08.20 パソ）藤井 郵便番号の値引継ぎ 
	// ADD 2009.09.01 パソ）藤井 記事・品名／個数の固定機能の追加 
	// MOD 2009.08.25 東都）高木 エントリー登録での請求先の存在チェックの追加 
	// MOD 2009.09.04 東都）高木 Vista対応(TAB対応もれ) 
	// MOD 2009.09.09 東都）高木 前回検索依頼主ＣＤのクリアもれ対応 
	// MOD 2009.10.05 パソ）藤井　記事・品名／個数の行別固定機能の追加
	// MOD 2009.10.16 東都）高木 記事・品名固定チェック解除機能の追加 
	// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 
	// MOD 2009.12.01 東都）高木 全角半角混在可能にする 
	// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 
	// MOD 2009.12.08 東都）高木 指定日の上限障害（上記のグローバル対応の障害）
	//--------------------------------------------------------------------------
	// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 
	// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 
	// MOD 2010.05.25 東都）高木　時間指定の変更 
	// MOD 2010.06.18 東都）高木 出荷データの参照・追加・更新・削除ログの追加 
	// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） 
	// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 
	// MOD 2010.08.31 東都）高木 重量０入力時の仕様変更 
	// MOD 2010.09.07 東都）高木 請求先チェックの表示変更 
	// MOD 2010.09.24 東都）高木 重量自動計算時の上限エラー対応 
	// MOD 2010.09.27 東都）高木 請求先部課名の追加 
	// MOD 2010.09.30 東都）高木 担当者（依頼主部署）クリア障害対応 
	// MOD 2010.10.01 東都）高木 お客様番号１６桁化 
	// MOD 2010.10.04 東都）高木 担当者（依頼主部署）フォーカス障害対応 
	// MOD 2010.11.01 東都）高木 ご依頼主情報の重量値０対応 
	// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 
	// MOD 2010.11.12 東都）高木 未発行データを削除可能にする 
	// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) 
	// ADD 2010.12.14 ACT）垣原 王子運送の対応 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない 
	// MOD 2011.01.24 東都）高木 ＧＰ送信済（出荷済）データの修正制限（ご依頼主、出荷日）
	// MOD 2011.03.11 東都）高木 ＧＰ送信済（出荷済）データの修正制限の強化 
	// MOD 2011.03.11 東都）高木 才数計算の補正 
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
	// MOD 2015.05.07 BEVAS) 前田 王子運送荷主様の郵便番号存在チェックでCM14J使用
	// MOD 2015.07.13 TDI）綱澤 バーコード読取専用画面追加
	// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応
	//--------------------------------------------------------------------------
	// MOD 2016.03.24 BEVAS）松本 王子運送版グローバル運用対応 
	// MOD 2016.04.13 BEVAS）松本 配達指定日上限の拡張
	// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応
	// MOD 2016.06.10 BEVAS）松本 記事の固定内容を出荷登録時以外でも保存
	// MOD 2016.06.10 BEVAS）松本 保険料入力チェック機能の追加（31万円以上の場合）
	//--------------------------------------------------------------------------
	public class 出荷登録 : 共通フォーム
	{
		// 公開変数
		public  string s処理ＦＧ  = "";
		public  string sジャーナルＮＯ  ="";
		public  string s登録日    = "";
		public  string s登録者ＣＤ   = "";

		// 雛型出荷照会からジャンプした場合に使用
		public  int      i雛型ＮＯ  = 0;
		public  DateTime dt雛型出荷日;
		public  bool     b雛型指定日 = false;
		public  DateTime dt雛型指定日;
		public  int      i雛型指定日区分 = 0;

		// 内部変数
		private string s届け先ＣＤ = "";
		private string s依頼主ＣＤ = "";
		private string sUpday     = "0";
		private string s前回検索依頼主ＣＤ = "";
		private int    i印刷ＦＧ = 0;
		private decimal d重量 = 0;
		private int    i送り状ＦＧ = 0;
		private int    iアクティブＦＧ = 0;
		private int    i更新ＦＧ  = 0;
		private int    i才数ＦＧ = 1;
		private int    i才数保持 = 1;
		private string s輸送商品親コード = "";
		private string s輸送商品子コード = "";
		private string s登録輸送商品コード = "";
		private string s登録送り状番号 = "";
// ADD 2009.04.02 東都）高木 稼働日対応 START
		private string s登録ＰＧ = "";
		private DateTime dt指定日最大値;
		private DateTime dt指定日最小値;
// ADD 2009.04.02 東都）高木 稼働日対応 END
// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 START
		private string[] sa記事品名固定;
// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 END
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
		private bool b指定日チェックＭＳＧ有 = false;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 START
		private string s修正前_依頼主ＣＤ = ""; //
		private string s修正前_請求先ＣＤ = ""; //
		private string s修正前_請求先部課 = ""; //請求先部課ＣＤ
		private string s修正前_請求先名   = ""; //
		private string s修正前_個数       = ""; //
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 END
// MOD 2011.07.25 東都）高木 各項目の入力不可対応 START
		private string s画面制御_重量   = "0";
		private string s画面制御_依頼主 = "0";
// MOD 2011.07.25 東都）高木 各項目の入力不可対応 END
// MOD 2015.07.13 TDI）綱澤 バーコード読取専用画面追加 START
		private string[] saグローバルチェック;
// MOD 2015.07.13 TDI）綱澤 バーコード読取専用画面追加 END

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
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.DateTimePicker dt出荷日;
		private System.Windows.Forms.DateTimePicker dt指定日;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab日時;
		private System.Windows.Forms.TextBox texお客様名;
		private System.Windows.Forms.Label labお客様名;
		private System.Windows.Forms.Label lab利用部門;
		private System.Windows.Forms.TextBox tex利用部門;
		private System.Windows.Forms.Label lab出荷登録タイトル;
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
		private 共通テキストボックス tex輸送コード親;
		private 共通テキストボックス tex記事名３;
		private 共通テキストボックス tex記事名２;
		private 共通テキストボックス tex記事名１;
		private 共通テキストボックス tex記事コード;
		private 共通テキストボックス texお客様管理番号;
		private System.Windows.Forms.NumericUpDown nUD重量;
		private System.Windows.Forms.NumericUpDown nUD保険金額;
		private System.Windows.Forms.NumericUpDown nUD個数;
		private System.Windows.Forms.Button btn削除;
		private System.Windows.Forms.Button btn取消;
		private System.Windows.Forms.Button btn更新;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.Button btn送り状印刷;
		private System.Windows.Forms.Button btn届け先検索;
		private System.Windows.Forms.Button btn依頼主検索;
		private System.Windows.Forms.Button btn住所検索;
		private System.Windows.Forms.Button btn輸送検索;
		private System.Windows.Forms.Button btn記事検索;
		private System.Windows.Forms.Button btn依頼主登録;
		private System.Windows.Forms.Button btn届け先登録;
		private System.Windows.Forms.Button btn複写;
		private System.Windows.Forms.CheckBox cBox依頼主固定;
		private System.Windows.Forms.CheckBox cBox出荷日固定;
		private System.Windows.Forms.Label lab届け先コード;
		private System.Windows.Forms.Label lab依頼主部署;
		private System.Windows.Forms.Label lab依頼主名前;
		private System.Windows.Forms.Label lab依頼主住所;
		private System.Windows.Forms.Label lab依頼主郵便番号;
		private System.Windows.Forms.Label lab依頼主電話番号;
		private System.Windows.Forms.Label lab依頼主コード;
		private System.Windows.Forms.Label lab依頼主請求先;
		private System.Windows.Forms.Label lab輸送コード;
		private System.Windows.Forms.Label lab輸送指定日;
		private System.Windows.Forms.Label lab輸送指示;
		private System.Windows.Forms.Label lab記事コード;
		private System.Windows.Forms.Label lab記事;
		private System.Windows.Forms.Label labお客様管理番号;
		private System.Windows.Forms.Label lab重量;
		private System.Windows.Forms.Label lab保険金額;
		private System.Windows.Forms.Label lab個数;
		private System.Windows.Forms.Label lab出荷日;
		private System.Windows.Forms.Label lab届け先名前;
		private System.Windows.Forms.Label lab届け先住所;
		private System.Windows.Forms.Label lab届け先郵便番号;
		private System.Windows.Forms.Label lab届け先電話番号;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox texメッセージ２;
		private System.Windows.Forms.CheckBox cBox指定日;
		private System.Windows.Forms.CheckBox cBox指定日固定;
		private System.Windows.Forms.Label label3;
		private IS2Client.共通テキストボックス tex輸送コード子;
		private IS2Client.共通テキストボックス tex輸送名親;
		private IS2Client.共通テキストボックス tex輸送名子;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cmb指定日区分;
		private System.Windows.Forms.TextBox tex請求先コード;
		private System.Windows.Forms.Label lab請求先コード;
		private System.Windows.Forms.TextBox tex請求先部課コード;
		private System.Windows.Forms.CheckBox cBox個数固定;
		private System.Windows.Forms.CheckBox cBox記事品名固定１;
		private System.Windows.Forms.CheckBox cBox記事品名固定３;
		private System.Windows.Forms.CheckBox cBox記事品名固定２;
		private System.Windows.Forms.Button btn記事品名固定;
		private System.Windows.Forms.Label lbl王子運送;
		private IS2Client.共通テキストボックス tex記事名４;
		private IS2Client.共通テキストボックス tex記事名５;
		private IS2Client.共通テキストボックス tex記事名６;
		private System.Windows.Forms.CheckBox cBox記事品名固定４;
		private System.Windows.Forms.CheckBox cBox記事品名固定５;
		private System.Windows.Forms.CheckBox cBox記事品名固定６;
		private System.Windows.Forms.Button btn支店止め;
		private System.Windows.Forms.Button btn支店止め解除;
		private System.ComponentModel.IContainer components;

		public 出荷登録()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(出荷登録));
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
			this.btn届け先登録 = new System.Windows.Forms.Button();
			this.btn届け先検索 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tex請求先部課コード = new System.Windows.Forms.TextBox();
			this.lab請求先コード = new System.Windows.Forms.Label();
			this.tex請求先コード = new System.Windows.Forms.TextBox();
			this.lab依頼主住所 = new System.Windows.Forms.Label();
			this.tex依頼主電話番号１ = new System.Windows.Forms.TextBox();
			this.tex依頼主請求先 = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.lab依頼主部署 = new System.Windows.Forms.Label();
			this.lab依頼主名前 = new System.Windows.Forms.Label();
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
			this.btn依頼主登録 = new System.Windows.Forms.Button();
			this.btn依頼主検索 = new System.Windows.Forms.Button();
			this.label21 = new System.Windows.Forms.Label();
			this.tex依頼主コード = new IS2Client.共通テキストボックス();
			this.lab依頼主請求先 = new System.Windows.Forms.Label();
			this.cBox依頼主固定 = new System.Windows.Forms.CheckBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.cBox記事品名固定６ = new System.Windows.Forms.CheckBox();
			this.cBox記事品名固定５ = new System.Windows.Forms.CheckBox();
			this.cBox記事品名固定４ = new System.Windows.Forms.CheckBox();
			this.tex記事名６ = new IS2Client.共通テキストボックス();
			this.tex記事名５ = new IS2Client.共通テキストボックス();
			this.tex記事名４ = new IS2Client.共通テキストボックス();
			this.btn記事品名固定 = new System.Windows.Forms.Button();
			this.cBox記事品名固定１ = new System.Windows.Forms.CheckBox();
			this.cBox記事品名固定３ = new System.Windows.Forms.CheckBox();
			this.cBox記事品名固定２ = new System.Windows.Forms.CheckBox();
			this.cmb指定日区分 = new System.Windows.Forms.ComboBox();
			this.tex輸送名子 = new IS2Client.共通テキストボックス();
			this.tex輸送名親 = new IS2Client.共通テキストボックス();
			this.tex輸送コード子 = new IS2Client.共通テキストボックス();
			this.label3 = new System.Windows.Forms.Label();
			this.cBox指定日固定 = new System.Windows.Forms.CheckBox();
			this.cBox指定日 = new System.Windows.Forms.CheckBox();
			this.dt指定日 = new System.Windows.Forms.DateTimePicker();
			this.btn輸送検索 = new System.Windows.Forms.Button();
			this.tex輸送コード親 = new IS2Client.共通テキストボックス();
			this.lab輸送コード = new System.Windows.Forms.Label();
			this.lab輸送指定日 = new System.Windows.Forms.Label();
			this.lab輸送指示 = new System.Windows.Forms.Label();
			this.tex記事名３ = new IS2Client.共通テキストボックス();
			this.tex記事名２ = new IS2Client.共通テキストボックス();
			this.tex記事名１ = new IS2Client.共通テキストボックス();
			this.btn記事検索 = new System.Windows.Forms.Button();
			this.tex記事コード = new IS2Client.共通テキストボックス();
			this.lab記事コード = new System.Windows.Forms.Label();
			this.lab記事 = new System.Windows.Forms.Label();
			this.texお客様管理番号 = new IS2Client.共通テキストボックス();
			this.labお客様管理番号 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.lab重量 = new System.Windows.Forms.Label();
			this.nUD重量 = new System.Windows.Forms.NumericUpDown();
			this.nUD保険金額 = new System.Windows.Forms.NumericUpDown();
			this.lab保険金額 = new System.Windows.Forms.Label();
			this.nUD個数 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.lab個数 = new System.Windows.Forms.Label();
			this.cBox個数固定 = new System.Windows.Forms.CheckBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.cBox出荷日固定 = new System.Windows.Forms.CheckBox();
			this.dt出荷日 = new System.Windows.Forms.DateTimePicker();
			this.lab出荷日 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.lbl王子運送 = new System.Windows.Forms.Label();
			this.texお客様名 = new System.Windows.Forms.TextBox();
			this.labお客様名 = new System.Windows.Forms.Label();
			this.lab利用部門 = new System.Windows.Forms.Label();
			this.tex利用部門 = new System.Windows.Forms.TextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab日時 = new System.Windows.Forms.Label();
			this.lab出荷登録タイトル = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn削除 = new System.Windows.Forms.Button();
			this.btn取消 = new System.Windows.Forms.Button();
			this.btn更新 = new System.Windows.Forms.Button();
			this.texメッセージ = new System.Windows.Forms.TextBox();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.btn送り状印刷 = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.texメッセージ２ = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nUD重量)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD保険金額)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD個数)).BeginInit();
			this.panel5.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// tex届け先コード
			// 
			this.tex届け先コード.BackColor = System.Drawing.SystemColors.Window;
			this.tex届け先コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex届け先コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex届け先コード.Location = new System.Drawing.Point(106, 2);
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
			this.tex届け先電話番号１.Location = new System.Drawing.Point(106, 28);
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
			this.panel1.Controls.Add(this.btn届け先登録);
			this.panel1.Controls.Add(this.btn届け先検索);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.tex届け先コード);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Location = new System.Drawing.Point(0, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(442, 221);
			this.panel1.TabIndex = 1;
			// 
			// btn支店止め解除
			// 
			this.btn支店止め解除.BackColor = System.Drawing.Color.SteelBlue;
			this.btn支店止め解除.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn支店止め解除.ForeColor = System.Drawing.Color.White;
			this.btn支店止め解除.Location = new System.Drawing.Point(296, 54);
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
			this.btn支店止め.Location = new System.Drawing.Point(296, 54);
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
			this.btn複写.Location = new System.Drawing.Point(246, 54);
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
			this.label35.Location = new System.Drawing.Point(26, 152);
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
			this.tex届け先名前２.Location = new System.Drawing.Point(106, 170);
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
			this.lab届け先名前.Location = new System.Drawing.Point(40, 152);
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
			this.tex届け先名前１.Location = new System.Drawing.Point(106, 148);
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
			this.btn住所検索.Location = new System.Drawing.Point(196, 54);
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
			this.tex届け先住所３.Location = new System.Drawing.Point(106, 124);
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
			this.tex届け先郵便番号２.Location = new System.Drawing.Point(154, 54);
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
			this.tex届け先郵便番号１.Location = new System.Drawing.Point(106, 54);
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
			this.label8.Location = new System.Drawing.Point(140, 60);
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
			this.tex届け先電話番号３.Location = new System.Drawing.Point(230, 28);
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
			this.tex届け先電話番号２.Location = new System.Drawing.Point(176, 28);
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
			this.label6.Location = new System.Drawing.Point(216, 34);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(12, 14);
			this.label6.TabIndex = 13;
			this.label6.Text = "－";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label5.ForeColor = System.Drawing.Color.LimeGreen;
			this.label5.Location = new System.Drawing.Point(166, 34);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(12, 14);
			this.label5.TabIndex = 11;
			this.label5.Text = "）";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label4.ForeColor = System.Drawing.Color.LimeGreen;
			this.label4.Location = new System.Drawing.Point(96, 34);
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
			this.lab届け先コード.Location = new System.Drawing.Point(40, 4);
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
			this.tex届け先住所２.Location = new System.Drawing.Point(106, 102);
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
			this.tex届け先住所１.Location = new System.Drawing.Point(106, 80);
			this.tex届け先住所１.MaxLength = 20;
			this.tex届け先住所１.Name = "tex届け先住所１";
			this.tex届け先住所１.Size = new System.Drawing.Size(330, 23);
			this.tex届け先住所１.TabIndex = 9;
			this.tex届け先住所１.Text = "";
			// 
			// btn届け先登録
			// 
			this.btn届け先登録.BackColor = System.Drawing.Color.Blue;
			this.btn届け先登録.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn届け先登録.ForeColor = System.Drawing.Color.White;
			this.btn届け先登録.Location = new System.Drawing.Point(330, 196);
			this.btn届け先登録.Name = "btn届け先登録";
			this.btn届け先登録.Size = new System.Drawing.Size(92, 22);
			this.btn届け先登録.TabIndex = 14;
			this.btn届け先登録.TabStop = false;
			this.btn届け先登録.Text = "お届け先登録";
			this.btn届け先登録.Click += new System.EventHandler(this.btn届け先登録_Click);
			// 
			// btn届け先検索
			// 
			this.btn届け先検索.BackColor = System.Drawing.Color.SteelBlue;
			this.btn届け先検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn届け先検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn届け先検索.ForeColor = System.Drawing.Color.White;
			this.btn届け先検索.Location = new System.Drawing.Point(280, 2);
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
			this.label1.Size = new System.Drawing.Size(20, 221);
			this.label1.TabIndex = 3;
			this.label1.Text = "お届け先";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(26, 202);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(18, 14);
			this.label7.TabIndex = 28;
			this.label7.Text = "※";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label9.ForeColor = System.Drawing.Color.Blue;
			this.label9.Location = new System.Drawing.Point(44, 202);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(178, 14);
			this.label9.TabIndex = 29;
			this.label9.Text = "印がある項目は必須入力項目です。";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Honeydew;
			this.panel2.Controls.Add(this.tex請求先部課コード);
			this.panel2.Controls.Add(this.lab請求先コード);
			this.panel2.Controls.Add(this.tex請求先コード);
			this.panel2.Controls.Add(this.lab依頼主住所);
			this.panel2.Controls.Add(this.tex依頼主電話番号１);
			this.panel2.Controls.Add(this.tex依頼主請求先);
			this.panel2.Controls.Add(this.label36);
			this.panel2.Controls.Add(this.lab依頼主部署);
			this.panel2.Controls.Add(this.lab依頼主名前);
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
			this.panel2.Controls.Add(this.btn依頼主登録);
			this.panel2.Controls.Add(this.btn依頼主検索);
			this.panel2.Controls.Add(this.label21);
			this.panel2.Controls.Add(this.tex依頼主コード);
			this.panel2.Controls.Add(this.lab依頼主請求先);
			this.panel2.Controls.Add(this.cBox依頼主固定);
			this.panel2.Location = new System.Drawing.Point(0, 6);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(442, 196);
			this.panel2.TabIndex = 2;
			// 
			// tex請求先部課コード
			// 
			this.tex請求先部課コード.BackColor = System.Drawing.Color.Honeydew;
			this.tex請求先部課コード.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex請求先部課コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex請求先部課コード.Location = new System.Drawing.Point(390, 174);
			this.tex請求先部課コード.Name = "tex請求先部課コード";
			this.tex請求先部課コード.ReadOnly = true;
			this.tex請求先部課コード.Size = new System.Drawing.Size(48, 16);
			this.tex請求先部課コード.TabIndex = 45;
			this.tex請求先部課コード.TabStop = false;
			this.tex請求先部課コード.Text = "";
			// 
			// lab請求先コード
			// 
			this.lab請求先コード.BackColor = System.Drawing.Color.Honeydew;
			this.lab請求先コード.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab請求先コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab請求先コード.Location = new System.Drawing.Point(262, 176);
			this.lab請求先コード.Name = "lab請求先コード";
			this.lab請求先コード.Size = new System.Drawing.Size(28, 14);
			this.lab請求先コード.TabIndex = 44;
			this.lab請求先コード.Text = "ｺｰﾄﾞ";
			// 
			// tex請求先コード
			// 
			this.tex請求先コード.BackColor = System.Drawing.Color.Honeydew;
			this.tex請求先コード.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex請求先コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex請求先コード.Location = new System.Drawing.Point(292, 174);
			this.tex請求先コード.Name = "tex請求先コード";
			this.tex請求先コード.ReadOnly = true;
			this.tex請求先コード.Size = new System.Drawing.Size(96, 16);
			this.tex請求先コード.TabIndex = 43;
			this.tex請求先コード.TabStop = false;
			this.tex請求先コード.Text = "";
			// 
			// lab依頼主住所
			// 
			this.lab依頼主住所.BackColor = System.Drawing.Color.Honeydew;
			this.lab依頼主住所.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab依頼主住所.Location = new System.Drawing.Point(40, 74);
			this.lab依頼主住所.Name = "lab依頼主住所";
			this.lab依頼主住所.Size = new System.Drawing.Size(56, 14);
			this.lab依頼主住所.TabIndex = 42;
			this.lab依頼主住所.Text = "住所";
			// 
			// tex依頼主電話番号１
			// 
			this.tex依頼主電話番号１.BackColor = System.Drawing.Color.Honeydew;
			this.tex依頼主電話番号１.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex依頼主電話番号１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主電話番号１.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex依頼主電話番号１.Location = new System.Drawing.Point(106, 32);
			this.tex依頼主電話番号１.MaxLength = 6;
			this.tex依頼主電話番号１.Name = "tex依頼主電話番号１";
			this.tex依頼主電話番号１.ReadOnly = true;
			this.tex依頼主電話番号１.Size = new System.Drawing.Size(52, 16);
			this.tex依頼主電話番号１.TabIndex = 3;
			this.tex依頼主電話番号１.TabStop = false;
			this.tex依頼主電話番号１.Text = "";
			// 
			// tex依頼主請求先
			// 
			this.tex依頼主請求先.BackColor = System.Drawing.Color.Honeydew;
			this.tex依頼主請求先.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex依頼主請求先.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主請求先.Location = new System.Drawing.Point(98, 175);
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
			this.lab依頼主部署.Location = new System.Drawing.Point(66, 152);
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
			this.lab依頼主名前.Location = new System.Drawing.Point(40, 112);
			this.lab依頼主名前.Name = "lab依頼主名前";
			this.lab依頼主名前.Size = new System.Drawing.Size(56, 14);
			this.lab依頼主名前.TabIndex = 24;
			this.lab依頼主名前.Text = "名前";
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
			this.label16.Location = new System.Drawing.Point(206, 34);
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
			this.label17.Location = new System.Drawing.Point(156, 34);
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
			this.label18.Location = new System.Drawing.Point(96, 34);
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
			this.tex依頼主部署.Location = new System.Drawing.Point(104, 148);
			this.tex依頼主部署.MaxLength = 10;
			this.tex依頼主部署.Name = "tex依頼主部署";
			this.tex依頼主部署.Size = new System.Drawing.Size(172, 23);
			this.tex依頼主部署.TabIndex = 12;
			this.tex依頼主部署.Text = "";
			// 
			// tex依頼主名前２
			// 
			this.tex依頼主名前２.BackColor = System.Drawing.Color.Honeydew;
			this.tex依頼主名前２.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex依頼主名前２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主名前２.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex依頼主名前２.Location = new System.Drawing.Point(106, 128);
			this.tex依頼主名前２.MaxLength = 20;
			this.tex依頼主名前２.Name = "tex依頼主名前２";
			this.tex依頼主名前２.ReadOnly = true;
			this.tex依頼主名前２.Size = new System.Drawing.Size(330, 16);
			this.tex依頼主名前２.TabIndex = 11;
			this.tex依頼主名前２.TabStop = false;
			this.tex依頼主名前２.Text = "";
			// 
			// tex依頼主名前１
			// 
			this.tex依頼主名前１.BackColor = System.Drawing.Color.Honeydew;
			this.tex依頼主名前１.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex依頼主名前１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主名前１.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex依頼主名前１.Location = new System.Drawing.Point(106, 110);
			this.tex依頼主名前１.MaxLength = 20;
			this.tex依頼主名前１.Name = "tex依頼主名前１";
			this.tex依頼主名前１.ReadOnly = true;
			this.tex依頼主名前１.Size = new System.Drawing.Size(330, 16);
			this.tex依頼主名前１.TabIndex = 10;
			this.tex依頼主名前１.TabStop = false;
			this.tex依頼主名前１.Text = "";
			// 
			// tex依頼主郵便番号２
			// 
			this.tex依頼主郵便番号２.BackColor = System.Drawing.Color.Honeydew;
			this.tex依頼主郵便番号２.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex依頼主郵便番号２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主郵便番号２.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex依頼主郵便番号２.Location = new System.Drawing.Point(150, 52);
			this.tex依頼主郵便番号２.MaxLength = 4;
			this.tex依頼主郵便番号２.Name = "tex依頼主郵便番号２";
			this.tex依頼主郵便番号２.ReadOnly = true;
			this.tex依頼主郵便番号２.Size = new System.Drawing.Size(36, 16);
			this.tex依頼主郵便番号２.TabIndex = 7;
			this.tex依頼主郵便番号２.TabStop = false;
			this.tex依頼主郵便番号２.Text = "";
			// 
			// tex依頼主郵便番号１
			// 
			this.tex依頼主郵便番号１.BackColor = System.Drawing.Color.Honeydew;
			this.tex依頼主郵便番号１.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex依頼主郵便番号１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主郵便番号１.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex依頼主郵便番号１.Location = new System.Drawing.Point(106, 52);
			this.tex依頼主郵便番号１.MaxLength = 3;
			this.tex依頼主郵便番号１.Name = "tex依頼主郵便番号１";
			this.tex依頼主郵便番号１.ReadOnly = true;
			this.tex依頼主郵便番号１.Size = new System.Drawing.Size(28, 16);
			this.tex依頼主郵便番号１.TabIndex = 6;
			this.tex依頼主郵便番号１.TabStop = false;
			this.tex依頼主郵便番号１.Text = "";
			// 
			// label14
			// 
			this.label14.BackColor = System.Drawing.Color.Honeydew;
			this.label14.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label14.ForeColor = System.Drawing.Color.LimeGreen;
			this.label14.Location = new System.Drawing.Point(134, 54);
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
			this.tex依頼主電話番号３.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex依頼主電話番号３.Location = new System.Drawing.Point(222, 32);
			this.tex依頼主電話番号３.MaxLength = 4;
			this.tex依頼主電話番号３.Name = "tex依頼主電話番号３";
			this.tex依頼主電話番号３.ReadOnly = true;
			this.tex依頼主電話番号３.Size = new System.Drawing.Size(36, 16);
			this.tex依頼主電話番号３.TabIndex = 5;
			this.tex依頼主電話番号３.TabStop = false;
			this.tex依頼主電話番号３.Text = "";
			// 
			// tex依頼主電話番号２
			// 
			this.tex依頼主電話番号２.BackColor = System.Drawing.Color.Honeydew;
			this.tex依頼主電話番号２.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex依頼主電話番号２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主電話番号２.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex依頼主電話番号２.Location = new System.Drawing.Point(170, 32);
			this.tex依頼主電話番号２.MaxLength = 4;
			this.tex依頼主電話番号２.Name = "tex依頼主電話番号２";
			this.tex依頼主電話番号２.ReadOnly = true;
			this.tex依頼主電話番号２.Size = new System.Drawing.Size(32, 16);
			this.tex依頼主電話番号２.TabIndex = 4;
			this.tex依頼主電話番号２.TabStop = false;
			this.tex依頼主電話番号２.Text = "";
			// 
			// lab依頼主コード
			// 
			this.lab依頼主コード.BackColor = System.Drawing.Color.Honeydew;
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
			this.tex依頼主住所２.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex依頼主住所２.Location = new System.Drawing.Point(106, 90);
			this.tex依頼主住所２.MaxLength = 20;
			this.tex依頼主住所２.Name = "tex依頼主住所２";
			this.tex依頼主住所２.ReadOnly = true;
			this.tex依頼主住所２.Size = new System.Drawing.Size(330, 16);
			this.tex依頼主住所２.TabIndex = 9;
			this.tex依頼主住所２.TabStop = false;
			this.tex依頼主住所２.Text = "";
			// 
			// tex依頼主住所１
			// 
			this.tex依頼主住所１.BackColor = System.Drawing.Color.Honeydew;
			this.tex依頼主住所１.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex依頼主住所１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主住所１.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex依頼主住所１.Location = new System.Drawing.Point(106, 72);
			this.tex依頼主住所１.MaxLength = 20;
			this.tex依頼主住所１.Name = "tex依頼主住所１";
			this.tex依頼主住所１.ReadOnly = true;
			this.tex依頼主住所１.Size = new System.Drawing.Size(330, 16);
			this.tex依頼主住所１.TabIndex = 8;
			this.tex依頼主住所１.TabStop = false;
			this.tex依頼主住所１.Text = "";
			// 
			// btn依頼主登録
			// 
			this.btn依頼主登録.BackColor = System.Drawing.Color.Blue;
			this.btn依頼主登録.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn依頼主登録.ForeColor = System.Drawing.Color.White;
			this.btn依頼主登録.Location = new System.Drawing.Point(330, 148);
			this.btn依頼主登録.Name = "btn依頼主登録";
			this.btn依頼主登録.Size = new System.Drawing.Size(92, 22);
			this.btn依頼主登録.TabIndex = 14;
			this.btn依頼主登録.TabStop = false;
			this.btn依頼主登録.Text = "ご依頼主登録";
			this.btn依頼主登録.Click += new System.EventHandler(this.btn依頼主登録_Click);
			// 
			// btn依頼主検索
			// 
			this.btn依頼主検索.BackColor = System.Drawing.Color.SteelBlue;
			this.btn依頼主検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn依頼主検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn依頼主検索.ForeColor = System.Drawing.Color.White;
			this.btn依頼主検索.Location = new System.Drawing.Point(280, 4);
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
			this.label21.Size = new System.Drawing.Size(20, 216);
			this.label21.TabIndex = 3;
			this.label21.Text = "ご依頼主";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tex依頼主コード
			// 
			this.tex依頼主コード.BackColor = System.Drawing.SystemColors.Window;
			this.tex依頼主コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex依頼主コード.Location = new System.Drawing.Point(106, 4);
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
			this.lab依頼主請求先.BackColor = System.Drawing.Color.Honeydew;
			this.lab依頼主請求先.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab依頼主請求先.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab依頼主請求先.Location = new System.Drawing.Point(40, 176);
			this.lab依頼主請求先.Name = "lab依頼主請求先";
			this.lab依頼主請求先.Size = new System.Drawing.Size(44, 14);
			this.lab依頼主請求先.TabIndex = 9;
			this.lab依頼主請求先.Text = "請求先";
			// 
			// cBox依頼主固定
			// 
			this.cBox依頼主固定.ForeColor = System.Drawing.Color.Red;
			this.cBox依頼主固定.Location = new System.Drawing.Point(338, 8);
			this.cBox依頼主固定.Name = "cBox依頼主固定";
			this.cBox依頼主固定.Size = new System.Drawing.Size(70, 16);
			this.cBox依頼主固定.TabIndex = 2;
			this.cBox依頼主固定.TabStop = false;
			this.cBox依頼主固定.Text = "固定する";
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.Honeydew;
			this.panel3.Controls.Add(this.cBox記事品名固定６);
			this.panel3.Controls.Add(this.cBox記事品名固定５);
			this.panel3.Controls.Add(this.cBox記事品名固定４);
			this.panel3.Controls.Add(this.tex記事名６);
			this.panel3.Controls.Add(this.tex記事名５);
			this.panel3.Controls.Add(this.tex記事名４);
			this.panel3.Controls.Add(this.btn記事品名固定);
			this.panel3.Controls.Add(this.cBox記事品名固定１);
			this.panel3.Controls.Add(this.cBox記事品名固定３);
			this.panel3.Controls.Add(this.cBox記事品名固定２);
			this.panel3.Controls.Add(this.cmb指定日区分);
			this.panel3.Controls.Add(this.tex輸送名子);
			this.panel3.Controls.Add(this.tex輸送名親);
			this.panel3.Controls.Add(this.tex輸送コード子);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.cBox指定日固定);
			this.panel3.Controls.Add(this.cBox指定日);
			this.panel3.Controls.Add(this.dt指定日);
			this.panel3.Controls.Add(this.btn輸送検索);
			this.panel3.Controls.Add(this.tex輸送コード親);
			this.panel3.Controls.Add(this.lab輸送コード);
			this.panel3.Controls.Add(this.lab輸送指定日);
			this.panel3.Controls.Add(this.lab輸送指示);
			this.panel3.Controls.Add(this.tex記事名３);
			this.panel3.Controls.Add(this.tex記事名２);
			this.panel3.Controls.Add(this.tex記事名１);
			this.panel3.Controls.Add(this.btn記事検索);
			this.panel3.Controls.Add(this.tex記事コード);
			this.panel3.Controls.Add(this.lab記事コード);
			this.panel3.Controls.Add(this.lab記事);
			this.panel3.Controls.Add(this.texお客様管理番号);
			this.panel3.Controls.Add(this.labお客様管理番号);
			this.panel3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.panel3.Location = new System.Drawing.Point(2, 6);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(336, 294);
			this.panel3.TabIndex = 3;
			// 
			// cBox記事品名固定６
			// 
			this.cBox記事品名固定６.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cBox記事品名固定６.ForeColor = System.Drawing.Color.Red;
			this.cBox記事品名固定６.Location = new System.Drawing.Point(320, 272);
			this.cBox記事品名固定６.Name = "cBox記事品名固定６";
			this.cBox記事品名固定６.Size = new System.Drawing.Size(14, 14);
			this.cBox記事品名固定６.TabIndex = 55;
			this.cBox記事品名固定６.TabStop = false;
			// 
			// cBox記事品名固定５
			// 
			this.cBox記事品名固定５.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cBox記事品名固定５.ForeColor = System.Drawing.Color.Red;
			this.cBox記事品名固定５.Location = new System.Drawing.Point(320, 248);
			this.cBox記事品名固定５.Name = "cBox記事品名固定５";
			this.cBox記事品名固定５.Size = new System.Drawing.Size(14, 14);
			this.cBox記事品名固定５.TabIndex = 54;
			this.cBox記事品名固定５.TabStop = false;
			// 
			// cBox記事品名固定４
			// 
			this.cBox記事品名固定４.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cBox記事品名固定４.ForeColor = System.Drawing.Color.Red;
			this.cBox記事品名固定４.Location = new System.Drawing.Point(320, 224);
			this.cBox記事品名固定４.Name = "cBox記事品名固定４";
			this.cBox記事品名固定４.Size = new System.Drawing.Size(14, 14);
			this.cBox記事品名固定４.TabIndex = 53;
			this.cBox記事品名固定４.TabStop = false;
			// 
			// tex記事名６
			// 
			this.tex記事名６.BackColor = System.Drawing.SystemColors.Window;
			this.tex記事名６.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex記事名６.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex記事名６.Location = new System.Drawing.Point(70, 268);
			this.tex記事名６.MaxLength = 30;
			this.tex記事名６.Name = "tex記事名６";
			this.tex記事名６.Size = new System.Drawing.Size(246, 23);
			this.tex記事名６.TabIndex = 52;
			this.tex記事名６.Text = "";
			// 
			// tex記事名５
			// 
			this.tex記事名５.BackColor = System.Drawing.SystemColors.Window;
			this.tex記事名５.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex記事名５.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex記事名５.Location = new System.Drawing.Point(70, 244);
			this.tex記事名５.MaxLength = 30;
			this.tex記事名５.Name = "tex記事名５";
			this.tex記事名５.Size = new System.Drawing.Size(246, 23);
			this.tex記事名５.TabIndex = 51;
			this.tex記事名５.Text = "";
			// 
			// tex記事名４
			// 
			this.tex記事名４.BackColor = System.Drawing.SystemColors.Window;
			this.tex記事名４.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex記事名４.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex記事名４.Location = new System.Drawing.Point(70, 220);
			this.tex記事名４.MaxLength = 30;
			this.tex記事名４.Name = "tex記事名４";
			this.tex記事名４.Size = new System.Drawing.Size(246, 23);
			this.tex記事名４.TabIndex = 50;
			this.tex記事名４.Text = "";
			// 
			// btn記事品名固定
			// 
			this.btn記事品名固定.BackColor = System.Drawing.Color.SteelBlue;
			this.btn記事品名固定.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn記事品名固定.Font = new System.Drawing.Font("MS UI Gothic", 9F);
			this.btn記事品名固定.ForeColor = System.Drawing.Color.White;
			this.btn記事品名固定.Location = new System.Drawing.Point(211, 124);
			this.btn記事品名固定.Name = "btn記事品名固定";
			this.btn記事品名固定.Size = new System.Drawing.Size(124, 22);
			this.btn記事品名固定.TabIndex = 0;
			this.btn記事品名固定.TabStop = false;
			this.btn記事品名固定.Text = "記事・品名を固定する";
			this.btn記事品名固定.Click += new System.EventHandler(this.btn記事品名固定_Click);
			// 
			// cBox記事品名固定１
			// 
			this.cBox記事品名固定１.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cBox記事品名固定１.ForeColor = System.Drawing.Color.Red;
			this.cBox記事品名固定１.Location = new System.Drawing.Point(320, 152);
			this.cBox記事品名固定１.Name = "cBox記事品名固定１";
			this.cBox記事品名固定１.Size = new System.Drawing.Size(14, 14);
			this.cBox記事品名固定１.TabIndex = 49;
			this.cBox記事品名固定１.TabStop = false;
			// 
			// cBox記事品名固定３
			// 
			this.cBox記事品名固定３.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cBox記事品名固定３.ForeColor = System.Drawing.Color.Red;
			this.cBox記事品名固定３.Location = new System.Drawing.Point(320, 200);
			this.cBox記事品名固定３.Name = "cBox記事品名固定３";
			this.cBox記事品名固定３.Size = new System.Drawing.Size(14, 14);
			this.cBox記事品名固定３.TabIndex = 48;
			this.cBox記事品名固定３.TabStop = false;
			// 
			// cBox記事品名固定２
			// 
			this.cBox記事品名固定２.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cBox記事品名固定２.ForeColor = System.Drawing.Color.Red;
			this.cBox記事品名固定２.Location = new System.Drawing.Point(320, 176);
			this.cBox記事品名固定２.Name = "cBox記事品名固定２";
			this.cBox記事品名固定２.Size = new System.Drawing.Size(14, 14);
			this.cBox記事品名固定２.TabIndex = 47;
			this.cBox記事品名固定２.TabStop = false;
			// 
			// cmb指定日区分
			// 
			this.cmb指定日区分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb指定日区分.Items.AddRange(new object[] {
														  "必着",
														  "指定"});
			this.cmb指定日区分.Location = new System.Drawing.Point(200, 26);
			this.cmb指定日区分.Name = "cmb指定日区分";
			this.cmb指定日区分.Size = new System.Drawing.Size(56, 24);
			this.cmb指定日区分.TabIndex = 43;
			this.cmb指定日区分.TabStop = false;
			// 
			// tex輸送名子
			// 
			this.tex輸送名子.BackColor = System.Drawing.Color.Honeydew;
			this.tex輸送名子.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex輸送名子.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex輸送名子.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex輸送名子.Location = new System.Drawing.Point(72, 100);
			this.tex輸送名子.MaxLength = 15;
			this.tex輸送名子.Name = "tex輸送名子";
			this.tex輸送名子.ReadOnly = true;
			this.tex輸送名子.Size = new System.Drawing.Size(246, 16);
			this.tex輸送名子.TabIndex = 42;
			this.tex輸送名子.TabStop = false;
			this.tex輸送名子.Text = "";
			// 
			// tex輸送名親
			// 
			this.tex輸送名親.BackColor = System.Drawing.Color.Honeydew;
			this.tex輸送名親.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex輸送名親.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex輸送名親.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex輸送名親.Location = new System.Drawing.Point(72, 78);
			this.tex輸送名親.MaxLength = 15;
			this.tex輸送名親.Name = "tex輸送名親";
			this.tex輸送名親.ReadOnly = true;
			this.tex輸送名親.Size = new System.Drawing.Size(246, 16);
			this.tex輸送名親.TabIndex = 41;
			this.tex輸送名親.TabStop = false;
			this.tex輸送名親.Text = "";
			// 
			// tex輸送コード子
			// 
			this.tex輸送コード子.BackColor = System.Drawing.SystemColors.Window;
			this.tex輸送コード子.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex輸送コード子.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex輸送コード子.Location = new System.Drawing.Point(26, 96);
			this.tex輸送コード子.MaxLength = 4;
			this.tex輸送コード子.Name = "tex輸送コード子";
			this.tex輸送コード子.Size = new System.Drawing.Size(42, 23);
			this.tex輸送コード子.TabIndex = 5;
			this.tex輸送コード子.Text = "";
			this.tex輸送コード子.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex輸送コード子_KeyDown);
			this.tex輸送コード子.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex輸送コード子_KeyPress);
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(74, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(108, 16);
			this.label3.TabIndex = 38;
			// 
			// cBox指定日固定
			// 
			this.cBox指定日固定.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cBox指定日固定.ForeColor = System.Drawing.Color.Red;
			this.cBox指定日固定.Location = new System.Drawing.Point(258, 30);
			this.cBox指定日固定.Name = "cBox指定日固定";
			this.cBox指定日固定.Size = new System.Drawing.Size(68, 18);
			this.cBox指定日固定.TabIndex = 3;
			this.cBox指定日固定.TabStop = false;
			this.cBox指定日固定.Text = "固定する";
			// 
			// cBox指定日
			// 
			this.cBox指定日.Location = new System.Drawing.Point(54, 28);
			this.cBox指定日.Name = "cBox指定日";
			this.cBox指定日.Size = new System.Drawing.Size(16, 20);
			this.cBox指定日.TabIndex = 1;
			this.cBox指定日.TabStop = false;
			this.cBox指定日.Click += new System.EventHandler(this.cBox指定日_Click);
			// 
			// dt指定日
			// 
			this.dt指定日.CalendarFont = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.dt指定日.CustomFormat = "";
			this.dt指定日.Font = new System.Drawing.Font("MS UI Gothic", 12F);
			this.dt指定日.Location = new System.Drawing.Point(70, 26);
			this.dt指定日.MaxDate = new System.DateTime(2105, 12, 31, 0, 0, 0, 0);
			this.dt指定日.MinDate = new System.DateTime(2005, 1, 1, 0, 0, 0, 0);
			this.dt指定日.Name = "dt指定日";
			this.dt指定日.Size = new System.Drawing.Size(132, 23);
			this.dt指定日.TabIndex = 2;
			this.dt指定日.TabStop = false;
			this.dt指定日.Value = new System.DateTime(2005, 1, 26, 0, 0, 0, 0);
			this.dt指定日.DropDown += new System.EventHandler(this.dt指定日_DropDown);
			this.dt指定日.CloseUp += new System.EventHandler(this.dt指定日_CloseUp);
			// 
			// btn輸送検索
			// 
			this.btn輸送検索.BackColor = System.Drawing.Color.SteelBlue;
			this.btn輸送検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn輸送検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn輸送検索.ForeColor = System.Drawing.Color.White;
			this.btn輸送検索.Location = new System.Drawing.Point(70, 52);
			this.btn輸送検索.Name = "btn輸送検索";
			this.btn輸送検索.Size = new System.Drawing.Size(48, 22);
			this.btn輸送検索.TabIndex = 3;
			this.btn輸送検索.TabStop = false;
			this.btn輸送検索.Text = "検索";
			this.btn輸送検索.Click += new System.EventHandler(this.btn輸送検索_Click);
			// 
			// tex輸送コード親
			// 
			this.tex輸送コード親.BackColor = System.Drawing.SystemColors.Window;
			this.tex輸送コード親.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex輸送コード親.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex輸送コード親.Location = new System.Drawing.Point(26, 74);
			this.tex輸送コード親.MaxLength = 4;
			this.tex輸送コード親.Name = "tex輸送コード親";
			this.tex輸送コード親.Size = new System.Drawing.Size(42, 23);
			this.tex輸送コード親.TabIndex = 4;
			this.tex輸送コード親.Text = "";
			this.tex輸送コード親.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex輸送コード親_KeyDown);
			this.tex輸送コード親.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex輸送コード親_KeyPress);
			// 
			// lab輸送コード
			// 
			this.lab輸送コード.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab輸送コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab輸送コード.Location = new System.Drawing.Point(26, 56);
			this.lab輸送コード.Name = "lab輸送コード";
			this.lab輸送コード.Size = new System.Drawing.Size(42, 14);
			this.lab輸送コード.TabIndex = 36;
			this.lab輸送コード.Text = "コード";
			// 
			// lab輸送指定日
			// 
			this.lab輸送指定日.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab輸送指定日.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab輸送指定日.Location = new System.Drawing.Point(4, 30);
			this.lab輸送指定日.Name = "lab輸送指定日";
			this.lab輸送指定日.Size = new System.Drawing.Size(64, 14);
			this.lab輸送指定日.TabIndex = 33;
			this.lab輸送指定日.Text = "指定日";
			// 
			// lab輸送指示
			// 
			this.lab輸送指示.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab輸送指示.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab輸送指示.ForeColor = System.Drawing.Color.Blue;
			this.lab輸送指示.Location = new System.Drawing.Point(4, 56);
			this.lab輸送指示.Name = "lab輸送指示";
			this.lab輸送指示.Size = new System.Drawing.Size(18, 62);
			this.lab輸送指示.TabIndex = 32;
			this.lab輸送指示.Text = "輸送商品";
			this.lab輸送指示.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tex記事名３
			// 
			this.tex記事名３.BackColor = System.Drawing.SystemColors.Window;
			this.tex記事名３.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex記事名３.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex記事名３.Location = new System.Drawing.Point(70, 196);
			this.tex記事名３.MaxLength = 30;
			this.tex記事名３.Name = "tex記事名３";
			this.tex記事名３.Size = new System.Drawing.Size(246, 23);
			this.tex記事名３.TabIndex = 14;
			this.tex記事名３.Text = "";
			// 
			// tex記事名２
			// 
			this.tex記事名２.BackColor = System.Drawing.SystemColors.Window;
			this.tex記事名２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex記事名２.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex記事名２.Location = new System.Drawing.Point(70, 172);
			this.tex記事名２.MaxLength = 30;
			this.tex記事名２.Name = "tex記事名２";
			this.tex記事名２.Size = new System.Drawing.Size(246, 23);
			this.tex記事名２.TabIndex = 12;
			this.tex記事名２.Text = "";
			// 
			// tex記事名１
			// 
			this.tex記事名１.BackColor = System.Drawing.SystemColors.Window;
			this.tex記事名１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex記事名１.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex記事名１.Location = new System.Drawing.Point(70, 148);
			this.tex記事名１.MaxLength = 30;
			this.tex記事名１.Name = "tex記事名１";
			this.tex記事名１.Size = new System.Drawing.Size(246, 23);
			this.tex記事名１.TabIndex = 10;
			this.tex記事名１.Text = "";
			// 
			// btn記事検索
			// 
			this.btn記事検索.BackColor = System.Drawing.Color.SteelBlue;
			this.btn記事検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn記事検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn記事検索.ForeColor = System.Drawing.Color.White;
			this.btn記事検索.Location = new System.Drawing.Point(70, 124);
			this.btn記事検索.Name = "btn記事検索";
			this.btn記事検索.Size = new System.Drawing.Size(48, 22);
			this.btn記事検索.TabIndex = 9;
			this.btn記事検索.TabStop = false;
			this.btn記事検索.Text = "検索";
			this.btn記事検索.Click += new System.EventHandler(this.btn記事検索_Click);
			// 
			// tex記事コード
			// 
			this.tex記事コード.BackColor = System.Drawing.SystemColors.Window;
			this.tex記事コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex記事コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex記事コード.Location = new System.Drawing.Point(26, 148);
			this.tex記事コード.MaxLength = 4;
			this.tex記事コード.Name = "tex記事コード";
			this.tex記事コード.Size = new System.Drawing.Size(42, 23);
			this.tex記事コード.TabIndex = 8;
			this.tex記事コード.Text = "";
			this.tex記事コード.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex記事コード_KeyDown);
			this.tex記事コード.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex記事コード_KeyPress);
			// 
			// lab記事コード
			// 
			this.lab記事コード.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab記事コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab記事コード.Location = new System.Drawing.Point(26, 126);
			this.lab記事コード.Name = "lab記事コード";
			this.lab記事コード.Size = new System.Drawing.Size(42, 14);
			this.lab記事コード.TabIndex = 11;
			this.lab記事コード.Text = "コード";
			// 
			// lab記事
			// 
			this.lab記事.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab記事.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab記事.ForeColor = System.Drawing.Color.Blue;
			this.lab記事.Location = new System.Drawing.Point(4, 122);
			this.lab記事.Name = "lab記事";
			this.lab記事.Size = new System.Drawing.Size(18, 168);
			this.lab記事.TabIndex = 9;
			this.lab記事.Text = "記事・品名";
			this.lab記事.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// texお客様管理番号
			// 
			this.texお客様管理番号.BackColor = System.Drawing.SystemColors.Window;
			this.texお客様管理番号.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texお客様管理番号.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.texお客様管理番号.Location = new System.Drawing.Point(70, 2);
			this.texお客様管理番号.MaxLength = 16;
			this.texお客様管理番号.Name = "texお客様管理番号";
			this.texお客様管理番号.Size = new System.Drawing.Size(190, 23);
			this.texお客様管理番号.TabIndex = 0;
			this.texお客様管理番号.Text = "";
			// 
			// labお客様管理番号
			// 
			this.labお客様管理番号.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labお客様管理番号.ForeColor = System.Drawing.Color.LimeGreen;
			this.labお客様管理番号.Location = new System.Drawing.Point(4, 8);
			this.labお客様管理番号.Name = "labお客様管理番号";
			this.labお客様管理番号.Size = new System.Drawing.Size(70, 14);
			this.labお客様管理番号.TabIndex = 9;
			this.labお客様管理番号.Text = "お客様番号";
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
			this.panel4.Controls.Add(this.cBox個数固定);
			this.panel4.Location = new System.Drawing.Point(2, 6);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(336, 92);
			this.panel4.TabIndex = 4;
			// 
			// lab重量
			// 
			this.lab重量.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab重量.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab重量.ForeColor = System.Drawing.Color.Blue;
			this.lab重量.Location = new System.Drawing.Point(112, 4);
			this.lab重量.Name = "lab重量";
			this.lab重量.Size = new System.Drawing.Size(104, 30);
			this.lab重量.TabIndex = 50;
			this.lab重量.Text = "重量(kg)";
			this.lab重量.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lab重量.Visible = false;
			// 
			// nUD重量
			// 
			this.nUD重量.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.nUD重量.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.nUD重量.Location = new System.Drawing.Point(142, 38);
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
			this.nUD保険金額.Location = new System.Drawing.Point(250, 38);
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
			this.lab保険金額.Location = new System.Drawing.Point(220, 4);
			this.lab保険金額.Name = "lab保険金額";
			this.lab保険金額.Size = new System.Drawing.Size(104, 30);
			this.lab保険金額.TabIndex = 10;
			this.lab保険金額.Text = "保険金額（万円）";
			this.lab保険金額.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nUD個数
			// 
			this.nUD個数.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.nUD個数.Location = new System.Drawing.Point(64, 38);
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
			this.label2.Location = new System.Drawing.Point(26, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(12, 16);
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
			this.lab個数.Size = new System.Drawing.Size(104, 30);
			this.lab個数.TabIndex = 4;
			this.lab個数.Text = "個数";
			this.lab個数.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cBox個数固定
			// 
			this.cBox個数固定.ForeColor = System.Drawing.Color.Red;
			this.cBox個数固定.Location = new System.Drawing.Point(6, 72);
			this.cBox個数固定.Name = "cBox個数固定";
			this.cBox個数固定.Size = new System.Drawing.Size(102, 16);
			this.cBox個数固定.TabIndex = 46;
			this.cBox個数固定.TabStop = false;
			this.cBox個数固定.Text = "個数を固定する";
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.Honeydew;
			this.panel5.Controls.Add(this.cBox出荷日固定);
			this.panel5.Controls.Add(this.dt出荷日);
			this.panel5.Controls.Add(this.lab出荷日);
			this.panel5.Location = new System.Drawing.Point(2, 6);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(420, 32);
			this.panel5.TabIndex = 0;
			// 
			// cBox出荷日固定
			// 
			this.cBox出荷日固定.ForeColor = System.Drawing.Color.Red;
			this.cBox出荷日固定.Location = new System.Drawing.Point(238, 8);
			this.cBox出荷日固定.Name = "cBox出荷日固定";
			this.cBox出荷日固定.Size = new System.Drawing.Size(114, 16);
			this.cBox出荷日固定.TabIndex = 1;
			this.cBox出荷日固定.TabStop = false;
			this.cBox出荷日固定.Text = "出荷日を固定する";
			// 
			// dt出荷日
			// 
			this.dt出荷日.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.dt出荷日.Location = new System.Drawing.Point(84, 5);
			this.dt出荷日.MaxDate = new System.DateTime(2105, 12, 31, 0, 0, 0, 0);
			this.dt出荷日.MinDate = new System.DateTime(2005, 1, 1, 0, 0, 0, 0);
			this.dt出荷日.Name = "dt出荷日";
			this.dt出荷日.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.dt出荷日.Size = new System.Drawing.Size(144, 23);
			this.dt出荷日.TabIndex = 0;
			this.dt出荷日.TabStop = false;
			this.dt出荷日.Value = new System.DateTime(2005, 1, 26, 0, 0, 0, 0);
			this.dt出荷日.ValueChanged += new System.EventHandler(this.dt出荷日_ValueChanged);
			// 
			// lab出荷日
			// 
			this.lab出荷日.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab出荷日.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab出荷日.Location = new System.Drawing.Point(18, 8);
			this.lab出荷日.Name = "lab出荷日";
			this.lab出荷日.Size = new System.Drawing.Size(56, 16);
			this.lab出荷日.TabIndex = 6;
			this.lab出荷日.Text = "出荷日";
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.PaleGreen;
			this.panel6.Controls.Add(this.lbl王子運送);
			this.panel6.Controls.Add(this.texお客様名);
			this.panel6.Controls.Add(this.labお客様名);
			this.panel6.Controls.Add(this.lab利用部門);
			this.panel6.Controls.Add(this.tex利用部門);
			this.panel6.Location = new System.Drawing.Point(0, 26);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(810, 26);
			this.panel6.TabIndex = 12;
			// 
			// lbl王子運送
			// 
			this.lbl王子運送.Font = new System.Drawing.Font("ＭＳ ゴシック", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lbl王子運送.ForeColor = System.Drawing.Color.Red;
			this.lbl王子運送.Location = new System.Drawing.Point(626, 2);
			this.lbl王子運送.Name = "lbl王子運送";
			this.lbl王子運送.Size = new System.Drawing.Size(156, 32);
			this.lbl王子運送.TabIndex = 20;
			this.lbl王子運送.Text = "王子運送対応";
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
			this.panel7.Controls.Add(this.lab出荷登録タイトル);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(792, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab日時
			// 
			this.lab日時.ForeColor = System.Drawing.Color.White;
			this.lab日時.Location = new System.Drawing.Point(674, 8);
			this.lab日時.Name = "lab日時";
			this.lab日時.Size = new System.Drawing.Size(112, 14);
			this.lab日時.TabIndex = 1;
			this.lab日時.Text = "2005/xx/xx 12:00:00";
			// 
			// lab出荷登録タイトル
			// 
			this.lab出荷登録タイトル.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab出荷登録タイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab出荷登録タイトル.ForeColor = System.Drawing.Color.White;
			this.lab出荷登録タイトル.Location = new System.Drawing.Point(12, 2);
			this.lab出荷登録タイトル.Name = "lab出荷登録タイトル";
			this.lab出荷登録タイトル.Size = new System.Drawing.Size(264, 24);
			this.lab出荷登録タイトル.TabIndex = 0;
			this.lab出荷登録タイトル.Text = "エントリー";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn削除);
			this.panel8.Controls.Add(this.btn取消);
			this.panel8.Controls.Add(this.btn更新);
			this.panel8.Controls.Add(this.texメッセージ);
			this.panel8.Controls.Add(this.btn閉じる);
			this.panel8.Controls.Add(this.btn送り状印刷);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 14;
			// 
			// btn削除
			// 
			this.btn削除.ForeColor = System.Drawing.Color.Blue;
			this.btn削除.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn削除.Location = new System.Drawing.Point(322, 6);
			this.btn削除.Name = "btn削除";
			this.btn削除.Size = new System.Drawing.Size(62, 48);
			this.btn削除.TabIndex = 4;
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
			this.btn取消.TabIndex = 3;
			this.btn取消.Text = "取消";
			this.btn取消.Click += new System.EventHandler(this.btn取消_Click);
			// 
			// btn更新
			// 
			this.btn更新.ForeColor = System.Drawing.Color.Blue;
			this.btn更新.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn更新.Location = new System.Drawing.Point(168, 6);
			this.btn更新.Name = "btn更新";
			this.btn更新.Size = new System.Drawing.Size(62, 48);
			this.btn更新.TabIndex = 2;
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
			this.texメッセージ.TabIndex = 5;
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
			// btn送り状印刷
			// 
			this.btn送り状印刷.ForeColor = System.Drawing.Color.Blue;
			this.btn送り状印刷.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn送り状印刷.Location = new System.Drawing.Point(98, 6);
			this.btn送り状印刷.Name = "btn送り状印刷";
			this.btn送り状印刷.Size = new System.Drawing.Size(62, 48);
			this.btn送り状印刷.TabIndex = 1;
			this.btn送り状印刷.Text = "ラベル　　印刷";
			this.btn送り状印刷.Click += new System.EventHandler(this.btn送り状印刷_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel5);
			this.groupBox1.Location = new System.Drawing.Point(24, 50);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(424, 40);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel1);
			this.groupBox2.Location = new System.Drawing.Point(4, 85);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(444, 229);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.panel2);
			this.groupBox3.Location = new System.Drawing.Point(4, 310);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(444, 204);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.panel3);
			this.groupBox4.Location = new System.Drawing.Point(450, 85);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(340, 303);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.panel4);
			this.groupBox5.Location = new System.Drawing.Point(450, 385);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(340, 100);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			// 
			// texメッセージ２
			// 
			this.texメッセージ２.BackColor = System.Drawing.Color.PaleGreen;
			this.texメッセージ２.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texメッセージ２.ForeColor = System.Drawing.Color.Red;
			this.texメッセージ２.Location = new System.Drawing.Point(450, 462);
			this.texメッセージ２.Multiline = true;
			this.texメッセージ２.Name = "texメッセージ２";
			this.texメッセージ２.ReadOnly = true;
			this.texメッセージ２.Size = new System.Drawing.Size(340, 52);
			this.texメッセージ２.TabIndex = 15;
			this.texメッセージ２.TabStop = false;
			this.texメッセージ２.Text = "";
			// 
			// 出荷登録
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 580);
			this.Controls.Add(this.texメッセージ２);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox5);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "出荷登録";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 エントリー";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Closed += new System.EventHandler(this.出荷登録_Closed);
			this.Activated += new System.EventHandler(this.出荷登録_Activated);
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nUD重量)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD保険金額)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD個数)).EndInit();
			this.panel5.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		private void Form1_Load(object sender, System.EventArgs e)
		{
// ADD 2005.06.24 東都）小童谷 初期化 START
			i送り状ＦＧ = 0;
// ADD 2005.06.24 東都）小童谷 初期化 END
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

// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 START
			//部門店所が取得されていない場合には、
			if(gs部門店所ＣＤ == null || gs部門店所ＣＤ.Length == 0){
				gs部門店所ＣＤ = 部門店所取得(gs部門ＣＤ);
			}
// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 END

			texメッセージ２.Visible = false;

// ADD 2010.12.14 ACT）垣原 王子運送の対応 START
			if (gs会員ＣＤ.Substring(0,1) != "J")
			{
				lbl王子運送.Visible=false;
			}
			else
			{
				lbl王子運送.Visible=true;
			}
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END


			// 出荷日の初期設定（当日）
			部門出荷日情報更新();
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
			//指定日チェックを無効にする
			//（dt出荷日.Value）を変更したイベントでチェックが走る為
			cBox指定日.Checked = false;
			b指定日チェックＭＳＧ有 = false;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
			dt出荷日.Value   = gdt出荷日;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
			b指定日チェックＭＳＧ有 = true;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
			dt出荷日.MinDate = gdt出荷日;
// ADD 2009.04.02 東都）高木 稼働日対応 START
//			dt出荷日.MaxDate = gdt出荷日.AddDays(7);
			dt出荷日.MaxDate = gdt出荷日最大値;
// ADD 2009.04.02 東都）高木 稼働日対応 END
			// 配達指定日の初期設定（当日＋２日）
// MOD 2006.06.27 東都）山本　出荷日を翌日に変更　START
			dt指定日.Value   = gdt出荷日.AddDays(1);
//			dt指定日.Value   = gdt出荷日.AddDays(2);
// MOD 2006.06.27 東都）山本　出荷日を翌日に変更　END
			dt指定日.MinDate = gdt出荷日;
// ADD 2009.04.02 東都）高木 稼働日対応 START
//			dt指定日.MaxDate = gdt出荷日.AddDays(20);
// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 START
//			dt指定日.MaxDate = gdt出荷日.AddDays(14);
			if(gs部門店所ＣＤ.Equals("047")){
				dt指定日.MaxDate = gdt出荷日.AddDays(90);
			}else{
				dt指定日.MaxDate = gdt出荷日.AddDays(14);
			}
// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 END
// MOD 2016.04.13 BEVAS）松本 配達指定日上限の拡張 START
			//セリア様の場合、配達指定日の上限を180日にまで拡張
			if(gs会員ＣＤ.Equals(gs指定日上限拡張会員ＣＤ))
			{
				dt指定日.MaxDate = gdt出荷日.AddDays(180);
			}
// MOD 2016.04.13 BEVAS）松本 配達指定日上限の拡張 END
// ADD 2009.04.02 東都）高木 稼働日対応 END
			cBox指定日.Checked = false;
			label3.Visible = true;
// MOD 2006.06.27 東都）山本　指定日を必着に固定　START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
//			label必着.Visible = false;
			cmb指定日区分.Visible = false;
			cmb指定日区分.SelectedIndex = 0;
// MOD 2008.11.14 東都）高木 指定日区分の復活 END
// MOD 2006.06.27 東都）山本　指定日を必着に固定　END
			cBox指定日固定.Visible = false;
			cBox指定日固定.Checked = false;

// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 START
			nUD保険金額.Minimum =  0;
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) START
//			nUD保険金額.Maximum = 30;
			nUD保険金額.Maximum = gl保険金額上限;
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) END
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 END

			更新可能処理();

//			btn送り状印刷.Visible = false;
			btn削除.Visible = false;

// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//			if(gsプリンタＦＧ != "1")
//				btn送り状印刷.Visible = false;
			if(gsプリンタＦＧ != "1" || gb自動出力ＯＮ){
				btn送り状印刷.Visible = false;
			}else{
				btn送り状印刷.Visible = true;
			}
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END

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
			// 更新モードで開かれた場合
			if(s処理ＦＧ == "U")
			{
// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 START
				記事品名固定無効();
// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 END
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//				btn送り状印刷.Visible = true;
//				// 端末設定でプリンタを使用できない設定の場合、印刷ボタン使用不可
//				if(gsプリンタＦＧ != "1")
//					btn送り状印刷.Visible = false;
				// 端末設定でプリンタを使用できない設定の場合、印刷ボタン使用不可
				if(gsプリンタＦＧ != "1" || gb自動出力ＯＮ){
					btn送り状印刷.Visible = false;
				}else{
					btn送り状印刷.Visible = true;
				}
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
				btn削除.Visible = true;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
				b指定日チェックＭＳＧ有 = false;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
				出荷検索();
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
				b指定日チェックＭＳＧ有 = true;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 START
				s修正前_依頼主ＣＤ = tex依頼主コード.Text.TrimEnd();
				s修正前_請求先ＣＤ = tex請求先コード.Text.TrimEnd();
				s修正前_請求先部課 = tex請求先部課コード.Text.TrimEnd();
				s修正前_請求先名   = tex依頼主請求先.Text.TrimEnd();
				s修正前_個数       = nUD個数.Text.TrimEnd();
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 END
			}
			else
			{
				if(i雛型ＮＯ > 0)
				{
// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 START
					記事品名固定無効();
// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 END
					雛型検索();
					dt出荷日.Value = dt雛型出荷日;
					if(b雛型指定日)
					{
						dt指定日.Value = dt雛型指定日;
						cBox指定日.Checked = true;
						label3.Visible = false;
// MOD 2006.06.27 東都）山本　指定日を必着に固定　START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
//						label必着.Visible = true;
						cmb指定日区分.Visible = true;
						cmb指定日区分.SelectedIndex = i雛型指定日区分;
// MOD 2008.11.14 東都）高木 指定日区分の復活 END
// MOD 2006.06.27 東都）山本　指定日を必着に固定　END
						cBox指定日固定.Visible = true;
					}
					else
					{
						label3.Visible = true;
// MOD 2006.06.27 東都）山本　指定日を必着に固定　START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
//						label必着.Visible = false;
						cmb指定日区分.Visible = false;
// MOD 2008.11.14 東都）高木 指定日区分の復活 END
// MOD 2006.06.27 東都）山本　指定日を必着に固定　END
						cBox指定日.Checked = false;
						cBox指定日固定.Visible = false;
					}
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 START
					s修正前_依頼主ＣＤ = tex依頼主コード.Text.TrimEnd();
					s修正前_請求先ＣＤ = tex請求先コード.Text.TrimEnd();
					s修正前_請求先部課 = tex請求先部課コード.Text.TrimEnd();
					s修正前_請求先名   = tex依頼主請求先.Text.TrimEnd();
					s修正前_個数       = nUD個数.Text.TrimEnd();
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 END
				}
				else
				{
// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 START
					記事品名固定有効();
					記事品名固定読込();
// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 END
					輸送商品個数重量制御();
				}
//				else
//				{
//					tex依頼主コード.Text = gs荷送人ＣＤ;
//					s依頼主ＣＤ          = gs荷送人ＣＤ;
//					if(s依頼主ＣＤ.Length > 0) 依頼主検索();
//				}
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
				bRet = 画面制御設定(sList[5]);
				texお客様管理番号.TabStop = bRet;
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
// ADD 2006.06.28 東都）山本　 エントリオプションの項目追加 START
				bRet = 画面制御設定(sList[11]);
				tex依頼主コード.TabStop = bRet;
// ADD 2006.06.28 東都）山本　 エントリオプションの項目追加 END
// MOD 2011.07.25 東都）高木 各項目の入力不可対応 START
				画面制御設定２(tex届け先住所２, sList[1]);
				画面制御設定２(tex届け先住所３, sList[2]);
				画面制御設定２(tex届け先名前２, sList[3]);
				画面制御設定２(tex依頼主部署, sList[4]);
				画面制御設定２(texお客様管理番号, sList[5]);
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
				s画面制御_依頼主        = sList[11];
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

		private void btn届け先登録_Click(object sender, System.EventArgs e)
		{
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
			if(gsオプション[18].Equals("1")){
				tex届け先住所１.Text       = tex届け先住所１.Text.TrimEnd();
				tex届け先住所２.Text       = tex届け先住所２.Text.TrimEnd();
				tex届け先住所３.Text       = tex届け先住所３.Text.TrimEnd();
				tex届け先名前１.Text       = tex届け先名前１.Text.TrimEnd();
				tex届け先名前２.Text       = tex届け先名前２.Text.TrimEnd();
			}else{
				tex届け先住所１.Text       = tex届け先住所１.Text.Trim();
				tex届け先住所２.Text       = tex届け先住所２.Text.Trim();
				tex届け先住所３.Text       = tex届け先住所３.Text.Trim();
				tex届け先名前１.Text       = tex届け先名前１.Text.Trim();
				tex届け先名前２.Text       = tex届け先名前２.Text.Trim();
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END

			//コードの引継ぎなし
//			if(!必須チェック(tex届け先コード)) return;
			if(!必須チェック(tex届け先電話番号１,"届け先電話番号１")) return;
			if(!必須チェック(tex届け先電話番号２,"届け先電話番号２")) return;
			if(!必須チェック(tex届け先電話番号３,"届け先電話番号３")) return;
			if(!必須チェック(tex届け先郵便番号１,"届け先郵便番号１")) return;
			if(!必須チェック(tex届け先郵便番号２,"届け先郵便番号２")) return;
			if(!必須チェック(tex届け先住所１,"届け先住所１")) return;
			if(!必須チェック(tex届け先名前１,"届け先名前１")) return;

//			if(!半角チェック(tex届け先コード)) return;
			if(!数値チェック(tex届け先電話番号１,"届け先電話番号１")) return;
			if(!数値チェック(tex届け先電話番号２,"届け先電話番号２")) return;
			if(!数値チェック(tex届け先電話番号３,"届け先電話番号３")) return;
			if(!半角チェック(tex届け先郵便番号１,"届け先郵便番号１")) return;
			if(!半角チェック(tex届け先郵便番号２,"届け先郵便番号２")) return;
// MOD 2011.12.08 東都）高木 住所・名前の半角入力可 START
//			if(!全角チェック(tex届け先住所１,"届け先住所１")) return;
//			if(!全角チェック(tex届け先住所２,"届け先住所２")) return;
//			if(!全角チェック(tex届け先住所３,"届け先住所３")) return;
//			if(!全角チェック(tex届け先名前１,"届け先名前１")) return;
//			if(!全角チェック(tex届け先名前２,"届け先名前２")) return;
			if(!全角変換チェック(tex届け先住所１,"届け先住所１")) return;
			if(!全角変換チェック(tex届け先住所２,"届け先住所２")) return;
			if(!全角変換チェック(tex届け先住所３,"届け先住所３")) return;
			if(!全角変換チェック(tex届け先名前１,"届け先名前１")) return;
			if(!全角変換チェック(tex届け先名前２,"届け先名前２")) return;
// MOD 2011.12.08 東都）高木 住所・名前の半角入力可 END

			//郵便番号存在チェック
			string s郵便番号 = tex届け先郵便番号１.Text + tex届け先郵便番号２.Text;
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

			if(sRet[0].Length != 4)
			{
				if(sRet[0].Equals("該当データがありません"))
					sRet[0] = "郵便番号が存在しません";
				texメッセージ.Text = sRet[0];
				ビープ音();
				tex届け先郵便番号１.Focus();
				return;
			}



// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			お届け先登録小 画面 = new お届け先登録小();
//			画面.Height = 画面.Height + 13;////
//			画面.Left = this.Left + panel2.Left + 1;
//			画面.Top = this.Top + panel2.Top + 10;
//
//			画面.sTdata[2]  = tex届け先電話番号１.Text;
//			画面.sTdata[3]  = tex届け先電話番号２.Text;
//			画面.sTdata[4]  = tex届け先電話番号３.Text;
//			画面.sTdata[5]  = tex届け先郵便番号１.Text;
//			画面.sTdata[6]  = tex届け先郵便番号２.Text;
//			画面.sTdata[7]  = tex届け先住所１.Text;
//			画面.sTdata[8]  = tex届け先住所２.Text;
//			画面.sTdata[9]  = tex届け先住所３.Text;
//			画面.sTdata[10] = tex届け先名前１.Text;
//			画面.sTdata[11] = tex届け先名前２.Text;
//
//			画面.s届け先ＣＤ = tex届け先コード.Text;
//			画面.ShowDialog();
//			tex届け先コード.Text = 画面.s届け先ＣＤ;
			if (g届先登小 == null)	 g届先登小 = new お届け先登録小();
// MOD 2008.03.19 東都）高木 お届け先の上書機能の追加 START
//			g届先登小.Left = this.Left + panel2.Left + 1;
//			g届先登小.Top = this.Top + panel2.Top + 10;
			g届先登小.Left = this.Left + (this.Width  - g届先登小.Width)  / 2;
			g届先登小.Top  = this.Top  + (this.Height - g届先登小.Height) / 2;
// MOD 2008.03.19 東都）高木 お届け先の上書機能の追加 END

			g届先登小.sTdata[2]  = tex届け先電話番号１.Text;
			g届先登小.sTdata[3]  = tex届け先電話番号２.Text;
			g届先登小.sTdata[4]  = tex届け先電話番号３.Text;
			g届先登小.sTdata[5]  = tex届け先郵便番号１.Text;
			g届先登小.sTdata[6]  = tex届け先郵便番号２.Text;
			g届先登小.sTdata[7]  = tex届け先住所１.Text;
			g届先登小.sTdata[8]  = tex届け先住所２.Text;
			g届先登小.sTdata[9]  = tex届け先住所３.Text;
			g届先登小.sTdata[10] = tex届け先名前１.Text;
			g届先登小.sTdata[11] = tex届け先名前２.Text;
// MOD 2008.03.19 東都）高木 お届け先の上書機能の追加 START
			g届先登小.sTdata[19] = sRet[3];		//住所ＣＤ
// MOD 2008.03.19 東都）高木 お届け先の上書機能の追加 END

			g届先登小.s届け先ＣＤ = tex届け先コード.Text;
			g届先登小.ShowDialog();
			tex届け先コード.Text = g届先登小.s届け先ＣＤ;

			tex依頼主コード.Focus();
// MOD 2009.09.04 東都）高木 Vista対応(TAB対応もれ) START
//// ADD 2006.10.17 東都）高木　 エントリオプションの項目追加 START
//			if(tex依頼主コード.TabStop == false)
//				System.Windows.Forms.SendKeys.SendWait("{TAB}");
//// ADD 2006.10.17 東都）高木　 エントリオプションの項目追加 END
			if(tex依頼主コード.TabStop == false){
// MOD 2011.08.02 東都）高木 各項目の入力不可対応（不具合調整） START
//				this.SelectNextControl(this.ActiveControl, true, true, true, true);
				this.SelectNextControl(tex依頼主コード, true, true, true, true);
// MOD 2011.08.02 東都）高木 各項目の入力不可対応（不具合調整） END
			}
// MOD 2009.09.04 東都）高木 Vista対応(TAB対応もれ) END
// MOD 2005.05.24 東都）小童谷 画面高速化 END
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
// MOD 2016.06.10 BEVAS）松本 記事の固定内容を出荷登録時以外でも保存 START
			//閉じるボタン押下時にも、記事の固定内容を保存する
			記事品名固定書込();
// MOD 2016.06.10 BEVAS）松本 記事の固定内容を出荷登録時以外でも保存 END
			this.Close();
		}

		private void btn依頼主登録_Click(object sender, System.EventArgs e)
		{
// ADD 2007.11.05 東都）高木 依頼主情報の最新化 START
			s前回検索依頼主ＣＤ = "";
// ADD 2007.11.05 東都）高木 依頼主情報の最新化 END
// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			ご依頼主登録 画面 = new ご依頼主登録();
//			画面.Left = this.Left;
//			画面.Top = this.Top;
//			画面.ShowDialog();
//			tex依頼主コード.Focus();
			if (g依頼登録 == null)	 g依頼登録 = new ご依頼主登録();
			g依頼登録.Left  = this.Left;
			g依頼登録.Top   = this.Top;
			g依頼登録.ShowInTaskbar = false;
			g依頼登録.ShowDialog(this);
			tex依頼主コード.Focus();
// MOD 2005.05.24 東都）小童谷 画面高速化 END
// ADD 2007.11.05 東都）高木 依頼主情報の最新化 START
			tex依頼主コード.Text = tex依頼主コード.Text.Trim();
			if(tex依頼主コード.Text.Length > 0)
			{
				if(!半角チェック(tex依頼主コード,"依頼主コード")) return;

				s依頼主ＣＤ = tex依頼主コード.Text;
				依頼主項目クリア();
				tex依頼主コード.Text = s依頼主ＣＤ;
				依頼主検索(true);
			}
// ADD 2007.11.05 東都）高木 依頼主情報の最新化 END
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
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 START
//				if((s依頼主ＣＤ != s前回検索依頼主ＣＤ)
//					|| (s依頼主ＣＤ == s前回検索依頼主ＣＤ
//					&& tex依頼主電話番号１.Text.Trim() == ""))
//				{
//					依頼主項目クリア();
//					tex依頼主コード.Text = s依頼主ＣＤ;
//					依頼主検索(true);
//				}
//				else
//				{
//					tex依頼主コード.Text = s依頼主ＣＤ;
//					tex依頼主コード.Focus();
//				}
				依頼主項目クリア();
				tex依頼主コード.Text = s依頼主ＣＤ;
				依頼主検索(true);
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

		private void btn送り状印刷_Click(object sender, System.EventArgs e)
		{
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

			i送り状ＦＧ = 1;
			i印刷ＦＧ = 0;

			if(i更新ＦＧ == 0)
				btn更新_Click(sender,e);
			else
				i印刷ＦＧ = 1;

			i更新ＦＧ = 0;

			if(i印刷ＦＧ == 0)
			{
				Cursor = System.Windows.Forms.Cursors.Default;
				return;
			}

// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） START
//			ds送り状.Clear();
			送り状データクリア();
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） END

			try
			{
				string[] sData = new string[2];
				sData[0] = s登録日;
				sData[1] = sジャーナルＮＯ;

				送り状印刷指示(sData);
			}
			catch (Exception ex)
			{
				texメッセージ.Text = ex.Message;
				ビープ音();
				return;
			}
			Cursor = System.Windows.Forms.Cursors.Default;

// MOD 2006.12.12 東都）小童谷 店所と部門店所が異なる場合は、印刷しない START
//			送り状帳票印刷();
			
//			texメッセージ.Text = "";
//			if(i送り状ＦＧ == 1)
//				Close();
			if(gb印刷)
			{
				送り状帳票印刷();
			
				texメッセージ.Text = "";
				if(i送り状ＦＧ == 1)
					Close();
			}
			else
			{
				texメッセージ.Text = "";
// MOD 2007.2.19 FJCS）桑田 メッセージ変更 START
//				MessageBox.Show("発店が違います。印刷できません。","送状印刷"
				MessageBox.Show("集荷店が違います。印刷できません。","送状印刷"
// MOD 2007.2.19 FJCS）桑田 メッセージ変更 END
					,MessageBoxButtons.OK);
				if(i送り状ＦＧ == 1)
					Close();
			}
// MOD 2006.12.12 東都）小童谷 店所と部門店所が異なる場合は、印刷しない END

		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

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
// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 END
		}

// ADD 2007.11.21 KCL) 森本 輸送コード入力チェック追加 START
		private bool CheckYusoCodeOya() {

			bool retValue = false;

			if (tex輸送コード親.Text.Length > 0) {

				if (! 半角チェック(tex輸送コード親,"輸送商品親コード")) return false;

				// カーソルを砂時計にする
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				texメッセージ.Text = "検索中．．．";

				// 親輸送名を取得
				string [] sList = {""};
				try {
					if (sv_kiji == null) sv_kiji = new is2kiji.Service1();
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
				} catch (System.Net.WebException) {
					sList[0] = gs通信エラー;
				} catch (Exception ex) {
					sList[0] = "通信エラー：" + ex.Message;
				}

				// カーソルをデフォルトに戻す
				Cursor = System.Windows.Forms.Cursors.Default;
				texメッセージ.Text = "";

				// エラー時
				if (sList[0].Length != 2) {
					ビープ音();
					texメッセージ.Text = sList[0];
					return false;
				}

				// 存在しない時
				if (sList[3] == "I") {
					texメッセージ.Text = "";
					MessageBox.Show("入力された輸送商品親コードはマスタに存在しません。","輸送検索",MessageBoxButtons.OK);
					return false;
				}

				// 空白除去
				if (sList[1] != null) {
					tex輸送名親.Text = sList[1];
					s輸送商品親コード = tex輸送コード親.Text;
				}

				輸送商品個数重量制御();

				retValue = true;
			}

			return retValue;
		}
// ADD 2007.11.21 KCL) 森本 輸送コード入力チェック追加 END
// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 START
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
// MOD 2007.11.21 KCL) 森本 輸送コード入力チェック追加 START
//						MessageBox.Show("輸送商品親コードが入力されていません。","入力チェック",MessageBoxButtons.OK);
//						return;
						// 輸送コード（親）の確認
						if (! this.CheckYusoCodeOya()) 
						{
							MessageBox.Show("輸送商品親コードが入力されていません。","入力チェック",MessageBoxButtons.OK);
							tex輸送コード親.Focus();
							return;
						}
// MOD 2007.11.21 KCL) 森本 輸送コード入力チェック追加 END
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
// MOD 2010.05.25 東都）高木　時間指定の変更 START
//							string[] items = {"１２","１３","１４","１５","１６","１７","１８","１９","２０","２１"};
							string[] items = {"１２","１３","１４","１５","１６","１７","１８","１９","２０"};
// MOD 2010.05.25 東都）高木　時間指定の変更 END
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
// MOD 2010.05.25 東都）高木　時間指定の変更 START
//							string[] items = {"１０","１１","１２","１３","１４","１５","１６","１７","１８","１９"};
							string[] items = {"１０","１１","１２","１３","１４","１５","１６","１７","１８"};
// MOD 2010.05.25 東都）高木　時間指定の変更 END
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
// ADD 2007.11.21 KCL) 森本 輸送コード入力チェック追加 START
				} 
				else 
				{
					// 輸送コード（親）の確認
					this.CheckYusoCodeOya();
// ADD 2007.11.21 KCL) 森本 輸送コード入力チェック追加 END
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
// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 END

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
// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 START
			i雛型ＮＯ = 0;
// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 END
			texお客様管理番号.Text = "";
			if(cBox指定日固定.Checked == false)
			{
				cBox指定日.Checked   = false;
				label3.Visible = true;
// MOD 2006.06.27 東都）山本　指定日を必着に固定　START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
//				label必着.Visible = false;
				cmb指定日区分.Visible = false;
				cmb指定日区分.SelectedIndex = 0;
// MOD 2008.11.14 東都）高木 指定日区分の復活 END
// MOD 2006.06.27 東都）山本　指定日を必着に固定　END
				cBox指定日固定.Visible = false;
// MOD 2006.06.27 東都）山本　出荷日を翌日に変更　START
// DEL 2009.04.02 東都）高木 稼働日対応 START
//				dt指定日.Value       = gdt出荷日.AddDays(1);				
// DEL 2009.04.02 東都）高木 稼働日対応 END
//				dt指定日.Value       = gdt出荷日.AddDays(2);				
// MOD 2006.06.27 東都）山本　出荷日を翌日に変更　END
			}
			tex輸送コード親.Text   = "";
			tex輸送コード子.Text   = "";
			tex輸送名親.Text       = "";
			tex輸送名子.Text       = "";
// MOD 2009.09.01 パソ）藤井 記事・品名／個数の固定機能の追加 START
//			tex記事名１.Text       = "";
//			tex記事名２.Text       = "";
//			tex記事名３.Text       = "";
//			nUD個数.Value          = 0;
//			nUD個数.Text           = "0";
			tex記事コード.Text		  = "";		//クリア忘れのため追加
// MOD 2009.10.05 パソ）藤井　記事・品名／個数の行別固定機能の追加 START
			//if(cBox記事品名固定.Checked == false)
			//{
			//	tex記事名１.Text       = "";
			//	tex記事名２.Text       = "";
			//	tex記事名３.Text       = "";
			//}
// MOD 2011.07.14 東都）高木 記事行の追加 END
//			if(cBox記事品名固定１.Checked == false)
//			{
//				tex記事名１.Text       = "";
//			}
//			if(cBox記事品名固定２.Checked == false)
//			{
//				tex記事名２.Text       = "";
//			}
//			if(cBox記事品名固定３.Checked == false)
//			{
//				tex記事名３.Text       = "";
//			}
			if(cBox記事品名固定１.Checked == false){
				tex記事名１.Text   = "";
			}
			if(cBox記事品名固定２.Checked == false){
				tex記事名２.Text   = "";
			}
			if(cBox記事品名固定３.Checked == false){
				tex記事名３.Text   = "";
			}
			if(cBox記事品名固定４.Checked == false){
				tex記事名４.Text   = "";
			}
			if(cBox記事品名固定５.Checked == false){
				tex記事名５.Text   = "";
			}
			if(cBox記事品名固定６.Checked == false){
				tex記事名６.Text   = "";
			}
// MOD 2011.07.14 東都）高木 記事行の追加 END
// MOD 2009.10.05 パソ）藤井　記事・品名／個数の行別固定機能の追加 END
			if(cBox個数固定.Checked == false)
			{
				nUD個数.Value          = 0;
				nUD個数.Text           = "0";
			}
// MOD 2009.09.01 パソ）藤井 記事・品名／個数の固定機能の追加 END
// MOD 2005.05.12 東都）小童谷 初期重量０ START
//			nUD重量.Value          = d重量;
			nUD重量.Value          = 0;
			nUD重量.Text           = "0";
// MOD 2005.05.12 東都）小童谷 初期重量０ END
			nUD保険金額.Value      = 0;
			nUD保険金額.Text       = "0";
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 START
			nUD保険金額.Minimum    =  0;
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) START
//			nUD保険金額.Maximum    = 30;
			nUD保険金額.Maximum    = gl保険金額上限;
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) END
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 END
// ADD 2005.05.26 東都）伊賀 輸送商品仕様変更 START
			s輸送商品親コード      = "";
			s輸送商品子コード      = "";
		    s登録輸送商品コード    = "";
		    s登録送り状番号        = "";
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
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
					if(gsオプション[18].Equals("1")){
						tex届け先住所１.Text     = sList[7].TrimEnd();
						tex届け先住所２.Text     = sList[8].TrimEnd();
						tex届け先住所３.Text     = sList[9].TrimEnd();
						tex届け先名前１.Text     = sList[10].TrimEnd();
						tex届け先名前２.Text     = sList[11].TrimEnd();
					}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
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
// MOD 2006.10.17 東都）高木　 エントリオプションの項目追加 START
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
// MOD 2006.10.17 東都）高木　 エントリオプションの項目追加 END
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

		private void 依頼主検索(bool bMsgYN)
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
					d重量  =  0;
					texメッセージ.Text = "";
					if(bMsgYN)
					{
						MessageBox.Show("入力されたご依頼主コードはマスタに存在しません。","ご依頼主検索",MessageBoxButtons.OK);
					}
					else
					{
						tex依頼主コード.Text = "";
					}
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
//					if(s依頼主ＣＤ.Length > 0 && s依頼主ＣＤ != s前回検索依頼主ＣＤ) 依頼主検索(true);
					if(s依頼主ＣＤ.Length > 0){
						依頼主検索(true);
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

		private void btn更新_Click(object sender, System.EventArgs e)
		{
			texメッセージ.Text = "";

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
				tex届け先住所１.Text       = tex届け先住所１.Text.TrimEnd();
				tex届け先住所２.Text       = tex届け先住所２.Text.TrimEnd();
				tex届け先住所３.Text       = tex届け先住所３.Text.TrimEnd();
				tex届け先名前１.Text       = tex届け先名前１.Text.TrimEnd();
				tex届け先名前２.Text       = tex届け先名前２.Text.TrimEnd();
				tex依頼主部署.Text         = tex依頼主部署.Text.TrimEnd();
			}else{
				tex届け先住所１.Text       = tex届け先住所１.Text.Trim();
				tex届け先住所２.Text       = tex届け先住所２.Text.Trim();
				tex届け先住所３.Text       = tex届け先住所３.Text.Trim();
				tex届け先名前１.Text       = tex届け先名前１.Text.Trim();
				tex届け先名前２.Text       = tex届け先名前２.Text.Trim();
				tex依頼主部署.Text         = tex依頼主部署.Text.Trim();
			}
			tex依頼主コード.Text       = tex依頼主コード.Text.Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
			texお客様管理番号.Text     = texお客様管理番号.Text.Trim();
//			tex輸送コード親.Text         = tex輸送コード親.Text.Trim();
//			tex記事コード.Text         = tex記事コード.Text.Trim();
//			tex輸送名親.Text           = tex輸送名親.Text.Trim();
//			tex輸送名子.Text           = tex輸送名子.Text.Trim();
			tex輸送名親.Text           = tex輸送名親.Text.TrimEnd();
			tex輸送名子.Text           = tex輸送名子.Text.TrimEnd();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//			tex記事名１.Text           = tex記事名１.Text.Trim();
//			tex記事名２.Text           = tex記事名２.Text.Trim();
//			tex記事名３.Text           = tex記事名３.Text.Trim();
//			tex依頼主請求先.Text       = tex依頼主請求先.Text.Trim();
			if(gsオプション[18].Equals("1")){
				tex記事名１.Text           = tex記事名１.Text.TrimEnd();
				tex記事名２.Text           = tex記事名２.Text.TrimEnd();
				tex記事名３.Text           = tex記事名３.Text.TrimEnd();
// MOD 2011.07.14 東都）高木 記事行の追加 START
				tex記事名４.Text           = tex記事名４.Text.TrimEnd();
				tex記事名５.Text           = tex記事名５.Text.TrimEnd();
				tex記事名６.Text           = tex記事名６.Text.TrimEnd();
// MOD 2011.07.14 東都）高木 記事行の追加 END
				tex依頼主請求先.Text       = tex依頼主請求先.Text.TrimEnd();
			}else{
				tex記事名１.Text           = tex記事名１.Text.Trim();
				tex記事名２.Text           = tex記事名２.Text.Trim();
				tex記事名３.Text           = tex記事名３.Text.Trim();
// MOD 2011.07.14 東都）高木 記事行の追加 START
				tex記事名４.Text           = tex記事名４.Text.Trim();
				tex記事名５.Text           = tex記事名５.Text.Trim();
				tex記事名６.Text           = tex記事名６.Text.Trim();
// MOD 2011.07.14 東都）高木 記事行の追加 END
				tex依頼主請求先.Text       = tex依頼主請求先.Text.Trim();
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 START
			tex請求先コード.Text       = tex請求先コード.Text.Trim();
			tex請求先部課コード.Text   = tex請求先部課コード.Text.Trim();
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 END

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
// ADD 2005.06.07 東都）伊賀 輸送商品仕様変更 START
			//８ＥＸＰ、９ＥＸＰ、１０ＥＸＰ、国内航空便の場合は指定日必須
			if((s輸送商品親コード.Equals("200") || s輸送商品親コード.Equals("300") || s輸送商品親コード.Equals("400") || s輸送商品親コード.Equals("500"))
				&& cBox指定日.Checked == false)
			{
// MOD 2005.06.13 東都）高木 メッセージの変更 START
//				MessageBox.Show("配達指定日は必須項目です","入力チェック",
				MessageBox.Show("現在選択している輸送商品では、指定日は必須項目です","入力チェック",
// MOD 2005.06.13 東都）高木 メッセージの変更 END
					MessageBoxButtons.OK );
				dt指定日.Focus();
				return;
			}
			//送り状登録済みのデータで
			if(s登録送り状番号.Length != 0)
			{
				//パーセルからパーセル以外に変更できない
				if(s登録輸送商品コード.Equals("001") || s登録輸送商品コード.Equals("002"))
				{
					if(!s輸送商品親コード.Equals("001") && !s輸送商品親コード.Equals("002"))
					{
						MessageBox.Show("発行済みのデータの輸送商品は、パーセルからパーセル以外に変更できません","入力チェック",
							MessageBoxButtons.OK );
						tex輸送コード親.Focus();
						return;
					}
				}
				//パーセルからパーセル以外に変更できない
				if(!s登録輸送商品コード.Equals("001") && !s登録輸送商品コード.Equals("002"))
				{
					if(s輸送商品親コード.Equals("001") || s輸送商品親コード.Equals("002"))
					{
						MessageBox.Show("発行済みのデータの輸送商品は、パーセル以外からパーセルに変更できません","入力チェック",
							MessageBoxButtons.OK );
						tex輸送コード親.Focus();
						return;
					}
				}
			}
// ADD 2005.06.07 東都）伊賀 輸送商品仕様変更 END
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
			if(!半角チェック(texお客様管理番号,"お客様管理番号")) return;
//			if(!半角チェック(tex輸送コード親,"輸送コード")) return;
//			if(!半角チェック(tex記事コード,"記事コード")) return;
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
// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 START
			if(s処理ＦＧ == "I" && i雛型ＮＯ == 0){
				記事品名固定書込();
			}
// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 END
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
			依頼主検索(true);
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
			// 更新モード or 雛形参照モードで開かれた場合
			if(s処理ＦＧ == "U" || i雛型ＮＯ > 0){
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
//			if(nUD重量.Text.Length == 0)
// MOD 2005.09.02 東都）小童谷 ValueをTextに START
//			if(nUD重量.Text.Length == 0 || nUD重量.Value == 0)
// MOD 2009.03.02 東都）高木 重量０入力時の不具合調整 START
//			if(nUD重量.Text.Length == 0 || nUD重量.Text == "0")
// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 START
//			nUD重量.Text = nUD重量.Text.Trim();
// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 END
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
						if(s処理ＦＧ == "U" || i雛型ＮＯ > 0){
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
//			if(!範囲チェック(nUD重量,"重量")) return;
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

			// 出荷日チェック
			部門出荷日情報更新();
			if (dt出荷日.Value < gdt出荷日)
			{
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック START
//				string s出荷日 = gs出荷日.Substring(0,4) + "年";
				string s出荷日 = "";
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック END
				if(gs出荷日[4] == '0')
					s出荷日 = s出荷日 + " " + gs出荷日.Substring(5,1) + "月";
				else
					s出荷日 = s出荷日 + gs出荷日.Substring(4,2) + "月";
				if(gs出荷日[6] == '0')
					s出荷日 = s出荷日 + " " + gs出荷日.Substring(7,1) + "日";
				else
					s出荷日 = s出荷日 + gs出荷日.Substring(6,2) + "日";

				MessageBox.Show("出荷日は" + s出荷日 + "以降を入力してください",
					"入力チェック",
					MessageBoxButtons.OK );
// DEL 2005.07.08 東都）高木 重複している為削除 START
//				MessageBox.Show("出荷日は"	+ s出荷日.Substring(0,4) + "年"
//											+ s出荷日.Substring(4,2) + "月"
//											+ s出荷日.Substring(6,2) + "日"
//											+ "以降で入力してください","入力チェック",
//					MessageBoxButtons.OK );
// DEL 2005.07.08 東都）高木 重複している為削除 END
				dt出荷日.Focus();
				return;
			}

			// 配達指定日チェック
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック START
//			if (cBox指定日.Checked == true && dt指定日.Value < dt出荷日.Value)
//			{
//				MessageBox.Show("配達指定日が正しく入力されていません","入力チェック",
//									MessageBoxButtons.OK );
//				dt指定日.Focus();
//				return;
//			}
			if (cBox指定日.Checked)
			{
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
				b指定日チェックＭＳＧ有 = true;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
				bool bRet = 出荷日チェック();
				if(bRet == false) return;
			}
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック END

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

// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 START
			if(tex届け先住所１.Text.Equals("※※支店止め※※"))
			{
				/** 支店止めの出荷を手入力でしようとした時の考慮 */

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

// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 START
			if(gs部門店所ＣＤ.Equals("044"))
			{
				//ログインユーザーが社内伝会員だった場合、ＣＭ０５Ｆの存在チェックを実施
				string[] saRet = new string[2];
				Cursor = System.Windows.Forms.Cursors.AppStarting;

				saRet = ＣＭ０５会員扱店Ｆチェック();
				int iRet = int.Parse(saRet[0]);
				string sChkRet = saRet[1];

				Cursor = System.Windows.Forms.Cursors.Default;
				if(iRet == 1)
				{
					//異常終了時
					ビープ音();
					string sメッセージ = "ご利用の会員に扱店登録がない為、出荷登録できません。\n" +
										"福山通運の営業本部へお問い合わせ下さい。\n" +
										"　　【チェック対象会員】 " + gs会員ＣＤ;
					MessageBox.Show(this, sメッセージ, "扱店登録チェック", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					if(sChkRet.Equals("該当データがありません"))
					{
						texメッセージ.Text = "【社内伝会員扱店チェックエラー】ご利用の会員に扱店登録がありませんでした";
					}
					else
					{
						texメッセージ.Text = "【社内伝会員扱店チェックエラー】" + sChkRet;
					}
					tex届け先コード.Focus();
					return;
				}
			}
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 END

// DEL 2009.03.02 東都）高木 重量０入力時の不具合調整 START
//// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 START
//			//依頼主情報の検索
//			s依頼主ＣＤ = tex依頼主コード.Text;
//			依頼主項目クリア２();
//			tex依頼主コード.Text = s依頼主ＣＤ;
//			依頼主検索(true);
//			//依頼主もしくは請求先が存在しない場合
//			if(tex依頼主請求先.Text.Trim().Length == 0){
//				return;
//			}
//// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 END
// DEL 2009.03.02 東都）高木 重量０入力時の不具合調整 END

			String[] sIUList;
// MOD 2005.06.08 東都）伊賀 指定日区分追加 START
// MOD 2005.05.30 東都）伊賀 輸送商品コード追加 START
// MOD 2005.05.17 東都）小童谷 才数追加 START
//			string[] s出荷Ｄ = new string[38];
//			string[] s出荷Ｄ = new string[39];
//			string[] s出荷Ｄ = new string[41];
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
//			string[] s出荷Ｄ = new string[42];
// MOD 2011.07.14 東都）高木 記事行の追加 START
//			string[] s出荷Ｄ = new string[43];
			string[] s出荷Ｄ = new string[46];
// MOD 2011.07.14 東都）高木 記事行の追加 END
			s出荷Ｄ[42] = gs重量入力制御;
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
// MOD 2005.05.17 東都）小童谷 才数追加 END
// MOD 2005.05.17 東都）伊賀 輸送商品コード追加 END
// MOD 2005.06.08 東都）伊賀 指定日区分追加 END
			s出荷Ｄ[0]  = gs会員ＣＤ;
			s出荷Ｄ[1]  = gs部門ＣＤ;
// MOD 2005.07.08 東都）高木 日付変換の変更 START
//			s出荷Ｄ[2]  = dt出荷日.Value.ToShortDateString().Replace("/","");
			s出荷Ｄ[2]  = YYYYMMDD変換(dt出荷日.Value);
// MOD 2005.07.08 東都）高木 日付変換の変更 END
			s出荷Ｄ[3]  = texお客様管理番号.Text.Trim();
			s出荷Ｄ[4]  = tex届け先コード.Text.Trim();
			s出荷Ｄ[5]  = tex届け先電話番号１.Text.Trim();
			s出荷Ｄ[6]  = tex届け先電話番号２.Text.Trim();
			s出荷Ｄ[7]  = tex届け先電話番号３.Text.Trim();
			s出荷Ｄ[8]  = tex届け先住所１.Text.Trim();
			s出荷Ｄ[9]  = tex届け先住所２.Text.Trim();
			s出荷Ｄ[10] = tex届け先住所３.Text.Trim();
			s出荷Ｄ[11] = tex届け先名前１.Text.Trim();
			s出荷Ｄ[12] = tex届け先名前２.Text.Trim();
			s出荷Ｄ[13] = tex届け先郵便番号１.Text.Trim();
			s出荷Ｄ[14] = tex届け先郵便番号２.Text.Trim();
			s出荷Ｄ[15] = tex依頼主コード.Text.Trim();
// MOD 2009.03.02 東都）高木 重量０入力時の不具合調整 START
//// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 START
//			s出荷Ｄ[17] = tex請求先コード.Text.Trim();
//			s出荷Ｄ[18] = tex請求先部課コード.Text.Trim();
//// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 END
//
//			// 請求先の取得
//			if(tex依頼主請求先.Text.Trim() == "")
//			{
//				s出荷Ｄ[16] = " ";
//// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 START
////				s出荷Ｄ[17] = " ";
////				s出荷Ｄ[18] = " ";
//// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 END
//			}
//			else
//			{
//				int iCnt;
//				if(gsa請求先ＣＤ != null)
//				{
//					for(iCnt = 0 ; iCnt < gsa請求先ＣＤ.Length; iCnt++ )
//					{
//						if(gsa請求先部課名[iCnt] == null)
//						{
//							s出荷Ｄ[16] = " ";
//// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 START
////							s出荷Ｄ[17] = " ";
////							s出荷Ｄ[18] = " ";
//// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 END
//						}
//						else
//						{
//							if(tex依頼主請求先.Text.Trim() == gsa請求先部課名[iCnt])
//							{
//								s出荷Ｄ[16] = gsa請求先ＣＤ[iCnt];
//// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 START
////								s出荷Ｄ[17] = gsa請求先部課ＣＤ[iCnt];
////								s出荷Ｄ[18] = gsa請求先部課名[iCnt];
//// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 END
//								break;
//							}
//						}
//					}
//				}
//			}
			s出荷Ｄ[16] = tex請求先コード.Text.Trim();
			s出荷Ｄ[17] = tex請求先部課コード.Text.Trim();
			s出荷Ｄ[18] = tex依頼主請求先.Text.Trim();
// MOD 2009.03.02 東都）高木 重量０入力時の不具合調整 END
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
			if(gsオプション[18].Equals("1")){
				s出荷Ｄ[8]  = tex届け先住所１.Text.TrimEnd();
				s出荷Ｄ[9]  = tex届け先住所２.Text.TrimEnd();
				s出荷Ｄ[10] = tex届け先住所３.Text.TrimEnd();
				s出荷Ｄ[11] = tex届け先名前１.Text.TrimEnd();
				s出荷Ｄ[12] = tex届け先名前２.Text.TrimEnd();
				s出荷Ｄ[18] = tex依頼主請求先.Text.TrimEnd();
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END

			s出荷Ｄ[19] = nUD個数.Value.ToString();
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
			if(gs重量入力制御 == "1"){
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
// MOD 2005.05.17 東都）小童谷 才数か重量か START
//			s出荷Ｄ[20] = nUD重量.Value.ToString();
				if(i才数ＦＧ == 0)
				{
					s出荷Ｄ[20] = "0";
					s出荷Ｄ[38] = nUD重量.Value.ToString();
				}
				else
				{
					s出荷Ｄ[20] = nUD重量.Value.ToString();
					s出荷Ｄ[38] = "0";
				}
// MOD 2005.05.17 東都）小童谷 才数か重量か END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
			}else{
				s出荷Ｄ[20] = "0";
				s出荷Ｄ[38] = "0";
			}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END

// MOD 2005.06.08 東都）伊賀 指定日区分追加 START
			if(cBox指定日.Checked == true)
			{
// MOD 2005.07.08 東都）高木 日付変換の変更 START
//				s出荷Ｄ[21] = dt指定日.Value.ToShortDateString().Replace("/","");
				s出荷Ｄ[21] = YYYYMMDD変換(dt指定日.Value);
// MOD 2005.07.08 東都）高木 日付変換の変更 END
// MOD 2006.06.27 東都）山本　指定日を必着に固定　START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
//				s出荷Ｄ[41] = "0";
				s出荷Ｄ[41] = cmb指定日区分.SelectedIndex.ToString();
// MOD 2008.11.14 東都）高木 指定日区分の復活 END
// MOD 2006.06.27 東都）山本　指定日を必着に固定　END
			}
			else
			{
				s出荷Ｄ[21] = "0";
				s出荷Ｄ[41] = "0";
			}
// MOD 2005.06.08 東都）伊賀 指定日区分追加 END

// ADD 2005.05.30 東都）伊賀 輸送商品コード追加 START
			s出荷Ｄ[39] = s輸送商品親コード.Trim();
			s出荷Ｄ[40] = s輸送商品子コード.Trim();
// ADD 2005.05.30 東都）伊賀 輸送商品コード追加 END
			s出荷Ｄ[22] = tex輸送名親.Text.TrimEnd();
			s出荷Ｄ[23] = tex輸送名子.Text.TrimEnd();
			s出荷Ｄ[24] = tex記事名１.Text.Trim();
			s出荷Ｄ[25] = tex記事名２.Text.Trim();
			s出荷Ｄ[26] = tex記事名３.Text.Trim();
// MOD 2011.07.14 東都）高木 記事行の追加 START
			s出荷Ｄ[43] = tex記事名４.Text.Trim();
			s出荷Ｄ[44] = tex記事名５.Text.Trim();
			s出荷Ｄ[45] = tex記事名６.Text.Trim();
// MOD 2011.07.14 東都）高木 記事行の追加 END
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
			if(gsオプション[18].Equals("1")){
				s出荷Ｄ[24] = tex記事名１.Text.TrimEnd();
				s出荷Ｄ[25] = tex記事名２.Text.TrimEnd();
				s出荷Ｄ[26] = tex記事名３.Text.TrimEnd();
// MOD 2011.07.14 東都）高木 記事行の追加 START
				s出荷Ｄ[43] = tex記事名４.Text.TrimEnd();
				s出荷Ｄ[44] = tex記事名５.Text.TrimEnd();
				s出荷Ｄ[45] = tex記事名６.Text.TrimEnd();
// MOD 2011.07.14 東都）高木 記事行の追加 END
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
			s出荷Ｄ[27] = "1";		//元着区分
			s出荷Ｄ[28] = nUD保険金額.Value.ToString();
			s出荷Ｄ[29] = "0";					//送り状発行済ＦＧ
			s出荷Ｄ[30] = "0";					//出荷済ＦＧ
			s出荷Ｄ[31] = "0";					//一括出荷ＦＧ
			s出荷Ｄ[32] = "出荷登録";
			s出荷Ｄ[33] = gs利用者ＣＤ;
			s出荷Ｄ[34] = sジャーナルＮＯ;
			s出荷Ｄ[35] = s登録日;
			s出荷Ｄ[36] = sUpday;
			// 荷送人部署名
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//			s出荷Ｄ[37] = tex依頼主部署.Text;
			if(gsオプション[18].Equals("1")){
				s出荷Ｄ[37] = tex依頼主部署.Text.TrimEnd();
			}else{
				s出荷Ｄ[37] = tex依頼主部署.Text.Trim();
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END

			for(int iCnt = 0 ; iCnt < s出荷Ｄ.Length; iCnt++ )
			{
				if( s出荷Ｄ[iCnt] == null 
					|| s出荷Ｄ[iCnt].Length == 0 ) s出荷Ｄ[iCnt] = " ";
			}

			DialogResult result;
			if(s処理ＦＧ == "I")
			{
//				result = MessageBox.Show("新規登録しますか？","登録",MessageBoxButtons.YesNo);
//				if(result == DialogResult.Yes)
//				{
					// カーソルを砂時計にする
					Cursor = System.Windows.Forms.Cursors.AppStarting;
					sIUList = new string[]{""};
					try
					{
						texメッセージ.Text = "登録中．．．";
						
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

					//出荷日エラー
					string s出荷年;
					string s出荷月;
					string s出荷日;
					if(sIUList[0] == "1")
					{
						s出荷年 = sIUList[1].Substring(0,4);
						s出荷月 = sIUList[1].Substring(4,2);
						if(s出荷月.Substring(0,1) == "0") s出荷月 = " " + s出荷月.Substring(1,1);
						s出荷日 = sIUList[1].Substring(6,2);
						if(s出荷日.Substring(0,1) == "0") s出荷日 = " " + s出荷日.Substring(1,1);
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック START
//						s出荷日 = s出荷年 + "年" + s出荷月 + "月" + s出荷日 + "日";
						s出荷日 = s出荷月 + "月" + s出荷日 + "日";
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック END
						texメッセージ.Text = "出荷日は、" + s出荷日 + "以降を入力してください。";
						dt出荷日.Focus();
						return;
					}

					if(sIUList[0].Length == 4)
					{
						i送り状ＦＧ = 2;
						i印刷ＦＧ = 1;
						s登録日 = sIUList[1];
						sジャーナルＮＯ = sIUList[2];
						btn取消_Click(sender, e);
					}
					else
					{
						texメッセージ.Text = sIUList[0];
						ビープ音();
						// 届け先コードにフォーカス
						tex届け先コード.Focus();
					}
//				}

			}
			else
			{
				result = MessageBox.Show("既に存在するデータに上書きしますか？","更新",MessageBoxButtons.YesNo);
				if(result == DialogResult.Yes)
				{
					// カーソルを砂時計にする
					Cursor = System.Windows.Forms.Cursors.AppStarting;
					sIUList = new string[]{""};
					try
					{
// MOD 2011.01.24 東都）高木 ＧＰ送信済（出荷済）データの修正制限（ご依頼主、出荷日）START
						string[] sList = {""};
						texメッセージ.Text = "検索中．．．";
						texメッセージ.Refresh();
						if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
						sList = sv_syukka.Get_Ssyukka(gsaユーザ
							, gs会員ＣＤ, gs部門ＣＤ, s登録日, int.Parse(sジャーナルＮＯ));
						// エラー時
						if(sList[0].Length != 4){
							Cursor = System.Windows.Forms.Cursors.Default;
							ビープ音();
							texメッセージ.Text = sList[0];
							return;
						}
						string s送り状番号 = sList[43];
//						string s状態       = sList[49];
						string s出荷済ＦＧ = sList[50];
// MOD 2011.03.11 東都）高木 ＧＰ送信済（出荷済）データの修正制限の強化 START
						string s印刷済ＦＧ = (sList.Length > 51) ? sList[51] : "";
//						string s送信済ＦＧ = (sList.Length > 52) ? sList[52] : "";
// MOD 2011.03.11 東都）高木 ＧＰ送信済（出荷済）データの修正制限の強化 END
// MOD 2015.07.13 TDI）綱澤 バーコード読取専用画面追加 START
						//発店数チェック
						bool bグローバルチェック１;
						//未集荷チェック
						bool bグローバルチェック２;

						bグローバルチェック１ = グローバルチェック１();
						if (s送り状番号.Trim() != "")
						{
							bグローバルチェック２ = グローバルチェック２(s送り状番号.Substring(4,11));
						}
						else
						{
							//空白時は修正を許可する
							bグローバルチェック２ = true;
						}
// MOD 2015.07.13 TDI）綱澤 バーコード読取専用画面追加 END
						// 出荷済ＦＧがたっている場合は、
						// 出荷日およびご依頼主コードの修正を許可しない
						//   もしくは
						// 出荷日が当日以前で、印刷済のデータは、
						// 出荷日およびご依頼主コードの修正を許可しない
// MOD 2011.03.11 東都）高木 ＧＰ送信済（出荷済）データの修正制限の強化 START
//						if(s送り状番号.Length > 0 && s出荷済ＦＧ == "1"){
						if((s送り状番号.Length > 0 && s出荷済ＦＧ == "1")
						|| (sList[1].Replace("/","").CompareTo(gs出荷日) <= 0 && s印刷済ＦＧ == "1") ){
// MOD 2011.03.11 東都）高木 ＧＰ送信済（出荷済）データの修正制限の強化 END
							// 出荷日
// MOD 2015.07.13 TDI）綱澤 バーコード読取専用画面追加 START
//							if(s出荷Ｄ[2].Trim() != sList[1].Replace("/","").Trim())
//							{
//								texメッセージ.Text = "";
//								texメッセージ.Refresh();
//								Cursor = System.Windows.Forms.Cursors.Default;
//								ビープ音();
//								MessageBox.Show("出荷日が変更されています。\n"
//									+ "印刷済データを変更する場合は、このデータを削除した後、\n"
//									+ "再度、エントリーを行って下さい。\n"
//									+ "\n"
//									+ "（※削除する前に、出荷照会画面から複写機能を利用すると簡単に\n"
//									+ "　エントリーが可能です。）\n"
//									+ "\n"
//								, "更新"
//								, MessageBoxButtons.OK);
//								if(dt出荷日.Enabled) dt出荷日.Focus();
//								return;
//							}
							if(s出荷Ｄ[2].Trim() != sList[1].Replace("/","").Trim())
							{
								if(!bグローバルチェック１ || !bグローバルチェック２)
								{
									texメッセージ.Text = "";
									texメッセージ.Refresh();
									Cursor = System.Windows.Forms.Cursors.Default;
									ビープ音();
									MessageBox.Show("出荷日が変更されています。\n"
										+ "印刷済データを変更する場合は、このデータを削除した後、\n"
										+ "再度、エントリーを行って下さい。\n"
										+ "\n"
										+ "（※削除する前に、出荷照会画面から複写機能を利用すると簡単に\n"
										+ "　エントリーが可能です。）\n"
										+ "\n"
										, "更新"
										, MessageBoxButtons.OK);
									if(dt出荷日.Enabled) dt出荷日.Focus();
									return;
								}
								else
								{
									//出荷日変更のメッセージは出さない
									texメッセージ.Text = "";
									texメッセージ.Refresh();
									MessageBox.Show("出荷登録内容が変更されます。\n"
										+ "発行済の荷札は必ず破棄して下さい、\n"
										, "更新"
										, MessageBoxButtons.OK);
								}
							}
// MOD 2015.07.13 TDI）綱澤 バーコード読取専用画面追加 END
							// ご依頼主コード
							if(s出荷Ｄ[15].Trim() != sList[14].Trim())
							{
								texメッセージ.Text = "";
								texメッセージ.Refresh();
								Cursor = System.Windows.Forms.Cursors.Default;
								ビープ音();
								MessageBox.Show("ご依頼主が変更されています。\n"
									+ "印刷済データを変更する場合は、このデータを削除した後、\n"
									+ "再度、エントリーを行って下さい。\n"
									+ "\n"
									+ "（※削除する前に、出荷照会画面から複写機能を利用すると簡単に\n"
									+ "　エントリーが可能です。）\n"
									+ "\n"
								, "更新"
								, MessageBoxButtons.OK);
								if(tex依頼主コード.Enabled) tex依頼主コード.Focus();
								return;
							}
							// 請求先コード、請求先部課コード、請求先名
							if(s出荷Ｄ[16].Trim() != sList[47].Trim()
							|| s出荷Ｄ[17].Trim() != sList[48].Trim()
							|| s出荷Ｄ[18].Trim() != sList[15].Trim()){
								texメッセージ.Text = "";
								texメッセージ.Refresh();
								Cursor = System.Windows.Forms.Cursors.Default;
								ビープ音();
								MessageBox.Show("ご依頼主の請求先が変更されています。\n"
									+ "印刷済データを変更する場合は、このデータを削除した後、\n"
									+ "再度、エントリーを行って下さい。\n"
									+ "\n"
									+ "（※削除する前に、出荷照会画面から複写機能を利用すると簡単に\n"
									+ "　エントリーが可能です。）\n"
									+ "\n"
								, "更新"
								, MessageBoxButtons.OK);
								if(tex依頼主コード.Enabled) tex依頼主コード.Focus();
								return;
							}
						}
// MOD 2011.01.24 東都）高木 ＧＰ送信済（出荷済）データの修正制限（ご依頼主、出荷日）END
						texメッセージ.Text = "更新中．．．";
// ADD 2010.12.14 ACT）垣原 王子運送の対応 START
						if (gs会員ＣＤ.Substring(0,1) != "J")
						{
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END
							if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
// MOD 2010.06.18 東都）高木 出荷データの参照・追加・更新・削除ログの追加 START
//						sIUList = sv_syukka.Upd_syukka(gsaユーザ,s出荷Ｄ);

							sIUList = sv_syukka.Upd_syukka2(gsaユーザ,s出荷Ｄ,s登録送り状番号);

// ADD 2010.12.14 ACT）垣原 王子運送の対応 START
						}
						else
						{
							if(sv_oji == null) sv_oji = new is2oji.Service1();
							sIUList = sv_oji.Upd_syukka2(gsaユーザ,s出荷Ｄ,s登録送り状番号);
						}
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END

						
// MOD 2010.06.18 東都）高木 出荷データの参照・追加・更新・削除ログの追加 END
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
						MessageBox.Show("入力されたご依頼主コードはマスタに存在しません","更新",MessageBoxButtons.OK);
						return;
					}

					//出荷日エラー
					string s出荷年;
					string s出荷月;
					string s出荷日;
					if(sIUList[0] == "1")
					{
						s出荷年 = sIUList[1].Substring(0,4);
						s出荷月 = sIUList[1].Substring(4,2);
						if(s出荷月.Substring(0,1) == "0") s出荷月 = " " + s出荷月.Substring(1,1);
						s出荷日 = sIUList[1].Substring(6,2);
						if(s出荷日.Substring(0,1) == "0") s出荷日 = " " + s出荷日.Substring(1,1);
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック START
//						s出荷日 = s出荷年 + "年" + s出荷月 + "月" + s出荷日 + "日";
						s出荷日 = s出荷月 + "月" + s出荷日 + "日";
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック END
						texメッセージ.Text = "出荷日は、" + s出荷日 + "以降を入力してください。";
						dt出荷日.Focus();
						return;
					}

					if(sIUList[0].Length == 4)
					{
						texメッセージ.Text = "";
						if(i送り状ＦＧ == 0)
							Close();
						else
							i印刷ＦＧ = 1;
//						btn取消_Click(sender, e);
						s登録輸送商品コード = s輸送商品親コード;
					}
					else
					{
						texメッセージ.Text = sIUList[0];
						ビープ音();
					}
					// 届け先コードにフォーカス
					tex届け先コード.Focus();
				}
			}

		}

		private void 更新不可処理()
		{
// MOD 2005.07.08 東都）高木 日付変換の変更 START
//			dt出荷日.MaxDate = DateTime.Parse("2105/12/31");
//			dt出荷日.MinDate = DateTime.Parse("2005/01/01");
			dt出荷日.MaxDate = YYYYMMDD変換("2105/12/31");
			dt出荷日.MinDate = YYYYMMDD変換("2005/01/01");
// MOD 2005.07.08 東都）高木 日付変換の変更 END
// MOD 2009.04.22 東都）高木 日付変換の変更 START
			dt指定日.MaxDate = YYYYMMDD変換("2105/12/31");
			dt指定日.MinDate = YYYYMMDD変換("2005/01/01");
// MOD 2009.04.22 東都）高木 日付変換の変更 END
			panel1.Enabled = false;
			panel2.Enabled = false;
			panel3.Enabled = false;
			panel4.Enabled = false;
			panel5.Enabled = false;
			btn更新.Enabled = false;
			btn取消.Enabled = false;
			btn削除.Enabled = false;
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 START
			if(tex届け先住所１.Text.Trim().Equals("※※支店止め※※"))
			{
				// 支店止めだった場合
				btn支店止め.Visible = false;
				btn支店止め.Enabled = false;
				btn支店止め解除.Visible = true;
				btn支店止め解除.Enabled = false;
			}
			else
			{
				// それ以外の場合
				btn支店止め.Visible = true;
				btn支店止め.Enabled = false;
				btn支店止め解除.Visible = false;
				btn支店止め解除.Enabled = false;
			}
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 END
			texメッセージ２.Visible = true;
		}

		private void 更新可能処理()
		{
			panel1.Enabled = true;
			panel2.Enabled = true;
			panel3.Enabled = true;
			panel4.Enabled = true;
			panel5.Enabled = true;
			btn更新.Enabled = true;
			btn送り状印刷.Visible = true;
			btn取消.Enabled = true;
			btn削除.Enabled = true;
			texメッセージ２.Visible = false;
// MOD 2011.01.24 東都）高木 ＧＰ送信済（出荷済）データの修正制限（ご依頼主、出荷日）START
			dt出荷日       .Enabled = true;
			tex依頼主コード.Enabled = true;
// MOD 2011.07.25 東都）高木 各項目の入力不可対応 START
			画面制御設定２(tex依頼主コード, s画面制御_依頼主);
// MOD 2011.07.25 東都）高木 各項目の入力不可対応 END
			btn依頼主検索  .Enabled = true;
// MOD 2011.01.24 東都）高木 ＧＰ送信済（出荷済）データの修正制限（ご依頼主、出荷日）END
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

			texメッセージ.Text = "";

			// 異常終了時
// MOD 2005.06.08 東都）伊賀 指定日区分追加 START
// MOD 2005.06.01 東都）伊賀 輸送指示コード追加 START
// MOD 2005.05.17 東都）小童谷 才数追加 START
//			if(sList[0].Length != 4 || sList[39] == "I")
//			if(sList[0].Length != 4 || sList[41] == "I")
//			if(sList[0].Length != 4 || sList[44] == "I")
			if(sList[0].Length != 4 || sList[45] == "I")
// MOD 2005.05.17 東都）小童谷 才数追加 END
// MOD 2005.06.01 東都）伊賀 輸送指示コード追加 END
// MOD 2005.06.08 東都）伊賀 指定日区分追加 END
			{
				texメッセージ.Text = sList[0];
				ビープ音();
				tex依頼主コード.Focus();
// MOD 2009.09.04 東都）高木 Vista対応(TAB対応もれ) START
//// ADD 2006.10.17 東都）高木　 エントリオプションの項目追加 START
//				if(tex依頼主コード.TabStop == false)
//					System.Windows.Forms.SendKeys.SendWait("{TAB}");
//// ADD 2006.10.17 東都）高木　 エントリオプションの項目追加 END
				if(tex依頼主コード.TabStop == false){
// MOD 2011.08.02 東都）高木 各項目の入力不可対応（不具合調整） START
//					this.SelectNextControl(this.ActiveControl, true, true, true, true);
					this.SelectNextControl(tex依頼主コード, true, true, true, true);
// MOD 2011.08.02 東都）高木 各項目の入力不可対応（不具合調整） END
				}
// MOD 2009.09.04 東都）高木 Vista対応(TAB対応もれ) END
				return;
			}

// ADD 2009.04.02 東都）高木 稼働日対応 START
			if(sList.Length > 46) s登録ＰＧ = sList[46];
// ADD 2009.04.02 東都）高木 稼働日対応 END
// MOD 2011.01.24 東都）高木 ＧＰ送信済（出荷済）データの修正制限（ご依頼主、出荷日）START
			string s出荷済ＦＧ = sList[50];
// MOD 2011.01.24 東都）高木 ＧＰ送信済（出荷済）データの修正制限（ご依頼主、出荷日）END
// MOD 2011.03.11 東都）高木 ＧＰ送信済（出荷済）データの修正制限の強化 START
			string s印刷済ＦＧ = (sList.Length > 51) ? sList[51] : "";
//			string s送信済ＦＧ = (sList.Length > 52) ? sList[52] : "";
// MOD 2011.03.11 東都）高木 ＧＰ送信済（出荷済）データの修正制限の強化 END
// MOD 2015.07.13 TDI）綱澤　バーコード読取専用画面追加 START
			string s送り状番号 = sList[43];
			bool bグローバルチェック１;
			bool bグローバルチェック２;
			bグローバルチェック１ = グローバルチェック１();
			if (s送り状番号.Trim() != "")
			{
				bグローバルチェック２ = グローバルチェック２(s送り状番号.Substring(4,11));
			}
			else
			{
				bグローバルチェック２ = true;
			}
// MOD 2015.07.13 TDI）綱澤　バーコード読取専用画面追加 END

			try
			{

// ADD 2009.04.02 東都）高木 稼働日対応 START
				if(s登録ＰＧ.Equals("自動出荷"))
				{
					dt出荷日.MaxDate = gdt出荷日最大値ＣＳＶ;
				}else{
					dt出荷日.MaxDate = gdt出荷日最大値;
				}
// MOD 2009.12.08 東都）高木 指定日の上限障害（上記のグローバル対応の障害）START
//// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 START
////				dt指定日.MaxDate = dt出荷日.Value.AddDays(14);
//				if(gs部門店所ＣＤ.Equals("047")){
//					dt指定日.MaxDate = gdt出荷日.AddDays(90);
//				}else{
//					dt指定日.MaxDate = gdt出荷日.AddDays(14);
//				}
//// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 END
				if(gs部門店所ＣＤ.Equals("047")){
					dt指定日.MaxDate = dt出荷日.Value.AddDays(90);
				}else{
					dt指定日.MaxDate = dt出荷日.Value.AddDays(14);
				}
// MOD 2009.12.08 東都）高木 指定日の上限障害（上記のグローバル対応の障害）END
// ADD 2009.04.02 東都）高木 稼働日対応 END
// MOD 2005.07.08 東都）高木 日付変換の変更 START
//				dt出荷日.Value       = DateTime.Parse(sList[1]);
				dt出荷日.Value       = YYYYMMDD変換(sList[1]);
// MOD 2005.07.08 東都）高木 日付変換の変更 END

				if(gs利用者ＣＤ != s登録者ＣＤ)
				{
					texメッセージ２.Text = "このデータは、登録者が違う為、"
						+ "修正および削除ができません。修正および削除を行う場合には、"
						+ "登録者でログインして下さい。";
					更新不可処理();
// MOD 2005.07.08 東都）高木 日付変換の変更 START
//					dt出荷日.Value   = DateTime.Parse(sList[1]);
					dt出荷日.Value   = YYYYMMDD変換(sList[1]);
// MOD 2005.07.08 東都）高木 日付変換の変更 END
					i更新ＦＧ = 1;
				}
			}
			catch (Exception)
			{
// MOD 2015.07.13 TDI）綱澤 バーコード読取専用画面追加 START
//				texメッセージ２.Text = "このデータは、確定されている為、"
//				    + "修正および削除ができません。修正および削除を行う場合には、"
//					+ "最寄の営業所まで御連絡下さい。";
//				btn送り状印刷.Visible = false;
//				更新不可処理();
//// MOD 2005.07.08 東都）高木 日付変換の変更 START
////				dt出荷日.Value   = DateTime.Parse(sList[1]);
//				dt出荷日.Value   = YYYYMMDD変換(sList[1]);
//// MOD 2005.07.08 東都）高木 日付変換の変更 END
//// MOD 2010.11.12 東都）高木 未発行データを削除可能にする START
//				if(gs利用者ＣＤ == s登録者ＣＤ){
//					string s状態       = sList[49];
//					if(s状態 == "01"){ // [状態]が「未発行」の場合
//						texメッセージ２.Text = "このデータは、確定されている為、"
//						    + "修正ができません。修正を行う場合には、"
//							+ "最寄の営業所まで御連絡下さい。";
//						btn削除.Enabled = true;
//					}
//				}
//// MOD 2010.11.12 東都）高木 未発行データを削除可能にする END
				if (!bグローバルチェック１ || !bグローバルチェック２)
				{
					//グローバル特定荷主ではない
					texメッセージ２.Text = "このデータは、確定されている為、"
						+ "修正および削除ができません。修正および削除を行う場合には、"
						+ "最寄の営業所まで御連絡下さい。";
					btn送り状印刷.Visible = false;
					更新不可処理();
					// MOD 2005.07.08 東都）高木 日付変換の変更 START
					//				dt出荷日.Value   = DateTime.Parse(sList[1]);
					dt出荷日.Value   = YYYYMMDD変換(sList[1]);
					// MOD 2005.07.08 東都）高木 日付変換の変更 END
					// MOD 2010.11.12 東都）高木 未発行データを削除可能にする START
					if(gs利用者ＣＤ == s登録者ＣＤ)
					{
						string s状態       = sList[49];
						if(s状態 == "01")
						{ // [状態]が「未発行」の場合
							texメッセージ２.Text = "このデータは、確定されている為、"
								+ "修正ができません。修正を行う場合には、"
								+ "最寄の営業所まで御連絡下さい。";
							btn削除.Enabled = true;
						}
					}
					// MOD 2010.11.12 東都）高木 未発行データを削除可能にする END
				}
				else
				{
					//グローバル特定荷主である
					//texメッセージ２.Text = "グローバル出荷修正処理";

					//出荷日は当日に修正する
					dt出荷日.Value   = DateTime.Today;

					if(gs利用者ＣＤ == s登録者ＣＤ)
					{
						string s状態       = sList[49];
						if(s状態 == "01")
						{ // [状態]が「未発行」の場合
							texメッセージ２.Text = "このデータは、確定されている為、"
								+ "修正ができません。修正を行う場合には、"
								+ "最寄の営業所まで御連絡下さい。";
							btn削除.Enabled = true;
						}
						else
						{
							nUD個数.Focus();
						}
					}
				}
// MOD 2015.07.13 TDI）綱澤 バーコード読取専用画面追加 END
			}
// MOD 2011.01.24 東都）高木 ＧＰ送信済（出荷済）データの修正制限（ご依頼主、出荷日）START
// MOD 2011.03.11 東都）高木 ＧＰ送信済（出荷済）データの修正制限の強化 START
//			if(s出荷済ＦＧ == "1"){
			if((s出荷済ＦＧ == "1")
			|| (sList[1].Replace("/","").CompareTo(gs出荷日) <= 0 && s印刷済ＦＧ == "1")){
// MOD 2011.03.11 東都）高木 ＧＰ送信済（出荷済）データの修正制限の強化 END
				dt出荷日       .Enabled = false;
				tex依頼主コード.Enabled = false;
				btn依頼主検索  .Enabled = false;
			}else{
				dt出荷日       .Enabled = true;
				tex依頼主コード.Enabled = true;
// MOD 2011.07.25 東都）高木 各項目の入力不可対応 START
				画面制御設定２(tex依頼主コード, s画面制御_依頼主);
// MOD 2011.07.25 東都）高木 各項目の入力不可対応 END
				btn依頼主検索  .Enabled = true;
			}
// MOD 2011.01.24 東都）高木 ＧＰ送信済（出荷済）データの修正制限（ご依頼主、出荷日）END

			texお客様管理番号.Text    = sList[2];
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
//				tex依頼主請求先.Text      = sList[15];
// ADD 2005.06.01 東都）伊賀 輸送指示コード追加 START
			s輸送商品親コード         = sList[41];
			s輸送商品子コード         = sList[42];
			輸送商品個数重量制御();
// ADD 2005.06.01 東都）伊賀 輸送指示コード追加 END
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
			if(sList[18] == "0")
			{
				cBox指定日.Checked    = false;
				label3.Visible = true;
// MOD 2006.06.27 東都）山本　指定日を必着に固定　START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
//				label必着.Visible = false;
				cmb指定日区分.Visible = false;
// MOD 2008.11.14 東都）高木 指定日区分の復活 END
// MOD 2006.06.27 東都）山本　指定日を必着に固定　END
				cBox指定日固定.Visible = false;
			}
			else
			{
				label3.Visible = false;
// MOD 2006.06.27 東都）山本　指定日を必着に固定　START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
//				label必着.Visible = true;
				cmb指定日区分.Visible = true;
// MOD 2008.11.14 東都）高木 指定日区分の復活 END
// MOD 2006.06.27 東都）山本　指定日を必着に固定　END
				cBox指定日.Checked    = true;
				cBox指定日固定.Visible = true;
				try
				{
// MOD 2005.07.08 東都）高木 日付変換の変更 START
//					dt指定日.Value        = DateTime.Parse(sList[18]);
					dt指定日.Value        = YYYYMMDD変換(sList[18]);
// MOD 2005.07.08 東都）高木 日付変換の変更 END
				}
				catch (Exception)
				{
// MOD 2005.07.08 東都）高木 日付変換の変更 START
//					dt指定日.MaxDate = DateTime.Parse("2105/12/31");
//					dt指定日.MinDate = DateTime.Parse("2005/01/01");
//					dt指定日.Value   = DateTime.Parse(sList[18]);
					dt指定日.MaxDate = YYYYMMDD変換("2105/12/31");
					dt指定日.MinDate = YYYYMMDD変換("2005/01/01");
					dt指定日.Value   = YYYYMMDD変換(sList[18]);
// MOD 2005.07.08 東都）高木 日付変換の変更 END
					panel1.Enabled = false;
					panel2.Enabled = false;
					panel3.Enabled = false;
					panel4.Enabled = false;
					panel5.Enabled = false;
					btn更新.Enabled = false;
					btn送り状印刷.Visible = false;
					btn取消.Enabled = false;
					btn削除.Enabled = false;
					texメッセージ２.Visible = true;
				}
			}
// DEL 2006.06.27 東都）山本　指定日を必着に固定　START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
// ADD 2005.06.08 東都）伊賀 指定日区分追加 START
			if (sList[44].Length != 0)
				cmb指定日区分.SelectedIndex = int.Parse(sList[44]);
			else
				cmb指定日区分.SelectedIndex = 0;
// ADD 2005.06.08 東都）伊賀 指定日区分追加 END
// MOD 2008.11.14 東都）高木 指定日区分の復活 END
// DEL 2006.06.27 東都）山本　指定日を必着に固定　END
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
			nUD保険金額.Value         = decimal.Parse(sList[24]);
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
			tex依頼主部署.Text = sList[37];
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 START
			// 現行の請求先情報を表示
			tex請求先コード.Text     = sList[47];
			tex請求先部課コード.Text = sList[48];
			tex依頼主請求先.Text     = sList[15];
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 END

			sUpday             = sList[25];

			// 届け先コードにフォーカス
			s依頼主ＣＤ         = tex依頼主コード.Text;
			s前回検索依頼主ＣＤ = tex依頼主コード.Text;
// MOD 2005.05.12 東都）小童谷 依頼主重量 START
//			d重量 = nUD重量.Value;
// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 STRAT
//// MOD 2005.05.17 東都）小童谷 才数追加 START
////			d重量 = decimal.Parse(sList[38]);
//			if(i才数ＦＧ == 0)
//				d重量 = decimal.Parse(sList[40]);
//			else
//				d重量 = decimal.Parse(sList[38]);
//// MOD 2005.05.17 東都）小童谷 才数追加 END
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
// MOD 2005.05.12 東都）小童谷 依頼主重量 END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
			}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
			s登録送り状番号 = sList[43].Trim();
			if (s登録送り状番号.Length != 0)
				s登録輸送商品コード = s輸送商品親コード;
			tex届け先コード.Focus();
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
//				int iPos = 1;
//				tex雛型名.Text            = sList[iPos++].Trim();
//				sファイル名               = sList[iPos++].Trim();
				int iPos = 3;
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
					tex届け先住所１.Text      = sList[iPos++].TrimEnd();
					tex届け先住所２.Text      = sList[iPos++].TrimEnd();
					tex届け先住所３.Text      = sList[iPos++].TrimEnd();
					tex届け先名前１.Text      = sList[iPos++].TrimEnd();
					tex届け先名前２.Text      = sList[iPos++].TrimEnd();
				}else{
					tex届け先住所１.Text      = sList[iPos++].Trim();
					tex届け先住所２.Text      = sList[iPos++].Trim();
					tex届け先住所３.Text      = sList[iPos++].Trim();
					tex届け先名前１.Text      = sList[iPos++].Trim();
					tex届け先名前２.Text      = sList[iPos++].Trim();
				}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
				tex届け先郵便番号１.Text  = sList[iPos++].Trim();
				tex届け先郵便番号２.Text  = sList[iPos++].Trim();
				tex依頼主コード.Text      = sList[iPos++].Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//				tex依頼主部署.Text        = sList[iPos++].Trim();
				if(gsオプション[18].Equals("1")){
					tex依頼主部署.Text        = sList[iPos++].TrimEnd();
				}else{
					tex依頼主部署.Text        = sList[iPos++].Trim();
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

//				tex輸送名親.Text          = sList[iPos++].Trim();
//				tex輸送名子.Text          = sList[iPos++].Trim();
				tex輸送名親.Text          = sList[iPos++].TrimEnd();
				tex輸送名子.Text          = sList[iPos++].TrimEnd();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//				tex記事名１.Text          = sList[iPos++].Trim();
//				tex記事名２.Text          = sList[iPos++].Trim();
//				tex記事名３.Text          = sList[iPos++].Trim();
				if(gsオプション[18].Equals("1")){
					tex記事名１.Text          = sList[iPos++].TrimEnd();
					tex記事名２.Text          = sList[iPos++].TrimEnd();
					tex記事名３.Text          = sList[iPos++].TrimEnd();
// MOD 2011.07.14 東都）高木 記事行の追加 START
					if(sList.Length > 41){
						tex記事名４.Text      = sList[41].TrimEnd();
						tex記事名５.Text      = sList[42].TrimEnd();
						tex記事名６.Text      = sList[43].TrimEnd();
					}
// MOD 2011.07.14 東都）高木 記事行の追加 END
				}else{
					tex記事名１.Text          = sList[iPos++].Trim();
					tex記事名２.Text          = sList[iPos++].Trim();
					tex記事名３.Text          = sList[iPos++].Trim();
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
//				s更新年月日               = sList[iPos++].Trim();
				iPos++;

				tex依頼主電話番号１.Text  = sList[iPos++].Trim();
				tex依頼主電話番号２.Text  = sList[iPos++].Trim();
				tex依頼主電話番号３.Text  = sList[iPos++].Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
//				tex依頼主住所１.Text      = sList[iPos++].Trim();
//				tex依頼主住所２.Text      = sList[iPos++].Trim();
//				tex依頼主名前１.Text      = sList[iPos++].Trim();
//				tex依頼主名前２.Text      = sList[iPos++].Trim();
				if(gsオプション[18].Equals("1")){
					tex依頼主住所１.Text      = sList[iPos++].TrimEnd();
					tex依頼主住所２.Text      = sList[iPos++].TrimEnd();
					tex依頼主名前１.Text      = sList[iPos++].TrimEnd();
					tex依頼主名前２.Text      = sList[iPos++].TrimEnd();
				}else{
					tex依頼主住所１.Text      = sList[iPos++].Trim();
					tex依頼主住所２.Text      = sList[iPos++].Trim();
					tex依頼主名前１.Text      = sList[iPos++].Trim();
					tex依頼主名前２.Text      = sList[iPos++].Trim();
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
// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 START
//				texメッセージ.Text = "";
// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 END
				s依頼主ＣＤ         = tex依頼主コード.Text;
				s前回検索依頼主ＣＤ = tex依頼主コード.Text;
// MOD 2005.05.12 東都）小童谷 依頼主重量 START
//				d重量 = nUD重量.Value;
//				d重量 = decimal.Parse(sList[36].Trim());
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
// MOD 2009.06.11 東都）高木 ご依頼主情報の重量・才数０対応 END
// MOD 2005.05.12 東都）小童谷 依頼主重量 END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
				}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
			}
		}

		private void btn削除_Click(object sender, System.EventArgs e)
		{			
			DialogResult result = MessageBox.Show("このデータを削除しますか？","削除",MessageBoxButtons.YesNo);
			if(result == DialogResult.Yes)
			{
				string[] sData = new string[6];
				sData[0] = gs会員ＣＤ;
				sData[1] = gs部門ＣＤ;
				sData[2] = s登録日;
				sData[3] = sジャーナルＮＯ;
				sData[4] = "出荷登録";
				sData[5] = gs利用者ＣＤ;
				// カーソルを砂時計にする
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				string[] sDList = {""};
				try
				{
// MOD 2010.11.12 東都）高木 未発行データを削除可能にする START
					if(gs利用者ＣＤ != s登録者ＣＤ){
						Cursor = System.Windows.Forms.Cursors.Default;
						ビープ音();
						texメッセージ.Text = "登録者が違う為削除できませんでした";
						return;
					}
					// 確定データ？（編集不可で出荷日などが範囲外）の時
					if(texメッセージ２.Visible){
						string[] sList = {""};
						texメッセージ.Text = "検索中．．．";
						if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
						sList = sv_syukka.Get_Ssyukka(gsaユーザ
							, gs会員ＣＤ, gs部門ＣＤ, s登録日, int.Parse(sジャーナルＮＯ));
						// エラー時
						if(sList[0].Length != 4){
							Cursor = System.Windows.Forms.Cursors.Default;
							ビープ音();
							texメッセージ.Text = sList[0];
							return;
						}
						string s送り状番号 = sList[43];
						string s状態       = sList[49];
						string s出荷済ＦＧ = sList[50];
// MOD 2011.03.11 東都）高木 ＧＰ送信済（出荷済）データの修正制限の強化 START
						string s印刷済ＦＧ = (sList.Length > 51) ? sList[51] : "";
//						string s送信済ＦＧ = (sList.Length > 52) ? sList[52] : "";
// MOD 2011.03.11 東都）高木 ＧＰ送信済（出荷済）データの修正制限の強化 END
						if(s状態 != "01"){ // [状態]が「未発行」の以外の場合
							Cursor = System.Windows.Forms.Cursors.Default;
							ビープ音();
							texメッセージ.Text = "「未発行」でない為削除できませんでした";
							return;
						}
						// 既に[送り状番号]が採番され、「出荷済」の場合
// MOD 2011.03.11 東都）高木 ＧＰ送信済（出荷済）データの修正制限の強化 START
//						if(s送り状番号.Length > 0 && s出荷済ＦＧ == "1"){
						if((s送り状番号.Length > 0 && s出荷済ＦＧ == "1")
						|| (sList[1].Replace("/","").CompareTo(gs出荷日) <= 0 && s印刷済ＦＧ == "1") ){
// MOD 2011.03.11 東都）高木 ＧＰ送信済（出荷済）データの修正制限の強化 END
							result = MessageBox.Show(
								"既にラベル発行を行っていますが、　\n"
								+ "削除してよろしいですか？　\n"
								, "削除"
								, MessageBoxButtons.YesNo
								, MessageBoxIcon.Warning);
							// [Yes]以外は終了
							if(result != DialogResult.Yes){
								Cursor = System.Windows.Forms.Cursors.Default;
								texメッセージ.Text = "";
								return;
							}
						}
					}
// MOD 2010.11.12 東都）高木 未発行データを削除可能にする END
					texメッセージ.Text = "削除中．．．";
					if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
// MOD 2010.06.18 東都）高木 出荷データの参照・追加・更新・削除ログの追加 START
//					sDList = sv_syukka.Del_syukka(gsaユーザ,sData);
					sDList = sv_syukka.Del_syukka2(gsaユーザ,sData,s登録送り状番号);
// MOD 2010.06.18 東都）高木 出荷データの参照・追加・更新・削除ログの追加 END
				}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
				catch (System.Net.WebException)
				{
					sDList[0] = gs通信エラー;
				}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
				catch (Exception ex)
				{
					sDList[0] = "通信エラー：" + ex.Message;
				}
				// カーソルをデフォルトに戻す
				Cursor = System.Windows.Forms.Cursors.Default;

				// エラー時
				if(sDList[0].Length != 4)
				{
					ビープ音();
					texメッセージ.Text = sDList[0];
				}
				else
					// [正常終了]時、画面をクリアする
					btn取消_Click(sender, e);

			}

		}

		private void btn取消_Click(object sender, System.EventArgs e)
		{
			if(cBox出荷日固定.Checked == false){
// MOD 2009.04.22 東都）高木 日付変換の変更 START
				if(cBox指定日固定.Checked == false)
				{
					dt指定日.MinDate = YYYYMMDD変換("2005/01/01");
					dt指定日.MaxDate = YYYYMMDD変換("2105/12/31");
					dt指定日.Value   = gdt出荷日.AddDays(1);
					dt指定日.MinDate = gdt出荷日;
// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 START
//					dt指定日.MaxDate = gdt出荷日.AddDays(14);
					if(gs部門店所ＣＤ.Equals("047")){
						dt指定日.MaxDate = gdt出荷日.AddDays(90);
					}else{
						dt指定日.MaxDate = gdt出荷日.AddDays(14);
					}
// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 END
				}
// MOD 2009.04.22 東都）高木 日付変換の変更 END
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
				b指定日チェックＭＳＧ有 = false;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
				dt出荷日.Value = gdt出荷日;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
				b指定日チェックＭＳＧ有 = true;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
			}

			届け先項目クリア();
			その他項目クリア();
// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 START
			記事品名固定有効();
			記事品名固定読込();
// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 END

			if(cBox依頼主固定.Checked == false){
				tex依頼主部署.Text         = "";
				tex依頼主コード.Text = gs荷送人ＣＤ;
				s依頼主ＣＤ          = gs荷送人ＣＤ;
			}
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 START
//			if(s依頼主ＣＤ != s前回検索依頼主ＣＤ) 
//			{
//				依頼主項目クリア();
//				tex依頼主コード.Text = s依頼主ＣＤ;
//				if(s依頼主ＣＤ.Length > 0) 依頼主検索(false);
//			}
// MOD 2010.09.30 東都）高木 担当者（依頼主部署）クリア障害対応 START
//			依頼主項目クリア();
			依頼主項目クリア２();
// MOD 2010.09.30 東都）高木 担当者（依頼主部署）クリア障害対応 END
			tex依頼主コード.Text = s依頼主ＣＤ;
			if(s依頼主ＣＤ.Length > 0){
				依頼主検索(false);
			}
// MOD 2010.08.31 東都）高木 現行の請求先情報の表示 END
			tex届け先コード.Focus();
// MOD 2005.05.12 東都）小童谷 初期重量０ START
//			nUD重量.Value = d重量;
// MOD 2005.05.12 東都）小童谷 初期重量０ START

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
// MOD 2006.06.27 東都）山本　郵便番号入力時TAB押下にて住所検索　START
			if((e.KeyCode == Keys.Enter)||(e.KeyCode == Keys.Tab))
//			if(e.KeyCode == Keys.Enter)
// MOD 2006.06.27 東都）山本　郵便番号入力時TAB押下にて住所検索　END
			{
				// 空白除去
				tex届け先郵便番号１.Text = tex届け先郵便番号１.Text.Trim();
				tex届け先郵便番号２.Text = tex届け先郵便番号２.Text.Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//				tex届け先住所１.Text = tex届け先住所１.Text.Trim();
//				tex届け先住所２.Text = tex届け先住所２.Text.Trim();
//				tex届け先住所３.Text = tex届け先住所３.Text.Trim();
				if(gsオプション[18].Equals("1")){
					tex届け先住所１.Text = tex届け先住所１.Text.TrimEnd();
					tex届け先住所２.Text = tex届け先住所２.Text.TrimEnd();
					tex届け先住所３.Text = tex届け先住所３.Text.TrimEnd();
				}else{
					tex届け先住所１.Text = tex届け先住所１.Text.Trim();
					tex届け先住所２.Text = tex届け先住所２.Text.Trim();
					tex届け先住所３.Text = tex届け先住所３.Text.Trim();
				}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
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
// MOD 2007.06.21 東都）高木 郵便番号変更時のカーソル移動の修正 START
					}else{
						if(e.KeyCode == Keys.Tab) tex届け先住所１.Focus();
// MOD 2007.06.21 東都）高木 郵便番号変更時のカーソル移動の修正 END
					}
				}
// MOD 2006.12.14 東都）小童谷　郵便番号入力時TAB押下にて住所検索　START
//				else
				else if(e.KeyCode == Keys.Enter)
// MOD 2006.12.14 東都）小童谷　郵便番号入力時TAB押下にて住所検索　END
				{
					btn住所検索.Focus();
					btn住所検索_Click(sender, e);
				}
// MOD 2007.06.21 東都）高木 郵便番号変更時のカーソル移動の修正 START
				else
				{
					tex届け先住所１.Focus();
				}
// MOD 2007.06.21 東都）高木 郵便番号変更時のカーソル移動の修正 END

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

		private void tex記事コード_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn記事検索_Click(sender,e);
				e.Handled = true;
			}
		}

		private void 出荷登録_Activated(object sender, System.EventArgs e)
		{
			if(iアクティブＦＧ == 0)
			{
				tex届け先コード.Focus();

// ADD 2005.05.11 東都）高木 請求先が存在しない時の対応 START
				iアクティブＦＧ = 1;
// ADD 2005.05.11 東都）高木 請求先が存在しない時の対応 END
				// 更新モード以外（登録）
				// かつ、雛形登録以外
				if(s処理ＦＧ != "U" && i雛型ＮＯ <= 0)
				{
					tex依頼主コード.Text = gs荷送人ＣＤ;
					s依頼主ＣＤ          = gs荷送人ＣＤ;
					if(s依頼主ＣＤ.Length > 0) 依頼主検索(false);

// MOD 2010.10.04 東都）高木 担当者（依頼主部署）フォーカス障害対応 START
//					if(s処理ＦＧ == "U")
//						tex依頼主部署.Focus();
//					else
//						tex届け先コード.Focus();
					tex届け先コード.Focus();
// MOD 2010.10.04 東都）高木 担当者（依頼主部署）フォーカス障害対応 END
				}
			}
// DEL 2005.05.11 東都）高木 請求先が存在しない時の対応 START
//			iアクティブＦＧ = 1;
// DEL 2005.05.11 東都）高木 請求先が存在しない時の対応 END
		}

		private void cBox指定日_Click(object sender, System.EventArgs e)
		{
			if(cBox指定日.Checked == true)
			{
				label3.Visible = false;
// MOD 2006.06.27 東都）山本　指定日を必着に固定　START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
//				label必着.Visible = true;
				cmb指定日区分.Visible = true;
// MOD 2008.11.14 東都）高木 指定日区分の復活 END
// MOD 2006.06.27 東都）山本　指定日を必着に固定　END
				cBox指定日固定.Visible = true;
			}
			else
			{
				label3.Visible = true;
// MOD 2006.06.27 東都）山本　指定日を必着に固定　START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
//				label必着.Visible = false;
				cmb指定日区分.Visible = false;
// MOD 2008.11.14 東都）高木 指定日区分の復活 END
// MOD 2006.06.27 東都）山本　指定日を必着に固定　END
				cBox指定日固定.Visible = false;
			}
		}

		private void dt指定日_DropDown(object sender, System.EventArgs e)
		{
			label3.Visible = false;
// MOD 2006.06.27 東都）山本　指定日を必着に固定　START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
//			label必着.Visible = true;
			cmb指定日区分.Visible = true;
// MOD 2008.11.14 東都）高木 指定日区分の復活 END
// MOD 2006.06.27 東都）山本　指定日を必着に固定　END
			cBox指定日固定.Visible = true;
			cBox指定日.Checked = true;
		}

		private void dt指定日_CloseUp(object sender, System.EventArgs e)
		{
			tex輸送コード親.Focus();
		}

// ADD 2005.05.24 東都）小童谷 フォーカス移動 START
		private void 出荷登録_Closed(object sender, System.EventArgs e)
		{
			cBox出荷日固定.Checked = false;
			cBox依頼主固定.Checked = false;
// MOD 2009.10.05 パソ）藤井　記事・品名／個数の行別固定機能の追加 START
// ADD 2009.09.01 パソ）藤井 記事・品名／個数の固定機能の追加 START
//			cBox記事品名固定.Checked = false;
			cBox個数固定.Checked = false;
// ADD 2009.09.01 パソ）藤井 記事・品名／個数の固定機能の追加 END
			cBox記事品名固定１.Checked = false;
			cBox記事品名固定２.Checked = false;
			cBox記事品名固定３.Checked = false;
// MOD 2009.10.05 パソ）藤井　記事・品名／個数の行別固定機能の追加 END
// MOD 2011.07.14 東都）高木 記事行の追加 START
			cBox記事品名固定４.Checked = false;
			cBox記事品名固定５.Checked = false;
			cBox記事品名固定６.Checked = false;
// MOD 2011.07.14 東都）高木 記事行の追加 END
			届け先項目クリア();
			依頼主項目クリア();
			その他項目クリア();
		}
// ADD 2005.05.24 東都）小童谷 フォーカス移動 END
// ADD 2009.04.02 東都）高木 稼働日対応 START
		private void dt出荷日_ValueChanged(object sender, System.EventArgs e)
		{
			出荷日チェック();
		}
		private bool 出荷日チェック()
		{
			try
			{
				//指定日の範囲の変更
				//最小値：出荷日、最大値：出荷日＋１４日 or ９０日
// MOD 2009.12.08 東都）高木 指定日の上限障害（上記のグローバル対応の障害）START
//// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 START
////				dt指定日最大値 = dt出荷日.Value.AddDays(14);
//				if(gs部門店所ＣＤ.Equals("047")){
//					dt指定日最大値 = gdt出荷日.AddDays(90);
//				}else{
//					dt指定日最大値 = gdt出荷日.AddDays(14);
//				}
//// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 END
				if(gs部門店所ＣＤ.Equals("047")){
					dt指定日最大値 = dt出荷日.Value.AddDays(90);
				}else{
					dt指定日最大値 = dt出荷日.Value.AddDays(14);
				}
// MOD 2009.12.08 東都）高木 指定日の上限障害（上記のグローバル対応の障害）END
// MOD 2016.04.13 BEVAS）松本 配達指定日上限の拡張 START
				//セリア様の場合、配達指定日の上限を180日にまで拡張
				if(gs会員ＣＤ.Equals(gs指定日上限拡張会員ＣＤ))
				{
					dt指定日最大値 = dt出荷日.Value.AddDays(180);
				}
// MOD 2016.04.13 BEVAS）松本 配達指定日上限の拡張 END
				dt指定日最小値 = dt出荷日.Value;

				//[指定日]のチェックが入っていない時
				if(cBox指定日.Checked == false){
					dt指定日.MaxDate = YYYYMMDD変換("2105/12/31");
					dt指定日.MinDate = YYYYMMDD変換("2005/01/01");
					dt指定日.Value   = dt出荷日.Value.AddDays(1);
					dt指定日.MaxDate = dt指定日最大値;
					dt指定日.MinDate = dt指定日最小値;
					return true;
				}

				//以下は[指定日]のチェックが入っている時

				if(dt指定日.Value < dt指定日最小値){
					dt指定日.MaxDate = dt指定日最大値;
					dt指定日.MinDate = dt指定日.Value;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
					if(b指定日チェックＭＳＧ有){
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
						//エラーメッセージ表示後、フォーカス移動
						MessageBox.Show("配達指定日は出荷日以降を入力してください\n"
										+ "（" 
										+ dt指定日最小値.Month + "月"
										+ dt指定日最小値.Day   + "日 ～ "
										+ dt指定日最大値.Month + "月"
										+ dt指定日最大値.Day   + "日）"
										,"入力チェック"
										,MessageBoxButtons.OK);
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
					}
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
					dt指定日.Refresh();
					dt指定日.Focus();
					return false;
				}else if(dt指定日.Value > dt指定日最大値){
					dt指定日.MaxDate = dt指定日.Value;
					dt指定日.MinDate = dt指定日最小値;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
					if(b指定日チェックＭＳＧ有){
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
						//エラーメッセージ表示後、フォーカス移動
						MessageBox.Show("配達指定日を変更してください\n"
										+ "（" 
										+ dt指定日最小値.Month + "月"
										+ dt指定日最小値.Day   + "日 ～ "
										+ dt指定日最大値.Month + "月"
										+ dt指定日最大値.Day   + "日）"
										,"入力チェック"
										,MessageBoxButtons.OK);
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
					}
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
					dt指定日.Refresh();
					dt指定日.Focus();
					return false;
				}else{
					dt指定日.MaxDate = dt指定日最大値;
					dt指定日.MinDate = dt指定日最小値;
				}
			}
			catch (Exception)
			{
				;
				return false;
			}
			return true;
		}

// MOD 2009.10.05 パソ）藤井　記事・品名／個数の行別固定機能の追加 START
		private void btn記事品名固定_Click(object sender, System.EventArgs e)
		{
// MOD 2009.10.16 東都）高木 記事・品名固定チェック解除機能の追加 START
			if(cBox記事品名固定１.Checked
			&& cBox記事品名固定２.Checked
// MOD 2011.07.14 東都）高木 記事行の追加 START
//			&& cBox記事品名固定３.Checked){
			&& cBox記事品名固定３.Checked
			&& cBox記事品名固定４.Checked
			&& cBox記事品名固定５.Checked
			&& cBox記事品名固定６.Checked
			){
// MOD 2011.07.14 東都）高木 記事行の追加 END
				cBox記事品名固定１.Checked = false;
				cBox記事品名固定２.Checked = false;
				cBox記事品名固定３.Checked = false;
// MOD 2011.07.14 東都）高木 記事行の追加 START
				cBox記事品名固定４.Checked = false;
				cBox記事品名固定５.Checked = false;
				cBox記事品名固定６.Checked = false;
// MOD 2011.07.14 東都）高木 記事行の追加 END
				//tex記事コード.Focus();
			}else{
// MOD 2009.10.16 東都）高木 記事・品名固定チェック解除機能の追加 END
				cBox記事品名固定１.Checked = true;
				cBox記事品名固定２.Checked = true;
				cBox記事品名固定３.Checked = true;
// MOD 2011.07.14 東都）高木 記事行の追加 START
				cBox記事品名固定４.Checked = true;
				cBox記事品名固定５.Checked = true;
				cBox記事品名固定６.Checked = true;
// MOD 2011.07.14 東都）高木 記事行の追加 END
				//tex記事コード.Focus();
// MOD 2009.10.16 東都）高木 記事・品名固定チェック解除機能の追加 START
			}
// MOD 2009.10.16 東都）高木 記事・品名固定チェック解除機能の追加 END
		}
// MOD 2009.10.05 パソ）藤井　記事・品名／個数の行別固定機能の追加 END

// ADD 2009.04.02 東都）高木 稼働日対応 END
// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 START
		private void 記事品名固定有効()
		{
			btn記事品名固定.Visible    = true;
			cBox記事品名固定１.Visible = true;
			cBox記事品名固定２.Visible = true;
			cBox記事品名固定３.Visible = true;
// MOD 2011.07.14 東都）高木 記事行の追加 START
			cBox記事品名固定４.Visible = true;
			cBox記事品名固定５.Visible = true;
			cBox記事品名固定６.Visible = true;
// MOD 2011.07.14 東都）高木 記事行の追加 END
		}
		private void 記事品名固定無効()
		{
			btn記事品名固定.Visible    = false;
			cBox記事品名固定１.Visible = false;
			cBox記事品名固定２.Visible = false;
			cBox記事品名固定３.Visible = false;
// MOD 2011.07.14 東都）高木 記事行の追加 START
			cBox記事品名固定４.Visible = false;
			cBox記事品名固定５.Visible = false;
			cBox記事品名固定６.Visible = false;
// MOD 2011.07.14 東都）高木 記事行の追加 END
		}
		private void 記事品名固定読込()
		{
			if(sa記事品名固定 == null){
// MOD 2011.07.14 東都）高木 記事行の追加 START
//				sa記事品名固定 = new string[]{"","","","","",""};
				sa記事品名固定 = new string[]{
					"","","","","",""
					, "","","","","",""
				};
// MOD 2011.07.14 東都）高木 記事行の追加 END

				StreamReader srp = null;
				try
				{
					srp = File.OpenText(gsInitKiji);
					for(int iCnt = 0; iCnt < sa記事品名固定.Length; iCnt++){
						sa記事品名固定[iCnt] = srp.ReadLine();
					}
				}
				catch(Exception)
				{
					;
				}
				finally
				{
					if(srp != null) srp.Close();
				}
			}

			if(sa記事品名固定[0] == "1"){
				cBox記事品名固定１.Checked = true;
				tex記事名１.Text = sa記事品名固定[1];
			}
			if(sa記事品名固定[2] == "1"){
				cBox記事品名固定２.Checked = true;
				tex記事名２.Text = sa記事品名固定[3];
			}
			if(sa記事品名固定[4] == "1"){
				cBox記事品名固定３.Checked = true;
				tex記事名３.Text = sa記事品名固定[5];
			}
// MOD 2011.07.14 東都）高木 記事行の追加 START
			if(sa記事品名固定[6] == "1"){
				cBox記事品名固定４.Checked = true;
				tex記事名４.Text = sa記事品名固定[7];
			}
			if(sa記事品名固定[8] == "1"){
				cBox記事品名固定５.Checked = true;
				tex記事名５.Text = sa記事品名固定[9];
			}
			if(sa記事品名固定[10] == "1"){
				cBox記事品名固定６.Checked = true;
				tex記事名６.Text = sa記事品名固定[11];
			}
// MOD 2011.07.14 東都）高木 記事行の追加 END
		}
		private void 記事品名固定書込()
		{
// MOD 2011.07.14 東都）高木 記事行の追加 START
//			sa記事品名固定 = new string[]{"","","","","",""};
			sa記事品名固定 = new string[]{
				"","","","","",""
				, "","","","","",""
			};
// MOD 2011.07.14 東都）高木 記事行の追加 END

			if(cBox記事品名固定１.Checked){
				sa記事品名固定[0] = "1";
				sa記事品名固定[1] = tex記事名１.Text.TrimEnd();
			}
			if(cBox記事品名固定２.Checked){
				sa記事品名固定[2] = "1";
				sa記事品名固定[3] = tex記事名２.Text.TrimEnd();
			}
			if(cBox記事品名固定３.Checked){
				sa記事品名固定[4] = "1";
				sa記事品名固定[5] = tex記事名３.Text.TrimEnd();
			}
// MOD 2011.07.14 東都）高木 記事行の追加 START
			if(cBox記事品名固定４.Checked){
				sa記事品名固定[6] = "1";
				sa記事品名固定[7] = tex記事名４.Text.TrimEnd();
			}
			if(cBox記事品名固定５.Checked){
				sa記事品名固定[8] = "1";
				sa記事品名固定[9] = tex記事名５.Text.TrimEnd();
			}
			if(cBox記事品名固定６.Checked){
				sa記事品名固定[10] = "1";
				sa記事品名固定[11] = tex記事名６.Text.TrimEnd();
			}
// MOD 2011.07.14 東都）高木 記事行の追加 END

			StreamWriter swp = null;
			try
			{
				swp = File.CreateText(gsInitKiji);
				for(int iCnt = 0; iCnt < sa記事品名固定.Length; iCnt++){
					swp.WriteLine(sa記事品名固定[iCnt]);
				}
			}
			catch(Exception)
			{
				;
			}
			finally
			{
				if(swp != null) swp.Close();
			}
		}

// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 END
// MOD 2015.07.13 TDI）綱澤 バーコード読取専用画面追加 START
		private bool グローバルチェック１()
		{
// MOD 2016.03.24 BEVAS）松本 王子運送版グローバル運用対応 START
//			if (gs会員ＣＤ.Substring(0,2).ToUpper() == "GL")
			if(gs部門店所ＣＤ.Equals("047"))
// MOD 2016.03.24 BEVAS）松本 王子運送版グローバル運用対応 END
			{
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
				//特定グローバル荷主か確認する。
				saグローバルチェック = sv_syukka.Get_GlobalCount(gsaユーザ);
				if (saグローバルチェック[0] != "正常終了") return false;
				if (saグローバルチェック[1] != "1") return false;
			}
			else
			{
				//グローバル荷主でない
				return false;
			}

			return true;
		}
// MOD 2015.07.13 TDI）綱澤 バーコード読取専用画面追加 END
// MOD 2015.07.13 TDI）綱澤 バーコード読取専用画面追加 START
		private bool グローバルチェック２(string 送り状番号)
		{
// MOD 2016.03.24 BEVAS）松本 王子運送版グローバル運用対応 START
//			if (gs会員ＣＤ.Substring(0,2).ToUpper() == "GL")
			if(gs部門店所ＣＤ.Equals("047"))
// MOD 2016.03.24 BEVAS）松本 王子運送版グローバル運用対応 END
			{
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
				//集荷済でないかチェックする
				saグローバルチェック = sv_syukka.Get_ModifiableSyukkaCount(gsaユーザ,送り状番号);
				if (saグローバルチェック[0] != "正常終了") return false;
				if (saグローバルチェック[1] != "1") return false;
			}
			else
			{
				//グローバル荷主でない
				return false;
			}

			return true;
		}
// MOD 2015.07.13 TDI）綱澤 バーコード読取専用画面追加 END
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
