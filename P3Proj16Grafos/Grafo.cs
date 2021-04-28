using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using P3Proj15Grafos;



namespace P3Proj16Grafos
{
	/// <summary>
	/// Description of Grafo.
	/// Classe para simular estrutura de dados do tipo grafo
	/// Também aqui deveriamos usar generics para tornar a nossa classe mais abrangente
	/// no entanto, para simplificar o estudo vamos usar:
	/// - string para identificar os diferentes vertícies:
	/// - int para as ligações (apenas valores positivos; 0 ou <0 para inexistente...)
	/// </summary>
	public class Grafo
	{
		
/// <summary>
		//		Notas:
		
		//> Por algum motivo quando se cria classes novas elas são ditas como pertencentes ao Proj15, e não
		//ao suposto Proj16 por isso o using P3Proj15Grafos
		
		//> O atualizar, eliminar, adicionar direto na janela funciona, mas, raramente, não há primeira.
		//  assim como o ToString() de vez enquando é necessário inserir o mesmo número duas vezes
		
		//> De resto todas as funcionalidades estão a funcionar
/// </summary>
		
     // lista de cores... para desenhar grafo
     static KnownColor[] colorNames  = (KnownColor[])Enum.GetValues(typeof(KnownColor));

     private int totalVertices=0;        // guarda número de vértices do grafo
	 public string[] vertices=null;      // lista de nomes dos vértices do Grafo
	 //Alterei da lista do pc para uma classe criada por mim porque como estava não consegui
	 //pôr aquilo do trocar no ecrã a funcionar direito, assim como os algoritmos especiais.
	 public ListaLigada[] ramos=null;          // guardar informação das ligações (int para testes deveria usar-se generics)
	 public Point[] posicoes=null;		// guarda as coordenadas para representação gráfica
		
#region Construtor da Classe
		public Grafo(int NumeroDeVertices)
		{
		this.vertices = new string[NumeroDeVertices]; // espaço para nomes dos vertices
		this.posicoes = new Point[NumeroDeVertices];
		this.totalVertices=NumeroDeVertices;

		Random random = new Random();
		for (int i=0;i<this.totalVertices;i++)
		{
		 	this.posicoes[i]= new Point(random.Next(10,700),random.Next(10,500));	
			this.vertices[i]="Vertice " + i;
		}		
		this.ramos = new ListaLigada[NumeroDeVertices];
		
		}
#endregion
		
#region Propriedades da Classe
    // devolve o número de vétices que constituem o Grafo
	public int TotalVertices
	{get {
		 return this.totalVertices;	
		}
	}

	// Propriedade que calcula e devolve o número de ramos válidos no grafo
	// lembrar existe ligação de valor na matriz >0
	public int TotalRamos
	{get {int c=0;
			for (int i=0;i<this.totalVertices;i++)
				if(ramos[i] != null)
					c += ramos[i].Count;
		  return c;		
		}
	}
	
