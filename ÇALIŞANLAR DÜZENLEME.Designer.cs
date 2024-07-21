namespace Otel_Otomasyonu
{
    partial class ÇALIŞANLAR_DÜZENLEME
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lvPersoneller = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGeriDön = new System.Windows.Forms.Button();
            this.btnCıkıs = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblBilgi = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtşifretekrar = new System.Windows.Forms.TextBox();
            this.txtşifre = new System.Windows.Forms.TextBox();
            this.txtGorevId2 = new System.Windows.Forms.TextBox();
            this.txtPersonelGorevId = new System.Windows.Forms.TextBox();
            this.btnbildeğiştir = new System.Windows.Forms.Button();
            this.btnsil = new System.Windows.Forms.Button();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.btnyeni = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbgorev = new System.Windows.Forms.ComboBox();
            this.txtad = new System.Windows.Forms.TextBox();
            this.txtsoyad = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnDeğiştir = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtYeniŞifretekrar = new System.Windows.Forms.TextBox();
            this.txtyeniŞifre = new System.Windows.Forms.TextBox();
            this.cbPersoneller = new System.Windows.Forms.ComboBox();
            this.groupBox4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.lvPersoneller);
            this.groupBox4.Location = new System.Drawing.Point(12, 28);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(332, 237);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            // 
            // lvPersoneller
            // 
            this.lvPersoneller.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvPersoneller.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lvPersoneller.GridLines = true;
            this.lvPersoneller.HideSelection = false;
            this.lvPersoneller.Location = new System.Drawing.Point(20, 23);
            this.lvPersoneller.Margin = new System.Windows.Forms.Padding(2);
            this.lvPersoneller.Name = "lvPersoneller";
            this.lvPersoneller.Size = new System.Drawing.Size(281, 222);
            this.lvPersoneller.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvPersoneller.TabIndex = 16;
            this.lvPersoneller.UseCompatibleStateImageBehavior = false;
            this.lvPersoneller.View = System.Windows.Forms.View.Details;
            this.lvPersoneller.SelectedIndexChanged += new System.EventHandler(this.lvPersoneller_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "PersonelId";
            this.columnHeader1.Width = 2;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "PersonelGorevId";
            this.columnHeader2.Width = 0;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Görevi";
            this.columnHeader3.Width = 98;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Adı";
            this.columnHeader4.Width = 111;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Soyadı";
            this.columnHeader5.Width = 426;
            // 
            // btnGeriDön
            // 
            this.btnGeriDön.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeriDön.Location = new System.Drawing.Point(83, 547);
            this.btnGeriDön.Margin = new System.Windows.Forms.Padding(2);
            this.btnGeriDön.Name = "btnGeriDön";
            this.btnGeriDön.Size = new System.Drawing.Size(52, 41);
            this.btnGeriDön.TabIndex = 23;
            this.btnGeriDön.Text = "GERİ";
            this.btnGeriDön.UseVisualStyleBackColor = true;
            this.btnGeriDön.Click += new System.EventHandler(this.btnGeriDön_Click);
            // 
            // btnCıkıs
            // 
            this.btnCıkıs.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCıkıs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCıkıs.Location = new System.Drawing.Point(11, 547);
            this.btnCıkıs.Margin = new System.Windows.Forms.Padding(2);
            this.btnCıkıs.Name = "btnCıkıs";
            this.btnCıkıs.Size = new System.Drawing.Size(51, 41);
            this.btnCıkıs.TabIndex = 22;
            this.btnCıkıs.Text = "ÇIKIŞ";
            this.btnCıkıs.UseVisualStyleBackColor = false;
            this.btnCıkıs.Click += new System.EventHandler(this.btnCıkıs_Click_1);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Location = new System.Drawing.Point(808, 134);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(344, 310);
            this.panel3.TabIndex = 20;
            // 
            // lblBilgi
            // 
            this.lblBilgi.AutoSize = true;
            this.lblBilgi.Location = new System.Drawing.Point(50, 30);
            this.lblBilgi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(57, 13);
            this.lblBilgi.TabIndex = 21;
            this.lblBilgi.Text = "giriş yapan";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Location = new System.Drawing.Point(366, 56);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(374, 388);
            this.panel2.TabIndex = 19;
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.txtşifretekrar);
            this.groupBox2.Controls.Add(this.txtşifre);
            this.groupBox2.Controls.Add(this.txtGorevId2);
            this.groupBox2.Controls.Add(this.txtPersonelGorevId);
            this.groupBox2.Controls.Add(this.btnbildeğiştir);
            this.groupBox2.Controls.Add(this.btnsil);
            this.groupBox2.Controls.Add(this.btnkaydet);
            this.groupBox2.Controls.Add(this.btnyeni);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbgorev);
            this.groupBox2.Controls.Add(this.txtad);
            this.groupBox2.Controls.Add(this.txtsoyad);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(14, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(358, 374);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txtşifretekrar
            // 
            this.txtşifretekrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtşifretekrar.Location = new System.Drawing.Point(166, 140);
            this.txtşifretekrar.Margin = new System.Windows.Forms.Padding(2);
            this.txtşifretekrar.Multiline = true;
            this.txtşifretekrar.Name = "txtşifretekrar";
            this.txtşifretekrar.Size = new System.Drawing.Size(122, 31);
            this.txtşifretekrar.TabIndex = 19;
            // 
            // txtşifre
            // 
            this.txtşifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtşifre.Location = new System.Drawing.Point(166, 100);
            this.txtşifre.Margin = new System.Windows.Forms.Padding(2);
            this.txtşifre.Multiline = true;
            this.txtşifre.Name = "txtşifre";
            this.txtşifre.Size = new System.Drawing.Size(122, 31);
            this.txtşifre.TabIndex = 18;
            // 
            // txtGorevId2
            // 
            this.txtGorevId2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGorevId2.Location = new System.Drawing.Point(294, 176);
            this.txtGorevId2.Margin = new System.Windows.Forms.Padding(2);
            this.txtGorevId2.Multiline = true;
            this.txtGorevId2.Name = "txtGorevId2";
            this.txtGorevId2.Size = new System.Drawing.Size(22, 19);
            this.txtGorevId2.TabIndex = 15;
            // 
            // txtPersonelGorevId
            // 
            this.txtPersonelGorevId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPersonelGorevId.Location = new System.Drawing.Point(292, 28);
            this.txtPersonelGorevId.Margin = new System.Windows.Forms.Padding(2);
            this.txtPersonelGorevId.Multiline = true;
            this.txtPersonelGorevId.Name = "txtPersonelGorevId";
            this.txtPersonelGorevId.Size = new System.Drawing.Size(24, 31);
            this.txtPersonelGorevId.TabIndex = 14;
            this.txtPersonelGorevId.Visible = false;
            // 
            // btnbildeğiştir
            // 
            this.btnbildeğiştir.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnbildeğiştir.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnbildeğiştir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnbildeğiştir.Location = new System.Drawing.Point(183, 289);
            this.btnbildeğiştir.Margin = new System.Windows.Forms.Padding(2);
            this.btnbildeğiştir.Name = "btnbildeğiştir";
            this.btnbildeğiştir.Size = new System.Drawing.Size(146, 73);
            this.btnbildeğiştir.TabIndex = 10;
            this.btnbildeğiştir.Text = "DEĞİŞTİR";
            this.btnbildeğiştir.UseVisualStyleBackColor = false;
            this.btnbildeğiştir.Click += new System.EventHandler(this.btnbildeğiştir_Click);
            // 
            // btnsil
            // 
            this.btnsil.BackColor = System.Drawing.Color.RosyBrown;
            this.btnsil.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnsil.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnsil.Location = new System.Drawing.Point(23, 289);
            this.btnsil.Margin = new System.Windows.Forms.Padding(2);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(148, 73);
            this.btnsil.TabIndex = 11;
            this.btnsil.Text = "SİL";
            this.btnsil.UseVisualStyleBackColor = false;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // btnkaydet
            // 
            this.btnkaydet.BackColor = System.Drawing.Color.LightCoral;
            this.btnkaydet.BackgroundImage = global::Otel_Otomasyonu.Properties.Resources.REZERVE;
            this.btnkaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkaydet.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnkaydet.Location = new System.Drawing.Point(183, 211);
            this.btnkaydet.Margin = new System.Windows.Forms.Padding(2);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(146, 73);
            this.btnkaydet.TabIndex = 12;
            this.btnkaydet.Text = "KAYDET";
            this.btnkaydet.UseVisualStyleBackColor = false;
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // btnyeni
            // 
            this.btnyeni.BackColor = System.Drawing.Color.Silver;
            this.btnyeni.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnyeni.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnyeni.Location = new System.Drawing.Point(23, 211);
            this.btnyeni.Margin = new System.Windows.Forms.Padding(2);
            this.btnyeni.Name = "btnyeni";
            this.btnyeni.Size = new System.Drawing.Size(148, 73);
            this.btnyeni.TabIndex = 13;
            this.btnyeni.Text = "YENİ";
            this.btnyeni.UseVisualStyleBackColor = false;
            this.btnyeni.Click += new System.EventHandler(this.btnyeni_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(36, 173);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 18);
            this.label6.TabIndex = 7;
            this.label6.Text = "GÖREVİ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(36, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "ŞİFRE TEKRAR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(36, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "ŞİFRE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(36, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "SOYADI";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(36, 41);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "ADI";
            // 
            // cbgorev
            // 
            this.cbgorev.DropDownWidth = 170;
            this.cbgorev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbgorev.FormattingEnabled = true;
            this.cbgorev.IntegralHeight = false;
            this.cbgorev.ItemHeight = 15;
            this.cbgorev.Location = new System.Drawing.Point(166, 175);
            this.cbgorev.Margin = new System.Windows.Forms.Padding(2);
            this.cbgorev.Name = "cbgorev";
            this.cbgorev.Size = new System.Drawing.Size(122, 23);
            this.cbgorev.TabIndex = 6;
            this.cbgorev.SelectedIndexChanged += new System.EventHandler(this.cbgorev_SelectedIndexChanged);
            // 
            // txtad
            // 
            this.txtad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtad.Location = new System.Drawing.Point(166, 28);
            this.txtad.Margin = new System.Windows.Forms.Padding(2);
            this.txtad.Multiline = true;
            this.txtad.Name = "txtad";
            this.txtad.Size = new System.Drawing.Size(122, 31);
            this.txtad.TabIndex = 5;
            // 
            // txtsoyad
            // 
            this.txtsoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtsoyad.Location = new System.Drawing.Point(166, 63);
            this.txtsoyad.Margin = new System.Windows.Forms.Padding(2);
            this.txtsoyad.Multiline = true;
            this.txtsoyad.Name = "txtsoyad";
            this.txtsoyad.Size = new System.Drawing.Size(122, 31);
            this.txtsoyad.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(41, 73);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 349);
            this.panel1.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnDeğiştir);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtYeniŞifretekrar);
            this.groupBox1.Controls.Add(this.txtyeniŞifre);
            this.groupBox1.Controls.Add(this.cbPersoneller);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(2, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(260, 306);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(250, 78);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(22, 19);
            this.textBox1.TabIndex = 16;
            // 
            // btnDeğiştir
            // 
            this.btnDeğiştir.BackColor = System.Drawing.Color.IndianRed;
            this.btnDeğiştir.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDeğiştir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeğiştir.Location = new System.Drawing.Point(42, 212);
            this.btnDeğiştir.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeğiştir.Name = "btnDeğiştir";
            this.btnDeğiştir.Size = new System.Drawing.Size(161, 73);
            this.btnDeğiştir.TabIndex = 8;
            this.btnDeğiştir.Text = "DEĞİŞTİR";
            this.btnDeğiştir.UseVisualStyleBackColor = false;
            this.btnDeğiştir.Click += new System.EventHandler(this.btnDeğiştir_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(0, 158);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 18);
            this.label8.TabIndex = 9;
            this.label8.Text = "T YENİ ŞİFRE";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(4, 124);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 18);
            this.label7.TabIndex = 8;
            this.label7.Text = "YENİ ŞİFRE";
            // 
            // txtYeniŞifretekrar
            // 
            this.txtYeniŞifretekrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYeniŞifretekrar.Location = new System.Drawing.Point(113, 146);
            this.txtYeniŞifretekrar.Margin = new System.Windows.Forms.Padding(2);
            this.txtYeniŞifretekrar.Multiline = true;
            this.txtYeniŞifretekrar.Name = "txtYeniŞifretekrar";
            this.txtYeniŞifretekrar.Size = new System.Drawing.Size(134, 31);
            this.txtYeniŞifretekrar.TabIndex = 2;
            // 
            // txtyeniŞifre
            // 
            this.txtyeniŞifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtyeniŞifre.Location = new System.Drawing.Point(113, 111);
            this.txtyeniŞifre.Margin = new System.Windows.Forms.Padding(2);
            this.txtyeniŞifre.Multiline = true;
            this.txtyeniŞifre.Name = "txtyeniŞifre";
            this.txtyeniŞifre.Size = new System.Drawing.Size(134, 31);
            this.txtyeniŞifre.TabIndex = 1;
            // 
            // cbPersoneller
            // 
            this.cbPersoneller.DropDownWidth = 170;
            this.cbPersoneller.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbPersoneller.FormattingEnabled = true;
            this.cbPersoneller.IntegralHeight = false;
            this.cbPersoneller.ItemHeight = 15;
            this.cbPersoneller.Location = new System.Drawing.Point(113, 76);
            this.cbPersoneller.Margin = new System.Windows.Forms.Padding(2);
            this.cbPersoneller.Name = "cbPersoneller";
            this.cbPersoneller.Size = new System.Drawing.Size(134, 23);
            this.cbPersoneller.TabIndex = 0;
            this.cbPersoneller.SelectedIndexChanged += new System.EventHandler(this.cbPersoneller_SelectedIndexChanged);
            // 
            // ÇALIŞANLAR_DÜZENLEME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Otel_Otomasyonu.Properties.Resources.desktop_wallpaper_gray_background_gray_pink_gray_floral_and_gray_grey_gradient;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1152, 610);
            this.Controls.Add(this.btnGeriDön);
            this.Controls.Add(this.btnCıkıs);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblBilgi);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ÇALIŞANLAR_DÜZENLEME";
            this.Text = "ÇALIŞANLAR_DÜZENLEME";
            this.Load += new System.EventHandler(this.ÇALIŞANLAR_DÜZENLEME_Load);
            this.groupBox4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView lvPersoneller;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnGeriDön;
        private System.Windows.Forms.Button btnCıkıs;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblBilgi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtşifretekrar;
        private System.Windows.Forms.TextBox txtşifre;
        private System.Windows.Forms.TextBox txtGorevId2;
        private System.Windows.Forms.TextBox txtPersonelGorevId;
        private System.Windows.Forms.Button btnbildeğiştir;
        private System.Windows.Forms.Button btnsil;
        private System.Windows.Forms.Button btnkaydet;
        private System.Windows.Forms.Button btnyeni;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbgorev;
        private System.Windows.Forms.TextBox txtad;
        private System.Windows.Forms.TextBox txtsoyad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnDeğiştir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtYeniŞifretekrar;
        private System.Windows.Forms.TextBox txtyeniŞifre;
        private System.Windows.Forms.ComboBox cbPersoneller;
    }
}