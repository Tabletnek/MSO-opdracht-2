﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_3
{
	internal interface IRepeat : ITask
	{
		List<ITask> tasks { get; }
	}
}