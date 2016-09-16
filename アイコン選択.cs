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
	/// Form1 の概要の説明です。
	/// </summary>
	public class アイコン選択 : 共通フォーム
	{
		public int iアイコン = 0;
		private System.Windows.Forms.ListView listViewアイコン;
		private System.Windows.Forms.Button btn選択;
		private System.Windows.Forms.Button btn閉じる;
		private System.ComponentModel.IContainer components = null;

		public アイコン選択()
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
			this.listViewアイコン = new System.Windows.Forms.ListView();
			this.btn選択 = new System.Windows.Forms.Button();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listViewアイコン
			// 
			this.listViewアイコン.BackColor = System.Drawing.Color.Honeydew;
			this.listViewアイコン.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.listViewアイコン.LabelEdit = true;
			this.listViewアイコン.Location = new System.Drawing.Point(2, 2);
			this.listViewアイコン.MultiSelect = false;
			this.listViewアイコン.Name = "listViewアイコン";
			this.listViewアイコン.Size = new System.Drawing.Size(492, 304);
			this.listViewアイコン.TabIndex = 0;
			this.listViewアイコン.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewアイコン_KeyDown);
			this.listViewアイコン.DoubleClick += new System.EventHandler(this.listViewアイコン_DoubleClick);
			// 
			// btn選択
			// 
			this.btn選択.BackColor = System.Drawing.Color.SteelBlue;
			this.btn選択.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn選択.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn選択.ForeColor = System.Drawing.Color.White;
			this.btn選択.Location = new System.Drawing.Point(356, 310);
			this.btn選択.Name = "btn選択";
			this.btn選択.Size = new System.Drawing.Size(64, 22);
			this.btn選択.TabIndex = 2;
			this.btn選択.TabStop = false;
			this.btn選択.Text = "選択";
			this.btn選択.Click += new System.EventHandler(this.btn選択_Click);
			// 
			// btn閉じる
			// 
			this.btn閉じる.BackColor = System.Drawing.Color.SteelBlue;
			this.btn閉じる.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn閉じる.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn閉じる.ForeColor = System.Drawing.Color.White;
			this.btn閉じる.Location = new System.Drawing.Point(426, 310);
			this.btn閉じる.Name = "btn閉じる";
			this.btn閉じる.Size = new System.Drawing.Size(64, 22);
			this.btn閉じる.TabIndex = 3;
			this.btn閉じる.TabStop = false;
			this.btn閉じる.Text = "閉じる";
			this.btn閉じる.Click += new System.EventHandler(this.btn閉じる_Click);
			// 
			// アイコン選択
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(496, 341);
			this.Controls.Add(this.btn閉じる);
			this.Controls.Add(this.btn選択);
			this.Controls.Add(this.listViewアイコン);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(502, 366);
			this.Name = "アイコン選択";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 アイコン選択";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
			this.Load += new System.EventHandler(this.アイコン選択_Load);
			this.Closed += new System.EventHandler(this.アイコン選択_Closed);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		private void アイコン選択_Load(object sender, System.EventArgs e)
		{
			// イメージの設定
			アイコンイメージの初期化();
			listViewアイコン.LargeImageList = imageList64;
			listViewアイコン.SmallImageList = imageList16;

			ListViewItem item;
			for(int iCnt = 0; iCnt < sアイコン.Length; iCnt++)
			{
				item = new ListViewItem();
// MOD 2005.05.25 東都）高木 アイコン選択画面の表示時、[.ico]非表示 START
//				item.Text = sアイコン[iCnt];
				item.Text = sアイコン一覧[iCnt];
// MOD 2005.05.25 東都）高木 アイコン選択画面の表示時、[.ico]非表示 END
				item.ImageIndex = iCnt;
				listViewアイコン.Items.Add(item);
			}

			listViewアイコン.Focus();

// MOD 2005.05.09 東都）高木 アイコン一覧表示の変更 START
//			// １つ目の項目を選択状態にする
//			if(listViewアイコン.Items.Count > 0)
//				listViewアイコン.Items[0].Selected = true;
			if(listViewアイコン.Items.Count > 0)
			{
				// アイコンを選択状態にする
				if( iアイコン > 0 )
					listViewアイコン.Items[iアイコン].Selected = true;
				else
					listViewアイコン.Items[0].Selected = true;
			}
// MOD 2005.05.09 東都）高木 アイコン一覧表示の変更 END
		}

		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void listViewアイコン_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyData == Keys.Enter)
			{
				btn選択_Click(sender, e);
			}
		}

		private void listViewアイコン_DoubleClick(object sender, System.EventArgs e)
		{
			btn選択_Click(sender, e);
		}

		private void btn選択_Click(object sender, System.EventArgs e)
		{
			// 選択されていない場合には終了
			if(listViewアイコン.SelectedItems.Count == 0)
			{	
				MessageBox.Show("アイコンが選択されていません。", "確認",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				listViewアイコン.Focus();
				return;
			}
			iアイコン = listViewアイコン.SelectedItems[0].Index;
			this.Close();
		}

// ADD 2005.05.24 東都）小童谷 フォーカス移動 START
		private void アイコン選択_Closed(object sender, System.EventArgs e)
		{
			listViewアイコン.Clear();
			listViewアイコン.Focus();
		}
// ADD 2005.05.24 東都）小童谷 フォーカス移動 END

	}
}
