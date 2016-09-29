using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [出荷ラベルイメージ印刷]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// ADD 2015.11.09 BEVAS）松本 新規作成（出荷ラベルイメージ印刷画面追加）
	//--------------------------------------------------------------------------
	public class 送り状控え印刷 : 共通フォーム
	{
		public short OldRow = 0;
		private short nSrow = 0;
		private short nErow = 0;
		private short nWork = 0;
		private string s届け先ＣＤ;
		private string s届け先名;
		private string s依頼主ＣＤ;
		private string s依頼主名;

		private string[] s出荷一覧;
		private int      i現在頁数;
		private string[] sa状態ＣＤ;

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab日時;
		private 共通テキストボックス tex届け先コード;
		private System.Windows.Forms.Label lab届け先;
		private System.Windows.Forms.TextBox tex重量合計;
		private System.Windows.Forms.TextBox tex個数合計;
		private System.Windows.Forms.Label lab登録件数;
		private System.Windows.Forms.TextBox tex登録件数;
		private System.Windows.Forms.Label lab個数合計;
		private System.Windows.Forms.Label lab重量合計;
		private System.Windows.Forms.Label lab依頼主;
		private 共通テキストボックス tex依頼主コード;
		private System.Windows.Forms.Label lab状態;
		private System.Windows.Forms.TextBox tex依頼主名;
		private System.Windows.Forms.TextBox tex届け先名;
		private System.Windows.Forms.Label lab利用部門;
		private System.Windows.Forms.Label lab出荷照会タイトル;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.Button btn届け先検索;
		private System.Windows.Forms.Button btn依頼主検索;
		private System.Windows.Forms.Button btn出荷検索;
		private System.Windows.Forms.Button btn再発行;
		private System.Windows.Forms.TextBox tex利用部門;
		private System.Windows.Forms.Label lab出荷日;
		private AxGTABLE32V2Lib.AxGTable32 axGT出荷一覧;
		private System.Windows.Forms.DateTimePicker dt開始日付;
		private System.Windows.Forms.DateTimePicker dt終了日付;
		private System.Windows.Forms.ComboBox cmb状態;
		private System.Windows.Forms.ComboBox cmb出荷日;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label labログイン集荷店;
		private System.Windows.Forms.TextBox texログイン集荷店;
		private System.Windows.Forms.Label lab頁番号;
		private System.Windows.Forms.Button btn次頁;
		private System.Windows.Forms.Button btn前頁;
		private System.Windows.Forms.Label lab送り状番号;
		private System.Windows.Forms.Label labお客様番号;
		private System.Windows.Forms.Label label2;
		private IS2Client.共通テキストボックス texお客様番号開始;
		private IS2Client.共通テキストボックス texお客様番号終了;
		private IS2Client.共通テキストボックス tex送り状番号開始;
		private System.Windows.Forms.Label label3;
		private IS2Client.共通テキストボックス tex送り状番号終了;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.ComponentModel.IContainer components;

		public 送り状控え印刷()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			ＤＰＩ表示サイズ変換();
			this.axGT出荷一覧.Size = new System.Drawing.Size(732, 282);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(送り状控え印刷));
            this.tex届け先コード = new IS2Client.共通テキストボックス();
            this.lab届け先 = new System.Windows.Forms.Label();
            this.btn届け先検索 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.axGT出荷一覧 = new AxGTABLE32V2Lib.AxGTable32();
            this.tex重量合計 = new System.Windows.Forms.TextBox();
            this.tex個数合計 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.lab登録件数 = new System.Windows.Forms.Label();
            this.tex登録件数 = new System.Windows.Forms.TextBox();
            this.lab個数合計 = new System.Windows.Forms.Label();
            this.lab重量合計 = new System.Windows.Forms.Label();
            this.lab依頼主 = new System.Windows.Forms.Label();
            this.btn依頼主検索 = new System.Windows.Forms.Button();
            this.tex依頼主コード = new IS2Client.共通テキストボックス();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tex送り状番号終了 = new IS2Client.共通テキストボックス();
            this.label3 = new System.Windows.Forms.Label();
            this.texお客様番号終了 = new IS2Client.共通テキストボックス();
            this.label2 = new System.Windows.Forms.Label();
            this.texお客様番号開始 = new IS2Client.共通テキストボックス();
            this.labお客様番号 = new System.Windows.Forms.Label();
            this.tex送り状番号開始 = new IS2Client.共通テキストボックス();
            this.lab送り状番号 = new System.Windows.Forms.Label();
            this.cmb状態 = new System.Windows.Forms.ComboBox();
            this.lab状態 = new System.Windows.Forms.Label();
            this.cmb出荷日 = new System.Windows.Forms.ComboBox();
            this.btn出荷検索 = new System.Windows.Forms.Button();
            this.tex依頼主名 = new System.Windows.Forms.TextBox();
            this.tex届け先名 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dt開始日付 = new System.Windows.Forms.DateTimePicker();
            this.lab出荷日 = new System.Windows.Forms.Label();
            this.dt終了日付 = new System.Windows.Forms.DateTimePicker();
            this.lab頁番号 = new System.Windows.Forms.Label();
            this.btn次頁 = new System.Windows.Forms.Button();
            this.btn前頁 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.labログイン集荷店 = new System.Windows.Forms.Label();
            this.texログイン集荷店 = new System.Windows.Forms.TextBox();
            this.lab利用部門 = new System.Windows.Forms.Label();
            this.tex利用部門 = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lab日時 = new System.Windows.Forms.Label();
            this.lab出荷照会タイトル = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btn再発行 = new System.Windows.Forms.Button();
            this.texメッセージ = new System.Windows.Forms.TextBox();
            this.btn閉じる = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ds送り状)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGT出荷一覧)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tex届け先コード
            // 
            this.tex届け先コード.BackColor = System.Drawing.SystemColors.Window;
            this.tex届け先コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex届け先コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tex届け先コード.Location = new System.Drawing.Point(94, 2);
            this.tex届け先コード.MaxLength = 15;
            this.tex届け先コード.Name = "tex届け先コード";
            this.tex届け先コード.Size = new System.Drawing.Size(190, 23);
            this.tex届け先コード.TabIndex = 0;
            this.tex届け先コード.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex届け先コード_KeyDown);
            this.tex届け先コード.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex届け先コード_KeyPress);
            this.tex届け先コード.LostFocus += new System.EventHandler(this.tex届け先コード_LostFocus);
            // 
            // lab届け先
            // 
            this.lab届け先.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab届け先.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab届け先.Location = new System.Drawing.Point(12, 6);
            this.lab届け先.Name = "lab届け先";
            this.lab届け先.Size = new System.Drawing.Size(70, 16);
            this.lab届け先.TabIndex = 8;
            this.lab届け先.Text = "お届け先";
            // 
            // btn届け先検索
            // 
            this.btn届け先検索.BackColor = System.Drawing.Color.SteelBlue;
            this.btn届け先検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn届け先検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn届け先検索.ForeColor = System.Drawing.Color.White;
            this.btn届け先検索.Location = new System.Drawing.Point(286, 4);
            this.btn届け先検索.Name = "btn届け先検索";
            this.btn届け先検索.Size = new System.Drawing.Size(64, 22);
            this.btn届け先検索.TabIndex = 1;
            this.btn届け先検索.TabStop = false;
            this.btn届け先検索.Text = "アドレス帳";
            this.btn届け先検索.UseVisualStyleBackColor = false;
            this.btn届け先検索.Click += new System.EventHandler(this.btn届け先検索_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Honeydew;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.axGT出荷一覧);
            this.panel2.Controls.Add(this.tex重量合計);
            this.panel2.Controls.Add(this.tex個数合計);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.lab登録件数);
            this.panel2.Controls.Add(this.tex登録件数);
            this.panel2.Controls.Add(this.lab個数合計);
            this.panel2.Controls.Add(this.lab重量合計);
            this.panel2.Location = new System.Drawing.Point(0, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(764, 316);
            this.panel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(546, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 28);
            this.label5.TabIndex = 56;
            this.label5.Text = "※表示の運賃は概算運賃であり、変更されることがあります。";
            // 
            // axGT出荷一覧
            // 
            this.axGT出荷一覧.DataSource = null;
            this.axGT出荷一覧.Location = new System.Drawing.Point(28, 30);
            this.axGT出荷一覧.Name = "axGT出荷一覧";
            this.axGT出荷一覧.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT出荷一覧.OcxState")));
            this.axGT出荷一覧.Size = new System.Drawing.Size(732, 282);
            this.axGT出荷一覧.TabIndex = 51;
            this.axGT出荷一覧.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT出荷一覧_CurPlaceChanged);
            this.axGT出荷一覧.CelClick += new AxGTABLE32V2Lib._DGTable32Events_CelClickEventHandler(this.axGT出荷一覧_CelClick);
            this.axGT出荷一覧.KeyDownEvent += new AxGTABLE32V2Lib._DGTable32Events_KeyDownEventHandler(this.axGT出荷一覧_KeyDownEvent);
            // 
            // tex重量合計
            // 
            this.tex重量合計.BackColor = System.Drawing.SystemColors.Window;
            this.tex重量合計.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex重量合計.Location = new System.Drawing.Point(382, 4);
            this.tex重量合計.Name = "tex重量合計";
            this.tex重量合計.ReadOnly = true;
            this.tex重量合計.Size = new System.Drawing.Size(86, 23);
            this.tex重量合計.TabIndex = 50;
            this.tex重量合計.TabStop = false;
            this.tex重量合計.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tex個数合計
            // 
            this.tex個数合計.BackColor = System.Drawing.SystemColors.Window;
            this.tex個数合計.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex個数合計.Location = new System.Drawing.Point(246, 4);
            this.tex個数合計.Name = "tex個数合計";
            this.tex個数合計.ReadOnly = true;
            this.tex個数合計.Size = new System.Drawing.Size(70, 23);
            this.tex個数合計.TabIndex = 49;
            this.tex個数合計.TabStop = false;
            this.tex個数合計.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.label21.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(0, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(22, 316);
            this.label21.TabIndex = 3;
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab登録件数
            // 
            this.lab登録件数.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab登録件数.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab登録件数.ForeColor = System.Drawing.Color.Blue;
            this.lab登録件数.Location = new System.Drawing.Point(62, 6);
            this.lab登録件数.Name = "lab登録件数";
            this.lab登録件数.Size = new System.Drawing.Size(60, 18);
            this.lab登録件数.TabIndex = 4;
            this.lab登録件数.Text = "登録件数";
            this.lab登録件数.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tex登録件数
            // 
            this.tex登録件数.BackColor = System.Drawing.SystemColors.Window;
            this.tex登録件数.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex登録件数.Location = new System.Drawing.Point(122, 4);
            this.tex登録件数.Name = "tex登録件数";
            this.tex登録件数.ReadOnly = true;
            this.tex登録件数.Size = new System.Drawing.Size(54, 23);
            this.tex登録件数.TabIndex = 46;
            this.tex登録件数.TabStop = false;
            this.tex登録件数.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lab個数合計
            // 
            this.lab個数合計.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab個数合計.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab個数合計.ForeColor = System.Drawing.Color.Blue;
            this.lab個数合計.Location = new System.Drawing.Point(186, 6);
            this.lab個数合計.Name = "lab個数合計";
            this.lab個数合計.Size = new System.Drawing.Size(60, 18);
            this.lab個数合計.TabIndex = 6;
            this.lab個数合計.Text = "個数合計";
            this.lab個数合計.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab重量合計
            // 
            this.lab重量合計.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab重量合計.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab重量合計.ForeColor = System.Drawing.Color.Blue;
            this.lab重量合計.Location = new System.Drawing.Point(322, 6);
            this.lab重量合計.Name = "lab重量合計";
            this.lab重量合計.Size = new System.Drawing.Size(60, 18);
            this.lab重量合計.TabIndex = 8;
            this.lab重量合計.Text = "重量合計";
            this.lab重量合計.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab依頼主
            // 
            this.lab依頼主.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab依頼主.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab依頼主.Location = new System.Drawing.Point(12, 32);
            this.lab依頼主.Name = "lab依頼主";
            this.lab依頼主.Size = new System.Drawing.Size(70, 16);
            this.lab依頼主.TabIndex = 8;
            this.lab依頼主.Text = "ご依頼主";
            // 
            // btn依頼主検索
            // 
            this.btn依頼主検索.BackColor = System.Drawing.Color.SteelBlue;
            this.btn依頼主検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn依頼主検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn依頼主検索.ForeColor = System.Drawing.Color.White;
            this.btn依頼主検索.Location = new System.Drawing.Point(286, 30);
            this.btn依頼主検索.Name = "btn依頼主検索";
            this.btn依頼主検索.Size = new System.Drawing.Size(64, 22);
            this.btn依頼主検索.TabIndex = 3;
            this.btn依頼主検索.TabStop = false;
            this.btn依頼主検索.Text = "検索";
            this.btn依頼主検索.UseVisualStyleBackColor = false;
            this.btn依頼主検索.Click += new System.EventHandler(this.btn依頼主検索_Click);
            // 
            // tex依頼主コード
            // 
            this.tex依頼主コード.BackColor = System.Drawing.SystemColors.Window;
            this.tex依頼主コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex依頼主コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tex依頼主コード.Location = new System.Drawing.Point(94, 28);
            this.tex依頼主コード.MaxLength = 12;
            this.tex依頼主コード.Name = "tex依頼主コード";
            this.tex依頼主コード.Size = new System.Drawing.Size(154, 23);
            this.tex依頼主コード.TabIndex = 2;
            this.tex依頼主コード.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex依頼主コード_KeyDown);
            this.tex依頼主コード.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tex依頼主コード_KeyPress);
            this.tex依頼主コード.LostFocus += new System.EventHandler(this.tex依頼主コード_LostFocus);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Honeydew;
            this.panel5.Controls.Add(this.tex送り状番号終了);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.texお客様番号終了);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.texお客様番号開始);
            this.panel5.Controls.Add(this.labお客様番号);
            this.panel5.Controls.Add(this.tex送り状番号開始);
            this.panel5.Controls.Add(this.lab送り状番号);
            this.panel5.Controls.Add(this.cmb状態);
            this.panel5.Controls.Add(this.lab状態);
            this.panel5.Controls.Add(this.cmb出荷日);
            this.panel5.Controls.Add(this.btn出荷検索);
            this.panel5.Controls.Add(this.tex依頼主名);
            this.panel5.Controls.Add(this.tex届け先名);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.dt開始日付);
            this.panel5.Controls.Add(this.lab出荷日);
            this.panel5.Controls.Add(this.lab届け先);
            this.panel5.Controls.Add(this.btn届け先検索);
            this.panel5.Controls.Add(this.tex届け先コード);
            this.panel5.Controls.Add(this.lab依頼主);
            this.panel5.Controls.Add(this.tex依頼主コード);
            this.panel5.Controls.Add(this.btn依頼主検索);
            this.panel5.Controls.Add(this.dt終了日付);
            this.panel5.Location = new System.Drawing.Point(1, 8);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(589, 134);
            this.panel5.TabIndex = 0;
            // 
            // tex送り状番号終了
            // 
            this.tex送り状番号終了.BackColor = System.Drawing.SystemColors.Window;
            this.tex送り状番号終了.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex送り状番号終了.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tex送り状番号終了.Location = new System.Drawing.Point(260, 80);
            this.tex送り状番号終了.MaxLength = 13;
            this.tex送り状番号終了.Name = "tex送り状番号終了";
            this.tex送り状番号終了.Size = new System.Drawing.Size(142, 23);
            this.tex送り状番号終了.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.LimeGreen;
            this.label3.Location = new System.Drawing.Point(238, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 16);
            this.label3.TabIndex = 77;
            this.label3.Text = "～";
            // 
            // texお客様番号終了
            // 
            this.texお客様番号終了.BackColor = System.Drawing.SystemColors.Window;
            this.texお客様番号終了.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.texお客様番号終了.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.texお客様番号終了.Location = new System.Drawing.Point(304, 106);
            this.texお客様番号終了.MaxLength = 20;
            this.texお客様番号終了.Name = "texお客様番号終了";
            this.texお客様番号終了.Size = new System.Drawing.Size(190, 23);
            this.texお客様番号終了.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.LimeGreen;
            this.label2.Location = new System.Drawing.Point(284, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 16);
            this.label2.TabIndex = 75;
            this.label2.Text = "～";
            // 
            // texお客様番号開始
            // 
            this.texお客様番号開始.BackColor = System.Drawing.SystemColors.Window;
            this.texお客様番号開始.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.texお客様番号開始.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.texお客様番号開始.Location = new System.Drawing.Point(94, 106);
            this.texお客様番号開始.MaxLength = 20;
            this.texお客様番号開始.Name = "texお客様番号開始";
            this.texお客様番号開始.Size = new System.Drawing.Size(190, 23);
            this.texお客様番号開始.TabIndex = 9;
            // 
            // labお客様番号
            // 
            this.labお客様番号.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labお客様番号.ForeColor = System.Drawing.Color.LimeGreen;
            this.labお客様番号.Location = new System.Drawing.Point(8, 110);
            this.labお客様番号.Name = "labお客様番号";
            this.labお客様番号.Size = new System.Drawing.Size(86, 16);
            this.labお客様番号.TabIndex = 73;
            this.labお客様番号.Text = "お客様番号";
            // 
            // tex送り状番号開始
            // 
            this.tex送り状番号開始.BackColor = System.Drawing.SystemColors.Window;
            this.tex送り状番号開始.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex送り状番号開始.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tex送り状番号開始.Location = new System.Drawing.Point(94, 80);
            this.tex送り状番号開始.MaxLength = 13;
            this.tex送り状番号開始.Name = "tex送り状番号開始";
            this.tex送り状番号開始.Size = new System.Drawing.Size(142, 23);
            this.tex送り状番号開始.TabIndex = 7;
            // 
            // lab送り状番号
            // 
            this.lab送り状番号.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab送り状番号.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab送り状番号.Location = new System.Drawing.Point(12, 84);
            this.lab送り状番号.Name = "lab送り状番号";
            this.lab送り状番号.Size = new System.Drawing.Size(82, 16);
            this.lab送り状番号.TabIndex = 71;
            this.lab送り状番号.Text = "送り状番号";
            // 
            // cmb状態
            // 
            this.cmb状態.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb状態.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb状態.Location = new System.Drawing.Point(488, 54);
            this.cmb状態.Name = "cmb状態";
            this.cmb状態.Size = new System.Drawing.Size(76, 24);
            this.cmb状態.TabIndex = 6;
            this.cmb状態.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb状態_KeyDown);
            // 
            // lab状態
            // 
            this.lab状態.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab状態.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab状態.Location = new System.Drawing.Point(412, 58);
            this.lab状態.Name = "lab状態";
            this.lab状態.Size = new System.Drawing.Size(76, 16);
            this.lab状態.TabIndex = 13;
            this.lab状態.Text = "輸送状況";
            // 
            // cmb出荷日
            // 
            this.cmb出荷日.BackColor = System.Drawing.Color.White;
            this.cmb出荷日.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb出荷日.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb出荷日.ForeColor = System.Drawing.Color.LimeGreen;
            this.cmb出荷日.Items.AddRange(new object[] {
            "出荷日",
            "登録日"});
            this.cmb出荷日.Location = new System.Drawing.Point(12, 54);
            this.cmb出荷日.Name = "cmb出荷日";
            this.cmb出荷日.Size = new System.Drawing.Size(78, 24);
            this.cmb出荷日.TabIndex = 4;
            // 
            // btn出荷検索
            // 
            this.btn出荷検索.BackColor = System.Drawing.Color.SteelBlue;
            this.btn出荷検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn出荷検索.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn出荷検索.ForeColor = System.Drawing.Color.White;
            this.btn出荷検索.Location = new System.Drawing.Point(504, 94);
            this.btn出荷検索.Name = "btn出荷検索";
            this.btn出荷検索.Size = new System.Drawing.Size(76, 36);
            this.btn出荷検索.TabIndex = 11;
            this.btn出荷検索.TabStop = false;
            this.btn出荷検索.Text = "照会";
            this.btn出荷検索.UseVisualStyleBackColor = false;
            this.btn出荷検索.Click += new System.EventHandler(this.btn出荷検索_Click);
            // 
            // tex依頼主名
            // 
            this.tex依頼主名.BackColor = System.Drawing.Color.Honeydew;
            this.tex依頼主名.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tex依頼主名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex依頼主名.Location = new System.Drawing.Point(354, 32);
            this.tex依頼主名.Name = "tex依頼主名";
            this.tex依頼主名.ReadOnly = true;
            this.tex依頼主名.Size = new System.Drawing.Size(224, 16);
            this.tex依頼主名.TabIndex = 12;
            this.tex依頼主名.TabStop = false;
            // 
            // tex届け先名
            // 
            this.tex届け先名.BackColor = System.Drawing.Color.Honeydew;
            this.tex届け先名.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tex届け先名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex届け先名.Location = new System.Drawing.Point(354, 6);
            this.tex届け先名.Name = "tex届け先名";
            this.tex届け先名.ReadOnly = true;
            this.tex届け先名.Size = new System.Drawing.Size(224, 16);
            this.tex届け先名.TabIndex = 11;
            this.tex届け先名.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(238, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "～";
            // 
            // dt開始日付
            // 
            this.dt開始日付.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dt開始日付.Location = new System.Drawing.Point(94, 54);
            this.dt開始日付.Name = "dt開始日付";
            this.dt開始日付.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dt開始日付.Size = new System.Drawing.Size(144, 23);
            this.dt開始日付.TabIndex = 4;
            // 
            // lab出荷日
            // 
            this.lab出荷日.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab出荷日.ForeColor = System.Drawing.Color.Green;
            this.lab出荷日.Location = new System.Drawing.Point(12, 58);
            this.lab出荷日.Name = "lab出荷日";
            this.lab出荷日.Size = new System.Drawing.Size(70, 16);
            this.lab出荷日.TabIndex = 6;
            this.lab出荷日.Text = "出荷日";
            // 
            // dt終了日付
            // 
            this.dt終了日付.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dt終了日付.Location = new System.Drawing.Point(260, 54);
            this.dt終了日付.Name = "dt終了日付";
            this.dt終了日付.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dt終了日付.Size = new System.Drawing.Size(144, 23);
            this.dt終了日付.TabIndex = 5;
            // 
            // lab頁番号
            // 
            this.lab頁番号.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab頁番号.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab頁番号.Location = new System.Drawing.Point(686, 166);
            this.lab頁番号.Name = "lab頁番号";
            this.lab頁番号.Size = new System.Drawing.Size(48, 14);
            this.lab頁番号.TabIndex = 70;
            this.lab頁番号.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn次頁
            // 
            this.btn次頁.BackColor = System.Drawing.Color.SteelBlue;
            this.btn次頁.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn次頁.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn次頁.ForeColor = System.Drawing.Color.White;
            this.btn次頁.Location = new System.Drawing.Point(734, 162);
            this.btn次頁.Name = "btn次頁";
            this.btn次頁.Size = new System.Drawing.Size(48, 22);
            this.btn次頁.TabIndex = 69;
            this.btn次頁.Text = "次頁";
            this.btn次頁.UseVisualStyleBackColor = false;
            // 
            // btn前頁
            // 
            this.btn前頁.BackColor = System.Drawing.Color.SteelBlue;
            this.btn前頁.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn前頁.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn前頁.ForeColor = System.Drawing.Color.White;
            this.btn前頁.Location = new System.Drawing.Point(638, 162);
            this.btn前頁.Name = "btn前頁";
            this.btn前頁.Size = new System.Drawing.Size(48, 22);
            this.btn前頁.TabIndex = 68;
            this.btn前頁.Text = "前頁";
            this.btn前頁.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.PaleGreen;
            this.panel6.Controls.Add(this.labログイン集荷店);
            this.panel6.Controls.Add(this.texログイン集荷店);
            this.panel6.Controls.Add(this.lab利用部門);
            this.panel6.Controls.Add(this.tex利用部門);
            this.panel6.Location = new System.Drawing.Point(0, 26);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(810, 26);
            this.panel6.TabIndex = 12;
            // 
            // labログイン集荷店
            // 
            this.labログイン集荷店.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labログイン集荷店.ForeColor = System.Drawing.Color.LimeGreen;
            this.labログイン集荷店.Location = new System.Drawing.Point(694, 8);
            this.labログイン集荷店.Name = "labログイン集荷店";
            this.labログイン集荷店.Size = new System.Drawing.Size(48, 14);
            this.labログイン集荷店.TabIndex = 13;
            this.labログイン集荷店.Text = "ログイン";
            // 
            // texログイン集荷店
            // 
            this.texログイン集荷店.BackColor = System.Drawing.Color.PaleGreen;
            this.texログイン集荷店.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.texログイン集荷店.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.texログイン集荷店.ForeColor = System.Drawing.Color.LimeGreen;
            this.texログイン集荷店.Location = new System.Drawing.Point(744, 6);
            this.texログイン集荷店.Name = "texログイン集荷店";
            this.texログイン集荷店.ReadOnly = true;
            this.texログイン集荷店.Size = new System.Drawing.Size(42, 16);
            this.texログイン集荷店.TabIndex = 12;
            this.texログイン集荷店.TabStop = false;
            this.texログイン集荷店.Text = "999";
            // 
            // lab利用部門
            // 
            this.lab利用部門.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.tex利用部門.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.panel7.Controls.Add(this.lab日時);
            this.panel7.Controls.Add(this.lab出荷照会タイトル);
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(792, 26);
            this.panel7.TabIndex = 13;
            // 
            // lab日時
            // 
            this.lab日時.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab日時.ForeColor = System.Drawing.Color.White;
            this.lab日時.Location = new System.Drawing.Point(674, 8);
            this.lab日時.Name = "lab日時";
            this.lab日時.Size = new System.Drawing.Size(112, 14);
            this.lab日時.TabIndex = 1;
            this.lab日時.Text = "2005/xx/xx 12:00:00";
            // 
            // lab出荷照会タイトル
            // 
            this.lab出荷照会タイトル.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab出荷照会タイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab出荷照会タイトル.ForeColor = System.Drawing.Color.White;
            this.lab出荷照会タイトル.Location = new System.Drawing.Point(12, 2);
            this.lab出荷照会タイトル.Name = "lab出荷照会タイトル";
            this.lab出荷照会タイトル.Size = new System.Drawing.Size(264, 24);
            this.lab出荷照会タイトル.TabIndex = 0;
            this.lab出荷照会タイトル.Text = "出荷ラベルイメージ印刷";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.PaleGreen;
            this.panel8.Controls.Add(this.btn再発行);
            this.panel8.Controls.Add(this.texメッセージ);
            this.panel8.Controls.Add(this.btn閉じる);
            this.panel8.Location = new System.Drawing.Point(0, 516);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(792, 58);
            this.panel8.TabIndex = 2;
            // 
            // btn再発行
            // 
            this.btn再発行.ForeColor = System.Drawing.Color.Blue;
            this.btn再発行.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn再発行.Location = new System.Drawing.Point(118, 6);
            this.btn再発行.Name = "btn再発行";
            this.btn再発行.Size = new System.Drawing.Size(60, 48);
            this.btn再発行.TabIndex = 1;
            this.btn再発行.Text = "イメージ　　印刷";
            this.btn再発行.Click += new System.EventHandler(this.btn再発行_Click);
            // 
            // texメッセージ
            // 
            this.texメッセージ.BackColor = System.Drawing.Color.PaleGreen;
            this.texメッセージ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.texメッセージ.ForeColor = System.Drawing.Color.Red;
            this.texメッセージ.Location = new System.Drawing.Point(446, 4);
            this.texメッセージ.Multiline = true;
            this.texメッセージ.Name = "texメッセージ";
            this.texメッセージ.ReadOnly = true;
            this.texメッセージ.Size = new System.Drawing.Size(344, 50);
            this.texメッセージ.TabIndex = 1;
            this.texメッセージ.TabStop = false;
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
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.ForeColor = System.Drawing.Color.Green;
            this.groupBox1.Location = new System.Drawing.Point(38, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Location = new System.Drawing.Point(16, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(768, 324);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(638, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 28);
            this.label4.TabIndex = 71;
            this.label4.Text = "※過去４５日間の出荷データを照会可能です。";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(638, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 28);
            this.label6.TabIndex = 72;
            this.label6.Text = "※未発行の出荷データは、印刷できません。";
            // 
            // 送り状控え印刷
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(792, 580);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lab頁番号);
            this.Controls.Add(this.btn次頁);
            this.Controls.Add(this.btn前頁);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 607);
            this.Name = "送り状控え印刷";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "is-2 出荷ラベルイメージ印刷";
            this.Closed += new System.EventHandler(this.出荷照会_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Onエンター移動);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Onエンターキャンセル);
            ((System.ComponentModel.ISupportInitialize)(this.ds送り状)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGT出荷一覧)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
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
		private void Form1_Load(object sender, System.EventArgs e)
		{
			// ヘッダー項目の設定
			if(gs利用者部門店所ＣＤ == null || gs利用者部門店所ＣＤ.Length == 0)
			{
				texログイン集荷店.Text = "";
			}
			else
			{
				texログイン集荷店.Text = gs利用者部門店所ＣＤ;
			}

			tex利用部門.Text = gs部門ＣＤ + " " + gs部門名;

			// 日時の初期設定
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled = true;

			// 状態コンボの初期設定
			// 本画面用状態リスト作成（発行済を除外するため）
			sa状態ＣＤ = new string[gsa状態ＣＤ.Length - 1];
			bool remove_flg = false; // 除外項目があったかどうかを判定するフラグ
			int storeId = 0;         // 本画面用状態リストの格納用Index
			for(int i = 0; i < gsa状態ＣＤ.Length; i++)
			{
				storeId = i;
				if(remove_flg)
				{
					// 除外された後の格納用Indexは、gsa状態ＣＤの現在処理Indexよりも『1』小さくする
					// （IndexOutOfRangeExceptionを防ぐ為）
					storeId = i - 1;
				}

				if(gsa状態ＣＤ[i] == "00")
				{
					//状態が[全て]の場合は、状態ＣＤを『aa』とする
					sa状態ＣＤ[storeId] = "aa";
					continue;
				}
				else if(gsa状態ＣＤ[i] == "01")
				{
					//状態が[発行済]の場合は、除外項目発見フラグをＯＮにする
					remove_flg = true;
					continue;
				}

				//状態が[発行済]以外のものを格納する
				sa状態ＣＤ[storeId] = gsa状態ＣＤ[i];
				
			}
			// 初期値設定
			cmb状態.Items.Clear();
			cmb状態.Items.AddRange(gsa状態名);
			cmb状態.Items.RemoveAt(1); // [発行済]を除外
			cmb状態.SelectedIndex = 0;

			// 出荷日コンボの初期値設定
			cmb出荷日.SelectedIndex = 0;

			// 出荷日の初期設定（当日）
			部門出荷日情報更新();
			dt開始日付.Value   = gdt出荷日;
			dt終了日付.Value   = gdt出荷日;

			項目初期化();

			axGT出荷一覧.Cols = 24;
			axGT出荷一覧.Rows = 10;
			axGT出荷一覧.ColSep = "|";

			axGT出荷一覧.set_RowsText(0, "||ﾗﾍﾞﾙ|出荷日|お届け先|個数|重量|送り状番号|お客様番号|指定日|輸送状況|"
										+"配完日付・時刻|輸送商品／記事・品名|運賃|保険料|登録日|"
										+"ジャーナルＮＯ|日|出日|登録者||||||");
			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|2.6|3|6.0|9.8|5.3|4.6|"
										+"8|12.0|5.5|5.5|4.2|"
										+"0|0|0|0|0|0|0|0|0|";
			axGT出荷一覧.ColsAlignHorz = "1|1|1|1|0|2|2|0|0|1|1|"
										+"1|0|2|2|1|"
										+"0|0|0|0|0|0|0|0|0|";
			axGT出荷一覧.set_CelForeColor(axGT出荷一覧.CaretRow,0,0x98FB98);  //BGR
			axGT出荷一覧.set_CelBackColor(axGT出荷一覧.CaretRow,0,0x006000);

			for(short i = 1; i <= axGT出荷一覧.Rows; i++ )
			{
				axGT出荷一覧.set_CelHeight(i,0,2.3);
				axGT出荷一覧.set_CelAlignVert(i,4,3);
				axGT出荷一覧.set_CelAlignVert(i,7,3);
				//輸送商品／記事・品名
				axGT出荷一覧.set_CelAlignVert(i,12,3);
			}

			btn前頁.Visible = false;
			btn次頁.Visible = false;
			lab頁番号.Visible = false;
		}

		private void 項目初期化()
		{
			tex届け先コード.Text = "";
			tex届け先名.Text     = "";
			tex依頼主コード.Text = "";
			tex依頼主名.Text     = "";
			tex送り状番号開始.Text = "";
			tex送り状番号終了.Text = "";
			texお客様番号開始.Text = "";
			texお客様番号終了.Text = "";
			tex登録件数.Text     = "";
			tex個数合計.Text     = "";
			tex重量合計.Text     = "";
			texメッセージ.Text   = "";
			axGT出荷一覧.Clear();
			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|2.6|3|6.0|9.8|5.3|4.6|"
										+"8|12.0|5.5|5.5|4.2|"
										+"0|0|0|0|0|0|0|0|0|";
			axGT出荷一覧.CaretRow = 1;
			axGT出荷一覧.CaretCol = 2;
			axGT出荷一覧_CurPlaceChanged(null,null);
		}

		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btn届け先検索_Click(object sender, System.EventArgs e)
		{
			tex届け先コード.Text = tex届け先コード.Text.Trim();
			if(!半角チェック(tex届け先コード,"届け先コード")) return;

			if(g届先検索 == null)
			{
				g届先検索 = new お届け先検索();
			}
			g届先検索.Left = this.Left;
			g届先検索.Top = this.Top;
			g届先検索.sTcode = "";
			g届先検索.ShowDialog();

			s届け先ＣＤ = g届先検索.sTcode;
			s届け先名   = g届先検索.sTname;
			if(s届け先ＣＤ.Length > 0)
			{
				tex届け先コード.Text = s届け先ＣＤ;
				tex届け先名.Text = s届け先名;
				tex依頼主コード.Focus();
			}
			else
				tex届け先コード.Focus();
		}

		private void btn依頼主検索_Click(object sender, System.EventArgs e)
		{
			tex依頼主コード.Text = tex依頼主コード.Text.Trim();
			if(!半角チェック(tex依頼主コード,"依頼主コード")) return;

			if(g依頼検索 == null)
			{
				g依頼検索 = new ご依頼主検索();
			}
			g依頼検索.Left = this.Left;
			g依頼検索.Top = this.Top;
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

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

		private void axGT出荷一覧_CurPlaceChanged(object sender, AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEvent e)
		{
			axGT出荷一覧.set_CelForeColor(OldRow,0,0);
			axGT出荷一覧.set_CelBackColor(OldRow,0,0xFFFFFF);
			if(axGT出荷一覧.SelStartRow == axGT出荷一覧.SelEndRow)
			{
				if(nSrow > nErow)
				{
					nWork = nSrow;
					nSrow = nErow;
					nErow = nWork;
				}
				for(short nCnt = nSrow; nCnt <= nErow; nCnt++)
				{
					axGT出荷一覧.set_CelForeColor(nCnt,0,0);
					axGT出荷一覧.set_CelBackColor(nCnt,0,0xFFFFFF);
				}
			}

			short n開始 = axGT出荷一覧.SelStartRow;
			short n終了 = axGT出荷一覧.SelEndRow;
			if(n開始 > n終了){
				n開始 = axGT出荷一覧.SelEndRow;
				n終了 = axGT出荷一覧.SelStartRow;
			}

			for(short n行 = n開始; n行 <= n終了; n行++){
				axGT出荷一覧.set_CelForeColor(n行,0,0x98FB98);
				axGT出荷一覧.set_CelBackColor(n行,0,0x006000);
			}

			axGT出荷一覧.set_CelForeColor(axGT出荷一覧.CaretRow,0,0x98FB98);
			axGT出荷一覧.set_CelBackColor(axGT出荷一覧.CaretRow,0,0x006000);

			OldRow = axGT出荷一覧.CaretRow;
			nSrow  = axGT出荷一覧.SelStartRow;
			nErow  = axGT出荷一覧.SelEndRow;

		}

		private void axGT出荷一覧_CelClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelClickEvent e)
		{
			axGT出荷一覧_CurPlaceChanged(null,null);
			if(axGT出荷一覧.SelStartRow != axGT出荷一覧.SelEndRow)
			{
				if(nSrow > nErow)
				{
					nWork = nSrow;
					nSrow = nErow;
					nErow = nWork;
				}
				for(short nCnt = nSrow; nCnt <= nErow; nCnt++)
				{
					axGT出荷一覧.set_CelForeColor(nCnt,0,0x98FB98);
					axGT出荷一覧.set_CelBackColor(nCnt,0,0x006000);
				}
				for(int nCnt = int.Parse(nSrow.ToString()) - 1; nCnt >= 1; nCnt--)
				{
					axGT出荷一覧.set_CelForeColor(short.Parse(nCnt.ToString()),0,0);
					axGT出荷一覧.set_CelBackColor(short.Parse(nCnt.ToString()),0,0xFFFFFF);
				}
				for(int nCnt = int.Parse(nErow.ToString()) + 1; nCnt <= axGT出荷一覧.Rows; nCnt++)
				{
					axGT出荷一覧.set_CelForeColor(short.Parse(nCnt.ToString()),0,0);
					axGT出荷一覧.set_CelBackColor(short.Parse(nCnt.ToString()),0,0xFFFFFF);
				}
			}
		}

		private void btn出荷検索_Click(object sender, System.EventArgs e)
		{
			if (dt開始日付.Value > dt終了日付.Value)
			{
				MessageBox.Show("日付の範囲が正しく入力されていません","入力チェック",MessageBoxButtons.OK );
				dt開始日付.Focus();
				return;
			}

			tex登録件数.Text = "";
			tex個数合計.Text = "";
			tex重量合計.Text = "";
			texメッセージ.Text = "検索中．．．";
			axGT出荷一覧.Clear();
			axGT出荷一覧.ColsWidth =    "0|0|2.2|3.6|18|2.6|3|6.0|9.8|5.3|4.6|"
										+"8|12.0|5.5|5.5|4.2|"
										+"0|0|0|0|0|0|0|0|0|";
			axGT出荷一覧.CaretRow = 1;
			axGT出荷一覧.CaretCol = 2;
			axGT出荷一覧_CurPlaceChanged(null,null);
			string sSday = YYYYMMDD変換(dt開始日付.Value);
			string sEday = YYYYMMDD変換(dt終了日付.Value);

			// 空白除去
			tex届け先コード.Text = tex届け先コード.Text.Trim();
			if(tex届け先コード.Text.Length == 0)
				tex届け先名.Text = "";
			else
			{
				if(!半角チェック(tex届け先コード,"届け先コード")) return;

				texメッセージ.Text = "";
				s届け先ＣＤ = tex届け先コード.Text;
				届け先検索();
			}

			tex依頼主コード.Text = tex依頼主コード.Text.Trim();
			if(tex依頼主コード.Text.Length == 0)
				tex依頼主名.Text = "";
			else
			{
				if(!半角チェック(tex依頼主コード,"依頼主コード")) return;

				texメッセージ.Text = "";
				s依頼主ＣＤ = tex依頼主コード.Text;
				依頼主検索();
			}

			tex送り状番号開始.Text = tex送り状番号開始.Text.TrimEnd();
			tex送り状番号終了.Text = tex送り状番号終了.Text.TrimEnd();
			texお客様番号開始.Text = texお客様番号開始.Text.TrimEnd();
			texお客様番号終了.Text = texお客様番号終了.Text.TrimEnd();

			if(!半角チェック(tex送り状番号開始,"送り状番号（開始）")) return;
			if(!半角チェック(tex送り状番号終了,"送り状番号（終了）")) return;
			if(!半角チェック(texお客様番号開始,"お客様番号（開始）")) return;
			if(!半角チェック(texお客様番号終了,"お客様番号（終了）")) return;
			
			if(tex送り状番号開始.Text.Length > 0){
				if(tex送り状番号開始.Text.Length != 11
				&& tex送り状番号開始.Text.Length != 4 // SSの仕様
				&& tex送り状番号開始.Text.Length != 5 // SSの仕様
				&& tex送り状番号開始.Text.Length != 13 ){
					texメッセージ.Text = "";
					MessageBox.Show("送り状番号は１１桁もしくは１３桁で入力してください"
									, "入力チェック", MessageBoxButtons.OK );
					tex送り状番号開始.Focus();
					return;
				}
			}

			if(tex送り状番号終了.Text.Length > 0){
				if(tex送り状番号終了.Text.Length != 11
				&& tex送り状番号終了.Text.Length != 4 // SSの仕様
				&& tex送り状番号終了.Text.Length != 5 // SSの仕様
				&& tex送り状番号終了.Text.Length != 13 ){
					texメッセージ.Text = "";
					MessageBox.Show("送り状番号は１１桁もしくは１３桁で入力してください"
									, "入力チェック", MessageBoxButtons.OK );
					tex送り状番号終了.Focus();
					return;
				}
			}

			string s状態 = sa状態ＣＤ[cmb状態.SelectedIndex];

			i現在頁数 = 1;
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				s出荷一覧 = new string[1];
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
				string[] sa検索条件 = new string[]{
								gs会員ＣＤ
								, gs部門ＣＤ
								, tex届け先コード.Text.TrimEnd()
								, tex依頼主コード.Text.TrimEnd()
								, cmb出荷日.SelectedIndex.ToString()
								, sSday
								, sEday
								, s状態
							    , tex送り状番号開始.Text.Replace("-","")
							    , tex送り状番号終了.Text.Replace("-","")
							    , texお客様番号開始.Text.TrimEnd()
							    , texお客様番号終了.Text.TrimEnd()
							    , "1"	//未発行印刷.csの一覧表示ずれを防止
				};

				s出荷一覧 = sv_syukka.Get_syukka2(gsaユーザ, sa検索条件);
				texメッセージ.Text = s出荷一覧[0];
				if(s出荷一覧[0].Length == 4)
				{
					texメッセージ.Text = "";
					tex登録件数.Text = s出荷一覧[1];
					tex個数合計.Text = s出荷一覧[2];
					tex重量合計.Text = s出荷一覧[3];
					axGT出荷一覧.Rows = 9;
					頁情報設定();
				}
				else
				{
					if(s出荷一覧[0].Equals("該当データがありません"))
					{
						texメッセージ.Text = "";
						MessageBox.Show("該当データがありません","出荷検索",MessageBoxButtons.OK);
					}
					else
					{
						i現在頁数 = 1;
						btn前頁.Enabled = false;
						btn次頁.Enabled = false;
						lab頁番号.Text = "";
						ビープ音();
					}
					tex届け先コード.Focus();
				}
			}
			catch (System.Net.WebException)
			{
				texメッセージ.Text = gs通信エラー;
				ビープ音();
				tex届け先コード.Focus();
			}
			catch (Exception ex)
			{
				texメッセージ.Text = "通信エラー：" + ex.Message;
				ビープ音();
				tex届け先コード.Focus();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
			axGT出荷一覧.CaretRow = 1;
			axGT出荷一覧.CaretCol = 2;
			axGT出荷一覧_CurPlaceChanged(sender,null);
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
						tex届け先名.Text     = sList[10].TrimEnd();
						texメッセージ.Text = "";
						tex依頼主コード.Focus();
					}
					else
					{
						texメッセージ.Text = "";
						tex依頼主コード.Focus();
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

		private void 依頼主検索()
		{
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
						texメッセージ.Text = "";
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

		private void tex届け先コード_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
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

		private void tex依頼主コード_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
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

		private void axGT出荷一覧_KeyDownEvent(object sender, AxGTABLE32V2Lib._DGTable32Events_KeyDownEvent e)
		{
			if (e.keyCode == 13)
			{
				//Enterキーを押した場合
				btn再発行_Click(sender, null);
			}
			if (e.keyCode == 9)
			{
				//Tabキーを押した場合
				this.SelectNextControl(axGT出荷一覧, true, true, true, true);
			}
		}

		private void btn再発行_Click(object sender, System.EventArgs e)
		{
			//登録日チェック
			if(axGT出荷一覧.get_CelText(axGT出荷一覧.CaretRow,17).Trim().Length == 0)
			{
				return;
			}

			texメッセージ.Text = "ラベルイメージ印刷中．．．";

//			try
//			{
//				プリンタチェック();
//			}
//			catch(Exception ex)
//			{
//				texメッセージ.Text = ex.Message;
//				return;
//			}

			Cursor = System.Windows.Forms.Cursors.AppStarting;

			short n開始;
			short n終了;
			if(axGT出荷一覧.SelStartRow > axGT出荷一覧.SelEndRow)
			{
				n終了 = axGT出荷一覧.SelStartRow;
				n開始 = axGT出荷一覧.SelEndRow;
			}
			else
			{
				n開始 = axGT出荷一覧.SelStartRow;
				n終了 = axGT出荷一覧.SelEndRow;
			}

			short n表示開始 = axGT出荷一覧.TopRow;
			string s開始登録日         = axGT出荷一覧.get_CelText(n開始,17).Trim();
			string s開始ジャーナルＮＯ = axGT出荷一覧.get_CelText(n開始,16).Trim();
			string s終了登録日         = axGT出荷一覧.get_CelText(n終了,17).Trim();
			string s終了ジャーナルＮＯ = axGT出荷一覧.get_CelText(n終了,16).Trim();
			string s次行登録日         = "";
			string s次行ジャーナルＮＯ = "";
			short n次行 = (short)(n終了 + 1);
			if(n次行 <= axGT出荷一覧.Rows){
				s次行登録日         = axGT出荷一覧.get_CelText(n次行,17).Trim();
				s次行ジャーナルＮＯ = axGT出荷一覧.get_CelText(n次行,16).Trim();
			}

			送り状データクリア();

			for(short nCnt = n開始 ; nCnt <= n終了; nCnt++)
			{
				try
				{
					string[] sData = new string[2];
					//登録日、ジャーナルＮＯ
					sData[0] = axGT出荷一覧.get_CelText(nCnt, 17);
					sData[1] = axGT出荷一覧.get_CelText(nCnt, 16);
					荷札控え印刷指示(sData, 1, 99);

					if(!gb印刷)
					{
						texメッセージ.Text = "";
						Cursor = System.Windows.Forms.Cursors.Default;
						MessageBox.Show("集荷店が違います。印刷できません。", "送状控印刷", MessageBoxButtons.OK);
						return;
					}
				}
				catch (Exception ex)
				{
					texメッセージ.Text = ex.Message;
					ビープ音();
					Cursor = System.Windows.Forms.Cursors.Default;
					return;
				}
			}

			荷札控え帳票印刷();

			Cursor = System.Windows.Forms.Cursors.Default;

			// 再検索
			btn出荷検索_Click(sender, e);
			一覧カーソル移動(n開始, n終了, n表示開始
							, s開始登録日, s開始ジャーナルＮＯ
							, s終了登録日, s終了ジャーナルＮＯ
							, s次行登録日, s次行ジャーナルＮＯ);
			texメッセージ.Text = "";
		}

		private void tex届け先コード_LostFocus(object sender, EventArgs e)
		{
			if(tex届け先コード.Text.Trim() == "")
				tex届け先名.Text = "";
		}

		private void tex依頼主コード_LostFocus(object sender, EventArgs e)
		{
			if(tex依頼主コード.Text.Trim() == "")
				tex依頼主名.Text = "";

		}

		private void btn前頁_Click(object sender, System.EventArgs e)
		{
			i現在頁数--;
			頁情報設定();
		}

		private void btn次頁_Click(object sender, System.EventArgs e)
		{
			i現在頁数++;
			頁情報設定();
		}

		private void 頁情報設定()
		{
			if (s出荷一覧.Length - 4 <= 9)
			{
				axGT出荷一覧.Rows = 9;
			}
			else if (axGT出荷一覧.Rows < s出荷一覧.Length - 4)
			{
				axGT出荷一覧.Rows = (short)(s出荷一覧.Length - 4);
			}

			for(short i = 1; i <= axGT出荷一覧.Rows; i++ )
			{
				axGT出荷一覧.set_CelHeight(i,0,2.3);
				axGT出荷一覧.set_CelAlignVert(i,4,3);
				axGT出荷一覧.set_CelAlignVert(i,7,3);
				//輸送商品／記事・品名
				axGT出荷一覧.set_CelAlignVert(i,12,3);
			}

			axGT出荷一覧.Clear();
			axGT出荷一覧.CaretRow = 1;
			axGT出荷一覧.CaretCol = 2;
			axGT出荷一覧_CurPlaceChanged(null,null);
			short s表示数 = (short)1;

			for(short sCnt = (short)4; sCnt < s出荷一覧.Length; sCnt++)
			{
				string sRList = s出荷一覧[sCnt].Replace("\\r\\n","\r\n");
				axGT出荷一覧.set_RowsText(s表示数, sRList);
				s表示数++;
			}
			axGT出荷一覧.Focus();
		}

		private void cmb状態_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				btn出荷検索_Click(sender,e);
			}

		}

		private void 出荷照会_Closed(object sender, System.EventArgs e)
		{
			tex届け先コード.Focus();
		}

		private void 一覧カーソル移動(short n開始, short n終了, short n表示開始
								, string s開始登録日, string s開始ジャーナルＮＯ
								, string s終了登録日, string s終了ジャーナルＮＯ
								, string s次行登録日, string s次行ジャーナルＮＯ)
		{
			//選択行のクリア
			axGT出荷一覧.CaretRow    = 1;
			axGT出荷一覧.SelStartRow = 1;
			axGT出荷一覧.SelEndRow   = 1;
			axGT出荷一覧.CaretCol    = 2;

			//選択行の設定
			short n新開始 = 0;
			short n新終了 = 0;

			//選択開始行と選択終了行がかわらない場合
			if(s開始登録日 == axGT出荷一覧.get_CelText(n開始,17).Trim()
			&& s開始ジャーナルＮＯ == axGT出荷一覧.get_CelText(n開始,16).Trim()
			&& s終了登録日 == axGT出荷一覧.get_CelText(n終了,17).Trim()
			&& s終了ジャーナルＮＯ == axGT出荷一覧.get_CelText(n終了,16).Trim()){
				n新開始 = n開始;
				n新終了 = n終了;
			}else{
				for(short n行 = 1; n行 <= axGT出荷一覧.Rows; n行++){
					//選択開始行の値（登録日、ジャーナルＮＯ）が同じ場合
					if(s開始登録日 == axGT出荷一覧.get_CelText(n行,17).Trim()
					&& s開始ジャーナルＮＯ == axGT出荷一覧.get_CelText(n行,16).Trim()){
						n新開始 = n行;
					}
					//選択終了行の値（登録日、ジャーナルＮＯ）が同じ場合
					if(s終了登録日 == axGT出荷一覧.get_CelText(n行,17).Trim()
					&& s終了ジャーナルＮＯ == axGT出荷一覧.get_CelText(n行,16).Trim()){
						n新終了 = n行;
						break;
					}
				}
			}
			//スクロール位置の設定
			if(n表示開始 <= axGT出荷一覧.Rows){
				axGT出荷一覧.TopRow = n表示開始;
			}
			//再検索後の一覧に該当データが存在する場合
			if(n新終了 > 0){
				//選択行数が同じ場合
				if(n新開始 > 0 && (n終了 - n開始 == n新終了 - n新開始)){
					axGT出荷一覧.CaretRow    = n新開始;
					axGT出荷一覧.SelStartRow = n新開始;
					axGT出荷一覧.SelEndRow   = n新終了;
				}else{
					axGT出荷一覧.CaretRow    = n新終了;
					axGT出荷一覧.SelStartRow = n新終了;
					axGT出荷一覧.SelEndRow   = n新終了;
				}
			}else{
				if(s次行登録日.Length > 0 && s次行ジャーナルＮＯ.Length > 0){
					for(short n行 = 1; n行 <= axGT出荷一覧.Rows; n行++){
						//選択開始行の値（登録日、ジャーナルＮＯ）が同じ場合
						if(s次行登録日 == axGT出荷一覧.get_CelText(n行,17).Trim()
						&& s次行ジャーナルＮＯ == axGT出荷一覧.get_CelText(n行,16).Trim()){
							axGT出荷一覧.CaretRow    = n行;
							axGT出荷一覧.SelStartRow = n行;
							axGT出荷一覧.SelEndRow   = n行;
							break;
						}
					}
				}
			}
			axGT出荷一覧_CurPlaceChanged(null,null);
		}
	}
}
