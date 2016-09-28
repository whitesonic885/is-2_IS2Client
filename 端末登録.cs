using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [端末登録]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// MOD 2008.10.17 東都）高木 テスト印刷機能の追加 
	//--------------------------------------------------------------------------
	// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） 
	//--------------------------------------------------------------------------
	// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 
	//--------------------------------------------------------------------------
	// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 
	// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応
	// MOD 2015.02.12 BEVAS）前田 ＴＥＣ製プリンタ(B-LV4)対応
	//--------------------------------------------------------------------------

	public class 端末登録 : 共通フォーム
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lab端末登録タイトル;
		private System.Windows.Forms.Label lab端末ID;
		private System.Windows.Forms.Label lab端末;
		private System.Windows.Forms.RadioButton rBtn無し;
		private System.Windows.Forms.RadioButton rBtn有り;
		private System.Windows.Forms.Button btn更新;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.Label labプリンタ;
		private System.Windows.Forms.Label lab発行種別;
		private System.Windows.Forms.ListBox listプリンタ;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnテスト印刷;
		private System.ComponentModel.IContainer components = null;

		public 端末登録()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

// MOD 2010.03.31 東都）高木 ＤＰＩ表示サイズ変換 START
			ＤＰＩ表示サイズ変換();
			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
//				this.listプリンタ.Size = new System.Drawing.Size(258, 34);
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 START
//				this.listプリンタ.Size = new System.Drawing.Size(258, (int)(34 * 1.5));
				this.listプリンタ.Size = new System.Drawing.Size(258, (int)(50 * 1.5));
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 END
			}
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
			this.labプリンタ = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rBtn無し = new System.Windows.Forms.RadioButton();
			this.rBtn有り = new System.Windows.Forms.RadioButton();
			this.listプリンタ = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lab発行種別 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab端末登録タイトル = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btnテスト印刷 = new System.Windows.Forms.Button();
			this.btn更新 = new System.Windows.Forms.Button();
			this.texメッセージ = new System.Windows.Forms.TextBox();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.panel5 = new System.Windows.Forms.Panel();
			this.lab端末ID = new System.Windows.Forms.Label();
			this.lab端末 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).BeginInit();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel5.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Honeydew;
			this.panel1.Controls.Add(this.labプリンタ);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.listプリンタ);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.lab発行種別);
			this.panel1.Location = new System.Drawing.Point(0, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(370, 176);
			this.panel1.TabIndex = 1;
			// 
			// labプリンタ
			// 
			this.labプリンタ.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labプリンタ.ForeColor = System.Drawing.Color.LimeGreen;
			this.labプリンタ.Location = new System.Drawing.Point(32, 12);
			this.labプリンタ.Name = "labプリンタ";
			this.labプリンタ.Size = new System.Drawing.Size(80, 14);
			this.labプリンタ.TabIndex = 46;
			this.labプリンタ.Text = "プリンタの有無";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rBtn無し);
			this.groupBox1.Controls.Add(this.rBtn有り);
			this.groupBox1.Location = new System.Drawing.Point(62, 14);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(272, 40);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// rBtn無し
			// 
			this.rBtn無し.Location = new System.Drawing.Point(106, 14);
			this.rBtn無し.Name = "rBtn無し";
			this.rBtn無し.Size = new System.Drawing.Size(58, 24);
			this.rBtn無し.TabIndex = 1;
			this.rBtn無し.Text = "無し";
			// 
			// rBtn有り
			// 
			this.rBtn有り.Checked = true;
			this.rBtn有り.Location = new System.Drawing.Point(26, 14);
			this.rBtn有り.Name = "rBtn有り";
			this.rBtn有り.Size = new System.Drawing.Size(58, 24);
			this.rBtn有り.TabIndex = 1;
			this.rBtn有り.TabStop = true;
			this.rBtn有り.Text = "有り";
			// 
			// listプリンタ
			// 
			this.listプリンタ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listプリンタ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.listプリンタ.ItemHeight = 16;
			this.listプリンタ.Items.AddRange(new object[] {
														  "ＺＥＢＲＡ製サーマルプリンタ（ＵＳＢ）",
														  "ＳＡＴＯ製サーマルプリンタ（ＵＳＢ）",
														  "東芝ＴＥＣ製サーマルプリンタ（ＵＳＢ）"});
			this.listプリンタ.Location = new System.Drawing.Point(70, 88);
			this.listプリンタ.Name = "listプリンタ";
			this.listプリンタ.Size = new System.Drawing.Size(258, 50);
			this.listプリンタ.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 404);
			this.label1.TabIndex = 44;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab発行種別
			// 
			this.lab発行種別.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab発行種別.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab発行種別.Location = new System.Drawing.Point(32, 68);
			this.lab発行種別.Name = "lab発行種別";
			this.lab発行種別.Size = new System.Drawing.Size(80, 14);
			this.lab発行種別.TabIndex = 42;
			this.lab発行種別.Text = "荷札発行種別";
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
			this.panel7.Controls.Add(this.lab端末登録タイトル);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(792, 26);
			this.panel7.TabIndex = 13;
			// 
			// lab端末登録タイトル
			// 
			this.lab端末登録タイトル.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab端末登録タイトル.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab端末登録タイトル.ForeColor = System.Drawing.Color.White;
			this.lab端末登録タイトル.Location = new System.Drawing.Point(12, 2);
			this.lab端末登録タイトル.Name = "lab端末登録タイトル";
			this.lab端末登録タイトル.Size = new System.Drawing.Size(264, 24);
			this.lab端末登録タイトル.TabIndex = 0;
			this.lab端末登録タイトル.Text = "端末登録";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btnテスト印刷);
			this.panel8.Controls.Add(this.btn更新);
			this.panel8.Controls.Add(this.texメッセージ);
			this.panel8.Controls.Add(this.btn閉じる);
			this.panel8.Location = new System.Drawing.Point(0, 286);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 2;
			// 
			// btnテスト印刷
			// 
			this.btnテスト印刷.ForeColor = System.Drawing.Color.Blue;
			this.btnテスト印刷.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnテスト印刷.Location = new System.Drawing.Point(132, 6);
			this.btnテスト印刷.Name = "btnテスト印刷";
			this.btnテスト印刷.Size = new System.Drawing.Size(54, 48);
			this.btnテスト印刷.TabIndex = 7;
			this.btnテスト印刷.Text = "テスト　　印刷";
			this.btnテスト印刷.Click += new System.EventHandler(this.btnテスト印刷_Click);
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
			this.texメッセージ.Location = new System.Drawing.Point(190, 4);
			this.texメッセージ.Multiline = true;
			this.texメッセージ.Name = "texメッセージ";
			this.texメッセージ.ReadOnly = true;
			this.texメッセージ.Size = new System.Drawing.Size(196, 50);
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
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.Honeydew;
			this.panel5.Controls.Add(this.lab端末ID);
			this.panel5.Controls.Add(this.lab端末);
			this.panel5.Location = new System.Drawing.Point(1, 6);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(346, 32);
			this.panel5.TabIndex = 0;
			// 
			// lab端末ID
			// 
			this.lab端末ID.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab端末ID.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab端末ID.Location = new System.Drawing.Point(78, 8);
			this.lab端末ID.Name = "lab端末ID";
			this.lab端末ID.Size = new System.Drawing.Size(86, 16);
			this.lab端末ID.TabIndex = 7;
			this.lab端末ID.Text = "12345678";
			// 
			// lab端末
			// 
			this.lab端末.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab端末.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab端末.Location = new System.Drawing.Point(10, 8);
			this.lab端末.Name = "lab端末";
			this.lab端末.Size = new System.Drawing.Size(56, 16);
			this.lab端末.TabIndex = 6;
			this.lab端末.Text = "端末ＩＤ";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel5);
			this.groupBox2.Location = new System.Drawing.Point(32, 52);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(349, 40);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.panel1);
			this.groupBox3.Location = new System.Drawing.Point(10, 94);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(372, 184);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			// 
			// 端末登録
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(388, 349);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.groupBox2);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(394, 374);
			this.Name = "端末登録";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 端末登録";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
			this.Load += new System.EventHandler(this.端末登録_Load);
			this.Closed += new System.EventHandler(this.端末登録_Closed);
			((System.ComponentModel.ISupportInitialize)(this.ds送り状)).EndInit();
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
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

		private void 初期設定()
		{
			// 端末ＩＤ
			lab端末ID.Text = gs端末ＣＤ;
			// プリンタ有無
			if(gsプリンタＦＧ == "1")
			{
				rBtn有り.Checked = true;
				rBtn無し.Checked = false;
// ADD 2008.10.17 東都）高木 テスト印刷機能の追加 START
				btnテスト印刷.Visible = true;
// ADD 2008.10.17 東都）高木 テスト印刷機能の追加 END
			}
			else
			{
				rBtn有り.Checked = false;
				rBtn無し.Checked = true;
// ADD 2008.10.17 東都）高木 テスト印刷機能の追加 START
				btnテスト印刷.Visible = false;
// ADD 2008.10.17 東都）高木 テスト印刷機能の追加 END
			}
			// プリンタ種類
			//レーザプリンタ削除
//			if(gsプリンタ種類 == "L0001  ")
				listプリンタ.SelectedIndex = 0;
//			else
//				listプリンタ.SelectedIndex = 1;
// ADD 2006.06.20 東都）高木 ＳＡＴＯ製プリンタ対応 START
			// ＳＡＴＯ製サーマルプリンタ（ＵＳＢ）
			if(gsプリンタ種類 == "S0002")
				listプリンタ.SelectedIndex = 1;
// ADD 2006.06.20 東都）高木 ＳＡＴＯ製プリンタ対応 END
//// ADD 2006.07.19 東都）高木 ＴＥＣ製プリンタ対応 START
//			// ＴＥＣ製サーマルプリンタ（ＵＳＢ）
//			if(gsプリンタ種類 == "S0003")
//				listプリンタ.SelectedIndex = 2;
//// ADD 2006.07.19 東都）高木 ＴＥＣ製プリンタ対応 END
//// ADD 2006.08.10 東都）高木 ＩＣタグ対応ＳＡＴＯ製プリンタ対応 START
//			// ＩＣタグ対応ＳＡＴＯ製サーマルプリンタ
//			if(gsプリンタ種類 == "S0004")
//				listプリンタ.SelectedIndex = 3;
//// ADD 2006.08.10 東都）高木 ＩＣタグ対応ＳＡＴＯ製プリンタ対応 END
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 START
			// ＳＡＴＯ製サーマルプリンタ（CS408T）
			if(gsプリンタ種類 == "S0005"){
				listプリンタ.SelectedIndex = 1;
			}
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 END
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 START
			// ＳＡＴＯ製サーマルプリンタ（CF408T）
			if(gsプリンタ種類 == "S0006")
			{
				listプリンタ.SelectedIndex = 1;
			}
// MOD 2013.04.05 TDI）綱澤 ＳＡＴＯ製プリンタ(CF408T)対応 END
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 START
			// ＴＥＣ製サーマルプリンタ（B-EV4）
			if(gsプリンタ種類 == "S0007")
			{
				listプリンタ.SelectedIndex = 2;
			}
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 END
// MOD 2015.02.12 BEVAS）前田 ＴＥＣ製プリンタ(B-LV4)対応 START
			// ＴＥＣ製サーマルプリンタ（B-LV4）
			if(gsプリンタ種類 == "S0008")
			{
				listプリンタ.SelectedIndex = 2;
			}
// MOD 2015.02.12 BEVAS）前田 ＴＥＣ製プリンタ(B-LV4)対応 END
		}
		private void 端末登録_Load(object sender, System.EventArgs e)
		{

			初期設定();
		}

		private void btn更新_Click(object sender, System.EventArgs e)
		{
// MOD 2005.05.31 東都）小童谷 プリンタチェック START
			texメッセージ.Text = "";
// DEL 2006.07.19 東都）高木 ＴＥＣ製プリンタ対応 START
//			if(rBtn有り.Checked)
//			{
//				try
//				{
//					プリンタチェック();
//				}
//				catch(Exception ex)
//				{
//					ビープ音();
//					MessageBox.Show(ex.Message, "プリンタチェック",
//						MessageBoxButtons.OK, MessageBoxIcon.Information);
//					return;
//				}
//			}
// DEL 2006.07.19 東都）高木 ＴＥＣ製プリンタ対応 END
// MOD 2005.05.31 東都）小童谷 プリンタチェック START

			// データ作成
			String[] sKey = new string[5];
			sKey[0] = gs端末ＣＤ;
			// プリンタの有無
			if(rBtn有り.Checked)
				sKey[1] = "1";
			else
				sKey[1] = "0";
			// プリンタのフォーマットの種類
			switch(listプリンタ.SelectedIndex)
			{
// MOD 2006.06.20 東都）高木 ＳＡＴＯ製プリンタ対応 START
//				case 0:	// レーザープリンタ
//					sKey[2] = "L0001  ";
//					break;
//
//				case 1:		// サーマルプリンタ（ＵＳＢ）
//					sKey[2] = "S0001  ";
//					break;
//
//				default:
//					sKey[2] = "S0001  ";
//					break;

				case 1:		// ＳＡＴＯ製サーマルプリンタ（ＵＳＢ）
					sKey[2] = "S0002";
					break;
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 START
				case 2:		// ＳＡＴＯ製サーマルプリンタ（ＵＳＢ）
					sKey[2] = "S0007";
					break;
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 END
/*
// ADD 2006.07.19 東都）高木 ＴＥＣ製プリンタ対応 START
				case 2:		// ＴＥＣ製サーマルプリンタ（ＵＳＢ）
					sKey[2] = "S0003";
					break;
// ADD 2006.07.19 東都）高木 ＴＥＣ製プリンタ対応 END

// ADD 2006.08.10 東都）高木 ＩＣタグ対応ＳＡＴＯ製プリンタ対応 START
				case 3:		// ＩＣタグ対応ＳＡＴＯ製サーマルプリンタ
					sKey[2] = "S0004";
					break;
// ADD 2006.08.10 東都）高木 ＩＣタグ対応ＳＡＴＯ製プリンタ対応 END
*/
				default:	// ＺＥＢＲＡ製サーマルプリンタ（ＵＳＢ）
					sKey[2] = "S0001";
					break;
// MOD 2006.06.20 東都）高木 ＳＡＴＯ製プリンタ対応 END
			}
			sKey[3] = "端末登録";
			sKey[4] = gs利用者ＣＤ;
// ADD 2006.07.19 東都）高木 ＴＥＣ製プリンタ対応 START
			if(rBtn有り.Checked)
			{
				try
				{
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 START
//					プリンタチェック(sKey[2]);
					sKey[2] = プリンタチェック(sKey[2]);
// MOD 2011.12.20 東都）高木 ＳＡＴＯ製プリンタ(CS408T)対応 END
				}
				catch(Exception ex)
				{
					ビープ音();
					MessageBox.Show(ex.Message, "プリンタチェック",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
// ADD 2006.07.19 東都）高木 ＴＥＣ製プリンタ対応 END

//			DialogResult result = MessageBox.Show("既に存在するデータに上書きしますか？","更新",MessageBoxButtons.YesNo);
//			if(result == DialogResult.Yes)
//			{
				// カーソルを砂時計にする
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				string sRet = "";
				try
				{
					// 端末情報更新
					// 引数：会員ＣＤ、利用者ＣＤ、サーマルプリンタ有無、プリンタ種類、
					texメッセージ.Text = "更新中．．．";
					if(sv_init == null) sv_init = new is2init.Service1();
					sRet = sv_init.Upd_tanmatsu(gsaユーザ,sKey);
				}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
				catch (System.Net.WebException)
				{
					sRet = gs通信エラー;
				}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
				catch (Exception ex)
				{
					sRet = "通信エラー：" + ex.Message;
				}
				// カーソルをデフォルトに戻す
				Cursor = System.Windows.Forms.Cursors.Default;

				texメッセージ.Text = sRet;
				// 正常終了時
				if(sRet.Length == 4)
				{
					texメッセージ.Text = "";
					gsプリンタＦＧ = sKey[1];
					gsプリンタ種類 = sKey[2];
					this.Close();
				}
//			}
		}

// ADD 2005.05.24 東都）小童谷 フォーカス移動 START
		private void 端末登録_Closed(object sender, System.EventArgs e)
		{
			texメッセージ.Text = "";
			if(rBtn有り.Checked == true)
				rBtn有り.Focus();
			else
				rBtn無し.Focus();
		}
// ADD 2005.05.24 東都）小童谷 フォーカス移動 END

		private void btnテスト印刷_Click(object sender, System.EventArgs e)
		{
			// プリンタの有無
			if(rBtn有り.Checked == false) return; 

			// プリンタのフォーマットの種類
			string sPrtFormat = "";
			switch(listプリンタ.SelectedIndex)
			{
				case 1:		// ＳＡＴＯ製サーマルプリンタ（ＵＳＢ）
					sPrtFormat = "S0002";
					break;
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 START
				case 2:		// ＴＥＣ製サーマルプリンタ（ＵＳＢ）
					sPrtFormat = "S0007";
					break;
// MOD 2013.10.22 BEVAS）高杉 ＴＥＣ製プリンタ(B-EV4)対応 END
				default:	// ＺＥＢＲＡ製サーマルプリンタ（ＵＳＢ）
					sPrtFormat = "S0001";
					break;
			}

			try
			{
				プリンタチェック(sPrtFormat);
			}
			catch(Exception ex)
			{
				ビープ音();
				MessageBox.Show(ex.Message, "プリンタチェック",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			Cursor = System.Windows.Forms.Cursors.AppStarting;

// DEL 2008.10.15 東都）高木 テスト印刷機能の追加 START
//			i送り状ＦＧ = 1;
// DEL 2008.10.15 東都）高木 テスト印刷機能の追加 END

// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） START
//			ds送り状.Clear();
			送り状データクリア();
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） END

			try
			{
				テスト印刷指示(sender, e);
			}
			catch (Exception ex)
			{
				texメッセージ.Text = ex.Message;
				ビープ音();
				return;
			}
			Cursor = System.Windows.Forms.Cursors.Default;

// DEL 2008.10.15 東都）高木 テスト印刷機能の追加 START
//			if(i送り状ＦＧ == 1)
// DEL 2008.10.15 東都）高木 テスト印刷機能の追加 END
				送り状帳票印刷();
		
			texメッセージ.Text = "";
// DEL 2008.10.15 東都）高木 テスト印刷機能の追加 START
//			if(i送り状ＦＧ == 1)
//				Close();
// DEL 2008.10.15 東都）高木 テスト印刷機能の追加 END
		}

// ADD 2008.10.17 東都）高木 テスト印刷機能の追加 START
		private void テスト印刷指示(object sender, System.EventArgs e)
		{
			try
			{
				//入力チェック
//				i印刷ＦＧ = 0;
//				btn更新_Click(sender,e);
//				if(i印刷ＦＧ == 0)
//				{
//					Cursor = System.Windows.Forms.Cursors.Default;
//					return;
//				}

				//データ設定
				string[] sPrintData = new string[39];
				sPrintData[0]  = "";
				sPrintData[1]  = "";	// tex届け先コード.Text;    
				sPrintData[2]  = "";	// tex届け先電話番号１.Text;
				sPrintData[3]  = "";	// tex届け先電話番号２.Text;
				sPrintData[4]  = "";	// tex届け先電話番号３.Text;
				if(sPrintData[2].Length == 0) sPrintData[2] = "123456";
				if(sPrintData[3].Length == 0) sPrintData[3] = "2234";
				if(sPrintData[4].Length == 0) sPrintData[4] = "3234";

				sPrintData[5]  = "";	// tex届け先住所１.Text;    
				sPrintData[6]  = "";	// tex届け先住所２.Text;    
				sPrintData[7]  = "";	// tex届け先住所３.Text;    
				sPrintData[8]  = "";	// tex届け先名前１.Text;    
				sPrintData[9]  = "";	// tex届け先名前２.Text;    
				sPrintData[10] = gs出荷日;	// YYYYMMDD変換(dt出荷日.Value);;

				//送り状番号
				sPrintData[11] = "00001234567890";
				//チェックデジット（７で割った余り）の付加
				sPrintData[11] = sPrintData[11] + (long.Parse(sPrintData[11]) % 7).ToString();

				sPrintData[12] = "";	// tex届け先郵便番号１.Text + tex届け先郵便番号２.Text;
//保留　着店ＣＤの検索
//保留　着店非表示
//保留　発店名の検索
//保留　仕分の検索
				sPrintData[13] = "0999";	//着店ＣＤ
				if(gs利用者部門店所ＣＤ == null || gs利用者部門店所ＣＤ.Length == 0){
					sPrintData[14] = "0888";
				}else{
					sPrintData[14] = "0" + gs利用者部門店所ＣＤ.Trim();
				}
				sPrintData[15] = "";	// tex依頼主電話番号１.Text;
				sPrintData[16] = "";	// tex依頼主電話番号２.Text;
				sPrintData[17] = "";	// tex依頼主電話番号３.Text;
				if(sPrintData[15].Length == 0) sPrintData[15] = "423456";
				if(sPrintData[16].Length == 0) sPrintData[16] = "5234";
				if(sPrintData[17].Length == 0) sPrintData[17] = "6234";
				sPrintData[18] = "";	// tex依頼主住所１.Text;
				sPrintData[19] = "";	// tex依頼主住所２.Text;
				sPrintData[20] = "";	//依頼主住所３
				sPrintData[21] = "";	// tex依頼主名前１.Text;
				sPrintData[22] = "";	// tex依頼主名前２.Text;
				sPrintData[23] = "0";	// nUD個数.Value.ToString();
				if(sPrintData[23].Length == 0) sPrintData[23] = "99";
				if(sPrintData[23].Trim().Equals("0")) sPrintData[23] = "99";

				//才数の場合：重量＝才数ｘ８
//				if(i才数ＦＧ == 0){
//					sPrintData[24] = "0";	// (nUD重量.Value * 8).ToString();
//				}else{
					sPrintData[24] = "0";	// nUD重量.Value.ToString();
//				}
				sPrintData[25] = "0";	// nUD保険金額.Value.ToString();

//				if(cBox指定日.Checked == true){
//					sPrintData[26] = YYYYMMDD変換(dt指定日.Value);
//				}else{
					sPrintData[26] = "0";
//				}

				sPrintData[27] = "";	// tex輸送名親.Text;        
				sPrintData[28] = "";	// tex輸送名子.Text;        
				sPrintData[29] = "";	// tex記事名１.Text;        
				sPrintData[30] = "";	// tex記事名２.Text;        
				sPrintData[31] = "";	// tex記事名３.Text;        

				sPrintData[32] = "1";	//元着区分
				sPrintData[33] = "0";	//送り状発行済ＦＧ

				sPrintData[34] = "";	// tex依頼主部署.Text;      
				sPrintData[35] = "";	// texお客様管理番号.Text;  
				sPrintData[36] = "0";	//０：必着、１：指定

//				sPrintData[37] = "XXX";	//仕分ＣＤ
//				sPrintData[38] = "発店名４";	//発店名
				sPrintData[37] = "ﾃｽﾄ";	//仕分ＣＤ
				sPrintData[38] = "ＸＸＸＸ";	//発店名

				{
					送り状データ.table送り状Row tr = (送り状データ.table送り状Row)ds送り状.table送り状.NewRow();
						
					tr.BeginEdit();
					tr.印刷順 = i印刷順++;
					tr.荷受人ＣＤ     = sPrintData[1];
					tr.荷受人電話番号 = "(" + sPrintData[2] + ")" + sPrintData[3] + "-" + sPrintData[4];

// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//					string s住所編集  = 住所編集(sPrintData[5]);
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
//					string[] s住所分割 = s住所編集.Split(' ');
					string[] s住所分割 = new string []{"★★★★★　テスト印刷　★★★★★"};
					tr.荷受人住所県   = s住所分割[0];
					if (s住所分割.Length > 1)
						tr.荷受人住所市 = s住所分割[1].PadLeft(s住所分割[1].Length + s住所分割[0].Length);
					else 
						tr.荷受人住所市 = "";
					if (s住所分割.Length > 2)
					{
						if (s住所分割[0].Length + s住所分割[1].Length >= 9)
							tr.荷受人住所町 = s住所分割[2].PadLeft(s住所分割[2].Length + s住所分割[0].Length + s住所分割[1].Length + 1);
						else
							tr.荷受人住所町 = s住所分割[2].PadLeft(s住所分割[2].Length + s住所分割[0].Length + s住所分割[1].Length);
					}
					else
						tr.荷受人住所町 = "";

//					tr.荷受人住所１   = sPrintData[5];
					tr.荷受人住所１   = "★★★★★　テスト印刷　★★★★★";
					tr.荷受人住所２   = sPrintData[6];
					tr.荷受人住所３   = sPrintData[7];
					tr.荷受人名前１   = sPrintData[8];
					tr.荷受人名前２   = sPrintData[9];
					tr.出荷日年       = sPrintData[10].Substring(2, 2);
					if(sPrintData[10].Substring(4, 1) == "0")
						tr.出荷日月       = " " + sPrintData[10].Substring(5, 1);
					else
						tr.出荷日月       = sPrintData[10].Substring(4, 2);
					if(sPrintData[10].Substring(6, 1) == "0")
						tr.出荷日日       = " " + sPrintData[10].Substring(7, 1);
					else
						tr.出荷日日       = sPrintData[10].Substring(6, 2);
					tr.送り状番号     = sPrintData[11].Substring(4,3) + "-" + sPrintData[11].Substring(7,4) + "-" + sPrintData[11].Substring(11,4);

					tr.バーコード     = "A" + sPrintData[11].Substring(4) + "01" + "A";

					if(sPrintData[13].Length == 0)
						tr.着店ＣＤ       = "";
					else
						tr.着店ＣＤ       = sPrintData[13].Substring(1);

					//仕分ＣＤが設定されている場合、仕分ＣＤ、発店名を印字
					if(sPrintData[37].Length > 0){
						tr.仕分ＣＤ       = sPrintData[37];
						tr.発店名         = sPrintData[38];
					}else{
						tr.仕分ＣＤ       = "";
						tr.発店名         = "";
					}
					tr.発店ＣＤ       = sPrintData[14].Substring(1, 3);

					if(sPrintData[14].Substring(1, 3) == "047"){
						tr.出荷日年       = "";
						tr.出荷日月       = "";
						tr.出荷日日       = "";
						tr.発店名         = "";
						tr.発店ＣＤ       = "";
					}

					tr.荷送人電話番号 = "(" + sPrintData[15] + ")" + sPrintData[16] + "-" + sPrintData[17];

//保留 MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
					tr.荷送人住所１   = 住所編集(sPrintData[18]);
//					tr.荷送人住所１   = sPrintData[18];
//保留 MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
					tr.荷送人住所２   = sPrintData[19];
					tr.荷送人住所３   = sPrintData[18];
					tr.荷送人名前１   = sPrintData[21];
					tr.荷送人名前２   = sPrintData[22];
					tr.担当者         = sPrintData[34];
					tr.個数           = sPrintData[23];

					tr.連番           = "1";

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

					tr.EndEdit();
					ds送り状.table送り状.Rows.Add(tr);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
// ADD 2008.10.17 東都）高木 テスト印刷機能の追加 END

	}
}
