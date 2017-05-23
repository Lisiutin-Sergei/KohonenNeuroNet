using System;
using System.Windows.Forms;

namespace KohonenNeuroNet.Interface
{
	/// <summary>
	/// Обработчик смены куросора.
	/// </summary>
	public class CursorHandler : IDisposable
	{
		private Cursor _saved;

		public CursorHandler(Cursor cursor = null)
		{
			_saved = Cursor.Current;
			Cursor.Current = cursor ?? Cursors.WaitCursor;
		}

		public void Dispose()
		{
			if (_saved != null)
			{
				Cursor.Current = _saved;
				_saved = null;
			}
		}
	}
}
