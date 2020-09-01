using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Hibernate.ViewModels {
	public class ViewModelBase : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null) {
			// Nothing changed, return
			if (EqualityComparer<T>.Default.Equals(backingField, value)) return;

			// Set the value and raise event
			backingField = value;
			OnPropertyChanged(propertyName);
		}
	}
}
