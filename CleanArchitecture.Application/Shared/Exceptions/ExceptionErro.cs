

namespace CleanArchitecture.Application.Shared.Exceptions
{
    public class ExceptionErro : Exception
    {
        public int CodigoErro { get; }

        public ExceptionErro() { }

        public ExceptionErro(string message) : base(message) { }

        public ExceptionErro(string message, Exception innerException) : base(message, innerException) { }

        public ExceptionErro(string message, int _codigoErro) : base(message)
        {
            CodigoErro = _codigoErro;
        }
    }
}
