using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Text;

namespace IS2Client
{
	/// <summary>
	/// お届け先取込
	/// </summary>
	//--------------------------------------------------------------------------
	// 修正履歴
	//--------------------------------------------------------------------------
	// ADD 2008.04.23 東都）高木 固定長ファイルのエラーファイル出力対応 
	// ＡＣＴ）山本殿より障害報告有
	// 現象：固定長ファイル取込時、エラーがあるにもかかわらずＤＢが更新される
	// 原因：固定長ファイルへの対応もれ
	// ADD 2008.04.11 ACT Vista対応 
	// ADD 2008.05.15 ACT Vista対応（エラー件数表示） 
	//--------------------------------------------------------------------------
	// MOD 2009.04.06 東都）高木 先頭行無視機能の追加 
	// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 
	// MOD 2009.12.01 東都）高木 データ登録時のエラーチェックを追加 
	//--------------------------------------------------------------------------
	// MOD 2010.03.12 東都）高木 １００００件チェック解除機能の追加 
	// MOD 2010.03.30 東都）高木 電話番号形式追加対応 
	// MOD 2010.03.30 東都）高木 携帯電話対応 
	// MOD 2010.04.26 東都）高木 １００００件チェック機能の変更 
	// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 
	// MOD 2010.05.11 東都）高木 行数表示の障害修正 
	// MOD 2010.11.25 東都）高木 GetAsyncKeyStateの訂正 
	//--------------------------------------------------------------------------
	// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない 
	//--------------------------------------------------------------------------
	// MOD 2015.05.13 BEVAS) 前田 王子会員様の郵便番号チェックを王子マスタで行う
	//--------------------------------------------------------------------------
	public class お届け先取込 : 共通フォーム
	{
		private string fileName = "";
// ADD 2006.06.30 東都）山本　取込時の取込件数＆エラー件数の表示対応 START
		private int i登録件数		= 0;
		private int iエラー件数		= 0;
// MOD 2007.01.17 FJCS) 桑田　荷主総件数をシート総件数に変更 START
//		private int i荷主総件数		= 0;
		private int iシート総件数	= 0;
// MOD 2007.01.17 FJCS) 桑田　荷主総件数をシート総件数に変更 END
// ADD 2006.06.30 東都）山本　取込時の取込件数＆エラー件数の表示対応 END
// DEL 2006.12.01 東都）高木 住所→郵便番号変換機能の削除 START
//// ADD 2006.07.14 東都）高木 住所→郵便番号変換機能の追加 START
//		private static Hashtable h都道府県２ = null;
//		private static string sあいまい文字
//			= "１壱２弐３参４５６７８９の乃けガがヶつ－";
//		private static string sあいまい文字変換
//			= "一一二二三三四五六七八九ノノケケケケツー";
//		private static string[] sa旧漢字
//		= {
//			 "亞惡蘆鰺壓菴圍爲醫毓弌壹稻飮婬隱夘鬱廐睿"
//			,"營曵榮頴衞咏驛圓烟艷鹽奧徃應歐毆鶯冲穩假"
//			,"價譁峩畫會觧囘壞恠懷繪蠏礙葢蠣鉤擴攪殼覺"
//			,"學嶽樂竈釡鬻勸卷歡灌罐觀諫鑒關陷陷舘鴈顏"
//			,"噐竒朞棊弃歸氣龜僞戲犧卻糺舊據擧亰峽挾况"
//			,"狹堯曉亟區驅勳羣徑惠憇攜溪經繼莖螢輕頸鷄"
//			,"藝缺决儉剱圈檢權獻縣險顯驗嚴乕皷效廣恆晄"
//			,"稾鑛刧軣國嵳濟碎劑戝冱阪埼櫻册雜皋參慘棧"
//			,"蠶讚贊殘絲帋齒亊兒辭濕貭實筱蘂舍寫釋咒壽"
//			,"收穐讎從澁獸縱肅凖處敍甞奬將厰枩燒稱證乘"
//			,"剩塲壤孃條淨疊穰讓釀囑觸脣寢愼晉眞刄盡靫"
//			,"醋圖廚埀粹翆醉隨髓數樞丗畆淒棲聲靜齋攝竊"
//			,"專戰淺潛綫纎舩賤踐錢譱禪曾踈蘓溯鼡雙壯搜"
//			,"插爭窗總聰莊裝赱騷臟藏屬續卆夛墮柁橢躰對"
//			,"帶滯臺瀧擇澤鈬逹豎貍單擔膽團彈斷耻癡穉遲"
//			,"晝蟲鑄潴豬廰甼聽膓敕珎鎭壺遞鐡纒轉點傳兔"
//			,"礪黨嶋檮盜燈當迯鬪仂獨讀杤屆繩弍邇韭姙迺"
//			,"惱腦霸廢拜盃楳賣蠅凾發髮罸拔蠻祕檜冰濱冨"
//			,"拂佛幤竝閇篦變邊辯舖穗寶峯萠襃豐冐皃沒夲"
//			,"飜槇儘萬滿簑脉梦壻麪默餠埜彌藥譯藪瘉涌豫"
//			,"餘與譽搖樣窰燿謠踴遙來亂覽畧澑畄龍兩凉獵"
//			,"暸粮鄰璢壘泪勵禮隸靈齡戀聨爐勞朖樓籠祿亙"
//			,"灣仞爼倅僭寃寇羃尅箚巵廁廈廝咯譟嚔阯埒罎"
//			,"弉匳侫嫻嫐爾崘篏迪彜弯髴悴慙懴戞扨擡旛曠"
//			,"桝檳椶樒蘗櫟殲徇冽淵烱熈熏犂豺貉貘瑯瑤瓔"
//			,"畴肬皹眦禀筺笋筝籘籤纃羇羹腟舮莓蕚蝨蟆蠎"
//			,"蠹衂袵襌諡譖貔贓躪體輙輛遒鑪鑽鬧濶齏飃鰮"
//			,"鳬鴟鵝鶫鷏麩囓"
//		};
//		private static string[] sa新漢字
//		= {
//			 "亜悪芦鯵圧庵囲為医育一壱稲飲淫隠卯欝厩叡"
//			,"営曳栄穎衛詠駅円煙艶塩奥往応欧殴鴬沖穏仮"
//			,"価嘩峨画会解回壊怪懐絵蟹碍蓋蛎鈎拡撹殻覚"
//			,"学岳楽竃釜粥勧巻歓潅缶観諌鑑関陥陥館雁顔"
//			,"器奇期棋棄帰気亀偽戯犠却糾旧拠挙京峡挟況"
//			,"狭尭暁極区駆勲群径恵憩携渓経継茎蛍軽頚鶏"
//			,"芸欠決倹剣圏検権献県険顕験厳虎鼓効広恒晃"
//			,"稿鉱劫轟国嵯済砕剤財冴坂崎桜冊雑皐参惨桟"
//			,"蚕讃賛残糸紙歯事児辞湿質実篠蕊舎写釈呪寿"
//			,"収秋讐従渋獣縦粛準処叙嘗奨将廠松焼称証乗"
//			,"剰場壌嬢条浄畳穣譲醸嘱触唇寝慎晋真刃尽靭"
//			,"酢図厨垂粋翠酔随髄数枢世畝凄栖声静斉摂窃"
//			,"専戦浅潜線繊船賎践銭善禅曽疎蘇遡鼠双壮捜"
//			,"挿争窓総聡荘装走騒臓蔵属続卒多堕舵楕体対"
//			,"帯滞台滝択沢鐸達竪狸単担胆団弾断恥痴稚遅"
//			,"昼虫鋳瀦猪庁町聴腸勅珍鎮壷逓鉄纏転点伝兎"
//			,"砺党島梼盗灯当逃闘働独読栃届縄二迩韮妊廼"
//			,"悩脳覇廃拝杯梅売蝿函発髪罰抜蛮秘桧氷浜富"
//			,"払仏幣並閉箆変辺弁舗穂宝峰萌褒豊冒貌没本"
//			,"翻槙侭万満蓑脈夢婿麺黙餅野弥薬訳薮癒湧予"
//			,"余与誉揺様窯耀謡踊遥来乱覧略溜留竜両涼猟"
//			,"瞭糧隣瑠塁涙励礼隷霊齢恋聯炉労朗楼篭禄亘"
//			,"湾仭俎伜僣冤冦冪剋剳卮厠厦厮喀噪嚏址埓壜"
//			,"奘奩佞嫺嬲尓崙嵌廸彝彎彿忰慚懺戛扠抬旙昿"
//			,"枡梹棕櫁檗檪殱洵洌渕炯煕燻犁犲狢獏琅瑶珱"
//			,"疇疣皸眥稟筐筍箏籐籖緕羈羮膣艫苺萼虱蟇蟒"
//			,"蠧衄衽褝謚譛豼賍躙軆輒輌逎鈩鑚閙闊韲飄鰛"
//			,"鳧鵄鵞鶇鷆麸齧"
//		};
//// ADD 2006.07.14 東都）高木 住所→郵便番号変換機能の追加 END
// DEL 2006.12.01 東都）高木 住所→郵便番号変換機能の削除 END

		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button btn閉じる;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lab日時;
		private System.Windows.Forms.Label labお客様名;
		private System.Windows.Forms.Label lab利用部門;
		private System.Windows.Forms.TextBox texお客様名;
		private System.Windows.Forms.TextBox tex利用部門;
		private System.Windows.Forms.TextBox texメッセージ;
		private System.Windows.Forms.Label labお届け先取込;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label labファイル名;
		private IS2Client.共通テキストボックス texファイル名;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn開く;
		private System.Windows.Forms.Button btn取込;
		private System.Windows.Forms.TextBox texデータエラー;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblエラー件数;
		private System.Windows.Forms.Label lbl取込件数;
		private System.Windows.Forms.Label label4;
// MOD 2007.01.17 FJCS) 桑田　荷主総件数をシート総件数に変更 START
//		private System.Windows.Forms.Label lbl荷主総件数;
		private System.Windows.Forms.Label lblシート総件数;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox cBox先頭行無視;
// MOD 2007.01.17 FJCS) 桑田　荷主総件数をシート総件数に変更 END
		private System.Windows.Forms.OpenFileDialog ofdお届け先データ;

