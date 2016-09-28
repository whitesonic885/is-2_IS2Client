using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [エントリーオプション]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// MOD 2006.06.28 東都）山本　 エントリオプションの項目追加 
	// MOD 2006.12.14 東都）小童谷 お届先全件削除追加 
	//--------------------------------------------------------------------------
	// MOD 2009.05.01 東都）高木 オプションの項目追加 
	// MOD 2009.10.23 PSN）藤井　オプションの項目追加（荷札フォント自動拡大）
	// MOD 2009.11.06 PSN）藤井　出荷実績一覧表対応
	//--------------------------------------------------------------------------
	// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない 
	// MOD 2011.03.08 東都）高木 王子運送対応 
	// MOD 2011.04.13 東都）高木 重量入力不可対応 
	// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 
	// MOD 2011.05.09 東都）高木 エコー金属版のオプションのマージ 
	// MOD 2011.07.14 東都）高木 記事行の追加 
	// MOD 2011.08.05 東都）高木 記事行の追加（３行・６行切替対応） 
	//--------------------------------------------------------------------------
	// MOD 2012.04.10 東都）高木 ラベル発店名の印字制御対応 
	//--------------------------------------------------------------------------
	// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加
	//--------------------------------------------------------------------------
	// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加
	// MOD 2016.06.10 BEVAS）松本 保険料入力チェック機能の追加（31万円以上の場合）
	//--------------------------------------------------------------------------
	public class 才数切り替え : 共通フォーム
	{
// MOD 2006.06.28 東都）山本　 エントリオプションの項目追加 START
//		private string[] s制御項目名   = {"住所２","住所３","名前２","担当","お客様番号","輸送商品","品名記事","重量","入力方法","保険料"};
//		private string[] s制御項目ＦＧ = new string[10];
//		private string[] s制御項目有無 = new string[10];
// MOD 2009.05.01 東都）高木 オプションの項目追加 START
//		private string[] s制御項目名   = {"住所２","住所３","名前２","担当","お客様番号","輸送商品","品名記事","重量","入力方法","保険料","依頼主"};
// MOD 2009.11.06 PSN）藤井　出荷実績一覧表対応 START
// MOD 2009.10.23 PSN）藤井　オプションの項目追加 START
//		private string[] s制御項目名   = {
//											"住所２","住所３","名前２","担当","お客様番号"
//											,"輸送商品","品名記事","重量","入力方法","保険料"
//											,"依頼主","ラベル荷受人ＣＤ","出荷実績一覧表行数"
//											,"出荷実績一覧表依頼主"
//										};
// MOD 2009.05.01 東都）高木 オプションの項目追加 END

		private string[] s制御項目名   = {
										"住所２","住所３","名前２","担当","お客様番号"
										,"輸送商品","品名記事","重量","入力方法","保険料"
										,"依頼主","ラベル荷受人ＣＤ","出荷実績一覧表行数"
										,"出荷実績一覧表依頼主"
										,"ラベル荷受人拡大","出荷実績一覧表社名"
// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）START
										,"ＣＳＶ出力形式"
// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）END
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
										,"住所氏名前詰め"
										,"ラベル郵便番号"
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
// MOD 2011.05.09 東都）高木 エコー金属版のオプションのマージ START
										,"受領印印字ラベル"
// MOD 2011.05.09 東都）高木 エコー金属版のオプションのマージ END
// MOD 2012.04.10 東都）高木 ラベル発店名の印字制御対応 
										,"ラベル発店名"
// MOD 2012.04.10 東都）高木 ラベル発店名の印字制御対応 
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 START
										,"バーコード読取画面"
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 END
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 START
										,"依頼主固定重量考慮"
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
// MOD 2016.06.10 BEVAS）松本 保険料入力チェック機能の追加 START
										,"保険料入力チェック"
// MOD 2016.06.10 BEVAS）松本 保険料入力チェック機能の追加 END
									};
// MOD 2009.10.23 PSN）藤井　オプションの項目追加 END
// MOD 2009.11.06 PSN）藤井　出荷実績一覧表対応 END
		private string[] s制御項目ＦＧ = new string[11];
		private string[] s制御項目有無 = new string[11];
// MOD 2006.06.28 東都）山本　 エントリオプションの項目追加 END

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lab才数切り替えタイトル;
		private System.Windows.Forms.Button btn更新;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label lab届け先住所２;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RadioButton rBtn届け先住所２する;
		private System.Windows.Forms.RadioButton rBtn届け先住所２しない;
		private System.Windows.Forms.Label lab届け先住所３;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.RadioButton rBtn届け先住所３する;
		private System.Windows.Forms.RadioButton rBtn届け先住所３しない;
		private System.Windows.Forms.Label lab届け先名前２;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.RadioButton rBtn届け先名前２する;
		private System.Windows.Forms.RadioButton rBtn届け先名前２しない;
		private System.Windows.Forms.Label lab担当;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.RadioButton rBtn担当する;
		private System.Windows.Forms.RadioButton rBtn担当しない;
		private System.Windows.Forms.Label labお客様番号;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.RadioButton rBtnお客様番号する;
		private System.Windows.Forms.RadioButton rBtnお客様番号しない;
		private System.Windows.Forms.Label lab輸送商品;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.RadioButton rBtn輸送商品する;
		private System.Windows.Forms.RadioButton rBtn輸送商品しない;
		private System.Windows.Forms.Label lab品名記事１;
		private System.Windows.Forms.Panel pnl品名記事１;
		private System.Windows.Forms.RadioButton rBtn品名記事１＿６行;
		private System.Windows.Forms.RadioButton rBtn品名記事１しない;
		private System.Windows.Forms.Label lab重量;
		private System.Windows.Forms.Panel panel14;
		private System.Windows.Forms.RadioButton rBtn重量する;
		private System.Windows.Forms.RadioButton rBtn重量しない;
		private System.Windows.Forms.Label lab重量入力方法;
		private System.Windows.Forms.Panel panel15;
		private System.Windows.Forms.RadioButton rBtn重量入力;
		private System.Windows.Forms.RadioButton rBtn才数入力;
		private System.Windows.Forms.Label lab保険金額;
		private System.Windows.Forms.Panel panel16;
		private System.Windows.Forms.RadioButton rBtn保険金額する;
		private System.Windows.Forms.RadioButton rBtn保険金額しない;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel12;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RadioButton rBtn依頼主入力する;
		private System.Windows.Forms.RadioButton rBtn依頼主入力しない;
		private System.Windows.Forms.Button btn削除;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox gpb左;
		private System.Windows.Forms.GroupBox gpb右;
		private System.Windows.Forms.Label lab帳票印刷;
		private System.Windows.Forms.Panel pnl荷受人コード;
		private System.Windows.Forms.Label lab出荷実績一覧表;
		private System.Windows.Forms.Panel pnl出荷実績一覧表;
		private System.Windows.Forms.RadioButton rBtn出荷実績８行;
		private System.Windows.Forms.RadioButton rBtn出荷実績２行;
		private System.Windows.Forms.Label labお届け先コード;
		private System.Windows.Forms.RadioButton rBtnラベルお届け先ＣＤしない;
		private System.Windows.Forms.RadioButton rBtnラベルお届け先ＣＤする;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Panel pn荷受人フォントサイズ;
		private System.Windows.Forms.RadioButton rBtnフォント自動拡大しない;
		private System.Windows.Forms.RadioButton rBtnフォント自動拡大する;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Panel panel13;
		private System.Windows.Forms.RadioButton rBtn社名印字しない;
		private System.Windows.Forms.RadioButton rBtn社名印字する;
		private System.Windows.Forms.GroupBox grp右上;
		private System.Windows.Forms.Panel pnlＣＳＶ出力形式;
		private System.Windows.Forms.RadioButton rBtn出荷ＣＳＶ標準;
		private System.Windows.Forms.RadioButton rBtn出荷ＣＳＶエントリー;
		private System.Windows.Forms.Label lab出荷ＣＳＶ出力;
		private System.Windows.Forms.Label lab出荷ＣＳＶ出力形式;
		private System.Windows.Forms.Label lab郵便番号;
		private System.Windows.Forms.Panel pan郵便番号;
		private System.Windows.Forms.RadioButton rBtnラベル郵便番号しない;
		private System.Windows.Forms.RadioButton rBtnラベル郵便番号する;
		private System.Windows.Forms.Label labお届け先情報;
		private System.Windows.Forms.Panel pan前詰め;
		private System.Windows.Forms.RadioButton rBtn前詰めする;
		private System.Windows.Forms.RadioButton rBtn前詰めしない;
		private System.Windows.Forms.Label lab前詰め;
		private System.Windows.Forms.Label labラベル印刷;
		private System.Windows.Forms.RadioButton rBtn出荷ＣＳＶ標準２;
		private System.Windows.Forms.RadioButton rBtn出荷ＣＳＶエントリー２;
		private System.Windows.Forms.RadioButton rBtn品名記事１＿３行;
		private System.Windows.Forms.Label lab発店名;
		private System.Windows.Forms.Panel pnl発店名;
		private System.Windows.Forms.RadioButton rBtnラベル発店名する;
		private System.Windows.Forms.RadioButton rBtnラベル発店名しない;
		private System.Windows.Forms.Label labバーコード読取専用;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.RadioButton rBtn読取表示する;
		private System.Windows.Forms.RadioButton rBtn読取表示しない;
		private System.Windows.Forms.Label lab依頼主重量考慮;
		private System.Windows.Forms.Panel pnl依頼主重量考慮;
		private System.Windows.Forms.RadioButton rBtn依頼主重量考慮しない;
		private System.Windows.Forms.RadioButton rBtn依頼主重量考慮する;
		private System.Windows.Forms.Panel pnl保険金額チェック;
		private System.Windows.Forms.RadioButton rBtn保険金額チェックする;
		private System.Windows.Forms.RadioButton rBtn保険金額チェックしない;
		private System.Windows.Forms.Label lab保険金額チェック;
		private System.ComponentModel.IContainer components = null;

		public 才数切り替え()
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.grp右上 = new System.Windows.Forms.GroupBox();
			this.labお届け先情報 = new System.Windows.Forms.Label();
			this.lab出荷ＣＳＶ出力形式 = new System.Windows.Forms.Label();
			this.pnlＣＳＶ出力形式 = new System.Windows.Forms.Panel();
			this.rBtn出荷ＣＳＶエントリー２ = new System.Windows.Forms.RadioButton();
			this.rBtn出荷ＣＳＶ標準２ = new System.Windows.Forms.RadioButton();
			this.rBtn出荷ＣＳＶ標準 = new System.Windows.Forms.RadioButton();
			this.rBtn出荷ＣＳＶエントリー = new System.Windows.Forms.RadioButton();
			this.lab出荷ＣＳＶ出力 = new System.Windows.Forms.Label();
			this.btn削除 = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.gpb右 = new System.Windows.Forms.GroupBox();
			this.lab発店名 = new System.Windows.Forms.Label();
			this.pnl発店名 = new System.Windows.Forms.Panel();
			this.rBtnラベル発店名する = new System.Windows.Forms.RadioButton();
			this.rBtnラベル発店名しない = new System.Windows.Forms.RadioButton();
			this.labラベル印刷 = new System.Windows.Forms.Label();
			this.pan郵便番号 = new System.Windows.Forms.Panel();
			this.rBtnラベル郵便番号しない = new System.Windows.Forms.RadioButton();
			this.rBtnラベル郵便番号する = new System.Windows.Forms.RadioButton();
			this.lab郵便番号 = new System.Windows.Forms.Label();
			this.panel13 = new System.Windows.Forms.Panel();
			this.rBtn社名印字しない = new System.Windows.Forms.RadioButton();
			this.rBtn社名印字する = new System.Windows.Forms.RadioButton();
			this.label11 = new System.Windows.Forms.Label();
			this.pn荷受人フォントサイズ = new System.Windows.Forms.Panel();
			this.rBtnフォント自動拡大しない = new System.Windows.Forms.RadioButton();
			this.rBtnフォント自動拡大する = new System.Windows.Forms.RadioButton();
			this.label10 = new System.Windows.Forms.Label();
			this.lab帳票印刷 = new System.Windows.Forms.Label();
			this.labお届け先コード = new System.Windows.Forms.Label();
			this.pnl荷受人コード = new System.Windows.Forms.Panel();
			this.rBtnラベルお届け先ＣＤしない = new System.Windows.Forms.RadioButton();
			this.rBtnラベルお届け先ＣＤする = new System.Windows.Forms.RadioButton();
			this.lab出荷実績一覧表 = new System.Windows.Forms.Label();
			this.pnl出荷実績一覧表 = new System.Windows.Forms.Panel();
			this.rBtn出荷実績８行 = new System.Windows.Forms.RadioButton();
			this.rBtn出荷実績２行 = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.gpb左 = new System.Windows.Forms.GroupBox();
			this.lab依頼主重量考慮 = new System.Windows.Forms.Label();
			this.pnl依頼主重量考慮 = new System.Windows.Forms.Panel();
			this.rBtn依頼主重量考慮しない = new System.Windows.Forms.RadioButton();
			this.rBtn依頼主重量考慮する = new System.Windows.Forms.RadioButton();
			this.panel11 = new System.Windows.Forms.Panel();
			this.rBtn読取表示する = new System.Windows.Forms.RadioButton();
			this.rBtn読取表示しない = new System.Windows.Forms.RadioButton();
			this.labバーコード読取専用 = new System.Windows.Forms.Label();
			this.lab前詰め = new System.Windows.Forms.Label();
			this.pan前詰め = new System.Windows.Forms.Panel();
			this.rBtn前詰めする = new System.Windows.Forms.RadioButton();
			this.rBtn前詰めしない = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.panel12 = new System.Windows.Forms.Panel();
			this.rBtn依頼主入力する = new System.Windows.Forms.RadioButton();
			this.rBtn依頼主入力しない = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel16 = new System.Windows.Forms.Panel();
			this.rBtn保険金額する = new System.Windows.Forms.RadioButton();
			this.rBtn保険金額しない = new System.Windows.Forms.RadioButton();
			this.lab保険金額 = new System.Windows.Forms.Label();
			this.panel15 = new System.Windows.Forms.Panel();
			this.rBtn重量入力 = new System.Windows.Forms.RadioButton();
			this.rBtn才数入力 = new System.Windows.Forms.RadioButton();
			this.lab重量入力方法 = new System.Windows.Forms.Label();
			this.panel14 = new System.Windows.Forms.Panel();
			this.rBtn重量する = new System.Windows.Forms.RadioButton();
			this.rBtn重量しない = new System.Windows.Forms.RadioButton();
			this.lab重量 = new System.Windows.Forms.Label();
			this.pnl品名記事１ = new System.Windows.Forms.Panel();
			this.rBtn品名記事１＿６行 = new System.Windows.Forms.RadioButton();
			this.rBtn品名記事１しない = new System.Windows.Forms.RadioButton();
			this.rBtn品名記事１＿３行 = new System.Windows.Forms.RadioButton();
			this.lab品名記事１ = new System.Windows.Forms.Label();
			this.panel10 = new System.Windows.Forms.Panel();
			this.rBtn輸送商品する = new System.Windows.Forms.RadioButton();
			this.rBtn輸送商品しない = new System.Windows.Forms.RadioButton();
			this.lab輸送商品 = new System.Windows.Forms.Label();
			this.panel9 = new System.Windows.Forms.Panel();
			this.rBtnお客様番号する = new System.Windows.Forms.RadioButton();
			this.rBtnお客様番号しない = new System.Windows.Forms.RadioButton();
			this.labお客様番号 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.rBtn担当する = new System.Windows.Forms.RadioButton();
			this.rBtn担当しない = new System.Windows.Forms.RadioButton();
			this.lab担当 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.rBtn届け先名前２する = new System.Windows.Forms.RadioButton();
			this.rBtn届け先名前２しない = new System.Windows.Forms.RadioButton();
			this.lab届け先名前２ = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.rBtn届け先住所３する = new System.Windows.Forms.RadioButton();
			this.rBtn届け先住所３しない = new System.Windows.Forms.RadioButton();
			this.lab届け先住所３ = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.rBtn届け先住所２する = new System.Windows.Forms.RadioButton();
			this.rBtn届け先住所２しない = new System.Windows.Forms.RadioButton();
			this.lab届け先住所２ = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab才数切り替えタイトル = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn更新 = new System.Windows.Forms.Button();
			this.texメッセージ = new System.Windows.Forms.TextBox();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.pnl保険金額チェック = new System.Windows.Forms.Panel();
			this.rBtn保険金額チェックする = new System.Windows.Forms.RadioButton();
			this.rBtn保険金額チェックしない = new System.Windows.Forms.RadioButton();
			this.lab保険金額チェック = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).BeginInit();
			this.panel1.SuspendLayout();
			this.grp右上.SuspendLayout();
			this.pnlＣＳＶ出力形式.SuspendLayout();
			this.gpb右.SuspendLayout();
			this.pnl発店名.SuspendLayout();
			this.pan郵便番号.SuspendLayout();
			this.panel13.SuspendLayout();
			this.pn荷受人フォントサイズ.SuspendLayout();
			this.pnl荷受人コード.SuspendLayout();
			this.pnl出荷実績一覧表.SuspendLayout();
			this.gpb左.SuspendLayout();
			this.pnl依頼主重量考慮.SuspendLayout();
			this.panel11.SuspendLayout();
			this.pan前詰め.SuspendLayout();
			this.panel12.SuspendLayout();
			this.panel16.SuspendLayout();
			this.panel15.SuspendLayout();
			this.panel14.SuspendLayout();
			this.pnl品名記事１.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.pnl保険金額チェック.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Honeydew;
			this.panel1.Controls.Add(this.grp右上);
			this.panel1.Controls.Add(this.gpb右);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.gpb左);
			this.panel1.Location = new System.Drawing.Point(0, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(778, 448);
			this.panel1.TabIndex = 1;
			// 
			// grp右上
			// 
			this.grp右上.Controls.Add(this.labお届け先情報);
			this.grp右上.Controls.Add(this.lab出荷ＣＳＶ出力形式);
			this.grp右上.Controls.Add(this.pnlＣＳＶ出力形式);
			this.grp右上.Controls.Add(this.lab出荷ＣＳＶ出力);
			this.grp右上.Controls.Add(this.btn削除);
			this.grp右上.Controls.Add(this.label9);
			this.grp右上.Controls.Add(this.label8);
			this.grp右上.Controls.Add(this.label7);
			this.grp右上.Location = new System.Drawing.Point(412, 4);
			this.grp右上.Name = "grp右上";
			this.grp右上.Size = new System.Drawing.Size(344, 200);
			this.grp右上.TabIndex = 1;
			this.grp右上.TabStop = false;
			// 
			// labお届け先情報
			// 
			this.labお届け先情報.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.labお届け先情報.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labお届け先情報.ForeColor = System.Drawing.Color.White;
			this.labお届け先情報.Location = new System.Drawing.Point(1, 112);
			this.labお届け先情報.Name = "labお届け先情報";
			this.labお届け先情報.Size = new System.Drawing.Size(343, 22);
			this.labお届け先情報.TabIndex = 92;
			this.labお届け先情報.Text = "お届け先情報";
			this.labお届け先情報.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab出荷ＣＳＶ出力形式
			// 
			this.lab出荷ＣＳＶ出力形式.BackColor = System.Drawing.Color.Honeydew;
			this.lab出荷ＣＳＶ出力形式.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab出荷ＣＳＶ出力形式.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab出荷ＣＳＶ出力形式.Location = new System.Drawing.Point(14, 32);
			this.lab出荷ＣＳＶ出力形式.Name = "lab出荷ＣＳＶ出力形式";
			this.lab出荷ＣＳＶ出力形式.Size = new System.Drawing.Size(112, 14);
			this.lab出荷ＣＳＶ出力形式.TabIndex = 91;
			this.lab出荷ＣＳＶ出力形式.Text = "出荷ＣＳＶ出力形式";
			// 
			// pnlＣＳＶ出力形式
			// 
			this.pnlＣＳＶ出力形式.Controls.Add(this.rBtn出荷ＣＳＶエントリー２);
			this.pnlＣＳＶ出力形式.Controls.Add(this.rBtn出荷ＣＳＶ標準２);
			this.pnlＣＳＶ出力形式.Controls.Add(this.rBtn出荷ＣＳＶ標準);
			this.pnlＣＳＶ出力形式.Controls.Add(this.rBtn出荷ＣＳＶエントリー);
			this.pnlＣＳＶ出力形式.Location = new System.Drawing.Point(140, 26);
			this.pnlＣＳＶ出力形式.Name = "pnlＣＳＶ出力形式";
			this.pnlＣＳＶ出力形式.Size = new System.Drawing.Size(202, 62);
			this.pnlＣＳＶ出力形式.TabIndex = 0;
			// 
			// rBtn出荷ＣＳＶエントリー２
			// 
			this.rBtn出荷ＣＳＶエントリー２.Location = new System.Drawing.Point(88, 26);
			this.rBtn出荷ＣＳＶエントリー２.Name = "rBtn出荷ＣＳＶエントリー２";
			this.rBtn出荷ＣＳＶエントリー２.Size = new System.Drawing.Size(114, 30);
			this.rBtn出荷ＣＳＶエントリー２.TabIndex = 4;
			this.rBtn出荷ＣＳＶエントリー２.Text = "CSVｴﾝﾄﾘ-形式２ （記事６行）";
			// 
			// rBtn出荷ＣＳＶ標準２
			// 
			this.rBtn出荷ＣＳＶ標準２.Location = new System.Drawing.Point(0, 26);
			this.rBtn出荷ＣＳＶ標準２.Name = "rBtn出荷ＣＳＶ標準２";
			this.rBtn出荷ＣＳＶ標準２.Size = new System.Drawing.Size(82, 30);
			this.rBtn出荷ＣＳＶ標準２.TabIndex = 3;
			this.rBtn出荷ＣＳＶ標準２.Text = "標準形式２ （記事６行）";
			// 
			// rBtn出荷ＣＳＶ標準
			// 
			this.rBtn出荷ＣＳＶ標準.Checked = true;
			this.rBtn出荷ＣＳＶ標準.Location = new System.Drawing.Point(0, 0);
			this.rBtn出荷ＣＳＶ標準.Name = "rBtn出荷ＣＳＶ標準";
			this.rBtn出荷ＣＳＶ標準.Size = new System.Drawing.Size(82, 24);
			this.rBtn出荷ＣＳＶ標準.TabIndex = 1;
			this.rBtn出荷ＣＳＶ標準.TabStop = true;
			this.rBtn出荷ＣＳＶ標準.Text = "標準形式";
			// 
			// rBtn出荷ＣＳＶエントリー
			// 
			this.rBtn出荷ＣＳＶエントリー.Location = new System.Drawing.Point(88, 0);
			this.rBtn出荷ＣＳＶエントリー.Name = "rBtn出荷ＣＳＶエントリー";
			this.rBtn出荷ＣＳＶエントリー.Size = new System.Drawing.Size(114, 24);
			this.rBtn出荷ＣＳＶエントリー.TabIndex = 2;
			this.rBtn出荷ＣＳＶエントリー.Text = "CSVｴﾝﾄﾘ-形式";
			// 
			// lab出荷ＣＳＶ出力
			// 
			this.lab出荷ＣＳＶ出力.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab出荷ＣＳＶ出力.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lab出荷ＣＳＶ出力.ForeColor = System.Drawing.Color.White;
			this.lab出荷ＣＳＶ出力.Location = new System.Drawing.Point(0, 0);
			this.lab出荷ＣＳＶ出力.Name = "lab出荷ＣＳＶ出力";
			this.lab出荷ＣＳＶ出力.Size = new System.Drawing.Size(343, 22);
			this.lab出荷ＣＳＶ出力.TabIndex = 87;
			this.lab出荷ＣＳＶ出力.Text = "出荷ＣＳＶ出力（出荷照会・出荷実績）";
			this.lab出荷ＣＳＶ出力.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn削除
			// 
			this.btn削除.BackColor = System.Drawing.Color.SteelBlue;
			this.btn削除.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn削除.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn削除.ForeColor = System.Drawing.Color.White;
			this.btn削除.Location = new System.Drawing.Point(14, 140);
			this.btn削除.Name = "btn削除";
			this.btn削除.Size = new System.Drawing.Size(66, 22);
			this.btn削除.TabIndex = 1;
			this.btn削除.TabStop = false;
			this.btn削除.Text = "全件削除";
			this.btn削除.Click += new System.EventHandler(this.btn削除_Click);
			// 
			// label9
			// 
			this.label9.ForeColor = System.Drawing.Color.Red;
			this.label9.Location = new System.Drawing.Point(90, 138);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(16, 14);
			this.label9.TabIndex = 47;
			this.label9.Text = "※";
			// 
			// label8
			// 
			this.label8.ForeColor = System.Drawing.Color.Red;
			this.label8.Location = new System.Drawing.Point(106, 174);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(196, 24);
			this.label8.TabIndex = 46;
			this.label8.Text = "また、事前にCSV出力によりバックアップをお取りください。";
			// 
			// label7
			// 
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(106, 138);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(188, 42);
			this.label7.TabIndex = 45;
			this.label7.Text = "お届け先を全件削除する場合、削除後は復旧できませんので、特別な場合以外は行わないでください。";
			// 
			// gpb右
			// 
			this.gpb右.Controls.Add(this.lab発店名);
			this.gpb右.Controls.Add(this.pnl発店名);
			this.gpb右.Controls.Add(this.labラベル印刷);
			this.gpb右.Controls.Add(this.pan郵便番号);
			this.gpb右.Controls.Add(this.lab郵便番号);
			this.gpb右.Controls.Add(this.panel13);
			this.gpb右.Controls.Add(this.label11);
			this.gpb右.Controls.Add(this.pn荷受人フォントサイズ);
			this.gpb右.Controls.Add(this.label10);
			this.gpb右.Controls.Add(this.lab帳票印刷);
			this.gpb右.Controls.Add(this.labお届け先コード);
			this.gpb右.Controls.Add(this.pnl荷受人コード);
			this.gpb右.Controls.Add(this.lab出荷実績一覧表);
			this.gpb右.Controls.Add(this.pnl出荷実績一覧表);
			this.gpb右.Location = new System.Drawing.Point(412, 204);
			this.gpb右.Name = "gpb右";
			this.gpb右.Size = new System.Drawing.Size(344, 240);
			this.gpb右.TabIndex = 2;
			this.gpb右.TabStop = false;
			// 
			// lab発店名
			// 
			this.lab発店名.BackColor = System.Drawing.Color.Honeydew;
			this.lab発店名.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab発店名.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab発店名.Location = new System.Drawing.Point(18, 32);
			this.lab発店名.Name = "lab発店名";
			this.lab発店名.Size = new System.Drawing.Size(100, 14);
			this.lab発店名.TabIndex = 102;
			this.lab発店名.Text = "発店名";
			// 
			// pnl発店名
			// 
			this.pnl発店名.Controls.Add(this.rBtnラベル発店名する);
			this.pnl発店名.Controls.Add(this.rBtnラベル発店名しない);
			this.pnl発店名.Location = new System.Drawing.Point(140, 26);
			this.pnl発店名.Name = "pnl発店名";
			this.pnl発店名.Size = new System.Drawing.Size(180, 24);
			this.pnl発店名.TabIndex = 0;
			// 
			// rBtnラベル発店名する
			// 
			this.rBtnラベル発店名する.Checked = true;
			this.rBtnラベル発店名する.Location = new System.Drawing.Point(0, 0);
			this.rBtnラベル発店名する.Name = "rBtnラベル発店名する";
			this.rBtnラベル発店名する.Size = new System.Drawing.Size(80, 24);
			this.rBtnラベル発店名する.TabIndex = 1;
			this.rBtnラベル発店名する.TabStop = true;
			this.rBtnラベル発店名する.Text = "印字する";
			// 
			// rBtnラベル発店名しない
			// 
			this.rBtnラベル発店名しない.Location = new System.Drawing.Point(100, 0);
			this.rBtnラベル発店名しない.Name = "rBtnラベル発店名しない";
			this.rBtnラベル発店名しない.Size = new System.Drawing.Size(80, 24);
			this.rBtnラベル発店名しない.TabIndex = 2;
			this.rBtnラベル発店名しない.Text = "印字しない";
			// 
			// labラベル印刷
			// 
			this.labラベル印刷.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.labラベル印刷.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labラベル印刷.ForeColor = System.Drawing.Color.White;
			this.labラベル印刷.Location = new System.Drawing.Point(0, 0);
			this.labラベル印刷.Name = "labラベル印刷";
			this.labラベル印刷.Size = new System.Drawing.Size(343, 22);
			this.labラベル印刷.TabIndex = 87;
			this.labラベル印刷.Text = "ラベル印刷";
			this.labラベル印刷.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pan郵便番号
			// 
			this.pan郵便番号.Controls.Add(this.rBtnラベル郵便番号しない);
			this.pan郵便番号.Controls.Add(this.rBtnラベル郵便番号する);
			this.pan郵便番号.Location = new System.Drawing.Point(140, 104);
			this.pan郵便番号.Name = "pan郵便番号";
			this.pan郵便番号.Size = new System.Drawing.Size(180, 24);
			this.pan郵便番号.TabIndex = 3;
			// 
			// rBtnラベル郵便番号しない
			// 
			this.rBtnラベル郵便番号しない.Location = new System.Drawing.Point(100, 0);
			this.rBtnラベル郵便番号しない.Name = "rBtnラベル郵便番号しない";
			this.rBtnラベル郵便番号しない.Size = new System.Drawing.Size(80, 24);
			this.rBtnラベル郵便番号しない.TabIndex = 2;
			this.rBtnラベル郵便番号しない.Text = "印字しない";
			// 
			// rBtnラベル郵便番号する
			// 
			this.rBtnラベル郵便番号する.Checked = true;
			this.rBtnラベル郵便番号する.Location = new System.Drawing.Point(0, 0);
			this.rBtnラベル郵便番号する.Name = "rBtnラベル郵便番号する";
			this.rBtnラベル郵便番号する.Size = new System.Drawing.Size(80, 24);
			this.rBtnラベル郵便番号する.TabIndex = 1;
			this.rBtnラベル郵便番号する.TabStop = true;
			this.rBtnラベル郵便番号する.Text = "印字する";
			// 
			// lab郵便番号
			// 
			this.lab郵便番号.BackColor = System.Drawing.Color.Honeydew;
			this.lab郵便番号.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab郵便番号.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab郵便番号.Location = new System.Drawing.Point(18, 110);
			this.lab郵便番号.Name = "lab郵便番号";
			this.lab郵便番号.Size = new System.Drawing.Size(100, 14);
			this.lab郵便番号.TabIndex = 100;
			this.lab郵便番号.Text = "郵便番号";
			// 
			// panel13
			// 
			this.panel13.Controls.Add(this.rBtn社名印字しない);
			this.panel13.Controls.Add(this.rBtn社名印字する);
			this.panel13.Location = new System.Drawing.Point(140, 188);
			this.panel13.Name = "panel13";
			this.panel13.Size = new System.Drawing.Size(180, 24);
			this.panel13.TabIndex = 4;
			// 
			// rBtn社名印字しない
			// 
			this.rBtn社名印字しない.Checked = true;
			this.rBtn社名印字しない.Location = new System.Drawing.Point(0, 0);
			this.rBtn社名印字しない.Name = "rBtn社名印字しない";
			this.rBtn社名印字しない.Size = new System.Drawing.Size(80, 24);
			this.rBtn社名印字しない.TabIndex = 3;
			this.rBtn社名印字しない.TabStop = true;
			this.rBtn社名印字しない.Text = "印字しない";
			// 
			// rBtn社名印字する
			// 
			this.rBtn社名印字する.Location = new System.Drawing.Point(100, 0);
			this.rBtn社名印字する.Name = "rBtn社名印字する";
			this.rBtn社名印字する.Size = new System.Drawing.Size(80, 24);
			this.rBtn社名印字する.TabIndex = 3;
			this.rBtn社名印字する.Text = "印字する";
			// 
			// label11
			// 
			this.label11.BackColor = System.Drawing.Color.Honeydew;
			this.label11.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label11.ForeColor = System.Drawing.Color.LimeGreen;
			this.label11.Location = new System.Drawing.Point(18, 194);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 14);
			this.label11.TabIndex = 98;
			this.label11.Text = "福山通運社名";
			// 
			// pn荷受人フォントサイズ
			// 
			this.pn荷受人フォントサイズ.Controls.Add(this.rBtnフォント自動拡大しない);
			this.pn荷受人フォントサイズ.Controls.Add(this.rBtnフォント自動拡大する);
			this.pn荷受人フォントサイズ.Location = new System.Drawing.Point(140, 78);
			this.pn荷受人フォントサイズ.Name = "pn荷受人フォントサイズ";
			this.pn荷受人フォントサイズ.Size = new System.Drawing.Size(198, 24);
			this.pn荷受人フォントサイズ.TabIndex = 2;
			// 
			// rBtnフォント自動拡大しない
			// 
			this.rBtnフォント自動拡大しない.Location = new System.Drawing.Point(100, 0);
			this.rBtnフォント自動拡大しない.Name = "rBtnフォント自動拡大しない";
			this.rBtnフォント自動拡大しない.TabIndex = 3;
			this.rBtnフォント自動拡大しない.Text = "自動拡大しない";
			// 
			// rBtnフォント自動拡大する
			// 
			this.rBtnフォント自動拡大する.Checked = true;
			this.rBtnフォント自動拡大する.Location = new System.Drawing.Point(0, 0);
			this.rBtnフォント自動拡大する.Name = "rBtnフォント自動拡大する";
			this.rBtnフォント自動拡大する.Size = new System.Drawing.Size(94, 24);
			this.rBtnフォント自動拡大する.TabIndex = 2;
			this.rBtnフォント自動拡大する.TabStop = true;
			this.rBtnフォント自動拡大する.Text = "自動拡大する";
			// 
			// label10
			// 
			this.label10.BackColor = System.Drawing.Color.Honeydew;
			this.label10.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label10.ForeColor = System.Drawing.Color.LimeGreen;
			this.label10.Location = new System.Drawing.Point(18, 84);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(112, 14);
			this.label10.TabIndex = 96;
			this.label10.Text = "荷受人フォントサイズ";
			// 
			// lab帳票印刷
			// 
			this.lab帳票印刷.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab帳票印刷.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lab帳票印刷.ForeColor = System.Drawing.Color.White;
			this.lab帳票印刷.Location = new System.Drawing.Point(0, 136);
			this.lab帳票印刷.Name = "lab帳票印刷";
			this.lab帳票印刷.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lab帳票印刷.Size = new System.Drawing.Size(343, 22);
			this.lab帳票印刷.TabIndex = 92;
			this.lab帳票印刷.Text = "帳票印刷";
			this.lab帳票印刷.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labお届け先コード
			// 
			this.labお届け先コード.BackColor = System.Drawing.Color.Honeydew;
			this.labお届け先コード.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labお届け先コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.labお届け先コード.Location = new System.Drawing.Point(18, 58);
			this.labお届け先コード.Name = "labお届け先コード";
			this.labお届け先コード.Size = new System.Drawing.Size(100, 14);
			this.labお届け先コード.TabIndex = 91;
			this.labお届け先コード.Text = "お届け先コード";
			// 
			// pnl荷受人コード
			// 
			this.pnl荷受人コード.Controls.Add(this.rBtnラベルお届け先ＣＤしない);
			this.pnl荷受人コード.Controls.Add(this.rBtnラベルお届け先ＣＤする);
			this.pnl荷受人コード.Location = new System.Drawing.Point(140, 52);
			this.pnl荷受人コード.Name = "pnl荷受人コード";
			this.pnl荷受人コード.Size = new System.Drawing.Size(180, 24);
			this.pnl荷受人コード.TabIndex = 1;
			// 
			// rBtnラベルお届け先ＣＤしない
			// 
			this.rBtnラベルお届け先ＣＤしない.Checked = true;
			this.rBtnラベルお届け先ＣＤしない.Location = new System.Drawing.Point(0, 0);
			this.rBtnラベルお届け先ＣＤしない.Name = "rBtnラベルお届け先ＣＤしない";
			this.rBtnラベルお届け先ＣＤしない.Size = new System.Drawing.Size(80, 24);
			this.rBtnラベルお届け先ＣＤしない.TabIndex = 1;
			this.rBtnラベルお届け先ＣＤしない.TabStop = true;
			this.rBtnラベルお届け先ＣＤしない.Text = "印字しない";
			// 
			// rBtnラベルお届け先ＣＤする
			// 
			this.rBtnラベルお届け先ＣＤする.Location = new System.Drawing.Point(100, 0);
			this.rBtnラベルお届け先ＣＤする.Name = "rBtnラベルお届け先ＣＤする";
			this.rBtnラベルお届け先ＣＤする.Size = new System.Drawing.Size(80, 24);
			this.rBtnラベルお届け先ＣＤする.TabIndex = 2;
			this.rBtnラベルお届け先ＣＤする.Text = "印字する";
			// 
			// lab出荷実績一覧表
			// 
			this.lab出荷実績一覧表.BackColor = System.Drawing.Color.Honeydew;
			this.lab出荷実績一覧表.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab出荷実績一覧表.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab出荷実績一覧表.Location = new System.Drawing.Point(18, 168);
			this.lab出荷実績一覧表.Name = "lab出荷実績一覧表";
			this.lab出荷実績一覧表.Size = new System.Drawing.Size(100, 14);
			this.lab出荷実績一覧表.TabIndex = 89;
			this.lab出荷実績一覧表.Text = "出荷実績一覧表";
			// 
			// pnl出荷実績一覧表
			// 
			this.pnl出荷実績一覧表.Controls.Add(this.rBtn出荷実績８行);
			this.pnl出荷実績一覧表.Controls.Add(this.rBtn出荷実績２行);
			this.pnl出荷実績一覧表.Location = new System.Drawing.Point(140, 162);
			this.pnl出荷実績一覧表.Name = "pnl出荷実績一覧表";
			this.pnl出荷実績一覧表.Size = new System.Drawing.Size(180, 24);
			this.pnl出荷実績一覧表.TabIndex = 3;
			// 
			// rBtn出荷実績８行
			// 
			this.rBtn出荷実績８行.Checked = true;
			this.rBtn出荷実績８行.Location = new System.Drawing.Point(0, 0);
			this.rBtn出荷実績８行.Name = "rBtn出荷実績８行";
			this.rBtn出荷実績８行.Size = new System.Drawing.Size(80, 24);
			this.rBtn出荷実績８行.TabIndex = 1;
			this.rBtn出荷実績８行.TabStop = true;
			this.rBtn出荷実績８行.Text = "８行";
			// 
			// rBtn出荷実績２行
			// 
			this.rBtn出荷実績２行.Location = new System.Drawing.Point(100, 0);
			this.rBtn出荷実績２行.Name = "rBtn出荷実績２行";
			this.rBtn出荷実績２行.Size = new System.Drawing.Size(80, 24);
			this.rBtn出荷実績２行.TabIndex = 2;
			this.rBtn出荷実績２行.Text = "２行";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 450);
			this.label1.TabIndex = 44;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// gpb左
			// 
			this.gpb左.BackColor = System.Drawing.Color.Honeydew;
			this.gpb左.Controls.Add(this.lab保険金額チェック);
			this.gpb左.Controls.Add(this.pnl保険金額チェック);
			this.gpb左.Controls.Add(this.lab依頼主重量考慮);
			this.gpb左.Controls.Add(this.pnl依頼主重量考慮);
			this.gpb左.Controls.Add(this.panel11);
			this.gpb左.Controls.Add(this.labバーコード読取専用);
			this.gpb左.Controls.Add(this.lab前詰め);
			this.gpb左.Controls.Add(this.pan前詰め);
			this.gpb左.Controls.Add(this.label6);
			this.gpb左.Controls.Add(this.panel12);
			this.gpb左.Controls.Add(this.label4);
			this.gpb左.Controls.Add(this.label3);
			this.gpb左.Controls.Add(this.label2);
			this.gpb左.Controls.Add(this.panel16);
			this.gpb左.Controls.Add(this.lab保険金額);
			this.gpb左.Controls.Add(this.panel15);
			this.gpb左.Controls.Add(this.lab重量入力方法);
			this.gpb左.Controls.Add(this.panel14);
			this.gpb左.Controls.Add(this.lab重量);
			this.gpb左.Controls.Add(this.pnl品名記事１);
			this.gpb左.Controls.Add(this.lab品名記事１);
			this.gpb左.Controls.Add(this.panel10);
			this.gpb左.Controls.Add(this.lab輸送商品);
			this.gpb左.Controls.Add(this.panel9);
			this.gpb左.Controls.Add(this.labお客様番号);
			this.gpb左.Controls.Add(this.panel5);
			this.gpb左.Controls.Add(this.lab担当);
			this.gpb左.Controls.Add(this.panel4);
			this.gpb左.Controls.Add(this.lab届け先名前２);
			this.gpb左.Controls.Add(this.panel3);
			this.gpb左.Controls.Add(this.lab届け先住所３);
			this.gpb左.Controls.Add(this.panel2);
			this.gpb左.Controls.Add(this.lab届け先住所２);
			this.gpb左.ForeColor = System.Drawing.Color.Black;
			this.gpb左.Location = new System.Drawing.Point(44, 4);
			this.gpb左.Name = "gpb左";
			this.gpb左.Size = new System.Drawing.Size(344, 440);
			this.gpb左.TabIndex = 0;
			this.gpb左.TabStop = false;
			// 
			// lab依頼主重量考慮
			// 
			this.lab依頼主重量考慮.BackColor = System.Drawing.Color.Honeydew;
			this.lab依頼主重量考慮.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab依頼主重量考慮.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab依頼主重量考慮.Location = new System.Drawing.Point(18, 382);
			this.lab依頼主重量考慮.Name = "lab依頼主重量考慮";
			this.lab依頼主重量考慮.Size = new System.Drawing.Size(112, 14);
			this.lab依頼主重量考慮.TabIndex = 92;
			this.lab依頼主重量考慮.Text = "ご依頼主固定重量";
			// 
			// pnl依頼主重量考慮
			// 
			this.pnl依頼主重量考慮.Controls.Add(this.rBtn依頼主重量考慮しない);
			this.pnl依頼主重量考慮.Controls.Add(this.rBtn依頼主重量考慮する);
			this.pnl依頼主重量考慮.Location = new System.Drawing.Point(140, 376);
			this.pnl依頼主重量考慮.Name = "pnl依頼主重量考慮";
			this.pnl依頼主重量考慮.Size = new System.Drawing.Size(180, 24);
			this.pnl依頼主重量考慮.TabIndex = 91;
			// 
			// rBtn依頼主重量考慮しない
			// 
			this.rBtn依頼主重量考慮しない.Checked = true;
			this.rBtn依頼主重量考慮しない.Location = new System.Drawing.Point(0, 0);
			this.rBtn依頼主重量考慮しない.Name = "rBtn依頼主重量考慮しない";
			this.rBtn依頼主重量考慮しない.Size = new System.Drawing.Size(80, 24);
			this.rBtn依頼主重量考慮しない.TabIndex = 1;
			this.rBtn依頼主重量考慮しない.TabStop = true;
			this.rBtn依頼主重量考慮しない.Text = "使用しない";
			// 
			// rBtn依頼主重量考慮する
			// 
			this.rBtn依頼主重量考慮する.Location = new System.Drawing.Point(100, 0);
			this.rBtn依頼主重量考慮する.Name = "rBtn依頼主重量考慮する";
			this.rBtn依頼主重量考慮する.Size = new System.Drawing.Size(80, 24);
			this.rBtn依頼主重量考慮する.TabIndex = 2;
			this.rBtn依頼主重量考慮する.Text = "使用する";
			// 
			// panel11
			// 
			this.panel11.Controls.Add(this.rBtn読取表示する);
			this.panel11.Controls.Add(this.rBtn読取表示しない);
			this.panel11.Location = new System.Drawing.Point(140, 400);
			this.panel11.Name = "panel11";
			this.panel11.Size = new System.Drawing.Size(180, 24);
			this.panel11.TabIndex = 12;
			// 
			// rBtn読取表示する
			// 
			this.rBtn読取表示する.Checked = true;
			this.rBtn読取表示する.Location = new System.Drawing.Point(0, 0);
			this.rBtn読取表示する.Name = "rBtn読取表示する";
			this.rBtn読取表示する.Size = new System.Drawing.Size(80, 24);
			this.rBtn読取表示する.TabIndex = 1;
			this.rBtn読取表示する.TabStop = true;
			this.rBtn読取表示する.Text = "表示する";
			// 
			// rBtn読取表示しない
			// 
			this.rBtn読取表示しない.Location = new System.Drawing.Point(100, 0);
			this.rBtn読取表示しない.Name = "rBtn読取表示しない";
			this.rBtn読取表示しない.Size = new System.Drawing.Size(80, 24);
			this.rBtn読取表示しない.TabIndex = 2;
			this.rBtn読取表示しない.Text = "表示しない";
			// 
			// labバーコード読取専用
			// 
			this.labバーコード読取専用.BackColor = System.Drawing.Color.Honeydew;
			this.labバーコード読取専用.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labバーコード読取専用.ForeColor = System.Drawing.Color.LimeGreen;
			this.labバーコード読取専用.Location = new System.Drawing.Point(16, 406);
			this.labバーコード読取専用.Name = "labバーコード読取専用";
			this.labバーコード読取専用.Size = new System.Drawing.Size(122, 14);
			this.labバーコード読取専用.TabIndex = 90;
			this.labバーコード読取専用.Text = "ﾊﾞｰｺｰﾄﾞ読取専用画面";
			// 
			// lab前詰め
			// 
			this.lab前詰め.BackColor = System.Drawing.Color.Honeydew;
			this.lab前詰め.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab前詰め.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab前詰め.Location = new System.Drawing.Point(18, 310);
			this.lab前詰め.Name = "lab前詰め";
			this.lab前詰め.Size = new System.Drawing.Size(120, 14);
			this.lab前詰め.TabIndex = 89;
			this.lab前詰め.Text = "住所・氏名等の前詰め";
			// 
			// pan前詰め
			// 
			this.pan前詰め.Controls.Add(this.rBtn前詰めする);
			this.pan前詰め.Controls.Add(this.rBtn前詰めしない);
			this.pan前詰め.Location = new System.Drawing.Point(140, 304);
			this.pan前詰め.Name = "pan前詰め";
			this.pan前詰め.Size = new System.Drawing.Size(180, 24);
			this.pan前詰め.TabIndex = 9;
			// 
			// rBtn前詰めする
			// 
			this.rBtn前詰めする.Checked = true;
			this.rBtn前詰めする.Location = new System.Drawing.Point(0, 0);
			this.rBtn前詰めする.Name = "rBtn前詰めする";
			this.rBtn前詰めする.Size = new System.Drawing.Size(80, 24);
			this.rBtn前詰めする.TabIndex = 1;
			this.rBtn前詰めする.TabStop = true;
			this.rBtn前詰めする.Text = "前詰めする";
			// 
			// rBtn前詰めしない
			// 
			this.rBtn前詰めしない.Location = new System.Drawing.Point(100, 0);
			this.rBtn前詰めしない.Name = "rBtn前詰めしない";
			this.rBtn前詰めしない.Size = new System.Drawing.Size(80, 24);
			this.rBtn前詰めしない.TabIndex = 2;
			this.rBtn前詰めしない.Text = "しない";
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Honeydew;
			this.label6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label6.ForeColor = System.Drawing.Color.LimeGreen;
			this.label6.Location = new System.Drawing.Point(18, 120);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 14);
			this.label6.TabIndex = 87;
			this.label6.Text = "ご依頼主コード";
			// 
			// panel12
			// 
			this.panel12.Controls.Add(this.rBtn依頼主入力する);
			this.panel12.Controls.Add(this.rBtn依頼主入力しない);
			this.panel12.Location = new System.Drawing.Point(140, 114);
			this.panel12.Name = "panel12";
			this.panel12.Size = new System.Drawing.Size(180, 24);
			this.panel12.TabIndex = 3;
			// 
			// rBtn依頼主入力する
			// 
			this.rBtn依頼主入力する.Checked = true;
			this.rBtn依頼主入力する.Location = new System.Drawing.Point(0, 0);
			this.rBtn依頼主入力する.Name = "rBtn依頼主入力する";
			this.rBtn依頼主入力する.Size = new System.Drawing.Size(80, 24);
			this.rBtn依頼主入力する.TabIndex = 1;
			this.rBtn依頼主入力する.TabStop = true;
			this.rBtn依頼主入力する.Text = "入力する";
			// 
			// rBtn依頼主入力しない
			// 
			this.rBtn依頼主入力しない.Location = new System.Drawing.Point(100, 0);
			this.rBtn依頼主入力しない.Name = "rBtn依頼主入力しない";
			this.rBtn依頼主入力しない.Size = new System.Drawing.Size(80, 24);
			this.rBtn依頼主入力しない.TabIndex = 2;
			this.rBtn依頼主入力しない.Text = "入力しない";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label4.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(0, 162);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(343, 22);
			this.label4.TabIndex = 85;
			this.label4.Text = "その他";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label3.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(0, 92);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(343, 22);
			this.label3.TabIndex = 84;
			this.label3.Text = "ご依頼主";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label2.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(343, 22);
			this.label2.TabIndex = 83;
			this.label2.Text = "お届け先";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel16
			// 
			this.panel16.Controls.Add(this.rBtn保険金額する);
			this.panel16.Controls.Add(this.rBtn保険金額しない);
			this.panel16.Location = new System.Drawing.Point(140, 256);
			this.panel16.Name = "panel16";
			this.panel16.Size = new System.Drawing.Size(180, 24);
			this.panel16.TabIndex = 8;
			// 
			// rBtn保険金額する
			// 
			this.rBtn保険金額する.Checked = true;
			this.rBtn保険金額する.Location = new System.Drawing.Point(0, 0);
			this.rBtn保険金額する.Name = "rBtn保険金額する";
			this.rBtn保険金額する.Size = new System.Drawing.Size(80, 24);
			this.rBtn保険金額する.TabIndex = 1;
			this.rBtn保険金額する.TabStop = true;
			this.rBtn保険金額する.Text = "入力する";
			// 
			// rBtn保険金額しない
			// 
			this.rBtn保険金額しない.Location = new System.Drawing.Point(100, 0);
			this.rBtn保険金額しない.Name = "rBtn保険金額しない";
			this.rBtn保険金額しない.Size = new System.Drawing.Size(80, 24);
			this.rBtn保険金額しない.TabIndex = 2;
			this.rBtn保険金額しない.Text = "入力しない";
			// 
			// lab保険金額
			// 
			this.lab保険金額.BackColor = System.Drawing.Color.Honeydew;
			this.lab保険金額.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab保険金額.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab保険金額.Location = new System.Drawing.Point(18, 262);
			this.lab保険金額.Name = "lab保険金額";
			this.lab保険金額.Size = new System.Drawing.Size(100, 14);
			this.lab保険金額.TabIndex = 81;
			this.lab保険金額.Text = "保険金額";
			// 
			// panel15
			// 
			this.panel15.Controls.Add(this.rBtn重量入力);
			this.panel15.Controls.Add(this.rBtn才数入力);
			this.panel15.Location = new System.Drawing.Point(140, 352);
			this.panel15.Name = "panel15";
			this.panel15.Size = new System.Drawing.Size(180, 24);
			this.panel15.TabIndex = 11;
			this.panel15.Visible = false;
			// 
			// rBtn重量入力
			// 
			this.rBtn重量入力.Checked = true;
			this.rBtn重量入力.Location = new System.Drawing.Point(0, 0);
			this.rBtn重量入力.Name = "rBtn重量入力";
			this.rBtn重量入力.Size = new System.Drawing.Size(80, 24);
			this.rBtn重量入力.TabIndex = 1;
			this.rBtn重量入力.TabStop = true;
			this.rBtn重量入力.Text = "重量";
			// 
			// rBtn才数入力
			// 
			this.rBtn才数入力.Location = new System.Drawing.Point(100, 0);
			this.rBtn才数入力.Name = "rBtn才数入力";
			this.rBtn才数入力.Size = new System.Drawing.Size(80, 24);
			this.rBtn才数入力.TabIndex = 2;
			this.rBtn才数入力.Text = "才数";
			// 
			// lab重量入力方法
			// 
			this.lab重量入力方法.BackColor = System.Drawing.Color.Honeydew;
			this.lab重量入力方法.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab重量入力方法.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab重量入力方法.Location = new System.Drawing.Point(54, 358);
			this.lab重量入力方法.Name = "lab重量入力方法";
			this.lab重量入力方法.Size = new System.Drawing.Size(60, 14);
			this.lab重量入力方法.TabIndex = 79;
			this.lab重量入力方法.Text = "入力方法";
			this.lab重量入力方法.Visible = false;
			// 
			// panel14
			// 
			this.panel14.Controls.Add(this.rBtn重量する);
			this.panel14.Controls.Add(this.rBtn重量しない);
			this.panel14.Location = new System.Drawing.Point(140, 328);
			this.panel14.Name = "panel14";
			this.panel14.Size = new System.Drawing.Size(180, 24);
			this.panel14.TabIndex = 10;
			this.panel14.Visible = false;
			// 
			// rBtn重量する
			// 
			this.rBtn重量する.Checked = true;
			this.rBtn重量する.Location = new System.Drawing.Point(0, 0);
			this.rBtn重量する.Name = "rBtn重量する";
			this.rBtn重量する.Size = new System.Drawing.Size(80, 24);
			this.rBtn重量する.TabIndex = 1;
			this.rBtn重量する.TabStop = true;
			this.rBtn重量する.Text = "入力する";
			// 
			// rBtn重量しない
			// 
			this.rBtn重量しない.Location = new System.Drawing.Point(100, 0);
			this.rBtn重量しない.Name = "rBtn重量しない";
			this.rBtn重量しない.Size = new System.Drawing.Size(80, 24);
			this.rBtn重量しない.TabIndex = 2;
			this.rBtn重量しない.Text = "入力しない";
			// 
			// lab重量
			// 
			this.lab重量.BackColor = System.Drawing.Color.Honeydew;
			this.lab重量.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab重量.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab重量.Location = new System.Drawing.Point(18, 334);
			this.lab重量.Name = "lab重量";
			this.lab重量.Size = new System.Drawing.Size(100, 14);
			this.lab重量.TabIndex = 77;
			this.lab重量.Text = "重量";
			this.lab重量.Visible = false;
			// 
			// pnl品名記事１
			// 
			this.pnl品名記事１.Controls.Add(this.rBtn品名記事１＿６行);
			this.pnl品名記事１.Controls.Add(this.rBtn品名記事１しない);
			this.pnl品名記事１.Controls.Add(this.rBtn品名記事１＿３行);
			this.pnl品名記事１.Location = new System.Drawing.Point(140, 232);
			this.pnl品名記事１.Name = "pnl品名記事１";
			this.pnl品名記事１.Size = new System.Drawing.Size(180, 24);
			this.pnl品名記事１.TabIndex = 7;
			// 
			// rBtn品名記事１＿６行
			// 
			this.rBtn品名記事１＿６行.Checked = true;
			this.rBtn品名記事１＿６行.Location = new System.Drawing.Point(0, 0);
			this.rBtn品名記事１＿６行.Name = "rBtn品名記事１＿６行";
			this.rBtn品名記事１＿６行.Size = new System.Drawing.Size(48, 24);
			this.rBtn品名記事１＿６行.TabIndex = 1;
			this.rBtn品名記事１＿６行.TabStop = true;
			this.rBtn品名記事１＿６行.Text = "６行";
			// 
			// rBtn品名記事１しない
			// 
			this.rBtn品名記事１しない.Location = new System.Drawing.Point(100, 0);
			this.rBtn品名記事１しない.Name = "rBtn品名記事１しない";
			this.rBtn品名記事１しない.Size = new System.Drawing.Size(80, 24);
			this.rBtn品名記事１しない.TabIndex = 2;
			this.rBtn品名記事１しない.Text = "入力しない";
			// 
			// rBtn品名記事１＿３行
			// 
			this.rBtn品名記事１＿３行.Location = new System.Drawing.Point(50, 0);
			this.rBtn品名記事１＿３行.Name = "rBtn品名記事１＿３行";
			this.rBtn品名記事１＿３行.Size = new System.Drawing.Size(48, 24);
			this.rBtn品名記事１＿３行.TabIndex = 3;
			this.rBtn品名記事１＿３行.Text = "３行";
			// 
			// lab品名記事１
			// 
			this.lab品名記事１.BackColor = System.Drawing.Color.Honeydew;
			this.lab品名記事１.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab品名記事１.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab品名記事１.Location = new System.Drawing.Point(18, 238);
			this.lab品名記事１.Name = "lab品名記事１";
			this.lab品名記事１.Size = new System.Drawing.Size(100, 14);
			this.lab品名記事１.TabIndex = 71;
			this.lab品名記事１.Text = "記事・品名";
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.rBtn輸送商品する);
			this.panel10.Controls.Add(this.rBtn輸送商品しない);
			this.panel10.Location = new System.Drawing.Point(140, 208);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(180, 24);
			this.panel10.TabIndex = 6;
			// 
			// rBtn輸送商品する
			// 
			this.rBtn輸送商品する.Checked = true;
			this.rBtn輸送商品する.Location = new System.Drawing.Point(0, 0);
			this.rBtn輸送商品する.Name = "rBtn輸送商品する";
			this.rBtn輸送商品する.Size = new System.Drawing.Size(80, 24);
			this.rBtn輸送商品する.TabIndex = 1;
			this.rBtn輸送商品する.TabStop = true;
			this.rBtn輸送商品する.Text = "入力する";
			// 
			// rBtn輸送商品しない
			// 
			this.rBtn輸送商品しない.Location = new System.Drawing.Point(100, 0);
			this.rBtn輸送商品しない.Name = "rBtn輸送商品しない";
			this.rBtn輸送商品しない.Size = new System.Drawing.Size(80, 24);
			this.rBtn輸送商品しない.TabIndex = 2;
			this.rBtn輸送商品しない.Text = "入力しない";
			// 
			// lab輸送商品
			// 
			this.lab輸送商品.BackColor = System.Drawing.Color.Honeydew;
			this.lab輸送商品.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab輸送商品.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab輸送商品.Location = new System.Drawing.Point(18, 214);
			this.lab輸送商品.Name = "lab輸送商品";
			this.lab輸送商品.Size = new System.Drawing.Size(100, 14);
			this.lab輸送商品.TabIndex = 69;
			this.lab輸送商品.Text = "輸送商品";
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.rBtnお客様番号する);
			this.panel9.Controls.Add(this.rBtnお客様番号しない);
			this.panel9.Location = new System.Drawing.Point(140, 184);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(180, 24);
			this.panel9.TabIndex = 5;
			// 
			// rBtnお客様番号する
			// 
			this.rBtnお客様番号する.Checked = true;
			this.rBtnお客様番号する.Location = new System.Drawing.Point(0, 0);
			this.rBtnお客様番号する.Name = "rBtnお客様番号する";
			this.rBtnお客様番号する.Size = new System.Drawing.Size(80, 24);
			this.rBtnお客様番号する.TabIndex = 1;
			this.rBtnお客様番号する.TabStop = true;
			this.rBtnお客様番号する.Text = "入力する";
			// 
			// rBtnお客様番号しない
			// 
			this.rBtnお客様番号しない.Location = new System.Drawing.Point(100, 0);
			this.rBtnお客様番号しない.Name = "rBtnお客様番号しない";
			this.rBtnお客様番号しない.Size = new System.Drawing.Size(80, 24);
			this.rBtnお客様番号しない.TabIndex = 2;
			this.rBtnお客様番号しない.Text = "入力しない";
			// 
			// labお客様番号
			// 
			this.labお客様番号.BackColor = System.Drawing.Color.Honeydew;
			this.labお客様番号.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labお客様番号.ForeColor = System.Drawing.Color.LimeGreen;
			this.labお客様番号.Location = new System.Drawing.Point(18, 190);
			this.labお客様番号.Name = "labお客様番号";
			this.labお客様番号.Size = new System.Drawing.Size(100, 14);
			this.labお客様番号.TabIndex = 67;
			this.labお客様番号.Text = "お客様番号";
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.rBtn担当する);
			this.panel5.Controls.Add(this.rBtn担当しない);
			this.panel5.Location = new System.Drawing.Point(140, 138);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(180, 24);
			this.panel5.TabIndex = 4;
			// 
			// rBtn担当する
			// 
			this.rBtn担当する.Checked = true;
			this.rBtn担当する.Location = new System.Drawing.Point(0, 0);
			this.rBtn担当する.Name = "rBtn担当する";
			this.rBtn担当する.Size = new System.Drawing.Size(80, 24);
			this.rBtn担当する.TabIndex = 1;
			this.rBtn担当する.TabStop = true;
			this.rBtn担当する.Text = "入力する";
			// 
			// rBtn担当しない
			// 
			this.rBtn担当しない.Location = new System.Drawing.Point(100, 0);
			this.rBtn担当しない.Name = "rBtn担当しない";
			this.rBtn担当しない.Size = new System.Drawing.Size(80, 24);
			this.rBtn担当しない.TabIndex = 2;
			this.rBtn担当しない.Text = "入力しない";
			// 
			// lab担当
			// 
			this.lab担当.BackColor = System.Drawing.Color.Honeydew;
			this.lab担当.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab担当.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab担当.Location = new System.Drawing.Point(18, 144);
			this.lab担当.Name = "lab担当";
			this.lab担当.Size = new System.Drawing.Size(100, 14);
			this.lab担当.TabIndex = 65;
			this.lab担当.Text = "担当";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.rBtn届け先名前２する);
			this.panel4.Controls.Add(this.rBtn届け先名前２しない);
			this.panel4.Location = new System.Drawing.Point(140, 68);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(180, 24);
			this.panel4.TabIndex = 2;
			// 
			// rBtn届け先名前２する
			// 
			this.rBtn届け先名前２する.Checked = true;
			this.rBtn届け先名前２する.Location = new System.Drawing.Point(0, 0);
			this.rBtn届け先名前２する.Name = "rBtn届け先名前２する";
			this.rBtn届け先名前２する.Size = new System.Drawing.Size(80, 24);
			this.rBtn届け先名前２する.TabIndex = 1;
			this.rBtn届け先名前２する.TabStop = true;
			this.rBtn届け先名前２する.Text = "入力する";
			// 
			// rBtn届け先名前２しない
			// 
			this.rBtn届け先名前２しない.Location = new System.Drawing.Point(100, 0);
			this.rBtn届け先名前２しない.Name = "rBtn届け先名前２しない";
			this.rBtn届け先名前２しない.Size = new System.Drawing.Size(80, 24);
			this.rBtn届け先名前２しない.TabIndex = 2;
			this.rBtn届け先名前２しない.Text = "入力しない";
			// 
			// lab届け先名前２
			// 
			this.lab届け先名前２.BackColor = System.Drawing.Color.Honeydew;
			this.lab届け先名前２.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab届け先名前２.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab届け先名前２.Location = new System.Drawing.Point(18, 74);
			this.lab届け先名前２.Name = "lab届け先名前２";
			this.lab届け先名前２.Size = new System.Drawing.Size(108, 14);
			this.lab届け先名前２.TabIndex = 63;
			this.lab届け先名前２.Text = "お届け先名前２行目";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.rBtn届け先住所３する);
			this.panel3.Controls.Add(this.rBtn届け先住所３しない);
			this.panel3.Location = new System.Drawing.Point(140, 44);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(180, 24);
			this.panel3.TabIndex = 1;
			// 
			// rBtn届け先住所３する
			// 
			this.rBtn届け先住所３する.Checked = true;
			this.rBtn届け先住所３する.Location = new System.Drawing.Point(0, 0);
			this.rBtn届け先住所３する.Name = "rBtn届け先住所３する";
			this.rBtn届け先住所３する.Size = new System.Drawing.Size(80, 24);
			this.rBtn届け先住所３する.TabIndex = 1;
			this.rBtn届け先住所３する.TabStop = true;
			this.rBtn届け先住所３する.Text = "入力する";
			// 
			// rBtn届け先住所３しない
			// 
			this.rBtn届け先住所３しない.Location = new System.Drawing.Point(100, 0);
			this.rBtn届け先住所３しない.Name = "rBtn届け先住所３しない";
			this.rBtn届け先住所３しない.Size = new System.Drawing.Size(80, 24);
			this.rBtn届け先住所３しない.TabIndex = 2;
			this.rBtn届け先住所３しない.Text = "入力しない";
			// 
			// lab届け先住所３
			// 
			this.lab届け先住所３.BackColor = System.Drawing.Color.Honeydew;
			this.lab届け先住所３.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab届け先住所３.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab届け先住所３.Location = new System.Drawing.Point(88, 50);
			this.lab届け先住所３.Name = "lab届け先住所３";
			this.lab届け先住所３.Size = new System.Drawing.Size(38, 14);
			this.lab届け先住所３.TabIndex = 61;
			this.lab届け先住所３.Text = "３行目";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.rBtn届け先住所２する);
			this.panel2.Controls.Add(this.rBtn届け先住所２しない);
			this.panel2.Location = new System.Drawing.Point(140, 22);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(180, 24);
			this.panel2.TabIndex = 0;
			// 
			// rBtn届け先住所２する
			// 
			this.rBtn届け先住所２する.Checked = true;
			this.rBtn届け先住所２する.Location = new System.Drawing.Point(0, -2);
			this.rBtn届け先住所２する.Name = "rBtn届け先住所２する";
			this.rBtn届け先住所２する.Size = new System.Drawing.Size(80, 24);
			this.rBtn届け先住所２する.TabIndex = 1;
			this.rBtn届け先住所２する.TabStop = true;
			this.rBtn届け先住所２する.Text = "入力する";
			// 
			// rBtn届け先住所２しない
			// 
			this.rBtn届け先住所２しない.Location = new System.Drawing.Point(100, -2);
			this.rBtn届け先住所２しない.Name = "rBtn届け先住所２しない";
			this.rBtn届け先住所２しない.Size = new System.Drawing.Size(80, 24);
			this.rBtn届け先住所２しない.TabIndex = 2;
			this.rBtn届け先住所２しない.Text = "入力しない";
			// 
			// lab届け先住所２
			// 
			this.lab届け先住所２.BackColor = System.Drawing.Color.Honeydew;
			this.lab届け先住所２.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab届け先住所２.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab届け先住所２.Location = new System.Drawing.Point(18, 26);
			this.lab届け先住所２.Name = "lab届け先住所２";
			this.lab届け先住所２.Size = new System.Drawing.Size(108, 14);
			this.lab届け先住所２.TabIndex = 60;
			this.lab届け先住所２.Text = "お届け先住所２行目";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(0, 0);
			this.label5.Name = "label5";
			this.label5.TabIndex = 0;
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
			this.panel7.Controls.Add(this.lab才数切り替えタイトル);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(796, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab才数切り替えタイトル
			// 
			this.lab才数切り替えタイトル.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab才数切り替えタイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab才数切り替えタイトル.ForeColor = System.Drawing.Color.White;
			this.lab才数切り替えタイトル.Location = new System.Drawing.Point(12, 2);
			this.lab才数切り替えタイトル.Name = "lab才数切り替えタイトル";
			this.lab才数切り替えタイトル.Size = new System.Drawing.Size(264, 24);
			this.lab才数切り替えタイトル.TabIndex = 0;
			this.lab才数切り替えタイトル.Text = "エントリーオプション";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn更新);
			this.panel8.Controls.Add(this.texメッセージ);
			this.panel8.Controls.Add(this.btn閉じる);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(794, 58);
			this.panel8.TabIndex = 2;
			// 
			// btn更新
			// 
			this.btn更新.ForeColor = System.Drawing.Color.Blue;
			this.btn更新.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn更新.Location = new System.Drawing.Point(70, 6);
			this.btn更新.Name = "btn更新";
			this.btn更新.Size = new System.Drawing.Size(54, 48);
			this.btn更新.TabIndex = 1;
			this.btn更新.Text = "保存";
			this.btn更新.Click += new System.EventHandler(this.btn更新_Click);
			// 
			// texメッセージ
			// 
			this.texメッセージ.BackColor = System.Drawing.Color.PaleGreen;
			this.texメッセージ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texメッセージ.ForeColor = System.Drawing.Color.Red;
			this.texメッセージ.Location = new System.Drawing.Point(130, 4);
			this.texメッセージ.Multiline = true;
			this.texメッセージ.Name = "texメッセージ";
			this.texメッセージ.ReadOnly = true;
			this.texメッセージ.Size = new System.Drawing.Size(382, 50);
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
			this.groupBox3.Location = new System.Drawing.Point(8, 54);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(780, 456);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			// 
			// pnl保険金額チェック
			// 
			this.pnl保険金額チェック.Controls.Add(this.rBtn保険金額チェックする);
			this.pnl保険金額チェック.Controls.Add(this.rBtn保険金額チェックしない);
			this.pnl保険金額チェック.Location = new System.Drawing.Point(140, 280);
			this.pnl保険金額チェック.Name = "pnl保険金額チェック";
			this.pnl保険金額チェック.Size = new System.Drawing.Size(198, 24);
			this.pnl保険金額チェック.TabIndex = 93;
			// 
			// rBtn保険金額チェックする
			// 
			this.rBtn保険金額チェックする.Checked = true;
			this.rBtn保険金額チェックする.Location = new System.Drawing.Point(0, 0);
			this.rBtn保険金額チェックする.Name = "rBtn保険金額チェックする";
			this.rBtn保険金額チェックする.Size = new System.Drawing.Size(80, 24);
			this.rBtn保険金額チェックする.TabIndex = 1;
			this.rBtn保険金額チェックする.TabStop = true;
			this.rBtn保険金額チェックする.Text = "チェックする";
			// 
			// rBtn保険金額チェックしない
			// 
			this.rBtn保険金額チェックしない.Location = new System.Drawing.Point(100, 0);
			this.rBtn保険金額チェックしない.Name = "rBtn保険金額チェックしない";
			this.rBtn保険金額チェックしない.Size = new System.Drawing.Size(92, 24);
			this.rBtn保険金額チェックしない.TabIndex = 2;
			this.rBtn保険金額チェックしない.Text = "チェックしない";
			// 
			// lab保険金額チェック
			// 
			this.lab保険金額チェック.BackColor = System.Drawing.Color.Honeydew;
			this.lab保険金額チェック.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab保険金額チェック.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab保険金額チェック.Location = new System.Drawing.Point(18, 286);
			this.lab保険金額チェック.Name = "lab保険金額チェック";
			this.lab保険金額チェック.Size = new System.Drawing.Size(114, 14);
			this.lab保険金額チェック.TabIndex = 94;
			this.lab保険金額チェック.Text = "保険金額入力チェック";
			// 
			// 才数切り替え
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(794, 582);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "才数切り替え";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 エントリーオプション";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
			this.Load += new System.EventHandler(this.才数切り替え_Load);
			this.Closed += new System.EventHandler(this.才数切り替え_Closed);
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).EndInit();
			this.panel1.ResumeLayout(false);
			this.grp右上.ResumeLayout(false);
			this.pnlＣＳＶ出力形式.ResumeLayout(false);
			this.gpb右.ResumeLayout(false);
			this.pnl発店名.ResumeLayout(false);
			this.pan郵便番号.ResumeLayout(false);
			this.panel13.ResumeLayout(false);
			this.pn荷受人フォントサイズ.ResumeLayout(false);
			this.pnl荷受人コード.ResumeLayout(false);
			this.pnl出荷実績一覧表.ResumeLayout(false);
			this.gpb左.ResumeLayout(false);
			this.pnl依頼主重量考慮.ResumeLayout(false);
			this.panel11.ResumeLayout(false);
			this.pan前詰め.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			this.panel16.ResumeLayout(false);
			this.panel15.ResumeLayout(false);
			this.panel14.ResumeLayout(false);
			this.pnl品名記事１.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.pnl保険金額チェック.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void 才数切り替え_Load(object sender, System.EventArgs e)
		{
// MOD 2009.05.01 東都）高木 オプションの項目追加 START
			s制御項目ＦＧ = new string[s制御項目名.Length];
			s制御項目有無 = new string[s制御項目名.Length];
// MOD 2009.05.01 東都）高木 オプションの項目追加 END
// MOD 2005.06.10 東都）伊賀 画面制御項目追加 START
//			try
//			{
//				画面制御検索(rBtn届け先住所２する,rBtn届け先住所２しない,0);
//				画面制御検索(rBtn届け先住所３する,rBtn届け先住所３しない,1);
//				画面制御検索(rBtn届け先名前２する,rBtn届け先名前２しない,2);
//				画面制御検索(rBtn担当する,rBtn担当しない,3);
//				画面制御検索(rBtnお客様番号する,rBtnお客様番号しない,4);
//				画面制御検索(rBtn輸送商品する,rBtn輸送商品しない,5);
//				画面制御検索(rBtn品名記事１する,rBtn品名記事１しない,6);
//				画面制御検索(rBtn重量する,rBtn重量しない,7);
//				画面制御検索(rBtn重量入力,rBtn才数入力,8);
//				画面制御検索(rBtn保険金額する,rBtn保険金額しない,9);
//			}
//			catch(Exception ex)
//			{
//				texメッセージ.Text = ex.Message;
//			}
			画面制御検索();
			画面制御設定(rBtn届け先住所２する,rBtn届け先住所２しない,0);
			画面制御設定(rBtn届け先住所３する,rBtn届け先住所３しない,1);
			画面制御設定(rBtn届け先名前２する,rBtn届け先名前２しない,2);
			画面制御設定(rBtn担当する,rBtn担当しない,3);
			画面制御設定(rBtnお客様番号する,rBtnお客様番号しない,4);
			画面制御設定(rBtn輸送商品する,rBtn輸送商品しない,5);
// MOD 2011.08.05 東都）高木 記事行の追加（３行・６行切替対応） START
//			画面制御設定(rBtn品名記事１する,rBtn品名記事１しない,6);
			画面制御設定パネル(pnl品名記事１,6);
// MOD 2011.08.05 東都）高木 記事行の追加（３行・６行切替対応） END
// MOD 2011.04.13 東都）高木 重量入力不可対応 START
//			画面制御設定(rBtn重量する,rBtn重量しない,7);
//			画面制御設定(rBtn重量入力,rBtn才数入力,8);
// MOD 2011.04.13 東都）高木 重量入力不可対応 END
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
			画面制御設定(rBtn重量する,rBtn重量しない,7);
			画面制御設定(rBtn重量入力,rBtn才数入力,8);
			if(gs重量入力制御 == "1"){
				lab重量入力方法.Visible = true;
				panel14.Visible = true;
				lab重量.Visible = true;
				panel15.Visible = true;
			}else{
				lab重量入力方法.Visible = false;
				panel14.Visible = false;
				lab重量.Visible = false;
				panel15.Visible = false;
			}
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END
			画面制御設定(rBtn保険金額する,rBtn保険金額しない,9);
// MOD 2005.06.10 東都）伊賀 画面制御項目追加 END
// ADD 2006.06.28 東都）山本　 エントリオプションの項目追加 START
			画面制御設定(rBtn依頼主入力する,rBtn依頼主入力しない,10);
// ADD 2006.06.28 東都）山本　 エントリオプションの項目追加 END
// MOD 2009.05.01 東都）高木 オプションの項目追加 START
			画面制御設定(rBtnラベルお届け先ＣＤしない,rBtnラベルお届け先ＣＤする,11);
			画面制御設定(rBtn出荷実績８行,rBtn出荷実績２行,12);
// MOD 2009.11.06 PSN）藤井　出荷実績一覧表対応 START
//			画面制御設定(rBtn出荷実績依頼主改頁あり,rBtn出荷実績依頼主改頁なし,13);
//			if(rBtn出荷実績７行.Checked){
//				rBtn出荷実績依頼主改頁あり.Visible = false;
//				rBtn出荷実績依頼主改頁なし.Visible = false;
//			}
// MOD 2009.11.06 PSN）藤井　出荷実績一覧表対応 END
// MOD 2009.05.01 東都）高木 オプションの項目追加 END
// MOD 2009.10.23 PSN）藤井　オプションの項目追加 END
			画面制御設定(rBtnフォント自動拡大する,rBtnフォント自動拡大しない,14);
// MOD 2009.10.23 PSN）藤井　オプションの項目追加 END
// MOD 2009.11.06 PSN）藤井　出荷実績一覧表対応 START
			画面制御設定(rBtn社名印字しない,rBtn社名印字する,15);
// MOD 2009.11.06 PSN）藤井　出荷実績一覧表対応 END
// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）START
// MOD 2011.07.14 東都）高木 記事行の追加 START
//			画面制御設定(rBtn出荷ＣＳＶ標準,rBtn出荷ＣＳＶエントリー,16);
			画面制御設定パネル(pnlＣＳＶ出力形式,16);
// MOD 2011.07.14 東都）高木 記事行の追加 END
// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）END
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
			画面制御設定(rBtn前詰めする,rBtn前詰めしない,17);
			画面制御設定(rBtnラベル郵便番号する,rBtnラベル郵便番号しない,18);
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
// MOD 2011.03.08 東都）高木 王子運送対応 START
			if(gs会員ＣＤ.Substring(0,1) != "J"){
				label11.Text = "福山通運社名";
			}else{
				label11.Text = "王子運送社名";
			}
// MOD 2011.03.08 東都）高木 王子運送対応 END
// MOD 2012.04.10 東都）高木 ラベル発店名の印字制御対応 START
			画面制御設定(rBtnラベル発店名する,rBtnラベル発店名しない,20);
// MOD 2012.04.10 東都）高木 ラベル発店名の印字制御対応 END
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 START
			画面制御設定(rBtn読取表示する,rBtn読取表示しない,21);
			if(s制御項目ＦＧ[21].Equals("9"))
			{
				//デフォルト(＝AM04画面制御に該当レコードが存在しない場合)でのチェックは、「表示しない」の方にチェック
				rBtn読取表示する.Checked = false;
				rBtn読取表示しない.Checked = true;
			}
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 END
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 START
			画面制御設定(rBtn依頼主重量考慮しない,rBtn依頼主重量考慮する,22);
			if(gs重量入力制御 == "1")
			{
				lab依頼主重量考慮.Visible = true;
				pnl依頼主重量考慮.Visible = true;
			}
			else
			{
				lab依頼主重量考慮.Visible = false;
				pnl依頼主重量考慮.Visible = false;
			}
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
// MOD 2016.06.10 BEVAS）松本 保険料入力チェック機能の追加 START
			画面制御設定(rBtn保険金額チェックする,rBtn保険金額チェックしない,23);
			//「保険金額」項目が『入力する』にチェックが入っている場合、「保険金額入力チェック」項目を表示する
			if(rBtn保険金額する.Checked)
			{
				lab保険金額チェック.Visible = true;
				pnl保険金額チェック.Visible = true;
			}
			else
			{
				lab保険金額チェック.Visible = false;
				pnl保険金額チェック.Visible = false;
			}
// MOD 2016.06.10 BEVAS）松本 保険料入力チェック機能の追加 END
		}
