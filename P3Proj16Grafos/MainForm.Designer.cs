namespace P3Proj16Grafos
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblResposta = new System.Windows.Forms.Label();
			this.txtGrafo = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.ficheiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gravarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.operações2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.númeroDeRamosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.densidadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.travessiaBreathFirstemLarguraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.travessiaDepthFirstemProfundidadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.operaçoes1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.grauDeUmVérticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sucessoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.antecessoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.operações3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.existeCaminhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.umCaminhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menorCaminhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.operações4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menoresDistânciasFloydWarshallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.árvoreGeradoraMinimaPrimToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.operações5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.inacessiveisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.picBoxGrafo = new System.Windows.Forms.PictureBox();
			this.menuStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picBoxGrafo)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label1.Location = new System.Drawing.Point(175, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(301, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Grafos";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(175, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(301, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "(implementação sob a forma de matriz de adjacências)";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblResposta
			// 
			this.lblResposta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblResposta.ForeColor = System.Drawing.SystemColors.Desktop;
			this.lblResposta.Location = new System.Drawing.Point(0, 303);
			this.lblResposta.Name = "lblResposta";
			this.lblResposta.Size = new System.Drawing.Size(582, 43);
			this.lblResposta.TabIndex = 9;
			this.lblResposta.Text = "Respostas:";
			// 
			// txtGrafo
			// 
			this.txtGrafo.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.txtGrafo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtGrafo.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtGrafo.Location = new System.Drawing.Point(3, 3);
			this.txtGrafo.Multiline = true;
			this.txtGrafo.Name = "txtGrafo";
			this.txtGrafo.ReadOnly = true;
			this.txtGrafo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtGrafo.Size = new System.Drawing.Size(544, 218);
			this.txtGrafo.TabIndex = 13;
			this.txtGrafo.TabStop = false;
			this.txtGrafo.WordWrap = false;
			this.txtGrafo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TxtGrafoMouseDown);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.ficheiroToolStripMenuItem,
									this.operações2ToolStripMenuItem,
									this.operaçoes1ToolStripMenuItem,
									this.operações3ToolStripMenuItem,
									this.operações4ToolStripMenuItem,
									this.operações5ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(595, 24);
			this.menuStrip1.TabIndex = 14;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// ficheiroToolStripMenuItem
			// 
			this.ficheiroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.novoToolStripMenuItem,
									this.abrirToolStripMenuItem,
									this.gravarToolStripMenuItem,
									this.toolStripSeparator1,
									this.sairToolStripMenuItem});
			this.ficheiroToolStripMenuItem.Name = "ficheiroToolStripMenuItem";
			this.ficheiroToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.ficheiroToolStripMenuItem.Text = "Ficheiro";
			// 
			// novoToolStripMenuItem
			// 
			this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
			this.novoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.novoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.novoToolStripMenuItem.Text = "Novo";
			this.novoToolStripMenuItem.Click += new System.EventHandler(this.NovoToolStripMenuItemClick);
			// 
			// abrirToolStripMenuItem
			// 
			this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
			this.abrirToolStripMenuItem.ShortcutKeyDisplayString = "";
			this.abrirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.abrirToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.abrirToolStripMenuItem.Text = "Abrir";
			this.abrirToolStripMenuItem.Click += new System.EventHandler(this.AbrirToolStripMenuItemClick);
			// 
			// gravarToolStripMenuItem
			// 
			this.gravarToolStripMenuItem.Name = "gravarToolStripMenuItem";
			this.gravarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
			this.gravarToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.gravarToolStripMenuItem.Text = "Gravar";
			this.gravarToolStripMenuItem.Click += new System.EventHandler(this.GravarToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(147, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.sairToolStripMenuItem.Text = "Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.SairToolStripMenuItemClick);
			// 
			// operações2ToolStripMenuItem
			// 
			this.operações2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.númeroDeRamosToolStripMenuItem,
									this.densidadeToolStripMenuItem,
									this.toolStripSeparator2,
									this.travessiaBreathFirstemLarguraToolStripMenuItem,
									this.travessiaDepthFirstemProfundidadeToolStripMenuItem});
			this.operações2ToolStripMenuItem.Name = "operações2ToolStripMenuItem";
			this.operações2ToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
			this.operações2ToolStripMenuItem.Text = "Operações1";
			// 
			// númeroDeRamosToolStripMenuItem
			// 
			this.númeroDeRamosToolStripMenuItem.Name = "númeroDeRamosToolStripMenuItem";
			this.númeroDeRamosToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
			this.númeroDeRamosToolStripMenuItem.Text = "Número de Ramos";
			this.númeroDeRamosToolStripMenuItem.Click += new System.EventHandler(this.NúmeroDeRamosToolStripMenuItemClick);
			// 
			// densidadeToolStripMenuItem
			// 
			this.densidadeToolStripMenuItem.Name = "densidadeToolStripMenuItem";
			this.densidadeToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
			this.densidadeToolStripMenuItem.Text = "Densidade";
			this.densidadeToolStripMenuItem.Click += new System.EventHandler(this.DensidadeToolStripMenuItemClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(281, 6);
			// 
			// travessiaBreathFirstemLarguraToolStripMenuItem
			// 
			this.travessiaBreathFirstemLarguraToolStripMenuItem.Name = "travessiaBreathFirstemLarguraToolStripMenuItem";
			this.travessiaBreathFirstemLarguraToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
			this.travessiaBreathFirstemLarguraToolStripMenuItem.Text = "Travessia Breath First (em Largura)";
			this.travessiaBreathFirstemLarguraToolStripMenuItem.Click += new System.EventHandler(this.TravessiaBreathFirstemLarguraToolStripMenuItemClick);
			// 
			// travessiaDepthFirstemProfundidadeToolStripMenuItem
			// 
			this.travessiaDepthFirstemProfundidadeToolStripMenuItem.Name = "travessiaDepthFirstemProfundidadeToolStripMenuItem";
			this.travessiaDepthFirstemProfundidadeToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
			this.travessiaDepthFirstemProfundidadeToolStripMenuItem.Text = "Travessia Depth First (em Profundidade)";
			this.travessiaDepthFirstemProfundidadeToolStripMenuItem.Click += new System.EventHandler(this.TravessiaDepthFirstemProfundidadeToolStripMenuItemClick);
			// 
			// operaçoes1ToolStripMenuItem
			// 
			this.operaçoes1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.grauDeUmVérticeToolStripMenuItem,
									this.sucessoresToolStripMenuItem,
									this.antecessoresToolStripMenuItem});
			this.operaçoes1ToolStripMenuItem.Name = "operaçoes1ToolStripMenuItem";
			this.operaçoes1ToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
			this.operaçoes1ToolStripMenuItem.Text = "Operações2";
			// 
			// grauDeUmVérticeToolStripMenuItem
			// 
			this.grauDeUmVérticeToolStripMenuItem.Name = "grauDeUmVérticeToolStripMenuItem";
			this.grauDeUmVérticeToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.grauDeUmVérticeToolStripMenuItem.Text = "Grau de um Vértice";
			this.grauDeUmVérticeToolStripMenuItem.Click += new System.EventHandler(this.GrauDeUmVérticeToolStripMenuItemClick);
			// 
			// sucessoresToolStripMenuItem
			// 
			this.sucessoresToolStripMenuItem.Name = "sucessoresToolStripMenuItem";
			this.sucessoresToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.sucessoresToolStripMenuItem.Text = "Sucessores de um Vértice";
			this.sucessoresToolStripMenuItem.Click += new System.EventHandler(this.SucessoresToolStripMenuItemClick);
			// 
			// antecessoresToolStripMenuItem
			// 
			this.antecessoresToolStripMenuItem.Name = "antecessoresToolStripMenuItem";
			this.antecessoresToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.antecessoresToolStripMenuItem.Text = "Antecessores de um Vértice";
			this.antecessoresToolStripMenuItem.Click += new System.EventHandler(this.AntecessoresToolStripMenuItemClick);
			// 
			// operações3ToolStripMenuItem
			// 
			this.operações3ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.existeCaminhoToolStripMenuItem,
									this.umCaminhoToolStripMenuItem,
									this.menorCaminhoToolStripMenuItem});
			this.operações3ToolStripMenuItem.Name = "operações3ToolStripMenuItem";
			this.operações3ToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
			this.operações3ToolStripMenuItem.Text = "Operações3";
			// 
			// existeCaminhoToolStripMenuItem
			// 
			this.existeCaminhoToolStripMenuItem.Name = "existeCaminhoToolStripMenuItem";
			this.existeCaminhoToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
			this.existeCaminhoToolStripMenuItem.Text = "Existe Caminho";
			this.existeCaminhoToolStripMenuItem.Click += new System.EventHandler(this.ExisteCaminhoToolStripMenuItemClick);
			// 
			// umCaminhoToolStripMenuItem
			// 
			this.umCaminhoToolStripMenuItem.Name = "umCaminhoToolStripMenuItem";
			this.umCaminhoToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
			this.umCaminhoToolStripMenuItem.Text = "Um Caminho";
			this.umCaminhoToolStripMenuItem.Click += new System.EventHandler(this.UmCaminhoToolStripMenuItemClick);
			// 
			// menorCaminhoToolStripMenuItem
			// 
			this.menorCaminhoToolStripMenuItem.Name = "menorCaminhoToolStripMenuItem";
			this.menorCaminhoToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
			this.menorCaminhoToolStripMenuItem.Text = "Menor Caminho (Dijkstra’s)";
			this.menorCaminhoToolStripMenuItem.Click += new System.EventHandler(this.MenorCaminhoToolStripMenuItemClick);
			// 
			// operações4ToolStripMenuItem
			// 
			this.operações4ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.menoresDistânciasFloydWarshallToolStripMenuItem,
									this.árvoreGeradoraMinimaPrimToolStripMenuItem1});
			this.operações4ToolStripMenuItem.Name = "operações4ToolStripMenuItem";
			this.operações4ToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
			this.operações4ToolStripMenuItem.Text = "Operações4";
			// 
			// menoresDistânciasFloydWarshallToolStripMenuItem
			// 
			this.menoresDistânciasFloydWarshallToolStripMenuItem.Name = "menoresDistânciasFloydWarshallToolStripMenuItem";
			this.menoresDistânciasFloydWarshallToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
			this.menoresDistânciasFloydWarshallToolStripMenuItem.Text = "Menores Distâncias (Floyd-Warshall)";
			this.menoresDistânciasFloydWarshallToolStripMenuItem.Click += new System.EventHandler(this.MenoresDistânciasFloydWarshallToolStripMenuItemClick);
			// 
			// árvoreGeradoraMinimaPrimToolStripMenuItem1
			// 
			this.árvoreGeradoraMinimaPrimToolStripMenuItem1.Name = "árvoreGeradoraMinimaPrimToolStripMenuItem1";
			this.árvoreGeradoraMinimaPrimToolStripMenuItem1.Size = new System.Drawing.Size(266, 22);
			this.árvoreGeradoraMinimaPrimToolStripMenuItem1.Text = "Árvore Geradora Minima (Prim)";
			this.árvoreGeradoraMinimaPrimToolStripMenuItem1.Click += new System.EventHandler(this.ÁrvoreGeradoraMinimaPrimToolStripMenuItem1Click);
			// 
			// operações5ToolStripMenuItem
			// 
			this.operações5ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.inacessiveisToolStripMenuItem});
			this.operações5ToolStripMenuItem.Name = "operações5ToolStripMenuItem";
			this.operações5ToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
			this.operações5ToolStripMenuItem.Text = "Operações5";
			// 
			// inacessiveisToolStripMenuItem
			// 
			this.inacessiveisToolStripMenuItem.Name = "inacessiveisToolStripMenuItem";
			this.inacessiveisToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.inacessiveisToolStripMenuItem.Text = "Inacessiveis";
			this.inacessiveisToolStripMenuItem.Click += new System.EventHandler(this.InacessiveisToolStripMenuItemClick);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 50);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(558, 250);
			this.tabControl1.TabIndex = 15;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtGrafo);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(550, 224);
			this.tabPage1.TabIndex = 1;
			this.tabPage1.Text = "MatrizAdjacencias";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.picBoxGrafo);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(550, 224);
			this.tabPage2.TabIndex = 2;
			this.tabPage2.Text = "Visual";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// picBoxGrafo
			// 
			this.picBoxGrafo.BackColor = System.Drawing.Color.WhiteSmoke;
			this.picBoxGrafo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picBoxGrafo.Location = new System.Drawing.Point(3, 3);
			this.picBoxGrafo.Name = "picBoxGrafo";
			this.picBoxGrafo.Size = new System.Drawing.Size(544, 218);
			this.picBoxGrafo.TabIndex = 0;
			this.picBoxGrafo.TabStop = false;
			this.picBoxGrafo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicBoxGrafoMouseMove);
			this.picBoxGrafo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicBoxGrafoMouseDown);
			this.picBoxGrafo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicBoxGrafoMouseUp);
			this.picBoxGrafo.SizeChanged += new System.EventHandler(this.PicBoxGrafoSizeChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(595, 345);
			this.Controls.Add(this.lblResposta);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.tabControl1);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Grafos - Matriz de Adjacências";
			this.ResizeEnd += new System.EventHandler(this.MainFormResizeEnd);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picBoxGrafo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.PictureBox picBoxGrafo;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.ToolStripMenuItem inacessiveisToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem operações5ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem travessiaBreathFirstemLarguraToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem travessiaDepthFirstemProfundidadeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem árvoreGeradoraMinimaPrimToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem menoresDistânciasFloydWarshallToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem operações4ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem grauDeUmVérticeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menorCaminhoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem umCaminhoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem existeCaminhoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem operações3ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem densidadeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem númeroDeRamosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem operações2ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem antecessoresToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sucessoresToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem operaçoes1ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gravarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ficheiroToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.Label lblResposta;
		private System.Windows.Forms.TextBox txtGrafo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
			
		
		void SairToolStripMenuItemClick(object sender, System.EventArgs e)
		{
		 System.Windows.Forms.Application.Exit();
		}
		
	}
}
