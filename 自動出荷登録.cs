using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Threading;

namespace IS2Client
{
	/// <summary>
	/// [ＣＳＶエントリー]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// MOD 2008.04.25 東都）高木 特殊計は全角は不可にする
	// ＡＣＴ）山本殿より障害報告有
	// ADD 2008.04.11 ACT Vista対応 
	// ADD 2008.05.14 東都）高木 Unicodeファイルの改行対応 
	// MOD 2008.06.12 kcl)森本 着店コード検索方法の変更
	//  btn確認_Click
	// MOD 2008.11.19 東都）高木 着店コードが空白でもエラーでなくする 
	// MOD 2008.12.25 kcl)森本 着店コード検索方法の再変更
	//--------------------------------------------------------------------------
	// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック 
	// MOD 2009.04.06 東都）高木 先頭行無視機能の追加 
	// MOD 2009.11.25 東都）高木 時間指定チェックの追加 
	// MOD 2009.12.01 東都）高木 全角半角混在可能にする 
	// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 
	//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 
	// MOD 2009.12.08 東都）高木 指定日の上限障害（上記のグローバル対応の障害）
	//--------------------------------------------------------------------------
	// MOD 2010.02.25 東都）高木 項目数チェックの修正 
	// MOD 2010.02.25 東都）高木 ヘッダ行自動判別機能の追加 
	// MOD 2010.03.18 東都）高木 データ無しチェックの追加 
	// MOD 2010.03.30 東都）高木 携帯電話対応 
	// MOD 2010.04.19 東都）高木 出力ファイル名の変更 
	// MOD 2010.05.25 東都）高木 時間指定の変更 
	// MOD 2010.09.03 東都）高木 ＣＳＶエントリー時の請求先エラー表記修正 
	// MOD 2010.10.01 東都）高木 お客様番号１６桁化 
	// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 
	// MOD 2010.11.02 東都）高木 数値範囲チェックの変更 
	// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) 
	// ADD 2010.12.14 ACT）垣原 王子運送の対応 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない 
	// MOD 2011.01.25 東都）高木 「ロードに失敗」対応 
	// MOD 2011.04.13 東都）高木 重量入力不可対応 
	// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 
	// MOD 2011.06.07 東都）高木 王子運送の対応 
	// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 
	// MOD 2011.07.14 東都）高木 記事行の追加 
	// MOD 2011.07.28 東都）高木 記事行の追加（文字数制限の追加） 
	// MOD 2011.08.04 東都）高木 記事行の追加（先頭行無視障害対応） 
	// MOD 2011.08.11 東都）高木 記事行の追加（登録日付省略時障害対応） 
	//--------------------------------------------------------------------------
	// MOD 2012.09.26 COA)横山 日付項目取込強化
	//                         （月日にスペースを含む場合，スペースをゼロに変換して取込）
	//--------------------------------------------------------------------------
	// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加
	//--------------------------------------------------------------------------
	// MOD 2016.04.13 BEVAS）松本 配達指定日上限の拡張
	//--------------------------------------------------------------------------
	// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応
	//--------------------------------------------------------------------------
	public class 自動出荷登録 : 共通フォーム
	{
		private string[] s取込データ;
		private string[] s取込エラー;
		private bool b取込          = false;
		private bool bエラー出力    = false;
		private string s対象ファイル = "";
		private short    nOldRow    = 0;
		private int i取込件数		= 0;
		private int iエラー件数		= 0;
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

		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab日時;
		private System.Windows.Forms.Label labお客様名;
		private System.Windows.Forms.Label lab利用部門;
		private System.Windows.Forms.TextBox texお客様名;
		private System.Windows.Forms.TextBox tex利用部門;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label labファイル名;
		private IS2Client.共通テキストボックス texファイル名;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn開く;
		private System.Windows.Forms.Label lab自動出荷登録;
		private System.Windows.Forms.OpenFileDialog ofd自動出荷登録データ;
		private System.Windows.Forms.Button btn確認;
		private System.Windows.Forms.Button btn取込;
		private System.Windows.Forms.Button btn一覧表;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblInputCnt;
		private System.Windows.Forms.Label lblErrorCnt;
		private System.Windows.Forms.CheckBox cBox先頭行無視;
		private System.Windows.Forms.Label lab注釈重量;
		private AxGTABLE32V2Lib.AxGTable32 axGT取込データ一覧;

		public 自動出荷登録()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
			ＤＰＩ表示サイズ変換();
//			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
				this.axGT取込データ一覧.Size = new System.Drawing.Size(696, 220);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(自動出荷登録));
			this.panel6 = new System.Windows.Forms.Panel();
			this.texお客様名 = new System.Windows.Forms.TextBox();
			this.labお客様名 = new System.Windows.Forms.Label();
			this.lab利用部門 = new System.Windows.Forms.Label();
			this.tex利用部門 = new System.Windows.Forms.TextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab日時 = new System.Windows.Forms.Label();
			this.lab自動出荷登録 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn一覧表 = new System.Windows.Forms.Button();
			this.texメッセージ = new System.Windows.Forms.TextBox();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lab注釈重量 = new System.Windows.Forms.Label();
			this.cBox先頭行無視 = new System.Windows.Forms.CheckBox();
			this.lblErrorCnt = new System.Windows.Forms.Label();
			this.lblInputCnt = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btn取込 = new System.Windows.Forms.Button();
			this.axGT取込データ一覧 = new AxGTABLE32V2Lib.AxGTable32();
			this.btn確認 = new System.Windows.Forms.Button();
			this.labファイル名 = new System.Windows.Forms.Label();
			this.texファイル名 = new IS2Client.共通テキストボックス();
			this.btn開く = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.ofd自動出荷登録データ = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).BeginInit();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axGT取込データ一覧)).BeginInit();
			this.SuspendLayout();
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
			this.panel7.Controls.Add(this.lab自動出荷登録);
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
			// lab自動出荷登録
			// 
			this.lab自動出荷登録.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab自動出荷登録.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab自動出荷登録.ForeColor = System.Drawing.Color.White;
			this.lab自動出荷登録.Location = new System.Drawing.Point(12, 2);
			this.lab自動出荷登録.Name = "lab自動出荷登録";
			this.lab自動出荷登録.Size = new System.Drawing.Size(264, 24);
			this.lab自動出荷登録.TabIndex = 0;
			this.lab自動出荷登録.Text = "ＣＳＶエントリー";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn一覧表);
			this.panel8.Controls.Add(this.texメッセージ);
			this.panel8.Controls.Add(this.btn閉じる);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 14;
			// 
			// btn一覧表
			// 
			this.btn一覧表.ForeColor = System.Drawing.Color.Blue;
			this.btn一覧表.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn一覧表.Location = new System.Drawing.Point(96, 6);
			this.btn一覧表.Name = "btn一覧表";
			this.btn一覧表.Size = new System.Drawing.Size(62, 48);
			this.btn一覧表.TabIndex = 8;
			this.btn一覧表.Text = "エラー\n一覧表\n印刷";
			this.btn一覧表.Click += new System.EventHandler(this.btn一覧表_Click);
			// 
			// texメッセージ
			// 
			this.texメッセージ.BackColor = System.Drawing.Color.PaleGreen;
			this.texメッセージ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texメッセージ.ForeColor = System.Drawing.Color.Red;
			this.texメッセージ.Location = new System.Drawing.Point(456, 4);
			this.texメッセージ.Multiline = true;
			this.texメッセージ.Name = "texメッセージ";
			this.texメッセージ.ReadOnly = true;
			this.texメッセージ.Size = new System.Drawing.Size(334, 50);
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
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lab注釈重量);
			this.groupBox2.Controls.Add(this.cBox先頭行無視);
			this.groupBox2.Controls.Add(this.lblErrorCnt);
			this.groupBox2.Controls.Add(this.lblInputCnt);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.btn取込);
			this.groupBox2.Controls.Add(this.axGT取込データ一覧);
			this.groupBox2.Controls.Add(this.btn確認);
			this.groupBox2.Controls.Add(this.labファイル名);
			this.groupBox2.Controls.Add(this.texファイル名);
			this.groupBox2.Controls.Add(this.btn開く);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(22, 96);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(746, 370);
			this.groupBox2.TabIndex = 17;
			this.groupBox2.TabStop = false;
			// 
			// lab注釈重量
			// 
			this.lab注釈重量.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab注釈重量.ForeColor = System.Drawing.Color.Red;
			this.lab注釈重量.Location = new System.Drawing.Point(436, 336);
			this.lab注釈重量.Name = "lab注釈重量";
			this.lab注釈重量.Size = new System.Drawing.Size(284, 30);
			this.lab注釈重量.TabIndex = 59;
			this.lab注釈重量.Text = "（※重量・才数の入力はできません\n　　重量・才数の値は「0」で取り込みます）";
			// 
			// cBox先頭行無視
			// 
			this.cBox先頭行無視.ForeColor = System.Drawing.Color.LimeGreen;
			this.cBox先頭行無視.Location = new System.Drawing.Point(136, 50);
			this.cBox先頭行無視.Name = "cBox先頭行無視";
			this.cBox先頭行無視.Size = new System.Drawing.Size(188, 24);
			this.cBox先頭行無視.TabIndex = 49;
			this.cBox先頭行無視.Text = "先頭１行目は取り込まない";
			// 
			// lblErrorCnt
			// 
			this.lblErrorCnt.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lblErrorCnt.ForeColor = System.Drawing.Color.Black;
			this.lblErrorCnt.Location = new System.Drawing.Point(680, 316);
			this.lblErrorCnt.Name = "lblErrorCnt";
			this.lblErrorCnt.Size = new System.Drawing.Size(48, 14);
			this.lblErrorCnt.TabIndex = 48;
			this.lblErrorCnt.Text = "0件";
			this.lblErrorCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblInputCnt
			// 
			this.lblInputCnt.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lblInputCnt.ForeColor = System.Drawing.Color.Black;
			this.lblInputCnt.Location = new System.Drawing.Point(552, 316);
			this.lblInputCnt.Name = "lblInputCnt";
			this.lblInputCnt.Size = new System.Drawing.Size(48, 14);
			this.lblInputCnt.TabIndex = 47;
			this.lblInputCnt.Text = "0件";
			this.lblInputCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.LimeGreen;
			this.label3.Location = new System.Drawing.Point(616, 316);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 46;
			this.label3.Text = "エラー件数：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.LimeGreen;
			this.label2.Location = new System.Drawing.Point(488, 316);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 45;
			this.label2.Text = "取込件数：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btn取込
			// 
			this.btn取込.BackColor = System.Drawing.Color.SteelBlue;
			this.btn取込.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn取込.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn取込.ForeColor = System.Drawing.Color.White;
			this.btn取込.Location = new System.Drawing.Point(352, 320);
			this.btn取込.Name = "btn取込";
			this.btn取込.Size = new System.Drawing.Size(80, 32);
			this.btn取込.TabIndex = 4;
			this.btn取込.TabStop = false;
			this.btn取込.Text = "取込";
			this.btn取込.Click += new System.EventHandler(this.btn取込_Click);
			// 
			// axGT取込データ一覧
			// 
			this.axGT取込データ一覧.ContainingControl = this;
			this.axGT取込データ一覧.DataSource = null;
			this.axGT取込データ一覧.Location = new System.Drawing.Point(40, 80);
			this.axGT取込データ一覧.Name = "axGT取込データ一覧";
			this.axGT取込データ一覧.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT取込データ一覧.OcxState")));
			this.axGT取込データ一覧.Size = new System.Drawing.Size(696, 220);
			this.axGT取込データ一覧.TabIndex = 3;
			this.axGT取込データ一覧.CelDblClick += new AxGTABLE32V2Lib._DGTable32Events_CelDblClickEventHandler(this.axGT取込データ一覧_CelDblClick);
			this.axGT取込データ一覧.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT取込データ一覧_CurPlaceChanged);
			// 
			// btn確認
			// 
			this.btn確認.BackColor = System.Drawing.Color.SteelBlue;
			this.btn確認.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn確認.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn確認.ForeColor = System.Drawing.Color.White;
			this.btn確認.Location = new System.Drawing.Point(360, 52);
			this.btn確認.Name = "btn確認";
			this.btn確認.Size = new System.Drawing.Size(65, 22);
			this.btn確認.TabIndex = 2;
			this.btn確認.TabStop = false;
			this.btn確認.Text = "内容確認";
			this.btn確認.Click += new System.EventHandler(this.btn確認_Click);
			// 
			// labファイル名
			// 
			this.labファイル名.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labファイル名.ForeColor = System.Drawing.Color.LimeGreen;
			this.labファイル名.Location = new System.Drawing.Point(72, 32);
			this.labファイル名.Name = "labファイル名";
			this.labファイル名.Size = new System.Drawing.Size(60, 14);
			this.labファイル名.TabIndex = 15;
			this.labファイル名.Text = "ファイル名";
			// 
			// texファイル名
			// 
			this.texファイル名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texファイル名.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.texファイル名.Location = new System.Drawing.Point(136, 24);
			this.texファイル名.MaxLength = 100;
			this.texファイル名.Name = "texファイル名";
			this.texファイル名.Size = new System.Drawing.Size(488, 23);
			this.texファイル名.TabIndex = 0;
			this.texファイル名.Text = "";
			// 
			// btn開く
			// 
			this.btn開く.BackColor = System.Drawing.Color.SteelBlue;
			this.btn開く.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn開く.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn開く.ForeColor = System.Drawing.Color.White;
			this.btn開く.Location = new System.Drawing.Point(632, 24);
			this.btn開く.Name = "btn開く";
			this.btn開く.Size = new System.Drawing.Size(65, 22);
			this.btn開く.TabIndex = 1;
			this.btn開く.TabStop = false;
			this.btn開く.Text = "開く";
			this.btn開く.Click += new System.EventHandler(this.btn開く_Click);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 370);
			this.label1.TabIndex = 44;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ofd自動出荷登録データ
			// 
			this.ofd自動出荷登録データ.FileOk += new System.ComponentModel.CancelEventHandler(this.ofお届け先データ_FileOk);
			// 
			// 自動出荷登録
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 574);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "自動出荷登録";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 ＣＳＶエントリー";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Closed += new System.EventHandler(this.自動出荷登録_Closed);
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axGT取込データ一覧)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			// ヘッダー項目の設定
			texお客様名.Text = gs利用者名;
			tex利用部門.Text = gs部門ＣＤ + " " + gs部門名;

			// 日時の初期設定
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled = true;

// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 START
			//部門店所が取得されていない場合には、
			if(gs部門店所ＣＤ == null || gs部門店所ＣＤ.Length == 0){
				gs部門店所ＣＤ = 部門店所取得(gs部門ＣＤ);
			}
// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 END

			// デフォルトのフォルダをデスクトップフォルダにする
			ofd自動出荷登録データ.InitialDirectory
				= Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			ofd自動出荷登録データ.Filter = "ＣＳＶファイル (*.csv)|*.csv|すべて(*.*)|*.*";

			axGT取込データ一覧.Cols = 26;
			axGT取込データ一覧.Rows = 1;
			axGT取込データ一覧.ColSep = "|";
			axGT取込データ一覧.RowSep = ";";
// MOD 2005.07.15 東都）山本 項目名の修正 START
//			axGT取込データ一覧.set_RowsText(0, "|荷受人コード|電話番号|住所１|住所２|住所３|名前１|名前１|郵便番号|特殊計|着店コード|荷送人コード|個数|才数|重量|輸送商品１|輸送商品２|品名記事１|品名記事２|品名記事３|予備１|予備２|予備３|元着区分|保険金額|出荷日付|登録日付|");
// MOD 2006.10.05 FJCS）桑田 項目の変更（予備１を配達指定日にする） START
//			axGT取込データ一覧.set_RowsText(0, "|荷受人コード|電話番号|住所１|住所２|住所３|名前１|名前２|郵便番号|特殊計|着店コード|荷送人コード|個数|才数|重量|輸送商品１|輸送商品２|品名記事１|品名記事２|品名記事３|予備１|予備２|予備３|元着区分|保険金額|出荷日付|登録日付|");
// MOD 2007.10.25 東都）高木 項目の変更（予備２をお客様管理番号にする） START
//			axGT取込データ一覧.set_RowsText(0, "|荷受人コード|電話番号|住所１|住所２|住所３|名前１|名前２|郵便番号|特殊計|着店コード|荷送人コード|個数|才数|重量|輸送商品１|輸送商品２|品名記事１|品名記事２|品名記事３|配達指定日|予備２|予備３|元着区分|保険金額|出荷日付|登録日付|");
			axGT取込データ一覧.set_RowsText(0, "|荷受人コード|電話番号|住所１|住所２|住所３|名前１|名前２|郵便番号|特殊計|着店コード|荷送人コード|個数|才数|重量|輸送商品１|輸送商品２|品名記事１|品名記事２|品名記事３|配達指定日|お客様管理番号|予備３|元着区分|保険金額|出荷日付|登録日付|");
// MOD 2007.10.25 東都）高木 項目の変更（予備２をお客様管理番号にする） END
// MOD 2006.10.05 FJCS）桑田 項目の変更（予備１を配達指定日にする） END
// MOD 2005.07.15 東都）山本 項目名の修正 END

// MOD 2006.10.05 FJCS）桑田 項目の変更（予備１を配達指定日にする） START
//			axGT取込データ一覧.ColsWidth = "2|7.5|8.5|10|10|10|10|10|7|3|0|7.5|2|3|3|9|9|9|9|9|0|0|0|5|6|6|6|";
//			axGT取込データ一覧.ColsAlignHorz = "1|0|0|0|0|0|0|0|1|0|1|0|2|2|2|0|0|0|0|0|0|0|0|1|2|1|1|";
// MOD 2007.10.25 東都）高木 項目の変更（予備２をお客様管理番号にする） START
//			axGT取込データ一覧.ColsWidth = "2|7.5|8.5|10|10|10|10|10|7|3|0|7.5|2|3|3|9|9|9|9|9|6|0|0|5|6|6|6|";
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 START
//			axGT取込データ一覧.ColsWidth = "2|7.5|8.5|14|12|8|11|11|5|3|0|7.5|2.5|3|3|8|8|9|9|8|5|9|0|4|6|4.5|4.5|";
			axGT取込データ一覧.ColsWidth = "2|7.5|8.5|14|12|8|11|11|5|3|0|7.5|2.5|3|3|8|8|9|9|8|5|10|0|4|5|4.5|4.5|";
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 END
// MOD 2007.10.25 東都）高木 項目の変更（予備２をお客様管理番号にする） END
			axGT取込データ一覧.ColsAlignHorz = "1|0|0|0|0|0|0|0|1|0|1|0|2|2|2|0|0|0|0|0|1|0|0|1|2|1|1|";
// MOD 2006.10.05 FJCS）桑田 項目の変更（予備１を配達指定日にする） END
			axGT取込データ一覧.set_CelForeColor(axGT取込データ一覧.CaretRow,0,0x98FB98);  //BGR
			axGT取込データ一覧.set_CelBackColor(axGT取込データ一覧.CaretRow,0,0x006000);
			axGT取込データ一覧.MarkingColor = System.Drawing.Color.Red;
			axGT取込データ一覧.Clear();
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 START
			axGT取込データ一覧.CaretRow = 1;
			axGT取込データ一覧.CaretCol = 1;
			axGT取込データ一覧_CurPlaceChanged(null,null);
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 END
			axGT取込データ一覧.set_CelText(1,0,""); 
			axGT取込データ一覧.Rows = 10;
			axGT取込データ一覧.set_CelMarking(0,0,false);
			b取込 = false;
			btn取込.Enabled = false;
			bエラー出力 = false;
			btn一覧表.Enabled = false;
			s対象ファイル = "";
// MOD 2006.10.31 FJCS）桑田 件数表示のクリア START
			lblInputCnt.Text = "0件";
			lblErrorCnt.Text = "0件";
// MOD 2006.10.31 FJCS）桑田 件数表示のクリア END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
			if(gs重量入力制御 == "1"){
				lab注釈重量.Visible = false;
			}else{
				lab注釈重量.Visible = true;
			}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
// MOD 2011.07.14 東都）高木 記事行の追加 START
			iＣＳＶエントリー形式 = 1;
