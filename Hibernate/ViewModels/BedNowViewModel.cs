using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hibernate.ViewModels {
	public class BedNowViewModel : ViewModelBase {
		public ObservableCollection<string> Times { get; protected set; } = new ObservableCollection<string>();

		public ICommand CalculateCommand { get; protected set; }

		public BedNowViewModel() {
			CalculateCommand = new Command(CalculateBedTimes);
		}

		protected void CalculateBedTimes() {
			Times.Clear();

			// Takes ~14 mins for human to fall asleep
			var timeWhenAsleep = DateTime.Now.AddMinutes(14);
			var sleepCycleTime = new TimeSpan(1, 30, 0);

			for (int i = 0; i < 6; i++) {
				timeWhenAsleep = timeWhenAsleep.Add(sleepCycleTime);

				Times.Add(timeWhenAsleep.ToString("h:mm tt"));

			}
		}
	}
}
