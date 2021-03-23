using System;

namespace Flx.ProjectName.Application.Exceptions
{
    /// <summary>
    /// Класс ошибки для @ProjectName.
    /// </summary>
    public class ProjectNameException : Exception
    {
        public int Status { get; }

        public ProjectNameException(int status = 500) : base()
        {
            Status = status;
        }

        public ProjectNameException(string message, int status = 500) : base(message)
        {
            Status = status;
        }
    }
}
