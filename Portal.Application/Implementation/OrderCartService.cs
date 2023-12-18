using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;
using Portal.Infrastructure.Database;
using Portal.Infrastructure.Identity;

namespace Portal.Application.Implementation
{
    public class OrderCartService : IOrderCartService
    {
        const string totalPriceString = "TotalPrice";
        const string orderItemsString = "OrderItems";


        PortalDBContext _portalDbContext;

        public OrderCartService(PortalDBContext portalDbContext)
        {
            _portalDbContext = portalDbContext;
        }


        public double AddOrderItemsToSession(int? akceId, ISession session)
        {
            //get total price from session
            double totalPrice = session.GetDouble(totalPriceString).GetValueOrDefault();


            //geet product which should be added to cart/session
            Akce? akce = _portalDbContext.Akces.FirstOrDefault(akc => akc.Id == akceId);

            if (akce != null)
            {
                //get list of order items from session
                List<OrderItem> orderItems = session.GetObject<List<OrderItem>>(orderItemsString);
                OrderItem? orderItemInSession = null;
                //if the list is already in the session, find the order item with the akceId, otherwise, create new list
                if (orderItems != null)
                    orderItemInSession = orderItems.Find(oi => oi.AkceID == akce.Id);
                else
                    orderItems = new List<OrderItem>();


                //if there is order item with akceId, increase amount and price, otherwise, add new OrderItem
                if (orderItemInSession != null)
                {
                    ++orderItemInSession.Amount;
                    orderItemInSession.Price += akce.Price;
                }
                else
                {
                    //create order item with connected product and add it to the list
                    OrderItem orderItem = new OrderItem()
                    {
                        AkceID = akce.Id,
                        Akce = akce,
                        Amount = 1,
                        Price = akce.Price
                    };

                    orderItems.Add(orderItem);
                }

                //set the list to the session
                session.SetObject(orderItemsString, orderItems);

                //increase the total price and set it to the session
                totalPrice += akce.Price;
                session.SetDouble(totalPriceString, totalPrice);
            }

            //return total price
            return totalPrice;
        }


        public bool ApproveOrderInSession(int userId, ISession session)
        {
            //get order items from the session
            List<OrderItem> orderItems = session.GetObject<List<OrderItem>>(orderItemsString);
            if (orderItems != null)
            {

                //get total price from session
                double totalPrice = session.GetDouble(totalPriceString).GetValueOrDefault();

                //reference to the product must be null; otherwise, it tries to add it to the database again
                orderItems.ForEach(orderItem => orderItem.Akce = null);

                ////alternate option for the problem above
                //double totalPrice = 0;
                //foreach (OrderItem orderItem in orderItems)
                //{
                //    //recalculate total price (just to be sure; the total price is in the session too and the value should be same)
                //    totalPrice += orderItem.Product.Price * orderItem.Amount;
                //    //reference to the product must be null; otherwise, it tries to add it to the database again
                //    orderItem.Product = null;
                //}


                //create new order and connect it with the list of the order items
                Order order = new Order()
                {
                    DateTimeCreated = DateTime.UtcNow,
                    OrderNumber = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
                    TotalPrice = totalPrice,
                    OrderItems = orderItems,
                    UserId = userId
                };



                //We can add just the order; connected order items will be added automatically to the database.
                _portalDbContext.Add(order);
                _portalDbContext.SaveChanges();


                //remove the informations from the session
                session.Remove(orderItemsString);
                session.Remove(totalPriceString);


                //success
                return true;

            }


            //failure
            return false;
        }

    }
}

