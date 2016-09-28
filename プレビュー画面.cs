using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IS2Client
{
	/// <summary>
	/// Form1 の概要の説明です。
	/// </summary>
	public class プレビュー画面 : System.Windows.Forms.Form
	{
		public CrystalDecisions.Windows.Forms.CrystalReportViewer crv帳票;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public プレビュー画面()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
			//
		}

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.crv帳票 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crv帳票
			// 
			this.crv帳票.ActiveViewIndex = -1;
			this.crv帳票.DisplayGroupTree = false;
			this.crv帳票.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crv帳票.Location = new System.Drawing.Point(0, 0);
			this.crv帳票.Name = "crv帳票";
			this.crv帳票.ReportSource = null;
			this.crv帳票.Size = new System.Drawing.Size(792, 573);
			this.crv帳票.TabIndex = 0;
			// 
			// プレビュー画面
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(792, 574);
			this.Controls.Add(this.crv帳票);
			this.Name = "プレビュー画面";
			this.Text = "帳票画面";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
