
partial class MainForm
{
	private System.ComponentModel.IContainer components = null;
	private System.Windows.Forms.Timer timer1;
	private System.Windows.Forms.Button button1;
	private System.Windows.Forms.Button button2;
	private System.Windows.Forms.Button button3;
	private System.Windows.Forms.Button button4;
	private System.Windows.Forms.Button button5;

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null) 
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.button1 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		this.button4 = new System.Windows.Forms.Button();
		this.button5 = new System.Windows.Forms.Button();
		this.SuspendLayout();
		// 
		// timer1
		// 
		this.timer1.Interval = 50;
		this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
		// 
		// button1
		// 
		this.button1.CausesValidation = false;
		this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Green;
		this.button1.FlatAppearance.BorderSize = 5;
		this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
		this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
		this.button1.Location = new System.Drawing.Point(1192, 56);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(256, 104);
		this.button1.TabIndex = 0;
		this.button1.TabStop = false;
		this.button1.Text = "Easy";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(this.Button1Click);
		// 
		// button2
		// 
		this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Green;
		this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
		this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
		this.button2.Location = new System.Drawing.Point(1192, 176);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(256, 104);
		this.button2.TabIndex = 1;
		this.button2.TabStop = false;
		this.button2.Text = "Medium";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(this.Button2Click);
		// 
		// button3
		// 
		this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Green;
		this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
		this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
		this.button3.Location = new System.Drawing.Point(1192, 296);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(256, 112);
		this.button3.TabIndex = 2;
		this.button3.TabStop = false;
		this.button3.Text = "Hard";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(this.Button3Click);
		// 
		// button4
		// 
		this.button4.CausesValidation = false;
		this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Green;
		this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
		this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
		this.button4.Location = new System.Drawing.Point(1192, 424);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(256, 112);
		this.button4.TabIndex = 3;
		this.button4.TabStop = false;
		this.button4.Text = "Mission impossible";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(this.Button4Click);
		// 
		// button5
		// 
		this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
		this.button5.Location = new System.Drawing.Point(1192, 552);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(256, 112);
		this.button5.TabIndex = 4;
		this.button5.Text = "Pause/Play";
		this.button5.UseVisualStyleBackColor = true;
		this.button5.Click += new System.EventHandler(this.Button5Click);
		// 
		// MainForm
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(1467, 993);
		this.Controls.Add(this.button5);
		this.Controls.Add(this.button4);
		this.Controls.Add(this.button3);
		this.Controls.Add(this.button2);
		this.Controls.Add(this.button1);
		this.DoubleBuffered = true;
		this.Name = "MainForm";
		this.Text = "PACMAN2";
		this.Load += new System.EventHandler(this.MainFormLoad);
		this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainFormPaint);
		this.ResumeLayout(false);

	}

	public MainForm()
	{
		InitializeComponent();
	}
}
