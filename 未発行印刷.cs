using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IS2Client
{
	/// <summary>
	/// [Äóü]A[`CXvg]
	/// </summary>
	//--------------------------------------------------------------------------
	// C³ð
	//--------------------------------------------------------------------------
	// MOD 2007.02.08 sjØ ê\¦ÚÌÏX 
	// MOD 2007.02.19 FJCSjKc bZ[WÏX 
	// MOD 2007.02.20 sjØ Ä­sæÊÅo×úª¢ÅàóüÂÉ·é 
	// ADD 2007.02.21 sjØ õãÌJÊuÌ²® 
	// MOD 2007.03.10 sjØ ê\¦ÚÌÏXiáQj 
	// MOD 2007.07.06 sjØ wb_ÉOCW×Xð\¦ 
	//--------------------------------------------------------------------------
	// ADD 2008.03.19 sjØ ÂÊÄ­s@\ÌÇÁ 
	// MOD 2008.10.29 sjØ ¿æîñðÇÁ 
	//--------------------------------------------------------------------------
	// MOD 2010.07.26 sjØ óüÌwèi¼ÎQj 
	// MOD 2010.10.01 sjØ ¨qlÔPU» 
	//--------------------------------------------------------------------------
	// MOD 2011.03.23 sjØ J[\Û@\ÌÇÁ 
	//--------------------------------------------------------------------------
	public class ¢­sóü : ¤ÊtH[
	{
		public short OldRow = 0;
		private short nSrow = 0;
		private short nErow = 0;
		private short nWork = 0;

		private string[] so×ê;
//		private int      i»ÝÅ;
		private int      iANeBuef = 0;

		public string s^Cg;
		public string sóÔíÊ;

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label labú;
		private System.Windows.Forms.TextBox texdÊv;
		private System.Windows.Forms.TextBox texÂv;
		private System.Windows.Forms.Label labo^;
		private System.Windows.Forms.TextBox texo^;
		private System.Windows.Forms.Label labÂv;
		private System.Windows.Forms.Label labdÊv;
		private System.Windows.Forms.Label labpå;
		private System.Windows.Forms.Label lab¢­sóü^Cg;
		private System.Windows.Forms.TextBox texbZ[W;
		private System.Windows.Forms.Button btnÂ¶é;
		private System.Windows.Forms.Button btnÄ­s;
		private System.Windows.Forms.TextBox texpå;
		private AxGTABLE32V2Lib.AxGTable32 axGTo×ê;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.TextBox texOCW×X;
		private System.Windows.Forms.Label labOCW×X;
		private System.Windows.Forms.Button btnÂÊÄ­s;
		private System.ComponentModel.IContainer components;

		public ¢­sóü()
		{
			//
			// Windows tH[ fUCi T|[gÉKvÅ·B
			//
			InitializeComponent();

// MOD 2010.03.31 sjØ coh\¦TCYÏ· START
			coh\¦TCYÏ·();
//			if(giDisplayDpiX == 120 && giDisplayDpiY == 120){
				this.axGTo×ê.Size = new System.Drawing.Size(732, 416);
//			}
// MOD 2010.03.31 sjØ coh\¦TCYÏ· END
		}

		/// <summary>
		/// gp³êÄ¢é\[XÉãðÀsµÜ·B
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

		#region Windows tH[ fUCiÅ¶¬³ê½R[h 
		/// <summary>
		/// fUCi T|[gÉKvÈ\bhÅ·B±Ì\bhÌàeð
		/// R[h GfB^ÅÏXµÈ¢Å­¾³¢B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(¢­sóü));
            this.panel2 = new System.Windows.Forms.Panel();
            this.axGTo×ê = new AxGTABLE32V2Lib.AxGTable32();
            this.texdÊv = new System.Windows.Forms.TextBox();
            this.texÂv = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.labo^ = new System.Windows.Forms.Label();
            this.texo^ = new System.Windows.Forms.TextBox();
            this.labÂv = new System.Windows.Forms.Label();
            this.labdÊv = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.labOCW×X = new System.Windows.Forms.Label();
            this.texOCW×X = new System.Windows.Forms.TextBox();
            this.labpå = new System.Windows.Forms.Label();
            this.texpå = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.labú = new System.Windows.Forms.Label();
            this.lab¢­sóü^Cg = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnÂÊÄ­s = new System.Windows.Forms.Button();
            this.btnÄ­s = new System.Windows.Forms.Button();
            this.texbZ[W = new System.Windows.Forms.TextBox();
            this.btnÂ¶é = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dsèó)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGTo×ê)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Honeydew;
            this.panel2.Controls.Add(this.axGTo×ê);
            this.panel2.Controls.Add(this.texdÊv);
            this.panel2.Controls.Add(this.texÂv);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.labo^);
            this.panel2.Controls.Add(this.texo^);
            this.panel2.Controls.Add(this.labÂv);
            this.panel2.Controls.Add(this.labdÊv);
            this.panel2.Location = new System.Drawing.Point(0, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(764, 452);
            this.panel2.TabIndex = 1;
            // 
            // axGTo×ê
            // 
            this.axGTo×ê.DataSource = null;
            this.axGTo×ê.Location = new System.Drawing.Point(28, 32);
            this.axGTo×ê.Name = "axGTo×ê";
            this.axGTo×ê.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGTo×ê.OcxState")));
            this.axGTo×ê.Size = new System.Drawing.Size(732, 416);
            this.axGTo×ê.TabIndex = 51;
            this.axGTo×ê.CurPlaceChanged += new AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEventHandler(this.axGTo×ê_CurPlaceChanged);
            this.axGTo×ê.CelClick += new AxGTABLE32V2Lib._DGTable32Events_CelClickEventHandler(this.axGTo×ê_CelClick);
            this.axGTo×ê.KeyDownEvent += new AxGTABLE32V2Lib._DGTable32Events_KeyDownEventHandler(this.axGTo×ê_KeyDownEvent);
            // 
            // texdÊv
            // 
            this.texdÊv.BackColor = System.Drawing.SystemColors.Window;
            this.texdÊv.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.texdÊv.Location = new System.Drawing.Point(382, 4);
            this.texdÊv.Name = "texdÊv";
            this.texdÊv.ReadOnly = true;
            this.texdÊv.Size = new System.Drawing.Size(86, 23);
            this.texdÊv.TabIndex = 50;
            this.texdÊv.TabStop = false;
            this.texdÊv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // texÂv
            // 
            this.texÂv.BackColor = System.Drawing.SystemColors.Window;
            this.texÂv.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.texÂv.Location = new System.Drawing.Point(246, 4);
            this.texÂv.Name = "texÂv";
            this.texÂv.ReadOnly = true;
            this.texÂv.Size = new System.Drawing.Size(70, 23);
            this.texÂv.TabIndex = 49;
            this.texÂv.TabStop = false;
            this.texÂv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.label21.Font = new System.Drawing.Font("lr oSVbN", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(0, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(22, 456);
            this.label21.TabIndex = 3;
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labo^
            // 
            this.labo^.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.labo^.Font = new System.Drawing.Font("lr oSVbN", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labo^.ForeColor = System.Drawing.Color.BlueViolet;
            this.labo^.Location = new System.Drawing.Point(62, 6);
            this.labo^.Name = "labo^";
            this.labo^.Size = new System.Drawing.Size(60, 18);
            this.labo^.TabIndex = 4;
            this.labo^.Text = "o^";
            this.labo^.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // texo^
            // 
            this.texo^.BackColor = System.Drawing.SystemColors.Window;
            this.texo^.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.texo^.Location = new System.Drawing.Point(122, 4);
            this.texo^.Name = "texo^";
            this.texo^.ReadOnly = true;
            this.texo^.Size = new System.Drawing.Size(54, 23);
            this.texo^.TabIndex = 46;
            this.texo^.TabStop = false;
            this.texo^.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labÂv
            // 
            this.labÂv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.labÂv.Font = new System.Drawing.Font("lr oSVbN", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labÂv.ForeColor = System.Drawing.Color.Blue;
            this.labÂv.Location = new System.Drawing.Point(186, 6);
            this.labÂv.Name = "labÂv";
            this.labÂv.Size = new System.Drawing.Size(60, 18);
            this.labÂv.TabIndex = 6;
            this.labÂv.Text = "Âv";
            this.labÂv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labdÊv
            // 
            this.labdÊv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.labdÊv.Font = new System.Drawing.Font("lr oSVbN", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labdÊv.ForeColor = System.Drawing.Color.Blue;
            this.labdÊv.Location = new System.Drawing.Point(322, 6);
            this.labdÊv.Name = "labdÊv";
            this.labdÊv.Size = new System.Drawing.Size(60, 18);
            this.labdÊv.TabIndex = 8;
            this.labdÊv.Text = "dÊv";
            this.labdÊv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.PaleGreen;
            this.panel6.Controls.Add(this.labOCW×X);
            this.panel6.Controls.Add(this.texOCW×X);
            this.panel6.Controls.Add(this.labpå);
            this.panel6.Controls.Add(this.texpå);
            this.panel6.Location = new System.Drawing.Point(0, 26);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(810, 26);
            this.panel6.TabIndex = 12;
            // 
            // labOCW×X
            // 
            this.labOCW×X.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labOCW×X.ForeColor = System.Drawing.Color.LimeGreen;
            this.labOCW×X.Location = new System.Drawing.Point(694, 8);
            this.labOCW×X.Name = "labOCW×X";
            this.labOCW×X.Size = new System.Drawing.Size(48, 14);
            this.labOCW×X.TabIndex = 14;
            this.labOCW×X.Text = "OC";
            // 
            // texOCW×X
            // 
            this.texOCW×X.BackColor = System.Drawing.Color.PaleGreen;
            this.texOCW×X.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.texOCW×X.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.texOCW×X.ForeColor = System.Drawing.Color.LimeGreen;
            this.texOCW×X.Location = new System.Drawing.Point(744, 6);
            this.texOCW×X.Name = "texOCW×X";
            this.texOCW×X.ReadOnly = true;
            this.texOCW×X.Size = new System.Drawing.Size(42, 16);
            this.texOCW×X.TabIndex = 12;
            this.texOCW×X.TabStop = false;
            this.texOCW×X.Text = "999";
            // 
            // labpå
            // 
            this.labpå.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labpå.ForeColor = System.Drawing.Color.LimeGreen;
            this.labpå.Location = new System.Drawing.Point(14, 8);
            this.labpå.Name = "labpå";
            this.labpå.Size = new System.Drawing.Size(58, 14);
            this.labpå.TabIndex = 10;
            this.labpå.Text = "ZNV";
            // 
            // texpå
            // 
            this.texpå.BackColor = System.Drawing.Color.PaleGreen;
            this.texpå.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.texpå.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.texpå.ForeColor = System.Drawing.Color.LimeGreen;
            this.texpå.Location = new System.Drawing.Point(78, 6);
            this.texpå.Name = "texpå";
            this.texpå.ReadOnly = true;
            this.texpå.Size = new System.Drawing.Size(474, 16);
            this.texpå.TabIndex = 8;
            this.texpå.TabStop = false;
            this.texpå.Text = "1234 {ÐQQQQQQQ¡";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.panel7.Controls.Add(this.labú);
            this.panel7.Controls.Add(this.lab¢­sóü^Cg);
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(792, 26);
            this.panel7.TabIndex = 13;
            // 
            // labú
            // 
            this.labú.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.labú.ForeColor = System.Drawing.Color.White;
            this.labú.Location = new System.Drawing.Point(674, 8);
            this.labú.Name = "labú";
            this.labú.Size = new System.Drawing.Size(112, 14);
            this.labú.TabIndex = 1;
            this.labú.Text = "2005/xx/xx 12:00:00";
            // 
            // lab¢­sóü^Cg
            // 
            this.lab¢­sóü^Cg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(241)))), ((int)(((byte)(83)))));
            this.lab¢­sóü^Cg.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab¢­sóü^Cg.ForeColor = System.Drawing.Color.White;
            this.lab¢­sóü^Cg.Location = new System.Drawing.Point(12, 2);
            this.lab¢­sóü^Cg.Name = "lab¢­sóü^Cg";
            this.lab¢­sóü^Cg.Size = new System.Drawing.Size(264, 24);
            this.lab¢­sóü^Cg.TabIndex = 0;
            this.lab¢­sóü^Cg.Text = "¢­sóü";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.PaleGreen;
            this.panel8.Controls.Add(this.btnÂÊÄ­s);
            this.panel8.Controls.Add(this.btnÄ­s);
            this.panel8.Controls.Add(this.texbZ[W);
            this.panel8.Controls.Add(this.btnÂ¶é);
            this.panel8.Location = new System.Drawing.Point(0, 516);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(792, 58);
            this.panel8.TabIndex = 2;
            // 
            // btnÂÊÄ­s
            // 
            this.btnÂÊÄ­s.ForeColor = System.Drawing.Color.Blue;
            this.btnÂÊÄ­s.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnÂÊÄ­s.Location = new System.Drawing.Point(170, 6);
            this.btnÂÊÄ­s.Name = "btnÂÊÄ­s";
            this.btnÂÊÄ­s.Size = new System.Drawing.Size(62, 48);
            this.btnÂÊÄ­s.TabIndex = 2;
            this.btnÂÊÄ­s.Text = "ÂÊ@@Ä­s";
            this.btnÂÊÄ­s.Click += new System.EventHandler(this.btnÂÊÄ­s_Click);
            // 
            // btnÄ­s
            // 
            this.btnÄ­s.ForeColor = System.Drawing.Color.Blue;
            this.btnÄ­s.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnÄ­s.Location = new System.Drawing.Point(98, 6);
            this.btnÄ­s.Name = "btnÄ­s";
            this.btnÄ­s.Size = new System.Drawing.Size(62, 48);
            this.btnÄ­s.TabIndex = 1;
            this.btnÄ­s.Text = "x@@óü";
            this.btnÄ­s.Click += new System.EventHandler(this.btnÄ­s_Click);
            // 
            // texbZ[W
            // 
            this.texbZ[W.BackColor = System.Drawing.Color.PaleGreen;
            this.texbZ[W.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.texbZ[W.ForeColor = System.Drawing.Color.Red;
            this.texbZ[W.Location = new System.Drawing.Point(446, 4);
            this.texbZ[W.Multiline = true;
            this.texbZ[W.Name = "texbZ[W";
            this.texbZ[W.ReadOnly = true;
            this.texbZ[W.Size = new System.Drawing.Size(344, 50);
            this.texbZ[W.TabIndex = 1;
            this.texbZ[W.TabStop = false;
            // 
            // btnÂ¶é
            // 
            this.btnÂ¶é.ForeColor = System.Drawing.Color.Red;
            this.btnÂ¶é.Location = new System.Drawing.Point(8, 6);
            this.btnÂ¶é.Name = "btnÂ¶é";
            this.btnÂ¶é.Size = new System.Drawing.Size(54, 48);
            this.btnÂ¶é.TabIndex = 0;
            this.btnÂ¶é.TabStop = false;
            this.btnÂ¶é.Text = "Â¶é";
            this.btnÂ¶é.Click += new System.EventHandler(this.btnÂ¶é_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Location = new System.Drawing.Point(16, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(768, 460);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // ¢­sóü
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(792, 574);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.groupBox2);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 607);
            this.Name = "¢­sóü";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "is-2 ¢­sóü";
            this.Activated += new System.EventHandler(this.¢­sóü_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnG^[Ú®);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnG^[LZ);
            ((System.ComponentModel.ISupportInitialize)(this.dsèó)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGTo×ê)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

// MOD 2016.09.28 Vivouac) er Visual Studio 2013`®ÉÏX START
        protected void OnG^[Ú®(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            base.G^[Ú®(sender, e);
        }

        protected void OnG^[LZ(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            base.G^[LZ(sender, e);
        }
// MOD 2016.09.28 Vivouac) er Visual Studio 2013`®ÉÏX END

		/// <summary>
		/// AvP[VÌC Gg |CgÅ·B
		/// </summary>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			iANeBuef = 0;
			//^Cg
			this.Text = "is-2 " + s^Cg;
			lab¢­sóü^Cg.Text = s^Cg;
// ADD 2008.03.19 sjØ ÂÊÄ­s@\ÌÇÁ START
			if(s^Cg.Equals("Ä­s")){
				this.btnÂÊÄ­s.Visible = true;
			}else{
				this.btnÂÊÄ­s.Visible = false;
			}
// ADD 2008.03.19 sjØ ÂÊÄ­s@\ÌÇÁ END

			// wb_[ÚÌÝè
// MOD 2007.07.06 sjØ wb_ÉOCW×Xð\¦ START
//			tex¨ql¼.Text = gspÒ¼;
			if(gspÒåXbc == null || gspÒåXbc.Length == 0)
			{
				texOCW×X.Text = "";
			}
			else
			{
				texOCW×X.Text = gspÒåXbc;
			}
// MOD 2007.07.06 sjØ wb_ÉOCW×Xð\¦ END
			texpå.Text = gsåbc + " " + gså¼;

			// úÌúÝè
			labú.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled = true;

			// o×úÌúÝèiúj
			åo×úîñXV();

// ADD 2005.05.24 sj¬¶J ÚÌú» START
			texbZ[W.Text = "";
			texo^.Text   = "";
			texÂv.Text   = "";
			texdÊv.Text   = "";
			axGTo×ê.Clear();
// ADD 2005.05.24 sj¬¶J ÚÌú» END
// ADD 2007.02.21 sjØ õãÌJÊuÌ²® START
			axGTo×ê.CaretRow = 1;
			axGTo×ê.CaretCol = 1;
			axGTo×ê_CurPlaceChanged(null,null);
// ADD 2007.02.21 sjØ õãÌJÊuÌ²® END

			// [ÝèÅv^ðgpÅ«È¢ÝèÌêAóü{^gpsÂ
			if(gsv^ef != "1")
			{
				btnÄ­s.Enabled = false;
			}

// MOD 2006.07.26 sjR{ êÉ^ÀÆÛ¯¿ÌÚðÇÁ START
//			axGTo×ê.Cols = 13;
// MOD 2007.02.08 sjØ ê\¦ÚÌÏX START
//			axGTo×ê.Cols = 16;
// MOD 2008.10.29 sjØ ¿æîñðÇÁ START
//			axGTo×ê.Cols = 18;
			axGTo×ê.Cols = 21;
// MOD 2008.10.29 sjØ ¿æîñðÇÁ END
// MOD 2007.02.08 sjØ ê\¦ÚÌÏX END
// MOD 2006.07.26 sjR{ êÉ^ÀÆÛ¯¿ÌÚðÇÁ END
			axGTo×ê.Rows = 14;
			axGTo×ê.ColSep = "|";
// MOD 2006.07.26 sjR{ êÉ^ÀÆÛ¯¿ÌÚðÇÁ START
//			axGTo×ê.set_RowsText(0, "|o×ú|¨Í¯æ|Â|dÊ|A¤i^LEi¼|èóÔ|wèú|Aóµ|o^ú|¨qlÔ|W[imn|ú|oú|");
//			axGTo×ê.ColsWidth = "0|3.5|15|3|3.5|12|7|4.5|5|3.5|15|0|0|0|";
//			axGTo×ê.ColsAlignHorz = "1|1|0|2|2|0|0|1|1|1|0|0|0|0|";

//			axGTo×ê.set_RowsText(0, "|o×ú|¨Í¯æ|Â|dÊ|A¤i^LEi¼|èóÔ|wèú|Aóµ|o^ú|¨qlÔ|W[imn|ú|oú|o^Ò|Û¯¿i~j|^Ài~j|");
//			axGTo×ê.ColsWidth = "0|3.5|15|3|3.5|12|7|4.5|5|3.5|15|0|0|0|0|6|6|";
//			axGTo×ê.ColsAlignHorz = "1|1|0|2|2|0|0|1|1|1|0|0|0|0|0|2|2|";

// MOD 2007.02.08 sjØ ê\¦ÚÌÏX START
//			axGTo×ê.set_RowsText(0, "|o×ú|¨Í¯æ|Â|dÊ|Û¯¿i~j|^Ài~j|A¤i^LEi¼|èóÔ|wèú|Aóµ|o^ú|¨qlÔ|W[imn|ú|oú|o^Ò|");
//			axGTo×ê.ColsWidth = "0|4|17|4|4.5|6|6|12|7|4.5|5|3.5|15.5|0|0|0|0|";
//			axGTo×ê.ColsAlignHorz = "1|1|0|2|2|2|2|0|0|1|1|1|0|0|0|0|0|";
			axGTo×ê.set_RowsText(0, "||×ÍÞÙ|o×ú|¨Í¯æ|Â|dÊ|èóÔ|¨qlÔ|wèú|Aóµ|A¤i^LEi¼|^À|Û¯¿|o^ú|W[imn|ú|oú|o^Ò|");
// MOD 2008.10.29 sjØ ¿æîñðÇÁ START
//			axGTo×ê.ColsWidth =    "0|0|2.2|3.6|18|3|3.4|6.5|8.5|5.3|4.6|13.0|6|6|5|0|0|0|0|";
// MOD 2010.10.01 sjØ ¨qlÔPU» START
//			axGTo×ê.ColsWidth =    "0|0|2.2|3.6|18|3|3.4|6.5|8.5|5.3|4.6|13.0|6|6|5|0|0|0|0|0|0|0|";
			axGTo×ê.ColsWidth =    "0|0|2.2|3.6|18|2.6|3|6.0|9.8|5.3|4.6|13.0|6|6|4.2|0|0|0|0|0|0|0|";
// MOD 2010.10.01 sjØ ¨qlÔPU» END
// MOD 2008.10.29 sjØ ¿æîñðÇÁ END
			axGTo×ê.ColsAlignHorz = "1|1|1|1|0|2|2|0|0|1|1|0|2|2|1|0|0|0|0|";
// MOD 2007.02.08 sjØ ê\¦ÚÌÏX END
// MOD 2006.07.26 sjR{ êÉ^ÀÆÛ¯¿ÌÚðÇÁ END

//			axGTo×ê.set_CelForeColor(axGTo×ê.CaretRow,0,111111);
			axGTo×ê.set_CelForeColor(axGTo×ê.CaretRow,0,0x98FB98);  //BGR
			axGTo×ê.set_CelBackColor(axGTo×ê.CaretRow,0,0x006000);

			for(short i = 1; i <= axGTo×ê.Rows; i++ )
			{
				axGTo×ê.set_CelHeight(i,0,2.3);
// MOD 2007.02.08 sjØ ê\¦ÚÌÏX START
//				axGTo×ê.set_CelAlignVert(i,2,3);
//// MOD 2006.08.03 sjR{ êÉ^ÀÆÛ¯¿ÌÚðÇÁ START
////				axGTo×ê.set_CelAlignVert(i,5,3);
////				axGTo×ê.set_CelAlignVert(i,6,3);
//				axGTo×ê.set_CelAlignVert(i,7,3);
//				axGTo×ê.set_CelAlignVert(i,8,3);
//// MOD 2006.08.03 sjR{ êÉ^ÀÆÛ¯¿ÌÚðÇÁ END
				axGTo×ê.set_CelAlignVert(i,4,3);
				axGTo×ê.set_CelAlignVert(i,7,3);
				axGTo×ê.set_CelAlignVert(i,11,3);
// MOD 2007.02.08 sjØ ê\¦ÚÌÏX END
			}
		}

		private void btnÂ¶é_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void o×õ()
		{
			string sÍ¯æ = "";
			string sËå = "";
			int    io×ú = 0;
// ADD 2005.06.01 sj¬¶J `CXÍútÍÍÈµ START
//			string sSday = gdto×ú.ToShortDateString().Replace("/","");
//			string sEday = gdto×ú.ToShortDateString().Replace("/","");
			string sSday = "";
			string sEday = "";
			if(sóÔíÊ != "aa")
			{
				sSday = "0";
				sEday = "0";
			}
			else
			{
// MOD 2005.07.08 sjØ útÏ·ÌÏX START
//				sSday = gdto×ú.ToShortDateString().Replace("/","");
//				sEday = gdto×ú.ToShortDateString().Replace("/","");
				sSday = YYYYMMDDÏ·(gdto×ú);
// MOD 2007.02.20 sjØ Ä­sæÊÅo×úª¢ÅàóüÂÉ·é START
//				sEday = YYYYMMDDÏ·(gdto×ú);
				sEday = "99991231";
// MOD 2007.02.20 sjØ Ä­sæÊÅo×úª¢ÅàóüÂÉ·é END
// MOD 2005.07.08 sjØ útÏ·ÌÏX END
			}
// ADD 2005.06.01 sj¬¶J `CXÍútÍÍÈµ END
//			string sóÔ = gsaóÔbc[1];
			string sóÔ = sóÔíÊ;

			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			try
			{
				so×ê = new string[1];
				if(sv_syukka == null) sv_syukka = new is2syukka.Service1();
// MOD 2006.07.26 sjR{ êÉ^ÀÆÛ¯¿ÌÚðÇÁ START
//				so×ê = sv_syukka.Get_syukka(gsa[U,gsïõbc,gsåbc,sÍ¯æ, sËå, io×ú, sSday, sEday, sóÔ);
				so×ê = sv_syukka.Get_syukka1(gsa[U,gsïõbc,gsåbc,sÍ¯æ, sËå, io×ú, sSday, sEday, sóÔ);
// MOD 2006.07.26 sjR{ êÉ^ÀÆÛ¯¿ÌÚðÇÁ END
				texbZ[W.Text = so×ê[0];
				if(so×ê[0].Length == 4)
				{
					texbZ[W.Text = "";
					texo^.Text = so×ê[1];
					texÂv.Text = so×ê[2];
					texdÊv.Text = so×ê[3];

					ÅîñÝè();

				}
				else
				{
					if(so×ê[0].Equals("Yf[^ª èÜ¹ñ"))
					{
						texbZ[W.Text = "";
						MessageBox.Show("Yf[^ª èÜ¹ñ","o×õ",MessageBoxButtons.OK);
						this.Close();
					}
					else
					{
//						i»ÝÅ = 1;
						r[v¹();
					}
				}
			}
// ADD 2005.05.24 sj¬¶J ÊMG[ÌbZ[WC³ START
			catch (System.Net.WebException)
			{
				texbZ[W.Text = gsÊMG[;
				r[v¹();
			}
// ADD 2005.05.24 sj¬¶J ÊMG[ÌbZ[WC³ END
			catch (Exception ex)
			{
				texbZ[W.Text = "ÊMG[F" + ex.Message;
				r[v¹();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
			axGTo×ê.CaretRow = 1;
			axGTo×ê_CurPlaceChanged(null,null);

		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			labú.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

		private void axGTo×ê_CurPlaceChanged(object sender, AxGTABLE32V2Lib._DGTable32Events_CurPlaceChangedEvent e)
		{
			axGTo×ê.set_CelForeColor(OldRow,0,0);
			axGTo×ê.set_CelBackColor(OldRow,0,0xFFFFFF);
			if(axGTo×ê.SelStartRow == axGTo×ê.SelEndRow)
			{
				if(nSrow > nErow)
				{
					nWork = nSrow;
					nSrow = nErow;
					nErow = nWork;
				}
				for(short nCnt = nSrow; nCnt <= nErow; nCnt++)
				{
//					axGTo×ê.set_CelForeColor(nCnt,0,0);
					axGTo×ê.set_CelForeColor(nCnt,0,0);
					axGTo×ê.set_CelBackColor(nCnt,0,0xFFFFFF);
				}
			}
//			axGTo×ê.set_CelForeColor(axGTo×ê.SelStartRow,0,111111);
//			axGTo×ê.set_CelForeColor(axGTo×ê.SelEndRow,0,111111);
//			axGTo×ê.set_CelForeColor(axGTo×ê.CaretRow,0,111111);
// MOD 2011.03.23 sjØ J[\Û@\ÌÇÁ START
//			axGTo×ê.set_CelForeColor(axGTo×ê.SelStartRow,0,0x98FB98);
//			axGTo×ê.set_CelBackColor(axGTo×ê.SelStartRow,0,0x006000);
//			axGTo×ê.set_CelForeColor(axGTo×ê.SelEndRow,0,0x98FB98);
//			axGTo×ê.set_CelBackColor(axGTo×ê.SelEndRow,0,0x006000);
			short nJn = axGTo×ê.SelStartRow;
			short nI¹ = axGTo×ê.SelEndRow;
			if(nJn > nI¹){
				nJn = axGTo×ê.SelEndRow;
				nI¹ = axGTo×ê.SelStartRow;
			}
			for(short ns = nJn; ns <= nI¹; ns++){
				axGTo×ê.set_CelForeColor(ns,0,0x98FB98);
				axGTo×ê.set_CelBackColor(ns,0,0x006000);
			}
// MOD 2011.03.23 sjØ J[\Û@\ÌÇÁ END
			axGTo×ê.set_CelForeColor(axGTo×ê.CaretRow,0,0x98FB98);
			axGTo×ê.set_CelBackColor(axGTo×ê.CaretRow,0,0x006000);
/*			if(axGTo×ê.SelEndRow > axGTo×ê.CaretRow
				&& axGTo×ê.SelStartRow <= axGTo×ê.CaretRow
				&& axGTo×ê.get_CelForeColor(axGTo×ê.SelEndRow,0) != Color.Black)
				axGTo×ê.set_CelForeColor(axGTo×ê.SelEndRow,0,0);

			if(axGTo×ê.SelEndRow < axGTo×ê.CaretRow
				&& axGTo×ê.SelStartRow >= axGTo×ê.CaretRow
				&& axGTo×ê.get_CelForeColor(axGTo×ê.SelEndRow,0) != Color.Black)
				axGTo×ê.set_CelForeColor(axGTo×ê.SelEndRow,0,0);
*/
// MOD 2011.03.23 sjØ J[\Û@\ÌÇÁ START
//			if(axGTo×ê.SelEndRow > axGTo×ê.CaretRow
//				&& axGTo×ê.SelStartRow <= axGTo×ê.CaretRow
//				&& axGTo×ê.get_CelForeColor(axGTo×ê.SelEndRow,0) != Color.Black)
//			{
//				axGTo×ê.set_CelForeColor(axGTo×ê.SelEndRow,0,0);
//				axGTo×ê.set_CelBackColor(axGTo×ê.SelEndRow,0,0xFFFFFF);
//			}
//
//			if(axGTo×ê.SelEndRow < axGTo×ê.CaretRow
//				&& axGTo×ê.SelStartRow >= axGTo×ê.CaretRow
//				&& axGTo×ê.get_CelForeColor(axGTo×ê.SelEndRow,0) != Color.Black)
//			{
//				axGTo×ê.set_CelForeColor(axGTo×ê.SelEndRow,0,0);
//				axGTo×ê.set_CelBackColor(axGTo×ê.SelEndRow,0,0xFFFFFF);
//			}
// MOD 2011.03.23 sjØ J[\Û@\ÌÇÁ END

			OldRow = axGTo×ê.CaretRow;
			nSrow  = axGTo×ê.SelStartRow;
			nErow  = axGTo×ê.SelEndRow;

		}

		private void axGTo×ê_CelClick(object sender, AxGTABLE32V2Lib._DGTable32Events_CelClickEvent e)
		{
			axGTo×ê_CurPlaceChanged(null,null);
			if(axGTo×ê.SelStartRow != axGTo×ê.SelEndRow)
			{
				if(nSrow > nErow)
				{
					nWork = nSrow;
					nSrow = nErow;
					nErow = nWork;
				}
				for(short nCnt = nSrow; nCnt <= nErow; nCnt++)
				{
					axGTo×ê.set_CelForeColor(nCnt,0,0x98FB98);
					axGTo×ê.set_CelBackColor(nCnt,0,0x006000);
				}
				for(int nCnt = int.Parse(nSrow.ToString()) - 1; nCnt >= 1; nCnt--)
				{
					axGTo×ê.set_CelForeColor(short.Parse(nCnt.ToString()),0,0);
					axGTo×ê.set_CelBackColor(short.Parse(nCnt.ToString()),0,0xFFFFFF);
				}
				for(int nCnt = int.Parse(nErow.ToString()) + 1; nCnt <= axGTo×ê.Rows; nCnt++)
				{
					axGTo×ê.set_CelForeColor(short.Parse(nCnt.ToString()),0,0);
					axGTo×ê.set_CelBackColor(short.Parse(nCnt.ToString()),0,0xFFFFFF);
				}
			}
		}

		private void axGTo×ê_KeyDownEvent(object sender, AxGTABLE32V2Lib._DGTable32Events_KeyDownEvent e)
		{
			if (e.keyCode == 9)
			{
				this.SelectNextControl(axGTo×ê, true, true, true, true);
			}
		}

// MOD 2008.03.19 sjØ ÂÊÄ­s@\ÌÇÁ START
//		private void btnÄ­s_Click(object sender, System.EventArgs e)
		private void btnÄ­s_Click(int iJn, int iI¹)
// MOD 2008.03.19 sjØ ÂÊÄ­s@\ÌÇÁ END
		{
// MOD 2007.03.10 sjØ ê\¦ÚÌÏXiáQj START
//// MOD 2006.08.10 sjR{ Û¯¿^ÀÇÁÎ START
////			if(axGTo×ê.get_CelText(axGTo×ê.CaretRow,12).Trim().Length == 0)
//			if(axGTo×ê.get_CelText(axGTo×ê.CaretRow,14).Trim().Length == 0)
//// MOD 2006.08.10 sjR{ Û¯¿^ÀÇÁÎ END
			//o^ú`FbN
			if(axGTo×ê.get_CelText(axGTo×ê.CaretRow,16).Trim().Length == 0)
// MOD 2007.03.10 sjØ ê\¦ÚÌÏXiáQj END
				return;

			texbZ[W.Text = "èó×DóüDDD";

			try
			{
				v^`FbN();
			}
			catch(Exception ex)
			{
				texbZ[W.Text = ex.Message;
				return;
			}
			Cursor = System.Windows.Forms.Cursors.AppStarting;

			short nJn;
			short nI¹;
			if(axGTo×ê.SelStartRow > axGTo×ê.SelEndRow)
			{
				nI¹ = axGTo×ê.SelStartRow;
				nJn = axGTo×ê.SelEndRow;
			}
			else
			{
				nJn = axGTo×ê.SelStartRow;
				nI¹ = axGTo×ê.SelEndRow;
			}
// MOD 2011.03.23 sjØ J[\Û@\ÌÇÁ START
			short n\¦Jn = axGTo×ê.TopRow;
			string sJno^ú         = axGTo×ê.get_CelText(nJn,16).Trim();
			string sJnW[imn = axGTo×ê.get_CelText(nJn,15).Trim();
//Û¯FÔÌsÌ`FbN
			string sI¹o^ú         = axGTo×ê.get_CelText(nI¹,16).Trim();
			string sI¹W[imn = axGTo×ê.get_CelText(nI¹,15).Trim();
			string sso^ú         = "";
			string ssW[imn = "";
			short ns = (short)(nI¹ + 1);
			if(ns <= axGTo×ê.Rows){
				sso^ú         = axGTo×ê.get_CelText(ns,16).Trim();
				ssW[imn = axGTo×ê.get_CelText(ns,15).Trim();
			}
// MOD 2011.03.23 sjØ J[\Û@\ÌÇÁ END

// MOD 2010.07.26 sjØ óüÌwèi¼ÎQj START
//			dsèó.Clear();
			èóf[^NA();
// MOD 2010.07.26 sjØ óüÌwèi¼ÎQj END

			for(short nCnt = nJn ; nCnt <= nI¹; nCnt++)
			{
// MOD 2011.03.23 sjØ J[\Û@\ÌÇÁ START
				//o^úªóÈçf[^Ö
				if(axGTo×ê.get_CelText(nCnt,16).Trim().Length == 0){
					continue;
				}
// MOD 2011.03.23 sjØ J[\Û@\ÌÇÁ END
				try
				{
					string[] sData = new string[2];
// MOD 2007.03.10 sjØ ê\¦ÚÌÏXiáQj START
//// MOD 2006.08.10 sjR{ Û¯¿^ÀÇÁÎ START
////					sData[0] = axGTo×ê.get_CelText(nCnt, 12);
////					sData[1] = axGTo×ê.get_CelText(nCnt, 11);
//					sData[0] = axGTo×ê.get_CelText(nCnt, 14);
//					sData[1] = axGTo×ê.get_CelText(nCnt, 13);
//// MOD 2006.08.10 sjR{ Û¯¿^ÀÇÁÎ END
					//o^úAW[imn
					sData[0] = axGTo×ê.get_CelText(nCnt, 16);
					sData[1] = axGTo×ê.get_CelText(nCnt, 15);
// MOD 2007.03.10 sjØ ê\¦ÚÌÏXiáQj END

// MOD 2008.03.19 sjØ ÂÊÄ­s@\ÌÇÁ START
//					èóóüw¦(sData);
					èóóüw¦(sData, iJn, iI¹);
// MOD 2008.03.19 sjØ ÂÊÄ­s@\ÌÇÁ END
// ADD 2006.12.12 sj¬¶J XÆåXªÙÈéêÍAóüµÈ¢ START
					if(!gbóü)
					{
						texbZ[W.Text = "";
						Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2007.02.19 FJCSjKc bZ[WÏX START
//						MessageBox.Show("­Xªá¢Ü·BóüÅ«Ü¹ñB","óóü"
						MessageBox.Show("W×Xªá¢Ü·BóüÅ«Ü¹ñB","óóü"
// MOD 2007.02.19 FJCSjKc bZ[WÏX START
							,MessageBoxButtons.OK);
						return;
					}
// ADD 2006.12.12 sj¬¶J XÆåXªÙÈéêÍAóüµÈ¢ END
				}
				catch (Exception ex)
				{
					texbZ[W.Text = ex.Message;
					r[v¹();
					return;
				}
			}
			Cursor = System.Windows.Forms.Cursors.Default;

			èó [óü();

			// Äõ
//			btno×õ_Click(sender, e);
			o×õ();
// MOD 2011.03.23 sjØ J[\Û@\ÌÇÁ START
			êJ[\Ú®(nJn, nI¹, n\¦Jn
							, sJno^ú, sJnW[imn
							, sI¹o^ú, sI¹W[imn
							, sso^ú, ssW[imn);
// MOD 2011.03.23 sjØ J[\Û@\ÌÇÁ END

			texbZ[W.Text = "";
		}


		private void ÅîñÝè()
		{
//
			if (so×ê.Length - 4 <= 14)
			{
				axGTo×ê.Rows = 14;
			}
			else if (axGTo×ê.Rows < so×ê.Length - 4)
			{
				axGTo×ê.Rows = (short)(so×ê.Length - 4);
			}
			for(short i = 1; i <= axGTo×ê.Rows; i++ )
			{
				axGTo×ê.set_CelHeight(i,0,2.3);
// MOD 2007.02.08 sjØ ê\¦ÚÌÏX START
//				axGTo×ê.set_CelAlignVert(i,2,3);
//// MOD 2006.08.03 sjR{ êÉ^ÀÆÛ¯¿ÌÚðÇÁ START
////				axGTo×ê.set_CelAlignVert(i,5,3);
////				axGTo×ê.set_CelAlignVert(i,6,3);
//				axGTo×ê.set_CelAlignVert(i,7,3);
//				axGTo×ê.set_CelAlignVert(i,8,3);
//// MOD 2006.08.03 sjR{ êÉ^ÀÆÛ¯¿ÌÚðÇÁ END
				axGTo×ê.set_CelAlignVert(i,4,3);
				axGTo×ê.set_CelAlignVert(i,7,3);
				axGTo×ê.set_CelAlignVert(i,11,3);
// MOD 2007.02.08 sjØ ê\¦ÚÌÏX END
			}
//
			axGTo×ê.Clear();
// ADD 2007.02.21 sjØ õãÌJÊuÌ²® START
			axGTo×ê.CaretRow = 1;
			axGTo×ê.CaretCol = 1;
			axGTo×ê_CurPlaceChanged(null,null);
// ADD 2007.02.21 sjØ õãÌJÊuÌ²® END

			short s\¦ = (short)1;
			for(short sCnt = (short)4; sCnt < so×ê.Length; sCnt++)
			{
				string sRList = so×ê[sCnt].Replace("\\r\\n","\r\n");
				axGTo×ê.set_RowsText(s\¦, sRList);
				s\¦++;
			}
			axGTo×ê.Focus();
		}

		private void ¢­sóü_Activated(object sender, System.EventArgs e)
		{
			if(iANeBuef == 0)
				o×õ();
			iANeBuef = 1;
		}

// ADD 2008.03.19 sjØ ÂÊÄ­s@\ÌÇÁ START
		private void btnÄ­s_Click(object sender, System.EventArgs e)
		{
			btnÄ­s_Click(1, 99);
		}

		private void btnÂÊÄ­s_Click(object sender, System.EventArgs e)
		{
			//o^ú`FbN
			if(axGTo×ê.get_CelText(axGTo×ê.CaretRow,16).Trim().Length == 0)
				return;

			//PsÈã
			if(axGTo×ê.SelStartRow != axGTo×ê.SelEndRow)
			{
				MessageBox.Show("¡Ìf[^ðIðµ½óÔÅÍÀsÅ«Ü¹ñB\r\n"
								+ "PÌÝIðµÄÀsµÄ­¾³¢B"
								, "mF", MessageBoxButtons.OK );
				return;
			}

			ÂÊÄ­s gÂÄ­s = new ÂÊÄ­s();
			gÂÄ­s.Left = this.Left + (this.Width  - gÂÄ­s.Width)  / 2;
			gÂÄ­s.Top  = this.Top  + (this.Height - gÂÄ­s.Height) / 2;
			gÂÄ­s.ShowDialog(this);

			//[Â¶é]{^ð³ê½
			if(gÂÄ­s.iJn == 0 && gÂÄ­s.iI¹ == 0) return;

			int iJn = gÂÄ­s.iJn;
			int iI¹ = gÂÄ­s.iI¹;
			gÂÄ­s = null;
			btnÄ­s_Click(iJn, iI¹);
		}
// ADD 2008.03.19 sjØ ÂÊÄ­s@\ÌÇÁ END
// MOD 2011.03.23 sjØ J[\Û@\ÌÇÁ START
		private void êJ[\Ú®(short nJn, short nI¹, short n\¦Jn
								, string sJno^ú, string sJnW[imn
								, string sI¹o^ú, string sI¹W[imn
								, string sso^ú, string ssW[imn)
		{
			//IðsÌNA
			axGTo×ê.CaretRow    = 1;
			axGTo×ê.SelStartRow = 1;
			axGTo×ê.SelEndRow   = 1;
			axGTo×ê.CaretCol    = 2;
			//IðsÌÝè
			short nVJn = 0;
			short nVI¹ = 0;
			//IðJnsÆIðI¹sª©íçÈ¢ê
			if(sJno^ú == axGTo×ê.get_CelText(nJn,16).Trim()
			&& sJnW[imn == axGTo×ê.get_CelText(nJn,15).Trim()
			&& sI¹o^ú == axGTo×ê.get_CelText(nI¹,16).Trim()
			&& sI¹W[imn == axGTo×ê.get_CelText(nI¹,15).Trim()){
				nVJn = nJn;
				nVI¹ = nI¹;
			}else{
				for(short ns = 1; ns <= axGTo×ê.Rows; ns++){
					//IðJnsÌlio^úAW[imnjª¯¶ê
					if(sJno^ú == axGTo×ê.get_CelText(ns,16).Trim()
					&& sJnW[imn == axGTo×ê.get_CelText(ns,15).Trim()){
						nVJn = ns;
					}
					//IðI¹sÌlio^úAW[imnjª¯¶ê
					if(sI¹o^ú == axGTo×ê.get_CelText(ns,16).Trim()
					&& sI¹W[imn == axGTo×ê.get_CelText(ns,15).Trim()){
						nVI¹ = ns;
						break;
					}
				}
			}
			//XN[ÊuÌÝè
			if(n\¦Jn <= axGTo×ê.Rows){
				axGTo×ê.TopRow = n\¦Jn;
			}
			//ÄõãÌêÉYf[^ª¶Ý·éê
			if(nVI¹ > 0){
//Û¯FÔÌsÌ`FbN
				//Iðsª¯¶ê
				if(nVJn > 0 && (nI¹ - nJn == nVI¹ - nVJn)){
					axGTo×ê.CaretRow    = nVJn;
					axGTo×ê.SelStartRow = nVJn;
					axGTo×ê.SelEndRow   = nVI¹;
				}else{
					axGTo×ê.CaretRow    = nVI¹;
					axGTo×ê.SelStartRow = nVI¹;
					axGTo×ê.SelEndRow   = nVI¹;
				}
			}else{
				if(sso^ú.Length > 0 && ssW[imn.Length > 0){
					for(short ns = 1; ns <= axGTo×ê.Rows; ns++){
						//IðJnsÌlio^úAW[imnjª¯¶ê
						if(sso^ú == axGTo×ê.get_CelText(ns,16).Trim()
						&& ssW[imn == axGTo×ê.get_CelText(ns,15).Trim()){
							axGTo×ê.CaretRow    = ns;
							axGTo×ê.SelStartRow = ns;
							axGTo×ê.SelEndRow   = ns;
							break;
						}
					}
				}
			}
			axGTo×ê_CurPlaceChanged(null,null);
		}
// MOD 2011.03.23 sjØ J[\Û@\ÌÇÁ END

	}
}
