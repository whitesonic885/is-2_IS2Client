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
	public class 共通テキストボックス２ : 共通テキストボックス
	{

		public 共通テキストボックス２()
		{
		}

		protected override bool IsInputKey(System.Windows.Forms.Keys keyData)
		{
			if(keyData == Keys.Tab)
				return true;

			return false;
		}
	}
}
