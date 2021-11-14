using furniture_system_web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace furniture_system_web.Repositories.Logics
{
    public class ProductionRepository : IProductionRepository
    {
        public async Task<bool> SaveBill(ProductionVM model)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    Random random = new Random();

                    DateTime thisDay = DateTime.Today;

                    var Bill_Code = Convert.ToString(random.Next(1000, 200000));

                    Production pro = new Production();

                    pro.Bill_Code = "BC_" + Bill_Code;
                    pro.Customer_Name = model.Customer_Name;
                    pro.Customer_Mobile = model.Customer_Mobile;
                    pro.Created_Date = thisDay;
                    pro.Created_By = "supun samarawickrama";
                    db.productions.Add(pro);
                    await db.SaveChangesAsync();

                    ProductionCart productionCart = new ProductionCart();

                    foreach (var item in model.ProductionCarts)
                    {
                        productionCart.Bill_Code = item.Bill_Code;
                        productionCart.Discount = item.Discount;
                        productionCart.Item_Code = item.Item_Code;
                        productionCart.Quentity = item.Quentity;
                        productionCart.Total_Amount = item.Total_Amount;

                        db.ProductionCarts.Add(productionCart);
                        await db.SaveChangesAsync();

                        ManageStock(item.Item_Code , item.Quentity);
                    }


                    if (model.Payment_Type == "cash")
                    {
                        CashProduction cash = new CashProduction();
                        cash.Bill_Code = Bill_Code;
                        cash.Customer_Bill = model.Customer_Bill;
                        cash.Customer_Payment = model.Customer_Payment;
                        cash.Customer_Balence = model.Customer_Balence;
                        cash.Created_By = "supun samarawickrama";
                        cash.Created_Date = thisDay;

                        db.cashProductions.Add(cash);
                        await db.SaveChangesAsync();
                    }
                    else if (model.Payment_Type == "check")
                    {

                        CheckProduction check = new CheckProduction();
                        check.Bill_Code = Bill_Code;
                        check.Check_Number = model.Check_Number;
                        check.Customer_Bill = model.Customer_Bill;
                        check.Customer_Payment = model.Customer_Payment;
                        check.Customer_Balence = model.Customer_Balence;
                        check.Created_By = "supun samarawickrama";
                        check.Created_Date = thisDay;

                        db.checkProductions.Add(check);
                        await db.SaveChangesAsync();
                    }
                    else
                    {

                        CardProduction card = new CardProduction();
                        card.Bill_Code = Bill_Code;
                        card.Bank_Name = model.Bank_Name;
                        card.Customer_Bill = model.Customer_Bill;
                        card.Customer_Payment = model.Customer_Payment;
                        card.Customer_Balence = model.Customer_Balence;
                        card.Created_By = "supun samarawickrama";
                        card.Created_Date = thisDay;

                        db.cardProductions.Add(card);
                        await db.SaveChangesAsync();
                    }
               

                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ManageStock(string itemcode , int quentity)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var _exists = db.stocks.Where(x => x.Item_Code == itemcode).FirstOrDefault();

                    _exists.Quentity = _exists.Quentity - quentity;
                    db.Entry(_exists).CurrentValues.SetValues(_exists);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
