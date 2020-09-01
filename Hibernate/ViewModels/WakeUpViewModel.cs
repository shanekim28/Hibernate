using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms.Internals;

namespace Hibernate.ViewModels {
	public class WakeUpViewModel : ViewModelBase {
		public ObservableCollection<string> Times { get; set; } = new ObservableCollection<string>();

		private TimeSpan selectedTime;
		public TimeSpan SelectedTime {
			get {
				return selectedTime;
			}
			set {
				SetValue(ref selectedTime, value);
				CalculateSleepTimes(selectedTime);
			} 
		}

		protected void CalculateSleepTimes(TimeSpan endtime) {
			Times.Clear();

			var wakeUpTime = DateTime.Today.AddDays(1) + endtime;

			var sleepCycleTime = new TimeSpan(1, 30, 0);

			for (int i = 0; i < 6; i++) {
				var sleepTime = wakeUpTime.Add(-sleepCycleTime);

				Times.Insert(0, sleepTime.AddMinutes(-14).ToString("h:mm tt"));
				wakeUpTime = sleepTime;
			}
		}

		public WakeUpViewModel() {
			CalculateSleepTimes(new TimeSpan(0, 0, 0));
		}


	}
}
