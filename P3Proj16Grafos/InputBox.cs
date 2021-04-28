using System;
using System.Windows.Forms;

namespace P3Proj16Grafos
{
	/// <summary>
	/// Description of InputBox.
	/// </summary>
	public class InputBox : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.ComponentModel.Container components = null;

		private InputBox(string pergunta,string valorinicial)
		{
			InitializeComponent();			
			this.Text=pergunta;
			this.textBox1.Text=valorinicial;
			this.textBox1.SelectAll();
		}

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

		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			//
			// textBox1
			//
			this.textBox1.Location = new System.Drawing.Point(16, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(256, 20);
			this.textBox1.TabIndex = 0;
			//this.textBox1.PasswordChar='*';
			this.textBox1.Text = "Digite valor aqui";
			this.textBox1.KeyDown += new
				System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			//
			// InputBox
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 53);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.textBox1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "InputBox";
			this.Text = "InputBox";
			this.StartPosition = FormStartPosition.CenterParent;
			this.ResumeLayout(false);			

		}

		private void textBox1_KeyDown(object sender,System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
				this.Close();
			if(e.KeyCode == Keys.Escape)
			{
              	textBox1.Text="";
				this.Close();
			}				
		}

		public static string ShowInputBox()
		{
			InputBox box = new InputBox("InputBox","Digite valor");
			box.ShowDialog();
			return box.textBox1.Text;
		}   
		public static string ShowInputBox(string pergunta)
		{
			InputBox box = new InputBox(pergunta,"Digite valor");
			box.ShowDialog();
			return box.textBox1.Text;
		}   
		public static string ShowInputBox(string pergunta, string valorinicial)
		{
			InputBox box = new InputBox(pergunta,valorinicial);
			box.ShowDialog();
			return box.textBox1.Text;
		}   
		
	}

}
