#pragma warning disable xUnit1001
#pragma warning disable xUnit1009
#pragma warning disable xUnit1011
#pragma warning disable xUnit1026

using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class TestClass
{
    public static IEnumerable<object[]> GetData(int[] data1, int[] data2)
    {
        for (int i = 0; i < data1.Length; i++)
        {
            yield return new object[] { data1[i], data2[i] };
        }
    }

    [Theory]
    [MemberData(nameof(GetData), new int[] { 4, 5, 7 }, new int[] { 8, 10, 12 })]
    public void RunTest(int data1, int data2)
    {
        Assert.Equal(data1 * 2, data2);
    }
}

public class BasicTests
{
    [Fact]
    public void Passing()
    {
        Assert.True(true);
    }

    [Fact]
    public void Failing()
    {
        Assert.True(false);
    }

    [Theory]
    [InlineData(2112)]
    [InlineData("hello from v2x_net462")]
    [InlineData(null)]
    public void Theory(object value)
    {
        Assert.NotNull(value);
    }

    [Fact]
    public void InvalidFact(object x) { }  // Facts can't have parameters

    [Theory]
    [InlineData(42, "Hello World", 21.12)]  // Too much data
    [InlineData(2600)]                      // Not enough data
    public void InvalidTheory(int x, string y) { }

#pragma warning disable xUnit1048 // Avoid using 'async void' for test methods as it is deprecated in xUnit.net v3

    [Fact]
    public async void FailingAsyncVoidTest()
    {
        await Task.Delay(0);
        Assert.True(false);
    }

#pragma warning restore xUnit1048 // Avoid using 'async void' for test methods as it is deprecated in xUnit.net v3

    [Fact]
    public async Task FailingAsyncTaskTest()
    {
        await Task.Delay(0);
        Assert.True(false);
    }
}
