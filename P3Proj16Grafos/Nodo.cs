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
	/// Description of Nodo.
	/// </summary>
	public class Nodo
	{
		private int _descendente;
		private int _valor;
		private Nodo _next;
		
		public Nodo(int desc, int valor, Nodo next = null)
		{
			_descendente = desc;
			_valor = valor;
			_next = next;
		}
		
		public int Descendente {
			get { 
				return _descendente;
			}
			set {
				_descendente = value;
			}
		}
		
		public int Valor {
			get { 
				return _valor;
			}
			set {
				_valor = value;
			}
		}
		
		public Nodo Next {
			get { 
				return _next;
			}
			set {
				_next = value;
			}
		}
	}
}