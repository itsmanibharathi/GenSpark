﻿using ShoppingModelLib;
using ShoppingModelLib.Exceptions;

namespace ShoppingDALLib
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        public override Customer Delete(int key)
        {
            Customer customer = GetByKey(key);
            if (customer != null)
            {
                items.Remove(customer);
            }
            return customer;
        }

        public override Customer GetByKey(int key)
        {
            if(items.Count == 0)
                throw new EmptyDataBaseException();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new NoCustomerWithGiveIdException();
        }

        public override Customer Update(Customer item)
        {
            Customer customer = GetByKey(item.Id);
            if (customer != null)
            {
                customer = item;
            }
            return customer;
        }
    }
}