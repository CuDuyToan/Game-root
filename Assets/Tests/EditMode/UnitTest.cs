using NUnit.Framework;

public class UnitTest
{
    [Test]
    public void Test_Add()
    {
        int result = 2 + 3;

        Assert.AreEqual(5, result);
    }
}