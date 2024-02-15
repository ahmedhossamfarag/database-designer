using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models
{
	internal class ActionsRecord
	{
		private Stack<(Action Undo, Action Redo)> Actions = new Stack<(Action Undo, Action Redo)>();
		private Stack<(Action Undo, Action Redo)> Undos = new Stack<(Action Undo, Action Redo)>();

		public void Add((Action Undo, Action Redo) d)
		{
			Actions.Push(d);
			Undos.Clear();
		}

		public void Undo()
		{
			if (Actions.Any())
			{
				(Action Undo, Action Redo) d = Actions.Pop();
				d.Undo?.Invoke();
				Undos.Push(d);
			}
		}

		public void Redo()
		{
			if (Undos.Any())
			{
				(Action Undo, Action Redo) d = Undos.Pop();
				d.Redo?.Invoke();
				Actions.Push(d);
			}
		}



	}
}
