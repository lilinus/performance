// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BenchmarkDotNet.Attributes;
using MicroBenchmarks;
using Newtonsoft.Json.Linq;

namespace System.Tests
{
	[BenchmarkCategory(Categories.Libraries)]
	public class Perf_TestPr
	{
		public static IEnumerable<object> DateOnlyValues()
		{
			yield return DateOnly.FromDateTime(DateTime.Today);
		}

		[Benchmark, ArgumentsSource(nameof(DateOnlyValues))]
		public int DateOnly_Year(DateOnly value) => value.Year;

		[Benchmark, ArgumentsSource(nameof(DateOnlyValues))]
		public int DateOnly_Month(DateOnly value) => value.Month;

		[Benchmark, ArgumentsSource(nameof(DateOnlyValues))]
		public int DateOnly_Day(DateOnly value) => value.Day;

		[Benchmark, ArgumentsSource(nameof(DateOnlyValues))]
		public int DateOnly_DayOfYear(DateOnly value) => value.DayOfYear;

		[Benchmark, ArgumentsSource(nameof(DateOnlyValues))]
		public (int, int, int) DateOnly_Deconstruct(DateOnly value)
		{
			(int y, int m, int d) = value;
			return (y, m, d);
		}
	}
}