// ADD 2005.06.10 東都）伊賀 画面制御項目追加 START
		private void 画面制御検索()
		{
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sList = {""};
			try
			{
				texメッセージ.Text = "検索中．．．";
				if(sv_init == null) sv_init = new is2init.Service1();
// MOD 2009.05.01 東都）高木 オプションの項目追加 START
//				sList = sv_init.Get_seigyo(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
				sList = sv_init.Get_seigyo2(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ, s制御項目ＦＧ.Length);
// MOD 2009.05.01 東都）高木 オプションの項目追加 END
			}
			catch (System.Net.WebException)
			{
				sList[0] = gs通信エラー;
				return;
			}
			catch (Exception ex)
			{
				sList[0] = "通信エラー：" + ex.Message;
				return;
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;

			texメッセージ.Text = "";

			if(sList[0].Length == 4)
			{
// MOD 2009.05.01 東都）高木 オプションの項目追加 START
//				for (int iCnt = 1; iCnt < sList.Length; iCnt++)
				int iCnt = 1;
				for (; iCnt-1 < s制御項目ＦＧ.Length && iCnt < sList.Length; iCnt++)
// MOD 2009.05.01 東都）高木 オプションの項目追加 END
				{
					s制御項目ＦＧ[iCnt-1] = sList[iCnt];
				}
// MOD 2009.05.01 東都）高木 オプションの項目追加 START
				for (; iCnt-1 < s制御項目ＦＧ.Length; iCnt++)
				{
					s制御項目ＦＧ[iCnt-1] = "9";
				}
// MOD 2009.05.01 東都）高木 オプションの項目追加 END
			}
			else
			{
				texメッセージ.Text = sList[0];
				ビープ音();
			}
			return;
		}
		private void 画面制御設定(System.Windows.Forms.RadioButton rBtn項目１, System.Windows.Forms.RadioButton rBtn項目２, int iCnt)
		{
			if(s制御項目ＦＧ[iCnt].Equals("9"))
			{
				rBtn項目１.Checked = true;
				rBtn項目２.Checked = false;
				s制御項目有無[iCnt] = "0";
			}
			else
			{
				if(s制御項目ＦＧ[iCnt].Equals("0"))
				{
					rBtn項目１.Checked = true;
					rBtn項目２.Checked = false;
				}
				else
				{
					rBtn項目１.Checked = false;
					rBtn項目２.Checked = true;
				}
				s制御項目有無[iCnt] = "1";
			}
		}
// ADD 2005.06.10 東都）伊賀 画面制御項目追加 END
// MOD 2011.07.14 東都）高木 記事行の追加 START
		private void 画面制御設定パネル(Panel pnl項目, int iCnt)
		{
			if(s制御項目ＦＧ[iCnt].Equals("9")){
				foreach(object obj in pnl項目.Controls){
					if(obj is RadioButton){
						RadioButton rBtn項目 = (RadioButton)obj;
						if(rBtn項目.TabIndex == 1){
							rBtn項目.Checked = true;
							break;
						}
					}
				}
				s制御項目有無[iCnt] = "0";
			}else{
				foreach(object obj in pnl項目.Controls){
					if(obj is RadioButton){
						RadioButton rBtn項目 = (RadioButton)obj;
						if((rBtn項目.TabIndex - 1).ToString() == s制御項目ＦＧ[iCnt]){
							rBtn項目.Checked = true;
							break;
						}
					}
				}
				s制御項目有無[iCnt] = "1";
			}
		}
// MOD 2011.07.14 東都）高木 記事行の追加 END

// DEL 2005.06.10 東都）伊賀 画面制御項目追加 START
/*
		private void 画面制御検索(System.Windows.Forms.RadioButton rBtn項目１, System.Windows.Forms.RadioButton rBtn項目２, int iCnt)
		{
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sList = {""};
			try
			{
				texメッセージ.Text = "検索中．．．";
				if(sv_init == null) sv_init = new is2init.Service1();
//				sList = sv_init.Get_seigyo(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,(iCnt+1).ToString());
			}
			catch (System.Net.WebException)
			{
				sList[0] = gs通信エラー;
				throw new Exception(sList[0]);
			}
			catch (Exception ex)
			{
				sList[0] = "通信エラー：" + ex.Message;
				throw new Exception(sList[0]);
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;

			texメッセージ.Text = "";

			// 異常終了時
			if(sList[0].Length == 1)
			{
				if(sList[0].Equals("9"))
				{
					rBtn項目１.Checked = true;
					rBtn項目２.Checked = false;
					s制御項目有無[iCnt] = "0";
				}
				else
				{
					if(sList[0].Equals("0"))
					{
						rBtn項目１.Checked = true;
						rBtn項目２.Checked = false;
					}
					else
					{
						rBtn項目１.Checked = false;
						rBtn項目２.Checked = true;
					}
					s制御項目有無[iCnt] = "1";
				}
			}
			else
			{
				texメッセージ.Text = sList[0];
				ビープ音();
				throw new Exception(sList[0]);
			}
		}
*/
// DEL 2005.06.10 東都）伊賀 画面制御項目追加 END

		private void btn更新_Click(object sender, System.EventArgs e)
		{
			try
			{
				画面制御更新(rBtn届け先住所２する,0);
				画面制御更新(rBtn届け先住所３する,1);
				画面制御更新(rBtn届け先名前２する,2);
				画面制御更新(rBtn担当する,3);
				画面制御更新(rBtnお客様番号する,4);
				画面制御更新(rBtn輸送商品する,5);
// MOD 2011.08.05 東都）高木 記事行の追加（３行・６行切替対応） START
//				画面制御更新(rBtn品名記事１する,6);
				画面制御更新パネル(pnl品名記事１,6);
// MOD 2011.08.05 東都）高木 記事行の追加（３行・６行切替対応） END
// MOD 2011.04.13 東都）高木 重量入力不可対応 START
//				画面制御更新(rBtn重量する,7);
//				画面制御更新(rBtn重量入力,8);
// MOD 2011.04.13 東都）高木 重量入力不可対応 END
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 START
				画面制御更新(rBtn重量する,7);
				画面制御更新(rBtn重量入力,8);
// MOD 2011.05.09 東都）高木 お客様毎の重量入力不可対応 END
				画面制御更新(rBtn保険金額する,9);
// ADD 2006.06.28 東都）山本　 エントリオプションの項目追加 START
				画面制御更新(rBtn依頼主入力する,10);
// ADD 2006.06.28 東都）山本　 エントリオプションの項目追加 END
// MOD 2009.05.01 東都）高木 オプションの項目追加 START
				画面制御更新(rBtnラベルお届け先ＣＤしない,11);
				画面制御更新(rBtn出荷実績８行,12);
// MOD 2009.11.06 PSN）藤井　出荷実績一覧表対応 START
//				画面制御更新(rBtn出荷実績依頼主改頁あり,13);
// MOD 2009.11.06 PSN）藤井　出荷実績一覧表対応 END
// MOD 2009.05.01 東都）高木 オプションの項目追加 END

// MOD 2009.10.23 PSN）藤井　オプションの項目追加 START
				画面制御更新(rBtnフォント自動拡大する,14);
// MOD 2009.10.23 PSN）藤井　オプションの項目追加 END
// MOD 2009.11.06 PSN）藤井　出荷実績一覧表対応 START
				画面制御更新(rBtn社名印字しない,15);
// MOD 2009.11.06 PSN）藤井　出荷実績一覧表対応 END
// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）START
// MOD 2011.07.14 東都）高木 記事行の追加 START
//				画面制御更新(rBtn出荷ＣＳＶ標準,16);
				画面制御更新パネル(pnlＣＳＶ出力形式,16);
// MOD 2011.07.14 東都）高木 記事行の追加 END
// MOD 2010.02.01 東都）高木 オプションの項目追加（ＣＳＶ出力形式）END
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
				画面制御更新(rBtn前詰めする,17);
				画面制御更新(rBtnラベル郵便番号する,18);
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
// MOD 2012.04.10 東都）高木 ラベル発店名の印字制御対応 START
				画面制御更新(rBtnラベル発店名する,20);
// MOD 2012.04.10 東都）高木 ラベル発店名の印字制御対応 END
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 START
				画面制御更新(rBtn読取表示する,21);
// ADD 2015.07.13 BEVAS) 松本 バーコード読取専用画面追加 END
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 START
				画面制御更新(rBtn依頼主重量考慮しない,22);
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
// MOD 2016.06.10 BEVAS）松本 保険料入力チェック機能の追加 START
				画面制御更新(rBtn保険金額チェックする,23);
// MOD 2016.06.10 BEVAS）松本 保険料入力チェック機能の追加 END
				this.Close();
			}
			catch(Exception ex)
			{
				texメッセージ.Text = ex.Message;
			}
		}


		private void 画面制御更新(System.Windows.Forms.RadioButton rBtn項目, int iCnt)
		{
			// データ作成
			String[] sKey = new string[7];
			sKey[0] = gs会員ＣＤ;
			sKey[1] = gs部門ＣＤ;
			sKey[2] = (iCnt + 1).ToString();
			sKey[3] = s制御項目名[iCnt];

			if(rBtn項目.Checked)
				sKey[4] = "0"; // 入力する
			else
				sKey[4] = "1"; // 入力しない

			sKey[5] = "画面制御";
			sKey[6] = gs利用者ＣＤ;

			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string sRet = "";
			try
			{
				if(s制御項目有無[iCnt].Equals("0"))
				{
					texメッセージ.Text = "登録中．．．";
					if(sv_init == null) sv_init = new is2init.Service1();
					sRet = sv_init.Ins_seigyo(gsaユーザ,sKey);
				}
				else
				{
					texメッセージ.Text = "更新中．．．";
					if(sv_init == null) sv_init = new is2init.Service1();
					sRet = sv_init.Upd_seigyo(gsaユーザ,sKey);
				}
			}
			catch (System.Net.WebException)
			{
				sRet = gs通信エラー;
				throw new Exception(sRet);
			}
			catch (Exception ex)
			{
				sRet = "通信エラー：" + ex.Message;
				throw new Exception(sRet);
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;
			texメッセージ.Text = sRet;
			// 正常終了時
			if(sRet.Length == 4)
			{
				texメッセージ.Text = "";
			}
			else
			{
				ビープ音();
				throw new Exception(sRet);
			}
		}
// MOD 2011.07.14 東都）高木 記事行の追加 START
		private void 画面制御更新パネル(Panel pnl項目, int iCnt)
		{
			// データ作成
			String[] sKey = new string[7];
			sKey[0] = gs会員ＣＤ;
			sKey[1] = gs部門ＣＤ;
			sKey[2] = (iCnt + 1).ToString();
			sKey[3] = s制御項目名[iCnt];

			foreach(object obj in pnl項目.Controls){
				if(obj is RadioButton){
					RadioButton rBtn項目 = (RadioButton)obj;
					if(rBtn項目.Checked){
						sKey[4] = (rBtn項目.TabIndex - 1).ToString();
						break;
					}
				}
			}

			sKey[5] = "画面制御";
			sKey[6] = gs利用者ＣＤ;

			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string sRet = "";
			try
			{
				if(s制御項目有無[iCnt].Equals("0"))
				{
					texメッセージ.Text = "登録中．．．";
					if(sv_init == null) sv_init = new is2init.Service1();
					sRet = sv_init.Ins_seigyo(gsaユーザ,sKey);
				}
				else
				{
					texメッセージ.Text = "更新中．．．";
					if(sv_init == null) sv_init = new is2init.Service1();
					sRet = sv_init.Upd_seigyo(gsaユーザ,sKey);
				}
			}
			catch (System.Net.WebException)
			{
				sRet = gs通信エラー;
				throw new Exception(sRet);
			}
			catch (Exception ex)
			{
				sRet = "通信エラー：" + ex.Message;
				throw new Exception(sRet);
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;
			texメッセージ.Text = sRet;
			// 正常終了時
			if(sRet.Length == 4)
			{
				texメッセージ.Text = "";
			}
			else
			{
				ビープ音();
				throw new Exception(sRet);
			}
		}
// MOD 2011.07.14 東都）高木 記事行の追加 END

		private void 才数切り替え_Closed(object sender, System.EventArgs e)
		{
			texメッセージ.Text = "";
			if(rBtn届け先住所２する.Checked)
				rBtn届け先住所２する.Focus();
			else
				rBtn届け先住所２しない.Focus();
		}

// MOD 2006.12.14 東都）小童谷 お届先全件削除追加 START
		private void btn削除_Click(object sender, System.EventArgs e)
		{
			DialogResult result;

			if (gログイン２ == null)	 gログイン２ = new ログイン２();
			gログイン２.b削除ログイン = false;
			gログイン２.ShowDialog(this);

			if(!gログイン２.b削除ログイン) return;

			result = MessageBox.Show("お届先情報を全て削除しますか？","全件削除",MessageBoxButtons.YesNo);
			if(result == DialogResult.Yes)
			{
				// カーソルを砂時計にする
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				String[] sDList = {""};
				string[] sData = new string[4];
				try
				{
					texメッセージ.Text = "削除中．．．";
					sData[0] = gs会員ＣＤ;
					sData[1] = gs部門ＣＤ;
					sData[2] = "画面制御";
					sData[3] = gs利用者ＣＤ;

					Cursor = System.Windows.Forms.Cursors.AppStarting;

					if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
					sDList = sv_otodoke.Del_todokesaki3(gsaユーザ,sData);
					texメッセージ.Text = sDList[0];
					Cursor = System.Windows.Forms.Cursors.Default;
					// [正常終了]時、画面をクリアする
					if(sDList[0].Length != 4)
					{
						ビープ音();
						return;
					}
				}
				catch (System.Net.WebException)
				{
					sDList[0] = gs通信エラー;
					Cursor = System.Windows.Forms.Cursors.Default;
					texメッセージ.Text = sDList[0];
					ビープ音();
				}
				catch (Exception ex)
				{
					sDList[0] = "通信エラー：" + ex.Message;
					Cursor = System.Windows.Forms.Cursors.Default;
					texメッセージ.Text = sDList[0];
					ビープ音();
				}
			}
		}

// MOD 2006.12.14 東都）小童谷 お届先全件削除追加 END

// MOD 2009.11.06 PSN）藤井　出荷実績一覧表対応 START
// MOD 2009.05.01 東都）高木 オプションの項目追加 START
//		private void rBtn出荷実績７行_CheckedChanged(object sender, System.EventArgs e)
//		{
//			rBtn出荷実績依頼主改頁あり.Visible = false;
//			rBtn出荷実績依頼主改頁なし.Visible = false;
//		}

//		private void rBtn出荷実績２行_CheckedChanged(object sender, System.EventArgs e)
//		{
//			rBtn出荷実績依頼主改頁あり.Visible = true;
//			rBtn出荷実績依頼主改頁なし.Visible = true;
//		}
// MOD 2009.05.01 東都）高木 オプションの項目追加 END
// MOD 2009.11.06 PSN）藤井　出荷実績一覧表対応 END
	}
}
