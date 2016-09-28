using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IS2Client
{
	/// <summary>
	/// 共通テキストボックス の概要の説明です。
	/// </summary>
	public class 共通テキストボックス : System.Windows.Forms.TextBox
	{
// ADD 2005.06.27 東都）小童谷 ９８対応 START
		private static System.PlatformID oEnv = Environment.OSVersion.Platform;
		private int iテキストＦＧ = 0;
// ADD 2005.06.27 東都）小童谷 ９８対応 END

		public 共通テキストボックス()
		{
			this.Enter += new System.EventHandler(this.共通テキストボックス_Enter);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.共通テキストボックス_MouseDown);
		}

		private void 共通テキストボックス_Enter(object sender, System.EventArgs e)
		{
// ADD 2005.06.27 東都）小童谷 ９８対応 START
			if(iテキストＦＧ == 0 && this.ImeMode == ImeMode.Hiragana && oEnv != System.PlatformID.Win32NT)
			{
				this.MaxLength = this.MaxLength * 2;
				iテキストＦＧ = 1;
			}
// ADD 2005.06.27 東都）小童谷 ９８対応 END

			if(this.Text.Length == 0 && this.PasswordChar == '\0') this.Text = " ";
			this.SelectionStart = 0;
			this.SelectionLength = this.Text.Length;
		}

		private void 共通テキストボックス_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
// ADD 2005.06.27 東都）小童谷 ９８対応 START
			if(iテキストＦＧ == 0 && this.ImeMode == ImeMode.Hiragana && oEnv != System.PlatformID.Win32NT)
			{
				this.MaxLength = this.MaxLength * 2;
				iテキストＦＧ = 1;
			}
// ADD 2005.06.27 東都）小童谷 ９８対応 END

			if(this.Text.Trim().Length == 0)
			{
				this.SelectionStart = 0;
				this.SelectionLength = this.Text.Length;
			}
		}
	}
}
