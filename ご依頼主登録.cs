using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [ご依頼主登録]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 
	//--------------------------------------------------------------------------
	// MOD 2009.08.20 パソ）藤井 郵便番号の値引継ぎ 
	//--------------------------------------------------------------------------
	// MOD 2010.09.07 東都）高木 請求先コードの存在チェック 
	// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない 
	// MOD 2011.01.25 東都）高木 「ロードに失敗」対応 
	// MOD 2011.04.13 東都）高木 重量入力不可対応 
	// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 
	//--------------------------------------------------------------------------
	public class ご依頼主登録 : 共通フォーム
	{
// MOD 2007.06.21 東都）高木 ORA-00921および排他エラー対応 START
//		private string sIUFlg;
//		private string sUpday;
		private string s更新日時 = "";
// MOD 2007.06.21 東都）高木 ORA-00921および排他エラー対応 END
		private string s依頼主ＣＤ;
// ADD 2006.08.10 東都）山本 依頼人情報「初期表示に使用する」を解除可能にする対応 START
		private bool bDefFlg;
// ADD 2006.08.10 東都）山本 依頼人情報「初期表示に使用する」を解除可能にする対応 END
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab日時;
		private 共通テキストボックス texカナ略称;
		private 共通テキストボックス tex電話番号１;
		private 共通テキストボックス tex名前２;
		private 共通テキストボックス tex名前１;
		private 共通テキストボックス tex郵便番号２;
		private 共通テキストボックス tex郵便番号１;
		private 共通テキストボックス tex電話番号３;
		private 共通テキストボックス tex電話番号２;
		private 共通テキストボックス tex住所２;
		private 共通テキストボックス tex住所１;
		private 共通テキストボックス tex依頼主コード;
		private 共通テキストボックス texお客様名;
		private 共通テキストボックス tex利用部門;
		private System.Windows.Forms.Label lab依頼主登録;
		private 共通テキストボックス texメール;
		private System.Windows.Forms.NumericUpDown nUD重量;
		private 共通テキストボックス texメッセージ;
		private System.Windows.Forms.Button btn住所検索;
		private System.Windows.Forms.Button btn依頼主検索;
		private System.Windows.Forms.Button btn依頼主実行;
		private System.Windows.Forms.Button btn一覧表;
		private System.Windows.Forms.Button btn削除;
		private System.Windows.Forms.Button btn取消;
		private System.Windows.Forms.Button btn更新;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.Label labメール;
		private System.Windows.Forms.Label lab重量;
		private System.Windows.Forms.Label labカナ略称;
		private System.Windows.Forms.Label lab名前;
		private System.Windows.Forms.Label lab住所;
		private System.Windows.Forms.Label lab郵便番号;
		private System.Windows.Forms.Label lab電話番号;
		private System.Windows.Forms.Label lab依頼主コード;
		private System.Windows.Forms.Label labお客様名;
		private System.Windows.Forms.Label lab利用部門;
		private System.Windows.Forms.Label lab請求先;
		private System.Windows.Forms.ComboBox cmb請求先;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox cBoxデフォルト;
		private System.Windows.Forms.NumericUpDown nUD才数;
		private System.Windows.Forms.Label lab才数;
		private System.Windows.Forms.Label lab請求先コード;
		private System.Windows.Forms.TextBox tex請求先部課コード;
		private System.Windows.Forms.TextBox tex請求先コード;
		private System.Windows.Forms.Button btnＣＳＶ出力;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.ComponentModel.IContainer components;

		public ご依頼主登録()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ご依頼主登録));
			this.texカナ略称 = new IS2Client.共通テキストボックス();
			this.tex電話番号１ = new IS2Client.共通テキストボックス();
			this.label11 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmb請求先 = new System.Windows.Forms.ComboBox();
			this.labメール = new System.Windows.Forms.Label();
			this.texメール = new IS2Client.共通テキストボックス();
			this.nUD重量 = new System.Windows.Forms.NumericUpDown();
			this.label22 = new System.Windows.Forms.Label();
			this.lab重量 = new System.Windows.Forms.Label();
			this.labカナ略称 = new System.Windows.Forms.Label();
			this.lab請求先 = new System.Windows.Forms.Label();
			this.tex名前２ = new IS2Client.共通テキストボックス();
			this.lab名前 = new System.Windows.Forms.Label();
			this.tex名前１ = new IS2Client.共通テキストボックス();
			this.btn住所検索 = new System.Windows.Forms.Button();
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
			this.btn依頼主検索 = new System.Windows.Forms.Button();
			this.btn依頼主実行 = new System.Windows.Forms.Button();
			this.lab依頼主コード = new System.Windows.Forms.Label();
			this.tex依頼主コード = new IS2Client.共通テキストボックス();
			this.panel6 = new System.Windows.Forms.Panel();
			this.texお客様名 = new IS2Client.共通テキストボックス();
			this.labお客様名 = new System.Windows.Forms.Label();
			this.lab利用部門 = new System.Windows.Forms.Label();
			this.tex利用部門 = new IS2Client.共通テキストボックス();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab日時 = new System.Windows.Forms.Label();
			this.lab依頼主登録 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btnＣＳＶ出力 = new System.Windows.Forms.Button();
			this.btn一覧表 = new System.Windows.Forms.Button();
			this.btn削除 = new System.Windows.Forms.Button();
			this.btn取消 = new System.Windows.Forms.Button();
			this.btn更新 = new System.Windows.Forms.Button();
			this.texメッセージ = new IS2Client.共通テキストボックス();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tex請求先部課コード = new System.Windows.Forms.TextBox();
			this.tex請求先コード = new System.Windows.Forms.TextBox();
			this.lab請求先コード = new System.Windows.Forms.Label();
			this.lab才数 = new System.Windows.Forms.Label();
			this.nUD才数 = new System.Windows.Forms.NumericUpDown();
			this.cBoxデフォルト = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD重量)).BeginInit();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nUD才数)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// texカナ略称
			// 
			this.texカナ略称.BackColor = System.Drawing.SystemColors.Window;
			this.texカナ略称.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texカナ略称.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
			this.texカナ略称.Location = new System.Drawing.Point(136, 168);
			this.texカナ略称.MaxLength = 10;
			this.texカナ略称.Name = "texカナ略称";
			this.texカナ略称.Size = new System.Drawing.Size(110, 23);
			this.texカナ略称.TabIndex = 10;
			this.texカナ略称.Text = "";
			// 
			// tex電話番号１
			// 
			this.tex電話番号１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex電話番号１.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex電話番号１.Location = new System.Drawing.Point(136, 16);
			this.tex電話番号１.MaxLength = 6;
			this.tex電話番号１.Name = "tex電話番号１";
			this.tex電話番号１.Size = new System.Drawing.Size(56, 23);
			this.tex電話番号１.TabIndex = 0;
			this.tex電話番号１.Text = "";
			// 
			// label11
			// 
			this.label11.ForeColor = System.Drawing.Color.Red;
			this.label11.Location = new System.Drawing.Point(28, 224);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(16, 14);
			this.label11.TabIndex = 60;
			this.label11.Text = "※";
			// 
			// label7
			// 
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(28, 122);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(16, 14);
			this.label7.TabIndex = 57;
			this.label7.Text = "※";
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(28, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 14);
			this.label3.TabIndex = 56;
			this.label3.Text = "※";
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(28, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 14);
			this.label2.TabIndex = 55;
			this.label2.Text = "※";
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(28, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(16, 14);
			this.label1.TabIndex = 54;
			this.label1.Text = "※";
			// 
			// cmb請求先
			// 
			this.cmb請求先.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb請求先.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cmb請求先.Location = new System.Drawing.Point(136, 220);
			this.cmb請求先.Name = "cmb請求先";
			this.cmb請求先.Size = new System.Drawing.Size(144, 20);
			this.cmb請求先.TabIndex = 14;
			this.cmb請求先.SelectedIndexChanged += new System.EventHandler(this.cmb請求先_SelectedIndexChanged);
			// 
			// labメール
			// 
			this.labメール.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labメール.ForeColor = System.Drawing.Color.LimeGreen;
			this.labメール.Location = new System.Drawing.Point(40, 198);
			this.labメール.Name = "labメール";
			this.labメール.Size = new System.Drawing.Size(72, 14);
			this.labメール.TabIndex = 52;
			this.labメール.Text = "メールアドレス";
			// 
			// texメール
			// 
			this.texメール.BackColor = System.Drawing.SystemColors.Window;
			this.texメール.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texメール.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.texメール.Location = new System.Drawing.Point(136, 194);
			this.texメール.MaxLength = 45;
			this.texメール.Name = "texメール";
			this.texメール.Size = new System.Drawing.Size(330, 23);
			this.texメール.TabIndex = 13;
			this.texメール.Text = "";
			// 
			// nUD重量
			// 
			this.nUD重量.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.nUD重量.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.nUD重量.Location = new System.Drawing.Point(136, 298);
			this.nUD重量.Maximum = new System.Decimal(new int[] {
																  9999,
																  0,
																  0,
																  0});
			this.nUD重量.Name = "nUD重量";
			this.nUD重量.Size = new System.Drawing.Size(58, 23);
			this.nUD重量.TabIndex = 72;
			this.nUD重量.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nUD重量.ThousandsSeparator = true;
			this.nUD重量.Visible = false;
			this.nUD重量.Enter += new System.EventHandler(this.nUD重量_Enter);
			// 
			// label22
			// 
			this.label22.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label22.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label22.ForeColor = System.Drawing.Color.White;
			this.label22.Location = new System.Drawing.Point(0, 6);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(22, 336);
			this.label22.TabIndex = 50;
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab重量
			// 
			this.lab重量.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab重量.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab重量.Location = new System.Drawing.Point(40, 302);
			this.lab重量.Name = "lab重量";
			this.lab重量.Size = new System.Drawing.Size(74, 14);
			this.lab重量.TabIndex = 48;
			this.lab重量.Text = "重量(kg)";
			this.lab重量.Visible = false;
			// 
			// labカナ略称
			// 
			this.labカナ略称.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labカナ略称.ForeColor = System.Drawing.Color.LimeGreen;
			this.labカナ略称.Location = new System.Drawing.Point(40, 172);
			this.labカナ略称.Name = "labカナ略称";
			this.labカナ略称.Size = new System.Drawing.Size(74, 14);
			this.labカナ略称.TabIndex = 42;
			this.labカナ略称.Text = "カナ略称";
			// 
			// lab請求先
			// 
			this.lab請求先.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab請求先.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab請求先.Location = new System.Drawing.Point(40, 224);
			this.lab請求先.Name = "lab請求先";
			this.lab請求先.Size = new System.Drawing.Size(74, 14);
			this.lab請求先.TabIndex = 36;
			this.lab請求先.Text = "請求先";
			// 
			// tex名前２
			// 
			this.tex名前２.BackColor = System.Drawing.SystemColors.Window;
			this.tex名前２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex名前２.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex名前２.Location = new System.Drawing.Point(136, 142);
			this.tex名前２.MaxLength = 20;
			this.tex名前２.Name = "tex名前２";
			this.tex名前２.Size = new System.Drawing.Size(330, 23);
			this.tex名前２.TabIndex = 9;
			this.tex名前２.Text = "";
			// 
			// lab名前
			// 
			this.lab名前.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab名前.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab名前.Location = new System.Drawing.Point(40, 122);
			this.lab名前.Name = "lab名前";
			this.lab名前.Size = new System.Drawing.Size(74, 14);
			this.lab名前.TabIndex = 24;
			this.lab名前.Text = "名前";
			// 
			// tex名前１
			// 
			this.tex名前１.BackColor = System.Drawing.SystemColors.Window;
			this.tex名前１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex名前１.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex名前１.Location = new System.Drawing.Point(136, 118);
			this.tex名前１.MaxLength = 20;
			this.tex名前１.Name = "tex名前１";
			this.tex名前１.Size = new System.Drawing.Size(330, 23);
			this.tex名前１.TabIndex = 8;
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
			this.btn住所検索.TabIndex = 5;
			this.btn住所検索.TabStop = false;
			this.btn住所検索.Text = "検索";
			this.btn住所検索.Click += new System.EventHandler(this.btn住所検索_Click);
			// 
			// lab住所
			// 
			this.lab住所.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab住所.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab住所.Location = new System.Drawing.Point(40, 72);
			this.lab住所.Name = "lab住所";
			this.lab住所.Size = new System.Drawing.Size(74, 14);
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
			this.tex郵便番号２.TabIndex = 4;
			this.tex郵便番号２.Text = "";
			this.tex郵便番号２.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex郵便番号２_KeyDown);
			this.tex郵便番号２.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex郵便番号２_KeyPress);
			// 
			// tex郵便番号１
			// 
			this.tex郵便番号１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex郵便番号１.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex郵便番号１.Location = new System.Drawing.Point(136, 42);
			this.tex郵便番号１.MaxLength = 3;
			this.tex郵便番号１.Name = "tex郵便番号１";
			this.tex郵便番号１.Size = new System.Drawing.Size(32, 23);
			this.tex郵便番号１.TabIndex = 3;
			this.tex郵便番号１.Text = "";
			this.tex郵便番号１.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex郵便番号１_KeyPress);
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label8.ForeColor = System.Drawing.Color.LimeGreen;
			this.label8.Location = new System.Drawing.Point(168, 46);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(12, 14);
			this.label8.TabIndex = 17;
			this.label8.Text = "－";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab郵便番号
			// 
			this.lab郵便番号.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab郵便番号.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab郵便番号.Location = new System.Drawing.Point(40, 46);
			this.lab郵便番号.Name = "lab郵便番号";
			this.lab郵便番号.Size = new System.Drawing.Size(74, 14);
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
			this.tex電話番号３.TabIndex = 2;
			this.tex電話番号３.Text = "";
			// 
			// tex電話番号２
			// 
			this.tex電話番号２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex電話番号２.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex電話番号２.Location = new System.Drawing.Point(208, 16);
			this.tex電話番号２.MaxLength = 4;
			this.tex電話番号２.Name = "tex電話番号２";
			this.tex電話番号２.Size = new System.Drawing.Size(40, 23);
			this.tex電話番号２.TabIndex = 1;
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
			this.label5.Location = new System.Drawing.Point(192, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(12, 14);
			this.label5.TabIndex = 11;
			this.label5.Text = "）";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label4.ForeColor = System.Drawing.Color.LimeGreen;
			this.label4.Location = new System.Drawing.Point(126, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 14);
			this.label4.TabIndex = 10;
			this.label4.Text = "（";
			// 
			// lab電話番号
			// 
			this.lab電話番号.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab電話番号.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab電話番号.Location = new System.Drawing.Point(40, 22);
			this.lab電話番号.Name = "lab電話番号";
			this.lab電話番号.Size = new System.Drawing.Size(64, 14);
			this.lab電話番号.TabIndex = 9;
			this.lab電話番号.Text = "電話番号";
			// 
			// tex住所２
			// 
			this.tex住所２.BackColor = System.Drawing.SystemColors.Window;
			this.tex住所２.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex住所２.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex住所２.Location = new System.Drawing.Point(136, 92);
			this.tex住所２.MaxLength = 20;
			this.tex住所２.Name = "tex住所２";
			this.tex住所２.Size = new System.Drawing.Size(330, 23);
			this.tex住所２.TabIndex = 7;
			this.tex住所２.Text = "";
			// 
			// tex住所１
			// 
			this.tex住所１.BackColor = System.Drawing.SystemColors.Window;
			this.tex住所１.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex住所１.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.tex住所１.Location = new System.Drawing.Point(136, 68);
			this.tex住所１.MaxLength = 20;
			this.tex住所１.Name = "tex住所１";
			this.tex住所１.Size = new System.Drawing.Size(330, 23);
			this.tex住所１.TabIndex = 6;
			this.tex住所１.Text = "";
			// 
			// btn依頼主検索
			// 
			this.btn依頼主検索.BackColor = System.Drawing.Color.SteelBlue;
			this.btn依頼主検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn依頼主検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn依頼主検索.ForeColor = System.Drawing.Color.White;
			this.btn依頼主検索.Location = new System.Drawing.Point(272, 12);
			this.btn依頼主検索.Name = "btn依頼主検索";
			this.btn依頼主検索.Size = new System.Drawing.Size(48, 22);
			this.btn依頼主検索.TabIndex = 1;
			this.btn依頼主検索.TabStop = false;
			this.btn依頼主検索.Text = "検索";
			this.btn依頼主検索.Click += new System.EventHandler(this.btn依頼主検索_Click);
			// 
			// btn依頼主実行
			// 
			this.btn依頼主実行.BackColor = System.Drawing.Color.SteelBlue;
			this.btn依頼主実行.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn依頼主実行.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn依頼主実行.ForeColor = System.Drawing.Color.White;
			this.btn依頼主実行.Location = new System.Drawing.Point(324, 12);
			this.btn依頼主実行.Name = "btn依頼主実行";
			this.btn依頼主実行.Size = new System.Drawing.Size(48, 22);
			this.btn依頼主実行.TabIndex = 2;
			this.btn依頼主実行.TabStop = false;
			this.btn依頼主実行.Text = "実行";
			this.btn依頼主実行.Click += new System.EventHandler(this.btn依頼主実行_Click);
			// 
			// lab依頼主コード
			// 
			this.lab依頼主コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab依頼主コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab依頼主コード.Location = new System.Drawing.Point(6, 16);
			this.lab依頼主コード.Name = "lab依頼主コード";
			this.lab依頼主コード.Size = new System.Drawing.Size(106, 17);
			this.lab依頼主コード.TabIndex = 6;
			this.lab依頼主コード.Text = "ご依頼主コード";
			// 
			// tex依頼主コード
			// 
			this.tex依頼主コード.BackColor = System.Drawing.SystemColors.Window;
			this.tex依頼主コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex依頼主コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tex依頼主コード.Location = new System.Drawing.Point(114, 12);
			this.tex依頼主コード.MaxLength = 12;
			this.tex依頼主コード.Name = "tex依頼主コード";
			this.tex依頼主コード.Size = new System.Drawing.Size(154, 23);
			this.tex依頼主コード.TabIndex = 0;
			this.tex依頼主コード.Text = "";
			this.tex依頼主コード.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex依頼主コード_KeyDown);
			this.tex依頼主コード.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex依頼主コード_KeyPress);
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
			this.panel7.Controls.Add(this.lab依頼主登録);
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
			// lab依頼主登録
			// 
			this.lab依頼主登録.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab依頼主登録.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab依頼主登録.ForeColor = System.Drawing.Color.White;
			this.lab依頼主登録.Location = new System.Drawing.Point(12, 2);
			this.lab依頼主登録.Name = "lab依頼主登録";
			this.lab依頼主登録.Size = new System.Drawing.Size(264, 24);
			this.lab依頼主登録.TabIndex = 0;
			this.lab依頼主登録.Text = "ご依頼主登録";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btnＣＳＶ出力);
			this.panel8.Controls.Add(this.btn一覧表);
			this.panel8.Controls.Add(this.btn削除);
			this.panel8.Controls.Add(this.btn取消);
			this.panel8.Controls.Add(this.btn更新);
			this.panel8.Controls.Add(this.texメッセージ);
			this.panel8.Controls.Add(this.btn閉じる);
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
			this.btnＣＳＶ出力.TabIndex = 5;
			this.btnＣＳＶ出力.Text = "ＣＳＶ\n 出力";
			this.btnＣＳＶ出力.Click += new System.EventHandler(this.btnＣＳＶ出力_Click);
			// 
			// btn一覧表
			// 
			this.btn一覧表.ForeColor = System.Drawing.Color.Blue;
			this.btn一覧表.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn一覧表.Location = new System.Drawing.Point(308, 6);
			this.btn一覧表.Name = "btn一覧表";
			this.btn一覧表.Size = new System.Drawing.Size(62, 48);
			this.btn一覧表.TabIndex = 4;
			this.btn一覧表.Text = "一覧表　印刷";
			this.btn一覧表.Click += new System.EventHandler(this.btn一覧表_Click);
			// 
			// btn削除
			// 
			this.btn削除.ForeColor = System.Drawing.Color.Blue;
			this.btn削除.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn削除.Location = new System.Drawing.Point(238, 6);
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
			this.btn取消.Location = new System.Drawing.Point(168, 6);
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
			this.texメッセージ.Location = new System.Drawing.Point(446, 4);
			this.texメッセージ.Multiline = true;
			this.texメッセージ.Name = "texメッセージ";
			this.texメッセージ.ReadOnly = true;
			this.texメッセージ.Size = new System.Drawing.Size(344, 50);
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tex請求先部課コード);
			this.groupBox1.Controls.Add(this.tex請求先コード);
			this.groupBox1.Controls.Add(this.lab請求先コード);
			this.groupBox1.Controls.Add(this.lab才数);
			this.groupBox1.Controls.Add(this.nUD才数);
			this.groupBox1.Controls.Add(this.cBoxデフォルト);
			this.groupBox1.Controls.Add(this.lab電話番号);
			this.groupBox1.Controls.Add(this.tex郵便番号１);
			this.groupBox1.Controls.Add(this.tex電話番号１);
			this.groupBox1.Controls.Add(this.tex住所１);
			this.groupBox1.Controls.Add(this.lab重量);
			this.groupBox1.Controls.Add(this.labカナ略称);
			this.groupBox1.Controls.Add(this.lab請求先);
			this.groupBox1.Controls.Add(this.tex名前２);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.lab名前);
			this.groupBox1.Controls.Add(this.tex電話番号３);
			this.groupBox1.Controls.Add(this.tex名前１);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.lab住所);
			this.groupBox1.Controls.Add(this.lab郵便番号);
			this.groupBox1.Controls.Add(this.tex郵便番号２);
			this.groupBox1.Controls.Add(this.texカナ略称);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cmb請求先);
			this.groupBox1.Controls.Add(this.labメール);
			this.groupBox1.Controls.Add(this.tex電話番号２);
			this.groupBox1.Controls.Add(this.texメール);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.btn住所検索);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.nUD重量);
			this.groupBox1.Controls.Add(this.tex住所２);
			this.groupBox1.Controls.Add(this.label22);
			this.groupBox1.Location = new System.Drawing.Point(22, 96);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(478, 340);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			// 
			// tex請求先部課コード
			// 
			this.tex請求先部課コード.BackColor = System.Drawing.Color.Honeydew;
			this.tex請求先部課コード.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex請求先部課コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex請求先部課コード.Location = new System.Drawing.Point(416, 222);
			this.tex請求先部課コード.Name = "tex請求先部課コード";
			this.tex請求先部課コード.ReadOnly = true;
			this.tex請求先部課コード.Size = new System.Drawing.Size(52, 16);
			this.tex請求先部課コード.TabIndex = 66;
			this.tex請求先部課コード.TabStop = false;
			this.tex請求先部課コード.Text = "";
			// 
			// tex請求先コード
			// 
			this.tex請求先コード.BackColor = System.Drawing.Color.Honeydew;
			this.tex請求先コード.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tex請求先コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.tex請求先コード.Location = new System.Drawing.Point(318, 222);
			this.tex請求先コード.Name = "tex請求先コード";
			this.tex請求先コード.ReadOnly = true;
			this.tex請求先コード.Size = new System.Drawing.Size(96, 16);
			this.tex請求先コード.TabIndex = 65;
			this.tex請求先コード.TabStop = false;
			this.tex請求先コード.Text = "";
			// 
			// lab請求先コード
			// 
			this.lab請求先コード.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab請求先コード.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab請求先コード.Location = new System.Drawing.Point(284, 224);
			this.lab請求先コード.Name = "lab請求先コード";
			this.lab請求先コード.Size = new System.Drawing.Size(32, 14);
			this.lab請求先コード.TabIndex = 64;
			this.lab請求先コード.Text = "コード";
			// 
			// lab才数
			// 
			this.lab才数.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab才数.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab才数.Location = new System.Drawing.Point(40, 276);
			this.lab才数.Name = "lab才数";
			this.lab才数.Size = new System.Drawing.Size(74, 14);
			this.lab才数.TabIndex = 63;
			this.lab才数.Text = "才数";
			this.lab才数.Visible = false;
			// 
			// nUD才数
			// 
			this.nUD才数.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.nUD才数.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.nUD才数.Location = new System.Drawing.Point(136, 272);
			this.nUD才数.Maximum = new System.Decimal(new int[] {
																  999,
																  0,
																  0,
																  0});
			this.nUD才数.Name = "nUD才数";
			this.nUD才数.Size = new System.Drawing.Size(58, 23);
			this.nUD才数.TabIndex = 71;
			this.nUD才数.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nUD才数.ThousandsSeparator = true;
			this.nUD才数.Visible = false;
			// 
			// cBoxデフォルト
			// 
			this.cBoxデフォルト.ForeColor = System.Drawing.Color.LimeGreen;
			this.cBoxデフォルト.Location = new System.Drawing.Point(136, 246);
			this.cBoxデフォルト.Name = "cBoxデフォルト";
			this.cBoxデフォルト.Size = new System.Drawing.Size(140, 16);
			this.cBoxデフォルト.TabIndex = 61;
			this.cBoxデフォルト.Text = "初期表示に使用する";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btn依頼主検索);
			this.groupBox2.Controls.Add(this.btn依頼主実行);
			this.groupBox2.Controls.Add(this.lab依頼主コード);
			this.groupBox2.Controls.Add(this.tex依頼主コード);
			this.groupBox2.Location = new System.Drawing.Point(44, 56);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(456, 42);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			// 
			// ご依頼主登録
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 574);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "ご依頼主登録";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 ご依頼主登録";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
			this.Load += new System.EventHandler(this.ご依頼主登録_Load);
			this.Closed += new System.EventHandler(this.ご依頼主登録_Closed);
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD重量)).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nUD才数)).EndInit();
			this.groupBox2.ResumeLayout(false);
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
//				if(画面.s住所.Length > 40)
				tex郵便番号１.Text = g住所検索.s郵便番号１;
				tex郵便番号２.Text = g住所検索.s郵便番号２;
				if(g住所検索.s住所.Length > 40)
				{
//					tex住所１.Text     = 画面.s住所.Substring(0,20);
//					tex住所２.Text     = 画面.s住所.Substring(20,20);
					tex住所１.Text     = g住所検索.s住所.Substring(0,20);
					tex住所２.Text     = g住所検索.s住所.Substring(20,20);
				}