// MOD 2011.07.14 東都）高木 記事行の追加 END
		}

		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

		private void btn開く_Click(object sender, System.EventArgs e)
		{
			ofd自動出荷登録データ.ShowDialog();
		}

		private void ofお届け先データ_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			texファイル名.Text = ofd自動出荷登録データ.FileName;
		}

		private void btn確認_Click(object sender, System.EventArgs e)
		{
			s対象ファイル = texファイル名.Text;
			if (s対象ファイル.Trim().Length == 0) return;
 
// ADD 2008.04.11 ACT Vista対応 START
			string sErr = "";
// ADD 2008.04.11 ACT Vista対応 END

			btn取込.Enabled = false;
			btn一覧表.Enabled = false;
// ADD 2006.06.29 東都）山本 取込件数＆エラー件数の表示対応 START
			lblInputCnt.Text="0件";
			lblErrorCnt.Text="0件";
// ADD 2006.06.29 東都）山本 取込件数＆エラー件数の表示対応 END

// MOD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 START
//			texメッセージ.Text = "実行中．．．";
			texメッセージ.Text = "ＣＳＶファイル読込中．．．";

			btn取込.Refresh();
			btn一覧表.Refresh();
			lblInputCnt.Refresh();
			lblErrorCnt.Refresh();
			texメッセージ.Refresh();
// MOD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 END

			axGT取込データ一覧.Clear();
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 START
			axGT取込データ一覧.CaretRow = 1;
			axGT取込データ一覧.CaretCol = 1;
			axGT取込データ一覧_CurPlaceChanged(null,null);
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 END
			axGT取込データ一覧.set_CelMarking(0,0,false);
			axGT取込データ一覧.set_CelBackColor(0,0,0xFFFFFF);
			if (!System.IO.File.Exists(s対象ファイル))
			{
				texメッセージ.Text = "指定したファイルが存在しません。";
				axGT取込データ一覧.Rows = 10;
				return;
			}
			if (!axGT取込データ一覧.LoadCsvFile(s対象ファイル))
			{
				texメッセージ.Text = "CSVファイルの取り込みに失敗しました";
				axGT取込データ一覧.Rows = 10;
				return;
			}
// MOD 2010.02.25 東都）高木 ヘッダ行自動判別機能の追加 START
			if(axGT取込データ一覧.Rows > 0){
				//ヘッダ行なので先頭行無視
				if(axGT取込データ一覧.get_CelText(1,1).IndexOf("荷受人コード") >= 0
				 && axGT取込データ一覧.get_CelText(1,2).IndexOf("電話番号") >= 0
				 && axGT取込データ一覧.get_CelText(1,3).IndexOf("住所") >= 0){
					cBox先頭行無視.Checked = true;
					cBox先頭行無視.Refresh();
				}
			}
// MOD 2010.02.25 東都）高木 ヘッダ行自動判別機能の追加 END
// MOD 2009.04.06 東都）高木 先頭行無視機能の追加 START 
			if( cBox先頭行無視.Checked && axGT取込データ一覧.Rows > 0){
				int iRet = axGT取込データ一覧.DeleteItem(1);
			}
			axGT取込データ一覧.Clear();
// MOD 2009.04.06 東都）高木 先頭行無視機能の追加 END
// ADD 2006.10.05 FJCS）桑田 項目の変更（予備１を配達指定日にする） START
			StreamReader sr1 = new StreamReader(s対象ファイル, System.Text.Encoding.Default);
// MOD 2011.08.04 東都）高木 記事行の追加（先頭行無視障害対応） START
			if( cBox先頭行無視.Checked ){
				string sDataDummy1 = sr1.ReadLine();
			}
// MOD 2011.08.04 東都）高木 記事行の追加（先頭行無視障害対応） END
			string sData1 = sr1.ReadLine();

// ADD 2008.05.14 東都）高木 Unicodeファイルの改行対応 START
			//UniCodeファイルの改行対応
			if(sData1 == null) sData1 = "";
// ADD 2008.05.14 東都）高木 Unicodeファイルの改行対応 END

			string[] sValue1 = sData1.Replace("\"","").Replace("\'","").Split(',');
// MOD 2011.07.14 東都）高木 記事行の追加 START
			iＣＳＶエントリー形式 = 1;
			while(sValue1.Length <= 1){
				if(sr1.Peek() == -1) break; // EOFの時
				sData1 = sr1.ReadLine();
				if(sData1 != null && sData1 != ""){
					sValue1 = sData1.Split(',');
				}
			}
			if(sValue1.Length != 26 && sValue1.Length != 25
				&& sValue1.Length != 30 && sValue1.Length != 29){
				sr1.Close();
				texメッセージ.Text = "項目数が違います。";
				axGT取込データ一覧.Rows = 10;
				return;
			}
			if(sValue1.Length == 30 || sValue1.Length == 29){
				iＣＳＶエントリー形式 = 2;
			}
			sValue1 = null;
// MOD 2011.07.14 東都）高木 記事行の追加 END
			sr1.Close();
// ADD 2006.10.05 FJCS）桑田 項目の変更（予備１を配達指定日にする） END
// ADD 2005.06.02 東都）伊賀 シートの再定義 START
			axGT取込データ一覧.Cols = 26;
// MOD 2006.10.05 FJCS）桑田 項目の変更（予備１を配達指定日にする） START
//			axGT取込データ一覧.set_RowsText(0, "|荷受人コード|電話番号|住所１|住所２|住所３|名前１|名前２|郵便番号|特殊計|着店コード|荷送人コード|個数|才数|重量|輸送商品１|輸送商品２|品名記事１|品名記事２|品名記事３|予備１|予備２|予備３|元着区分|保険金額|出荷日付|登録日付|");
//			axGT取込データ一覧.ColsWidth = "2|7.5|8.5|10|10|10|10|10|7|3|0|7.5|2|3|3|9|9|9|9|9|0|0|0|5|6|6|6|";
//			axGT取込データ一覧.ColsAlignHorz = "1|0|0|0|0|0|0|0|1|0|1|0|2|2|2|0|0|0|0|0|0|0|0|1|2|1|1|";
// MOD 2007.10.25 東都）高木 項目の変更（予備２をお客様管理番号にする） START
//			axGT取込データ一覧.set_RowsText(0, "|荷受人コード|電話番号|住所１|住所２|住所３|名前１|名前２|郵便番号|特殊計|着店コード|荷送人コード|個数|才数|重量|輸送商品１|輸送商品２|品名記事１|品名記事２|品名記事３|配達指定日|予備２|予備３|元着区分|保険金額|出荷日付|登録日付|");
//			axGT取込データ一覧.ColsWidth = "2|7.5|8.5|10|10|10|10|10|7|3|0|7.5|2|3|3|9|9|9|9|9|6|0|0|5|6|6|6|";
			axGT取込データ一覧.set_RowsText(0, "|荷受人コード|電話番号|住所１|住所２|住所３|名前１|名前２|郵便番号|特殊計|着店コード|荷送人コード|個数|才数|重量|輸送商品１|輸送商品２|品名記事１|品名記事２|品名記事３|配達指定日|お客様管理番号|予備３|元着区分|保険金額|出荷日付|登録日付|");
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 START
//			axGT取込データ一覧.ColsWidth = "2|7.5|8.5|14|12|8|11|11|5|3|0|7.5|2.5|3|3|8|8|9|9|8|5|9|0|4|6|4.5|4.5|";
			axGT取込データ一覧.ColsWidth = "2|7.5|8.5|14|12|8|11|11|5|3|0|7.5|2.5|3|3|8|8|9|9|8|5|10|0|4|5|4.5|4.5|";
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 END
// MOD 2007.10.25 東都）高木 項目の変更（予備２をお客様管理番号にする） END
			axGT取込データ一覧.ColsAlignHorz = "1|0|0|0|0|0|0|0|1|0|1|0|2|2|2|0|0|0|0|0|1|0|0|1|2|1|1|";
// MOD 2006.10.05 FJCS）桑田 項目の変更（予備１を配達指定日にする） END
// ADD 2005.06.02 東都）伊賀 シートの再定義 END
// MOD 2011.07.14 東都）高木 記事行の追加 START
		if(iＣＳＶエントリー形式 == 2){
			axGT取込データ一覧.Cols = 30;
			axGT取込データ一覧.set_RowsText(0, "|荷受人コード|電話番号|住所１|住所２|住所３|名前１|名前２|郵便番号|特殊計|着店コード|荷送人コード|荷送担当者|個数|才数|重量|輸送商品１|輸送商品２|品名記事１|品名記事２|品名記事３|品名記事４|品名記事５|品名記事６|配達指定日|必着区分|お客様管理番号|元着区分|保険金額|出荷日付|登録日付|");
			axGT取込データ一覧.ColsWidth = "2|7.5|8.5|14|12|8|11|11|5|3|0|7.5|7.5|2.5|3|3|8|8|9|9|8|8|8|8|5|4|10|4|5|4.5|4.5|";
			axGT取込データ一覧.ColsAlignHorz = "1|0|0|0|0|0|0|0|1|0|1|0|0|2|2|2|0|0|0|0|0|0|0|0|1|1|0|1|2|1|1|";
		}
// MOD 2011.07.14 東都）高木 記事行の追加 END

			StreamReader sr = new StreamReader(s対象ファイル, System.Text.Encoding.Default);
// MOD 2009.04.06 東都）高木 先頭行無視機能の追加 START 
			if( cBox先頭行無視.Checked ){
				string sDataDummy = sr.ReadLine();
			}
// MOD 2009.04.06 東都）高木 先頭行無視機能の追加 END
			axGT取込データ一覧.CaretRow = 1;
			axGT取込データ一覧.set_CelForeColor(nOldRow,0,0);
			axGT取込データ一覧.set_CelBackColor(nOldRow,0,0xFFFFFF);
			axGT取込データ一覧.set_CelForeColor(axGT取込データ一覧.CaretRow,0,0x98FB98);  //BGR
			axGT取込データ一覧.set_CelBackColor(axGT取込データ一覧.CaretRow,0,0x006000);
			nOldRow = axGT取込データ一覧.CaretRow;
			try
			{
				s取込データ = new string[(int)axGT取込データ一覧.Rows];
				s取込エラー = new string[(int)axGT取込データ一覧.Rows];
				b取込 = true;
				bエラー出力 = false;
// MOD 2006.06.29 東都）山本 取込件数＆エラー件数の表示対応 START
//				int i取込件数 = (int)axGT取込データ一覧.Rows;
				i取込件数 = (int)axGT取込データ一覧.Rows;
				iエラー件数 = 0;
// MOD 2006.06.29 東都）山本 取込件数＆エラー件数の表示対応 END
				if (axGT取込データ一覧.Rows < 10) axGT取込データ一覧.Rows = 10;

//保留 MOD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 START
//保留 MOD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 END
// ADD 2005.06.02 東都）伊賀 内容確認処理見直し START
				部門出荷日情報更新();
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				string[] sRet = {""};
				string s発店ＣＤ   = "";
				string s発店名     = "";
				string s集約店ＣＤ = "";
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 START
				//社内伝会員の扱店登録チェック
				if(gs部門店所ＣＤ.Equals("044"))
				{
					string[] saChkRet = ＣＭ０５会員扱店Ｆチェック();
					int iChkRet = int.Parse(saChkRet[0]);
					string sChkRet = saChkRet[1];
					if(iChkRet ==1)
					{
						//異常終了時
						string sメッセージ =
							"ご利用の会員に扱店登録がない為、出荷登録できません。\n" +
							"福山通運の営業本部へお問い合わせ下さい。\n" +
							"　　　【チェック対象会員】 " + gs会員ＣＤ;
						MessageBox.Show(this, sメッセージ, "扱店チェック", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						if(sChkRet.Equals("該当データがありません"))
						{
							throw new Exception("ご利用の会員に扱店登録がありませんでした");
						}
						else
						{
							throw new Exception(sChkRet);
						}
					}
				}
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 END
				//発店取得
				try
				{
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
//					if (gs会員ＣＤ.Substring(0,1) != "J")
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
					throw new Exception(gs通信エラー);
				}
				catch (Exception ex)
				{
					throw new Exception("通信エラー：" + ex.Message);
				}
				if(sRet[0].Equals("正常終了"))
				{
					s発店ＣＤ = sRet[1];	//発店ＣＤ
					s発店名   = sRet[2];	//発店名
					if (s発店名.Length == 0) s発店名 = " ";
				}
				else
				{
					if(sRet[0].Equals("該当データがありません"))
						throw new Exception("発店を決められませんでした");
					else
						throw new Exception(sRet[0]);
				}
				//集約店取得
				try
				{
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
//					if (gs会員ＣＤ.Substring(0,1) != "J")
					else if (gs会員ＣＤ.Substring(0,1) != "J")
// MOD 2016.04.15 BEVAS）松本 社内伝票機能追加対応 END
					{
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END
					if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
					sRet = sv_syukka.Get_syuuyakuten2(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
// ADD 2010.12.14 ACT）垣原 王子運送の対応 START
					}
					else
					{
						if(sv_oji == null) sv_oji = new is2oji.Service1();
						sRet = sv_oji.Get_syuuyakuten2(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
					}
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END
				}
				catch (System.Net.WebException)
				{
					throw new Exception(gs通信エラー);
				}
				catch (Exception ex)
				{
					throw new Exception("通信エラー：" + ex.Message);
				}
				if(sRet[0] != " ")
				{
					s集約店ＣＤ = sRet[1];	//集約店ＣＤ
				}
				else
				{
					if(sRet[0].Equals("該当データがありません"))
						throw new Exception("集約店を決められませんでした");
					else
						throw new Exception(sRet[0]);
				}
// ADD 2005.06.02 東都）伊賀 内容確認処理見直し END

// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 START
				string sChkMsg = "";
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 END
				for (int iCnt = 1; iCnt <= i取込件数; iCnt++)
				{
// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 START
					texメッセージ.Text = "内容確認中．．．" + iCnt + "件目";
					texメッセージ.Refresh();
// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 END
// MOD 2010.03.18 東都）高木 データ無しチェックの追加 START
//					axGT取込データ一覧.set_CelText((short)iCnt,0, iCnt.ToString()); 
// MOD 2010.03.18 東都）高木 データ無しチェックの追加 END
					string sData = sr.ReadLine();

// ADD 2008.05.14 東都）高木 Unicodeファイルの改行対応 START
					//UniCodeの改行対応
					if(sData == null){
						sData = "";
//						break;	//←取込件数に間違いが発生する
					}
// ADD 2008.05.14 東都）高木 Unicodeファイルの改行対応 END

// MOD 2005.09.15 東都）伊賀 "' を削除 START
//					string[] sValue = sData.Replace("\"", "").Split(',');
					string[] sValue = sData.Replace("\"","").Replace("\'","").Split(',');
// MOD 2010.03.18 東都）高木 データ無しチェックの追加 START
					if (sValue.Length <= 1) continue;
//保留 MOD 2011.04.13 東都）高木 重量入力不可対応 START
//					// 才数・重量に０を設定
//					if(sValue.Length > 12) sValue[12] = "0";
//					if(sValue.Length > 13) sValue[13] = "0";
//保留 MOD 2011.04.13 東都）高木 重量入力不可対応 END
					//行数表示
					axGT取込データ一覧.set_CelText((short)iCnt,0, iCnt.ToString()); 
// MOD 2010.03.18 東都）高木 データ無しチェックの追加 END
					for (int i = 0; i < sValue.Length; i++)
					{
						axGT取込データ一覧.set_CelText((short)iCnt, (short)(i+1), sValue[i]);
					}
// MOD 2005.09.15 東都）伊賀 "' を削除 END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
//// MOD 2011.04.13 東都）高木 重量入力不可対応 START
//					// 才数・重量に０を設定
//					axGT取込データ一覧.set_CelText((short)iCnt, (short)(12+1), "0");
//					axGT取込データ一覧.set_CelText((short)iCnt, (short)(13+1), "0");
//// MOD 2011.04.13 東都）高木 重量入力不可対応 END
//					string[] sKey   = new string[46];
					if(gs重量入力制御 != "1"){
						// 才数・重量に０を設定
// MOD 2011.07.14 東都）高木 記事行の追加 START
						if(iＣＳＶエントリー形式 == 2){
							axGT取込データ一覧.set_CelText((short)iCnt, (short)((int)形式２.才数+1), "0");
							axGT取込データ一覧.set_CelText((short)iCnt, (short)((int)形式２.重量+1), "0");
						}else{
// MOD 2011.07.14 東都）高木 記事行の追加 END
							axGT取込データ一覧.set_CelText((short)iCnt, (short)(12+1), "0");
							axGT取込データ一覧.set_CelText((short)iCnt, (short)(13+1), "0");
// MOD 2011.07.14 東都）高木 記事行の追加 START
						}
// MOD 2011.07.14 東都）高木 記事行の追加 END
					}
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
// MOD 2010.02.25 東都）高木 項目数チェックの修正 START
//					if (sValue.Length != 26)
//					{
//						エラー出力(iCnt, 0, "項目数が違います\r\n");
//						continue;
//					}
// MOD 2011.07.14 東都）高木 記事行の追加 START
//					if (sValue.Length != 26 && sValue.Length != 25){
					if (sValue.Length != 26 && sValue.Length != 25
						&& sValue.Length != 30 && sValue.Length != 29){
// MOD 2011.07.14 東都）高木 記事行の追加 END
						エラー出力(iCnt, 0, "項目数が違います\r\n");
						continue;
					}
// MOD 2010.02.25 東都）高木 項目数チェックの修正 END
// MOD 2011.07.14 東都）高木 記事行の追加 START
					string[] sValue一覧行 = new string[sValue.Length];
					if(iＣＳＶエントリー形式 == 2){
						System.Array.Copy(sValue, sValue一覧行, sValue.Length);
//						for(int iCnt一覧行 = 0; iCnt一覧行 < sValue.Length; iCnt一覧行++){
//							sValue一覧行[iCnt一覧行] = sValue[iCnt一覧行];
//						}
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
						if(!半角チェック(sValue[0])) エラー出力(iCnt, 1, "荷受人コードは半角文字で入力してください\r\n");
						sKey[4] = sValue[0];
						if(半角チェック(sValue[0]))
						{
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
							if(!記号チェック(sValue[0])){
								エラー出力(iCnt, 1, "荷受人コードに使用できない記号があります\r\n");
							}else{
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
								//荷受人コード存在チェック
								try
								{
									if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
//保留 MOD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 START
//保留 MOD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 END
									sRet = sv_otodoke.Get_Stodokesaki(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,sKey[4]);
								}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
								catch (System.Net.WebException)
								{
									throw new Exception(gs通信エラー);
								}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
								catch (Exception ex)
								{
									throw new Exception("通信エラー：" + ex.Message);
								}
//保留 MOD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 START
//保留 MOD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 END
								if(!sRet[0].Equals("更新"))
								{
									if(sRet[0].Equals("登録"))
									{
										エラー出力(iCnt, 1, "荷受人コードが存在しません\r\n");
									}
									else
									{
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
// ADD 2010.12.14 ACT）垣原 王子運送の対応 START
												if (gs会員ＣＤ.Substring(0,1) != "J")
												{
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END
											if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
// MOD 2008.12.25 kcl)森本 着店コード検索方法の再変更 START
//// ADD 2008.06.12 kcl)森本 着店コード検索方法の変更 START
////										sRet = sv_syukka.Get_autoEntryPref(gsaユーザ,sKey[14]);
//										sRet = sv_syukka.Get_autoEntryPref3(gsaユーザ, sKey[0], sKey[1], sKey[4], sKey[14], sKey[9] + sKey[10] + sKey[11]);
//// ADD 2008.06.12 kcl)森本 着店コード検索方法の変更 END
											sRet = sv_syukka.Get_autoEntryPref3(gsaユーザ, sKey[0], sKey[1], sKey[4], sKey[14], sKey[9] + sKey[10] + sKey[11], sKey[12] + sKey[13]);
// MOD 2008.12.25 kcl)森本 着店コード検索方法の再変更 START
// ADD 2010.12.14 ACT）垣原 王子運送の対応 START
												}
												else
												{
													if(sv_oji == null) sv_oji = new is2oji.Service1();
													sRet = sv_oji.Get_autoEntryPref3(gsaユーザ, sKey[0], sKey[1], sKey[4], sKey[14], sKey[9] + sKey[10] + sKey[11], sKey[12] + sKey[13]);
												}
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END
										}
										catch (System.Net.WebException)
										{
											throw new Exception(gs通信エラー);
										}
										catch (Exception ex)
										{
											throw new Exception("通信エラー：" + ex.Message);
										}
										if(sRet[0].Length != 4)
										{
											if(sRet[0].Equals("該当データがありません"))
											{
												エラー出力(iCnt, 1, "郵便番号が存在しません\r\n");
											}
											else
											{
												throw new Exception(sRet[0]);
											}
										}
										else
										{
											sKey[15] = sRet[2];	//着店ＣＤ
											sKey[16] = sRet[3];	//着店名
											if (sKey[16].Length == 0) sKey[16] = " ";
											sKey[8]  = sRet[1];	//住所ＣＤ
// MOD 2008.11.19 東都）高木 着店コードが空白でもエラーでなくする START
//										if (sKey[15].Trim().Length == 0) エラー出力(iCnt, 1, "配達店が決められませんでした\r\n");
// MOD 2008.11.19 東都）高木 着店コードが空白でもエラーでなくする END
										}
									}
									else
									{
										sKey[14] = " ";
									}
								}
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
							}
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
						}
					}
					else
					{
						sKey[4] = " ";
					}

					//電話番号
					sValue[1] = sValue[1].Trim();
					if (sKey[4].Trim().Length == 0 && !必須チェック(sValue[1])) エラー出力(iCnt, 2, "電話番号は必須項目です\r\n");
					if (sValue[1].Length != 0)
					{
						try
						{
							if (!半角チェック(sValue[1])) エラー出力(iCnt, 2, "電話番号は半角文字で入力してください\r\n");
							if (sValue[1].IndexOf("(") == -1 && sValue[1].LastIndexOf(")") == -1)
							{
								if (sValue[1].IndexOf("-") == sValue[1].LastIndexOf("-") && sValue[1].IndexOf("-") != -1)
								{
									sKey[5] = " ";
									sKey[6] = sValue[1].Substring(0, sValue[1].IndexOf("-"));
									sKey[7] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
									if (!数値チェック(sKey[6]) || !数値チェック(sKey[7]))
										エラー出力(iCnt, 2, "電話番号は数値で入力してください\r\n");
								}
								else if (sValue[1].IndexOf("-") != sValue[1].LastIndexOf("-") && sValue[1].IndexOf("-") != -1)
								{
									sKey[5] = sValue[1].Substring(0, sValue[1].IndexOf("-"));
									sKey[6] = sValue[1].Substring(sValue[1].IndexOf("-") + 1, sValue[1].LastIndexOf("-") - sValue[1].IndexOf("-") - 1);
									sKey[7] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
									if (!数値チェック(sKey[5]) || !数値チェック(sKey[6]) || !数値チェック(sKey[7]))
										エラー出力(iCnt, 2, "電話番号は数値で入力してください\r\n");
								}
// ADD 2005.09.15 東都）伊賀 電話番号形式追加対応 START
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
										エラー出力(iCnt, 2, "電話番号は数値で入力してください\r\n");
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
										エラー出力(iCnt, 2, "電話番号は数値で入力してください\r\n");
								}
								else if (sValue[1].Length == 11)
								{
									//電話番号１１桁
// MOD 2010.03.30 東都）高木 携帯電話対応 START
									if(sValue[1].Substring(0,3).Equals("090")
									 || sValue[1].Substring(0,3).Equals("080")
									 || sValue[1].Substring(0,3).Equals("070")
									 || sValue[1].Substring(0,3).Equals("050")){
										//携帯電話は 3-4-4で編集
										sKey[5] = sValue[1].Substring(0,3);
										sKey[6] = sValue[1].Substring(3,4);
										sKey[7] = sValue[1].Substring(7,4);
									}else{
// MOD 2010.03.30 東都）高木 携帯電話対応 END
										//4-3-4で編集
										sKey[5] = sValue[1].Substring(0,4);
										sKey[6] = sValue[1].Substring(4,3);
										sKey[7] = sValue[1].Substring(7,4);
// MOD 2010.03.30 東都）高木 携帯電話対応 START
									}
// MOD 2010.03.30 東都）高木 携帯電話対応 END
									if (!数値チェック(sKey[5]) || !数値チェック(sKey[6]) || !数値チェック(sKey[7]))
										エラー出力(iCnt, 2, "電話番号は数値で入力してください\r\n");
								}
								else if (sValue[1].Length == 12)
								{
									//電話番号１２桁
									//4-4-4で編集
									sKey[5] = sValue[1].Substring(0,4);
									sKey[6] = sValue[1].Substring(4,4);
									sKey[7] = sValue[1].Substring(8,4);
									if (!数値チェック(sKey[5]) || !数値チェック(sKey[6]) || !数値チェック(sKey[7]))
										エラー出力(iCnt, 2, "電話番号は数値で入力してください\r\n");
								}
// ADD 2005.09.15 東都）伊賀 電話番号形式追加対応 END
								else
								{
									エラー出力(iCnt, 2, "電話番号の形式に誤りがあります\r\n");
								}
							}
							else if (sValue[1].IndexOf("(") != -1 && sValue[1].LastIndexOf(")") != -1)
							{
								sKey[5] = sValue[1].Substring(sValue[1].IndexOf("(") + 1, sValue[1].LastIndexOf(")") - sValue[1].IndexOf("(") - 1);
								sKey[6] = sValue[1].Substring(sValue[1].IndexOf(")") + 1, sValue[1].LastIndexOf("-") - sValue[1].IndexOf(")") - 1);
								sKey[7] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
								if (!数値チェック(sKey[5]) || !数値チェック(sKey[6]) || !数値チェック(sKey[7]))
									エラー出力(iCnt, 2, "電話番号は数値で入力してください\r\n");
							}
							else
							{
								エラー出力(iCnt, 2, "電話番号の形式に誤りがあります\r\n");
							}
							if (sKey[5].Length > 6) エラー出力(iCnt, 2, "電話番号(市外)は６文字以内で入力してください\r\n");
							if (sKey[6].Length > 4) エラー出力(iCnt, 2, "電話番号(市内)は４文字以内で入力してください\r\n");
							if (sKey[7].Length > 4) エラー出力(iCnt, 2, "電話番号(番号)は４文字以内で入力してください\r\n");
						}
						catch
						{
							エラー出力(iCnt, 2, "電話番号の形式に誤りがあります\r\n");
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
						if (!必須チェック(sValue[2])) エラー出力(iCnt, 3, "住所１は必須項目です\r\n");
// ADD 2008.04.11 ACT Vista対応 START
						if (sValue[2].Length != 0)
						{
							if (!漢字変換_CSV(ref sValue[2], ref sErr))
							{
								エラー出力(iCnt, 3, "住所１はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}
							else
							{
								文字変換後出力(iCnt, 3, sValue[2]);
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 START
							if(!全角変換チェック(ref sValue[2], ref sErr)){
								エラー出力(iCnt, 3, "住所１は全角文字変換がおこなえませんでした"
													 + "『" + sErr + "』\r\n");
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 END
						}
						if (sValue[3].Length != 0)
						{
							if (!漢字変換_CSV(ref sValue[3], ref sErr))
							{
								エラー出力(iCnt, 4, "住所２はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}
							else
							{
								文字変換後出力(iCnt, 4, sValue[3]);
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 START
							if(!全角変換チェック(ref sValue[3], ref sErr)){
								エラー出力(iCnt, 4, "住所２は全角文字変換がおこなえませんでした"
													 + "『" + sErr + "』\r\n");
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 END
						}
						if (sValue[4].Length != 0)
						{
							if (!漢字変換_CSV(ref sValue[4], ref sErr))
							{
								エラー出力(iCnt, 5, "住所３はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}
							else
							{
								文字変換後出力(iCnt, 5, sValue[4]);
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 START
							if(!全角変換チェック(ref sValue[4], ref sErr)){
								エラー出力(iCnt, 5, "住所３は全角文字変換がおこなえませんでした"
													 + "『" + sErr + "』\r\n");
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 END
						}
// ADD 2008.04.11 ACT Vista対応 END
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
					else if (sKey[4].Trim().Length == 0) エラー出力(iCnt, 3, "住所１は必須項目です\r\n");

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
						if (!必須チェック(sValue[5])) エラー出力(iCnt, 6, "名前１は必須項目です\r\n");
// ADD 2008.04.11 ACT Vista対応 START
						if (sValue[5].Length != 0)
						{
							if (!漢字変換_CSV(ref sValue[5], ref sErr))
							{
								エラー出力(iCnt, 6, "名前１はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}
							else
							{
								文字変換後出力(iCnt, 6, sValue[5]);
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 START
							if(!全角変換チェック(ref sValue[5], ref sErr)){
								エラー出力(iCnt, 6, "名前１は全角文字変換がおこなえませんでした"
													 + "『" + sErr + "』\r\n");
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 END
						}
						if (sValue[6].Length != 0)
						{
							if (!漢字変換_CSV(ref sValue[6], ref sErr))
							{
								エラー出力(iCnt, 7, "名前２はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}
							else
							{
								文字変換後出力(iCnt, 7, sValue[6]);
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 START
							if(!全角変換チェック(ref sValue[6], ref sErr)){
								エラー出力(iCnt, 7, "名前２は全角文字変換がおこなえませんでした"
													 + "『" + sErr + "』\r\n");
							}
// MOD 2011.06.28 東都）高木 Windows7のStrConv障害対応 END
						}
// ADD 2008.04.11 ACT Vista対応 END
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
					else if (sKey[4].Trim().Length == 0) エラー出力(iCnt, 6, "名前１は必須項目です\r\n");
					
					//郵便番号
					sValue[7] = sValue[7].Trim().Replace("-", "");
					if (sKey[4].Trim().Length == 0 && !必須チェック(sValue[7])) エラー出力(iCnt, 8, "郵便番号は必須項目です\r\n");
					if (sValue[7].Length != 0)
					{
						if (!数値チェック(sValue[7])) エラー出力(iCnt, 8, "郵便番号は数値で入力してください\r\n");
						if (sValue[7].Length > 7) エラー出力(iCnt, 8, "郵便番号は７文字以内で入力してください\r\n");
						if (数値チェック(sValue[7]) && sValue[7].Length <= 7)
						{
							//住所存在チェック
							try
							{
// ADD 2010.12.14 ACT）垣原 王子運送の対応 START
						if (gs会員ＣＤ.Substring(0,1) != "J")
						{
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END
								if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
//保留 MOD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 START
//保留 MOD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 END
// MOD 2008.12.25 kcl)森本 着店コード検索方法の再変更 START
//// ADD 2008.06.12 kcl)森本 着店コード検索方法の変更 START
////								sRet = sv_syukka.Get_autoEntryPref(gsaユーザ,sValue[7]);
//								sRet = sv_syukka.Get_autoEntryPref3(gsaユーザ, sKey[0], sKey[1], sKey[4], sValue[7], sValue[2] + sValue[3] + sValue[4]);
//// ADD 2008.06.12 kcl)森本 着店コード検索方法の変更 END
								sRet = sv_syukka.Get_autoEntryPref3(gsaユーザ, sKey[0], sKey[1], sKey[4], sValue[7], sValue[2] + sValue[3] + sValue[4], sValue[5] + sValue[6]);
// MOD 2008.12.25 kcl)森本 着店コード検索方法の再変更 START
// ADD 2010.12.14 ACT）垣原 王子運送の対応 START
						}
						else
						{
							if(sv_oji == null) sv_oji = new is2oji.Service1();
							sRet = sv_oji.Get_autoEntryPref3(gsaユーザ, sKey[0], sKey[1], sKey[4], sValue[7], sValue[2] + sValue[3] + sValue[4], sValue[5] + sValue[6]);
						}
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END
							}
							catch (System.Net.WebException)
							{
								throw new Exception(gs通信エラー);
							}
							catch (Exception ex)
							{
								throw new Exception("通信エラー：" + ex.Message);
							}
							if(sRet[0].Length != 4)
							{
								if(sRet[0].Equals("該当データがありません"))
								{
									エラー出力(iCnt, 8, "郵便番号が存在しません\r\n");
								}
								else
								{
									throw new Exception(sRet[0]);
								}
							}
							else
							{
								sKey[15] = sRet[2];	//着店ＣＤ
								sKey[16] = sRet[3];	//着店名
								if (sKey[16].Length == 0) sKey[16] = " ";
								sKey[8]  = sRet[1];	//住所ＣＤ
// MOD 2008.11.19 東都）高木 着店コードが空白でもエラーでなくする START
//								if (sKey[15].Trim().Length == 0) エラー出力(iCnt, 8, "入力された郵便番号では配達店が決められませんでした\r\n");
// MOD 2008.11.19 東都）高木 着店コードが空白でもエラーでなくする END
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
// ADD 2007.11.20 東都）高木 桁数チェックの追加 START
						if (半角チェック(sValue[8]))
						{
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
//							if(!記号チェック(sValue[8])) エラー出力(iCnt, 9, "特殊計に使用できない記号があります\r\n");
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
							if (sValue[8].Length > 5) エラー出力(iCnt, 9, "特殊計は半角５文字以内で入力してください\r\n");
						}
						else
						{
// MOD 2008.04.25 東都）高木 特殊計は全角は不可にする START
//							if (sValue[8].Length > 2) エラー出力(iCnt, 9, "特殊計は半角５文字以内で入力してください\r\n");
							エラー出力(iCnt, 9, "特殊計は半角文字で入力してください\r\n");
// MOD 2008.04.25 東都）高木 特殊計は全角は不可にする END
						}
// ADD 2007.11.20 東都）高木 桁数チェックの追加 END
					}

					//荷送人コード
					sValue[10] = sValue[10].Trim();
					if (!必須チェック(sValue[10])) エラー出力(iCnt, 11, "荷送人コードは必須項目です\r\n");
					if (!半角チェック(sValue[10])) エラー出力(iCnt, 11, "荷送人コードは半角文字で入力してください\r\n");
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
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
						if(!記号チェック(sValue[10])){
							エラー出力(iCnt, 11, "荷送人コードに使用できない記号があります\r\n");
						}else{
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
							//荷送人存在チェック
							try
							{
								if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
//保留 MOD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 START
//保留 MOD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 END
								sRet = sv_syukka.Get_autoEntryClaim(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,sKey[18]);
							}
							catch (System.Net.WebException)
							{
								throw new Exception(gs通信エラー);
							}
							catch (Exception ex)
							{
								throw new Exception("通信エラー：" + ex.Message);
							}
							if(sRet[0].Length != 4)
							{
								if(sRet[0].Equals("該当データがありません"))
								{
									エラー出力(iCnt, 11, "荷送人コードが存在しません\r\n");
								}
								else
								{
									throw new Exception(sRet[0]);
								}
							}
							else
							{
								sKey[23] = sRet[1];	//得意先ＣＤ
								sKey[24] = sRet[2];	//部課ＣＤ
// ADD 2005.08.19 東都）高木 ＮＵＬＬエラーの対応 START
								if(sKey[24].Length == 0) sKey[24] = " ";
// ADD 2005.08.19 東都）高木 ＮＵＬＬエラーの対応 END
								sKey[25] = sRet[3]; //得意先部課名
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 START
								i荷送人固定重量 = int.Parse(sRet[4].Trim());
								i荷送人固定才数 = int.Parse(sRet[5].Trim());
								b重量才数再設定FLG = true;
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
// MOD 2010.09.03 東都）高木 ＣＳＶエントリー時の請求先エラー表記修正 START
//								if (sKey[25].Trim().Length == 0) エラー出力(iCnt, 11, "得意先部課名が存在しません\r\n");
								if(sKey[25].Trim().Length == 0)
								{
									string s請求先ＣＤ = sRet[1].Trim();
									if(sRet[2].Trim().Length > 0){
										s請求先ＣＤ += "-" + sRet[2].Trim();
									}
									エラー出力(iCnt, 11
									, "荷送人の請求先["+s請求先ＣＤ+"]は登録されていません\r\n");
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 START
									b重量才数再設定FLG = false;
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
								}
// MOD 2010.09.03 東都）高木 ＣＳＶエントリー時の請求先エラー表記修正 END
							}
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
						}
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
					}
					
					//荷送人部署名
					sKey[19] = " ";
// MOD 2011.07.14 東都）高木 記事行の追加 START
					if(iＣＳＶエントリー形式 == 2){
						if(sValue一覧行[(int)形式２.荷送担当者].Length != 0){
//							if(!全角チェック(sValue一覧行[(int)形式２.荷送担当者])){
//								エラー出力２(iCnt, (int)形式２.荷送担当者
//									, "荷送担当者は全角文字で入力してください\r\n");
//							}
//							if(sValue一覧行[(int)形式２.荷送担当者].Length > 10){
//								エラー出力２(iCnt, (int)形式２.荷送担当者
//									, "荷送担当者は１０文字以内で入力してください\r\n");
//							}
//							sKey[19] = sValue一覧行[(int)形式２.荷送担当者];
							if(!漢字変換_CSV(ref sValue一覧行[(int)形式２.荷送担当者], ref sErr)){
								エラー出力２(iCnt, (int)形式２.荷送担当者
								, "荷送担当者はVista対応により文字変換がおこなえませんでした"
													 + "『" + sErr + "』\r\n");
							}else{
								文字変換後出力(iCnt, (int)形式２.荷送担当者 + 1
													, sValue一覧行[(int)形式２.荷送担当者]);
							}
							if(!全角変換チェック(ref sValue一覧行[(int)形式２.荷送担当者], ref sErr)){
								エラー出力２(iCnt, (int)形式２.荷送担当者
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
//					if (!必須チェック(sValue[11]) || sValue[11].Equals("0")) エラー出力(iCnt, 12, "個数は必須項目です\r\n");
					if(!必須チェック(sValue[11]) || sValue[11].Equals("0"))
					{
						エラー出力(iCnt, 12, "個数は必須項目です\r\n");
						b重量才数再設定FLG = false;
					}
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
// MOD 2010.11.02 東都）高木 数値範囲チェックの変更 START
//					if (!数値チェック(sValue[11])) エラー出力(iCnt, 12, "個数は数値で入力してください\r\n");
//// ADD 2006.11.20 FJCS）桑田 前ゼロ対応 START
////					if (sValue[11].Trim().Length > 2) エラー出力(iCnt, 12, "個数は２桁以内で入力してください\r\n");
//					if (数値チェック(sValue[11]))
//					{	
//// MOD 2007.11.08 東都）高木 桁あふれ障害対応 START
////						if (int.Parse(sValue[11].Trim()) > 99) エラー出力(iCnt, 12, "個数は２桁以内で入力してください\r\n");
//						if (long.Parse(sValue[11].Trim()) > 99) エラー出力(iCnt, 12, "個数は２桁以内で入力してください\r\n");
//// MOD 2007.11.08 東都）高木 桁あふれ障害対応 END
//					}
//// ADD 2006.11.20 FJCS）桑田 前ゼロ対応 END
					sChkMsg = 数値範囲チェック("個数", sValue[11], 0, 99, "２桁以内");
					if(sChkMsg.Length > 0){
						エラー出力(iCnt, 12, sChkMsg +"\r\n");
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 START
						b重量才数再設定FLG = false;
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
					}
// MOD 2010.11.02 東都）高木 数値範囲チェックの変更 END
					sKey[26] = sValue[11];
					
					//才数
					sValue[12] = sValue[12].Trim();
// ADD 2005.09.15 東都）伊賀 空白の場合"0"として判定 START
					if (sValue[12].Length == 0) sValue[12] = "0";
// ADD 2005.09.15 東都）伊賀 空白の場合"0"として判定 END
// MOD 2010.11.02 東都）高木 数値範囲チェックの変更 START
//					if (!数値チェック(sValue[12])) エラー出力(iCnt, 13, "才数は数値で入力してください\r\n");
//					if (sValue[12].Trim().Length > 3) エラー出力(iCnt, 13, "才数は３桁以内で入力してください\r\n");
					sChkMsg = 数値範囲チェック("才数", sValue[12], 0, 999, "３桁以内");
					if(sChkMsg.Length > 0){
// MOD 2011.04.13 東都）高木 重量入力不可対応 START
////						エラー出力(iCnt, 12, sChkMsg +"\r\n");
//						エラー出力(iCnt, 13, sChkMsg +"\r\n");
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
//						sValue[12] = "0";
						if(gs重量入力制御 == "1")
						{
							エラー出力(iCnt, 13, sChkMsg +"\r\n");
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
// ADD 2005.09.15 東都）伊賀 空白の場合"0"として判定 START
					if (sValue[13].Length == 0) sValue[13] = "0";
// ADD 2005.09.15 東都）伊賀 空白の場合"0"として判定 END
// MOD 2010.11.02 東都）高木 数値範囲チェックの変更 START
//					if (!数値チェック(sValue[13])) エラー出力(iCnt, 14, "重量は数値で入力してください\r\n");
//					if (sValue[13].Trim().Length > 4) エラー出力(iCnt, 14, "重量は４桁以内で入力してください\r\n");
					sChkMsg = 数値範囲チェック("重量", sValue[13], 0, 9999, "４桁以内");
					if(sChkMsg.Length > 0){
// MOD 2011.04.13 東都）高木 重量入力不可対応 START
////						エラー出力(iCnt, 12, sChkMsg +"\r\n");
//						エラー出力(iCnt, 14, sChkMsg +"\r\n");
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
//						sValue[13] = "0";
						if(gs重量入力制御 == "1")
						{
							エラー出力(iCnt, 14, sChkMsg +"\r\n");
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
//						エラー出力(iCnt, 13, "才数と重量はどちらか一方を入力してください\r\n");
//						axGT取込データ一覧.set_CelMarking((short)(iCnt),(short)(14),true);
//					}
// MOD 2011.04.13 東都）高木 重量入力不可対応 END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
					if(gs重量入力制御 == "1")
					{
						if (!sValue[12].Equals("0")  && !sValue[13].Equals("0")){
							エラー出力(iCnt, 13, "才数と重量はどちらか一方を入力してください\r\n");
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 START
							b重量才数再設定FLG = false;
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
// MOD 2011.07.14 東都）高木 記事行の追加 START
//							axGT取込データ一覧.set_CelMarking((short)(iCnt),(short)(14),true);
							if(iＣＳＶエントリー形式 == 2)
							{
								axGT取込データ一覧.set_CelMarking((short)(iCnt),(short)((int)形式２.重量+1),true);
							}else{
								axGT取込データ一覧.set_CelMarking((short)(iCnt),(short)((int)形式１.重量+1),true);
							}
// MOD 2011.07.14 東都）高木 記事行の追加 START
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

							//併せて画面上の表示も再設定する
							if(iＣＳＶエントリー形式 == 2)
							{
								axGT取込データ一覧.set_CelText((short)iCnt, (short)((int)形式２.才数 + 1), sKey[27]); // 才数
								axGT取込データ一覧.set_CelText((short)iCnt, (short)((int)形式２.重量 + 1), sKey[28]); // 重量
							}
							else
							{
								axGT取込データ一覧.set_CelText((short)iCnt, (short)((int)形式１.才数 + 1), sKey[27]); // 才数
								axGT取込データ一覧.set_CelText((short)iCnt, (short)((int)形式１.重量 + 1), sKey[28]); // 重量
							}
						}
// MOD 2016.02.02 BEVAS）松本 荷送人マスタの固定重量、固定才数の考慮追加 END
					}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END

					//輸送指示１
					sValue[14] = sValue[14].TrimEnd();
// ADD 2005.10.13 東都）伊賀 エラー対応 START
					sKey[31] = "000";
					sKey[32] = " ";
// ADD 2005.10.13 東都）伊賀 エラー対応 END
					if (sValue[14].Length != 0)
					{
// ADD 2006.11.07 FJCS）桑田 輸送商品はコードでもＯＫとする START
						if (半角チェック(sValue[14]))
						{
							if (!数値チェック(sValue[14])) エラー出力(iCnt, 15, "輸送商品１コードは数値のみ入力可能です\r\n");
							if (sValue[14].Length != 3) エラー出力(iCnt, 15, "輸送商品１コードは３桁で入力してください\r\n");
							if (数値チェック(sValue[14]) && sValue[14].Length == 3)
							{
								string[] sList = {""};
								try
								{
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
									throw new Exception(gs通信エラー);
								}
								catch (Exception ex)
								{
									throw new Exception("通信エラー:" + ex.Message);
								}
								//存在しない時
								if (sList[3] == "I")
								{
									エラー出力(iCnt,15,"入力された輸送商品１コードはマスタに存在しません。\r\n");
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
							// ADD 2006.11.07 FJCS）桑田 輸送商品はコードでもＯＫとする END
						{
// ADD 2008.04.11 ACT Vista対応 START
							if (!漢字変換_CSV(ref sValue[14], ref sErr)) 
							{
								エラー出力(iCnt, 15, "輸送商品１はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}
							else
							{
								文字変換後出力(iCnt, 15, sValue[14]);
							}
// ADD 2008.04.11 ACT Vista対応 END
							if (!全角チェック(sValue[14])) エラー出力(iCnt, 15, "輸送商品１の名称は全角文字で、コードは半角文字で入力してください（どちらか一方のみです）\r\n");
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
									throw new Exception(gs通信エラー);
								}
								catch (Exception ex)
								{
									throw new Exception("通信エラー：" + ex.Message);
								}
								if(sRet[0].Length != 4)
								{
									if(sRet[0].Equals("該当データがありません"))
									{
										sKey[31] = "000";
										エラー出力(iCnt, 15, "輸送商品１が存在しません\r\n");
									}
									else
									{
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
							if (sKey[33].Equals("000")) エラー出力(iCnt, 16, "輸送商品１が入力されている場合、輸送商品２は必須項目です\r\n");
						}
						else if (!sList[0].Equals("該当データがありません"))
						{
							throw new Exception(sList[0]);
						}
					}
					if (sValue[15].Length != 0)
					{
						if (sValue[14].Length == 0) エラー出力(iCnt, 15, "輸送商品１を入力してください\r\n");
// ADD 2006.11.07 FJCS）桑田 輸送商品はコードでもＯＫとする START
						if (半角チェック(sValue[15]))
						{
							if (!数値チェック(sValue[15])) エラー出力(iCnt, 16, "輸送商品２コードは数値のみ入力可能です\r\n");
							if (sValue[15].Length != 3) エラー出力(iCnt, 16, "輸送商品２コードは３桁で入力してください\r\n");
							if (数値チェック(sValue[15]) && sValue[15].Length == 3)
							{
								string[] sList = {""};
								try
								{
									if(sv_kiji == null) sv_kiji = new is2kiji.Service1();
// MOD 2011.06.07 東都）高木 王子運送の対応 START
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
									throw new Exception(gs通信エラー);
								}
								catch (Exception ex)
								{
									throw new Exception("通信エラー：" + ex.Message);
								}
								//存在しない時
								if(sList[3] == "I")
								{
									エラー出力(iCnt,16,"入力された輸送商品２コードはマスタに存在しません。\r\n");
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
// ADD 2006.11.07 FJCS）桑田 輸送商品はコードでもＯＫとする END
						{
// ADD 2008.04.11 ACT Vista対応 START
							if (!漢字変換_CSV(ref sValue[15], ref sErr)) 
							{
								エラー出力(iCnt, 16, "輸送商品２はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}
							else
							{
								文字変換後出力(iCnt, 16, sValue[15]);
							}
// ADD 2008.04.11 ACT Vista対応 END
							if (!全角チェック(sValue[15])) エラー出力(iCnt, 16, "輸送商品２の名称は全角文字で、コードは半角文字で入力してください（どちらか一方のみです）\r\n");
// MOD 2009.11.25 東都）高木 時間指定チェックの追加 START
							if(sValue[14].Length != 0 && 全角チェック(sValue[15]) && sKey[31].Equals("100")){
								if(sValue[15].Equals("ＡＭ指定")){
									sValue[15] = "ＡＭ指定（１０時～１２時）";
								}
							}
// MOD 2009.11.25 東都）高木 時間指定チェックの追加 END
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
									throw new Exception(gs通信エラー);
								}
								catch (Exception ex)
								{
									throw new Exception("通信エラー：" + ex.Message);
								}
								if(sRet[0].Length != 4)
								{
									if(sRet[0].Equals("該当データがありません"))
									{
										sKey[33] = "000";
										エラー出力(iCnt, 16, "輸送商品２が存在しません\r\n");
									}
									else
									{
										throw new Exception(sRet[0]);
									}
								}
								else
								{
// MOD 2009.11.25 東都）高木 時間指定チェックの追加 START
									if(sKey[31].Equals("100")){
										if(sRet[1].Equals("11X")){
// MOD 2010.05.25 東都）高木 時間指定の変更 START
//											時間指定チェック(iCnt, sValue[15], 12, 21);
											時間指定チェック(iCnt, sValue[15], 12, 20);
// MOD 2010.05.25 東都）高木 時間指定の変更 END
										}else if(sRet[1].Equals("12X")){
// MOD 2010.05.25 東都）高木 時間指定の変更 START
//											時間指定チェック(iCnt, sValue[15], 10, 19);
											時間指定チェック(iCnt, sValue[15], 10, 18);
// MOD 2010.05.25 東都）高木 時間指定の変更 END
										}
									}else if(sKey[31].Equals("200")){
										if(sRet[1].Equals("21X")){
// MOD 2010.05.25 東都）高木 時間指定の変更 START
//											時間指定チェック(iCnt, sValue[15], 12, 21);
											時間指定チェック(iCnt, sValue[15], 12, 20);
// MOD 2010.05.25 東都）高木 時間指定の変更 END
										}else if(sRet[1].Equals("22X")){
// MOD 2010.05.25 東都）高木 時間指定の変更 START
//											時間指定チェック(iCnt, sValue[15], 10, 19);
											時間指定チェック(iCnt, sValue[15], 10, 18);
// MOD 2010.05.25 東都）高木 時間指定の変更 END
										}
									}
// MOD 2009.11.25 東都）高木 時間指定チェックの追加 END
									sKey[33] = sRet[1];
								}
							}
						}
					}
// ADD 2005.06.02 東都）伊賀 輸送商品による個数重量制限 START
					// パーセルワンの場合
					if (sKey[31].Equals("001"))
					{
						if (!sKey[26].Equals("1")) エラー出力(iCnt, 12, "輸送商品１が" + sKey[32] + "の場合、個数は'1'を入力してください\r\n");
						if (!sKey[28].Equals("1")) エラー出力(iCnt, 14, "輸送商品１が" + sKey[32] + "の場合、重量は'1'を入力してください\r\n");
					}
					// パーセルパックの場合
					if (sKey[31].Equals("002"))
					{
						if (!sKey[26].Equals("1")) エラー出力(iCnt, 12, "輸送商品１が" + sKey[32] + "の場合、個数は'1'を入力してください\r\n");
						if (数値チェック(sKey[28]) && int.Parse(sKey[28]) > 30) エラー出力(iCnt, 14, "輸送商品１が" + sKey[32] + "の場合、重量は３０以下を入力してください\r\n");
						if (数値チェック(sKey[27]) && 数値チェック(sKey[28]) && int.Parse(sKey[27]) > 0 && int.Parse(sKey[28]) == 0) エラー出力(iCnt, 14, "輸送商品１が" + sKey[32] + "の場合、重量を入力してください\r\n");
					}
// ADD 2005.06.02 東都）伊賀 輸送商品による個数重量制限 END

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
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
						if(!記号チェック２(sValue[16])) エラー出力(iCnt, 17, "品名記事１に使用できない記号があります\r\n");
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
// ADD 2008.04.11 ACT Vista対応 START
						if (!漢字変換_CSV(ref sValue[16], ref sErr)) 
						{
							エラー出力(iCnt, 17, "品名記事１はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
						}
						else
						{
							文字変換後出力(iCnt, 17, sValue[16]);
						}
// ADD 2008.04.11 ACT Vista対応 END
// MOD 2009.12.01 東都）高木 全角半角混在可能にする START
//						sKey[35] = Microsoft.VisualBasic.Strings.StrConv(sValue[16], Microsoft.VisualBasic.VbStrConv.Wide, 0);
//						if (sKey[35].Length > 15) sKey[35] = sKey[35].Substring(0, 15);
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 START
//						sKey[35] = sKey[35].Replace('\\','￥');
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 END
						sKey[35] = バイト長カット(sValue[16], 30);
// MOD 2009.12.01 東都）高木 全角半角混在可能にする END
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
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
						if(!記号チェック２(sValue[17])) エラー出力(iCnt, 18, "品名記事２に使用できない記号があります\r\n");
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
// ADD 2008.04.11 ACT Vista対応 START
						if (!漢字変換_CSV(ref sValue[17], ref sErr)) 
						{
							エラー出力(iCnt, 18, "品名記事２はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
						}
						else
						{
							文字変換後出力(iCnt, 18, sValue[17]);
						}
// ADD 2008.04.11 ACT Vista対応 END
// MOD 2009.12.01 東都）高木 全角半角混在可能にする START
//						sKey[36] = Microsoft.VisualBasic.Strings.StrConv(sValue[17], Microsoft.VisualBasic.VbStrConv.Wide, 0);
//						if (sKey[36].Length > 15) sKey[36] = sKey[36].Substring(0, 15);
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 START
//						sKey[36] = sKey[36].Replace('\\','￥');
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 END
						sKey[36] = バイト長カット(sValue[17], 30);
// MOD 2009.12.01 東都）高木 全角半角混在可能にする END
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
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
						if(!記号チェック２(sValue[18])) エラー出力(iCnt, 19, "品名記事３に使用できない記号があります\r\n");
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
// ADD 2008.04.11 ACT Vista対応 START
						if (!漢字変換_CSV(ref sValue[18], ref sErr)) 
						{
							エラー出力(iCnt, 19, "品名記事３はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
						}
						else
						{
							文字変換後出力(iCnt, 19, sValue[18]);
						}
// ADD 2008.04.11 ACT Vista対応 END
// MOD 2009.12.01 東都）高木 全角半角混在可能にする START
//						sKey[37] = Microsoft.VisualBasic.Strings.StrConv(sValue[18], Microsoft.VisualBasic.VbStrConv.Wide, 0);
//						if (sKey[37].Length > 15) sKey[37] = sKey[37].Substring(0, 15);
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 START
//						sKey[37] = sKey[37].Replace('\\','￥');
//保留 MOD 2009.12.15 東都）高木 [\]→[￥]変換の追加 END
						sKey[37] = バイト長カット(sValue[18], 30);
// MOD 2009.12.01 東都）高木 全角半角混在可能にする END
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
								エラー出力２(iCnt, (int)形式２.品名記事４
								, "品名記事４に使用できない記号があります\r\n");
							}
							if(!漢字変換_CSV(ref sValue一覧行[(int)形式２.品名記事４], ref sErr)){
								エラー出力２(iCnt, (int)形式２.品名記事４
								, "品名記事４はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}else{
								文字変換後出力(iCnt, (int)形式２.品名記事４ + 1
								, sValue一覧行[(int)形式２.品名記事４]);
							}
							sKey[47] = バイト長カット(sValue一覧行[(int)形式２.品名記事４], 30);
						}
						sKey[48] = " ";
						if(sValue一覧行[(int)形式２.品名記事５].Length != 0){
							if(!記号チェック２(sValue一覧行[(int)形式２.品名記事５])){
								エラー出力２(iCnt, (int)形式２.品名記事５
								, "品名記事５に使用できない記号があります\r\n");
							}
							if(!漢字変換_CSV(ref sValue一覧行[(int)形式２.品名記事５], ref sErr)){
								エラー出力２(iCnt, (int)形式２.品名記事５
								, "品名記事５はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}else{
								文字変換後出力(iCnt, (int)形式２.品名記事５ + 1
								, sValue一覧行[(int)形式２.品名記事５]);
							}
							sKey[48] = バイト長カット(sValue一覧行[(int)形式２.品名記事５], 30);
						}
						sKey[49] = " ";
						if(sValue一覧行[(int)形式２.品名記事６].Length != 0){
							if(!記号チェック２(sValue一覧行[(int)形式２.品名記事６])){
								エラー出力２(iCnt, (int)形式２.品名記事６
								, "品名記事６に使用できない記号があります\r\n");
							}
							if(!漢字変換_CSV(ref sValue一覧行[(int)形式２.品名記事６], ref sErr)){
								エラー出力２(iCnt, (int)形式２.品名記事６
								, "品名記事６はVista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							}else{
								文字変換後出力(iCnt, (int)形式２.品名記事６ + 1
								, sValue一覧行[(int)形式２.品名記事６]);
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
					
// MOD 2007.10.25 東都）高木 項目の変更（予備２をお客様管理番号にする） START
					//お客様管理番号
					sValue[20] = sValue[20].Trim();
					if (sValue[20] == "0")	sValue[20]=""; // ？
					if (sValue[20].Length != 0)
					{
						if (!半角チェック(sValue[20])) エラー出力(iCnt, 21, "お客様管理番号は半角文字で入力してください\r\n");
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
//						if(!記号チェック(sValue[20])) エラー出力(iCnt, 21, "お客様管理番号に使用できない記号があります\r\n");
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 START
//						if (sValue[20].Length > 15) エラー出力(iCnt, 21, "お客様管理番号は１５桁以内で入力してください\r\n");
						if (sValue[20].Length > 16){
							エラー出力(iCnt, 21, "お客様管理番号は１６桁以内で入力してください\r\n");
						}
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 END
						sKey[3] = sValue[20];
					}
// MOD 2007.10.25 東都）高木 項目の変更（予備２をお客様管理番号にする） END

					//元着区分
					sValue[22] = sValue[22].Trim();
					if (!sValue[22].Equals("1"))
					{
						エラー出力(iCnt, 23, "元着区分は'1'を入力してください\r\n");
					}
					sKey[38] = sValue[22];
					
					//保険金額
					sValue[23] = sValue[23].Trim();
// ADD 2005.09.15 東都）伊賀 空白の場合"0"として判定 START
					if (sValue[23].Length == 0) sValue[23] = "0";
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 START
//// ADD 2005.09.15 東都）伊賀 空白の場合"0"として判定 END
//					if (!数値チェック(sValue[23])) エラー出力(iCnt, 24, "保険金額は数値で入力してください\r\n");
//// ADD 2006.10.16 FJCS）桑田 バグ修正 START
////					if (sValue[21].Trim().Length > 4) エラー出力(iCnt, 24, "保険金額は４桁以内で入力してください\r\n");
//// ADD 2006.11.20 FJCS）桑田 前ゼロ対応 START
////					if (sValue[23].Trim().Length > 4) エラー出力(iCnt, 24, "保険金額は４桁以内で入力してください\r\n");
//					if (数値チェック(sValue[23]))
//					{	
//// MOD 2007.11.08 東都）高木 桁あふれ障害対応 START
////						if (int.Parse(sValue[23].Trim()) > 9999) エラー出力(iCnt, 24, "保険金額は４桁以内で入力してください\r\n");
//						if (long.Parse(sValue[23].Trim()) > 9999) エラー出力(iCnt, 24, "保険金額は４桁以内で入力してください\r\n");
//// MOD 2007.11.08 東都）高木 桁あふれ障害対応 END
//					}
//// ADD 2006.11.20 FJCS）桑田 前ゼロ対応 END
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) START
//					sChkMsg = 数値範囲チェック("保険金額", sValue[23], 0, 30, "");
					sChkMsg = 数値範囲チェック("保険金額", sValue[23], 0, gl保険金額上限, "４桁以内");
// MOD 2010.12.01 東都）高木 保険金額上限を元に戻す(9999万) END
					if(sChkMsg.Length > 0){
						エラー出力(iCnt, 24, sChkMsg +"\r\n");
					}
// MOD 2010.11.02 東都）高木 保険金額上限を30万に変更 END

// ADD 2006.10.16 FJCS）桑田 バグ修正 END
					sKey[39] = sValue[23];
					
					//出荷日
					sValue[24] = sValue[24].Trim();
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック START
					DateTime dt出荷日 = DateTime.Today;
					bool     b出荷日設定 = false;
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック END
// ADD 2007.11.20 東都）高木 桁数チェックの追加 START
					if (!必須チェック(sValue[24])) エラー出力(iCnt, 25, "出荷日は必須項目です\r\n");
					if (sValue[24].Length != 0)
					{
						if (!半角チェック(sValue[24])) エラー出力(iCnt, 25, "出荷日は半角文字で入力してください\r\n");
						if (sValue[24].Length != 8)
						{
							エラー出力(iCnt, 25, "出荷日は８文字で入力してください\r\n");
						}
						else
						{
// ADD 2007.11.20 東都）高木 桁数チェックの追加 END
							try
							{
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック START
//								if (new DateTime(int.Parse(sValue[24].Substring(0,4)),
//									int.Parse(sValue[24].Substring(4,2)),
//									int.Parse(sValue[24].Substring(6))) < gdt出荷日)
//								{
//									エラー出力(iCnt, 25, "出荷日は" + gdt出荷日.ToString("yyyy年MM月dd日") + "以降で入力してください\r\n");
//								}
								dt出荷日 = new DateTime(int.Parse(sValue[24].Substring(0,4)),
														int.Parse(sValue[24].Substring(4,2)),
														int.Parse(sValue[24].Substring(6)));
								b出荷日設定 = true;
								if(dt出荷日 < gdt出荷日)
								{
//									エラー出力(iCnt, 25, "出荷日は当日以降を入力してください\r\n");
									エラー出力(iCnt, 25, "出荷日は" + gdt出荷日.ToString(" M月 d日") + "以降を入力してください\r\n");
								}
								//当日（登録日）から２週間まで
//								else if(dt出荷日 > DateTime.Today.AddDays(14))
								else if(dt出荷日 > gdt出荷日最大値ＣＳＶ)
								{
//									エラー出力(iCnt, 25, "出荷日は" + DateTime.Today.AddDays(14).ToString("yyyy年MM月dd日")
									エラー出力(iCnt, 25, "出荷日は" + gdt出荷日最大値ＣＳＶ.ToString(" M月 d日")
									 + "以前を入力してください\r\n");
								}
								// ADD-S 2012.09.26 COA)横山 日付項目取込強化
								else 
								{
									sValue[24] = YYYYMMDD変換(dt出荷日);
								}
								// ADD-E 2012.09.26 COA)横山 日付項目取込強化
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック END
							}
							catch
							{
								エラー出力(iCnt, 25, "出荷日はyyyyMMddの形式で入力してください\r\n");
							}
// ADD 2007.11.20 東都）高木 桁数チェックの追加 START
						}
					}
// ADD 2007.11.20 東都）高木 桁数チェックの追加 END
					sKey[2] = sValue[24];
					
// MOD 2010.02.25 東都）高木 項目数チェックの修正 START
					//登録日の初期設定
					sKey[40] = YYYYMMDD変換(DateTime.Now);
					if(sValue.Length > 25){
// MOD 2010.02.25 東都）高木 項目数チェックの修正 END
						//登録日
						sValue[25] = sValue[25].Trim();
// ADD 2006.10.05 FJCS）桑田 項目の変更（予備１を配達指定日にする） START
						string   s当日    = YYYYMMDD変換(DateTime.Now);
// ADD 2006.10.05 FJCS）桑田 項目の変更（予備１を配達指定日にする） END
// MOD 2006.06.29 東都）山本 登録日省略時のシステム日付編集対応 START
// ADD 2006.11.07 FJCS）桑田 0は許容する START
						sValue[25] = sValue[25].Trim();
						if (sValue[25] == "0")	sValue[25]="";
// ADD 2006.11.07 FJCS）桑田 0は許容する END
						if (sValue[25].Length != 0)
						{	
							try
							{
								DateTime dt登録日 = new DateTime(int.Parse(sValue[25].Substring(0,4)),int.Parse(sValue[25].Substring(4,2)), int.Parse(sValue[25].Substring(6)));
// MOD 2005.07.08 東都）高木 日付変換の変更 START
//								string   s当日    = DateTime.Now.ToString("yyyyMMdd");
//								string   s当日    = YYYYMMDD変換(DateTime.Now);
// MOD 2005.07.08 東都）高木 日付変換の変更 END
								if (!sValue[25].Equals(s当日)) エラー出力(iCnt, 26, "登録日は当日を入力してください\r\n");
							}
							catch
							{
								エラー出力(iCnt, 26, "登録日はyyyyMMddの形式で入力してください\r\n");
							}
						}
						else 
							sValue[25] = s当日;
// MOD 2006.06.29 東都）山本 登録日省略時のシステム日付編集対応 END
						sKey[40] = sValue[25];
// MOD 2010.02.25 東都）高木 項目数チェックの修正 START
					}
// MOD 2010.02.25 東都）高木 項目数チェックの修正 END
					//指定日
					sKey[29] = "0";
					//指定日区分
					sKey[30] = "0";
// AOD 2006.10.05 FJCS）桑田 項目の変更（予備１を配達指定日にする） START
					sValue[19] = sValue[19].Trim();
					if (sValue[19] == "0")	sValue[19]="";
					if (sValue[19].Length != 0)
					{
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 START
						if(sValue[19].Length != 8){
							エラー出力(iCnt, 20, "配達指定日は８文字で入力してください\r\n");
						}else{
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 END
						try
						{
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック START
//							DateTime dtWork0 = new DateTime(int.Parse(sValue[19].Substring(0,4)),int.Parse(sValue[19].Substring(4,2)), int.Parse(sValue[19].Substring(6)));
//							DateTime dtWork = new DateTime(int.Parse(s当日.Substring(0,4)),int.Parse(s当日.Substring(4,2)), int.Parse(s当日.Substring(6)));
//							DateTime dt指定日 =dtWork.AddMonths(1);
//							string   dt加算指定日 = YYYYMMDD変換(dt指定日);
//							if (int.Parse(sValue[19]) >= int.Parse(dt加算指定日) ) エラー出力(iCnt, 20, "配達指定日は当日以降１ヶ月以内で入力してください\r\n");
//							if (int.Parse(sValue[19]) < int.Parse(s当日) ) エラー出力(iCnt, 20, "配達指定日は当日以降を入力してください\r\n");
							DateTime dt配達指定日 = new DateTime(
															int.Parse(sValue[19].Substring(0,4))
															, int.Parse(sValue[19].Substring(4,2))
															, int.Parse(sValue[19].Substring(6)));
							// ADD-S 2012.09.26 COA)横山 日付項目取込強化
							bool	wk_bNoErr_配達指定日	= true;
							// ADD-E 2012.09.26 COA)横山 日付項目取込強化

							if(b出荷日設定){
// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 START
//								//出荷日から１４日まで
//								if(dt配達指定日 < dt出荷日)
//								{
//									エラー出力(iCnt, 20, "配達指定日は出荷日以降を入力してください\r\n");
//								}
//								if(dt配達指定日 > dt出荷日.AddDays(14))
//								{
//									エラー出力(iCnt, 20, "配達指定日は" + dt出荷日.AddDays(14).ToString(" M月 d日")
//									 + "以前を入力してください\r\n");
//								}
								//出荷日から（１４日 or ９０日）まで
								DateTime dt指定日最大値;
// MOD 2009.12.08 東都）高木 指定日の上限障害（上記のグローバル対応の障害）START
//								if(gs部門店所ＣＤ.Equals("047")){
//									dt指定日最大値 = gdt出荷日.AddDays(90);
//								}else{
//									dt指定日最大値 = gdt出荷日.AddDays(14);
//								}
								if(gs部門店所ＣＤ.Equals("047")){
									dt指定日最大値 = dt出荷日.AddDays(90);
								}else{
									dt指定日最大値 = dt出荷日.AddDays(14);
								}
// MOD 2009.12.08 東都）高木 指定日の上限障害（上記のグローバル対応の障害）END
// MOD 2016.04.13 BEVAS）松本 配達指定日上限の拡張 START
								//セリア様の場合、配達指定日の上限を180日にまで拡張
								if(gs会員ＣＤ.Equals(gs指定日上限拡張会員ＣＤ))
								{
									dt指定日最大値 = dt出荷日.AddDays(180);
								}
// MOD 2016.04.13 BEVAS）松本 配達指定日上限の拡張 END
								if(dt配達指定日 < dt出荷日)
								{
									エラー出力(iCnt, 20, "配達指定日は出荷日以降を入力してください\r\n");
									// ADD-S 2012.09.26 COA)横山 日付項目取込強化
									wk_bNoErr_配達指定日	= false;
									// ADD-E 2012.09.26 COA)横山 日付項目取込強化

								}
								if(dt配達指定日 > dt指定日最大値)
								{
									エラー出力(iCnt, 20, "配達指定日は" + dt指定日最大値.ToString(" M月 d日")
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
// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 END
							}
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック END
						}
						catch
						{
							エラー出力(iCnt, 20, "配達指定日はyyyyMMddの形式で入力してください\r\n");
						}
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 START
						}
// MOD 2010.10.01 東都）高木 お客様番号１６桁化 END
						sKey[29] = sValue[19];
						sKey[30] = "1"; // 1:指定
// MOD 2011.07.14 東都）高木 記事行の追加 START
						if(iＣＳＶエントリー形式 == 2){
							if(sValue一覧行[(int)形式２.必着区分].Length != 0){
								if(半角チェック(sValue一覧行[(int)形式２.必着区分])){
									if(sValue一覧行[(int)形式２.必着区分] == "0"){
										sKey[30] = "0"; // 0:必着 1:指定
									}else if(sValue一覧行[(int)形式２.必着区分] == "1"){
										sKey[30] = "1"; // 0:必着 1:指定
									}else{
										エラー出力２(iCnt, (int)形式２.必着区分
										, "必着区分は[0]もしくは[1]で入力してください\r\n");
									}
								}else{
									if(sValue一覧行[(int)形式２.必着区分] == "必着"){
										sKey[30] = "0"; // 0:必着 1:指定
									}else if(sValue一覧行[(int)形式２.必着区分] == "指定"){
										sKey[30] = "1"; // 0:必着 1:指定
									}else{
										エラー出力２(iCnt, (int)形式２.必着区分
										, "必着区分は[必着]もしくは[指定]で入力してください\r\n");
									}
								}
							}
						}
// MOD 2011.07.14 東都）高木 記事行の追加 END
					}
// ADD 2006.10.05 FJCS）桑田 項目の変更（予備１を配達指定日にする） END
					//送り状発行済ＦＧ
					sKey[41] = "0";
					//出荷済ＦＧ
					sKey[42] = "0";
					//一括出荷ＦＧ
					sKey[43] = "0";
					sKey[44] = "自動出荷";
					sKey[45] = gs利用者ＣＤ;
					
					StringBuilder sbKeyData = new StringBuilder();
					for (int j = 0; j < sKey.Length; j++)
					{
						sbKeyData.Append(sKey[j] + ",");
					}
					s取込データ[iCnt - 1] = sbKeyData.ToString();
				}
				texメッセージ.Text = "";
				axGT取込データ一覧.Focus();
			}
			catch (Exception ex)
			{
				texメッセージ.Text = ex.Message;
				axGT取込データ一覧.Clear();
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 START
				axGT取込データ一覧.CaretRow = 1;
				axGT取込データ一覧.CaretCol = 1;
				axGT取込データ一覧_CurPlaceChanged(null,null);
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 END
				b取込 = false;
				bエラー出力 = false;
			}
			finally
			{
				sr.Close();
			}

// MOD 2010.03.18 東都）高木 データ無しチェックの追加 START
			if(s取込データ.Length == 1){
				if(s取込データ[0] == null){
					Cursor = System.Windows.Forms.Cursors.Default;
					texメッセージ.Text = "データがありません";
					texメッセージ.Refresh();
					return;
				}else if(s取込データ[0].Trim().Length == 0){
					Cursor = System.Windows.Forms.Cursors.Default;
					texメッセージ.Text = "データがありません";
					texメッセージ.Refresh();
					return;
				}
			}
// MOD 2010.03.18 東都）高木 データ無しチェックの追加 END

			if (b取込)
				btn取込.Enabled = true;
			else
				texメッセージ.Text += "エラーがあります";
			if (bエラー出力)
				btn一覧表.Enabled = true;
			Cursor = System.Windows.Forms.Cursors.Default;

// ADD 2006.06.29 東都）山本 取込件数＆エラー件数の表示対応 START
			if (bエラー出力)
			{
				for(int Kensu=0;Kensu < s取込エラー.Length ;Kensu++)
				{
// MOD 2006.10.16 FJCS）桑田 バグ修正 START
					//if(s取込エラー[Kensu].Length != 0)
					if(s取込エラー[Kensu] != null)
// MOD 2006.10.016FJCS）桑田 バグ修正 END
						iエラー件数++;
				}
			}
			int Wrkcnt = i取込件数 - iエラー件数;
			lblInputCnt.Text=Wrkcnt.ToString()+"件";
			lblErrorCnt.Text=iエラー件数.ToString()+"件";
// ADD 2006.06.29 東都）山本 取込件数＆エラー件数の表示対応 END
		}

		private void btn取込_Click(object sender, System.EventArgs e)
		{
// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 START
			btn取込.Enabled = false;
			btn取込.Refresh();
			texメッセージ.Text = "取込中．．．";
			texメッセージ.Refresh();
			Cursor = System.Windows.Forms.Cursors.AppStarting;
// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 END
			try
			{
				if (sv_syukka == null)
				{
					sv_syukka = new is2syukka.Service1();
// DEL 2005.05.20 東都）高木 セションコントロールの廃止 START
//					sv_syukka.CookieContainer = cContainer;
// DEL 2005.05.20 東都）高木 セションコントロールの廃止 END
				}
				string[] sRet = sv_syukka.Ins_autoEntryData(gsaユーザ,s取込データ);
				texメッセージ.Text = sRet[0];
				if(sRet[0].Length == 0)
				{
					MessageBox.Show("正常に取り込まれました","ＣＳＶエントリー",MessageBoxButtons.OK);
				}
// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 START
				else
				{
					btn取込.Enabled = true;
				}
// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 END
			}
// ADD 2005.07.05 東都）高木 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				texメッセージ.Text = gs通信エラー;
// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 START
				btn取込.Enabled = true;
// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 END
			}
// ADD 2005.07.05 東都）高木 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				texメッセージ.Text = ex.Message;
// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 START
				btn取込.Enabled = true;
// ADD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 END
			}
// MOD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 START
//			btn取込.Enabled = false;
			Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2007.04.20 東都）高木 ＣＳＶエントリ（自動出荷登録）の高速化 END
		}

// DEL 2005.06.30 東都）小童谷 共通フォームへ移動 START
//		private bool 必須チェック(string data)
//		{
//			if (data.Trim().Length == 0)
//				return false;
//			else
//				return true;
//		}
//
//		private bool 全角チェック(string data)
//		{
//			string sUnicode = data;
//			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
//			if(bSjis.Length == sUnicode.Length * 2) return true;
//			return false;
//		}
//
//		private bool 半角チェック(string data)
//		{
//			string sUnicode = data;
//			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
//			if(bSjis.Length != sUnicode.Length) return false;
//			return true;
//		}
//
//		private bool 数値チェック(string data)
//		{
//			try
//			{
//				int iChk = int.Parse(data.Replace(",",""));
//				return true;
//			}
//			catch(System.FormatException)
//			{
//				return false;
//			}
//		}
// DEL 2005.06.30 東都）小童谷 共通フォームへ移動 END

		private void エラー出力(int nRow, int nCol, string message)
		{
//			axGT取込データ一覧.set_CelBackColor((short)nRow,(short)(nCol + 1),0x0000FF);
// MOD 2011.07.14 東都）高木 記事行の追加 START
			if(iＣＳＶエントリー形式 == 2){
				switch(nCol - 1){
				case (int)形式１.個数: // 11
					nCol = (int)形式２.個数;
					nCol++;
					break;
				case (int)形式１.才数: // 12
					nCol = (int)形式２.才数;
					nCol++;
					break;
				case (int)形式１.重量: // 13
					nCol = (int)形式２.重量;
					nCol++;
					break;
				case (int)形式１.輸送商品１: // 14
					nCol = (int)形式２.輸送商品１;
					nCol++;
					break;
				case (int)形式１.輸送商品２: // 15
					nCol = (int)形式２.輸送商品２;
					nCol++;
					break;
				case (int)形式１.品名記事１: // 16
					nCol = (int)形式２.品名記事１;
					nCol++;
					break;
				case (int)形式１.品名記事２: // 17
					nCol = (int)形式２.品名記事２;
					nCol++;
					break;
				case (int)形式１.品名記事３: // 18
					nCol = (int)形式２.品名記事３;
					nCol++;
					break;
				case (int)形式１.配達指定日: // 19
					nCol = (int)形式２.配達指定日;
					nCol++;
					break;
				case (int)形式１.お客様管理番号: // 20
					nCol = (int)形式２.お客様管理番号;
					nCol++;
					break;
//				case (int)形式１.予備:
//					break;
				case (int)形式１.元払区分: // 22
					nCol = (int)形式２.元払区分;
					nCol++;
					break;
				case (int)形式１.保険金額: // 23
					nCol = (int)形式２.保険金額;
					nCol++;
					break;
				case (int)形式１.出荷日付: // 24
					nCol = (int)形式２.出荷日付;
					nCol++;
					break;
				case (int)形式１.登録日付: // 25
					nCol = (int)形式２.登録日付;
					nCol++;
					break;
				}
			}
// MOD 2011.07.14 東都）高木 記事行の追加 END
			axGT取込データ一覧.set_CelMarking((short)nRow,(short)(nCol),true);
			s取込エラー[nRow - 1] += message;
			b取込 = false;
			bエラー出力 = true;
		}
// MOD 2011.07.14 東都）高木 記事行の追加 START
		private void エラー出力２(int nRow, int nCol, string message)
		{
			axGT取込データ一覧.set_CelMarking((short)nRow,(short)(nCol + 1),true);
			s取込エラー[nRow - 1] += message;
			b取込 = false;
			bエラー出力 = true;
		}
// MOD 2011.07.14 東都）高木 記事行の追加 END

		private void axGT取込データ一覧_CelDblClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelDblClickEvent e)
		{
			if (s取込エラー.Length < axGT取込データ一覧.CaretRow) return;
			string errMessage = s取込エラー[(int)axGT取込データ一覧.CaretRow - 1];
			if (errMessage.Trim().Length != 0) MessageBox.Show(errMessage,"入力チェック",MessageBoxButtons.OK);
		}

		private void axGT取込データ一覧_CurPlaceChanged(object sender, AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEvent e)
		{
			axGT取込データ一覧.set_CelForeColor(nOldRow,0,0);
			axGT取込データ一覧.set_CelBackColor(nOldRow,0,0xFFFFFF);
			axGT取込データ一覧.set_CelForeColor(axGT取込データ一覧.CaretRow,0,0x98FB98);  //BGR
			axGT取込データ一覧.set_CelBackColor(axGT取込データ一覧.CaretRow,0,0x006000);
			nOldRow = axGT取込データ一覧.CaretRow;
		}

		private void 自動出荷登録_Closed(object sender, System.EventArgs e)
		{
			texファイル名.Text  = " ";
			texメッセージ.Text  = "";
			axGT取込データ一覧.Clear();
			axGT取込データ一覧.CaretRow  = 1;
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 START
			axGT取込データ一覧.CaretCol = 1;
// ADD 2007.02.21 東都）高木 検索後のカラム位置の調整 END
			axGT取込データ一覧_CurPlaceChanged(null,null);
			texファイル名.Focus();
		}

// ADD 2005.06.08 東都）伊賀 一覧表出力追加 START
		private void btn一覧表_Click(object sender, System.EventArgs e)
		{
			texメッセージ.Text = "エラー一覧印刷中．．．";
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;

			int i行番号 = 1;
			自動出荷エラーデータ ds = new 自動出荷エラーデータ();
			for (int iCnt = 0; iCnt < s取込エラー.Length; iCnt++)
			{
				if (s取込エラー[iCnt] == null) continue;
				string[] s取込エラー詳細 = s取込エラー[iCnt].Replace("\r\n", ",").Split(',');
				for (int jCnt = 0; jCnt < s取込エラー詳細.Length - 1; jCnt++)
				{
					自動出荷エラーデータ.table自動出荷エラーRow tr = (自動出荷エラーデータ.table自動出荷エラーRow)ds.table自動出荷エラー.NewRow();
					tr.BeginEdit();
					tr.番号 = i行番号++;
					tr.エラー行 = (iCnt + 1).ToString() + "行目";
					tr.エラー内容 = s取込エラー詳細[jCnt];
					tr.EndEdit();
					ds.table自動出荷エラー.Rows.Add(tr);					
				}
			}
			自動出荷エラー帳票 cr = new 自動出荷エラー帳票();
			//CrystalReportにパラメータとデータセットを渡す
			cr.SetParameterValue("部門ＣＤ", gs部門ＣＤ);
			cr.SetParameterValue("部門名",   gs部門名);
			cr.SetParameterValue("対象ファイル", s対象ファイル);
			cr.SetDataSource(ds);
			this.Cursor = System.Windows.Forms.Cursors.Default;

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
		}
// ADD 2005.06.08 東都）伊賀 一覧表出力追加 END
// ADD 2008.04.11 ACT Vista対応 START
		private void 文字変換後出力(int nRow, int nCol, string message)
		{
// MOD 2011.07.14 東都）高木 記事行の追加 START
			if(iＣＳＶエントリー形式 == 2){
				switch(nCol - 1){
				case (int)形式１.輸送商品１:
					nCol = (int)形式２.輸送商品１ + 1;
					break;
				case (int)形式１.輸送商品２:
					nCol = (int)形式２.輸送商品２ + 1;
					break;
				case (int)形式１.品名記事１:
					nCol = (int)形式２.品名記事１ + 1;
					break;
				case (int)形式１.品名記事２:
					nCol = (int)形式２.品名記事２ + 1;
					break;
				case (int)形式１.品名記事３:
					nCol = (int)形式２.品名記事３ + 1;
					break;
				}
			}
// MOD 2011.07.14 東都）高木 記事行の追加 END
			axGT取込データ一覧.set_CelText((short)nRow, (short)nCol, message);
		}
// ADD 2008.04.11 ACT Vista対応 END
// MOD 2009.11.25 東都）高木 時間指定チェックの追加 START
		private void 時間指定チェック(int iCnt, string sData, int iHourMin, int iHourMax)
		{
			if(sData.Length != 9){
//				エラー出力(iCnt, 16, "輸送商品２の時間指定の文字の長さに誤りがあります\r\n");
				エラー出力(iCnt, 16, "輸送商品２の時間指定に誤りがあります["+sData+"]\r\n");
				return;
			}
			if(!sData.Substring(6,1).Equals("時")){
//				エラー出力(iCnt, 16, "輸送商品２の時間指定の時刻に誤りがあります[時]\r\n");
				エラー出力(iCnt, 16, "輸送商品２の時間指定に誤りがあります["+sData+"]\r\n");
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
				エラー出力(iCnt, 16, "輸送商品２の時間指定の時刻に誤りがあります["+s時間+"]\r\n");
				return;
			}
		}
// MOD 2009.11.25 東都）高木 時間指定チェックの追加 END
	}
}
