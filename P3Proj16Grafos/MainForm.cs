using System;
using System.Drawing;
using System.Windows.Forms;

namespace P3Proj16Grafos
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
	   Grafo grafo = null;   // objecto a usar para tratamento de Grafos....
	   int vertice=-1;		 // variável para tratamento de ajuste visual do grafo...
				
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			// iniciar o programa com um grafo vazio de dimensão 10
			grafo = new Grafo(10);
			this.txtGrafo.Text=grafo.ToString();
			this.picBoxGrafo.Image=grafo.ToImage(this.picBoxGrafo.Width,this.picBoxGrafo.Height);
			//Quando alterava diretamento no design dava erro ao pôr a dar
			this.Text = "Grafo-Lista de Adjacências";
			label2.Text = "(implementação sob a forma de lista de adjacências)";
			tabPage1.Text = "ListaAdjaçências";
		}

        // evento chamado quando o se faz um mousedown dentro da caixa de texto
        // serve para fazer a edição dos dados do Grafo
		void TxtGrafoMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
		 if (e.Button!= MouseButtons.Left)   // só se for o botão esquerdo...
				return;
		 if (this.grafo==null)					// só se existir um grafo válido
		  	 return;
		 // Dadas as coordenadas do rato devolver a posição dentro de uma string 
		 int pos= this.txtGrafo.GetCharIndexFromPosition(new Point(e.X,e.Y));
		 		 
		 // tamanho da linha devolvida pelo ToString()...
		 int tamanhoLinha = 13 + this.grafo.TotalVertices*5 + 2;

		 // calcular agora em que linha e coluna foi feito o click
		 int verticeOrigem = pos/tamanhoLinha-1;
		 int verticeDestino = ((pos%tamanhoLinha));
		 if (verticeDestino<14)
		 	 verticeDestino=-1;
		    else 
		     verticeDestino = (verticeDestino-14)/5;
				 
		 // para testes....
		  //string texto="posicao" + pos+" Origem="+verticeOrigem+" Destino="+verticeDestino;
		  //MessageBox.Show(texto,"olá");
	
		 // se seleccionou um dos ramos existentes no grafo então editar essa ligação
		 if (verticeDestino!=-1 && verticeOrigem!=-1)
		    {string resp=InputBox.ShowInputBox("Valor da ligação entre "+ verticeOrigem + " e " + verticeDestino);
		 	int vert;
		 	if(int.TryParse(resp,out vert))
		 	{
		 		if(grafo.ramos[verticeOrigem] != null )
		 			grafo.ramos[verticeOrigem].Add(verticeDestino,vert);
		 		else
		 			if(vert != 0)
		 				grafo.ramos[verticeOrigem] = new P3Proj15Grafos.ListaLigada(new P3Proj15Grafos.Nodo(verticeDestino,vert));
		 		
		 	}
		    }
		 //se seleccionou um dos nomes dos vértices, então editar esse nome
		 if (verticeDestino==-1 && verticeOrigem!=-1)
		 	this.grafo.vertices[verticeOrigem]=InputBox.ShowInputBox("Nome do vertice");
		     
		 this.txtGrafo.Text=grafo.ToString();
		 if (this.picBoxGrafo.Image!=null) this.picBoxGrafo.Image.Dispose();
		 this.picBoxGrafo.Image=grafo.ToImage(this.picBoxGrafo.Width,this.picBoxGrafo.Height);		 
		 this.txtGrafo.Select(0,0); // para limpar qualquer selecção...
		}

		// evento chamado a quando do redimensionamento do formulário 
		// serve para ajustar o tamanho da caixa de texo ao tamanho do formulário
		void MainFormResizeEnd(object sender, EventArgs e)
		{
		 this.tabControl1.Width=this.Width-50;
		 this.tabControl1.Height=this.Height-155;
		 this.lblResposta.Width=this.Width-50;
		 this.lblResposta.Top=this.Height-100;
		}

		
		// tenta criar um grafo a partir dos dados guardados em disco
		void AbrirToolStripMenuItemClick(object sender, EventArgs e)
		{OpenFileDialog fdiag = new OpenFileDialog();
		 fdiag.Filter="Text files (*.txt)|*.txt|All files (*.*)|*.*";
		 DialogResult res = fdiag.ShowDialog();
		 if (res==DialogResult.OK)
		 	grafo = Grafo.GrafoFromFile(fdiag.FileName);
		 string[] nome=fdiag.FileName.Split('\\');		 
		 fdiag.Dispose();
		 if (grafo==null)
		    {this.txtGrafo.Text="Erro na abertura do grafo...";
		     this.Text="Grafos-Lista de Adjacências: ";
		    }
		 else
		    {this.txtGrafo.Text=grafo.ToString();
		     if (this.picBoxGrafo.Image!=null) this.picBoxGrafo.Image.Dispose();
		     this.picBoxGrafo.Image=grafo.ToImage(this.picBoxGrafo.Width,this.picBoxGrafo.Height);		 
		     this.txtGrafo.Select(0,0); // para limpar qualquer selecção...			     
		     this.Text="Grafos-Lista de Adjacências: "+nome[nome.Length-1].ToString();
		    }
		}
		
		// Evento para guardar um grafo em disco
		void GravarToolStripMenuItemClick(object sender, EventArgs e)
		{if (this.grafo==null)
				return;
		 SaveFileDialog fdiag = new SaveFileDialog();
		 fdiag.Filter="Text files (*.txt)|*.txt|All files (*.*)|*.*";
		 DialogResult res = fdiag.ShowDialog();
		 if (res==DialogResult.OK)		// se escolheu um ficheiro de texto
		 	grafo.ToFile(fdiag.FileName);
		 string[] nome=fdiag.FileName.Split('\\');
		 this.Text="Grafos-Lista de Adjacências: "+nome[nome.Length-1].ToString();
		 fdiag.Dispose();
		}
		
		//Chama o método que permite calcular o número de ramos existentes no grafo
		void NúmeroDeRamosToolStripMenuItemClick(object sender, EventArgs e)
		{if (this.grafo==null)
				return;
		 this.lblResposta.Text= "O número de ramos: " + this.grafo.TotalRamos;
		}
		
		
		//chama o método que permite calcular a densidade do grafo 
		void DensidadeToolStripMenuItemClick(object sender, EventArgs e)
		{if (this.grafo==null)
				return;			
			this.lblResposta.Text= String.Format("Densidade é {0:p}",this.grafo.Densidade);
		}
		
		// mostra os sucessores de um determinado Vértice
		void SucessoresToolStripMenuItemClick(object sender, EventArgs e)
		{if (this.grafo==null)
			  return;	
		 int vini;
		 do
		   int.TryParse(InputBox.ShowInputBox("Índice do Vértice Inicial:"),out vini);
		 while (vini>=this.grafo.TotalVertices);
		 int[] resp = grafo.Sucessores(vini);
		 this.lblResposta.Text= "Sucessores de " + grafo.vertices[vini] + " são " + grafo.IndicesToNomes(resp);
		}
		
		// mostra os Antecessores de um determinado Vértice
		void AntecessoresToolStripMenuItemClick(object sender, EventArgs e)
		{if (this.grafo==null)
			  return;	
		 int vini;
		 do
		   int.TryParse(InputBox.ShowInputBox("Índice do Vértice Inicial:"),out vini);
		 while (vini>=this.grafo.TotalVertices);
		 int[] resp = grafo.Antecessores(vini);
		 this.lblResposta.Text= "Antecessores de " + grafo.vertices[vini] + " são " + grafo.IndicesToNomes(resp);
		}
		
		void GrauDeUmVérticeToolStripMenuItemClick(object sender, EventArgs e)
		{if (this.grafo==null)
			  return;	
		 int vini;
		 do
		   int.TryParse(InputBox.ShowInputBox("Índice do Vértice:"),out vini);
		 while (vini>=this.grafo.TotalVertices);
		 this.lblResposta.Text= "Grau do vértice " + grafo.vertices[vini] + " é " + grafo.GrauVertice(vini);
        }
		
		void NovoToolStripMenuItemClick(object sender, EventArgs e)
		{int numero;
		 do
		   int.TryParse(InputBox.ShowInputBox("Número de Vértices"),out numero);
		 while (numero<2);
		 this.grafo=new Grafo(numero);
		 this.txtGrafo.Text=this.grafo.ToString();
		 this.lblResposta.Text="";
		 this.Text="Grafos-Lista de Adjacências: noname.txt";
		}
		
		
		void TravessiaDepthFirstemProfundidadeToolStripMenuItemClick(object sender, EventArgs e)
		{if (this.grafo==null)
				return;			
		 int vini;
		 do
		   int.TryParse(InputBox.ShowInputBox("Vértice Inicial:"),out vini);
		 while (vini>=this.grafo.TotalVertices);
		 int[] vecresult = this.grafo.DepthFirst(vini);
		 string saida="Travessia Depth First: ";
		 saida = saida + this.grafo.IndicesToNomes(vecresult);
         this.lblResposta.Text=saida;					
		}
		
		void TravessiaBreathFirstemLarguraToolStripMenuItemClick(object sender, EventArgs e)
		{if (this.grafo==null)
				return;			
		 int vini;
		 do
		   int.TryParse(InputBox.ShowInputBox("Vértice Inicial:"),out vini);
		 while (vini>=this.grafo.TotalVertices);
		 int[] vecresult = this.grafo.BreadthFirst(vini);
		 string saida="Travessia Breath First: ";
		 saida = saida + this.grafo.IndicesToNomes(vecresult);
         this.lblResposta.Text=saida;	
	  	 this.picBoxGrafo.Image=this.grafo.DrawInImage(vecresult,this.picBoxGrafo.Image);
		}
		
		
		// evento chamado quando se quer saber se existe caminho entre dois vértices
		void ExisteCaminhoToolStripMenuItemClick(object sender, EventArgs e)
		{if (this.grafo==null)
				return;			
		 int vini,vfim;
		 do
		   int.TryParse(InputBox.ShowInputBox("Origem do Caminhno:"),out vini);
		 while (vini>=this.grafo.TotalVertices);
		 do
		   int.TryParse(InputBox.ShowInputBox("Destino do Caminho:"),out vfim);
		 while (vfim>=this.grafo.TotalVertices);
		 
		 if (this.grafo.ExisteCaminho(vini,vfim)==true)
		      this.lblResposta.Text="SIM, existe caminho ";
		   else
		   	  this.lblResposta.Text="NÃO, não existe caminho ";

		 this.lblResposta.Text+=" entre " + this.grafo.vertices[vini] + " e " + this.grafo.vertices[vfim];
		}
		
		// evento chamado para devolver um caminho
		void UmCaminhoToolStripMenuItemClick(object sender, EventArgs e)
		{if (this.grafo==null)
				return;			
		 int vini,vfim;
		 do
		   int.TryParse(InputBox.ShowInputBox("Origem do Camnhino:"),out vini);
		 while (vini>=this.grafo.TotalVertices);
		 do
		   int.TryParse(InputBox.ShowInputBox("Destino do Caminho:"),out vfim);
		 while (vfim>=this.grafo.TotalVertices);
		 int[] vecresult;
		 if ((vecresult=this.grafo.UmCaminho(vini,vfim))==null)		// se devolver vector vazio
		   	this.lblResposta.Text="NÃO, não existe caminho ";
		  else
		    {this.lblResposta.Text="Um caminho entre " + this.grafo.vertices[vini] + " e " + this.grafo.vertices[vfim] + ": "+ this.grafo.IndicesToNomes(vecresult);
		  	 this.picBoxGrafo.Image=this.grafo.DrawInImage(vecresult,this.picBoxGrafo.Image);
		    }
		}
		
				
		void MenorCaminhoToolStripMenuItemClick(object sender, EventArgs e)
		{if (this.grafo==null)
				return;			
		 int vini,vfim;
		 do
		   int.TryParse(InputBox.ShowInputBox("Origem do Camnhino:"),out vini);
		 while (vini>=this.grafo.TotalVertices);
		 do
		   int.TryParse(InputBox.ShowInputBox("Destino do Caminho:"),out vfim);
		 while (vfim>=this.grafo.TotalVertices);
		 int[] vecresult;
		 if ((vecresult=this.grafo.MenorCaminho(vini,vfim))==null)		// se devolver vector vazio
		   	this.lblResposta.Text="NÃO, não existe caminho ";
		  else
		   {
		  	this.lblResposta.Text="Menor Caminho entre " + this.grafo.vertices[vini] + " e " + this.grafo.vertices[vfim] + ": "+ this.grafo.IndicesToNomes(vecresult);
		  	this.picBoxGrafo.Image=this.grafo.DrawInImage(vecresult,this.picBoxGrafo.Image);
		    }
		}
		
		void MenoresDistânciasFloydWarshallToolStripMenuItemClick(object sender, EventArgs e)
		{if (this.grafo==null)
				return;			
		 this.grafo.ToGrafoMenoresDistancias();
		 this.txtGrafo.Text = this.grafo.ToString();
		 if (this.picBoxGrafo.Image!=null) this.picBoxGrafo.Image.Dispose();
		 this.picBoxGrafo.Image=grafo.ToImage(this.picBoxGrafo.Width,this.picBoxGrafo.Height);		 
		 this.lblResposta.Text="";
		}
		
		void ÁrvoreGeradoraMinimaPrimToolStripMenuItem1Click(object sender, EventArgs e)
		{if (this.grafo==null)
				return;			
		 int vini;
		 do
		   int.TryParse(InputBox.ShowInputBox("Origem da Árvore:"),out vini);
		 while (vini>=this.grafo.TotalVertices);
		 this.grafo.ToArvoreGeradoraMinima(vini);
		 this.txtGrafo.Text = this.grafo.ToString();
		 if (this.picBoxGrafo.Image!=null) this.picBoxGrafo.Image.Dispose();
		 this.picBoxGrafo.Image=grafo.ToImage(this.picBoxGrafo.Width,this.picBoxGrafo.Height);		 
		 this.lblResposta.Text="";		 
		}
		
		void InacessiveisToolStripMenuItemClick(object sender, System.EventArgs e)
		{if (this.grafo==null)
				return;			
		 int vini;
		 do
		   int.TryParse(InputBox.ShowInputBox("Vértice Inicial:"),out vini);
		 while (vini>=this.grafo.TotalVertices);
		 int[] vecresult = this.grafo.Inacessiveis(vini);
		 if (vecresult==null)
              this.lblResposta.Text="não existem inacessíveis a partir  de " + this.grafo.vertices[vini];					
		    else
		  	  this.lblResposta.Text="Inacessiveis a partir de " + this.grafo.vertices[vini] + " : " + this.grafo.IndicesToNomes(vecresult);
		 	 
		}

		// evento chamado quando se clica na picbox
		void PicBoxGrafoMouseDown(object sender, MouseEventArgs e)
		{
		 if (this.grafo==null || e.Button!=MouseButtons.Left)
					return;
		 int px=e.X;
		 int py=e.Y;
		 // verificar se nas coordenadas px,py existe algum vértice
		 vertice=-1;
		 for (int i=0;i<this.grafo.TotalVertices;i++)
		 	if (Math.Abs(px-this.grafo.posicoes[i].X)<10 && Math.Abs(py-this.grafo.posicoes[i].Y)<10)
		 		vertice=i;					
	    }
		
		
		void PicBoxGrafoMouseUp(object sender, MouseEventArgs e)
		{
		 if (this.grafo==null || e.Button!=MouseButtons.Left || vertice==-1)
					return;
		 vertice=-1;
		}

		
		void PicBoxGrafoMouseMove(object sender, MouseEventArgs e)
		{
		 //return;
		 if (this.grafo==null || e.Button!=MouseButtons.Left || vertice==-1)
					return;
		 if (e.X<5 || e.Y<5 || e.X>this.picBoxGrafo.Width-5 || e.Y>this.picBoxGrafo.Height-5)
		 	return;
		 this.grafo.posicoes[vertice].X=e.X;
		 this.grafo.posicoes[vertice].Y=e.Y;
		 if (this.picBoxGrafo.Image!=null) this.picBoxGrafo.Image.Dispose();
		 this.picBoxGrafo.Image=grafo.ToImage(this.picBoxGrafo.Width,this.picBoxGrafo.Height);						
		}
		
		void PicBoxGrafoSizeChanged(object sender, EventArgs e)
		{
		 if (this.picBoxGrafo.Image!=null) this.picBoxGrafo.Image.Dispose();
		 this.picBoxGrafo.Image=grafo.ToImage(this.picBoxGrafo.Width,this.picBoxGrafo.Height);			
		}
	}
}
