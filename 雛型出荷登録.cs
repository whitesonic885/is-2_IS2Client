using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [クイックエントリー]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// MOD 2008.11.14 東都）高木 指定日区分の復活 
	//--------------------------------------------------------------------------
	// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック 
	// ADD 2009.04.02 東都）高木 稼働日対応 
	// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 
	//--------------------------------------------------------------------------
	// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 
	// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 
	// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） 
	// ADD 2010.12.14 ACT）垣原 王子運送の対応 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない 
	// MOD 2011.07.14 東都）高木 記事行の追加 
	//--------------------------------------------------------------------------
	// MOD 2016.04.13 BEVAS）松本 配達指定日上限の拡張
	//--------------------------------------------------------------------------
	public class 雛型出荷登録 : 共通フォーム
	{
		private int  i印刷ＦＧ = 0;
		private int  i雛型ＮＯ = 0;
		private string sジャーナルＮＯ = "";
		private string s登録日 = "";
// ADD 2009.04.02 東都）高木 稼働日対応 START
		private DateTime dt指定日最大値;
		private DateTime dt指定日最小値;
// ADD 2009.04.02 東都）高木 稼働日対応 END
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
		private bool b指定日チェックＭＳＧ有 = false;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END

		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnアイコン表示;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ListView listView雛型;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.Button btn出荷登録;
		private System.Windows.Forms.Button btn送り状印刷;
		private System.Windows.Forms.Button btn雛型作成;
		private System.Windows.Forms.Button btn雛型編集;
		private System.Windows.Forms.Button btn雛型削除;
		private System.Windows.Forms.DateTimePicker dt出荷日;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab日時;
		private System.Windows.Forms.DateTimePicker dt指定日;
		private System.Windows.Forms.TextBox texお客様名;
		private System.Windows.Forms.Label labお客様名;
		private System.Windows.Forms.Label lab利用部門;
		private System.Windows.Forms.TextBox tex利用部門;
		private System.Windows.Forms.Label lab雛型出荷登録;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.Label lab出荷日;
		private System.Windows.Forms.Label lab指定日;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox cBox指定日;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnショートカット;
		private System.Windows.Forms.ComboBox cmb指定日区分;
		private System.Boolean アイコン表示状態 = true;

		public 雛型出荷登録()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(雛型出荷登録));
			this.panel6 = new System.Windows.Forms.Panel();
			this.texお客様名 = new System.Windows.Forms.TextBox();
			this.labお客様名 = new System.Windows.Forms.Label();
			this.lab利用部門 = new System.Windows.Forms.Label();
			this.tex利用部門 = new System.Windows.Forms.TextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab日時 = new System.Windows.Forms.Label();
			this.lab雛型出荷登録 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btn雛型削除 = new System.Windows.Forms.Button();
			this.btn雛型編集 = new System.Windows.Forms.Button();
			this.btn雛型作成 = new System.Windows.Forms.Button();
			this.btn送り状印刷 = new System.Windows.Forms.Button();
			this.btn出荷登録 = new System.Windows.Forms.Button();
			this.texメッセージ = new System.Windows.Forms.TextBox();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.btnショートカット = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.panel5 = new System.Windows.Forms.Panel();
			this.cmb指定日区分 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cBox指定日 = new System.Windows.Forms.CheckBox();
			this.dt出荷日 = new System.Windows.Forms.DateTimePicker();
			this.lab出荷日 = new System.Windows.Forms.Label();
			this.dt指定日 = new System.Windows.Forms.DateTimePicker();
			this.lab指定日 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnアイコン表示 = new System.Windows.Forms.Button();
			this.listView雛型 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel5.SuspendLayout();
			this.groupBox1.SuspendLayout();
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
			this.panel7.Controls.Add(this.lab雛型出荷登録);
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
			// lab雛型出荷登録
			// 
			this.lab雛型出荷登録.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.lab雛型出荷登録.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab雛型出荷登録.ForeColor = System.Drawing.Color.White;
			this.lab雛型出荷登録.Location = new System.Drawing.Point(12, 2);
			this.lab雛型出荷登録.Name = "lab雛型出荷登録";
			this.lab雛型出荷登録.Size = new System.Drawing.Size(264, 24);
			this.lab雛型出荷登録.TabIndex = 0;
			this.lab雛型出荷登録.Text = "クイックエントリー";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.btn雛型削除);
			this.panel8.Controls.Add(this.btn雛型編集);
			this.panel8.Controls.Add(this.btn雛型作成);
			this.panel8.Controls.Add(this.btn送り状印刷);
			this.panel8.Controls.Add(this.btn出荷登録);
			this.panel8.Controls.Add(this.texメッセージ);
			this.panel8.Controls.Add(this.btn閉じる);
			this.panel8.Controls.Add(this.btnショートカット);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 14;
			// 
			// btn雛型削除
			// 
			this.btn雛型削除.ForeColor = System.Drawing.Color.Blue;
			this.btn雛型削除.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn雛型削除.Location = new System.Drawing.Point(372, 6);
			this.btn雛型削除.Name = "btn雛型削除";
			this.btn雛型削除.Size = new System.Drawing.Size(62, 48);
			this.btn雛型削除.TabIndex = 10;
			this.btn雛型削除.Text = "ライブラリ　削除";
			this.btn雛型削除.Click += new System.EventHandler(this.btn雛型削除_Click);
			// 
			// btn雛型編集
			// 
			this.btn雛型編集.ForeColor = System.Drawing.Color.Blue;
			this.btn雛型編集.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn雛型編集.Location = new System.Drawing.Point(302, 6);
			this.btn雛型編集.Name = "btn雛型編集";
			this.btn雛型編集.Size = new System.Drawing.Size(62, 48);
			this.btn雛型編集.TabIndex = 9;
			this.btn雛型編集.Text = "ライブラリ　編集";
			this.btn雛型編集.Click += new System.EventHandler(this.btn雛型編集_Click);
			// 
			// btn雛型作成
			// 
			this.btn雛型作成.ForeColor = System.Drawing.Color.Blue;
			this.btn雛型作成.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn雛型作成.Location = new System.Drawing.Point(232, 6);
			this.btn雛型作成.Name = "btn雛型作成";
			this.btn雛型作成.Size = new System.Drawing.Size(62, 48);
			this.btn雛型作成.TabIndex = 8;
			this.btn雛型作成.Text = "ライブラリ　登録";
			this.btn雛型作成.Click += new System.EventHandler(this.btn雛型作成_Click);
			// 
			// btn送り状印刷
			// 
			this.btn送り状印刷.ForeColor = System.Drawing.Color.Blue;
			this.btn送り状印刷.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn送り状印刷.Location = new System.Drawing.Point(82, 6);
			this.btn送り状印刷.Name = "btn送り状印刷";
			this.btn送り状印刷.Size = new System.Drawing.Size(62, 48);
			this.btn送り状印刷.TabIndex = 2;
			this.btn送り状印刷.Text = "ラベル　　印刷";
			this.btn送り状印刷.Click += new System.EventHandler(this.btn送り状印刷_Click);
			// 
			// btn出荷登録
			// 
			this.btn出荷登録.ForeColor = System.Drawing.Color.Blue;
			this.btn出荷登録.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn出荷登録.Location = new System.Drawing.Point(152, 6);
			this.btn出荷登録.Name = "btn出荷登録";
			this.btn出荷登録.Size = new System.Drawing.Size(62, 48);
			this.btn出荷登録.TabIndex = 7;
			this.btn出荷登録.Text = "エントリー";
			this.btn出荷登録.Click += new System.EventHandler(this.btn出荷登録_Click);
			// 
			// texメッセージ
			// 
			this.texメッセージ.BackColor = System.Drawing.Color.PaleGreen;
			this.texメッセージ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texメッセージ.ForeColor = System.Drawing.Color.Red;
			this.texメッセージ.Location = new System.Drawing.Point(520, 4);
			this.texメッセージ.Multiline = true;
			this.texメッセージ.Name = "texメッセージ";
			this.texメッセージ.ReadOnly = true;
			this.texメッセージ.Size = new System.Drawing.Size(270, 50);
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
			// btnショートカット
			// 
			this.btnショートカット.ForeColor = System.Drawing.Color.Blue;
			this.btnショートカット.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnショートカット.Location = new System.Drawing.Point(450, 6);
			this.btnショートカット.Name = "btnショートカット";
			this.btnショートカット.Size = new System.Drawing.Size(62, 48);
			this.btnショートカット.TabIndex = 19;
			this.btnショートカット.Text = "ﾃﾞｽｸﾄｯﾌﾟに貼付";
			this.btnショートカット.Click += new System.EventHandler(this.btnショートカット_Click);
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
			this.panel5.Controls.Add(this.cmb指定日区分);
			this.panel5.Controls.Add(this.cBox指定日);
			this.panel5.Controls.Add(this.dt出荷日);
			this.panel5.Controls.Add(this.lab出荷日);
			this.panel5.Controls.Add(this.lab指定日);
			this.panel5.Controls.Add(this.label2);
			this.panel5.Controls.Add(this.dt指定日);
			this.panel5.Font = new System.Drawing.Font("MS UI Gothic", 12F);
			this.panel5.Location = new System.Drawing.Point(1, 6);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(579, 32);
			this.panel5.TabIndex = 1;
			// 
			// cmb指定日区分
			// 
			this.cmb指定日区分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb指定日区分.Items.AddRange(new object[] {
														  "必着",
														  "指定"});
			this.cmb指定日区分.Location = new System.Drawing.Point(490, 4);
			this.cmb指定日区分.Name = "cmb指定日区分";
			this.cmb指定日区分.Size = new System.Drawing.Size(56, 24);
			this.cmb指定日区分.TabIndex = 44;
			this.cmb指定日区分.TabStop = false;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(350, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 16);
			this.label2.TabIndex = 10;
			// 
			// cBox指定日
			// 
			this.cBox指定日.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.cBox指定日.Location = new System.Drawing.Point(326, 8);
			this.cBox指定日.Name = "cBox指定日";
			this.cBox指定日.Size = new System.Drawing.Size(16, 16);
			this.cBox指定日.TabIndex = 8;
			this.cBox指定日.TabStop = false;
			this.cBox指定日.Text = "checkBox1";
			this.cBox指定日.Click += new System.EventHandler(this.cBox指定日_Click);
			// 
			// dt出荷日
			// 
			this.dt出荷日.Location = new System.Drawing.Point(86, 4);
			this.dt出荷日.MaxDate = new System.DateTime(2105, 12, 31, 0, 0, 0, 0);
			this.dt出荷日.MinDate = new System.DateTime(2005, 1, 1, 0, 0, 0, 0);
			this.dt出荷日.Name = "dt出荷日";
			this.dt出荷日.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.dt出荷日.Size = new System.Drawing.Size(144, 23);
			this.dt出荷日.TabIndex = 0;
			this.dt出荷日.ValueChanged += new System.EventHandler(this.dt出荷日_ValueChanged);
			// 
			// lab出荷日
			// 
			this.lab出荷日.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab出荷日.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab出荷日.Location = new System.Drawing.Point(8, 8);
			this.lab出荷日.Name = "lab出荷日";
			this.lab出荷日.Size = new System.Drawing.Size(56, 16);
			this.lab出荷日.TabIndex = 6;
			this.lab出荷日.Text = "出荷日";
			// 
			// dt指定日
			// 
			this.dt指定日.Location = new System.Drawing.Point(346, 4);
			this.dt指定日.MaxDate = new System.DateTime(2105, 12, 31, 0, 0, 0, 0);
			this.dt指定日.MinDate = new System.DateTime(2005, 1, 1, 0, 0, 0, 0);
			this.dt指定日.Name = "dt指定日";
			this.dt指定日.Size = new System.Drawing.Size(142, 23);
			this.dt指定日.TabIndex = 9;
			this.dt指定日.TabStop = false;
			this.dt指定日.Value = new System.DateTime(2005, 2, 2, 0, 0, 0, 0);
			this.dt指定日.DropDown += new System.EventHandler(this.dt指定日_DropDown);
			// 
			// lab指定日
			// 
			this.lab指定日.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab指定日.ForeColor = System.Drawing.Color.LimeGreen;
			this.lab指定日.Location = new System.Drawing.Point(256, 8);
			this.lab指定日.Name = "lab指定日";
			this.lab指定日.Size = new System.Drawing.Size(56, 16);
			this.lab指定日.TabIndex = 6;
			this.lab指定日.Text = "指定日";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Blue;
			this.label1.Location = new System.Drawing.Point(22, 90);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 380);
			this.label1.TabIndex = 17;
			this.label1.Text = "ライブラリ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnアイコン表示
			// 
			this.btnアイコン表示.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.btnアイコン表示.ForeColor = System.Drawing.Color.Blue;
			this.btnアイコン表示.Location = new System.Drawing.Point(690, 58);
			this.btnアイコン表示.Name = "btnアイコン表示";
			this.btnアイコン表示.Size = new System.Drawing.Size(78, 26);
			this.btnアイコン表示.TabIndex = 18;
			this.btnアイコン表示.Text = "一覧表示";
			this.btnアイコン表示.Click += new System.EventHandler(this.btnアイコン表示_Click);
			// 
			// listView雛型
			// 
			this.listView雛型.BackColor = System.Drawing.Color.Honeydew;
			this.listView雛型.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.columnHeader1,
																						 this.columnHeader2});
			this.listView雛型.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.listView雛型.LabelEdit = true;
			this.listView雛型.Location = new System.Drawing.Point(44, 90);
			this.listView雛型.Name = "listView雛型";
			this.listView雛型.Size = new System.Drawing.Size(726, 380);
			this.listView雛型.TabIndex = 0;
			this.listView雛型.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView雛型_KeyDown);
			this.listView雛型.DoubleClick += new System.EventHandler(this.listView雛型_DoubleClick);
			this.listView雛型.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView雛型_ColumnClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "雛型名";
			this.columnHeader1.Width = 662;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "表示順";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel5);
			this.groupBox1.Location = new System.Drawing.Point(44, 473);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(584, 40);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// 雛型出荷登録
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 574);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnアイコン表示);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listView雛型);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "雛型出荷登録";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 クイックエントリー";
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 START
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Onエンター移動);
            //this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Onエンターキャンセル);
