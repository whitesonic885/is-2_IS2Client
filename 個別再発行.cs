using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IS2Client
{
	public class 個別再発行 : IS2Client.共通フォーム
	{
		public int i開始 = 0;
		public int i終了 = 0;

		private System.Windows.Forms.Label labから;
		private System.Windows.Forms.Label lab枚目;
		private System.Windows.Forms.Label labメッセージ;
		private System.Windows.Forms.Button btn再発行;
		private System.Windows.Forms.Button btn閉じる;
		private IS2Client.共通テキストボックス txt個数開始;
		private IS2Client.共通テキストボックス txt個数終了;
		private System.Windows.Forms.Label lab注釈;
		private System.ComponentModel.IContainer components = null;

		public 個別再発行()
		{
			// この呼び出しは Windows フォーム デザイナで必要です。
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

		#region デザイナで生成されたコード
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.labから = new System.Windows.Forms.Label();
			this.lab枚目 = new System.Windows.Forms.Label();
			this.labメッセージ = new System.Windows.Forms.Label();
			this.btn再発行 = new System.Windows.Forms.Button();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.txt個数開始 = new IS2Client.共通テキストボックス();
			this.txt個数終了 = new IS2Client.共通テキストボックス();
			this.lab注釈 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labから
			// 
			this.labから.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labから.Location = new System.Drawing.Point(94, 38);
			this.labから.Name = "labから";
			this.labから.Size = new System.Drawing.Size(20, 23);
			this.labから.TabIndex = 2;
			this.labから.Text = "～";
			this.labから.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lab枚目
			// 
			this.lab枚目.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab枚目.Location = new System.Drawing.Point(148, 38);
			this.lab枚目.Name = "lab枚目";
			this.lab枚目.Size = new System.Drawing.Size(44, 23);
			this.lab枚目.TabIndex = 4;
			this.lab枚目.Text = "枚目";
			this.lab枚目.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labメッセージ
			// 
			this.labメッセージ.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labメッセージ.Location = new System.Drawing.Point(10, 10);
			this.labメッセージ.Name = "labメッセージ";
			this.labメッセージ.Size = new System.Drawing.Size(194, 20);
			this.labメッセージ.TabIndex = 5;
			this.labメッセージ.Text = "印刷範囲を設定してください";
			this.labメッセージ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn再発行
			// 
			this.btn再発行.BackColor = System.Drawing.Color.PaleGreen;
			this.btn再発行.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn再発行.ForeColor = System.Drawing.Color.Blue;
			this.btn再発行.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn再発行.Location = new System.Drawing.Point(130, 92);
			this.btn再発行.Name = "btn再発行";
			this.btn再発行.Size = new System.Drawing.Size(68, 34);
			this.btn再発行.TabIndex = 6;
			this.btn再発行.Text = "印刷";
			this.btn再発行.Click += new System.EventHandler(this.btn再発行_Click);
			// 
			// btn閉じる
			// 
			this.btn閉じる.BackColor = System.Drawing.Color.PaleGreen;
			this.btn閉じる.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn閉じる.ForeColor = System.Drawing.Color.Red;
			this.btn閉じる.Location = new System.Drawing.Point(26, 92);
			this.btn閉じる.Name = "btn閉じる";
			this.btn閉じる.Size = new System.Drawing.Size(68, 34);
			this.btn閉じる.TabIndex = 7;
			this.btn閉じる.TabStop = false;
			this.btn閉じる.Text = "閉じる";
			this.btn閉じる.Click += new System.EventHandler(this.btn閉じる_Click);
			// 
			// txt個数開始
			// 
			this.txt個数開始.Font = new System.Drawing.Font("MS UI Gothic", 15.75F);
			this.txt個数開始.Location = new System.Drawing.Point(60, 34);
			this.txt個数開始.MaxLength = 2;
			this.txt個数開始.Name = "txt個数開始";
			this.txt個数開始.Size = new System.Drawing.Size(30, 28);
			this.txt個数開始.TabIndex = 8;
			this.txt個数開始.Text = "1";
			this.txt個数開始.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt個数終了
			// 
			this.txt個数終了.Font = new System.Drawing.Font("MS UI Gothic", 15.75F);
			this.txt個数終了.Location = new System.Drawing.Point(116, 34);
			this.txt個数終了.MaxLength = 2;
			this.txt個数終了.Name = "txt個数終了";
			this.txt個数終了.Size = new System.Drawing.Size(30, 28);
			this.txt個数終了.TabIndex = 9;
			this.txt個数終了.Text = "99";
			this.txt個数終了.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lab注釈
			// 
			this.lab注釈.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab注釈.Location = new System.Drawing.Point(114, 64);
			this.lab注釈.Name = "lab注釈";
			this.lab注釈.Size = new System.Drawing.Size(120, 20);
			this.lab注釈.TabIndex = 10;
			this.lab注釈.Text = "(※[99]は最終頁)";
			this.lab注釈.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// 個別再発行
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(234, 138);
			this.Controls.Add(this.lab注釈);
			this.Controls.Add(this.txt個数終了);
			this.Controls.Add(this.txt個数開始);
			this.Controls.Add(this.labメッセージ);
			this.Controls.Add(this.lab枚目);
			this.Controls.Add(this.labから);
			this.Controls.Add(this.btn再発行);
			this.Controls.Add(this.btn閉じる);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(240, 170);
			this.Name = "個別再発行";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 個別再発行";
			this.ResumeLayout(false);

		}
		#endregion

		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
			//なにもしない場合は、変数を０にする
			this.i開始 = 0;
			this.i終了 = 0;
			this.Close();
		}

		private void btn再発行_Click(object sender, System.EventArgs e)
		{
			//必須チェック
			if(txt個数開始.Text.Length == 0 && txt個数終了.Text.Length == 0){
				if(!必須チェック(txt個数開始,"開始頁")) return;
				return;
			}

			this.i開始 = 0;
			this.i終了 = 0;
			//数値チェック
			if(txt個数開始.Text.Length > 0){
				if(!半角チェック(txt個数開始,"開始頁")) return;
				if(!数値チェック(txt個数開始,"開始頁")) return;
				this.i開始 = int.Parse(txt個数開始.Text);
				if(this.i開始 < 0 || this.i開始 > 99){
					MessageBox.Show("開始頁は1～99の間で入力してください"
						, "入力チェック", MessageBoxButtons.OK);
					txt個数開始.Focus();
					return;
				}
			}
			if(txt個数終了.Text.Length > 0){
				if(!半角チェック(txt個数終了,"終了頁")) return;
				if(!数値チェック(txt個数終了,"終了頁")) return;
				this.i終了 = int.Parse(txt個数終了.Text);
				if(this.i終了 < 0 || this.i終了 > 99){
					MessageBox.Show("終了頁は1～99の間で入力してください"
						, "入力チェック", MessageBoxButtons.OK);
					txt個数終了.Focus();
					return;
				}
				//大小関係チェック
				if(this.i開始 > this.i終了){
					MessageBox.Show("頁の範囲が正しく入力されていません"
						, "入力チェック", MessageBoxButtons.OK);
					txt個数終了.Focus();
					return;
				}
			}

			//片方が省略されている場合
			if(this.i開始 == 0) this.i開始 = this.i終了;
			if(this.i終了 == 0) this.i終了 = this.i開始;
			this.Close();
		}
	}
}

