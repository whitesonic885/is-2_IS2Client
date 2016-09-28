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
	public class ���ʃe�L�X�g�{�b�N�X : System.Windows.Forms.TextBox
	{
// ADD 2005.06.27 ���s�j�����J �X�W�Ή� START
		private static System.PlatformID oEnv = Environment.OSVersion.Platform;
		private int i�e�L�X�g�e�f = 0;
// ADD 2005.06.27 ���s�j�����J �X�W�Ή� END

		public ���ʃe�L�X�g�{�b�N�X()
		{
			this.Enter += new System.EventHandler(this.���ʃe�L�X�g�{�b�N�X_Enter);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.���ʃe�L�X�g�{�b�N�X_MouseDown);
		}

		private void ���ʃe�L�X�g�{�b�N�X_Enter(object sender, System.EventArgs e)
		{
// ADD 2005.06.27 ���s�j�����J �X�W�Ή� START
			if(i�e�L�X�g�e�f == 0 && this.ImeMode == ImeMode.Hiragana && oEnv != System.PlatformID.Win32NT)
			{
				this.MaxLength = this.MaxLength * 2;
				i�e�L�X�g�e�f = 1;
			}
// ADD 2005.06.27 ���s�j�����J �X�W�Ή� END

			if(this.Text.Length == 0 && this.PasswordChar == '\0') this.Text = " ";
			this.SelectionStart = 0;
			this.SelectionLength = this.Text.Length;
		}

		private void ���ʃe�L�X�g�{�b�N�X_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
// ADD 2005.06.27 ���s�j�����J �X�W�Ή� START
			if(i�e�L�X�g�e�f == 0 && this.ImeMode == ImeMode.Hiragana && oEnv != System.PlatformID.Win32NT)
			{
				this.MaxLength = this.MaxLength * 2;
				i�e�L�X�g�e�f = 1;
			}
// ADD 2005.06.27 ���s�j�����J �X�W�Ή� END

			if(this.Text.Trim().Length == 0)
			{
				this.SelectionStart = 0;
				this.SelectionLength = this.Text.Length;
			}
		}
	}
}
