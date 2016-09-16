using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace IS2Client
{
	/// <summary>
	/// [お知らせ表題ボタン]
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// MOD 2010.06.01 東都）高木 メニューのレイアウト表示時の障害対応 
	// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 
	//--------------------------------------------------------------------------
	public class お知らせ表題ボタン : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.PictureBox pic表題;
		private System.Windows.Forms.Label lab日付;
		private System.Windows.Forms.Label lab表題;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 表題を表示する既定のフォントサイズです。
		/// </summary>
		private readonly float _OriginalFontSize;
		/// <summary>
		/// 背景に使用するイメージのリストです。
		/// </summary>
		private Image [] _ImageList;
		/// <summary>
		/// 選択時の文字色です。
		/// </summary>
		private readonly Color _SelectedColor = Color.FromArgb(102, 102, 255);
		/// <summary>
		/// 未選択時の文字色です。
		/// </summary>
		private readonly Color _UnSelectedColor = Color.SeaGreen;
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
		/// <summary>
		/// 選択時の文字色２です。
		/// </summary>
		private readonly Color _SelectedColor2 = Color.DarkOrange;
		/// <summary>
		/// 未選択時の文字色２です。
		/// </summary>
		private readonly Color _UnSelectedColor2 = Color.FromArgb(224, 163, 0);

		/// <summary>
		/// 選択時の文字色３です。
		/// </summary>
//		private readonly Color _SelectedColor3 = Color.FromArgb(254, 123, 85);
		private readonly Color _SelectedColor3 = Color.FromArgb(254,  80, 60);
		/// <summary>
		/// 未選択時の文字色３です。
		/// </summary>
//		private readonly Color _UnSelectedColor3 = Color.Pink;
//		private readonly Color _UnSelectedColor3 = Color.FromArgb(254, 170, 145);
//		private readonly Color _UnSelectedColor3 = Color.FromArgb(254, 153, 130);
//		private readonly Color _UnSelectedColor3 = Color.FromArgb(254, 150, 125);
		private readonly Color _UnSelectedColor3 = Color.FromArgb(254, 123, 85);

		/// <summary>
		/// ボタンの文字色モードです。
		/// </summary>
		private int _Mode = 0;
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END
		#region イベント
		/// <summary>
		/// このユーザーコントロールをクリックした時に発生するイベントです。
		/// </summary>
		public event EventHandler ButtonClicked;

		/// <summary>
		/// このユーザーコントロールのクリックイベント発動です。
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnButtonClicked(EventArgs e) 
		{
			if (ButtonClicked != null) 
				ButtonClicked(this, e);
		}
		#endregion

		#region プロパティ
		/// <summary>
		/// 表示する日付を設定します。
		/// </summary>
		public string 日付 
		{
			set { lab日付.Text = (value == null) ? string.Empty : value; }
		}
		/// <summary>
		/// 表示する表題を設定します。
		/// </summary>
		public string 表題 
		{
			set 
			{ 
				if (value == null) 
				{
					lab表題.Text = string.Empty;
				} 
				else 
				{
					this.SetStringToLabel(value, lab表題);
				}
			}
		}
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
		/// <summary>
		/// 文字色モードを設定します。
		/// </summary>
		public int モード 
		{
			set
			{
				_Mode = value;
				switch(_Mode){
				case 1:
					pic表題.Image     = _ImageList[2];
					lab日付.ForeColor = _UnSelectedColor2;
					lab表題.ForeColor = _UnSelectedColor2;
					break;
				case 2:
					pic表題.Image     = _ImageList[4];
					lab日付.ForeColor = _UnSelectedColor3;
					lab表題.ForeColor = _UnSelectedColor3;
					break;
				default:
					pic表題.Image     = _ImageList[0];
					lab日付.ForeColor = _UnSelectedColor;
					lab表題.ForeColor = _UnSelectedColor;
					break;
				}
			}
		}
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END
		#endregion

		/// <summary>
		/// コンストラクタです。
		/// </summary>
		public お知らせ表題ボタン()
		{
			// この呼び出しは、Windows.Forms フォーム デザイナで必要です。
			InitializeComponent();

			// イメージリストの初期化
			this.InitImageList();

			// 背景の設定
			pic表題.Image = _ImageList[0];

			// フォントサイズの規定値を取得
			_OriginalFontSize = lab表題.Font.Size;
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
			// フォントカラーの設定
			lab日付.ForeColor = _UnSelectedColor;
			lab表題.ForeColor = _UnSelectedColor;
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END
		}

		#region イメージリストの初期化
		/// <summary>
		/// イメージリストを初期化します。
		/// </summary>
		private void InitImageList()
		{
			if (_ImageList != null) return;

// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
//			_ImageList = new Image[2];
			_ImageList = new Image[6];
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END
// MOD 2010.06.01 東都）高木 メニューのレイアウト表示時の障害対応 START
			try{
// MOD 2010.06.01 東都）高木 メニューのレイアウト表示時の障害対応 END
				_ImageList[0] = Image.FromFile("img\\m601a.gif");
				_ImageList[1] = Image.FromFile("img\\m601b.gif");
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
				_ImageList[2] = Image.FromFile("img\\m602a.gif");
				_ImageList[3] = Image.FromFile("img\\m602b.gif");
				_ImageList[4] = Image.FromFile("img\\m603a.gif");
				_ImageList[5] = Image.FromFile("img\\m603b.gif");
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END
// MOD 2010.06.01 東都）高木 メニューのレイアウト表示時の障害対応 START
			}catch(Exception){
				_ImageList[0] = Image.FromFile(@"bin\Debug\img\m601a.gif");
				_ImageList[1] = Image.FromFile(@"bin\Debug\img\m601b.gif");
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
				_ImageList[2] = Image.FromFile(@"bin\Debug\img\m602a.gif");
				_ImageList[3] = Image.FromFile(@"bin\Debug\img\m602b.gif");
				_ImageList[4] = Image.FromFile(@"bin\Debug\img\m603a.gif");
				_ImageList[5] = Image.FromFile(@"bin\Debug\img\m603b.gif");
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END
			}
// MOD 2010.06.01 東都）高木 メニューのレイアウト表示時の障害対応 END
		}
		#endregion

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

		#region コンポーネント デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.pic表題 = new System.Windows.Forms.PictureBox();
			this.lab日付 = new System.Windows.Forms.Label();
			this.lab表題 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// pic表題
			// 
			this.pic表題.Location = new System.Drawing.Point(0, 0);
			this.pic表題.Name = "pic表題";
			this.pic表題.Size = new System.Drawing.Size(482, 42);
			this.pic表題.TabIndex = 0;
			this.pic表題.TabStop = false;
			this.pic表題.Click += new System.EventHandler(this.お知らせ表題_Click);
			this.pic表題.MouseEnter += new System.EventHandler(this.お知らせ表題_MouseEnter);
			this.pic表題.MouseLeave += new System.EventHandler(this.お知らせ表題_MouseLeave);
			// 
			// lab日付
			// 
			this.lab日付.BackColor = System.Drawing.Color.Transparent;
			this.lab日付.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab日付.ForeColor = System.Drawing.Color.SeaGreen;
			this.lab日付.Location = new System.Drawing.Point(44, 20);
			this.lab日付.Name = "lab日付";
			this.lab日付.Size = new System.Drawing.Size(94, 16);
			this.lab日付.TabIndex = 1;
			this.lab日付.Text = "9999/99/99";
			this.lab日付.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.lab日付.Click += new System.EventHandler(this.お知らせ表題_Click);
			this.lab日付.MouseEnter += new System.EventHandler(this.お知らせ表題_MouseEnter);
			this.lab日付.MouseLeave += new System.EventHandler(this.お知らせ表題_MouseLeave);
			// 
			// lab表題
			// 
			this.lab表題.BackColor = System.Drawing.Color.Transparent;
			this.lab表題.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lab表題.ForeColor = System.Drawing.Color.SeaGreen;
			this.lab表題.Location = new System.Drawing.Point(136, 12);
			this.lab表題.Name = "lab表題";
			this.lab表題.Size = new System.Drawing.Size(344, 22);
			this.lab表題.TabIndex = 2;
			this.lab表題.Text = "国国国国国王王王王王国国国国国王王王王王";
			this.lab表題.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.lab表題.Click += new System.EventHandler(this.お知らせ表題_Click);
			this.lab表題.MouseEnter += new System.EventHandler(this.お知らせ表題_MouseEnter);
			this.lab表題.MouseLeave += new System.EventHandler(this.お知らせ表題_MouseLeave);
			// 
			// お知らせ表題ボタン
			// 
			this.Controls.Add(this.lab表題);
			this.Controls.Add(this.lab日付);
			this.Controls.Add(this.pic表題);
			this.Name = "お知らせ表題ボタン";
			this.Size = new System.Drawing.Size(482, 42);
			this.ResumeLayout(false);

		}
		#endregion

		private void お知らせ表題_MouseEnter(object sender, System.EventArgs e)
		{
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
//			pic表題.Image     = _ImageList[1];
//			lab日付.ForeColor = _SelectedColor;
//			lab表題.ForeColor = _SelectedColor;
			switch(_Mode){
			case 1:
				pic表題.Image     = _ImageList[3];
				lab日付.ForeColor = _SelectedColor2;
				lab表題.ForeColor = _SelectedColor2;
				break;
			case 2:
				pic表題.Image     = _ImageList[5];
				lab日付.ForeColor = _SelectedColor3;
				lab表題.ForeColor = _SelectedColor3;
				break;
			default:
				pic表題.Image     = _ImageList[1];
				lab日付.ForeColor = _SelectedColor;
				lab表題.ForeColor = _SelectedColor;
				break;
			}
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END
		}

		private void お知らせ表題_MouseLeave(object sender, System.EventArgs e)
		{
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 START
//			pic表題.Image     = _ImageList[0];
//			lab日付.ForeColor = _UnSelectedColor;
//			lab表題.ForeColor = _UnSelectedColor;
			switch(_Mode){
			case 1:
				pic表題.Image     = _ImageList[2];
				lab日付.ForeColor = _UnSelectedColor2;
				lab表題.ForeColor = _UnSelectedColor2;
				break;
			case 2:
				pic表題.Image     = _ImageList[4];
				lab日付.ForeColor = _UnSelectedColor3;
				lab表題.ForeColor = _UnSelectedColor3;
				break;
			default:
				pic表題.Image     = _ImageList[0];
				lab日付.ForeColor = _UnSelectedColor;
				lab表題.ForeColor = _UnSelectedColor;
				break;
			}
// MOD 2010.07.01 東都）高木 営業所用お知らせ登録機能の追加 END
		}

		private void お知らせ表題_Click(object sender, System.EventArgs e)
		{
			this.OnButtonClicked(EventArgs.Empty);
		}

		#region ラベルへの文字列設定
		/// <summary>
		/// ラベルに文字列を設定します。
		/// 文字列が長すぎて表示できない時は、自動的にフォントを小さくして表示します。
		/// </summary>
		/// <param name="str">表示する文字列</param>
		/// <param name="label">文字列を表示するラベル</param>
		private void SetStringToLabel(string str, Label label) 
		{
			// フォントサイズをデフォルトに戻す
			label.Font = new Font(label.Font.FontFamily, _OriginalFontSize, label.Font.Style);

			// 文字列幅の取得
			Font fnt = label.Font;
			// １文字の最大サイズ（だいたいこのくらいあればいい？）
			int charSize = Convert.ToInt32(fnt.Size * 2);
			// ラベルに表示した時の１行の最大幅
			int width    = this.GetStringWidth(str, fnt, label.Width, label.Height);
			// 文字列全体の幅
			int maxWidth = this.GetStringWidth(str, fnt, charSize * str.Length, charSize);

			if (width < maxWidth) 
			{
				// はいりきらない場合　－　フォントサイズを小さくする

				// 最初の一回は、倍率によりフォントサイズを計算
				float ritsu = (float) width / (float) maxWidth;
				// できるだけ大きいサイズで表示する為、計算結果より１大きいサイズからスタートする
				float fntSize = fnt.Size * ritsu + 1;
				fnt = new Font(fnt.FontFamily, fntSize, fnt.Style);
				charSize = Convert.ToInt32(fntSize * 2);
				width    = this.GetStringWidth(str, fnt, label.Width, label.Height);
				maxWidth = this.GetStringWidth(str, fnt, charSize * str.Length, charSize);

				while (width < maxWidth) 
				{
					// 二回目以降は、0.1 刻みで小さくしていく（微調整）
					fntSize = fnt.Size - (float) 0.1;
					fnt = new Font(fnt.FontFamily, fntSize, fnt.Style);
					charSize = Convert.ToInt32(fntSize * 2);
					width    = this.GetStringWidth(str, fnt, label.Width, label.Height);
					maxWidth = this.GetStringWidth(str, fnt, charSize * str.Length, charSize);
				}

				// フォント設定＆文字列表示
				label.Font = fnt;
				label.Text = str;
			} 
			else 
			{
				// はいる場合　－　そのまま表示

				// ラベルに表示
				label.Text = str;
			}
		}
		#endregion

		#region 文字列幅の取得
		/// <summary>
		/// 文字列の幅を取得します。
		/// </summary>
		/// <param name="str">幅を取得する文字列</param>
		/// <param name="fnt">文字列のフォント</param>
		/// <param name="layoutWidth">文字列を表示する領域の幅</param>
		/// <param name="layoutHeight">文字列を表示する領域の高さ</param>
		/// <returns>文字列の幅</returns>
		private int GetStringWidth(string str, Font fnt, int layoutWidth, int layoutHeight) 
		{
			int width = 0;

			// PictureBox の Graphics オブジェクトを取得
			PictureBox pbox = new PictureBox();
			Graphics g = pbox.CreateGraphics();

			// 文字列を描画
			StringFormat sf = new StringFormat();
			//g.DrawString(str, fnt, Brushes.Black, 0, 0, sf);
			CharacterRange [] charRanges = { new CharacterRange(0, str.Length) };
			sf.SetMeasurableCharacterRanges(charRanges);

			// 文字列のレイアウト四角形を指定
			RectangleF layoutRect = new RectangleF(0, 0, layoutWidth, layoutHeight);

			// 文字列に外接する Region 配列を取得
			Region [] strRegions = g.MeasureCharacterRanges(str, fnt, layoutRect, sf);

			// 取得した文字列の大きさを使って文字列幅を取得
			RectangleF rect = strRegions[0].GetBounds(g);
			width = Rectangle.Round(rect).Width;

			// リソースを開放
			g.Dispose();

			return width;
		}
		#endregion
	}
}
