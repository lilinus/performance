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
		public static IEnumerable<object[]> Values()
		{
			yield return new object[] { new Guid(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), new Guid(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1) };
			yield return new object[] { new Guid(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), new Guid(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2) };
			yield return new object[] { new Guid(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), new Guid(1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1) };
			yield return new object[] { new Guid(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), new Guid(1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1) };
			yield return new object[] { new Guid(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), new Guid(1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1) };
			yield return new object[] { new Guid(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), new Guid(1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1) };
			yield return new object[] { new Guid(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), new Guid(1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1) };
			yield return new object[] { new Guid(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), new Guid(1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1) };
			yield return new object[] { new Guid(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), new Guid(1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1) };
			yield return new object[] { new Guid(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), new Guid(1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1) };
			yield return new object[] { new Guid(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), new Guid(1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1) };
			yield return new object[] { new Guid(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), new Guid(2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1) };
		}

		[Benchmark, ArgumentsSource(nameof(Values))]
		public int Guid_CompareTo(Guid left, Guid right) => left.CompareTo(right);

		[Benchmark, ArgumentsSource(nameof(Values))]
		public bool Guid_LessThan(Guid left, Guid right) => left < right;
	}
}
