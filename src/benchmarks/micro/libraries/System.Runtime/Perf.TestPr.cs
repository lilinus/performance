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
			yield return new object[] { new DateTime(123456789U), @"yyyy\-MM\-dd\.HH\.mm\.ss\.fff" };
			yield return new object[] { new DateTime(123456789U), @"yyyy\-MM\-dd\.HH\.mm\.ss\.FFFFF" };
		}
		[Benchmark, ArgumentsSource(nameof(DateTimeFormatValues))]
		public string DateTime_Format(DateTime arg1, string arg2) => arg1.ToString(arg2, CultureInfo.InvariantCulture);

		public static IEnumerable<object[]> TimeSpanFormatValues()
		{
			yield return new object[] { new TimeSpan(123456789U), @"d\.hh\.mm\.ss\.fffffff" };
			yield return new object[] { new TimeSpan(123456789U), @"d\.hh\.mm\.ss\.FFFFFFF" };
		}
		[Benchmark, ArgumentsSource(nameof(TimeSpanFormatValues))]
		public string TimeSpan_Format(TimeSpan arg1, string arg2) => arg1.ToString(arg2, CultureInfo.InvariantCulture);

		public static IEnumerable<object[]> DateTimeParseValues()
		{
			yield return new object[] { "2024-05-02.21.40.42.12345", @"yyyy\-MM\-dd\.HH\.mm\.ss\.fffff" };
			yield return new object[] { "2024-05-02.21.40.42.123", @"yyyy\-MM\-dd\.HH\.mm\.ss\.FFFFF" };
		}
		[Benchmark, ArgumentsSource(nameof(DateTimeParseValues))]
		public DateTime DateTime_Parse(string arg1, string arg2) => DateTime.ParseExact(arg1, arg2, CultureInfo.InvariantCulture);

		public static IEnumerable<object[]> TimeSpanParseValues()
		{
			yield return new object[] { "0.00.00.00.12345", @"d\.hh\.mm\.ss\.fffff" };
			yield return new object[] { "0.00.00.00.123", @"d\.hh\.mm\.ss\.FFFFF" };
		}
		[Benchmark, ArgumentsSource(nameof(TimeSpanParseValues))]
		public TimeSpan TimeSpan_Parse(string arg1, string arg2) => TimeSpan.ParseExact(arg1, arg2, CultureInfo.InvariantCulture);
	}
}
