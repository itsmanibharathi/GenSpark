﻿using ShoppingModelLib;
using ShoppingModelLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLib
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        public override Cart Delete(int key)
        {
            Cart cart = GetByKey(key);
            if (cart != null)
            {
                items.Remove(cart);
            }
            return cart;
        }

        public override Cart GetByKey(int key)
        {
            if (items.Count == 0)
                throw new EmptyDataBaseException();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new NoCartWithGiveIdException();
        }

        public override Cart Update(Cart item)
        {
            Cart cart = GetByKey(item.Id);
            if (cart != null)
            {
                cart = item;
            }
            return cart;
        }

    }
}
