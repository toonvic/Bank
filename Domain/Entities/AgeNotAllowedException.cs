namespace Domain.Entities;

public class AgeNotAllowedException : Exception
{
	public AgeNotAllowedException()
		: base("Age is not allowed.")
	{ }
}
