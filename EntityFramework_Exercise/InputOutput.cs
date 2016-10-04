using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework_Entities;

namespace EntityFramework_Exercise
{
    class InputOutput
    {
        public int PrintChoices()
        {
            int choice = 0;
            Console.WriteLine("\nChoose a Task");
            Console.WriteLine("[1]Read [2]Add [3]Edit [4]Delete [5]Native_Read [6]Native_StoredProc [7]Exit");
            Int32.TryParse(Console.ReadLine(), out choice);
            return choice;
        }

        public void checkProcess(bool process)
        {
            if(process == true)
            {
                Console.WriteLine("Process successful!");
            }
            else
            {
                Console.WriteLine("Process failed!");
            }
        }

        public int InputID()
        {
            int id = 0;
            Console.Write("Please enter ID: ");
            Int32.TryParse(Console.ReadLine(), out id);
            return id;
        }

        public string InputName()
        {
            string name = "";
            Console.Write("Please enter Name: ");
            name = Console.ReadLine();
            return name;
        }

        public string InputReason()
        {
            string reason = "";
            Console.Write("Please enter Reason Type: ");
            reason = Console.ReadLine();
            return reason;
        }

        public SalesReason ClassInput(int id, string name, string reason, DateTime date)
        {
            SalesReason input = new SalesReason() { SalesReasonID = id, Name = name, ReasonType = reason, ModifiedDate = date};
            return input;
        }

        public void OutputRecords(List<SalesReason> input)
        {
            if (input != null)
            {
                Console.WriteLine("{0,-5} {1,-30} {2,-5}", "ID", "Name", "Reason Type");
                foreach (var item in input)
                {
                    Console.WriteLine("{0,-5} {1,-30} {2,-5}", item.SalesReasonID, item.Name, item.ReasonType);
                }
            }
            else
            {
                Console.WriteLine("No Records Found!");
            }
        }

        public void OutputRecords(SalesReason input)
        {
            if(input != null)
            {
                Console.WriteLine();
                Console.WriteLine("{0,-15} {1,3} {2,-20}", "Sales Reason ID", ":", input.SalesReasonID);
                Console.WriteLine("{0,-15} {1,3} {2,-20}", "Name", ":", input.Name);
                Console.WriteLine("{0,-15} {1,3} {2,-20}", "Reason Type", ":", input.ReasonType);
                Console.WriteLine("{0,-15} {1,3} {2,-20}", "Date Modified", ":", input.ModifiedDate);
            }
            else
            {
                Console.WriteLine("No Records Found!");
            }

        }

        public void OutputEmployeeManager(List<EmployeeManager> input)
        {
            if (input != null)
            {
                Console.WriteLine("{0,-20} {1,-20}", "Employee Name", "Manager Name");
                foreach (var item in input)
                {
                    Console.WriteLine("{0,-20} {1,-20}", item.EmployeeName, item.ManagerName);
                }
            }
            else
            {
                Console.WriteLine("No Records Found!");
            }
        }

        public bool ConfirmDelete()
        {
            bool check;
            string input = "";
            Console.Write("Are you sure you want to delete?[y/n]");
            input = Console.ReadLine();
            if (input.Equals("y"))
            {
                check = true;
            }
            else
            {
                check = false;
                Console.WriteLine("Deleting cancelled!");
            }
            return check;
        }
    }
}