	// propriedade que devolve a densidade do Grafo: R/(V*(V-1))
	public double Densidade
	{get {
		  return (double)this.TotalRamos/(this.totalVertices*(this.totalVertices-1));
		 }		
	}
	
#endregion

#region Métodos Públicos dos objectos da Classe
   // devolve o Grafo formatado em forma de matriz de adjacência
   // para colocar numa textBox qualquer...
   // cada linha tem 13 espaços + 5*numvertices + 2 caracteres (mudar de linha)
   public override string ToString()
	{string saida="             ";
   	 // primera linha  .... 00  01  20  03
   	 for (int i=0;i<this.totalVertices;i++)
   	 	saida=saida+String.Format(": {0:00} ",i);
   	 saida = saida + "\r\n";    // mudar de linha
   	 // linhas seguintes:
   	 for(int i = 0; i < totalVertices; i++)
   	 {
   	 	saida = saida + String.Format("{0,-11}{1:00}",(this.vertices[i].Length>11)?this.vertices[i].Substring(0,11):this.vertices[i].ToString(),i);
   	 	if(ramos[i] != null)
   	 	{
   	 		Nodo aux = ramos[i].Primeiro;
   	 		for(int j = 0; j < totalVertices; j++)
   	 		{
   	 			if(aux != null && aux.Descendente == j && aux.Valor.ToString().Length > 4)
   	 			{
   	 				saida=saida+String.Format(":{0,3}+",aux.Valor.ToString().Substring(0,3));
   	 				aux = aux.Next;
   	 				continue;
   	 			}
   	 			
   	 			if(aux != null && aux.Descendente == j)
   	 			{
	   	 			saida+=String.Format(":{0,4}",aux.Valor.ToString());
	   	 			aux = aux.Next;	
	   	 			continue;
   	 			}

   	 			saida+=String.Format(":{0,4}","");
   	 		}
   	 		saida = saida + "\r\n";
   	 		continue;
   	 	}
   	 	for(int n = 0; n < totalVertices; n++)
   	 	{
   	 		saida=saida+String.Format(":{0,4}","");
   	 	}
   	 	saida = saida + "\r\n";
   	 }
   	  return saida.Substring(0,saida.Length-2); // devolver tirando o último \r\n
	}
   	 

   	

   
   // método que tenta desenhar o grafo de forma gráfica numa Image criada com tamanho comprimentoxaltura
   public Image ToImage(int comprimento, int altura)
	{
	 if (comprimento<=0 || altura<=0)
			return null;
		 
	 Pen pen1 = new Pen(Color.DarkSalmon,2);		 
	 Font font = new System.Drawing.Font("Currier New", 9,FontStyle.Regular, GraphicsUnit.Point);
	 StringFormat f = new StringFormat();
	 f.Alignment= StringAlignment.Center;

	 Image imag = new Bitmap(comprimento,altura,System.Drawing.Imaging.PixelFormat.Format24bppRgb);
	 Graphics g=Graphics.FromImage(imag);
	 g.Clear(Color.LightGray);
	 //g.DrawRectangle(pen1,1,1,imag.Width-1,imag.Height-1);
	 if (this.vertices==null)
	 	  return imag; 		 
	 
	 AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 8);	 		 
	 // desenhar os ramos
     Pen pen2 = new Pen(Color.DarkRed,3); 
     pen2.CustomEndCap = bigArrow;
	 for (int i=0;i<this.totalVertices;i++)
	      {
	 	   int px=this.posicoes[i].X;
	 	   int py=this.posicoes[i].Y;
	 	   pen2.Color=Color.FromKnownColor(colorNames[(i*3)%colorNames.Length]);
	 	   if(ramos[i] != null)
	 	   {
	 	   Nodo aux = ramos[i].Primeiro;
	 	   while(aux != null)
	 	   {
	 	   	g.DrawLine(pen2,px,py,this.posicoes[aux.Descendente].X,this.posicoes[aux.Descendente].Y);
	       	g.DrawString(aux.Valor.ToString(),font,Brushes.Blue,(px+this.posicoes[aux.Descendente].X)/2+1,(py+this.posicoes[aux.Descendente].Y)/2-5,f);
	       	aux = aux.Next;
	 	   }
	 	   }
		  }

	 // Agora desenhar por cima os vertíces
	 for (int i=0;i<this.totalVertices;i++)
	      {
	 	   g.DrawArc(pen1,this.posicoes[i].X-10,this.posicoes[i].Y-10,20,20,0,360);
	 	   g.DrawString(this.vertices[i]+"("+i+")",font,Brushes.Blue,this.posicoes[i].X,this.posicoes[i].Y-10,f);
		  }

	 g.Dispose();
	 return imag; 		 
	}
   
   
// método que desenha numa imagem o trajeto contido no vertor vert
   public Image DrawInImage(int[] vert, Image img)
   {
   	if (vert==null || img==null || this.totalVertices==0)
   		return null;		 
	 Pen pen1 = new Pen(Color.Yellow,4);		 
     pen1.EndCap = LineCap.ArrowAnchor;
	 Graphics g=Graphics.FromImage(img);
	 // desenhar as ligações
	 for (int i=0;i<vert.Length-1;i++)
	      {
	 	   g.DrawLine(pen1,this.posicoes[vert[i]].X,this.posicoes[vert[i]].Y,this.posicoes[vert[i+1]].X,this.posicoes[vert[i+1]].Y);
		  }
	 g.Dispose();
	 return img; 		 
	}
   
