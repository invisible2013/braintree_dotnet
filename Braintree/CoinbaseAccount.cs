using System;

namespace Braintree
{
    public class CoinbaseAccount : PaymentMethod
    {
        public String UserId { get; protected set; }
        public String UserEmail { get; protected set; }
        public String UserName { get; protected set; }
        public String Token { get; protected set; }
        public Boolean? IsDefault { get; protected set; }
        public String ImageUrl { get; protected set; }
        public DateTime? CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }
        public Subscription[] Subscriptions { get; protected set; }

        protected internal CoinbaseAccount(NodeWrapper node, BraintreeService service)
        {
            UserId = node.GetString("user-id");
            UserEmail = node.GetString("user-email");
            UserName = node.GetString("user-name");

            Token = node.GetString("token");
            IsDefault = node.GetBoolean("default");
            ImageUrl = node.GetString("image-url");

            CreatedAt = node.GetDateTime("created-at");
            UpdatedAt = node.GetDateTime("updated-at");

            var subscriptionXmlNodes = node.GetList("subscriptions/subscription");
            Subscriptions = new Subscription[subscriptionXmlNodes.Count];
            for (int i = 0; i < subscriptionXmlNodes.Count; i++)
            {
                Subscriptions[i] = new Subscription(subscriptionXmlNodes[i], service);
            }
        }
    }
}
