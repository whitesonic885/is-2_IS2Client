using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IS2Client
{
	/// <summary>
	/// ���ʃe�L�X�g�{�b�N�X �̊T�v�̐����ł��B
	/// </summary>
	public class ���ʃe�L�X�g�{�b�N�X�Q : ���ʃe�L�X�g�{�b�N�X
	{

		public ���ʃe�L�X�g�{�b�N�X�Q()
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