//				else if(画面.s住所.Length > 20)
				else if(g住所検索.s住所.Length > 20)
				{
//					tex住所１.Text     = 画面.s住所.Substring(0,20);
//					tex住所２.Text     = 画面.s住所.Substring(20);
					tex住所１.Text     = g住所検索.s住所.Substring(0,20);
					tex住所２.Text     = g住所検索.s住所.Substring(20);
				}
				else
				{
//					tex住所１.Text     = 画面.s住所;
					tex住所１.Text     = g住所検索.s住所;
					tex住所２.Text     = "";
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

		private void btn依頼主検索_Click(object sender, System.EventArgs e)
		{
			tex依頼主コード.Text = tex依頼主コード.Text.Trim();
			if(!半角チェック(tex依頼主コード,"依頼主コード")) return;

// MOD 2005.05.24 東都）小童谷 画面高速化 START
			// 検索画面を右側に表示する
//			ご依頼主検索 画面 = new ご依頼主検索();
//			画面.Left = this.Left + 404;
//			画面.Top = this.Top;
//			画面.Visible複写();
			// コードの初期表示
//			画面.sIcode = tex依頼主コード.Text;
//			画面.ShowDialog();
			if (g依頼検索 == null)	 g依頼検索 = new ご依頼主検索();
			g依頼検索.Left = this.Left;
			g依頼検索.Top = this.Top;
			g依頼検索.Visible複写();
// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 START
			g依頼検索.VisibleCSV出力();
			g依頼検索.Visible一覧印刷();
			g依頼検索.Visible削除();
// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 END
			// コードの初期表示
// MOD 2005.06.02 東都）小童谷 値の引継ぎなし START
//			g依頼検索.sIcode = tex依頼主コード.Text;
			g依頼検索.sIcode = "";
// MOD 2005.06.02 東都）小童谷 値の引継ぎなし END
			g依頼検索.ShowDialog(this);
// MOD 2005.05.24 東都）小童谷 画面高速化 END

			s依頼主ＣＤ = g依頼検索.sIcode;
			if(s依頼主ＣＤ.Length > 0)
			{
				if(g依頼検索.s複写 == "T")
				{
					btn依頼主実行_Click();
					tex依頼主コード.Text = " ";
					tex依頼主コード.Focus();
				}
				else
				{
					tex依頼主コード.Text = s依頼主ＣＤ;
					btn依頼主実行_Click();
					tex電話番号１.Focus();
				}
			}
			else
			{
				tex依頼主コード.Focus();
			}
		}

		private void ご依頼主登録_Load(object sender, System.EventArgs e)
		{
			// ヘッダー項目の設定
			texお客様名.Text = gs利用者名;
			tex利用部門.Text = gs部門ＣＤ + " " + gs部門名;

			// 日時の初期設定
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled = true;

			cmb請求先.Items.Clear();
			if(gsa請求先部課名 != null)
			{
				cmb請求先.Items.AddRange(gsa請求先部課名);
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック START
				cmb請求先.Items.Add("");
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック END
				cmb請求先.SelectedIndex = 0;
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 START
				tex請求先コード.Text     = "";
				tex請求先部課コード.Text = "";
				if(gsa請求先ＣＤ.Length > 0){
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック START
					if(cmb請求先.SelectedIndex < gsa請求先ＣＤ.Length){
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック END
						tex請求先コード.Text     = gsa請求先ＣＤ[cmb請求先.SelectedIndex];
						tex請求先部課コード.Text = gsa請求先部課ＣＤ[cmb請求先.SelectedIndex];
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック START
					}
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック END
				}
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 END
			}

// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
			Font fGothic = new System.Drawing.Font("MS Gothic"
							, 12F
							, System.Drawing.FontStyle.Regular
							, System.Drawing.GraphicsUnit.Point
							, ((System.Byte)(128))
							);
			tex住所１.Font = fGothic;
			tex住所２.Font = fGothic;
			tex名前１.Font = fGothic;
			tex名前２.Font = fGothic;
			texカナ略称.Font = fGothic;
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
			if(gs重量入力制御 == "1"){
				lab才数.Visible = true;
				nUD才数.Visible = true;
				lab重量.Visible = true;
				nUD重量.Visible = true;
			}else{
				lab才数.Visible = false;
				nUD才数.Visible = false;
				lab重量.Visible = false;
				nUD重量.Visible = false;
			}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

		private void btn取消_Click(object sender, System.EventArgs e)
		{
//			tex依頼主コード.Text = "";
			texカナ略称.Text     = "";
			tex電話番号１.Text   = "";
			tex電話番号２.Text   = "";
			tex電話番号３.Text   = "";
			tex郵便番号１.Text   = "";
			tex郵便番号２.Text   = "";
			tex住所１.Text       = "";
			tex住所２.Text       = "";
			tex名前１.Text       = "";
			tex名前２.Text       = "";
			nUD才数.Value        = 0;
			nUD重量.Value        = 0;
			nUD才数.Text        = "0";
			nUD重量.Text        = "0";
			texメール.Text       = "";
			cmb請求先.SelectedIndex = 0;
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 START
			tex請求先コード.Text     = "";
			tex請求先部課コード.Text = "";
			if(gsa請求先ＣＤ.Length > 0){
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック START
				if(cmb請求先.SelectedIndex < gsa請求先ＣＤ.Length){
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック END
					tex請求先コード.Text     = gsa請求先ＣＤ[cmb請求先.SelectedIndex];
					tex請求先部課コード.Text = gsa請求先部課ＣＤ[cmb請求先.SelectedIndex];
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック START
				}
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック END
			}
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 END
			cBoxデフォルト.Checked = false;
			texメッセージ.Text   = "";
// ADD 2007.06.21 東都）高木 ORA-00921および排他エラー対応 START
			s更新日時            = "";
// ADD 2007.06.21 東都）高木 ORA-00921および排他エラー対応 END

		}

		private void btn依頼主実行_Click()
		{
			texメッセージ.Text = "検索中．．．";

			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			String[] sList = {""};
			try
			{
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

// ADD 2006.08.10 東都）山本 依頼人情報「初期表示に使用する」を解除可能にする対応 START
			if(sList[2] != null)
			{
				String[] sList1 = {""};
				try
				{
					sList1 = sv_goirai.Get_riyo(gsaユーザ,gs会員ＣＤ,gs利用者ＣＤ);
				}
				catch (System.Net.WebException)
				{
					sList[0] = gs通信エラー;
				}
				catch (Exception ex)
				{
					sList[0] = "通信エラー：" + ex.Message;
				}
			
				if(sList1[0] == s依頼主ＣＤ)
				{
					cBoxデフォルト.Checked = true;
					bDefFlg = true;
				}
				else
				{
					cBoxデフォルト.Checked = false;
					bDefFlg = false;
				}
			}
// ADD 2006.08.10 東都）山本 依頼人情報「初期表示に使用する」を解除可能にする対応 END


			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;

			if(sList[2] != null)
			{
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//				texカナ略称.Text   = sList[1];
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
				tex電話番号１.Text = sList[2];
				tex電話番号２.Text = sList[3];
				tex電話番号３.Text = sList[4];
				tex郵便番号１.Text = sList[5];
				tex郵便番号２.Text = sList[6];
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//				tex住所１.Text     = sList[7];
//				tex住所２.Text     = sList[8];
//				tex名前１.Text     = sList[9];
//				tex名前２.Text     = sList[10];
				if(gsオプション[18].Equals("1")){
					tex住所１.Text     = sList[7].TrimEnd();
					tex住所２.Text     = sList[8].TrimEnd();
					tex名前１.Text     = sList[9].TrimEnd();
					tex名前２.Text     = sList[10].TrimEnd();
					texカナ略称.Text   = sList[1].TrimEnd();
				}else{
					tex住所１.Text     = sList[7].Trim();
					tex住所２.Text     = sList[8].Trim();
					tex名前１.Text     = sList[9].Trim();
					tex名前２.Text     = sList[10].Trim();
					texカナ略称.Text   = sList[1].Trim();
				}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
				if(gs重量入力制御 == "1"){
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
// MOD 2005.05.17 東都）小童谷 才数復活 START
					nUD才数.Value      = decimal.Parse(sList[11]);
					nUD才数.Text       = sList[11];
// MOD 2005.05.17 東都）小童谷 才数復活 END
					nUD重量.Value      = decimal.Parse(sList[12]);
					nUD重量.Text       = sList[12];
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
				}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
				texメール.Text     = sList[13];
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 START
				tex請求先コード.Text = sList[14];
				tex請求先部課コード.Text = sList[15];
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 END

// MOD 2010.09.07 東都）高木 請求先コードの存在チェック START
				cmb請求先.Text = "";
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック END
				int iCnt;
				if(gsa請求先ＣＤ != null)
				{
					for(iCnt = 0 ; iCnt < gsa請求先ＣＤ.Length; iCnt++ )
					{
						if(gsa請求先ＣＤ[iCnt] == null || gsa請求先部課ＣＤ[iCnt] == null)
							cmb請求先.SelectedIndex = 0;
						else
						{
							if(gsa請求先ＣＤ[iCnt] == sList[14] && gsa請求先部課ＣＤ[iCnt] == sList[15])
							{
								cmb請求先.SelectedIndex = iCnt;
								break;
							}
						}
					}
				}
			}

			texメッセージ.Text = sList[0];
// MOD 2007.06.21 東都）高木 ORA-00921および排他エラー対応 START
//			sUpday             = sList[16];
//			sIUFlg             = sList[17];
			s更新日時          = sList[16];
// MOD 2007.06.21 東都）高木 ORA-00921および排他エラー対応 END

			// メッセージが[登録]、[更新]の時、正常終了
			if(sList[0].Length == 2)
			{
				texメッセージ.Text = "";
				tex電話番号１.Focus();
			}
			else
			{
				// 異常終了時
				ビープ音();
				tex依頼主コード.Focus();
			}
		}

		private void btn削除_Click(object sender, System.EventArgs e)
		{
			// 空白除去
			tex依頼主コード.Text = tex依頼主コード.Text.Trim();

			if(!必須チェック(tex依頼主コード,"依頼主コード")) return;
			if(!半角チェック(tex依頼主コード,"依頼主コード")) return;

			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			String[] sList = {""};
			try
			{
				if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
				sList = sv_goirai.Get_Sirainusi(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,tex依頼主コード.Text.Trim());
				Cursor = System.Windows.Forms.Cursors.Default;
			
				//			sUpday    = sList[14];
// MOD 2007.06.21 東都）高木 ORA-00921および排他エラー対応 START
//				sIUFlg    = sList[17];
				if(sList[17] == "U"){
					s更新日時 = sList[16];
				}else{
					s更新日時 = "";
				}
// MOD 2007.06.21 東都）高木 ORA-00921および排他エラー対応 END

				String[] sDList;
				string[] sData = new string[5];

				DialogResult result;
// MOD 2007.06.21 東都）高木 ORA-00921および排他エラー対応 START
//				if(sIUFlg == "I")
				if(s更新日時.Length == 0)
// MOD 2007.06.21 東都）高木 ORA-00921および排他エラー対応 END
					MessageBox.Show("コード(" + tex依頼主コード.Text + ")のデータは存在しません","削除",MessageBoxButtons.OK);
				else
				{
// ADD 2005.11.07 東都）伊賀 出荷ジャーナルチェック START
					if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
					string[] sCData = new string[3];
					sCData[0] = gs会員ＣＤ;
					sCData[1] = gs部門ＣＤ;
					sCData[2]  = tex依頼主コード.Text.Trim();
					String[] sCList = sv_goirai.Sel_SyukkaIrainusi(gsaユーザ,sCData);

					if(sCList[0].Length != 4)
					{
						ビープ音();
						texメッセージ.Text = sCList[0];
						return;
					}
// ADD 2005.11.07 東都）伊賀 出荷ジャーナルチェック END

					result = MessageBox.Show("コード(" + tex依頼主コード.Text + ")のデータを削除しますか？","削除",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						texメッセージ.Text = "削除中．．．";
						sData[0] = gs会員ＣＤ;
						sData[1] = gs部門ＣＤ;
						sData[2]  = tex依頼主コード.Text.Trim();
						sData[3] = "ご依頼主";
						sData[4] = gs利用者ＣＤ;

						Cursor = System.Windows.Forms.Cursors.AppStarting;

						if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
						sDList = sv_goirai.Del_irainusi(gsaユーザ,sData);
						Cursor = System.Windows.Forms.Cursors.Default;
						if(sDList[0].Length == 4)
						{
							tex依頼主コード.Text = "";
							btn取消_Click(sender,e);
						}
						else
						{
							ビープ音();
							texメッセージ.Text = sDList[0];
						}
					}
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

		private void btn更新_Click(object sender, System.EventArgs e)
		{
			tex依頼主コード.Text = tex依頼主コード.Text.Trim();
			tex電話番号１.Text   = tex電話番号１.Text.Trim();
			tex電話番号２.Text   = tex電話番号２.Text.Trim();
			tex電話番号３.Text   = tex電話番号３.Text.Trim();
			tex郵便番号１.Text   = tex郵便番号１.Text.Trim();
			tex郵便番号２.Text   = tex郵便番号２.Text.Trim();
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//			tex住所１.Text       = tex住所１.Text.Trim();
//			tex住所２.Text       = tex住所２.Text.Trim();
//			tex名前１.Text       = tex名前１.Text.Trim();
//			tex名前２.Text       = tex名前２.Text.Trim();
//			texカナ略称.Text     = texカナ略称.Text.Trim();
			if(gsオプション[18].Equals("1")){
				tex住所１.Text       = tex住所１.Text.TrimEnd();
				tex住所２.Text       = tex住所２.Text.TrimEnd();
				tex名前１.Text       = tex名前１.Text.TrimEnd();
				tex名前２.Text       = tex名前２.Text.TrimEnd();
				texカナ略称.Text     = texカナ略称.Text.TrimEnd();
			}else{
				tex住所１.Text       = tex住所１.Text.Trim();
				tex住所２.Text       = tex住所２.Text.Trim();
				tex名前１.Text       = tex名前１.Text.Trim();
				tex名前２.Text       = tex名前２.Text.Trim();
				texカナ略称.Text     = texカナ略称.Text.Trim();
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
			texメール.Text       = texメール.Text.Trim();
			cmb請求先.Text       = cmb請求先.Text.Trim();

			if(!必須チェック(tex依頼主コード,"依頼主コード")) return;
			if(!必須チェック(tex電話番号１,"電話番号１")) return;
			if(!必須チェック(tex電話番号２,"電話番号２")) return;
			if(!必須チェック(tex電話番号３,"電話番号３")) return;
			if(!必須チェック(tex郵便番号１,"郵便番号１")) return;
			if(!必須チェック(tex郵便番号２,"郵便番号２")) return;
			if(!必須チェック(tex住所１,"住所１")) return;
			if(!必須チェック(tex名前１,"名前１")) return;

			if(!半角チェック(tex依頼主コード,"依頼主コード")) return;
			if(!数値チェック(tex電話番号１,"電話番号１")) return;
			if(!数値チェック(tex電話番号２,"電話番号２")) return;
			if(!数値チェック(tex電話番号３,"電話番号３")) return;
			if(!半角チェック(tex郵便番号１,"郵便番号１")) return;
			if(!半角チェック(tex郵便番号２,"郵便番号２")) return;
			if(!全角チェック(tex住所１,"住所１")) return;
			if(!全角チェック(tex住所２,"住所２")) return;
			if(!全角チェック(tex名前１,"名前１")) return;
			if(!全角チェック(tex名前２,"名前２")) return;
			if(!半角チェック(texカナ略称,"カナ略称")) return;
			if(!半角チェック(texメール,"メールアドレス")) return;

// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
			if(gs重量入力制御 == "1"){
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
				if(nUD重量.Text.Length == 0 ) nUD重量.Text = "0";
				if(nUD才数.Text.Length == 0 ) nUD才数.Text = "0";

				if(!範囲チェック(nUD重量,"重量")) return;
// ADD 2005.05.17 東都）小童谷 才数復活 START
				if(!範囲チェック(nUD才数,"才数")) return;
// ADD 2005.05.17 東都）小童谷 才数復活 END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
			}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END

			if(cmb請求先.Text.Length == 0 )
			{
				MessageBox.Show("必須項目（請求先）が入力されていません","入力チェック",MessageBoxButtons.OK);
				cmb請求先.Focus();
				return;
			}

// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 START
			tex請求先コード.Text     = "";
			tex請求先部課コード.Text = "";
			if(gsa請求先ＣＤ.Length > 0){
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック START
				if(cmb請求先.SelectedIndex < gsa請求先ＣＤ.Length){
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック END
					tex請求先コード.Text     = gsa請求先ＣＤ[cmb請求先.SelectedIndex];
					tex請求先部課コード.Text = gsa請求先部課ＣＤ[cmb請求先.SelectedIndex];
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック START
				}
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック END
			}
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 END

			//郵便番号存在チェック
			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string s郵便番号 = tex郵便番号１.Text + tex郵便番号２.Text;
			string[] sRet = {""};
			try
			{
				if(sv_address == null) sv_address = new is2address.Service1();
				sRet = sv_address.Get_byPostcode2(gsaユーザ,s郵便番号);
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


			texメッセージ.Text = "";
			// カーソルを砂時計にする
			String[] sList = {""};
			try
			{
				if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
				sList = sv_goirai.Get_Sirainusi(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ,tex依頼主コード.Text.Trim());
				Cursor = System.Windows.Forms.Cursors.Default;
//			sUpday    = sList[14];
// MOD 2007.06.21 東都）高木 ORA-00921および排他エラー対応 START
//				sIUFlg    = sList[17];
				if(sList[17] == "U"){
					s更新日時 = sList[16];
				}else{
					s更新日時 = "";
				}
// MOD 2007.06.21 東都）高木 ORA-00921および排他エラー対応 END

				String[] sIUList;
// MOD 2006.08.10 東都）山本 依頼人情報「初期表示に使用する」を解除可能にする対応 START
//				string[] sData = new string[22];
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
//				string[] sData = new string[23];
				string[] sData = new string[24];
				sData[23] = gs重量入力制御;
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
// MOD 2006.08.10 東都）山本 依頼人情報「初期表示に使用する」を解除可能にする対応 END
				sData[0]  = tex依頼主コード.Text;
				sData[1]  = texカナ略称.Text;
				sData[2]  = tex電話番号１.Text;
				sData[3]  = tex電話番号２.Text;
				sData[4]  = tex電話番号３.Text;
// MOD 2005.09.02 東都）小童谷 空白ずめ START
//				sData[5]  = tex郵便番号１.Text;
				sData[5]  = tex郵便番号１.Text.PadRight(3,' ');
// MOD 2005.09.02 東都）小童谷 空白ずめ END
				sData[6]  = tex郵便番号２.Text;
				sData[7]  = tex住所１.Text;
				sData[8]  = tex住所２.Text;
				sData[9]  = tex名前１.Text;
				sData[10] = tex名前２.Text;
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
				if(gs重量入力制御 == "1"){
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
// MOD 2005.05.17 東都）小童谷 才数復活 START
					sData[11] = nUD才数.Value.ToString();
// MOD 2005.05.17 東都）小童谷 才数復活 END
					sData[12] = nUD重量.Value.ToString();
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
				}else{
					sData[11] = "0";
					sData[12] = "0";
				}
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
				sData[13] = texメール.Text;
				sData[14] = "ご依頼主";
				sData[15] = gs利用者ＣＤ;
				sData[16] = gs会員ＣＤ;
				sData[17] = gs部門ＣＤ;
// MOD 2007.06.21 東都）高木 ORA-00921および排他エラー対応 START
//				sData[18] = sUpday;
				sData[18] = s更新日時;
// MOD 2007.06.21 東都）高木 ORA-00921および排他エラー対応 END
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック START
				sData[19] = " ";
				sData[20] = " ";
				if(cmb請求先.SelectedIndex < gsa請求先ＣＤ.Length){
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック END
					sData[19] = gsa請求先ＣＤ[cmb請求先.SelectedIndex];
					sData[20] = gsa請求先部課ＣＤ[cmb請求先.SelectedIndex];
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック START
				}
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック END
				if(cBoxデフォルト.Checked == true)
					sData[21] = "1";
				else
					sData[21] = "0";
// ADD 2006.08.10 東都）山本 依頼人情報「初期表示に使用する」を解除可能にする対応 START
				if(bDefFlg == true)
				{
					if(cBoxデフォルト.Checked == false)
						sData[22] = "1";
					else
						sData[22] = "0";
				}
				else
					sData[22] = "0";
// ADD 2006.08.10 東都）山本 依頼人情報「初期表示に使用する」を解除可能にする対応 END

				for(int iCnt = 0 ; iCnt < sData.Length; iCnt++ )
				{
					if( sData[iCnt] == null 
						|| sData[iCnt].Length == 0 ) sData[iCnt] = " ";
				}

				DialogResult result;
// MOD 2007.06.21 東都）高木 ORA-00921および排他エラー対応 START
//				if(sIUFlg == "I")
				if(s更新日時.Length == 0)
// MOD 2007.06.21 東都）高木 ORA-00921および排他エラー対応 END
				{
					result = MessageBox.Show("新規登録しますか？","登録",MessageBoxButtons.YesNo);
					if(result == DialogResult.Yes)
					{
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						texメッセージ.Text = "登録中．．．";

						if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
						sIUList = sv_goirai.Ins_irainusi(gsaユーザ,sData);
						Cursor = System.Windows.Forms.Cursors.Default;
						if(sIUList[0].Length == 4)
						{
							if(cBoxデフォルト.Checked == true)
								gs荷送人ＣＤ = tex依頼主コード.Text;
							tex依頼主コード.Text = "";
							btn取消_Click(sender,e);
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

						if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
// MOD 2006.08.10 東都）山本 依頼人情報「初期表示に使用する」を解除可能にする対応 START
//						sIUList = sv_goirai.Upd_irainusi(gsaユーザ,sData);
						sIUList = sv_goirai.Upd_irainusi1(gsaユーザ,sData);
// MOD 2006.08.10 東都）山本 依頼人情報「初期表示に使用する」を解除可能にする対応 END
						Cursor = System.Windows.Forms.Cursors.Default;
						if(sIUList[0].Length == 4)
						{
							if(cBoxデフォルト.Checked == true)
								gs荷送人ＣＤ = tex依頼主コード.Text;
// ADD 2006.08.10 東都）山本 依頼人情報「初期表示に使用する」を解除可能にする対応 START
							if(sData[22] == "1")
								gs荷送人ＣＤ = "";
// ADD 2006.08.10 東都）山本 依頼人情報「初期表示に使用する」を解除可能にする対応 END
							tex依頼主コード.Text = "";
							btn取消_Click(sender,e);
						}
						else
						{
							ビープ音();
							texメッセージ.Text = sIUList[0];
						}
					}
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

		private void btn依頼主実行_Click(object sender, System.EventArgs e)
		{
			// メッセージのクリア
			texメッセージ.Text = "";
			btn取消_Click(sender,e);

			// 空白除去
			tex依頼主コード.Text = tex依頼主コード.Text.Trim();

			if(!必須チェック(tex依頼主コード,"依頼主コード")) return;
			if(!半角チェック(tex依頼主コード,"依頼主コード")) return;

			s依頼主ＣＤ = tex依頼主コード.Text.Trim();
			btn依頼主実行_Click();

		}

		private void tex依頼主コード_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				if(tex依頼主コード.Text.Trim().Length == 0)
				{
					tex依頼主コード.Focus();
					btn依頼主検索_Click(sender, e);
				}
				else
				{
					btn依頼主実行_Click(sender, e);
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
				if(gsオプション[18].Equals("1")){
					tex住所１.Text       = tex住所１.Text.TrimEnd();
					tex住所２.Text       = tex住所２.Text.TrimEnd();
				}else{
					tex住所１.Text       = tex住所１.Text.Trim();
					tex住所２.Text       = tex住所２.Text.Trim();
				}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END

				// 入力チェック
				if(!半角チェック(tex郵便番号１,"郵便番号１")) return;
				if(!半角チェック(tex郵便番号２,"郵便番号２")) return;

				string s郵便番号 = tex郵便番号１.Text + tex郵便番号２.Text;
				if(s郵便番号.Length == 7)
				{
					if(tex住所１.Text.Length == 0 
						&& tex住所２.Text.Length == 0)
					{
						// カーソルを砂時計にする
						Cursor = System.Windows.Forms.Cursors.AppStarting;
						string[] sRet = {""};
						try
						{
							if(sv_address == null) sv_address = new is2address.Service1();
							texメッセージ.Text = "検索中．．．";
							sRet = sv_address.Get_byPostcode2(gsaユーザ,s郵便番号);
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
							if(sRet[2].Length > 40){
								tex住所１.Text     = sRet[2].Substring(0,20);
								tex住所２.Text     = sRet[2].Substring(20,20);
							}else if(sRet[2].Length > 20){
								tex住所１.Text     = sRet[2].Substring(0,20);
								tex住所２.Text     = sRet[2].Substring(20);
							}else{
								tex住所１.Text     = sRet[2];
								tex住所２.Text     = "";
							}
							texメッセージ.Text = "";
							//フォーカス設定
							tex住所２.Focus();
						}
						else
						{
							if(sRet[0].Equals("該当データがありません"))
								sRet[0] = "郵便番号が存在しません";
							texメッセージ.Text = sRet[0];
							//フォーカス設定
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

		private void tex依頼主コード_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString().Equals("*"))
			{
				btn依頼主検索.Focus();
				btn依頼主検索_Click(sender,e);
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
				btn住所検索.Focus();
				btn住所検索_Click(sender,e);
				e.Handled = true;
			}		
		}

		private void btn一覧表_Click(object sender, System.EventArgs e)
		{
			texメッセージ.Text = "ご依頼主一覧印刷中．．．";
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				if(sv_print == null) sv_print = new is2print.Service1();
				string[] sKey = new string[3];
				sKey[0] = gs会員ＣＤ;
				sKey[1] = gs部門ＣＤ;

				string[] sRet = new string[1];
				IEnumerator iEnum = sv_print.Get_ConsignorPrintData(gsaユーザ,sKey).GetEnumerator();
				iEnum.MoveNext();
				sRet = (string[])iEnum.Current;
// DEL 2005.05.11 東都）高木 「正常終了」は表示しない START
//				texメッセージ.Text = sRet[0];
// DEL 2005.05.11 東都）高木 「正常終了」は表示しない END
				if (sRet[0].Equals("正常終了"))
				{
					ご依頼主データ ds = new ご依頼主データ();

					int iCnt = 1;
					//データセットに値をセット
					while (iEnum.MoveNext())
					{
						string[] sList = new string[14];
						sList = (string[])iEnum.Current;
					
						ご依頼主データ.tableご依頼主Row tr = (ご依頼主データ.tableご依頼主Row)ds.tableご依頼主.NewRow();
						tr.BeginEdit();
						tr.番号     = iCnt++;
						tr.コード   = sList[0].Trim();
						tr.カナ略称 = sList[1].Trim();
						if(sList[2].Trim().Length == 0)
							tr.電話番号 = sList[3] + "-" + sList[4];
						else
							tr.電話番号 = "(" + sList[2] + ")" + sList[3] + "-" + sList[4];
						tr.郵便番号 = sList[5] + "-" + sList[6];
						tr.住所     = sList[7].Trim() + sList[8].Trim() + sList[9].Trim();
						tr.名前     = sList[10].Trim() + "  " + sList[11].Trim();
						tr.重量     = double.Parse(sList[12]);
						tr.得意先コード = sList[13].Trim();
						tr.得意先部課コード = sList[14].Trim();
						tr.得意先部課名 = sList[15].Trim();
//保留 MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
///						if(gsオプション[18].Equals("1")){
							tr.カナ略称 = sList[1].TrimEnd();
							tr.住所     = sList[7].TrimEnd() + sList[8].TrimEnd() + sList[9].TrimEnd();
							tr.名前     = sList[10].TrimEnd() + "  " + sList[11].TrimEnd();
							tr.得意先部課名 = sList[15].TrimEnd();
///						}
//保留 MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 START
						tr.重量入力制御 = (sList.Length > 17) ? sList[17].TrimEnd() : "0";
// MOD 2011.05.06 東都）高木 お客様ごとに重量入力制御 END
						tr.EndEdit();

						ds.tableご依頼主.Rows.Add(tr);					
					}
					
					ご依頼主帳票 cr = new ご依頼主帳票();
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

		private void nUD重量_Enter(object sender, System.EventArgs e)
		{
			if(nUD重量.Text.Length > 0) nUD重量.Select(0, nUD重量.Text.Length);
		}

// ADD 2005.05.24 東都）小童谷 フォーカス移動 START
		private void ご依頼主登録_Closed(object sender, System.EventArgs e)
		{
			tex依頼主コード.Text = " ";
			btn取消_Click(sender,e);
			tex依頼主コード.Focus();
		}
// ADD 2005.05.24 東都）小童谷 フォーカス移動 END

// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 START
		private void cmb請求先_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			tex請求先コード.Text     = "";
			tex請求先部課コード.Text = "";
			if(gsa請求先ＣＤ.Length > 0){
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック START
				if(cmb請求先.SelectedIndex < gsa請求先ＣＤ.Length){
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック END
					tex請求先コード.Text     = gsa請求先ＣＤ[cmb請求先.SelectedIndex];
					tex請求先部課コード.Text = gsa請求先部課ＣＤ[cmb請求先.SelectedIndex];
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック START
				}
// MOD 2010.09.07 東都）高木 請求先コードの存在チェック END
			}
		}
// MOD 2008.10.28 東都）高木 請求先コード表示機能の追加 END

// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 START
		private void btnＣＳＶ出力_Click(object sender, System.EventArgs e)
		{
// MOD 2010.09.22 東都）高木 ＣＳＶ出力：[キャンセル]選択時の障害修正 START
			texメッセージ.Text = "";
// MOD 2010.09.22 東都）高木 ＣＳＶ出力：[キャンセル]選択時の障害修正 END
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try{
				String[] sList;
				if(sv_goirai == null) sv_goirai = new is2goirai.Service1();
				sList = sv_goirai.Get_csvwrite(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
				this.Cursor = System.Windows.Forms.Cursors.Default;

				if(sList[0].Length == 4){
					// 見出し部の編集
					sList[0] = "\"荷送人コード\",\"電話番号\","
						+ "\"住所１\",\"住所２\",\"予備１\","
						+ "\"名前１\",\"名前２\",\"予備２\","
						+ "\"郵便番号\",\"カナ略称\",\"才数\",\"重量\",\"メールアドレス\","
						+ "\"請求先コード\",\"請求先部課コード\""
						;

					// デフォルトのフォルダをデスクトップフォルダにする
					saveFileDialog1.InitialDirectory
						= Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
					saveFileDialog1.Filter = "ＣＳＶファイル (*.csv)|*.csv";
					byte[] bSJIS;
					if(saveFileDialog1.ShowDialog(this) == DialogResult.OK){
						System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
						for(int iCnt = 0; iCnt < sList.Length; iCnt++){
							bSJIS = toSJIS(sList[iCnt]);
							fs.Write(bSJIS, 0 , bSJIS.Length);
						}
						fs.Close();
					}
					texメッセージ.Text = "";
				}else{
					ビープ音();
					texメッセージ.Text = sList[0];
				}
			}catch (System.Net.WebException){
				this.Cursor = System.Windows.Forms.Cursors.Default;
				texメッセージ.Text = gs通信エラー;
				ビープ音();
			}catch(Exception ex){
				this.Cursor = System.Windows.Forms.Cursors.Default;
				texメッセージ.Text = ex.Message;
			}
			tex依頼主コード.Focus();
		}
// MOD 2010.09.08 東都）高木 ＣＳＶ出力機能の追加 END

	}
}
