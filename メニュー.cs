using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Xml;
using System.Net;
using System.Text;
using System.Security.Cryptography;

using IS2Client;

namespace IS2Client
{
	/// <summary>
	/// [Home]（メニュー）
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// MOD 2008.01.30 KCL) 森本 表示スピード変更 
	// MOD 2008.02.08 KCL) 森本 お知らせ修正 
	// MOD 2008.02.13 東都）高木 ヘルプの細分化対応 
	// ADD 2008.03.13 東都）高木 Vista対応 
	// ADD 2008.04.11 ACT Vista対応 
	// MOD 2008.05.20 東都）高木 [wis2.dll]のフォルダの変更
	// ADD 2008.06.17 東都）高木 ディレクトリ存在チェックの追加 
	//--------------------------------------------------------------------------
	// ADD 2009.04.02 東都）高木 稼働日対応 
	// MOD 2009.05.01 東都）高木 オプションの項目追加 
	// ADD 2009.07.29 東都）高木 プロキシ対応 
	// 　ＩＥの[Secure]の設定からも取得する
	// 　プロキシをユーザが設定できるようにする
	// MOD 2009.07.30 東都）高木 exeのdll化対応 
	// MOD 2009.10.14 東都）高木 config読込など 
	// MOD 2009.10.16 東都）高木 プロキシ機能表記の追加 
	// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 
	// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 
	//--------------------------------------------------------------------------
	// MOD 2010.01.15 東都）高木 エラーメッセージのクリア 
	// MOD 2010.02.04 東都）高木 出荷実績画面のセンタリング 
	// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 
	// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 
	// MOD 2010.04.16 東都）高木 モジュール再ダウンロード 
	// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 
	// MOD 2010.05.24 東都）高木 120DPI対応時の表示位置調整 
	// MOD 2010.04.21 東都）高木 ハング近似動作の防止 
	// MOD 2010.05.25 東都）高木 メッセージのスレッド化 
	// MOD 2010.05.25 東都）高木 時間指定の変更 
	// MOD 2010.06.01 東都）高木 自動出力ボタンの移動 
	// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 
	// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） 
	// MOD 2010.07.30 東都）高木 デフォルトプロキシ設定の修正 
	// MOD 2010.08.27 東都）高木 ご依頼主取込（ＣＳＶ）機能追加 
	// MOD 2010.09.03 東都）高木 ＣＳＶエントリー時の請求先エラー表記修正 
	// MOD 2010.10.01 東都）高木 お客様番号１６桁化 
	// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 
	// MOD 2010.11.02 東都）高木 数値範囲チェックの変更 
	// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) 
	// ADD 2010.12.14 ACT）垣原 王子運送の対応 
	//--------------------------------------------------------------------------
	// MOD 2011.01.11 東都）高木 王子運送の対応 
	// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない 
	// MOD 2011.02.03 東都）高木 SATO製プリンタ清掃マニュアル追加 
	// MOD 2011.03.08 東都）高木 王子運送対応（メニュー画面の切替） 
	// MOD 2011.04.05 東都）高木 画面イメージのロード変更 
	// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 
	// MOD 2011.06.07 東都）高木 王子運送の対応 
	// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 
	// MOD 2011.07.14 東都）高木 記事行の追加 
	// MOD 2011.07.28 東都）高木 記事行の追加（文字数制限の追加） 
	// MOD 2011.08.03 東都）高木 終了時に自動出力が無効になる障害対応 
	// MOD 2011.08.11 東都）高木 記事行の追加（登録日付省略時障害対応） 
	// MOD 2011.09.05 東都）高木 出荷日の上限をＣＳＶエントリーと同様にする 
	// MOD 2011.10.11 東都）高木 ＳＳＬ証明書導入状態などのチェック 
	// MOD 2011.12.06 東都）高木 プロキシ認証の追加 
	//--------------------------------------------------------------------------
	// MOD 2012.09.26 COA)横山 日付項目取込強化
	//                         （月日にスペースを含む場合，スペースをゼロに変換して取込）
	//--------------------------------------------------------------------------
	// ADD 2013.02.15 TDI)綱澤 グローバル出荷日制限拡張対応(14日⇒62日)
	//--------------------------------------------------------------------------
	// MOD 2015.04.13 BEVAS) 前田 自動出力タイマー (秒単位指定対応)
	// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加
	// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加
	//--------------------------------------------------------------------------
	// MOD 2016.01.15 BEVAS) 松本 WinXP非対応に伴う該当端末への注意文表示対応
	// MOD 2016.01.21 BEVAS) 松本 お知らせボタンの色切替え改修
	//                            （表題の先頭に「【重要】」が付くものはボタンの色を変える）
	// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加
	// MOD 2016.04.13 BEVAS）松本 配達指定日上限の拡張
	// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応
	// MOD 2016.05.24 BEVAS）松本 セクション切替画面改修対応
	// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存
    //--------------------------------------------------------------------------
    // MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更
    //--------------------------------------------------------------------------
	public class メニュー : 共通フォーム
	{
// MOD 2009.07.30 東都）高木 exeのdll化対応 START
//		private static System.Threading.Mutex mutex;
// MOD 2009.07.30 東都）高木 exeのdll化対応 END
// DEL 2005.05.27 東都）高木 スレッド位置の移動 START
//		private Image[,]  imageMenu = null;
//		private Image[,,] imageCmd  = null;
// DEL 2005.05.27 東都）高木 スレッド位置の移動 END
		private bool bメッセージ更新中 = false;
		private int iメッセージ更新ＣＮＴ = 0;
		private int iメッセージ表示位置 = 0;
		private int iメッセージＣＮＴ = 0;
		private System.Windows.Forms.Timer timメッセージ;
		private int i終了ＦＧ = 0;
// MOD 2005.05.27 東都）高木 スレッド位置の移動 START
//// ADD 2005.05.20 東都）西口 スレッド化 START
//		private Thread trd = null;
//// ADD 2005.05.20 東都）西口 スレッド化 END
		private static Image[,]  imageMenu = null;
		private static Image[,,] imageCmd  = null;
		private static Thread trd = null;
// MOD 2005.05.27 東都）高木 スレッド位置の移動 END
// ADD 2005.05.25 東都）高木 ヘルプＵＲＬをconfigから取得 START
		private string sヘルプＵＲＬ = "http://wwwis2.fukutsu.co.jp/is2/manual/is2manual.pdf";
// ADD 2005.05.25 東都）高木 ヘルプＵＲＬをconfigから取得 END
// MOD 2007.11.29 東都）高木 ログイン時のフォーカス障害対応 START
		private static 初期登録 F初期登録 = null;
		private static ログイン Fログイン = null;
// MOD 2007.11.29 東都）高木 ログイン時のフォーカス障害対応 END
// MOD 2009.10.14 東都）高木 config読込など START
		private static string sUrl_address  = "";
		private static string sUrl_goirai   = "";
		private static string sUrl_hinagata = "";
		private static string sUrl_init     = "";
		private static string sUrl_kiji     = "";
		private static string sUrl_otodoke  = "";
		private static string sUrl_print    = "";
		private static string sUrl_syukka   = "";
		private static string sUrl_seikyuu  = "";
		private static string sUrl_oshirase = "";
// MOD 2009.10.14 東都）高木 config読込など END
// MOD 2011.01.11 東都）高木 王子運送の対応 START
		private static string sUrl_oji      = "";
// MOD 2011.01.11 東都）高木 王子運送の対応 END
// MOD 2008.02.08 KCL) 森本 お知らせ修正 START
		private お知らせ表題ボタン [] btnList = new お知らせ表題ボタン [5];
// MOD 2008.02.08 KCL) 森本 お知らせ修正 END
// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
		private string [][] sお知らせ一覧 = null;
// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
// MOD 2009.11.25 東都）高木 時間指定チェックの追加 START
		private string[] sa時間指定チェック = {
			"１０","１１","１２","１３","１４",
			"１５","１６","１７","１８","１９",
// MOD 2010.05.25 東都）高木 時間指定の変更 START
//			"２０","２１"
			"２０"
// MOD 2010.05.25 東都）高木 時間指定の変更 END
		};
// MOD 2009.11.25 東都）高木 時間指定チェックの追加 END
// MOD 2011.07.14 東都）高木 記事行の追加 START
		private int iＣＳＶエントリー形式 = 1;
		private enum 形式１ {
			荷受人ＣＤ, 電話番号, 住所, 住所２, 住所３
			, 名前, 名前２, 郵便番号, 特殊計, 着店ＣＤ
			, 荷送人ＣＤ, 個数, 才数, 重量, 輸送商品１
			, 輸送商品２, 品名記事１, 品名記事２, 品名記事３, 配達指定日
			, お客様管理番号, 予備, 元払区分, 保険金額, 出荷日付
			, 登録日付
		};
		private enum 形式２ {
			荷受人ＣＤ, 電話番号, 住所, 住所２, 住所３
			, 名前, 名前２, 郵便番号, 特殊計, 着店ＣＤ
			, 荷送人ＣＤ, 荷送担当者, 個数, 才数, 重量
			, 輸送商品１, 輸送商品２, 品名記事１, 品名記事２, 品名記事３
			, 品名記事４, 品名記事５, 品名記事６, 配達指定日, 必着区分
			, お客様管理番号, 元払区分, 保険金額, 出荷日付, 登録日付
		};
// MOD 2011.07.14 東都）高木 記事行の追加 END

// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 START
		private System.Windows.Forms.Timer tim出荷ＣＳＶ自動出力;
		private static Encoding enc = Encoding.GetEncoding("shift-jis");
// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 END
// MOD 2010.04.21 東都）高木 ハング近似動作の防止 START
		private string[]    sFiles1;
		private DateTime[] dtFiles1;
		private long[]     lsFiles1;
		public  Thread     trd1 = null;
// MOD 2010.04.21 東都）高木 ハング近似動作の防止 END
// MOD 2010.05.25 東都）高木 メッセージのスレッド化 START
		public  Thread     trdMsg = null;
// MOD 2010.05.25 東都）高木 メッセージのスレッド化 END
// MOD 2011.10.11 東都）高木 ＳＳＬ証明書導入状態などのチェック START
		public static Thread  trdSSLTest = null;
// MOD 2011.10.11 東都）高木 ＳＳＬ証明書導入状態などのチェック END

		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab日時;
		private System.Windows.Forms.Button btnパスワード変更;
		private System.Windows.Forms.Button btn終了;
		private System.Windows.Forms.TextBox tex部門名;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.Button btn部門変更;
		private System.Windows.Forms.PictureBox pic出荷照会;
		private System.Windows.Forms.PictureBox pic請求先登録;
		private System.Windows.Forms.PictureBox pic端末情報;
		private System.Windows.Forms.PictureBox pic記事情報;
		private System.Windows.Forms.PictureBox picご依頼主情報;
		private System.Windows.Forms.PictureBox picご依頼主取込;
		private System.Windows.Forms.PictureBox picお届け先情報;
		private System.Windows.Forms.PictureBox picメニュー４;
		private System.Windows.Forms.PictureBox picメニュー３;
		private System.Windows.Forms.PictureBox picメニュー２;
		private System.Windows.Forms.PictureBox picメニュー１;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pic送り状荷札発行;
		private System.Windows.Forms.PictureBox pic雛型出荷登録;
		private System.Windows.Forms.PictureBox pic自動出荷登録;
		private System.Windows.Forms.PictureBox pictureBox7;
		private System.Windows.Forms.PictureBox pic出荷登録;
		private System.Windows.Forms.PictureBox picお届先取込;
		private System.Windows.Forms.Panel panメイン;
		private System.Windows.Forms.Panel panメニュー１;
		private System.Windows.Forms.Panel panメニュー２;
		private System.Windows.Forms.Panel panメニュー３;
		private System.Windows.Forms.Panel panメニュー４;
		private System.Drawing.Printing.PrintDocument is2PrintDocument;
		private System.Windows.Forms.Label labメッセージ;
		private System.Windows.Forms.PictureBox picチョイスプリント;
		private System.Windows.Forms.PictureBox pic再発行;
		private System.Windows.Forms.Button btnヘルプ;
		private System.Windows.Forms.PictureBox pic才数切替;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tex会員名;
		private System.Windows.Forms.PictureBox pic出荷実績;
		private System.Windows.Forms.Label labメッセージ裏;
		private System.Windows.Forms.PictureBox picホーム;
		private System.Windows.Forms.Label labバージョン;
		private System.Windows.Forms.PictureBox picメニュー６;
		private System.Windows.Forms.Panel panメニュー６;
		private IS2Client.お知らせ表題ボタン btnお知らせ１;
		private IS2Client.お知らせ表題ボタン btnお知らせ２;
		private IS2Client.お知らせ表題ボタン btnお知らせ３;
		private IS2Client.お知らせ表題ボタン btnお知らせ４;
		private IS2Client.お知らせ表題ボタン btnお知らせ５;
		private System.Windows.Forms.Label lab自動出力ＯＮ;
		private System.Windows.Forms.Button btn自動出力フォルダ;
		private System.Windows.Forms.Button btn自動出力;
		private System.Windows.Forms.Label lbl王子運送;
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 START
		private System.Windows.Forms.PictureBox picバーコード読取;
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 END
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 START
		private System.Windows.Forms.PictureBox picラベルイメージ印刷;
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 END
		private System.ComponentModel.IContainer components;

		public メニュー()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
			ＤＰＩ表示サイズ変換();
			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
				this.pictureBox7.Size = new System.Drawing.Size(162, 418);
				this.picメニュー１.Size = new System.Drawing.Size(128, 33);
				this.picメニュー２.Size = new System.Drawing.Size(128, 33);
				this.picメニュー３.Size = new System.Drawing.Size(128, 33);
				this.picメニュー４.Size = new System.Drawing.Size(128, 33);
				this.picメニュー６.Size = new System.Drawing.Size(128, 33);
// MOD 2010.05.24 東都）高木 120DPI対応時の表示位置調整 START
//				this.Top  = 0;
//				this.Left = 0;
//				this.Left = 15;
//				this.Left = (SystemInformation.WorkingArea.Width
//								- this.Width) / 2;
				//参考値：System.Drawing.Size(800, 607);
				this.Top  = (SystemInformation.WorkingArea.Height
								- ＤＰＩサイズ位置調整(607, giDisplayDpiY)) / 2;
				this.Left = (SystemInformation.WorkingArea.Width
								- ＤＰＩサイズ位置調整(800, giDisplayDpiX)) / 2;
				this.Top  = ＤＰＩサイズ位置調整(this.Top, giDisplayDpiY);
				this.Left = ＤＰＩサイズ位置調整(this.Left, giDisplayDpiX);
// MOD 2010.05.24 東都）高木 120DPI対応時の表示位置調整 END
			}
// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 END
// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
			// 初期設定
			this.お知らせ初期設定();
// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
		}

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );

// MOD 2009.07.30 東都）高木 exeのdll化対応 START
//			// ミューテックスの破棄
//			mutex.Close();
// MOD 2009.07.30 東都）高木 exeのdll化対応 END
		}

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(メニュー));
			this.panel7 = new System.Windows.Forms.Panel();
			this.picホーム = new System.Windows.Forms.PictureBox();
			this.lab日時 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.tex会員名 = new System.Windows.Forms.TextBox();
			this.panel6 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.btnヘルプ = new System.Windows.Forms.Button();
			this.tex部門名 = new System.Windows.Forms.TextBox();
			this.btn部門変更 = new System.Windows.Forms.Button();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn自動出力フォルダ = new System.Windows.Forms.Button();
			this.btn自動出力 = new System.Windows.Forms.Button();
			this.btnパスワード変更 = new System.Windows.Forms.Button();
			this.texメッセージ = new System.Windows.Forms.TextBox();
			this.btn終了 = new System.Windows.Forms.Button();
			this.lab自動出力ＯＮ = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.picお届け先情報 = new System.Windows.Forms.PictureBox();
			this.picご依頼主情報 = new System.Windows.Forms.PictureBox();
			this.picご依頼主取込 = new System.Windows.Forms.PictureBox();
			this.pic記事情報 = new System.Windows.Forms.PictureBox();
			this.pic端末情報 = new System.Windows.Forms.PictureBox();
			this.pic請求先登録 = new System.Windows.Forms.PictureBox();
			this.pic出荷照会 = new System.Windows.Forms.PictureBox();
			this.panメイン = new System.Windows.Forms.Panel();
			this.lbl王子運送 = new System.Windows.Forms.Label();
			this.panメニュー６ = new System.Windows.Forms.Panel();
			this.btnお知らせ１ = new IS2Client.お知らせ表題ボタン();
			this.btnお知らせ５ = new IS2Client.お知らせ表題ボタン();
			this.btnお知らせ４ = new IS2Client.お知らせ表題ボタン();
			this.btnお知らせ３ = new IS2Client.お知らせ表題ボタン();
			this.btnお知らせ２ = new IS2Client.お知らせ表題ボタン();
			this.picメニュー６ = new System.Windows.Forms.PictureBox();
			this.labバージョン = new System.Windows.Forms.Label();
			this.picメニュー４ = new System.Windows.Forms.PictureBox();
			this.picメニュー３ = new System.Windows.Forms.PictureBox();
			this.picメニュー２ = new System.Windows.Forms.PictureBox();
			this.picメニュー１ = new System.Windows.Forms.PictureBox();
			this.panメニュー４ = new System.Windows.Forms.Panel();
			this.pic才数切替 = new System.Windows.Forms.PictureBox();
			this.panメニュー３ = new System.Windows.Forms.Panel();
			this.picお届先取込 = new System.Windows.Forms.PictureBox();
			this.panメニュー１ = new System.Windows.Forms.Panel();
			this.picチョイスプリント = new System.Windows.Forms.PictureBox();
			this.pic送り状荷札発行 = new System.Windows.Forms.PictureBox();
			this.pic雛型出荷登録 = new System.Windows.Forms.PictureBox();
			this.pic出荷登録 = new System.Windows.Forms.PictureBox();
			this.pic自動出荷登録 = new System.Windows.Forms.PictureBox();
			this.panメニュー２ = new System.Windows.Forms.Panel();
			this.pic出荷実績 = new System.Windows.Forms.PictureBox();
			this.pic再発行 = new System.Windows.Forms.PictureBox();
			this.picバーコード読取 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox7 = new System.Windows.Forms.PictureBox();
			this.labメッセージ = new System.Windows.Forms.Label();
			this.labメッセージ裏 = new System.Windows.Forms.Label();
			this.is2PrintDocument = new System.Drawing.Printing.PrintDocument();
			this.picラベルイメージ印刷 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).BeginInit();
			this.panel7.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panメイン.SuspendLayout();
			this.panメニュー６.SuspendLayout();
			this.panメニュー４.SuspendLayout();
			this.panメニュー３.SuspendLayout();
			this.panメニュー１.SuspendLayout();
			this.panメニュー２.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.panel7.Controls.Add(this.picホーム);
			this.panel7.Controls.Add(this.lab日時);
			this.panel7.Controls.Add(this.label29);
			this.panel7.Controls.Add(this.tex会員名);
			this.panel7.Location = new System.Drawing.Point(0, -2);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(792, 26);
			this.panel7.TabIndex = 15;
			// 
			// picホーム
			// 
			this.picホーム.Image = ((System.Drawing.Image)(resources.GetObject("picホーム.Image")));
			this.picホーム.Location = new System.Drawing.Point(8, 4);
			this.picホーム.Name = "picホーム";
			this.picホーム.Size = new System.Drawing.Size(22, 22);
			this.picホーム.TabIndex = 2;
			this.picホーム.TabStop = false;
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
			// label29
			// 
			this.label29.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label29.Font = new System.Drawing.Font("MS UI Gothic", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label29.ForeColor = System.Drawing.Color.White;
			this.label29.Location = new System.Drawing.Point(32, 6);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(76, 24);
			this.label29.TabIndex = 0;
			this.label29.Text = "Home";
			// 
			// tex会員名
			// 
			this.tex会員名.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.tex会員名.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex会員名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex会員名.ForeColor = System.Drawing.Color.SeaGreen;
			this.tex会員名.Location = new System.Drawing.Point(118, 8);
			this.tex会員名.Name = "tex会員名";
			this.tex会員名.ReadOnly = true;
			this.tex会員名.Size = new System.Drawing.Size(536, 16);
			this.tex会員名.TabIndex = 13;
			this.tex会員名.TabStop = false;
			this.tex会員名.Text = "王国王国王国王国王国王王王王王国国国国国";
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.PaleGreen;
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.btnヘルプ);
			this.panel6.Controls.Add(this.tex部門名);
			this.panel6.Controls.Add(this.btn部門変更);
			this.panel6.Location = new System.Drawing.Point(-2, 24);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(810, 26);
			this.panel6.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label1.ForeColor = System.Drawing.Color.LimeGreen;
			this.label1.Location = new System.Drawing.Point(12, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 16);
			this.label1.TabIndex = 12;
			this.label1.Text = "セクション";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnヘルプ
			// 
			this.btnヘルプ.BackColor = System.Drawing.Color.SteelBlue;
			this.btnヘルプ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnヘルプ.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btnヘルプ.ForeColor = System.Drawing.Color.White;
			this.btnヘルプ.Location = new System.Drawing.Point(714, 2);
			this.btnヘルプ.Name = "btnヘルプ";
			this.btnヘルプ.Size = new System.Drawing.Size(70, 22);
			this.btnヘルプ.TabIndex = 11;
			this.btnヘルプ.Text = "ヘルプ";
			this.btnヘルプ.Click += new System.EventHandler(this.btnヘルプ_Click);
			// 
			// tex部門名
			// 
			this.tex部門名.BackColor = System.Drawing.Color.PaleGreen;
			this.tex部門名.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex部門名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex部門名.ForeColor = System.Drawing.Color.LimeGreen;
			this.tex部門名.Location = new System.Drawing.Point(74, 6);
			this.tex部門名.Name = "tex部門名";
			this.tex部門名.ReadOnly = true;
			this.tex部門名.Size = new System.Drawing.Size(540, 16);
			this.tex部門名.TabIndex = 8;
			this.tex部門名.TabStop = false;
			this.tex部門名.Text = "王国王国王国王国王国";
			// 
			// btn部門変更
			// 
			this.btn部門変更.BackColor = System.Drawing.Color.SteelBlue;
			this.btn部門変更.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn部門変更.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn部門変更.ForeColor = System.Drawing.Color.White;
			this.btn部門変更.Location = new System.Drawing.Point(626, 2);
			this.btn部門変更.Name = "btn部門変更";
			this.btn部門変更.Size = new System.Drawing.Size(84, 22);
			this.btn部門変更.TabIndex = 9;
			this.btn部門変更.Text = "セクション変更";
			this.btn部門変更.Click += new System.EventHandler(this.btn部門変更_Click);
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn自動出力フォルダ);
			this.panel8.Controls.Add(this.btn自動出力);
			this.panel8.Controls.Add(this.btnパスワード変更);
			this.panel8.Controls.Add(this.texメッセージ);
			this.panel8.Controls.Add(this.btn終了);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 2;
			// 
			// btn自動出力フォルダ
			// 
			this.btn自動出力フォルダ.BackColor = System.Drawing.Color.PaleGreen;
			this.btn自動出力フォルダ.ForeColor = System.Drawing.Color.Blue;
			this.btn自動出力フォルダ.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn自動出力フォルダ.Location = new System.Drawing.Point(238, 6);
			this.btn自動出力フォルダ.Name = "btn自動出力フォルダ";
			this.btn自動出力フォルダ.Size = new System.Drawing.Size(62, 48);
			this.btn自動出力フォルダ.TabIndex = 12;
			this.btn自動出力フォルダ.Text = "自動出力 フォルダ 表示";
			this.btn自動出力フォルダ.Click += new System.EventHandler(this.btn自動出力フォルダ_Click);
			// 
			// btn自動出力
			// 
			this.btn自動出力.BackColor = System.Drawing.Color.PaleGreen;
			this.btn自動出力.ForeColor = System.Drawing.Color.Blue;
			this.btn自動出力.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn自動出力.Location = new System.Drawing.Point(168, 6);
			this.btn自動出力.Name = "btn自動出力";
			this.btn自動出力.Size = new System.Drawing.Size(62, 48);
			this.btn自動出力.TabIndex = 11;
			this.btn自動出力.Text = "自動出力 ON";
			this.btn自動出力.Click += new System.EventHandler(this.btn自動出力_Click);
			// 
			// btnパスワード変更
			// 
			this.btnパスワード変更.ForeColor = System.Drawing.Color.Blue;
			this.btnパスワード変更.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnパスワード変更.Location = new System.Drawing.Point(98, 6);
			this.btnパスワード変更.Name = "btnパスワード変更";
			this.btnパスワード変更.Size = new System.Drawing.Size(62, 48);
			this.btnパスワード変更.TabIndex = 1;
			this.btnパスワード変更.Text = "パスワード変更";
			this.btnパスワード変更.Click += new System.EventHandler(this.btnパスワード変更_Click);
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
			// btn終了
			// 
			this.btn終了.ForeColor = System.Drawing.Color.Red;
			this.btn終了.Location = new System.Drawing.Point(8, 6);
			this.btn終了.Name = "btn終了";
			this.btn終了.Size = new System.Drawing.Size(54, 48);
			this.btn終了.TabIndex = 0;
			this.btn終了.TabStop = false;
			this.btn終了.Text = "終了";
			this.btn終了.Click += new System.EventHandler(this.btn終了_Click);
			// 
			// lab自動出力ＯＮ
			// 
			this.lab自動出力ＯＮ.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(101)), ((System.Byte)(255)));
			this.lab自動出力ＯＮ.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab自動出力ＯＮ.ForeColor = System.Drawing.Color.White;
			this.lab自動出力ＯＮ.Location = new System.Drawing.Point(0, 398);
			this.lab自動出力ＯＮ.Name = "lab自動出力ＯＮ";
			this.lab自動出力ＯＮ.Size = new System.Drawing.Size(160, 42);
			this.lab自動出力ＯＮ.TabIndex = 3;
			this.lab自動出力ＯＮ.Text = "自動出力ＯＮ";
			this.lab自動出力ＯＮ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// picお届け先情報
			// 
			this.picお届け先情報.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picお届け先情報.Location = new System.Drawing.Point(16, 16);
			this.picお届け先情報.Name = "picお届け先情報";
			this.picお届け先情報.Size = new System.Drawing.Size(482, 42);
			this.picお届け先情報.TabIndex = 22;
			this.picお届け先情報.TabStop = false;
			this.picお届け先情報.Click += new System.EventHandler(this.picお届け先情報_Click);
			this.picお届け先情報.MouseEnter += new System.EventHandler(this.picお届け先情報_MouseEnter);
			this.picお届け先情報.MouseLeave += new System.EventHandler(this.picお届け先情報_MouseLeave);
			// 
			// picご依頼主情報
			// 
			this.picご依頼主情報.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picご依頼主情報.Location = new System.Drawing.Point(16, 144);
			this.picご依頼主情報.Name = "picご依頼主情報";
			this.picご依頼主情報.Size = new System.Drawing.Size(482, 42);
			this.picご依頼主情報.TabIndex = 23;
			this.picご依頼主情報.TabStop = false;
			this.picご依頼主情報.Click += new System.EventHandler(this.picご依頼主情報_Click);
			this.picご依頼主情報.MouseEnter += new System.EventHandler(this.picご依頼主情報_MouseEnter);
			this.picご依頼主情報.MouseLeave += new System.EventHandler(this.picご依頼主情報_MouseLeave);
			// 
			// picご依頼主取込
			// 
			this.picご依頼主取込.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picご依頼主取込.Location = new System.Drawing.Point(16, 208);
			this.picご依頼主取込.Name = "picご依頼主取込";
			this.picご依頼主取込.Size = new System.Drawing.Size(482, 42);
			this.picご依頼主取込.TabIndex = 23;
			this.picご依頼主取込.TabStop = false;
			this.picご依頼主取込.Click += new System.EventHandler(this.picご依頼主取込_Click);
			this.picご依頼主取込.MouseEnter += new System.EventHandler(this.picご依頼主取込_MouseEnter);
			this.picご依頼主取込.MouseLeave += new System.EventHandler(this.picご依頼主取込_MouseLeave);
			// 
			// pic記事情報
			// 
			this.pic記事情報.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic記事情報.Location = new System.Drawing.Point(16, 16);
			this.pic記事情報.Name = "pic記事情報";
			this.pic記事情報.Size = new System.Drawing.Size(482, 42);
			this.pic記事情報.TabIndex = 24;
			this.pic記事情報.TabStop = false;
			this.pic記事情報.Click += new System.EventHandler(this.pic記事情報_Click);
			this.pic記事情報.MouseEnter += new System.EventHandler(this.pic記事情報_MouseEnter);
			this.pic記事情報.MouseLeave += new System.EventHandler(this.pic記事情報_MouseLeave);
			// 
			// pic端末情報
			// 
			this.pic端末情報.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic端末情報.Location = new System.Drawing.Point(16, 144);
			this.pic端末情報.Name = "pic端末情報";
			this.pic端末情報.Size = new System.Drawing.Size(482, 42);
			this.pic端末情報.TabIndex = 24;
			this.pic端末情報.TabStop = false;
			this.pic端末情報.Click += new System.EventHandler(this.pic端末情報_Click);
			this.pic端末情報.MouseEnter += new System.EventHandler(this.pic端末情報_MouseEnter);
			this.pic端末情報.MouseLeave += new System.EventHandler(this.pic端末情報_MouseLeave);
			// 
			// pic請求先登録
			// 
			this.pic請求先登録.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic請求先登録.Location = new System.Drawing.Point(16, 80);
			this.pic請求先登録.Name = "pic請求先登録";
			this.pic請求先登録.Size = new System.Drawing.Size(482, 42);
			this.pic請求先登録.TabIndex = 24;
			this.pic請求先登録.TabStop = false;
			this.pic請求先登録.Click += new System.EventHandler(this.pic請求先登録_Click);
			this.pic請求先登録.MouseEnter += new System.EventHandler(this.pic請求先登録_MouseEnter);
			this.pic請求先登録.MouseLeave += new System.EventHandler(this.pic請求先登録_MouseLeave);
			// 
			// pic出荷照会
			// 
			this.pic出荷照会.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic出荷照会.Location = new System.Drawing.Point(16, 16);
			this.pic出荷照会.Name = "pic出荷照会";
			this.pic出荷照会.Size = new System.Drawing.Size(482, 42);
			this.pic出荷照会.TabIndex = 22;
			this.pic出荷照会.TabStop = false;
			this.pic出荷照会.Click += new System.EventHandler(this.pic出荷照会_Click);
			this.pic出荷照会.MouseEnter += new System.EventHandler(this.pic出荷照会_MouseEnter);
			this.pic出荷照会.MouseLeave += new System.EventHandler(this.pic出荷照会_MouseLeave);
			// 
			// panメイン
			// 
			this.panメイン.Controls.Add(this.lbl王子運送);
			this.panメイン.Controls.Add(this.panメニュー６);
			this.panメイン.Controls.Add(this.lab自動出力ＯＮ);
			this.panメイン.Controls.Add(this.picメニュー６);
			this.panメイン.Controls.Add(this.labバージョン);
			this.panメイン.Controls.Add(this.picメニュー４);
			this.panメイン.Controls.Add(this.picメニュー３);
			this.panメイン.Controls.Add(this.picメニュー２);
			this.panメイン.Controls.Add(this.picメニュー１);
			this.panメイン.Controls.Add(this.panメニュー４);
			this.panメイン.Controls.Add(this.panメニュー３);
			this.panメイン.Controls.Add(this.panメニュー１);
			this.panメイン.Controls.Add(this.panメニュー２);
			this.panメイン.Controls.Add(this.pictureBox2);
			this.panメイン.Controls.Add(this.pictureBox7);
			this.panメイン.Controls.Add(this.labメッセージ);
			this.panメイン.Controls.Add(this.labメッセージ裏);
			this.panメイン.Location = new System.Drawing.Point(0, 52);
			this.panメイン.Name = "panメイン";
			this.panメイン.Size = new System.Drawing.Size(784, 458);
			this.panメイン.TabIndex = 20;
			// 
			// lbl王子運送
			// 
			this.lbl王子運送.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(255)));
			this.lbl王子運送.Font = new System.Drawing.Font("Arial Black", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbl王子運送.ForeColor = System.Drawing.Color.White;
			this.lbl王子運送.Location = new System.Drawing.Point(474, 10);
			this.lbl王子運送.Name = "lbl王子運送";
			this.lbl王子運送.Size = new System.Drawing.Size(202, 48);
			this.lbl王子運送.TabIndex = 40;
			this.lbl王子運送.Text = "王子運送";
			// 
			// panメニュー６
			// 
			this.panメニュー６.Controls.Add(this.btnお知らせ１);
			this.panメニュー６.Controls.Add(this.btnお知らせ５);
			this.panメニュー６.Controls.Add(this.btnお知らせ４);
			this.panメニュー６.Controls.Add(this.btnお知らせ３);
			this.panメニュー６.Controls.Add(this.btnお知らせ２);
			this.panメニュー６.Location = new System.Drawing.Point(184, 82);
			this.panメニュー６.Name = "panメニュー６";
			this.panメニュー６.Size = new System.Drawing.Size(544, 338);
			this.panメニュー６.TabIndex = 38;
			// 
			// btnお知らせ１
			// 
			this.btnお知らせ１.Location = new System.Drawing.Point(16, 16);
			this.btnお知らせ１.Name = "btnお知らせ１";
			this.btnお知らせ１.Size = new System.Drawing.Size(482, 42);
			this.btnお知らせ１.TabIndex = 26;
			this.btnお知らせ１.Visible = false;
			this.btnお知らせ１.ButtonClicked += new System.EventHandler(this.picお知らせ１_Click);
			// 
			// btnお知らせ５
			// 
			this.btnお知らせ５.Location = new System.Drawing.Point(16, 272);
			this.btnお知らせ５.Name = "btnお知らせ５";
			this.btnお知らせ５.Size = new System.Drawing.Size(482, 42);
			this.btnお知らせ５.TabIndex = 29;
			this.btnお知らせ５.Visible = false;
			this.btnお知らせ５.ButtonClicked += new System.EventHandler(this.picお知らせ５_Click);
			// 
			// btnお知らせ４
			// 
			this.btnお知らせ４.Location = new System.Drawing.Point(16, 208);
			this.btnお知らせ４.Name = "btnお知らせ４";
			this.btnお知らせ４.Size = new System.Drawing.Size(482, 42);
			this.btnお知らせ４.TabIndex = 28;
			this.btnお知らせ４.Visible = false;
			this.btnお知らせ４.ButtonClicked += new System.EventHandler(this.picお知らせ４_Click);
			// 
			// btnお知らせ３
			// 
			this.btnお知らせ３.Location = new System.Drawing.Point(16, 144);
			this.btnお知らせ３.Name = "btnお知らせ３";
			this.btnお知らせ３.Size = new System.Drawing.Size(482, 42);
			this.btnお知らせ３.TabIndex = 27;
			this.btnお知らせ３.Visible = false;
			this.btnお知らせ３.ButtonClicked += new System.EventHandler(this.picお知らせ３_Click);
			// 
			// btnお知らせ２
			// 
			this.btnお知らせ２.Location = new System.Drawing.Point(16, 80);
			this.btnお知らせ２.Name = "btnお知らせ２";
			this.btnお知らせ２.Size = new System.Drawing.Size(482, 42);
			this.btnお知らせ２.TabIndex = 26;
			this.btnお知らせ２.Visible = false;
			this.btnお知らせ２.ButtonClicked += new System.EventHandler(this.picお知らせ２_Click);
			// 
			// picメニュー６
			// 
			this.picメニュー６.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(255)));
			this.picメニュー６.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picメニュー６.Location = new System.Drawing.Point(0, 354);
			this.picメニュー６.Name = "picメニュー６";
			this.picメニュー６.Size = new System.Drawing.Size(162, 42);
			this.picメニュー６.TabIndex = 39;
			this.picメニュー６.TabStop = false;
			this.picメニュー６.Click += new System.EventHandler(this.picメニュー６_Click);
			this.picメニュー６.MouseEnter += new System.EventHandler(this.picメニュー６_MouseEnter);
			this.picメニュー６.MouseLeave += new System.EventHandler(this.picメニュー６_MouseLeave);
			// 
			// labバージョン
			// 
			this.labバージョン.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(101)), ((System.Byte)(255)));
			this.labバージョン.ForeColor = System.Drawing.Color.White;
			this.labバージョン.Location = new System.Drawing.Point(704, 16);
			this.labバージョン.Name = "labバージョン";
			this.labバージョン.Size = new System.Drawing.Size(60, 12);
			this.labバージョン.TabIndex = 38;
			this.labバージョン.Text = "Ver.1.9";
			// 
			// picメニュー４
			// 
			this.picメニュー４.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(255)));
			this.picメニュー４.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picメニュー４.Location = new System.Drawing.Point(0, 228);
			this.picメニュー４.Name = "picメニュー４";
			this.picメニュー４.Size = new System.Drawing.Size(162, 42);
			this.picメニュー４.TabIndex = 31;
			this.picメニュー４.TabStop = false;
			this.picメニュー４.Click += new System.EventHandler(this.picメニュー４_Click);
			this.picメニュー４.MouseEnter += new System.EventHandler(this.picメニュー４_MouseEnter);
			this.picメニュー４.MouseLeave += new System.EventHandler(this.picメニュー４_MouseLeave);
			// 
			// picメニュー３
			// 
			this.picメニュー３.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(255)));
			this.picメニュー３.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picメニュー３.Location = new System.Drawing.Point(0, 186);
			this.picメニュー３.Name = "picメニュー３";
			this.picメニュー３.Size = new System.Drawing.Size(162, 42);
			this.picメニュー３.TabIndex = 30;
			this.picメニュー３.TabStop = false;
			this.picメニュー３.Click += new System.EventHandler(this.picメニュー３_Click);
			this.picメニュー３.MouseEnter += new System.EventHandler(this.picメニュー３_MouseEnter);
			this.picメニュー３.MouseLeave += new System.EventHandler(this.picメニュー３_MouseLeave);
			// 
			// picメニュー２
			// 
			this.picメニュー２.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(255)));
			this.picメニュー２.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picメニュー２.Location = new System.Drawing.Point(0, 144);
			this.picメニュー２.Name = "picメニュー２";
			this.picメニュー２.Size = new System.Drawing.Size(162, 42);
			this.picメニュー２.TabIndex = 29;
			this.picメニュー２.TabStop = false;
			this.picメニュー２.Click += new System.EventHandler(this.picメニュー２_Click);
			this.picメニュー２.MouseEnter += new System.EventHandler(this.picメニュー２_MouseEnter);
			this.picメニュー２.MouseLeave += new System.EventHandler(this.picメニュー２_MouseLeave);
			// 
			// picメニュー１
			// 
			this.picメニュー１.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(255)));
			this.picメニュー１.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picメニュー１.Location = new System.Drawing.Point(0, 102);
			this.picメニュー１.Name = "picメニュー１";
			this.picメニュー１.Size = new System.Drawing.Size(162, 42);
			this.picメニュー１.TabIndex = 28;
			this.picメニュー１.TabStop = false;
			this.picメニュー１.Click += new System.EventHandler(this.picメニュー１_Click);
			this.picメニュー１.MouseEnter += new System.EventHandler(this.picメニュー１_MouseEnter);
			this.picメニュー１.MouseLeave += new System.EventHandler(this.picメニュー１_MouseLeave);
			// 
			// panメニュー４
			// 
			this.panメニュー４.Controls.Add(this.pic請求先登録);
			this.panメニュー４.Controls.Add(this.pic記事情報);
			this.panメニュー４.Controls.Add(this.pic端末情報);
			this.panメニュー４.Controls.Add(this.pic才数切替);
			this.panメニュー４.Location = new System.Drawing.Point(184, 82);
			this.panメニュー４.Name = "panメニュー４";
			this.panメニュー４.Size = new System.Drawing.Size(544, 338);
			this.panメニュー４.TabIndex = 33;
			// 
			// pic才数切替
			// 
			this.pic才数切替.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic才数切替.Location = new System.Drawing.Point(16, 208);
			this.pic才数切替.Name = "pic才数切替";
			this.pic才数切替.Size = new System.Drawing.Size(482, 42);
			this.pic才数切替.TabIndex = 25;
			this.pic才数切替.TabStop = false;
			this.pic才数切替.Click += new System.EventHandler(this.pic才数切替_Click);
			this.pic才数切替.MouseEnter += new System.EventHandler(this.pic才数切替_MouseEnter);
			this.pic才数切替.MouseLeave += new System.EventHandler(this.pic才数切替_MouseLeave);
			// 
			// panメニュー３
			// 
			this.panメニュー３.Controls.Add(this.picお届け先情報);
			this.panメニュー３.Controls.Add(this.picご依頼主情報);
			this.panメニュー３.Controls.Add(this.picご依頼主取込);
			this.panメニュー３.Controls.Add(this.picお届先取込);
			this.panメニュー３.Location = new System.Drawing.Point(184, 82);
			this.panメニュー３.Name = "panメニュー３";
			this.panメニュー３.Size = new System.Drawing.Size(544, 338);
			this.panメニュー３.TabIndex = 33;
			// 
			// picお届先取込
			// 
			this.picお届先取込.BackColor = System.Drawing.Color.Transparent;
			this.picお届先取込.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picお届先取込.Location = new System.Drawing.Point(16, 80);
			this.picお届先取込.Name = "picお届先取込";
			this.picお届先取込.Size = new System.Drawing.Size(482, 42);
			this.picお届先取込.TabIndex = 22;
			this.picお届先取込.TabStop = false;
			this.picお届先取込.Click += new System.EventHandler(this.picお届先取込_Click);
			this.picお届先取込.MouseEnter += new System.EventHandler(this.picお届先取込_MouseEnter);
			this.picお届先取込.MouseLeave += new System.EventHandler(this.picお届先取込_MouseLeave);
			// 
			// panメニュー１
			// 
			this.panメニュー１.Controls.Add(this.picチョイスプリント);
			this.panメニュー１.Controls.Add(this.pic送り状荷札発行);
			this.panメニュー１.Controls.Add(this.pic雛型出荷登録);
			this.panメニュー１.Controls.Add(this.pic出荷登録);
			this.panメニュー１.Controls.Add(this.pic自動出荷登録);
			this.panメニュー１.Location = new System.Drawing.Point(184, 82);
			this.panメニュー１.Name = "panメニュー１";
			this.panメニュー１.Size = new System.Drawing.Size(544, 338);
			this.panメニュー１.TabIndex = 33;
			// 
			// picチョイスプリント
			// 
			this.picチョイスプリント.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picチョイスプリント.Location = new System.Drawing.Point(16, 272);
			this.picチョイスプリント.Name = "picチョイスプリント";
			this.picチョイスプリント.Size = new System.Drawing.Size(482, 42);
			this.picチョイスプリント.TabIndex = 25;
			this.picチョイスプリント.TabStop = false;
			this.picチョイスプリント.Click += new System.EventHandler(this.picチョイスプリント_Click);
			this.picチョイスプリント.MouseEnter += new System.EventHandler(this.picチョイスプリント_MouseEnter);
			this.picチョイスプリント.MouseLeave += new System.EventHandler(this.picチョイスプリント_MouseLeave);
			// 
			// pic送り状荷札発行
			// 
			this.pic送り状荷札発行.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic送り状荷札発行.Location = new System.Drawing.Point(16, 208);
			this.pic送り状荷札発行.Name = "pic送り状荷札発行";
			this.pic送り状荷札発行.Size = new System.Drawing.Size(482, 42);
			this.pic送り状荷札発行.TabIndex = 24;
			this.pic送り状荷札発行.TabStop = false;
			this.pic送り状荷札発行.Click += new System.EventHandler(this.pic送り状荷札発行_Click);
			this.pic送り状荷札発行.MouseEnter += new System.EventHandler(this.pic送り状荷札発行_MouseEnter);
			this.pic送り状荷札発行.MouseLeave += new System.EventHandler(this.pic送り状荷札発行_MouseLeave);
			// 
			// pic雛型出荷登録
			// 
			this.pic雛型出荷登録.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic雛型出荷登録.Location = new System.Drawing.Point(16, 80);
			this.pic雛型出荷登録.Name = "pic雛型出荷登録";
			this.pic雛型出荷登録.Size = new System.Drawing.Size(482, 42);
			this.pic雛型出荷登録.TabIndex = 23;
			this.pic雛型出荷登録.TabStop = false;
			this.pic雛型出荷登録.Click += new System.EventHandler(this.pic雛型出荷登録_Click);
			this.pic雛型出荷登録.MouseEnter += new System.EventHandler(this.pic雛型出荷登録_MouseEnter);
			this.pic雛型出荷登録.MouseLeave += new System.EventHandler(this.pic雛型出荷登録_MouseLeave);
			// 
			// pic出荷登録
			// 
			this.pic出荷登録.BackColor = System.Drawing.Color.Transparent;
			this.pic出荷登録.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic出荷登録.Location = new System.Drawing.Point(16, 16);
			this.pic出荷登録.Name = "pic出荷登録";
			this.pic出荷登録.Size = new System.Drawing.Size(482, 42);
			this.pic出荷登録.TabIndex = 22;
			this.pic出荷登録.TabStop = false;
			this.pic出荷登録.Click += new System.EventHandler(this.pic出荷登録_Click);
			this.pic出荷登録.MouseEnter += new System.EventHandler(this.pic出荷登録_MouseEnter);
			this.pic出荷登録.MouseLeave += new System.EventHandler(this.pic出荷登録_MouseLeave);
			// 
			// pic自動出荷登録
			// 
			this.pic自動出荷登録.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic自動出荷登録.Location = new System.Drawing.Point(16, 144);
			this.pic自動出荷登録.Name = "pic自動出荷登録";
			this.pic自動出荷登録.Size = new System.Drawing.Size(482, 42);
			this.pic自動出荷登録.TabIndex = 23;
			this.pic自動出荷登録.TabStop = false;
			this.pic自動出荷登録.Click += new System.EventHandler(this.pic自動出荷登録_Click);
			this.pic自動出荷登録.MouseEnter += new System.EventHandler(this.pic自動出荷登録_MouseEnter);
			this.pic自動出荷登録.MouseLeave += new System.EventHandler(this.pic自動出荷登録_MouseLeave);
			// 
			// panメニュー２
			// 
			this.panメニュー２.Controls.Add(this.picラベルイメージ印刷);
			this.panメニュー２.Controls.Add(this.pic出荷実績);
			this.panメニュー２.Controls.Add(this.pic出荷照会);
			this.panメニュー２.Controls.Add(this.pic再発行);
			this.panメニュー２.Controls.Add(this.picバーコード読取);
			this.panメニュー２.Location = new System.Drawing.Point(184, 82);
			this.panメニュー２.Name = "panメニュー２";
			this.panメニュー２.Size = new System.Drawing.Size(544, 338);
			this.panメニュー２.TabIndex = 33;
			// 
			// pic出荷実績
			// 
			this.pic出荷実績.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic出荷実績.Location = new System.Drawing.Point(16, 80);
			this.pic出荷実績.Name = "pic出荷実績";
			this.pic出荷実績.Size = new System.Drawing.Size(482, 42);
			this.pic出荷実績.TabIndex = 27;
			this.pic出荷実績.TabStop = false;
			this.pic出荷実績.Click += new System.EventHandler(this.pic出荷実績_Click);
			this.pic出荷実績.MouseEnter += new System.EventHandler(this.pic出荷実績_MouseEnter);
			this.pic出荷実績.MouseLeave += new System.EventHandler(this.pic出荷実績_MouseLeave);
			// 
			// pic再発行
			// 
			this.pic再発行.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic再発行.Location = new System.Drawing.Point(16, 144);
			this.pic再発行.Name = "pic再発行";
			this.pic再発行.Size = new System.Drawing.Size(482, 42);
			this.pic再発行.TabIndex = 26;
			this.pic再発行.TabStop = false;
			this.pic再発行.Click += new System.EventHandler(this.pic再発行_Click);
			this.pic再発行.MouseEnter += new System.EventHandler(this.pic再発行_MouseEnter);
			this.pic再発行.MouseLeave += new System.EventHandler(this.pic再発行_MouseLeave);
			// 
			// picバーコード読取
			// 
			this.picバーコード読取.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picバーコード読取.Location = new System.Drawing.Point(16, 208);
			this.picバーコード読取.Name = "picバーコード読取";
			this.picバーコード読取.Size = new System.Drawing.Size(482, 42);
			this.picバーコード読取.TabIndex = 41;
			this.picバーコード読取.TabStop = false;
			this.picバーコード読取.Click += new System.EventHandler(this.picバーコード読取_Click);
			this.picバーコード読取.MouseEnter += new System.EventHandler(this.picバーコード読取_MouseEnter);
			this.picバーコード読取.MouseLeave += new System.EventHandler(this.picバーコード読取_MouseLeave);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(255)));
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(0, 10);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(782, 65);
			this.pictureBox2.TabIndex = 26;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox7
			// 
			this.pictureBox7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(255)));
			this.pictureBox7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox7.BackgroundImage")));
			this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
			this.pictureBox7.Location = new System.Drawing.Point(0, 46);
			this.pictureBox7.Name = "pictureBox7";
			this.pictureBox7.Size = new System.Drawing.Size(160, 418);
			this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox7.TabIndex = 25;
			this.pictureBox7.TabStop = false;
			// 
			// labメッセージ
			// 
			this.labメッセージ.BackColor = System.Drawing.Color.SkyBlue;
			this.labメッセージ.Font = new System.Drawing.Font("ＭＳ ゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labメッセージ.ForeColor = System.Drawing.SystemColors.ControlText;
			this.labメッセージ.Location = new System.Drawing.Point(136, 434);
			this.labメッセージ.Name = "labメッセージ";
			this.labメッセージ.Size = new System.Drawing.Size(682, 24);
			this.labメッセージ.TabIndex = 34;
			this.labメッセージ.Tag = "";
			this.labメッセージ.Text = "　　";
			this.labメッセージ.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// labメッセージ裏
			// 
			this.labメッセージ裏.BackColor = System.Drawing.Color.SkyBlue;
			this.labメッセージ裏.Font = new System.Drawing.Font("ＭＳ ゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labメッセージ裏.Location = new System.Drawing.Point(136, 434);
			this.labメッセージ裏.Name = "labメッセージ裏";
			this.labメッセージ裏.Size = new System.Drawing.Size(662, 24);
			this.labメッセージ裏.TabIndex = 37;
			this.labメッセージ裏.Tag = "";
			this.labメッセージ裏.Text = "　　";
			this.labメッセージ裏.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// picラベルイメージ印刷
			// 
			this.picラベルイメージ印刷.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picラベルイメージ印刷.Location = new System.Drawing.Point(16, 272);
			this.picラベルイメージ印刷.Name = "picラベルイメージ印刷";
			this.picラベルイメージ印刷.Size = new System.Drawing.Size(482, 42);
			this.picラベルイメージ印刷.TabIndex = 42;
			this.picラベルイメージ印刷.TabStop = false;
			this.picラベルイメージ印刷.Click += new System.EventHandler(this.picラベルイメージ印刷_Click);
			this.picラベルイメージ印刷.MouseEnter += new System.EventHandler(this.picラベルイメージ印刷_MouseEnter);
			this.picラベルイメージ印刷.MouseLeave += new System.EventHandler(this.picラベルイメージ印刷_MouseLeave);
			// 
			// メニュー
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 580);
			this.Controls.Add(this.panメイン);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "メニュー";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "is-2 Home";
			this.Load += new System.EventHandler(this.メニュー_Load);
			this.Activated += new System.EventHandler(this.メニュー_Activated);
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).EndInit();
			this.panel7.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panメイン.ResumeLayout(false);
			this.panメニュー６.ResumeLayout(false);
			this.panメニュー４.ResumeLayout(false);
			this.panメニュー３.ResumeLayout(false);
			this.panメニュー１.ResumeLayout(false);
			this.panメニュー２.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		[STAThread]
// MOD 2009.07.30 東都）高木 exeのdll化対応 START
//		static void Main(string[] args) 
// MOD 2009.10.14 東都）高木 config読込など START
//		public static void Main(string[] args) 
		public void Main(string[] args) 
// MOD 2009.10.14 東都）高木 config読込など END
// MOD 2009.07.30 東都）高木 exeのdll化対応 END
		{
// MOD 2009.07.30 東都）高木 exeのdll化対応 START
//			// アプリケーションの二重起動防止
//			mutex = new System.Threading.Mutex(false, "is2Client");
//			if( mutex.WaitOne(0, false) == false) return;
// MOD 2009.07.30 東都）高木 exeのdll化対応 END

// MOD 2005.05.20 東都）伊賀 クイックエントリショートカット対応 START
//			if(args.Length > 0 && args[0].Trim() == "hinagata")
			if(args.Length > 0 && args[0].IndexOf("hinagata") != -1)
			{
				b雛型出荷登録 = true;
				if (args[0].IndexOf("_") != -1)
				{
					s雛型出荷登録ＮＯ = args[0].Substring(args[0].IndexOf("_") + 1);
				}
			}
// MOD 2005.05.20 東都）伊賀 クイックエントリショートカット対応 END

			// カレントディレクトリの取得
			gsアプリフォルダ = System.IO.Directory.GetCurrentDirectory();

// MOD 2009.10.14 東都）高木 config読込など START
			try{
				FileInfo finfo = new FileInfo("IS2Client.dll.config");
				if(finfo.Exists){
					XmlDocument xmldoc = new XmlDocument();
					xmldoc.Load(finfo.FullName);
					foreach(XmlNode node in xmldoc["configuration"]["appSettings"]){
						if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2address.Service1")){
							sUrl_address = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2goirai.Service1")){
							sUrl_goirai = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2hinagata.Service1")){
							sUrl_hinagata = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2init.Service1")){
							sUrl_init = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2kiji.Service1")){
							sUrl_kiji = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2otodoke.Service1")){
							sUrl_otodoke = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2print.Service1")){
							sUrl_print = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2syukka.Service1")){
							sUrl_syukka = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2seikyuu.Service1")){
							sUrl_seikyuu = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2oshirase.Service1")){
							sUrl_oshirase = node.Attributes.GetNamedItem("value").Value;
						}
// MOD 2011.01.11 東都）高木 王子運送の対応 START
						else if(node.Attributes.GetNamedItem("key").Value.Equals("IS2Client.is2oji.Service1")){
							sUrl_oji = node.Attributes.GetNamedItem("value").Value;
						}
// MOD 2011.01.11 東都）高木 王子運送の対応 END
						else if(node.Attributes.GetNamedItem("key").Value.Equals("HelpURL")){
							sヘルプＵＲＬ = node.Attributes.GetNamedItem("value").Value;
						}
					}
					xmldoc = null;
				}
				finfo = null;
			}catch(Exception){
				;
			}
// MOD 2009.10.14 東都）高木 config読込など END
// ADD 2005.05.27 東都）高木 スレッド位置の移動 START
			trd = new Thread(new ThreadStart(ThreadTask));
			trd.IsBackground = true;
			trd.Start();
// ADD 2005.05.27 東都）高木 スレッド位置の移動 END

			// XMLサービスの初期化
			try
			{
// MOD 2005.05.17 東都）高木 起動時間を短くする START
//				if(sv_init == null) sv_init = new is2init.Service1();
//				sv_init.CookieContainer = cContainer;
// MOD 2005.05.17 東都）高木 起動時間を短くする END

				bool bログイン = true;

// ADD 2008.05.20 東都）高木 [wis2.dll]のフォルダの変更 START
				//[wis2.dll]がシステムフォルダに有る場合
				//（インストーラーのバージョンが古い場合）
				if(File.Exists(gsInitFile)){
// ADD 2008.05.20 東都）高木 [wis2.dll]のフォルダの変更 END
// ADD 2008.03.13 東都）高木 Vista対応 START
					//書き込み権限がない場合（Vista対応、ドメイン対応）
					try{
						StreamWriter sw = File.AppendText(gsInitFile);
						sw.Write("");
						sw.Close();
					}catch(Exception){
// ADD 2008.06.17 東都）高木 ディレクトリ存在チェックの追加 START
						if(Directory.Exists(gsアプリフォルダ.Substring(0,gsアプリフォルダ.Length-4))){
// ADD 2008.06.17 東都）高木 ディレクトリ存在チェックの追加 END
							gbInitFileExt = true;
// MOD 2008.03.13 東都）高木 Vista対応 START
//						gsInitFile = gsアプリフォルダ + "\\wis2.dll";
							gsInitFile
							 = gsアプリフォルダ.Substring(0,gsアプリフォルダ.Length-4)
							 + "\\wis2.dll";
// MOD 2008.03.13 東都）高木 Vista対応 END
// ADD 2008.06.17 東都）高木 ディレクトリ存在チェックの追加 START
						}
// ADD 2008.06.17 東都）高木 ディレクトリ存在チェックの追加 END
					}
// ADD 2008.03.13 東都）高木 Vista対応 END
// ADD 2008.05.20 東都）高木 [wis2.dll]のフォルダの変更 START
				}else{
// ADD 2008.06.17 東都）高木 ディレクトリ存在チェックの追加 START
					if(Directory.Exists(gsアプリフォルダ.Substring(0,gsアプリフォルダ.Length-4))){
// ADD 2008.06.17 東都）高木 ディレクトリ存在チェックの追加 END
						gbInitFileExt = true;
						gsInitFile
						 = gsアプリフォルダ.Substring(0,gsアプリフォルダ.Length-4)
						 + "\\wis2.dll";
// ADD 2008.06.17 東都）高木 ディレクトリ存在チェックの追加 START
					}
// ADD 2008.06.17 東都）高木 ディレクトリ存在チェックの追加 END
				}
// ADD 2008.05.20 東都）高木 [wis2.dll]のフォルダの変更 END
// ADD 2009.07.29 東都）高木 プロキシ対応 START
				if(Directory.Exists(gsアプリフォルダ.Substring(0,gsアプリフォルダ.Length-4))){
					gsInitProxy
					 = gsアプリフォルダ.Substring(0,gsアプリフォルダ.Length-4)
					 + "\\proxy.ini";
// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 START
					gsInitKiji
					 = gsアプリフォルダ.Substring(0,gsアプリフォルダ.Length-4)
					 + "\\kiji.ini";
// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 END
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 START
					gsInitClient
					 = gsアプリフォルダ.Substring(0,gsアプリフォルダ.Length-4)
					 + "\\IS2Client.ini";
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 END
// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 START
					gsInitSyukka
					 = gsアプリフォルダ.Substring(0,gsアプリフォルダ.Length-4)
					 + "\\syukka.ini";
					gsPathSyukka
					 = gsアプリフォルダ.Substring(0,gsアプリフォルダ.Length-4)
					 + "\\Syukka";
					gsPathSyukkaIn  = gsPathSyukka + "\\In";
					gsPathSyukkaOut = gsPathSyukka + "\\Out";
					gsPathSyukkaLog = gsPathSyukka + "\\Log";
// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 END
// MOD 2010.04.16 東都）高木 モジュール再ダウンロード START
					gsFlagIS2Client
					 = gsアプリフォルダ.Substring(0,gsアプリフォルダ.Length-4)
					 + "\\zs2Client.txt";
// MOD 2010.04.16 東都）高木 モジュール再ダウンロード END
				}
// ADD 2009.07.29 東都）高木 プロキシ対応 END
// MOD 2011.10.11 東都）高木 ＳＳＬ証明書導入状態などのチェック START
				gbInitSyukkaExists = false;
				try{
					if(File.Exists(gsInitSyukka)){
						gbInitSyukkaExists = true;
					}
				}catch{
					gbInitSyukkaExists = false;
				}
				gsOSVer = "";
				try{
					gsOSVer = System.Environment.OSVersion.Version.ToString();
				}catch(Exception ex){
					gsOSVer = "e:"+ex.Message;
				}
				gsNetVer = "";
				try{
					gsNetVer = System.Environment.Version.ToString();
				}catch(Exception ex){
					gsNetVer = "e:"+ex.Message;
				}
// MOD 2011.10.11 東都）高木 ＳＳＬ証明書導入状態などのチェック END
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 START
				端末ごとの初期設定ファイル読込();
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 END
// ADD 2008.04.11 ACT Vista対応 START

				try
				{
					漢字変換ハッシュ設定();
				}
				catch(Exception ex)
				{
					ビープ音();
					MessageBox.Show(ex.Message, 
						"漢字変換取得", 
						MessageBoxButtons.OK, MessageBoxIcon.Error);
// MOD 2009.07.30 東都）高木 exeのdll化対応 START
//					// ミューテックスの破棄
//					mutex.Close();
//					Application.Exit();
// MOD 2009.07.30 東都）高木 exeのdll化対応 END
					return;
				}		
// ADD 2008.04.11 ACT Vista対応 END

// ADD 2008.10.30 東都）高木 プロキシ対応 START
				gbInitProxyExists = false;
				gsProxyAdrUserSet = "";
				giProxyNoUserSet  = 0;
				giConnectTimeOut  = 50; // 50秒
// MOD 2011.12.06 東都）高木 プロキシ認証の追加 START
				gbProxyOnUserSet   = false;
				gbProxyIdOnUserSet = false;
				gsProxyIdUserSet   = "";
				gsProxyPaUserSet   = "";
// MOD 2011.12.06 東都）高木 プロキシ認証の追加 END

				string sConnectTimeOut  = "";
				string sProxyAdrUserSet = "";
				string sProxyNoUserSet  = "";
// MOD 2011.12.06 東都）高木 プロキシ認証の追加 START
				string sProxyOnUserSet   = "";
				string sProxyIdOnUserSet = "";
				string sProxyIdUserSet   = "";
				string sProxyPaUserSet   = "";
// MOD 2011.12.06 東都）高木 プロキシ認証の追加 END

				StreamReader srp = null;
				try
				{
					srp = File.OpenText(gsInitProxy);
					gbInitProxyExists = true;
					sConnectTimeOut  = srp.ReadLine();
					sProxyAdrUserSet = srp.ReadLine();
					sProxyNoUserSet  = srp.ReadLine();
// MOD 2011.12.06 東都）高木 プロキシ認証の追加 START
//					if(srp != null) srp.Close();
					sProxyOnUserSet   = srp.ReadLine();
					sProxyIdOnUserSet = srp.ReadLine();
					sProxyIdUserSet   = srp.ReadLine();
					sProxyPaUserSet   = srp.ReadLine();
					if(sConnectTimeOut   == null) sConnectTimeOut   = "";
					if(sProxyAdrUserSet  == null) sProxyAdrUserSet  = "";
					if(sProxyNoUserSet   == null) sProxyNoUserSet   = "";
					if(sProxyOnUserSet   == null) sProxyOnUserSet   = "";
					if(sProxyIdOnUserSet == null) sProxyIdOnUserSet = "";
					if(sProxyIdUserSet   == null) sProxyIdUserSet   = "";
					if(sProxyPaUserSet   == null) sProxyPaUserSet   = "";

					if(sProxyIdUserSet.Length > 0){
						sProxyIdUserSet  = 復号化２(sProxyIdUserSet);
						sProxyPaUserSet  = 復号化２(sProxyPaUserSet);
					}
// MOD 2011.12.06 東都）高木 プロキシ認証の追加 END
				}
//				catch(System.IO.FileNotFoundException ex)
//				{
//					With _myLogRecord
//						.Target = "プロキシ設定ファイルがみつかりませんでした"
//						.Result = "NG"
//						.Remark = ex.Message
//					End With
//					_myLog.WriteLog(_myLogRecord)
//				}
				catch(Exception)
				{
//					With _myLogRecord
//						.Target = "プロキシ設定ファイル Exception:"
//						.Result = "NG"
//						.Remark = ex.Message
//					End With
//					_myLog.WriteLog(_myLogRecord)
				}
// MOD 2011.12.06 東都）高木 プロキシ認証の追加 START
				finally
				{
					if(srp != null) srp.Close();
				}
// MOD 2011.12.06 東都）高木 プロキシ認証の追加 END

// ADD 2009.10.03 東都）高木 [proxy.ini]が存在しない時、プロキシβ版機能停止 START
				if(gbInitProxyExists){
// ADD 2009.10.03 東都）高木 [proxy.ini]が存在しない時、プロキシβ版機能停止 END
					try
					{
						if(sConnectTimeOut.Length > 0){
							if(半角チェック(sConnectTimeOut)){
								if(数値チェック(sConnectTimeOut)){
									giConnectTimeOut = int.Parse(sConnectTimeOut);
								}
							}
						}
						if(sProxyAdrUserSet != null){
							if(半角チェック(sProxyAdrUserSet)){
							    gsProxyAdrUserSet = sProxyAdrUserSet;
							}
						}
						if(sProxyNoUserSet.Length > 0){
							if(半角チェック(sProxyNoUserSet)){
								if(数値チェック(sProxyNoUserSet)){
									giProxyNoUserSet = int.Parse(sProxyNoUserSet);
								}
							}
						}
// MOD 2011.12.06 東都）高木 プロキシ認証の追加 START
						if(sProxyOnUserSet != null){
							if(半角チェック(sProxyOnUserSet)){
								if(sProxyOnUserSet.Equals("1")){
									gbProxyOnUserSet = true;
								}
							}
						}
						if(sProxyOnUserSet == null || sProxyOnUserSet.Length == 0){
							if(gsProxyAdrUserSet.Length > 0){
								gbProxyOnUserSet = true;
							}
						}
						if(sProxyIdOnUserSet != null){
							if(半角チェック(sProxyIdOnUserSet)){
								if(sProxyIdOnUserSet.Equals("1")){
									gbProxyIdOnUserSet = true;
								}
							}
						}
						if(sProxyIdUserSet != null){
							if(半角チェック(sProxyIdUserSet)){
							    gsProxyIdUserSet = sProxyIdUserSet;
							}
						}
						if(sProxyPaUserSet != null){
							if(半角チェック(sProxyPaUserSet)){
							    gsProxyPaUserSet = sProxyPaUserSet;
							}
						}
// MOD 2011.12.06 東都）高木 プロキシ認証の追加 END
					}
//					catch(Exception ex)
					catch(Exception)
					{
	//'//保留　エラー処理
	//					With _myLogRecord
	//						.Target = "XmlReadServer Exception:"
	//						.Result = "NG"
	//						.Remark = ex.Message
	//					End With
	//					_myLog.WriteLog(_myLogRecord)
					}

					bool bRet = false;
					int  iRet = 0;
					ＩＥプロキシ取得();
// MOD 2009.10.14 東都）高木 config読込など START
//					sv_init = new is2init.Service1();
					Ｗｅｂサービスの初期化init();
// MOD 2009.10.14 東都）高木 config読込など END
					sv_init.Timeout = giConnectTimeOut * 1000;

					//β版のお客様で未設定のプロキシ未設定のお客様は、[]
					//β版のお客様で未設定のプロキシ設定のお客様は、[50]
					//[proxy.ini]の１行目が未設定の場合、開発系も接続可とする
					//それ以外は[https]通信に強制的にする
// MOD 2009.10.14 東都）高木 config読込など START
//					if(sConnectTimeOut.Length > 0){
//						sv_init.Url = sv_init.Url.Replace("http://","https://");
//					}
// MOD 2009.10.14 東都）高木 config読込など END

// MOD 2011.12.06 東都）高木 プロキシ認証の追加 START
//					if(bRet == false && gsProxyAdrUserSet.Length > 0){
//						//ＩＥのプロキシ設定(ユーザ設定)
//						bRet = プロキシ設定(gsProxyAdrUserSet, giProxyNoUserSet);
//					}
					if(bRet == false){
						if(gbProxyOnUserSet){
							if(gbProxyIdOnUserSet){
								//ＩＥのプロキシ設定(ユーザ設定：認証有)
								bRet = プロキシ設定２(gsProxyAdrUserSet, giProxyNoUserSet
														, gsProxyIdUserSet, gsProxyPaUserSet);
							}else{
								//ＩＥのプロキシ設定(ユーザ設定)
								bRet = プロキシ設定(gsProxyAdrUserSet, giProxyNoUserSet);
							}
						}else{
							//ＩＥのプロキシ設定(プロキシ無し)
							bRet = プロキシ設定("", 0);
						}
					}
// MOD 2011.12.06 東都）高木 プロキシ認証の追加 END

					if(bRet == false && gsProxyAdr.Length > 0){
						//ＩＥのプロキシ設定(デフォルト)
						iRet = デフォルトプロキシ設定();
						if(iRet == 1) bRet = true;
					}

					//ＩＥのプロキシ設定(ＳＳＬ、排除リスト有効)←ベストだと思われる
					if(bRet == false && gsProxyAdr.Length > 0){
						//ＩＥのプロキシ設定(Select)
						bRet = プロキシ設定(gsProxyAdr, giProxyNo);
					}

					if(bRet == false && gsProxyAdrHttp.Length > 0){
						//ＩＥのプロキシ設定(HTTP)
						bRet = プロキシ設定(gsProxyAdrHttp, giProxyNoHttp);
					}

					if(bRet == false){
						//ＩＥのプロキシ設定(プロキシ無し)
						bRet = プロキシ設定("", 0);
					}

//					sv_init.Timeout = 100000; // デフォルト値の１００秒に戻す
// ADD 2009.10.03 東都）高木 [proxy.ini]が存在しない時、プロキシβ版機能停止 START
				}else{
					// [proxy.ini]が存在しない場合
					Ｗｅｂサービスの初期化init();
					Ｗｅｂサービスの初期化others();
				}
// ADD 2009.10.03 東都）高木 [proxy.ini]が存在しない時、プロキシβ版機能停止 END
// ADD 2009.07.29 東都）高木 プロキシ対応 END
// MOD 2011.10.11 東都）高木 ＳＳＬ証明書導入状態などのチェック START
				trdSSLTest = new Thread(new ThreadStart(ＳＳＬ証明書導入状態チェック));
				trdSSLTest.IsBackground = true;
				trdSSLTest.Start();
// MOD 2011.10.11 東都）高木 ＳＳＬ証明書導入状態などのチェック END

				// 初期設定ファイルが存在しない場合：初期登録画面を表示
				if( !File.Exists(gsInitFile) )
				{
// MOD 2007.11.29 東都）高木 ログイン時のフォーカス障害対応 START
//					初期登録 画面 = new 初期登録();
//					画面.ShowDialog();
					F初期登録 = new 初期登録();
					F初期登録.WindowState = FormWindowState.Normal;
					F初期登録.ShowDialog();
					F初期登録 = null;
// MOD 2007.11.29 東都）高木 ログイン時のフォーカス障害対応 END
					bログイン = false;	// ログイン画面は非表示
				}
				// 初期設定ファイルが存在しない場合：アプリ終了
				if( !File.Exists(gsInitFile) )
				{
// MOD 2009.07.30 東都）高木 exeのdll化対応 START
//					// ミューテックスの破棄
//					mutex.Close();
//					Application.Exit();
// MOD 2009.07.30 東都）高木 exeのdll化対応 END
					return;
				}

// MOD 2005.05.17 東都）高木 起動時間を短くする START
//				// 端末ＣＤの取得
//				StreamReader sr = File.OpenText(gsInitFile);
//				gs会員ＣＤ   = sr.ReadLine();
//				if(gs会員ＣＤ == null)
//				{
//					sr.Close();
//
//					初期登録 F初期登録 = new 初期登録();
//					F初期登録.ShowDialog();
//					bログイン = false;	// ログイン画面は非表示
//
//					sr = File.OpenText(gsInitFile);
//					gs会員ＣＤ   = sr.ReadLine();
//				}
//				gs利用者ＣＤ = sr.ReadLine();
//				gs端末ＣＤ   = sr.ReadLine();
//				gs会員名     = sr.ReadLine();
//				gs利用者名   = sr.ReadLine();
//				gs部門ＣＤ   = sr.ReadLine();
//				gs部門名     = sr.ReadLine();
//				sr.Close();
//				// 会員ＣＤ、端末ＣＤが設定されていない場合：アプリ終了
//				if(gs会員ＣＤ == null || gs会員ＣＤ.Trim().Length == 0
//					|| gs端末ＣＤ == null || gs端末ＣＤ.Trim().Length == 0)
//				{
//					// ミューテックスの破棄
//					mutex.Close();
//					Application.Exit();
//					return;
//				}
//
//				gs会員名   = "";
//
//				端末情報取得();
//				// マスタ設定が適合しない場合には終了
//				if(gs会員名.Length == 0)
//				{
//					// ミューテックスの破棄
//					mutex.Close();
//					Application.Exit();
//					return;
//				}
//				gsaユーザ[2] = gs端末ＣＤ;

				// 端末ＣＤの取得
				StreamReader sr = File.OpenText(gsInitFile);
				gs端末ＣＤ = sr.ReadLine();
				gs端末ＣＤ = sr.ReadLine();
				gs端末ＣＤ = sr.ReadLine();
				sr.Close();

				if(gs端末ＣＤ == null || gs端末ＣＤ.Trim().Length == 0)
				{
// MOD 2007.11.29 東都）高木 ログイン時のフォーカス障害対応 START
//					初期登録 F初期登録 = new 初期登録();
					F初期登録 = new 初期登録();
					F初期登録.WindowState = FormWindowState.Normal;
// MOD 2007.11.29 東都）高木 ログイン時のフォーカス障害対応 END
					F初期登録.ShowDialog();
// ADD 2007.11.29 東都）高木 ログイン時のフォーカス障害対応 START
					F初期登録 = null;
// ADD 2007.11.29 東都）高木 ログイン時のフォーカス障害対応 END
					bログイン = false;	// ログイン画面は非表示

					sr = File.OpenText(gsInitFile);
					gs端末ＣＤ = sr.ReadLine();
					gs端末ＣＤ = sr.ReadLine();
					gs端末ＣＤ = sr.ReadLine();
					sr.Close();
				}
				// 端末ＣＤが設定されていない場合：アプリ終了
				if(gs端末ＣＤ == null || gs端末ＣＤ.Trim().Length == 0)
				{
// MOD 2009.07.30 東都）高木 exeのdll化対応 START
//					// ミューテックスの破棄
//					mutex.Close();
//					Application.Exit();
// MOD 2009.07.30 東都）高木 exeのdll化対応 END
					return;
				}
				gsaユーザ[2] = gs端末ＣＤ;
// MOD 2005.05.17 東都）高木 起動時間を短くする END

				// 初期登録画面が開かれなかった時に実行
				if(bログイン)
				{
					gs利用者ＣＤ = "";
					gs利用者名   = "";
// MOD 2007.11.29 東都）高木 ログイン時のフォーカス障害対応 START
//					ログイン Fログイン = new ログイン();
					Fログイン = new ログイン();
					Fログイン.WindowState = FormWindowState.Normal;
// MOD 2007.11.29 東都）高木 ログイン時のフォーカス障害対応 END
					Fログイン.ShowDialog();
// ADD 2007.11.29 東都）高木 ログイン時のフォーカス障害対応 START
					Fログイン = null;
// ADD 2007.11.29 東都）高木 ログイン時のフォーカス障害対応 END
					// マスタ設定が適合しない場合には終了
					if(gs利用者ＣＤ.Length == 0 || gs利用者名.Length == 0)
					{
// MOD 2009.07.30 東都）高木 exeのdll化対応 START
//						// ミューテックスの破棄
//						mutex.Close();
//						Application.Exit();
// MOD 2009.07.30 東都）高木 exeのdll化対応 END
						return;
					}
				}
				利用者情報取得();
// ADD 2006.12.14 東都）小童谷 初期部門 START
				gs利用者部門ＣＤ = gs部門ＣＤ;
// ADD 2006.12.14 東都）小童谷 初期部門 END

// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 START
//// ADD 2006.12.12 東都）小童谷 部門店所取得 START
//				利用者部門店所取得();
//// ADD 2006.12.12 東都）小童谷 部門店所取得 END
				gs利用者部門店所ＣＤ = 部門店所取得(gs利用者部門ＣＤ);
				gs部門店所ＣＤ = gs利用者部門店所ＣＤ;
// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 END

// ADD 2009.04.02 東都）高木 稼働日対応 START
				稼働日情報取得();
// ADD 2009.04.02 東都）高木 稼働日対応 END
// MOD 2009.05.01 東都）高木 オプションの項目追加 START
				オプション情報取得();
// MOD 2009.05.01 東都）高木 オプションの項目追加 END
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
				重量入力制御取得();
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END

// ADD 2005.07.21 東都）高木 店所ユーザ対応 START
				if(gs権限１ == "T")
					gsプリンタＦＧ = "0"; // プリンタ無し
// ADD 2005.07.21 東都）高木 店所ユーザ対応 END
			}
			catch (Exception)
			{
// MOD 2009.07.30 東都）高木 exeのdll化対応 START
//				// ミューテックスの破棄
//				mutex.Close();
//				Application.Exit();
// MOD 2009.07.30 東都）高木 exeのdll化対応 END
				return;
			}

			gsaユーザ[0] = gs会員ＣＤ;
			gsaユーザ[1] = gs利用者ＣＤ;

// DEL 2005.05.20 東都）西口 スレッド化 START
//			if(sv_address == null) sv_address = new is2address.Service1();
//			sv_address.CookieContainer = cContainer;
//
//			if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
//			sv_goirai.CookieContainer = cContainer;
//
//			if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
//			sv_hinagata.CookieContainer = cContainer;
//
//			if(sv_kiji == null) sv_kiji = new is2kiji.Service1();
//			sv_kiji.CookieContainer = cContainer;
//
//			if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
//			sv_otodoke.CookieContainer = cContainer;
//
//			if(sv_print == null) sv_print = new is2print.Service1();
//			sv_print.CookieContainer = cContainer;
//
//			if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
//			sv_syukka.CookieContainer = cContainer;
//
//			if(sv_seikyuu == null) sv_seikyuu = new is2seikyuu.Service1();
//			sv_seikyuu.CookieContainer = cContainer;
// DEL 2005.05.20 東都）西口 スレッド化 END

// MOD 2005.05.27 東都）高木 起動時間を短くする START
//			try
//			{	
//				// 状態リストを取得
//				if(sv_init == null) sv_init = new is2init.Service1();
////				sv_init.CookieContainer = cContainer;
//				string[] sRet = sv_init.Get_jyotai(gsaユーザ);
//				if( sRet[0].Length == 4 ){
//					int i状態数 = int.Parse(sRet[1]);
//					if(i状態数 > 0)
//					{
//						gsa状態ＣＤ = new string[1 + i状態数];
//						gsa状態名　 = new string[1 + i状態数];
//						gsa状態ＣＤ[0] = "00";
//						gsa状態名[0]   = "全て";
//						int iPos = 2;
//						for(int iCnt = 1; iCnt <= i状態数 && iPos < sRet.Length; iCnt++)
//						{
//							gsa状態ＣＤ[iCnt] = sRet[iPos++];
//							gsa状態名[iCnt]   = sRet[iPos++];
//						}
//					}
//				}
//			}
//			catch (Exception)
//			{
//				// ミューテックスの破棄
//				mutex.Close();
//				Application.Exit();
//				return;
//			}

			// スレッドでは実行できないので、ここで実施
			if(g出荷照会 == null) g出荷照会 = new 出荷照会();
			if(g届先検索 == null) g届先検索 = new お届け先検索();
			if(g依頼検索 == null) g依頼検索 = new ご依頼主検索();
			if(g記事検索 == null) g記事検索 = new 記事検索();
			if(g自動登録 == null) g自動登録 = new 自動出荷登録();
			if(g住所検索 == null) g住所検索 = new 住所検索();
			if(g請求登録 == null) g請求登録 = new 請求先登録();
			if(g未発印刷 == null) g未発印刷 = new 未発行印刷();
// ADD 2006.12.22 東都）小童谷 画面追加 START
			if(gログイン２ == null) gログイン２ = new ログイン２();
// ADD 2006.12.22 東都）小童谷 画面追加 END
// ADD 2007.12.06 KCL) 森本 お知らせ追加 START
			if(gお知表示 == null) gお知表示 = new お知らせ表示();
// ADD 2007.12.06 KCL) 森本 お知らせ追加 END
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 START
			if(g控え印刷 == null) g控え印刷 = new 送り状控え印刷();
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 END

			if(状態情報取得() == false)
			{
// MOD 2009.07.30 東都）高木 exeのdll化対応 START
//				// ミューテックスの破棄
//				mutex.Close();
//				Application.Exit();
// MOD 2009.07.30 東都）高木 exeのdll化対応 END
				return;
			}

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

// MOD 2005.05.27 東都）高木 起動時間を短くする END

// MOD 2009.10.14 東都）高木 config読込など START
//			Application.Run(new メニュー());
			Application.Run(this);
// MOD 2009.10.14 東都）高木 config読込など END
		}

// ADD 2005.05.27 東都）高木 起動時間を短くする START
		private static bool 状態情報取得()
		{
			// 既に取得していた場合には終了
			if(gsa状態ＣＤ.Length > 1 && gsa状態ＣＤ[0].Length > 0) return true;

			try
			{	
				// 状態リストを取得
				if(sv_init == null) sv_init = new is2init.Service1();
				string[] sRet = sv_init.Get_jyotai(gsaユーザ);
				if( sRet[0].Length == 4 ){
					int i状態数 = int.Parse(sRet[1]);
					if(i状態数 > 0)
					{
						gsa状態ＣＤ = new string[1 + i状態数];
						gsa状態名　 = new string[1 + i状態数];
						gsa状態ＣＤ[0] = "00";
						gsa状態名[0]   = "全て";
						int iPos = 2;
						for(int iCnt = 1; iCnt <= i状態数 && iPos < sRet.Length; iCnt++)
						{
							gsa状態ＣＤ[iCnt] = sRet[iPos++];
							gsa状態名[iCnt]   = sRet[iPos++];
						}
					}
				}
			}
// MOD 2005.06.30 東都）高木 通信エラーのメッセージ修正 START
//			catch (Exception)
//			{
//				return false;
//			}
			catch (System.Net.WebException)
			{
				ビープ音();
				MessageBox.Show(gs通信エラー, 
								"通信エラー", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			catch (Exception ex)
			{
				ビープ音();
				MessageBox.Show(ex.Message, 
								"通信エラー", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
// MOD 2005.06.30 東都）高木 通信エラーのメッセージ修正 END

			return true;
		}
// ADD 2005.05.27 東都）高木 起動時間を短くする END

// MOD 2005.05.17 東都）高木 起動時間を短くする START
		static public void 端末情報取得()
		{
			// カーソルを砂時計にする
//			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				// 端末情報の取得（会員ＣＤ・名、プリンタ情報）
				if(sv_init == null) sv_init = new is2init.Service1();
//				texメッセージ.Text = "端末情報取得中．．．";
//				sv_init.CookieContainer = cContainer;
				String[] sRet = sv_init.Get_tanmatsu2(gsaユーザ,gs端末ＣＤ);
//				cContainer = sv_init.CookieContainer;
//				texメッセージ.Text = sRet[0];
				if(sRet[0].Length != 4)
				{
					ビープ音();
					MessageBox.Show(sRet[0],
									"端末情報取得", 
									MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

// MOD 2005.05.17 東都）高木 起動時間を短くする START
//// MOD 2005.05.11 東都）高木 demoユーザの対応 START
////				gs会員ＣＤ     = sRet[1];
////				gsプリンタＦＧ = sRet[2];
////				gsプリンタ種類 = sRet[3];
////				gs会員名       = sRet[4];
//				if(gs会員ＣＤ == "demo")
//				{
//					gsプリンタＦＧ = sRet[2];
//					gsプリンタ種類 = sRet[3];
//				}
//				else
//				{
//					gs会員ＣＤ     = sRet[1];
//					gsプリンタＦＧ = sRet[2];
//					gsプリンタ種類 = sRet[3];
//					gs会員名       = sRet[4];
//				}
//// MOD 2005.05.11 東都）高木 demoユーザの対応 END
				gsプリンタＦＧ = sRet[2];
				gsプリンタ種類 = sRet[3];
// MOD 2005.05.17 東都）高木 起動時間を短くする END
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				ビープ音();
				MessageBox.Show(gs通信エラー, 
								"通信エラー", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				ビープ音();
				MessageBox.Show(ex.Message, 
								"通信エラー", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			// カーソルをデフォルトに戻す
//			Cursor = System.Windows.Forms.Cursors.Default;
		}
// MOD 2005.05.17 東都）高木 起動時間を短くする END

		static private void 利用者情報取得()
		{
			// カーソルを砂時計にする
//			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				// 利用者情報取得の取得（利用者名、部門情報、請求先情報）
				if(sv_init == null) sv_init = new is2init.Service1();
//				texメッセージ.Text = "利用者情報取得中．．．";
//				sv_init.CookieContainer = cContainer;
				String[] sRet = sv_init.Get_riyou(gsaユーザ,gs会員ＣＤ, gs利用者ＣＤ);
//				cContainer = sv_init.CookieContainer;
//				texメッセージ.Text = sRet[0];
				if(sRet[0].Length != 4)
				{
					ビープ音();
					MessageBox.Show(sRet[0],
									"利用者情報取得", 
									MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				gs利用者名     = sRet[1];
				gs部門ＣＤ     = sRet[2];
				gs部門名       = sRet[3];
				gs出荷日       = sRet[4];
				if(gs出荷日.Length == 8)
				{
					gdt出荷日 = new DateTime(int.Parse(gs出荷日.Substring(0,4)), 
											int.Parse(gs出荷日.Substring(4,2)),
											int.Parse(gs出荷日.Substring(6)) );
				}
				gs荷送人ＣＤ   = sRet[5];
				// 部門情報数の取得
				int iCntBumon  = int.Parse(sRet[6]);
				// 請求先情報数の取得
				int iCntTokui  = int.Parse(sRet[7]);
				// 基本情報の最終インデックス
				int iPos = 8;

				// 部門情報の設定
				if(iCntBumon > 0)
				{
					gsa部門ＣＤ = new string[iCntBumon];
					gsa部門名   = new string[iCntBumon];
					gsa出荷日   = new string[iCntBumon];
					gh部門ＣＤ  = new Hashtable();
					for(int iCnt = 0; iCnt < iCntBumon; iCnt++)
					{
						gsa部門ＣＤ[iCnt] = sRet[iPos++];
						gsa部門名[iCnt]   = sRet[iPos++];
						gsa出荷日[iCnt]   = sRet[iPos++];
						gh部門ＣＤ.Add(gsa部門ＣＤ[iCnt],iCnt);
					}
				}
				// 請求先情報の設定
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
// ADD 2005.07.21 東都）高木 店所ユーザ対応 START
				gs権限１ = sRet[sRet.Length -1];
// ADD 2005.07.21 東都）高木 店所ユーザ対応 END
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				ビープ音();
				MessageBox.Show(gs通信エラー, 
								"通信エラー", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				ビープ音();
				MessageBox.Show(ex.Message, 
								"通信エラー", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			// カーソルをデフォルトに戻す
//			Cursor = System.Windows.Forms.Cursors.Default;
		}

// DEL 2007.03.28 東都）高木 集荷店取得エラー対応 START
//// ADD 2006.12.12 東都）小童谷 部門店所取得 START
//		static private void 利用者部門店所取得()
//		{
//			try
//			{
//				// 利用者情報取得の取得（利用者名、部門情報、請求先情報）
//				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
//				String[] sRet = sv_syukka.Get_hatuten2(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
//				if(sRet[0].Length != 4)
//				{
//					ビープ音();
//					MessageBox.Show(sRet[0],
//						"利用者部門店所取得", 
//						MessageBoxButtons.OK, MessageBoxIcon.Error);
//					return;
//				}
//
//				gs部門店所     = sRet[1];
//			}
//			catch (System.Net.WebException)
//			{
//				ビープ音();
//				MessageBox.Show(gs通信エラー, 
//					"通信エラー", 
//					MessageBoxButtons.OK, MessageBoxIcon.Error);
//			}
//			catch (Exception ex)
//			{
//				ビープ音();
//				MessageBox.Show(ex.Message, 
//					"通信エラー", 
//					MessageBoxButtons.OK, MessageBoxIcon.Error);
//			}
//		}
//// ADD 2006.12.12 東都）小童谷 部門店所取得 END
// DEL 2007.03.28 東都）高木 集荷店取得エラー対応 END

		static private void 部門情報取得()
		{
			// カーソルを砂時計にする
//			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				// 部門情報取得の取得
				if(sv_init == null) sv_init = new is2init.Service1();
//				texメッセージ.Text = "部門情報取得中．．．";
//				sv_init.CookieContainer = cContainer;
				String[] sRet = sv_init.Get_bumon(gsaユーザ,gs会員ＣＤ);
//				cContainer = sv_init.CookieContainer;
//				texメッセージ.Text = sRet[0];
				if(sRet[0].Length != 4)
				{
					ビープ音();
					MessageBox.Show(sRet[0],
									"部門情報取得", 
									MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				// 部門情報数の取得
				int iCntBumon  = int.Parse(sRet[1]);
				// 基本情報の最終インデックス
				int iPos = 2;

				// 部門情報の設定
				if(iCntBumon > 0)
				{
					gsa部門ＣＤ = new string[iCntBumon];
					gsa部門名   = new string[iCntBumon];
					gsa出荷日   = new string[iCntBumon];
					gh部門ＣＤ  = new Hashtable();
					for(int iCnt = 0; iCnt < iCntBumon; iCnt++)
					{
						gsa部門ＣＤ[iCnt] = sRet[iPos++];
						gsa部門名[iCnt]   = sRet[iPos++];
						gsa出荷日[iCnt]   = sRet[iPos++];
						gh部門ＣＤ.Add(gsa部門ＣＤ[iCnt],iCnt);
					}
				}
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				ビープ音();
				MessageBox.Show(gs通信エラー, 
								"通信エラー", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				ビープ音();
				MessageBox.Show(ex.Message, 
								"通信エラー", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			// カーソルをデフォルトに戻す
//			Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void メニュー_Load(object sender, System.EventArgs e)
		{
// ADD 2007.10.26 東都）高木 バージョン情報の表示 START
			if(gsaユーザ[3].Length > 0) labバージョン.Text = "Ver." + gsaユーザ[3];
// ADD 2007.10.26 東都）高木 バージョン情報の表示 END
// MOD 2009.10.16 東都）高木 プロキシ機能表記の追加 START
			if(gbInitProxyExists) labバージョン.Text += " p";
// MOD 2009.10.16 東都）高木 プロキシ機能表記の追加 END
			// ヘッダー項目の設定
// DEL 2005.06.02 東都）小童谷 削除 START
//			tex利用者名.Text = gs利用者名;
// DEL 2005.06.02 東都）小童谷 削除 END
			tex部門名.Text   = gs部門ＣＤ + " " + gs部門名;
			tex会員名.Text   = gs会員名;
			// 日時の初期設定
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled = true;
			// メッセージの設定
			labメッセージ.Text = "";
			timメッセージ = new System.Windows.Forms.Timer(this.components);
			timメッセージ.Tick += new System.EventHandler(timメッセージ_Tick);
// MOD 2008.01.30 KCL) 森本 表示スピード変更 START
//// MOD 2007.03.13 FJCS）桑田　表示スピード変更 START
////			timメッセージ.Interval = 100; // 0.1秒
//			timメッセージ.Interval = 50; // 0.05秒
			timメッセージ.Interval = 30; // 0.03秒
//// MOD 2007.03.13 FJCS）桑田　表示スピード変更 END
// MOD 2008.01.30 KCL) 森本 表示スピード変更 END
			timメッセージ.Enabled = true;

			メニューイメージの初期化();
// MOD 2011.04.05 東都）高木 画面イメージのロード変更 START
//// MOD 2011.03.08 東都）高木 王子運送対応（メニュー画面の切替） START
//			if(gs会員ＣＤ.Substring(0,1) != "J"){
//				imageMenu[4,0] = Image.FromFile("img\\upperbar.gif");
//			}else{
//				imageMenu[4,0] = Image.FromFile("img\\upperbar_oji.gif");
//			}
//// MOD 2011.03.08 東都）高木 王子運送対応（メニュー画面の切替） END
			if(gs会員ＣＤ.Substring(0,1) != "J"){
				imageMenu[4,0] = Image_FromFile("img\\upperbar.gif");
			}else{
				imageMenu[4,0] = Image_FromFile("img\\upperbar_oji.gif");
			}
// MOD 2011.04.05 東都）高木 画面イメージのロード変更 END
			コマンドイメージの初期化();

			// メニュー
// MOD 2011.04.05 東都）高木 画面イメージのロード変更 START
//			picホーム.Image       = Image.FromFile("img\\home.gif");
			picホーム.Image       = Image_FromFile("img\\home.gif");
// MOD 2011.04.05 東都）高木 画面イメージのロード変更 END
			picメニュー１.Image   = imageMenu[0,1]; // エントリー
			picメニュー２.Image   = imageMenu[1,0]; // エントリーデータ
			picメニュー３.Image   = imageMenu[2,0]; // アドレス帳
			picメニュー４.Image   = imageMenu[3,0]; // オプション
//			picメニュー５.Image   = imageMenu[6,0]; // 設定
// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
			picメニュー６.Image   = imageMenu[6,0]; // お知らせ
// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
			panメニュー１.Visible = true;
			panメニュー２.Visible = false;
			panメニュー３.Visible = false;
			panメニュー４.Visible = false;
//			panメニュー５.Visible = false;
// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
			panメニュー６.Visible = false;
// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
			pictureBox2.Image     = imageMenu[4,0];
//			pictureBox3.Image     = imageMenu[5,0];
			pictureBox7.Image     = imageMenu[4,1];
			// コマンド
			pic出荷登録.Image         = imageCmd[1,1,0];
			pic雛型出荷登録.Image     = imageCmd[1,2,0];
			pic自動出荷登録.Image     = imageCmd[1,3,0];
			pic送り状荷札発行.Image   = imageCmd[1,4,0];
			picチョイスプリント.Image = imageCmd[1,5,0];
			pic出荷照会.Image         = imageCmd[2,1,0];
			pic出荷実績.Image         = imageCmd[2,2,0];
			pic再発行.Image           = imageCmd[2,3,0];
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 START
			picバーコード読取.Image    = imageCmd[2,4,0];
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 END
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 START
			picラベルイメージ印刷.Image    = imageCmd[2,5,0];
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 END
			picお届け先情報.Image     = imageCmd[3,1,0];
			picお届先取込.Image       = imageCmd[3,2,0];
			picご依頼主情報.Image     = imageCmd[3,3,0];
// MOD 2010.08.27 東都）高木 ご依頼主取込（ＣＳＶ）機能追加 START
			picご依頼主取込.Image     = imageCmd[3,4,0];
// MOD 2010.08.27 東都）高木 ご依頼主取込（ＣＳＶ）機能追加 END
			pic記事情報.Image         = imageCmd[4,1,0];
			pic請求先登録.Image       = imageCmd[4,2,0];
			pic端末情報.Image         = imageCmd[4,3,0];
			pic才数切替.Image         = imageCmd[4,4,0];

// DEL 2008.02.08 KCL) 森本 お知らせ修正 START
//// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
//			picお知らせ１.Image       = imageCmd[5,1,0];
//			picお知らせ２.Image       = imageCmd[5,1,0];
//			picお知らせ３.Image       = imageCmd[5,1,0];
//			picお知らせ４.Image       = imageCmd[5,1,0];
//			picお知らせ５.Image       = imageCmd[5,1,0];
//// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
// DEL 2008.02.08 KCL) 森本 お知らせ修正 END

// DEL 2005.05.27 東都）高木 スレッド位置の移動 START
//// ADD 2005.05.20 東都）西口 スレッド化 START
//			trd = new Thread(new ThreadStart(ThreadTask));
//			trd.IsBackground = true;
//			trd.Start();
//// ADD 2005.05.20 東都）西口 スレッド化 END
// DEL 2005.05.27 東都）高木 スレッド位置の移動 END

// ADD 2005.05.25 東都）高木 ヘルプＵＲＬをconfigから取得 START
// MOD 2009.07.30 東都）高木 exeのdll化対応 START
//			System.Type type = System.Type.GetType("System.String");
//			System.Configuration.AppSettingsReader config = new System.Configuration.AppSettingsReader();
//			sヘルプＵＲＬ = config.GetValue("HelpURL", type).ToString();
// MOD 2009.07.30 東都）高木 exeのdll化対応 END
// ADD 2005.05.25 東都）高木 ヘルプＵＲＬをconfigから取得 END

// ADD 2005.05.31 東都）小童谷 プリンタなしならメニューを消す START
			if(gsプリンタＦＧ == "0")
			{
				pic送り状荷札発行.Visible   = false;
				picチョイスプリント.Visible = false;
				pic再発行.Visible           = false;
			}
			else
			{
				pic送り状荷札発行.Visible   = true;
				picチョイスプリント.Visible = true;
				pic再発行.Visible           = true;
			}
// ADD 2005.05.31 東都）小童谷 プリンタなしならメニューを消す END

			if( b雛型出荷登録 )
			{
// MOD 2005.05.20 東都）伊賀 クイックエントリショートカット対応 START
				if (s雛型出荷登録ＮＯ != null && !s雛型出荷登録ＮＯ.Equals(""))
				{
					出荷登録 画面 = new 出荷登録();
					画面.Left = this.Left;
					画面.Top = this.Top;
					画面.s処理ＦＧ = "I";
					画面.dt雛型出荷日 = new DateTime(int.Parse(gs出荷日.Substring(0,4)), 
											int.Parse(gs出荷日.Substring(4,2)),
											int.Parse(gs出荷日.Substring(6)) );
					画面.b雛型指定日  = false;	//指定なし
					画面.i雛型ＮＯ = int.Parse(s雛型出荷登録ＮＯ);
					画面.ShowDialog(this);
				}
				else
				{
					雛型出荷登録 画面 = new 雛型出荷登録();
					画面.Left = this.Left;
					画面.Top = this.Top;
					画面.ShowDialog(this);
				}
// MOD 2005.05.20 東都）伊賀 クイックエントリショートカット対応 END
			}
// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 START
			if( File.Exists(gsInitSyukka) && gsプリンタＦＧ == "1"){
				btn自動出力        .Visible = true;
				btn自動出力フォルダ.Visible = true;
			}else{
				btn自動出力        .Visible = false;
				btn自動出力フォルダ.Visible = false;
			}
			出荷ＣＳＶ自動出力過去ファイル削除();
// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 END
// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 START
			if(gb自動出力ＯＮ){
				lab自動出力ＯＮ.Visible = true;
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
				pic送り状荷札発行.Visible   = false;
				picチョイスプリント.Visible = false;
				pic再発行.Visible           = false;
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
// MOD 2010.06.01 東都）高木 自動出力ボタンの移動 START
				pic自動出荷登録.Visible     = false;
// MOD 2010.06.01 東都）高木 自動出力ボタンの移動 END
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 START
				picバーコード読取.Visible   = false;
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 END
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 START
				picラベルイメージ印刷.Visible = false;
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 END
			}
			else
			{
				lab自動出力ＯＮ.Visible = false;
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
				if(gsプリンタＦＧ == "1"){
					pic送り状荷札発行.Visible   = true;
					picチョイスプリント.Visible = true;
					pic再発行.Visible           = true;
				}
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 START
				// エントリーオプションに設定した値により、当該ボタンの表示・非表示を切り替える
				if(gsオプション[22].Equals("0"))
				{
					picバーコード読取.Visible = true;
				}
				else
				{
					picバーコード読取.Visible = false;
				}
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 END
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 START
				picラベルイメージ印刷.Visible = true;
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 END
// MOD 2010.06.01 東都）高木 自動出力ボタンの移動 START
				pic自動出荷登録.Visible     = true;
// MOD 2010.06.01 東都）高木 自動出力ボタンの移動 END
			}
// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 END
// MOD 2011.07.14 東都）高木 記事行の追加 START
			iＣＳＶエントリー形式 = 1;
// MOD 2011.07.14 東都）高木 記事行の追加 END
		}

		private void setButtonImage(PictureBox picButton, string sImage)
		{
			try
			{
				picButton.Image = Bitmap.FromFile(sImage);
			}
			catch(System.IO.FileNotFoundException)
			{
				// ファイルが存在しない場合
				picButton.BackColor = Color.PaleGreen;
			}
		}

		private void btn終了_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 START
			端末ごとの初期設定ファイル保存();
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 END
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
// MOD 2011.08.03 東都）高木 終了時に自動出力が無効になる障害対応 START
//			if(gb自動出力ＯＮ) gb自動出力ＯＮ = false;
			bool b自動出力終了時状態 = gb自動出力ＯＮ;
			if(gb自動出力ＯＮ){
				ログ出力２(" 終了時処理 自動出力ＯＦＦ");
				gb自動出力ＯＮ = false;
			}
// MOD 2011.08.03 東都）高木 終了時に自動出力が無効になる障害対応 END
//			if(g自動登録 != null){
				if(trd1 != null && trd1.IsAlive){
					//５秒まで待つ
					for(int iCnt = 0;iCnt < 5; iCnt++){
						if(trd1 == null) break;
						if(trd1.IsAlive == false) break;
						Thread.Sleep(1000); // 1秒待つ
					}
				}
				while(trd1 != null && trd1.IsAlive){
					if(trd1 != null && trd1.IsAlive){
						ビープ音();
						DialogResult dlgRst = MessageBox.Show(
							"自動出力が実行中ですが強制終了しますか？\n"
							+ "（[いいえ]の場合は、６０秒まで待ちます）"
							, "終了"
							, MessageBoxButtons.YesNo
							, MessageBoxIcon.Warning);
						if(dlgRst == DialogResult.Yes){
							break;
						}
					}
					//６０秒まで待つ
					for(int iCnt = 0;iCnt < 60; iCnt++){
						if(trd1 == null) break;
						if(trd1.IsAlive == false) break;
						Thread.Sleep(1000); // 1秒待つ
					}
				}
//			}
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
			i終了ＦＧ = 0;
			if(gsプリンタＦＧ == "1")
			{
// MOD 2005.06.30 東都）高木 通信エラーのメッセージ修正 START
//				未出荷データ発行();
				try
				{
					未出荷データ発行();
				}
				catch (System.Net.WebException)
				{
					ビープ音();
					MessageBox.Show(gs通信エラー, 
									"通信エラー", 
									MessageBoxButtons.OK, MessageBoxIcon.Error);
					i終了ＦＧ = 1;
				}
				catch (Exception ex)
				{
					ビープ音();
					MessageBox.Show(ex.Message, 
									"通信エラー", 
									MessageBoxButtons.OK, MessageBoxIcon.Error);
					i終了ＦＧ = 1;
				}
				// カーソルをデフォルトに戻す
				Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2005.06.30 東都）高木 通信エラーのメッセージ修正 END
			}
			else
			{
				DialogResult result = MessageBox.Show("終了しますか？", "終了", 
					MessageBoxButtons.YesNo);
// MOD 2011.08.03 東都）高木 終了時に自動出力が無効になる障害対応 START
//				if (result == DialogResult.Yes)
//					Application.Exit();
//				else
//					return;
				if(result == DialogResult.Yes){
					Application.Exit();
				}else{
					if(b自動出力終了時状態){
						ログ出力２(" 終了時処理 自動出力ＯＮ");
						gb自動出力ＯＮ = true;
					}
					return;
				}
// MOD 2011.08.03 東都）高木 終了時に自動出力が無効になる障害対応 END
			}

			if(i終了ＦＧ == 0)
			{
//				Application.Exit();
// MOD 2007.02.08 東都）高木 クライアントアプリの高速化 START
//// ADD 2005.06.30 東都）小童谷 端末マスタ更新 START
//				try
//				{
//					if(sv_init == null) sv_init = new is2init.Service1();
//					string[] sRet = sv_init.Upd_tanmatu(gsaユーザ,gs利用者ＣＤ);
//					Application.Exit();
//				}
//				catch
//				{
//					Application.Exit();
//				}
//// ADD 2005.06.30 東都）小童谷 端末マスタ更新 END
				Application.Exit();
// MOD 2007.02.08 東都）高木 クライアントアプリの高速化 END
			}
			else
			{
				DialogResult result = MessageBox.Show("終了しますか？", "終了", 
					MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
				{
//					Application.Exit();
// MOD 2007.02.08 東都）高木 クライアントアプリの高速化 START
//// ADD 2005.06.30 東都）小童谷 端末マスタ更新 START
//					try
//					{
//						if(sv_init == null) sv_init = new is2init.Service1();
//						string[] sRet = sv_init.Upd_tanmatu(gsaユーザ,gs利用者ＣＤ);
//						Application.Exit();
//					}
//					catch
//					{
//						Application.Exit();
//					}
//// ADD 2005.06.30 東都）小童谷 端末マスタ更新 END
					Application.Exit();
// MOD 2007.02.08 東都）高木 クライアントアプリの高速化 END
// MOD 2011.08.03 東都）高木 終了時に自動出力が無効になる障害対応 START
				}else{
					if(b自動出力終了時状態){
						ログ出力２(" 終了時処理 自動出力ＯＮ");
						gb自動出力ＯＮ = true;
					}
// MOD 2011.08.03 東都）高木 終了時に自動出力が無効になる障害対応 END
				}
			}
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

		// このイベントの発生間隔　　0.01秒
		// （メッセージ内容更新間隔（サーバ通信間隔　　30分）
		private void timメッセージ_Tick(object sender, System.EventArgs e)
		{
			if(bメッセージ更新中) return;
			bメッセージ更新中 = true;

			if(iメッセージ更新ＣＮＴ == 0){
				string[] sRet = {""};
				try
				{
					if(sv_init == null) sv_init = new is2init.Service1();
					sRet = sv_init.Get_message(gsaユーザ, gs会員ＣＤ, gs部門ＣＤ);
					if(sRet[0].Length == 4){
// MOD 2005.05.24 東都）高木 システムメッセージの追加 START
//// MOD 2005.05.09 東都）高木 メッセージの変更 START
////						gsメッセージ = new String('　',25) + "★お知らせ★　"
////									 + sRet[1] + "　　　" + sRet[2];
//						gsメッセージ = new String('　',25) + "★お知らせ★　"
//									 + sRet[1];
//						if(sRet[1].Length == 0 && sRet[2].Length == 0)
//						{
//							labメッセージ.Text = "";
//						}
//						else if(sRet[1].Length > 0 && sRet[2].Length > 0)
//						{
//							gsメッセージ += "　　　";
//						}
//						gsメッセージ += sRet[2];
//// MOD 2005.05.09 東都）高木 メッセージの変更 END
						if(sRet[1].Length == 0 && sRet[2].Length == 0 && sRet[3].Length == 0)
						{
							gsメッセージ       = "";
							labメッセージ.Text = "";
// MOD 2016.01.15 BEVAS) 松本 WinXP非対応に伴う該当端末への注意文表示対応 START
							if(gsOSVer.StartsWith("5"))
							{
								//ログイン端末のＯＳがVistaよりも前の場合、テロップを表示する
								string s非対応メッセージ = s非対応メッセージ = "ご利用のパソコンは、ｉＳＴＡＲ－２サポート対象外ＯＳとなります。詳しくは、お知らせ「【重要】Ｗｉｎｄｏｗｓ　ＸＰ以前の端末をご利用のお客様へ」をご覧下さい。";
								gsメッセージ = new String('　', 31) + "★お知らせ★　" + s非対応メッセージ;
							}
// MOD 2016.01.15 BEVAS) 松本 WinXP非対応に伴う該当端末への注意文表示対応 END
						}
						else
						{
//							gsメッセージ = new String('　',25) + "★お知らせ★　" + sRet[1];
							gsメッセージ = new String('　',31) + "★お知らせ★　" + sRet[1];
							if(sRet[2].Length > 0)
							{
								if(sRet[1].Length > 0)
									gsメッセージ += "　　　";
								gsメッセージ += sRet[2];
							}
							if(sRet[3].Length > 0)
							{
								if(sRet[1].Length > 0 || sRet[2].Length > 0)
									gsメッセージ += "　　　";
								gsメッセージ += sRet[3];
							}
						}
// MOD 2005.05.24 東都）高木 システムメッセージの追加 END
					}
// MOD 2016.01.15 BEVAS) 松本 WinXP非対応に伴う該当端末への注意文表示対応 START
					if(gsメッセージ.IndexOf("ご利用のパソコンは、") >= 0)
					{
						//ログイン端末のＯＳがVistaよりも前
						labメッセージ.ForeColor = Color.Crimson;
						labメッセージ.Font = new Font(labメッセージ.Font, FontStyle.Bold);
					}
					else
					{
						labメッセージ.ForeColor = SystemColors.ControlText;
						labメッセージ.Font = new Font(
							"ＭＳ ゴシック",
							15.75F,
							System.Drawing.FontStyle.Regular,
							System.Drawing.GraphicsUnit.Point,
							((System.Byte)(128)));
					}
// MOD 2016.01.15 BEVAS) 松本 WinXP非対応に伴う該当端末への注意文表示対応 END
				}
				catch (Exception)
				{
					;
				}
			}
			iメッセージ更新ＣＮＴ++;
// MOD 2008.01.30 KCL) 森本 表示スピード変更 START
////			if(iメッセージ更新ＣＮＴ == 6000){
//			////////////////////////////////////////////
//			// メッセージ更新間隔
//			// 36000 x 0.05 → 1800秒 → 30分
//			////////////////////////////////////////////
//			if(iメッセージ更新ＣＮＴ == 36000)
			////////////////////////////////////////////
			// メッセージ更新間隔
			// cnt_limit x Interval → 1800秒 → 30分
			////////////////////////////////////////////
			int cnt_limit = 1800000 / timメッセージ.Interval;
			if(iメッセージ更新ＣＮＴ == cnt_limit)
// MOD 2008.01.30 KCL) 森本 表示スピード変更 END
			{
				iメッセージ更新ＣＮＴ = 0;
			}
			bメッセージ更新中 = false;

//			if(gsメッセージ.Length > 32)
			if(gsメッセージ.Length > 31+7)
			{
				iメッセージＣＮＴ++;
//				if(iメッセージＣＮＴ <=  9)
//				if(iメッセージＣＮＴ <= 18)
				if(iメッセージＣＮＴ <= 10)
				{
//					labメッセージ.Visible = false;
					labメッセージ.Left -= 2;
//					labメッセージ.Left -= 1;
//					labメッセージ.Visible = true;
				}
				else
				{
					if(iメッセージ表示位置 < gsメッセージ.Length)
						iメッセージ表示位置++;
					else
						iメッセージ表示位置 = 0;
					labメッセージ.Visible = false;
//					labメッセージ.Left += 18;
					labメッセージ.Left += 20;
//					if(gsメッセージ.Length - iメッセージ表示位置 < 25)
					if(gsメッセージ.Length - iメッセージ表示位置 < 31)
						labメッセージ.Text = gsメッセージ.Substring(iメッセージ表示位置);
					else
//						labメッセージ.Text = gsメッセージ.Substring(iメッセージ表示位置,25);
						labメッセージ.Text = gsメッセージ.Substring(iメッセージ表示位置,31);
					labメッセージ.Visible = true;
					iメッセージＣＮＴ = 0;
				}
			}
		}

		private void pic出荷登録_Click(object sender, System.EventArgs e)
		{
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
			重量入力制御取得();
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
// ADD 2005.05.11 東都）高木 請求先が０件時の対応 START
			if(!請求先情報取得()) return;
// ADD 2005.05.11 東都）高木 請求先が０件時の対応 END

// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			出荷登録 画面 = new 出荷登録();
//			画面.Left = this.Left;
//			画面.Top = this.Top;
//			画面.s処理ＦＧ = "I";
//			this.Visible = false;
//			画面.ShowDialog(this);
//			this.Visible = true;
			if (g出荷登録 == null)	 g出荷登録 = new 出荷登録();
			g出荷登録.Left = this.Left;
			g出荷登録.Top = this.Top;
			g出荷登録.s処理ＦＧ = "I";
			g出荷登録.i雛型ＮＯ = 0;
			this.Visible = false;
			g出荷登録.ShowDialog(this);
			this.Visible = true;
// MOD 2005.05.24 東都）小童谷 画面高速化 END
		}

		private void pic雛型出荷登録_Click(object sender, System.EventArgs e)
		{
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
			重量入力制御取得();
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
// ADD 2005.05.11 東都）高木 請求先が０件時の対応 START
			if(!請求先情報取得()) return;
// ADD 2005.05.11 東都）高木 請求先が０件時の対応 END

// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			雛型出荷登録 画面 = new 雛型出荷登録();
//			画面.Left = this.Left;
//			画面.Top = this.Top;
//			this.Visible = false;
//			画面.ShowDialog(this);
//			this.Visible = true;
			if (g雛出登録 == null)	 g雛出登録 = new 雛型出荷登録();
			g雛出登録.Left = this.Left;
			g雛出登録.Top = this.Top;
			this.Visible = false;
			g雛出登録.ShowDialog(this);
			this.Visible = true;
// MOD 2005.05.24 東都）小童谷 画面高速化 END
		}

		private void pic送り状荷札発行_Click(object sender, System.EventArgs e)
		{
//保留 MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
//保留			重量入力制御取得();
//保留 MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
			if(gsプリンタＦＧ != "1") return;
// MOD 2005.06.08 東都）小童谷 メッセージの順番の変更 START
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
			if(gb自動出力ＯＮ) return;
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
//			DialogResult result = MessageBox.Show("未発行のラベルを全て発行します", "ラベル印刷", 
//				MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
//			if (result == DialogResult.OK)
//			{
// MOD 2005.06.30 東都）高木 通信エラーのメッセージ修正 START
//				送り状荷札発行();
				try
				{
					送り状荷札発行();
				}
				catch (System.Net.WebException)
				{
					ビープ音();
					MessageBox.Show(gs通信エラー, 
									"通信エラー", 
									MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception ex)
				{
					ビープ音();
					MessageBox.Show(ex.Message, 
									"通信エラー", 
									MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				// カーソルをデフォルトに戻す
				Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2005.06.30 東都）高木 通信エラーのメッセージ修正 END
//			}
// MOD 2005.06.08 東都）小童谷 メッセージの順番の変更 END
		}

		private void picチョイスプリント_Click(object sender, System.EventArgs e)
		{
//保留 MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
//保留			重量入力制御取得();
//保留 MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
			if(gsプリンタＦＧ != "1") return;
// MOD 2005.05.24 東都）小童谷 画面高速化 START
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
			if(gb自動出力ＯＮ) return;
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
//			未発行印刷 画面 = new 未発行印刷();
//			画面.Left = this.Left;
//			画面.Top = this.Top;
			//未発行
//			画面.sタイトル   = "チョイスプリント";
//			画面.s状態種別 = gsa状態ＣＤ[1];
//			this.Visible = false;
//			画面.ShowDialog(this);
//			this.Visible = true;
			if (g未発印刷 == null)	 g未発印刷 = new 未発行印刷();
			g未発印刷.Left = this.Left;
			g未発印刷.Top = this.Top;
			g未発印刷.sタイトル  = "チョイスプリント";
			g未発印刷.s状態種別  = gsa状態ＣＤ[1];
			this.Visible = false;
			g未発印刷.ShowDialog(this);
			this.Visible = true;
// MOD 2005.05.24 東都）小童谷 画面高速化 END
		}

		private void pic再発行_Click(object sender, System.EventArgs e)
		{
//保留 MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
//保留			重量入力制御取得();
//保留 MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
			if(gsプリンタＦＧ != "1") return;
// MOD 2005.05.24 東都）小童谷 画面高速化 START
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
			if(gb自動出力ＯＮ) return;
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
//			未発行印刷 画面 = new 未発行印刷();
//			画面.Left = this.Left;
//			画面.Top = this.Top;
			//発行済
//			画面.sタイトル   = "再発行";
//			画面.s状態種別 = "aa";
//			this.Visible = false;
//			画面.ShowDialog(this);
//			this.Visible = true;
			if (g未発印刷 == null)	 g未発印刷 = new 未発行印刷();
			g未発印刷.Left = this.Left;
			g未発印刷.Top = this.Top;
			g未発印刷.sタイトル  = "再発行";
			g未発印刷.s状態種別  = "aa";
			this.Visible = false;
			g未発印刷.ShowDialog(this);
			this.Visible = true;
// MOD 2005.05.24 東都）小童谷 画面高速化 END
		}

		private void pic出荷照会_Click(object sender, System.EventArgs e)
		{
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
			重量入力制御取得();
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
// MOD 2005.05.20 東都）西口 画面高速化 START
//			出荷照会 画面 = new 出荷照会();
//			画面.Left = this.Left;
//			画面.Top = this.Top;
//			this.Visible = false;
//			画面.ShowDialog(this);
//			this.Visible = true;
			if (g出荷照会 == null)	 g出荷照会 = new 出荷照会();
			g出荷照会.Left = this.Left;
			g出荷照会.Top = this.Top;
			this.Visible = false;
			g出荷照会.ShowDialog(this);
			this.Visible = true;
// MOD 2005.05.20 東都）西口 画面高速化 END
		}

		private void pic出荷実績_Click(object sender, System.EventArgs e)
		{
//保留 MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
//保留			重量入力制御取得();
//保留 MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
			if (g出荷実績 == null)	 g出荷実績 = new 出荷実績();
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 START
//			g出荷実績.Left = this.Left + (this.Width  - g出荷実績.Width)  / 2;
//			g出荷実績.Top  = this.Top  + (this.Height - g出荷実績.Height) / 2;
// MOD 2010.02.04 東都）高木 出荷実績画面のセンタリング START
//			g出荷実績.Left = this.Left;
			g出荷実績.Left = this.Left + (this.Width  - g出荷実績.Width)  / 2;
// MOD 2010.02.04 東都）高木 出荷実績画面のセンタリング END
			g出荷実績.Top  = this.Top;
// MOD 2009.11.06 東都）高木 検索条件に請求先、お届け先、お客様番号を追加 END
			g出荷実績.ShowDialog();
		}

// ADD 2005.05.20 東都）伊賀 自動出荷登録追加の対応 START
		private void pic自動出荷登録_Click(object sender, System.EventArgs e)
		{
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
			重量入力制御取得();
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			自動出荷登録 画面 = new 自動出荷登録();
//			画面.Left = this.Left;
//			画面.Top = this.Top;
//			this.Visible = false;
//			画面.ShowDialog(this);
//			this.Visible = true;
// MOD 2010.06.01 東都）高木 自動出力ボタンの移動 START
			if(gb自動出力ＯＮ) return;
// MOD 2010.06.01 東都）高木 自動出力ボタンの移動 END
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
			if (g自動登録 == null)	 g自動登録 = new 自動出荷登録();
			g自動登録.Left = this.Left;
			g自動登録.Top = this.Top;
			this.Visible = false;
			g自動登録.ShowDialog(this);
// MOD 2010.06.01 東都）高木 自動出力ボタンの移動 START
//// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 START
//			if(gb自動出力ＯＮ){
//				lab自動出力ＯＮ.Visible = true;
//// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//				pic送り状荷札発行.Visible   = false;
//				picチョイスプリント.Visible = false;
//				pic再発行.Visible           = false;
//// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
//			}else{
//				lab自動出力ＯＮ.Visible = false;
//// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//				if(gsプリンタＦＧ == "1"){
//					pic送り状荷札発行.Visible   = true;
//					picチョイスプリント.Visible = true;
//					pic再発行.Visible           = true;
//				}
//// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
//			}
//// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 END
// MOD 2010.06.01 東都）高木 自動出力ボタンの移動 END
			this.Visible = true;
// MOD 2005.05.24 東都）小童谷 画面高速化 END
		}
// ADD 2005.05.20 東都）伊賀 自動出荷登録追加の対応 END

		private void picお届け先情報_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			お届け先登録 画面 = new お届け先登録();
//			画面.Left = this.Left;
//			画面.Top = this.Top;
//			this.Visible = false;
//			画面.ShowDialog(this);
//			this.Visible = true;
			if (g届先登録 == null)	 g届先登録 = new お届け先登録();
			g届先登録.Left = this.Left;
			g届先登録.Top = this.Top;
			this.Visible = false;
			g届先登録.ShowDialog(this);
			this.Visible = true;
// MOD 2005.05.24 東都）小童谷 画面高速化 END
		}

		private void picご依頼主情報_Click(object sender, System.EventArgs e)
		{
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
			重量入力制御取得();
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
			if(!請求先情報取得()) return;

// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			ご依頼主登録 画面 = new ご依頼主登録();
//			画面.Left = this.Left;
//			画面.Top = this.Top;
//			this.Visible = false;
//			画面.ShowDialog(this);
//			this.Visible = true;
			if (g依頼登録 == null)	 g依頼登録 = new ご依頼主登録();
			g依頼登録.Left = this.Left;
			g依頼登録.Top = this.Top;
			g依頼登録.ShowInTaskbar = true;
			this.Visible = false;
			g依頼登録.ShowDialog(this);
			this.Visible = true;
// MOD 2005.05.24 東都）小童谷 画面高速化 END
		}

// MOD 2010.08.27 東都）高木 ご依頼主取込（ＣＳＶ）機能追加 START
		private void picご依頼主取込_Click(object sender, System.EventArgs e)
		{
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
			重量入力制御取得();
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END
			//エラーメッセージのクリア
			texメッセージ.Text = "";
			if(!請求先情報取得()) return;

			if (g依頼取込 == null)	 g依頼取込 = new ご依頼主取込();
			g依頼取込.Left = this.Left;
			g依頼取込.Top = this.Top;
			g依頼取込.ShowInTaskbar = true;
			this.Visible = false;
			g依頼取込.ShowDialog(this);
			this.Visible = true;
		}
// MOD 2010.08.27 東都）高木 ご依頼主取込（ＣＳＶ）機能追加 END

		private bool 請求先情報取得()
		{
// ADD 2005.05.11 東都）高木 請求先が０件時の対応 START
			int iCntTokui  = 0;
// ADD 2005.05.11 東都）高木 請求先が０件時の対応 END
			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sRet = {""};
			try
			{
				texメッセージ.Text = "請求先情報取得中．．．";
				// 請求先情報の取得（gs会員ＣＤ、gs部門ＣＤ）
				if(sv_init == null) sv_init = new is2init.Service1();
				sRet = sv_init.Get_seikyu(gsaユーザ,gs会員ＣＤ, gs部門ＣＤ);
				texメッセージ.Text = "";

				// 請求先情報数の取得
// MOD 2005.05.11 東都）高木 請求先が０件時の対応 START
//				int iCntTokui  = int.Parse(sRet[1]);
				iCntTokui  = int.Parse(sRet[1]);
// MOD 2005.05.11 東都）高木 請求先が０件時の対応 END
				// 基本情報の最終インデックス
				int iPos = 2;

				// 請求先情報の設定
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
// ADD 2005.05.24 東都）高木 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				sRet[0] = gs通信エラー;
			}
// ADD 2005.05.24 東都）高木 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				sRet[0] = "通信エラー：" + ex.Message;
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;

			if(sRet[0].Length != 4)
			{
				MessageBox.Show(sRet[0], "請求先情報取得", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
// ADD 2005.05.11 東都）高木 請求先が０件時の対応 START
			else if(iCntTokui == 0)
			{
				MessageBox.Show("まず請求先の登録をお願い致します。",
					"請求先情報取得", MessageBoxButtons.OK, MessageBoxIcon.Error);
				pic請求先登録_Click(null, null);
				return false;
			}
// ADD 2005.05.11 東都）高木 請求先が０件時の対応 END

			return true;
		}

		private void pic記事情報_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			記事検索 画面 = new 記事検索();
//			画面.Left = this.Left + (this.Width - 画面.Width) / 2;
//			画面.Top  = this.Top;
			// タイトルの変更
//			画面.Text                = "is-2 記事登録";
//			画面.lab記事タイトル.Text = "記事登録";
			// ADD 2005.05.16 東都）伊賀 品名記事 START
//			画面.b輸送指示 = false;
			// ADD 2005.05.16 東都）伊賀 品名記事 END
//			画面.ShowDialog();
			if (g記事検索 == null)	 g記事検索 = new 記事検索();
//			g記事検索.Left = this.Left + (this.Width - g記事検索.Width) / 2;
// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
//			g記事検索.Left = this.Left + (this.Width - 396) / 2;
			g記事検索.Left = this.Left + (this.Width - g記事検索.Width) / 2;
// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 END
			g記事検索.Top = this.Top;
			g記事検索.Text                 = "is-2 記事登録";
			g記事検索.lab記事タイトル.Text = "記事登録";
			g記事検索.b輸送指示 = false;
			g記事検索.ShowDialog(this);
// MOD 2005.05.24 東都）小童谷 画面高速化 END
		}

		private void pic端末情報_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
// ADD 2005.07.21 東都）高木 店所ユーザ対応 START
			// 店所ユーザは端末変更不可
			if(gs権限１ == "T")
			{
				MessageBox.Show("現在のユーザでは変更できません。", "端末情報", 
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
// ADD 2005.07.21 東都）高木 店所ユーザ対応 END

			端末情報取得();
// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			端末登録 画面 = new 端末登録();
//			画面.Left = this.Left + (this.Width  - 画面.Width)  / 2;
//			画面.Top  = this.Top  + (this.Height - 画面.Height) / 2;
//			画面.ShowDialog();
			if (g端末登録 == null)	 g端末登録 = new 端末登録();
			g端末登録.Left = this.Left + (this.Width  - g端末登録.Width)  / 2;
			g端末登録.Top  = this.Top  + (this.Height - g端末登録.Height) / 2;
			g端末登録.ShowDialog(this);
// MOD 2005.05.24 東都）小童谷 画面高速化 END
// ADD 2005.05.31 東都）小童谷 プリンタなしならメニューを消す START
			if(gsプリンタＦＧ == "0")
			{
				pic送り状荷札発行.Visible   = false;
				picチョイスプリント.Visible = false;
				pic再発行.Visible           = false;
			}
			else
			{
				pic送り状荷札発行.Visible   = true;
				picチョイスプリント.Visible = true;
				pic再発行.Visible           = true;
			}
// ADD 2005.05.31 東都）小童谷 プリンタなしならメニューを消す END
// MOD 2010.06.01 東都）高木 自動出力ボタンの移動 START
			if( File.Exists(gsInitSyukka) && gsプリンタＦＧ == "1"){
				btn自動出力        .Visible = true;
				btn自動出力フォルダ.Visible = true;
			}else{
				btn自動出力        .Visible = false;
				btn自動出力フォルダ.Visible = false;

				gb自動出力ＯＮ              = false;
				ログ出力２(" 自動出力ＯＦＦ");
				btn自動出力.Text = "自動出力 ON";
				lab自動出力ＯＮ.Visible = false;
				pic自動出荷登録.Visible     = true;
			}
			if(gb自動出力ＯＮ){
				pic送り状荷札発行.Visible   = false;
				picチョイスプリント.Visible = false;
				pic再発行.Visible           = false;
			}
// MOD 2010.06.01 東都）高木 自動出力ボタンの移動 END
		}

		private void pic請求先登録_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			請求先登録 画面 = new 請求先登録();
//			画面.Left = this.Left + (this.Width - 画面.Width) / 2;
//			画面.Top = this.Top;
//			画面.ShowDialog();
			if (g請求登録 == null)	 g請求登録 = new 請求先登録();
			g請求登録.Left = this.Left + (this.Width - g請求登録.Width) / 2;
			g請求登録.Top  = this.Top;
			g請求登録.ShowDialog(this);
// MOD 2005.05.24 東都）小童谷 画面高速化 END
		}

		private void pic才数切替_Click(object sender, System.EventArgs e)
		{
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
			重量入力制御取得();
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			才数切り替え 画面 = new 才数切り替え();
//			画面.Left = this.Left + (this.Width  - 画面.Width)  / 2;
//			画面.Top  = this.Top  + (this.Height - 画面.Height) / 2;
//			画面.ShowDialog();
			if (g才数切替 == null)	 g才数切替 = new 才数切り替え();
// MOD 2010.05.24 東都）高木 120DPI対応時の表示位置調整 START
//			g才数切替.Left = this.Left + (this.Width  - g才数切替.Width)  / 2;
//			g才数切替.Top  = this.Top  + (this.Height - g才数切替.Height) / 2;
			g才数切替.Left = this.Left;
			g才数切替.Top  = this.Top;
// MOD 2010.05.24 東都）高木 120DPI対応時の表示位置調整 END
			g才数切替.ShowDialog(this);
// MOD 2005.05.24 東都）小童谷 画面高速化 END
// MOD 2009.05.01 東都）高木 オプションの項目追加 START
			オプション情報取得();
// MOD 2009.05.01 東都）高木 オプションの項目追加 END
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 START
			//エントリーオプションに設定した値と自動出力がＯＮかどうかにより、
			//当該ボタンの表示・非表示を切り替える
			if(gb自動出力ＯＮ)
			{
				//自動出力がＯＮ → ボタンは必ず非表示
				picバーコード読取.Visible = false;
			}
			else
			{
				//自動出力がＯＦＦ
				if(gsオプション[22].Equals("0"))
				{
					picバーコード読取.Visible = true;
				}
				else
				{
					picバーコード読取.Visible = false;
				}
			}
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 END
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
			重量入力制御取得();
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END
		}

		private void btnパスワード変更_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			パスワード変更 画面 = new パスワード変更();
//			画面.Left = this.Left;
//			画面.Top = this.Bottom - 画面.Height;
//			画面.Left = this.Left + (this.Width  - 画面.Width)  / 2;
//			画面.Top  = this.Top  + (this.Height - 画面.Height) / 2;
//			画面.ShowDialog();
			if (gパス変更 == null)	 gパス変更 = new パスワード変更();
			gパス変更.Left = this.Left + (this.Width  - gパス変更.Width)  / 2;
			gパス変更.Top  = this.Top  + (this.Height - gパス変更.Height) / 2;
			gパス変更.ShowDialog(this);
// MOD 2005.05.24 東都）小童谷 画面高速化 END
		}

		private void btn部門変更_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
			部門情報取得();
//			部門変更 画面 = new 部門変更();
//			画面.Left = this.Left;
// MOD 2005.05.20 東都）西口 画面高速化 START
//			部門変更２ 画面 = new 部門変更２();
//			画面.Left = this.Left + (this.Width - 画面.Width) / 2;
//			画面.Top = this.Top + 68;
//			画面.ShowDialog();
			if (g部門変更 == null)	 g部門変更 = new 部門変更２();

			g部門変更.Left = this.Left + (this.Width - g部門変更.Width) / 2;
			g部門変更.Top = this.Top + 68;
// MOD 2016.05.24 BEVAS）松本 セクション切替画面改修対応 START
			g部門変更.s部門コード = "";
			g部門変更.s部門名 = "";
// MOD 2016.05.24 BEVAS）松本 セクション切替画面改修対応 END
			g部門変更.ShowDialog();
// MOD 2005.05.20 東都）西口 画面高速化 END
// ADD 2009.04.02 東都）高木 稼働日対応 START
			稼働日情報取得();
// ADD 2009.04.02 東都）高木 稼働日対応 END
// MOD 2009.05.01 東都）高木 オプションの項目追加 START
			オプション情報取得();
// MOD 2009.05.01 東都）高木 オプションの項目追加 END
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
			重量入力制御取得();
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END

			// ヘッダー項目の設定
// DEL 2005.06.02 東都）小童谷 削除 START
//			tex利用者名.Text = gs利用者名;
// DEL 2005.06.02 東都）小童谷 削除 END
// DEL 2005.05.13 東都）小童谷 会員名に変更 START
//			tex部門名.Text   = gs部門ＣＤ + " " + gs部門名;
// DEL 2005.05.13 東都）小童谷 会員名に変更 END

// ADD 2005.05.09 東都）高木 メッセージの変更 START
			// メッセージの取得を行う
			iメッセージ更新ＣＮＴ = 0;
// ADD 2005.05.09 東都）高木 メッセージの変更 END
// ADD 2006.12.12 東都）小童谷 セクション名変更 START
			tex部門名.Text   = gs部門ＣＤ + " " + gs部門名;
// ADD 2006.12.12 東都）小童谷 セクション名変更 END
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 START
			//エントリーオプションに設定した値と自動出力がＯＮかどうかにより、
			//当該ボタンの表示・非表示を切り替える
			if(gb自動出力ＯＮ)
			{
				//自動出力がＯＮ → ボタンは必ず非表示
				picバーコード読取.Visible = false;
			}
			else
			{
				//自動出力がＯＦＦ
				if(gsオプション[22].Equals("0"))
				{
					picバーコード読取.Visible = true;
				}
				else
				{
					picバーコード読取.Visible = false;
				}
			}
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 END
		}

		private void picお届先取込_MouseEnter(object sender, System.EventArgs e)
		{
			picお届先取込.Image        = imageCmd[3,2,1];
		}

		private void picお届先取込_MouseLeave(object sender, System.EventArgs e)
		{
			picお届先取込.Image        = imageCmd[3,2,0];
		}

		private void picお届先取込_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			お届け先取込 画面 = new お届け先取込();
//			画面.Left = this.Left;
//			画面.Top = this.Top;
//			this.Visible = false;
//			画面.ShowDialog(this);
//			this.Visible = true;
			if (g届先取込 == null)	 g届先取込 = new お届け先取込();
			g届先取込.Left = this.Left;
			g届先取込.Top = this.Top;
			this.Visible = false;
			g届先取込.ShowDialog(this);
			this.Visible = true;
// MOD 2005.05.24 東都）小童谷 画面高速化 END
		}
// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
		private string [] お知らせ詳細内容取得(string s登録日, string sシーケンスＮｏ) 
		{
			string [] sResults = new string[3];

			// 引数設定
			string [] sKey = new string [2];
			sKey[0] = s登録日;
			sKey[1] = sシーケンスＮｏ;

			// お知らせ情報取得
			string [] sRet = null;
			try
			{
				if (sv_oshirase == null) sv_oshirase = new IS2Client.is2oshirase.Service1();
				sRet = sv_oshirase.Sel_Oshirase(gsaユーザ, sKey);
			}
			catch (System.Net.WebException)
			{
				// 通信エラー発生
				sRet[0] = gs通信エラー;
			}
			catch (Exception ex)
			{
				// その他のエラー発生
				sRet[0] = "通信エラー：" + ex.Message;
			}

			// 結果処理
			switch (sRet[0].Trim()) 
			{
				case "正常終了" :	// 正常終了の場合

					// 詳細内容、ボタン名、アドレスを返す
					sResults[0] = sRet[3].Replace("\n", "\r\n");		// 詳細内容
					sResults[1] = sRet[4];								// ボタン名
					sResults[2] = sRet[5];								// アドレス

					break;

				default :			// 異常終了の場合

					// 空文字列を返す
					sResults[0] = sResults[1] = sResults[2] = string.Empty;
					// 警告音
					ビープ音();
					// エラーメッセージ表示
					texメッセージ.Text = sRet[0];

					break;
			}

			return sResults;
		}
		private void picお知らせ１_Click(object sender, System.EventArgs e)
		{
			if (sお知らせ一覧.Length > 0) 
			{
				this.お知らせ詳細表示(1);
			}
		}

		private void picお知らせ２_Click(object sender, System.EventArgs e)
		{
			if (sお知らせ一覧.Length > 1) 
			{
				this.お知らせ詳細表示(2);
			}
		}

		private void picお知らせ３_Click(object sender, System.EventArgs e)
		{
			if (sお知らせ一覧.Length > 2) 
			{
				this.お知らせ詳細表示(3);
			}
		}

		private void picお知らせ４_Click(object sender, System.EventArgs e)
		{
			if (sお知らせ一覧.Length > 3) 
			{
				this.お知らせ詳細表示(4);
			}
		}

		private void picお知らせ５_Click(object sender, System.EventArgs e)
		{
			if (sお知らせ一覧.Length > 4) 
			{
				this.お知らせ詳細表示(5);
			}
		}

		private void お知らせ詳細表示(int no) 
		{
			int idx = no - 1;

			if (gお知表示 == null) gお知表示 = new お知らせ表示();
			gお知表示.s登録日	= sお知らせ一覧[idx][0];
			gお知表示.s表題		= sお知らせ一覧[idx][1];
			string [] naiyo		= this.お知らせ詳細内容取得(sお知らせ一覧[idx][2], sお知らせ一覧[idx][3]);
			gお知表示.s詳細内容	= naiyo[0];
			gお知表示.sボタン名  = naiyo[1];
			gお知表示.sアドレス	= naiyo[2];
			gお知表示.Top		= this.Top;
			gお知表示.Left		= this.Left;
			this.Visible		= false;
			gお知表示.ShowDialog(this);
			this.Visible		= true;
		}
// ADD 2007.11.30 KCL) 森本 お知らせ追加 END

		private void pic出荷登録_MouseEnter(object sender, System.EventArgs e)
		{
			pic出荷登録.Image        = imageCmd[1,1,1];
		}

		private void pic出荷登録_MouseLeave(object sender, System.EventArgs e)
		{
			pic出荷登録.Image        = imageCmd[1,1,0];
		}

		private void pic雛型出荷登録_MouseEnter(object sender, System.EventArgs e)
		{
			pic雛型出荷登録.Image    = imageCmd[1,2,1];
		}

		private void pic雛型出荷登録_MouseLeave(object sender, System.EventArgs e)
		{
			pic雛型出荷登録.Image    = imageCmd[1,2,0];
		}

		private void pic送り状荷札発行_MouseEnter(object sender, System.EventArgs e)
		{
			pic送り状荷札発行.Cursor = Cursors.Default;
			if(gsプリンタＦＧ != "1") return;
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
			if(gb自動出力ＯＮ) return;
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
			pic送り状荷札発行.Cursor = Cursors.Hand;
			pic送り状荷札発行.Image  = imageCmd[1,4,1];
		}

		private void pic送り状荷札発行_MouseLeave(object sender, System.EventArgs e)
		{
			if(gsプリンタＦＧ != "1") return;
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
			if(gb自動出力ＯＮ) return;
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
			pic送り状荷札発行.Image  = imageCmd[1,4,0];
		}

		private void picチョイスプリント_MouseEnter(object sender, System.EventArgs e)
		{
			picチョイスプリント.Cursor = Cursors.Default;
			if(gsプリンタＦＧ != "1") return;
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
			if(gb自動出力ＯＮ) return;
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
			picチョイスプリント.Cursor = Cursors.Hand;
			picチョイスプリント.Image  = imageCmd[1,5,1];
		}

		private void picチョイスプリント_MouseLeave(object sender, System.EventArgs e)
		{
			if(gsプリンタＦＧ != "1") return;
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
			if(gb自動出力ＯＮ) return;
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
			picチョイスプリント.Image  = imageCmd[1,5,0];
		}

		private void pic再発行_MouseEnter(object sender, System.EventArgs e)
		{
			pic再発行.Cursor = Cursors.Default;
			if(gsプリンタＦＧ != "1") return;
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
			if(gb自動出力ＯＮ) return;
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
			pic再発行.Cursor = Cursors.Hand;
			pic再発行.Image  = imageCmd[2,3,1];
		}

		private void pic再発行_MouseLeave(object sender, System.EventArgs e)
		{
			if(gsプリンタＦＧ != "1") return;
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
			if(gb自動出力ＯＮ) return;
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
			pic再発行.Image  = imageCmd[2,3,0];
		}

		private void pic出荷照会_MouseEnter(object sender, System.EventArgs e)
		{
			pic出荷照会.Image        = imageCmd[2,1,1];
		}

		private void pic出荷照会_MouseLeave(object sender, System.EventArgs e)
		{
			pic出荷照会.Image        = imageCmd[2,1,0];
		}

		private void pic出荷実績_MouseEnter(object sender, System.EventArgs e)
		{
			pic出荷実績.Image        = imageCmd[2,2,1];
		}

		private void pic出荷実績_MouseLeave(object sender, System.EventArgs e)
		{
			pic出荷実績.Image        = imageCmd[2,2,0];
		}

		private void pic自動出荷登録_MouseEnter(object sender, System.EventArgs e)
		{
			pic自動出荷登録.Image    = imageCmd[1,3,1];
		}

		private void pic自動出荷登録_MouseLeave(object sender, System.EventArgs e)
		{
			pic自動出荷登録.Image    = imageCmd[1,3,0];
		}

		private void picお届け先情報_MouseEnter(object sender, System.EventArgs e)
		{
			picお届け先情報.Image    = imageCmd[3,1,1];
		}

		private void picお届け先情報_MouseLeave(object sender, System.EventArgs e)
		{
			picお届け先情報.Image    = imageCmd[3,1,0];
		}

		private void picご依頼主情報_MouseEnter(object sender, System.EventArgs e)
		{
			picご依頼主情報.Image    = imageCmd[3,3,1];
		}

		private void picご依頼主情報_MouseLeave(object sender, System.EventArgs e)
		{
			picご依頼主情報.Image    = imageCmd[3,3,0];
		}
// MOD 2010.08.27 東都）高木 ご依頼主取込（ＣＳＶ）機能追加 START
		private void picご依頼主取込_MouseEnter(object sender, System.EventArgs e)
		{
			picご依頼主取込.Image    = imageCmd[3,4,1];
		}

		private void picご依頼主取込_MouseLeave(object sender, System.EventArgs e)
		{
			picご依頼主取込.Image    = imageCmd[3,4,0];
		}
// MOD 2010.08.27 東都）高木 ご依頼主取込（ＣＳＶ）機能追加 END

		private void pic記事情報_MouseEnter(object sender, System.EventArgs e)
		{
			pic記事情報.Image        = imageCmd[4,1,1];
		}

		private void pic記事情報_MouseLeave(object sender, System.EventArgs e)
		{
			pic記事情報.Image        = imageCmd[4,1,0];
		}

		private void pic端末情報_MouseEnter(object sender, System.EventArgs e)
		{
			pic端末情報.Image        = imageCmd[4,3,1];
		}

		private void pic端末情報_MouseLeave(object sender, System.EventArgs e)
		{
			pic端末情報.Image        = imageCmd[4,3,0];
		}

		private void pic請求先登録_MouseEnter(object sender, System.EventArgs e)
		{
			pic請求先登録.Image      = imageCmd[4,2,1];
		}

		private void pic請求先登録_MouseLeave(object sender, System.EventArgs e)
		{
			pic請求先登録.Image      = imageCmd[4,2,0];
		}

		private void pic才数切替_MouseEnter(object sender, System.EventArgs e)
		{
			pic才数切替.Image        = imageCmd[4,4,1];
		}

		private void pic才数切替_MouseLeave(object sender, System.EventArgs e)
		{
			pic才数切替.Image        = imageCmd[4,4,0];
		}

// DEL 2008.02.08 KCL) 森本 お知らせ修正 START
//// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
//		private void picお知らせ１_MouseEnter(object sender, System.EventArgs e)
//		{
//			picお知らせ１.Image        = imageCmd[5,1,1];
//			labお知らせ１.ForeColor    = this._SelectedColor;
//		}
//
//		private void picお知らせ１_MouseLeave(object sender, System.EventArgs e)
//		{
//			picお知らせ１.Image        = imageCmd[5,1,0];
//			labお知らせ１.ForeColor    = this._UnSelectedColor1;
//		}
//
//		private void picお知らせ２_MouseEnter(object sender, System.EventArgs e)
//		{
//			picお知らせ２.Image        = imageCmd[5,1,1];
//			labお知らせ２.ForeColor    = this._SelectedColor;
//		}
//
//		private void picお知らせ２_MouseLeave(object sender, System.EventArgs e)
//		{
//			picお知らせ２.Image        = imageCmd[5,1,0];
//			labお知らせ２.ForeColor    = this._UnSelectedColor2;
//		}
//
//		private void picお知らせ３_MouseEnter(object sender, System.EventArgs e)
//		{
//			picお知らせ３.Image        = imageCmd[5,1,1];
//			labお知らせ３.ForeColor    = this._SelectedColor;
//		}
//
//		private void picお知らせ３_MouseLeave(object sender, System.EventArgs e)
//		{
//			picお知らせ３.Image        = imageCmd[5,1,0];
//			labお知らせ３.ForeColor    = this._UnSelectedColor1;
//		}
//
//		private void picお知らせ４_MouseEnter(object sender, System.EventArgs e)
//		{
//			picお知らせ４.Image        = imageCmd[5,1,1];
//			labお知らせ４.ForeColor    = this._SelectedColor;
//		}
//
//		private void picお知らせ４_MouseLeave(object sender, System.EventArgs e)
//		{
//			picお知らせ４.Image        = imageCmd[5,1,0];
//			labお知らせ４.ForeColor    = this._UnSelectedColor2;
//		}
//
//		private void picお知らせ５_MouseEnter(object sender, System.EventArgs e)
//		{
//			picお知らせ５.Image        = imageCmd[5,1,1];
//			labお知らせ５.ForeColor    = this._SelectedColor;
//		}
//
//		private void picお知らせ５_MouseLeave(object sender, System.EventArgs e)
//		{
//			picお知らせ５.Image        = imageCmd[5,1,0];
//			labお知らせ５.ForeColor    = this._UnSelectedColor1;
//		}
//// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
// DEL 2008.02.08 KCL) 森本 お知らせ修正 START


		private void picメニュー１_MouseEnter(object sender, System.EventArgs e)
		{
			picメニュー１.Image = imageMenu[0,1];
		}

		private void picメニュー１_MouseLeave(object sender, System.EventArgs e)
		{
			if(panメニュー１.Visible == false)
				picメニュー１.Image = imageMenu[0,0];
		}

		private void picメニュー２_MouseEnter(object sender, System.EventArgs e)
		{
			picメニュー２.Image = imageMenu[1,1];
		}

		private void picメニュー２_MouseLeave(object sender, System.EventArgs e)
		{
			if(panメニュー２.Visible == false)
				picメニュー２.Image = imageMenu[1,0];
		}

		private void picメニュー３_MouseEnter(object sender, System.EventArgs e)
		{
			picメニュー３.Image = imageMenu[2,1];
		}

		private void picメニュー３_MouseLeave(object sender, System.EventArgs e)
		{
			if(panメニュー３.Visible == false)
				picメニュー３.Image = imageMenu[2,0];
		}

		private void picメニュー４_MouseEnter(object sender, System.EventArgs e)
		{
			picメニュー４.Image = imageMenu[3,1];
		}

		private void picメニュー４_MouseLeave(object sender, System.EventArgs e)
		{
			if(panメニュー４.Visible == false)
				picメニュー４.Image = imageMenu[3,0];
		}

/*		private void picメニュー５_MouseEnter(object sender, System.EventArgs e)
		{
			picメニュー５.Image = imageMenu[6,1];
		}

		private void picメニュー５_MouseLeave(object sender, System.EventArgs e)
		{
			if(panメニュー５.Visible == false)
				picメニュー５.Image = imageMenu[6,0];
		}
*/
// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
		private void picメニュー６_MouseEnter(object sender, System.EventArgs e) 
		{
			picメニュー６.Image = imageMenu[6,1];
		}
		private void picメニュー６_MouseLeave(object sender, System.EventArgs e) 
		{
			if(panメニュー６.Visible == false)
				picメニュー６.Image = imageMenu[6,0];
		}
// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
		private void picメニュー１_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
			if(gsお知らせ案内メッセージ.Length > 0){
				texメッセージ.Text = gsお知らせ案内メッセージ;
			}
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END
			picメニュー１.Image   = imageMenu[0,1];
			picメニュー２.Image   = imageMenu[1,0];
			picメニュー３.Image   = imageMenu[2,0];
			picメニュー４.Image   = imageMenu[3,0];
//			picメニュー５.Image   = imageMenu[6,0];
// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
			picメニュー６.Image   = imageMenu[6,0];
// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
			panメニュー１.Visible = true;
			panメニュー２.Visible = false;
			panメニュー３.Visible = false;
			panメニュー４.Visible = false;
//			panメニュー５.Visible = false;
// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
			panメニュー６.Visible = false;
// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
		}

		private void picメニュー２_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
			if(gsお知らせ案内メッセージ.Length > 0){
				texメッセージ.Text = gsお知らせ案内メッセージ;
			}
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END
			picメニュー１.Image   = imageMenu[0,0];
			picメニュー２.Image   = imageMenu[1,1];
			picメニュー３.Image   = imageMenu[2,0];
			picメニュー４.Image   = imageMenu[3,0];
//			picメニュー５.Image   = imageMenu[6,0];
// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
			picメニュー６.Image   = imageMenu[6,0];
// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
			panメニュー１.Visible = false;
			panメニュー２.Visible = true;
			panメニュー３.Visible = false;
			panメニュー４.Visible = false;
//			panメニュー５.Visible = false;
// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
			panメニュー６.Visible = false;
// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
		}

		private void picメニュー３_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
			if(gsお知らせ案内メッセージ.Length > 0){
				texメッセージ.Text = gsお知らせ案内メッセージ;
			}
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END
			picメニュー１.Image   = imageMenu[0,0];
			picメニュー２.Image   = imageMenu[1,0];
			picメニュー３.Image   = imageMenu[2,1];
			picメニュー４.Image   = imageMenu[3,0];
//			picメニュー５.Image   = imageMenu[6,0];
// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
			picメニュー６.Image   = imageMenu[6,0];
// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
			panメニュー１.Visible = false;
			panメニュー２.Visible = false;
			panメニュー３.Visible = true;
			panメニュー４.Visible = false;
//			panメニュー５.Visible = false;
// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
			panメニュー６.Visible = false;
// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
		}

		private void picメニュー４_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
			if(gsお知らせ案内メッセージ.Length > 0){
				texメッセージ.Text = gsお知らせ案内メッセージ;
			}
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END
			picメニュー１.Image   = imageMenu[0,0];
			picメニュー２.Image   = imageMenu[1,0];
			picメニュー３.Image   = imageMenu[2,0];
			picメニュー４.Image   = imageMenu[3,1];
//			picメニュー５.Image   = imageMenu[6,0];
// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
			picメニュー６.Image   = imageMenu[6,0];
// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
			panメニュー１.Visible = false;
			panメニュー２.Visible = false;
			panメニュー３.Visible = false;
			panメニュー４.Visible = true;
//			panメニュー５.Visible = false;
// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
			panメニュー６.Visible = false;
// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
		}

/*		private void picメニュー５_Click(object sender, System.EventArgs e)
		{
			picメニュー１.Image   = imageMenu[0,0];
			picメニュー２.Image   = imageMenu[1,0];
			picメニュー３.Image   = imageMenu[2,0];
			picメニュー４.Image   = imageMenu[3,0];
			picメニュー５.Image   = imageMenu[6,1];
			panメニュー１.Visible = false;
			panメニュー２.Visible = false;
			panメニュー３.Visible = false;
			panメニュー４.Visible = false;
			panメニュー５.Visible = true;
		}
*/
// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
		private void picメニュー６_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
			if(gsお知らせ案内メッセージ.Length > 0){
				texメッセージ.Text = gsお知らせ案内メッセージ;
			}
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END
			picメニュー１.Image   = imageMenu[0,0];
			picメニュー２.Image   = imageMenu[1,0];
			picメニュー３.Image   = imageMenu[2,0];
			picメニュー４.Image   = imageMenu[3,0];
			picメニュー６.Image   = imageMenu[6,1];
			panメニュー１.Visible = false;
			panメニュー２.Visible = false;
			panメニュー３.Visible = false;
			panメニュー４.Visible = false;
			panメニュー６.Visible = true;

			// お知らせの設定
			this.お知らせの取得と表示();
		}
// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
// MOD 2005.05.27 東都）高木 スレッド位置の移動 START
//		private void メニューイメージの初期化()
		private static void メニューイメージの初期化()
// MOD 2005.05.27 東都）高木 スレッド位置の移動 END
		{
			if(imageMenu != null) return;

//			imageMenu = new Image[4,2];
// MOD 2007.11.30 KCL) 森本 お知らせ追加 START
//			imageMenu = new Image[6,2];
			imageMenu = new Image[8,2];
// MOD 2007.11.30 KCL) 森本 お知らせ追加 END
// MOD 2011.04.05 東都）高木 画面イメージのロード変更 START
//			imageMenu[0,0] = Image.FromFile("img\\m1a.gif");
//			imageMenu[0,1] = Image.FromFile("img\\m1b.gif");
//			imageMenu[1,0] = Image.FromFile("img\\m2a.gif");
//			imageMenu[1,1] = Image.FromFile("img\\m2b.gif");
//			imageMenu[2,0] = Image.FromFile("img\\m3a.gif");
//			imageMenu[2,1] = Image.FromFile("img\\m3b.gif");
//			imageMenu[3,0] = Image.FromFile("img\\m4a.gif");
//			imageMenu[3,1] = Image.FromFile("img\\m4b.gif");
//			imageMenu[4,0] = Image.FromFile("img\\upperbar.gif");
//			imageMenu[4,1] = Image.FromFile("img\\sidebar.gif");
//			imageMenu[5,0] = Image.FromFile("img\\i-start.gif");
////		imageMenu[6,0] = Image.FromFile("img\\m5a.gif");
////		imageMenu[6,1] = Image.FromFile("img\\m5b.gif");
//// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
//			imageMenu[6,0] = Image.FromFile("img\\m6a.gif");
//			imageMenu[6,1] = Image.FromFile("img\\m6b.gif");
//// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
			imageMenu[0,0] = Image_FromFile("img\\m1a.gif");
			imageMenu[0,1] = Image_FromFile("img\\m1b.gif");
			imageMenu[1,0] = Image_FromFile("img\\m2a.gif");
			imageMenu[1,1] = Image_FromFile("img\\m2b.gif");
			imageMenu[2,0] = Image_FromFile("img\\m3a.gif");
			imageMenu[2,1] = Image_FromFile("img\\m3b.gif");
			imageMenu[3,0] = Image_FromFile("img\\m4a.gif");
			imageMenu[3,1] = Image_FromFile("img\\m4b.gif");
			imageMenu[4,0] = Image_FromFile("img\\upperbar.gif");
			imageMenu[4,1] = Image_FromFile("img\\sidebar.gif");
			imageMenu[5,0] = Image_FromFile("img\\i-start.gif");
			imageMenu[6,0] = Image_FromFile("img\\m6a.gif");
			imageMenu[6,1] = Image_FromFile("img\\m6b.gif");
// MOD 2011.04.05 東都）高木 画面イメージのロード変更 END
		}

// MOD 2005.05.27 東都）高木 スレッド位置の移動 START
//		private void コマンドイメージの初期化()
		private static void コマンドイメージの初期化()
// MOD 2005.05.27 東都）高木 スレッド位置の移動 END
		{
			if(imageCmd != null) return;

			// 本来は、[5,5,2]でよいがＰＧ上見やすくする為[5,6,2]とした
// MOD 2008.02.08 KCL) 森本 お知らせ修正 START
//// MOD 2007.11.30 KCL) 森本 お知らせ追加 START
////			imageCmd = new Image[5,6,2];
//			imageCmd = new Image[6,6,2];
//// MOD 2007.11.30 KCL) 森本 お知らせ追加 END
			imageCmd = new Image[5,6,2];
// MOD 2008.02.08 KCL) 森本 お知らせ修正 END
// MOD 2011.04.05 東都）高木 画面イメージのロード変更 START
//			imageCmd[1,1,0] = Image.FromFile("img\\m101a.gif");
//			imageCmd[1,1,1] = Image.FromFile("img\\m101b.gif");
//			imageCmd[1,2,0] = Image.FromFile("img\\m102a.gif");
//			imageCmd[1,2,1] = Image.FromFile("img\\m102b.gif");
//			imageCmd[1,3,0] = Image.FromFile("img\\m103a.gif");
//			imageCmd[1,3,1] = Image.FromFile("img\\m103b.gif");
//			imageCmd[1,4,0] = Image.FromFile("img\\m104a.gif");
//			imageCmd[1,4,1] = Image.FromFile("img\\m104b.gif");
//			imageCmd[1,5,0] = Image.FromFile("img\\m105a.gif");
//			imageCmd[1,5,1] = Image.FromFile("img\\m105b.gif");
//
//			imageCmd[2,1,0] = Image.FromFile("img\\m201a.gif");
//			imageCmd[2,1,1] = Image.FromFile("img\\m201b.gif");
//			imageCmd[2,2,0] = Image.FromFile("img\\m202a.gif");
//			imageCmd[2,2,1] = Image.FromFile("img\\m202b.gif");
//			imageCmd[2,3,0] = Image.FromFile("img\\m203a.gif");
//			imageCmd[2,3,1] = Image.FromFile("img\\m203b.gif");
//
//			imageCmd[3,1,0] = Image.FromFile("img\\m301a.gif");
//			imageCmd[3,1,1] = Image.FromFile("img\\m301b.gif");
//			imageCmd[3,2,0] = Image.FromFile("img\\m302a.gif");
//			imageCmd[3,2,1] = Image.FromFile("img\\m302b.gif");
//			imageCmd[3,3,0] = Image.FromFile("img\\m303a.gif");
//			imageCmd[3,3,1] = Image.FromFile("img\\m303b.gif");
//// MOD 2010.08.27 東都）高木 ご依頼主取込（ＣＳＶ）機能追加 START
//			imageCmd[3,4,0] = Image.FromFile("img\\m304a.gif");
//			imageCmd[3,4,1] = Image.FromFile("img\\m304b.gif");
//// MOD 2010.08.27 東都）高木 ご依頼主取込（ＣＳＶ）機能追加 END
//			imageCmd[4,1,0] = Image.FromFile("img\\m401a.gif");
//			imageCmd[4,1,1] = Image.FromFile("img\\m401b.gif");
//			imageCmd[4,2,0] = Image.FromFile("img\\m402a.gif");
//			imageCmd[4,2,1] = Image.FromFile("img\\m402b.gif");
//			imageCmd[4,3,0] = Image.FromFile("img\\m403a.gif");
//			imageCmd[4,3,1] = Image.FromFile("img\\m403b.gif");
//			imageCmd[4,4,0] = Image.FromFile("img\\m404a.gif");
//			imageCmd[4,4,1] = Image.FromFile("img\\m404b.gif");
			imageCmd[1,1,0] = Image_FromFile("img\\m101a.gif");
			imageCmd[1,1,1] = Image_FromFile("img\\m101b.gif");
			imageCmd[1,2,0] = Image_FromFile("img\\m102a.gif");
			imageCmd[1,2,1] = Image_FromFile("img\\m102b.gif");
			imageCmd[1,3,0] = Image_FromFile("img\\m103a.gif");
			imageCmd[1,3,1] = Image_FromFile("img\\m103b.gif");
			imageCmd[1,4,0] = Image_FromFile("img\\m104a.gif");
			imageCmd[1,4,1] = Image_FromFile("img\\m104b.gif");
			imageCmd[1,5,0] = Image_FromFile("img\\m105a.gif");
			imageCmd[1,5,1] = Image_FromFile("img\\m105b.gif");

			imageCmd[2,1,0] = Image_FromFile("img\\m201a.gif");
			imageCmd[2,1,1] = Image_FromFile("img\\m201b.gif");
			imageCmd[2,2,0] = Image_FromFile("img\\m202a.gif");
			imageCmd[2,2,1] = Image_FromFile("img\\m202b.gif");
			imageCmd[2,3,0] = Image_FromFile("img\\m203a.gif");
			imageCmd[2,3,1] = Image_FromFile("img\\m203b.gif");
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 START
			imageCmd[2,4,0] = Image_FromFile("img\\m204a.gif");
			imageCmd[2,4,1] = Image_FromFile("img\\m204b.gif");
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 END
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 START
			imageCmd[2,5,0] = Image_FromFile("img\\m205a.gif");
			imageCmd[2,5,1] = Image_FromFile("img\\m205b.gif");
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 END

			imageCmd[3,1,0] = Image_FromFile("img\\m301a.gif");
			imageCmd[3,1,1] = Image_FromFile("img\\m301b.gif");
			imageCmd[3,2,0] = Image_FromFile("img\\m302a.gif");
			imageCmd[3,2,1] = Image_FromFile("img\\m302b.gif");
			imageCmd[3,3,0] = Image_FromFile("img\\m303a.gif");
			imageCmd[3,3,1] = Image_FromFile("img\\m303b.gif");
			imageCmd[3,4,0] = Image_FromFile("img\\m304a.gif");
			imageCmd[3,4,1] = Image_FromFile("img\\m304b.gif");
			imageCmd[4,1,0] = Image_FromFile("img\\m401a.gif");
			imageCmd[4,1,1] = Image_FromFile("img\\m401b.gif");
			imageCmd[4,2,0] = Image_FromFile("img\\m402a.gif");
			imageCmd[4,2,1] = Image_FromFile("img\\m402b.gif");
			imageCmd[4,3,0] = Image_FromFile("img\\m403a.gif");
			imageCmd[4,3,1] = Image_FromFile("img\\m403b.gif");
			imageCmd[4,4,0] = Image_FromFile("img\\m404a.gif");
			imageCmd[4,4,1] = Image_FromFile("img\\m404b.gif");
// MOD 2011.04.05 東都）高木 画面イメージのロード変更 END
//			imageCmd[4,5,0] = Image.FromFile("img\\m405a.gif");
//			imageCmd[4,5,1] = Image.FromFile("img\\m405b.gif");
//			imageCmd[5,1,0] = Image.FromFile("img\\m501a.gif");
//			imageCmd[5,1,1] = Image.FromFile("img\\m501b.gif");
//			imageCmd[5,2,0] = Image.FromFile("img\\m502a.gif");
//			imageCmd[5,2,1] = Image.FromFile("img\\m502b.gif");

// DEL 2008.02.08 KCL) 森本 お知らせ修正 START
//// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
//			imageCmd[5,1,0] = Image.FromFile("img\\m601a.gif");
//			imageCmd[5,1,1] = Image.FromFile("img\\m601b.gif");
//// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
// DEL 2008.02.08 KCL) 森本 お知らせ修正 END
		}

		private void 送り状荷札発行()
		{
			texメッセージ.Text = "";

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

			if(sv_print == null) sv_print = new is2print.Service1();

			//対象データの取得
			String[] sKey = new string[2];
			sKey[0] = gs会員ＣＤ;
			sKey[1] = gs部門ＣＤ;

			IEnumerator iEnum = sv_print.Get_ShippedUnpublished(gsaユーザ,sKey).GetEnumerator();
			iEnum.MoveNext();
			string[] sData = (string[])iEnum.Current;
			if (sData[0].Equals("正常終了"))
			{
// MOD 2005.06.08 東都）小童谷 メッセージの順番の変更 START
				Cursor = System.Windows.Forms.Cursors.Default;
				DialogResult result = MessageBox.Show("未発行のラベルを全て発行します", "ラベル印刷", 
					MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
				if (result == DialogResult.OK)
				{
					Cursor = System.Windows.Forms.Cursors.AppStarting;
					texメッセージ.Text = "ラベル印刷中．．．";
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） START
//					ds送り状.Clear();
					送り状データクリア();
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） END

// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 START
					int iCnt = 0;
// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 END
					while(iEnum.MoveNext())
					{
// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 START
						iCnt++;
						texメッセージ.Text = "ラベルデータ編集中．．．" + iCnt + "件目";
						texメッセージ.Refresh();
// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 END
						try
						{
							sData = (string[])iEnum.Current;
							送り状印刷指示(sData);
// ADD 2006.12.12 東都）小童谷 店所と部門店所が異なる場合は、印刷しない START
							if(!gb印刷)
							{
								texメッセージ.Text = "";
// MOD 2007.2.19 FJCS）桑田 メッセージ変更 START
//								MessageBox.Show("発店が違います。印刷できません。","送状印刷"
								MessageBox.Show("集荷店が違います。印刷できません。","送状印刷"
// MOD 2007.2.19 FJCS）桑田 メッセージ変更 END
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
// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 START
					texメッセージ.Text = "ラベル印刷中．．．";
					texメッセージ.Refresh();
// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 END
					送り状帳票印刷();
				}
// MOD 2005.06.08 東都）小童谷 メッセージの順番の変更 END

				texメッセージ.Text = "";
			}
			else
			{
				if(sData[0].Equals("送り状はすべて印刷済です。"))
				{
					MessageBox.Show("送り状はすべて印刷済です", "ラベル印刷", 
						MessageBoxButtons.OK);
				}
				else
				{
					texメッセージ.Text = sData[0];
				}
			}
			Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void 未出荷データ発行()
		{
//			try
//			{
//				プリンタチェック();
//			}
//			catch(Exception ex)
//			{
//// MOD 2005.05.31 東都）小童谷 メッセージボックスに変更 START
////				texメッセージ.Text = ex.Message;
//				ビープ音();
//				MessageBox.Show(ex.Message, "プリンタチェック", 
//					MessageBoxButtons.OK, MessageBoxIcon.Information);
//				i終了ＦＧ = 1;
//// MOD 2005.05.31 東都）小童谷 メッセージボックスに変更 END
//				return;
//			}
			Cursor = System.Windows.Forms.Cursors.AppStarting;

			if(sv_print == null) sv_print = new is2print.Service1();

			DialogResult result;
			//対象データの取得
			String[] sKey = new string[2];
			sKey[0] = gs会員ＣＤ;
			sKey[1] = gs部門ＣＤ;

			IEnumerator iEnum = sv_print.Get_Unpublished(gsaユーザ,sKey).GetEnumerator();
			iEnum.MoveNext();
			string[] sData = (string[])iEnum.Current;
			if (sData[0].Equals("正常終了"))
			{
				i終了ＦＧ = 0;
				result = MessageBox.Show("印刷が済んでいない出荷データがあります\r\n今すぐ印刷しますか？", "ラベル印刷", 
					MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (result != DialogResult.Yes) return;

// MOD 2005.06.11 東都）小童谷 プリンタチェック移動 START
				try
				{
					プリンタチェック();
				}
				catch(Exception ex)
				{
// MOD 2005.05.31 東都）小童谷 メッセージボックスに変更 START
//				texメッセージ.Text = ex.Message;
					ビープ音();
					MessageBox.Show(ex.Message, "プリンタチェック", 
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					i終了ＦＧ = 1;
// MOD 2005.05.31 東都）小童谷 メッセージボックスに変更 END
					return;
				}
// MOD 2005.06.11 東都）小童谷 プリンタチェック移動 END

				texメッセージ.Text = "ラベル印刷中．．．";

// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） START
//				ds送り状.Clear();
				送り状データクリア();
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） END

// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 START
				int iCnt = 0;
// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 END
				while(iEnum.MoveNext())
				{
// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 START
					iCnt++;
					texメッセージ.Text = "ラベルデータ編集中．．．" + iCnt + "件目";
					texメッセージ.Refresh();
// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 END
					try
					{
						sData = (string[])iEnum.Current;
						送り状印刷指示(sData);
// ADD 2006.12.12 東都）小童谷 店所と部門店所が異なる場合は、印刷しない START
						if(!gb印刷)
						{
							texメッセージ.Text = "";
							Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2007.2.19 FJCS）桑田 メッセージ変更 START
//							MessageBox.Show("発店が違います。印刷できません。","送状印刷"
							MessageBox.Show("集荷店が違います。印刷できません。","送状印刷"
// MOD 2007.2.19 FJCS）桑田 メッセージ変更 END
								,MessageBoxButtons.OK);
							return;
						}
// ADD 2006.12.12 東都）小童谷 店所と部門店所が異なる場合は、印刷しない END
					}
					catch (Exception ex)
					{
// MOD 2005.05.31 東都）小童谷 メッセージボックスに変更 START
//						texメッセージ.Text = ex.Message;
//						ビープ音();
						ビープ音();
						MessageBox.Show(ex.Message, "ラベル印刷エラー", 
							MessageBoxButtons.OK, MessageBoxIcon.Error);
						i終了ＦＧ = 1;
// MOD 2005.05.31 東都）小童谷 メッセージボックスに変更 END
						return;
					}
				}

				送り状帳票印刷();

				texメッセージ.Text = "";
				Cursor = System.Windows.Forms.Cursors.Default;
			}
			else
			{
				Cursor = System.Windows.Forms.Cursors.Default;
// ADD 2005.05.31 東都）小童谷 エラー時 START
				if (!sData[0].Equals("送り状はすべて印刷済です。"))
				{
					ビープ音();
					MessageBox.Show(sData[0], "ラベル印刷エラー", 
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
// ADD 2005.05.31 東都）小童谷 エラー時 END
				i終了ＦＧ = 1;
			}
		}

// ADD 2005.05.20 東都）西口 スレッド化 START
		private static  void ThreadTask()
		{
// ADD 2005.05.27 東都）高木 スレッド位置の移動 START
// MOD 2009.10.14 東都）高木 config読込など START
//			if(sv_init     == null) sv_init     = new is2init.Service1();
// MOD 2009.10.14 東都）高木 config読込など END
			メニューイメージの初期化();
			コマンドイメージの初期化();
// ADD 2005.05.27 東都）高木 スレッド位置の移動 END
// DEL 2005.06.10 東都）高木 起動時間を短くする START
//// ADD 2005.05.27 東都）高木 起動時間を短くする START
//			bool bRet = 状態情報取得();
//// ADD 2005.05.27 東都）高木 起動時間を短くする END
// DEL 2005.06.10 東都）高木 起動時間を短くする END
// MOD 2009.10.14 東都）高木 config読込など START
//			if(sv_address  == null) sv_address  = new is2address.Service1();
//			if(sv_goirai   == null) sv_goirai   = new is2goirai.Service1();
//			if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
//			if(sv_kiji     == null) sv_kiji     = new is2kiji.Service1();
//			if(sv_otodoke  == null) sv_otodoke  = new is2otodoke.Service1();
//			if(sv_print    == null) sv_print    = new is2print.Service1();
//			if(sv_syukka   == null) sv_syukka   = new is2syukka.Service1();
//			if(sv_seikyuu  == null) sv_seikyuu  = new is2seikyuu.Service1();
//// ADD 2007.12.11 KCL) 森本 お知らせ追加 START
//			if(sv_oshirase == null) sv_oshirase = new is2oshirase.Service1();
//// ADD 2007.12.11 KCL) 森本 お知らせ追加 END
// MOD 2009.10.14 東都）高木 config読込など END

// ADD 2005.05.24 東都）高木 画面遷移の高速化 START
// MOD 2016.05.24 BEVAS）松本 セクション切替画面改修対応 START
			//スプレッドシート使用により、コメント化
//			if(g部門変更 == null) g部門変更 = new 部門変更２();
// MOD 2016.05.24 BEVAS）松本 セクション切替画面改修対応 END
			if(gアイコン == null) gアイコン = new アイコン選択();
			if(g届先取込 == null) g届先取込 = new お届け先取込();
			if(g届先登録 == null) g届先登録 = new お届け先登録();
			if(g届先登小 == null) g届先登小 = new お届け先登録小();
			if(g依頼登録 == null) g依頼登録 = new ご依頼主登録();
			if(gパス変更 == null) gパス変更 = new パスワード変更();
			if(g才数切替 == null) g才数切替 = new 才数切り替え();
			if(g出荷登録 == null) g出荷登録 = new 出荷登録();
			if(g雛出登録 == null) g雛出登録 = new 雛型出荷登録();
			if(g雛型登録 == null) g雛型登録 = new 雛型登録();
			if(g端末登録 == null) g端末登録 = new 端末登録();
			if(g指定時間入力 == null) g指定時間入力 = new 指定時間入力();
			if(g出荷実績 == null) g出荷実績 = new 出荷実績();
// 保留 スプレッドシートがあるものは、下記のエラーがでる
//	'System.Reflection.TargetInvocationException' のハンドルされていない例外が 
//	system.windows.forms.dll で発生しました。
//	追加情報 : 'AxGTable32' コントロールのウィンドウ ハンドルを取得できません。
//	ウィンドウなしの ActiveX コントロールはサポートされていません。
//
//			if(g出荷照会 == null) g出荷照会 = new 出荷照会();
//			if(g届先検索 == null) g届先検索 = new お届け先検索();
//			if(g依頼検索 == null) g依頼検索 = new ご依頼主検索();
//			if(g記事検索 == null) g記事検索 = new 記事検索();
//			if(g自動登録 == null) g自動登録 = new 自動出荷登録();
//			if(g住所検索 == null) g住所検索 = new 住所検索();
//			if(g請求登録 == null) g請求登録 = new 請求先登録();
//			if(g未発印刷 == null) g未発印刷 = new 未発行印刷();
// ADD 2005.05.24 東都）高木 画面遷移の高速化 END

// ADD 2005.05.25 東都）高木 画面遷移の高速化 START
			アイコンイメージの初期化();
// ADD 2005.05.25 東都）高木 画面遷移の高速化 END

//			MessageBox.Show("スレッド終了",
//				"スレッド", 
//				MessageBoxButtons.OK);
// ADD 2007.11.29 東都）高木 ログイン時のフォーカス障害対応 START
			if(F初期登録 != null) F初期登録.Focus();
			else if(Fログイン != null) Fログイン.Focus();
// ADD 2007.11.29 東都）高木 ログイン時のフォーカス障害対応 END
		}
// ADD 2005.05.20 東都）西口 スレッド化 END

// ADD 2005.05.20 東都）小童谷 ヘルプ追加 START
		private void btnヘルプ_Click(object sender, System.EventArgs e)
		{
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア START
			//エラーメッセージのクリア
			texメッセージ.Text = "";
// MOD 2010.01.15 東都）高木 エラーメッセージのクリア END
// MOD 2005.05.25 東都）高木 ヘルプＵＲＬをconfigから取得 START
//			Process.Start("iexplore.exe", "http://wwwis2.fukutsu.co.jp/is2/manual/is2manual.pdf");
// MOD 2008.02.13 東都）高木 ヘルプの細分化対応 START
//			Process.Start("iexplore.exe", sヘルプＵＲＬ);
			ヘルプ Fヘルプ = new ヘルプ();
			if(Fヘルプ.sヘルプＵＲＬ.Length == 0)
			{
				Fヘルプ.sヘルプＵＲＬ = this.sヘルプＵＲＬ;
				int iPos = this.sヘルプＵＲＬ.LastIndexOf("/") + 1;
				Fヘルプ.sヘルプＵＲＬＢＡＳＥ = this.sヘルプＵＲＬ.Substring(0,iPos);
			}
			Fヘルプ.Top  = this.Top  + panel6.Top + panel6.Height
// MOD 2011.02.03 東都）高木 SATO製プリンタ清掃マニュアル追加 START
//									+ btnヘルプ.Top + btnヘルプ.Height;
									+ btnヘルプ.Top;
// MOD 2011.02.03 東都）高木 SATO製プリンタ清掃マニュアル追加 END
// MOD 2010.05.24 東都）高木 120DPI対応時の表示位置調整 START
//			Fヘルプ.Left = this.Left + this.Width - Fヘルプ.Width - 4;
			Fヘルプ.Left = this.Left
						 + this.Width - ＤＰＩサイズ位置調整(Fヘルプ.Width, giDisplayDpiX)
						 - 4;
// MOD 2010.05.24 東都）高木 120DPI対応時の表示位置調整 END
			Fヘルプ.WindowState = FormWindowState.Normal;
			Fヘルプ.ShowDialog();
// MOD 2008.02.13 東都）高木 ヘルプの細分化対応 END
// MOD 2005.05.25 東都）高木 ヘルプＵＲＬをconfigから取得 END
		}
// ADD 2005.05.20 東都）小童谷 ヘルプ追加 END

// ADD 2007.11.30 KCL) 森本 お知らせ追加 START
		private void お知らせ初期設定() 
		{
// MOD 2008.02.08 KCL) 森本 お知らせ修正 START
//			// Label を配列にする
//			labList[0] = labお知らせ１;
//			labList[1] = labお知らせ２;
//			labList[2] = labお知らせ３;
//			labList[3] = labお知らせ４;
//			labList[4] = labお知らせ５;
//
//			// PictureBox を配列にする
//			picList[0] = picお知らせ１;
//			picList[1] = picお知らせ２;
//			picList[2] = picお知らせ３;
//			picList[3] = picお知らせ４;
//			picList[4] = picお知らせ５;
//
			// お知らせ表題ボタンを配列にする
			btnList[0] = btnお知らせ１;
			btnList[1] = btnお知らせ２;
			btnList[2] = btnお知らせ３;
			btnList[3] = btnお知らせ４;
			btnList[4] = btnお知らせ５;
// MOD 2008.02.08 KCL) 森本 お知らせ修正 END
		}
		private void お知らせの取得と表示() 
		{
			// お知らせ取得条件の設定
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
//			string [] sKey = new string [5];
			string [] sKey = new string [7];
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END
			sKey[0] = string.Empty;		// 開始登録日
			sKey[1] = string.Empty;		// 終了登録日
			sKey[2] = string.Empty;		// 表題
			sKey[3] = string.Empty;		// 詳細内容
			sKey[4] = "5";				// 上位Ｎ件
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
			sKey[5] = "お知らせボタン荷主"; // 機能
			sKey[6] = gs利用者部門店所ＣＤ; // 店所ＣＤ
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END

			// お知らせ一覧を取得
			string [] sRet = null;
			try
			{
				if (sv_oshirase == null) sv_oshirase = new is2oshirase.Service1();
				sRet = sv_oshirase.Get_OshiraseTopN(gsaユーザ, sKey);
			}
			catch (System.Net.WebException)
			{
				// 通信エラー発生
				sRet[0] = gs通信エラー;
			}
			catch (Exception ex)
			{
				// その他のエラー発生
				sRet[0] = "通信エラー：" + ex.Message;
			}

			// 結果処理
			try 
			{
				switch (sRet[0].Trim()) 
				{
					case "正常終了" :		// 正常終了の場合

						// お知らせ取得
						sお知らせ一覧 = new string [sRet.Length - 1][];
						for (int i=1; i<sRet.Length; i++) 
						{
							string [] s項目 = sRet[i].Split('|');
							sお知らせ一覧[i-1] = new string [] {
															 s項目[1],	// 登録日（表示用）
															 s項目[2],	// 表題
															 s項目[3],	// 登録日（数字８桁）
															 s項目[4]	// シーケンスＮｏ
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
															 ,s項目[5]	// 管理者区分
															 ,s項目[6]	// 店所ＣＤ
															 ,s項目[7]	// 会員ＣＤ
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END
														 };
						}

						break;

					default :				// 異常終了の場合

						throw new Exception(sRet[0]);
				}
			} 
			catch (Exception ex) 
			{
				// お知らせの取得に失敗

				// ボタンをすべて非表示に
				for (int i=0; i<5; i++) 
				{
// MOD 2008.02.08 KCL) 森本 お知らせ修正 START
//					labList[i].Visible = false;
//					picList[i].Visible = false;
//
					btnList[i].Visible = false;
// MOD 2008.02.08 KCL) 森本 お知らせ修正 START
				}
				// 警告音
				ビープ音();
				// エラーメッセージ表示
				texメッセージ.Text = "お知らせの取得に失敗しました。" + ex.Message;

				return;
			}

			// お知らせボタンを表示
			for (int i=0; i<5; i++) 
			{
				if (sお知らせ一覧.Length > i) 
				{
					// 表示するお知らせ有

// MOD 2008.02.08 KCL) 森本 お知らせ修正 START
//					// ボタンを表示
//					labList[i].Visible = true;
//					picList[i].Visible = true;
//
//					// 登録日と表題を表示
//					string title = sお知らせ一覧[i][1];
//					int len = title.Length;
//					labList[i].Text = string.Format("{0}　{1}", sお知らせ一覧[i][0], title);
//
					// ボタンを表示
					btnList[i].Visible = true;

					// 登録日と表題を表示
					btnList[i].日付 = sお知らせ一覧[i][0];
					btnList[i].表題 = sお知らせ一覧[i][1];
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
					if(sお知らせ一覧[i][5].Length > 0){	// 店所ＣＤ
						btnList[i].モード = 2;
					}else{
						btnList[i].モード = 0;
					}
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END
// MOD 2016.01.21 BEVAS) 松本 お知らせボタンの色切替え改修 START
					//お知らせ表題の先頭に「【重要】」が付くときは、ボタンの色を変える
					if(sお知らせ一覧[i][1].StartsWith("【重要】"))
					{
						btnList[i].モード = 2;
					}
// MOD 2016.01.21 BEVAS) 松本 お知らせボタンの色切替え改修 END
// MOD 2008.02.08 KCL) 森本 お知らせ修正 END
				} 
				else 
				{
					// 表示するお知らせ無

// MOD 2008.02.08 KCL) 森本 お知らせ修正 START
//					// ボタンを表示しない
//					labList[i].Visible = false;
//					picList[i].Visible = false;
//
					// ボタンを表示しない
					btnList[i].Visible = false;
// MOD 2008.02.08 KCL) 森本 お知らせ修正 END
				}
			}
		}
// ADD 2007.11.30 KCL) 森本 お知らせ追加 END
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
		private void お知らせ案内メッセージ取得() 
		{
			// お知らせ取得条件の設定
			string [] sKey = new string [7];
			sKey[0] = string.Empty;		// 開始登録日
			sKey[1] = string.Empty;		// 終了登録日
			sKey[2] = string.Empty;		// 表題
			sKey[3] = string.Empty;		// 詳細内容
			sKey[4] = "5";				// 上位Ｎ件
			sKey[5] = "メニュー荷主"; // 機能
			sKey[6] = gs利用者部門店所ＣＤ; // 店所ＣＤ

			// お知らせ一覧を取得
			string [] sRet = null;
			try{
				if (sv_oshirase == null) sv_oshirase = new is2oshirase.Service1();
				sRet = sv_oshirase.Get_OshiraseTopN(gsaユーザ, sKey);
			}catch (System.Net.WebException){
				// 通信エラー発生
				sRet[0] = gs通信エラー;
			}catch (Exception ex){
				// その他のエラー発生
				sRet[0] = "通信エラー：" + ex.Message;
			}

			try{
				if(sRet[0].Length == 4){	// 正常終了の場合
					// お知らせ取得
					sお知らせ一覧 = new string [sRet.Length - 1][];
					for(int iCnt = 1; iCnt < sRet.Length; iCnt++){
						string [] s項目 = sRet[iCnt].Split('|');
						sお知らせ一覧[iCnt-1]
						 = new string []{
							  s項目[ 3]	// 0:登録日（数字８桁）
							 ,s項目[ 4]	// 1:シーケンスＮｏ
							 ,s項目[ 6]	// 2:店所ＣＤ
							 ,s項目[ 7]	// 3:会員ＣＤ
							 ,s項目[ 8]	// 4:詳細内容
							 ,s項目[ 9]	// 5:メッセージ
							 ,s項目[10]	// 6:表示期間開始
							 ,s項目[11]	// 7:表示期間終了
							 ,s項目[12]	// 8:表示ＦＧ
							 ,s項目[13]	// 9:システム日付
						 };
					}
				}else{
					throw new Exception(sRet[0]);
				}
			}catch (Exception ex){
				ビープ音();
				texメッセージ.Text = "お知らせの取得に失敗しました。" + ex.Message;
				return;
			}

			// メッセージを表示
			for(int iCnt = 0; iCnt < sお知らせ一覧.Length; iCnt++){
				// 店所ＣＤチェック
				if(sお知らせ一覧[iCnt][2].Length == 0) continue;

				// 会員ＣＤチェック
				if(sお知らせ一覧[iCnt][3].Length > 0){
					// 表示ＦＧチェック
					if(sお知らせ一覧[iCnt][8].Equals("1")){
						MessageBox.Show(sお知らせ一覧[iCnt][4]
							, ""
							, MessageBoxButtons.OK);
						お知らせ表示ＦＧ更新(
							sお知らせ一覧[iCnt][0], sお知らせ一覧[iCnt][1]);
					}
				}

				// 表示期間チェック
				string s表示期間開始 = sお知らせ一覧[iCnt][6];
				string s表示期間終了 = sお知らせ一覧[iCnt][7];
				string sシステム日付 = sお知らせ一覧[iCnt][9];
				if(s表示期間開始.CompareTo(sシステム日付) > 0) continue;
				if(s表示期間終了.CompareTo(sシステム日付) < 0) continue;
				gsお知らせ案内メッセージ = sお知らせ一覧[iCnt][5];
//				texメッセージ.Text = gsお知らせ案内メッセージ;
			}
		}
		private void お知らせ表示ＦＧ更新(string s登録日, string sシーケンスＮｏ) 
		{
			// お知らせ取得条件の設定
			string [] sKey = new string[]{
				  s登録日
				, sシーケンスＮｏ
				, gs利用者ＣＤ
			};

			string [] sRet = null;
			try{
				if(sv_oshirase == null) sv_oshirase = new is2oshirase.Service1();
				sRet = sv_oshirase.Upd_HyoujiFG(gsaユーザ, sKey);
			}catch(System.Net.WebException){
				// 通信エラー発生
				sRet[0] = gs通信エラー;
			}catch(Exception ex){
				// その他のエラー発生
				sRet[0] = "通信エラー：" + ex.Message;
			}

			if(sRet[0].Length != 4){
				ビープ音();
				texメッセージ.Text = sRet[0];
				return;
			}
		}
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END
// ADD 2009.04.02 東都）高木 稼働日対応 START
		static private void 稼働日情報取得()
		{
			//初期設定
// MOD 2011.09.05 東都）高木 出荷日の上限をＣＳＶエントリーと同様にする START
//			gdt出荷日最大値       = gdt出荷日.AddDays(7);
			gdt出荷日最大値       = gdt出荷日.AddDays(14);
// MOD 2011.09.05 東都）高木 出荷日の上限をＣＳＶエントリーと同様にする END
			gdt出荷日最大値ＣＳＶ = gdt出荷日.AddDays(14);

			DateTime dt開始日 = gdt出荷日;
			DateTime dt終了日 = gdt出荷日.AddMonths(1).AddDays(-1);

			try
			{
				// 稼働日情報取得
				if(sv_init == null) sv_init = new is2init.Service1();
				String[] sRet = sv_init.Get_Kadobi(gsaユーザ, dt開始日.ToString("yyyyMMdd")
															, dt終了日.ToString("yyyyMMdd"));
				if(sRet[0].Length != 4)
				{
					ビープ音();
					MessageBox.Show(sRet[0],
									"稼働日情報取得", 
									MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

// MOD 2011.09.05 東都）高木 出荷日の上限をＣＳＶエントリーと同様にする START
//				try{
//					if(sRet[1].Length == 8){
//						gdt出荷日最大値 = new DateTime(int.Parse(sRet[1].Substring(0,4)), 
//											int.Parse(sRet[1].Substring(4,2)),
//											int.Parse(sRet[1].Substring(6)) );
//					}
//				}catch(Exception){}
// MOD 2011.09.05 東都）高木 出荷日の上限をＣＳＶエントリーと同様にする END
				try{
					if(sRet[2].Length == 8){
						gdt出荷日最大値ＣＳＶ = new DateTime(int.Parse(sRet[2].Substring(0,4)), 
											int.Parse(sRet[2].Substring(4,2)),
											int.Parse(sRet[2].Substring(6)) );
// MOD 2011.09.05 東都）高木 出荷日の上限をＣＳＶエントリーと同様にする START
						gdt出荷日最大値       = gdt出荷日最大値ＣＳＶ;
// MOD 2011.09.05 東都）高木 出荷日の上限をＣＳＶエントリーと同様にする END
					}
				}catch(Exception){}
// ADD 2013.02.15 TDI)綱澤 グローバル出荷日制限拡張対応(14日⇒62日) ADD START
// グローバル荷主の場合は、出荷日最大値を62日間とする。上書き
				try
				{
					if(gs部門店所ＣＤ.Equals("047"))
					{
						gdt出荷日最大値 = gdt出荷日.AddDays(62);
						gdt出荷日最大値ＣＳＶ = gdt出荷日.AddDays(62);
					}
					else
					{
						//何もしない
					}
				}
				catch(Exception){}
// ADD 2013.02.15 TDI)綱澤 グローバル出荷日制限拡張対応(14日⇒62日) ADD END

			}
			catch (System.Net.WebException)
			{
				ビープ音();
				MessageBox.Show(gs通信エラー, 
								"通信エラー", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				ビープ音();
				MessageBox.Show(ex.Message, 
								"通信エラー", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
// ADD 2009.04.02 東都）高木 稼働日対応 END
// MOD 2009.05.01 東都）高木 オプションの項目追加 START
		static protected void オプション情報取得()
		{
			string[] sRet = new string[]{""};
//			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
//				texメッセージ.Text = "検索中．．．";
				if(sv_init == null) sv_init = new is2init.Service1();
				sRet = sv_init.Get_seigyo2(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,giオプション数);
			}
			catch (System.Net.WebException)
			{
				ビープ音();
				MessageBox.Show(gs通信エラー, 
					"通信エラー", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			catch (Exception ex)
			{
				ビープ音();
				MessageBox.Show(ex.Message, 
					"通信エラー", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			// カーソルをデフォルトに戻す
//			Cursor = System.Windows.Forms.Cursors.Default;

			if(sRet[0].Length == 4)
			{
				int iCnt = 0;
				for (; iCnt < gsオプション.Length && iCnt < sRet.Length; iCnt++)
				{
					gsオプション[iCnt] = sRet[iCnt];
				}
				for (; iCnt < gsオプション.Length; iCnt++)
				{
					gsオプション[iCnt] = "9";
				}
			}
			else
			{
				ビープ音();
				MessageBox.Show(sRet[0], 
					"通信エラー", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return;
		}
// MOD 2009.05.01 東都）高木 オプションの項目追加 START
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
		static protected void 重量入力制御取得()
		{
			string[] sRet = new string[]{"",""};
			gs重量入力制御 = "0";
			try{
				sRet = sv_init.Get_seigyo3(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
			}catch (System.Net.WebException){
//				ビープ音();
//				MessageBox.Show(gs通信エラー, 
//					"通信エラー", 
//					MessageBoxButtons.OK, MessageBoxIcon.Error);
//				return;
//			}catch (Exception ex){
			}catch (Exception){
//				ビープ音();
//				MessageBox.Show(ex.Message, 
//					"通信エラー", 
//					MessageBoxButtons.OK, MessageBoxIcon.Error);
//				return;
			}
			if(sRet[0].Length == 4){
				gs重量入力制御 = sRet[1];
			}
			return;
		}
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END

// ADD 2009.07.29 東都）高木 プロキシ対応 START
		// ＩＥのプロキシの設定内容をレジストリから取得
		private static void ＩＥプロキシ取得()
		{
//			LogWriter.GetInstance().WriteInfo("ＩＥプロキシ取得()");

			Microsoft.Win32.RegistryKey regkey =
				Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", false);
			//キーが存在しないときは null が返される
			if (regkey == null) return;

//			int iProxyEnable = (int)regkey.GetValue("ProxyEnable");
//			string[] sProxyServer   = ((string)regkey.GetValue("ProxyServer")).Split(new char[]{';'});
			int iProxyEnable = 0;
			if(regkey.GetValue("ProxyEnable") != null){
				iProxyEnable = (int)regkey.GetValue("ProxyEnable");
//				LogWriter.GetInstance().WriteInfo("ProxyEnable[" + iProxyEnable + "]");
			}
			string[] sProxyServer   = {""};
			if(regkey.GetValue("ProxyServer") != null){
				sProxyServer   = ((string)regkey.GetValue("ProxyServer")).Split(new char[]{';'});
//				LogWriter.GetInstance().WriteInfo("ProxyServer["
//								 + (string)regkey.GetValue("ProxyServer") + "]");
			}

			string[] sProxyOverride = {""};
			if(regkey.GetValue("ProxyOverride") != null){
				sProxyOverride = ((string)regkey.GetValue("ProxyOverride")).Split(new char[]{';'});
//				LogWriter.GetInstance().WriteInfo("ProxyOverride["
//								 + (string)regkey.GetValue("ProxyOverride") + "]");
			}
			regkey.Close();
			if(iProxyEnable == 1){
				for(int iCnt = 0; iCnt < sProxyServer.Length; iCnt++){
					string[] sParam = sProxyServer[iCnt].Split(new char[]{':'});
					if(sParam[0].StartsWith("https=")){
						gsProxyAdrSecure = sParam[0].Substring(6);
						if(sParam.Length >= 2) giProxyNoSecure = int.Parse(sParam[1]);
					}else if(sParam[0].StartsWith("http=")){
						gsProxyAdrHttp = sParam[0].Substring(5);
						if(sParam.Length >= 2) giProxyNoHttp   = int.Parse(sParam[1]);
					}else if(sParam[0].StartsWith("ftp=")){
						;
					}else if(sParam[0].StartsWith("socks=")){
						;
					}else{
						gsProxyAdrAll  = sParam[0];
						if(sParam.Length >= 2) giProxyNoAll    = int.Parse(sParam[1]);
					}
				}
				for(int iCnt = 0; iCnt < sProxyOverride.Length; iCnt++){
					if(sProxyOverride[iCnt].Equals("wwwis2.fukutsu.co.jp")) return;
					if(sProxyOverride[iCnt].Equals("fukutsu.co.jp")) return;
				}
				if(gsProxyAdrAll.Length > 0){
					gsProxyAdr = gsProxyAdrAll;
					giProxyNo  = giProxyNoAll;
				}else if(gsProxyAdrSecure.Length > 0){
					gsProxyAdr = gsProxyAdrSecure;
					giProxyNo  = giProxyNoSecure;
				}else if(gsProxyAdrHttp.Length > 0){
					gsProxyAdr = gsProxyAdrHttp;
					giProxyNo  = giProxyNoHttp;
				}
			}
		}

		//
		// デフォルトプロキシの設定を行う
		//
		public static int デフォルトプロキシ設定()
		{
			int iRet = 0;

			try{
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 START
				//System.Net.GlobalProxySelection.Select = System.Net.WebProxy.GetDefaultProxy();
                System.Net.WebRequest.DefaultWebProxy = System.Net.WebRequest.GetSystemWebProxy();
				//sv_init.Proxy = System.Net.WebProxy.GetDefaultProxy();
                sv_init.Proxy = System.Net.WebRequest.GetSystemWebProxy();
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 END

				string sRet = sv_init.wakeupDB();
// MOD 2010.07.30 東都）高木 デフォルトプロキシ設定の修正 START
				Ｗｅｂサービスの初期化others();
// MOD 2010.07.30 東都）高木 デフォルトプロキシ設定の修正 END
				iRet = 1;
			}catch(System.Net.WebException ex){
				iRet = -1;
				switch(ex.Status){
				case WebExceptionStatus.NameResolutionFailure:
				    iRet = -11;
					break;
				case WebExceptionStatus.Timeout:
				    iRet = -12;
					break;
				case WebExceptionStatus.TrustFailure:
					iRet = -13;
					break;
				case WebExceptionStatus.ConnectFailure:
					iRet = -14;
					break;
				default:
					iRet = -19;
					break;
				}
				return iRet;
//			}catch(Exception ex){
			}catch(Exception){
				iRet = -2;
				return iRet;
			}

			return iRet;
		}
		//
		public static bool プロキシ設定(string sProxyAdr, int iProxyNo)
// MOD 2011.12.06 東都）高木 プロキシ認証の追加 START
		{
			return プロキシ設定２(sProxyAdr, iProxyNo, "", "");
		}
		private static bool プロキシ設定２(string sProxyAdr, int iProxyNo
											, string sProxyId, string sProxyPa)
// MOD 2011.12.06 東都）高木 プロキシ認証の追加 END
		{
			try{
				if(sProxyAdr.Length > 0)
				{
					if(iProxyNo > 0)
					{
						gProxy = new System.Net.WebProxy(sProxyAdr, iProxyNo);
					}
					else
					{
						gProxy = new System.Net.WebProxy(sProxyAdr);
					}
// MOD 2011.12.06 東都）高木 プロキシ認証の追加 START
					if(sProxyId.Length > 0){
						gProxy.Credentials = new NetworkCredential(sProxyId, sProxyPa);
					}
// MOD 2011.12.06 東都）高木 プロキシ認証の追加 END

// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 START
					//System.Net.GlobalProxySelection.Select = gProxy;
                    System.Net.WebRequest.DefaultWebProxy = gProxy;
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 END
					sv_init.Proxy = gProxy;
				}
				else
				{
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 START
					//System.Net.GlobalProxySelection.Select = System.Net.GlobalProxySelection.GetEmptyWebProxy();
                    System.Net.WebRequest.DefaultWebProxy = null;
					//sv_init.Proxy = System.Net.GlobalProxySelection.GetEmptyWebProxy();
                    sv_init.Proxy = null;
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 END
				}
				string sRet = "";
//				try
//				{
					sRet = sv_init.wakeupDB();
//				}
//				catch (Exception)
//				{
//					if(sv_init.Url.StartsWith("http://")){
//						sv_init.Url     = sv_init.Url.Replace("http://","https://");
//
//						sv_address.Url  = sv_address.Url.Replace("http://","https://");
//						sv_goirai.Url   = sv_goirai.Url.Replace("http://","https://");
//						sv_hinagata.Url = sv_hinagata.Url.Replace("http://","https://");
//						sv_kiji.Url     = sv_kiji.Url.Replace("http://","https://");
//						sv_otodoke.Url  = sv_otodoke.Url.Replace("http://","https://");
//						sv_print.Url    = sv_print.Url.Replace("http://","https://");
//						sv_syukka.Url   = sv_syukka.Url.Replace("http://","https://");
//						sv_seikyuu.Url  = sv_seikyuu.Url.Replace("http://","https://");
//						sv_oshirase.Url = sv_oshirase.Url.Replace("http://","https://");
//					}else if(sv_init.Url.StartsWith("https://")){
//						sv_init.Url     = sv_init.Url.Replace("https://","http://");
//
//						sv_address.Url  = sv_address.Url.Replace("https://","http://");
//						sv_goirai.Url   = sv_goirai.Url.Replace("https://","http://");
//						sv_hinagata.Url = sv_hinagata.Url.Replace("https://","http://");
//						sv_kiji.Url     = sv_kiji.Url.Replace("https://","http://");
//						sv_otodoke.Url  = sv_otodoke.Url.Replace("https://","http://");
//						sv_print.Url    = sv_print.Url.Replace("https://","http://");
//						sv_syukka.Url   = sv_syukka.Url.Replace("https://","http://");
//						sv_seikyuu.Url  = sv_seikyuu.Url.Replace("https://","http://");
//						sv_oshirase.Url = sv_oshirase.Url.Replace("https://","http://");
//					}
//					sRet = sv_init.wakeupDB();
//					return false;
//				}

//				if(sv_address  == null) sv_address  = new is2address.Service1();
//				if(sv_goirai   == null) sv_goirai   = new is2goirai.Service1();
//				if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
//				if(sv_kiji     == null) sv_kiji     = new is2kiji.Service1();
//				if(sv_otodoke  == null) sv_otodoke  = new is2otodoke.Service1();
//				if(sv_print    == null) sv_print    = new is2print.Service1();
//				if(sv_syukka   == null) sv_syukka   = new is2syukka.Service1();
//				if(sv_seikyuu  == null) sv_seikyuu  = new is2seikyuu.Service1();
//				if(sv_oshirase == null) sv_oshirase = new is2oshirase.Service1();

				Ｗｅｂサービスの初期化others();

				return true;
//			}catch (System.Net.WebException ex){
			}catch (System.Net.WebException){
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 START
                //元の状態に戻す
				//System.Net.GlobalProxySelection.Select = System.Net.WebProxy.GetDefaultProxy();
                System.Net.WebRequest.DefaultWebProxy = System.Net.WebRequest.GetSystemWebProxy();
				//sv_init.Proxy = System.Net.WebProxy.GetDefaultProxy();
                sv_init.Proxy = System.Net.WebRequest.GetSystemWebProxy();
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 END
				return false;
//			}catch (Exception ex){
			}catch (Exception){
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 START
				//元の状態に戻す
				//System.Net.GlobalProxySelection.Select = System.Net.WebProxy.GetDefaultProxy();
                System.Net.WebRequest.DefaultWebProxy = System.Net.WebRequest.GetSystemWebProxy();
				//sv_init.Proxy = System.Net.WebProxy.GetDefaultProxy();
                sv_init.Proxy = System.Net.WebRequest.GetSystemWebProxy();
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 END
				return false;
			}
		}
// ADD 2009.07.29 東都）高木 プロキシ対応 END
// MOD 2009.10.14 東都）高木 config読込など START
		static void Ｗｅｂサービスの初期化init()
		{
			sv_init     = new is2init.Service1();
			if(sUrl_init.Length     > 0) sv_init.Url     = sUrl_init;
		}
		static void Ｗｅｂサービスの初期化others()
		{
			sv_address  = new is2address.Service1();
			sv_goirai   = new is2goirai.Service1();
			sv_hinagata = new is2hinagata.Service1();
			sv_kiji     = new is2kiji.Service1();
			sv_otodoke  = new is2otodoke.Service1();
			sv_print    = new is2print.Service1();
			sv_syukka   = new is2syukka.Service1();
			sv_seikyuu  = new is2seikyuu.Service1();
			sv_oshirase = new is2oshirase.Service1();
// MOD 2011.01.11 東都）高木 王子運送の対応 START
			sv_oji      = new is2oji.Service1();
// MOD 2011.01.11 東都）高木 王子運送の対応 END

			if(sUrl_address.Length  > 0) sv_address.Url  = sUrl_address;
			if(sUrl_goirai.Length   > 0) sv_goirai.Url   = sUrl_goirai;
			if(sUrl_hinagata.Length > 0) sv_hinagata.Url = sUrl_hinagata;
			if(sUrl_kiji.Length     > 0) sv_kiji.Url     = sUrl_kiji;
			if(sUrl_otodoke.Length  > 0) sv_otodoke.Url  = sUrl_otodoke;
			if(sUrl_print.Length    > 0) sv_print.Url    = sUrl_print;
			if(sUrl_syukka.Length   > 0) sv_syukka.Url   = sUrl_syukka;
			if(sUrl_seikyuu.Length  > 0) sv_seikyuu.Url  = sUrl_seikyuu;
			if(sUrl_oshirase.Length > 0) sv_oshirase.Url = sUrl_oshirase;
// MOD 2011.01.11 東都）高木 王子運送の対応 START
			if(sUrl_oji.Length      > 0) sv_oji.Url      = sUrl_oji;
// MOD 2011.01.11 東都）高木 王子運送の対応 END

			sv_address.Proxy  = sv_init.Proxy;
			sv_goirai.Proxy   = sv_init.Proxy;
			sv_hinagata.Proxy = sv_init.Proxy;
			sv_kiji.Proxy     = sv_init.Proxy;
			sv_otodoke.Proxy  = sv_init.Proxy;
			sv_print.Proxy    = sv_init.Proxy;
			sv_syukka.Proxy   = sv_init.Proxy;
			sv_seikyuu.Proxy  = sv_init.Proxy;
			sv_oshirase.Proxy = sv_init.Proxy;
// MOD 2011.01.11 東都）高木 王子運送の対応 START
			sv_oji.Proxy      = sv_init.Proxy;
// MOD 2011.01.11 東都）高木 王子運送の対応 END
		}
// MOD 2009.10.14 東都）高木 config読込など END
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 START
		private void 端末ごとの初期設定ファイル読込()
		{
			try{
				FileInfo finfo = new FileInfo(gsInitClient);
				if(finfo.Exists){
					XmlDocument xmldoc = new XmlDocument();
					xmldoc.Load(finfo.FullName);
					foreach(XmlNode node in xmldoc["configuration"]["appSettings"]){
						if(node.Attributes.GetNamedItem("key").Value.Equals("アドレス帳_表示順１")){
							gsアドレス帳_表示順１   = node.Attributes.GetNamedItem("value").Value;
						}else if(node.Attributes.GetNamedItem("key").Value.Equals("アドレス帳_表示順１_方向")){
							gsアドレス帳_表示順１_方向   = node.Attributes.GetNamedItem("value").Value;
						}else if(node.Attributes.GetNamedItem("key").Value.Equals("アドレス帳_表示順２")){
							gsアドレス帳_表示順２   = node.Attributes.GetNamedItem("value").Value;
						}else if(node.Attributes.GetNamedItem("key").Value.Equals("アドレス帳_表示順２_方向")){
							gsアドレス帳_表示順２_方向   = node.Attributes.GetNamedItem("value").Value;
						}else if(node.Attributes.GetNamedItem("key").Value.Equals("ご依頼主検索_表示順１")){
							gsご依頼主検索_表示順１ = node.Attributes.GetNamedItem("value").Value;
						}else if(node.Attributes.GetNamedItem("key").Value.Equals("ご依頼主検索_表示順１_方向")){
							gsご依頼主検索_表示順１_方向 = node.Attributes.GetNamedItem("value").Value;
						}else if(node.Attributes.GetNamedItem("key").Value.Equals("ご依頼主検索_表示順２")){
							gsご依頼主検索_表示順２ = node.Attributes.GetNamedItem("value").Value;
						}else if(node.Attributes.GetNamedItem("key").Value.Equals("ご依頼主検索_表示順２_方向")){
							gsご依頼主検索_表示順２_方向 = node.Attributes.GetNamedItem("value").Value;
						}
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 START
						//[IS2Client.ini]ファイルに、出荷実績表印刷画面の出力オプションのチェック内容を保持させる
						else if(node.Attributes.GetNamedItem("key").Value.Equals("出荷実績_未発行分除外"))
						{
							gs出荷実績_未発行分除外 = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("出荷実績_網掛けなし_印刷のみ"))
						{
							gs出荷実績_網掛けなし_印刷のみ = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("出荷実績_ご依頼主印字なし_印刷のみ"))
						{
							gs出荷実績_ご依頼主印字なし_印刷のみ = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("出荷実績_運賃印字なし_印刷のみ"))
						{
							gs出荷実績_運賃印字なし_印刷のみ = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("出荷実績_発店出力_ＣＳＶのみ"))
						{
							gs出荷実績_発店出力_ＣＳＶのみ = node.Attributes.GetNamedItem("value").Value;
						}
						else if(node.Attributes.GetNamedItem("key").Value.Equals("出荷実績_配完日時出力"))
						{
							gs出荷実績_配完日時出力 = node.Attributes.GetNamedItem("value").Value;
						}
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 END
					}
					xmldoc = null;
				}
				finfo = null;
			}catch(Exception){
				;
			}
		}
		private void 端末ごとの初期設定ファイル保存()
		{
			try{
				FileInfo finfo = new FileInfo(gsInitClient);
				XmlDocument xmldoc = new XmlDocument();
				xmldoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?>"
								+ "<configuration>"
								+ "<appSettings>"
								+ "</appSettings>"
								+ "</configuration>"
								);
				XmlNode node = xmldoc["configuration"]["appSettings"];
				node.InnerXml = "";
				if(gsアドレス帳_表示順１ != null){
					node.InnerXml += "<add key=\"アドレス帳_表示順１\" value=\""+gsアドレス帳_表示順１+"\" />";
				}
				if(gsアドレス帳_表示順１_方向 != null){
					node.InnerXml += "<add key=\"アドレス帳_表示順１_方向\" value=\""+gsアドレス帳_表示順１_方向+"\" />";
				}
				if(gsアドレス帳_表示順２ != null){
					node.InnerXml += "<add key=\"アドレス帳_表示順２\" value=\""+gsアドレス帳_表示順２+"\" />";
				}
				if(gsアドレス帳_表示順２_方向 != null){
					node.InnerXml += "<add key=\"アドレス帳_表示順２_方向\" value=\""+gsアドレス帳_表示順２_方向+"\" />";
				}
				if(gsご依頼主検索_表示順１ != null){
					node.InnerXml += "<add key=\"ご依頼主検索_表示順１\" value=\""+gsご依頼主検索_表示順１+"\" />";
				}
				if(gsご依頼主検索_表示順１_方向 != null){
					node.InnerXml += "<add key=\"ご依頼主検索_表示順１_方向\" value=\""+gsご依頼主検索_表示順１_方向+"\" />";
				}
				if(gsご依頼主検索_表示順２ != null){
					node.InnerXml += "<add key=\"ご依頼主検索_表示順２\" value=\""+gsご依頼主検索_表示順２+"\" />";
				}
				if(gsご依頼主検索_表示順２_方向 != null){
					node.InnerXml += "<add key=\"ご依頼主検索_表示順２_方向\" value=\""+gsご依頼主検索_表示順２_方向+"\" />";
				}
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 START
				//[IS2Client.ini]ファイルに、出荷実績表印刷画面の出力オプションのチェック内容を保持させる
				if(gs出荷実績_未発行分除外 != null)
				{
					node.InnerXml += "<add key=\"出荷実績_未発行分除外\" value=\""+gs出荷実績_未発行分除外+"\" />";
				}
				if(gs出荷実績_網掛けなし_印刷のみ != null)
				{
					node.InnerXml += "<add key=\"出荷実績_網掛けなし_印刷のみ\" value=\""+gs出荷実績_網掛けなし_印刷のみ+"\" />";
				}
				if(gs出荷実績_ご依頼主印字なし_印刷のみ != null)
				{
					node.InnerXml += "<add key=\"出荷実績_ご依頼主印字なし_印刷のみ\" value=\""+gs出荷実績_ご依頼主印字なし_印刷のみ+"\" />";
				}
				if(gs出荷実績_運賃印字なし_印刷のみ != null)
				{
					node.InnerXml += "<add key=\"出荷実績_運賃印字なし_印刷のみ\" value=\""+gs出荷実績_運賃印字なし_印刷のみ+"\" />";
				}
				if(gs出荷実績_発店出力_ＣＳＶのみ != null)
				{
					node.InnerXml += "<add key=\"出荷実績_発店出力_ＣＳＶのみ\" value=\""+gs出荷実績_発店出力_ＣＳＶのみ+"\" />";
				}
				if(gs出荷実績_配完日時出力 != null)
				{
					node.InnerXml += "<add key=\"出荷実績_配完日時出力\" value=\""+gs出荷実績_配完日時出力+"\" />";
				}
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 END
				if(node.InnerXml.Length > 0)
				{
					XmlTextWriter writer = new XmlTextWriter(finfo.FullName, System.Text.UTF8Encoding.UTF8);
					writer.Formatting = Formatting.Indented;
					xmldoc.WriteContentTo(writer);
					writer.Flush();
					writer.Close();
				}
				xmldoc = null;
				finfo  = null;
			}catch(Exception ex){
				//ex = ex;
                string dummy = ex.Message;
			}
		}
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 END
// MOD 2010.05.24 東都）高木 120DPI対応時の表示位置調整 START
		private int ＤＰＩサイズ位置調整(int iSize, int iDisplayDpi)
		{
			if(iDisplayDpi == 0 || iDisplayDpi == 96) return iSize;
			if(iSize <= 0) return 0;
			return iSize * iDisplayDpi / 96;
		}
// MOD 2010.05.24 東都）高木 120DPI対応時の表示位置調整 END
// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 START
		private void 出荷ＣＳＶ自動出力設定ファイル読込()
		{
			// ファイルが存在しなければ終了
			if( !File.Exists(gsInitSyukka) ) return;

			try{
				gi自動出力タイマー  = 3; // 3分
// ADD 2015.04.13 BEVAS)前田　自動出力タイマー秒単位指定 START
				gi自動出力タイマー秒  = 0; // 0秒 →　デフォルトだと3分 + 0秒間隔とする。
// ADD 2015.04.13 BEVAS)前田　自動出力タイマー秒単位指定 END
				string s自動出力タイマー  = "";

				StreamReader sr = new StreamReader(gsInitSyukka, System.Text.Encoding.Default);
				s自動出力タイマー = sr.ReadLine();
				sr.Close();

				if(s自動出力タイマー.Length > 0){
					if(半角チェック(s自動出力タイマー)){
						if(数値チェック(s自動出力タイマー))
						{
							gi自動出力タイマー = int.Parse(s自動出力タイマー);
							// 上限は60分
							if(gi自動出力タイマー > 60)
							{
								gi自動出力タイマー = 60; // 60分
							}
						}
// ADD 2015.04.13 BEVAS)前田 自動出力タイマーの秒単位指定 START
						else 
						{
							if ((s自動出力タイマー.Substring(0,1) == "S") || (s自動出力タイマー.Substring(0,1) == "s")) 
							{
								// 秒単位で出力間隔が指定
								if(数値チェック(s自動出力タイマー.Substring(1)))
								{
									gi自動出力タイマー秒 = int.Parse(s自動出力タイマー.Substring(1));
									// 
									if (gi自動出力タイマー秒 < 1) 
									{
										gi自動出力タイマー秒 = 180; // 3分
										ログ出力２("自動出力の間隔は1秒以上を設定してください。");
										
									}
									if(gi自動出力タイマー秒 > 3600)
									{
										gi自動出力タイマー秒 = 3600; // 60分
										ログ出力２("自動出力の間隔は60分(3600秒)以内です");
									}

									gi自動出力タイマー = gi自動出力タイマー秒 / 60;
									gi自動出力タイマー秒 = gi自動出力タイマー秒 % 60;
								}
								else 
								{
									ログ出力２("自動出力の間隔として不正な文字列な指定されています:" + s自動出力タイマー);
								}
							}
							else {
								ログ出力２("自動出力の間隔として不正な文字列な指定されています:" + s自動出力タイマー);
							}
						}
					}
					else 
					{
						ログ出力２("自動出力の間隔として不正な文字列な指定されています:" + s自動出力タイマー);
					}
// ADD 2015.04.13 BEVAS)前田 自動出力タイマーの秒単位指定 END
				}
			}catch(Exception ex){
				ログ出力２(" 設定ファイル読込"+ex.Message);
//保留
//				MessageBox.Show("出荷ＣＳＶ自動出力用設定ファイルの読込に失敗しました\n"
//								+ ex.Message 
//								,"出荷ＣＳＶ自動出力"
//								, MessageBoxButtons.OK);
			}
		}
		private void 出荷ＣＳＶ自動出力フォルダ作成()
		{
			// ディレクトリが存在しなければ作成する
			try{
				if(!Directory.Exists(gsPathSyukka)){
					Directory.CreateDirectory(gsPathSyukka);
				}
				if(!Directory.Exists(gsPathSyukkaIn)){
					Directory.CreateDirectory(gsPathSyukkaIn);
				}
				if(!Directory.Exists(gsPathSyukkaOut)){
					Directory.CreateDirectory(gsPathSyukkaOut);
				}
				if(!Directory.Exists(gsPathSyukkaLog)){
					Directory.CreateDirectory(gsPathSyukkaLog);
				}
			}catch(Exception ex){
				ログ出力２(" フォルダ作成"+ex.Message);
				MessageBox.Show("出荷ＣＳＶ自動出力用フォルダの作成に失敗しました\n"
								+ ex.Message 
								,"出荷ＣＳＶ自動出力"
								, MessageBoxButtons.OK);
			}
		}
		private void 出荷ＣＳＶ自動出力過去ファイル削除()
		{
			// ディレクトリが存在しなければ作成する
			try{
				if(Directory.Exists(gsPathSyukkaOut)){
					過去ファイル削除(gsPathSyukkaOut);
				}
				if(Directory.Exists(gsPathSyukkaLog)){
					過去ファイル削除(gsPathSyukkaLog);
				}
			}catch(Exception ex){
				ログ出力２(" 過去ファイル削除"+ex.Message);
				MessageBox.Show("出荷ＣＳＶ自動出力用フォルダの過去ファイル削除に失敗しました\n"
								+ ex.Message 
								,"出荷ＣＳＶ自動出力"
								, MessageBoxButtons.OK);
			}
		}
		private void 過去ファイル削除(string sPath)
		{
			try{
				// ファイル一覧取得
				string[] sFiles = Directory.GetFiles(sPath);
				if(sFiles.Length == 0) return;

				DateTime dt６日前 = DateTime.Now.Date.AddDays(-6);
				DateTime dtFile;
				for(int iCnt = 0; iCnt < sFiles.Length; iCnt++){
					// ファイルスタンプの比較
					dtFile = File.GetLastWriteTime(sFiles[iCnt]);
					if(dtFile < dt６日前){
						File.Delete(sFiles[iCnt]);
					}
				}
			}catch(Exception ex){
//保留　エラー処理
				ログ出力２(" 過去ファイル削除"+ex.Message);
			}
		}

		private string sログ出力２ = "";
		private void ログ出力２(string message)
		{
			if(sログ出力２.Length == 0){
				sログ出力２ = gsPathSyukkaLog + "\\" + YYYYMMDD変換(DateTime.Now) + ".log";
			}

			// ログ用フォルダがなければ戻る
			if(!Directory.Exists(gsPathSyukkaLog)) return;

			StringBuilder sbBuff = new StringBuilder(2048);
			sbBuff.Append("["+ System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") +"]");
			sbBuff.Append(message);

			try{
				StreamWriter swp = new StreamWriter(sログ出力２, true, enc);
				swp.WriteLine(sbBuff);
				swp.Close();
				
			}catch(Exception ){
//保留			;
			}
		}

		private bool bエラー出力２ = false;
		private int  iエラー行数２ = 0;
		private int  i前回エラー行 = 0;
		private void エラー出力２(string sErrFile, int nRow, int nCol, string message)
		{
			bエラー出力２ = true;
			if(i前回エラー行 != nRow){
				i前回エラー行 = nRow;
				iエラー行数２++;
			}

			// 出力用フォルダがなければ戻る
			if(!Directory.Exists(gsPathSyukkaOut)) return;

			try{
				StreamWriter swp = new StreamWriter(sErrFile, true, enc);
//				swp.WriteLine(nRow.ToString("00000")+"行目:"+message);
				swp.Write(nRow.ToString("00000")+"行目:"+message);
				swp.Close();
				
			}catch(Exception ){
//保留			;
			}
		}
// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 END

		private void btn自動出力_Click(object sender, System.EventArgs e)
		{
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
			重量入力制御取得();
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END
			出荷ＣＳＶ自動出力フォルダ作成();
			if(btn自動出力.Text == "自動出力 ON"){
				出荷ＣＳＶ自動出力設定ファイル読込();
// MOD 2015.04.13 BEVAS)前田 自動出力タイマー秒対応 START
				//if(gi自動出力タイマー > 0){
				if((gi自動出力タイマー > 0) || (gi自動出力タイマー秒 > 0)){
// MOD 2015.04.13 BEVAS)前田 自動出力タイマー秒対応 END
					gb自動出力ＯＮ   = true;
					btn自動出力.Text = "自動出力 OFF";
					ログ出力２(" 自動出力ＯＮ");
// MOD 2015.04.13 BEVAS)前田 自動出力タイマー秒対応 START
					//ログ出力２(" ファイル確認間隔："+gi自動出力タイマー+"分");
					ログ出力２(" ファイル確認間隔："+gi自動出力タイマー+"分"+gi自動出力タイマー秒+"秒");
// MOD 2015.04.13 BEVAS)前田 自動出力タイマー秒対応 END
				}
				else
				{
					gb自動出力ＯＮ   = false;
					btn自動出力.Text = "自動出力 ON";
					ログ出力２(" 自動出力ＯＦＦ");
				}
			}else{
				gb自動出力ＯＮ   = false;
				btn自動出力.Text = "自動出力 ON";
				ログ出力２(" 自動出力ＯＦＦ");
			}
			btn自動出力.Refresh();

			if(gb自動出力ＯＮ){
//保留 MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//保留				btn確認.Enabled = false;
//保留 MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
//				出荷ＣＳＶ自動出力フォルダ作成();
// MOD 2010.04.21 東都）高木 ハング近似動作の防止 START
//				ファイル一覧取得１();
				if(!b実行中_ThreadTask1) ファイル一覧取得１();
// MOD 2010.04.21 東都）高木 ハング近似動作の防止 END
				// タイマーの設定をする
				if(tim出荷ＣＳＶ自動出力 == null){
					tim出荷ＣＳＶ自動出力 = new System.Windows.Forms.Timer(this.components);
					tim出荷ＣＳＶ自動出力.Tick += new System.EventHandler(tim出荷ＣＳＶ自動出力_Tick);
//					if(gi自動出力タイマー == 1){
//						tim出荷ＣＳＶ自動出力.Interval = 3 * 1000; // 3秒
//					}else{
//						tim出荷ＣＳＶ自動出力.Interval = (gi自動出力タイマー - 1) * 60 * 1000;
//					}
				}
// MOD 2015.04.13 BEVAS)前田　自動出力タイマー秒対応 START
				//tim出荷ＣＳＶ自動出力.Interval = gi自動出力タイマー * 60 * 1000;
				tim出荷ＣＳＶ自動出力.Interval = ((gi自動出力タイマー * 60) + gi自動出力タイマー秒) * 1000;
// MOD 2015.04.13 BEVAS)前田　自動出力タイマー秒対応 END
				tim出荷ＣＳＶ自動出力.Enabled = true;
			}else{
//保留 MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//保留				btn確認.Enabled = true;
//保留 MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
				if(tim出荷ＣＳＶ自動出力 != null){
					tim出荷ＣＳＶ自動出力.Enabled = false;
				}
			}
// MOD 2010.06.01 東都）高木 自動出力ボタンの移動 START
			if(gb自動出力ＯＮ){
				lab自動出力ＯＮ.Visible = true;
				pic送り状荷札発行.Visible   = false;
				picチョイスプリント.Visible = false;
				pic再発行.Visible           = false;
				pic自動出荷登録.Visible     = false;
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 START
				picバーコード読取.Visible = false;
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 END
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 START
				picラベルイメージ印刷.Visible = false;
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 END
			}
			else
			{
				lab自動出力ＯＮ.Visible = false;
				if(gsプリンタＦＧ == "1"){
					pic送り状荷札発行.Visible   = true;
					picチョイスプリント.Visible = true;
					pic再発行.Visible           = true;
				}
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 START
				// エントリーオプションに設定した値により、当該ボタンの表示・非表示を切り替える
				if(gsオプション[22].Equals("0"))
				{
					picバーコード読取.Visible = true;
				}
				else
				{
					picバーコード読取.Visible = false;
				}
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 END
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 START
				picラベルイメージ印刷.Visible = true;
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 END
				pic自動出荷登録.Visible     = true;
			}
// MOD 2010.06.01 東都）高木 自動出力ボタンの移動 END
		}

		private void btn自動出力フォルダ_Click(object sender, System.EventArgs e)
		{
			出荷ＣＳＶ自動出力フォルダ作成();
			if(!Directory.Exists(gsPathSyukka)) return;

			// エクスプローラで開く
			System.Diagnostics.Process process = new System.Diagnostics.Process(); 
			process.StartInfo.Arguments = "\"" + gsPathSyukka + "\"";
			process.StartInfo.WorkingDirectory = gsPathSyukka;
			process.StartInfo.FileName = "explorer.exe";
			try{
				process.Start();
			}catch(System.ComponentModel.Win32Exception ex){
				ログ出力２(" エクスプローラの起動"+ex.Message);
			    // ファイルが見つからなかった場合、
			    // 関連付けられたアプリケーションが見つからなかった場合等
				MessageBox.Show("エクスプローラの起動に失敗しました\n"
								+ ex.Message 
								,"出荷ＣＳＶ自動出力"
								, MessageBoxButtons.OK);
			}catch(System.Exception ex ){
				ログ出力２(" エクスプローラの起動"+ex.Message);
			    // その他
				MessageBox.Show("エクスプローラの起動に失敗しました\n"
								+ ex.Message 
								,"出荷ＣＳＶ自動出力"
								, MessageBoxButtons.OK);
			}
		}
// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 END

		private bool b実行中_tim出荷ＣＳＶ自動出力_Tick = false; // 起動フラグ
		private void tim出荷ＣＳＶ自動出力_Tick(object sender, System.EventArgs e)
		{
			if(b実行中_tim出荷ＣＳＶ自動出力_Tick) return;
// MOD 2010.04.21 東都）高木 ハング近似動作の防止 START
			if(b実行中_ThreadTask1) return;
// MOD 2010.04.21 東都）高木 ハング近似動作の防止 END
			b実行中_tim出荷ＣＳＶ自動出力_Tick = true;
			try{
				if(!Directory.Exists(gsPathSyukka))    return;
				if(!Directory.Exists(gsPathSyukkaIn))  return;
				if(!Directory.Exists(gsPathSyukkaOut)) return;
				if(!Directory.Exists(gsPathSyukkaLog)) return;

// MOD 2010.04.21 東都）高木 ハング近似動作の防止 START
//				// ファイル一覧取得１
////				ログ出力２(" ファイル一覧取得１");
//				string[] sFiles1 = Directory.GetFiles(gsPathSyukkaIn);
//				if(sFiles1.Length == 0) return;
//				DateTime[] dtFiles1 = new DateTime[sFiles1.Length];
//				long[]     lsFiles1 = new long[sFiles1.Length];
//				for(int iCnt = 0; iCnt < sFiles1.Length; iCnt++){
//					dtFiles1[iCnt] = File.GetLastWriteTime(sFiles1[iCnt]);
//					try{
//						FileStream fs = new FileStream(sFiles1[iCnt], FileMode.Open);
//						lsFiles1[iCnt] = fs.Length;
//						fs.Close();
//					}catch(IOException ex){
////保留　エラー処理
//						ログ出力２(" ファイルサイズ取得１ "+ex.Message);
//					}
//				}
//
////保留　テスト時はコメント
////				System.Threading.Thread.Sleep(60 * 1000); // １分間待つ
//				System.Threading.Thread.Sleep(20 * 1000); // ２０秒待つ
//				if(sFiles1 == null) return;
				if(sFiles1.Length == 0){
					ファイル一覧取得１();
					return;
				}
				//スレッドが既に起動中であれば、終了させ破棄する
				if(trd1 != null){
					trd1.Abort();
					trd1 = null;
				}
				if(!gb自動出力ＯＮ) return; //自動出力が無効であれば終了
				//スレッドを作成
				trd1 = new Thread(new ThreadStart(ThreadTask1));
				trd1.IsBackground = true;
				trd1.Start();
			}catch(Exception ex){
//保留　エラー処理
				ログ出力２(" ファイル一覧取得２ "+ex.Message);
			}finally{
				b実行中_tim出荷ＣＳＶ自動出力_Tick = false;
			}
		}

		public bool b実行中_ThreadTask1 = false; // 起動フラグ
		private void ThreadTask1()
		{
			if(b実行中_ThreadTask1) return;
			b実行中_ThreadTask1 = true;
			try{
// MOD 2010.04.21 東都）高木 ハング近似動作の防止 END
				// ファイル一覧取得２
//				ログ出力２(" ファイル一覧取得２");
				string[] sFiles2 = Directory.GetFiles(gsPathSyukkaIn);
				if(sFiles2.Length == 0) return;
				// ファイルスタンプの古い順にソートする
				DateTime[] dtFiles2 = new DateTime[sFiles2.Length];
				for(int iCnt2 = 0; iCnt2 < sFiles2.Length; iCnt2++){
					// ファイルスタンプの取得
					dtFiles2[iCnt2] = File.GetLastWriteTime(sFiles2[iCnt2]);
				}
				Array.Sort(dtFiles2, sFiles2);
				if(!gb自動出力ＯＮ) return; //自動出力が無効であれば終了
				long     lsFile;
// MOD 2010.04.21 東都）高木 ハング近似動作の防止 START
//				string[] s店所情報等 = 店所情報等取得();
				string[] s店所情報等 = null;
// MOD 2010.04.21 東都）高木 ハング近似動作の防止 END
				for(int iCnt2 = 0; iCnt2 < sFiles2.Length; iCnt2++){
					if(!gb自動出力ＯＮ) return; //自動出力が無効であれば終了
					//前回のファイル一覧結果と比較
					for(int iCnt1 = 0; iCnt1 < sFiles1.Length; iCnt1++){
						if(!gb自動出力ＯＮ) return; //自動出力が無効であれば終了
						// ファイル名の比較
						if(sFiles2[iCnt2] != sFiles1[iCnt1]) continue;
						// ファイルスタンプの比較
						if(dtFiles2[iCnt2] != dtFiles1[iCnt1]) break;
						// ファイルサイズの比較
						try{
							FileStream fs = new FileStream(sFiles2[iCnt2], FileMode.Open);
							lsFile = fs.Length;
							fs.Close();
							if(lsFile != lsFiles1[iCnt1]) break;
						}catch(IOException ex){
//保留　エラー処理
							ログ出力２(" ファイルサイズ取得２ "+ex.Message);
							break;
						}

// MOD 2010.04.21 東都）高木 ハング近似動作の防止 START
						if(s店所情報等 == null){
							s店所情報等 = 店所情報等取得();
						}
						System.Threading.Thread.Sleep(200); // 0.2秒待つ
// MOD 2010.04.21 東都）高木 ハング近似動作の防止 END
						出荷ＣＳＶ印刷(sFiles2[iCnt2], s店所情報等[1]
									, s店所情報等[2], s店所情報等[3]);
						break;
					}
				}
// MOD 2010.04.21 東都）高木 ハング近似動作の防止 START
				ファイル一覧取得１();
// MOD 2010.04.21 東都）高木 ハング近似動作の防止 END
			}catch(Exception ex){
//保留　エラー処理
				ログ出力２(" ファイル一覧取得２ "+ex.Message);
			}finally{
// MOD 2010.04.21 東都）高木 ハング近似動作の防止 START
//				b実行中_tim出荷ＣＳＶ自動出力_Tick = false;
				b実行中_ThreadTask1 = false;
// MOD 2010.04.21 東都）高木 ハング近似動作の防止 END
			}
		}

		private string[] 店所情報等取得()
		{
			string[] sCsvRet = {"","","",""};

//			texメッセージ.Text = "出荷日取得中．．．";
//			texメッセージ.Refresh();
			ログ出力２(" 出荷日取得");
//			Cursor = System.Windows.Forms.Cursors.AppStarting;

			部門出荷日情報更新();
			Cursor = System.Windows.Forms.Cursors.Default;

			string[] sRet = {""};
			string s発店ＣＤ   = "";
			string s発店名     = "";
			string s集約店ＣＤ = "";

//			texメッセージ.Text = "発店取得中．．．";
//			texメッセージ.Refresh();
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 START
			//社内伝会員の扱店登録チェック
			if(gs部門店所ＣＤ.Equals("044"))
			{
				ログ出力２(" 社内伝会員扱店チェック");
				Cursor = System.Windows.Forms.Cursors.AppStarting;

				string[] saChkRet = ＣＭ０５会員扱店Ｆチェック();
				int iChkRet = int.Parse(saChkRet[0]);
				string sChkRet = saChkRet[1];

				Cursor = System.Windows.Forms.Cursors.Default;
				if(iChkRet == 1)
				{
					if(sChkRet.Equals("該当データがありません"))
					{
						ログ出力２(" 社内伝会員扱店チェックエラー：ご利用の会員に扱店登録がありませんでした");
						throw new Exception("ご利用の会員に扱店登録がありませんでした");
					}
					else
					{
						ログ出力２(" 社内伝会員扱店チェックエラー：" + sChkRet);
						throw new Exception(sChkRet);
					}
				}
			}
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 END
			ログ出力２(" 発店取得");
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			//発店取得
			try{
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 START
				if(gs部門店所ＣＤ.Equals("044"))
				{
					//社内伝会員向けの、発店を取得
					if(gs会員ＣＤ.Substring(0,1) != "J")
					{
						//福山通運向け
						if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
						sRet = sv_syukka.Get_hatuten2_HouseSlip(gsaユーザ,gs会員ＣＤ);
					}
				}
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 END
// ADD 2010.12.14 ACT）垣原 王子運送の対応 START
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 START
//				if (gs会員ＣＤ.Substring(0,1) != "J")
				else if (gs会員ＣＤ.Substring(0,1) != "J")
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 END
				{
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END
					if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
					sRet = sv_syukka.Get_hatuten2(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
// ADD 2010.12.14 ACT）垣原 王子運送の対応 START
				}
				else
				{
					if(sv_oji == null) sv_oji = new is2oji.Service1();
					sRet = sv_oji.Get_hatuten2(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
				}
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END
			}
			catch (System.Net.WebException)
			{
				ログ出力２(" 発店取得エラー："+gs通信エラー);
				throw new Exception(gs通信エラー);
			}catch (Exception ex){
				ログ出力２(" 発店取得エラー："+ex.Message);
				throw new Exception("通信エラー：" + ex.Message);
			}finally{
				Cursor = System.Windows.Forms.Cursors.Default;
			}
			if(sRet[0].Equals("正常終了")){
				s発店ＣＤ = sRet[1];	//発店ＣＤ
				s発店名   = sRet[2];	//発店名
				if (s発店名.Length == 0) s発店名 = " ";
			}else{
				if(sRet[0].Equals("該当データがありません")){
					ログ出力２(" 発店取得エラー：発店を決められませんでした");
					throw new Exception("発店を決められませんでした");
				}else{
					ログ出力２(" 発店取得エラー："+sRet[0]);
					throw new Exception(sRet[0]);
				}
			}
//			texメッセージ.Text = "集約店取得中．．．";
//			texメッセージ.Refresh();
			ログ出力２(" 集約店取得");
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			//集約店取得
			try{
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 START
				if(gs部門店所ＣＤ.Equals("044"))
				{
					//社内伝会員向けの、集約店を取得
					if(gs会員ＣＤ.Substring(0,1) != "J")
					{
						//福山通運向け
						if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
						sRet = sv_syukka.Get_syuuyakuten2_HouseSlip(gsaユーザ,gs会員ＣＤ);
					}
				}
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 END
// ADD 2010.12.14 ACT）垣原 王子運送の対応 START
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 START
//				if (gs会員ＣＤ.Substring(0,1) != "J")
				else if (gs会員ＣＤ.Substring(0,1) != "J")
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 END
				{
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END
					if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
					sRet = sv_syukka.Get_syuuyakuten2(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
// ADD 2010.12.14 ACT）垣原 王子運送の対応 START
				}
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 START
				else if(gs部門店所ＣＤ.Equals("044"))
				{
					//社内伝会員向けの、集約店を取得
					if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
					sRet = sv_syukka.Get_syuuyakuten2_HouseSlip(gsaユーザ,gs会員ＣＤ);
				}
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 END
				else
				{
					if(sv_oji == null) sv_oji = new is2oji.Service1();
					sRet = sv_oji.Get_syuuyakuten2(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
				}
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END
			}catch (System.Net.WebException){
				ログ出力２(" 集約店取得エラー："+gs通信エラー);
				throw new Exception(gs通信エラー);
			}catch (Exception ex){
				ログ出力２(" 集約店取得エラー："+ex.Message);
				throw new Exception("通信エラー：" + ex.Message);
			}finally{
				Cursor = System.Windows.Forms.Cursors.Default;
			}
			if(sRet[0] != " "){
				s集約店ＣＤ = sRet[1];	//集約店ＣＤ
			}else{
				if(sRet[0].Equals("該当データがありません")){
					ログ出力２(" 集約店取得エラー：集約店を決められませんでした");
					throw new Exception("集約店を決められませんでした");
				}else{
					ログ出力２(" 集約店取得エラー："+sRet[0]);
					throw new Exception(sRet[0]);
				}
			}
			sCsvRet[1] = s発店ＣＤ; 
			sCsvRet[2] = s発店名; 
			sCsvRet[3] = s集約店ＣＤ; 

			return sCsvRet;
		}
		private void 出荷ＣＳＶ印刷(string sCsvFile, string s発店ＣＤ, string s発店名, string s集約店ＣＤ)
		{
			string sErr = "";
			string[] sRet = {""};
// MOD 2010.04.19 東都）高木 出力ファイル名の変更 START
//			string sErrFile = gsPathSyukkaOut + "\\" + Path.GetFileName(sCsvFile) + ".txt";
			string s実行日時 = DateTime.Now.ToString("yyyyMMddHHmmss");
			string sErrFile  = gsPathSyukkaOut + "\\" + Path.GetFileName(sCsvFile)
							 + "_" + s実行日時 + ".txt";
// MOD 2010.04.19 東都）高木 出力ファイル名の変更 END

// 保留　ＣＳＶ形式チェック
//			if (!axGT取込データ一覧.LoadCsvFile(sCsvFile))
//			{
//				texメッセージ.Text = "CSVファイルの取り込みに失敗しました";
//				axGT取込データ一覧.Rows = 10;
//				return;
//			}

			bエラー出力２ = false;
			iエラー行数２ = 0;
			i前回エラー行 = 0;

//保留　1000件は仮設定
			string[] s取込データ２ = new string[1000];
			int i取込行数２ = 0;
			int iCnt = 0;

//			texメッセージ.Text = "出荷ＣＳＶ自動出力 読込中．．．";
//			texメッセージ.Refresh();
			ログ出力２(" 入力ファイル["+sCsvFile+"]");
			ログ出力２(" チェック開始");
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			StreamReader sr = new StreamReader(sCsvFile, System.Text.Encoding.Default);
//保留　画面の先頭行無視を有効にするか
//			if( cBox先頭行無視.Checked ){
//				if(sr.Peek() != -1) iCnt++;
//				string sDataDummy = sr.ReadLine();
//			}

			try
			{
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 START
				string sChkMsg = "";
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 END
//保留　1000件は仮設定
//				while(iCnt <= 1000)
				while(iCnt <= 2000)
				{
					if(!gb自動出力ＯＮ) return; //自動出力が無効であれば終了
					if(sr.Peek() == -1) break;
//					texメッセージ.Text = "出荷ＣＳＶ自動出力 確認中．．．" + iCnt + "件目";
//					texメッセージ.Refresh();
					iCnt++;
					ログ出力２(" チェック " + iCnt.ToString("0000") + " 行目");
					string sData = sr.ReadLine();

					//UniCodeの改行対応
					if(sData == null) sData = "";

					string[] sValue = sData.Replace("\"","").Replace("\'","").Split(',');
					if(sValue.Length <= 1){
						continue;
					}

// MOD 2011.07.14 東都）高木 記事行の追加 START
//					if(sValue.Length != 26 && sValue.Length != 25){
//						エラー出力２(sErrFile, iCnt, 0, "項目数が違います\r\n");
//						continue;
//					}
					if(sValue.Length != 26 && sValue.Length != 25
						&& sValue.Length != 30 && sValue.Length != 29){
						エラー出力２(sErrFile, iCnt, 0, "項目数が違います\r\n");
						continue;
					}
					if(sValue.Length == 30 || sValue.Length == 29)
					{
						iＣＳＶエントリー形式 = 2;
					}
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 START
					//「記事6行フォーマットCSV→記事3行フォーマットCSV」の取込時のバグを修正
					//　　※「Index was outside the bounds of the array.（＝IndexOutOfRangeException）」が発生
					else if(sValue.Length == 26 || sValue.Length == 25)
					{
						iＣＳＶエントリー形式 = 1;
					}
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
// MOD 2011.07.14 東都）高木 記事行の追加 END

					//ヘッダ行なので読み飛ばし
					if(sValue[0].IndexOf("荷受人コード") >= 0
						&& sValue[1].IndexOf("電話番号") >= 0
						&& sValue[2].IndexOf("住所") >= 0){
						continue;
					}
//保留　1000件は仮設定
					if(i取込行数２ >= s取込データ２.Length){
						エラー出力２(sErrFile, iCnt, 0
							, s取込データ２.Length + "件を超えたので処理できません。\r\n");
						break;
					}

//保留 MOD 2011.04.13 東都）高木 重量入力不可対応 START
//					// 才数・重量に０を設定
//					if(sValue.Length > 12) sValue[12] = "0";
//					if(sValue.Length > 13) sValue[13] = "0";
//保留 MOD 2011.04.13 東都）高木 重量入力不可対応 END

// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
//					string[] sKey   = new string[46];
// MOD 2011.07.14 東都）高木 記事行の追加 START
//					string[] sKey   = new string[47];
					string[] sKey = null;
					if(iＣＳＶエントリー形式 == 2){
						sKey = new string[50];
					}else{
						sKey = new string[47];
					}
// MOD 2011.07.14 東都）高木 記事行の追加 END
					sKey[46] = gs重量入力制御;
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
// MOD 2011.07.14 東都）高木 記事行の追加 START
					string[] sValue一覧行 = new string[sValue.Length];
					if(iＣＳＶエントリー形式 == 2){
						System.Array.Copy(sValue, sValue一覧行, sValue.Length);
						sValue[(int)形式１.個数] = sValue一覧行[(int)形式２.個数];
						sValue[(int)形式１.才数] = sValue一覧行[(int)形式２.才数];
						sValue[(int)形式１.重量] = sValue一覧行[(int)形式２.重量];
						sValue[(int)形式１.輸送商品１] = sValue一覧行[(int)形式２.輸送商品１];
						sValue[(int)形式１.輸送商品２] = sValue一覧行[(int)形式２.輸送商品２];
						sValue[(int)形式１.品名記事１] = sValue一覧行[(int)形式２.品名記事１];
						sValue[(int)形式１.品名記事２] = sValue一覧行[(int)形式２.品名記事２];
						sValue[(int)形式１.品名記事３] = sValue一覧行[(int)形式２.品名記事３];
						sValue[(int)形式１.配達指定日] = sValue一覧行[(int)形式２.配達指定日];
						sValue[(int)形式１.お客様管理番号] = sValue一覧行[(int)形式２.お客様管理番号];
						sValue[(int)形式１.予備] = "";
						sValue[(int)形式１.元払区分] = sValue一覧行[(int)形式２.元払区分];
						sValue[(int)形式１.保険金額] = sValue一覧行[(int)形式２.保険金額];
						sValue[(int)形式１.出荷日付] = sValue一覧行[(int)形式２.出荷日付];
// MOD 2011.08.11 東都）高木 記事行の追加（登録日付省略時障害対応）  START
//						sValue[(int)形式１.登録日付] = sValue一覧行[(int)形式２.登録日付];
						if(sValue一覧行.Length > (int)形式２.登録日付){
							sValue[(int)形式１.登録日付] = sValue一覧行[(int)形式２.登録日付];
						}else{
							sValue[(int)形式１.登録日付] = "";
						}
// MOD 2011.08.11 東都）高木 記事行の追加（登録日付省略時障害対応）  END
					}
// MOD 2011.07.14 東都）高木 記事行の追加 END
					sKey[0] = gs会員ＣＤ;
					sKey[1] = gs部門ＣＤ;
					sKey[3] = " ";

					//荷受人コード
					sKey[5]  = " ";				//電話番号１
					sKey[6]  = " ";				//電話番号２
					sKey[7]  = " ";				//電話番号３
					sKey[9]  = " ";				//住所１
					sKey[10] = " ";				//住所２
					sKey[11] = " ";				//住所３
					sKey[12] = " ";				//名前１
					sKey[13] = " ";				//名前２
					sKey[14] = " ";				//郵便番号
					sKey[17] = " ";				//特殊計
					sValue[0] = sValue[0].Trim();
					if(sValue[0].Length != 0)
					{
						if(!半角チェック(sValue[0])) エラー出力２(sErrFile, iCnt, 1, "荷受人コードは半角文字で入力してください\r\n");
						sKey[4] = sValue[0];
						if(半角チェック(sValue[0]))
						{
							if(!記号チェック(sValue[0])){
								エラー出力２(sErrFile, iCnt, 1, "荷受人コードに使用できない記号があります\r\n");
							}else{
								//荷受人コード存在チェック
								try
								{
//保留　チェックをまとめる予定
//		sValue[0]は半角
//		sValue[0]は記号ではない
//		sValue[0]は７桁以内
//	引数：
//		gs会員ＣＤ
//		gs部門ＣＤ
//		sKey[4]		荷受人ＣＤ
//	戻り値：
//		[0]		結果
//		[2-12]	値（電話番号１など）
//	概要：
//		お届け先情報を取得する
									if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
									sRet = sv_otodoke.Get_Stodokesaki(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,sKey[4]);
								}
								catch (System.Net.WebException)
								{
									エラー出力２(sErrFile, iCnt, 1
										, "荷受人情報取得エラー："+gs通信エラー+"\r\n");
									throw new Exception(gs通信エラー);
								}
								catch (Exception ex)
								{
									エラー出力２(sErrFile, iCnt, 1
										, "荷受人情報取得エラー："+ex.Message+"\r\n");
									throw new Exception("通信エラー：" + ex.Message);
								}
								if(!sRet[0].Equals("更新"))
								{
									if(sRet[0].Equals("登録"))
									{
										エラー出力２(sErrFile, iCnt, 1
											, "荷受人コード["+sKey[4]+"]が存在しません\r\n");
									}
									else
									{
										エラー出力２(sErrFile, iCnt, 1
											, "荷受人情報取得エラー："+sRet[0]+"\r\n");
										throw new Exception(sRet[0]);
									}
								}
								else
								{
									sKey[5]  = sRet[2];				//電話番号１
									if (sKey[5].Length == 0) sKey[5] = " ";
									sKey[6]  = sRet[3];				//電話番号２
									if (sKey[6].Length == 0) sKey[6] = " ";
									sKey[7]  = sRet[4];				//電話番号３
									if (sKey[7].Length == 0) sKey[7] = " ";
									sKey[9]  = sRet[7];				//住所１
									if (sKey[9].Length == 0) sKey[9] = " ";
									sKey[10] = sRet[8];				//住所２
									if (sKey[10].Length == 0) sKey[10] = " ";
									sKey[11] = sRet[9];				//住所３
									if (sKey[11].Length == 0) sKey[11] = " ";
									sKey[12] = sRet[10];			//名前１
									if (sKey[12].Length == 0) sKey[12] = " ";
									sKey[13] = sRet[11];			//名前２
									if (sKey[13].Length == 0) sKey[13] = " ";
									sKey[14] = sRet[5] + sRet[6];	//郵便番号
									sKey[17] = sRet[12];			//特殊計
									if (sKey[17].Length == 0) sKey[17] = " ";
									if (sKey[14].Length != 0)
									{
										//住所存在チェック
										try
										{
//保留　チェックをまとめる予定
//		sKey[14]（郵便番号）が入力
//	引数：
//		sKey[0]		会員ＣＤ
//		sKey[1]		部門ＣＤ
//		sKey[4]		荷受人ＣＤ
//		sKey[14]	郵便番号
//		sKey[9]+[10]+[11] 住所１２３
//		sKey[12]+[13] 名前１２
//	戻り値：
//		[0]		結果
//		[1]		住所ＣＤ
//		[2]		着店ＣＤ
//		[3]		着店名
//	概要：
//		着店情報を取得する

// MOD 2015.05.07 BEVAS）前田 王子運送郵便番号存在チェック対応 START
											if (gs会員ＣＤ.Substring(0,1) != "J") 
											{
// MOD 2015.05.07 BEVAS）前田 王子運送郵便番号存在チェック対応 END
												if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
												sRet = sv_syukka.Get_autoEntryPref3(gsaユーザ, sKey[0], sKey[1], sKey[4]
													, sKey[14], sKey[9] + sKey[10] + sKey[11], sKey[12] + sKey[13]);
// MOD 2015.05.07 BEVAS）前田 王子運送郵便番号存在チェック対応 START
											} 
											else 
											{
												// 王子の会員様の場合は王子の郵便番号マスタをチェック
												if(sv_oji == null) sv_oji = new is2oji.Service1();
												sRet = sv_oji.Get_autoEntryPref3(gsaユーザ, sKey[0], sKey[1], sKey[4]
													, sKey[14], sKey[9] + sKey[10] + sKey[11], sKey[12] + sKey[13]);
											}
// MOD 2015.05.07 BEVAS）前田 王子運送郵便番号存在チェック対応 END

										}
										catch (System.Net.WebException)
										{
											エラー出力２(sErrFile, iCnt, 1
												, "荷受人着店取得エラー："+gs通信エラー+"\r\n");
											throw new Exception(gs通信エラー);
										}
										catch (Exception ex)
										{
											エラー出力２(sErrFile, iCnt, 1
												, "荷受人着店取得エラー："+ex.Message+"\r\n");
											throw new Exception("通信エラー：" + ex.Message);
										}
										if(sRet[0].Length != 4)
										{
											if(sRet[0].Equals("該当データがありません"))
											{
												エラー出力２(sErrFile, iCnt, 1
													, "郵便番号["+sKey[14]+"]が存在しません\r\n");
											}
											else
											{
												エラー出力２(sErrFile, iCnt, 1
													, "荷受人着店取得エラー："+sRet[0]+"\r\n");
												throw new Exception(sRet[0]);
											}
										}
										else
										{
											sKey[15] = sRet[2];	//着店ＣＤ
											sKey[16] = sRet[3];	//着店名
											if (sKey[16].Length == 0) sKey[16] = " ";
											sKey[8]  = sRet[1];	//住所ＣＤ
										}
									}
									else
									{
										sKey[14] = " "; // 荷受人ＣＤ
									}
								}
							}
						}
					}
					else
					{
						sKey[4] = " "; // 荷受人ＣＤ
					}

					//電話番号
					sValue[1] = sValue[1].Trim();
					if (sKey[4].Trim().Length == 0 && !必須チェック(sValue[1])) エラー出力２(sErrFile, iCnt, 2, "電話番号は必須項目です\r\n");
					if (sValue[1].Length != 0)
					{
						try
						{
							if (!半角チェック(sValue[1])) エラー出力２(sErrFile, iCnt, 2, "電話番号は半角文字で入力してください\r\n");
							if (sValue[1].IndexOf("(") == -1 && sValue[1].LastIndexOf(")") == -1)
							{
								if (sValue[1].IndexOf("-") == sValue[1].LastIndexOf("-") && sValue[1].IndexOf("-") != -1)
								{
									sKey[5] = " ";
									sKey[6] = sValue[1].Substring(0, sValue[1].IndexOf("-"));
									sKey[7] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
									if (!数値チェック(sKey[6]) || !数値チェック(sKey[7]))
										エラー出力２(sErrFile, iCnt, 2, "電話番号は数値で入力してください\r\n");
								}
								else if (sValue[1].IndexOf("-") != sValue[1].LastIndexOf("-") && sValue[1].IndexOf("-") != -1)
								{
									sKey[5] = sValue[1].Substring(0, sValue[1].IndexOf("-"));
									sKey[6] = sValue[1].Substring(sValue[1].IndexOf("-") + 1, sValue[1].LastIndexOf("-") - sValue[1].IndexOf("-") - 1);
									sKey[7] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
									if (!数値チェック(sKey[5]) || !数値チェック(sKey[6]) || !数値チェック(sKey[7]))
										エラー出力２(sErrFile, iCnt, 2, "電話番号は数値で入力してください\r\n");
								}
								else if (sValue[1].Length == 9)
								{
									//電話番号９桁
									if (sValue[1].Substring(0,1).Equals("3") || sValue[1].Substring(0,1).Equals("6"))
									{
										//東京、大阪は 1-4-4で編集
										sKey[5] = sValue[1].Substring(0,1);
										sKey[6] = sValue[1].Substring(1,4);
										sKey[7] = sValue[1].Substring(5,4);
									}
									else
									{
										//それ以外は3-2-4で編集
										sKey[5] = sValue[1].Substring(0,3);
										sKey[6] = sValue[1].Substring(3,2);
										sKey[7] = sValue[1].Substring(5,4);
									}
									if (!数値チェック(sKey[5]) || !数値チェック(sKey[6]) || !数値チェック(sKey[7]))
										エラー出力２(sErrFile, iCnt, 2, "電話番号は数値で入力してください\r\n");
								}
								else if (sValue[1].Length == 10)
								{
									//電話番号１０桁
									if (sValue[1].Substring(0,2).Equals("03") || sValue[1].Substring(0,2).Equals("06"))
									{
										//東京、大阪は 2-4-4で編集
										sKey[5] = sValue[1].Substring(0,2);
										sKey[6] = sValue[1].Substring(2,4);
										sKey[7] = sValue[1].Substring(6,4);
									}
									else
									{
										//それ以外は4-2-4で編集
										sKey[5] = sValue[1].Substring(0,4);
										sKey[6] = sValue[1].Substring(4,2);
										sKey[7] = sValue[1].Substring(6,4);
									}
									if (!数値チェック(sKey[5]) || !数値チェック(sKey[6]) || !数値チェック(sKey[7]))
										エラー出力２(sErrFile, iCnt, 2, "電話番号は数値で入力してください\r\n");
								}
								else if (sValue[1].Length == 11)
								{
									//電話番号１１桁
									if(sValue[1].Substring(0,3).Equals("090")
									 || sValue[1].Substring(0,3).Equals("080")
									 || sValue[1].Substring(0,3).Equals("070")
									 || sValue[1].Substring(0,3).Equals("050")){
										//携帯電話は 3-4-4で編集
										sKey[5] = sValue[1].Substring(0,3);
										sKey[6] = sValue[1].Substring(3,4);
										sKey[7] = sValue[1].Substring(7,4);
									}else{
										//4-3-4で編集
										sKey[5] = sValue[1].Substring(0,4);
										sKey[6] = sValue[1].Substring(4,3);
										sKey[7] = sValue[1].Substring(7,4);
									}
									if (!数値チェック(sKey[5]) || !数値チェック(sKey[6]) || !数値チェック(sKey[7]))
										エラー出力２(sErrFile, iCnt, 2, "電話番号は数値で入力してください\r\n");
								}
								else if (sValue[1].Length == 12)
								{
									//電話番号１２桁
									//4-4-4で編集
									sKey[5] = sValue[1].Substring(0,4);
									sKey[6] = sValue[1].Substring(4,4);
									sKey[7] = sValue[1].Substring(8,4);
									if (!数値チェック(sKey[5]) || !数値チェック(sKey[6]) || !数値チェック(sKey[7]))
										エラー出力２(sErrFile, iCnt, 2, "電話番号は数値で入力してください\r\n");
								}
								else
								{
									エラー出力２(sErrFile, iCnt, 2, "電話番号の形式に誤りがあります\r\n");
								}
							}
							else if (sValue[1].IndexOf("(") != -1 && sValue[1].LastIndexOf(")") != -1)
							{
								sKey[5] = sValue[1].Substring(sValue[1].IndexOf("(") + 1, sValue[1].LastIndexOf(")") - sValue[1].IndexOf("(") - 1);
								sKey[6] = sValue[1].Substring(sValue[1].IndexOf(")") + 1, sValue[1].LastIndexOf("-") - sValue[1].IndexOf(")") - 1);
								sKey[7] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
								if (!数値チェック(sKey[5]) || !数値チェック(sKey[6]) || !数値チェック(sKey[7]))
									エラー出力２(sErrFile, iCnt, 2, "電話番号は数値で入力してください\r\n");
							}
							else
							{
								エラー出力２(sErrFile, iCnt, 2, "電話番号の形式に誤りがあります\r\n");
							}
							if (sKey[5].Length > 6) エラー出力２(sErrFile, iCnt, 2, "電話番号(市外)は６文字以内で入力してください\r\n");
							if (sKey[6].Length > 4) エラー出力２(sErrFile, iCnt, 2, "電話番号(市内)は４文字以内で入力してください\r\n");
							if (sKey[7].Length > 4) エラー出力２(sErrFile, iCnt, 2, "電話番号(番号)は４文字以内で入力してください\r\n");
						}
						catch
						{
							エラー出力２(sErrFile, iCnt, 2, "電話番号の形式に誤りがあります\r\n");
						}
					}
					
					//住所
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//					sValue[2] = sValue[2].Trim();
//					sValue[3] = sValue[3].Trim();
//					sValue[4] = sValue[4].Trim();
					if(gsオプション[18].Equals("1")){
						sValue[2] = sValue[2].TrimEnd();
						sValue[3] = sValue[3].TrimEnd();
						sValue[4] = sValue[4].TrimEnd();
					}else{
						sValue[2] = sValue[2].Trim();
						sValue[3] = sValue[3].Trim();
						sValue[4] = sValue[4].Trim();
					}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
					if (sValue[2].Length != 0 || sValue[3].Length != 0 || sValue[4].Length != 0)
					{
						if (!必須チェック(sValue[2])) エラー出力２(sErrFile, iCnt, 3, "住所１は必須項目です\r\n");
						if (sValue[2].Length != 0)
						{
							if (!漢字変換_CSV(ref sValue[2], ref sErr))
							{
								エラー出力２(sErrFile, iCnt, 3, "住所１はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}
							else
							{
								// 文字変換後出力(iCnt, 3, sValue[2]);
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 START
							if(!全角変換チェック(ref sValue[2], ref sErr)){
								エラー出力２(sErrFile, iCnt, 3, "住所１は全角文字変換がおこなえませんでした"
													 + "『" + sErr + "』\r\n");
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 END
						}
						if (sValue[3].Length != 0)
						{
							if (!漢字変換_CSV(ref sValue[3], ref sErr))
							{
								エラー出力２(sErrFile, iCnt, 4, "住所２はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}
							else
							{
								// 文字変換後出力(iCnt, 4, sValue[3]);
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 START
							if(!全角変換チェック(ref sValue[3], ref sErr)){
								エラー出力２(sErrFile, iCnt, 4, "住所２は全角文字変換がおこなえませんでした"
													 + "『" + sErr + "』\r\n");
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 END
						}
						if (sValue[4].Length != 0)
						{
							if (!漢字変換_CSV(ref sValue[4], ref sErr))
							{
								エラー出力２(sErrFile, iCnt, 5, "住所３はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}
							else
							{
								// 文字変換後出力(iCnt, 5, sValue[4]);
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 START
							if(!全角変換チェック(ref sValue[4], ref sErr)){
								エラー出力２(sErrFile, iCnt, 5, "住所３は全角文字変換がおこなえませんでした"
													 + "『" + sErr + "』\r\n");
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 END
						}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 START
//						sValue[2] = Microsoft.VisualBasic.Strings.StrConv(sValue[2], Microsoft.VisualBasic.VbStrConv.Wide, 0);
//						sValue[3] = Microsoft.VisualBasic.Strings.StrConv(sValue[3], Microsoft.VisualBasic.VbStrConv.Wide, 0);
//						sValue[4] = Microsoft.VisualBasic.Strings.StrConv(sValue[4], Microsoft.VisualBasic.VbStrConv.Wide, 0);
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 END
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 START
//						sValue[2] = sValue[2].Replace('\\','￥');
//						sValue[3] = sValue[3].Replace('\\','￥');
//						sValue[4] = sValue[4].Replace('\\','￥');
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 END
						//全角２０桁を超える項目がある場合結合して再分配
						if (sValue[2].Length > 20 || sValue[3].Length > 20 || sValue[4].Length > 20)
						{
							string s住所 = sValue[2] + sValue[3] + sValue[4];
							sKey[9] = s住所.Substring(0, 20);
							if (s住所.Length <= 40)
								sKey[10] = s住所.Substring(20);
							else
							{
								sKey[10] = s住所.Substring(20, 20);
								if (s住所.Length <= 60)
									sKey[11] = s住所.Substring(40);
								else
									sKey[11] = s住所.Substring(40, 20);
							}
						}
						else
						{
							sKey[9]  = sValue[2];
							sKey[10] = sValue[3];
							sKey[11] = sValue[4];
						}
						if (sKey[9].Length == 0)  sKey[9]  = " ";
						if (sKey[10].Length == 0) sKey[10] = " ";
						if (sKey[11].Length == 0) sKey[11] = " ";
					}
					else if (sKey[4].Trim().Length == 0) エラー出力２(sErrFile, iCnt, 3, "住所１は必須項目です\r\n");

					//名前
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//					sValue[5] = sValue[5].Trim();
//					sValue[6] = sValue[6].Trim();
					if(gsオプション[18].Equals("1")){
						sValue[5] = sValue[5].TrimEnd();
						sValue[6] = sValue[6].TrimEnd();
					}else{
						sValue[5] = sValue[5].Trim();
						sValue[6] = sValue[6].Trim();
					}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
					if (sValue[5].Length != 0 || sValue[6].Length != 0)
					{
						if (!必須チェック(sValue[5])) エラー出力２(sErrFile, iCnt, 6, "名前１は必須項目です\r\n");
						if (sValue[5].Length != 0)
						{
							if (!漢字変換_CSV(ref sValue[5], ref sErr))
							{
								エラー出力２(sErrFile, iCnt, 6, "名前１はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}
							else
							{
								// 文字変換後出力(iCnt, 6, sValue[5]);
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 START
							if(!全角変換チェック(ref sValue[5], ref sErr)){
								エラー出力２(sErrFile, iCnt, 6, "名前１は全角文字変換がおこなえませんでした"
													 + "『" + sErr + "』\r\n");
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 END
						}
						if (sValue[6].Length != 0)
						{
							if (!漢字変換_CSV(ref sValue[6], ref sErr))
							{
								エラー出力２(sErrFile, iCnt, 7, "名前２はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}
							else
							{
								// 文字変換後出力(iCnt, 7, sValue[6]);
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 START
							if(!全角変換チェック(ref sValue[6], ref sErr)){
								エラー出力２(sErrFile, iCnt, 7, "名前２は全角文字変換がおこなえませんでした"
													 + "『" + sErr + "』\r\n");
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 END
						}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 START
//						sValue[5] = Microsoft.VisualBasic.Strings.StrConv(sValue[5], Microsoft.VisualBasic.VbStrConv.Wide, 0);
//						sValue[6] = Microsoft.VisualBasic.Strings.StrConv(sValue[6], Microsoft.VisualBasic.VbStrConv.Wide, 0);
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 END
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 START
//						sValue[5] = sValue[5].Replace('\\','￥');
//						sValue[6] = sValue[6].Replace('\\','￥');
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 END
						//全角２０桁を超える項目がある場合結合して再分配
						if (sValue[5].Length > 20 || sValue[6].Length > 20)
						{
							string s名前 = sValue[5] + sValue[6];
							sKey[12] = s名前.Substring(0, 20);
							if (s名前.Length <= 40)
								sKey[13] = s名前.Substring(20);
							else
								sKey[13] = s名前.Substring(20, 20);
						}
						else
						{
							sKey[12] = sValue[5];
							sKey[13] = sValue[6];
						}
						if (sKey[12].Length == 0) sKey[12] = " ";
						if (sKey[13].Length == 0) sKey[13] = " ";
					}
					else if (sKey[4].Trim().Length == 0) エラー出力２(sErrFile, iCnt, 6, "名前１は必須項目です\r\n");
					
					//郵便番号
					sValue[7] = sValue[7].Trim().Replace("-", "");
					if (sKey[4].Trim().Length == 0 && !必須チェック(sValue[7])) エラー出力２(sErrFile, iCnt, 8, "郵便番号は必須項目です\r\n");
					if (sValue[7].Length != 0)
					{
						if (!数値チェック(sValue[7])) エラー出力２(sErrFile, iCnt, 8, "郵便番号は数値で入力してください\r\n");
						if (sValue[7].Length > 7) エラー出力２(sErrFile, iCnt, 8, "郵便番号は７文字以内で入力してください\r\n");
						if (数値チェック(sValue[7]) && sValue[7].Length <= 7)
						{
							//住所存在チェック
							try
							{
//保留　チェックをまとめる予定
//		sValue[7]（郵便番号）は数値
//		sValue[7]（郵便番号）は７桁以内
//	引数：
//		sKey[0]		会員ＣＤ
//		sKey[1]		部門ＣＤ
//		sKey[4]		荷受人ＣＤ
//		sValue[7]	郵便番号
//		sValue[2]+[3]+[4] 住所１２３
//		sValue[5]+[6] 名前１２
//	戻り値：
//		[0]		結果
//		[1]		住所ＣＤ
//		[2]		着店ＣＤ
//		[3]		着店名
//	概要：
//		着店情報を取得する


// MOD 2015.05.07 BEVAS）前田 王子運送郵便番号存在チェック対応 START
								if (gs会員ＣＤ.Substring(0,1) != "J") 
								{
// MOD 2015.05.07 BEVAS）前田 王子運送郵便番号存在チェック対応 END
									if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
									sRet = sv_syukka.Get_autoEntryPref3(gsaユーザ, sKey[0], sKey[1], sKey[4], sValue[7]
										, sValue[2] + sValue[3] + sValue[4], sValue[5] + sValue[6]);
// MOD 2015.05.07 BEVAS）前田 王子運送郵便番号存在チェック対応 START
								} 
								else 
								{
// 王子の会員様の場合は王子の郵便番号マスタをチェック
									if(sv_oji == null) sv_oji = new is2oji.Service1();
									sRet = sv_oji.Get_autoEntryPref3(gsaユーザ, sKey[0], sKey[1], sKey[4], sValue[7]
										, sValue[2] + sValue[3] + sValue[4], sValue[5] + sValue[6]);	
								}
// MOD 2015.05.07 BEVAS）前田 王子運送郵便番号存在チェック対応 END

							}
							catch (System.Net.WebException)
							{
								エラー出力２(sErrFile, iCnt, 8
									, "荷受人着店取得エラー："+gs通信エラー+"\r\n");
								throw new Exception(gs通信エラー);
							}
							catch (Exception ex)
							{
								エラー出力２(sErrFile, iCnt, 8
									, "荷受人着店取得エラー："+ex.Message+"\r\n");
								throw new Exception("通信エラー：" + ex.Message);
							}
							if(sRet[0].Length != 4)
							{
								if(sRet[0].Equals("該当データがありません"))
								{
									エラー出力２(sErrFile, iCnt, 8
										, "郵便番号["+sValue[7]+"]が存在しません\r\n");
								}
								else
								{
									エラー出力２(sErrFile, iCnt, 8
										, "荷受人着店取得エラー："+sRet[0]+"\r\n");
									throw new Exception(sRet[0]);
								}
							}
							else
							{
								sKey[15] = sRet[2];	//着店ＣＤ
								sKey[16] = sRet[3];	//着店名
								if (sKey[16].Length == 0) sKey[16] = " ";
								sKey[8]  = sRet[1];	//住所ＣＤ
							}
						}
						sKey[14] = sValue[7];
					}
					sKey[21] = s発店ＣＤ;
					sKey[22] = s発店名;
					sKey[20] = s集約店ＣＤ;
					
					//特殊計
					sValue[8] = sValue[8].Trim();
					if (sValue[8].Length != 0)
					{
						sKey[17] = sValue[8];
						if (sKey[17].Length == 0) sKey[17] = " ";
						if (半角チェック(sValue[8]))
						{
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
//							if(!記号チェック(sValue[8])) エラー出力２(sErrFile, iCnt, 9, "特殊計に使用できない記号があります\r\n");
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
							if (sValue[8].Length > 5) エラー出力２(sErrFile, iCnt, 9, "特殊計は半角５文字以内で入力してください\r\n");
						}
						else
						{
							エラー出力２(sErrFile, iCnt, 9, "特殊計は半角文字で入力してください\r\n");
						}
					}

					//荷送人コード
					sValue[10] = sValue[10].Trim();
					if (!必須チェック(sValue[10])) エラー出力２(sErrFile, iCnt, 11, "荷送人コードは必須項目です\r\n");
					if (!半角チェック(sValue[10])) エラー出力２(sErrFile, iCnt, 11, "荷送人コードは半角文字で入力してください\r\n");
					sKey[18] = sValue[10];
					sKey[23] = " ";
					sKey[24] = " ";
					sKey[25] = " ";
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 START
					int i荷送人固定重量 = 0;
					int i荷送人固定才数 = 0;
					bool b重量才数再設定FLG = false;
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
					//荷送人コード存在チェック
					if (必須チェック(sKey[18]) && 半角チェック(sKey[18]))
					{
						if(!記号チェック(sValue[10])){
							エラー出力２(sErrFile, iCnt, 11, "荷送人コードに使用できない記号があります\r\n");
						}else{
							//荷送人存在チェック
							try
							{
//保留　チェックをまとめる予定
//		sValue[10]は必須
//		sValue[10] -> sKey[18]（荷送人コード）が半角
								if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
//保留 MOD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 START
//保留 MOD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 END
								sRet = sv_syukka.Get_autoEntryClaim(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,sKey[18]);
							}
							catch (System.Net.WebException)
							{
								エラー出力２(sErrFile, iCnt, 11
									, "荷送人情報取得エラー："+gs通信エラー+"\r\n");
								throw new Exception(gs通信エラー);
							}
							catch (Exception ex)
							{
								エラー出力２(sErrFile, iCnt, 11
									, "荷送人情報取得エラー："+ex.Message+"\r\n");
								throw new Exception("通信エラー：" + ex.Message);
							}
							if(sRet[0].Length != 4)
							{
								if(sRet[0].Equals("該当データがありません"))
								{
									エラー出力２(sErrFile, iCnt, 11
										, "荷送人コード["+sKey[18]+"]が存在しません\r\n");
								}
								else
								{
									エラー出力２(sErrFile, iCnt, 11
										, "荷送人情報取得エラー："+sRet[0]+"\r\n");
									throw new Exception(sRet[0]);
								}
							}
							else
							{
								sKey[23] = sRet[1];	//得意先ＣＤ
								sKey[24] = sRet[2];	//部課ＣＤ
								if(sKey[24].Length == 0) sKey[24] = " ";
								sKey[25] = sRet[3]; //得意先部課名
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 START
								i荷送人固定重量 = int.Parse(sRet[4].Trim());
								i荷送人固定才数 = int.Parse(sRet[5].Trim());
								b重量才数再設定FLG = true;
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
// MOD 2010.09.03 東都）高木 ＣＳＶエントリー時の請求先エラー表記修正 START
//								if (sKey[25].Trim().Length == 0) エラー出力２(sErrFile, iCnt, 11, "得意先部課名が存在しません\r\n");
								if(sKey[25].Trim().Length == 0)
								{
									string s請求先ＣＤ = sRet[1].Trim();
									if(sRet[2].Trim().Length > 0){
										s請求先ＣＤ += "-" + sRet[2].Trim();
									}
									エラー出力２(sErrFile, iCnt, 11
									, "荷送人の請求先["+s請求先ＣＤ+"]は登録されていません\r\n");
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 START
									b重量才数再設定FLG = false;
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
								}
// MOD 2010.09.03 東都）高木 ＣＳＶエントリー時の請求先エラー表記修正 END
							}
						}
					}
					
					//荷送人部署名
					sKey[19] = " ";
// MOD 2011.07.14 東都）高木 記事行の追加 START
					if(iＣＳＶエントリー形式 == 2){
						if(sValue一覧行[(int)形式２.荷送担当者].Length != 0){
//							if(!全角チェック(sValue一覧行[(int)形式２.荷送担当者])){
//								エラー出力２(sErrFile, iCnt, (int)形式２.荷送担当者
//									, "荷送担当者は全角文字で入力してください\r\n");
//							}
//							if(sValue一覧行[(int)形式２.荷送担当者].Length > 10){
//								エラー出力２(sErrFile, iCnt, (int)形式２.荷送担当者
//									, "荷送担当者は１０文字以内で入力してください\r\n");
//							}
//							sKey[19] = sValue一覧行[(int)形式２.荷送担当者];
							if(!漢字変換_CSV(ref sValue一覧行[(int)形式２.荷送担当者], ref sErr)){
								エラー出力２(sErrFile, iCnt, (int)形式２.荷送担当者
								, "荷送担当者はVista対応により文字変換がおこなえませんでした"
													 + "『" + sErr + "』\r\n");
							}else{
								// 文字変換後出力(iCnt, (int)形式２.荷送担当者
								//					, sValue一覧行[(int)形式２.荷送担当者]);
							}
							if(!全角変換チェック(ref sValue一覧行[(int)形式２.荷送担当者], ref sErr)){
								エラー出力２(sErrFile, iCnt, (int)形式２.荷送担当者
								, "荷送担当者は全角文字変換がおこなえませんでした"
													 + "『" + sErr + "』\r\n");
							}
							if(sValue一覧行[(int)形式２.荷送担当者].Length > 10){
								sKey[19] = sValue一覧行[(int)形式２.荷送担当者].Substring(0,10);
							}else{
								sKey[19] = sValue一覧行[(int)形式２.荷送担当者];
							}
						}
					}
// MOD 2011.07.14 東都）高木 記事行の追加 END

					//個数
					sValue[11] = sValue[11].Trim();
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 START
//					if (!必須チェック(sValue[11]) || sValue[11].Equals("0")) エラー出力２(sErrFile, iCnt, 12, "個数は必須項目です\r\n");
					if(!必須チェック(sValue[11]) || sValue[11].Equals("0"))
					{
						エラー出力２(sErrFile, iCnt, 12, "個数は必須項目です\r\n");
						b重量才数再設定FLG = false;
					}
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
// MOD 2010.11.02 東都）高木 数値範囲チェックの変更 START
//					if (!数値チェック(sValue[11])) エラー出力２(sErrFile, iCnt, 12, "個数は数値で入力してください\r\n");
//					if (数値チェック(sValue[11]))
//					{	
//						if (long.Parse(sValue[11].Trim()) > 99) エラー出力２(sErrFile, iCnt, 12, "個数は２桁以内で入力してください\r\n");
//					}
					sChkMsg = 数値範囲チェック("個数", sValue[11], 0, 99, "２桁以内");
					if(sChkMsg.Length > 0){
						エラー出力２(sErrFile, iCnt, 12, sChkMsg +"\r\n");
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 START
						b重量才数再設定FLG = false;
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
					}
// MOD 2010.11.02 東都）高木 数値範囲チェックの変更 END
					sKey[26] = sValue[11];
					
					//才数
					sValue[12] = sValue[12].Trim();
					if (sValue[12].Length == 0) sValue[12] = "0";
// MOD 2010.11.02 東都）高木 数値範囲チェックの変更 START
//					if (!数値チェック(sValue[12])) エラー出力２(sErrFile, iCnt, 13, "才数は数値で入力してください\r\n");
//					if (sValue[12].Trim().Length > 3) エラー出力２(sErrFile, iCnt, 13, "才数は３桁以内で入力してください\r\n");
					sChkMsg = 数値範囲チェック("才数", sValue[12], 0, 999, "３桁以内");
					if(sChkMsg.Length > 0){
// MOD 2011.04.13 東都）高木 重量入力不可対応 START
////						エラー出力２(sErrFile, iCnt, 12, sChkMsg +"\r\n");
//						エラー出力２(sErrFile, iCnt, 13, sChkMsg +"\r\n");
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
//						sValue[12] = "0";
						if(gs重量入力制御 == "1")
						{
							エラー出力２(sErrFile, iCnt, 13, sChkMsg +"\r\n");
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 START
							b重量才数再設定FLG = false;
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
						}
						else
						{
							sValue[12] = "0";
						}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
// MOD 2011.04.13 東都）高木 重量入力不可対応 END
					}
// MOD 2010.11.02 東都）高木 数値範囲チェックの変更 END
					sKey[27] = sValue[12];
					
					//重量
					sValue[13] = sValue[13].Trim();
					if (sValue[13].Length == 0) sValue[13] = "0";
// MOD 2010.11.02 東都）高木 数値範囲チェックの変更 START
//					if (!数値チェック(sValue[13])) エラー出力２(sErrFile, iCnt, 14, "重量は数値で入力してください\r\n");
//					if (sValue[13].Trim().Length > 4) エラー出力２(sErrFile, iCnt, 14, "重量は４桁以内で入力してください\r\n");
					sChkMsg = 数値範囲チェック("重量", sValue[13], 0, 9999, "４桁以内");
					if(sChkMsg.Length > 0){
// MOD 2011.04.13 東都）高木 重量入力不可対応 START
////						エラー出力２(sErrFile, iCnt, 12, sChkMsg +"\r\n");
//						エラー出力２(sErrFile, iCnt, 14, sChkMsg +"\r\n");
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
//						sValue[13] = "0";
						if(gs重量入力制御 == "1")
						{
							エラー出力２(sErrFile, iCnt, 14, sChkMsg +"\r\n");
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 START
							b重量才数再設定FLG = false;
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
						}
						else
						{
							sValue[13] = "0";
						}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
// MOD 2011.04.13 東都）高木 重量入力不可対応 END
					}
// MOD 2010.11.02 東都）高木 数値範囲チェックの変更 END
					sKey[28] = sValue[13];
					
// MOD 2011.04.13 東都）高木 重量入力不可対応 START
//					if (!sValue[12].Equals("0")  && !sValue[13].Equals("0"))
//					{
//						エラー出力２(sErrFile, iCnt, 13, "才数と重量はどちらか一方を入力してください\r\n");
////						axGT取込データ一覧.set_CelMarking((short)(iCnt),(short)(14),true);
//					}
// MOD 2011.04.13 東都）高木 重量入力不可対応 END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
					if(gs重量入力制御 == "1")
					{
						if (!sValue[12].Equals("0")  && !sValue[13].Equals("0")){
							エラー出力２(sErrFile, iCnt, 13
								, "才数と重量はどちらか一方を入力してください\r\n");
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 START
							b重量才数再設定FLG = false;
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
						}
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 START
						if(b重量才数再設定FLG)
						{
							//荷送人コード、個数、才数、重量の各チェックで、いずれもエラーがなかった場合に処理
							int iＣＳＶ個数 = int.Parse(sKey[26].Trim());
							int iＣＳＶ才数 = int.Parse(sKey[27].Trim());
							int iＣＳＶ重量 = int.Parse(sKey[28].Trim());
							int i登録才数 = 0;
							int i登録重量 = 0;

							if(gsオプション[23] == "1")
							{
								//エントリーオプションの【ご依頼主固定重量】項目が「考慮する」の場合
								if(iＣＳＶ才数 == 0 && iＣＳＶ重量 == 0)
								{
									//CSVデータの重量、才数が両方「0」の場合のみが対象
									if(gsオプション[9] == "1")
									{
										//エントリーオプションの【重量入力方法】項目が「才数」の場合
										//　　→「才数(荷送人マスタ)」×「個数(CSVデータ)」をセット
										i登録才数 = i荷送人固定才数 * iＣＳＶ個数;
									}
									else
									{
										//エントリーオプションの【重量入力方法】項目が「重量」または「未設定」の場合
										//　　→「重量(荷送人マスタ)」×「個数(CSVデータ)」をセット
										i登録重量 = i荷送人固定重量 * iＣＳＶ個数;
									}
								}
								else
								{
									//CSVデータの重量、才数がどちらか一方でも入力されていたら、CSVの値をセット
									i登録才数 = iＣＳＶ才数;
									i登録重量 = iＣＳＶ重量;
								}
							}
							else
							{
								//エントリーオプションの【ご依頼主固定重量】項目が「考慮しない」または「未設定」の場合、CSVの値をセット
								i登録才数 = iＣＳＶ才数;
								i登録重量 = iＣＳＶ重量;
							}

							//考慮後の重量および才数を再設定する
							sKey[27] = i登録才数.ToString(); // 才数
							sKey[28] = i登録重量.ToString(); // 重量
						}
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
					}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END

					//輸送指示１
					sValue[14] = sValue[14].TrimEnd();
					sKey[31] = "000";
					sKey[32] = " ";
					if (sValue[14].Length != 0)
					{
						if (半角チェック(sValue[14]))
						{
							if (!数値チェック(sValue[14])) エラー出力２(sErrFile, iCnt, 15, "輸送商品１コードは数値のみ入力可能です\r\n");
							if (sValue[14].Length != 3) エラー出力２(sErrFile, iCnt, 15, "輸送商品１コードは３桁で入力してください\r\n");
							if (数値チェック(sValue[14]) && sValue[14].Length == 3)
							{
								string[] sList = {""};
								try
								{
//保留　チェックをまとめる予定
//		sValue[14]（輸送指示１）が半角
//		sValue[14]（輸送指示１）が数字
//		sValue[14]（輸送指示１）が３桁
//結果は
									if(sv_kiji == null) sv_kiji = new is2kiji.Service1();
// MOD 2011.06.07 東都）高木 王子運送の対応 START
									if (gs会員ＣＤ.Substring(0,1) != "J"){
// MOD 2011.06.07 東都）高木 王子運送の対応 END
										sList = sv_kiji.Get_Skiji(gsaユーザ,"yusoshohin","0000",sValue[14]);
// MOD 2011.06.07 東都）高木 王子運送の対応 START
									}else{
										sList = sv_kiji.Get_Skiji(gsaユーザ,"Jyusoshohin","0000",sValue[14]);
									}
// MOD 2011.06.07 東都）高木 王子運送の対応 END
								}
								catch (System.Net.WebException)
								{
									エラー出力２(sErrFile, iCnt, 15
										, "輸送商品１情報取得エラー："+gs通信エラー+"\r\n");
									throw new Exception(gs通信エラー);
								}
								catch (Exception ex)
								{
									エラー出力２(sErrFile, iCnt, 15
										, "輸送商品１情報取得エラー："+ex.Message+"\r\n");
									throw new Exception("通信エラー:" + ex.Message);
								}
								//存在しない時
								if (sList[3] == "I")
								{
									エラー出力２(sErrFile, iCnt,15,"入力された輸送商品１コードはマスタに存在しません。\r\n");
								}
								else
								{
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//									sKey[32] = sList[1].Trim();
									sKey[32] = sList[1].TrimEnd();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
								}
								sKey[31] = sValue[14];
							}
						}
						else
						{
							if (!漢字変換_CSV(ref sValue[14], ref sErr)) 
							{
								エラー出力２(sErrFile, iCnt, 15, "輸送商品１はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}
							else
							{
								// 文字変換後出力(iCnt, 15, sValue[14]);
							}
							if (!全角チェック(sValue[14])) エラー出力２(sErrFile, iCnt, 15, "輸送商品１の名称は全角文字で、コードは半角文字で入力してください（どちらか一方のみです）\r\n");
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 START
//							sKey[32] = Microsoft.VisualBasic.Strings.StrConv(sValue[14], Microsoft.VisualBasic.VbStrConv.Wide, 0);
							sKey[32] = sValue[14];
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 END
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 START
//							sKey[32] = sKey[32].Replace('\\','￥');
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 END
							if (sKey[32].Length > 15) sKey[32] = sKey[32].Substring(0, 15);
							//輸送商品コード検索
							if (全角チェック(sValue[14]))
							{
								try
								{
//保留　チェックをまとめる予定
//		sValue[14]（輸送指示１）が全角
// MOD 2011.06.07 東都）高木 王子運送の対応 START
									if (gs会員ＣＤ.Substring(0,1) != "J"){
// MOD 2011.06.07 東都）高木 王子運送の対応 END
										if(sv_kiji == null) sv_kiji = new is2kiji.Service1();
										sRet = sv_kiji.Get_kijiCD(gsaユーザ,"0000",sValue[14]);
// MOD 2011.06.07 東都）高木 王子運送の対応 START
									}else{
										if(sv_oji == null) sv_oji = new is2oji.Service1();
										sRet = sv_oji.Get_kijiCD(gsaユーザ,"0000",sValue[14]);
									}
// MOD 2011.06.07 東都）高木 王子運送の対応 END
								}
								catch (System.Net.WebException)
								{
									エラー出力２(sErrFile, iCnt, 15
										, "輸送商品１ＣＤ取得エラー："+gs通信エラー+"\r\n");
									throw new Exception(gs通信エラー);
								}
								catch (Exception ex)
								{
									エラー出力２(sErrFile, iCnt, 15
										, "輸送商品１ＣＤ取得エラー："+ex.Message+"\r\n");
									throw new Exception("通信エラー：" + ex.Message);
								}
								if(sRet[0].Length != 4)
								{
									if(sRet[0].Equals("該当データがありません"))
									{
										sKey[31] = "000";
										エラー出力２(sErrFile, iCnt, 15, "輸送商品１が存在しません\r\n");
									}
									else
									{
										エラー出力２(sErrFile, iCnt, 15
											, "輸送商品１ＣＤ取得エラー："+sRet[0]+"\r\n");
										throw new Exception(sRet[0]);
									}
								}
								else
								{
									sKey[31] = sRet[1];
								}
							}
						}
					}
					else
					{
						sKey[31] = "000";
						sKey[32] = " ";
					}
					//輸送指示２
					sValue[15] = sValue[15].TrimEnd();
					sKey[33] = "000";
					sKey[34] = " ";
					//輸送商品２件数チェック
					if (!sKey[31].Equals("000") && sValue[15].Length == 0)
					{
						string[] sList = {""};
						try
						{
//保留　チェックをまとめる予定
//		sKey[31]（輸送指示１）が[000]以外
//		sValue[15]（輸送指示２）が未入力
							if(sv_kiji == null)  sv_kiji = new is2kiji.Service1();
// MOD 2011.06.07 東都）高木 王子運送の対応 START
							if (gs会員ＣＤ.Substring(0,1) != "J"){
// MOD 2011.06.07 東都）高木 王子運送の対応 END
								sList = sv_kiji.Get_kiji(gsaユーザ,"yusoshohin",sKey[31]);
// MOD 2011.06.07 東都）高木 王子運送の対応 START
							}else{
								sList = sv_kiji.Get_kiji(gsaユーザ,"Jyusoshohin",sKey[31]);
							}
// MOD 2011.06.07 東都）高木 王子運送の対応 END
						}
						catch (System.Net.WebException)
						{
							throw new Exception(gs通信エラー);
						}
						catch (Exception ex)
						{
							throw new Exception("通信エラー：" + ex.Message);
						}
						if(sList[0].Equals("正常終了"))
						{
							for (int i = 1; i < sList.Length; i++)
							{
								//輸送商品１と同じコードがある場合は輸送商品２を指定なしと判定
								string[] s記事 = sList[i].Split('|');
								if (s記事.Length > 2 && sKey[31].Equals(s記事[1]))
								{
									sKey[33] = s記事[1];
									sKey[34] = s記事[2];
									break;
								}
							}
							if (sKey[33].Equals("000")) エラー出力２(sErrFile, iCnt, 16, "輸送商品１が入力されている場合、輸送商品２は必須項目です\r\n");
						}
						else if (!sList[0].Equals("該当データがありません"))
						{
							エラー出力２(sErrFile, iCnt, 16
								, "輸送商品２情報取得エラー："+sRet[0]+"\r\n");
							throw new Exception(sList[0]);
						}
					}
					if (sValue[15].Length != 0)
					{
						if (sValue[14].Length == 0) エラー出力２(sErrFile, iCnt, 15, "輸送商品１を入力してください\r\n");
						if (半角チェック(sValue[15]))
						{
							if (!数値チェック(sValue[15])) エラー出力２(sErrFile, iCnt, 16, "輸送商品２コードは数値のみ入力可能です\r\n");
							if (sValue[15].Length != 3) エラー出力２(sErrFile, iCnt, 16, "輸送商品２コードは３桁で入力してください\r\n");
							if (数値チェック(sValue[15]) && sValue[15].Length == 3)
							{
								string[] sList = {""};
								try
								{
//保留　チェックをまとめる予定
//		sValue[14]（輸送指示１）に入力あり
//		sValue[15]（輸送指示２）が半角
//		sValue[15]（輸送指示２）が数値
//		sValue[15]（輸送指示２）が３桁
// MOD 2011.06.07 東都）高木 王子運送の対応 START
									if(sv_kiji == null) sv_kiji = new is2kiji.Service1();
									if (gs会員ＣＤ.Substring(0,1) != "J"){
// MOD 2011.06.07 東都）高木 王子運送の対応 END
										// 会員コード:"yusoshohin" 部門コード:"0000"で検索
										sList = sv_kiji.Get_Skiji(gsaユーザ,"yusoshohin",sKey[31],sValue[15]);
// MOD 2011.06.07 東都）高木 王子運送の対応 START
									}else{
										sList = sv_kiji.Get_Skiji(gsaユーザ,"Jyusoshohin",sKey[31],sValue[15]);
									}
// MOD 2011.06.07 東都）高木 王子運送の対応 END
								}
								catch (System.Net.WebException)
								{
									エラー出力２(sErrFile, iCnt, 16
										, "輸送商品２情報取得エラー："+gs通信エラー+"\r\n");
									throw new Exception(gs通信エラー);
								}
								catch (Exception ex)
								{
									エラー出力２(sErrFile, iCnt, 16
										, "輸送商品２情報取得エラー："+ex.Message+"\r\n");
									throw new Exception("通信エラー：" + ex.Message);
								}
								//存在しない時
								if(sList[3] == "I")
								{
									エラー出力２(sErrFile, iCnt,16,"入力された輸送商品２コードはマスタに存在しません。\r\n");
								}
								else
								{
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//									sKey[34] = sList[1].Trim();
									sKey[34] = sList[1].TrimEnd();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
								}
								sKey[33] = sValue[15];
							}
						}
						else
						{
							if (!漢字変換_CSV(ref sValue[15], ref sErr)) 
							{
								エラー出力２(sErrFile, iCnt, 16, "輸送商品２はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}
							else
							{
								// 文字変換後出力(iCnt, 16, sValue[15]);
							}
							if (!全角チェック(sValue[15])) エラー出力２(sErrFile, iCnt, 16, "輸送商品２の名称は全角文字で、コードは半角文字で入力してください（どちらか一方のみです）\r\n");
							if(sValue[14].Length != 0 && 全角チェック(sValue[15]) && sKey[31].Equals("100")){
								if(sValue[15].Equals("ＡＭ指定")){
									sValue[15] = "ＡＭ指定（１０時～１２時）";
								}
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 START
//							sKey[34] = Microsoft.VisualBasic.Strings.StrConv(sValue[15], Microsoft.VisualBasic.VbStrConv.Wide, 0);
							sKey[34] = sValue[15];
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 END
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 START
//							sKey[34] = sKey[34].Replace('\\','￥');
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 END
							if (sKey[34].Length > 15) sKey[34] = sKey[34].Substring(0, 15);
							//輸送商品コード検索
							if (sValue[14].Length != 0 && 全角チェック(sValue[15]) && !sKey[31].Equals("000"))
							{
								try
								{
//保留　チェックをまとめる予定
//		sValue[14]（輸送指示１）が入力有り
//		sValue[15]（輸送指示２）が全角
//		sKey[31]（輸送指示１コード）が[000]以外
// MOD 2011.06.07 東都）高木 王子運送の対応 START
									if (gs会員ＣＤ.Substring(0,1) != "J"){
// MOD 2011.06.07 東都）高木 王子運送の対応 END
										if(sv_kiji == null) sv_kiji = new is2kiji.Service1();
										sRet = sv_kiji.Get_kijiCD(gsaユーザ,sKey[31],sValue[15]);
// MOD 2011.06.07 東都）高木 王子運送の対応 START
									}else{
										if(sv_oji == null) sv_oji = new is2oji.Service1();
										sRet = sv_oji.Get_kijiCD(gsaユーザ,sKey[31],sValue[15]);
									}
// MOD 2011.06.07 東都）高木 王子運送の対応 END
								}
								catch (System.Net.WebException)
								{
									エラー出力２(sErrFile, iCnt, 16
										, "輸送商品２ＣＤ取得エラー："+gs通信エラー+"\r\n");
									throw new Exception(gs通信エラー);
								}
								catch (Exception ex)
								{
									エラー出力２(sErrFile, iCnt, 16
										, "輸送商品２ＣＤ取得エラー："+ex.Message+"\r\n");
									throw new Exception("通信エラー：" + ex.Message);
								}
								if(sRet[0].Length != 4)
								{
									if(sRet[0].Equals("該当データがありません"))
									{
										sKey[33] = "000";
										エラー出力２(sErrFile, iCnt, 16, "輸送商品２が存在しません\r\n");
									}
									else
									{
										エラー出力２(sErrFile, iCnt, 16
											, "輸送商品２ＣＤ取得エラー："+sRet[0]+"\r\n");
										throw new Exception(sRet[0]);
									}
								}
								else
								{
									if(sKey[31].Equals("100")){
										if(sRet[1].Equals("11X")){
// MOD 2010.05.25 東都）高木 時間指定の変更 START
//											時間指定チェック(iCnt, sValue[15], 12, 21);
											時間指定チェック２(sErrFile, iCnt, sValue[15], 12, 20);
// MOD 2010.05.25 東都）高木 時間指定の変更 END
										}else if(sRet[1].Equals("12X")){
// MOD 2010.05.25 東都）高木 時間指定の変更 START
//											時間指定チェック(iCnt, sValue[15], 10, 19);
											時間指定チェック２(sErrFile, iCnt, sValue[15], 10, 18);
// MOD 2010.05.25 東都）高木 時間指定の変更 END
										}
									}else if(sKey[31].Equals("200")){
										if(sRet[1].Equals("21X")){
// MOD 2010.05.25 東都）高木 時間指定の変更 START
//											時間指定チェック(iCnt, sValue[15], 12, 21);
											時間指定チェック２(sErrFile, iCnt, sValue[15], 12, 20);
// MOD 2010.05.25 東都）高木 時間指定の変更 END
										}else if(sRet[1].Equals("22X")){
// MOD 2010.05.25 東都）高木 時間指定の変更 START
//											時間指定チェック(iCnt, sValue[15], 10, 19);
											時間指定チェック２(sErrFile, iCnt, sValue[15], 10, 18);
// MOD 2010.05.25 東都）高木 時間指定の変更 END
										}
									}
									sKey[33] = sRet[1];
								}
							}
						}
					}
					// パーセルワンの場合
					if (sKey[31].Equals("001"))
					{
						if (!sKey[26].Equals("1")) エラー出力２(sErrFile, iCnt, 12, "輸送商品１が" + sKey[32] + "の場合、個数は'1'を入力してください\r\n");
						if (!sKey[28].Equals("1")) エラー出力２(sErrFile, iCnt, 14, "輸送商品１が" + sKey[32] + "の場合、重量は'1'を入力してください\r\n");
					}
					// パーセルパックの場合
					if (sKey[31].Equals("002"))
					{
						if (!sKey[26].Equals("1")) エラー出力２(sErrFile, iCnt, 12, "輸送商品１が" + sKey[32] + "の場合、個数は'1'を入力してください\r\n");
						if (数値チェック(sKey[28]) && int.Parse(sKey[28]) > 30) エラー出力２(sErrFile, iCnt, 14, "輸送商品１が" + sKey[32] + "の場合、重量は３０以下を入力してください\r\n");
						if (数値チェック(sKey[27]) && 数値チェック(sKey[28]) && int.Parse(sKey[27]) > 0 && int.Parse(sKey[28]) == 0) エラー出力２(sErrFile, iCnt, 14, "輸送商品１が" + sKey[32] + "の場合、重量を入力してください\r\n");
					}

					//品名記事１
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//					sValue[16] = sValue[16].TrimEnd();
					if(gsオプション[18].Equals("1")){
						sValue[16] = sValue[16].TrimEnd();
					}else{
						sValue[16] = sValue[16].Trim();
					}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
					if (sValue[16].Length != 0)
					{
						if(!記号チェック２(sValue[16])) エラー出力２(sErrFile, iCnt, 17, "品名記事１に使用できない記号があります\r\n");
						if (!漢字変換_CSV(ref sValue[16], ref sErr)) 
						{
							エラー出力２(sErrFile, iCnt, 17, "品名記事１はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
						}
						else
						{
							// 文字変換後出力(iCnt, 17, sValue[16]);
						}
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 START
//						sKey[35] = sKey[35].Replace('\\','￥');
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 END
						sKey[35] = バイト長カット(sValue[16], 30);
					}
					else
					{
						sKey[35] = " ";
					}

					//品名記事２
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//					sValue[17] = sValue[17].TrimEnd();
					if(gsオプション[18].Equals("1")){
						sValue[17] = sValue[17].TrimEnd();
					}else{
						sValue[17] = sValue[17].Trim();
					}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
					if (sValue[17].Length != 0)
					{
						if(!記号チェック２(sValue[17])) エラー出力２(sErrFile, iCnt, 18, "品名記事２に使用できない記号があります\r\n");
						if (!漢字変換_CSV(ref sValue[17], ref sErr)) 
						{
							エラー出力２(sErrFile, iCnt, 18, "品名記事２はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
						}
						else
						{
							// 文字変換後出力(iCnt, 18, sValue[17]);
						}
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 START
//						sKey[36] = sKey[36].Replace('\\','￥');
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 END
						sKey[36] = バイト長カット(sValue[17], 30);
					}
					else
					{
						sKey[36] = " ";
					}

					//品名記事３
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//					sValue[18] = sValue[18].TrimEnd();
					if(gsオプション[18].Equals("1")){
						sValue[18] = sValue[18].TrimEnd();
					}else{
						sValue[18] = sValue[18].Trim();
					}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
					if (sValue[18].Length != 0)
					{
						if(!記号チェック２(sValue[18])) エラー出力２(sErrFile, iCnt, 19, "品名記事３に使用できない記号があります\r\n");
						if (!漢字変換_CSV(ref sValue[18], ref sErr)) 
						{
							エラー出力２(sErrFile, iCnt, 19, "品名記事３はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
						}
						else
						{
							// 文字変換後出力(iCnt, 19, sValue[18]);
						}
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 START
//						sKey[37] = sKey[37].Replace('\\','￥');
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 END
						sKey[37] = バイト長カット(sValue[18], 30);
					}
					else
					{
						sKey[37] = " ";
					}
// MOD 2011.07.14 東都）高木 記事行の追加 START
					if(iＣＳＶエントリー形式 == 2){
						sKey[47] = " ";
						if(sValue一覧行[(int)形式２.品名記事４].Length != 0){
							if(!記号チェック２(sValue一覧行[(int)形式２.品名記事４])){
								エラー出力２(sErrFile, iCnt, (int)形式２.品名記事４
								, "品名記事４に使用できない記号があります\r\n");
							}
							if(!漢字変換_CSV(ref sValue一覧行[(int)形式２.品名記事４], ref sErr)){
								エラー出力２(sErrFile, iCnt, (int)形式２.品名記事４
								, "品名記事４はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}else{
								// 文字変換後出力(iCnt, (int)形式２.品名記事４
								// , sValue一覧行[(int)形式２.品名記事４]);
							}
							sKey[47] = バイト長カット(sValue一覧行[(int)形式２.品名記事４], 30);
						}
						sKey[48] = " ";
						if(sValue一覧行[(int)形式２.品名記事５].Length != 0){
							if(!記号チェック２(sValue一覧行[(int)形式２.品名記事５])){
								エラー出力２(sErrFile, iCnt, (int)形式２.品名記事５
								, "品名記事５に使用できない記号があります\r\n");
							}
							if(!漢字変換_CSV(ref sValue一覧行[(int)形式２.品名記事５], ref sErr)){
								エラー出力２(sErrFile, iCnt, (int)形式２.品名記事５
								, "品名記事５はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}else{
								// 文字変換後出力(iCnt, (int)形式２.品名記事５
								// , sValue一覧行[(int)形式２.品名記事５]);
							}
							sKey[48] = バイト長カット(sValue一覧行[(int)形式２.品名記事５], 30);
						}
						sKey[49] = " ";
						if(sValue一覧行[(int)形式２.品名記事６].Length != 0){
							if(!記号チェック２(sValue一覧行[(int)形式２.品名記事６])){
								エラー出力２(sErrFile, iCnt, (int)形式２.品名記事６
								, "品名記事６に使用できない記号があります\r\n");
							}
							if(!漢字変換_CSV(ref sValue一覧行[(int)形式２.品名記事６], ref sErr)){
								エラー出力２(sErrFile, iCnt, (int)形式２.品名記事６
								, "品名記事６はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}else{
								// 文字変換後出力(iCnt, (int)形式２.品名記事６
								// , sValue一覧行[(int)形式２.品名記事６]);
							}
							sKey[49] = バイト長カット(sValue一覧行[(int)形式２.品名記事６], 30);
						}
// MOD 2011.07.28 東都）高木 記事行の追加（文字数制限の追加） START
						// 品名記事４～６のいずれかにデータある場合
						if(sKey[47].Trim().Length > 0
							|| sKey[48].Trim().Length > 0
							|| sKey[49].Trim().Length > 0
						){
							sKey[35] = バイト長カット(sKey[35], 18); // 品名記事１
							sKey[36] = バイト長カット(sKey[36], 18); // 品名記事２
							sKey[37] = バイト長カット(sKey[37], 18); // 品名記事３
							sKey[47] = バイト長カット(sKey[47], 18); // 品名記事４
							sKey[48] = バイト長カット(sKey[48], 18); // 品名記事５
							sKey[49] = バイト長カット(sKey[49], 18); // 品名記事６
						}
// MOD 2011.07.28 東都）高木 記事行の追加（文字数制限の追加） END
					}
// MOD 2011.07.14 東都）高木 記事行の追加 END
					
					//お客様管理番号
					sValue[20] = sValue[20].Trim();
					if (sValue[20] == "0")	sValue[20]=""; // ？
					if (sValue[20].Length != 0)
					{
						if (!半角チェック(sValue[20])) エラー出力２(sErrFile, iCnt, 21, "お客様管理番号は半角文字で入力してください\r\n");
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
//						if(!記号チェック(sValue[20])) エラー出力２(sErrFile, iCnt, 21, "お客様管理番号に使用できない記号があります\r\n");
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 START
//						if (sValue[20].Length > 15) エラー出力２(sErrFile, iCnt, 21, "お客様管理番号は１５桁以内で入力してください\r\n");
						if (sValue[20].Length > 16){
							エラー出力２(sErrFile, iCnt, 21, "お客様管理番号は１６桁以内で入力してください\r\n");
						}
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 END
						sKey[3] = sValue[20];
					}

					//元着区分
					sValue[22] = sValue[22].Trim();
					if (!sValue[22].Equals("1"))
					{
						エラー出力２(sErrFile, iCnt, 23, "元着区分は'1'を入力してください\r\n");
					}
					sKey[38] = sValue[22];
					
					//保険金額
					sValue[23] = sValue[23].Trim();
					if (sValue[23].Length == 0) sValue[23] = "0";
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 START
//					if (!数値チェック(sValue[23])) エラー出力２(sErrFile, iCnt, 24, "保険金額は数値で入力してください\r\n");
//					if (数値チェック(sValue[23]))
//					{	
//						if (long.Parse(sValue[23].Trim()) > 9999) エラー出力２(sErrFile, iCnt, 24, "保険金額は４桁以内で入力してください\r\n");
//					}
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) START
//					sChkMsg = 数値範囲チェック("保険金額", sValue[23], 0, 30, "");
					sChkMsg = 数値範囲チェック("保険金額", sValue[23], 0, gl保険金額上限, "４桁以内");
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) END
					if(sChkMsg.Length > 0){
						エラー出力２(sErrFile, iCnt, 24, sChkMsg +"\r\n");
					}
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 END
					sKey[39] = sValue[23];
					
					//出荷日
					sValue[24] = sValue[24].Trim();
					DateTime dt出荷日 = DateTime.Today;
					bool     b出荷日設定 = false;
					if (!必須チェック(sValue[24])) エラー出力２(sErrFile, iCnt, 25, "出荷日は必須項目です\r\n");
					if (sValue[24].Length != 0)
					{
						if (!半角チェック(sValue[24])) エラー出力２(sErrFile, iCnt, 25, "出荷日は半角文字で入力してください\r\n");
						if (sValue[24].Length != 8)
						{
							エラー出力２(sErrFile, iCnt, 25, "出荷日は８文字で入力してください\r\n");
						}
						else
						{
							try
							{
								dt出荷日 = new DateTime(int.Parse(sValue[24].Substring(0,4)),
														int.Parse(sValue[24].Substring(4,2)),
														int.Parse(sValue[24].Substring(6)));
								b出荷日設定 = true;
								if(dt出荷日 < gdt出荷日)
								{
									エラー出力２(sErrFile, iCnt, 25, "出荷日は" + gdt出荷日.ToString(" M月 d日") + "以降を入力してください\r\n");
								}
								//当日（登録日）から２週間まで
								else if(dt出荷日 > gdt出荷日最大値ＣＳＶ)
								{
									エラー出力２(sErrFile, iCnt, 25, "出荷日は" + gdt出荷日最大値ＣＳＶ.ToString(" M月 d日")
									 + "以前を入力してください\r\n");
								}
								// ADD-S 2012.09.26 COA)横山 日付項目取込強化
								else 
								{
									sValue[24] = YYYYMMDD変換(dt出荷日);
								}
								// ADD-E 2012.09.26 COA)横山 日付項目取込強化
							}
							catch
							{
								エラー出力２(sErrFile, iCnt, 25, "出荷日はyyyyMMddの形式で入力してください\r\n");
							}
						}
					}
					sKey[2] = sValue[24];
					
					//登録日の初期設定
					sKey[40] = YYYYMMDD変換(DateTime.Now);
					if(sValue.Length > 25){
						//登録日
						sValue[25] = sValue[25].Trim();
						string   s当日    = YYYYMMDD変換(DateTime.Now);
						sValue[25] = sValue[25].Trim();
						if (sValue[25] == "0")	sValue[25]="";
						if (sValue[25].Length != 0)
						{	
							try
							{
								DateTime dt登録日 = new DateTime(int.Parse(sValue[25].Substring(0,4)),int.Parse(sValue[25].Substring(4,2)), int.Parse(sValue[25].Substring(6)));
								if (!sValue[25].Equals(s当日)) エラー出力２(sErrFile, iCnt, 26, "登録日は当日を入力してください\r\n");
							}
							catch
							{
								エラー出力２(sErrFile, iCnt, 26, "登録日はyyyyMMddの形式で入力してください\r\n");
							}
						}
						else 
							sValue[25] = s当日;
						sKey[40] = sValue[25];
					}

					//指定日
					sKey[29] = "0";
					//指定日区分
					sKey[30] = "0";
// MOD 2011.07.14 東都）高木 記事行の追加 START
					if(iＣＳＶエントリー形式 == 2){
						if(sValue一覧行[(int)形式２.必着区分].Length != 0){
							if(半角チェック(sValue一覧行[(int)形式２.必着区分])){
								if(sValue一覧行[(int)形式２.必着区分] == "0"){
									sKey[30] = "0"; // 0:必着 1:指定
								}else if(sValue一覧行[(int)形式２.必着区分] == "1"){
									sKey[30] = "1"; // 0:必着 1:指定
								}else{
									エラー出力２(sErrFile, iCnt, (int)形式２.必着区分
									, "必着区分は[0]もしくは[1]で入力してください\r\n");
								}
							}else{
								if(sValue一覧行[(int)形式２.必着区分] == "必着"){
									sKey[30] = "0"; // 0:必着 1:指定
								}else if(sValue一覧行[(int)形式２.必着区分] == "指定"){
									sKey[30] = "1"; // 0:必着 1:指定
								}else{
									エラー出力２(sErrFile, iCnt, (int)形式２.必着区分
									, "必着区分は[必着]もしくは[指定]で入力してください\r\n");
								}
							}
						}
					}
// MOD 2011.07.14 東都）高木 記事行の追加 END

					sValue[19] = sValue[19].Trim();
					if (sValue[19] == "0")	sValue[19]="";
					if (sValue[19].Length != 0)
					{
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 START
						if(sValue[19].Length != 8){
							エラー出力２(sErrFile, iCnt, 20, "配達指定日は８文字で入力してください\r\n");
						}else{
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 END
						try
						{
							DateTime dt配達指定日 = new DateTime(
															int.Parse(sValue[19].Substring(0,4))
															, int.Parse(sValue[19].Substring(4,2))
															, int.Parse(sValue[19].Substring(6)));
							// ADD-S 2012.09.26 COA)横山 日付項目取込強化
							bool	wk_bNoErr_配達指定日	= true;
							// ADD-E 2012.09.26 COA)横山 日付項目取込強化

							if(b出荷日設定)
							{
								//出荷日から（１４日 or ９０日）まで
								DateTime dt指定日最大値;
								if(gs部門店所ＣＤ.Equals("047")){
									dt指定日最大値 = dt出荷日.AddDays(90);
								}else{
									dt指定日最大値 = dt出荷日.AddDays(14);
								}
// MOD 2016.04.13 BEVAS）松本 配達指定日上限の拡張 START
								//セリア様の場合、配達指定日の上限を180日にまで拡張
								if(gs会員ＣＤ.Equals(gs指定日上限拡張会員ＣＤ))
								{
									dt指定日最大値 = dt出荷日.AddDays(180);
								}
// MOD 2016.04.13 BEVAS）松本 配達指定日上限の拡張 END
								if(dt配達指定日 < dt出荷日)
								{
									エラー出力２(sErrFile, iCnt, 20, "配達指定日は出荷日以降を入力してください\r\n");
									// ADD-S 2012.09.26 COA)横山 日付項目取込強化
									wk_bNoErr_配達指定日	= false;
									// ADD-E 2012.09.26 COA)横山 日付項目取込強化
								}
								if(dt配達指定日 > dt指定日最大値)
								{
									エラー出力２(sErrFile, iCnt, 20, "配達指定日は" + dt指定日最大値.ToString(" M月 d日")
									 + "以前を入力してください\r\n");
									// ADD-S 2012.09.26 COA)横山 日付項目取込強化
									wk_bNoErr_配達指定日	= false;
									// ADD-E 2012.09.26 COA)横山 日付項目取込強化
								}

								// ADD-S 2012.09.26 COA)横山 日付項目取込強化
								if (wk_bNoErr_配達指定日 == true) 
								{
									sValue[19] =  YYYYMMDD変換(dt配達指定日);
								}
								// ADD-E 2012.09.26 COA)横山 日付項目取込強化
							}
						}
						catch
						{
							エラー出力２(sErrFile, iCnt, 20, "配達指定日はyyyyMMddの形式で入力してください\r\n");
						}
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 START
						}
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 END
						sKey[29] = sValue[19];
						sKey[30] = "1";
					}
					sKey[41] = "0";			// 送り状発行済ＦＧ
					sKey[42] = "0";			// 出荷済ＦＧ
					sKey[43] = "0";			// 一括出荷ＦＧ
					sKey[44] = "自動出荷";	
					sKey[45] = gs利用者ＣＤ;
					
					StringBuilder sbKeyData = new StringBuilder();
					for (int j = 0; j < sKey.Length; j++){
						sbKeyData.Append(sKey[j] + ",");
					}
					s取込データ２[i取込行数２++] = sbKeyData.ToString();

//					if(i取込行数２ % 10 == 0){
//						System.Threading.Thread.Sleep(100); // 0.1秒待つ
//					}
				}
//				texメッセージ.Text = "";
			}catch (Exception ex){
//				texメッセージ.Text = ex.Message;
				ログ出力２(" "+ex.Message);
//				bエラー出力２ = false;
			}finally{
				sr.Close();
				Cursor = System.Windows.Forms.Cursors.Default;
			}
			ログ出力２(" チェック終了");

			ログ出力２(" 読込行数　："+iCnt.ToString("0000"));
//			ログ出力２(" 取込行数　："+i取込行数２.ToString("0000"));
			ログ出力２(" エラー行数："+iエラー行数２.ToString("0000"));

			if(!gb自動出力ＯＮ) return; //自動出力が無効であれば終了

			// ファイルを移動する
			try{
// MOD 2010.04.19 東都）高木 出力ファイル名の変更 START
//				File.Move(sCsvFile
//						, gsPathSyukkaOut + "\\" + Path.GetFileName(sCsvFile));
				File.Move(sCsvFile
						, gsPathSyukkaOut + "\\" + Path.GetFileName(sCsvFile)
						+ "_" + s実行日時);
// MOD 2010.04.19 東都）高木 出力ファイル名の変更 END
			}catch(Exception ex){
//保留　エラー処理
				ログ出力２(" "+ex.Message);
				return;
			}

			// エラーが発生していた場合は、終了
			if(bエラー出力２){
//				MessageBox.Show("出荷ＣＳＶ自動出力でエラーが発生しました。\n"
//								+ "エラーファイル["+sErrFile+"]を確認して下さい。"
//								,"出荷ＣＳＶ自動出力"
//								,MessageBoxButtons.OK);
// MOD 2010.05.25 東都）高木 メッセージのスレッド化 START
//				DialogResult dlgRst = MessageBox.Show(
//								"出荷ＣＳＶ自動出力でエラーが発生しました。\n"
//								+ "ＣＳＶエントリー画面の[自動出力フォルダ表示]ボタンを押して、\n"
//								+ "エラーファイル[Out\\"+Path.GetFileName(sErrFile)+"]の内容を確認して下さい。\n"
//								, "出荷ＣＳＶ自動出力"
//								, MessageBoxButtons.OK
//								, MessageBoxIcon.Error);
				sTaskMsgErrFile = sErrFile;
				trdMsg = new Thread(new ThreadStart(ThreadTaskMsg));
				trdMsg.IsBackground = true;
				trdMsg.Start();
// MOD 2010.05.25 東都）高木 メッセージのスレッド化 END
				return;
			}

			// 取込予定件数が０の場合
			if(i取込行数２ == 0) return;

			// 配列データの再作成を行う
			string[] s取込データ２Ｗ = new string[i取込行数２];
			System.Array.Copy(s取込データ２, s取込データ２Ｗ, i取込行数２);
			s取込データ２ = null;

//			texメッセージ.Text = "出荷ＣＳＶ自動出力 取込中．．．";
//			texメッセージ.Refresh();
			ログ出力２(" 取込開始");
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try{
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
				sRet = sv_syukka.Ins_autoEntryData(gsaユーザ,s取込データ２Ｗ);
//				texメッセージ.Text = sRet[0];
//				texメッセージ.Refresh();
				if(sRet[0].Length != 0){
					ログ出力２(" "+sRet[0]);
					return;
				}
			}catch (System.Net.WebException){
//				texメッセージ.Text = gs通信エラー;
//				texメッセージ.Refresh();
				ログ出力２(" "+gs通信エラー);
				return;
			}catch (Exception ex){
//				texメッセージ.Text = ex.Message;
//				texメッセージ.Refresh();
				ログ出力２(" "+ex.Message);
				return;
			}finally{
				Cursor = System.Windows.Forms.Cursors.Default;
			}
			ログ出力２(" 取込終了");

//			texメッセージ.Text = "出荷ＣＳＶ自動出力 印刷中．．．";
//			texメッセージ.Refresh();
			ログ出力２(" 印刷開始");
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try{
				プリンタチェック();
			}catch(Exception ex){
				Cursor = System.Windows.Forms.Cursors.Default;
//				texメッセージ.Text = ex.Message;
				ログ出力２(" "+ex.Message);
				return;
			}

// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） START
//			ds送り状.Clear();
			送り状データクリア();
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） END
			int iRetCnt = 1;
			while(iRetCnt < sRet.Length){
				if(sRet[iRetCnt] == null) break;
				// 登録日、ジャーナルＮＯ
				string[] sPrtData = {sRet[iRetCnt++], sRet[iRetCnt++]};
				送り状印刷指示(sPrtData);
//保留　おそらく不要
//				if(!gb印刷){
//					texメッセージ.Text = "";
//					Cursor = System.Windows.Forms.Cursors.Default;
//					MessageBox.Show("集荷店が違います。印刷できません。","送状印刷"
//						,MessageBoxButtons.OK);
//					return;
//				}

//保留 １件ずつ印刷する
//				送り状帳票印刷();
//				ds送り状.Clear();

//				if(iRetCnt % 60 == 1){
//					System.Threading.Thread.Sleep(300); // 0.3秒待つ
//				}
			}
//保留 まとめて印刷する
			送り状帳票印刷();
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） START
//			ds送り状.Clear();
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） END

			Cursor = System.Windows.Forms.Cursors.Default;
			ログ出力２(" 印刷終了");
		}
// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 END
// MOD 2010.04.21 東都）高木 ハング近似動作の防止 START
		private void ファイル一覧取得１()
		{
			try{
				if(!Directory.Exists(gsPathSyukka))    return;
				if(!Directory.Exists(gsPathSyukkaIn))  return;
				if(!Directory.Exists(gsPathSyukkaOut)) return;
				if(!Directory.Exists(gsPathSyukkaLog)) return;

				// ファイル一覧取得１
//				ログ出力２(" ファイル一覧取得１");
				sFiles1 = Directory.GetFiles(gsPathSyukkaIn);
				if(sFiles1.Length == 0) return;
				dtFiles1 = new DateTime[sFiles1.Length];
				lsFiles1 = new long[sFiles1.Length];
				for(int iCnt = 0; iCnt < sFiles1.Length; iCnt++){
					dtFiles1[iCnt] = File.GetLastWriteTime(sFiles1[iCnt]);
					lsFiles1[iCnt] = 0;
					try{
						FileStream fs = new FileStream(sFiles1[iCnt], FileMode.Open);
						lsFiles1[iCnt] = fs.Length;
						fs.Close();
					}catch(IOException ex){
//保留　エラー処理
						ログ出力２(" ファイルサイズ取得１ "+ex.Message);
					}
				}
			}catch(Exception ex){
//保留　エラー処理
				ログ出力２(" ファイル一覧取得１ "+ex.Message);
			}finally{
//				b実行中_tim出荷ＣＳＶ自動出力_Tick = false;
			}
		}
// MOD 2010.04.21 東都）高木 ハング近似動作の防止 END
// MOD 2010.05.25 東都）高木 メッセージのスレッド化 START
		private string sTaskMsgErrFile = "";
		private void ThreadTaskMsg()
		{
			DialogResult dlgRst = MessageBox.Show(
							"出荷ＣＳＶ自動出力でエラーが発生しました。\n"
							+ "ＣＳＶエントリー画面の[自動出力フォルダ表示]ボタンを押して、\n"
							+ "エラーファイル[Out\\"+Path.GetFileName(sTaskMsgErrFile)+"]の内容を確認して下さい。\n"
							, "出荷ＣＳＶ自動出力"
							, MessageBoxButtons.OK
							, MessageBoxIcon.Error);
		}
// MOD 2010.05.25 東都）高木 メッセージのスレッド化 END
// MOD 2010.05.25 東都）高木 時間指定の変更 START
		private void 時間指定チェック２(string sErrFile, int iCnt, string sData, int iHourMin, int iHourMax)
		{
			if(sData.Length != 9){
//				エラー出力２(sErrFile, iCnt, 16, "輸送商品２の時間指定の文字の長さに誤りがあります\r\n");
				エラー出力２(sErrFile, iCnt, 16, "輸送商品２の時間指定に誤りがあります["+sData+"]\r\n");
				return;
			}
			if(!sData.Substring(6,1).Equals("時")){
//				エラー出力２(sErrFile, iCnt, 16, "輸送商品２の時間指定の時刻に誤りがあります[時]\r\n");
				エラー出力２(sErrFile, iCnt, 16, "輸送商品２の時間指定に誤りがあります["+sData+"]\r\n");
				return;
			}
			string s時間 = sData.Substring(4,2);
			int iHour = 0;
			for(int iPos = 0;iPos < sa時間指定チェック.Length; iPos++){
				if(s時間.Equals(sa時間指定チェック[iPos])){
					iHour = 10 + iPos;
					break;
				}
			}
			if(iHour == 0 || iHour < iHourMin || iHour > iHourMax){
				エラー出力２(sErrFile, iCnt, 16, "輸送商品２の時間指定の時刻に誤りがあります["+s時間+"]\r\n");
				return;
			}
		}

// MOD 2010.05.25 東都）高木 時間指定の変更 END
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
		private bool bメニュー_Activated = false;
		private void メニュー_Activated(object sender, System.EventArgs e)
		{
			if(bメニュー_Activated == false){
				お知らせ案内メッセージ取得();
			}
			bメニュー_Activated = true;
			if(gsお知らせ案内メッセージ.Length > 0){
				texメッセージ.Text = gsお知らせ案内メッセージ;
			}
		}
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END
// MOD 2011.04.05 東都）高木 画面イメージのロード変更 START
		private static Image Image_FromFile(string sイメージファイル)
		{
			Image retImage = null;
			try{
//				retImage = Image.FromFile(gsアプリフォルダ+"\\"+sイメージファイル);
				FileStream fs = new FileStream(gsアプリフォルダ+"\\"+sイメージファイル
										, FileMode.Open, FileAccess.Read); 
				Bitmap bmp = (Bitmap)System.Drawing.Bitmap.FromStream(fs); 
				fs.Close(); 
				retImage = new Bitmap(bmp); 
			}catch{
			}
			return retImage;
		}
// MOD 2011.04.05 東都）高木 画面イメージのロード変更 END
// MOD 2011.10.11 東都）高木 ＳＳＬ証明書導入状態などのチェック START
		private static void ＳＳＬ証明書導入状態チェック()
		{
			if(gsSSLStatus.Length > 0) return;

			is2init.Service1 sv_test = new is2init.Service1();;
			sv_test.Url   = sv_init.Url;
			sv_test.Proxy = sv_init.Proxy;
			
			int iTimeout = 100000; // デフォルトは、100秒
			try{
				iTimeout = sv_test.Timeout;
				sv_test.Timeout = 10000; // 10秒
				sv_test.Url = sv_test.Url.Replace("wwwis2","www.is2edi");
				gsSSLStatus = sv_test.wakeupDB();
				if(gsSSLStatus.Length == 0){
					gsSSLStatus = "o";
				}
			}catch(Exception ex){
				gsSSLStatus = "e:"+ex.Message;
			}finally{
				// 元の設定に戻す
				sv_test.Timeout = iTimeout; // 元に戻す
				sv_test.Url = sv_test.Url.Replace("www.is2edi","wwwis2");
			}
		}
// MOD 2011.10.11 東都）高木 ＳＳＬ証明書導入状態などのチェック END
// MOD 2011.12.06 東都）高木 プロキシ認証の追加 START
		private byte[] bKey = {51, 168, 96, 2, 36, 12, 74, 143, 11, 85, 61, 233, 202, 170, 114, 59};
		private byte[] bIv  = {100, 223, 207, 80, 29, 100, 53, 152};
		private string 復号化２(string sText)
		{
			byte[] bText;
			byte[] bRet;
			string sRet = "";

			try{
				//bText = Encoding.GetEncoding("shift-jis").GetBytes(sText);
				string sByte = "";
				bText = new byte[sText.Length / 2];
				for(int iCnt = 0; iCnt < sText.Length; iCnt+=2){
					sByte = sText.Substring(iCnt, 2);
					bText[iCnt/2] = Convert.ToByte(sByte,16);
				}

				MemoryStream inputStream = new MemoryStream(bText);
				RC2CryptoServiceProvider rc2 = new RC2CryptoServiceProvider();

				// CryptoStreamオブジェクトを作成する
				ICryptoTransform transform = rc2.CreateDecryptor(bKey,bIv); // Decryptorを作成する
				CryptoStream csDecrypt = new CryptoStream( inputStream, transform, CryptoStreamMode.Read);

				bRet = new Byte[bText.Length];
				//Read the data out of the crypto stream.
				int iLen = csDecrypt.Read(bRet, 0, bRet.Length);

				//Convert the byte array back into a string.
				sRet = Encoding.GetEncoding("shift-jis").GetString(bRet,0,iLen);

				// ストリームを閉じる
				csDecrypt.Close();
				inputStream.Close();
				

				rc2 = null;
				csDecrypt = null;
				inputStream = null;	

				if(sRet.Length >= 2){
					// 先頭および末尾のダミー文字を削除
					sRet = sRet.Substring(1,sRet.Length-2);
				}
			}catch(Exception ex){
				sRet = ex.Message;
			}
										
			return sRet;
		}
// MOD 2011.12.06 東都）高木 プロキシ認証の追加 END
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 START
		private void picバーコード読取_Click(object sender, System.EventArgs e)
		{
			texメッセージ.Text = "";
			if(gb自動出力ＯＮ) return;
			if (g読取専用画面 == null)
			{
				g読取専用画面 = new 読取専用画面();
			}
			g読取専用画面.ShowDialog(this);
		}

		private void picバーコード読取_MouseEnter(object sender, System.EventArgs e)
		{
			picバーコード読取.Cursor = Cursors.Default;
			if(gb自動出力ＯＮ) return;
			picバーコード読取.Cursor = Cursors.Hand;
			picバーコード読取.Image = imageCmd[2,4,1];
		}

		private void picバーコード読取_MouseLeave(object sender, System.EventArgs e)
		{
			if(gb自動出力ＯＮ) return;
			picバーコード読取.Image  = imageCmd[2,4,0];
										}
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 END
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 START
		private void picラベルイメージ印刷_Click(object sender, System.EventArgs e)
		{
			//お客様毎の重量入力不可対応
			重量入力制御取得();

			//エラーメッセージのクリア
			texメッセージ.Text = "";

			// 自動出力がONの場合は、画面遷移しない
			if(gb自動出力ＯＮ) return;

			if (g控え印刷 == null)
			{
				g控え印刷 = new 送り状控え印刷();
			}
			g控え印刷.Left = this.Left;
			g控え印刷.Top = this.Top;
			this.Visible = false;
			g控え印刷.ShowDialog(this);
			this.Visible = true;
		}

		private void picラベルイメージ印刷_MouseEnter(object sender, System.EventArgs e)
		{
			picラベルイメージ印刷.Cursor = Cursors.Default;
			if(gb自動出力ＯＮ) return;
			picラベルイメージ印刷.Cursor = Cursors.Hand;
			picラベルイメージ印刷.Image  = imageCmd[2,5,1];
		}
						
		private void picラベルイメージ印刷_MouseLeave(object sender, System.EventArgs e)
		{
			if(gb自動出力ＯＮ) return;
			picラベルイメージ印刷.Image  = imageCmd[2,5,0];
		}
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 END
	}
}
