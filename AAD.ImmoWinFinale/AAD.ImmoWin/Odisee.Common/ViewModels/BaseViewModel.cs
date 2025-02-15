﻿using Odisee.Common.Observables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odisee.Common.ViewModels
{
	public class BaseViewModel : ObservableObject
	{
		#region Properties

		#region Command properties

		#endregion

		#region Observable properties

		private String _title;
		public String Title
		{
			get { return _title; }
			set
			{
				SetProperty(ref _title, value);
			}
		}

		private Boolean _isEnabled;
		public Boolean IsEnabled
		{
			get { return _isEnabled; }
			set
			{
				SetProperty(ref _isEnabled, value);
			}
		}

		#endregion

		#endregion

		#region Constructors

		public BaseViewModel()
		{
			_title = "<no title>";
			_isEnabled = true;
		}

		#endregion

		#region Methods

		#endregion

		#region Interfaces

		#region Interfaces.IFormattable

		#endregion

		#endregion
	}
}
