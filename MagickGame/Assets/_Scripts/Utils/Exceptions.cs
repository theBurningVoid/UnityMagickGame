using System;

public struct Exceptions
{
	public class InsufficientComponentRequisiteException : ApplicationException{
		public InsufficientComponentRequisiteException(String message) : base(message){}
	}

	public class ComponentListModifyException : ApplicationException {
		public ComponentListModifyException(String message) : base(message) {}
	}
}