   // método que faz a gravação dos dados de um grafo em disco
   // usando um formato próprio....
   // 1ª linha: texto GrafoP3
   // 2ª linha: total de vertices (N)
   // N linhas: nomes dos vertices
   // N linhas: matriz de ligação (valores separados por espaços e com * onde não há ligações)
   public void ToFile(string nomeF)
   {
   	StreamWriter fs = new StreamWriter(nomeF,false,System.Text.Encoding.GetEncoding("iso-8859-1"));
   	fs.WriteLine("GrafoP3");
   	fs.WriteLine(this.totalVertices.ToString());
   	// colocar no ficheiro o nome dos vertices e suas coordenadas...
   	for (int i=0;i<this.totalVertices;i++)
   		fs.WriteLine("{0};{1};{2}",this.vertices[i],this.posicoes[i].X,this.posicoes[i].Y);
   	// colocar no ficheiro os dados das ligações
   	for (int i=0;i<this.totalVertices;i++)
   	{
   		Nodo aux;
   		if(ramos[i] != null)
   			aux = ramos[i].Primeiro;
   		else
   			aux = null;
   		for (int j=0;j<this.totalVertices;j++)
   		{
   			if(aux == null || aux.Descendente != j)
   		    {
   		         fs.Write("* ");
   		         continue;
   		    }
   			fs.Write("{0} ",aux.Valor.ToString());
   			if(aux != null)
   				aux = aux.Next;
    	}
   		fs.WriteLine();
   	}
   	fs.Close();
   }

   // método que calcula e devolve o grau de um vértice
   // faz uso de outros métodos para o calculo...
   public int GrauVertice(int vert)
   {
   	int grau = 0;
   	if(ramos[vert] == null)
   		return 0;
   	Nodo aux = ramos[vert].Primeiro;
   	while(aux != null)
   	{
   		grau++;
   		if(aux.Descendente == vert)
   			grau--;
   		aux = aux.Next;
   	}
   	return grau + TotalAntecessores(vert);
   }
   
   /// <summary>
   /// método que devolve um vector com os índices dos vértices sucessores de Vini
   /// </summary>
   /// <param name="vini">Indice do vertice inicial onde começa a listagem</param>
   /// <returns>vector contendo os indices dos vertices</returns>
   public int[] Sucessores(int vini)
   {int[] vector=null;
   	if (vini<0 || vini>=this.TotalVertices || ramos[vini] == null)
   		return null;
   	int dim=this.TotalSucessores(vini);  // dimensão dos sucessores
   	vector= new int[dim];  // reserva espaço para os indices
   	//  preencher vetor com sucessores..
   	int k=0;
   	Nodo aux = ramos[vini].Primeiro;
   	while(aux != null)
   	{
   		vector[k++] = aux.Descendente;
   		aux = aux.Next;
   	}
   	return vector;
   }   
   /// <summary>
   /// método que devolve um vector com os índices dos vértices Antecessores de Vini
   /// </summary>
   /// <param name="vini">Indice do vertice inicial onde começa a listagem</param>
   /// <returns>vector contendo os indices dos vertices</returns>
   public int[] Antecessores(int vini)
   {int[] vector=null;
   	if (vini<0 || vini>=this.TotalVertices)
   		return null;
   	int dim=this.TotalAntecessores(vini);  // dimensão dos antecessores
   	vector= new int[dim];  // reserva espaço para os indices
   	//  preencher vetor com sucessores..
   	int k=0;
   	for(int i = 0; i < totalVertices; i++)
   	{
   		if(ramos[i] != null)
   		{
	   		Nodo aux = ramos[i].Primeiro;
	   		while(aux != null)
	   		{
	   			if(aux.Descendente == vini)
	   			{
	   				vector[k++] = i;
	   				break;
	   			}
	   			aux = aux.Next;
	   		}
   		}
   	}
   	return vector;
   }
   
