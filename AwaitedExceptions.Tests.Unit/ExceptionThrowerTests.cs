using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AwaitedExceptions.Tests.Unit;

public class ExceptionThrowerTests
{
	private readonly ITestOutputHelper _testOutputHelper;

	public ExceptionThrowerTests(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public async Task NotAwaitedTest()
	{
		var exception = await Assert.ThrowsAsync<InvalidOperationException>(
			async () => await new ExceptionThrowerWrapper(new ExceptionThrower()).NotAwaitedWrapper());

		_testOutputHelper.WriteLine(exception.StackTrace);
		
		// We entirely get rid of the wrapper in the stack trace. It's like the wrapper doesn't exist at all. We don't
		// want that, see the AwaitedTest() for what's actually expected.
		Assert.DoesNotContain(nameof(ExceptionThrowerWrapper), exception.StackTrace);
	}

	[Fact]
	public async Task AwaitedTest()
	{
		var exception = await Assert.ThrowsAsync<InvalidOperationException>(
			async () => await new ExceptionThrowerWrapper(new ExceptionThrower()).AwaitedWrapper());

		_testOutputHelper.WriteLine(exception.StackTrace);
		
		// By awaiting in the wrapper as well, it gets included in the stack trace.
		Assert.Contains(nameof(ExceptionThrowerWrapper), exception.StackTrace);
	}
}
