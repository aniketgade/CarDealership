using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Tables
{
    public class SaleLog
    {
        public int SaleId { get; set; }
        public string BuyerName { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public decimal PurchasePrice { get; set; }
        public string PurchaseType { get; set; }
        public int VehicleId { get; set; }
        public string Phone { get; set; }
        public string SalesUserId { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}
