using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Text;

namespace IS2Client
{
	/// <summary>
	/// ご依頼主取込
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// ADD 2008.04.23 東都）高木 固定長ファイルのエラーファイル出力対応 
	// ＡＣＴ）山本殿より障害報告有
	// 現象：固定長ファイル取込時、エラーがあるにもかかわらずＤＢが更新される
	// 原因：固定長ファイルへの対応もれ
	// ADD 2008.04.11 ACT Vista対応 
	// ADD 2008.05.15 ACT Vista対応（エラー件数表示） 
	//--------------------------------------------------------------------------
	// MOD 2009.04.06 東都）高木 先頭行無視機能の追加 
	// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 
	// MOD 2009.12.01 東都）高木 データ登録時のエラーチェックを追加 
	//--------------------------------------------------------------------------
	// MOD 2010.03.12 東都）高木 １００００件チェック解除機能の追加 
	// MOD 2010.03.30 東都）高木 電話番号形式追加対応 
	// MOD 2010.03.30 東都）高木 携帯電話対応 
	// MOD 2010.04.26 東都）高木 １００００件チェック機能の変更 
	// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 
	// MOD 2010.05.11 東都）高木 行数表示の障害修正 
	// MOD 2010.11.25 東都）高木 GetAsyncKeyStateの訂正 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない 
	//--------------------------------------------------------------------------
	// MOD 2015.05.13 BEVAS) 前田 王子会員様は王子マスタで郵便番号存在チェックを行う
	//--------------------------------------------------------------------------
	public class ご依頼主取込 : 共通フォーム
	{
		private string fileName = "";
		private int i登録件数		= 0;
		private int iエラー件数		= 0;
		private int iシート総件数	= 0;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab日時;
		private System.Windows.Forms.Label labお客様名;
		private System.Windows.Forms.Label lab利用部門;
		private System.Windows.Forms.TextBox texお客様名;
		private System.Windows.Forms.TextBox tex利用部門;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.Label labご依頼主取込;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label labファイル名;
		private IS2Client.共通テキストボックス texファイル名;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn開く;
		private System.Windows.Forms.Button btn取込;
		private System.Windows.Forms.TextBox texデータエラー;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblエラー件数;
		private System.Windows.Forms.Label lbl取込件数;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblシート総件数;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox cBox先頭行無視;
		private System.Windows.Forms.Label lab注釈重量;
		private System.Windows.Forms.OpenFileDialog ofdご依頼主データ;