// MOD 2016.09.28 Vivouac) 菊池 Visual Studio 2013形式に変更 END
            this.Load += new System.EventHandler(this.雛型出荷登録_Load);
			this.Closed += new System.EventHandler(this.雛型出荷登録_Closed);
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
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
		private void 雛型出荷登録_Load(object sender, System.EventArgs e)
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

			// 出荷日の初期設定（当日）
			部門出荷日情報更新();
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
			//指定日チェックを無効にする
			//（dt出荷日.Value）を変更したイベントでチェックが走る為
			cBox指定日.Checked = false;
			b指定日チェックＭＳＧ有 = false;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
			dt出荷日.Value   = gdt出荷日;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
			b指定日チェックＭＳＧ有 = true;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
			dt出荷日.MinDate = gdt出荷日;
// ADD 2009.04.02 東都）高木 稼働日対応 START
//			dt出荷日.MaxDate = gdt出荷日.AddDays(7);
			dt出荷日.MaxDate = gdt出荷日最大値;
// ADD 2009.04.02 東都）高木 稼働日対応 END
			// 指定日の初期設定（当日＋２日）
// MOD 2007.02.20 東都）高木 出荷日を翌日に変更 START
//			dt指定日.Value   = gdt出荷日.AddDays(2);
			dt指定日.Value   = gdt出荷日.AddDays(1);
