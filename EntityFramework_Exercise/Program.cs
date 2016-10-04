using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework_BL;
using EntityFramework_Entities;

namespace EntityFramework_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var bl = new ClassManager();
            var io = new InputOutput();

            int choiceNum = 0;

            while(choiceNum != 7)
            {
                int id = 0;
                string reasonType = null;
                string name = null;
                DateTime date = DateTime.Now;
                SalesReason classInput;
                Console.Clear();
                io.OutputRecords(bl.ReadSalesReason());
                choiceNum = io.PrintChoices();
                switch(choiceNum)
                {
                    case 1:
                        id = io.InputID();
                        classInput = io.ClassInput(id, name, reasonType, date);
                        io.OutputRecords(bl.ReadSalesReason(classInput));
                        break;
                    case 2:
                        name = io.InputName();
                        reasonType = io.InputReason();
                        classInput = io.ClassInput(id, name, reasonType, date);
                        io.checkProcess(bl.CreateNewSalesReason(classInput));
                        break;
                    case 3:
                        id = io.InputID();
                        name = io.InputName();
                        reasonType = io.InputReason();
                        classInput = io.ClassInput(id, name, reasonType, date);
                        io.checkProcess(bl.UpdateSalesReason(classInput));
                        break;
                    case 4:
                        id = io.InputID();
                        if(io.ConfirmDelete() == true)
                        {
                            classInput = io.ClassInput(id, name, reasonType, date);
                            io.checkProcess(bl.DeleteSalesReason(classInput));
                        }
                        break;
                    case 5:
                        id = io.InputID();
                        classInput = io.ClassInput(id, name, reasonType, date);
                        io.OutputRecords(bl.NativeSqlRetrieve(classInput));
                        break;
                    case 6:
                        id = io.InputID();
                        io.OutputEmployeeManager(bl.NativeSqlStoredProc(id));
                        break;
                }
                Console.ReadLine();
            }         
            
        }
    }
}
