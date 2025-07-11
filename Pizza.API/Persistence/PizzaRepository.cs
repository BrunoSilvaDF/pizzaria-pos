﻿

using Pizza.API.Exceptions;

namespace Pizza.API.Persistence
{
    public class PizzaRepository(PizzaDbContext dbContext)
    {
        public List<Models.Pizza> GetAll()
        {
            return dbContext.Pizzas.ToList();
        }

        public Models.Pizza Add(Models.Pizza pizza)
        {
            dbContext.Pizzas.Add(pizza);
            dbContext.SaveChanges();
            
            return pizza;
        }

        public Models.Pizza GetById(int id)
        {
            var pizza = dbContext.Pizzas.FirstOrDefault(p => p.Id == id);

            if (pizza is null)
            {
                throw new NaoEncontradoException("Não tem pizza com este id");
            }

            return pizza;
        }
    }
}
