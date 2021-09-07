using System;
using System.Threading.Tasks;
using Management.Models;
using Management.Commons;
using Management.BusinessLogic;

namespace Management.UI
{
    public class StoreRegistration
    {
        private readonly IBusinessLogicStore _actionsStore;

        //use null coalescing operator to return the value of actions operand if not null, else throw exception
        public StoreRegistration(IBusinessLogicStore actionsStore)
        {
            _actionsStore = actionsStore ?? throw new ArgumentNullException(nameof(actionsStore));
        }

        private string storeName;
        private string storeNumber;
        private string storeType;
        private int storeProducts; 
        private string userId; 

        public async Task DisplayStore()
        {
            try
            {
                System.Console.WriteLine("Create your store");

                System.Console.WriteLine("Enter store name");
                string storeNameInput = Console.ReadLine();
                storeName = StoreValidation.FormatName(storeNameInput);

                System.Console.WriteLine("Enter store number");
                string storeNumberInput = Console.ReadLine();
                storeNumber = StoreValidation.FormatStoreNumber(storeNumberInput);

                System.Console.WriteLine("Enter store type");
                string storeTypeInput = Console.ReadLine();
                storeType = StoreValidation.FormatName(storeTypeInput);

                System.Console.WriteLine("Enter store products");
                var storeProductsInput = StoreValidation.IsValidInput(Console.ReadLine());
                if(storeProductsInput == -1)
                {
                    System.Console.WriteLine("Kindly enter numbers");
                    storeProductsInput = StoreValidation.IsValidInput(Console.ReadLine());
                }
                storeProducts = StoreValidation.ValidateProducts(storeProductsInput);

                System.Console.WriteLine("Enter user Id");
                string userIdInput = Console.ReadLine();
                userId = StoreValidation.FormatStoreNumber(userIdInput);

                var store = await _actionsStore.CreateStore(storeName, storeNumber, storeType, storeProducts, userId);
                System.Console.WriteLine($"Your {storeName} has been created succesfully");
            }
            catch (FormatException ex) 
            //Catch all errors relating to argument formats operations
            {

                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception e)  
            //Catch all unforseen errors
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}