   /// <summary>
   /// método que permite obter a lista de nomes de vertices (na forma de string), separados por ;
   /// </summary>
   /// <param name="vecindices">vector de índices a saber o nome</param>
   /// <returns>string contendo a lista de nomes sparada por ;</returns>
   public string IndicesToNomes(int[] vecIndices)
   {string saida="";
   	if(vecIndices == null)
   		return saida;
   	else
	   	for (int i=0;i<vecIndices.Length;i++)
	   		saida=saida + this.vertices[vecIndices[i]] + " ; ";
   	return saida;
   }
   
   /// <summary>
   /// Implementação da travessia do grafo 
   /// usando como estratégia a pesquisa em Largura (BreadthFirst)
   //  devolve um vector contendo os vértices visitados ao longo dessa travessia
   /// </summary>
   /// <param name="vi">Indice do vertice onde começa a travessia</param>
   /// <returns>lista (vector) de vertices atravessados por esta travessia</returns>
   public int[] BreadthFirst(int vi)
   {
   	if (vi<0 || vi>=this.totalVertices)
   		return null;
   	bool[] visitados = new bool[this.totalVertices];// para marcar visitados
   	List<int> lista = new List<int>();		  // para colocar travessia..
   	Queue<int> fila = new Queue<int>();   // guardar temporaiamente os valores  
   	fila.Enqueue(vi);
   	visitados[vi] = true;
   	while(fila.Count > 0)
   	{
   		int n = fila.Dequeue();
   		lista.Add(n);
   		if(ramos[n] != null)
   		{
   			Nodo aux = ramos[n].Primeiro;
   			while(aux != null)
   			{
   				if(visitados[aux.Descendente] == false)
   				{
   					fila.Enqueue(aux.Descendente);
   					visitados[aux.Descendente] = true;
   				}
   				aux = aux.Next;
   			}
   		}
   	}
   	return lista.ToArray();
   }
   
   /// <summary>
   /// Implementação da travessia do grafo 
   /// usando como estratégia a pesquisa em Profundidade (usa recursividade)
   //  devolve um vector contendo os vértices visitados ao longo dessa travessia
   /// </summary>
   /// <param name="vi">Indice do vertice onde começa a travessia</param>
   /// <returns>lista (vector) de vertices atravessados por esta travessia</returns>
   public int[] DepthFirst(int vi)
   {
   	if (vi<0 || vi>=this.totalVertices || ramos[vi] == null)
   		return null;
   	bool[] visitados= new bool[this.totalVertices];
   	List<int> lista = new List<int>();
   	DepthFirstRecursivo(vi,visitados,lista);
   	return lista.ToArray();
   }
   
   // método que verifica se existe um qualquer caminho entre dois vértices do grafo
   // devolve true em caso afirmativo.
   public bool ExisteCaminho(int vini, int vfim)
   {
   	bool[] visitados = new bool[this.totalVertices];   
   	return Ha_Caminho(vini,vfim,visitados);
   }

   // método que verifica a existencia de um caminho entre dois vértices 
   // devolvendo-o na forma de vector (null caso não exista)
   public int[] UmCaminho(int vini, int vfim)
   {   	
   	bool[] visitados = new bool[this.totalVertices];
   	List<int> lista = new List<int>();
   	if (Ha_Caminho(vini,vfim,visitados,lista)==true)
   		lista.Add(vini);
   	lista.Reverse();
   	return lista.ToArray();   	   	
   }
   