// MOD 2007.02.20 東都）高木 出荷日を翌日に変更 END
			dt指定日.MinDate = gdt出荷日;
// ADD 2009.04.02 東都）高木 稼働日対応 START
//			dt指定日.MaxDate = gdt出荷日.AddDays(20);
// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 START
//			dt指定日.MaxDate = gdt出荷日.AddDays(14);
			if(gs部門店所ＣＤ.Equals("047")){
				dt指定日.MaxDate = gdt出荷日.AddDays(90);
			}else{
				dt指定日.MaxDate = gdt出荷日.AddDays(14);
			}
// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 END
// MOD 2016.04.13 BEVAS）松本 配達指定日上限の拡張 START
			//セリア様の場合、配達指定日の上限を180日にまで拡張
			if(gs会員ＣＤ.Equals(gs指定日上限拡張会員ＣＤ))
			{
				dt指定日.MaxDate = gdt出荷日.AddDays(180);
			}
// MOD 2016.04.13 BEVAS）松本 配達指定日上限の拡張 END
// ADD 2009.04.02 東都）高木 稼働日対応 END
//			dt指定日.Checked = false;
			cBox指定日.Checked = false;
//			dt指定日.Visible   = false;
			label2.Visible = true;
// MOD 2007.02.20 東都）高木 指定日を必着に固定 START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
			cmb指定日区分.Visible = false;
			cmb指定日区分.SelectedIndex = 0;
//			lab必着.Visible = false;
// MOD 2008.11.14 東都）高木 指定日区分の復活 END
// MOD 2007.02.20 東都）高木 指定日を必着に固定 END

			// 端末設定でプリンタを使用できない設定の場合、印刷ボタン使用不可
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 START
//			if(gsプリンタＦＧ != "1")
			if(gsプリンタＦＧ != "1" || gb自動出力ＯＮ)
