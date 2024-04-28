using ShoppingModelLib;
using ShoppingModelLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLib
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        [ExcludeFromCodeCoverage]
        int GenerateId()
        {
            if (items.Count == 0)
                return 101;
            return items.Max(x => x.Id) + 1;
        }
        public override async Task<Cart> Add(Cart item)
        {
            item.Id = GenerateId();
            items.Add(item);
            return item;
        }
        public override async Task<Cart> Delete(int key)
        {
            Cart cart = await GetByKey(key);
            if (cart != null)
            {
                items.Remove(cart);
            }
            return cart;
        }

        public override async Task<Cart> GetByKey(int key)
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
        public override async Task<Cart> Update(Cart item)
        {
            Cart cart = await GetByKey(item.Id);
            if (cart != null)
            {
                return cart;
            }
            throw new NoCartWithGiveIdException();
        }

    }
}
