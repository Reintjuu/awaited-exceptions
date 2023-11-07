using System.Threading.Tasks;

namespace AwaitedExceptions;

public class ExceptionThrowerWrapper
{
	private readonly ExceptionThrower _exceptionThrower;

	public ExceptionThrowerWrapper(ExceptionThrower exceptionThrower)
	{
		_exceptionThrower = exceptionThrower;
	}
	
	public async Task AwaitedWrapper()
	{
		await _exceptionThrower.ThrowInvalidOperationExceptionAfterSmallDelay();
	}
	
	public Task NotAwaitedWrapper()
	{
		return _exceptionThrower.ThrowInvalidOperationExceptionAfterSmallDelay();
	}
}