// MOD 2010.05.11 東都）高木 ラベル印刷のスレッド対応 END
			{
				btn送り状印刷.Visible = false;
			}
			else
			{
				btn送り状印刷.Visible = true;
			}

			// イメージの設定
			アイコンイメージの初期化();
			listView雛型.LargeImageList = imageList64;
			listView雛型.SmallImageList = imageList16;

			ライブラリ更新();
			listView雛型.Focus();

			// １つ目の項目を選択状態にする
			if(listView雛型.Items.Count > 0)
				listView雛型.Items[0].Selected = true;
		}

		private void ライブラリ更新()
		{
			// ライブラリの初期設定
			listView雛型.Items.Clear();

			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			String[] sRet = {""};
			try
			{
				// ライブラリの取得
				// 引数：会員ＣＤ、部門ＣＤ
				// 戻値：ステータス、件数、雛型ＮＯ、雛型名称、ファイル名
				texメッセージ.Text = "データ取得中．．．";
				if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
				sRet = sv_hinagata.Get_hinagata(gsaユーザ,gs会員ＣＤ, gs部門ＣＤ);
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

			texメッセージ.Text = sRet[0];

			// 正常終了以外は終了
			if(sRet[0].Length != 4) return;

			ListViewItem item;
			int iCntHinagata = int.Parse(sRet[1]);
			int iPos = 2;
			for(int iCnt = 0; iCnt < iCntHinagata; iCnt++)
			{
				item = new ListViewItem();
				item.Text = sRet[iPos++];
				item.SubItems.Add(sRet[iPos++]);
				item.ImageIndex = アイコンイメージの取得(sRet[iPos++]);
				item.SubItems.Add(sRet[iPos++]);
				listView雛型.Items.Add(item);
			}
			texメッセージ.Text = "";
		}

		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnアイコン表示_Click(object sender, System.EventArgs e)
		{
			if( アイコン表示状態 )
			{
				listView雛型.View = View.Details;
				アイコン表示状態 = false;
				btnアイコン表示.Text = "アイコン表示";
			}
			else
			{
				listView雛型.View = View.LargeIcon;
				アイコン表示状態 = true;
				btnアイコン表示.Text = "一覧表示";
			}
		}

		private void btn雛型作成_Click(object sender, System.EventArgs e)
		{
// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			雛型登録 画面 = new 雛型登録();
//			画面.Left = this.Left;
//			画面.Top  = this.Top;
//			画面.s雛型名称 = "";
//			画面.i雛型ＮＯ = 0;
//			画面.s登録日 = "";
//			画面.sジャーナルＮＯ = "";
//			this.Visible = false;
//			画面.ShowDialog();
//			this.Visible = true;
			if (g雛型登録 == null)	 g雛型登録 = new 雛型登録();
			g雛型登録.Left = this.Left;
			g雛型登録.Top  = this.Top;
			g雛型登録.s雛型名称 = "";
			g雛型登録.i雛型ＮＯ = 0;
			g雛型登録.s登録日 = "";
			g雛型登録.sジャーナルＮＯ = "";
			this.Visible = false;
			g雛型登録.ShowDialog();
			this.Visible = true;
// MOD 2005.05.24 東都）小童谷 画面高速化 END

			ライブラリ更新();
			listView雛型.Focus();
		}

		private void btn雛型編集_Click(object sender, System.EventArgs e)
		{
			// 選択されていない場合には終了
			if(listView雛型.SelectedItems.Count == 0)
			{	
				MessageBox.Show("データが１件も選択されていません。", "確認",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				listView雛型.Focus();
				return;
			}
			// 複数選択時には終了
			if(listView雛型.SelectedItems.Count > 1)
			{	
				MessageBox.Show("複数のデータを選択した状態では実行できません。\r\n１件のみ選択して実行してください。", "確認",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				listView雛型.Focus();
				return;
			}

			int i選択項目 = listView雛型.SelectedItems[0].Index;

// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			雛型登録 画面 = new 雛型登録();
//			画面.Left = this.Left;
//			画面.Top  = this.Top;
//			画面.s雛型名称 = listView雛型.SelectedItems[0].Text;
//			画面.i雛型ＮＯ = int.Parse(listView雛型.SelectedItems[0].SubItems[1].Text);
//			this.Visible = false;
//			画面.ShowDialog();
//			this.Visible = true;
			if (g雛型登録 == null)	 g雛型登録 = new 雛型登録();
			g雛型登録.Left = this.Left;
			g雛型登録.Top  = this.Top;
			g雛型登録.s雛型名称 = listView雛型.SelectedItems[0].Text;
			g雛型登録.i雛型ＮＯ = int.Parse(listView雛型.SelectedItems[0].SubItems[1].Text);
			this.Visible = false;
			g雛型登録.ShowDialog();
			this.Visible = true;
// MOD 2005.05.24 東都）小童谷 画面高速化 END

			ライブラリ更新();
			listView雛型.Focus();
			if(listView雛型.Items.Count > 0 && i選択項目 < listView雛型.Items.Count)
			{
				listView雛型.Items[i選択項目].Selected = true;
			}
		}

		private void btn出荷登録_Click(object sender, System.EventArgs e)
		{
			// 選択されていない場合には終了
			if(listView雛型.SelectedItems.Count == 0)
			{	
				MessageBox.Show("データが１件も選択されていません。", "確認",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				listView雛型.Focus();
				return;
			}
			// 複数選択時には終了
			if(listView雛型.SelectedItems.Count > 1)
			{	
				MessageBox.Show("複数のデータを選択した状態では実行できません。\r\n１件のみ選択して実行してください。", "確認",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				listView雛型.Focus();
				return;
			}

			// 出荷日チェック
			部門出荷日情報更新();
			if (dt出荷日.Value < gdt出荷日)
			{
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック START
//				string s出荷日 = gs出荷日.Substring(0,4) + "年";
				string s出荷日 = "";
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック END
				if(gs出荷日[4] == '0')
					s出荷日 = s出荷日 + " " + gs出荷日.Substring(5,1) + "月";
				else
					s出荷日 = s出荷日 + gs出荷日.Substring(4,2) + "月";
				if(gs出荷日[6] == '0')
					s出荷日 = s出荷日 + " " + gs出荷日.Substring(7,1) + "日";
				else
					s出荷日 = s出荷日 + gs出荷日.Substring(6,2) + "日";

				MessageBox.Show("出荷日は" + s出荷日 + "以降で入力してください",
					"入力チェック",
					MessageBoxButtons.OK );
				dt出荷日.Focus();
				return;
			}

// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック START
			// 配達指定日チェック
			if (cBox指定日.Checked)
			{
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
				b指定日チェックＭＳＧ有 = true;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
				bool bRet = 出荷日チェック();
				if(bRet == false) return;
			}
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック END

			int i選択項目 = listView雛型.SelectedItems[0].Index;

// MOD 2005.05.24 東都）小童谷 画面高速化 START
//			出荷登録 画面 = new 出荷登録();
//			画面.Left = this.Left;
//			画面.Top = this.Top;
//			画面.s処理ＦＧ = "I";
//			画面.dt雛型出荷日 = dt出荷日.Value;
			if (g出荷登録 == null)	 g出荷登録 = new 出荷登録();
			g出荷登録.Left = this.Left;
			g出荷登録.Top = this.Top;
			g出荷登録.s処理ＦＧ = "I";
			g出荷登録.dt雛型出荷日 = dt出荷日.Value;
//			if(dt指定日.Checked)
			if(cBox指定日.Checked)
			{
//				画面.b雛型指定日  = true;
//				画面.dt雛型指定日 = dt指定日.Value;
				g出荷登録.b雛型指定日  = true;
				g出荷登録.dt雛型指定日 = dt指定日.Value;
// DEL 2007.02.20 東都）高木 指定日を必着に固定 START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
				g出荷登録.i雛型指定日区分 = cmb指定日区分.SelectedIndex;
// MOD 2008.11.14 東都）高木 指定日区分の復活 END
// DEL 2007.02.20 東都）高木 指定日を必着に固定 END
			}
			else
			{
//				画面.b雛型指定日  = false;
				g出荷登録.b雛型指定日  = false;
			}
//			画面.i雛型ＮＯ = int.Parse(listView雛型.SelectedItems[0].SubItems[1].Text);
			g出荷登録.i雛型ＮＯ = int.Parse(listView雛型.SelectedItems[0].SubItems[1].Text);
			this.Visible = false;
//			画面.ShowDialog();
			g出荷登録.ShowDialog();
// MOD 2005.05.24 東都）小童谷 画面高速化 END
			this.Visible = true;
//			ライブラリ更新();
			listView雛型.Focus();
//			if(listView雛型.Items.Count > 0 && i選択項目 < listView雛型.Items.Count){
//				listView雛型.Items[i選択項目].Selected = true;
//			}
		}

		private void btn送り状印刷_Click(object sender, System.EventArgs e)
		{
			// 選択されていない場合には終了
			if(listView雛型.SelectedItems.Count == 0)
			{	
				MessageBox.Show("データが１件も選択されていません。", "確認",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				listView雛型.Focus();
				return;
			}

			// 出荷日チェック
			部門出荷日情報更新();
			if (dt出荷日.Value < gdt出荷日)
			{
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック START
//				string s出荷日 = gs出荷日.Substring(0,4) + "年";
				string s出荷日 = "";
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック END
				if(gs出荷日[4] == '0')
					s出荷日 = s出荷日 + " " + gs出荷日.Substring(5,1) + "月";
				else
					s出荷日 = s出荷日 + gs出荷日.Substring(4,2) + "月";
				if(gs出荷日[6] == '0')
					s出荷日 = s出荷日 + " " + gs出荷日.Substring(7,1) + "日";
				else
					s出荷日 = s出荷日 + gs出荷日.Substring(6,2) + "日";

				MessageBox.Show("出荷日は" + s出荷日 + "以降で入力してください",
					"入力チェック",
					MessageBoxButtons.OK );
				dt出荷日.Focus();
				return;
			}

			// 指定日チェック
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック START
//			if (cBox指定日.Checked == true && dt指定日.Value < dt出荷日.Value)
//			{
//				MessageBox.Show("指定日が正しく入力されていません","入力チェック",
//					MessageBoxButtons.OK );
//				dt指定日.Focus();
//				return;
//			}
			// 配達指定日チェック
			if (cBox指定日.Checked)
			{
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
				b指定日チェックＭＳＧ有 = true;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
				bool bRet = 出荷日チェック();
				if(bRet == false) return;
			}
// MOD 2009.03.05 東都）高木 出荷日および配達指定日の整合性チェック END

			String strMsg = "選択されたラベルを印刷します。\r\n";
			foreach( ListViewItem oItem in listView雛型.SelectedItems )
			{
				strMsg += "\r\n『" + oItem.Text + "』";
			}
			DialogResult result;
			result = MessageBox.Show(strMsg, "ラベル印刷", 
				MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

			if(result == DialogResult.OK)
			{
				string sエラーＮＯ = "";
				int i選択数 = listView雛型.SelectedItems.Count;

				for(int iCnt = 0; iCnt < i選択数; iCnt++)
				{
					i雛型ＮＯ = int.Parse(listView雛型.SelectedItems[iCnt].SubItems[1].Text);
					出荷登録();
					if(i印刷ＦＧ == 1)
					{
// MOD 2006.12.12 東都）小童谷 店所と部門店所が異なる場合は、印刷しない START
//						送り状印刷();
						if(!送り状印刷())
						{
							return;
						}
// MOD 2006.12.12 東都）小童谷 店所と部門店所が異なる場合は、印刷しない START
						if(i印刷ＦＧ == 0)
						{
//							texメッセージ.Text = "印刷処理に失敗しました";
							ビープ音();
							sエラーＮＯ = i雛型ＮＯ.ToString();
							break;
						}
					}
					else
					{
//						texメッセージ.Text = "出荷登録に失敗しました";
						ビープ音();
						sエラーＮＯ = i雛型ＮＯ.ToString();
						break;
					}
				}
				for(int iCnt = 0; iCnt < listView雛型.Items.Count; iCnt++)
				{
					if(sエラーＮＯ != listView雛型.Items[iCnt].SubItems[1].Text)
						listView雛型.Items[iCnt].Selected = false;
				}
				if(i印刷ＦＧ == 1)
					texメッセージ.Text = "";

			}

			listView雛型.Focus();
		}

		private void listView雛型_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyData == Keys.Enter)
			{
				btn送り状印刷_Click(sender, e);
			}
		}

		private void listView雛型_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			switch(e.Column)
			{
				case 0:
					if(listView雛型.Sorting == System.Windows.Forms.SortOrder.Ascending)
					{
						listView雛型.Sorting = System.Windows.Forms.SortOrder.Descending;
					}
					else
					{
						listView雛型.Sorting = System.Windows.Forms.SortOrder.Ascending;
					}
					break;
				case 1:
					listView雛型.Sorting = System.Windows.Forms.SortOrder.None;
					//保留 並べ替え
					break;
			}
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

		private void btn雛型削除_Click(object sender, System.EventArgs e)
		{
			// 選択されていない場合には終了
			if(listView雛型.SelectedItems.Count == 0)
			{	
				MessageBox.Show("データが１件も選択されていません。", "確認",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				listView雛型.Focus();
				return;
			}
			// 複数選択時には終了
			if(listView雛型.SelectedItems.Count > 1)
			{	
				MessageBox.Show("複数のデータを選択した状態では実行できません。\r\n１件のみ選択して実行してください。", "確認",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				listView雛型.Focus();
				return;
			}

			DialogResult result = MessageBox.Show("選択したデータをすべて削除しますか？","削除",MessageBoxButtons.YesNo);
			if(result == DialogResult.Yes)
			{
				string[] sKey = new string[6];
				sKey[0] = gs会員ＣＤ;
				sKey[1] = gs部門ＣＤ;
				sKey[2] = listView雛型.SelectedItems[0].SubItems[1].Text;
				sKey[3] = listView雛型.SelectedItems[0].SubItems[2].Text;
				sKey[4] = "雛型出荷";
				sKey[5] = gs利用者ＣＤ;

				int i選択項目 = listView雛型.SelectedItems[0].Index;

				// カーソルを砂時計にする
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				string sRet = "";
				try
				{
					// 雛型の削除
					// 引数：会員ＣＤ、部門ＣＤ、雛型ＮＯ、更新日時、更新ＰＧ、更新者
					// 戻値：ステータス
					texメッセージ.Text = "削除中．．．";
					if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
					sRet = sv_hinagata.Del_hinagata(gsaユーザ,sKey);
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

				ライブラリ更新();
				if(texメッセージ.Text.Trim() == "" && sRet.Length != 4)
					texメッセージ.Text = sRet;

				if(listView雛型.Items.Count > 0 && i選択項目 < listView雛型.Items.Count)
				{
					listView雛型.Items[i選択項目].Selected = true;
				}
			}
			listView雛型.Focus();
		}

		private void 出荷登録()
		{
			i印刷ＦＧ = 0;

			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			string[] sList = {""};
			try
			{
				texメッセージ.Text = "検索中．．．";
				if(sv_hinagata == null) sv_hinagata = new is2hinagata.Service1();
				sList = sv_hinagata.Get_Hinagata2(gsaユーザ,gs会員ＣＤ, gs部門ＣＤ, i雛型ＮＯ);
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

			texメッセージ.Text = sList[0];

			// メッセージが[正常終了]
			if(sList[0].Length != 4) return;

			String[] sIUList;
// MOD 2005.06.08 東都）伊賀 指定日区分追加 START
// MOD 2005.05.17 東都）小童谷 才数追加 START
//			string[] s出荷Ｄ = new string[38];
//			string[] s出荷Ｄ = new string[39];
// MOD 2011.07.14 東都）高木 記事行の追加 START
//			string[] s出荷Ｄ = new string[42];
			string[] s出荷Ｄ = new string[45];
// MOD 2011.07.14 東都）高木 記事行の追加 END
// MOD 2005.05.17 東都）小童谷 才数追加 END
// MOD 2005.06.08 東都）伊賀 指定日区分追加 END
			s出荷Ｄ[0]    = gs会員ＣＤ;
			s出荷Ｄ[1]    = gs部門ＣＤ;
// MOD 2005.07.08 東都）高木 日付変換の変更 START
//			s出荷Ｄ[2]    = dt出荷日.Value.ToShortDateString().Replace("/","");
			s出荷Ｄ[2]    = YYYYMMDD変換(dt出荷日.Value);
// MOD 2005.07.08 東都）高木 日付変換の変更 END
			s出荷Ｄ[3]    = " ";                    //お客様管理番号
			s出荷Ｄ[4]    = sList[3].Trim();   //届け先コード
			s出荷Ｄ[5]    = sList[4].Trim();   //届け先電話番号１
			s出荷Ｄ[6]    = sList[5].Trim();   //届け先電話番号２
			s出荷Ｄ[7]    = sList[6].Trim();   //届け先電話番号３
			s出荷Ｄ[8]    = sList[7].Trim();   //届け先住所１
			s出荷Ｄ[9]    = sList[8].Trim();   //届け先住所２
			s出荷Ｄ[10]   = sList[9].Trim();   //届け先住所３
			s出荷Ｄ[11]   = sList[10].Trim();   //届け先名前１
			s出荷Ｄ[12]   = sList[11].Trim();   //届け先名前２
			s出荷Ｄ[13]   = sList[12].Trim();   //届け先郵便番号１
			s出荷Ｄ[14]   = sList[13].Trim();   //届け先郵便番号２
			s出荷Ｄ[15]   = sList[14].Trim();   //依頼主コード
			s出荷Ｄ[37]   = sList[15].Trim();    //依頼主部署

			s出荷Ｄ[19]   = sList[16].Trim();   //個数
			s出荷Ｄ[20]   = sList[17].Trim();   //重量

// MOD 2005.06.08 東都）伊賀 指定日区分追加 START
			if(cBox指定日.Checked == true)
			{
// MOD 2005.07.08 東都）高木 日付変換の変更 START
//				s出荷Ｄ[21] = dt指定日.Value.ToShortDateString().Replace("/","");
				s出荷Ｄ[21] = YYYYMMDD変換(dt指定日.Value);
// MOD 2005.07.08 東都）高木 日付変換の変更 END
// MOD 2007.02.20 東都）高木 指定日を必着に固定 START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
				s出荷Ｄ[41] = cmb指定日区分.SelectedIndex.ToString();
//				s出荷Ｄ[41] = "0";
// MOD 2008.11.14 東都）高木 指定日区分の復活 END
// MOD 2007.02.20 東都）高木 指定日を必着に固定 END
			}
			else
			{
				s出荷Ｄ[21] = "0";
				s出荷Ｄ[41] = "0";
			}
// MOD 2005.06.08 東都）伊賀 指定日区分追加 END

// ADD 2005.05.30 東都）伊賀 輸送商品コード追加 START
			s出荷Ｄ[39] = sList[39].Trim();
			s出荷Ｄ[40] = sList[40].Trim();
// ADD 2005.05.30 東都）伊賀 輸送商品コード追加 END

// ADD 2005.06.08 東都）伊賀 指定日区分追加 START
			//８ＥＸＰ、９ＥＸＰ、１０ＥＸＰ、国内航空便の場合は指定日必須
			if((s出荷Ｄ[39].Equals("200") || s出荷Ｄ[39].Equals("300") || s出荷Ｄ[39].Equals("400") || s出荷Ｄ[39].Equals("500"))
				&& cBox指定日.Checked == false)
			{
				MessageBox.Show("配達指定日は必須項目です","入力チェック",
					MessageBoxButtons.OK );
				dt指定日.Focus();
				return;
			}
// ADD 2005.06.08 東都）伊賀 指定日区分追加 END

			s出荷Ｄ[22]   = sList[18].Trim();   //輸送名１
			s出荷Ｄ[23]   = sList[19].Trim();   //輸送名２
			s出荷Ｄ[24]   = sList[20].Trim();   //記事名１
			s出荷Ｄ[25]   = sList[21].Trim();   //記事名２
			s出荷Ｄ[26]   = sList[22].Trim();   //記事名３
			s出荷Ｄ[27]   = "1";		//元着区分
			s出荷Ｄ[28]   = sList[23].Trim();   //保険金額
			s出荷Ｄ[29] = "0";					//送り状発行済ＦＧ
			s出荷Ｄ[30] = "0";					//出荷済ＦＧ
			s出荷Ｄ[31] = "0";					//一括出荷ＦＧ
			s出荷Ｄ[32] = "雛型出荷";
			s出荷Ｄ[33] = gs利用者ＣＤ;
			s出荷Ｄ[34] = " ";
			s出荷Ｄ[35] = " ";
			s出荷Ｄ[36] = " ";

// ADD 2005.05.17 東都）小童谷 才数追加 START
			s出荷Ｄ[38]   = sList[37].Trim();   //才数
// ADD 2005.05.17 東都）小童谷 才数追加 START

			string s請求先ＣＤ        = sList[34].Trim();
			string s請求先部課ＣＤ    = sList[35].Trim();

			s出荷Ｄ[16] = s請求先ＣＤ;
			s出荷Ｄ[17] = s請求先部課ＣＤ;
			s出荷Ｄ[18] = " ";

			if(gsa請求先ＣＤ != null && s請求先ＣＤ.Length > 0)
			{
				if(gsa請求先ＣＤ != null)
				{
					for(int iCnt = 0 ; iCnt < gsa請求先ＣＤ.Length; iCnt++ )
					{
						if(gsa請求先ＣＤ[iCnt] == null || gsa請求先部課ＣＤ[iCnt] == null)
							continue;
						if(gsa請求先ＣＤ[iCnt] == s請求先ＣＤ && gsa請求先部課ＣＤ[iCnt] == s請求先部課ＣＤ)
						{
							s出荷Ｄ[18] = gsa請求先部課名[iCnt];
							break;
						}
					}
				}
			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
///			if(gsオプション[18].Equals("1")){
				s出荷Ｄ[8]  = sList[7].TrimEnd();  // 届け先住所１
				s出荷Ｄ[9]  = sList[8].TrimEnd();  // 届け先住所２
				s出荷Ｄ[10] = sList[9].TrimEnd();  // 届け先住所３
				s出荷Ｄ[11] = sList[10].TrimEnd(); // 届け先名前１
				s出荷Ｄ[12] = sList[11].TrimEnd(); // 届け先名前２
				s出荷Ｄ[37] = sList[15].TrimEnd(); // 依頼主部署

				s出荷Ｄ[22] = sList[18].TrimEnd(); // 輸送名１
				s出荷Ｄ[23] = sList[19].TrimEnd(); // 輸送名２
				s出荷Ｄ[24] = sList[20].TrimEnd(); // 記事名１
				s出荷Ｄ[25] = sList[21].TrimEnd(); // 記事名２
				s出荷Ｄ[26] = sList[22].TrimEnd(); // 記事名３
///			}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
// MOD 2011.07.14 東都）高木 記事行の追加 START
			if(sList.Length > 41){
				s出荷Ｄ[42] = sList[41].TrimEnd(); // 記事名４
				s出荷Ｄ[43] = sList[42].TrimEnd(); // 記事名５
				s出荷Ｄ[44] = sList[43].TrimEnd(); // 記事名６
			}
// MOD 2011.07.14 東都）高木 記事行の追加 END

			for(int iCnt = 0 ; iCnt < s出荷Ｄ.Length; iCnt++ )
			{
				if( s出荷Ｄ[iCnt] == null 
					|| s出荷Ｄ[iCnt].Length == 0 ) s出荷Ｄ[iCnt] = " ";
			}

			// カーソルを砂時計にする
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			sIUList = new string[]{""};
			try
			{
				texメッセージ.Text = "登録中．．．";
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
// ADD 2010.12.14 ACT）垣原 王子運送の対応 START
				if(sv_oji == null) sv_oji = new is2oji.Service1();
				if (gs会員ＣＤ.Substring(0,1) != "J")
				{
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END
					
					sIUList = sv_syukka.Ins_syukka(gsaユーザ,s出荷Ｄ);

// ADD 2010.12.14 ACT）垣原 王子運送の対応 START
				}
				else
				{
					sIUList = sv_oji.Ins_syukka(gsaユーザ,s出荷Ｄ);
				}
// ADD 2010.12.14 ACT）垣原 王子運送の対応 END

			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 START
			catch (System.Net.WebException)
			{
				sIUList[0] = gs通信エラー;
			}
// ADD 2005.05.24 東都）小童谷 通信エラーのメッセージ修正 END
			catch (Exception ex)
			{
				sIUList[0] = "通信エラー：" + ex.Message;
			}
			// カーソルをデフォルトに戻す
			Cursor = System.Windows.Forms.Cursors.Default;

			// 異常終了時
			if(sIUList[0] == "0")
			{
				texメッセージ.Text = "入力されたご依頼主コードはマスタに存在しません";
//				MessageBox.Show("ご依頼主コードが存在しません",
//					"登録",MessageBoxButtons.OK);
				return;
			}

			texメッセージ.Text = sIUList[0];
			if(sIUList[0].Length == 4)
			{
				i印刷ＦＧ = 1;
				s登録日 = sIUList[1];
				sジャーナルＮＯ = sIUList[2];
			}
		}

		private bool 送り状印刷()
		{
			i印刷ＦＧ = 0;

			try
			{
				プリンタチェック();
			}
			catch(Exception ex)
			{
				texメッセージ.Text = ex.Message;
				return true;
			}
			Cursor = System.Windows.Forms.Cursors.AppStarting;

// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） START
//			ds送り状.Clear();
			送り状データクリア();
// MOD 2010.07.26 東都）高木 印刷順の指定（仮対応２） END

			try
			{
				string[] sData = new string[2];
				sData[0] = s登録日;
				sData[1] = sジャーナルＮＯ;

				送り状印刷指示(sData);
// ADD 2006.12.12 東都）小童谷 店所と部門店所が異なる場合は、印刷しない START
				if(!gb印刷)
				{
					texメッセージ.Text = "";
					Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2007.2.19 FJCS）桑田 メッセージ変更 START
//					MessageBox.Show("発店が違います。印刷できません。","送状印刷"
					MessageBox.Show("集荷店が違います。印刷できません。","送状印刷"
// MOD 2007.2.19 FJCS）桑田 メッセージ変更 END
						,MessageBoxButtons.OK);
					return false;
				}
// ADD 2006.12.12 東都）小童谷 店所と部門店所が異なる場合は、印刷しない END
			}
			catch (Exception ex)
			{
				texメッセージ.Text = ex.Message;
				ビープ音();
				return true;
			}

			送り状帳票印刷();
			Cursor = System.Windows.Forms.Cursors.Default;

			i印刷ＦＧ = 1;
			texメッセージ.Text = "";
			return true;
		}

		private void listView雛型_DoubleClick(object sender, System.EventArgs e)
		{
			btn出荷登録_Click(sender, e);
		}

		private void cBox指定日_Click(object sender, System.EventArgs e)
		{
			if(cBox指定日.Checked == true)
			{
				label2.Visible = false;
// MOD 2007.02.20 東都）高木 指定日を必着に固定 START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
				cmb指定日区分.Visible = true;
//				lab必着.Visible = true;
// MOD 2008.11.14 東都）高木 指定日区分の復活 END
// MOD 2007.02.20 東都）高木 指定日を必着に固定 END
				dt指定日.TabStop = true;
// DEL 2007.02.20 東都）高木 指定日を必着に固定 START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
				cmb指定日区分.TabStop = true;
// MOD 2008.11.14 東都）高木 指定日区分の復活 END
// DEL 2007.02.20 東都）高木 指定日を必着に固定 END
			}
			else
			{
				label2.Visible = true;
// MOD 2007.02.20 東都）高木 指定日を必着に固定 START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
				cmb指定日区分.Visible = false;
//				lab必着.Visible = false;
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
// MOD 2007.02.20 東都）高木 指定日を必着に固定 END
				dt指定日.TabStop = false;
// DEL 2007.02.20 東都）高木 指定日を必着に固定 START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
				cmb指定日区分.TabStop = false;
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
// DEL 2007.02.20 東都）高木 指定日を必着に固定 END
			}
		}

		private void dt指定日_DropDown(object sender, System.EventArgs e)
		{
			label2.Visible = false;
			cBox指定日.Checked = true;
// MOD 2007.02.20 東都）高木 指定日を必着に固定 START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
			cmb指定日区分.Visible = true;
//			lab必着.Visible = true;
// MOD 2008.11.14 東都）高木 指定日区分の復活 END
// MOD 2007.02.20 東都）高木 指定日を必着に固定 END
			dt指定日.TabStop = true;
// DEL 2007.02.20 東都）高木 指定日を必着に固定 START
// MOD 2008.11.14 東都）高木 指定日区分の復活 START
			cmb指定日区分.TabStop = true;
// MOD 2008.11.14 東都）高木 指定日区分の復活 END
// DEL 2007.02.20 東都）高木 指定日を必着に固定 END
		}

		private void btnショートカット_Click(object sender, System.EventArgs e)
		{
			// 選択されていない場合には終了
			if(listView雛型.SelectedItems.Count == 0)
			{	
				MessageBox.Show("データが１件も選択されていません。", "確認",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				listView雛型.Focus();
				return;
			}

			String strMsg = "選択されたラベルをデスクトップに貼り付けます。\r\n";
			foreach( ListViewItem oItem in listView雛型.SelectedItems )
			{
				strMsg += "\r\n『" + oItem.Text + "』";
			}
			DialogResult result;
			result = MessageBox.Show(strMsg, "デスクトップに貼付", 
				MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

			if(result == DialogResult.OK)
			{
				try
				{
					int i選択数 = listView雛型.SelectedItems.Count;

					for(int iCnt = 0; iCnt < i選択数; iCnt++)
					{
						string shortcurPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop ), "クイックエントリー_" + listView雛型.SelectedItems[iCnt].SubItems[0].Text + ".lnk" );
						// ショートカットを作成
						ShellLink shortcut = new ShellLink();
						shortcut.Description = "クイックエントリーのショートカット";
						shortcut.TargetPath = Path.Combine(gsアプリフォルダ, "..\\AutoUpGrade.exe");
						shortcut.WorkingDirectory = Path.Combine(gsアプリフォルダ, "..\\");
						shortcut.Arguments = "hinagata_" + int.Parse(listView雛型.SelectedItems[iCnt].SubItems[1].Text);
						shortcut.IconFile = Path.Combine(gsアプリフォルダ, "icon\\" + sアイコン[listView雛型.SelectedItems[iCnt].ImageIndex]);
						shortcut.Save(shortcurPath);
						shortcut.Dispose();
						shortcut = null;
					}
				}
				catch (Exception ex)
				{
					texメッセージ.Text = ex.Message;
				}
			}
//			ライブラリ更新();
			listView雛型.Focus();
		}

// ADD 2005.05.24 東都）小童谷 フォーカス移動 START
		private void 雛型出荷登録_Closed(object sender, System.EventArgs e)
		{
			texメッセージ.Text = "";
			listView雛型.Focus();
		}
// ADD 2005.05.24 東都）小童谷 フォーカス移動 END
// ADD 2009.04.02 東都）高木 稼働日対応 START
		private void dt出荷日_ValueChanged(object sender, System.EventArgs e)
		{
			出荷日チェック();
		}
		private bool 出荷日チェック()
		{
			try
			{
				//指定日の範囲の変更
				//最小値：出荷日、最大値：出荷日＋１４日 or ９０日
// MOD 2009.12.08 東都）高木 指定日の上限障害（上記のグローバル対応の障害）START
//// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 START
////				dt指定日最大値 = dt出荷日.Value.AddDays(14);
//				if(gs部門店所ＣＤ.Equals("047")){
//					dt指定日最大値 = gdt出荷日.AddDays(90);
//				}else{
//					dt指定日最大値 = gdt出荷日.AddDays(14);
//				}
//// MOD 2009.12.02 東都）高木 グローバルの場合、配達指定日上限を＋９０日 END
				if(gs部門店所ＣＤ.Equals("047")){
					dt指定日最大値 = dt出荷日.Value.AddDays(90);
				}else{
					dt指定日最大値 = dt出荷日.Value.AddDays(14);
				}
// MOD 2009.12.08 東都）高木 指定日の上限障害（上記のグローバル対応の障害）END
// MOD 2016.04.13 BEVAS）松本 配達指定日上限の拡張 START
				//セリア様の場合、配達指定日の上限を180日にまで拡張
				if(gs会員ＣＤ.Equals(gs指定日上限拡張会員ＣＤ))
				{
					dt指定日最大値 = dt出荷日.Value.AddDays(180);
				}
// MOD 2016.04.13 BEVAS）松本 配達指定日上限の拡張 END
				dt指定日最小値 = dt出荷日.Value;

				//[指定日]のチェックが入っていない時
				if(cBox指定日.Checked == false){
					dt指定日.MaxDate = YYYYMMDD変換("2105/12/31");
					dt指定日.MinDate = YYYYMMDD変換("2005/01/01");
					dt指定日.Value   = dt出荷日.Value.AddDays(1);
					dt指定日.MaxDate = dt指定日最大値;
					dt指定日.MinDate = dt指定日最小値;
					return true;
				}

				//以下は[指定日]のチェックが入っている時

				if(dt指定日.Value < dt指定日最小値){
					dt指定日.MaxDate = dt指定日最大値;
					dt指定日.MinDate = dt指定日.Value;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
					if(b指定日チェックＭＳＧ有){
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
						//エラーメッセージ表示後、フォーカス移動
						MessageBox.Show("配達指定日は出荷日以降を入力してください\n"
										+ "（" 
										+ dt指定日最小値.Month + "月"
										+ dt指定日最小値.Day   + "日 ～ "
										+ dt指定日最大値.Month + "月"
										+ dt指定日最大値.Day   + "日）"
										,"入力チェック"
										,MessageBoxButtons.OK);
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
					}
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
					dt指定日.Refresh();
					dt指定日.Focus();
					return false;
				}else if(dt指定日.Value > dt指定日最大値){
					dt指定日.MaxDate = dt指定日.Value;
					dt指定日.MinDate = dt指定日最小値;
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
					if(b指定日チェックＭＳＧ有){
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
						//エラーメッセージ表示後、フォーカス移動
						MessageBox.Show("配達指定日を変更してください\n"
										+ "（" 
										+ dt指定日最小値.Month + "月"
										+ dt指定日最小値.Day   + "日 ～ "
										+ dt指定日最大値.Month + "月"
										+ dt指定日最大値.Day   + "日）"
										,"入力チェック"
										,MessageBoxButtons.OK);
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 START
					}
// MOD 2010.03.26 東都）高木 指定日固定チェック時の障害対応 END
					dt指定日.Refresh();
					dt指定日.Focus();
					return false;
				}else{
					dt指定日.MaxDate = dt指定日最大値;
					dt指定日.MinDate = dt指定日最小値;
				}
			}
			catch (Exception)
			{
				;
				return false;
			}
			return true;
		}
// ADD 2009.04.02 東都）高木 稼働日対応 END

	}
}
