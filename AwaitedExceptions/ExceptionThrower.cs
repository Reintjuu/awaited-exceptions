using System;
using System.Threading.Tasks;

namespace AwaitedExceptions;

public class ExceptionThrower
{
	public async Task ThrowInvalidOperationExceptionAfterSmallDelay()
	{
		await Task.Delay(1);

		throw new InvalidOperationException("Just for the fun of it.");
	}
}
