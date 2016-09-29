using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [お届け先登録]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 
	// ADD 2008.10.16 kcl)森本 着店コード存在チェック追加 
	// ADD 2008.10.17 東都）高木 着店コードチェック機能不可視化 
	// MOD 2008.11.12 東都）高木 住所ＣＤの自動設定を行わない
	//--------------------------------------------------------------------------
	// DEL 2009.02.02 東都）高木 着店コードチェック機能可視化
	// MOD 2009.08.20 パソ）藤井 郵便番号の値引継ぎ 
	//--------------------------------------------------------------------------
	// MOD 2010.09.22 東都）高木 ＣＳＶ出力：[キャンセル]選択時の障害修正 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない 
	// MOD 2011.01.25 東都）高木 「ロードに失敗」対応 
	// MOD 2011.12.08 東都）高木 住所・名前の半角入力可 
	//--------------------------------------------------------------------------
    // MOD 2015.05.07 BEVAS) 前田　王子郵便番号マスタ存在チェック対応
	//--------------------------------------------------------------------------
	// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応
	//--------------------------------------------------------------------------

	public class お届け先登録 : 共通フォーム
	{
// ADD 2007.02.13 東都）高木 ORA-00921および排他エラー対応 START
//		private string sIUFlg;
//		private string sUpday;
		private string s更新日時 = "";
// ADD 2007.02.13 東都）高木 ORA-00921および排他エラー対応 END
		private string s届け先ＣＤ;

		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab日時;
		private System.Windows.Forms.Button btn届け先検索;
		private 共通テキストボックス tex届け先コード;
		private System.Windows.Forms.Label lab届け先登録タイトル;
		private 共通テキストボックス texカナ略称;
		private 共通テキストボックス tex電話番号１;
		private 共通テキストボックス texメール;
		private 共通テキストボックス tex特殊計;
		private 共通テキストボックス tex名前２;
		private 共通テキストボックス tex名前１;
		private 共通テキストボックス tex住所３;
		private 共通テキストボックス tex郵便番号２;
		private 共通テキストボックス tex郵便番号１;
		private 共通テキストボックス tex電話番号３;
		private 共通テキストボックス tex電話番号２;
		private 共通テキストボックス tex住所２;
		private 共通テキストボックス tex住所１;
		private System.Windows.Forms.Button btn届け先実行;
		private System.Windows.Forms.TextBox texお客様名;
		private System.Windows.Forms.Label lab利用部門;
		private System.Windows.Forms.TextBox tex利用部門;
		private System.Windows.Forms.Button btn住所検索;
		private System.Windows.Forms.Label labメール;
		private System.Windows.Forms.Label labカナ略称;
		private System.Windows.Forms.Label lab特殊計;
		private System.Windows.Forms.Label lab名前;
		private System.Windows.Forms.Label lab住所;
		private System.Windows.Forms.Label lab郵便番号;
		private System.Windows.Forms.Label lab電話番号;
		private System.Windows.Forms.Label lab届け先コード;
		private System.Windows.Forms.Label labお客様名;
		private System.Windows.Forms.Button btn一覧表;
		private System.Windows.Forms.Button btn削除;
		private System.Windows.Forms.Button btn取消;
		private System.Windows.Forms.Button btn更新;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnＣＳＶ出力;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Label lbl荷主総件数;
		private System.Windows.Forms.Button btn件数取得;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label lab住所コード;
		private System.Windows.Forms.Label lab着店コード;
		private IS2Client.共通テキストボックス tex住所コード;
		private IS2Client.共通テキストボックス tex着店コード;
		private System.Windows.Forms.Label lab住所コード注釈;
		private System.Windows.Forms.Label lab着店コード注釈;
		private System.Windows.Forms.Button btn支店止め;
		private System.Windows.Forms.Button btn支店止め解除;
		private System.ComponentModel.IContainer components;

		public お届け先登録()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
			ＤＰＩ表示サイズ変換();
// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 END
// ADD 2008.10.17 東都）高木 着店コードチェック機能不可視化 START
// DEL 2009.02.02 東都）高木 着店コードチェック機能可視化 START
//			lab住所コード.Visible = false;
//			lab着店コード.Visible = false;
//			tex住所コード.Visible = false;
//			tex着店コード.Visible = false;
// DEL 2009.02.02 東都）高木 着店コードチェック機能可視化 END
// ADD 2008.10.17 東都）高木 着店コードチェック機能不可視化 END
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(お届け先登録));
			this.texカナ略称 = new IS2Client.共通テキストボックス();
			this.tex電話番号１ = new IS2Client.共通テキストボックス();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.labメール = new System.Windows.Forms.Label();
			this.texメール = new IS2Client.共通テキストボックス();
			this.label1 = new System.Windows.Forms.Label();
			this.labカナ略称 = new System.Windows.Forms.Label();
			this.tex特殊計 = new IS2Client.共通テキストボックス();
			this.lab特殊計 = new System.Windows.Forms.Label();
			this.tex名前２ = new IS2Client.共通テキストボックス();
			this.lab名前 = new System.Windows.Forms.Label();
			this.tex名前１ = new IS2Client.共通テキストボックス();
			this.btn住所検索 = new System.Windows.Forms.Button();
			this.tex住所３ = new IS2Client.共通テキストボックス();
			this.lab住所 = new System.Windows.Forms.Label();
			this.tex郵便番号２ = new IS2Client.共通テキストボックス();
			this.tex郵便番号１ = new IS2Client.共通テキストボックス();
			this.label8 = new System.Windows.Forms.Label();
			this.lab郵便番号 = new System.Windows.Forms.Label();
			this.tex電話番号３ = new IS2Client.共通テキストボックス();
			this.tex電話番号２ = new IS2Client.共通テキストボックス();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lab電話番号 = new System.Windows.Forms.Label();
			this.tex住所２ = new IS2Client.共通テキストボックス();
			this.tex住所１ = new IS2Client.共通テキストボックス();
			this.btn届け先検索 = new System.Windows.Forms.Button();
			this.btn届け先実行 = new System.Windows.Forms.Button();
			this.lab届け先コード = new System.Windows.Forms.Label();
			this.tex届け先コード = new IS2Client.共通テキストボックス();
			this.panel6 = new System.Windows.Forms.Panel();
			this.texお客様名 = new System.Windows.Forms.TextBox();
			this.labお客様名 = new System.Windows.Forms.Label();
			this.lab利用部門 = new System.Windows.Forms.Label();
			this.tex利用部門 = new System.Windows.Forms.TextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab日時 = new System.Windows.Forms.Label();
			this.lab届け先登録タイトル = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btnＣＳＶ出力 = new System.Windows.Forms.Button();
			this.btn削除 = new System.Windows.Forms.Button();
			this.btn取消 = new System.Windows.Forms.Button();
			this.btn更新 = new System.Windows.Forms.Button();
			this.texメッセージ = new System.Windows.Forms.TextBox();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.btn一覧表 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn支店止め解除 = new System.Windows.Forms.Button();
			this.btn支店止め = new System.Windows.Forms.Button();
			this.lab着店コード注釈 = new System.Windows.Forms.Label();
			this.lab住所コード注釈 = new System.Windows.Forms.Label();
			this.lab着店コード = new System.Windows.Forms.Label();
			this.lab住所コード = new System.Windows.Forms.Label();
			this.tex着店コード = new IS2Client.共通テキストボックス();
			this.tex住所コード = new IS2Client.共通テキストボックス();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btn件数取得 = new System.Windows.Forms.Button();
			this.lbl荷主総件数 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).BeginInit();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// texカナ略称
			// 
			this.texカナ略称.BackColor = System.Drawing.SystemColors.Window;
			this.texカナ略称.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texカナ略称.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
			this.texカナ略称.Location = new System.Drawing.Point(134, 192);
			this.texカナ略称.MaxLength = 10;
			this.texカナ略称.Name = "texカナ略称";
			this.texカナ略称.Size = new System.Drawing.Size(110, 23);
			this.texカナ略称.TabIndex = 15;
			this.texカナ略称.Text = "";
			// 
			// tex電話番号１
			// 
			this.tex電話番号１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex電話番号１.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex電話番号１.Location = new System.Drawing.Point(134, 16);
			this.tex電話番号１.MaxLength = 6;
			this.tex電話番号１.Name = "tex電話番号１";
			this.tex電話番号１.Size = new System.Drawing.Size(56, 23);
			this.tex電話番号１.TabIndex = 1;
			this.tex電話番号１.Text = "";
			// 
			// label9
			// 
			this.label9.ForeColor = System.Drawing.Color.Red;
			this.label9.Location = new System.Drawing.Point(30, 148);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(16, 14);
			this.label9.TabIndex = 52;
			this.label9.Text = "※";
			// 
			// label7
			// 
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(30, 72);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(16, 14);
			this.label7.TabIndex = 51;
			this.label7.Text = "※";
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(30, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 14);
			this.label3.TabIndex = 50;
			this.label3.Text = "※";
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(30, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 14);
			this.label2.TabIndex = 49;
			this.label2.Text = "※";
			// 
			// labメール
			// 
			this.labメール.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labメール.ForeColor = System.Drawing.Color.LimeGreen;
			this.labメール.Location = new System.Drawing.Point(44, 250);
			this.labメール.Name = "labメール";
			this.labメール.Size = new System.Drawing.Size(70, 14);
			this.labメール.TabIndex = 48;
			this.labメール.Text = "メールアドレス";
			// 
			// texメール
			// 
			this.texメール.BackColor = System.Drawing.SystemColors.Window;
			this.texメール.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texメール.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.texメール.Location = new System.Drawing.Point(134, 244);
			this.texメール.MaxLength = 45;
			this.texメール.Name = "texメール";
			this.texメール.Size = new System.Drawing.Size(330, 23);
			this.texメール.TabIndex = 47;
			this.texメール.Text = "";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 334);
			this.label1.TabIndex = 44;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labカナ略称
			// 
			this.labカナ略称.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labカナ略称.ForeColor = System.Drawing.Color.LimeGreen;
			this.labカナ略称.Location = new System.Drawing.Point(44, 198);
			this.labカナ略称.Name = "labカナ略称";
			this.labカナ略称.Size = new System.Drawing.Size(70, 14);
			this.labカナ略称.TabIndex = 42;
			this.labカナ略称.Text = "カナ略称";
			// 
			// tex特殊計
			// 
			this.tex特殊計.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex特殊計.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex特殊計.Location = new System.Drawing.Point(134, 218);
			this.tex特殊計.MaxLength = 5;
			this.tex特殊計.Name = "tex特殊計";
			this.tex特殊計.Size = new System.Drawing.Size(56, 23);
			this.tex特殊計.TabIndex = 16;
			this.tex特殊計.Text = "";
			// 
			// lab特殊計
			// 
			this.lab特殊計.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab特殊計.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab特殊計.Location = new System.Drawing.Point(44, 224);
			this.lab特殊計.Name = "lab特殊計";
			this.lab特殊計.Size = new System.Drawing.Size(70, 14);
			this.lab特殊計.TabIndex = 37;
			this.lab特殊計.Text = "特殊計";
			// 
			// tex名前２
			// 
			this.tex名前２.BackColor = System.Drawing.SystemColors.Window;
			this.tex名前２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex名前２.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex名前２.Location = new System.Drawing.Point(134, 166);
			this.tex名前２.MaxLength = 20;
			this.tex名前２.Name = "tex名前２";
			this.tex名前２.Size = new System.Drawing.Size(330, 23);
			this.tex名前２.TabIndex = 14;
			this.tex名前２.Text = "";
			// 
			// lab名前
			// 
			this.lab名前.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab名前.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab名前.Location = new System.Drawing.Point(44, 148);
			this.lab名前.Name = "lab名前";
			this.lab名前.Size = new System.Drawing.Size(70, 14);
			this.lab名前.TabIndex = 24;
			this.lab名前.Text = "名前";
			// 
			// tex名前１
			// 
			this.tex名前１.BackColor = System.Drawing.SystemColors.Window;
			this.tex名前１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex名前１.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex名前１.Location = new System.Drawing.Point(134, 142);
			this.tex名前１.MaxLength = 20;
			this.tex名前１.Name = "tex名前１";
			this.tex名前１.Size = new System.Drawing.Size(330, 23);
			this.tex名前１.TabIndex = 13;
			this.tex名前１.Text = "";
			// 
			// btn住所検索
			// 
			this.btn住所検索.BackColor = System.Drawing.Color.SteelBlue;
			this.btn住所検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn住所検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn住所検索.ForeColor = System.Drawing.Color.White;
			this.btn住所検索.Location = new System.Drawing.Point(222, 42);
			this.btn住所検索.Name = "btn住所検索";
			this.btn住所検索.Size = new System.Drawing.Size(48, 22);
			this.btn住所検索.TabIndex = 9;
			this.btn住所検索.TabStop = false;
			this.btn住所検索.Text = "検索";
			this.btn住所検索.Click += new System.EventHandler(this.btn住所検索_Click);
			// 
			// tex住所３
			// 
			this.tex住所３.BackColor = System.Drawing.SystemColors.Window;
			this.tex住所３.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex住所３.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex住所３.Location = new System.Drawing.Point(134, 116);
			this.tex住所３.MaxLength = 20;
			this.tex住所３.Name = "tex住所３";
			this.tex住所３.Size = new System.Drawing.Size(330, 23);
			this.tex住所３.TabIndex = 12;
			this.tex住所３.Text = "";
			// 
			// lab住所
			// 
			this.lab住所.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab住所.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab住所.Location = new System.Drawing.Point(44, 72);
			this.lab住所.Name = "lab住所";
			this.lab住所.Size = new System.Drawing.Size(70, 14);
			this.lab住所.TabIndex = 19;
			this.lab住所.Text = "住所";
			// 
			// tex郵便番号２
			// 
			this.tex郵便番号２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex郵便番号２.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex郵便番号２.Location = new System.Drawing.Point(180, 42);
			this.tex郵便番号２.MaxLength = 4;
			this.tex郵便番号２.Name = "tex郵便番号２";
			this.tex郵便番号２.Size = new System.Drawing.Size(40, 23);
			this.tex郵便番号２.TabIndex = 8;
			this.tex郵便番号２.Text = "";
			this.tex郵便番号２.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex郵便番号２_KeyDown);
			this.tex郵便番号２.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex郵便番号２_KeyPress);
			// 
			// tex郵便番号１
			// 
			this.tex郵便番号１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex郵便番号１.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex郵便番号１.Location = new System.Drawing.Point(134, 42);
			this.tex郵便番号１.MaxLength = 3;
			this.tex郵便番号１.Name = "tex郵便番号１";
			this.tex郵便番号１.Size = new System.Drawing.Size(32, 23);
			this.tex郵便番号１.TabIndex = 7;
			this.tex郵便番号１.Text = "";
			this.tex郵便番号１.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex郵便番号１_KeyPress);
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label8.ForeColor = System.Drawing.Color.LimeGreen;
			this.label8.Location = new System.Drawing.Point(166, 48);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(12, 14);
			this.label8.TabIndex = 17;
			this.label8.Text = "－";
			// 
			// lab郵便番号
			// 
			this.lab郵便番号.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab郵便番号.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab郵便番号.Location = new System.Drawing.Point(44, 48);
			this.lab郵便番号.Name = "lab郵便番号";
			this.lab郵便番号.Size = new System.Drawing.Size(70, 14);
			this.lab郵便番号.TabIndex = 15;
			this.lab郵便番号.Text = "郵便番号";
			// 
			// tex電話番号３
			// 
			this.tex電話番号３.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex電話番号３.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex電話番号３.Location = new System.Drawing.Point(260, 16);
			this.tex電話番号３.MaxLength = 4;
			this.tex電話番号３.Name = "tex電話番号３";
			this.tex電話番号３.Size = new System.Drawing.Size(40, 23);
			this.tex電話番号３.TabIndex = 3;
			this.tex電話番号３.Text = "";
			// 
			// tex電話番号２
			// 
			this.tex電話番号２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex電話番号２.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex電話番号２.Location = new System.Drawing.Point(206, 16);
			this.tex電話番号２.MaxLength = 4;
			this.tex電話番号２.Name = "tex電話番号２";
			this.tex電話番号２.Size = new System.Drawing.Size(40, 23);
			this.tex電話番号２.TabIndex = 2;
			this.tex電話番号２.Text = "";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label6.ForeColor = System.Drawing.Color.LimeGreen;
			this.label6.Location = new System.Drawing.Point(246, 22);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(12, 14);
			this.label6.TabIndex = 13;
			this.label6.Text = "－";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label5.ForeColor = System.Drawing.Color.LimeGreen;
			this.label5.Location = new System.Drawing.Point(190, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(12, 14);
			this.label5.TabIndex = 11;
			this.label5.Text = "）";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label4.ForeColor = System.Drawing.Color.LimeGreen;
			this.label4.Location = new System.Drawing.Point(124, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(10, 14);
			this.label4.TabIndex = 10;
			this.label4.Text = "（";
			// 
			// lab電話番号
			// 
			this.lab電話番号.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab電話番号.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab電話番号.Location = new System.Drawing.Point(44, 22);
			this.lab電話番号.Name = "lab電話番号";
			this.lab電話番号.Size = new System.Drawing.Size(63, 14);
			this.lab電話番号.TabIndex = 9;
			this.lab電話番号.Text = "電話番号";
			// 
			// tex住所２
			// 
			this.tex住所２.BackColor = System.Drawing.SystemColors.Window;
			this.tex住所２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex住所２.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex住所２.Location = new System.Drawing.Point(134, 92);
			this.tex住所２.MaxLength = 20;
			this.tex住所２.Name = "tex住所２";
			this.tex住所２.Size = new System.Drawing.Size(330, 23);
			this.tex住所２.TabIndex = 11;
			this.tex住所２.Text = "";
			// 
			// tex住所１
			// 
			this.tex住所１.BackColor = System.Drawing.SystemColors.Window;
			this.tex住所１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex住所１.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex住所１.Location = new System.Drawing.Point(134, 68);
			this.tex住所１.MaxLength = 20;
			this.tex住所１.Name = "tex住所１";
			this.tex住所１.Size = new System.Drawing.Size(330, 23);
			this.tex住所１.TabIndex = 10;
			this.tex住所１.Text = "";
			// 
			// btn届け先検索
			// 
			this.btn届け先検索.BackColor = System.Drawing.Color.SteelBlue;
			this.btn届け先検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn届け先検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn届け先検索.ForeColor = System.Drawing.Color.White;
			this.btn届け先検索.Location = new System.Drawing.Point(282, 14);
			this.btn届け先検索.Name = "btn届け先検索";
			this.btn届け先検索.Size = new System.Drawing.Size(64, 22);
			this.btn届け先検索.TabIndex = 1;
			this.btn届け先検索.TabStop = false;
			this.btn届け先検索.Text = "アドレス帳";
			this.btn届け先検索.Click += new System.EventHandler(this.btn届け先検索_Click);
			// 
			// btn届け先実行
			// 
			this.btn届け先実行.BackColor = System.Drawing.Color.SteelBlue;
			this.btn届け先実行.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn届け先実行.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn届け先実行.ForeColor = System.Drawing.Color.White;
			this.btn届け先実行.Location = new System.Drawing.Point(348, 14);
			this.btn届け先実行.Name = "btn届け先実行";
			this.btn届け先実行.Size = new System.Drawing.Size(48, 22);
			this.btn届け先実行.TabIndex = 2;
			this.btn届け先実行.TabStop = false;
			this.btn届け先実行.Text = "実行";
			this.btn届け先実行.Click += new System.EventHandler(this.btn届け先実行_Click);
			// 
			// lab届け先コード
			// 
			this.lab届け先コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab届け先コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab届け先コード.Location = new System.Drawing.Point(6, 18);
			this.lab届け先コード.Name = "lab届け先コード";
			this.lab届け先コード.Size = new System.Drawing.Size(104, 16);
			this.lab届け先コード.TabIndex = 6;
			this.lab届け先コード.Text = "お届け先コード";
			// 
			// tex届け先コード
			// 
			this.tex届け先コード.BackColor = System.Drawing.SystemColors.Window;
			this.tex届け先コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex届け先コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex届け先コード.Location = new System.Drawing.Point(112, 14);
			this.tex届け先コード.MaxLength = 15;
			this.tex届け先コード.Name = "tex届け先コード";
			this.tex届け先コード.Size = new System.Drawing.Size(166, 23);
			this.tex届け先コード.TabIndex = 0;
			this.tex届け先コード.Text = "";
			this.tex届け先コード.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex届け先コード_KeyDown);
			this.tex届け先コード.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex届け先コード_KeyPress);
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
			this.panel7.Controls.Add(this.lab届け先登録タイトル);
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
			// lab届け先登録タイトル
			// 
			this.lab届け先登録タイトル.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab届け先登録タイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab届け先登録タイトル.ForeColor = System.Drawing.Color.White;
			this.lab届け先登録タイトル.Location = new System.Drawing.Point(12, 2);
			this.lab届け先登録タイトル.Name = "lab届け先登録タイトル";
			this.lab届け先登録タイトル.Size = new System.Drawing.Size(264, 24);
			this.lab届け先登録タイトル.TabIndex = 0;
			this.lab届け先登録タイトル.Text = "お届け先登録";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btnＣＳＶ出力);
			this.panel8.Controls.Add(this.btn削除);
			this.panel8.Controls.Add(this.btn取消);
			this.panel8.Controls.Add(this.btn更新);
			this.panel8.Controls.Add(this.texメッセージ);
			this.panel8.Controls.Add(this.btn閉じる);
			this.panel8.Controls.Add(this.btn一覧表);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 17;
			// 
			// btnＣＳＶ出力
			// 
			this.btnＣＳＶ出力.ForeColor = System.Drawing.Color.Blue;
			this.btnＣＳＶ出力.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnＣＳＶ出力.Location = new System.Drawing.Point(378, 6);
			this.btnＣＳＶ出力.Name = "btnＣＳＶ出力";
			this.btnＣＳＶ出力.Size = new System.Drawing.Size(62, 48);
			this.btnＣＳＶ出力.TabIndex = 54;
			this.btnＣＳＶ出力.Text = "ＣＳＶ　　出力";
			this.btnＣＳＶ出力.Click += new System.EventHandler(this.btnＣＳＶ出力_Click);
			// 
			// btn削除
			// 
			this.btn削除.ForeColor = System.Drawing.Color.Blue;
			this.btn削除.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn削除.Location = new System.Drawing.Point(238, 6);
			this.btn削除.Name = "btn削除";
			this.btn削除.Size = new System.Drawing.Size(62, 48);
			this.btn削除.TabIndex = 52;
			this.btn削除.Text = "削除";
			this.btn削除.Click += new System.EventHandler(this.btn削除_Click);
			// 
			// btn取消
			// 
			this.btn取消.ForeColor = System.Drawing.Color.Blue;
			this.btn取消.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn取消.Location = new System.Drawing.Point(168, 6);
			this.btn取消.Name = "btn取消";
			this.btn取消.Size = new System.Drawing.Size(62, 48);
			this.btn取消.TabIndex = 51;
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
			this.btn更新.TabIndex = 50;
			this.btn更新.Text = "保存";
			this.btn更新.Click += new System.EventHandler(this.btn更新_Click);
			// 
			// texメッセージ
			// 
			this.texメッセージ.BackColor = System.Drawing.Color.PaleGreen;
			this.texメッセージ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texメッセージ.ForeColor = System.Drawing.Color.Red;
			this.texメッセージ.Location = new System.Drawing.Point(448, 4);
			this.texメッセージ.Multiline = true;
			this.texメッセージ.Name = "texメッセージ";
			this.texメッセージ.ReadOnly = true;
			this.texメッセージ.Size = new System.Drawing.Size(342, 50);
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
			// btn一覧表
			// 
			this.btn一覧表.BackColor = System.Drawing.Color.PaleGreen;
			this.btn一覧表.ForeColor = System.Drawing.Color.Blue;
			this.btn一覧表.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn一覧表.Location = new System.Drawing.Point(308, 6);
			this.btn一覧表.Name = "btn一覧表";
			this.btn一覧表.Size = new System.Drawing.Size(60, 48);
			this.btn一覧表.TabIndex = 53;
			this.btn一覧表.Text = "一覧表　印刷";
			this.btn一覧表.Click += new System.EventHandler(this.btn一覧表_Click);
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btn支店止め解除);
			this.groupBox1.Controls.Add(this.btn支店止め);
			this.groupBox1.Controls.Add(this.lab着店コード注釈);
			this.groupBox1.Controls.Add(this.texメール);
			this.groupBox1.Controls.Add(this.tex住所１);
			this.groupBox1.Controls.Add(this.tex住所２);
			this.groupBox1.Controls.Add(this.lab電話番号);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.tex電話番号２);
			this.groupBox1.Controls.Add(this.tex電話番号３);
			this.groupBox1.Controls.Add(this.lab郵便番号);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.tex郵便番号１);
			this.groupBox1.Controls.Add(this.tex郵便番号２);
			this.groupBox1.Controls.Add(this.lab住所);
			this.groupBox1.Controls.Add(this.tex住所３);
			this.groupBox1.Controls.Add(this.btn住所検索);
			this.groupBox1.Controls.Add(this.tex名前１);
			this.groupBox1.Controls.Add(this.lab名前);
			this.groupBox1.Controls.Add(this.tex名前２);
			this.groupBox1.Controls.Add(this.lab特殊計);
			this.groupBox1.Controls.Add(this.texカナ略称);
			this.groupBox1.Controls.Add(this.labカナ略称);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.labメール);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.tex電話番号１);
			this.groupBox1.Controls.Add(this.tex特殊計);
			this.groupBox1.Controls.Add(this.lab住所コード注釈);
			this.groupBox1.Controls.Add(this.lab着店コード);
			this.groupBox1.Controls.Add(this.lab住所コード);
			this.groupBox1.Controls.Add(this.tex着店コード);
			this.groupBox1.Controls.Add(this.tex住所コード);
			this.groupBox1.Location = new System.Drawing.Point(22, 96);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(624, 342);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			// 
			// btn支店止め解除
			// 
			this.btn支店止め解除.BackColor = System.Drawing.Color.SteelBlue;
			this.btn支店止め解除.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn支店止め解除.ForeColor = System.Drawing.Color.White;
			this.btn支店止め解除.Location = new System.Drawing.Point(272, 42);
			this.btn支店止め解除.Name = "btn支店止め解除";
			this.btn支店止め解除.Size = new System.Drawing.Size(78, 22);
			this.btn支店止め解除.TabIndex = 60;
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
			this.btn支店止め.Location = new System.Drawing.Point(272, 42);
			this.btn支店止め.Name = "btn支店止め";
			this.btn支店止め.Size = new System.Drawing.Size(52, 22);
			this.btn支店止め.TabIndex = 59;
			this.btn支店止め.TabStop = false;
			this.btn支店止め.Text = "支店止";
			this.btn支店止め.Click += new System.EventHandler(this.btn支店止め_Click);
			// 
			// lab着店コード注釈
			// 
			this.lab着店コード注釈.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab着店コード注釈.ForeColor = System.Drawing.Color.Red;
			this.lab着店コード注釈.Location = new System.Drawing.Point(270, 300);
			this.lab着店コード注釈.Name = "lab着店コード注釈";
			this.lab着店コード注釈.Size = new System.Drawing.Size(150, 14);
			this.lab着店コード注釈.TabIndex = 58;
			this.lab着店コード注釈.Text = "←通常は入力しないで下さい";
			// 
			// lab住所コード注釈
			// 
			this.lab住所コード注釈.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab住所コード注釈.ForeColor = System.Drawing.Color.Red;
			this.lab住所コード注釈.Location = new System.Drawing.Point(270, 274);
			this.lab住所コード注釈.Name = "lab住所コード注釈";
			this.lab住所コード注釈.Size = new System.Drawing.Size(150, 14);
			this.lab住所コード注釈.TabIndex = 57;
			this.lab住所コード注釈.Text = "←通常は入力しないで下さい";
			// 
			// lab着店コード
			// 
			this.lab着店コード.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab着店コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab着店コード.Location = new System.Drawing.Point(44, 302);
			this.lab着店コード.Name = "lab着店コード";
			this.lab着店コード.Size = new System.Drawing.Size(70, 14);
			this.lab着店コード.TabIndex = 54;
			this.lab着店コード.Text = "着店コード";
			// 
			// lab住所コード
			// 
			this.lab住所コード.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab住所コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab住所コード.Location = new System.Drawing.Point(44, 276);
			this.lab住所コード.Name = "lab住所コード";
			this.lab住所コード.Size = new System.Drawing.Size(70, 14);
			this.lab住所コード.TabIndex = 53;
			this.lab住所コード.Text = "住所コード";
			// 
			// tex着店コード
			// 
			this.tex着店コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex着店コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex着店コード.Location = new System.Drawing.Point(134, 296);
			this.tex着店コード.MaxLength = 4;
			this.tex着店コード.Name = "tex着店コード";
			this.tex着店コード.Size = new System.Drawing.Size(42, 23);
			this.tex着店コード.TabIndex = 56;
			this.tex着店コード.Text = "";
			// 
			// tex住所コード
			// 
			this.tex住所コード.BackColor = System.Drawing.SystemColors.Window;
			this.tex住所コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex住所コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex住所コード.Location = new System.Drawing.Point(134, 270);
			this.tex住所コード.MaxLength = 16;
			this.tex住所コード.Name = "tex住所コード";
			this.tex住所コード.Size = new System.Drawing.Size(136, 23);
			this.tex住所コード.TabIndex = 55;
			this.tex住所コード.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btn件数取得);
			this.groupBox2.Controls.Add(this.lbl荷主総件数);
			this.groupBox2.Controls.Add(this.tex届け先コード);
			this.groupBox2.Controls.Add(this.lab届け先コード);
			this.groupBox2.Controls.Add(this.btn届け先実行);
			this.groupBox2.Controls.Add(this.btn届け先検索);
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Location = new System.Drawing.Point(44, 56);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(602, 44);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			// 
			// btn件数取得
			// 
			this.btn件数取得.BackColor = System.Drawing.Color.SteelBlue;
			this.btn件数取得.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn件数取得.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn件数取得.ForeColor = System.Drawing.Color.White;
			this.btn件数取得.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btn件数取得.Location = new System.Drawing.Point(402, 14);
			this.btn件数取得.Name = "btn件数取得";
			this.btn件数取得.Size = new System.Drawing.Size(104, 22);
			this.btn件数取得.TabIndex = 45;
			this.btn件数取得.TabStop = false;
			this.btn件数取得.Text = "お届け先総件数：";
			this.btn件数取得.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btn件数取得.Click += new System.EventHandler(this.btn件数取得_Click);
			// 
			// lbl荷主総件数
			// 
			this.lbl荷主総件数.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lbl荷主総件数.ForeColor = System.Drawing.Color.Black;
			this.lbl荷主総件数.Location = new System.Drawing.Point(514, 14);
			this.lbl荷主総件数.Name = "lbl荷主総件数";
			this.lbl荷主総件数.Size = new System.Drawing.Size(74, 22);
			this.lbl荷主総件数.TabIndex = 44;
			this.lbl荷主総件数.Text = "10000 件";
			this.lbl荷主総件数.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbl荷主総件数.Visible = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Location = new System.Drawing.Point(400, 6);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(194, 34);
			this.groupBox3.TabIndex = 46;
			this.groupBox3.TabStop = false;
			// 
			// お届け先登録
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 580);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.groupBox1);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "お届け先登録";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 お届け先登録";
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 START
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Onエンター移動);
            //this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Onエンターキャンセル);
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 END
            this.Load += new System.EventHandler(this.お届け先登録_Load);
			this.Closed += new System.EventHandler(this.お届け先登録_Closed);
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
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
		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 START
			// ロックを解除
			tex郵便番号１.Enabled = true; // 郵便番号１
			tex郵便番号２.Enabled = true; // 郵便番号２
			tex住所１.Enabled = true; // 住所１
			tex住所２.Enabled = true; // 住所２
			tex住所３.Enabled = true; // 住所３

			// 支店止めボタンを表示、解除ボタンを非表示
			btn支店止め.Visible = true;
			btn支店止め解除.Visible = false;
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 END
			this.Close();
		}

		private void btn住所検索_Click(object sender, System.EventArgs e)
		{
			// 空白除去
			tex郵便番号１.Text = tex郵便番号１.Text.Trim();
			tex郵便番号２.Text = tex郵便番号２.Text.Trim();

			// 入力チェック
			if(!半角チェック(tex郵便番号１,"郵便番号１")) return;
			if(!半角チェック(tex郵便番号２,"郵便番号２")) return;

// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			住所検索 画面 = new 住所検索();
//			画面.Left = this.Left + 404;
//			画面.Top = this.Top;
//			//画面初期値の設定
//			画面.s郵便番号１ = tex郵便番号１.Text;
//			画面.s郵便番号２ = tex郵便番号２.Text;
//			画面.ShowDialog();
//			//戻り値の設定
//			if(画面.s住所ＣＤ.Length > 0)
			if (g住所検索 == null)	 g住所検索 = new 住所検索();
			g住所検索.Left = this.Left + 404;
			g住所検索.Top = this.Top;
			//画面初期値の設定
// MOD 2009.08.20 パソ）藤井　郵便番号の値引継ぎ  START
// MOD 2005.06.02 東都）小童谷 値の引継ぎなし START
			g住所検索.s郵便番号１ = tex郵便番号１.Text;
			g住所検索.s郵便番号２ = tex郵便番号２.Text;
//			g住所検索.s郵便番号１ = "";
//			g住所検索.s郵便番号２ = "";
// MOD 2005.06.02 東都）小童谷 値の引継ぎなし END
// MOD 2009.08.20 パソ）藤井　郵便番号の値引継ぎ  END
			g住所検索.s住所       = tex住所１.Text;
			g住所検索.ShowDialog();
			//戻り値の設定
			if(g住所検索.s住所ＣＤ.Length > 0)
			{
//				tex郵便番号１.Text = 画面.s郵便番号１;
//				tex郵便番号２.Text = 画面.s郵便番号２;
//				if(画面.s住所.Length > 60)
				tex郵便番号１.Text = g住所検索.s郵便番号１;
				tex郵便番号２.Text = g住所検索.s郵便番号２;
				if(g住所検索.s住所.Length > 60)
				{
//					tex住所１.Text     = 画面.s住所.Substring(0,20);
//					tex住所２.Text     = 画面.s住所.Substring(20,20);
//					tex住所３.Text     = 画面.s住所.Substring(40,20);
					tex住所１.Text     = g住所検索.s住所.Substring(0,20);
					tex住所２.Text     = g住所検索.s住所.Substring(20,20);
					tex住所３.Text     = g住所検索.s住所.Substring(40,20);
				}
//				else if(画面.s住所.Length > 40)
				else if(g住所検索.s住所.Length > 40)
				{
//					tex住所１.Text     = 画面.s住所.Substring(0,20);
//					tex住所２.Text     = 画面.s住所.Substring(20,20);
//					tex住所３.Text     = 画面.s住所.Substring(40);
					tex住所１.Text     = g住所検索.s住所.Substring(0,20);
					tex住所２.Text     = g住所検索.s住所.Substring(20,20);
					tex住所３.Text     = g住所検索.s住所.Substring(40);
				}
//				else if(画面.s住所.Length > 20)
				else if(g住所検索.s住所.Length > 20)
				{
//					tex住所１.Text     = 画面.s住所.Substring(0,20);
//					tex住所２.Text     = 画面.s住所.Substring(20);
					tex住所１.Text     = g住所検索.s住所.Substring(0,20);
					tex住所２.Text     = g住所検索.s住所.Substring(20);
					tex住所３.Text     = "";
				}
				else
				{
//					tex住所１.Text     = 画面.s住所;
					tex住所１.Text     = g住所検索.s住所;
					tex住所２.Text     = "";
					tex住所３.Text     = "";
				}
// MOD 2005.05.24 東都）小童谷 画面高速化 END
				//フォーカス設定
				tex住所２.Focus();
			}
			else
			{
				
				tex郵便番号１.Focus();
			}
		}

		private void btn届け先検索_Click(object sender, System.EventArgs e)
		{
			tex届け先コード.Text = tex届け先コード.Text.Trim();
			if(!半角チェック(tex届け先コード,"届け先コード")) return;

// MOD 2005.05.24 東都）小童谷 画面高速化 START
			// 検索画面を右側に表示する
//			お届け先検索 画面 = new お届け先検索();
//			画面.Left = this.Left + 404;
//			画面.Top = this.Top;
//			画面.Visible複写();
			// コードの初期表示
//			画面.sTcode = tex届け先コード.Text;
//			画面.ShowDialog();
			if (g届先検索 == null)	 g届先検索 = new お届け先検索();
			g届先検索.Left = this.Left;
			g届先検索.Top = this.Top;
			g届先検索.Visible複写();
// ADD 2006.07.04 東都）山本 削除＆一覧印刷＆ＣＳＶ出力機能追加 START
			g届先検索.VisibleCSV出力();
			g届先検索.Visible一覧印刷();
			g届先検索.Visible削除();
// ADD 2006.07.04 東都）山本 削除＆一覧印刷＆ＣＳＶ出力機能追加 END
			// コードの初期表示
// MOD 2005.06.02 東都）小童谷 値の引継ぎなし START
//			g届先検索.sTcode = tex届け先コード.Text;
			g届先検索.sTcode = "";
// MOD 2005.06.02 東都）小童谷 値の引継ぎなし END
			g届先検索.ShowDialog(this);
// MOD 2005.05.24 東都）小童谷 画面高速化 END

			s届け先ＣＤ = g届先検索.sTcode;
			if(s届け先ＣＤ.Length > 0)
			{
				項目クリア();
				if(g届先検索.s複写 == "T")
				{
					tex届け先コード.Text = "";
					届け先検索();
					tex届け先コード.Focus();
				}
				else
				{
					tex届け先コード.Text = s届け先ＣＤ;
					届け先検索();
					tex電話番号１.Focus();
				}
			}
			else
			{
				tex届け先コード.Focus();
			}
			// MOD 2006.07.12 東都）山本 荷主総件数の表示対応 START
			if(lbl荷主総件数.Text.Length != 0)
			{
				String[] sList1 = {""};
				sList1 = sv_otodoke.Get_ninushiCount(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
// MOD 2007.02.19 FJCS）桑田 荷主総件数の表示対応 START
//				lbl荷主総件数.Text=sList1[1].ToString()+"件";
				lbl荷主総件数.Text=sList1[1].ToString()+" 件";
// MOD 2007.02.19 FJCS）桑田 荷主総件数の表示対応 END
				lbl荷主総件数.Visible=true;
			}
			// MOD 2006.07.12 東都）山本 荷主総件数の表示対応 END

		}

		private void お届け先登録_Load(object sender, System.EventArgs e)
		{
			// ヘッダー項目の設定
			texお客様名.Text = gs利用者名;
			tex利用部門.Text = gs部門ＣＤ + " " + gs部門名;

			// 日時の初期設定
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled = true;
// ADD 2006.07.11 東都）山本 荷主総件数表示対応 START
			lbl荷主総件数.Text = "";
// ADD 2006.07.11 東都）山本 荷主総件数表示対応 END
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
			Font fGothic = new System.Drawing.Font("MS Gothic"
							, 12F
							, System.Drawing.FontStyle.Regular
							, System.Drawing.GraphicsUnit.Point
							, ((System.Byte)(128))
							);
			tex住所１.Font = fGothic;
			tex住所２.Font = fGothic;
			tex住所３.Font = fGothic;
			tex名前１.Font = fGothic;
			tex名前２.Font = fGothic;
			texカナ略称.Font = fGothic;
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

		private void btn届け先実行_Click(object sender, System.EventArgs e)
		{
			// メッセージのクリア
			texメッセージ.Text = "";
			項目クリア();

			// 空白除去
			tex届け先コード.Text = tex届け先コード.Text.Trim();

			if(!必須チェック(tex届け先コード,"届け先コード")) return;
			if(!半角チェック(tex届け先コード,"届け先コード")) return;

			s届け先ＣＤ = tex届け先コード.Text.Trim();
			届け先検索();

		}

		private void 届け先検索()
		{
			// メッセージのクリア
			texメッセージ.Text = "検索中．．．";

			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			String[] sList = {""};
			try
			{
				// 検索
				if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
// DEL 2005.05.20 東都）高木 セションコントロールの廃止 START
//				sv_otodoke.CookieContainer = cContainer;
// DEL 2005.05.20 東都）高木 セションコントロールの廃止 END
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

			if(sList[2] != null)
			{
				texカナ略称.Text   = sList[1].Trim();
				tex電話番号１.Text = sList[2].Trim();
				tex電話番号２.Text = sList[3].Trim();
				tex電話番号３.Text = sList[4].Trim();
				tex郵便番号１.Text = sList[5].Trim();
				tex郵便番号２.Text = sList[6].Trim();
				tex住所１.Text     = sList[7].Trim();
				tex住所２.Text     = sList[8].Trim();
				tex住所３.Text     = sList[9].Trim();
				tex名前１.Text     = sList[10].Trim();
				tex名前２.Text     = sList[11].Trim();
				tex特殊計.Text     = sList[12].Trim();
				texメール.Text     = sList[13].Trim();
// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 START
				tex住所コード.Text = sList[16].Trim();
				tex着店コード.Text = sList[17].Trim();
// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 END
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
				if(gsオプション[18].Equals("1")){
					texカナ略称.Text = sList[1].TrimEnd();
					tex住所１.Text   = sList[7].TrimEnd();
					tex住所２.Text   = sList[8].TrimEnd();
					tex住所３.Text   = sList[9].TrimEnd();
					tex名前１.Text   = sList[10].TrimEnd();
					tex名前２.Text   = sList[11].TrimEnd();
				}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END

// MOD 2007.02.13 東都）高木 ORA-00921および排他エラー対応 START
//				sUpday             = sList[14];
//				sIUFlg             = sList[15];
				s更新日時          = sList[14];
// MOD 2007.02.13 東都）高木 ORA-00921および排他エラー対応 END
			}
			// メッセージの表示
			texメッセージ.Text = sList[0];

			// メッセージが[登録]、[更新]の時、正常終了
			if(sList[0].Length == 2)
			{
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 START
				if(tex住所１.Text.Equals("※※支店止め※※"))
				{
					// ロック
					tex郵便番号１.Enabled = false; // 郵便番号１
					tex郵便番号２.Enabled = false; // 郵便番号２
					tex住所１.Enabled = false; // 住所１
					tex住所２.Enabled = false; // 住所２
					tex住所３.Enabled = false; // 住所３

					// 支店止めボタンを非表示、解除ボタンを表示
					btn支店止め.Visible = false;
					btn支店止め解除.Visible = true;
				}
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 END

				texメッセージ.Text = "";
				tex電話番号１.Focus();
			}
			else
			{
				// 異常終了時
				ビープ音();
				tex届け先コード.Focus();
			}
		}

		private void btn更新_Click(object sender, System.EventArgs e)
		{
			texメッセージ.Text = "";

			tex届け先コード.Text = tex届け先コード.Text.Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//			texカナ略称.Text     = texカナ略称.Text.Trim();
			if(gsオプション[18].Equals("1")){
				texカナ略称.Text = texカナ略称.Text.TrimEnd();
			}else{
				texカナ略称.Text = texカナ略称.Text.Trim();
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
			tex電話番号１.Text   = tex電話番号１.Text.Trim();
			tex電話番号２.Text   = tex電話番号２.Text.Trim();
			tex電話番号３.Text   = tex電話番号３.Text.Trim();
			tex郵便番号１.Text   = tex郵便番号１.Text.Trim();
			tex郵便番号２.Text   = tex郵便番号２.Text.Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//			tex住所１.Text       = tex住所１.Text.Trim();
//			tex住所２.Text       = tex住所２.Text.Trim();
//			tex住所３.Text       = tex住所３.Text.Trim();
//			tex名前１.Text       = tex名前１.Text.Trim();
//			tex名前２.Text       = tex名前２.Text.Trim();
			if(gsオプション[18].Equals("1")){
				tex住所１.Text   = tex住所１.Text.TrimEnd();
				tex住所２.Text   = tex住所２.Text.TrimEnd();
				tex住所３.Text   = tex住所３.Text.TrimEnd();
				tex名前１.Text   = tex名前１.Text.TrimEnd();
				tex名前２.Text   = tex名前２.Text.TrimEnd();
			}else{
				tex住所１.Text   = tex住所１.Text.Trim();
				tex住所２.Text   = tex住所２.Text.Trim();
				tex住所３.Text   = tex住所３.Text.Trim();
				tex名前１.Text   = tex名前１.Text.Trim();
				tex名前２.Text   = tex名前２.Text.Trim();
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
			tex特殊計.Text       = tex特殊計.Text.Trim();
			texメール.Text       = texメール.Text.Trim();
// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 START
			tex住所コード.Text   = tex住所コード.Text.Trim();
			tex着店コード.Text   = tex着店コード.Text.Trim();
// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 END

			if(!必須チェック(tex届け先コード,"届け先コード")) return;
			if(!必須チェック(tex電話番号１,"電話番号１")) return;
			if(!必須チェック(tex電話番号２,"電話番号２")) return;
			if(!必須チェック(tex電話番号３,"電話番号３")) return;
			if(!必須チェック(tex郵便番号１,"郵便番号１")) return;
			if(!必須チェック(tex郵便番号２,"郵便番号２")) return;
			if(!必須チェック(tex住所１,"住所１")) return;
			if(!必須チェック(tex名前１,"名前１")) return;

			if(!半角チェック(tex届け先コード,"届け先コード")) return;
			if(!半角チェック(texカナ略称,"カナ略称")) return;
			if(!数値チェック(tex電話番号１,"電話番号１")) return;
			if(!数値チェック(tex電話番号２,"電話番号２")) return;
			if(!数値チェック(tex電話番号３,"電話番号３")) return;
			if(!半角チェック(tex郵便番号１,"郵便番号１")) return;
			if(!半角チェック(tex郵便番号２,"郵便番号２")) return;
// MOD 2011.12.08 東都）高木 住所・名前の半角入力可 START
//			if(!全角チェック(tex住所１,"住所１")) return;
//			if(!全角チェック(tex住所２,"住所２")) return;
//			if(!全角チェック(tex住所３,"住所３")) return;
//			if(!全角チェック(tex名前１,"名前１")) return;
//			if(!全角チェック(tex名前２,"名前２")) return;
			if(!全角変換チェック(tex住所１,"住所１")) return;
			if(!全角変換チェック(tex住所２,"住所２")) return;
			if(!全角変換チェック(tex住所３,"住所３")) return;
			if(!全角変換チェック(tex名前１,"名前１")) return;
			if(!全角変換チェック(tex名前２,"名前２")) return;
// MOD 2011.12.08 東都）高木 住所・名前の半角入力可 END
			if(!半角チェック(tex特殊計,"特殊計")) return;
			if(!半角チェック(texメール,"メールアドレス")) return;
// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 START
			if(!半角チェック(tex住所コード,"住所コード")) return;
			if(!半角チェック(tex着店コード,"着店コード")) return;
// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 END

			//郵便番号存在チェック
			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
// MOD 2007.02.13 東都）高木 郵便番号の保存障害対応 START
			string s郵便番号 = tex郵便番号１.Text + tex郵便番号２.Text;
//保留　郵便番号マスタチェックが強化される為
//			string s郵便番号 = tex郵便番号１.Text.PadRight(3,' ') + tex郵便番号２.Text;
// MOD 2007.02.13 東都）高木 郵便番号の保存障害対応 END
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
				tex郵便番号１.Focus();
				Cursor = System.Windows.Forms.Cursors.Default;
				return;
			}
// MOD 2008.11.12 東都）高木 住所ＣＤの自動設定を行わない START
//// ADD 2006.07.10 東都）高木 住所ＣＤの追加 START
//			string s住所ＣＤ = sRet[3];
//// ADD 2006.07.10 東都）高木 住所ＣＤの追加 END
//// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 START
//			// 画面で入力されている場合は、それを優先する
//			if (tex住所コード.Text.Length > 0)
//				s住所ＣＤ = tex住所コード.Text;
//// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 END
// MOD 2008.11.12 東都）高木 住所ＣＤの自動設定を行わない END

// ADD 2008.10.16 kcl)森本 着店コード存在チェック追加 START
			if (tex着店コード.Text.Length > 0) 
			{
				// 着店コードが入力されている場合
				string [] sRetChk = new string[1];
				try
				{
					// 着店コード存在チェック
					if (sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
					sRetChk = sv_otodoke.Check_TensyoCode(gsaユーザ, tex着店コード.Text);
				}
				catch (System.Net.WebException)
				{
					sRetChk[0] = gs通信エラー;
				}
				catch (Exception ex)
				{
					sRetChk[0] = "通信エラー：" + ex.Message;
				}
				if (! sRetChk[0].Equals("正常終了")) 
				{
					texメッセージ.Text = sRetChk[0];
					ビープ音();
					tex着店コード.Focus();
					Cursor = System.Windows.Forms.Cursors.Default;
					return;
				}
			}
// ADD 2008.10.16 kcl)森本 着店コード存在チェック追加 END

// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 START
			if(tex住所１.Text.Equals("※※支店止め※※"))
			{
				/** 支店止めをする荷受人を手入力でしようとした時の考慮 */

				// 住所３の入力チェック
				if(tex住所３.Text.Trim().Equals(""))
				{
					// 住所３に何も入力されていない
					texメッセージ.Text = "支店止めは、支店止めボタンによる入力でお願い致します。";
					ビープ音();
					tex住所１.Focus();
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
					sChkList = sv_syukka.CheckCM10_GeneralDelivery(gsaユーザ, tex住所３.Text, s郵便番号);

					if(sChkList[0].Length == 4)
					{
						// 正常終了時
						tex住所２.Text = sChkList[1] + "止め";
					}
					else
					{
						// 異常終了時
						texメッセージ.Text = "支店止めは、支店止めボタンによる入力でお願い致します。";
						ビープ音();
						tex住所１.Focus();
						Cursor = System.Windows.Forms.Cursors.Default;
						return;
					}
				}
				catch (System.Net.WebException)
				{
					sChkList[0] = gs通信エラー;
					Cursor = System.Windows.Forms.Cursors.Default;
					texメッセージ.Text = sChkList[0];
					tex住所１.Focus();
					ビープ音();
					return;
				}
				catch (Exception ex)
				{
					sChkList[0] = "通信エラー：" + ex.Message;
					Cursor = System.Windows.Forms.Cursors.Default;
					texメッセージ.Text = sChkList[0];
					tex住所１.Focus();
					ビープ音();
					return;
				}
			}
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 END

			String[] sList = {""};
			try
			{
				if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
				sList = sv_otodoke.Get_Stodokesaki(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,tex届け先コード.Text);

				// カーソルをデフォルトに戻す
				Cursor = System.Windows.Forms.Cursors.Default;
//			sUpday    = sList[14];
//↑コメント削除可？
// MOD 2007.02.13 東都）高木 ORA-00921および排他エラー対応 START
//				sIUFlg    = sList[15];
				if(sList[15] == "U"){
//					if(s更新日時.Length == 0) s更新日時 = sList[14];
					s更新日時 = sList[14];
				}else{
					s更新日時 = "";
				}
// MOD 2007.02.13 東都）高木 ORA-00921および排他エラー対応 END

				String[] sIUList;
// MOD 2008.06.13 kcl)森本 着店コード検索方法の変更 START
//// MOD 2006.07.10 東都）高木 住所ＣＤの追加 START
////				string[] sData = new string[19];
//				string[] sData = new string[20];
//// MOD 2006.07.10 東都）高木 住所ＣＤの追加 END
				string[] sData = new string[21];
// MOD 2008.06.13 kcl)森本 着店コード検索方法の変更 START
				sData[0]  = tex届け先コード.Text;
				sData[1]  = texカナ略称.Text;
				sData[2]  = tex電話番号１.Text;
				sData[3]  = tex電話番号２.Text;
				sData[4]  = tex電話番号３.Text;
// MOD 2007.02.13 東都）高木 郵便番号の保存障害対応 START
//				sData[5]  = tex郵便番号１.Text;
				sData[5]  = tex郵便番号１.Text.PadRight(3,' ');
// MOD 2007.02.13 東都）高木 郵便番号の保存障害対応 END
				sData[6]  = tex郵便番号２.Text;
				sData[7]  = tex住所１.Text;
				sData[8]  = tex住所２.Text;
				sData[9]  = tex住所３.Text;
				sData[10] = tex名前１.Text;
				sData[11] = tex名前２.Text;
				sData[12] = tex特殊計.Text;
				sData[13] = texメール.Text;
				sData[14] = "お届け先";
				sData[15] = gs利用者ＣＤ;
				sData[16] = gs会員ＣＤ;
				sData[17] = gs部門ＣＤ;
// MOD 2007.02.13 東都）高木 ORA-00921および排他エラー対応 START
//				sData[18] = sUpday;
				sData[18] = s更新日時;
// MOD 2007.02.13 東都）高木 ORA-00921および排他エラー対応 END
// MOD 2008.11.12 東都）高木 住所ＣＤの自動設定を行わない START
//// ADD 2006.07.10 東都）高木 住所ＣＤの追加 START
//				sData[19] = s住所ＣＤ;
//// ADD 2006.07.10 東都）高木 住所ＣＤの追加 END
				sData[19] = tex住所コード.Text;
// MOD 2008.11.12 東都）高木 住所ＣＤの自動設定を行わない END
// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 START
				sData[20] = tex着店コード.Text;
// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 END

				//修正 NOT NULL対策 高木 Start
				for(int iCnt = 0 ; iCnt < sData.Length; iCnt++ )
				{
					if( sData[iCnt] == null 
						|| sData[iCnt].Length == 0 ) sData[iCnt] = " ";
				}
				//修正 NOT NULL対策 高木 End

				DialogResult result;
// MOD 2007.02.13 東都）高木 ORA-00921および排他エラー対応 START
//				if(sIUFlg == "I")
				if(s更新日時.Length == 0)
// MOD 2007.02.13 東都）高木 ORA-00921および排他エラー対応 END
				{
					result = MessageBox.Show("新規登録しますか？","登録",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						texメッセージ.Text = "登録中．．．";

						if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
						sIUList = sv_otodoke.Ins_todokesaki(gsaユーザ,sData);
						Cursor = System.Windows.Forms.Cursors.Default;
						// 正常終了時、画面をクリアする
						if(sIUList[0].Length == 4)
						{
							tex届け先コード.Text = "";
							項目クリア();
						}
						else
						{
							ビープ音();
							texメッセージ.Text = sIUList[0];
						}
					}
				}
				else
				{
					result = MessageBox.Show("既に存在するデータに上書きしますか？","更新",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						texメッセージ.Text = "更新中．．．";

						if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
						sIUList = sv_otodoke.Upd_todokesaki(gsaユーザ,sData);
						Cursor = System.Windows.Forms.Cursors.Default;
						// 正常終了時、画面をクリアする
						if(sIUList[0].Length == 4)
						{
							tex届け先コード.Text = "";
							項目クリア();
						}
						else
						{
							ビープ音();
							texメッセージ.Text = sIUList[0];
						}
					}
				}
		
// MOD 2006.07.12 東都）山本 荷主総件数の表示対応 START
				if(lbl荷主総件数.Text.Length != 0)
				{
					String[] sList1 = {""};
					sList1 = sv_otodoke.Get_ninushiCount(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
// MOD 2007.02.19 FJCS）桑田 荷主総件数の表示対応 START
//					lbl荷主総件数.Text=sList1[1].ToString()+"件";
					lbl荷主総件数.Text=sList1[1].ToString()+" 件";
// MOD 2007.02.19 FJCS）桑田 荷主総件数の表示対応 END
					lbl荷主総件数.Visible=true;
				}
// MOD 2006.07.12 東都）山本 荷主総件数の表示対応 END
			
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				sList[0] = gs通信エラー;
				Cursor = System.Windows.Forms.Cursors.Default;
				texメッセージ.Text = sList[0];
				ビープ音();
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				sList[0] = "通信エラー：" + ex.Message;
				Cursor = System.Windows.Forms.Cursors.Default;
				texメッセージ.Text = sList[0];
				ビープ音();
			}
		}

		private void btn削除_Click(object sender, System.EventArgs e)
		{
			// 空白除去
			tex届け先コード.Text = tex届け先コード.Text.Trim();

			if(!必須チェック(tex届け先コード,"届け先コード")) return;
			if(!半角チェック(tex届け先コード,"届け先コード")) return;
			
			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			String[] sList = {""};
			try
			{
				if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
				sList = sv_otodoke.Get_Stodokesaki(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,tex届け先コード.Text.Trim());
//			sUpday    = sList[14];
//↑コメント削除可？
// MOD 2007.02.13 東都）高木 ORA-00921および排他エラー対応 START
//				sIUFlg    = sList[15];
				if(sList[15] == "U"){
//					if(s更新日時.Length == 0) s更新日時 = sList[14];
					s更新日時 = sList[14];
				}else{
					s更新日時 = "";
				}
// MOD 2007.02.13 東都）高木 ORA-00921および排他エラー対応 END

				Cursor = System.Windows.Forms.Cursors.Default;

				String[] sDList;
				string[] sData = new string[5];

				DialogResult result;
// MOD 2007.02.13 東都）高木 ORA-00921および排他エラー対応 START
//				if(sIUFlg == "I")
				if(s更新日時.Length == 0)
// MOD 2007.02.13 東都）高木 ORA-00921および排他エラー対応 END
					MessageBox.Show("コード(" + tex届け先コード.Text + ")のデータは存在しません","削除",MessageBoxButtons.OK);
				else
				{
					result = MessageBox.Show("コード(" + tex届け先コード.Text + ")のデータを削除しますか？","削除",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						texメッセージ.Text = "削除中．．．";
						sData[0] = gs会員ＣＤ;
						sData[1] = gs部門ＣＤ;
						sData[2] = tex届け先コード.Text.Trim();
						sData[3] = "お届け先";
						sData[4] = gs利用者ＣＤ;

						Cursor = System.Windows.Forms.Cursors.AppStarting;

						if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
						sDList = sv_otodoke.Del_todokesaki(gsaユーザ,sData);
//						Cursor = System.Windows.Forms.Cursors.Default;

						// [正常終了]時、画面をクリアする
						if(sDList[0].Length == 4)
						{
							tex届け先コード.Text = "";
							btn取消_Click(sender,e);
						}
						else
						{
							ビープ音();
							texメッセージ.Text = sDList[0];
						}
// MOD 2006.07.12 東都）山本 荷主総件数の表示対応 START
						if(lbl荷主総件数.Text.Length != 0)
						{
							String[] sList1 = {""};
							sList1 = sv_otodoke.Get_ninushiCount(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
// MOD 2007.02.19 FJCS）桑田 荷主総件数の表示対応 START
//							lbl荷主総件数.Text=sList1[1].ToString()+"件";
							lbl荷主総件数.Text=sList1[1].ToString()+" 件";
// MOD 2007.02.19 FJCS）桑田 荷主総件数の表示対応 END
							lbl荷主総件数.Visible=true;
						}
// MOD 2006.07.12 東都）山本 荷主総件数の表示対応 END
					}
					Cursor = System.Windows.Forms.Cursors.Default;
				}
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				sList[0] = gs通信エラー;
				Cursor = System.Windows.Forms.Cursors.Default;
				texメッセージ.Text = sList[0];
				ビープ音();
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				sList[0] = "通信エラー：" + ex.Message;
				Cursor = System.Windows.Forms.Cursors.Default;
				texメッセージ.Text = sList[0];
				ビープ音();

			}

		}

		private void 項目クリア()
		{
//			tex届け先コード.Text = "";
			texカナ略称.Text     = "";
			tex電話番号１.Text   = "";
			tex電話番号２.Text   = "";
			tex電話番号３.Text   = "";
			tex郵便番号１.Text   = "";
			tex郵便番号２.Text   = "";
			tex住所１.Text       = "";
			tex住所２.Text       = "";
			tex住所３.Text       = "";
			tex名前１.Text       = "";
			tex名前２.Text       = "";
			tex特殊計.Text       = "";
			texメール.Text       = "";
// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 START
			tex住所コード.Text   = "";
			tex着店コード.Text   = "";
// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 START
			texメッセージ.Text   = "";
// ADD 2007.02.13 東都）高木 ORA-00921および排他エラー対応 START
			s更新日時            = "";
// ADD 2007.02.13 東都）高木 ORA-00921および排他エラー対応 END
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 START
			// ロックを解除
			tex郵便番号１.Enabled = true; // 郵便番号１
			tex郵便番号２.Enabled = true; // 郵便番号２
			tex住所１.Enabled = true; // 住所１
			tex住所２.Enabled = true; // 住所２
			tex住所３.Enabled = true; // 住所３
			// 支店止めボタンを表示、解除ボタンを非表示
			btn支店止め.Visible = true;
			btn支店止め解除.Visible = false;
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 END
			tex届け先コード.Focus();
		}
		
		private void btn取消_Click(object sender, System.EventArgs e)
		{
			項目クリア();
		}

		private void tex届け先コード_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				if(tex届け先コード.Text.Trim().Length == 0)
				{
					btn届け先検索.Focus();
					btn届け先検索_Click(sender, e);
				}
				else
				{
					btn届け先実行_Click(sender, e);
				}
				return;
			}
		}

		private void tex郵便番号２_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				// 空白除去
				tex郵便番号１.Text = tex郵便番号１.Text.Trim();
				tex郵便番号２.Text = tex郵便番号２.Text.Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//				tex住所１.Text = tex住所１.Text.Trim();
//				tex住所２.Text = tex住所２.Text.Trim();
//				tex住所３.Text = tex住所３.Text.Trim();
				if(gsオプション[18].Equals("1")){
					tex住所１.Text = tex住所１.Text.TrimEnd();
					tex住所２.Text = tex住所２.Text.TrimEnd();
					tex住所３.Text = tex住所３.Text.TrimEnd();
				}else{
					tex住所１.Text = tex住所１.Text.Trim();
					tex住所２.Text = tex住所２.Text.Trim();
					tex住所３.Text = tex住所３.Text.Trim();
				}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END

				// 入力チェック
				if(!半角チェック(tex郵便番号１,"郵便番号１")) return;
				if(!半角チェック(tex郵便番号２,"郵便番号２")) return;

				string s郵便番号 = tex郵便番号１.Text + tex郵便番号２.Text;
				if(s郵便番号.Length == 7)
				{
					if(tex住所１.Text.Length == 0 && tex住所２.Text.Length == 0 && tex住所３.Text.Length == 0)
					{
						// カーソルを砂時計にする
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						string[] sRet = {""};
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
						Cursor = System.Windows.Forms.Cursors.Default;

						if(sRet[0].Length == 4)
						{
// 保留						sRet[1]：郵便番号
// 保留						sRet[3]：住所ＣＤ
							if(sRet[2].Length > 60){
								tex住所１.Text     = sRet[2].Substring(0,20);
								tex住所２.Text     = sRet[2].Substring(20,20);
								tex住所３.Text     = sRet[2].Substring(40,20);
							}else if(sRet[2].Length > 40){
								tex住所１.Text     = sRet[2].Substring(0,20);
								tex住所２.Text     = sRet[2].Substring(20,20);
								tex住所３.Text     = sRet[2].Substring(40);
							}else if(sRet[2].Length > 20){
								tex住所１.Text     = sRet[2].Substring(0,20);
								tex住所２.Text     = sRet[2].Substring(20);
								tex住所３.Text     = "";
							}else{
								tex住所１.Text     = sRet[2];
								tex住所２.Text     = "";
								tex住所３.Text     = "";
							}
							texメッセージ.Text = "";
							//フォーカス設定
							tex住所２.Focus();
						}else{
							//フォーカス設定
							if(sRet[0].Equals("該当データがありません"))
								sRet[0] = "郵便番号が存在しません";
							texメッセージ.Text = sRet[0];
							ビープ音();
							tex郵便番号１.Focus();
						}
					}
				}
				else
				{
					btn住所検索.Focus();
					btn住所検索_Click(sender, e);
				}

				return;
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

		private void tex郵便番号１_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn住所検索.Focus();
				btn住所検索_Click(sender,e);
				e.Handled = true;
			}		
		}

		private void tex郵便番号２_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn住所検索_Click(sender,e);
				e.Handled = true;
			}		
		}

		private void btn一覧表_Click(object sender, System.EventArgs e)
		{
			texメッセージ.Text = "お届け先一覧印刷中．．．";
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				if(sv_print == null) sv_print = new is2print.Service1();
				string[] sKey = new string[3];
				sKey[0] = gs会員ＣＤ;
				sKey[1] = gs部門ＣＤ;

				string[] sRet = new string[1];
				IEnumerator iEnum = sv_print.Get_ConsigneePrintData(gsaユーザ,sKey).GetEnumerator();
				iEnum.MoveNext();
				sRet = (string[])iEnum.Current;
// DEL 2005.05.11 東都）高木 「正常終了」は表示しない START
//				texメッセージ.Text = sRet[0];
// DEL 2005.05.11 東都）高木 「正常終了」は表示しない END
				if (sRet[0].Equals("正常終了"))
				{
					お届先データ ds = new お届先データ();

					int iCnt = 1;
					//データセットに値をセット
					while (iEnum.MoveNext())
					{
						string[] sList = new string[13];
						sList = (string[])iEnum.Current;
					
						お届先データ.tableお届先Row tr = (お届先データ.tableお届先Row)ds.tableお届先.NewRow();
						tr.BeginEdit();
						tr.番号 = iCnt++;
						tr.コード   = sList[0].Trim();
						tr.カナ略称 = sList[1].Trim();
						if(sList[2].Trim().Length == 0)
							tr.電話番号 = sList[3] + "-" + sList[4];
						else
							tr.電話番号 = "(" + sList[2] + ")" + sList[3] + "-" + sList[4];
						tr.郵便番号 = sList[5] + "-" + sList[6];
						tr.住所     = sList[7].Trim() + sList[8].Trim() + sList[9].Trim();
						tr.名前     = sList[10].Trim() + "  " + sList[11].Trim();
						tr.特殊計   = sList[12].Trim();
//保留 MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
///						if(gsオプション[18].Equals("1")){
							tr.カナ略称 = sList[1].TrimEnd();
							tr.住所     = sList[7].TrimEnd() + sList[8].TrimEnd() + sList[9].TrimEnd();
							tr.名前     = sList[10].TrimEnd() + "  " + sList[11].TrimEnd();
///						}
//保留 MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
						tr.EndEdit();

						ds.tableお届先.Rows.Add(tr);					
					}
					
					お届先帳票 cr = new お届先帳票();
					//CrystalReportにパラメータとデータセットを渡す
					cr.SetParameterValue("部門ＣＤ", gs部門ＣＤ);
					cr.SetParameterValue("部門名",   gs部門名);
					cr.SetDataSource(ds);

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
				else
				{
// ADD 2005.05.11 東都）高木 「正常終了」は表示しない START
					texメッセージ.Text = sRet[0];
// ADD 2005.05.11 東都）高木 「正常終了」は表示しない END
					ビープ音();
				}
			}
// ADD 2005.06.27 東都）高木 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				texメッセージ.Text = gs通信エラー;
				ビープ音();
			}
// ADD 2005.06.27 東都）高木 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				texメッセージ.Text = ex.Message;
				ビープ音();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

// ADD 2005.05.24 東都）小童谷 フォーカス移動 START
		private void お届け先登録_Closed(object sender, System.EventArgs e)
		{
			tex届け先コード.Text = " ";
			項目クリア();
			tex届け先コード.Focus();
		}
// ADD 2005.05.24 東都）小童谷 フォーカス移動 END

// ADD 2005.06.08 東都）伊賀 ＣＳＶ出力追加 START
		private void btnＣＳＶ出力_Click(object sender, System.EventArgs e)
		{
// MOD 2010.09.22 東都）高木 ＣＳＶ出力：[キャンセル]選択時の障害修正 START
			texメッセージ.Text = "";
// MOD 2010.09.22 東都）高木 ＣＳＶ出力：[キャンセル]選択時の障害修正 END
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				String[] sList;
				if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
				sList = sv_otodoke.Get_csvwrite(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
				this.Cursor = System.Windows.Forms.Cursors.Default;

				if(sList[0].Length == 4)
				{
					sList[0] = "\"荷受人コード\",\"電話番号\",\"ＦＡＸ番号\","
						+ "\"住所１\",\"住所２\",\"住所３\","
// ADD 2005.11.08 東都）伊賀 ヘッダ項目不足修正 START
//						+ "\"名前１\",\"名前２\",\"郵便番号\","
						+ "\"名前１\",\"名前２\",\"予約\",\"郵便番号\","
// ADD 2005.11.08 東都）伊賀 ヘッダ項目不足修正 END
						+ "\"カナ略称\",\"一斉出荷区分\",\"特殊計\",\"着店コード\"";

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
// MOD 2010.09.22 東都）高木 ＣＳＶ出力：[キャンセル]選択時の障害修正 START
//						texメッセージ.Text = "";
// MOD 2010.09.22 東都）高木 ＣＳＶ出力：[キャンセル]選択時の障害修正 END
					}
// MOD 2010.09.22 東都）高木 ＣＳＶ出力：[キャンセル]選択時の障害修正 START
					texメッセージ.Text = "";
// MOD 2010.09.22 東都）高木 ＣＳＶ出力：[キャンセル]選択時の障害修正 END
				}
				else
				{
					ビープ音();
					texメッセージ.Text = sList[0];
				}
			}
// ADD 2005.06.27 東都）高木 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
				texメッセージ.Text = gs通信エラー;
				ビープ音();
			}
