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
		public static IEnumerable<object[]> DateTimeFormatValues()
		{
			yield return new object[] { new DateTime(12345678900L), @"yyyy\-MM\-dd\.HH\.mm\.ss\.FFFFFFF" };
		}
		[Benchmark, ArgumentsSource(nameof(DateTimeFormatValues))]
		public string DateTime_Format(DateTime value, string fmt) => value.ToString(fmt, CultureInfo.InvariantCulture);

		public static IEnumerable<object[]> TimeSpanFormatValues()
		{
			yield return new object[] { new TimeSpan(12345678900L), @"d\.hh\.mm\.ss\.FFFFFFF" };
			yield return new object[] { new TimeSpan(12345678900L), "g" };
			yield return new object[] { new TimeSpan(12345678900L), "G" };
		}
		[Benchmark, ArgumentsSource(nameof(TimeSpanFormatValues))]
		public string TimeSpan_Format(TimeSpan value, string fmt) => value.ToString(fmt, CultureInfo.InvariantCulture);
	}
}
