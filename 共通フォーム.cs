using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Runtime.InteropServices;

namespace IS2Client
{
	/// <summary>
	/// [共通フォーム]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// ADD 2008.03.13 東都）高木 Vista対応 
	// ADD 2008.03.19 東都）高木 個別再発行機能の追加 
	// ADD 2008.04.11 ACT Vista対応 
	//保留 ADD 2008.06.12 東都）高木 ＴＥＣ製プリンタ対応 
	// ADD 2008.06.17 東都）高木 住所１が[神][和][鹿]で始まりかつ３文字だけの場合の対応 
	//--------------------------------------------------------------------------
	//保留 DEL 2009.02.06 東都）高木 ラベル用紙サイズ定義チェックの廃止
	// 　ＺＥＢＲＡ製ラベルプリンタだけで行われていた
	// ADD 2009.04.02 東都）高木 稼働日対応 
	// ADD 2009.04.07 東都）高木 着店ＣＤ[000]対応 
	// MOD 2009.05.01 東都）高木 オプションの項目追加 
	// ADD 2009.07.29 東都）高木 プロキシ対応 
	// 　ＩＥの[Secure]の設定からも取得する
	// 　プロキシをユーザが設定できるようにする
	// MOD 2009.11.04 東都）高木 お届け先ＣＤに記号[+]を利用可能にする 
	// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 
	//                           （ＳＳとの共通仕様の為、一応合わせる）
	// MOD 2009.11.06 PSN）藤井　オプションの項目追加
	// MOD 2009.11.09 PSN）藤井　オプションの項目追加
	// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 
	// MOD 2009.12.01 東都）高木 全角半角混在可能にする 
	// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 
	//--------------------------------------------------------------------------
	// MOD 2010.01.15 東都）高木 文字数カットのメッセージの変更 
	// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）
	// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 
	// MOD 2010.03.12 東都）高木 １００００件チェック解除機能の追加 
	// MOD 2010.03.17 東都）高木 荷受人電話番号がALL0であれば非表示 
	// MOD 2010.03.17 東都）高木 出荷日の出荷日の年を４桁表示にする 
	// MOD 2010.03.18 東都）高木 荷受人住所の都道府県と市区郡を区切らない 
	// MOD 2010.03.19 東都）高木 印刷順の指定（仮対応１） 
	// MOD 2010.03.30 東都）高木 荷受人電話番号が0であれば非表示 
	// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 
	// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 
	// MOD 2010.04.16 東都）高木 モジュール再ダウンロード 
	// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 
	// MOD 2010.06.01 東都）高木 ファイル出力時の改行の変更 
	// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 
	// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） 
	// MOD 2010.09.02 東都）高木 選択時のずれの対応 
	// MOD 2010.08.27 東都）高木 ご依頼主取込（ＣＳＶ）機能追加 
	// MOD 2010.11.01 東都）高木 出荷済の場合、出荷日未更新 
	// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 
	// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) 
	// ADD 2010.12.14 ACT）垣原 王子運送の対応 
	//--------------------------------------------------------------------------
	// MOD 2011.01.06 東都）高木 郵便番号の印刷 
	// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない 
	// MOD 2011.01.25 東都）高木 「ロードに失敗」対応 
	// MOD 2010.02.28 東都）高木 王子運送の対応 
	// MOD 2011.03.03 東都）高木 プリンタごとの補正対応 
	// MOD 2011.04.26 東都）高木 プリンタごとの補正対応 
	// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 
	// MOD 2011.05.09 東都）高木 エコー金属版のオプションのマージ 
	// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 
	// MOD 2011.07.14 東都）高木 記事行の追加 
	// MOD 2011.07.28 東都）高木 記事行の追加（入力制限の追加） 
	// MOD 2011.10.11 東都）高木 ＳＳＬ証明書導入状態などのチェック 
	// MOD 2011.12.06 東都）高木 ラベルヘッダ部に発店名・着店名を印字 
	// MOD 2011.12.08 東都）高木 住所・名前の半角入力可 
	// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 
	// MOD 2011.12.06 東都）高木 プロキシ認証の追加 
	//--------------------------------------------------------------------------
	// MOD 2012.04.10 東都）高木 ラベル発店名の印字制御対応 
	//--------------------------------------------------------------------------
	// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応
	// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応
	// MOD 2013.10.22 BEVAS）高杉 ＳＡＴＯ製プリンタ(CS408T)プリンタ名小文字対応
	//--------------------------------------------------------------------------
	// MOD 2015.02.12 BEVAS）前田 ＴＥＣ製プリンタ(B-LV4)対応
	// ADD 2015.03.05 BEVAS）前田 支店止め機能追加対応
	// MOD 2015.04.13 BEVAS) 前田　自動出力間隔秒対応 
	// MOD 2015.05.07 BEVAS) 前田 王子CM14J郵便番号存在チェック対応
	// MOD 2015.07.13 TDI) 綱澤 バーコード読取専用画面追加 
	// MOD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加
	// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加
	//--------------------------------------------------------------------------
	// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加
	// MOD 2016.04.13 BEVAS）松本 配達指定日上限の拡張
	// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応
	// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存
	// MOD 2016.06.10 BEVAS）松本 保険料入力チェック機能の追加（31万円以上の場合）
	//--------------------------------------------------------------------------
	public class 共通フォーム : System.Windows.Forms.Form
	{
// ADD 2005.07.11 東都）小童谷 印刷順の制御 START
		protected static int i印刷順 = 0;
// ADD 2005.07.11 東都）小童谷 印刷順の制御 END

		protected static String gsInitFile = System.Environment.SystemDirectory
										  + "\\wis2.dll";
// ADD 2009.07.29 東都）高木 プロキシ対応 START
		protected static String gsInitProxy = AppDomain.CurrentDomain.BaseDirectory
										  + "proxy.ini";
		protected static bool gbInitProxyExists = false;
// ADD 2009.07.29 東都）高木 プロキシ対応 END
// MOD 2011.10.11 東都）高木 ＳＳＬ証明書導入状態などのチェック START
		protected static bool gbInitSyukkaExists = false;
		protected static string gsOSVer  = "";
		protected static string gsNetVer = "";
		protected static string gsSSLStatus = "";
// MOD 2011.10.11 東都）高木 ＳＳＬ証明書導入状態などのチェック END
// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 START
		protected static String gsInitKiji = AppDomain.CurrentDomain.BaseDirectory
										  + "kiji.ini";
// MOD 2009.11.04 東都）高木 記事の固定内容を端末ごとに保存 END
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 START
		protected static String gsInitClient = AppDomain.CurrentDomain.BaseDirectory
										  + "IS2Client.ini";
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 END
// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 START
		protected static String gsInitSyukka = AppDomain.CurrentDomain.BaseDirectory
										  + "syukka.ini";
		protected static String gsPathSyukka = AppDomain.CurrentDomain.BaseDirectory
										  + "Syukka";
		protected static String gsPathSyukkaIn  = gsPathSyukka + "\\In";
		protected static String gsPathSyukkaOut = gsPathSyukka + "\\Out";
		protected static String gsPathSyukkaLog = gsPathSyukka + "\\Log";
		protected static bool gb自動出力ＯＮ = false;
		protected static int  gi自動出力タイマー = 3;
// ADD 2015.04.13 BEVAS)前田 自動出力タイマー　秒単位指定対応 START
		protected static int  gi自動出力タイマー秒 = 0;
// ADD 2015.04.13 BEVAS)前田 自動出力タイマー　秒単位指定対応 END

// MOD 2010.04.07 東都）高木 出荷ＣＳＶ自動出力 END
// MOD 2010.04.16 東都）高木 モジュール再ダウンロード START
		protected static String gsFlagIS2Client = AppDomain.CurrentDomain.BaseDirectory
										  + "zs2Client.txt";
// MOD 2010.04.16 東都）高木 モジュール再ダウンロード END
// ADD 2008.03.13 東都）高木 Vista対応 START
		protected static bool gbInitFileExt = false;
// ADD 2008.03.13 東都）高木 Vista対応 END
		protected static String gsアプリフォルダ = "";

		protected static string[] gsa県名
			= { "",												// 都道府県ＣＤ
				  "北海道","青森県","岩手県","宮城県","秋田県",		// 01 -
				  "山形県","福島県","茨城県","栃木県","群馬県",		//    - 10
				  "埼玉県","千葉県","東京都","神奈川県","新潟県",	// 11 -
				  "富山県","石川県","福井県","山梨県","長野県",		//    - 20
				  "岐阜県","静岡県","愛知県","三重県","滋賀県",		// 21 -
				  "京都府","大阪府","兵庫県","奈良県","和歌山県",	//    - 30
				  "鳥取県","島根県","岡山県","広島県","山口県",		// 31 -
				  "徳島県","香川県","愛媛県","高知県","福岡県",		//    - 39
				  "佐賀県","長崎県","熊本県","大分県","宮崎県",		// 41 -
				  "鹿児島県","沖縄県"								//    - 
			  };
// ADD 2005.06.07 東都）高木 都道府県選択の変更 START
		protected static int      gi都道府県ＣＤ = 0;
// ADD 2005.06.07 東都）高木 都道府県選択の変更 END
		protected static string[] gsa市区郡
			= { "市原市","市川市","今市市","余市郡","蒲郡市",
				  "郡上市","小郡市","郡山市","高市郡","郡上郡",
				  "廿日市市","四日市市","八日市場市"
			  };
		protected static Hashtable h都道府県   = null;

		protected static String gs会員ＣＤ     = "";
		protected static String gs会員名       = "";
		protected static String gs部門ＣＤ     = "";
		protected static String gs部門名       = "";
		protected static String gs出荷日       = "";
		protected static String gs利用者ＣＤ   = "";
		protected static String gs利用者名     = "";
		protected static String gs端末ＣＤ     = "";
		protected static String gsプリンタＦＧ = "";
		protected static String gsプリンタ種類 = "";
		protected static String gs荷送人ＣＤ   = "";
		protected static String[] gsa部門ＣＤ = {""};
		protected static String[] gsa部門名   = {""};
		protected static String[] gsa出荷日   = {""};
		protected static Hashtable gh部門ＣＤ = null;
		protected static String[] gsa請求先ＣＤ     = {""};
		protected static String[] gsa請求先部課ＣＤ = {""};
		protected static String[] gsa請求先部課名   = {""};
		protected static DateTime gdt出荷日 = DateTime.Today;
		protected static String[] gsa状態ＣＤ = {""};
		protected static String[] gsa状態名   = {""};
// MOD 2007.10.26 東都）高木 バージョン情報を表示する START
//		protected static String[] gsaユーザ = new string[3];
		protected static String[] gsaユーザ = {"","","",""};
// MOD 2007.10.26 東都）高木 バージョン情報を表示する END
//		protected static string gsメッセージ = new String('　',25) + "★お知らせ★　";
		protected static string gsメッセージ = "";

// MDD 2005.05.25 東都）高木 アイコン選択画面の表示時、[.ico]非表示 START
//		protected static String[] sアイコン = { "", 
//												"Icon0008.ico", "Icon0009.ico", "Icon0010.ico", 
//												"Icon0011.ico", "Icon0023.ico", "Icon0024.ico", 
//												"Icon0035.ico", "Icon0069.ico", "Icon0072.ico", 
//												"Icon0075.ico", "Icon0076.ico", "Icon0077.ico", 
//												"Icon0078.ico", "Icon0084.ico", "Icon0113.ico", 
//												"Icon0114.ico", "Icon0142.ico", 
//												"zblue.ico", "zgreen.ico", "zpurple.ico"};
		protected static String[] sアイコン = { "" };
		protected static String[] sアイコン一覧 = { "" };
// MDD 2005.05.25 東都）高木 アイコン選択画面の表示時、[.ico]非表示 END
		protected static Hashtable hアイコン = null;
		protected static ImageList imageList64 = null;
		protected static ImageList imageList16 = null;
		protected static ImageList imageList部門 = null;
// ADD 2009.07.29 東都）高木 プロキシ対応 START
		protected static string gsProxyAdr        = "";
		protected static string gsProxyAdrUserSet = "";
		protected static string gsProxyAdrSecure  = "";
		protected static string gsProxyAdrHttp    = "";
		protected static string gsProxyAdrAll     = "";
		protected static int    giProxyNo         = 0;
		protected static int    giProxyNoUserSet  = 0;
		protected static int    giProxyNoSecure   = 0;
		protected static int    giProxyNoHttp     = 0;
		protected static int    giProxyNoAll      = 0;
		protected static System.Net.WebProxy gProxy;
		protected static int    giConnectTimeOut  = 0;
// ADD 2009.07.29 東都）高木 プロキシ対応 END
// MOD 2011.12.06 東都）高木 プロキシ認証の追加 START
		protected static bool   gbProxyOnUserSet   = false;
		protected static bool   gbProxyIdOnUserSet = false;
		protected static string gsProxyIdUserSet   = "";
		protected static string gsProxyPaUserSet   = "";
// MOD 2011.12.06 東都）高木 プロキシ認証の追加 END
		// Ｗｅｂサービス変数
		protected static is2address.Service1  sv_address  = null;
		protected static is2goirai.Service1   sv_goirai   = null;
		protected static is2hinagata.Service1 sv_hinagata = null;
		protected static is2init.Service1     sv_init     = null;
		protected static is2kiji.Service1     sv_kiji     = null;
		protected static is2otodoke.Service1  sv_otodoke  = null;
		protected static is2print.Service1    sv_print    = null;
		protected static is2syukka.Service1   sv_syukka   = null;
		protected static is2seikyuu.Service1  sv_seikyuu  = null;
// ADD 2007.12.11 KCL) 森本 お知らせ追加 START
		protected static is2oshirase.Service1 sv_oshirase = null;
// ADD 2007.12.11 KCL) 森本 お知らせ追加 END
// ADD 2010.12.13 ACT) 垣原 王子運送対応 START
		protected static is2oji.Service1 sv_oji = null;
// ADD 2010.12.13 ACT) 垣原 王子運送対応 END

// DEL 2005.05.20 東都）高木 セションコントロールの廃止 START
//		// Cookieを保存しておくCookieContainer
//		protected static System.Net.CookieContainer cContainer = new System.Net.CookieContainer();
// DEL 2005.05.20 東都）高木 セションコントロールの廃止 END
		// 雛型出荷登録画面をスタート画面にする場合は、true
		protected static bool   b雛型出荷登録 = false;
		protected static string s雛型出荷登録ＮＯ = "";
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//		// 送り状印刷用データセット
//		protected static 送り状データ ds送り状 = new 送り状データ();
//		// サーマルプリンタチェック用
//		protected static System.Drawing.Printing.PrintDocument pdサーマルプリンタ = new System.Drawing.Printing.PrintDocument();
		// 送り状印刷用データセット
		protected 送り状データ ds送り状 = new 送り状データ();
		// サーマルプリンタチェック用
		protected System.Drawing.Printing.PrintDocument pdサーマルプリンタ = new System.Drawing.Printing.PrintDocument();
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END

// ADD 2005.05.20 東都）西口 スレッド化 START
		protected static 部門変更２  g部門変更       = null;
		protected static 出荷照会    g出荷照会       = null;
// ADD 2005.05.20 東都）西口 スレッド化 END
// ADD 2005.05.24 東都）小童谷 スレッド化 START
		protected static アイコン選択   gアイコン    = null;
		protected static お届け先検索   g届先検索    = null;
		protected static お届け先取込   g届先取込    = null;
		protected static お届け先登録   g届先登録    = null;
		protected static お届け先登録小 g届先登小    = null;
		protected static ご依頼主検索   g依頼検索    = null;
// MOD 2010.08.27 東都）高木 ご依頼主取込（ＣＳＶ）機能追加 START
		protected static ご依頼主取込   g依頼取込    = null;
// MOD 2010.08.27 東都）高木 ご依頼主取込（ＣＳＶ）機能追加 END
		protected static ご依頼主登録   g依頼登録    = null;
		protected static パスワード変更 gパス変更    = null;
		protected static 記事検索       g記事検索    = null;
		protected static 才数切り替え   g才数切替    = null;
		protected static 自動出荷登録   g自動登録    = null;
		protected static 住所検索       g住所検索    = null;
		protected static 出荷登録       g出荷登録    = null;
		protected static 雛型出荷登録   g雛出登録    = null;
		protected static 雛型登録       g雛型登録    = null;
		protected static 請求先登録     g請求登録    = null;
		protected static 端末登録       g端末登録    = null;
		protected static 未発行印刷     g未発印刷    = null;
		protected static 指定時間入力   g指定時間入力 = null;
		protected static 出荷実績       g出荷実績    = null;
// ADD 2015.03.05 BEVAS) 前田 支店止め機能追加対応 START
		protected static 店所検索       g店所検索    = null;
// ADD 2014.03.05 BEVAS) 前田 支店止め機能追加対応 END

// ADD 2006.12.22 東都）小童谷 画面追加 START
		protected static ログイン２     gログイン２  = null;
// ADD 2006.12.22 東都）小童谷 画面追加 END
// ADD 2005.05.24 東都）小童谷 スレッド化 END
// ADD 2007.12.06 KCL) 森本 お知らせ追加 START
		protected static お知らせ表示    gお知表示   = null;
// ADD 2007.12.06 KCL) 森本 お知らせ追加 END
// ADD 2015.07.13 TDI）綱澤 バーコード読取専用画面追加 START
		protected static 読取専用画面    g読取専用画面 = null;
// ADD 2015.07.13 TDI）綱澤 バーコード読取専用画面追加 END
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 START
		protected static 送り状控え印刷 g控え印刷 = null;
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 END

// ADD 2005.05.24 東都）高木 通信エラーのメッセージ修正 START
//		protected static String gs通信エラー
		protected const string gs通信エラー
			= "サーバーとの通信に失敗しました\n"
			+ " ＬＡＮケーブルやネットワーク設定等を確認してください";
// ADD 2005.05.24 東都）高木 通信エラーのメッセージ修正 END
// ADD 2005.07.21 東都）高木 店所ユーザ対応 START
		protected static string gs権限１ = "";
// ADD 2005.07.21 東都）高木 店所ユーザ対応 END
// ADD 2006.12.12 東都）小童谷 部門店所取得 START
		protected static string gs利用者部門店所ＣＤ = "";
		protected static bool   gb印刷 = true;
// ADD 2006.12.12 東都）小童谷 部門店所取得 END
// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 START
		protected static string gs部門店所ＣＤ = "";
// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 END

// ADD 2006.12.14 東都）小童谷 初期部門 START
		protected static string gs利用者部門ＣＤ = "";
// ADD 2006.12.14 東都）小童谷 初期部門 END
// ADD 2008.04.11 ACT Vista対応 START
		protected static Hashtable gh漢字変換 = null;
// ADD 2008.04.11 ACT Vista対応 END
// ADD 2009.04.02 東都）高木 稼働日対応 START
		protected static string[] gs稼働日;
		protected static DateTime gdt出荷日最大値;
		protected static DateTime gdt出荷日最大値ＣＳＶ;
// ADD 2009.04.02 東都）高木 稼働日対応 END
// MOD 2009.05.01 東都）高木 オプションの項目追加 START
// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）START
//// MOD 2009.11.06 PSN）藤井　オプションの項目追加 START
////		protected static int      giオプション数 = 14;
//		protected static int      giオプション数 = 16;
//// MOD 2009.11.06 PSN）藤井　オプションの項目追加 END
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//		protected static int      giオプション数 = 17;
// MOD 2011.05.09 東都）高木 エコー金属版のオプションのマージ START
//		protected static int      giオプション数 = 19;
// MOD 2012.04.10 東都）高木 ラベル発店名の印字制御対応 START
//		protected static int      giオプション数 = 20;
// MOD 2015.07.13 BEVAS)松本 バーコード読取専用画面追加 START
//		protected static int      giオプション数 = 21;
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 START
//		protected static int      giオプション数 = 22;
// MOD 2016.06.10 BEVAS）松本 保険料入力チェック機能の追加 START
//		protected static int      giオプション数 = 23;
		protected static int      giオプション数 = 24;
// MOD 2016.06.10 BEVAS）松本 保険料入力チェック機能の追加 END
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
// MOD 2015.07.13 BEVAS)松本 バーコード読取専用画面追加 END
// MOD 2012.04.10 東都）高木 ラベル発店名の印字制御対応 END
// MOD 2011.05.09 東都）高木 エコー金属版のオプションのマージ END
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）END
		protected static string[] gsオプション = new string[giオプション数+1];
// MOD 2009.05.01 東都）高木 オプションの項目追加 END
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
		protected static string gs重量入力制御 = "0";
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 START
		protected static string gsアドレス帳_表示順１        = null;
		protected static string gsアドレス帳_表示順１_方向   = null;
		protected static string gsアドレス帳_表示順２        = null;
		protected static string gsアドレス帳_表示順２_方向   = null;
		protected static string gsご依頼主検索_表示順１      = null;
		protected static string gsご依頼主検索_表示順１_方向 = null;
		protected static string gsご依頼主検索_表示順２      = null;
		protected static string gsご依頼主検索_表示順２_方向 = null;
// MOD 2010.03.01 東都）高木 端末ごとに表示条件を保持する機能の追加 END
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 START
		protected static string gs出荷実績_未発行分除外              = null;
		protected static string gs出荷実績_網掛けなし_印刷のみ       = null;
		protected static string gs出荷実績_ご依頼主印字なし_印刷のみ = null;
		protected static string gs出荷実績_運賃印字なし_印刷のみ     = null;
		protected static string gs出荷実績_発店出力_ＣＳＶのみ       = null;
		protected static string gs出荷実績_配完日時出力              = null;
// MOD 2016.06.10 BEVAS）松本 出荷実績画面のオプションチェック内容を端末毎に保存 END
// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
		protected static int giDisplayDpiX = 0;
		protected static int giDisplayDpiY = 0;
// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 END
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
		protected static string gsお知らせ案内メッセージ = "";
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) START
		protected const long gl保険金額上限 = 9999;
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) END
// MOD 2016.04.13 BEVAS）松本 配達指定日上限の拡張 START
		protected static string gs指定日上限拡張会員ＣＤ = "0584898934";  //セリア様のみ対象
// MOD 2016.04.13 BEVAS）松本 配達指定日上限の拡張 END
// MOD 2016.06.10 BEVAS）松本 保険料入力チェック機能の追加 START
		protected const long gl保険金額チェック基準 = 31;
// MOD 2016.06.10 BEVAS）松本 保険料入力チェック機能の追加 END

		[System.Runtime.InteropServices.DllImport("user32.dll")] 
		protected static extern int MessageBeep(uint n); 
// MOD 2010.03.12 東都）高木 １００００件チェック解除機能の追加 START
		[System.Runtime.InteropServices.DllImport("user32.dll")] 
		protected static extern short GetAsyncKeyState(Keys vKey); 
// MOD 2010.03.12 東都）高木 １００００件チェック解除機能の追加 END

		protected void エンター移動(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyCode){
				// [Enter]キーが押された時、次のコントロールへフォーカス移動
				case Keys.Enter:
//					System.Windows.Forms.SendKeys.Send("{TAB}");
// MOD 2007.11.22 KCL) 森本 Vista対応 START
//// ADD 2007.11.08 東都）高木 Vista対応 START
//					try
//					{
//// ADD 2007.11.08 東都）高木 Vista対応 END
//						System.Windows.Forms.SendKeys.SendWait("{TAB}");
//// ADD 2007.11.08 東都）高木 Vista対応 START
//					}
//					catch(System.Security.SecurityException)
//					{
//					}
//// ADD 2007.11.08 東都）高木 Vista対応 END
					// 別の方法 - その１
					//this.ProcessTabKey(!e.Shift);

					// 別の方法 - その２
					this.SelectNextControl(this.ActiveControl, true, true, true, true);
// MOD 2007.11.22 KCL) 森本 Vista対応 END
					break;
				// [Esc]キーが押された時、フォームを閉じる
				case Keys.Escape:
					Close();
					break;
			}
		}
		protected void エンターキャンセル(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == 0x0d)
			{
				e.Handled = true;
			}
		}
		protected static bool 必須チェック(TextBox tex, string name)
		{
			if(tex.Text.Length > 0) return true;
			MessageBox.Show("必須項目(" + name + ")が入力されていません",
				"入力チェック",MessageBoxButtons.OK);
			tex.Focus();
			return false;
		}

// ADD 2007.03.29 東都）高木 ＳＪＩＳチェック機能の追加 START
// MOD 2008.04.11 ACT Vista対応 START
//		private static bool ＳＪＩＳチェック(TextBox tex, string name, string sUnicode, byte[] bSjis)
		private static bool ＳＪＩＳチェック(TextBox tex, string name, ref string sUnicode, ref byte[] bSjis)
// MOD 2008.04.11 ACT Vista対応 END
		{
			//逆変換してＳＪＩＳ文字をチェックする
			string sRevUnicode = System.Text.Encoding.GetEncoding("shift-jis").GetString(bSjis);
			string sErrChars = "";
			for(int iPos = 0; iPos < sUnicode.Length && iPos < sRevUnicode.Length; iPos++)
			{
				if(sUnicode[iPos] != sRevUnicode[iPos])
				{
// DEL 2007.11.22 KCL) 森本 Unicode サロゲート・ペア対応 START
//					if(sErrChars.IndexOf(sUnicode[iPos]) == -1)
//					{
//						if(sErrChars.Length > 0) sErrChars += "、";
// DEL 2007.11.22 KCL) 森本 Unicode サロゲート・ペア対応 END
						sErrChars += sUnicode[iPos];
// DEL 2007.11.22 KCL) 森本 Unicode サロゲート・ペア対応 START
//					}
// DEL 2007.11.22 KCL) 森本 Unicode サロゲート・ペア対応 END
				}
			}
			if(sErrChars.Length > 0)
			{
// MOD 2008.04.11 ACT Vista対応 START
//				MessageBox.Show(name + "に使用できない文字があります\n"
//					+ "『" + sErrChars + "』",
//					"入力チェック",MessageBoxButtons.OK);
//				tex.Focus();
//				return false;
				return 漢字変換(tex, name, ref sUnicode, ref bSjis);
// MOD 2008.04.11 ACT Vista対応 END
			}
			return true;
		}