   /// <summary>
   /// método que calcula qual o menor caminho entre dois vétices
   /// implementa o algoritmo de dijkstra
   /// </summary>
   /// <param name="vini">Indice do vertice partida</param>
   /// <param name="vfim">Indice do vertice destino</param>
   /// <returns>devolve o caminho a percorrer na forma de vector (null caso não exista caminho possível)</returns>
   public int[] MenorCaminho(int vini, int vfim)
   {
   	bool[] visitado = new bool[this.totalVertices]; 
   	int[] distancia = new int[this.totalVertices];
   	int[] anterior = new int[this.totalVertices]; //para poder saber o caminho "de volta"   	
   	// iniciar vetores
   	for (int i=0;i<this.totalVertices;i++)
   	  {visitado[i]=false;
   	   anterior[i]=vini;
   	   Nodo aux = ramos[vini].Primeiro;
   	   if(aux != null && aux.Descendente == i)
   	   {
   	   		distancia[i] = aux.Valor;
   	   		aux = aux.Next;
   	   }
   	   	else
   	   		distancia[i] = 100000;
   	   }
   	  
   	// algoritmo propriamente dito...
   	distancia[vini]=0;
   	visitado[vini]=true;
   	int vx;	     	
   	
   	while ((vx=IndMenorDistanciaNVisitado(distancia,visitado))!=-1)
   	{
   	 visitado[vx]=true;
   	 Nodo aux = ramos[vx] != null ? ramos[vx].Primeiro : null;
   	 while(aux != null)
   	 {
   	 	if(visitado[aux.Descendente] == false)
   	 	{
   	 		if(distancia[aux.Descendente] > distancia[vx] + aux.Valor)
   	 		{
   	 			distancia[aux.Descendente] = distancia[vx] + aux.Valor;
   	 			anterior[aux.Descendente] = vx;
   	 		}
   	 	}
   	 	aux = aux.Next;
   	 }
   	 
   	}// fim do while
   
   	if (distancia[vfim]==100000)	// se não existe distancia de vini para vfim
   		return null;
   	
   	// vamos agora construir o caminho de Vfim para Vini
   	Stack<int> caminho = new Stack<int>();   	
   	caminho.Push(vfim);
   	int ant = vfim;
   	while (ant!=vini)
   		{ ant = anterior[ant];
          caminho.Push(ant);
  	     }
   	
   	return caminho.ToArray();
   }
   
   /// <summary>
   /// método que transforma o grafo actual num grafo de menores distâncias de todos para todos
   /// faz uso do algortimo de Floyd-Warshall para este objectivo
   /// </summary>
   public void ToGrafoMenoresDistancias()
   {
   	int[,]dist = new int[totalVertices,totalVertices];
   	for(int i = 0; i < totalVertices; i++)
   		dist[i,i] = 0;
   	for(int u =0; u < totalVertices; u++)
   	{
   		Nodo aux = null;
   		if(ramos[u] != null)
   			aux = ramos[u].Primeiro;
   		for(int j = 0; j < totalVertices; j++)
   		{
   			if(aux != null && j == aux.Descendente)
   			{
   				dist[u,j] = aux.Valor;
   				aux = aux.Next;
   			}
   			else
   				dist[u,j] = 1000000;
   		}
   	}
   	
   	for(int k = 0; k < totalVertices; k++)
   		for(int i = 0; i < totalVertices; i++)
   			for(int j = 0; j < totalVertices; j++)
   				if(dist[i,j] > dist[i,k] + dist[k,j])
   					dist[i,j] = dist[i,k] + dist[k,j];
   	
   	for(int i = 0; i < totalVertices; i++)
   	{
   		ListaLigada aux = new ListaLigada();
   		for(int j = 0; j < totalVertices; j++)
   		{
   			if(dist[i,j] != 1000000)
   			{
   				aux.Add(j,dist[i,j]);
   			}
   		}
   		ramos[i] = aux;
   	}
   }
   
   // método que transforma o grafo actual numa árvore geradora minima
   // faz uso do algortimo de Prim para este objectivo
   public void ToArvoreGeradoraMinima(int vini)
   {
   	if(ramos[vini] == null)
   		return;
   	bool[] visitado = new bool[totalVertices];
   	int[] distancia = new int[totalVertices];
   	int[] anterior = new int[totalVertices];
   	Grafo test = new Grafo(totalVertices);
   	
   	for(int i = 0; i < totalVertices; i++)
   	{
   		distancia[i] = 100000;
   		visitado[i] = false;
   	}
   	
   	distancia[vini] = 0;
   	anterior[vini] = -1;
   	int menor;
   	while((menor = IndMenorDistanciaNVisitado(distancia, visitado)) != -1)
   	{
   		if(menor == -1)
   			continue;
   		visitado[menor] = true;
   		
   		if(ramos[menor] != null)
   		{
   			Nodo aux = ramos[menor].Primeiro;
   			for(int v = 0; v < totalVertices; v++)
   			{
   				if(aux != null && aux.Descendente == v && visitado[v] == false && aux.Valor < distancia[v])
   				{
   					anterior[v] = menor;
   					distancia[v] = aux.Valor;
   					aux = aux.Next;
   				}
   			}
   		}
   	}
   	for(int i = 0; i <totalVertices; i++)
   	{
   		for(int j = 0; j < totalVertices; j++)
   		{
   			if(anterior[j] == i && distancia[j] != 100000)
   			{
   				if(test.ramos[i] == null)
   					test.ramos[i] = new ListaLigada(new Nodo(j,distancia[j]));
   				else
   					test.ramos[i].Add(j,distancia[j]);
   			}
   		}
   	}
   	ramos = test.ramos;
   }
   
