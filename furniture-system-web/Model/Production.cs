using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace furniture_system_web.Model
{
    public class Production
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Bill_Code { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Mobile { get; set; }
        public DateTime Created_Date { get; set; }
        public string Created_By { get; set; }
        public bool Status { get; set; }
    }

    public class CashProduction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Bill_Code { get; set; }
        public double Customer_Bill { get; set; }
        public double Customer_Payment { get; set; }
        public double Customer_Balence { get; set; }
        public DateTime Created_Date { get; set; }
        public string Created_By { get; set; }
        public bool Status { get; set; }
    }

    public class CheckProduction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Bill_Code { get; set; }
        public string Check_Number { get; set; }
        public double Customer_Bill { get; set; }
        public double Customer_Payment { get; set; }
        public double Customer_Balence { get; set; }
        public DateTime Created_Date { get; set; }
        public string Created_By { get; set; }
        public bool Status { get; set; }
    }

    public class CardProduction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Bill_Code { get; set; }
        public string Bank_Name { get; set; }
        public double Customer_Bill { get; set; }
        public double Customer_Payment { get; set; }
        public double Customer_Balence { get; set; }
        public DateTime Created_Date { get; set; }
        public string Created_By { get; set; }
        public bool Status { get; set; }
    }

    public class ProductionCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Bill_Code { get; set; }
        public string Item_Code { get; set; }
        public double Discount { get; set; }
        public int Quentity { get; set; }
        public double Total_Amount { get; set; }
        public bool Status { get; set; }
    }

    public class ProductionVM
    {
        public string Payment_Type { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Mobile { get; set; }
        public string Check_Number { get; set; }
        public double Customer_Bill { get; set; }
        public double Customer_Payment { get; set; }
        public double Customer_Balence { get; set; }
        public string Bank_Name { get; set; }
        public List<ProductionCart> ProductionCarts { get; set; }
    }


}