// ADD 2007.03.29 東都）高木 ＳＪＩＳチェック機能の追加 END

		protected static bool 全角チェック(TextBox tex, string name)
		{
			string sUnicode = tex.Text;
			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
// MOD 2008.04.11 ACT Vista対応 START
//// ADD 2007.03.29 東都）高木 ＳＪＩＳチェック機能の追加 START
//			if(!ＳＪＩＳチェック(tex, name, sUnicode, bSjis)) return false;
			if(!ＳＪＩＳチェック(tex, name, ref sUnicode, ref bSjis)) return false;
//// ADD 2007.03.29 東都）高木 ＳＪＩＳチェック機能の追加 END
// MOD 2008.04.11 ACT Vista対応 END
			if(bSjis.Length == sUnicode.Length * 2) return true;
			MessageBox.Show(name + "は全角文字で入力してください",
				"入力チェック",MessageBoxButtons.OK);
			tex.Focus();
			return false;
		}

// MOD 2011.12.08 東都）高木 住所・名前の半角入力可 START
		//
		// 入力項目の長さ制限より短くカットする必要があった為作成
		// （記事の長さチェック）
		//
		protected bool 全角変換チェック(TextBox tex, string name)
		{
			string sUnicode = tex.Text;
			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
			if(!ＳＪＩＳチェック(tex, name, ref sUnicode, ref bSjis)) return false;

			// すべて全角文字の場合は、リターン
			if(bSjis.Length == sUnicode.Length * 2) return true;

			DialogResult result;
			result = MessageBox.Show(name + "に半角文字が含まれています。"
				+ "全角文字に変換してよろしいですか？"
				, "入力チェック", MessageBoxButtons.YesNo);
			if(result != DialogResult.Yes){
				tex.Focus();
				return false;
			}

			string sErr = "";
			bool bRet = 全角変換チェック(ref sUnicode, ref sErr);
			if(bRet == false){
//保留 エラー処理
				MessageBox.Show(name + "に使用できない文字があります\n"
					+ "『" + sErr + " → ? 』",
					"入力チェック",MessageBoxButtons.OK);
				tex.Focus();
				return false;
			}

			// 桁数チェック
			if(sUnicode.Length > tex.MaxLength){
				result = MessageBox.Show(name + "の制限文字数を超えています（"
					+ (sUnicode.Length - tex.MaxLength)+"文字超過）\n"
					+ "超過分をカットしてよろしいですか？"
					, "入力チェック", MessageBoxButtons.YesNo);
				if(result != DialogResult.Yes){
					tex.Focus();
					return false;
				}
				tex.Text = バイト長カット(sUnicode, tex.MaxLength * 2);
				tex.Refresh();
				return true;
			}

			tex.Text = sUnicode;
			tex.Refresh();
			return true;
		}
// MOD 2011.12.08 東都）高木 住所・名前の半角入力可 END

		protected static bool 半角チェック(TextBox tex, string name)
		{
			string sUnicode = tex.Text;
			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
// MOD 2008.04.11 ACT Vista対応 START
//// ADD 2007.03.29 東都）高木 ＳＪＩＳチェック機能の追加 START
//			if(!ＳＪＩＳチェック(tex, name, sUnicode, bSjis)) return false;
			if(!ＳＪＩＳチェック(tex, name, ref sUnicode, ref bSjis)) return false;
//// ADD 2007.03.29 東都）高木 ＳＪＩＳチェック機能の追加 END
// MOD 2008.04.11 ACT Vista対応 END
			if(bSjis.Length != sUnicode.Length)
			{
				MessageBox.Show(name + "は半角文字で入力してください",
					"入力チェック",MessageBoxButtons.OK);
				tex.Focus();
				return false;
			}

			for(int i = 0; i < tex.Text.Length; i++)
			{
				// [!"#$%&'()*,]
				// [:;<=>?]
				// [[]^]
				// [{|}]
				// [\]
// MOD 2009.11.04 東都）高木 お届け先ＣＤに記号[+]を利用可能にする START
//				if((tex.Text[i] >= 0x21 && tex.Text[i] <= 0x2C)
				if((tex.Text[i] >= 0x21 && tex.Text[i] <= 0x2A)
					|| (tex.Text[i] == 0x2C)
// MOD 2009.11.04 東都）高木 お届け先ＣＤに記号[+]を利用可能にする END
					|| (tex.Text[i] >= 0x3A && tex.Text[i] <= 0x3F)
					|| (tex.Text[i] >= 0x5B && tex.Text[i] <= 0x5E)
					|| (tex.Text[i] >= 0x7B && tex.Text[i] <= 0x7D)
					|| (tex.Text[i] == 0xA5))
				{
					MessageBox.Show(name + "に記号が入力されています","入力チェック",MessageBoxButtons.OK);
					tex.Focus();
					return false;
				}
			}
			return true;
		}

		protected static bool パスワードチェック(TextBox tex, string name)
		{
			string sUnicode = tex.Text;
			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
// MOD 2008.05.13 東都）高木 Vista対応 START
//// ADD 2008.03.13 東都）高木 ＳＪＩＳチェック機能の追加 START
//			if(!ＳＪＩＳチェック(tex, name, sUnicode, bSjis)) return false;
			if(!ＳＪＩＳチェック(tex, name, ref sUnicode, ref bSjis)) return false;
//// ADD 2008.03.13 東都）高木 ＳＪＩＳチェック機能の追加 END
// MOD 2008.05.13 東都）高木 Vista対応 END
			//半角チェック
			if(bSjis.Length != sUnicode.Length)
			{
				MessageBox.Show("利用者ＣＤもしくはパスワードに誤りがあります",
					"入力チェック",MessageBoxButtons.OK);
				tex.Focus();
				return false;
			}

			for(int i = 0; i < tex.Text.Length; i++)
			{
				// [!"#$%&'()*,]
				// [:;<=>?]
				// [[]^]
				// [{|}]
				// [\]
// MOD 2009.11.04 東都）高木 お届け先ＣＤに記号[+]を利用可能にする START
//				if((tex.Text[i] >= 0x21 && tex.Text[i] <= 0x2C)
				if((tex.Text[i] >= 0x21 && tex.Text[i] <= 0x2A)
					|| (tex.Text[i] == 0x2C)
// MOD 2009.11.04 東都）高木 お届け先ＣＤに記号[+]を利用可能にする END
					|| (tex.Text[i] >= 0x3A && tex.Text[i] <= 0x3F)
					|| (tex.Text[i] >= 0x5B && tex.Text[i] <= 0x5E)
					|| (tex.Text[i] >= 0x7B && tex.Text[i] <= 0x7D)
					|| (tex.Text[i] == 0xA5))
				{
					MessageBox.Show("利用者ＣＤもしくはパスワードに誤りがあります","入力チェック",MessageBoxButtons.OK);
					tex.Focus();
					return false;
				}
			}
			return true;
		}

// MOD 2009.12.01 東都）高木 全角半角混在可能にする START
		protected static bool 混在チェック(TextBox tex, string name)
		{
			string sUnicode = tex.Text;
			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
			if(!ＳＪＩＳチェック(tex, name, ref sUnicode, ref bSjis)) return false;

			// 桁数チェック
			if(bSjis.Length > tex.MaxLength){
				DialogResult result;
// MOD 2010.01.15 東都）高木 文字数カットのメッセージの変更 START
//				result = MessageBox.Show(name + "の文字数が "
//					+ (bSjis.Length - tex.MaxLength) +"バイト分多すぎます\n"
//					+ tex.MaxLength+"バイト以内で入力してください\n"
//					+ "（半角文字は 1バイト、全角文字は 2バイトとして数えます）\n"
//					+ "先頭から 30バイト分でカットしてよろしいですか？"
				result = MessageBox.Show(name + "の制限文字数を超えています（"
					+ (bSjis.Length - tex.MaxLength)+"バイト超過）\n"
					+ "超過分をカットしてよろしいですか？\n"
					+ "（※半角文字は 1バイト、全角文字は 2バイトとして数えます）\n"
// MOD 2010.01.15 東都）高木 文字数カットのメッセージの変更 END
					, "入力チェック", MessageBoxButtons.YesNo);
				if(result != DialogResult.Yes){
					tex.Focus();
					return false;
				}
				tex.Text = バイト長カット(tex.Text, tex.MaxLength);
				tex.Refresh();
			}

			for(int i = 0; i < tex.Text.Length; i++)
			{
//				// [!"#$%&'()*,]
//				// [:;<=>?]
//				// [[]^]
//				// [{|}]
//				// [\]
//// MOD 2009.11.04 東都）高木 お届け先ＣＤに記号[+]を利用可能にする START
////				if((tex.Text[i] >= 0x21 && tex.Text[i] <= 0x2C)
//				if((tex.Text[i] >= 0x21 && tex.Text[i] <= 0x2A)
//					|| (tex.Text[i] == 0x2C)
//// MOD 2009.11.04 東都）高木 お届け先ＣＤに記号[+]を利用可能にする END
//					|| (tex.Text[i] >= 0x3A && tex.Text[i] <= 0x3F)
//					|| (tex.Text[i] >= 0x5B && tex.Text[i] <= 0x5E)
//					|| (tex.Text[i] >= 0x7B && tex.Text[i] <= 0x7D)
//					|| (tex.Text[i] == 0xA5))
//				{
//					MessageBox.Show(name + "に記号が入力されています","入力チェック",MessageBoxButtons.OK);
//					tex.Focus();
//					return false;
//				}
				// ["',;|]
				if(tex.Text[i] == 0x22 || tex.Text[i] == 0x27 
					|| tex.Text[i] == 0x2C || tex.Text[i] == 0x3B
					|| tex.Text[i] == 0x7C )
				{
					MessageBox.Show(name + "に記号["+tex.Text[i]+"]が入力されています"
						,"入力チェック",MessageBoxButtons.OK);
					tex.Focus();
					return false;
				}
			}
			
			return true;
		}
// MOD 2009.12.01 東都）高木 全角半角混在可能にする END
// MOD 2011.07.28 東都）高木 記事行の追加（入力制限の追加） START
		//
		// 入力項目の長さ制限より短くカットする必要があった為作成
		// （記事の長さチェック）
		//
		protected static bool 混在チェック２(TextBox tex, string name, int iMaxLength)
		{
			string sUnicode = tex.Text;
			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
			if(!ＳＪＩＳチェック(tex, name, ref sUnicode, ref bSjis)) return false;

			// 桁数チェック
			if(bSjis.Length > iMaxLength){
				DialogResult result;
				result = MessageBox.Show(name + "の制限文字数を超えています（"
					+ (bSjis.Length - iMaxLength)+"バイト超過）\n"
					+ "超過分をカットしてよろしいですか？\n"
					+ "（※半角文字は 1バイト、全角文字は 2バイトとして数えます）\n"
					, "入力チェック", MessageBoxButtons.YesNo);
				if(result != DialogResult.Yes){
					tex.Focus();
					return false;
				}
				tex.Text = バイト長カット(tex.Text, iMaxLength);
				tex.Refresh();
			}

			for(int i = 0; i < tex.Text.Length; i++)
			{
				// ["',;|]
				if(tex.Text[i] == 0x22 || tex.Text[i] == 0x27 
					|| tex.Text[i] == 0x2C || tex.Text[i] == 0x3B
					|| tex.Text[i] == 0x7C )
				{
					MessageBox.Show(name + "に記号["+tex.Text[i]+"]が入力されています"
						,"入力チェック",MessageBoxButtons.OK);
					tex.Focus();
					return false;
				}
			}
			
			return true;
		}
// MOD 2011.07.28 東都）高木 記事行の追加（入力制限の追加） END

		protected static bool 数値チェック(TextBox tex, string name)
		{
			try
			{
// MOD 2006.05.30 東都）高木 数値チェックの桁あふれ対応 START
//				int iChk = int.Parse(tex.Text.Replace(",",""));
				long lChk = long.Parse(tex.Text.Replace(",",""));
// MOD 2006.05.30 東都）高木 数値チェックの桁あふれ対応 END
				return true;
			}
// MOD 2006.05.30 東都）高木 数値チェックの桁あふれ対応 START
//			catch(System.FormatException)
			catch(Exception)
// MOD 2006.05.30 東都）高木 数値チェックの桁あふれ対応 END
			{
				MessageBox.Show(name + "に数値が入力されていません","入力チェック",MessageBoxButtons.OK);
				tex.Focus();
				
				return false;
			}
		}

		//NumericUpDown用
		protected static bool 範囲チェック(NumericUpDown num, string name)
		{
			try
			{
// MOD 2006.05.30 東都）高木 数値チェックの桁あふれ対応 START
//				int iChk = int.Parse(num.Text.Replace(",",""));
//				if (iChk >= num.Minimum && iChk <= num.Maximum) return true;
				long lChk = long.Parse(num.Text.Replace(",",""));
// ADD 2007.03.29 東都）高木 整数チェック機能の強化 START
				//内部数値に表示数値を代入（小数入力障害対応）
				num.Value = lChk;
// ADD 2007.03.29 東都）高木 整数チェック機能の強化 END
				if (lChk >= num.Minimum && lChk <= num.Maximum) return true;
// MOD 2006.05.30 東都）高木 数値チェックの桁あふれ対応 END
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 START
//				MessageBox.Show(name + "は" + num.Minimum + "～" + num.Maximum + "の間で入力してください","入力チェック",MessageBoxButtons.OK);
				MessageBox.Show(name + "は "
					+ num.Minimum + "～" + num.Maximum + " の値を入力してください　"
					, "入力チェック", MessageBoxButtons.OK);
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 END
				num.Focus();
				return false;
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 START
			}catch(System.ArgumentException){
				// コントロールの下限値もしくは上限値を超えた時
				MessageBox.Show(name + "は "
					+ num.Minimum + "～" + num.Maximum + " の値を入力してください　"
					, "入力チェック", MessageBoxButtons.OK);
				num.Focus();
				return false;
			}catch(System.OverflowException){
				// long型の下限値もしくは上限値を超えた時
				// （桁あふれ等）
				MessageBox.Show(name + "は "
					+ num.Minimum + "～" + num.Maximum + " の値を入力してください　"
					, "入力チェック", MessageBoxButtons.OK);
				num.Focus();
				return false;
			}catch(System.FormatException){
				// コントロールのフォーマット形式と異なる時
				// （小数点や数字以外が入力されている場合等）
				MessageBox.Show(name + "は "
					+ num.Minimum + "～" + num.Maximum + " の整数を入力してください　"
					, "入力チェック", MessageBoxButtons.OK);
				num.Focus();
				return false;
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 END
			}
// MOD 2006.05.30 東都）高木 数値チェックの桁あふれ対応 START
//			catch(System.FormatException)
			catch(Exception)
// MOD 2006.05.30 東都）高木 数値チェックの桁あふれ対応 END
			{
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 START
//// ADD 2005.09.02 東都）小童谷 メッセージ変更 START
////				MessageBox.Show(name + "に数値が入力されていません","入力チェック",MessageBoxButtons.OK);
//				MessageBox.Show(name + "に整数が入力されていません","入力チェック",MessageBoxButtons.OK);
//// ADD 2005.09.02 東都）小童谷 メッセージ変更 END
				MessageBox.Show(name + "は "
					+ num.Minimum + "～" + num.Maximum + " の整数を入力してください　"
					, "入力チェック", MessageBoxButtons.OK);
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 END
				num.Focus();
				return false;
			}
		}

// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 START
		protected static bool 範囲チェック(NumericUpDown num, string name, long lMin, long lMax, string sMaxMsg)
		{
			try{
				string data = num.Text.Replace(",","");
				string sChkMsg = 数値範囲チェック(name, data, lMin, lMax, sMaxMsg);
				if(sChkMsg.Length > 0){
					MessageBox.Show(sChkMsg + "　"
						, "入力チェック", MessageBoxButtons.OK);
					num.Focus();
					return false;
				}
				long lChk = long.Parse(data);
				//内部数値に表示数値を代入（小数入力障害対応）
				num.Value = lChk;
			}catch(System.ArgumentException){
				// コントロールの下限値もしくは上限値を超えた時
				MessageBox.Show(name + "は "
					+ lMin + "～" + lMax + " の値を入力してください　"
					, "入力チェック", MessageBoxButtons.OK);
				num.Focus();
				return false;
			}catch(Exception){
				MessageBox.Show(name + "は "
					+ lMin + "～" + lMax + " の整数を入力してください　"
					, "入力チェック", MessageBoxButtons.OK);
				num.Focus();
				return false;
			}
			return true;
		}

		protected static string 数値範囲チェック(string name, string data, long lMin, long lMax, string sMaxMsg)
		{
			string sRet = "";
			try{
				if(data.IndexOf(".") >= 0){
					sRet = name + "は整数を入力してください";
					return sRet;
				}
				long lChk = long.Parse(data.Replace(",",""));
				// 範囲内ならＯＫ
				if(lChk >= lMin && lChk <= lMax){
					return sRet;
				}
				if(sMaxMsg.Length > 0 && lChk > lMin){
					sRet = name + "は"+ sMaxMsg + "で入力してください";
				}else{
					sRet = name + "は "+ lMin + "～" + lMax + " の値を入力してください";
				}
//			}catch(System.ArgumentException){
//				// コントロールの下限値もしくは上限値を超えた時
//				sRet = name + "は "+ lMin + "～" + lMax + " の値を入力してください";
			}catch(System.OverflowException){
				// long型の下限値もしくは上限値を超えた時
				// （桁あふれ等）
				sRet = name + "は "+ lMin + "～" + lMax + " の値を入力してください";
			}catch(System.FormatException){
				// コントロールのフォーマット形式と異なる時
				// （小数点や数字以外が入力されている場合等）
				sRet = name + "は "+ lMin + "～" + lMax + " の整数を入力してください";
			}catch(Exception){
				sRet = name + "は "+ lMin + "～" + lMax + " の整数を入力してください";
			}
			return sRet;
		}
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 END

// ADD 2005.06.30 東都）小童谷 データ取込時のチェック START
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//		protected static bool 必須チェック(string data)
		protected bool 必須チェック(string data)
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
		{
			if (data.Trim().Length == 0)
				return false;
			else
				return true;
		}
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//		protected static bool 全角チェック(string data)
		protected bool 全角チェック(string data)
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
		{
			string sUnicode = data;
			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
			if(bSjis.Length == sUnicode.Length * 2) return true;

			return false;
		}
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//		protected static bool 半角チェック(string data)
		protected bool 半角チェック(string data)
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
		{
			string sUnicode = data;
			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
			if(bSjis.Length != sUnicode.Length) return false;
			return true;
		}

// MOD 2009.12.01 東都）高木 全角半角混在可能にする START
		protected static string バイト長カット(string data, int iMaxLength)
		{
			string sRet = data;
			byte[] bSjis;

			bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(data);
			//範囲内ならそのまま戻す
			if(bSjis.Length <= iMaxLength){
				return sRet;
			}

			try{
				string sUnicode;
				for(int iLen = iMaxLength / 2; iLen <= data.Length; iLen++){
					sUnicode = data.Substring(0,iLen);
					bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
					if(bSjis.Length > iMaxLength){
						break;
					}
					sRet = sUnicode;
				}
			}catch(Exception){
				;
			}

			return sRet;
		}
// MOD 2009.12.01 東都）高木 全角半角混在可能にする END

// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
//		protected static bool 記号チェック(string data)
		protected bool 記号チェック(string data)
		{
			for(int i = 0; i < data.Length; i++)
			{
				// [!"#$%&'()*,]
				// [:;<=>?]
				// [[]^]
				// [{|}]
				// [\]
				if((data[i] >= 0x21 && data[i] <= 0x2A)
					|| (data[i] == 0x2C)
					|| (data[i] >= 0x3A && data[i] <= 0x3F)
					|| (data[i] >= 0x5B && data[i] <= 0x5E)
					|| (data[i] >= 0x7B && data[i] <= 0x7D)
					|| (data[i] == 0xA5))
				{
					return false;
				}
			}
			return true;
		}
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//		protected static bool 記号チェック２(string data)
		protected bool 記号チェック２(string data)
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
		{
			for(int i = 0; i < data.Length; i++)
			{
//				// ["',;|]
//				if(data[i] == 0x22 || data[i] == 0x27 
//					|| data[i] == 0x2C || data[i] == 0x3B
//					|| data[i] == 0x7C )
				// [;|]
				if(data[i] == 0x3B || data[i] == 0x7C)
				{
					return false;
				}
			}
			return true;
		}
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END

// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//		protected static bool 数値チェック(string data)
		protected bool 数値チェック(string data)
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
		{
			try
			{
// MOD 2006.05.30 東都）高木 数値チェックの桁あふれ対応 END
//				int iChk = int.Parse(data.Replace(",",""));
				long lChk = long.Parse(data.Replace(",",""));
// MOD 2006.05.30 東都）高木 数値チェックの桁あふれ対応 END
				return true;
			}
// MOD 2006.05.30 東都）高木 数値チェックの桁あふれ対応 START
//			catch(System.FormatException)
			catch(Exception)
// MOD 2006.05.30 東都）高木 数値チェックの桁あふれ対応 END
			{
				return false;
			}
		}

// ADD 2005.06.30 東都）小童谷 データ取込時のチェック END

// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//		protected static string 住所編集(string s住所)
		protected string 住所編集(string s住所)
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
		{
// ADD 2005.08.08 東都）小童谷 2文字以下の時は編集しない START
			if(s住所.Length <= 2) return s住所;
// ADD 2005.08.08 東都）小童谷 2文字以下の時は編集しない END

			// 都道府県ハッシュテーブルの作成
			if(h都道府県 == null)
			{
				h都道府県 = new Hashtable();
				for(int iCnt = 1; iCnt < gsa県名.Length; iCnt++)
				{
					h都道府県.Add(iCnt,gsa県名[iCnt]);
				}
			}

			string s県名   = "";
			string s市区郡 = "";
			string s編集中 = "";
			string s編集後 = "";
			int    iIndex  = 0;

			// 「神奈川県」、「和歌山県」、「鹿児島県」は４文字で分解し比較する
			if(s住所.StartsWith("神") || s住所.StartsWith("和") || s住所.StartsWith("鹿"))
			{
//				s編集中 = s住所.Insert(4," ");
// ADD 2008.06.17 東都）高木 住所１が[神][和][鹿]で始まりかつ３文字だけの場合の対応 START
				// [和泉市]、[鹿屋市]など
//				if(s編集中.Length >= 4){
				if(s住所.Length >= 4){
// ADD 2008.06.17 東都）高木 住所１が[神][和][鹿]で始まりかつ３文字だけの場合の対応 END
					s編集中 = s住所.Substring(0,4);
					iIndex  = 4;
// ADD 2008.06.17 東都）高木 住所１が[神][和][鹿]で始まりかつ３文字だけの場合の対応 START
				}
// ADD 2008.06.17 東都）高木 住所１が[神][和][鹿]で始まりかつ３文字だけの場合の対応 END
			}
			else
			{
//				s編集中 = s住所.Insert(3," ");
				s編集中 = s住所.Substring(0,3);
				iIndex  = 3;
			}

			if(h都道府県.ContainsValue(s編集中))
			{
//				s県名   = s住所.Insert(iIndex," ");
				s県名   = s編集中;
				s編集中 = s住所.Remove(0,iIndex);
			}
			else
				s編集中 = s住所;

			s市区郡 = s編集中;
			for(int iCnt = 0; iCnt < gsa市区郡.Length; iCnt++)
			{
				if(gsa市区郡[iCnt].Length <= s市区郡.Length)
				{
					if(gsa市区郡[iCnt] == s市区郡.Substring(0,gsa市区郡[iCnt].Length))
					{
						s市区郡 = s編集中.Insert(gsa市区郡[iCnt].Length," ");
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
						if(gsオプション[18].Equals("1")){
							if(s県名.Trim().Length > 0){
								s編集後 = s県名 + " " + s市区郡;
							}else{
								s編集後 = s市区郡;
							}
							return s編集後.TrimEnd();
						}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
						s編集後 = s県名 + " " + s市区郡;
						return s編集後.Trim();
					}
				}
			}

			for(iIndex = 1; iIndex < s編集中.Length; iIndex++)
			{
				if(s編集中.Substring(iIndex,1) == "市"
					|| s編集中.Substring(iIndex,1) == "区"
					|| s編集中.Substring(iIndex,1) == "郡")
				{
					s市区郡 = s編集中.Insert(iIndex + 1," ");
// MOD 2006.05.24 東都）高木 市区郡分解の終了条件の修正 START
//					iIndex = 15;
					break;
// MOD 2006.05.24 東都）高木 市区郡分解の終了条件の修正 END
				}
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
			if(gsオプション[18].Equals("1")){
				if(s県名.Trim().Length > 0){
					s編集後 = s県名 + " " + s市区郡;
				}else{
					s編集後 = s市区郡;
				}
				return s編集後.TrimEnd();
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
			s編集後 = s県名 + " " + s市区郡;
			return s編集後.Trim();
		}

		protected static void ビープ音()
		{
			MessageBeep(0x00000030);

		}

		protected static void アイコンイメージの初期化()
		{
			if(imageList16 != null && imageList64 != null) return;

			imageList64 = new ImageList();
//			imageList64.ImageSize = new System.Drawing.Size(64, 64);
			imageList64.ImageSize = new System.Drawing.Size(32, 32);
			imageList64.TransparentColor = System.Drawing.Color.Transparent;
			imageList16 = new ImageList();
			imageList16.ImageSize = new System.Drawing.Size(16, 16);
			imageList16.TransparentColor = System.Drawing.Color.Transparent;
			
			imageList64.Images.Add(System.Drawing.SystemIcons.WinLogo);
			imageList16.Images.Add(System.Drawing.SystemIcons.WinLogo);

//			string[] sファイル = Directory.GetFiles("icon\\", "*.ico");
// 復活 2005.05.09 DEL 2005.05.06 東都）高木 アイコン選択の修正 START
			string[] sファイル = Directory.GetFiles(gsアプリフォルダ + "\\icon\\", "*.ico");
			sアイコン = new string[sファイル.Length + 1];
			sアイコン[0] = "";
// 復活 2005.05.09 DEL 2005.05.06 東都）高木 アイコン選択の修正 END  
// ADD 2005.05.25 東都）高木 アイコン選択画面の表示時、[.ico]非表示 START
			sアイコン一覧 = new string[sファイル.Length + 1];
			sアイコン一覧[0] = "";
// ADD 2005.05.25 東都）高木 アイコン選択画面の表示時、[.ico]非表示 END

			hアイコン = new Hashtable();

			for(int iCnt = 1; iCnt < sアイコン.Length; iCnt++)
			{
// 復活 2005.05.09 MOD 2005.05.06 東都）高木 アイコン選択の修正 START
				int iLastPath = sファイル[iCnt - 1].LastIndexOf('\\');
				if(iLastPath >= 0)
					sアイコン[iCnt] = sファイル[iCnt - 1].Substring(iLastPath + 1);
				else
					sアイコン[iCnt] = sファイル[iCnt - 1];

				hアイコン.Add(sアイコン[iCnt],iCnt);
// ADD 2005.05.25 東都）高木 アイコン選択画面の表示時、[.ico]非表示 START
				int iLastExt = sアイコン[iCnt].LastIndexOf(".");
				if(iLastExt > 0)
					sアイコン一覧[iCnt] = sアイコン[iCnt].Substring(0,iLastExt);
				else
					sアイコン一覧[iCnt] = sアイコン[iCnt];
// ADD 2005.05.25 東都）高木 アイコン選択画面の表示時、[.ico]非表示 END
// ADD 2005.06.03 東都）高木 アイコン選択画面の表示時、先頭３文字非表示 START
				if(sアイコン一覧[iCnt].Length > 3)
					sアイコン一覧[iCnt] = sアイコン一覧[iCnt].Substring(3);
// ADD 2005.06.03 東都）高木 アイコン選択画面の表示時、先頭３文字非表示 END

				imageList64.Images.Add(Image.FromFile(sファイル[iCnt - 1]));
				imageList16.Images.Add(Image.FromFile(sファイル[iCnt - 1]));
//				hアイコン.Add(sアイコン[iCnt],iCnt);
//				imageList64.Images.Add(Image.FromFile(gsアプリフォルダ + "\\icon\\" + sアイコン[iCnt]));
//				imageList16.Images.Add(Image.FromFile(gsアプリフォルダ + "\\icon\\" + sアイコン[iCnt]));
// 復活 2005.05.09 MOD 2005.05.06 東都）高木 アイコン選択の修正 END  
			}
		}

		protected static int アイコンイメージの取得(string sファイル名)
		{
			object obj = hアイコン[sファイル名];
			if(obj == null) return 0;

			return (int)obj;
		}

		protected static void 部門アイコンの初期化()
		{
			if(imageList部門 != null) return;

			imageList部門 = new ImageList();
			imageList部門.ImageSize = new System.Drawing.Size(32, 32);
			imageList部門.TransparentColor = System.Drawing.Color.Transparent;
// MOD 2005.05.06 東都）高木 アイコン選択の修正 START
//			imageList部門.Images.Add(Image.FromFile(gsアプリフォルダ + "\\img\\Icon0002.ico"));
// MOD 2005.05.09 東都）高木 部門アイコンのフォルダ変更 START
//			imageList部門.Images.Add(Image.FromFile(gsアプリフォルダ + "\\icon\\Icon0002.ico"));
			imageList部門.Images.Add(Image.FromFile(gsアプリフォルダ + "\\bumon\\Icon0002.ico"));
// MOD 2005.05.09 東都）高木 部門アイコンのフォルダ変更 END
// MOD 2005.05.06 東都）高木 アイコン選択の修正 END  
		}

		protected static byte[] toSJIS(string sデータ)
		{
			byte[] bSJIS;

// MOD 2010.06.01 東都）高木 ファイル出力時の改行の変更 START
//			bSJIS = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sデータ + "\n");
			bSJIS = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sデータ + "\r\n");
// MOD 2010.06.01 東都）高木 ファイル出力時の改行の変更 END
			return bSJIS;
		}

		private void InitializeComponent()
		{
			// 
			// 共通フォーム
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "共通フォーム";

		}
		
// ADD 2006.10.10 東都）高木 ＳＡＴＯ製プリンタ障害対応 START
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//		protected static string 初期登録前プリンタチェック()
		protected string 初期登録前プリンタチェック()
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
		{
			string sプリンタ種類 = "";
			string sPrinter = "";
			int iCnt = 0;

			// プリンタ設定の存在チェック
			for(iCnt = 0; iCnt < PrinterSettings.InstalledPrinters.Count; iCnt++)
			{
				sPrinter = PrinterSettings.InstalledPrinters[iCnt];

//保留 ADD 2008.06.12 東都）高木 ＴＥＣ製プリンタ対応 START
//				//ＴＥＣ製サーマルプリンタ（ＵＳＢ）
//				if(sPrinter.IndexOf("B-SV4-JP") >= 0)
//				{
//					pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
//					if(pdサーマルプリンタ.PrinterSettings.IsValid)
//					{
//						sプリンタ種類 = "S0003";
//						break;
//					}
//				}
//保留 ADD 2008.06.12 東都）高木 ＴＥＣ製プリンタ対応 END  

// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 START
				//ＳＡＴＯ製サーマルプリンタ（CS408T）
// MOD 2013.10.22 BEVAS）高杉 ＳＡＴＯ製プリンタ(CS408T)プリンタ名小文字対応 START
//				if(sPrinter.IndexOf("CS408T") >= 0)
				if(sPrinter.IndexOf("CS408T") >= 0 || sPrinter.IndexOf("cs408t") >= 0)
// MOD 2013.10.22 BEVAS）高杉 ＳＡＴＯ製プリンタ(CS408T)プリンタ名小文字対応 END
				{
					pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
					if(pdサーマルプリンタ.PrinterSettings.IsValid)
					{
						sプリンタ種類 = "S0005";
						break;
					}
				}
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 END

// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 START
				//ＳＡＴＯ製サーマルプリンタ（CS408T）
				// MOD 2013.04.11 TDI）綱澤 プリンタ名小文字対応 START
				//if(sPrinter.IndexOf("CF408T") >= 0)
				if(sPrinter.IndexOf("CF408T") >= 0 || sPrinter.IndexOf("cf408") >= 0)
				// MOD 2013.04.11 TDI）綱澤 プリンタ名小文字対応 END
				{
					pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
					if(pdサーマルプリンタ.PrinterSettings.IsValid)
					{
						sプリンタ種類 = "S0006";
						break;
					}
				}
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 END
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 START
				//ＴＥＣ製サーマルプリンタ（B-EV4）
				if(sPrinter.IndexOf("B-EV4-G-Fukuyama") >= 0 || sPrinter.IndexOf("b-ev4-g-fukuyama") >= 0)
				{
					pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
					if(pdサーマルプリンタ.PrinterSettings.IsValid)
					{
						sプリンタ種類 = "S0007";
						break;
					}
				}
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 END
// MOD 2015.02.12 BEVAS）前田 ＴＥＣ製プリンタ(B-LV4)対応 START
				//ＴＥＣ製サーマルプリンタ（B-LV4）
				if(sPrinter.IndexOf("B-LV4-G-Fukuyama") >= 0 || sPrinter.IndexOf("b-lv4-g-fukuyama") >= 0)
				{
					pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
					if(pdサーマルプリンタ.PrinterSettings.IsValid)
					{
						sプリンタ種類 = "S0008";
						break;
					}
				}
// MOD 2015.02.12 BEVAS）前田 ＴＥＣ製プリンタ(B-LV4)対応 END

				//ＳＡＴＯ製サーマルプリンタ（ＵＳＢ）
				if(sPrinter.IndexOf("ﾚｽﾌﾟﾘβ") >= 0)
				{
					pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
					if(pdサーマルプリンタ.PrinterSettings.IsValid)
					{
						sプリンタ種類 = "S0002";
						break;
					}
				}

				//ＺＥＢＲＡ製サーマルプリンタ（ＵＳＢ）
				if(sPrinter.IndexOf("LP2844") >= 0)
				{
					pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
					if(pdサーマルプリンタ.PrinterSettings.IsValid)
					{
						sプリンタ種類 = "S0001";
					}
				}

			}

			// ローカル接続のプリンタが存在しない場合
			// ネットワークの共有プリンタを検索する
			if(iCnt == PrinterSettings.InstalledPrinters.Count)
			{
				// ネットワーク共有プリンタ[ZebraLP2]の検索
				for(iCnt = 0; iCnt < PrinterSettings.InstalledPrinters.Count; iCnt++)
				{
					sPrinter = PrinterSettings.InstalledPrinters[iCnt];
//保留 ADD 2008.06.12 東都）高木 ＴＥＣ製プリンタ対応 START
//					//ＴＥＣ製サーマルプリンタ（ＵＳＢ）
//					if(sPrinter.IndexOf("TECB-SV4") >= 0)
//					{
//						pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
//						if(pdサーマルプリンタ.PrinterSettings.IsValid)
//						{
//							sプリンタ種類 = "S0003";
//							break;
//						}
//					}
//保留 ADD 2008.06.12 東都）高木 ＴＥＣ製プリンタ対応 END

// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 START
					//ＳＡＴＯ製サーマルプリンタ（CS408T）
// MOD 2013.10.22 BEVAS）高杉 ＳＡＴＯ製プリンタ(CS408T)プリンタ名小文字対応 START
//					if(sPrinter.IndexOf("SATOCS40") >= 0)
					if(sPrinter.IndexOf("SATOCS40") >= 0 || sPrinter.IndexOf("satocs40") >= 0)
// MOD 2013.10.22 BEVAS）高杉 ＳＡＴＯ製プリンタ(CS408T)プリンタ名小文字対応 END
					{
						pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
						if(pdサーマルプリンタ.PrinterSettings.IsValid)
						{
							sプリンタ種類 = "S0005";
							break;
						}
					}
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 END

// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 START
					//ＳＡＴＯ製サーマルプリンタ（CS408T）
					// MOD 2013.04.11 TDI）綱澤 プリンタ名小文字対応 START
					//if(sPrinter.IndexOf("SATOCF40") >= 0)
					if(sPrinter.IndexOf("SATOCF40") >= 0 || sPrinter.IndexOf("satocf40") >= 0)
					// MOD 2013.04.11 TDI）綱澤 プリンタ名小文字対応 END 
					{
						pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
						if(pdサーマルプリンタ.PrinterSettings.IsValid)
						{
							sプリンタ種類 = "S0006";
							break;
						}
					}
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 END
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 START
					//ＴＥＣ製サーマルプリンタ（B-EV4）
					if(sPrinter.IndexOf("TECB-EV4") >= 0 || sPrinter.IndexOf("tecb-ev4") >= 0)
					{
						pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
						if(pdサーマルプリンタ.PrinterSettings.IsValid)
						{
							sプリンタ種類 = "S0007";
							break;
						}
					}
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 END
// MOD 2015.02.12 BEVAS）前田 ＴＥＣ製プリンタ(B-LV4)対応 START
					//ＴＥＣ製サーマルプリンタ（B-LV4）
					if(sPrinter.IndexOf("TECB-LV4") >= 0 || sPrinter.IndexOf("tecb-lv4") >= 0 
						|| sPrinter.IndexOf("TEC B-LV4") >= 0 || sPrinter.IndexOf("tec b-lv4") >= 0)
					{
						pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
						if(pdサーマルプリンタ.PrinterSettings.IsValid)
						{
							sプリンタ種類 = "S0008";
							break;
						} 
					}
// MOD 2015.02.12 BEVAS）前田 ＴＥＣ製プリンタ(B-LV4)対応 END

					//ＳＡＴＯ製サーマルプリンタ（ＵＳＢ）
					if(sPrinter.IndexOf("SATOﾚｽﾌﾟ") >= 0)
					{
						pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
						if(pdサーマルプリンタ.PrinterSettings.IsValid)
						{
							sプリンタ種類 = "S0002";
							break;
						}
					}

					//ＺＥＢＲＡ製サーマルプリンタ（ＵＳＢ）
					if(sPrinter.IndexOf("ZebraLP2") >= 0)
					{
						pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
						if(pdサーマルプリンタ.PrinterSettings.IsValid)
						{
							sプリンタ種類 = "S0001";
						}
					}
				}
			}
//			if(iCnt == PrinterSettings.InstalledPrinters.Count)
			if(sプリンタ種類.Length == 0)
				throw new Exception("プリンタが使用できません。");

			return sプリンタ種類;
		}
// ADD 2006.10.10 東都）高木 ＳＡＴＯ製プリンタ障害対応 END

// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//		protected static void プリンタチェック()
		protected void プリンタチェック()
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
		{
// ADD 2006.07.19 東都）高木 ＴＥＣ製プリンタ対応 START
			プリンタチェック(gsプリンタ種類);
		}

// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 START
//// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
////		protected static void プリンタチェック(string gsプリンタ種類)
//		protected void プリンタチェック(string gsプリンタ種類)
//// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
//		{
//// ADD 2006.08.10 東都）高木 ＩＣタグ対応ＳＡＴＯ製プリンタ対応 START
//			if(gsプリンタ種類 == "S0004") return;
//// ADD 2006.08.10 東都）高木 ＩＣタグ対応ＳＡＴＯ製プリンタ対応 END
		protected string プリンタチェック(string gsプリンタ種類)
		{
			string sRtnプリンタ種類 = gsプリンタ種類;
			if(gsプリンタ種類 == "S0004"){
				return sRtnプリンタ種類;
			}
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 END

// ADD 2006.07.19 東都）高木 ＴＥＣ製プリンタ対応 END

			//プリンタの取得
// MOD 2006.06.20 東都）高木 ＳＡＴＯ製プリンタ対応 START
//			pdサーマルプリンタ.PrinterSettings.PrinterName = "Zebra  LP2844";
			if(gsプリンタ種類 == "S0002")
			{
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 START
//				//ＳＡＴＯ製サーマルプリンタ（ＵＳＢ）
//				pdサーマルプリンタ.PrinterSettings.PrinterName = "SATO ﾚｽﾌﾟﾘβ";
				//ＳＡＴＯ製サーマルプリンタ（CS408T）
				pdサーマルプリンタ.PrinterSettings.PrinterName = "SATO CS408T";
				if(pdサーマルプリンタ.PrinterSettings.IsValid == true){
					sRtnプリンタ種類 = "S0005";
				}
				else{
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 START
//					//ＳＡＴＯ製サーマルプリンタ（ＵＳＢ）
					pdサーマルプリンタ.PrinterSettings.PrinterName = "SATO CF408T";
					if(pdサーマルプリンタ.PrinterSettings.IsValid == true)
					{
						sRtnプリンタ種類 = "S0006";
					}
					else
					{
						pdサーマルプリンタ.PrinterSettings.PrinterName = "SATO ﾚｽﾌﾟﾘβ";
					}
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 END
				}
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 END
			}
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 START
			else if(gsプリンタ種類 == "S0005")
			{
				//ＳＡＴＯ製サーマルプリンタ（CS408T）
				pdサーマルプリンタ.PrinterSettings.PrinterName = "SATO CS408T";
			}
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 END
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 START
			else if(gsプリンタ種類 == "S0006")
			{
				//ＳＡＴＯ製サーマルプリンタ（CF408T）
				pdサーマルプリンタ.PrinterSettings.PrinterName = "SATO CF408T";
			}
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 END
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 START
			else if(gsプリンタ種類 == "S0007")
			{
// MOD 2015.02.12 BEVAS）前田 ＴＥＣ製プリンタ(B-LV4)対応 START
				//ＴＥＣ製サーマルプリンタ（B-EV4）あるいはB-LV4のどちらかを判定
				pdサーマルプリンタ.PrinterSettings.PrinterName = "TEC B-LV4-G-Fukuyama";
				if(pdサーマルプリンタ.PrinterSettings.IsValid == true)
				{
					sRtnプリンタ種類 = "S0008"; // TEC製B-LV4として認識する
				}
				else
				{
					//ＴＥＣ製サーマルプリンタ（B-EV4）
					pdサーマルプリンタ.PrinterSettings.PrinterName = "TEC B-EV4-G-Fukuyama";
				}


				////ＴＥＣ製サーマルプリンタ（B-EV4）
				//pdサーマルプリンタ.PrinterSettings.PrinterName = "TEC B-EV4-G-Fukuyama";
// MOD 2015.02.12 BEVAS）前田 ＴＥＣ製プリンタ(B-LV4)対応 END
			}
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 END

//保留 ADD 2008.06.12 東都）高木 ＴＥＣ製プリンタ対応 START
//			else if(gsプリンタ種類 == "S0003")
//			{
//				//ＴＥＣ製サーマルプリンタ（ＵＳＢ）
//				pdサーマルプリンタ.PrinterSettings.PrinterName = "TEC B-SV4-JP";
//			}
//保留 ADD 2008.06.12 東都）高木 ＴＥＣ製プリンタ対応 END  
			else
			{
				//ＺＥＢＲＡ製サーマルプリンタ（ＵＳＢ）
				pdサーマルプリンタ.PrinterSettings.PrinterName = "Zebra  LP2844";
			}
// MOD 2006.06.20 東都）高木 ＳＡＴＯ製プリンタ対応 END
			if (pdサーマルプリンタ.PrinterSettings.IsValid == false)
			{
// MOD 2005.06.13 東都）高木 プリンタチェックの拡張 START
//				throw new Exception("プリンタが使用できません。");
				string sPrinter = "";
				int iCnt = 0;
				// プリンタ[LP2844]の検索
				for(iCnt = 0; iCnt < PrinterSettings.InstalledPrinters.Count; iCnt++)
				{
					sPrinter = PrinterSettings.InstalledPrinters[iCnt];
// ADD 2006.06.20 東都）高木 ＳＡＴＯ製プリンタ対応 START
					if(gsプリンタ種類 == "S0002")
					{
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 START
						//ＳＡＴＯ製サーマルプリンタ（ＵＳＢ）
// MOD 2013.10.22 BEVAS）高杉 ＳＡＴＯ製プリンタ(CS408T)プリンタ名小文字対応
//						if(sPrinter.IndexOf("CS408T") >= 0)
						if(sPrinter.IndexOf("CS408T") >= 0 || sPrinter.IndexOf("cs408t") >= 0)
// MOD 2013.10.22 BEVAS）高杉 ＳＡＴＯ製プリンタ(CS408T)プリンタ名小文字対応
						{
							pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
							if(pdサーマルプリンタ.PrinterSettings.IsValid)
							{
								sRtnプリンタ種類 = "S0005";
								break;
							}
						}
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 END
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 START
						//ＳＡＴＯ製サーマルプリンタ（ＵＳＢ）
						// MOD 2013.04.11 TDI）綱澤 プリンタ名小文字対応 START
						//if(sPrinter.IndexOf("CF408T") >= 0)
						if(sPrinter.IndexOf("CF408T") >= 0 || sPrinter.IndexOf("cf408t") >= 0)
						// MOD 2013.04.11 TDI）綱澤 プリンタ名小文字対応 END
						{
							pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
							if(pdサーマルプリンタ.PrinterSettings.IsValid)
							{
								sRtnプリンタ種類 = "S0006";
								break;
							}
						}
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 END


						//ＳＡＴＯ製サーマルプリンタ（ＵＳＢ）
						if(sPrinter.IndexOf("ﾚｽﾌﾟﾘβ") >= 0)
						{
							pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
							if(pdサーマルプリンタ.PrinterSettings.IsValid) break;
						}
						continue;
					}
// ADD 2006.06.20 東都）高木 ＳＡＴＯ製プリンタ対応 END
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 START
					else if(gsプリンタ種類 == "S0005")
					{
						//ＳＡＴＯ製サーマルプリンタ（CS408T）
// MOD 2013.10.22 BEVAS）高杉 ＳＡＴＯ製プリンタ(CS408T)プリンタ名小文字対応 START
//						if(sPrinter.IndexOf("CS408T") >= 0)
						if(sPrinter.IndexOf("CS408T") >= 0 || sPrinter.IndexOf("cs408t") >= 0)
// MOD 2013.10.22 BEVAS）高杉 ＳＡＴＯ製プリンタ(CS408T)プリンタ名小文字対応 END
						{
							pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
							if(pdサーマルプリンタ.PrinterSettings.IsValid) break;
						}
						continue;
					}
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 END
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 START
					else if(gsプリンタ種類 == "S0006")
					{
						//ＳＡＴＯ製サーマルプリンタ（CF408T）
						// MOD 2013.04.11 TDI）綱澤 プリンタ名小文字対応 START
						//if(sPrinter.IndexOf("CF408T") >= 0)
						if(sPrinter.IndexOf("CF408T") >= 0 || sPrinter.IndexOf("cf408t") >= 0)
						// MOD 2013.04.11 TDI）綱澤 プリンタ名小文字対応 END
						{
							pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
							if(pdサーマルプリンタ.PrinterSettings.IsValid) break;
						}
						continue;
					}
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 END
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 START
					else if(gsプリンタ種類 == "S0007")
					{
						//ＴＥＣ製サーマルプリンタ（B-EV4-G）
						if(sPrinter.IndexOf("B-EV4-G-Fukuyama") >= 0 || sPrinter.IndexOf("b-ev4-g-fukuyama") >= 0)
						{
							pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
							if(pdサーマルプリンタ.PrinterSettings.IsValid) break;
						}
						continue;
					}
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 END
// MOD 2015.02.12 BEVAS）前田 ＴＥＣ製プリンタ(B-LV4)対応 START
					else if(gsプリンタ種類 == "S0008")
					{
						//ＴＥＣ製サーマルプリンタ（B-LV4-G）
						if(sPrinter.IndexOf("B-LV4-G-Fukuyama") >= 0 || sPrinter.IndexOf("b-lv4-g-fukuyama") >= 0)
						{
							pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
							if(pdサーマルプリンタ.PrinterSettings.IsValid) break;
						}
						continue;
					}
// MOD 2015.02.12 BEVAS）前田 ＴＥＣ製プリンタ(B-LV4)対応 END
//保留 ADD 2008.06.12 東都）高木 ＴＥＣ製プリンタ対応 START
//					else if(gsプリンタ種類 == "S0003")
//					{
//						//ＴＥＣ製サーマルプリンタ（ＵＳＢ）
//						if(sPrinter.IndexOf("B-SV4-JP") >= 0)
//						{
//							pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
//							if(pdサーマルプリンタ.PrinterSettings.IsValid) break;
//						}
//						continue;
//					}
//保留 ADD 2008.06.12 東都）高木 ＴＥＣ製プリンタ対応 END
// ADD 2006.10.10 東都）高木 ＳＡＴＯ製プリンタ障害対応 START
// MOD 2006.10.13 東都）高木 ＳＡＴＯ製プリンタ障害対応 START
//					else if(gsプリンタ種類 == "S0001")
					else
// MOD 2006.10.13 東都）高木 ＳＡＴＯ製プリンタ障害対応 END
					{
// ADD 2006.10.10 東都）高木 ＳＡＴＯ製プリンタ障害対応 END
						//ＺＥＢＲＡ製サーマルプリンタ（ＵＳＢ）
						if(sPrinter.IndexOf("LP2844") >= 0)
						{
							pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
							if(pdサーマルプリンタ.PrinterSettings.IsValid) break;
						}
// ADD 2006.10.10 東都）高木 ＳＡＴＯ製プリンタ障害対応 START
					}
// ADD 2006.10.10 東都）高木 ＳＡＴＯ製プリンタ障害対応 END
				}

				// ローカル接続のプリンタが存在しない場合
				// ネットワークの共有プリンタを検索する
				if(iCnt == PrinterSettings.InstalledPrinters.Count)
				{
					// ネットワーク共有プリンタ[ZebraLP2]の検索
					for(iCnt = 0; iCnt < PrinterSettings.InstalledPrinters.Count; iCnt++)
					{
						sPrinter = PrinterSettings.InstalledPrinters[iCnt];
// ADD 2006.10.10 東都）高木 ＳＡＴＯ製プリンタ障害対応 START
						//ＳＡＴＯ製サーマルプリンタ（ＵＳＢ）
						if(gsプリンタ種類 == "S0002")
						{
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 START
// MOD 2013.10.22 BEVAS）高杉 ＳＡＴＯ製プリンタ(CS408T)プリンタ名小文字対応 START
//							if(sPrinter.IndexOf("SATOCS40") >= 0)
							if(sPrinter.IndexOf("SATOCS40") >= 0 || sPrinter.IndexOf("satocs40") >= 0)
// MOD 2013.10.22 BEVAS）高杉 ＳＡＴＯ製プリンタ(CS408T)プリンタ名小文字対応 END
							{
								pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
								if(pdサーマルプリンタ.PrinterSettings.IsValid)
								{
									sRtnプリンタ種類 = "S0005";
									break;
								}
							}
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 END
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 START
							// MOD 2013.04.11 TDI）綱澤 プリンタ名小文字対応 START
							//if(sPrinter.IndexOf("SATOCF40") >= 0)
							if(sPrinter.IndexOf("SATOCF40") >= 0 || sPrinter.IndexOf("satocf40") >= 0)
							// MOD 2013.04.11 TDI）綱澤 プリンタ名小文字対応 END
							{
								pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
								if(pdサーマルプリンタ.PrinterSettings.IsValid)
								{
									sRtnプリンタ種類 = "S0006";
									break;
								}
							}
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 END

							if(sPrinter.IndexOf("SATOﾚｽﾌﾟ") >= 0)
							{
								pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
								if(pdサーマルプリンタ.PrinterSettings.IsValid) break;
							}
							continue;
						}
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 START
						//ＳＡＴＯ製サーマルプリンタ（CS408T）
						else if(gsプリンタ種類 == "S0005")
						{
// MOD 2013.10.22 BEVAS）高杉 ＳＡＴＯ製プリンタ(CS408T)プリンタ名小文字対応 START
//							if(sPrinter.IndexOf("SATOCS40") >= 0)
							if(sPrinter.IndexOf("SATOCS40") >= 0 || sPrinter.IndexOf("satocs40") >= 0)
// MOD 2013.10.22 BEVAS）高杉 ＳＡＴＯ製プリンタ(CS408T)プリンタ名小文字対応 END
							{
								pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
								if(pdサーマルプリンタ.PrinterSettings.IsValid) break;
							}
							continue;
						}
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 END
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 START
						//ＳＡＴＯ製サーマルプリンタ（CF408T）
						else if(gsプリンタ種類 == "S0006")
						{
							// MOD 2013.04.11 TDI）綱澤 プリンタ名小文字対応 START
							//if(sPrinter.IndexOf("SATOCF40") >= 0)
							if(sPrinter.IndexOf("SATOCF40") >= 0 || sPrinter.IndexOf("satocf40") >= 0)
							// MOD 2013.04.11 TDI）綱澤 プリンタ名小文字対応 END
							{
								pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
								if(pdサーマルプリンタ.PrinterSettings.IsValid) break;
							}
							continue;
						}
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 END
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 START
						else if(gsプリンタ種類 == "S0007")
						{
							//ＴＥＣ製サーマルプリンタ（B-EV4）
							if(sPrinter.IndexOf("B-EV4-G-Fukuyama") >= 0 || sPrinter.IndexOf("b-ev4-g-fukuyama") >= 0)
							{
								pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
								if(pdサーマルプリンタ.PrinterSettings.IsValid) break;
							} 
// ADD 2015.02.12 BEVAS）前田 ＴＥＣ製プリンタ(B-LV4)対応 START
							//ＴＥＣ製サーマルプリンタ（B-LV4）
							else if(sPrinter.IndexOf("B-LV4-G-Fukuyama") >= 0 || sPrinter.IndexOf("b-lv4-g-fukuyama") >= 0)
							{
								pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
								if(pdサーマルプリンタ.PrinterSettings.IsValid) 
								{
									gsプリンタ種類 = "S0008";
									break;
								}
							}
// ADD 2015.02.12 BEVAS）前田 ＴＥＣ製プリンタ(B-LV4)対応 END
							continue;
						}
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 END
//保留 ADD 2008.06.12 東都）高木 ＴＥＣ製プリンタ対応 START
//						else if(gsプリンタ種類 == "S0003")
//						{
//							//ＴＥＣ製サーマルプリンタ（ＵＳＢ）
//							if(sPrinter.IndexOf("TECB-SV4") >= 0)
//							{
//								pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
//								if(pdサーマルプリンタ.PrinterSettings.IsValid) break;
//							}
//							continue;
//						}
//保留 ADD 2008.06.12 東都）高木 ＴＥＣ製プリンタ対応 END
// MOD 2006.10.13 東都）高木 ＳＡＴＯ製プリンタ障害対応 START
//						else if(gsプリンタ種類 == "S0001")
						else
// MOD 2006.10.13 東都）高木 ＳＡＴＯ製プリンタ障害対応 END
						{
// ADD 2006.10.10 東都）高木 ＳＡＴＯ製プリンタ障害対応 END
							if(sPrinter.IndexOf("ZebraLP2") >= 0)
							{
								pdサーマルプリンタ.PrinterSettings.PrinterName = sPrinter;
								if(pdサーマルプリンタ.PrinterSettings.IsValid) break;
							}
// ADD 2006.10.10 東都）高木 ＳＡＴＯ製プリンタ障害対応 END
						}
// ADD 2006.10.10 東都）高木 ＳＡＴＯ製プリンタ障害対応 END
					}
				}
				if(iCnt == PrinterSettings.InstalledPrinters.Count) 
					throw new Exception("プリンタが使用できません。");
// MOD 2005.06.13 東都）高木 プリンタチェックの拡張 END
			}

//保留 DEL 2009.02.06 東都）高木 ラベル用紙サイズ定義チェックの廃止 START
// ADD 2006.10.10 東都）高木 ＳＡＴＯ製プリンタ障害対応 START
			//用紙サイズのチェックは、ＺＥＢＲＡの時以外は行わない。
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 START
//			if(gsプリンタ種類 != "S0001") return;
			if(gsプリンタ種類 != "S0001"){
				return sRtnプリンタ種類;
			}
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 END
// ADD 2006.10.10 東都）高木 ＳＡＴＯ製プリンタ障害対応 END

			//用紙サイズのチェック
			if (pdサーマルプリンタ.DefaultPageSettings.PaperSize.Width != 425 
				|| pdサーマルプリンタ.DefaultPageSettings.PaperSize.Height != 651)
			{
				throw new Exception("用紙サイズが違います。\r\n横10.80cm 縦16.54cmに設定してください。");
			}
//保留 DEL 2009.02.06 東都）高木 ラベル用紙サイズ定義チェックの廃止 END
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 START
			return sRtnプリンタ種類;
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 END
		}

// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 START
//// ADD 2007.03.28 東都）高木 集荷店取得エラー対応 START
//		protected static void 利用者部門店所取得()
//		{
//			try
//			{
//				// 利用者情報取得の取得（利用者名、部門情報、請求先情報）
//				if(sv_init == null) sv_init = new is2init.Service1();
//				String[] sRet = sv_init.Get_hatuten3(gsaユーザ,gs会員ＣＤ,gs利用者部門ＣＤ);
//				if(sRet[0].Length != 4)
//				{
//					ビープ音();
//					MessageBox.Show(sRet[0],
//						"利用者集荷店取得", 
//						MessageBoxButtons.OK, MessageBoxIcon.Error);
//					return;
//				}
//
//				gs利用者部門店所     = sRet[1];
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
//// ADD 2007.03.28 東都）高木 集荷店取得エラー対応 END
		protected static string 部門店所取得(string s部門ＣＤ)
		{
			try{
				// 部門店所の取得
				if(sv_init == null) sv_init = new is2init.Service1();
// ADD 2010.12.14 ACT）垣原 王子運送の対応 START
//				String[] sRet = sv_init.Get_hatuten3(gsaユーザ, gs会員ＣＤ, s部門ＣＤ);
				if(sv_oji == null) sv_oji = new is2oji.Service1();
				String[] sRet;
				if (gs会員ＣＤ.Substring(0,1) != "J")
				{
					sRet = sv_init.Get_hatuten3(gsaユーザ, gs会員ＣＤ, s部門ＣＤ);

				}
				else
				{
					sRet = sv_oji.Get_hatuten3(gsaユーザ, gs会員ＣＤ, s部門ＣＤ);
				}
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END

				if(sRet[0].Length != 4)
				{
					ビープ音();
					MessageBox.Show(sRet[0],
						"集荷店取得", 
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}else{
					return sRet[1];
				}
			}catch(System.Net.WebException){
				ビープ音();
				MessageBox.Show(gs通信エラー, 
					"通信エラー", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}catch(Exception ex){
				ビープ音();
				MessageBox.Show(ex.Message, 
					"通信エラー", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return "";
		}
// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 END

// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//		protected static void 送り状印刷指示(string[] sData)
		protected void 送り状印刷指示(string[] sData)
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
// ADD 2008.03.19 東都）高木 個別再発行機能の追加 START
		{
			送り状印刷指示(sData, 1, 99);
		}
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//		protected static void 送り状印刷指示(string[] sData, int i開始, int i終了)
		protected void 送り状印刷指示(string[] sData, int i開始, int i終了)
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
// ADD 2008.03.19 東都）高木 個別再発行機能の追加 END
		{
			gb印刷 = true;
			try
			{
				if(sv_print == null) sv_print = new is2print.Service1();

				//印刷データの作成
// MOD 2011.03.25 東都）高木 送り状番号の上書き防止 START
//				String[] sPrintKey = new string[4];
//				sPrintKey[0] = gs会員ＣＤ;
//				sPrintKey[1] = gs部門ＣＤ;
//				sPrintKey[2] = sData[0];
//				sPrintKey[3] = sData[1];
				//ログイン時に担当集荷店ＣＤが取得されていない場合には、
				if(gs利用者部門店所ＣＤ == null || gs利用者部門店所ＣＤ.Length == 0){
					gs利用者部門店所ＣＤ = "";
					gs利用者部門店所ＣＤ = 部門店所取得(gs利用者部門ＣＤ);
				}
				string[] sPrintKey = new string[]{
					gs会員ＣＤ
					, gs部門ＣＤ
					, sData[0]
					, sData[1]
					, gs利用者部門店所ＣＤ
				};
// MOD 2011.03.25 東都）高木 送り状番号の上書き防止 END
				
// ADD 2010.12.14 ACT）垣原 王子運送の対応 START
//				String[] sPrintData = sv_print.Get_InvoicePrintData(gsaユーザ,sPrintKey);
				if(sv_oji == null) sv_oji = new is2oji.Service1();
				String[] sPrintData;
				if (gs会員ＣＤ.Substring(0,1) != "J")
				{
					sPrintData = sv_print.Get_InvoicePrintData(gsaユーザ,sPrintKey);
				}
				else
				{
					sPrintData = sv_oji.Get_InvoicePrintData(gsaユーザ,sPrintKey);
				}
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END
				
				if (!sPrintData[0].Equals("正常終了"))
				{
					throw new Exception(sPrintData[0]);
				}
// ADD 2007.03.28 東都）高木 集荷店取得エラー対応 START
				//ログイン時に担当集荷店ＣＤが取得されていない場合には、
				if(gs利用者部門店所ＣＤ == null || gs利用者部門店所ＣＤ.Length == 0)
				{
// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 START
//					利用者部門店所取得();
					gs利用者部門店所ＣＤ = 部門店所取得(gs利用者部門ＣＤ);
// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 END
				}
				//担当集荷店ＣＤが取得できない場合には、スルーさせる
				if(gs利用者部門店所ＣＤ == null || gs利用者部門店所ＣＤ.Length == 0)
				{
//					gb印刷 = false;
//					throw new Exception("担当店所情報の取得に失敗しました");
				}else{
// ADD 2007.03.28 東都）高木 集荷店取得エラー対応 END
// ADD 2006.12.12 東都）小童谷 店所と部門店所が異なる場合は、印刷しない START
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 START
//					if(!gs利用者部門店所ＣＤ.Trim().Equals(sPrintData[14].Trim().Substring(1, 3)))
//					{
//						gb印刷 = false;
//						return;
//					}
					//社内伝の場合は、店所と部門店所が異なってもよい
					if(!gs利用者部門店所ＣＤ.Equals("044"))
					{
						if(!gs利用者部門店所ＣＤ.Trim().Equals(sPrintData[14].Trim().Substring(1, 3)))
						{
							gb印刷 = false;
							return;
						}
					}
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 END
// ADD 2006.12.12 東都）小童谷 店所と部門店所が異なる場合は、印刷しない END
// ADD 2007.03.28 東都）高木 集荷店取得エラー対応 START
				}
// ADD 2007.03.28 東都）高木 集荷店取得エラー対応 END
				//送り状発行のチェック
				if (!sPrintData[33].Equals("1")) // 送り状発行済ＦＧ
				{
					//送り状が未発行の場合。送り状番号の採番
					String[] sGetKey = new string[4];
					sGetKey[0] = gs会員ＣＤ;
					sGetKey[1] = gs部門ＣＤ;
// MOD 2005.06.07 東都）伊賀 輸送商品によって値を変更 START
//					sGetKey[2] = sPrintData[32] + "0";	//元着区分 + "0"
					sGetKey[2] = sPrintData[32]; //元着区分 + "0" or "1"
// MOD 2005.06.07 東都）伊賀 輸送商品によって値を変更 END
// ADD 2007.10.17 東都）高木 グローバル対応（出荷日、発店の非表示） START
					if(sPrintData[14].Substring(1, 3) == "047"){
						sGetKey[2] = sPrintData[32].Substring(0,1) + "G"; //元着区分 + "G"
					}
// ADD 2007.10.17 東都）高木 グローバル対応（出荷日、発店の非表示） END
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 START
					if(gs利用者部門店所ＣＤ.Equals("044"))
					{
						sGetKey[2] = sPrintData[32].Substring(0,1) + "F"; //元着区分 + "F"
					}
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 END
					sGetKey[3] = gs利用者ＣＤ;
// ADD 2005.05.13 東都）小童谷 未発行で出荷日が過去のものは出荷日を当日にする START

// MOD 2010.11.01 東都）高木 出荷済の場合、出荷日未更新 START
					string s出荷済ＦＧ = (sPrintData.Length >= 40 ? sPrintData[39] : "0");
					if(s出荷済ＦＧ.Equals("0")){
// MOD 2010.11.01 東都）高木 出荷済の場合、出荷日未更新 END
// MOD 2005.07.08 東都）高木 日付変換の変更 START
//						string s当日 = DateTime.Today.ToShortDateString().Replace("/","");
						string s当日 = YYYYMMDD変換(DateTime.Today);
// MOD 2005.07.08 東都）高木 日付変換の変更 END
						if(int.Parse(sPrintData[10]) < int.Parse(s当日))
// MOD 2005.06.10 東都）小童谷 出荷日の更新 START
//							sPrintData[10] = s当日;
						{
							sPrintData[10] = s当日;

							String[] sKeyData = new string[7];
							sKeyData[0] = gs会員ＣＤ;
							sKeyData[1] = gs部門ＣＤ;
							sKeyData[2] = sData[0];
							sKeyData[3] = sData[1];
							sKeyData[4] = s当日;
							sKeyData[5] = "共通フォ";
							sKeyData[6] = gs利用者ＣＤ;
							if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
							String[] sSyuData = sv_syukka.Upd_syukkabi(gsaユーザ,sKeyData);
							if (!sSyuData[0].Equals("正常終了"))
							{
								throw new Exception(sSyuData[0]);
							}

						}
// MOD 2005.06.10 東都）小童谷 出荷日の更新 END
// ADD 2005.05.13 東都）小童谷 未発行で出荷日が過去のものは出荷日を当日にする END
// MOD 2010.11.01 東都）高木 出荷済の場合、出荷日未更新 START
					}
// MOD 2010.11.01 東都）高木 出荷済の場合、出荷日未更新 END

					// 送り状ＮＯが登録されていない場合
					if (sPrintData[11].Length == 0) // 送り状番号
					{
						if(sv_print == null) sv_print = new is2print.Service1();
						String[] sGetData = sv_print.Get_InvoiceNo(gsaユーザ,sGetKey);
						if (!sGetData[0].Equals("正常終了"))
						{
							throw new Exception(sGetData[0]);
						}
						//送り状番号のセット
						sPrintData[11] = sGetData[1].PadLeft(14, '0');
						//チェックデジット（７で割った余り）の付加
//						sPrintData[11] = sPrintData[11] + (int.Parse(sPrintData[11]) % 7).ToString();
						sPrintData[11] = sPrintData[11] + (long.Parse(sPrintData[11]) % 7).ToString();
					}

					//送り状番号更新
					//（送り状番号、送り状発行済ＦＧ、状態、発店の更新）
					String[] sSetKey = new string[6];
					sSetKey[0] = gs会員ＣＤ;
					sSetKey[1] = gs部門ＣＤ;
					sSetKey[2] = sData[0];       // 登録日
					sSetKey[3] = sData[1];       // ジャーナルＮＯ
					sSetKey[4] = sPrintData[11]; // 送り状番号
					sSetKey[5] = gs利用者ＣＤ;

					if(sv_print == null) sv_print = new is2print.Service1();
// ADD 2010.12.14 ACT）垣原 王子運送の対応 START
//					String[] sSetData = sv_print.Set_InvoiceNo(gsaユーザ,sSetKey);
					if(sv_oji == null) sv_oji = new is2oji.Service1();
					String[] sSetData;
					if (gs会員ＣＤ.Substring(0,1) != "J")
					{
						sSetData = sv_print.Set_InvoiceNo(gsaユーザ,sSetKey);

					}
					else
					{
						sSetData = sv_oji.Set_InvoiceNo(gsaユーザ,sSetKey);
					}
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END

					
					if (!sSetData[0].Equals("正常終了"))
					{
						throw new Exception(sSetData[0]);
					}
				}

// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
				if(gsオプション[18].Equals("1"))
				{
					sPrintData[5] = sPrintData[5].TrimEnd(); // 荷受人住所１
					sPrintData[6] = sPrintData[6].TrimEnd(); // 荷受人住所２
					sPrintData[7] = sPrintData[7].TrimEnd(); // 荷受人住所３
					sPrintData[8] = sPrintData[8].TrimEnd(); // 荷受人名前１
					sPrintData[9] = sPrintData[9].TrimEnd(); // 荷受人名前２

					sPrintData[18] = sPrintData[18].TrimEnd(); // 荷送人住所１
					sPrintData[19] = sPrintData[19].TrimEnd(); // 荷送人住所２
					sPrintData[21] = sPrintData[21].TrimEnd(); // 荷送人名前１
					sPrintData[22] = sPrintData[22].TrimEnd(); // 荷送人名前２
					sPrintData[34] = sPrintData[34].TrimEnd(); // 担当者
					
					sPrintData[29] = sPrintData[29].TrimEnd(); // 品名記事１
					sPrintData[30] = sPrintData[30].TrimEnd(); // 品名記事２
					sPrintData[31] = sPrintData[31].TrimEnd(); // 品名記事３
// MOD 2011.07.14 東都）高木 記事行の追加 START
					if(sPrintData.Length > 42){
						sPrintData[42] = sPrintData[42].TrimEnd(); // 品名記事４
						sPrintData[43] = sPrintData[43].TrimEnd(); // 品名記事５
						sPrintData[44] = sPrintData[44].TrimEnd(); // 品名記事６
					}
// MOD 2011.07.14 東都）高木 記事行の追加 END
				}else{
					sPrintData[5] = sPrintData[5].Trim(); // 荷受人住所１
					sPrintData[6] = sPrintData[6].Trim(); // 荷受人住所２
					sPrintData[7] = sPrintData[7].Trim(); // 荷受人住所３
					sPrintData[8] = sPrintData[8].Trim(); // 荷受人名前１
					sPrintData[9] = sPrintData[9].Trim(); // 荷受人名前２

					sPrintData[18] = sPrintData[18].Trim(); // 荷送人住所１
					sPrintData[19] = sPrintData[19].Trim(); // 荷送人住所２
					sPrintData[21] = sPrintData[21].Trim(); // 荷送人名前１
					sPrintData[22] = sPrintData[22].Trim(); // 荷送人名前２
					sPrintData[34] = sPrintData[34].Trim(); // 担当者
					
					sPrintData[29] = sPrintData[29].Trim(); // 品名記事１
					sPrintData[30] = sPrintData[30].Trim(); // 品名記事２
					sPrintData[31] = sPrintData[31].Trim(); // 品名記事３
// MOD 2011.07.14 東都）高木 記事行の追加 START
					if(sPrintData.Length > 42){
						sPrintData[42] = sPrintData[42].Trim(); // 品名記事４
						sPrintData[43] = sPrintData[43].Trim(); // 品名記事５
						sPrintData[44] = sPrintData[44].Trim(); // 品名記事６
					}
// MOD 2011.07.14 東都）高木 記事行の追加 END
				}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END

// ADD 2006.08.10 東都）高木 ＩＣタグ対応ＳＡＴＯ製プリンタ対応 START
				if(gsプリンタ種類 == "S0004"){
					string sパス名 = "C:\\";
					string sファイル名 = "荷物データファイル.csv";
					try
					{
						System.IO.FileStream fs = new FileStream(sパス名 + sファイル名, 
							FileMode.Append, FileAccess.Write,FileShare.Read);
						try
						{
							string sCSVData = "";
							for (int iCnt = 0; iCnt < int.Parse(sPrintData[23]); iCnt++)
							{
								int    i連番 = iCnt + 1;
								string s連番 = i連番.ToString();
								string s荷物番号 = sPrintData[11].Substring(4) + s連番.PadLeft(2, '0');

								//荷物番号
								sCSVData = s荷物番号;
								荷物データ出力(fs, sCSVData, false);
								//荷受人電話番号
								sCSVData = "(" + sPrintData[2] + ")" + sPrintData[3] + "-" + sPrintData[4];
// MOD 2010.03.17 東都）高木 荷受人電話番号がALL0であれば非表示 START
// MOD 2010.03.30 東都）高木 荷受人電話番号が0であれば非表示 START
//								if(sPrintData[2] == "000000"
//								&& sPrintData[3] == "0000"
//								&& sPrintData[4] == "0000"){
								if(sPrintData[2].Replace("0","").Trim().Length == 0
								&& sPrintData[3].Replace("0","").Trim().Length == 0
								&& sPrintData[4].Replace("0","").Trim().Length == 0){
// MOD 2010.03.30 東都）高木 荷受人電話番号が0であれば非表示 END
									sCSVData = " ";
								}
// MOD 2010.03.17 東都）高木 荷受人電話番号がALL0であれば非表示 END
								荷物データ出力(fs, sCSVData, false);

								//荷受人住所の都道府県、市区町村、その他の分割
								string s住所編集  = 住所編集(sPrintData[5]);
								string[] s住所分割 = s住所編集.Split(' ');

								//荷受人住所県
								荷物データ出力(fs, s住所分割[0], false);

								//荷受人住所市
								if (s住所分割.Length > 1){
									//sCSVData = s住所分割[1].PadLeft(s住所分割[1].Length + s住所分割[0].Length);
									//荷物データ出力(fs, sCSVData, false);
									荷物データ出力(fs, s住所分割[1], false);
								}else{
									荷物データ出力(fs, "", false);
								}
								//荷受人住所町
								if (s住所分割.Length > 2){
									//if (s住所分割[0].Length + s住所分割[1].Length >= 9)
									//	sCSVData = s住所分割[2].PadLeft(s住所分割[2].Length + s住所分割[0].Length + s住所分割[1].Length + 1);
									//else
									//	sCSVData = s住所分割[2].PadLeft(s住所分割[2].Length + s住所分割[0].Length + s住所分割[1].Length);
									//荷物データ出力(fs, sCSVData, false);
									荷物データ出力(fs, s住所分割[2], false);
								}else{
									荷物データ出力(fs, "", false);
								}

								荷物データ出力(fs, sPrintData[5], false);		//荷受人住所１
								荷物データ出力(fs, sPrintData[6], false);		//荷受人住所２
								荷物データ出力(fs, sPrintData[7], false);		//荷受人住所３
								荷物データ出力(fs, sPrintData[8], false);		//荷受人名前１
								荷物データ出力(fs, sPrintData[9], false);		//荷受人名前２
// ADD 2007.10.13 東都）高木 グローバル対応（出荷日、発店の非表示） START
								if(sPrintData[14].Substring(1, 3) == "047"){
									荷物データ出力(fs, "", false);	//出荷日年
									荷物データ出力(fs, "", false);	//出荷日月
									荷物データ出力(fs, "", false);	//出荷日日
								}else{
// ADD 2007.10.13 東都）高木 グローバル対応（出荷日、発店の非表示） END
// MOD 2010.03.17 東都）高木 出荷日の年を４桁表示にする START
//									荷物データ出力(fs, sPrintData[10].Substring(2, 2), false);	//出荷日年
									荷物データ出力(fs, sPrintData[10], false);	//出荷日年
// MOD 2010.03.17 東都）高木 出荷日の年を４桁表示にする END
									//出荷日月
									if(sPrintData[10].Substring(4, 1) == "0")
										sCSVData = " " + sPrintData[10].Substring(5, 1);
									else
										sCSVData = sPrintData[10].Substring(4, 2);
									荷物データ出力(fs, sCSVData, false);
									//出荷日日
									if(sPrintData[10].Substring(6, 1) == "0")
										sCSVData = " " + sPrintData[10].Substring(7, 1);
									else
										sCSVData = sPrintData[10].Substring(6, 2);
									荷物データ出力(fs, sCSVData, false);
// ADD 2007.10.13 東都）高木 グローバル対応（出荷日、発店の非表示） START
								}
// ADD 2007.10.13 東都）高木 グローバル対応（出荷日、発店の非表示） END
								//送り状番号
								sCSVData = sPrintData[11].Substring(4,3) + "-" + sPrintData[11].Substring(7,4) + "-" + sPrintData[11].Substring(11,4);
								荷物データ出力(fs, sCSVData, false);
								//バーコード
								sCSVData = "A" + s荷物番号 + "A";
								荷物データ出力(fs, sCSVData, false);
								//着店ＣＤ
								if(sPrintData[13].Length == 0)
									sCSVData = "";
								else
									sCSVData = sPrintData[13].Substring(1, 1) + "-" + sPrintData[13].Substring(2,2);
								荷物データ出力(fs, sCSVData, false);
								//発店ＣＤ
// MOD 2007.10.13 東都）高木 グローバル対応（出荷日、発店の非表示） START
//								荷物データ出力(fs, sPrintData[14].Substring(1, 3), false);
								if(sPrintData[14].Substring(1, 3) == "047"){
									荷物データ出力(fs, "", false);
								}else{
									荷物データ出力(fs, sPrintData[14].Substring(1, 3), false);
								}
// MOD 2007.10.13 東都）高木 グローバル対応（出荷日、発店の非表示） END
								//荷送人電話番号
								sCSVData = "(" + sPrintData[15] + ")" + sPrintData[16] + "-" + sPrintData[17];
								荷物データ出力(fs, sCSVData, false);

								荷物データ出力(fs, 住所編集(sPrintData[18]), false);	//荷送人住所１
								荷物データ出力(fs, sPrintData[19], false);				//荷送人住所２
								荷物データ出力(fs, sPrintData[18], false);				//荷送人住所３
								荷物データ出力(fs, sPrintData[21], false);				//荷送人名前１
								荷物データ出力(fs, sPrintData[22], false);				//荷送人名前２
								荷物データ出力(fs, sPrintData[34], false);				//担当者

								荷物データ出力(fs, int.Parse(sPrintData[23]), false);	//個数
								荷物データ出力(fs, i連番, false);						//連番
								荷物データ出力(fs, int.Parse(sPrintData[24]), false);	//重量

								//保険料
								int iCSVData = int.Parse(sPrintData[25]) * 10;
								if(iCSVData > 0 && iCSVData < 50) iCSVData = 50;
								荷物データ出力(fs, iCSVData, false);

								//指定日
								string s指定月;
								string s指定日;
								if (sPrintData[26] != null && !sPrintData[26].Equals("") && !sPrintData[26].Equals("0"))
								{
									if(sPrintData[26].Substring(4, 1) == "0")
										s指定月 = " " + sPrintData[26].Substring(5, 1);
									else
										s指定月 = sPrintData[26].Substring(4, 2);

									if(sPrintData[26].Substring(6, 1) == "0")
										s指定日 = " " + sPrintData[26].Substring(7, 1);
									else
										s指定日 = sPrintData[26].Substring(6, 2);

									sCSVData     = s指定月 + "月" + s指定日 + "日";
									if (sPrintData[36].Equals("0"))
										sCSVData += "必着";
									else if (sPrintData[36].Equals("1"))
										sCSVData += "指定";
									荷物データ出力(fs, sCSVData, false);
								}
								else
								{
									荷物データ出力(fs, "", false);
								}

								//お客様番号
								if(sPrintData[35].Length == 0)
									荷物データ出力(fs, "", false);
								else
									荷物データ出力(fs, "お客様番号:" + sPrintData[35], false);

								荷物データ出力(fs, sPrintData[27], false);		//輸送記事１
								荷物データ出力(fs, sPrintData[28], false);		//輸送記事２
								荷物データ出力(fs, sPrintData[29], false);		//品名記事１
								荷物データ出力(fs, sPrintData[30], false);		//品名記事２
								荷物データ出力(fs, sPrintData[31], false);		//品名記事３
								if(iCnt == 0){
									荷物データ出力(fs, sPrintData[27], false);	//ラベル３輸送記事１
									荷物データ出力(fs, sPrintData[28], false);	//ラベル３輸送記事２
									荷物データ出力(fs, sPrintData[29], false);	//ラベル３品名記事１
									荷物データ出力(fs, sPrintData[30], false);	//ラベル３品名記事２
									荷物データ出力(fs, sPrintData[31], false);	//ラベル３品名記事３
									荷物データ出力(fs, "", true);				//ラベル３個口表記
								}else{
									荷物データ出力(fs, "", false);				//ラベル３輸送記事１
									荷物データ出力(fs, "", false);				//ラベル３輸送記事２
									荷物データ出力(fs, "", false);				//ラベル３品名記事１
									荷物データ出力(fs, "", false);				//ラベル３品名記事２
									荷物データ出力(fs, "", false);				//ラベル３品名記事３
									荷物データ出力(fs, "荷札" + s連番.PadLeft(3,' ') + "個目", true);
																				//ラベル３個口表記
								}
							}
						}
						catch(Exception ex)
						{
							throw new Exception(ex.Message);
						}
						fs.Close();
					}
					catch(Exception ex)
					{
						throw new Exception(ex.Message);
					}
					return;
				}
// ADD 2006.08.10 東都）高木 ＩＣタグ対応ＳＡＴＯ製プリンタ対応 END

// MOD 2008.03.19 東都）高木 個別再発行機能の追加 START
//				for (int i = 0; i < int.Parse(sPrintData[23]); i++)
				int iLabel終了 = int.Parse(sPrintData[23]);
				if(iLabel終了 > i終了){
					iLabel終了 = i終了;
				}
				for (int iPage = i開始; iPage <= iLabel終了; iPage++)
// MOD 2008.03.19 東都）高木 個別再発行機能の追加 END
				{
					送り状データ.table送り状Row tr = (送り状データ.table送り状Row)ds送り状.table送り状.NewRow();
						
					tr.BeginEdit();
// ADD 2005.07.11 東都）小童谷 印刷順の制御 START
					tr.印刷順 = i印刷順++;
// ADD 2005.07.11 東都）小童谷 印刷順の制御 END
// MOD 2011.01.06 東都）高木 郵便番号の印刷 START
					if(!gsオプション[19].Equals("1") && sPrintData[12].Length >= 7){
						tr.荷受人郵便番号 = "〒";
						tr.荷受人郵便番号 += sPrintData[12].Substring(0,3);
						tr.荷受人郵便番号 += "-";
						tr.荷受人郵便番号 += sPrintData[12].Substring(3,4);
					}else{
						tr.荷受人郵便番号 = "";
					}
// MOD 2011.01.06 東都）高木 郵便番号の印刷 END
					tr.荷受人ＣＤ     = sPrintData[1];
// MOD 2009.05.01 東都）高木 オプションの項目追加 START
					if(gsオプション[0].Length == 4){
						if(!gsオプション[12].Equals("1")){
							tr.荷受人ＣＤ     = " ";
						}
					}
// MOD 2009.05.01 東都）高木 オプションの項目追加 END
					tr.荷受人電話番号 = "(" + sPrintData[2] + ")" + sPrintData[3] + "-" + sPrintData[4];
// MOD 2010.03.17 東都）高木 荷受人電話番号がALL0であれば非表示 START
// MOD 2010.03.30 東都）高木 荷受人電話番号が0であれば非表示 START
//					if(sPrintData[2] == "000000"
//					&& sPrintData[3] == "0000"
//					&& sPrintData[4] == "0000"){
					if(sPrintData[2].Replace("0","").Trim().Length == 0
					&& sPrintData[3].Replace("0","").Trim().Length == 0
					&& sPrintData[4].Replace("0","").Trim().Length == 0){
// MOD 2010.03.30 東都）高木 荷受人電話番号が0であれば非表示 END
						tr.荷受人電話番号 = " ";
					}
// MOD 2010.03.18 東都）高木 荷受人住所の都道府県と市区郡を区切らない START
//// MOD 2010.03.17 東都）高木 荷受人電話番号がALL0であれば非表示 END
////					tr.荷受人住所１   = 住所編集(sPrintData[5]);
////					tr.荷受人住所１   = sPrintData[5];
//					string s住所編集  = 住所編集(sPrintData[5]);
//					string[] s住所分割 = s住所編集.Split(' ');
//					tr.荷受人住所県   = s住所分割[0];
//					if (s住所分割.Length > 1)
//						tr.荷受人住所市 = s住所分割[1].PadLeft(s住所分割[1].Length + s住所分割[0].Length);
//					else 
//						tr.荷受人住所市 = "";
//					if (s住所分割.Length > 2)
//// MOD 2006.05.24 東都）伊賀 住所表示位置の調整 START
////						tr.荷受人住所町 = s住所分割[2].PadLeft(s住所分割[2].Length + s住所分割[0].Length + s住所分割[1].Length);
//					{
//						if (s住所分割[0].Length + s住所分割[1].Length >= 9)
//							tr.荷受人住所町 = s住所分割[2].PadLeft(s住所分割[2].Length + s住所分割[0].Length + s住所分割[1].Length + 1);
//						else
//							tr.荷受人住所町 = s住所分割[2].PadLeft(s住所分割[2].Length + s住所分割[0].Length + s住所分割[1].Length);
//					}
//// MOD 2005.05.24 東都）伊賀 住所表示位置の調整 END
//					else
//						tr.荷受人住所町 = "";
					tr.荷受人住所県   = "";
					tr.荷受人住所市   = "";
					tr.荷受人住所町   = "";
// MOD 2010.03.18 東都）高木 荷受人住所の都道府県と市区郡を区切らない END
					tr.荷受人住所１   = sPrintData[5];
//					tr.荷受人住所１   = s住所編集;
					tr.荷受人住所２   = sPrintData[6];
					tr.荷受人住所３   = sPrintData[7];
					tr.荷受人名前１   = sPrintData[8];
					tr.荷受人名前２   = sPrintData[9];
// ADD 2015.03.23 BEVAS) 前田 支店止め対応追加 START
					if (sPrintData[5].Equals("※※支店止め※※"))
					{
						// 支店止めであるとき、荷受人住所項目に以下の設定を行なう
						// 　・荷受人住所県：「※※支店止め※※」（帳票項目の表示判定に使用、非表示項目）
						// 　・荷受人住所１：「福山通運／王子運送」を印字
						// 　・荷受人住所２：「○○支店／営業所止め」
						// 　・荷受人住所３：何も印字しない
						tr.荷受人住所県 = sPrintData[5];
						if(sPrintData[6].Substring(0, 2) == "王子")
						{
							tr.荷受人住所１ = "王子運送";
						}
						else
						{
							tr.荷受人住所１ = "福山通運";
						}
						tr.荷受人住所３ = "";
					}
// ADD 2015.03.23 BEVAS) 前田 支店止め対応追加 END
// MOD 2010.03.17 東都）高木 出荷日の年を４桁表示にする START
//					tr.出荷日年       = sPrintData[10].Substring(2, 2);
					tr.出荷日年       = sPrintData[10];
// MOD 2010.03.17 東都）高木 出荷日の年を４桁表示にする END
					if(sPrintData[10].Substring(4, 1) == "0")
						tr.出荷日月       = " " + sPrintData[10].Substring(5, 1);
					else
						tr.出荷日月       = sPrintData[10].Substring(4, 2);
					if(sPrintData[10].Substring(6, 1) == "0")
						tr.出荷日日       = " " + sPrintData[10].Substring(7, 1);
					else
						tr.出荷日日       = sPrintData[10].Substring(6, 2);
					tr.送り状番号     = sPrintData[11].Substring(4,3) + "-" + sPrintData[11].Substring(7,4) + "-" + sPrintData[11].Substring(11,4);
// MOD 2008.03.19 東都）高木 個別再発行機能の追加 START
//					tr.バーコード     = "A" + sPrintData[11].Substring(4) + (i + 1).ToString().PadLeft(2, '0') + "A";
					tr.バーコード     = "A" + sPrintData[11].Substring(4) + iPage.ToString().PadLeft(2, '0') + "A";
// MOD 2008.03.19 東都）高木 個別再発行機能の追加 END
					if(sPrintData[13].Length == 0)
						tr.着店ＣＤ       = "";
					else
// MOD 2007.02.08 東都）高木 仕分ＣＤ、発店名の追加 START
//						tr.着店ＣＤ       = sPrintData[13].Substring(1, 1) + "-" + sPrintData[13].Substring(2,2);
						tr.着店ＣＤ       = sPrintData[13].Substring(1);
// MOD 2007.02.08 東都）高木 仕分ＣＤ、発店名の追加 END
// ADD 2009.04.07 東都）高木 着店ＣＤ[000]対応 START
					if(sPrintData[13].Equals("0000")){
						tr.着店ＣＤ       = "";
					}
// ADD 2009.04.07 東都）高木 着店ＣＤ[000]対応 END

// MOD 2007.02.15 東都）高木 仕分ＣＤ、発店名の印字条件の変更 START
//// MOD 2007.02.08 東都）高木 仕分ＣＤ、発店名の追加 START
//					if(sPrintData[37].Length == 0)
//						tr.仕分ＣＤ       = "";
//					else
//						tr.仕分ＣＤ       = "-" + sPrintData[37];
//					tr.発店名         = sPrintData[38];
//// MOD 2007.02.08 東都）高木 仕分ＣＤ、発店名の追加 END
					//仕分ＣＤが設定されている場合、仕分ＣＤ、発店名を印字
					if(sPrintData[37].Length > 0){
// MOD 2007.03.14 FJCS）桑田 ハイフン無し START
//						tr.仕分ＣＤ       = "-" + sPrintData[37];
						tr.仕分ＣＤ       = sPrintData[37];
// MOD 2007.03.14 FJCS）桑田 ハイフン無し END
// MOD 2011.12.06 東都）高木 ラベル印字項目に発店名・着店名を追加 START
//						tr.発店名         = sPrintData[38];
// MOD 2011.12.06 東都）高木 ラベル印字項目に発店名・着店名を追加 END
					}else{
						tr.仕分ＣＤ       = "";
// MOD 2011.12.06 東都）高木 ラベル印字項目に発店名・着店名を追加 START
//						tr.発店名         = "";
// MOD 2011.12.06 東都）高木 ラベル印字項目に発店名・着店名を追加 END
					}
// MOD 2007.02.15 東都）高木 仕分ＣＤ、発店名の印字条件の変更 END
					tr.発店ＣＤ       = sPrintData[14].Substring(1, 3);
// ADD 2007.10.13 東都）高木 グローバル対応（出荷日、発店の非表示） START
					if(sPrintData[14].Substring(1, 3) == "047"){
						tr.出荷日年       = "";
						tr.出荷日月       = "";
						tr.出荷日日       = "";
						tr.発店名         = "";
						tr.発店ＣＤ       = "";
					}
// ADD 2007.10.13 東都）高木 グローバル対応（出荷日、発店の非表示） END
// MOD 2011.01.06 東都）高木 郵便番号の印刷 START
					if(!gsオプション[19].Equals("1")
					 && sPrintData.Length > 40 && sPrintData[40].Length >= 7){
						tr.荷送人郵便番号 = "〒";
						tr.荷送人郵便番号 += sPrintData[40].Substring(0,3);
						tr.荷送人郵便番号 += "-";
						tr.荷送人郵便番号 += sPrintData[40].Substring(3,4);
					}else{
						tr.荷送人郵便番号 = "";
					}
// MOD 2011.01.06 東都）高木 郵便番号の印刷 END
					tr.荷送人電話番号 = "(" + sPrintData[15] + ")" + sPrintData[16] + "-" + sPrintData[17];
					//				tr.荷送人住所１   = sPrintData[18];
//保留 MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
					tr.荷送人住所１   = 住所編集(sPrintData[18]);
//					tr.荷送人住所１   = sPrintData[18];
//保留 MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
					tr.荷送人住所２   = sPrintData[19];
//					tr.荷送人住所３   = sPrintData[20];
					tr.荷送人住所３   = sPrintData[18];
					tr.荷送人名前１   = sPrintData[21];
					tr.荷送人名前２   = sPrintData[22];
// ADD 2005.06.01 東都）小童谷 担当者追加 START
					tr.担当者         = sPrintData[34];
// ADD 2005.06.01 東都）小童谷 担当者追加 END
					tr.個数           = sPrintData[23];
// MOD 2008.03.19 東都）高木 個別再発行機能の追加 START
//					tr.連番           = (i + 1).ToString();
					tr.連番           = iPage.ToString();
// MOD 2008.03.19 東都）高木 個別再発行機能の追加 END
					tr.重量           = sPrintData[24];
					int i保険料 = int.Parse(sPrintData[25]) * 10;
					if(i保険料 > 0 && i保険料 < 50)
					{
						tr.保険料     = "50";
					}
					else
					{
						string s保険料 = i保険料.ToString();
						if(s保険料.Length == 4)
							s保険料 = s保険料.Insert(1,",");
						else
						{
							if(s保険料.Length == 5)
								s保険料 = s保険料.Insert(2,",");
						}
						tr.保険料     = s保険料;
//						tr.保険料     = i保険料.ToString();
					}
					string s指定月;
					string s指定日;
					if (sPrintData[26] != null && !sPrintData[26].Equals("") && !sPrintData[26].Equals("0"))
					{
						if(sPrintData[26].Substring(4, 1) == "0")
							s指定月 = " " + sPrintData[26].Substring(5, 1);
						else
							s指定月 = sPrintData[26].Substring(4, 2);

						if(sPrintData[26].Substring(6, 1) == "0")
							s指定日 = " " + sPrintData[26].Substring(7, 1);
						else
							s指定日 = sPrintData[26].Substring(6, 2);
// MOD 2005.06.01 東都）伊賀 指定日区分追加 START
						tr.指定日     = s指定月 + "月" + s指定日 + "日";
						if (sPrintData[36].Equals("0"))
							tr.指定日 += "必着";
						else if (sPrintData[36].Equals("1"))
							tr.指定日 += "指定";
// MOD 2005.06.01 東都）伊賀 指定日区分追加 END
//						tr.指定日     = sPrintData[26].Substring(4, 2) + "月" + sPrintData[26].Substring(6, 2) + "日必着";
					}
					else
						tr.指定日     = "";
// ADD 2005.06.01 東都）小童谷 お客様番号追加 START
					if(sPrintData[35].Length != 0)
						tr.お客様番号     = "お客様番号:" + sPrintData[35];
					else
						tr.お客様番号     = sPrintData[35];
// ADD 2005.06.01 東都）小童谷 お客様番号追加 END
					tr.輸送記事１     = sPrintData[27];
					tr.輸送記事２     = sPrintData[28];
					tr.品名記事１     = sPrintData[29];
					tr.品名記事２     = sPrintData[30];
					tr.品名記事３     = sPrintData[31];
// MOD 2011.07.14 東都）高木 記事行の追加 START
					if(sPrintData.Length > 42){
						tr.品名記事４ = sPrintData[42];
						tr.品名記事５ = sPrintData[43];
						tr.品名記事６ = sPrintData[44];
					}else{
						tr.品名記事４ = "";
						tr.品名記事５ = "";
						tr.品名記事６ = "";
					}
					// 品名記事４～６のいずれかにデータある場合
					if(tr.品名記事４.Length > 0
						|| tr.品名記事５.Length > 0
						|| tr.品名記事６.Length > 0
					){
						// 全角９文字、又は半角１８文字
						tr.品名記事１ = バイト長カット(tr.品名記事１, 18);
						tr.品名記事２ = バイト長カット(tr.品名記事２, 18);
						tr.品名記事３ = バイト長カット(tr.品名記事３, 18);
						tr.品名記事４ = バイト長カット(tr.品名記事４, 18);
						tr.品名記事５ = バイト長カット(tr.品名記事５, 18);
						tr.品名記事６ = バイト長カット(tr.品名記事６, 18);
					}
// MOD 2011.07.14 東都）高木 記事行の追加 END
// ADD 2007.02.08 東都）高木 仕分ＣＤ、発店名の追加 START
//					//レイアウト印字用
//					tr.着店ＣＤ       = "888";
//					tr.仕分ＣＤ       = "-" + "WWW";
//					tr.発店名         = "国国国国";
//					tr.輸送記事１     = "国国国国王国国国国王国国国国王";
//					tr.輸送記事２     = "国国国国王国国国国王国国国国王";
// ADD 2007.02.08 東都）高木 仕分ＣＤ、発店名の追加 END

// MOD 2009.11.09 PSN）藤井　オプションの項目追加 START
					if(!gsオプション[15].Equals("1"))
					{
						tr.荷受人フォントサイズ拡大FLG     = "0";
					}else{
						tr.荷受人フォントサイズ拡大FLG     = "1";
					}
// MOD 2009.11.09 PSN）藤井　オプションの項目追加 END
// MOD 2010.02.28 東都）高木 王子運送の対応 START
					if(gs会員ＣＤ.Substring(0,1) != "J"){
						tr.王子運送FLG = "0";
					}else{
						tr.王子運送FLG = "1";
					}
// MOD 2010.02.28 東都）高木 王子運送の対応 END
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
					string s重量入力制御 = (sPrintData.Length > 41) ? sPrintData[41] : "0";
					tr.重量入力制御 = s重量入力制御;
//保留				tr.重量入力制御 = gs重量入力制御;
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END
// MOD 2011.12.06 東都）高木 ラベルヘッダ部に発店名・着店名を印字 START
					if(tr.発店ＣＤ == "" || tr.発店ＣＤ == "000"){
						tr.発店名     = ""; // 発店ＣＤが未設定時(グローバル等)
// MOD 2012.04.10 東都）高木 ラベル発店名の印字制御対応 START
					}else if(gsオプション[21].Equals("1")){
						tr.発店名     = "";
// MOD 2012.04.10 東都）高木 ラベル発店名の印字制御対応 END
					}else{
						if(sPrintData[38] == ""){
// MOD 2015.01.16 BEVAS)前田 着店名の印字拡大 START
							//tr.発店名     = "発:" + tr.発店ＣＤ;
							tr.発店名     = tr.発店ＣＤ;
						}
						else
						{
							//tr.発店名     = "発:" + sPrintData[38];
							tr.発店名     = sPrintData[38];
// MOD 2015.01.16 BEVAS)前田 着店名の印字拡大 END
						}
					}
					string s着店名 = (sPrintData.Length > 45) ? sPrintData[45] : "";
					if(tr.着店ＣＤ == "" || tr.着店ＣＤ == "000"){
						tr.着店名     = ""; // 着店ＣＤが未設定時
					}else{
						if(s着店名 == ""){
// MOD 2015.01.16 BEVAS)前田 着店名の印字拡大 START
							//tr.着店名     = "着:" + tr.着店ＣＤ;
							tr.着店名     = tr.着店ＣＤ;
						}
						else
						{
							//tr.着店名     = "着:" + s着店名;
							tr.着店名     = s着店名;
// MOD 2015.01.16 BEVAS)前田 着店名の印字拡大 END
						}
					}
					// ※ラベルのバックの黒塗を[着店名]に設定している為
					//   着店名が表示されない時、バックの色が消えます
					// 
// MOD 2011.12.06 東都）高木 ラベルヘッダ部に発店名・着店名を印字 END
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 START
					//社内伝票であれば、値をセットする
					if(gs利用者部門店所ＣＤ.Equals("044"))
					{
						// 社内伝票であるとき、荷受人住所項目に以下の設定を行なう
						// 　・荷受人住所町　　　　　：「※※社内伝票※※」
						//　　　（帳票項目の表示判定に使用、非表示項目）
						// 　・着店ＣＤ（大）　　　　：印字しない
						// 　・着店ＣＤ（小）　　　　：印字する
						// 　・『社内専用』テキスト：印字する
						tr.荷受人住所町 = "※※社内伝票※※";
					}
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 END

					tr.EndEdit();

					ds送り状.table送り状.Rows.Add(tr);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//		protected static void 送り状帳票印刷()
		protected void 送り状帳票印刷()
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
		{
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） START
			//明示的ガベージコレクタ
			System.GC.Collect();
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） END
// ADD 2006.08.10 東都）高木 ＩＣタグ対応ＳＡＴＯ製プリンタ対応 START
			if(gsプリンタ種類 == "S0004"){
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） START
//				i印刷順 = 0;
//				ds送り状.Clear();
				送り状データクリア();
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） END
				return;
			}
// ADD 2006.08.10 東都）高木 ＩＣタグ対応ＳＡＴＯ製プリンタ対応 END

			//送り状帳票 cr = new 送り状帳票();
			//送り状帳票２ cr = new 送り状帳票２();
			送り状帳票３ cr = new 送り状帳票３();
// MOD 2011.03.03 東都）高木 プリンタごとの補正対応 START
#if DEBUG
			System.IO.FileStream fs = null;
			try{
				fs = new FileStream(
					Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
					+ @"\ラベル定義_is2"
					+ "_" + DateTime.Now.ToString("yyyyMMdd")
					+ "_" + gsaユーザ[3]
					+ ".txt", 
					FileMode.Create, FileAccess.Write,FileShare.Read);
			}catch(Exception ex){
				throw new Exception(ex.Message);
			}finally{
				if(fs != null) fs.Close();
			}
			CheckReportDefOut(cr.Section1);
			CheckReportDefOut(cr.Section2);
			CheckReportDefOut(cr.Section3);
			CheckReportDefOut(cr.Section5);
			CheckReportDefOut(cr.Section6);
			CheckReportDefOut(cr.Section9);
			CheckReportDefOut(cr.Section10);
//			if(gsプリンタ種類.Length > 0){
//				送り状データクリア();
//				return;
//			}
#endif
// MOD 2011.03.03 東都）高木 プリンタごとの補正対応 END
// MOD 2011.03.03 東都）高木 プリンタごとの補正対応 START
			//------------------------------------------------------------------
			// << 参考：単位 >>
			//------------------------------------------------------------------
			// 1 inch = 25.4 mm
			// 1 inch = 1440 Twp
			// → 1   mm = 56.69 Twp
			// → 1/4 mm = 14.17 Twp
			//------------------------------------------------------------------
			// << 参考：用紙サイズ設定値および印字密度 >>
			//------------------------------------------------------------------
			// Zebra  ：横   4.25 inch 縦   6.51 inch
			//       →横 6120.0 Twp  縦 9374.4 Twp
			// ( Zebra ：横  108.0 mm   縦  165.4 mm  )
			// (       →横 6122.8 Twp  縦 9377.0 Twp )
			// LP2844 ：印字密度 203 x 203 dpi (8 dots/mm) 
			//------------------------------------------------------------------
			// Sato   ：横  107.0 mm   縦  164.0 mm
			//       →横 6066.1 Twp  縦 9297.6 Twp
			// ﾚｽﾌﾟﾘβ：印字密度 203 x 203 dpi (8 dots/mm) 
			//------------------------------------------------------------------
			// << 参考：ラベル用紙サイズ >>
			//------------------------------------------------------------------
			// 箱より：横  110.0 mm   縦  6-1/2 inch
			//       →横 6236.2 Twp  縦 9360.0 Twp
			//------------------------------------------------------------------

			//------------------------------------------------------------------
			// << 参考：Crystalreports セクション高さの初期値 >>
			//------------------------------------------------------------------
//			cr.Section1.Height  =    0; // ReportHeader
//			cr.Section2.Height  = 1185; // PageHeader
//			cr.Section3.Height  = 3510; // Detail a
//			cr.Section5.Height  = 3012; // PageFooter
//			cr.Section6.Height  =    0; // ReportFooter
//			cr.Section9.Height  = 1585; // Detail b 1枚目
//			cr.Section10.Height = 1585; // Detail c 2枚目以降
//							合計  9292 Twp ← 実際の用紙のサイズより 32 Twp Over

			//------------------------------------------------------------------
			// << 補正単位 >>
			//------------------------------------------------------------------
			int i補正単位 = 14; // 約 1/4 mm
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 START
			int iヘッダー部上下補正Ｔ = 0;
			int i詳細部１上下補正Ｔ   = 0;
			int i詳細部２上下補正Ｔ   = 0; 
			int iフッター部上下補正Ｔ = 0;
			int i左右補正Ｔ = 0;
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 END
			if(gsプリンタ種類 == "S0002"){
				//------------------------------------------------------------------
				// レスプリβの場合
				//------------------------------------------------------------------
				//------------------------------------------------------------------
				// << 上下位置および高さ補正 >>
				//------------------------------------------------------------------
				//------------------------------------------------------------------
				// < フッター部：上下位置補正 >
				//------------------------------------------------------------------
// MOD 2011.04.26 東都）高木 プリンタごとの補正対応 START
//				// フッター部：出荷年月日
//				cr.Section5.ReportObjects["Field40"].Top  += i補正単位 * (-1);
//				cr.Section5.ReportObjects["Field41"].Top  += i補正単位 * (-1);
//				cr.Section5.ReportObjects["Field42"].Top  += i補正単位 * (-1);
// MOD 2011.04.26 東都）高木 プリンタごとの補正対応 END
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 START
			}else if(gsプリンタ種類 == "S0005"){
				//------------------------------------------------------------------
				// ＳＡＴＯ製プリンタ(CS408T)の場合
				//------------------------------------------------------------------
				//------------------------------------------------------------------
				// << 上下位置および高さ補正 >>
				//------------------------------------------------------------------
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 END
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 START
			}
			else if(gsプリンタ種類 == "S0006")
			{
				//------------------------------------------------------------------
				// ＳＡＴＯ製プリンタ(CS408T)の場合
				//------------------------------------------------------------------
				//------------------------------------------------------------------
				// << 上下位置および高さ補正 >>
				//------------------------------------------------------------------
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 END
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 START
// MOD 2015.02.12 BEVAS）前田 ＴＥＣ製プリンタ(B-LV4)対応 START
			}
			//else if(gsプリンタ種類 == "S0007")
			else if((gsプリンタ種類 == "S0007") || (gsプリンタ種類 == "S0008"))
			{
				//------------------------------------------------------------------
//				// ＴＥＣ製プリンタ(B-EV4-G)の場合
				// ＴＥＣ製プリンタ(B-EV4-GおよびB-LV4-G)の場合
				//------------------------------------------------------------------
// MOD 2015.02.12 BEVAS）高杉 ＴＥＣ製プリンタ(B-LV4)対応 START
				//------------------------------------------------------------------
				// << 上下位置および高さ補正 >>
				//------------------------------------------------------------------
				iヘッダー部上下補正Ｔ = i補正単位 * ( 0); // 
				i詳細部１上下補正Ｔ   = i補正単位 * (-7); // 約 1.75 mm(上)
				i詳細部２上下補正Ｔ   = i補正単位 * (-2); // 約 0.50 mm(上)
				iフッター部上下補正Ｔ = i補正単位 * ( 0); // 
				//------------------------------------------------------------------
				// < 詳細部１：上下位置補正 >
				//------------------------------------------------------------------
				cr.Section3.ReportObjects["Field8" ].Top  += i詳細部１上下補正Ｔ; // バーコード上
				cr.Section3.ReportObjects["Field9" ].Top  += i詳細部１上下補正Ｔ; // バーコード中
				cr.Section3.ReportObjects["Field74"].Top  += i詳細部１上下補正Ｔ; // バーコード下
				cr.Section3.ReportObjects["Field19"].Top  += i詳細部１上下補正Ｔ; // バーコード数字
				cr.Section3.ReportObjects["Text21" ].Top  += i詳細部１上下補正Ｔ; // 王子運送******
				cr.Section3.ReportObjects["Field16"].Top  += i詳細部１上下補正Ｔ; // 出荷日(年)
				cr.Section3.ReportObjects["Field17"].Top  += i詳細部１上下補正Ｔ; // 出荷日(月)
				cr.Section3.ReportObjects["Field18"].Top  += i詳細部１上下補正Ｔ; // 出荷日(日)
				cr.Section3.ReportObjects["Text17" ].Top  += i詳細部１上下補正Ｔ; // 発店ＣＤ(文字)
				cr.Section3.ReportObjects["Field50"].Top  += i詳細部１上下補正Ｔ; // 発店ＣＤ
				cr.Section3.ReportObjects["Text18" ].Top  += i詳細部１上下補正Ｔ; // 元払
				cr.Section3.ReportObjects["Text1"  ].Top  += i詳細部１上下補正Ｔ; // 送り状番号(文字)
				cr.Section3.ReportObjects["Field51"].Top  += i詳細部１上下補正Ｔ; // 送り状番号
				//------------------------------------------------------------------
				// < 各セクション高さ補正 >
				//------------------------------------------------------------------
				// ヘッダー部高さ補正
				cr.Section2.Height  += iヘッダー部上下補正Ｔ;
				// 詳細部１
				cr.Section3.Height  += i詳細部１上下補正Ｔ;
				// 詳細部２－１ // 1枚目
				cr.Section9.Height  += i詳細部２上下補正Ｔ;
				// 詳細部２－２ // 2枚目以降
				cr.Section10.Height += i詳細部２上下補正Ｔ;
				// フッター部高さ補正
				cr.Section5.Height  += iフッター部上下補正Ｔ;
				//------------------------------------------------------------------
				// << 左右位置補正 >>
				//------------------------------------------------------------------
				i左右補正Ｔ = i補正単位 * ( 8); // 約 2.00 mm(右)
				//------------------------------------------------------------------
				// < ヘッダー部：上下位置補正 >
				//------------------------------------------------------------------
				cr.Section2.ReportObjects["Field1" ].Left += i左右補正Ｔ; //着店ＣＤ
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 START
				cr.Section2.ReportObjects["Field83"].Left += i左右補正Ｔ; //着店ＣＤ（小）
				cr.Section2.ReportObjects["Text3" ].Left += i左右補正Ｔ;  //『社内専用』テキスト
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 END
				cr.Section2.ReportObjects["Field49"].Left += i左右補正Ｔ; // 発店名
				cr.Section2.ReportObjects["Field71"].Left += i左右補正Ｔ; // 発店名（バック）
				cr.Section2.ReportObjects["Field81"].Left += i左右補正Ｔ; // 着店名
				cr.Section2.ReportObjects["Field82"].Left += i左右補正Ｔ; // 着店名（バック）
				cr.Section2.ReportObjects["Field72"].Left += i左右補正Ｔ; // 仕分ＣＤ
// ADD 2015.01.20 BEVAS)前田 着店名拡大印字対応 START
				cr.Section2.ReportObjects["Text24"].Left += i左右補正Ｔ; // 「着」文字
				cr.Section2.ReportObjects["Text25"].Left += i左右補正Ｔ; // 「発」文字
// ADD 2015.01.20 BEVAS)前田 着店名拡大印字対応 END

				cr.Section2.ReportObjects["Field2" ].Left += i左右補正Ｔ; // 指定日
				cr.Section2.ReportObjects["Field3" ].Left += i左右補正Ｔ; // 輸送記事１
				cr.Section2.ReportObjects["Field4" ].Left += i左右補正Ｔ; // 輸送記事２
				//------------------------------------------------------------------
				// < 詳細部１：左右位置補正 >
				//------------------------------------------------------------------
				cr.Section3.ReportObjects["Field11"].Left += i左右補正Ｔ; //荷受人住所１
				cr.Section3.ReportObjects["Field12"].Left += i左右補正Ｔ; //荷受人住所２
				cr.Section3.ReportObjects["Field13"].Left += i左右補正Ｔ; //荷受人住所３
				cr.Section3.ReportObjects["Field14"].Left += i左右補正Ｔ; //荷受人名前１
				cr.Section3.ReportObjects["Field15"].Left += i左右補正Ｔ; //荷受人名前２
				cr.Section3.ReportObjects["Field60"].Left += i左右補正Ｔ; //荷受人住所１(大文字)
				cr.Section3.ReportObjects["Field75"].Left += i左右補正Ｔ; //荷受人住所２(大文字)
				cr.Section3.ReportObjects["Field76"].Left += i左右補正Ｔ; //荷受人名前１(大文字)

				cr.Section3.ReportObjects["Text21" ].Left += i左右補正Ｔ; //王子運送******
				cr.Section3.ReportObjects["Field16"].Left += i左右補正Ｔ; //出荷日(年)
				cr.Section3.ReportObjects["Field17"].Left += i左右補正Ｔ; //出荷日(月)
				cr.Section3.ReportObjects["Field18"].Left += i左右補正Ｔ; //出荷日(日)
				//------------------------------------------------------------------
				// < 詳細部２－１：左右位置補正 >
				//------------------------------------------------------------------
				cr.Section9.ReportObjects["Field79"].Left += i左右補正Ｔ; //荷送人郵便番号
				cr.Section9.ReportObjects["Field61"].Left += i左右補正Ｔ; //荷送人住所１
				cr.Section9.ReportObjects["Field62"].Left += i左右補正Ｔ; //荷送人住所２
				cr.Section9.ReportObjects["Field63"].Left += i左右補正Ｔ; //荷送人名前１
				cr.Section9.ReportObjects["Field64"].Left += i左右補正Ｔ; //荷送人名前２
				cr.Section9.ReportObjects["Field45"].Left += i左右補正Ｔ; //荷送人担当者

// ADD 2015.01.20 BEVAS)前田 入力欄追加印字対応 START
				//cr.Section9.ReportObjects["Text2"].Left        += i左右補正Ｔ; // 受領印文字
				cr.Section9.ReportObjects["Text13"].Left       += i左右補正Ｔ; // 保険料背景
				cr.Section9.ReportObjects["Text6"].Left        += i左右補正Ｔ; // 保険料(文字)
				cr.Section9.ReportObjects["Field54"].Left      += i左右補正Ｔ; // 保険料(金額)
				cr.Section9.ReportObjects["Text7"].Left        += i左右補正Ｔ; // 円
				cr.Section9.ReportObjects["親荷札kg枠"].Left    += i左右補正Ｔ;
				cr.Section9.ReportObjects["親荷札cm枠"].Left    += i左右補正Ｔ;
				cr.Section9.ReportObjects["親荷札才数枠"].Left  += i左右補正Ｔ;
				cr.Section9.ReportObjects["txt親荷札kg"].Left   += i左右補正Ｔ;
				cr.Section9.ReportObjects["txt親荷札cm"].Left   += i左右補正Ｔ;
				cr.Section9.ReportObjects["txt親荷札才数"].Left += i左右補正Ｔ;
// ADD 2015.01.20 BEVAS)前田 入力欄追加印字対応 END
							
				//------------------------------------------------------------------
				// < 詳細部２－２：左右位置補正 >
				//------------------------------------------------------------------
				cr.Section10.ReportObjects["Field21"].Left += i左右補正Ｔ; //荷送人郵便番号
				cr.Section10.ReportObjects["Field66"].Left += i左右補正Ｔ; //荷送人住所１
				cr.Section10.ReportObjects["Field67"].Left += i左右補正Ｔ; //荷送人住所２
				cr.Section10.ReportObjects["Field68"].Left += i左右補正Ｔ; //荷送人名前１
				cr.Section10.ReportObjects["Field69"].Left += i左右補正Ｔ; //荷送人名前２
				cr.Section10.ReportObjects["Field20"].Left += i左右補正Ｔ; //荷送人担当者
// ADD 2015.01.20 BEVAS)前田 入力欄追加印字対応 START
				cr.Section10.ReportObjects["Text16"].Left      += i左右補正Ｔ; // 保険料背景
				cr.Section10.ReportObjects["Text19"].Left      += i左右補正Ｔ; // 保険料(文字)
				cr.Section10.ReportObjects["Field56"].Left     += i左右補正Ｔ; // 保険料(金額)
				cr.Section10.ReportObjects["Text20"].Left      += i左右補正Ｔ; // 円
				cr.Section10.ReportObjects["子荷札kg枠"].Left   += i左右補正Ｔ;
				cr.Section10.ReportObjects["子荷札cm枠"].Left   += i左右補正Ｔ;
				cr.Section10.ReportObjects["子荷札才数枠"].Left += i左右補正Ｔ;
				cr.Section10.ReportObjects["txt子荷札kg"].Left  += i左右補正Ｔ;
				cr.Section10.ReportObjects["txt子荷札cm"].Left  += i左右補正Ｔ;
				cr.Section10.ReportObjects["txt子荷札才数"].Left+= i左右補正Ｔ;
// ADD 2015.01.20 BEVAS)前田 入力欄追加印字対応 END
				//------------------------------------------------------------------
				// < フッター部：左右位置補正 >
				//------------------------------------------------------------------
				cr.Section5.ReportObjects["Field80"].Left += i左右補正Ｔ; //荷受人郵便番号
				cr.Section5.ReportObjects["Field23"].Left += i左右補正Ｔ; //荷受人住所１
				cr.Section5.ReportObjects["Field24"].Left += i左右補正Ｔ; //荷受人住所２
				cr.Section5.ReportObjects["Field25"].Left += i左右補正Ｔ; //荷受人住所３
				cr.Section5.ReportObjects["Field77"].Left += i左右補正Ｔ; //荷受人住所１(大文字)
				cr.Section5.ReportObjects["Field78"].Left += i左右補正Ｔ; //荷受人住所２(大文字)
				cr.Section5.ReportObjects["Field26"].Left += i左右補正Ｔ; //荷受人名前１
				cr.Section5.ReportObjects["Field27"].Left += i左右補正Ｔ; //荷受人名前２

				cr.Section5.ReportObjects["Field40"].Left += i左右補正Ｔ; //出荷日(年)
				cr.Section5.ReportObjects["Field41"].Left += i左右補正Ｔ; //出荷日(月)
				cr.Section5.ReportObjects["Field42"].Left += i左右補正Ｔ; //出荷日(日)

				cr.Section5.ReportObjects["Field5" ].Left += i左右補正Ｔ; //荷送人郵便番号
				cr.Section5.ReportObjects["Field48"].Left += i左右補正Ｔ; //荷送人住所１
				cr.Section5.ReportObjects["Field29"].Left += i左右補正Ｔ; //荷送人住所２
				cr.Section5.ReportObjects["Field31"].Left += i左右補正Ｔ; //荷送人名前１
				cr.Section5.ReportObjects["Field32"].Left += i左右補正Ｔ; //荷送人名前２
				cr.Section5.ReportObjects["Field28"].Left += i左右補正Ｔ; //荷送人担当者

				cr.Section5.ReportObjects["Text22" ].Left += i左右補正Ｔ; //******
				cr.Section5.ReportObjects["Text23" ].Left += i左右補正Ｔ; //王子運送
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 END
			}
			else
			{
				//------------------------------------------------------------------
				// レスプリβ以外（Ｚｅｂｒａ）の場合
				//------------------------------------------------------------------
				//------------------------------------------------------------------
				// << 上下位置および高さ補正 >>
				//------------------------------------------------------------------
//				int iヘッダー部上下補正 = i補正単位 * (-6); // 約 1.5  mm
				int iヘッダー部上下補正 = i補正単位 * (-5); // 約 1.25 mm
				int i詳細部１上下補正   = i補正単位 * ( 0); // 
				int i詳細部２上下補正   = i補正単位 * (-3); // 約 0.75 mm(-4はX、-3まで)
				int iフッター部上下補正 = i補正単位 * ( 8); // 約 2.00 mm
				//------------------------------------------------------------------
				// < ヘッダー部：上下位置補正 >
				//------------------------------------------------------------------
				// ヘッダー部：着店コード
				cr.Section2.ReportObjects["Field1" ].Top  += iヘッダー部上下補正; // 着店ＣＤ
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 START
				cr.Section2.ReportObjects["Field83"].Top += iヘッダー部上下補正;  //着店ＣＤ（小）
				cr.Section2.ReportObjects["Text3" ].Top += iヘッダー部上下補正;   //『特殊エリア』テキスト
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 END
				// ヘッダー部：仕分コード
// MOD 2011.12.06 東都）高木 ラベルヘッダ部に発店名・着店名を印字 START
//				cr.Section2.ReportObjects["Field71"].Top  += iヘッダー部上下補正;
				cr.Section2.ReportObjects["Field49"].Top  += iヘッダー部上下補正; // 発店名
				cr.Section2.ReportObjects["Field71"].Top  += iヘッダー部上下補正; // 発店名（バック）
				cr.Section2.ReportObjects["Field81"].Top  += iヘッダー部上下補正; // 着店名
				cr.Section2.ReportObjects["Field82"].Top  += iヘッダー部上下補正; // 着店名（バック）
// MOD 2011.12.06 東都）高木 ラベルヘッダ部に発店名・着店名を印字 END
				cr.Section2.ReportObjects["Field72"].Top  += iヘッダー部上下補正; // 仕分ＣＤ
				// ヘッダー部：指定日、輸送記事
				cr.Section2.ReportObjects["Field2" ].Top  += iヘッダー部上下補正; // 指定日
				cr.Section2.ReportObjects["Field3" ].Top  += iヘッダー部上下補正; // 輸送記事１
				cr.Section2.ReportObjects["Field4" ].Top  += iヘッダー部上下補正; // 輸送記事２
// ADD 2015.01.20 BEVAS)前田 着店名拡大印字対応 START
// いままでField49, Field81に「発：」、「着：」を含めていたが、着店名とまとめて拡大されないよう分離
				cr.Section2.ReportObjects["Text24" ].Top  += iヘッダー部上下補正; // [発]テキスト
				cr.Section2.ReportObjects["Text25" ].Top  += iヘッダー部上下補正; // [着]テキスト
// ADD 2015.01.20 BEVAS)前田 着店名拡大印字対応 END
// MOD 2011.04.26 東都）高木 プリンタごとの補正対応 START
//				//------------------------------------------------------------------
//				// < フッター部：上下位置補正 >
//				//------------------------------------------------------------------
//				// フッター部：出荷年月日
//				cr.Section5.ReportObjects["Field40"].Top  += i補正単位 * (-1);
//				cr.Section5.ReportObjects["Field41"].Top  += i補正単位 * (-1);
//				cr.Section5.ReportObjects["Field42"].Top  += i補正単位 * (-1);
// MOD 2011.04.26 東都）高木 プリンタごとの補正対応 END
				//------------------------------------------------------------------
				// < 各セクション高さ補正 >
				//------------------------------------------------------------------
				// ヘッダー部高さ補正
				cr.Section2.Height  += iヘッダー部上下補正;
				// 詳細部１
				cr.Section3.Height  += i詳細部１上下補正;
				// 詳細部２－１ // 1枚目
				cr.Section9.Height  += i詳細部２上下補正;
				// 詳細部２－２ // 2枚目以降
				cr.Section10.Height += i詳細部２上下補正;
				// フッター部高さ補正
				cr.Section5.Height  += iフッター部上下補正;
				//------------------------------------------------------------------
				// << 左右位置補正 >>
				//------------------------------------------------------------------
				int i左右補正 = i補正単位 * (-4); // 約 1 mm
				//------------------------------------------------------------------
				// < 詳細部１：左右位置補正 >
				//------------------------------------------------------------------
				// 詳細部１：出荷年月日
				cr.Section3.ReportObjects["Field16"].Left += i左右補正;
				cr.Section3.ReportObjects["Field17"].Left += i左右補正;
				cr.Section3.ReportObjects["Field18"].Left += i左右補正;
				//------------------------------------------------------------------
				// < 詳細部２－１：左右位置補正 >
				//------------------------------------------------------------------
				// 詳細部２－１：荷送人郵便番号、住所、名前
				cr.Section9.ReportObjects["Field79"].Left += i左右補正;
				cr.Section9.ReportObjects["Field61"].Left += i左右補正;
				cr.Section9.ReportObjects["Field62"].Left += i左右補正;
				cr.Section9.ReportObjects["Field63"].Left += i左右補正;
				cr.Section9.ReportObjects["Field64"].Left += i左右補正;
				// 詳細部２－１：荷送人担当者
				cr.Section9.ReportObjects["Field45"].Left += i左右補正;
// ADD 2015.01.20 BEVAS)前田 入力欄追加印字対応 START
//				cr.Section9.ReportObjects["Box2"].Left    += i左右補正;    // 受領印枠
				cr.Section9.ReportObjects["Text2"].Left    += i左右補正;   // 受領印文字
				cr.Section9.ReportObjects["Text13"].Left    += i左右補正;  // 保険料背景
				cr.Section9.ReportObjects["Text6"].Left    += i左右補正;   // 保険料(文字)
				cr.Section9.ReportObjects["Field54"].Left    += i左右補正; // 保険料(金額)
				cr.Section9.ReportObjects["Text7"].Left    += i左右補正;   // 円

				cr.Section9.ReportObjects["親荷札kg枠"].Left    += i左右補正;
				cr.Section9.ReportObjects["親荷札cm枠"].Left    += i左右補正;
				cr.Section9.ReportObjects["親荷札才数枠"].Left  += i左右補正;
				cr.Section9.ReportObjects["txt親荷札kg"].Left   += i左右補正;
				cr.Section9.ReportObjects["txt親荷札cm"].Left   += i左右補正;
				cr.Section9.ReportObjects["txt親荷札才数"].Left += i左右補正;
// ADD 2015.01.20 BEVAS)前田 入力欄追加印字対応 END
				//------------------------------------------------------------------
				// < 詳細部２－２：左右位置補正 >
				//------------------------------------------------------------------
				// 詳細部２－２：荷送人郵便番号、住所、名前
				cr.Section10.ReportObjects["Field21"].Left += i左右補正;
				cr.Section10.ReportObjects["Field66"].Left += i左右補正;
				cr.Section10.ReportObjects["Field67"].Left += i左右補正;
				cr.Section10.ReportObjects["Field68"].Left += i左右補正;
				cr.Section10.ReportObjects["Field69"].Left += i左右補正;
				// 詳細部２－２：荷送人担当者
				cr.Section10.ReportObjects["Field20"].Left += i左右補正;
// ADD 2015.01.20 BEVAS)前田 入力欄追加印字対応 START
				cr.Section10.ReportObjects["Text16"].Left    += i左右補正;  // 保険料背景
				cr.Section10.ReportObjects["Text19"].Left    += i左右補正;  // 保険料(文字)
				cr.Section10.ReportObjects["Field56"].Left   += i左右補正;  // 保険料(金額)
				cr.Section10.ReportObjects["Text20"].Left    += i左右補正;  // 円
				
				cr.Section10.ReportObjects["子荷札kg枠"].Left    += i左右補正;
				cr.Section10.ReportObjects["子荷札cm枠"].Left    += i左右補正;
				cr.Section10.ReportObjects["子荷札才数枠"].Left  += i左右補正;
				cr.Section10.ReportObjects["txt子荷札kg"].Left   += i左右補正;
				cr.Section10.ReportObjects["txt子荷札cm"].Left   += i左右補正;
				cr.Section10.ReportObjects["txt子荷札才数"].Left += i左右補正;
// ADD 2015.01.20 BEVAS)前田 入力欄追加印字対応 END
				//------------------------------------------------------------------
				// < フッター部：左右位置補正 >
				//------------------------------------------------------------------
				// フッター部：荷受人電話番号、荷受人コード
				cr.Section5.ReportObjects["Field43"].Left += i左右補正;
				cr.Section5.ReportObjects["Field59"].Left += i左右補正;
				// フッター部：出荷年月日
				cr.Section5.ReportObjects["Field40"].Left += i左右補正;
				cr.Section5.ReportObjects["Field41"].Left += i左右補正;
				cr.Section5.ReportObjects["Field42"].Left += i左右補正;
				// フッター部：荷受人郵便番号
				cr.Section5.ReportObjects["Field80"].Left += i左右補正;
				// フッター部：荷受人住所
				cr.Section5.ReportObjects["Field23"].Left += i左右補正;
				cr.Section5.ReportObjects["Field24"].Left += i左右補正;
				cr.Section5.ReportObjects["Field25"].Left += i左右補正;
				cr.Section5.ReportObjects["Field77"].Left += i左右補正;
				cr.Section5.ReportObjects["Field78"].Left += i左右補正;
				// フッター部：荷受人名前
				cr.Section5.ReportObjects["Field26"].Left += i左右補正;
				cr.Section5.ReportObjects["Field27"].Left += i左右補正;
				// フッター部：荷送人郵便番号、住所、名前
				cr.Section5.ReportObjects["Field5" ].Left += i左右補正;
				cr.Section5.ReportObjects["Field48"].Left += i左右補正;
				cr.Section5.ReportObjects["Field29"].Left += i左右補正;
				cr.Section5.ReportObjects["Field31"].Left += i左右補正;
				cr.Section5.ReportObjects["Field32"].Left += i左右補正;
				// フッター部：荷送人担当者
				cr.Section5.ReportObjects["Field28"].Left += i左右補正;
			}
// MOD 2011.03.03 東都）高木 プリンタごとの補正対応 END


// MOD 2010.03.19 東都）高木 印刷順の指定（仮対応１） START
//			cr.SetDataSource(ds送り状);
//案１ START
//			cr.SetDataSource(ds送り状.table送り状);
//案１ END 
//案２ START ×
//			DataTable dt2 = ds送り状.table送り状.Clone();
//			DataRow[] dra = ds送り状.table送り状.Select();//なぜか印刷順になる//→ならない
//			foreach (DataRow dr in dra){
//				dt2.ImportRow(dr);
//			}
//			dt2.AcceptChanges();
//			cr.SetDataSource(dt2);
//案２ END
//案３ START
			DataView dv = ds送り状.table送り状.DefaultView;
			dv.Sort = "印刷順 ASC";
//			dv.Sort = "印刷順 DESC"; //←逆順にプレビューされた
			DataTable dt2 = ds送り状.table送り状.Clone();
			foreach (DataRowView drv in dv) {
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） START
//				dt2.ImportRow(drv.Row);
				dt2.Rows.Add(drv.Row.ItemArray);
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） END
			}
			dt2.AcceptChanges();
			cr.SetDataSource(dt2);
//案３ END
// MOD 2010.03.19 東都）高木 印刷順の指定（仮対応１） END

			//CrystalReportの印刷設定
			cr.PrintOptions.PrinterName = pdサーマルプリンタ.PrinterSettings.PrinterName;

#if DEBUG
#else
			//印刷
			cr.PrintToPrinter(1, false, 0, 0);
#endif

			//プレビュー表示
#if DEBUG
			プレビュー画面 画面 = new プレビュー画面();
			画面.crv帳票.PrintReport();
			画面.crv帳票.ReportSource = cr;
			画面.ShowDialog();

			//印刷
			cr.PrintToPrinter(1, false, 0, 0);
#endif

// MOD 2011.01.25 東都）高木 「ロードに失敗」対応 START
			try{
				cr.Close();
				cr.Dispose();
			}catch(Exception){
				;
			}
// MOD 2011.01.25 東都）高木 「ロードに失敗」対応 END
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） START
			//明示的領域開放
			cr  = null;
			dv  = null;
			dt2 = null;

			//明示的ガベージコレクタ
			System.GC.Collect();

// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） END
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） START
//// ADD 2005.07.11 東都）小童谷 印刷順の制御 START
//			i印刷順 = 0;
//// ADD 2005.07.11 東都）小童谷 印刷順の制御 END
//
//			ds送り状.Clear();
			送り状データクリア();
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） END
		}		
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） START
		protected void 送り状データクリア()
		{
			i印刷順 = 0;

			ds送り状.Clear();

			//明示的領域開放
			ds送り状 = null;

			//明示的ガベージコレクタ
			System.GC.Collect();

			//送り状データ領域再作成
			ds送り状 = new 送り状データ();
		}
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） END

		protected string 部門出荷日情報更新()
		{
			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sRet = {""};
			try
			{
				// 請求先情報の取得（gs会員ＣＤ、gs部門ＣＤ）
				if(sv_init == null) sv_init = new is2init.Service1();
				sRet = sv_init.Get_syukabi(gsaユーザ,gs会員ＣＤ, gs部門ＣＤ);

				if(sRet[0].Length == 4){
					gs出荷日       = sRet[1];
					if(gs出荷日.Length == 8)
					{
						gdt出荷日 = new DateTime(int.Parse(gs出荷日.Substring(0,4)), 
												int.Parse(gs出荷日.Substring(4,2)),
												int.Parse(gs出荷日.Substring(6)) );
					}
				}
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

			// 正常終了時
			if(sRet[0].Length == 4) return "";

			return sRet[0];
		}

// ADD 2005.07.08 東都）高木 日付変換の変更 START
		protected static string YYYYMMDD変換(DateTime dtDate)
		{
			return dtDate.Year.ToString() + dtDate.ToString("MMdd");
		}

		protected static DateTime YYYYMMDD変換(string sDate)
		{
			sDate = sDate.Replace("/","");
			if(sDate.Length == 6) sDate = "20" + sDate;
			if(sDate.Length != 8) return DateTime.Today;
			
			return new DateTime(int.Parse(sDate.Substring(0,4)), 
								int.Parse(sDate.Substring(4,2)),
								int.Parse(sDate.Substring(6)));
		}
// ADD 2005.07.08 東都）高木 日付変換の変更 END

// ADD 2006.08.10 東都）高木 ＩＣタグ対応ＳＡＴＯ製プリンタ対応 START
		private static byte[] toSJIS_CSV(string sデータ, bool bCRLF)
		{

			byte[] bSJIS;
			if(bCRLF)
				bSJIS = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sデータ + "\n");
			else
				bSJIS = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sデータ + ",");
			return bSJIS;
		}

		private static void 荷物データ出力(FileStream fs, int iCSVData, bool bCRLF)
		{
			byte[] bSJIS;
			string sCSVData = iCSVData.ToString();
			bSJIS = toSJIS_CSV(sCSVData, bCRLF);
			fs.Write(bSJIS, 0 , bSJIS.Length);
		}

		private static void 荷物データ出力(FileStream fs, string sCSVData, bool bCRLF)
		{
			byte[] bSJIS;
			bSJIS = toSJIS_CSV("\"" + sCSVData + "\"", bCRLF);
			fs.Write(bSJIS, 0 , bSJIS.Length);
		}
// ADD 2006.08.10 東都）高木 ＩＣタグ対応ＳＡＴＯ製プリンタ対応 END
// ADD 2008.04.11 ACT Vista対応 START
		protected static void 漢字変換ハッシュ設定()
		{
			string [,] s漢字変換 = CharConvUtility.CharConvUtility.GetCharConvTable();
			gh漢字変換  = new Hashtable();
			for(int iCnt = 0; iCnt < s漢字変換.GetLength(0); iCnt++)
			{
				gh漢字変換.Add(s漢字変換[iCnt,0],s漢字変換[iCnt,1]);
			}
		}

		private static bool 漢字変換(TextBox tex, string name, ref string sUnicode, ref byte[] bSjis)
		{
			string sErrChars = "";
			string sOKHChars = "";
			string sNotHChars = "";
			string sAllChars = "";
			string sBefChars = "";
			string sMessage = "";
			string sMessage2 = "";
			string sAfterCode = null;
			int iNotHash = 0;

			string sOneMozi = "";
			string sOneUni = "";
			System.Text.Encoding enc = System.Text.Encoding.GetEncoding("unicodeFFFE");
			//文字列の中から1文字ずつ取り出す
			System.Globalization.TextElementEnumerator Enumerator = System.Globalization.StringInfo.GetTextElementEnumerator(sUnicode);
			while (Enumerator.MoveNext())
			{
				sOneMozi = Enumerator.Current.ToString();

				//取り出した1文字をバイト型に変換
				byte[] bOneCode = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sOneMozi);
				//バイト型をstring型に変換
				string sRevUnicode = System.Text.Encoding.GetEncoding("shift-jis").GetString(bOneCode);

				if(sOneMozi != sRevUnicode)
				{
					//変換テーブルの8桁対応
					byte [] bytes = enc.GetBytes(sOneMozi);
					sOneUni = BitConverter.ToString(bytes).Replace("-","");
					if(sOneUni.Length == 4)
					{
						sOneUni += sOneUni;
					}
					//漢字変換
					sAfterCode = (string)gh漢字変換[sOneUni];
					if(sAfterCode != null)
					{
						if(sAfterCode == "" || sAfterCode == "4040")
						{
							//変換できない文字を代入
							sNotHChars += sOneMozi;
							sAllChars += sOneMozi;
						}
						else
						{
							//コードから文字を取得
							int iAfter = Convert.ToInt16(sAfterCode,16);
							char cAfter = (char)iAfter;
							string sAfterL = Convert.ToString(cAfter);
							//変換後の文字を代入
							sOKHChars += sAfterL;
							sAllChars += sAfterL;
							//変換前の文字を代入
							sBefChars += sOneMozi;
						}	
					}
					else
					{
						//テーブルに存在しない文字を代入
						sErrChars += sOneMozi;
						sAllChars += sOneMozi;
						sAfterCode = "";
						iNotHash = 1;	
					}	
				}
				else
				{	
					sAllChars += sOneMozi;
				}
			}
			Enumerator.Reset();

			bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sAllChars);
			string sBefMozi = "";
			sBefMozi = sUnicode;

			if(sAfterCode != null)
			{
				if(sNotHChars.Length > 0)
				{
					sMessage = "2";
				}
				else if(sOKHChars.Length > 0)
				{
					sMessage = "1";
				}
			}

			if(iNotHash == 1)
			{
				sMessage2 = "3";
			}

			if(sMessage == "1")
			{
				tex.Text = sAllChars;
				DialogResult result = MessageBox.Show(name + "はVista対応により文字変換をおこないました\n" 
					+ "『" + sBefChars + " → " + sOKHChars + "』", "入力チェック", 
					MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
				if (result == DialogResult.Cancel)
				{
					tex.Text = sBefMozi;
					tex.Focus();
					return false;
				}
				else
				{
					sUnicode = sAllChars;
				}
			}
			if(sMessage == "2")
			{
				MessageBox.Show(name + "はVista対応により文字変換がおこなえませんでした\n"
					+ "『" + sNotHChars + " → ? 』",
					"入力チェック",MessageBoxButtons.OK);
				if(sMessage2 != "3")
				{
					tex.Focus();
					return false;
				}
			}
			if(sMessage2 == "3")
			{
				MessageBox.Show(name + "に使用できない文字があります\n"
					+ "『" + sErrChars + " → ? 』",
					"入力チェック",MessageBoxButtons.OK);
				tex.Focus();
				return false;
			}
			return true;
		}
		
		protected static bool 漢字変換_CSV(ref string data, ref string err)
		{
			string sUnicode = data;
			string sErrChars = "";
			string sOKHChars = "";
			string sAllChars = "";
			string sAfterCode = null;

			string sOneMozi = "";
			string sOneUni = "";
			System.Text.Encoding enc = System.Text.Encoding.GetEncoding("unicodeFFFE");
			//文字列の中から1文字ずつ取り出す
			System.Globalization.TextElementEnumerator Enumerator = System.Globalization.StringInfo.GetTextElementEnumerator(sUnicode);
			while (Enumerator.MoveNext())
			{
				sOneMozi = Enumerator.Current.ToString();

				//取り出した1文字をバイト型に変換
				byte[] bOneCode = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sOneMozi);
				//バイト型をstring型に変換
				string sRevUnicode = System.Text.Encoding.GetEncoding("shift-jis").GetString(bOneCode);

				if(sOneMozi != sRevUnicode)
				{
					//変換テーブルの8桁対応
					byte [] bytes = enc.GetBytes(sOneMozi);
					sOneUni = BitConverter.ToString(bytes).Replace("-","");
					if(sOneUni.Length == 4)
					{
						sOneUni += sOneUni;
					}
					//漢字変換
					sAfterCode = (string)gh漢字変換[sOneUni];
					if(sAfterCode != null)
					{
						if(sAfterCode == "" || sAfterCode == "4040")
						{
							//変換できない文字を代入
							sErrChars += sOneMozi;
							sAllChars += sOneMozi;
						}
						else
						{
							//コードから文字を取得
							int iAfter = Convert.ToInt16(sAfterCode,16);
							char cAfter = (char)iAfter;
							string sAfterL = Convert.ToString(cAfter);
							//変換後の文字を代入
							sOKHChars += sAfterL;
							sAllChars += sAfterL;
						}	
					}
					else
					{
						//テーブルに存在しない文字を代入
						sErrChars += sOneMozi;
						sAllChars += sOneMozi;
						sAfterCode = "";	
					}	
				}
				else
				{	
					sAllChars += sOneMozi;
				}
			}
			Enumerator.Reset();

			if(sErrChars.Length > 0)
			{
				data = sAllChars;
				err = sErrChars;
				return false;
			}

			data = sAllChars;
			err = sErrChars;
			return true;
		}
// ADD 2008.04.11 ACT Vista対応 END
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 START
		// Microsoft.VisualBasic.Strings.StrConv(string, Microsoft.VisualBasic.VbStrConv.Wide, int);
		[DllImport("kernel32.dll",CharSet=CharSet.Unicode, SetLastError = true)] 
		private static extern int LCMapString(int Locale, uint dwMapFlags, string lpSrcStr, int cchSrc, [MarshalAs(UnmanagedType.LPArray)]  char[] lpDestStr, int cchDest);
		private static string MapString(string source)
		{
			char[] buffer = new char[source.Length * 2];
			//StringBuilder buffer = new StringBuilder(source.Length*2);
			int len = LCMapString((int)0x0411, (uint)0x00800000, source, source.Length, buffer, buffer.Length);
			if (len < 0){
				throw new ArgumentException("\"LCMAP_SORTKEY\" is not support ");
			}
			return new String(buffer,0,len);
		}
		protected bool 全角変換後チェック(string sSrc, string sDes)
		{
			// 変換後すべて全角文字の場合
			if(!全角チェック(sDes)){
#if DEBUG
				MessageBox.Show(
					"2883:全角変換に失敗\n"
					+ "半角文字がまざっていました"
					, "["+sSrc+"]"
					, MessageBoxButtons.OK);
#endif
				return false;
			}

			// 変換後の文字数に誤りがある場合
			int i濁音文字数 = 0;
			for(int iCnt = 0; iCnt < sSrc.Length; iCnt++){
				if(sSrc[iCnt] == 'ﾞ'){
					i濁音文字数++;
					continue;
				}
				if(sSrc[iCnt] == 'ﾟ'){
					i濁音文字数++;
					continue;
				}
			}
			if(sDes.Length >= sSrc.Length - i濁音文字数){
//				sSrc = sDes2;
				return true;
			}
#if DEBUG
			MessageBox.Show(
				"2875:全角変換に失敗\n"
				+ "文字長["+sSrc.Length+"]→["+sDes.Length+"]"
				, "["+sSrc+"]"
				, MessageBoxButtons.OK);
#endif
			return false;
		}
		protected bool 全角変換チェック(ref string data, ref string err)
		{
			// すべて全角文字の場合は、リターン
			if(全角チェック(data)){
				return true;
			}

			// 半角[\]が存在する場合は、全角[￥]に変換
			if(data.IndexOf('\\') >= 0){
				data = data.Replace('\\','￥');
			}

			// すべて全角文字の場合は、リターン
			if(全角チェック(data)){
				return true;
			}

			bool   bRet = true;
			string sRet = "";
			// 全角文字に変換
			try{
				sRet = Microsoft.VisualBasic.Strings.StrConv(data
							, Microsoft.VisualBasic.VbStrConv.Wide
							, 0x0411);
#if DEBUG
			}catch(Exception ex){
				// StrConvに失敗
				MessageBox.Show(
					"2798:StrConvに失敗（Exception）\n"
					+ ex.Message
					, "["+data+"]"
					, MessageBoxButtons.OK);
#else
			}catch(Exception){
				// StrConvに失敗
#endif
				bRet = false;
			}

			// 正常に変換できた場合
			if(bRet){
				// 変換後すべて全角文字の場合は、リターン
				if(全角変換後チェック(data, sRet)){
					data = sRet;
					return true;
				}
				bRet = false;
			}
			
			try{
				string sRet2 = "";
				sRet2 = MapString(data);
				// 変換後すべて全角文字の場合は、リターン
				if(全角変換後チェック(data, sRet2)){
					data = sRet2;
					return true;
				}
				bRet = false;
#if DEBUG
				MessageBox.Show(
					"2866:MapStringに失敗\n"
					+ "[" + sRet2 + "]"
					, "["+data+"]"
					, MessageBoxButtons.OK);
#endif
#if DEBUG
			}catch(Exception ex){
				MessageBox.Show(
					"2892:MapStringに失敗（Exception）\n"
					+ ex.Message
					, "["+data+"]"
					, MessageBoxButtons.OK);
#else
			}catch(Exception){
#endif
			}

			// １文字ずつ変換しチェックする
//保留		bRet = true;
			sRet = "";
			string sErrChars = "";
			string sData = "";
			string sData2 = "";
			string sWide = "";
			string sRevUnicode = "";
			byte[] bSjis;

			for(int iCnt = 0; iCnt < data.Length; iCnt++){
				sData = "";
				sData = data.Substring(iCnt,1);
				if(全角チェック(sData)){
					sRet += sData;
					continue;
				}
				// 濁音対応
				sData2 = "";
				if(iCnt+1 < data.Length){
					sData2 = data.Substring(iCnt+1,1);
				}
				try{
					bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sData);
					// ＳＪＩＳバイト変換エラー時：スキップして次の文字へ
					if(bSjis == null || bSjis.Length == 0){
						sErrChars += sData;
						bRet = false;
#if DEBUG
						MessageBox.Show(
							"2827:GetEncoding(shift-jis).GetBytesに失敗（０バイト）"
							+ "[" + sData + "]"
							, "["+data+"]"
							, MessageBoxButtons.OK);
#endif
						continue;
					}
					////////////////////////////////////////////
					// ２バイト文字（全角文字）の場合：結合して次の文字へ
					////////////////////////////////////////////
					if(bSjis.Length == 2){
						sRet += sData;
						continue;
					}
					// １バイト文字以外の場合：スキップして次の文字へ
					if(bSjis.Length != 1){
						sErrChars += sData;
#if DEBUG
						MessageBox.Show(
							"2846:GetEncoding(shift-jis).GetBytesに失敗（１バイト以外）"
							+ "[" + sData + "]"
							+ "[" + bSjis.Length + "]"
							, "["+data+"]"
							, MessageBoxButtons.OK);
#endif
						bRet = false;
						continue;
					}
					////////////////////////////////////////////
					// １バイト文字（半角文字）の場合
					////////////////////////////////////////////
					// 濁音対応
					if(sData2 == "ﾞ" || sData2 == "ﾟ"){
						sData += sData2;
						iCnt++;
					}
					// 全角文字に変換
					sWide = "";
					try{
						sWide = Microsoft.VisualBasic.Strings.StrConv(sData
									, Microsoft.VisualBasic.VbStrConv.Wide
									, 0x0411);
#if DEBUG
					}catch(Exception ex){
						MessageBox.Show(
							"2872:StrConvに失敗（Exception）"
							+ "[" + sData + "]\n"
							+ ex.Message
							, "["+data+"]"
							, MessageBoxButtons.OK);
#else
					}catch(Exception){
#endif
						sErrChars += sData;
						bRet = false;
						continue;
					}
					// 全角文字変換エラー時：スキップして次の文字へ
					if(sWide == null || sWide.Length != 1){
						sErrChars += sData;
						bRet = false;
#if DEBUG
						MessageBox.Show(
							"2886:StrConvに失敗（１文字以外）"
							+ "[" + sData + "]"
							+ "[" + sWide.Length + "]"
							, "["+data+"]"
							, MessageBoxButtons.OK);
#endif
						continue;
					}
					bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sWide);
					// ＳＪＩＳバイト変換エラー時：スキップして次の文字へ
					if(bSjis == null || bSjis.Length == 0){
						sErrChars += sData;
						bRet = false;
#if DEBUG
						MessageBox.Show(
							"2900:GetEncoding(shift-jis).GetBytesに失敗（０バイト）"
							+ "[" + sData + "]"
							, "["+data+"]"
							, MessageBoxButtons.OK);
#endif
						continue;
					}
					// 変換後２バイト文字でなかった場合：スキップして次の文字へ
					if(bSjis.Length != 2){
						sErrChars += sData;
#if DEBUG
						MessageBox.Show(
							"2945:GetEncoding(shift-jis).GetBytesに失敗（２バイト以外）"
							+ "[" + sData + "]"
							+ "[" + bSjis.Length + "]"
							, "["+data+"]"
							, MessageBoxButtons.OK);
#endif
						bRet = false;
						continue;
					}
					//バイト型をstring型に変換
					sRevUnicode = "";
					sRevUnicode = System.Text.Encoding.GetEncoding("shift-jis").GetString(bSjis);
					// 逆変換後文字が異なる場合：スキップして次の文字へ
					if(sRevUnicode != sWide){
						sErrChars += sData;
#if DEBUG
						MessageBox.Show(
							"2961:GetEncoding(shift-jis).GetBytesに失敗（逆変換に失敗）"
							+ "[" + sData + "]"
							, "["+data+"]"
							, MessageBoxButtons.OK);
#endif
						bRet = false;
						continue;
					}
					sRet += sWide;
#if DEBUG
				}catch(Exception ex){
					MessageBox.Show(
						"2973:失敗（Exception）\n"
						+ "[" + sData + "]\n"
						+ ex.Message
						, "["+data+"]"
						, MessageBoxButtons.OK);
#else
				}catch(Exception){
#endif
					bRet = false;
					break;
				}
			}

//保留			if(bRet){
//保留				data = sRet;
//保留				return true;
//保留			}

			if(sErrChars.Length == 0){
				err = data;
			}else{
				err  = sErrChars;
			}

			return bRet;
		}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 END
// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
		protected void ＤＰＩ表示サイズ変換()
		{
			if(giDisplayDpiX == 0 || giDisplayDpiY == 0){
				//解像度(dpi)を取得.
				Graphics g = this.CreateGraphics();
				giDisplayDpiX = (int)g.DpiX;
				giDisplayDpiY = (int)g.DpiY;
				g.Dispose();
			}
//			int iDisplayX = 0; 
//			int iDisplayY = 0; 
//			if(giDisplayDpiX != 96 || giDisplayDpiY != 96){
//				iDisplayX  = this.Width  * giDisplayDpiX / 96;
//				iDisplayY  = this.Height * giDisplayDpiY / 96;
//				this.MaximumSize = new Size(iDisplayX, iDisplayY);
//				this.Width  = iDisplayX;
//				this.Height = iDisplayY;
			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
				this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			}
		}
// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 END
// MOD 2010.09.02 東都）高木 選択時のずれの対応 START
		private string gsColsWidth = "";
		protected void カラム幅の補正(AxGTABLE32V2Lib.AxGTable32 ax一覧)
		{
			if(giDisplayDpiX == 96){
				return;
			}
			if(gsColsWidth.Length > 0){
				ax一覧.ColsWidth = gsColsWidth;
				return;
			}

			double d補正値１ = 0.95; // 記事検索など
			double d補正値２ = 0.90; // 記事検索など
			if(this.Text == "is-2 請求先情報メンテナンス"){
				d補正値１ = 0.99;
				d補正値２ = 0.90;
			}
			if(this.Text == "is-2 ご依頼主検索"){
				d補正値１ = 0.99;
				d補正値２ = 0.60;
			}

			string sColsWidth = ax一覧.ColsWidth;
			string sWork = "";
			try{
				string[] sCols = sColsWidth.Split('|');
				for(int iCnt = 0; iCnt < sCols.Length; iCnt++){
					string sCol = sCols[iCnt].Trim();
					if(sCol == ""){
						sWork += "";
					}else if(sCol == "0"){
						sWork += "0";
					}else{
						try{
							double dCol = double.Parse(sCol);
							// 小数第２位を切り上げ
							sWork += ((int)(dCol*10*d補正値１+d補正値２))/10;
						}catch(Exception){
							sWork += sCol;
						}
					}
					if(iCnt != sCols.Length - 1){
						sWork += "|";
					}
				}
			}catch(Exception){
				sWork = sColsWidth;
			}
			gsColsWidth = sWork;
			ax一覧.ColsWidth = gsColsWidth;
			return ;
		}
// MOD 2010.09.02 東都）高木 選択時のずれの対応 END
// MOD 2011.03.03 東都）高木 プリンタごとの補正対応 START
		private void CheckReportDefOut(Section sec)
		{
			ReportObjects robj = sec.ReportObjects;
			
			string[] sTypeName = new string[robj.Count];
			string[] sName     = new string[robj.Count];
			string[] sValue    = new string[robj.Count];
			string[] sFontName = new string[robj.Count];
			string[] sFontSize = new string[robj.Count];
			string[] sFontStyle = new string[robj.Count];
			int[]    iTop      = new int[robj.Count];
			int[]    iHeight   = new int[robj.Count];
			int[]    iLeft     = new int[robj.Count];
			int[]    iWidth    = new int[robj.Count];
			object      oTmp   = null;
			FieldObject fldTmp = null;
			TextObject  texTmp = null;
			BoxObject   boxTmp = null;

			System.IO.FileStream fs = null;
			try{
				fs = new FileStream(
					Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
					+ @"\ラベル定義_is2"
					+ "_" + DateTime.Now.ToString("yyyyMMdd")
					+ "_" + gsaユーザ[3]
					+ ".txt", 
					FileMode.Append, FileAccess.Write,FileShare.Read);
				荷物データ出力(fs, "["+sec.Kind+"]", false);
				荷物データ出力(fs, sec.Name, false);
				荷物データ出力(fs, sec.Height, true);

				int iPos = 0;
				while(robj.MoveNext()){
					oTmp = robj.Current;
					sTypeName[iPos] = oTmp.GetType().ToString();
					if(oTmp is FieldObject){
						fldTmp = (FieldObject)robj.Current;
						sName [iPos] = fldTmp.Name;
						sValue[iPos] = "["+fldTmp.DataSource.Name+"]";
						sFontName[iPos]  = fldTmp.Font.Name;
						sFontSize[iPos]  = fldTmp.Font.Size.ToString();
						sFontStyle[iPos] = "";
						if(fldTmp.Font.Bold){
							sFontStyle[iPos] += "Bold ";
						}
						iTop[iPos]    = fldTmp.Top;
						iLeft[iPos]   = fldTmp.Left;
						iHeight[iPos] = fldTmp.Height;
						iWidth[iPos]  = fldTmp.Width;
					}else if(oTmp is TextObject){
						texTmp = (TextObject)robj.Current;
						sName [iPos] = texTmp.Name;
						sValue[iPos] = texTmp.Text;
						sFontName[iPos]  = texTmp.Font.Name;
						sFontSize[iPos]  = texTmp.Font.Size.ToString();
						sFontStyle[iPos] = "";
						if(texTmp.Font.Bold){
							sFontStyle[iPos] += "Bold ";
						}
						iTop[iPos]    = texTmp.Top;
						iLeft[iPos]   = texTmp.Left;
						iHeight[iPos] = texTmp.Height;
						iWidth[iPos]  = texTmp.Width;
					}else if(oTmp is BoxObject){
						boxTmp = (BoxObject)robj.Current;
						sName [iPos] = boxTmp.Name;
						sValue[iPos] = "";
						sFontName[iPos]  = "";
						sFontSize[iPos]  = "";
						sFontStyle[iPos] = "";
						iTop[iPos]    = boxTmp.Top;
						iLeft[iPos]   = boxTmp.Left;
						iHeight[iPos] = boxTmp.Height;
						iWidth[iPos]  = boxTmp.Width;
					}else{
						荷物データ出力(fs, sTypeName[iPos], true);
						iPos++;
						continue;
					}
					荷物データ出力(fs, sName[iPos], false);
					荷物データ出力(fs, sValue[iPos], false);
					荷物データ出力(fs, sFontName[iPos], false);
					荷物データ出力(fs, sFontSize[iPos], false);
					荷物データ出力(fs, sFontStyle[iPos], false);
					荷物データ出力(fs, iTop[iPos], false);
					荷物データ出力(fs, iLeft[iPos], false);
					荷物データ出力(fs, iHeight[iPos], false);
					荷物データ出力(fs, iWidth[iPos], true);
					iPos++;
				}
			}catch(Exception ex){
				throw new Exception(ex.Message);
			}finally{
				if(fs != null) fs.Close();
			}
			return;
		}
		private void SetRptFontSize(ReportObject robj, double dSize)
		{
			FieldObject fldTmp = null;
			Font fntTmp = null;
			try{
				if(robj is FieldObject){
					fldTmp = (FieldObject)robj;
//					fntTmp = new Font(fldTmp.Name, fldTmp.Font.Size, FontStyle.Bold);
					fntTmp = new Font(fldTmp.Name, fldTmp.Font.Size);
					fldTmp.ApplyFont(fntTmp);
				}
			}catch(Exception ex){
				throw new Exception(ex.Message);
			}
			return;
		}
// MOD 2011.03.03 東都）高木 プリンタごとの補正対応 END

// ADD 2015.03.05 BEVAS) 前田　支店止め対応 START
		protected string 全角数字変換(string sData)
		{
			// 桁数チェック
			if(sData.Length != 3)
			{
				return "店所コードが３桁ではありません。";
			}

			string wk = "";
			for(int i = 0; i < sData.Length; i++)
			{
				string sData_letter = sData.Substring(i, 1);
				switch(sData_letter)
				{
					case "0":
						sData_letter = sData_letter.Replace("0", "０");
						break;
					case "1":
						sData_letter = sData_letter.Replace("1", "１");
						break;
					case "2":
						sData_letter = sData_letter.Replace("2", "２");
						break;
					case "3":
						sData_letter = sData_letter.Replace("3", "３");
						break;
					case "4":
						sData_letter = sData_letter.Replace("4", "４");
						break;
					case "5":
						sData_letter = sData_letter.Replace("5", "５");
						break;
					case "6":
						sData_letter = sData_letter.Replace("6", "６");
						break;
					case "7":
						sData_letter = sData_letter.Replace("7", "７");
						break;
					case "8":
						sData_letter = sData_letter.Replace("8", "８");
						break;
					case "9":
						sData_letter = sData_letter.Replace("9", "９");
						break;
				}
				wk += sData_letter;
				sData_letter = "";
			}

			// 変換後の店所コードが不正であった場合
			if(wk.Length != 3)
			{
				return "変換後の店所コードが、半角数字３桁ではありません。不正な形式です。";
			}

			return wk;
		}
// ADD 2015.03.05 BEVAS) 前田　支店止め対応 END

// MOD 2015.05.07 BEVAS) 前田 王子CM14J郵便番号存在チェック対応 START
		protected string[] ＣＭ１４郵便番号存在チェック(string s郵便番号) 
		{
			string[] sRet = {""};
 
			if (gs会員ＣＤ.Substring(0,1) != "J")
			{
				// 福通の郵便番号マスタをチェック
				if(sv_address == null) sv_address = new is2address.Service1();
				sRet = sv_address.Get_byPostcode2(gsaユーザ,s郵便番号);
			}
			else
			{
				// 王子の郵便番号マスタをチェック
				if(sv_oji == null) sv_oji = new is2oji.Service1();
				sRet = sv_oji.Get_byPostcode2(gsaユーザ,s郵便番号);
			}
			return sRet;
		}
// MOD 2015.05.07 BEVAS) 前田 王子CM14J郵便番号存在チェック対応 END

// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 START
		protected void 荷札控え印刷指示(string[] sData, int i開始, int i終了)
		{
			gb印刷 = true;
			try
			{
				if(gs利用者部門店所ＣＤ == null || gs利用者部門店所ＣＤ.Length == 0)
				{
					gs利用者部門店所ＣＤ = "";
					gs利用者部門店所ＣＤ = 部門店所取得(gs利用者部門ＣＤ);
				}

				//印刷データの作成
				String[] sPrintKey = new string[5];
				sPrintKey[0] = gs会員ＣＤ;
				sPrintKey[1] = gs部門ＣＤ;
				sPrintKey[2] = sData[0];	//登録日
				sPrintKey[3] = sData[1];	//ジャーナルＮＯ
				sPrintKey[4] = gs利用者部門店所ＣＤ;

				if(sv_print == null) sv_print = new is2print.Service1();
				if(sv_oji == null) sv_oji = new is2oji.Service1();
				String[] sPrintData;
				if (gs会員ＣＤ.Substring(0,1) != "J")
				{
					sPrintData = sv_print.Get_InvoicePrintData(gsaユーザ,sPrintKey);
				}
				else
				{
					sPrintData = sv_oji.Get_InvoicePrintData(gsaユーザ,sPrintKey);
				}
				
				if (!sPrintData[0].Equals("正常終了"))
				{
					throw new Exception(sPrintData[0]);
				}

				if(gs利用者部門店所ＣＤ == null || gs利用者部門店所ＣＤ.Length == 0)
				{
					gs利用者部門店所ＣＤ = 部門店所取得(gs利用者部門ＣＤ);
				}

				if(gs利用者部門店所ＣＤ == null || gs利用者部門店所ＣＤ.Length == 0)
				{
					// 何もしない
				}
				else
				{
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 START
//					// 店所と部門店所が異なる場合(集荷店取得エラー)は、印刷しない
//					if(!gs利用者部門店所ＣＤ.Trim().Equals(sPrintData[14].Trim().Substring(1, 3)))
//					{
//						gb印刷 = false;
//						return;
//					}
					//社内伝の場合は、店所と部門店所が異なってもよい
					if(!gs利用者部門店所ＣＤ.Equals("044"))
					{
						// 店所と部門店所が異なる場合(集荷店取得エラー)は、印刷しない
						if(!gs利用者部門店所ＣＤ.Trim().Equals(sPrintData[14].Trim().Substring(1, 3)))
						{
							gb印刷 = false;
							return;
						}
					}
				}
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 END
//				//送り状発行のチェック
//				if (!sPrintData[33].Equals("1")) // 送り状発行済ＦＧ
//				{
//					//送り状が未発行の場合。送り状番号の採番
//					String[] sGetKey = new string[4];
//					sGetKey[0] = gs会員ＣＤ;
//					sGetKey[1] = gs部門ＣＤ;
//					// 輸送商品によって値を変更
//					sGetKey[2] = sPrintData[32]; //元着区分 + "0" or "1"
//					// グローバル対応（出荷日、発店の非表示）
//					if(sPrintData[14].Substring(1, 3) == "047")
//					{
//						sGetKey[2] = sPrintData[32].Substring(0,1) + "G"; //元着区分 + "G"
//					}
//					sGetKey[3] = gs利用者ＣＤ;
//
//					//送り状番号更新
//					//（送り状番号、送り状発行済ＦＧ、状態、発店の更新）
//					String[] sSetKey = new string[6];
//					sSetKey[0] = gs会員ＣＤ;
//					sSetKey[1] = gs部門ＣＤ;
//					sSetKey[2] = sData[0];       // 登録日
//					sSetKey[3] = sData[1];       // ジャーナルＮＯ
//					sSetKey[4] = sPrintData[11]; // 送り状番号
//					sSetKey[5] = gs利用者ＣＤ;
//
//					if(sv_print == null) sv_print = new is2print.Service1();
//					if(sv_oji == null) sv_oji = new is2oji.Service1();
//					String[] sSetData;
//					if (gs会員ＣＤ.Substring(0,1) != "J")
//					{
//						sSetData = sv_print.Set_InvoiceNo(gsaユーザ,sSetKey);
//
//					}
//					else
//					{
//						sSetData = sv_oji.Set_InvoiceNo(gsaユーザ,sSetKey);
//					}
//					
//					if (!sSetData[0].Equals("正常終了"))
//					{
//						throw new Exception(sSetData[0]);
//					}
//				}

				if(gsオプション[18].Equals("1"))
				{
					sPrintData[5] = sPrintData[5].TrimEnd(); // 荷受人住所１
					sPrintData[6] = sPrintData[6].TrimEnd(); // 荷受人住所２
					sPrintData[7] = sPrintData[7].TrimEnd(); // 荷受人住所３
					sPrintData[8] = sPrintData[8].TrimEnd(); // 荷受人名前１
					sPrintData[9] = sPrintData[9].TrimEnd(); // 荷受人名前２

					sPrintData[18] = sPrintData[18].TrimEnd(); // 荷送人住所１
					sPrintData[19] = sPrintData[19].TrimEnd(); // 荷送人住所２
					sPrintData[21] = sPrintData[21].TrimEnd(); // 荷送人名前１
					sPrintData[22] = sPrintData[22].TrimEnd(); // 荷送人名前２
					sPrintData[34] = sPrintData[34].TrimEnd(); // 担当者
					
					sPrintData[29] = sPrintData[29].TrimEnd(); // 品名記事１
					sPrintData[30] = sPrintData[30].TrimEnd(); // 品名記事２
					sPrintData[31] = sPrintData[31].TrimEnd(); // 品名記事３
					if(sPrintData.Length > 42)
					{
						sPrintData[42] = sPrintData[42].TrimEnd(); // 品名記事４
						sPrintData[43] = sPrintData[43].TrimEnd(); // 品名記事５
						sPrintData[44] = sPrintData[44].TrimEnd(); // 品名記事６
					}
				}
				else
				{
					sPrintData[5] = sPrintData[5].Trim(); // 荷受人住所１
					sPrintData[6] = sPrintData[6].Trim(); // 荷受人住所２
					sPrintData[7] = sPrintData[7].Trim(); // 荷受人住所３
					sPrintData[8] = sPrintData[8].Trim(); // 荷受人名前１
					sPrintData[9] = sPrintData[9].Trim(); // 荷受人名前２

					sPrintData[18] = sPrintData[18].Trim(); // 荷送人住所１
					sPrintData[19] = sPrintData[19].Trim(); // 荷送人住所２
					sPrintData[21] = sPrintData[21].Trim(); // 荷送人名前１
					sPrintData[22] = sPrintData[22].Trim(); // 荷送人名前２
					sPrintData[34] = sPrintData[34].Trim(); // 担当者
					
					sPrintData[29] = sPrintData[29].Trim(); // 品名記事１
					sPrintData[30] = sPrintData[30].Trim(); // 品名記事２
					sPrintData[31] = sPrintData[31].Trim(); // 品名記事３
					if(sPrintData.Length > 42)
					{
						sPrintData[42] = sPrintData[42].Trim(); // 品名記事４
						sPrintData[43] = sPrintData[43].Trim(); // 品名記事５
						sPrintData[44] = sPrintData[44].Trim(); // 品名記事６
					}
				}

				if(gsプリンタ種類 == "S0004")
				{
					string sパス名 = "C:\\";
					string sファイル名 = "荷物データファイル.csv";
					try
					{
						System.IO.FileStream fs = new FileStream(sパス名 + sファイル名, 
							FileMode.Append, FileAccess.Write,FileShare.Read);
						try
						{
							string sCSVData = "";
							for (int iCnt = 0; iCnt < int.Parse(sPrintData[23]); iCnt++)
							{
								int    i連番 = iCnt + 1;
								string s連番 = i連番.ToString();
								string s荷物番号 = sPrintData[11].Substring(4) + s連番.PadLeft(2, '0');

								//荷物番号
								sCSVData = s荷物番号;
								荷物データ出力(fs, sCSVData, false);
								//荷受人電話番号
								sCSVData = "(" + sPrintData[2] + ")" + sPrintData[3] + "-" + sPrintData[4];
								if(sPrintData[2].Replace("0","").Trim().Length == 0
									&& sPrintData[3].Replace("0","").Trim().Length == 0
									&& sPrintData[4].Replace("0","").Trim().Length == 0)
								{
									sCSVData = " ";
								}
								荷物データ出力(fs, sCSVData, false);

								//荷受人住所の都道府県、市区町村、その他の分割
								string s住所編集  = 住所編集(sPrintData[5]);
								string[] s住所分割 = s住所編集.Split(' ');

								//荷受人住所県
								荷物データ出力(fs, s住所分割[0], false);

								//荷受人住所市
								if (s住所分割.Length > 1)
								{
									荷物データ出力(fs, s住所分割[1], false);
								}
								else
								{
									荷物データ出力(fs, "", false);
								}
								//荷受人住所町
								if (s住所分割.Length > 2)
								{
									荷物データ出力(fs, s住所分割[2], false);
								}
								else
								{
									荷物データ出力(fs, "", false);
								}

								荷物データ出力(fs, sPrintData[5], false);		//荷受人住所１
								荷物データ出力(fs, sPrintData[6], false);		//荷受人住所２
								荷物データ出力(fs, sPrintData[7], false);		//荷受人住所３
								荷物データ出力(fs, sPrintData[8], false);		//荷受人名前１
								荷物データ出力(fs, sPrintData[9], false);		//荷受人名前２

								if(sPrintData[14].Substring(1, 3) == "047")
								{
									荷物データ出力(fs, "", false);	//出荷日年
									荷物データ出力(fs, "", false);	//出荷日月
									荷物データ出力(fs, "", false);	//出荷日日
								}
								else
								{
									荷物データ出力(fs, sPrintData[10], false);	//出荷日年
									//出荷日月
									if(sPrintData[10].Substring(4, 1) == "0")
										sCSVData = " " + sPrintData[10].Substring(5, 1);
									else
										sCSVData = sPrintData[10].Substring(4, 2);
									荷物データ出力(fs, sCSVData, false);
									//出荷日日
									if(sPrintData[10].Substring(6, 1) == "0")
										sCSVData = " " + sPrintData[10].Substring(7, 1);
									else
										sCSVData = sPrintData[10].Substring(6, 2);
									荷物データ出力(fs, sCSVData, false);
								}
								//送り状番号
								sCSVData = sPrintData[11].Substring(4,3) + "-" + sPrintData[11].Substring(7,4) + "-" + sPrintData[11].Substring(11,4);
								荷物データ出力(fs, sCSVData, false);
								//バーコード
								sCSVData = "A" + s荷物番号 + "A";
								荷物データ出力(fs, sCSVData, false);
								//着店ＣＤ
								if(sPrintData[13].Length == 0)
									sCSVData = "";
								else
									sCSVData = sPrintData[13].Substring(1, 1) + "-" + sPrintData[13].Substring(2,2);
								荷物データ出力(fs, sCSVData, false);
								//発店ＣＤ
								if(sPrintData[14].Substring(1, 3) == "047")
								{
									荷物データ出力(fs, "", false);
								}
								else
								{
									荷物データ出力(fs, sPrintData[14].Substring(1, 3), false);
								}
								//荷送人電話番号
								sCSVData = "(" + sPrintData[15] + ")" + sPrintData[16] + "-" + sPrintData[17];
								荷物データ出力(fs, sCSVData, false);

								荷物データ出力(fs, 住所編集(sPrintData[18]), false);	//荷送人住所１
								荷物データ出力(fs, sPrintData[19], false);				//荷送人住所２
								荷物データ出力(fs, sPrintData[18], false);				//荷送人住所３
								荷物データ出力(fs, sPrintData[21], false);				//荷送人名前１
								荷物データ出力(fs, sPrintData[22], false);				//荷送人名前２
								荷物データ出力(fs, sPrintData[34], false);				//担当者

								荷物データ出力(fs, int.Parse(sPrintData[23]), false);	//個数
								荷物データ出力(fs, i連番, false);						//連番
								荷物データ出力(fs, int.Parse(sPrintData[24]), false);	//重量

								//保険料
								int iCSVData = int.Parse(sPrintData[25]) * 10;
								if(iCSVData > 0 && iCSVData < 50) iCSVData = 50;
								荷物データ出力(fs, iCSVData, false);

								//指定日
								string s指定月;
								string s指定日;
								if (sPrintData[26] != null && !sPrintData[26].Equals("") && !sPrintData[26].Equals("0"))
								{
									if(sPrintData[26].Substring(4, 1) == "0")
										s指定月 = " " + sPrintData[26].Substring(5, 1);
									else
										s指定月 = sPrintData[26].Substring(4, 2);

									if(sPrintData[26].Substring(6, 1) == "0")
										s指定日 = " " + sPrintData[26].Substring(7, 1);
									else
										s指定日 = sPrintData[26].Substring(6, 2);

									sCSVData     = s指定月 + "月" + s指定日 + "日";
									if (sPrintData[36].Equals("0"))
										sCSVData += "必着";
									else if (sPrintData[36].Equals("1"))
										sCSVData += "指定";
									荷物データ出力(fs, sCSVData, false);
								}
								else
								{
									荷物データ出力(fs, "", false);
								}

								//お客様番号
								if(sPrintData[35].Length == 0)
									荷物データ出力(fs, "", false);
								else
									荷物データ出力(fs, "お客様番号:" + sPrintData[35], false);

								荷物データ出力(fs, sPrintData[27], false);		//輸送記事１
								荷物データ出力(fs, sPrintData[28], false);		//輸送記事２
								荷物データ出力(fs, sPrintData[29], false);		//品名記事１
								荷物データ出力(fs, sPrintData[30], false);		//品名記事２
								荷物データ出力(fs, sPrintData[31], false);		//品名記事３
								if(iCnt == 0)
								{
									荷物データ出力(fs, sPrintData[27], false);	//ラベル３輸送記事１
									荷物データ出力(fs, sPrintData[28], false);	//ラベル３輸送記事２
									荷物データ出力(fs, sPrintData[29], false);	//ラベル３品名記事１
									荷物データ出力(fs, sPrintData[30], false);	//ラベル３品名記事２
									荷物データ出力(fs, sPrintData[31], false);	//ラベル３品名記事３
									荷物データ出力(fs, "", true);				//ラベル３個口表記
								}
								else
								{
									荷物データ出力(fs, "", false);				//ラベル３輸送記事１
									荷物データ出力(fs, "", false);				//ラベル３輸送記事２
									荷物データ出力(fs, "", false);				//ラベル３品名記事１
									荷物データ出力(fs, "", false);				//ラベル３品名記事２
									荷物データ出力(fs, "", false);				//ラベル３品名記事３
									荷物データ出力(fs, "荷札" + s連番.PadLeft(3,' ') + "個目", true);
									//ラベル３個口表記
								}
							}
						}
						catch(Exception ex)
						{
							throw new Exception(ex.Message);
						}
						fs.Close();
					}
					catch(Exception ex)
					{
						throw new Exception(ex.Message);
					}
					return;
				}

				// 個数(sPrintData[23])は使用せず、１回のみ印刷する
//				int iLabel終了 = int.Parse(sPrintData[23]);
				int iLabel終了 = 1;
				if(iLabel終了 > i終了)
				{
					iLabel終了 = i終了;
				}

				for (int iPage = i開始; iPage <= iLabel終了; iPage++)
				{
					送り状データ.table送り状Row tr = (送り状データ.table送り状Row)ds送り状.table送り状.NewRow();
						
					tr.BeginEdit();
					tr.印刷順 = i印刷順++;

					if(!gsオプション[19].Equals("1") && sPrintData[12].Length >= 7)
					{
						tr.荷受人郵便番号 = "〒";
						tr.荷受人郵便番号 += sPrintData[12].Substring(0,3);
						tr.荷受人郵便番号 += "-";
						tr.荷受人郵便番号 += sPrintData[12].Substring(3,4);
					}
					else
					{
						tr.荷受人郵便番号 = "";
					}
					tr.荷受人ＣＤ     = sPrintData[1];
					if(gsオプション[0].Length == 4)
					{
						if(!gsオプション[12].Equals("1"))
						{
							tr.荷受人ＣＤ     = " ";
						}
					}
					tr.荷受人電話番号 = "(" + sPrintData[2] + ")" + sPrintData[3] + "-" + sPrintData[4];
					if(sPrintData[2].Replace("0","").Trim().Length == 0
						&& sPrintData[3].Replace("0","").Trim().Length == 0
						&& sPrintData[4].Replace("0","").Trim().Length == 0)
					{
						tr.荷受人電話番号 = " ";
					}
					tr.荷受人住所県   = "";
					tr.荷受人住所市   = "";
					tr.荷受人住所町   = "";
					tr.荷受人住所１   = sPrintData[5];
					tr.荷受人住所２   = sPrintData[6];
					tr.荷受人住所３   = sPrintData[7];
					tr.荷受人名前１   = sPrintData[8];
					tr.荷受人名前２   = sPrintData[9];
					if (sPrintData[5].Equals("※※支店止め※※"))
					{
						// 支店止めであるとき、荷受人住所項目に以下の設定を行なう
						// 　・荷受人住所県：「※※支店止め※※」（帳票項目の表示判定に使用、非表示項目）
						// 　・荷受人住所１：「福山通運／王子運送」を印字
						// 　・荷受人住所２：「○○支店／営業所止め」
						// 　・荷受人住所３：何も印字しない
						tr.荷受人住所県 = sPrintData[5];
						if(sPrintData[6].Substring(0, 2) == "王子")
						{
							tr.荷受人住所１ = "王子運送";
						}
						else
						{
							tr.荷受人住所１ = "福山通運";
						}
						tr.荷受人住所３ = "";
					}

					tr.出荷日年       = sPrintData[10];
					if(sPrintData[10].Substring(4, 1) == "0")
						tr.出荷日月       = " " + sPrintData[10].Substring(5, 1);
					else
						tr.出荷日月       = sPrintData[10].Substring(4, 2);
					if(sPrintData[10].Substring(6, 1) == "0")
						tr.出荷日日       = " " + sPrintData[10].Substring(7, 1);
					else
						tr.出荷日日       = sPrintData[10].Substring(6, 2);

					tr.送り状番号     = sPrintData[11].Substring(4,3) + "-" + sPrintData[11].Substring(7,4) + "-" + sPrintData[11].Substring(11,4);
					tr.バーコード     = "A" + sPrintData[11].Substring(4) + "A";

					if(sPrintData[13].Length == 0)
						tr.着店ＣＤ       = "";
					else
						tr.着店ＣＤ       = sPrintData[13].Substring(1);
					if(sPrintData[13].Equals("0000"))
					{
						tr.着店ＣＤ       = "";
					}

					//仕分ＣＤが設定されている場合、仕分ＣＤ、発店名を印字
					if(sPrintData[37].Length > 0)
					{
						tr.仕分ＣＤ       = sPrintData[37];
					}
					else
					{
						tr.仕分ＣＤ       = "";
					}
					tr.発店ＣＤ       = sPrintData[14].Substring(1, 3);
					if(sPrintData[14].Substring(1, 3) == "047")
					{
						tr.出荷日年       = "";
						tr.出荷日月       = "";
						tr.出荷日日       = "";
						tr.発店名         = "";
						tr.発店ＣＤ       = "";
					}

					if(!gsオプション[19].Equals("1")
						&& sPrintData.Length > 40 && sPrintData[40].Length >= 7)
					{
						tr.荷送人郵便番号 = "〒";
						tr.荷送人郵便番号 += sPrintData[40].Substring(0,3);
						tr.荷送人郵便番号 += "-";
						tr.荷送人郵便番号 += sPrintData[40].Substring(3,4);
					}
					else
					{
						tr.荷送人郵便番号 = "";
					}
					tr.荷送人電話番号 = "(" + sPrintData[15] + ")" + sPrintData[16] + "-" + sPrintData[17];
					tr.荷送人住所１   = 住所編集(sPrintData[18]);
					tr.荷送人住所２   = sPrintData[19];
					tr.荷送人住所３   = sPrintData[18];
					tr.荷送人名前１   = sPrintData[21];
					tr.荷送人名前２   = sPrintData[22];
					tr.担当者         = sPrintData[34];
					tr.個数           = sPrintData[23];

					// 連番は０固定とする。
//					tr.連番           = iPage.ToString();
					tr.連番           = "0";

					tr.重量           = sPrintData[24];
					int i保険料 = int.Parse(sPrintData[25]) * 10;
					if(i保険料 > 0 && i保険料 < 50)
					{
						tr.保険料     = "50";
					}
					else
					{
						string s保険料 = i保険料.ToString();
						if(s保険料.Length == 4)
							s保険料 = s保険料.Insert(1,",");
						else
						{
							if(s保険料.Length == 5)
								s保険料 = s保険料.Insert(2,",");
						}
						tr.保険料     = s保険料;
					}
					string s指定月;
					string s指定日;
					if (sPrintData[26] != null && !sPrintData[26].Equals("") && !sPrintData[26].Equals("0"))
					{
						if(sPrintData[26].Substring(4, 1) == "0")
							s指定月 = " " + sPrintData[26].Substring(5, 1);
						else
							s指定月 = sPrintData[26].Substring(4, 2);

						if(sPrintData[26].Substring(6, 1) == "0")
							s指定日 = " " + sPrintData[26].Substring(7, 1);
						else
							s指定日 = sPrintData[26].Substring(6, 2);
						tr.指定日     = s指定月 + "月" + s指定日 + "日";
						if (sPrintData[36].Equals("0"))
							tr.指定日 += "必着";
						else if (sPrintData[36].Equals("1"))
							tr.指定日 += "指定";
					}
					else
						tr.指定日     = "";
					if(sPrintData[35].Length != 0)
						tr.お客様番号     = "お客様番号:" + sPrintData[35];
					else
						tr.お客様番号     = sPrintData[35];
					tr.輸送記事１     = sPrintData[27];
					tr.輸送記事２     = sPrintData[28];
					tr.品名記事１     = sPrintData[29];
					tr.品名記事２     = sPrintData[30];
					tr.品名記事３     = sPrintData[31];
					if(sPrintData.Length > 42)
					{
						tr.品名記事４ = sPrintData[42];
						tr.品名記事５ = sPrintData[43];
						tr.品名記事６ = sPrintData[44];
					}
					else
					{
						tr.品名記事４ = "";
						tr.品名記事５ = "";
						tr.品名記事６ = "";
					}
					if(tr.品名記事４.Length > 0
						|| tr.品名記事５.Length > 0
						|| tr.品名記事６.Length > 0
						)
					{
						// 全角９文字、又は半角１８文字
						tr.品名記事１ = バイト長カット(tr.品名記事１, 18);
						tr.品名記事２ = バイト長カット(tr.品名記事２, 18);
						tr.品名記事３ = バイト長カット(tr.品名記事３, 18);
						tr.品名記事４ = バイト長カット(tr.品名記事４, 18);
						tr.品名記事５ = バイト長カット(tr.品名記事５, 18);
						tr.品名記事６ = バイト長カット(tr.品名記事６, 18);
					}

					if(!gsオプション[15].Equals("1"))
					{
						tr.荷受人フォントサイズ拡大FLG     = "0";
					}
					else
					{
						tr.荷受人フォントサイズ拡大FLG     = "1";
					}

					if(gs会員ＣＤ.Substring(0,1) != "J")
					{
						tr.王子運送FLG = "0";
					}
					else
					{
						tr.王子運送FLG = "1";
					}

					string s重量入力制御 = (sPrintData.Length > 41) ? sPrintData[41] : "0";
					tr.重量入力制御 = s重量入力制御;
					if(tr.発店ＣＤ == "" || tr.発店ＣＤ == "000")
					{
						tr.発店名     = ""; // 発店ＣＤが未設定時(グローバル等)
					}
					else if(gsオプション[21].Equals("1"))
					{
						tr.発店名     = "";
					}
					else
					{
						if(sPrintData[38] == "")
						{
							tr.発店名     = tr.発店ＣＤ;
						}
						else
						{
							tr.発店名     = sPrintData[38];
						}
					}
					string s着店名 = (sPrintData.Length > 45) ? sPrintData[45] : "";
					if(tr.着店ＣＤ == "" || tr.着店ＣＤ == "000")
					{
						tr.着店名     = ""; // 着店ＣＤが未設定時
					}
					else
					{
						if(s着店名 == "")
						{
							tr.着店名     = tr.着店ＣＤ;
						}
						else
						{
							tr.着店名     = s着店名;
						}
					}
					// ※ラベルのバックの黒塗を[着店名]に設定している為
					//   着店名が表示されない時、バックの色が消えます

// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 START
					//社内伝票であれば、値をセットする
					if(gs部門店所ＣＤ.Equals("044"))
					{
						// 社内伝票であるとき、荷受人住所項目に以下の設定を行なう
						// 　・荷受人住所町　　　　　：「※※社内伝票※※」
						//　　　（帳票項目の表示判定に使用、非表示項目）
						// 　・着店ＣＤ（大）　　　　：印字しない
						// 　・着店ＣＤ（小）　　　　：印字する
						// 　・『社内専用』テキスト：印字する
						tr.荷受人住所町 = "※※社内伝票※※";
					}
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 END

					tr.EndEdit();

					ds送り状.table送り状.Rows.Add(tr);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		protected void 荷札控え帳票印刷()
		{
			// 明示的ガベージコレクタ
			System.GC.Collect();
			if(gsプリンタ種類 == "S0004")
			{
				送り状データクリア();
				return;
			}

			// プレビュー表示
			送り状控えＡ４帳票 crA4 = new 送り状控えＡ４帳票();

			DataView dv = ds送り状.table送り状.DefaultView;
			dv.Sort = "印刷順 ASC";
			DataTable dt2 = ds送り状.table送り状.Clone();
			foreach (DataRowView drv in dv) 
			{
				dt2.Rows.Add(drv.Row.ItemArray);
			}
			dt2.AcceptChanges();
			crA4.SetDataSource(dt2);

			プレビュー画面 画面 = new プレビュー画面();
			画面.crv帳票.PrintReport();
			画面.crv帳票.ReportSource = crA4;
			画面.ShowDialog();

			// 明示的領域開放
			crA4 = null;
			dv  = null;
			dt2 = null;

			// 明示的ガベージコレクタ
			System.GC.Collect();

			送り状データクリア();
		}
// ADD 2015.11.02 BEVAS）松本 出荷ラベルイメージ印刷画面追加 END
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 START
		protected string[] ＣＭ０５会員扱店Ｆチェック()
		{
			string[] sRet = new string[2];
			try
			{
				string[] sList = new string[2];
				if(sv_syukka == null)
				{
					sv_syukka = new is2syukka.Service1();
				}
				sList = sv_syukka.CheckCM22_HouseSlip(gsaユーザ, gs会員ＣＤ);

				if(sList[0] == "正常終了")
				{
					//正常終了時
					sRet[0] = "0"; //問題なし
					sRet[1] = "";
				}
				else
				{
					//異常終了時
					sRet[0] = "1"; //問題あり
					sRet[1] = sList[0].Trim();
				}
			}
			catch(System.Net.WebException)
			{
				sRet[0] = "1"; //問題あり
				sRet[1] = gs通信エラー;
			}
			catch(Exception ex)
			{
				sRet[0] = "1"; //問題あり
				sRet[1] = "通信エラー：" + ex.Message;
			}
			return sRet;
		}
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 END
	}
}
