using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SportsStore.Infrastructure;


namespace SportsStore.Models
{
    public class SessionCart: Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            var raw = session?.GetString("Cart");
            SessionCart cart = raw == null ? new SessionCart(): JsonConvert.DeserializeObject<SessionCart>(raw);
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetString("Cart", JsonConvert.SerializeObject(this));
        }

        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.SetString("Cart", JsonConvert.SerializeObject(this));
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}