		public ご依頼主取込()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ご依頼主取込));
			this.panel6 = new System.Windows.Forms.Panel();
			this.texお客様名 = new System.Windows.Forms.TextBox();
			this.labお客様名 = new System.Windows.Forms.Label();
			this.lab利用部門 = new System.Windows.Forms.Label();
			this.tex利用部門 = new System.Windows.Forms.TextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab日時 = new System.Windows.Forms.Label();
			this.labご依頼主取込 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.texメッセージ = new System.Windows.Forms.TextBox();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lab注釈重量 = new System.Windows.Forms.Label();
			this.cBox先頭行無視 = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.lblシート総件数 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lbl取込件数 = new System.Windows.Forms.Label();
			this.lblエラー件数 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.texデータエラー = new System.Windows.Forms.TextBox();
			this.btn取込 = new System.Windows.Forms.Button();
			this.labファイル名 = new System.Windows.Forms.Label();
			this.texファイル名 = new IS2Client.共通テキストボックス();
			this.btn開く = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.ofdご依頼主データ = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).BeginInit();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox2.SuspendLayout();
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
			this.lab利用部門.Location = new System.Drawing.Point(18, 8);
			this.lab利用部門.Name = "lab利用部門";
			this.lab利用部門.Size = new System.Drawing.Size(54, 14);
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
			this.panel7.Controls.Add(this.labご依頼主取込);
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
			// labご依頼主取込
			// 
			this.labご依頼主取込.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.labご依頼主取込.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labご依頼主取込.ForeColor = System.Drawing.Color.White;
			this.labご依頼主取込.Location = new System.Drawing.Point(12, 2);
			this.labご依頼主取込.Name = "labご依頼主取込";
			this.labご依頼主取込.Size = new System.Drawing.Size(264, 24);
			this.labご依頼主取込.TabIndex = 0;
			this.labご依頼主取込.Text = "ご依頼主取込";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.texメッセージ);
			this.panel8.Controls.Add(this.btn閉じる);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 14;
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
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lab注釈重量);
			this.groupBox2.Controls.Add(this.cBox先頭行無視);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.lblシート総件数);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.lbl取込件数);
			this.groupBox2.Controls.Add(this.lblエラー件数);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.texデータエラー);
			this.groupBox2.Controls.Add(this.btn取込);
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
			this.lab注釈重量.Location = new System.Drawing.Point(402, 62);
			this.lab注釈重量.Name = "lab注釈重量";
			this.lab注釈重量.Size = new System.Drawing.Size(242, 28);
			this.lab注釈重量.TabIndex = 58;
			this.lab注釈重量.Text = "（※重量・才数の入力はできません\n　　重量・才数の値は「0」で取り込みます）";
			// 
			// cBox先頭行無視
			// 
			this.cBox先頭行無視.ForeColor = System.Drawing.Color.LimeGreen;
			this.cBox先頭行無視.Location = new System.Drawing.Point(136, 62);
			this.cBox先頭行無視.Name = "cBox先頭行無視";
			this.cBox先頭行無視.Size = new System.Drawing.Size(196, 24);
			this.cBox先頭行無視.TabIndex = 2;
			this.cBox先頭行無視.Text = "先頭１行目は取り込まない";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label5.ForeColor = System.Drawing.Color.Red;
			this.label5.Location = new System.Drawing.Point(136, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(576, 16);
			this.label5.TabIndex = 57;
			this.label5.Text = "CSVファイルを選択してください（※ご依頼主の請求先は、あらかじめ登録されている必要があります）";
			// 
			// lblシート総件数
			// 
			this.lblシート総件数.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lblシート総件数.ForeColor = System.Drawing.Color.Black;
			this.lblシート総件数.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblシート総件数.Location = new System.Drawing.Point(232, 344);
			this.lblシート総件数.Name = "lblシート総件数";
			this.lblシート総件数.Size = new System.Drawing.Size(64, 14);
			this.lblシート総件数.TabIndex = 52;
			this.lblシート総件数.Text = "0件";
			this.lblシート総件数.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label4.ForeColor = System.Drawing.Color.LimeGreen;
			this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label4.Location = new System.Drawing.Point(136, 344);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 14);
			this.label4.TabIndex = 50;
			this.label4.Text = "総件数：";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbl取込件数
			// 
			this.lbl取込件数.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lbl取込件数.ForeColor = System.Drawing.Color.Black;
			this.lbl取込件数.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lbl取込件数.Location = new System.Drawing.Point(464, 344);
			this.lbl取込件数.Name = "lbl取込件数";
			this.lbl取込件数.Size = new System.Drawing.Size(48, 14);
			this.lbl取込件数.TabIndex = 49;
			this.lbl取込件数.Text = "0件";
			this.lbl取込件数.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblエラー件数
			// 
			this.lblエラー件数.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lblエラー件数.ForeColor = System.Drawing.Color.Black;
			this.lblエラー件数.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblエラー件数.Location = new System.Drawing.Point(592, 344);
			this.lblエラー件数.Name = "lblエラー件数";
			this.lblエラー件数.Size = new System.Drawing.Size(48, 14);
			this.lblエラー件数.TabIndex = 48;
			this.lblエラー件数.Text = "0件";
			this.lblエラー件数.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label3.ForeColor = System.Drawing.Color.LimeGreen;
			this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label3.Location = new System.Drawing.Point(528, 344);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 14);
			this.label3.TabIndex = 47;
			this.label3.Text = "エラー件数：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label2.ForeColor = System.Drawing.Color.LimeGreen;
			this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label2.Location = new System.Drawing.Point(400, 344);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 14);
			this.label2.TabIndex = 46;
			this.label2.Text = "取込件数：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// texデータエラー
			// 
			this.texデータエラー.BackColor = System.Drawing.SystemColors.Window;
			this.texデータエラー.Location = new System.Drawing.Point(136, 94);
			this.texデータエラー.Multiline = true;
			this.texデータエラー.Name = "texデータエラー";
			this.texデータエラー.ReadOnly = true;
			this.texデータエラー.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.texデータエラー.Size = new System.Drawing.Size(504, 240);
			this.texデータエラー.TabIndex = 4;
			this.texデータエラー.Text = "";
			this.texデータエラー.WordWrap = false;
			// 
			// btn取込
			// 
			this.btn取込.BackColor = System.Drawing.Color.SteelBlue;
			this.btn取込.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn取込.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn取込.ForeColor = System.Drawing.Color.White;
			this.btn取込.Location = new System.Drawing.Point(650, 64);
			this.btn取込.Name = "btn取込";
			this.btn取込.Size = new System.Drawing.Size(65, 22);
			this.btn取込.TabIndex = 3;
			this.btn取込.TabStop = false;
			this.btn取込.Text = "取込";
			this.btn取込.Click += new System.EventHandler(this.btn取込_Click);
			// 
			// labファイル名
			// 
			this.labファイル名.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labファイル名.ForeColor = System.Drawing.Color.LimeGreen;
			this.labファイル名.Location = new System.Drawing.Point(72, 40);
			this.labファイル名.Name = "labファイル名";
			this.labファイル名.Size = new System.Drawing.Size(60, 14);
			this.labファイル名.TabIndex = 15;
			this.labファイル名.Text = "ファイル名";
			// 
			// texファイル名
			// 
			this.texファイル名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texファイル名.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.texファイル名.Location = new System.Drawing.Point(136, 32);
			this.texファイル名.MaxLength = 100;
			this.texファイル名.Name = "texファイル名";
			this.texファイル名.Size = new System.Drawing.Size(504, 23);
			this.texファイル名.TabIndex = 0;
			this.texファイル名.Text = "";
			// 
			// btn開く
			// 
			this.btn開く.BackColor = System.Drawing.Color.SteelBlue;
			this.btn開く.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn開く.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn開く.ForeColor = System.Drawing.Color.White;
			this.btn開く.Location = new System.Drawing.Point(650, 32);
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
			// ofdご依頼主データ
			// 
			this.ofdご依頼主データ.FileOk += new System.ComponentModel.CancelEventHandler(this.ofご依頼主データ_FileOk);
			// 
			// ご依頼主取込
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
			this.Name = "ご依頼主取込";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 ご依頼主取込";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
			this.Load += new System.EventHandler(this.ご依頼主取込_Load);
			this.Closed += new System.EventHandler(this.ご依頼主取込_Closed);
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		private void ご依頼主取込_Load(object sender, System.EventArgs e)
		{
			// ヘッダー項目の設定
			texお客様名.Text = gs利用者名;
			tex利用部門.Text = gs部門ＣＤ + " " + gs部門名;

			// 日時の初期設定
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled = true;

			// デフォルトのフォルダをデスクトップフォルダにする
			ofdご依頼主データ.InitialDirectory
				= Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			ofdご依頼主データ.Filter = "ファイル (*.csv;*.dat)|*.csv;*.dat|すべて(*.*)|*.*";
			lbl取込件数.Text="0件";
			lblエラー件数.Text="0件";
			lblシート総件数.Text="0件";
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
			lbl取込件数.Refresh();
			lblエラー件数.Refresh();
			lblシート総件数.Refresh();
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
			if(gs重量入力制御 == "1"){
				lab注釈重量.Visible = false;
			}else{
				lab注釈重量.Visible = true;
			}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
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
			ofdご依頼主データ.ShowDialog();
		}

		private void ofご依頼主データ_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			texファイル名.Text = ofdご依頼主データ.FileName;
		}

		private void btn取込_Click(object sender, System.EventArgs e)
		{
			texメッセージ.Text = "";
			texデータエラー.Text = "";
			fileName = texファイル名.Text;
			if(fileName.Trim().Length == 0) return;
			if(!System.IO.File.Exists(fileName)){
				ビープ音();
				texメッセージ.Text = "指定したファイルが存在しません。";
				return;
			}

// MOD 2010.04.26 東都）高木 １００００件チェック機能の変更 START
// MOD 2010.11.25 東都）高木 GetAsyncKeyStateの訂正 START
//			bool bAltKey   = (GetAsyncKeyState(Keys.Menu    ) == 0) ? false : true;
//			bool bShiftKey = (GetAsyncKeyState(Keys.ShiftKey) == 0) ? false : true;
			bool bAltKey   = ((GetAsyncKeyState(Keys.Menu) & 0x8000) == 0) ? false : true;
			bool bShiftKey = ((GetAsyncKeyState(Keys.ShiftKey) & 0x8000) == 0) ? false : true;
// MOD 2010.11.25 東都）高木 GetAsyncKeyStateの訂正 END
			if(bAltKey && bShiftKey){
				;
			}else{
				texメッセージ.Text = "データ件数チェック中．．．";
				int iDataCnt = 0;
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				StreamReader sr = null;
				try{
					string sData = null;
					sr = new StreamReader(fileName, System.Text.Encoding.Default);
					sData = sr.ReadLine();
					if( cBox先頭行無視.Checked ){
						sData = sr.ReadLine();
					}
					while(sData != null){
						string[] sValue = sData.Replace("\"", "").Replace("\'","").Split(',');
						//１項目目が"荷送人コード"以外ならデータとみなす
						if(!sValue[0].Equals("荷送人コード")){
							iDataCnt++;
						}
						sData = sr.ReadLine();
					}
				}catch (Exception ex){
					ビープ音();
					MessageBox.Show(ex.Message,"ご依頼主取込",MessageBoxButtons.OK);
					return;
				}finally{
					texメッセージ.Text = "";
					Cursor = System.Windows.Forms.Cursors.Default;
					if(sr != null) sr.Close();
				}
				if(iDataCnt == 0){
					ビープ音();
					MessageBox.Show("データ件数が０件です。"
									, "ご依頼主取込", MessageBoxButtons.OK);
					return;
				}
				// １万件を超えれば、１０００件チェック
				if(iDataCnt > 10000){
					ビープ音();
					MessageBox.Show("CSV取込可能最大件数（10000件）を超えています。\n"
									+ "数回に分けて取込を行って下さい。\n"
									, "ご依頼主取込", MessageBoxButtons.OK);
					return;
				}
			}

			texメッセージ.Text = "実行中．．．";

			ＣＳＶファイル取込();
		}

		private void ＣＳＶファイル取込()
		{
			StringBuilder sbErr = new StringBuilder();

			Cursor = System.Windows.Forms.Cursors.AppStarting;
			StreamReader sr = null;
			try{
				sr = new StreamReader(fileName, System.Text.Encoding.Default);
			}catch (Exception ex){
				texメッセージ.Text = "";
				Cursor = System.Windows.Forms.Cursors.Default;
				MessageBox.Show(ex.Message,"ご依頼主取込",MessageBoxButtons.OK);
				return;
			}
			String errfileName = fileName + ".err";
			StreamWriter sw    = null;
			int iLenErrMsg     = 0;
			int iLenErrMsgOld  = 0;
			i登録件数		= 0;
			iエラー件数		= 0;
			iシート総件数		= 0;
			bool iErrorFlg   = true;
			bool iTxtMsgDsp  = true;

			int iCnt = 0;
			int iLineCnt = 0;
			int iSetCnt = 0; 
			try
			{
// MOD 2015.05.13 BEVAS) 前田 王子会員様は王子マスタで郵便番号存在チェックを行う START
				if (gs会員ＣＤ.Substring(0,1) != "J") 
				{
// MOD 2015.05.13 BEVAS) 前田 王子会員様は王子マスタでチェックを行う END
					if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
// MOD 2015.05.13 BEVAS) 前田 王子会員様は王子マスタで郵便番号存在チェックを行う START
				} 
				else 
				{
					if(sv_oji == null) sv_oji = new is2oji.Service1();
				}
// MOD 2015.05.13 BEVAS) 前田 王子会員様は王子マスタで郵便番号存在チェックを行う END

				while(true)
				{
					string sData = sr.ReadLine();
 					if(sData == null)break;
					if(sData != null)iCnt++;
					if(sData != null)iLineCnt++;

					if(iCnt == 1 && cBox先頭行無視.Checked){
						sData = sr.ReadLine();
 						if(sData == null)break;
						if(sData != null)iLineCnt++;
					}

					ArrayList alKey = new ArrayList();
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
					string[] saData = new string[101];
					int[]    iaData = new int[101];
					int iサーバ送信行 = 1;
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
					while(sData != null)
					{

						byte[] bSjis = Encoding.GetEncoding("shift-jis").GetBytes(sData);

						string[] sValue = sData.Replace("\"", "").Replace("\'","").Split(',');
						//１行目の１項目目が"ご依頼主コード"ならばヘッダとみなし読み飛ばします
						if(iCnt == 1 && sValue.Length > 0 && sValue[0].Equals("荷送人コード")){
							sData = sr.ReadLine();
							if(sData == null)break;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
							if(sData != null)iLineCnt++;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
							continue;
						}

// ADD 2008.04.11 ACT Vista対応 START
						string sErr = "";
						string sHData = sData;
						iErrorFlg = true;
						if (!漢字変換_CSV(ref sHData, ref sErr))
						{
							sbErr.Append(iLineCnt + "行目:Vista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							iLenErrMsg = sbErr.ToString().Trim().Length;
							iLenErrMsgOld = iLenErrMsg;
							sw = エラーファイル出力(sw, errfileName, sData);
							if(sw == null) return;
							sData = sr.ReadLine();
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
//							iCnt++;
							if(sData != null)iCnt++;
							if(sData != null)iLineCnt++;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
							iエラー件数++;
							iErrorFlg = false;
							continue;
						}
						bSjis = Encoding.GetEncoding("shift-jis").GetBytes(sHData);
						sValue = sHData.Replace("\"", "").Replace("\'","").Split(',');
// ADD 2008.04.11 ACT Vista対応 END

						iErrorFlg = true;
						if(sValue.Length < 14 || sValue.Length > 15){
							sbErr.Append(iLineCnt + "行目:項目数または、データ長が違います\r\n");
							iLenErrMsg = sbErr.ToString().Trim().Length;
							iLenErrMsgOld = iLenErrMsg;
							sw = エラーファイル出力(sw, errfileName, sData);
							if(sw == null) return;
							sData = sr.ReadLine();
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
//							iCnt++;
							if(sData != null)iCnt++;
							if(sData != null)iLineCnt++;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
							iエラー件数++;
							iErrorFlg = false;
							continue;
						}

						string[] sKey = new string[21];
						sKey[0] = gs会員ＣＤ;
						sKey[1] = gs部門ＣＤ;

						//荷送人コード
						sValue[0] = sValue[0].Trim();
						if (!必須チェック(sValue[0])){
							sbErr.Append(iLineCnt + "行目:荷送人コードは必須項目です\r\n");
							iErrorFlg = false;
						}
						if (!半角チェック(sValue[0])){
							sbErr.Append(iLineCnt + "行目:荷送人コードは半角文字で入力してください\r\n");
							iErrorFlg = false;
						}
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
						if(!記号チェック(sValue[0])){
							sbErr.Append(iLineCnt + "行目:荷送人コードに使用できない記号があります\r\n");
							iErrorFlg = false;
						}
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
						sKey[2] = sValue[0];
						if (sKey[2].Length > 15){
							sbErr.Append(iLineCnt + "行目:荷送人コードは１５文字以内で入力してください\r\n");
							iErrorFlg = false;
						}
						//電話番号
						sKey[3] = " ";
						sKey[4] = " ";
						sKey[5] = " ";
						sValue[1] = sValue[1].Trim();
						if (!必須チェック(sValue[1]))
						{
							sbErr.Append(iLineCnt + "行目:電話番号は必須項目です\r\n");
							iErrorFlg = false;
						}
						if (!半角チェック(sValue[1])) 
						{
							sbErr.Append(iLineCnt + "行目:電話番号は半角文字で入力してください\r\n");
							iErrorFlg = false;
						}
						try
						{
							sValue[1] = sValue[1].Replace(" ", "");
							if (sValue[1].Length > 0)
							{
								//カッコ[()]がない時
								if (sValue[1].IndexOf("(") == -1 && sValue[1].LastIndexOf(")") == -1)
								{
									// ハイフン[-]が１つの時
									if (sValue[1].IndexOf("-") == sValue[1].LastIndexOf("-") && sValue[1].IndexOf("-") != -1)
									{
										sKey[3] = " ";
										sKey[4] = sValue[1].Substring(0, sValue[1].IndexOf("-"));
										sKey[5] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
										if (!数値チェック(sKey[4]) || !数値チェック(sKey[5]))
										{
											sbErr.Append(iLineCnt + "行目:電話番号は数値で入力してください\r\n");
											iErrorFlg = false;
										}
									}
									// ハイフン[-]が２つ以上の時
									else if (sValue[1].IndexOf("-") != sValue[1].LastIndexOf("-") && sValue[1].IndexOf("-") != -1)
									{
										sKey[3] = sValue[1].Substring(0, sValue[1].IndexOf("-"));
										sKey[4] = sValue[1].Substring(sValue[1].IndexOf("-") + 1, sValue[1].LastIndexOf("-") - sValue[1].IndexOf("-") - 1);
										sKey[5] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
										if (!数値チェック(sKey[3]) || !数値チェック(sKey[4]) || !数値チェック(sKey[5]))
										{
											sbErr.Append(iLineCnt + "行目:電話番号は数値で入力してください\r\n");
											iErrorFlg = false;
										}
									}
// MOD 2010.03.30 東都）高木 電話番号形式追加対応 START
									// ハイフンが無い時
									// 電話番号が９桁の時
									else if(sValue[1].Length == 9){
										if (sValue[1].Substring(0,1).Equals("3") || sValue[1].Substring(0,1).Equals("6")){
											//東京、大阪は 1-4-4で編集
											sKey[3] = sValue[1].Substring(0,1);
											sKey[4] = sValue[1].Substring(1,4);
											sKey[5] = sValue[1].Substring(5,4);
										}else{
											//それ以外は3-2-4で編集
											sKey[3] = sValue[1].Substring(0,3);
											sKey[4] = sValue[1].Substring(3,2);
											sKey[5] = sValue[1].Substring(5,4);
										}
										if(!数値チェック(sKey[3]) || !数値チェック(sKey[4]) || !数値チェック(sKey[5])){
											sbErr.Append(iLineCnt + "行目:電話番号は数値で入力してください\r\n");
											iErrorFlg = false;
										}
									// 電話番号が１０桁の時
									}else if(sValue[1].Length == 10){
										if(sValue[1].Substring(0,2).Equals("03") || sValue[1].Substring(0,2).Equals("06")){
											//東京、大阪は 2-4-4で編集
											sKey[3] = sValue[1].Substring(0,2);
											sKey[4] = sValue[1].Substring(2,4);
											sKey[5] = sValue[1].Substring(6,4);
										}else{
											//それ以外は4-2-4で編集
											sKey[3] = sValue[1].Substring(0,4);
											sKey[4] = sValue[1].Substring(4,2);
											sKey[5] = sValue[1].Substring(6,4);
										}
										if(!数値チェック(sKey[3]) || !数値チェック(sKey[4]) || !数値チェック(sKey[5])){
											sbErr.Append(iLineCnt + "行目:電話番号は数値で入力してください\r\n");
											iErrorFlg = false;
										}
									// 電話番号が１１桁の時
									}else if(sValue[1].Length == 11){
// MOD 2010.03.30 東都）高木 携帯電話対応 START
										if(sValue[1].Substring(0,3).Equals("090")
										 || sValue[1].Substring(0,3).Equals("080")
										 || sValue[1].Substring(0,3).Equals("070")
										 || sValue[1].Substring(0,3).Equals("050")){
											//携帯電話は 3-4-4で編集
											sKey[3] = sValue[1].Substring(0,3);
											sKey[4] = sValue[1].Substring(3,4);
											sKey[5] = sValue[1].Substring(7,4);
										}else{
// MOD 2010.03.30 東都）高木 携帯電話対応 END
											//4-3-4で編集
											sKey[3] = sValue[1].Substring(0,4);
											sKey[4] = sValue[1].Substring(4,3);
											sKey[5] = sValue[1].Substring(7,4);
											if(!数値チェック(sKey[3]) || !数値チェック(sKey[4]) || !数値チェック(sKey[5])){
												sbErr.Append(iLineCnt + "行目:電話番号は数値で入力してください\r\n");
												iErrorFlg = false;
											}
// MOD 2010.03.30 東都）高木 携帯電話対応 START
										}
// MOD 2010.03.30 東都）高木 携帯電話対応 END
									// 電話番号が１２桁の時
									}else if(sValue[1].Length == 12){
										//4-4-4で編集
										sKey[3] = sValue[1].Substring(0,4);
										sKey[4] = sValue[1].Substring(4,4);
										sKey[5] = sValue[1].Substring(8,4);
										if(!数値チェック(sKey[3]) || !数値チェック(sKey[4]) || !数値チェック(sKey[5])){
											sbErr.Append(iLineCnt + "行目:電話番号は数値で入力してください\r\n");
											iErrorFlg = false;
										}
									}
// MOD 2010.03.30 東都）高木 電話番号形式追加対応 END
									else
									{
										sbErr.Append(iLineCnt + "行目:電話番号の形式に誤りがあります\r\n");
										iErrorFlg = false;
									}
								}
								//カッコ[()]がある時
								else if (sValue[1].IndexOf("(") != -1 && sValue[1].LastIndexOf(")") != -1)
								{
									sKey[3] = sValue[1].Substring(sValue[1].IndexOf("(") + 1, sValue[1].LastIndexOf(")") - sValue[1].IndexOf("(") - 1);
									sKey[4] = sValue[1].Substring(sValue[1].IndexOf(")") + 1, sValue[1].LastIndexOf("-") - sValue[1].IndexOf(")") - 1);
									sKey[5] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
									if (!数値チェック(sKey[3]) || !数値チェック(sKey[4]) || !数値チェック(sKey[5]))
									{
										sbErr.Append(iLineCnt + "行目:電話番号は数値で入力してください\r\n");
										iErrorFlg = false;
									}							
								}
								else
								{
									sbErr.Append(iLineCnt + "行目:電話番号の形式に誤りがあります\r\n");
									iErrorFlg = false;
								}
								if (sKey[3].Length > 6)	
								{
									sbErr.Append(iLineCnt + "行目:電話番号(市外)は６文字以内で入力してください\r\n");
									iErrorFlg = false;
								}
								if (sKey[4].Length > 4)	
								{
									sbErr.Append(iLineCnt + "行目:電話番号(市内)は４文字以内で入力してください\r\n");
									iErrorFlg = false;
								}
								if (sKey[5].Length > 4)							
								{
									sbErr.Append(iLineCnt + "行目:電話番号(番号)は４文字以内で入力してください\r\n");
									iErrorFlg = false;
								}
							}
						}
						catch
						{
							sbErr.Append(iLineCnt + "行目:電話番号の形式に誤りがあります\r\n");
							iErrorFlg = false;
						}

						//住所１
						if (!必須チェック(sValue[2])){
							sbErr.Append(iLineCnt + "行目:住所１は必須項目です\r\n");
							iErrorFlg = false;
						}
						sKey[6] = Microsoft.VisualBasic.Strings.StrConv(sValue[2], Microsoft.VisualBasic.VbStrConv.Wide, 0);
						if (sKey[6].Length > 20) sKey[6] = sKey[6].Substring(0, 20);
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
						if(gsオプション[18].Equals("1")){
							sKey[6] = sKey[6].TrimEnd();
						}else{
							sKey[6] = sKey[6].Trim();
						}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
						//住所２
						if (sValue[3].Trim().Length != 0){
							sKey[7] = Microsoft.VisualBasic.Strings.StrConv(sValue[3], Microsoft.VisualBasic.VbStrConv.Wide, 0);
							if (sKey[7].Length > 20) sKey[7] = sKey[7].Substring(0, 20);
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
							if(gsオプション[18].Equals("1")){
								sKey[7] = sKey[7].TrimEnd();
							}else{
								sKey[7] = sKey[7].Trim();
							}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
						}
						if (sKey[7] == null || sKey[7].Length == 0) sKey[7] = " ";
						//住所３（予約１、未使用）
						if (sValue[4].Trim().Length != 0){
							sKey[8] = Microsoft.VisualBasic.Strings.StrConv(sValue[4], Microsoft.VisualBasic.VbStrConv.Wide, 0);
							if (sKey[8].Length > 20) sKey[8] = sKey[8].Substring(0, 20);
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
							if(gsオプション[18].Equals("1")){
								sKey[8] = sKey[8].TrimEnd();
							}else{
								sKey[8] = sKey[8].Trim();
							}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
						}
						if (sKey[8] == null || sKey[8].Length == 0) sKey[8] = " ";

						//名前１
						if (!必須チェック(sValue[5])){
							sbErr.Append(iLineCnt + "行目:名前１は必須項目です\r\n");
							iErrorFlg = false;
						}
						sKey[9] = Microsoft.VisualBasic.Strings.StrConv(sValue[5], Microsoft.VisualBasic.VbStrConv.Wide, 0);
						if (sKey[9].Length > 20) sKey[9] = sKey[9].Substring(0, 20);
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
						if(gsオプション[18].Equals("1")){
							sKey[9] = sKey[9].TrimEnd();
						}else{
							sKey[9] = sKey[9].Trim();
						}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
						sKey[10] = " ";
						//名前２
						if (sValue[6].Trim().Length != 0){
							sKey[10] = Microsoft.VisualBasic.Strings.StrConv(sValue[6], Microsoft.VisualBasic.VbStrConv.Wide, 0);
							if (sKey[10].Length > 20) sKey[10] = sKey[10].Substring(0, 20);
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
							if(gsオプション[18].Equals("1")){
								sKey[10] = sKey[10].TrimEnd();
							}else{
								sKey[10] = sKey[10].Trim();
							}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
						}
						if (sKey[10] == null || sKey[10].Length == 0) sKey[10] = " ";
						sKey[11] = " ";
						//名前３（予約２、未使用）
						if (sValue[7].Trim().Length != 0){
							sKey[11] = Microsoft.VisualBasic.Strings.StrConv(sValue[7], Microsoft.VisualBasic.VbStrConv.Wide, 0);
							if (sKey[11].Length > 20) sKey[11] = sKey[11].Substring(0, 20);
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
							if(gsオプション[18].Equals("1")){
								sKey[11] = sKey[11].TrimEnd();
							}else{
								sKey[11] = sKey[11].Trim();
							}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
						}
						if (sKey[11] == null || sKey[11].Length == 0) sKey[11] = " ";

						//郵便番号
						sKey[12] = " ";
						sValue[8] = sValue[8].Trim();
						sKey[12] = sValue[8].Replace("-", "");
						if (!必須チェック(sKey[12])){
							sbErr.Append(iLineCnt + "行目:郵便番号は必須項目です\r\n");
							iErrorFlg = false;
						}
						if (sKey[12].Length > 0){
							if (sKey[12].Length > 7){
								sbErr.Append(iLineCnt + "行目:郵便番号は７文字以内で入力してください\r\n");
								iErrorFlg = false;
							}
						}
						if (sKey[12].Length == 0) sKey[12] = " ";

						//カナ略称
						sKey[13] = " ";
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//						sValue[9] = sValue[9].Trim();
//						if (sValue[9].Trim().Length != 0){
						if(gsオプション[18].Equals("1")){
							sValue[9] = sValue[9].TrimEnd();
						}else{
							sValue[9] = sValue[9].Trim();
						}
						if (sValue[9].Length != 0){
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
							if (!半角チェック(sValue[9])){
								sbErr.Append(iLineCnt + "行目:カナ略称は半角文字で入力してください\r\n");
								iErrorFlg = false;
							}
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
//							if(!記号チェック(sValue[9])){
//								sbErr.Append(iLineCnt + "行目:カナ略称に使用できない記号があります\r\n");
//								iErrorFlg = false;
//							}
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
						}
						sKey[13] = sValue[9];
						if (sKey[13].Length > 10){
							sbErr.Append(iLineCnt + "行目:カナ略称は１０文字以内で入力してください\r\n");
							iErrorFlg = false;
						}
						if (sKey[13].Length == 0) sKey[13] = " ";

						//才数
						sValue[10] = sValue[10].Trim();
						if (sValue[10].Length == 0) sValue[10] = "0";
						if (!数値チェック(sValue[10])){
							sbErr.Append(iLineCnt + "行目:才数は数値で入力してください\r\n");
							iErrorFlg = false;
						}
						if (sValue[10].Trim().Length > 3){
							sbErr.Append(iLineCnt + "行目:才数は３桁以内で入力してください\r\n");
							iErrorFlg = false;
						}
						sKey[14] = sValue[10];
						
						//重量
						sValue[11] = sValue[11].Trim();
						if (sValue[11].Length == 0) sValue[11] = "0";
						if (!数値チェック(sValue[11])){
							sbErr.Append(iLineCnt + "行目:重量は数値で入力してください\r\n");
							iErrorFlg = false;
						}
						if (sValue[11].Trim().Length > 4){
							sbErr.Append(iLineCnt + "行目:重量は４桁以内で入力してください\r\n");
							iErrorFlg = false;
						}
						sKey[15] = sValue[11];

						//メールアドレス
						sKey[16] = " ";
						sValue[12] = sValue[12].Trim();
						if (!半角チェック(sValue[12])){
							sbErr.Append(iLineCnt + "行目:メールアドレスは半角文字で入力してください\r\n");
							iErrorFlg = false;
						}
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
//						if(!記号チェック(sValue[12])){
//							sbErr.Append(iLineCnt + "行目:メールアドレスに使用できない記号があります\r\n");
//							iErrorFlg = false;
//						}
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
						sKey[16] = sValue[12];
						if (sKey[16].Length > 45){
							sbErr.Append(iLineCnt + "行目:メールアドレスは４５文字以内で入力してください\r\n");
							iErrorFlg = false;
						}
						if (sKey[16].Length == 0) sKey[16] = " ";

						//請求先コード
						sKey[17] = " ";
						sKey[17] = sValue[13].Trim();
						if (sKey[17].Length == 0) sKey[17] = " ";

						//請求先部署コード
						sKey[18] = " ";
						if(sValue.Length > 14){
							sKey[18] = sValue[14].Trim();
						}
						if (sKey[18].Length == 0) sKey[18] = " ";

						sKey[19] = "ご依取込";
						sKey[20] = gs利用者ＣＤ;

						//
						//チェックが終了した時にエラーメッセージが増加していれば
						//その行は、再度編集対象になるのでエラーファイルに出力する
						//（iErrorFlgは？、おそらく山本殿により追加されたフラグで
						//　大量に追加する為、コメントを省略したはず...）
						//
						iLenErrMsg = sbErr.ToString().Trim().Length;
						if(iLenErrMsg != iLenErrMsgOld){
							iLenErrMsgOld = iLenErrMsg;
							sw = エラーファイル出力(sw, errfileName, sData);
							if(sw == null) return;
						}else{
							StringBuilder sbKeyData = new StringBuilder();
							for (int j = 0; j < sKey.Length; j++){
								sbKeyData.Append(sKey[j] + ",");
							}
							alKey.Add(sbKeyData.ToString().Substring(0, sbKeyData.ToString().Length - 1));
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
							saData[iサーバ送信行] = sData;
							iaData[iサーバ送信行] = iLineCnt;
							iサーバ送信行++;
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
						}

						if(iErrorFlg == false){
							iエラー件数++;
							lblエラー件数.Text=iエラー件数.ToString()+"件";
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
							lblエラー件数.Refresh();
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
							iErrorFlg = true;
						}else{
							iSetCnt++;
							// １００件ごとに登録
							if(iSetCnt >= 100){
								break;
							}
						}

// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
						iシート総件数 = iCnt;
						lblシート総件数.Text=iシート総件数.ToString()+"件";
						lblシート総件数.Refresh();
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END

						sData = sr.ReadLine();
						if(sData != null)iCnt++;
						if(sData != null)iLineCnt++;
					}

					if (alKey.Count > 0)
					{
						string[] sList = new string[alKey.Count];
						IEnumerator enumList = alKey.GetEnumerator();
						int i = 0;
						while(enumList.MoveNext()){
							sList[i] = enumList.Current.ToString();
							i++;
						}
						string[] sRet = {""};
						try{
// MOD 2015.05.15 BEVAS)前田 王子会員様は王子郵便番号マスタで存在チェック START
							if (gs会員ＣＤ.Substring(0,1) != "J")
							{
// MOD 2015.05.15 BEVAS)前田 王子会員様は王子郵便番号マスタで存在チェック END						
								sRet = sv_goirai.Ins_uploadData2(gsaユーザ,sList);
// MOD 2015.05.15 BEVAS)前田 王子会員様は王子郵便番号マスタで存在チェック START
							} 
							else 
							{
								sRet = sv_oji.goirai_Ins_uploadData2(gsaユーザ,sList);
							}
// MOD 2015.05.15 BEVAS)前田 王子会員様は王子郵便番号マスタで存在チェック END


							//登録時にエラーが発生した場合終了する
							if(sRet[0].Length > 0)
							{
								texメッセージ.Text = sRet[0];
								iTxtMsgDsp  = false;
								break;
							}

							int	iLine2 = 1;
							for(int iRetLine2 = 1; iRetLine2 < sRet.Length; iRetLine2+=2){
								if(sRet[iRetLine2].Length > 0 || sRet[iRetLine2+1].Length > 0){
									iエラー件数++;
									iSetCnt--;
									if(sRet[iRetLine2].Length > 0){
										sbErr.Append(iaData[iLine2] + "行目:郵便番号["+sRet[iRetLine2]+"]が存在しません\r\n");
									}
									if(sRet[iRetLine2+1].Length > 0){
										sbErr.Append(iaData[iLine2] + "行目:請求先["+sRet[iRetLine2+1]+"]が存在しません\r\n");
									}
									iLenErrMsg = sbErr.ToString().Trim().Length;
									if(iLenErrMsg != iLenErrMsgOld){
										iLenErrMsgOld = iLenErrMsg;
									}
									sw = エラーファイル出力(sw, errfileName, saData[iLine2]);
									if(sw == null) return;
								}
								iLine2++;
							}
						}catch (System.Net.WebException){
							sRet[0] = gs通信エラー;
							texメッセージ.Text = sRet[0];
							iTxtMsgDsp = false;
							break;
						}catch (Exception ex){
							sRet[0] = "通信エラー：" + ex.Message;
							texメッセージ.Text = sRet[0];
							iTxtMsgDsp = false;
							break;
						}
						i登録件数 += iSetCnt;
						lbl取込件数.Text=i登録件数.ToString()+"件";
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
						lbl取込件数.Refresh();

						lblエラー件数.Text=iエラー件数.ToString()+"件";
						lblエラー件数.Refresh();
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
						alKey = null;
						enumList = null;
						iSetCnt = 0;
					}
 					if(sData == null){
						break;
					}
				}
			}
			catch (Exception ex)
			{
				sbErr.Append(ex.Message);
			}
			finally
			{
				sr.Close();
				if(sw != null) sw.Close();
			}
			texデータエラー.Text = sbErr.ToString();
			Cursor = System.Windows.Forms.Cursors.Default;

			lbl取込件数.Text=i登録件数.ToString()+"件";
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
			lblエラー件数.Text=iエラー件数.ToString()+"件";
			iシート総件数 = iCnt;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
			if(iシート総件数 < 0) iシート総件数 = 0;
			lblシート総件数.Text=iシート総件数.ToString()+"件";
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
			lbl取込件数.Refresh();
			lblエラー件数.Refresh();
			lblシート総件数.Refresh();
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
			if(iTxtMsgDsp == true)
				texメッセージ.Text = "";

			if(iエラー件数 == 0 && iシート総件数 == 0){
				MessageBox.Show("取込データが存在しませんでした。"
								,"ご依頼主取込",MessageBoxButtons.OK);
			}else{
				if(i登録件数 == 0){
					MessageBox.Show("エラーが発生した為、取り込めませんでした。"
									,"ご依頼主取込",MessageBoxButtons.OK);
				}else if(iエラー件数 > 0 || iシート総件数 != i登録件数){
					MessageBox.Show("エラーが発生した為、取り込めなかったデータがあります。"
									,"ご依頼主取込",MessageBoxButtons.OK);
				}else{
					MessageBox.Show("取込処理が完了しました。"
									,"ご依頼主取込",MessageBoxButtons.OK);
				}
			}
		}

		private StreamWriter エラーファイル出力(StreamWriter sw, String errfileName, String sData)
		{
			if(sw == null){
				try
				{
					sw = new StreamWriter(errfileName, false, System.Text.Encoding.Default);
				}
				catch (Exception ex)
				{
					texメッセージ.Text = "";
					Cursor = System.Windows.Forms.Cursors.Default;
					MessageBox.Show(ex.Message,"ご依頼主取込",MessageBoxButtons.OK);
					return null;
				}
			}
			sw.WriteLine(sData);
			return sw;
		}

		private void ご依頼主取込_Closed(object sender, System.EventArgs e)
		{
			texファイル名.Text   = " ";
			texデータエラー.Text = "";
			texメッセージ.Text   = "";
			texファイル名.Focus();
		}
	}
}