   /// <summary>
   /// Método que calcula e devolve a lista de vertinices inacessíveis
   /// a partir de um vertice inical.
   /// </summary>
   /// <param name="vini">vértice inicial</param>
   /// <returns>lista contendo indices inacessíves. Null caso não exista</returns>
   public int[] Inacessiveis(int vini)
   {
   	int[] acessiveis = DepthFirst(vini);
   	if(acessiveis == null)
   	{
   		acessiveis = new int[totalVertices];
   		int i = 0;
   		while(i != totalVertices)
   		{
   			if(i != vini)
   				acessiveis[i]=i;
   			i++;
   		}
   		return acessiveis.ToArray();
   	}
	if(acessiveis.Length == totalVertices)
   		return null;
   	Queue<int> inacessiveis = new Queue<int>();
   	for(int i = 0; i < totalVertices; i++)
   		if(!acessiveis.Contains(i))
   			inacessiveis.Enqueue(i);
   	return inacessiveis.ToArray();
   }
   #endregion

#region Métodos privados da classe
    // Método auxiliar da travessia em Profundidade...
    private void DepthFirstRecursivo(int vi,bool[] visit, List<int> lista)
    {
     visit[vi]=true;		// marca-lo como visitado
     lista.Add(vi);			// acrescenta-lo à saída..
     // Na lista de sucessores (não visitados) voltar a chamar este mesmo
     // método de forma recursiva...
     if(ramos[vi] != null)
     {
     Nodo aux = ramos[vi].Primeiro;
     while(aux != null)
     {
     	if(visit[aux.Descendente] == false)
     		DepthFirstRecursivo(aux.Descendente, visit, lista);
     	aux = aux.Next;
     }
     }
    }
    

	/// <summary>
    /// Método auxiliar para verificar se existe caminho entre dois vértices..
    /// Faz uso da definição de caminho...
	/// </summary>
	/// <param name="vini">indice do vertice inicial</param>
	/// <param name="vfim">indice do vertice final</param>
	/// <param name="visit">boolenos para assinalar já visitados</param>
	/// <returns></returns>
    private bool Ha_Caminho(int vini, int vfim,bool[] visit)
    {
     visit[vini]=true;
     // existe caminho de vini para vfim se houver ramo vini->vfim
     if(ramos[vini] != null)
     {
     Nodo aux = ramos[vini].Primeiro;
     while(aux != null)
     {
     	if(aux.Descendente == vfim)
     		return true;
     	aux = aux.Next;
     }
     //ou então se exitir caminho de um dos sucessores de vini para vfim
     aux =ramos[vini].Primeiro;
     while(aux != null)
     {
     	if(!visit[aux.Descendente])
     	{
     		if(Ha_Caminho(aux.Descendente, vfim, visit))
     		   return true;
     	}
     	aux = aux.Next;
     }
     }
     return false;						// por aqui não há caminho...
    }    
    
    
	/// <summary>
    /// Método auxiliar para verificar se existe caminho entre dois vértices (
    /// caso exista coloca esse caminho numa lista ligada
    /// Faz uso da definição de caminho...
	/// </summary>
	/// <param name="vini">indice do vertice inicial</param>
	/// <param name="vfim">indice do vertice final</param>
	/// <param name="visit">boolenos para assinalar já visitados</param>
	/// <param name="lista">lista ligada contendo caminho </param>
	/// <returns></returns>
    private bool Ha_Caminho(int vini, int vfim,bool[] visit, List<int> lista)
    {
     visit[vini]=true;
     // existe caminho de vini para vfim se houver ramo vini->vfim	
     if(ramos[vini] != null)
     {
     Nodo aux = ramos[vini].Primeiro;
     while(aux != null)
     {
     	if(aux.Descendente == vfim)
     	{
     		lista.Add(vfim);
     		return true;
     	}
     	aux = aux.Next;
     }
     //ou então se exitir caminho de um dos sucessores de vini para vfim
     aux = ramos[vini].Primeiro;
     while(aux != null)
     {
     	if(!visit[aux.Descendente])
     	{
     		if(Ha_Caminho(aux.Descendente,vfim,visit,lista))
     		{
     			lista.Add(aux.Descendente);
     			return true;
     		}
     	}
     	aux = aux.Next;
     }
     }
     return false;
    }
      
