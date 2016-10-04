using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework_Entities;
using System.Data.SqlClient;

namespace EntityFramework_BL
{
    public class ClassManager
    {
        static List<Exception> exceptionList = new List<Exception>();
        DateTime date = DateTime.Now;

        public List<SalesReason> ReadSalesReason()
        {
            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    var result = (from salesReason in context.SalesReasons
                                  orderby salesReason.Name
                                  select salesReason).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                exceptionList.Add(ex);
            }
            return null;
        }

        public SalesReason ReadSalesReason(SalesReason input)
        {
            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    SalesReason results = context.SalesReasons.Where(x => x.SalesReasonID == input.SalesReasonID).SingleOrDefault();
                    return results;
                }
            }
            catch (Exception ex)
            {
                exceptionList.Add(ex);        
            }
            return null;
        }

        public void test()
        {

        }

        public bool CreateNewSalesReason(SalesReason input)
        {
            bool returnValue = false;
            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    //salesReason.Name = input.Name;
                    //salesReason.ReasonType = input.ReasonType;
                    //salesReason.ModifiedDate = input.ModifiedDate;
                    input.ModifiedDate = DateTime.Now;
                    context.SalesReasons.Add(input);
                    context.SaveChanges();
                    returnValue = true;
                }
            }
            catch (Exception ex)
            {
                exceptionList.Add(ex);
                returnValue = false;
            }
            return returnValue;
        }

        public bool UpdateSalesReason(SalesReason input)
        {
            bool returnValue = false;
            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    SalesReason result = (from salesReason in context.SalesReasons
                                          where salesReason.SalesReasonID == input.SalesReasonID
                                          select salesReason).SingleOrDefault();

                    if (result != null)
                    {
                        result.Name = input.Name;
                        result.ReasonType = input.ReasonType;
                        context.SaveChanges();
                        returnValue = true;
                    }
                    else
                    {
                        returnValue = false;
                    }
                }
            }
            catch(Exception ex)
            {
                exceptionList.Add(ex);
                returnValue = false;
            }
            return returnValue;
        }

        public bool DeleteSalesReason(SalesReason input)
        {
            bool returnValue = false;

            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    if(input.SalesReasonID > 0)
                    {
                        context.Database.ExecuteSqlCommand("DELETE FROM Sales.SalesReason WHERE SalesReasonID = @ID", new SqlParameter("@ID", input.SalesReasonID));
                        context.SaveChanges();
                        returnValue = true;
                    }
                    else
                    {
                        returnValue = false;
                    }
                }
            }
            catch (Exception ex)
            {
                exceptionList.Add(ex);
                returnValue = false;
            }
            return returnValue;
        }

        public SalesReason NativeSqlRetrieve(SalesReason input)
        {
            SalesReason result;
            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    result = context.Database.SqlQuery<SalesReason>("SELECT * FROM Sales.SalesReason WHERE SalesReasonID = @ID",new SqlParameter("@ID", input.SalesReasonID)).SingleOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                exceptionList.Add(ex);
            }
            return null;
        }

        public List<EmployeeManager> NativeSqlStoredProc(int inputID)
        {
            List<EmployeeManager> empManagerList = new List<EmployeeManager>();

            using (var context = new AdventureWorks2008Entities())
            {
                var result = context.Database.SqlQuery<uspGetEmployeeManagers_Result>("uspGetEmployeeManagers @ID",new SqlParameter("@ID", inputID)).ToList();
                foreach(var item in result)
                {
                    var empName = item.FirstName + " " + item.LastName;
                    var managerName = item.ManagerFirstName + " " + item.ManagerLastName;
                    empManagerList.Add(new EmployeeManager{  EmployeeName = empName, ManagerName = managerName});
                }
                return empManagerList;
            }
        }
    }
}
