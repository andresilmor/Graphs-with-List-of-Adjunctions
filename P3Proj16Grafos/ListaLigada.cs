/*
 * Created by SharpDevelop.
 * User: Win10
 * Date: 31/01/2020
 * Time: 02:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;





namespace P3Proj15Grafos
{
	/// <summary>
	/// Description of ListaLigada.
	/// </summary>
	public class ListaLigada
	{
		private Nodo _primeiro;
		private int ramos = 0;
		
		public ListaLigada(Nodo Primeiro = null)
		{
			_primeiro = Primeiro;
			ramos += Primeiro != null ? 1 : 0;
		}
		
		public Nodo Primeiro {
			get {
				return _primeiro;
			}
			set {
				_primeiro = value;
			}
		}
		
		public void Add(int desc, int valor)
		{
			if(_primeiro == null)
			{
				if(valor == 0)
					return;
				_primeiro = new Nodo(desc,valor);
				ramos++;
				return;
			}
			if(_primeiro.Descendente == desc)
			{
				if(valor == 0)
				{
					_primeiro = _primeiro.Next != null ? _primeiro.Next : null;
					ramos--;
					return;
				}
				_primeiro.Valor = valor;
				return;
			}
			if(_primeiro.Next == null)
			{
				_primeiro.Next = new Nodo(desc,valor);
				ramos++;
				return;
			}
			if(desc < _primeiro.Descendente && valor != 0)
			{
				Nodo novo = new Nodo(desc,valor,_primeiro);
				_primeiro = novo;
				ramos++;
				return;
			}

			Nodo aux = _primeiro;
			while(aux.Next != null)
			{
				if(aux.Next.Descendente == desc)
				{
					if(valor == 0)
					{
						aux.Next = aux.Next.Next != null ? aux.Next.Next : null;
						ramos--;
						return;
					}
					aux.Next.Valor = valor;
					return;
				}
				if((desc > aux.Descendente && desc < aux.Next.Descendente) || aux.Next == null)
				{
					Nodo novo = new Nodo(desc,valor,aux.Next);
					aux.Next = novo;
					ramos++;
					return;
				}
				aux = aux.Next;
			}
			aux.Next = new Nodo(desc,valor);
			ramos++;
		}
		
		public int Count
		{
			get {
			return ramos;
			}
		}
		
		public bool Vazia 
		{
			get {
				return ramos == 0 ? true : false;
			}
		}
	}
}
