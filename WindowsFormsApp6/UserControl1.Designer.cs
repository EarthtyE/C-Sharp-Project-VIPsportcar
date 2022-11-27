
namespace WindowsFormsApp6
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHis = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCarid = new System.Windows.Forms.TextBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtDepos = new System.Windows.Forms.TextBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Location = new System.Drawing.Point(223, 265);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(130, 55);
            this.button5.TabIndex = 50;
            this.button5.Text = "Load Image";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("FC Home", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(706, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 30);
            this.label1.TabIndex = 47;
            this.label1.Text = "Pirce";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("FC Home", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(680, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 30);
            this.label5.TabIndex = 46;
            this.label5.Text = "Deposit";
            // 
            // txtHis
            // 
            this.txtHis.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtHis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHis.Font = new System.Drawing.Font("FC Home", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtHis.ForeColor = System.Drawing.Color.White;
            this.txtHis.Location = new System.Drawing.Point(776, 148);
            this.txtHis.Name = "txtHis";
            this.txtHis.Size = new System.Drawing.Size(211, 37);
            this.txtHis.TabIndex = 43;
            this.txtHis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtCarid);
            this.panel2.Controls.Add(this.txtBrand);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtHis);
            this.panel2.Controls.Add(this.txtModel);
            this.panel2.Controls.Add(this.txtDepos);
            this.panel2.Controls.Add(this.txtColor);
            this.panel2.Controls.Add(this.txtPrice);
            this.panel2.Controls.Add(this.txtPlate);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Location = new System.Drawing.Point(175, 427);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(995, 384);
            this.panel2.TabIndex = 66;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(350, 317);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("FC Home", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(456, 7);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(211, 37);
            this.textBox3.TabIndex = 51;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("FC Home", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(371, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 30);
            this.label2.TabIndex = 21;
            this.label2.Text = "Brand";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("FC Home", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(372, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 30);
            this.label3.TabIndex = 22;
            this.label3.Text = "Model";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("FC Home", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(373, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 30);
            this.label4.TabIndex = 23;
            this.label4.Text = "Car ID";
            // 
            // txtCarid
            // 
            this.txtCarid.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtCarid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCarid.Font = new System.Drawing.Font("FC Home", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCarid.ForeColor = System.Drawing.Color.White;
            this.txtCarid.Location = new System.Drawing.Point(456, 77);
            this.txtCarid.Name = "txtCarid";
            this.txtCarid.Size = new System.Drawing.Size(211, 37);
            this.txtCarid.TabIndex = 25;
            this.txtCarid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCarid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCarid_KeyPress);
            // 
            // txtBrand
            // 
            this.txtBrand.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtBrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBrand.Font = new System.Drawing.Font("FC Home", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtBrand.ForeColor = System.Drawing.Color.White;
            this.txtBrand.Location = new System.Drawing.Point(456, 217);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(211, 37);
            this.txtBrand.TabIndex = 26;
            this.txtBrand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("FC Home", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(683, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 30);
            this.label8.TabIndex = 49;
            this.label8.Text = "History\r\n";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("FC Home", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(673, 79);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(97, 30);
            this.label16.TabIndex = 27;
            this.label16.Text = "Nb.Plate";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("FC Home", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(365, 150);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 30);
            this.label15.TabIndex = 28;
            this.label15.Text = "Status";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("FC Home", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(700, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 30);
            this.label14.TabIndex = 29;
            this.label14.Text = "Color";
            // 
            // txtModel
            // 
            this.txtModel.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModel.Font = new System.Drawing.Font("FC Home", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtModel.ForeColor = System.Drawing.Color.White;
            this.txtModel.Location = new System.Drawing.Point(456, 286);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(211, 37);
            this.txtModel.TabIndex = 30;
            this.txtModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDepos
            // 
            this.txtDepos.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtDepos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepos.Font = new System.Drawing.Font("FC Home", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDepos.ForeColor = System.Drawing.Color.White;
            this.txtDepos.Location = new System.Drawing.Point(776, 286);
            this.txtDepos.Name = "txtDepos";
            this.txtDepos.Size = new System.Drawing.Size(211, 37);
            this.txtDepos.TabIndex = 42;
            this.txtDepos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDepos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepos_KeyPress);
            // 
            // txtColor
            // 
            this.txtColor.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtColor.Font = new System.Drawing.Font("FC Home", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtColor.ForeColor = System.Drawing.Color.White;
            this.txtColor.Location = new System.Drawing.Point(776, 5);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(211, 37);
            this.txtColor.TabIndex = 31;
            this.txtColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Font = new System.Drawing.Font("FC Home", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPrice.ForeColor = System.Drawing.Color.White;
            this.txtPrice.Location = new System.Drawing.Point(776, 217);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(211, 37);
            this.txtPrice.TabIndex = 41;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // txtPlate
            // 
            this.txtPlate.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtPlate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlate.Font = new System.Drawing.Font("FC Home", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPlate.ForeColor = System.Drawing.Color.White;
            this.txtPlate.Location = new System.Drawing.Point(776, 77);
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(211, 37);
            this.txtPlate.TabIndex = 32;
            this.txtPlate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox1.Font = new System.Drawing.Font("FC Lamoon", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ready",
            "Rented",
            "Maintenance"});
            this.comboBox1.Location = new System.Drawing.Point(456, 150);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(211, 34);
            this.comboBox1.TabIndex = 40;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("FC Home", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(385, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 30);
            this.label17.TabIndex = 35;
            this.label17.Text = "Type";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(175, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 64;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("FC Friday", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(216, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 50);
            this.label7.TabIndex = 63;
            this.label7.Text = "VIPsportcar";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("FC Friday", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(227, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 28);
            this.label9.TabIndex = 62;
            this.label9.Text = "Car information";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Plum;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(1176, 494);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 55);
            this.button3.TabIndex = 60;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightPink;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(1176, 555);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 55);
            this.button2.TabIndex = 59;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(1176, 433);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 55);
            this.button1.TabIndex = 58;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(178, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1128, 334);
            this.dataGridView1.TabIndex = 57;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.DoubleBuffered = true;
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(1500, 900);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHis;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCarid;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtDepos;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtPlate;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
