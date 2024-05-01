// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using MicroBenchmarks;
using Newtonsoft.Json.Linq;

namespace System.Tests
{
	[BenchmarkCategory(Categories.Libraries)]
	public class Perf_TestPr
	{
		private const int iterations = 100;
		public static IEnumerable<object[]> Values()
		{
			yield return new object[] { Int128.MinValue, Int128.One };
			yield return new object[] { -Int128.One, Int128.One };
			yield return new object[] { Int128.Zero, Int128.One };
			yield return new object[] { Int128.One, Int128.One };
			yield return new object[] { Int128.MaxValue, Int128.One };
			yield return new object[] { Int128.MinValue, -Int128.One };
			yield return new object[] { -Int128.One, -Int128.One };
			yield return new object[] { Int128.Zero, -Int128.One };
			yield return new object[] { Int128.One, -Int128.One };
			yield return new object[] { Int128.MaxValue, -Int128.One };
		}

		[Benchmark, ArgumentsSource(nameof(Values))]
		public void op_GreaterThan(Int128 val1, Int128 val2)
		{
			for (int i = 0; i < iterations; i++)
				_ = val1 > val2;
		}
	}
}
