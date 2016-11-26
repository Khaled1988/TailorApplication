using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tailor1WebApp.Models;

namespace Tailor1WebApp.BLL
{
    class TailorAppBLL
    {
        private TailorAppGateway tailorGateway;
        public TailorAppBLL()
        {
            tailorGateway = new TailorAppGateway();
        }

        #region Customer

        public string SaveCustomer(Customer aCustomer)
        {
            if (HasThisCustomer(aCustomer.CustomerIDNo))
            {
                return "CustomerID Already Exist";
            }
            else
            {
                return tailorGateway.SaveCustomer(aCustomer);
            }
        }
        private bool HasThisCustomer(string CustomerIdNumber)
        {
            return tailorGateway.HasThisCustomer(CustomerIdNumber);
        }
        public List<Customer> GetAllCustomer()
        {
            return tailorGateway.GetAllCustomer();
        }
        public List<Customer> GetAllCustomerByName(string customerName)
        {           
            return tailorGateway.GetAllCustomerByName(customerName);           
        }
        public List<Customer> GetAllCustomerByID(string customerID)
        {
            return tailorGateway.GetAllCustomerByID(customerID);           
        }
        public List<Customer> GetAllCustomerByMobile(string customerMobile)
        {
            return tailorGateway.GetAllCustomerByMobile(customerMobile);           
        }
        public int GetMaxCustomerID()
        {
            return tailorGateway.GetMaxCustomerID();
        }
        public string GetCustomerNameByID(int CustomerID)
        {
            return tailorGateway.GetCustomerNameByID(CustomerID);
        }
        public List<CustomerMeasurement> GetAllCustomerMeasurement()
        {
            return tailorGateway.GetAllCustomerMeasurement();
        }
        public List<CustomerMeasurement> GetAllCustomerMeasurementByName(string customername)
        {
            return tailorGateway.GetAllCustomerMeasurementByName(customername);
        }
        public List<CustomerMeasurement> GetAllCustomerMeasurementByMobile(string customerMobile)
        {
            return tailorGateway.GetAllCustomerMeasurementByMobile(customerMobile);
        }
        public List<Customer> GetAllCustomerByCustomerID(int customerID)
        {
            return tailorGateway.GetAllCustomerByCustomerID(customerID);
        }
        public string UpdateCustomer(Customer aCustomer, int customerIdHidden)
        {
            return tailorGateway.UpdateCustomer(aCustomer, customerIdHidden);
        }
        public List<CustomerMeasurement> GetCustomerMeasurementByCustomerID(int customerid)
        {
            return tailorGateway.GetCustomerMeasurementByCustomerID(customerid);
        }
        
        #endregion

        #region User

        public string SaveUser(User aUser)
        {
            return tailorGateway.SaveUser(aUser);
        }
        public string CheckUser(string userName, string Password)
        {
            if (userName == string.Empty || Password == string.Empty)
            {
                return "Please fill up both fields";
            }
            else
            {
                //if (HasThisUserName(userName) && HasThisPassword(Password))
                if (HasThisNamePassword(userName, Password))
                {
                    return "";
                }
                else if (HasThisUserName(userName) || HasThisPassword(Password))
                {
                    return "Enter Correct Username and Password";
                }
                else
                {
                    return "No User Found....Please Register!!";
                }
            }
        }
        private bool HasThisUserName(string userName)
        {
            return tailorGateway.HasThisName(userName);
        }
        private bool HasThisPassword(string password)
        {
            return tailorGateway.HasThisPassword(password);
        }
        private bool HasThisNamePassword(string username, string password)
        {
            return tailorGateway.HasThisNamePassword(username, password);
        }
        public List<User> GetUserInfoByUserID(string loginID)
        {
            return tailorGateway.GetUserInfoByUserID(loginID);
        }


        #endregion

        #region Measurement

        public string SaveMeasurement(Measurement aMeasurement)
        {
            return tailorGateway.SaveMeasurement(aMeasurement);
        }
        public List<DressMeasurement> GetDressMeasurementListByCustomerID(int CustomerID)
        {
            return tailorGateway.GetDressMeasurementListByCustomerID(CustomerID);
        }
        public List<Measurement> GetAllMeasurement()
        {
            return tailorGateway.GetAllMeasurement();
        }
        public string UpdateMeasurement(Measurement aMeasurement, int measurementHiddenID)
        {
            return tailorGateway.UpdateMeasurement(aMeasurement, measurementHiddenID);
        }

        #endregion

        #region Order

