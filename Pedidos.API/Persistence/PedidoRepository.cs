using Pedidos.API.Models;

namespace Pedidos.API.Persistence
{
    public class PedidoRepository(PedidoDbContext dbContext)
    {
        public Pedido Add(Pedido pedido)
        {
            dbContext.Pedidos.Add(pedido);
            dbContext.SaveChanges();
            return pedido;
        }

        public Pedido? GetById(Guid id)
        {
            //dbContext.Pedidos.FirstOrDefault(p => p.Id == id);
            return dbContext.Pedidos.Find(id);
        }

        public List<Pedido> GetAll() {
            return dbContext.Pedidos.ToList();
        }
    }
}
