using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [店所検索]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// ADD 2014.09.01 BEVAS) 前田 支店止め機能対応のため店所検索画面を追加
	//--------------------------------------------------------------------------
	public class 店所検索 : 共通フォーム
	{
		public short nOldRow = 0;
		public string s店所コード;
		public string s店所名;
		public string s店所正式名;
		public string s郵便番号;

		private string[] s店所一覧;
		private int i現在頁数;
		private int i最大頁数;
		private int i開始数;
		private int i終了数;
		private int iアクティブＦＧ = 0;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Button btn確定;
		private 共通テキストボックス texメッセージ;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Button btn検索;
		private AxGTABLE32V2Lib.AxGTable32 axGT店所;
		private System.Windows.Forms.Label lab店所タイトル;
		private 共通テキストボックス tex店所コード;
		private System.Windows.Forms.Label lab店所コード;
		private System.Windows.Forms.Label lab店所名;
		private 共通テキストボックス tex店所名;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lab頁番号;
		private System.Windows.Forms.Button btn次頁;
		private System.Windows.Forms.Button btn前頁;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmb地域;
		private System.Windows.Forms.ComboBox cmb都道府県;

		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public 店所検索()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			ＤＰＩ表示サイズ変換();
			this.axGT店所.Size = new System.Drawing.Size(422, 292);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(店所検索));
            this.panel1 = new System.Windows.Forms.Panel();
            this.axGT店所 = new AxGTABLE32V2Lib.AxGTable32();
            this.lab頁番号 = new System.Windows.Forms.Label();
            this.btn次頁 = new System.Windows.Forms.Button();
            this.btn前頁 = new System.Windows.Forms.Button();
            this.btn確定 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lab店所タイトル = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.texメッセージ = new IS2Client.共通テキストボックス();
            this.btn閉じる = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb都道府県 = new System.Windows.Forms.ComboBox();
            this.cmb地域 = new System.Windows.Forms.ComboBox();
            this.tex店所コード = new IS2Client.共通テキストボックス();
            this.lab店所コード = new System.Windows.Forms.Label();
            this.lab店所名 = new System.Windows.Forms.Label();
            this.tex店所名 = new IS2Client.共通テキストボックス();
            this.btn検索 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ds送り状)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGT店所)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Honeydew;
            this.panel1.Controls.Add(this.axGT店所);
            this.panel1.Controls.Add(this.lab頁番号);
            this.panel1.Controls.Add(this.btn次頁);
            this.panel1.Controls.Add(this.btn前頁);
            this.panel1.Controls.Add(this.btn確定);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 352);
            this.panel1.TabIndex = 1;
            // 
            // axGT店所
            // 
            this.axGT店所.DataSource = null;
            this.axGT店所.Location = new System.Drawing.Point(50, 25);
            this.axGT店所.Name = "axGT店所";
            this.axGT店所.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGT店所.OcxState")));
            this.axGT店所.Size = new System.Drawing.Size(267, 289);
            this.axGT店所.TabIndex = 12;
            this.axGT店所.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGT店所_CurPlaceChanged);
            this.axGT店所.CelDblClick += new AxGTABLE32V2Lib._DGTable32Events_CelDblClickEventHandler(this.axGT店所_CelDblClick);
            this.axGT店所.KeyDownEvent += new AxGTABLE32V2Lib._DGTable32Events_KeyDownEventHandler(this.axGT店所_KeyDownEvent);
            // 
            // lab頁番号
            // 
            this.lab頁番号.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab頁番号.ForeColor = System.Drawing.Color.Green;
            this.lab頁番号.Location = new System.Drawing.Point(194, 326);
            this.lab頁番号.Name = "lab頁番号";
            this.lab頁番号.Size = new System.Drawing.Size(44, 20);
            this.lab頁番号.TabIndex = 73;
            this.lab頁番号.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn次頁
            // 
            this.btn次頁.BackColor = System.Drawing.Color.SteelBlue;
            this.btn次頁.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn次頁.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn次頁.ForeColor = System.Drawing.Color.White;
            this.btn次頁.Location = new System.Drawing.Point(240, 324);
            this.btn次頁.Name = "btn次頁";
            this.btn次頁.Size = new System.Drawing.Size(48, 22);
            this.btn次頁.TabIndex = 9;
            this.btn次頁.TabStop = false;
            this.btn次頁.Text = "次頁";
            this.btn次頁.UseVisualStyleBackColor = false;
            this.btn次頁.Click += new System.EventHandler(this.btn次頁_Click);
            // 
            // btn前頁
            // 
            this.btn前頁.BackColor = System.Drawing.Color.SteelBlue;
            this.btn前頁.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn前頁.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn前頁.ForeColor = System.Drawing.Color.White;
            this.btn前頁.Location = new System.Drawing.Point(144, 324);
            this.btn前頁.Name = "btn前頁";
            this.btn前頁.Size = new System.Drawing.Size(48, 22);
            this.btn前頁.TabIndex = 8;
            this.btn前頁.TabStop = false;
            this.btn前頁.Text = "前頁";
            this.btn前頁.UseVisualStyleBackColor = false;
            this.btn前頁.Click += new System.EventHandler(this.btn前頁_Click);
            // 
            // btn確定
            // 
            this.btn確定.BackColor = System.Drawing.Color.Blue;
            this.btn確定.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn確定.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn確定.ForeColor = System.Drawing.Color.White;
            this.btn確定.Location = new System.Drawing.Point(302, 324);
            this.btn確定.Name = "btn確定";
            this.btn確定.Size = new System.Drawing.Size(64, 22);
            this.btn確定.TabIndex = 10;
            this.btn確定.Text = "確定";
            this.btn確定.UseVisualStyleBackColor = false;
            this.btn確定.Click += new System.EventHandler(this.btn確定_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.panel7.Controls.Add(this.lab店所タイトル);
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(394, 26);
            this.panel7.TabIndex = 13;
            // 
            // lab店所タイトル
            // 
            this.lab店所タイトル.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab店所タイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab店所タイトル.ForeColor = System.Drawing.Color.White;
            this.lab店所タイトル.Location = new System.Drawing.Point(12, 2);
            this.lab店所タイトル.Name = "lab店所タイトル";
            this.lab店所タイトル.Size = new System.Drawing.Size(264, 24);
            this.lab店所タイトル.TabIndex = 0;
            this.lab店所タイトル.Text = "支店止め対応店所検索";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.PaleGreen;
            this.panel8.Controls.Add(this.texメッセージ);
            this.panel8.Controls.Add(this.btn閉じる);
            this.panel8.Location = new System.Drawing.Point(0, 516);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(474, 58);
            this.panel8.TabIndex = 2;
            // 
            // texメッセージ
            // 
            this.texメッセージ.BackColor = System.Drawing.Color.PaleGreen;
            this.texメッセージ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.texメッセージ.ForeColor = System.Drawing.Color.Red;
            this.texメッセージ.Location = new System.Drawing.Point(68, 4);
            this.texメッセージ.Multiline = true;
            this.texメッセージ.Name = "texメッセージ";
            this.texメッセージ.ReadOnly = true;
            this.texメッセージ.Size = new System.Drawing.Size(314, 50);
            this.texメッセージ.TabIndex = 7;
            this.texメッセージ.TabStop = false;
            // 
            // btn閉じる
            // 
            this.btn閉じる.ForeColor = System.Drawing.Color.Red;
            this.btn閉じる.Location = new System.Drawing.Point(8, 6);
            this.btn閉じる.Name = "btn閉じる";
            this.btn閉じる.Size = new System.Drawing.Size(54, 48);
            this.btn閉じる.TabIndex = 11;
            this.btn閉じる.TabStop = false;
            this.btn閉じる.Text = "閉じる";
            this.btn閉じる.Click += new System.EventHandler(this.btn閉じる_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(0, 0);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 0;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(0, 0);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.PaleGreen;
            this.panel6.Location = new System.Drawing.Point(0, 26);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(394, 26);
            this.panel6.TabIndex = 15;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Honeydew;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.cmb都道府県);
            this.panel5.Controls.Add(this.cmb地域);
            this.panel5.Controls.Add(this.tex店所コード);
            this.panel5.Controls.Add(this.lab店所コード);
            this.panel5.Controls.Add(this.lab店所名);
            this.panel5.Controls.Add(this.tex店所名);
            this.panel5.Controls.Add(this.btn検索);
            this.panel5.Location = new System.Drawing.Point(1, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(374, 94);
            this.panel5.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(4, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 50;
            this.label1.Text = "都道府県";
            // 
            // cmb都道府県
            // 
            this.cmb都道府県.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb都道府県.Enabled = false;
            this.cmb都道府県.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb都道府県.ForeColor = System.Drawing.Color.LimeGreen;
            this.cmb都道府県.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmb都道府県.Items.AddRange(new object[] {
            "未選択"});
            this.cmb都道府県.Location = new System.Drawing.Point(222, 62);
            this.cmb都道府県.Name = "cmb都道府県";
            this.cmb都道府県.Size = new System.Drawing.Size(138, 24);
            this.cmb都道府県.TabIndex = 7;
            // 
            // cmb地域
            // 
            this.cmb地域.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb地域.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb地域.ForeColor = System.Drawing.Color.LimeGreen;
            this.cmb地域.Items.AddRange(new object[] {
            "地域未選択",
            "東北・北海道",
            "関東",
            "甲信越・北陸",
            "東海",
            "関西",
            "中国",
            "四国",
            "九州・沖縄"});
            this.cmb地域.Location = new System.Drawing.Point(82, 62);
            this.cmb地域.Name = "cmb地域";
            this.cmb地域.Size = new System.Drawing.Size(128, 24);
            this.cmb地域.TabIndex = 6;
            this.cmb地域.SelectedIndexChanged += new System.EventHandler(this.cmb地域_SelectedIndexChanged);
            // 
            // tex店所コード
            // 
            this.tex店所コード.BackColor = System.Drawing.SystemColors.Window;
            this.tex店所コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex店所コード.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tex店所コード.Location = new System.Drawing.Point(82, 6);
            this.tex店所コード.MaxLength = 4;
            this.tex店所コード.Name = "tex店所コード";
            this.tex店所コード.Size = new System.Drawing.Size(44, 23);
            this.tex店所コード.TabIndex = 1;
            // 
            // lab店所コード
            // 
            this.lab店所コード.BackColor = System.Drawing.Color.Honeydew;
            this.lab店所コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab店所コード.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab店所コード.Location = new System.Drawing.Point(8, 10);
            this.lab店所コード.Name = "lab店所コード";
            this.lab店所コード.Size = new System.Drawing.Size(58, 16);
            this.lab店所コード.TabIndex = 46;
            this.lab店所コード.Text = "コード";
            // 
            // lab店所名
            // 
            this.lab店所名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab店所名.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab店所名.Location = new System.Drawing.Point(8, 34);
            this.lab店所名.Name = "lab店所名";
            this.lab店所名.Size = new System.Drawing.Size(58, 16);
            this.lab店所名.TabIndex = 6;
            this.lab店所名.Text = "店所名";
            // 
            // tex店所名
            // 
            this.tex店所名.BackColor = System.Drawing.SystemColors.Window;
            this.tex店所名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tex店所名.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tex店所名.Location = new System.Drawing.Point(82, 34);
            this.tex店所名.MaxLength = 4;
            this.tex店所名.Name = "tex店所名";
            this.tex店所名.Size = new System.Drawing.Size(74, 23);
            this.tex店所名.TabIndex = 2;
            this.tex店所名.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex店所名_KeyDown);
            // 
            // btn検索
            // 
            this.btn検索.BackColor = System.Drawing.Color.SteelBlue;
            this.btn検索.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn検索.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn検索.ForeColor = System.Drawing.Color.White;
            this.btn検索.Location = new System.Drawing.Point(292, 32);
            this.btn検索.Name = "btn検索";
            this.btn検索.Size = new System.Drawing.Size(64, 22);
            this.btn検索.TabIndex = 3;
            this.btn検索.TabStop = false;
            this.btn検索.Text = "検索";
            this.btn検索.UseVisualStyleBackColor = false;
            this.btn検索.Click += new System.EventHandler(this.btn検索_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Location = new System.Drawing.Point(7, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(8, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 355);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // 店所検索
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(388, 582);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(394, 607);
            this.Name = "店所検索";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "is-2 店所検索";
            this.Activated += new System.EventHandler(this.店所検索_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Onエンター移動);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Onエンターキャンセル);
            ((System.ComponentModel.ISupportInitialize)(this.ds送り状)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axGT店所)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
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
			iアクティブＦＧ = 0;
			tex店所コード.Text = s店所コード;
			tex店所名.Text = s店所名;
			
			axGT店所.Cols = 4;
			axGT店所.Rows = 15;
			axGT店所.ColSep = "|";
			axGT店所.CaretRow = 1;
			axGT店所.NoBeep = true;
			axGT店所.set_RowsText(0, "|コード|店所名|店所正式名|郵便番号|");
			axGT店所.ColsWidth = "0|8.0|12.5|0|0|";
			axGT店所.ColsAlignHorz = "0|1|0|0|0|";
			axGT店所.set_CelForeColor(axGT店所.CaretRow,0,0x98FB98);  //BGR
			axGT店所.set_CelBackColor(axGT店所.CaretRow,0,0x006000);

			btn前頁.Enabled = false;
			btn次頁.Enabled = false;
			lab頁番号.Text = "";
			i現在頁数 = 1;

			// 地域・都道府県をクリア
			cmb地域.SelectedIndex = 0;
			cmb地域.ResetText();	
			cmb地域.Enabled = true;
			cmb地域.Visible = true;

			// 地域コンボをクリックしたのち、押せるようにする
			cmb都道府県.Items.Clear();
			cmb都道府県.Items.Add("未選択");
			cmb都道府県.SelectedIndex = 0;
			cmb都道府県.ResetText();
			cmb都道府県.Visible = true;
			cmb都道府県.Enabled = false; 
		}

		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
			s店所コード = "";
			s店所名 = "";
			s店所正式名 = "";
			s郵便番号 = "";
			this.Close();
		}

		private void axGT店所_CelDblClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelDblClickEvent e)
		{
			s店所コード = axGT店所.get_CelText(axGT店所.CaretRow,1);
			s店所名 = axGT店所.get_CelText(axGT店所.CaretRow,2);
			s店所正式名 = axGT店所.get_CelText(axGT店所.CaretRow,3);
			s郵便番号 = axGT店所.get_CelText(axGT店所.CaretRow,4);
			if(s店所コード != "")
				this.Close();
		}

		private void axGT店所_CurPlaceChanged(object sender, AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEvent e)
		{
			axGT店所.set_CelForeColor(nOldRow,0,0);
			axGT店所.set_CelBackColor(nOldRow,0,0xFFFFFF);
			axGT店所.set_CelForeColor(axGT店所.CaretRow,0,0x98FB98);  //BGR
			axGT店所.set_CelBackColor(axGT店所.CaretRow,0,0x006000);
			nOldRow = axGT店所.CaretRow;
		}

		private void btn検索_Click(object sender, System.EventArgs e)
		{
			店所一覧検索();		
		}

		private void btn確定_Click(object sender, System.EventArgs e)
		{
			s店所コード = axGT店所.get_CelText(axGT店所.CaretRow,1);
			s店所名 = axGT店所.get_CelText(axGT店所.CaretRow,2);
			s店所正式名 = axGT店所.get_CelText(axGT店所.CaretRow,3);
			s郵便番号 = axGT店所.get_CelText(axGT店所.CaretRow,4);
			if(s店所コード != "")
				this.Close();
		}

		private void 店所一覧検索()
		{
			iアクティブＦＧ = 1;
			axGT店所.Clear();
			tex店所コード.Text = tex店所コード.Text.Trim();
			tex店所名.Text = tex店所名.Text.Trim();
			if(!半角チェック(tex店所コード, "コード")) return;
			if(!全角チェック(tex店所名, "店所名")) return;

			texメッセージ.Text = "検索中．．．";

			// 以下の場合は、通常検索
			// *****店所コード／店所名に入力あり*****
			// *****初期状態(検索条件変更なし)*****
			if((tex店所コード.Text.Length > 0 || tex店所名.Text.Length > 0) ||
				(tex店所コード.Text.Length == 0 && tex店所名.Text.Length == 0 && cmb都道府県.Text.Equals("未選択")))
			{
				// 地域・都道府県をクリア
				cmb地域.SelectedIndex = 0;
				cmb地域.ResetText();
				cmb都道府県.Text = "";
				cmb都道府県.Enabled = false;

				s店所一覧 = new string[1];
				// カーソルを砂時計にする
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				try
				{
					string[] sKey  = new string[3];
					sKey[0] = tex店所コード.Text;
					sKey[1] = tex店所名.Text;
					if(gs会員ＣＤ.Substring(0,1) != "J")
					{
						sKey[2] = "1"; // 福山通運の店所止め
					}
					else
					{
						sKey[2] = "2"; // 王子運送の店所止め
					}

					// 支店止め対応の店所一覧の取得
					s店所一覧 = sv_print.Get_DeliShop(gsaユーザ, sKey);
				}
				catch (System.Net.WebException)
				{
					s店所一覧[0] = gs通信エラー;
				}
				catch (Exception ex)
				{
					s店所一覧[0] = "通信エラー：" + ex.Message;
				}
				// カーソルをデフォルトに戻す
				Cursor = System.Windows.Forms.Cursors.Default;

				if (s店所一覧[0].Equals("正常終了"))
				{
					texメッセージ.Text = "";
					i最大頁数 = (s店所一覧.Length - 2) / (axGT店所.Rows - 1) + 1;
					if (i現在頁数 > i最大頁数)
						i現在頁数 = i最大頁数;
					頁情報設定();

					axGT店所.CaretRow = 1;
					axGT店所_CurPlaceChanged(null,null);

					axGT店所.Focus();
				}
				else
				{
					axGT店所.CaretRow = 1;
					axGT店所_CurPlaceChanged(null,null);
					if (s店所一覧[0].Equals("該当データがありません"))
					{
						texメッセージ.Text = "";
						MessageBox.Show("該当データがありません","店所検索",MessageBoxButtons.OK);
					}
					else
					{
						texメッセージ.Text = s店所一覧[0];
						axGT店所.Clear();
						i現在頁数 = 1;
						btn前頁.Enabled = false;
						btn次頁.Enabled = false;
						lab頁番号.Text = "";
						ビープ音();
					}
					tex店所コード.Focus();
				}
			}
			// 地域／都道府県のみが選択状態の場合
			else if(!cmb都道府県.Text.Equals("未選択"))
			{
				string s県名 = string.Empty;
				s県名 = cmb都道府県.Text.Trim();
				県別店所検索(s県名);
			}
		}

		private void axGT店所_KeyDownEvent(object sender, AxGTABLE32V2Lib._DGTable32Events_KeyDownEvent e)
		{
			if (e.keyCode == 0x0d)
			{
				s店所コード = axGT店所.get_CelText(axGT店所.CaretRow,1);
				s店所名 = axGT店所.get_CelText(axGT店所.CaretRow,2);
				s店所正式名 = axGT店所.get_CelText(axGT店所.CaretRow,3);
				s郵便番号 = axGT店所.get_CelText(axGT店所.CaretRow,4);
				if(s店所コード != "")
					this.Close();
			}
			if (e.keyCode == 0x09)
			{
				this.SelectNextControl(axGT店所, true, true, true, true);
			}
		}

		private void tex店所名_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				店所一覧検索();
			}		
		}

		private void btn前頁_Click(object sender, System.EventArgs e)
		{
			i現在頁数--;
			頁情報設定();
			axGT店所.CaretRow = 1;
			axGT店所_CurPlaceChanged(null,null);
		}

		private void btn次頁_Click(object sender, System.EventArgs e)
		{
			i現在頁数++;
			頁情報設定();
			axGT店所.CaretRow = 1;
			axGT店所_CurPlaceChanged(null,null);
		}

		private void 頁情報設定()
		{
			axGT店所.Clear();

			i開始数 = (i現在頁数 - 1) * (axGT店所.Rows - 1) + 1;
			i終了数 = i現在頁数 * (axGT店所.Rows - 1);

			short s表示数 = (short)2;
			for(short sCnt = (short)i開始数; sCnt < s店所一覧.Length && sCnt <= i終了数 ; sCnt++)
			{
				axGT店所.set_RowsText(s表示数, s店所一覧[sCnt]);
				s表示数++;
			}
			lab頁番号.Text = i現在頁数.ToString() + " / " + i最大頁数.ToString();
			if (i現在頁数 == 1)
				btn前頁.Enabled = false;
			else
				btn前頁.Enabled = true;
			if (i現在頁数 == i最大頁数)
				btn次頁.Enabled = false;
			else
				btn次頁.Enabled = true;
			axGT店所.Focus();
		}

		private void 店所検索_Activated(object sender, System.EventArgs e)
		{
			if(iアクティブＦＧ == 0)
				店所一覧検索();
		}

		private void cmb地域_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ComboBox cmb = (ComboBox) sender;
			if (cmb.SelectedIndex > 0) 
			{
				cmb都道府県.Items.Clear();
				cmb都道府県.BeginUpdate();
				foreach (string sPref in jag都道府県[cmb.SelectedIndex])
				{
					cmb都道府県.Items.Add(sPref);
				}
				cmb都道府県.EndUpdate();
				cmb都道府県.SelectedIndex = 0;
				cmb都道府県.Enabled = true;
				cmb都道府県.ResetText();
				cmb都道府県.Focus();
			}
			cmb都道府県.Refresh();
		}

		private void 県別店所検索(string s県名) 
		{
			texメッセージ.Text = "検索中．．．";

			s店所一覧 = new string[1];
			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			try {
				string[] sKey  = new string[2];
				sKey[0] = s県名;
				if(gs会員ＣＤ.Substring(0,1) != "J")
				{
					sKey[1] = "1"; // 福山通運の支店止め対応
				}
				else
				{
					sKey[1] = "2"; // 王子運送の支店止め対応
				}

				// 県別の支店止め対応の店所一覧の取得
				s店所一覧 = sv_print.Get_PrefDeliShop(gsaユーザ, sKey);
			}
			catch (System.Net.WebException) {
				s店所一覧[0] = gs通信エラー;
			}
			catch (Exception ex)
			{
				s店所一覧[0] = "通信エラー：" + ex.Message;
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;

			if (s店所一覧[0].Equals("正常終了"))
			{
				texメッセージ.Text = "";
				i最大頁数 = (s店所一覧.Length - 2) / (axGT店所.Rows - 1) + 1;
				if (i現在頁数 > i最大頁数)
					i現在頁数 = i最大頁数;
				頁情報設定();

				axGT店所.CaretRow = 1;
				axGT店所_CurPlaceChanged(null,null);

				axGT店所.Focus();
			}
			else
			{
				axGT店所.CaretRow = 1;
				axGT店所_CurPlaceChanged(null,null);
				if (s店所一覧[0].Equals("該当データがありません"))
				{
					texメッセージ.Text = "";
					MessageBox.Show("該当データがありません","店所検索",MessageBoxButtons.OK);
				}
				else
				{
					texメッセージ.Text = s店所一覧[0];
					axGT店所.Clear();
					i現在頁数 = 1;
					btn前頁.Enabled = false;
					btn次頁.Enabled = false;
					lab頁番号.Text = "";
					ビープ音();
				}
				tex店所コード.Focus();
			}
		}

		private string[][] jag都道府県
			= { new string[] {"未選択"},
				new string[] {"北海道","青森県","岩手県","宮城県","秋田県","山形県","福島県"},
			    new string[] {"茨城県","栃木県","群馬県","埼玉県","千葉県","東京都","神奈川県"},
			    new string[] {"新潟県","山梨県","長野県","富山県","石川県","福井県"},
				new string[] {"岐阜県","静岡県","愛知県","三重県"},
				new string[] {"滋賀県","京都府","大阪府","兵庫県","奈良県","和歌山県"},
			    new string[] {"鳥取県","島根県","岡山県","広島県","山口県"},
			    new string[] {"徳島県","香川県","愛媛県","高知県"},
			    new string[] {"福岡県","佐賀県","長崎県","熊本県","大分県","宮崎県","鹿児島県","沖縄県"}};

	}
}