        public string SaveOrder(Order aOrder)
        {
            //return tailorGateway.SaveOrder(aOrder);
            if (HasThisOrderNo(aOrder.OrderNo))
            {
                return "Order No Already Exist";
            }
            else
            {
                return tailorGateway.SaveOrder(aOrder);
            }
        }
        public bool HasThisOrderNo(string OrderNumber)
        {
            return tailorGateway.HasThisOrderNo(OrderNumber);
        }
        public int GetOrderIDbyOrderNo(string OrderNo)
        {
            return tailorGateway.GetOrderIDbyOrderNo(OrderNo);
        }
        public string SaveOrderDetails(OrderDetail aOrderDetail)
        {
            return tailorGateway.SaveOrderDetails(aOrderDetail);
        }
        public List<Order> GetAllUndeliveredOrder()
        {
            return tailorGateway.GetAllUndeliveredOrder();
        }
        public List<Order> GetAllDeliveredOrder()
        {
            return tailorGateway.GetAllDeliveredOrder();
        }
        public List<Order> GetAllCanceledOrder()
        {
            return tailorGateway.GetAllCanceledOrder();
        }
        public int GetMaxOrderID()
        {
            return tailorGateway.GetMaxOrderID();
        }
        public List<Order> GetAllUndeliveredOrderByOrderNo(string searchText)
        {
            return tailorGateway.GetAllUndeliveredOrderByOrderNo(searchText);
        }
        public List<Order> GetAllOrder()
        {
            return tailorGateway.GetAllOrder();
        }
        public List<Measurement> GetAllMeasurementBymeasurementID(int measurementID)
        {
            return tailorGateway.GetAllMeasurementBymeasurementID(measurementID);
        }
        public List<CustomerDressOrder> GetCustomerDressOrderListByOrderNo(string OrderNo)
        {
            return tailorGateway.GetCustomerDressOrderListByOrderNo(OrderNo);
        }
        
        #endregion

        #region DressType

        public List<DressType> GetAllDressType()
        {
            return tailorGateway.GetAllDressType();
        }

        #endregion

        #region Delivery

        public string UpdateOrderDelivery(int OrderIDforUpdate)
        {
            return tailorGateway.UpdateOrderDelivery(OrderIDforUpdate);
        }
        public string CancilOrderDelivery(int OrderIDforUpdate)
        {
            return tailorGateway.CancilOrderDelivery(OrderIDforUpdate);
        }

        #endregion

        #region Supplier
        public List<Supplier> GetAllSupplier()
        {
            return tailorGateway.GetAllSupplier();
        }
        public string SaveSupplier(Supplier aSupplier)
        {
            return tailorGateway.SaveSupplier(aSupplier);
        }
        public string UpdateSupplier(Supplier aSupplier, string SupplierCode)
        {
            return tailorGateway.UpdateSupplier(aSupplier, SupplierCode);
        }
        public int GetMaxSupplierID()
        {
            return tailorGateway.GetMaxSupplierID();
        }
        public int GetSupplierIDBySupplierCode(string supplierCode)
        {
            return tailorGateway.GetSupplierIDBySupplierCode(supplierCode);
        }
        public List<SupplierProduct> GetAllSupplierProduct()
        {
            return tailorGateway.GetAllSupplierProduct();
        }
        public List<SupplierProduct> GetAllSupplierProductBySupplierName(string supplierName)
        {
            return tailorGateway.GetAllSupplierProductBySupplierName(supplierName);
        }
        public List<SupplierProduct> GetAllSupplierProductBySupplierMobile(string supplierMobile)
        {
            return tailorGateway.GetAllSupplierProductBySupplierMobile(supplierMobile);
        }
        public List<Supplier> GetAllSupplierBySupplierID(int supplierID)
        {
            return tailorGateway.GetAllSupplierBySupplierID(supplierID);
        }
        #endregion

        #region Material
        public string SaveMaterial(Material aMaterial)
        {
            return tailorGateway.SaveMaterial(aMaterial);
        }

        public string UpdateProduct(Material aMaterial, int supplierID)
        {
            return tailorGateway.UpdateProduct(aMaterial, supplierID);
        }
        public List<Material> GetAllMaterial()
        {
            return tailorGateway.GetAllMaterial();
        }
        
        public string SaveOrderMaterial(List<OrderMaterial> orderMaterialList)
        {
            return tailorGateway.SaveOrderMaterial(orderMaterialList);
        }
        public string UpdateOrderMaterial(List<OrderMaterial> orderMaterialList, string OrderNO)
        {
            tailorGateway.DeleteOrderMaterial(OrderNO);
            return tailorGateway.SaveOrderMaterial(orderMaterialList);  
        }
        private bool HasthisOrderNo(string orderNo)
        {
            return tailorGateway.HasthisOrderNo(orderNo);
        }
        public string GetMaterialUnitByCode(string MaterialCode)
        {
            return tailorGateway.GetMaterialUnitByCode(MaterialCode);
        }
        public List<OrderMaterial> GetOrderMaterialByOrderNo(string searchText)
        {
            return tailorGateway.GetOrderMaterialByOrderNo(searchText);
        }
        public List<OrderMaterial> GetMaterialRequsitionBetweenFromToDate(string fromDATE, string toDATE)
        {
            return tailorGateway.GetMaterialRequsitionBetweenFromToDate(fromDATE, toDATE);
        }

        public List<Material> GetAllMaterialBySupplierID(int supplierID)
        {
            return tailorGateway.GetAllMaterialBySupplierID(supplierID);
        }

        #endregion

        #region DressType
        public string SaveDressType(DressType aDressType)
        {
            return tailorGateway.SaveDressType(aDressType);
        }
        public List<DressType> GetAllDressTypeByID(int dressTypeID)
        {
            return tailorGateway.GetAllDressTypeByID(dressTypeID);
        }
        public string UpdateDressType(DressType aDressType, int DressTypeID)
        {
            return tailorGateway.UpdateDressType(aDressType, DressTypeID);
        }
        #endregion






        
    }
}