		public お届け先取込()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(お届け先取込));
			this.panel6 = new System.Windows.Forms.Panel();
			this.texお客様名 = new System.Windows.Forms.TextBox();
			this.labお客様名 = new System.Windows.Forms.Label();
			this.lab利用部門 = new System.Windows.Forms.Label();
			this.tex利用部門 = new System.Windows.Forms.TextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lab日時 = new System.Windows.Forms.Label();
			this.labお届け先取込 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.texメッセージ = new System.Windows.Forms.TextBox();
			this.btn閉じる = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cBox先頭行無視 = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.lblシート総件数 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lbl取込件数 = new System.Windows.Forms.Label();
			this.lblエラー件数 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.texデータエラー = new System.Windows.Forms.TextBox();
			this.btn取込 = new System.Windows.Forms.Button();
			this.labファイル名 = new System.Windows.Forms.Label();
			this.texファイル名 = new IS2Client.共通テキストボックス();
			this.btn開く = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.ofdお届け先データ = new System.Windows.Forms.OpenFileDialog();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox2.SuspendLayout();
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
			this.lab利用部門.Location = new System.Drawing.Point(18, 8);
			this.lab利用部門.Name = "lab利用部門";
			this.lab利用部門.Size = new System.Drawing.Size(54, 14);
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
			this.panel7.Controls.Add(this.labお届け先取込);
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
			// labお届け先取込
			// 
			this.labお届け先取込.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.labお届け先取込.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labお届け先取込.ForeColor = System.Drawing.Color.White;
			this.labお届け先取込.Location = new System.Drawing.Point(12, 2);
			this.labお届け先取込.Name = "labお届け先取込";
			this.labお届け先取込.Size = new System.Drawing.Size(264, 24);
			this.labお届け先取込.TabIndex = 0;
			this.labお届け先取込.Text = "お届け先取込";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.PaleGreen;
			this.panel8.Controls.Add(this.texメッセージ);
			this.panel8.Controls.Add(this.btn閉じる);
			this.panel8.Location = new System.Drawing.Point(0, 516);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(792, 58);
			this.panel8.TabIndex = 14;
			// 
			// texメッセージ
			// 
			this.texメッセージ.BackColor = System.Drawing.Color.PaleGreen;
			this.texメッセージ.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texメッセージ.ForeColor = System.Drawing.Color.Red;
			this.texメッセージ.Location = new System.Drawing.Point(456, 4);
			this.texメッセージ.Multiline = true;
			this.texメッセージ.Name = "texメッセージ";
			this.texメッセージ.ReadOnly = true;
			this.texメッセージ.Size = new System.Drawing.Size(334, 50);
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
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cBox先頭行無視);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.lblシート総件数);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.lbl取込件数);
			this.groupBox2.Controls.Add(this.lblエラー件数);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.texデータエラー);
			this.groupBox2.Controls.Add(this.btn取込);
			this.groupBox2.Controls.Add(this.labファイル名);
			this.groupBox2.Controls.Add(this.texファイル名);
			this.groupBox2.Controls.Add(this.btn開く);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(22, 96);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(746, 370);
			this.groupBox2.TabIndex = 17;
			this.groupBox2.TabStop = false;
			// 
			// cBox先頭行無視
			// 
			this.cBox先頭行無視.ForeColor = System.Drawing.Color.LimeGreen;
			this.cBox先頭行無視.Location = new System.Drawing.Point(136, 62);
			this.cBox先頭行無視.Name = "cBox先頭行無視";
			this.cBox先頭行無視.Size = new System.Drawing.Size(196, 24);
			this.cBox先頭行無視.TabIndex = 2;
			this.cBox先頭行無視.Text = "先頭１行目は取り込まない";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label5.ForeColor = System.Drawing.Color.Red;
			this.label5.Location = new System.Drawing.Point(136, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(176, 16);
			this.label5.TabIndex = 57;
			this.label5.Text = "CSVファイルを選択してください。";
			// 
			// lblシート総件数
			// 
			this.lblシート総件数.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lblシート総件数.ForeColor = System.Drawing.Color.Black;
			this.lblシート総件数.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblシート総件数.Location = new System.Drawing.Point(232, 344);
			this.lblシート総件数.Name = "lblシート総件数";
			this.lblシート総件数.Size = new System.Drawing.Size(64, 14);
			this.lblシート総件数.TabIndex = 52;
			this.lblシート総件数.Text = "0件";
			this.lblシート総件数.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label4.ForeColor = System.Drawing.Color.LimeGreen;
			this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label4.Location = new System.Drawing.Point(136, 344);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 14);
			this.label4.TabIndex = 50;
			this.label4.Text = "総件数：";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbl取込件数
			// 
			this.lbl取込件数.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lbl取込件数.ForeColor = System.Drawing.Color.Black;
			this.lbl取込件数.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lbl取込件数.Location = new System.Drawing.Point(464, 344);
			this.lbl取込件数.Name = "lbl取込件数";
			this.lbl取込件数.Size = new System.Drawing.Size(48, 14);
			this.lbl取込件数.TabIndex = 49;
			this.lbl取込件数.Text = "0件";
			this.lbl取込件数.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblエラー件数
			// 
			this.lblエラー件数.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.lblエラー件数.ForeColor = System.Drawing.Color.Black;
			this.lblエラー件数.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblエラー件数.Location = new System.Drawing.Point(592, 344);
			this.lblエラー件数.Name = "lblエラー件数";
			this.lblエラー件数.Size = new System.Drawing.Size(48, 14);
			this.lblエラー件数.TabIndex = 48;
			this.lblエラー件数.Text = "0件";
			this.lblエラー件数.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label3.ForeColor = System.Drawing.Color.LimeGreen;
			this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label3.Location = new System.Drawing.Point(528, 344);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 14);
			this.label3.TabIndex = 47;
			this.label3.Text = "エラー件数：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label2.ForeColor = System.Drawing.Color.LimeGreen;
			this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label2.Location = new System.Drawing.Point(400, 344);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 14);
			this.label2.TabIndex = 46;
			this.label2.Text = "取込件数：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// texデータエラー
			// 
			this.texデータエラー.BackColor = System.Drawing.SystemColors.Window;
			this.texデータエラー.Location = new System.Drawing.Point(136, 94);
			this.texデータエラー.Multiline = true;
			this.texデータエラー.Name = "texデータエラー";
			this.texデータエラー.ReadOnly = true;
			this.texデータエラー.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.texデータエラー.Size = new System.Drawing.Size(504, 240);
			this.texデータエラー.TabIndex = 4;
			this.texデータエラー.Text = "";
			this.texデータエラー.WordWrap = false;
			// 
			// btn取込
			// 
			this.btn取込.BackColor = System.Drawing.Color.SteelBlue;
			this.btn取込.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn取込.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn取込.ForeColor = System.Drawing.Color.White;
			this.btn取込.Location = new System.Drawing.Point(650, 64);
			this.btn取込.Name = "btn取込";
			this.btn取込.Size = new System.Drawing.Size(65, 22);
			this.btn取込.TabIndex = 3;
			this.btn取込.TabStop = false;
			this.btn取込.Text = "取込";
			this.btn取込.Click += new System.EventHandler(this.btn取込_Click);
			// 
			// labファイル名
			// 
			this.labファイル名.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.labファイル名.ForeColor = System.Drawing.Color.LimeGreen;
			this.labファイル名.Location = new System.Drawing.Point(72, 40);
			this.labファイル名.Name = "labファイル名";
			this.labファイル名.Size = new System.Drawing.Size(60, 14);
			this.labファイル名.TabIndex = 15;
			this.labファイル名.Text = "ファイル名";
			// 
			// texファイル名
			// 
			this.texファイル名.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.texファイル名.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.texファイル名.Location = new System.Drawing.Point(136, 32);
			this.texファイル名.MaxLength = 100;
			this.texファイル名.Name = "texファイル名";
			this.texファイル名.Size = new System.Drawing.Size(504, 23);
			this.texファイル名.TabIndex = 0;
			this.texファイル名.Text = "";
			// 
			// btn開く
			// 
			this.btn開く.BackColor = System.Drawing.Color.SteelBlue;
			this.btn開く.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn開く.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.btn開く.ForeColor = System.Drawing.Color.White;
			this.btn開く.Location = new System.Drawing.Point(650, 32);
			this.btn開く.Name = "btn開く";
			this.btn開く.Size = new System.Drawing.Size(65, 22);
			this.btn開く.TabIndex = 1;
			this.btn開く.TabStop = false;
			this.btn開く.Text = "開く";
			this.btn開く.Click += new System.EventHandler(this.btn開く_Click);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(241)), ((System.Byte)(83)));
			this.label1.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 370);
			this.label1.TabIndex = 44;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ofdお届け先データ
			// 
			this.ofdお届け先データ.FileOk += new System.ComponentModel.CancelEventHandler(this.ofお届け先データ_FileOk);
			// 
			// お届け先取込
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(792, 574);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 607);
			this.Name = "お届け先取込";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "is-2 お届け先取込";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.エンター移動);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.エンターキャンセル);
			this.Load += new System.EventHandler(this.お届け先取込_Load);
			this.Closed += new System.EventHandler(this.お届け先取込_Closed);
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		private void お届け先取込_Load(object sender, System.EventArgs e)
		{
			// ヘッダー項目の設定
			texお客様名.Text = gs利用者名;
			tex利用部門.Text = gs部門ＣＤ + " " + gs部門名;

			// 日時の初期設定
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
			timer1.Interval = 10000;
			timer1.Enabled = true;

			// デフォルトのフォルダをデスクトップフォルダにする
			ofdお届け先データ.InitialDirectory
				= Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			ofdお届け先データ.Filter = "ファイル (*.csv;*.dat)|*.csv;*.dat|すべて(*.*)|*.*";
// ADD 2006.07.03 東都）山本 取込件数＆エラー件数の表示対応 START
			lbl取込件数.Text="0件";
			lblエラー件数.Text="0件";
// MOD 2007.01.17 FJCS) 桑田　荷主総件数をシート総件数に変更 START
//			lbl荷主総件数.Text="0件";
			lblシート総件数.Text="0件";
// MOD 2007.01.17 FJCS) 桑田　荷主総件数をシート総件数に変更 END
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
			lbl取込件数.Refresh();
			lblエラー件数.Refresh();
			lblシート総件数.Refresh();
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
// ADD 2006.07.03 東都）山本 取込件数＆エラー件数の表示対応 END
		}

		private void btn閉じる_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lab日時.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
		}

		private void btn開く_Click(object sender, System.EventArgs e)
		{
			ofdお届け先データ.ShowDialog();
		}

		private void ofお届け先データ_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			texファイル名.Text = ofdお届け先データ.FileName;
		}

		private void btn取込_Click(object sender, System.EventArgs e)
		{
			texデータエラー.Text = "";
			fileName = texファイル名.Text;
			if (fileName.Trim().Length == 0) return;
			if (!System.IO.File.Exists(fileName))
			{
				ビープ音();
				texメッセージ.Text = "指定したファイルが存在しません。";
				return;
			}
// MOD 2010.04.26 東都）高木 １００００件チェック機能の変更 START
// MOD 2010.11.25 東都）高木 GetAsyncKeyStateの訂正 START
//			bool bAltKey   = (GetAsyncKeyState(Keys.Menu    ) == 0) ? false : true;
//			bool bShiftKey = (GetAsyncKeyState(Keys.ShiftKey) == 0) ? false : true;
			bool bAltKey   = ((GetAsyncKeyState(Keys.Menu) & 0x8000) == 0) ? false : true;
			bool bShiftKey = ((GetAsyncKeyState(Keys.ShiftKey) & 0x8000) == 0) ? false : true;
// MOD 2010.11.25 東都）高木 GetAsyncKeyStateの訂正 END
			if(bAltKey && bShiftKey){
				;
			}else{
				int i既登録数 = 0;
				texメッセージ.Text = "既存データ件数チェック中．．．";
				try{
					string[] sRet = {""};
					if(sv_otodoke == null) sv_otodoke = new is2otodoke.Service1();
					sRet = sv_otodoke.Get_otodokeCount(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
					if(sRet[0].Length != 4){
						ビープ音();
						texメッセージ.Text = sRet[0];
						return;
					}
					i既登録数 = int.Parse(sRet[1]);
				}catch (System.Net.WebException){
					ビープ音();
					texメッセージ.Text = gs通信エラー;
					return;
				}catch (Exception ex){
					ビープ音();
					texメッセージ.Text = "通信エラー：" + ex.Message;
					return;
				}

				texメッセージ.Text = "データ件数チェック中．．．";
				int iDataCnt = 0;
				Cursor = System.Windows.Forms.Cursors.AppStarting;
				StreamReader sr = null;
				try{
					string sData = null;
					sr = new StreamReader(fileName, System.Text.Encoding.Default);
					sData = sr.ReadLine();
					if( cBox先頭行無視.Checked ){
						sData = sr.ReadLine();
					}
					while(sData != null){
						string[] sValue = sData.Replace("\"", "").Replace("\'","").Split(',');
						//１項目目が"荷受人コード"以外ならデータとみなす
						if(!sValue[0].Equals("荷受人コード")){
							iDataCnt++;
						}
						sData = sr.ReadLine();
					}
				}catch (Exception ex){
					ビープ音();
					MessageBox.Show(ex.Message,"お届け先取込",MessageBoxButtons.OK);
					return;
				}finally{
					texメッセージ.Text = "";
					Cursor = System.Windows.Forms.Cursors.Default;
					if(sr != null) sr.Close();
				}
				if(iDataCnt == 0){
//					texメッセージ.Text = "データ件数が０件です。";
					ビープ音();
					MessageBox.Show("データ件数が０件です。"
									, "お届け先取込", MessageBoxButtons.OK);
					return;
				}
				// １万件を超えれば、１０００件チェック
				if(i既登録数 >= 10000){
					if(iDataCnt > 1000){
//						texメッセージ.Text = "データ件数が１０００件を超えています。";
						ビープ音();
						MessageBox.Show("CSV取込可能最大件数（1000件）を超えています。\n"
										+ "数回に分けて取込を行って下さい。\n"
										+ "（既に10000件以上登録済の場合、1回あたりの取込可能件数は1000件です。\n"
										+ "現在登録件数："+i既登録数+"件）"
										, "お届け先取込", MessageBoxButtons.OK);
						return;
					}
				// １万件未満なら、１００００件チェック
				}else{
					if(iDataCnt > 10000){
//						texメッセージ.Text = "データ件数が１００００件を超えています。";
						ビープ音();
						MessageBox.Show("CSV取込可能最大件数（10000件）を超えています。\n"
										+ "数回に分けて取込を行って下さい。\n"
										, "お届け先取込", MessageBoxButtons.OK);
						return;
					}
				}
			}
// MOD 2010.04.26 東都）高木 １００００件チェック機能の変更 END
			texメッセージ.Text = "実行中．．．";

//			if(texファイル名.Text.Trim().EndsWith(".csv"))
				ＣＳＶファイル取込();
//			else
//				ＤＡＴファイル取込();
		}

// MOD 2006.07.10 東都）山本 ＣＳＶ取込件数ＭＡＸ３００００件（登録は１００件単位）変更 START
// 2006.10.26 FJCS)桑田 ＭＡＸ１００００件に変更 //
		private void ＣＳＶファイル取込()
		{
			StringBuilder sbErr = new StringBuilder();
// MOD 2010.04.26 東都）高木 １００００件チェック機能の変更 START
//// MOD 2010.03.12 東都）高木 １００００件チェック解除機能の追加 START
//			bool bAltKey   = (GetAsyncKeyState(Keys.Menu    ) == 0) ? false : true;
//			bool bShiftKey = (GetAsyncKeyState(Keys.ShiftKey) == 0) ? false : true;
//// MOD 2010.03.12 東都）高木 １００００件チェック解除機能の追加 END
// MOD 2010.04.26 東都）高木 １００００件チェック機能の変更 END

			Cursor = System.Windows.Forms.Cursors.AppStarting;
			StreamReader sr = null;
			try
			{
				sr = new StreamReader(fileName, System.Text.Encoding.Default);
			}
			catch (Exception ex)
			{
				texメッセージ.Text = "";
				Cursor = System.Windows.Forms.Cursors.Default;
				MessageBox.Show(ex.Message,"お届け先取込",MessageBoxButtons.OK);
				return;
			}
			String errfileName = fileName + ".err";
			StreamWriter sw    = null;
			int iLenErrMsg     = 0;
			int iLenErrMsgOld  = 0;
			i登録件数		= 0;
			iエラー件数		= 0;
// MOD 2007.01.17 FJCS) 桑田　荷主総件数をシート総件数に変更 START
//			i荷主総件数		= 0;
			iシート総件数		= 0;
// MOD 2007.01.17 FJCS) 桑田　荷主総件数をシート総件数に変更 END
			bool iErrorFlg   = true;
			bool iTxtMsgDsp  = true;

// MOD 2007.02.20 東都）高木 行数カウントの障害修正 START
//			int iCnt = 1;
			int iCnt = 0;
// MOD 2007.02.20 東都）高木 行数カウントの障害修正 END
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
			int iLineCnt = 0;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
			int iSetCnt = 0; 
			try
			{
				if (sv_otodoke == null)
				{
					sv_otodoke = new is2otodoke.Service1();
				}
				while(true)
				{
// MOD 2010.04.26 東都）高木 １００００件チェック機能の変更 START
//// MOD 2010.03.12 東都）高木 １００００件チェック解除機能の追加 START
//				if(bAltKey && bShiftKey){
//					;
//				}else{
//// MOD 2010.03.12 東都）高木 １００００件チェック解除機能の追加 END
//					String[] sList1 = {""};
//					sList1 = sv_otodoke.Get_ninushiCount(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
//					int DataCnt = int.Parse(sList1[1]);
//// DEL 2007.01.17 FJCS) 桑田　荷主総件数をシート総件数に変更 START
////					i荷主総件数 = DataCnt;
//// DEL 2007.01.17 FJCS) 桑田　荷主総件数をシート総件数に変更 END
//
//// MOD 2006.10.26 FJCS)桑田 ＭＡＸ１００００件に変更 SATRT
////					if( DataCnt >= 30000)
////					{
////						texメッセージ.Text = "登録件数が３００００件を超過します。";
//					if( DataCnt >= 10000)
//					{
//// MOD 2007.02.21 東都）高木 件数が－１になる START
////						texメッセージ.Text = "登録件数が１００００件を超過します。";
//						texメッセージ.Text = "登録件数が１００００件を超えています。";
//						iエラー件数++;
//						sbErr.Append("登録件数が１００００件を超えています\r\n");
//						iErrorFlg = false;
//// MOD 2007.02.21 東都）高木 件数が－１になる END
//// MOD 2006.10.26 FJCS)桑田 ＭＡＸ１００００件に変更 END
//						iTxtMsgDsp = false;
//						break;
//					}
//// MOD 2010.03.12 東都）高木 １００００件チェック解除機能の追加 START
//				}
//// MOD 2010.03.12 東都）高木 １００００件チェック解除機能の追加 END
// MOD 2010.04.26 東都）高木 １００００件チェック機能の変更 END

					string sData = sr.ReadLine();
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
//// ADD 2007.02.20 東都）高木 行数カウントの障害修正 START
//					iCnt++;
//// ADD 2007.02.20 東都）高木 行数カウントの障害修正 END
					if(sData != null)iCnt++;
					if(sData != null)iLineCnt++;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
 					if(sData == null)
						break;
// MOD 2009.04.06 東都）高木 先頭行無視機能の追加 START
// MOD 2010.04.26 東都）高木 １００００件チェック機能の変更 START
//					if( cBox先頭行無視.Checked ){
					if( iCnt == 1 && cBox先頭行無視.Checked ){
// MOD 2010.04.26 東都）高木 １００００件チェック機能の変更 END
						sData = sr.ReadLine();
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
						if(sData != null)iLineCnt++;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
						if(sData == null){
							break;
						}
					}
// MOD 2009.04.06 東都）高木 先頭行無視機能の追加 END
					ArrayList alKey = new ArrayList();
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
					string[] saData = new string[101];
					int[]    iaData = new int[101];
					int iサーバ送信行 = 1;
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
					while(sData != null)
					{

						byte[] bSjis = Encoding.GetEncoding("shift-jis").GetBytes(sData);

// MOD 2009.12.01 東都）高木 ['] を削除 START
//						string[] sValue = sData.Replace("\"", "").Split(',');
						string[] sValue = sData.Replace("\"", "").Replace("\'","").Split(',');
// MOD 2009.12.01 東都）高木 ['] を削除 END
						//１行目の１項目目が"荷受人コード"ならばヘッダとみなし読み飛ばします
						if (iCnt == 1 && sValue.Length > 0 && sValue[0].Equals("荷受人コード"))
						{
							sData = sr.ReadLine();
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
							if(sData != null)iLineCnt++;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
							continue;
						}
// MOD 2006.12.01 東都）高木 住所→郵便番号変換機能の削除 START
//// MOD 2006.07.14 東都）高木 住所→郵便番号変換機能の追加 START
////						string[] sKey   = new string[21];
//						string[] sKey   = new string[22];
//// MOD 2006.07.14 東都）高木 住所→郵便番号変換機能の追加 END
						string[] sKey   = new string[21];
// MOD 2006.12.01 東都）高木 住所→郵便番号変換機能の削除 END

// ADD 2008.04.11 ACT Vista対応 START
						string sErr = "";
						string sHData = sData;
						iErrorFlg = true;
						if (!漢字変換_CSV(ref sHData, ref sErr))
						{
							sbErr.Append(iLineCnt + "行目:Vista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							iLenErrMsg = sbErr.ToString().Trim().Length;
							iLenErrMsgOld = iLenErrMsg;
							sw = エラーファイル出力(sw, errfileName, sData);
							if(sw == null) return;
							sData = sr.ReadLine();
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
//							iCnt++;
							if(sData != null)iCnt++;
							if(sData != null)iLineCnt++;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
// ADD 2008.05.15 ACT Vista対応（エラー件数表示） START
							iエラー件数++;
// ADD 2008.05.15 ACT Vista対応（エラー件数表示） END
							iErrorFlg = false;
							continue;
						}
						bSjis = Encoding.GetEncoding("shift-jis").GetBytes(sHData);
// MOD 2009.12.01 東都）高木 ['] を削除 START
//						sValue = sHData.Replace("\"", "").Split(',');
						sValue = sHData.Replace("\"", "").Replace("\'","").Split(',');
// MOD 2009.12.01 東都）高木 ['] を削除 END
// ADD 2008.04.11 ACT Vista対応 END

						if ((sValue.Length < 10 || sValue.Length > 14) && bSjis.Length == 338)
						{
							sr.Close();
// ADD 2008.04.11 ACT Vista対応 START
							if(sw != null) sw.Close();
// ADD 2008.04.11 ACT Vista対応 END
// MOD 2008.04.23 東都）高木 固定長ファイルのエラーファイル出力対応 START
//							ＤＡＴファイル取込();
							ＤＡＴファイル取込(errfileName);
// MOD 2008.04.23 東都）高木 固定長ファイルのエラーファイル出力対応 END
							return;
						}
						iErrorFlg = true;
						if (sValue.Length < 10 || sValue.Length > 14)
						{
							sbErr.Append(iLineCnt + "行目:項目数または、データ長が違います\r\n");
							iLenErrMsg = sbErr.ToString().Trim().Length;
							iLenErrMsgOld = iLenErrMsg;
							sw = エラーファイル出力(sw, errfileName, sData);
							if(sw == null) return;
							sData = sr.ReadLine();
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
//							iCnt++;
							if(sData != null)iCnt++;
							if(sData != null)iLineCnt++;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
// ADD 2008.05.15 ACT Vista対応（エラー件数表示） START
							iエラー件数++;
// ADD 2008.05.15 ACT Vista対応（エラー件数表示） END
							iErrorFlg = false;
							continue;
						}
						sKey[0] = gs会員ＣＤ;
						sKey[1] = gs部門ＣＤ;
						sKey[20] = gs利用者ＣＤ;
						//荷受人コード
						sValue[0] = sValue[0].Trim();
						if (!必須チェック(sValue[0])) 
						{
							sbErr.Append(iLineCnt + "行目:荷受人コードは必須項目です\r\n");
							iErrorFlg = false;
						}
						if (!半角チェック(sValue[0])) 
						{
							sbErr.Append(iLineCnt + "行目:荷受人コードは半角文字で入力してください\r\n");
							iErrorFlg = false;
						}
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
						if(!記号チェック(sValue[0])){
							sbErr.Append(iLineCnt + "行目:荷受人コードに使用できない記号があります\r\n");
							iErrorFlg = false;
						}
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
						sKey[2] = sValue[0];
						if (sKey[2].Length > 15)
						{
							sbErr.Append(iLineCnt + "行目:荷受人コードは１５文字以内で入力してください\r\n");
							iErrorFlg = false;
						}
						//電話番号
						sKey[3] = " ";
						sKey[4] = " ";
						sKey[5] = " ";
						sValue[1] = sValue[1].Trim();
						if (!必須チェック(sValue[1]))
						{
							sbErr.Append(iLineCnt + "行目:電話番号は必須項目です\r\n");
							iErrorFlg = false;
						}
						if (!半角チェック(sValue[1])) 
						{
							sbErr.Append(iLineCnt + "行目:電話番号は半角文字で入力してください\r\n");
							iErrorFlg = false;
						}
						try
						{
							sValue[1] = sValue[1].Replace(" ", "");
							if (sValue[1].Length > 0)
							{
								//カッコ[()]がない時
								if (sValue[1].IndexOf("(") == -1 && sValue[1].LastIndexOf(")") == -1)
								{
									// ハイフン[-]が１つの時
									if (sValue[1].IndexOf("-") == sValue[1].LastIndexOf("-") && sValue[1].IndexOf("-") != -1)
									{
										sKey[3] = " ";
										sKey[4] = sValue[1].Substring(0, sValue[1].IndexOf("-"));
										sKey[5] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
										if (!数値チェック(sKey[4]) || !数値チェック(sKey[5]))
										{
											sbErr.Append(iLineCnt + "行目:電話番号は数値で入力してください\r\n");
											iErrorFlg = false;
										}
									}
									// ハイフン[-]が２つ以上の時
									else if (sValue[1].IndexOf("-") != sValue[1].LastIndexOf("-") && sValue[1].IndexOf("-") != -1)
									{
										sKey[3] = sValue[1].Substring(0, sValue[1].IndexOf("-"));
										sKey[4] = sValue[1].Substring(sValue[1].IndexOf("-") + 1, sValue[1].LastIndexOf("-") - sValue[1].IndexOf("-") - 1);
										sKey[5] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
										if (!数値チェック(sKey[3]) || !数値チェック(sKey[4]) || !数値チェック(sKey[5]))
										{
											sbErr.Append(iLineCnt + "行目:電話番号は数値で入力してください\r\n");
											iErrorFlg = false;
										}
									}
// MOD 2010.03.30 東都）高木 電話番号形式追加対応 START
									// ハイフンが無い時
									// 電話番号が９桁の時
									else if(sValue[1].Length == 9){
										if (sValue[1].Substring(0,1).Equals("3") || sValue[1].Substring(0,1).Equals("6")){
											//東京、大阪は 1-4-4で編集
											sKey[3] = sValue[1].Substring(0,1);
											sKey[4] = sValue[1].Substring(1,4);
											sKey[5] = sValue[1].Substring(5,4);
										}else{
											//それ以外は3-2-4で編集
											sKey[3] = sValue[1].Substring(0,3);
											sKey[4] = sValue[1].Substring(3,2);
											sKey[5] = sValue[1].Substring(5,4);
										}
										if(!数値チェック(sKey[3]) || !数値チェック(sKey[4]) || !数値チェック(sKey[5])){
											sbErr.Append(iLineCnt + "行目:電話番号は数値で入力してください\r\n");
											iErrorFlg = false;
										}
									// 電話番号が１０桁の時
									}else if(sValue[1].Length == 10){
										if(sValue[1].Substring(0,2).Equals("03") || sValue[1].Substring(0,2).Equals("06")){
											//東京、大阪は 2-4-4で編集
											sKey[3] = sValue[1].Substring(0,2);
											sKey[4] = sValue[1].Substring(2,4);
											sKey[5] = sValue[1].Substring(6,4);
										}else{
											//それ以外は4-2-4で編集
											sKey[3] = sValue[1].Substring(0,4);
											sKey[4] = sValue[1].Substring(4,2);
											sKey[5] = sValue[1].Substring(6,4);
										}
										if(!数値チェック(sKey[3]) || !数値チェック(sKey[4]) || !数値チェック(sKey[5])){
											sbErr.Append(iLineCnt + "行目:電話番号は数値で入力してください\r\n");
											iErrorFlg = false;
										}
									// 電話番号が１１桁の時
									}else if(sValue[1].Length == 11){
// MOD 2010.03.30 東都）高木 携帯電話対応 START
										if(sValue[1].Substring(0,3).Equals("090")
										 || sValue[1].Substring(0,3).Equals("080")
										 || sValue[1].Substring(0,3).Equals("070")
										 || sValue[1].Substring(0,3).Equals("050")){
											//携帯電話は 3-4-4で編集
											sKey[3] = sValue[1].Substring(0,3);
											sKey[4] = sValue[1].Substring(3,4);
											sKey[5] = sValue[1].Substring(7,4);
										}else{
// MOD 2010.03.30 東都）高木 携帯電話対応 END
											//4-3-4で編集
											sKey[3] = sValue[1].Substring(0,4);
											sKey[4] = sValue[1].Substring(4,3);
											sKey[5] = sValue[1].Substring(7,4);
											if(!数値チェック(sKey[3]) || !数値チェック(sKey[4]) || !数値チェック(sKey[5])){
												sbErr.Append(iLineCnt + "行目:電話番号は数値で入力してください\r\n");
												iErrorFlg = false;
											}
// MOD 2010.03.30 東都）高木 携帯電話対応 START
										}
// MOD 2010.03.30 東都）高木 携帯電話対応 END
									// 電話番号が１２桁の時
									}else if(sValue[1].Length == 12){
										//4-4-4で編集
										sKey[3] = sValue[1].Substring(0,4);
										sKey[4] = sValue[1].Substring(4,4);
										sKey[5] = sValue[1].Substring(8,4);
										if(!数値チェック(sKey[3]) || !数値チェック(sKey[4]) || !数値チェック(sKey[5])){
											sbErr.Append(iLineCnt + "行目:電話番号は数値で入力してください\r\n");
											iErrorFlg = false;
										}
									}
// MOD 2010.03.30 東都）高木 電話番号形式追加対応 END
									else
									{
										sbErr.Append(iLineCnt + "行目:電話番号の形式に誤りがあります\r\n");
										iErrorFlg = false;
									}
								}
								//カッコ[()]がある時
								else if (sValue[1].IndexOf("(") != -1 && sValue[1].LastIndexOf(")") != -1)
								{
									sKey[3] = sValue[1].Substring(sValue[1].IndexOf("(") + 1, sValue[1].LastIndexOf(")") - sValue[1].IndexOf("(") - 1);
									sKey[4] = sValue[1].Substring(sValue[1].IndexOf(")") + 1, sValue[1].LastIndexOf("-") - sValue[1].IndexOf(")") - 1);
									sKey[5] = sValue[1].Substring(sValue[1].LastIndexOf("-") + 1);
									if (!数値チェック(sKey[3]) || !数値チェック(sKey[4]) || !数値チェック(sKey[5]))
									{
										sbErr.Append(iLineCnt + "行目:電話番号は数値で入力してください\r\n");
										iErrorFlg = false;
									}							
								}
								else
								{
									sbErr.Append(iLineCnt + "行目:電話番号の形式に誤りがあります\r\n");
									iErrorFlg = false;
								}
								if (sKey[3].Length > 6)	
								{
									sbErr.Append(iLineCnt + "行目:電話番号(市外)は６文字以内で入力してください\r\n");
									iErrorFlg = false;
								}
								if (sKey[4].Length > 4)	
								{
									sbErr.Append(iLineCnt + "行目:電話番号(市内)は４文字以内で入力してください\r\n");
									iErrorFlg = false;
								}
								if (sKey[5].Length > 4)							
								{
									sbErr.Append(iLineCnt + "行目:電話番号(番号)は４文字以内で入力してください\r\n");
									iErrorFlg = false;
								}
							}
						}
						catch
						{
							sbErr.Append(iLineCnt + "行目:電話番号の形式に誤りがあります\r\n");
							iErrorFlg = false;
						}
						//ＦＡＸ番号
						sKey[6] = " ";
						sKey[7] = " ";
						sKey[8] = " ";
						sValue[2] = sValue[2].Trim();
						try
						{
							sValue[2] = sValue[2].Replace(" ", "");
							if (sValue[2].Trim().Length != 0)
							{
								if (!半角チェック(sValue[2])) 
								{
									sbErr.Append(iLineCnt + "行目:ＦＡＸ番号は半角文字で入力してください\r\n");
									iErrorFlg = false;
								}
								if (sValue[2].IndexOf("(") == -1 && sValue[2].LastIndexOf(")") == -1)
								{
									if (sValue[2].IndexOf("-") == sValue[2].LastIndexOf("-") && sValue[2].IndexOf("-") != -1)
									{
										sKey[6] = " ";
										sKey[7] = sValue[2].Substring(0, sValue[2].IndexOf("-"));
										sKey[8] = sValue[2].Substring(sValue[2].LastIndexOf("-") + 1);
										if (!数値チェック(sKey[7]) || !数値チェック(sKey[8]))
										{
											sbErr.Append(iLineCnt + "行目:ＦＡＸ番号は数値で入力してください\r\n");
											iErrorFlg = false;
										}
									}
									else if (sValue[2].IndexOf("-") != sValue[2].LastIndexOf("-") && sValue[2].IndexOf("-") != -1)
									{
										sKey[6] = sValue[2].Substring(0, sValue[2].IndexOf("-"));
										sKey[7] = sValue[2].Substring(sValue[2].IndexOf("-") + 1, sValue[2].LastIndexOf("-") - sValue[2].IndexOf("-") - 1);
										sKey[8] = sValue[2].Substring(sValue[2].LastIndexOf("-") + 1);
										if (!数値チェック(sKey[6]) || !数値チェック(sKey[7]) || !数値チェック(sKey[8]))	
										{
											sbErr.Append(iLineCnt + "行目:ＦＡＸ番号は数値で入力してください\r\n");
											iErrorFlg = false;
										}
									}
									else
									{
										sbErr.Append(iLineCnt + "行目:ＦＡＸ番号の形式に誤りがあります\r\n");
										iErrorFlg = false;
									}
								}
								else if (sValue[2].IndexOf("(") != -1 && sValue[2].LastIndexOf(")") != -1)
								{
									sKey[6] = sValue[2].Substring(sValue[2].IndexOf("(") + 1, sValue[2].LastIndexOf(")") - sValue[2].IndexOf("(") - 1);
									sKey[7] = sValue[2].Substring(sValue[2].IndexOf(")") + 1, sValue[2].LastIndexOf("-") - sValue[2].IndexOf(")") - 1);
									sKey[8] = sValue[2].Substring(sValue[2].LastIndexOf("-") + 1);
									if (!数値チェック(sKey[6]) || !数値チェック(sKey[7]) || !数値チェック(sKey[8]))	
									{
										sbErr.Append(iLineCnt + "行目:ＦＡＸ番号は数値で入力してください\r\n");
										iErrorFlg = false;
									}
								}
								else
								{
									sbErr.Append(iLineCnt + "行目:ＦＡＸ番号の形式に誤りがあります\r\n");
									iErrorFlg = false;
								}
							}
							if (sKey[6].Length > 6)
							{
								sbErr.Append(iLineCnt + "行目:ＦＡＸ番号(市外)は６文字以内で入力してください\r\n");
								iErrorFlg = false;
							}
							if (sKey[7].Length > 4)
							{
								sbErr.Append(iLineCnt + "行目:ＦＡＸ番号(市内)は４文字以内で入力してください\r\n");
								iErrorFlg = false;
							}
							if (sKey[8].Length > 4)
							{
								sbErr.Append(iLineCnt + "行目:ＦＡＸ番号(番号)は４文字以内で入力してください\r\n");
								iErrorFlg = false;
							}
						}
						catch
						{
							sbErr.Append(iLineCnt + "行目:ＦＡＸ番号の形式に誤りがあります\r\n");
							iErrorFlg = false;
						}
						//住所１
						if (!必須チェック(sValue[3]))
						{ 
							sbErr.Append(iLineCnt + "行目:住所１は必須項目です\r\n");
							iErrorFlg = false;
						}
						sKey[9] = Microsoft.VisualBasic.Strings.StrConv(sValue[3], Microsoft.VisualBasic.VbStrConv.Wide, 0);
						if (sKey[9].Length > 20) sKey[9] = sKey[9].Substring(0, 20);
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
						if(gsオプション[18].Equals("1")){
							sKey[9] = sKey[9].TrimEnd();
						}else{
							sKey[9] = sKey[9].Trim();
						}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
						//住所２
						if (sValue[4].Trim().Length != 0)
						{
							sKey[10] = Microsoft.VisualBasic.Strings.StrConv(sValue[4], Microsoft.VisualBasic.VbStrConv.Wide, 0);
							if (sKey[10].Length > 20) sKey[10] = sKey[10].Substring(0, 20);
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
							if(gsオプション[18].Equals("1")){
								sKey[10] = sKey[10].TrimEnd();
							}else{
								sKey[10] = sKey[10].Trim();
							}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
						}
						if (sKey[10] == null || sKey[10].Length == 0) sKey[10] = " ";
						//住所３
						if (sValue[5].Trim().Length != 0)
						{
							sKey[11] = Microsoft.VisualBasic.Strings.StrConv(sValue[5], Microsoft.VisualBasic.VbStrConv.Wide, 0);
							if (sKey[11].Length > 20) sKey[11] = sKey[11].Substring(0, 20);
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
							if(gsオプション[18].Equals("1")){
								sKey[11] = sKey[11].TrimEnd();
							}else{
								sKey[11] = sKey[11].Trim();
							}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
						}
						if (sKey[11] == null || sKey[11].Length == 0) sKey[11] = " ";
						//名前１
						if (!必須チェック(sValue[6])) 
						{
							sbErr.Append(iLineCnt + "行目:名前１は必須項目です\r\n");
							iErrorFlg = false;
						}
						sKey[12] = Microsoft.VisualBasic.Strings.StrConv(sValue[6], Microsoft.VisualBasic.VbStrConv.Wide, 0);
						if (sKey[12].Length > 20) sKey[12] = sKey[12].Substring(0, 20);
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
						if(gsオプション[18].Equals("1")){
							sKey[12] = sKey[12].TrimEnd();
						}else{
							sKey[12] = sKey[12].Trim();
						}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
						sKey[13] = " ";
						//名前２
						if (sValue[7].Trim().Length != 0)
						{
							sKey[13] = Microsoft.VisualBasic.Strings.StrConv(sValue[7], Microsoft.VisualBasic.VbStrConv.Wide, 0);
							if (sKey[13].Length > 20) sKey[13] = sKey[13].Substring(0, 20);
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
							if(gsオプション[18].Equals("1")){
								sKey[13] = sKey[13].TrimEnd();
							}else{
								sKey[13] = sKey[13].Trim();
							}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
						}
						if (sKey[13] == null || sKey[13].Length == 0) sKey[13] = " ";
						sKey[14] = " ";
						//名前３ 未使用
						if (sValue[8].Trim().Length != 0)
						{
							sKey[14] = Microsoft.VisualBasic.Strings.StrConv(sValue[8], Microsoft.VisualBasic.VbStrConv.Wide, 0);
							if (sKey[14].Length > 20) sKey[14] = sKey[14].Substring(0, 20);
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
							if(gsオプション[18].Equals("1")){
								sKey[14] = sKey[14].TrimEnd();
							}else{
								sKey[14] = sKey[14].Trim();
							}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
						}
						if (sKey[14] == null || sKey[14].Length == 0) sKey[14] = " ";
						sKey[15] = " ";
						//郵便番号
						sValue[9] = sValue[9].Trim();
						sKey[15] = sValue[9].Replace("-", "");
// DEL 2006.12.01 東都）高木 住所→郵便番号変換機能の削除 START
//// ADD 2006.07.14 東都）高木 住所→郵便番号変換機能の追加 START
//						sKey[21] = " ";
//						//郵便番号が未入力の場合
//						if(sKey[15].Length == 0){
//							string[] sRet = new string[6];
//							sRet = 郵便番号取得(sKey[9].Trim() + sKey[10].Trim() + sKey[11].Trim());
//							if(sRet[0].Length == 4)
//							{
//								//郵便番号が存在し、店所ＣＤが割当てられている時
//								//if(sRet[1].Length == 7 && sRet[3].Trim().Length > 0)
//								if(sRet[1].Length == 7)
//								{
//									sKey[15] = sRet[1];	//郵便番号
//									sKey[21] = sRet[2];	//住所ＣＤ８桁
//									sKey[19] = sRet[3]; //店所ＣＤ
//									//sRet[4]; //都道府県ＣＤ
//									//sRet[5]; //市区町村ＣＤ
//								}
//							}
////							else if(sRet[0].Length > 4)
////							{ 
////								sbErr.Append(iLineCnt + "行目:" + sRet[0] +"\r\n");
////								iErrorFlg = false;
////							}
//						}
//// ADD 2006.07.14 東都）高木 住所→郵便番号変換機能の追加 END
// DEL 2006.12.01 東都）高木 住所→郵便番号変換機能の削除 END
						if (!必須チェック(sKey[15]))
						{
							sbErr.Append(iLineCnt + "行目:郵便番号は必須項目です\r\n");
							iErrorFlg = false;
						}
						if (sKey[15].Length > 0)
						{
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
//							if (!数値チェック(sKey[15]))
//							{
//								sbErr.Append(iLineCnt + "行目:郵便番号は数値で入力してください\r\n");
//								iErrorFlg = false;
//							}
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
							if (sKey[15].Length > 7) 
							{
								sbErr.Append(iLineCnt + "行目:郵便番号は７文字以内で入力してください\r\n");
								iErrorFlg = false;
							}
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
//							if (数値チェック(sKey[15]) && sKey[15].Length <= 7)
//							{
//								//郵便番号存在チェック
//								string[] sRet = {""};
//								try
//								{
//									if(sv_address == null) sv_address = new is2address.Service1();
//									sRet = sv_address.Get_byPostcode2(gsaユーザ,sKey[15]);
//								}
//								catch (System.Net.WebException)
//								{
//									sbErr.Append(iLineCnt + "行目:"+ gs通信エラー +"\r\n");
//									iErrorFlg = false;
//								}
//								catch (Exception ex)
//								{
//									sbErr.Append(iLineCnt + "行目:通信エラー：" + ex.Message +"\r\n");
//									iErrorFlg = false;
//								}
//
//								if(sRet[0].Length != 4)
//								{
//									sbErr.Append(iLineCnt + "行目:郵便番号が存在しません\r\n");
//									iErrorFlg = false;
//								}
//							}
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
						}
						if (sKey[15].Length == 0) sKey[15] = " ";
						sKey[16] = " ";
						if (sValue.Length > 10)
						{
							//カナ略称
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
//							sValue[10] = sValue[10].Trim();
//							if (sValue[10].Trim().Length != 0)
							if(gsオプション[18].Equals("1")){
								sValue[10] = sValue[10].TrimEnd();
							}else{
								sValue[10] = sValue[10].Trim();
							}
							if (sValue[10].Length != 0)
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END
							{
								if (!半角チェック(sValue[10])) 
								{
									sbErr.Append(iLineCnt + "行目:カナ略称は半角文字で入力してください\r\n");
									iErrorFlg = false;
								}
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
//								if(!記号チェック(sValue[10])){
//									sbErr.Append(iLineCnt + "行目:カナ略称に使用できない記号があります\r\n");
//									iErrorFlg = false;
//								}
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
							}
							sKey[16] = sValue[10];
							if (sKey[16].Length > 10) 
							{
								sbErr.Append(iLineCnt + "行目:カナ略称は１０文字以内で入力してください\r\n");
								iErrorFlg = false;
							}
							if (sKey[16].Length == 0) sKey[16] = " ";
						}
						sKey[17] = " ";
						if (sValue.Length > 11)
						{
							//一斉出荷区分 未使用
							sValue[11] = sValue[11].Trim();
							if (!半角チェック(sValue[11])) 
							{
								sbErr.Append(iLineCnt + "行目:一斉出荷区分は半角文字で入力してください\r\n");
								iErrorFlg = false;
							}
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
//							if(!記号チェック(sValue[11])){
//								sbErr.Append(iLineCnt + "行目:一斉出荷区分に使用できない記号があります\r\n");
//								iErrorFlg = false;
//							}
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
							sKey[17] = sValue[11];
							if (sKey[17].Length > 2) 
							{
								sbErr.Append(iLineCnt + "行目:一斉出荷区分は２文字以内で入力してください\r\n");
								iErrorFlg = false;
							}
							if (sKey[17].Length == 0) sKey[17] = " ";
						}
						sKey[18] = " ";
						if (sValue.Length > 12)
						{
							//特殊計 未使用
							sValue[12] = sValue[12].Trim();
							if (!半角チェック(sValue[12])) 
							{
								sbErr.Append(iLineCnt + "行目:特殊計は半角文字で入力してください\r\n");
								iErrorFlg = false;
							}
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
//							if(!記号チェック(sValue[12])){
//								sbErr.Append(iLineCnt + "行目:特殊計に使用できない記号があります\r\n");
//								iErrorFlg = false;
//							}
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
							sKey[18] = sValue[12];
							if (sKey[18].Length > 5) 
							{
								sbErr.Append(iLineCnt + "行目:特殊計は５文字以内で入力してください\r\n");
								iErrorFlg = false;
							}
							if (sKey[18].Length == 0) sKey[18] = " ";
						}
						sKey[19] = " ";
						if (sValue.Length > 13)
						{
							//着店コード
							sKey[19] = sValue[13];
							if (sKey[19].Length == 0) sKey[19] = " ";
						}

						//
						//チェックが終了した時にエラーメッセージが増加していれば
						//その行は、再度編集対象になるのでエラーファイルに出力する
						//（iErrorFlgは？、おそらく山本殿により追加されたフラグで
						//　大量に追加する為、コメントを省略したはず...）
						//
						iLenErrMsg = sbErr.ToString().Trim().Length;
						if(iLenErrMsg != iLenErrMsgOld)
						{
							iLenErrMsgOld = iLenErrMsg;
							sw = エラーファイル出力(sw, errfileName, sData);
							if(sw == null) return;
						}
						else
						{
							StringBuilder sbKeyData = new StringBuilder();
							for (int j = 0; j < sKey.Length; j++)
							{
								sbKeyData.Append(sKey[j] + ",");
							}
							alKey.Add(sbKeyData.ToString().Substring(0, sbKeyData.ToString().Length - 1));
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
							saData[iサーバ送信行] = sData;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
//							iaData[iサーバ送信行] = iCnt;
							iaData[iサーバ送信行] = iLineCnt;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
							iサーバ送信行++;
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
						}

						if(iErrorFlg == false)
						{
							iエラー件数++;
							lblエラー件数.Text=iエラー件数.ToString()+"件";
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
							lblエラー件数.Refresh();
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
							iErrorFlg = true;
						}
						else
						{
							iSetCnt++;
// ADD 2007.02.20 東都）高木 行数カウントの障害修正 START
							// １００件ごとに登録
							if(iSetCnt >= 100)
								break;
// ADD 2007.02.20 東都）高木 行数カウントの障害修正 END
						}
// DEL 2007.02.20 東都）高木 行数カウントの障害修正 START
//						if(iSetCnt >= 100)
//							break;
// DEL 2007.02.20 東都）高木 行数カウントの障害修正 END
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
						iシート総件数 = iCnt;
						lblシート総件数.Text=iシート総件数.ToString()+"件";
						lblシート総件数.Refresh();
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
						sData = sr.ReadLine();
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
//						iCnt++;
						if(sData != null)iCnt++;
						if(sData != null)iLineCnt++;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
					}

					if (alKey.Count > 0)
					{
						string[] sList = new string[alKey.Count];
						IEnumerator enumList = alKey.GetEnumerator();
						int i = 0;
						while(enumList.MoveNext())
						{
							sList[i] = enumList.Current.ToString();
							i++;
						}
						string[] sRet = {""};
						try
						{
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
//							sRet = sv_otodoke.Ins_uploadData(gsaユーザ,sList);
// MOD 2015.05.13 BEVAS) 前田　王子会員様の郵便番号存在チェックを王子マスタで行う START
							if (gs会員ＣＤ.Substring(0,1) != "J")
							{
// MOD 2015.05.13 BEVAS) 前田　王子会員様の郵便番号存在チェックを王子マスタで行う END
							sRet = sv_otodoke.Ins_uploadData2(gsaユーザ,sList);
// MOD 2015.05.13 BEVAS) 前田　王子会員様の郵便番号存在チェックを王子マスタで行う START
							} 
							else 
							{
								sRet = sv_oji.otodoke_Ins_uploadData2(gsaユーザ,sList);
							}
// MOD 2015.05.13 BEVAS) 前田　王子会員様の郵便番号存在チェックを王子マスタで行う END

// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
// MOD 2009.12.01 東都）高木 データ登録時のエラーチェックを追加 START
							//登録時にエラーが発生した場合終了する
							if(sRet[0].Length > 0)
							{
								texメッセージ.Text = sRet[0];
								iTxtMsgDsp  = false;
								break;
							}
// MOD 2009.12.01 東都）高木 データ登録時のエラーチェックを追加 END
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
							for(int iLine2 = 1; iLine2 < sRet.Length; iLine2++){
								if(sRet[iLine2].Length > 0){
									iエラー件数++;
									iSetCnt--;
									sbErr.Append(iaData[iLine2] + "行目:郵便番号["+sRet[iLine2]+"]が存在しません\r\n");
									iLenErrMsg = sbErr.ToString().Trim().Length;
									if(iLenErrMsg != iLenErrMsgOld){
										iLenErrMsgOld = iLenErrMsg;
									}
									sw = エラーファイル出力(sw, errfileName, saData[iLine2]);
									if(sw == null) return;
								}
							}
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
						}
						catch (System.Net.WebException)
						{
							sRet[0] = gs通信エラー;
							texメッセージ.Text = sRet[0];
							iTxtMsgDsp = false;
							break;
						}
						catch (Exception ex)
						{
							sRet[0] = "通信エラー：" + ex.Message;
							texメッセージ.Text = sRet[0];
							iTxtMsgDsp = false;
							break;
						}
						i登録件数 += iSetCnt;
						lbl取込件数.Text=i登録件数.ToString()+"件";
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
						lbl取込件数.Refresh();

						lblエラー件数.Text=iエラー件数.ToString()+"件";
						lblエラー件数.Refresh();
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
// ADD 2007.02.20 東都）高木 行数カウントの障害修正 START
						alKey = null;
						enumList = null;
// ADD 2007.02.20 東都）高木 行数カウントの障害修正 END
						iSetCnt = 0;
					}
// ADD 2007.02.20 東都）高木 行数カウントの障害修正 START
 					if(sData == null){
						break;
					}
// ADD 2007.02.20 東都）高木 行数カウントの障害修正 END
				}
			}
			catch (Exception ex)
			{
				sbErr.Append(ex.Message);
			}
			finally
			{
				sr.Close();
				if(sw != null) sw.Close();
			}
			texデータエラー.Text = sbErr.ToString();
			Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
//			int Wrkcnt = i登録件数;
//			lbl取込件数.Text=Wrkcnt.ToString()+"件";
			lbl取込件数.Text=i登録件数.ToString()+"件";
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
			lblエラー件数.Text=iエラー件数.ToString()+"件";
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
//// MOD 2007.01.17 FJCS) 桑田　荷主総件数をシート総件数に変更 START
////			lbl荷主総件数.Text=i荷主総件数.ToString()+"件";
//			iシート総件数 = iCnt - 1;
//// ADD 2007.02.21 東都）高木 件数が－１になる START
			iシート総件数 = iCnt;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
			if(iシート総件数 < 0) iシート総件数 = 0;
// ADD 2007.02.21 東都）高木 件数が－１になる END
			lblシート総件数.Text=iシート総件数.ToString()+"件";
// MOD 2007.01.17 FJCS) 桑田　荷主総件数をシート総件数に変更 END
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
			lbl取込件数.Refresh();
			lblエラー件数.Refresh();
			lblシート総件数.Refresh();
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
			if(iTxtMsgDsp == true)
				texメッセージ.Text = "";
// MOD 2007.02.21 東都）高木 エラー時の完了メッセージの変更 START
//			MessageBox.Show("取込処理が完了しました。","お届け先取込",MessageBoxButtons.OK);
			if(iエラー件数 == 0 && iシート総件数 == 0){
				MessageBox.Show("取込データが存在しませんでした。"
								,"お届け先取込",MessageBoxButtons.OK);
			}else{
				if(i登録件数 == 0){
					MessageBox.Show("エラーが発生した為、取り込めませんでした。"
									,"お届け先取込",MessageBoxButtons.OK);
				}else if(iエラー件数 > 0 || iシート総件数 != i登録件数){
					MessageBox.Show("エラーが発生した為、取り込めなかったデータがあります。"
									,"お届け先取込",MessageBoxButtons.OK);
				}else{
					MessageBox.Show("取込処理が完了しました。"
									,"お届け先取込",MessageBoxButtons.OK);
				}
			}
// MOD 2007.02.21 東都）高木 エラー時の完了メッセージの変更 END
		}
// MOD 2006.07.10 東都）山本 ＣＳＶ取込件数ＭＡＸ３００００件（登録は１００件単位）変更 END

// ADD 2006.05.17 東都）高木 ＣＳＶ取込のエラーファイル出力 START
		private StreamWriter エラーファイル出力(StreamWriter sw, String errfileName, String sData)
		{
			if(sw == null){
				try
				{
					sw = new StreamWriter(errfileName, false, System.Text.Encoding.Default);
				}
				catch (Exception ex)
				{
					texメッセージ.Text = "";
					Cursor = System.Windows.Forms.Cursors.Default;
					MessageBox.Show(ex.Message,"お届け先取込",MessageBoxButtons.OK);
					return null;
				}
			}
			sw.WriteLine(sData);
			return sw;
		}
// ADD 2006.05.17 東都）高木 ＣＳＶ取込のエラーファイル出力 END

// MOD 2006.07.10 東都）山本 ＣＳＶ取込件数ＭＡＸ３００００件（登録は１００件単位）変更 START
// 2006.10.26 FJCS)桑田 ＭＡＸ１００００件に変更 //
// MOD 2008.04.23 東都）高木 固定長ファイルのエラーファイル出力対応 START
//		private void ＤＡＴファイル取込()
//		{
		private void ＤＡＴファイル取込(String errfileName)
		{
			StreamWriter sw    = null;
			int iLenErrMsg     = 0;
			int iLenErrMsgOld  = 0;
// MOD 2008.04.23 東都）高木 固定長ファイルのエラーファイル出力対応 END
			StringBuilder sbErr = new StringBuilder();
// MOD 2010.04.26 東都）高木 １００００件チェック機能の変更 START
//// MOD 2010.03.12 東都）高木 １００００件チェック解除機能の追加 START
//			bool bAltKey   = (GetAsyncKeyState(Keys.Menu    ) == 0) ? false : true;
//			bool bShiftKey = (GetAsyncKeyState(Keys.ShiftKey) == 0) ? false : true;
//// MOD 2010.03.12 東都）高木 １００００件チェック解除機能の追加 END
// MOD 2010.04.26 東都）高木 １００００件チェック機能の変更 END

			Cursor = System.Windows.Forms.Cursors.AppStarting;
			StreamReader sr = new StreamReader(fileName, System.Text.Encoding.GetEncoding("shift-jis"));
			iエラー件数		= 0;
			bool iErrorFlg   = true;
			bool iTxtMsgDsp  = true;

// MOD 2007.02.20 東都）高木 行数カウントの障害修正 START
//			int iCnt = 1;
			int iCnt = 0;
// MOD 2007.02.20 東都）高木 行数カウントの障害修正 END
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
			int iLineCnt = 0;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
			int iSetCnt = 0; 
			try
			{
				if (sv_otodoke == null)
				{
					sv_otodoke = new is2otodoke.Service1();
				}
				while(true)
				{
// MOD 2010.04.26 東都）高木 １００００件チェック機能の変更 START
//// MOD 2010.03.12 東都）高木 １００００件チェック解除機能の追加 START
//				if(bAltKey && bShiftKey){
//					;
//				}else{
//// MOD 2010.03.12 東都）高木 １００００件チェック解除機能の追加 END
//					String[] sList1 = {""};
//					sList1 = sv_otodoke.Get_ninushiCount(gsaユーザ,gs会員ＣＤ,gs部門ＣＤ);
//					int DataCnt = int.Parse(sList1[1]);
//// DEL 2007.01.17 FJCS) 桑田　荷主総件数をシート総件数に変更 START
////					i荷主総件数 = DataCnt;
//// DEL 2007.01.17 FJCS) 桑田　荷主総件数をシート総件数に変更 END
//// MOD 2006.10.26 FJCS)桑田 ＭＡＸ１００００件に変更 SATRT
////					if( DataCnt >= 30000)
////					{
////						texメッセージ.Text = "登録件数が３００００件を超過します。";
//					if( DataCnt >= 10000)
//					{
//// MOD 2007.02.21 東都）高木 件数が－１になる START
////						texメッセージ.Text = "登録件数が１００００件を超過します。";
//						texメッセージ.Text = "登録件数が１００００件を超えています。";
//						iエラー件数++;
//						sbErr.Append("登録件数が１００００件を超えています\r\n");
//						iErrorFlg = false;
//// MOD 2007.02.21 東都）高木 件数が－１になる END
//// MOD 2006.10.26 FJCS)桑田 ＭＡＸ１００００件に変更 END
//						iTxtMsgDsp  = false;
//						break;
//					}
//// MOD 2010.03.12 東都）高木 １００００件チェック解除機能の追加 START
//				}
//// MOD 2010.03.12 東都）高木 １００００件チェック解除機能の追加 END
// MOD 2010.04.26 東都）高木 １００００件チェック機能の変更 END

					string sData = sr.ReadLine();
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
//// ADD 2007.02.20 東都）高木 行数カウントの障害修正 START
//					iCnt++;
//// ADD 2007.02.20 東都）高木 行数カウントの障害修正 END
					if(sData != null)iCnt++;
					if(sData != null)iLineCnt++;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
					if(sData == null)
						break;
// MOD 2009.04.06 東都）高木 先頭行無視機能の追加 START
// MOD 2010.04.26 東都）高木 １００００件チェック機能の変更 START
//					if( cBox先頭行無視.Checked ){
					if( iCnt == 1 && cBox先頭行無視.Checked ){
// MOD 2010.04.26 東都）高木 １００００件チェック機能の変更 END
						sData = sr.ReadLine();
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
						if(sData != null)iLineCnt++;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
						if(sData == null){
							break;
						}
					}
// MOD 2009.04.06 東都）高木 先頭行無視機能の追加 END
					ArrayList alKey = new ArrayList();
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
					string[] saData = new string[101];
					int[]    iaData = new int[101];
					int iサーバ送信行 = 1;
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END

					System.Text.Encoding enc = Encoding.GetEncoding("shift-jis");
					string[] sValue = new string[22];
					byte[] bSjis;

					while(sData != null)
					{
						bSjis = enc.GetBytes(sData);
						if(bSjis.Length  == 0)
						{
							sData = sr.ReadLine();
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
							if(sData != null)iLineCnt++;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
							continue;
						}

// ADD 2008.04.11 ACT Vista対応 START
						string sErr = "";
						string sHData = sData;
						iErrorFlg = true;
						if (!漢字変換_CSV(ref sHData, ref sErr))
						{
							sbErr.Append(iLineCnt + "行目:Vista対応により文字変換がおこなえませんでした" + "『" + sErr + "』\r\n");
							iLenErrMsg = sbErr.ToString().Trim().Length;
							iLenErrMsgOld = iLenErrMsg;
							sw = エラーファイル出力(sw, errfileName, sData);
							if(sw == null) return;
							sData = sr.ReadLine();
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
//							iCnt++;
							if(sData != null)iCnt++;
							if(sData != null)iLineCnt++;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
							iエラー件数++;
							continue;
						}
						bSjis = Encoding.GetEncoding("shift-jis").GetBytes(sHData);
// ADD 2008.04.11 ACT Vista対応 END

						iErrorFlg = true;
						if(bSjis.Length < 338)
						{
							sbErr.Append(iLineCnt + "行目:データ長が違います\r\n");
							sData = sr.ReadLine();
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
//							iCnt++;
							if(sData != null)iCnt++;
							if(sData != null)iLineCnt++;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
							iエラー件数++;
							continue;
						}

						sValue[0]  = new string(enc.GetChars(bSjis,  0,15)).Trim();	//荷受人コード
						sValue[1]  = new string(enc.GetChars(bSjis, 15, 6)).Trim();	//電話番号１
						sValue[2]  = new string(enc.GetChars(bSjis, 21, 4)).Trim();	//電話番号２
						sValue[3]  = new string(enc.GetChars(bSjis, 25, 4)).Trim();	//電話番号３
						sValue[4]  = new string(enc.GetChars(bSjis, 29, 6)).Trim();	//ＦＡＸ番号１
						sValue[5]  = new string(enc.GetChars(bSjis, 35, 4)).Trim();	//ＦＡＸ番号２
						sValue[6]  = new string(enc.GetChars(bSjis, 39, 4)).Trim();	//ＦＡＸ番号３
						sValue[7]  = new string(enc.GetChars(bSjis, 43,40)).Trim();	//住所１
						sValue[8]  = new string(enc.GetChars(bSjis, 83,40)).Trim();	//住所２
						sValue[9]  = new string(enc.GetChars(bSjis,123,40)).Trim();	//住所３
						sValue[10] = new string(enc.GetChars(bSjis,163,40)).Trim();	//名前１
						sValue[11] = new string(enc.GetChars(bSjis,203,40)).Trim();	//名前２
						sValue[12] = new string(enc.GetChars(bSjis,243,40)).Trim();	//未使用（SS:名前３）
						sValue[13] = new string(enc.GetChars(bSjis,283, 3)).Trim();	//郵便番号１
						sValue[14] = new string(enc.GetChars(bSjis,286, 4)).Trim();	//郵便番号２
						sValue[15] = new string(enc.GetChars(bSjis,290, 3)).Trim();	//着店コード
						sValue[16] = new string(enc.GetChars(bSjis,293,10)).Trim();	//カナ略称
						sValue[17] = new string(enc.GetChars(bSjis,303,16)).Trim();	//未使用（SS:住所ＣＤ）
						sValue[18] = new string(enc.GetChars(bSjis,319, 2)).Trim();	//一斉出荷区分
						sValue[19] = new string(enc.GetChars(bSjis,321, 5)).Trim();	//特殊計
						sValue[20] = new string(enc.GetChars(bSjis,326, 6)).Trim();	//未使用（SS:登録日付）
						sValue[21] = new string(enc.GetChars(bSjis,332, 6)).Trim();	//未使用（SS:更新日付）
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない START
						if(gsオプション[18].Equals("1")){
							sValue[7]  = new string(enc.GetChars(bSjis, 43,40)).TrimEnd(); // 住所１
							sValue[8]  = new string(enc.GetChars(bSjis, 83,40)).TrimEnd(); // 住所２
							sValue[9]  = new string(enc.GetChars(bSjis,123,40)).TrimEnd(); // 住所３
							sValue[10] = new string(enc.GetChars(bSjis,163,40)).TrimEnd(); // 名前１
							sValue[11] = new string(enc.GetChars(bSjis,203,40)).TrimEnd(); // 名前２
							sValue[12] = new string(enc.GetChars(bSjis,243,40)).TrimEnd(); // 未使用（SS:名前３）
							sValue[16] = new string(enc.GetChars(bSjis,293,10)).TrimEnd(); // カナ略称
						}
// MOD 2011.01.18 東都）高木 住所名前の前SPACEをつめない END

// MOD 2008.06.16 kcl)森本 着店コード検索方法の変更 START
//// MOD 2006.12.01 東都）高木 住所→郵便番号変換機能の削除 START
////// MOD 2006.07.14 東都）高木 住所→郵便番号変換機能の追加 START
//////						string[] sKey   = new string[21];
////						string[] sKey   = new string[22];
////// MOD 2006.07.14 東都）高木 住所→郵便番号変換機能の追加 END
//						string[] sKey   = new string[21];
//// MOD 2006.12.01 東都）高木 住所→郵便番号変換機能の削除 END
						string[] sKey   = new string[22];
// MOD 2008.06.16 kcl)森本 着店コード検索方法の変更 END

						if (sValue.Length != 22)
						{
							sbErr.Append(iLineCnt + "行目:項目数が違います\r\n");
							sData = sr.ReadLine();
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
//							iCnt++;
							if(sData != null)iCnt++;
							if(sData != null)iLineCnt++;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
							iエラー件数++;
							continue;
						}

						sKey[0] = gs会員ＣＤ;
						sKey[1] = gs部門ＣＤ;
						sKey[20] = gs利用者ＣＤ;
						//荷受人コード
						sValue[0] = sValue[0];
						if (!必須チェック(sValue[0]))
						{
							sbErr.Append(iLineCnt + "行目:荷受人コードは必須項目です\r\n");
							iErrorFlg = false;
						}
						if (!半角チェック(sValue[0]))
						{
							sbErr.Append(iLineCnt + "行目:荷受人コードは半角文字で入力してください\r\n");
							iErrorFlg = false;
						}
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
						if(!記号チェック(sValue[0])){
							sbErr.Append(iLineCnt + "行目:荷受人コードに使用できない記号があります\r\n");
							iErrorFlg = false;
						}
// MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
						sKey[2] = sValue[0];
						if (sKey[2].Length > 15)
						{
							sbErr.Append(iLineCnt + "行目:荷受人コードは１５文字以内で入力してください\r\n");
							iErrorFlg = false;
						}
						//電話番号
						sKey[3] = sValue[1];
						sKey[4] = sValue[2];
						sKey[5] = sValue[3];
						if (sKey[3] == null || sKey[3].Length == 0) sKey[3] = " ";
						if (sKey[4] == null || sKey[4].Length == 0) sKey[4] = " ";
						if (sKey[5] == null || sKey[5].Length == 0) sKey[5] = " ";
						string sTel = sValue[1] + sValue[2] + sValue[3];
						if (!必須チェック(sTel))
						{
							sbErr.Append(iLineCnt + "行目:電話番号は必須項目です\r\n");
							iErrorFlg = false;
						}
// MOD 2008.04.11 ACT Vista対応 START
//						if (!半角チェック(sTel))
						if (!数値チェック(sTel))
// MOD 2008.04.11 ACT Vista対応 END
						{
// MOD 2008.04.11 ACT Vista対応 START
//							sbErr.Append(iLineCnt + "行目:電話番号は半角文字で入力してください\r\n");
							sbErr.Append(iLineCnt + "行目:電話番号は数値で入力してください\r\n");
// MOD 2008.04.11 ACT Vista対応 END
							iErrorFlg = false;
						}
						//ＦＡＸ番号
						string sFax = sValue[4] + sValue[5] + sValue[6];
// MOD 2008.04.11 ACT Vista対応 START
//						if (!半角チェック(sFax))
						if (!数値チェック(sFax))
// MOD 2008.04.11 ACT Vista対応 END
						{
// MOD 2008.04.11 ACT Vista対応 START
//							sbErr.Append(iLineCnt + "行目:ＦＡＸ番号は半角文字で入力してください\r\n");
							sbErr.Append(iLineCnt + "行目:ＦＡＸ番号は数値で入力してください\r\n");
// MOD 2008.04.11 ACT Vista対応 END
							iErrorFlg = false;
						}
						sKey[6] = sValue[4];
						sKey[7] = sValue[5];
						sKey[8] = sValue[6];
						if (sKey[6] == null || sKey[6].Length == 0) sKey[6] = " ";
						if (sKey[7] == null || sKey[7].Length == 0) sKey[7] = " ";
						if (sKey[8] == null || sKey[8].Length == 0) sKey[8] = " ";
						//住所１
						if (!必須チェック(sValue[7]))
						{
							sbErr.Append(iLineCnt + "行目:住所１は必須項目です\r\n");
							iErrorFlg = false;
						}
						if (!全角チェック(sValue[7]))
						{
							sbErr.Append(iLineCnt + "行目:住所１は全角文字で入力してください\r\n");
							iErrorFlg = false;
						}
						sKey[9] = sValue[7];
						//住所２
						if (sValue[8].Length != 0)
						{
							if (!全角チェック(sValue[8]))
							{
								sbErr.Append(iLineCnt + "行目:住所２は全角文字で入力してください\r\n");
								iErrorFlg = false;
							}
							sKey[10] = sValue[8];
						}
						if (sKey[10] == null || sKey[10].Length == 0) sKey[10] = " ";
						//住所３
						if (sValue[9].Length != 0)
						{
							if (!全角チェック(sValue[9]))
							{
								sbErr.Append(iLineCnt + "行目:住所３は全角文字で入力してください\r\n");
								iErrorFlg = false;
							}
							sKey[11] = sValue[9];
						}
						if (sKey[11] == null || sKey[11].Length == 0) sKey[11] = " ";
						//名前１
						if (!必須チェック(sValue[10]))
						{
							sbErr.Append(iLineCnt + "行目:名前１は必須項目です\r\n");
							iErrorFlg = false;
						}
						if (!全角チェック(sValue[10]))
						{
							sbErr.Append(iLineCnt + "行目:名前１は全角文字で入力してください\r\n");
							iErrorFlg = false;
						}
						sKey[12] = sValue[10];
						//名前２
						if (sValue[11].Length != 0)
						{
							if (!全角チェック(sValue[11]))
							{
								sbErr.Append(iLineCnt + "行目:名前２は全角文字で入力してください\r\n");
								iErrorFlg = false;
							}
							sKey[13] = sValue[11];
						}
						if (sKey[13] == null || sKey[13].Length == 0) sKey[13] = " ";
						//名前３ 未使用
						if (sValue[12].Length != 0)
						{
							if (!全角チェック(sValue[12]))
							{
								sbErr.Append(iLineCnt + "行目:名前３は全角文字で入力してください\r\n");
								iErrorFlg = false;
							}
							sKey[14] = sValue[12];
						}
						if (sKey[14] == null || sKey[14].Length == 0) sKey[14] = " ";
						//郵便番号
						sKey[15] = sValue[13] + sValue[14];
// DEL 2006.12.01 東都）高木 住所→郵便番号変換機能の削除 START
//// ADD 2006.07.14 東都）高木 住所→郵便番号変換機能の追加 START
//						sKey[21] = " ";
//						//郵便番号が未入力の場合
//						if(sKey[15].Length == 0){
//							string[] sRet = {"","","","","",""};
//							sRet = 郵便番号取得(sKey[9].Trim() + sKey[10].Trim() + sKey[11].Trim());
//							if(sRet[0].Length == 4)
//							{
//								//郵便番号が存在し、店所ＣＤが割当てられている時
//								//if(sRet[1].Length == 7 && sRet[3].Trim().Length > 0)
//								if(sRet[1].Length == 7)
//								{
//									sKey[15] = sRet[1];	//郵便番号
//									sKey[21] = sRet[2];	//住所ＣＤ８桁
//									sKey[19] = sRet[3]; //店所ＣＤ
//									//sRet[4]; //都道府県ＣＤ
//									//sRet[5]; //市区町村ＣＤ
//								}
//							}
////							else if(sRet[0].Length > 4)
////							{ 
////								sbErr.Append(iLineCnt + "行目:" + sRet[0] +"\r\n");
////								iErrorFlg = false;
////							}
//						}
//// ADD 2006.07.14 東都）高木 住所→郵便番号変換機能の追加 END
// DEL 2006.12.01 東都）高木 住所→郵便番号変換機能の削除 END
						if (!必須チェック(sKey[15])) 
						{
							sbErr.Append(iLineCnt + "行目:郵便番号は必須項目です\r\n");
							iErrorFlg = false;
						}
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
//						if (!数値チェック(sKey[15]))
//						{
//							sbErr.Append(iLineCnt + "行目:郵便番号は数値で入力してください\r\n");
//							iErrorFlg = false;
//						}
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
						if (sKey[15].Length > 7)
						{
							sbErr.Append(iLineCnt + "行目:郵便番号は７文字以内で入力してください\r\n");
							iErrorFlg = false;
						}
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
//						if (数値チェック(sKey[15]) && sKey[15].Length <= 7)
//						{
//							//郵便番号存在チェック
//							string[] sRet = {""};
//							try
//							{
//								if(sv_address == null) sv_address = new is2address.Service1();
//								sRet = sv_address.Get_byPostcode2(gsaユーザ,sKey[15]);
//							}
//							catch (System.Net.WebException)
//							{
//								sbErr.Append(iLineCnt + "行目:"+ gs通信エラー +"\r\n");
//								iErrorFlg = false;
//							}
//							catch (Exception ex)
//							{
//								sbErr.Append(iLineCnt + "行目:通信エラー：" + ex.Message +"\r\n");
//								iErrorFlg = false;
//							}
//
//							if(sRet[0].Length != 4)
//							{
//								sbErr.Append(iLineCnt + "行目:郵便番号が存在しません\r\n");
//								iErrorFlg = false;
//							}
//						}
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
						if (sKey[15].Length == 0) sKey[15] = " ";
						//カナ略称
						sValue[16] = sValue[16];
						if (sValue[16].Trim().Length != 0)
						{
							if (!半角チェック(sValue[16]))
							{
								sbErr.Append(iLineCnt + "行目:カナ略称は半角文字で入力してください\r\n");
								iErrorFlg = false;
							}
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
//							if(!記号チェック(sValue[16])){
//								sbErr.Append(iLineCnt + "行目:カナ略称に使用できない記号があります\r\n");
//								iErrorFlg = false;
//							}
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
						}
						sKey[16] = sValue[16];
						if (sKey[16].Length > 10)
						{
							sbErr.Append(iLineCnt + "行目:カナ略称は１０文字以内で入力してください\r\n");
							iErrorFlg = false;
						}
						if (sKey[16].Length == 0) sKey[16] = " ";
						//一斉出荷区分 未使用
						sValue[18] = sValue[18];
						if (!半角チェック(sValue[18]))
						{
							sbErr.Append(iLineCnt + "行目:一斉出荷区分は半角文字で入力してください\r\n");
							iErrorFlg = false;
						}
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
//						if(!記号チェック(sValue[18])){
//							sbErr.Append(iLineCnt + "行目:一斉出荷区分に使用できない記号があります\r\n");
//							iErrorFlg = false;
//						}
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
						sKey[17] = sValue[18];
						if (sKey[17].Length > 2)
						{
							sbErr.Append(iLineCnt + "行目:一斉出荷区分は２文字以内で入力してください\r\n");
							iErrorFlg = false;
						}
						if (sKey[17].Length == 0) sKey[17] = " ";
						//特殊計 未使用
						sValue[19] = sValue[19];
						if (!半角チェック(sValue[19])) 
						{
							sbErr.Append(iLineCnt + "行目:特殊計は半角文字で入力してください\r\n");
							iErrorFlg = false;
						}
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 START
//						if(!記号チェック(sValue[19])){
//							sbErr.Append(iLineCnt + "行目:特殊計に使用できない記号があります\r\n");
//							iErrorFlg = false;
//						}
//保留 MOD 2009.11.30 東都）高木 ＣＳＶエントリー等に記号チェック機能を追加 END
						sKey[18] = sValue[19];
						if (sKey[18].Length > 5) 
						{
							sbErr.Append(iLineCnt + "行目:特殊計は５文字以内で入力してください\r\n");
							iErrorFlg = false;
						}
						if (sKey[18].Length == 0) sKey[18] = " ";
						//着店コード
						sKey[19] = sValue[15];
// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 START
						//住所コード
						sKey[21] = sValue[17].Trim();
// ADD 2008.06.11 kcl)森本 着店コード検索方法の変更 END
// ADD 2008.04.23 東都）高木 固定長ファイルのエラーファイル出力対応 START
						iLenErrMsg = sbErr.ToString().Trim().Length;
						if(iLenErrMsg != iLenErrMsgOld)
						{
							iLenErrMsgOld = iLenErrMsg;
							sw = エラーファイル出力(sw, errfileName, sData);
							if(sw == null) return;
						}
						else
						{
// ADD 2008.04.23 東都）高木 固定長ファイルのエラーファイル出力対応 END
							StringBuilder sbKeyData = new StringBuilder();
							for (int j = 0; j < sKey.Length; j++)
							{
								sbKeyData.Append(sKey[j] + ",");
							}
							alKey.Add(sbKeyData.ToString().Substring(0, sbKeyData.ToString().Length - 1));
// ADD 2008.04.23 東都）高木 固定長ファイルのエラーファイル出力対応 START
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
							saData[iサーバ送信行] = sData;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
//							iaData[iサーバ送信行] = iCnt;
							iaData[iサーバ送信行] = iLineCnt;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
							iサーバ送信行++;
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
						}
// ADD 2008.04.23 東都）高木 固定長ファイルのエラーファイル出力対応 END
						if(iErrorFlg == false)
						{
							iエラー件数++;
							lblエラー件数.Text=iエラー件数.ToString()+"件";
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
							lblエラー件数.Refresh();
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
							iErrorFlg = true;
						}
						else
						{
							iSetCnt++;
// ADD 2007.02.20 東都）高木 行数カウントの障害修正 START
							if(iSetCnt >= 100)
								break;
// ADD 2007.02.20 東都）高木 行数カウントの障害修正 END
						}
// DEL 2007.02.20 東都）高木 行数カウントの障害修正 START
//						if(iSetCnt >= 100)
//							break;
// DEL 2007.02.20 東都）高木 行数カウントの障害修正 END
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
						iシート総件数 = iCnt;
						lblシート総件数.Text=iシート総件数.ToString()+"件";
						lblシート総件数.Refresh();
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
						sData = sr.ReadLine();
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
//						iCnt++;
						if(sData != null)iCnt++;
						if(sData != null)iLineCnt++;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
					}
					if (alKey.Count > 0)
					{
						string[] sList = new string[alKey.Count];
						IEnumerator enumList = alKey.GetEnumerator();
						int i = 0;
						while(enumList.MoveNext())
						{
							sList[i] = enumList.Current.ToString();
							i++;
						}
						string[] sRet = {""};
						try
						{
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
//							sRet = sv_otodoke.Ins_uploadData(gsaユーザ,sList);
// MOD 2015.05.13 BEVAS) 前田 王子会員様は王子郵便番号マスタで存在チェック　START
							if (gs会員ＣＤ.Substring(0,1) != "J") 
							{
// MOD 2015.05.13 BEVAS) 前田 王子会員様は王子郵便番号マスタで存在チェック　END
								sRet = sv_otodoke.Ins_uploadData2(gsaユーザ,sList);
// MOD 2015.05.13 BEVAS) 前田 王子会員様は王子郵便番号マスタで存在チェック　START
							} 
							else 
							{
								if(sv_oji == null) sv_oji = new is2oji.Service1();
								sRet = sv_oji.otodoke_Ins_uploadData2(gsaユーザ, sList); 
							}
// MOD 2015.05.13 BEVAS) 前田 王子会員様は王子郵便番号マスタで存在チェック　END

// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
// MOD 2009.12.01 東都）高木 データ登録時のエラーチェックを追加 START
							//登録時にエラーが発生した場合終了する
							if(sRet[0].Length > 0)
							{
								texメッセージ.Text = sRet[0];
								iTxtMsgDsp  = false;
								break;
							}
// MOD 2009.12.01 東都）高木 データ登録時のエラーチェックを追加 END
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
							for(int iLine2 = 1; iLine2 < sRet.Length; iLine2++){
								if(sRet[iLine2].Length > 0){
									iエラー件数++;
									iSetCnt--;
									sbErr.Append(iaData[iLine2] + "行目:郵便番号["+sRet[iLine2]+"]が存在しません\r\n");
									iLenErrMsg = sbErr.ToString().Trim().Length;
									if(iLenErrMsg != iLenErrMsgOld){
										iLenErrMsgOld = iLenErrMsg;
									}
									sw = エラーファイル出力(sw, errfileName, saData[iLine2]);
									if(sw == null) return;
								}
							}
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
						}
						catch (System.Net.WebException)
						{
							sRet[0] = gs通信エラー;
							texメッセージ.Text = sRet[0];
							iTxtMsgDsp  = false;
							break;
						}
						catch (Exception ex)
						{
							sRet[0] = "通信エラー：" + ex.Message;
							texメッセージ.Text = sRet[0];
							iTxtMsgDsp  = false;
							break;
						}
						i登録件数 += iSetCnt;
						lbl取込件数.Text=i登録件数.ToString()+"件";
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
						lbl取込件数.Refresh();

						lblエラー件数.Text=iエラー件数.ToString()+"件";
						lblエラー件数.Refresh();
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
// ADD 2007.02.20 東都）高木 行数カウントの障害修正 START
						alKey = null;
						enumList = null;
// ADD 2007.02.20 東都）高木 行数カウントの障害修正 END
						iSetCnt = 0;
					}
// ADD 2007.02.20 東都）高木 行数カウントの障害修正 START
 					if(sData == null){
						break;
					}
// ADD 2007.02.20 東都）高木 行数カウントの障害修正 END
				}
			}
			catch (Exception ex)
			{
				sbErr.Append(ex.Message);
			}
			finally
			{
				sr.Close();
// ADD 2008.04.23 東都）高木 固定長ファイルのエラーファイル出力対応 START
				if(sw != null) sw.Close();
// ADD 2008.04.23 東都）高木 固定長ファイルのエラーファイル出力対応 END
			}
			texデータエラー.Text = sbErr.ToString();
			
			Cursor = System.Windows.Forms.Cursors.Default;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
//			int Wrkcnt = i登録件数;
//			lbl取込件数.Text=Wrkcnt.ToString()+"件";
			lbl取込件数.Text=i登録件数.ToString()+"件";
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
			lblエラー件数.Text=iエラー件数.ToString()+"件";
// MOD 2007.01.17 FJCS) 桑田　荷主総件数をシート総件数に変更 START
//			lbl荷主総件数.Text=i荷主総件数.ToString()+"件";
// MOD 2010.05.11 東都）高木 行数表示の障害修正 START
//			iシート総件数 = iCnt - 1;
			iシート総件数 = iCnt;
// MOD 2010.05.11 東都）高木 行数表示の障害修正 END
// ADD 2007.02.21 東都）高木 件数が－１になる START
			if(iシート総件数 < 0) iシート総件数 = 0;
// ADD 2007.02.21 東都）高木 件数が－１になる END
			lblシート総件数.Text=iシート総件数.ToString()+"件";
// MOD 2007.01.17 FJCS) 桑田　荷主総件数をシート総件数に変更 END
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 START
			lbl取込件数.Refresh();
			lblエラー件数.Refresh();
			lblシート総件数.Refresh();
// MOD 2010.05.07 東都）高木 ＣＳＶ取込時の郵便番号１００件一括チェックを追加 END
			if(iTxtMsgDsp == true)
				texメッセージ.Text = "";
// MOD 2007.02.21 東都）高木 エラー時の完了メッセージの変更 START
//			MessageBox.Show("取込処理が完了しました。","お届け先取込",MessageBoxButtons.OK);
			if(iエラー件数 == 0 && iシート総件数 == 0){
				MessageBox.Show("取込データが存在しませんでした。"
								,"お届け先取込",MessageBoxButtons.OK);
			}else{
				if(i登録件数 == 0){
					MessageBox.Show("エラーが発生した為、取り込めませんでした。"
									,"お届け先取込",MessageBoxButtons.OK);
				}else if(iエラー件数 > 0 || iシート総件数 != i登録件数){
					MessageBox.Show("エラーが発生した為、取り込めなかったデータがあります。"
									,"お届け先取込",MessageBoxButtons.OK);
				}else{
					MessageBox.Show("取込処理が完了しました。"
									,"お届け先取込",MessageBoxButtons.OK);
				}
			}
// MOD 2007.02.21 東都）高木 エラー時の完了メッセージの変更 END
		}
// MOD 2006.07.10 東都）山本 ＣＳＶ取込件数ＭＡＸ３００００件（登録は１００件単位）変更 END

// DEL 2005.06.30 東都）小童谷 共通フォームへ移動 START
//		private bool 必須チェック(string data)
//		{
//			if (data.Trim().Length == 0)
//				return false;
//			else
//				return true;
//		}

//		private bool 全角チェック(string data)
//		{
//			string sUnicode = data.Trim();
//			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
//			if(bSjis.Length == sUnicode.Length * 2) return true;
//			return false;
//		}
//
//		private bool 半角チェック(string data)
//		{
//			string sUnicode = data;
//			byte[] bSjis = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(sUnicode);
//			if(bSjis.Length != sUnicode.Length) return false;
//			return true;
//		}
//
//		private bool 数値チェック(string data)
//		{
//			try
//			{
//				int iChk = int.Parse(data.Replace(",",""));
//				return true;
//			}
//			catch(System.FormatException)
//			{
//				return false;
//			}
//		}
// DEL 2005.06.30 東都）小童谷 共通フォームへ移動 END

// ADD 2005.05.24 東都）小童谷 フォーカス移動 START
		private void お届け先取込_Closed(object sender, System.EventArgs e)
		{
			texファイル名.Text   = " ";
			texデータエラー.Text = "";
			texメッセージ.Text   = "";
			texファイル名.Focus();
		}
// ADD 2005.05.24 東都）小童谷 フォーカス移動 END
// DEL 2006.12.01 東都）高木 住所→郵便番号変換機能の削除 START
//// ADD 2006.07.14 東都）高木 住所→郵便番号変換機能の追加 START
//		private int 市区町村取得(string s住所, int i開始位置)
//		{
//			int i市区町村１ = s住所.Length;
//			int i市１ = s住所.IndexOf("市", i開始位置);
//			int i区１ = s住所.IndexOf("区", i開始位置);
//			int i町１ = s住所.IndexOf("町", i開始位置);
//			int i村１ = s住所.IndexOf("村", i開始位置);
//
//			if(i市１ >= 0 && i市１ < i市区町村１) i市区町村１ = i市１;
//			if(i区１ >= 0 && i区１ < i市区町村１) i市区町村１ = i区１;
//			if(i町１ >= 0 && i町１ < i市区町村１) i市区町村１ = i町１;
//			if(i村１ >= 0 && i村１ < i市区町村１) i市区町村１ = i村１;
//
//			if(i市区町村１ == s住所.Length) return -1;
//
//			return i市区町村１;
//		}
//
//		private string[] 郵便番号取得(string s住所)
//		{
//			string[] sRet = {"","","","","",""};
//			string s都道府県ＣＤ = "";
//			string s市区町村１   = "";
//			string s市区町村２   = "";
//			string s編集住所     = "";
//
//			s住所 = s住所.Replace(" ","");	//半角空白除去
//			s住所 = s住所.Replace("　","");	//全角空白除去
//			
//			//都道府県ハッシュテーブルの作成
//			if(h都道府県２ == null)
//			{
//				h都道府県２ = new Hashtable();
//				for(int iCnt1 = 1; iCnt1 < gsa県名.Length; iCnt1++)
//				{
//					h都道府県２.Add(gsa県名[iCnt1],iCnt1.ToString("00"));
//				}
//			}
//
//			if(s住所.Length >= 3)
//			{
//				//都道府県ＣＤの取得
//				string s編集中     = "";
//				int    iIndex      = 0;
//				// 「神奈川県」、「和歌山県」、「鹿児島県」は４文字で分解し比較する
//				if((s住所[0] == '神' || s住所[0] == '和' || s住所[0] == '鹿')
//					&& s住所.Length >= 4 
//					&& s住所[3] == '県')
//				{
//					s編集中 = s住所.Substring(0,4);
//					iIndex  = 4;
//				}
//				else
//				{
//					s編集中 = s住所.Substring(0,3);
//					iIndex  = 3;
//				}
//				Object obj = h都道府県２[s編集中];
//				if(obj != null)
//				{
//					s都道府県ＣＤ = (string)obj;
//					s住所 = s住所.Remove(0,iIndex);
//				}
//			}
//			s編集住所 = s住所;
//
//			//あいまい文字を変換
//			for(int iCnt1 = 0; iCnt1 < sあいまい文字.Length; iCnt1++)
//			{
//				if(s住所.IndexOf(sあいまい文字[iCnt1]) >= 0)
//					s住所 = s住所.Replace(sあいまい文字[iCnt1], sあいまい文字変換[iCnt1]);
//			}
//			s編集住所 = s住所;
//
//			//旧漢字文字を変換
//			for(int iCnt1 = 0; iCnt1 < sa旧漢字.Length; iCnt1++)
//			{
//				for(int iCnt2 = 0; iCnt2 < sa旧漢字[iCnt1].Length; iCnt2++)
//				{
//					if(s住所.IndexOf(sa旧漢字[iCnt1][iCnt2]) >= 0)
//						s住所 = s住所.Replace(sa旧漢字[iCnt1][iCnt2], sa新漢字[iCnt1][iCnt2]);
//				}
//			}
//			s編集住所 = s住所;
//
//			//省略可能文字を削除
//			s住所 = s住所.Replace("字","");
//			s住所 = s住所.Replace("大","");
//			s住所 = s住所.Replace("小","");
//			s住所 = s住所.Replace("（","");
//			s住所 = s住所.Replace("）","");
//			s編集住所 = s住所;
//
//			//市区町村の区切り
//			int i市区町村１ = 市区町村取得(s住所, 0);
//			if(i市区町村１ >= 0)
//			{
//				s市区町村１ = s住所.Substring(0, i市区町村１ + 1);
//				if(i市区町村１ < s住所.Length)
//				{
//					int i市区町村２ = 市区町村取得(s住所, i市区町村１ + 1);
//					if(i市区町村２ >= 0){
//						s市区町村２ = s住所.Substring(0, i市区町村２ + 1);
//					}
//				}
//			}
//
//			try
//			{
//				if(sv_address == null) sv_address = new is2address.Service1();
//				sRet = sv_address.GetPostcode(gsaユーザ, s都道府県ＣＤ, 
//											s市区町村１, s市区町村２, s編集住所);
//			}
//			catch (System.Net.WebException)
//			{
//				sRet[0] = gs通信エラー;
//			}
//			catch (Exception ex)
//			{
//				sRet[0] = "通信エラー：" + ex.Message;
//			}
//
//			return sRet;
//		}
//// ADD 2006.07.14 東都）高木 住所→郵便番号変換機能の追加 END
// DEL 2006.12.01 東都）高木 住所→郵便番号変換機能の削除 END

	}
}