// ADD 2005.06.27 東都）高木 通信エラーのメッセージ修正 END
			catch(Exception ex)
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
				texメッセージ.Text = ex.Message;
			}
			tex届け先コード.Focus();

		}

// ADD 2005.06.08 東都）伊賀 ＣＳＶ出力追加 END
// MOD 2006.07.03 東都）山本 荷主総件数の表示対応 START
		private void btn件数取得_Click(object sender, System.EventArgs e)
		{
			String[] sList = {""};
			if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
			sList = sv_otodoke.Get_ninushiCount(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
// MOD 2007.02.19 FJCS）桑田 荷主総件数の表示対応 START
//			lbl荷主総件数.Text=sList[1].ToString()+"件";
			lbl荷主総件数.Text=sList[1].ToString()+" 件";
// MOD 2007.02.19 FJCS）桑田 荷主総件数の表示対応 END
			lbl荷主総件数.Visible=true;
		}

// MOD 2006.07.03 東都）山本 荷主総件数の表示対応 END
		
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
				tex郵便番号１.Text = g店所検索.s郵便番号.Substring(0, 3); // 郵便番号１
				tex郵便番号２.Text = g店所検索.s郵便番号.Substring(3, 4); // 郵便番号２
				tex住所１.Text = "※※支店止め※※"; // 住所１
				tex住所２.Text = g店所検索.s店所正式名 + "止め"; // 住所２
				tex住所３.Text = 全角数字変換(g店所検索.s店所コード); // 住所３

				// 郵便番号および住所１～３をロック
				tex郵便番号１.Enabled = false; // 郵便番号１
				tex郵便番号２.Enabled = false; // 郵便番号２
				tex住所１.Enabled = false; // 住所１
				tex住所２.Enabled = false; // 住所２
				tex住所３.Enabled = false; // 住所３

				// 支店止めボタンを非表示、解除ボタンを表示
				btn支店止め.Visible = false;
				btn支店止め解除.Visible = true;

				// フォーカスを『名前１』に設定
				tex名前１.Focus();
			}
			else
			{
				/** それ以外の場合 */
				// フォーカスを『住所１』に設定
				tex住所１.Focus();
			}
		}

		private void btn支店止め解除_Click(object sender, System.EventArgs e)
		{
			// 郵便番号および住所１～３のロックを解除
			tex郵便番号１.Enabled = true; // 郵便番号１
			tex郵便番号２.Enabled = true; // 郵便番号２
			tex住所１.Enabled = true; // 住所１
			tex住所２.Enabled = true; // 住所２
			tex住所３.Enabled = true; // 住所３

			// 郵便番号および住所１～３の入力値をクリア
			tex郵便番号１.Text = ""; // 郵便番号１
			tex郵便番号２.Text = ""; // 郵便番号２
			tex住所１.Text = ""; // 住所１
			tex住所２.Text = ""; // 住所２
			tex住所３.Text = ""; // 住所３

			// 支店止めボタンを表示、解除ボタンを非表示
			btn支店止め.Visible = true;
			btn支店止め解除.Visible = false;

			// フォーカスを『郵便番号１』に設定
			tex郵便番号１.Focus();
		}
// MOD 2015.07.30 BEVAS) 松本 支店止め機能対応 END

	}
}
