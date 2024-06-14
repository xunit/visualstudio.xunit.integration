using System;
using Xunit;

public class FailingFixture : IDisposable
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}

public class ClassFixtureFailure : IClassFixture<FailingFixture>
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
}

[CollectionDefinition("MyCollection")]
public class MyCollection : ICollectionFixture<FailingFixture>
{
}

[Collection("MyCollection")]
public class CollectionFixtureFailure
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
}
