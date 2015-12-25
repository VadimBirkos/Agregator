using Bll.Interface;

namespace Bll.Implementation.Clients
{
    class VsemenuClient
    {
        private readonly IParser _parser;

        public VsemenuClient(IParser parser)
        {
            _parser = parser;
        }
    }
}