	// método que devolve o número de sucessores de um vértice
	private int TotalSucessores(int vini)
	{
		if(ramos[vini] != null)
			return ramos[vini].Count;
		return 0;
	}

	// método que devolve o número de Antecessores de um vértice
	private int TotalAntecessores(int vini)
	{int cont=0;	
		for(int i = 0; i <totalVertices; i++)
		{
			if(ramos[i] != null)
			{
				Nodo aux = ramos[i].Primeiro;
				while(aux != null)
				{
					if(aux.Descendente == vini)
					{
						cont+=1;
						break;
					}
					aux = aux.Next;
				}
			}
		}
	 return cont;
	}

	// método que devolve o indice da menor distância (>0) de entre os vértices não visitados
	// devolve -1 caso já esteja tudo visitado
	private static int IndMenorDistanciaNVisitado(int[]dist, bool[] visit)
	{int ind=-1;
	 int menor=100000;
	 for (int i=0;i<dist.Length;i++)
	 	if (dist[i]<menor && visit[i]==false)
	        {menor=dist[i];
	 	     ind=i;
	        }
	 return ind;	
	}
#endregion

#region Métodos static da classe Grafo 
    // método que cria um grafo com os dados guardados num ficheiro 
    // formatado de formaespecial (1-GtafoP3, 2-numvertices, 3-nomes, 4-ramos....)
    public static Grafo GrafoFromFile(string nomeF)
    {Grafo grafo=null;
     string[] linhas;
     linhas=File.ReadAllLines(nomeF,System.Text.Encoding.GetEncoding("iso-8859-1")); //ler todos os dados do ficheiro (linha a linha)
     if (linhas.Length<6)				// Não deve ser um grafo (falta mostra mensagem...)
	 	      return null;					
     if (linhas[0]!="GrafoP3")  		// Ver 1ª linha: Não deve ser um grafo nosso (falta mostra mensagem...)
     	 return null;			
     int numvertices;
     int.TryParse(linhas[1],out numvertices);
     if (numvertices<2)
     	 return null;
     grafo = new Grafo(numvertices);   // reservar espaço para este grafo
     // ler as informações dos seus vertices..
     for (int i=0;i<numvertices;i++)
      {string[] umalinha = linhas[i+2].Split(';');
     	 if (umalinha.Length<3)
     	        return null;	
       grafo.vertices[i]=umalinha[0];
       int px,py;
       int.TryParse(umalinha[1],out px);grafo.posicoes[i].X=px;
       int.TryParse(umalinha[2],out py);grafo.posicoes[i].Y=py;
      }
     // tentar agora ler informções sobre as ligações entre vertices
     for(int i = 0; i < numvertices; i++)
     {
     	string[] umalinha = linhas[numvertices+i+2].Split(' ');
     	if(umalinha.Length < numvertices)
     		return null;
     	for(int j = 0; j < numvertices; j++)
     	{
     		int valor;
     		if(umalinha[j] != "*" && umalinha[j] != "" && int.TryParse(umalinha[j], out valor))
     		{
     			if(grafo.ramos[i] != null)
     				grafo.ramos[i].Add(j,valor);
     			else
     			{
     				grafo.ramos[i] = new ListaLigada(new Nodo(j,valor));
     			}
     		}
     	}
     	
     }
     return grafo;
     
    
    }
#endregion

	
	
	}
}
