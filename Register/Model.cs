// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 02-08-2017
//
// Last Modified By : Seungkeun
// Last Modified On : 02-08-2017
// ***********************************************************************
// <copyright file="Model.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Windows.Forms;

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class POSOrder.
    /// </summary>
    public class POSOrder
    {

        /// <summary>
        /// Enum OrderStatus
        /// </summary>
        public enum OrderStatus
        {
            /// <summary>
            /// The pending
            /// </summary>
            /// <summary>
            /// The open
            /// </summary>
            /// <summary>
            /// The closed
            /// </summary>
            /// <summary>
            /// The locked
            /// </summary>
            /// <summary>
            /// The authorized
            /// </summary>
            /// <summary>
            /// The partially refunded
            /// </summary>
            /// <summary>
            /// The partially paid
            /// </summary>
            PENDING, OPEN, CLOSED, LOCKED, AUTHORIZED, PARTIALLY_REFUNDED, PARTIALLY_PAID
        }
        /// <summary>
        /// Enum OrderChangeTarget
        /// </summary>
        public enum OrderChangeTarget
        {
            /// <summary>
            /// The order
            /// </summary>
            /// <summary>
            /// The item
            /// </summary>
            /// <summary>
            /// The payment
            /// </summary>
            ORDER, ITEM, PAYMENT
        }

        /// <summary>
        /// Delegate OrderDataChangeHandler
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="target">The target.</param>
        public delegate void OrderDataChangeHandler(POSOrder order, OrderChangeTarget target);
        public event OrderDataChangeHandler OrderChange;
        /// <summary>
        /// Ons the order change.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="target">The target.</param>
        protected void onOrderChange(POSOrder order, OrderChangeTarget target)
        {
            if (order.status == OrderStatus.PENDING &&
                order.Items.Count > 0)
            {
                order.status = OrderStatus.OPEN;
            }
            if (OrderChange != null)
            {
                OrderChange(order, target);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="POSOrder"/> class.
        /// </summary>
        public POSOrder()
        {
            Status = OrderStatus.PENDING;
            Items = new List<POSLineItem>();
            Payments = new List<POSExchange>();
            Discount = new POSDiscount("None", 0);
            Date = new DateTime();
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public List<POSLineItem> Items { get; internal set; }
        /// <summary>
        /// Gets the payments.
        /// </summary>
        /// <value>The payments.</value>
        public List<POSExchange> Payments { get; internal set; }
        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public POSDiscount Discount
        {
            get { return discount; }
            set
            {
                if (discount != value)
                {
                    discount = value;
                    onOrderChange(this, OrderChangeTarget.ORDER);
                }
            }
        }
        /// <summary>
        /// The status
        /// </summary>
        private OrderStatus status;
        /// <summary>
        /// The discount
        /// </summary>
        private POSDiscount discount;
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string ID { set; get; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public DateTime Date { set; get; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public OrderStatus Status {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    onOrderChange(this, OrderChangeTarget.ORDER);
                }
            }
        }

        /// <summary>
        /// Adds the order line item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddOrderLineItem(POSLineItem item)
        {
            this.Items.Add(item);
            onOrderChange(this, OrderChangeTarget.ITEM);
        }

        /// <summary>
        /// Adds the order payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        public void AddOrderPayment(POSPayment payment)
        {
            this.Payments.Add(payment);
            onOrderChange(this, OrderChangeTarget.PAYMENT);
        }
        /// <summary>
        /// Modifies the tip amount.
        /// </summary>
        /// <param name="paymentID">The payment identifier.</param>
        /// <param name="amount">The amount.</param>
        public void ModifyTipAmount(String paymentID, long amount)
        {
            foreach(Object paymentObject in Payments) {
                if (paymentObject is POSPayment && ((POSPayment)paymentObject).PaymentID == paymentID)
                {
                    ((POSPayment)paymentObject).TipAmount = amount;
                    onOrderChange(this, OrderChangeTarget.PAYMENT);
                }
            }
        }
        /// <summary>
        /// Modifies the payment status.
        /// </summary>
        /// <param name="paymentID">The payment identifier.</param>
        /// <param name="status">The status.</param>
        public void ModifyPaymentStatus(string paymentID, POSPayment.Status status)
        {
            foreach (Object paymentObject in Payments)
            {
                if (paymentObject is POSPayment && ((POSPayment)paymentObject).PaymentID == paymentID)
                {
                    ((POSPayment)paymentObject).PaymentStatus = status;
                    onOrderChange(this, OrderChangeTarget.PAYMENT);
                }
            }

        }

        /// <summary>
        /// Gets the pre discount sub total.
        /// </summary>
        /// <value>The pre discount sub total.</value>
        public long PreDiscountSubTotal
        {
            get
            {
                long sub = 0;
                foreach (POSLineItem li in Items)
                {
                    sub += li.Price * li.Quantity;
                }
                return sub;
            }
        }
        /// <summary>
        /// Gets the pre tax sub total.
        /// </summary>
        /// <value>The pre tax sub total.</value>
        public long PreTaxSubTotal {
            get
            {
                long sub = 0;
                foreach(POSLineItem li in Items)
                {
                    sub += li.Price * li.Quantity ;
                }
                if(Discount != null)
                {
                    sub = Discount.AppliedTo(sub);
                }
                return sub;
            }
        }
        /// <summary>
        /// Gets the tippable amount.
        /// </summary>
        /// <value>The tippable amount.</value>
        public long TippableAmount
        {
            get
            {
                long tippableAmount = 0;
                foreach(POSLineItem li in Items)
                {
                    if (li.Item.Tippable)
                    {
                        tippableAmount += li.Price * li.Quantity;
                    }
                }
                if (Discount != null)
                {
                    tippableAmount = Discount.AppliedTo(tippableAmount);
                }
                return tippableAmount + TaxAmount; // should match Total if there aren't any "non-tippable" items
            }
        }
        /// <summary>
        /// Gets the taxable subtotal.
        /// </summary>
        /// <value>The taxable subtotal.</value>
        public long TaxableSubtotal
        {
            get
            {
                long sub = 0;
                foreach (POSLineItem li in Items)
                {
                    if(li.Item.Taxable)
                    {
                        sub += li.Price * li.Quantity;
                    }
                }
                if (Discount != null)
                {
                    sub = Discount.AppliedTo(sub);
                }
                return sub;
            }
        }
        /// <summary>
        /// Gets the tax amount.
        /// </summary>
        /// <value>The tax amount.</value>
        public long TaxAmount {
            get
            {
                return (int)(TaxableSubtotal * 0.07);
            }
        }
        /// <summary>
        /// Gets the total.
        /// </summary>
        /// <value>The total.</value>
        public long Total
        {
            get
            {
                return PreTaxSubTotal + TaxAmount;
            }
        }
        /// <summary>
        /// Tipses this instance.
        /// </summary>
        /// <returns>System.Int64.</returns>
        public long Tips()
        {
            long tips = 0;
            foreach(POSPayment posPayment in Payments)
            {
                tips += posPayment.TipAmount;
            }
            return tips;
        }


        /// <summary>
        /// manages adding a POSItem to an order. If the POSItem already exists, the quantity is just incremented
        /// </summary>
        /// <param name="i"></param>
        /// <param name="quantity"></param>
        /// <returns>The POSLineItem for the POSItem. Will either return a new one, or an existing with its quantity incremented</returns>
        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>POSLineItem.</returns>
        public POSLineItem AddItem(POSItem i, int quantity)
        {
            bool exists = false;
            POSLineItem targetItem = null;
            foreach(POSLineItem lineI in Items)
            {
                if(lineI.Item.ID == i.ID)
                {
                    exists = true;
                    lineI.Quantity += quantity;
                    targetItem = lineI;
                    break;
                }
            }
            if(!exists)
            {
                POSLineItem li = new POSLineItem();
                li.Quantity = quantity;
                li.Item = i;
                targetItem = li;
                Items.Add(li);
            }
            onOrderChange(this, OrderChangeTarget.ITEM);
            return targetItem;
        }

        /// <summary>
        /// Adds the payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        public void AddPayment(POSPayment payment)
        {
            Payments.Add(payment);
            onOrderChange(this, OrderChangeTarget.PAYMENT);
        }

        /// <summary>
        /// Adds the refund.
        /// </summary>
        /// <param name="refund">The refund.</param>
        public void AddRefund(POSRefund refund)
        {
            foreach(POSExchange pay in Payments)
            {
                if(pay is POSPayment)
                {
                    if (pay.PaymentID == refund.PaymentID)
                    {
                        ((POSPayment)pay).PaymentStatus = POSPayment.Status.REFUNDED;

                    }

                }
            }
            Payments.Add(refund);
            onOrderChange(this, OrderChangeTarget.PAYMENT);
        }

        /// <summary>
        /// Removes the item.
        /// </summary>
        /// <param name="selectedLineItem">The selected line item.</param>
        internal void RemoveItem(POSLineItem selectedLineItem)
        {
            Items.Remove(selectedLineItem);
            onOrderChange(this, OrderChangeTarget.ITEM);
        }

    }

    /// <summary>
    /// Class POSCard.
    /// </summary>
    public class POSCard
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the first6.
        /// </summary>
        /// <value>The first6.</value>
        public string First6 { get; set; }
        /// <summary>
        /// Gets or sets the last4.
        /// </summary>
        /// <value>The last4.</value>
        public string Last4 { get; set; }
        /// <summary>
        /// Gets or sets the month.
        /// </summary>
        /// <value>The month.</value>
        public string Month { get; set; }
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        public string Year { get; set; }
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        public string Token { get; set; }
    }

    /// <summary>
    /// Class POSExchange.
    /// </summary>
    public class POSExchange
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="POSExchange"/> class.
        /// </summary>
        /// <param name="paymentID">The payment identifier.</param>
        /// <param name="orderID">The order identifier.</param>
        /// <param name="employeeID">The employee identifier.</param>
        /// <param name="amount">The amount.</param>
        public POSExchange(string paymentID, string orderID, string employeeID, long amount)
        {
            PaymentID = paymentID;
            OrderID = orderID;
            EmployeeID = employeeID;
            Amount = amount;
        }

        /// <summary>
        /// Gets or sets the payment identifier.
        /// </summary>
        /// <value>The payment identifier.</value>
        public string PaymentID { get; set; }
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        public string OrderID { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        public string EmployeeID { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public long Amount { get; set; }
    }

    /// <summary>
    /// Class POSRefund.
    /// </summary>
    /// <seealso cref="Register.POSExchange" />
    public class POSRefund : POSExchange
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="POSRefund"/> class.
        /// </summary>
        /// <param name="refundID">The refund identifier.</param>
        /// <param name="paymentID">The payment identifier.</param>
        /// <param name="orderID">The order identifier.</param>
        /// <param name="employeeID">The employee identifier.</param>
        /// <param name="amount">The amount.</param>
        public POSRefund(string refundID, string paymentID, string orderID, string employeeID, long amount) : base(paymentID, orderID, employeeID, amount)
        {
            RefundID = refundID;
        }
        /// <summary>
        /// Gets or sets the refund identifier.
        /// </summary>
        /// <value>The refund identifier.</value>
        public string RefundID { get; set; }
    }

    /// <summary>
    /// Class POSManualRefund.
    /// </summary>
    public class POSManualRefund 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="POSManualRefund"/> class.
        /// </summary>
        /// <param name="creditID">The credit identifier.</param>
        /// <param name="orderID">The order identifier.</param>
        /// <param name="amount">The amount.</param>
        public POSManualRefund(string creditID, string orderID, long amount)
        {
            CreditID = creditID;
            OrderID = orderID;
            Amount = amount;
        }
        /// <summary>
        /// Gets or sets the credit identifier.
        /// </summary>
        /// <value>The credit identifier.</value>
        public string CreditID { get; set; }
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        public string OrderID { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public long Amount { get; set; }
    }

    /// <summary>
    /// Class POSPayment.
    /// </summary>
    /// <seealso cref="Register.POSExchange" />
    public class POSPayment : POSExchange
    {
        /// <summary>
        /// Enum Status
        /// </summary>
        public enum Status
        {
            /// <summary>
            /// The paid
            /// </summary>
            /// <summary>
            /// The voided
            /// </summary>
            /// <summary>
            /// The refunded
            /// </summary>
            /// <summary>
            /// The authorized
            /// </summary>
            PAID, VOIDED, REFUNDED, AUTHORIZED
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="POSPayment"/> class.
        /// </summary>
        /// <param name="paymentID">The payment identifier.</param>
        /// <param name="orderID">The order identifier.</param>
        /// <param name="employeeID">The employee identifier.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="tip">The tip.</param>
        /// <param name="cashBack">The cash back.</param>
        public POSPayment(string paymentID, string orderID, string employeeID, long amount, long tip = 0, long cashBack = 0) : base(paymentID, orderID, employeeID, amount)
        {
            TipAmount = tip;
            CashBackAmount = cashBack;
            OrderID = orderID;
            EmployeeID = employeeID;
            
        }

        /// <summary>
        /// The status
        /// </summary>
        private Status _status;

        /// <summary>
        /// Gets or sets the payment status.
        /// </summary>
        /// <value>The payment status.</value>
        public Status PaymentStatus
        {
            get
            {
                return _status;
            }
            set
            {
                if(_status != value)
                {
                    _status = value;
                }
            }
        }
        /// <summary>
        /// Gets a value indicating whether this <see cref="POSPayment"/> is voided.
        /// </summary>
        /// <value><c>true</c> if voided; otherwise, <c>false</c>.</value>
        public bool Voided {
            get
            {
                return _status == Status.VOIDED;
            }
        }
        /// <summary>
        /// Gets a value indicating whether this <see cref="POSPayment"/> is refunded.
        /// </summary>
        /// <value><c>true</c> if refunded; otherwise, <c>false</c>.</value>
        public bool Refunded
        {
            get
            {
                return _status == Status.REFUNDED;
            }
        }

        /// <summary>
        /// Gets or sets the tip amount.
        /// </summary>
        /// <value>The tip amount.</value>
        public long TipAmount { get; set; }
        /// <summary>
        /// Gets or sets the cash back amount.
        /// </summary>
        /// <value>The cash back amount.</value>
        public long CashBackAmount { get; set; }
    }

    /// <summary>
    /// Class POSLineItem.
    /// </summary>
    public class POSLineItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="POSLineItem"/> class.
        /// </summary>
        public POSLineItem()
        {
            Quantity = 1;
            ID = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public POSLineItemDiscount Discount { get; set; }
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string ID { get; internal set; }
        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>The item.</value>
        public POSItem Item
        {
            set; get;
        }
        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <value>The price.</value>
        public long Price {
            get
            {
                if(Discount != null)
                {
                    return Item.Price - Discount.Value(Item);
                }
                else
                {
                    return Item.Price;
                }
            }
        }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public int Quantity
        {
            set; get;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="ListViewItem"/> to <see cref="POSLineItem"/>.
        /// </summary>
        /// <param name="v">The v.</param>
        /// <returns>The result of the conversion.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public static implicit operator POSLineItem(ListViewItem v)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Class POSItem.
    /// </summary>
    public class POSItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="POSItem"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="price">The price.</param>
        /// <param name="taxable">if set to <c>true</c> [taxable].</param>
        /// <param name="tippable">if set to <c>true</c> [tippable].</param>
        public POSItem(string id, string name, long price, bool taxable = true, bool tippable = true)
        {
            ID = id;
            Name = name;
            Price = price;
            Taxable = taxable;
            Tippable = tippable;
        }
        /// <summary>
        /// Gets a value indicating whether this <see cref="POSItem"/> is tippable.
        /// </summary>
        /// <value><c>true</c> if tippable; otherwise, <c>false</c>.</value>
        public bool Tippable { get; internal set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="POSItem"/> is taxable.
        /// </summary>
        /// <value><c>true</c> if taxable; otherwise, <c>false</c>.</value>
        public bool Taxable { get; set; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string ID { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public long Price { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public String Name { get; set; }
        
    }

    /// <summary>
    /// Class POSDiscount.
    /// </summary>
    public class POSDiscount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="POSDiscount"/> class.
        /// </summary>
        public POSDiscount()
        {
            Name = "";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="POSDiscount"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="percentOff">The percent off.</param>
        public POSDiscount(string name, float percentOff) : this()
        {
            Name = name;
            PercentageOff = percentOff;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="POSDiscount"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="amountOff">The amount off.</param>
        public POSDiscount(string name, long amountOff) : this()
        {
            Name = name;
            AmountOff = amountOff;
        }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// The amount off
        /// </summary>
        private long _amountOff = 0;
        /// <summary>
        /// Gets or sets the amount off.
        /// </summary>
        /// <value>The amount off.</value>
        public long AmountOff
        {
            get
            {
                return _amountOff;
            }
            set
            {
                _percentageOff = 0.0f;
                _amountOff = value;
            }
        }
        /// <summary>
        /// The percentage off
        /// </summary>
        private float _percentageOff = 0.0f;
        /// <summary>
        /// Gets or sets the percentage off.
        /// </summary>
        /// <value>The percentage off.</value>
        public float PercentageOff
        {
            get
            {
                return _percentageOff;
            }
            set
            {
                _amountOff = 0;
                _percentageOff = value;
            }
        }

        /// <summary>
        /// Applieds to.
        /// </summary>
        /// <param name="sub">The sub.</param>
        /// <returns>System.Int64.</returns>
        internal long AppliedTo(long sub)
        {
            if(AmountOff == 0)
            {
                sub = (long)Math.Round(sub - (sub * PercentageOff));
            }
            else
            {
                sub -= AmountOff;
            }
            return Math.Max(sub, 0);
        }

        /// <summary>
        /// Values the specified sub.
        /// </summary>
        /// <param name="sub">The sub.</param>
        /// <returns>System.Int64.</returns>
        public long Value(long sub)
        {
            long value = AmountOff;
            if (AmountOff == 0)
            {
                value = (long)Math.Round(sub * PercentageOff);
            }

            return value;
        }
    }

    /// <summary>
    /// Class POSOrderDiscount.
    /// </summary>
    /// <seealso cref="Register.POSDiscount" />
    public class POSOrderDiscount : POSDiscount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="POSOrderDiscount"/> class.
        /// </summary>
        /// <param name="fixedDiscountAmount">The fixed discount amount.</param>
        /// <param name="name">The name.</param>
        public POSOrderDiscount(long fixedDiscountAmount, string name)
        {
            AmountOff = fixedDiscountAmount;
            Name = name;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="POSOrderDiscount"/> class.
        /// </summary>
        /// <param name="percentageOff">The percentage off.</param>
        /// <param name="name">The name.</param>
        public POSOrderDiscount(float percentageOff, string name)
        {
            PercentageOff = percentageOff;
            Name = name;
        }

        /// <summary>
        /// Values the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>System.Int64.</returns>
        public long Value(POSOrder order)
        {
            if (AmountOff > 0)
            {
                return AmountOff;
            }
            else
            {
                return (int)(order.PreTaxSubTotal * PercentageOff);
            }
        }

    }

    /// <summary>
    /// Class POSLineItemDiscount.
    /// </summary>
    /// <seealso cref="Register.POSDiscount" />
    public class POSLineItemDiscount : POSDiscount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="POSLineItemDiscount"/> class.
        /// </summary>
        /// <param name="fixedDiscountAmount">The fixed discount amount.</param>
        /// <param name="name">The name.</param>
        public POSLineItemDiscount(long fixedDiscountAmount, string name)
        {
            AmountOff = fixedDiscountAmount;
            Name = name;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="POSLineItemDiscount"/> class.
        /// </summary>
        /// <param name="percentageOff">The percentage off.</param>
        /// <param name="name">The name.</param>
        public POSLineItemDiscount(float percentageOff, string name)
        {
            PercentageOff = percentageOff;
            Name = name;
        }

        /// <summary>
        /// Values the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>System.Int64.</returns>
        public long Value(POSItem item)
        {
            if(AmountOff > 0)
            {
                return AmountOff;
            }
            else
            {
                return (int)(item.Price * PercentageOff);
            }
        }
    }

    /// <summary>
    /// Class Store.
    /// </summary>
    public class Store
    {
        /// <summary>
        /// The order number
        /// </summary>
        private static int orderNumber = 1000;

        /// <summary>
        /// Initializes a new instance of the <see cref="Store"/> class.
        /// </summary>
        public Store()
        {
            AvailableItems = new List<POSItem>();
            AvailableDiscounts = new List<POSDiscount>();
            Orders = new List<POSOrder>();
            NewDiscount = false;
            Cards = new List<POSCard>();
            PreAuths = new List<POSPayment>();
        }

        /// <summary>
        /// Gets or sets the cards.
        /// </summary>
        /// <value>The cards.</value>
        public List<POSCard> Cards { set; get; }
        /// <summary>
        /// Gets or sets the pre auths.
        /// </summary>
        /// <value>The pre auths.</value>
        public List<POSPayment> PreAuths { set; get; }
        /// <summary>
        /// Gets or sets the available items.
        /// </summary>
        /// <value>The available items.</value>
        public List<POSItem> AvailableItems { set; get; }
        /// <summary>
        /// Gets or sets the available discounts.
        /// </summary>
        /// <value>The available discounts.</value>
        public List<POSDiscount> AvailableDiscounts { set; get; }
        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>The orders.</value>
        public List<POSOrder> Orders { set; get; }
        /// <summary>
        /// Gets or sets the current order.
        /// </summary>
        /// <value>The current order.</value>
        public POSOrder CurrentOrder { set; get; }
        /// <summary>
        /// Gets or sets the new discount.
        /// </summary>
        /// <value>The new discount.</value>
        public Boolean NewDiscount { set; get; }

        /// <summary>
        /// Enum OrderListAction
        /// </summary>
        public enum OrderListAction
        {
            /// <summary>
            /// The added
            /// </summary>
            /// <summary>
            /// The removed
            /// </summary>
            /// <summary>
            /// The updated
            /// </summary>
            ADDED, REMOVED, UPDATED
        }

        /// <summary>
        /// Enum PreAuthAction
        /// </summary>
        public enum PreAuthAction
        {
            /// <summary>
            /// The added
            /// </summary>
            /// <summary>
            /// The removed
            /// </summary>
            ADDED, REMOVED
        }


        /// <summary>
        /// Delegate OrderListChangeHandler
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="action">The action.</param>
        public delegate void OrderListChangeHandler(Store store, OrderListAction action);
        public event OrderListChangeHandler OrderListChange;
        /// <summary>
        /// Delegate PreAuthListChangeHandler
        /// </summary>
        /// <param name="payment">The payment.</param>
        /// <param name="action">The action.</param>
        public delegate void PreAuthListChangeHandler(POSPayment payment, PreAuthAction action);
        public event PreAuthListChangeHandler PreAuthListChange;
        /// <summary>
        /// Ons the order list change.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="action">The action.</param>
        protected void onOrderListChange(Store store, OrderListAction action)
        {
            if (OrderListChange != null)
            {
                OrderListChange(store, action);
            }
        }
        /// <summary>
        /// Creates the order.
        /// </summary>
        public void CreateOrder()
        {
            //Get rid of any prior pending orders, before creating a new one
            DeletePendingOrder();
            POSOrder order = new POSOrder();
            order.ID = "" + (++orderNumber);
            CurrentOrder = order;
            AddOrder(order);
        }
        /// <summary>
        /// Called when [pre authentication changed].
        /// </summary>
        /// <param name="payment">The payment.</param>
        /// <param name="action">The action.</param>
        protected void OnPreAuthChanged(POSPayment payment, PreAuthAction action)
        {
            if (PreAuthListChange != null)
            {
                PreAuthListChange(payment, action);
            }
        }

        /*  This will remove any other PENDING order before creating a new one. */
        /// <summary>
        /// Deletes the pending order.
        /// </summary>
        private void DeletePendingOrder()
        {
            POSOrder delOrder = null;
            foreach (POSOrder order in Orders) {
                if (order.Status == POSOrder.OrderStatus.PENDING)
                {
                    delOrder = order;
                    break;
                }
            }
            if (delOrder != null)
            {
                Orders.Remove(delOrder); //This shouldn't trigger a onOrderListChange, as PENDING orders aren't displayed
                delOrder = null;
            }
        }
        /// <summary>
        /// Adds the pre authentication.
        /// </summary>
        /// <param name="payment">The payment.</param>
        public void AddPreAuth(POSPayment payment)
        {
            PreAuths.Add(payment);
            OnPreAuthChanged(payment, PreAuthAction.ADDED);
        }
        /// <summary>
        /// Removes the pre authentication.
        /// </summary>
        /// <param name="payment">The payment.</param>
        public void RemovePreAuth(POSPayment payment)
        {
            if(PreAuths.Remove(payment))
            {
                OnPreAuthChanged(payment, PreAuthAction.REMOVED);
            }
        }
        /// <summary>
        /// Adds the order.
        /// </summary>
        /// <param name="order">The order.</param>
        public void AddOrder(POSOrder order)
        {
            Orders.Add(order);
            onOrderListChange(this, OrderListAction.ADDED);
        }
        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <param name="paymentID">The payment identifier.</param>
        /// <returns>POSOrder.</returns>
        public POSOrder GetOrder(String paymentID)
        {
            foreach (POSOrder order in Orders)
            {
                foreach (Object payment in order.Payments) // payments can be POSPayment or POSRefund
                {
                    if (payment is POSPayment && ((POSPayment)payment).PaymentID == paymentID)
                    {
                        return order;
                    }
                }
            }
            return null;
        }

    }
}
