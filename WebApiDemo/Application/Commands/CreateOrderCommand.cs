using MediatR;

namespace WebApiDemo.Application.Commands
{
    public class CreateOrderCommand : IRequest<long>
    {
        public long ItemCount { get; private set; }

        public CreateOrderCommand(int itemCount) 
        { 
            ItemCount= itemCount;
        }
    }
}
